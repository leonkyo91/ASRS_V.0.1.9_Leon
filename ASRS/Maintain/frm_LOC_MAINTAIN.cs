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
    public partial class frm_LOC_MAINTAIN : Form
    {
        #region Grid1 Parameter
        int iCol_FOSBID = 0;
        int iCol_ITEMNO = 1;
        int iCol_CUSTOMER = 2;
        int iCol_DEVICE = 3;
        int iCol_LOTNO = 4;
        int iCol_OFFQTY = 5;
        int iCol_WAFERQTY = 6;
        int iCol_SHIPQTY = 7;
        int iCol_CHKIQC = 8;
        int iCol_INDATE = 9;
        int iCol_TRNDATE = 10;
        int iCol_REMARK = 11;
        int iCol_Counts = 12;
        #endregion


        public frm_LOC_MAINTAIN()
        {
            InitializeComponent();
        }

        private void frm_LOC_MAINTAIN_Load(object sender, EventArgs e)
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

            oGrid.Columns[iCol_FOSBID].Width = 90; oGrid.Columns[iCol_FOSBID].Name = "FOSB ID";
            oGrid.Columns[iCol_ITEMNO].Width = 80; oGrid.Columns[iCol_ITEMNO].Name = "ITEM NO";
            oGrid.Columns[iCol_CUSTOMER].Width = 80; oGrid.Columns[iCol_CUSTOMER].Name = "客戶簡稱";
            oGrid.Columns[iCol_DEVICE].Width = 100; oGrid.Columns[iCol_DEVICE].Name = "DEVICE";
            oGrid.Columns[iCol_LOTNO].Width = 100; oGrid.Columns[iCol_LOTNO].Name = "Lot No";
            oGrid.Columns[iCol_OFFQTY].Width = 70; oGrid.Columns[iCol_OFFQTY].Name = "件數";
            oGrid.Columns[iCol_WAFERQTY].Width = 70; oGrid.Columns[iCol_WAFERQTY].Name = "枚數";
            oGrid.Columns[iCol_SHIPQTY].Width = 70; oGrid.Columns[iCol_SHIPQTY].Name = "數量";
            oGrid.Columns[iCol_CHKIQC].Width = 70; oGrid.Columns[iCol_CHKIQC].Name = "檢驗";
            oGrid.Columns[iCol_INDATE].Width = 120; oGrid.Columns[iCol_INDATE].Name = "入庫日期";
            oGrid.Columns[iCol_TRNDATE].Width = 120; oGrid.Columns[iCol_TRNDATE].Name = "異動日期";

            oGrid.RowCount = 0;
        }

        private void FormInit()
        {
            clsASRS.SubCboSetLocSts(ref cboLocSts);

        }



        private void FormCls()
        {
            txtLotNo.Text = "";
            txtLoc.Text = "";
            txtMLoc.Text = "";
            cboLocSts.Text = "";
            txtLocID.Text = "";
            Grid1.RowCount = 0;
        }


        private void cmdQuery_Click(object sender, EventArgs e)
        {
            SubQuery();
        }

        private void SubQuery()
        {
            string sSQL = ""; DbDataReader dbRS = null;

            if (txtLoc.Text == "") { return; }

            txtLotNo.Text = "";
            txtMLoc.Text = "";
            cboLocSts.Text = "";
            txtLocID.Text = "";
            Grid1.RowCount = 0;

            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };

            sSQL = "SELECT * FROM LOC_MST WHERE LOC = '" + txtLoc.Text + "' ";
            if (clsDB.FunRsSql(sSQL,ref dbRS))
            {
                while (dbRS.Read())
                {
                    txtMLoc.Text = dbRS["LOC"].ToString();
                    txtLocID.Text = dbRS["LOCID"].ToString();
                    cboLocSts.Text = dbRS["LOCSTS"].ToString();
                }
                dbRS.Close();
            }

            sSQL = "SELECT * FROM LOC_DTL WHERE LOC = '" + txtLoc.Text + "' ";
            if (clsDB.FunRsSql(sSQL, ref dbRS))
            {
                while (dbRS.Read())
                {
                    Grid1.Rows.Add();
                    Grid1.Rows[Grid1.RowCount - 1].HeaderCell.Value = "";
                    Grid1[iCol_FOSBID, Grid1.RowCount - 1].Value = dbRS["FOSBID"].ToString();
                    Grid1[iCol_ITEMNO, Grid1.RowCount - 1].Value = dbRS["Itemno"].ToString();
                    Grid1[iCol_CUSTOMER, Grid1.RowCount - 1].Value = dbRS["customer"].ToString();
                    Grid1[iCol_DEVICE, Grid1.RowCount - 1].Value = dbRS["device"].ToString();
                    Grid1[iCol_LOTNO, Grid1.RowCount - 1].Value = dbRS["lotno"].ToString();
                    Grid1[iCol_OFFQTY, Grid1.RowCount - 1].Value = dbRS["offqty"].ToString();
                    Grid1[iCol_WAFERQTY, Grid1.RowCount - 1].Value = dbRS["waferqty"].ToString();
                    Grid1[iCol_SHIPQTY, Grid1.RowCount - 1].Value = dbRS["ShipQty"].ToString();
                    Grid1[iCol_CHKIQC, Grid1.RowCount - 1].Value = dbRS["chkiqc"].ToString();
                    Grid1[iCol_INDATE, Grid1.RowCount - 1].Value = dbRS["indate"].ToString();
                    Grid1[iCol_REMARK, Grid1.RowCount - 1].Value = dbRS["REMARK"].ToString();
                }
                dbRS.Close();
            }

        }

        private void cmdEnd_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtMLoc.Text == "") { return; }


            clsASRS.gsHelpStyle = "ADD";
            //Array.Resize<string>(ref clsASRS.gsHelpRtnData, 0);
            Array.Resize<string>(ref clsASRS.gsHelpRtnData, 1);
            clsASRS.gsHelpRtnData[0] = "";
            clsASRS.gsHelpStyle_Data = "";
            clsASRS.gsHelpStyle_MLoc = txtMLoc.Text;

            frm_LOC_MAINTAIN_Help frmHelp = new frm_LOC_MAINTAIN_Help();
            frmHelp.ShowDialog();



            //回傳值
            string sRtnData = clsASRS.gsHelpRtnData[0];

            if (sRtnData == "Y") { SubQuery(); }
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtMLoc.Text == "") { return; }

            string sData = SubGetGridData();

            clsASRS.gsHelpStyle = "UPD";
            Array.Resize<string>(ref clsASRS.gsHelpRtnData, 1);
            clsASRS.gsHelpRtnData[0] = "";
            clsASRS.gsHelpStyle_Data = sData;
            clsASRS.gsHelpStyle_MLoc = txtMLoc.Text;

            frm_LOC_MAINTAIN_Help frmHelp = new frm_LOC_MAINTAIN_Help();
            frmHelp.ShowDialog();

            string sRtnData = clsASRS.gsHelpRtnData[0];
            if (sRtnData == "Y") { SubQuery(); }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (txtMLoc.Text == "") { return; }

            string sData = SubGetGridData();

            clsASRS.gsHelpStyle = "DEL";
            Array.Resize<string>(ref clsASRS.gsHelpRtnData, 1);
            clsASRS.gsHelpRtnData[0] = "";
            clsASRS.gsHelpStyle_Data = sData;
            clsASRS.gsHelpStyle_MLoc = txtMLoc.Text;

            frm_LOC_MAINTAIN_Help frmHelp = new frm_LOC_MAINTAIN_Help();
            frmHelp.ShowDialog();

            string sRtnData = clsASRS.gsHelpRtnData[0];
            if (sRtnData == "Y") { SubQuery(); }
        }

        private string SubGetGridData()
        {
            int idx = 0;
            string sData = "";

            sData = Grid1[iCol_FOSBID, idx].Value.ToString() + ",";
            sData = sData + Grid1[iCol_ITEMNO, idx].Value.ToString() + ",";
            sData = sData + Grid1[iCol_CUSTOMER, idx].Value.ToString() + ",";
            sData = sData + Grid1[iCol_DEVICE, idx].Value.ToString() + ",";
            sData = sData + Grid1[iCol_LOTNO, idx].Value.ToString() + ",";
            sData = sData + Grid1[iCol_OFFQTY, idx].Value.ToString() + ",";
            sData = sData + Grid1[iCol_WAFERQTY, idx].Value.ToString() + ",";
            sData = sData + Grid1[iCol_SHIPQTY, idx].Value.ToString() + ",";
            sData = sData + Grid1[iCol_CHKIQC, idx].Value.ToString() + ",";
            sData = sData + Grid1[iCol_INDATE, idx].Value.ToString() + ",";
            sData = sData + Grid1[iCol_REMARK, idx].Value.ToString() + " ";
            
            return sData;
        }

        private void btnUpd_Loc_Click(object sender, EventArgs e)
        {
            if (txtMLoc.Text == "") {return; }

            string sLocSts = "";
                        
            sLocSts = clsTool.FunGetComineData(cboLocSts.Text);
                        
            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };

            string sSQL = "";
            sSQL = "UPDATE LOC_MST SET LOCSTS = '" + sLocSts + "', ";
            if (sLocSts == "S")
            {
                sSQL = sSQL + "MIXQTY = 1, AVAIL = 100, ";
            }
            sSQL = sSQL + "LOCID = '" + txtLocID.Text + "' ";
            sSQL = sSQL + "WHERE LOC = '" + txtMLoc.Text + "' ";
            if (clsDB.FunExecSql(sSQL) == true)
            {
                clsMSG.ShowInformationMsg(clsMSG.MSG.Msg_Run_Finish);
                clsDB.FunClsDB();
                FormCls();                
            }
            else
            {
                clsMSG.ShowErrMsg(clsMSG.MSG.Msg_Run_Error);
                clsDB.FunClsDB();
            }
            
        }


    }
}
