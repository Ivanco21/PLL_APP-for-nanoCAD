﻿using System;
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

        public void ReversPolyline ()
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

        public void NumberInDwg(int inputUserTextHeight, int startNumber) 
        {
            int vertStartNum = startNumber;
            List<Point3d> Vert = new List<Point3d>();
            Vert = this.listVertecs(plineGetFromUser);

            Vector3d forTextVector = new Vector3d(100, 0, 0);
            double hTx = inputUserTextHeight; // получаем от пользователя
            DbText forDraw = new DbText();
            // текущий текстовый стиль
            //forDraw.Text.TextStyle = McObjectManager.CurrentStyle.CurrentTextStyle;

            for (int i = 0; i < Vert.Count; i++)
            {
                TextGeom textNumberPoint = new TextGeom(Convert.ToString(i + startNumber), Vert[i], forTextVector, "");
                textNumberPoint.TextStyle = McObjectManager.CurrentStyle.CurrentTextStyle;
                textNumberPoint.Height = hTx;
                forDraw = textNumberPoint;
                forDraw.DbEntity.AddToCurrentDocument();
                vertStartNum = vertStartNum + 1;
            }


        }

        public McTable VertexInTable(DbPolyline plineGetFromUser, string accuracyPoint, bool isUseUCS, bool isXYrevers) 
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
            // текущий текстовый стиль
            string txtStyleName = McObjectManager.CurrentStyle.CurrentTextStyle;
            TablePoint.DefaultCell.TextStyle = txtStyleName;

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
                // преобразовать в UCS?
                if (isUseUCS)
                {
                    onePointAtList = onePointAtList.TransformBy(matUsc);// преобразуем в текущую систему координат
                }
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

                // тип данных в ячейке
                TablePoint[j, 0].Type = CellFormatEnum.Number;
                TablePoint[j, 1].Type = CellFormatEnum.Number;
                TablePoint[j, 2].Type = CellFormatEnum.Number;
                TablePoint[j, 3].Type = CellFormatEnum.Number;

                //номера точек в ячейки 
                TablePoint[j, 0].Value = j.ToString();
                // X и Yв ячейки 
                //меняем местами  X и Y если isXYrevers == true
                if (isXYrevers)
                {
                    TablePoint[j, 1].Value = onePointAtList.Y.ToString();
                    TablePoint[j, 2].Value = onePointAtList.X.ToString();
                }
                else
                {
                    TablePoint[j, 1].Value = onePointAtList.X.ToString();
                    TablePoint[j, 2].Value = onePointAtList.Y.ToString();
                }
                //Z в ячейки 
                TablePoint[j, 3].Value = onePointAtList.Z.ToString();
          }

            return TablePoint;
       }

        public McTable VertexInTableKadastrForm(DbPolyline plineGetFromUser, string accuracyPoint, bool isUseUCS, bool isXYrevers)
        {

            List<Point3d> Vert = new List<Point3d>();
            Vert = this.listVertecs(plineGetFromUser);
             
            // создаем таблицу  //rows - строки , colums - столбцы
            McTable TablePoint = new McTable();
            int rowCount = Vert.Count;

            // если замкнутая но вершины не совпадают значит нужно добавить строку т.к. 
            // Приказ Минэкономразвития от 08.12.2015 № 921 "Об утверждении формы и состава сведений межевого плана, требований к его подготовке":
            // Список характерных точек границ должен завершаться обозначением начальной точки.
            bool plIsClose = plineGetFromUser.Polyline.ClosedLogically;
            bool onePointEqualTwoPoint = (Vert[0].X == Vert[Vert.Count - 1].X) & 
                                         (Vert[0].Y == Vert[Vert.Count - 1].Y) & 
                                         (Vert[0].Z == Vert[Vert.Count - 1].Z);

            if(plIsClose & !onePointEqualTwoPoint)
            {
                rowCount = rowCount + 1;
            }

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
            // second rect 
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

            // точность представления чисел в ячейках - получается из формы от пользователя 
            for (int rc = 0; rc < rowCount; rc++)
            {
                int jc = rc + 4;

                switch (accuracyPoint)
                {
                    case "0":
                        TablePoint[jc, 1].Precision = CellPrecisionEnum.Integer;
                        TablePoint[jc, 2].Precision = CellPrecisionEnum.Integer;
                        break;

                    case "0.0":
                        TablePoint[jc, 1].Precision = CellPrecisionEnum.Precision1;
                        TablePoint[jc, 2].Precision = CellPrecisionEnum.Precision1;
                        break;

                    case "0.00":
                        TablePoint[jc, 1].Precision = CellPrecisionEnum.Precision2;
                        TablePoint[jc, 2].Precision = CellPrecisionEnum.Precision2;
                        break;

                    case "0.000":
                        TablePoint[jc, 1].Precision = CellPrecisionEnum.Precision3;
                        TablePoint[jc, 2].Precision = CellPrecisionEnum.Precision3;
                        break;
                }
            }
            
            // настройки таблицы по умолчанию
            TablePoint.DefaultCell.TextHeight = 2.5;
            TablePoint.DefaultCell.TextColor = System.Drawing.Color.Black;
            TablePoint.DefaultCell.VerticalTextAlign = VertTextAlign.Center;
            TablePoint.DefaultCell.HorizontalTextAlign = HorizTextAlign.Center;

            // текущий текстовый стиль
            string txtStyleName = McObjectManager.CurrentStyle.CurrentTextStyle;
            TablePoint.DefaultCell.TextStyle = txtStyleName;

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
                // преобразовать в UCS?
                if (isUseUCS)
                {
                    onePointAtList = onePointAtList.TransformBy(matUsc);// преобразуем в текущую систему координат
                }
                int j = i + 4;
                // тип данных в ячейке
 
                TablePoint[j, 0].Type = CellFormatEnum.Number;
                TablePoint[j, 1].Type = CellFormatEnum.Number;
                TablePoint[j, 2].Type = CellFormatEnum.Number;
                //номера точек в ячейки 
                int pointNumber = j - 3;
                TablePoint[j, 0].Value = pointNumber.ToString();

                //координата X,Y в ячейки 
                //меняем местами  X и Y если isXYrevers == true
                if (isXYrevers)
                {
                    TablePoint[j, 1].Value = onePointAtList.Y.ToString();
                    TablePoint[j, 2].Value = onePointAtList.X.ToString();
                }
                else
                {
                    TablePoint[j, 1].Value = onePointAtList.X.ToString();
                    TablePoint[j, 2].Value = onePointAtList.Y.ToString();
                }


            }

            // Список характерных точек границ должен завершаться обозначением начальной точки.
            if (plIsClose & !onePointEqualTwoPoint)
            {
                TablePoint[allRowCount - 1, 0].Type = CellFormatEnum.Number;
                TablePoint[allRowCount - 1, 1].Type = CellFormatEnum.Number;
                TablePoint[allRowCount - 1, 2].Type = CellFormatEnum.Number;
                // всегда "1" согласно правилам заполнения кадастровой формы
                TablePoint[allRowCount - 1, 0].Value = "1";

                //координата X,Y в ячейки 
                //меняем местами  X и Y если isXYrevers == true
                if (isXYrevers)
                {
                    TablePoint[allRowCount - 1, 1].Value = Vert[0].Y.ToString();
                    TablePoint[allRowCount - 1, 2].Value = Vert[0].X.ToString();
                }
                else
                {
                    TablePoint[allRowCount - 1, 1].Value = Vert[0].X.ToString();
                    TablePoint[allRowCount - 1, 2].Value = Vert[0].Y.ToString();
                }

            }

            return TablePoint;
        }

        public void VertexInTableOutDwg(string accuracyPoint, bool isKadastrForm ,bool isUseUCS, bool isXYrevers )
        {
            // таблица по кадастровой форме или простая 
            if (isKadastrForm == true)
            {
                // создаем таблицу на чертеже
                McTable TablePoint = VertexInTableKadastrForm(plineGetFromUser, accuracyPoint, isUseUCS, isXYrevers);
                TablePoint.PlaceObject(McEntity.PlaceFlags.Silent);
            }
            else
            {
                // создаем таблицу на чертеже
                McTable TablePoint = VertexInTable(plineGetFromUser, accuracyPoint, isUseUCS, isXYrevers);
                TablePoint.PlaceObject(McEntity.PlaceFlags.Silent);
            }


        }

        public void VertexInTableOutCsv(string accuracyPoint,bool isUseUCS, bool isXYrevers)
        {
            //выгружаем в csv
            McTable TablePoint = VertexInTable(plineGetFromUser, accuracyPoint, isUseUCS, isXYrevers);
            TablePoint.SaveToFile();
        }

        public void DeletDuplicatedVertexPolyline()
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

        public void FitPolyline(double tolerance, bool delSoursePL)
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

        public void RenumerateVertex(int numStartVertex)
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