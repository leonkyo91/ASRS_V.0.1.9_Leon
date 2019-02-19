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
    public partial class frm_WMS_CYCLE : Form
    {

        string gsCrn = "";
        string gsWmsLocList = "";

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

        int iCol_Loc = 10;           //儲位
        int iCol_LocSts = 11;        //儲位狀態
        int iCol_LocID = 12;         //料盤ID
        int iCol_SubLoc = 13;        //L/R
        int iCol_Cust = 14;          //客戶簡稱 
        int iCol_Dev = 15;           //DEVICE
        int iCol_ChkIQC = 16;       //檢驗

        int iCol_InDate = 17;       //入庫日期
        int iCol_TrnDate = 18;      //異動日期
        int iCol_REMARK = 19;                   //備註
        int iCol_TRANSACTION_DATE = 20;        //收料日期
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
        int iCol_ONDATA = 46;
        int iCol_MIXQTY = 47;
        int iCol_AVAIL = 48;
        int iCol_Counts = 49;
        #endregion

        public frm_WMS_CYCLE()
        {
            InitializeComponent();
        }

        private void frm_WMS_CYCLE_Load(object sender, EventArgs e)
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

            oGrid.Columns[iCol_CreationDate].Width = 110; oGrid.Columns[iCol_CreationDate].Name = "Creation Date"; oGrid.Columns[iCol_CreationDate].Visible = false;

            oGrid.Columns[iCol_LocMark].Width = 130; oGrid.Columns[iCol_LocMark].Name = "儲位備註";

            oGrid.Columns[iCol_Loc].Width = 50; oGrid.Columns[iCol_Loc].Name = "儲位";
            oGrid.Columns[iCol_LocSts].Width = 40; oGrid.Columns[iCol_LocSts].Name = "儲位狀態";
            oGrid.Columns[iCol_LocID].Width = 90; oGrid.Columns[iCol_LocID].Name = "料盤ID"; oGrid.Columns[iCol_LocID].Visible = false;
            oGrid.Columns[iCol_SubLoc].Width = 50; oGrid.Columns[iCol_SubLoc].Name = "對映儲位"; //oGrid.Columns[iCol_SubLoc].Visible = false;
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

            oGrid.Columns[iCol_SEQ_NO].Width = 100; oGrid.Columns[iCol_SEQ_NO].Name = ""; oGrid.Columns[iCol_SEQ_NO].Visible = false; //'For WMS
            oGrid.Columns[iCol_COID].Width = 100; oGrid.Columns[iCol_COID].Name = ""; oGrid.Columns[iCol_COID].Visible = false;     //'For WMS
            oGrid.Columns[iCol_DOCID2].Width = 100; oGrid.Columns[iCol_DOCID2].Name = "WMS下架單號"; oGrid.Columns[iCol_DOCID2].Visible = false;     //'For WMS

            oGrid.Columns[iCol_Store].Visible = false;
            oGrid.Columns[iCol_OffQty].Visible = false;
            oGrid.Columns[iCol_IQCID].Visible = false;
            oGrid.Columns[iCol_ACCID].Visible = false;
            oGrid.Columns[iCol_StorageTyp].Visible = false;

            oGrid.Columns[iCol_ONDATA].Visible = false;
            oGrid.Columns[iCol_MIXQTY].Visible = false;
            oGrid.Columns[iCol_AVAIL].Visible = false;


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
            //clsASRS.SubCboSetStnNo(ref cboStnNo);
            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };
            //cboStnNo.Text = clsASRS.FunGetStnNoByAreaNo(clsASRS.gsAreaNo);

            clsASRS.SubCboSetCrnNo(ref cboCrn);
            clsDB.FunClsDB();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCls_Click(object sender, EventArgs e)
        {
            SubClear();
        }

        private void SubClear()
        {
            Grid1.RowCount = 0;
            txtWmsID.Text = "";
            txtLoc.Text = "";
            cboCrn.Text = "";
            txtFosbID.Text = "";
            chkSelAll.Checked = false;

            chkStnA01.Checked = false;
            chkStnA02.Checked = false;
            chkStnA03.Checked = false;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            //SubQuery();
            SubQuery_V2();
        }

        private void SubQuery()
        {
            string sSQL = ""; DbDataReader dbRS = null;
            string sNotes = "";
            string[] aWmsLoc = new string[0];
            int i = 0;

            int iCrn = 0; int iRow_x1 = 0; int iRow_x2 = 0;
            string sWmsLoc = "";

            Grid1.RowCount = 0;

            if (RdBtn_1.Checked == true)
            {
                #region Query 1
                sSQL = "SELECT T.SNID,T.TYPE,T.RCVNO,T.DOCTYP,T.DOCID,T.CREATION_DATE,A.* FROM TB_ASRS_TO_WMS_TEMP T ";
                sSQL = sSQL + ", ( ";
                sSQL = sSQL + "SELECT L.*, S.WMS_LOC FROM  ";
                sSQL = sSQL + "(SELECT D.ITEMNO,D.LOTNO,D.WAFERQTY,D.SHIPQTY,D.FOSBID,M.LOC,M.LOCSTS,M.LOCID,M.STORAGETYP ";
                sSQL = sSQL + "FROM LOC_MST M, LOC_DTL D WHERE M.LOC = D.LOC ) L ";
                sSQL = sSQL + "LEFT JOIN SPIL_WMS_LOC S ON L.LOCID = S.ASRS_LOCID ) A ";
                sSQL = sSQL + "WHERE T.RCVNO = A.FOSBID ";
                sSQL = sSQL + "AND T.LOTNO = A.LOTNO ";
                sSQL = sSQL + "AND T.TYPE = 'CYCLE_COUNT' AND T.STATUS = 'A' AND T.SEND_ASRS = 'Y' ";

                if (txtWmsID.Text != "")
                {
                    sSQL = sSQL + "AND T.DOCID = '" + txtWmsID.Text + "' ";
                }

                if (txtFosbID.Text != "")
                {
                    sSQL = sSQL + "AND T.RCVNO = '" + txtFosbID.Text + "' ";
                }
                sSQL = sSQL + "ORDER BY T.DOCID DESC, T.RCVNO ";
                #endregion
            }
            else if (RdBtn_2.Checked == true)
            {
                #region Query 2
                sSQL = "SELECT L.*, S.WMS_LOC FROM  ";
                sSQL = sSQL + "(SELECT D.ITEMNO,D.LOTNO,D.WAFERQTY,D.SHIPQTY,D.FOSBID,M.LOC,M.LOCSTS,M.LOCID,M.STORAGETYP,M.ROW_X,M.CRANE_NO ";
                sSQL = sSQL + "FROM LOC_MST M, LOC_DTL D WHERE M.LOC = D.LOC ) L ";
                sSQL = sSQL + "LEFT JOIN SPIL_WMS_LOC S ON L.LOCID = S.ASRS_LOCID ";
                sSQL = sSQL + "WHERE L.LOCSTS = 'S' ";

                if (txtLoc.Text != "")
                {
                    aWmsLoc = txtLoc.Text.Split(',');
                    sWmsLoc = "";

                    for (i = 0; i <= aWmsLoc.Length - 1; i++)
                    {
                        if (aWmsLoc[i] != "")
                        {
                            if (sWmsLoc == "")
                            {
                                sWmsLoc = "'" + aWmsLoc[i] + "'";
                            }
                            else
                            {
                                sWmsLoc = sWmsLoc + ",'" + aWmsLoc[i] + "'";
                            }
                        }
                    }

                    if (sWmsLoc == "")
                    {
                        return;
                    }
                    sSQL = sSQL + "AND S.WMS_LOC IN (" + sWmsLoc + ") ";

                }
                else
                {
                    #region Other
                    if (cboCrn.Text.Trim() != "")
                    {
                        iCrn = clsTool.INT(cboCrn.Text);

                        //iRow_x1 = iCrn * 2;
                        //iRow_x2 = (iCrn * 2) - 1;

                        //sSQL = sSQL + "AND L.ROW_X IN (" + iRow_x1 + "," + iRow_x2 + ") ";

                        sSQL = sSQL + "AND L.CRANE_NO = " + iCrn + " ";
                    }
                    #endregion
                }
                #endregion
            }


            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };

            #region Query Data
            if (clsDB.FunRsSql(sSQL, ref dbRS))
            {
                while (dbRS.Read())
                {
                    Grid1.Rows.Add();
                    Grid1.Rows[Grid1.Rows.Count - 1].HeaderCell.Value = "";

                    if (RdBtn_1.Checked == true)
                    {

                        Grid1[iCol_SEQ_NO, Grid1.Rows.Count - 1].Value = dbRS["SNID"].ToString();
                        Grid1[iCol_DOCTYP, Grid1.Rows.Count - 1].Value = dbRS["DOCTYP"].ToString();
                        Grid1[iCol_DOCID, Grid1.Rows.Count - 1].Value = dbRS["DOCID"].ToString();
                        Grid1[iCol_CreationDate, Grid1.Rows.Count - 1].Value = dbRS["CREATION_DATE"].ToString();

                        Grid1[iCol_FOSBID, Grid1.Rows.Count - 1].Value = dbRS["RCVNO"].ToString();
                        Grid1[iCol_WMSLOC, Grid1.Rows.Count - 1].Value = dbRS["WMS_LOC"].ToString();   //'計算WMS儲位
                        Grid1[iCol_ITEM, Grid1.Rows.Count - 1].Value = dbRS["ITEMNO"].ToString();
                        Grid1[iCol_LotNo, Grid1.Rows.Count - 1].Value = dbRS["LOTNO"].ToString();
                        Grid1[iCol_WaferQty, Grid1.Rows.Count - 1].Value = dbRS["WAFERQTY"].ToString();
                        Grid1[iCol_ShipQty, Grid1.Rows.Count - 1].Value = dbRS["SHIPQTY"].ToString();

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
                            else
                            {
                                sNotes = "該儲位不可進行出庫";
                            }
                        }
                        Grid1[iCol_LocMark, Grid1.Rows.Count - 1].Value = sNotes;   // '儲位備註

                        Grid1[iCol_Loc, Grid1.Rows.Count - 1].Value = dbRS["LOC"].ToString();
                        Grid1[iCol_LocSts, Grid1.Rows.Count - 1].Value = dbRS["LOCSTS"].ToString();
                        Grid1[iCol_LocID, Grid1.Rows.Count - 1].Value = dbRS["LOCID"].ToString();
                        Grid1[iCol_SubLoc, Grid1.Rows.Count - 1].Value = "";// dbRS["SUBLOC"].ToString();
                    }
                    else
                    {
                        Grid1[iCol_SEQ_NO, Grid1.Rows.Count - 1].Value = "";
                        Grid1[iCol_DOCTYP, Grid1.Rows.Count - 1].Value = "";
                        Grid1[iCol_DOCID, Grid1.Rows.Count - 1].Value = "";
                        Grid1[iCol_CreationDate, Grid1.Rows.Count - 1].Value = "";

                        Grid1[iCol_FOSBID, Grid1.Rows.Count - 1].Value = dbRS["FOSBID"].ToString();
                        Grid1[iCol_WMSLOC, Grid1.Rows.Count - 1].Value = dbRS["WMS_LOC"].ToString();   //'計算WMS儲位
                        Grid1[iCol_ITEM, Grid1.Rows.Count - 1].Value = dbRS["ITEMNO"].ToString();
                        Grid1[iCol_LotNo, Grid1.Rows.Count - 1].Value = dbRS["LOTNO"].ToString();
                        Grid1[iCol_WaferQty, Grid1.Rows.Count - 1].Value = dbRS["WAFERQTY"].ToString();
                        Grid1[iCol_ShipQty, Grid1.Rows.Count - 1].Value = dbRS["SHIPQTY"].ToString();

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
                            else
                            {
                                sNotes = "該儲位不可進行出庫";
                            }
                        }
                        Grid1[iCol_LocMark, Grid1.Rows.Count - 1].Value = sNotes; //'儲位備註

                        Grid1[iCol_Loc, Grid1.Rows.Count - 1].Value = dbRS["LOC"].ToString();
                        Grid1[iCol_LocSts, Grid1.Rows.Count - 1].Value = dbRS["LOCSTS"].ToString();
                        Grid1[iCol_LocID, Grid1.Rows.Count - 1].Value = dbRS["LOCID"].ToString();
                        Grid1[iCol_SubLoc, Grid1.Rows.Count - 1].Value = "";// dbRS["SUBLOC"].ToString();
                    }
                }
                dbRS.Close();
            }
            #endregion

            clsDB.FunClsDB();

        }

        private void SubQuery_V2()
        {
            string sSQL = ""; DbDataReader dbRS = null;
            string sNotes = "";
            string[] aWmsLoc = new string[0];
            int i = 0;

            int iCrn = 0; 
            string sWmsLoc = "";

            tmpGrid1.RowCount = 0;
            Grid1.RowCount = 0;

            if (RdBtn_1.Checked == true)
            {
                #region Query 1
                sSQL = "SELECT T.SNID,T.TYPE,T.RCVNO,T.DOCTYP,T.DOCID,T.CREATION_DATE,A.* FROM TB_ASRS_TO_WMS_TEMP T ";
                sSQL = sSQL + ", ( ";
                sSQL = sSQL + "SELECT L.*, S.WMS_LOC FROM  ";
                //sSQL = sSQL + "(SELECT D.ITEMNO,D.LOTNO,D.WAFERQTY,D.SHIPQTY,D.FOSBID,M.LOC,M.LOCSTS,M.LOCID,M.STORAGETYP ";
                sSQL = sSQL + "(SELECT D.ITEMNO,D.LOTNO,D.WAFERQTY,D.SHIPQTY,D.FOSBID,M.LOC,M.LOCSTS,M.LOCID,M.STORAGETYP,M.LOC1 ";
                sSQL = sSQL + "FROM LOC_MST M, LOC_DTL D WHERE M.LOC = D.LOC ) L ";
                sSQL = sSQL + "LEFT JOIN SPIL_WMS_LOC S ON L.LOCID = S.ASRS_LOCID ) A ";
                sSQL = sSQL + "WHERE T.RCVNO = A.FOSBID ";
                sSQL = sSQL + "AND T.LOTNO = A.LOTNO ";
                sSQL = sSQL + "AND T.TYPE = 'CYCLE_COUNT' AND T.STATUS = 'A' AND T.SEND_ASRS = 'Y' ";

                if (txtWmsID.Text != "")
                {
                    sSQL = sSQL + "AND T.DOCID = '" + txtWmsID.Text + "' ";
                }

                if (txtFosbID.Text != "")
                {
                    sSQL = sSQL + "AND T.RCVNO = '" + txtFosbID.Text + "' ";
                }
                sSQL = sSQL + "ORDER BY T.DOCID DESC, T.RCVNO ";
                #endregion
            }
            else if (RdBtn_2.Checked == true)
            {
                #region Query 2
                sSQL = "SELECT L.*, S.WMS_LOC FROM  ";
                //sSQL = sSQL + "(SELECT D.ITEMNO,D.LOTNO,D.WAFERQTY,D.SHIPQTY,D.FOSBID,M.LOC,M.LOCSTS,M.LOCID,M.STORAGETYP,M.ROW_X,M.CRANE_NO ";
                sSQL = sSQL + "(SELECT D.ITEMNO,D.LOTNO,D.WAFERQTY,D.SHIPQTY,D.FOSBID,M.LOC,M.LOCSTS,M.LOCID,M.STORAGETYP,M.ROW_X,M.CRANE_NO,M.LOC1 ";
                sSQL = sSQL + "FROM LOC_MST M, LOC_DTL D WHERE M.LOC = D.LOC ) L ";
                sSQL = sSQL + "LEFT JOIN SPIL_WMS_LOC S ON L.LOCID = S.ASRS_LOCID ";
                sSQL = sSQL + "WHERE L.LOCSTS = 'S' ";

                if (txtLoc.Text != "")
                {
                    aWmsLoc = txtLoc.Text.Split(',');
                    sWmsLoc = "";

                    for (i = 0; i <= aWmsLoc.Length - 1; i++)
                    {
                        if (aWmsLoc[i] != "")
                        {
                            if (sWmsLoc == "")
                            {
                                sWmsLoc = "'" + aWmsLoc[i] + "'";
                            }
                            else
                            {
                                sWmsLoc = sWmsLoc + ",'" + aWmsLoc[i] + "'";
                            }
                        }
                    }

                    if (sWmsLoc == "")
                    {
                        return;
                    }
                    sSQL = sSQL + "AND S.WMS_LOC IN (" + sWmsLoc + ") ";

                }
                else
                {
                    #region Other
                    if (cboCrn.Text.Trim() != "")
                    {
                        iCrn = clsTool.INT(cboCrn.Text);

                        sSQL = sSQL + "AND L.CRANE_NO = " + iCrn + " ";
                    }
                    #endregion
                }
                #endregion
            }


            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };

            #region Query Data
            if (clsDB.FunRsSql(sSQL, ref dbRS))
            {
                while (dbRS.Read())
                {
                    tmpGrid1.Rows.Add();
                    tmpGrid1.Rows[tmpGrid1.Rows.Count - 1].HeaderCell.Value = "";

                    if (RdBtn_1.Checked == true)
                    {
                        tmpGrid1[iCol_SEQ_NO, tmpGrid1.Rows.Count - 1].Value = dbRS["SNID"].ToString();
                        tmpGrid1[iCol_DOCTYP, tmpGrid1.Rows.Count - 1].Value = dbRS["DOCTYP"].ToString();
                        tmpGrid1[iCol_DOCID, tmpGrid1.Rows.Count - 1].Value = dbRS["DOCID"].ToString();
                        tmpGrid1[iCol_CreationDate, tmpGrid1.Rows.Count - 1].Value = dbRS["CREATION_DATE"].ToString();

                        tmpGrid1[iCol_FOSBID, tmpGrid1.Rows.Count - 1].Value = dbRS["RCVNO"].ToString();
                        tmpGrid1[iCol_WMSLOC, tmpGrid1.Rows.Count - 1].Value = dbRS["WMS_LOC"].ToString();   //'計算WMS儲位
                        tmpGrid1[iCol_ITEM, tmpGrid1.Rows.Count - 1].Value = dbRS["ITEMNO"].ToString();
                        tmpGrid1[iCol_LotNo, tmpGrid1.Rows.Count - 1].Value = dbRS["LOTNO"].ToString();
                        tmpGrid1[iCol_WaferQty, tmpGrid1.Rows.Count - 1].Value = dbRS["WAFERQTY"].ToString();
                        tmpGrid1[iCol_ShipQty, tmpGrid1.Rows.Count - 1].Value = dbRS["SHIPQTY"].ToString();

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
                            else
                            {
                                sNotes = "該儲位不可進行出庫";
                            }
                        }
                        tmpGrid1[iCol_LocMark, tmpGrid1.Rows.Count - 1].Value = sNotes;   // '儲位備註

                        tmpGrid1[iCol_Loc, tmpGrid1.Rows.Count - 1].Value = dbRS["LOC"].ToString();
                        tmpGrid1[iCol_LocSts, tmpGrid1.Rows.Count - 1].Value = dbRS["LOCSTS"].ToString();
                        tmpGrid1[iCol_LocID, tmpGrid1.Rows.Count - 1].Value = dbRS["LOCID"].ToString();
                        tmpGrid1[iCol_SubLoc, tmpGrid1.Rows.Count - 1].Value = dbRS["LOC1"].ToString();
                    }
                    else
                    {
                        tmpGrid1[iCol_SEQ_NO, tmpGrid1.Rows.Count - 1].Value = "";
                        tmpGrid1[iCol_DOCTYP, tmpGrid1.Rows.Count - 1].Value = "";
                        tmpGrid1[iCol_DOCID, tmpGrid1.Rows.Count - 1].Value = "";
                        tmpGrid1[iCol_CreationDate, tmpGrid1.Rows.Count - 1].Value = "";

                        tmpGrid1[iCol_FOSBID, tmpGrid1.Rows.Count - 1].Value = dbRS["FOSBID"].ToString();
                        tmpGrid1[iCol_WMSLOC, tmpGrid1.Rows.Count - 1].Value = dbRS["WMS_LOC"].ToString();   //'計算WMS儲位
                        tmpGrid1[iCol_ITEM, tmpGrid1.Rows.Count - 1].Value = dbRS["ITEMNO"].ToString();
                        tmpGrid1[iCol_LotNo, tmpGrid1.Rows.Count - 1].Value = dbRS["LOTNO"].ToString();
                        tmpGrid1[iCol_WaferQty, tmpGrid1.Rows.Count - 1].Value = dbRS["WAFERQTY"].ToString();
                        tmpGrid1[iCol_ShipQty, tmpGrid1.Rows.Count - 1].Value = dbRS["SHIPQTY"].ToString();

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
                            else
                            {
                                sNotes = "該儲位不可進行出庫";
                            }
                        }
                        tmpGrid1[iCol_LocMark, tmpGrid1.Rows.Count - 1].Value = sNotes; //'儲位備註

                        tmpGrid1[iCol_Loc, tmpGrid1.Rows.Count - 1].Value = dbRS["LOC"].ToString();
                        tmpGrid1[iCol_LocSts, tmpGrid1.Rows.Count - 1].Value = dbRS["LOCSTS"].ToString();
                        tmpGrid1[iCol_LocID, tmpGrid1.Rows.Count - 1].Value = dbRS["LOCID"].ToString();
                        tmpGrid1[iCol_SubLoc, tmpGrid1.Rows.Count - 1].Value = dbRS["LOC1"].ToString();
                    }
                }
                dbRS.Close();
            }
            #endregion

            clsDB.FunClsDB();


            #region tmpGrid1 to Grid1
            string sLoc = ""; string sLoc1 = "";
            for (i = 0; i <= tmpGrid1.RowCount - 1; i++)
            {
                if (tmpGrid1[iCol_Loc, i].Value.ToString() != "")
                {
                    sLoc = tmpGrid1[iCol_Loc, i].Value.ToString();      //Loc
                    sLoc1 = tmpGrid1[iCol_SubLoc, i].Value.ToString();  //Loc1

                    for (int j = i; j <= tmpGrid1.RowCount - 1; j++)
                    {
                        if (sLoc == tmpGrid1[iCol_Loc, j].Value.ToString())
                        {
                            SubCopyDataGridView(j);
                        }
                    }

                    for (int j = i; j <= tmpGrid1.RowCount - 1; j++)
                    {
                        if (sLoc1 == tmpGrid1[iCol_Loc, j].Value.ToString())
                        {
                            SubCopyDataGridView(j);
                        }
                    }
                }
            }
            #endregion

        }

        private void SubCopyDataGridView(int iRow)
        {
            Grid1.Rows.Add(); Grid1.Rows[Grid1.RowCount - 1].HeaderCell.Value = "";

            //Move to Grid1
            for (int iCol = 0; iCol <= tmpGrid1.ColumnCount - 1; iCol++)
            {
                if (tmpGrid1[iCol, iRow].Value == null)
                {
                    Grid1[iCol, Grid1.RowCount - 1].Value = "";
                }
                else
                {
                    Grid1[iCol, Grid1.RowCount - 1].Value = tmpGrid1[iCol, iRow].Value.ToString();
                }
            }

            //Clear
            for (int iCol = 0; iCol <= tmpGrid1.ColumnCount - 1; iCol++)
            {
                tmpGrid1[iCol, iRow].Value = "";
            }
        }

        private void chkSelAll_CheckedChanged(object sender, EventArgs e)
        {
            int i = 0;

            if (chkSelAll.Checked == true)
            {

                for (i = 0; i <= Grid1.RowCount - 1; i++)
                {
                    if (Grid1[iCol_LocSts, i].Value.ToString() == "S")
                    {
                        clsASRS.SetGridSeletRowColorHead(ref Grid1, i, 1);
                    }
                }
            }
            else
            {
                for (i = 0; i <= Grid1.RowCount - 1; i++)
                {
                    clsASRS.SetGridSeletRowColorHead(ref Grid1, i, 2);
                }
            }
        }

        private void Grid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Grid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex < 0) || (e.ColumnIndex < 0)) { return; }

            int i = 0; string sLoc = ""; string sLocSts = "";
            sLoc = Grid1[iCol_Loc, e.RowIndex].Value.ToString();
            sLocSts = Grid1[iCol_LocSts, e.RowIndex].Value.ToString();

            if (Grid1[iCol_LocSts, e.RowIndex].Value.ToString() != "S")
            {
                clsMSG.ShowWarningMsg("此FOSB(Lot:" + Grid1[iCol_LotNo, e.RowIndex].Value.ToString() + ") 不是庫存儲位,不可以出庫!!");
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
        }

        private void btnExecute_Click(object sender, EventArgs e)
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


            //判斷站號是否正確
            //if (clsASRS.FunChkStnNo(cboStnNo.Text.Trim()) == false) { return; }
            //string[] aStn = new string[0];
            //FunGetStnList(ref aStn);
            //if (aStn.Length <= 0) { clsMSG.ShowWarningMsg(clsMSG.MSG.Msg_Pls_Input_StnNo); return; }
            string sStnNo = "";

            //讀取要出庫的儲位資料
            string[] aLoc = new string[1]; aLoc[0] = "";
            if (clsASRS.FunGetLocList(ref aLoc, ref Grid1, iCol_Loc) == false) { return; }

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

                    //sStnNo = FunGetStnNoByList(sStnNo, aStn);

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
                        aCmdMst.SCAN1 = "Y";
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
                            aCmdMst.SCAN2 = "Y";
                        }
                        aCmdMst.CMDSTS = "0";
                        aCmdMst.PRT = "5";
                        aCmdMst.STNNO = clsASRS.FunGetStnNoByLoc_SPIL_ZX(sLoc1);
                        aCmdMst.IOTYP = clsASRS.gsIOTYPE_Cycle_WMS;
                        aCmdMst.AVAIL = "100";  // 彰化廠
                        aCmdMst.MIXQTY = "1";   // 彰化廠
                        aCmdMst.NEWLOC = "";
                        aCmdMst.PROGID = clsASRS.gsIOTYPE_Cycle_WMS_PID;
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

                    #region 7. WMS
                    if (RdBtn_1.Checked == true)
                    {
                        if (bCmdFlag == true)
                        {
                            if (SubWMS(ref tmpGrid1, sCmdSno[i], aCmdMst.SNO1) == false)
                            {
                                bCmdFlag = false;
                            }

                            if ((bCmdFlag == true) && (sLocOther != ""))
                            {
                                if (SubWMS(ref tmpGrid2, sCmdSno[i], aCmdMst.SNO2) == false)
                                {
                                    bCmdFlag = false;
                                }
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
            //txtCycleNo.Text = clsASRS.FunGetCycleSno(); //取得盤點單號

            clsDB.FunClsDB();
        }

        private bool FunGetLocToTmpGrid(string sGetLoc)
        {
            string sSQL = ""; DbDataReader dbRS = null;

            tmpGrid1.RowCount = 0;

            #region Get Data
            sSQL = "SELECT M.LOCID,M.LOCSTS,M.STORAGETYP,M.MIXQTY,M.AVAIL,D.* FROM LOC_MST M, LOC_DTL D WHERE M.LOC = D.LOC AND M.LOC = '" + sGetLoc + "' ";
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

                    tmpGrid1[iCol_SEQ_NO, tmpGrid1.Rows.Count - 1].Value = "";
                }
                dbRS.Close();
            }
            #endregion

            if (tmpGrid1.RowCount == 0) { return false; }

            #region 判斷要出庫的資料
            string sFosbID_1 = ""; string sType = ""; string sSNID = "";
            for (int i = 0; i <= Grid1.RowCount - 1; i++)
            {
                if (Grid1[iCol_Loc, i].Value.ToString() == sGetLoc)
                {
                    sFosbID_1 = Grid1[iCol_FOSBID, i].Value.ToString();
                    sType = Grid1[iCol_DOCTYP, i].Value.ToString();
                    sSNID = Grid1[iCol_SEQ_NO, i].Value.ToString();

                    for (int j = 0; j <= tmpGrid1.RowCount - 1; j++)
                    {
                        if ((tmpGrid1[iCol_Loc, j].Value.ToString() == sGetLoc) &&
                            (tmpGrid1[iCol_FOSBID, j].Value.ToString() == sFosbID_1))
                        {
                            tmpGrid1.Rows[j].HeaderCell.Value = "*";

                            tmpGrid1[iCol_DOCTYP, j].Value = sType;
                            tmpGrid1[iCol_SEQ_NO, j].Value = sSNID;

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

                    tmpGrid2[iCol_SEQ_NO, tmpGrid1.Rows.Count - 1].Value = "";

                }
                dbRS.Close();
            }
            #endregion

            if (tmpGrid2.RowCount == 0) { return false; }

            #region 判斷要出庫的資料
            string sFosbID_1 = ""; string sType = ""; string sSNID = "";
            for (int i = 0; i <= Grid1.RowCount - 1; i++)
            {
                if (Grid1[iCol_Loc, i].Value.ToString() == sGetLoc)
                {
                    sFosbID_1 = Grid1[iCol_FOSBID, i].Value.ToString();
                    sType = Grid1[iCol_DOCTYP, i].Value.ToString();
                    sSNID = Grid1[iCol_SEQ_NO, i].Value.ToString();

                    for (int j = 0; j <= tmpGrid2.RowCount - 1; j++)
                    {
                        if ((tmpGrid2[iCol_Loc, j].Value.ToString() == sGetLoc) &&
                            (tmpGrid2[iCol_FOSBID, j].Value.ToString() == sFosbID_1))
                        {
                            tmpGrid2.Rows[j].HeaderCell.Value = "*";

                            tmpGrid2[iCol_DOCTYP, j].Value = sType;
                            tmpGrid2[iCol_SEQ_NO, j].Value = sSNID;

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

                aCmdDtl.OFFACTQTY = 0;
                aCmdDtl.WAFERACTQTY = 0;
                aCmdDtl.SHIPACTQTY = 0;

                aCmdDtl.FLAGQTY = clsASRS.gsFlagQty_Limit;  // X:禁止出貨

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
                aCmdDtl.CYCLENO = objGridTmp[iCol_SEQ_NO, j].Value.ToString();       //'WMS
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


        private bool SubWMS(ref DataGridView objGridTmp, string sCmdSno, string sSno)
        {
            int j = 0; int y = 0;
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
                    if (objGridTmp.Rows[j].HeaderCell.Value.ToString() == "*")
                    {
                        sSQL = "UPDATE TB_ASRS_TO_WMS_TEMP SET SEND_ASRS = 'A', ";
                        sSQL = sSQL + "USER_NAME = '" + clsParam.gsDB_User + "', ";
                        sSQL = sSQL + "TXN_DATE = '" + clsTool.GetDateTimeForWMS() + "' ";
                        sSQL = sSQL + "WHERE RCVNO = '" + objGridTmp[iCol_FOSBID, j].Value.ToString() + "' ";
                        sSQL = sSQL + "AND STATUS = 'A' AND SEND_ASRS = 'Y' ";
                        sSQL = sSQL + "AND TYPE = 'CYCLE_COUNT' ";
                        if (clsDB.FunExecSql(sSQL) == false)
                        {
                            //return false;
                        }
                    }
                }


            }
            return true;
        }

        private void btnWmsLoc_Click(object sender, EventArgs e)
        {
            if (RdBtn_2.Checked == false) { return; }
            string sCrn = cboCrn.Text;

            clsASRS.gsHelpStyle = "WMS_CRANE";
            clsASRS.gsHelpStyle_MLoc = sCrn;
            Array.Resize<string>(ref clsASRS.gsHelpRtnData, 0);

            frmHelp frmHelp = new frmHelp();
            frmHelp.ShowDialog();

            if (clsASRS.gsHelpRtnData[0] != "")
            {
                if (txtLoc.Text == "")
                {
                    txtLoc.Text =  clsASRS.gsHelpRtnData[0] ;
                }
                else
                {
                    txtLoc.Text = txtLoc.Text + "," + clsASRS.gsHelpRtnData[0] + "";
                }
            }
        }




    }
}
