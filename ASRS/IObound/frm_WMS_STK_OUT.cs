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
    public partial class frm_WMS_STK_OUT : Form
    {
        public frm_WMS_STK_OUT()
        {
            InitializeComponent();
        }

        private void btnFunA_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frm_WMS_STK_OUT_AsrsStkOut")
                {
                    f.Visible = true;
                    f.Activate();
                    f.WindowState = FormWindowState.Maximized;
                    f.Focus();
                    return;
                }
            }

            frm_WMS_STK_OUT_AsrsStkOut frmP_WMS_STK_OUT_AsrsStkOut = new frm_WMS_STK_OUT_AsrsStkOut();
            frmP_WMS_STK_OUT_AsrsStkOut.MdiParent = this.MdiParent;
            
            
            ////MdiParent
            frmP_WMS_STK_OUT_AsrsStkOut.Show();
            frmP_WMS_STK_OUT_AsrsStkOut.Focus();

            
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frm_WMS_STK_OUT_Receive")
                {
                    f.Visible = true;
                    f.Activate();
                    f.WindowState = FormWindowState.Maximized;
                    f.Focus();
                    return;
                }
            }

            frm_WMS_STK_OUT_Receive frmP_WMS_STK_OUT_Receive = new frm_WMS_STK_OUT_Receive();
            frmP_WMS_STK_OUT_Receive.MdiParent = this.MdiParent;

            ////MdiParent
            frmP_WMS_STK_OUT_Receive.Show();
            frmP_WMS_STK_OUT_Receive.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_WMS_STK_OUT_Load(object sender, EventArgs e)
        {

        }
    }
}
