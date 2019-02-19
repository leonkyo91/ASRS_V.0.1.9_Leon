using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ASRS
{
    public partial class frm_ASRS_OFFLINE_IN_1 : Form
    {
        Color gsColor_MustInput = Color.Orange;

        public frm_ASRS_OFFLINE_IN_1()
        {
            InitializeComponent();
        }

        private void frm_ASRS_OFFLINE_IN_1_Load(object sender, EventArgs e)
        {
            FormInit();
        }

        private void FormInit()
        {
            clsASRS.SetStore(ref cboStore);
            SubClsForm();

            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };
            txtACC_ID.Text = clsASRS.FunGetACCID();
            clsDB.FunClsDB();

            txtDate.Text = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            cboStore.BackColor = gsColor_MustInput;
            txtLotNo.BackColor = gsColor_MustInput;
        }

        private void SubClsForm()
        {
            txtACC_ID.Text = "";
            cboStore.SelectedIndex = 0;
            txtLotNo.Text = "";
            txtOffQty.Text = "";
            txtWaferQty.Text = "";
            txtShipQty.Text = "";
            txtItemNo.Text = "";
            txtDevice.Text = "";
            txtRemark.Text = "";
            txtCust.Text = "";
            txtFabLot.Text = "";
            txtLotType.Text = "";
            txtCustomer.Text = "";
            txtTypeNo.Text = "";
            txtSize.Text = "";
            txtYield.Text = "";

            txtDate.Text = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            //判斷防呆
            #region 判斷防呆
            txtLotNo.Text = txtLotNo.Text.Trim();
            if (cboStore.Text.ToUpper().Trim() == "IC")
            {
                if (txtOffQty.Text == "")
                {
                    clsMSG.ShowWarningMsg("請輸入件數");
                    return;
                }
            }
            else if (cboStore.Text.ToUpper().Trim() == "WAFER.DIE")
            {
                if ((txtWaferQty.Text == "") && (txtShipQty.Text == ""))
                {
                    clsMSG.ShowWarningMsg("請輸入枚數或數量");
                    return;
                }
            }
            else if (cboStore.Text.ToUpper().Trim() == "OTHERS")
            {
                if ((txtOffQty.Text == "") && (txtWaferQty.Text == "") && (txtShipQty.Text == ""))
                {
                    clsMSG.ShowWarningMsg("請輸入件數或枚數或數量");
                    return;
                }
            }
            else
            {
                clsMSG.ShowWarningMsg("請選擇材料類別");
                return;
            }

            if (txtLotNo.Text == "")
            {
                clsMSG.ShowWarningMsg("請輸入Lot No");
                return;
            }
            #endregion

            string sSQL = "";

            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };

            sSQL = "INSERT INTO TRNTKT_ACC (ACC_ID,ITEMNO,CUSTOMER,DEVICE,LOTNO,STORE,OFFQTY,WAFERQTY,SHIPQTY,CHKIQC,";
            sSQL = sSQL + "REMARK,TRANSACTION_DATE,GIB_CUSTOMER,FAB_LOT_NO,TYPENO,LOT_TYPE,WAFER_SIZE,YIELD) VALUES (";
            sSQL = sSQL + "'" + txtACC_ID.Text + "',";                                   //ACC_ID
            sSQL = sSQL + "'" + txtItemNo.Text + "',";                       //ITEMNO
            sSQL = sSQL + "'" + txtCust.Text + "',";                         //CUSTOMER
            sSQL = sSQL + "'" + txtDevice.Text + "',";                       //DEVICE
            sSQL = sSQL + "'" + txtLotNo.Text + "',";                        //LOTNO
            sSQL = sSQL + "'" + cboStore.Text + "',";                       //STORE
            sSQL = sSQL + "'" + clsTool.INT(txtOffQty.Text) + "',";                              //OFFQTY
            sSQL = sSQL + "'" + clsTool.INT(txtWaferQty.Text) + "',";                            //WAFERQTY
            sSQL = sSQL + "'" + clsTool.INT(txtShipQty.Text) + "',";                             //SHIPQTY
            sSQL = sSQL + "'N',";                                                        //CHKIQC
            sSQL = sSQL + "'" + txtRemark.Text + "',";                       //REMARK
            sSQL = sSQL + "'" + txtDate.Text + "',";   				    //TRANSACTION_DATE
            sSQL = sSQL + "'" + txtCust.Text + "',";                     //GIB_CUSTOMER
            sSQL = sSQL + "'" + txtFabLot.Text + "',";                       //FAB_LOT_NO
            sSQL = sSQL + "'" + txtCustomer.Text + "',";                       //TYPENO
            sSQL = sSQL + "'" + txtLotType.Text + "',";                      //LOT_TYPE
            sSQL = sSQL + "'" + txtSize.Text + "',";                         //WAFER_SIZE
            sSQL = sSQL + "'" + txtYield.Text + "') ";                       //YIELD

            clsDB.FunCommitCtrl("BEGIN");
            if (clsDB.FunExecSql(sSQL) == false)
            {
                clsDB.FunCommitCtrl("ROLLBACK");
                clsMSG.ShowErrMsg(clsMSG.MSG.Msg_Run_Error);
                clsDB.FunClsDB();
                return;
            }
            else
            {
                clsDB.FunCommitCtrl("COMMIT");
            }           

            clsDB.FunClsDB();

            //回傳給主畫面
            clsASRS.gsHelpRtnData[0] = txtACC_ID.Text;
            this.Close();
        }

        private void cboStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboStore.Text.ToUpper().Trim() == "IC")
            {
                txtOffQty.BackColor = gsColor_MustInput;
                txtWaferQty.BackColor = Color.White;
                txtShipQty.BackColor = Color.White;
            }
            else if (cboStore.Text.ToUpper().Trim() == "WAFER.DIE")
            {
                txtOffQty.BackColor = Color.White;
                txtWaferQty.BackColor = gsColor_MustInput;
                txtShipQty.BackColor = gsColor_MustInput;
            }
            else if (cboStore.Text.ToUpper().Trim() == "OTHERS")
            {
                txtOffQty.BackColor = gsColor_MustInput;
                txtWaferQty.BackColor = Color.White;
                txtShipQty.BackColor = Color.White;
            }
            else
            {
                txtOffQty.BackColor = Color.White;
                txtWaferQty.BackColor = Color.White;
                txtShipQty.BackColor = Color.White;
            }
        }

        private void cboStore_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (char)27; //ESC
        }
        
    }
}
