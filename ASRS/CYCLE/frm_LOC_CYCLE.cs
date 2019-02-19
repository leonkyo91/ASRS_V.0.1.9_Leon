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
    public partial class frm_LOC_CYCLE : Form
    {
        #region Grid Prarm
        int iCol_Loc = 0;           //儲位
        int iCol_LocSts = 1;        //儲位狀態
        int iCol_LocID = 2;         //料盤ID
        int iCol_SubLoc = 3;        //L/R (No use
        int iCol_ITEM = 4;          //ITEM No
        int iCol_Cust = 5;          //客戶簡稱 
        int iCol_Dev = 6;           //DEVICE
        int iCol_LotNo = 7;         //Lot No
        int iCol_OffQty = 8;
        int iCol_WaferQty = 9;      //枚數
        int iCol_ShipQty = 10;       //數量
        int iCol_ChkIQC = 11;       //檢驗
        int iCol_InDate = 12;       //'入庫日期
        int iCol_TrnDate = 13;      //'異動日期

        int iCol_FOSBID = 14;                   //'收料序號(FOSB條碼)
        int iCol_REMARK = 15;                 // '備註
        int iCol_TRANSACTION_DATE = 16;         //'收料日期
        int iCol_GIB_CUSTOMER = 17;             //'來貨廠商
        int iCol_FAB_LOT_NO = 18;               //Fab lot
        int iCol_FAB_TYPE = 19;                 //'晶圓廠別
        int iCol_TYPENO = 20;                   //'Mask
        int iCol_LOT_TYPE = 21;                 //'Lot Type
        int iCol_WAFER_SIZE = 22;              //'Size
        int iCol_YIELD = 23;                    //'良率
        int iCol_APP_NO = 24;                   //'報單號碼
        int iCol_REL_DATE = 25;                 //'報單日期
        int iCol_REASON_NAME = 26;              //'Reason Code
        int iCol_TRANSACTION_REFERENCE = 27;    //'Reference
        int iCol_TRANSACTION_SOURCE_ID = 28;    //'Source ID
        int iCol_TRANSACTION_TYPE_ID = 29;     //'Transaction Type
        int iCol_FROM_ORG = 30;                 //'From Org ID
        int iCol_TO_ORG = 31;                   //'To Org ID
        int iCol_FROM_BANK = 32;                //'From Bank
        int iCol_TO_BANK = 33;                  //'To Bank

        int iCol_Store = 34;
        int iCol_IQCID = 35;
        int iCol_ACCID = 36;
        int iCol_MIXQTY = 37;
        int iCol_AVAIL = 38;
        int iCol_ONDATA = 39;
        int iCol_DOCID = 40;        //'WMS上架單號
        int iCol_Counts = 41;
        #endregion

        public frm_LOC_CYCLE()
        {
            InitializeComponent();
        }

        private void frm_LOC_CYCLE_Load(object sender, EventArgs e)
        {
            GridInit();
            FormInit();
        }

        private void GridInit()
        {
            GridSysInit(ref Grid1); GridSetRange(ref Grid1);
            GridSysInit(ref tmpGrid1); GridSetRange(ref tmpGrid1);
            GridSysInit(ref tmpGrid2); GridSetRange(ref tmpGrid2);
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
            oGrid.RowCount = 1;

            oGrid.Columns[iCol_Loc].Width = 50; oGrid.Columns[iCol_Loc].Name = "儲位";
            oGrid.Columns[iCol_LocSts].Width = 40; oGrid.Columns[iCol_LocSts].Name = "儲位狀態";
            oGrid.Columns[iCol_LocID].Width = 40; oGrid.Columns[iCol_LocID].Name = "料盤ID";
            oGrid.Columns[iCol_SubLoc].Width = 40; oGrid.Columns[iCol_SubLoc].Name = "L/R"; oGrid.Columns[iCol_SubLoc].Visible = false;
            oGrid.Columns[iCol_ITEM].Width = 80; oGrid.Columns[iCol_ITEM].Name = "ITEM NO";
            oGrid.Columns[iCol_Cust].Width = 80; oGrid.Columns[iCol_Cust].Name = "客戶簡稱";
            oGrid.Columns[iCol_Dev].Width = 80; oGrid.Columns[iCol_Dev].Name = "DEVICE";
            oGrid.Columns[iCol_LotNo].Width = 80; oGrid.Columns[iCol_LotNo].Name = "LOT NO";
            oGrid.Columns[iCol_OffQty].Width = 40; oGrid.Columns[iCol_OffQty].Name = "件數";
            oGrid.Columns[iCol_WaferQty].Width = 40; oGrid.Columns[iCol_WaferQty].Name = "枚數";
            oGrid.Columns[iCol_ShipQty].Width = 40; oGrid.Columns[iCol_ShipQty].Name = "數量";
            oGrid.Columns[iCol_ChkIQC].Width = 40; oGrid.Columns[iCol_ChkIQC].Name = "檢驗";
            oGrid.Columns[iCol_InDate].Width = 100; oGrid.Columns[iCol_InDate].Name = "入庫時間";
            oGrid.Columns[iCol_TrnDate].Width = 100; oGrid.Columns[iCol_TrnDate].Name = "異動時間";
            oGrid.Columns[iCol_FOSBID].Width = 80; oGrid.Columns[iCol_FOSBID].Name = "收料序號";
            oGrid.Columns[iCol_REMARK].Width = 80; oGrid.Columns[iCol_REMARK].Name = "備註";
            oGrid.Columns[iCol_TRANSACTION_DATE].Width = 100; oGrid.Columns[iCol_TRANSACTION_DATE].Name = "收料日期";

            oGrid.Columns[iCol_GIB_CUSTOMER].Width = 80; oGrid.Columns[iCol_GIB_CUSTOMER].Name = "來貨廠商"; oGrid.Columns[iCol_GIB_CUSTOMER].Visible = false;
            oGrid.Columns[iCol_FAB_LOT_NO].Width = 80; oGrid.Columns[iCol_FAB_LOT_NO].Name = "Fab lot"; oGrid.Columns[iCol_FAB_LOT_NO].Visible = false;
            oGrid.Columns[iCol_FAB_TYPE].Width = 80; oGrid.Columns[iCol_FAB_TYPE].Name = "晶圓廠別"; oGrid.Columns[iCol_FAB_TYPE].Visible = false;
            oGrid.Columns[iCol_TYPENO].Width = 80; oGrid.Columns[iCol_TYPENO].Name = "Mask"; oGrid.Columns[iCol_TYPENO].Visible = false;
            oGrid.Columns[iCol_LOT_TYPE].Width = 80; oGrid.Columns[iCol_LOT_TYPE].Name = "Lot Type"; oGrid.Columns[iCol_LOT_TYPE].Visible = false;
            oGrid.Columns[iCol_WAFER_SIZE].Width = 80; oGrid.Columns[iCol_WAFER_SIZE].Name = "Size"; oGrid.Columns[iCol_WAFER_SIZE].Visible = false;
            oGrid.Columns[iCol_YIELD].Width = 80; oGrid.Columns[iCol_YIELD].Name = "良率"; oGrid.Columns[iCol_YIELD].Visible = false;
            oGrid.Columns[iCol_APP_NO].Width = 80; oGrid.Columns[iCol_APP_NO].Name = "報單號碼"; oGrid.Columns[iCol_APP_NO].Visible = false;
            oGrid.Columns[iCol_REL_DATE].Width = 100; oGrid.Columns[iCol_REL_DATE].Name = "報單日期"; oGrid.Columns[iCol_REL_DATE].Visible = false;
            oGrid.Columns[iCol_REASON_NAME].Width = 100; oGrid.Columns[iCol_REASON_NAME].Name = "Reason Code"; oGrid.Columns[iCol_REASON_NAME].Visible = false;
            oGrid.Columns[iCol_TRANSACTION_REFERENCE].Width = 100; oGrid.Columns[iCol_TRANSACTION_REFERENCE].Name = "Reference"; oGrid.Columns[iCol_TRANSACTION_REFERENCE].Visible = false;
            oGrid.Columns[iCol_TRANSACTION_SOURCE_ID].Width = 100; oGrid.Columns[iCol_TRANSACTION_SOURCE_ID].Name = "Source ID"; oGrid.Columns[iCol_TRANSACTION_SOURCE_ID].Visible = false;
            oGrid.Columns[iCol_TRANSACTION_TYPE_ID].Width = 100; oGrid.Columns[iCol_TRANSACTION_TYPE_ID].Name = "Transaction Type"; oGrid.Columns[iCol_TRANSACTION_TYPE_ID].Visible = false;
            oGrid.Columns[iCol_FROM_ORG].Width = 100; oGrid.Columns[iCol_FROM_ORG].Name = "From Org ID"; oGrid.Columns[iCol_FROM_ORG].Visible = false;
            oGrid.Columns[iCol_TO_ORG].Width = 100; oGrid.Columns[iCol_TO_ORG].Name = "To Org ID"; oGrid.Columns[iCol_TO_ORG].Visible = false;
            oGrid.Columns[iCol_FROM_BANK].Width = 100; oGrid.Columns[iCol_FROM_BANK].Name = "From Bank"; oGrid.Columns[iCol_FROM_BANK].Visible = false;
            oGrid.Columns[iCol_TO_BANK].Width = 100; oGrid.Columns[iCol_TO_BANK].Name = "To Bank"; oGrid.Columns[iCol_TO_BANK].Visible = false;

            oGrid.Columns[iCol_DOCID].Width = 100; oGrid.Columns[iCol_DOCID].Name = "WMS上架單號"; oGrid.Columns[iCol_DOCID].Visible = false;

            oGrid.Columns[iCol_Store].Width = 0; oGrid.Columns[iCol_Store].Name = ""; oGrid.Columns[iCol_Store].Visible = false;
            oGrid.Columns[iCol_IQCID].Width = 0; oGrid.Columns[iCol_IQCID].Name = ""; oGrid.Columns[iCol_IQCID].Visible = false;
            oGrid.Columns[iCol_ACCID].Width = 0; oGrid.Columns[iCol_ACCID].Name = ""; oGrid.Columns[iCol_ACCID].Visible = false;
            oGrid.Columns[iCol_MIXQTY].Width = 0; oGrid.Columns[iCol_MIXQTY].Name = ""; oGrid.Columns[iCol_MIXQTY].Visible = false;
            oGrid.Columns[iCol_AVAIL].Width = 0; oGrid.Columns[iCol_AVAIL].Name = ""; oGrid.Columns[iCol_AVAIL].Visible = false;
            oGrid.Columns[iCol_ONDATA].Width = 0; oGrid.Columns[iCol_ONDATA].Name = ""; oGrid.Columns[iCol_ONDATA].Visible = false;


                        
            int i = 0;
            for (i = 0; i <= oGrid.ColumnCount - 1; i++)
            {
                oGrid.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            oGrid.RowCount = 0;
        }

        private void FormInit()
        {
            txtCycleUser.Text = clsASRS.gstrLoginUser;
            clsASRS.SubCboSetStnNo(ref cboStnNo);


            #region Get Row,Bay,Lvl
            string strSql = ""; DbDataReader dbRS = null;
            int iValue  = 0;

            cboRowF.Items.Clear();
            cboRowT.Items.Clear();
            cboBayF.Items.Clear();
            cboBayT.Items.Clear();
            cboLvlF.Items.Clear();
            cboLvlT.Items.Clear();

            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };

            cboStnNo.Text = clsASRS.FunGetStnNoByAreaNo(clsASRS.gsAreaNo);

            strSql = "SELECT MAX(ROW_X),MAX(BAY_Y),MAX(LVL_Z) FROM LOC_MST";
            if (clsDB.FunRsSql(strSql, ref dbRS))
            {
                while (dbRS.Read())
                {
                    for (iValue = 1; iValue <= clsTool.INT(dbRS[0].ToString()); iValue++)
                    {
                        cboRowF.Items.Add(iValue);
                        cboRowT.Items.Add(iValue);
                    }
                    for (iValue = 1; iValue <= clsTool.INT(dbRS[1].ToString()); iValue++)
                    {
                        cboBayF.Items.Add(iValue);
                        cboBayT.Items.Add(iValue);
                    }
                    for (iValue = 1; iValue <= clsTool.INT(dbRS[2].ToString()); iValue++)
                    {
                        cboLvlF.Items.Add(iValue);
                        cboLvlT.Items.Add(iValue);
                    }
                }
                dbRS.Close();
            }
            cboRowF.SelectedIndex = 0;
            cboRowT.SelectedIndex = cboRowT.Items.Count - 1;
            cboBayF.SelectedIndex = 0;
            cboBayT.SelectedIndex = cboBayT.Items.Count - 1;
            cboLvlF.SelectedIndex = 0;
            cboLvlT.SelectedIndex = cboLvlT.Items.Count - 1;
            #endregion

            txtCycleNo.Text = clsASRS.FunGetCycleSno(); //取得盤點單號

            clsDB.FunClsDB();
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            SubClear();
        }

        private void SubClear()
        {
            Grid1.RowCount = 0; tmpGrid1.RowCount = 0; tmpGrid2.RowCount = 0;
            cboRowF.SelectedIndex = 0;
            cboRowT.SelectedIndex = cboRowT.Items.Count - 1;
            cboBayF.SelectedIndex = 0;
            cboBayT.SelectedIndex = cboBayT.Items.Count - 1;
            cboLvlF.SelectedIndex = 0;
            cboLvlT.SelectedIndex = cboLvlT.Items.Count - 1;
            txtLocIDF.Text = "";
            txtLocIDT.Text = "";
            txtLocCnt.Text = "";
            txtLotNoCount.Text = "";

            chkStnA01.Checked = false;
            chkStnA02.Checked = false;
            chkStnA03.Checked = false;
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdQuery_Click(object sender, EventArgs e)
        {
            SubQuery();
        }

        private void SubQuery()
        {
            string strSql = ""; DbDataReader dbRS = null;

            txtLocIDF.Text = txtLocIDF.Text.Trim().ToUpper();
            txtLocIDT.Text = txtLocIDT.Text.Trim().ToUpper();

            Grid1.RowCount = 0;
            txtLotNoCount.Text = "";

            #region SQL
            strSql = "SELECT M.LOCSTS,M.LOCID,M.AVAIL,M.MIXQTY,D.* FROM LOC_MST M,LOC_DTL D WHERE M.LOC=D.LOC AND M.LOCSTS <> 'E' AND M.LOCSTS <> 'N'  ";
            strSql = strSql + " AND M.ROW_X>=" + clsTool.INT(cboRowF.Text) + " AND M.ROW_X<=" + clsTool.INT(cboRowT.Text) + " "; //'ROW
            strSql = strSql + " AND M.BAY_Y>=" + clsTool.INT(cboBayF.Text) + " AND M.BAY_Y<=" + clsTool.INT(cboBayT.Text) + " "; //'BAY
            strSql = strSql + " AND M.LVL_Z>=" + clsTool.INT(cboLvlF.Text) + " AND M.LVL_Z<=" + clsTool.INT(cboLvlT.Text) + " "; //'LVL
            if (txtLocIDF.Text.Trim() != "")
            {
                if (txtLocIDT.Text.Trim() != "")
                {
                    strSql = strSql + " AND M.LOCID>='" + txtLocIDF.Text + "' AND M.LOCID<='" + txtLocIDT.Text + "'";
                }
                else
                {
                    strSql = strSql + " AND M.LOCID = '" + txtLocIDF.Text + "' ";
                }
            }

            if (RdBtn_1.Checked == true)
            {
                strSql = strSql + "AND D.ONDATA = 'N' ";
                Grid1.Columns[iCol_OffQty].Visible = true;
                Grid1.Columns[iCol_WaferQty].Visible = true;
            }
            else if (RdBtn_2.Checked == true)
            {
                strSql = strSql + "AND D.ONDATA = 'Y' ";
                Grid1.Columns[iCol_OffQty].Visible = false;
                Grid1.Columns[iCol_WaferQty].Visible = false;
            }
            else if (RdBtn_3.Checked == true)
            {
                Grid1.Columns[iCol_OffQty].Visible = true;
                Grid1.Columns[iCol_WaferQty].Visible = true;
            }
            strSql = strSql + " ORDER BY D.LOC ";
            #endregion

            #region GetData
            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };

            if (clsDB.FunRsSql(strSql, ref dbRS))
            {
                while (dbRS.Read())
                {
                    Grid1.Rows.Add();
                    Grid1.Rows[Grid1.RowCount - 1].HeaderCell.Value = "";
                    Grid1[iCol_Loc, Grid1.RowCount - 1].Value = dbRS["LOC"].ToString();
                    Grid1[iCol_LocSts, Grid1.RowCount - 1].Value = dbRS["LOCSTS"].ToString();
                    Grid1[iCol_LocID, Grid1.RowCount - 1].Value = dbRS["LOCID"].ToString();
                    Grid1[iCol_SubLoc, Grid1.RowCount - 1].Value = "";// dbRS["SUBLOC"].ToString();

                    Grid1[iCol_ITEM, Grid1.RowCount - 1].Value = dbRS["ITEMNO"].ToString();
                    Grid1[iCol_Cust, Grid1.RowCount - 1].Value = dbRS["CUSTOMER"].ToString();
                    Grid1[iCol_Dev, Grid1.RowCount - 1].Value = dbRS["DEVICE"].ToString();
                    Grid1[iCol_LotNo, Grid1.RowCount - 1].Value = dbRS["LOTNO"].ToString();
                    Grid1[iCol_Store, Grid1.RowCount - 1].Value = dbRS["STORE"].ToString();
                    Grid1[iCol_OffQty, Grid1.RowCount - 1].Value = dbRS["OFFQTY"].ToString();
                    Grid1[iCol_WaferQty, Grid1.RowCount - 1].Value = dbRS["WAFERQTY"].ToString();
                    Grid1[iCol_ShipQty, Grid1.RowCount - 1].Value = dbRS["SHIPQTY"].ToString();
                    Grid1[iCol_ChkIQC, Grid1.RowCount - 1].Value = dbRS["CHKIQC"].ToString();
                    Grid1[iCol_ONDATA, Grid1.RowCount - 1].Value = dbRS["ONDATA"].ToString();

                    Grid1[iCol_FOSBID, Grid1.RowCount - 1].Value = dbRS["FOSBID"].ToString();
                    Grid1[iCol_IQCID, Grid1.RowCount - 1].Value = dbRS["IQC_ID"].ToString();
                    Grid1[iCol_ACCID, Grid1.RowCount - 1].Value = dbRS["ACC_ID"].ToString();
                    Grid1[iCol_InDate, Grid1.RowCount - 1].Value = dbRS["INDATE"].ToString();
                    Grid1[iCol_TrnDate, Grid1.RowCount - 1].Value = dbRS["TRNDATE"].ToString();                      
                    Grid1[iCol_REMARK, Grid1.RowCount - 1].Value = dbRS["REMARK"].ToString();
                    Grid1[iCol_TRANSACTION_DATE, Grid1.RowCount - 1].Value = dbRS["TRANSACTION_DATE"].ToString();                    
                    Grid1[iCol_GIB_CUSTOMER, Grid1.RowCount - 1].Value = dbRS["GIB_CUSTOMER"].ToString();
                    Grid1[iCol_FAB_LOT_NO, Grid1.RowCount - 1].Value = dbRS["FAB_LOT_NO"].ToString();
                    Grid1[iCol_FAB_TYPE, Grid1.RowCount - 1].Value = dbRS["FAB_TYPE"].ToString();
                    Grid1[iCol_TYPENO, Grid1.RowCount - 1].Value = dbRS["TYPENO"].ToString();
                    Grid1[iCol_LOT_TYPE, Grid1.RowCount - 1].Value = dbRS["LOT_TYPE"].ToString();
                    Grid1[iCol_WAFER_SIZE, Grid1.RowCount - 1].Value = dbRS["WAFER_SIZE"].ToString();
                    Grid1[iCol_YIELD, Grid1.RowCount - 1].Value = dbRS["YIELD"].ToString();
                    Grid1[iCol_APP_NO, Grid1.RowCount - 1].Value = dbRS["APP_NO"].ToString();
                    Grid1[iCol_REL_DATE, Grid1.RowCount - 1].Value = dbRS["REL_DATE"].ToString();
                    Grid1[iCol_REASON_NAME, Grid1.RowCount - 1].Value = dbRS["REASON_NAME"].ToString();
                    Grid1[iCol_TRANSACTION_REFERENCE, Grid1.RowCount - 1].Value = dbRS["TRANSACTION_REFERENCE"].ToString();
                    Grid1[iCol_TRANSACTION_SOURCE_ID, Grid1.RowCount - 1].Value = dbRS["TRANSACTION_SOURCE_ID"].ToString();
                    Grid1[iCol_TRANSACTION_TYPE_ID, Grid1.RowCount - 1].Value = dbRS["TRANSACTION_TYPE_ID"].ToString();
                    Grid1[iCol_FROM_ORG, Grid1.RowCount - 1].Value = dbRS["FROM_ORG"].ToString();
                    Grid1[iCol_TO_ORG, Grid1.RowCount - 1].Value = dbRS["TO_ORG"].ToString();
                    Grid1[iCol_FROM_BANK, Grid1.RowCount - 1].Value = dbRS["FROM_BANK"].ToString();
                    Grid1[iCol_TO_BANK, Grid1.RowCount - 1].Value = dbRS["TO_BANK"].ToString();
                    Grid1[iCol_DOCID, Grid1.RowCount - 1].Value = dbRS["DOCID"].ToString();
                    
                    //loc_mst
                    Grid1[iCol_MIXQTY, Grid1.RowCount - 1].Value = dbRS["MIXQTY"].ToString();
                    Grid1[iCol_AVAIL, Grid1.RowCount - 1].Value = dbRS["AVAIL"].ToString();
                    
                }
                dbRS.Close();
            }
            
            clsDB.FunClsDB();
            #endregion

            txtLotNoCount.Text = clsASRS.FunGetFosbCnt(ref Grid1, iCol_FOSBID).ToString();
        }

        private void Grid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Grid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex < 0) || (e.ColumnIndex < 0)) { return; }

            int i = 0; string sLoc = "";
            sLoc = Grid1[iCol_Loc, e.RowIndex].Value.ToString();

            if (Grid1[iCol_LocSts, e.RowIndex].Value.ToString() != "S")
            {
                clsMSG.ShowWarningMsg("此FOSB(Lot:" + Grid1[iCol_LotNo, e.RowIndex].Value.ToString() + ") 己經選擇出庫中");
                return;
            }

            if (Grid1.Rows[e.RowIndex].HeaderCell.Value.ToString() == "*")
            {
                for (i = 0; i <= Grid1.RowCount - 1; i++)
                {
                    if (Grid1[iCol_Loc, i].Value.ToString() == sLoc)
                    {
                        clsASRS.SetGridSeletRowColorHead(ref Grid1, i, 2);
                    }
                }
            }
            else
            {
                for (i = 0; i <= Grid1.RowCount - 1; i++)
                {
                    if (Grid1[iCol_Loc, i].Value.ToString() == sLoc)
                    {
                        clsASRS.SetGridSeletRowColorHead(ref Grid1, i, 1);
                    }
                }
            }

            txtLocCnt.Text = FunGetSelLocCnt().ToString();

        }

        private int FunGetSelLocCnt()
        {
            int i = 0; int j = 0 ;int iCnt = 0;

            //讀取要出庫的儲位資料
            string[] aLoc = new string[0];
            //    aLoc(0) = ""
            int idx = 0;
            for (i = 0; i <= Grid1.RowCount - 1; i++)
            {
                if (Grid1.Rows[i].HeaderCell.Value.ToString() == "*")
                {
                    if (idx == 0)
                    {
                        idx = idx + 1;
                        Array.Resize<string>(ref aLoc, idx);
                        aLoc[0] = Grid1[iCol_Loc, i].Value.ToString();
                    }
                    else
                    {
                        bool bIsOverLay = false;
                        for (j = 0; j <= aLoc.Length - 1; j++)
                        {
                            if (aLoc[j] == Grid1[iCol_Loc, i].Value.ToString())
                            {
                                bIsOverLay = true;
                                break;
                            }
                        }
                        if (bIsOverLay == false)
                        {
                            idx = idx + 1;
                            Array.Resize<string>(ref aLoc, idx);
                            aLoc[idx - 1] = Grid1[iCol_Loc, i].Value.ToString();
                        }
                    }                    
                }
            }

            iCnt = aLoc.Length;

            return iCnt;
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            int iRow = 0;

            for (iRow = 0; iRow <= Grid1.RowCount - 1; iRow++)
            {
                if (chkSelectAll.Checked == true)
                {
                    if (Grid1[iCol_LocSts, iRow].Value.ToString() == "S")
                    {
                        clsASRS.SetGridSeletRowColorHead(ref Grid1, iRow, 1);
                    }
                }
                else
                {
                    clsASRS.SetGridSeletRowColorHead(ref Grid1, iRow, 2);
                }
            }

            txtLocCnt.Text = FunGetSelLocCnt().ToString();
        }


        private void cmdStart_Click(object sender, EventArgs e)
        {
            SubExecute();
        }

        private void FunGetStnList(ref string[] aStn)
        {
            int idx = 0;

            if (chkStnA01.Checked == true)
            {
                idx = idx + 1;
                Array.Resize<string>(ref aStn, idx);
                aStn[idx - 1] = "A01";
            }

            if (chkStnA02.Checked == true)
            {
                idx = idx + 1;
                Array.Resize<string>(ref aStn, idx);
                aStn[idx - 1] = "A02";
            }

            if (chkStnA03.Checked == true)
            {
                idx = idx + 1;
                Array.Resize<string>(ref aStn, idx);
                aStn[idx - 1] = "A03";
            }
        }

        private string FunGetStnNoByList(string sStnNo, string[] aStn)
        {
            string sRtnStnNo = "";
            if (aStn.Length <= 0) { return ""; };
            if (sStnNo == "") { sRtnStnNo = aStn[0]; return sRtnStnNo; }  //取第1筆
            if (aStn.Length == 1) { sRtnStnNo = aStn[0]; return sRtnStnNo; }  //取第1筆

            for (int i = 0; i <= aStn.Length - 1; i++)
            {
                if (aStn[i] == sStnNo)
                {
                    if (i >= aStn.Length - 1)
                    {
                        sRtnStnNo = aStn[0];
                    }
                    else
                    {
                        sRtnStnNo = aStn[i + 1];
                    }
                }
            }

            return sRtnStnNo;
        }

        private void SubExecute()
        {
            string sSQL = ""; DbDataReader dbRS = null;
            int i = 0; int j = 0; bool bCmdFlag = false;
            cls_CmdMst aCmdMst = new cls_CmdMst();
            string sLoc1 = ""; string sLocOther = ""; string sLocIDOther = "";

            if (txtCycleNo.Text.Trim() == "")
            {
                clsMSG.ShowWarningMsg("無盤點單號 !!");
                return;
            }

            //判斷站號是否正確
            //if (clsASRS.FunChkStnNo(cboStnNo.Text.Trim()) == false) { return; }
            string[] aStn = new string[0];
            FunGetStnList(ref aStn);
            if (aStn.Length <= 0) { clsMSG.ShowWarningMsg(clsMSG.MSG.Msg_Pls_Input_StnNo); return; }
            string sStnNo = "";


            //讀取要出庫的儲位資料
            string[] aLoc = new string[1]; aLoc[0] = "";
            if (clsASRS.FunGetLocList(ref aLoc,ref Grid1,iCol_Loc) == false) { return; }

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

            #region 讀取命令序號
            string[] sCmdSno = new string[aLoc.Length];
            for (i = 0; i <= aLoc.Length - 1; i++)
            {
                sCmdSno[i] = clsASRS.FunGetCmdSno();
                if (sCmdSno[i] == "")
                {
                    clsMSG.ShowErrMsg("系統錯誤,無命令序號可使用!!");
                    clsDB.FunClsDB(); return;
                }
            }
            #endregion


            for (i = 0; i <= aLoc.Length - 1; i++)
            {

                if (aLoc[i] != "")
                {

                    #region 1. 複製 Loc 資訊
                    tmpGrid1.RowCount = 0;
                    tmpGrid2.RowCount = 0;
                    sLoc1 = ""; sLocOther = ""; sLocIDOther = "";
                    if (FunGetLocToTmpGrid(aLoc[i]) == false)
                    {
                        clsMSG.ShowErrMsg("系統錯誤");
                        clsDB.FunClsDB();
                        return;
                    }
                    #endregion

                    #region 2. 取得另一個 Loc (sLocOther/sLocIDOther)
                    string sCrane_Row = "";
                    string sSNO1 = ""; string sSNO2 = "";
                    sSQL = "SELECT LOC1,CRANE_ROW FROM LOC_MST WHERE LOC = '" + aLoc[i] + "' ";
                    if (clsDB.FunRsSql(sSQL, ref dbRS))
                    {
                        while (dbRS.Read())
                        {
                            sLoc1 = dbRS["LOC1"].ToString();
                            sCrane_Row = dbRS["CRANE_ROW"].ToString();
                        }
                        dbRS.Close();
                    }

                    bool bFlagTmp = false;
                    for (j = 0; j <= aLoc.Length - 1; j++)
                    {
                        if (sLoc1 == aLoc[j])
                        {
                            aLoc[j] = "";  //Clear                            
                            bFlagTmp = true;
                            break;
                        }
                    }
                    if (bFlagTmp == true)
                    {
                        sLocOther = sLoc1;
                        sSQL = "SELECT LOCID FROM LOC_MST WHERE LOC = '" + sLocOther + "' ";
                        if (clsDB.FunRsSql(sSQL, ref dbRS))
                        {
                            while (dbRS.Read())
                            {
                                sLocIDOther = dbRS["LOCID"].ToString();
                            }
                            dbRS.Close();
                        }

                        if (FunGetLocToTmpGrid2(sLocOther) == false)
                        {
                            clsMSG.ShowErrMsg("系統錯誤");
                            clsDB.FunClsDB();
                            return;
                        }

                        //判斷左右
                        if ((sCrane_Row == "2") || (sCrane_Row == "3"))
                        {
                            sSNO1 = "1";
                            sSNO2 = "2";
                        }
                        else
                        {
                            sSNO1 = "2";
                            sSNO2 = "1";
                        }
                    }
                    else
                    {
                        sSNO1 = "1";
                        sSNO2 = "";
                    }
                    #endregion

                    sStnNo = FunGetStnNoByList(sStnNo, aStn);

                    #region BEGIN
                    bCmdFlag = true;
                    clsDB.FunCommitCtrl("BEGIN");
                    #endregion

                    #region 4. 預約儲位
                    if (bCmdFlag == true)
                    {
                        sSQL = "UPDATE LOC_MST SET LOCSTS = 'C' WHERE LOC = '" + aLoc[i] + "' AND LOCSTS = 'S' ";
                        if (clsDB.FunExecSql(sSQL) == false)
                        {
                            bCmdFlag = false;
                        }
                    }
                    if (bCmdFlag == true)
                    {
                        if (sLocOther != "")
                        {
                            sSQL = "UPDATE LOC_MST SET LOCSTS = 'C' WHERE LOC = '" + sLocOther + "' AND LOCSTS = 'S' ";
                            if (clsDB.FunExecSql(sSQL) == false)
                            {
                                bCmdFlag = false;
                            }
                        }
                    }
                    #endregion

                    #region 5. 產生命令主檔
                    if (bCmdFlag == true)
                    {
                        aCmdMst.FunCmdMstClear();   //Clear()
                        aCmdMst.CMDSNO = sCmdSno[i];
                        aCmdMst.SNO1 = sSNO1;       // "1";                        
                        aCmdMst.LOC1 = aLoc[i];
                        aCmdMst.LOCID1 = tmpGrid1[iCol_LocID, 0].Value.ToString();   //LOCID
                        aCmdMst.SCAN1 = "N";
                        if (sLocOther == "")
                        {
                            aCmdMst.SNO2 = "";
                            aCmdMst.CMDMODE = clsASRS.gsCmdMode_Out;   //2
                        }
                        else
                        {
                            aCmdMst.SNO2 = sSNO2;
                            aCmdMst.LOC2 = sLocOther;
                            aCmdMst.LOCID2 = sLocIDOther;
                            aCmdMst.CMDMODE = clsASRS.gsCmdMode_Pack;   //3
                            aCmdMst.SCAN2 = "N";
                        }
                        aCmdMst.CMDSTS = "0";
                        aCmdMst.PRT = "5";
                        aCmdMst.STNNO = sStnNo; // cboStnNo.Text;
                        aCmdMst.IOTYP = clsASRS.gsIOTYPE_Cycle_Loc;
                        aCmdMst.AVAIL = tmpGrid1[iCol_AVAIL, 0].Value.ToString();   // "100";  // 彰化廠
                        aCmdMst.MIXQTY = tmpGrid1[iCol_MIXQTY, 0].Value.ToString();  //"1";   // 彰化廠
                        aCmdMst.NEWLOC = "";
                        aCmdMst.PROGID = clsASRS.gsIOTYPE_Cycle_Loc_PID;
                        aCmdMst.USERID = clsASRS.gstrLoginUser;
                        aCmdMst.TRACE = "0";
                        aCmdMst.STORAGETYP = "";
                        if (aCmdMst.FunInsCmdMst() == false)
                        {
                            bCmdFlag = false;
                        }
                    }
                    #endregion

                    #region 6. 產生命令明細檔
                    if (bCmdFlag == true)
                    {
                        if (SubGetCmdDtl(ref tmpGrid1, sCmdSno[i], aCmdMst.SNO1) == false)
                        {
                            bCmdFlag = false;
                        }

                        if ((bCmdFlag == true) && (sLocOther != ""))
                        {
                            if (SubGetCmdDtl(ref tmpGrid2, sCmdSno[i], aCmdMst.SNO2) == false)
                            {
                                bCmdFlag = false;
                            }
                        }
                    }
                    #endregion

                    #region 7. 產生盤點檔
                    if (bCmdFlag == true)
                    {
                        if (SubGetCycle(ref tmpGrid1, sCmdSno[i], aCmdMst.SNO1) == false)
                        {
                            bCmdFlag = false;
                        }

                        if ((bCmdFlag == true) && (sLocOther != ""))
                        {
                            if (SubGetCycle(ref tmpGrid2, sCmdSno[i], aCmdMst.SNO2) == false)
                            {
                                bCmdFlag = false;
                            }
                        }
                    }
                    #endregion

                    #region COMMIT/ROLLBACK
                    if (bCmdFlag == true)
                    {
                        clsDB.FunCommitCtrl("COMMIT");
                    }
                    else
                    {
                        clsDB.FunCommitCtrl("ROLLBACK");
                        clsDB.FunClsDB();
                        clsMSG.ShowErrMsg(clsMSG.MSG.Msg_Run_Error);
                        return;
                    }
                    #endregion

                }
            }
            
            SubClear();
            txtCycleNo.Text = clsASRS.FunGetCycleSno(); //取得盤點單號

            clsDB.FunClsDB();
        }

        private bool FunGetLocToTmpGrid(string sGetLoc)
        {
            string sSQL = ""; DbDataReader dbRS = null;

            tmpGrid1.RowCount = 0;

            #region Get Data
            sSQL = "SELECT M.LOCID,M.LOCSTS,M.MIXQTY,M.AVAIL,M.STORAGETYP,D.* FROM LOC_MST M, LOC_DTL D WHERE M.LOC = D.LOC AND M.LOC = '" + sGetLoc + "' ";
            if (clsDB.FunRsSql(sSQL, ref dbRS))
            {
                while (dbRS.Read())
                {
                    tmpGrid1.Rows.Add();
                    tmpGrid1.Rows[tmpGrid1.RowCount - 1].HeaderCell.Value = "";
                    tmpGrid1[iCol_Loc, tmpGrid1.RowCount - 1].Value = dbRS["LOC"].ToString();
                    tmpGrid1[iCol_LocSts, tmpGrid1.RowCount - 1].Value = dbRS["LOCSTS"].ToString();
                    tmpGrid1[iCol_LocID, tmpGrid1.RowCount - 1].Value = dbRS["LOCID"].ToString();
                    tmpGrid1[iCol_SubLoc, tmpGrid1.RowCount - 1].Value = "";// dbRS["SUBLOC"].ToString();

                    tmpGrid1[iCol_ITEM, tmpGrid1.RowCount - 1].Value = dbRS["ITEMNO"].ToString();
                    tmpGrid1[iCol_Cust, tmpGrid1.RowCount - 1].Value = dbRS["CUSTOMER"].ToString();
                    tmpGrid1[iCol_Dev, tmpGrid1.RowCount - 1].Value = dbRS["DEVICE"].ToString();
                    tmpGrid1[iCol_LotNo, tmpGrid1.RowCount - 1].Value = dbRS["LOTNO"].ToString();
                    tmpGrid1[iCol_Store, tmpGrid1.RowCount - 1].Value = dbRS["STORE"].ToString();
                    tmpGrid1[iCol_OffQty, tmpGrid1.RowCount - 1].Value = dbRS["OFFQTY"].ToString();
                    tmpGrid1[iCol_WaferQty, tmpGrid1.RowCount - 1].Value = dbRS["WAFERQTY"].ToString();
                    tmpGrid1[iCol_ShipQty, tmpGrid1.RowCount - 1].Value = dbRS["SHIPQTY"].ToString();
                    tmpGrid1[iCol_ChkIQC, tmpGrid1.RowCount - 1].Value = dbRS["CHKIQC"].ToString();
                    tmpGrid1[iCol_ONDATA, tmpGrid1.RowCount - 1].Value = dbRS["ONDATA"].ToString();

                    tmpGrid1[iCol_FOSBID, tmpGrid1.RowCount - 1].Value = dbRS["FOSBID"].ToString();
                    tmpGrid1[iCol_IQCID, tmpGrid1.RowCount - 1].Value = dbRS["IQC_ID"].ToString();
                    tmpGrid1[iCol_ACCID, tmpGrid1.RowCount - 1].Value = dbRS["ACC_ID"].ToString();
                    tmpGrid1[iCol_InDate, tmpGrid1.RowCount - 1].Value = dbRS["INDATE"].ToString();
                    tmpGrid1[iCol_TrnDate, tmpGrid1.RowCount - 1].Value = dbRS["TRNDATE"].ToString();
                    tmpGrid1[iCol_REMARK, tmpGrid1.RowCount - 1].Value = dbRS["REMARK"].ToString();
                    tmpGrid1[iCol_TRANSACTION_DATE, tmpGrid1.RowCount - 1].Value = dbRS["TRANSACTION_DATE"].ToString();
                    tmpGrid1[iCol_GIB_CUSTOMER, tmpGrid1.RowCount - 1].Value = dbRS["GIB_CUSTOMER"].ToString();
                    tmpGrid1[iCol_FAB_LOT_NO, tmpGrid1.RowCount - 1].Value = dbRS["FAB_LOT_NO"].ToString();
                    tmpGrid1[iCol_FAB_TYPE, tmpGrid1.RowCount - 1].Value = dbRS["FAB_TYPE"].ToString();
                    tmpGrid1[iCol_TYPENO, tmpGrid1.RowCount - 1].Value = dbRS["TYPENO"].ToString();
                    tmpGrid1[iCol_LOT_TYPE, tmpGrid1.RowCount - 1].Value = dbRS["LOT_TYPE"].ToString();
                    tmpGrid1[iCol_WAFER_SIZE, tmpGrid1.RowCount - 1].Value = dbRS["WAFER_SIZE"].ToString();
                    tmpGrid1[iCol_YIELD, tmpGrid1.RowCount - 1].Value = dbRS["YIELD"].ToString();
                    tmpGrid1[iCol_APP_NO, tmpGrid1.RowCount - 1].Value = dbRS["APP_NO"].ToString();
                    tmpGrid1[iCol_REL_DATE, tmpGrid1.RowCount - 1].Value = dbRS["REL_DATE"].ToString();
                    tmpGrid1[iCol_REASON_NAME, tmpGrid1.RowCount - 1].Value = dbRS["REASON_NAME"].ToString();
                    tmpGrid1[iCol_TRANSACTION_REFERENCE, tmpGrid1.RowCount - 1].Value = dbRS["TRANSACTION_REFERENCE"].ToString();
                    tmpGrid1[iCol_TRANSACTION_SOURCE_ID, tmpGrid1.RowCount - 1].Value = dbRS["TRANSACTION_SOURCE_ID"].ToString();
                    tmpGrid1[iCol_TRANSACTION_TYPE_ID, tmpGrid1.RowCount - 1].Value = dbRS["TRANSACTION_TYPE_ID"].ToString();
                    tmpGrid1[iCol_FROM_ORG, tmpGrid1.RowCount - 1].Value = dbRS["FROM_ORG"].ToString();
                    tmpGrid1[iCol_TO_ORG, tmpGrid1.RowCount - 1].Value = dbRS["TO_ORG"].ToString();
                    tmpGrid1[iCol_FROM_BANK, tmpGrid1.RowCount - 1].Value = dbRS["FROM_BANK"].ToString();
                    tmpGrid1[iCol_TO_BANK, tmpGrid1.RowCount - 1].Value = dbRS["TO_BANK"].ToString();
                    tmpGrid1[iCol_DOCID, tmpGrid1.RowCount - 1].Value = dbRS["DOCID"].ToString();

                    tmpGrid1[iCol_MIXQTY, tmpGrid1.RowCount - 1].Value = dbRS["MIXQTY"].ToString();
                    tmpGrid1[iCol_AVAIL, tmpGrid1.RowCount - 1].Value = dbRS["AVAIL"].ToString();
                }
                dbRS.Close();
            }
            #endregion

            if (tmpGrid1.RowCount == 0) { return false; }

            return true;
        }

        private bool FunGetLocToTmpGrid2(string sGetLoc)
        {
            string sSQL = ""; DbDataReader dbRS = null;

            tmpGrid2.RowCount = 0;

            #region Get Data
            sSQL = "SELECT M.LOCID,M.LOCSTS,M.STORAGETYP,M.MIXQTY,M.AVAIL,D.* FROM LOC_MST M, LOC_DTL D WHERE M.LOC = D.LOC AND M.LOC = '" + sGetLoc + "' ";
            if (clsDB.FunRsSql(sSQL, ref dbRS))
            {
                while (dbRS.Read())
                {
                    tmpGrid2.Rows.Add();
                    tmpGrid2.Rows[tmpGrid2.RowCount - 1].HeaderCell.Value = "";
                    tmpGrid2[iCol_Loc, tmpGrid2.RowCount - 1].Value = dbRS["LOC"].ToString();
                    tmpGrid2[iCol_LocSts, tmpGrid2.RowCount - 1].Value = dbRS["LOCSTS"].ToString();
                    tmpGrid2[iCol_LocID, tmpGrid2.RowCount - 1].Value = dbRS["LOCID"].ToString();
                    tmpGrid2[iCol_SubLoc, tmpGrid2.RowCount - 1].Value = "";// dbRS["SUBLOC"].ToString();

                    tmpGrid2[iCol_ITEM, tmpGrid2.RowCount - 1].Value = dbRS["ITEMNO"].ToString();
                    tmpGrid2[iCol_Cust, tmpGrid2.RowCount - 1].Value = dbRS["CUSTOMER"].ToString();
                    tmpGrid2[iCol_Dev, tmpGrid2.RowCount - 1].Value = dbRS["DEVICE"].ToString();
                    tmpGrid2[iCol_LotNo, tmpGrid2.RowCount - 1].Value = dbRS["LOTNO"].ToString();
                    tmpGrid2[iCol_Store, tmpGrid2.RowCount - 1].Value = dbRS["STORE"].ToString();
                    tmpGrid2[iCol_OffQty, tmpGrid2.RowCount - 1].Value = dbRS["OFFQTY"].ToString();
                    tmpGrid2[iCol_WaferQty, tmpGrid2.RowCount - 1].Value = dbRS["WAFERQTY"].ToString();
                    tmpGrid2[iCol_ShipQty, tmpGrid2.RowCount - 1].Value = dbRS["SHIPQTY"].ToString();
                    tmpGrid2[iCol_ChkIQC, tmpGrid2.RowCount - 1].Value = dbRS["CHKIQC"].ToString();
                    tmpGrid2[iCol_ONDATA, tmpGrid2.RowCount - 1].Value = dbRS["ONDATA"].ToString();

                    tmpGrid2[iCol_FOSBID, tmpGrid2.RowCount - 1].Value = dbRS["FOSBID"].ToString();
                    tmpGrid2[iCol_IQCID, tmpGrid2.RowCount - 1].Value = dbRS["IQC_ID"].ToString();
                    tmpGrid2[iCol_ACCID, tmpGrid2.RowCount - 1].Value = dbRS["ACC_ID"].ToString();
                    tmpGrid2[iCol_InDate, tmpGrid2.RowCount - 1].Value = dbRS["INDATE"].ToString();
                    tmpGrid2[iCol_TrnDate, tmpGrid2.RowCount - 1].Value = dbRS["TRNDATE"].ToString();
                    tmpGrid2[iCol_REMARK, tmpGrid2.RowCount - 1].Value = dbRS["REMARK"].ToString();
                    tmpGrid2[iCol_TRANSACTION_DATE, tmpGrid2.RowCount - 1].Value = dbRS["TRANSACTION_DATE"].ToString();
                    tmpGrid2[iCol_GIB_CUSTOMER, tmpGrid2.RowCount - 1].Value = dbRS["GIB_CUSTOMER"].ToString();
                    tmpGrid2[iCol_FAB_LOT_NO, tmpGrid2.RowCount - 1].Value = dbRS["FAB_LOT_NO"].ToString();
                    tmpGrid2[iCol_FAB_TYPE, tmpGrid2.RowCount - 1].Value = dbRS["FAB_TYPE"].ToString();
                    tmpGrid2[iCol_TYPENO, tmpGrid2.RowCount - 1].Value = dbRS["TYPENO"].ToString();
                    tmpGrid2[iCol_LOT_TYPE, tmpGrid2.RowCount - 1].Value = dbRS["LOT_TYPE"].ToString();
                    tmpGrid2[iCol_WAFER_SIZE, tmpGrid2.RowCount - 1].Value = dbRS["WAFER_SIZE"].ToString();
                    tmpGrid2[iCol_YIELD, tmpGrid2.RowCount - 1].Value = dbRS["YIELD"].ToString();
                    tmpGrid2[iCol_APP_NO, tmpGrid2.RowCount - 1].Value = dbRS["APP_NO"].ToString();
                    tmpGrid2[iCol_REL_DATE, tmpGrid2.RowCount - 1].Value = dbRS["REL_DATE"].ToString();
                    tmpGrid2[iCol_REASON_NAME, tmpGrid2.RowCount - 1].Value = dbRS["REASON_NAME"].ToString();
                    tmpGrid2[iCol_TRANSACTION_REFERENCE, tmpGrid2.RowCount - 1].Value = dbRS["TRANSACTION_REFERENCE"].ToString();
                    tmpGrid2[iCol_TRANSACTION_SOURCE_ID, tmpGrid2.RowCount - 1].Value = dbRS["TRANSACTION_SOURCE_ID"].ToString();
                    tmpGrid2[iCol_TRANSACTION_TYPE_ID, tmpGrid2.RowCount - 1].Value = dbRS["TRANSACTION_TYPE_ID"].ToString();
                    tmpGrid2[iCol_FROM_ORG, tmpGrid2.RowCount - 1].Value = dbRS["FROM_ORG"].ToString();
                    tmpGrid2[iCol_TO_ORG, tmpGrid2.RowCount - 1].Value = dbRS["TO_ORG"].ToString();
                    tmpGrid2[iCol_FROM_BANK, tmpGrid2.RowCount - 1].Value = dbRS["FROM_BANK"].ToString();
                    tmpGrid2[iCol_TO_BANK, tmpGrid2.RowCount - 1].Value = dbRS["TO_BANK"].ToString();
                    tmpGrid2[iCol_DOCID, tmpGrid2.RowCount - 1].Value = dbRS["DOCID"].ToString();

                    tmpGrid2[iCol_MIXQTY, tmpGrid2.RowCount - 1].Value = dbRS["MIXQTY"].ToString();
                    tmpGrid2[iCol_AVAIL, tmpGrid2.RowCount - 1].Value = dbRS["AVAIL"].ToString();

                }
                dbRS.Close();
            }
            #endregion

            if (tmpGrid2.RowCount == 0) { return false; }

            return true;
        }

        private bool SubGetCmdDtl(ref DataGridView objGridTmp, string sCmdSno, string sSno)
        {
            int j = 0;
            cls_CmdDtl aCmdDtl = new cls_CmdDtl();

            for (j = 0; j <= objGridTmp.RowCount - 1; j++)
            {
                #region Get出庫明細 objGridTmp Data
                aCmdDtl.CMDSNO = sCmdSno;
                aCmdDtl.SNO = sSno;
                //aCmdDtl.LOC = objGridTmp[iCol_Loc, 0].Value.ToString();
                aCmdDtl.LOCID = objGridTmp[iCol_LocID, 0].Value.ToString();
                aCmdDtl.SUBLOC = ""; //No Use
                aCmdDtl.ITEMNO = objGridTmp[iCol_ITEM, j].Value.ToString();
                aCmdDtl.CUSTOMER = objGridTmp[iCol_Cust, j].Value.ToString();
                aCmdDtl.DEVICE = objGridTmp[iCol_Dev, j].Value.ToString();
                aCmdDtl.LOTNO = objGridTmp[iCol_LotNo, j].Value.ToString();
                aCmdDtl.STORE = objGridTmp[iCol_Store, j].Value.ToString();
                aCmdDtl.OFFQTY = clsTool.INT(objGridTmp[iCol_OffQty, j].Value.ToString());
                aCmdDtl.WAFERQTY = clsTool.INT(objGridTmp[iCol_WaferQty, j].Value.ToString());
                aCmdDtl.SHIPQTY = clsTool.INT(objGridTmp[iCol_ShipQty, j].Value.ToString());

                aCmdDtl.OFFACTQTY = 0;
                aCmdDtl.WAFERACTQTY = 0;
                aCmdDtl.SHIPACTQTY = 0;

                //if (tmpGrid1.Rows[j].HeaderCell.Value.ToString() == "*")
                //{
                aCmdDtl.FLAGQTY = clsASRS.gsFlagQty_OUT;    
                //}
                //else
                //{
                //    aCmdDtl.FLAGQTY = clsASRS.gsFlagQty_Limit;
                //}

                aCmdDtl.CHKIQC = objGridTmp[iCol_ChkIQC, j].Value.ToString();
                aCmdDtl.FOSBID = objGridTmp[iCol_FOSBID, j].Value.ToString();
                aCmdDtl.IQC_ID = objGridTmp[iCol_IQCID, j].Value.ToString();
                aCmdDtl.ACC_ID = objGridTmp[iCol_ACCID, j].Value.ToString();
                aCmdDtl.INDATE = objGridTmp[iCol_InDate, j].Value.ToString();
                aCmdDtl.REMARK = objGridTmp[iCol_REMARK, j].Value.ToString();
                aCmdDtl.TRANSACTION_DATE = objGridTmp[iCol_TRANSACTION_DATE, j].Value.ToString();
                aCmdDtl.GIB_CUSTOMER = objGridTmp[iCol_GIB_CUSTOMER, j].Value.ToString();
                aCmdDtl.FAB_LOT_NO = objGridTmp[iCol_FAB_LOT_NO, j].Value.ToString();
                aCmdDtl.FAB_TYPE = objGridTmp[iCol_FAB_TYPE, j].Value.ToString();
                aCmdDtl.TYPENO = objGridTmp[iCol_TYPENO, j].Value.ToString();
                aCmdDtl.LOT_TYPE = objGridTmp[iCol_LOT_TYPE, j].Value.ToString();
                aCmdDtl.WAFER_SIZE = objGridTmp[iCol_WAFER_SIZE, j].Value.ToString();
                aCmdDtl.YIELD = objGridTmp[iCol_YIELD, j].Value.ToString();
                aCmdDtl.APP_NO = objGridTmp[iCol_APP_NO, j].Value.ToString();
                aCmdDtl.REL_DATE = objGridTmp[iCol_REL_DATE, j].Value.ToString();
                aCmdDtl.REASON_NAME = objGridTmp[iCol_REASON_NAME, j].Value.ToString();
                aCmdDtl.TRANSACTION_REFERENCE = objGridTmp[iCol_TRANSACTION_REFERENCE, j].Value.ToString();
                aCmdDtl.TRANSACTION_SOURCE_ID = objGridTmp[iCol_TRANSACTION_SOURCE_ID, j].Value.ToString();
                aCmdDtl.TRANSACTION_TYPE_ID = objGridTmp[iCol_TRANSACTION_TYPE_ID, j].Value.ToString();
                aCmdDtl.FROM_ORG = objGridTmp[iCol_FROM_ORG, j].Value.ToString();
                aCmdDtl.TO_ORG = objGridTmp[iCol_TO_ORG, j].Value.ToString();
                aCmdDtl.FROM_BANK = objGridTmp[iCol_FROM_BANK, j].Value.ToString();
                aCmdDtl.TO_BANK = objGridTmp[iCol_TO_BANK, j].Value.ToString();
                aCmdDtl.CYCLENO = txtCycleNo.Text;  //盤點單號
                aCmdDtl.COID = "";      
                aCmdDtl.DOCID = objGridTmp[iCol_DOCID, j].Value.ToString();        
                aCmdDtl.DOCID2 = "";    
                #endregion

                if (aCmdDtl.FunInsCmdDtl() == false)
                {
                    return false;
                }
            }
                        
            return true;
        }

        private bool SubGetCycle(ref DataGridView objGridTmp, string sCmdSno, string sSno)
        {
            int j = 0;
            cls_Cycle aCycle = new cls_Cycle();

            for (j = 0; j <= objGridTmp.RowCount - 1; j++)
            {
                #region Get出庫明細 objGridTmp Data
                aCycle.CYCLENO = txtCycleNo.Text;  //盤點單號
                aCycle.LOC = objGridTmp[iCol_Loc, j].Value.ToString();
                aCycle.LOCID = objGridTmp[iCol_LocID, 0].Value.ToString();
                aCycle.ITEMNO = objGridTmp[iCol_ITEM, j].Value.ToString();
                aCycle.CUSTOMER = objGridTmp[iCol_Cust, j].Value.ToString();
                aCycle.DEVICE = objGridTmp[iCol_Dev, j].Value.ToString();
                aCycle.LOTNO = objGridTmp[iCol_LotNo, j].Value.ToString();
                aCycle.STORE = objGridTmp[iCol_Store, j].Value.ToString();
                aCycle.OFFQTY = clsTool.INT(objGridTmp[iCol_OffQty, j].Value.ToString());
                aCycle.WAFERQTY = clsTool.INT(objGridTmp[iCol_WaferQty, j].Value.ToString());
                aCycle.SHIPQTY = clsTool.INT(objGridTmp[iCol_ShipQty, j].Value.ToString());

                aCycle.CYCOFFQTY = 0;
                aCycle.CYCWAFERQTY = 0;
                aCycle.CYCSHIPQTY = 0;                

                aCycle.CHKIQC = objGridTmp[iCol_ChkIQC, j].Value.ToString();
                aCycle.FOSBID = objGridTmp[iCol_FOSBID, j].Value.ToString();
                aCycle.IQC_ID = objGridTmp[iCol_IQCID, j].Value.ToString();
                aCycle.ACC_ID = objGridTmp[iCol_ACCID, j].Value.ToString();
                aCycle.INDATE = objGridTmp[iCol_InDate, j].Value.ToString();
                aCycle.REMARK = objGridTmp[iCol_REMARK, j].Value.ToString();
                aCycle.TRANSACTION_DATE = objGridTmp[iCol_TRANSACTION_DATE, j].Value.ToString();
                aCycle.GIB_CUSTOMER = objGridTmp[iCol_GIB_CUSTOMER, j].Value.ToString();
                aCycle.FAB_LOT_NO = objGridTmp[iCol_FAB_LOT_NO, j].Value.ToString();
                aCycle.FAB_TYPE = objGridTmp[iCol_FAB_TYPE, j].Value.ToString();
                aCycle.TYPENO = objGridTmp[iCol_TYPENO, j].Value.ToString();
                aCycle.LOT_TYPE = objGridTmp[iCol_LOT_TYPE, j].Value.ToString();
                aCycle.WAFER_SIZE = objGridTmp[iCol_WAFER_SIZE, j].Value.ToString();
                aCycle.YIELD = objGridTmp[iCol_YIELD, j].Value.ToString();
                aCycle.APP_NO = objGridTmp[iCol_APP_NO, j].Value.ToString();
                aCycle.REL_DATE = objGridTmp[iCol_REL_DATE, j].Value.ToString();
                aCycle.REASON_NAME = objGridTmp[iCol_REASON_NAME, j].Value.ToString();
                aCycle.TRANSACTION_REFERENCE = objGridTmp[iCol_TRANSACTION_REFERENCE, j].Value.ToString();
                aCycle.TRANSACTION_SOURCE_ID = objGridTmp[iCol_TRANSACTION_SOURCE_ID, j].Value.ToString();
                aCycle.TRANSACTION_TYPE_ID = objGridTmp[iCol_TRANSACTION_TYPE_ID, j].Value.ToString();
                aCycle.FROM_ORG = objGridTmp[iCol_FROM_ORG, j].Value.ToString();
                aCycle.TO_ORG = objGridTmp[iCol_TO_ORG, j].Value.ToString();
                aCycle.FROM_BANK = objGridTmp[iCol_FROM_BANK, j].Value.ToString();
                aCycle.TO_BANK = objGridTmp[iCol_TO_BANK, j].Value.ToString();
                                
                aCycle.DOCID = objGridTmp[iCol_DOCID, j].Value.ToString();
                aCycle.DOCID2 = "";
                aCycle.USER_CREAT = clsASRS.gstrLoginUser;
                #endregion

                if (aCycle.FunInsCycle() == false)
                {
                    return false;
                }
            }

            return true;
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            frm_CYCLE_CHECK frm_CYCLE_CHECK = new frm_CYCLE_CHECK();
            frm_CYCLE_CHECK.MdiParent = this.MdiParent;

            ////MdiParent
            frm_CYCLE_CHECK.Show();
            frm_CYCLE_CHECK.Focus();
        }

        private void cmdExport_Click(object sender, EventArgs e)
        {
            clsTool.funGridToCsv(Grid1);
        }




        //private bool FunCopyToTmpGrid(string sLoc)
        //{
        //    int iCol = 0; int iRow = 0;

        //    tmpGrid1.RowCount = 0;
        //    tmpGrid1.ColumnCount = Grid1.ColumnCount;

        //    for (iRow = 0; iRow <= Grid1.RowCount - 1; iRow++)
        //    {
        //        if (Grid1[iCol_Loc, iRow].Value.ToString() == sLoc)
        //        {
        //            tmpGrid1.Rows.Add();

        //            if (Grid1.Rows[iRow].HeaderCell.Value.ToString() == "*")
        //            {
        //                tmpGrid1.Rows[tmpGrid1.RowCount - 1].HeaderCell.Value = "*";
        //            }
        //            else
        //            {
        //                tmpGrid1.Rows[tmpGrid1.RowCount - 1].HeaderCell.Value = "";
        //            }
        //            for (iCol = 0; iCol <= tmpGrid1.ColumnCount - 1; iCol++)
        //            {
        //                tmpGrid1[iCol, tmpGrid1.RowCount - 1].Value = Grid1[iCol, iRow].Value.ToString();
        //            }
        //        }             
        //    }

        //    if (tmpGrid1.RowCount <= 0)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

    }
}
