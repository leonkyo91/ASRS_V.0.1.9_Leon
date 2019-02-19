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
    public partial class frm_WMS_IQC_LOGIN : Form
    {
        public frm_WMS_IQC_LOGIN()
        {
            InitializeComponent();
        }

        private void frm_WMS_IQC_LOGIN_Load(object sender, EventArgs e)
        {
            FormInit();
        }

        private void FormInit()
        {
            Array.Resize<string>(ref clsASRS.gsHelpRtnData, 1);
            txtIQC_ID.Text = "";
            txtIQC_ID.Select();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            SubOK();
        }

        private void SubOK()
        {
            clsASRS.gsHelpRtnData[0] = "";
            clsASRS.gsHelpRtnData[0] = txtIQC_ID.Text.Trim();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            clsASRS.gsHelpRtnData[0] = "";
            this.Close();
        }

        private void txtIQC_ID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtIQC_ID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                SubOK();
            }
        }



    }
}
