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
            this.lbAccuracyPoint = new System.Windows.Forms.Label();
            this.numVertex = new System.Windows.Forms.GroupBox();
            this.btNumberVertInDwg = new System.Windows.Forms.Button();
            this.lbTextHeight = new System.Windows.Forms.Label();
            this.tbTextHeight = new System.Windows.Forms.TextBox();
            this.btExportInCsv = new System.Windows.Forms.Button();
            this.revers = new System.Windows.Forms.Button();
            this.pnlOnePnl.SuspendLayout();
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
            this.pnlOnePnl.Controls.Add(this.gbRedusePl);
            this.pnlOnePnl.Controls.Add(this.DelDuplicateVertexPl);
            this.pnlOnePnl.Controls.Add(this.label1);
            this.pnlOnePnl.Controls.Add(this.vertInTable);
            this.pnlOnePnl.Controls.Add(this.numVertex);
            this.pnlOnePnl.Controls.Add(this.revers);
            this.pnlOnePnl.Enabled = false;
            this.pnlOnePnl.Location = new System.Drawing.Point(12, 41);
            this.pnlOnePnl.Name = "pnlOnePnl";
            this.pnlOnePnl.Size = new System.Drawing.Size(368, 304);
            this.pnlOnePnl.TabIndex = 1;
            // 
            // gbRedusePl
            // 
            this.gbRedusePl.Controls.Add(this.lbTolerance);
            this.gbRedusePl.Controls.Add(this.tbTolerance);
            this.gbRedusePl.Controls.Add(this.btRedusePl);
            this.gbRedusePl.Controls.Add(this.cbDelSoursePl);
            this.gbRedusePl.Location = new System.Drawing.Point(9, 216);
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
            this.btRedusePl.Click += new System.EventHandler(this.btRedusePl_Click);
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
            this.DelDuplicateVertexPl.Location = new System.Drawing.Point(165, 185);
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
            this.label1.Location = new System.Drawing.Point(6, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(307, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "После реверса и удаления одинаковых вершин перевыбор";
            // 
            // vertInTable
            // 
            this.vertInTable.Controls.Add(this.vertexInTable);
            this.vertInTable.Controls.Add(this.cbAccuracyPoint);
            this.vertInTable.Controls.Add(this.lbAccuracyPoint);
            this.vertInTable.Location = new System.Drawing.Point(9, 3);
            this.vertInTable.Name = "vertInTable";
            this.vertInTable.Size = new System.Drawing.Size(348, 54);
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
            this.numVertex.Controls.Add(this.btNumberVertInDwg);
            this.numVertex.Controls.Add(this.lbTextHeight);
            this.numVertex.Controls.Add(this.tbTextHeight);
            this.numVertex.Controls.Add(this.btExportInCsv);
            this.numVertex.Location = new System.Drawing.Point(9, 63);
            this.numVertex.Name = "numVertex";
            this.numVertex.Size = new System.Drawing.Size(348, 93);
            this.numVertex.TabIndex = 8;
            this.numVertex.TabStop = false;
            // 
            // btNumberVertInDwg
            // 
            this.btNumberVertInDwg.Location = new System.Drawing.Point(6, 19);
            this.btNumberVertInDwg.Name = "btNumberVertInDwg";
            this.btNumberVertInDwg.Size = new System.Drawing.Size(147, 34);
            this.btNumberVertInDwg.TabIndex = 5;
            this.btNumberVertInDwg.Text = "Нумеровать вершины в чертеже";
            this.btNumberVertInDwg.UseVisualStyleBackColor = true;
            this.btNumberVertInDwg.Click += new System.EventHandler(this.numberInDwg_Click);
            // 
            // lbTextHeight
            // 
            this.lbTextHeight.AutoSize = true;
            this.lbTextHeight.Location = new System.Drawing.Point(201, 16);
            this.lbTextHeight.Name = "lbTextHeight";
            this.lbTextHeight.Size = new System.Drawing.Size(82, 13);
            this.lbTextHeight.TabIndex = 7;
            this.lbTextHeight.Text = "Высота текста";
            // 
            // tbTextHeight
            // 
            this.tbTextHeight.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.tbTextHeight.Location = new System.Drawing.Point(202, 33);
            this.tbTextHeight.Name = "tbTextHeight";
            this.tbTextHeight.Size = new System.Drawing.Size(100, 20);
            this.tbTextHeight.TabIndex = 6;
            this.tbTextHeight.Text = "250";
            this.tbTextHeight.TextChanged += new System.EventHandler(this.textHeight_TextChanged);
            // 
            // btExportInCsv
            // 
            this.btExportInCsv.Location = new System.Drawing.Point(6, 62);
            this.btExportInCsv.Name = "btExportInCsv";
            this.btExportInCsv.Size = new System.Drawing.Size(147, 25);
            this.btExportInCsv.TabIndex = 4;
            this.btExportInCsv.Text = "Экспорт в файл";
            this.btExportInCsv.UseVisualStyleBackColor = true;
            this.btExportInCsv.Click += new System.EventHandler(this.ExportInCsv_Click);
            // 
            // revers
            // 
            this.revers.Location = new System.Drawing.Point(15, 185);
            this.revers.Name = "revers";
            this.revers.Size = new System.Drawing.Size(75, 25);
            this.revers.TabIndex = 0;
            this.revers.Text = "Реверс";
            this.revers.UseVisualStyleBackColor = true;
            this.revers.Click += new System.EventHandler(this.revers_Click);
            // 
            // GlobalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 357);
            this.Controls.Add(this.pnlOnePnl);
            this.Controls.Add(this.btGetPL);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "GlobalForm";
            this.ShowIcon = false;
            this.Text = "PLL APP by Ivanco_v0.2";
            this.pnlOnePnl.ResumeLayout(false);
            this.pnlOnePnl.PerformLayout();
            this.gbRedusePl.ResumeLayout(false);
            this.gbRedusePl.PerformLayout();
            this.vertInTable.ResumeLayout(false);
            this.vertInTable.PerformLayout();
            this.numVertex.ResumeLayout(false);
            this.numVertex.PerformLayout();
            this.ResumeLayout(false);

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
    }
}