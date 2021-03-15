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
    public partial class frmInactiveRawmaterials : Form
    {
        IStoredProcedures objStorProc = null;
        myclasses xClass = new myclasses();
        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();
        DataSet dSet_temp = new DataSet();
        DataSet dSet = new DataSet();
        int p_id = 0;
        public frmInactiveRawmaterials()
        {
            InitializeComponent();
        }

        private void frmInactiveRawmaterials_Load(object sender, EventArgs e)
        {
            objStorProc = xClass.g_objStoredProc.GetCollections();

            load_micro();

            txtItemAddedBy.Text = userinfo.emp_name.ToUpper();
        }



        public void load_micro()
        {


                string mcolumns = "test,item_code,item_description,Category,item_group,RESERVED,ONHAND,buffer_of_stocks,price,REPACK,RECEIVING";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
                pointer_module.populateModule(dsetHeader, dgv_table, mcolumns, "raw_materials_not_active");
                //lblrecords.Text = dgv_table.RowCount.ToString();
         

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
            showValue();
        }


        void showValue()
        {

            if (dgv_table.RowCount > 0)
            {
                if (dgv_table.CurrentRow != null)
                {
                    if (dgv_table.CurrentRow.Cells["item_id"].Value != null)
                    {

                        txtItemCode.Text = dgv_table.CurrentRow.Cells["item_code"].Value.ToString();


                    }
                }
            }

        }


        void AddedSuccessUpdate()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Raw Material Activated Successfully!";
            popup.ContentColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Green;
            popup.Popup();
            //popup.AnimationDuration = 1000;
            //popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);

            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }

        private void dgv_table_DoubleClick(object sender, EventArgs e)
        {

            //if (MetroFramework.MetroMessageBox.Show(this, "Are you sure that you want to save the Data as Active? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            //{


            //    dSet.Clear();
            //    ///   dSet = objStorProc.rdf_sp_supplier(p_id, txtSupplier.Text.Trim(), txtContactNo.Text.Trim(), txtAddress.Text.Trim(), txtEmailAddress.Text.Trim(), "edit");
            //    dSet = objStorProc.rdf_sp_new_micro(p_id, 0, txtItemCode.Text.Trim(), 0, txtItemAddedBy.Text.Trim(), "NULL", "NULL", "", "NULL", "BULLY", "deliver", txtItemAddedBy.Text.Trim(), "BULLty", "", "", "", "", "activated");


            //    AddedSuccessUpdate();
            //    frmInactiveRawmaterials_Load(sender, e);
            //}

            //else
            //{

            //    return;
            //}

        }
    }
}
