using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Windows.Forms;

namespace ASRS
{

    class clsASRS
    {
        #region 定義 TRN_LOG structure
        public struct TRN_LOG
        {
            public string TRN_DATE;
            public string CMD_SNO;
            public string LOC;
            public string CMD_STS;
            public string PRTY;
            public string STN_NO;
            public string CMD_MODE;
            public string IO_TYPE;
            public string NEW_LOC;
            public string LOC_ID;
            public string CRT_DATE;
            public string EXP_DATE;
            public string END_DATE;
            public string FIN_DATE;
            public string PROG_ID;
            public string PROG_NAME;
            public string PROG_DESC;
            public string USER_ID;
            public string HOST_NAME;
            public string TRACE;
            public string STORAGE_TYPE;
            public string GROUP_ID;
            public string LOC_SNO;
            public string TRN_LOC_SNO;
            public string ITEM_NO;
            public string LOT_NO;
            public string STATUS;
            public string IQC;
            public string TKT_NO;
            public string TKT_SNO;
            public int PLT_QTY;
            public int ALO_QTY;
            public int TRN_QTY;
            public string IN_DATE;
            public string PROD_DATE;
            public string BEST_DATE;
            public string CYCLE_DATE;
            public string TRN_TKT_NO;
            public string TRN_TKT_SNO;
            public string REMARKS;
        }
        #endregion

        #region 定義 LOC_DTL structure
        public struct LOC_DTL
        {
            public string LOC;
            public string LOC_SNO;
            public string ITEM_NO;
            public string LOT_NO;
            public string STATUS;
            public string IQC;
            public string TKT_NO;
            public string TKT_SNO;
            public int PLT_QTY;
            public int ALO_QTY;
            public int TRN_QTY;
            public string IN_DATE;
            public string PROD_DATE;
            public string BEST_DATE;
            public string CYCLE_DATE;
            public string PROG_ID;
            public string PROG_NAME;
            public string REMARKS;
        }
        #endregion

        //變數
        #region Define ASRS Parameters
        public static string gstrTitle = "";
        #endregion

        #region Define ASRS 登入的必要變數
        public static string gstrLoginUser = "";        //登入帳號
        public static string gstrLoginAuthority = "";   //登入密碼
        public static string gsHostName = "";           //Host Name
        public static string gsAreaNo = "";             //PC 所在區域
        #endregion

        //ASRS 常用變數
        #region Define ASRS 命令模式 (CmdMode)
        public const string gsCmdMode_In = "1";
        public const string gsCmdMode_Out = "2";
        public const string gsCmdMode_Pack = "3";
        public const string gsCmdMode_S2S = "4";
        public const string gsCmdMode_R2R = "5";
        #endregion

        #region Define ASRS 作業別 (IOTYPE)        
        public const string gsIOTYPE_EmptyIn = "11";        //AWP010 空料盒入庫         
        public const string gsIOTYPE_Offline_In = "16";     //AWP080 無帳入庫作業        
        public const string gsIOTYPE_ERP_In = "17";         //AWP110 手動入庫
        public const string gsIOTYPE_WMS_In = "18";         //AWP130 WMS入庫
        
        public const string gsIOTYPE_EmptyOut = "21";       //AWP020 空料盒出庫        
        public const string gsIOTYPE_Offline_Out = "26";    //AWP100 無帳出庫作業
        public const string gsIOTYPE_ERP_Out = "27";        //AWP120 手動出庫
        public const string gsIOTYPE_WMS_Out = "28";        //AWP140 WMS出庫作業
        public const string gsIOTYPE_IQC_AUTO = "29";       //IQC自動出庫

        public const string gsIOTYPE_Cycle_Loc = "31";      //AWC010 依儲位盤點
        public const string gsIOTYPE_Cycle_Item = "32";     //AWC020 依item盤點
        public const string gsIOTYPE_Cycle = "33";          //AWC030 檢視出庫
        public const string gsIOTYPE_Cycle_WMS = "35";      //AWC080 WMS盤點
       

        public const string gsIOTYPE_R2R = "41";        //庫對庫        
        public const string gsIOTYPE_S2S = "42";        //站對站
        public const string gsIOTYPE_ErrLocOut = "43";  //異常儲位出庫
        public const string gsIOTYPE_LocDtlChg = "44";  //儲位資料維護

        #endregion

        #region Define ASRS 程式編號
        public const string gsIOTYPE_EmptyIn_PID = "AWP010";        //AWP010 空料盒入庫         
        public const string gsIOTYPE_Offline_In_PID = "AWP080";     //AWP080 無帳入庫作業        
        public const string gsIOTYPE_ERP_In_PID = "AWP110";         //AWP110 手動入庫
        public const string gsIOTYPE_WMS_In_PID = "AWP130";         //AWP130 WMS入庫

        public const string gsIOTYPE_EmptyOut_PID = "AWP020";       //AWP020 空料盒出庫        
        public const string gsIOTYPE_Offline_Out_PID = "AWP100";    //AWP100 無帳出庫作業
        public const string gsIOTYPE_ERP_Out_PID = "AWP120";        //AWP120 手動出庫
        public const string gsIOTYPE_WMS_Out_PID = "AWP140";        //AWP140 WMS出庫作業

        public const string gsIOTYPE_Cycle_Loc_PID = "AWC010";      //AWC010 依儲位盤點
        public const string gsIOTYPE_Cycle_Item_PID = "AWC020";     //AWC020 依item盤點
        public const string gsIOTYPE_Cycle_PID = "AWC030";          //AWC030 檢視出庫
        public const string gsIOTYPE_Cycle_WMS_PID = "AWC080";      //AWC080 WMS盤點

        public const string gsIOTYPE_R2R_PID = "AWP030";            //AWP030 庫對庫     
        #endregion

        //Form之間的變數
        public static int iQty = 0;

        public static CMD_LIST[] aCMD_LIST = new CMD_LIST[1];


        public static string gsTktType = "";
        public static string gsTktIOType = "";
        public static string gsTkt_ERP = "";



        #region 定義 CMD_LIST structrue
        public struct CMD_LIST
        {
            public string CMD_SNO;
            public string LOC;
            public string STNNO;
        }
        #endregion

        public const string RUN_STS_Standby = "Standby";
        public const string RUN_STS_Going = "Going";
        public const string RUN_STS_Completed = "Completed";
        public const string RUN_STS_Hold = "Hold";



        //Function
        #region FunGetAreaNo()  由電腦名稱取出區域代碼
        public static string FunGetAreaNo(string sHostName)
        {
            string strSql = ""; string sAreaNo = "";
            strSql = "SELECT * FROM AREA_HOST WHERE HOST_NAME = '" + sHostName + "' ";

            DbDataReader dbRS = null;
            if (clsDB.FunRsSql(strSql, ref dbRS))
            {
                while (dbRS.Read())
                {
                    sAreaNo = dbRS["AREA_NO"].ToString();                    
                }
                dbRS.Close();
            }

            return sAreaNo;
        }
        #endregion

        #region FunGetAreaName()  由區域代碼取出區域名稱
        public static string FunGetAreaName(string sAreaNo)
        {
            if (sAreaNo == "") { return "";  };
            
            string strSql = ""; string sAreaName = "";
            strSql = "SELECT * FROM AREA_CTRL WHERE AREA_NO = '" + sAreaNo + "' ";            

            DbDataReader dbRS = null;
            if (clsDB.FunRsSql(strSql, ref dbRS))
            {
                while (dbRS.Read())
                {
                    sAreaName = dbRS["AREA_NAME"].ToString();
                }
                dbRS.Close();
            }

            return sAreaName;
        }
        #endregion

        #region FunGetUserName()  取出使用者名稱
        public static string FunGetUserName(string sUser)
        {
            if (sUser == "") { return ""; };

            string strSql = ""; string sUserName = "";
            strSql = "SELECT * FROM USER_MST WHERE USER_ID = '" + sUser + "' ";

            DbDataReader dbRS = null;
            if (clsDB.FunRsSql(strSql, ref dbRS))
            {
                while (dbRS.Read())
                {
                    sUserName = dbRS["USER_NAME"].ToString();
                }
                dbRS.Close();
            }

            return sUserName;
        }
        #endregion

