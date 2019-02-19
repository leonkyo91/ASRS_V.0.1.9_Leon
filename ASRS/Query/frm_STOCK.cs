using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Common;
using System.Threading;

namespace ASRS
{
    public partial class frm_STOCK : Form
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
        int iCol_WAFERQTY= 9;
        int iCol_SHIPQTY = 10;
        int iCol_CHKIQC = 11;
        int iCol_INDATE = 12;
        int iCol_Counts = 13;
        #endregion


        public frm_STOCK()
        {
            InitializeComponent();
            frmLoad();
        }

        private void frmLoad() 
        {
            RdBtn_3.Checked = true;
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
            oGrid.Columns[iCol_LOCSTS].Width = 60; oGrid.Columns[iCol_LOCSTS].Name = "儲位狀態";
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
            oGrid.Columns[iCol_INDATE].Width = 120; oGrid.Columns[iCol_INDATE].Name = "入庫日期";

            oGrid.RowCount = 0;
        }


        private void btnQuery_Click(object sendr, EventArgs e)
        {
            Query();
        }


        private void Query()
        {
            Grid1.RowCount = 0;
            txtLotNoCount.Text = "";

            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };

            #region Query
            DbDataReader dbRs = null;
            string strSql = "select * from loc_mst m left join loc_dtl d on m.loc=d.loc";                
            foreach (RadioButton rb in GroupBox2.Controls)
            {
                if (rb.Checked)
                {
                    switch (rb.Name)
                    {
                        case "RdBtn_1":
                            strSql += " where ondata='n' and m.locsts in ('S','O','X')";
                            break;
                        case "RdBtn_2":
                            strSql += " where ondata='y' and m.locsts in ('S','O','X')";
                            break;
                        case "RdBtn_3":
                            strSql+= " where m.locsts in ('S','O','X')";
                            break;
                          
                    }
                }                    
            }

            if (!clsDB.FunRsSql(strSql, ref dbRs))
            {
                clsDB.FunClsDB();
                return;
                //
                //throw new Exception("查詢失敗或查無資料!");
            }
            #endregion

            #region Data
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
                Grid1[iCol_INDATE, x].Value = dbRs["indate"].ToString();
                x++;
            }
            dbRs.Close();

            #endregion

            txtLotNoCount.Text = clsASRS.FunGetFosbCnt(ref Grid1, iCol_FOSBID).ToString();

            clsDB.FunClsDB();
                
        }

        private void cmdExport_Click(object sender, EventArgs e)
        {
            clsTool.funGridToCsv(Grid1);
        }

        private void cmdEnd_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_STOCK_Load(object sender, EventArgs e)
        {

        }


    }
}
