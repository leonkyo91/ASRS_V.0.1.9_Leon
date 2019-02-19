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
    public partial class frmHelp2 : Form
    {
        private int iCol_Loc1 = 0;
        private int iCol_LocID1 = 1;
        private int iCol_Loc2 = 2;
        private int iCol_LocID2 = 3;
        private int iCol_Counts = 4;

        private int iSelRow = 0;

        public frmHelp2()
        {
            InitializeComponent();
        }

        private void frmHelp2_Load(object sender, EventArgs e)
        {
            GridInit();
            FormInit();
        }

        private void FormInit()
        {
            Array.Resize<string>(ref clsASRS.gsHelpRtnData, 4);
            clsASRS.gsHelpRtnData[0] = "";
            clsASRS.gsHelpRtnData[1] = "";
            clsASRS.gsHelpRtnData[2] = "";
            clsASRS.gsHelpRtnData[3] = "";

            clsASRS.SubCboSetCrnNo(ref cboCrnNo);
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

            oGrid.Columns[iCol_Loc1].Width = 90; oGrid.Columns[iCol_Loc1].Name = "儲位編號";
            oGrid.Columns[iCol_LocID1].Width = 90; oGrid.Columns[iCol_LocID1].Name = "料盤編號";
            oGrid.Columns[iCol_Loc2].Width = 90; oGrid.Columns[iCol_Loc2].Name = "儲位編號";
            oGrid.Columns[iCol_LocID2].Width = 90; oGrid.Columns[iCol_LocID2].Name = "料盤編號";

            if (clsASRS.gsHelpStyle == "1")
            {
                oGrid.Columns[iCol_Loc1].Width = 90; oGrid.Columns[iCol_Loc1].Name = "儲位編號";
                oGrid.Columns[iCol_LocID1].Width = 90; oGrid.Columns[iCol_LocID1].Name = "料盤編號";
                oGrid.Columns[iCol_Loc2].Width = 90; oGrid.Columns[iCol_Loc2].Name = "儲位編號";
                oGrid.Columns[iCol_LocID2].Width = 90; oGrid.Columns[iCol_LocID2].Name = "料盤編號";
                oGrid.Columns[iCol_Loc2].Visible = false;
                oGrid.Columns[iCol_LocID2].Visible = false;                
            }
            else
            {
                oGrid.Columns[iCol_Loc1].Width = 100; oGrid.Columns[iCol_Loc1].Name = "儲位編號(1)";
                oGrid.Columns[iCol_LocID1].Width = 100; oGrid.Columns[iCol_LocID1].Name = "料盤編號(1)";
                oGrid.Columns[iCol_Loc2].Width = 100; oGrid.Columns[iCol_Loc2].Name = "儲位編號(2)";
                oGrid.Columns[iCol_LocID2].Width = 100; oGrid.Columns[iCol_LocID2].Name = "料盤編號(2)";
            }

            int i = 0;
            for (i = 0; i <= oGrid.ColumnCount - 1; i++)
            {
                oGrid.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            oGrid.RowCount = 0;
        }


        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (Grid1.RowCount > 0)
            {
                if (iSelRow >= 0)
                {
                    clsASRS.gsHelpRtnData[0] = Grid1[iCol_Loc1, iSelRow].Value.ToString();
                    clsASRS.gsHelpRtnData[1] = Grid1[iCol_LocID1, iSelRow].Value.ToString();
                    clsASRS.gsHelpRtnData[2] = Grid1[iCol_Loc2, iSelRow].Value.ToString();
                    clsASRS.gsHelpRtnData[3] = Grid1[iCol_LocID2, iSelRow].Value.ToString();
                }
            }
            this.Close();
        }

        private void cmdQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboCrnNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            SubQuery();
        }

        private void SubQuery()
        {
            string strSql = ""; DbDataReader dbRS = null;
            int iCrn = 0;

            Grid1.RowCount = 0;

            if (cboCrnNo.Text == "") { return; }
            iCrn = clsTool.INT(cboCrnNo.Text);


            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };

            if (clsASRS.gsHelpStyle == "1")
            {
                strSql = "SELECT LOC,LOCSTS,LOCID,LOC1 FROM LOC_MST WHERE LOCSTS = 'E' AND CRANE_NO = " + iCrn + " ";
                strSql = strSql + "ORDER BY ROW_X,BAY_Y,LVL_Z ";
                if (clsDB.FunRsSql(strSql, ref dbRS) == true)
                {
                    while (dbRS.Read())
                    {
                        Grid1.Rows.Add();
                        Grid1[iCol_Loc1, Grid1.RowCount - 1].Value = dbRS["LOC"].ToString();
                        Grid1[iCol_LocID1, Grid1.RowCount - 1].Value = dbRS["LOCID"].ToString();
                        Grid1[iCol_Loc2, Grid1.RowCount - 1].Value = "";
                        Grid1[iCol_LocID2, Grid1.RowCount - 1].Value = "";
                    }
                    dbRS.Close();
                }
            }
            else if (clsASRS.gsHelpStyle == "2")
            {
                strSql = "SELECT LOC,LOCSTS,LOCID,LOC1,(SELECT LOCID FROM LOC_MST WHERE LOC = M.LOC1) AS LOCID1 ";
                strSql = strSql + "FROM LOC_MST M WHERE LOCSTS = 'E' ";
                strSql = strSql + "AND LOC IN (";
                strSql = strSql + "SELECT LOC1 FROM LOC_MST WHERE LOCSTS = 'E') ";
                strSql = strSql + "AND CRANE_NO = " + iCrn + " ";
                strSql = strSql + "AND CRANE_ROW IN (3,2) ";    //取左列
                strSql = strSql + "ORDER BY LVL_Z,BAY_Y,ROW_X ";
                if (clsDB.FunRsSql(strSql, ref dbRS) == true)
                {
                    while (dbRS.Read())
                    {
                        Grid1.Rows.Add();
                        Grid1[iCol_Loc1, Grid1.RowCount - 1].Value = dbRS["LOC"].ToString();
                        Grid1[iCol_LocID1, Grid1.RowCount - 1].Value = dbRS["LOCID"].ToString();
                        Grid1[iCol_Loc2, Grid1.RowCount - 1].Value = dbRS["LOC1"].ToString();
                        Grid1[iCol_LocID2, Grid1.RowCount - 1].Value = dbRS["LOCID1"].ToString();
                    }
                    dbRS.Close();
                }
            }
            
            clsDB.FunClsDB();

        }

        private void Grid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            iSelRow = e.RowIndex;
            //if (e.RowIndex < 0) { return; }

        }

        private void Grid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
