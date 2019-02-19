//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Windows.Forms;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.Common;


namespace ASRS
{
    class clsTool
    {
        public static System.Drawing.Color gsColor_Sel = System.Drawing.Color.Orange; //SPIL //System.Drawing.Color.Moccasin;
        public static System.Drawing.Color gsColor_BackColor = System.Drawing.Color.White;
        public static System.Drawing.Color gsColor_Light = System.Drawing.Color.LightSalmon;
        public static System.Drawing.Color gsColor_MustInput = System.Drawing.Color.Gold;   //SPIL

        public static void SetFocus(TextBox txtObj)
        {
            txtObj.SelectAll();
            txtObj.Focus();
        }



        #region FunGetComineData()
        public static string FunGetComineData(string sValue)
        {
            int iPos = 0;
            iPos = sValue.IndexOf(":",0);

            string sData = "";
            if (iPos >= 0 )
            {
                sData = sValue.Substring(0,iPos);
            }
            else
            {
                sData= sValue;
            }

            return sData;
        }
        #endregion


        #region FunGetComineData2()
        public static string FunGetComineData2(string sValue)
        {
            int iPos = 0;
            iPos = sValue.IndexOf(":", 0);

            string sData = "";
            if (iPos >= 0)
            {
                sData = sValue.Substring(iPos + 1, (sValue.Length - 1) - iPos);
            }
            else
            {
                sData = sValue;
            }

            return sData;
        }
        #endregion


        #region INT() 字串轉換為數字
        public static int INT(string sData)
        {
            int iValue = 0;
            double dValue = 0;
            string sValue = "";
            int n;

            try
            {
                if (int.TryParse(sData, out n))
                {
                    iValue = int.Parse(sData);    // 取數值
                }
                else
                {
                    double n1;
                    if (double.TryParse(sData, out n1))
                    {
                        dValue = double.Parse(sData);     // 取Double                    
                        //dValue = Math.Floor(dValue + 0.5);  // 四捨五入
                        dValue = Math.Floor(dValue);  // 無條件捨去
                        sValue = dValue.ToString();         // 轉字串
                        if (int.TryParse(sValue, out n))
                        {
                            iValue = int.Parse(sValue);     // 取整數
                        }
                        else
                        {
                            iValue = 0;
                        }
                    }
                    else
                    {
                        iValue = 0;
                    }
                }

            }
            catch
            {

            }
            return iValue;
        }
        #endregion

        #region DateDiff_Day 取得與今天日期的時間差
        public static string DateDiff_Day(string sDate)
        {
            //入庫日期 – 今天日期
            //Ex: (2012-05-06) – (2012-05-23) = -7
            try
            {
                DateTime DateTime1 = Convert.ToDateTime(sDate);
                string dateDiff = null;

                TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
                TimeSpan ts2 = new TimeSpan(System.DateTime.Now.Ticks);
                TimeSpan ts = ts1.Subtract(ts2).Duration();
                dateDiff = ts.Days.ToString();
                return dateDiff;
            }
            catch
            {
                return "0";
            }
        }
        #endregion

        public static int DateDiff_Seconds(string sDate)
        {
            //時間1 – 時間2
            //Ex: (2013-01-01 00:00:00) – (2013-01-01 00:01:00) = -60
            try
            {
                DateTime DateTime1 = Convert.ToDateTime(sDate);
                int dateDiff = 0;

                TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
                TimeSpan ts2 = new TimeSpan(System.DateTime.Now.Ticks);
                TimeSpan ts = ts2.Subtract(ts1).Duration();
                dateDiff = ts.Seconds;
                return dateDiff;
            }
            catch
            {
                return 0;
            }
        }

        #region GetDateTime() 取得今天的日期時間 本端電腦時間
        public static string GetDateTime()
        {
            return System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        }
        #endregion


        #region GetDateTimeForWMS() 取得今天的日期時間 本端電腦時間
        public static string GetDateTimeForWMS()
        {
            return System.DateTime.Now.ToString("yyyyMMddHHmmss");
        }
        #endregion

