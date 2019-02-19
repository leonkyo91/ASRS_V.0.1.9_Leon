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
    public partial class frm_ASRS_EMPTY_OUT : Form
    {
        public frm_ASRS_EMPTY_OUT()
        {
            InitializeComponent();
        }

        private void frm_ASRS_EMPTY_OUT_Load(object sender, EventArgs e)
        {
            FormInit();
        }

        private void FormInit()
        {
            FormCls();

            clsASRS.SubCboSetStnNo(ref cboStnNo);
            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };
            cboStnNo.Text = clsASRS.FunGetStnNoByAreaNo(clsASRS.gsAreaNo);
            clsDB.FunClsDB();
        }


        private void FormCls()
        {            
            txtLoc.Text = "";
            txtLoc1.Text = "";
            txtLoc2.Text = "";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            //string strSql = ""; DbDataReader dbRS = null;
            string sSQL = "";

            #region 防呆
            string sLoc1 = ""; string sLocID1 = ""; string sLoc2 = ""; string sLocID2 = "";

            //中科廠-站號依儲位
            //if (clsASRS.FunChkStnNo(cboStnNo.Text.Trim()) == false) { return; }

            if ((rdbSel1.Checked == false) && (rdbSel2.Checked == false))
            {
                clsMSG.ShowWarningMsg("請選擇空料盒");
                return;
            }

            if (rdbSel1.Checked == true)
            {
                if (txtLoc.Text == "")
                {
                    clsMSG.ShowWarningMsg("請輸入空料盒儲位");
                    return;
                }
                else
                {
                    sLoc1 = txtLoc.Text.Trim();
                    sLoc2 = "";
                }
            }

            if (rdbSel2.Checked == true)
            {
                if (txtLoc1.Text == "")
                {
                    clsMSG.ShowWarningMsg("請輸入空料盒儲位 (左側)");
                    return;
                }                 
                if (txtLoc2.Text == "")
                {
                    clsMSG.ShowWarningMsg("請輸入空料盒儲位 (右側)");
                    return;
                }
                sLoc1 = txtLoc1.Text.Trim();
                sLoc2 = txtLoc2.Text.Trim();
            }

            #endregion

            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; }

            #region 判斷左右的儲位一定要正確
            if ((sLoc1 != "") && (sLoc2 != ""))
            {
                bool bFlagA = false;
                if (clsTool.INT(sLoc1.Substring(4, 2)) == clsTool.INT(sLoc2.Substring(4, 2)))
                {
                    if (clsTool.INT(sLoc1.Substring(2, 2)) == clsTool.INT(sLoc2.Substring(2, 2)))
                    {
                        int iLoc1_Row = clsTool.INT(sLoc1.Substring(0, 2)) % 4;
                        int iLoc2_Row = clsTool.INT(sLoc2.Substring(0, 2)) % 4;

                        if (iLoc1_Row == 3)
                        {
                            if (iLoc2_Row == 1)
                            {
                                bFlagA = true;
                            }
                        }
                        else if (iLoc1_Row == 2)
                        {
                            if (iLoc2_Row == 0)
                            {
                                bFlagA = true;
                            }
                        }
                        else
                        {
                            bFlagA = false;
                        }
                    }
                    else
                    {
                        bFlagA = false;
                    }
                }
                else
                {
                    bFlagA = false;
                }

                if (bFlagA == false)
                {
                    clsMSG.ShowWarningMsg("空料盒儲位左右儲位不符合規定");
                    clsDB.FunClsDB();
                    return;
                }

            }

            #endregion


            #region 判斷是否有儲位重整中
            string sMsg = "";
            if (clsASRS.FunChkCycleStsIsRunning(ref sMsg) == false)
            {
                clsMSG.ShowInformationMsg(sMsg);
                clsDB.FunClsDB();
                return;
            }
            #endregion

            #region 取得棧板ID
            sLocID1 = clsASRS.FunGetLocID_FromLocMst(sLoc1);
            sLocID2 = clsASRS.FunGetLocID_FromLocMst(sLoc2);            
            #endregion

            #region 取得命令序號
            string sCmdSno = clsASRS.FunGetCmdSno();
            if (sCmdSno == "")
            {
                clsMSG.ShowErrMsg("系統錯誤,無命令序號可使用!!");
                clsDB.FunClsDB(); return;
            }
            #endregion

            
            //預約儲位
            #region 判斷是否有儲位重整中
            string sTmpMsg = "";
            if (clsASRS.FunChkCycleStsIsRunning(ref sTmpMsg) == false)
            {
                clsMSG.ShowInformationMsg(sTmpMsg);
                clsDB.FunClsDB();
                return;
            }
            #endregion

            clsDB.FunCommitCtrl("BEGIN");

            //產生出庫命令
            bool bFlag = true;
            cls_CmdMst aCmdMst = new cls_CmdMst();
            aCmdMst.FunCmdMstClear();   //Clear()
            aCmdMst.CMDSNO = sCmdSno;
            aCmdMst.CMDMODE = clsASRS.gsCmdMode_Out;   //2

            aCmdMst.SNO1 = "1";
            aCmdMst.LOC1 = sLoc1;
            aCmdMst.LOCID1 = sLocID1;
            aCmdMst.SCAN1 = "Y";
            if (sLoc2 == "")
            {
                aCmdMst.SNO2 = "";
                aCmdMst.LOC2 = "";
                aCmdMst.LOCID2 = "";
                aCmdMst.SCAN2 = "Y";
            }
            else
            {
                aCmdMst.SNO2 = "2";
                aCmdMst.LOC2 = sLoc2;
                aCmdMst.LOCID2 = sLocID2;
                aCmdMst.SCAN2 = "Y";
            }
            aCmdMst.CMDSTS = "0";
            aCmdMst.PRT = "5";
            
            //中科廠-站號依儲位
            //aCmdMst.STNNO = cboStnNo.Text;
            if (cboStnNo.Text == "D04") { aCmdMst.STNNO = cboStnNo.Text; }
            else { aCmdMst.STNNO = clsASRS.FunGetStnNoByLoc_SPIL_ZX(sLoc1); }
            
            
            aCmdMst.IOTYP = clsASRS.gsIOTYPE_EmptyOut;
            aCmdMst.AVAIL = "0";
            aCmdMst.MIXQTY = "0";
            aCmdMst.NEWLOC = "";
            aCmdMst.PROGID = clsASRS.gsIOTYPE_EmptyOut_PID;
            aCmdMst.USERID = clsASRS.gstrLoginUser;
            aCmdMst.TRACE = "0";
            aCmdMst.STORAGETYP = "";
            if (aCmdMst.FunInsCmdMst() == false)
            {
                bFlag = false;
            }

            if (bFlag == true)
            {
                sSQL = "UPDATE LOC_MST SET LOCSTS = 'O' WHERE LOC = '" + sLoc1 + "' AND LOCSTS = 'E' ";
                if (clsDB.FunExecSql(sSQL) == false)
                {
                    bFlag = false;
                }
            }

            if (bFlag == true)
            {
                if (sLoc2 != "")
                {
                    sSQL = "UPDATE LOC_MST SET LOCSTS = 'O' WHERE LOC = '" + sLoc2 + "' AND LOCSTS = 'E' ";
                    if (clsDB.FunExecSql(sSQL) == false)
                    {
                        bFlag = false;
                    }
                }
            }

            if (bFlag == true)
            {
                clsDB.FunCommitCtrl("COMMIT");
                clsDB.FunClsDB();
                this.Cursor = Cursors.Default;
                clsMSG.ShowInformationMsg(clsMSG.MSG.Msg_Run_Finish);
                FormCls();
            }
            else
            {
                clsDB.FunCommitCtrl("ROLLBACK");
                clsMSG.ShowErrMsg(clsMSG.MSG.COMMAND_ERROR);
                clsDB.FunClsDB();
                this.Cursor = Cursors.Default;
                return;
            }



        }

        private void btnHelp1_Click(object sender, EventArgs e)
        {
            clsASRS.gsHelpStyle = "1";
            Array.Resize<string>(ref clsASRS.gsHelpRtnData, 0);

            frmHelp2 frmHelp = new frmHelp2();
            frmHelp.ShowDialog();

            txtLoc.Text = clsASRS.gsHelpRtnData[0];


        }

        private void btnHelp2_Click(object sender, EventArgs e)
        {
            clsASRS.gsHelpStyle = "2";
            Array.Resize<string>(ref clsASRS.gsHelpRtnData, 0);

            frmHelp2 frmHelp = new frmHelp2();
            frmHelp.ShowDialog();

            txtLoc1.Text = clsASRS.gsHelpRtnData[0];
            txtLoc2.Text = clsASRS.gsHelpRtnData[2];
        }

        private void txtLoc1_TextChanged(object sender, EventArgs e)
        {

        }



    }
}
