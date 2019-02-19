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
    public partial class frm_ASRS_OFFLINE_IN : Form
    {
        #region Grid Prarm
        //主畫面Grid1
        int iCol_SubLoc = 0;        //L/R
        int iCol_ITEM = 1;          //ITEM No
        int iCol_CUST = 2;          //客戶簡稱
        int iCol_DEV = 3;          //DEVICE
        int iCol_LotNo = 4;         //LotNo
        int iCol_Store = 5;         //材料類別
        int iCol_OffQty = 6;        //件數
        int iCol_WaferQty = 7;      //枚數
        int iCol_ShipQty = 8;       //數量
        int iCol_ChkIQC = 9;        //檢驗
        int iCol_FOSBID = 10;       //收料序號
        int iCol_ACCID = 11;        //無單流水號
        int iCol_InDate = 12;       //入庫日期
        int iCol_Remark = 13;       //備註
        int iCol_TRANSACTION_DATE = 14;        //收料日期
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
        int iCol_FlagQty = 32;
        int iCol_Counts = 33;

        //主畫面Grid2
        int iCol2_ACCID = 0;         //無單流水號 / 收料序號  
        int iCol2_STYLE = 1;        //材料類別
        int iCol2_ITEM = 2;          //ITEM      
        int iCol2_CUST = 3;          //客戶簡稱  
        int iCol2_DEV = 4;           //DEVICE               
        int iCol2_LotNo = 5;         //LotNo  
        int iCol2_OffQty = 6;        //件數
        int iCol2_WaferQty = 7;      //枚數              
        int iCol2_ShipQty = 8;       //數量     
        int iCol2_Remark = 9;        //備註              
        int iCol2_StrInDate = 10;    //收料日期          
        int iCol2_Vendor = 11;       //來源廠商          
        int iCol2_FabLot = 12;       //Fab Lot           
        int iCol2_MASK = 13;         //MASK              
        int iCol2_LotType = 14;      //Lot Type          
        int iCol2_Size = 15;         //Size              
        int iCol2_Rate = 16;         //良率              
        int iCol2_Counts = 17;
        #endregion

        public frm_ASRS_OFFLINE_IN()
        {
            InitializeComponent();
        }

        private void frm_ASRS_OFFLINE_IN_Load(object sender, EventArgs e)
        {
            GridInit();
            FormInit();
        }

        private void GridInit()
        {
            GridSysInit(ref Grid1);
            GridSetRange(ref Grid1);

            GridSysInit(ref Grid2);
            GridSetRange2(ref Grid2);
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

            oGrid.Columns[iCol_SubLoc].Width = 40; oGrid.Columns[iCol_SubLoc].Name = "L/R"; oGrid.Columns[iCol_SubLoc].Visible = false;
            oGrid.Columns[iCol_ITEM].Width = 100;  oGrid.Columns[iCol_ITEM].Name = "ITEM No";
            oGrid.Columns[iCol_CUST].Width = 100;  oGrid.Columns[iCol_CUST].Name = "客戶簡稱";
            oGrid.Columns[iCol_DEV].Width = 100;  oGrid.Columns[iCol_DEV].Name = "DEVICE";
            oGrid.Columns[iCol_LotNo].Width = 100;  oGrid.Columns[iCol_LotNo].Name = "LOT NO";
            oGrid.Columns[iCol_Store].Width = 100;  oGrid.Columns[iCol_Store].Name = "材料類別";
            oGrid.Columns[iCol_OffQty].Width = 60;  oGrid.Columns[iCol_OffQty].Name = "件數";
            oGrid.Columns[iCol_WaferQty].Width = 60;  oGrid.Columns[iCol_WaferQty].Name = "枚數";
            oGrid.Columns[iCol_ShipQty].Width = 60;  oGrid.Columns[iCol_ShipQty].Name = "數量";
            oGrid.Columns[iCol_ChkIQC].Width = 80;  oGrid.Columns[iCol_ChkIQC].Name = "檢驗";
            oGrid.Columns[iCol_FOSBID].Width = 100;  oGrid.Columns[iCol_FOSBID].Name = "收料序號";
            oGrid.Columns[iCol_ACCID].Width = 100;  oGrid.Columns[iCol_ACCID].Name = "無單流水號";
            oGrid.Columns[iCol_InDate].Width = 100;  oGrid.Columns[iCol_InDate].Name = "入庫日期";
            oGrid.Columns[iCol_Remark].Width = 100;  oGrid.Columns[iCol_Remark].Name = "備註";
            oGrid.Columns[iCol_TRANSACTION_DATE].Width = 100;  oGrid.Columns[iCol_TRANSACTION_DATE].Name = "收料日期";
            oGrid.Columns[iCol_GIB_CUSTOMER].Width = 100;  oGrid.Columns[iCol_GIB_CUSTOMER].Name = "來貨廠商";
            oGrid.Columns[iCol_FAB_LOT_NO].Width = 100;  oGrid.Columns[iCol_FAB_LOT_NO].Name = "Fab lot";
            oGrid.Columns[iCol_FAB_TYPE].Width = 100;  oGrid.Columns[iCol_FAB_TYPE].Name = "晶圓廠別";
            oGrid.Columns[iCol_TYPENO].Width = 100;  oGrid.Columns[iCol_TYPENO].Name = "Mask";
            oGrid.Columns[iCol_LOT_TYPE].Width = 100;  oGrid.Columns[iCol_LOT_TYPE].Name = "Lot Type";
            oGrid.Columns[iCol_WAFER_SIZE].Width = 100;  oGrid.Columns[iCol_WAFER_SIZE].Name = "晶片尺寸";
            oGrid.Columns[iCol_YIELD].Width = 100;  oGrid.Columns[iCol_YIELD].Name = "良率";
            oGrid.Columns[iCol_APP_NO].Width = 100;  oGrid.Columns[iCol_APP_NO].Name = "報單號碼";
            oGrid.Columns[iCol_REL_DATE].Width = 100;  oGrid.Columns[iCol_REL_DATE].Name = "報單日期";
            oGrid.Columns[iCol_REASON_NAME].Width = 100;  oGrid.Columns[iCol_REASON_NAME].Name = "Reason Code";
            oGrid.Columns[iCol_TRANSACTION_REFERENCE].Width = 100;  oGrid.Columns[iCol_TRANSACTION_REFERENCE].Name = "Reference";
            oGrid.Columns[iCol_TRANSACTION_SOURCE_ID].Width = 100;  oGrid.Columns[iCol_TRANSACTION_SOURCE_ID].Name = "Source ID";
            oGrid.Columns[iCol_TRANSACTION_TYPE_ID].Width = 120;  oGrid.Columns[iCol_TRANSACTION_TYPE_ID].Name = "Transaction Type";
            oGrid.Columns[iCol_FROM_ORG].Width = 100;  oGrid.Columns[iCol_FROM_ORG].Name = "From Org";
            oGrid.Columns[iCol_TO_ORG].Width = 100;  oGrid.Columns[iCol_TO_ORG].Name = "To Org";
            oGrid.Columns[iCol_FROM_BANK].Width = 100; oGrid.Columns[iCol_FROM_BANK].Name = "From Bank";
            oGrid.Columns[iCol_TO_BANK].Width = 100;  oGrid.Columns[iCol_TO_BANK].Name = "To Bank";
            oGrid.Columns[iCol_FlagQty].Width = 100;  oGrid.Columns[iCol_FlagQty].Name = "Falg";

            int i = 0;
            for (i = 0; i <= oGrid.ColumnCount - 1; i++)
            {
                oGrid.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            oGrid.RowCount = 0;
        }

        private void GridSetRange2(ref DataGridView oGrid)
        {
            oGrid.ColumnCount = iCol2_Counts;

            oGrid.Columns[iCol2_ACCID].Width = 85; oGrid.Columns[iCol2_ACCID].Name = "無單流水號";
            oGrid.Columns[iCol2_STYLE].Width = 85; oGrid.Columns[iCol2_STYLE].Name = "材料類別";
            oGrid.Columns[iCol2_ITEM].Width = 85; oGrid.Columns[iCol2_ITEM].Name = "ITEM No";
            oGrid.Columns[iCol2_CUST].Width = 85; oGrid.Columns[iCol2_CUST].Name = "客戶簡稱";
            oGrid.Columns[iCol2_DEV].Width = 85; oGrid.Columns[iCol2_DEV].Name = "DEVICE";
            oGrid.Columns[iCol2_LotNo].Width = 100; oGrid.Columns[iCol2_LotNo].Name = "LOT NO";
            oGrid.Columns[iCol2_OffQty].Width = 65; oGrid.Columns[iCol2_OffQty].Name = "件數";
            oGrid.Columns[iCol2_WaferQty].Width = 65; oGrid.Columns[iCol2_WaferQty].Name = "枚數";
            oGrid.Columns[iCol2_ShipQty].Width = 65; oGrid.Columns[iCol2_ShipQty].Name = "數量";
            oGrid.Columns[iCol2_Remark].Width = 100; oGrid.Columns[iCol2_Remark].Name = "備註";
            oGrid.Columns[iCol2_StrInDate].Width = 100; oGrid.Columns[iCol2_StrInDate].Name = "收料日期";
            oGrid.Columns[iCol2_Vendor].Width = 100; oGrid.Columns[iCol2_Vendor].Name = "來貨廠商";
            oGrid.Columns[iCol2_FabLot].Width = 100; oGrid.Columns[iCol2_FabLot].Name = "Fab lot";
            oGrid.Columns[iCol2_MASK].Width = 100; oGrid.Columns[iCol2_MASK].Name = "Mask";
            oGrid.Columns[iCol2_LotType].Width = 100; oGrid.Columns[iCol2_LotType].Name = "Lot Type";
            oGrid.Columns[iCol2_Size].Width = 65; oGrid.Columns[iCol2_Size].Name = "Size";
            oGrid.Columns[iCol2_Rate].Width = 65; oGrid.Columns[iCol2_Rate].Name = "良率";

            int i = 0;
            for (i = 0; i <= oGrid.ColumnCount - 1; i++)
            {
                oGrid.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            oGrid.RowCount = 0;
        }

        private void FormInit()
        {
            clsASRS.SubCboSetStnNo(ref cboStnNo);
            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };
            cboStnNo.Text = clsASRS.FunGetStnNoByAreaNo(clsASRS.gsAreaNo);
            clsDB.FunClsDB();

            chkLocAuto.Checked = true;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void SubSetGridColor_Selected(ref DataGridView oGrid, int iRow, bool bIsFalg)
        {
            int i = 0;
  
            if (bIsFalg == true)
            {
                oGrid.Rows[iRow].HeaderCell.Value = "V";

                for (i = 0; i <= oGrid.ColumnCount - 1; i++)
                {
                    oGrid.Rows[iRow].Cells[i].Style.BackColor = Color.Tomato;
                }
            }
            else
            {
                oGrid.Rows[iRow].HeaderCell.Value = "*";

                for (i = 0; i <= oGrid.ColumnCount - 1; i++)
                {
                    oGrid.Rows[iRow].Cells[i].Style.BackColor = Color.Orange;
                }
            }
        }

        private void SubSetGridColor(ref DataGridView oGrid, int iRow)
        {
            int i = 0;

            if (oGrid.Rows[iRow].HeaderCell.Value == "V")
            {

            }
            else
            {
                if (oGrid.Rows[iRow].HeaderCell.Value != "*")
                {
                    oGrid.Rows[iRow].HeaderCell.Value = "*";

                    for (i = 0; i <= oGrid.ColumnCount - 1; i++)
                    {
                        oGrid.Rows[iRow].Cells[i].Style.BackColor = clsTool.gsColor_BackColor;
                    }
                }
                else
                {
                    oGrid.Rows[iRow].HeaderCell.Value = "";

                    for (i = 0; i <= oGrid.ColumnCount - 1; i++)
                    {
                        oGrid.Rows[iRow].Cells[i].Style.BackColor = clsTool.gsColor_BackColor;
                    }
                }
            }
        }

        private void btnCls_Click(object sender, EventArgs e)
        {
            FormClear();
            SubClrFormGrid();
        }

        private void FormClear()
        {
            Grid2.RowCount = 0;
        }

        private void SubClrFormGrid()
        {
            int i = 0; int j = 0;
            for (i = 0; i <= Grid1.RowCount - 1; i++)
            {

                if (Grid1[iCol_ACCID, i].Value.ToString() != "")
                {
                    for (j = 0; j <= Grid2.RowCount - 1; j++)
                    {
                        if (Grid2[iCol2_ACCID, j].Value.ToString() == Grid1[iCol_ACCID, i].Value.ToString())
                        {
                            SubSetGridColor_Selected(ref Grid2, j, false);
                        }
                    }
                }
            }
            SubClrForm();
        }

        private void SubClrForm()
        {
            txtLoc.Text = "";
            txtLocID.Text = "";
            Grid1.RowCount = 0;
            txtLoc.Enabled = true;
            txtLocID.Enabled = true;
            btnHelp1.Enabled = true;
            btnHelp2.Enabled = true;
            cmdQuery.Enabled = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            SubClrFormGrid();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            clsASRS.gsHelpStyle = "ACCID";
            Array.Resize<string>(ref clsASRS.gsHelpRtnData, 1);
            clsASRS.gsHelpRtnData[0] = "";

            frm_ASRS_OFFLINE_IN_1 frmHelp = new frm_ASRS_OFFLINE_IN_1();
            frmHelp.ShowDialog();
            
            string sACCID = clsASRS.gsHelpRtnData[0];

            if (sACCID != "")
            {
                string strSql = ""; DbDataReader dbRS = null;

                strSql = "SELECT * FROM TRNTKT_ACC WHERE ACC_ID = '" + sACCID + "' ";

                if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };
                
                if (clsDB.FunRsSql(strSql, ref dbRS))
                {
                    while (dbRS.Read())
                    {
                        Grid2.Rows.Add();
                        Grid2.Rows[Grid2.Rows.Count - 1].HeaderCell.Value = "*";
                        Grid2[iCol2_ACCID, Grid2.Rows.Count - 1].Value = dbRS["ACC_ID"].ToString();
                        Grid2[iCol2_STYLE, Grid2.Rows.Count - 1].Value = dbRS["STORE"].ToString();
                        Grid2[iCol2_CUST, Grid2.Rows.Count - 1].Value = dbRS["CUSTOMER"].ToString();
                        Grid2[iCol2_ITEM, Grid2.Rows.Count - 1].Value = dbRS["ITEMNO"].ToString();
                        Grid2[iCol2_DEV, Grid2.Rows.Count - 1].Value = dbRS["DEVICE"].ToString();
                        Grid2[iCol2_LotNo, Grid2.Rows.Count - 1].Value = dbRS["LOTNO"].ToString();
                        Grid2[iCol2_OffQty, Grid2.Rows.Count - 1].Value = dbRS["OFFQTY"].ToString();
                        Grid2[iCol2_WaferQty, Grid2.Rows.Count - 1].Value = dbRS["WAFERQTY"].ToString();
                        Grid2[iCol2_ShipQty, Grid2.Rows.Count - 1].Value = dbRS["SHIPQTY"].ToString();
                        Grid2[iCol2_Remark, Grid2.Rows.Count - 1].Value = dbRS["REMARK"].ToString();
                        Grid2[iCol2_StrInDate, Grid2.Rows.Count - 1].Value = dbRS["TRANSACTION_DATE"].ToString();

                        Grid2[iCol2_Vendor, Grid2.Rows.Count - 1].Value = dbRS["GIB_CUSTOMER"].ToString();
                        Grid2[iCol2_FabLot, Grid2.Rows.Count - 1].Value = dbRS["FAB_LOT_NO"].ToString();
                        Grid2[iCol2_MASK, Grid2.Rows.Count - 1].Value = dbRS["TYPENO"].ToString();
                        Grid2[iCol2_LotType, Grid2.Rows.Count - 1].Value = dbRS["LOT_TYPE"].ToString();
                        Grid2[iCol2_Size, Grid2.Rows.Count - 1].Value = dbRS["WAFER_SIZE"].ToString();
                        Grid2[iCol2_Rate, Grid2.Rows.Count - 1].Value = dbRS["YIELD"].ToString(); 
                    }
                    dbRS.Close();
                }

                clsDB.FunClsDB();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (Grid2.RowCount == 0) { return; }

            if (Grid2.Rows[Grid2.CurrentRow.Index].HeaderCell.Value == "V")
            {
                clsMSG.ShowWarningMsg("己指派儲位，資料不可刪除 \r\n 請取消存放後再執行!!");
                return;
            }

            string sSQL = "";

            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };

            clsDB.FunCommitCtrl("BEGIN");


            sSQL = "DELETE FROM TRNTKT_ACC WHERE ACC_ID = '" + Grid2[iCol2_ACCID, Grid2.CurrentRow.Index].Value.ToString() + "' ";
            if (clsDB.FunExecSql(sSQL) == false)
            {                
                clsDB.FunCommitCtrl("ROLLBACK");
                clsDB.FunClsDB();
                clsMSG.ShowErrMsg(clsMSG.MSG.Msg_Run_Error);
            }
            else
            {
                clsDB.FunCommitCtrl("COMMIT");
                clsDB.FunClsDB();
                Grid2.Rows.Remove(Grid2.Rows[Grid2.CurrentRow.Index]);
            }
        }

        private void Grid2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Grid2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex <= -1) || (e.ColumnIndex <= -1)) { return; }
            if (Grid2[iCol_ACCID, e.RowIndex].Value.ToString() == "") { return; }

            SubSetGridColor(ref Grid2, e.RowIndex);
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string strSql = ""; DbDataReader dbRS = null;

            clsASRS.gsHelpStyle = "ACCID";
            Array.Resize<string>(ref clsASRS.gsHelpRtnData, 1);
            clsASRS.gsHelpRtnData[0] = "";

            frmHelp frmHelp = new frmHelp();
            frmHelp.ShowDialog();

            string sACCID = clsASRS.gsHelpRtnData[0];

            if (sACCID != "")
            {
                if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };

                strSql = "SELECT * FROM TRNTKT_ACC WHERE ACC_ID = '" + sACCID + "' ";
                if (clsDB.FunRsSql(strSql, ref dbRS))
                {
                    while (dbRS.Read())
                    {
                        Grid2.Rows.Add();
                        Grid2.Rows[Grid2.Rows.Count - 1].HeaderCell.Value = "*";
                        Grid2[iCol2_ACCID, Grid2.Rows.Count - 1].Value = dbRS["ACC_ID"].ToString();
                        Grid2[iCol2_STYLE, Grid2.Rows.Count - 1].Value = dbRS["STORE"].ToString();
                        Grid2[iCol2_CUST, Grid2.Rows.Count - 1].Value = dbRS["CUSTOMER"].ToString();
                        Grid2[iCol2_ITEM, Grid2.Rows.Count - 1].Value = dbRS["ITEMNO"].ToString();
                        Grid2[iCol2_DEV, Grid2.Rows.Count - 1].Value = dbRS["DEVICE"].ToString();
                        Grid2[iCol2_LotNo, Grid2.Rows.Count - 1].Value = dbRS["LOTNO"].ToString();
                        Grid2[iCol2_OffQty, Grid2.Rows.Count - 1].Value = dbRS["OFFQTY"].ToString();
                        Grid2[iCol2_WaferQty, Grid2.Rows.Count - 1].Value = dbRS["WAFERQTY"].ToString();
                        Grid2[iCol2_ShipQty, Grid2.Rows.Count - 1].Value = dbRS["SHIPQTY"].ToString();
                        Grid2[iCol2_Remark, Grid2.Rows.Count - 1].Value = dbRS["REMARK"].ToString();
                        Grid2[iCol2_StrInDate, Grid2.Rows.Count - 1].Value = dbRS["TRANSACTION_DATE"].ToString();

                        Grid2[iCol2_Vendor, Grid2.Rows.Count - 1].Value = dbRS["GIB_CUSTOMER"].ToString();
                        Grid2[iCol2_FabLot, Grid2.Rows.Count - 1].Value = dbRS["FAB_LOT_NO"].ToString();
                        Grid2[iCol2_MASK, Grid2.Rows.Count - 1].Value = dbRS["TYPENO"].ToString();
                        Grid2[iCol2_LotType, Grid2.Rows.Count - 1].Value = dbRS["LOT_TYPE"].ToString();
                        Grid2[iCol2_Size, Grid2.Rows.Count - 1].Value = dbRS["WAFER_SIZE"].ToString();
                        Grid2[iCol2_Rate, Grid2.Rows.Count - 1].Value = dbRS["YIELD"].ToString();

                        SubSetGridColor(ref Grid2, Grid2.Rows.Count - 1);
                    }
                    dbRS.Close();
                }

                clsDB.FunClsDB();

            }
        }

        private void btnHelp1_Click(object sender, EventArgs e)
        {
            clsASRS.gsHelpStyle = "LOC_E";
            Array.Resize<string>(ref clsASRS.gsHelpRtnData, 1);
            clsASRS.gsHelpRtnData[0] = "";

            frmHelp frmHelp = new frmHelp();
            frmHelp.ShowDialog();

            if (clsASRS.gsHelpRtnData[0] != "")
            {
                string[] aData = new string[0];
                aData = clsASRS.gsHelpRtnData[0].Split(',');
                txtLoc.Text = aData[0];
                txtLocID.Text = aData[1];

                if (FunGetLoc() == true)
                {
                    txtLoc.Enabled = false;
                    txtLocID.Enabled = false;
                    btnHelp1.Enabled = false;
                    btnHelp2.Enabled = false;
                    cmdQuery.Enabled = false;
                }
            }
        }

        private void btnHelp2_Click(object sender, EventArgs e)
        {
            clsASRS.gsHelpStyle = "LOC_E";
            Array.Resize<string>(ref clsASRS.gsHelpRtnData, 1);
            clsASRS.gsHelpRtnData[0] = "";

            frmHelp frmHelp = new frmHelp();
            frmHelp.ShowDialog();

            if (clsASRS.gsHelpRtnData[0] != "")
            {
                string[] aData = new string[0];
                aData = clsASRS.gsHelpRtnData[0].Split(',');
                txtLoc.Text = aData[0];
                txtLocID.Text = aData[1];

                if (FunGetLoc() == true)
                {
                    txtLoc.Enabled = false;
                    txtLocID.Enabled = false;
                    btnHelp1.Enabled = false;
                    btnHelp2.Enabled = false;
                    cmdQuery.Enabled = false;
                }
            }
        }

        private void cmdQuery_Click(object sender, EventArgs e)
        {
            if (FunGetLoc() == true)
            {
                txtLoc.Enabled = false;
                txtLocID.Enabled = false;
                btnHelp1.Enabled = false;
                btnHelp2.Enabled = false;
                cmdQuery.Enabled = false;
            }
        }


        private bool FunGetLoc()
        {
            //string sSQL = ""; string sSQL_tmp = ""; DbDataReader oRS = null;
            string sLoc = "";

            Grid1.RowCount = 0;

            if ((txtLoc.Text.Trim() == "") && (txtLocID.Text.Trim() == ""))
            {
                clsMSG.ShowWarningMsg("請輸入要入庫的儲位ID料盤ID ");
                return false;
            }

            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return false; };

            //判斷儲位主檔是否正確
            sLoc = SubGetLoc_ChkLocMst();
            if (sLoc == "") { clsDB.FunClsDB(); return false; }

            #region Mark
            //讀取儲位明細
            //        sSQL = "SELECT * FROM LOC_DTL WHERE LOC = '" & sLoc & "' "
            //        If FunRsSql_None(sSQL, oRS) Then
            //            If oRS.HasRows Then
            //                While oRS.Read()
            //                    Grid1.Rows.Add()
            //                    Grid1.Item(iCol_SubLoc, Grid1.Rows.Count - 1).Value = oRS("SUBLOC").ToString
            //                    Grid1.Item(iCol_ITEM, Grid1.Rows.Count - 1).Value = oRS("ITEMNO").ToString
            //                    Grid1.Item(iCol_CUST, Grid1.Rows.Count - 1).Value = oRS("CUSTOMER").ToString
            //                    Grid1.Item(iCol_DEV, Grid1.Rows.Count - 1).Value = oRS("DEVICE").ToString
            //                    Grid1.Item(iCol_LotNo, Grid1.Rows.Count - 1).Value = oRS("LOTNO").ToString
            //                    Grid1.Item(iCol_Store, Grid1.Rows.Count - 1).Value = oRS("STORE").ToString
            //                    Grid1.Item(iCol_OffQty, Grid1.Rows.Count - 1).Value = oRS("OFFQTY").ToString
            //                    Grid1.Item(iCol_WaferQty, Grid1.Rows.Count - 1).Value = oRS("WAFERQTY").ToString
            //                    Grid1.Item(iCol_ShipQty, Grid1.Rows.Count - 1).Value = oRS("SHIPQTY").ToString
            //                    Grid1.Item(iCol_ChkIQC, Grid1.Rows.Count - 1).Value = oRS("CHKIQC").ToString
            //                    Grid1.Item(iCol_FOSBID, Grid1.Rows.Count - 1).Value = oRS("FOSBID").ToString
            //                    Grid1.Item(iCol_ACCID, Grid1.Rows.Count - 1).Value = oRS("ACC_ID").ToString
            //                    Grid1.Item(iCol_InDate, Grid1.Rows.Count - 1).Value = Format(oRS("INDATE"), "yyyy/MM/dd HH:mm:ss").ToString
            //                    Grid1.Item(iCol_Remark, Grid1.Rows.Count - 1).Value = oRS("REMARK").ToString
            //                    Grid1.Item(iCol_TRANSACTION_DATE, Grid1.Rows.Count - 1).Value = Format(oRS("TRANSACTION_DATE"), "yyyy/MM/dd HH:mm:ss").ToString
            //                    Grid1.Item(iCol_GIB_CUSTOMER, Grid1.Rows.Count - 1).Value = oRS("GIB_CUSTOMER").ToString
            //                    Grid1.Item(iCol_FAB_LOT_NO, Grid1.Rows.Count - 1).Value = oRS("FAB_LOT_NO").ToString
            //                    Grid1.Item(iCol_FAB_TYPE, Grid1.Rows.Count - 1).Value = oRS("FAB_TYPE").ToString
            //                    Grid1.Item(iCol_TYPENO, Grid1.Rows.Count - 1).Value = oRS("TYPENO").ToString
            //                    Grid1.Item(iCol_LOT_TYPE, Grid1.Rows.Count - 1).Value = oRS("LOT_TYPE").ToString
            //                    Grid1.Item(iCol_WAFER_SIZE, Grid1.Rows.Count - 1).Value = oRS("WAFER_SIZE").ToString
            //                    Grid1.Item(iCol_YIELD, Grid1.Rows.Count - 1).Value = oRS("YIELD").ToString
            //                    Grid1.Item(iCol_APP_NO, Grid1.Rows.Count - 1).Value = oRS("APP_NO").ToString
            //                    Grid1.Item(iCol_REL_DATE, Grid1.Rows.Count - 1).Value = oRS("REL_DATE").ToString
            //                    Grid1.Item(iCol_REASON_NAME, Grid1.Rows.Count - 1).Value = oRS("REASON_NAME").ToString
            //                    Grid1.Item(iCol_TRANSACTION_REFERENCE, Grid1.Rows.Count - 1).Value = oRS("TRANSACTION_REFERENCE").ToString
            //                    Grid1.Item(iCol_TRANSACTION_SOURCE_ID, Grid1.Rows.Count - 1).Value = oRS("TRANSACTION_SOURCE_ID").ToString
            //                    Grid1.Item(iCol_TRANSACTION_TYPE_ID, Grid1.Rows.Count - 1).Value = oRS("TRANSACTION_TYPE_ID").ToString
            //                    Grid1.Item(iCol_FROM_ORG, Grid1.Rows.Count - 1).Value = oRS("FROM_ORG").ToString
            //                    Grid1.Item(iCol_TO_ORG, Grid1.Rows.Count - 1).Value = oRS("TO_ORG").ToString
            //                    Grid1.Item(iCol_FROM_BANK, Grid1.Rows.Count - 1).Value = oRS("FROM_BANK").ToString
            //                    Grid1.Item(iCol_TO_BANK, Grid1.Rows.Count - 1).Value = oRS("TO_BANK").ToString
            //                    Grid1.Item(iCol_FlagQty, Grid1.RowCount - 1).Value = "X"
            //                End While
            //            Else
            //                '無資料
            //            End If
            //            oRS.Close()
            //        Else
            //            'SQL錯誤則離開
            //            GoTo ErrorHandler
            //        End If

            //        FunGetLoc = True
            //        OleDBConn.Close()
            //        Grid1.Enabled = True
            //        Me.Cursor = Cursors.Default
            //        Exit Function
            //ErrorHandler:
            //        OleDBConn.Close()
            //        Grid1.Enabled = True
            #endregion

            return true;
        }


        private string SubGetLoc_ChkLocMst()
        {
            string sSQL = ""; string sSQL_tmp = ""; DbDataReader oRS = null;
            string sLoc = ""; string sLocID = "";
            bool bIsPass = true;
            
            sSQL = "SELECT LOCSTS,MIXQTY,LOC,LOCID FROM LOC_MST ";
            if (txtLoc.Text.Trim() != "")
            {
                if (sSQL_tmp == "")
                {
                    sSQL_tmp = sSQL_tmp + "WHERE LOC = '" + txtLoc.Text + "' ";
                }
                else
                {
                    sSQL_tmp = sSQL_tmp + "AND LOC = '" + txtLoc.Text + "' ";
                }
            }
            if (txtLocID.Text.Trim() != "")
            {
                if (sSQL_tmp == "")
                {
                    sSQL_tmp = sSQL_tmp + "WHERE LOCID = '" + txtLocID.Text + "' ";
                }
                else
                {
                    sSQL_tmp = sSQL_tmp + "AND LOCID = '" + txtLocID.Text + "' ";
                }
            }
            sSQL = sSQL + sSQL_tmp;
            if (clsDB.FunRsSql(sSQL, ref oRS))
            {
                while (oRS.Read())
                {
                    sLoc = oRS["LOC"].ToString();
                    sLocID = oRS["LOCID"].ToString();
                    if (oRS["LOCSTS"].ToString() == "E")
                    {
                        bIsPass = true;
                    }
                    else if (oRS["LOCSTS"].ToString() == "S")
                    {
                        clsMSG.ShowWarningMsg("此儲位己滿,不能再做入庫功能!!");
                        bIsPass = false;
                    }            
                }
                oRS.Close();
            }
            else
            {
                clsMSG.ShowWarningMsg("無此儲位或料盤條碼");
                bIsPass = false;
                txtLoc.Text = "";
                txtLocID.Text = "";
            }

            if (bIsPass == true)
            {
                txtLoc.Text = sLoc;
                txtLocID.Text = sLocID;
                return sLoc;  
            }
            else
            {
                txtLoc.Text = "";
                txtLocID.Text = "";
                return "";
            }
        }

        private void BtnAddLoc_Click(object sender, EventArgs e)
        {
            int i = 0;
            bool bIsSel = false;

            for (i = 0; i <= Grid2.RowCount - 1; i++)
            {
                if (Grid2.Rows[i].HeaderCell.Value.ToString() == "*")
                {
                    bIsSel = true;
                    break;
                }
            }
            if (bIsSel == false)
            {
                clsMSG.ShowWarningMsg("請選擇要放入儲位的無帳資料");
                return;
            }

            if (chkLocAuto.Checked == true)
            {
                //預設讀取一個儲位
                if ((txtLoc.Text != "") && (txtLoc.Enabled == false))
                {
                    //己有資料
                }
                else
                {
                    SubGetDefaultLoc();
                    if (txtLoc.Text == "")
                    {
                        return;
                    }
                }
            }
            else
            {
                if (txtLoc.Enabled == true)
                {
                    clsMSG.ShowWarningMsg("請輸入要入庫的儲位");
                    return;
                }
                if (txtLoc.Text == "")
                {
                    clsMSG.ShowWarningMsg("請輸入要入庫的儲位");
                    return;
                }
            }

        
            for (i = 0; i <= Grid2.RowCount - 1; i++)
            {
                if (Grid2.Rows[i].HeaderCell.Value == "*")
                {
                    Grid1.Rows.Add();
                    Grid1[iCol_SubLoc, Grid1.Rows.Count - 1].Value = "";
                    Grid1[iCol_ITEM, Grid1.Rows.Count - 1].Value = Grid2[iCol2_ITEM, i].Value.ToString();
                    Grid1[iCol_CUST, Grid1.Rows.Count - 1].Value = Grid2[iCol2_CUST, i].Value.ToString();
                    Grid1[iCol_DEV, Grid1.Rows.Count - 1].Value = Grid2[iCol2_DEV, i].Value.ToString();
                    Grid1[iCol_LotNo, Grid1.Rows.Count - 1].Value = Grid2[iCol2_LotNo, i].Value.ToString();
                    Grid1[iCol_Store, Grid1.Rows.Count - 1].Value = Grid2[iCol2_STYLE, i].Value.ToString();
                    Grid1[iCol_OffQty, Grid1.Rows.Count - 1].Value = Grid2[iCol2_OffQty, i].Value.ToString();
                    Grid1[iCol_WaferQty, Grid1.Rows.Count - 1].Value = Grid2[iCol2_WaferQty, i].Value.ToString();
                    Grid1[iCol_ShipQty, Grid1.Rows.Count - 1].Value = Grid2[iCol2_ShipQty, i].Value.ToString();
                    Grid1[iCol_ChkIQC, Grid1.Rows.Count - 1].Value = "N";
                    Grid1[iCol_FOSBID, Grid1.Rows.Count - 1].Value = Grid2[iCol2_ACCID, i].Value.ToString();
                    Grid1[iCol_ACCID, Grid1.Rows.Count - 1].Value = Grid2[iCol2_ACCID, i].Value.ToString();
                    Grid1[iCol_InDate, Grid1.Rows.Count - 1].Value = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                    Grid1[iCol_Remark, Grid1.Rows.Count - 1].Value = Grid2[iCol2_Remark, i].Value.ToString();
                    Grid1[iCol_TRANSACTION_DATE, Grid1.Rows.Count - 1].Value = Grid2[iCol2_StrInDate, i].Value.ToString();
                    Grid1[iCol_GIB_CUSTOMER, Grid1.Rows.Count - 1].Value = Grid2[iCol2_Vendor, i].Value.ToString();
                    Grid1[iCol_FAB_LOT_NO, Grid1.Rows.Count - 1].Value = Grid2[iCol2_FabLot, i].Value.ToString();
                    Grid1[iCol_FAB_TYPE, Grid1.Rows.Count - 1].Value = Grid2[iCol2_DEV, i].Value.ToString();
                    Grid1[iCol_TYPENO, Grid1.Rows.Count - 1].Value = Grid2[iCol2_MASK, i].Value.ToString();
                    Grid1[iCol_LOT_TYPE, Grid1.Rows.Count - 1].Value = Grid2[iCol2_LotType, i].Value.ToString();
                    Grid1[iCol_WAFER_SIZE, Grid1.Rows.Count - 1].Value = Grid2[iCol2_Size, i].Value.ToString();
                    Grid1[iCol_YIELD, Grid1.Rows.Count - 1].Value = Grid2[iCol2_Rate, i].Value.ToString();
                    Grid1[iCol_APP_NO, Grid1.Rows.Count - 1].Value = " ";
                    Grid1[iCol_REL_DATE, Grid1.Rows.Count - 1].Value = " ";
                    Grid1[iCol_REASON_NAME, Grid1.Rows.Count - 1].Value = " ";
                    Grid1[iCol_TRANSACTION_REFERENCE, Grid1.Rows.Count - 1].Value = " ";
                    Grid1[iCol_TRANSACTION_SOURCE_ID, Grid1.Rows.Count - 1].Value = " ";
                    Grid1[iCol_TRANSACTION_TYPE_ID, Grid1.Rows.Count - 1].Value = " ";
                    Grid1[iCol_FROM_ORG, Grid1.Rows.Count - 1].Value = " ";
                    Grid1[iCol_TO_ORG, Grid1.Rows.Count - 1].Value = " ";
                    Grid1[iCol_FROM_BANK, Grid1.Rows.Count - 1].Value = " ";
                    Grid1[iCol_TO_BANK, Grid1.Rows.Count - 1].Value = " ";
                    Grid1[iCol_FlagQty, Grid1.RowCount - 1].Value = "A";

                    SubSetGridColor_Selected(ref Grid2, i, true);

                }
            }
        
        }

        private void SubGetDefaultLoc()
        {
            string sSQL = ""; DbDataReader dbRS = null;
            string sLoc = ""; string sLocID = "";

            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };
            
            sSQL = "SELECT M.LOC,M.LOCID,M.LOCSTS,D.ONDATA FROM LOC_MST M LEFT JOIN LOC_DTL D ON M.LOC = D.LOC ";
            sSQL = sSQL + "WHERE M.LOCSTS = 'E' ";
            sSQL = sSQL + "ORDER BY M.LVL_Z,M.BAY_Y,M.ROW_X ";

            if (clsDB.FunRsSql(sSQL, ref dbRS))
            {
                while (dbRS.Read())
                {
                    sLoc = dbRS["LOC"].ToString();
                    sLocID = dbRS["LOCID"].ToString();
                }
                dbRS.Close();               
            }

            if ((sLoc != "") && (sLocID != ""))
            {
                txtLoc.Text = sLoc;
                txtLocID.Text = sLocID;
                if (FunGetLoc() == true)
                {
                    txtLoc.Enabled = false;
                    txtLocID.Enabled = false;
                    btnHelp1.Enabled = false;
                    btnHelp2.Enabled = false;
                    cmdQuery.Enabled = false;
                }
            }
            else
            {
                txtLoc.Text = "";
                txtLocID.Text = "";
                clsMSG.ShowWarningMsg("己沒有儲位可入庫!!");
            }

            clsDB.FunClsDB();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            string sSQL = ""; //DbDataReader dbRS = null;
            string sLoc = ""; string sLocID = ""; //string sLocSts = "";

            if (FunChkData() == false) { return; }

            sLoc = txtLoc.Text;
            sLocID = txtLocID.Text;

            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };

            #region 判斷是否有儲位重整中
            string sMsg = "";
            if (clsASRS.FunChkCycleStsIsRunning(ref sMsg) == false)
            {
                clsMSG.ShowInformationMsg(sMsg);
                clsDB.FunClsDB();
                return;
            }
            #endregion

            #region 取得命令序號
            string sCmdSno = clsASRS.FunGetCmdSno();
            if (sCmdSno == "")
            {
                clsMSG.ShowErrMsg("系統錯誤,無命令序號可使用!!");
                clsDB.FunClsDB(); return;
            }
            #endregion

            clsDB.FunCommitCtrl("BEGIN");

            #region 判斷是否有儲位重整中
            string sTmpMsg = "";
            if (clsASRS.FunChkCycleStsIsRunning(ref sTmpMsg) == false)
            {
                clsMSG.ShowInformationMsg(sTmpMsg);
                clsDB.FunClsDB();
                return;
            }
            #endregion

            #region 產生命令主檔
            cls_CmdMst aCmdMst = new cls_CmdMst();
            aCmdMst.FunCmdMstClear();   //Clear()
            aCmdMst.CMDSNO = sCmdSno;
            aCmdMst.CMDMODE = clsASRS.gsCmdMode_Out;   //2

            aCmdMst.SNO1 = "1";
            aCmdMst.LOC1 = sLoc;
            aCmdMst.LOCID1 = sLocID;
            aCmdMst.SCAN1 = "Y";

            aCmdMst.SNO2 = "";
            aCmdMst.LOC2 = "";
            aCmdMst.LOCID2 = "";
            aCmdMst.SCAN2 = "Y";            

            aCmdMst.CMDSTS = "0";
            aCmdMst.PRT = "5";
            aCmdMst.STNNO = cboStnNo.Text;
            aCmdMst.IOTYP = clsASRS.gsIOTYPE_Offline_In;
            aCmdMst.AVAIL = "0";
            aCmdMst.MIXQTY = "0";
            aCmdMst.NEWLOC = "";
            aCmdMst.PROGID = clsASRS.gsIOTYPE_Offline_In_PID;
            aCmdMst.USERID = clsASRS.gstrLoginUser;
            aCmdMst.TRACE = "0";
            aCmdMst.STORAGETYP = "";
            if (aCmdMst.FunInsCmdMst() == false)
            {
                clsDB.FunCommitCtrl("ROLLBACK");
                clsMSG.ShowErrMsg(clsMSG.MSG.COMMAND_ERROR);
                clsDB.FunClsDB();
                this.Cursor = Cursors.Default;
                return;
            }
            #endregion
            

            #region 產生命令明細檔
            cls_CmdDtl aCmdDtl = new cls_CmdDtl();
            int i = 0;
            for (i = 0; i <= Grid1.RowCount - 1; i++)
            {
                #region Get出庫明細 objGridTmp Data
                aCmdDtl.CMDSNO = sCmdSno;
                aCmdDtl.SNO = "1";
                //aCmdDtl.LOC = objGridTmp[iCol_Loc, 0].Value.ToString();
                aCmdDtl.LOCID = sLocID;
                aCmdDtl.SUBLOC = ""; //No Use
                aCmdDtl.ITEMNO = Grid1[iCol_ITEM, i].Value.ToString();
                aCmdDtl.CUSTOMER = Grid1[iCol_CUST, i].Value.ToString();
                aCmdDtl.DEVICE = Grid1[iCol_DEV, i].Value.ToString();
                aCmdDtl.LOTNO = Grid1[iCol_LotNo, i].Value.ToString();
                aCmdDtl.STORE = Grid1[iCol_Store, i].Value.ToString();
                aCmdDtl.OFFQTY = clsTool.INT(Grid1[iCol_OffQty, i].Value.ToString());
                aCmdDtl.WAFERQTY = clsTool.INT(Grid1[iCol_WaferQty, i].Value.ToString());
                aCmdDtl.SHIPQTY = clsTool.INT(Grid1[iCol_ShipQty, i].Value.ToString());

                aCmdDtl.OFFACTQTY = clsTool.INT(Grid1[iCol_OffQty, i].Value.ToString());
                aCmdDtl.WAFERACTQTY = clsTool.INT(Grid1[iCol_WaferQty, i].Value.ToString());
                aCmdDtl.SHIPACTQTY = clsTool.INT(Grid1[iCol_ShipQty, i].Value.ToString());
                aCmdDtl.FLAGQTY = "A";

                aCmdDtl.CHKIQC = Grid1[iCol_ChkIQC, i].Value.ToString();
                aCmdDtl.FOSBID = Grid1[iCol_FOSBID, i].Value.ToString();
                aCmdDtl.IQC_ID = "";
                aCmdDtl.ACC_ID = Grid1[iCol_ACCID, i].Value.ToString();
                aCmdDtl.INDATE = Grid1[iCol_InDate, i].Value.ToString();
                aCmdDtl.REMARK = Grid1[iCol_Remark, i].Value.ToString();
                aCmdDtl.TRANSACTION_DATE = Grid1[iCol_TRANSACTION_DATE, i].Value.ToString();
                if (aCmdDtl.TRANSACTION_DATE == "")
                {
                    aCmdDtl.TRANSACTION_DATE = clsTool.GetDateTime(); //Format(Now, "yyyy/MM/dd HH:mm:ss")
                }
                aCmdDtl.GIB_CUSTOMER = Grid1[iCol_GIB_CUSTOMER, i].Value.ToString();
                aCmdDtl.FAB_LOT_NO = Grid1[iCol_FAB_LOT_NO, i].Value.ToString();
                aCmdDtl.FAB_TYPE = Grid1[iCol_FAB_TYPE, i].Value.ToString();
                aCmdDtl.TYPENO = Grid1[iCol_TYPENO, i].Value.ToString();
                aCmdDtl.LOT_TYPE = Grid1[iCol_LOT_TYPE, i].Value.ToString();
                aCmdDtl.WAFER_SIZE = Grid1[iCol_WAFER_SIZE, i].Value.ToString();
                aCmdDtl.YIELD = Grid1[iCol_YIELD, i].Value.ToString();
                aCmdDtl.APP_NO = Grid1[iCol_APP_NO, i].Value.ToString();
                aCmdDtl.REL_DATE = Grid1[iCol_REL_DATE, i].Value.ToString();
                aCmdDtl.REASON_NAME = Grid1[iCol_REASON_NAME, i].Value.ToString();
                aCmdDtl.TRANSACTION_REFERENCE = Grid1[iCol_TRANSACTION_REFERENCE, i].Value.ToString();
                aCmdDtl.TRANSACTION_SOURCE_ID = Grid1[iCol_TRANSACTION_SOURCE_ID, i].Value.ToString();
                aCmdDtl.TRANSACTION_TYPE_ID = Grid1[iCol_TRANSACTION_TYPE_ID, i].Value.ToString();
                aCmdDtl.FROM_ORG = Grid1[iCol_FROM_ORG, i].Value.ToString();
                aCmdDtl.TO_ORG = Grid1[iCol_TO_ORG, i].Value.ToString();
                aCmdDtl.FROM_BANK = Grid1[iCol_FROM_BANK, i].Value.ToString();
                aCmdDtl.TO_BANK = Grid1[iCol_TO_BANK, i].Value.ToString();
                aCmdDtl.CYCLENO ="";       //'WMS
                aCmdDtl.COID = "";// objGridTmp[iCol_COID, j].Value.ToString();
                aCmdDtl.DOCID = "";        // 'WMS
                aCmdDtl.DOCID2 = "";//? objGridTmp[iCol_DOCID2, j].Value.ToString();       // 'WMS
                #endregion

                if (aCmdDtl.FunInsCmdDtl() == false)
                {
                    clsDB.FunCommitCtrl("ROLLBACK");
                    clsMSG.ShowErrMsg(clsMSG.MSG.COMMAND_ERROR);
                    clsDB.FunClsDB();
                    this.Cursor = Cursors.Default;
                    return;
                }

                sSQL = "DELETE FROM TRNTKT_ACC ";                
                sSQL = sSQL + "WHERE ACC_ID = '" + Grid1[iCol_ACCID, i].Value.ToString() + "' ";
                if (clsDB.FunExecSql(sSQL) == false)
                {
                    clsDB.FunCommitCtrl("ROLLBACK");
                    clsMSG.ShowErrMsg(clsMSG.MSG.COMMAND_ERROR);
                    clsDB.FunClsDB();
                    this.Cursor = Cursors.Default;
                    return;
                }
            }
            #endregion

            clsDB.FunCommitCtrl("COMMIT");
            clsMSG.ShowInformationMsg(clsMSG.MSG.Msg_Run_Finish);
            clsDB.FunClsDB();

            FormClear();
            SubClrForm();
        }

        //防呆無資料判斷
        private bool FunChkData()
        {
            if (Grid2.RowCount <= 0)
            {
                clsMSG.ShowWarningMsg("請輸入無帳資料");
                return false;
            }

            if (txtLoc.Text.Trim() == "")
            {
                clsMSG.ShowWarningMsg("請輸入要入庫的儲位");
                return false;
            }

            if (Grid1.RowCount <= 0)
            {
                clsMSG.ShowWarningMsg("請加入無帳的資料");
                return false;
            }

            if (cboStnNo.Text.Trim() == "")
            {
                clsMSG.ShowWarningMsg(clsMSG.MSG.Msg_Pls_Input_StnNo);
                return false;
            }
            else
            {
                //clsMSG.ShowWarningMsg(clsMSG.MSG.Msg_Pls_Input_Right_StnNo);
                //return false;

            }
            return true;
        }

        private void btnExit2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