        #region FunInsTrnLog() 寫入異動檔
        public static bool FunInsTrnLog(ref TRN_LOG tTrn_Log)
        {
            string sSQL = "";

            sSQL = "INSERT INTO TRN_LOG (TRN_DATE,CMD_SNO,LOC,CMD_STS,PRTY,STN_NO,CMD_MODE,IO_TYPE,NEW_LOC,LOC_ID,";
            sSQL = sSQL + "CRT_DATE,EXP_DATE,END_DATE,FIN_DATE,PROG_ID,PROG_NAME,PROG_DESC,USER_ID,HOST_NAME,";
            sSQL = sSQL + "TRACE,STORAGE_TYPE,GROUP_ID,LOC_SNO,TRN_LOC_SNO,ITEM_NO,LOT_NO,STATUS,IQC,";
            sSQL = sSQL + "TKT_NO,TKT_SNO,PLT_QTY,ALO_QTY,TRN_QTY,IN_DATE,PROD_DATE,BEST_DATE,CYCLE_DATE,TRN_TKT_NO,TRN_TKT_SNO,REMARKS) VALUES (";
            sSQL = sSQL + "'" + tTrn_Log.TRN_DATE + "',";
            sSQL = sSQL + "'" + tTrn_Log.CMD_SNO + "',";
            sSQL = sSQL + "'" + tTrn_Log.LOC + "',";
            sSQL = sSQL + "'" + tTrn_Log.CMD_STS + "',";
            sSQL = sSQL + tTrn_Log.PRTY + ",";
            sSQL = sSQL + "'" + tTrn_Log.STN_NO + "',";
            sSQL = sSQL + "'" + tTrn_Log.CMD_MODE + "',";
            sSQL = sSQL + "'" + tTrn_Log.IO_TYPE + "',";
            sSQL = sSQL + "'" + tTrn_Log.NEW_LOC + "',";
            sSQL = sSQL + "'" + tTrn_Log.LOC_ID + "',";
            sSQL = sSQL + "'" + tTrn_Log.CRT_DATE + "',";
            sSQL = sSQL + "'" + tTrn_Log.EXP_DATE + "',";
            sSQL = sSQL + "'" + tTrn_Log.END_DATE + "',";
            sSQL = sSQL + "'" + tTrn_Log.FIN_DATE + "',";
            sSQL = sSQL + "'" + tTrn_Log.PROG_ID + "',";
            sSQL = sSQL + "'" + tTrn_Log.PROG_NAME + "',";
            sSQL = sSQL + "'" + tTrn_Log.PROG_DESC + "',";
            sSQL = sSQL + "'" + tTrn_Log.USER_ID + "',";
            sSQL = sSQL + "'" + tTrn_Log.HOST_NAME + "',";
            sSQL = sSQL + "'" + tTrn_Log.TRACE + "',";
            sSQL = sSQL + "'" + tTrn_Log.STORAGE_TYPE + "',";
            sSQL = sSQL + "'" + tTrn_Log.GROUP_ID + "',";
            sSQL = sSQL + "'" + tTrn_Log.LOC_SNO + "',";
            sSQL = sSQL + "'" + tTrn_Log.TRN_LOC_SNO + "',";
            sSQL = sSQL + "'" + tTrn_Log.ITEM_NO + "',";
            sSQL = sSQL + "'" + tTrn_Log.LOT_NO + "',";
            sSQL = sSQL + "'" + tTrn_Log.STATUS + "',";
            sSQL = sSQL + "'" + tTrn_Log.IQC + "',";
            sSQL = sSQL + "'" + tTrn_Log.TKT_NO + "',";
            sSQL = sSQL + "'" + tTrn_Log.TKT_SNO + "',";
            sSQL = sSQL + tTrn_Log.PLT_QTY + ",";
            sSQL = sSQL + tTrn_Log.ALO_QTY + ",";
            sSQL = sSQL + tTrn_Log.TRN_QTY + ",";
            sSQL = sSQL + "'" + tTrn_Log.IN_DATE + "',";
            sSQL = sSQL + "'" + tTrn_Log.PROD_DATE + "',";
            sSQL = sSQL + "'" + tTrn_Log.BEST_DATE + "',";
            sSQL = sSQL + "'" + tTrn_Log.CYCLE_DATE + "',";
            sSQL = sSQL + "'" + tTrn_Log.TRN_TKT_NO + "',";
            sSQL = sSQL + "'" + tTrn_Log.TRN_TKT_SNO + "',";
            sSQL = sSQL + "'" + tTrn_Log.REMARKS + "') ";

            if (clsDB.FunExecSql(sSQL) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion


        //Help
        public static string gsHelpStyle = "";
        public static string gsHelpStyle_Data = "";
        public static string gsHelpStyle_MLoc = "";
        public static string[] gsHelpRtnData;



        //ASRS
        public static string FunGetAsrsLocStsCnt(string sLocType)
        {
            string strSql = ""; DbDataReader dbRS = null;
            string sValue = "";

            switch (sLocType)
            {
                case "ALL": strSql = "SELECT COUNT(*) FROM LOC_MST "; break;
                case "S": strSql = "SELECT COUNT(*) FROM LOC_MST WHERE LOC_STS = 'S' "; break;
                case "I": strSql = "SELECT COUNT(*) FROM LOC_MST WHERE LOC_STS = 'I' "; break;
                case "O": strSql = "SELECT COUNT(*) FROM LOC_MST WHERE LOC_STS = 'O' "; break;
                case "C": strSql = "SELECT COUNT(*) FROM LOC_MST WHERE LOC_STS = 'C' "; break;
                case "P": strSql = "SELECT COUNT(*) FROM LOC_MST WHERE LOC_STS = 'P' "; break;
                case "X": strSql = "SELECT COUNT(*) FROM LOC_MST WHERE LOC_STS = 'X' "; break;
                case "A": strSql = "SELECT COUNT(*) FROM LOC_MST WHERE LOC_STS = 'A' "; break;
                case "N": strSql = "SELECT COUNT(*) FROM LOC_MST WHERE LOC_STS = 'N' "; break;
                case "E": strSql = "SELECT COUNT(*) FROM LOC_MST WHERE LOC_STS = 'E' "; break;
                case "1": strSql = "SELECT COUNT(*) FROM LOC_MST WHERE LOC_STS IN ('I','O','C','A','S') "; break;
            }

            if (clsDB.FunRsSql(strSql, ref dbRS) == true)
            {
                while (dbRS.Read())
                {
                    sValue = dbRS[0].ToString();
                }
                dbRS.Close();
            }

            return sValue;
        }

        #region FunLocDtlDataFlag()  取得儲位明細是否有資料
        public static bool FunLocDtlDataFlag(string sLoc)
        {
            string strSql = ""; DbDataReader dbRS = null;
            bool bFlag = false;
            strSql = "SELECT COUNT(*) FROM LOC_DTL WHERE LOC = '" + sLoc + "' ";
            if (clsDB.FunRsSql(strSql, ref dbRS))
            {
                while (dbRS.Read())
                {
                    if (clsTool.INT(dbRS[0].ToString()) > 0)
                    {
                        bFlag = true;
                    }
                }
                dbRS.Close();
            }

            return bFlag;
        }
        #endregion

        #region FunLocDtlDataCnt()  取得儲位明細有幾筆資料
        public static int FunLocDtlDataCnt(string sLoc)
        {
            string strSql = ""; DbDataReader dbRS = null;
            int iCnt = 0;
            strSql = "SELECT COUNT(*) FROM LOC_DTL WHERE LOC = '" + sLoc + "' ";
            if (clsDB.FunRsSql(strSql, ref dbRS))
            {
                while (dbRS.Read())
                {
                    iCnt = clsTool.INT(dbRS[0].ToString());
                }
                dbRS.Close();
            }
            return iCnt;
        }
        #endregion

        #region FunChkLocIsEmpty()  取得儲位是否為空儲位
        public static bool FunChkLocIsEmpty(string sLoc)
        {
            string strSql = ""; DbDataReader dbRS = null;
            bool bFlag = false;
            strSql = "SELECT * FROM LOC_MST WHERE LOC = '" + sLoc + "' ";
            if (clsDB.FunRsSql(strSql, ref dbRS))
            {
                while (dbRS.Read())
                {
                    if (dbRS["LOC_STS"].ToString() == "N")
                    {
                        bFlag = true;
                    }
                }
                dbRS.Close();
            }
            return bFlag;
        }
        #endregion

        #region FunGetCraneNoByLoc() 由儲位編號取得 Crane No
        public static int FunGetCraneNoByLoc(string sLoc)
        {
            try
            {
                string sRow = sLoc.Substring(0, 2);
                int iCrn = (int.Parse(sRow) + 3) / 4;
                return iCrn;
            }
            catch
            {
                return 0;
            }
        }
        #endregion

        #region FunGetCmdSno() 產生命令序號
        public static string FunGetCmdSno()
        {
            string strSql = ""; DbDataReader dbRS = null;
            string sCmdSno = ""; int i = 0;
            bool bFlag = false;

            for (i = 1; i <= 20000; i++)
            {
                sCmdSno = FunGetCmdSno_Sub();

                if (sCmdSno == "")
                { 
                    return "";
                }
                else
                {
                    bFlag = false;
                    strSql = "SELECT CMDSNO FROM CMD_MST WHERE CMDSNO = '" + sCmdSno + "' ";
                    if (clsDB.FunRsSql(strSql, ref dbRS))
                    {
                        while (dbRS.Read())
                        {
                            bFlag = true;
                        }
                        dbRS.Close();
                    }

                    if (bFlag == false) { break; }
                }                
            }
            return sCmdSno;
        }

        public static string FunGetCmdSno_Sub()
        {
            string sSQL = ""; DbDataReader dbRS = null;
            string sCmdSno = ""; int iTimes = 0; int iOldCmdSno = 0;
            string sDate = DateTime.Now.ToString("yyyyMMdd");
            int iValue = 0;
            
            while (iTimes < 5 && sCmdSno == "")
            {
                sCmdSno = "";
                iTimes = iTimes + 1;
                sSQL = "SELECT SNO FROM SNOCTL WHERE SNOTYP = 'CMDSNO' ";
                if (clsDB.FunRsSql(sSQL, ref dbRS))
                {
                    #region Get SNOCTL's SNO
                    while (dbRS.Read())
                    {
                        iOldCmdSno = int.Parse(dbRS["SNO"].ToString());
                        iValue = int.Parse(dbRS["SNO"].ToString()) + 1;
                        if (iValue >= 20000)
                        {
                            sCmdSno = "00001";
                            break;
                        }
                        else
                        {
                            sCmdSno = iValue.ToString().PadLeft(5, '0');
                            break;
                        }
                    }
                    dbRS.Close();
                    #endregion

                    #region Update SNOCTL Data
                    if (sCmdSno != "")
                    {
                        clsDB.FunCommitCtrl("BEGIN");
                        //V.1.5.1
                        //sSQL = "UPDATE SNOCTL SET TRNDATE = '" + sDate + "', SNO = " + Convert.ToInt32(sCmdSno) + " ";
                        //sSQL = sSQL + "WHERE SNOTYP = 'CMDSNO' ";
                        sSQL = "UPDATE SNOCTL SET TRNDATE = '" + sDate + "', SNO = " + Convert.ToInt32(sCmdSno) + " ";
                        sSQL = sSQL + "WHERE SNOTYP = 'CMDSNO' AND SNO = " + iOldCmdSno + " ";
                        if (clsDB.FunExecSql(sSQL) == true)
                        {
                            clsDB.FunCommitCtrl("COMMIT");
                        }
                        else
                        {
                            sCmdSno = "";
                            clsDB.FunCommitCtrl("ROLLBACK");
                        }
                    }
                    #endregion
                }
                else
                {
                    #region SNOCTL No Data need to Insert First Data
                    sCmdSno = "00001";
                    clsDB.FunCommitCtrl("BEGIN");
                    sSQL = "INSERT INTO SNOCTL (TRNDATE,SNOTYP,SNO) VALUES ('" + sDate + "','CMDSNO', " + Convert.ToInt32(sCmdSno) + ") ";
                    if (clsDB.FunExecSql(sSQL) == true)
                    {
                        clsDB.FunCommitCtrl("COMMIT");
                    }
                    else
                    {
                        sCmdSno = "";
                        clsDB.FunCommitCtrl("ROLLBACK");
                    }
                    #endregion
                }
            }

            return sCmdSno;
        }
        #endregion

        #region FunGetLocSno() 產生儲位流水號
        public static string FunGetLocSno()
        {
            string sLocSno = FunGetLocSno_Sub();
            if (sLocSno == "")
            {
                sLocSno = "";
            }
            else
            {
                sLocSno = DateTime.Now.ToString("yyyyMMdd") + sLocSno;
            }
            return sLocSno;
        }

        public static string FunGetLocSno_Sub()
        {
            string sSQL = ""; DbDataReader dbRS = null;
            string sValue = ""; int iValue = 0; int iTimes = 0;
            string sDate = DateTime.Now.ToString("yyyyMMdd");

            while (iTimes < 5 && sValue == "")
            {
                sValue = "";
                iTimes = iTimes + 1;
                sSQL = "SELECT SNO,TRNDATE FROM SNOCTL WHERE SNO_TYPE = 'ASRSNO' ";
                if (clsDB.FunRsSql(sSQL, ref dbRS))
                {
                    #region Get SNOCTL's SNO
                    while (dbRS.Read())
                    {
                        if (dbRS["TRNDATE"].ToString() == sDate)
                        {
                            iValue = int.Parse(dbRS["SNO"].ToString()) + 1;
                            sValue = iValue.ToString().PadLeft(5, '0');
                            break;
                        }
                        else
                        {
                            sValue = "00001";
                            break;
                        }
                    }
                    dbRS.Close();
                    #endregion

                    #region Update SNOCTL Data
                    if (sValue != "")
                    {
                        clsDB.FunCommitCtrl("BEGIN");
                        sSQL = "UPDATE SNOCTL SET TRNDATE = '" + sDate + "', SNO = " + Convert.ToInt32(sValue) + " ";
                        sSQL = sSQL + "WHERE SNOTYP = 'ASRSNO' ";
                        if (clsDB.FunExecSql(sSQL) == true)
                        {
                            clsDB.FunCommitCtrl("COMMIT");
                        }
                        else
                        {
                            sValue = "";
                            clsDB.FunCommitCtrl("ROLLBACK");
                        }
                    }
                    #endregion
                }
                else
                {
                    #region SNOCTL No Data need to Insert First Data
                    sValue = "00001";
                    clsDB.FunCommitCtrl("BEGIN");
                    sSQL = "INSERT INTO SNOCTL (TRNDATE,SNOTYP,SNO) VALUES ('" + sDate + "','ASRSNO'," + Convert.ToInt32(sValue) + " )";
                    if (clsDB.FunExecSql(sSQL) == true)
                    {
                        clsDB.FunCommitCtrl("COMMIT");
                    }
                    else
                    {
                        sValue = "";
                        clsDB.FunCommitCtrl("ROLLBACK");
                    }
                    #endregion
                }
            }

            return sValue;
        }
        #endregion

        #region FunGetCycleSno() 產生盤點流水號
        public static string FunGetCycleSno()
        {
            string sLocSno = FunGetCycleSno_Sub();
            if (sLocSno == "")
            {
                sLocSno = "";
            }
            else
            {
                sLocSno = DateTime.Now.ToString("yyyyMMdd") + sLocSno;
            }
            return sLocSno;
        }

        public static string FunGetCycleSno_Sub()
        {
            string sSQL = ""; DbDataReader dbRS = null;
            string sValue = ""; int iValue = 0; int iTimes = 0;
            string sDate = DateTime.Now.ToString("yyyyMMdd");

            while (iTimes < 5 && sValue == "")
            {
                sValue = "";
                iTimes = iTimes + 1;
                sSQL = "SELECT SNO,TRNDATE FROM SNOCTL WHERE SNOTYP = 'CYCLE' ";
                if (clsDB.FunRsSql(sSQL, ref dbRS))
                {
                    #region Get SNOCTL's SNO
                    while (dbRS.Read())
                    {
                        if (dbRS["TRNDATE"].ToString() == sDate)
                        {
                            iValue = int.Parse(dbRS["SNO"].ToString()) + 1;
                            sValue = iValue.ToString().PadLeft(5, '0');
                            break;
                        }
                        else
                        {
                            sValue = "00001";
                            break;
                        }
                    }
                    dbRS.Close();
                    #endregion

                    #region Update SNOCTL Data
                    if (sValue != "")
                    {
                        clsDB.FunCommitCtrl("BEGIN");
                        sSQL = "UPDATE SNOCTL SET TRNDATE = '" + sDate + "', SNO = " + Convert.ToInt32(sValue) + " ";
                        sSQL = sSQL + "WHERE SNOTYP = 'CYCLE' ";
                        if (clsDB.FunExecSql(sSQL) == true)
                        {
                            clsDB.FunCommitCtrl("COMMIT");
                        }
                        else
                        {
                            sValue = "";
                            clsDB.FunCommitCtrl("ROLLBACK");
                        }
                    }
                    #endregion
                }
                else
                {
                    #region SNOCTL No Data need to Insert First Data
                    sValue = "0001";
                    clsDB.FunCommitCtrl("BEGIN");
                    sSQL = "INSERT INTO SNOCTL (TRNDATE,SNOTYP,SNO) VALUES ('" + sDate + "','CYCLE'," + Convert.ToInt32(sValue) + " )";
                    if (clsDB.FunExecSql(sSQL) == true)
                    {
                        clsDB.FunCommitCtrl("COMMIT");
                    }
                    else
                    {
                        sValue = "";
                        clsDB.FunCommitCtrl("ROLLBACK");
                    }
                    #endregion
                }
            }

            return sValue;
        }
        #endregion

        public static string FunGetAdjCycNo()
        {
            string sSQL = ""; DbDataReader dbRS = null;
            string sValue = ""; int iValue = 0; int iTimes = 0;
            string sDate = DateTime.Now.ToString("yyyyMMdd");

            while (iTimes < 5 && sValue == "")
            {
                sValue = "";
                iTimes = iTimes + 1;
                sSQL = "SELECT SNO,TRNDATE FROM SNOCTL WHERE SNOTYP = 'ADJ_CYC' ";
                if (clsDB.FunRsSql(sSQL, ref dbRS))
                {
                    #region Get SNOCTL's SNO
                    while (dbRS.Read())
                    {
                        if (dbRS["TRNDATE"].ToString() == sDate)
                        {
                            iValue = int.Parse(dbRS["SNO"].ToString()) + 1;
                            sValue = iValue.ToString().PadLeft(5, '0');
                            break;
                        }
                        else
                        {
                            sValue = "00001";
                            break;
                        }
                    }
                    dbRS.Close();
                    #endregion

                    #region Update SNOCTL Data
                    if (sValue != "")
                    {
                        clsDB.FunCommitCtrl("BEGIN");
                        sSQL = "UPDATE SNOCTL SET TRNDATE = '" + sDate + "', SNO = " + Convert.ToInt32(sValue) + " ";
                        sSQL = sSQL + "WHERE SNOTYP = 'ADJ_CYC' ";
                        if (clsDB.FunExecSql(sSQL) == true)
                        {
                            clsDB.FunCommitCtrl("COMMIT");
                        }
                        else
                        {
                            sValue = "";
                            clsDB.FunCommitCtrl("ROLLBACK");
                        }
                    }
                    #endregion
                }
                else
                {
                    #region SNOCTL No Data need to Insert First Data
                    sValue = "0001";
                    clsDB.FunCommitCtrl("BEGIN");
                    sSQL = "INSERT INTO SNOCTL (TRNDATE,SNOTYP,SNO) VALUES ('" + sDate + "','ADJ_CYC'," + Convert.ToInt32(sValue) + " )";
                    if (clsDB.FunExecSql(sSQL) == true)
                    {
                        clsDB.FunCommitCtrl("COMMIT");
                    }
                    else
                    {
                        sValue = "";
                        clsDB.FunCommitCtrl("ROLLBACK");
                    }
                    #endregion
                }
            }

            return sValue;
        }


        #region FunGetAccID() 產生盤點流水號
        public static string FunGetACCID()
        {
            string sLocSno = FunGetAccID_Sub();
            if (sLocSno == "")
            {
                sLocSno = "";
            }
            else
            {
                sLocSno = DateTime.Now.ToString("yyyyMMdd") + sLocSno;
            }
            return sLocSno;
        }

        public static string FunGetAccID_Sub()
        {
            string sSQL = ""; DbDataReader dbRS = null;
            string sValue = ""; int iValue = 0; int iTimes = 0;
            string sDate = DateTime.Now.ToString("yyyyMMdd");

            while (iTimes < 5 && sValue == "")
            {
                sValue = "";
                iTimes = iTimes + 1;
                sSQL = "SELECT SNO,TRNDATE FROM SNOCTL WHERE SNOTYP = 'ACCID' ";
                if (clsDB.FunRsSql(sSQL, ref dbRS))
                {
                    #region Get SNOCTL's SNO
                    while (dbRS.Read())
                    {
                        if (dbRS["TRNDATE"].ToString() == sDate)
                        {
                            iValue = int.Parse(dbRS["SNO"].ToString()) + 1;
                            sValue = iValue.ToString().PadLeft(5, '0');
                            break;
                        }
                        else
                        {
                            sValue = "00001";
                            break;
                        }
                    }
                    dbRS.Close();
                    #endregion

                    #region Update SNOCTL Data
                    if (sValue != "")
                    {
                        clsDB.FunCommitCtrl("BEGIN");
                        sSQL = "UPDATE SNOCTL SET TRNDATE = '" + sDate + "', SNO = " + Convert.ToInt32(sValue) + " ";
                        sSQL = sSQL + "WHERE SNOTYP = 'ACCID' ";
                        if (clsDB.FunExecSql(sSQL) == true)
                        {
                            clsDB.FunCommitCtrl("COMMIT");
                        }
                        else
                        {
                            sValue = "";
                            clsDB.FunCommitCtrl("ROLLBACK");
                        }
                    }
                    #endregion
                }
                else
                {
                    #region SNOCTL No Data need to Insert First Data
                    sValue = "0001";
                    clsDB.FunCommitCtrl("BEGIN");
                    sSQL = "INSERT INTO SNOCTL (TRNDATE,SNOTYP,SNO) VALUES ('" + sDate + "','ACCID'," + Convert.ToInt32(sValue) + " )";
                    if (clsDB.FunExecSql(sSQL) == true)
                    {
                        clsDB.FunCommitCtrl("COMMIT");
                    }
                    else
                    {
                        sValue = "";
                        clsDB.FunCommitCtrl("ROLLBACK");
                    }
                    #endregion
                }
            }

            return sValue;
        }
        #endregion

        #region FunGetEmptyLocByCraneNo()  取得空儲位
        public static string FunGetEmptyLocByCraneNo(int iCnt)
        {
            string strSql = ""; DbDataReader dbRS = null;
            string sLoc = "";
            strSql = "SELECT * FROM LOC_MST WHERE LOC_STS = 'N' AND ROW_X IN (" + (iCnt*2-1) +"," + iCnt*2 + ") ";
            strSql = strSql + "ORDER BY LVL_Z ,BAY_Y ";
            if (clsDB.FunRsSql(strSql, ref dbRS))
            {
                while (dbRS.Read())
                {
                    sLoc = dbRS["LOC"].ToString();
                    break;
                }
                dbRS.Close();
            }
            return sLoc;
        }
        #endregion

        #region FunSetLocSts_StockOut() 預約儲位出庫
        public static bool FunSetLocSts_StockOut(string sLoc)
        {
            string strSql = "UPDATE LOC_MST SET LOC_STS = 'O' WHERE LOC = '" + sLoc + "' AND LOC_STS = 'S' ";
            bool bRet = clsDB.FunExecSql(strSql);            
            return bRet;            
        }
        #endregion

        #region FunSetLocSts_Cycle() 預約儲位出庫(盤點)
        public static bool FunSetLocSts_Cycle(string sLoc)
        {
            string strSql = "UPDATE LOC_MST SET LOC_STS = 'C' WHERE LOC = '" + sLoc + "' AND LOC_STS = 'S' ";
            bool bRet = clsDB.FunExecSql(strSql);
            return bRet;
        }
        #endregion



        //專案客製化的內容
        //變數     
        public static int giCrnMax = 3;
        public static string[] gaStn = new string[] {"A01","A02","A03","D04"};
        public static string gsStnNo = "";          //登入後預設的站號

        //FlagQty
        public static string gsFlagQty_Limit = "X";
        public static string gsFlagQty_ADD = "A";
        public static string gsFlagQty_OUT = "O";
        public static string gsFlagQty_None = " ";

        

        public struct LOC_BASE
        {
            public string LOC;
            public string LOC_ID;
            public string ROW_X;
            public string BAY_Y;
            public string LVL_Z;            
        }

        public struct LOC_Double
        {
            public string LOC1;
            public string LOC1_ID;
            public string LOC2;
            public string LOC2_ID;
        }

        public struct LOC_Single
        {
            public string LOC1;
            public string LOC1_ID;
        }

        #region SubCboSetCrnNo() 設定此專案的高架車清單
        public static void SubCboSetCrnNo(ref ComboBox objCboBox)
        {
            int i = 0; string sCrnNo = "";

            objCboBox.Items.Clear();
            objCboBox.Items.Add("");

            for (i = 1; i <= giCrnMax; i++)
            {
                sCrnNo = i.ToString();
                objCboBox.Items.Add(sCrnNo);
            }
        }
        #endregion

        #region SubCboSetStnNo() 設定此專案的站號清單
        public static void SubCboSetStnNo(ref ComboBox objCboBox)
        {
            int i = 0; 

            objCboBox.Items.Clear();
            objCboBox.Items.Add("");

            for (i = 0; i <= gaStn.Length -1; i++)
            {
                objCboBox.Items.Add(gaStn[i]);
            }
        }
        #endregion

        public static string FunGetStnNoByAreaNo(string sAreaNo)
        {
            string sAreaName = "";
            string strSql = ""; DbDataReader dbRS = null;

            strSql = "SELECT AREA_NAME FROM AREA_CTRL WHERE AREA_NO = '" + sAreaNo + "'";
            if (clsDB.FunRsSql(strSql, ref dbRS))
            {
                while (dbRS.Read())
                {
                    sAreaName = dbRS["AREA_NAME"].ToString();
                }
                dbRS.Close();
            }

            return sAreaName;
        }



        //for 矽品

        #region FunGetLocForDoubleListByLocSts() 取儲位是2個皆為E/N/S的儲位
        public static bool FunGetLocForDoubleListByLocSts(int iCrn, string sLocSts,
                                                          ref string sRtnLoc1, ref string sRtnLocID1,
                                                          ref string sRtnLoc2, ref string sRtnLocID2)
        {
            string sSQL = ""; DbDataReader dbRS = null;
            string sLoc1 = ""; string sLoc2 = "";
            string sLocID1 = ""; string sLocID2 = "";

            sSQL = "SELECT * FROM LOC_MST WHERE LOCSTS = '" + sLocSts + "' ";
            sSQL = sSQL + "AND LOC IN (";
            sSQL = sSQL + "SELECT LOC1 FROM LOC_MST WHERE LOCSTS = '" + sLocSts + "') ";
            if (iCrn == 0)
            {
                //不限Crane
            }
            else
            {
                //限制Crane
                sSQL = sSQL + "AND CRANE_NO = " + iCrn + " ";
            }
            sSQL = sSQL + "AND CRANE_ROW IN (3,2) ";    //取左列
            sSQL = sSQL + "AND (STORAGETYP = '' OR STORAGETYP = ' ') ";
            sSQL = sSQL + "ORDER BY BAY_Y,LVL_Z,ROW_X ";
            //sSQL = sSQL + "ORDER BY LVL_Z,BAY_Y,ROW_X ";
            //sSQL = sSQL + "ORDER BY LVL_Z DESC,BAY_Y,ROW_X ";  //9/28 EMPTY IN 
            if (clsDB.FunRsSql(sSQL, ref dbRS))
            {
                while (dbRS.Read())
                {
                    sLoc1 = dbRS["LOC"].ToString();     //左
                    sLocID1 = dbRS["LOCID"].ToString();
                    sLoc2 = dbRS["LOC1"].ToString();    //右
                    break;
                }
                dbRS.Close();
            }

            sSQL = "SELECT LOCID FROM LOC_MST WHERE LOC = '" + sLoc2 + "' ";
            if (clsDB.FunRsSql(sSQL, ref dbRS))
            {
                while (dbRS.Read())
                {
                    sLocID2 = dbRS["LOCID"].ToString();
                }
                dbRS.Close();
            }

            sRtnLoc1 = sLoc1; sRtnLoc2 = sLoc2;
            sRtnLocID1 = sLocID1; sRtnLocID2 = sLocID2;

            if ((sRtnLoc1 == "") || (sRtnLoc2 == ""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region FunGetLocForSingleListByLocSts() 取單一儲位是為E/N/S的儲位
        public static bool FunGetLocForSingleListByLocSts(int iCrn, string sLocSts, int iLocLR,
                                                          ref string sRtnLoc1, ref string sRtnLocID1)
        {
            string sSQL = ""; DbDataReader dbRS = null;
            string sLoc1 = ""; string sLocID1 = "";

            sSQL = "SELECT * FROM LOC_MST WHERE LOCSTS = '" + sLocSts + "' ";
            sSQL = sSQL + "AND LOC IN (";
            sSQL = sSQL + "SELECT LOC1 FROM LOC_MST WHERE LOCSTS <> '" + sLocSts + "') ";
            if (iCrn == 0)
            {
                //不限Crane
            }
            else
            {
                //限制Crane
                sSQL = sSQL + "AND CRANE_NO = " + iCrn + " ";
            }
            sSQL = sSQL + "AND (STORAGETYP = '' OR STORAGETYP = ' ') ";
            sSQL = sSQL + "AND CRANE_ROW = " + iLocLR + " ";
            sSQL = sSQL + "ORDER BY LVL_Z,BAY_Y,ROW_X ";
            if (clsDB.FunRsSql(sSQL, ref dbRS))
            {
                while (dbRS.Read())
                {
                    sLoc1 = dbRS["LOC"].ToString();     //左
                    sLocID1 = dbRS["LOCID"].ToString();
                }
                dbRS.Close();
            }

            sRtnLoc1 = sLoc1; sRtnLocID1 = sLocID1;
            if (sRtnLoc1 == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region FunGetLocForSingleListByInOutLoc() 取單一儲位是為E/N/S的儲位
        public static bool FunGetLocForSingleListByInOutLoc(int iCrn, string sLocSts, string sLocSts2, int iLR,
                                                            ref string sRtnLoc1, ref string sRtnLocID1)
        {
            string sSQL = ""; DbDataReader dbRS = null;
            string sLoc1 = ""; string sLocID1 = "";

            sSQL = "SELECT * FROM LOC_MST WHERE LOCSTS = '" + sLocSts + "' ";
            sSQL = sSQL + "AND LOC IN (";
            sSQL = sSQL + "SELECT LOC1 FROM LOC_MST WHERE LOCSTS = '" + sLocSts2 + "') ";
            if (iCrn == 0)
            {
                //不限Crane
            }
            else
            {
                //限制Crane
                sSQL = sSQL + "AND CRANE_NO = " + iCrn + " ";
            }
            if (iLR == 1)   //內儲位
            {
                sSQL = sSQL + "AND CRANE_ROW IN (1,2) ";
            }
            else            //外儲位
            {
                sSQL = sSQL + "AND CRANE_ROW IN (3,4) ";
            }
            sSQL = sSQL + "AND (STORAGETYP = '' OR STORAGETYP = ' ') ";
            sSQL = sSQL + "ORDER BY BAY_Y,LVL_Z,ROW_X ";
            //sSQL = sSQL + "ORDER BY LVL_Z,BAY_Y,ROW_X ";

            if (clsDB.FunRsSql(sSQL, ref dbRS))
            {
                while (dbRS.Read())
                {
                    sLoc1 = dbRS["LOC"].ToString();     //左
                    sLocID1 = dbRS["LOCID"].ToString();
                    break;
                }
                dbRS.Close();
            }

            sRtnLoc1 = sLoc1;
            sRtnLocID1 = sLocID1;

            if (sRtnLoc1 == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion


        #region FunGetLocForSingleListByInOutLoc_StorageTyp_Temp() 取單一儲位是為E/N/S的儲位
        public static bool FunGetLocForSingleListByInOutLoc_StorageTyp_Temp(int iCrn, string sLocSts, string sLocSts2, int iLR,
                                                                            ref string sRtnLoc1, ref string sRtnLocID1, int iBayDesc)
        {
            string sSQL = ""; DbDataReader dbRS = null;
            string sLoc1 = ""; string sLocID1 = "";

            sSQL = "SELECT * FROM LOC_MST WHERE LOCSTS = '" + sLocSts + "' ";
            sSQL = sSQL + "AND LOC IN (";
            sSQL = sSQL + "SELECT LOC1 FROM LOC_MST WHERE LOCSTS = '" + sLocSts2 + "') ";
            if (iCrn == 0)
            {
                //不限Crane
            }
            else
            {
                //限制Crane
                sSQL = sSQL + "AND CRANE_NO = " + iCrn + " ";
            }
            if (iLR == 1)   //內儲位
            {
                sSQL = sSQL + "AND CRANE_ROW IN (1,2) ";
            }
            else            //外儲位
            {
                sSQL = sSQL + "AND CRANE_ROW IN (3,4) ";
            }
            sSQL = sSQL + "AND STORAGETYP = 'T' ";
            if (iBayDesc == 1)
            {
                //sSQL = sSQL + "ORDER BY BAY_Y,LVL_Z,ROW_X ";
                sSQL = sSQL + "ORDER BY LVL_Z,BAY_Y,ROW_X ";
            }
            else
            {
                //sSQL = sSQL + "ORDER BY BAY_Y DESC,LVL_Z,ROW_X ";
                sSQL = sSQL + "ORDER BY LVL_Z DESC,BAY_Y,ROW_X ";
            }

            if (clsDB.FunRsSql(sSQL, ref dbRS))
            {
                while (dbRS.Read())
                {
                    sLoc1 = dbRS["LOC"].ToString();     //左
                    sLocID1 = dbRS["LOCID"].ToString();
                    break;
                }
                dbRS.Close();
            }

            sRtnLoc1 = sLoc1; 
            sRtnLocID1 = sLocID1;

            if (sRtnLoc1 == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region FunGetWMSLocByLocID() 取得 WMS儲位
        public static string FunGetWMSLocByLocID(string sLocID)
        {
            string sSQL = ""; DbDataReader dbRS = null;
            string sWMSLoc = "";

            sSQL = "SELECT WMS_LOC FROM SPIL_WMS_LOC WHERE ASRS_LOCID = '" + sLocID + "' ";
            if (clsDB.FunRsSql(sSQL, ref dbRS))
            {
                while (dbRS.Read())
                {
                    sWMSLoc = dbRS["WMS_LOC"].ToString();     
                }
                dbRS.Close();
            }

            return sWMSLoc;
        }
        #endregion

        public static bool FunChkStnNo(string sStnNo)
        {
            if (sStnNo == "")
            {
                clsMSG.ShowWarningMsg(clsMSG.MSG.Msg_Pls_Input_StnNo);
                return false;
            }
            else
            {
                for (int i = 0; i <= clsASRS.gaStn.Length - 1; i++)
                {
                    if (clsASRS.gaStn[i] == sStnNo)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        
        public static bool FunChkLocIdIsExist(string sLocID,ref string sErrMsg)
        {
            string sSQL = ""; DbDataReader dbRS = null;

            string sRdLocID = ""; string sLoc = ""; string sCmdSno = "";

            sSQL = "SELECT LOCID,LOC FROM LOC_MST WHERE LOCID = '" + sLocID + "'";
            if (clsDB.FunRsSql(sSQL, ref dbRS))
            {
                while (dbRS.Read())
                {
                    sRdLocID = dbRS["LOCID"].ToString();
                    sLoc = dbRS["LOC"].ToString();
                }
                dbRS.Close();
            }

            if (sRdLocID != "")
            {
                sErrMsg = "料盤ID己存在儲位["+ sLoc +"]資料中,請查明後再輸入";
                return false;
            }

            sRdLocID = ""; sCmdSno = "";
            sSQL = "SELECT LOCID,CMDSNO FROM CMD_MST WHERE CMDSTS <= '8' AND LOCID = '" + sLocID + "' ";
            if (clsDB.FunRsSql(sSQL, ref dbRS))
            {
                while (dbRS.Read())
                {
                    sRdLocID = dbRS["LOCID"].ToString();
                    sCmdSno = dbRS["CMDSNO"].ToString();
                }
                dbRS.Close();
            }

            if (sRdLocID != "")
            {
                sErrMsg = "料盤ID己存在命令["+ sCmdSno + "]資料中,請查明後再輸入";
                return false;
            }

            return true;
        }

        public static int FunGetCraneNoByLocID(string sLocID)
        {
            int iCrn = 0;

            if (sLocID == "") { return 0; }

            switch (sLocID.Substring(0, 1))
            {
                case "A": iCrn = 1; break;
                case "B": iCrn = 2; break;
                case "C": iCrn = 3; break;
            }
            
            return iCrn;
        }

        public static bool FunSetLocIsPreStkIn(string sLoc1, string sLoc2,ref string sMsg)
        {
            string sSQL = "";
            sSQL = "UPDATE LOC_MST SET LOCSTS = 'I' WHERE LOC = '" + sLoc1 + "' AND LOCSTS = 'N' ";
            if (clsDB.FunExecSql(sSQL) == false)
            {
                sMsg = clsMSG.MSG.COMMAND_ERROR;
                return false;
            }
            if (sLoc2 != "")
            {
                sSQL = "UPDATE LOC_MST SET LOCSTS = 'I' WHERE LOC = '" + sLoc2 + "' AND LOCSTS = 'N' ";
                if (clsDB.FunExecSql(sSQL) == false)
                {
                    sMsg = clsMSG.MSG.COMMAND_ERROR;
                    return false;
                }
            }
            return true;
        }

        public static bool FunSetLocIsPreStkOutForEmpty(string sLoc1, string sLoc2, ref string sMsg)
        {
            string sSQL = "";
            sSQL = "UPDATE LOC_MST SET LOCSTS = 'O' WHERE LOC = '" + sLoc1 + "' AND LOCSTS = 'E' ";
            if (clsDB.FunExecSql(sSQL) == false)
            {
                sMsg = clsMSG.MSG.COMMAND_ERROR;
                return false;
            }
            if (sLoc2 != "")
            {
                sSQL = "UPDATE LOC_MST SET LOCSTS = 'O' WHERE LOC = '" + sLoc2 + "' AND LOCSTS = 'E' ";
                if (clsDB.FunExecSql(sSQL) == false)
                {
                    sMsg = clsMSG.MSG.COMMAND_ERROR;
                    return false;
                }
            }
            return true;
        }

        public static string FunGetLocID_FromLocMst(string sLoc)
        {
            string strSql = ""; DbDataReader dbRS = null;
            string sLocID = "";
            strSql = "SELECT LOCID FROM LOC_MST WHERE LOC = '" + sLoc + "' ";
            if (clsDB.FunRsSql(strSql, ref dbRS))
            {
                while (dbRS.Read())
                {
                    sLocID = dbRS["LOCID"].ToString();
                }
                dbRS.Close();
            }
            return sLocID;
        }


        public static void SetGridColorForOut(ref DataGridView objGrid, int iRow, int iSel)
        {
            int y = 0;
            for (y = 0; y <= objGrid.ColumnCount - 1; y++)
            {
                if (iSel == 1)
                {
                    objGrid.Rows[iRow].Cells[y].Style.BackColor = System.Drawing.Color.GreenYellow;
                }
                else
                {
                    objGrid.Rows[iRow].Cells[y].Style.BackColor = System.Drawing.Color.LightBlue;
                }
            }
        }

        public static void SetGridSeletRowColorHead(ref DataGridView objGrid, int iRow, int iSel)
        {
            int y = 0;
            for (y = 0; y <= objGrid.ColumnCount - 1; y++)
            {
                if (iSel == 1)
                {
                    objGrid.Rows[iRow].Cells[y].Style.BackColor = System.Drawing.Color.Orange;
                }
                else
                {
                    objGrid.Rows[iRow].Cells[y].Style.BackColor = System.Drawing.Color.White;
                }
            }
            if (iSel == 1)
            {
                objGrid.Rows[iRow].HeaderCell.Value = "*";
            }
            else
            {
                objGrid.Rows[iRow].HeaderCell.Value = "";
            }
        }


        //***************************************************************************************************
        //計算批數
        //***************************************************************************************************
        public static int FunGetFosbCnt(ref DataGridView oGrid, int iFOSB_Col)
        {
            int i = 0; int j = 0;  int iCnt = 0;
            
            for (i = 0; i <= oGrid.RowCount - 1; i++)
            {
                if (oGrid[iFOSB_Col, i].Value.ToString() != "")
                {
                    for (j = 0; j <= i; j++)
                    {
                        if (oGrid[iFOSB_Col, i].Value.ToString() == oGrid[iFOSB_Col, j].Value.ToString())
                        {
                            break;
                        }
                    }
                    iCnt = iCnt + 1;

                }
            }
            return iCnt;
        }


        public static bool FunGetLocList(ref string[] aLoc,ref DataGridView objGrid,int iCol_Loc)
        {
            int i = 0; int j = 0; int idx = 0;
            aLoc[0] = "";
            for (i = 0; i <= objGrid.RowCount - 1; i++)
            {
                if (objGrid.Rows[i].HeaderCell.Value.ToString() == "*")
                {
                    if (idx == 0)
                    {
                        aLoc[0] = objGrid[iCol_Loc, i].Value.ToString();
                        idx++;
                    }
                    else
                    {
                        bool bIsOverLay = false;
                        for (j = 0; j <= aLoc.Length - 1; j++)
                        {
                            if (aLoc[j] == objGrid[iCol_Loc, i].Value.ToString())
                            {
                                bIsOverLay = true;
                                break;
                            }
                        }
                        if (bIsOverLay == false)
                        {
                            idx++;
                            Array.Resize<string>(ref aLoc, idx);
                            aLoc[idx - 1] = objGrid[iCol_Loc, i].Value.ToString();
                        }                        
                    }
                }
            }
            if (aLoc.Length <= 1)
            {
                if (aLoc[0] == "")
                {
                    clsMSG.ShowWarningMsg("請選擇要出庫的WMS收料序號");
                    return false;
                }
            }
            return true;
        }

        
        //***************************************************************************************************
        //Function: 設定此專案的盤點確認原因(盤點)
        //***************************************************************************************************
        public static void SetCycResult(ref ComboBox oComBo)
        {            
            oComBo.Items.Clear();
            oComBo.Items.Add(" ");
            oComBo.Items.Add("1:枚數不符");
            oComBo.Items.Add("2:數量不符");
            oComBo.Items.Add("3:與實物不符");
            oComBo.Items.Add("4:其它");
            oComBo.SelectedIndex = 0;
        }


        public static void SetStore(ref ComboBox oComBo)
        {
            oComBo.Items.Clear();
            oComBo.Items.Add("IC");
            oComBo.Items.Add("WAFER.DIE");
            oComBo.Items.Add("Others");
            oComBo.SelectedIndex = 0;
        }






        //定義 ERP_DATA structure
        //ERP入出庫

        public static ERP_QUERY_PARAM sERP_QUERY_PARAM = new ERP_QUERY_PARAM();

        #region 定義 ERP_QUERY_PARAM structure
        public struct ERP_QUERY_PARAM
        {
            public string ITEM_NO;
            public string TKT_NO;            
            public string LOT_NO;
            public string CAR;            
        }
        #endregion
        
        //ERP入出庫回傳選擇單據資料
        public static ERP_DATA[] aERP_DATA = new ERP_DATA[0];

        #region 定義 ERP_DATA structure
        public struct ERP_DATA
        {
            public string ERP_NO;
            public string ITEM_NO;
            public string TRN_QTY;
            public string FIN_QTY;
            public string ASRS_QTY;
            public string TKT_NO;
            public string TKT_SNO;
            public string LOT_NO;
            public string CAR;
            public string STORE;
            public string UNIT;
            public string STD_BOX;
            public string ITEM_DESC;
            public string TRN_DATE;
            public string TRN_USER;
        }
        #endregion
                

        public static void SubCboSetType(ref ComboBox objCboBox)
        {
            objCboBox.Items.Clear();
            objCboBox.Items.Add("");
            objCboBox.Items.Add("權限等級");
            //objCboBox.Items.Add("單位");
            //objCboBox.Items.Add("限制區域");
        }



        public static void SubCboSetLocSts(ref ComboBox objCboBox)
        {
            objCboBox.Items.Clear();
            objCboBox.Items.Add("");
            objCboBox.Items.Add("N:空儲位");
            objCboBox.Items.Add("S:庫存儲位");
            objCboBox.Items.Add("I:入庫預約");
            objCboBox.Items.Add("O:出庫預約");
            objCboBox.Items.Add("C:盤點預約");
            objCboBox.Items.Add("X:禁用儲位");
            objCboBox.Items.Add("E:空料盒儲位");
            objCboBox.Items.Add("A:異常儲位");
        }

        public static void SubCboSetIoType(ref ComboBox objCboBox)
        {
            objCboBox.Items.Clear();
            objCboBox.Items.Add("");
            objCboBox.Items.Add("11:空料盒入庫");
            objCboBox.Items.Add("16:無帳入庫作業");
            //objCboBox.Items.Add("17:手動入庫");
            objCboBox.Items.Add("18:WMS入庫");

            objCboBox.Items.Add("21:空料盒出庫");
            objCboBox.Items.Add("26:無帳出庫作業");
            //objCboBox.Items.Add("27:手動出庫");
            objCboBox.Items.Add("28:WMS出庫作業");
            objCboBox.Items.Add("29:IQC自動出庫");

            objCboBox.Items.Add("31:依儲位盤點");
            objCboBox.Items.Add("32:依料號盤點");
            objCboBox.Items.Add("33:檢視出庫");
            objCboBox.Items.Add("35:WMS盤點");

            objCboBox.Items.Add("51:庫對庫(庫存儲位)");
            objCboBox.Items.Add("52:庫對庫(空料盒)");
            objCboBox.Items.Add("53:庫對庫(重整儲位)");
        }

        public static string FunGetIoTypeByName(string sName)
        {
            string sValue = "";        
            switch (sName)
            {
                //v1.01 case "一般含混載入庫": sValue = "11"; break;
                case "一般含混載入庫": sValue = "12"; break;
                case "ERP入庫": sValue = "14"; break;
                case "加料入庫": sValue = "23"; break;
                case "ERP出庫": sValue = "24"; break;
                case "盤點出庫": sValue = "31"; break;
            }

            return sValue;
        }

        public static string FunGetLocStsName(string sLocSts)
        {
            string sValue = "";

            switch (sLocSts)
            {
                case "N": sValue = "空儲位"; break;
                case "S": sValue = "庫存儲位"; break;
                case "I": sValue = "入庫預約"; break;
                case "O": sValue = "出庫預約"; break;
                case "C": sValue = "盤點預約"; break;
                case "X": sValue = "禁用儲位"; break;
                case "E": sValue = "空棧板儲位"; break;
                case "A": sValue = "異常儲位"; break;            
            }

            return sValue;
        }

        public static string FunGetLocStsName_1(string sLocSts)
        {
            string sValue = "";

            switch (sLocSts)
            {
                case "N": sValue = "N:空儲位"; break;
                case "S": sValue = "S:庫存儲位"; break;
                case "I": sValue = "I:入庫預約"; break;
                case "O": sValue = "O:出庫預約"; break;
                case "C": sValue = "C:盤點預約"; break;
                case "X": sValue = "X:禁用儲位"; break;
                case "E": sValue = "E:空棧板儲位"; break;
                case "A": sValue = "A:異常儲位"; break;
            }

            return sValue;
        }

        public static string FunGetTktStatusName(string sTktSts)
        {
            string sValue = "";

            switch (sTktSts)
            {
                case "0": sValue = "未完成"; break;
                case "1": sValue = "執行中"; break;
                case "9": sValue = "己完成"; break;
                case "F": sValue = "己結單"; break;
                default:
                    sValue = sTktSts; break;
            }

            return sValue;
        }

        public static string FunGetIqcName(string sIqc)
        {
            string sValue = "";

            switch (sIqc)
            {
                case "0": sValue = "合格"; break;
                case "1": sValue = "不合格"; break;
                case "2": sValue = "待驗"; break;
                default:
                    sValue = "合格"; break;
            }

            return sValue;
        }

        public static string FunGetIqcByName(string sIqc)
        {
            string sValue = "";

            switch (sIqc)
            {
                case "合格": sValue = "0"; break;
                case "不合格": sValue = "1"; break;
                case "待驗": sValue = "2"; break;
                default:
                    sValue = "0"; break;
            }

            return sValue;
        }

        public static void SubCboSetLockSts(ref ComboBox objCboBox)
        {
            objCboBox.Items.Clear();
            objCboBox.Items.Add("");
            objCboBox.Items.Add("鎖定");
            objCboBox.Items.Add("解除鎖定");
        }




        public static void SubCboSetIQC(ref ComboBox objCboBox)
        {
            objCboBox.Items.Clear();
            objCboBox.Items.Add("");
            objCboBox.Items.Add("合格");
            objCboBox.Items.Add("不合格");
            objCboBox.Items.Add("待驗");
        }

        public static void SubCboSetIQC_LocDtl(ref ComboBox objCboBox)
        {
            objCboBox.Items.Clear();
            objCboBox.Items.Add("");
            objCboBox.Items.Add("合格");
            objCboBox.Items.Add("不合格");
            objCboBox.Items.Add("待驗");
        }

        public static void SubCboSetItemType(ref ComboBox objCboBox)
        {
            DbDataReader dbRS = null;
            string strSql = "";

            objCboBox.Items.Clear();
            objCboBox.Items.Add("");

            strSql = "SELECT * FROM ITM_TYPE ORDER BY ITEM_TYPE ";
            if (clsDB.FunRsSql(strSql, ref dbRS))
            {
                while (dbRS.Read())
                {
                    objCboBox.Items.Add(dbRS["ITEM_TYPE"].ToString());
                }

                dbRS.Close(); // DbDataReader Close
            }
        }

        public static void SubCboSort(ref ComboBox objCboBox)
        {
            objCboBox.Items.Clear();
            objCboBox.Items.Add("");
            objCboBox.Items.Add("物料編號+批號+儲位");
            objCboBox.Items.Add("物料編號+儲位");
            objCboBox.Items.Add("儲位+物料編號");
            objCboBox.Items.Add("保存剩餘天數");        
        }

        public static string FunGetCmdModeByEvent(string sEvent)
        {
            string sValue = "";

            switch (sEvent)
            {
                case "1": sValue = "入庫"; break;
                case "2": sValue = "全板出庫"; break;
                case "3": sValue = "撿料出庫"; break;
                default:
                    sValue = sEvent; break;
            }

            return sValue;
        }

        public static string FunGetCmdName(string sCmdSts)
        {
            string sValue;
            switch (sCmdSts)
            {
                case "7":
                case "9":
                    sValue = "完成";
                    break;
                case "0":
                case "6":
                    sValue = "取消刪除";
                    break;
                default:
                    sValue = sCmdSts;
                    break;
            }
            return sValue;
        }

        #region FunChkStnIsASRS() 檢查站號是否正確
        public static bool FunChkStnIsASRS(string sStnNo)  //v1.01 2013.01.02 Julia
        {
            if (((sStnNo == "31") | (sStnNo == "32") | (sStnNo == "33") | (sStnNo == "34") |
                 (sStnNo == "41") | (sStnNo == "42") | (sStnNo == "43") | (sStnNo == "44") |
                 (sStnNo == "51") | (sStnNo == "52") | (sStnNo == "53") | (sStnNo == "54") |
                 (sStnNo == "61") | (sStnNo == "62") | (sStnNo == "63") | (sStnNo == "64") ) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region FunInsLocDtl() 寫入儲位明細
        public static bool FunInsLocDtl(ref clsASRS.LOC_DTL tLoc_Dtl)
        {
            string sSQL = "";

            sSQL = "INSERT INTO LOC_DTL (LOC,LOC_SNO,ITEM_NO,LOT_NO,STATUS,IQC,TKT_NO,TKT_SNO,PLT_QTY,ALO_QTY,IN_DATE,";
            sSQL = sSQL + "PROD_DATE,BEST_DATE,CYCLE_DATE,PROG_ID,PROG_NAME,REMARKS) VALUES (";
            sSQL = sSQL + "'" + tLoc_Dtl.LOC + "',";
            sSQL = sSQL + "'" + tLoc_Dtl.LOC_SNO + "',";
            sSQL = sSQL + "'" + tLoc_Dtl.ITEM_NO + "',";
            sSQL = sSQL + "'" + tLoc_Dtl.LOT_NO + "',";
            sSQL = sSQL + "'" + tLoc_Dtl.STATUS + "',";
            sSQL = sSQL + "'" + tLoc_Dtl.IQC + "',";
            sSQL = sSQL + "'" + tLoc_Dtl.TKT_NO + "',";
            sSQL = sSQL + "'" + tLoc_Dtl.TKT_SNO + "',";
            sSQL = sSQL + tLoc_Dtl.PLT_QTY + ",";
            sSQL = sSQL + "0,";
            sSQL = sSQL + "'" + tLoc_Dtl.IN_DATE + "',";
            sSQL = sSQL + "'" + tLoc_Dtl.PROD_DATE + "',";
            sSQL = sSQL + "'" + tLoc_Dtl.BEST_DATE + "',";
            sSQL = sSQL + "'" + tLoc_Dtl.CYCLE_DATE + "',";
            sSQL = sSQL + "'" + tLoc_Dtl.PROG_ID + "',";
            sSQL = sSQL + "'" + tLoc_Dtl.PROG_NAME + "',";
            sSQL = sSQL + "'" + tLoc_Dtl.REMARKS + "') ";

            if (clsDB.FunExecSql(sSQL) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion


        public static bool FunGetLocN_ByE(int iCrn, ref string sGetLoc1, ref string sGetLocID1, int iBayDesc)
        {
            //(1)先找內側儲位為N,外側儲位為E
            if (clsASRS.FunGetLocForSingleListByInOutLoc(iCrn, "N", "E", 1, ref sGetLoc1, ref sGetLocID1) == false)
            {
                //(2)找內側儲位為N,外側儲位為E. (TEMP 儲位)
                if (clsASRS.FunGetLocForSingleListByInOutLoc_StorageTyp_Temp(iCrn, "N", "E", 1, ref sGetLoc1, ref sGetLocID1, iBayDesc) == false)
                {
                    //(4)找外側儲位為N,內側儲位為N,
                    if (clsASRS.FunGetLocForSingleListByInOutLoc(iCrn, "N", "N", 2, ref sGetLoc1, ref sGetLocID1) == false)
                    {
                        //(3)找外側儲位為N,內側儲位為N. (TEMP 儲位)
                        if (clsASRS.FunGetLocForSingleListByInOutLoc_StorageTyp_Temp(iCrn, "N", "N", 2, ref sGetLoc1, ref sGetLocID1, iBayDesc) == false)
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        public static bool FunGetLocN_ByS(int iCrn, ref string sGetLoc1, ref string sGetLocID1, int iBayDesc)
        {
            //(1)先找內側儲位為N,外側儲位為S
            if (clsASRS.FunGetLocForSingleListByInOutLoc(iCrn, "N", "S", 1, ref sGetLoc1, ref sGetLocID1) == false)
            {
                //(2)找內側儲位為N,外側儲位為S. (TEMP 儲位)
                if (clsASRS.FunGetLocForSingleListByInOutLoc_StorageTyp_Temp(iCrn, "N", "S", 1, ref sGetLoc1, ref sGetLocID1, iBayDesc) == false)
                {
                    //(4)找外側儲位為N,內側儲位為N,
                    if (clsASRS.FunGetLocForSingleListByInOutLoc(iCrn, "N", "N", 2, ref sGetLoc1, ref sGetLocID1) == false)
                    {
                        //(3)找外側儲位為N,內側儲位為N. (TEMP 儲位)
                        if (clsASRS.FunGetLocForSingleListByInOutLoc_StorageTyp_Temp(iCrn, "N", "N", 2, ref sGetLoc1, ref sGetLocID1, iBayDesc) == false)
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }




        public static bool FunChkCycleStsIsRunning(ref string sRtnMsg)
        {
            string sStatus = ""; string sType = ""; string sTypeNo = "";
            if (FunGetLocAdjFlag(ref sStatus, ref sType, ref sTypeNo) == true)
            {
                if (sStatus == "Y")
                {
                    sRtnMsg = "目前正在執行儲位重整中,請稍後再執行!!";
                    return false;
                }
                else
                {
                    //Z:自動暫停/ P:暫停/ N:停止
                    //判斷是否有 Hold儲位
                    if (ChkCraneHoldLoc() == true)
                    {
                        //沒有Hold儲位
                        return true;
                    }
                    else
                    {
                        //有Hold儲位,待Hold儲位重整完成
                        sRtnMsg = "目前己暫停儲位重整中,部份料盒還在重整中,請稍後再執行!!";
                        return false;
                    }
                }
            }

            return false;
        }

        public static bool FunGetLocAdjFlag(ref string sFlag, ref string sType, ref string sTypeNo)
        {
            //[CYCLE_TYPE]  A:預盤 / B:呆滯品 / C:IQC
            //[STATUS]      Y:啓動 / N:停止  / P:暫停 / Z:自動暫停 (註:同一時間只能有一個 Y or Z or P, 其它為 N)
            string sSQL = ""; DbDataReader dbRS = null;
            sFlag = ""; sType = ""; sTypeNo = "";

            //判斷是否有 Y:啓動  / P:暫停 / Z:自動暫停
            sSQL = "SELECT * FROM CYCLE_STS WHERE STATUS <> 'N' ";
            if (clsDB.FunRsSql(sSQL, ref dbRS))
            {
                while (dbRS.Read())
                {
                    sFlag = dbRS["STATUS"].ToString();
                    sType = dbRS["CYCLE_TYPE"].ToString();
                    sTypeNo = dbRS["TYPE_NO"].ToString();
                }
                dbRS.Close();
            }

            if (sFlag != "") { return true; }

            sFlag = "N"; return true;
        }

        public static bool ChkCraneHoldLoc()
        {
            string sSQL = ""; DbDataReader dbRS = null;
            int iCnt = 0;

            sSQL = "SELECT COUNT(*) FROM LOC_MST WHERE LOCSTS = 'H' ";
            if (clsDB.FunRsSql(sSQL, ref dbRS))
            {
                while (dbRS.Read())
                {
                    iCnt = clsTool.INT(dbRS[0].ToString());
                }
                dbRS.Close();

                if (iCnt <= 0)
                {
                    return true;
                }
            }
            return false;
        }

        #region FunGetStnNoByLoc_SPIL_ZX(sLoc) 矽品中科廠,由儲位取出1F前側的站號
        public static string FunGetStnNoByLoc_SPIL_ZX(string sLoc)
        {
            if (sLoc.Length < 6) { return ""; }

            int iRow = clsTool.INT(sLoc.Substring(0, 2));            
            int iCrn = (iRow + 3) / 4;
            switch (iCrn)
            {
                case 1: return "A01"; 
                case 2: return "A02"; 
                case 3: return "A03"; 
                default: return "";
            }
        }
        #endregion

    }


    class cls_CmdMst
    {
        #region Define
        public string CMDSNO = "";
        public string SNO1 = "";
        public string SNO2 = "";
        public string CMDSTS = "";
        public string PRT = "";
        public string STNNO = "";
        public string CMDMODE = "";
        public string IOTYP = "";
        public string LOC1 = "";
        public string LOC2 = "";
        public string NEWLOC = "";
        public string AVAIL = "";
        public string MIXQTY = "";        
        public string LOCID1 = "";
        public string LOCID2 = "";
        public string PROGID = "";
        public string USERID = "";
        public string TRACE = "";
        public string STORAGETYP = "";
        public string SCAN1 = "";
        public string SCAN2 = "";
        #endregion

        #region FunCmdMstClear() 清除變數
        public  void FunCmdMstClear()
        {
            CMDSNO = "";
            SNO1 = "";
            SNO2 = "";
            CMDSTS = "";
            PRT = "";
            STNNO = "";
            CMDMODE = "";
            IOTYP = "";
            LOC1 = "";
            LOC2 = "";
            NEWLOC = "";
            AVAIL = "";
            MIXQTY = "";
            LOCID1 = "";
            LOCID2 = "";
            PROGID = "";
            USERID = "";
            TRACE = "";
            STORAGETYP = "";
            SCAN1 = "";
            SCAN2 = "";
        }
        #endregion

        #region FunInsCmdMst() 寫入CMD_MST
        public bool FunInsCmdMst()
        {
            string strSql = "";
            strSql = "INSERT INTO CMD_MST (CMDSNO,SNO,CMDSTS,PRT,STNNO,CMDMODE,IOTYP,LOC,NEWLOC,";
            strSql = strSql + "AVAIL,MIXQTY,TRNDATE,ACTTIME,EXPTIME,ENDTIME,PROGID,USERID,LOCID,TRACE,STORAGETYP,SCAN) VALUES (";
            strSql = strSql + "'" + CMDSNO + "',";
            strSql = strSql + "'" + SNO1 + "',";
            strSql = strSql + "'" + CMDSTS + "',";
            strSql = strSql + "'" + PRT + "',";
            strSql = strSql + "'" + STNNO + "',";
            strSql = strSql + "'" + CMDMODE + "',";
            strSql = strSql + "'" + IOTYP + "',";
            strSql = strSql + "'" + LOC1 + "',";
            strSql = strSql + "'" + NEWLOC + "',";
            strSql = strSql + AVAIL + ",";
            strSql = strSql + MIXQTY + ",";
            strSql = strSql + "'" + clsTool.GetDate() + "',";
            strSql = strSql + "'" + clsTool.GetTime() + "',";
            strSql = strSql + "'',";
            strSql = strSql + "'',";
            strSql = strSql + "'" + PROGID + "',";
            strSql = strSql + "'" + USERID + "',";
            strSql = strSql + "'" + LOCID1 + "',";
            strSql = strSql + "'" + TRACE + "',";
            strSql = strSql + "'" + STORAGETYP + "',";
            strSql = strSql + "'" + SCAN1 + "')";

            if (clsDB.FunExecSql(strSql) == true)
            {
                if (LOC2 != "")
                {
                    strSql = "INSERT INTO CMD_MST (CMDSNO,SNO,CMDSTS,PRT,STNNO,CMDMODE,IOTYP,LOC,NEWLOC,";
                    strSql = strSql + "AVAIL,MIXQTY,TRNDATE,ACTTIME,EXPTIME,ENDTIME,PROGID,USERID,LOCID,TRACE,STORAGETYP,SCAN) VALUES (";
                    strSql = strSql + "'" + CMDSNO + "',";
                    strSql = strSql + "'" + SNO2 + "',";
                    strSql = strSql + "'" + CMDSTS + "',";
                    strSql = strSql + "'" + PRT + "',";
                    strSql = strSql + "'" + STNNO + "',";
                    strSql = strSql + "'" + CMDMODE + "',";
                    strSql = strSql + "'" + IOTYP + "',";
                    strSql = strSql + "'" + LOC2 + "',";
                    strSql = strSql + "'" + NEWLOC + "',";
                    strSql = strSql + AVAIL + ",";
                    strSql = strSql + MIXQTY + ",";
                    strSql = strSql + "'" + clsTool.GetDate() + "',";
                    strSql = strSql + "'" + clsTool.GetTime() + "',";
                    strSql = strSql + "'',";
                    strSql = strSql + "'',";
                    strSql = strSql + "'" + PROGID + "',";
                    strSql = strSql + "'" + USERID + "',";
                    strSql = strSql + "'" + LOCID2 + "',";
                    strSql = strSql + "'" + TRACE + "',";
                    strSql = strSql + "'" + STORAGETYP + "',";
                    strSql = strSql + "'" + SCAN2 + "')";
                    if (clsDB.FunExecSql(strSql) == true)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
        #endregion
    }

    class cls_CmdDtl
    {
        #region Define
        public string CMDSNO = "";
        public string LOCID = "";
        public string SNO = "";
        public string SUBLOC = "";//NO USE
        public string ITEMNO = "";
        public string CUSTOMER = "";
        public string DEVICE = "";
        public string LOTNO = "";
        public string STORE = "";
        public int OFFQTY = 0;
        public int WAFERQTY = 0;
        public int SHIPQTY = 0;
        public int OFFACTQTY = 0;
        public int WAFERACTQTY = 0;
        public int SHIPACTQTY = 0;
        public string FLAGQTY = "";
        public string CHKIQC = "";
        public string FOSBID = "";
        public string IQC_ID = "";
        public string ACC_ID = "";
        public string INDATE = "";
        public string REMARK = "";
        public string TRANSACTION_DATE = "";
        public string GIB_CUSTOMER = "";
        public string FAB_LOT_NO = "";
        public string FAB_TYPE = "";
        public string TYPENO = "";
        public string LOT_TYPE = "";
        public string WAFER_SIZE = "";
        public string YIELD = "";
        public string APP_NO = "";
        public string REL_DATE = "";
        public string REASON_NAME = "";
        public string TRANSACTION_REFERENCE = "";
        public string TRANSACTION_SOURCE_ID = "";
        public string TRANSACTION_TYPE_ID = "";
        public string FROM_ORG = "";
        public string TO_ORG = "";
        public string FROM_BANK = "";
        public string TO_BANK = "";
        public string CYCLENO = "";
        public string COID = "";
        public string SNID = "";
        public string DOCID = "";
        public string DOCID2 = "";
        #endregion

        #region FunCmdDtlClear() 清除變數
        public void FunCmdDtlClear()
        {
            CMDSNO = "";
            LOCID = "";
            SNO = "";
            SUBLOC = "";
            ITEMNO = "";
            CUSTOMER = "";
            DEVICE = "";
            LOTNO = "";
            STORE = "";
            OFFQTY = 0;
            WAFERQTY = 0;
            SHIPQTY = 0;
            OFFACTQTY = 0;
            WAFERACTQTY = 0;
            SHIPACTQTY = 0;
            FLAGQTY = "";
            CHKIQC = "";
            FOSBID = "";
            IQC_ID = "";
            ACC_ID = "";
            INDATE = "";
            REMARK = "";
            TRANSACTION_DATE = "";
            GIB_CUSTOMER = "";
            FAB_LOT_NO = "";
            FAB_TYPE = "";
            TYPENO = "";
            LOT_TYPE = "";
            WAFER_SIZE = "";
            YIELD = "";
            APP_NO = "";
            REL_DATE = "";
            REASON_NAME = "";
            TRANSACTION_REFERENCE = "";
            TRANSACTION_SOURCE_ID = "";
            TRANSACTION_TYPE_ID = "";
            FROM_ORG = "";
            TO_ORG = "";
            FROM_BANK = "";
            TO_BANK = "";
            CYCLENO = "";
            COID = "";
            SNID = "";
            DOCID = "";
            DOCID2 = "";        
        }
        #endregion

        #region FunInsCmdDtl() 寫入 CMD_DTL
        public bool FunInsCmdDtl()
        {
            string strSql = "";
            strSql = "INSERT INTO CMD_DTL (CMDSNO,LocID,SNO,ITEMNO,CUSTOMER,DEVICE,LOTNO,STORE,";
            strSql = strSql + "OFFQTY,WAFERQTY,SHIPQTY,OFFACTQTY,WAFERACTQTY,SHIPACTQTY,";
            strSql = strSql + "FLAGQTY,CHKIQC,FOSBID,IQC_ID,ACC_ID,INDATE,REMARK,TRANSACTION_DATE,";
            strSql = strSql + "GIB_CUSTOMER,FAB_LOT_NO,FAB_TYPE,TYPENO,LOT_TYPE,WAFER_SIZE,YIELD,";
            strSql = strSql + "APP_NO,REL_DATE,REASON_NAME,TRANSACTION_REFERENCE,TRANSACTION_SOURCE_ID,";
            strSql = strSql + "TRANSACTION_TYPE_ID,FROM_ORG,TO_ORG,FROM_BANK,TO_BANK,CYCLENO,COID,SNID,DOCID,DOCID2) VALUES (";
            strSql = strSql + "'" + CMDSNO + "',";
            strSql = strSql + "'" + LOCID + "',";
            strSql = strSql + "'" + SNO + "',"; //?
            strSql = strSql + "'" + ITEMNO + "',";
            strSql = strSql + "'" + CUSTOMER + "',";
            strSql = strSql + "'" + DEVICE + "',";
            strSql = strSql + "'" + LOTNO + "',";
            strSql = strSql + "'" + STORE + "',";
            strSql = strSql + OFFQTY + ",";
            strSql = strSql + WAFERQTY + ",";
            strSql = strSql + SHIPQTY + ",";
            strSql = strSql + OFFACTQTY + ",";
            strSql = strSql + WAFERACTQTY + ",";
            strSql = strSql + SHIPACTQTY + ",";
            strSql = strSql + "'" + FLAGQTY + "',";
            strSql = strSql + "'" + CHKIQC + "',";
            strSql = strSql + "'" + FOSBID + "',";
            strSql = strSql + "'" + IQC_ID + "',";
            strSql = strSql + "'" + ACC_ID + "',";
            strSql = strSql + "'" + INDATE + "',";
            strSql = strSql + "'" + REMARK + "',";
            strSql = strSql + "'" + TRANSACTION_DATE + "',";
            strSql = strSql + "'" + GIB_CUSTOMER + "',";
            strSql = strSql + "'" + FAB_LOT_NO + "',";
            strSql = strSql + "'" + FAB_TYPE + "',";
            strSql = strSql + "'" + TYPENO + "',";
            strSql = strSql + "'" + LOT_TYPE + "',";
            strSql = strSql + "'" + WAFER_SIZE + "',";
            strSql = strSql + "'" + YIELD + "',";
            strSql = strSql + "'" + APP_NO + "',";
            strSql = strSql + "'" + REL_DATE + "',";
            strSql = strSql + "'" + REASON_NAME + "',";
            strSql = strSql + "'" + TRANSACTION_REFERENCE + "',";
            strSql = strSql + "'" + TRANSACTION_SOURCE_ID + "',";
            strSql = strSql + "'" + TRANSACTION_TYPE_ID + "',";
            strSql = strSql + "'" + FROM_ORG + "',";
            strSql = strSql + "'" + TO_ORG + "',";
            strSql = strSql + "'" + FROM_BANK + "',";
            strSql = strSql + "'" + TO_BANK + "',";
            strSql = strSql + "'" + CYCLENO + "', ";
            strSql = strSql + "'" + COID + "',";
            strSql = strSql + "'" + SNID + "',";
            strSql = strSql + "'" + DOCID + "',";
            strSql = strSql + "'" + DOCID2 + "') ";

            if (clsDB.FunExecSql(strSql) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion


    }

    class cls_Cycle
    {
        #region Define
        public string CYCLENO = "";
        public string LOC = "";
        public string LOCID = "";
        public string ITEMNO = "";
        public string CUSTOMER = "";
        public string DEVICE = "";
        public string LOTNO = "";
        public string STORE = "";
        public int OFFQTY = 0;
        public int WAFERQTY = 0;
        public int SHIPQTY = 0;
        public int CYCOFFQTY = 0;
        public int CYCWAFERQTY = 0;
        public int CYCSHIPQTY = 0;        

        public string CHKIQC = "";
        public string ONDATA = "";
        public string FOSBID = "";
        public string IQC_ID = "";
        public string ACC_ID = "";
        public string INDATE = "";
        public string TRNDATE = "";
        public string REMARK = "";
        public string TRANSACTION_DATE = "";
        public string GIB_CUSTOMER = "";
        public string FAB_LOT_NO = "";
        public string FAB_TYPE = "";
        public string TYPENO = "";
        public string LOT_TYPE = "";
        public string WAFER_SIZE = "";
        public string YIELD = "";
        public string APP_NO = "";
        public string REL_DATE = "";
        public string REASON_NAME = "";
        public string TRANSACTION_REFERENCE = "";
        public string TRANSACTION_SOURCE_ID = "";
        public string TRANSACTION_TYPE_ID = "";
        public string FROM_ORG = "";
        public string TO_ORG = "";
        public string FROM_BANK = "";
        public string TO_BANK = "";
        public string USER_CREAT = "";
        public string DOCID = "";
        public string DOCID2 = "";
        #endregion

        #region FunCycleClear() 清除變數
        public void FunCycleClear()
        {
            CYCLENO = "";
            LOC = "";
            LOCID = "";
            ITEMNO = "";
            CUSTOMER = "";
            DEVICE = "";
            LOTNO = "";
            STORE = "";
            OFFQTY = 0;
            WAFERQTY = 0;
            SHIPQTY = 0;
            CYCOFFQTY = 0;
            CYCWAFERQTY = 0;
            CYCSHIPQTY = 0;

            CHKIQC = "";
            ONDATA = "";
            FOSBID = "";
            IQC_ID = "";
            ACC_ID = "";
            INDATE = "";
            TRNDATE = "";
            REMARK = "";
            TRANSACTION_DATE = "";
            GIB_CUSTOMER = "";
            FAB_LOT_NO = "";
            FAB_TYPE = "";
            TYPENO = "";
            LOT_TYPE = "";
            WAFER_SIZE = "";
            YIELD = "";
            APP_NO = "";
            REL_DATE = "";
            REASON_NAME = "";
            TRANSACTION_REFERENCE = "";
            TRANSACTION_SOURCE_ID = "";
            TRANSACTION_TYPE_ID = "";
            FROM_ORG = "";
            TO_ORG = "";
            FROM_BANK = "";
            TO_BANK = "";
            USER_CREAT = "";
            DOCID = "";
            DOCID2 = "";
        }
        #endregion

        #region FunInsCycle() 寫入 Cycle
        public bool FunInsCycle()
        {
            string strSql = "";
            strSql = "INSERT INTO CYCLE (CYCLENO,LOC,LOCID,ITEMNO,CUSTOMER,DEVICE,LOTNO,STORE,";
            strSql = strSql + "OFFQTY,WAFERQTY,SHIPQTY,CYCOFFQTY,CYCWAFERQTY,CYCSHIPQTY,CHKOFFQTY,CHKWAFERQTY,CHKSHIPQTY,";
            strSql = strSql + "CHKIQC,ONDATA,FOSBID,IQC_ID,ACC_ID,INDATE,TRNDATE,REMARK,TRANSACTION_DATE,GIB_CUSTOMER,";
            strSql = strSql + "FAB_LOT_NO,FAB_TYPE,TYPENO,LOT_TYPE,WAFER_SIZE,YIELD,APP_NO,REL_DATE,REASON_NAME,TRANSACTION_REFERENCE,";
            strSql = strSql + "TRANSACTION_SOURCE_ID,TRANSACTION_TYPE_ID,FROM_ORG,TO_ORG,FROM_BANK,TO_BANK,";
            strSql = strSql + "USER_CREAT,USER_CYC,USER_CHK,CYC_STATUS,CYC_RESULT,DOCID,DOCID2) VALUES (";
            strSql = strSql + "'" + CYCLENO + "',";
            strSql = strSql + "'" + LOC + "',";
            strSql = strSql + "'" + LOCID + "',";
            strSql = strSql + "'" + ITEMNO + "',";
            strSql = strSql + "'" + CUSTOMER + "',";
            strSql = strSql + "'" + DEVICE + "',";
            strSql = strSql + "'" + LOTNO + "',";
            strSql = strSql + "'" + STORE + "',";

            strSql = strSql + OFFQTY + ",";
            strSql = strSql + WAFERQTY + ",";
            strSql = strSql + SHIPQTY + ",";
            strSql = strSql + CYCOFFQTY + ",";
            strSql = strSql + CYCWAFERQTY + ",";
            strSql = strSql + CYCSHIPQTY + ",";
            strSql = strSql + "0,";
            strSql = strSql + "0,";
            strSql = strSql + "0,";

            strSql = strSql + "'" + CHKIQC + "',";
            strSql = strSql + "'" + ONDATA + "',";
            strSql = strSql + "'" + FOSBID + "',";
            strSql = strSql + "'" + IQC_ID + "',";
            strSql = strSql + "'" + ACC_ID + "',";
            strSql = strSql + "'" + INDATE + "',";
            strSql = strSql + "'" + TRNDATE + "',";
            strSql = strSql + "'" + REMARK + "',";
            strSql = strSql + "'" + TRANSACTION_DATE + "',";
            strSql = strSql + "'" + GIB_CUSTOMER + "',";

            strSql = strSql + "'" + FAB_LOT_NO + "',";
            strSql = strSql + "'" + FAB_TYPE + "',";
            strSql = strSql + "'" + TYPENO + "',";
            strSql = strSql + "'" + LOT_TYPE + "',";
            strSql = strSql + "'" + WAFER_SIZE + "',";
            strSql = strSql + "'" + YIELD + "',";
            strSql = strSql + "'" + APP_NO + "',";
            strSql = strSql + "'" + REL_DATE + "',";
            strSql = strSql + "'" + REASON_NAME + "',";
            strSql = strSql + "'" + TRANSACTION_REFERENCE + "',";

            strSql = strSql + "'" + TRANSACTION_SOURCE_ID + "',";
            strSql = strSql + "'" + TRANSACTION_TYPE_ID + "',";
            strSql = strSql + "'" + FROM_ORG + "',";
            strSql = strSql + "'" + TO_ORG + "',";
            strSql = strSql + "'" + FROM_BANK + "',";
            strSql = strSql + "'" + TO_BANK + "',";

            strSql = strSql + "'" + USER_CREAT + "',";
            strSql = strSql + "' ',";    //USER_CYC
            strSql = strSql + "' ',";    //USER_CHK
            strSql = strSql + "'1',";    //CYC_STATUS
            strSql = strSql + "' ',";    //CYC_RESULT

            strSql = strSql + "'" + DOCID + "',";
            strSql = strSql + "'" + DOCID2 + "') ";

            if (clsDB.FunExecSql(strSql) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

    }

}
