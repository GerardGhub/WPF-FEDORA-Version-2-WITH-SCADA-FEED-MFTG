using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace WFFDR.Production
{
    public partial class frmTaggingofFeedtype : Form
    {
        DataSet dsetprod = new DataSet();
        IStoredProcedures objStorProc = null;
        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();
        myclasses xClass = new myclasses();

        public frmTaggingofFeedtype()
        {
            InitializeComponent();
        }

        private void frmTaggingofFeedtype_Load(object sender, EventArgs e)
        {
            objStorProc = xClass.g_objStoredProc.GetCollections();
            LoadProd();
            load_FGmonitoring();
            txtprod.Text = String.Empty;
            txtfeedcode.Text = String.Empty;
            txtfeedtype.Text = String.Empty;
        }

            

        public void load_FGmonitoring()
        {
            string mcolumns = "test,prod_id,p_feed_code,feed_type,bags_int,proddate,total_reprocess_count,DONE,TOTAL,AGING";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgvreprocess, mcolumns, "FGmonitoringReprocess");
            lblreprocess.Text = dgvreprocess.RowCount.ToString();

        }

        private void LoadProd()
        {


            dsetprod.Clear();
            dsetprod = objStorProc.sp_GetCategory("LoadProdtagging", 0, "", "", "");
            if (dsetprod.Tables.Count > 0)
            {
                DataView dv = new DataView(dsetprod.Tables[0]);

                dgvprod.DataSource = dv;
                lblprod.Text = dgvprod.RowCount.ToString();
            }
        }

        private void dgvprod_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgvprod.RowCount > 0)
            {
                if (dgvprod.CurrentRow != null)
                {
                    if (dgvprod.CurrentRow.Cells["FEEDTYPE"].Value != null)
                    {
                        //txtprod.Text = dgvprod.CurrentRow.Cells["PRODID"].Value.ToString();
                        //txtfeedcode.Text = dgvprod.CurrentRow.Cells["FEEDCODE"].Value.ToString();
                        txtfeedtype.Text = dgvprod.CurrentRow.Cells["FEEDTYPE"].Value.ToString();
                    }

                }
            }

        }

        private void dgvprod_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void dgvreprocess_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void tagbtn_Click(object sender, EventArgs e)
        {

            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to tag this feedtype '" + txtfeedcode.Text + "' to '"+ txtfeedtype.Text + "' ? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                dsetHeader.Clear();
                dsetHeader = objStorProc.sp_GetCategory("Tagfeedtype", 0, txtprod.Text, txtfeedcode.Text, txtfeedtype.Text);
                Tagged();
                txtprod.Text = String.Empty;
                txtfeedcode.Text = String.Empty;
                txtfeedtype.Text = String.Empty;
                frmTaggingofFeedtype_Load(sender, e);


            }
            else
            {
                return;
            }

                
        }


        void Tagged()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Successfully Tagged!";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);

            popup.BodyColor = Color.Red;
            popup.Popup();
            popup.AnimationDuration = 200;
            popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            //txtMainInput.Focus();
            //txtMainInput.Select();
            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;
           

        }

        private void dgvreprocess_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgvreprocess.RowCount > 0)
            {
                if (dgvreprocess.CurrentRow != null)
                {
                    if (dgvreprocess.CurrentRow.Cells["prod_id"].Value != null)
                    {
                        //txtprod.Text = dgvprod.CurrentRow.Cells["PRODID"].Value.ToString();
                        txtfeedcode.Text = dgvreprocess.CurrentRow.Cells["feed_type"].Value.ToString();
                        txtprod.Text = dgvreprocess.CurrentRow.Cells["prod_id"].Value.ToString();

                    }

                }
            }

        }
    }
}