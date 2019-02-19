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
    public partial class frmHelp_PRT : Form
    {
        public frmHelp_PRT()
        {
            InitializeComponent();
        }

        private void frmHelp_PRT_Load(object sender, EventArgs e)
        {
            string[] sData = new string[0];
            sData = clsASRS.gsHelpStyle_Data.Split(',');

            lblCmdSno.Text = sData[0];
            lblLocID.Text = sData[1];
            txtCmdPrt.Text = sData[2];
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            string strSql = ""; 

            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };

            clsDB.FunCommitCtrl("BEGIN");
            strSql = "UPDATE CMD_MST SET PRT = '" + txtCmdPrt.Text.Trim() + "' ";
            strSql = strSql + "WHERE CMDSNO = '" + lblCmdSno.Text + "' AND LOCID = '" + lblLocID.Text + "' ";
            if (clsDB.FunExecSql(strSql))
            {
                clsDB.FunCommitCtrl("COMMIT");
                clsMSG.ShowInformationMsg("命令修改完成");
            }
            else
            {
                clsDB.FunCommitCtrl("ROLLBACK");
                clsMSG.ShowErrMsg("命令修改失敗");
            }

            clsDB.FunClsDB();
            this.Close();
        }

        private void cmdQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
