namespace ASRS
{
    partial class frm_CMD_MAINTAIN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_CMD_MAINTAIN));
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.RdBtn0 = new System.Windows.Forms.RadioButton();
            this.RdBtn4 = new System.Windows.Forms.RadioButton();
            this.RdBtn3 = new System.Windows.Forms.RadioButton();
            this.RdBtn2 = new System.Windows.Forms.RadioButton();
            this.RdBtn1 = new System.Windows.Forms.RadioButton();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.Grid1 = new System.Windows.Forms.DataGridView();
            this.Grid2 = new System.Windows.Forms.DataGridView();
            this.Label13 = new System.Windows.Forms.Label();
            this.Label12 = new System.Windows.Forms.Label();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.txtLocID = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtLoc = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.cboIotype = new System.Windows.Forms.ComboBox();
            this.Label11 = new System.Windows.Forms.Label();
            this.txtCmdSno1 = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.txtCmdSno0 = new System.Windows.Forms.TextBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdStart = new System.Windows.Forms.Button();
            this.cmdQuery = new System.Windows.Forms.Button();
            this.cmdClear = new System.Windows.Forms.Button();
            this.cmdEnd = new System.Windows.Forms.Button();
            this.GroupBox4.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid2)).BeginInit();
            this.GroupBox2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.RdBtn0);
            this.GroupBox4.Controls.Add(this.RdBtn4);
            this.GroupBox4.Controls.Add(this.RdBtn3);
            this.GroupBox4.Controls.Add(this.RdBtn2);
            this.GroupBox4.Controls.Add(this.RdBtn1);
            this.GroupBox4.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.GroupBox4.Location = new System.Drawing.Point(12, 8);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(226, 154);
            this.GroupBox4.TabIndex = 38;
            this.GroupBox4.TabStop = false;
            // 
            // RdBtn0
            // 
            this.RdBtn0.AutoSize = true;
            this.RdBtn0.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.RdBtn0.Location = new System.Drawing.Point(11, 17);
            this.RdBtn0.Name = "RdBtn0";
            this.RdBtn0.Size = new System.Drawing.Size(126, 20);
            this.RdBtn0.TabIndex = 4;
            this.RdBtn0.TabStop = true;
            this.RdBtn0.Text = "命令暫停/啓動";
            this.RdBtn0.UseVisualStyleBackColor = true;
            // 
            // RdBtn4
            // 
            this.RdBtn4.AutoSize = true;
            this.RdBtn4.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.RdBtn4.Location = new System.Drawing.Point(11, 121);
            this.RdBtn4.Name = "RdBtn4";
            this.RdBtn4.Size = new System.Drawing.Size(93, 20);
            this.RdBtn4.TabIndex = 3;
            this.RdBtn4.TabStop = true;
            this.RdBtn4.Text = "修改Trace";
            this.RdBtn4.UseVisualStyleBackColor = true;
            // 
            // RdBtn3
            // 
            this.RdBtn3.AutoSize = true;
            this.RdBtn3.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.RdBtn3.Location = new System.Drawing.Point(11, 95);
            this.RdBtn3.Name = "RdBtn3";
            this.RdBtn3.Size = new System.Drawing.Size(122, 20);
            this.RdBtn3.TabIndex = 2;
            this.RdBtn3.TabStop = true;
            this.RdBtn3.Text = "修改出庫順序";
            this.RdBtn3.UseVisualStyleBackColor = true;
            // 
            // RdBtn2
            // 
            this.RdBtn2.AutoSize = true;
            this.RdBtn2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.RdBtn2.Location = new System.Drawing.Point(11, 69);
            this.RdBtn2.Name = "RdBtn2";
            this.RdBtn2.Size = new System.Drawing.Size(90, 20);
            this.RdBtn2.TabIndex = 1;
            this.RdBtn2.TabStop = true;
            this.RdBtn2.Text = "強制過帳";
            this.RdBtn2.UseVisualStyleBackColor = true;
            // 
            // RdBtn1
            // 
            this.RdBtn1.AutoSize = true;
            this.RdBtn1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.RdBtn1.Location = new System.Drawing.Point(11, 43);
            this.RdBtn1.Name = "RdBtn1";
            this.RdBtn1.Size = new System.Drawing.Size(90, 20);
            this.RdBtn1.TabIndex = 0;
            this.RdBtn1.TabStop = true;
            this.RdBtn1.Text = "命令取消";
            this.RdBtn1.UseVisualStyleBackColor = true;
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.Grid1);
            this.GroupBox3.Controls.Add(this.Grid2);
            this.GroupBox3.Controls.Add(this.Label13);
            this.GroupBox3.Controls.Add(this.Label12);
            this.GroupBox3.Location = new System.Drawing.Point(243, 8);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(757, 598);
            this.GroupBox3.TabIndex = 37;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "查詢結果";
            // 
            // Grid1
            // 
            this.Grid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid1.Location = new System.Drawing.Point(9, 34);
            this.Grid1.Name = "Grid1";
            this.Grid1.RowTemplate.Height = 24;
            this.Grid1.Size = new System.Drawing.Size(742, 411);
            this.Grid1.TabIndex = 29;
            this.Grid1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid1_CellClick);
            this.Grid1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid1_CellContentClick);
            // 
            // Grid2
            // 
            this.Grid2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid2.Location = new System.Drawing.Point(6, 464);
            this.Grid2.Name = "Grid2";
            this.Grid2.RowTemplate.Height = 24;
            this.Grid2.Size = new System.Drawing.Size(742, 117);
            this.Grid2.TabIndex = 28;
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label13.ForeColor = System.Drawing.Color.Blue;
            this.Label13.Location = new System.Drawing.Point(6, 448);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(59, 13);
            this.Label13.TabIndex = 26;
            this.Label13.Text = "命令明細";
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label12.ForeColor = System.Drawing.Color.Blue;
            this.Label12.Location = new System.Drawing.Point(6, 18);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(59, 13);
            this.Label12.TabIndex = 25;
            this.Label12.Text = "命令清單";
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.txtUserID);
            this.GroupBox2.Controls.Add(this.txtLocID);
            this.GroupBox2.Controls.Add(this.Label3);
            this.GroupBox2.Controls.Add(this.txtLoc);
            this.GroupBox2.Controls.Add(this.Label2);
            this.GroupBox2.Controls.Add(this.Label1);
            this.GroupBox2.Controls.Add(this.cboIotype);
            this.GroupBox2.Controls.Add(this.Label11);
            this.GroupBox2.Controls.Add(this.txtCmdSno1);
            this.GroupBox2.Controls.Add(this.Label6);
            this.GroupBox2.Controls.Add(this.Label5);
            this.GroupBox2.Controls.Add(this.txtCmdSno0);
            this.GroupBox2.Location = new System.Drawing.Point(12, 168);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(226, 239);
            this.GroupBox2.TabIndex = 36;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "查詢條件";
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(84, 181);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(90, 22);
            this.txtUserID.TabIndex = 33;
            // 
            // txtLocID
            // 
            this.txtLocID.Location = new System.Drawing.Point(84, 144);
            this.txtLocID.Name = "txtLocID";
            this.txtLocID.Size = new System.Drawing.Size(90, 22);
            this.txtLocID.TabIndex = 32;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label3.Location = new System.Drawing.Point(22, 144);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(56, 16);
            this.Label3.TabIndex = 31;
            this.Label3.Text = "料盤ID";
            // 
            // txtLoc
            // 
            this.txtLoc.Location = new System.Drawing.Point(84, 110);
            this.txtLoc.Name = "txtLoc";
            this.txtLoc.Size = new System.Drawing.Size(90, 22);
            this.txtLoc.TabIndex = 29;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label2.Location = new System.Drawing.Point(22, 181);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(56, 16);
            this.Label2.TabIndex = 28;
            this.Label2.Text = "使用者";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label1.Location = new System.Drawing.Point(8, 110);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(72, 16);
            this.Label1.TabIndex = 27;
            this.Label1.Text = "儲位編號";
            // 
            // cboIotype
            // 
            this.cboIotype.FormattingEnabled = true;
            this.cboIotype.Location = new System.Drawing.Point(84, 78);
            this.cboIotype.Name = "cboIotype";
            this.cboIotype.Size = new System.Drawing.Size(132, 20);
            this.cboIotype.TabIndex = 26;
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label11.Location = new System.Drawing.Point(22, 78);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(56, 16);
            this.Label11.TabIndex = 24;
            this.Label11.Text = "作業別";
            // 
            // txtCmdSno1
            // 
            this.txtCmdSno1.Location = new System.Drawing.Point(84, 43);
            this.txtCmdSno1.Name = "txtCmdSno1";
            this.txtCmdSno1.Size = new System.Drawing.Size(90, 22);
            this.txtCmdSno1.TabIndex = 11;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label6.Location = new System.Drawing.Point(45, 43);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(24, 16);
            this.Label6.TabIndex = 10;
            this.Label6.Text = "～";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label5.Location = new System.Drawing.Point(6, 18);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(72, 16);
            this.Label5.TabIndex = 9;
            this.Label5.Text = "命令序號";
            // 
            // txtCmdSno0
            // 
            this.txtCmdSno0.Location = new System.Drawing.Point(84, 15);
            this.txtCmdSno0.Name = "txtCmdSno0";
            this.txtCmdSno0.Size = new System.Drawing.Size(90, 22);
            this.txtCmdSno0.TabIndex = 8;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.cmdStart);
            this.GroupBox1.Controls.Add(this.cmdQuery);
            this.GroupBox1.Controls.Add(this.cmdClear);
            this.GroupBox1.Controls.Add(this.cmdEnd);
            this.GroupBox1.Location = new System.Drawing.Point(12, 413);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(226, 181);
            this.GroupBox1.TabIndex = 35;
            this.GroupBox1.TabStop = false;
            // 
            // cmdStart
            // 
            this.cmdStart.Font = new System.Drawing.Font("細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmdStart.Image = ((System.Drawing.Image)(resources.GetObject("cmdStart.Image")));
            this.cmdStart.Location = new System.Drawing.Point(11, 62);
            this.cmdStart.Name = "cmdStart";
            this.cmdStart.Size = new System.Drawing.Size(205, 35);
            this.cmdStart.TabIndex = 49;
            this.cmdStart.Text = "執行";
            this.cmdStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdStart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdStart.UseVisualStyleBackColor = true;
            this.cmdStart.Click += new System.EventHandler(this.cmdStart_Click);
            // 
            // cmdQuery
            // 
            this.cmdQuery.Font = new System.Drawing.Font("細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmdQuery.Image = ((System.Drawing.Image)(resources.GetObject("cmdQuery.Image")));
            this.cmdQuery.Location = new System.Drawing.Point(11, 21);
            this.cmdQuery.Name = "cmdQuery";
            this.cmdQuery.Size = new System.Drawing.Size(205, 35);
            this.cmdQuery.TabIndex = 37;
            this.cmdQuery.Text = "查詢";
            this.cmdQuery.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdQuery.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdQuery.UseVisualStyleBackColor = true;
            this.cmdQuery.Click += new System.EventHandler(this.cmdQuery_Click);
            // 
            // cmdClear
            // 
            this.cmdClear.Font = new System.Drawing.Font("細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmdClear.Image = ((System.Drawing.Image)(resources.GetObject("cmdClear.Image")));
            this.cmdClear.Location = new System.Drawing.Point(11, 103);
            this.cmdClear.Name = "cmdClear";
            this.cmdClear.Size = new System.Drawing.Size(205, 35);
            this.cmdClear.TabIndex = 36;
            this.cmdClear.Text = "清除畫面";
            this.cmdClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClear.UseVisualStyleBackColor = true;
            this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
            // 
            // cmdEnd
            // 
            this.cmdEnd.Font = new System.Drawing.Font("細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmdEnd.Image = ((System.Drawing.Image)(resources.GetObject("cmdEnd.Image")));
            this.cmdEnd.Location = new System.Drawing.Point(11, 144);
            this.cmdEnd.Name = "cmdEnd";
            this.cmdEnd.Size = new System.Drawing.Size(205, 35);
            this.cmdEnd.TabIndex = 35;
            this.cmdEnd.Text = "離開";
            this.cmdEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdEnd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdEnd.UseVisualStyleBackColor = true;
            this.cmdEnd.Click += new System.EventHandler(this.cmdEnd_Click);
            // 
            // frm_CMD_MAINTAIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1012, 606);
            this.Controls.Add(this.GroupBox4);
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.GroupBox1);
            this.Name = "frm_CMD_MAINTAIN";
            this.Text = "命令資料維護";
            this.Load += new System.EventHandler(this.frm_CMD_MAINTAIN_Load);
            this.GroupBox4.ResumeLayout(false);
            this.GroupBox4.PerformLayout();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid2)).EndInit();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox4;
        internal System.Windows.Forms.RadioButton RdBtn0;
        internal System.Windows.Forms.RadioButton RdBtn4;
        internal System.Windows.Forms.RadioButton RdBtn3;
        internal System.Windows.Forms.RadioButton RdBtn2;
        internal System.Windows.Forms.RadioButton RdBtn1;
        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.Label Label13;
        internal System.Windows.Forms.Label Label12;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.TextBox txtUserID;
        internal System.Windows.Forms.TextBox txtLocID;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txtLoc;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ComboBox cboIotype;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.TextBox txtCmdSno1;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.TextBox txtCmdSno0;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Button cmdStart;
        internal System.Windows.Forms.Button cmdQuery;
        internal System.Windows.Forms.Button cmdClear;
        internal System.Windows.Forms.Button cmdEnd;
        internal System.Windows.Forms.DataGridView Grid2;
        internal System.Windows.Forms.DataGridView Grid1;
    }
}