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
    public partial class frm_IQC_DATA : Form
    {

        #region Grid1 Parameter
        int iCol_RCVNO = 0;
        int iCol_LOTNO = 1;
        int iCol_PIECE = 2;
        int iCol_DIE = 3;
        int iCol_USER_NAME = 4;
        int iCol_TXN_DATE = 5;
        int iCol_STATUS = 6;
        int iCol_Counts = 7;
        #endregion

        public frm_IQC_DATA()
        {
            InitializeComponent();
        }
        
        private void frm_IQC_DATA_Load(object sender, EventArgs e)
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

            oGrid.Columns[iCol_RCVNO].Width = 150; oGrid.Columns[iCol_RCVNO].Name = "收料序號";
            oGrid.Columns[iCol_LOTNO].Width = 100; oGrid.Columns[iCol_LOTNO].Name = "批號";
            oGrid.Columns[iCol_PIECE].Width = 50; oGrid.Columns[iCol_PIECE].Name = "枚數";
            oGrid.Columns[iCol_DIE].Width = 50; oGrid.Columns[iCol_DIE].Name = "片數";
            oGrid.Columns[iCol_USER_NAME].Width = 80; oGrid.Columns[iCol_USER_NAME].Name = "IQC工號";
            oGrid.Columns[iCol_TXN_DATE].Width = 100; oGrid.Columns[iCol_TXN_DATE].Name = "簽收時間";
            oGrid.Columns[iCol_STATUS].Width = 160; oGrid.Columns[iCol_STATUS].Name = "狀態";

            int i = 0;
            for (i = 0; i <= oGrid.ColumnCount - 1; i++)
            {
                oGrid.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            oGrid.RowCount = 0;
        }

        private void FormInit()
        {
            FormCls();
        }

        private void FormCls()
        {
            txtIQCID.Text = "";
            txtLotNo1.Text = "";
            txtLotNo2.Text = "";
            txtRcvNo1.Text = "";
            txtRcvNo2.Text = "";
            chkDate.Checked = false;
            txtLotNoCount.Text = "";
            Grid1.RowCount = 0;
        }

        private void btnCls_Click(object sender, EventArgs e)
        {
            FormCls();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            SubQuery();
        }

        private void SubQuery()
        {
            string strSql = ""; DbDataReader dbRS = null;
            string sSQL_tmp = "";
            Grid1.RowCount = 0;

            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };
            strSql = "SELECT * FROM SPIL_IQC ";

            if (txtIQCID.Text != "")
            {
                if (sSQL_tmp == "")
                {
                    sSQL_tmp = "WHERE USER_NAME = '" + txtIQCID.Text + "' ";
                }
                else
                {
                    sSQL_tmp = sSQL_tmp + "AND USER_NAME = '" + txtIQCID.Text + "' ";
                }
            }

            if (txtLotNo1.Text != "")
            {
                if (txtLotNo2.Text != "")
                {
                    if (sSQL_tmp == "")
                    {
                        sSQL_tmp = "WHERE LOTNO >= '" + txtLotNo1.Text + "' AND LOTNO <= '" + txtLotNo2.Text + "' ";
                    }
                    else
                    {
                        sSQL_tmp = sSQL_tmp + "AND LOTNO >= '" + txtLotNo1.Text + "' AND LOTNO <= '" + txtLotNo2.Text + "' ";
                    }
                }
                else
                {
                    if (sSQL_tmp == "")
                    {
                        sSQL_tmp = "WHERE LOTNO = '" + txtLotNo1.Text + "' ";
                    }
                    else
                    {
                        sSQL_tmp = sSQL_tmp + "AND LOTNO = '" + txtLotNo1.Text + "' ";
                    }
                }
            }

            if (txtRcvNo1.Text != "")
            {
                if (txtRcvNo2.Text != "")
                {
                    if (sSQL_tmp == "")
                    {
                        sSQL_tmp = "WHERE RCVNO >= '" + txtRcvNo1.Text + "' AND RCVNO <= '" + txtRcvNo2.Text + "' ";
                    }
                    else
                    {
                        sSQL_tmp = sSQL_tmp + "AND RCVNO >= '" + txtRcvNo1.Text + "' AND RCVNO <= '" + txtRcvNo2.Text + "' ";
                    }
                }
                else
                {
                    if (sSQL_tmp == "")
                    {
                        sSQL_tmp = "WHERE RCVNO = '" + txtRcvNo1.Text + "' ";
                    }
                    else
                    {
                        sSQL_tmp = sSQL_tmp + "AND RCVNO = '" + txtRcvNo1.Text + "' ";
                    }
                }
            }

            if (chkDate.Checked == true)
            {
                string sDate1 = ""; string sDate2 = "";
                sDate1 = txtDate1.Value.ToString("yyyyMMdd") + "000000";
                sDate2 = txtDate2.Value.ToString("yyyyMMdd") + "999999";

                if (sSQL_tmp == "")
                {
                    sSQL_tmp = "WHERE TXN_DATE >= '" + sDate1 + "' AND TXN_DATE <= '" + sDate2 + "' ";
                }
                else
                {
                    sSQL_tmp = sSQL_tmp + "AND TXN_DATE >= '" + sDate1 + "' AND TXN_DATE <= '" + sDate2 + "' ";
                }
            }

            strSql = strSql + sSQL_tmp;
            strSql = strSql + "ORDER BY RCVNO ";

            if (clsDB.FunRsSql(strSql, ref dbRS))
            {
                while (dbRS.Read())
                {
                    Grid1.Rows.Add();
                    Grid1[iCol_RCVNO, Grid1.RowCount - 1].Value = dbRS["RCVNO"].ToString();
                    Grid1[iCol_LOTNO, Grid1.RowCount - 1].Value = dbRS["LOTNO"].ToString();
                    Grid1[iCol_PIECE, Grid1.RowCount - 1].Value = dbRS["PIECE"].ToString();
                    Grid1[iCol_DIE, Grid1.RowCount - 1].Value = dbRS["DIE"].ToString();
                    Grid1[iCol_USER_NAME, Grid1.RowCount - 1].Value = dbRS["USER_NAME"].ToString();
                    Grid1[iCol_TXN_DATE, Grid1.RowCount - 1].Value = dbRS["TXN_DATE"].ToString();
                    Grid1[iCol_STATUS, Grid1.RowCount - 1].Value = FunGetStatus(dbRS["STATUS"].ToString());
                }
                dbRS.Close();
            }

            txtLotNoCount.Text = clsASRS.FunGetFosbCnt(ref Grid1, iCol_RCVNO).ToString();

            clsDB.FunClsDB();
        }

        private string FunGetStatus(string sData)
        {
            string sValue;
            switch (sData)
            {
                case "0": sValue = "0:未簽收"; break;
                case "1": sValue = "1:己簽收待回報"; break;
                case "2": sValue = "2:己簽收己回報WMS"; break;
                default:
                    sValue = sData; break;
            }
            return sValue;
        }

        private void cmdExport_Click(object sender, EventArgs e)
        {
            clsTool.funGridToCsv(Grid1);
        }

    }
}
