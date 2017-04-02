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
        public HandlerPolyline PlineGetFromUser { get; set; }
        public dynamic ObjPlace { get; set; }

        public ObjPlaced(dynamic objPlace, HandlerPolyline plineGetFromUser)
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

            // какой тип объекта расставляем (блок либо обычную геометрию).у текстов отдельная обработка.
            if (ObjPlace is McBlockRef)
            {
                McBlockRef objPlMcBlockRef = new McBlockRef();
                objPlMcBlockRef = ObjPlace as McBlockRef;

                foreach (Point3d onePt in Vertices)
                {
                    McBlockRef refBlock = new McBlockRef();
                    String selBlock = objPlMcBlockRef.BlockName;
                    refBlock.DbEntity.MatchProperties(objPlMcBlockRef.DbEntity, MatchPropEnum.All);//копирование свойств
                    refBlock.BlockName = selBlock;
                    refBlock.DbEntity.AddToCurrentDocument();

                    Point3d centrObj = refBlock.InsertPoint;
                    Vector3d vec = centrObj.GetVectorTo(onePt);
                    Matrix3d mat = Matrix3d.Displacement(vec);
                    refBlock.DbEntity.Transform(mat);
                }
            }

            else if (ObjPlace is DbText)
            {
                DbText objPlDbText = new DbText();
                objPlDbText = ObjPlace as DbText;

                foreach (Point3d onePt in Vertices)
                {
                    McDbObject cloneGeom = objPlDbText.DbEntity.Clone() as McDbObject;
                    cloneGeom.Entity.DbEntity.MatchProperties(objPlDbText.DbEntity, MatchPropEnum.All);//копирование свойств
                    Point3d centrObj = objPlDbText.Text.Origin;
                    Vector3d vec = centrObj.GetVectorTo(onePt);
                    Matrix3d mat = Matrix3d.Displacement(vec);
                    cloneGeom.Entity.DbEntity.Transform(mat);
                    cloneGeom.Entity.DbEntity.AddToCurrentDocument();
                }
            }

            else
            {
                DbGeometry objPlDbGeometry = new DbGeometry();
                objPlDbGeometry = ObjPlace as DbGeometry; 

                foreach (Point3d onePt in Vertices)
                {
                    McDbObject cloneGeom = objPlDbGeometry.DbEntity.Clone() as McDbObject;
                    cloneGeom.Entity.DbEntity.MatchProperties(objPlDbGeometry.DbEntity, MatchPropEnum.All);//копирование свойств
                    Point3d centrObj = cloneGeom.Entity.DbEntity.BoundingBox.Center;
                    Vector3d vec = centrObj.GetVectorTo(onePt);
                    Matrix3d mat = Matrix3d.Displacement(vec);
                    cloneGeom.Entity.DbEntity.Transform(mat);
                    cloneGeom.Entity.DbEntity.AddToCurrentDocument();
                }
            }

        }
    }
}
