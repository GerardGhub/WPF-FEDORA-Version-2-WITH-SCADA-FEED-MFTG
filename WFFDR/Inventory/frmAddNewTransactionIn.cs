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

namespace WFFDR
{
    public partial class frmAddNewTransactionIn : Form
    {

frmMiscellaneoustransactionIssueIN ths;
        //int rowindex;

        string mode = ""; //mymode
        myclasses xClass = new myclasses();
        IStoredProcedures objStorProc = null;
        DataSet dSets = new DataSet();

        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();
        DataSet dSet_temp = new DataSet();
        DataSet dset_delete = new DataSet();

        DataSet dSet = new DataSet();
        DataSet dset_rights = new DataSet();


        private const int BaudRate = 9600;
        //int sec;
        DataSet dset_section = new DataSet();
        Boolean ready = false;

        int p_id = 0;
        //int s_id = 0;
        //weighing

        public myclasses classes = new myclasses();
        myclasses myClass = new myclasses();


        public DataSet dset = new DataSet();
        DataSet dset2 = new DataSet();
        DataSet dset3 = new DataSet();

   

   
        public frmAddNewTransactionIn(frmMiscellaneoustransactionIssueIN frm)
        {
            InitializeComponent();

            ths = frm;
            txtdescription.TextChanged += new EventHandler(textBox1_TextChanged);
        }

        private void txtmoveorder_TextChanged(object sender, EventArgs e)
        {
                   
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void frmAddNewTransactionIn_Load(object sender, EventArgs e)
        {
            // Calling the Stored PROC 
            objStorProc = xClass.g_objStoredProc.GetCollections();
         txtAddedBy.Text = userinfo.emp_name.ToUpper();
            mfg_datePicker.Text = DateTime.Now.ToString("M/d/yyyy");
            dtpMfgDate.Text = DateTime.Now.ToString("M/d/yyyy");

            xpired.Text = DateTime.Now.ToString("M/d/yyyy");
            lbldateandtime.Text = DateTime.Now.ToString();

            xpired.MinDate = DateTime.Today;
            CallMaterialsDescription();
            LoadItemCode();
            CheckTheNumberTransactions();
            

       txtTransactno.Text = (float.Parse(lbltotaldata.Text) + 1).ToString();
            LoadSupplier();

            lbldatabasis.Text = "1";
        }




        void CheckTheNumberTransactions()
        {
     
                String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";


                SqlConnection sql_con = new SqlConnection(connetionString);


                string sqlquery = "SELECT * FROM [dbo].[rdf_transaction_in_progress]";



                sql_con.Open();
                SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
                SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
                DataTable dt = new DataTable();
                sdr.Fill(dt);
               dgvViewDescriptions.DataSource = dt;
            lbltotaldata.Text = dgvViewDescriptions.RowCount.ToString();
                sql_con.Close();

     

        }
        void LoadItemCode()
        {
            ready = false;
            mfg_datePicker.Enabled = false;
            txtdescription.Enabled = false;
            txtxp.Enabled = false;
            xClass.fillComboBoxWH(cboItemCode, "rdf_item_code_view", dSet);
            //displayData(Convert.ToInt32(cboStandardWeight.SelectedValue.ToString()));

            ready = true;
            textBox1.Text = "";
        }

        void LoadSupplier()
        {

            xClass.fillComboBoxWH(txtSupplier, "rdf_supplier_view_combo", dSet);
            //displayData(Convert.ToInt32(cboStandardWeight.SelectedValue.ToString()));

            ready = true;
         
        }
        private void txtexpiration_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtqtyreceived_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboProddate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ths.textBox1.Text = textBox1.Text;
        }

        private void lbldateandtime_Click(object sender, EventArgs e)
        {

        }

        private void xpired_ValueChanged(object sender, EventArgs e)
        {
            mfg_datePicker.Text = DateTime.Now.ToString("M/d/yyyy");
            expirationdays();
        }


        void expirationdays()
        {
            xpired.MinDate = DateTime.Today;
            //autocomputer expired open start
            DateTime FirstDate = mfg_datePicker.Value;
            DateTime SecondDate = xpired.Value;


            // Difference in days, hours, and minutes.
            TimeSpan ts = SecondDate - FirstDate;

            // Difference in days.
            int differenceInDays = ts.Days;
            txtxp.Text = differenceInDays.ToString();
        }

        void CallMaterialsDescription()
        {


            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";


            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "SELECT * FROM [dbo].[rdf_raw_materials] where is_active='1' and item_code='" + cboItemCode.Text + "'";



            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvViewDescriptions.DataSource = dt;
            lblcountrawmats.Text = dgvViewDescriptions.RowCount.ToString();


        }
        private void cboItemCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            CallMaterialsDescription();


            dgvViewDescriptions_CurrentCellChanged(sender, e);
        }

