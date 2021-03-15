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
    public partial class frmMicroReceivingInfo : Form
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

        private string id = "";

        DataSet dSet = new DataSet();
        DataSet dSet_temp = new DataSet();
        DataSet dset_offense = new DataSet();
        DataSet dsImage = new DataSet();
        Boolean ready = false;

        string mode = "";

        Boolean lodi = false;
        bool re = false;

        int p_id = 0;
        int d_id = 0;
        int s_id = 0;
        int pos_id = 0;
        int r_id = 0;
        int details_id = 0;

        MDIParent1 parents;

        public int temp_id = 0;
        public string received_id = "";
        public string r_item_id = "";
        public string r_item_code = "";
        public string r_item_description = "";
        public string r_supplier = "";
        public string r_item_category = "";
        public string days_to_expired = "";
        public string r_classification = "";
        public string supplier = "";
        public string selected_uom = "";
        //public string selected_uom = "";
        public string r_quantity = "";
        public string actual_count_good = "";
        public string actual_count_reject = "";
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




        public frmMicroReceivingInfo()
        {
            InitializeComponent();
        }

        private void frmMicroReceivingInfo_Load(object sender, EventArgs e)
        {

            g_objStoredProcCollection = xClass.g_objStoredProc.GetCollections();

            objStorProc = xClass.g_objStoredProc.GetCollections();



            if (myglobal.mode == "edit")
            {

                txtID.Text = received_id;
                txtitem_id.Text = r_item_id;
                txtItemDescription.Text = r_item_description;
                txtSupplier.Text = r_supplier;
                txtxp.Text = days_to_expired;
                cboCategory.Text = r_item_category;
                txtItemCode.Text = r_item_code;
                cboclassification.Text = r_classification;
                txtselecteduom.Text = selected_uom;
                txtActualStocks.Text = r_quantity;
                txtactualgood.Text = actual_count_good;
                txtactualreject.Text = actual_count_reject;
                //cboclassification.Text = classification;
                //txtSupplierName.Text = supplier;
                //cboSupplier.Text = supplier;
                //totalQty.Text = total_quantity_raw;
                //txtSupplierNumber.Text = contact_no;
                //txtAddressfinal.Text = address;
                //txtEmail_Address.Text = email_address;
                //txtLocation.Text = item_location;
                //txtItemRemarks.Text = item_remarks;
                //txtAddedBy.Text = added_by;
                //date_added.Value = dateadded;
                //txtPerBag.Text = per_bag;

                //txtexpiration_details.Text = expirationdetails;
                //txtDeliveryDetails.Text = delivery_details;




                //////////////button2.Visible = false;
                //////////expiration_details.Enabled = false;


               loadImage();

                //      cboSection_SelectedValueChanged(sender, e);
            }
            else
            {
                //    loadDefaultImage();
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
                     //   btnRemove.Enabled = true;
                    }
                    catch (Exception exception)
                    {
                        this.Show();
                        loadDefaultImage();
                        MessageBox.Show("Error  :  Image of" + txtItemCode.Text + " " + txtItemDescription.Text + " Failed To Load. \n\n" + exception.Message, "HR Application", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception) { loadDefaultImage(); }
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
               // btnRemove.Enabled = false;
            }
            catch (Exception)
            {

            }
        }


    }
}
