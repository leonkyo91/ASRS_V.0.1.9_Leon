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
    public partial class frm_WMS_IQC : Form
    {
        #region Grid Parameter
        int iCol_SNO = 0;             
        int iCol_RCVNO = 1;
        int iCol_LOTNO = 2;
        int iCol_PIECE = 3;    
        int iCol_Counts = 4;
        #endregion

        bool bIQC = false;
        string sDTime = "";

        public frm_WMS_IQC()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void frm_WMS_IQC_Load(object sender, EventArgs e)
        {
            GridInit();
            FormInit();
        }

        private void GridInit()
        {
            GridSysInit(ref Grid1);
            GridSetRange(ref Grid1);
        }

        private void GridSysInit(ref DataGridView oGrid)
        {
            try
            {
                //指定 Column 的字體
                oGrid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.WhiteSmoke;
                oGrid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.Black;

                //指定 Row 的字體
                oGrid.RowHeadersDefaultCellStyle.BackColor = System.Drawing.Color.WhiteSmoke;
                oGrid.RowHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                oGrid.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                oGrid.ReadOnly = true;               //不允許修改
                oGrid.AllowUserToAddRows = false;    //不允許使用者從 DataGridView 中增加資料列。
                oGrid.AllowUserToDeleteRows = false; //不允許使用者從 DataGridView 中刪除資料列。 
                oGrid.AllowUserToResizeRows = false; //不允許調整資料列的大小。
                oGrid.MultiSelect = false;           //不允許多選列
                //.SelectionMode = DataGridViewSelectionMode.FullRowSelect                    '選擇整Row方式
                oGrid.SelectionMode = DataGridViewSelectionMode.CellSelect;    //選擇單一Row方式

                oGrid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;  //字體對齊位置
            }
            catch (Exception ex)
            {
                clsMSG.ShowWarningMsg(clsMSG.MSG.SYSTEM_NG + " " + ex.ToString());
            }

        }

        private void GridSetRange(ref DataGridView oGrid)
        {
            oGrid.ColumnCount = iCol_Counts;

            oGrid.Columns[iCol_SNO].Width = 10; oGrid.Columns[iCol_SNO].Name = "WMS SNID"; oGrid.Columns[iCol_SNO].Visible = false;
            oGrid.Columns[iCol_RCVNO].Width = 200; oGrid.Columns[iCol_RCVNO].Name = "收料序號";
            oGrid.Columns[iCol_LOTNO].Width = 200; oGrid.Columns[iCol_LOTNO].Name = "LOT NO";
            oGrid.Columns[iCol_PIECE].Width = 100; oGrid.Columns[iCol_PIECE].Name = "數量";

            int i = 0;
            for (i = 0; i <= oGrid.ColumnCount - 1; i++)
            {
                oGrid.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            oGrid.RowCount = 0; oGrid.RowCount = 1;
        }

        private void FormInit()
        {
            Grid1.RowCount = 0;
            txtIQC_ID.Text = "";
            txtRCVNO.Text = "";
            txtIQC_ID.Select();
            bIQC = false;
            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };
            SubQuery();
            clsDB.FunClsDB();

            
            timer1.Enabled = true;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            //SubSetIQC();
            SubIqcLogin();
        }

        private void SubIqcLogin()
        {
            Array.Resize<string>(ref clsASRS.gsHelpRtnData, 0);

            frm_WMS_IQC_LOGIN frmHelp = new frm_WMS_IQC_LOGIN();
            frmHelp.ShowDialog();
            lblIQCID.Text = clsASRS.gsHelpRtnData[0];

            if (clsASRS.gsHelpRtnData[0] == "")
            {
                //this.Close();
            }
        }

        private void txtIQC_ID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtIQC_ID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                SubSetIQC();
            }
        }

        private void SubSetIQC()
        {
            txtIQC_ID.Text = txtIQC_ID.Text.Trim();
            if (txtIQC_ID.Enabled == true)
            {
                txtIQC_ID.Enabled = false;  bIQC = false; sDTime = "";
                txtRCVNO.Select();
            }
            else
            {
                if (txtIQC_ID.Text == "") { return; }

                txtIQC_ID.Enabled = true; bIQC = true; sDTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                txtRCVNO.Select();
            }
        }




        private void btnExecute_Click(object sender, EventArgs e)
        {
            SubExecute();
        }

        private void txtRCVNO_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRCVNO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                SubExecute();
                txtRCVNO.Text = "";
            }
        }

        private void SubExecute()
        {
            sDTime = System.DateTime.Now.AddSeconds(600).ToString("yyyy-MM-dd HH:mm:ss");
            if (txtRCVNO.Text == "") { return; }

            if (lblIQCID.Text == "")
            {
                clsMSG.ShowWarningMsg("請刷 IQC ID (工號)");
                return;
            }
            
            string strSql = ""; DbDataReader dbRS = null;
            string sLocID = ""; string sLoc = ""; string sGetLocID1 = ""; string sCmdSno = ""; string sRCVNO = "";
            bool bFlag = true;

            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };

            #region 取得料盒ID / 命令序號 / 儲位
            sRCVNO = "";
            strSql = "SELECT * FROM SPIL_IQC ";
            strSql = strSql + "WHERE RCVNO = '" + txtRCVNO.Text + "' ";
            strSql = strSql + "AND STATUS = '0' ";
            if (clsDB.FunRsSql(strSql, ref dbRS))
            {
                while (dbRS.Read())
                {
                    sLocID = dbRS["GROUPID"].ToString();
                    sRCVNO = dbRS["RCVNO"].ToString();
                }
                dbRS.Close();
            }

            #region 判斷 警語"請刷WMS收料序號" / "此WMS收料序號已刷取過!!"
            //當user刷的不是wms收料序號請跳出警語"請刷WMS收料序號" 
            //當USER重複刷WMS收料序號時.請跳出警語"此WMS收料序號已刷取過!!"
            if (sRCVNO == "")
            {
                string sStatus = "";
                strSql = "SELECT * FROM SPIL_IQC ";
                strSql = strSql + "WHERE RCVNO = '" + txtRCVNO.Text + "' ";
                if (clsDB.FunRsSql(strSql, ref dbRS))
                {
                    while (dbRS.Read())
                    {
                        sStatus = dbRS["STATUS"].ToString();
                    }
                    dbRS.Close();
                }

                if (sStatus == "1")
                {
                    clsMSG.ShowWarningMsg("此WMS收料序號已刷取過!!");
                }
                else if (sStatus == "")
                {
                    clsMSG.ShowWarningMsg("請刷WMS收料序號");
                }

                clsDB.FunClsDB();
                return;
            }
            #endregion

            //if (sLocID == "") { clsMSG.ShowErrMsg("系統錯誤!!,讀取不到料盒ID資料!!"); clsDB.FunClsDB(); return; }

            if (sLocID != "")
            {
                #region 系統指派空儲位
                int iCrn = clsASRS.FunGetCraneNoByLocID(sLocID); //由料盒ID取得是那一座Crane
                
                if (clsASRS.FunGetLocN_ByE(iCrn, ref sLoc, ref sGetLocID1, 2) == false)
                {
                    clsMSG.ShowWarningMsg("無合適之空儲位!!"); clsDB.FunClsDB(); return;
                }            
                #endregion

                #region 取得命令序號
                sCmdSno = clsASRS.FunGetCmdSno();
                if (sCmdSno == "")
                {
                    clsMSG.ShowErrMsg("系統錯誤,無命令序號可使用!!");
                    clsDB.FunClsDB(); return;
                }
                #endregion

            }
            #endregion
            
            clsDB.FunCommitCtrl("BEGIN");

            #region 產生空料盒入庫命令
            if (sLocID != "")
            {
                bFlag = FunCreateNewCmdSno(sCmdSno, sLoc, sLocID);
            }
            #endregion

            #region 更新 SPIL_IQC 狀態
            if (bFlag == true)
            {
                strSql = "UPDATE SPIL_IQC SET STATUS = '1', ";
                strSql = strSql + "USER_NAME = '" + lblIQCID.Text + "', ";
                strSql = strSql + "TXN_DATE = '" + clsTool.GetDateTimeForWMS() + "' ";
                strSql = strSql + "WHERE RCVNO = '" + txtRCVNO.Text + "' ";
                strSql = strSql + "AND STATUS = '0' ";
                if (clsDB.FunExecSql(strSql) == false)
                {
                    bFlag = false;
                }
            }
            #endregion

            #region COMMIT/ROLLBACK
            if (bFlag == true)
            {
                clsDB.FunCommitCtrl("COMMIT");
                txtRCVNO.Text = "";
                SubQuery();
                clsMSG.ShowInformationMsg("已簽收完成");
            }
            else
            {
                clsDB.FunCommitCtrl("ROLLBACK");
                clsMSG.ShowWarningMsg(clsMSG.MSG.Msg_Run_Error);
            }
            #endregion

            clsDB.FunClsDB();

            sDTime = System.DateTime.Now.AddSeconds(600).ToString("yyyy-MM-dd HH:mm:ss");
        }

        private bool FunCreateNewCmdSno(string sCmdSno, string sLoc, string sLocID)
        {
            #region 預約儲位
            string sMsg = "";
            //預約儲位為入庫預約
            if (clsASRS.FunSetLocIsPreStkIn(sLoc, "", ref sMsg) == false)
            {
                return false;
            }
            #endregion

            #region 產生命令主檔
            cls_CmdMst aCmdMst = new cls_CmdMst();

            aCmdMst.FunCmdMstClear();   //Clear()
            aCmdMst.CMDSNO = sCmdSno;
            aCmdMst.SNO1 = "1";
            aCmdMst.LOC1 = sLoc;
            aCmdMst.LOCID1 = sLocID;
            aCmdMst.SCAN1 = "Y";    //己確認

            aCmdMst.SNO2 = "";
            aCmdMst.LOC2 = "";
            aCmdMst.LOCID2 = "";
            aCmdMst.SCAN2 = "N";
            aCmdMst.CMDMODE = "1";   //入庫                    

            aCmdMst.CMDSTS = "0";
            aCmdMst.PRT = "5";
            aCmdMst.STNNO = "D04";
            aCmdMst.IOTYP = clsASRS.gsIOTYPE_EmptyIn;

            aCmdMst.AVAIL = "0";  // 彰化廠
            aCmdMst.MIXQTY = "0";   // 彰化廠
            
            aCmdMst.NEWLOC = "";
            aCmdMst.PROGID = clsASRS.gsIOTYPE_EmptyIn_PID;
            aCmdMst.USERID = txtIQC_ID.Text;
            aCmdMst.TRACE = "0";
            aCmdMst.STORAGETYP = "";
            if (aCmdMst.FunInsCmdMst() == false)
            {
                return false;
            }

            #endregion

            return true;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };
            SubQuery();
            clsDB.FunClsDB();
        }

        private void SubQuery()
        {
            string strSql = ""; DbDataReader dbRS = null;

            Grid1.RowCount = 0;
            //lblHelp.Text = "未完成批量";
            //if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };

            strSql = "SELECT * FROM SPIL_IQC WHERE STATUS = '0' ORDER BY SNID ";

            if (clsDB.FunRsSql(strSql, ref dbRS))
            {
                while (dbRS.Read())
                {
                    Grid1.Rows.Add();
                    Grid1.Rows[Grid1.Rows.Count - 1].HeaderCell.Value = "";

                    Grid1[iCol_SNO, Grid1.Rows.Count - 1].Value = dbRS["SNID"].ToString();
                    Grid1[iCol_RCVNO, Grid1.Rows.Count - 1].Value = dbRS["RCVNO"].ToString();
                    Grid1[iCol_LOTNO, Grid1.Rows.Count - 1].Value = dbRS["LOTNO"].ToString();
                    Grid1[iCol_PIECE, Grid1.Rows.Count - 1].Value = dbRS["PIECE"].ToString();                    
                }
                dbRS.Close();
            }

            int iCount = 0;
            strSql = "SELECT COUNT(*) FROM ";
            strSql = strSql + "(SELECT RCVNO FROM SPIL_IQC WHERE STATUS = '0' GROUP BY RCVNO) A ";
            if (clsDB.FunRsSql(strSql, ref dbRS))
            {
                while (dbRS.Read())
                {
                    iCount = clsTool.INT(dbRS[0].ToString());
                }
                dbRS.Close();
            }

            lblHelpQty.Text = iCount.ToString();

        }

        private void Grid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            SubTimer_LogOut();
            timer1.Enabled = true;

            txtRCVNO.Select();



            ////sDTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //timer1.Enabled = false;

            //if (bIQC == true)
            //{
            //    //if (sDTime == "")
            //    //{
            //    sDTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //    //}

            //    int iTime = clsTool.DateDiff_Seconds(sDTime);

            //    if (iTime > 600)
            //    {
            //        bIQC = false; txtIQC_ID.Text = ""; txtIQC_ID.Enabled = false; 
            //        sDTime = "";
            //    }
            //}
            //if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };
            //SubQuery();
            //clsDB.FunClsDB();

            //if (bIQC == true) { txtRCVNO.Select(); } else { txtIQC_ID.Select(); }

            //timer1.Enabled = true;
            
        }

        private void SubTimer_LogOut()
        {
            if (lblIQCID.Text == "")
            {
                //SubIqcLogin();
                sDTime = ""; //System.DateTime.Now.AddSeconds(600).ToString("yyyy-MM-dd HH:mm:ss");
                this.Text = "IQC檢驗出庫簽收 ";  
            }
            else
            {
                if (sDTime == "")
                {
                    sDTime = System.DateTime.Now.AddSeconds(600).ToString("yyyy-MM-dd HH:mm:ss");
                }
                

                try
                {
                    DateTime DateTime1 = Convert.ToDateTime(sDTime);
                    int dateDiff = 0;
                    int MinutesDiff = 0;
                    

                    TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
                    TimeSpan ts2 = new TimeSpan(System.DateTime.Now.Ticks);
                    TimeSpan ts = ts2.Subtract(ts1).Duration();
                    MinutesDiff = ts.Minutes;
                    dateDiff = ts.Seconds;

                    string sMsg = "IQC檢驗出庫簽收 " + "離登出時間(" + sDTime + ") " + "還有 ";
                    if (MinutesDiff > 0)
                    {
                        sMsg = sMsg + MinutesDiff + " 分 ";
                    }
                    sMsg = sMsg + dateDiff + " 秒 ";

                    this.Text = sMsg;

                    if ((MinutesDiff <= 0) && (dateDiff <= 0)) 
                    {
                        lblIQCID.Text = "";
                    }                    
                }
                catch
                {
                    this.Text = "IQC檢驗出庫簽收 "; 
                }



            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }






    }
}
