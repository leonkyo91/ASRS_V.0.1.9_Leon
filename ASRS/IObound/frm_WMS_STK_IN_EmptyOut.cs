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
    public partial class frm_WMS_STK_IN_EmptyOut : Form
    {
        #region Grid Parameter
        int iCol1_CmdSno = 0;
        int iCol1_Loc1 = 1;
        int iCol1_LocID1 = 2;
        int iCol1_Loc2 = 3;
        int iCol1_LocID2 = 4;
        int iCol1_FOSBCnt = 5;
        int iCol1_Counts = 6;
        #endregion

        #region Grid Parameter
        int iCol_Loc = 0;           
        int iCol_SubLoc = 1;        
        int iCol_ITEM = 2;          
        int iCol_Cust = 3;           
        int iCol_Dev = 4;          
        int iCol_LotNo = 5;         
        int iCol_OFFQty = 6;       
        int iCol_WaferQty = 7;      
        int iCol_ShipQty = 8;       
        int iCol_ChkIQC = 9;        
        int iCol_InDate = 10;       
        int iCol_TrnDate = 11;  
        int iCol_FOSBID = 12;                 
        int iCol_REMARK = 13;                 
        int iCol_TRANSACTION_DATE = 14;       
        int iCol_GIB_CUSTOMER = 15;           
        int iCol_FAB_LOT_NO = 16;             
        int iCol_FAB_TYPE = 17;               
        int iCol_TYPENO = 18;                 
        int iCol_LOT_TYPE = 19;               
        int iCol_WAFER_SIZE = 20;             
        int iCol_YIELD = 21;                  
        int iCol_APP_NO = 22;                 
        int iCol_REL_DATE = 23;               
        int iCol_REASON_NAME = 24;            
        int iCol_TRANSACTION_REFERENCE = 25;  
        int iCol_TRANSACTION_SOURCE_ID = 26; 
        int iCol_TRANSACTION_TYPE_ID = 27;    
        int iCol_FROM_ORG = 28;               
        int iCol_TO_ORG = 29;                 
        int iCol_FROM_BANK = 30;
        int iCol_TO_BANK = 31; 
        int iCol_Store = 32;
        int iCol_IQCID = 33;
        int iCol_ACCID = 34;
        int iCol_Counts = 35;
        #endregion

        bool bIsinit = true;

        public frm_WMS_STK_IN_EmptyOut()
        {
            InitializeComponent();
        }

        private void btnCheckFosb_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frm_WMS_STK_IN_Receive")
                {
                    f.Visible = true;
                    f.Activate();
                    f.WindowState = FormWindowState.Maximized;
                    f.Focus();
                    return;
                }
            }
            frm_WMS_STK_IN_Receive frmP_WMS_STK_IN_Receive = new frm_WMS_STK_IN_Receive();
            frmP_WMS_STK_IN_Receive.MdiParent = this.MdiParent;
            frmP_WMS_STK_IN_Receive.Show();
            frmP_WMS_STK_IN_Receive.Focus();
        }

        private void frm_WMS_STK_IN_EmptyOut_Load(object sender, EventArgs e)
        {
            GridInit();
            FormInit();
        }

        private void GridInit()
        {
            GridSysInit(ref Grid1);
            GridSetRange(ref Grid1);

            GridSysInit(ref tmpGrid);
            GridSetRange2(ref tmpGrid);
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
            oGrid.ColumnCount = iCol1_Counts;
            oGrid.RowCount = 1;
            oGrid.Columns[iCol1_CmdSno].Width = 100; oGrid.Columns[iCol1_CmdSno].Name = "命令序號";
            oGrid.Columns[iCol1_Loc1].Width = 100; oGrid.Columns[iCol1_Loc1].Name = "儲位1";
            oGrid.Columns[iCol1_LocID1].Width = 100; oGrid.Columns[iCol1_LocID1].Name = "料盤ID1";
            oGrid.Columns[iCol1_Loc2].Width = 100; oGrid.Columns[iCol1_Loc2].Name = "儲位2";
            oGrid.Columns[iCol1_LocID2].Width = 100; oGrid.Columns[iCol1_LocID2].Name = "料盤ID2";
            oGrid.Columns[iCol1_FOSBCnt].Width = 100; oGrid.Columns[iCol1_FOSBCnt].Name = "FOSB空間數";
            //oGrid.RowHeadersWidth = 60;

            int i = 0;
            for (i = 0; i <= oGrid.ColumnCount - 1; i++)
            {
                oGrid.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            oGrid.RowCount = 0;
        }

        private void GridSetRange2(ref DataGridView oGrid)
        {
            oGrid.ColumnCount = iCol_Counts;
            oGrid.RowCount = 1;

            oGrid.Columns[iCol_Loc].Width = 50; oGrid.Columns[iCol_Loc].Name = "儲位";
            oGrid.Columns[iCol_SubLoc].Width = 40; oGrid.Columns[iCol_SubLoc].Name = "L/R";
            oGrid.Columns[iCol_ITEM].Width = 80; oGrid.Columns[iCol_ITEM].Name = "NO";
            oGrid.Columns[iCol_Cust].Width = 80; oGrid.Columns[iCol_Cust].Name = "客戶簡稱";
            oGrid.Columns[iCol_Dev].Width = 80; oGrid.Columns[iCol_Dev].Name = "DEVICE";
            oGrid.Columns[iCol_LotNo].Width = 80; oGrid.Columns[iCol_LotNo].Name = "LOT NO";
            oGrid.Columns[iCol_OFFQty].Width = 40; oGrid.Columns[iCol_OFFQty].Name = "件數";
            oGrid.Columns[iCol_WaferQty].Width = 40; oGrid.Columns[iCol_WaferQty].Name = "枚數";
            oGrid.Columns[iCol_ShipQty].Width = 40; oGrid.Columns[iCol_ShipQty].Name = "數量";
            oGrid.Columns[iCol_ChkIQC].Width = 40; oGrid.Columns[iCol_ChkIQC].Name = "檢驗";
            oGrid.Columns[iCol_InDate].Width = 100; oGrid.Columns[iCol_InDate].Name = "入庫時間";
            oGrid.Columns[iCol_TrnDate].Width = 100; oGrid.Columns[iCol_TrnDate].Name = "異動時間";

            oGrid.Columns[iCol_FOSBID].Width = 80; oGrid.Columns[iCol_FOSBID].Name = "收料序號";
            oGrid.Columns[iCol_REMARK].Width = 80; oGrid.Columns[iCol_REMARK].Name = "備註";
            oGrid.Columns[iCol_TRANSACTION_DATE].Width = 100; oGrid.Columns[iCol_TRANSACTION_DATE].Name = "收料日期";
            oGrid.Columns[iCol_GIB_CUSTOMER].Width = 40; oGrid.Columns[iCol_GIB_CUSTOMER].Name = "來貨廠商";
            oGrid.Columns[iCol_FAB_LOT_NO].Width = 80; oGrid.Columns[iCol_FAB_LOT_NO].Name = "Fab lot";
            oGrid.Columns[iCol_FAB_TYPE].Width = 80; oGrid.Columns[iCol_FAB_TYPE].Name = "晶圓廠別";
            oGrid.Columns[iCol_TYPENO].Width = 80; oGrid.Columns[iCol_TYPENO].Name = "Mask";
            oGrid.Columns[iCol_LOT_TYPE].Width = 80; oGrid.Columns[iCol_LOT_TYPE].Name = "Lot Type";
            oGrid.Columns[iCol_WAFER_SIZE].Width = 80; oGrid.Columns[iCol_WAFER_SIZE].Name = "Size";
            oGrid.Columns[iCol_YIELD].Width = 80; oGrid.Columns[iCol_YIELD].Name = "良率";
            oGrid.Columns[iCol_APP_NO].Width = 80; oGrid.Columns[iCol_APP_NO].Name = "報單號碼";
            oGrid.Columns[iCol_REL_DATE].Width = 100; oGrid.Columns[iCol_REL_DATE].Name = "報單日期";
            oGrid.Columns[iCol_REASON_NAME].Width = 100; oGrid.Columns[iCol_REASON_NAME].Name = "Reason Code";
            oGrid.Columns[iCol_TRANSACTION_REFERENCE].Width = 100; oGrid.Columns[iCol_TRANSACTION_REFERENCE].Name = "Reference";
            oGrid.Columns[iCol_TRANSACTION_SOURCE_ID].Width = 100; oGrid.Columns[iCol_TRANSACTION_SOURCE_ID].Name = "Source ID";
            oGrid.Columns[iCol_TRANSACTION_TYPE_ID].Width = 100; oGrid.Columns[iCol_TRANSACTION_TYPE_ID].Name = "Transaction Type";
            oGrid.Columns[iCol_FROM_ORG].Width = 100; oGrid.Columns[iCol_FROM_ORG].Name = "From Org ID";
            oGrid.Columns[iCol_TO_ORG].Width = 100; oGrid.Columns[iCol_TO_ORG].Name = "To Org ID";
            oGrid.Columns[iCol_FROM_BANK].Width = 100; oGrid.Columns[iCol_FROM_BANK].Name = "From Bank";
            oGrid.Columns[iCol_TO_BANK].Width = 100; oGrid.Columns[iCol_TO_BANK].Name = "To Bank";

            oGrid.Columns[iCol_Store].Width = 0; oGrid.Columns[iCol_Store].Name = "";
            oGrid.Columns[iCol_IQCID].Width = 0; oGrid.Columns[iCol_IQCID].Name = "";
            oGrid.Columns[iCol_ACCID].Width = 0; oGrid.Columns[iCol_ACCID].Name = "";

            int i = 0;
            for (i = 0; i <= oGrid.ColumnCount - 1; i++)
            {
                oGrid.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            oGrid.RowCount = 0;
        }
        
        private void FormInit()
        {
            clsASRS.SubCboSetCrnNo(ref cboCrnNo);
            clsASRS.SubCboSetStnNo(ref cboStnNo);
            for (int i = 1; i <= 30; i++)
            {
                txtTrnQty.Items.Add(i);
            }

            SubGetInitValue();

            Grid1.RowCount = 0;
            bIsinit = false;

            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };
            cboStnNo.Text = clsASRS.FunGetStnNoByAreaNo(clsASRS.gsAreaNo);
            clsDB.FunClsDB();
        }



        private void SubGetInitValue()
        {
            string strSql = ""; DbDataReader dbRS = null;

            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };

            this.Cursor = Cursors.WaitCursor;

            //Get Empty FOSB Count
            lblEmptyFosb1.Text = "";
            lblEmptyFosb2.Text = "";
            lblEmptyFosb3.Text = "";

            //計算目前空FOSB數........................................................................
            int i = 0;int iCrn = 0;
            int iFosbCnt = 0; 

            for (iCrn = 1; iCrn <= clsASRS.giCrnMax; iCrn++)
            {
                iFosbCnt = 0;
                strSql = "SELECT COUNT(*) FROM LOC_MST WHERE LOCSTS = 'E' ";
                strSql = strSql + "AND (STORAGETYP = '' or  STORAGETYP = ' ' or STORAGETYP IS NULL) ";
                strSql = strSql + "AND ROW_X >= " + (iCrn * 4 - 3) + " AND ROW_X <= " + (iCrn * 4) + " ";
                if (clsDB.FunRsSql(strSql, ref dbRS))
                {
                    while (dbRS.Read())
                    {
                        iFosbCnt = clsTool.INT(dbRS[0].ToString());                        
                    }
                    dbRS.Close();
                }

                switch (iCrn)
                {
                    case 1:
                        lblEmptyFosb1.Text = iFosbCnt.ToString();
                        break;
                    case 2:
                        lblEmptyFosb2.Text = iFosbCnt.ToString();
                        break;
                    case 3:
                        lblEmptyFosb3.Text = iFosbCnt.ToString();
                        break;
                }
            }
            
            clsDB.FunClsDB();
            this.Cursor = Cursors.Default;

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCls_Click(object sender, EventArgs e)
        {
            SubGetInitValue();
            Grid1.RowCount = 0;
            txtTrnQty.Text = "0";
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            SubExecute();
        }

        private void cboCrnNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (char)27; //ESC
        }

        private void txtTrnQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if ((e.KeyChar >= '0' && e.KeyChar <= '9') == false)
            //{
            //    e.KeyChar = (char)27; //ESC
            //}
        }

        private void cboStnNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (char)27; //ESC
        }

        private void cboStnNo_TextChanged(object sender, EventArgs e)
        {
            SubGetStnCmd();
        }

        private void cboStnNo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SubGetStnCmd()
        {
            if (bIsinit == true) { return; }

            if (cboCrnNo.Text == "") { lblCmdQty.Text = ""; return; }

            string strSql = ""; DbDataReader dbRS = null;

            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };

            int iCmdSno = 0;

            strSql = "SELECT COUNT(CMDSNO) FROM CMD_MST WHERE CMDSTS < '7' AND STNNO = '" + cboCrnNo.Text + "' ";

            if (clsDB.FunRsSql(strSql, ref dbRS))
            {
                while (dbRS.Read())
                {
                    iCmdSno = clsTool.INT(dbRS[0].ToString());
                }
                dbRS.Close();
            }

            lblCmdQty.Text = iCmdSno.ToString();

            clsDB.FunClsDB();
            this.Cursor = Cursors.Default;
        }


        private void SubExecute()
        {
            string sSQL = ""; //DbDataReader dbRS = null;
            int iSelCrn = 0;    //指定 Crane No

            int iTrnCnt = 0; int idx = 0;
            iTrnCnt = clsTool.INT(txtTrnQty.Text);

            Grid1.RowCount = 0;

            //if (cboStnNo.Text == "") { clsMSG.ShowWarningMsg("請選擇站號"); return; }

            #region 判斷數量是否足夠
            int iEmptyFosb = 0;
            if (chkCrn.Checked == false)
            {                
                iSelCrn = clsTool.INT(cboCrnNo.Text);
                switch (cboCrnNo.Text)
                {
                    case "1":
                        iEmptyFosb = clsTool.INT(lblEmptyFosb1.Text);   break;
                    case "2":
                        iEmptyFosb = clsTool.INT(lblEmptyFosb2.Text);   break;
                    case "3":
                        iEmptyFosb = clsTool.INT(lblEmptyFosb3.Text);   break;
                    default:
                        clsMSG.ShowWarningMsg("選擇的高架車錯誤");return;
                        //MessageBox.Show("選擇的高架車錯誤","Error",MessageBoxButtons.OK,MessageBoxIcon.Error); return;
                }
                if (iTrnCnt > iEmptyFosb)
                {
                    clsMSG.ShowErrMsg("AS/RS 可存放FOSB為：" + iEmptyFosb + " \n 預計入庫存放FOSB為：" + iTrnCnt + " \n 無法存放，請再確認!!");
                    return;
                }
            }
            else
            {
                //隨機(不限高架車)
                iSelCrn = 0;

                iEmptyFosb = clsTool.INT(lblEmptyFosb1.Text) + clsTool.INT(lblEmptyFosb2.Text) + clsTool.INT(lblEmptyFosb3.Text);
                if (iTrnCnt > iEmptyFosb)
                {
                    clsMSG.ShowErrMsg("AS/RS 可存放FOSB為：" + iEmptyFosb + " \n 預計入庫存放FOSB為：" + iTrnCnt + " \n 無法存放，請再確認!!");
                    return;
                }

            }
            #endregion


            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };

            #region 判斷是否有儲位重整中
            string sTmpMsg = "";
            if (clsASRS.FunChkCycleStsIsRunning(ref sTmpMsg) == false)
            {
                clsMSG.ShowInformationMsg(sTmpMsg);
                clsDB.FunClsDB();
                return;
            }
            #endregion


            this.Cursor = Cursors.WaitCursor;

            cls_CmdMst aCmdMst = new cls_CmdMst();

            int iFosb = 0; int i =0;
            iFosb = iTrnCnt;  //要出庫的數量
            for (i = 1; i <= iTrnCnt; i++)
            {
                #region 尋找 E空料盒儲位
                string sLoc1 = ""; string sLocID1 ="";
                string sLoc2 = ""; string sLocID2 ="";

                if (iFosb <= 0) { break; }  //數量己經為0,則跳出迴圈
                
                if (iFosb == 1)
                {
                    //剩下一個
                    #region 找單料盒儲位順序
                    //(1) 找外側儲位,內側儲位為N.
                    //(2) 找內側儲位,外側儲位為N.
                    //(3) 找內側儲位,外側儲位為S.
                    //(4) 找內側儲位,外側儲位為E.
                    //(5) 找外側儲位,內側儲位為E.
                    //(6) 找內側儲位,內側儲位不為E.
                    //(7) 找外側儲位,內側儲位不為E.
                    #endregion

                    #region 找料盒
                    //(1) 找外側儲位,內側儲位為N.
                    if (clsASRS.FunGetLocForSingleListByInOutLoc(iSelCrn, "E", "N", 2, ref sLoc1, ref sLocID1) == false)
                    {
                        //(2) 找內側儲位,外側儲位為N.
                        if (clsASRS.FunGetLocForSingleListByInOutLoc(iSelCrn, "E", "N", 1, ref sLoc1, ref sLocID1) == false)
                        {
                            //(3) 找內側儲位,外側儲位為S.
                            if (clsASRS.FunGetLocForSingleListByInOutLoc(iSelCrn, "E", "S", 1, ref sLoc1, ref sLocID1) == false)
                            {
                                //(4) 找內側儲位,外側儲位為E.
                                if (clsASRS.FunGetLocForSingleListByInOutLoc(iSelCrn, "E", "E", 1, ref sLoc1, ref sLocID1) == false)
                                {
                                    //(5) 找外側儲位,內側儲位為E.
                                    if (clsASRS.FunGetLocForSingleListByInOutLoc(iSelCrn, "E", "E", 2, ref sLoc1, ref sLocID1) == false)
                                    {
                                        //(6) 找內側儲位,內側儲位不為E.
                                        if (clsASRS.FunGetLocForSingleListByLocSts(iSelCrn, "E", 1, ref sLoc1, ref sLocID1) == false)
                                        {
                                            //(7) 找外側儲位,內側儲位不為E.
                                            if (clsASRS.FunGetLocForSingleListByLocSts(iSelCrn, "E", 2, ref sLoc1, ref sLocID1) == false)
                                            {
                                                clsDB.FunClsDB();
                                                this.Cursor = Cursors.Default;
                                                return;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    #endregion

                    //SLOC1,SOCID1
                }
                else
                {
                    //1. 先找儲位雙料盒皆為空料盒.
                    if (clsASRS.FunGetLocForDoubleListByLocSts(iSelCrn, "E", ref sLoc1, ref sLocID1, ref sLoc2, ref sLocID2) == true)
                    {
                        //Got LOC1,LOC2
                    }
                    else
                    {
                        //2. 無雙料盒則找單料盒. 
                        #region 找單料盒儲位順序
                        //(1) 找外側儲位,內側儲位為N.
                        //(2) 找內側儲位,外側儲位為N.
                        //(3) 找內側儲位,外側儲位為S.
                        //(4) 找內側儲位,外側儲位為E.
                        //(5) 找外側儲位,內側儲位為E.
                        //(6) 找內側儲位,內側儲位不為E.
                        //(7) 找外側儲位,內側儲位不為E.
                        #endregion

                        #region 找料盒
                        //(1) 找外側儲位,內側儲位為N.
                        if (clsASRS.FunGetLocForSingleListByInOutLoc(iSelCrn, "E", "N", 2, ref sLoc1, ref sLocID1) == false)  
                        {
                            //(2) 找內側儲位,外側儲位為N.
                            if (clsASRS.FunGetLocForSingleListByInOutLoc(iSelCrn, "E", "N", 1, ref sLoc1, ref sLocID1) == false) 
                            {
                                //(3) 找內側儲位,外側儲位為S.
                                if (clsASRS.FunGetLocForSingleListByInOutLoc(iSelCrn, "E", "S", 1, ref sLoc1, ref sLocID1) == false) 
                                {
                                    //(4) 找內側儲位,外側儲位為E.
                                    if (clsASRS.FunGetLocForSingleListByInOutLoc(iSelCrn, "E", "E", 1, ref sLoc1, ref sLocID1) == false) 
                                    {
                                        //(5) 找外側儲位,內側儲位為E.
                                        if (clsASRS.FunGetLocForSingleListByInOutLoc(iSelCrn, "E", "E", 2, ref sLoc1, ref sLocID1) == false) 
                                        {
                                            //(6) 找內側儲位,內側儲位不為E.
                                            if (clsASRS.FunGetLocForSingleListByLocSts(iSelCrn, "E", 1, ref sLoc1, ref sLocID1) == false) 
                                            {
                                                //(7) 找外側儲位,內側儲位不為E.
                                                if (clsASRS.FunGetLocForSingleListByLocSts(iSelCrn, "E", 2, ref sLoc1, ref sLocID1) == false)
                                                {
                                                    clsDB.FunClsDB();
                                                    this.Cursor = Cursors.Default;
                                                    return;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        #endregion

                        //SLOC1,SOCID1
                    }
                }
                #endregion

                
                //產生出庫命令

                #region 讀取命令序號
                string sCmdSno = clsASRS.FunGetCmdSno();
                if (sCmdSno == "")
                {
                    clsMSG.ShowErrMsg("系統錯誤,無命令序號可使用!!");
                    clsDB.FunClsDB(); return;
                }
                #endregion
                
                clsDB.FunCommitCtrl("BEGIN");

                #region 預約儲位
                sSQL = "UPDATE LOC_MST SET LOCSTS = 'O' WHERE LOC = '" + sLoc1 + "' AND LOCSTS = 'E' ";
                if (clsDB.FunExecSql(sSQL) == false)
                {
                    clsDB.FunCommitCtrl("ROLLBACK");
                    clsDB.FunClsDB();
                    this.Cursor = Cursors.Default;
                    clsMSG.ShowErrMsg(clsMSG.MSG.COMMAND_ERROR);
                    return;
                }
                if (sLoc2 != "")
                {
                    sSQL = "UPDATE LOC_MST SET LOCSTS = 'O' WHERE LOC = '" + sLoc2 + "' AND LOCSTS = 'E' ";
                    if (clsDB.FunExecSql(sSQL) == false)
                    {
                        clsDB.FunCommitCtrl("ROLLBACK");
                        clsDB.FunClsDB();
                        this.Cursor = Cursors.Default;
                        clsMSG.ShowErrMsg(clsMSG.MSG.COMMAND_ERROR);
                        return;
                    }
                }
                #endregion
                
                #region 產生命令主檔
                aCmdMst.FunCmdMstClear();   //Clear()
                aCmdMst.CMDSNO = sCmdSno;
                aCmdMst.SNO1 = "1";
                aCmdMst.LOC1 = sLoc1;
                aCmdMst.LOCID1 = sLocID1;
                aCmdMst.SCAN1 = "N";  aCmdMst.SCAN2 = "N";
                if (sLoc2 == "")
                {
                    aCmdMst.SNO2 = "";
                    aCmdMst.CMDMODE = clsASRS.gsCmdMode_Out;   //2                    
                    idx = 1;    //1個空料盒
                }
                else
                {
                    aCmdMst.SNO2 = "2";
                    aCmdMst.LOC2 = sLoc2;
                    aCmdMst.LOCID2 = sLocID2;
                    aCmdMst.CMDMODE = clsASRS.gsCmdMode_Pack;   //3
                    idx = 2;    //2個空料盒
                }
                aCmdMst.CMDSTS = "0";
                aCmdMst.PRT = "5";
                
                //中科廠-站號依儲位
                //aCmdMst.STNNO = cboStnNo.Text;
                if (cboStnNo.Text == "D04") { aCmdMst.STNNO = cboStnNo.Text; }
                else { aCmdMst.STNNO = clsASRS.FunGetStnNoByLoc_SPIL_ZX(sLoc1); }

                aCmdMst.IOTYP = clsASRS.gsIOTYPE_WMS_In;
                aCmdMst.AVAIL = "0";
                aCmdMst.MIXQTY = "0";
                aCmdMst.NEWLOC = "";
                aCmdMst.PROGID = clsASRS.gsIOTYPE_WMS_In_PID;
                aCmdMst.USERID = clsASRS.gstrLoginUser;
                aCmdMst.TRACE = "0";
                aCmdMst.STORAGETYP = "";
                                

                if (aCmdMst.FunInsCmdMst() == false) 
                {
                    clsDB.FunCommitCtrl("ROLLBACK");
                    clsDB.FunClsDB();
                    this.Cursor = Cursors.Default;
                    clsMSG.ShowErrMsg(clsMSG.MSG.COMMAND_ERROR);
                    return;

                }
                #endregion


                clsDB.FunCommitCtrl("COMMIT");

                //將結果寫入Grid中
                SubWriGridCmd(sCmdSno, sLoc1, sLocID1, sLoc2, sLocID2,idx);

                //計算判斷要扣除幾個FOSB空間
                iFosb = iFosb - idx;

            }


            clsDB.FunClsDB();
            this.Cursor = Cursors.Default;

            clsMSG.ShowInformationMsg(clsMSG.MSG.SET_PARAMETER_OK);
        }

        private void SubWriGridCmd(string sCmdSno, string sLoc1, string sLocID1, string sLoc2, string sLocID2, int idx)
        {
            Grid1.Rows.Add();
            Grid1[iCol1_CmdSno, Grid1.Rows.Count - 1].Value = sCmdSno;
            Grid1[iCol1_Loc1, Grid1.Rows.Count - 1].Value = sLoc1;
            Grid1[iCol1_LocID1, Grid1.Rows.Count - 1].Value = sLocID1;
            Grid1[iCol1_Loc2, Grid1.Rows.Count - 1].Value = sLoc2;
            Grid1[iCol1_LocID2, Grid1.Rows.Count - 1].Value = sLocID2;
            Grid1[iCol1_FOSBCnt, Grid1.Rows.Count - 1].Value = idx.ToString();
        }

        private void txtTrnQty_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void cboCrnNo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }





        ////尋找空料盒儲位 (Coding)
        //private void FunGetInLoc(string sStoragetyp, ref string sLoc1, ref string sLoc2)
        //{
        //    string strSql = ""; DbDataReader dbRS = null; DbDataReader dbRS2 = null;
        //    string sLoc = "";
            
        //    if (chkCrn.Checked == true)
        //    {
        //        // 不限高架車


        //    }
        //    else
        //    {
        //        //限制高架車
        //        int iCrn = clsTool.INT(cboCrnNo.Text);

        //        clsASRS.LOC_BASE aLocList = new clsASRS.LOC_BASE();
                
        //        //找內側儲位是空料盒儲位
        //        strSql = "SELEC LOC,LOCID,ROW_X,BAY_Y,LVL_Z FROM LOC_MST WHERE LOCSTS = 'E' AND (STORAGETYP = '' or STORAGETYP = ' ') ";
        //        strSql = strSql + "AND ROW_X >= " + (iCrn * 4 - 3) + " AND ROW_X <= " + (iCrn * 4 - 3 + 1) + " ";
        //        strSql = strSql + "ORDER BY LVL_Z,BAY_Y,ROW_X ";
        //        if (clsDB.FunRsSql(strSql, ref dbRS))
        //        {
        //            while (dbRS.Read())
        //            {
        //                aLocList.LOC = dbRS["LOC"].ToString();
        //                aLocList.LOC_ID = dbRS["LOCID"].ToString();
        //                aLocList.ROW_X = dbRS["ROW_X"].ToString();
        //                aLocList.BAY_Y = dbRS["BAY_Y"].ToString();
        //                aLocList.LVL_Z = dbRS["LVL_Z"].ToString();

        //                strSql = "SELECT LOC,LOCID,ROW_X,BAY_Y,LVL_Z FROM LOC_MST WHERE (STORAGETYP = '' or STORAGETYP = ' ') ";
        //                strSql = strSql + "AND ROW_X = '' ";




        //            }
        //            dbRS.Close();
        //        }




        //    }

        //}

        ////尋找空料盒儲位清單
        //private void FunGetDoubleEmptyLocList(int iCrn)
        //{
        //    string strSql = ""; DbDataReader dbRS = null; 

        //    clsASRS.LOC_Double[] aLocList = new clsASRS.LOC_Double[0];   
        //    clsASRS.LOC_Single[] aLocList_Single = new clsASRS.LOC_Single[0];
        //    clsASRS.LOC_BASE[] aLocList1 = new clsASRS.LOC_BASE[0];
        //    int i = 0; int j = 0; int idx = 0; int idx_1 = 0;


        //    #region 收集空料盒儲位清單
        //    strSql = "SELEC LOC,LOCID,ROW_X,BAY_Y,LVL_Z FROM LOC_MST WHERE LOCSTS = 'E' AND (STORAGETYP = '' or STORAGETYP = ' ') ";
        //    strSql = strSql + "AND ROW_X >= " + (iCrn * 4 - 3) + " AND ROW_X <= " + (iCrn * 4 - 3 + 1) + " ";
        //    strSql = strSql + "ORDER BY LVL_Z,BAY_Y,ROW_X ";
        //    if (clsDB.FunRsSql(strSql, ref dbRS))
        //    {
        //        while (dbRS.Read())
        //        {
        //            idx = idx + 1;
        //            Array.Resize<clsASRS.LOC_BASE>(ref aLocList1, idx);

        //            aLocList1[idx].LOC = dbRS["LOC"].ToString();
        //            aLocList1[idx].LOC_ID = dbRS["LOCID"].ToString();
        //            aLocList1[idx].ROW_X = dbRS["ROW_X"].ToString();
        //            aLocList1[idx].BAY_Y = dbRS["BAY_Y"].ToString();
        //            aLocList1[idx].LVL_Z = dbRS["LVL_Z"].ToString();
        //        }
        //        dbRS.Close();
        //    }
        //    #endregion

        //    #region 分類 Double儲位或 Single儲位
        //    idx = 0; idx_1 = 0;
        //    for (i = 1; i <= aLocList1.Length - 1; i++)
        //    {
        //        if (aLocList1[i].LOC == "") { break; }
                
        //        int x = clsTool.INT(aLocList1[i].ROW_X);    //取 ROW
                
        //        if (i == aLocList.Length - 1)
        //        {
        //            //最後一筆
                    
        //        }
        //        else
        //        {
        //            for (j = i + 1; j <= aLocList1.Length - 1; j++)
        //            {                      
        //                int y = 0;

        //                if (aLocList1[j].LOC == "")
        //                {

        //                }
        //                else
        //                {

        //                    //相同的Bay_y和Lvl_z
        //                    if ((aLocList1[i].BAY_Y == aLocList1[j].BAY_Y) && (aLocList1[i].LVL_Z == aLocList1[j].LVL_Z))
        //                    {
        //                        y = clsTool.INT(aLocList1[j].ROW_X);    //取 ROW
        //                        bool bFlaA = false;

        //                        #region 判斷是否同一側,如果是同一側,則寫入aLocList[]中
        //                        if ((x == 1) && (y == 3))
        //                        {
        //                            idx = idx + 1;
        //                            Array.Resize<clsASRS.LOC_Double>(ref aLocList, idx);

        //                            aLocList[idx].LOC1 = aLocList1[j].LOC;
        //                            aLocList[idx].LOC1_ID = aLocList1[j].LOC_ID;
        //                            aLocList[idx].LOC2 = aLocList1[i].LOC;
        //                            aLocList[idx].LOC2_ID = aLocList1[i].LOC_ID;

        //                            aLocList1[i].LOC = ""; aLocList1[j].LOC = "";  //Clear
        //                            bFlaA = true;
        //                            break;
        //                        }
        //                        else if ((x == 3) && (y == 1))
        //                        {
        //                            idx = idx + 1;
        //                            Array.Resize<clsASRS.LOC_Double>(ref aLocList, idx);

        //                            aLocList[idx].LOC1 = aLocList1[i].LOC;
        //                            aLocList[idx].LOC1_ID = aLocList1[i].LOC_ID;
        //                            aLocList[idx].LOC2 = aLocList1[j].LOC;
        //                            aLocList[idx].LOC2_ID = aLocList1[j].LOC_ID;

        //                            aLocList1[i].LOC = ""; aLocList1[j].LOC = "";  //Clear
        //                            bFlaA = true;
        //                            break;
        //                        }
        //                        else if ((x == 2) && (y == 4))
        //                        {
        //                            idx = idx + 1;
        //                            Array.Resize<clsASRS.LOC_Double>(ref aLocList, idx);

        //                            aLocList[idx].LOC1 = aLocList1[j].LOC;
        //                            aLocList[idx].LOC1_ID = aLocList1[j].LOC_ID;
        //                            aLocList[idx].LOC2 = aLocList1[i].LOC;
        //                            aLocList[idx].LOC2_ID = aLocList1[i].LOC_ID;

        //                            aLocList1[i].LOC = ""; aLocList1[j].LOC = "";  //Clear
        //                            bFlaA = true;
        //                            break;
        //                        }
        //                        else if ((x == 4) && (y == 2))
        //                        {
        //                            idx = idx + 1;
        //                            Array.Resize<clsASRS.LOC_Double>(ref aLocList, idx);

        //                            aLocList[idx].LOC1 = aLocList1[i].LOC;
        //                            aLocList[idx].LOC1_ID = aLocList1[i].LOC_ID;
        //                            aLocList[idx].LOC2 = aLocList1[j].LOC;
        //                            aLocList[idx].LOC2_ID = aLocList1[j].LOC_ID;

        //                            aLocList1[i].LOC = ""; aLocList1[j].LOC = "";  //Clear
        //                            bFlaA = true;
        //                            break;
        //                        }
        //                        #endregion

        //                        #region 如果不是同一側,則寫入aLocList_Single[]中
        //                        if (bFlaA == false)
        //                        {
        //                            idx_1 = idx_1 + 1;
        //                            Array.Resize<clsASRS.LOC_Single>(ref aLocList_Single, idx_1);

        //                            aLocList_Single[idx_1].LOC1 = aLocList1[j].LOC;
        //                            aLocList_Single[idx_1].LOC1_ID = aLocList1[j].LOC_ID;

        //                            aLocList1[i].LOC = "";   //Clear
        //                        }
        //                        #endregion
        //                    }

        //                }
        //            }
        //        }
        //    }
        //    #endregion
            

        //}


    }
}
