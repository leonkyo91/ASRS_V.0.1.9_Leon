namespace ASRS
{
    partial class frm_WMS_LOC_MAPPING
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_WMS_LOC_MAPPING));
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.cmdEnd = new System.Windows.Forms.Button();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.Grid1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.cmdStart = new System.Windows.Forms.Button();
            this.txtWMS = new System.Windows.Forms.TextBox();
            this.txtASRS = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.GroupBox5 = new System.Windows.Forms.GroupBox();
            this.rbDel = new System.Windows.Forms.RadioButton();
            this.rbUpdate = new System.Windows.Forms.RadioButton();
            this.rbAdd = new System.Windows.Forms.RadioButton();
            this.GroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).BeginInit();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.GroupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.cmdEnd);
            this.GroupBox3.Controls.Add(this.cmdRefresh);
            this.GroupBox3.Controls.Add(this.Grid1);
            this.GroupBox3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox3.Location = new System.Drawing.Point(12, 12);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(505, 582);
            this.GroupBox3.TabIndex = 21;
            this.GroupBox3.TabStop = false;
            // 
            // cmdEnd
            // 
            this.cmdEnd.Font = new System.Drawing.Font("MingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmdEnd.Image = ((System.Drawing.Image)(resources.GetObject("cmdEnd.Image")));
            this.cmdEnd.Location = new System.Drawing.Point(386, 14);
            this.cmdEnd.Name = "cmdEnd";
            this.cmdEnd.Size = new System.Drawing.Size(109, 35);
            this.cmdEnd.TabIndex = 20;
            this.cmdEnd.Text = "離開";
            this.cmdEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdEnd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdEnd.UseVisualStyleBackColor = true;
            this.cmdEnd.Click += new System.EventHandler(this.cmdEnd_Click);
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.Font = new System.Drawing.Font("MingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmdRefresh.Image = ((System.Drawing.Image)(resources.GetObject("cmdRefresh.Image")));
            this.cmdRefresh.Location = new System.Drawing.Point(271, 12);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(109, 38);
            this.cmdRefresh.TabIndex = 22;
            this.cmdRefresh.Text = "更新";
            this.cmdRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdRefresh.UseVisualStyleBackColor = true;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // Grid1
            // 
            this.Grid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.Grid1.Location = new System.Drawing.Point(10, 55);
            this.Grid1.Name = "Grid1";
            this.Grid1.RowTemplate.Height = 24;
            this.Grid1.Size = new System.Drawing.Size(489, 521);
            this.Grid1.TabIndex = 14;
            this.Grid1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid1_CellClick);
            this.Grid1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid1_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "WMS儲位";
            this.Column1.Name = "Column1";
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "ASRS料盒ID";
            this.Column2.Name = "Column2";
            this.Column2.Width = 150;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.GroupBox2);
            this.GroupBox1.Controls.Add(this.GroupBox5);
            this.GroupBox1.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.GroupBox1.Location = new System.Drawing.Point(523, 12);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(454, 291);
            this.GroupBox1.TabIndex = 24;
            this.GroupBox1.TabStop = false;
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.cmdStart);
            this.GroupBox2.Controls.Add(this.txtWMS);
            this.GroupBox2.Controls.Add(this.txtASRS);
            this.GroupBox2.Controls.Add(this.Label2);
            this.GroupBox2.Controls.Add(this.Label1);
            this.GroupBox2.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.GroupBox2.Location = new System.Drawing.Point(17, 91);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(415, 181);
            this.GroupBox2.TabIndex = 23;
            this.GroupBox2.TabStop = false;
            // 
            // cmdStart
            // 
            this.cmdStart.Font = new System.Drawing.Font("MingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmdStart.Image = ((System.Drawing.Image)(resources.GetObject("cmdStart.Image")));
            this.cmdStart.Location = new System.Drawing.Point(307, 88);
            this.cmdStart.Name = "cmdStart";
            this.cmdStart.Size = new System.Drawing.Size(90, 35);
            this.cmdStart.TabIndex = 50;
            this.cmdStart.Text = "執行";
            this.cmdStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdStart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdStart.UseVisualStyleBackColor = true;
            this.cmdStart.Click += new System.EventHandler(this.cmdStart_Click);
            // 
            // txtWMS
            // 
            this.txtWMS.Font = new System.Drawing.Font("MingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtWMS.Location = new System.Drawing.Point(126, 96);
            this.txtWMS.Name = "txtWMS";
            this.txtWMS.Size = new System.Drawing.Size(175, 27);
            this.txtWMS.TabIndex = 26;
            // 
            // txtASRS
            // 
            this.txtASRS.Font = new System.Drawing.Font("MingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtASRS.Location = new System.Drawing.Point(126, 56);
            this.txtASRS.Name = "txtASRS";
            this.txtASRS.Size = new System.Drawing.Size(175, 27);
            this.txtASRS.TabIndex = 25;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("MingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label2.Location = new System.Drawing.Point(56, 99);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(64, 16);
            this.Label2.TabIndex = 24;
            this.Label2.Text = "WMS儲位";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("MingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label1.Location = new System.Drawing.Point(32, 59);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(88, 16);
            this.Label1.TabIndex = 23;
            this.Label1.Text = "ASRS料盒ID";
            // 
            // GroupBox5
            // 
            this.GroupBox5.Controls.Add(this.rbDel);
            this.GroupBox5.Controls.Add(this.rbUpdate);
            this.GroupBox5.Controls.Add(this.rbAdd);
            this.GroupBox5.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.GroupBox5.Location = new System.Drawing.Point(17, 13);
            this.GroupBox5.Name = "GroupBox5";
            this.GroupBox5.Size = new System.Drawing.Size(415, 72);
            this.GroupBox5.TabIndex = 22;
            this.GroupBox5.TabStop = false;
            // 
            // rbDel
            // 
            this.rbDel.AutoSize = true;
            this.rbDel.Font = new System.Drawing.Font("MingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rbDel.Location = new System.Drawing.Point(261, 31);
            this.rbDel.Name = "rbDel";
            this.rbDel.Size = new System.Drawing.Size(58, 20);
            this.rbDel.TabIndex = 2;
            this.rbDel.Text = "刪除";
            this.rbDel.UseVisualStyleBackColor = true;
            // 
            // rbUpdate
            // 
            this.rbUpdate.AutoSize = true;
            this.rbUpdate.Font = new System.Drawing.Font("MingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rbUpdate.Location = new System.Drawing.Point(172, 31);
            this.rbUpdate.Name = "rbUpdate";
            this.rbUpdate.Size = new System.Drawing.Size(58, 20);
            this.rbUpdate.TabIndex = 1;
            this.rbUpdate.Text = "修改";
            this.rbUpdate.UseVisualStyleBackColor = true;
            // 
            // rbAdd
            // 
            this.rbAdd.AutoSize = true;
            this.rbAdd.Checked = true;
            this.rbAdd.Font = new System.Drawing.Font("MingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rbAdd.Location = new System.Drawing.Point(88, 31);
            this.rbAdd.Name = "rbAdd";
            this.rbAdd.Size = new System.Drawing.Size(58, 20);
            this.rbAdd.TabIndex = 0;
            this.rbAdd.TabStop = true;
            this.rbAdd.Text = "新增";
            this.rbAdd.UseVisualStyleBackColor = true;
            // 
            // frm_WMS_LOC_MAPPING
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1012, 606);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.GroupBox3);
            this.Name = "frm_WMS_LOC_MAPPING";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WMS儲位對照表";
            this.Load += new System.EventHandler(this.frm_WMS_LOC_MAPPING_Load);
            this.GroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.GroupBox5.ResumeLayout(false);
            this.GroupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.Button cmdEnd;
        internal System.Windows.Forms.Button cmdRefresh;
        internal System.Windows.Forms.DataGridView Grid1;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.Button cmdStart;
        internal System.Windows.Forms.TextBox txtWMS;
        internal System.Windows.Forms.TextBox txtASRS;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.GroupBox GroupBox5;
        internal System.Windows.Forms.RadioButton rbDel;
        internal System.Windows.Forms.RadioButton rbUpdate;
        internal System.Windows.Forms.RadioButton rbAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}