        #region GetDate() 取得今天的日期時間 本端電腦時間
        public static string GetDate()
        {
            return System.DateTime.Now.ToString("yyyy/MM/dd");
        }
        #endregion

        #region GetTime() 取得今天的日期時間 本端電腦時間
        public static string GetTime()
        {
            return System.DateTime.Now.ToString("HH:mm:ss");
        }
        #endregion

        #region SetHiLightColor() 設定 Hi-Light 顏色 (紅色)
        public static void SetSelColor(ref DataGridView objGrid, int iRow)
        {
            for (int k = 0; k <= objGrid.ColumnCount - 1; k++)
            {
                objGrid.Rows[iRow].Cells[k].Style.BackColor = gsColor_Light;
            }
        }
        #endregion

        #region SetGridSeletRowColorHead() 設定 Hi-Light 顏色 (SPIL)
        public static void SetGridSeletRowColorHead(ref DataGridView objGrid, bool bSel, int iRow)
        {
            int x = 0;
            if (bSel == true)
            {
                objGrid.Rows[iRow].HeaderCell.Value = "*";
                for (x = 0; x <= objGrid.ColumnCount - 1; x++)
                {
                    objGrid.Rows[iRow].Cells[x].Style.BackColor = gsColor_Sel;
                }
            }
            else
            {
                objGrid.Rows[iRow].HeaderCell.Value = "";
                for (x = 0; x <= objGrid.ColumnCount - 1; x++)
                {
                    objGrid.Rows[iRow].Cells[x].Style.BackColor = gsColor_BackColor;
                }
            }
        }
        #endregion





        //==============================================================================
        // 補足或截止完整字元
        //==============================================================================
        public static string FunConvert2Str(string strTxt, int intLimitLen )
        {
            try
            {                
                int iLen = 0;
                //int intIndex = 0;
                int i = 0;
                int iLen1 = 0;
                string sValue = "";
                iLen = System.Text.Encoding.GetEncoding("BIG5").GetBytes(strTxt).Length;
                //iLen = strTxt.Length;

                if (iLen == intLimitLen)
                {
                    return strTxt;
                }
                else if (iLen > intLimitLen)
                {
                    // 截掉超過部份 V2
                    for (int x = 0; x < strTxt.Length; x++)
                    {
                        iLen1 = strTxt.Length;
                        strTxt = strTxt.Substring(0, iLen1 - x);                        
                        iLen = System.Text.Encoding.GetEncoding("BIG5").GetBytes(strTxt).Length;
                        //iLen = strTxt.Length;
                        if (iLen <= intLimitLen)
                        {
                            break;
                        }
                    }

                    // 補空白
                    sValue = strTxt;
                    for (i = 0; i < intLimitLen; i++)
                    {
                        iLen = System.Text.Encoding.GetEncoding("BIG5").GetBytes(strTxt).Length;
                        //iLen = strTxt.Length;
                        if (iLen == intLimitLen)
                        {
                            sValue = strTxt;
                            break;
                        }
                        else if (iLen < intLimitLen)
                        {
                            strTxt = strTxt + " ";
                        }
                    }

                    return sValue;
                }
                else if (iLen < intLimitLen)
                {
                    iLen = System.Text.Encoding.GetEncoding("BIG5").GetBytes(strTxt).Length;
                    //iLen = strTxt.Length;

                    //        '補空白
                    sValue = strTxt;
                    for (i = 0; i < intLimitLen; i++)
                    {
                        iLen = System.Text.Encoding.GetEncoding("BIG5").GetBytes(strTxt).Length;
                        //iLen = strTxt.Length;
                        if (iLen == intLimitLen)
                        {
                            sValue = strTxt;
                            break;
                        }
                        else if (iLen < intLimitLen)
                        {
                            strTxt = strTxt + " ";
                            sValue = strTxt;
                        }
                    }

                    return sValue;
                }
            }
            catch (Exception ex)
            {

                return "";
            }

            return "";
        }


