namespace PLL_APP
{
    partial class GlobalForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btGetPL = new System.Windows.Forms.Button();
            this.pnlOnePnl = new System.Windows.Forms.Panel();
            this.gbGeomtoVertexPl = new System.Windows.Forms.GroupBox();
            this.btnPlaceGeom = new System.Windows.Forms.Button();
            this.lbGeomToPlVert = new System.Windows.Forms.Label();
            this.btnGetObj = new System.Windows.Forms.Button();
            this.gbRenumerateVertexPl = new System.Windows.Forms.GroupBox();
            this.lbInfoAboutPl = new System.Windows.Forms.Label();
            this.btnRenumVertexInPl = new System.Windows.Forms.Button();
            this.dmUpDwnVertexInPl = new System.Windows.Forms.DomainUpDown();
            this.gbRedusePl = new System.Windows.Forms.GroupBox();
            this.lbTolerance = new System.Windows.Forms.Label();
            this.tbTolerance = new System.Windows.Forms.TextBox();
            this.btRedusePl = new System.Windows.Forms.Button();
            this.cbDelSoursePl = new System.Windows.Forms.CheckBox();
            this.DelDuplicateVertexPl = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.vertInTable = new System.Windows.Forms.GroupBox();
            this.vertexInTable = new System.Windows.Forms.Button();
            this.cbAccuracyPoint = new System.Windows.Forms.ComboBox();
            this.btExportInCsv = new System.Windows.Forms.Button();
            this.lbAccuracyPoint = new System.Windows.Forms.Label();
            this.numVertex = new System.Windows.Forms.GroupBox();
            this.btNumberVertInDwg = new System.Windows.Forms.Button();
            this.lbTextHeight = new System.Windows.Forms.Label();
            this.tbTextHeight = new System.Windows.Forms.TextBox();
            this.revers = new System.Windows.Forms.Button();
            this.lbLinkMoney = new System.Windows.Forms.LinkLabel();
            this.lbPleaseGiveMoney = new System.Windows.Forms.Label();
            this.cbStartNumerateAbout = new System.Windows.Forms.CheckBox();
            this.tbStartNumerateNumber = new System.Windows.Forms.TextBox();
            this.pnlOnePnl.SuspendLayout();
            this.gbGeomtoVertexPl.SuspendLayout();
            this.gbRenumerateVertexPl.SuspendLayout();
            this.gbRedusePl.SuspendLayout();
            this.vertInTable.SuspendLayout();
            this.numVertex.SuspendLayout();
            this.SuspendLayout();
            // 
            // btGetPL
            // 
            this.btGetPL.Location = new System.Drawing.Point(67, 12);
            this.btGetPL.Name = "btGetPL";
            this.btGetPL.Size = new System.Drawing.Size(268, 23);
            this.btGetPL.TabIndex = 0;
            this.btGetPL.Text = "Выберите полилинию";
            this.btGetPL.UseVisualStyleBackColor = true;
            this.btGetPL.Click += new System.EventHandler(this.GetPL_Click);
            // 
            // pnlOnePnl
            // 
            this.pnlOnePnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlOnePnl.Controls.Add(this.gbGeomtoVertexPl);
            this.pnlOnePnl.Controls.Add(this.gbRenumerateVertexPl);
            this.pnlOnePnl.Controls.Add(this.gbRedusePl);
            this.pnlOnePnl.Controls.Add(this.DelDuplicateVertexPl);
            this.pnlOnePnl.Controls.Add(this.label1);
            this.pnlOnePnl.Controls.Add(this.vertInTable);
            this.pnlOnePnl.Controls.Add(this.numVertex);
            this.pnlOnePnl.Controls.Add(this.revers);
            this.pnlOnePnl.Enabled = false;
            this.pnlOnePnl.Location = new System.Drawing.Point(12, 41);
            this.pnlOnePnl.Name = "pnlOnePnl";
            this.pnlOnePnl.Size = new System.Drawing.Size(368, 522);
            this.pnlOnePnl.TabIndex = 1;
            // 
            // gbGeomtoVertexPl
            // 
            this.gbGeomtoVertexPl.Controls.Add(this.btnPlaceGeom);
            this.gbGeomtoVertexPl.Controls.Add(this.lbGeomToPlVert);
            this.gbGeomtoVertexPl.Controls.Add(this.btnGetObj);
            this.gbGeomtoVertexPl.Location = new System.Drawing.Point(3, 291);
            this.gbGeomtoVertexPl.Name = "gbGeomtoVertexPl";
            this.gbGeomtoVertexPl.Size = new System.Drawing.Size(357, 78);
            this.gbGeomtoVertexPl.TabIndex = 14;
            this.gbGeomtoVertexPl.TabStop = false;
            // 
            // btnPlaceGeom
            // 
            this.btnPlaceGeom.Enabled = false;
            this.btnPlaceGeom.Location = new System.Drawing.Point(187, 45);
            this.btnPlaceGeom.Name = "btnPlaceGeom";
            this.btnPlaceGeom.Size = new System.Drawing.Size(147, 27);
            this.btnPlaceGeom.TabIndex = 2;
            this.btnPlaceGeom.Text = "Расставить";
            this.btnPlaceGeom.UseVisualStyleBackColor = true;
            this.btnPlaceGeom.Click += new System.EventHandler(this.btnPlaceGeom_Click);
            // 
            // lbGeomToPlVert
            // 
            this.lbGeomToPlVert.AutoSize = true;
            this.lbGeomToPlVert.Location = new System.Drawing.Point(45, 16);
            this.lbGeomToPlVert.Name = "lbGeomToPlVert";
            this.lbGeomToPlVert.Size = new System.Drawing.Size(257, 13);
            this.lbGeomToPlVert.TabIndex = 1;
            this.lbGeomToPlVert.Text = "Расстановка геометрии по вершинам полилинии";
            // 
            // btnGetObj
            // 
            this.btnGetObj.Location = new System.Drawing.Point(9, 45);
            this.btnGetObj.Name = "btnGetObj";
            this.btnGetObj.Size = new System.Drawing.Size(147, 27);
            this.btnGetObj.TabIndex = 0;
            this.btnGetObj.Text = "Выберите объект";
            this.btnGetObj.UseVisualStyleBackColor = true;
            this.btnGetObj.Click += new System.EventHandler(this.btnGetObj_Click);
            // 
            // gbRenumerateVertexPl
            // 
            this.gbRenumerateVertexPl.Controls.Add(this.lbInfoAboutPl);
            this.gbRenumerateVertexPl.Controls.Add(this.btnRenumVertexInPl);
            this.gbRenumerateVertexPl.Controls.Add(this.dmUpDwnVertexInPl);
            this.gbRenumerateVertexPl.Location = new System.Drawing.Point(9, 189);
            this.gbRenumerateVertexPl.Name = "gbRenumerateVertexPl";
            this.gbRenumerateVertexPl.Size = new System.Drawing.Size(348, 96);
            this.gbRenumerateVertexPl.TabIndex = 13;
            this.gbRenumerateVertexPl.TabStop = false;
            // 
            // lbInfoAboutPl
            // 
            this.lbInfoAboutPl.AutoSize = true;
            this.lbInfoAboutPl.Location = new System.Drawing.Point(0, 16);
            this.lbInfoAboutPl.Name = "lbInfoAboutPl";
            this.lbInfoAboutPl.Size = new System.Drawing.Size(304, 26);
            this.lbInfoAboutPl.TabIndex = 2;
            this.lbInfoAboutPl.Text = "Только для замкнутых полилиний\r\n(генерация новой линий с измененным порядком верш" +
    "ин)";
            // 
            // btnRenumVertexInPl
            // 
            this.btnRenumVertexInPl.Location = new System.Drawing.Point(6, 55);
            this.btnRenumVertexInPl.Name = "btnRenumVertexInPl";
            this.btnRenumVertexInPl.Size = new System.Drawing.Size(202, 35);
            this.btnRenumVertexInPl.TabIndex = 1;
            this.btnRenumVertexInPl.Text = "Перенумерация вершин из 1 в ->";
            this.btnRenumVertexInPl.UseVisualStyleBackColor = true;
            this.btnRenumVertexInPl.Click += new System.EventHandler(this.btnRenumVertexInPl_Click);
            // 
            // dmUpDwnVertexInPl
            // 
            this.dmUpDwnVertexInPl.Location = new System.Drawing.Point(216, 64);
            this.dmUpDwnVertexInPl.Name = "dmUpDwnVertexInPl";
            this.dmUpDwnVertexInPl.ReadOnly = true;
            this.dmUpDwnVertexInPl.Size = new System.Drawing.Size(117, 20);
            this.dmUpDwnVertexInPl.TabIndex = 0;
            // 
            // gbRedusePl
            // 
            this.gbRedusePl.Controls.Add(this.lbTolerance);
            this.gbRedusePl.Controls.Add(this.tbTolerance);
            this.gbRedusePl.Controls.Add(this.btRedusePl);
            this.gbRedusePl.Controls.Add(this.cbDelSoursePl);
            this.gbRedusePl.Location = new System.Drawing.Point(3, 375);
            this.gbRedusePl.Name = "gbRedusePl";
            this.gbRedusePl.Size = new System.Drawing.Size(348, 77);
            this.gbRedusePl.TabIndex = 12;
            this.gbRedusePl.TabStop = false;
            // 
            // lbTolerance
            // 
            this.lbTolerance.AutoSize = true;
            this.lbTolerance.Location = new System.Drawing.Point(167, 16);
            this.lbTolerance.Name = "lbTolerance";
            this.lbTolerance.Size = new System.Drawing.Size(174, 13);
            this.lbTolerance.TabIndex = 3;
            this.lbTolerance.Text = "Максимальная длинна сегмента";
            // 
            // tbTolerance
            // 
            this.tbTolerance.Location = new System.Drawing.Point(228, 45);
            this.tbTolerance.Name = "tbTolerance";
            this.tbTolerance.Size = new System.Drawing.Size(99, 20);
            this.tbTolerance.TabIndex = 2;
            this.tbTolerance.Text = "50";
            this.tbTolerance.TextChanged += new System.EventHandler(this.tbTolerance_TextChanged);
            // 
            // btRedusePl
            // 
            this.btRedusePl.Location = new System.Drawing.Point(6, 16);
            this.btRedusePl.Name = "btRedusePl";
            this.btRedusePl.Size = new System.Drawing.Size(127, 23);
            this.btRedusePl.TabIndex = 0;
            this.btRedusePl.Text = "Упростить";
            this.btRedusePl.UseVisualStyleBackColor = true;
            this.btRedusePl.Click += new System.EventHandler(this.btFitPl_Click);
            // 
            // cbDelSoursePl
            // 
            this.cbDelSoursePl.AutoSize = true;
            this.cbDelSoursePl.Location = new System.Drawing.Point(6, 48);
            this.cbDelSoursePl.Name = "cbDelSoursePl";
            this.cbDelSoursePl.Size = new System.Drawing.Size(179, 17);
            this.cbDelSoursePl.TabIndex = 1;
            this.cbDelSoursePl.Text = "Удалять исходную полилинию";
            this.cbDelSoursePl.UseVisualStyleBackColor = true;
            this.cbDelSoursePl.CheckedChanged += new System.EventHandler(this.cbDelSoursePl_CheckedChanged);
            // 
            // DelDuplicateVertexPl
            // 
            this.DelDuplicateVertexPl.Location = new System.Drawing.Point(166, 482);
            this.DelDuplicateVertexPl.Name = "DelDuplicateVertexPl";
            this.DelDuplicateVertexPl.Size = new System.Drawing.Size(185, 25);
            this.DelDuplicateVertexPl.TabIndex = 11;
            this.DelDuplicateVertexPl.Text = "Удаление одинаковых вершин";
            this.DelDuplicateVertexPl.UseVisualStyleBackColor = true;
            this.DelDuplicateVertexPl.Click += new System.EventHandler(this.segmentToLines_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 455);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(364, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "После реверса, упростить и удаления одинаковых вершин перевыбор";
            // 
            // vertInTable
            // 
            this.vertInTable.Controls.Add(this.vertexInTable);
            this.vertInTable.Controls.Add(this.cbAccuracyPoint);
            this.vertInTable.Controls.Add(this.btExportInCsv);
            this.vertInTable.Controls.Add(this.lbAccuracyPoint);
            this.vertInTable.Location = new System.Drawing.Point(9, 3);
            this.vertInTable.Name = "vertInTable";
            this.vertInTable.Size = new System.Drawing.Size(348, 87);
            this.vertInTable.TabIndex = 9;
            this.vertInTable.TabStop = false;
            // 
            // vertexInTable
            // 
            this.vertexInTable.Location = new System.Drawing.Point(6, 13);
            this.vertexInTable.Name = "vertexInTable";
            this.vertexInTable.Size = new System.Drawing.Size(147, 35);
            this.vertexInTable.TabIndex = 1;
            this.vertexInTable.Text = "Вершины в таблицу чертежа";
            this.vertexInTable.UseVisualStyleBackColor = true;
            this.vertexInTable.Click += new System.EventHandler(this.vertexInTable_Click);
            // 
            // cbAccuracyPoint
            // 
            this.cbAccuracyPoint.DisplayMember = "(none)";
            this.cbAccuracyPoint.FormattingEnabled = true;
            this.cbAccuracyPoint.Items.AddRange(new object[] {
            "0",
            "0.0",
            "0.00",
            "0.000"});
            this.cbAccuracyPoint.Location = new System.Drawing.Point(214, 27);
            this.cbAccuracyPoint.Name = "cbAccuracyPoint";
            this.cbAccuracyPoint.Size = new System.Drawing.Size(99, 21);
            this.cbAccuracyPoint.TabIndex = 2;
            this.cbAccuracyPoint.Text = "0.0";
            // 
            // btExportInCsv
            // 
            this.btExportInCsv.Location = new System.Drawing.Point(6, 54);
            this.btExportInCsv.Name = "btExportInCsv";
            this.btExportInCsv.Size = new System.Drawing.Size(147, 25);
            this.btExportInCsv.TabIndex = 4;
            this.btExportInCsv.Text = "Экспорт в файл";
            this.btExportInCsv.UseVisualStyleBackColor = true;
            this.btExportInCsv.Click += new System.EventHandler(this.ExportInCsv_Click);
            // 
            // lbAccuracyPoint
            // 
            this.lbAccuracyPoint.AutoSize = true;
            this.lbAccuracyPoint.Location = new System.Drawing.Point(211, 11);
            this.lbAccuracyPoint.Name = "lbAccuracyPoint";
            this.lbAccuracyPoint.Size = new System.Drawing.Size(110, 13);
            this.lbAccuracyPoint.TabIndex = 3;
            this.lbAccuracyPoint.Text = "Точность координат";
            // 
            // numVertex
            // 
            this.numVertex.Controls.Add(this.tbStartNumerateNumber);
            this.numVertex.Controls.Add(this.cbStartNumerateAbout);
            this.numVertex.Controls.Add(this.btNumberVertInDwg);
            this.numVertex.Controls.Add(this.lbTextHeight);
            this.numVertex.Controls.Add(this.tbTextHeight);
            this.numVertex.Location = new System.Drawing.Point(9, 96);
            this.numVertex.Name = "numVertex";
            this.numVertex.Size = new System.Drawing.Size(348, 93);
            this.numVertex.TabIndex = 8;
            this.numVertex.TabStop = false;
            // 
            // btNumberVertInDwg
            // 
            this.btNumberVertInDwg.Location = new System.Drawing.Point(6, 19);
            this.btNumberVertInDwg.Name = "btNumberVertInDwg";
            this.btNumberVertInDwg.Size = new System.Drawing.Size(202, 34);
            this.btNumberVertInDwg.TabIndex = 5;
            this.btNumberVertInDwg.Text = "Нумеровать вершины в чертеже";
            this.btNumberVertInDwg.UseVisualStyleBackColor = true;
            this.btNumberVertInDwg.Click += new System.EventHandler(this.numberInDwg_Click);
            // 
            // lbTextHeight
            // 
            this.lbTextHeight.AutoSize = true;
            this.lbTextHeight.Location = new System.Drawing.Point(253, 16);
            this.lbTextHeight.Name = "lbTextHeight";
            this.lbTextHeight.Size = new System.Drawing.Size(82, 13);
            this.lbTextHeight.TabIndex = 7;
            this.lbTextHeight.Text = "Высота текста";
            // 
            // tbTextHeight
            // 
            this.tbTextHeight.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.tbTextHeight.Location = new System.Drawing.Point(248, 33);
            this.tbTextHeight.Name = "tbTextHeight";
            this.tbTextHeight.Size = new System.Drawing.Size(94, 20);
            this.tbTextHeight.TabIndex = 6;
            this.tbTextHeight.Text = "250";
            this.tbTextHeight.TextChanged += new System.EventHandler(this.textHeight_TextChanged);
            // 
            // revers
            // 
            this.revers.Location = new System.Drawing.Point(3, 482);
            this.revers.Name = "revers";
            this.revers.Size = new System.Drawing.Size(75, 25);
            this.revers.TabIndex = 0;
            this.revers.Text = "Реверс";
            this.revers.UseVisualStyleBackColor = true;
            this.revers.Click += new System.EventHandler(this.revers_Click);
            // 
            // lbLinkMoney
            // 
            this.lbLinkMoney.AutoSize = true;
            this.lbLinkMoney.Location = new System.Drawing.Point(281, 579);
            this.lbLinkMoney.Name = "lbLinkMoney";
            this.lbLinkMoney.Size = new System.Drawing.Size(83, 13);
            this.lbLinkMoney.TabIndex = 2;
            this.lbLinkMoney.TabStop = true;
            this.lbLinkMoney.Text = "ЯндексДеньги";
            this.lbLinkMoney.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkMoney_LinkClicked);
            // 
            // lbPleaseGiveMoney
            // 
            this.lbPleaseGiveMoney.AutoSize = true;
            this.lbPleaseGiveMoney.Location = new System.Drawing.Point(22, 573);
            this.lbPleaseGiveMoney.Name = "lbPleaseGiveMoney";
            this.lbPleaseGiveMoney.Size = new System.Drawing.Size(225, 26);
            this.lbPleaseGiveMoney.TabIndex = 3;
            this.lbPleaseGiveMoney.Text = "Прогресc в разработке двигают печеньки,\r\nсказать спасибо/на печеньки        -----" +
    "---->>";
            // 
            // cbStartNumerateAbout
            // 
            this.cbStartNumerateAbout.AutoSize = true;
            this.cbStartNumerateAbout.Location = new System.Drawing.Point(6, 70);
            this.cbStartNumerateAbout.Name = "cbStartNumerateAbout";
            this.cbStartNumerateAbout.Size = new System.Drawing.Size(236, 17);
            this.cbStartNumerateAbout.TabIndex = 9;
            this.cbStartNumerateAbout.Text = "Нумерация не с первой позиции,а с поз.:";
            this.cbStartNumerateAbout.UseVisualStyleBackColor = true;
            this.cbStartNumerateAbout.CheckedChanged += new System.EventHandler(this.cbStartNumerateAbout_CheckedChanged);
            // 
            // tbStartNumerateNumber
            // 
            this.tbStartNumerateNumber.Location = new System.Drawing.Point(248, 68);
            this.tbStartNumerateNumber.Name = "tbStartNumerateNumber";
            this.tbStartNumerateNumber.ReadOnly = true;
            this.tbStartNumerateNumber.Size = new System.Drawing.Size(94, 20);
            this.tbStartNumerateNumber.TabIndex = 10;
            this.tbStartNumerateNumber.TextChanged += new System.EventHandler(this.tbStartNumerateNumber_TextChanged);
            // 
            // GlobalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 608);
            this.Controls.Add(this.lbPleaseGiveMoney);
            this.Controls.Add(this.lbLinkMoney);
            this.Controls.Add(this.pnlOnePnl);
            this.Controls.Add(this.btGetPL);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "GlobalForm";
            this.ShowIcon = false;
            this.Text = "PLL APP by Ivanco_v0.3  (soldatov@infoind.info)";
            this.pnlOnePnl.ResumeLayout(false);
            this.pnlOnePnl.PerformLayout();
            this.gbGeomtoVertexPl.ResumeLayout(false);
            this.gbGeomtoVertexPl.PerformLayout();
            this.gbRenumerateVertexPl.ResumeLayout(false);
            this.gbRenumerateVertexPl.PerformLayout();
            this.gbRedusePl.ResumeLayout(false);
            this.gbRedusePl.PerformLayout();
            this.vertInTable.ResumeLayout(false);
            this.vertInTable.PerformLayout();
            this.numVertex.ResumeLayout(false);
            this.numVertex.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btGetPL;
        private System.Windows.Forms.Panel pnlOnePnl;
        private System.Windows.Forms.Button vertexInTable;
        private System.Windows.Forms.Button revers;
        public System.Windows.Forms.ComboBox cbAccuracyPoint;
        private System.Windows.Forms.Button btExportInCsv;
        private System.Windows.Forms.Label lbAccuracyPoint;
        private System.Windows.Forms.Label lbTextHeight;
        private System.Windows.Forms.Button btNumberVertInDwg;
        public System.Windows.Forms.TextBox tbTextHeight;
        private System.Windows.Forms.GroupBox numVertex;
        private System.Windows.Forms.GroupBox vertInTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button DelDuplicateVertexPl;
        private System.Windows.Forms.GroupBox gbRedusePl;
        private System.Windows.Forms.Label lbTolerance;
        private System.Windows.Forms.TextBox tbTolerance;
        private System.Windows.Forms.Button btRedusePl;
        private System.Windows.Forms.CheckBox cbDelSoursePl;
        private System.Windows.Forms.GroupBox gbRenumerateVertexPl;
        private System.Windows.Forms.Button btnRenumVertexInPl;
        private System.Windows.Forms.DomainUpDown dmUpDwnVertexInPl;
        private System.Windows.Forms.Label lbInfoAboutPl;
        private System.Windows.Forms.GroupBox gbGeomtoVertexPl;
        private System.Windows.Forms.Button btnPlaceGeom;
        private System.Windows.Forms.Label lbGeomToPlVert;
        private System.Windows.Forms.Button btnGetObj;
        private System.Windows.Forms.LinkLabel lbLinkMoney;
        private System.Windows.Forms.Label lbPleaseGiveMoney;
        private System.Windows.Forms.TextBox tbStartNumerateNumber;
        private System.Windows.Forms.CheckBox cbStartNumerateAbout;
    }
}