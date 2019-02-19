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
    public partial class frm_ASRS_LOG : Form
    {

        #region Grid1 Parameter
        int iCol_TRNDATE = 0;
        int iCol_TRNTIME = 1;
        int iCol_CMDSNO = 2;
        int iCol_CMDMODE = 3;
        int iCol_IOTYPE = 4;
        int iCol_STNNO = 5;
        int iCol_LOC = 6;
        int iCol_LOCID = 7;
        int iCol_NEWLOC = 8;
        int iCol_USERID = 9;
        int iCol_PROGID = 10;
        int iCol_ITEMNO = 11;
        int iCol_CUSTOMER = 12;
        int iCol_DEVICE = 13;
        int iCol_LOTNO = 14;
        int iCol_OFFQTY = 15;
        int iCol_WAFERQTY = 16;
        int iCol_SHIPQTY = 17;
        int iCol_OFFACTQTY = 18;
        int iCol_WAFERACTQTY = 19;
        int iCol_SHIPACTQTY = 20;
        int iCol_FOSBID = 21;
        int iCol_INDATE = 22;
        int iCol_Counts = 23;
        #endregion

        public frm_ASRS_LOG()
        {
            InitializeComponent();
        }

        private void frm_ASRS_LOG_Load(object sender, EventArgs e)
        {
            GridInit();
            FormInit();
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

            oGrid.Columns[iCol_TRNDATE].Width = 80; oGrid.Columns[iCol_TRNDATE].Name = "異動日期";
            oGrid.Columns[iCol_TRNTIME].Width = 80; oGrid.Columns[iCol_TRNTIME].Name = "異動時間";
            oGrid.Columns[iCol_CMDSNO].Width = 80; oGrid.Columns[iCol_CMDSNO].Name = "命令序號";
            oGrid.Columns[iCol_CMDMODE].Width = 80; oGrid.Columns[iCol_CMDMODE].Name = "命令模式";
            oGrid.Columns[iCol_IOTYPE].Width = 80; oGrid.Columns[iCol_IOTYPE].Name = "作業別";
            oGrid.Columns[iCol_STNNO].Width = 80; oGrid.Columns[iCol_STNNO].Name = "站號";
            oGrid.Columns[iCol_LOC].Width = 80; oGrid.Columns[iCol_LOC].Name = "儲位";
            oGrid.Columns[iCol_LOCID].Width = 80; oGrid.Columns[iCol_LOCID].Name = "料盒編號";
            oGrid.Columns[iCol_NEWLOC].Width = 80; oGrid.Columns[iCol_NEWLOC].Name = "新儲位";
            oGrid.Columns[iCol_USERID].Width = 80; oGrid.Columns[iCol_USERID].Name = "使用者";
            oGrid.Columns[iCol_PROGID].Width = 80; oGrid.Columns[iCol_PROGID].Name = "程式編號";

            oGrid.Columns[iCol_ITEMNO].Width = 80; oGrid.Columns[iCol_ITEMNO].Name = "ITEM NO";
            oGrid.Columns[iCol_CUSTOMER].Width = 80; oGrid.Columns[iCol_CUSTOMER].Name = "客戶簡稱";
            oGrid.Columns[iCol_DEVICE].Width = 80; oGrid.Columns[iCol_DEVICE].Name = "DEVICE";
            oGrid.Columns[iCol_LOTNO].Width = 80; oGrid.Columns[iCol_LOTNO].Name = "LOT NO";
            oGrid.Columns[iCol_OFFQTY].Width = 60; oGrid.Columns[iCol_OFFQTY].Name = "件數";
            oGrid.Columns[iCol_WAFERQTY].Width = 60; oGrid.Columns[iCol_WAFERQTY].Name = "枚數";
            oGrid.Columns[iCol_SHIPQTY].Width = 80; oGrid.Columns[iCol_SHIPQTY].Name = "數量";
            oGrid.Columns[iCol_OFFACTQTY].Width = 80; oGrid.Columns[iCol_OFFACTQTY].Name = "(異動)件數";
            oGrid.Columns[iCol_WAFERACTQTY].Width = 80; oGrid.Columns[iCol_WAFERACTQTY].Name = "(異動)枚數";
            oGrid.Columns[iCol_SHIPACTQTY].Width = 80; oGrid.Columns[iCol_SHIPACTQTY].Name = "(異動)數量";
            oGrid.Columns[iCol_FOSBID].Width = 90; oGrid.Columns[iCol_FOSBID].Name = "FOSB ID";
            oGrid.Columns[iCol_INDATE].Width = 120; oGrid.Columns[iCol_INDATE].Name = "入庫日期";





            int i = 0;
            for (i = 0; i <= oGrid.ColumnCount - 1; i++)
            {
                oGrid.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            oGrid.RowCount = 0;
        }

        private void FormInit()
        {
            clsASRS.SubCboSetIoType(ref cboIotype);

        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            //clsMSG.ShowQuestionMsg("abcdefghijklmnopqrstuvwxyz1234567890=========================================");
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
                        case "txtFosbID2":
                            txtFosbID2.Text = txtFosbID1.Text;
                            break;
                        case "txtItemNo2":
                            txtItemNo2.Text = txtItemNo1.Text;
                            break;
                        case "txtLotNo2":
                            txtLotNo2.Text = txtLotNo1.Text;
                            break;
                    }
                }
            }
        }
        private void Query()
        {
            Grid1.RowCount = 0;
            txtLotNoCount.Text = "";

           
            string strSql = "select * from trnlog";
            string strCondition = " where ";

            #region 抓取db條件
            for (int i = 0; i != GroupBox2.Controls.Count; i++)
            {
                object obj = GroupBox2.Controls[i];
                switch (obj.GetType().FullName)
                {
                    case "System.Windows.Forms.TextBox":
                        TextBox tb = (TextBox)obj;
                        if (tb.Text == "")
                            break;
                        switch (tb.Name)
                        {
                            case "txtCmdSno0":
                                strCondition += (strCondition.Trim() == "where" ? "" : " and ") + "cmdSno>='" + tb.Text + "' ";
                                break;
                            case "txtCmdSno1":
                                strCondition += (strCondition.Trim() == "where" ? "" : " and ") + "cmdSno<='" + tb.Text + "' ";
                                break;
                            case "txtItemNo1":
                                strCondition += (strCondition.Trim() == "where" ? "" : " and ") + "itemno>='" + tb.Text + "' ";
                                break;
                            case "txtItemNo2":
                                strCondition += (strCondition.Trim() == "where" ? "" : " and ") + "itemno<='" + tb.Text + "' ";
                                break;
                            case "txtLotNo1":
                                strCondition += (strCondition.Trim() == "where" ? "" : " and ") + "lotno>='" + tb.Text + "' ";
                                break;
                            case "txtLotNo2":
                                strCondition += (strCondition.Trim() == "where" ? "" : " and ") + "lotno<='" + tb.Text + "' ";
                                break;
                            case "txtFosbID1":
                                strCondition += (strCondition.Trim() == "where" ? "" : " and ") + "fosbid>='" + tb.Text + "' ";
                                break;
                            case "txtFosbID2":
                                strCondition += (strCondition.Trim() == "where" ? "" : " and ") + "fosbid<='" + tb.Text + "' ";
                                break;
                            case "txtLoc1":
                                strCondition += (strCondition.Trim() == "where" ? "" : " and ") + "loc>='" + tb.Text + "' ";
                                break;
                            case "txtLoc2":
                                strCondition += (strCondition.Trim() == "where" ? "" : " and ") + "loc<='" + tb.Text + "' ";
                                break;
                            default:
                                clsMSG.ShowWarningMsg(tb.Name + "不在此表單內");
                                //MessageBox.Show(tb.Name + "不在此表單內");
                                break;
                        }
                        break;
                    case "System.Windows.Forms.ComboBox":
                        ComboBox cbo = (ComboBox)obj;
                        if (cbo.Text == "")
                            break;
                        switch (cbo.Name)
                        {
                            case "cboCmdSts": strCondition += (strCondition.Trim() == "where" ? "" : " and ") + "cmdsts='" + cbo.Text[0] + "'";
                                break;
                            case "cboStnNo": strCondition += (strCondition.Trim() == "where" ? "" : " and ") + "stnNo='" + cbo.Text + "'";
                                break;
                            case "cboIotype": strCondition += (strCondition.Trim() == "where" ? "" : " and ") + "Iotyp='" + cbo.Text[0] + (cbo.Text.Length > 1 ? cbo.Text[1] : ' ') + "'";
                                break;
                            default:
                                //MessageBox.Show(cbo.Name + "不在此表單內");
                                break;

                        }
                        break;
                }


            }

            if (chkDATE.Checked)
            {
                if (txtTransDate1.Text != "")
                    strCondition += (strCondition.Trim() == "where" ? "" : " and ") + "TRNDATE>='" + txtTransDate1.Text + "' ";
                if (txtTransDate2.Text != "")
                    strCondition += (strCondition.Trim() == "where" ? "" : " and ") + "TRNDATE<='" + txtTransDate2.Text + "' ";
            }

            if (strCondition.Trim() == "where")
            {
                clsMSG.ShowWarningMsg("請選擇查詢條件!!");
                return;   
            }
            else
            {
                strSql += strCondition;
            }
            #endregion


            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };
            DbDataReader dbRs = null;

            if (clsDB.FunRsSql(strSql, ref dbRs))
            {

                int x = 0;

                while (dbRs.Read())
                {
                    Grid1.Rows.Add();

                    Grid1[iCol_TRNDATE, x].Value = dbRs["TRNDATE"].ToString();
                    Grid1[iCol_TRNTIME, x].Value = dbRs["TRNTIME"].ToString();
                    Grid1[iCol_CMDSNO, x].Value = dbRs["CMDSNO"].ToString();
                    Grid1[iCol_CMDMODE, x].Value = dbRs["CMDMODE"].ToString();
                    Grid1[iCol_IOTYPE, x].Value = dbRs["IOTYP"].ToString();
                    Grid1[iCol_STNNO, x].Value = dbRs["STNNO"].ToString();
                    Grid1[iCol_LOC, x].Value = dbRs["LOC"].ToString();
                    Grid1[iCol_LOCID, x].Value = dbRs["LOCID"].ToString();
                    Grid1[iCol_USERID, x].Value = dbRs["USERID"].ToString();
                    Grid1[iCol_PROGID, x].Value = dbRs["PROGID"].ToString();
                    Grid1[iCol_CUSTOMER, x].Value = dbRs["CUSTOMER"].ToString();
                    Grid1[iCol_DEVICE, x].Value = dbRs["DEVICE"].ToString();

                    Grid1[iCol_LOTNO, x].Value = dbRs["LOTNO"].ToString();
                    Grid1[iCol_OFFQTY, x].Value = dbRs["OFFQTY"].ToString();
                    Grid1[iCol_WAFERQTY, x].Value = dbRs["WAFERQTY"].ToString();
                    Grid1[iCol_SHIPQTY, x].Value = dbRs["SHIPQTY"].ToString();
                    Grid1[iCol_OFFACTQTY, x].Value = dbRs["OFFACTQTY"].ToString();
                    Grid1[iCol_WAFERACTQTY, x].Value = dbRs["WAFERACTQTY"].ToString();
                    Grid1[iCol_SHIPACTQTY, x].Value = dbRs["SHIPACTQTY"].ToString();
                    Grid1[iCol_FOSBID, x].Value = dbRs["FOSBID"].ToString();
                    Grid1[iCol_INDATE, x].Value = dbRs["INDATE"].ToString();

                    x++;
                }
                dbRs.Close();

                txtLotNoCount.Text = clsASRS.FunGetFosbCnt(ref Grid1, iCol_FOSBID).ToString();
            }

            clsDB.FunClsDB();
        }

        private void btnCls_Click(object sender, EventArgs e)
        {
            clsTool.finished(this);
            FormCls();
            Grid1.RowCount = 0;
        }

        private void FormCls()
        {
            txtLoc1.Text = ""; txtLoc2.Text = "";
            txtLotNo1.Text = ""; txtLotNo2.Text = "";
            txtItemNo1.Text = ""; txtItemNo2.Text = "";
            txtFosbID1.Text = ""; txtFosbID2.Text = "";
            txtLotNoCount.Text = "";
            chkDATE.Checked = false;
        }

        private void cmdExport_Click(object sender, EventArgs e)
        {
            clsTool.funGridToCsv(Grid1);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHelp_Item1_Click(object sender, EventArgs e)
        {
            clsTool.showForm(txtItemNo1, "itemno", "trnlog");
        }

        private void btnHelp_Item2_Click(object sender, EventArgs e)
        {
            clsTool.showForm(txtItemNo2, "itemno", "trnlog");
        }

        private void btnHelp_FOSB1_Click(object sender, EventArgs e)
        {
            clsTool.showForm(txtFosbID1, "fosbid", "trnlog");
        }

        private void btnHelp_FOSB2_Click(object sender, EventArgs e)
        {
            clsTool.showForm(txtFosbID2, "fosbid", "trnlog");
        }

        private void btnHelp_LotNo1_Click(object sender, EventArgs e)
        {
            clsTool.showForm(txtLotNo1, "lotno", "trnlog");
        }

        private void btnHelp_LotNo2_Click(object sender, EventArgs e)
        {
            clsTool.showForm(txtLotNo2, "lotno", "trnlog");
        }


    }
}
