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
    public partial class frm_WMS_STK_OUT_Receive : Form
    {
        #region Grid Parameter
        int iCol2_Customer = 0;             //'客戶編號
        int iCol2_ItemNo = 1;               //'ITEM
        int iCol2_LotNo = 2;                //'Lot No
        int iCol2_FOSBID = 3;               //'FOSB ID
        int iCol2_WMSLOC = 4;
        int iCol2_WaferQty = 5;             //'枚數
        int iCol2_ShipQty = 6;              //'數量
        int iCol2_FAB_LOT_NO = 7;
        int iCol2_Device = 8;               //'DEVICE

        int iCol2_Loc = 9;
        int iCol2_REMARK = 10;
        int iCol2_TRANSACTION_DATE = 11;    //'收料日期
        int iCol2_GIB_CUSTOMER = 12;

        int iCol2_FAB_TYPE = 13;
        int iCol2_TYPENO = 14;
        int iCol2_LOT_TYPE = 15;
        int iCol2_WAFER_SIZE = 16;
        int iCol2_YIELD = 17;
        int iCol2_APP_NO = 18;
        int iCol2_REL_DATE = 19;
        int iCol2_REASON_NAME = 20;
        int iCol2_TRANSACTION_REFERENCE = 21;
        int iCol2_TRANSACTION_SOURCE_ID = 22;
        int iCol2_TRANSACTION_TYPE_ID = 23;
        int iCol2_FROM_ORG = 24;
        int iCol2_TO_ORG = 25;
        int iCol2_FROM_BANK = 26;
        int iCol2_TO_BANK = 27;
        int iCol2_INDATE = 28;           // '入庫時間
        int iCol2_ChkIQC = 29;           //   '是否檢驗
        int iCol2_FLAGQTY = 30;

        int iCol2_SEQ_NO = 31;          //'流水號 (WMS)
        int iCol2_COID = 32;            //'廠區   (WMS)
        int iCol2_DOCID = 33;           //'WMS上架單號(WMS)
        int iCol2_WMS_STS = 34;
        int iCol2_Counts = 35;
        #endregion


        #region Grid Parameter
        int iCol_Type = 0;                  //作業項目
        int iCol_DOCID = 1;                 //單號
        int iCol_RCVNO = 2;                 //收料序號
        int iCol_LOTNO = 3;                //
        int iCol_STNNO = 4;
        int iCol_Counts = 5;
        #endregion

        string get_CmdSno = "";
        string get_Loc = "";
        string get_LocID = "";
        string get_Sno = "";

        string gsLocStyle = "";
        string gsWMSLOC = "";


        string gsMemo = "";
        string gsStkOutType = "";

        string gsStkType1 = "退客貨下架";
        string gsStkType2 = "發料下架";
        string gsStkType3 = "一般調撥";
        string gsStkType4 = "報廢移倉下架";
        string gsStkType5 = "手動下架";
        string gsStkType6 = "更換標籤";

        public frm_WMS_STK_OUT_Receive()
        {
            InitializeComponent();
        }

        private void frm_WMS_STK_OUT_Receive_Load(object sender, EventArgs e)
        {
            GridInit();
            FormInit();
        }

        private void GridInit()
        {
            GridSysInit(ref Grid1); GridSetRange(ref Grid1);
            GridSysInit(ref Grid2); GridSetRange2(ref Grid2);
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
            oGrid.ColumnCount = iCol2_Counts;
           
            oGrid.Columns[iCol2_Customer].Width = 90; oGrid.Columns[iCol2_Customer].Name = "客戶名稱";
            oGrid.Columns[iCol2_ItemNo].Width = 100;  oGrid.Columns[iCol2_ItemNo].Name = "ITEM";
            oGrid.Columns[iCol2_LotNo].Width = 100; oGrid.Columns[iCol2_LotNo].Name = "LOT NO";
            oGrid.Columns[iCol2_FOSBID].Width = 110; oGrid.Columns[iCol2_FOSBID].Name = "收料序號";
            oGrid.Columns[iCol2_WMSLOC].Width = 140; oGrid.Columns[iCol2_WMSLOC].Name = "WMS儲位";
            oGrid.Columns[iCol2_WaferQty].Width = 60; oGrid.Columns[iCol2_WaferQty].Name = "枚數";
            oGrid.Columns[iCol2_ShipQty].Width = 60; oGrid.Columns[iCol2_ShipQty].Name = "數量";
            oGrid.Columns[iCol2_FAB_LOT_NO].Width = 110; oGrid.Columns[iCol2_FAB_LOT_NO].Name = "晶圓批號";
            oGrid.Columns[iCol2_Device].Width = 100; oGrid.Columns[iCol2_Device].Name = "DEVICE";
            oGrid.Columns[iCol2_Loc].Width = 0; oGrid.Columns[iCol2_Loc].Visible = false;
            oGrid.Columns[iCol2_REMARK].Width = 100; oGrid.Columns[iCol2_REMARK].Name = "備註";
            oGrid.Columns[iCol2_REMARK].Visible = false;
            oGrid.Columns[iCol2_TRANSACTION_DATE].Width = 110; oGrid.Columns[iCol2_TRANSACTION_DATE].Name = "收料日期";
            oGrid.Columns[iCol2_TRANSACTION_DATE].Visible = false;
            oGrid.Columns[iCol2_GIB_CUSTOMER].Width = 80; oGrid.Columns[iCol2_GIB_CUSTOMER].Name = "來貨廠商";
            oGrid.Columns[iCol2_GIB_CUSTOMER].Visible = false;
            oGrid.Columns[iCol2_FAB_TYPE].Width = 100; oGrid.Columns[iCol2_FAB_TYPE].Name = "晶圓廠別";
            oGrid.Columns[iCol2_FAB_TYPE].Visible = false;
            oGrid.Columns[iCol2_TYPENO].Width = 100; oGrid.Columns[iCol2_TYPENO].Name = "Mask";
            oGrid.Columns[iCol2_TYPENO].Visible = false;
            oGrid.Columns[iCol2_LOT_TYPE].Width = 100; oGrid.Columns[iCol2_LOT_TYPE].Name = "Lot Type";
            oGrid.Columns[iCol2_LOT_TYPE].Visible = false;
            oGrid.Columns[iCol2_WAFER_SIZE].Width = 100; oGrid.Columns[iCol2_WAFER_SIZE].Name = "晶片尺寸";
            oGrid.Columns[iCol2_WAFER_SIZE].Visible = false;
            oGrid.Columns[iCol2_YIELD].Width = 50; oGrid.Columns[iCol2_YIELD].Name = "良率";
            oGrid.Columns[iCol2_YIELD].Visible = false;
            oGrid.Columns[iCol2_APP_NO].Width = 100; oGrid.Columns[iCol2_APP_NO].Name = "報單號碼";
            oGrid.Columns[iCol2_APP_NO].Visible = false;
            oGrid.Columns[iCol2_REL_DATE].Width = 110; oGrid.Columns[iCol2_REL_DATE].Name = "報單日期";
            oGrid.Columns[iCol2_REL_DATE].Visible = false;
            oGrid.Columns[iCol2_REASON_NAME].Width = 100; oGrid.Columns[iCol2_REASON_NAME].Name = "Reason Code";
            oGrid.Columns[iCol2_REASON_NAME].Visible = false;
            oGrid.Columns[iCol2_TRANSACTION_REFERENCE].Width = 100; oGrid.Columns[iCol2_TRANSACTION_REFERENCE].Name = "Reference";
            oGrid.Columns[iCol2_TRANSACTION_REFERENCE].Visible = false;
            oGrid.Columns[iCol2_TRANSACTION_SOURCE_ID].Width = 100; oGrid.Columns[iCol2_TRANSACTION_SOURCE_ID].Name = "Source ID";
            oGrid.Columns[iCol2_TRANSACTION_SOURCE_ID].Visible = false;
            oGrid.Columns[iCol2_TRANSACTION_TYPE_ID].Width = 130; oGrid.Columns[iCol2_TRANSACTION_TYPE_ID].Name = "Transaction Type";
            oGrid.Columns[iCol2_TRANSACTION_TYPE_ID].Visible = false;
            oGrid.Columns[iCol2_FROM_ORG].Width = 100; oGrid.Columns[iCol2_FROM_ORG].Name = "From Org";
            oGrid.Columns[iCol2_FROM_ORG].Visible = false;
            oGrid.Columns[iCol2_TO_ORG].Width = 100; oGrid.Columns[iCol2_TO_ORG].Name = "To Org";
            oGrid.Columns[iCol2_TO_ORG].Visible = false;
            oGrid.Columns[iCol2_FROM_BANK].Width = 100; oGrid.Columns[iCol2_FROM_BANK].Name = "From Bank";
            oGrid.Columns[iCol2_FROM_BANK].Visible = false;
            oGrid.Columns[iCol2_TO_BANK].Width = 100; oGrid.Columns[iCol2_TO_BANK].Name = "To Bank";
            oGrid.Columns[iCol2_TO_BANK].Visible = false;
            oGrid.Columns[iCol2_INDATE].Width = 120; oGrid.Columns[iCol2_INDATE].Name = "入庫日期";
            oGrid.Columns[iCol2_INDATE].Visible = false;
            oGrid.Columns[iCol2_ChkIQC].Width = 45; oGrid.Columns[iCol2_ChkIQC].Name = "檢驗";
            oGrid.Columns[iCol2_ChkIQC].Visible = false;
            oGrid.Columns[iCol2_FLAGQTY].Width = 100; oGrid.Columns[iCol2_FLAGQTY].Name = "flag";
            oGrid.Columns[iCol2_FLAGQTY].Visible = false;

            oGrid.Columns[iCol2_SEQ_NO].Width = 100; oGrid.Columns[iCol2_SEQ_NO].Name = "SEQ_NO";    //'流水號 (WMS)
            oGrid.Columns[iCol2_SEQ_NO].Visible = false;
            oGrid.Columns[iCol2_COID].Width = 100; oGrid.Columns[iCol2_COID].Name = "COID";          //'廠區   (WMS)
            oGrid.Columns[iCol2_COID].Visible = false;
            oGrid.Columns[iCol2_DOCID].Width = 100; oGrid.Columns[iCol2_DOCID].Name = "WMS上架單號"; //'(WMS)
            oGrid.Columns[iCol2_DOCID].Visible = false;
            oGrid.Columns[iCol2_WMS_STS].Width = 50; oGrid.Columns[iCol2_WMS_STS].Name = "Status";   //'(WMS)
            oGrid.Columns[iCol2_WMS_STS].Visible = false;
            int i = 0;
            for (i = 0; i <= oGrid.ColumnCount - 1; i++)
            {
                oGrid.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            oGrid.RowCount = 0; oGrid.RowCount = 1;
        }

        private void GridSetRange2(ref DataGridView oGrid)
        {
            oGrid.ColumnCount = iCol_Counts;

            oGrid.Columns[iCol_Type].Width = 150; oGrid.Columns[iCol_Type].Name = "作業項目";
            oGrid.Columns[iCol_DOCID].Width = 120; oGrid.Columns[iCol_DOCID].Name = "單號";
            oGrid.Columns[iCol_RCVNO].Width = 140; oGrid.Columns[iCol_RCVNO].Name = "收料序號";
            oGrid.Columns[iCol_LOTNO].Width = 120; oGrid.Columns[iCol_LOTNO].Name = "LOT NO";
            oGrid.Columns[iCol_STNNO].Width = 120; oGrid.Columns[iCol_STNNO].Name = "站號";

            int i = 0;
            for (i = 0; i <= oGrid.ColumnCount - 1; i++)
            {
                oGrid.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            oGrid.RowCount = 0; 
        }

        private void FormInit()
        {
            Grid1.RowCount = 0;

            get_CmdSno = "";
            get_Loc = "";
            get_LocID = "";

            lblCmdSno.Text = "";
            lblLimit.Text = ""; lblLimit.BackColor = Color.White;
            txtFOSB.Text = ""; txtFOSB.BackColor = Color.White;
            txtLocID.Text = ""; txtLocID.BackColor = Color.White;
            lblStkOutType.Visible = false;

            lblFOSB_Red.Visible = false; txtFOSB_Red.Visible = false;
            lblHelp.Visible = false;

            //lblShowMsg.Visible = false;

            txtScan.Text = "";
            txtScan.Select();
        }

        private void btnCls_Click(object sender, EventArgs e)
        {
            SubClearInit();
        }

        private void SubClearInit()
        {
            Grid1.RowCount = 0;
            get_CmdSno = "";
            get_Loc = "";
            get_LocID = "";
            get_Sno = "";

            lblStkOutType.Text = ""; lblStkOutType.Visible = false;

            lblCmdSno.Text = "";
            lblLimit.Text = ""; lblLimit.BackColor = Color.White;

            txtLocID.Text = ""; txtLocID.BackColor = Color.White;
            txtFOSB.Text = ""; txtFOSB.BackColor = Color.White;
            //lblShowMsg.Visible = false;
            txtFOSB_Red.Text = ""; txtFOSB_Red.Visible = false; 
            lblFOSB_Red.Text = ""; lblFOSB_Red.Visible = false;
            lblHelp.Visible = false;
            txtScan.Text = ""; txtScan.Select();
        }

        private void txtScan_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtScan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                txtScan.Text = txtScan.Text.Trim();
                txtScan.Text = txtScan.Text.ToUpper();  //大寫
                if (txtScan.Text.Length == 5)
                {
                    //料盒編號:A0001 (5碼)
                    SubReadLocID(txtScan.Text);
                }
                else
                {
                    //FOSB ID
                    SubReadFOSBID(txtScan.Text);
                }

                txtScan.Text = "";
            }
        }


        //***************************************************************************************************
        // 判別 料盤 條碼
        //***************************************************************************************************
        #region 判別 料盤 條碼
        private void SubReadLocID(string sValue)
        {
            string sLocID = sValue;    //取出料盒ID

            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; }

            if (get_CmdSno == "")
            {
                //讀取命令序號是否存在,是否正確
                if (SubReadLocID_Rd_CMD_MST(sLocID) == false)
                {
                    btnCls.PerformClick();
                    clsDB.FunClsDB(); return;
                }
                
                //讀取WMS的儲位
                gsWMSLOC = clsASRS.FunGetWMSLocByLocID(sLocID);
                
                //讀取命令是否己經有原有的 CMD_DTL 資料
                SubReadLocID_Rd_CMD_DTL(sValue);

                //設定要出庫FOSB的顏色  
                SubColorGrid();

                //WMS
                //判斷是否為 更換標籤
                SubReadCmdIsUpdateData();


                lblStkOutType.Text = gsStkOutType;
                lblStkOutType.Visible = true;
            }
            else
            {
                //己經刷條碼了
                if (get_LocID != "")
                {
                    if (get_LocID != sLocID)
                    {
                        clsMSG.ShowWarningMsg("己經刷過料盤ID!!");
                        btnCls.PerformClick();
                        clsDB.FunClsDB(); return;
                    }
                }
            }

            clsDB.FunClsDB();
        }

        private bool SubReadLocID_Rd_CMD_MST(string sLocID)
        {
            string sSQL = ""; DbDataReader dbRS = null;
            string sScan = "";
            string sCmdSno = ""; string sLoc = ""; string sLocStyle = ""; string sSno = ""; string sCmdMode = "";

            sSQL = "SELECT * FROM CMD_MST WHERE LOCID = '" + sLocID + "' AND CMDSTS <= '7' AND IOTYP = '" + clsASRS.gsIOTYPE_WMS_Out + "' ";
            if (clsDB.FunRsSql(sSQL, ref dbRS))
            {
                while (dbRS.Read())
                {
                    sScan = dbRS["SCAN"].ToString();  //是否Scan
                    sCmdSno = dbRS["CMDSNO"].ToString();
                    sLoc = dbRS["LOC"].ToString();
                    sLocStyle = dbRS["STORAGETYP"].ToString();
                    sSno = dbRS["SNO"].ToString();
                    sCmdMode = dbRS["CMDMODE"].ToString(); //
                }
                dbRS.Close();

                if ((sCmdMode == "3") || (sCmdMode == "1"))
                {
                    //入庫
                    if (sScan == "Y")
                    {
                        clsMSG.ShowWarningMsg("料盤己確認過(己經確認執行)");
                        return false;
                    }
                }
                else if (sCmdMode == "2")
                {
                    //空料盒出庫 --> 轉入庫命令
                    //入庫
                    if (sScan == "Y")
                    {
                        clsMSG.ShowWarningMsg("料盤己確認過(己經確認執行)");
                        return false;
                    }
                }
                else
                {
                    return false;
                }

                get_CmdSno = sCmdSno;
                get_Loc = sLoc;
                get_LocID = sLocID;
                get_Sno = sSno;
                lblCmdSno.Text = get_CmdSno;
                txtLocID.Text = get_LocID;

                gsLocStyle = sLocStyle; //'讀取欄位用來判斷FOSB/黑扁盒
                
            }
            else
            {
                string sIotype = ""; string sProgID = "";
                sSQL = "SELECT * FROM CMD_MST WHERE LOCID = '" + sLocID + "' AND CMDSTS <= '7' ";
                if (clsDB.FunRsSql(sSQL, ref dbRS))
                {
                    while (dbRS.Read())
                    {
                        sIotype = dbRS["IOTYP"].ToString();
                        sProgID = dbRS["PROGID"].ToString();
                    }
                    dbRS.Close();

                    if (sIotype != clsASRS.gsIOTYPE_WMS_Out)
                    {
                        if ((sProgID == clsASRS.gsIOTYPE_WMS_Out_PID) && (sIotype == clsASRS.gsIOTYPE_EmptyIn))
                        {
                            clsMSG.ShowWarningMsg("料盤己確認過(己經確認執行)");
                            return false;
                        }
                        else
                        {
                            clsMSG.ShowWarningMsg("命令不是WMS出庫功能");
                            return false;
                        }
                        
                    }
                }
                else
                {
                    clsMSG.ShowWarningMsg("命令不存在");
                    return false;
                }
            }

            //黑扁盒...顯示只能存放黑扁盒
            if (gsLocStyle == "A")
            {
                //lblShowMsg.Visible = true;
            }
            else
            {
                //lblShowMsg.Visible = false;
            }

            return true;
        }

        private void SubReadLocID_Rd_CMD_DTL(string sLocID)
        {
            string sSQL = ""; DbDataReader dbRS = null;
            lblLimit.BackColor = Color.White;

            if (gsLocStyle == "A")
            {
                //黑扁盒的處理方式 
                // coding ...

            }
            else
            {
                //FOSB的處理方式
                Grid1.RowCount = 0;

                sSQL = "SELECT * FROM CMD_DTL WHERE CMDSNO = '" + get_CmdSno + "' AND LOCID = '" + sLocID + "' ";
                if (clsDB.FunRsSql(sSQL, ref dbRS))
                {
                    while (dbRS.Read())
                    {
                        if (dbRS["FLAGQTY"].ToString() == "O")
                        {
                            lblLimit.Text = "O:FOSB出庫 ";
                            lblLimit.BackColor = Color.White;
                        }
                        else if (dbRS["FLAGQTY"].ToString() == "X")
                        {
                            lblLimit.Text = "X:禁止取貨 (未選擇出庫）";
                            lblLimit.BackColor = Color.Red;
                        }

                        Grid1.Rows.Add();

                        #region
                        Grid1[iCol2_Loc, Grid1.Rows.Count - 1].Value = ""; //dbRS["LOC"].ToString();
                        Grid1[iCol2_Customer, Grid1.Rows.Count - 1].Value = dbRS["CUSTOMER"].ToString();
                        Grid1[iCol2_ItemNo, Grid1.Rows.Count - 1].Value = dbRS["ITEMNO"].ToString();
                        Grid1[iCol2_FOSBID, Grid1.Rows.Count - 1].Value = dbRS["FOSBID"].ToString();
                        Grid1[iCol2_LotNo, Grid1.Rows.Count - 1].Value = dbRS["LOTNO"].ToString();
                        Grid1[iCol2_WMSLOC, Grid1.Rows.Count - 1].Value = gsWMSLOC;
                        Grid1[iCol2_WaferQty, Grid1.Rows.Count - 1].Value = dbRS["WAFERQTY"].ToString();
                        Grid1[iCol2_ShipQty, Grid1.Rows.Count - 1].Value = dbRS["SHIPQTY"].ToString();
                        Grid1[iCol2_FAB_LOT_NO, Grid1.Rows.Count - 1].Value = dbRS["FAB_LOT_NO"].ToString();
                        Grid1[iCol2_Device, Grid1.Rows.Count - 1].Value = dbRS["DEVICE"].ToString();
                        Grid1[iCol2_REMARK, Grid1.Rows.Count - 1].Value = dbRS["REMARK"].ToString();

                        Grid1[iCol2_TRANSACTION_DATE, Grid1.Rows.Count - 1].Value = dbRS["TRANSACTION_DATE"].ToString();
                        Grid1[iCol2_GIB_CUSTOMER, Grid1.Rows.Count - 1].Value = dbRS["GIB_CUSTOMER"].ToString();
                        Grid1[iCol2_FAB_TYPE, Grid1.Rows.Count - 1].Value = dbRS["FAB_TYPE"].ToString();
                        Grid1[iCol2_TYPENO, Grid1.Rows.Count - 1].Value = dbRS["TYPENO"].ToString();
                        Grid1[iCol2_LOT_TYPE, Grid1.Rows.Count - 1].Value = dbRS["LOT_TYPE"].ToString();
                        Grid1[iCol2_WAFER_SIZE, Grid1.Rows.Count - 1].Value = dbRS["WAFER_SIZE"].ToString();
                        Grid1[iCol2_YIELD, Grid1.Rows.Count - 1].Value = dbRS["YIELD"].ToString();
                        Grid1[iCol2_APP_NO, Grid1.Rows.Count - 1].Value = dbRS["APP_NO"].ToString();
                        Grid1[iCol2_REL_DATE, Grid1.Rows.Count - 1].Value = dbRS["REL_DATE"].ToString();
                        Grid1[iCol2_REASON_NAME, Grid1.Rows.Count - 1].Value = dbRS["REASON_NAME"].ToString();
                        Grid1[iCol2_TRANSACTION_REFERENCE, Grid1.Rows.Count - 1].Value = dbRS["TRANSACTION_REFERENCE"].ToString();
                        Grid1[iCol2_TRANSACTION_SOURCE_ID, Grid1.Rows.Count - 1].Value = dbRS["TRANSACTION_SOURCE_ID"].ToString();
                        Grid1[iCol2_TRANSACTION_TYPE_ID, Grid1.Rows.Count - 1].Value = dbRS["TRANSACTION_TYPE_ID"].ToString();
                        Grid1[iCol2_FROM_ORG, Grid1.Rows.Count - 1].Value = dbRS["FROM_ORG"].ToString();
                        Grid1[iCol2_TO_ORG, Grid1.Rows.Count - 1].Value = dbRS["TO_ORG"].ToString();
                        Grid1[iCol2_FROM_BANK, Grid1.Rows.Count - 1].Value = dbRS["FROM_BANK"].ToString();
                        Grid1[iCol2_TO_BANK, Grid1.Rows.Count - 1].Value = dbRS["TO_BANK"].ToString();
                        Grid1[iCol2_ChkIQC, Grid1.Rows.Count - 1].Value = dbRS["CHKIQC"].ToString();
                        Grid1[iCol2_INDATE, Grid1.Rows.Count - 1].Value = dbRS["INDATE"].ToString();
                        Grid1[iCol2_FLAGQTY, Grid1.Rows.Count - 1].Value = dbRS["FLAGQTY"].ToString();
                        Grid1[iCol2_SEQ_NO, Grid1.Rows.Count - 1].Value = dbRS["CYCLENO"].ToString();
                        #endregion
                    }
                    dbRS.Close();
                }
                else
                {

                }
            }
        }

        private void SubColorGrid()
        {
            int i= 0;
            if (gsLocStyle == "A")
            {
                //黑扁盒

            }
            else
            {
                //FOSB
                if (lblLimit.Text.Length > 2)
                {
                    if (lblLimit.Text.Substring(0, 1) == "O")
                    {
                        for (i = 0; i <= Grid1.RowCount - 1; i++)
                        {
                            clsASRS.SetGridColorForOut(ref Grid1, i, 1);

                        }
                    }

                }

            }

        }


        private void SubReadCmdIsUpdateData()
        {
            string sSQL = ""; DbDataReader dbRS = null;
            int i = 0; string sSNID = "";

            for (i = 0; i <= Grid1.RowCount - 1; i++)
            {
                if (Grid1[iCol2_SEQ_NO, i].Value.ToString() != "")
                {
                    if (sSNID == "")
                    {
                        sSNID = Grid1[iCol2_SEQ_NO, i].Value.ToString();
                    }
                    else
                    {
                        sSNID = sSNID + "," + Grid1[iCol2_SEQ_NO, i].Value.ToString();
                    }
                }
            }

            if (sSNID != "")
            {
                #region gsStkOutType
                sSQL = "SELECT * FROM TB_ASRS_TO_WMS_TEMP WHERE SNID IN (" + sSNID + ") ";
                if (clsDB.FunRsSql(sSQL, ref dbRS))
                {
                    while (dbRS.Read())
                    {
                        if (dbRS["TYPE"].ToString() == "UPDATE_DATA")
                        {
                            lblHelp.Visible = true;
                            gsStkOutType = gsStkType6;
                            break;
                        }

                        if (dbRS["TYPE"].ToString() == "STOCKOUT")
                        {
                            if (dbRS["DOCTYP"].ToString() == gsStkType1)
                            {
                                gsStkOutType = gsStkType1;
                            }
                            else if (dbRS["DOCTYP"].ToString() == gsStkType2)
                            {
                                gsStkOutType = gsStkType2;
                            }
                            else if (dbRS["DOCTYP"].ToString() == gsStkType2)
                            {
                                gsStkOutType = gsStkType2;
                            }
                            else if (dbRS["DOCTYP"].ToString() == gsStkType3)
                            {
                                gsStkOutType = gsStkType3;
                            }
                            else if (dbRS["DOCTYP"].ToString() == gsStkType4)
                            {
                                gsStkOutType = gsStkType4;
                            }
                            else if (dbRS["DOCTYP"].ToString() == gsStkType5)
                            {
                                gsStkOutType = gsStkType5;
                            }
                        }

                    }
                    dbRS.Close();
                }
                #endregion

                if (gsStkOutType == gsStkType2)
                {
                    lblFOSB_Red.Visible = true;
                    txtFOSB_Red.Visible = true;
                }
            }
        }
        #endregion




        //***************************************************************************************************
        //判別 FOSB 條碼
        //***************************************************************************************************
        #region 判別 FOSB 條碼
        private void SubReadFOSBID(string sValue)
        {
            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; }
            

            //1.判別變數 get_LocID 是否存在
            if (SubReadFosbID_get_LocID() == false) { btnCls.PerformClick(); clsDB.FunClsDB(); return; }

            //2.判別 FOSB條碼 是否可出庫
            if (SubReadFosbID_Out(sValue) == false) { btnCls.PerformClick(); clsDB.FunClsDB(); return; }

            clsDB.FunClsDB();

            if (txtFOSB_Red.Visible == true)
            {
                if (txtFOSB_Red.Text != "")
                {
                    SubExecute();
                }
            }
            else
            {
                SubExecute();
            }
        }

        private bool SubReadFosbID_get_LocID()
        {
            if (get_LocID == "")
            {
                clsMSG.ShowWarningMsg("請先刷料盤條碼");
                btnCls.PerformClick();
                return false;
            }        
            return true;
        }

        //判別 FOSB條碼 是否可出庫
        private bool SubReadFosbID_Out(string sValue)
        {
            string sGrdFosbID = "";
            int i = 0; //int iRow = 0;
            //bool bIsFosbOut = false;
            string sMsg = "";

            string[] aRedFosbID = new string[1]; aRedFosbID[0] ="";
            int iRed = 0;
            bool bFlagA = true;



            bool bFlagRedBlue = false;
            if (gsLocStyle == "A")
            {


            }
            else
            {
                //************************************************************
                //FOSB
                //************************************************************
                bFlagRedBlue = false;

                #region 判斷
                for (i = 0; i <= Grid1.RowCount - 1; i++)
                {
                    sGrdFosbID = Grid1[iCol2_FOSBID, i].Value.ToString();
                    if (sGrdFosbID.IndexOf(".", 0) >= 0)
                    {
                        sGrdFosbID = sGrdFosbID.Substring(0, sGrdFosbID.IndexOf(".", 0));
                    }


                    //藍標有可能長度大於FOSB ID, 要取FOSB ID長度做比較  //V.1.5.3
                    if (sValue.Length > sGrdFosbID.Length)
                    {
                        sValue = sValue.Substring(0, sGrdFosbID.Length);
                    }


                    if (sGrdFosbID == sValue)
                    {
                        bFlagRedBlue = true;


                        if (Grid1[iCol2_FLAGQTY, i].Value.ToString() == "O")
                        {
                            //bIsFosbOut = true;                              //設定為出庫
                            clsASRS.SetGridColorForOut(ref Grid1, i, 2);    //顏色設定為Blue
                            Grid1[iCol2_FLAGQTY, i].Value = "Y";            //確定出庫
                            txtFOSB.Text = txtFOSB.Text + sValue + ";";
                        }
                        else if (Grid1[iCol2_FLAGQTY, i].Value.ToString() == "X")
                        {
                            if (lblHelp.Visible == true)
                            {
                                sMsg = "更換標籤\r\n (不必刷 WMS 條碼做確認)";
                                clsMSG.ShowWarningMsg(sMsg);
                                return false;
                            }
                            else
                            {
                                sMsg = "此FOSB條碼不能出庫";
                                clsMSG.ShowWarningMsg(sMsg);
                                btnCls.PerformClick();
                                return false;
                            }
                        }
                        else if (Grid1[iCol2_FLAGQTY, i].Value.ToString() == "Y")
                        {
                            #region 紅/藍標確認
                            if (txtFOSB_Red.Visible == true)
                            {
                                txtFOSB_Red.Text = sValue + ";";
                            }
                            else
                            {
                                aRedFosbID = txtFOSB_Red.Text.Split(';');

                                bFlagA = false;
                                for (iRed = 0; iRed <= aRedFosbID.Length - 1; iRed++)
                                {
                                    if (aRedFosbID[iRed] != "")
                                    {
                                        if (aRedFosbID[iRed] == sValue)
                                        {
                                            bFlagA = true;
                                            break;
                                        }
                                    }
                                }
                                if (bFlagA == false)
                                {
                                    txtFOSB_Red.Text = txtFOSB_Red.Text + sValue + ";";
                                }
                            }
                            #endregion
                        }
                        
                    }
                }
                #endregion

                if (txtFOSB_Red.Visible == true)
                {
                    if (bFlagRedBlue == false)
                    {
                        clsMSG.ShowWarningMsg("紅標與藍標收料序號不符!!");
                        btnCls.PerformClick();
                        return false;
                    }
                }
            }

            return true;
        }
        #endregion


        //***************************************************************************************************
        //執行
        //***************************************************************************************************
        #region 執行
        private void btnExecute_Click(object sender, EventArgs e)
        {
            SubExecute();
            SubQueryWmsOutData();
        }

        private void SubExecute()
        {
            bool bIsInsData = false;

            //判別命令序號是否存在
            if (get_CmdSno == "") { txtScan.Select(); return; }

            //判別是否有領全部的料
            if (FunChkIsFOSB(ref bIsInsData) == false)
            {
                clsMSG.ShowWarningMsg("目前還有尚有需要出庫的FOSB,但還未刷條碼做資料確認");
                txtScan.Select();
                return;
            }

            if (FunChkRedFosb() == false)
            {
                txtScan.Select();
                return;
            }

            if (FunDelwithCmd(bIsInsData) == true)
            {
                clsMSG.ShowInformationMsg("資料己處理完畢,請繼續執行出庫動作");
                SubClearInit();
            }

        }
        
        private bool FunChkIsFOSB(ref bool bIsInsData)
        {
            bool bLoc = true; int i = 0;

            if (gsLocStyle == "A")
            {


            }
            else
            {
                //************************************************************
                //FOSB
                //'************************************************************
                if (lblLimit.Text.Length > 2)
                {
                    if (lblLimit.Text.Substring(0, 1) == "O")
                    {
                        for (i = 0; i <= Grid1.RowCount - 1; i++)
                        {
                            if (Grid1[iCol2_FLAGQTY, i].Value.ToString() == "O")     //'應該為'Y',有被刷過
                            {
                                bLoc = false;  //只有FOSB上其中有一個條碼沒被刷到就算不行出庫
                                break;
                            }
                            else if(Grid1[iCol2_FLAGQTY, i].Value.ToString() == "Y")
                            {
                                bIsInsData = true;
                            }
                        }
                    }
                }

                if (bLoc == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        private bool FunChkRedFosb()
        {
            int i = 0; int j = 0; bool bFlag = true;

            string[] aFosb = new string[1]; aFosb[0] = "";

            if (txtFOSB_Red.Visible == true)
            {
                aFosb = txtFOSB_Red.Text.Split(';');


                for (i = 0; i <= Grid1.RowCount - 1; i++)
                {
                    if (Grid1[iCol2_FLAGQTY, i].Value.ToString() == "Y")
                    {
                        bFlag = false;
                        for (j = 0; j <= aFosb.Length - 1; j++)
                        {
                            if (aFosb[j] != "")
                            {
                                if (aFosb[j] == Grid1[iCol2_FOSBID, i].Value.ToString())
                                {
                                    bFlag = true;
                                    break;
                                }
                            }
                        }
                        if (bFlag == false)
                        {
                            clsMSG.ShowWarningMsg("紅標與藍標收料序號不符!!");
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        private bool FunDelwithCmd(bool bIsInsData)
        {
            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return false; };


            #region 找出命令模式
            string sSQL = ""; DbDataReader dbRS = null;
            string sCmdMode = ""; string sIOTYP = ""; string sStnNo = ""; string sProgID = ""; string sUserID = "";
            sSQL = "SELECT * FROM CMD_MST WHERE CMDSNO = '" + get_CmdSno + "' AND LOCID = '" + get_LocID + "' ";
            if (clsDB.FunRsSql(sSQL, ref dbRS))
            {
                while (dbRS.Read())
                {
                    sCmdMode = dbRS["CMDMODE"].ToString();
                    sIOTYP = dbRS["IOTYP"].ToString();
                    sStnNo = dbRS["STNNO"].ToString();
                    sProgID = dbRS["PROGID"].ToString();
                    sUserID = dbRS["USERID"].ToString();
                }
                dbRS.Close();
            }
            #endregion

            if (sCmdMode == "2")
            {
                #region 判斷是否回庫是否有帳
                bool bFlagA = false;
                sSQL = "SELECT * FROM CMD_DTL WHERE CMDSNO = '" + get_CmdSno + "' AND LOCID = '" + get_LocID + "' ";
                if (clsDB.FunRsSql(sSQL, ref dbRS))
                {
                    while (dbRS.Read())
                    {
                        if (dbRS["FLAGQTY"].ToString() == "X")
                        {
                            bFlagA = true;
                        }
                    }
                    dbRS.Close();
                }
                #endregion


                #region 找儲位
                //尋找空儲位 (一定是一個空儲位) 只有入一個      
                int iCrn = 0;
                iCrn = clsASRS.FunGetCraneNoByLocID(get_LocID); //由料盒ID取得是那一座Crane
                int iBayDesc = 1; //從前面找起

                string sGetLoc1 = ""; string sGetLocID1 = "";
                if (bFlagA == true)
                {
                    if (clsASRS.FunGetLocN_ByS(iCrn, ref sGetLoc1, ref sGetLocID1, iBayDesc) == false)
                    {
                        clsMSG.ShowWarningMsg("無合適之空儲位!!"); clsDB.FunClsDB(); return false;
                    }
                }
                else
                {
                    if (clsASRS.FunGetLocN_ByE(iCrn, ref sGetLoc1, ref sGetLocID1, iBayDesc) == false)
                    {
                        clsMSG.ShowWarningMsg("無合適之空儲位!!"); clsDB.FunClsDB(); return false;
                    }
                }
                #endregion

                #region 找命令
                string sCmdSnoNew = clsASRS.FunGetCmdSno();
                if (sCmdSnoNew == "") { clsMSG.ShowErrMsg("系統錯誤!!"); clsDB.FunClsDB(); return false; }
                #endregion

                string sMsg = "";
                clsDB.FunCommitCtrl("BEGIN");
                #region 預約儲位
                //預約儲位為入庫預約
                if (clsASRS.FunSetLocIsPreStkIn(sGetLoc1, "", ref sMsg) == false)
                {
                    clsDB.FunCommitCtrl("ROLLBACK");
                    clsMSG.ShowWarningMsg(sMsg);
                    clsDB.FunClsDB(); return false;
                }
                #endregion

                //更新old命令
                #region 更新 Old命令
                //3.UPDATE資料至CMD_DTL裡
                if (FunDelWithCmd_CMD_DTL(bIsInsData) == false)
                {
                    clsDB.FunCommitCtrl("ROLLBACK"); clsDB.FunClsDB(); return false;
                }
                //if (FunDelWithCmd_CMD_MST() == false)
                //{
                //    clsDB.FunCommitCtrl("ROLLBACK"); clsDB.FunClsDB(); return false;
                //}
                #region 更新Old命令主檔
                sSQL = "UPDATE CMD_MST SET SCAN = 'Y', MIXQTY = 0, AVAIL = 0, CMDSTS = '7' ";
                sSQL = sSQL + "WHERE CMDSNO = '" + get_CmdSno + "' ";
                sSQL = sSQL + "AND LOCID = '" + get_LocID + "' ";
                sSQL = sSQL + "AND CMDSTS <= '7' ";
                if (clsDB.FunExecSql(sSQL) == false)
                {
                    clsDB.FunCommitCtrl("ROLLBACK");
                    clsMSG.ShowWarningMsg(clsMSG.MSG.Msg_Run_Error);
                    clsDB.FunClsDB();
                    return false;
                }
                #endregion
                #endregion

                //產生命令主檔
                #region 產生命令主檔
                cls_CmdMst aCmdMst = new cls_CmdMst();

                aCmdMst.FunCmdMstClear();   //Clear()
                aCmdMst.CMDSNO = sCmdSnoNew;
                aCmdMst.SNO1 = "1";
                aCmdMst.LOC1 = sGetLoc1;
                aCmdMst.LOCID1 = get_LocID;
                aCmdMst.SCAN1 = "Y";

                aCmdMst.SNO2 = "";
                aCmdMst.LOC2 = "";
                aCmdMst.LOCID2 = "";
                aCmdMst.SCAN2 = "N";
                aCmdMst.CMDMODE = clsASRS.gsCmdMode_In;   //入庫                    

                aCmdMst.CMDSTS = "0";
                aCmdMst.PRT = "5";
                aCmdMst.STNNO = sStnNo;
                if (bFlagA == false)
                {
                    aCmdMst.IOTYP = clsASRS.gsIOTYPE_EmptyIn;   //空料盒入庫
                    aCmdMst.AVAIL = "0";  // 彰化廠
                    aCmdMst.MIXQTY = "0";   // 彰化廠
                    //aCmdMst.PROGID = clsASRS.gsIOTYPE_EmptyIn_PID;
                    aCmdMst.PROGID = clsASRS.gsIOTYPE_WMS_Out_PID;
                }
                else
                {
                    aCmdMst.IOTYP = clsASRS.gsIOTYPE_WMS_Out;   //WMS 出庫
                    aCmdMst.AVAIL = "100";  // 彰化廠
                    aCmdMst.MIXQTY = "1";   // 彰化廠
                    aCmdMst.PROGID = clsASRS.gsIOTYPE_WMS_Out_PID;
                }
                aCmdMst.NEWLOC = "";
                //aCmdMst.PROGID = sProgID;
                aCmdMst.USERID = sUserID;
                aCmdMst.TRACE = "0";
                aCmdMst.STORAGETYP = "";
                if (aCmdMst.FunInsCmdMst() == false)
                {
                    clsDB.FunCommitCtrl("ROLLBACK");
                    clsMSG.ShowWarningMsg("處理失敗");
                    clsDB.FunClsDB(); return false;
                }

                #endregion

                //產生命令明細檔
                #region 產生命令明細檔
                if (bFlagA == true)
                {
                    sSQL = "INSERT INTO CMD_DTL (CMDSNO,LocID,SNO,ITEMNO,CUSTOMER,DEVICE,LOTNO,STORE,";
                    sSQL = sSQL + "OFFQTY,WAFERQTY,SHIPQTY,OFFACTQTY,WAFERACTQTY,SHIPACTQTY,";
                    sSQL = sSQL + "FLAGQTY,CHKIQC,FOSBID,IQC_ID,ACC_ID,INDATE,REMARK,TRANSACTION_DATE,";
                    sSQL = sSQL + "GIB_CUSTOMER,FAB_LOT_NO,FAB_TYPE,TYPENO,LOT_TYPE,WAFER_SIZE,YIELD,";
                    sSQL = sSQL + "APP_NO,REL_DATE,REASON_NAME,TRANSACTION_REFERENCE,TRANSACTION_SOURCE_ID,";
                    sSQL = sSQL + "TRANSACTION_TYPE_ID,FROM_ORG,TO_ORG,FROM_BANK,TO_BANK,CYCLENO,COID,SNID,DOCID,DOCID2) ";
                    sSQL = sSQL + "(SELECT '" + sCmdSnoNew + "',LocID,SNO,ITEMNO,CUSTOMER,DEVICE,LOTNO,STORE,";
                    sSQL = sSQL + "OFFQTY,WAFERQTY,SHIPQTY,OFFACTQTY,WAFERACTQTY,SHIPACTQTY,";
                    sSQL = sSQL + "FLAGQTY,CHKIQC,FOSBID,IQC_ID,ACC_ID,INDATE,REMARK,TRANSACTION_DATE,";
                    sSQL = sSQL + "GIB_CUSTOMER,FAB_LOT_NO,FAB_TYPE,TYPENO,LOT_TYPE,WAFER_SIZE,YIELD,";
                    sSQL = sSQL + "APP_NO,REL_DATE,REASON_NAME,TRANSACTION_REFERENCE,TRANSACTION_SOURCE_ID,";
                    sSQL = sSQL + "TRANSACTION_TYPE_ID,FROM_ORG,TO_ORG,FROM_BANK,TO_BANK,CYCLENO,COID,SNID,DOCID,DOCID2 ";
                    sSQL = sSQL + "FROM CMD_DTL WHERE CMDSNO = '" + get_CmdSno + "' AND LOCID = '" + get_LocID + "')";
                    if (clsDB.FunExecSql(sSQL) == false)
                    {
                        clsDB.FunCommitCtrl("ROLLBACK");
                        clsMSG.ShowWarningMsg(clsMSG.MSG.Msg_Run_Error);
                        clsDB.FunClsDB();
                        return false;
                    }
                }
                #endregion
                
                clsDB.FunCommitCtrl("COMMIT");    // 'COMMIT
                clsDB.FunClsDB();
                return true;
            }
            else
            {

                clsDB.FunCommitCtrl("BEGIN");
                //3.UPDATE資料至CMD_DTL裡
                if (FunDelWithCmd_CMD_DTL(bIsInsData) == false)
                {
                    clsDB.FunCommitCtrl("ROLLBACK"); clsDB.FunClsDB(); return false;
                }

                //4.更新 CMD_MST's 
                if (FunDelWithCmd_CMD_MST() == false)
                {
                    clsDB.FunCommitCtrl("ROLLBACK"); clsDB.FunClsDB(); return false;
                }

                clsDB.FunCommitCtrl("COMMIT");
                clsDB.FunClsDB();
                return true;
            }
        }

        private bool FunDelWithCmd_CMD_DTL(bool bIsInsData)
        {
            int i = 0; string sSQL = "";

            if (gsLocStyle == "A")
            {


            }
            else
            {
                //************************************************************
                //FOSB
                //************************************************************
                if (bIsInsData == true)
                {
                    #region CMD_DTL
                    for (i = 0; i <= Grid1.RowCount - 1; i++)
                    {
                        if (Grid1[iCol2_LotNo, i].Value.ToString() == "") { break; }

                        sSQL = "UPDATE CMD_DTL SET WAFERACTQTY = " + clsTool.INT(Grid1[iCol2_WaferQty, i].Value.ToString()) + ",";
                        sSQL = sSQL + "SHIPACTQTY = " + clsTool.INT(Grid1[iCol2_ShipQty, i].Value.ToString()) + " ";
                        sSQL = sSQL + "WHERE CMDSNO = '" + get_CmdSno + "' ";
                        //    sSQL = sSQL & "AND LOC = '" & .Item(iCol2_Loc, i).Value & "' ";
                        sSQL = sSQL + "AND LOCID = '" + get_LocID + "' ";
                        sSQL = sSQL + "AND ITEMNO = '" + Grid1[iCol2_ItemNo, i].Value.ToString() + "' ";
                        sSQL = sSQL + "AND LOTNO = '" + Grid1[iCol2_LotNo, i].Value.ToString() + "' ";
                        sSQL = sSQL + "AND FOSBID = '" + Grid1[iCol2_FOSBID, i].Value.ToString() + "' ";
                        if (clsDB.FunExecSql(sSQL) == false)
                        {
                            clsMSG.ShowWarningMsg(clsMSG.MSG.Msg_Run_Error);
                            return false;
                        }
                    }
                    #endregion


                    
                    int y = 0; int j = 0;
                    for (j = 0; j <= Grid1.RowCount - 1; j++)
                    {
                        #region check
                        bool bFlag = true;
                        if (j == 0)
                        {
                            bFlag = true;
                        }
                        else
                        {
                            for (y = 0; y <= j - 1; y++)
                            {
                                if (Grid1[iCol2_FOSBID, j].Value.ToString() == Grid1[iCol2_FOSBID, y].Value.ToString())
                                {
                                    bFlag = false;
                                    break;
                                }
                            }
                        }
                        #endregion

                                                

                        if (bFlag == true)
                        {
                            #region TB_ASRS_TO_WMS_TEMP
                            //V.2
                            if (lblHelp.Visible == false)
                            {

                                //issue 這邊要寫只更新一筆收料序號 (Yulin) 多批會有問題
                                sSQL = "UPDATE TB_ASRS_TO_WMS_TEMP SET SEND_ASRS = 'F', ";
                                sSQL = sSQL + "USER_NAME = '" + clsASRS.gstrLoginUser + "', ";
                                sSQL = sSQL + "TXN_DATE = '" + clsTool.GetDateTimeForWMS() + "' ";
                                sSQL = sSQL + "WHERE RCVNO = '" + Grid1[iCol2_FOSBID, j].Value.ToString() + "' ";
                                sSQL = sSQL + "AND STATUS = 'A' AND SEND_ASRS = 'A' ";
                                sSQL = sSQL + "AND TYPE IN ('UPDATE_DATA','STOCKOUT') ";
                                if (clsDB.FunExecSql(sSQL) == false)
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                sSQL = "UPDATE TB_ASRS_TO_WMS_TEMP SET SEND_ASRS = 'F', ";
                                sSQL = sSQL + "USER_NAME = '" + clsASRS.gstrLoginUser + "', ";
                                sSQL = sSQL + "TXN_DATE = '" + clsTool.GetDateTimeForWMS() + "' ";
                                sSQL = sSQL + "WHERE RCVNO = '" + Grid1[iCol2_FOSBID, j].Value.ToString() + "' ";
                                sSQL = sSQL + "AND STATUS = 'A' AND SEND_ASRS = 'A' ";
                                sSQL = sSQL + "AND TYPE = 'UPDATE_DATA' ";
                                if (clsDB.FunExecSql(sSQL) == false)
                                {
                                    return false;
                                }
                            }
                            #endregion
                        }
                    }
                }
            }            

            return true;
        }

        private bool FunDelWithCmd_CMD_MST()
        {
            string sSQL = "";

            sSQL = "UPDATE CMD_MST SET SCAN = 'Y',MIXQTY = 0,AVAIL = 0 ";
            sSQL = sSQL + "WHERE CMDSNO = '" + get_CmdSno + "' ";
            sSQL = sSQL + "AND LOCID = '" + get_LocID + "' ";
            sSQL = sSQL + "AND CMDSTS <= '7' ";
            //sSQL = sSQL + "AND CMDMODE IN ('1','3') "; //2
            if (clsDB.FunExecSql(sSQL) == false)
            {
                clsMSG.ShowWarningMsg(clsMSG.MSG.Msg_Run_Error);
                return false;
            }

            return true;
        }
        #endregion

        
        //***************************************************************************************************
        //取消
        //***************************************************************************************************
        private void btnReturn_Click(object sender, EventArgs e)
        {
            #region 檢查
            if (get_CmdSno == "")
            {
                clsMSG.ShowInformationMsg("請先刷料盤條碼");
                txtScan.Select();
                return;
            }

            if (FunChkFOSBIsScan() == false)
            {
                clsMSG.ShowWarningMsg("有刷FOSB收料序號條碼,不可以按'料盤直接回庫'!!");
                txtScan.Select();
                return;
            }
            #endregion

            #region 顯示提示視窗
            string sMsg = "";
            sMsg = "您確定FOSB不做出庫功能,直接讓料盒回ASRS儲位嗎?";
            if (clsMSG.ShowQuestionMsg(sMsg) == true)
            {
                sMsg = "請再次確認,以免料帳不一致,確定FOSB不做出庫功能直接讓料盒回ASRS儲位嗎?";
                if (clsMSG.ShowQuestionMsg(sMsg) == false)
                {
                    txtScan.Select();
                }
            }
            else
            {
                txtScan.Select();
                return;
            }
            #endregion


            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };

            #region 找出命令模式
            string sSQL = ""; DbDataReader dbRS = null;
            string sCmdMode = ""; string sIOTYP = ""; string sStnNo = ""; string sProgID = ""; string sUserID = "";
            sSQL = "SELECT * FROM CMD_MST WHERE CMDSNO = '" + get_CmdSno + "' AND LOCID = '" + get_LocID + "' ";
            if (clsDB.FunRsSql(sSQL, ref dbRS))
            {
                while (dbRS.Read())
                {
                    sCmdMode = dbRS["CMDMODE"].ToString();
                    sIOTYP = dbRS["IOTYP"].ToString();
                    sStnNo = dbRS["STNNO"].ToString();
                    sProgID = dbRS["PROGID"].ToString();
                    sUserID = dbRS["USERID"].ToString();
                }
                dbRS.Close();
            }
            #endregion

            if (sCmdMode == "2")
            {
                #region 找儲位
                //尋找空儲位 (一定是一個空儲位) 只有入一個      
                int iCrn = 0;
                iCrn = clsASRS.FunGetCraneNoByLocID(get_LocID); //由料盒ID取得是那一座Crane
                int iBayDesc = 1; //從前面找起

                string sGetLoc1 = ""; string sGetLocID1 = "";
                if (clsASRS.FunGetLocN_ByS(iCrn, ref sGetLoc1, ref sGetLoc1, iBayDesc) == false)
                {
                    clsMSG.ShowWarningMsg("無合適之空儲位!!"); clsDB.FunClsDB(); return;
                }
                #endregion

                #region 找命令
                string sCmdSnoNew = clsASRS.FunGetCmdSno();
                if (sCmdSnoNew == "") { clsMSG.ShowErrMsg("系統錯誤!!"); clsDB.FunClsDB(); return; }
                #endregion

                //string sMsg = "";
                clsDB.FunCommitCtrl("BEGIN");

                SubStkOutRollback();

                #region 預約儲位
                //預約儲位為入庫預約
                if (clsASRS.FunSetLocIsPreStkIn(sGetLoc1, "", ref sMsg) == false)
                {
                    clsDB.FunCommitCtrl("ROLLBACK");
                    clsMSG.ShowWarningMsg(sMsg);
                    clsDB.FunClsDB(); return;
                }
                #endregion

                //更新old命令
                #region 更新 Old命令
                if (FunDelWithCmd_CMD_MST() == false)
                {
                    clsDB.FunCommitCtrl("ROLLBACK"); clsDB.FunClsDB(); return;
                }
                #endregion


                //產生命令主檔
                #region 產生命令主檔
                cls_CmdMst aCmdMst = new cls_CmdMst();

                aCmdMst.FunCmdMstClear();   //Clear()
                aCmdMst.CMDSNO = sCmdSnoNew;
                aCmdMst.SNO1 = "1";
                aCmdMst.LOC1 = sGetLoc1;
                aCmdMst.LOCID1 = get_LocID;
                aCmdMst.SCAN1 = "Y";

                aCmdMst.SNO2 = "";
                aCmdMst.LOC2 = "";
                aCmdMst.LOCID2 = "";
                aCmdMst.SCAN2 = "N";
                aCmdMst.CMDMODE = clsASRS.gsCmdMode_In;   //入庫                    

                aCmdMst.CMDSTS = "0";
                aCmdMst.PRT = "5";
                aCmdMst.STNNO = sStnNo;
                aCmdMst.IOTYP = clsASRS.gsIOTYPE_WMS_Out;
                aCmdMst.AVAIL = "100";  // 彰化廠
                aCmdMst.MIXQTY = "1";   // 彰化廠
                aCmdMst.NEWLOC = "";
                aCmdMst.PROGID = sProgID;
                aCmdMst.USERID = sUserID;
                aCmdMst.TRACE = "0";
                aCmdMst.STORAGETYP = "";
                if (aCmdMst.FunInsCmdMst() == false)
                {
                    clsDB.FunCommitCtrl("ROLLBACK");
                    clsMSG.ShowWarningMsg("處理失敗");
                    clsDB.FunClsDB(); return;
                }

                #endregion

                //產生命令明細檔
                #region 產生命令明細檔
                sSQL = "INSERT INTO CMD_DTL (CMDSNO,LocID,SNO,ITEMNO,CUSTOMER,DEVICE,LOTNO,STORE,";
                sSQL = sSQL + "OFFQTY,WAFERQTY,SHIPQTY,OFFACTQTY,WAFERACTQTY,SHIPACTQTY,";
                sSQL = sSQL + "FLAGQTY,CHKIQC,FOSBID,IQC_ID,ACC_ID,INDATE,REMARK,TRANSACTION_DATE,";
                sSQL = sSQL + "GIB_CUSTOMER,FAB_LOT_NO,FAB_TYPE,TYPENO,LOT_TYPE,WAFER_SIZE,YIELD,";
                sSQL = sSQL + "APP_NO,REL_DATE,REASON_NAME,TRANSACTION_REFERENCE,TRANSACTION_SOURCE_ID,";
                sSQL = sSQL + "TRANSACTION_TYPE_ID,FROM_ORG,TO_ORG,FROM_BANK,TO_BANK,CYCLENO,COID,SNID,DOCID,DOCID2) ";
                sSQL = sSQL + "(SELECT '" + sCmdSnoNew + "',LocID,SNO,ITEMNO,CUSTOMER,DEVICE,LOTNO,STORE,";
                sSQL = sSQL + "OFFQTY,WAFERQTY,SHIPQTY,OFFACTQTY,WAFERACTQTY,SHIPACTQTY,";
                sSQL = sSQL + "FLAGQTY,CHKIQC,FOSBID,IQC_ID,ACC_ID,INDATE,REMARK,TRANSACTION_DATE,";
                sSQL = sSQL + "GIB_CUSTOMER,FAB_LOT_NO,FAB_TYPE,TYPENO,LOT_TYPE,WAFER_SIZE,YIELD,";
                sSQL = sSQL + "APP_NO,REL_DATE,REASON_NAME,TRANSACTION_REFERENCE,TRANSACTION_SOURCE_ID,";
                sSQL = sSQL + "TRANSACTION_TYPE_ID,FROM_ORG,TO_ORG,FROM_BANK,TO_BANK,CYCLENO,COID,SNID,DOCID,DOCID2 ";
                sSQL = sSQL + "FROM CMD_DTL WHERE CMDSNO = '" + get_CmdSno + "' AND LOCID = '" + get_LocID + "')";
                if (clsDB.FunExecSql(sSQL) == false)
                {
                    clsDB.FunCommitCtrl("ROLLBACK");
                    clsMSG.ShowWarningMsg(clsMSG.MSG.Msg_Run_Error);
                    clsDB.FunClsDB();
                    return;
                }
                #endregion



                clsDB.FunCommitCtrl("COMMIT");    // 'COMMIT
                clsDB.FunClsDB();
            }
            else
            {
                clsDB.FunCommitCtrl("BEGIN");

                SubStkOutRollback();


                if (FunDelWithCmd_CMD_MST() == false)
                {
                    clsDB.FunCommitCtrl("ROLLBACK"); clsDB.FunClsDB(); return;
                }

                clsDB.FunCommitCtrl("COMMIT");
                clsDB.FunClsDB();
            }
            SubClearInit();
            SubQueryWmsOutData();
        }

        private bool FunChkFOSBIsScan()
        {
            int i = 0;

            if (gsLocStyle == "A")
            {



            }
            else
            {
                //************************************************************
                //FOSB
                //************************************************************
                if ((lblLimit.Text.Length) > 2)
                {
                    if (lblLimit.Text.Substring(0, 1) == "O")
                    {
                        for (i = 0; i <= Grid1.RowCount - 1; i++)
                        {
                            if (Grid1[iCol2_FLAGQTY, i].Value.ToString() == "O")
                            {
                                //沒有被刷過
                            }
                            else if (Grid1[iCol2_FLAGQTY, i].Value.ToString() == "Y")
                            {
                                //有被刷過
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
        }

        private void SubStkOutRollback()
        {
            string sSQL = "";
            int i = 0;

            if (gsLocStyle == "A")
            {


            }
            else
            {
                //************************************************************
                //FOSB
                //************************************************************
                for (i = 0; i <= Grid1.RowCount - 1; i++)
                {
                    if (Grid1[iCol2_LotNo, i].Value.ToString() == "") { break; }

                    if (Grid1[iCol2_FLAGQTY, i].Value.ToString() == "O")
                    {
                        //'V.2
                        if (lblHelp.Visible == false)
                        {
                            sSQL = "UPDATE TB_ASRS_TO_WMS_TEMP SET SEND_ASRS = 'Y', ";
                            sSQL = sSQL + "USER_NAME = '" + clsASRS.gstrLoginUser + "', ";
                            sSQL = sSQL + "TXN_DATE = '" + clsTool.GetDateTimeForWMS() + "' ";
                            sSQL = sSQL + "WHERE RCVNO = '" + Grid1[iCol2_FOSBID, i].Value.ToString() + "' ";
                            sSQL = sSQL + "AND STATUS = 'A' AND SEND_ASRS = 'A' ";
                            sSQL = sSQL + "AND TYPE IN ('UPDATE_DATA','STOCKOUT') ";
                            if (clsDB.FunExecSql(sSQL))
                            {

                            }
                        }                     

                    }

                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            SubQueryWmsOutData();
        }

        private void SubQueryWmsOutData()
        {
            string strSql = ""; DbDataReader dbRS = null;

            Grid2.RowCount = 0;
            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };
          
            //strSql = "SELECT T.DOCTYP,T.DOCID,D.FOSBID,D.LOTNO,T.CREATION_BY ";
            //strSql = strSql + "FROM CMD_DTL D LEFT JOIN TB_ASRS_TO_WMS_TEMP T ";
            //strSql = strSql + "ON D.CYCLENO = CAST(T.SNID as varchar ) ";
            //strSql = strSql + "WHERE D.CMDSNO IN (";
            //strSql = strSql + "SELECT CMDSNO FROM CMD_MST WHERE IOTYP IN ('27','28') AND CMDMODE IN ('2','3') AND SCAN = 'N') ";


            strSql = "SELECT T.DOCTYP,T.DOCID,D.FOSBID,D.LOTNO,T.CREATION_BY,D.STNNO ";
            strSql = strSql + "FROM (SELECT M.CMDSNO,M.LOCID,M.STNNO,D.FOSBID,D.LOTNO,D.CYCLENO FROM CMD_MST M, CMD_DTL D ";
            strSql = strSql + "WHERE M.CMDSNO = D.CMDSNO AND M.LOCID = D.LOCID ";
            strSql = strSql + "AND IOTYP IN ('27','28') AND CMDMODE IN ('2','3') AND SCAN = 'N' ) D ";
            strSql = strSql + "LEFT JOIN TB_ASRS_TO_WMS_TEMP T  ";
            strSql = strSql + "ON D.CYCLENO = CAST(T.SNID as varchar ) ";

            if (clsDB.FunRsSql(strSql, ref dbRS))
            {
                while (dbRS.Read())
                {
                    Grid2.Rows.Add();
                    Grid2[iCol_Type, Grid2.RowCount - 1].Value = dbRS["DOCTYP"].ToString();
                    Grid2[iCol_DOCID, Grid2.RowCount - 1].Value = dbRS["DOCID"].ToString();
                    Grid2[iCol_RCVNO, Grid2.RowCount - 1].Value = dbRS["FOSBID"].ToString();
                    Grid2[iCol_LOTNO, Grid2.RowCount - 1].Value = dbRS["LOTNO"].ToString();
                    Grid2[iCol_STNNO, Grid2.RowCount - 1].Value = dbRS["STNNO"].ToString();
                 }
                dbRS.Close();
            }
                                  
            clsDB.FunClsDB();

        }






    }
}
