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
    public partial class frmProductionPlanController : Form
    {
        IStoredProcedures objStorProc = null;
        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();
        myclasses xClass = new myclasses();
        DataSet dSet = new DataSet();
        public frmProductionPlanController()
        {
            InitializeComponent();
        }

        private void frmProductionPlanController_Load(object sender, EventArgs e)
        {
            objStorProc = xClass.g_objStoredProc.GetCollections();

            load_PlanningActive();
            GenerateBaseDControll();

        }
        public void GenerateBaseDControll()
        {
            txtRemarks.Text = string.Empty;
        }

        public void load_PlanningActive()
        {
            string mcolumns = "test,prod_id,p_feed_code,rp_feed_type,p_bags_int,p_nobatch,proddate,ra_feed_selection";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgv_table, mcolumns, "isForproduction_Automation_Cancelation");
            lblrecords.Text = dgv_table.RowCount.ToString();
        }

        private void dgv_table_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void dgv_table_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgv_table.RowCount > 0)
            {
                if (dgv_table.CurrentRow != null)
                {
                    if (dgv_table.CurrentRow.Cells["p_feed_code"].Value != null)
                    {

                        txtProdId.Text = dgv_table.CurrentRow.Cells["prod_id"].Value.ToString();

                    }

                }
            }
        }
        void InputRemarks()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.ContentText = "Input The Remark First!";
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.LightBlue;
            popup.Popup();

            popup.ContentColor = Color.Black;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.TitleColor = Color.Black;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.AnimationDuration = 1000;
            popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);

            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }


       public void SuccessFullyCancelled()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Production Schedule Successfully Cancel";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Green;
            popup.Popup();
            popup.AnimationDuration = 1000;
            popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);

            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;
  

        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            if(lblrecords.Text =="0")
            {
                return;
            }

            if (txtRemarks.Text.Trim() == string.Empty)
            {
                InputRemarks();
                txtRemarks.Focus();
                return;
            }
            else
            {

            }

            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Cancel the selected Production Schedule? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                dSet.Clear();
                dSet = objStorProc.rdf_sp_prod_schedules(0, txtProdId.Text, txtRemarks.Text, "", "", "", "", "", "", "", "", "", "cancelProdPlanInProductionArea");

                SuccessFullyCancelled();
                frmProductionPlanController_Load(sender, e);
            }
            else
            {
                return;
            }

            }

        private void dgv_table_DoubleClick(object sender, EventArgs e)
        {
            txtRemarks.Enabled = true;
        }
    }
}
