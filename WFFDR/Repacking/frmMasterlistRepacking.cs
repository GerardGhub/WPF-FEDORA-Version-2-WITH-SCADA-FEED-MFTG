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

namespace WFFDR
{
    public partial class frmMasterlistRepacking : Form
    {

        myclasses xClass = new myclasses();
        IStoredProcedures objStorProc = null;

        int p_id = 0;
        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();

        public frmMasterlistRepacking()
        {
            InitializeComponent();
        }

        private void frmMasterlistRepacking_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            load_micro_receiving_entry();
            // Calling the Stored PROC 
            objStorProc = xClass.g_objStoredProc.GetCollections();
            load_2ndSupplier();
            HideTextBox();
            DisableTextBox();

            Load_Receiving_Entry();

            load_RepackingLogs();
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
        public void DisableTextBox()
        {
            txtsearch.Enabled = false;
            txtsearchreceiving.Enabled = false;
        }

        public void HideTextBox()
        {
            dgv_table_2nd_sup.Visible = false;
            dtgReceivingEntry.Visible = false;

            txtsearch.Visible = true;
            txtsearchreceiving.Visible = true;
        }
      
        public void load_2ndSupplier()
        {
            string mcolumns = "test,rp_item_id,rp_item_code,rp_supplier,totalnstock,selected_uom,uniquedate,days_to_expired";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgvretaillogs, mcolumns, "raw_material_micro_repackin");

            //string mcolumns = "test,r_item_id,received_id,r_item_code,r_supplier,totalnstock,selected_uom,uniquedate,days_to_expired";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            //pointer_module.populateModule(dsetHeader, dgv_table_2nd_sup, mcolumns, "raw_material_micro_dosSupplier");

            //  lblrecords.Text = dgv_table.RowCount.ToString();

            //micro_2ndSupplier_header(); //hide muna daw
        }
        public void load_RepackingLogs()
        {
            string mcolumns = "test,repack_id,rp_item_id,rp_item_code,rp_supplier,totalnstock,selected_uom,uniquedate,days_to_expired";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgvretaillogs, mcolumns, "raw_material_micro_repackin");

            //string mcolumns = "test,r_item_id,received_id,r_item_code,r_supplier,totalnstock,selected_uom,uniquedate,days_to_expired";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            //pointer_module.populateModule(dsetHeader, dgv_table_2nd_sup, mcolumns, "raw_material_micro_dosSupplier");

