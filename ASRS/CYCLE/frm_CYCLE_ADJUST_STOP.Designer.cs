namespace ASRS
{
    partial class frm_CYCLE_ADJUST_STOP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_CYCLE_ADJUST_STOP));
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.txtCycle_Type = new System.Windows.Forms.TextBox();
            this.txtTypeNo = new System.Windows.Forms.TextBox();
            this.btnMClose = new System.Windows.Forms.Button();
            this.btnMStart = new System.Windows.Forms.Button();
            this.btnMStop = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtType = new System.Windows.Forms.TextBox();
            this.txtCycle_TypeName = new System.Windows.Forms.TextBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.btnQuery = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.Grid1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtState = new System.Windows.Forms.TextBox();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox13.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.txtCycle_Type);
            this.groupBox13.Controls.Add(this.txtTypeNo);
            this.groupBox13.Controls.Add(this.btnMClose);
            this.groupBox13.Controls.Add(this.btnMStart);
            this.groupBox13.Controls.Add(this.btnMStop);
            this.groupBox13.Controls.Add(this.btnExit);
            this.groupBox13.Controls.Add(this.label1);
            this.groupBox13.Controls.Add(this.txtType);
            this.groupBox13.Controls.Add(this.txtCycle_TypeName);
            this.groupBox13.Controls.Add(this.Label7);
            this.groupBox13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox13.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox13.Location = new System.Drawing.Point(3, 3);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(1006, 103);
            this.groupBox13.TabIndex = 128;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "目前執行重整類型";
            // 
            // txtCycle_Type
            // 
            this.txtCycle_Type.BackColor = System.Drawing.Color.Silver;
            this.txtCycle_Type.Location = new System.Drawing.Point(734, 59);
            this.txtCycle_Type.Name = "txtCycle_Type";
            this.txtCycle_Type.ReadOnly = true;
            this.txtCycle_Type.Size = new System.Drawing.Size(64, 22);
            this.txtCycle_Type.TabIndex = 135;
            this.txtCycle_Type.Tag = "";
            this.txtCycle_Type.Visible = false;
            // 
            // txtTypeNo
            // 
            this.txtTypeNo.BackColor = System.Drawing.Color.Silver;
            this.txtTypeNo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTypeNo.Location = new System.Drawing.Point(734, 26);
            this.txtTypeNo.Name = "txtTypeNo";
            this.txtTypeNo.ReadOnly = true;
            this.txtTypeNo.Size = new System.Drawing.Size(64, 22);
            this.txtTypeNo.TabIndex = 134;
            this.txtTypeNo.Tag = "";
            this.txtTypeNo.Visible = false;
            // 
            // btnMClose
            // 
            this.btnMClose.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnMClose.Location = new System.Drawing.Point(251, 62);
            this.btnMClose.Name = "btnMClose";
            this.btnMClose.Size = new System.Drawing.Size(105, 35);
            this.btnMClose.TabIndex = 133;
            this.btnMClose.Text = "取消執行";
            this.btnMClose.UseVisualStyleBackColor = true;
            this.btnMClose.Click += new System.EventHandler(this.btnMClose_Click);
            // 
            // btnMStart
            // 
            this.btnMStart.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnMStart.Location = new System.Drawing.Point(140, 62);
            this.btnMStart.Name = "btnMStart";
            this.btnMStart.Size = new System.Drawing.Size(105, 35);
            this.btnMStart.TabIndex = 132;
            this.btnMStart.Text = "手動啓動";
            this.btnMStart.UseVisualStyleBackColor = true;
            this.btnMStart.Click += new System.EventHandler(this.btnMStart_Click);
            // 
            // btnMStop
            // 
            this.btnMStop.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnMStop.Location = new System.Drawing.Point(29, 62);
            this.btnMStop.Name = "btnMStop";
            this.btnMStop.Size = new System.Drawing.Size(105, 35);
            this.btnMStop.TabIndex = 131;
            this.btnMStop.Text = "手動暫停";
            this.btnMStop.UseVisualStyleBackColor = true;
            this.btnMStop.Click += new System.EventHandler(this.btnMStop_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Location = new System.Drawing.Point(362, 60);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(106, 38);
            this.btnExit.TabIndex = 130;
            this.btnExit.Text = " 離開";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(259, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 16);
            this.label1.TabIndex = 30;
            this.label1.Text = "Type";
            // 
            // txtType
            // 
            this.txtType.BackColor = System.Drawing.Color.Silver;
            this.txtType.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtType.Location = new System.Drawing.Point(305, 26);
            this.txtType.Name = "txtType";
            this.txtType.ReadOnly = true;
            this.txtType.Size = new System.Drawing.Size(423, 22);
            this.txtType.TabIndex = 29;
            this.txtType.Tag = "";
            // 
            // txtCycle_TypeName
            // 
            this.txtCycle_TypeName.BackColor = System.Drawing.Color.Silver;
            this.txtCycle_TypeName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCycle_TypeName.Location = new System.Drawing.Point(113, 26);
            this.txtCycle_TypeName.Name = "txtCycle_TypeName";
            this.txtCycle_TypeName.ReadOnly = true;
            this.txtCycle_TypeName.Size = new System.Drawing.Size(137, 22);
            this.txtCycle_TypeName.TabIndex = 28;
            this.txtCycle_TypeName.Tag = "";
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.Location = new System.Drawing.Point(35, 26);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(72, 16);
            this.Label7.TabIndex = 27;
            this.Label7.Text = "整併項目";
            // 
            // btnQuery
            // 
            this.btnQuery.Font = new System.Drawing.Font("MingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnQuery.Image = ((System.Drawing.Image)(resources.GetObject("btnQuery.Image")));
            this.btnQuery.Location = new System.Drawing.Point(4, 3);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(107, 37);
            this.btnQuery.TabIndex = 128;
            this.btnQuery.Text = "Refresh";
            this.btnQuery.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuery.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 112);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1006, 491);
            this.groupBox1.TabIndex = 129;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FOSB調整狀況進度";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.Grid1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1000, 470);
            this.tableLayoutPanel2.TabIndex = 34;
            // 
            // Grid1
            // 
            this.Grid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grid1.Location = new System.Drawing.Point(3, 53);
            this.Grid1.Name = "Grid1";
            this.Grid1.RowTemplate.Height = 24;
            this.Grid1.Size = new System.Drawing.Size(994, 414);
            this.Grid1.TabIndex = 31;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtState);
            this.panel1.Controls.Add(this.txtQty);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnQuery);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(991, 44);
            this.panel1.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(156, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 27;
            this.label3.Text = "目前狀態";
            // 
            // txtState
            // 
            this.txtState.BackColor = System.Drawing.Color.Silver;
            this.txtState.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtState.ForeColor = System.Drawing.Color.Red;
            this.txtState.Location = new System.Drawing.Point(234, 11);
            this.txtState.Name = "txtState";
            this.txtState.ReadOnly = true;
            this.txtState.Size = new System.Drawing.Size(212, 22);
            this.txtState.TabIndex = 28;
            this.txtState.Tag = "";
            // 
            // txtQty
            // 
            this.txtQty.BackColor = System.Drawing.Color.Silver;
            this.txtQty.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQty.Location = new System.Drawing.Point(560, 10);
            this.txtQty.Name = "txtQty";
            this.txtQty.ReadOnly = true;
            this.txtQty.Size = new System.Drawing.Size(85, 22);
            this.txtQty.TabIndex = 33;
            this.txtQty.Tag = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(466, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 32;
            this.label2.Text = "待執行批數";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox13, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 109F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1012, 606);
            this.tableLayoutPanel1.TabIndex = 130;
            // 
            // frm_CYCLE_ADJUST_STOP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1012, 606);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frm_CYCLE_ADJUST_STOP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frm_CYCLE_ADJUST_STOP_Load);
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox groupBox13;
        internal System.Windows.Forms.Button btnExit;
        internal System.Windows.Forms.Button btnQuery;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtType;
        internal System.Windows.Forms.TextBox txtCycle_TypeName;
        internal System.Windows.Forms.Button btnMStart;
        internal System.Windows.Forms.Button btnMStop;
        internal System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.TextBox txtState;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txtQty;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.DataGridView Grid1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        internal System.Windows.Forms.Button btnMClose;
        internal System.Windows.Forms.TextBox txtTypeNo;
        internal System.Windows.Forms.TextBox txtCycle_Type;
    }
}