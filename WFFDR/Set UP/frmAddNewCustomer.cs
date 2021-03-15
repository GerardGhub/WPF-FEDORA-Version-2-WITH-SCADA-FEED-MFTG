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

namespace WFFDR
{
    public partial class frmAddNewCustomer : Form
    {

        myclasses xClass = new myclasses();
        IStoredProcedures objStorProc = null;
        DataSet dSets = new DataSet();

        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();
        DataSet dSet_temp = new DataSet();
        DataSet dset_delete = new DataSet();

        DataSet dSet = new DataSet();
        DataSet dset_rights = new DataSet();


        private const int BaudRate = 9600;
        //int sec;
        DataSet dset_section = new DataSet();
        Boolean ready = false;
        bool re = false;
        //int p_id = 0;
        //int s_id = 0;
        //weighing

        public myclasses classes = new myclasses();
        myclasses myClass = new myclasses();


        public DataSet dset = new DataSet();
        DataSet dset2 = new DataSet();
        DataSet dset3 = new DataSet();

        frmCustomer ths;
        public frmAddNewCustomer(frmCustomer frm, string add,string name, string type, string company, string mobile, string lead_man, string address, string added_by, string date_added,string key)
        {
            InitializeComponent();
            ths = frm;
            textBox1.TextChanged += new EventHandler(textBox1_TextChanged);
            this.add = add;
            this.name = name;
            this.type = type;
            this.company = company;
            this.mobile = mobile;
            this.lead_man = lead_man;
            this.address = address;
            this.added_by = added_by;
            this.date_added = date_added;
            this.key = key;
            
        }
        public string name { get; set; }
        public string type { get; set; }
        public string company { get; set; }
        public string mobile { get; set; }
        public string lead_man { get; set; }
        public string address { get; set; }
        public string added_by { get; set; }
        public string date_added { get; set; }
        public string add { get; set; }
        public string key { get; set; }

        private void frmAddNewCustomer_Load(object sender, EventArgs e)
        {
            // Calling the Stored PROC 
            objStorProc = xClass.g_objStoredProc.GetCollections();

            textBox1.Text = "";
            txtadd.Text = add;

            if(txtadd.Text=="add")
            {
                txtdateadded.Text = (DateTime.Now.ToString("M/d/yyyy"));
                txtaddedby.Text = userinfo.emp_name.ToUpper();
                btnsave.Text = "Save";

            }
            else
            {
                txtname.Text = name;
                cboType.Text = type;
                cboCompany.Text = company;
                txtmobile.Text = mobile;
                txtleadman.Text = lead_man;
                txtaddress.Text = address;
                txtaddedby.Text = added_by;
                txtdateadded.Text = date_added;
                txtid.Text = key;
                btnsave.Text = "Update";

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ths.textBox1.Text = textBox1.Text;
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

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if(txtname.Text.Trim()==string.Empty)
            {
                FillData();
                txtname.Focus();
                return;
            }
            if (cboType.Text.Trim() == string.Empty)
            {
                FillData();
               cboType.Focus();
                return;
            }
            if (cboCompany.Text.Trim() == string.Empty)
            {
                FillData();
               cboCompany.Focus();
                return;
            }
            if (txtmobile.Text.Trim() == string.Empty)
            {
                FillData();
                txtmobile.Focus();
                return;
            }
            if (txtleadman.Text.Trim() == string.Empty)
            {
                FillData();
                txtleadman.Focus();
                return;
            }
            if (txtaddress.Text.Trim() == string.Empty)
            {
                FillData();
              txtaddress.Focus();
                return;
            }

            if (txtadd.Text == "add")
            {

                if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Insert a new Customer ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {

                    dSet = objStorProc.rdf_sp_customer(0, txtname.Text.Trim(), cboType.Text.Trim(), cboCompany.Text.Trim(), txtmobile.Text.Trim(), txtleadman.Text.Trim(), txtaddress.Text.Trim(), txtaddedby.Text.Trim(), txtdateadded.Text.Trim(), "add");



                    dSet.Clear();
                    textBox1.Text = "SAVENA";
                    SuccessFullySave();
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

                    dSet = objStorProc.rdf_sp_customer(0, txtname.Text.Trim(), cboType.Text.Trim(), cboCompany.Text.Trim(), txtmobile.Text.Trim(), txtleadman.Text.Trim(), txtaddress.Text.Trim(), txtid.Text.Trim(), txtdateadded.Text.Trim(), "update");



                    dSet.Clear();
                    textBox1.Text = "UpdateNA";
                    SuccessFullyUpdated();
        
                        this.Close();

                }
                else
                {

                    return;
                }







            }




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

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            
        }

        private void frmAddNewCustomer_FormClosing(object sender, FormClosingEventArgs e)
        {
            textBox1.Text = "Closing";
        }
    }
}
