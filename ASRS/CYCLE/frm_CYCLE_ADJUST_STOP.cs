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
    public partial class frm_CYCLE_ADJUST_STOP : Form
    {

        #region Grid1 Parameter
        //int iCol_FOSB = 0;
        int iCol_LOCID = 0;
        int iCol_LOC = 1;
        int iCol_NEWLOC = 2;
        int iCol_STATUS = 3;

        int iCol_FOSBID = 4;
        int iCol_LOTNO = 5;
        int iCol_Customer = 6;

        int iCol_REMARK = 7;
        int iCol_Counts = 8;
        #endregion

        public static string gsStatus = "";

        public frm_CYCLE_ADJUST_STOP()
        {
            InitializeComponent();
        }

        private void frm_CYCLE_ADJUST_STOP_Load(object sender, EventArgs e)
        {
            GridInit();
            FormInit();
            FormCls();
        }

        private void GridInit()
        {
            GridSysInit(ref Grid1); GridSetRange1(ref Grid1);
        }

        private void GridSysInit(ref DataGridView oGrid)
        {
            try
            {
                //指定 Column 的字體
                oGrid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.WhiteSmoke;
                oGrid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.Black;

                //指定 Row 的字體
                oGrid.RowHeadersDefaultCellStyle.BackColor = System.Drawing.Color.WhiteSmoke;
                oGrid.RowHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                oGrid.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                oGrid.ReadOnly = true;               //不允許修改
                oGrid.AllowUserToAddRows = false;    //不允許使用者從 DataGridView 中增加資料列。
                oGrid.AllowUserToDeleteRows = false; //不允許使用者從 DataGridView 中刪除資料列。 
                oGrid.AllowUserToResizeRows = false; //不允許調整資料列的大小。
                oGrid.MultiSelect = false;           //不允許多選列
                //.SelectionMode = DataGridViewSelectionMode.FullRowSelect                    '選擇整Row方式
                oGrid.SelectionMode = DataGridViewSelectionMode.CellSelect;    //選擇單一Row方式

                oGrid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;  //字體對齊位置
            }
            catch (Exception ex)
            {
                clsMSG.ShowWarningMsg(clsMSG.MSG.SYSTEM_NG + " " + ex.ToString());
            }

        }

        private void GridSetRange1(ref DataGridView oGrid)
        {
            oGrid.ColumnCount = iCol_Counts;
            oGrid.RowCount = 1;

            //oGrid.Columns[iCol_FOSB].Width = 100; oGrid.Columns[iCol_FOSB].Name = "FOSBID";
            oGrid.Columns[iCol_LOCID].Width = 100; oGrid.Columns[iCol_LOCID].Name = "料盒ID";
            oGrid.Columns[iCol_LOC].Width = 100; oGrid.Columns[iCol_LOC].Name = "儲位編號";
            oGrid.Columns[iCol_NEWLOC].Width = 100; oGrid.Columns[iCol_NEWLOC].Name = "重整後儲位"; oGrid.Columns[iCol_NEWLOC].Visible = false;
            oGrid.Columns[iCol_STATUS].Width = 200; oGrid.Columns[iCol_STATUS].Name = "狀態";

            oGrid.Columns[iCol_FOSBID].Width = 120; oGrid.Columns[iCol_FOSBID].Name = "收料序號";
            oGrid.Columns[iCol_LOTNO].Width = 120; oGrid.Columns[iCol_LOTNO].Name = "批號";
            oGrid.Columns[iCol_Customer].Width = 120; oGrid.Columns[iCol_Customer].Name = "客戶簡稱";

            oGrid.Columns[iCol_REMARK].Width = 300; oGrid.Columns[iCol_REMARK].Name = "備註";

            oGrid.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            oGrid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft; 

            int i = 0;
            for (i = 0; i <= oGrid.ColumnCount - 1; i++)
            {
                oGrid.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            oGrid.RowCount = 0;
        }

        private void FormInit()
        {
            FormCls();
        }

        private void FormCls()
        {
            txtCycle_Type.Text = ""; txtCycle_TypeName.Text = "";
            txtType.Text = ""; txtTypeNo.Text = "";
            txtState.Text = "";
            txtQty.Text = "";
            Grid1.RowCount = 0;
            gsStatus = "";
            
        }
        
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };
            SubQuery();
            clsDB.FunClsDB();
        }

        private void SubQuery()
        {
            FormCls();

            string sCycle_Type = ""; string sType_No = "";
            if (SubQuery_Sts(ref sCycle_Type, ref sType_No) == true)
            {
                SubQuery_Data(sCycle_Type, sType_No);
            }
        }


        private bool SubQuery_Sts(ref string sCycle_Type, ref string sType_No)
        {            
            string strSQL = ""; DbDataReader dbRS = null;
            //string sCycle_Type = ""; string sType_No = ""; 
            string sType_Name = ""; string sStatus = "";
            strSQL = "SELECT * FROM CYCLE_STS WHERE STATUS <> 'N' ";
            if (clsDB.FunRsSql(strSQL, ref dbRS))
            {
                while (dbRS.Read())
                {
                    sCycle_Type = dbRS["CYCLE_TYPE"].ToString();
                    sType_No = dbRS["TYPE_NO"].ToString();
                    sType_Name = dbRS["TYPE_NAME"].ToString();
                    sStatus = dbRS["STATUS"].ToString();
                }
                dbRS.Close();
            }
            else
            {
                return false;
            }

            txtCycle_TypeName.Text = FunGetCycleType(sCycle_Type);
            txtCycle_Type.Text = sCycle_Type;
            txtTypeNo.Text = sType_No;
            txtType.Text = sType_Name;

            gsStatus = sStatus; //記錄全域變數            
            switch (sStatus)
            {
                case "Y":
                    txtState.Text = "重整中..."; break;
                case "N":
                    txtState.Text = "重整結束"; break;
                case "P":
                    txtState.Text = "重整暫停"; break;
                case "Z":
                    txtState.Text = "自動暫停"; break;
                case "":
                    txtState.Text = ""; break;
                default:
                    txtState.Text = ""; break;
            }

            return true;
        }
        
        private string FunGetCycleType(string sValue)
        {
            switch (sValue)
            {
                case "1": return "IQC整併";
                case "2": return "呆滯晶片整併";
                case "3": return "盤點整併";
                default: return sValue;
            }
        }
        private void SubQuery_Data(string sCycle_Type, string sType_No)
        {
            string strSQL = ""; DbDataReader dbRS = null;

            int iQty = 0; int iQty1 = 0;

            //strSQL = "SELECT C.*, D.FOSBID,D.LOTNO,D.CUSTOMER FROM CYCLE_DATA C, LOC_DTL D WHERE C.LOC = D.LOC ";
            //strSQL = strSQL + "AND CYCLE_TYPE = '" + sCycle_Type + "' AND TYPE_NO = '" + sType_No + "' ";
            //strSQL = strSQL + "AND C.NEWLOC = '' ";

            strSQL = "SELECT C.*, D.FOSBID,D.LOTNO,D.CUSTOMER FROM CYCLE_DATA C LEFT JOIN LOC_DTL D ON C.LOC = D.LOC ";
            strSQL = strSQL + "WHERE C.CYCLE_TYPE = '" + sCycle_Type + "' AND C.TYPE_NO = '" + sType_No + "' ";
            strSQL = strSQL + "AND C.NEWLOC = '' ";
                        
            if (clsDB.FunRsSql(strSQL, ref dbRS))
            {
                while (dbRS.Read())
                {
                    Grid1.Rows.Add();
                    //Grid1[iCol_FOSB, Grid1.Rows.Count - 1].Value = dbRS["FOSBID"].ToString();
                    Grid1[iCol_LOCID, Grid1.Rows.Count - 1].Value = dbRS["LOCID"].ToString();
                    Grid1[iCol_LOC, Grid1.Rows.Count - 1].Value = dbRS["LOC"].ToString();
                    Grid1[iCol_NEWLOC, Grid1.Rows.Count - 1].Value = dbRS["NEWLOC"].ToString();
                    if ((dbRS["STATUS"].ToString() == "Y") || (dbRS["STATUS"].ToString() == "W"))
                    {
                        iQty1++;
                    }
                    Grid1[iCol_STATUS, Grid1.Rows.Count - 1].Value = FunGetStatus(dbRS["STATUS"].ToString());

                    Grid1[iCol_FOSBID, Grid1.Rows.Count - 1].Value = dbRS["FOSBID"].ToString();
                    Grid1[iCol_LOTNO, Grid1.Rows.Count - 1].Value = dbRS["LOTNO"].ToString();
                    Grid1[iCol_Customer, Grid1.Rows.Count - 1].Value = dbRS["CUSTOMER"].ToString();
                    Grid1[iCol_REMARK, Grid1.Rows.Count - 1].Value = dbRS["REMARK"].ToString();

                    iQty++;
                }
                dbRS.Close();
            }


            strSQL = "SELECT C.*, D.FOSBID,D.LOTNO,D.CUSTOMER FROM CYCLE_DATA C LEFT JOIN LOC_DTL D ON C.NEWLOC = D.LOC ";
            strSQL = strSQL + "WHERE C.CYCLE_TYPE = '" + sCycle_Type + "' AND C.TYPE_NO = '" + sType_No + "' ";
            strSQL = strSQL + "AND C.NEWLOC <> '' ";
            //strSQL = "SELECT C.*, D.FOSBID,D.LOTNO,D.CUSTOMER FROM CYCLE_DATA C, LOC_DTL D WHERE C.NEWLOC = D.LOC ";
            //strSQL = strSQL + "AND CYCLE_TYPE = '" + sCycle_Type + "' AND TYPE_NO = '" + sType_No + "' ";
            //strSQL = strSQL + "AND C.NEWLOC <> '' ";
            if (clsDB.FunRsSql(strSQL, ref dbRS))
            {
                while (dbRS.Read())
                {
                    Grid1.Rows.Add();
                    //Grid1[iCol_FOSB, Grid1.Rows.Count - 1].Value = dbRS["FOSBID"].ToString();
                    Grid1[iCol_LOCID, Grid1.Rows.Count - 1].Value = dbRS["LOCID"].ToString();
                    Grid1[iCol_LOC, Grid1.Rows.Count - 1].Value = dbRS["NEWLOC"].ToString(); //dbRS["LOC"].ToString();
                    Grid1[iCol_NEWLOC, Grid1.Rows.Count - 1].Value = dbRS["NEWLOC"].ToString();
                    if ((dbRS["STATUS"].ToString() == "Y") || (dbRS["STATUS"].ToString() == "W"))
                    {
                        iQty1++;
                    }
                    Grid1[iCol_STATUS, Grid1.Rows.Count - 1].Value = FunGetStatus(dbRS["STATUS"].ToString());

                    Grid1[iCol_FOSBID, Grid1.Rows.Count - 1].Value = dbRS["FOSBID"].ToString();
                    Grid1[iCol_LOTNO, Grid1.Rows.Count - 1].Value = dbRS["LOTNO"].ToString();
                    Grid1[iCol_Customer, Grid1.Rows.Count - 1].Value = dbRS["CUSTOMER"].ToString();
                    Grid1[iCol_REMARK, Grid1.Rows.Count - 1].Value = dbRS["REMARK"].ToString();

                    iQty++;
                }
                dbRS.Close();
            }

            txtQty.Text = iQty1.ToString() + "/" + iQty.ToString();
        }


        private string FunGetStatus(string sValue)
        {
            switch (sValue)
            {
                case "Y": return "Y:己重整";
                case "N": return "N:未處理";
                case "A": return "A:處理中";
                case "W": return "W:不可重整";
                case "Z": return "Z:手動停止";
                default: return sValue;
            }
        }
        

        private void btnMStop_Click(object sender, EventArgs e)
        {
            if ((txtCycle_Type.Text == "") || (txtTypeNo.Text == ""))
            {
                return;
            }


            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };
            SubQuery();

            if ((txtCycle_Type.Text == "") || (txtTypeNo.Text == ""))
            {
                clsDB.FunClsDB();
                return;
            }

            
            string strSQL = ""; DbDataReader dbRS = null;
            int iCnt = 0;
            strSQL = "SELECT * FROM CYCLE_DATA WHERE CYCLE_TYPE = '" + txtCycle_Type.Text + "' AND TYPE_NO = '" + txtTypeNo.Text + "' AND STATUS = 'Z' ";
            if (clsDB.FunRsSql(strSQL, ref dbRS))
            {
                while (dbRS.Read())
                {
                    iCnt = clsTool.INT(dbRS[0].ToString());
                }
                dbRS.Close();
            }

            if (iCnt >= 1) { clsDB.FunClsDB(); return; }

            if (gsStatus == "Y")
            {
                bool bFlag = true;

                clsDB.FunCommitCtrl("BEGIN");

                strSQL = "UPDATE CYCLE_STS SET STATUS = 'P' WHERE CYCLE_TYPE = '" + txtCycle_Type.Text + "' AND TYPE_NO = '" + txtTypeNo.Text + "' ";
                if (clsDB.FunExecSql(strSQL) == false) { bFlag = false; }

                if (bFlag == true)
                {
                    strSQL = "UPDATE CYCLE_SET SET RUN_STS = '" + clsASRS.RUN_STS_Hold + "' WHERE CYCLE_TYPE = '" + txtCycle_Type.Text + "' AND TYPE_NO = '" + txtTypeNo.Text + "' ";
                    if (clsDB.FunExecSql(strSQL) == false) { bFlag = false; }
                }

                if (bFlag == true)
                {
                    clsDB.FunCommitCtrl("COMMIT");
                }
                else
                {
                    clsDB.FunCommitCtrl("ROLLBACK");
                }

                string sCycle_Type = ""; string sType_No = "";
                bool bRet = SubQuery_Sts(ref sCycle_Type, ref sType_No);
            }

            clsDB.FunClsDB();
        }

        private void btnMStart_Click(object sender, EventArgs e)
        {
            if ((txtCycle_Type.Text == "") || (txtTypeNo.Text == ""))
            {
                return;
            }
            
            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };
            SubQuery();

            if ((txtCycle_Type.Text == "") || (txtTypeNo.Text == ""))
            {
                clsDB.FunClsDB();
                return;
            }

            string strSQL = ""; DbDataReader dbRS = null;
            int iCnt = 0;
            strSQL = "SELECT * FROM CYCLE_DATA WHERE CYCLE_TYPE = '" + txtCycle_Type.Text + "' AND TYPE_NO = '" + txtTypeNo.Text + "' AND STATUS = 'Z' ";
            if (clsDB.FunRsSql(strSQL, ref dbRS))
            {
                while (dbRS.Read())
                {
                    iCnt = clsTool.INT(dbRS[0].ToString());
                }
                dbRS.Close();
            }

            if (iCnt >= 1) { clsDB.FunClsDB(); return; }

            if (gsStatus == "P")
            {
                bool bFlag = true;

                clsDB.FunCommitCtrl("BEGIN");

                strSQL = "UPDATE CYCLE_STS SET STATUS = 'Y' WHERE CYCLE_TYPE = '" + txtCycle_Type.Text + "' AND TYPE_NO = '" + txtTypeNo.Text + "' ";
                if (clsDB.FunExecSql(strSQL) == false) { bFlag = false; }

                if (bFlag == true)
                {
                    strSQL = "UPDATE CYCLE_SET SET RUN_STS = '" + clsASRS.RUN_STS_Going + "' WHERE CYCLE_TYPE = '" + txtCycle_Type.Text + "' AND TYPE_NO = '" + txtTypeNo.Text + "' ";
                    if (clsDB.FunExecSql(strSQL) == false) { bFlag = false; }
                }

                if (bFlag == true)
                {
                    clsDB.FunCommitCtrl("COMMIT");
                }
                else
                {
                    clsDB.FunCommitCtrl("ROLLBACK");
                }

                string sCycle_Type = ""; string sType_No = "";
                bool bRet = SubQuery_Sts(ref sCycle_Type, ref sType_No);
            }

            clsDB.FunClsDB();
        }

        private void btnMClose_Click(object sender, EventArgs e)
        {
            if ((txtCycle_Type.Text == "") || (txtTypeNo.Text == ""))
            {
                return;
            }
            
            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };
            SubQuery();

            if ((txtCycle_Type.Text == "") || (txtTypeNo.Text == ""))
            {
                clsDB.FunClsDB();
                return;
            }

            string strSQL = "";

            if ((gsStatus == "P") || (gsStatus == "Y"))
            {
                bool bFlag = true;

                clsDB.FunCommitCtrl("BEGIN");
                strSQL = "UPDATE CYCLE_DATA SET STATUS = 'Z',REMARK = '手動停止' ";
                strSQL = strSQL + "WHERE CYCLE_TYPE = '" + txtCycle_Type.Text + "' AND TYPE_NO = '" + txtTypeNo.Text + "' ";
                //strSQL = strSQL + "AND STATUS = 'N' ";
                if (clsDB.FunExecSql(strSQL) == false) { bFlag = false; }       

                if (bFlag == true)
                {
                    clsDB.FunCommitCtrl("COMMIT");
                }
                else
                {
                    clsDB.FunCommitCtrl("ROLLBACK");
                }

                string sCycle_Type = ""; string sType_No = "";
                bool bRet = SubQuery_Sts(ref sCycle_Type, ref sType_No);
            }

            SubQuery();

            clsDB.FunClsDB();
        }





    }
}
