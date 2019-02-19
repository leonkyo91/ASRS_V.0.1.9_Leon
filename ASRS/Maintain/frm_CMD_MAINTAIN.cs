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
    public partial class frm_CMD_MAINTAIN : Form
    {
        #region Grid1 Parameter
        int iCol_CMDSNO = 0;
        int iCol_LOCID = 1;    
        int iCol_SNO = 2;
        int iCol_CMDSTS = 3;
        int iCol_PRT = 4;
        int iCol_STNNO = 5;
        int iCol_CMDMODE = 6;
        int iCol_IOTYP = 7;
        int iCol_LOC = 8;
        int iCol_NEWLOC = 9;
            
        int iCol_TRACE = 10;
        int iCol_SCAN = 11;
        int iCol_USERID = 12;
        int iCol_TRNDATE = 13;  
        int iCol_ACTTIME = 14;
        int iCol_EXPTIME = 15;
        int iCol_ENDTIME = 16;
        int iCol_PROGID = 17;
        int iCol_Counts = 18;
        
        //int iCol_AVAIL;
        //int iCol_MIXQTY;
        //int iCol_STORAGETYP	
        #endregion

        #region Grid2 Parameter
        int iCol2_CMDSNO = 0;
        int iCol2_LOCID = 1;
        int iCol2_ITEMNO = 2;
        int iCol2_CUSTOMER = 3;
        int iCol2_DEVICE = 4;
        int iCol2_LOTNO = 5;
        int iCol2_FOSBID = 6;
        int iCol2_OFFQTY = 7;
        int iCol2_WAFERQTY = 8;
        int iCol2_SHIPQTY = 9;
        int iCol2_ACTOFFQTY = 10;
        int iCol2_ACTWAFERQTY = 11;
        int iCol2_ACTSHIPQTY = 12;
        int iCol2_Counts = 13;
        #endregion

        int iSelRow = 0;

        public frm_CMD_MAINTAIN()
        {
            InitializeComponent();
        }

        private void frm_CMD_MAINTAIN_Load(object sender, EventArgs e)
        {
            GridInit();
            FormInit();
        }

        private void GridInit()
        {
            GridSysInit(ref Grid1); GridSetRange1(ref Grid1);
            GridSysInit(ref Grid2); GridSetRange2(ref Grid2);
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

            oGrid.Columns[iCol_CMDSNO].Width = 60; oGrid.Columns[iCol_CMDSNO].Name = "命令序號";
            oGrid.Columns[iCol_LOCID].Width = 60; oGrid.Columns[iCol_LOCID].Name = "料盤編號";
            oGrid.Columns[iCol_SNO].Width = 40; oGrid.Columns[iCol_SNO].Name = "SNO";
            oGrid.Columns[iCol_CMDSTS].Width = 60; oGrid.Columns[iCol_CMDSTS].Name = "命令狀態";
            oGrid.Columns[iCol_PRT].Width = 60; oGrid.Columns[iCol_PRT].Name = "命令順序";
            oGrid.Columns[iCol_STNNO].Width = 40; oGrid.Columns[iCol_STNNO].Name = "站號";
            oGrid.Columns[iCol_CMDMODE].Width = 60; oGrid.Columns[iCol_CMDMODE].Name = "命令模式";
            oGrid.Columns[iCol_IOTYP].Width = 45; oGrid.Columns[iCol_IOTYP].Name = "作業別";
            oGrid.Columns[iCol_LOC].Width = 60; oGrid.Columns[iCol_LOC].Name = "儲位編號";
            oGrid.Columns[iCol_NEWLOC].Width = 60; oGrid.Columns[iCol_NEWLOC].Name = "新儲位";

            oGrid.Columns[iCol_TRACE].Width = 40; oGrid.Columns[iCol_TRACE].Name = "Trace";
            oGrid.Columns[iCol_SCAN].Width = 100; oGrid.Columns[iCol_SCAN].Name = "是否己刷條碼";
            oGrid.Columns[iCol_USERID].Width = 70; oGrid.Columns[iCol_USERID].Name = "使用者";
            oGrid.Columns[iCol_TRNDATE].Width = 85; oGrid.Columns[iCol_TRNDATE].Name = "命令產生日期";
            oGrid.Columns[iCol_ACTTIME].Width = 85; oGrid.Columns[iCol_ACTTIME].Name = "命令產生時間";
            oGrid.Columns[iCol_EXPTIME].Width = 65; oGrid.Columns[iCol_EXPTIME].Name = "執行時間";
            oGrid.Columns[iCol_ENDTIME].Width = 65; oGrid.Columns[iCol_ENDTIME].Name = "結束時間";
            oGrid.Columns[iCol_PROGID].Width = 65; oGrid.Columns[iCol_PROGID].Name = "程式編號";


            int i = 0;
            for (i = 0; i <= oGrid.ColumnCount - 1; i++)
            {
                oGrid.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            oGrid.RowCount = 0;
        }

        private void GridSetRange2(ref DataGridView oGrid)
        {
            oGrid.ColumnCount = iCol2_Counts;
            oGrid.RowCount = 1;
            
            oGrid.Columns[iCol2_CMDSNO].Width = 60; oGrid.Columns[iCol2_CMDSNO].Name = "命令序號";
            oGrid.Columns[iCol2_LOCID].Width = 60; oGrid.Columns[iCol2_LOCID].Name = "料盤編號";

            oGrid.Columns[iCol2_ITEMNO].Width = 70; oGrid.Columns[iCol2_ITEMNO].Name = "ITEM NO";
            oGrid.Columns[iCol2_CUSTOMER].Width = 60; oGrid.Columns[iCol2_CUSTOMER].Name = "客戶";
            oGrid.Columns[iCol2_DEVICE].Width = 70; oGrid.Columns[iCol2_DEVICE].Name = "DEVICE";
            oGrid.Columns[iCol2_LOTNO].Width = 80; oGrid.Columns[iCol2_LOTNO].Name = "LOT NO";
            oGrid.Columns[iCol2_FOSBID].Width = 70; oGrid.Columns[iCol2_FOSBID].Name = "FOSB ID";
            oGrid.Columns[iCol2_OFFQTY].Width = 50; oGrid.Columns[iCol2_OFFQTY].Name = "件數";
            oGrid.Columns[iCol2_WAFERQTY].Width = 50; oGrid.Columns[iCol2_WAFERQTY].Name = "枚數";
            oGrid.Columns[iCol2_SHIPQTY].Width = 50; oGrid.Columns[iCol2_SHIPQTY].Name = "片數";

            oGrid.Columns[iCol2_ACTOFFQTY].Width = 85; oGrid.Columns[iCol2_ACTOFFQTY].Name = "件數(預約量)";
            oGrid.Columns[iCol2_ACTWAFERQTY].Width = 85; oGrid.Columns[iCol2_ACTWAFERQTY].Name = "枚數(預約量)";
            oGrid.Columns[iCol2_ACTSHIPQTY].Width = 85; oGrid.Columns[iCol2_ACTSHIPQTY].Name = "片數(預約量)";

            int i = 0;
            for (i = 0; i <= oGrid.ColumnCount - 1; i++)
            {
                oGrid.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            oGrid.RowCount = 0;
        }

        private void FormInit()
        {
            clsASRS.SubCboSetIoType(ref cboIotype);

            FormCls();
        }

        private void FormCls()
        {
            txtCmdSno0.Text = "";
            txtCmdSno1.Text = "";
            txtLoc.Text = "";
            txtLocID.Text = "";
            txtUserID.Text = "";
            cboIotype.SelectedIndex = 0;
            Grid1.RowCount = 0;
            Grid2.RowCount = 0;
        }

        private void Grid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmdQuery_Click(object sender, EventArgs e)
        {
            SubQuery();
        }

        private void SubQuery()
        {
            string strSql = ""; DbDataReader dbRS = null;

            Grid1.RowCount = 0; Grid2.RowCount = 0;

            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };
            strSql = "SELECT * FROM CMD_MST WHERE CMDSTS <= '6' ";

            #region 查詢條件
            if (txtCmdSno0.Text != "")
            {
                if (txtCmdSno1.Text != "")
                {
                    strSql = strSql + "AND CMDSNO >= '" + txtCmdSno0.Text + "' AND CMDSNO <= '" + txtCmdSno1.Text + "' ";
                }
                else
                {
                    strSql = strSql + "AND CMDSNO = '" + txtCmdSno0.Text + "' ";
                }
            }
            if (cboIotype.Text != "")
            {
                strSql = strSql + "AND IOTYP = '" + clsTool.FunGetComineData(cboIotype.Text) + "' ";
            }
            if (txtLoc.Text != "")
            {
                strSql = strSql + "AND LOC = '" + txtLoc.Text + "' ";
            }
            if (txtLocID.Text != "")
            {
                strSql = strSql + "AND LOCID = '" + txtLocID.Text + "' ";
            }
            if (txtUserID.Text != "")
            {
                strSql = strSql + "AND USERID = '" + txtUserID.Text + "' ";
            }
            #endregion

            if (clsDB.FunRsSql(strSql, ref dbRS))
            {
                while (dbRS.Read())
                {
                    Grid1.Rows.Add();
                    Grid1[iCol_CMDSNO, Grid1.RowCount - 1].Value = dbRS["CMDSNO"].ToString();
                    Grid1[iCol_LOCID, Grid1.RowCount - 1].Value = dbRS["LOCID"].ToString();
                    Grid1[iCol_SNO, Grid1.RowCount - 1].Value = dbRS["SNO"].ToString();
                    Grid1[iCol_CMDSTS, Grid1.RowCount - 1].Value = dbRS["CMDSTS"].ToString();
                    
                    Grid1[iCol_PRT, Grid1.RowCount - 1].Value = dbRS["PRT"].ToString();
                    Grid1[iCol_STNNO, Grid1.RowCount - 1].Value = dbRS["STNNO"].ToString();
                    Grid1[iCol_CMDMODE, Grid1.RowCount - 1].Value = dbRS["CMDMODE"].ToString();
                    Grid1[iCol_IOTYP, Grid1.RowCount - 1].Value = dbRS["IOTYP"].ToString();
                    Grid1[iCol_LOC, Grid1.RowCount - 1].Value = dbRS["LOC"].ToString();
                    Grid1[iCol_NEWLOC, Grid1.RowCount - 1].Value = dbRS["NEWLOC"].ToString();
                   
                    Grid1[iCol_TRACE, Grid1.RowCount - 1].Value = dbRS["TRACE"].ToString();
                    Grid1[iCol_SCAN, Grid1.RowCount - 1].Value = dbRS["SCAN"].ToString();
                    Grid1[iCol_USERID, Grid1.RowCount - 1].Value = dbRS["USERID"].ToString();
                    Grid1[iCol_TRNDATE, Grid1.RowCount - 1].Value = dbRS["TRNDATE"].ToString();
                    Grid1[iCol_ACTTIME, Grid1.RowCount - 1].Value = dbRS["ACTTIME"].ToString();
                    Grid1[iCol_EXPTIME, Grid1.RowCount - 1].Value = dbRS["EXPTIME"].ToString();
                    Grid1[iCol_ENDTIME, Grid1.RowCount - 1].Value = dbRS["ENDTIME"].ToString();
                    Grid1[iCol_PROGID, Grid1.RowCount - 1].Value = dbRS["PROGID"].ToString();


                }
                dbRS.Close();
            }
            
            clsDB.FunClsDB();
        }



        private void cmdStart_Click(object sender, EventArgs e)
        {
            SubExecute();
        }

        private void SubExecute()
        {
            //if (iSelRow < 0) { return; }
            if (Grid1.RowCount <= 0) { return; }
            if (Grid1.CurrentRow.Index < 0) { return; }

            string sCmdSno = ""; string sLocID = ""; string sPrt = ""; string sCmdSts = ""; string sTrace = "";
            sCmdSno = Grid1[iCol_CMDSNO, Grid1.CurrentRow.Index].Value.ToString();            
            sLocID = Grid1[iCol_LOCID, Grid1.CurrentRow.Index].Value.ToString();
            sPrt = Grid1[iCol_PRT, Grid1.CurrentRow.Index].Value.ToString();
            sCmdSts = Grid1[iCol_CMDSTS, Grid1.CurrentRow.Index].Value.ToString();
            sTrace = Grid1[iCol_TRACE, Grid1.CurrentRow.Index].Value.ToString();

            if (sCmdSno == "") { clsMSG.ShowWarningMsg("請選擇命令序號!!"); return; }

            if ((RdBtn0.Checked == false) && (RdBtn1.Checked == false) && (RdBtn2.Checked == false) &&
                (RdBtn3.Checked == false) && (RdBtn4.Checked == false))
            {
                clsMSG.ShowWarningMsg("請選擇要維護的功能!!");
                return;
            }

            if (RdBtn0.Checked == true)
            {
                SubCmdHold(sCmdSno, sLocID);
            }
            else if (RdBtn1.Checked == true)
            {
                SubCmdCancel(sCmdSno, sLocID);
            }
            else if (RdBtn2.Checked == true)
            {
                SubCmdComplete(sCmdSno, sLocID);
            }
            else if (RdBtn3.Checked == true)
            {
                SubCmdPrtt(sCmdSno, sLocID, sPrt);
            }
            else if (RdBtn4.Checked == true)
            {
                SubCmdTrace(sCmdSno, sLocID, sCmdSts,sTrace);
            }


            SubQuery();
        }

        private void SubCmdHold(string sCmdSno, string sLocID)
        {
            string strSql = ""; //DbDataReader dbRS = null;
            string sMsg = "";

            sMsg = "確定將命令序號(" + sCmdSno + ") 料盤ID(" + sLocID + ") 做暫停嗎?";

            if (clsMSG.ShowQuestionMsg(sMsg) == false)
            {
                return;
            }
            
            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };


            clsDB.FunCommitCtrl("BEGIN");
            strSql = "UPDATE CMD_MST SET CMDSTS = 'H' WHERE CMDSNO = '" + sCmdSno + "' ";
            strSql = strSql + "AND LOCID = '" + sLocID + "' ";
            strSql = strSql + "AND CMDSTS <= '6' ";
            if (clsDB.FunExecSql(strSql))
            {
                clsDB.FunCommitCtrl("COMMIT");
            }
            else
            {
                clsDB.FunCommitCtrl("ROLLBACK");
                clsMSG.ShowErrMsg("命令暫停失敗!!");
            }
            clsDB.FunClsDB();


        }

        private void SubCmdCancel(string sCmdSno,string sLocID)
        {
            string strSql = ""; //DbDataReader dbRS = null;
            string sMsg = "";

            sMsg = "確定將命令序號(" + sCmdSno + ") 料盤ID(" + sLocID + ") 做命令取消嗎?";

            if (clsMSG.ShowQuestionMsg(sMsg) == false)
            {
                return;
            }

            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };

            clsDB.FunCommitCtrl("BEGIN");
            strSql = "UPDATE CMD_MST SET CMDSTS = '8' WHERE CMDSNO = '" + sCmdSno + "' ";
            strSql = strSql + "AND LOCID = '" + sLocID + "' ";
            strSql = strSql + "AND CMDSTS <= '6' ";
            if (clsDB.FunExecSql(strSql))
            {
                clsDB.FunCommitCtrl("COMMIT");
            }
            else
            {
                clsDB.FunCommitCtrl("ROLLBACK");
                clsMSG.ShowErrMsg("命令取消失敗!!");
            }
            clsDB.FunClsDB();
        }

        private void SubCmdComplete(string sCmdSno, string sLocID)
        {
            string strSql = ""; //DbDataReader dbRS = null;
            string sMsg = "";

            sMsg = "確定將命令序號(" + sCmdSno + ") 料盤ID(" + sLocID + ") 做命令強制過帳嗎?";

            if (clsMSG.ShowQuestionMsg(sMsg) == false)
            {
                return;
            }

            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };

            clsDB.FunCommitCtrl("BEGIN");
            strSql = "UPDATE CMD_MST SET CMDSTS = '7' WHERE CMDSNO = '" + sCmdSno + "' ";
            strSql = strSql + "AND LOCID = '" + sLocID + "' ";
            strSql = strSql + "AND CMDSTS <= '6' ";
            if (clsDB.FunExecSql(strSql))
            {
                clsDB.FunCommitCtrl("COMMIT");
            }
            else
            {
                clsDB.FunCommitCtrl("ROLLBACK");
                clsMSG.ShowErrMsg("命令完成失敗!!");
            }
            clsDB.FunClsDB();


        }

        private void SubCmdPrtt(string sCmdSno, string sLocID,string sPrt)
        {
            clsASRS.gsHelpStyle_Data = sCmdSno + "," + sLocID + "," + sPrt;

            frmHelp_PRT frmHelp = new frmHelp_PRT();
            frmHelp.ShowDialog();
            SubQuery();
        }

        private void SubCmdTrace(string sCmdSno, string sLocID, string sCmdSts,string sTrace)
        {
            clsASRS.gsHelpStyle_Data = sCmdSno + "," + sLocID + "," + sCmdSts + "," + sTrace;
            
            frmHelp_CmdTrace frmHelp = new frmHelp_CmdTrace();
            frmHelp.ShowDialog();
            SubQuery();
        }



        private void cmdClear_Click(object sender, EventArgs e)
        {
            FormCls();
        }

        private void cmdEnd_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Grid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            iSelRow = e.RowIndex;
            Grid2.RowCount = 0;    
        
            if (e.RowIndex < 0) { return; }

            if (Grid1[iCol_CMDSNO, e.RowIndex].Value.ToString() == "") { return; }

            string sCmdSno = ""; string sLocID = "";
            sCmdSno = Grid1[iCol_CMDSNO, e.RowIndex].Value.ToString();
            sLocID = Grid1[iCol_LOCID, e.RowIndex].Value.ToString();

            SubQuery_CmdDtl(sCmdSno, sLocID);
        }

        private void SubQuery_CmdDtl(string sCmdSno, string sLocID)
        {
            string strSql = ""; DbDataReader dbRS = null;
            if (clsDB.FunOpenDB() == false) { clsMSG.ShowErrMsg(clsMSG.MSG.OPEN_DB_NG); return; };
            
            strSql = "SELECT * FROM CMD_DTL WHERE CMDSNO = '" + sCmdSno + "' AND LOCID = '" + sLocID + "' ";
            if (clsDB.FunRsSql(strSql, ref dbRS))
            {
                while (dbRS.Read())
                {
                    Grid2.Rows.Add();
                    Grid2[iCol2_CMDSNO, Grid2.RowCount - 1].Value = dbRS["CMDSNO"].ToString();
                    Grid2[iCol2_LOCID, Grid2.RowCount - 1].Value = dbRS["LOCID"].ToString();
                    Grid2[iCol2_ITEMNO, Grid2.RowCount - 1].Value = dbRS["ITEMNO"].ToString();
                    Grid2[iCol2_CUSTOMER, Grid2.RowCount - 1].Value = dbRS["CUSTOMER"].ToString();
                    Grid2[iCol2_DEVICE, Grid2.RowCount - 1].Value = dbRS["DEVICE"].ToString();

                    Grid2[iCol2_LOTNO, Grid2.RowCount - 1].Value = dbRS["LOTNO"].ToString();
                    Grid2[iCol2_FOSBID, Grid2.RowCount - 1].Value = dbRS["FOSBID"].ToString();
                    Grid2[iCol2_OFFQTY, Grid2.RowCount - 1].Value = dbRS["OFFQTY"].ToString();
                    Grid2[iCol2_WAFERQTY, Grid2.RowCount - 1].Value = dbRS["WAFERQTY"].ToString();
                    Grid2[iCol2_SHIPQTY, Grid2.RowCount - 1].Value = dbRS["SHIPQTY"].ToString();

                    Grid2[iCol2_ACTOFFQTY, Grid2.RowCount - 1].Value = dbRS["OFFACTQTY"].ToString();
                    Grid2[iCol2_ACTWAFERQTY, Grid2.RowCount - 1].Value = dbRS["WAFERACTQTY"].ToString();
                    Grid2[iCol2_ACTSHIPQTY, Grid2.RowCount - 1].Value = dbRS["SHIPACTQTY"].ToString();
                }
                dbRS.Close();
            }

            clsDB.FunClsDB();

        }









    }
}

