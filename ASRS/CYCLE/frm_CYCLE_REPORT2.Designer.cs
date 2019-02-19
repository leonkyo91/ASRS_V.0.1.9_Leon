namespace ASRS
{
    partial class frm_CYCLE_REPORT2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_CYCLE_REPORT2));
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.cmdExport = new System.Windows.Forms.Button();
            this.Grid2 = new System.Windows.Forms.DataGridView();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.Grid1 = new System.Windows.Forms.DataGridView();
            this.txtLotNoCount = new System.Windows.Forms.TextBox();
            this.cmdExport2 = new System.Windows.Forms.Button();
            this.Label13 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.btnHelp_Device2 = new System.Windows.Forms.Button();
            this.btnHelp_Device1 = new System.Windows.Forms.Button();
            this.btnHelp_Item2 = new System.Windows.Forms.Button();
            this.btnHelp_Item1 = new System.Windows.Forms.Button();
            this.btnHelp_LotNo2 = new System.Windows.Forms.Button();
            this.btnHelp_LotNo1 = new System.Windows.Forms.Button();
            this.txtDeviceT = new System.Windows.Forms.TextBox();
            this.txtDeviceF = new System.Windows.Forms.TextBox();
            this.GroupBox5 = new System.Windows.Forms.GroupBox();
            this.chkTREANSACTION_DATE2 = new System.Windows.Forms.CheckBox();
            this.dtpDateT = new System.Windows.Forms.DateTimePicker();
            this.dtpDateF = new System.Windows.Forms.DateTimePicker();
            this.Label10 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.txtItemNoT = new System.Windows.Forms.TextBox();
            this.txtItemNoF = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtLotNoT = new System.Windows.Forms.TextBox();
            this.txtLotNoF = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.cmdQuery = new System.Windows.Forms.Button();
            this.cmdClear = new System.Windows.Forms.Button();
            this.cmdExit = new System.Windows.Forms.Button();
            this.GroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid2)).BeginInit();
            this.GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).BeginInit();
            this.GroupBox1.SuspendLayout();
            this.GroupBox5.SuspendLayout();
            this.GroupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox3
            // 
            this.GroupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.GroupBox3.Controls.Add(this.cmdExport);
            this.GroupBox3.Controls.Add(this.Grid2);
            this.GroupBox3.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.GroupBox3.Location = new System.Drawing.Point(12, 90);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(980, 222);
            this.GroupBox3.TabIndex = 19;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "盤點次數";
            // 
            // cmdExport
            // 
            this.cmdExport.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmdExport.Image = ((System.Drawing.Image)(resources.GetObject("cmdExport.Image")));
            this.cmdExport.Location = new System.Drawing.Point(10, 18);
            this.cmdExport.Name = "cmdExport";
            this.cmdExport.Size = new System.Drawing.Size(99, 35);
            this.cmdExport.TabIndex = 73;
            this.cmdExport.Text = "匯出Excel";
            this.cmdExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdExport.UseVisualStyleBackColor = true;
            this.cmdExport.Click += new System.EventHandler(this.cmdExport_Click);
            // 
            // Grid2
            // 
            this.Grid2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid2.Location = new System.Drawing.Point(9, 56);
            this.Grid2.Name = "Grid2";
            this.Grid2.RowTemplate.Height = 24;
            this.Grid2.Size = new System.Drawing.Size(964, 162);
            this.Grid2.TabIndex = 4;
            this.Grid2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid2_CellClick);
            this.Grid2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid2_CellContentClick);
            // 
            // GroupBox2
            // 
            this.GroupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.GroupBox2.Controls.Add(this.Grid1);
            this.GroupBox2.Controls.Add(this.txtLotNoCount);
            this.GroupBox2.Controls.Add(this.cmdExport2);
            this.GroupBox2.Controls.Add(this.Label13);
            this.GroupBox2.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.GroupBox2.Location = new System.Drawing.Point(12, 319);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(980, 275);
            this.GroupBox2.TabIndex = 18;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "盤點清單";
            // 
            // Grid1
            // 
            this.Grid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid1.Location = new System.Drawing.Point(9, 58);
            this.Grid1.Name = "Grid1";
            this.Grid1.RowTemplate.Height = 24;
            this.Grid1.Size = new System.Drawing.Size(964, 211);
            this.Grid1.TabIndex = 76;
            // 
            // txtLotNoCount
            // 
            this.txtLotNoCount.Enabled = false;
            this.txtLotNoCount.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtLotNoCount.Location = new System.Drawing.Point(163, 22);
            this.txtLotNoCount.Name = "txtLotNoCount";
            this.txtLotNoCount.Size = new System.Drawing.Size(74, 23);
            this.txtLotNoCount.TabIndex = 75;
            this.txtLotNoCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmdExport2
            // 
            this.cmdExport2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmdExport2.Image = ((System.Drawing.Image)(resources.GetObject("cmdExport2.Image")));
            this.cmdExport2.Location = new System.Drawing.Point(13, 17);
            this.cmdExport2.Name = "cmdExport2";
            this.cmdExport2.Size = new System.Drawing.Size(99, 35);
            this.cmdExport2.TabIndex = 74;
            this.cmdExport2.Text = "匯出Excel";
            this.cmdExport2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdExport2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdExport2.UseVisualStyleBackColor = true;
            this.cmdExport2.Click += new System.EventHandler(this.cmdExport2_Click);
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label13.Location = new System.Drawing.Point(124, 25);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(33, 13);
            this.Label13.TabIndex = 25;
            this.Label13.Text = "批數";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.btnHelp_Device2);
            this.GroupBox1.Controls.Add(this.btnHelp_Device1);
            this.GroupBox1.Controls.Add(this.btnHelp_Item2);
            this.GroupBox1.Controls.Add(this.btnHelp_Item1);
            this.GroupBox1.Controls.Add(this.btnHelp_LotNo2);
            this.GroupBox1.Controls.Add(this.btnHelp_LotNo1);
            this.GroupBox1.Controls.Add(this.txtDeviceT);
            this.GroupBox1.Controls.Add(this.txtDeviceF);
            this.GroupBox1.Controls.Add(this.GroupBox5);
            this.GroupBox1.Controls.Add(this.Label7);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.txtItemNoT);
            this.GroupBox1.Controls.Add(this.txtItemNoF);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.txtLotNoT);
            this.GroupBox1.Controls.Add(this.txtLotNoF);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Location = new System.Drawing.Point(12, 3);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(679, 81);
            this.GroupBox1.TabIndex = 17;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "查詢條件";
            // 
            // btnHelp_Device2
            // 
            this.btnHelp_Device2.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnHelp_Device2.Location = new System.Drawing.Point(649, 18);
            this.btnHelp_Device2.Name = "btnHelp_Device2";
            this.btnHelp_Device2.Size = new System.Drawing.Size(24, 20);
            this.btnHelp_Device2.TabIndex = 80;
            this.btnHelp_Device2.Text = "...";
            this.btnHelp_Device2.UseVisualStyleBackColor = true;
            this.btnHelp_Device2.Click += new System.EventHandler(this.btnHelp_Device2_Click);
            // 
            // btnHelp_Device1
            // 
            this.btnHelp_Device1.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnHelp_Device1.Location = new System.Drawing.Point(499, 18);
            this.btnHelp_Device1.Name = "btnHelp_Device1";
            this.btnHelp_Device1.Size = new System.Drawing.Size(24, 20);
            this.btnHelp_Device1.TabIndex = 79;
            this.btnHelp_Device1.Text = "...";
            this.btnHelp_Device1.UseVisualStyleBackColor = true;
            this.btnHelp_Device1.Click += new System.EventHandler(this.btnHelp_Device1_Click);
            // 
            // btnHelp_Item2
            // 
            this.btnHelp_Item2.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnHelp_Item2.Location = new System.Drawing.Point(319, 48);
            this.btnHelp_Item2.Name = "btnHelp_Item2";
            this.btnHelp_Item2.Size = new System.Drawing.Size(24, 20);
            this.btnHelp_Item2.TabIndex = 78;
            this.btnHelp_Item2.Text = "...";
            this.btnHelp_Item2.UseVisualStyleBackColor = true;
            this.btnHelp_Item2.Click += new System.EventHandler(this.btnHelp_Item2_Click);
            // 
            // btnHelp_Item1
            // 
            this.btnHelp_Item1.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnHelp_Item1.Location = new System.Drawing.Point(163, 49);
            this.btnHelp_Item1.Name = "btnHelp_Item1";
            this.btnHelp_Item1.Size = new System.Drawing.Size(24, 20);
            this.btnHelp_Item1.TabIndex = 77;
            this.btnHelp_Item1.Text = "...";
            this.btnHelp_Item1.UseVisualStyleBackColor = true;
            this.btnHelp_Item1.Click += new System.EventHandler(this.btnHelp_Item1_Click);
            // 
            // btnHelp_LotNo2
            // 
            this.btnHelp_LotNo2.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnHelp_LotNo2.Location = new System.Drawing.Point(319, 19);
            this.btnHelp_LotNo2.Name = "btnHelp_LotNo2";
            this.btnHelp_LotNo2.Size = new System.Drawing.Size(24, 20);
            this.btnHelp_LotNo2.TabIndex = 76;
            this.btnHelp_LotNo2.Text = "...";
            this.btnHelp_LotNo2.UseVisualStyleBackColor = true;
            this.btnHelp_LotNo2.Click += new System.EventHandler(this.btnHelp_LotNo2_Click);
            // 
            // btnHelp_LotNo1
            // 
            this.btnHelp_LotNo1.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnHelp_LotNo1.Location = new System.Drawing.Point(163, 19);
            this.btnHelp_LotNo1.Name = "btnHelp_LotNo1";
            this.btnHelp_LotNo1.Size = new System.Drawing.Size(24, 20);
            this.btnHelp_LotNo1.TabIndex = 75;
            this.btnHelp_LotNo1.Text = "...";
            this.btnHelp_LotNo1.UseVisualStyleBackColor = true;
            this.btnHelp_LotNo1.Click += new System.EventHandler(this.btnHelp_LotNo1_Click);
            // 
            // txtDeviceT
            // 
            this.txtDeviceT.BackColor = System.Drawing.Color.White;
            this.txtDeviceT.Location = new System.Drawing.Point(551, 18);
            this.txtDeviceT.Name = "txtDeviceT";
            this.txtDeviceT.Size = new System.Drawing.Size(92, 22);
            this.txtDeviceT.TabIndex = 11;
            this.txtDeviceT.Tag = "";
            // 
            // txtDeviceF
            // 
            this.txtDeviceF.BackColor = System.Drawing.Color.White;
            this.txtDeviceF.Location = new System.Drawing.Point(398, 18);
            this.txtDeviceF.Name = "txtDeviceF";
            this.txtDeviceF.Size = new System.Drawing.Size(95, 22);
            this.txtDeviceF.TabIndex = 10;
            this.txtDeviceF.Tag = "";
            // 
            // GroupBox5
            // 
            this.GroupBox5.Controls.Add(this.chkTREANSACTION_DATE2);
            this.GroupBox5.Controls.Add(this.dtpDateT);
            this.GroupBox5.Controls.Add(this.dtpDateF);
            this.GroupBox5.Controls.Add(this.Label10);
            this.GroupBox5.Location = new System.Drawing.Point(356, 37);
            this.GroupBox5.Name = "GroupBox5";
            this.GroupBox5.Size = new System.Drawing.Size(317, 32);
            this.GroupBox5.TabIndex = 74;
            this.GroupBox5.TabStop = false;
            // 
            // chkTREANSACTION_DATE2
            // 
            this.chkTREANSACTION_DATE2.AutoSize = true;
            this.chkTREANSACTION_DATE2.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.chkTREANSACTION_DATE2.Location = new System.Drawing.Point(2, 14);
            this.chkTREANSACTION_DATE2.Name = "chkTREANSACTION_DATE2";
            this.chkTREANSACTION_DATE2.Size = new System.Drawing.Size(78, 17);
            this.chkTREANSACTION_DATE2.TabIndex = 74;
            this.chkTREANSACTION_DATE2.Text = "收料日期";
            this.chkTREANSACTION_DATE2.UseVisualStyleBackColor = true;
            // 
            // dtpDateT
            // 
            this.dtpDateT.CustomFormat = "yyyy/MM/dd";
            this.dtpDateT.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateT.Location = new System.Drawing.Point(214, 10);
            this.dtpDateT.Name = "dtpDateT";
            this.dtpDateT.Size = new System.Drawing.Size(100, 22);
            this.dtpDateT.TabIndex = 73;
            // 
            // dtpDateF
            // 
            this.dtpDateF.CustomFormat = "yyyy/MM/dd";
            this.dtpDateF.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateF.Location = new System.Drawing.Point(84, 10);
            this.dtpDateF.Name = "dtpDateF";
            this.dtpDateF.Size = new System.Drawing.Size(100, 22);
            this.dtpDateF.TabIndex = 72;
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label10.Location = new System.Drawing.Point(187, 12);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(24, 16);
            this.Label10.TabIndex = 71;
            this.Label10.Text = "～";
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label7.Location = new System.Drawing.Point(529, 20);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(24, 16);
            this.Label7.TabIndex = 12;
            this.Label7.Text = "～";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label5.Location = new System.Drawing.Point(356, 22);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(40, 13);
            this.Label5.TabIndex = 8;
            this.Label5.Text = "Device";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label4.Location = new System.Drawing.Point(193, 47);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(24, 16);
            this.Label4.TabIndex = 7;
            this.Label4.Text = "～";
            // 
            // txtItemNoT
            // 
            this.txtItemNoT.BackColor = System.Drawing.Color.White;
            this.txtItemNoT.Location = new System.Drawing.Point(221, 47);
            this.txtItemNoT.Name = "txtItemNoT";
            this.txtItemNoT.Size = new System.Drawing.Size(92, 22);
            this.txtItemNoT.TabIndex = 6;
            this.txtItemNoT.Tag = "";
            // 
            // txtItemNoF
            // 
            this.txtItemNoF.BackColor = System.Drawing.Color.White;
            this.txtItemNoF.Location = new System.Drawing.Point(62, 47);
            this.txtItemNoF.Name = "txtItemNoF";
            this.txtItemNoF.Size = new System.Drawing.Size(95, 22);
            this.txtItemNoF.TabIndex = 5;
            this.txtItemNoF.Tag = "";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label3.Location = new System.Drawing.Point(6, 53);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(47, 13);
            this.Label3.TabIndex = 4;
            this.Label3.Text = "Item No";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label2.Location = new System.Drawing.Point(193, 17);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(24, 16);
            this.Label2.TabIndex = 3;
            this.Label2.Text = "～";
            // 
            // txtLotNoT
            // 
            this.txtLotNoT.BackColor = System.Drawing.Color.White;
            this.txtLotNoT.Location = new System.Drawing.Point(221, 18);
            this.txtLotNoT.Name = "txtLotNoT";
            this.txtLotNoT.Size = new System.Drawing.Size(92, 22);
            this.txtLotNoT.TabIndex = 2;
            this.txtLotNoT.Tag = "";
            // 
            // txtLotNoF
            // 
            this.txtLotNoF.BackColor = System.Drawing.Color.White;
            this.txtLotNoF.Location = new System.Drawing.Point(62, 18);
            this.txtLotNoF.Name = "txtLotNoF";
            this.txtLotNoF.Size = new System.Drawing.Size(95, 22);
            this.txtLotNoF.TabIndex = 1;
            this.txtLotNoF.Tag = "";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label1.Location = new System.Drawing.Point(12, 23);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(41, 13);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Lot No";
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.cmdQuery);
            this.GroupBox4.Controls.Add(this.cmdClear);
            this.GroupBox4.Controls.Add(this.cmdExit);
            this.GroupBox4.Location = new System.Drawing.Point(697, 3);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(295, 81);
            this.GroupBox4.TabIndex = 20;
            this.GroupBox4.TabStop = false;
            // 
            // cmdQuery
            // 
            this.cmdQuery.Font = new System.Drawing.Font("細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmdQuery.Image = ((System.Drawing.Image)(resources.GetObject("cmdQuery.Image")));
            this.cmdQuery.Location = new System.Drawing.Point(6, 28);
            this.cmdQuery.Name = "cmdQuery";
            this.cmdQuery.Size = new System.Drawing.Size(93, 35);
            this.cmdQuery.TabIndex = 73;
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
            this.cmdClear.Location = new System.Drawing.Point(105, 28);
            this.cmdClear.Name = "cmdClear";
            this.cmdClear.Size = new System.Drawing.Size(100, 35);
            this.cmdClear.TabIndex = 72;
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
            this.cmdExit.Location = new System.Drawing.Point(211, 28);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(77, 35);
            this.cmdExit.TabIndex = 71;
            this.cmdExit.Text = "離開";
            this.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // frm_CYCLE_REPORT2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1012, 606);
            this.Controls.Add(this.GroupBox4);
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.GroupBox1);
            this.Name = "frm_CYCLE_REPORT2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "盤點記錄報表";
            this.Load += new System.EventHandler(this.frm_CYCLE_REPORT2_Load);
            this.GroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid2)).EndInit();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox5.ResumeLayout(false);
            this.GroupBox5.PerformLayout();
            this.GroupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.Button cmdExport;
        internal System.Windows.Forms.DataGridView Grid2;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.TextBox txtLotNoCount;
        internal System.Windows.Forms.Button cmdExport2;
        internal System.Windows.Forms.Label Label13;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Button btnHelp_Device2;
        internal System.Windows.Forms.Button btnHelp_Device1;
        internal System.Windows.Forms.Button btnHelp_Item2;
        internal System.Windows.Forms.Button btnHelp_Item1;
        internal System.Windows.Forms.Button btnHelp_LotNo2;
        internal System.Windows.Forms.Button btnHelp_LotNo1;
        internal System.Windows.Forms.TextBox txtDeviceT;
        internal System.Windows.Forms.TextBox txtDeviceF;
        internal System.Windows.Forms.GroupBox GroupBox5;
        internal System.Windows.Forms.CheckBox chkTREANSACTION_DATE2;
        internal System.Windows.Forms.DateTimePicker dtpDateT;
        internal System.Windows.Forms.DateTimePicker dtpDateF;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TextBox txtItemNoT;
        internal System.Windows.Forms.TextBox txtItemNoF;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txtLotNoT;
        internal System.Windows.Forms.TextBox txtLotNoF;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.GroupBox GroupBox4;
        internal System.Windows.Forms.Button cmdQuery;
        internal System.Windows.Forms.Button cmdClear;
        internal System.Windows.Forms.Button cmdExit;
        internal System.Windows.Forms.DataGridView Grid1;
    }
}