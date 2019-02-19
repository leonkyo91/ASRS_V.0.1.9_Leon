namespace ASRS
{

    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.lblAuthorize = new System.Windows.Forms.Label();
            this.picUserID = new System.Windows.Forms.PictureBox();
            this.picPassword = new System.Windows.Forms.PictureBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUserID = new System.Windows.Forms.Label();
            this.butLogin = new System.Windows.Forms.Button();
            this.butExit = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.lblProduct = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picUserID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPassword)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAuthorize
            // 
            this.lblAuthorize.AutoSize = true;
            this.lblAuthorize.BackColor = System.Drawing.Color.Transparent;
            this.lblAuthorize.Font = new System.Drawing.Font("PMingLiU", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblAuthorize.Location = new System.Drawing.Point(52, 246);
            this.lblAuthorize.Name = "lblAuthorize";
            this.lblAuthorize.Size = new System.Drawing.Size(332, 12);
            this.lblAuthorize.TabIndex = 46;
            this.lblAuthorize.Text = "Copyright © 2011 Mirle Automation Corporation. All rights reserved.";
            // 
            // picUserID
            // 
            this.picUserID.BackColor = System.Drawing.Color.Transparent;
            this.picUserID.Image = ((System.Drawing.Image)(resources.GetObject("picUserID.Image")));
            this.picUserID.Location = new System.Drawing.Point(323, 99);
            this.picUserID.Name = "picUserID";
            this.picUserID.Size = new System.Drawing.Size(16, 16);
            this.picUserID.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picUserID.TabIndex = 45;
            this.picUserID.TabStop = false;
            // 
            // picPassword
            // 
            this.picPassword.BackColor = System.Drawing.Color.Transparent;
            this.picPassword.Image = ((System.Drawing.Image)(resources.GetObject("picPassword.Image")));
            this.picPassword.Location = new System.Drawing.Point(323, 131);
            this.picPassword.Name = "picPassword";
            this.picPassword.Size = new System.Drawing.Size(16, 16);
            this.picPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picPassword.TabIndex = 44;
            this.picPassword.TabStop = false;
            // 
            // lblPassword
            // 
            this.lblPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblPassword.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblPassword.Location = new System.Drawing.Point(42, 130);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(120, 16);
            this.lblPassword.TabIndex = 43;
            this.lblPassword.Text = "密碼";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUserID
            // 
            this.lblUserID.BackColor = System.Drawing.Color.Transparent;
            this.lblUserID.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblUserID.Location = new System.Drawing.Point(42, 99);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(120, 23);
            this.lblUserID.TabIndex = 42;
            this.lblUserID.Text = "使用者";
            this.lblUserID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butLogin
            // 
            this.butLogin.Font = new System.Drawing.Font("MingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.butLogin.Image = ((System.Drawing.Image)(resources.GetObject("butLogin.Image")));
            this.butLogin.Location = new System.Drawing.Point(129, 180);
            this.butLogin.Name = "butLogin";
            this.butLogin.Size = new System.Drawing.Size(100, 35);
            this.butLogin.TabIndex = 2;
            this.butLogin.Text = "登入";
            this.butLogin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butLogin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.butLogin.UseVisualStyleBackColor = true;
            this.butLogin.Click += new System.EventHandler(this.butLogin_Click);
            // 
            // butExit
            // 
            this.butExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butExit.Font = new System.Drawing.Font("MingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.butExit.Image = ((System.Drawing.Image)(resources.GetObject("butExit.Image")));
            this.butExit.Location = new System.Drawing.Point(258, 180);
            this.butExit.Name = "butExit";
            this.butExit.Size = new System.Drawing.Size(100, 35);
            this.butExit.TabIndex = 3;
            this.butExit.Text = "離開";
            this.butExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.butExit.UseVisualStyleBackColor = true;
            this.butExit.Click += new System.EventHandler(this.butExit_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("MingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtPassword.Location = new System.Drawing.Point(168, 126);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(150, 27);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
            // 
            // txtUserID
            // 
            this.txtUserID.Font = new System.Drawing.Font("MingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtUserID.Location = new System.Drawing.Point(168, 95);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(150, 27);
            this.txtUserID.TabIndex = 0;
            this.txtUserID.TextChanged += new System.EventHandler(this.txtUserID_TextChanged);
            this.txtUserID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUserID_KeyPress);
            // 
            // lblProduct
            // 
            this.lblProduct.BackColor = System.Drawing.Color.Transparent;
            this.lblProduct.Font = new System.Drawing.Font("Tahoma", 27.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)
                            | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProduct.ForeColor = System.Drawing.Color.Black;
            this.lblProduct.Location = new System.Drawing.Point(3, 19);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(427, 45);
            this.lblProduct.TabIndex = 41;
            this.lblProduct.Text = "AS/RS System";
            this.lblProduct.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("PMingLiU", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(41, 230);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(359, 12);
            this.label1.TabIndex = 47;
            this.label1.Text = "___________________________________________________________";
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.butExit;
            this.ClientSize = new System.Drawing.Size(442, 266);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblAuthorize);
            this.Controls.Add(this.picUserID);
            this.Controls.Add(this.picPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUserID);
            this.Controls.Add(this.butLogin);
            this.Controls.Add(this.butExit);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.lblProduct);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登入/登出";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picUserID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPassword)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAuthorize;
        internal System.Windows.Forms.PictureBox picUserID;
        internal System.Windows.Forms.PictureBox picPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUserID;
        internal System.Windows.Forms.Button butLogin;
        internal System.Windows.Forms.Button butExit;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label label1;

    }
}