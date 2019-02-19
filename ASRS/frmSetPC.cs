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
    public partial class frmSetPC : Form
    {
        public frmSetPC()
        {
            InitializeComponent();
        }

        private void frmSetPC_Load(object sender, EventArgs e)
        {
            lblHostName.Text = clsASRS.gsHostName;
            SubGetPcAreaList();
        }

        private void SubGetPcAreaList()
        {
            cboAreaNo.Items.Clear();

            string strSql = ""; string sData = "";
            strSql = "SELECT * FROM AREA_CTRL ORDER BY AREA_NO ";

            DbDataReader dbRS = null;
            if (clsDB.FunRsSql(strSql, ref dbRS))
            {
                while (dbRS.Read())
                {
                    sData = dbRS["AREA_NO"].ToString() + ":" + dbRS["AREA_NAME"].ToString();
                    cboAreaNo.Items.Add(sData);
                }
                dbRS.Close();
            }
            else
            {                
                return;
            }           
        
        }

        private void butExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string strSql = ""; string strSql1 = "";

            if (lblHostName.Text == "")
            {
                clsMSG.ShowWarningMsg(clsMSG.MSG.HOSTNAME_IS_EMPTY);
                return;
            }

            if (cboAreaNo.Text == "")
            {
                clsMSG.ShowWarningMsg(clsMSG.MSG.PLS_INPUT_AREA);
                return;
            }

            string sAreaNo = clsTool.FunGetComineData(cboAreaNo.Text);
            string sAreaName = clsTool.FunGetComineData2(cboAreaNo.Text);
            if (sAreaNo == "")
            {
                clsMSG.ShowErrMsg(clsMSG.MSG.SET_NG);
                return;            
            }

            strSql = "SELECT * FROM AREA_HOST WHERE HOST_NAME = '" + lblHostName.Text + "'";
            DbDataReader dbRS = null;
            if (clsDB.FunRsSql(strSql, ref dbRS))
            {
                while (dbRS.Read())
                {
                    strSql1 = "DELETE FROM AREA_HOST WHERE HOST_NAME = '" + lblHostName.Text + "'";                    
                }
                dbRS.Close();
            }


            strSql = "INSERT INTO AREA_HOST (AREA_NO,HOST_NAME) VALUES ('" + sAreaNo + "','" + lblHostName.Text + "') ";      
      

            //更新動作
            bool bFlag = true;
            if (strSql1 != "")
            {
                if (clsDB.FunExecSql(strSql1) == false)
                {
                    bFlag = false;
                }
            }

            if (bFlag == true)
            {
                if (clsDB.FunExecSql(strSql) == false)
                {
                    bFlag = false;
                }
            }

            if (bFlag == true)
            {
                clsASRS.gsAreaNo = sAreaNo;
                clsMSG.ShowInformationMsg(clsMSG.MSG.SET_PARAMETER_OK);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                clsMSG.ShowErrMsg(clsMSG.MSG.SET_NG);
            }



            #region
            //if (strSql1 != "")
            //{
            //    if (clsDB.FunExecSql(strSql1) == true)
            //    {
            //        if (clsDB.FunExecSql(strSql) == true)
            //        {
            //            clsASRS.gsAreaNo = sAreaNo;
            //            clsMSG.ShowInformationMsg(clsMSG.MSG.SET_PARAMETER_OK);
            //            this.DialogResult = DialogResult.OK;
            //            this.Close();
            //        }
            //        else
            //        {
            //            clsMSG.ShowErrMsg(clsMSG.MSG.SET_NG);
            //        }
            //    }
            //    else
            //    {
            //        clsMSG.ShowErrMsg(clsMSG.MSG.SET_NG);
            //    }
            //}
            //else
            //{
            //    if (clsDB.FunExecSql(strSql) == true)
            //    {
            //        clsASRS.gsAreaNo = sAreaNo;
            //        clsMSG.ShowInformationMsg(clsMSG.MSG.SET_PARAMETER_OK);
            //        this.DialogResult = DialogResult.OK;
            //        this.Close();
            //    }
            //    else
            //    {
            //        clsMSG.ShowErrMsg(clsMSG.MSG.SET_NG);
            //    }            
            //}
            #endregion

        }



    }
}