        #region 清除form包含的textbox及combobox的text屬性及checkBox的checked屬性
        public static void finished(Form form)
        {

            for (int x = 0; x != form.Controls.Count; x++)
            {

                switch (form.Controls[x].GetType().FullName)
                {
                    case "System.Windows.Forms.GroupBox":
                        groupboxClear((GroupBox)form.Controls[x]);
                        break;
                    case "System.Windows.Forms.TextBox":
                        form.Controls[x].Text = "";
                        break;
                    case "System.Windows.Forms.ComboBox":
                        form.Controls[x].Text = "";
                        break;
                    case "System.Windows.Forms.CheckBox":
                        CheckBox chk1 = (CheckBox)form.Controls[x];
                        chk1.Checked = false;
                        break;
                    default:
                        break;
                }

            }
          //  MessageBox.Show("處理成功");
        }
        private static void groupboxClear(GroupBox gb)
        {
            for (int x = 0; x != gb.Controls.Count; x++)
            {

                switch (gb.Controls[x].GetType().FullName)
                {
                    case "System.Windows.Forms.GroupBox":
                        GroupBox gb1 = (GroupBox)gb.Controls[x];
                        groupboxClear(gb1);
                        break;
                    case "System.Windows.Forms.TextBox":
                        gb.Controls[x].Text = "";
                        break;
                    case "System.Windows.Forms.ComboBox":
                        gb.Controls[x].Text = "";
                        break;
                    case "System.Windows.Forms.CheckBox":
                        CheckBox chk1 = (CheckBox)gb.Controls[x];
                        chk1.Checked = false;
                        break;
                    default:
                        break;
                }
            }
        }
        #endregion

        #region 匯出grid資料
        public static bool funGridToCsv( DataGridView Grd, String strErrMsg = "")
        {
            try
            {
                string sLine = "";
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "csv files (*.csv)|*.csv|txt files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.RestoreDirectory = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter straWrite = new StreamWriter(saveFileDialog1.OpenFile(), System.Text.Encoding.GetEncoding("Big5"));

                    //Header資料
                    for (int iCol = 0; iCol != Grd.ColumnCount; iCol++)
                    {
                        if (iCol != 0) sLine = sLine + ",";
                        sLine = sLine + Grd.Columns[iCol].HeaderText;
                    }
                    straWrite.WriteLine(sLine);

                    //匯出資料

                    for (int iRow = 0; iRow != Grd.RowCount; iRow++)
                    {
                        sLine = "";
                        for (int iCol = 0; iCol != Grd.ColumnCount; iCol++)
                        {
                         
                            sLine = sLine + (Grd[iCol,iRow].Value==null?"":Grd[iCol, iRow].Value.ToString()) + ",";
                        }
                        straWrite.WriteLine(sLine);
                    }

                    straWrite.Close();
                    straWrite.Dispose();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                strErrMsg = ex.Message;
                return false;
            }
        }
        #endregion

        #region showForm
        public static TextBox TB1=new TextBox();
        //public static Form f1 = new Form();
        public static void CellDoubleClick(object sender, DataGridViewCellEventArgs e) 
        {
            DataGridView dgv=(DataGridView)sender;
            TB1.Text = dgv[e.ColumnIndex, e.RowIndex].Value.ToString();
            Form f1 = (Form)dgv.Parent;
            f1.Close();
        }

        public static void showForm(TextBox tb,string item,string tableName)
        {

            TB1 = tb;
            Form f1 = new Form();
           
            string strSql = "select distinct "+item+" from "+tableName;
            clsDB.FunOpenDB();
            DbDataReader dbrs = null;
            if (!clsDB.FunRsSql(strSql, ref dbrs))
            {
                //return;
                DataGridView dgv = new DataGridView();
                dgv.ColumnCount = 1;
                dgv.Columns[0].HeaderText = item;
                dgv.Dock = System.Windows.Forms.DockStyle.Fill;
                
                dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(CellDoubleClick);

                f1.Controls.Add(dgv);
                f1.Size = new System.Drawing.Size(100, 300);
                f1.Show();
            }
            else
            {
                DataGridView dgv = new DataGridView();
                dgv.ColumnCount = 1;
                dgv.Columns[0].HeaderText = item;
                dgv.Dock = System.Windows.Forms.DockStyle.Fill;
                int X = 0;
                while (dbrs.Read())
                {
                    dgv.Rows.Add();
                    dgv[0, X].Value = dbrs[item].ToString();
                    X++;
                }

                dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(CellDoubleClick);

                f1.Controls.Add(dgv);
                dbrs.Close();   //Close
                f1.Size = new System.Drawing.Size(100, 300);
                f1.Show();
            }
        }
      
     
        #endregion



