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
    public partial class frmImportSupplier : Form
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


        public frmImportSupplier()
        {
            InitializeComponent();
        }

        private void frmImportSupplier_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hr_bakDataSet.rdf_supplier' table. You can move, or remove it, as needed.
            this.rdf_supplierTableAdapter.Fill(this.hr_bakDataSet.rdf_supplier);
            //this.WindowState = FormWindowState.Maximized;
            dgv_table.Columns[0].Width = 100;// The id column 
            objStorProc = xClass.g_objStoredProc.GetCollections();
        }

        void BrowseNotif()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.information;
            popup.TitleText = "Fedora Notifications";
            popup.ContentText = "Please Select the DataSheet That you want to Import In Fedora System";
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.DarkOrange;
            popup.Popup();

            popup.ContentColor = Color.Black;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.TitleColor = Color.Black;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            //popup.AnimationDuration = 1000;
            //popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);

            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


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

        private void cboSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = tableCollection[cboSheet.SelectedItem.ToString()];
            //dgv_table.DataSource = dt;
            if (dt != null)
            {
                List<upload_supplier> Import_Po_Summarys = new List<upload_supplier>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    upload_supplier Import_Po_Summary = new upload_supplier();
                    //Import_Po_Summary.recipe_id = dt.Rows[i]["recipe_id"].ToString();
                    Import_Po_Summary.supplier = dt.Rows[i]["Supplier"].ToString();
       


                    //Import_Po_Summary.import_date = dt.Rows[i]["import_date"].ToString();
                    Import_Po_Summarys.Add(Import_Po_Summary);
                }
                rdfsupplierBindingSource.DataSource = Import_Po_Summarys;
            }
        }

        DataTableCollection tableCollection;

        private void btnimport_Click(object sender, EventArgs e)
        {
            try
            {
                // string connectionString = "Server=.;Database=Fedoramain;User Id=;Password=;";
                ////string connectionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
                 String connectionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
                DapperPlusManager.Entity<upload_supplier>().Table("rdf_supplier");
                List<upload_supplier> Import_Po_Summarys = rdfsupplierBindingSource.DataSource as List<upload_supplier>;
                if (Import_Po_Summarys != null)
                {
                    using (IDbConnection db = new SqlConnection(connectionString))
                    {
                        db.BulkInsert(Import_Po_Summarys);
                    }
                }


                MessageBox.Show("Supplier Lists Reports Succesfully Upload !!");
                txtFilename.Text = "";




                mode = "addysupplier";

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

                        if (tmode == "addysupplier")
                        {
                            //  dgv1.CurrentCell = dgv1[0, dgv1.Rows.Count - 1];




                            MessageBox.Show("Upload Supplier SuccesFully.", "Raw Material Received", MessageBoxButtons.OK, MessageBoxIcon.Information);





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

            if (mode == "addysupplier")
            {
                dSet.Clear();
                dSet = objStorProc.rdf_sp_new_micro_received(0, "", "", "", "", "","","","", "", "","", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "","","","","", "getbyname");

                if (dSet.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Raw Material is already added.", "Raw Materials", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //calling the dashboard counts

                    return false;
                }

                else
                {
                    dSet.Clear();
                    dSet = objStorProc.rdf_sp_new_micro_received(0, "", "", "", "","", "", "","", "", "", "", "", "","","", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "","","","","", "addysupplier");
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

        private void bunifuBrowse_Click(object sender, EventArgs e)
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
        void UploadSuccess()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Import Supplier SuccessFully Saved !";
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
        private void bunifuUpload_Click(object sender, EventArgs e)
        {
            if (cboSheet.Text.Trim() == string.Empty)
            {
                BrowseNotif();
                //MessageBox.Show("Please Select the DataSheet That you want to Import In Fedora System", "Select and Sheet", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            try
            {
                // string connectionString = "Server=.;Database=Fedoramain;User Id=;Password=;";
                //string connectionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
                String connectionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
                DapperPlusManager.Entity<upload_supplier>().Table("rdf_supplier");
                List<upload_supplier> Import_Po_Summarys = rdfsupplierBindingSource.DataSource as List<upload_supplier>;
                if (Import_Po_Summarys != null)
                {
                    using (IDbConnection db = new SqlConnection(connectionString))
                    {
                        db.BulkInsert(Import_Po_Summarys);
                    }
                }
                UploadSuccess();

                //MessageBox.Show("Supplier Lists Reports Succesfully Upload !!");
                txtFilename.Text = "";
                bunifuUpload.Visible = false;



                mode = "addysupplier";

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

                        if (tmode == "addysupplier")
                        {
                            //  dgv1.CurrentCell = dgv1[0, dgv1.Rows.Count - 1];



                            UploadSuccess();






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

        private void bunifuStartImport_Click(object sender, EventArgs e)
        {
            bunifuThinButton21.Visible = true;
            bunifuStartImport.Visible = false;
            //label10.Visible = true;
            //label6.Visible = true;
            bunifuBrowse.Visible = true;
            bunifuThinButton211.Visible = true;
            bunifuThinButton22.Visible = true;
            txtFilename.Visible = true;
            cboSheet.Visible = true;
            label5.Visible = true;
            label7.Visible = true;
            dgv_table.Visible = true;
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            metroButton1_Click(sender, e);
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure that you want to Cancel the Supplier Importing ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
               
                bunifuBrowse.Visible = false;
                bunifuThinButton211.Visible = false;
                bunifuThinButton22.Visible = false;
                txtFilename.Visible = false;
                cboSheet.Visible = false;
                dgv_table.Visible = false;
                bunifuStartImport.Visible = true;
                bunifuThinButton21.Visible = false;
                cboSheet.Visible = true;
                label5.Visible = false;
                label7.Visible = false;
                cboSheet.Visible = false;
            }
            else
            {

                return;
            }
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

        private void cboSheet_SelectedValueChanged(object sender, EventArgs e)
        {
            if(cboSheet.Text.Trim()==string.Empty)
            {

            }
            else
            {
                bunifuUpload.Visible = true;
            }

        }

        private void dgv_table_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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
    }
}
