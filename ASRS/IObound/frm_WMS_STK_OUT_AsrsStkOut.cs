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
    public partial class frm_WMS_STK_OUT_AsrsStkOut : Form
    {
        #region Grid Parameter
        int iCol_DOCTYP = 0;        //原因別
        int iCol_DOCID = 1;         //單號
        int iCol_FOSBID = 2;        //收料序號
        int iCol_WMSLOC = 3;        //WMS儲位
        int iCol_ITEM = 4;
        int iCol_LotNo = 5;
        int iCol_WaferQty = 6;      //枚數
        int iCol_ShipQty = 7;       //數量
        int iCol_CreationDate = 8;

        int iCol_LocMark = 9;       //儲位備註

        int iCol_Loc = 10;          //儲位
        int iCol_LocSts = 11;       //儲位狀態
        int iCol_LocID = 12;        //料盤ID
        int iCol_SubLoc = 13;       //L/R
        int iCol_Cust = 14;         //客戶簡稱 
        int iCol_Dev = 15;          //DEVICE
        int iCol_ChkIQC = 16;       //檢驗
        int iCol_InDate = 17;       //入庫日期
        int iCol_TrnDate = 18;      //異動日期
        int iCol_REMARK = 19;       //備註
        int iCol_TRANSACTION_DATE = 20;         //收料日期
        int iCol_GIB_CUSTOMER = 21;             //來貨廠商
        int iCol_FAB_LOT_NO = 22;               //Fab lot
        int iCol_FAB_TYPE = 23;                 //晶圓廠別
        int iCol_TYPENO = 24;                   //Mask
        int iCol_LOT_TYPE = 25;                 //Lot Type
        int iCol_WAFER_SIZE = 26;               //Size
        int iCol_YIELD = 27;                    //良率
        int iCol_APP_NO = 28;                   //報單號碼
        int iCol_REL_DATE = 29;                 //報單日期
        int iCol_REASON_NAME = 30;              //Reason Code
        int iCol_TRANSACTION_REFERENCE = 31;    //Reference
        int iCol_TRANSACTION_SOURCE_ID = 32;    //Source ID
        int iCol_TRANSACTION_TYPE_ID = 33;      //Transaction Type
        int iCol_FROM_ORG = 34;                 //From Org ID
        int iCol_TO_ORG = 35;                   //To Org ID
        int iCol_FROM_BANK = 36;                //From Bank
        int iCol_TO_BANK = 37;                  //To Bank

        int iCol_Store = 38;
        int iCol_OffQty = 39;
        int iCol_IQCID = 40;
        int iCol_ACCID = 41;

        int iCol_SEQ_NO = 42;   //For WMS
        int iCol_COID = 43;     //For WMS
        int iCol_DOCID2 = 44;   //For WMS
        int iCol_StorageTyp = 45;
        int iCol_Counts = 46;
        #endregion

        #region WMS Type Parameter
        string gsType1 = "退客貨下架";
        string gsType2 = "發料下架";
        string gsType3 = "一般調撥";
        string gsType4 = "報廢移倉下架";
        string gsType5 = "手動下架";
        string gsType6 = "更換標籤";
        string gsType7 = "送IQC清單";

        #endregion


        string iCol_DocTyp_Update = "更換標籤";

        public frm_WMS_STK_OUT_AsrsStkOut()
        {
            InitializeComponent();
        }

        private void frm_WMS_STK_OUT_AsrsStkOut_Load(object sender, EventArgs e)
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

            oGrid.Columns[iCol_DOCTYP].Width = 90; oGrid.Columns[iCol_DOCTYP].Name = "資料類別";
            oGrid.Columns[iCol_DOCID].Width = 90; oGrid.Columns[iCol_DOCID].Name = "單號";
            oGrid.Columns[iCol_FOSBID].Width = 110; oGrid.Columns[iCol_FOSBID].Name = "收料序號";
            oGrid.Columns[iCol_WMSLOC].Width = 100; oGrid.Columns[iCol_WMSLOC].Name = "WMS儲位";
            oGrid.Columns[iCol_ITEM].Width = 90; oGrid.Columns[iCol_ITEM].Name = "ITEM";
            oGrid.Columns[iCol_LotNo].Width = 90; oGrid.Columns[iCol_LotNo].Name = "Lot No";
            oGrid.Columns[iCol_WaferQty].Width = 45; oGrid.Columns[iCol_WaferQty].Name = "枚數";
            oGrid.Columns[iCol_ShipQty].Width = 45; oGrid.Columns[iCol_ShipQty].Name = "數量";
            oGrid.Columns[iCol_CreationDate].Width = 110; oGrid.Columns[iCol_CreationDate].Name = "Creation Date";
            oGrid.Columns[iCol_LocMark].Width = 130; oGrid.Columns[iCol_LocMark].Name = "儲位備註";


            oGrid.Columns[iCol_Loc].Width = 50; oGrid.Columns[iCol_Loc].Name = "儲位";
            oGrid.Columns[iCol_LocSts].Width = 100; oGrid.Columns[iCol_LocSts].Name = "儲位狀態";
            oGrid.Columns[iCol_LocID].Width = 40; oGrid.Columns[iCol_LocID].Name = "料盤ID"; oGrid.Columns[iCol_LocID].Visible = false;
            oGrid.Columns[iCol_SubLoc].Width = 40; oGrid.Columns[iCol_SubLoc].Name = "L/R"; oGrid.Columns[iCol_SubLoc].Visible = false;
            oGrid.Columns[iCol_Cust].Width = 80; oGrid.Columns[iCol_Cust].Name = "客戶簡稱"; oGrid.Columns[iCol_Cust].Visible = false;
            oGrid.Columns[iCol_Dev].Width = 80; oGrid.Columns[iCol_Dev].Name = "DEVICE"; oGrid.Columns[iCol_Dev].Visible = false;
            oGrid.Columns[iCol_OffQty].Width = 40; oGrid.Columns[iCol_OffQty].Name = "件數"; oGrid.Columns[iCol_OffQty].Visible = false;
            oGrid.Columns[iCol_ChkIQC].Width = 40; oGrid.Columns[iCol_ChkIQC].Name = "檢驗"; oGrid.Columns[iCol_ChkIQC].Visible = false;
            oGrid.Columns[iCol_InDate].Width = 100; oGrid.Columns[iCol_InDate].Name = "入庫時間"; oGrid.Columns[iCol_InDate].Visible = false;
            oGrid.Columns[iCol_TrnDate].Width = 100; oGrid.Columns[iCol_TrnDate].Name = "異動時間"; oGrid.Columns[iCol_TrnDate].Visible = false;
            oGrid.Columns[iCol_REMARK].Width = 80; oGrid.Columns[iCol_REMARK].Name = "備註"; oGrid.Columns[iCol_REMARK].Visible = false;
            oGrid.Columns[iCol_TRANSACTION_DATE].Width = 100; oGrid.Columns[iCol_TRANSACTION_DATE].Name = "收料日期"; oGrid.Columns[iCol_TRANSACTION_DATE].Visible = false;
            oGrid.Columns[iCol_GIB_CUSTOMER].Width = 40; oGrid.Columns[iCol_GIB_CUSTOMER].Name = "來貨廠商"; oGrid.Columns[iCol_GIB_CUSTOMER].Visible = false;
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

            oGrid.Columns[iCol_Store].Width = 0; oGrid.Columns[iCol_Store].Name = ""; oGrid.Columns[iCol_Store].Visible = false;
            oGrid.Columns[iCol_OffQty].Width = 0; oGrid.Columns[iCol_OffQty].Name = ""; oGrid.Columns[iCol_OffQty].Visible = false;
            oGrid.Columns[iCol_IQCID].Width = 0; oGrid.Columns[iCol_IQCID].Name = ""; oGrid.Columns[iCol_IQCID].Visible = false;
            oGrid.Columns[iCol_ACCID].Width = 0; oGrid.Columns[iCol_ACCID].Name = ""; oGrid.Columns[iCol_ACCID].Visible = false;

            oGrid.Columns[iCol_SEQ_NO].Width = 100; oGrid.Columns[iCol_SEQ_NO].Name = ""; oGrid.Columns[iCol_SEQ_NO].Visible = false; //For WMS
            oGrid.Columns[iCol_COID].Width = 100; oGrid.Columns[iCol_COID].Name = ""; oGrid.Columns[iCol_COID].Visible = false;     //For WMS
            oGrid.Columns[iCol_DOCID2].Width = 100; oGrid.Columns[iCol_DOCID2].Name = "WMS下架單號"; oGrid.Columns[iCol_DOCID2].Visible = false;     //For WMS

            oGrid.Columns[iCol_Store].Visible = false;
            oGrid.Columns[iCol_OffQty].Visible = false;
            oGrid.Columns[iCol_IQCID].Visible = false;
            oGrid.Columns[iCol_ACCID].Visible = false;
            oGrid.Columns[iCol_StorageTyp].Visible = false;

            int i = 0;
            for (i = 0; i <= oGrid.ColumnCount - 1; i++)
            {
                if ((i == iCol_DOCTYP) || (i == iCol_DOCID) || (i == iCol_FOSBID) || (i == iCol_ITEM)
                    || (i == iCol_WMSLOC) || (i == iCol_LotNo))
                {
                    //允許排序
                }
                else
                {
                    oGrid.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
        }

        private void FormInit()
        {
            FormCls();

            clsASRS.SubCboSetStnNo(ref cboStnNo);
            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };
            cboStnNo.Text = clsASRS.FunGetStnNoByAreaNo(clsASRS.gsAreaNo);
            clsDB.FunClsDB();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            SubQuery();
        }

        private void btnCls_Click(object sender, EventArgs e)
        {
            FormCls();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormCls()
        {
            txtDocID.Text = "";
            txtFOSB.Text = "";
            Grid1.RowCount = 0;
        }

        private void SubQuery()
        {
            string sSQL = ""; DbDataReader dbRS = null;
            string sType = ""; string sNotes = "";
            bool bDataOverlay = false; int x = 0;

            txtFOSB.Text = txtFOSB.Text.Trim().ToUpper();
            txtDocID.Text = txtDocID.Text.Trim().ToUpper();

            Grid1.RowCount = 0;

            #region 檢查是否有輸入查詢條件
            if ((chkAll.Checked == false) && (chkSel1.Checked == false) && (chkSel2.Checked == false) && (chkSel7.Checked == false) &&
                (chkSel3.Checked == false) && (chkSel4.Checked == false) && (chkSel5.Checked == false) && (chkSel6.Checked == false))
            {
                if ((txtFOSB.Text == "") && (txtDocID.Text == ""))
                {
                    clsMSG.ShowWarningMsg("請選擇資料類別或查詢條件!!");
                    return;
                }
            }
            #endregion


            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; }

            #region 查詢條件
            sSQL = "SELECT T.SNID,T.TYPE,T.RCVNO,T.DOCTYP,T.DOCID,T.CREATION_DATE,T.COID,A.* FROM TB_ASRS_TO_WMS_TEMP T ";
            sSQL = sSQL + "LEFT JOIN ( ";
            sSQL = sSQL + "SELECT L.*, S.WMS_LOC FROM  ";
            sSQL = sSQL + "(SELECT D.ITEMNO,D.LOTNO,D.WAFERQTY,D.SHIPQTY,D.FOSBID,M.LOC,M.LOCSTS,M.LOCID,M.STORAGETYP ";
            sSQL = sSQL + "FROM LOC_MST M, LOC_DTL D WHERE M.LOC = D.LOC ) L ";
            sSQL = sSQL + "LEFT JOIN SPIL_WMS_LOC S ON L.LOCID = S.ASRS_LOCID ) A ";
            sSQL = sSQL + "ON T.RCVNO = A.FOSBID ";

            if (chkAll.Checked == true)
            {
                sSQL = sSQL + "WHERE ((T.TYPE = 'STOCKOUT') OR (T.TYPE = 'UPDATE_DATA')) ";
            }
            else
            {
                #region 退客貨下架
                if (chkSel1.Checked == true)
                {
                    if (sType == "")
                    {
                        sType = sType + "'" + gsType1 + "'";
                    }
                    else
                    {
                        sType = sType + ",'" + gsType1 + "'";
                    }
                }
                #endregion

                #region 發料下架
                if (chkSel2.Checked == true)
                {
                    if (sType == "")
                    {
                        sType = sType + "'" + gsType2 + "'";
                    }
                    else
                    {
                        sType = sType + ",'" + gsType2 + "'";
                    }
                }
                #endregion

                #region 一般調撥
                if (chkSel3.Checked == true)
                {
                    if (sType == "")
                    {
                        sType = sType + "'" + gsType3 + "'";
                    }
                    else
                    {
                        sType = sType + ",'" + gsType3 + "'";
                    }
                }
                #endregion

                #region 報廢移倉下架
                if (chkSel4.Checked == true)
                {
                    if (sType == "")
                    {
                        sType = sType + "'報廢移倉下架'";
                    }
                    else
                    {
                        sType = sType + ",'報廢移倉下架'";
                    }
                }
                #endregion

                #region 手動下架
                if (chkSel5.Checked == true)
                {
                    if (sType == "")
                    {
                        sType = sType + "'" + gsType5 + "'";
                    }
                    else
                    {
                        sType = sType + ",'" + gsType5 + "'";
                    }
                }
                #endregion

                #region IQC手動下架
                if (chkSel7.Checked == true)
                {
                    if (sType == "")
                    {
                        sType = sType + "'" + gsType7 + "'";
                    }
                    else
                    {
                        sType = sType + ",'" + gsType7 + "'";
                    }
                }
                #endregion

                #region 其它
                if (chkSel6.Checked == true)
                {
                    if (sType == "")
                    {
                        sSQL = sSQL + "WHERE (T.TYPE = 'UPDATE_DATA') ";
                    }
                    else
                    {
                        sSQL = sSQL + "WHERE ((T.TYPE = 'STOCKOUT' AND T.DOCTYP IN (" + sType + " )) OR (T.TYPE = 'UPDATE_DATA')) ";
                    }
                }
                else
                {
                    if (sType == "")
                    {
                        sSQL = sSQL + "WHERE ((T.TYPE = 'STOCKOUT') OR (T.TYPE = 'UPDATE_DATA')) ";
                    }
                    else
                    {
                        sSQL = sSQL + "WHERE (T.TYPE = 'STOCKOUT' AND T.DOCTYP IN (" + sType + " )) ";
                    }
                }
                #endregion
            }

            sSQL = sSQL + "AND T.STATUS = 'A' AND T.SEND_ASRS = 'Y' ";

            if (txtFOSB.Text != "")
            {
                sSQL = sSQL + "AND T.RCVNO = '" + txtFOSB.Text + "' ";
            }
            if (txtDocID.Text != "")
            {
                sSQL = sSQL + "AND T.DOCID = '" + txtDocID.Text + "' ";
            }
            #endregion

            if (clsDB.FunRsSql(sSQL, ref dbRS))
            {
                while (dbRS.Read())
                {
                    #region Check資料是否重覆 bDataOverlay
                    bDataOverlay = false;
                    for (x = 0; x <= Grid1.RowCount - 1; x++)
                    {
                        if ((dbRS["RCVNO"].ToString() == Grid1[iCol_FOSBID, x].Value.ToString()) &&
                            (dbRS["LOTNO"].ToString() == Grid1[iCol_LotNo, x].Value.ToString()) &&
                            (dbRS["DOCID"].ToString() == Grid1[iCol_DOCID, x].Value.ToString()))
                        {
                            bDataOverlay = true;
                            break;
                        }
                    }
                    #endregion

                    #region Get Data
                    if (bDataOverlay == false)
                    {
                        Grid1.Rows.Add();
                        Grid1.Rows[Grid1.Rows.Count - 1].HeaderCell.Value = "";
                        if (dbRS["TYPE"].ToString() == "UPDATE_DATA")
                        {
                            Grid1[iCol_DOCTYP, Grid1.Rows.Count - 1].Value = iCol_DocTyp_Update;  //"更換標籤"
                        }
                        else
                        {
                            Grid1[iCol_DOCTYP, Grid1.Rows.Count - 1].Value = dbRS["DOCTYP"].ToString();
                        }

                        Grid1[iCol_DOCID, Grid1.Rows.Count - 1].Value = dbRS["DOCID"].ToString();

                        Grid1[iCol_FOSBID, Grid1.Rows.Count - 1].Value = dbRS["RCVNO"].ToString();
                        Grid1[iCol_WMSLOC, Grid1.Rows.Count - 1].Value = dbRS["WMS_LOC"].ToString();   //計算WMS儲位
                        Grid1[iCol_ITEM, Grid1.Rows.Count - 1].Value = dbRS["ITEMNO"].ToString();
                        Grid1[iCol_LotNo, Grid1.Rows.Count - 1].Value = dbRS["LOTNO"].ToString();
                        Grid1[iCol_WaferQty, Grid1.Rows.Count - 1].Value = dbRS["WAFERQTY"].ToString();
                        Grid1[iCol_ShipQty, Grid1.Rows.Count - 1].Value = dbRS["SHIPQTY"].ToString();

                        Grid1[iCol_CreationDate, Grid1.Rows.Count - 1].Value = dbRS["CREATION_DATE"].ToString();

                        sNotes = "";

                        if (dbRS["LOC"].ToString() == "")
                        {
                            sNotes = "不在ASRS庫存儲位";
                        }
                        else
                        {
                            if (dbRS["LOCSTS"].ToString() == "S")
                            {
                                sNotes = "可進行出庫作業";
                            }
                            else if (dbRS["LOCSTS"].ToString() == "O")
                            {
                                sNotes = "作業中,不可以重覆執行";
                            }
                            else
                            {
                                sNotes = "該儲位不可進行出庫";
                            }
                        }

                        Grid1[iCol_LocMark, Grid1.Rows.Count - 1].Value = sNotes; //儲位備註

                        Grid1[iCol_Loc, Grid1.Rows.Count - 1].Value = dbRS["LOC"].ToString();
                        Grid1[iCol_LocSts, Grid1.Rows.Count - 1].Value = dbRS["LOCSTS"].ToString();
                        Grid1[iCol_LocID, Grid1.Rows.Count - 1].Value = dbRS["LOCID"].ToString();
                        Grid1[iCol_SubLoc, Grid1.Rows.Count - 1].Value = "";// dbRS["SUBLOC"].ToString();
                        Grid1[iCol_SEQ_NO, Grid1.Rows.Count - 1].Value = dbRS["SNID"].ToString();

                        Grid1[iCol_COID, Grid1.Rows.Count - 1].Value = dbRS["COID"].ToString();
                    }
                    #endregion
                }
                dbRS.Close();
            }

            clsDB.FunClsDB();


            Grid1.Sort(Grid1.Columns[iCol_WMSLOC], System.ComponentModel.ListSortDirection.Ascending);

        }

        #region CheckBox
        private void chkAll_Click(object sender, EventArgs e)
        {
            if (chkAll.Checked == true) { SetObjSel("ALL"); };
        }

        private void chkSel1_Click(object sender, EventArgs e)
        {
            if (chkSel1.Checked == true) { SetObjSel("1"); };
        }

        private void chkSel2_Click(object sender, EventArgs e)
        {
            if (chkSel2.Checked == true) { SetObjSel("2"); };
        }

        private void chkSel3_Click(object sender, EventArgs e)
        {
            if (chkSel3.Checked == true) { SetObjSel("3"); };
        }

        private void chkSel4_Click(object sender, EventArgs e)
        {
            if (chkSel4.Checked == true) { SetObjSel("4"); };
        }

        private void chkSel5_Click(object sender, EventArgs e)
        {
            if (chkSel5.Checked == true) { SetObjSel("5"); };
        }

        private void chkSel6_Click(object sender, EventArgs e)
        {
            if (chkSel6.Checked == true) { SetObjSel("6"); };
        }

        private void chkSel7_Click(object sender, EventArgs e)
        {
            if (chkSel7.Checked == true) { SetObjSel("7"); };
        }

        private void SetObjSel(string sType)
        {
            switch (sType)
            {
                case "ALL":
                    chkSel1.Checked = false;
                    chkSel2.Checked = false;
                    chkSel3.Checked = false;
                    chkSel4.Checked = false;
                    chkSel5.Checked = false;
                    chkSel6.Checked = false;
                    chkSel7.Checked = false;
                    break;
                case "1":
                    chkAll.Checked = false;
                    chkSel2.Checked = false;
                    chkSel3.Checked = false;
                    chkSel4.Checked = false;
                    chkSel5.Checked = false;
                    chkSel6.Checked = false;
                    chkSel7.Checked = false;
                    break;
                case "2":
                    chkAll.Checked = false;
                    chkSel1.Checked = false;
                    chkSel3.Checked = false;
                    chkSel4.Checked = false;
                    chkSel5.Checked = false;
                    chkSel6.Checked = false;
                    chkSel7.Checked = false;
                    break;
                case "3":
                    chkAll.Checked = false;
                    chkSel1.Checked = false;
                    chkSel2.Checked = false;
                    chkSel4.Checked = false;
                    chkSel5.Checked = false;
                    chkSel6.Checked = false;
                    chkSel7.Checked = false;
                    break;
                case "4":
                    chkAll.Checked = false;
                    chkSel1.Checked = false;
                    chkSel2.Checked = false;
                    chkSel3.Checked = false;
                    chkSel5.Checked = false;
                    chkSel6.Checked = false;
                    chkSel7.Checked = false;
                    break;
                case "5":
                    chkAll.Checked = false;
                    chkSel1.Checked = false;
                    chkSel2.Checked = false;
                    chkSel3.Checked = false;
                    chkSel4.Checked = false;
                    chkSel6.Checked = false;
                    chkSel7.Checked = false;
                    break;
                case "6":
                    chkAll.Checked = false;
                    chkSel1.Checked = false;
                    chkSel2.Checked = false;
                    chkSel3.Checked = false;
                    chkSel4.Checked = false;
                    chkSel5.Checked = false;
                    chkSel7.Checked = false;
                    break;
                case "7":
                    chkAll.Checked = false;
                    chkSel1.Checked = false;
                    chkSel2.Checked = false;
                    chkSel3.Checked = false;
                    chkSel4.Checked = false;
                    chkSel5.Checked = false;
                    chkSel6.Checked = false;
                    break;
            }
        }
        #endregion

        private void chkSelAll_CheckedChanged(object sender, EventArgs e)
        {
            int i = 0;
            if (chkSelAll.Checked == true)
            {
                for (i = 0; i <= Grid1.RowCount - 1; i++)
                {
                    if (Grid1[iCol_LocSts, i].Value.ToString() == "S")
                    {
                        clsTool.SetGridSeletRowColorHead(ref Grid1, true, i);
                    }
                }
            }
            else
            {
                for (i = 0; i <= Grid1.RowCount - 1; i++)
                {
                    clsTool.SetGridSeletRowColorHead(ref Grid1, false, i);
                }
            }
        }

        private void Grid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Grid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex <= -1) || (e.ColumnIndex <= -1)) { return; }
            if (Grid1[iCol_Loc, e.RowIndex].Value.ToString() == "") { return; }

            int i = 0; string sLoc = ""; string sLocSts = "";
            string sMsg = "";

            sLoc = Grid1[iCol_Loc, e.RowIndex].Value.ToString();
            sLocSts = Grid1[iCol_LocSts, e.RowIndex].Value.ToString();

            if (sLocSts != "S")
            {
                if (sLocSts == "O")
                {
                    sMsg = "此批材料正在執行出庫中\r\n";
                    sMsg = sMsg + "不可以重覆執行\r\n";
                    sMsg = sMsg + "請待前一個命令完成後,再作業";
                    clsMSG.ShowWarningMsg(sMsg);
                    return;
                }
                else
                {
                    sMsg = "不是庫存儲位,不可以出庫!!";
                    clsMSG.ShowWarningMsg(sMsg);
                    return;
                }
            }

            if (Grid1.Rows[e.RowIndex].HeaderCell.Value.ToString() == "*")
            {
                for (i = 0; i <= Grid1.RowCount - 1; i++)
                {
                    if (Grid1[iCol_Loc, i].Value.ToString() == sLoc)
                    {
                        clsTool.SetGridSeletRowColorHead(ref Grid1, false, i);
                    }
                }
            }
            else
            {
                for (i = 0; i <= Grid1.RowCount - 1; i++)
                {
                    if (Grid1[iCol_Loc, i].Value.ToString() == sLoc)
                    {
                        clsTool.SetGridSeletRowColorHead(ref Grid1, true, i);
                    }
                }
            }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {

            string sSQL = ""; DbDataReader dbRS = null;
            int i = 0; int j = 0; bool bCmdFlag = false;
            cls_CmdMst aCmdMst = new cls_CmdMst();
            cls_CmdDtl aCmdDtl = new cls_CmdDtl();
            string sLoc1 = ""; string sLocOther = ""; string sLocIDOther = "";

            //中科廠-站號依儲位
            //判斷站號是否正確
            //if (clsASRS.FunChkStnNo(cboStnNo.Text.Trim()) == false) { return; }

            //讀取要出庫的儲位資料
            string[] aLoc = new string[1]; aLoc[0] = "";
            if (FunGetLocList(ref aLoc) == false) { return; }

            //判斷同一個料盤(同一個WMS儲位)剛好另一個收料序號沒有勾選到，則顯示跳出提示畫面
            if (FunChkSelTrayInfo(ref aLoc) == false) { return; }


            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; }

            #region 判斷是否有儲位重整中
            string sTmpMsg = "";
            if (clsASRS.FunChkCycleStsIsRunning(ref sTmpMsg) == false)
            {
                clsMSG.ShowInformationMsg(sTmpMsg);
                clsDB.FunClsDB();
                return;
            }
            #endregion

            //判斷-->此尚有更換標籤需求,請更換標籤
            string[] aFOSB = new string[1]; aFOSB[0] = "";
            if (FunGetFosbID(ref aFOSB) == false) { clsDB.FunClsDB(); return; }



            //產生命令
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
                //判斷Loc是否有值存在
                if (aLoc[i] != "")
                {

                    #region copy Loc and Clear tmpGrid
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

                    #region Get Other Loc (sLocOther/sLocIDOther)
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
                            //break;
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


                    
                    bCmdFlag = true;
                    clsDB.FunCommitCtrl("BEGIN");

                    #region 預約儲位
                    if (bCmdFlag == true)
                    {
                        sSQL = "UPDATE LOC_MST SET LOCSTS = 'O' WHERE LOC = '" + aLoc[i] + "' AND LOCSTS = 'S' ";
                        if (clsDB.FunExecSql(sSQL) == false)
                        {
                            bCmdFlag = false;
                        }
                    }
                    if (bCmdFlag == true)
                    {
                        if (sLocOther != "")
                        {
                            sSQL = "UPDATE LOC_MST SET LOCSTS = 'O' WHERE LOC = '" + sLocOther + "' AND LOCSTS = 'S' ";
                            if (clsDB.FunExecSql(sSQL) == false)
                            {
                                bCmdFlag = false;
                            }
                        }
                    }
                    #endregion

                    #region 產生命令主檔
                    if (bCmdFlag == true)
                    {
                        aCmdMst.FunCmdMstClear();   //Clear()
                        aCmdMst.CMDSNO = sCmdSno[i];
                        aCmdMst.SNO1 = sSNO1;   // "1";                        
                        aCmdMst.LOC1 = aLoc[i];
                        aCmdMst.LOCID1 = tmpGrid1[iCol_LocID, 0].Value.ToString();   //LOCID
                        aCmdMst.SCAN1 = "N";
                        if (sLocOther == "")
                        {
                            aCmdMst.SNO2 = "";
                            aCmdMst.CMDMODE = clsASRS.gsCmdMode_Out;   //2
                            //idx = 1;    //1個空料盒
                        }
                        else
                        {
                            aCmdMst.SNO2 = sSNO2;
                            aCmdMst.LOC2 = sLocOther;
                            aCmdMst.LOCID2 = sLocIDOther;
                            aCmdMst.CMDMODE = clsASRS.gsCmdMode_Pack;   //3
                            aCmdMst.SCAN2 = "N";
                            //    //idx = 2;    //2個空料盒
                        }
                        aCmdMst.CMDSTS = "0";
                        aCmdMst.PRT = "5";
                                                
                        //中科廠-站號依儲位
                        //aCmdMst.STNNO = cboStnNo.Text;
                        if (cboStnNo.Text == "D04") { aCmdMst.STNNO = cboStnNo.Text; }
                        else { aCmdMst.STNNO = clsASRS.FunGetStnNoByLoc_SPIL_ZX(sLoc1); }
                        
                        aCmdMst.IOTYP = clsASRS.gsIOTYPE_WMS_Out;
                        aCmdMst.AVAIL = "100";  // 彰化廠
                        aCmdMst.MIXQTY = "1";   // 彰化廠
                        aCmdMst.NEWLOC = "";
                        aCmdMst.PROGID = clsASRS.gsIOTYPE_WMS_Out_PID;
                        aCmdMst.USERID = clsASRS.gstrLoginUser;
                        aCmdMst.TRACE = "0";
                        aCmdMst.STORAGETYP = "";
                        if (aCmdMst.FunInsCmdMst() == false)
                        {
                            bCmdFlag = false;
                        }                        
                    }
                    #endregion

                    #region 產生命令明細檔
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

                    if (bCmdFlag == true)
                    {
                        clsDB.FunCommitCtrl("COMMIT");
                    }
                    else
                    {
                        clsDB.FunCommitCtrl("ROLLBACK");
                        clsDB.FunClsDB();
                        this.Cursor = Cursors.Default;
                        clsMSG.ShowErrMsg(clsMSG.MSG.COMMAND_ERROR);
                        return;
                    }                    
                }
            }

            clsDB.FunClsDB();
            this.Cursor = Cursors.Default;
            clsMSG.ShowInformationMsg(clsMSG.MSG.SET_PARAMETER_OK);
            FormCls();

        }

        



        private bool FunGetLocList(ref string[] aLoc)
        {
            int i = 0; int j = 0; int idx = 0;
            aLoc[0] = "";
            for (i = 0; i <= Grid1.RowCount - 1; i++)
            {
                if (Grid1.Rows[i].HeaderCell.Value.ToString() == "*")
                {
                    if (idx == 0)
                    {
                        aLoc[0] = Grid1[iCol_Loc, i].Value.ToString();
                        idx++;
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
                            idx++;
                            Array.Resize<string>(ref aLoc, idx);
                            aLoc[idx - 1] = Grid1[iCol_Loc, i].Value.ToString();
                        }
                    }
                }
            }
            if (aLoc.Length == 0)
            {
                if (aLoc[0] == "")
                {
                    clsMSG.ShowWarningMsg("請選擇要出庫的WMS收料序號");
                    return false;
                }
            }
            return true;
        }

        private bool FunChkSelTrayInfo(ref string[] aLoc)
        {
            int x = 0; int y = 0; string sLocTmp = "";
            for (x = 0; x <= aLoc.Length - 1; x++)
            {
                for (y = 0; y <= Grid1.RowCount - 1; y++)
                {
                    if (Grid1[iCol_Loc, y].Value.ToString() == sLocTmp)
                    {
                        if (Grid1.Rows[y].HeaderCell.Value.ToString() != "*")
                        {
                            string sMsg = "";
                            sMsg = "WMS儲位(" + Grid1[iCol_WMSLOC, y].Value.ToString() + ")\r\n"; // +Environment.NewLine;                            
                            sMsg = sMsg + "資料類別(" + Grid1[iCol_DOCTYP, y].Value.ToString() + ")\r\n";
                            sMsg = sMsg + "單號(" + Grid1[iCol_DOCID, y].Value.ToString() + ")\r\n";
                            sMsg = sMsg + "WMS收料序號(" + Grid1[iCol_FOSBID, y].Value + ")\r\n";
                            sMsg = sMsg + "待作業,是否選擇一併出庫 ?";

                            if (clsMSG.ShowQuestionMsg(sMsg) == true)
                            {
                                //跳出判斷回到畫面讓 User重新選擇
                                return false;
                            }
                            else
                            {
                                //繼續判斷
                            }
                        }
                    }
                }
            }

            return true;
        }

        private bool FunGetFosbID(ref string[] aFOSB)
        {
            int i = 0; int idx = 0; int j = 0;

            #region Get FOSB ID
            for (i = 0; i <= Grid1.RowCount - 1; i++)
            {
                if (Grid1.Rows[i].HeaderCell.Value.ToString() == "*")
                {
                    if (idx == 0)
                    {
                        aFOSB[0] = Grid1[iCol_FOSBID, i].Value.ToString();
                        idx = idx + 1;
                    }
                    else
                    {
                        bool bIsOverlay = false;
                        for (j = 0; j <= aFOSB.Length - 1; j++)
                        {
                            if (aFOSB[j] == Grid1[iCol_FOSBID, i].Value.ToString())
                            {
                                bIsOverlay = true;
                                break;
                            }
                        }
                        if (bIsOverlay == false)
                        {
                            idx++;
                            Array.Resize<string>(ref aFOSB, idx);
                            aFOSB[idx - 1] = Grid1[iCol_FOSBID, i].Value.ToString();
                        }
                    }
                }
            }
            #endregion

            #region Check FOSB ID on WMS
            string sSQL = ""; DbDataReader dbRS = null;
            bool bHadUpdData = false; bool bShowData = false;
            for (i = 0; i <= aFOSB.Length - 1; i++)
            {
                if (aFOSB[i] != "")
                {
                    sSQL = "SELECT * FROM TB_ASRS_TO_WMS_TEMP WHERE STATUS = 'A' AND SEND_ASRS = 'Y' ";
                    sSQL = sSQL + "AND RCVNO = '" + aFOSB[i] + "' ";
                    sSQL = sSQL + "AND TYPE IN ('UPDATE_DATA','STOCKOUT') ";
                    if (clsDB.FunRsSql(sSQL, ref dbRS))
                    {
                        while (dbRS.Read())
                        {
                            if (dbRS["TYPE"].ToString() == "UPDATE_DATA")
                            {
                                bHadUpdData = true;
                            }
                        }
                        dbRS.Close();
                    }

                    if (bHadUpdData == true)
                    {
                        bShowData = false;
                        for (j = 0; j <= Grid1.RowCount - 1; j++)
                        {
                            if (Grid1.Rows[j].HeaderCell.Value.ToString() == "*")
                            {
                                if (Grid1[iCol_FOSBID, j].Value.ToString() == aFOSB[i])
                                {
                                    if (Grid1[iCol_DOCTYP, j].Value.ToString() == iCol_DocTyp_Update)
                                    {

                                    }
                                    else
                                    {
                                        //下架
                                        bShowData = true;
                                        break;
                                    }
                                }
                            }
                        }

                        if (bShowData == true)
                        {
                            string sMsg1 = "";
                            sMsg1 = "收料序號：" + aFOSB[i] + " /r/n";
                            sMsg1 = sMsg1 + "此批尚有更換標籤需求/r/n";
                            sMsg1 = sMsg1 + "請同步執行標籤更換!!/r/n";

                            clsMSG.ShowInformationMsg(sMsg1);
                            return false;
                        }
                    }
                }

            }

            return true;
            #endregion
        }

        private bool FunGetLocToTmpGrid(string sGetLoc)
        {
            string sSQL = ""; DbDataReader dbRS = null;
            int i = 0; int j = 0;
            string sLoc = ""; string sItemNo = ""; string sLotNo = ""; string sFosbID = "";

            tmpGrid1.RowCount = 0;

            #region Get Data
            sSQL = "SELECT M.LOCID,M.LOCSTS,M.STORAGETYP,D.* FROM LOC_MST M, LOC_DTL D WHERE M.LOC = D.LOC AND M.LOC = '" + sGetLoc + "' ";
            if (clsDB.FunRsSql(sSQL, ref dbRS))
            {
                while (dbRS.Read())
                {
                    sLoc = sGetLoc;
                    sItemNo = dbRS["ITEMNO"].ToString();
                    sLotNo = dbRS["LOTNO"].ToString();
                    sFosbID = dbRS["FOSBID"].ToString();

                    tmpGrid1.Rows.Add();
                    tmpGrid1[iCol_DOCTYP, tmpGrid1.Rows.Count - 1].Value = "";
                    tmpGrid1[iCol_DOCID, tmpGrid1.Rows.Count - 1].Value = "";
                    tmpGrid1[iCol_FOSBID, tmpGrid1.Rows.Count - 1].Value = dbRS["FOSBID"].ToString();
                    tmpGrid1[iCol_WMSLOC, tmpGrid1.Rows.Count - 1].Value = "";
                    tmpGrid1[iCol_ITEM, tmpGrid1.Rows.Count - 1].Value = dbRS["ITEMNO"].ToString();
                    tmpGrid1[iCol_LotNo, tmpGrid1.Rows.Count - 1].Value = dbRS["LOTNO"].ToString();
                    tmpGrid1[iCol_WaferQty, tmpGrid1.Rows.Count - 1].Value = dbRS["WAFERQTY"].ToString();
                    tmpGrid1[iCol_ShipQty, tmpGrid1.Rows.Count - 1].Value = dbRS["SHIPQTY"].ToString();
                    tmpGrid1[iCol_LocMark, tmpGrid1.Rows.Count - 1].Value = "";

                    tmpGrid1[iCol_Loc, tmpGrid1.Rows.Count - 1].Value = dbRS["LOC"].ToString();
                    tmpGrid1[iCol_LocSts, tmpGrid1.Rows.Count - 1].Value = dbRS["LOCSTS"].ToString();
                    tmpGrid1[iCol_LocID, tmpGrid1.Rows.Count - 1].Value = dbRS["LOCID"].ToString();
                    //tmpGrid1[iCol_SubLoc, tmpGrid1.Rows.Count - 1].Value = dbRS["SUBLOC"].ToString();
                    tmpGrid1[iCol_Cust, tmpGrid1.Rows.Count - 1].Value = dbRS["CUSTOMER"].ToString();
                    tmpGrid1[iCol_Dev, tmpGrid1.Rows.Count - 1].Value = dbRS["DEVICE"].ToString();
                    tmpGrid1[iCol_ChkIQC, tmpGrid1.Rows.Count - 1].Value = dbRS["CHKIQC"].ToString();
                    tmpGrid1[iCol_InDate, tmpGrid1.Rows.Count - 1].Value = dbRS["INDATE"].ToString();
                    tmpGrid1[iCol_TrnDate, tmpGrid1.Rows.Count - 1].Value = dbRS["TRNDATE"].ToString();
                    tmpGrid1[iCol_REMARK, tmpGrid1.Rows.Count - 1].Value = dbRS["REMARK"].ToString();
                    tmpGrid1[iCol_TRANSACTION_DATE, tmpGrid1.Rows.Count - 1].Value = dbRS["TRANSACTION_DATE"].ToString();
                                        
                    tmpGrid1[iCol_GIB_CUSTOMER, tmpGrid1.Rows.Count - 1].Value = dbRS["GIB_CUSTOMER"].ToString();
                    tmpGrid1[iCol_FAB_LOT_NO, tmpGrid1.Rows.Count - 1].Value = dbRS["FAB_LOT_NO"].ToString();
                    tmpGrid1[iCol_FAB_TYPE, tmpGrid1.Rows.Count - 1].Value = dbRS["FAB_TYPE"].ToString();
                    tmpGrid1[iCol_TYPENO, tmpGrid1.Rows.Count - 1].Value = dbRS["TYPENO"].ToString();
                    tmpGrid1[iCol_LOT_TYPE, tmpGrid1.Rows.Count - 1].Value = dbRS["LOT_TYPE"].ToString();

                    tmpGrid1[iCol_WAFER_SIZE, tmpGrid1.Rows.Count - 1].Value = dbRS["WAFER_SIZE"].ToString();
                    tmpGrid1[iCol_YIELD, tmpGrid1.Rows.Count - 1].Value = dbRS["YIELD"].ToString();
                    tmpGrid1[iCol_APP_NO, tmpGrid1.Rows.Count - 1].Value = dbRS["APP_NO"].ToString();
                    tmpGrid1[iCol_REL_DATE, tmpGrid1.Rows.Count - 1].Value = dbRS["REL_DATE"].ToString();

                    tmpGrid1[iCol_REASON_NAME, tmpGrid1.Rows.Count - 1].Value = dbRS["REASON_NAME"].ToString();
                    tmpGrid1[iCol_TRANSACTION_REFERENCE, tmpGrid1.Rows.Count - 1].Value = dbRS["TRANSACTION_REFERENCE"].ToString();
                    tmpGrid1[iCol_TRANSACTION_SOURCE_ID, tmpGrid1.Rows.Count - 1].Value = dbRS["TRANSACTION_SOURCE_ID"].ToString();
                    tmpGrid1[iCol_TRANSACTION_TYPE_ID, tmpGrid1.Rows.Count - 1].Value = dbRS["TRANSACTION_TYPE_ID"].ToString();
                    tmpGrid1[iCol_FROM_ORG, tmpGrid1.Rows.Count - 1].Value = dbRS["FROM_ORG"].ToString();
                    tmpGrid1[iCol_TO_ORG, tmpGrid1.Rows.Count - 1].Value = dbRS["TO_ORG"].ToString();
                    tmpGrid1[iCol_FROM_BANK, tmpGrid1.Rows.Count - 1].Value = dbRS["FROM_BANK"].ToString();
                    tmpGrid1[iCol_TO_BANK, tmpGrid1.Rows.Count - 1].Value = dbRS["TO_BANK"].ToString();

                    tmpGrid1[iCol_Store, tmpGrid1.Rows.Count - 1].Value = dbRS["STORE"].ToString();
                    tmpGrid1[iCol_OffQty, tmpGrid1.Rows.Count - 1].Value = dbRS["OFFQTY"].ToString();
                    tmpGrid1[iCol_IQCID, tmpGrid1.Rows.Count - 1].Value = dbRS["IQC_ID"].ToString();
                    tmpGrid1[iCol_ACCID, tmpGrid1.Rows.Count - 1].Value = dbRS["ACC_ID"].ToString();

                    tmpGrid1[iCol_SEQ_NO, tmpGrid1.Rows.Count - 1].Value = "";

                    tmpGrid1[iCol_StorageTyp, tmpGrid1.Rows.Count - 1].Value = dbRS["STORAGETYP"].ToString();
                    tmpGrid1[iCol_COID, tmpGrid1.Rows.Count - 1].Value = "";// dbRS["COID"].ToString();
                }
                dbRS.Close();
            }
            #endregion

            if (tmpGrid1.RowCount == 0) { return false; }

            #region 判斷要出庫的資料
            string sFosbID_1 = ""; string sType = ""; string sSNID = "";
            string sTypePri = "0";  //Type 1.下架 or 2.更換標籤
            for (i = 0; i <= Grid1.RowCount - 1; i++)
            {
                if (Grid1[iCol_Loc, i].Value.ToString() == sGetLoc)
                {
                    sFosbID_1 = Grid1[iCol_FOSBID, i].Value.ToString();
                    sType = Grid1[iCol_DOCTYP, i].Value.ToString();
                    sSNID = Grid1[iCol_SEQ_NO, i].Value.ToString();

                    for (j = 0; j <= tmpGrid1.RowCount - 1; j++)
                    {
                        if ((tmpGrid1[iCol_Loc, j].Value.ToString() == sGetLoc) &&
                            (tmpGrid1[iCol_FOSBID, j].Value.ToString() == sFosbID_1))
                        {
                            tmpGrid1.Rows[j].HeaderCell.Value = "*";
                            
                            if (sType == iCol_DocTyp_Update)    //更換標籤
                            {
                                if (sTypePri == "0")
                                {
                                    sTypePri = "2";
                                }
                                else
                                {
                                    if (sTypePri == "1")
                                    {
                                        sTypePri = "1";
                                    }
                                }
                            }
                            else
                            {
                                sTypePri = "1";
                            }

                            if (sTypePri == "2")
                            {
                                tmpGrid1[iCol_DOCTYP, j].Value = iCol_DocTyp_Update;
                                tmpGrid1[iCol_SEQ_NO, j].Value = sSNID;
                            }
                            else
                            {
                                if (sType == iCol_DocTyp_Update)    //更換標籤
                                {

                                }
                                tmpGrid1[iCol_DOCTYP, j].Value = sType;
                                tmpGrid1[iCol_SEQ_NO, j].Value = sSNID;
                            }
                        }
                    }
                }

            }
            #endregion

            return true;
        }

        private bool FunGetLocToTmpGrid2(string sGetLoc)
        {
            string sSQL = ""; DbDataReader dbRS = null;
            int i = 0; int j = 0;
            string sLoc = ""; string sItemNo = ""; string sLotNo = ""; string sFosbID = "";

            tmpGrid2.RowCount = 0;

            #region Get Data
            sSQL = "SELECT M.LOCID,M.LOCSTS,M.STORAGETYP,D.* FROM LOC_MST M, LOC_DTL D WHERE M.LOC = D.LOC AND M.LOC = '" + sGetLoc + "' ";
            if (clsDB.FunRsSql(sSQL, ref dbRS))
            {
                while (dbRS.Read())
                {
                    sLoc = sGetLoc;
                    sItemNo = dbRS["ITEMNO"].ToString();
                    sLotNo = dbRS["LOTNO"].ToString();
                    sFosbID = dbRS["FOSBID"].ToString();

                    tmpGrid2.Rows.Add();
                    tmpGrid2[iCol_DOCTYP, tmpGrid2.Rows.Count - 1].Value = "";
                    tmpGrid2[iCol_DOCID, tmpGrid2.Rows.Count - 1].Value = "";
                    tmpGrid2[iCol_FOSBID, tmpGrid2.Rows.Count - 1].Value = dbRS["FOSBID"].ToString();
                    tmpGrid2[iCol_WMSLOC, tmpGrid2.Rows.Count - 1].Value = "";
                    tmpGrid2[iCol_ITEM, tmpGrid2.Rows.Count - 1].Value = dbRS["ITEMNO"].ToString();
                    tmpGrid2[iCol_LotNo, tmpGrid2.Rows.Count - 1].Value = dbRS["LOTNO"].ToString();
                    tmpGrid2[iCol_WaferQty, tmpGrid2.Rows.Count - 1].Value = dbRS["WAFERQTY"].ToString();
                    tmpGrid2[iCol_ShipQty, tmpGrid2.Rows.Count - 1].Value = dbRS["SHIPQTY"].ToString();
                    tmpGrid2[iCol_LocMark, tmpGrid2.Rows.Count - 1].Value = "";

                    tmpGrid2[iCol_Loc, tmpGrid2.Rows.Count - 1].Value = dbRS["LOC"].ToString();
                    tmpGrid2[iCol_LocSts, tmpGrid2.Rows.Count - 1].Value = dbRS["LOCSTS"].ToString();
                    tmpGrid2[iCol_LocID, tmpGrid2.Rows.Count - 1].Value = dbRS["LOCID"].ToString();
                    //tmpGrid2[iCol_SubLoc, tmpGrid2.Rows.Count - 1].Value = dbRS["SUBLOC"].ToString();
                    tmpGrid2[iCol_Cust, tmpGrid2.Rows.Count - 1].Value = dbRS["CUSTOMER"].ToString();
                    tmpGrid2[iCol_Dev, tmpGrid2.Rows.Count - 1].Value = dbRS["DEVICE"].ToString();
                    tmpGrid2[iCol_ChkIQC, tmpGrid2.Rows.Count - 1].Value = dbRS["CHKIQC"].ToString();
                    tmpGrid2[iCol_InDate, tmpGrid2.Rows.Count - 1].Value = dbRS["INDATE"].ToString();
                    tmpGrid2[iCol_TrnDate, tmpGrid2.Rows.Count - 1].Value = dbRS["TRNDATE"].ToString();
                    tmpGrid2[iCol_REMARK, tmpGrid2.Rows.Count - 1].Value = dbRS["REMARK"].ToString();
                    tmpGrid2[iCol_TRANSACTION_DATE, tmpGrid2.Rows.Count - 1].Value = dbRS["TRANSACTION_DATE"].ToString();

                    tmpGrid2[iCol_GIB_CUSTOMER, tmpGrid2.Rows.Count - 1].Value = dbRS["GIB_CUSTOMER"].ToString();
                    tmpGrid2[iCol_FAB_LOT_NO, tmpGrid2.Rows.Count - 1].Value = dbRS["FAB_LOT_NO"].ToString();
                    tmpGrid2[iCol_FAB_TYPE, tmpGrid2.Rows.Count - 1].Value = dbRS["FAB_TYPE"].ToString();
                    tmpGrid2[iCol_TYPENO, tmpGrid2.Rows.Count - 1].Value = dbRS["TYPENO"].ToString();
                    tmpGrid2[iCol_LOT_TYPE, tmpGrid2.Rows.Count - 1].Value = dbRS["LOT_TYPE"].ToString();
                    tmpGrid2[iCol_WAFER_SIZE, tmpGrid2.Rows.Count - 1].Value = dbRS["WAFER_SIZE"].ToString();
                    tmpGrid2[iCol_YIELD, tmpGrid2.Rows.Count - 1].Value = dbRS["YIELD"].ToString();
                    tmpGrid2[iCol_APP_NO, tmpGrid2.Rows.Count - 1].Value = dbRS["APP_NO"].ToString();
                    tmpGrid2[iCol_REL_DATE, tmpGrid2.Rows.Count - 1].Value = dbRS["REL_DATE"].ToString();

                    tmpGrid2[iCol_REASON_NAME, tmpGrid2.Rows.Count - 1].Value = dbRS["REASON_NAME"].ToString();
                    tmpGrid2[iCol_TRANSACTION_REFERENCE, tmpGrid2.Rows.Count - 1].Value = dbRS["TRANSACTION_REFERENCE"].ToString();
                    tmpGrid2[iCol_TRANSACTION_SOURCE_ID, tmpGrid2.Rows.Count - 1].Value = dbRS["TRANSACTION_SOURCE_ID"].ToString();
                    tmpGrid2[iCol_TRANSACTION_TYPE_ID, tmpGrid2.Rows.Count - 1].Value = dbRS["TRANSACTION_TYPE_ID"].ToString();
                    tmpGrid2[iCol_FROM_ORG, tmpGrid2.Rows.Count - 1].Value = dbRS["FROM_ORG"].ToString();
                    tmpGrid2[iCol_TO_ORG, tmpGrid2.Rows.Count - 1].Value = dbRS["TO_ORG"].ToString();
                    tmpGrid2[iCol_FROM_BANK, tmpGrid2.Rows.Count - 1].Value = dbRS["FROM_BANK"].ToString();
                    tmpGrid2[iCol_TO_BANK, tmpGrid2.Rows.Count - 1].Value = dbRS["TO_BANK"].ToString();

                    tmpGrid2[iCol_Store, tmpGrid2.Rows.Count - 1].Value = dbRS["STORE"].ToString();
                    tmpGrid2[iCol_OffQty, tmpGrid2.Rows.Count - 1].Value = dbRS["OFFQTY"].ToString();
                    tmpGrid2[iCol_IQCID, tmpGrid2.Rows.Count - 1].Value = dbRS["IQC_ID"].ToString();
                    tmpGrid2[iCol_ACCID, tmpGrid2.Rows.Count - 1].Value = dbRS["ACC_ID"].ToString();

                    tmpGrid2[iCol_SEQ_NO, tmpGrid2.Rows.Count - 1].Value = "";

                    tmpGrid2[iCol_StorageTyp, tmpGrid2.Rows.Count - 1].Value = dbRS["STORAGETYP"].ToString();
                    tmpGrid2[iCol_COID, tmpGrid2.Rows.Count - 1].Value = "";// dbRS["COID"].ToString();

                }
                dbRS.Close();
            }
            #endregion

            if (tmpGrid2.RowCount == 0) { return false; }

            #region 判斷要出庫的資料
            string sFosbID_1 = ""; string sType = ""; string sSNID = "";
            string sTypePri = "0";  //Type 1.下架 or 2.更換標籤
            for (i = 0; i <= Grid1.RowCount - 1; i++)
            {
                if (Grid1[iCol_Loc, i].Value.ToString() == sGetLoc)
                {
                    sFosbID_1 = Grid1[iCol_FOSBID, i].Value.ToString();
                    sType = Grid1[iCol_DOCTYP, i].Value.ToString();
                    sSNID = Grid1[iCol_SEQ_NO, i].Value.ToString();

                    for (j = 0; j <= tmpGrid2.RowCount - 1; j++)
                    {
                        if ((tmpGrid2[iCol_Loc, j].Value.ToString() == sGetLoc) &&
                            (tmpGrid2[iCol_FOSBID, j].Value.ToString() == sFosbID_1))
                        {
                            tmpGrid2.Rows[j].HeaderCell.Value = "*";
                            if (sType == iCol_DocTyp_Update)    //更換標籤
                            {
                                if (sTypePri == "0")
                                {
                                    sTypePri = "2";
                                }
                                else
                                {
                                    if (sTypePri == "1")
                                    {
                                        sTypePri = "1";
                                    }
                                }
                            }
                            else
                            {
                                sTypePri = "1";
                            }

                            if (sTypePri == "2")
                            {
                                tmpGrid2[iCol_DOCTYP, j].Value = iCol_DocTyp_Update;
                                tmpGrid2[iCol_SEQ_NO, j].Value = sSNID;
                            }
                            else
                            {
                                if (sType == iCol_DocTyp_Update)    //更換標籤
                                {

                                }
                                tmpGrid2[iCol_DOCTYP, j].Value = sType;
                                tmpGrid2[iCol_SEQ_NO, j].Value = sSNID;
                            }
                        }
                    }
                }

            }
            #endregion

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

                aCmdDtl.OFFACTQTY = aCmdDtl.OFFQTY;
                aCmdDtl.WAFERACTQTY = aCmdDtl.WAFERQTY;
                aCmdDtl.SHIPACTQTY = aCmdDtl.SHIPQTY;
                if (objGridTmp.Rows[j].HeaderCell.Value.ToString() == "*")
                {
                    if (objGridTmp[iCol_DOCTYP, j].Value.ToString() == iCol_DocTyp_Update) // '更換標籤
                    {
                        aCmdDtl.FLAGQTY = clsASRS.gsFlagQty_Limit;
                    }
                    else
                    {
                        aCmdDtl.FLAGQTY = clsASRS.gsFlagQty_OUT;
                    }
                }
                else
                {
                    aCmdDtl.FLAGQTY = clsASRS.gsFlagQty_Limit;
                }

                aCmdDtl.CHKIQC = objGridTmp[iCol_ChkIQC, j].Value.ToString();
                aCmdDtl.FOSBID = objGridTmp[iCol_FOSBID, j].Value.ToString();
                aCmdDtl.IQC_ID = objGridTmp[iCol_IQCID, j].Value.ToString();
                aCmdDtl.ACC_ID = objGridTmp[iCol_ACCID, j].Value.ToString();
                aCmdDtl.INDATE = objGridTmp[iCol_InDate, j].Value.ToString();
                aCmdDtl.REMARK = objGridTmp[iCol_REMARK, j].Value.ToString();
                aCmdDtl.TRANSACTION_DATE = objGridTmp[iCol_TRANSACTION_DATE, j].Value.ToString();
                if (aCmdDtl.TRANSACTION_DATE == "")
                {
                    aCmdDtl.TRANSACTION_DATE = clsTool.GetDateTime(); //Format(Now, "yyyy/MM/dd HH:mm:ss")
                }
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
                aCmdDtl.CYCLENO = objGridTmp[iCol_SEQ_NO, j].Value.ToString();       //'WMS
                aCmdDtl.COID = "";// objGridTmp[iCol_COID, j].Value.ToString();
                aCmdDtl.DOCID = objGridTmp[iCol_DOCID, j].Value.ToString();         // 'WMS
                aCmdDtl.DOCID2 = "";//? objGridTmp[iCol_DOCID2, j].Value.ToString();       // 'WMS
                #endregion

                if (aCmdDtl.FunInsCmdDtl() == false)
                {
                    return false;
                }
            }



            int y = 0;
            for (j = 0; j <= objGridTmp.RowCount - 1; j++)
            {
                bool bFlag = true;
                if (j == 0)
                {
                    bFlag = true;
                }
                else
                {
                    for (y = 0; y <= j - 1; y++)
                    {
                        if (objGridTmp[iCol_FOSBID, j].Value.ToString() == objGridTmp[iCol_FOSBID, y].Value.ToString())
                        {
                            bFlag = false;
                            break;
                        }
                    }
                }

                if (bFlag == true)
                {
                    //WMS 資料
                    string sSQL = "";
                    if (objGridTmp.Rows[j].HeaderCell.Value == "*")
                    {
                        if (objGridTmp[iCol_DOCTYP, j].Value.ToString() == iCol_DocTyp_Update)       //更換標籤
                        {
                            sSQL = "UPDATE TB_ASRS_TO_WMS_TEMP SET SEND_ASRS = 'A' ";
                            sSQL = sSQL + "WHERE RCVNO = '" + objGridTmp[iCol_FOSBID, j].Value.ToString() + "' ";
                            sSQL = sSQL + "AND STATUS = 'A' AND SEND_ASRS = 'Y' ";
                            sSQL = sSQL + "AND TYPE = 'UPDATE_DATA' ";
                        }
                        else
                        {
                            sSQL = "UPDATE TB_ASRS_TO_WMS_TEMP SET SEND_ASRS = 'A' ";
                            sSQL = sSQL + "WHERE RCVNO = '" + objGridTmp[iCol_FOSBID, j].Value.ToString() + "' ";
                            sSQL = sSQL + "AND STATUS = 'A' AND SEND_ASRS = 'Y' ";
                            sSQL = sSQL + "AND TYPE IN ('UPDATE_DATA','STOCKOUT') ";
                        }
                        if (clsDB.FunExecSql(sSQL) == false)
                        {
                            return false;
                        }
                    }
                }

            }
            return true;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            frmASRS frmA = new frmASRS();
            frmA.ShowFormA();


            //foreach (Form f in this.MdiChildren)
            //{
            //    if (f.Name == "frm_WMS_STK_OUT_Receive")
            //    {
            //        f.Visible = true;
            //        f.Activate();
            //        f.WindowState = FormWindowState.Maximized;
            //        f.Focus();
            //        return;
            //    }
            //}

            //frm_WMS_STK_OUT_Receive frmP_WMS_STK_OUT_Receive = new frm_WMS_STK_OUT_Receive();
            //frmP_WMS_STK_OUT_Receive.MdiParent = this.MdiParent;

            //////MdiParent
            //frmP_WMS_STK_OUT_Receive.Show();
            //frmP_WMS_STK_OUT_Receive.Focus();
        }



    }



}
