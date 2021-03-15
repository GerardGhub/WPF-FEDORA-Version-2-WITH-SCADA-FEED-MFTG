using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Z.Dapper.Plus;
using Tulpep.NotificationWindow;


namespace WFFDR
{
    public partial class frmImportRawMaterials : Form
    {
        myclasses xClass = new myclasses();

        IStoredProcedures objStorProc = null;
        int p_id = 0;
        //  private object tableCollection; // hello
        string mode = ""; //mymode
        Boolean ready = false;
        DataSet dSet = new DataSet();
        DataSet dSets = new DataSet();
        DataSet dSet_temp = new DataSet();



        public frmImportRawMaterials()
        {
            InitializeComponent();
        }

        private void btnbrowse_Click(object sender, EventArgs e)
        {

            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx|Excel 97-2003 Workbook|*.xls" })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtFilename.Text = openFileDialog.FileName;
                    using (var stream = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                            });
                            tableCollection = result.Tables;
                            cboSheet.Items.Clear();
                            foreach (DataTable table in tableCollection)
                                cboSheet.Items.Add(table.TableName); // add sheet into combo box
                        }
                    }

                }

            }
        }

        private void frmImportRawMaterials_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hr_bakDataSet.rdf_materials' table. You can move, or remove it, as needed.
            this.rdf_materialsTableAdapter.Fill(this.hr_bakDataSet.rdf_materials);
            //this.WindowState = FormWindowState.Maximized;
                        dgv_table.Columns[0].Width = 100;// The id column 
            objStorProc = xClass.g_objStoredProc.GetCollections();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle = cp.ExStyle | 0x2000000;
                return cp;
            }
        }

        private void cboSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

    
            DataTable dt = tableCollection[cboSheet.SelectedItem.ToString()];
            //dgv_table.DataSource = dt;
            if (dt != null)
            {
                List<raw_materials_uploader> Import_Po_Summarys = new List<raw_materials_uploader>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    raw_materials_uploader Import_Po_Summary = new raw_materials_uploader();
                    //Import_Po_Summary.recipe_id = dt.Rows[i]["recipe_id"].ToString();
                    Import_Po_Summary.item_code = dt.Rows[i]["ITEM CODE"].ToString();
                    Import_Po_Summary.item_description = dt.Rows[i]["DESCRIPTION"].ToString();
                    Import_Po_Summary.Category = dt.Rows[i]["CATEGORY"].ToString();
                    Import_Po_Summary.item_group = dt.Rows[i]["GROUP"].ToString();
          


                    //Import_Po_Summary.import_date = dt.Rows[i]["import_date"].ToString();
                    Import_Po_Summarys.Add(Import_Po_Summary);
                }
                rdfmaterialsBindingSource.DataSource = Import_Po_Summarys;
            }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
 

        DataTableCollection tableCollection;

        private void btnimport_Click(object sender, EventArgs e)
        {



            try
            {
                // string connectionString = "Server=.;Database=Fedoramain;User Id=;Password=;";
                //string connectionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
                String connectionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
                DapperPlusManager.Entity<raw_materials_uploader>().Table("rdf_raw_materials");
                List<raw_materials_uploader> Import_Po_Summarys = rdfmaterialsBindingSource.DataSource as List<raw_materials_uploader>;
                if (Import_Po_Summarys != null)
                {
                    using (IDbConnection db = new SqlConnection(connectionString))
                    {
                        db.BulkInsert(Import_Po_Summarys);
                    }
                }


                SavedNotify();
                //txtFilename.Text = "";
                bunifuUpload.Visible = false;


                mode = "addyrawmaterials";

                if (cboSheet.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please Select the DataSheet That you want to Import In Fedora System", "Select and Sheet", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (saveMode())
                    {
                        /// loadSupplier();
                        string tmode = mode;

                        if (tmode == "addyrawmaterials")
                        {
                            //  dgv1.CurrentCell = dgv1[0, dgv1.Rows.Count - 1];




         



                        }
                        else
                        {

                        }



                    }
                    else
                        MessageBox.Show("Failed");

                }




























            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public bool saveMode()
        {

            if (mode == "addyrawmaterials")
            {
                dSet.Clear();
                dSet = objStorProc.rdf_sp_new_micro_received(0, "","","","", "", "", "", "", "", "", "", "","", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "","","","","", "getbyname");

                if (dSet.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Raw Material is already added.", "Raw Materials", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //calling the dashboard counts

                    return false;
                }

                else
                {
                    dSet.Clear();
                    dSet = objStorProc.rdf_sp_new_micro_received(0, "","","","", "", "", "", "", "", "", "", "", "", "", "", "","", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "","","","","", "addyrawmaterials");
                    //    dSet = objStorProc.rdf_sp_new_micro(0, Convert.ToInt32(cbocategory.SelectedValue.ToString()), txtItemCode.Text.Trim(), Convert.ToInt32(cboSupplier.SelectedValue.ToString()), txtDescription.Text.Trim(), cboClassification.Text.Trim(), txtReorderLevel.Text.Trim(), txtDateAdded.Text.Trim(), txtExpirationDetails.Text.Trim(), txtLocation.Text.Trim(), txtDeliveryDetails.Text.Trim(), txtItemAddedBy.Text.Trim(), "add");

                    //      dSets = objStorProc.rdf_sp_new_micro_received(0, txtID.Text.Trim(), cboCategory.Text.Trim(), txtItemCode.Text.Trim(), cboSupplier.Text.Trim(), txtItemDescription.Text.Trim(), cboclassification.Text.Trim(), txtFinalQty.Text.Trim(), dateTimePicker2.Text.Trim(), xpired.Text.Trim(), txtAddedBy.Text.Trim(), txtxp.Text.Trim(), textBox2.Text.Trim(), txtUpdatedStock.Text.Trim(), txtgood.Text.Trim(), txtreject.Text.Trim(), "add");

                    // dSets = objStorProc.rdf_sp_new_micro_updated(0, txtID.Text.Trim(), cboCategory.Text.Trim(), txtItemCode.Text.Trim(), cboSupplier.Text.Trim(), txtItemDescription.Text.Trim(), cboclassification.Text.Trim(), txtFinalQty.Text.Trim(), dateTimePicker2.Text.Trim(), xpired.Text.Trim(), txtAddedBy.Text.Trim(), txtxp.Text.Trim(),txtxp.Text.Trim(), "update");
                    return true;
                }
            }
            else if (mode == "edit")
            {
                dSet.Clear();
                /// dSet = objStorProc.rdf_sp_supplier(0, txtSupplier.Text, txtContactNo.Text, txtAddress.Text, txtEmailAddress.Text, "getbyname");

                dSet_temp.Clear();
                /// dSet_temp = objStorProc.rdf_sp_supplier(p_id, txtSupplier.Text, txtContactNo.Text, txtAddress.Text, txtEmailAddress.Text, "getbyid");

                if (dSet.Tables[0].Rows.Count > 0)
                {
                    int tmpID = Convert.ToInt32(dSet.Tables[0].Rows[0][0].ToString());
                    if (tmpID == p_id)
                    {
                        dSet.Clear();
                        ///   dSet = objStorProc.rdf_sp_supplier(p_id, txtSupplier.Text.Trim(), txtContactNo.Text.Trim(), txtAddress.Text.Trim(), txtEmailAddress.Text.Trim(), "edit");


                        return true;
                    }

                    else
                    {
                        MessageBox.Show("Offense code is already added.", "Offense", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        return false;
                    }
                }
                else
                {
                    dSet.Clear();
                    ///        dSet = dSet = objStorProc.rdf_sp_supplier(p_id, txtSupplier.Text.Trim(), txtContactNo.Text.Trim(), txtAddress.Text.Trim(), txtEmailAddress.Text.Trim(), "edit");


                    return true;
                }
            }
            else if (mode == "delete")
            {
                dSet.Clear();
                dSet = objStorProc.rdf_sp_supplier(p_id, "", "", "", "", "delete");

                //dSet_temp.Clear();
                //dSet_temp = objStorProc.sp_positions(p_id,0,"","delete");

                return true;
            }
            return false;
        }

        private void txtFilename_TextChanged(object sender, EventArgs e)
        {
            if(txtFilename.Text.Trim()==string.Empty)
            {

            }
            else
            {
                cboSheet.Enabled = true;
   
            }
        }

        private void bunifuUpload_Click(object sender, EventArgs e)
        {


            dSet.Clear();


            dSet = objStorProc.rdf_sp_bulk_data(0, txtItemCode.Text.Trim(), "", "", "", "1", "rawmaterialexist");



            if (dSet.Tables[0].Rows.Count > 0)
            {
                //MessageBox.Show("NOT RECOGNISE", "Offense", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //cboFeedCode.Focus();
                MessageBox.Show("Raw Material Already Exists '"+txtItemCode.Text+"'");

                return;
            }
            else
            {
                ////MessageBox.Show("Mali");
                //return;
            }



          

            if (dgv_table.Rows.Count >= 1)
            {
                int i = dgv_table.CurrentRow.Index + 1;
                if (i >= -1 && i < dgv_table.Rows.Count)
                   dgv_table.CurrentCell = dgv_table.Rows[i].Cells[0];
                else
                {
                    btnimport_Click(sender, e);


                    ////txtselectweight.Text = dgvAllFeedCode.CurrentRow.Cells["Quantity"].Value.ToString();
                    //timer1_Tick(sender, e);
                    //txtweighingscale.Focus();
                    return;
                }
            }

            btnoperation_Click(sender, e);


            //btnimport_Click(sender, e);
        }


        void SavedNotify()
        {

            Tulpep.NotificationWindow.PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Raw Materials Successfully Upload";
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
        private void cboSheet_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboSheet.Text.Trim() == string.Empty)
            {

            }
            else
            {
               bunifuUpload.Visible = true;

            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dgv_table_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {





        }

        private void dgv_table_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {

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

            if (dgv_table.CurrentRow != null)
            {
                if (dgv_table.CurrentRow.Cells["item_code"].Value != null)
                {
                  txtItemCode.Text = dgv_table.CurrentRow.Cells["item_code"].Value.ToString();


                }
            }

        }

        private void btnoperation_Click(object sender, EventArgs e)
        {
            bunifuUpload_Click(sender, e);
        }
    }
}
