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
    public partial class frm_USER : Form
    {

        #region Grid1 Parameter
        int iCol_USER_ID = 0;
        int iCol_USER_NAME = 1;
        int iCol_USER_PSWD = 2;
        int iCol_USER_PROGSTYLE = 3;
        int iCol_CODE_NAME = 4;
        int iCol_Counts = 5;
        #endregion

        public frm_USER()
        {
            InitializeComponent();
            frm_load();
        }


        private void frm_load()
        {
            try
            {
                System.Data.Common.DbDataReader dbRS = null;
                string strSql = "SELECT * FROM CODE_DTL WHERE CODE_TYPE = 'PRIVILEGE' ORDER BY CODE_NO ";
                if (!clsDB.FunOpenDB())
                {
                    throw new Exception("資料庫開啟失敗!"); 
                }
                if (clsDB.FunRsSql(strSql, ref dbRS))
                {
                    while (dbRS.Read())
                    {
                        cboProgStytle.Items.Add(dbRS["CODE_NO"].ToString() + ":" + dbRS["CODE_NAME"].ToString());
                    }
                    dbRS.Close(); // DbDataReader Close
                }
                clsDB.FunClsDB();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frm_USER_Load(object sender, EventArgs e)
        {
            GridInit();
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

            oGrid.Columns[iCol_USER_ID].Width = 100; oGrid.Columns[iCol_USER_ID].Name = "使用者卡號";
            oGrid.Columns[iCol_USER_NAME].Width = 100; oGrid.Columns[iCol_USER_NAME].Name = "使用者名稱";
            oGrid.Columns[iCol_USER_PSWD].Width = 100; oGrid.Columns[iCol_USER_PSWD].Name = "使用者密碼";
            oGrid.Columns[iCol_USER_PROGSTYLE].Width = 90; oGrid.Columns[iCol_USER_PROGSTYLE].Name = "權限代碼"; oGrid.Columns[iCol_USER_PROGSTYLE].Visible = false;
            oGrid.Columns[iCol_CODE_NAME].Width = 100; oGrid.Columns[iCol_CODE_NAME].Name = "權限等級";
            
            oGrid.RowCount = 0;
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            clsTool.finished(this);
            RdAdd.Checked = true;
            RdDel.Checked = false;
            RdMo.Checked = false;
        }

        private void FormCls()
        {
            clsTool.finished(this);
            RdAdd.Checked = true;
            RdDel.Checked = false;
            RdMo.Checked = false;
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdStart_Click(object sender, EventArgs e)
        {
            Excute();
        }

        private void Excute()
        {
            if (RdAdd.Checked == true)
            {
                SubAdd();
            }
            else if (RdDel.Checked == true)
            {
                SubDel();
            }
            else if (RdMo.Checked == true)
            {
                SubUpdate();
            }

            //try 
            //{
            //    if (!clsDB.FunOpenDB())
            //        throw new Exception("資料庫開啟失敗");

            //    foreach(RadioButton rb in GroupBox2.Controls)
            //    {
            //        if (!rb.Checked)
            //            continue;
            //        string strSql = "";
            //        user_mst um = new user_mst();
            //        switch (rb.Name)
            //        {
            //            case"RdAdd":
            //                if (txtUserID.Text == "" || txtUserName.Text == ""||cboProgStytle.Text=="")
            //                {
            //                    throw new Exception("請輸入使用者ID與使用者名稱");
                                
            //                }
            //                strSql = "";
            //                um.CRT_DATE = DateTime.Now.ToShortDateString();
            //                um.USER_ID = txtUserID.Text;
            //                um.USER_NAME = txtUserName.Text;
            //                um.USER_PSWD = "11111";
            //                um.PROGSTYLE = (cboProgStytle.Text.Split(':'))[0];
            //                if (!clsDB.FunExecSql(um.getStr_InsertDB(typeof(user_mst))))
            //                    throw new Exception("處理失敗");
            //                throw new Exception("處理成功");
                            
            //            case"RdMo":
            //                if (txtUserID.Text == "" || (txtPassWord.Text == "" && txtUserName.Text == "" && cboProgStytle.Text==""))
            //                    throw new Exception("請輸入使用者id與要修改的值");
            //                strSql = "update user_mst set ";
            //                string value = "";
            //                if (txtPassWord.Text != "")
            //                {
            //                    value += (value == "" ? "" : ",") + " user_pswd='" + txtPassWord.Text + "'";
            //                }
            //                if (txtUserName.Text != "")
            //                {
            //                    value += (value == "" ? "" : ",") + " user_name='" + txtUserName.Text + "'";
            //                }
            //                if (cboProgStytle.Text != "")
            //                {
            //                    value += (value == "" ? "" : ",") + " progstyle='" + (cboProgStytle.Text.Split(':'))[0]+"'";
            //                }
            //                strSql += value + " where user_id='" + txtUserID.Text + "'";
            //                if (!clsDB.FunExecSql(strSql))
            //                    throw new Exception("處理失敗");
            //                throw new Exception("處理成功");
                            
            //            case"RdDel":
            //                if (txtUserID.Text == "")
            //                    throw new Exception("請輸入USER_ID");
            //                strSql = "delete user_mst where user_id='" + txtUserID.Text + "'";
            //                if (!clsDB.FunExecSql(strSql))
            //                    throw new Exception("處理失敗");
            //                throw new Exception("處理成功");
                            
            //        }
            //    }


            //}
            //catch (Exception ex) { MessageBox.Show(ex.Message); }
 
        }


        private void SubAdd()
        {
            string strSql = ""; DbDataReader dbRS = null;

            if (txtUserID.Text == "")
            {
                clsMSG.ShowWarningMsg("請輸入使用者卡號");
                return;
            }
            if (txtUserName.Text == "")
            {
                clsMSG.ShowWarningMsg("請輸入使用者名稱");
                return;
            }
            if (txtPassWord.Text == "")
            {
                clsMSG.ShowWarningMsg("請輸入使用者密碼");
                return;
            }
            if (cboProgStytle.Text == "")
            {
                clsMSG.ShowWarningMsg("請輸入權限等級");
                return;
            }

            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };

            strSql = "SELECT * FROM USER_MST WHERE USER_ID = '" + txtUserID.Text + "' ";
            if (clsDB.FunRsSql(strSql, ref dbRS))
            {
                while (dbRS.Read())
                {
                    clsMSG.ShowWarningMsg("使用者卡號重覆!!");
                    dbRS.Close();
                    clsDB.FunClsDB();
                    return;
                }
                dbRS.Close();
            }


            strSql = "INSERT INTO USER_MST(USER_ID,USER_NAME,USER_PSWD,WORK_AREA,CRT_DATE,TRN_USER,TRN_DATE,LOGIN_TM,LOGOUT_TM,PROGSTYLE) VALUES (";
            strSql = strSql + "'" + txtUserID.Text + "',";
            strSql = strSql + "'" + txtUserName.Text + "',";
            strSql = strSql + "'" + txtPassWord.Text + "',";
            strSql = strSql + "' ',";
            strSql = strSql + "'" + System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")  + "',";
            strSql = strSql + "' ',";
            strSql = strSql + "' ',";
            strSql = strSql + "' ',";
            strSql = strSql + "' ',";
            strSql = strSql + "'" + clsTool.FunGetComineData(cboProgStytle.Text) + "') ";
            if (clsDB.FunExecSql(strSql) == true)
            {
                clsMSG.ShowInformationMsg(clsMSG.MSG.ADD_OK);
            }
            else
            {
                clsMSG.ShowWarningMsg(clsMSG.MSG.Msg_Run_Error);
            }

            clsDB.FunClsDB();

            FormCls();

            Query();

        }

        private void SubDel()
        {
            string strSql = ""; DbDataReader dbRS = null;

            if (txtUserID.Text == "")
            {
                clsMSG.ShowWarningMsg("請輸入使用者卡號");
                return;
            }

            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };

            bool bFlag = false;
            strSql = "SELECT * FROM USER_MST WHERE USER_ID = '" + txtUserID.Text + "' ";
            if (clsDB.FunRsSql(strSql, ref dbRS))
            {
                while (dbRS.Read())
                {
                    bFlag = true;
                }
                dbRS.Close();
            }

            if (bFlag == false)
            {
                clsMSG.ShowWarningMsg("查無使用者卡號!!");
                clsDB.FunClsDB();
                return;
            }

            strSql = "DELETE FROM USER_MST WHERE USER_ID = '" + txtUserID.Text + "' ";
            if (clsDB.FunExecSql(strSql) == true)
            {
                clsMSG.ShowInformationMsg(clsMSG.MSG.DELETE_OK);
            }
            else
            {
                clsMSG.ShowWarningMsg(clsMSG.MSG.Msg_Run_Error);
            }

            clsDB.FunClsDB();

            FormCls();

            Query();
        }

        private void SubUpdate()
        {
            string strSql = ""; DbDataReader dbRS = null;

            if (txtUserID.Text == "")
            {
                clsMSG.ShowWarningMsg("請輸入使用者卡號");
                return;
            }
            if (txtUserName.Text == "")
            {
                clsMSG.ShowWarningMsg("請輸入使用者名稱");
                return;
            }
            if (txtPassWord.Text == "")
            {
                clsMSG.ShowWarningMsg("請輸入使用者密碼");
                return;
            }
            if (cboProgStytle.Text == "")
            {
                clsMSG.ShowWarningMsg("請輸入權限等級");
                return;
            }

            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };

            bool bFlag = false;
            strSql = "SELECT * FROM USER_MST WHERE USER_ID = '" + txtUserID.Text + "' ";
            if (clsDB.FunRsSql(strSql, ref dbRS))
            {
                while (dbRS.Read())
                {
                    bFlag = true;                    
                }
                dbRS.Close();
            }

            if (bFlag == false)
            {
                clsMSG.ShowWarningMsg("查無使用者卡號!!");
                clsDB.FunClsDB();
                return;
            }

            strSql = "UPDATE USER_MST SET ";
            strSql = strSql + "USER_NAME = '" + txtUserName.Text + "',";
            strSql = strSql + "USER_PSWD = '" + txtPassWord.Text + "',";
            strSql = strSql + "TRN_DATE = '" + System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "',";
            strSql = strSql + "PROGSTYLE = '" + clsTool.FunGetComineData(cboProgStytle.Text) + "' ";
            strSql = strSql + "WHERE USER_ID = '" + txtUserID.Text + "' ";
            if (clsDB.FunExecSql(strSql) == true)
            {
                clsMSG.ShowInformationMsg(clsMSG.MSG.UPDATE_OK);
            }
            else
            {
                clsMSG.ShowWarningMsg(clsMSG.MSG.Msg_Run_Error);
            }

            clsDB.FunClsDB();

            FormCls();

            Query();

        }

        private void txtUserID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUserID_Leave(object sender, EventArgs e)
        {
            if (txtUserID.Text != "")
            {
                string strSql = ""; DbDataReader dbRS = null;
                if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };

                string sProgStytle = "";
                strSql = "SELECT * FROM USER_MST WHERE USER_ID = '" + txtUserID.Text + "' ";
                if (clsDB.FunRsSql(strSql, ref dbRS))
                {
                    while (dbRS.Read())
                    {
                        txtUserName.Text = dbRS["USER_NAME"].ToString();
                        txtPassWord.Text = dbRS["USER_PSWD"].ToString();
                        sProgStytle= dbRS["PROGSTYLE"].ToString();
                    }
                    dbRS.Close();

                    cboProgStytle.Text = "";
                    if (sProgStytle != "")
                    {
                        strSql = "SELECT * FROM CODE_DTL WHERE CODE_TYPE = 'PRIVILEGE' AND CODE_NO = '" + sProgStytle + "' ";
                        if (clsDB.FunRsSql(strSql, ref dbRS))
                        {
                            while (dbRS.Read())
                            {
                                cboProgStytle.Text = (dbRS["CODE_NO"].ToString() + ":" + dbRS["CODE_NAME"].ToString());
                            }
                            dbRS.Close(); 
                        }
                    }

                }
                


                clsDB.FunClsDB();
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            Query();
        }

        private void Query()
        {
            Grid1.RowCount = 0;

            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };

            string strSql = "SELECT M.USER_ID,M.USER_NAME,M.USER_PSWD,M.PROGSTYLE,D.CODE_NAME FROM USER_MST M LEFT JOIN CODE_DTL D ";
            strSql = strSql + "ON M.PROGSTYLE = D.CODE_NO ";
            strSql = strSql + "WHERE D.CODE_TYPE = 'PRIVILEGE' ";
            strSql = strSql + "ORDER BY M.USER_ID ";

            DbDataReader dbRS = null;

            if (clsDB.FunRsSql(strSql, ref dbRS))
            {

                while (dbRS.Read())
                {
                    Grid1.Rows.Add();
                    Grid1[iCol_USER_ID, Grid1.RowCount - 1].Value = dbRS["USER_ID"].ToString();
                    Grid1[iCol_USER_NAME, Grid1.RowCount - 1].Value = dbRS["USER_NAME"].ToString();
                    Grid1[iCol_USER_PSWD, Grid1.RowCount - 1].Value = dbRS["USER_PSWD"].ToString();
                    Grid1[iCol_USER_PROGSTYLE, Grid1.RowCount - 1].Value = dbRS["PROGSTYLE"].ToString();
                    Grid1[iCol_CODE_NAME, Grid1.RowCount - 1].Value = dbRS["CODE_NAME"].ToString();
                }
                dbRS.Close();

            }
            clsDB.FunClsDB();
        }

        private void cmdExport_Click(object sender, EventArgs e)
        {
            clsTool.funGridToCsv(Grid1);
        }


    }

}
