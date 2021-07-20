using System;
using System.Collections.Generic;
using System.Text;

using Multicad;
using Multicad.Symbols;
using Multicad.Geometry;
using Multicad.DatabaseServices;
using Multicad.DatabaseServices.StandardObjects;

namespace PLL_APP
{
    class NotesWorker
    {

        public HandlerPolyline plineItem { get; set; }

        public NotesWorker(HandlerPolyline plineGetFromUser)
        {
            plineItem = plineGetFromUser;
        }

        public void AddXYnotes(bool isUcsUsed, bool isXyCoordRevers, string accuracyNote )
        {
            if (plineItem == null)
            {
                return;
            }

            //определяем какая нужна точность для вывода значения координат
            int accuracyNoteInt = 0;
            switch (accuracyNote)
            {
                case "0":
                    accuracyNoteInt = 0;
                    break;

                case "0.0":
                    accuracyNoteInt = 1;
                    break;

                case "0.00":
                    accuracyNoteInt = 2;
                    break;

                case "0.000":
                    accuracyNoteInt = 3;
                    break;
            }

            // учитываем  систему координат
            McDocument doc = McDocument.WorkingDocument;
            Matrix3d matCurrent = doc.UCS;
            Matrix3d matUsc = matCurrent.Inverse();

            List<Point3d> plVertexs = new List<Point3d>();
            // собираем все вершины в list
            plVertexs = this.plineItem.listVertecs(this.plineItem.plineGetFromUser);

            foreach (Point3d onePt in plVertexs)
            {

                Point3d firstNotePt = new Point3d();
                firstNotePt = onePt;

                Matrix3d movementMat = Matrix3d.Displacement(new Vector3d(500, 500, 0));
                Point3d secondNotePt = new Point3d();
                secondNotePt = firstNotePt;
                secondNotePt = secondNotePt.TransformBy(movementMat);


                McNotePosition notePos = new McNotePosition();
                notePos.Origin = secondNotePt;
                notePos.Leader.AddSegment(firstNotePt, secondNotePt);
                notePos.Arrow = Arrows.Arrow;


                Point3d coordPt = new Point3d();
                coordPt = onePt;
                // преобразовать в UCS?
                if (isUcsUsed)
                {
                    coordPt = coordPt.TransformBy(matUsc);// преобразуем в текущую систему координат
                }

                if (!isXyCoordRevers)
                {
                    notePos.FirstLine= Math.Round(coordPt.X, accuracyNoteInt).ToString();
                    notePos.SecondLine = Math.Round(coordPt.Y, accuracyNoteInt).ToString();
                }
                else
                {
                    notePos.FirstLine = Math.Round(coordPt.Y, accuracyNoteInt).ToString();
                    notePos.SecondLine = Math.Round(coordPt.X, accuracyNoteInt).ToString();
                }

                notePos.DbEntity.Color = Multicad.Constants.Colors.ByLayer;
                notePos.DbEntity.AddToCurrentDocument();
                notePos.DbEntity.Update();
            }

        }
    }
}
