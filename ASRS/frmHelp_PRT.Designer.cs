namespace ASRS
{
    partial class frmHelp_PRT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHelp_PRT));
            this.grpTrace = new System.Windows.Forms.GroupBox();
            this.cmdQuit = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.txtCmdPrt = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblLocID = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblCmdSno = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.grpTrace.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpTrace
            // 
            this.grpTrace.BackColor = System.Drawing.Color.Silver;
            this.grpTrace.Controls.Add(this.cmdQuit);
            this.grpTrace.Controls.Add(this.cmdOK);
            this.grpTrace.Controls.Add(this.txtCmdPrt);
            this.grpTrace.Controls.Add(this.label9);
            this.grpTrace.Controls.Add(this.lblLocID);
            this.grpTrace.Controls.Add(this.label7);
            this.grpTrace.Controls.Add(this.lblCmdSno);
            this.grpTrace.Controls.Add(this.label4);
            this.grpTrace.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.grpTrace.Location = new System.Drawing.Point(1, 3);
            this.grpTrace.Name = "grpTrace";
            this.grpTrace.Size = new System.Drawing.Size(224, 180);
            this.grpTrace.TabIndex = 41;
            this.grpTrace.TabStop = false;
            // 
            // cmdQuit
            // 
            this.cmdQuit.Font = new System.Drawing.Font("MingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmdQuit.Image = ((System.Drawing.Image)(resources.GetObject("cmdQuit.Image")));
            this.cmdQuit.Location = new System.Drawing.Point(107, 135);
            this.cmdQuit.Name = "cmdQuit";
            this.cmdQuit.Size = new System.Drawing.Size(90, 37);
            this.cmdQuit.TabIndex = 103;
            this.cmdQuit.Text = "取消";
            this.cmdQuit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdQuit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdQuit.UseVisualStyleBackColor = true;
            this.cmdQuit.Click += new System.EventHandler(this.cmdQuit_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Font = new System.Drawing.Font("MingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmdOK.Image = ((System.Drawing.Image)(resources.GetObject("cmdOK.Image")));
            this.cmdOK.Location = new System.Drawing.Point(11, 134);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(90, 36);
            this.cmdOK.TabIndex = 102;
            this.cmdOK.Text = "確定";
            this.cmdOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // txtCmdPrt
            // 
            this.txtCmdPrt.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCmdPrt.Location = new System.Drawing.Point(84, 76);
            this.txtCmdPrt.Name = "txtCmdPrt";
            this.txtCmdPrt.Size = new System.Drawing.Size(96, 27);
            this.txtCmdPrt.TabIndex = 36;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label9.Location = new System.Drawing.Point(6, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 16);
            this.label9.TabIndex = 34;
            this.label9.Text = "命令順序";
            // 
            // lblLocID
            // 
            this.lblLocID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblLocID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLocID.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblLocID.Location = new System.Drawing.Point(84, 45);
            this.lblLocID.Name = "lblLocID";
            this.lblLocID.Size = new System.Drawing.Size(96, 21);
            this.lblLocID.TabIndex = 33;
            this.lblLocID.Text = "00000";
            this.lblLocID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(22, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 16);
            this.label7.TabIndex = 32;
            this.label7.Text = "料盤ID";
            // 
            // lblCmdSno
            // 
            this.lblCmdSno.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblCmdSno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCmdSno.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblCmdSno.Location = new System.Drawing.Point(84, 16);
            this.lblCmdSno.Name = "lblCmdSno";
            this.lblCmdSno.Size = new System.Drawing.Size(96, 21);
            this.lblCmdSno.TabIndex = 11;
            this.lblCmdSno.Text = "00000";
            this.lblCmdSno.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(6, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "命令序號";
            // 
            // frmHelp_PRT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(227, 191);
            this.Controls.Add(this.grpTrace);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmHelp_PRT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改命令順序";
            this.Load += new System.EventHandler(this.frmHelp_PRT_Load);
            this.grpTrace.ResumeLayout(false);
            this.grpTrace.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox grpTrace;
        internal System.Windows.Forms.Button cmdQuit;
        internal System.Windows.Forms.Button cmdOK;
        internal System.Windows.Forms.TextBox txtCmdPrt;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.Label lblLocID;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label lblCmdSno;
        internal System.Windows.Forms.Label label4;
    }
}