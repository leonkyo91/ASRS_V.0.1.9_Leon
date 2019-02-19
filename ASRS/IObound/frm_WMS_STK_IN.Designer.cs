namespace ASRS
{
    partial class frm_WMS_STK_IN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_WMS_STK_IN));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnFunC = new System.Windows.Forms.Button();
            this.btnFunB = new System.Windows.Forms.Button();
            this.btnFunA = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.btnFunC);
            this.groupBox1.Controls.Add(this.btnFunB);
            this.groupBox1.Controls.Add(this.btnFunA);
            this.groupBox1.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox1.Location = new System.Drawing.Point(214, 94);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(584, 417);
            this.groupBox1.TabIndex = 122;
            this.groupBox1.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Location = new System.Drawing.Point(185, 365);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(232, 38);
            this.btnExit.TabIndex = 155;
            this.btnExit.Text = " 離開";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnFunC
            // 
            this.btnFunC.Font = new System.Drawing.Font("DFKai-SB", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnFunC.Location = new System.Drawing.Point(185, 138);
            this.btnFunC.Name = "btnFunC";
            this.btnFunC.Size = new System.Drawing.Size(232, 70);
            this.btnFunC.TabIndex = 154;
            this.btnFunC.Text = "工作站口入庫確認\r\n";
            this.btnFunC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFunC.UseVisualStyleBackColor = true;
            this.btnFunC.Click += new System.EventHandler(this.btnFunC_Click);
            // 
            // btnFunB
            // 
            this.btnFunB.Font = new System.Drawing.Font("DFKai-SB", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnFunB.Location = new System.Drawing.Point(429, 138);
            this.btnFunB.Name = "btnFunB";
            this.btnFunB.Size = new System.Drawing.Size(232, 70);
            this.btnFunB.TabIndex = 153;
            this.btnFunB.Text = "建議儲位(料盒)出庫\r\n黑扁盒\r\n";
            this.btnFunB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFunB.UseVisualStyleBackColor = true;
            this.btnFunB.Visible = false;
            this.btnFunB.Click += new System.EventHandler(this.btnFunB_Click);
            // 
            // btnFunA
            // 
            this.btnFunA.Font = new System.Drawing.Font("DFKai-SB", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnFunA.Location = new System.Drawing.Point(185, 61);
            this.btnFunA.Name = "btnFunA";
            this.btnFunA.Size = new System.Drawing.Size(232, 70);
            this.btnFunA.TabIndex = 152;
            this.btnFunA.Text = "建議儲位(料盒)出庫";
            this.btnFunA.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFunA.UseVisualStyleBackColor = true;
            this.btnFunA.Click += new System.EventHandler(this.btnFunA_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 590F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 423F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1012, 606);
            this.tableLayoutPanel1.TabIndex = 123;
            // 
            // frm_WMS_STK_IN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1012, 606);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frm_WMS_STK_IN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frm_WMS_STK_IN_Load);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Button btnFunC;
        internal System.Windows.Forms.Button btnFunB;
        internal System.Windows.Forms.Button btnFunA;
        internal System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}