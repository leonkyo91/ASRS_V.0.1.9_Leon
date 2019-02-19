namespace ASRS
{
    partial class frm_STOCK
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_STOCK));
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.Grid1 = new System.Windows.Forms.DataGridView();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.RdBtn_3 = new System.Windows.Forms.RadioButton();
            this.RdBtn_1 = new System.Windows.Forms.RadioButton();
            this.RdBtn_2 = new System.Windows.Forms.RadioButton();
            this.Label13 = new System.Windows.Forms.Label();
            this.txtLotNoCount = new System.Windows.Forms.TextBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.cmdExport = new System.Windows.Forms.Button();
            this.cmdEnd = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.GroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).BeginInit();
            this.GroupBox2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.tableLayoutPanel1);
            this.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupBox3.Location = new System.Drawing.Point(0, 0);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(1012, 606);
            this.GroupBox3.TabIndex = 34;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "庫存清單";
            // 
            // Grid1
            // 
            this.Grid1.AllowUserToAddRows = false;
            this.Grid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grid1.Location = new System.Drawing.Point(3, 117);
            this.Grid1.Name = "Grid1";
            this.Grid1.RowTemplate.Height = 24;
            this.Grid1.Size = new System.Drawing.Size(1000, 465);
            this.Grid1.TabIndex = 38;
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.RdBtn_3);
            this.GroupBox2.Controls.Add(this.RdBtn_1);
            this.GroupBox2.Controls.Add(this.RdBtn_2);
            this.GroupBox2.Location = new System.Drawing.Point(340, 3);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(384, 66);
            this.GroupBox2.TabIndex = 34;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "查詢條件";
            // 
            // RdBtn_3
            // 
            this.RdBtn_3.AutoSize = true;
            this.RdBtn_3.Checked = true;
            this.RdBtn_3.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.RdBtn_3.Location = new System.Drawing.Point(245, 27);
            this.RdBtn_3.Name = "RdBtn_3";
            this.RdBtn_3.Size = new System.Drawing.Size(103, 17);
            this.RdBtn_3.TabIndex = 37;
            this.RdBtn_3.TabStop = true;
            this.RdBtn_3.Text = "所有庫存資料";
            this.RdBtn_3.UseVisualStyleBackColor = true;
            // 
            // RdBtn_1
            // 
            this.RdBtn_1.AutoSize = true;
            this.RdBtn_1.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.RdBtn_1.Location = new System.Drawing.Point(11, 28);
            this.RdBtn_1.Name = "RdBtn_1";
            this.RdBtn_1.Size = new System.Drawing.Size(98, 17);
            this.RdBtn_1.TabIndex = 34;
            this.RdBtn_1.Text = "無帳(單)資料";
            this.RdBtn_1.UseVisualStyleBackColor = true;
            // 
            // RdBtn_2
            // 
            this.RdBtn_2.AutoSize = true;
            this.RdBtn_2.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.RdBtn_2.Location = new System.Drawing.Point(133, 27);
            this.RdBtn_2.Name = "RdBtn_2";
            this.RdBtn_2.Size = new System.Drawing.Size(90, 17);
            this.RdBtn_2.TabIndex = 36;
            this.RdBtn_2.Text = "己入帳資料";
            this.RdBtn_2.UseVisualStyleBackColor = true;
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label13.Location = new System.Drawing.Point(4, 6);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(33, 13);
            this.Label13.TabIndex = 33;
            this.Label13.Text = "批數";
            // 
            // txtLotNoCount
            // 
            this.txtLotNoCount.Enabled = false;
            this.txtLotNoCount.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtLotNoCount.Location = new System.Drawing.Point(43, 3);
            this.txtLotNoCount.Name = "txtLotNoCount";
            this.txtLotNoCount.Size = new System.Drawing.Size(74, 23);
            this.txtLotNoCount.TabIndex = 32;
            this.txtLotNoCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.btnQuery);
            this.GroupBox1.Controls.Add(this.cmdExport);
            this.GroupBox1.Controls.Add(this.cmdEnd);
            this.GroupBox1.Location = new System.Drawing.Point(4, 3);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(330, 66);
            this.GroupBox1.TabIndex = 31;
            this.GroupBox1.TabStop = false;
            // 
            // btnQuery
            // 
            this.btnQuery.Font = new System.Drawing.Font("MingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnQuery.Image = ((System.Drawing.Image)(resources.GetObject("btnQuery.Image")));
            this.btnQuery.Location = new System.Drawing.Point(6, 18);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(107, 37);
            this.btnQuery.TabIndex = 90;
            this.btnQuery.Text = "查詢";
            this.btnQuery.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuery.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // cmdExport
            // 
            this.cmdExport.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmdExport.Image = ((System.Drawing.Image)(resources.GetObject("cmdExport.Image")));
            this.cmdExport.Location = new System.Drawing.Point(115, 19);
            this.cmdExport.Name = "cmdExport";
            this.cmdExport.Size = new System.Drawing.Size(99, 35);
            this.cmdExport.TabIndex = 35;
            this.cmdExport.Text = "匯出Excel";
            this.cmdExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdExport.UseVisualStyleBackColor = true;
            this.cmdExport.Click += new System.EventHandler(this.cmdExport_Click);
            // 
            // cmdEnd
            // 
            this.cmdEnd.Font = new System.Drawing.Font("MingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmdEnd.Image = ((System.Drawing.Image)(resources.GetObject("cmdEnd.Image")));
            this.cmdEnd.Location = new System.Drawing.Point(216, 19);
            this.cmdEnd.Name = "cmdEnd";
            this.cmdEnd.Size = new System.Drawing.Size(107, 35);
            this.cmdEnd.TabIndex = 33;
            this.cmdEnd.Text = "離開";
            this.cmdEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdEnd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdEnd.UseVisualStyleBackColor = true;
            this.cmdEnd.Click += new System.EventHandler(this.cmdEnd_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Grid1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1006, 585);
            this.tableLayoutPanel1.TabIndex = 105;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.GroupBox1);
            this.panel1.Controls.Add(this.GroupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 69);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtLotNoCount);
            this.panel2.Controls.Add(this.Label13);
            this.panel2.Location = new System.Drawing.Point(3, 78);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 33);
            this.panel2.TabIndex = 1;
            // 
            // frm_STOCK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1012, 606);
            this.Controls.Add(this.GroupBox3);
            this.Name = "frm_STOCK";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "庫存資料查詢";
            this.Load += new System.EventHandler(this.frm_STOCK_Load);
            this.GroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).EndInit();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.RadioButton RdBtn_3;
        internal System.Windows.Forms.RadioButton RdBtn_1;
        internal System.Windows.Forms.RadioButton RdBtn_2;
        internal System.Windows.Forms.Label Label13;
        internal System.Windows.Forms.TextBox txtLotNoCount;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Button cmdExport;
        internal System.Windows.Forms.Button cmdEnd;
        internal System.Windows.Forms.Button btnQuery;
        internal System.Windows.Forms.DataGridView Grid1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}