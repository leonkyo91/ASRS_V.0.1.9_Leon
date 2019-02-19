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
    public partial class frm_WMS_STK_IN_IQC_Receive : Form
    {
        #region Grid Parameter
        int iCol2_Customer = 0;             
        int iCol2_ItemNo = 1;              
        int iCol2_LotNo = 2;               
        int iCol2_FOSBID = 3;               
        int iCol2_WMSLOC = 4;
        int iCol2_WaferQty = 5;             
        int iCol2_ShipQty = 6;              
        int iCol2_FAB_LOT_NO = 7;
        int iCol2_Device = 8;               

        int iCol2_REMARK = 9;
        int iCol2_TRANSACTION_DATE = 10;    
        int iCol2_GIB_CUSTOMER = 11;

        int iCol2_FAB_TYPE = 12;
        int iCol2_TYPENO = 13;
        int iCol2_LOT_TYPE = 14;
        int iCol2_WAFER_SIZE = 15;
        int iCol2_YIELD = 16;
        int iCol2_APP_NO = 17;
        int iCol2_REL_DATE = 18;
        int iCol2_REASON_NAME = 19;
        int iCol2_TRANSACTION_REFERENCE = 20;
        int iCol2_TRANSACTION_SOURCE_ID = 21;
        int iCol2_TRANSACTION_TYPE_ID = 22;
        int iCol2_FROM_ORG = 23;
        int iCol2_TO_ORG = 24;
        int iCol2_FROM_BANK = 25;
        int iCol2_TO_BANK = 26;
        int iCol2_INDATE = 27; 
        int iCol2_ChkIQC = 28; 
        int iCol2_FLAGQTY = 29;

        int iCol2_SEQ_NO = 30; 
        int iCol2_COID = 31;   
        int iCol2_DOCID = 32;
        int iCol2_WMS_STS = 33;
        int iCol2_Counts = 34;
        #endregion


        int iCol1_FOSBID = 0;
        int iCol1_LOTNO = 1;
        int iCol1_Counts = 2;

        string get_CmdSno="";
        string get_Loc = "";
        string get_LocID = "";
        string get_Sno = "";

        string gsLocStyle = "";
        int giLeft = 0;
        int giRight = 0;
        string gsWMSLOC = "";

        
        public frm_WMS_STK_IN_IQC_Receive()
        {
            InitializeComponent();
        }

        private void frm_WMS_STK_IN_IQC_Receive_Load(object sender, EventArgs e)
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
            //oGrid.RowCount = 1;

            oGrid.Columns[iCol2_Customer].Width = 90 ; oGrid.Columns[iCol2_Customer].Name = "客戶名稱";
            oGrid.Columns[iCol2_ItemNo].Width = 100 ; oGrid.Columns[iCol2_ItemNo].Name = "ITEM";
            oGrid.Columns[iCol2_LotNo].Width = 100 ; oGrid.Columns[iCol2_LotNo].Name = "LOT NO";
            oGrid.Columns[iCol2_FOSBID].Width = 110 ; oGrid.Columns[iCol2_FOSBID].Name = "收料序號";
            oGrid.Columns[iCol2_WMSLOC].Width = 140 ; oGrid.Columns[iCol2_WMSLOC].Name = "WMS儲位";
            oGrid.Columns[iCol2_WaferQty].Width = 70 ; oGrid.Columns[iCol2_WaferQty].Name = "枚數";
            oGrid.Columns[iCol2_ShipQty].Width = 70 ; oGrid.Columns[iCol2_ShipQty].Name = "數量";
            oGrid.Columns[iCol2_FAB_LOT_NO].Width = 110 ; oGrid.Columns[iCol2_FAB_LOT_NO].Name = "晶圓批號";
            oGrid.Columns[iCol2_Device].Width = 100 ; oGrid.Columns[iCol2_Device].Name = "DEVICE";
            
            oGrid.Columns[iCol2_REMARK].Width = 100 ; oGrid.Columns[iCol2_REMARK].Name = "備註";
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
            oGrid.Columns[iCol2_COID].Width = 100; oGrid.Columns[iCol2_COID].Name = "COID";          //廠區   (WMS)
            oGrid.Columns[iCol2_COID].Visible = false;
            oGrid.Columns[iCol2_DOCID].Width = 100; oGrid.Columns[iCol2_DOCID].Name = "WMS上架單號"; //(WMS)
            oGrid.Columns[iCol2_DOCID].Visible = false;
            oGrid.Columns[iCol2_WMS_STS].Width = 50;oGrid.Columns[iCol2_WMS_STS].Name = "Status";   //(WMS)
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
            oGrid.ColumnCount = iCol1_Counts;
            //oGrid.RowCount = 1;

            oGrid.Columns[iCol1_FOSBID].Width = 130; oGrid.Columns[iCol1_FOSBID].Name = "FOSB ID";
            oGrid.Columns[iCol1_LOTNO].Width = 120; oGrid.Columns[iCol1_LOTNO].Name = "LOTNO";




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
        
            get_CmdSno = "";
            get_Loc = "";
            get_LocID = "";
            
            lblCmdSno.Text = "";
            lblLimit.Text = ""; lblLimit.BackColor = Color.White;
            txtFOSB.Text = ""; txtFOSB.BackColor = Color.White;
            txtLocID.Text = ""; txtLocID.BackColor = Color.White;
            
            lblShowMsg.Visible = false;
            giLeft = 0;
            giRight = 0;

            txtScan.Text = "";
            txtScan.Focus();
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



        private void btnCls_Click(object sender, EventArgs e)
        {   
            SubClearInit();
        }

        private void SubClearInit()
        {
            SubQuery2();

            Grid1.RowCount = 0;
            get_CmdSno = "";
            get_Loc = "";
            get_LocID = "";
            get_Sno = "";

            lblCmdSno.Text = "";
            lblLimit.Text = ""; lblLimit.BackColor = Color.White;

            txtLocID.Text = ""; txtLocID.BackColor = Color.White;
            txtFOSB.Text = ""; txtFOSB.BackColor = Color.White;
            lblShowMsg.Visible = false;
            giLeft = 0; giRight = 0;//??
            txtScan.Text = ""; txtScan.Select();


        }
                
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //***************************************************************************************************
        // 判別 料盤 條碼
        //***************************************************************************************************
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
            string sCmdSno = ""; string sLoc = ""; string sLocStyle = ""; string sSno = "";

            sSQL = "SELECT * FROM CMD_MST WHERE LOCID = '" + sLocID + "' AND CMDSTS <= '7' AND IOTYP = '" + clsASRS.gsIOTYPE_WMS_In + "' ";
            if (clsDB.FunRsSql(sSQL, ref dbRS))
            {
                while (dbRS.Read())
                {
                    sScan = dbRS["SCAN"].ToString();  //是否Scan
                    sCmdSno = dbRS["CMDSNO"].ToString();
                    sLoc = dbRS["LOC"].ToString();                    
                    sLocStyle = dbRS["STORAGETYP"].ToString();
                    sSno = dbRS["SNO"].ToString();
                }
                dbRS.Close();

                if (sScan == "Y")
                {
                    clsMSG.ShowWarningMsg("料盤己確認過(己經確認執行)");
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
                string sIotype = "";
                sSQL = "SELECT * FROM CMD_MST WHERE LOCID = '" + sLocID + "' AND CMDSTS <= '7' ";
                if (clsDB.FunRsSql(sSQL, ref dbRS))
                {
                    while (dbRS.Read())
                    {
                        sIotype = dbRS["IOTYP"].ToString();
                    }
                    dbRS.Close();

                    if (sIotype != clsASRS.gsIOTYPE_WMS_In)
                    {
                        clsMSG.ShowWarningMsg("命令不是WMS入庫功能");
                        return false;
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
                lblShowMsg.Visible = true;
            }
            else
            {
                lblShowMsg.Visible = false;
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
                        // 有資料
                        lblLimit.Text = "X:禁止取貨 (原有的資料）";
                        lblLimit.BackColor = Color.Red;

                        Grid1.Rows.Add();

                        #region
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
                        #endregion
                    }
                    dbRS.Close();
                }
                else
                {
                    
                }

            }

        }


        //***************************************************************************************************
        // 判別 FOSB 條碼
        //***************************************************************************************************
        private void SubReadFOSBID(string sValue)
        {
            //1.判別變數 get_LocID 是否存在
            if (SubReadFosbID_get_LocID() == false) 
            {
                btnCls.PerformClick();
                return; 
            }

            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; }

            //2.判別 FOSB條碼 是否重覆 & 判別 FOSB條碼 是否為CMD_DTL的資料
            if (SubReadFosbID_OverLay(sValue) == false) 
            {
                btnCls.PerformClick();
                clsDB.FunClsDB(); return; 
            }

            //3.判別 FOSB條碼是否在儲位中或命令中
            if (SubReadFOSBID_InLoc(sValue) == false) 
            {
                btnCls.PerformClick();
                clsDB.FunClsDB(); return; 
            }

            //4.判別 FOSB條碼 是否在收料檔 並填入 左或右的FOSB's Grid中
            SubReadFOSBID_InputGrid(sValue);

            clsDB.FunClsDB();

            SubExecute();
        }

        #region 判別變數 get_LocID 是否存在
        private bool SubReadFosbID_get_LocID()
        {
            if (get_LocID == "")
            {
                clsMSG.ShowWarningMsg("請先刷料盤條碼");
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region 判別 FOSB條碼 是否重覆 & 判別 FOSB條碼 是否為CMD_DTL的資料
        private bool SubReadFosbID_OverLay(string sValue)
        {
            int i = 0 ; string sGrdFosbID = "";

            for (i = 0; i <= Grid1.RowCount - 1; i++)
            {
                sGrdFosbID = Grid1[iCol2_FOSBID, i].Value.ToString();
                if (sGrdFosbID.IndexOf(".", 0) >= 0)
                {
                    sGrdFosbID = sGrdFosbID.Substring(0, sGrdFosbID.IndexOf(".", 0));
                }
                if (sGrdFosbID == sValue)
                {
                    clsMSG.ShowWarningMsg("FOSB條碼重覆");
                    return false;
                }
            }

            return true;
        }
        #endregion

        #region 判別 FOSB條碼是否在儲位中或命令中
        private bool SubReadFOSBID_InLoc(string sValue)
        {
            string sSQL = ""; DbDataReader dbRS = null;
            int iCnt = 0;
            sSQL = "SELECT COUNT(*) FROM LOC_DTL WHERE FOSBID LIKE '" + sValue + "%' ";
            if (clsDB.FunRsSql(sSQL, ref dbRS))
            {
                while (dbRS.Read())
                {
                    iCnt = clsTool.INT(dbRS[0].ToString());
                }
                dbRS.Close();
            }
            if (iCnt > 0)
            {
                clsMSG.ShowWarningMsg("FOSB條碼己存在 ASRS 庫存裡");
                return false;
            }

            iCnt = 0;
            //sSQL = "SELECT COUNT(*) FROM CMD_MST WHERE CMDSNO IN (";
            //sSQL = sSQL + "SELECT DISTINCT CMDSNO FROM CMD_DTL WHERE FOSBID LIKE '" + sValue + "%') ";
            //sSQL = sSQL + "AND CMDSTS <= '6' ";
            sSQL = "SELECT COUNT(*) FROM CMD_MST M, CMD_DTL D ";
            sSQL = sSQL + "WHERE M.CMDSNO = D.CMDSNO ";
            sSQL = sSQL + "AND M.LOCID = D.LOCID ";
            sSQL = sSQL + "AND D.FOSBID LIKE '" + sValue + "%' ";
            sSQL = sSQL + "AND M.CMDSTS <= '6'";
            if (clsDB.FunRsSql(sSQL,ref dbRS))
            {
                while (dbRS.Read())
                {
                    iCnt = clsTool.INT(dbRS[0].ToString());
                }
                dbRS.Close();
            }
            if (iCnt > 0)
            {
                clsMSG.ShowWarningMsg("FOSB條碼己存在命令資料中");
                return false;
            }

            return true;
        }
        #endregion

        #region 判別 FOSB條碼 是否在收料檔 並填入 左或右的FOSB's Grid中
        private void SubReadFOSBID_InputGrid(string sValue)
        {
            string sSQL = ""; DbDataReader dbRS = null;
            int i = 0;

            //判斷黑扁盒是否己經放了兩個收料序號的盒子
            if (gsLocStyle == "A")
            {
                //Coding
            }

            //V.1.5.1
            //sSQL = "SELECT * FROM TB_ASRS_TO_WMS_TEMP WHERE RCVNO = '" + sValue + "' AND TYPE = 'STOCKIN' AND STATUS = 'A' AND SEND_ASRS = 'Y'  ";
            sSQL = "SELECT * FROM TB_ASRS_TO_WMS_TEMP WHERE RCVNO = '" + sValue + "' AND TYPE = 'STOCKIN' AND STATUS = 'A' AND SEND_ASRS = 'Y' ORDER BY CREATION_DATE DESC ";
            if (clsDB.FunRsSql(sSQL, ref dbRS))
            {
                #region Get WMS's Data
                while (dbRS.Read())
                {
                    bool bIsOverlay = false;
                    for (i = 0; i <= Grid1.RowCount - 1; i++)
                    {
                        if (Grid1[iCol2_FOSBID, i].Value.ToString() == dbRS["RCVNO"].ToString())
                        {
                            if (Grid1[iCol2_LotNo, i].Value.ToString() == dbRS["LOTNO"].ToString())
                            {
                                bIsOverlay = true;
                            }
                        }
                    }

                    if (bIsOverlay == false)
                    {
                        if (txtFOSB.Text == "") { txtFOSB.Text = sValue; } else { txtFOSB.Text = txtFOSB.Text + "," + sValue + " " ; }
                        Grid1.Rows.Add();

                        Grid1[iCol2_WMSLOC, Grid1.Rows.Count - 1].Value = gsWMSLOC;
                        Grid1[iCol2_ItemNo, Grid1.Rows.Count - 1].Value = dbRS["SKUID"].ToString();
                        Grid1[iCol2_Customer, Grid1.Rows.Count - 1].Value = dbRS["CUSNME"].ToString();
                        Grid1[iCol2_Device, Grid1.Rows.Count - 1].Value = dbRS["DEVICE"].ToString();
                        Grid1[iCol2_LotNo, Grid1.Rows.Count - 1].Value = dbRS["LOTNO"].ToString();
                        Grid1[iCol2_WaferQty, Grid1.Rows.Count - 1].Value = dbRS["PIECE"].ToString();
                        Grid1[iCol2_ShipQty, Grid1.Rows.Count - 1].Value = dbRS["DIE"].ToString();
                        Grid1[iCol2_FOSBID, Grid1.Rows.Count - 1].Value = dbRS["RCVNO"].ToString();
                        Grid1[iCol2_REMARK, Grid1.Rows.Count - 1].Value = "";
                        Grid1[iCol2_TRANSACTION_DATE, Grid1.Rows.Count - 1].Value = clsTool.GetDateTime();
                        Grid1[iCol2_GIB_CUSTOMER, Grid1.Rows.Count - 1].Value = "";
                        Grid1[iCol2_FAB_LOT_NO, Grid1.Rows.Count - 1].Value = dbRS["WFRLOTNO"].ToString();
                        Grid1[iCol2_FAB_TYPE, Grid1.Rows.Count - 1].Value = "";
                        Grid1[iCol2_TYPENO, Grid1.Rows.Count - 1].Value = "";
                        Grid1[iCol2_LOT_TYPE, Grid1.Rows.Count - 1].Value = "";
                        Grid1[iCol2_WAFER_SIZE, Grid1.Rows.Count - 1].Value = "";
                        Grid1[iCol2_YIELD, Grid1.Rows.Count - 1].Value = "";
                        Grid1[iCol2_APP_NO, Grid1.Rows.Count - 1].Value = "";
                        Grid1[iCol2_REL_DATE, Grid1.Rows.Count - 1].Value = "";
                        Grid1[iCol2_REASON_NAME, Grid1.Rows.Count - 1].Value = "";
                        Grid1[iCol2_TRANSACTION_REFERENCE, Grid1.Rows.Count - 1].Value = "";
                        Grid1[iCol2_TRANSACTION_SOURCE_ID, Grid1.Rows.Count - 1].Value = "";
                        Grid1[iCol2_TRANSACTION_TYPE_ID, Grid1.Rows.Count - 1].Value = "";
                        Grid1[iCol2_FROM_ORG, Grid1.Rows.Count - 1].Value = "";
                        Grid1[iCol2_TO_ORG, Grid1.Rows.Count - 1].Value = "";
                        Grid1[iCol2_FROM_BANK, Grid1.Rows.Count - 1].Value = "";
                        Grid1[iCol2_TO_BANK, Grid1.Rows.Count - 1].Value = "";
                        Grid1[iCol2_ChkIQC, Grid1.Rows.Count - 1].Value = "N";
                        Grid1[iCol2_INDATE, Grid1.Rows.Count - 1].Value = clsTool.GetDateTime();
                        Grid1[iCol2_FLAGQTY, Grid1.Rows.Count - 1].Value = "A";

                        Grid1[iCol2_SEQ_NO, Grid1.Rows.Count - 1].Value = dbRS["SNID"].ToString();
                        Grid1[iCol2_COID, Grid1.Rows.Count - 1].Value = "";
                        Grid1[iCol2_DOCID, Grid1.Rows.Count - 1].Value = "";
                        Grid1[iCol2_WMS_STS, Grid1.Rows.Count - 1].Value = "";
                    }
                }
                dbRS.Close();
                #endregion
            }
            else
            {
                bool bData = false;
                sSQL = "SELECT * FROM TB_ASRS_TO_WMS_TEMP WHERE RCVNO = '" + sValue + "' AND TYPE ='STOCKIN' AND STATUS = 'C' AND SEND_ASRS = 'Y' ";
                if (clsDB.FunRsSql(sSQL, ref dbRS))
                {
                    while (dbRS.Read())
                    {
                        bData = true;
                    }
                    dbRS.Close();

                    if (bData == true)
                    {
                        string sMsg = "此收料序號入庫需求已取消!!\r\n";
                        sMsg = sMsg + "請確認是否還執行入庫!!\r\n";
                        sMsg = sMsg + "若是不需要，請點選'空料盤直接回庫'.";
                        clsMSG.ShowErrMsg(sMsg);
                        return;
                    }
                    else
                    {
                        clsMSG.ShowErrMsg("無WMS資料");
                        btnCls.PerformClick();
                        return;
                    }
                }
                else
                {
                    clsMSG.ShowErrMsg("無WMS資料");
                    btnCls.PerformClick();
                }
            }
        }
        #endregion

        private void btnExecute_Click(object sender, EventArgs e)
        {
            SubExecute();
        }

        private void SubExecute()
        {
            if (get_CmdSno == "") { return; }

            if (gsLocStyle == "A")
            {
                //黑扁盒

            }
            else
            {
                //FOSB
                //判斷有刷料盤但沒有刷FOSB條碼
                if (FunDelWithCmd_ChkNoScan() == false)
                {
                    clsMSG.ShowWarningMsg("料盤上並沒有放置新的資料");
                    txtScan.Focus();
                    return;
                }




                //處理資料,將資料寫入命令檔
                if (FunDelwithCmd() == true)
                {
                    clsMSG.ShowInformationMsg("資料己處理完畢,請繼續執行入庫動作");
                    SubClearInit();
                }
            }

        }

        private bool FunDelWithCmd_ChkNoScan()
        {
            if (lblLimit.Text.Length > 0)
            {
                return false;
            }
            else
            {
                if (Grid1.RowCount <= 0)
                {
                    return false;
                }
            }

            return true;
        }


        //處理命令
        private bool FunDelwithCmd()
        {
            if (clsDB.FunOpenDB() == false) { 
                clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG);
                return false;
            }


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

                if (clsASRS.FunGetLocN_ByS(iCrn, ref sGetLoc1, ref sGetLocID1, iBayDesc) == false)
                {
                    clsMSG.ShowWarningMsg("無合適之空儲位!!"); clsDB.FunClsDB(); return false;
                }
                
                ////(1)先找內側儲位為N,外側儲位為S
                //if (clsASRS.FunGetLocForSingleListByInOutLoc(iCrn, "N", "S", 1, ref sGetLoc1, ref sGetLocID1) == false)
                //{
                //    //(2)找內側儲位為N,外側儲位為S. (TEMP 儲位)
                //    if (clsASRS.FunGetLocForSingleListByInOutLoc_StorageTyp_Temp(iCrn, "N", "S", 1, ref sGetLoc1, ref sGetLocID1, iBayDesc) == false)
                //    {
                //        //(3)找外側儲位為N,內側儲位為N. (TEMP 儲位)
                //        if (clsASRS.FunGetLocForSingleListByInOutLoc_StorageTyp_Temp(iCrn, "N", "N", 2, ref sGetLoc1, ref sGetLocID1, iBayDesc) == false)
                //        {
                //            //(4)找外側儲位為N,內側儲位為N,
                //            if (clsASRS.FunGetLocForSingleListByInOutLoc(iCrn, "N", "N", 2, ref sGetLoc1, ref sGetLocID1) == false)
                //            {
                //                clsMSG.ShowWarningMsg("無合適之空儲位!!"); clsDB.FunClsDB(); return false;
                //            }
                //        }
                //    }
                //}
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

                //更新Old命令主檔
                #region 更新Old命令主檔
                sSQL = "UPDATE CMD_MST SET SCAN = 'Y', CMDSTS = '7' WHERE CMDSNO = '" + get_CmdSno + "' AND CMDSTS <= '7' ";
                if (clsDB.FunExecSql(sSQL) == false)
                {
                    clsDB.FunCommitCtrl("ROLLBACK");
                    clsMSG.ShowWarningMsg(clsMSG.MSG.Msg_Run_Error);
                    clsDB.FunClsDB();
                    return false;
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
                //---- no data on 第2盒  ----
                aCmdMst.SNO2 = "";
                aCmdMst.LOC2 = "";
                aCmdMst.LOCID2 = "";
                aCmdMst.SCAN2 = "N";
                aCmdMst.CMDMODE = clsASRS.gsCmdMode_In;   //入庫                    
                //---------------------------
                aCmdMst.CMDSTS = "0";
                aCmdMst.PRT = "5";
                aCmdMst.STNNO = sStnNo;
                aCmdMst.IOTYP = sIOTYP;
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
                    clsDB.FunClsDB(); return false;
                }

                #endregion

                //產生命令明細檔
                #region 產生命令明細檔
                if (FunDelWithCmd_CMD_DTL_NewIn(sCmdSnoNew, get_LocID) == false)
                {
                    clsDB.FunCommitCtrl("ROLLBACK");
                    clsMSG.ShowWarningMsg(clsMSG.MSG.Msg_Run_Error);
                    clsDB.FunClsDB();
                    return false;
                }
                #endregion


                
                clsDB.FunCommitCtrl("COMMIT");    // 'COMMIT
                clsDB.FunClsDB();
                return true;
            }
            else
            {

                clsDB.FunCommitCtrl("BEGIN");

                //.新增資料至CMD_DTL裡
                if (FunDelWithCmd_CMD_DTL() == false)
                {
                    clsDB.FunCommitCtrl("ROLLBACK");
                    clsDB.FunClsDB();
                    return false;
                }

                if (FunDelWithCmd_CMD_MST() == false)
                {
                    clsDB.FunCommitCtrl("ROLLBACK");
                    clsDB.FunClsDB();
                    return false;
                }

            }
            clsDB.FunCommitCtrl("COMMIT");
            clsDB.FunClsDB();
            return true;
        }


        private bool FunDelWithCmd_CMD_DTL()
        {
            string sSQL = ""; DbDataReader dbRS = null;
            int i = 0;
            cls_CmdDtl tCmdDtl = new cls_CmdDtl();

            for (i = 0; i <= Grid1.RowCount - 1; i++)
            {
                if (Grid1[iCol2_LotNo, i].Value.ToString() != "")
                {
                    #region 寫入CMD_DTL資料
                    if (Grid1[iCol2_FLAGQTY, i].Value.ToString() == "A")
                    {
                        tCmdDtl.FunCmdDtlClear();
                        tCmdDtl.CMDSNO = get_CmdSno;
                        tCmdDtl.SNO = get_Sno;
                        tCmdDtl.LOCID = get_LocID;
                        tCmdDtl.ITEMNO = Grid1[iCol2_ItemNo, i].Value.ToString();
                        tCmdDtl.CUSTOMER = Grid1[iCol2_Customer, i].Value.ToString();
                        tCmdDtl.DEVICE = Grid1[iCol2_Device, i].Value.ToString();
                        tCmdDtl.LOTNO = Grid1[iCol2_LotNo, i].Value.ToString();
                        tCmdDtl.STORE = " ";
                        tCmdDtl.OFFQTY = 0;
                        tCmdDtl.WAFERQTY = 0;   
                        tCmdDtl.SHIPQTY = 0;    
                        tCmdDtl.OFFACTQTY = 0;
                        tCmdDtl.WAFERACTQTY = clsTool.INT(Grid1[iCol2_WaferQty, i].Value.ToString());
                        tCmdDtl.SHIPACTQTY = clsTool.INT(Grid1[iCol2_ShipQty, i].Value.ToString());
                        tCmdDtl.FLAGQTY = clsASRS.gsFlagQty_ADD;
                        tCmdDtl.CHKIQC = "N";
                        tCmdDtl.FOSBID = Grid1[iCol2_FOSBID, i].Value.ToString();
                        tCmdDtl.IQC_ID = " ";
                        tCmdDtl.ACC_ID = " ";
                        tCmdDtl.INDATE = Grid1[iCol2_INDATE, i].Value.ToString();
                        tCmdDtl.REMARK = Grid1[iCol2_REMARK, i].Value.ToString();
                        tCmdDtl.TRANSACTION_DATE = Grid1[iCol2_TRANSACTION_DATE, i].Value.ToString();
                        tCmdDtl.GIB_CUSTOMER = Grid1[iCol2_GIB_CUSTOMER, i].Value.ToString();
                        tCmdDtl.FAB_LOT_NO = Grid1[iCol2_FAB_LOT_NO, i].Value.ToString();
                        tCmdDtl.FAB_TYPE = Grid1[iCol2_FAB_TYPE, i].Value.ToString();
                        tCmdDtl.TYPENO = Grid1[iCol2_TYPENO, i].Value.ToString();
                        tCmdDtl.LOT_TYPE = Grid1[iCol2_LOT_TYPE, i].Value.ToString();
                        tCmdDtl.WAFER_SIZE = Grid1[iCol2_WAFER_SIZE, i].Value.ToString();
                        tCmdDtl.YIELD = Grid1[iCol2_YIELD, i].Value.ToString();
                        tCmdDtl.APP_NO = Grid1[iCol2_APP_NO, i].Value.ToString();
                        tCmdDtl.REL_DATE = Grid1[iCol2_REL_DATE, i].Value.ToString();
                        tCmdDtl.REASON_NAME = Grid1[iCol2_REASON_NAME, i].Value.ToString();
                        tCmdDtl.TRANSACTION_REFERENCE = Grid1[iCol2_TRANSACTION_REFERENCE, i].Value.ToString();
                        tCmdDtl.TRANSACTION_SOURCE_ID = Grid1[iCol2_TRANSACTION_SOURCE_ID, i].Value.ToString();
                        tCmdDtl.TRANSACTION_TYPE_ID = Grid1[iCol2_TRANSACTION_TYPE_ID, i].Value.ToString();
                        tCmdDtl.FROM_ORG = Grid1[iCol2_FROM_ORG, i].Value.ToString();
                        tCmdDtl.TO_ORG = Grid1[iCol2_TO_ORG, i].Value.ToString();
                        tCmdDtl.FROM_BANK = Grid1[iCol2_FROM_BANK, i].Value.ToString();
                        tCmdDtl.TO_BANK = Grid1[iCol2_TO_BANK, i].Value.ToString();
                        tCmdDtl.CYCLENO = Grid1[iCol2_SEQ_NO, i].Value.ToString();
                        tCmdDtl.COID = Grid1[iCol2_COID, i].Value.ToString();
                        tCmdDtl.DOCID = Grid1[iCol2_DOCID, i].Value.ToString();

                        if (tCmdDtl.FunInsCmdDtl() == false)
                        {
                            return false;
                        }
                    }
                    #endregion

                    #region 資料記錄在 TB_ASRS_TO_WMS_TEMP
                    if (SubDealWithWMS(Grid1[iCol2_SEQ_NO, i].Value.ToString(), Grid1[iCol2_WMSLOC, i].Value.ToString(), clsParam.gsDB_User) == false)
                    {
                        return false;
                    }
                    #endregion
                }
            }

            return true;
        }


        private bool FunDelWithCmd_CMD_DTL_NewIn(string sCmdSno, string sLocID)
        {
            int i = 0;
            cls_CmdDtl tCmdDtl = new cls_CmdDtl();

            for (i = 0; i <= Grid1.RowCount - 1; i++)
            {
                if (Grid1[iCol2_LotNo, i].Value.ToString() != "")
                {
                    #region 寫入CMD_DTL資料
                    if (Grid1[iCol2_FLAGQTY, i].Value.ToString() == "A")
                    {
                        tCmdDtl.FunCmdDtlClear();
                        tCmdDtl.CMDSNO = sCmdSno;
                        tCmdDtl.SNO = "1";
                        tCmdDtl.LOCID = sLocID;
                        tCmdDtl.ITEMNO = Grid1[iCol2_ItemNo, i].Value.ToString();
                        tCmdDtl.CUSTOMER = Grid1[iCol2_Customer, i].Value.ToString();
                        tCmdDtl.DEVICE = Grid1[iCol2_Device, i].Value.ToString();
                        tCmdDtl.LOTNO = Grid1[iCol2_LotNo, i].Value.ToString();
                        tCmdDtl.STORE = " ";
                        tCmdDtl.OFFQTY = 0;
                        tCmdDtl.WAFERQTY = 0;
                        tCmdDtl.SHIPQTY = 0;
                        tCmdDtl.OFFACTQTY = 0;
                        tCmdDtl.WAFERACTQTY = clsTool.INT(Grid1[iCol2_WaferQty, i].Value.ToString());
                        tCmdDtl.SHIPACTQTY = clsTool.INT(Grid1[iCol2_ShipQty, i].Value.ToString());
                        tCmdDtl.FLAGQTY = clsASRS.gsFlagQty_ADD;
                        tCmdDtl.CHKIQC = "N";
                        tCmdDtl.FOSBID = Grid1[iCol2_FOSBID, i].Value.ToString();
                        tCmdDtl.IQC_ID = " ";
                        tCmdDtl.ACC_ID = " ";
                        tCmdDtl.INDATE = Grid1[iCol2_INDATE, i].Value.ToString();
                        tCmdDtl.REMARK = Grid1[iCol2_REMARK, i].Value.ToString();
                        tCmdDtl.TRANSACTION_DATE = Grid1[iCol2_TRANSACTION_DATE, i].Value.ToString();
                        tCmdDtl.GIB_CUSTOMER = Grid1[iCol2_GIB_CUSTOMER, i].Value.ToString();
                        tCmdDtl.FAB_LOT_NO = Grid1[iCol2_FAB_LOT_NO, i].Value.ToString();
                        tCmdDtl.FAB_TYPE = Grid1[iCol2_FAB_TYPE, i].Value.ToString();
                        tCmdDtl.TYPENO = Grid1[iCol2_TYPENO, i].Value.ToString();
                        tCmdDtl.LOT_TYPE = Grid1[iCol2_LOT_TYPE, i].Value.ToString();
                        tCmdDtl.WAFER_SIZE = Grid1[iCol2_WAFER_SIZE, i].Value.ToString();
                        tCmdDtl.YIELD = Grid1[iCol2_YIELD, i].Value.ToString();
                        tCmdDtl.APP_NO = Grid1[iCol2_APP_NO, i].Value.ToString();
                        tCmdDtl.REL_DATE = Grid1[iCol2_REL_DATE, i].Value.ToString();
                        tCmdDtl.REASON_NAME = Grid1[iCol2_REASON_NAME, i].Value.ToString();
                        tCmdDtl.TRANSACTION_REFERENCE = Grid1[iCol2_TRANSACTION_REFERENCE, i].Value.ToString();
                        tCmdDtl.TRANSACTION_SOURCE_ID = Grid1[iCol2_TRANSACTION_SOURCE_ID, i].Value.ToString();
                        tCmdDtl.TRANSACTION_TYPE_ID = Grid1[iCol2_TRANSACTION_TYPE_ID, i].Value.ToString();
                        tCmdDtl.FROM_ORG = Grid1[iCol2_FROM_ORG, i].Value.ToString();
                        tCmdDtl.TO_ORG = Grid1[iCol2_TO_ORG, i].Value.ToString();
                        tCmdDtl.FROM_BANK = Grid1[iCol2_FROM_BANK, i].Value.ToString();
                        tCmdDtl.TO_BANK = Grid1[iCol2_TO_BANK, i].Value.ToString();
                        tCmdDtl.CYCLENO = Grid1[iCol2_SEQ_NO, i].Value.ToString();
                        tCmdDtl.COID = Grid1[iCol2_COID, i].Value.ToString();
                        tCmdDtl.DOCID = Grid1[iCol2_DOCID, i].Value.ToString();

                        if (tCmdDtl.FunInsCmdDtl() == false)
                        {
                            return false;
                        }
                    }
                    #endregion

                    #region 資料記錄在 TB_ASRS_TO_WMS_TEMP
                    if (SubDealWithWMS(Grid1[iCol2_SEQ_NO, i].Value.ToString(), Grid1[iCol2_WMSLOC, i].Value.ToString(), clsParam.gsDB_User) == false)
                    {
                        return false;
                    }
                    #endregion
                }
            }

            return true;
        }





        private void btnReturn_Click(object sender, EventArgs e)
        {
            SubReturnTray();
        }

        private void SubReturnTray()
        {
            
            #region 判斷是否有命令
            if (get_CmdSno == "")
            {
                clsMSG.ShowWarningMsg("請先刷料盤條碼");
                txtScan.Focus();
                return;
            }
            #endregion

            #region 顯示提示視窗
            string sMsg = "";
            sMsg = "您確定料盒不放新的FOSB入庫功能,直接讓料盒回ASRS儲位嗎?";
            if (clsMSG.ShowQuestionMsg(sMsg) == true)
            {
                sMsg = "請再次確認,以免料帳不一致,確定直接讓料盒回ASRS儲位嗎?";
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

            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; }


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

                if (clsASRS.FunGetLocN_ByE(iCrn, ref sGetLoc1, ref sGetLocID1, iBayDesc) == false)
                {
                    clsMSG.ShowWarningMsg("無合適之空儲位!!"); clsDB.FunClsDB(); return;
                }

                ////(1)先找內側儲位為N,外側儲位為E
                //if (clsASRS.FunGetLocForSingleListByInOutLoc(iCrn, "N", "E", 1, ref sGetLoc1, ref sGetLocID1) == false)
                //{
                //    //(2)找內側儲位為N,外側儲位為E. (TEMP 儲位)
                //    if (clsASRS.FunGetLocForSingleListByInOutLoc_StorageTyp_Temp(iCrn, "N", "E", 1, ref sGetLoc1, ref sGetLocID1, iBayDesc) == false)
                //    {
                //        //(3)找外側儲位為N,內側儲位為N. (TEMP 儲位)
                //        if (clsASRS.FunGetLocForSingleListByInOutLoc_StorageTyp_Temp(iCrn, "N", "N", 2, ref sGetLoc1, ref sGetLocID1, iBayDesc) == false)
                //        {
                //            //(4)找外側儲位為N,內側儲位為N,
                //            if (clsASRS.FunGetLocForSingleListByInOutLoc(iCrn, "N", "N", 2, ref sGetLoc1, ref sGetLocID1) == false)
                //            {
                //                clsMSG.ShowWarningMsg("無合適之空儲位!!"); clsDB.FunClsDB(); return;
                //            }
                //        }
                //    }
                //}
                #endregion

                #region 找命令
                string sCmdSnoNew = clsASRS.FunGetCmdSno();
                if (sCmdSnoNew == "") { clsMSG.ShowErrMsg("系統錯誤!!"); clsDB.FunClsDB(); return; }
                #endregion

                //string sMsg = "";
                clsDB.FunCommitCtrl("BEGIN");
                #region 預約儲位
                //預約儲位為入庫預約
                if (clsASRS.FunSetLocIsPreStkIn(sGetLoc1, "", ref sMsg) == false)
                {
                    clsDB.FunCommitCtrl("ROLLBACK");
                    clsMSG.ShowWarningMsg(sMsg);
                    clsDB.FunClsDB(); return;
                }
                #endregion

                //更新Old命令主檔
                #region 更新Old命令主檔
                sSQL = "UPDATE CMD_MST SET SCAN = 'Y', CMDSTS = '7' WHERE CMDSNO = '" + get_CmdSno + "' AND CMDSTS <= '7' ";
                if (clsDB.FunExecSql(sSQL) == false)
                {
                    clsDB.FunCommitCtrl("ROLLBACK");
                    clsMSG.ShowWarningMsg(clsMSG.MSG.Msg_Run_Error);
                    clsDB.FunClsDB();
                    return;
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
                //---- no data on 第2盒  ----
                aCmdMst.SNO2 = "";
                aCmdMst.LOC2 = "";
                aCmdMst.LOCID2 = "";
                aCmdMst.SCAN2 = "N";
                aCmdMst.CMDMODE = clsASRS.gsCmdMode_In;   //入庫                    
                //---------------------------
                aCmdMst.CMDSTS = "0";
                aCmdMst.PRT = "5";
                aCmdMst.STNNO = sStnNo;
                aCmdMst.IOTYP = clsASRS.gsIOTYPE_EmptyIn;
                aCmdMst.AVAIL = "0";  // 彰化廠
                aCmdMst.MIXQTY = "0";   // 彰化廠
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


                clsDB.FunCommitCtrl("COMMIT");    // 'COMMIT
                clsDB.FunClsDB();

            }
            else
            {                
                clsDB.FunCommitCtrl("BEGIN");

                if (FunDelWithCmd_CMD_MST() == false)
                {
                    clsDB.FunCommitCtrl("ROLLBACK");
                    clsDB.FunClsDB();
                    txtScan.Focus();
                }

                clsDB.FunCommitCtrl("COMMIT");
                clsDB.FunClsDB();
            }
            SubClearInit();
        }

        private bool FunDelWithCmd_CMD_MST()
        {
            string sSQL = ""; 
            sSQL = "UPDATE CMD_MST SET SCAN = 'Y'";
            sSQL = sSQL + ", MIXQTY = '1', AVAIL = 100 ";   //Importmant
            sSQL = sSQL + "WHERE CMDSNO = '" + get_CmdSno + "' AND LOCID = '" + get_LocID + "' AND CMDSTS <= '6' ";
            if (clsDB.FunExecSql(sSQL) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    

        private bool SubDealWithWMS(string sSNID, string sLocID, string sUserName)
        {
            string sSQL = "UPDATE TB_ASRS_TO_WMS_TEMP SET ";
            sSQL = sSQL + "LOCID = '" + sLocID + "', ";
            sSQL = sSQL + "USER_NAME = '" + clsASRS.gstrLoginUser + "', ";
            sSQL = sSQL + "TXN_DATE = '" + clsTool.GetDateTimeForWMS() + "' ";
            sSQL = sSQL + "WHERE SNID = " + sSNID + "  ";
            if (clsDB.FunExecSql(sSQL) == true)
            {
                return true;
            }
            else
            {
                return false;
            }            
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            SubQuery2();
        }

        private void SubQuery2()
        {
            string sSQL = ""; DbDataReader dbRS = null;
            
            Grid2.RowCount = 0;
            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };

            sSQL = "SELECT * FROM TB_ASRS_TO_WMS_TEMP WHERE DOCTYP = '自動IQC還料清單' AND STATUS = 'A' AND SEND_ASRS = 'Y' ";

            if (clsDB.FunRsSql(sSQL, ref dbRS))
            {
                while (dbRS.Read())
                {
                    Grid2.Rows.Add();
                    Grid2[iCol1_FOSBID, Grid2.RowCount - 1].Value = dbRS["RCVNO"].ToString();
                    Grid2[iCol1_LOTNO, Grid2.RowCount - 1].Value = dbRS["LOTNO"].ToString();

                }
                dbRS.Close();
            }

            clsDB.FunClsDB();
        }

    //        Private Function SubDealWithWMS(ByVal sSNID As String, ByVal sLocID As String, ByVal sUserName As String) As Boolean
    //    Dim sSQL As String

    //    SubDealWithWMS = False
    //    'sSQL = "UPDATE TB_ASRS_TO_WMS_TEMP SET STATUS = 'A', "
    //    sSQL = "UPDATE TB_ASRS_TO_WMS_TEMP SET  "
    //    sSQL = sSQL & "LOCID = '" & sLocID & "', "
    //    sSQL = sSQL & "USER_NAME = '" & sUserName & "', "
    //    sSQL = sSQL & "TXN_DATE = '" & Format(Now, "yyyyMMddHHmmss") & "' "
    //    sSQL = sSQL & "WHERE SNID = " & sSNID & "  "
    //    If Not FunExecSql(sSQL) Then
    //        MsgBox(Msg_Run_Error, MsgBoxStyle.Critical)
    //        Exit Function
    //    End If
    //    SubDealWithWMS = True

    //End Function

    }
}
