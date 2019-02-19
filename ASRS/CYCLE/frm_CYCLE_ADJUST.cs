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
    public partial class frm_CYCLE_ADJUST : Form
    {
        public frm_CYCLE_ADJUST()
        {
            InitializeComponent();
        }

        private void frm_CYCLE_ADJUST_Load(object sender, EventArgs e)
        {
            FormInit();
        }

        private void FormInit()
        {
            SubSetCboAction();
            SubSetCboCycType();
            SubSetScheduleTime();
            SubSetCboFabIn();

            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };
            SubSetCboCust();
            SubSetCboCustGrp();
            clsDB.FunClsDB();

            FormCls();
            
        }

        private void FormCls()
        {
            FormCls1();
            FormCls2();
        }

        private void FormCls1()
        {
            cboAction.Text = "";
            cboCycType.Text = "";
            txtType.Text = ""; 
            txtTypeNo.Text = "";
        }

        private void FormCls2()
        {            
            cboCust.Text = "";
            cboCustGrp.Text = "";
            cboFabIn.Text = "";
            rdbCir.Checked = true;
            rdbSingle.Checked = false;
            txtTime.Text = "1";
            cboTime.Text = "";
            txtTransDate1.Text = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm");
        }

        private void FormDisable(bool bFlag)
        {
            cboCust.Enabled = bFlag;
            cboCustGrp.Enabled = bFlag;
            cboFabIn.Enabled = bFlag;

            rdbSingle.Enabled = bFlag;
            rdbCir.Enabled = bFlag;
            txtTime.Enabled = bFlag;
            cboTime.Enabled = bFlag;
            txtTransDate1.Enabled = bFlag;
        }

        private void SubSetCboAction()
        {
            cboAction.Items.Clear();
            cboAction.Items.Add("1:新增");
            cboAction.Items.Add("2:修改");
            cboAction.Items.Add("3:刪除");
        }

        private void SubSetCboCycType()
        {
            cboCycType.Items.Clear();
            cboCycType.Items.Add("");
            cboCycType.Items.Add("1:IQC整併");
            cboCycType.Items.Add("2:呆滯晶片整併");
            cboCycType.Items.Add("3:盤點整併");
        }

        private void SubSetCboCust()
        {
            string strSQL = ""; DbDataReader dbRS = null;

            cboCust.Items.Clear();
            cboCust.Items.Add("");

            strSQL = "SELECT DISTINCT CUSTOMER FROM LOC_DTL GROUP BY CUSTOMER ";            
            if (clsDB.FunRsSql(strSQL, ref dbRS))
            {
                while (dbRS.Read())
                {
                    cboCust.Items.Add(dbRS["CUSTOMER"].ToString());
                }
                dbRS.Close();
            }
        }

        private void SubSetCboCustGrp()
        {
            string strSQL = ""; DbDataReader dbRS = null;

            cboCustGrp.Items.Clear();
            cboCustGrp.Items.Add("");

            strSQL = "SELECT DISTINCT GIB_CUSTOMER FROM LOC_DTL GROUP BY GIB_CUSTOMER ";
            if (clsDB.FunRsSql(strSQL, ref dbRS))
            {
                while (dbRS.Read())
                {
                    cboCustGrp.Items.Add(dbRS["GIB_CUSTOMER"].ToString());
                }
                dbRS.Close();
            }
        }

        private void SubSetCboFabIn()
        {
            cboFabIn.Items.Clear();
            cboFabIn.Items.Add("");
            cboFabIn.Items.Add("1:6個月~1年");
            cboFabIn.Items.Add("2:6個月以上");
            cboFabIn.Items.Add("3:1年以上");  
        }

        private void SubSetScheduleTime()
        {
            cboTime.Items.Clear();
            cboTime.Items.Add("");
            cboTime.Items.Add("MONTH");
            cboTime.Items.Add("WEEK");
            cboTime.Items.Add("DAY");
            cboTime.Items.Add("HOUR");
        }

        private void cboTime_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (char)27; //ESC
        }

        private void cboAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (clsTool.FunGetComineData(cboAction.Text))
            {
                case "1":   //新增
                    FormCls2();
                    cboCycType.Text = ""; txtType.Text = ""; txtTypeNo.Text = "";
                    //FormDisable(true);
                    break;
                case "2":   //修改
                    FormCls2();
                    cboCycType.Text = ""; txtType.Text = ""; txtTypeNo.Text = "";
                    //FormDisable(true);
                    break;
                case "3":   //刪除
                    FormCls2();
                    cboCycType.Text = ""; txtType.Text = ""; txtTypeNo.Text = "";
                    //FormDisable(true);
                    break;
                default:
                    FormCls();
                    //FormDisable(false);
                    break;
            }
        }

        private void cboAction_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (char)27; //ESC
        }

        private void cboCycType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if ((clsTool.FunGetComineData(cboAction.Text) == "2") || (clsTool.FunGetComineData(cboAction.Text) == "3"))
            //{
                
            //}
        }

        private void cboCycType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (char)27; //ESC
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboType_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.KeyChar = (char)27; //ESC
        }

        private void cboFabIn_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboFabIn_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (char)27; //ESC
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SubSave();
        }

        private void SubSave()
        {
            string strSQL = ""; DbDataReader dbRS = null;
            
            //防呆
            string sCycle_Type = ""; string sType_No = ""; string sType_Name = "";
            string sCustomer = ""; string sCust_Grp = ""; string sFabInTime = "";
            string sCir = ""; int iCir = 0; string sCir_Time = ""; string sCir_StartTime = "";

            sCycle_Type = clsTool.FunGetComineData(cboCycType.Text);
            string sTmp = clsTool.FunGetComineData(cboAction.Text);

            int iTimeCnt = clsTool.INT(txtTime.Text);
            txtTime.Text = iTimeCnt.ToString();

            txtType.Text = txtType.Text.Trim();

            if (sTmp == "")
            {
                clsMSG.ShowWarningMsg("請輸入執行項目!!");
                return;
            }
            if (sCycle_Type == "")
            {
                clsMSG.ShowWarningMsg("請輸入整併項目!!");
                return;
            }

            

            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };
            if (sTmp == "1")        //1:新增
            {
                #region 防呆
                if (cboTime.Text == "")
                {
                    clsMSG.ShowWarningMsg("請輸入執行時間週期!!");
                    clsDB.FunClsDB();
                    return;
                }
                if (iTimeCnt <= 0)
                {
                    clsMSG.ShowWarningMsg("執行時間週期時間不可以<= 0 !!");
                    clsDB.FunClsDB();
                    return;
                }
                if (txtType.Text == "")
                {
                    clsMSG.ShowWarningMsg("請輸入 Type 名稱!!");
                    clsDB.FunClsDB();
                    return;
                }

                TimeSpan ts1 = new TimeSpan(txtTransDate1.Value.Ticks);
                TimeSpan ts2 = new TimeSpan(System.DateTime.Now.Ticks);
                TimeSpan ts = ts1.Subtract(ts2).Duration();
                if (ts1.TotalSeconds <= ts2.TotalSeconds)
                {
                    clsMSG.ShowWarningMsg("啓動時間不可小於現在時間!!");
                    clsDB.FunClsDB();
                    return;
                }
                #endregion

                sType_No = clsASRS.FunGetAdjCycNo();
            }
            else if (sTmp == "2")   //2:修改
            {
                #region 防呆
                if (cboTime.Text == "")
                {
                    clsMSG.ShowWarningMsg("請輸入執行時間週期!!");
                    clsDB.FunClsDB();
                    return;
                }
                if (iTimeCnt <= 0)
                {
                    clsMSG.ShowWarningMsg("執行時間週期時間不可以<= 0 !!");
                    clsDB.FunClsDB();
                    return;
                }
                if (txtType.Text == "")
                {
                    clsMSG.ShowWarningMsg("請輸入 Type 名稱!!");
                    clsDB.FunClsDB();
                    return;
                }

                TimeSpan ts1 = new TimeSpan(txtTransDate1.Value.Ticks);
                TimeSpan ts2 = new TimeSpan(System.DateTime.Now.Ticks);
                TimeSpan ts = ts1.Subtract(ts2).Duration();
                if (ts1.TotalSeconds <= ts2.TotalSeconds)
                {
                    clsMSG.ShowWarningMsg("啓動時間不可小於現在時間!!");
                    clsDB.FunClsDB();
                    return;
                }
                #endregion

                sType_No = txtTypeNo.Text;
            }
            else if (sTmp == "3")   //3:刪除
            {
                sType_No = txtTypeNo.Text;
            }
            if (sType_No == "")
            {
                return;
            }
            sType_Name = txtType.Text.Trim();
            

            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };
            bool bOver = false;
            int iCnt = 0;
            strSQL = "SELECT COUNT(*) as CNT FROM CYCLE_SET WHERE TYPE_NAME = '" + sType_Name + "' AND CYCLE_TYPE = '" + sCycle_Type + "' ";
            if (clsDB.FunRsSql(strSQL, ref dbRS))
            {
                while (dbRS.Read())
                {
                    iCnt = clsTool.INT(dbRS[0].ToString());
                }
                dbRS.Close();

                if (iCnt > 0)
                {
                    bOver = true;
                }
            }


            if (sTmp == "1") 
            {
                if (bOver == true)
                {
                    clsMSG.ShowErrMsg("Type名稱重覆!!");
                    clsDB.FunClsDB();
                    return;
                }
            }
            else if ((sTmp == "3") || (sTmp == "2"))
            {
                if (bOver == false)
                {
                    clsMSG.ShowErrMsg("Type資料不存在!!");
                    clsDB.FunClsDB();
                    return;
                }
            }

            sCustomer = cboCust.Text;
            sCust_Grp = cboCustGrp.Text;
            sFabInTime = clsTool.FunGetComineData(cboFabIn.Text);            
            if (rdbCir.Checked == true)
            {
                sCir = "Y";
            }
            else
            {
                sCir = "N";
            }
            iCir = clsTool.INT(txtTime.Text);
            sCir_Time = cboTime.Text;
            sCir_StartTime = txtTransDate1.Text ;

            //新增           
            if (sTmp == "1")
            {
                strSQL = "INSERT INTO CYCLE_SET (CYCLE_TYPE,TYPE_NO,TYPE_NAME,CRT_TIME,PRIORITY,USED,";
                strSQL = strSQL + "CUST,CUST_GROUP,FAB_IN_TIME,CIRCULATE,CIR_CNT,CIR_TIME,START_TIME,";
                strSQL = strSQL + "NEXT_TIME,RUN_STS,RUN_TIME_S,RUN_TIME_E,REMARK1,REMARK2,REMARK3) VALUES (";
                strSQL = strSQL + "'" + sCycle_Type + "',";
                strSQL = strSQL + "'" + sType_No + "',";
                strSQL = strSQL + "'" + sType_Name + "',";
                strSQL = strSQL + "'" + System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "',";
                strSQL = strSQL + "0,";
                strSQL = strSQL + "'1',";
                strSQL = strSQL + "'" + sCustomer + "',";
                strSQL = strSQL + "'" + sCust_Grp + "',";
                strSQL = strSQL + "'" + sFabInTime + "',";
                strSQL = strSQL + "'" + sCir + "',";
                strSQL = strSQL + iCir + ",";
                strSQL = strSQL + "'" + sCir_Time + "',";
                strSQL = strSQL + "'" + sCir_StartTime + "',";
                strSQL = strSQL + "'','','','',";
                strSQL = strSQL + "'" + clsASRS.gstrLoginUser + "','','') ";
                if (clsDB.FunExecSql(strSQL))
                {
                    clsMSG.ShowInformationMsg(clsMSG.MSG.Msg_Run_Finish);
                    FormCls();
                }
                else
                {
                    clsMSG.ShowErrMsg(clsMSG.MSG.Msg_Run_Error);
                }
            }
            else if (sTmp == "2")
            {
                strSQL = "UPDATE CYCLE_SET SET CUST = '" + sCustomer + "', ";
                strSQL = strSQL + "CUST_GROUP = '" + sCust_Grp + "', ";
                strSQL = strSQL + "FAB_IN_TIME = '" + sFabInTime + "', ";
                strSQL = strSQL + "CIRCULATE = '" + sCir + "',";
                strSQL = strSQL + "CIR_CNT = " + iCir + ",";
                strSQL = strSQL + "CIR_TIME = '" + sCir_Time + "' ";
                strSQL = strSQL + "WHERE CYCLE_TYPE = '" + sCycle_Type + "' AND TYPE_NO = '" + sType_No + "' ";
                if (clsDB.FunExecSql(strSQL))
                {
                    clsMSG.ShowInformationMsg(clsMSG.MSG.Msg_Run_Finish);
                    FormCls();
                }
                else
                {
                    clsMSG.ShowErrMsg(clsMSG.MSG.Msg_Run_Error);
                }
            }
            else if (sTmp == "3")
            {
                bool bFlag = true;
                int iCycleSts_Cnt = 0;
                strSQL = "SELECT COUNT(*) FROM CYCLE_STS WHERE CYCLE_TYPE = '" + sCycle_Type + "' AND TYPE_NO = '" + sType_No + "' ";
                if (clsDB.FunRsSql(strSQL, ref dbRS))
                {
                    while (dbRS.Read())
                    {
                        iCycleSts_Cnt = clsTool.INT(dbRS[0].ToString());
                    }
                    dbRS.Close();
                }

                int iCycleData_Cnt = 0;
                strSQL = "SELECT COUNT(*) FROM CYCLE_DATA WHERE CYCLE_TYPE = '" + sCycle_Type + "' AND TYPE_NO = '" + sType_No + "' ";
                if (clsDB.FunRsSql(strSQL, ref dbRS))
                {
                    while (dbRS.Read())
                    {
                        iCycleData_Cnt = clsTool.INT(dbRS[0].ToString());
                    }
                    dbRS.Close();
                }

                clsDB.FunCommitCtrl("BEGIN");

                strSQL = "DELETE FROM CYCLE_SET WHERE CYCLE_TYPE = '" + sCycle_Type + "' AND TYPE_NO = '" + sType_No + "' ";
                if (clsDB.FunExecSql(strSQL) == false) { bFlag = false; }

                if (iCycleSts_Cnt >= 1)
                {
                    if (bFlag == true)
                    {
                        strSQL = "DELETE FROM CYCLE_STS WHERE CYCLE_TYPE = '" + sCycle_Type + "' AND TYPE_NO = '" + sType_No + "' ";
                        if (clsDB.FunExecSql(strSQL) == false) { bFlag = false; }
                    }
                }

                if (iCycleData_Cnt >= 1)
                {
                    if (bFlag == true)
                    {
                        strSQL = "UPDATE CYCLE_DATA SET STATUS = 'Z',REMARK = '手動停止' ";
                        strSQL = strSQL + "WHERE CYCLE_TYPE = '" + sCycle_Type + "' AND TYPE_NO = '" + sType_No + "' ";
                        if (clsDB.FunExecSql(strSQL) == false) { bFlag = false; }
                    }
                }

                if (bFlag == true)
                {
                    clsDB.FunCommitCtrl("COMMIT");
                    clsMSG.ShowInformationMsg(clsMSG.MSG.Msg_Run_Finish);
                    FormCls();
                }
                else
                {
                    clsDB.FunCommitCtrl("ROLLBACK");
                    clsMSG.ShowErrMsg(clsMSG.MSG.Msg_Run_Error);
                }

                //if (clsDB.FunExecSql(strSQL))
                //{
                //    clsMSG.ShowInformationMsg(clsMSG.MSG.Msg_Run_Finish);
                //    FormCls();
                //}
                //else
                //{
                //    clsMSG.ShowErrMsg(clsMSG.MSG.Msg_Run_Error);
                //}
            }


            clsDB.FunClsDB();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtTime_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 48) && (e.KeyChar <= 57))
            {

            }
            else
            {
                e.KeyChar = (char)27; //ESC
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            clsASRS.gsHelpStyle = "CYCLE_SET_TYPE";
            clsASRS.gsHelpStyle_Data = clsTool.FunGetComineData(cboCycType.Text);
            Array.Resize<string>(ref clsASRS.gsHelpRtnData, 2);

            frmHelp frmHelp = new frmHelp();
            frmHelp.ShowDialog();

            txtTypeNo.Text = clsASRS.gsHelpRtnData[0];
            txtType.Text = clsASRS.gsHelpRtnData[1];

            if (clsASRS.gsHelpRtnData[0] != "")
            {
                if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };

                string strSQL = ""; DbDataReader dbRS = null;
                strSQL = "SELECT * FROM CYCLE_SET ";
                strSQL = strSQL + "WHERE CYCLE_TYPE = '" + clsTool.FunGetComineData(cboCycType.Text) + "' ";
                strSQL = strSQL + "AND TYPE_NO = '" + clsASRS.gsHelpRtnData[0] + "' ";
                if (clsDB.FunRsSql(strSQL, ref dbRS))
                {
                    while (dbRS.Read())
                    {

                        cboCust.Text = dbRS["CUST"].ToString();
                        cboCustGrp.Text = dbRS["CUST_GROUP"].ToString();
                        cboFabIn.Text = FunGetFabInTime(dbRS["FAB_IN_TIME"].ToString());
                        if (dbRS["CIRCULATE"].ToString() == "Y")
                        {
                            rdbCir.Checked = true;
                            rdbSingle.Checked = false;
                        }
                        else
                        {
                            rdbCir.Checked = false;
                            rdbSingle.Checked = true;
                        }

                        txtTime.Text = dbRS["CIR_CNT"].ToString();
                        cboTime.Text = dbRS["CIR_TIME"].ToString();
                        txtTransDate1.Text = dbRS["START_TIME"].ToString();


                    }
                    dbRS.Close();
                }

                clsDB.FunClsDB();
            }

        }

        private string FunGetFabInTime(string sValue)
        {
            switch (sValue)
            {
                case "1": return "大於6個月~1年";
                case "2": return "大於1年";
                default: return sValue;
            }
        }

        private void cboCust_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCust.Text != "")
            {
                cboCustGrp.Text = "";
            }
        }

        private void cboCustGrp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCustGrp.Text != "")
            {
                cboCust.Text = "";
            }
        }

        private void cboCust_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (char)27; //ESC
        }

        private void cboCustGrp_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (char)27; //ESC
        }






    }
}
