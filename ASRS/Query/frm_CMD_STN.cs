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
    public partial class frm_CMD_STN : Form
    {
        public frm_CMD_STN()
        {
            InitializeComponent();
            frmLoad();
        }
        private void frmLoad()
        {
            clsASRS.SubCboSetStnNo(ref cboStnNo);
            cboStnNo.SelectedIndex = 1;
        }

        private void btnCls_Click(object sender, EventArgs e)
        {
            clsTool.finished(this);
        }

        private void cmdExport_Click(object sender, EventArgs e)
        {
            clsTool.funGridToCsv(Grid1);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            Query();
           
        }
    
        private void Query()
        {
            try
            {
                Grid1.RowCount = 0;
                txtLotNoCount.Text = "";
                if (!clsDB.FunOpenDB())
                {
                    throw new Exception("資料庫開啟失敗");
                }

                string strSql = "select * from cmd_mst m left join cmd_dtl d on m.cmdsno=d.cmdsno " + (cboStnNo.Text != "" ? ("where stnno='" + cboStnNo.Text + "'") : "");//("where stnno='"+cboStnNo.Text[0]+"'"):"";
      
                DbDataReader dbRs = null;

                if (!clsDB.FunRsSql(strSql, ref dbRs))
                {
                    throw new Exception("查詢失敗或查無資料!");
                }

                int x = 0;

                while (dbRs.Read())
                {
                    Grid1.Rows.Add();
                    Grid1[0, x].Value = dbRs["cmdsno"].ToString();
                    Grid1[1, x].Value = dbRs["cmdsts"].ToString();
                    Grid1[2, x].Value = dbRs["cmdmode"].ToString();
                    Grid1[3, x].Value = dbRs["prt"].ToString();
                    Grid1[4, x].Value = dbRs["stnno"].ToString();
                    Grid1[5, x].Value = dbRs["iotyp"].ToString();
                    Grid1[6, x].Value = dbRs["loc"].ToString();
                    Grid1[7, x].Value = dbRs["locid"].ToString();
                    Grid1[8, x].Value = dbRs["avail"].ToString();
                    Grid1[9, x].Value = dbRs["userid"].ToString();
                    Grid1[10, x].Value = dbRs["acttime"].ToString();
                    x++;
                }
                dbRs.Close();
                #region 抓取批數
                string sql = "select count( distinct FOSBID) cnt from cmd_mst m left join cmd_dtl d on m.cmdsno=d.cmdsno " + (cboStnNo.Text != "" ? ("where stnno='" + cboStnNo.Text + "'") : "");//("where stnno='"+cboStnNo.Text[0]+"'"):"";

                DbDataReader dbrs1 = null;
                //if (strCondition.Trim() == "where")
                //{

                //}
                //else
                //{
                //    sql += strCondition;
                //}
                if (!clsDB.FunRsSql(sql, ref dbrs1))
                {
                    throw new Exception("查詢失敗或查無資料!");
                }
                dbrs1.Read();
                txtLotNoCount.Text = dbrs1["cnt"].ToString();
                #endregion

            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
            }

        }
        private void Grid1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (!clsDB.FunOpenDB())
                {
                    throw new Exception("資料庫開啟失敗");
                }
                int row = e.RowIndex;
                string cmdSno = Grid1[0, row].Value.ToString();
                string strSql = "";
                DbDataReader dbRs = null;
                strSql = "select * from cmd_dtl where cmdSno=" + cmdSno;
                if (!clsDB.FunRsSql(strSql, ref dbRs))
                {
                    throw new Exception("查詢失敗或查無資料");
                }
                Grid2.RowCount = 0;
                dbRs.Read();
                Grid2.Rows.Add();
                Grid2[0, 0].Value = dbRs["cmdsno"].ToString();
                Grid2[1, 0].Value = dbRs["itemno"].ToString();
                Grid2[2, 0].Value = dbRs["device"].ToString();
                Grid2[3, 0].Value = dbRs["lotno"].ToString();
                Grid2[4, 0].Value = dbRs["store"].ToString();
                Grid2[5, 0].Value = dbRs["offqty"].ToString();
                Grid2[6, 0].Value = dbRs["waferqty"].ToString();
                Grid2[7, 0].Value = dbRs["shipqty"].ToString();
                Grid2[8, 0].Value = dbRs["offactqty"].ToString();
                Grid2[9, 0].Value = dbRs["waferactqty"].ToString();



            }
            catch (Exception ex) 
            {
                //MessageBox.Show(ex.Message); 
            }
        }
    }
}
