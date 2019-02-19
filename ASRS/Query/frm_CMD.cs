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
    public partial class frm_CMD : Form
    {

        #region Grid1 Parameter
        int iCol_CMDSNO = 0;
        int iCol_LOCID = 1;
        int iCol_SNO = 2;
        int iCol_CMDSTS = 3;
        int iCol_PRT = 4;
        int iCol_STNNO = 5;
        int iCol_CMDMODE = 6;
        int iCol_IOTYP = 7;
        int iCol_LOC = 8;
        int iCol_NEWLOC = 9;

        int iCol_TRACE = 10;
        int iCol_SCAN = 11;
        int iCol_USERID = 12;
        int iCol_TRNDATE = 13;
        int iCol_ACTTIME = 14;
        int iCol_EXPTIME = 15;
        int iCol_ENDTIME = 16;
        int iCol_PROGID = 17;
        int iCol_Counts = 18;
        #endregion

        #region Grid2 Parameter
        int iCol2_CMDSNO = 0;
        int iCol2_LOCID = 1;
        int iCol2_ITEMNO = 2;
        int iCol2_CUSTOMER = 3;
        int iCol2_DEVICE = 4;
        int iCol2_LOTNO = 5;
        int iCol2_FOSBID = 6;
        int iCol2_OFFQTY = 7;
        int iCol2_WAFERQTY = 8;
        int iCol2_SHIPQTY = 9;
        int iCol2_ACTOFFQTY = 10;
        int iCol2_ACTWAFERQTY = 11;
        int iCol2_ACTSHIPQTY = 12;
        int iCol2_Counts = 13;
        #endregion

        public frm_CMD()
        {
            InitializeComponent();
        }

        private void frm_CMD_Load(object sender, EventArgs e)
        {            
            GridInit();
            FormInit();
        }

        private void GridInit()
        {
            GridSysInit(ref Grid1); GridSetRange1(ref Grid1);
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

        private void GridSetRange1(ref DataGridView oGrid)
        {
            oGrid.ColumnCount = iCol_Counts;
            oGrid.RowCount = 1;

            oGrid.Columns[iCol_CMDSNO].Width = 60; oGrid.Columns[iCol_CMDSNO].Name = "命令序號";
            oGrid.Columns[iCol_LOCID].Width = 60; oGrid.Columns[iCol_LOCID].Name = "料盤編號";
            oGrid.Columns[iCol_SNO].Width = 40; oGrid.Columns[iCol_SNO].Name = "SNO";
            oGrid.Columns[iCol_CMDSTS].Width = 60; oGrid.Columns[iCol_CMDSTS].Name = "命令狀態";
            oGrid.Columns[iCol_PRT].Width = 60; oGrid.Columns[iCol_PRT].Name = "命令順序";
            oGrid.Columns[iCol_STNNO].Width = 40; oGrid.Columns[iCol_STNNO].Name = "站號";
            oGrid.Columns[iCol_CMDMODE].Width = 60; oGrid.Columns[iCol_CMDMODE].Name = "命令模式";
            oGrid.Columns[iCol_IOTYP].Width = 45; oGrid.Columns[iCol_IOTYP].Name = "作業別";
            oGrid.Columns[iCol_LOC].Width = 60; oGrid.Columns[iCol_LOC].Name = "儲位編號";
            oGrid.Columns[iCol_NEWLOC].Width = 60; oGrid.Columns[iCol_NEWLOC].Name = "新儲位";

            oGrid.Columns[iCol_TRACE].Width = 40; oGrid.Columns[iCol_TRACE].Name = "Trace";
            oGrid.Columns[iCol_SCAN].Width = 100; oGrid.Columns[iCol_SCAN].Name = "是否己刷條碼";
            oGrid.Columns[iCol_USERID].Width = 70; oGrid.Columns[iCol_USERID].Name = "使用者";
            oGrid.Columns[iCol_TRNDATE].Width = 85; oGrid.Columns[iCol_TRNDATE].Name = "命令產生日期";
            oGrid.Columns[iCol_ACTTIME].Width = 85; oGrid.Columns[iCol_ACTTIME].Name = "命令產生時間";
            oGrid.Columns[iCol_EXPTIME].Width = 65; oGrid.Columns[iCol_EXPTIME].Name = "執行時間";
            oGrid.Columns[iCol_ENDTIME].Width = 65; oGrid.Columns[iCol_ENDTIME].Name = "結束時間";
            oGrid.Columns[iCol_PROGID].Width = 65; oGrid.Columns[iCol_PROGID].Name = "程式編號";


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
            oGrid.RowCount = 1;

            oGrid.Columns[iCol2_CMDSNO].Width = 60; oGrid.Columns[iCol2_CMDSNO].Name = "命令序號";
            oGrid.Columns[iCol2_LOCID].Width = 60; oGrid.Columns[iCol2_LOCID].Name = "料盤編號";

            oGrid.Columns[iCol2_ITEMNO].Width = 70; oGrid.Columns[iCol2_ITEMNO].Name = "ITEM NO";
            oGrid.Columns[iCol2_CUSTOMER].Width = 60; oGrid.Columns[iCol2_CUSTOMER].Name = "客戶";
            oGrid.Columns[iCol2_DEVICE].Width = 70; oGrid.Columns[iCol2_DEVICE].Name = "DEVICE";
            oGrid.Columns[iCol2_LOTNO].Width = 80; oGrid.Columns[iCol2_LOTNO].Name = "LOT NO";
            oGrid.Columns[iCol2_FOSBID].Width = 70; oGrid.Columns[iCol2_FOSBID].Name = "FOSB ID";
            oGrid.Columns[iCol2_OFFQTY].Width = 50; oGrid.Columns[iCol2_OFFQTY].Name = "件數";
            oGrid.Columns[iCol2_WAFERQTY].Width = 50; oGrid.Columns[iCol2_WAFERQTY].Name = "枚數";
            oGrid.Columns[iCol2_SHIPQTY].Width = 50; oGrid.Columns[iCol2_SHIPQTY].Name = "片數";

            oGrid.Columns[iCol2_ACTOFFQTY].Width = 85; oGrid.Columns[iCol2_ACTOFFQTY].Name = "件數(預約量)";
            oGrid.Columns[iCol2_ACTWAFERQTY].Width = 85; oGrid.Columns[iCol2_ACTWAFERQTY].Name = "枚數(預約量)";
            oGrid.Columns[iCol2_ACTSHIPQTY].Width = 85; oGrid.Columns[iCol2_ACTSHIPQTY].Name = "片數(預約量)";

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
            clsASRS.SubCboSetIoType(ref cboIotype);

            cboCmdSts.Items.Clear();
            cboCmdSts.Items.Add("");
            cboCmdSts.Items.Add("0:未處理");
            cboCmdSts.Items.Add("1:執行命令");
            cboCmdSts.Items.Add("7:命令完成待過帳");
            cboCmdSts.Items.Add("8:命令取消待過帳");
            cboCmdSts.Items.Add("9:過帳完成");
            cboCmdSts.Items.Add("D:取消");
            cboCmdSts.Items.Add("E:過帳失敗");

            cboCmdSts.Text = "1:執行命令";
        }

        private void btnCls_Click(object sender, EventArgs e)
        {
            clsTool.finished(this);
            FormCls();
            Grid1.RowCount = 0;
            Grid2.RowCount = 0;
            //cboCmdSts.Text = "1:執行命令";
        }

        private void FormCls()
        {
            txtCmdSno0.Text = ""; txtCmdSno1.Text = "";
            txtFosbID0.Text = ""; txtFosbID1.Text = "";
            txtItem0.Text = ""; txtItem1.Text = "";
            txtLocID1.Text = ""; txtLocID2.Text = "";
            txtLotNo0.Text = ""; txtLotNo1.Text = "";
            txtLotNoCount.Text = "";
            cboCmdSts.Text = "";
            cboIotype.Text = "";
            cboStnNo.Text = "";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdExport_Click(object sender, EventArgs e)
        {
            clsTool.funGridToCsv(Grid1);
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
                if (obj.GetType() == typeof(TextBox)&&((TextBox)obj).Text=="")
                {
                  switch(((TextBox)obj).Name)
                  {
                      case"txtCmdSno1":
                          txtCmdSno1.Text = txtCmdSno0.Text;
                          break;
                      case"txtFosbID1":
                          txtFosbID1.Text = txtFosbID0.Text;
                          break;
                      case"txtItem1":
                          txtItem1.Text = txtItem0.Text;
                          break;
                      case "txtLotNo1":
                          txtLotNo1.Text = txtLotNo0.Text;
                          break;
                  }
                }
            }
        }

        private void Query()
        {

            Grid1.RowCount = 0;
            Grid2.RowCount = 0;
            txtLotNoCount.Text = "";

            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };

            #region 
            ////string strSql = "select * from cmd_mst m left join cmd_dtl d on m.cmdsno=d.cmdsno";
            //string strSql = "select * from cmd_mst m left join cmd_dtl d on m.cmdsno=d.cmdsno and m.locid = d.locid ";
            //string strCondition = " where ";

            //#region 抓取db條件
            //for (int i = 0; i != GroupBox2.Controls.Count; i++)
            //{
            //    object obj = GroupBox2.Controls[i];
            //    switch (obj.GetType().FullName)
            //    {
            //        case "System.Windows.Forms.TextBox":
            //            TextBox tb = (TextBox)obj;
            //            if (tb.Text == "")
            //                break;
            //            switch (tb.Name)
            //            {
            //                case "txtCmdSno0":
            //                    strCondition += (strCondition.Trim() == "where" ? "" : " and ") + "m.cmdSno>=" + tb.Text;
            //                    break;
            //                case "txtCmdSno1":
            //                    strCondition += (strCondition.Trim() == "where" ? "" : " and ") + "m.cmdSno<=" + tb.Text;
            //                    break;
            //                case "txtItem0":
            //                    strCondition += (strCondition.Trim() == "where" ? "" : " and ") + "d.itemno>=" + tb.Text;
            //                    break;
            //                case "txtItem1":
            //                    strCondition += (strCondition.Trim() == "where" ? "" : " and ") + "d.itemno<=" + tb.Text;
            //                    break;
            //                case "txtLotNo0":
            //                    strCondition += (strCondition.Trim() == "where" ? "" : " and ") + "d.lotno>=" + tb.Text;
            //                    break;
            //                case "txtLotNo1":
            //                    strCondition += (strCondition.Trim() == "where" ? "" : " and ") + "d.lotno<=" + tb.Text;
            //                    break;
            //                case "txtFosbID0":
            //                    strCondition += (strCondition.Trim() == "where" ? "" : " and ") + "d.fosbid>=" + tb.Text;
            //                    break;
            //                case "txtFosbID1":
            //                    strCondition += (strCondition.Trim() == "where" ? "" : " and ") + "d.fosbid<=" + tb.Text;
            //                    break;
            //            }
            //            break;
            //        case "System.Windows.Forms.ComboBox":
            //            ComboBox cbo = (ComboBox)obj;
            //            if (cbo.Text == "")
            //                break;
            //            switch (cbo.Name)
            //            {
            //                case "cboCmdSts": strCondition += (strCondition.Trim() == "where" ? "" : " and ") + "m.cmdsts='" + cbo.Text[0] + "'";
            //                    break;
            //                case "cboStnNo": strCondition += (strCondition.Trim() == "where" ? "" : " and ") + "m.stnNo='" + cbo.Text + "'";
            //                    break;
            //                case "cboIotype": strCondition += (strCondition.Trim() == "where" ? "" : " and ") + "m.Iotyp='" + cbo.Text[0] + (cbo.Text.Length > 1 ? cbo.Text[1] : ' ') + "'";
            //                    break;


            //            }
            //            break;
            //    }


            //}



            //if (strCondition.Trim() == "where")
            //{

            //}
            //else
            //{
            //    strSql += strCondition;
            //}
            //#endregion
            #endregion


            string sSQL_tmp = "";
            string strSql = "SELECT * FROM CMD_MST WHERE CMDSNO <> '' ";
            if (txtCmdSno0.Text != "")
            {
                if (txtCmdSno1.Text != "")
                {
                    sSQL_tmp = sSQL_tmp + "AND CMDSNO >= '" + txtCmdSno0.Text + "' AND CMDSNO <= '" + txtCmdSno1.Text + "'";
                }
                else
                {
                    sSQL_tmp = sSQL_tmp + "AND CMDSNO = '" + txtCmdSno0.Text + "' ";
                }
            }
            if (cboCmdSts.Text != "")
            {
                if (cboCmdSts.Text[0].ToString() == "1")
                {
                    sSQL_tmp = sSQL_tmp + "AND CMDSTS in ('0','1') ";
                }
                else
                {
                    sSQL_tmp = sSQL_tmp + "AND CMDSTS = '" + cboCmdSts.Text[0] + "' ";
                }
            }
            if (cboStnNo.Text != "")
            {
                sSQL_tmp = sSQL_tmp + "AND STNNO = '" + cboStnNo.Text + "' ";
            }
            if (cboIotype.Text != "")
            {
                sSQL_tmp = sSQL_tmp + "AND IOTYP = '" + clsTool.FunGetComineData(cboIotype.Text) + "' ";
            }

            txtLocID1.Text = txtLocID1.Text.ToUpper();
            txtLocID2.Text = txtLocID2.Text.ToUpper();
            if (txtLocID1.Text != "")
            {
                if (txtLocID2.Text != "")
                {
                    sSQL_tmp = sSQL_tmp + "AND LOCID >= '" + txtLocID1.Text + "' AND LOCID <= '" + txtLocID2.Text + "'";
                }
                else
                {
                    sSQL_tmp = sSQL_tmp + "AND LOCID = '" + txtLocID1.Text + "' ";
                }
            }


            strSql = strSql + sSQL_tmp;

            string sSQL_tmp1 = "";
            if (txtFosbID0.Text != "")
            {
                if (txtFosbID1.Text != "")
                {
                    sSQL_tmp1 = sSQL_tmp1 + "AND FOSBID >= '" + txtFosbID0.Text + "' AND FOSBID <= '" + txtFosbID1.Text + "'";
                }
                else
                {
                    sSQL_tmp1 = sSQL_tmp1 + "AND FOSBID = '" + txtFosbID0.Text + "' ";
                }
            }
            if (txtItem0.Text != "")
            {
                if (txtItem1.Text != "")
                {
                    sSQL_tmp1 = sSQL_tmp1 + "AND ITEMNO >= '" + txtItem0.Text + "' AND ITEMNO <= '" + txtItem1.Text + "'";
                }
                else
                {
                    sSQL_tmp1 = sSQL_tmp1 + "AND ITEMNO = '" + txtItem0.Text + "' ";
                }
            }
            if (txtLotNo0.Text != "")
            {
                if (txtLotNo1.Text != "")
                {
                    sSQL_tmp1 = sSQL_tmp1 + "AND LOTNO >= '" + txtLotNo0.Text + "' AND LOTNO <= '" + txtLotNo1.Text + "'";
                }
                else
                {
                    sSQL_tmp1 = sSQL_tmp1 + "AND LOTNO = '" + txtLotNo0.Text + "' ";
                }
            }
            if (sSQL_tmp1 != "")
            {
                sSQL_tmp1 = "AND CMDSNO IN (SELECT CMDSNO FROM CMD_DTL WHERE CMDSNO <> '' " + sSQL_tmp1 + ") ";
            }

            strSql = strSql + sSQL_tmp1;
            strSql = strSql + "ORDER BY CMDSTS,CMDSNO,SNO ";






            DbDataReader dbRS = null;

            if (clsDB.FunRsSql(strSql, ref dbRS))
            {
                int x = 0;

                while (dbRS.Read())
                {
                    Grid1.Rows.Add();
                    Grid1[iCol_CMDSNO, Grid1.RowCount - 1].Value = dbRS["CMDSNO"].ToString();
                    Grid1[iCol_LOCID, Grid1.RowCount - 1].Value = dbRS["LOCID"].ToString();
                    Grid1[iCol_SNO, Grid1.RowCount - 1].Value = dbRS["SNO"].ToString();
                    Grid1[iCol_CMDSTS, Grid1.RowCount - 1].Value = dbRS["CMDSTS"].ToString();

                    Grid1[iCol_PRT, Grid1.RowCount - 1].Value = dbRS["PRT"].ToString();
                    Grid1[iCol_STNNO, Grid1.RowCount - 1].Value = dbRS["STNNO"].ToString();
                    Grid1[iCol_CMDMODE, Grid1.RowCount - 1].Value = dbRS["CMDMODE"].ToString();
                    Grid1[iCol_IOTYP, Grid1.RowCount - 1].Value = dbRS["IOTYP"].ToString();
                    Grid1[iCol_LOC, Grid1.RowCount - 1].Value = dbRS["LOC"].ToString();
                    Grid1[iCol_NEWLOC, Grid1.RowCount - 1].Value = dbRS["NEWLOC"].ToString();

                    Grid1[iCol_TRACE, Grid1.RowCount - 1].Value = dbRS["TRACE"].ToString();
                    Grid1[iCol_SCAN, Grid1.RowCount - 1].Value = dbRS["SCAN"].ToString();
                    Grid1[iCol_USERID, Grid1.RowCount - 1].Value = dbRS["USERID"].ToString();
                    Grid1[iCol_TRNDATE, Grid1.RowCount - 1].Value = dbRS["TRNDATE"].ToString();
                    Grid1[iCol_ACTTIME, Grid1.RowCount - 1].Value = dbRS["ACTTIME"].ToString();
                    Grid1[iCol_EXPTIME, Grid1.RowCount - 1].Value = dbRS["EXPTIME"].ToString();
                    Grid1[iCol_ENDTIME, Grid1.RowCount - 1].Value = dbRS["ENDTIME"].ToString();
                    Grid1[iCol_PROGID, Grid1.RowCount - 1].Value = dbRS["PROGID"].ToString();
                }
                dbRS.Close();

            }
            clsDB.FunClsDB();
        }

        private void Grid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Grid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Grid2.RowCount = 0;

            if (e.RowIndex < 0) { return; }

            if (Grid1[iCol_CMDSNO, e.RowIndex].Value.ToString() == "") { return; }

            string sCmdSno = ""; string sLocID = "";
            sCmdSno = Grid1[iCol_CMDSNO, e.RowIndex].Value.ToString();
            sLocID = Grid1[iCol_LOCID, e.RowIndex].Value.ToString();

            SubQuery_CmdDtl(sCmdSno, sLocID);
        }

        private void SubQuery_CmdDtl(string sCmdSno, string sLocID)
        {
            string strSql = ""; DbDataReader dbRS = null;
            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };

            strSql = "SELECT * FROM CMD_DTL WHERE CMDSNO = '" + sCmdSno + "' AND LOCID = '" + sLocID + "' ";
            if (clsDB.FunRsSql(strSql, ref dbRS))
            {
                while (dbRS.Read())
                {
                    Grid2.Rows.Add();
                    Grid2[iCol2_CMDSNO, Grid2.RowCount - 1].Value = dbRS["CMDSNO"].ToString();
                    Grid2[iCol2_LOCID, Grid2.RowCount - 1].Value = dbRS["LOCID"].ToString();
                    Grid2[iCol2_ITEMNO, Grid2.RowCount - 1].Value = dbRS["ITEMNO"].ToString();
                    Grid2[iCol2_CUSTOMER, Grid2.RowCount - 1].Value = dbRS["CUSTOMER"].ToString();
                    Grid2[iCol2_DEVICE, Grid2.RowCount - 1].Value = dbRS["DEVICE"].ToString();

                    Grid2[iCol2_LOTNO, Grid2.RowCount - 1].Value = dbRS["LOTNO"].ToString();
                    Grid2[iCol2_FOSBID, Grid2.RowCount - 1].Value = dbRS["FOSBID"].ToString();
                    Grid2[iCol2_OFFQTY, Grid2.RowCount - 1].Value = dbRS["OFFQTY"].ToString();
                    Grid2[iCol2_WAFERQTY, Grid2.RowCount - 1].Value = dbRS["WAFERQTY"].ToString();
                    Grid2[iCol2_SHIPQTY, Grid2.RowCount - 1].Value = dbRS["SHIPQTY"].ToString();

                    Grid2[iCol2_ACTOFFQTY, Grid2.RowCount - 1].Value = dbRS["OFFACTQTY"].ToString();
                    Grid2[iCol2_ACTWAFERQTY, Grid2.RowCount - 1].Value = dbRS["WAFERACTQTY"].ToString();
                    Grid2[iCol2_ACTSHIPQTY, Grid2.RowCount - 1].Value = dbRS["SHIPACTQTY"].ToString();
                }
                dbRS.Close();
            }

            clsDB.FunClsDB();
            txtLotNoCount.Text = clsASRS.FunGetFosbCnt(ref Grid2, iCol2_FOSBID).ToString();
        }

        private void btnHelp_FOSB1_Click(object sender, EventArgs e)
        {
            //clsTool.showForm(txtFosbID0, "FOSBID", "CMD_DTL");
            clsASRS.gsHelpStyle = "FOSB";
            Array.Resize<string>(ref clsASRS.gsHelpRtnData, 1);

            frmHelp frmHelp = new frmHelp();
            frmHelp.ShowDialog();

            txtFosbID0.Text = clsASRS.gsHelpRtnData[0];
        }

        private void btnHelp_FOSB2_Click(object sender, EventArgs e)
        {
            //clsTool.showForm(txtFosbID1, "FOSBID", "CMD_DTL");
            clsASRS.gsHelpStyle = "FOSB";
            Array.Resize<string>(ref clsASRS.gsHelpRtnData, 1);

            frmHelp frmHelp = new frmHelp();
            frmHelp.ShowDialog();

            txtFosbID1.Text = clsASRS.gsHelpRtnData[0];
        }

        private void btnHelp_Item1_Click(object sender, EventArgs e)
        {
            //clsTool.showForm(txtItem0, "ITEMNO", "CMD_DTL");
            clsASRS.gsHelpStyle = "ITEM";
            Array.Resize<string>(ref clsASRS.gsHelpRtnData, 1);

            frmHelp frmHelp = new frmHelp();
            frmHelp.ShowDialog();

            txtItem0.Text = clsASRS.gsHelpRtnData[0];
        }

        private void btnHelp_Item2_Click(object sender, EventArgs e)
        {
            //clsTool.showForm(txtItem1, "ITEMNO", "CMD_DTL");
            clsASRS.gsHelpStyle = "ITEM";
            Array.Resize<string>(ref clsASRS.gsHelpRtnData, 1);

            frmHelp frmHelp = new frmHelp();
            frmHelp.ShowDialog();

            txtItem1.Text = clsASRS.gsHelpRtnData[0];
        }

        private void btnHelp_LotNo1_Click(object sender, EventArgs e)
        {
            //clsTool.showForm(txtLotNo0, "LOTNO", "CMD_DTL");
            clsASRS.gsHelpStyle = "LOTNO";
            Array.Resize<string>(ref clsASRS.gsHelpRtnData, 1);

            frmHelp frmHelp = new frmHelp();
            frmHelp.ShowDialog();

            txtLotNo0.Text = clsASRS.gsHelpRtnData[0];
        }

        private void btnHelp_LotNo2_Click(object sender, EventArgs e)
        {
            //clsTool.showForm(txtLotNo1, "LOTNO", "CMD_DTL");
            clsASRS.gsHelpStyle = "LOTNO";
            Array.Resize<string>(ref clsASRS.gsHelpRtnData, 1);

            frmHelp frmHelp = new frmHelp();
            frmHelp.ShowDialog();

            txtLotNo1.Text = clsASRS.gsHelpRtnData[0];
        }




    }
}
