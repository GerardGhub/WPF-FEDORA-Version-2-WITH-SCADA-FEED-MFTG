using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFFDR
{
    public partial class frmBufferedInventory : Form
    {
        myclasses xClass = new myclasses();
        myglobal pointer_module = new myglobal();
        IStoredProcedures objStorProc = null;
        DataSet dsetHeader = new DataSet();
        DataSet dSet = new DataSet();
        DataSet dset_offense = new DataSet();

     
     
  

        frmMenu Mainmenu;
        Boolean ready = false;

        DataSet dSet_temp = new DataSet();

        public frmBufferedInventory()
        {
            InitializeComponent();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddNewRawMaterial_Load(object sender, EventArgs e)
        {
            objStorProc = xClass.g_objStoredProc.GetCollections();
          
            DisableButton();
            loadSupplier();
            loadClassification();
            loadCategory();
            txtItemCode.Focus();
            txtItemCode.Select();
            txtItemAddedBy.Text = userinfo.emp_name.ToUpper();
            txtDateAdded.Text = Convert.ToString(DateTime.Now);
            Mainmenu = new frmMenu();

            load_all_materials();
            load_micro();
            load_macro();
        }

        public void load_micro()
        {
            string mcolumns = "test,item_code,item_description,Category,item_group,buffer_of_stocks,ONHAND,RESERVED,DIF,TenPercent";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgv_table, mcolumns, "micro_raw_materialsnewbufferview");
            lblrecords.Text = dgv_table.RowCount.ToString();

        }

        public void load_all_materials()
        {
            string mcolumns = "test,item_code,item_description,Category,item_group,qty_repack_available,qty_production,qty_repack,buffer_of_stocks";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgv_all, mcolumns, "all_materials_buffered");
            lblrecords3.Text = dgv_all.RowCount.ToString();

        }

        public void load_macro()
        {
            string mcolumns = "test,item_code,item_description,Category,item_group,MACREPACK,buffer_of_stocks,ONHAND,RESERVED,DIF,TenPercent";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgv_table_macro, mcolumns, "micro_raw_materialsnewbufferviewmac");
            lblrecords2.Text = dgv_table_macro.RowCount.ToString();
        }



        public void loadSupplier()
        {
            ready = false;

            xClass.fillComboBox(cboSupplier, "my_supplier_rdf", dSet);
            // displayData(Convert.ToInt32(cboDepartment.SelectedValue.ToString()));

            ready = true;

        }

        public void loadClassification()
        {
            ready = false;

            xClass.fillComboBox(cboClassification, "rdf_classification", dSet);
            // displayData(Convert.ToInt32(cboDepartment.SelectedValue.ToString()));

            ready = true;

        }

        public void loadCategory()
        {
            ready = false;

            xClass.fillComboBox(cbocategory, "rdf_category", dSet);
            // displayData(Convert.ToInt32(cboDepartment.SelectedValue.ToString()));

            ready = true;

        }
        public void DisableButton()
        {
            //txtCategory.Enabled = false;
            txtDateAdded.Enabled = false;
            txtItemAddedBy.Enabled = false;
            txtstock.Enabled = false;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //mode = "add";
            //if (txtDescription.Text.Trim() == string.Empty)
            //{
            //    MessageBox.Show("Please enter Description", "Item Description", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}



            //if (txtReorderLevel.Text.Trim() == string.Empty)
            //{
            //    MessageBox.Show("Please enter Contact Details", "Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //else
            //{
            //    if (saveMode())
            //    {
            //       /// loadSupplier();
            //        string tmode = mode;

            //        if (tmode == "add")
            //        {
            //            //  dgv1.CurrentCell = dgv1[0, dgv1.Rows.Count - 1];

            //            MessageBox.Show("Raw Materials Added SuccesFully.", "Supplier", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            Mainmenu.load_micro();
            //            Mainmenu.Refresh();
            //            this.Close();
            //        }
            //        else
            //        {
            //          //  dgv1.CurrentCell = dgv1[0, temp_hid];
            //        }

            //        /// btnCancel_Click(sender, e);

            //    }
            //    else
            //        MessageBox.Show("Failed");
            //    //frmMenu sa = new frmMenu();

            //    //sa.ActivitiesLogs(userinfo.emp_name + "update offenses");
            //}
        }


        //public bool saveMode()
        //{

        //    //if (mode == "add")
        //    //{
        //    //    dSet.Clear();
        //    //    dSet = objStorProc.rdf_sp_new_micro(0, Convert.ToInt32(cbocategory.SelectedValue.ToString()), txtItemCode.Text, 0, txtDescription.Text, "", "", "", "","","", "", "", "","", "getbyname");

        //    //    if (dSet.Tables[0].Rows.Count > 0)
        //    //    {
        //    //        MessageBox.Show("Raw Material is already added.", "Raw Materials", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    //        txtDescription.Focus();
        //    //        return false;
        //    //    }
        //    //    else
        //    //    {
        //    //        dSet.Clear();
        //    //        dSet = objStorProc.rdf_sp_new_micro(0, Convert.ToInt32(cbocategory.SelectedValue.ToString()), txtItemCode.Text.Trim(), Convert.ToInt32(cboSupplier.SelectedValue.ToString()), txtDescription.Text.Trim(), cboClassification.Text.Trim(), txtReorderLevel.Text.Trim(), txtDateAdded.Text.Trim(), txtExpirationDetails.Text.Trim(), txtLocation.Text.Trim(), txtDeliveryDetails.Text.Trim(), txtItemAddedBy.Text.Trim(), txtBag.Text.Trim(),"","", "add");

        //    //        return true;
        //    //    }
        //    //}
        //    //else if (mode == "edit")
        //    //{
        //    //    dSet.Clear();
        //    //   /// dSet = objStorProc.rdf_sp_supplier(0, txtSupplier.Text, txtContactNo.Text, txtAddress.Text, txtEmailAddress.Text, "getbyname");

        //    //    dSet_temp.Clear();
        //    //   /// dSet_temp = objStorProc.rdf_sp_supplier(p_id, txtSupplier.Text, txtContactNo.Text, txtAddress.Text, txtEmailAddress.Text, "getbyid");

        //    //    if (dSet.Tables[0].Rows.Count > 0)
        //    //    {
        //    //        int tmpID = Convert.ToInt32(dSet.Tables[0].Rows[0][0].ToString());
        //    //        if (tmpID == p_id)
        //    //        {
        //    //            dSet.Clear();
        //    //         ///   dSet = objStorProc.rdf_sp_supplier(p_id, txtSupplier.Text.Trim(), txtContactNo.Text.Trim(), txtAddress.Text.Trim(), txtEmailAddress.Text.Trim(), "edit");


        //    //            return true;
        //    //        }
        //    //        else
        //    //        {
        //    //            MessageBox.Show("Offense code is already added.", "Offense", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    //            txtDescription.Focus();
        //    //            return false;
        //    //        }
        //    //    }
        //    //    else
        //    //    {
        //    //        dSet.Clear();
        //    /////        dSet = dSet = objStorProc.rdf_sp_supplier(p_id, txtSupplier.Text.Trim(), txtContactNo.Text.Trim(), txtAddress.Text.Trim(), txtEmailAddress.Text.Trim(), "edit");


        //    //        return true;
        //    //    }
        //    //}
        //    //else if (mode == "delete")
        //    //{
        //    //    dSet.Clear();
        //    //    dSet = objStorProc.rdf_sp_supplier(p_id, "", "", "", "", "delete");

        //    //    //dSet_temp.Clear();
        //    //    //dSet_temp = objStorProc.sp_positions(p_id,0,"","delete");

        //    //    return true;
        //    //}
        //    //return false;
        //}

        private void txtReorderLevel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
     (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void cmbFinalView_SelectedValueChanged(object sender, EventArgs e)
        {
            if(cmbFinalView.Text== "Micro Materials Inventory")
            {
                dgv_table.Visible = true;
                lblrecords.Visible = true;
                lblrecords3.Visible = false;
                dgv_table_macro.Visible = false;
                lblrecords2.Visible = false;
                dgv_all.Visible = false;
            }
         else if(cmbFinalView.Text == "Macro Materials Inventory")
            {
                dgv_table.Visible = false;
                lblrecords.Visible = false;
                lblrecords3.Visible = false;
                dgv_table_macro.Visible = true;
                lblrecords2.Visible = true;
                dgv_all.Visible = false;
            }

            else
            {
                lblrecords3.Visible = true;
                dgv_all.Visible = true;
                lblrecords2.Visible = false;
                lblrecords.Visible = false;
                dgv_table_macro.Visible = false;
                dgv_table.Visible = false;

            }

        }

        private void dgv_table_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {
                if (dgv_table.Columns[e.ColumnIndex].Name.ToLower().Contains("qty_repack_available"))
                {
                    if (e.Value.ToString() != "")
                    {
                        double d = double.Parse(e.Value.ToString());
                        e.Value = d.ToString("n0");
                    }
                }
            }

            if (e.ColumnIndex > 0)
            {
                if (dgv_table.Columns[e.ColumnIndex].Name.ToLower().Contains("qty_production"))
                {
                    if (e.Value.ToString() != "")
                    {
                        double d = double.Parse(e.Value.ToString());
                        e.Value = d.ToString("n0");
                    }
                }
            }


            if (e.ColumnIndex > 0)
            {
                if (dgv_table.Columns[e.ColumnIndex].Name.ToLower().Contains("buffer_of_stocks"))
                {
                    if (e.Value.ToString() != "")
                    {
                        double d = double.Parse(e.Value.ToString());
                        e.Value = d.ToString("n0");
                    }
                }
            }




            //foreach (DataGridViewRow row in dgv_table.Rows)
            //{
            //    if (Convert.ToDouble(row.Cells["buffer_of_stocks"].Value) > Convert.ToDouble(row.Cells["qty_production"].Value))
            //    {
            //        //row.Cells["buffer_of_stocks"].Style.BackColor = Color.LightGreen;
            //        row.Cells["buffer_of_stocks"].Style.BackColor = Color.LightSalmon;
            //    }
            //    else if (Convert.ToDouble(row.Cells["buffer_of_stocks"].Value) < Convert.ToDouble(row.Cells["qty_production"].Value))
            //    {
            //        // row.DefaultCellStyle.BackColor = Color.LightSalmon; // Use it in order to colorize all cells of the row

            //        //row.Cells["buffer_of_stocks"].Style.BackColor = Color.LightSalmon;
            //    }
            //}

            //Pussy man
            foreach (DataGridViewRow row in dgv_table.Rows)
            {
                if (Convert.ToDouble(row.Cells["TenPercent2"].Value) > 0 && Convert.ToDouble(row.Cells["TenPercent2"].Value) < 0.1)
                {

                    row.Cells["buffer_of_stocks"].Style.BackColor = Color.Yellow;
                }


                else if (Convert.ToDouble(row.Cells["TenPercent2"].Value) <= 0)
                {
                    row.Cells["buffer_of_stocks"].Style.BackColor = Color.Red;
                }

                else if (Convert.ToDouble(row.Cells["TenPercent2"].Value) > 0.1)
                {
                    row.Cells["buffer_of_stocks"].Style.BackColor = Color.White;
                }



            }












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

        private void dgv_table_macro_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void dgv_table_macro_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {
                if (dgv_table_macro.Columns[e.ColumnIndex].Name.ToLower().Contains("qty_repack_available2"))
                {
                    if (e.Value.ToString() != "")
                    {
                        double d = double.Parse(e.Value.ToString());
                        e.Value = d.ToString("n0");
                    }
                }
            }

            if (e.ColumnIndex > 0)
            {
                if (dgv_table_macro.Columns[e.ColumnIndex].Name.ToLower().Contains("qty_production2"))
                {
                    if (e.Value.ToString() != "")
                    {
                        double d = double.Parse(e.Value.ToString());
                        e.Value = d.ToString("n0");
                    }
                }
            }


            if (e.ColumnIndex > 0)
            {
                if (dgv_table_macro.Columns[e.ColumnIndex].Name.ToLower().Contains("buffer_of_stocks2"))
                {
                    if (e.Value.ToString() != "")
                    {
                        double d = double.Parse(e.Value.ToString());
                        e.Value = d.ToString("n0");
                    }
                }
            }



            //Pussy man
            foreach (DataGridViewRow row in dgv_table_macro.Rows)
            {
                if (Convert.ToDouble(row.Cells["TenPercent"].Value) > 0 && Convert.ToDouble(row.Cells["TenPercent"].Value) < 0.1)
                {

                    row.Cells["buffer_of_stocks2"].Style.BackColor = Color.Yellow;
                }
            

                else if (Convert.ToDouble(row.Cells["TenPercent"].Value) <= 0)
                {
                    row.Cells["buffer_of_stocks2"].Style.BackColor = Color.Red;
                }

                else if (Convert.ToDouble(row.Cells["TenPercent"].Value) > 0.1)
                {
                    row.Cells["buffer_of_stocks2"].Style.BackColor = Color.White;
                }



            }
















        }

        private void cmbFinalView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgv_all_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void lblnearly_Click(object sender, EventArgs e)
        {
            frmNearlyExpired a = new frmNearlyExpired();
            a.ShowDialog();
        }
    }
}
