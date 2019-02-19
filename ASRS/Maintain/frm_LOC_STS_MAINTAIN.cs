using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ASRS
{
    public partial class frm_LOC_STS_MAINTAIN : frm_LOC_STS
    {
        public frm_LOC_STS_MAINTAIN()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // frm_LOC_STS_MAINTAIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(1012, 606);
            this.Name = "frm_LOC_STS_MAINTAIN";
            this.ResumeLayout(false);

        }
        public override void Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                base.Grid_CellClick(sender, e);

                if (!clsDB.FunOpenDB())
                {
                    throw new Exception("資料庫開啟失敗!");
                }
                #region 找目前tabPage內的grid
                DataGridView dgv = null;

                for (int count = 0; count != tabControl1.SelectedTab.Controls[0].Controls.Count; count++)
                {
                    if (tabControl1.SelectedTab.Controls[0].Controls[count].GetType() == typeof(DataGridView))
                    {
                        dgv = (DataGridView)tabControl1.SelectedTab.Controls[0].Controls[count];
                    }

                }
                #endregion
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
                #region 確認原本儲位狀態 set 條件
                string strSql,strAsk="";
                switch (dgv[e.ColumnIndex, e.RowIndex].Value.ToString())
                {
                    case"^":
                        return;
                        break;
                    case "X":
                        strSql = "update loc_mst set locsts=oldsts where loc='" + lbl.Text + "'";
                        strAsk = "是否解禁儲位";
                        break;
                    default:
                        strSql = "update loc_mst set oldsts=locsts,locsts='X' where loc='" + lbl.Text + "'";
                        strAsk = "是否禁用儲位";
                        break;
                }
                #endregion
                #region 詢問視窗
                //DialogResult dr = new DialogResult();
                bool dr = clsMSG.ShowQuestionMsg(strAsk + lbl.Text);
                //dr = MessageBox.Show(strAsk + lbl.Text, "詢問", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == false)
                {
                    return;
                }
                #endregion
                if (!clsDB.FunExecSql(strSql))
                {
                    throw new Exception("執行失敗 儲位:"+lbl.Text);
                }
                Query();
                clsMSG.ShowInformationMsg("處理成功");
                //MessageBox.Show("處理成功");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {

        }

        private void btnQuery_Click_1(object sender, EventArgs e)
        {

        }

        private void Grid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
       
    }
}
