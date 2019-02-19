using System;
using System.Windows.Forms;
using System.Data.Common;

namespace ASRS
{
    ///<Summary>
    /// 
    ///</Summary>  
    public partial class frmLogin : Form
    {
        /// <summary>
        /// 登入作業
        /// </summary>
        public frmLogin()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.None;           
        }
        
        private void frmLogin_Load(object sender, EventArgs e)
        {
            if (clsASRS.gstrLoginUser != "")
            {
                txtUserID.Text = clsASRS.gstrLoginUser;
            }
            else
            {
                txtUserID.Text = "";
            }
        }
        
        private void butLogin_Click(object sender, EventArgs e)
        {
            try
            {
                txtUserID.Text = txtUserID.Text.Trim();  txtUserID.Text = txtUserID.Text.ToUpper();
                txtPassword.Text = txtPassword.Text.Trim(); txtPassword.Text = txtPassword.Text.ToUpper();

                if (txtUserID.Text == "")
                {
                    clsMSG.ShowWarningMsg(clsMSG.MSG.PLS_INPUT_USER);
                    return;
                }
                if (txtPassword.Text == "")
                {
                    clsMSG.ShowWarningMsg(clsMSG.MSG.PLS_INPUT_PWD);
                    return;
                }

                string strSql = ""; string strPWD = ""; string strProg = "";
                strSql = "SELECT * FROM USER_MST WHERE USER_ID = '" + txtUserID.Text + "' ";
                
                DbDataReader dbRS = null;
                if (clsDB.FunRsSql(strSql,ref dbRS))
                {
                    while (dbRS.Read())
                    {
                        strPWD = dbRS["USER_PSWD"].ToString();
                        strProg = dbRS["PROGSTYLE"].ToString();
                    }
                    dbRS.Close();
                }
                else
                {
                    clsMSG.ShowErrMsg(clsMSG.MSG.USER_ID_NG);
                    return;
                }

                if (strPWD != txtPassword.Text)
                { 
                    clsMSG.ShowErrMsg(clsMSG.MSG.PWD_NG);
                    return;
                }

                clsASRS.gstrLoginUser = txtUserID.Text;
                clsASRS.gstrLoginAuthority = strProg;
                this.DialogResult = DialogResult.OK;

                string sCount = "";
                strSql = "SELECT COUNT(*) AS AA FROM LOCID_R2R WHERE N1 > 8 ";
                if (clsDB.FunRsSql(strSql, ref dbRS))
                {
                    while (dbRS.Read())
                    {
                        sCount = dbRS["AA"].ToString();
                    }
                    dbRS.Close();
                }
                if (clsTool.INT(sCount) > 0)
                { clsMSG.ShowErrMsg("庫對庫次數大於 8 次共有 " + sCount + " 筆: 請執行檢視出庫功能!"); }
                this.Close(); 

            }
            catch (Exception ex)
            {
                clsMSG.ShowErrMsg(ex.Message);
            }
        }

        private void butExit_Click(object sender, EventArgs e)
        {
            clsASRS.gstrLoginUser = "";
            clsASRS.gstrLoginAuthority = "";
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtUserID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                clsTool.SetFocus(txtPassword);
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                butLogin.Focus();
            }
        }

        private void txtUserID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
