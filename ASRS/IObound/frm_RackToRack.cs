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
    public partial class frm_RackToRack : Form
    {
        public frm_RackToRack()
        {
            InitializeComponent();
        }

        private void frm_RackToRack_Load(object sender, EventArgs e)
        {
            FormInit();
        }

        private void FormInit()
        {
            FormCls();

            clsASRS.SubCboSetCrnNo(ref cboCrnNo);
        }

        private void FormCls()
        {
            cboCrnNo.Text = "";
            txtLoc1.Text = "";
            txtLoc2.Text = "";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void SubClear()
        {
            txtLoc1.Text = "";
            txtLoc2.Text = "";
        }

        private void txtLoc1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLoc2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnHelp1_Click(object sender, EventArgs e)
        {
            if (cboCrnNo.Text == "") { return; }

            clsASRS.gsHelpStyle = "LOC_S_E";
            clsASRS.gsHelpStyle_Data = cboCrnNo.Text;
            Array.Resize<string>(ref clsASRS.gsHelpRtnData, 0);

            frmHelp frmHelp = new frmHelp();
            frmHelp.ShowDialog();

            txtLoc1.Text = clsASRS.gsHelpRtnData[0];
        }

        private void btnHelp2_Click(object sender, EventArgs e)
        {
            if (cboCrnNo.Text == "") { return; }

            clsASRS.gsHelpStyle = "LOC_N";
            clsASRS.gsHelpStyle_Data = cboCrnNo.Text;
            Array.Resize<string>(ref clsASRS.gsHelpRtnData, 0);

            frmHelp frmHelp = new frmHelp();
            frmHelp.ShowDialog();

            txtLoc2.Text = clsASRS.gsHelpRtnData[0];
        }

        private void cboCrnNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtLoc1.Text = "";
            txtLoc2.Text = "";
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            string sSQL = ""; DbDataReader dbRS = null;

            #region 防呆,防止輸入空白欄位
            if (txtLoc1.Text == "")
            {
                clsMSG.ShowWarningMsg("請輸入來源儲位");
                return;
            }
            if (txtLoc2.Text == "")
            {
                clsMSG.ShowWarningMsg("請輸入目的儲位");
                return;
            }
            #endregion

            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };

            #region 判斷是否有儲位重整中
            string sTmpMsg = "";
            if (clsASRS.FunChkCycleStsIsRunning(ref sTmpMsg) == false)
            {
                clsMSG.ShowInformationMsg(sTmpMsg);
                clsDB.FunClsDB();
                return;
            }
            #endregion

            #region 防呆,防止來源儲位和目的儲位的儲位狀態是否正確
            string sLocSts_S = ""; string sLocID_S = "";
            sSQL = "SELECT * FROM LOC_MST WHERE LOC = '" + txtLoc1.Text + "' ";
            if (clsDB.FunRsSql(sSQL, ref dbRS))
            {
                while (dbRS.Read())
                {
                    sLocSts_S = dbRS["LOCSTS"].ToString();
                    sLocID_S = dbRS["LOCID"].ToString();
                }
                dbRS.Close();
            }
            if (!((sLocSts_S == "S") || (sLocSts_S == "E")))
            {
                clsMSG.ShowWarningMsg("來源儲位不是庫存儲位或空料盒儲位!!");
                clsDB.FunClsDB();
                return;
            }

            string sLocSts_E = "";
            sSQL = "SELECT * FROM LOC_MST WHERE LOC = '" + txtLoc2.Text + "' ";
            if (clsDB.FunRsSql(sSQL, ref dbRS))
            {
                while (dbRS.Read())
                {
                    sLocSts_E = dbRS["LOCSTS"].ToString();
                }
                dbRS.Close();
            }
            if (sLocSts_E != "N")
            {
                clsMSG.ShowWarningMsg("目的儲位不是空儲位");
                clsDB.FunClsDB();
                return;
            }
            
            int iCrn_S = clsASRS.FunGetCraneNoByLoc(txtLoc1.Text);
            int iCrn_E = clsASRS.FunGetCraneNoByLoc(txtLoc2.Text);

            if (iCrn_S != iCrn_E)
            {
                clsMSG.ShowWarningMsg("來源儲位和目的儲位不是同一座Crane");
                clsDB.FunClsDB();
                return;
            }
            #endregion
                        
            if (sLocID_S == "")
            {
                clsMSG.ShowWarningMsg("錯誤,料盒編號是空值");
                clsDB.FunClsDB();
                return;
            }


            //下達庫對庫命令
            #region 讀取命令序號 (sCmdSno)
            string sCmdSno = "";
            sCmdSno = clsASRS.FunGetCmdSno();
            if (sCmdSno == "") { clsMSG.ShowErrMsg("系統錯誤,產生命令失敗!!"); clsDB.FunClsDB(); return; }
            #endregion
            
            bool bFlag = true;
            clsDB.FunCommitCtrl("BEGIN");

            #region 預約 出庫儲位(O)
            if (bFlag == true)
            {
                sSQL = "UPDATE LOC_MST SET LOCSTS = 'O',OLDSTS = '" + sLocSts_S + "'  WHERE LOC = '" + txtLoc1.Text + "' AND LOCSTS = '" + sLocSts_S + "' ";
                if (clsDB.FunExecSql(sSQL) == false) { bFlag = false; }
            }
            #endregion

            #region 預約 入庫儲位(I)
            if (bFlag == true)
            {
                sSQL = "UPDATE LOC_MST SET LOCSTS = 'I',OLDSTS = '" + sLocSts_E + "' WHERE LOC = '" + txtLoc2.Text + "' AND LOCSTS = 'N' ";
                if (clsDB.FunExecSql(sSQL) == false) { bFlag = false; }
            }
            #endregion

            cls_CmdMst aCmdMst = new cls_CmdMst();

            #region 產生命令主檔
            if (bFlag == true)
            {
                aCmdMst.FunCmdMstClear();   //Clear()

                aCmdMst.CMDSNO = sCmdSno;
                aCmdMst.SNO1 = "1";
                aCmdMst.LOC1 = txtLoc1.Text;
                aCmdMst.LOCID1 = sLocID_S;
                aCmdMst.SCAN1 = "Y"; aCmdMst.SCAN2 = "Y";

                aCmdMst.NEWLOC = txtLoc2.Text;
                
                aCmdMst.SNO2 = "";
                aCmdMst.LOC2 = "";
                aCmdMst.LOCID2 = "";

                aCmdMst.CMDMODE = clsASRS.gsCmdMode_R2R;   //5
                                
                aCmdMst.CMDSTS = "0";
                aCmdMst.PRT = "5";
                aCmdMst.STNNO = "";
                //aCmdMst.IOTYP = clsASRS.gsIOTYPE_R2R;
                if (sLocSts_S == "S")
                {
                    aCmdMst.IOTYP = "51";
                }
                else if (sLocSts_S == "E")
                {
                    aCmdMst.IOTYP = "52";
                }
                aCmdMst.AVAIL = "0";
                aCmdMst.MIXQTY = "0";                
                aCmdMst.PROGID = clsASRS.gsIOTYPE_R2R_PID;
                aCmdMst.USERID = clsASRS.gstrLoginUser;
                aCmdMst.TRACE = "0";
                aCmdMst.STORAGETYP = "";
                if (aCmdMst.FunInsCmdMst() == false)
                {
                    bFlag = false;
                }
            }
            #endregion

            if (bFlag == true)
            {
                clsDB.FunCommitCtrl("COMMIT");
                clsMSG.ShowInformationMsg("庫對庫命令產生完成!!");
                SubClear();
            }
            else
            {
                clsDB.FunCommitCtrl("ROLLBACK");
                clsMSG.ShowErrMsg("庫對庫命令產生失敗!!");
            }
            
            clsDB.FunClsDB();

            SubClear();
        }


    }
}
