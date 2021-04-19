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
    public partial class frmImportFormula : Form
    {

        myclasses xClass = new myclasses();

        IStoredProcedures objStorProc = null;
        int p_id = 0;
        //  private object tableCollection; // hello
        string mode = ""; //mymode
        Boolean ready = false;
        DataSet dSet = new DataSet();
        DataSet dSet2 = new DataSet();
        DataSet dSets = new DataSet();
        DataSet dSet_temp = new DataSet();

        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();
        public frmImportFormula()
        {
            InitializeComponent();
        }


        private void frmImportFormula_Load(object sender, EventArgs e)
        {
            objStorProc = xClass.g_objStoredProc.GetCollections();
            // TODO: This line of code loads data into the 'hr_bakDataSet.rdf_Formula' table. You can move, or remove it, as needed.
            this.rdf_FormulaTableAdapter.Fill(this.hr_bakDataSet.rdf_Formula);
            objStorProc = xClass.g_objStoredProc.GetCollections();
            this.rdf_FormulaTableAdapter.Fill(this.hr_bakDataSet.rdf_Formula);
            dgv_table.Columns[0].Width = 90;

            txtaddedby.Text = userinfo.emp_name.ToUpper();
            txtdatetime.Text = DateTime.Now.ToString();
            // The id column 
            //this.rdf_po_summary_rptTableAdapter.Fill(this.hr_bakDataSet.rdf_po_summary_rpt);
            //this.WindowState = FormWindowState.Maximized;
            dgvChecklist.Visible = false;
            lblx1.Visible = false;
            load_formula();
            lblx1.Text = (float.Parse(lbltotalprod.Text) * 1).ToString();
            //DataRecipeSearch();
            lblStartValidating.Text = "0";
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

        public void load_formula()
        {
            string mcolumns = "po_sum_id,item_code";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgvChecklist, mcolumns, "FormulationTotal");
            lbltotalprod.Text = dgvChecklist.RowCount.ToString();


        }

        public void load_Schedules()
        {
            string mcolumns = "po_sum_id,item_code";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgvChecklist, mcolumns, "FormulationTotal");
            lblnewrecords.Text = dgvChecklist.RowCount.ToString();

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
            try
            {

  
            DataTable dt = tableCollection[cboSheet.SelectedItem.ToString()];
            //dgv_table.DataSource = dt;
            if (dt != null)
            {
                List<formula_uploader> Import_Po_Summarys = new List<formula_uploader>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    formula_uploader Import_Po_Summary = new formula_uploader();

                    Import_Po_Summary.rp_type = dt.Rows[i]["TYPE"].ToString();
                    Import_Po_Summary.feed_code = dt.Rows[i]["FEED CODE"].ToString();
                    Import_Po_Summary.rp_feed_type = dt.Rows[i]["FEED TYPE"].ToString();

                    Import_Po_Summary.item_code = dt.Rows[i]["ITEM CODE"].ToString();
                    Import_Po_Summary.rp_description = dt.Rows[i]["DESCRIPTION"].ToString();
                    Import_Po_Summary.rp_category = dt.Rows[i]["CATEGORY"].ToString();
                    Import_Po_Summary.rp_group = dt.Rows[i]["GROUP"].ToString();
                    Import_Po_Summary.quantity = dt.Rows[i]["QTY"].ToString();

                    Import_Po_Summarys.Add(Import_Po_Summary);
                }
                rdfFormulaBindingSource.DataSource = Import_Po_Summarys;
            }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }


        DataTableCollection tableCollection;

        void HollowInsert()
        {
            // string connectionString = "Server=.;Database=Fedoramain;User Id=;Password=;";
            //string connectionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
            String connectionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            DapperPlusManager.Entity<formula_uploader>().Table("rdf_recipe_hollow");
            List<formula_uploader> Import_Po_Summarys = rdfFormulaBindingSource.DataSource as List<formula_uploader>;
            if (Import_Po_Summarys != null)
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    db.BulkInsert(Import_Po_Summarys);
                }
            }




            //start
            dSet.Clear();
            dSet = objStorProc.rdf_sp_prod_schedules(0, lblitemcode.Text, "", "", "", "", "", "","","","","","", "existsornotformulahollow");

            if (dSet.Tables[0].Rows.Count > 0)
            {


                    btnlessthan_Click(new object(), new System.EventArgs());

            }
            else
            {



                lblitemcodeerror.Text = "Error Found Unidentified Item Code " + lblitemcode.Text + " for " + lbldescription.Text + "            ";
                lblitemcodeerror.Visible = true;



                //ItemCodeNotExist();
                dSet.Clear();
                dSet = objStorProc.rdf_sp_prod_schedules(0, "", "", "", "", "", "", "","","","","","", "DeleteformulaHollow");

                //this.dgv_table.CurrentCell = this.dgv_table.Rows[0].Cells[this.dgv_table.CurrentCell.ColumnIndex];
                return;
            }







        }




        void FeedCodeAlreadyExists2()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "" + lblfeedcode.Text
                + " Found Duplicate Feed Code for " + lblfeedcode.Text + "!!!";
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








        void FeedCodeAlreadyExist()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "FeedCode Already Exists " + lblfeedcode.Text + "!";
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














        void ItemCodeExist()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "" + lblfeedcode.Text
                + " Validating Item Code " + lblitemcode.Text + " for " + lbldescription.Text + "!";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Red;
            popup.Popup();

            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);

            popup.Delay = 100;
            popup.AnimationInterval = 1;
            popup.AnimationDuration = 100;


            popup.ShowOptionsButton = true;

            this.dgv_table.CurrentCell = this.dgv_table.Rows[0].Cells[this.dgv_table.CurrentCell.ColumnIndex];
        }



        private void btnimport_Click(object sender, EventArgs e)
        {

            //HollowInsert();



            if(lblitemcodeerror.Visible==true)
            {
                ItemCodeExist();
                return;


            }




            //return;

            try
            {
                // string connectionString = "Server=.;Database=Fedoramain;User Id=;Password=;";
                //string connectionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
                String connectionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
                DapperPlusManager.Entity<formula_uploader>().Table("rdf_recipe");
                List<formula_uploader> Import_Po_Summarys = rdfFormulaBindingSource.DataSource as List<formula_uploader>;
                if (Import_Po_Summarys != null)
                {
                    using (IDbConnection db = new SqlConnection(connectionString))
                    {
                        db.BulkInsert(Import_Po_Summarys);
                    }
                }


                //MessageBox.Show("Formula Reports Succesfully Upload !!");
                //txtFilename.Text = "";


                bunifuUpload.Visible = false;



                mode = "addyformula";

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




                            //MessageBox.Show("Upload Supplier SuccesFully.", "Raw Material Received", MessageBoxButtons.OK, MessageBoxIcon.Information);





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

            load_formula();
            lblfinalcount.Text = (float.Parse(lbltotalprod.Text) - float.Parse(lblx1.Text)).ToString();
            UploadSuccess(); //Gerard
            lblx1.Text = (float.Parse(lbltotalprod.Text) * 1).ToString();
            dgv_table.Enabled = false;
            btnLastCheck_Click(sender, e);

        }

        void UploadSuccess()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "" + lblfinalcount.Text + " LINES SUCCESSFULLY LOADED !";
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
            dgv_table.Enabled = true;

        }
        private void txtFilename_TextChanged(object sender, EventArgs e)
        {
            if (txtFilename.Text.Trim() == string.Empty)
            {

            }
            else
            {
                cboSheet.Enabled = true;
            }
        }


        public bool saveMode()
        {

            if (mode == "addyformula")
            {
                dSet.Clear();
                dSet = objStorProc.rdf_sp_new_micro_received(0, "", "","","", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "getbyname");

                if (dSet.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Raw Material is already added.", "Raw Materials", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //calling the dashboard counts

                    return false;
                }

                else
                {
                    dSet.Clear();
                    dSet = objStorProc.rdf_sp_new_micro_received(0, "", "","","", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "addyformula");
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

        private void bunifuUpload_Click(object sender, EventArgs e)
        {
            btnimport_Click(sender, e);
        }

        private void cboSheet_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboSheet.Text.Trim() == string.Empty)
            {

            }
            else
            {
                //bunifuUpload.Visible = true;.Visi
                bunifuThinButton23.Visible = true;
                //this.dgv_table.CurrentCell = this.dgv_table.Rows[0].Cells[this.dgv_table.CurrentCell.ColumnIndex];
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dgv_table_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void dgv_table_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgv_table.CurrentRow != null)
            {
                if (dgv_table.CurrentRow.Cells["item_code"].Value != null)
                {
                    //p_id = Convert.ToInt32(dgv1stView.CurrentRow.Cells["prod"].Value);

                    lblitemcode.Text = dgv_table.CurrentRow.Cells["item_code"].Value.ToString();
                    lbldescription.Text = dgv_table.CurrentRow.Cells["rp_description"].Value.ToString();
                    txtFeedType.Text = dgv_table.CurrentRow.Cells["rp_feed_type"].Value.ToString();



                    lblfeedcode.Text = dgv_table.CurrentRow.Cells["feed_code"].Value.ToString();

                }

            }
        }

        private void dgv_table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnlessthan_Click(object sender, EventArgs e)
        {
            AvoidDuplicate();
            if (lblnumvalidator.Text == "1")
            {
                FeedCodeAlreadyExist();
                return;
            }
            btnproxy_Click(sender, e);
            int currentRow = dgv_table.SelectedRows[0].Index;
            if (currentRow < dgv_table.RowCount - 1)
            {
          
                dgv_table.Rows[++currentRow].Cells[0].Selected = true;
       

            }
            else
            {
                //MessageBox.Show("Takala");
                bunifuUpload_Click(sender, e);
                dSet.Clear();
                dSet = objStorProc.rdf_sp_prod_schedules(0, "", "", "", "", "", "","","", "","","","", "DeleteformulaHollow");
                return;
            }

            bunifuThinButton24_Click(sender, e);


        }


        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {


            HollowInsert();

        }

        private void btnproxy_Click(object sender, EventArgs e)
        {


            //start
            dSet.Clear();
            dSet = objStorProc.rdf_sp_prod_schedules(0, lblitemcode.Text, "","","", "", "", "", "", "","","","", "existsornotformulahollow");

            if (dSet.Tables[0].Rows.Count > 0)
            {




                }
            else
            {

                //MessageBox.Show("Hello");

                lblitemcodeerror.Text = "Error Found Unidentified Item Code " + lblitemcode.Text + " for " + lbldescription.Text + " N "+lblfeedcode.Text+"           ";
                lblitemcodeerror.Visible = true;
                //ItemCodeNotExist();
                dSet.Clear();
                dSet = objStorProc.rdf_sp_prod_schedules(0, "", "", "","","", "", "", "", "","","","", "DeleteformulaHollow");

                //this.dgv_table.CurrentCell = this.dgv_table.Rows[0].Cells[this.dgv_table.CurrentCell.ColumnIndex];
                return;
            }


            SendKeys.SendWait("{ENTER}"); // How to press enter?














        }

        private void metroButton3_Click(object sender, EventArgs e)
        {


            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Upload the Formulation ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                //    txtFeedType_TextChanged(sender, e);
                lblStartValidating.Text = "1";
                bunifuThinButton22_Click(sender, e);
                bunifuThinButton23.Visible = false;
                dgv_table.Enabled = false;
  


            }
            else
            {
                return;
            }









        }

        void AvoidDuplicate()
        {
            dSet.Clear();
            dSet = objStorProc.rdf_sp_prod_schedules(0, lblfeedcode.Text, "","","", "", "", "", "","","", "","", "formulanotexist");

            if (dSet.Tables[0].Rows.Count > 0)
            {

                lblnumvalidator.Text = "1";
         
  
            }

            else
            {

                //MessageBox.Show("MULI");
                //return;
            }
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            metroButton3_Click(sender, e);
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            AvoidDuplicate();
            if (lblnumvalidator.Text == "1")
            {
                FeedCodeAlreadyExist();
                return;
            }


            btnproxy_Click(sender, e);
            int currentRow = dgv_table.SelectedRows[0].Index;
            if (currentRow < dgv_table.RowCount - 1)
            {
           
                dgv_table.Rows[++currentRow].Cells[0].Selected = true;
  
            }
            else
            {
                //MessageBox.Show("Takala2");
                bunifuUpload_Click(sender, e);
                dSet.Clear();
                dSet = objStorProc.rdf_sp_prod_schedules(0, "", "", "", "", "", "", "","","","","","", "DeleteformulaHollow");
                return;
            }




                btnlessthan_Click(sender, e);

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {


            }

        public void DataRecipeSearch()
        {
            dgv_table_CurrentCellChanged(new object(), new System.EventArgs());
            //if (txtFilename.Text.Trim() == string.Empty)
            //{

            //}
            //else
            //{
                String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

                SqlConnection sql_con = new SqlConnection(connetionString);



                string sqlquery = "SELECT mixing_capacity,qa_corn_code,corn_type_formula FROM [dbo].[rdf_recipe] where mixing_capacity IS NOT NULL AND corn_type_formula IS NOT NULL AND qa_corn_code IS NOT NULL AND rp_feed_type = '" + txtFeedType.Text + "' ";



                sql_con.Open();
                SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
                SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
                DataTable dt = new DataTable();
                sdr.Fill(dt);
                dgvRecipeData.DataSource = dt;

                lblMytotalRecords.Text = dgvRecipeData.RowCount.ToString();

                sql_con.Close();
            //}
        }




        private void txtFeedType_TextChanged(object sender, EventArgs e)
        {
            if (lblStartValidating.Text == "1")
            {
                IterationAfterInsertTheData();
            }






        }

        public void IterationAfterInsertTheData()
        {
            DataRecipeSearch();

            dgvRecipeData_CurrentCellChanged(new object(), new System.EventArgs());
            //MessageBox.Show(txtFeedType.Text);
            if (lblMytotalRecords.Text == "0")
            {

            }

            else
            {
                txtdatetime.Text = DateTime.Now.ToString();

                String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

                SqlConnection sql_con = new SqlConnection(connetionString);



                string sqlquery = "UPDATE [dbo].[rdf_recipe] SET mixing_capacity='" + txtcapacity.Text + "', mixing_capacity_timestamp ='" + txtdatetime.Text + "', mixing_capacity_modified_by='" + txtaddedby.Text + "',corn_type_formula='" + txtcorntype.Text + "',qa_corn_code='" + txtCorn.Text + "'  WHERE rp_feed_type = '" + txtFeedType.Text + "' and not  mixing_capacity IS NOT NULL ";



                sql_con.Open();
                SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
                SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
                DataTable dt = new DataTable();
                sdr.Fill(dt);
                dgvUpdateMixingCapacity.DataSource = dt;



                sql_con.Close();
                //MessageBox.Show("Solid");
            }

        }

        private void dgvRecipeData_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgvRecipeData.CurrentRow != null)
            {
                if (dgvRecipeData.CurrentRow.Cells["mixing_capacity"].Value != null)
                {
                
                    txtcapacity.Text = dgvRecipeData.CurrentRow.Cells["mixing_capacity"].Value.ToString();
                   txtCorn.Text = dgvRecipeData.CurrentRow.Cells["qa_corn_code"].Value.ToString();
                    txtcorntype.Text = dgvRecipeData.CurrentRow.Cells["corn_type_formula"].Value.ToString();

                }

            }



        }

        private void btnLastCheck2_Click(object sender, EventArgs e)
        {
            btnLastCheck_Click(sender, e);
        }

        private void btnLastCheck_Click(object sender, EventArgs e)
        {
            txtFeedType_TextChanged(sender, e);
          
            int currentRow = dgv_table.SelectedRows[0].Index;
            if (currentRow < dgv_table.RowCount - 1)
            {

                dgv_table.Rows[++currentRow].Cells[0].Selected = true;


            }
            else
            {

                this.dgv_table.CurrentCell = this.dgv_table.Rows[0].Cells[this.dgv_table.CurrentCell.ColumnIndex];
                lblStartValidating.Text = "0";
                dgv_table.Enabled = true;
                return;
            }
            btnLastCheck2_Click(sender, e);

        }
    }
}
