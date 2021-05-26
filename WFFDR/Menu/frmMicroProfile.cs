using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace WFFDR
{
    public partial class frmMicroProfile : Form
    {
        String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=hr_bak;Integrated Security=SSPI;";
        System.Media.SoundPlayer player = new System.Media.SoundPlayer();
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        //1
        IStoredProcedures objStorProc = null;
        //2
        private readonly String defaultImage = Path.GetDirectoryName(Application.ExecutablePath) + @"\Resources\Employee.png";
        private FileStream fileStream;
        private BinaryReader binaryReader;
        public Byte[] imageByte = null;

        //private string id = "";

        DataSet dSet = new DataSet();
        DataSet dSet_temp = new DataSet();
        DataSet dset_offense = new DataSet();
        DataSet dsImage = new DataSet();
        Boolean ready = false;

        string mode = "";

        Boolean lodi = false;
        //bool re = false;



        MDIParent1 parents;

        public int temp_id = 0;
        public string item_id = "";
        public string item_code = "";
        public string item_description = "";
        public string quantity = "";
        public string Category= "";
        public string classification = "";
        public string supplier = "";
        public string contact_no = "";
        public string address = "";
        public string email_address = "";
        public string item_location = "";
        public string item_remarks = "";
        public string added_by = "";
        public string total_quantity_raw = "";
    //   public string emp.added_by = "";
        public DateTime dateadded;
        public string expirationdetails;
        public string delivery_details;
        public string per_bag;
        frmMenu mainMenu;

        public String imagePath;
        private ToolTip toolTipImage = new ToolTip();

        myclasses xClass = new myclasses();
        IStoredProcedures g_objStoredProcCollection = null;

        public frmMicroProfile()
        {
            InitializeComponent();
        }

        private void frmMicroProfile_Load(object sender, EventArgs e)
        {
            btncancel.Visible = false;
            toolTipImage.AutoPopDelay = 5000;
            toolTipImage.InitialDelay = 1000;
            toolTipImage.ReshowDelay = 500;
            toolTipImage.ShowAlways = true;


            parents = new MDIParent1();



            mainMenu = new frmMenu();
            VisibleFalse();

            g_objStoredProcCollection = xClass.g_objStoredProc.GetCollections();

            objStorProc = xClass.g_objStoredProc.GetCollections();
    
            dgv1_CurrentCellChanged(sender, e);

          loadSupplier(); //4
            loadrdfCategory();
           loadClassification(); //3
           loadFeedCode(); //2
            NoEdit();  //1
      //     loadImage();
            loadDepartment(); //sample lang vest
            txtnumber.Enabled = false;
            txtItemCode.Enabled = false;

            if (myglobal.mode == "edit")
            {
                txtnumber.Text = item_id;
               txtItemCode.Text = item_code;
                txtItemDescription.Text = item_description;
                txtquantity.Text = quantity;
             cbocategory.Text = Category;
            cboclassification.Text = classification;
               txtSupplierName.Text = supplier;
                cboSupplier.Text = supplier;
                totalQty.Text = total_quantity_raw;
                txtSupplierNumber.Text = contact_no;
              txtAddressfinal.Text = address;
                txtEmail_Address.Text = email_address;
                txtLocation.Text = item_location;
                txtItemRemarks.Text = item_remarks;
             txtAddedBy.Text = added_by;
   ////date_added.Value = dateadded; lako kepa 2/19/2020
                txtPerBag.Text = per_bag;
                ////expiration_details.Value = expirationdetails;
                ///
                txtexpiration_details.Text = expirationdetails;
                txtDeliveryDetails.Text = delivery_details;
             //   cboDepartment.Text = department;
           //     cboSection.Text = section;
            //    cboPosition.Text = position;
            //    cbostatus.Text = employee_status;
           //     cbotax.Text = tax_name;
           //     date_hired.Value = datehired;
            ////    birth_date.Value = birthdate;
          //      cboworker.Text = workers_name;
       
            //    date_regularization.Value = dateregularization;
//txtphilhealth.Text = philhealth_no;
            //    txthdmf.Text = hdmf_no;
           //     txtrtn.Text = hdmf_rtn;
             //   txtsalaryrate.Text = salaryrate;
             //   txtstructure.Text = salarystructure;
            //    cbosalarytype.Text = salarytype;
//
            ///   txtICOEName.Text = ICOEName;
            //    txtICOENumber.Text = ICOENumber;
         ///       texRos.Text = Ros_hrd;
           //     textRemarks.Text = Remarks;
            


                button2.Visible = false;
                expiration_details.Enabled = false;


             loadImage();
              
          //      cboSection_SelectedValueChanged(sender, e);
            }
            else
            {
            //    loadDefaultImage();
            }


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

        private void loadImage()
        {
            dsImage = g_objStoredProcCollection.sp_micro_new(myglobal.temp_id, "", "getImage");
            try
            {
                imageByte = (Byte[])(dsImage.Tables[0].Rows[0]["raw_material_image"]);

                if (imageByte.Length == 0)
                {
                    loadDefaultImage();
                }
                else
                {
                    try
                    {
                        //bebeko
                        pbImage.Image = Image.FromStream(new MemoryStream(imageByte));
                        btnRemove.Enabled = true;
                    }
                    catch (Exception exception)
                    {
                        this.Show();
                        loadDefaultImage();
                        MessageBox.Show("Error  :  Image of" + txtItemCode.Text + " " + txtItemDescription.Text + " " + txtquantity.Text + " Failed To Load. \n\n" + exception.Message, "HR Application", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception) { loadDefaultImage(); }
        }


        public void loadSupplier()
        {
            ready = false;

            xClass.fillComboBox(cboSupplier, "my_supplier_rdf", dSet);
           // displayData(Convert.ToInt32(cboDepartment.SelectedValue.ToString()));

            ready = true;

        }
        public void loadrdfCategory()
        {
            ready = false;

            xClass.fillComboBox(cbocategory, "rdf_category", dSet);
            // displayData(Convert.ToInt32(cboDepartment.SelectedValue.ToString()));

            ready = true;

        }

        public void loadClassification()
        {
            ready = false;
            xClass.fillComboBox(cboclassification, "rdf_classification", dSet);
            ready =true;
        }
        private void loadFeedCode()
        {
            /*
            ready = false;
            xClass.fillListBox(lstFeedCode, "get_rdf_codes", dSet);
            ready = true;
*/
        }




        private void con_on()
        {
            con = new SqlConnection();
            con.ConnectionString = connetionString;
            con.Open();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            frmGroup g = new frmGroup();
            g.ShowDialog();
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            selectMicroImage();
        }

        private void selectMicroImage()
        {
            odbEmployeeImage.Filter = "JPEG Images (.JPG)|*.jpg|GIF Images (.GIF)|*.gif|BITMAPS (.BMP)|*.bmp|PNG Images (.PNG)|*.png";
            odbEmployeeImage.Multiselect = false;
            lodi = true;
            if (odbEmployeeImage.ShowDialog() != DialogResult.Cancel)
            {
                try
                {
                    pbImage.Image = null;
                    pbImage.Refresh();
                    pbImage.Image = Image.FromFile(odbEmployeeImage.FileName);
                    lodi = true;
                    if (readImageByte(odbEmployeeImage.FileName))
                    {
                        btnRemove.Enabled = true;
                    }
                }
                catch (Exception exception)
                {
                    lodi = false;
                    MessageBox.Show("Error  : Image Failed To Load \n\n\n" + exception.Message, "HR Application", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private Boolean readImageByte(String path)
        {
            try
            {
                imageByte = new byte[Convert.ToInt32(null)];
                fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
                binaryReader = new BinaryReader(fileStream);
                imageByte = binaryReader.ReadBytes((Int32)fileStream.Length);
                pbImage.Image = null;
                pbImage.Refresh();
                pbImage.Image = Image.FromFile(path);
                return true;
            }
            catch (Exception exception)
            {
                loadDefaultImage();
                MessageBox.Show("Error  :  Image failed to Read\n\nPlease Try it again!!!\n\n" + exception.Message, "HR Application", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

        }

        private void loadDefaultImage()
        {
            try
            {
                lodi = false;
                pbImage.Image = null;
                pbImage.Refresh();
              pbImage.BackgroundImage = new Bitmap(Properties.Resources.Buddy);
                // Image.FromFile(Path.GetDirectoryName(Application.ExecutablePath) + @"\Resources\Buddy.png");
                imageByte = new byte[Convert.ToInt32(null)];
                btnRemove.Enabled = false;
            }
            catch (Exception)
            {

            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Remove The Image of  " + txtItemDescription.Text + "?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                loadDefaultImage();

                frmMenu sa = new frmMenu();

               // sa.ActivitiesLogs(userinfo.emp_name + " Remove Image");
            }
        }
        private void ForEdit()
        {
            gBSupplier.Enabled = true;
            groupBox1.Enabled = true;
         //   gBemergency.Enabled = true;
            groupBox2.Enabled = true;
            btnsave.Enabled = true;
            button1.Enabled = false;
            btnClose.Visible = false;
            btncancel.Visible = true;
        }
        private void VisibleFalse()
        {
            btnsave.Visible = true;
            btnSubmit.Visible = false;
        }
        private void NoEdit()
        {
            groupBox1.Enabled = false;
            gBSupplier.Enabled = false;
            groupBox2.Enabled = false;
            gBInactive.Enabled = false;
            gBemergency.Enabled = false;
            btnsave.Enabled = false;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ForEdit();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            gBSupplier.Enabled = false;
            groupBox1.Enabled = false;
            gBemergency.Enabled = false;
            groupBox2.Enabled = false;
            gBInactive.Enabled = false;
            btnsave.Enabled = false;
            btnEdit.Enabled = true;
            button1.Enabled = true;
            btnSubmit.Visible = false;
            btncancel.Visible = false;
            btnClose.Visible = true;
        }
       void myCancel()
        {
            gBSupplier.Enabled = false;
            groupBox1.Enabled = false;
            gBemergency.Enabled = false;
            groupBox2.Enabled = false;
            gBInactive.Enabled = false;
            btnsave.Enabled = false;
            btnEdit.Enabled = true;
            button1.Enabled = true;
            btnSubmit.Visible = false;
        }

        private void cboDepartment_SelectedValueChanged(object sender, EventArgs e)
        {
            if (ready == true)
                displayData(Convert.ToInt32(cboDepartment.SelectedValue.ToString()));
        }

        void displayData(int dept_id)
        {
            //dSet = objStorProc.sp_getFilterTables("filter_section_by_department_id", "", dept_id);

            //if (dSet.Tables.Count > 0)
            //{
            //    DataView dv = new DataView(dSet.Tables[0]);
            //    dgv1.DataSource = dv;
            //}

        }

        void loadDepartment()
        {
            ready = false;

            xClass.fillComboBox(cboDepartment, "department", dSet);
           displayData(Convert.ToInt32(cboDepartment.SelectedValue.ToString()));

            ready = true;
        }

        private void dgv1_CurrentCellChanged(object sender, EventArgs e)
        {
         //   showRecords();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            gBInactive.Enabled = true;
            btnEdit.Enabled = false;
            btnSubmit.Visible=true;
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
          
            if (MessageBox.Show("Are you sure you want to save this Micro Raw Material? Please check details", "RAW MATERIAL RECORD?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                if (txtItemCode.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter an Item Code", "Micro Raw Material", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (txtItemDescription.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter raw material's Item Description", "Micro Raw Material", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (txtquantity.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter raw material's Reorder Level", "Micro Raw Material", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (cboclassification.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter raw material's Classfication.", "Micro Raw Material", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
              
                else if (cboSupplier.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter raw material's Supplier", "Micro Raw Material", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (txtLocation.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter raw material's Location", "Micro Raw Material", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                {
                  
                    if (save_record())
                    {
                        myglobal.updated = true; frmMenu sa = new frmMenu();
                        sa.ActivitiesLogs(userinfo.emp_name + " Save Employee Edited Details of" + txtItemDescription.Text + ", " + txtItemCode.Text);
                        btncancel_Click(sender, e);


                    }
                 
                }






            }
         
        }

      
        public bool save_record()
        {
            if (myglobal.mode == "add")
            {
                dSet.Clear();
                dSet = g_objStoredProcCollection.sp_micro_new(myglobal.temp_id, txtItemCode.Text, "getbynumber");

                if (dSet.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Raw Materials Micro already exist...", "Already Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtnumber.Focus();
                    return false;
                }
                else              // Convert.ToInt32(cboPosition.SelectedValue.ToString()),
                {
                    dSet.Clear();
                    dSet = g_objStoredProcCollection.sp_micro_new(0, Convert.ToInt32(cbocategory.SelectedValue.ToString()),
                                                                txtItemCode.Text, Convert.ToInt32(cboSupplier.SelectedValue.ToString()), txtItemDescription.Text,
                                                                cboclassification.Text, txtquantity.Text, date_added.Value,
                                                                txtexpiration_details.Text, txtDeliveryDetails.Text, txtAddedBy.Text,
                                                                txtLocation.Text, txtItemRemarks.Text, txtAddedBy.Text,txtPerBag.Text, 
                                                                "add",
                                                                imageByte);

                    // add picture to timekeeping
                    if (pbImage.Image != null && lodi == true)
                    {
                        if (pbImage.Image.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Jpeg))
                        {
                            sendimg_to_tk(dSet.Tables[0].Rows[0][0].ToString(), "jpg", "add");
                        }
                        else if (pbImage.Image.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Png))
                        {
                            sendimg_to_tk(dSet.Tables[0].Rows[0][0].ToString(), "png", "add");
                        }
                        else if (pbImage.Image.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Bmp))
                        {
                            sendimg_to_tk(dSet.Tables[0].Rows[0][0].ToString(), "bmp", "add");
                        }
                        lodi = false;
                    }


                    MessageBox.Show("Micro Material Successfully Added", "RDF FEDORA SYSTEM", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
            }
            else if (myglobal.mode == "edit")
            {


                if (myglobal.global_module == "MICRO")
                {
                    dSet.Clear();
                    dSet = g_objStoredProcCollection.sp_micro_new(myglobal.temp_id, Convert.ToInt32(cbocategory.SelectedValue.ToString()),
                                                                txtItemCode.Text, Convert.ToInt32(cboSupplier.SelectedValue.ToString()), txtItemDescription.Text,
                                                                cboclassification.Text, txtquantity.Text, date_added.Value,
                                                                txtexpiration_details.Text, txtDeliveryDetails.Text, txtAddedBy.Text,
                                                                txtLocation.Text, txtItemRemarks.Text, txtAddedBy.Text, txtPerBag.Text,
                                                                "edit",
                                                                imageByte);

                    MessageBox.Show("Raw Material Succesfully Updated", "Micro Materials", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
                    //parents.load_micro();
                    myCancel();
                    gBemergency.Refresh();
                    return true;


                }




    
                dSet.Clear();
               dSet = g_objStoredProcCollection.sp_micro_new(0, item_code, "getbynumber");

                dSet_temp.Clear();
                dSet_temp = g_objStoredProcCollection.sp_micro_new(myglobal.temp_id, txtnumber.Text, "getbyid");

                if (dSet.Tables[0].Rows.Count > 0)
                {
                    int tmpID = Convert.ToInt32(dSet.Tables[0].Rows[0][0].ToString());
                    if (tmpID == temp_id)
                    {
                        dSet.Clear();
             


                        dSet = g_objStoredProcCollection.sp_micro_new(myglobal.temp_id, Convert.ToInt32(cbocategory.SelectedValue.ToString()),
                                                                txtItemCode.Text, Convert.ToInt32(cboSupplier.SelectedValue.ToString()), txtItemDescription.Text,
                                                                cboclassification.Text, txtquantity.Text, date_added.Value,
                                                                txtexpiration_details.Text, txtDeliveryDetails.Text, txtAddedBy.Text,
                                                                txtLocation.Text, txtItemRemarks.Text, txtAddedBy.Text, txtPerBag.Text,
                                                                "edit",
                                                                imageByte);
                   

                        if (pbImage.Image != null && lodi == true)
                        {
                            if (pbImage.Image.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Jpeg))
                            {
                                sendimg_to_tk(dSet.Tables[0].Rows[0][0].ToString(), "jpg", "edit");
                            }
                            else if (pbImage.Image.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Png))
                            {
                                sendimg_to_tk(dSet.Tables[0].Rows[0][0].ToString(), "png", "edit");
                            }
                            else if (pbImage.Image.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Bmp))
                            {
                                sendimg_to_tk(dSet.Tables[0].Rows[0][0].ToString(), "bmp", "edit");
                            }
                            MessageBox.Show("Updated and Image sent to Timekeeping", "Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            lodi = false;
                        }
                        else if (lodi == false)
                        {
                            MessageBox.Show("Updated", "Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        return true;

                    }

                }


                else
                {
                    MessageBox.Show("Employee already exista...", "Already Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   

                    txtnumber.Focus();
                    return false;
                }
            }


            else
            {

                dSet.Clear();
                dSet = g_objStoredProcCollection.sp_micro_new(myglobal.temp_id, Convert.ToInt32(cbocategory.SelectedValue.ToString()),
                                                                txtItemCode.Text, Convert.ToInt32(cboSupplier.SelectedValue.ToString()), txtItemDescription.Text,
                                                                cboclassification.Text, txtquantity.Text, date_added.Value,
                                                                txtexpiration_details.Text, txtDeliveryDetails.Text, txtAddedBy.Text,
                                                                txtLocation.Text, txtItemRemarks.Text, txtAddedBy.Text,txtPerBag.Text,
                                                                "edit",
                                                                imageByte);



                return true;
            }

 
            return false;
        }


        /// marami na tlaga code etong putangina
        /// 
      
        private void sendimg_to_tk(string empid, string format, string mode)
        {
            if (mode == "add")
            {
                try
                {
                    if (format == "jpg")
                    {
                        string filepath = @"\\192.168.2.171\C$\pics";
                        pbImage.Image.Save(Path.Combine(filepath, empid + ".jpg"), System.Drawing.Imaging.ImageFormat.Jpeg);

                        string filepath2 = @"\\192.168.2.136\C$\pics";
                        pbImage.Image.Save(Path.Combine(filepath2, empid + ".jpg"), System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    else if (format == "png")
                    {
                        string filepath = @"\\192.168.2.171\C$\pics";
                        pbImage.Image.Save(Path.Combine(filepath, empid + ".jpg"), System.Drawing.Imaging.ImageFormat.Jpeg);

                        string filepath2 = @"\\192.168.2.136\C$\pics";
                        pbImage.Image.Save(Path.Combine(filepath2, empid + ".jpg"), System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    else if (format == "bmp")
                    {
                        string filepath = @"\\192.168.2.171\C$\pics";
                        pbImage.Image.Save(Path.Combine(filepath, empid + ".jpg"), System.Drawing.Imaging.ImageFormat.Jpeg);

                        string filepath2 = @"\\192.168.2.136\C$\pics";
                        pbImage.Image.Save(Path.Combine(filepath2, empid + ".jpg"), System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ADD Picture Failed");
                }
            }
            else if (mode == "edit" && lodi == true)
            {
                try
                {
                    if (format == "jpg")
                    {
                        string filepath = @"\\10.10.12.115\C$\pics";
                        if (!System.IO.File.Exists(Path.Combine(filepath, empid + ".jpg")))
                        {
                            pbImage.Image.Save(Path.Combine(filepath, empid + ".jpg"), System.Drawing.Imaging.ImageFormat.Jpeg);
                        }
                        /*
                        string filepath2 = @"\\192.168.2.136\C$\pics";
                        if (!System.IO.File.Exists(Path.Combine(filepath2, empid + ".jpg")))
                        {
                            pbImage.Image.Save(Path.Combine(filepath2, empid + ".jpg"), System.Drawing.Imaging.ImageFormat.Jpeg);
                        }
                        */
                    }

                    else if (format == "png")
                    {
                        string filepath = @"\\10.10.12.115\C$\pics";
                        if (!System.IO.File.Exists(Path.Combine(filepath, empid + ".png")))
                        {
                            pbImage.Image.Save(Path.Combine(filepath, empid + ".jpg"), System.Drawing.Imaging.ImageFormat.Jpeg);
                        }
                        /*
                        string filepath2 = @"\\192.168.2.136\C$\pics";
                        if (!System.IO.File.Exists(Path.Combine(filepath2, empid + ".png")))
                        {
                            pbImage.Image.Save(Path.Combine(filepath2, empid + ".jpg"), System.Drawing.Imaging.ImageFormat.Jpeg);
                        }
                        */
                    }

                    else if (format == "bmp")
                    {
                        string filepath = @"\\192.168.2.171\C$\pics";
                        if (!System.IO.File.Exists(Path.Combine(filepath, empid + ".bmp")))
                        {
                            pbImage.Image.Save(Path.Combine(filepath, empid + ".jpg"), System.Drawing.Imaging.ImageFormat.Jpeg);
                        }
                        /*
                        string filepath2 = @"\\192.168.2.136\C$\pics";
                        if (!System.IO.File.Exists(Path.Combine(filepath2, empid + ".png")))
                        {
                            pbImage.Image.Save(Path.Combine(filepath2, empid + ".jpg"), System.Drawing.Imaging.ImageFormat.Jpeg);
                        }
                        */
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "UPDATE Picture Failed");
                }




            }

        }


      
        private void button4_Click(object sender, EventArgs e)
        {
            player.SoundLocation = @"C:\Users\bobo\you_have_a_text_msg.wav";
            player.Play();
        }

        private void cboSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
       
        
        }

        private void pbImage_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
