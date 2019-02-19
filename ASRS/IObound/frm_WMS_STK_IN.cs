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
    public partial class frm_WMS_STK_IN : Form
    {
        public frm_WMS_STK_IN()
        {
            InitializeComponent();
        }

        private void btnFunA_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frm_WMS_STK_IN_EmptyOut")
                {
                    f.Visible = true;
                    f.Activate();
                    f.WindowState = FormWindowState.Maximized;
                    f.Focus();
                    return;
                }
            }

            frm_WMS_STK_IN_EmptyOut frmP_WMS_STK_IN_EmptyOut = new frm_WMS_STK_IN_EmptyOut();
            frmP_WMS_STK_IN_EmptyOut.MdiParent = this.MdiParent;
            frmP_WMS_STK_IN_EmptyOut.Show();
            frmP_WMS_STK_IN_EmptyOut.Focus();
            //frmP_WMS_STK_IN_EmptyOut.ShowDialog();
        }

        private void btnFunB_Click(object sender, EventArgs e)
        {

        }

        private void btnFunC_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frm_WMS_STK_IN_Receive")
                {
                    f.Visible = true;
                    f.Activate();
                    f.WindowState = FormWindowState.Maximized;
                    f.Focus();
                    return;
                }
            }
            frm_WMS_STK_IN_Receive frmP_WMS_STK_IN_Receive = new frm_WMS_STK_IN_Receive();
            frmP_WMS_STK_IN_Receive.MdiParent = this.MdiParent;
            frmP_WMS_STK_IN_Receive.Show();
            frmP_WMS_STK_IN_Receive.Focus();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_WMS_STK_IN_Load(object sender, EventArgs e)
        {

        }



    }
}
