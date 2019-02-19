using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace ASRS
{
    class clsPrinter
    {
        public int iline = 0;　　 //存放当前要打印行的行号 
        public int printingPageNo = 0; //當前列印的頁號

        public static string[] aPrintData = new string[1];
        public static string[] aPrintDataHeader = new string[1];

        public static int iLineAdd = 0; //Speical

        public bool PrintDoc()
        {
            try
            {
                ////獲取需要列印的內容


                //initial
                iline = 0; printingPageNo = 0;

                //打印预览，调试的时候，可以通过这个，节约纸张
                PrintPreviewDialog ppd = new PrintPreviewDialog();
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
                ppd.Document = pd;
                ppd.Height = 800; ppd.Width = 1000;
                ppd.ShowDialog();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return false;
            }

        }

        //列印格式內容
        private void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            string strLine;//用於存放當前行列印的資訊　　　　　　 
            float leftMargin = (e.MarginBounds.Left) * 3 / 4;　 //左邊距
            float topMargin = e.MarginBounds.Top * 2 / 3;　　　 //頂邊距
            float verticalPosition = topMargin;　　　　　　　　 //初始化垂直位置，設為頂邊距
            bool bPageClose = false;

            Font mainFont = new Font("Courier New", 10);//列印的字體

            //每頁的行數，當列印行數超過這個時，要換頁(1.05這個值是根據實際情況中設定的，可以不要) 
            //int linesPerPage = (int)(e.MarginBounds.Height * 1.05 / mainFont.GetHeight(e.Graphics));
            int linesPerPage = (int)(e.MarginBounds.Height * 0.88 / mainFont.GetHeight(e.Graphics));
            int iCount = 0;     //行數

            while (iCount < linesPerPage)
            {
                if (iCount == 0)
                {
                    #region 抬頭內容
                    mainFont = new Font("Courier New", 12, FontStyle.Bold);
                    for (int ii = 0; ii <= aPrintDataHeader.Length - 1; ii++)
                    {
                        strLine = aPrintDataHeader[ii];
                        e.Graphics.DrawString(strLine, mainFont, Brushes.Black, leftMargin, verticalPosition, new StringFormat());
                        verticalPosition = verticalPosition + mainFont.GetHeight(e.Graphics);
                    }

                    //打印一条横线　 
                    mainFont = new Font("Courier New", 3);
                    e.Graphics.DrawLine(new Pen(Color.Black), leftMargin, verticalPosition, e.MarginBounds.Right + iLineAdd, verticalPosition);
                    verticalPosition = verticalPosition + mainFont.GetHeight(e.Graphics);
                    #endregion
                }
                else
                {
                    if (iline <= aPrintData.Length - 1)
                    {
                        mainFont = new Font("Courier New", 12, FontStyle.Bold);
                        strLine = aPrintData[iline];
                        e.Graphics.DrawString(strLine, mainFont, Brushes.Black, leftMargin, verticalPosition, new StringFormat());
                        verticalPosition = verticalPosition + mainFont.GetHeight(e.Graphics);
                        iline = iline + 1;
                    }
                    else
                    {
                        mainFont = new Font("Courier New", 12, FontStyle.Bold);
                        strLine = "  ";
                        strLine = "  ";
                        strLine = "                                page. " + (printingPageNo+1).ToString() + " ";
                        e.Graphics.DrawString(strLine, mainFont, Brushes.Black, leftMargin, verticalPosition, new StringFormat());
                        verticalPosition = verticalPosition + mainFont.GetHeight(e.Graphics);
                        bPageClose = true;
                        break;
                    }
                }
                iCount = iCount + 1;
            }

            printingPageNo++; //頁號加一

            if (bPageClose == false)
            {
                mainFont = new Font("Courier New", 12, FontStyle.Bold);
                strLine = "  ";
                strLine = "  ";
                strLine = "                                page. " + printingPageNo.ToString() + " ";
                e.Graphics.DrawString(strLine, mainFont, Brushes.Black, leftMargin, verticalPosition, new StringFormat());
                verticalPosition = verticalPosition + mainFont.GetHeight(e.Graphics);

                e.HasMorePages = true;
            }
            else
            {
                //結束
                e.HasMorePages = false;
                iline = 0; printingPageNo = 0;
            }




            #region Remark
            //if (printingPageNo == 0) //列印第一頁時，需要列印以下頭資訊
            //{

            //}
            //else
            //{

            //}
            #endregion

        }

    }
}
