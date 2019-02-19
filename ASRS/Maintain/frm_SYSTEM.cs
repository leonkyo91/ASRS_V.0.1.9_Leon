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
    public partial class frm_SYSTEM : Form
    {
        public frm_SYSTEM()
        {
            InitializeComponent();
        }

        private void frm_SYSTEM_Load(object sender, EventArgs e)
        {
            GridInit();
            FormInit();
            this.WindowState = FormWindowState.Maximized;
        }

        private void frm_SYSTEM_Resize(object sender, EventArgs e)
        {
            //gpb1.Width = this.Width - 40;
            //Grid1.Width = gpb1.Width - 10;
        }

        //Form Initial
        private void FormInit()
        {
            clsASRS.SubCboSetType(ref cboType); //代碼
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
                clsMSG.ShowWarningMsg(clsMSG.MSG.SYSTEM_NG  + " " + ex.ToString());
            }

        }

        private void GridSetRange1(ref DataGridView oGrid)
        {
            oGrid.ColumnCount = 3;
            oGrid.RowCount = 1;

            oGrid.Columns[0].Width = 100; oGrid.Columns[0].Name = "代碼類型"; oGrid.Columns[0].Visible = false;
            oGrid.Columns[1].Width = 200; oGrid.Columns[1].Name = "代碼編號";
            oGrid.Columns[2].Width = 300; oGrid.Columns[2].Name = "代碼名稱";


            int i = 0;
            for (i = 0; i <= oGrid.ColumnCount - 1; i++)
            {
                oGrid.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void GridSetRange2(ref DataGridView oGrid)
        {
            oGrid.ColumnCount = 3;
            oGrid.RowCount = 1;

            oGrid.Columns[0].Width = 100; oGrid.Columns[0].Name = "代碼類型"; oGrid.Columns[0].Visible = false;
            oGrid.Columns[1].Width = 200; oGrid.Columns[1].Name = "代碼編號";
            oGrid.Columns[2].Width = 300; oGrid.Columns[2].Name = "代碼名稱"; oGrid.Columns[2].Visible = false;


            int i = 0;
            for (i = 0; i <= oGrid.ColumnCount - 1; i++)
            {
                oGrid.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void GridInit()
        {
            GridSysInit(ref Grid1);
            GridSetRange1(ref Grid1);
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SubQuery();
        }

        private void cboType_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void SubQuery()
        {
            txtTypeNo.Text = "";
            txtTypeName.Text = "";

            switch (cboType.Text)
            {
                case "權限等級":
                    GridSetRange1(ref Grid1);
                    lblTypeName.Visible = true;
                    txtTypeName.Visible = true;
                    break;
                case "單位":
                    GridSetRange2(ref Grid1);
                    lblTypeName.Visible = false;
                    txtTypeName.Visible = false;
                    break;
                case "限制區域":
                    GridSetRange2(ref Grid1);
                    lblTypeName.Visible = false;
                    txtTypeName.Visible = false;
                    break;
                default:
                    break;
            }
            Grid1.RowCount = 0;

            Query();

        }

        private void Grid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }
            txtTypeNo.Text = Grid1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtOldTypeNo.Text = txtTypeNo.Text;
            txtTypeName.Text = Grid1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }
        
        private void Grid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            SubAdd();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SubUpdate();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            SubDel();
        }




        private void Query()
        {
            string strSql = ""; DbDataReader dbRS = null;

            Grid1.RowCount = 0;

            if ((cboType.Text) == "") { return; };

            try
            {
                if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };    //資料庫開啓失敗

                this.Cursor = Cursors.WaitCursor;

                strSql = "SELECT * FROM CODE_DTL ";
                switch (cboType.Text)
                {
                    case "權限等級":
                        strSql = strSql + "WHERE CODE_TYPE = 'PRIVILEGE' ";
                        break;

                    case "單位":
                        strSql = strSql + "WHERE CODE_TYPE = 'UNIT' ";
                        break;

                    case "限制區域":
                        strSql = strSql + "WHERE CODE_TYPE = 'GROUP' ";
                        break;
                    
                    default:
                        strSql = strSql + "WHERE CODE_TYPE = '' ";
                        break;

                }


                if (clsDB.FunRsSql(strSql, ref dbRS))
                {
                    while (dbRS.Read())
                    {
                        Grid1.Rows.Add();

                        Grid1[0, Grid1.Rows.Count - 1].Value = dbRS["CODE_TYPE"].ToString();
                        Grid1[1, Grid1.Rows.Count - 1].Value = dbRS["CODE_NO"].ToString();
                        Grid1[2, Grid1.Rows.Count - 1].Value = dbRS["CODE_NAME"].ToString();
                    }

                    dbRS.Close();
                }

                clsDB.FunClsDB();

                this.Cursor = Cursors.Default;
            }
            catch
            {
                clsDB.FunClsDB();
                this.Cursor = Cursors.Default;
                clsMSG.ShowErrMsg(clsMSG.MSG.SYSTEM_NG);    //系統錯誤!!
            }

        }

        private void SubAdd()
        {
            string strSql = ""; DbDataReader dbRS = null;
            string strType = "";

            //防呆
            txtTypeNo.Text = txtTypeNo.Text.Trim().ToUpper();
            txtTypeName.Text = txtTypeName.Text.Trim();

            if (cboType.Text == "")
            {
                clsMSG.ShowWarningMsg("請選擇代碼類型!!");
                return;
            }
            if (txtTypeNo.Text == "")
            {
                clsMSG.ShowWarningMsg("請輸入代碼編號!!");
                return;
            }

            switch (cboType.Text)
            {
                case "權限等級":
                    strType = "PRIVILEGE";
                    break;
                case "單位":
                    strType = "UNIT";
                    break;
                case "限制區域":
                    strType = "GROUP";
                    break;
                default:
                    return;
            }

            bool bFlag = false;

            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };

            try
            {
                bool bHadData = false;
                strSql = "SELECT COUNT(*) FROM CODE_DTL ";
                strSql = strSql + "WHERE CODE_TYPE = '" + strType + "' ";
                strSql = strSql + "AND CODE_NO = '" + txtTypeNo.Text + "' ";
                if (clsDB.FunRsSql(strSql,ref  dbRS) == true)
                {
                    while (dbRS.Read())
                    {
                        if (clsTool.INT(dbRS[0].ToString()) > 0)
                        {
                            bHadData = true;
                        }
                    }
                    dbRS.Close(); 
                }

                if (bHadData == true)
                {
                    clsMSG.ShowWarningMsg("代碼資料重覆!!");
                    clsDB.FunClsDB();
                    return;
                }

                strSql = "INSERT INTO CODE_DTL (CODE_TYPE,CODE_NO,CODE_NAME,CODE_NOTES) VALUES (";
                strSql = strSql + "'" + strType + "',";
                strSql = strSql + "'" + txtTypeNo.Text + "',";
                strSql = strSql + "'" + txtTypeName.Text + "',";
                strSql = strSql + "' ')";
                if (clsDB.FunExecSql(strSql) == true)
                {
                    bFlag = true;
                }

                if (bFlag == true)
                {
                    SubClear();
                    Query();                    
                    clsMSG.ShowInformationMsg(clsMSG.MSG.ADD_OK);
                }
                else
                { 
                    clsMSG.ShowErrMsg(clsMSG.MSG.SET_NG);
                }

                clsDB.FunClsDB();   
            }
            catch
            {
                bFlag = false;
                clsDB.FunClsDB();   
                clsMSG.ShowErrMsg(clsMSG.MSG.SET_NG);
            }

        
        }
        
        private void SubUpdate()
        {
            string strSql = ""; DbDataReader dbRS = null;
            string strType = "";
            if (cboType.Text == "")
            {
                clsMSG.ShowWarningMsg("請選擇代碼類型!!");
                return;
            }
            if (txtTypeNo.Text == "")
            {
                clsMSG.ShowWarningMsg("請輸入代碼編號!!");
                return;
            }

            switch (cboType.Text)
            {
                case "權限等級":
                    strType = "PRIVILEGE";
                    break;
                case "單位":
                    strType = "UNIT";
                    break;
                case "限制區域":
                    strType = "GROUP";
                    break;
                default:
                    return;
            }

            //DialogResult result = MessageBox.Show("是否確認修改", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            bool result = clsMSG.ShowQuestionMsg("是否確認修改");
            if (result == false)
            {
                return;
            }

            bool bFlag = false;

            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };

            try
            {
                bool bHadData = false;
                strSql = "SELECT COUNT(*) FROM CODE_DTL ";
                strSql = strSql + "WHERE CODE_TYPE = '" + strType + "' ";
                strSql = strSql + "AND CODE_NO = '" + txtOldTypeNo.Text + "' ";
                if (clsDB.FunRsSql(strSql, ref  dbRS) == true)
                {
                    while (dbRS.Read())
                    {
                        if (clsTool.INT(dbRS[0].ToString()) > 0)
                        {
                            bHadData = true;
                        }
                    }
                    dbRS.Close();
                }

                if (bHadData == false)
                {
                    clsMSG.ShowWarningMsg("代碼資料不存在!!");
                    clsDB.FunClsDB();
                    return;
                }



                //strSql = "UPDATE CODE_DTL ";
                //strSql = strSql + "SET CODE_NAME = '" + txtTypeName.Text + "' ";
                //strSql = strSql + "WHERE CODE_TYPE = '" + strType + "' ";
                //strSql = strSql + "AND CODE_NO = '" + txtTypeNo.Text + "' ";

                clsDB.FunCommitCtrl("BEGIN");

                strSql = "DELETE FROM CODE_DTL ";
                strSql = strSql + "WHERE CODE_TYPE = '" + strType + "' ";
                strSql = strSql + "AND CODE_NO = '" + txtOldTypeNo.Text + "' ";
                if (clsDB.FunExecSql(strSql) == true)
                {
                    strSql = "INSERT INTO CODE_DTL (CODE_TYPE,CODE_NO,CODE_NAME,CODE_NOTES) VALUES (";
                    strSql = strSql + "'" + strType + "',";
                    strSql = strSql + "'" + txtTypeNo.Text + "',";
                    strSql = strSql + "'" + txtTypeName.Text + "',";
                    strSql = strSql + "' ')";
                    if (clsDB.FunExecSql(strSql) == true)
                    {
                        bFlag = true;
                    }
                }

                if (bFlag == true)
                {
                    clsDB.FunCommitCtrl("COMMIT");
                    SubClear();
                    Query();
                    clsMSG.ShowInformationMsg(clsMSG.MSG.UPDATE_OK);
                }
                else
                {
                    clsDB.FunCommitCtrl("ROLLBACK");
                    clsMSG.ShowErrMsg(clsMSG.MSG.SET_NG);
                }

                clsDB.FunClsDB();
            }
            catch
            {
                bFlag = false;
                clsDB.FunClsDB();
                clsMSG.ShowErrMsg(clsMSG.MSG.SET_NG);
            }


        }

        private void SubDel()
        {
            string strSql = ""; DbDataReader dbRS = null;
            string strType = "";
            if (cboType.Text == "")
            {
                clsMSG.ShowWarningMsg("請選擇代碼類型!!");
                return;
            }
            if (txtTypeNo.Text == "")
            {
                clsMSG.ShowWarningMsg("請輸入代碼編號!!");
                return;
            }

            switch (cboType.Text)
            {
                case "權限等級":
                    strType = "PRIVILEGE";
                    break;
                case "單位":
                    strType = "UNIT";
                    break;
                case "限制區域":
                    strType = "GROUP";
                    break;
                default:
                    return;
            }

            //DialogResult result = MessageBox.Show("是否確認刪除", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
           bool result = clsMSG.ShowQuestionMsg("是否確認刪除");
            if (result ==false)
            {
                return;
            }

            bool bFlag = false;

            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };

            try
            {
                bool bHadData = false;
                strSql = "SELECT COUNT(*) FROM CODE_DTL ";
                strSql = strSql + "WHERE CODE_TYPE = '" + strType + "' ";
                strSql = strSql + "AND CODE_NO = '" + txtTypeNo.Text + "' ";
                if (clsDB.FunRsSql(strSql, ref  dbRS) == true)
                {
                    while (dbRS.Read())
                    {
                        if (clsTool.INT(dbRS[0].ToString()) > 0)
                        {
                            bHadData = true;
                        }
                    }
                    dbRS.Close();
                }

                if (bHadData == false)
                {
                    clsMSG.ShowWarningMsg("代碼資料不存在!!");
                    clsDB.FunClsDB();
                    return;
                }

                strSql = "DELETE FROM CODE_DTL ";
                strSql = strSql + "WHERE CODE_TYPE = '" + strType + "' ";
                strSql = strSql + "AND CODE_NO = '" + txtTypeNo.Text + "' ";
                if (clsDB.FunExecSql(strSql) == true)
                {
                    bFlag = true;
                }

                if (bFlag == true)
                {
                    SubClear();
                    Query();
                    clsMSG.ShowInformationMsg(clsMSG.MSG.DELETE_OK);
                }
                else
                {
                    clsMSG.ShowErrMsg(clsMSG.MSG.SET_NG);
                }

                clsDB.FunClsDB();
            }
            catch
            {
                bFlag = false;
                clsDB.FunClsDB();
                clsMSG.ShowErrMsg(clsMSG.MSG.SET_NG);
            }


        }

        private void SubClear()
        {
            txtTypeNo.Text = "";
            txtTypeName.Text = "";
            Grid1.RowCount = 0;
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }








    }
}
