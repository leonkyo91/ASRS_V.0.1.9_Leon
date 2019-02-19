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
    public partial class frm_WMS_LOC_MAPPING : Form
    {
        #region Grid Parameter
        int iCol_WMS = 0;
        int iCol_ASRS = 1;
        int iCol_Counts = 2;
        #endregion

        public frm_WMS_LOC_MAPPING()
        {
            InitializeComponent();
        }

        private void frm_WMS_LOC_MAPPING_Load(object sender, EventArgs e)
        {
            GridInit();
            FormInit();
        }

        private void GridInit()
        {
            GridSysInit(ref Grid1);
            GridSetRange(ref Grid1);
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
  
            oGrid.Columns[iCol_WMS].Width = 160; oGrid.Columns[iCol_WMS].Name = "WMS儲位";
            oGrid.Columns[iCol_ASRS].Width = 90; oGrid.Columns[iCol_ASRS].Name = "ASRS料盒ID";

            int i = 0;
            for (i = 0; i <= oGrid.ColumnCount - 1; i++)
            {
                oGrid.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            oGrid.RowCount = 0; 
        }

        private void FormInit()
        {

        }

        private void Grid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Grid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtWMS.Text = ""; txtASRS.Text = "";

            if ((e.RowIndex <= -1) || (e.ColumnIndex <= -1)) { return; }
            if (Grid1[iCol_ASRS, e.RowIndex].Value.ToString() == "") { return; }

            string sWMS = ""; string sASRS = "";

            sWMS = Grid1[iCol_WMS, e.RowIndex].Value.ToString();
            sASRS = Grid1[iCol_ASRS, e.RowIndex].Value.ToString();

            txtWMS.Text = sWMS; txtASRS.Text = sASRS;
        }

        private void cmdEnd_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            SubQuery();
        }

        private void SubQuery()
        {
            string strSql = ""; DbDataReader dbRS = null;

            Grid1.RowCount = 0;

            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };

            strSql = "SELECT * from spil_wms_loc order by ASRS_LOCID ";
            if (clsDB.FunRsSql(strSql, ref dbRS))
            {
                while (dbRS.Read())
                {
                    Grid1.Rows.Add();
                    Grid1.Rows[Grid1.Rows.Count - 1].HeaderCell.Value = "";

                    Grid1[iCol_WMS, Grid1.Rows.Count - 1].Value = dbRS["WMS_LOC"].ToString();
                    Grid1[iCol_ASRS, Grid1.Rows.Count - 1].Value = dbRS["ASRS_LOCID"].ToString();
                }
                dbRS.Close();
            }

            clsDB.FunClsDB();
        }

        
        private void cmdStart_Click(object sender, EventArgs e)
        {
            if (rbAdd.Checked == true)
            {
                SubAdd();
            }
            else if (rbUpdate.Checked == true)
            {
                SubUpdate();
            }
            else if (rbDel.Checked == true)
            {
                SubDel();
            }
        }

        private void SubAdd()
        {
            string sWMS = ""; string sASRS = "";
            sWMS = txtWMS.Text.Trim();
            sASRS = txtASRS.Text.Trim();

            string strSql = ""; DbDataReader dbRS = null;

            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };

            strSql = "SELECT COUNT(*) FROM SPIL_WMS_LOC WHERE ASRS_LOCID = '" + sASRS + "' ";
            if (clsDB.FunRsSql(strSql, ref dbRS))
            {
                while (dbRS.Read())
                {
                    if (clsTool.INT(dbRS[0].ToString()) > 0)
                    {
                        clsMSG.ShowWarningMsg("資料己重覆(" + sASRS + ")");
                        dbRS.Close();
                        clsDB.FunClsDB();
                        return;
                    }

                }
                dbRS.Close();
            }

            strSql = "SELECT COUNT(*) FROM SPIL_WMS_LOC WHERE WMS_LOC = '" + sWMS + "' ";
            if (clsDB.FunRsSql(strSql, ref dbRS))
            {
                while (dbRS.Read())
                {
                    if (clsTool.INT(dbRS[0].ToString()) > 0)
                    {
                        clsMSG.ShowWarningMsg("資料己重覆(" + sWMS + ")");
                        dbRS.Close();
                        clsDB.FunClsDB();
                        return;
                    }

                }
                dbRS.Close();
            }

            strSql = "INSERT INTO spil_wms_loc (ASRS_LOCID,WMS_LOC) VALUES (";
            strSql = strSql + "'" + sASRS + "','" + sWMS + "') ";
            if (clsDB.FunExecSql(strSql) == true)
            {
                clsMSG.ShowInformationMsg(clsMSG.MSG.Msg_Run_Finish);
                clsDB.FunClsDB();
                SubQuery();
                txtWMS.Text = ""; txtASRS.Text = "";
            }
            else
            {
                clsMSG.ShowErrMsg(clsMSG.MSG.Msg_Run_Error);
                clsDB.FunClsDB();
            }
        }

        private void SubUpdate()
        {
            string sWMS = ""; string sASRS = "";
            sWMS = txtWMS.Text.Trim();
            sASRS = txtASRS.Text.Trim();

            string strSql = "";

            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };

            clsDB.FunCommitCtrl("BEGIN");

            strSql = "DELETE FROM SPIL_WMS_LOC WHERE ASRS_LOCID = '" + sASRS + "' ";
            clsDB.FunExecSql(strSql);

            strSql = "DELETE FROM SPIL_WMS_LOC WHERE WMS_LOC = '" + sWMS + "' ";
            clsDB.FunExecSql(strSql);

            strSql = "UPDATE spil_wms_loc (ASRS_LOCID,WMS_LOC) VALUES (";
            strSql = strSql + "'" + sASRS + "','" + sWMS + "') ";
            if (clsDB.FunExecSql(strSql) == true)
            {
                clsDB.FunCommitCtrl("COMMIT");
                clsMSG.ShowInformationMsg(clsMSG.MSG.Msg_Run_Finish);
                clsDB.FunClsDB();
                SubQuery();
                txtWMS.Text = ""; txtASRS.Text = "";
            }
            else
            {
                clsDB.FunCommitCtrl("ROLLBACK");
                clsMSG.ShowErrMsg(clsMSG.MSG.Msg_Run_Error);
                clsDB.FunClsDB();
            }

        }

        private void SubDel()
        {
            string sWMS = ""; string sASRS = "";
            sWMS = txtWMS.Text.Trim();
            sASRS = txtASRS.Text.Trim();

            string strSql = "";

            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };

            strSql = "DELETE FROM spil_wms_loc ";
            strSql = strSql + "WHERE ASRS_LOCID = '" + sASRS + "' ";
            strSql = strSql + "AND WMS_LOC = '" + sWMS + "' ";
            if (clsDB.FunExecSql(strSql) == true)
            {
                clsMSG.ShowInformationMsg(clsMSG.MSG.Msg_Run_Finish);
                clsDB.FunClsDB();
                SubQuery();
                txtWMS.Text = ""; txtASRS.Text = "";
            }
            else
            {
                clsMSG.ShowErrMsg(clsMSG.MSG.Msg_Run_Error);
                clsDB.FunClsDB();
            }  
            clsDB.FunClsDB();
        }
    }
}
