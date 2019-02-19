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
    public partial class frm_CYCLE_CHECK : Form
    {
        #region Grid Param
        int iCol2_LocID = 0;
        int iCol2_ItemNo = 1;               //'ITEM
        int iCol2_Customer = 2;             //'客戶編號
        int iCol2_Device = 3;               //'DEVICE
        int iCol2_LotNo = 4;                //'Lot No
        int iCol2_WaferQty = 5;             //'枚數
        int iCol2_ShipQty = 6;              //'數量
        int iCol2_FOSBID = 7;               //'FOSB ID
        int iCol2_REMARK = 8;
        int iCol2_TRANSACTION_DATE = 9;     //'收料日期
        int iCol2_GIB_CUSTOMER = 10;
        int iCol2_FAB_LOT_NO = 11;
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
        int iCol2_ChkIQC = 27;              //'是否檢驗
        int iCol2_INDATE = 28;              //'入庫時間
        int iCol2_FLAGQTY = 29;
        int iCol2_CYCLE = 30;
        int iCol2_Result = 31;              //'盤點確認
        int iCol2_COID = 32;                //'廠區(WMS)
        int iCol2_SNID = 33;                //'流水號(WMS)

        int iCol2_WaferQty_old = 34;             //'枚數
        int iCol2_ShipQty_old = 35;              //'數量
        int iCol2_Loc = 36;
        int iCol2_Counts = 37;
        #endregion

        string get_CmdSno = "";
        string get_Loc = "";
        string get_LocID = "";
        string get_Sno = "";

        public frm_CYCLE_CHECK()
        {
            InitializeComponent();
        }

        private void frm_CYCLE_CHECK_Load(object sender, EventArgs e)
        {
            GridInit();
            FormInit();
        }

        private void GridInit()
        {
            GridSysInit(ref Grid1); GridSetRange(ref Grid1);
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
            oGrid.RowCount = 1;

            oGrid.Columns[iCol2_LocID].Width = 80; oGrid.Columns[iCol2_LocID].Name = "料盒編號";
            oGrid.Columns[iCol2_ItemNo].Width = 80; oGrid.Columns[iCol2_ItemNo].Name = "ITEM No";
            oGrid.Columns[iCol2_Customer].Width = 100; oGrid.Columns[iCol2_Customer].Name = "客戶簡稱";
            oGrid.Columns[iCol2_Device].Width = 80; oGrid.Columns[iCol2_Device].Name = "DEVICE";
            oGrid.Columns[iCol2_LotNo].Width = 80; oGrid.Columns[iCol2_LotNo].Name = "LOT NO";
            oGrid.Columns[iCol2_WaferQty].Width = 45; oGrid.Columns[iCol2_WaferQty].Name = "枚數";
            oGrid.Columns[iCol2_ShipQty].Width = 45; oGrid.Columns[iCol2_ShipQty].Name = "數量";
            oGrid.Columns[iCol2_REMARK].Width = 100; oGrid.Columns[iCol2_REMARK].Name = "備註";
            oGrid.Columns[iCol2_FOSBID].Width = 80; oGrid.Columns[iCol2_FOSBID].Name = "收料序號";
            oGrid.Columns[iCol2_TRANSACTION_DATE].Width = 110; oGrid.Columns[iCol2_TRANSACTION_DATE].Name = "收料日期";
            oGrid.Columns[iCol2_GIB_CUSTOMER].Width = 80; oGrid.Columns[iCol2_GIB_CUSTOMER].Name = "來貨廠商";
            oGrid.Columns[iCol2_FAB_LOT_NO].Width = 100; oGrid.Columns[iCol2_FAB_LOT_NO].Name = "Fab lot";
            oGrid.Columns[iCol2_FAB_TYPE].Width = 100; oGrid.Columns[iCol2_FAB_TYPE].Name = "晶圓廠別";
            oGrid.Columns[iCol2_TYPENO].Width = 100; oGrid.Columns[iCol2_TYPENO].Name = "Mask";
            oGrid.Columns[iCol2_LOT_TYPE].Width = 100; oGrid.Columns[iCol2_LOT_TYPE].Name = "Lot Type";
            oGrid.Columns[iCol2_WAFER_SIZE].Width = 100; oGrid.Columns[iCol2_WAFER_SIZE].Name = "晶片尺寸";
            oGrid.Columns[iCol2_YIELD].Width = 45; oGrid.Columns[iCol2_YIELD].Name = "良率";
            oGrid.Columns[iCol2_APP_NO].Width = 100; oGrid.Columns[iCol2_APP_NO].Name = "報單號碼";
            oGrid.Columns[iCol2_REL_DATE].Width = 100; oGrid.Columns[iCol2_REL_DATE].Name = "報單日期";
            oGrid.Columns[iCol2_REASON_NAME].Width = 100; oGrid.Columns[iCol2_REASON_NAME].Name = "Reason Code";
            oGrid.Columns[iCol2_TRANSACTION_REFERENCE].Width = 100; oGrid.Columns[iCol2_TRANSACTION_REFERENCE].Name = "Reference";
            oGrid.Columns[iCol2_TRANSACTION_SOURCE_ID].Width = 100; oGrid.Columns[iCol2_TRANSACTION_SOURCE_ID].Name = "Source ID";
            oGrid.Columns[iCol2_TRANSACTION_TYPE_ID].Width = 120; oGrid.Columns[iCol2_TRANSACTION_TYPE_ID].Name = "Transaction Type";
            oGrid.Columns[iCol2_FROM_ORG].Width = 100; oGrid.Columns[iCol2_FROM_ORG].Name = "From Org";
            oGrid.Columns[iCol2_TO_ORG].Width = 100; oGrid.Columns[iCol2_TO_ORG].Name = "To Org";
            oGrid.Columns[iCol2_FROM_BANK].Width = 100; oGrid.Columns[iCol2_FROM_BANK].Name = "From Bank";
            oGrid.Columns[iCol2_TO_BANK].Width = 100; oGrid.Columns[iCol2_TO_BANK].Name = "To Bank";
            oGrid.Columns[iCol2_INDATE].Width = 110; oGrid.Columns[iCol2_INDATE].Name = "入庫日期";
            oGrid.Columns[iCol2_ChkIQC].Width = 45; oGrid.Columns[iCol2_ChkIQC].Name = "檢驗";
            oGrid.Columns[iCol2_FLAGQTY].Width = 45; oGrid.Columns[iCol2_FLAGQTY].Name = "flag";
            oGrid.Columns[iCol2_CYCLE].Width = 100; oGrid.Columns[iCol2_CYCLE].Name = "盤點單號";
            oGrid.Columns[iCol2_Result].Width = 100; oGrid.Columns[iCol2_Result].Name = "盤點確認";

            oGrid.Columns[iCol2_COID].Width = 100; oGrid.Columns[iCol2_COID].Name = "廠區";
            oGrid.Columns[iCol2_SNID].Width = 100; oGrid.Columns[iCol2_SNID].Name = "流水號";
            oGrid.Columns[iCol2_COID].Visible = false;
            oGrid.Columns[iCol2_SNID].Visible = false;

            oGrid.Columns[iCol2_WaferQty_old].Width = 45; oGrid.Columns[iCol2_WaferQty_old].Name = "枚數";
            oGrid.Columns[iCol2_ShipQty_old].Width = 45; oGrid.Columns[iCol2_ShipQty_old].Name = "枚數數量";
            oGrid.Columns[iCol2_WaferQty_old].Visible = false;
            oGrid.Columns[iCol2_ShipQty_old].Visible = false;

            oGrid.Columns[iCol2_FLAGQTY].Visible = false;
            oGrid.Columns[iCol2_Loc].Visible = false;
            
                        
            int i = 0;
            for (i = 0; i <= oGrid.ColumnCount - 1; i++)
            {
                oGrid.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            oGrid.RowCount = 0;
        }

        private void FormInit()
        {        
            clsASRS.SetCycResult(ref cboResult_L);
            RdBtn_Confirm_L.Checked = true;
            txtQty_L.Maximum = 100000;
            SubClearInit();
            txtCycleUser.Text = clsASRS.gstrLoginUser;
        }

        private void SubClearInit()
        {
            Grid1.RowCount = 0;

            get_CmdSno = "";
            get_Loc = "";
            get_LocID = "";
            lblCmdSno.Text = "";
            lblCycle.Text = "";

            lblQty_L.Visible = false;
            txtQty_L.Visible = false;

            RdBtn_Confirm_L.Checked = true;
            RdBtn_NG_L.Checked = false;
            RdBtn_Confirm_L.Checked = true;

            txtLocID.Text = "";
            txtLocID.BackColor = Color.White;            
            txtScan.Text = "";
            txtScan.Select();
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
                    clsDB.FunClsDB(); return;
                }

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

            sSQL = "SELECT * FROM CMD_MST WHERE LOCID = '" + sLocID + "' AND CMDSTS <= '7' ";
            sSQL = sSQL + "AND IOTYP IN ('" + clsASRS.gsIOTYPE_Cycle_Item + "','" + clsASRS.gsIOTYPE_Cycle_Loc + "','" + clsASRS.gsIOTYPE_Cycle_WMS + "') ";
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

            }
            else
            {
                string sIotype = "";
                sSQL = "SELECT * FROM CMD_MST WHERE LOCID = '" + sLocID + "' AND CMDSTS <= '5' ";
                if (clsDB.FunRsSql(sSQL, ref dbRS))
                {
                    while (dbRS.Read())
                    {
                        sIotype = dbRS["IOTYP"].ToString();
                    }
                    dbRS.Close();

                    if ((sIotype != clsASRS.gsIOTYPE_Cycle_Loc) && (sIotype != clsASRS.gsIOTYPE_Cycle_Item) && (sIotype != clsASRS.gsIOTYPE_Cycle_WMS))
                    {
                        clsMSG.ShowWarningMsg("命令不是盤點功能");
                        return false;
                    }
                }
                else
                {
                    clsMSG.ShowWarningMsg("命令不存在");
                    return false;
                }
            }


            return true;
        }

        private void SubReadLocID_Rd_CMD_DTL(string sLocID)
        {
            string sSQL = ""; DbDataReader dbRS = null;

            string sCycNo ="";
            sCycNo = "";


            Grid1.RowCount = 0;

            //sSQL = "SELECT * FROM CMD_DTL WHERE CMDSNO = '" + get_CmdSno + "' AND LOCID = '" + sLocID + "' ";
            sSQL = "SELECT M.LOC,D.* FROM CMD_MST M, CMD_DTL D ";
            sSQL = sSQL + "WHERE M.CMDSNO = D.CMDSNO AND M.LOCID = D.LOCID ";
            sSQL = sSQL + "AND D.CMDSNO = '" + get_CmdSno + "' AND D.LOCID = '" + sLocID + "' ";
            if (clsDB.FunRsSql(sSQL, ref dbRS))
            {
                while (dbRS.Read())
                {
                    Grid1.Rows.Add();

                    #region
                    Grid1[iCol2_Loc, Grid1.Rows.Count - 1].Value = dbRS["LOC"].ToString();
                    Grid1[iCol2_LocID, Grid1.Rows.Count - 1].Value = dbRS["LOCID"].ToString();
                    Grid1[iCol2_ItemNo, Grid1.Rows.Count - 1].Value = dbRS["ITEMNO"].ToString();
                    Grid1[iCol2_Customer, Grid1.Rows.Count - 1].Value = dbRS["CUSTOMER"].ToString();
                    Grid1[iCol2_Device, Grid1.Rows.Count - 1].Value = dbRS["DEVICE"].ToString();
                    Grid1[iCol2_LotNo, Grid1.Rows.Count - 1].Value = dbRS["LOTNO"].ToString();
                    Grid1[iCol2_WaferQty, Grid1.Rows.Count - 1].Value = dbRS["WAFERQTY"].ToString();
                    Grid1[iCol2_ShipQty, Grid1.Rows.Count - 1].Value = dbRS["SHIPQTY"].ToString();
                    Grid1[iCol2_FOSBID, Grid1.Rows.Count - 1].Value = dbRS["FOSBID"].ToString();
                    Grid1[iCol2_REMARK, Grid1.Rows.Count - 1].Value = dbRS["REMARK"].ToString();
                    Grid1[iCol2_TRANSACTION_DATE, Grid1.Rows.Count - 1].Value = dbRS["TRANSACTION_DATE"].ToString();
                    Grid1[iCol2_GIB_CUSTOMER, Grid1.Rows.Count - 1].Value = dbRS["GIB_CUSTOMER"].ToString();
                    Grid1[iCol2_FAB_LOT_NO, Grid1.Rows.Count - 1].Value = dbRS["FAB_LOT_NO"].ToString();
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
                    Grid1[iCol2_CYCLE, Grid1.Rows.Count - 1].Value = dbRS["CYCLENO"].ToString();

                    if (Grid1[iCol2_CYCLE, Grid1.Rows.Count - 1].Value != "")
                    {
                        sCycNo = Grid1[iCol2_CYCLE, Grid1.Rows.Count - 1].Value.ToString();
                    }

                    if (dbRS["FLAGQTY"].ToString() == "X")
                    {
                        SetGridColotNotCycle(ref Grid1, Grid1.Rows.Count - 1);
                        Grid1[iCol2_Result, Grid1.Rows.Count - 1].Value = "";
                    }
                    else
                    {
                        Grid1[iCol2_Result, Grid1.Rows.Count - 1].Value = "0:相符";
                    }

                    Grid1[iCol2_WaferQty_old, Grid1.Rows.Count - 1].Value = dbRS["WAFERQTY"].ToString();
                    Grid1[iCol2_ShipQty_old, Grid1.Rows.Count - 1].Value = dbRS["SHIPQTY"].ToString();

                    Grid1[iCol2_COID, Grid1.Rows.Count - 1].Value = dbRS["COID"].ToString();
                    Grid1[iCol2_SNID, Grid1.Rows.Count - 1].Value = dbRS["SNID"].ToString();

                    
                    #endregion
                }
                dbRS.Close();
            }
            
            lblCycle.Text = sCycNo;
            RdBtn_Confirm_L.Checked = true;
        }

        private void SetGridColotNotCycle(ref DataGridView oGrid, int iRow)
        {
            int y = 0;

            try
            {
                oGrid.Rows[iRow].HeaderCell.Value = "";
                for (y = 0; y <= oGrid.ColumnCount - 1; y++)
                {
                    oGrid.Rows[iRow].Cells[y].Style.BackColor = Color.Gray;
                }
            }
            catch
            {
             
            }
        }
        #endregion

        private void cboResult_L_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboResult_L.Text = cboResult_L.Text.Trim();

            if (cboResult_L.Text != "")
            {
                if (cboResult_L.Text.Substring(0, 1) == "1")     //與枚數不符
                {
                    lblQty_L.Text = "枚數";
                    txtQty_L.Value = 0;
                    lblQty_L.Visible = true;
                    txtQty_L.Visible = true;
                }
                else if (cboResult_L.Text.Substring(0, 1) == "2")   //與數量不符
                {
                    lblQty_L.Text = "數量";
                    lblQty_L.Visible = true;
                    txtQty_L.Visible = true;
                }
                else if (cboResult_L.Text.Substring(0, 1) == "3")   //與實物不符
                {
                    lblQty_L.Visible = false;
                    txtQty_L.Visible = false;
                }
                else if (cboResult_L.Text.Substring(0, 1) == "4")    //其它
                {
                    lblQty_L.Visible = false;
                    txtQty_L.Visible = false;
                }
                //WMS
                if (Grid1.RowCount == 0)
                {
                    txtScan.Select();
                    return;
                }
                if (Grid1[iCol2_ItemNo, Grid1.CurrentRow.Index].Value.ToString() == "")
                {
                    txtScan.Select();
                    return;
                }
                if (Grid1[iCol2_FLAGQTY, Grid1.CurrentRow.Index].Value.ToString() == "X")
                {
                    txtScan.Select();
                    return;
                }
                if (cboResult_L.Text.Length >= 2)
                {
                    Grid1[iCol2_Result, Grid1.CurrentRow.Index].Value = cboResult_L.Text;
                }
                else
                {
                    Grid1[iCol2_Result, Grid1.CurrentRow.Index].Value = "";
                }
                
            }
            else
            {
                    lblQty_L.Visible = false;
                    txtQty_L.Visible = false;
            }
            txtScan.Select();
        }

        private void txtQty_L_ValueChanged(object sender, EventArgs e)
        {
            if (Grid1.RowCount == 0)
            {
                txtScan.Select();
                return;
            }
            if (Grid1[iCol2_ItemNo, Grid1.CurrentRow.Index].Value.ToString() == "")
            {
                txtScan.Select();
                return;
            }

            if (Grid1[iCol2_FLAGQTY, Grid1.CurrentRow.Index].Value.ToString() == "X")
            {
                txtScan.Select();
                return;
            }

            if (cboResult_L.Text.Length >= 2)
            {
                if (cboResult_L.Text.Substring(0, 1) == "1")      //'枚數不符
                {
                    Grid1[iCol2_WaferQty, Grid1.CurrentRow.Index].Value = txtQty_L.Value;
                }
                else if (cboResult_L.Text.Substring(0, 1) == "2")   //數量不符
                {
                    Grid1[iCol2_ShipQty, Grid1.CurrentRow.Index].Value = txtQty_L.Value;
                }
            }
        }

        private void Grid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtScan.Select();
        }

        private void Grid1_Click(object sender, EventArgs e)
        {
            txtScan.Select();
        }

        private void Grid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtScan.Select();
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            SubClearInit();
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }





        private void RdBtn_NG_L_CheckedChanged(object sender, EventArgs e)
        {
            SubChgResultData();
            txtScan.Select();
        }

        private void RdBtn_Confirm_L_CheckedChanged(object sender, EventArgs e)
        {
            SubChgResultData();
            txtScan.Select();
        }


        private void SubChgResultData()
        {
            if (RdBtn_Confirm_L.Checked == true)    //相符
            {
                cboResult_L.Text = " ";
                cboResult_L.Enabled = false;
                lblQty_L.Visible = false;
                txtQty_L.Visible = false;
                //WMS

                if (Grid1.RowCount == 0)
                {
                    txtScan.Select();
                    return;
                }
                if (Grid1[iCol2_ItemNo, Grid1.CurrentRow.Index].Value.ToString() == "")
                {
                    txtScan.Select();
                    return;
                }
                if (Grid1[iCol2_ItemNo, Grid1.CurrentRow.Index].Value.ToString() == "X")
                {
                    txtScan.Select();
                    return;
                }
                Grid1[iCol2_Result, Grid1.CurrentRow.Index].Value = "0:相符";
                Grid1[iCol2_WaferQty, Grid1.CurrentRow.Index].Value = Grid1[iCol2_WaferQty_old, Grid1.CurrentRow.Index].Value.ToString();
                Grid1[iCol2_ShipQty, Grid1.CurrentRow.Index].Value = Grid1[iCol2_ShipQty_old, Grid1.CurrentRow.Index].Value.ToString();
            }
            else
            {
                if (Grid1.RowCount == 0)
                {
                    txtScan.Select();
                    return;
                }
                if (Grid1[iCol2_ItemNo, Grid1.CurrentRow.Index].Value == "")
                {
                    txtScan.Select();
                    return;
                }
                cboResult_L.Enabled = true;
                cboResult_L.SelectedIndex = 1;
            }
        }

        private void cboResult_L_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
        
        
        private void cmdStart_Click(object sender, EventArgs e)
        {
            int y = 0;

            //1.判別命令序號是否存在
            if (get_CmdSno == "") { return; }

            //判別是否有做盤點確認
            if (Grid1.RowCount >= 1)
            {
                if ((RdBtn_Confirm_L.Checked == false) && (RdBtn_NG_L.Checked == false))
                {
                    for (y = 0; y <= Grid1.RowCount - 1; y++)
                    {
                        if (Grid1[iCol2_FLAGQTY, y].Value.ToString() != "X")
                        {
                            clsMSG.ShowWarningMsg("請做盤點確認!!");
                            return;
                        }
                    }
                }
            }
            
            if (FunDelwithCmd() == true)
            {
                clsMSG.ShowInformationMsg("資料己處理完畢,請繼續執行出庫動作");
                SubClearInit();
            }
            
        }

        //處理命令
        private bool FunDelwithCmd()
        {          
            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return false; };


            //找出命令模式
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
                //(1)先找內側儲位為N,外側儲位為S
                if (clsASRS.FunGetLocForSingleListByInOutLoc(iCrn, "N", "S", 1, ref sGetLoc1, ref sGetLocID1) == false)
                {
                    //(2)找內側儲位為N,外側儲位為S. (TEMP 儲位)
                    if (clsASRS.FunGetLocForSingleListByInOutLoc_StorageTyp_Temp(iCrn, "N", "S", 1, ref sGetLoc1, ref sGetLocID1, iBayDesc) == false)
                    {
                        //(3)找外側儲位為N,內側儲位為N. (TEMP 儲位)
                        if (clsASRS.FunGetLocForSingleListByInOutLoc_StorageTyp_Temp(iCrn, "N", "N", 2, ref sGetLoc1, ref sGetLocID1, iBayDesc) == false)
                        {
                            //(4)找外側儲位為N,內側儲位為N,
                            if (clsASRS.FunGetLocForSingleListByInOutLoc(iCrn, "N", "N", 2, ref sGetLoc1, ref sGetLocID1) == false)
                            {
                                clsMSG.ShowWarningMsg("無合適之空儲位!!"); clsDB.FunClsDB(); return false;
                            }
                        }
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

                //產生命令主檔
                #region 產生命令主檔
                cls_CmdMst aCmdMst = new cls_CmdMst();

                aCmdMst.FunCmdMstClear();   //Clear()
                aCmdMst.CMDSNO = sCmdSnoNew;
                aCmdMst.SNO1 = "1";
                aCmdMst.LOC1 = sGetLoc1;
                aCmdMst.LOCID1 = get_LocID;
                aCmdMst.SCAN1 = "Y";    //己確認

                aCmdMst.SNO2 = "";
                aCmdMst.LOC2 = "";
                aCmdMst.LOCID2 = "";
                aCmdMst.SCAN2 = "N";
                aCmdMst.CMDMODE = clsASRS.gsCmdMode_In;   //入庫                    

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
                sSQL = "INSERT INTO CMD_DTL (CMDSNO,LocID,SNO,ITEMNO,CUSTOMER,DEVICE,LOTNO,STORE,";
                sSQL = sSQL + "OFFQTY,WAFERQTY,SHIPQTY,OFFACTQTY,WAFERACTQTY,SHIPACTQTY,";
                sSQL = sSQL + "FLAGQTY,CHKIQC,FOSBID,IQC_ID,ACC_ID,INDATE,REMARK,TRANSACTION_DATE,";
                sSQL = sSQL + "GIB_CUSTOMER,FAB_LOT_NO,FAB_TYPE,TYPENO,LOT_TYPE,WAFER_SIZE,YIELD,";
                sSQL = sSQL + "APP_NO,REL_DATE,REASON_NAME,TRANSACTION_REFERENCE,TRANSACTION_SOURCE_ID,";
                sSQL = sSQL + "TRANSACTION_TYPE_ID,FROM_ORG,TO_ORG,FROM_BANK,TO_BANK,CYCLENO,COID,SNID,DOCID,DOCID2) ";
                sSQL = sSQL + "SELECT '" + sCmdSnoNew + "',LocID,SNO,ITEMNO,CUSTOMER,DEVICE,LOTNO,STORE,";
                sSQL = sSQL + "OFFQTY,WAFERQTY,SHIPQTY,OFFACTQTY,WAFERACTQTY,SHIPACTQTY,";
                sSQL = sSQL + "FLAGQTY,CHKIQC,FOSBID,IQC_ID,ACC_ID,INDATE,REMARK,TRANSACTION_DATE,";
                sSQL = sSQL + "GIB_CUSTOMER,FAB_LOT_NO,FAB_TYPE,TYPENO,LOT_TYPE,WAFER_SIZE,YIELD,";
                sSQL = sSQL + "APP_NO,REL_DATE,REASON_NAME,TRANSACTION_REFERENCE,TRANSACTION_SOURCE_ID,";
                sSQL = sSQL + "TRANSACTION_TYPE_ID,FROM_ORG,TO_ORG,FROM_BANK,TO_BANK,CYCLENO,COID,SNID,DOCID,DOCID2 ";
                sSQL = sSQL + "FROM CMD_DTL WHERE CMDSNO = '" + get_CmdSno + "' AND LOCID = '" + get_LocID + "' ";
                if (clsDB.FunExecSql(sSQL) == false)
                {
                    clsDB.FunCommitCtrl("ROLLBACK");
                    clsMSG.ShowWarningMsg(clsMSG.MSG.Msg_Run_Error);
                    clsDB.FunClsDB();
                    return false;
                }
                #endregion

                //更新盤點檔
                #region 更新盤點檔
                if (FunDelWithCYCLE() == false)
                {
                    clsDB.FunCommitCtrl("ROLLBACK");
                    clsMSG.ShowWarningMsg(clsMSG.MSG.Msg_Run_Error);
                    clsDB.FunClsDB();
                    return false;
                }
                #endregion

                //更新old命令為 Y且結束
                #region 更新old命令為 Y且結束
                sSQL = "UPDATE CMD_MST SET SCAN = 'Y',CMDSTS = '7' ";
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

                clsDB.FunCommitCtrl("COMMIT");    // 'COMMIT
                clsDB.FunClsDB();
                return true;
            }
            else
            {
                clsDB.FunCommitCtrl("BEGIN");

                //更新盤點檔
                if (FunDelWithCYCLE() == false)
                {
                    clsDB.FunCommitCtrl("ROLLBACK");
                    clsMSG.ShowWarningMsg(clsMSG.MSG.Msg_Run_Error);
                    clsDB.FunClsDB();
                    return false;
                }

                //更新 CMD_MST
                if (FunDelWithCmd_CMD_MST() == false)
                {
                    clsDB.FunCommitCtrl("ROLLBACK");
                    clsMSG.ShowWarningMsg(clsMSG.MSG.Msg_Run_Error);
                    clsDB.FunClsDB();
                    return false;
                }

                clsDB.FunCommitCtrl("COMMIT");    // 'COMMIT
                clsDB.FunClsDB();
                return true;
            }

            //return false;
        }

        private bool FunDelWithCmd_CMD_MST()
        {
            string sSQL = "";

            sSQL = "UPDATE CMD_MST SET SCAN = 'Y' ";
            sSQL = sSQL + "WHERE CMDSNO = '" + get_CmdSno + "' ";
            sSQL = sSQL + "AND LOCID = '" + get_LocID + "' ";
            sSQL = sSQL + "AND CMDSTS <= '5' ";
            //sSQL = sSQL + "AND CMDMODE IN ('1','3') "; //2
            if (clsDB.FunExecSql(sSQL) == false)
            {
                clsMSG.ShowWarningMsg(clsMSG.MSG.Msg_Run_Error);
                return false;
            }

            return true;
        }


        private bool FunDelWithCYCLE()
        {
            string sSQL = ""; string sResult = ""; int i = 0;
            string sDate = clsTool.GetDateTime();
            
            for (i = 0; i <= Grid1.RowCount - 1; i++)
            {
                #region CYCLE
                if (Grid1[iCol2_CYCLE, i].Value.ToString().Trim() != "")
                {
                    if (Grid1[iCol2_Result, i].Value.ToString().Length >= 2)
                    {
                        sResult = Grid1[iCol2_Result, i].Value.ToString().Substring(0, 1);
                    }
                    else
                    {
                        sResult = "";
                    }

                    sSQL = "UPDATE CYCLE SET USER_CYC = '" + txtCycleUser.Text + "', ";
                    sSQL = sSQL + "CYC_STATUS = '2',";  //'己盤點
                    if ((sResult != "") || (sResult == "0"))
                    {
                        sSQL = sSQL + "CYC_RESULT = '" + sResult + "',";
                        sSQL = sSQL + "CYCWAFERQTY = " + Grid1[iCol2_WaferQty, i].Value.ToString() + ", ";
                        sSQL = sSQL + "CYCSHIPQTY = " + Grid1[iCol2_ShipQty, i].Value.ToString() + ", ";
                    }
                    else
                    {
                        sSQL = sSQL + "CYC_RESULT = '0', ";
                        sSQL = sSQL + "CYCWAFERQTY = " + Grid1[iCol2_WaferQty_old, i].Value.ToString() + ", ";
                        sSQL = sSQL + "CYCSHIPQTY = " + Grid1[iCol2_ShipQty_old, i].Value.ToString() + ", ";
                    }


                    sSQL = sSQL + "DATE_CYCLE = '" + sDate + "' ";
                    sSQL = sSQL + "WHERE CYCLENO = '" + Grid1[iCol2_CYCLE, i].Value.ToString() + "' ";
                    sSQL = sSQL + "AND LOC = '" + Grid1[iCol2_Loc, i].Value.ToString() + "' ";
                    sSQL = sSQL + "AND LOCID = '" + Grid1[iCol2_LocID, i].Value.ToString() + "' ";
                    //sSQL = sSQL + "AND SUBLOC = 'L' ";
                    sSQL = sSQL + "AND ITEMNO = '" + Grid1[iCol2_ItemNo, i].Value.ToString() + "' ";
                    sSQL = sSQL + "AND LOTNO = '" + Grid1[iCol2_LotNo, i].Value.ToString() + "' ";
                    sSQL = sSQL + "AND FOSBID = '" + Grid1[iCol2_FOSBID, i].Value.ToString() + "' ";
                    if (clsDB.FunExecSql(sSQL) == false)
                    {
                        clsMSG.ShowErrMsg(clsMSG.MSG.Msg_Run_Error);
                        return false;
                    }
                }
                #endregion

                //#region 回報WMS WMS_CYCLE_LOT
                //if (Grid1[iCol2_SNID, i].Value.ToString().Trim() != "")
                //{
                //    sSQL = "UPDATE WMS_CYCLE_LOT ";
                //    sSQL = sSQL + "SET LOCID = '" + get_LocID + "', ";
                //    sSQL = sSQL + "PIECE = " + Grid1[iCol2_WaferQty, i].Value.ToString() + ", ";
                //    sSQL = sSQL + "DIE = " + Grid1[iCol2_ShipQty, i].Value.ToString() + " ";
                //    sSQL = sSQL + "WHERE SEQ_NO = " + Grid1[iCol2_SNID, i].Value.ToString() + " ";
                //    sSQL = sSQL + "AND COID = '" + Grid1[iCol2_COID, i].Value.ToString() + "' ";
                //    if (clsDB.FunExecSql(sSQL) == false)
                //    {
                //        clsMSG.ShowErrMsg(clsMSG.MSG.Msg_Run_Error);
                //        return false;
                //    }
                //}
                //#endregion
            }            
            return true;
        }







    }
}