using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Common;
using System.Text.RegularExpressions;

namespace ASRS
{
    public partial class frmChgPwd : Form
    {
        public frmChgPwd()
        {
            InitializeComponent();
        }

        private void frmChgPwd_Load(object sender, EventArgs e)
        {
            txtUserID.Text = clsASRS.gstrLoginUser;
            txtPassword.Text = "";
            txtNewPwd.Text = "";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            txtUserID.Text = txtUserID.Text.Trim(); //txtUserID.Text = txtUserID.Text.ToUpper(); V.0.1.9
            txtPassword.Text = txtPassword.Text.Trim(); //txtPassword.Text = txtPassword.Text.ToUpper();
            txtNewPwd.Text = txtNewPwd.Text.Trim(); //txtNewPwd.Text = txtNewPwd.Text.ToUpper();

            if (txtUserID.Text == "")
            {
                clsMSG.ShowWarningMsg(clsMSG.MSG.PLS_INPUT_USER);
                return;
            }

            if (txtPassword.Text == "")
            {
                clsMSG.ShowWarningMsg(clsMSG.MSG.PLS_INPUT_OLD_PWD);
                return;
            }

            if (txtNewPwd.Text == "")
            {
                clsMSG.ShowWarningMsg(clsMSG.MSG.PLS_INPUT_NEW_PWD);
                return;
            }
            #region	檢查新舊密碼 & 密碼複雜度驗證 V.0.1.9
            if (txtPassword.Text == txtNewPwd.Text)
            {
                clsMSG.ShowWarningMsg("新舊密碼不可相同!!");
                return;
            }
            
            Regex regex = new Regex(@"^(?=.*\d)(?=.*[a-zA-Z])(?=.*\W).{8,12}$");
            clsMSG.ShowWarningMsg("333");
            bool bflag = regex.IsMatch(txtNewPwd.Text) ? true : false;
            if (bflag == false)
            {
                clsMSG.ShowWarningMsg("密碼規則不符,需要長度最少8碼,大小寫英字,數字,特殊字元");
                return;
            }
            #endregion


            #region 開啟資料庫失敗
            if (clsDB.FunOpenDB() == false)     // Open Database
            {
                clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG);
                return;
            };
            #endregion 開啟資料庫失敗
            string strSql = ""; string sPwd = "";
            DbDataReader dbRS = null;

            strSql = "SELECT * FROM USER_MST WHERE USER_ID = '" + txtUserID.Text + "' ";            
            if (clsDB.FunRsSql(strSql, ref dbRS))
            {
                while (dbRS.Read())
                {
                    sPwd = dbRS["USER_PSWD"].ToString();
                }
                dbRS.Close();
            }

            if (sPwd == txtPassword.Text)
            {
                //strSql = "UPDATE USER_MST SET USER_PSWD = '" + txtNewPwd.Text + "' WHERE USER_ID = '" + txtUserID.Text + "' ";
                strSql = "UPDATE USER_MST SET USER_PSWD = '" + txtNewPwd.Text + "' ,TRN_DATE='"+System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")+"' WHERE USER_ID = '" + txtUserID.Text + "' ";
                if (clsDB.FunExecSql(strSql) == true)
                {
                    clsMSG.ShowInformationMsg(clsMSG.MSG.SET_PARAMETER_OK);
                }
                else
                {
                    clsMSG.ShowErrMsg(clsMSG.MSG.SET_NG);
                    clsDB.FunClsDB();
                    return;
                }
            }
            else
            {
                clsMSG.ShowWarningMsg(clsMSG.MSG.OLD_PWD_NG);
                clsDB.FunClsDB();
                return;
            }
            
            clsDB.FunClsDB();
            this.Close();
        }

        private void txtUserID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                clsTool.SetFocus(txtNewPwd);
            }
        }

        private void txtNewPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                btnConfirm.Focus();
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }





    }
}
