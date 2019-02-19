namespace ASRS
{
    partial class frm_LOC_MAINTAIN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_LOC_MAINTAIN));
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.Grid1 = new System.Windows.Forms.DataGridView();
            this.GroupBox5 = new System.Windows.Forms.GroupBox();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.Label5 = new System.Windows.Forms.Label();
            this.txtMLoc = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtAvail = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.cboLocSts = new System.Windows.Forms.ComboBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtLocID = new System.Windows.Forms.TextBox();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.cmdEnd = new System.Windows.Forms.Button();
            this.cmdQuery = new System.Windows.Forms.Button();
            this.cmdClear = new System.Windows.Forms.Button();
            this.txtLoc = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtLotNo = new System.Windows.Forms.TextBox();
            this.btnUpd_Loc = new System.Windows.Forms.Button();
            this.GroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).BeginInit();
            this.GroupBox5.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.Grid1);
            this.GroupBox3.Location = new System.Drawing.Point(12, 215);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(981, 381);
            this.GroupBox3.TabIndex = 39;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "明細";
            // 
            // Grid1
            // 
            this.Grid1.AllowUserToAddRows = false;
            this.Grid1.AllowUserToDeleteRows = false;
            this.Grid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid1.Location = new System.Drawing.Point(6, 21);
            this.Grid1.Name = "Grid1";
            this.Grid1.ReadOnly = true;
            this.Grid1.RowTemplate.Height = 24;
            this.Grid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grid1.Size = new System.Drawing.Size(969, 354);
            this.Grid1.TabIndex = 2;
            this.Grid1.TabStop = false;
            // 
            // GroupBox5
            // 
            this.GroupBox5.Controls.Add(this.btnUpd_Loc);
            this.GroupBox5.Controls.Add(this.btnDel);
            this.GroupBox5.Controls.Add(this.btnAdd);
            this.GroupBox5.Controls.Add(this.Label5);
            this.GroupBox5.Controls.Add(this.txtMLoc);
            this.GroupBox5.Controls.Add(this.btnUpdate);
            this.GroupBox5.Controls.Add(this.txtAvail);
            this.GroupBox5.Controls.Add(this.Label4);
            this.GroupBox5.Controls.Add(this.cboLocSts);
            this.GroupBox5.Controls.Add(this.Label2);
            this.GroupBox5.Controls.Add(this.Label1);
            this.GroupBox5.Controls.Add(this.txtLocID);
            this.GroupBox5.Location = new System.Drawing.Point(12, 92);
            this.GroupBox5.Name = "GroupBox5";
            this.GroupBox5.Size = new System.Drawing.Size(980, 105);
            this.GroupBox5.TabIndex = 38;
            this.GroupBox5.TabStop = false;
            this.GroupBox5.Text = "格位資訊";
            // 
            // btnDel
            // 
            this.btnDel.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnDel.Location = new System.Drawing.Point(869, 55);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(105, 35);
            this.btnDel.TabIndex = 15;
            this.btnDel.Text = "刪除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnAdd.Location = new System.Drawing.Point(647, 55);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(105, 35);
            this.btnAdd.TabIndex = 14;
            this.btnAdd.Text = "新增";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label5.Location = new System.Drawing.Point(20, 21);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(59, 13);
            this.Label5.TabIndex = 9;
            this.Label5.Text = "儲位編號";
            // 
            // txtMLoc
            // 
            this.txtMLoc.Enabled = false;
            this.txtMLoc.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtMLoc.Location = new System.Drawing.Point(99, 15);
            this.txtMLoc.Name = "txtMLoc";
            this.txtMLoc.Size = new System.Drawing.Size(161, 23);
            this.txtMLoc.TabIndex = 8;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnUpdate.Location = new System.Drawing.Point(758, 55);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(105, 35);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "修改";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtAvail
            // 
            this.txtAvail.BackColor = System.Drawing.Color.Silver;
            this.txtAvail.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtAvail.Location = new System.Drawing.Point(99, 95);
            this.txtAvail.Name = "txtAvail";
            this.txtAvail.Size = new System.Drawing.Size(160, 23);
            this.txtAvail.TabIndex = 13;
            this.txtAvail.Visible = false;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label4.Location = new System.Drawing.Point(7, 98);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(72, 13);
            this.Label4.TabIndex = 12;
            this.Label4.Text = "空間使用率";
            this.Label4.Visible = false;
            // 
            // cboLocSts
            // 
            this.cboLocSts.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cboLocSts.FormattingEnabled = true;
            this.cboLocSts.Location = new System.Drawing.Point(99, 41);
            this.cboLocSts.Name = "cboLocSts";
            this.cboLocSts.Size = new System.Drawing.Size(160, 21);
            this.cboLocSts.TabIndex = 11;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label2.Location = new System.Drawing.Point(20, 44);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(59, 13);
            this.Label2.TabIndex = 10;
            this.Label2.Text = "儲位狀態";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label1.Location = new System.Drawing.Point(33, 74);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(46, 13);
            this.Label1.TabIndex = 9;
            this.Label1.Text = "料盤ID";
            // 
            // txtLocID
            // 
            this.txtLocID.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtLocID.Location = new System.Drawing.Point(99, 67);
            this.txtLocID.Name = "txtLocID";
            this.txtLocID.Size = new System.Drawing.Size(160, 23);
            this.txtLocID.TabIndex = 8;
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.cmdEnd);
            this.GroupBox2.Controls.Add(this.cmdQuery);
            this.GroupBox2.Controls.Add(this.cmdClear);
            this.GroupBox2.Controls.Add(this.txtLoc);
            this.GroupBox2.Controls.Add(this.Label6);
            this.GroupBox2.Controls.Add(this.Label3);
            this.GroupBox2.Controls.Add(this.txtLotNo);
            this.GroupBox2.Location = new System.Drawing.Point(12, 4);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(980, 73);
            this.GroupBox2.TabIndex = 37;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "查詢條件";
            // 
            // cmdEnd
            // 
            this.cmdEnd.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmdEnd.Image = ((System.Drawing.Image)(resources.GetObject("cmdEnd.Image")));
            this.cmdEnd.Location = new System.Drawing.Point(598, 21);
            this.cmdEnd.Name = "cmdEnd";
            this.cmdEnd.Size = new System.Drawing.Size(109, 35);
            this.cmdEnd.TabIndex = 36;
            this.cmdEnd.Text = "離開";
            this.cmdEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdEnd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdEnd.UseVisualStyleBackColor = true;
            this.cmdEnd.Click += new System.EventHandler(this.cmdEnd_Click);
            // 
            // cmdQuery
            // 
            this.cmdQuery.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmdQuery.Image = ((System.Drawing.Image)(resources.GetObject("cmdQuery.Image")));
            this.cmdQuery.Location = new System.Drawing.Point(368, 21);
            this.cmdQuery.Name = "cmdQuery";
            this.cmdQuery.Size = new System.Drawing.Size(109, 35);
            this.cmdQuery.TabIndex = 34;
            this.cmdQuery.Text = "查詢";
            this.cmdQuery.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdQuery.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdQuery.UseVisualStyleBackColor = true;
            this.cmdQuery.Click += new System.EventHandler(this.cmdQuery_Click);
            // 
            // cmdClear
            // 
            this.cmdClear.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmdClear.Image = ((System.Drawing.Image)(resources.GetObject("cmdClear.Image")));
            this.cmdClear.Location = new System.Drawing.Point(483, 21);
            this.cmdClear.Name = "cmdClear";
            this.cmdClear.Size = new System.Drawing.Size(109, 35);
            this.cmdClear.TabIndex = 35;
            this.cmdClear.Text = "清除畫面";
            this.cmdClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClear.UseVisualStyleBackColor = true;
            // 
            // txtLoc
            // 
            this.txtLoc.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtLoc.Location = new System.Drawing.Point(98, 28);
            this.txtLoc.Name = "txtLoc";
            this.txtLoc.Size = new System.Drawing.Size(161, 23);
            this.txtLoc.TabIndex = 13;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label6.Location = new System.Drawing.Point(20, 28);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(59, 13);
            this.Label6.TabIndex = 12;
            this.Label6.Text = "儲位編號";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label3.Location = new System.Drawing.Point(725, 33);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(33, 13);
            this.Label3.TabIndex = 11;
            this.Label3.Text = "批號";
            this.Label3.Visible = false;
            // 
            // txtLotNo
            // 
            this.txtLotNo.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtLotNo.Location = new System.Drawing.Point(777, 33);
            this.txtLotNo.Name = "txtLotNo";
            this.txtLotNo.Size = new System.Drawing.Size(161, 23);
            this.txtLotNo.TabIndex = 10;
            this.txtLotNo.Visible = false;
            // 
            // btnUpd_Loc
            // 
            this.btnUpd_Loc.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnUpd_Loc.Location = new System.Drawing.Point(266, 15);
            this.btnUpd_Loc.Name = "btnUpd_Loc";
            this.btnUpd_Loc.Size = new System.Drawing.Size(105, 35);
            this.btnUpd_Loc.TabIndex = 16;
            this.btnUpd_Loc.Text = "更新";
            this.btnUpd_Loc.UseVisualStyleBackColor = true;
            this.btnUpd_Loc.Click += new System.EventHandler(this.btnUpd_Loc_Click);
            // 
            // frm_LOC_MAINTAIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1012, 606);
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.GroupBox5);
            this.Controls.Add(this.GroupBox2);
            this.Name = "frm_LOC_MAINTAIN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "儲位資料維護";
            this.Load += new System.EventHandler(this.frm_LOC_MAINTAIN_Load);
            this.GroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).EndInit();
            this.GroupBox5.ResumeLayout(false);
            this.GroupBox5.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.DataGridView Grid1;
        internal System.Windows.Forms.GroupBox GroupBox5;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.TextBox txtMLoc;
        internal System.Windows.Forms.Button btnUpdate;
        internal System.Windows.Forms.TextBox txtAvail;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.ComboBox cboLocSts;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txtLocID;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.Button cmdEnd;
        internal System.Windows.Forms.Button cmdQuery;
        internal System.Windows.Forms.Button cmdClear;
        internal System.Windows.Forms.TextBox txtLoc;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txtLotNo;
        internal System.Windows.Forms.Button btnDel;
        internal System.Windows.Forms.Button btnAdd;
        internal System.Windows.Forms.Button btnUpd_Loc;
    }
}