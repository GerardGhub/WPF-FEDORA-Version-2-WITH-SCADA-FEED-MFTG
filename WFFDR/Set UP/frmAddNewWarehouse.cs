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
    public partial class frmAddNewWarehouse : Form
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

        DataSet dset_section = new DataSet();



        public myclasses classes = new myclasses();
        myclasses myClass = new myclasses();


        public DataSet dset = new DataSet();
        DataSet dset2 = new DataSet();
        DataSet dset3 = new DataSet();

        frmWarehouseMgmt ths;
        public frmAddNewWarehouse(frmWarehouseMgmt frm, string add, string warehouse, string account_title, string added_by, string date_added,string key)
        {
            InitializeComponent();
            ths = frm;
            textBox1.TextChanged += new EventHandler(textBox1_TextChanged);
            this.add = add;
            this.warehouse = warehouse;
            this.acccount_title = account_title;
            this.added_by = added_by;
            this.date_added = date_added;
            this.key = key;
        }
        public string add { get; set; }
        public string warehouse { get; set; }
        public string acccount_title { get; set; }
        public string added_by { get; set; }
        public string date_added { get; set; }
        public string key { get; set; }
        
        private void frmAddNewWarehouse_Load(object sender, EventArgs e)
        {
            // Calling the Stored PROC 
            objStorProc = xClass.g_objStoredProc.GetCollections();
            txtdateadded.Text = (DateTime.Now.ToString("M/d/yyyy"));
            txtaddedby.Text = userinfo.emp_name.ToUpper();
            txtadd.Text = add;

             if(txtadd.Text == "add")
            {
                disableTextBox();
                txtwarehouse.Focus();
                button2.Text = "Save";

            }
             else
            {
                txtwarehouse.Text = warehouse;
                txtaccounttitle.Text = acccount_title;
                txtaddedby.Text = added_by;
                txtdateadded.Text = date_added;

                txtwarehouse.Enabled = true;
                txtaccounttitle.Enabled = true;
                txtkey.Text = key;
                txtdateadded.Enabled = false;
                txtaddedby.Enabled = false;
                button2.Text = "Update";
            }
        }


        public void disableTextBox()
        {
            //txtwarehouse.Enabled = false;
            //txtaccounttitle.Enabled = false;
            txtdateadded.Enabled = false;
            txtaddedby.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ths.textBox1.Text = textBox1.Text;
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



        public void SuccessFullyUpdate()
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);

            popup.ContentText = "Updated Successfully!";

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





        public void InvalidInput()
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);

            popup.ContentText = "Fill up the required field";

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




        private void button2_Click(object sender, EventArgs e)
        {
           if(txtwarehouse.Text.Trim() == string.Empty)
            {
                InvalidInput();
                txtwarehouse.Focus();
                return;
            }

           if(txtaccounttitle.Text.Trim()==string.Empty)
            {
                InvalidInput();
                txtaccounttitle.Focus();
                return;
            }


            if(txtadd.Text =="add")
            {


           


            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Insert a new Warehouse ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                dSet = objStorProc.rdf_sp_warehouse(0, txtwarehouse.Text.Trim(), txtaccounttitle.Text.Trim(), txtaddedby.Text.Trim(),txtdateadded.Text.Trim(), "add");



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


                if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Update the Warehouse Info ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {

                    dSet = objStorProc.rdf_sp_warehouse(0, txtwarehouse.Text.Trim(), txtaccounttitle.Text.Trim(), txtkey.Text.Trim(), txtdateadded.Text.Trim(), "update");



                    dSet.Clear();
                    textBox1.Text = "UpdateNA";
                    SuccessFullyUpdate();
                    this.Close();

                }
                else
                {

                    return;
                }






            }





        }

        private void frmAddNewWarehouse_FormClosing(object sender, FormClosingEventArgs e)
        {
            textBox1.Text = "SAVENA";
        }
    }
}
