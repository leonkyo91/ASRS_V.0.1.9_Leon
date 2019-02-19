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
    public partial class frm_LOC_STS : Form
    {
    
        public frm_LOC_STS():base()
        {
            InitializeComponent();
            frmLoad();
        }

        private void frmLoad() 
        {
            cboCrn.Text = "1";
            this.cboCrn.SelectedIndexChanged += new System.EventHandler(this.cboCrn_SelectedIndexChanged);


            GridSetRange(ref Grid1);
            GridSetRange(ref Grid2);
            GridSetRange(ref Grid3);
            GridSetRange(ref Grid4);            
        }

        private void GridSetRange(ref DataGridView oGrid)
        {
            int i = 0;
            for (i = 0; i <= oGrid.ColumnCount - 1; i++)
            {
                oGrid.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        static int row_x;
        private void btnQuery_Click(object sender, EventArgs e)
        {
            Query();
          
        }
        public virtual void Query() 
        {    
            try
            {

               
                if (cboCrn.Text == "")
                {
                    throw new Exception("請選擇高架車編號");
                }
                if (!clsDB.FunOpenDB())
                {
                    throw new Exception("資料庫開啟失敗");
                }

                lblLocID.Text = "";

                string strSql;
                DbDataReader dbRs=null;
                
                row_x = (int.Parse(cboCrn.Text[0].ToString()) - 1) * 4+ int.Parse(tabControl1.SelectedTab.Text[2].ToString());

                strSql = "select * from loc_mst where row_x='"+row_x.ToString()+"' order by lvl_z desc, bay_y";

                if (!clsDB.FunRsSql(strSql, ref dbRs))
                {
                    return;
                    //throw new Exception("查詢失敗");
                }

                #region 找目前tabPage內的grid
                DataGridView dgv=null;
             
                for (int con = 0; con != tabControl1.SelectedTab.Controls[0].Controls.Count;con++ )
                {
                    if (tabControl1.SelectedTab.Controls[0].Controls[con].GetType() == typeof(DataGridView))
                    {
                       dgv = (DataGridView)tabControl1.SelectedTab.Controls[0].Controls[con];
                       dgv.CellClick -= new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_CellClick);
                       dgv.CellDoubleClick -= new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_CellDoubleClick);
                       dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_CellClick);
                       dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_CellDoubleClick);
                       GridSysInit(ref dgv);
                       ProcGrid(ref dgv, ref dbRs);
                    }
                    else 
                        if(tabControl1.SelectedTab.Controls[0].Controls[con].GetType()==typeof(Label))
                        {
                            if (((Label)tabControl1.SelectedTab.Controls[0].Controls[con]).Text != "儲位編號")
                            {
                                ((Label)tabControl1.SelectedTab.Controls[0].Controls[con]).Text = "";
                            }
                        }
                }
                #endregion
                #region get lblFOSB DATA
                if (!dbRs.IsClosed)
                    dbRs.Close();
                strSql = "select (select count(*) E from loc_mst where LOCSTS='E') E , count(*) S from loc_mst where LOCSTS IN ('I','O','C','S') ";
                       

                if (!clsDB.FunRsSql(strSql, ref dbRs))
                {
                    return;
                }
               
                dbRs.Read();
                lblFOSB_2.Text = dbRs["S"].ToString();
                lblFOSB_1.Text = dbRs["E"].ToString();
                #endregion
            }
            catch(Exception ex) 
            {
                //MessageBox.Show(ex.Message,"警告");
            }
        }
        private void ProcGrid(ref DataGridView Grid1,ref DbDataReader dbRs) 
        {
            Grid1.RowCount = 8;
            Grid1.ColumnCount = 63;
            for (int r = 0; r != Grid1.RowCount; r++)
            {
                for (int c = 0; c != Grid1.ColumnCount; c++)
                {
                    Grid1[c, r].Value = "^";
                    Grid1.Rows[r].Cells[c].Style.BackColor = lblColor_Z.BackColor;
                }
            }
            int N = 0, E = 0, I = 0, O = 0, S = 0, C = 0, X = 0, H = 0, L = 0;
            while (dbRs.Read())
            {
                int x = int.Parse(dbRs["bay_y"].ToString()) - 1;
                int y = 8 - int.Parse(dbRs["lvl_z"].ToString());
                Color col = Color.Black;

                //if (int.Parse(dbRs["bay_y"].ToString()) == 6 && int.Parse(dbRs["lvl_z"].ToString())==4)
                //{
                //    return;
                //}

                switch (dbRs["locsts"].ToString())
                {
                    case "N":
                        N++;
                        col = lblColor_N.BackColor;
                        break;
                    case "E":
                        E++;
                        col = lblColor_E.BackColor;
                        break;
                    case"I":
                        I++;
                        col = lblColor_I.BackColor;
                        break;
                    case"O":
                        O++;
                        col = lblColor_O.BackColor;
                        break;
                    case"S":
                        S++;
                        col = lblColor_S.BackColor;
                        break;
                    case"C":
                        C++;
                        col = lblColor_C.BackColor;
                        break;
                    case "X":
                        X++;
                        col = lblColor_X.BackColor;
                        break;
                    case "H":
                        H++;
                        col = lblColor_H.BackColor;
                        break;
                    case "L":
                        L++;
                        col = lblColor_L.BackColor;
                        break;
                }
                Grid1[x, y].Value = dbRs["locsts"].ToString();
                Grid1.Rows[y].Cells[x].Style.BackColor = col;

            }

            lblSts_C.Text = C.ToString();
            lblSts_E.Text = E.ToString();
            lblSts_I.Text = I.ToString();
            lblSts_N.Text = N.ToString();
            lblSts_O.Text = O.ToString();
            lblSts_S.Text = S.ToString();
            lblSts_X.Text = X.ToString();
            lblSts_H.Text = H.ToString();
            lblSts_L.Text = L.ToString();


          

            Form.CheckForIllegalCrossThreadCalls = false;
           // ParameterizedThreadStart ParStart = new ParameterizedThreadStart(deleg);
            Thread gridHeader = new Thread(deleg);
            gridHeader.Start(Grid1);
            
          
        }
        public virtual void Grid_CellClick(object sender, DataGridViewCellEventArgs e) 
        {
            try 
            {
                
                if (!clsDB.FunOpenDB())
                {
                    throw new Exception("資料庫開啟失敗!");
                }
                int row =Math.Abs(e.RowIndex - 8);      //V.0.1
                int colu = e.ColumnIndex+1;
                string loc = row_x.ToString().PadLeft(2, '0') + colu.ToString().PadLeft(2, '0') + row.ToString().PadLeft(2, '0');
                string strSql = "select * from loc_mst where loc="+loc;

                DbDataReader dbRs = null;
                bool LocFlag = clsDB.FunRsSql(strSql, ref dbRs);
                //if (!clsDB.FunRsSql(strSql, ref dbRs))
                //{
                    
                //    return;
                //    //throw new Exception("查詢失敗!");
                //}


                #region 找目前tanPage內的label
                Label lbl = null;
                for (int i = 0; i != tabControl1.SelectedTab.Controls[0].Controls.Count; i++)
                {
                    if (tabControl1.SelectedTab.Controls[0].Controls[i].GetType() == typeof(Label))
                    {
                        if (tabControl1.SelectedTab.Controls[0].Controls[i].Text != "儲位編號")
                            lbl = (Label)tabControl1.SelectedTab.Controls[0].Controls[i];
                    }
                }
                #endregion

                #region 判斷有無此儲位 無則清值
                if (LocFlag)
                {
                    dbRs.Read();
                    lblLocID.Text = dbRs["locid"] == null ? "" : dbRs["locid"].ToString();
                    lbl.Text = dbRs["loc"].ToString();
                }
                else
                {
                    lblLocID.Text = "";
                    lbl.Text = "";
                }
                #endregion



            }
            catch (Exception ex) { MessageBox.Show( ex.Message,"警告"); }

        }
        public virtual void Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        { }
        private void deleg(object grid1)
        {
            DataGridView Grid1 = (DataGridView)grid1;
           // Grid1.Enabled = false;
            Grid1.Hide();
            showRow(ref Grid1);
            showColumn(ref Grid1);
           
        }     
        private void showColumn(ref DataGridView Grid1) 
        {
            this.UseWaitCursor = true;
            int i = 0;
        
            while (i != Grid1.ColumnCount)
            {
               // Grid1.Show();
                Grid1.Columns[i].HeaderText = (i + 1).ToString() ;
                Grid1.Columns[i].Width = 20;
                i++;
             
            }

            Grid1.Show();
            this.UseWaitCursor = false;
        }
        private void showRow(ref DataGridView Grid1)
        {
            Grid1.RowHeadersWidth = 80;
            int i = 0;
            while (i != Grid1.RowCount)
            {
               
                Grid1.Rows[i].HeaderCell.Value = (Grid1.RowCount - i).ToString() + "層";
                Grid1.Rows[i].Height = 35;
                i++;
              
               
            }
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

            Query();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }
        private void cboCrn_SelectedIndexChanged(object sender, EventArgs e)
        {
            Query();
        }
        private void GridSysInit(ref DataGridView oGrid)
        {
            try
            {
                //指定 Column 的字體
                oGrid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.WhiteSmoke;
                oGrid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                oGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

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
                oGrid.AllowUserToOrderColumns = false;
               
                oGrid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;  //字體對齊位置
            }
            catch (Exception ex)
            {
                clsMSG.ShowWarningMsg(clsMSG.MSG.SYSTEM_NG + " " + ex.ToString());
            }
        }

        private void frm_LOC_STS_Load(object sender, EventArgs e)
        {

        }
      

        

    }
   
}
