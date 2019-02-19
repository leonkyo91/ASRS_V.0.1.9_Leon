namespace ASRS
{
    partial class frm_IQC_DATA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_IQC_DATA));
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDate2 = new System.Windows.Forms.DateTimePicker();
            this.txtDate1 = new System.Windows.Forms.DateTimePicker();
            this.chkDate = new System.Windows.Forms.CheckBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtRcvNo2 = new System.Windows.Forms.TextBox();
            this.txtRcvNo1 = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.txtLotNo2 = new System.Windows.Forms.TextBox();
            this.txtLotNo1 = new System.Windows.Forms.TextBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.txtIQCID = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdExport = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnCls = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.Label13 = new System.Windows.Forms.Label();
            this.txtLotNoCount = new System.Windows.Forms.TextBox();
            this.Grid1 = new System.Windows.Forms.DataGridView();
            this.GroupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.txtDate2);
            this.GroupBox2.Controls.Add(this.txtDate1);
            this.GroupBox2.Controls.Add(this.chkDate);
            this.GroupBox2.Controls.Add(this.Label4);
            this.GroupBox2.Controls.Add(this.Label1);
            this.GroupBox2.Controls.Add(this.txtRcvNo2);
            this.GroupBox2.Controls.Add(this.txtRcvNo1);
            this.GroupBox2.Controls.Add(this.Label2);
            this.GroupBox2.Controls.Add(this.Label10);
            this.GroupBox2.Controls.Add(this.txtLotNo2);
            this.GroupBox2.Controls.Add(this.txtLotNo1);
            this.GroupBox2.Controls.Add(this.Label9);
            this.GroupBox2.Controls.Add(this.Label5);
            this.GroupBox2.Controls.Add(this.txtIQCID);
            this.GroupBox2.Location = new System.Drawing.Point(12, 12);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(981, 78);
            this.GroupBox2.TabIndex = 35;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "查詢條件";
            // 
            // txtDate2
            // 
            this.txtDate2.CustomFormat = "yyyy/MM/dd";
            this.txtDate2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtDate2.Location = new System.Drawing.Point(568, 15);
            this.txtDate2.Name = "txtDate2";
            this.txtDate2.Size = new System.Drawing.Size(109, 22);
            this.txtDate2.TabIndex = 74;
            // 
            // txtDate1
            // 
            this.txtDate1.CustomFormat = "yyyy/MM/dd";
            this.txtDate1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtDate1.Location = new System.Drawing.Point(423, 16);
            this.txtDate1.Name = "txtDate1";
            this.txtDate1.Size = new System.Drawing.Size(109, 22);
            this.txtDate1.TabIndex = 73;
            // 
            // chkDate
            // 
            this.chkDate.AutoSize = true;
            this.chkDate.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.chkDate.Location = new System.Drawing.Point(339, 18);
            this.chkDate.Name = "chkDate";
            this.chkDate.Size = new System.Drawing.Size(78, 17);
            this.chkDate.TabIndex = 69;
            this.chkDate.Text = "簽收日期";
            this.chkDate.UseVisualStyleBackColor = true;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label4.Location = new System.Drawing.Point(538, 20);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(20, 13);
            this.Label4.TabIndex = 24;
            this.Label4.Text = "～";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label1.Location = new System.Drawing.Point(538, 44);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(20, 13);
            this.Label1.TabIndex = 33;
            this.Label1.Text = "～";
            // 
            // txtRcvNo2
            // 
            this.txtRcvNo2.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtRcvNo2.Location = new System.Drawing.Point(568, 42);
            this.txtRcvNo2.Name = "txtRcvNo2";
            this.txtRcvNo2.Size = new System.Drawing.Size(109, 23);
            this.txtRcvNo2.TabIndex = 22;
            // 
            // txtRcvNo1
            // 
            this.txtRcvNo1.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtRcvNo1.Location = new System.Drawing.Point(425, 41);
            this.txtRcvNo1.Name = "txtRcvNo1";
            this.txtRcvNo1.Size = new System.Drawing.Size(107, 23);
            this.txtRcvNo1.TabIndex = 20;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label2.Location = new System.Drawing.Point(358, 44);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(59, 13);
            this.Label2.TabIndex = 30;
            this.Label2.Text = "收料序號";
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label10.Location = new System.Drawing.Point(194, 49);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(20, 13);
            this.Label10.TabIndex = 19;
            this.Label10.Text = "～";
            // 
            // txtLotNo2
            // 
            this.txtLotNo2.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtLotNo2.Location = new System.Drawing.Point(220, 42);
            this.txtLotNo2.Name = "txtLotNo2";
            this.txtLotNo2.Size = new System.Drawing.Size(90, 23);
            this.txtLotNo2.TabIndex = 18;
            // 
            // txtLotNo1
            // 
            this.txtLotNo1.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtLotNo1.Location = new System.Drawing.Point(98, 43);
            this.txtLotNo1.Name = "txtLotNo1";
            this.txtLotNo1.Size = new System.Drawing.Size(90, 23);
            this.txtLotNo1.TabIndex = 17;
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label9.Location = new System.Drawing.Point(51, 46);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(41, 13);
            this.Label9.TabIndex = 16;
            this.Label9.Text = "Lot No";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label5.Location = new System.Drawing.Point(14, 25);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(78, 13);
            this.Label5.TabIndex = 9;
            this.Label5.Text = "IQC ID(工號)";
            // 
            // txtIQCID
            // 
            this.txtIQCID.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtIQCID.Location = new System.Drawing.Point(98, 17);
            this.txtIQCID.Name = "txtIQCID";
            this.txtIQCID.Size = new System.Drawing.Size(90, 23);
            this.txtIQCID.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmdExport);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.btnCls);
            this.groupBox1.Controls.Add(this.btnQuery);
            this.groupBox1.Location = new System.Drawing.Point(12, 92);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(981, 55);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            // 
            // cmdExport
            // 
            this.cmdExport.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmdExport.Image = ((System.Drawing.Image)(resources.GetObject("cmdExport.Image")));
            this.cmdExport.Location = new System.Drawing.Point(232, 10);
            this.cmdExport.Name = "cmdExport";
            this.cmdExport.Size = new System.Drawing.Size(99, 38);
            this.cmdExport.TabIndex = 107;
            this.cmdExport.Text = "匯出Excel";
            this.cmdExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdExport.UseVisualStyleBackColor = true;
            this.cmdExport.Click += new System.EventHandler(this.cmdExport_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Location = new System.Drawing.Point(337, 11);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(106, 38);
            this.btnExit.TabIndex = 106;
            this.btnExit.Text = "離開";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnCls
            // 
            this.btnCls.Font = new System.Drawing.Font("MingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnCls.Image = ((System.Drawing.Image)(resources.GetObject("btnCls.Image")));
            this.btnCls.Location = new System.Drawing.Point(118, 11);
            this.btnCls.Name = "btnCls";
            this.btnCls.Size = new System.Drawing.Size(108, 37);
            this.btnCls.TabIndex = 104;
            this.btnCls.Text = " 清除";
            this.btnCls.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCls.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCls.UseVisualStyleBackColor = true;
            this.btnCls.Click += new System.EventHandler(this.btnCls_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Font = new System.Drawing.Font("MingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnQuery.Image = ((System.Drawing.Image)(resources.GetObject("btnQuery.Image")));
            this.btnQuery.Location = new System.Drawing.Point(5, 11);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(107, 37);
            this.btnQuery.TabIndex = 105;
            this.btnQuery.Text = "查詢";
            this.btnQuery.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuery.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.Label13);
            this.GroupBox3.Controls.Add(this.txtLotNoCount);
            this.GroupBox3.Controls.Add(this.Grid1);
            this.GroupBox3.Location = new System.Drawing.Point(12, 153);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(981, 435);
            this.GroupBox3.TabIndex = 38;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "查詢結果";
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label13.Location = new System.Drawing.Point(7, 15);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(33, 13);
            this.Label13.TabIndex = 31;
            this.Label13.Text = "批數";
            // 
            // txtLotNoCount
            // 
            this.txtLotNoCount.Enabled = false;
            this.txtLotNoCount.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtLotNoCount.Location = new System.Drawing.Point(46, 12);
            this.txtLotNoCount.Name = "txtLotNoCount";
            this.txtLotNoCount.Size = new System.Drawing.Size(74, 23);
            this.txtLotNoCount.TabIndex = 30;
            this.txtLotNoCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Grid1
            // 
            this.Grid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid1.Location = new System.Drawing.Point(6, 41);
            this.Grid1.Name = "Grid1";
            this.Grid1.RowTemplate.Height = 24;
            this.Grid1.Size = new System.Drawing.Size(969, 388);
            this.Grid1.TabIndex = 2;
            // 
            // frm_IQC_DATA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1012, 606);
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GroupBox2);
            this.Name = "frm_IQC_DATA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IQC簽收資料查詢";
            this.Load += new System.EventHandler(this.frm_IQC_DATA_Load);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.DateTimePicker txtDate2;
        internal System.Windows.Forms.DateTimePicker txtDate1;
        internal System.Windows.Forms.CheckBox chkDate;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txtRcvNo2;
        internal System.Windows.Forms.TextBox txtRcvNo1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.TextBox txtLotNo2;
        internal System.Windows.Forms.TextBox txtLotNo1;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.TextBox txtIQCID;
        internal System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Button cmdExport;
        internal System.Windows.Forms.Button btnExit;
        internal System.Windows.Forms.Button btnCls;
        internal System.Windows.Forms.Button btnQuery;
        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.Label Label13;
        internal System.Windows.Forms.TextBox txtLotNoCount;
        internal System.Windows.Forms.DataGridView Grid1;
    }
}