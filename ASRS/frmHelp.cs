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
    public partial class frmHelp : Form
    {
        private int iSelRow = 0;

        public frmHelp()
        {
            InitializeComponent();
        }


        private void frmHelp_Load(object sender, EventArgs e)
        {
            GridInit();
            FormInit();
            SubQueryData();
        }

        private void GridInit()
        {
            GridSysInit(ref Grid1);
            GridSetRange(ref Grid1);
            if (clsASRS.gsHelpStyle == "CYCLE_SET_TYPE")
            {
                Grid1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;  //字體對齊位置
            }
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
            if (clsASRS.gsHelpStyle == "LOC_S_E")
            {
                oGrid.ColumnCount = 2;
                oGrid.Columns[0].Width = 150; oGrid.Columns[0].Name = "儲位編號";
                oGrid.Columns[1].Width = 150; oGrid.Columns[1].Name = "儲位狀態";
            }
            else if (clsASRS.gsHelpStyle == "LOC_N")
            {
                oGrid.ColumnCount = 2;
                oGrid.Columns[0].Width = 150; oGrid.Columns[0].Name = "儲位編號";
                oGrid.Columns[1].Width = 150; oGrid.Columns[1].Name = "儲位狀態";
            }
            else if (clsASRS.gsHelpStyle == "FOSB")
            {
                oGrid.ColumnCount = 1;
                oGrid.Columns[0].Width = 200; oGrid.Columns[0].Name = "收料序號";
            }
            else if (clsASRS.gsHelpStyle == "LOTNO")
            {
                oGrid.ColumnCount = 1;
                oGrid.Columns[0].Width = 200; oGrid.Columns[0].Name = "LOT NO";
            }
            else if (clsASRS.gsHelpStyle == "CUSTOMER")
            {
                oGrid.ColumnCount = 1;
                oGrid.Columns[0].Width = 200; oGrid.Columns[0].Name = "CUSTOMER";
            }
            else if (clsASRS.gsHelpStyle == "DEVICE")
            {
                oGrid.ColumnCount = 1;
                oGrid.Columns[0].Width = 200; oGrid.Columns[0].Name = "DEVICE";
            }
            else if (clsASRS.gsHelpStyle == "ITEM")
            {
                oGrid.ColumnCount = 1;
                oGrid.Columns[0].Width = 200; oGrid.Columns[0].Name = "ITEM NO";
            }
            else if (clsASRS.gsHelpStyle == "CYCLENO")
            {
                oGrid.ColumnCount = 1;
                oGrid.Columns[0].Width = 200; oGrid.Columns[0].Name = "盤點單號";
            }
            else if (clsASRS.gsHelpStyle == "ACCID")
            {
                oGrid.ColumnCount = 3;
                oGrid.Columns[0].Width = 110; oGrid.Columns[0].Name = "無帳單號";
                oGrid.Columns[1].Width = 100; oGrid.Columns[1].Name = "材料類別";
                oGrid.Columns[2].Width = 100; oGrid.Columns[2].Name = "Lot No";
            }
            else if (clsASRS.gsHelpStyle == "LOC_E")
            {
                oGrid.ColumnCount = 3;
                oGrid.Columns[0].Width = 100; oGrid.Columns[0].Name = "儲位編號";
                oGrid.Columns[1].Width = 100; oGrid.Columns[1].Name = "料盒編號";
                oGrid.Columns[2].Width = 100; oGrid.Columns[2].Name = "儲位狀態";
            }
            else if (clsASRS.gsHelpStyle == "WMS_CRANE")
            {
                oGrid.ColumnCount = 2;
                oGrid.Columns[0].Width = 150; oGrid.Columns[0].Name = "WMS儲位";
                oGrid.Columns[1].Width = 100; oGrid.Columns[1].Name = "料盤ID";
            }
            else if (clsASRS.gsHelpStyle == "CYCLE_SET_TYPE")
            {
                oGrid.ColumnCount = 2;
                oGrid.Columns[0].Width = 70; oGrid.Columns[0].Name = "No"; oGrid.Columns[0].Visible = false;
                oGrid.Columns[1].Width = 200; oGrid.Columns[1].Name = "Type Name";
            }
            else
            {
                oGrid.ColumnCount = 1;
                oGrid.Columns[0].Width = 150; oGrid.Columns[0].Name = "";
            }
            
            oGrid.RowCount = 0;
        }

        private void FormInit()
        {
            Array.Resize<string>(ref clsASRS.gsHelpRtnData, 4);
            clsASRS.gsHelpRtnData[0] = "";
            clsASRS.gsHelpRtnData[1] = "";
            clsASRS.gsHelpRtnData[2] = "";
            clsASRS.gsHelpRtnData[3] = "";

        }

        private void SubQueryData()
        {
            switch (clsASRS.gsHelpStyle)
            {
                case "LOC_S_E": SubLocList(); break;
                case "LOC_N": SubLocList(); break;
                case "FOSB": SubFosbList(); break;
                case "LOTNO": SubLotNoList(); break;
                case "ACCID": SubAccList(); break;
                case "LOC_E": SubLocE_List(); break;
                case "ITEM": SubItemList(); break;
                case "DEVICE": SubDeviceList(); break;
                case "CYCLENO": SubCycleNoList(); break;
                case "WMS_CRANE": SubGetWmsLoc(); break;
                case "CYCLE_SET_TYPE": SubGetCycle_SET(); break;
                case "CUSTOMER": SubCUSTOMERList(); break;
            }
        }

        #region SubLocList() 列出儲位編號清單
        private void SubLocList()
        {
            string strSql = ""; DbDataReader dbRS = null;
            int iCrn = clsTool.INT(clsASRS.gsHelpStyle_Data);

            Grid1.RowCount = 0;

            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };

            strSql = "SELECT LOC,LOCSTS FROM LOC_MST ";
            strSql = strSql + "WHERE CRANE_NO = " + iCrn + " ";
            if (clsASRS.gsHelpStyle == "LOC_S_E")
            {
                strSql = strSql + "AND LOCSTS IN ('E','S') ";
            }
            else if (clsASRS.gsHelpStyle == "LOC_N")
            {
                strSql = strSql + "AND LOCSTS = 'N' ";
            }            
            strSql = strSql + "ORDER BY ROW_X,BAY_Y,LVL_Z ";
            if (clsDB.FunRsSql(strSql, ref dbRS))
            {
                while (dbRS.Read())
                {
                    Grid1.Rows.Add();

                    Grid1[0, Grid1.RowCount - 1].Value = dbRS["LOC"].ToString();
                    Grid1[1, Grid1.RowCount - 1].Value = dbRS["LOCSTS"].ToString();
                }
                dbRS.Close();
            }
            
            clsDB.FunClsDB();
        }
        #endregion

        #region SubFosbList() 列出收料清單
        private void SubFosbList()
        {
            string strSql = ""; DbDataReader dbRS = null;

            Grid1.RowCount = 0;

            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };

            strSql = "SELECT DISTINCT FOSBID FROM LOC_DTL ";
            strSql = strSql + "ORDER BY FOSBID ";
            if (clsDB.FunRsSql(strSql, ref dbRS))
            {
                while (dbRS.Read())
                {
                    Grid1.Rows.Add();

                    Grid1[0, Grid1.RowCount - 1].Value = dbRS["FOSBID"].ToString();
                }
                dbRS.Close();
            }

            clsDB.FunClsDB();
        }
        #endregion

        #region SubLotNoList() 列出批號清單
        private void SubLotNoList()
        {
            string strSql = ""; DbDataReader dbRS = null;

            Grid1.RowCount = 0;

            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };

            strSql = "SELECT DISTINCT LOTNO FROM LOC_DTL ";
            strSql = strSql + "ORDER BY LOTNO ";
            if (clsDB.FunRsSql(strSql, ref dbRS))
            {
                while (dbRS.Read())
                {
                    Grid1.Rows.Add();

                    Grid1[0, Grid1.RowCount - 1].Value = dbRS["LOTNO"].ToString();
                }
                dbRS.Close();
            }

            clsDB.FunClsDB();
        }
        #endregion

        #region SubItemList() 列出Itemno清單
        private void SubItemList()
        {
            string strSql = ""; DbDataReader dbRS = null;

            Grid1.RowCount = 0;

            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };

            strSql = "SELECT DISTINCT ITEMNO FROM LOC_DTL ";
            strSql = strSql + "ORDER BY ITEMNO ";
            if (clsDB.FunRsSql(strSql, ref dbRS))
            {
                while (dbRS.Read())
                {
                    Grid1.Rows.Add();

                    Grid1[0, Grid1.RowCount - 1].Value = dbRS["ITEMNO"].ToString();
                }
                dbRS.Close();
            }

            clsDB.FunClsDB();
        }
        #endregion


        #region SubDeviceList() 列出Device清單
        private void SubDeviceList()
        {
            string strSql = ""; DbDataReader dbRS = null;

            Grid1.RowCount = 0;

            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };

            strSql = "SELECT DISTINCT DEVICE FROM LOC_DTL ";
            strSql = strSql + "ORDER BY DEVICE ";
            if (clsDB.FunRsSql(strSql, ref dbRS))
            {
                while (dbRS.Read())
                {
                    Grid1.Rows.Add();

                    Grid1[0, Grid1.RowCount - 1].Value = dbRS["DEVICE"].ToString();
                }
                dbRS.Close();
            }

            clsDB.FunClsDB();
        }
        #endregion

        #region SubAccList() 列出批號清單
        private void SubAccList()
        {
            DbDataReader dbRS = null;

            Grid1.RowCount = 0;

            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };

            string sSQL = "";

            sSQL = "SELECT ACC_ID,LOTNO,STORE FROM TRNTKT_ACC ";
            sSQL = sSQL + "ORDER BY ACC_ID DESC";
            if (clsDB.FunRsSql(sSQL, ref dbRS))
            {
                while (dbRS.Read())
                {
                    Grid1.Rows.Add();                    
                    Grid1[0, Grid1.RowCount - 1].Value = dbRS["ACC_ID"].ToString();
                    Grid1[1, Grid1.RowCount - 1].Value = dbRS["STORE"].ToString();
                    Grid1[2, Grid1.RowCount - 1].Value = dbRS["LOTNO"].ToString();
                }
                dbRS.Close();
            }

            clsDB.FunClsDB();
        }
        #endregion

        #region SubLocE_List() 列出收料清單
        private void SubLocE_List()
        {
            string strSql = ""; DbDataReader dbRS = null;

            Grid1.RowCount = 0;

            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };

            strSql = "SELECT LOC,LOCSTS,LOCID FROM LOC_MST ";
            strSql = strSql + "WHERE LOCSTS = 'E' ";           
            strSql = strSql + "ORDER BY ROW_X,BAY_Y,LVL_Z ";
            if (clsDB.FunRsSql(strSql, ref dbRS))
            {
                while (dbRS.Read())
                {
                    Grid1.Rows.Add();

                    Grid1[0, Grid1.RowCount - 1].Value = dbRS["LOC"].ToString();
                    Grid1[1, Grid1.RowCount - 1].Value = dbRS["LOCID"].ToString();
                    Grid1[2, Grid1.RowCount - 1].Value = dbRS["LOCSTS"].ToString();
                }
                dbRS.Close();
            }

            clsDB.FunClsDB();
        }
        #endregion

        #region SubCycleNoList() 列出CycleNo清單
        private void SubCycleNoList()
        {
            string strSql = ""; DbDataReader dbRS = null;

            Grid1.RowCount = 0;

            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };

            strSql = "SELECT DISTINCT CYCLENO FROM CYCLE ";
            strSql = strSql + "ORDER BY CYCLENO ";
            if (clsDB.FunRsSql(strSql, ref dbRS))
            {
                while (dbRS.Read())
                {
                    Grid1.Rows.Add();

                    Grid1[0, Grid1.RowCount - 1].Value = dbRS["CYCLENO"].ToString();
                }
                dbRS.Close();
            }

            clsDB.FunClsDB();
        }
        #endregion

        #region SubCUSTOMERList() 列出CUSTOMER清單
        private void SubCUSTOMERList()
        {
            string strSql = ""; DbDataReader dbRS = null;

            Grid1.RowCount = 0;

            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };

            strSql = "SELECT DISTINCT CUSTOMER FROM LOC_DTL ";
            strSql = strSql + "ORDER BY CUSTOMER ";
            if (clsDB.FunRsSql(strSql, ref dbRS))
            {
                while (dbRS.Read())
                {
                    Grid1.Rows.Add();

                    Grid1[0, Grid1.RowCount - 1].Value = dbRS["CUSTOMER"].ToString();
                }
                dbRS.Close();
            }

            clsDB.FunClsDB();
        }
        #endregion
        

        private void SubGetWmsLoc()
        {
            string strSql = ""; DbDataReader dbRS = null;

            Grid1.RowCount = 0;

            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };

            strSql = "SELECT M.LOCID,S.WMS_LOC FROM LOC_MST M, SPIL_WMS_LOC S ";
            strSql = strSql + "WHERE M.LOCID = S.ASRS_LOCID ";
            strSql = strSql + "AND M.LOCSTS = 'S' ";
            strSql = strSql + "AND M.CRANE_NO = " + clsASRS.gsHelpStyle_MLoc + " ";
            strSql = strSql + "ORDER BY M.ROW_X,M.BAY_Y,M.LVL_Z ";
            if (clsDB.FunRsSql(strSql, ref dbRS))
            {
                while (dbRS.Read())
                {
                    Grid1.Rows.Add();

                    Grid1[0, Grid1.RowCount - 1].Value = dbRS["WMS_LOC"].ToString();
                    Grid1[1, Grid1.RowCount - 1].Value = dbRS["LOCID"].ToString();
                }
                dbRS.Close();
            }

            clsDB.FunClsDB();

        }


        private void SubGetCycle_SET()
        {
            string strSql = ""; DbDataReader dbRS = null;

            Grid1.RowCount = 0;

            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };

            strSql = "SELECT TYPE_NO,TYPE_NAME FROM CYCLE_SET ";
            strSql = strSql + "WHERE CYCLE_TYPE = '" + clsASRS.gsHelpStyle_Data + "' ";           

            if (clsDB.FunRsSql(strSql, ref dbRS))
            {
                while (dbRS.Read())
                {
                    Grid1.Rows.Add();

                    Grid1[0, Grid1.RowCount - 1].Value = dbRS["TYPE_NO"].ToString();
                    Grid1[1, Grid1.RowCount - 1].Value = dbRS["TYPE_NAME"].ToString();
                }
                dbRS.Close();
            }

            clsDB.FunClsDB();


        }



        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (Grid1.RowCount > 0)
            {
                if (iSelRow >= 0)
                {
                    if (clsASRS.gsHelpStyle == "LOC_E")
                    {
                        //LOC+LOCID
                        clsASRS.gsHelpRtnData[0] = Grid1[0, iSelRow].Value.ToString() + "," + Grid1[1, iSelRow].Value.ToString();
                    }
                    else if (clsASRS.gsHelpStyle == "CYCLE_SET_TYPE")
                    {
                        clsASRS.gsHelpRtnData[0] = Grid1[0, iSelRow].Value.ToString();
                        clsASRS.gsHelpRtnData[1] = Grid1[1, iSelRow].Value.ToString();
                    }
                    else
                    {
                        clsASRS.gsHelpRtnData[0] = Grid1[0, iSelRow].Value.ToString();
                    }
                }
            }

            this.Close();
        }

        private void cmdQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Grid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            iSelRow = e.RowIndex;
        }

 
    }
}
