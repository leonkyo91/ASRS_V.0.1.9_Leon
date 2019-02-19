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
    public partial class frm_ASRS_STK_OUT : Form
    {
        public frm_ASRS_STK_OUT()
        {
            InitializeComponent();
        }

        private void btnFunA_Click(object sender, EventArgs e)
        {
            frm_ASRS_STK_OUT_Loc frmP_ASRS_STK_OUT_Loc = new frm_ASRS_STK_OUT_Loc();
            frmP_ASRS_STK_OUT_Loc.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
