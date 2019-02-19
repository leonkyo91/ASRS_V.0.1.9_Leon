using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASRS
{
    class clsMSG
    {

        public struct MSG
        {
            public static string SYSTEM_NG = "系統錯誤!!";

            public static string OPEN_DB_NG = "資料庫開啓失敗!!";
            public static string USER_ID_NG = "使用者帳號錯誤!!";
            public static string PWD_NG = "密碼錯誤!!";
            public static string SET_NG = "處理失敗!!";
            public static string OLD_PWD_NG = "輸入的原來密碼不正確!!";            

            public static string PLS_INPUT_USER = "請輸入使用者帳號!!";
            public static string PLS_INPUT_PWD = "請輸入密碼!!";
            public static string PLS_INPUT_OLD_PWD = "請輸入原來的密碼!!";
            public static string PLS_INPUT_NEW_PWD = "請輸入要修改的新密碼!!";
            public static string PLS_INPUT_AREA = "請選擇工作區域!!";

            public static string HOSTNAME_IS_EMPTY = "系統錯誤,讀取不到電腦名稱!!";

            public static string SET_PARAMETER_OK = "處理完成!!";
            public static string ADD_OK = "新增完成!!";
            public static string UPDATE_OK = "修改完成!!";
            public static string DELETE_OK = "刪除完成!!";

            public static string COMMAND_ERROR = "產生命令失敗!!";


            public static string Msg_Pls_Input_User = "請輸入使用者代號";
            public static string Msg_Pls_Input_PWD = "請輸入使用者密碼";
            public static string Msg_Pls_Input_Chg_PWD = "請輸入修改後的密碼";
            public static string Msg_Pls_Input_TryBCR = "請刷料盒Barcode";
            public static string Msg_Pls_Input_Loc = "請輸入儲位編號";
            public static string Msg_Pls_Input_LocID = "請輸入料盤Barcode";
            public static string Msg_Pls_Input_StnNo = "請輸入出庫站號";
            public static string Msg_Pls_Input_Right_StnNo = "請輸入正確的站號";
            public static string Msg_Pls_Query_Data = "請選擇查詢條件!!";
            public static string Msg_Err_PWD = "密碼不正確";
            public static string Msg_Err_User = "使用者代碼不正確";
            public static string Msg_Err_Chg_PWD = "更改密碼失敗";
            public static string Msg_Err_Login = "異常登入,無使用者代碼!!";
            public static string Msg_Err_Reading = "讀取資料失敗";
            public static string Msg_Succ_Chg_PWD = "更改密碼完成";
            public static string Msg_Null_Prog = "無任何程式";
            public static string Msg_Run_Finish = "處理完成";
            public static string Msg_Run_Error = "處理失敗";
            public static string Msg_Reading = "資料讀取中......";
            public static string Msg_Finish_Reading = "資料讀取完成";
            public static string Msg_Succ_DEF = "設定完成";
            public static string Msg_Err_DEF = "設定失敗";
            public static string Msg_Limit_Loc = "動作中的儲位不可以設定禁用";
            public static string Msg_Limit_SysErr = "系統錯誤,無法更改回之前禁用的儲位";

                        
        }

        #region ShowErrMsg
  
        public static void ShowErrMsg(string sMessage)
        {
            MsgBox Msg   = new MsgBox(sMessage, "ASRS", "ERROR");
            Msg.BackColor = System.Drawing.Color.Red;
            Msg.textBox1.BackColor = System.Drawing.Color.Red;
            Msg.textBox1.ForeColor = System.Drawing.Color.White;
            Msg.textBox1.Font = new System.Drawing.Font(Msg.textBox1.Font.Name, 24, System.Drawing.FontStyle.Bold);
            Msg.ShowDialog();
           
            //System.Windows.Forms.MessageBox.Show(sMessage,
            //                                     "ASRS",
            //                                     System.Windows.Forms.MessageBoxButtons.OK,
            //                                     System.Windows.Forms.MessageBoxIcon.Error);  
        }
       
        #endregion
        public static void ShowWarningMsg(string sMessage)
        {
            
            MsgBox Msg = new MsgBox(sMessage, "ASRS", "Warning");
            Msg.BackColor = System.Drawing.Color.Red;
            Msg.textBox1.BackColor = System.Drawing.Color.Red;
            Msg.textBox1.ForeColor = System.Drawing.Color.White;
            Msg.textBox1.Font = new System.Drawing.Font(Msg.textBox1.Font.Name, 24, System.Drawing.FontStyle.Bold);
            Msg.ShowDialog();
            //System.Windows.Forms.MessageBox.Show(sMessage,
            //                                     "ASRS",
            //                                     System.Windows.Forms.MessageBoxButtons.OK,
            //                                     System.Windows.Forms.MessageBoxIcon.Warning);
        }

        public static void ShowInformationMsg(string sMessage)
        {
            
            MsgBox Msg = new MsgBox(sMessage, "ASRS", "OK");
            Msg.ShowDialog();
                //System.Windows.Forms.MessageBox.Show(sMessage,
            //                                     "ASRS",
            //                                     System.Windows.Forms.MessageBoxButtons.OK,
            //                                     System.Windows.Forms.MessageBoxIcon.Information);

        }
        public static bool msg_flag;
        public static bool ShowQuestionMsg(string sMessage)
        {

            msg_flag = false;
            MsgBox Msg = new MsgBox(sMessage, "ASRS", "Question");
            Msg.ShowDialog();

            return msg_flag;
            //if (System.Windows.Forms.MessageBox.Show(sMessage,
            //                                         "ASRS",
            //                                         System.Windows.Forms.MessageBoxButtons.OKCancel,
            //                                         System.Windows.Forms.MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.OK)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }
    }
}
