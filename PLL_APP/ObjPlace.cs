using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;


using Multicad;
using Multicad.DatabaseServices;
using Multicad.Geometry;
using Multicad.Runtime;
using Multicad.DatabaseServices.StandardObjects;

namespace PLL_APP
{
    class ObjPlaced
    {
        public DbGeometry ObjPlace { get; set; }
        public HandlerPolyline PlineGetFromUser { get; set; }
        public ObjPlaced (ref DbGeometry objPlace, ref HandlerPolyline plineGetFromUser)
        {
            ObjPlace = objPlace;
            PlineGetFromUser = plineGetFromUser; 
        }
        public void geometryPlaceToPlVertex()
        {
             // учитываем  систему координат
            McDocument doc = McDocument.WorkingDocument;
            Matrix3d matCurrent = doc.UCS;
            Matrix3d matUsc = matCurrent.Inverse();

            List<Point3d> Vertices = new List<Point3d>();
            // собираем все вершины в list
            Vertices = this.PlineGetFromUser.listVertecs(this.PlineGetFromUser.plineGetFromUser);

            foreach (Point3d onePt in Vertices)
            {
                McDbObject cloneGeom  = this.ObjPlace.DbEntity.Clone() as McDbObject;
                Point3d centrObj = cloneGeom.Entity.DbEntity.BoundingBox.Center;
                Vector3d vec = centrObj.GetVectorTo(onePt);
                Matrix3d mat = Matrix3d.Displacement(vec);
                cloneGeom.Entity.DbEntity.Transform(mat);  
                cloneGeom.Entity.DbEntity.AddToCurrentDocument();
            }
      


//          IsHardReference 
//Содержит HardReference на блок/объект, вытягивает объех исходник при копировании

//http://docs.autodesk.com/ACD/2013/ENU/index.html?url=files/GUID-E02A8AAF-61FF-4C72-8960-0AEEBBEC2594.htm,topicNumber=d30e720156

//// Create a copy of the circle and change its radius
//      Circle acCircClone = acCirc.Clone() as Circle;
//      acCircClone.Radius = 1;


// BoundBlock - вроде блок это. 


        }

        public void blockPlaceToPlVertex(McBlockRef objPlace, HandlerPolyline pl)
        {

        }


    }
}
