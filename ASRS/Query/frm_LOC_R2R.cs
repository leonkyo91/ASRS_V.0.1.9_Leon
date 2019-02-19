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
    public partial class frm_LOC_R2R : Form
    {

        #region Grid1 Parameter
        int iCol_LOCID = 0;
        int iCol_LOC = 1;
        int iCol_N1 = 2;
        int iCol_Counts = 3;
        #endregion

        public frm_LOC_R2R()
        {
            InitializeComponent();
        }

        private void frm_LOC_R2R_Load(object sender, EventArgs e)
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
                        
            oGrid.Columns[iCol_LOCID].Width = 150; oGrid.Columns[iCol_LOCID].Name = "料盒ID";
            oGrid.Columns[iCol_LOC].Width = 150; oGrid.Columns[iCol_LOC].Name = "原儲位編號";
            oGrid.Columns[iCol_N1].Width = 200; oGrid.Columns[iCol_N1].Name = "庫對庫累計次數";

            //int i = 0;
            //for (i = 0; i <= oGrid.ColumnCount - 1; i++)
            //{
            //    oGrid.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            //}

            oGrid.RowCount = 0;
        }

        private void FormInit()
        {
            FormCls();
        }

        private void FormCls()
        {
            txtLoc1.Text = ""; txtLoc2.Text = "";
            txtLocID1.Text = ""; txtLocID2.Text = "";
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };
            SubQuery();
            clsDB.FunClsDB();
        }

        private void btnCls_Click(object sender, EventArgs e)
        {
            FormCls();
            Grid1.RowCount = 0;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void SubQuery()
        {
            string strSQL = ""; DbDataReader dbRS = null;

            Grid1.RowCount = 0;

            strSQL = "SELECT * FROM LOCID_R2R WHERE N1 > 0 ";
            if (txtLoc1.Text != "")
            {
                if (txtLoc2.Text != "")
                {
                    strSQL = strSQL + "AND LOC >= '" + txtLoc1.Text + "' AND LOC <= '" + txtLoc2.Text + "' ";  
                }
                else
                {
                    strSQL = strSQL + "AND LOC = '" + txtLoc1.Text + "' ";
                }
            }

            if (txtLocID1.Text != "")
            {
                if (txtLocID2.Text != "")
                {
                    strSQL = strSQL + "AND LOCID >= '" + txtLocID1.Text + "' AND LOCID <= '" + txtLocID2.Text + "' ";
                }
                else
                {
                    strSQL = strSQL + "AND LOCID = '" + txtLocID1.Text + "' ";
                }
            }

            strSQL = strSQL + "ORDER BY N1 DESC,LOCID ";
            if (clsDB.FunRsSql(strSQL, ref dbRS))
            {
                while (dbRS.Read())
                {
                    Grid1.Rows.Add();
                    Grid1[iCol_LOCID, Grid1.Rows.Count - 1].Value = dbRS["LOCID"].ToString();
                    Grid1[iCol_LOC, Grid1.Rows.Count - 1].Value = dbRS["LOC"].ToString();
                    Grid1[iCol_N1, Grid1.Rows.Count - 1].Value = dbRS["N1"].ToString();
                }
                dbRS.Close();
            }

        }









    }
}
