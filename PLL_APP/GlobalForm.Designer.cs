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
            this.revers = new System.Windows.Forms.Button();
            this.btExportInCsv = new System.Windows.Forms.Button();
            this.pnlOnePnl.SuspendLayout();
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
            this.pnlOnePnl.Controls.Add(this.DelDuplicateVertexPl);
            this.pnlOnePnl.Controls.Add(this.label1);
            this.pnlOnePnl.Controls.Add(this.vertInTable);
            this.pnlOnePnl.Controls.Add(this.numVertex);
            this.pnlOnePnl.Controls.Add(this.revers);
            this.pnlOnePnl.Enabled = false;
            this.pnlOnePnl.Location = new System.Drawing.Point(12, 41);
            this.pnlOnePnl.Name = "pnlOnePnl";
            this.pnlOnePnl.Size = new System.Drawing.Size(398, 227);
            this.pnlOnePnl.TabIndex = 1;
            // 
            // DelDuplicateVertexPl
            // 
            this.DelDuplicateVertexPl.Location = new System.Drawing.Point(126, 185);
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
            this.label1.Size = new System.Drawing.Size(305, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "после реверса и удаления одинаковых вершин перевыбор";
            // 
            // vertInTable
            // 
            this.vertInTable.Controls.Add(this.vertexInTable);
            this.vertInTable.Controls.Add(this.cbAccuracyPoint);
            this.vertInTable.Controls.Add(this.lbAccuracyPoint);
            this.vertInTable.Location = new System.Drawing.Point(9, 3);
            this.vertInTable.Name = "vertInTable";
            this.vertInTable.Size = new System.Drawing.Size(383, 54);
            this.vertInTable.TabIndex = 9;
            this.vertInTable.TabStop = false;
            // 
            // vertexInTable
            // 
            this.vertexInTable.Location = new System.Drawing.Point(6, 19);
            this.vertexInTable.Name = "vertexInTable";
            this.vertexInTable.Size = new System.Drawing.Size(216, 23);
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
            this.cbAccuracyPoint.Location = new System.Drawing.Point(255, 27);
            this.cbAccuracyPoint.Name = "cbAccuracyPoint";
            this.cbAccuracyPoint.Size = new System.Drawing.Size(94, 21);
            this.cbAccuracyPoint.TabIndex = 2;
            this.cbAccuracyPoint.Text = "0.0";
            // 
            // lbAccuracyPoint
            // 
            this.lbAccuracyPoint.AutoSize = true;
            this.lbAccuracyPoint.Location = new System.Drawing.Point(252, 10);
            this.lbAccuracyPoint.Name = "lbAccuracyPoint";
            this.lbAccuracyPoint.Size = new System.Drawing.Size(108, 13);
            this.lbAccuracyPoint.TabIndex = 3;
            this.lbAccuracyPoint.Text = "точность координат";
            // 
            // numVertex
            // 
            this.numVertex.Controls.Add(this.btNumberVertInDwg);
            this.numVertex.Controls.Add(this.lbTextHeight);
            this.numVertex.Controls.Add(this.tbTextHeight);
            this.numVertex.Controls.Add(this.btExportInCsv);
            this.numVertex.Location = new System.Drawing.Point(9, 63);
            this.numVertex.Name = "numVertex";
            this.numVertex.Size = new System.Drawing.Size(383, 93);
            this.numVertex.TabIndex = 8;
            this.numVertex.TabStop = false;
            // 
            // btNumberVertInDwg
            // 
            this.btNumberVertInDwg.Location = new System.Drawing.Point(6, 19);
            this.btNumberVertInDwg.Name = "btNumberVertInDwg";
            this.btNumberVertInDwg.Size = new System.Drawing.Size(233, 23);
            this.btNumberVertInDwg.TabIndex = 5;
            this.btNumberVertInDwg.Text = "Нумеровать вершины в чертеже";
            this.btNumberVertInDwg.UseVisualStyleBackColor = true;
            this.btNumberVertInDwg.Click += new System.EventHandler(this.numberInDwg_Click);
            // 
            // lbTextHeight
            // 
            this.lbTextHeight.AutoSize = true;
            this.lbTextHeight.Location = new System.Drawing.Point(271, 10);
            this.lbTextHeight.Name = "lbTextHeight";
            this.lbTextHeight.Size = new System.Drawing.Size(82, 13);
            this.lbTextHeight.TabIndex = 7;
            this.lbTextHeight.Text = "Высота текста";
            // 
            // tbTextHeight
            // 
            this.tbTextHeight.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.tbTextHeight.Location = new System.Drawing.Point(261, 33);
            this.tbTextHeight.Name = "tbTextHeight";
            this.tbTextHeight.Size = new System.Drawing.Size(100, 20);
            this.tbTextHeight.TabIndex = 6;
            this.tbTextHeight.Text = "250";
            this.tbTextHeight.TextChanged += new System.EventHandler(this.textHeight_TextChanged);
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
            // GlobalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 280);
            this.Controls.Add(this.pnlOnePnl);
            this.Controls.Add(this.btGetPL);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "GlobalForm";
            this.ShowIcon = false;
            this.Text = "PLL APP by Ivanco_v0.1";
            this.pnlOnePnl.ResumeLayout(false);
            this.pnlOnePnl.PerformLayout();
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
    }
}