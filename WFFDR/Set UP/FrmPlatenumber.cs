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
    public partial class FrmPlatenumber : Form
    {

        myglobal pointer_module = new myglobal();
        myclasses xClass = new myclasses();
        IStoredProcedures objStorProc = null;
        DataSet dSet = new DataSet();
        DataSet dsetHeader = new DataSet();
        public myclasses classes = new myclasses();



        public DataSet dset = new DataSet();
        public FrmPlatenumber()
        {
            InitializeComponent();
        }

        private void FrmPlatenumber_Load(object sender, EventArgs e)
        {
            objStorProc = xClass.g_objStoredProc.GetCollections();
            load_active_platenumber();
            textBox1.Text = "";
           
        }
        public void load_active_platenumber()
        {
            string mcolumns = "test,pnid,to_vehicle,platenumber,added_by,date_added";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgvplatenumber, mcolumns, "load_active_platenumber");
            lblrecords.Text = dgvplatenumber.RowCount.ToString();
            textBox1.Text = "";

        }

        private void dgvplatenumber_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            Disable();
            Frmaddnewplatenumber addplatenumber = new Frmaddnewplatenumber(this,txtadd.Text,txtid.Text, txtboxtovehicle.Text, txtboxplatenumber.Text,txtaddedby.Text,txtdateadded.Text);
            addplatenumber.Show();
        }

        private void Enable()
        {
            btnNew.Visible = true;
            btnUpdate.Visible = true;
            btnDelete.Visible = true;
            dgvplatenumber.Enabled = true;

        }

        private void Disable()
        {
            btnNew.Visible = false;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            dgvplatenumber.Enabled = false;

        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {
            load_active_platenumber();
            Enable();
            

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Disable();
            Frmaddnewplatenumber addplatenumber = new Frmaddnewplatenumber(this,txtedit.Text,txtid.Text, txtboxtovehicle.Text, txtboxplatenumber.Text, txtaddedby.Text, txtdateadded.Text);
            addplatenumber.Show();
        }

        private void dgvplatenumber_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgvplatenumber.CurrentRow != null)
            {
                if (dgvplatenumber.CurrentRow.Cells["pnid"].Value != null)
                {
                    txtid.Text = dgvplatenumber.CurrentRow.Cells["pnid"].Value.ToString();
                    txtboxtovehicle.Text = dgvplatenumber.CurrentRow.Cells["to_vehicle"].Value.ToString();
                    txtboxplatenumber.Text = dgvplatenumber.CurrentRow.Cells["platenumber"].Value.ToString();
                    txtaddedby.Text = dgvplatenumber.CurrentRow.Cells["added_by"].Value.ToString();
                    txtdateadded.Text = dgvplatenumber.CurrentRow.Cells["date_added"].Value.ToString();
                }



            }
        }


        public void SuccessFullyInactive()
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);

            popup.ContentText = "In-Active SuccessFully!";

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
        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to In-Active this Customer ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                txtdateadded.Text = (DateTime.Now.ToString("MM/dd/yyyy"));
                txtaddedby.Text = userinfo.emp_name.ToUpper();
                dSet = objStorProc.rdf_sp_platenumber(Convert.ToInt32(txtid.Text), "", "", "", "", txtaddedby.Text, txtdateadded.Text, "", "", "", "", "inactive");
                dSet.Clear();
                textBox1.Text = "inactive";
                SuccessFullyInactive();
                load_active_platenumber();




            }
            else
            {

                return;
            }
        }
    }
}
