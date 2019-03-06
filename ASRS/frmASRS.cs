//***************************************************************************************
//V.0.1.9	.因應矽品內部管控要求,帳號密碼超過30天,要強制變更密碼
//V.0.1.9	.修正 自動登初設定秒 -> 分, 矽品要求超過7分自動登出			frmASRS.cs, clsTool.cs
//V.0.1.9	.ASRS系統安全性補強(密碼複雜度加強、長度要求、不可同舊密碼)	frmChgPwd.cs, frm_USER.cs
//V.0.1.0   .修正 儲位狀態查詢 點選儲位顯示資料有誤.              		frm_LOC_STS.cs
//          .WMS出庫時, 藍標長度可能大於FOSB ID.增加判斷條件     		frm_WMS_STK_OUT_Receive.cs
//          .修改使用者資料清單,增加匯出功能                    frm_USER.cs
//
//***************************************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Common;


namespace ASRS
{
    
    public partial class frmASRS : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public frmASRS()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void frmASRS_Load(object sender, EventArgs e)
        {
            SubInitASRS();   //Init ASRS System
            //timer1.Enabled = true;
        }

        private void frmASRS_MaximumSizeChanged(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                f.WindowState = FormWindowState.Normal;
                f.WindowState = FormWindowState.Maximized;
            }
        }
        
        #region SubInitASRS() Init ASRS System
        public void SubInitASRS()
        {
            //sct1.SplitterDistance = 0;
            panel1.Width = 220;

            clsParam.SubLoadSysIni();           // 取得ASRS.ini檔資料

            this.Text = clsASRS.gstrTitle;

            try
            {
                #region 開啟資料庫失敗
                if (clsDB.FunOpenDB() == false)     // Open Database
                {
                    clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG);
                    Application.Exit();
                };
                #endregion 開啟資料庫失敗

                SubAsrsSetArea();   //判斷是否加入區域電腦
                SubAsrsLogin();     //登入帳號/密碼
                SubGetAuthoirty();  //設定權限

                clsDB.FunClsDB();
            }
            catch
            { 
            
            }
        }

        private void SubAsrsSetArea()
        {
            clsASRS.gsHostName = System.Net.Dns.GetHostName();              //Host Name
            clsASRS.gsAreaNo = clsASRS.FunGetAreaNo(clsASRS.gsHostName);    //Area No
            string sAreaName = "";

            //clsASRS.gsAreaNo = "";
            if (clsASRS.gsAreaNo == "")
            {
                frmSetPC frm1 = new frmSetPC();
                if (frm1.ShowDialog() != DialogResult.OK)
                {
                    clsDB.FunClsDB();
                    Application.Exit();
                }
                else
                {
                    sAreaName = clsASRS.FunGetAreaName(clsASRS.gsAreaNo);    //Area Name
                    tsl1.Text = clsASRS.gsAreaNo + ":" + sAreaName;
                }
            }
            else
            {
                sAreaName = clsASRS.FunGetAreaName(clsASRS.gsAreaNo);    //Area Name
                tsl1.Text = clsASRS.gsAreaNo + ":" + sAreaName;
            }


        }

        private void SubAsrsLogin()
        {
            tslLoginUser.Text = "";
            clsASRS.gstrLoginUser = "";
            //登入帳號/密碼
            Form frm = new frmLogin();
            if (frm.ShowDialog() != DialogResult.OK)
            {
                clsASRS.gstrLoginUser = "";
                clsDB.FunClsDB();
                Application.Exit();
            }
            else
            {
                string sUserName = clsASRS.FunGetUserName(clsASRS.gstrLoginUser);
                tslLoginUser.Text = clsASRS.gstrLoginUser + "/" + sUserName;
            }
        }

        private void SubMenuCls()
        {
            trvMenu.Nodes.Clear();
            TreeNode trvNode_I = trvMenu.Nodes.Add("IOBOUND", "設定作業");
            TreeNode trvNode_C = trvMenu.Nodes.Add("CYCLE", "盤點作業");
            TreeNode trvNode_Q = trvMenu.Nodes.Add("QUERY", "查詢作業");
            TreeNode trvNode_M = trvMenu.Nodes.Add("MAINTAIN", "維護作業");
            TreeNode trvMode_B = trvMenu.Nodes.Add("SCHEDULE", "儲位重整");
            trvMenu.ExpandAll();            

            mniIOBOUND.DropDownItems.Clear();
            mniCycle.DropDownItems.Clear();
            mniQuery.DropDownItems.Clear();
            mniMAINTAIN.DropDownItems.Clear();
            mniSchedule.DropDownItems.Clear();
        }

        private void SubGetAuthoirty()
        {
            trvMenu.Nodes.Clear();
            TreeNode trvNode_I = trvMenu.Nodes.Add("IOBOUND", "設定作業");
            TreeNode trvNode_Q = trvMenu.Nodes.Add("QUERY", "查詢作業");
            TreeNode trvNode_M = trvMenu.Nodes.Add("MAINTAIN", "維護作業");       
            TreeNode trvNode_C = trvMenu.Nodes.Add("CYCLE", "盤點作業");
            TreeNode trvMode_B = trvMenu.Nodes.Add("SCHEDULE", "儲位重整");

            mniIOBOUND.DropDownItems.Clear();
            mniCycle.DropDownItems.Clear();
            mniQuery.DropDownItems.Clear();
            mniMAINTAIN.DropDownItems.Clear();
            mniSchedule.DropDownItems.Clear();

            
            string strSql = ""; 
            strSql = "SELECT F.PROGSTYLE,P.PROG_ID,P.PROG_NAME_TW,P.PARENT_ID,P.SORT_NO " +
                     "FROM FMSSEC F, PROG_LIST P " +
                     "WHERE F.PROG_ID = P.PROG_ID " +
                     "AND F.PROGSTYLE = '" + clsASRS.gstrLoginAuthority + "' " +
                     "ORDER BY P.PARENT_ID, P.SORT_NO ";

            DbDataReader dbRS = null;
            if (clsDB.FunRsSql(strSql, ref dbRS))
            {
                while (dbRS.Read())
                {
                    string strMenu = "";    Image img = null;
                    //strMenu = "[" + dbRS["PROG_ID"].ToString() + "] " + dbRS["PROG_NAME_TW"].ToString();  
                    strMenu =  dbRS["PROG_NAME_TW"].ToString(); 
                    
                    switch (dbRS["PARENT_ID"].ToString())
                    { 
                        case "IOBOUND":     //入出庫
                            trvNode_I.Nodes.Add(dbRS["PROG_ID"].ToString(), strMenu);
                            
                            mniIOBOUND.DropDownItems.Add(strMenu, img);
                            mniIOBOUND.DropDownItems[mniIOBOUND.DropDownItems.Count - 1].Name = dbRS["PROG_ID"].ToString();
                            break;
                        case "CYCLE":       //出庫 (盤點)
                            trvNode_C.Nodes.Add(dbRS["PROG_ID"].ToString(), strMenu);

                            mniCycle.DropDownItems.Add(strMenu, img);
                            mniCycle.DropDownItems[mniCycle.DropDownItems.Count - 1].Name = dbRS["PROG_ID"].ToString();
                            break;
                        case "QUERY":       //查詢
                            trvNode_Q.Nodes.Add(dbRS["PROG_ID"].ToString(), strMenu);

                            mniQuery.DropDownItems.Add(strMenu, img);
                            mniQuery.DropDownItems[mniQuery.DropDownItems.Count - 1].Name = dbRS["PROG_ID"].ToString();
                            break;

                        case "MAINTAIN":    //維護
                            trvNode_M.Nodes.Add(dbRS["PROG_ID"].ToString(), strMenu);

                            mniMAINTAIN.DropDownItems.Add(strMenu, img);
                            mniMAINTAIN.DropDownItems[mniMAINTAIN.DropDownItems.Count - 1].Name = dbRS["PROG_ID"].ToString();
                            break;

                        case "SCHEDULE":
                            trvMode_B.Nodes.Add(dbRS["PROG_ID"].ToString(), strMenu);

                            mniSchedule.DropDownItems.Add(strMenu, img);
                            mniSchedule.DropDownItems[mniSchedule.DropDownItems.Count - 1].Name = dbRS["PROG_ID"].ToString();
                            break;

                    }   
                }
                dbRS.Close();
            }
            

            //trvMenu.ExpandAll();
        }

        private void SubLogInOut()
        {
            SubMenuCls();                       //Menu Clear
            SubClsForm();

            if (clsDB.FunOpenDB() == false)     // Open Database
            {
                clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG);
                Application.Exit();
            }

            SubAsrsLogin();                     //登入帳號/密碼
            SubGetAuthoirty();                  //Get Authority

            clsDB.FunClsDB();
        }

        #endregion

        #region ToolStripMenuItem Click
        private void mniLogOut_Click(object sender, EventArgs e)
        {
            SubLogInOut();
        }

        private void mniSetArea_Click(object sender, EventArgs e)
        {
            if (clsDB.FunOpenDB() == false)     // Open Database
            {
                clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG);
                return;
            }
            
            clsASRS.gsHostName = System.Net.Dns.GetHostName();              //Host Name

            frmSetPC frm1 = new frmSetPC();
            frm1.ShowDialog();

            string sAreaName = clsASRS.FunGetAreaName(clsASRS.gsAreaNo);    //Area Name
            tsl1.Text = clsASRS.gsAreaNo + ":" + sAreaName;

            clsDB.FunClsDB();
        }

        private void mniChangePwd_Click(object sender, EventArgs e)
        {
            if (clsASRS.gstrLoginUser == "") { return; };

            frmChgPwd frmChgPwd_From = new frmChgPwd();
            frmChgPwd_From.ShowDialog();
        }

        private void mniMAINTAIN_Click(object sender, EventArgs e)
        {

        }

        private void mniMAINTAIN_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            SubCallForm(e.ClickedItem.Name);
        }

        private void mniERP_Click(object sender, EventArgs e)
        {

        }

        private void mniWareHouse_Click(object sender, EventArgs e)
        {

        }

        private void mniQuery_Click(object sender, EventArgs e)
        {

        }

        private void mniQuery_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            SubCallForm(e.ClickedItem.Name);
        }

        private void mniERP_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            SubCallForm(e.ClickedItem.Name);
        }

        private void mniCycle_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            SubCallForm(e.ClickedItem.Name);
        }

        private void mniIOBOUND_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            SubCallForm(e.ClickedItem.Name);
        }

        private void mniWareHouse_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            SubCallForm(e.ClickedItem.Name);
        }

        private void mniSystem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            SubCallForm(e.ClickedItem.Name);
        }

        private void mniSchedule_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            SubCallForm(e.ClickedItem.Name);
        }

        private void mniClosed_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion


        

        private void tsbShowMenu_Click(object sender, EventArgs e)
        {

        }

        private void tsbShowMenu_CheckedChanged(object sender, EventArgs e)
        {
            if (tsbShowMenu.Checked)
            {
                //sct1.SplitterDistance = Math.Max(250, this.Width / 8);
                panel1.Width = 0;
            }
            else
            {
                //sct1.SplitterDistance = 0;
                panel1.Width = 220;
            }
        }        

        private void tsbS_LogOut_Click(object sender, EventArgs e)
        {
            SubLogInOut();
        }

        private void trvMenu_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void trvMenu_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void trvMenu_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Level == 1) //Level=0 : 分類目錄
            {
                SubCallForm(e.Node.Name);                
            }
        }

        private void sct1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            //if (sct1.Panel2.Controls.Count > 0)
            //{
            //    foreach (Control ctl in sct1.Panel2.Controls)
            //    {
            //        if (ctl is Form)
            //        {
            //            Form tmp = (Form)ctl;
            //            //tmp.Visible = false;
            //            //tmp.WindowState = FormWindowState.Normal;   
            //            tmp.Width = sct1.Panel2.Width;
            //            tmp.Height = sct1.Panel2.Height;
            //            //tmp.WindowState = FormWindowState.Maximized;
            //            tmp.TopMost = true;
            //            //tmp.Visible = true;
            //        }
            //    }
            //}
        }

        private void sct1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }







        // Call Form
        private void SubCallForm(string sForm)
        {
            try
            {
                string sFormName = "";

                #region
                switch (sForm)
                {
                    #region 設定作業
                    case "AWP010":
                        sFormName = "frm_ASRS_EMPTY_IN";  break;
                    case "AWP020":
                        sFormName = "frm_ASRS_EMPTY_OUT";  break;
                    case "AWP030":
                        sFormName = "frm_RackToRack"; break;
                    case "AWP090":
                        sFormName = "frm_ASRS_OFFLINE_IN"; break;
                    case "AWP100":
                        sFormName = "frm_ASRS_OFFLINE_OUT"; break;
                    case "AWP120":
                        sFormName = "frm_ASRS_STK_OUT"; break;
                    case "AWP130":
                        sFormName = "frm_WMS_STK_IN"; break;
                    case "AWP140":
                        sFormName = "frm_WMS_STK_OUT"; break;
                    case "AWP150":
                        sFormName = "frm_WMS_CYCLE"; break;
                    case "AWP160":
                        sFormName = "frm_WMS_IQC"; break;
                    case "AWP170":
                        sFormName = "frm_WMS_STK_IN_IQC_Receive"; break;
                    case "AWB010":
                        sFormName = "frm_CYCLE_ADJUST"; break; 
                    case "AWB020":
                        sFormName = "frm_CYCLE_ADJUST_SCHE"; break;
                    case "AWB030":
                        sFormName = "frm_CYCLE_ADJUST_STOP"; break;
                    #endregion

                    #region 查詢作業
                    case "AWQ010":
                        sFormName = "frm_LOC_STS"; break; 
                    case "AWQ020":
                        sFormName = "frm_LOC_DTL"; break; 
                    case "AWQ030":
                        sFormName = "frm_STOCK"; break; 
                    case "AWQ040":
                        sFormName = "frm_CMD"; break; 
                    case "AWQ050":
                        sFormName = "frm_CMD_STN"; break;
                    case "AWQ060":
                        sFormName = "frm_ASRS_LOG"; break; 
                    case "AWQ070":
                        sFormName = "frm_OFFLINE_DATA"; break;
                    case "AWQ080":
                        sFormName = "frm_STOCK_OFFLINE"; break; 
                    case "AWQ090":
                        sFormName = "frm_IQC_DATA"; break; 
                    case "AWQ100":
                        break;
                    case "AWQ110":
                        sFormName = "frm_LOC_R2R"; break;                        
                    #endregion

                    #region 盤點作業
                    case "AWC010":
                        sFormName = "frm_LOC_CYCLE"; break;  
                    case "AWC020":
                        sFormName = "frm_ITEM_CYCLE"; break; 
                    case "AWC030":
                        sFormName = "frm_CYCLE"; break; 
                    case "AWC040":
                        sFormName = "frm_CYCLE_CHECK"; break;
                    case "AWC060":
                        sFormName = "frm_CYCLE_REPORT"; break; 
                    case "AWC070":
                        sFormName = "frm_CYCLE_REPORT2"; break;  
                    #endregion

                    #region 維護作業
                    case "AWM010":
                        sFormName = "frm_LOC_MAINTAIN"; break;
                    case "AWM020":
                        sFormName = "frm_LOC_STS_MAINTAIN"; break; 
                    case "AWM030":
                        sFormName = "frm_CMD_MAINTAIN"; break;
                    case "AWM040":
                        sFormName = "frm_USER"; break; 
                    case "AWM050":
                        sFormName = "frm_AUTHORITY"; break; 
                    case "AWM060":
                        sFormName = "frm_LOC_STYLE"; break; 
                    case "AWM070":
                        sFormName = "frm_WMS_LOC_MAPPING"; break; 
                    case "AWM080":
                        sFormName = "frm_SYSTEM"; break;
                    #endregion
                }

                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frm_WMS_IQC")
                    {

                        f.Close();

                        //return;
                    }
                }
                
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == sFormName)
                    {
                        f.Visible = true;
                        f.Activate();
                        f.WindowState = FormWindowState.Maximized;
                        f.Focus();

                        //f.Close();
                        return;
                    }
                }
                #endregion

                

                switch (sForm)
                {
                    #region 設定作業
                    case "AWP010":
                        frm_ASRS_EMPTY_IN frmP_ASRS_EMPTY_IN = new frm_ASRS_EMPTY_IN(); SubShowForm(frmP_ASRS_EMPTY_IN); break;
                    case "AWP020":
                        frm_ASRS_EMPTY_OUT frmP_ASRS_EMPTY_OUT = new frm_ASRS_EMPTY_OUT(); SubShowForm(frmP_ASRS_EMPTY_OUT); break;
                    case "AWP030":                        
                        frm_RackToRack frmP_RackToRack = new frm_RackToRack(); SubShowForm(frmP_RackToRack); break;
                    case "AWP090":
                        frm_ASRS_OFFLINE_IN frmP_ASRS_OFFLINE_IN = new frm_ASRS_OFFLINE_IN(); SubShowForm(frmP_ASRS_OFFLINE_IN); break;
                    case "AWP100":
                        frm_ASRS_OFFLINE_OUT frmP_ASRS_OFFLINE_OUT = new frm_ASRS_OFFLINE_OUT(); SubShowForm(frmP_ASRS_OFFLINE_OUT); break;
                    case "AWP120":
                        frm_ASRS_STK_OUT frmP_ASRS_STK_OUT = new frm_ASRS_STK_OUT(); SubShowForm(frmP_ASRS_STK_OUT); break;                    
                    case "AWP130":
                        frm_WMS_STK_IN frmP_WMS_STK_IN = new frm_WMS_STK_IN(); SubShowForm(frmP_WMS_STK_IN); break;
                    case "AWP140":
                        frm_WMS_STK_OUT frmP_WMS_STK_OUT = new frm_WMS_STK_OUT(); SubShowForm(frmP_WMS_STK_OUT); break;
                    case "AWP150":
                        frm_WMS_CYCLE frmP_WMS_CYCLE = new frm_WMS_CYCLE(); SubShowForm(frmP_WMS_CYCLE); break;
                    case "AWP160":
                        frm_WMS_IQC frmP_WMS_IQC = new frm_WMS_IQC(); SubShowForm(frmP_WMS_IQC); break;
                    case "AWP170":
                        frm_WMS_STK_IN_IQC_Receive frmP_WMS_STK_IN_IQC_Receive = new frm_WMS_STK_IN_IQC_Receive(); SubShowForm(frmP_WMS_STK_IN_IQC_Receive); break;
                    case "AWB010":
                        frm_CYCLE_ADJUST frmP_CYCLE_ADJUST = new frm_CYCLE_ADJUST(); SubShowForm(frmP_CYCLE_ADJUST); return;
                    case "AWB020":
                        frm_CYCLE_ADJUST_SCHE frmP_CYCLE_ADJUST_SCHE= new frm_CYCLE_ADJUST_SCHE(); SubShowForm(frmP_CYCLE_ADJUST_SCHE); return;
                    case "AWB030":
                        frm_CYCLE_ADJUST_STOP frmP_CYCLE_ADJUST_STOP= new frm_CYCLE_ADJUST_STOP(); SubShowForm(frmP_CYCLE_ADJUST_STOP); return;
                    #endregion

                    #region 查詢作業
                    case "AWQ010":
                        frm_LOC_STS frmP_LOC_STS = new frm_LOC_STS(); SubShowForm(frmP_LOC_STS); break;
                    case "AWQ020":
                        frm_LOC_DTL frmP_LOC_DTL = new frm_LOC_DTL(); SubShowForm(frmP_LOC_DTL); break;
                    case "AWQ030":
                        frm_STOCK frmP_STOCK = new frm_STOCK(); SubShowForm(frmP_STOCK); break;
                    case "AWQ040":
                        frm_CMD frmP_CMD = new frm_CMD(); SubShowForm(frmP_CMD); break;
                    case "AWQ050":
                        frm_CMD_STN frmP_CMD_STN = new frm_CMD_STN(); SubShowForm(frmP_CMD_STN); break;
                    case "AWQ060":
                        frm_ASRS_LOG frmP_ASRS_LOG = new frm_ASRS_LOG(); SubShowForm(frmP_ASRS_LOG); break;
                    case "AWQ070":
                        frm_OFFLINE_DATA frmP_OFFLINE_DATA = new frm_OFFLINE_DATA(); SubShowForm(frmP_OFFLINE_DATA); break;
                    case "AWQ080":
                        frm_STOCK_OFFLINE frmP_STOCK_OFFLINE = new frm_STOCK_OFFLINE(); SubShowForm(frmP_STOCK_OFFLINE); break;
                    case "AWQ090":
                        frm_IQC_DATA frmP_IQC_DATA = new frm_IQC_DATA(); SubShowForm(frmP_IQC_DATA); break;
                    case "AWQ100":
                        break;
                    case "AWQ110":
                        frm_LOC_R2R frmP_LOC_R2R = new frm_LOC_R2R(); SubShowForm(frmP_LOC_R2R); break;
                    #endregion

                    #region 維護作業
                    case "AWM010":
                        frm_LOC_MAINTAIN frmP_LOC_MAINTAIN = new frm_LOC_MAINTAIN(); SubShowForm(frmP_LOC_MAINTAIN); break;
                    case "AWM020":
                        frm_LOC_STS_MAINTAIN frmP_LOC_STS_MAINTAIN = new frm_LOC_STS_MAINTAIN(); SubShowForm(frmP_LOC_STS_MAINTAIN); break;
                    case "AWM030":
                        frm_CMD_MAINTAIN frmP_CMD_MAINTAIN = new frm_CMD_MAINTAIN(); SubShowForm(frmP_CMD_MAINTAIN); break;
                    case "AWM040":
                        frm_USER frmP_USER = new frm_USER(); SubShowForm(frmP_USER); break;
                    case "AWM050":
                        frm_AUTHORITY frmP_AUTHORITY = new frm_AUTHORITY(); SubShowForm(frmP_AUTHORITY); break;
                    case "AWM060":
                        frm_LOC_STYLE frmP_LOC_STYLE = new frm_LOC_STYLE(); SubShowForm(frmP_LOC_STYLE); break;
                    case "AWM070":
                        frm_WMS_LOC_MAPPING frmP_WMS_LOC_MAPPING = new frm_WMS_LOC_MAPPING(); SubShowForm(frmP_WMS_LOC_MAPPING); break;
                    case "AWM080":
                        frm_SYSTEM frmP_SYSTEM = new frm_SYSTEM(); SubShowForm(frmP_SYSTEM); break;
                    #endregion

                    #region 盤點作業
                    case "AWC010":
                        frm_LOC_CYCLE frmP_LOC_CYCLE = new frm_LOC_CYCLE(); SubShowForm(frmP_LOC_CYCLE); break;
                    case "AWC020":
                        frm_ITEM_CYCLE frmP_ITEM_CYCLE = new frm_ITEM_CYCLE(); SubShowForm(frmP_ITEM_CYCLE); break;
                    case "AWC030":
                        frm_CYCLE frmP_CYCLE = new frm_CYCLE(); SubShowForm(frmP_CYCLE); break;
                    case "AWC040":
                        frm_CYCLE_CHECK frmP_CYCLE_CHECK = new frm_CYCLE_CHECK(); SubShowForm(frmP_CYCLE_CHECK); break;
                    case "AWC060":
                        frm_CYCLE_REPORT frmP_CYCLE_REPORT = new frm_CYCLE_REPORT(); SubShowForm(frmP_CYCLE_REPORT); break;
                    case "AWC070":
                        frm_CYCLE_REPORT2 frmP_CYCLE_REPORT2 = new frm_CYCLE_REPORT2(); SubShowForm(frmP_CYCLE_REPORT2); break;
                    #endregion

                    default:
                        //clsMessage.ShowMessage(clsMessage.errSYS.NotOpenProg);
                        break;
                }
            }
            catch (Exception ex)
            {
                //clsMessage.ShowMessage(clsMessage.errSYS.SysErr, ex);
                MessageBox.Show(ex.Message);
            }
        }


        private void SubClsForm()
        {
            try
            {
                foreach (Form f in this.MdiChildren)
                {
                    f.Close();
                }
                
            }
            catch (Exception ex)
            {
                //clsMessage.ShowMessage(clsMessage.errSYS.SysErr, ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void SubShowForm(Form sForm)
        {
            sForm.MdiParent = this;
            //this.sct1.Panel2.Controls.Add(sForm);
            sForm.WindowState = FormWindowState.Maximized;
            sForm.Show();
            //sForm.Width = sct1.Panel2.Width;
            //sForm.Height = sct1.Panel2.Height;
            sForm.Focus();
            //sForm.WindowState = FormWindowState.Normal;
            
        }

        private void mniSystem_Click(object sender, EventArgs e)
        {

        }

        private void mniSys_Click(object sender, EventArgs e)
        {

        }

        int MousePositionX = 0;
        int MousePositionY = 0;
        bool bIsDTime = false;
        string sDTime = "";

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (clsASRS.gstrLoginUser == "") { return; }

            #region 取得滑鼠位置
            if ((MousePositionX == System.Windows.Forms.Cursor.Position.X) &&
                (MousePositionY == System.Windows.Forms.Cursor.Position.Y))
            {
                bIsDTime = true;
            }
            else
            {
                //位置不同,重新計算
                MousePositionX = System.Windows.Forms.Cursor.Position.X;
                MousePositionY = System.Windows.Forms.Cursor.Position.Y;
                bIsDTime = false;
                sDTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
            #endregion

            if (bIsDTime == true)
            {
                if (sDTime == "")
                {
                    sDTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                }
                //V 0.1.9
                //int iTime = clsTool.DateDiff_Seconds(sDTime); // 秒 
                int iTime = clsTool.DateDiff_Minutes(sDTime);   //分

                if (iTime >= 7)
                {
                    timer1.Stop();
                    clsMSG.ShowInformationMsg("已自動斷線，請重新登錄!!");
                    timer1.Start();
                    SubLogInOut();
                }
            }
        }




        public void ShowFormA()
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frm_WMS_STK_OUT_Receive")
                {
                    f.Visible = true;
                    f.Activate();
                    f.WindowState = FormWindowState.Maximized;
                    f.Focus();
                    return;
                }
            }

            frm_WMS_STK_OUT_Receive frmP_WMS_STK_OUT_Receive = new frm_WMS_STK_OUT_Receive();
            frmP_WMS_STK_OUT_Receive.MdiParent = this.MdiParent;

            //MdiParent
            frmP_WMS_STK_OUT_Receive.Show();
            frmP_WMS_STK_OUT_Receive.Focus();
  
        }

        private void tsbS_ChgPwd_Click(object sender, EventArgs e)
        {
            SubMenuCls();                       //Menu Clear
            SubClsForm();

            //密碼修改
            frmChgPwd frmPChgPwd = new frmChgPwd();
            frmPChgPwd.ShowDialog();
            
            if (clsDB.FunOpenDB() == false)     // Open Database
            {
                clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG);
                Application.Exit();
            }

            SubAsrsLogin();                     //登入帳號/密碼
            SubGetAuthoirty();                  //Get Authority

            clsDB.FunClsDB();

        }



        private void mniCycle_Click(object sender, EventArgs e)
        {

        }

        private void mniSchedule_Click(object sender, EventArgs e)
        {

        }
















    }
}
