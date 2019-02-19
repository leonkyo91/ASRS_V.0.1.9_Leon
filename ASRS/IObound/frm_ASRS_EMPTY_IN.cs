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
    public partial class frm_ASRS_EMPTY_IN : Form
    {
        public frm_ASRS_EMPTY_IN()
        {
            InitializeComponent();
        }

        private void frm_ASRS_EMPTY_IN_Load(object sender, EventArgs e)
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
            txtLocID1.Text = "";
            txtLocID2.Text = "";
            txtLocID1.Select();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            int iFosb = 0;  //0:None, 1:Left, 2:Right, 3:ALL
            string sLocID1 = ""; string sLocID2 = "";
            string sGetLoc1 = ""; string sGetLoc2 = ""; string sGetLocID1 = ""; string sGetLocID2 = "";
            int iCrn = 0;
            int iBayDesc = 1;

            #region 防呆
            if (clsASRS.FunChkStnNo(cboStnNo.Text.Trim()) == false) { return; }

            if (cboStnNo.Text == "D04")
            {
                iBayDesc = 2;   //由後面找起
            }
            else
            {
                iBayDesc = 1;
            }

            txtLocID1.Text = txtLocID1.Text.Trim().ToUpper();
            txtLocID2.Text = txtLocID2.Text.Trim().ToUpper();
            sLocID1 = txtLocID1.Text;
            sLocID2 = txtLocID2.Text;

            if (sLocID1 != "")
            {
                if (sLocID2 == "")
                {
                    iFosb = 1;
                }
                else
                {
                    iFosb = 3;

                    //判斷左右的條碼要相同的第一碼
                    string sLocID_H1 = ""; string sLocID_H2 = "";
                    if (txtLocID1.Text.Length > 0)
                    {
                        sLocID_H1 = txtLocID1.Text.Substring(0, 1);
                    }
                    if (txtLocID2.Text.Length > 0)
                    {
                        sLocID_H2 = txtLocID2.Text.Substring(0, 1);
                    }
                    if (sLocID_H1 != sLocID_H2)
                    {
                        clsMSG.ShowWarningMsg("左右兩側的料盒條碼,第一碼要相同的編號");
                        return;
                    }

                }
            }
            else if (sLocID2 != "")
            {
                iFosb = 2;
                clsMSG.ShowWarningMsg("不允許由右側,進行空料盒入庫作業");
                return;
            }
            else
            {
                iFosb = 0;
                clsMSG.ShowWarningMsg("請輸入空料盒條碼");
                return;
            }   
            #endregion


            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; }

            #region 判斷是否有儲位重整中
            string sMsg = "";
            if (clsASRS.FunChkCycleStsIsRunning(ref sMsg) == false)
            {
                clsMSG.ShowInformationMsg(sMsg);
                clsDB.FunClsDB();
                return;
            }
            #endregion

            #region 判斷料盤ID是否有建檔
            if (txtLocID1.Text != "")
            {
                if (clsASRS.FunGetWMSLocByLocID(txtLocID1.Text) == "")
                {
                    clsDB.FunClsDB();
                    clsMSG.ShowWarningMsg("料盤編號 (" + txtLocID1.Text + ") 不正確!!, 請確認系統是否有建立料盤編號.");
                    return;
                }
            }
            if (txtLocID2.Text != "")
            {
                if (clsASRS.FunGetWMSLocByLocID(txtLocID2.Text) == "")
                {
                    clsDB.FunClsDB();
                    clsMSG.ShowWarningMsg("料盤編號 (" + txtLocID2.Text + ") 不正確!!, 請確認系統是否有建立料盤編號.");
                    return;
                }
            }
            #endregion


            #region 判別料盤ID是否己存在儲位中或命令中
            string sTmpMsg = "";
            if (sLocID1 != "")
            {
                if (clsASRS.FunChkLocIdIsExist(sLocID1, ref sTmpMsg) == false)
                {
                    clsMSG.ShowWarningMsg(sTmpMsg);
                    clsDB.FunClsDB();
                    return;
                }
            }
            if (sLocID2 != "")
            {
                if (clsASRS.FunChkLocIdIsExist(sLocID2, ref sMsg) == false)
                {
                    clsMSG.ShowWarningMsg(sMsg);
                    clsDB.FunClsDB();
                    return;
                }
            }
            #endregion

            #region 系統指派空儲位
            iCrn = clsASRS.FunGetCraneNoByLocID(sLocID1); //由料盒ID取得是那一座Crane
            if (iFosb == 3) //ALL
            {
                if (clsASRS.FunGetLocForDoubleListByLocSts(iCrn, "N", ref sGetLoc1, ref sGetLocID1, ref sGetLoc2, ref sGetLocID2) == false)
                {
                    clsMSG.ShowWarningMsg("無空儲位!!"); clsDB.FunClsDB(); return;
                }
            }
            else if (iFosb == 1)
            {

                if (clsASRS.FunGetLocN_ByE(iCrn, ref sGetLoc1, ref sGetLocID1, iBayDesc) == false)
                {
                    clsMSG.ShowWarningMsg("無合適之空儲位!!"); clsDB.FunClsDB(); return;
                }

                ////只有入一個      
                ////(1)先找內側儲位為N,外側儲位為E
                //if (clsASRS.FunGetLocForSingleListByInOutLoc(iCrn, "N", "E", 1, ref sGetLoc1, ref sGetLocID1) == false)
                //{
                //    //(2)找內側儲位為N,外側儲位為E. (TEMP 儲位)
                //    if (clsASRS.FunGetLocForSingleListByInOutLoc_StorageTyp_Temp(iCrn, "N", "E", 1, ref sGetLoc1, ref sGetLocID1, iBayDesc) == false)
                //    {
                //        //(3)找外側儲位為N,內側儲位為N. (TEMP 儲位)
                //        if (clsASRS.FunGetLocForSingleListByInOutLoc_StorageTyp_Temp(iCrn, "N", "N", 2, ref sGetLoc1, ref sGetLocID1, iBayDesc) == false)
                //        {
                //            //(4)找外側儲位為N,內側儲位為N,
                //            if (clsASRS.FunGetLocForSingleListByInOutLoc(iCrn, "N", "N", 2, ref sGetLoc1, ref sGetLocID1) == false)
                //            {
                //                clsMSG.ShowWarningMsg("無合適之空儲位!!"); clsDB.FunClsDB(); return;
                //            }
                //        }
                //    }
                //}
            }
            #endregion

            #region 取得命令序號
            string sCmdSno = clsASRS.FunGetCmdSno();
            if (sCmdSno == "")
            {
                clsMSG.ShowErrMsg("系統錯誤,無命令序號可使用!!");
                clsDB.FunClsDB(); return;
            }
            #endregion

            clsDB.FunCommitCtrl("BEGIN");

            //預約儲位
            sMsg = "";
            if (clsASRS.FunSetLocIsPreStkIn(sGetLoc1, sGetLoc2, ref sMsg) == false)
            {
                clsDB.FunCommitCtrl("ROLLBACK");
                clsMSG.ShowWarningMsg(sMsg); 
                clsDB.FunClsDB(); return;
            }

            //產生入庫命令
            cls_CmdMst aCmdMst = new cls_CmdMst();
            aCmdMst.FunCmdMstClear();   //Clear()
            aCmdMst.CMDSNO = sCmdSno;
            aCmdMst.CMDMODE = clsASRS.gsCmdMode_In;   //1

            aCmdMst.SNO1 = "1";
            aCmdMst.LOC1 = sGetLoc1;
            aCmdMst.LOCID1 = sLocID1;
            aCmdMst.SCAN1 = "Y";   
            if (sGetLoc2 == "")
            {
                aCmdMst.SNO2 = "";
                aCmdMst.LOC2 = "";
                aCmdMst.LOCID2 = "";
                aCmdMst.SCAN2 = "";
            }
            else
            {
                aCmdMst.SNO2 = "2";
                aCmdMst.LOC2 = sGetLoc2;
                aCmdMst.LOCID2 = sLocID2;
                aCmdMst.SCAN2 = "Y";
            }
            aCmdMst.CMDSTS = "0";
            aCmdMst.PRT = "5";

            //中科廠-站號依儲位
            aCmdMst.STNNO = cboStnNo.Text;
            if (cboStnNo.Text == "D04") { aCmdMst.STNNO = cboStnNo.Text; }
            else { aCmdMst.STNNO = clsASRS.FunGetStnNoByLoc_SPIL_ZX(sGetLoc1); }                        
            
            aCmdMst.IOTYP = clsASRS.gsIOTYPE_EmptyIn;
            aCmdMst.AVAIL = "0";
            aCmdMst.MIXQTY = "0";
            aCmdMst.NEWLOC = "";
            aCmdMst.PROGID = clsASRS.gsIOTYPE_EmptyIn_PID;
            aCmdMst.USERID = clsASRS.gstrLoginUser;
            aCmdMst.TRACE = "0";
            aCmdMst.STORAGETYP = "";
            if (aCmdMst.FunInsCmdMst() == false)
            {
                clsDB.FunCommitCtrl("ROLLBACK");
                clsMSG.ShowErrMsg(clsMSG.MSG.COMMAND_ERROR);
                clsDB.FunClsDB();
                this.Cursor = Cursors.Default;                
                return;
            }
            
            clsDB.FunCommitCtrl("COMMIT");
            clsDB.FunClsDB();

            clsMSG.ShowInformationMsg(clsMSG.MSG.Msg_Run_Finish);
            FormCls();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtLocID1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLocID1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                txtLocID2.Select();
            }
        }

        private void txtLocID2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                btnExecute.Select();
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }




    }
}
