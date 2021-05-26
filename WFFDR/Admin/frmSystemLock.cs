using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFFDR
{
    public partial class frmSystemLock : Form
    {

        myclasses xx = new myclasses();
        public frmSystemLock()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (txtpassword.Text == "work")
            {
                // my_class.dailyAttendanceDate = DateTime.Now;

                myclasses.confirmPassword = txtpassword.Text;

                this.Close();

               // return;
            }
            else
            {
                MessageBox.Show("incorrect Password " + lblName.Text + ". ", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtpassword.Text = "";
                txtpassword.Focus();
                txtpassword.Select();
                return;

            }

        }

        private void BtnContinue_KeyDown(object sender, KeyEventArgs e)
        {
       
        }

        private void BtnContinue_KeyPress(object sender, KeyPressEventArgs e)
        {
       
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (txtpassword.Text == "work")
            {
                // my_class.dailyAttendanceDate = DateTime.Now;

                myclasses.confirmPassword = txtpassword.Text;

                this.Close();

                // return;
            }
            else
            {
                MessageBox.Show("incorrect Password " + lblName.Text + ". ", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtpassword.Text = "";
                return;

            }
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1_Click_1(sender, e);
        }

        private void txtpassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1_Click_1(sender, e);
        }

        private void PresentModule_Click(object sender, EventArgs e)
        {

        }

        private void frmSystemLock_Load(object sender, EventArgs e)
        {
            button1.Visible = false;
            //BtnContinue.Visible = false;
            lblName.Visible = false;

        }
    }
}
