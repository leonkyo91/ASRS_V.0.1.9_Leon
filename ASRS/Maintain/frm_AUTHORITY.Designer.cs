namespace ASRS
{
    partial class frm_AUTHORITY
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_AUTHORITY));
            this.cboPrivilege = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gpb1 = new System.Windows.Forms.GroupBox();
            this.lsbLeft = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAddAll = new System.Windows.Forms.Button();
            this.btnDelAll = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lsbRight = new System.Windows.Forms.ListBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.cmdExport = new System.Windows.Forms.Button();
            this.gpb1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboPrivilege
            // 
            this.cboPrivilege.BackColor = System.Drawing.Color.LightGreen;
            this.cboPrivilege.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPrivilege.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cboPrivilege.FormattingEnabled = true;
            this.cboPrivilege.Location = new System.Drawing.Point(425, 25);
            this.cboPrivilege.Name = "cboPrivilege";
            this.cboPrivilege.Size = new System.Drawing.Size(166, 24);
            this.cboPrivilege.TabIndex = 123;
            this.cboPrivilege.SelectedIndexChanged += new System.EventHandler(this.cboPrivilege_SelectedIndexChanged);
            this.cboPrivilege.TextChanged += new System.EventHandler(this.cboPrivilege_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(347, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 122;
            this.label3.Text = "權限等級";
            // 
            // gpb1
            // 
            this.gpb1.Controls.Add(this.lsbLeft);
            this.gpb1.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.gpb1.Location = new System.Drawing.Point(29, 69);
            this.gpb1.Name = "gpb1";
            this.gpb1.Size = new System.Drawing.Size(359, 535);
            this.gpb1.TabIndex = 124;
            this.gpb1.TabStop = false;
            this.gpb1.Text = "無 權限程式清單";
            // 
            // lsbLeft
            // 
            this.lsbLeft.FormattingEnabled = true;
            this.lsbLeft.ItemHeight = 16;
            this.lsbLeft.Location = new System.Drawing.Point(6, 26);
            this.lsbLeft.Name = "lsbLeft";
            this.lsbLeft.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lsbLeft.Size = new System.Drawing.Size(346, 500);
            this.lsbLeft.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("MingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnAdd.Location = new System.Drawing.Point(405, 146);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(127, 39);
            this.btnAdd.TabIndex = 125;
            this.btnAdd.Text = "＞";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDel
            // 
            this.btnDel.Font = new System.Drawing.Font("MingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnDel.Location = new System.Drawing.Point(405, 215);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(127, 39);
            this.btnDel.TabIndex = 126;
            this.btnDel.Text = "＜";
            this.btnDel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAddAll
            // 
            this.btnAddAll.Font = new System.Drawing.Font("MingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnAddAll.Location = new System.Drawing.Point(405, 291);
            this.btnAddAll.Name = "btnAddAll";
            this.btnAddAll.Size = new System.Drawing.Size(127, 39);
            this.btnAddAll.TabIndex = 127;
            this.btnAddAll.Text = "＞＞";
            this.btnAddAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddAll.UseVisualStyleBackColor = true;
            this.btnAddAll.Click += new System.EventHandler(this.btnAddAll_Click);
            // 
            // btnDelAll
            // 
            this.btnDelAll.Font = new System.Drawing.Font("MingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnDelAll.Location = new System.Drawing.Point(405, 368);
            this.btnDelAll.Name = "btnDelAll";
            this.btnDelAll.Size = new System.Drawing.Size(127, 39);
            this.btnDelAll.TabIndex = 128;
            this.btnDelAll.Text = "＜＜";
            this.btnDelAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelAll.UseVisualStyleBackColor = true;
            this.btnDelAll.Click += new System.EventHandler(this.btnDelAll_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lsbRight);
            this.groupBox1.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox1.Location = new System.Drawing.Point(553, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(359, 533);
            this.groupBox1.TabIndex = 125;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "權限程式清單";
            // 
            // lsbRight
            // 
            this.lsbRight.FormattingEnabled = true;
            this.lsbRight.ItemHeight = 16;
            this.lsbRight.Location = new System.Drawing.Point(6, 26);
            this.lsbRight.Name = "lsbRight";
            this.lsbRight.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lsbRight.Size = new System.Drawing.Size(346, 500);
            this.lsbRight.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("MingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Location = new System.Drawing.Point(405, 535);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(123, 44);
            this.btnExit.TabIndex = 129;
            this.btnExit.Text = " 離開";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cmdExport
            // 
            this.cmdExport.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmdExport.Image = ((System.Drawing.Image)(resources.GetObject("cmdExport.Image")));
            this.cmdExport.Location = new System.Drawing.Point(612, 19);
            this.cmdExport.Name = "cmdExport";
            this.cmdExport.Size = new System.Drawing.Size(99, 35);
            this.cmdExport.TabIndex = 130;
            this.cmdExport.Text = "匯出Excel";
            this.cmdExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdExport.UseVisualStyleBackColor = true;
            this.cmdExport.Click += new System.EventHandler(this.cmdExport_Click);
            // 
            // frm_AUTHORITY
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1012, 606);
            this.Controls.Add(this.cmdExport);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDelAll);
            this.Controls.Add(this.btnAddAll);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.gpb1);
            this.Controls.Add(this.cboPrivilege);
            this.Controls.Add(this.label3);
            this.Name = "frm_AUTHORITY";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "權限資料維護";
            this.Load += new System.EventHandler(this.frm_AUTHORITY_Load);
            this.gpb1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboPrivilege;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gpb1;
        private System.Windows.Forms.ListBox lsbLeft;
        internal System.Windows.Forms.Button btnAdd;
        internal System.Windows.Forms.Button btnDel;
        internal System.Windows.Forms.Button btnAddAll;
        internal System.Windows.Forms.Button btnDelAll;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lsbRight;
        internal System.Windows.Forms.Button btnExit;
        internal System.Windows.Forms.Button cmdExport;
    }
}