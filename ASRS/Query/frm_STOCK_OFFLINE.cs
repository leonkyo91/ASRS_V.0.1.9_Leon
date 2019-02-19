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
    public partial class frm_STOCK_OFFLINE : Form
    {
        public frm_STOCK_OFFLINE()
        {
            InitializeComponent();
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
                if (obj.GetType() == typeof(TextBox) && ((TextBox)obj).Text == "")
                {
                    switch (((TextBox)obj).Name)
                    {
                        case "txtLot2":
                            txtLot2.Text = txtLot1.Text;
                            break;
                        case "txtAccID2":
                            txtAccID2.Text = txtAccID1.Text;
                            break;
                      
                    }
                }
            }
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

                DbDataReader dbRs = null;
                string strSql = "select * from TRNTKT_ACC t,loc_dtl d,loc_mst m where t.acc_id=d.acc_id and m.loc=d.loc";
                string strCondition = " ";
                for (int i = 0; i != GroupBox2.Controls.Count; i++)
                {
                    object obj=GroupBox2.Controls[i];
                    switch (obj.GetType().FullName)
                    {
                        case "System.Windows.Forms.TextBox":
                                 switch (((TextBox)obj).Name)
                                {
                                 
                                    case "txtLot1":
                                        strCondition += ((TextBox)obj).Text == "" ? "" : strCondition == " where " ? " t.lotno>= " : " and t.lotno>=" + ((TextBox)obj).Text;
                                        break;
                                    case "txtLot2":
                                        strCondition += ((TextBox)obj).Text == "" ? "" : strCondition == " where " ? " t.lotno<= " : " and t.lotno<=" + ((TextBox)obj).Text;
                                        break;
                                    case "txtAccID1":
                                        strCondition += ((TextBox)obj).Text == "" ? "" :strCondition==" where "?" t.acc_id>= ": " and t.acc_id>=" + ((TextBox)obj).Text;
                                        break;
                                    case "txtAccID2":
                                        strCondition +=((TextBox)obj).Text==""?"":strCondition==" where "?" t.acc_id<= ": " and t.acc_id<=" + ((TextBox)obj).Text;
                                        break;
                                }
                            break;
                        case"System.Windows.Forms.ComboBox":
                            switch(((ComboBox)obj).Name)
                            {
                                case"cboStore":
                                    strCondition +=((ComboBox)obj).Text==""?"":strCondition==" where "?" t.store= ": " and t.store="+((ComboBox)obj).Text;
                                    break;
                            }
                            break;
                        default:
                            break;

                    }
                }
                if (strCondition == " ")
                { }
                else
                {
                    strSql += strCondition;
                }

                    if (!clsDB.FunRsSql(strSql, ref dbRs))
                    {
                        throw new Exception("查詢失敗或查無資料!");
                    }

                int x = 0;
                while (dbRs.Read())
                {
                    Grid1.Rows.Add();
                    Grid1[0, x].Value = dbRs["loc"].ToString();
                    Grid1[1, x].Value = dbRs["locsts"].ToString();
                    Grid1[2, x].Value = dbRs["locid"].ToString();
                    Grid1[3, x].Value = dbRs["acc_id"].ToString();
                    Grid1[4, x].Value = dbRs["Itemno"].ToString();
                    Grid1[5, x].Value = dbRs["customer"].ToString();
                    Grid1[6, x].Value = dbRs["device"].ToString();
                    Grid1[7, x].Value = dbRs["lotno"].ToString();
                    Grid1[8, x].Value = dbRs["offqty"].ToString();
                    Grid1[9, x].Value = dbRs["waferqty"].ToString();
                    Grid1[10, x].Value = dbRs["shipqty"].ToString();
                    Grid1[11, x].Value = dbRs["chkiqc"].ToString();
                    Grid1[12, x].Value = dbRs["indate"].ToString();
                    x++;
                }
                dbRs.Close();

                #region 抓取批數
                string sql = "select count( distinct FOSBID) cnt   from TRNTKT_ACC t,loc_dtl d where t.acc_id=d.acc_id";
                DbDataReader dbrs1 = null;
                for (int i = 0; i != GroupBox2.Controls.Count; i++)
                {
                    object obj = GroupBox2.Controls[i];
                    switch (obj.GetType().FullName)
                    {
                        case "System.Windows.Forms.TextBox":
                            switch (((TextBox)obj).Name)
                            {

                                case "txtLot1":
                                    sql += ((TextBox)obj).Text == "" ? "" : " and t.lotno>=" + ((TextBox)obj).Text;
                                    break;
                                case "txtLot2":
                                    sql += ((TextBox)obj).Text == "" ? "" : " and t.lotno<=" + ((TextBox)obj).Text;
                                    break;
                                case "txtAccID1":
                                    sql += ((TextBox)obj).Text == "" ? "" : " and t.acc_id>=" + ((TextBox)obj).Text;
                                    break;
                                case "txtAccID2":
                                    sql += ((TextBox)obj).Text == "" ? "" : " and t.acc_id<=" + ((TextBox)obj).Text;
                                    break;
                            }
                            break;
                        case "System.Windows.Forms.ComboBox":
                            switch (((ComboBox)obj).Name)
                            {
                                case "cboStore":
                                    sql += ((ComboBox)obj).Text == "" ? "" : " and t.store=" + ((ComboBox)obj).Text;
                                    break;
                            }
                            break;
                        default:
                            break;

                    }
                }
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
                //MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            clsTool.showForm(txtLot1, "lotno", "TRNTKT_ACC");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clsTool.showForm(txtLot2, "lotno", "TRNTKT_ACC");
        }

        private void btnHelp_ACCID1_Click(object sender, EventArgs e)
        {
            clsTool.showForm(txtAccID1, "acc_id", "TRNTKT_ACC");
        }

        private void btnHelp_ACCID2_Click(object sender, EventArgs e)
        {
            clsTool.showForm(txtAccID2, "acc_id", "TRNTKT_ACC");
        }

        private void frm_STOCK_OFFLINE_Load(object sender, EventArgs e)
        {
            FormInit();
        }

        private void FormInit()
        {
            clsASRS.SetStore(ref cboStore);
        }
    }
}
