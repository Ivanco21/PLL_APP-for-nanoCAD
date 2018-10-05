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
    partial class HandlerPolyline : DbPolyline
    {
       public DbPolyline plineGetFromUser { get; set; }
        public HandlerPolyline(DbPolyline Pl)
        {
            plineGetFromUser = Pl;
        }

        public void reversPolyline ()
       {  
           
            List<Point3d> Vert = new List<Point3d>();
            Vert = this.listVertecs(plineGetFromUser);

            if (this.Polyline.ClosedLogically == false)
            {
              Vert.Reverse();
            }
            else if (this.closeAndDuplicateVertex == true)
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

        public void numberInDwg(int inputUserTextHeight, int startNumber) 
        {
            int vertStartNum = startNumber;
            List<Point3d> Vert = new List<Point3d>();
            Vert = this.listVertecs(plineGetFromUser);

            Vector3d forTextVector = new Vector3d(100, 0, 0);
            double hTx = inputUserTextHeight; // получаем от пользователя
            DbText forDraw = new DbText();

            for (int i = 0; i < Vert.Count; i++)
            {
                TextGeom textNumberPoint = new TextGeom(Convert.ToString(i + startNumber), Vert[i], forTextVector, "");
                textNumberPoint.Height = hTx;
                forDraw = textNumberPoint;
                forDraw.DbEntity.AddToCurrentDocument();
                vertStartNum = vertStartNum + 1;
            }


        }

        public McTable vertexInTable(DbPolyline plineGetFromUser, string accuracyPoint) 
        {
            
            List<Point3d> Vert = new List<Point3d>();
            Vert = this.listVertecs(plineGetFromUser);

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
            // учитываем  систему координат
            McDocument doc = McDocument.WorkingDocument;
            Matrix3d matCurrent = doc.UCS;
            Matrix3d matUsc = matCurrent.Inverse(); 
             
            //номера точек в ячейки и  координата X,Y,Z
            for (int i = 0; i < Vert.Count; i++)
            {
                Point3d onePointAtList = new Point3d();
                onePointAtList = Vert[i];
                onePointAtList = onePointAtList.TransformBy(matUsc);// преобразуем в текущую систему координат
                int j = i + 1;
                // точность представления чисел в ячейках - получается из формы от пользователя 
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

        public McTable vertexInTableKadastrForm(DbPolyline plineGetFromUser, string accuracyPoint)
        {

            List<Point3d> Vert = new List<Point3d>();
            Vert = this.listVertecs(plineGetFromUser);

            // создаем таблицу  //rows - строки , colums - столбцы
            McTable TablePoint = new McTable();
            int rowCount = Vert.Count;
            int allRowCount = rowCount + 4;// add header
            int colCount = 3;
            TablePoint.Rows.AddRange(0, allRowCount);
            TablePoint.Columns.AddRange(0, colCount);

            // Header merge
            System.Drawing.Rectangle rectHeader = new System.Drawing.Rectangle(0, 0, colCount - 1, 0);
            TablePoint.Merge(rectHeader);
            // second header 
            System.Drawing.Rectangle rectSecondHeader = new System.Drawing.Rectangle(0, 1, colCount - 1, 0);
            TablePoint.Merge(rectSecondHeader);
            // first rect
            System.Drawing.Rectangle rectFirst = new System.Drawing.Rectangle(0, 2, colCount - 3, 1);
            TablePoint.Merge(rectFirst);
            // second rect - не работает
            System.Drawing.Rectangle rectSecond = new System.Drawing.Rectangle(1, 2, colCount - 2, 0);
            TablePoint.Merge(rectSecond);

            // ширина столбцов
            TablePoint.Columns[0].Width = 25;
            TablePoint.Columns[1].Width = 30;
            TablePoint.Columns[2].Width = 30;
            // ширина строк
            for (int k = 0; k < allRowCount; k++)
            {
                TablePoint.Rows[k].Height = 5; 
            }
            
            // настройки таблицы по умолчанию
            TablePoint.DefaultCell.TextHeight = 2.5;
            TablePoint.DefaultCell.TextColor = System.Drawing.Color.Black;
            TablePoint.DefaultCell.VerticalTextAlign = VertTextAlign.Center;
            TablePoint.DefaultCell.HorizontalTextAlign = HorizTextAlign.Center;

            // Статичные поля таблицы 
            TablePoint[0, 0].HorizontalTextAlign = HorizTextAlign.Left;
            TablePoint[0, 0].VerticalTextAlign = VertTextAlign.Center;
            TablePoint[0, 0].Value = "Условный номер земельного участка";

            TablePoint[1, 0].HorizontalTextAlign = HorizTextAlign.Left;
            TablePoint[1, 0].VerticalTextAlign = VertTextAlign.Center;
            TablePoint[1, 0].Value = "Площадь земельного участка        м2";

            TablePoint[2, 0].HorizontalTextAlign = HorizTextAlign.Left;
            TablePoint[2, 0].VerticalTextAlign = VertTextAlign.Top;
            TablePoint[2, 0].Value = "Обозначение характерных точек границ";

            TablePoint[2, 1].HorizontalTextAlign = HorizTextAlign.Center;
            TablePoint[2, 1].VerticalTextAlign = VertTextAlign.Center;
            TablePoint[2, 1].Value = "Координаты,м";

            TablePoint[3, 1].HorizontalTextAlign = HorizTextAlign.Center;
            TablePoint[3, 1].VerticalTextAlign = VertTextAlign.Center;
            TablePoint[3, 1].Value = "X";

            TablePoint[3, 2].HorizontalTextAlign = HorizTextAlign.Center;
            TablePoint[3, 2].VerticalTextAlign = VertTextAlign.Center;
            TablePoint[3, 2].Value = "Y";

            // учитываем  систему координат
            McDocument doc = McDocument.WorkingDocument;
            Matrix3d matCurrent = doc.UCS;
            Matrix3d matUsc = matCurrent.Inverse(); 

            //номера точек в ячейки и  координата X,Y,Z
            for (int i = 0; i < Vert.Count; i++)
            {
                Point3d onePointAtList = new Point3d();
                onePointAtList = Vert[i];
                onePointAtList = onePointAtList.TransformBy(matUsc);// преобразуем в текущую систему координат
                int j = i + 4;
                // точность представления чисел в ячейках - получается из формы от пользователя 
                switch (accuracyPoint)
                {
                    case "0":
                        TablePoint[j, 1].Precision = CellPrecisionEnum.Integer;
                        TablePoint[j, 2].Precision = CellPrecisionEnum.Integer;
                        break;

                    case "0.0":
                        TablePoint[j, 1].Precision = CellPrecisionEnum.Precision1;
                        TablePoint[j, 2].Precision = CellPrecisionEnum.Precision1;
                        break;

                    case "0.00":
                        TablePoint[j, 1].Precision = CellPrecisionEnum.Precision2;
                        TablePoint[j, 2].Precision = CellPrecisionEnum.Precision2;
                        break;

                    case "0.000":
                        TablePoint[j, 1].Precision = CellPrecisionEnum.Precision3;
                        TablePoint[j, 2].Precision = CellPrecisionEnum.Precision3;
                        break;
                }

                //номера точек в ячейки и  координата X,Y
                TablePoint[j, 0].Type = CellFormatEnum.Number;
                int pointNumber = j - 3;
                TablePoint[j, 0].Value = pointNumber.ToString();

                TablePoint[j, 1].Type = CellFormatEnum.Number;
                TablePoint[j, 1].Value = onePointAtList.X.ToString();

                TablePoint[j, 2].Type = CellFormatEnum.Number;
                TablePoint[j, 2].Value = onePointAtList.Y.ToString();

            }
            return TablePoint;
        }

        public void vertexInTableOutDwg(string accuracyPoint, bool isKadastrForm)
        {
            // таблица по кадастровой форме или простая 
            if (isKadastrForm == true)
            {
                // создаем таблицу на чертеже
                McTable TablePoint = vertexInTableKadastrForm(plineGetFromUser, accuracyPoint);
                TablePoint.PlaceObject(McEntity.PlaceFlags.Silent);
            }
            else
            {
                // создаем таблицу на чертеже
                McTable TablePoint = vertexInTable(plineGetFromUser, accuracyPoint);
                TablePoint.PlaceObject(McEntity.PlaceFlags.Silent);
            }


        }

        public void vertexInTableOutCsv(string accuracyPoint)
        {
            //выгружаем в csv
            McTable TablePoint = vertexInTable(plineGetFromUser, accuracyPoint);
            TablePoint.SaveToFile();
        }

        public void deletDuplicatedVertexPolyline()
        {
            
            //на LINQ            
            int i = this.listVertecs(plineGetFromUser).Select(CompareFactor => new { CompareFactor.X, CompareFactor.Y, CompareFactor.Z }).Count();
            int j = this.listVertecs(plineGetFromUser).Select(CompareFactor => new { CompareFactor.X, CompareFactor.Y, CompareFactor.Z }).Distinct().Count();

            if (i == j)
            {
              MessageBox.Show("У данной полилинии нет одинаковых/задвоенных вершин");
              return;
            }

            var list = this.listVertecs(plineGetFromUser).Select(CompareFactor => new { CompareFactor.X, CompareFactor.Y, CompareFactor.Z }).Distinct();

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
         
          List<Point3d> Vert = new List<Point3d>();
          List<Point3d> delVert = new List<Point3d>();
          Vert = this.listVertecs(plineGetFromUser);

          if (this.closeAndDuplicateVertex == false && plineGetFromUser.Polyline.ClosedLogically == true)
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

        public void renumerateVertex(int numStartVertex)
        {
            List<Point3d> getVert = new List<Point3d>();
            getVert = this.listVertecs(plineGetFromUser);

            List<Point3d> setVert = new List<Point3d>();
           for( int i = numStartVertex - 1, j = 0; i < getVert.Count; i ++, j++)
           {
               setVert.Insert(j,getVert[i]);
           }

           for (int i = 0, j = setVert.Count; i < numStartVertex - 1; i++, j++)
           {
               setVert.Insert(j, getVert[i]);
           }

           Polyline3d plAfterRenumVert = new Polyline3d(setVert);
           DbPolyline plForWrite = new DbPolyline();
           if (plineGetFromUser.Polyline.ClosedLogically == true)
           {
               plAfterRenumVert.SetClosed(true);
           }
           plForWrite = plAfterRenumVert;
           plForWrite.DbEntity.MatchProperties(plineGetFromUser.DbEntity, MatchPropEnum.All);//копирование свойств
           plineGetFromUser.DbEntity.Erase();// удаляет исходную PL из чертежа
           plForWrite.DbEntity.AddToCurrentDocument();
        }
    }
}