        //public static bool FunCheckFormIsShow(string sForm)
        //{
        //    string sFormName = "";
        //    #region
        //    switch (sForm)
        //    {
        //        #region 設定作業
        //        case "AWP010":
        //            sFormName = "frm_ASRS_EMPTY_IN"; break;
        //        case "AWP020":
        //            sFormName = "frm_ASRS_EMPTY_OUT"; break;
        //        case "AWP030":
        //            sFormName = "frm_RackToRack"; break;
        //        case "AWP090":
        //            sFormName = "frm_ASRS_OFFLINE_IN"; break;
        //        case "AWP100":
        //            sFormName = "frm_ASRS_OFFLINE_OUT"; break;
        //        case "AWP120":
        //            sFormName = "frm_ASRS_STK_OUT"; break;
        //        case "AWP130":
        //            sFormName = "frm_WMS_STK_IN"; break;
        //        case "AWP140":
        //            sFormName = "frm_WMS_STK_OUT"; break;
        //        case "AWP150":
        //            sFormName = "frm_WMS_CYCLE"; break;
        //        case "AWP160":
        //            sFormName = "frm_WMS_IQC"; break;
        //        #endregion

        //        #region 查詢作業
        //        case "AWQ010":
        //            sFormName = "frm_LOC_STS"; break;
        //        case "AWQ020":
        //            sFormName = "frm_LOC_DTL"; break;
        //        case "AWQ030":
        //            sFormName = "frm_STOCK"; break;
        //        case "AWQ040":
        //            sFormName = "frm_CMD"; break;
        //        case "AWQ050":
        //            sFormName = "frm_CMD_STN"; break;
        //        case "AWQ060":
        //            sFormName = "frm_ASRS_LOG"; break;
        //        case "AWQ070":
        //            sFormName = "frm_OFFLINE_DATA"; break;
        //        case "AWQ080":
        //            sFormName = "frm_STOCK_OFFLINE"; break;
        //        case "AWQ090":
        //            sFormName = "frm_IQC_DATA"; break;
        //        case "AWQ100":
        //            break;
        //        #endregion

        //        #region 盤點作業
        //        case "AWC010":
        //            sFormName = "frm_LOC_CYCLE"; break;
        //        case "AWC020":
        //            sFormName = "frm_ITEM_CYCLE"; break;
        //        case "AWC030":
        //            sFormName = "frm_CYCLE"; break;
        //        case "AWC040":
        //            sFormName = "frm_CYCLE_CHECK"; break;
        //        case "AWC060":
        //            sFormName = "frm_CYCLE_REPORT"; break;
        //        case "AWC070":
        //            sFormName = "frm_CYCLE_REPORT2"; break;
        //        #endregion

        //        #region 維護作業
        //        case "AWM010":
        //            sFormName = "frm_LOC_MAINTAIN"; break;
        //        case "AWM020":
        //            sFormName = "frm_LOC_STS_MAINTAIN"; break;
        //        case "AWM030":
        //            sFormName = "frm_CMD_MAINTAIN"; break;
        //        case "AWM040":
        //            sFormName = "frm_USER"; break;
        //        case "AWM050":
        //            sFormName = "frm_AUTHORITY"; break;
        //        case "AWM060":
        //            sFormName = "frm_LOC_STYLE"; break;
        //        case "AWM070":
        //            sFormName = "frm_WMS_LOC_MAPPING"; break;
        //        case "AWM080":
        //            break;
        //        #endregion
        //    }

        //    foreach (Form f in this.MdiChildren)
        //    {
        //        if (f.Name == sFormName)
        //        {
        //            f.Visible = true;
        //            f.Activate();
        //            f.WindowState = FormWindowState.Maximized;
        //            f.Focus();
        //            return;
        //        }
        //    }
        //    #endregion
        //}



    }
}
