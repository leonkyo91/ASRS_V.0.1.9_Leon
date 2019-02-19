namespace ASRS
{
    partial class frm_ASRS_OFFLINE_OUT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ASRS_OFFLINE_OUT));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnExecute = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.btnCls = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboStnNo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.Grid1 = new System.Windows.Forms.DataGridView();
            this.tmpGrid2 = new System.Windows.Forms.DataGridView();
            this.tmpGrid1 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmpGrid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmpGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.btnExecute);
            this.groupBox1.Controls.Add(this.btnQuery);
            this.groupBox1.Controls.Add(this.btnCls);
            this.groupBox1.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox1.Location = new System.Drawing.Point(7, -1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(988, 68);
            this.groupBox1.TabIndex = 123;
            this.groupBox1.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Location = new System.Drawing.Point(636, 21);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(106, 38);
            this.btnExit.TabIndex = 107;
            this.btnExit.Text = " 離開";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnExecute
            // 
            this.btnExecute.Font = new System.Drawing.Font("MingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnExecute.Image = ((System.Drawing.Image)(resources.GetObject("btnExecute.Image")));
            this.btnExecute.Location = new System.Drawing.Point(410, 22);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(106, 37);
            this.btnExecute.TabIndex = 106;
            this.btnExecute.Text = " 執行";
            this.btnExecute.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExecute.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Font = new System.Drawing.Font("MingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnQuery.Image = ((System.Drawing.Image)(resources.GetObject("btnQuery.Image")));
            this.btnQuery.Location = new System.Drawing.Point(6, 22);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(179, 37);
            this.btnQuery.TabIndex = 105;
            this.btnQuery.Text = "無帳入庫資料查詢";
            this.btnQuery.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuery.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnCls
            // 
            this.btnCls.Font = new System.Drawing.Font("MingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnCls.Image = ((System.Drawing.Image)(resources.GetObject("btnCls.Image")));
            this.btnCls.Location = new System.Drawing.Point(522, 22);
            this.btnCls.Name = "btnCls";
            this.btnCls.Size = new System.Drawing.Size(108, 37);
            this.btnCls.TabIndex = 103;
            this.btnCls.Text = " 清除畫面";
            this.btnCls.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCls.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCls.UseVisualStyleBackColor = true;
            this.btnCls.Click += new System.EventHandler(this.btnCls_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tmpGrid2);
            this.groupBox2.Controls.Add(this.tmpGrid1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cboStnNo);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtReason);
            this.groupBox2.Controls.Add(this.Grid1);
            this.groupBox2.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox2.Location = new System.Drawing.Point(6, 73);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(988, 521);
            this.groupBox2.TabIndex = 124;
            this.groupBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(186, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 151;
            this.label1.Text = "出庫原因";
            // 
            // cboStnNo
            // 
            this.cboStnNo.BackColor = System.Drawing.Color.White;
            this.cboStnNo.FormattingEnabled = true;
            this.cboStnNo.Location = new System.Drawing.Point(52, 16);
            this.cboStnNo.Name = "cboStnNo";
            this.cboStnNo.Size = new System.Drawing.Size(113, 21);
            this.cboStnNo.TabIndex = 150;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 149;
            this.label4.Text = "站號";
            // 
            // txtReason
            // 
            this.txtReason.BackColor = System.Drawing.Color.White;
            this.txtReason.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtReason.Location = new System.Drawing.Point(251, 14);
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(410, 27);
            this.txtReason.TabIndex = 152;
            // 
            // Grid1
            // 
            this.Grid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid1.Location = new System.Drawing.Point(6, 47);
            this.Grid1.Name = "Grid1";
            this.Grid1.RowTemplate.Height = 24;
            this.Grid1.Size = new System.Drawing.Size(976, 468);
            this.Grid1.TabIndex = 106;
            this.Grid1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid1_CellClick);
            this.Grid1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid1_CellContentClick);
            // 
            // tmpGrid2
            // 
            this.tmpGrid2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tmpGrid2.Location = new System.Drawing.Point(399, 399);
            this.tmpGrid2.Name = "tmpGrid2";
            this.tmpGrid2.RowTemplate.Height = 24;
            this.tmpGrid2.Size = new System.Drawing.Size(452, 90);
            this.tmpGrid2.TabIndex = 154;
            this.tmpGrid2.Visible = false;
            // 
            // tmpGrid1
            // 
            this.tmpGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tmpGrid1.Location = new System.Drawing.Point(411, 292);
            this.tmpGrid1.Name = "tmpGrid1";
            this.tmpGrid1.RowTemplate.Height = 24;
            this.tmpGrid1.Size = new System.Drawing.Size(452, 90);
            this.tmpGrid1.TabIndex = 153;
            this.tmpGrid1.Visible = false;
            // 
            // frm_ASRS_OFFLINE_OUT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1012, 606);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frm_ASRS_OFFLINE_OUT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AWP100 無帳(單)出庫";
            this.Load += new System.EventHandler(this.frm_ASRS_OFFLINE_OUT_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmpGrid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmpGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Button btnQuery;
        internal System.Windows.Forms.Button btnCls;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView Grid1;
        internal System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboStnNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtReason;
        internal System.Windows.Forms.Button btnExit;
        internal System.Windows.Forms.DataGridView tmpGrid2;
        internal System.Windows.Forms.DataGridView tmpGrid1;
    }
}