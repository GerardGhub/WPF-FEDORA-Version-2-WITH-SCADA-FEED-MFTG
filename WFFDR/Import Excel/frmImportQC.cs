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
    public partial class frmImportQC : Form
    {
        // private object tableCollection;

        myclasses xClass = new myclasses();

        IStoredProcedures objStorProc = null;
        int p_id = 0;
        //  private object tableCollection; // hello
        string mode = ""; //mymode
        Boolean ready = false;
        DataSet dSet = new DataSet();
        DataSet dSets = new DataSet();
        DataSet dSet_temp = new DataSet();
        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();
        public frmImportQC()
        {
            InitializeComponent();
        }

        private void frmImportQC_Load(object sender, EventArgs e)
        {
            // Calling the Stored PROC 
            objStorProc = xClass.g_objStoredProc.GetCollections();
            IndexLoad();
            load_Schedules();
            load_checklist();
            lblx1.Text = (float.Parse(lbltotalprod.Text) * 1).ToString();
            dataGridView3.Visible = false;
            lblfinalcount.Visible = false;
            lbltotalprod.Visible = false;
            lblx1.Visible = false;
            dgv_table.Columns[0].Width = 70;// The id column 
            dgvChecklist.Visible = false;
            lbldescription.Visible = false;
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
        public void load_Schedules()
        {
            string mcolumns = "po_sum_id,pr_number";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dataGridView3, mcolumns, "PoDataCount");
            lbltotalprod.Text = dataGridView3.RowCount.ToString();
            // textBox1.Text = dgv_table.RowCount.ToString();

        }
        public void load_checklist()
        {
            string mcolumns = "po_sum_id,item_code";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgvChecklist, mcolumns, "POGetChecklist");
            lblrecord.Text = dgvChecklist.RowCount.ToString();
            // textBox1.Text = dgv_table.RowCount.ToString();

        }

        
        void IndexLoad()
        {

            txtdatenow.Text = DateTime.Now.ToString("dd-MM-yyyy");
            // TODO: This line of code loads data into the 'hr_bakDataSet.rdf_po_summary_rpt' table. You can move, or remove it, as needed.
            this.rdf_po_summary_rptTableAdapter.Fill(this.hr_bakDataSet.rdf_po_summary_rpt);
            //this.WindowState = FormWindowState.Maximized;
            objStorProc = xClass.g_objStoredProc.GetCollections();
        }
        private void cboSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {



                DataTable dt = tableCollection[cboSheet.SelectedItem.ToString()];
                // dgv_table.DataSource = dt;
                if (dt != null)
                {
                    List<import_po_summary> Import_Po_Summarys = new List<import_po_summary>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        import_po_summary Import_Po_Summary = new import_po_summary();
                        // Import_Po_Summary.po_sum_id = dt.Rows[i]["po_sum_id"].ToString();
                        Import_Po_Summary.pr_number = dt.Rows[i]["Pr Number"].ToString();
                        Import_Po_Summary.pr_date = dt.Rows[i]["PR Date"].ToString();
                        Import_Po_Summary.po_number = dt.Rows[i]["PO Number"].ToString();
                        Import_Po_Summary.po_date = dt.Rows[i]["PO Date"].ToString();
                        Import_Po_Summary.item_code = dt.Rows[i]["Item Code"].ToString();
                        Import_Po_Summary.item_description = dt.Rows[i]["Item Description"].ToString();
                        Import_Po_Summary.qty_ordered = dt.Rows[i]["Qty Ordered"].ToString();
                        Import_Po_Summary.qty_delivered = dt.Rows[i]["Qty Delivered"].ToString();
                        Import_Po_Summary.qty_billed = dt.Rows[i]["Qty Billed"].ToString();
                        Import_Po_Summary.qty_uom = dt.Rows[i]["UOM"].ToString();
                        Import_Po_Summary.unit_price = dt.Rows[i]["Unit Price"].ToString();
                        Import_Po_Summary.vendor_name = dt.Rows[i]["Vendor Name"].ToString();
                        //Import_Po_Summary.import_date = dt.Rows[i]["import_date"].ToString();
                        Import_Po_Summarys.Add(Import_Po_Summary);
                    }
                    rdfposummaryrptBindingSource.DataSource = Import_Po_Summarys;
                }


            }

                   
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }



}



