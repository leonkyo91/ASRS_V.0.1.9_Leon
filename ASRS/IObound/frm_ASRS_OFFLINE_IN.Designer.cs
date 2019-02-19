namespace ASRS
{
    partial class frm_ASRS_OFFLINE_IN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ASRS_OFFLINE_IN));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.BtnAddLoc = new System.Windows.Forms.Button();
            this.Grid2 = new System.Windows.Forms.DataGridView();
            this.btnQuery = new System.Windows.Forms.Button();
            this.btnCls = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkLocAuto = new System.Windows.Forms.CheckBox();
            this.Grid1 = new System.Windows.Forms.DataGridView();
            this.btnHelp2 = new System.Windows.Forms.Button();
            this.btnHelp1 = new System.Windows.Forms.Button();
            this.txtLocID = new System.Windows.Forms.TextBox();
            this.txtLoc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdQuery = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnExit2 = new System.Windows.Forms.Button();
            this.btnExecute = new System.Windows.Forms.Button();
            this.cboStnNo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid2)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.BtnAddLoc);
            this.groupBox1.Controls.Add(this.Grid2);
            this.groupBox1.Controls.Add(this.btnQuery);
            this.groupBox1.Controls.Add(this.btnCls);
            this.groupBox1.Controls.Add(this.btnDel);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox1.Location = new System.Drawing.Point(12, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(988, 258);
            this.groupBox1.TabIndex = 122;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "無帳資料";
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Location = new System.Drawing.Point(346, 26);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(106, 38);
            this.btnExit.TabIndex = 108;
            this.btnExit.Text = " 離開";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // BtnAddLoc
            // 
            this.BtnAddLoc.Font = new System.Drawing.Font("MingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BtnAddLoc.Image = ((System.Drawing.Image)(resources.GetObject("BtnAddLoc.Image")));
            this.BtnAddLoc.Location = new System.Drawing.Point(6, 217);
            this.BtnAddLoc.Name = "BtnAddLoc";
            this.BtnAddLoc.Size = new System.Drawing.Size(105, 37);
            this.BtnAddLoc.TabIndex = 107;
            this.BtnAddLoc.Text = " 加入";
            this.BtnAddLoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAddLoc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnAddLoc.UseVisualStyleBackColor = true;
            this.BtnAddLoc.Click += new System.EventHandler(this.BtnAddLoc_Click);
            // 
            // Grid2
            // 
            this.Grid2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid2.Location = new System.Drawing.Point(6, 69);
            this.Grid2.Name = "Grid2";
            this.Grid2.RowTemplate.Height = 24;
            this.Grid2.Size = new System.Drawing.Size(976, 142);
            this.Grid2.TabIndex = 106;
            this.Grid2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid2_CellClick);
            this.Grid2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid2_CellContentClick);
            // 
            // btnQuery
            // 
            this.btnQuery.Font = new System.Drawing.Font("MingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnQuery.Image = ((System.Drawing.Image)(resources.GetObject("btnQuery.Image")));
            this.btnQuery.Location = new System.Drawing.Point(534, 26);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(144, 37);
            this.btnQuery.TabIndex = 105;
            this.btnQuery.Text = "讀取無單資料";
            this.btnQuery.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuery.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnCls
            // 
            this.btnCls.Font = new System.Drawing.Font("MingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnCls.Image = ((System.Drawing.Image)(resources.GetObject("btnCls.Image")));
            this.btnCls.Location = new System.Drawing.Point(232, 26);
            this.btnCls.Name = "btnCls";
            this.btnCls.Size = new System.Drawing.Size(108, 37);
            this.btnCls.TabIndex = 103;
            this.btnCls.Text = " 清除畫面";
            this.btnCls.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCls.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCls.UseVisualStyleBackColor = true;
            this.btnCls.Click += new System.EventHandler(this.btnCls_Click);
            // 
            // btnDel
            // 
            this.btnDel.Font = new System.Drawing.Font("MingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnDel.Image = ((System.Drawing.Image)(resources.GetObject("btnDel.Image")));
            this.btnDel.Location = new System.Drawing.Point(117, 26);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(106, 37);
            this.btnDel.TabIndex = 102;
            this.btnDel.Text = " 刪除";
            this.btnDel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("MingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(6, 26);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(105, 37);
            this.btnAdd.TabIndex = 101;
            this.btnAdd.Text = " 新增";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkLocAuto);
            this.groupBox2.Controls.Add(this.Grid1);
            this.groupBox2.Controls.Add(this.btnHelp2);
            this.groupBox2.Controls.Add(this.btnHelp1);
            this.groupBox2.Controls.Add(this.txtLocID);
            this.groupBox2.Controls.Add(this.txtLoc);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cmdQuery);
            this.groupBox2.Controls.Add(this.btnClear);
            this.groupBox2.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox2.Location = new System.Drawing.Point(12, 268);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(988, 273);
            this.groupBox2.TabIndex = 123;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "入庫儲位選擇";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // chkLocAuto
            // 
            this.chkLocAuto.AutoSize = true;
            this.chkLocAuto.Location = new System.Drawing.Point(93, 1);
            this.chkLocAuto.Name = "chkLocAuto";
            this.chkLocAuto.Size = new System.Drawing.Size(91, 17);
            this.chkLocAuto.TabIndex = 153;
            this.chkLocAuto.Text = "由系統指派";
            this.chkLocAuto.UseVisualStyleBackColor = true;
            // 
            // Grid1
            // 
            this.Grid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid1.Location = new System.Drawing.Point(9, 86);
            this.Grid1.Name = "Grid1";
            this.Grid1.RowTemplate.Height = 24;
            this.Grid1.Size = new System.Drawing.Size(976, 183);
            this.Grid1.TabIndex = 152;
            // 
            // btnHelp2
            // 
            this.btnHelp2.Location = new System.Drawing.Point(252, 54);
            this.btnHelp2.Name = "btnHelp2";
            this.btnHelp2.Size = new System.Drawing.Size(30, 26);
            this.btnHelp2.TabIndex = 151;
            this.btnHelp2.Text = "...";
            this.btnHelp2.UseVisualStyleBackColor = true;
            this.btnHelp2.Click += new System.EventHandler(this.btnHelp2_Click);
            // 
            // btnHelp1
            // 
            this.btnHelp1.Location = new System.Drawing.Point(252, 23);
            this.btnHelp1.Name = "btnHelp1";
            this.btnHelp1.Size = new System.Drawing.Size(30, 26);
            this.btnHelp1.TabIndex = 150;
            this.btnHelp1.Text = "...";
            this.btnHelp1.UseVisualStyleBackColor = true;
            this.btnHelp1.Click += new System.EventHandler(this.btnHelp1_Click);
            // 
            // txtLocID
            // 
            this.txtLocID.BackColor = System.Drawing.Color.White;
            this.txtLocID.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtLocID.Location = new System.Drawing.Point(93, 53);
            this.txtLocID.Name = "txtLocID";
            this.txtLocID.Size = new System.Drawing.Size(153, 27);
            this.txtLocID.TabIndex = 149;
            // 
            // txtLoc
            // 
            this.txtLoc.BackColor = System.Drawing.Color.White;
            this.txtLoc.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtLoc.Location = new System.Drawing.Point(93, 23);
            this.txtLoc.Name = "txtLoc";
            this.txtLoc.Size = new System.Drawing.Size(153, 27);
            this.txtLoc.TabIndex = 148;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 108;
            this.label2.Text = "料盤編號";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 107;
            this.label1.Text = "儲位編號";
            // 
            // cmdQuery
            // 
            this.cmdQuery.Font = new System.Drawing.Font("MingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmdQuery.Image = ((System.Drawing.Image)(resources.GetObject("cmdQuery.Image")));
            this.cmdQuery.Location = new System.Drawing.Point(306, 37);
            this.cmdQuery.Name = "cmdQuery";
            this.cmdQuery.Size = new System.Drawing.Size(108, 37);
            this.cmdQuery.TabIndex = 105;
            this.cmdQuery.Text = "查詢";
            this.cmdQuery.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdQuery.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdQuery.UseVisualStyleBackColor = true;
            this.cmdQuery.Click += new System.EventHandler(this.cmdQuery_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("MingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.Location = new System.Drawing.Point(420, 37);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(108, 37);
            this.btnClear.TabIndex = 103;
            this.btnClear.Text = " 清除畫面";
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnExit2);
            this.groupBox3.Controls.Add(this.btnExecute);
            this.groupBox3.Controls.Add(this.cboStnNo);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox3.Location = new System.Drawing.Point(12, 543);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(988, 56);
            this.groupBox3.TabIndex = 124;
            this.groupBox3.TabStop = false;
            // 
            // btnExit2
            // 
            this.btnExit2.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnExit2.Image = ((System.Drawing.Image)(resources.GetObject("btnExit2.Image")));
            this.btnExit2.Location = new System.Drawing.Point(312, 14);
            this.btnExit2.Name = "btnExit2";
            this.btnExit2.Size = new System.Drawing.Size(106, 38);
            this.btnExit2.TabIndex = 107;
            this.btnExit2.Text = " 離開";
            this.btnExit2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExit2.UseVisualStyleBackColor = true;
            this.btnExit2.Click += new System.EventHandler(this.btnExit2_Click);
            // 
            // btnExecute
            // 
            this.btnExecute.Font = new System.Drawing.Font("MingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnExecute.Image = ((System.Drawing.Image)(resources.GetObject("btnExecute.Image")));
            this.btnExecute.Location = new System.Drawing.Point(200, 14);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(106, 37);
            this.btnExecute.TabIndex = 106;
            this.btnExecute.Text = " 執行";
            this.btnExecute.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExecute.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // cboStnNo
            // 
            this.cboStnNo.BackColor = System.Drawing.Color.White;
            this.cboStnNo.FormattingEnabled = true;
            this.cboStnNo.Location = new System.Drawing.Point(61, 20);
            this.cboStnNo.Name = "cboStnNo";
            this.cboStnNo.Size = new System.Drawing.Size(113, 21);
            this.cboStnNo.TabIndex = 98;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 96;
            this.label4.Text = "站號";
            // 
            // frm_ASRS_OFFLINE_IN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1012, 606);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frm_ASRS_OFFLINE_IN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AWP090 無帳(單)入庫作業";
            this.Load += new System.EventHandler(this.frm_ASRS_OFFLINE_IN_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Button btnDel;
        internal System.Windows.Forms.Button btnAdd;
        internal System.Windows.Forms.Button btnCls;
        internal System.Windows.Forms.Button btnQuery;
        internal System.Windows.Forms.Button BtnAddLoc;
        private System.Windows.Forms.DataGridView Grid2;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.Button cmdQuery;
        internal System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLocID;
        private System.Windows.Forms.TextBox txtLoc;
        private System.Windows.Forms.Button btnHelp2;
        private System.Windows.Forms.Button btnHelp1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboStnNo;
        internal System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.DataGridView Grid1;
        internal System.Windows.Forms.Button btnExit;
        internal System.Windows.Forms.Button btnExit2;
        private System.Windows.Forms.CheckBox chkLocAuto;
    }
}