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
    public partial class frmsystemupdate : Form
    {
        myclasses myClass = new myclasses();
        //IStoredProcedures g_objStoredProcCollection = null;
        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();
        //DataSet dSet_temp = new DataSet();
        DataSet dSet = new DataSet();
        //int p_id = 0;
        //int temp_hid = 0;
        //string mode = "";
        Boolean ready = false;
        myclasses xClass = new myclasses();
        IStoredProcedures objStorProc = null;
        public frmsystemupdate()
        {
            InitializeComponent();
        }
        
        private void frmsystemupdate_Load(object sender, EventArgs e)
        {
            objStorProc = xClass.g_objStoredProc.GetCollections();
            load_updates();
            DateTime dNow = DateTime.Now;
            txtaddedby.Visible = false;
          
            txtuseridproc.Text = userinfo.user_rights_id.ToString();
            loadModule_type();
            txtuseridproc.Visible = false;
        }

        // for repisotory of enabling and disable a textbox
  void DisableTextBoxes()
        {
            txtupdatedate.Enabled = false;
            txtobjective.Enabled = false;
            txtremarks.Enabled = false;
        }

        void loadModule_type()
        {
            ready = false;
            myClass.fillComboBox(txtmodule, "module_type", dSet);
            ready = true;

            if(txtuseridproc.Text=="2")
            {
                groupBox1.Visible = true;
            }
            else
            {

                groupBox1.Visible = false;
            }
        }

        public void load_updates()
        {
            string mcolumns = "test,update_id,module,update_remarks,update_objective,update_date,added_by";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgvUnread, mcolumns, "distinctupdatefedora");
            //lblrecords.Text = dgv_table.RowCount.ToString();
    txtaddedby.Text = userinfo.emp_name.ToUpper();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you save the update of project Fedora ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

            }
            else
            {

                return;
            }



            if (txtremarks.Text.Trim() == string.Empty)
            {
                EmptyFieldNotify();
                return;
            }
            if (txtobjective.Text.Trim() == string.Empty)
            {
                EmptyFieldNotify();
                return;
            }


            dSet.Clear();

            dSet = objStorProc.rdf_sp_new_preparation(0, txtmodule.Text, txtremarks.Text, txtobjective.Text, txtupdatedate.Text, txtaddedby.Text, "", "", "", "", "", "", "", "", "", "", "", "", "addupdate");
            load_updates();


            DisableTextBoxes();
        }

        private void dgvUnread_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            dSet.Clear();

            dSet = objStorProc.rdf_sp_new_preparation(0, txtid.Text, txtremarks.Text, txtobjective.Text, txtupdatedate.Text, txtaddedby.Text, "", "", "", "", "", "", "", "", "", "", "", "", "deleteupdate");
            load_updates();
        }

        private void dgvUnread_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgvUnread.RowCount > 0)
            {
                if (dgvUnread.CurrentRow != null)
                {
                    if (dgvUnread.CurrentRow.Cells["update_id"].Value != null)
                    {
                        //p_id = Convert.ToInt32(dgv1stView.CurrentRow.Cells["prod"].Value);

                        txtid.Text = dgvUnread.CurrentRow.Cells["update_id"].Value.ToString();


                    }

                }
            }
        }

        private void txtuseridproc_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
            Enable();
            btnCancel.Visible = true;
            btnNew.Visible = false;
        }
        void Enable()
        {

            txtmodule.Enabled = true;
            txtupdatedate.Enabled = true;
                txtobjective.Enabled = true;
                txtremarks.Enabled = true;
        }
        void ClearTextBoxes()
        {
            txtmodule.Text = "";
            txtupdatedate.Text = "";
            txtobjective.Text="";
            txtremarks.Text = "";

        }

        void EmptyFieldNotify()
        {

            Tulpep.NotificationWindow.PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "FILL UP THE REQUIRED FIELD";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(920, 270);
            popup.ImageSize = new Size(175, 180);
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel.Visible = false;
            btnNew.Visible = true;
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {

        }
    }
}