DataTableCollection tableCollection;
        private void btnbrowse_Click(object sender, EventArgs e)
        {
           // using(OpenFileDialog openFileDialog=new OpenFileDialog() { Filter="Excel 97-2003 Workbook|*.xls|Excel Workbook|*.xlsx" })
            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx|Excel 97-2003 Workbook|*.xls" })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtFilename.Text = openFileDialog.FileName;
                    using(var stream = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
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


        void HollowUploading()
        {
            //string connectionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
            String connectionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            DapperPlusManager.Entity<import_po_summary>().Table("rdf_po_summary_rpt_hollow");
            List<import_po_summary> Import_Po_Summarys = rdfposummaryrptBindingSource.DataSource as List<import_po_summary>;
            if (Import_Po_Summarys != null)
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                  db.BulkInsert(Import_Po_Summarys);
                }
            }


            //MessageBox.Show("Feedmill PO Summary Reports Succesfully Upload !!");
            //txtFilename.Text = "";
            //start
            dSet.Clear();
            dSet = objStorProc.rdf_sp_prod_schedules(0, lblitemcode.Text.Trim(), "", "", "","","", "", "","","", "","", "existsornotpohollow");

            if (dSet.Tables[0].Rows.Count > 0)
            {
                dSet.Clear();
                dSet = objStorProc.rdf_sp_prod_schedules(0, "", "", "", "", "", "", "","","","","","", "DeletepoHollow");
                btnlessthan_Click(new object(), new System.EventArgs());
            }
            else
            {

                dSet.Clear();
                dSet = objStorProc.rdf_sp_prod_schedules(0, "", "", "", "", "", "", "","","","","","", "DeletepoHollow");

                ItemCodeNotExist();
                return;
            }


        }




        void ItemCodeNotExist()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = " Error Found Unidentified Item Code " + lblitemcode.Text + " for " + lbldescription.Text + "!";
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






        private void btnimport_Click(object sender, EventArgs e)
        {

            //HollowUploading();
     

          


            try
            {
                // string connectionString = "Server=.;Database=Fedoramain;User Id=;Password=;";
                //string connectionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
                String connectionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
                DapperPlusManager.Entity<import_po_summary>().Table("rdf_po_summary_rpt");
                List<import_po_summary> Import_Po_Summarys = rdfposummaryrptBindingSource.DataSource as List<import_po_summary>;
                    if (Import_Po_Summarys != null)
                {
                    using(IDbConnection db = new SqlConnection(connectionString))
                    {
                        db.BulkInsert(Import_Po_Summarys);
                    }
                }


                //MessageBox.Show("Feedmill PO Summary Reports Succesfully Upload !!");
                //txtFilename.Text = "";


















                mode = "addy";

                if (cboSheet.Text.Trim() == string.Empty)
                {
                    BrowseNotif();
                    //MessageBox.Show("Please Select the DataSheet That you want to Import In Fedora System", "Select and Sheet", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (saveMode())
                    {
                        /// loadSupplier();
                        string tmode = mode;

                        if (tmode == "addy")
                        {
                            //  dgv1.CurrentCell = dgv1[0, dgv1.Rows.Count - 1];



                            //UploadSuccess(); //Gerard
                            IndexLoad();
                            cboSheet.Text = "";

                            Hideview();
                            //////MessageBox.Show("Raw Materials Received SuccesFully.", "Raw Material Received", MessageBoxButtons.OK, MessageBoxIcon.Information);





                        }
                        else
                        {
            
                        }

               

                    }
                    else
                        MessageBox.Show("Failed");
         
                }










            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            load_Schedules();
           lblfinalcount.Text = (float.Parse(lbltotalprod.Text) - float.Parse(lblx1.Text)).ToString();
            UploadSuccess(); //Gerard
            lblx1.Text = (float.Parse(lbltotalprod.Text) * 1).ToString();
        }



        void BrowseNotif()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
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

        public bool saveMode()
        {

            if (mode == "addy")
            {
                dSet.Clear();
                  dSet = objStorProc.rdf_sp_new_micro_received(0, "","","", "","", "","", "", "", "", "", "", "", "", "", "", "", "", "","","","","","","","","","","","","","","","","","","","","","", "getbyname");

                if (dSet.Tables[0].Rows.Count > 0)
                {
                    //MessageBox.Show("Raw Material is already added.", "Raw Materials", MessageBoxButtons.OK, MessageBoxIcon.Information);

               
                    //calling the dashboard counts

                    return false;
                }

                else
                {
                    dSet.Clear();
                    dSet = objStorProc.rdf_sp_new_micro_received(0, "","","", "", "", "", "", "", "", "","", "", "","", "", "", "", "", "","","","","","","","","","","","","","","","","","","","","","", "addy");
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




        private void dgv_table_CurrentCellChanged(object sender, EventArgs e)
        {
            //  showValue();



            if (dgv_table.CurrentRow != null)
            {
                if (dgv_table.CurrentRow.Cells["item_code"].Value != null)
                {
                    //p_id = Convert.ToInt32(dgv1stView.CurrentRow.Cells["prod"].Value);

                    lblitemcode.Text = dgv_table.CurrentRow.Cells["item_code"].Value.ToString();
                    lbldescription.Text = dgv_table.CurrentRow.Cells["item_description2"].Value.ToString();

                }

            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            // using(OpenFileDialog openFileDialog=new OpenFileDialog() { Filter="Excel 97-2003 Workbook|*.xls|Excel Workbook|*.xlsx" })
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtFilename.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please Browse an Excel File PO Summary first and Upload into Fedora", "FeedMill PO Summary Report ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnbrowse.Focus();
                btnbrowse.Select();
                return;
            }
            try
            {
                // string connectionString = "Server=.;Database=Fedoramain;User Id=;Password=;";
                //string connectionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
                String connectionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
                DapperPlusManager.Entity<import_po_summary>().Table("rdf_po_summary_rpt");
                List<import_po_summary> Import_Po_Summarys = rdfposummaryrptBindingSource.DataSource as List<import_po_summary>;
                if (Import_Po_Summarys != null)
                {
                    using (IDbConnection db = new SqlConnection(connectionString))
                    {
                        db.BulkInsert(Import_Po_Summarys);
                    }
                }
                MessageBox.Show("Finish Na!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnrejections_Click(object sender, EventArgs e)
        {
            frmQCImportPending pendingimport = new frmQCImportPending();
            pendingimport.ShowDialog();
        }

        private void txtFilename_TextChanged(object sender, EventArgs e)
        {
            //bunifuUpload.Visible = true;
            bunifuThinButton24.Visible = true;
        }

        private void bunifuUpload_Click(object sender, EventArgs e)
        {
      
            btnimport_Click(sender,e);
        }

        private void bunifuBrowse_Click(object sender, EventArgs e)
        {
            btnbrowse_Click(sender,e);
        }

        private void bunifuStartImport_Click(object sender, EventArgs e)
        {
            bunifuThinButton21.Visible = true;
            bunifuStartImport.Visible = false;
            label10.Visible = true;
            label6.Visible = true;
            bunifuBrowse.Visible = true;
            bunifuThinButton211.Visible = true;
            bunifuThinButton22.Visible = true;
            txtFilename.Visible = true;
            cboSheet.Visible = true;
            dgv_table.Visible = true;
            lbltotal.Visible = true;
                lblrecord.Visible = true;
        }

        void UploadSuccess()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = ""+lblfinalcount.Text+" LINES SUCCESSFULLY LOADED !";
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

            load_checklist();
            bunifuThinButton24.Visible = false;
        }



        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Cancel the PO Importing ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                label10.Visible = false;
                label6.Visible = false;
                bunifuBrowse.Visible = false;
                bunifuThinButton211.Visible = false;
                bunifuThinButton22.Visible = false;
                txtFilename.Visible = false;
                cboSheet.Visible = false;
                dgv_table.Visible = false;
                bunifuStartImport.Visible = true;
                bunifuThinButton21.Visible = false;
                lbltotal.Visible = false;
                lblrecord.Visible = false;
            }
            else
            {

                return;
            }
        }

        void Hideview()
        {

            label10.Visible = false;
            label6.Visible = false;
            bunifuBrowse.Visible = false;
            bunifuThinButton211.Visible = false;
            bunifuThinButton22.Visible = false;
            txtFilename.Visible = false;
            cboSheet.Visible = false;
            dgv_table.Visible = false;
            bunifuStartImport.Visible = true;
            bunifuThinButton21.Visible = false;
            bunifuUpload.Visible = false;
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            metroButton1_Click(sender, e);
        }

        private void dgv_table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dgv_table_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {
                if (dgv_table.Columns[e.ColumnIndex].Name.ToLower().Contains("qty_ordered"))
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
                if (dgv_table.Columns[e.ColumnIndex].Name.ToLower().Contains("qty_delivered"))
                {
                    if (e.Value.ToString() != "")
                    {
                        double d = double.Parse(e.Value.ToString());
                        e.Value = d.ToString("n0");
                    }
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

        private void btnlessthan_Click(object sender, EventArgs e)
        {

            if (dgv_table.Rows.Count >= 1)
            {


                int i = dgv_table.CurrentRow.Index + 1;
                if (i >= -1 && i < dgv_table.Rows.Count)
                    dgv_table.CurrentCell = dgv_table.Rows[i].Cells[1];




                //dgvMaster_Click(sender,e);
                else
                {
                    //LastLine();
                    bunifuUpload_Click(sender, e);

                    return;
                }
            }
            btnproxy_Click(sender, e);
        }

        private void btnproxy_Click(object sender, EventArgs e)
        {
            bunifuThinButton23_Click(sender, e);
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            HollowUploading();
     
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Upload the QA Checklist ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                bunifuThinButton23_Click(sender, e);
            }
            else
            {
                return;
            }

            }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            metroButton3_Click(sender, e);
        }

        private void cboSheet_SelectedValueChanged(object sender, EventArgs e)
        {
            bunifuThinButton24.Visible = true;
        }
    }
}


