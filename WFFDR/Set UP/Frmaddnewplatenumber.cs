using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace WFFDR.Set_UP
{
    public partial class Frmaddnewplatenumber : Form
    {
        myclasses xClass = new myclasses();
        IStoredProcedures objStorProc = null;
        DataSet dSet = new DataSet();
        public myclasses classes = new myclasses();
        public DataSet dset = new DataSet();

        FrmPlatenumber ths;
        public Frmaddnewplatenumber(FrmPlatenumber frm, string add, string pnid, string tovehicle, string platenumber, string added_by, string date_added)
        {
            InitializeComponent();
            ths = frm;
            textBox1.TextChanged += new EventHandler(textBox1_TextChanged);
            this.tovehicle = tovehicle;
            this.platenumber = platenumber;
            this.pnid = pnid;
            this.added_by = added_by;
            this.date_added = date_added;
            this.add = add;
        }

        public string add{ get; set; }

        public string pnid { get; set; }
        public string tovehicle { get; set; }
        public string platenumber { get; set; }

        public string added_by { get; set; }
        public string date_added { get; set; }


        private void Frmaddnewplatenumber_Load(object sender, EventArgs e)
        {

            objStorProc = xClass.g_objStoredProc.GetCollections();


            txtdateadded.Text = (DateTime.Now.ToString("MM/dd/yyyy"));
            txtaddedby.Text = userinfo.emp_name.ToUpper();
            txtadd.Text = add;
             
            if (txtadd.Text == "add")
            {
                txtdateadded.Text = (DateTime.Now.ToString("MM/dd/yyyy"));
                txtaddedby.Text = userinfo.emp_name.ToUpper();
                btnsave.Text = "Save";

            }
            else
            {


                txtplatenumber.Text = platenumber;
                txttovehicle.Text = tovehicle;
                txtaddedby.Text = added_by;
                txtdateadded.Text = date_added;
                txtid.Text = pnid;
                btnsave.Text = "Update";

            }
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        public void FillData()
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);

            popup.ContentText = "Fill up the required Field";

            popup.ContentColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);

            popup.ContentHoverColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentPadding = new Padding(0);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Red;
            popup.Popup();

            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);

            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }

        public void SuccessFullyUpdated()
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);

            popup.ContentText = "Updated SuccessFully!";

            popup.ContentColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);

            popup.ContentHoverColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentPadding = new Padding(0);

            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Green;
            popup.Popup();

            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);

            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }
        public void SuccessFullySave()
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);

            popup.ContentText = "SuccessFully Save !";

            popup.ContentColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);

            popup.ContentHoverColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentPadding = new Padding(0);

            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Green;
            popup.Popup();

            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);

            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txttovehicle.Text.Trim() == String.Empty)
            {
                FillData();
                txttovehicle.Focus();
                return;
            }
            if (txtplatenumber.Text.Trim() == String.Empty)
            {
                FillData();
                txttovehicle.Focus();
                return;
            }
            else
            {

                if (txtadd.Text == "add")
                {

                    if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Insert a new Customer ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {

                        dSet = objStorProc.rdf_sp_platenumber(0, txttovehicle.Text, txtplatenumber.Text, txtaddedby.Text, txtdateadded.Text, "", "", "", "", "", "", "add");
                        dSet.Clear();

                        txttovehicle.Text = String.Empty;
                        txtplatenumber.Text = String.Empty;
                        SuccessFullySave();
                        textBox1.Text = "SAVE";
                        this.Close();

                    }
                    else
                    {

                        return;
                    }
                }
                else
                {


                    if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Update the new Customer ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        txtdateadded.Text = (DateTime.Now.ToString("MM/dd/yyyy"));
                        txtaddedby.Text = userinfo.emp_name.ToUpper();


                        dSet = objStorProc.rdf_sp_platenumber(Convert.ToInt32(txtid.Text), txttovehicle.Text, txtplatenumber.Text, "", "", "", "", "", "", txtaddedby.Text, txtdateadded.Text, "update");
                        dSet.Clear();

                        txttovehicle.Text = String.Empty;
                        txtplatenumber.Text = String.Empty;
                        textBox1.Text = "Update";

                        SuccessFullyUpdated();

                        this.Close();

                    }
                    else
                    {

                        return;
                    }







                }

            }
        }

        public void textBox1_TextChanged(object sender, EventArgs e)

        {
            ths.textBox1.Text = textBox1.Text;

        }
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            
        }

        private void Frmaddnewplatenumber_FormClosing(object sender, FormClosingEventArgs e)
        {
            textBox1.Text = "Closing";
        }
    }
}
