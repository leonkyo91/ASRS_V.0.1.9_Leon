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
    public partial class frm_CYCLE_ADJUST_SCHE : Form
    {
        #region Grid1 Parameter        
        int iCol_CYCLE_TYPE = 0;
        int iCol_CYCLE_TYPE_NO = 1;
        int iCol_TYPE_NO = 2;
        int iCol_TYPE_NAME = 3;
        int iCol_CRT_TIME = 4;

        int iCol_CUST = 5;
        int iCol_CUST_GROUP = 6;
        int iCol_FAB_IN_TIME = 7;
        int iCol_CIRCULATE = 8;
        int iCol_CIR_CNT = 9;
        int iCol_CIR_TIME = 10;

        int iCol_START_TIME = 11;
        int iCol_NEXT_TIME = 12;
        int iCol_RUN_STS = 13;
        int iCol_RUN_TIME_S = 14;
        int iCol_RUN_TIME_E = 15;
        int iCol_USED = 16;
        int iCol_USED_Before = 17;
        int iCol_CRT_USER = 18;
        int iCol_MODIFY_USER = 19;
        int iCol_Counts = 20;
        #endregion


        public frm_CYCLE_ADJUST_SCHE()
        {
            InitializeComponent();
        }

        private void frm_CYCLE_ADJUST_SCHE_Load(object sender, EventArgs e)
        {
            GridInit();
            FormInit();
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

            oGrid.Columns[iCol_CYCLE_TYPE].Width = 80; oGrid.Columns[iCol_CYCLE_TYPE].Name = "重整類型";
            oGrid.Columns[iCol_CYCLE_TYPE_NO].Width = 0; oGrid.Columns[iCol_CYCLE_TYPE_NO].Name = ""; oGrid.Columns[iCol_CYCLE_TYPE_NO].Visible = false;
            oGrid.Columns[iCol_TYPE_NO].Width = 0; oGrid.Columns[iCol_TYPE_NO].Name = ""; oGrid.Columns[iCol_TYPE_NO].Visible = false;
            oGrid.Columns[iCol_TYPE_NAME].Width = 120; oGrid.Columns[iCol_TYPE_NAME].Name = "Type";
            oGrid.Columns[iCol_CRT_TIME].Width = 110; oGrid.Columns[iCol_CRT_TIME].Name = "建立時間";

            oGrid.Columns[iCol_CUST].Width = 280; oGrid.Columns[iCol_CUST].Name = "Customer";
            oGrid.Columns[iCol_CUST_GROUP].Width = 120; oGrid.Columns[iCol_CUST_GROUP].Name = "Customer Group"; oGrid.Columns[iCol_CUST_GROUP].Visible = false;
            oGrid.Columns[iCol_FAB_IN_TIME].Width = 120; oGrid.Columns[iCol_FAB_IN_TIME].Name = "晶圓入廠日期"; oGrid.Columns[iCol_FAB_IN_TIME].Visible = false;
            oGrid.Columns[iCol_CIRCULATE].Width = 90; oGrid.Columns[iCol_CIRCULATE].Name = ""; //循環/單次
            oGrid.Columns[iCol_CIR_CNT].Width = 0; oGrid.Columns[iCol_CIR_CNT].Name = ""; oGrid.Columns[iCol_CIR_CNT].Visible = false;
            oGrid.Columns[iCol_CIR_TIME].Width = 0; oGrid.Columns[iCol_CIR_TIME].Name = ""; oGrid.Columns[iCol_CIR_TIME].Visible = false;

            oGrid.Columns[iCol_START_TIME].Width = 100; oGrid.Columns[iCol_START_TIME].Name = "啓動時間";
            oGrid.Columns[iCol_NEXT_TIME].Width = 120; oGrid.Columns[iCol_NEXT_TIME].Name = "下次執行時間";
            oGrid.Columns[iCol_RUN_STS].Width = 80; oGrid.Columns[iCol_RUN_STS].Name = "狀態";
            oGrid.Columns[iCol_RUN_TIME_S].Width = 110; oGrid.Columns[iCol_RUN_TIME_S].Name = "起始時間";
            oGrid.Columns[iCol_RUN_TIME_E].Width = 110; oGrid.Columns[iCol_RUN_TIME_E].Name = "結束時間";
            oGrid.Columns[iCol_USED].Width = 60; oGrid.Columns[iCol_USED].Name = "使用";
            oGrid.Columns[iCol_USED_Before].Width = 60; oGrid.Columns[iCol_USED_Before].Name = "使用"; oGrid.Columns[iCol_USED_Before].Visible = false;

            oGrid.Columns[iCol_CRT_USER].Width = 100; oGrid.Columns[iCol_CRT_USER].Name = "建立者";
            oGrid.Columns[iCol_MODIFY_USER].Width = 100; oGrid.Columns[iCol_MODIFY_USER].Name = "修改者";
            
            oGrid.ReadOnly = false;     //Grid可修改
            oGrid.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            oGrid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft; 
            
            int i = 0;
            oGrid.Columns[iCol_CYCLE_TYPE].ReadOnly = true;

            for (i = 0; i <= oGrid.ColumnCount - 1; i++)
            {
                oGrid.Columns[i].ReadOnly = true;     //Grid裡資料不可修改

                if (i == iCol_NEXT_TIME)
                {
                    //可排序
                }
                else
                {
                    oGrid.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }


            oGrid.RowCount = 0;
        }


        private void FormInit()
        {
            SubSetCboCycType();
            SubSetCboStatus();
        }

        private void SubSetCboCycType()
        {
            cboCycType.Items.Clear();
            cboCycType.Items.Add("");
            cboCycType.Items.Add("1:IQC整併");
            cboCycType.Items.Add("2:呆滯晶片整併");
            cboCycType.Items.Add("3:盤點整併");
        }

        private void SubSetCboStatus()
        {
            cboStatus.Items.Clear();
            cboStatus.Items.Add("");
            cboStatus.Items.Add("Standby");
            cboStatus.Items.Add("Going");
            cboStatus.Items.Add("Completed");
            cboStatus.Items.Add("Hold");
            cboStatus.Items.Add("Wait");
        }


        private void SetSelColor_Complete(ref DataGridView objGrid, int iRow)
        {
            for (int k = 0; k <= objGrid.ColumnCount - 1; k++)
            {
                objGrid.Rows[iRow].Cells[k].Style.BackColor = Color.LightGray;
            }
        }

        private void SetSelColor_Going(ref DataGridView objGrid, int iRow)
        {
            objGrid.Rows[iRow].Cells[iCol_RUN_STS].Style.BackColor = Color.LightGreen;            
        }




        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };
            SubQuery();
            clsDB.FunClsDB();
        }

        private void SubQuery()
        {
            string strSQL = ""; DbDataReader dbRS = null;

            Grid1.RowCount = 0;

            strSQL = "SELECT * FROM CYCLE_SET ";
            strSQL = strSQL + "WHERE CYCLE_TYPE <> '' ";

            if (cboCycType.Text != "")
            {
                strSQL = strSQL + "AND CYCLE_TYPE = '" + clsTool.FunGetComineData(cboCycType.Text) + "' ";
            }
            if (cboStatus.Text != "")
            {
                strSQL = strSQL + "AND RUN_STS = '" + cboStatus.Text + "' ";
            }

            strSQL = strSQL + "ORDER BY NEXT_TIME "; //CYCLE_TYPE,CRT_TIME ";
            if (clsDB.FunRsSql(strSQL, ref dbRS))
            {
                while (dbRS.Read())
                {
                    Grid1.Rows.Add();
                    Grid1[iCol_CYCLE_TYPE, Grid1.RowCount - 1].Value = FunGetCycleType(dbRS["CYCLE_TYPE"].ToString());
                    Grid1[iCol_CYCLE_TYPE_NO, Grid1.RowCount - 1].Value = dbRS["CYCLE_TYPE"].ToString();
                    Grid1[iCol_TYPE_NO, Grid1.RowCount - 1].Value = dbRS["TYPE_NO"].ToString();
                    Grid1[iCol_TYPE_NAME, Grid1.RowCount - 1].Value = dbRS["TYPE_NAME"].ToString();
                    Grid1[iCol_CRT_TIME, Grid1.RowCount - 1].Value = dbRS["CRT_TIME"].ToString();

                    Grid1[iCol_CUST, Grid1.RowCount - 1].Value = dbRS["CUST"].ToString();
                    Grid1[iCol_CUST_GROUP, Grid1.RowCount - 1].Value = dbRS["CUST_GROUP"].ToString();
                    Grid1[iCol_FAB_IN_TIME, Grid1.RowCount - 1].Value = FunGetFabInTime(dbRS["FAB_IN_TIME"].ToString());

                    Grid1[iCol_CUST, Grid1.RowCount - 1].Value = Grid1[iCol_CUST, Grid1.RowCount - 1].Value + ","
                                                               + Grid1[iCol_CUST_GROUP, Grid1.RowCount - 1].Value + ","
                                                               + Grid1[iCol_FAB_IN_TIME, Grid1.RowCount - 1].Value;

                    Grid1[iCol_CIRCULATE, Grid1.RowCount - 1].Value = FunGetCirculate(dbRS["CIRCULATE"].ToString());
                    Grid1[iCol_CIR_CNT, Grid1.RowCount - 1].Value = dbRS["CIR_CNT"].ToString();
                    Grid1[iCol_CIR_TIME, Grid1.RowCount - 1].Value = dbRS["CIR_TIME"].ToString();

                    Grid1[iCol_CIRCULATE, Grid1.RowCount - 1].Value = Grid1[iCol_CIRCULATE, Grid1.RowCount - 1].Value + ","
                                                                    + Grid1[iCol_CIR_CNT, Grid1.RowCount - 1].Value + ","
                                                                    + Grid1[iCol_CIR_TIME, Grid1.RowCount - 1].Value;

                    Grid1[iCol_START_TIME, Grid1.RowCount - 1].Value = dbRS["START_TIME"].ToString();
                    Grid1[iCol_NEXT_TIME, Grid1.RowCount - 1].Value = dbRS["NEXT_TIME"].ToString();
                    Grid1[iCol_RUN_STS, Grid1.RowCount - 1].Value = dbRS["RUN_STS"].ToString();
                    Grid1[iCol_RUN_TIME_S, Grid1.RowCount - 1].Value = dbRS["RUN_TIME_S"].ToString();
                    Grid1[iCol_RUN_TIME_E, Grid1.RowCount - 1].Value = dbRS["RUN_TIME_E"].ToString();
                    if (dbRS["USED"].ToString() == "1")
                    {
                        Grid1[iCol_USED, Grid1.RowCount - 1].Value = true;
                        Grid1[iCol_USED_Before, Grid1.RowCount - 1].Value = "1";

                        if (dbRS["RUN_STS"].ToString().ToUpper() == "COMPLETED")
                        {
                            SetSelColor_Complete(ref Grid1, Grid1.RowCount - 1);
                        }
                        else if (dbRS["RUN_STS"].ToString().ToUpper() == "GOING")
                        {
                            SetSelColor_Going(ref Grid1, Grid1.RowCount - 1);
                        }
                    }
                    else
                    {
                        Grid1[iCol_USED, Grid1.RowCount - 1].Value = false;
                        Grid1[iCol_USED_Before, Grid1.RowCount - 1].Value = "0";

                        Grid1[iCol_RUN_STS, Grid1.RowCount - 1].Value = "Hold Schedule";
                    }



                    Grid1[iCol_CRT_USER, Grid1.RowCount - 1].Value = dbRS["REMARK1"].ToString();
                    Grid1[iCol_MODIFY_USER, Grid1.RowCount - 1].Value = dbRS["REMARK2"].ToString();

                }
                dbRS.Close();
            }


        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            string sCycle_Type = ""; string sType_No = "";
            sCycle_Type = Grid1[iCol_CYCLE_TYPE_NO, Grid1.CurrentRow.Index].Value.ToString();
            sType_No = Grid1[iCol_TYPE_NO, Grid1.CurrentRow.Index].Value.ToString();

            if ((sCycle_Type == "") || (sType_No == "")) { return; }

            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };
            
            string strSQL = ""; DbDataReader dbRS = null;
            string sStatus = "";
            bool bFlag = true;

            strSQL = "SELECT * FROM CYCLE_STS WHERE CYCLE_TYPE  '" + sCycle_Type + "' AND TYPE_NO = '" + sType_No + "' ";
            if (clsDB.FunRsSql(strSQL, ref dbRS))
            {
                while (dbRS.Read())
                {
                    sStatus = dbRS["STATUS"].ToString();
                }
                dbRS.Close();
            }


            bool bCycleSts = false;
            if (sStatus == "") 
            {
                bCycleSts = false;
            }
            else if  (sStatus == "N")
            {
                bCycleSts = true;
            }
            else
            {
                bCycleSts = false;
                clsMSG.ShowInformationMsg("請將排程先做停止,才能做刪除功能!! ");
                return;
            }


            clsDB.FunCommitCtrl("BEGIN");

            if (bCycleSts == true)
            {
                strSQL = "DELETE FROM CYCLE_STS WHERE CYCLE_TYPE = '" + sCycle_Type + "' AND TYPE_NO = '" + sType_No + "' ";
                if (clsDB.FunExecSql(strSQL) == false) { bFlag = false; }
            }

            strSQL = "DELETE FROM CYCLE_SET WHERE CYCLE_TYPE = '" + sCycle_Type + "' AND TYPE_NO = '" + sType_No + "' ";
            if (clsDB.FunExecSql(strSQL) == false) { bFlag = false; }

            if (bFlag == true)
            {
                clsDB.FunCommitCtrl("COMMIT");
                clsMSG.ShowInformationMsg(clsMSG.MSG.Msg_Run_Finish);
                SubQuery();
            }
            else
            {
                clsDB.FunCommitCtrl("ROLLBACK");
                clsMSG.ShowErrMsg(clsMSG.MSG.Msg_Run_Error);
            }
            clsDB.FunClsDB();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void Grid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Grid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }
            if (Grid1[iCol_CYCLE_TYPE, e.RowIndex].Value.ToString() == "") { return; }
            if (Grid1[iCol_TYPE_NO, e.RowIndex].Value.ToString() == "") { return; }

            string sCycleType = Grid1[iCol_CYCLE_TYPE, e.RowIndex].Value.ToString();
            string sTypeNo = Grid1[iCol_TYPE_NO, e.RowIndex].Value.ToString();

            if (e.ColumnIndex == iCol_USED)
            {
                string sValue = Grid1[iCol_USED, e.RowIndex].Value.ToString();

                //string strSQL = ""; DbDataReader dbRS = null;

                //if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };

                //strSQL = "UPDATE CYCLE_SET SET USED = '" + sValue + "' ";
                //strSQL = strSQL + "WHERE CYCLE_TYPE = '" + sCycleType + "' AND TYPE_NO = '" + sTypeNo + "' ";
                //bool bret = clsDB.FunExecSql(strSQL);
                
                //clsDB.FunClsDB();                
            }

        }

        private string FunGetFabInTime(string sValue)
        {            
            switch (sValue)
            {
                case "1": return "大於6個月~1年";
                case "2": return "大於6個月";
                case "3": return "大於1年";
                default: return sValue;
            }
        }

        private string FunGetCirculate(string sValue)
        {
            switch (sValue)
            {
                case "Y": return "循環";
                case "N": return "單次";
                default: return sValue;
            }
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

        private void cmdExport_Click(object sender, EventArgs e)
        {
            funGridToCsv(Grid1);
        }

        private void funGridToCsv(DataGridView Grd, String strErrMsg = "")
        {
            try
            {
                string sLine = "";
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "csv files (*.csv)|*.csv|txt files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.RestoreDirectory = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    
                    System.IO.StreamWriter straWrite = new System.IO.StreamWriter(saveFileDialog1.OpenFile(), System.Text.Encoding.GetEncoding("Big5"));

                    //Header資料
                    for (int iCol = 0; iCol != Grd.ColumnCount; iCol++)
                    {                        
                        //if (iCol != 0) sLine = sLine + ",";


                        if ((iCol == iCol_CYCLE_TYPE_NO) || (iCol == iCol_TYPE_NO) || (iCol == iCol_CUST_GROUP) || (iCol == iCol_FAB_IN_TIME) || 
                            (iCol == iCol_CIR_CNT) || (iCol == iCol_CIR_TIME) || (iCol == iCol_USED_Before) )
                        {
                            //不做記錄
                        }
                        else
                        {
                            sLine = sLine + Grd.Columns[iCol].HeaderText + ",";
                        }
                    }
                    straWrite.WriteLine(sLine);

                    //匯出資料

                    for (int iRow = 0; iRow != Grd.RowCount; iRow++)
                    {
                        sLine = "";
                        for (int iCol = 0; iCol != Grd.ColumnCount; iCol++)
                        {
                            if ((iCol == iCol_CYCLE_TYPE_NO) || (iCol == iCol_TYPE_NO) || (iCol == iCol_CUST_GROUP) || (iCol == iCol_FAB_IN_TIME) ||
                                (iCol == iCol_CIR_CNT) || (iCol == iCol_CIR_TIME) || (iCol == iCol_USED_Before))
                            {
                                //不做記錄
                            }
                            else
                            {
                                sLine = sLine + (Grd[iCol, iRow].Value == null ? "" : Grd[iCol, iRow].Value.ToString()) + ",";
                            }                            
                        }
                        straWrite.WriteLine(sLine);
                    }

                    straWrite.Close();
                    straWrite.Dispose();
                    
                }
                else
                {
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                strErrMsg = ex.Message;                
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;

            btnQuery.Enabled = false;
            btnDel.Enabled = false;
            cmdExport.Enabled = false;

            Grid1.Columns[iCol_USED].ReadOnly = false;     
            

        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            btnUpdate.Enabled = true;

            btnQuery.Enabled = true;
            btnDel.Enabled = true;
            cmdExport.Enabled = true;

            SubModifyFunction();

            Grid1.Columns[iCol_USED].ReadOnly = true;

        }

        private void SubModifyFunction()
        {
            if (Grid1.RowCount <= 0) { return; }
            string strSQL = "";

            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };

            clsDB.FunCommitCtrl("BEGIN");

            int i = 0; string sUsed = ""; string sUsed_Before = ""; bool bFlag = true;
            for (i = 0; i <= Grid1.RowCount - 1; i++)
            {
                string sValue = Grid1[iCol_USED, i].Value.ToString();
                sUsed_Before = Grid1[iCol_USED_Before, i].Value.ToString();
                if (sValue.ToUpper() == "TRUE")
                {
                    sUsed = "1";
                }
                else
                {
                    sUsed = "0";
                }

                if (sUsed_Before != sUsed)
                {
                    strSQL = "UPDATE CYCLE_SET SET USED = '" + sUsed + "',REMARK2 = '" + clsASRS.gstrLoginUser + "' ";
                    strSQL = strSQL + "WHERE CYCLE_TYPE = '" + Grid1[iCol_CYCLE_TYPE_NO, i].Value.ToString() + "' ";
                    strSQL = strSQL + "AND TYPE_NO = '" + Grid1[iCol_TYPE_NO, i].Value.ToString() + "' ";
                    if (clsDB.FunExecSql(strSQL) == false)
                    {
                        bFlag = false;
                        break;
                    }
                }
            }

            if (bFlag == true)
            {
                clsDB.FunCommitCtrl("COMMIT");
            }
            else
            {
                clsDB.FunCommitCtrl("ROLLBACK");
            }
            clsDB.FunClsDB();

        }

        private void Grid1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

    }
}
