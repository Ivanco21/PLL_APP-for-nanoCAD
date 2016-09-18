using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Multicad.DatabaseServices.StandardObjects;
using Multicad.Geometry;

namespace PLL_APP
{
   public class PolylineProperties: DbPolyline
    {
        public bool closed { get; set; }
        public bool closeAndDuplicateVertex { get; set; }

        public PolylineProperties(DbPolyline plineItem)
        {
            this.closed = plineItem.Polyline.ClosedLogically;

            if(plineItem.Polyline.ClosedLogically == true && (plineItem.Polyline.Vertices.First().Point.X == plineItem.Polyline.Vertices.Last().Point.X)
                                                              && (plineItem.Polyline.Vertices.First().Point.Y == plineItem.Polyline.Vertices.Last().Point.Y)
                                                              && (plineItem.Polyline.Vertices.First().Point.Z == plineItem.Polyline.Vertices.Last().Point.Z))
            {
              this.closeAndDuplicateVertex = true;
            }
            else 
            {
              this.closeAndDuplicateVertex = false;
            }
        }

        public List<Point3d> listVertecs(DbPolyline plineItem)
        {
            List<Point3d> Vertices = new List<Point3d>();
            // собираем все вершины в list
            for (int i1 = 0; i1 < plineItem.Polyline.Vertices.Count; i1++)
            {
                Point3d Vertex = new Point3d(); double Bulge; double startWidth; double endWidth; Vector3d nrm;
                plineItem.Polyline.Vertices.GetVertexAt((uint)i1, out Vertex, out Bulge, out startWidth, out endWidth, out nrm);
                Vertices.Add(Vertex);
            }
            return Vertices;
        }
    }
}
