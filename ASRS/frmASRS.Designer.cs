namespace ASRS
{
    partial class frmASRS
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmASRS));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("設定作業");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("查詢作業");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("維護作業");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("盤點作業");
            this.mnuMainMenu = new System.Windows.Forms.MenuStrip();
            this.mniIOBOUND = new System.Windows.Forms.ToolStripMenuItem();
            this.mniQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.mniMAINTAIN = new System.Windows.Forms.ToolStripMenuItem();
            this.mniCycle = new System.Windows.Forms.ToolStripMenuItem();
            this.mniSchedule = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsUser = new System.Windows.Forms.ToolStrip();
            this.tsbShowMenu = new System.Windows.Forms.ToolStripButton();
            this.tsbS2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbS_LogOut = new System.Windows.Forms.ToolStripButton();
            this.tsbS_ChgPwd = new System.Windows.Forms.ToolStripButton();
            this.stsTaskbar = new System.Windows.Forms.StatusStrip();
            this.tsl1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsl2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslLoginUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslDateTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.trvMenu = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.mnuMainMenu.SuspendLayout();
            this.tlsUser.SuspendLayout();
            this.stsTaskbar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMainMenu
            // 
            this.mnuMainMenu.BackColor = System.Drawing.Color.LightSteelBlue;
            this.mnuMainMenu.Font = new System.Drawing.Font("細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.mnuMainMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.mnuMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniIOBOUND,
            this.mniQuery,
            this.mniMAINTAIN,
            this.mniCycle,
            this.mniSchedule});
            this.mnuMainMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMainMenu.Name = "mnuMainMenu";
            this.mnuMainMenu.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.mnuMainMenu.Size = new System.Drawing.Size(1407, 34);
            this.mnuMainMenu.TabIndex = 1;
            this.mnuMainMenu.Text = "menuStrip1";
            // 
            // mniIOBOUND
            // 
            this.mniIOBOUND.Name = "mniIOBOUND";
            this.mniIOBOUND.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.P)));
            this.mniIOBOUND.Size = new System.Drawing.Size(118, 28);
            this.mniIOBOUND.Tag = "";
            this.mniIOBOUND.Text = "設定作業";
            this.mniIOBOUND.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mniIOBOUND_DropDownItemClicked);
            // 
            // mniQuery
            // 
            this.mniQuery.Name = "mniQuery";
            this.mniQuery.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Q)));
            this.mniQuery.Size = new System.Drawing.Size(118, 28);
            this.mniQuery.Text = "查詢作業";
            this.mniQuery.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mniQuery_DropDownItemClicked);
            this.mniQuery.Click += new System.EventHandler(this.mniQuery_Click);
            // 
            // mniMAINTAIN
            // 
            this.mniMAINTAIN.Name = "mniMAINTAIN";
            this.mniMAINTAIN.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.M)));
            this.mniMAINTAIN.Size = new System.Drawing.Size(118, 28);
            this.mniMAINTAIN.Text = "維護作業";
            this.mniMAINTAIN.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mniMAINTAIN_DropDownItemClicked);
            // 
            // mniCycle
            // 
            this.mniCycle.Name = "mniCycle";
            this.mniCycle.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.mniCycle.Size = new System.Drawing.Size(118, 28);
            this.mniCycle.Text = "盤點作業";
            this.mniCycle.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mniCycle_DropDownItemClicked);
            this.mniCycle.Click += new System.EventHandler(this.mniCycle_Click);
            // 
            // mniSchedule
            // 
            this.mniSchedule.Name = "mniSchedule";
            this.mniSchedule.Size = new System.Drawing.Size(118, 28);
            this.mniSchedule.Text = "儲位重整";
            this.mniSchedule.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mniSchedule_DropDownItemClicked);
            this.mniSchedule.Click += new System.EventHandler(this.mniSchedule_Click);
            // 
            // tlsUser
            // 
            this.tlsUser.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.tlsUser.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tlsUser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbShowMenu,
            this.tsbS2,
            this.tsbS_LogOut,
            this.tsbS_ChgPwd});
            this.tlsUser.Location = new System.Drawing.Point(0, 34);
            this.tlsUser.Name = "tlsUser";
            this.tlsUser.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.tlsUser.Size = new System.Drawing.Size(1407, 30);
            this.tlsUser.TabIndex = 2;
            this.tlsUser.Text = "toolStrip1";
            // 
            // tsbShowMenu
            // 
            this.tsbShowMenu.CheckOnClick = true;
            this.tsbShowMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbShowMenu.Image = ((System.Drawing.Image)(resources.GetObject("tsbShowMenu.Image")));
            this.tsbShowMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbShowMenu.Name = "tsbShowMenu";
            this.tsbShowMenu.Size = new System.Drawing.Size(24, 27);
            this.tsbShowMenu.ToolTipText = "自動隱藏";
            this.tsbShowMenu.CheckedChanged += new System.EventHandler(this.tsbShowMenu_CheckedChanged);
            this.tsbShowMenu.Click += new System.EventHandler(this.tsbShowMenu_Click);
            // 
            // tsbS2
            // 
            this.tsbS2.Name = "tsbS2";
            this.tsbS2.Size = new System.Drawing.Size(6, 30);
            // 
            // tsbS_LogOut
            // 
            this.tsbS_LogOut.Image = ((System.Drawing.Image)(resources.GetObject("tsbS_LogOut.Image")));
            this.tsbS_LogOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbS_LogOut.Name = "tsbS_LogOut";
            this.tsbS_LogOut.Size = new System.Drawing.Size(70, 27);
            this.tsbS_LogOut.Text = "登出";
            this.tsbS_LogOut.Click += new System.EventHandler(this.tsbS_LogOut_Click);
            // 
            // tsbS_ChgPwd
            // 
            this.tsbS_ChgPwd.Image = ((System.Drawing.Image)(resources.GetObject("tsbS_ChgPwd.Image")));
            this.tsbS_ChgPwd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbS_ChgPwd.Name = "tsbS_ChgPwd";
            this.tsbS_ChgPwd.Size = new System.Drawing.Size(106, 27);
            this.tsbS_ChgPwd.Text = "密碼修改";
            this.tsbS_ChgPwd.Click += new System.EventHandler(this.tsbS_ChgPwd_Click);
            // 
            // stsTaskbar
            // 
            this.stsTaskbar.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.stsTaskbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsl1,
            this.tsl2,
            this.tslLoginUser,
            this.tslVersion,
            this.tslDateTime});
            this.stsTaskbar.Location = new System.Drawing.Point(0, 1015);
            this.stsTaskbar.Name = "stsTaskbar";
            this.stsTaskbar.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.stsTaskbar.Size = new System.Drawing.Size(1407, 32);
            this.stsTaskbar.TabIndex = 3;
            this.stsTaskbar.Text = "statusStrip1";
            // 
            // tsl1
            // 
            this.tsl1.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.tsl1.Name = "tsl1";
            this.tsl1.Size = new System.Drawing.Size(4, 27);
            // 
            // tsl2
            // 
            this.tsl2.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.tsl2.Name = "tsl2";
            this.tsl2.Size = new System.Drawing.Size(1308, 27);
            this.tsl2.Spring = true;
            // 
            // tslLoginUser
            // 
            this.tslLoginUser.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tslLoginUser.Name = "tslLoginUser";
            this.tslLoginUser.Size = new System.Drawing.Size(4, 27);
            // 
            // tslVersion
            // 
            this.tslVersion.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tslVersion.Name = "tslVersion";
            this.tslVersion.Size = new System.Drawing.Size(68, 27);
            this.tslVersion.Text = "V.0.1.9";
            // 
            // tslDateTime
            // 
            this.tslDateTime.Name = "tslDateTime";
            this.tslDateTime.Size = new System.Drawing.Size(0, 27);
            // 
            // trvMenu
            // 
            this.trvMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvMenu.Font = new System.Drawing.Font("細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.trvMenu.Location = new System.Drawing.Point(0, 0);
            this.trvMenu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.trvMenu.Name = "trvMenu";
            treeNode1.Name = "IO";
            treeNode1.Text = "設定作業";
            treeNode2.Name = "QUERY";
            treeNode2.Text = "查詢作業";
            treeNode3.Name = "MAINTENANCE";
            treeNode3.Text = "維護作業";
            treeNode4.Name = "CYCLE";
            treeNode4.Text = "盤點作業";
            this.trvMenu.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            this.trvMenu.Size = new System.Drawing.Size(330, 951);
            this.trvMenu.TabIndex = 103;
            this.trvMenu.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvMenu_AfterSelect);
            this.trvMenu.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.trvMenu_NodeMouseDoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.trvMenu);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 64);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(330, 951);
            this.panel1.TabIndex = 104;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmASRS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1407, 1047);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.stsTaskbar);
            this.Controls.Add(this.tlsUser);
            this.Controls.Add(this.mnuMainMenu);
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.mnuMainMenu;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmASRS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AS/RS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MaximumSizeChanged += new System.EventHandler(this.frmASRS_MaximumSizeChanged);
            this.Load += new System.EventHandler(this.frmASRS_Load);
            this.mnuMainMenu.ResumeLayout(false);
            this.mnuMainMenu.PerformLayout();
            this.tlsUser.ResumeLayout(false);
            this.tlsUser.PerformLayout();
            this.stsTaskbar.ResumeLayout(false);
            this.stsTaskbar.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMainMenu;
        private System.Windows.Forms.ToolStripMenuItem mniIOBOUND;
        private System.Windows.Forms.ToolStripMenuItem mniCycle;
        private System.Windows.Forms.ToolStripMenuItem mniMAINTAIN;
        private System.Windows.Forms.ToolStripMenuItem mniQuery;
        private System.Windows.Forms.ToolStrip tlsUser;
        private System.Windows.Forms.ToolStripButton tsbShowMenu;
        private System.Windows.Forms.ToolStripSeparator tsbS2;
        private System.Windows.Forms.StatusStrip stsTaskbar;
        private System.Windows.Forms.ToolStripStatusLabel tsl1;
        private System.Windows.Forms.ToolStripStatusLabel tsl2;
        private System.Windows.Forms.ToolStripStatusLabel tslLoginUser;
        private System.Windows.Forms.ToolStripStatusLabel tslVersion;
        private System.Windows.Forms.ToolStripStatusLabel tslDateTime;
        private System.Windows.Forms.ToolStripButton tsbS_LogOut;
        private System.Windows.Forms.TreeView trvMenu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripButton tsbS_ChgPwd;
        private System.Windows.Forms.ToolStripMenuItem mniSchedule;
    }
}

