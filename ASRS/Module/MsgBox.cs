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
   public  partial class MsgBox : Form
    {
       
        public MsgBox(string _strMsg,string _strTitle,string _strIcon)
        {

            InitializeComponent();
            frmLoad(_strMsg, _strTitle, _strIcon);
       
        }
        private void frmLoad(string strMsg, string strTitle, string strIcon)
        {
        

            #region choise ICON 
            pbError.Visible = false;
            pbInfor.Visible = false;
            pbWarning.Visible = false;

            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;

            button1.Text = "確定";
            button2.Text = "是";
            button3.Text = "否";
           
            switch (strIcon)
            {
                case"Warning":
                    this.pbWarning.Location = new System.Drawing.Point(13, 25);
                    pbWarning.Visible = true;
                    button1.Visible = true;
                    break;
                case"ERROR":
                    this.pbError.Location = new System.Drawing.Point(13, 25);
                    pbError.Visible = true;
                    button1.Visible = true;
                    break;
                case"OK":
                    this.pbInfor.Location = new System.Drawing.Point(13, 25);
                    pbInfor.Visible = true;
                    button1.Visible = true;
                    break;
                case"Question":
                    this.pbWarning.Location = new System.Drawing.Point(13, 25);
                    button2.Visible = true;
                    button3.Visible = true;
                    pbWarning.Visible = true;
                    break;
            }
            #endregion

            this.Text = strTitle;
            textBox1.Text = strMsg;
            //label1.Text = strMsg;
            #region bitton stytle
           
            button1.Text = "確定";
            button3.Text = "是";
            button2.Text = "否";
            #endregion
            timer1.Start();
            timer1.Interval = 100;
            
          
        }

        private  void button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            
            this.Close();
            this.Dispose();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            button1.Focus();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clsMSG.msg_flag = true;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clsMSG.msg_flag = false;
            this.Close();
        }
    }
}
