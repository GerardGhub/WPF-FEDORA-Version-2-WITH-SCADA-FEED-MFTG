using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFFDR.Receiving
{
    public partial class FormReceivingConfirmation : Form
    {

        frmFGView ths;
        
        public FormReceivingConfirmation(frmFGView frm,string lbltotalquantityselect)
        {
            InitializeComponent();
            ths = frm;

            this.lbltotalquantityselect = lbltotalquantityselect;
           
        }

        public FormReceivingConfirmation()
        {
        }

        public string lbltotalquantityselect { get; set; }
        private void FormReceivingConfirmation_Load(object sender, EventArgs e)
        {

            confirmquan.Text = lbltotalquantityselect;

        }

        private void confirmbtn_Click(object sender, EventArgs e)
        {
            if (confirmquan.Text == lblconfirmtxt.Text)
            {
                FormReceivingConfirmation form = new FormReceivingConfirmation();
                form.Close();


            }
            else
                return;

        }

        private void lblconfirmtxt_TextChanged(object sender, EventArgs e)
        {
            lblconfirmtxt.Text = confirmbtn.Text;
        }
    }
}
