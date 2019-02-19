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
    public partial class frm_AUTHORITY : Form
    {
        public frm_AUTHORITY()
        {
            InitializeComponent();
        }

        private void frm_AUTHORITY_Load(object sender, EventArgs e)
        {
            
            FormInit();
            this.WindowState = FormWindowState.Maximized;
        }

        private void FormInit()
        {
            lsbLeft.Items.Clear();
            lsbRight.Items.Clear();

            cboPrivilege.Items.Clear();
            cboPrivilege.Items.Add("");

            string strSql = "";
            DbDataReader dbRS = null;

            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };

            strSql = "SELECT * FROM CODE_DTL WHERE CODE_TYPE = 'PRIVILEGE' ORDER BY CODE_NO ";
            if (clsDB.FunRsSql(strSql, ref dbRS))
            {
                while (dbRS.Read())
                {
                    cboPrivilege.Items.Add(dbRS["CODE_NO"].ToString() + ":" + dbRS["CODE_NAME"].ToString());
                }
                dbRS.Close(); // DbDataReader Close
            }

            clsDB.FunClsDB();   //Close DB
        }

        private void cboPrivilege_SelectedIndexChanged(object sender, EventArgs e)
        {
            SubQueryData();
        }

        private void cboPrivilege_TextChanged(object sender, EventArgs e)
        {

        }

        private void SubQueryData()
        {
            string sPri = "";
            sPri = clsTool.FunGetComineData(cboPrivilege.Text);
            if (sPri == "")
            {
                lsbLeft.Items.Clear();
                lsbRight.Items.Clear();
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };
            FunGetRightProg(sPri);
            clsDB.FunClsDB();   

            this.Cursor = Cursors.Default;
        }

        private void FunGetRightProg(string sPri)
        {
            string strSql = ""; DbDataReader dbRS = null;

            lsbLeft.Items.Clear();
            lsbRight.Items.Clear();            

            strSql = "SELECT A.PROG_ID,A.PROG_NAME_TW FROM PROG_LIST A WHERE EXISTS ";
            strSql = strSql + "(SELECT B.PROG_ID FROM FMSSEC B WHERE A.PROG_ID = B.PROG_ID AND B.PROGSTYLE = '" + sPri + "') ";
            strSql = strSql + "ORDER BY A.PROG_ID ";
            if (clsDB.FunRsSql(strSql, ref dbRS))
            {
                while (dbRS.Read())
                {
                    lsbRight.Items.Add(dbRS["PROG_ID"].ToString() + "－" + dbRS["PROG_NAME_TW"].ToString());
                }
                dbRS.Close(); 
            }

            strSql = "SELECT A.PROG_ID,A.PROG_NAME_TW FROM PROG_LIST A WHERE NOT EXISTS ";
            strSql = strSql + "(SELECT B.PROG_ID FROM FMSSEC B WHERE A.PROG_ID = B.PROG_ID AND B.PROGSTYLE = '" + sPri + "') ";
            strSql = strSql + "ORDER BY A.PROG_ID ";
            if (clsDB.FunRsSql(strSql, ref dbRS))
            {
                while (dbRS.Read())
                {
                    lsbLeft.Items.Add(dbRS["PROG_ID"].ToString() + "－" + dbRS["PROG_NAME_TW"].ToString());
                }
                dbRS.Close(); 
            }            
        }
        
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (FunGetPri() == false)
            {
                clsMSG.ShowInformationMsg("無權限可以修改 !");
                return;
            }

            string strSql = "";
            string sPri = ""; string sProgId = "";

            if (lsbLeft.SelectedItems.Count == 0) { return; }
            sPri = clsTool.FunGetComineData(cboPrivilege.SelectedItem.ToString());
            if (sPri == "") { return; }

            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };

            clsDB.FunCommitCtrl("BEGIN");         
            do
            {
                sProgId = lsbLeft.SelectedItems[0].ToString().Substring(0, 6);
                strSql = "INSERT INTO FMSSEC (PROGSTYLE,PROG_ID) VALUES ('" + sPri + "','" + sProgId + "') ";
                if (clsDB.FunExecSql(strSql) == false)
                {
                    clsDB.FunCommitCtrl("ROLLBACK");
                    FunGetRightProg(sPri);
                    clsMSG.ShowErrMsg(clsMSG.MSG.SET_NG);
                    return;
                }
                lsbLeft.Items.Remove(lsbLeft.SelectedItems[0].ToString());
            } while (!((lsbLeft.SelectedItems.Count <= 0)));
            
            clsDB.FunCommitCtrl("COMMIT");

            FunGetRightProg(sPri);

            clsDB.FunClsDB();
            clsMSG.ShowInformationMsg(clsMSG.MSG.SET_PARAMETER_OK);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            string strSql = "";
            string sPri = ""; string sProgId = "";

            if (FunGetPri() == false)
            {
                clsMSG.ShowInformationMsg("無權限可以修改 !");
                return;
            }

            if (lsbRight.SelectedItems.Count == 0) { return; }
            sPri = clsTool.FunGetComineData(cboPrivilege.SelectedItem.ToString());
            if (sPri == "") { return; }

            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };

            clsDB.FunCommitCtrl("BEGIN");
            do
            {
                sProgId = lsbRight.SelectedItems[0].ToString().Substring(0, 6);
                strSql = "DELETE FROM FMSSEC WHERE PROGSTYLE = '" + sPri + "' ";
                strSql = strSql + "AND PROG_ID = '" + sProgId + "' ";
                if (clsDB.FunExecSql(strSql) == false)
                {
                    clsDB.FunCommitCtrl("ROLLBACK");
                    FunGetRightProg(sPri);
                    clsMSG.ShowErrMsg(clsMSG.MSG.SET_NG);
                    clsDB.FunClsDB();
                    return;
                }
                lsbRight.Items.Remove(lsbRight.SelectedItems[0].ToString());
            } while (!((lsbRight.SelectedItems.Count <= 0)));

            clsDB.FunCommitCtrl("COMMIT");

            FunGetRightProg(sPri);

            clsDB.FunClsDB();
            clsMSG.ShowInformationMsg(clsMSG.MSG.SET_PARAMETER_OK);
        }

        private void btnAddAll_Click(object sender, EventArgs e)
        {
            string strSql = "";
            string sPri = ""; string sProgId = "";

            if (FunGetPri() == false)
            {
                clsMSG.ShowInformationMsg("無權限可以修改 !");
                return;
            }

            //if (lsbLeft.SelectedItems.Count == 0) { return; }
            sPri = clsTool.FunGetComineData(cboPrivilege.SelectedItem.ToString());
            if (sPri == "") { return; }

            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };

            clsDB.FunCommitCtrl("BEGIN");

            int i = 0;
            for (i = 0; i <= lsbLeft.Items.Count-1; i++)
            {
                sProgId = lsbLeft.Items[i].ToString().Substring(0, 6);
                strSql = "INSERT INTO FMSSEC (PROGSTYLE,PROG_ID) VALUES ('" + sPri + "','" + sProgId + "') ";
                if (clsDB.FunExecSql(strSql) == false)
                {
                    clsDB.FunCommitCtrl("ROLLBACK");
                    FunGetRightProg(sPri);
                    clsMSG.ShowErrMsg(clsMSG.MSG.SET_NG);
                    return;
                }
                //lsbLeft.Items.Remove(lsbLeft.Items[i].ToString());
            } 

            clsDB.FunCommitCtrl("COMMIT");

            FunGetRightProg(sPri);

            clsDB.FunClsDB();
            clsMSG.ShowInformationMsg(clsMSG.MSG.SET_PARAMETER_OK);
        }

        private void btnDelAll_Click(object sender, EventArgs e)
        {
            string strSql = "";
            string sPri = ""; string sProgId = "";

            if (FunGetPri() == false)
            {
                clsMSG.ShowInformationMsg("無權限可以修改 !");
                return;
            }

            sPri = clsTool.FunGetComineData(cboPrivilege.SelectedItem.ToString());
            if (sPri == "" ) { return;}

            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };

            clsDB.FunCommitCtrl("BEGIN");

            int i = 0;
            for (i = 0 ;i<=lsbRight.Items.Count-1; i++)
            {
                sProgId = lsbRight.Items[i].ToString().Substring(0, 6);
                strSql = "DELETE FROM FMSSEC WHERE PROGSTYLE = '" + sPri + "' ";
                strSql = strSql + "AND PROG_ID = '" + sProgId + "' ";
                if (clsDB.FunExecSql(strSql) == false)
                {
                    clsDB.FunCommitCtrl("ROLLBACK");
                    FunGetRightProg(sPri);
                    clsMSG.ShowErrMsg(clsMSG.MSG.SET_NG);
                    clsDB.FunClsDB();
                    return;
                }
                //lsbRight.Items.Remove(lsbRight.Items[i].ToString());
            } 

            clsDB.FunCommitCtrl("COMMIT");

            FunGetRightProg(sPri);

            clsDB.FunClsDB();
            clsMSG.ShowInformationMsg(clsMSG.MSG.SET_PARAMETER_OK);
        }


        private bool FunGetPri()
        {
            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return false; };

            string strSql = ""; DbDataReader dbRS = null;
            string sProg = "";
            strSql = "SELECT * FROM USER_MST WHERE USER_ID = '" + clsASRS.gstrLoginUser + "' ";
            if (clsDB.FunRsSql(strSql, ref dbRS))
            {
                while (dbRS.Read())
                {
                    sProg = dbRS["PROGSTYLE"].ToString();
                }
                dbRS.Close();
            }

            clsDB.FunClsDB();

            if ((sProg == "0") || (sProg == "99"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void cmdExport_Click(object sender, EventArgs e)
        {

        }

    }
}
