using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices; 

namespace ASRS
{
    /// <summary>
    /// 
    /// </summary>
    class clsParam
    {
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        #region Define Database Parameters
        public static string gsDB_DBMS = "";
        public static string gsDB_Server = "";
        public static string gsDB_DSN = "";
        public static string gsDB_User = "";
        public static string gsDB_Pwd = "";
        #endregion

        public static int iIQCFlag = 0;


        public static void SubLoadSysIni()
        {
            string sFileName = null;

            sFileName = System.Windows.Forms.Application.StartupPath + "\\ASRS.ini";
            if (!System.IO.File.Exists(sFileName))
            {
                System.Windows.Forms.MessageBox.Show("系統參數異常，請洽系統管理人員 !!", "ASRS", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
                System.Environment.Exit(0);
            }

            //Get PLC's StationNumber
            string sAppName = "";

            //Get Project's Title
            sAppName = "PROJECT";
            clsASRS.gstrTitle = FunReadParam(sFileName, sAppName, "TITLE");

            //Get DataBase
            sAppName = "DATABASE INFO";
            gsDB_DBMS = FunReadParam(sFileName, sAppName, "DBMS");
            gsDB_Server = FunReadParam(sFileName, sAppName, "DBSERVER");
            gsDB_DSN = FunReadParam(sFileName, sAppName, "DBDSN");
            gsDB_User = FunReadParam(sFileName, sAppName, "DBUSER");
            gsDB_Pwd = FunReadParam(sFileName, sAppName, "DBPWD");
            //clsASRS.gsFailover = FunReadParam(sFileName, sAppName, "FAILOVER");
            sAppName = "SYSTEM INFO";
            iIQCFlag = int.Parse(FunReadParam(sFileName, sAppName, "IQCFLAG"));

        }

        //***************************************************************************************************
        //Function: 讀取ini檔的單一欄位
        //***************************************************************************************************
        public static string FunReadParam(string sFileName, string sAppName, string sKeyName)
        {
            string sDefault = null;
            StringBuilder sResult = new StringBuilder(80);
            int lResult = 0;
            sDefault = "";

            lResult = GetPrivateProfileString(sAppName, sKeyName, sDefault, sResult, 255, sFileName);

            string temp = sResult.ToString().Trim();
            return temp.Trim();
        }

    }
}
