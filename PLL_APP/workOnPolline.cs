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

   partial class HandlerPolyline
    {

       public List<Point3d> listVertecs(DbPolyline plineForWork)
        {
            List<Point3d> Vertices = new List<Point3d>();
            // собираем все вершины в list
            for (int i1 = 0; i1 < plineForWork.Polyline.Vertices.Count; i1++)
              {
                Point3d Vertex = new Point3d(); double Bulge; double startWidth; double endWidth; Vector3d nrm;
                plineForWork.Polyline.Vertices.GetVertexAt((uint)i1, out Vertex, out Bulge, out startWidth, out endWidth, out nrm);
                Vertices.Add(Vertex);
              }
            return Vertices;
        }

        public void reversPolyline (DbPolyline plineForWork)
        {
            List<Point3d> Vert = new List<Point3d>();
            Vert = listVertecs(plineForWork);
            Vert.Reverse();

            Polyline3d reversPL3d = new Polyline3d(Vert);


            // Если вы с помощью выбора берете уже существующую полилинию, то это plineForWork.DbEntity.AddToCurrentDocument(); не нужно, можно есче добавить plineForWork.DbEntity.Update();
             plineForWork.DbEntity.Erase();// удаляет исходную PL из чертежа

            if (plineForWork.Polyline.ClosedLogically == true)
            {
                reversPL3d.SetClosed(true);
            }

            plineForWork = reversPL3d;
            plineForWork.DbEntity.AddToCurrentDocument();

        }

        public void numberInDwg(int inputUserTextHeight)
        {
            List<Point3d> Vert = new List<Point3d>();
            Vert = listVertecs(plineForWork);

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

        public McTable vertexInTable(DbPolyline plineForWork, string accuracyPoint)
        {
            List<Point3d> Vert = new List<Point3d>();
            Vert = listVertecs(plineForWork);

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
            McTable TablePoint = vertexInTable(plineForWork, accuracyPoint);
            TablePoint.PlaceObject(McEntity.PlaceFlags.Silent);

        }

        public void vertexInTableOutCsv(string accuracyPoint)
        {
            //выгружаем в csv
            McTable TablePoint = vertexInTable(plineForWork, accuracyPoint);
            TablePoint.SaveToFile();
        }

 
       public void deletDuplicatedVertexPolyline(DbPolyline plineForWork)
        {
            //на LINQ.https://www.youtube.com/watch?v=WSm6uEtgqzk&index=20&list=PL-ss7IpVOiB6Z3Pn8Paapr5qwT2lqS14D

            var list = listVertecs(plineForWork).Select(CompareFactor => new {CompareFactor.X, CompareFactor.Y,CompareFactor.Z}).Distinct();

            List<Point3d> Vertex = new List<Point3d>();
          
           foreach( var item in list)
            {
               Point3d PointForList = new Point3d(item.X,item.Y,item.Z);
               Vertex.Add(PointForList);
            }

           Polyline3d PL3dNonDuplicatePoints = new Polyline3d(Vertex);
           DbPolyline PL = PL3dNonDuplicatePoints;
           plineForWork.DbEntity.Erase();
           PL.DbEntity.AddToCurrentDocument();       
        }

    }
