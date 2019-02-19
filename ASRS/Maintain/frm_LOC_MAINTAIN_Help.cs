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
    public partial class frm_LOC_MAINTAIN_Help : Form
    {
        public frm_LOC_MAINTAIN_Help()
        {
            InitializeComponent();
        }

        private void frm_LOC_MAINTAIN_Help_Load(object sender, EventArgs e)
        {
            FormInit();
        }

        private void FormInit()
        {
            string[] sData = new string[0];
            sData = clsASRS.gsHelpStyle_Data.Split(',');

            if (clsASRS.gsHelpStyle == "ADD")
            {
                FormCls();
            }
            else if (clsASRS.gsHelpStyle == "UPD") 
            {
                txtFosbID.Text = sData[0];      //FOSB ID
                txtItemNo.Text = sData[1];      //ITMENO
                txtCust.Text = sData[2];        //CUSTOMER
                txtDevice.Text = sData[3];      //DEVICE
                txtLotNo.Text = sData[4];       //LOT NO
                txtOffQty.Text = sData[5];      //OFFQTY
                txtWaferQty.Text = sData[6];    //WAFERQTY
                txtShipQty.Text = sData[7];     //SHIPQTY
                txtChkIQC.Text = sData[8];      //IQC
                txtInDate.Text = sData[9];      //INDATE            
                txtRemark.Text = sData[10];      //REMARK

            }
            else if (clsASRS.gsHelpStyle == "DEL")
            {
                txtFosbID.Text = sData[0];      //FOSB ID
                txtItemNo.Text = sData[1];      //ITMENO
                txtCust.Text = sData[2];        //CUSTOMER
                txtDevice.Text = sData[3];      //DEVICE
                txtLotNo.Text = sData[4];       //LOT NO
                txtOffQty.Text = sData[5];      //OFFQTY
                txtWaferQty.Text = sData[6];    //WAFERQTY
                txtShipQty.Text = sData[7];     //SHIPQTY
                txtChkIQC.Text = sData[8];      //IQC
                txtInDate.Text = sData[9];      //INDATE            
                txtRemark.Text = sData[10];      //REMARK
            }
        }

        private void FormCls()
        {
            txtFosbID.Text = "";      //FOSB ID
            txtItemNo.Text = "";      //ITMENO
            txtCust.Text = "";        //CUSTOMER
            txtDevice.Text = "";      //DEVICE
            txtLotNo.Text = "";       //LOT NO
            txtOffQty.Text = "";      //OFFQTY
            txtWaferQty.Text = "";    //WAFERQTY
            txtShipQty.Text = "";     //SHIPQTY
            txtChkIQC.Text = "";      //IQC
            txtInDate.Text = "";      //INDATE            
            txtRemark.Text = "";      //REMARK

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            //防呆
            if (txtFosbID.Text == "") { return; }
            
            if (clsASRS.gsHelpStyle == "ADD")
            {
                if (SubAdd() == true)
                {
                    clsASRS.gsHelpRtnData[0] = "Y";
                    this.Close();
                }
            }
            else if (clsASRS.gsHelpStyle == "UPD")
            {
                if (SubUpd() == true)
                {
                    clsASRS.gsHelpRtnData[0] = "Y";
                    this.Close();
                }
            }
            else if (clsASRS.gsHelpStyle == "DEL")
            {
                if (SubDel() == true)
                {
                    clsASRS.gsHelpRtnData[0] = "Y";
                    this.Close();
                }
            }
        }

        private bool SubAdd()
        {
            string sSQL = ""; DbDataReader dbRS = null;

            string sLoc = ""; string sItemNo = ""; string sCustomer = ""; string sDevice = "";
            string sLotNo = ""; string sStore = "";
            int iOFFQTY = 0; int iWAFERQTY = 0; int iSHIPQTY=0;
            string sCHKIQC = ""; string sONDATA = ""; string sFOSBID = "";

            sLoc = clsASRS.gsHelpStyle_MLoc;
            sFOSBID = txtFosbID.Text;
            sItemNo = txtItemNo.Text ;
            sCustomer = txtCust.Text;
            sDevice = txtDevice.Text;
            sLotNo = txtLotNo.Text;
            sStore = "";
            iOFFQTY = clsTool.INT(txtOffQty.Text);
            iWAFERQTY = clsTool.INT(txtWaferQty.Text);
            iSHIPQTY = clsTool.INT(txtShipQty.Text);
            sCHKIQC = txtChkIQC.Text;
            sONDATA = "Y";

            if (sFOSBID == "") { return false; }

            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return false; };

            sSQL = "INSERT INTO LOC_DTL(LOC,ITEMNO,CUSTOMER,DEVICE,LOTNO,STORE,OFFQTY,WAFERQTY,SHIPQTY,CHKIQC,ONDATA,";
            sSQL = sSQL + "FOSBID,IQC_ID,ACC_ID,INDATE,TRNDATE,REMARK,TRANSACTION_DATE,GIB_CUSTOMER,FAB_LOT_NO,FAB_TYPE,";
            sSQL = sSQL + "TYPENO,LOT_TYPE,WAFER_SIZE,YIELD,APP_NO,REL_DATE,REASON_NAME,TRANSACTION_REFERENCE,TRANSACTION_SOURCE_ID,";
            sSQL = sSQL + "TRANSACTION_TYPE_ID,FROM_ORG,TO_ORG,FROM_BANK,TO_BANK,DOCID) VALUES (";
            sSQL = sSQL + "'" + sLoc + "',";
            sSQL = sSQL + "'" + sItemNo + "',";
            sSQL = sSQL + "'" + sCustomer + "',";
            sSQL = sSQL + "'" + sDevice + "',";
            sSQL = sSQL + "'" + sLotNo + "',";
            sSQL = sSQL + "'" + sStore + "',";
            sSQL = sSQL + iOFFQTY + ",";
            sSQL = sSQL + iWAFERQTY + ",";
            sSQL = sSQL + iSHIPQTY + ",";
            sSQL = sSQL + "'" + sCHKIQC + "',";
            sSQL = sSQL + "'" + sONDATA + "',";
            sSQL = sSQL + "'" + sFOSBID + "',";
            sSQL = sSQL + "'','',";     //IQC_ID,ACC_ID
            sSQL = sSQL + "'" + txtInDate.Text + "',";
            sSQL = sSQL + "'" + clsTool.GetDateTime() + "',";
            sSQL = sSQL + "'',";     //REMARK
            sSQL = sSQL + "'" + txtDate.Text + "',";                //TRANSACTION_DATE
            sSQL = sSQL + "'','','','','','','','','','','','','','','','','','')";
            if (clsDB.FunExecSql(sSQL) == true)
            {
                clsDB.FunClsDB();
                return true;
            }
            else
            {
                clsDB.FunClsDB();
                clsMSG.ShowWarningMsg(clsMSG.MSG.Msg_Run_Error);
                return false;
            }
        }

        private bool SubDel()
        {
            string sSQL = "";
            string sLoc = ""; string sItemNo = ""; string sCustomer = ""; string sDevice = "";
            string sLotNo = ""; string sFOSBID = "";

            sLoc = clsASRS.gsHelpStyle_MLoc;
            sFOSBID = txtFosbID.Text;
            sItemNo = txtItemNo.Text;
            sCustomer = txtCust.Text;
            sDevice = txtDevice.Text;
            sLotNo = txtLotNo.Text;

            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return false; };

            sSQL = "DELETE FROM LOC_DTL WHERE LOC = '" + sLoc + "' ";
            sSQL = sSQL + "AND ITEMNO = '" + sItemNo + "' ";
            sSQL = sSQL + "AND FOSBID = '" + sFOSBID + "' ";
            sSQL = sSQL + "AND LOTNO = '" + sLotNo + "' ";
            if (clsDB.FunExecSql(sSQL) == true)
            {
                clsDB.FunClsDB();
                return true;
            }
            else
            {
                clsDB.FunClsDB();
                clsMSG.ShowWarningMsg(clsMSG.MSG.Msg_Run_Error);
                return false;
            }

        }

        private bool SubUpd()
        {
            string sSQL = ""; DbDataReader dbRS = null;

            string sLoc = ""; string sItemNo = ""; string sCustomer = ""; string sDevice = "";
            string sLotNo = ""; string sStore = "";
            int iOFFQTY = 0; int iWAFERQTY = 0; int iSHIPQTY = 0;
            string sCHKIQC = ""; string sONDATA = ""; string sFOSBID = "";

            sLoc = clsASRS.gsHelpStyle_MLoc;
            sFOSBID = txtFosbID.Text;
            sItemNo = txtItemNo.Text;
            sCustomer = txtCust.Text;
            sDevice = txtDevice.Text;
            sLotNo = txtLotNo.Text;
            sStore = "";
            iOFFQTY = clsTool.INT(txtOffQty.Text);
            iWAFERQTY = clsTool.INT(txtWaferQty.Text);
            iSHIPQTY = clsTool.INT(txtShipQty.Text);
            sCHKIQC = txtChkIQC.Text;
            sONDATA = "Y";

            if (sFOSBID == "") { return false; }

            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return false; };

            sSQL = "UPDATE LOC_DTL SET ";
            sSQL = sSQL + "OFFQTY = " + iOFFQTY + ", ";
            sSQL = sSQL + "WAFERQTY = " + iWAFERQTY + ", ";
            sSQL = sSQL + "SHIPQTY = " + iSHIPQTY + ", ";
            sSQL = sSQL + "CHKIQC = '" + sCHKIQC + "', ";
            sSQL = sSQL + "DEVICE = '" + sDevice + "', ";
            sSQL = sSQL + "CUSTOMER = '" + sCustomer + "',";
            sSQL = sSQL + "INDATE = '" + txtInDate.Text + "', ";
            sSQL = sSQL + "TRANSACTION_DATE  = '" + txtDate.Text + "' ";
            sSQL = sSQL + "WHERE LOC = '" + sLoc + "' ";
            sSQL = sSQL + "AND ITEMNO = '" + sItemNo + "' ";
            sSQL = sSQL + "AND FOSBID = '" + sFOSBID + "' ";
            sSQL = sSQL + "AND LOTNO = '" + sLotNo + "' ";
            if (clsDB.FunExecSql(sSQL) == true)
            {
                clsDB.FunClsDB();
                return true;
            }
            else
            {
                clsDB.FunClsDB();
                clsMSG.ShowWarningMsg(clsMSG.MSG.Msg_Run_Error);
                return false;
            }
        }


    }
}
