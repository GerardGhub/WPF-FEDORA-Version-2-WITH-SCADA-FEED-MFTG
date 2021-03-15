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
    public partial class frmCombinationCode : Form
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

        //weighing

        public myclasses classes = new myclasses();
        myclasses myClass = new myclasses();


        public DataSet dset = new DataSet();
        DataSet dset2 = new DataSet();
        DataSet dset3 = new DataSet();


        public frmCombinationCode()
        {
            InitializeComponent();
        }

        private void frmCombinationCode_Load(object sender, EventArgs e)
        {
            // Calling the Stored PROC 
            objStorProc = xClass.g_objStoredProc.GetCollections();
            load_mixing_active();
            load_mixing_inactive();
            btnNew.Visible = true;
            textBox1.Text = "";
            this.BringToFront();
            myglobal.global_module = "FGINVENTORY";

            if(lblrecords.Text=="0")
            {
                //ControlBox = false;
            }
            else
            {
                ControlBox = true;
            }
            this.BringToFront();

            btnUpdate.Visible = true;
        }


        public void load_mixing_active()
        {
            string mcolumns = "test,code,description,remarks,date_added,added_by";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgvApproved, mcolumns, "mixing_combination_active");
            lblrecords.Text = dgvApproved.RowCount.ToString();

        }

        public void load_mixing_inactive()
        {
            string mcolumns = "test,code,description,remarks,date_added";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dataGridView1, mcolumns, "mixing_combination_inactive");
            lblrecords2.Text = dataGridView1.RowCount.ToString();

        }

        private void dgvApproved_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void btnActive_Click(object sender, EventArgs e)
        {

            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Mark as Active ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
            if(lblrecords.Text=="0")
                {

                }
            else
                {
                    InvalidMultipleActive();
                    return;
                }

                dSet.Clear();
                dSet = objStorProc.rdf_sp_move_order(0, lblid2.Text.Trim(), "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", 0, "activecombicode");


                frmCombinationCode_Load(sender, e);


            }
            else
            {

                return;
            }


        }


        public void InvalidMultipleActive()
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);

            popup.ContentText = "We already have an active Code !";

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

        private void btnInactive_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Mark as in Active ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                dSet.Clear();
                dSet = objStorProc.rdf_sp_move_order(0, lblid.Text.Trim(), "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", 0, "inactivecombicode");


                frmCombinationCode_Load(sender, e);

            }
            else
            {

                return;
            }
        }

        private void dgvApproved_CurrentCellChanged(object sender, EventArgs e)
        {


            if (dgvApproved.CurrentRow != null)
            {
                if (dgvApproved.CurrentRow.Cells["id"].Value != null)
                {
                    lblid.Text = dgvApproved.CurrentRow.Cells["id"].Value.ToString();
                  lblactivecode.Text = dgvApproved.CurrentRow.Cells["code"].Value.ToString();




                }
            }

        }

        private void dgvApproved_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {

            if (dataGridView1.CurrentRow != null)
            {
                if (dataGridView1.CurrentRow.Cells["id2"].Value != null)
                {
                    lblid2.Text = dataGridView1.CurrentRow.Cells["id2"].Value.ToString();

                    txtcode.Text = dataGridView1.CurrentRow.Cells["coder"].Value.ToString();
                   txtdescription.Text = dataGridView1.CurrentRow.Cells["descriptionr"].Value.ToString();
                    txtremarks.Text = dataGridView1.CurrentRow.Cells["remarksr"].Value.ToString();
                    txtdateadded.Text = dataGridView1.CurrentRow.Cells["date_addeds"].Value.ToString();
                    txtaddedby.Text = dataGridView1.CurrentRow.Cells["added_bys"].Value.ToString();
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            //btnNew.Visible = false;
            //frmNewMixingCode asaka = new frmNewMixingCode(this);
            //asaka.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            frmCombinationCode_Load(sender, e);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnNew.Visible = false;
            frmNewMixingCode asaka = new frmNewMixingCode(this,lblsample.Text,lblsample.Text,lblsample.Text,lblsample.Text,lblsample.Text, lblsample.Text);
            asaka.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Mark as Active ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (lblrecords.Text == "0")
                {

                }
                else
                {
                    InvalidMultipleActive();
                    return;
                }

                dSet.Clear();
                dSet = objStorProc.rdf_sp_move_order(0, lblid2.Text.Trim(), "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", 0, "activecombicode");


                frmCombinationCode_Load(sender, e);


            }
            else
            {

                return;
            }
        }

        private void btnInactive_Click_1(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Mark as in Active ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                dSet.Clear();
                dSet = objStorProc.rdf_sp_move_order(0, lblid.Text.Trim(), "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", 0, "inactivecombicode");


                frmCombinationCode_Load(sender, e);

            }
            else
            {

                return;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            btnUpdate.Visible = false;
            frmNewMixingCode asaka = new frmNewMixingCode(this,lblid2.Text,txtcode.Text, txtdescription.Text, txtremarks.Text, txtdateadded.Text, txtaddedby.Text);
            asaka.Show();
        }
    }
}
