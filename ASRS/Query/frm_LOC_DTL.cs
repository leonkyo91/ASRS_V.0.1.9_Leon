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
    public partial class frm_LOC_DTL : Form
    {
        #region Grid1 Parameter
        int iCol_LOC = 0;
        int iCol_LOCSTS = 1;
        int iCol_LOCID = 2;
        int iCol_FOSBID = 3;
        int iCol_ITEMNO = 4;
        int iCol_CUSTOMER = 5;
        int iCol_DEVICE = 6;
        int iCol_LOTNO = 7;
        int iCol_OFFQTY = 8;
        int iCol_WAFERQTY = 9;
        int iCol_SHIPQTY = 10;
        int iCol_CHKIQC = 11;

        int iCol_GIB_CUSTOMER = 12;
        int iCol_REL_DATE = 13;

        int iCol_INDATE = 14;
        int iCol_TRNDATE = 15;
        int iCol_Counts = 16;
        #endregion

        public frm_LOC_DTL()
        {
            InitializeComponent();
        }

        private void frm_LOC_DTL_Load(object sender, EventArgs e)
        {
            GridInit();
        }

        private void GridInit()
        {
            GridSysInit(ref Grid1); GridSetRange1(ref Grid1);
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

        private void GridSetRange1(ref DataGridView oGrid)
        {
            oGrid.ColumnCount = iCol_Counts;
            oGrid.RowCount = 1;

            oGrid.Columns[iCol_LOC].Width = 80; oGrid.Columns[iCol_LOC].Name = "儲位編號";
            oGrid.Columns[iCol_LOCSTS].Width = 80; oGrid.Columns[iCol_LOCSTS].Name = "儲位狀態";
            oGrid.Columns[iCol_LOCID].Width = 80; oGrid.Columns[iCol_LOCID].Name = "料盒編號";
            oGrid.Columns[iCol_FOSBID].Width = 90; oGrid.Columns[iCol_FOSBID].Name = "FOSB ID";
            oGrid.Columns[iCol_ITEMNO].Width = 80; oGrid.Columns[iCol_ITEMNO].Name = "ITEM NO";
            oGrid.Columns[iCol_CUSTOMER].Width = 80; oGrid.Columns[iCol_CUSTOMER].Name = "客戶簡稱";
            oGrid.Columns[iCol_DEVICE].Width = 100; oGrid.Columns[iCol_DEVICE].Name = "DEVICE";
            oGrid.Columns[iCol_LOTNO].Width = 100; oGrid.Columns[iCol_LOTNO].Name = "Lot No";
            oGrid.Columns[iCol_OFFQTY].Width = 70; oGrid.Columns[iCol_OFFQTY].Name = "件數";
            oGrid.Columns[iCol_WAFERQTY].Width = 70; oGrid.Columns[iCol_WAFERQTY].Name = "枚數";
            oGrid.Columns[iCol_SHIPQTY].Width = 70; oGrid.Columns[iCol_SHIPQTY].Name = "數量";
            oGrid.Columns[iCol_CHKIQC].Width = 70; oGrid.Columns[iCol_CHKIQC].Name = "檢驗";

            oGrid.Columns[iCol_GIB_CUSTOMER].Width = 120; oGrid.Columns[iCol_GIB_CUSTOMER].Name = "Customer Group";
            oGrid.Columns[iCol_REL_DATE].Width = 130; oGrid.Columns[iCol_REL_DATE].Name = "晶圓入廠日期";

            oGrid.Columns[iCol_INDATE].Width = 120; oGrid.Columns[iCol_INDATE].Name = "入庫日期";
            oGrid.Columns[iCol_TRNDATE].Width = 120; oGrid.Columns[iCol_TRNDATE].Name = "異動日期";


            oGrid.RowCount = 0;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            FillText();
            Query();
        }
        
        private void FillText()
        {
            foreach (object obj in GroupBox2.Controls)
            {   
                if (obj.GetType() == typeof(TextBox) && ((TextBox)obj).Text == "")
                {
                    switch (((TextBox)obj).Name)
                    {
                        case "txtLoc2":
                            txtLoc2.Text = txtLoc1.Text;
                            break;
                        case "txtLocID2":
                            txtLocID2.Text = txtLocID1.Text;
                            break;
                        case "txtItemNo2":
                            txtItemNo2.Text = txtItemNo1.Text;
                            break;
                        case "txtLotNo2":
                            txtLotNo2.Text = txtLotNo1.Text;
                            break;
                        case "txtFosbID2":       
                            txtFosbID2.Text = txtFosbID1.Text;
                            break;
                        case"txtDevice2":
                            txtDevice2.Text = txtDevice1.Text;
                            break;
                    }
                }
            }
        }
        private void Query()
        {

            txtLotNoCount.Text = "";
            Grid1.RowCount = 0;

            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };

            Grid1.RowCount = 0;

            string strSql = "select * from loc_mst m left join loc_dtl d on m.loc=d.loc ";
            #region 產生DB條件字串
            string strCondition = " where ";

            for (int i = 0; i != GroupBox2.Controls.Count; i++)
            {
                if (GroupBox2.Controls[i].GetType() == typeof(TextBox) && GroupBox2.Controls[i].Text != "")
                {
                    TextBox tb = (TextBox)GroupBox2.Controls[i];
                    switch (tb.Name)
                    {
                        case "txtLoc1":
                            strCondition += (strCondition.Trim() == "where" ? "" : " and ") + "m.loc>='" + tb.Text + "' ";
                            break;
                        case "txtLoc2":
                            strCondition += (strCondition.Trim() == "where" ? "" : " and ") + "m.loc<='" + tb.Text + "' ";
                            break;
                        case "txtLocID1":
                            strCondition += (strCondition.Trim() == "where" ? "" : " and ") + "m.locid >='" + tb.Text + "' ";
                            break;
                        case "txtLocID2":
                            strCondition += (strCondition.Trim() == "where" ? "" : " and ") + "m.locid <='" + tb.Text + "' ";
                            break;
                        case "txtItemNo1":
                            strCondition += (strCondition.Trim() == "where" ? "" : " and ") + "d.itemno>='" + tb.Text + "' ";
                            break;
                        case "txtItemNo2":
                            strCondition += (strCondition.Trim() == "where" ? "" : " and ") + "d.itemno<='" + tb.Text + "' ";
                            break;
                        case "txtLotNo1":
                            strCondition += (strCondition.Trim() == "where" ? "" : " and ") + "d.lotno>='" + tb.Text + "' ";
                            break;
                        case "txtLotNo2":
                            strCondition += (strCondition.Trim() == "where" ? "" : " and ") + "d.lotno<='" + tb.Text + "' ";
                            break;
                        case "txtFosbID1":
                            strCondition += (strCondition.Trim() == "where" ? "" : " and ") + "d.fosbid>='" + tb.Text + "' ";
                            break;
                        case "txtFosbID2":
                            strCondition += (strCondition.Trim() == "where" ? "" : " and ") + "d.fosbid<='" + tb.Text + "' ";
                            break;
                        case "txtDevice1":
                            strCondition += (strCondition.Trim() == "where" ? "" : " and ") + "d.device>='" + tb.Text + "' ";
                            break;
                        case "txtDevice2":
                            strCondition += (strCondition.Trim() == "where" ? "" : " and ") + "d.device<='" + tb.Text + "' ";
                            break;

                    }
                }
            }
            #endregion
            if (chkTREANSACTION_DATE1.Checked)
            {
                if (txtTransDate1.Text != "")
                    strCondition += (strCondition.Trim() == "where" ? "" : " and ") + "d.TRANSACTION_DATE>='" + txtTransDate1.Text + " 00:00:00' ";
                if (txtTransDate2.Text != "")
                    strCondition += (strCondition.Trim() == "where" ? "" : " and ") + "d.TRANSACTION_DATE<='" + txtTransDate2.Text + " 99:99:99' ";
            }

            if (strCondition.Trim() == "where")
            {
                //strSql += " where m.locsts not in ('N') ";
            }
            else
            {
                strSql += strCondition;
                //strSql += " and m.locsts not in ('N') ";
            }


            DbDataReader dbRs = null;

            if (clsDB.FunRsSql(strSql, ref dbRs))
            {

                int x = 0;
                while (dbRs.Read())
                {
                    Grid1.Rows.Add();
                    Grid1[iCol_LOC, x].Value = dbRs["loc"].ToString();
                    Grid1[iCol_LOCSTS, x].Value = dbRs["locsts"].ToString();
                    Grid1[iCol_LOCID, x].Value = dbRs["locid"].ToString();
                    Grid1[iCol_FOSBID, x].Value = dbRs["FOSBID"].ToString();
                    Grid1[iCol_ITEMNO, x].Value = dbRs["Itemno"].ToString();
                    Grid1[iCol_CUSTOMER, x].Value = dbRs["customer"].ToString();
                    Grid1[iCol_DEVICE, x].Value = dbRs["device"].ToString();
                    Grid1[iCol_LOTNO, x].Value = dbRs["lotno"].ToString();
                    Grid1[iCol_OFFQTY, x].Value = dbRs["offqty"].ToString();
                    Grid1[iCol_WAFERQTY, x].Value = dbRs["waferqty"].ToString();
                    Grid1[iCol_SHIPQTY, x].Value = dbRs["ShipQty"].ToString();
                    Grid1[iCol_CHKIQC, x].Value = dbRs["chkiqc"].ToString();

                    Grid1[iCol_GIB_CUSTOMER, x].Value = dbRs["GIB_CUSTOMER"].ToString();
                    Grid1[iCol_REL_DATE, x].Value = dbRs["REL_DATE"].ToString();

                    Grid1[iCol_INDATE, x].Value = dbRs["indate"].ToString();
                    x++;
                }
                dbRs.Close();


                #region 抓取批數
                //string sql = "select count( distinct FOSBID) cnt from loc_mst m left join loc_dtl d on m.loc=d.loc ";

                //DbDataReader dbrs1 = null;
                //if (strCondition.Trim() == "where")
                //{

                //}
                //else
                //{
                //    sql += strCondition;
                //}
                //if (!clsDB.FunRsSql(sql, ref dbrs1))
                //{
                //    throw new Exception("查詢失敗或查無資料!");
                //}
                //dbrs1.Read();
                //txtLotNoCount.Text = dbrs1["cnt"].ToString();

                txtLotNoCount.Text = clsASRS.FunGetFosbCnt(ref Grid1, iCol_FOSBID).ToString();

                #endregion

                
                clsDB.FunClsDB();
            }


        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCls_Click(object sender, EventArgs e)
        {
            //clsTool.finished(this);
            FormCls();
            Grid1.RowCount = 0;
        }

        private void FormCls()
        {
            txtLoc1.Text = ""; txtLoc2.Text = "";
            txtItemNo1.Text = "";txtItemNo2.Text = "";
            txtLocID1.Text = ""; txtLocID2.Text = "";
            txtDevice1.Text = ""; txtDevice2.Text = "";
            txtFosbID1.Text = ""; txtFosbID2.Text = "";
            txtLotNo1.Text = ""; txtLotNo2.Text = "";
            txtLotNoCount.Text = "";
            chkTREANSACTION_DATE1.Checked = false;
        }

        private void cmdExport_Click(object sender, EventArgs e)
        {
            clsTool.funGridToCsv(Grid1);
        }

        private void btnHelp_Item1_Click(object sender, EventArgs e)
        {
            //clsTool.showForm(txtItemNo1, "ITEMNO", "LOC_DTL");
            clsASRS.gsHelpStyle = "ITEM";
            Array.Resize<string>(ref clsASRS.gsHelpRtnData, 1);

            frmHelp frmHelp = new frmHelp();
            frmHelp.ShowDialog();

            txtItemNo1.Text = clsASRS.gsHelpRtnData[0];
        }

        private void btnHelp_Item2_Click(object sender, EventArgs e)
        {
            //clsTool.showForm(txtItemNo2, "ITEMNO", "LOC_DTL");
            clsASRS.gsHelpStyle = "ITEM";
            Array.Resize<string>(ref clsASRS.gsHelpRtnData, 1);

            frmHelp frmHelp = new frmHelp();
            frmHelp.ShowDialog();

            txtItemNo2.Text = clsASRS.gsHelpRtnData[0];
        }

        private void btnHelp_LotNo1_Click(object sender, EventArgs e)
        {
            //clsTool.showForm(txtLotNo1, "LOTNO", "LOC_DTL");
            clsASRS.gsHelpStyle = "LOTNO";
            Array.Resize<string>(ref clsASRS.gsHelpRtnData, 1);

            frmHelp frmHelp = new frmHelp();
            frmHelp.ShowDialog();

            txtLotNo1.Text = clsASRS.gsHelpRtnData[0];
        }

        private void btnHelp_LotNo2_Click(object sender, EventArgs e)
        {
            //clsTool.showForm(txtLotNo2, "LOTNO", "LOC_DTL");
            clsASRS.gsHelpStyle = "LOTNO";
            Array.Resize<string>(ref clsASRS.gsHelpRtnData, 1);

            frmHelp frmHelp = new frmHelp();
            frmHelp.ShowDialog();

            txtLotNo2.Text = clsASRS.gsHelpRtnData[0];
        }

        private void btnHelp_FOSB1_Click(object sender, EventArgs e)
        {
            //clsTool.showForm(txtFosbID1, "FOSBID", "LOC_DTL");
            clsASRS.gsHelpStyle = "FOSB";
            Array.Resize<string>(ref clsASRS.gsHelpRtnData, 1);

            frmHelp frmHelp = new frmHelp();
            frmHelp.ShowDialog();

            txtFosbID1.Text = clsASRS.gsHelpRtnData[0];
        }

        private void btnHelp_FOSB2_Click(object sender, EventArgs e)
        {
            //clsTool.showForm(txtFosbID2, "FOSBID", "LOC_DTL");
            clsASRS.gsHelpStyle = "FOSB";
            Array.Resize<string>(ref clsASRS.gsHelpRtnData, 1);

            frmHelp frmHelp = new frmHelp();
            frmHelp.ShowDialog();

            txtFosbID2.Text = clsASRS.gsHelpRtnData[0];
        }

        private void btnHelp_Device1_Click(object sender, EventArgs e)
        {
            //clsTool.showForm(txtDevice1, "DEVICE", "LOC_DTL");

            clsASRS.gsHelpStyle = "DEVICE";
            Array.Resize<string>(ref clsASRS.gsHelpRtnData, 1);

            frmHelp frmHelp = new frmHelp();
            frmHelp.ShowDialog();

            txtDevice1.Text = clsASRS.gsHelpRtnData[0];
        }

        private void btnHelp_Device2_Click(object sender, EventArgs e)
        {
            //clsTool.showForm(txtDevice2, "DEVICE", "LOC_DTL");

            clsASRS.gsHelpStyle = "DEVICE";
            Array.Resize<string>(ref clsASRS.gsHelpRtnData, 1);

            frmHelp frmHelp = new frmHelp();
            frmHelp.ShowDialog();

            txtDevice2.Text = clsASRS.gsHelpRtnData[0];
        }


    }
}