            //  lblrecords.Text = dgv_table.RowCount.ToString();

    
        }




        public void Load_Receiving_Entry()
        {
            string mcolumns = "test,received_id,r_item_id,r_item_code,r_item_description,r_supplier,selected_uom,totalnstock,r_receiving_date,days_to_expired";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dtgReceivingEntry, mcolumns, "raw_material_partial_viewing");
            //  lblrecords.Text = dgv_table.RowCount.ToString();
            // textBox1.Text = dgv_table.RowCount.ToString();
            Receiving_header();
        }



        void micro_2ndSupplier_header()
        {
            dgv_table_2nd_sup.Columns[0].HeaderText = "ID";

            dgv_table.Columns[1].HeaderText = "Received ID";
            dgv_table_2nd_sup.Columns[2].HeaderText = "Code";
            dgv_table_2nd_sup.Columns[3].HeaderText = "Supplier";
            dgv_table_2nd_sup.Columns[4].HeaderText = "Stocks";
            dgv_table_2nd_sup.Columns[5].HeaderText = "UOM";

            dgv_table_2nd_sup.Columns[6].HeaderText = "Date Received";
            //dgv_table_2nd_sup.Columns[7].HeaderText = "Expiration";  alis muna 2/10/2020
            //dgv_table.Columns[6].HeaderText = "Reorder Level";
            //dgv_table.Columns[7].HeaderText = "Per Bag";
            //dgv_table.Columns[8].HeaderText = "Supplier";
            //dgv_table.Columns[9].HeaderText = "Supplier Address";
            //dgv_table.Columns[10].HeaderText = "Supplier Contact";
            //dgv_table.Columns[11].HeaderText = "Supplier Email";
            //dgv_table.Columns[12].HeaderText = "Date Added";
            //dgv_table.Columns[13].HeaderText = "Expiration Details";



            //this.dgv_table.Columns["per_bag"].Frozen = true;



        }



        void Receiving_header()
        {
            dtgReceivingEntry.Columns[0].HeaderText = "ReceivedID";

            dtgReceivingEntry.Columns[1].HeaderText = "ItemID";
            dtgReceivingEntry.Columns[2].HeaderText = "Item Code";
            dtgReceivingEntry.Columns[3].HeaderText = "Description";
            dtgReceivingEntry.Columns[4].HeaderText = "Supplier";
            dtgReceivingEntry.Columns[5].HeaderText = "UOM";

            //dtgReceivingEntry.Columns[6].HeaderText = "QTY.Deliver";
            dtgReceivingEntry.Columns[7].HeaderText = "Expirations";
            //dgv_table.Columns[6].HeaderText = "Reorder Level";
            //dgv_table.Columns[7].HeaderText = "Per Bag";
            //dgv_table.Columns[8].HeaderText = "Supplier";          //dgv_table.Columns[9].HeaderText = "Supplier Address";
            //dgv_table.Columns[10].HeaderText = "Supplier Contact";
            //dgv_table.Columns[11].HeaderText = "Supplier Email";
            //dgv_table.Columns[12].HeaderText = "Date Added";
            //dgv_table.Columns[13].HeaderText = "Expiration Details";



            //this.dgv_table.Columns["per_bag"].Frozen = true;



        }

        public void load_micro_receiving_entry()
        {
            string mcolumns = "test,item_id,item_code,item_description,total_quantity_raw";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgv_table, mcolumns, "raw_material_receiving_repacking");
            //  lblrecords.Text = dgv_table.RowCount.ToString();
            // textBox1.Text = dgv_table.RowCount.ToString();
            micro_materials_header();
        }

        void micro_materials_header()
        {
            dgv_table.Columns[0].HeaderText = "Item ID";
            dgv_table.Columns[1].HeaderText = "Item Code";
            dgv_table.Columns[2].HeaderText = "Item Description";
            dgv_table.Columns[3].HeaderText = "Total Quantity";
            //dgv_table.Columns[4].HeaderText = "Available";
            //dgv_table.Columns[5].HeaderText = "Expiration";
            //dgv_table.Columns[6].HeaderText = "Reorder Level";
            //dgv_table.Columns[7].HeaderText = "Per Bag";
            //dgv_table.Columns[8].HeaderText = "Supplier";
            //dgv_table.Columns[9].HeaderText = "Supplier Address";
            //dgv_table.Columns[10].HeaderText = "Supplier Contact";
            //dgv_table.Columns[11].HeaderText = "Supplier Email";
            //dgv_table.Columns[12].HeaderText = "Date Added";
            //dgv_table.Columns[13].HeaderText = "Expiration Details";



            //this.dgv_table.Columns["per_bag"].Frozen = true;



        }

        private void txtmainsearch_TextChanged(object sender, EventArgs e)
        {

            String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=hr_bak;Integrated Security=SSPI";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "select item_id,item_code,item_description,total_quantity_raw from [dbo].[rdf_raw_materials] WHERE item_code like '%" + txtmainsearch.Text + "%' or item_description like '%" + txtmainsearch.Text + "%' ";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgv_table.DataSource = dt;
            sql_con.Close();



            if (txtmainsearch.Text.Trim() == string.Empty)
            {
                load_micro_receiving_entry();

            }





        }

        private void dgv_table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
                        p_id = Convert.ToInt32(dgv_table.CurrentRow.Cells["item_id"].Value);
                        //txtID.Text = dgv_table.CurrentRow.Cells["received_id"].Value.ToString();
                        txtsearch.Text = dgv_table.CurrentRow.Cells["item_code"].Value.ToString();
                        txtsearchreceiving.Text = dgv_table.CurrentRow.Cells["item_code"].Value.ToString();
                        //txtItemDescription.Text = dgv_table.CurrentRow.Cells["r_item_description"].Value.ToString();
                        //txtMainSupplier.Text = dgv_table.CurrentRow.Cells["r_supplier"].Value.ToString();
                        //lbldashboard1.Text = dgv_table.CurrentRow.Cells["totalnstock"].Value.ToString();
                        //txtxp.Text = dgv_table.CurrentRow.Cells["days_to_expired"].Value.ToString();
                        //cboCategory.Text = dgv_table.CurrentRow.Cells["r_item_category"].Value.ToString();
                        //lblactualgood.Text = dgv_table.CurrentRow.Cells["actual_count_good"].Value.ToString();
                        //lblactualreject.Text = dgv_table.CurrentRow.Cells["actual_count_reject"].Value.ToString();
                        //txtuom.Text = dgv_table.CurrentRow.Cells["selected_uom"].Value.ToString();
                        //txtItemCode.Text = dgv_table.CurrentRow.Cells["r_item_code"].Value.ToString();
                        //lbldelivered.Text = dgv_table.CurrentRow.Cells["r_qty_delivered"].Value.ToString();
                        //lblqtyordered.Text = dgv_table.CurrentRow.Cells["r_qty_ordered"].Value.ToString();
                        //mfg_datePicker.Text = dgv_table.CurrentRow.Cells["r_mfg_date"].Value.ToString();
                        //xpired.Text = dgv_table.CurrentRow.Cells["r_expiry_date"].Value.ToString();
                        //txtActualQty.Text = dgv_table.CurrentRow.Cells["r_qty_delivered"].Value.ToString();
                        //dtpreceivingdate.Text = dgv_table.CurrentRow.Cells["r_receiving_date"].Value.ToString();
                        //txtContactNo.Text = dgv1.CurrentRow.Cells["contact_no"].Value.ToString();
                        //txtAddress.Text = dgv1.CurrentRow.Cells["address"].Value.ToString();
                        //txtEmailAddress.Text = dgv1.CurrentRow.Cells["email_address"].Value.ToString();

                    }

                }
            }

        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=hr_bak;Integrated Security=SSPI";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "select rp_item_id,rp_item_code,rp_supplier,totalnstock,selected_uom,uniquedate,days_to_expired from [dbo].[rdf_repackin_entry] WHERE rp_item_code like '%" + txtsearch.Text + "%' or rp_supplier like '%" + txtsearch.Text + "%' ";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgv_table_2nd_sup.DataSource = dt;
            lblrepackcount.Text = dgv_table_2nd_sup.RowCount.ToString();
            sql_con.Close();

        }

        private void dgv_table_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgv_table_2nd_sup.Visible = true;
            dtgReceivingEntry.Visible = true;
        }

        private void txtsearchreceiving_TextChanged(object sender, EventArgs e)
        {
            String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=hr_bak;Integrated Security=SSPI";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "select r_item_id,received_id,r_item_code,r_supplier,totalnstock,selected_uom,uniquedate,days_to_expired from [dbo].[rdf_microreceiving_entry] WHERE r_item_code like '%" + txtsearch.Text + "%' or r_supplier like '%" + txtsearch.Text + "%' ";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dtgReceivingEntry.DataSource = dt;
            sql_con.Close();
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {

        }

        private void dtgReceivingEntry_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_table_2nd_sup_CurrentCellChanged(object sender, EventArgs e)
        {
            showValueRepackingLogs();
        }


        void showValueRepackingLogs()
        {

            if (dgv_table_2nd_sup.RowCount > 0)
            {
                if (dgv_table_2nd_sup.CurrentRow != null)
                {
                    if (dgv_table_2nd_sup.CurrentRow.Cells["rp_item_id"].Value != null)
                    {
                        p_id = Convert.ToInt32(dgv_table_2nd_sup.CurrentRow.Cells["rp_item_id"].Value);
                        //txtID.Text = dgv_table.CurrentRow.Cells["received_id"].Value.ToString();
                        txtretailid.Text = dgv_table_2nd_sup.CurrentRow.Cells["rp_item_id"].Value.ToString();
                        //txtsearchreceiving.Text = dgv_table.CurrentRow.Cells["item_code"].Value.ToString();


                    }

                }
            }

        }

        private void txtretailid_TextChanged(object sender, EventArgs e)
        {
            String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=hr_bak;Integrated Security=SSPI";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "select rp_item_id,rp_item_code,rp_supplier,totalnstock,selected_uom,uniquedate,days_to_expired from [dbo].[rdf_repackin_entry] WHERE rp_item_id like '%" + txtretailid.Text + "%' or rp_supplier like '%" + txtretailid.Text + "%' ";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvretaillogs.DataSource = dt;
            lblrepackcount.Text = dgvretaillogs.RowCount.ToString();
            sql_con.Close();
        }

        private void dtgReceivingEntry_CurrentCellChanged(object sender, EventArgs e)
        {

        }
    }
}
