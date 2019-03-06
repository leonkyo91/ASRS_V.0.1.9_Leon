namespace ASRS
{
    partial class frm_USER
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_USER));
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.cmdExport = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.cmdStart = new System.Windows.Forms.Button();
            this.cmdClear = new System.Windows.Forms.Button();
            this.cmdExit = new System.Windows.Forms.Button();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.cboProgStytle = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPassWord = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.RdUnlock = new System.Windows.Forms.RadioButton();
            this.RdDel = new System.Windows.Forms.RadioButton();
            this.RdMo = new System.Windows.Forms.RadioButton();
            this.RdAdd = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.Grid1 = new System.Windows.Forms.DataGridView();
            this.GroupBox1.SuspendLayout();
            this.GroupBox4.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.GroupBox4);
            this.GroupBox1.Controls.Add(this.GroupBox3);
            this.GroupBox1.Controls.Add(this.GroupBox2);
            this.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupBox1.Location = new System.Drawing.Point(251, 34);
            this.GroupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.GroupBox1.Size = new System.Drawing.Size(1016, 439);
            this.GroupBox1.TabIndex = 14;
            this.GroupBox1.TabStop = false;
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.cmdExport);
            this.GroupBox4.Controls.Add(this.btnQuery);
            this.GroupBox4.Controls.Add(this.cmdStart);
            this.GroupBox4.Controls.Add(this.cmdClear);
            this.GroupBox4.Controls.Add(this.cmdExit);
            this.GroupBox4.Location = new System.Drawing.Point(124, 308);
            this.GroupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.GroupBox4.Size = new System.Drawing.Size(810, 118);
            this.GroupBox4.TabIndex = 15;
            this.GroupBox4.TabStop = false;
            // 
            // cmdExport
            // 
            this.cmdExport.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmdExport.Image = ((System.Drawing.Image)(resources.GetObject("cmdExport.Image")));
            this.cmdExport.Location = new System.Drawing.Point(177, 32);
            this.cmdExport.Margin = new System.Windows.Forms.Padding(4);
            this.cmdExport.Name = "cmdExport";
            this.cmdExport.Size = new System.Drawing.Size(148, 52);
            this.cmdExport.TabIndex = 107;
            this.cmdExport.Text = "匯出Excel";
            this.cmdExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdExport.UseVisualStyleBackColor = true;
            this.cmdExport.Click += new System.EventHandler(this.cmdExport_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Font = new System.Drawing.Font("細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnQuery.Image = ((System.Drawing.Image)(resources.GetObject("btnQuery.Image")));
            this.btnQuery.Location = new System.Drawing.Point(16, 32);
            this.btnQuery.Margin = new System.Windows.Forms.Padding(4);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(152, 52);
            this.btnQuery.TabIndex = 106;
            this.btnQuery.Text = "查詢";
            this.btnQuery.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuery.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // cmdStart
            // 
            this.cmdStart.Font = new System.Drawing.Font("細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmdStart.Image = ((System.Drawing.Image)(resources.GetObject("cmdStart.Image")));
            this.cmdStart.Location = new System.Drawing.Point(519, 32);
            this.cmdStart.Margin = new System.Windows.Forms.Padding(4);
            this.cmdStart.Name = "cmdStart";
            this.cmdStart.Size = new System.Drawing.Size(135, 52);
            this.cmdStart.TabIndex = 72;
            this.cmdStart.Text = "執行";
            this.cmdStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdStart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdStart.UseVisualStyleBackColor = true;
            this.cmdStart.Click += new System.EventHandler(this.cmdStart_Click);
            // 
            // cmdClear
            // 
            this.cmdClear.Font = new System.Drawing.Font("細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmdClear.Image = ((System.Drawing.Image)(resources.GetObject("cmdClear.Image")));
            this.cmdClear.Location = new System.Drawing.Point(363, 32);
            this.cmdClear.Margin = new System.Windows.Forms.Padding(4);
            this.cmdClear.Name = "cmdClear";
            this.cmdClear.Size = new System.Drawing.Size(147, 52);
            this.cmdClear.TabIndex = 70;
            this.cmdClear.Text = "清除畫面";
            this.cmdClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClear.UseVisualStyleBackColor = true;
            this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
            // 
            // cmdExit
            // 
            this.cmdExit.Font = new System.Drawing.Font("細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmdExit.Image = ((System.Drawing.Image)(resources.GetObject("cmdExit.Image")));
            this.cmdExit.Location = new System.Drawing.Point(663, 32);
            this.cmdExit.Margin = new System.Windows.Forms.Padding(4);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(135, 52);
            this.cmdExit.TabIndex = 23;
            this.cmdExit.Text = "離開";
            this.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.cboProgStytle);
            this.GroupBox3.Controls.Add(this.label4);
            this.GroupBox3.Controls.Add(this.txtPassWord);
            this.GroupBox3.Controls.Add(this.txtUserName);
            this.GroupBox3.Controls.Add(this.txtUserID);
            this.GroupBox3.Controls.Add(this.Label3);
            this.GroupBox3.Controls.Add(this.Label2);
            this.GroupBox3.Controls.Add(this.Label1);
            this.GroupBox3.Location = new System.Drawing.Point(262, 32);
            this.GroupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.GroupBox3.Size = new System.Drawing.Size(672, 267);
            this.GroupBox3.TabIndex = 15;
            this.GroupBox3.TabStop = false;
            // 
            // cboProgStytle
            // 
            this.cboProgStytle.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cboProgStytle.FormattingEnabled = true;
            this.cboProgStytle.Location = new System.Drawing.Point(201, 192);
            this.cboProgStytle.Margin = new System.Windows.Forms.Padding(4);
            this.cboProgStytle.Name = "cboProgStytle";
            this.cboProgStytle.Size = new System.Drawing.Size(307, 32);
            this.cboProgStytle.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(60, 192);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 24);
            this.label4.TabIndex = 7;
            this.label4.Text = "權限等級";
            // 
            // txtPassWord
            // 
            this.txtPassWord.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtPassWord.Location = new System.Drawing.Point(201, 136);
            this.txtPassWord.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.Size = new System.Drawing.Size(307, 36);
            this.txtPassWord.TabIndex = 6;
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtUserName.Location = new System.Drawing.Point(201, 82);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(4);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(307, 36);
            this.txtUserName.TabIndex = 5;
            // 
            // txtUserID
            // 
            this.txtUserID.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtUserID.Location = new System.Drawing.Point(201, 33);
            this.txtUserID.Margin = new System.Windows.Forms.Padding(4);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(307, 36);
            this.txtUserID.TabIndex = 4;
            this.txtUserID.TextChanged += new System.EventHandler(this.txtUserID_TextChanged);
            this.txtUserID.Leave += new System.EventHandler(this.txtUserID_Leave);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label3.Location = new System.Drawing.Point(60, 136);
            this.Label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(130, 24);
            this.Label3.TabIndex = 2;
            this.Label3.Text = "使用者密碼";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label2.Location = new System.Drawing.Point(60, 87);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(130, 24);
            this.Label2.TabIndex = 1;
            this.Label2.Text = "使用者名稱";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label1.Location = new System.Drawing.Point(60, 40);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(130, 24);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "使用者卡號";
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.RdUnlock);
            this.GroupBox2.Controls.Add(this.RdDel);
            this.GroupBox2.Controls.Add(this.RdMo);
            this.GroupBox2.Controls.Add(this.RdAdd);
            this.GroupBox2.Location = new System.Drawing.Point(124, 32);
            this.GroupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.GroupBox2.Size = new System.Drawing.Size(129, 267);
            this.GroupBox2.TabIndex = 14;
            this.GroupBox2.TabStop = false;
            // 
            // RdUnlock
            // 
            this.RdUnlock.AutoSize = true;
            this.RdUnlock.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.RdUnlock.Location = new System.Drawing.Point(16, 152);
            this.RdUnlock.Margin = new System.Windows.Forms.Padding(4);
            this.RdUnlock.Name = "RdUnlock";
            this.RdUnlock.Size = new System.Drawing.Size(83, 28);
            this.RdUnlock.TabIndex = 3;
            this.RdUnlock.TabStop = true;
            this.RdUnlock.Text = "解鎖";
            this.RdUnlock.UseVisualStyleBackColor = true;
            // 
            // RdDel
            // 
            this.RdDel.AutoSize = true;
            this.RdDel.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.RdDel.Location = new System.Drawing.Point(16, 114);
            this.RdDel.Margin = new System.Windows.Forms.Padding(4);
            this.RdDel.Name = "RdDel";
            this.RdDel.Size = new System.Drawing.Size(83, 28);
            this.RdDel.TabIndex = 2;
            this.RdDel.TabStop = true;
            this.RdDel.Text = "刪除";
            this.RdDel.UseVisualStyleBackColor = true;
            // 
            // RdMo
            // 
            this.RdMo.AutoSize = true;
            this.RdMo.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.RdMo.Location = new System.Drawing.Point(16, 76);
            this.RdMo.Margin = new System.Windows.Forms.Padding(4);
            this.RdMo.Name = "RdMo";
            this.RdMo.Size = new System.Drawing.Size(83, 28);
            this.RdMo.TabIndex = 1;
            this.RdMo.TabStop = true;
            this.RdMo.Text = "修改";
            this.RdMo.UseVisualStyleBackColor = true;
            // 
            // RdAdd
            // 
            this.RdAdd.AutoSize = true;
            this.RdAdd.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.RdAdd.Location = new System.Drawing.Point(16, 38);
            this.RdAdd.Margin = new System.Windows.Forms.Padding(4);
            this.RdAdd.Name = "RdAdd";
            this.RdAdd.Size = new System.Drawing.Size(83, 28);
            this.RdAdd.TabIndex = 0;
            this.RdAdd.TabStop = true;
            this.RdAdd.Text = "新增";
            this.RdAdd.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1024F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox5, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.GroupBox1, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 447F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1518, 909);
            this.tableLayoutPanel2.TabIndex = 125;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.Grid1);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox5.Location = new System.Drawing.Point(251, 481);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox5.Size = new System.Drawing.Size(1016, 424);
            this.groupBox5.TabIndex = 126;
            this.groupBox5.TabStop = false;
            // 
            // Grid1
            // 
            this.Grid1.AllowUserToAddRows = false;
            this.Grid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grid1.Location = new System.Drawing.Point(4, 28);
            this.Grid1.Margin = new System.Windows.Forms.Padding(4);
            this.Grid1.Name = "Grid1";
            this.Grid1.RowTemplate.Height = 24;
            this.Grid1.Size = new System.Drawing.Size(1008, 392);
            this.Grid1.TabIndex = 3;
            // 
            // frm_USER
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1518, 909);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_USER";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "使用者資料維護";
            this.Load += new System.EventHandler(this.frm_USER_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox4.ResumeLayout(false);
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.GroupBox GroupBox4;
        internal System.Windows.Forms.Button cmdStart;
        internal System.Windows.Forms.Button cmdClear;
        internal System.Windows.Forms.Button cmdExit;
        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.TextBox txtPassWord;
        internal System.Windows.Forms.TextBox txtUserName;
        internal System.Windows.Forms.TextBox txtUserID;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.RadioButton RdDel;
        internal System.Windows.Forms.RadioButton RdMo;
        internal System.Windows.Forms.RadioButton RdAdd;
        private System.Windows.Forms.ComboBox cboProgStytle;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        internal System.Windows.Forms.GroupBox groupBox5;
        internal System.Windows.Forms.DataGridView Grid1;
        internal System.Windows.Forms.Button cmdExport;
        internal System.Windows.Forms.RadioButton RdUnlock;
    }
}