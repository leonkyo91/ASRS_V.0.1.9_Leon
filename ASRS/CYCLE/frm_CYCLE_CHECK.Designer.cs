namespace ASRS
{
    partial class frm_CYCLE_CHECK
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_CYCLE_CHECK));
            this.lblCycle = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.GroupBox6 = new System.Windows.Forms.GroupBox();
            this.txtCycleUser = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.txtScan = new System.Windows.Forms.TextBox();
            this.lblCmdSno = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.cmdStart = new System.Windows.Forms.Button();
            this.cmdClear = new System.Windows.Forms.Button();
            this.cmdExit = new System.Windows.Forms.Button();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.Grid1 = new System.Windows.Forms.DataGridView();
            this.GroupBox5 = new System.Windows.Forms.GroupBox();
            this.txtQty_L = new System.Windows.Forms.NumericUpDown();
            this.lblQty_L = new System.Windows.Forms.Label();
            this.cboResult_L = new System.Windows.Forms.ComboBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.RdBtn_NG_L = new System.Windows.Forms.RadioButton();
            this.RdBtn_Confirm_L = new System.Windows.Forms.RadioButton();
            this.txtLocID = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.GroupBox6.SuspendLayout();
            this.GroupBox4.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).BeginInit();
            this.GroupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQty_L)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCycle
            // 
            this.lblCycle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCycle.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblCycle.Location = new System.Drawing.Point(308, 105);
            this.lblCycle.Name = "lblCycle";
            this.lblCycle.Size = new System.Drawing.Size(194, 22);
            this.lblCycle.TabIndex = 35;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label6.Location = new System.Drawing.Point(230, 105);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(72, 16);
            this.Label6.TabIndex = 34;
            this.Label6.Text = "盤點單號";
            // 
            // GroupBox6
            // 
            this.GroupBox6.Controls.Add(this.txtCycleUser);
            this.GroupBox6.Controls.Add(this.Label4);
            this.GroupBox6.Controls.Add(this.Label7);
            this.GroupBox6.Controls.Add(this.txtScan);
            this.GroupBox6.Location = new System.Drawing.Point(12, 13);
            this.GroupBox6.Name = "GroupBox6";
            this.GroupBox6.Size = new System.Drawing.Size(490, 54);
            this.GroupBox6.TabIndex = 33;
            this.GroupBox6.TabStop = false;
            // 
            // txtCycleUser
            // 
            this.txtCycleUser.BackColor = System.Drawing.Color.Silver;
            this.txtCycleUser.Enabled = false;
            this.txtCycleUser.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtCycleUser.Location = new System.Drawing.Point(343, 20);
            this.txtCycleUser.Name = "txtCycleUser";
            this.txtCycleUser.Size = new System.Drawing.Size(79, 23);
            this.txtCycleUser.TabIndex = 44;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label4.Location = new System.Drawing.Point(21, 22);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(68, 16);
            this.Label4.TabIndex = 28;
            this.Label4.Text = "掃瞄中...";
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label7.Location = new System.Drawing.Point(265, 22);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(72, 16);
            this.Label7.TabIndex = 26;
            this.Label7.Text = "盤點人員";
            // 
            // txtScan
            // 
            this.txtScan.BackColor = System.Drawing.Color.White;
            this.txtScan.Location = new System.Drawing.Point(94, 21);
            this.txtScan.Name = "txtScan";
            this.txtScan.Size = new System.Drawing.Size(146, 22);
            this.txtScan.TabIndex = 0;
            this.txtScan.Tag = "";
            this.txtScan.TextChanged += new System.EventHandler(this.txtScan_TextChanged);
            this.txtScan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtScan_KeyPress);
            // 
            // lblCmdSno
            // 
            this.lblCmdSno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCmdSno.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblCmdSno.Location = new System.Drawing.Point(108, 104);
            this.lblCmdSno.Name = "lblCmdSno";
            this.lblCmdSno.Size = new System.Drawing.Size(101, 22);
            this.lblCmdSno.TabIndex = 32;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label5.Location = new System.Drawing.Point(28, 104);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(72, 16);
            this.Label5.TabIndex = 31;
            this.Label5.Text = "命令序號";
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.cmdStart);
            this.GroupBox4.Controls.Add(this.cmdClear);
            this.GroupBox4.Controls.Add(this.cmdExit);
            this.GroupBox4.Location = new System.Drawing.Point(667, 12);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(325, 54);
            this.GroupBox4.TabIndex = 30;
            this.GroupBox4.TabStop = false;
            // 
            // cmdStart
            // 
            this.cmdStart.Font = new System.Drawing.Font("MingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmdStart.Image = ((System.Drawing.Image)(resources.GetObject("cmdStart.Image")));
            this.cmdStart.Location = new System.Drawing.Point(6, 13);
            this.cmdStart.Name = "cmdStart";
            this.cmdStart.Size = new System.Drawing.Size(103, 35);
            this.cmdStart.TabIndex = 50;
            this.cmdStart.Text = "盤點確認";
            this.cmdStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdStart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdStart.UseVisualStyleBackColor = true;
            this.cmdStart.Click += new System.EventHandler(this.cmdStart_Click);
            // 
            // cmdClear
            // 
            this.cmdClear.Font = new System.Drawing.Font("MingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmdClear.Image = ((System.Drawing.Image)(resources.GetObject("cmdClear.Image")));
            this.cmdClear.Location = new System.Drawing.Point(115, 13);
            this.cmdClear.Name = "cmdClear";
            this.cmdClear.Size = new System.Drawing.Size(108, 35);
            this.cmdClear.TabIndex = 9;
            this.cmdClear.Text = "清除畫面";
            this.cmdClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClear.UseVisualStyleBackColor = true;
            this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
            // 
            // cmdExit
            // 
            this.cmdExit.Font = new System.Drawing.Font("MingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmdExit.Image = ((System.Drawing.Image)(resources.GetObject("cmdExit.Image")));
            this.cmdExit.Location = new System.Drawing.Point(229, 13);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(90, 35);
            this.cmdExit.TabIndex = 7;
            this.cmdExit.Text = "離開";
            this.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // GroupBox2
            // 
            this.GroupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.GroupBox2.Controls.Add(this.Grid1);
            this.GroupBox2.Controls.Add(this.GroupBox5);
            this.GroupBox2.Controls.Add(this.txtLocID);
            this.GroupBox2.Controls.Add(this.Label1);
            this.GroupBox2.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.GroupBox2.Location = new System.Drawing.Point(12, 130);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(980, 263);
            this.GroupBox2.TabIndex = 29;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "FOSB資訊";
            // 
            // Grid1
            // 
            this.Grid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Grid1.Location = new System.Drawing.Point(6, 37);
            this.Grid1.Name = "Grid1";
            this.Grid1.RowTemplate.Height = 24;
            this.Grid1.Size = new System.Drawing.Size(955, 167);
            this.Grid1.TabIndex = 53;
            this.Grid1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid1_CellClick);
            this.Grid1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid1_CellContentClick);
            // 
            // GroupBox5
            // 
            this.GroupBox5.Controls.Add(this.txtQty_L);
            this.GroupBox5.Controls.Add(this.lblQty_L);
            this.GroupBox5.Controls.Add(this.cboResult_L);
            this.GroupBox5.Controls.Add(this.Label8);
            this.GroupBox5.Controls.Add(this.RdBtn_NG_L);
            this.GroupBox5.Controls.Add(this.RdBtn_Confirm_L);
            this.GroupBox5.Location = new System.Drawing.Point(19, 210);
            this.GroupBox5.Name = "GroupBox5";
            this.GroupBox5.Size = new System.Drawing.Size(553, 47);
            this.GroupBox5.TabIndex = 14;
            this.GroupBox5.TabStop = false;
            this.GroupBox5.Text = "盤點結果";
            // 
            // txtQty_L
            // 
            this.txtQty_L.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtQty_L.Location = new System.Drawing.Point(439, 18);
            this.txtQty_L.Name = "txtQty_L";
            this.txtQty_L.Size = new System.Drawing.Size(78, 23);
            this.txtQty_L.TabIndex = 52;
            this.txtQty_L.ValueChanged += new System.EventHandler(this.txtQty_L_ValueChanged);
            // 
            // lblQty_L
            // 
            this.lblQty_L.AutoSize = true;
            this.lblQty_L.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblQty_L.Location = new System.Drawing.Point(400, 22);
            this.lblQty_L.Name = "lblQty_L";
            this.lblQty_L.Size = new System.Drawing.Size(33, 13);
            this.lblQty_L.TabIndex = 14;
            this.lblQty_L.Text = "數量";
            // 
            // cboResult_L
            // 
            this.cboResult_L.FormattingEnabled = true;
            this.cboResult_L.Location = new System.Drawing.Point(202, 20);
            this.cboResult_L.Name = "cboResult_L";
            this.cboResult_L.Size = new System.Drawing.Size(180, 21);
            this.cboResult_L.TabIndex = 13;
            this.cboResult_L.SelectedIndexChanged += new System.EventHandler(this.cboResult_L_SelectedIndexChanged);
            this.cboResult_L.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboResult_L_KeyPress);
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label8.Location = new System.Drawing.Point(163, 24);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(33, 13);
            this.Label8.TabIndex = 11;
            this.Label8.Text = "原因";
            // 
            // RdBtn_NG_L
            // 
            this.RdBtn_NG_L.AutoSize = true;
            this.RdBtn_NG_L.Location = new System.Drawing.Point(93, 22);
            this.RdBtn_NG_L.Name = "RdBtn_NG_L";
            this.RdBtn_NG_L.Size = new System.Drawing.Size(64, 17);
            this.RdBtn_NG_L.TabIndex = 1;
            this.RdBtn_NG_L.TabStop = true;
            this.RdBtn_NG_L.Text = "不相符";
            this.RdBtn_NG_L.UseVisualStyleBackColor = true;
            this.RdBtn_NG_L.CheckedChanged += new System.EventHandler(this.RdBtn_NG_L_CheckedChanged);
            // 
            // RdBtn_Confirm_L
            // 
            this.RdBtn_Confirm_L.AutoSize = true;
            this.RdBtn_Confirm_L.Location = new System.Drawing.Point(19, 22);
            this.RdBtn_Confirm_L.Name = "RdBtn_Confirm_L";
            this.RdBtn_Confirm_L.Size = new System.Drawing.Size(51, 17);
            this.RdBtn_Confirm_L.TabIndex = 0;
            this.RdBtn_Confirm_L.TabStop = true;
            this.RdBtn_Confirm_L.Text = "相符";
            this.RdBtn_Confirm_L.UseVisualStyleBackColor = true;
            this.RdBtn_Confirm_L.CheckedChanged += new System.EventHandler(this.RdBtn_Confirm_L_CheckedChanged);
            // 
            // txtLocID
            // 
            this.txtLocID.BackColor = System.Drawing.Color.White;
            this.txtLocID.Enabled = false;
            this.txtLocID.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtLocID.Location = new System.Drawing.Point(99, 13);
            this.txtLocID.Name = "txtLocID";
            this.txtLocID.Size = new System.Drawing.Size(217, 23);
            this.txtLocID.TabIndex = 1;
            this.txtLocID.Tag = "";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label1.Location = new System.Drawing.Point(21, 19);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(59, 13);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "料盤條碼";
            // 
            // frm_CYCLE_CHECK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1012, 606);
            this.Controls.Add(this.lblCycle);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.GroupBox6);
            this.Controls.Add(this.lblCmdSno);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.GroupBox4);
            this.Controls.Add(this.GroupBox2);
            this.Name = "frm_CYCLE_CHECK";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "盤點確認";
            this.Load += new System.EventHandler(this.frm_CYCLE_CHECK_Load);
            this.GroupBox6.ResumeLayout(false);
            this.GroupBox6.PerformLayout();
            this.GroupBox4.ResumeLayout(false);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).EndInit();
            this.GroupBox5.ResumeLayout(false);
            this.GroupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQty_L)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblCycle;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.GroupBox GroupBox6;
        internal System.Windows.Forms.TextBox txtCycleUser;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.TextBox txtScan;
        internal System.Windows.Forms.Label lblCmdSno;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.GroupBox GroupBox4;
        internal System.Windows.Forms.Button cmdStart;
        internal System.Windows.Forms.Button cmdClear;
        internal System.Windows.Forms.Button cmdExit;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.GroupBox GroupBox5;
        internal System.Windows.Forms.NumericUpDown txtQty_L;
        internal System.Windows.Forms.Label lblQty_L;
        internal System.Windows.Forms.ComboBox cboResult_L;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.RadioButton RdBtn_NG_L;
        internal System.Windows.Forms.RadioButton RdBtn_Confirm_L;
        internal System.Windows.Forms.TextBox txtLocID;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.DataGridView Grid1;
    }
}