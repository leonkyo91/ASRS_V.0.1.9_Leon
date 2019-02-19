using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ASRS
{
    class clsDB
    {
        public static SqlConnection SqlDBConn;
        public static SqlTransaction SqlDBTran;

        public static bool bConnDB;

        // ***************************************
        // Open DataBase
        // ***************************************
        public static bool FunOpenDB()
        {
            string sConnect = "";
            try
            {
                sConnect = "Initial Catalog=" + clsParam.gsDB_DSN + ";Password=" + clsParam.gsDB_Pwd + ";";
                sConnect = sConnect + "User ID=" + clsParam.gsDB_User + ";Data Source=" + clsParam.gsDB_Server;
                //sConnect = sConnect + ";Failover Partner="";

                SqlDBConn = new SqlConnection(sConnect);
                SqlDBConn.Open();
                bConnDB = true;                
                return true;
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message + "\n" + sConnect);
                bConnDB = false;
                SqlDBConn.Close();
                return false;
            }
        }


        //***************************************************************************************************
        //Function: Close DB
        //***************************************************************************************************
        public static bool FunClsDB()
        {
            try
            {               
                SqlDBConn.Close();
                return true;
            }
            catch
            {                
                return false;
            }
        }


        //***************************************************************************************************
        //Function: BEGIN / COMMIT / ROLLBACK
        //***************************************************************************************************
        public static bool FunCommitCtrl(string sCommitLvl)
        {
            try
            {
                switch (sCommitLvl)
                {
                    case "BEGIN":
                        SqlDBTran = SqlDBConn.BeginTransaction();
                        break;
                    case "COMMIT":
                        SqlDBTran.Commit();
                        break;
                    case "ROLLBACK":
                        SqlDBTran.Rollback();
                        break;
                }
                return true;
            }
            catch
            {
                SqlDBTran.Rollback();
                return false;
            }
        }


        //***************************************************************************************************
        //Function: Query (無資料時直接關閉物件,並回傳False)
        //***************************************************************************************************
        public static bool FunRsSql(string pSql, ref System.Data.Common.DbDataReader SqlRs)
        {
            try
            {
                SqlCommand SqlDbCmd = new SqlCommand(pSql);
                SqlDbCmd.Connection = SqlDBConn;
                SqlRs = SqlDbCmd.ExecuteReader();

                if (!(SqlRs.HasRows))   //無資料則Close
                {
                    //cls_Param.FunWriteLog( pSql + " (No Data)");
                    SqlRs.Close();
                    return false;
                }
                else
                {
                    //cls_Param.FunWriteLog(pSql);
                    return true;
                }
            }
            catch 
            {
                return false;
            }
        }


        //***************************************************************************************************
        //Function: Insert / Update / Delete
        //***************************************************************************************************
        public static bool FunExecSql(string pSql)
        {
            try
            {
                SqlCommand SqlDbCmd = new SqlCommand(pSql);
                SqlDbCmd.Connection = SqlDBConn;
                SqlDbCmd.Transaction = SqlDBTran;
                bool bReturnValue;
                bReturnValue = (SqlDbCmd.ExecuteNonQuery() <= 0 ? false : true);

                return bReturnValue;
            }
            catch
            {
                return false;
            }
        }    
    }
}
