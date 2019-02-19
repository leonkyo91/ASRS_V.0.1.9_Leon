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
    public partial class frm_CYCLE_REPORT2 : Form
    {

        #region Grid Parameter
        int iCol_CycleNo = 0;            //盤點單號
        int iCol_Status = 1;            //盤點狀態
        int iCol_Result = 2;            //盤點結果
        int iCol_Creater = 3;           //建立人員

        int iCol_Loc = 4;               //儲位
        int iCol_LocID = 5;             //料盤ID
        int iCol_SubLoc = 6;            //L/R
        int iCol_Item = 7;              //ITEM
        int iCol_Customer = 8;          //客戶簡稱
        int iCol_Dev = 9;               //DEVICE
        int iCol_LotNo = 10;            //Lot No
        int iCol_OffQty = 11;           //件數
        int iCol_WaferQty = 12;         //枚數
        int iCol_ShipQty = 13;          //數量

        int iCol_User_Cyc = 14;         //盤點人員
        int iCol_Date_CYC = 15;         //盤點時間
        int iCol_CYCOffQty = 16;        //盤點調帳件數
        int iCol_CYCWaferQty = 17;      //盤點實物枚數
        int iCol_CYCShipQty = 18;       //盤點實物數量

        int iCol_User_CHK = 19;         //調帳人員
        int iCol_Date_CHECK = 20;       //調帳時間
        int iCol_CHKOffQty = 21;        //調帳實物枚數
        int iCol_CHKWaferQty = 22;      //調帳實物枚數
        int iCol_CHKShipQty = 23;       //調帳實物數量
        int iCol_Counts = 24;


        int iCol1_Customer = 0;     //客戶簡稱
        int iCol1_LotNo = 1;        //批號
        int iCol1_FOSBID = 2;       //FOSB ID
        int iCol1_Cnt = 3;          //次數
        int iCol1_OK = 4;           //符合
        int iCol1_NG = 5;           //不符合
        int iCol1_Counts = 6;       //
        #endregion

        public frm_CYCLE_REPORT2()
        {
            InitializeComponent();
        }

        private void frm_CYCLE_REPORT2_Load(object sender, EventArgs e)
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
            oGrid.ColumnCount = iCol_Counts;
            oGrid.RowCount = 1;

            oGrid.Columns[iCol_CycleNo].Width = 80; oGrid.Columns[iCol_CycleNo].Name = "盤點單號";
            oGrid.Columns[iCol_Status].Width = 80; oGrid.Columns[iCol_Status].Name = "盤點狀態";
            oGrid.Columns[iCol_Result].Width = 80; oGrid.Columns[iCol_Result].Name = "盤點結果";
            oGrid.Columns[iCol_Creater].Width = 70; oGrid.Columns[iCol_Creater].Name = "建立人員";
            oGrid.Columns[iCol_Loc].Width = 45; oGrid.Columns[iCol_Loc].Name = "儲位";
            oGrid.Columns[iCol_LocID].Width = 60; oGrid.Columns[iCol_LocID].Name = "料盤ID";
            oGrid.Columns[iCol_SubLoc].Width = 45; oGrid.Columns[iCol_SubLoc].Name = "L/R"; oGrid.Columns[iCol_SubLoc].Visible = false;
            oGrid.Columns[iCol_Item].Width = 80; oGrid.Columns[iCol_Item].Name = "ITEM No";
            oGrid.Columns[iCol_Customer].Width = 80; oGrid.Columns[iCol_Customer].Name = "客戶簡稱";
            oGrid.Columns[iCol_Dev].Width = 80; oGrid.Columns[iCol_Dev].Name = "DEVICE";
            oGrid.Columns[iCol_LotNo].Width = 80; oGrid.Columns[iCol_LotNo].Name = "LOT NO";
            oGrid.Columns[iCol_OffQty].Width = 45; oGrid.Columns[iCol_OffQty].Name = "件數";
            oGrid.Columns[iCol_WaferQty].Width = 45; oGrid.Columns[iCol_WaferQty].Name = "枚數";
            oGrid.Columns[iCol_ShipQty].Width = 45; oGrid.Columns[iCol_ShipQty].Name = "數量";
            oGrid.Columns[iCol_User_Cyc].Width = 80; oGrid.Columns[iCol_User_Cyc].Name = "盤點人員";
            oGrid.Columns[iCol_Date_CYC].Width = 100; oGrid.Columns[iCol_Date_CYC].Name = "盤點時間";
            oGrid.Columns[iCol_CYCOffQty].Width = 80; oGrid.Columns[iCol_CYCOffQty].Name = "實物件數";
            oGrid.Columns[iCol_CYCWaferQty].Width = 80; oGrid.Columns[iCol_CYCWaferQty].Name = "實物枚數";
            oGrid.Columns[iCol_CYCShipQty].Width = 80; oGrid.Columns[iCol_CYCShipQty].Name = "實物數量";

            oGrid.Columns[iCol_User_CHK].Width = 80; oGrid.Columns[iCol_User_CHK].Name = "調帳人員"; oGrid.Columns[iCol_User_CHK].Visible = false;
            oGrid.Columns[iCol_Date_CHECK].Width = 80; oGrid.Columns[iCol_Date_CHECK].Name = "調帳時間"; oGrid.Columns[iCol_Date_CHECK].Visible = false;
            oGrid.Columns[iCol_CHKOffQty].Width = 80; oGrid.Columns[iCol_CHKOffQty].Name = "調帳實物件數"; oGrid.Columns[iCol_CHKOffQty].Visible = false;
            oGrid.Columns[iCol_CHKWaferQty].Width = 80; oGrid.Columns[iCol_CHKWaferQty].Name = "調帳實物枚量"; oGrid.Columns[iCol_CHKWaferQty].Visible = false;
            oGrid.Columns[iCol_CHKShipQty].Width = 80; oGrid.Columns[iCol_CHKShipQty].Name = "調帳實物數量"; oGrid.Columns[iCol_CHKShipQty].Visible = false;

            int i = 0;
            for (i = 0; i <= oGrid.ColumnCount - 1; i++)
            {
                oGrid.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            oGrid.RowCount = 0;
        }

        private void GridSetRange2(ref DataGridView oGrid)
        {
            int i = 0;
            //With oGrid
            oGrid.ColumnCount = iCol1_Counts;
            oGrid.RowCount = 1;

            oGrid.Columns[iCol1_Customer].Width = 100; oGrid.Columns[iCol1_Customer].Name = "客戶簡稱";
            oGrid.Columns[iCol1_LotNo].Width = 120; oGrid.Columns[iCol1_LotNo].Name = "批號";
            oGrid.Columns[iCol1_FOSBID].Width = 100; oGrid.Columns[iCol1_FOSBID].Name = "FOSB ID";
            oGrid.Columns[iCol1_Cnt].Width = 70; oGrid.Columns[iCol1_Cnt].Name = "次數";
            oGrid.Columns[iCol1_OK].Width = 100; oGrid.Columns[iCol1_OK].Name = "符合次數";
            oGrid.Columns[iCol1_NG].Width = 100; oGrid.Columns[iCol1_NG].Name = "不符合次數";


            for (i = 0; i <= oGrid.ColumnCount - 1; i++)
            {
                oGrid.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            oGrid.RowCount = 0;
        }

        private void FormInit()
        {

        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            SubFormCls();
        }

        private void SubFormCls()
        {
            txtLotNoCount.Text = "";
            Grid1.RowCount = 0;
            Grid2.RowCount = 0;

            txtLotNoF.Text = ""; txtLotNoT.Text = "";
            txtItemNoF.Text = ""; txtItemNoT.Text = "";
            txtDeviceF.Text = ""; txtDeviceT.Text = "";
            chkTREANSACTION_DATE2.Checked = false;
        }

        private void cmdQuery_Click(object sender, EventArgs e)
        {
            SubQuery();
        }

        private void SubQuery()
        {
            string sSQL = ""; string sSQL_tmp = ""; DbDataReader oRS = null;
            int i = 0;
            Grid2.RowCount = 0;
            Grid1.RowCount = 0;


            if (txtItemNoF.Text != "")
            {
                if (txtItemNoT.Text != "")
                {
                    sSQL_tmp = sSQL_tmp + "AND ITEMNO >= '" + txtItemNoF.Text + "' AND ITEMNO <= '" + txtItemNoT.Text + "' ";
                }
                else
                {
                    sSQL_tmp = sSQL_tmp + "AND ITEMNO = '" + txtItemNoF.Text + "' ";
                }
            }
            if (txtLotNoF.Text != "")
            {
                if (txtLotNoT.Text != "")
                {
                    sSQL_tmp = sSQL_tmp + "AND LOTNO >= '" + txtLotNoF.Text + "' AND LOTNO <= '" + txtLotNoT.Text + "' ";
                }
                    else
                {
                    sSQL_tmp = sSQL_tmp + "AND LOTNO = '" + txtLotNoF.Text + "' ";
                }
            }
            if (txtDeviceF.Text != "")
            {
                if (txtDeviceT.Text != "")
                {
                    sSQL_tmp = sSQL_tmp + "AND DEVICE >= '" + txtDeviceF.Text + "' AND DEVICE <= '" + txtDeviceT.Text + "' ";
                }
                else
                {
                    sSQL_tmp = sSQL_tmp + "AND DEVICE = '" + txtDeviceF.Text + "' ";
                }
            }
            if (chkTREANSACTION_DATE2.Checked == true)
            {
                sSQL_tmp = sSQL_tmp + " AND TRANSACTION_DATE >= '" + dtpDateF.Value.ToString("yyyy/MM/dd") + " 00:00:00";
                sSQL_tmp = sSQL_tmp + " AND TRANSACTION_DATE <= '" + dtpDateT.Value.ToString("yyyy/MM/dd") + " 99:99:99";
            }

            if (sSQL_tmp == "")
            {
                clsMSG.ShowInformationMsg("請選擇查詢條件");
                return;
            }


            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };


            sSQL = "SELECT CUSTOMER, LOTNO, FOSBID, COUNT(LOTNO) AS RESULT_CNT FROM CYCLE ";
            sSQL = sSQL + "WHERE CYC_STATUS = '2' ";     //'己盤點過
            sSQL = sSQL + sSQL_tmp + "GROUP BY CUSTOMER,LOTNO,FOSBID ORDER BY LOTNO,FOSBID ";

            if (clsDB.FunRsSql(sSQL, ref oRS))
            {
                while (oRS.Read())
                {
                    Grid2.Rows.Add();
                    Grid2[iCol1_Customer, Grid2.Rows.Count - 1].Value = oRS["CUSTOMER"].ToString();
                    Grid2[iCol1_LotNo, Grid2.Rows.Count - 1].Value = oRS["LOTNO"].ToString();
                    Grid2[iCol1_FOSBID, Grid2.Rows.Count - 1].Value = oRS["FOSBID"].ToString();
                    Grid2[iCol1_Cnt, Grid2.Rows.Count - 1].Value = oRS["RESULT_CNT"].ToString();
                    Grid2[iCol1_OK, Grid2.Rows.Count - 1].Value = 0;
                    Grid2[iCol1_NG, Grid2.Rows.Count - 1].Value = 0;
                }
                oRS.Close();
            }
            else
            {
                clsMSG.ShowInformationMsg("查無資料");
                clsDB.FunClsDB();
                return;
            }
            
            sSQL = "SELECT CUSTOMER, LOTNO, FOSBID, COUNT(LOTNO) AS RESULT_CNT FROM CYCLE ";
            sSQL = sSQL + "WHERE CYC_STATUS = '2' ";     //'己盤點過
            sSQL = sSQL + "AND CYC_RESULT = '0' ";       //'盤點結果為相符
            sSQL = sSQL + sSQL_tmp + "GROUP BY CUSTOMER,LOTNO,FOSBID ORDER BY LOTNO,FOSBID ";
            if (clsDB.FunRsSql(sSQL, ref oRS))
            {
                while (oRS.Read())
                {
                    for (i = 0; i <= Grid2.RowCount - 1; i++)
                    {
                        if ((Grid2[iCol1_LotNo, i].Value.ToString() == oRS["LOTNO"].ToString()) &&
                            (Grid2[iCol1_FOSBID, i].Value.ToString() == oRS["FOSBID"].ToString()) &&
                            (Grid2[iCol1_Customer, i].Value.ToString() == oRS["CUSTOMER"].ToString()))
                        {
                            Grid2[iCol1_OK, i].Value = oRS["RESULT_CNT"].ToString();
                            break;                        
                        }
                    }
                }
                oRS.Close();
            }

            sSQL = "SELECT CUSTOMER, LOTNO, FOSBID, COUNT(LOTNO) AS RESULT_CNT FROM CYCLE ";
            sSQL = sSQL + "WHERE CYC_STATUS = '2' ";     //'己盤點過
            sSQL = sSQL + "AND CYC_RESULT <> '0' ";
            sSQL = sSQL + sSQL_tmp + "GROUP BY CUSTOMER,LOTNO,FOSBID ORDER BY LOTNO,FOSBID ";
            if (clsDB.FunRsSql(sSQL, ref oRS))
            {
                while (oRS.Read())
                {
                    for (i = 0; i <= Grid2.RowCount - 1; i++)
                    {
                        if ((Grid2[iCol1_LotNo, i].Value.ToString() == oRS["LOTNO"].ToString()) &&
                            (Grid2[iCol1_FOSBID, i].Value.ToString() == oRS["FOSBID"].ToString()) &&
                            (Grid2[iCol1_Customer, i].Value.ToString() == oRS["CUSTOMER"].ToString()))
                        {
                            Grid2[iCol1_NG, i].Value = oRS["RESULT_CNT"].ToString();
                            break;  
                        }
                    }
                }
                oRS.Close();
            }

            clsDB.FunClsDB();

        }


        private string FunCodeTypeValue(string sStyle, string sValue)
        {
            string sData = sValue;

            switch (sStyle)
            {
                case "CYC_STATUS":   //'盤點狀態
                    switch (sValue)
                    {
                        case "1": sData = "1:未盤點"; break;
                        case "2": sData = "2:己盤點"; break;
                    }
                    break;
                case "CYC_RESULT":   //'盤點結果
                    switch (sValue)
                    {
                        case "0": sData = "0:相符"; break;
                        case "1": sData = "1:枚數不符"; break;
                        case "2": sData = "2:數量不符"; break;
                        case "3": sData = "3:與實物不符"; break;
                        case "4": sData = "4:其它"; break;
                    }
                    break;
            }
            return sData;
        }

        private void Grid2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Grid2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex < 0) || (e.ColumnIndex < 0)) { return; }
            
            SubQuery2();
        }

        private void SubQuery2()
        {
            string sSQL = ""; DbDataReader oRS = null;

            Grid1.RowCount = 0;

            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };

            sSQL = "SELECT * FROM CYCLE ";
            sSQL = sSQL + "WHERE LOTNO = '" + Grid2[iCol1_LotNo, Grid2.CurrentRow.Index].Value.ToString() + "' ";
            sSQL = sSQL + "AND FOSBID = '" + Grid2[iCol1_FOSBID, Grid2.CurrentRow.Index].Value.ToString() + "' ";

            if (clsDB.FunRsSql(sSQL, ref oRS))
            {
                while (oRS.Read())
                {
                    Grid1.Rows.Add();

                    Grid1[iCol_CycleNo, Grid1.Rows.Count - 1].Value = oRS["CYCLENO"].ToString();
                    Grid1[iCol_Status, Grid1.Rows.Count - 1].Value = FunCodeTypeValue("CYC_STATUS", oRS["CYC_STATUS"].ToString());
                    Grid1[iCol_Result, Grid1.Rows.Count - 1].Value = FunCodeTypeValue("CYC_RESULT", oRS["CYC_RESULT"].ToString());
                    Grid1[iCol_Creater, Grid1.Rows.Count - 1].Value = oRS["USER_CREAT"].ToString();
                    Grid1[iCol_Loc, Grid1.Rows.Count - 1].Value = oRS["LOC"].ToString();
                    Grid1[iCol_LocID, Grid1.Rows.Count - 1].Value = oRS["LOCID"].ToString();
                    //Grid1[iCol_SubLoc, Grid1.Rows.Count - 1].Value = oRS["SUBLOC"].ToString();
                    Grid1[iCol_Item, Grid1.Rows.Count - 1].Value = oRS["ITEMNO"].ToString();
                    Grid1[iCol_Customer, Grid1.Rows.Count - 1].Value = oRS["CUSTOMER"].ToString();
                    Grid1[iCol_Dev, Grid1.Rows.Count - 1].Value = oRS["DEVICE"].ToString();
                    Grid1[iCol_LotNo, Grid1.Rows.Count - 1].Value = oRS["LOTNO"].ToString();
                    Grid1[iCol_OffQty, Grid1.Rows.Count - 1].Value = oRS["OFFQTY"].ToString();
                    Grid1[iCol_WaferQty, Grid1.Rows.Count - 1].Value = oRS["WAFERQTY"].ToString();
                    Grid1[iCol_ShipQty, Grid1.Rows.Count - 1].Value = oRS["SHIPQTY"].ToString();

                    Grid1[iCol_User_Cyc, Grid1.Rows.Count - 1].Value = oRS["USER_CYC"].ToString();
                    Grid1[iCol_Date_CYC, Grid1.Rows.Count - 1].Value = oRS["DATE_CYCLE"].ToString();
                    Grid1[iCol_CYCOffQty, Grid1.Rows.Count - 1].Value = oRS["CYCOFFQTY"].ToString();
                    Grid1[iCol_CYCWaferQty, Grid1.Rows.Count - 1].Value = oRS["CYCWAFERQTY"].ToString();
                    Grid1[iCol_CYCShipQty, Grid1.Rows.Count - 1].Value = oRS["CYCSHIPQTY"].ToString();

                    Grid1[iCol_User_CHK, Grid1.Rows.Count - 1].Value = oRS["USER_CHK"].ToString();
                    Grid1[iCol_Date_CHECK, Grid1.Rows.Count - 1].Value = oRS["DATE_CHECK"].ToString();
                    Grid1[iCol_CHKOffQty, Grid1.Rows.Count - 1].Value = oRS["CHKOFFQTY"].ToString();
                    Grid1[iCol_CHKWaferQty, Grid1.Rows.Count - 1].Value = oRS["CHKWAFERQTY"].ToString();
                    Grid1[iCol_CHKShipQty, Grid1.Rows.Count - 1].Value = oRS["CHKSHIPQTY"].ToString();
                }
                oRS.Close();
            }
            else
            {
                clsMSG.ShowInformationMsg("查無資料");
            }

            txtLotNoCount.Text = clsASRS.FunGetFosbCnt(ref Grid1, iCol_LotNo).ToString();

            clsDB.FunClsDB();
        }

        private void cmdExport_Click(object sender, EventArgs e)
        {
            clsTool.funGridToCsv(Grid1);
        }

        private void cmdExport2_Click(object sender, EventArgs e)
        {
            clsTool.funGridToCsv(Grid1);
        }

        private void btnHelp_LotNo1_Click(object sender, EventArgs e)
        {
            clsASRS.gsHelpStyle = "LOTNO";
            Array.Resize<string>(ref clsASRS.gsHelpRtnData, 1);

            frmHelp frmHelp = new frmHelp();
            frmHelp.ShowDialog();

            txtLotNoF.Text = clsASRS.gsHelpRtnData[0];
        }

        private void btnHelp_LotNo2_Click(object sender, EventArgs e)
        {
            clsASRS.gsHelpStyle = "LOTNO";
            Array.Resize<string>(ref clsASRS.gsHelpRtnData, 1);

            frmHelp frmHelp = new frmHelp();
            frmHelp.ShowDialog();

            txtLotNoT.Text = clsASRS.gsHelpRtnData[0];
        }

        private void btnHelp_Item1_Click(object sender, EventArgs e)
        {
            clsASRS.gsHelpStyle = "ITEM";
            Array.Resize<string>(ref clsASRS.gsHelpRtnData, 1);

            frmHelp frmHelp = new frmHelp();
            frmHelp.ShowDialog();

            txtItemNoF.Text = clsASRS.gsHelpRtnData[0];
        }

        private void btnHelp_Item2_Click(object sender, EventArgs e)
        {
            clsASRS.gsHelpStyle = "ITEM";
            Array.Resize<string>(ref clsASRS.gsHelpRtnData, 1);

            frmHelp frmHelp = new frmHelp();
            frmHelp.ShowDialog();

            txtItemNoT.Text = clsASRS.gsHelpRtnData[0];
        }

        private void btnHelp_Device1_Click(object sender, EventArgs e)
        {
            clsASRS.gsHelpStyle = "DEVICE";
            Array.Resize<string>(ref clsASRS.gsHelpRtnData, 1);

            frmHelp frmHelp = new frmHelp();
            frmHelp.ShowDialog();

            txtDeviceF.Text = clsASRS.gsHelpRtnData[0];
        }

        private void btnHelp_Device2_Click(object sender, EventArgs e)
        {
            clsASRS.gsHelpStyle = "DEVICE";
            Array.Resize<string>(ref clsASRS.gsHelpRtnData, 1);

            frmHelp frmHelp = new frmHelp();
            frmHelp.ShowDialog();

            txtDeviceT.Text = clsASRS.gsHelpRtnData[0];
        }

        

    }
}
