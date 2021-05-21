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
    public partial class frmProductionLevel : Form
    {
        myclasses xClass = new myclasses();
        IStoredProcedures objStorProc = null;
        //Boolean ready = false;
        DataSet dSet = new DataSet();

        //DataSet dSets = new DataSet();

        //string mode = "";
        //int p_id = 0;
        //int temp_hid = 0;
        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();

        public frmProductionLevel()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmaddUsers_Load(object sender, EventArgs e)
        {
            objStorProc = xClass.g_objStoredProc.GetCollections();
            load_Schedules();
            DateTime dNow = DateTime.Now;
            lblTip.Text = userinfo.emp_name.ToUpper();
            txtdatenow2.Text = (dNow.ToString("M/d/yyyy"));

            txtaddedby.Text = userinfo.emp_name.ToUpper();
        }


        void BagsDotNotify()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = " Actual Bags is not Divisble by 40 '" + txtnobatch.Text + "'!";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Red;
            popup.Popup();
            //popup.AnimationDuration = 1000;
            //popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            //txtMainInput.Focus();
            //txtMainInput.Select();
            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }

        void UpdateSucccesssFully()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Production level status successsfully Updated";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Green;
            popup.Popup();
            //popup.AnimationDuration = 1000;
            //popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            //txtMainInput.Focus();
            //txtMainInput.Select();
            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }




        void EmptyField()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = " Fill up the required Fields";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Red;
            popup.Popup();
            //popup.AnimationDuration = 1000;
            //popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            //txtMainInput.Focus();
            //txtMainInput.Select();
            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }



        public void load_Schedules()
        {
            string mcolumns = "test,levelstatus,modified_by,modified_date";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dataView, mcolumns, "isForproductionLevelMgmt");
            //lbltotalprod.Text = dataView.RowCount.ToString();
            // textBox1.Text = dgv_table.RowCount.ToString();

        }

        private void dataView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void txtbags_TextChanged(object sender, EventArgs e)
        {
            try
            {


                txtnobatch.Text = (float.Parse(txtbags.Text) / 40).ToString();


            }
            catch (Exception)
            {


            }

            if (txtnobatch.Text.Contains("."))
            {
 

                txtnobatch.BackColor = Color.Yellow;

            }
            else
            {
                txtnobatch.BackColor = Color.White;
   
            }




            if (txtbags.Text.Trim() == string.Empty)
            {

                txtnobatch.Text = "";
                txtbags.BackColor = Color.Yellow;


            }

            else
            {
                txtbags.BackColor = Color.White;

            }













            }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            if (txtnobatch.Text.Contains("."))
            {
                //MessageBox.Show("Approved");
                BagsDotNotify();
                txtbags.BackColor = Color.Yellow;
                txtbags.Focus();
                txtbags.Select();
                return;
            }
            else
            {
                //MessageBox.Show("DisApproved");
            }






            txtbags.Enabled = true;
        
            btnUpdate.Visible = true;
            btnEdit.Visible = false;

            bunifuThinButton24.Visible = true;
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            txtbags.Enabled = false;
            txtnobatch.Enabled = false;
            btnUpdate.Visible = false;
            btnEdit.Visible = true;
            bunifuThinButton24.Visible = false;

        }

        private void dataView_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataView.RowCount > 0)
            {
                if (dataView.CurrentRow != null)
                {
                    if (dataView.CurrentRow.Cells["levelstatus"].Value != null)
                    {
                        //p_id = Convert.ToInt32(dgv1stView.CurrentRow.Cells["prod"].Value);

                        txtbags.Text = dataView.CurrentRow.Cells["levelstatus"].Value.ToString();


                    }

                }
            }
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
       
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to update Production Level ? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if(txtbags.Text.Trim() == string.Empty)
                {
                    EmptyField();
                    txtbags.Focus();
                    txtbags.Select();
                    return;
                }






                if (txtnobatch.Text.Contains("."))
                {
                    //MessageBox.Show("Approved");
                    BagsDotNotify();
                    txtbags.BackColor = Color.Yellow;
                    txtbags.Focus();
                    txtbags.Select();
                    return;
                }
                else
                {
                    //MessageBox.Show("DisApproved");
                }


                dSet.Clear();
                //dSet = objStorProc.rdf_sp_prod_schedules(0, txt1.Text, "", "", "", "", "", "", "existsornot");
                dSet = objStorProc.rdf_sp_new_preparation(0, txtbags.Text,lblTip.Text,txtdatenow2.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "updateproductionlevel");




                dSet.Clear();
                lbldate.Text = DateTime.Now.ToString();
                //4 query is for insert the audit trail
                dSet = objStorProc.rdf_sp_new_preparation(0, txtbags.Text, txtaddedby.Text, "8.3.3 Production Level Setup", "Update a Production Level", lbldate.Text, "", txtnobatch.Text, "", "", "", "", "", "", "", "", "", "", "addTrailLogs");






                UpdateSucccesssFully();
                load_Schedules();
                txtbags.Enabled = false;
                btnUpdate.Visible = false;

                btnEdit.Visible = true;
                bunifuThinButton24.Visible = false;


            }

            else
            {
                return;

            }





            }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            metroButton4_Click(sender, e);
        }
    }
}