        private void dgvViewDescriptions_CurrentCellChanged(object sender, EventArgs e)
        {
            if (lblcountrawmats.Text == "0")
            {
                return;
            }

            if (dgvViewDescriptions.CurrentRow != null)
            {
                if (dgvViewDescriptions.CurrentRow.Cells["item_code"].Value != null)
                {
                    txtdescription.Text = dgvViewDescriptions.CurrentRow.Cells["item_description"].Value.ToString();

                    txtCategory.Text = dgvViewDescriptions.CurrentRow.Cells["Category"].Value.ToString();


                    if (lbldatabasis.Text == "1")
                    {
                        txtmaterialid.Text = dgvViewDescriptions.CurrentRow.Cells["item_id"].Value.ToString();

                    }

                }
            }


        }



        public void FillRequiredFields()
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);

            popup.ContentText = "Fill up the required Field";

            popup.ContentColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);

            popup.ContentHoverColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentPadding = new Padding(0);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Red;
            popup.Popup();

            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);

            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }

        public void Success()
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);

            popup.ContentText = "Successfully insert a new Transaction of Raw Material";

            popup.ContentColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);

            popup.ContentHoverColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentPadding = new Padding(0);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Green;
            popup.Popup();

            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);

            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }


        private void frmAddNewTransactionIn_FormClosed(object sender, FormClosedEventArgs e)
        {
            textBox1.Text = "212";
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
 
            if (txtTransactno.Text.Trim() == string.Empty)
            {

                FillRequiredFields();
                txtTransactno.Focus();
                return;
            }

            if (cboItemCode.Text.Trim() == string.Empty)
            {
                FillRequiredFields();
                cboItemCode.Focus();
                return;
            }


            if (txtSupplier.Text.Trim() == string.Empty)
            {
                FillRequiredFields();
                txtSupplier.Focus();
                return;
            }

            if (txtqty.Text.Trim() == string.Empty)
            {

                FillRequiredFields();
                txtqty.Focus();
                return;
            }


            if (txtxp.Text.Trim() == string.Empty)
            {

                FillRequiredFields();
                
                return;
            }

            if (txtremarks.Text.Trim() == string.Empty)
            {
                //MessageBox.Show("Error");
                FillRequiredFields();
                txtremarks.Focus();
                return;
            }


            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to save the Transaction ? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {





                mode = "add";





             //   UpdateFG();

                if (saveMode())
                {

                    string tmode = mode;

                    if (tmode == "add")
                    {


                        //AddedSuccess();
                        //bunifuThinButton29_Click(sender, e);
                        //btnfinishvalidation_Click(sender, e); ///dito muna ang minus querys
                        //Clear();
                        //load_Schedules_approved();
                        //load_Schedules();



                    }
                    else
                    {

                    }

                    /// btnCancel_Click(sender, e);

                }
                else
                {
                    //MessageBox.Show("Failed");
                }







            }
            else
            {

                return;
            }


            textBox1.Text = "Tapos";
            txtqty.Text = "";
            txtSupplier.Text = "";
            Success();


            this.Hide();
          //  this.Close();








            //    frmMoveOrder_Load(sender, e);



















        }

        public bool saveMode()
        {

            if (mode == "add")
            {
                dSet.Clear();
                dSet = objStorProc.sp_transaction_in(0, cboItemCode.Text.Trim(), txtdescription.Text, txtCategory.Text.Trim(), txtSupplier.Text.Trim(), txtqty.Text.Trim(), lbldateandtime.Text.Trim(), dtpMfgDate.Text.Trim(), xpired.Text.Trim(), txtremarks.Text.Trim(), mfg_datePicker.Text.Trim(), txtAddedBy.Text.Trim(),txtxp.Text.Trim(),txtTransactno.Text.Trim(),txtmaterialid.Text.Trim(), "add");


                //dSet.Clear();
                //dSet = objStorProc.rdf_sp_prod_schedules(0, cboFeedCode.Text, lbldata1.Text, "", "", "", "", "", "", "", "getbyname");

                //if (dSet.Tables[0].Rows.Count > 0)
                //{
                //    MessageBox.Show("Duplicate Entry", "Offense", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    cboFeedCode.Focus();
                //    return false;
                //}
                //else
                //{
                //    //tae
                //    dSet.Clear();
                //    dSet = objStorProc.rdf_sp_move_order(0, txtorder.Text.Trim(), lbldateandtime.Text, cboWarehouse.Text.Trim(), lbldata1.Text.Trim(), cboCustomer.Text.Trim(), lbldata2.Text.Trim(), lblfeed_code.Text.Trim(), lblFeedType.Text.Trim(), cmbBagorSack.Text.Trim(), cboProddate.Text.Trim(), txtqty.Text.Trim(), cboUOM.Text.Trim(), txtqtyreceived.Text.Trim(), txtstockonhand.Text.Trim(), txtstock.Text.Trim(), lblprodid.Text.Trim(), lbluseractive.Text.Trim(), txtdatenow.Text, "add");

                //    return true;
                //}
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

        private void txtqty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
            && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }



        }

        private void txtqty_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
