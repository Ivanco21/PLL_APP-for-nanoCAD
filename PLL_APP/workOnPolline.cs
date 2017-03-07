using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

using Multicad;
using Multicad.Geometry;
using Multicad.DatabaseServices;
using Multicad.DatabaseServices.StandardObjects;
using Multicad.Symbols.Tables;
using Multicad.Runtime;

namespace PLL_APP
{
   partial class HandlerPolyline
    { 
        public void reversPolyline ()
       {  
            PolylineProperties plForWork = new PolylineProperties(plineGetFromUser);
            List<Point3d> Vert = new List<Point3d>();
            Vert = plForWork.listVertecs(plineGetFromUser); 

            if (plForWork.closed == false)
            {
              Vert.Reverse();
            }
            else if (plForWork.closeAndDuplicateVertex == true)
            {
                Vert.Reverse();
            }
            else
            {
              Vert.Reverse(1, Vert.Count - 1);
            }

            Polyline3d reversPL3d = new Polyline3d(Vert);

            if (plineGetFromUser.Polyline.ClosedLogically == true)
            {
              reversPL3d.SetClosed(true);
            }
            DbPolyline plForWrite = new DbPolyline();
            
            
            plForWrite = reversPL3d;
            plForWrite.DbEntity.MatchProperties(plineGetFromUser.DbEntity, MatchPropEnum.All);//копирование свойств
            plineGetFromUser.DbEntity.Erase();// удаляет исходную PL из чертежа
            plForWrite.DbEntity.AddToCurrentDocument();
                         
        }

        public void numberInDwg(int inputUserTextHeight) 
        {
            PolylineProperties plForWork = new PolylineProperties(plineGetFromUser);
            List<Point3d> Vert = new List<Point3d>();
            Vert = plForWork.listVertecs(plineGetFromUser);

            Vector3d forTextVector = new Vector3d(100, 0, 0);
            double hTx = inputUserTextHeight; // получаем от пользователя
            // экземпляр класса создается т.к. TextGeom не поддерживает AddToCurrentDocument()
            DbText forDraw = new DbText();

            for (int i = 0; i < Vert.Count; i++)
            {
                TextGeom textNumberPoint = new TextGeom(Convert.ToString(i + 1), Vert[i], forTextVector, "");
                textNumberPoint.Height = hTx;
                forDraw = textNumberPoint;
                forDraw.DbEntity.AddToCurrentDocument();
            }


        }

        public McTable vertexInTable(DbPolyline plineGetFromUser, string accuracyPoint) 
        {
            PolylineProperties plForWork = new PolylineProperties(plineGetFromUser);
            List<Point3d> Vert = new List<Point3d>();
            Vert = plForWork.listVertecs(plineGetFromUser);

            // создаем таблицу
            McTable TablePoint = new McTable();
            int rowCount = Vert.Count;
            int colCount = 4;
            TablePoint.Rows.AddRange(0, rowCount + 1);
            TablePoint.Columns.AddRange(0, colCount);

            // настройки таблицы по умолчанию
            TablePoint.DefaultCell.TextHeight = 2.5;
            TablePoint.DefaultCell.TextColor = System.Drawing.Color.Black;

            // наименование_столбцов
            TablePoint[0, 0].Value = "№_Point";
            TablePoint[0, 1].Value = "X";
            TablePoint[0, 2].Value = "Y";
            TablePoint[0, 3].Value = "Z";

            //номера точек в ячейки и  координата X,Y,Z
            for (int i = 0; i < Vert.Count; i++)
            {
                Point3d onePointAtList = new Point3d();
                onePointAtList = Vert[i];
                int j = i + 1;
                // точность представления чисел в ячейках - получается из формы от пользователя , выбираем из enum 
                switch (accuracyPoint)
                {
                    case "0":
                        TablePoint[j, 1].Precision = CellPrecisionEnum.Integer;
                        TablePoint[j, 2].Precision = CellPrecisionEnum.Integer;
                        TablePoint[j, 3].Precision = CellPrecisionEnum.Integer;
                        break;

                    case "0.0":
                        TablePoint[j, 1].Precision = CellPrecisionEnum.Precision1;
                        TablePoint[j, 2].Precision = CellPrecisionEnum.Precision1;
                        TablePoint[j, 3].Precision = CellPrecisionEnum.Precision1;
                        break;

                    case "0.00":
                        TablePoint[j, 1].Precision = CellPrecisionEnum.Precision2;
                        TablePoint[j, 2].Precision = CellPrecisionEnum.Precision2;
                        TablePoint[j, 3].Precision = CellPrecisionEnum.Precision2;
                        break;

                    case "0.000":
                        TablePoint[j, 1].Precision = CellPrecisionEnum.Precision3;
                        TablePoint[j, 2].Precision = CellPrecisionEnum.Precision3;
                        TablePoint[j, 3].Precision = CellPrecisionEnum.Precision3;
                        break;
                }

            //номера точек в ячейки и  координата X,Y,Z
            TablePoint[j, 0].Type = CellFormatEnum.Number;
            TablePoint[j, 0].Value = j.ToString();

            TablePoint[j, 1].Type = CellFormatEnum.Number;
            TablePoint[j, 1].Value = onePointAtList.X.ToString();

            TablePoint[j, 2].Type = CellFormatEnum.Number;
            TablePoint[j, 2].Value = onePointAtList.Y.ToString();

            TablePoint[j, 3].Type = CellFormatEnum.Number;
            TablePoint[j, 3].Value = onePointAtList.Z.ToString();
          }

            return TablePoint;
       }

