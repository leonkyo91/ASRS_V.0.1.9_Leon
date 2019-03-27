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
                txtUserID.Text = txtUserID.Text.Trim();  //txtUserID.Text = txtUserID.Text.ToUpper(); V.0.1.9
                txtPassword.Text = txtPassword.Text.Trim(); //txtPassword.Text = txtPassword.Text.ToUpper();

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

                string strSql = ""; string strUserID = ""; string strPWD = ""; string strProg = ""; string strErrCnt = ""; string strLock = ""; string strLoginFailTm = "";
                strSql = "SELECT * FROM USER_MST WHERE USER_ID = '" + txtUserID.Text + "' ";
                
                DbDataReader dbRS = null;
                if (clsDB.FunRsSql(strSql,ref dbRS))
                {
                    while (dbRS.Read())
                    {
                        strUserID = dbRS["USER_ID"].ToString();
                        strPWD = dbRS["USER_PSWD"].ToString();
                        strProg = dbRS["PROGSTYLE"].ToString();
                        strErrCnt = dbRS["PSWD_ERR_CNT"].ToString();
                        strLock = dbRS["LOCK"].ToString();
                        strLoginFailTm = dbRS["LOGIN_FAIL_TM"].ToString().Trim();
                    }
                    dbRS.Close();
                }
                else
                {
                    clsMSG.ShowErrMsg(clsMSG.MSG.USER_ID_NG);
                    return;
                }

                //V.0.1.9 登入錯誤帳號鎖定機制
                //計算目前時間與上次登入錯誤時間相差多久。
                int iTimeM = 0;
                int iTimeH = 0;
                int iTimeD = 0;
                if (strLoginFailTm.Length != 0)
                {
                    iTimeM = clsTool.DateDiff_Minutes(strLoginFailTm);   //分
                    iTimeH = clsTool.DateDiff_Hours(strLoginFailTm);   //時
                    iTimeD = clsTool.DateDiff_Days(strLoginFailTm);   //日
                }
                    

                // 距離上次登入失敗超過30分鐘，解除鎖定與重置錯誤計數器。
                if (iTimeM >= 30 || iTimeH >= 1 || iTimeD >= 1)
                {
                    strLock = "0";
                    strErrCnt = "0";
                }

                //帳號鎖定中
                if (strLock == "1")
                {
                    clsMSG.ShowInformationMsg("帳號已鎖定，請等待 " + (30 - iTimeM) + " 分鐘後自動解鎖。");
                    return;
                }


                if (strPWD != txtPassword.Text)
                {
                    //登入錯誤計數器 + 1
                    int iError = int.Parse(strErrCnt);
                    iError++;

                    //錯誤超過 3 次鎖定帳戶
                    if (iError >= 3)
                        strLock = "1";

                    strSql = "UPDATE USER_MST SET ";
                    strSql = strSql + "PSWD_ERR_CNT = '" + iError + "',";
                    strSql = strSql + "LOCK = '" + strLock + "',";
                    strSql = strSql + "LOGIN_FAIL_TM = '" + System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "' ";
                    strSql = strSql + "WHERE USER_ID = '" + strUserID + "' ";
                    if (clsDB.FunExecSql(strSql) == true)
                    {
                        //clsMSG.ShowInformationMsg(clsMSG.MSG.UPDATE_OK);
                    }
                    else
                    {
                        clsMSG.ShowWarningMsg(clsMSG.MSG.Msg_Run_Error);
                    }

                    clsMSG.ShowInformationMsg("密碼輸入錯誤次數 " + iError + " 次，超過 3 次錯誤將暫時鎖定帳號 30 分鐘。");
                    //clsMSG.ShowErrMsg(clsMSG.MSG.PWD_NG);
                    return;
                }

                clsASRS.gstrLoginUser = txtUserID.Text;
                clsASRS.gstrLoginAuthority = strProg;
                this.DialogResult = DialogResult.OK;

                //V.0.1.9 強制變更密碼
                funChkLogInPw(clsASRS.gstrLoginUser);

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

        private void funChkLogInPw(string strUserID)
        {
            string sSQL = ""; DbDataReader dbRS = null;
            string sDTime = "";
            int iTime=50;

            sSQL = "SELECT * FROM USER_MST WHERE USER_ID='"+strUserID+"'";
            if (clsDB.FunRsSql(sSQL, ref dbRS))
            {
                while (dbRS.Read())
                {
                    sDTime = dbRS["TRN_DATE"].ToString().Trim();
                }
                dbRS.Close();
            }
            if(sDTime.Length !=0)
                iTime = clsTool.DateDiff_Days ((sDTime))   ;   //日

            //V.0.1.9 密碼過期前十天提醒使用者修改密碼
            if (iTime >= 20 && iTime < 30)
            {
                clsMSG.ShowInformationMsg("密碼剩餘 " + (30-iTime) + " 天即過期，請前往修改密碼。");
            }

            if (iTime >= 30)
            {
                //密碼修改
                clsMSG.ShowInformationMsg("密碼超過30天未變更");
                
                frmChgPwd frmPChgPwd = new frmChgPwd();
                frmPChgPwd.ShowDialog();
            } 
        }


        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
