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
    public partial class frmNewMixingCode : Form
    {
        int rowindex;
        int i;
        string mode = ""; //mymode
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
        int sec;
        DataSet dset_section = new DataSet();
        Boolean ready = false;
        bool re = false;
        int p_id = 0;
        int s_id = 0;
        //weighing

        public myclasses classes = new myclasses();
        myclasses myClass = new myclasses();


        public DataSet dset = new DataSet();
        DataSet dset2 = new DataSet();
        DataSet dset3 = new DataSet();
        frmCombinationCode ths;

        public frmNewMixingCode(frmCombinationCode frm, string id2, string code, string description, string remarks, string date_added, string added_by)
        {
            InitializeComponent();
            ths = frm;
            textBox1.TextChanged += new EventHandler(textBox1_TextChanged);
            this.id2 = id2;
            this.code = code;
            this.description = description;
            this.remarks = remarks;
            this.date_added = date_added;
            this.added_by = added_by;
        }
        public string date_added { get; set; }
        public string added_by { get; set; }
        public string id2 { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public string remarks { get; set; }

        private void frmNewMixingCode_Load(object sender, EventArgs e)
        {
            // Calling the Stored PROC 
            objStorProc = xClass.g_objStoredProc.GetCollections();


            textBox1.Text = "";
            txtcode.Focus();
            lblid2.Text = id2;

            if(lblid2.Text =="0")
            {
                txtdateadded.Text = (DateTime.Now.ToString("M/d/yyyy"));
                txtaddedby.Text = userinfo.emp_name.ToUpper();
                button2.Text = "&Save";
            }
            else
            {
                button2.Text = "&Update";
                txtcode.Text = code;
                txtdescription.Text = description;
                txtremarks.Text = remarks;
                txtdateadded.Text = date_added;
                txtaddedby.Text = added_by;
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



        public void SuccessFullyUpdate()
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);

            popup.ContentText = "Updated SuccessFully !";

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


        public void FilledUptheemptyFilled()
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);

            popup.ContentText = "Fill up the required field!";

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



        private void frmNewMixingCode_FormClosing(object sender, FormClosingEventArgs e)
        {
            // If user (not system!) wants to close the form
            // but (s)he answered "no", do not close the form
            if (e.CloseReason == CloseReason.UserClosing)
                e.Cancel = MessageBox.Show(@"Do you really want to close the form?",
                                           Application.ProductName,
                                           MessageBoxButtons.YesNo) == DialogResult.No;
        }

        private void frmNewMixingCode_FormClosing_1(object sender, FormClosingEventArgs e)
        {



        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Mark as in Active ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                dSet = objStorProc.rdf_sp_move_order(0, txtcode.Text.Trim(), txtdescription.Text.Trim(), txtremarks.Text.Trim(), txtdateadded.Text.Trim(), txtaddedby.Text.Trim(), "", "", "", "", "", "", "", "", "", "", "", "", "", 0, "insertcode");



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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ths.textBox1.Text = textBox1.Text;
        }

        private void frmNewMixingCode_FormClosed(object sender, FormClosedEventArgs e)
        {
            //if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Exit?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            //{

            //    textBox1.Text = "sfsf";
            //    this.Close();
            //    return;
            //}
            //else
            //{
            //    return;

            //}
            textBox1.Text = "sfsf";
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {

        }

        private void txtUnitPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Mark as in Active ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                dSet = objStorProc.rdf_sp_move_order(0, txtcode.Text.Trim(), txtdescription.Text.Trim(), txtremarks.Text.Trim(), txtdateadded.Text.Trim(), txtaddedby.Text.Trim(), "", "", "", "", "", "", "", "", "", "", "", "", "", 0, "insertcode");



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

        private void button2_Click(object sender, EventArgs e)
        {


            if(txtcode.Text.Trim() == string.Empty)

            {
                FilledUptheemptyFilled();
                txtcode.Focus();

                return;
            }
            if(txtdescription.Text.Trim() == string.Empty)
            {
                FilledUptheemptyFilled();
                txtdescription.Focus();
                return;
            }
            if(txtremarks.Text.Trim()==string.Empty)
            {
                FilledUptheemptyFilled();
                txtremarks.Focus();
                return;
            }



            if (lblid2.Text == "0")
            {


                if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Mark as in Active ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {

                    dSet = objStorProc.rdf_sp_move_order(0, txtcode.Text.Trim(), txtdescription.Text.Trim(), txtremarks.Text.Trim(), txtdateadded.Text.Trim(), txtaddedby.Text.Trim(), "", "", "", "", "", "", "", "", "", "", "", "", "", 0, "insertcode");



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
                //yabamg


                if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Update the Outright Code ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {

                    dSet = objStorProc.rdf_sp_move_order(0, txtcode.Text.Trim(), txtdescription.Text.Trim(), txtremarks.Text.Trim(), lblid2.Text.Trim(), txtaddedby.Text.Trim(), "", "", "", "", "", "", "", "", "", "", "", "", "", 0, "updatecode");



                    dSet.Clear();
                    textBox1.Text = "SAVENA";
                    SuccessFullyUpdate();
                    this.Close();

                }
                else
                {

                    return;
                }




            }






        }
    }
}