        public void vertexInTableOutDwg(string accuracyPoint)
        {
            // создаем таблицу на чертеже
            McTable TablePoint = vertexInTable(plineGetFromUser,accuracyPoint);
            TablePoint.PlaceObject(McEntity.PlaceFlags.Silent);

        }

        public void vertexInTableOutCsv(string accuracyPoint)
        {
            //выгружаем в csv
            McTable TablePoint = vertexInTable(plineGetFromUser, accuracyPoint);
            TablePoint.SaveToFile();
        }

        public void deletDuplicatedVertexPolyline()
        {
            PolylineProperties plForWork = new PolylineProperties(plineGetFromUser);
            //на LINQ            
            int i = plForWork.listVertecs(plineGetFromUser).Select(CompareFactor => new { CompareFactor.X, CompareFactor.Y, CompareFactor.Z }).Count();
            int j = plForWork.listVertecs(plineGetFromUser).Select(CompareFactor => new { CompareFactor.X, CompareFactor.Y, CompareFactor.Z }).Distinct().Count();

            if (i == j)
            {
              MessageBox.Show("У данной полилинии нет одинаковых/задвоенных вершин");
              return;
            }

            var list = plForWork.listVertecs(plineGetFromUser).Select(CompareFactor => new { CompareFactor.X, CompareFactor.Y, CompareFactor.Z }).Distinct();

            List<Point3d> Vertex = new List<Point3d>();
            foreach (var item in list)
            {
              Point3d PointForList = new Point3d(item.X, item.Y, item.Z);
              Vertex.Add(PointForList);
            }
         
            Polyline3d PL3dNonDuplicatePoints = new Polyline3d(Vertex);
            if (plineGetFromUser.Polyline.ClosedLogically == true)
            {
              PL3dNonDuplicatePoints.SetClosed(true);
            }
            plineGetFromUser.DbEntity.Erase();
            plineGetFromUser = PL3dNonDuplicatePoints;
            plineGetFromUser.DbEntity.AddToCurrentDocument();       
        }

        public void fitPolyline(double tolerance, bool delSoursePL)
       {
          PolylineProperties plForWork = new PolylineProperties(plineGetFromUser);
          List<Point3d> Vert = new List<Point3d>();
          List<Point3d> delVert = new List<Point3d>();
          Vert = plForWork.listVertecs(plineGetFromUser);

          if (plForWork.closeAndDuplicateVertex == false && plineGetFromUser.Polyline.ClosedLogically == true)
          {
              for (uint i = 0; i < plineGetFromUser.Polyline.Segments.Count; i++)
              {
                  Curve3d oneSegment = plineGetFromUser.Polyline.Segments.GetSegAt(i, true);
                  int j = Convert.ToInt32(i);

                  if (j == plineGetFromUser.Polyline.Segments.Count - 1 && oneSegment.Length(0, 1) < tolerance) // дописать логику. что делать если последний сегмент замкнутой поллинии короткий?
                  {

                  }
                  else if (oneSegment.Length(0, 1) < tolerance)
                  {
                      delVert.Add(Vert[j + 1]);
                  }
              }
          }
          else
          {
              for (uint i = 0; i < plineGetFromUser.Polyline.Segments.Count; i++)
              {
                  Curve3d oneSegment = plineGetFromUser.Polyline.Segments.GetSegAt(i, true);
                  int j = Convert.ToInt32(i);
                  if (oneSegment.Length(0, 1) < tolerance)
                  {
                      delVert.Add(Vert[j + 1]);
                  }
              }
          }
         
           List<Point3d> resultVertex = new List<Point3d>();

           if (delVert.Count == 0)
           {
               MessageBox.Show("Коротких сегментов не найдено");
               return;
           }
           else if (delVert.Count == Vert.Count-1)// в случае если все сегменты меньше заданного значения -соединяем первую и последнюю точку
           {
               resultVertex.Add(plineGetFromUser.Polyline.Points.FirstPoint);
               resultVertex.Add(plineGetFromUser.Polyline.Points.LastPoint);
           }
           else
           {
               var result = Vert.Except(delVert);// на LINQ с помощью метода Except можно получить разность двух множеств
               foreach (var item in result)
               {
                   Point3d PointForList = new Point3d(item.X, item.Y, item.Z);
                   resultVertex.Add(PointForList);
               }
           }
               
          Polyline3d PL3dFited = new Polyline3d(resultVertex);
        
          if (plineGetFromUser.Polyline.ClosedLogically == true)
          {
              PL3dFited.SetClosed(true);
          }

          if (delSoursePL == true)// проверка удалять ли исходную Pl - чекбокс в форме
          {
              plineGetFromUser.DbEntity.Erase();
          }
          plineGetFromUser = PL3dFited;
          plineGetFromUser.DbEntity.AddToCurrentDocument();
          
       }

    }
}