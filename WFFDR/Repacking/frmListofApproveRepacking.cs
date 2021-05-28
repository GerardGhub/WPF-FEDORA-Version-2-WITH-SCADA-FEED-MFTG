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
using System.Threading;
using CrystalDecisions.CrystalReports.Engine;
using Tulpep.NotificationWindow;
using System.Drawing.Printing;
using System.IO;
using MetroFramework;
using MetroFramework.Forms;
using CrystalDecisions.Shared;

namespace WFFDR
{
    public partial class frmListofApproveRepacking : Form
    {

        //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI;MultipleActiveResultSets=true;";
        String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
        //deploy

        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr; SqlDataReader dr1;
        DataSet ds = new DataSet();

        IStoredProcedures objStorProc = null;

        myclasses xClass = new myclasses();

        Thread t;

        string year = DateTime.Now.ToString("yyyy");



        private int qweInt = 1;
        int p_id = 0;
        int i;
        DataSet dSet_temp = new DataSet();
        DataSet dSet = new DataSet();
        DataSet dset = new DataSet();
        DataSet dset2 = new DataSet();
        DataSet dset3 = new DataSet();
        string Rpt_Path = "";
        public myclasses classes = new myclasses();
        myclasses myClass = new myclasses();


        IStoredProcedures g_objStoredProcCollection = null;

        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();
        ReportDocument rpt = new ReportDocument();
        string mode = ""; //mymode

        DataSet dSets = new DataSet();



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        //etc123 qwe = new etc123();


        public frmListofApproveRepacking()
        {
            InitializeComponent();
        }

        private void btnstartrepacking_Click(object sender, EventArgs e)
        {
            //dgvMaster.Enabled = false;
        }

        private void btncancelrepacking_Click(object sender, EventArgs e)
        {
            //dgvMaster.Enabled = true;
        }

        private void txtsearchitems_TextChanged(object sender, EventArgs e)
        {


 

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            //deploy
            SqlConnection sql_con = new SqlConnection(connetionString);

            //string sqlquery = "select distinct rpa.item_code AS CODE,rpa.rp_description AS DESCRIPTION from [dbo].[rdf_recipe] rpa LEFT JOIN rdf_production_advance ax ON rpa.feed_code=ax.p_feed_code WHERE rpa.rp_category='MICRO' AND ax.repacking_status='ready' AND rpa.is_active=1 AND NOT rpa.repacking_status='1'  AND ax.proddate='" + txtdateplusone.Text + "' OR ax.proddate='" + dtpreceivingdate.Text + "' OR ax.proddate='" + txtdateminus1.Text + "' AND NOT ax.canceltheapprove IS NOT NULL ";



            string sqlquery = "select distinct ax.p_feed_code AS FEEDCODE,ax.prod_id,ax.proddate,ax.feed_type,ax.bagorbin,CAST(ax.proddate as date) as plannerdate,additional_bin,CAST(ax.prod_id as float) as mainid from [dbo].[rdf_production_advance] ax LEFT JOIN rdf_recipe_to_production rpa ON rpa.production_id=ax.prod_id WHERE rpa.repacking_status='1' AND ax.is_selected=1 AND rpa.is_active=1 AND ax.is_active=1  AND ax.canceltheapprove" +
                " IS NULL AND NOT rpa.rp_category='MACRO' AND (ax.proddate='" + dtpreceivingdate.Text + "' OR ax.proddate='" + txtdateminus1.Text + "' OR ax.proddate='" + txtdateplusone.Text + "' OR ax.proddate='" + txtdateofoutminus2.Text + "' OR ax.proddate ='" + txtplustwo.Text + "' OR ax.proddate ='" + txtplusthree.Text + "' OR ax.proddate ='"+ lbldateplus5.Text+ "') ORDER BY mainid ASC ";



            //string sqlquery = "select distinct rpa.item_code AS CODE,rpa.rp_description AS DESCRIPTION,ax.proddate AS PRODDATE from [dbo].[rdf_recipe_to_production] rpa LEFT JOIN rdf_production_advance ax ON rpa.feed_code=ax.p_feed_code WHERE ax.is_selected=1 AND rpa.is_active=1 AND ax.is_active=1 AND NOT rpa.repacking_status='1' AND ax.canceltheapprove IS NULL AND NOT rpa.rp_category='MACRO' AND (ax.proddate='" + dtpreceivingdate.Text + "' OR ax.proddate='" + txtdateminus1.Text + "' OR ax.proddate='" + txtdateplusone.Text + "' OR ax.proddate='" + txtdateofoutminus2.Text + "') ORDER BY ax.proddate ASC";
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgv1stView.DataSource = dt;

            lblraws.Text = dgv1stView.RowCount.ToString();
            sql_con.Close();

  
        }


        private void txtAllFeed_TextChanged(object sender, EventArgs e)
        {
  
        }

        private void dgv1stView_CurrentCellChanged(object sender, EventArgs e)
        {
            showRawMats();
            show3Fomula();
            //button4_Click_1(sender, e);
        }

        void showRawMats()
        {

            if (dgv1stView.RowCount > 0)
            {
                if (dgv1stView.CurrentRow != null)
                {
                    if (dgv1stView.CurrentRow.Cells["FEEDCODE"].Value != null)
                    {
                        //p_id = Convert.ToInt32(dgv1stView.CurrentRow.Cells["prod"].Value);

                        //txtitemcode.Text = dgv1stView.CurrentRow.Cells["CODE"].Value.ToString();


                        ////       txtdesviewone.Text = dgv1stView.CurrentRow.Cells["DESCRIPTION"].Value.ToString();

                        ////       txtsearchreceiving.Text = dgv1stView.CurrentRow.Cells["CODE"].Value.ToString();

                        ////      txtrawitemcode.Text = dgv1stView.CurrentRow.Cells["CODE"].Value.ToString();

                        ////txtrecommendedsearch.Text = dgv1stView.CurrentRow.Cells["CODE"].Value.ToString();
                        ///
                       lblbintype.Text = dgv1stView.CurrentRow.Cells["additional_bin"].Value.ToString();
                        lblprodid.Text = dgv1stView.CurrentRow.Cells["prod_id"].Value.ToString();
                        lblproductionid.Text = dgv1stView.CurrentRow.Cells["prod_id"].Value.ToString();
                lblbagorbin.Text = dgv1stView.CurrentRow.Cells["bagorbin"].Value.ToString();

                        lblfeedtype.Text = dgv1stView.CurrentRow.Cells["feed_typer"].Value.ToString();
                        lblproddate.Text = dgv1stView.CurrentRow.Cells["proddate"].Value.ToString();
                    }

                }
            }

        }


        private void txtitemcode_TextChanged(object sender, EventArgs e)
        {
            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);

            // AND rp_category='MICRO' ORDER BY rp_group
            string sqlquery = "select rpa.feed_code AS Feed_Code,rpa.rp_feed_type AS Feed_Type,rpa.rp_description,rpa.rp_group AS Groups,rpa.quantity AS Quantity,ax.p_nobatch AS Batch,rpa.production_id AS PRODID,rpa.item_code from [dbo].[rdf_recipe_to_production] rpa LEFT JOIN rdf_production_advance ax ON rpa.production_id=ax.prod_id WHERE rpa.rp_category='MICRO' AND rpa.production_id ='" + lblprodid.Text + "' AND rpa.is_active=1 AND ax.is_selected='1' AND ax.is_active=1 AND NOT ax.canceltheapprove IS NOT NULL  AND (ax.proddate='" + txtdateplusone.Text + "' OR ax.proddate='" + dtpreceivingdate.Text + "' OR ax.proddate='" + txtdateminus1.Text + "' OR ax.proddate='" + txtdateofoutminus2.Text + "' OR ax.proddate='" + txtplustwo.Text + "' OR ax.proddate='" + txtplusthree.Text + "' OR ax.proddate='"+lbldateplus5.Text+"') ORDER BY ax.prod_id ASC";





            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvAllFeedCode.DataSource = dt;
            lblrepack.Text = dgvAllFeedCode.RowCount.ToString();
            lblcountFcode.Text = dgvAllFeedCode.RowCount.ToString();

            sql_con.Close();


            for (int n = 0; n < (dgvAllFeedCode.Rows.Count); n++)
            {
                double s = Convert.ToDouble(dgvAllFeedCode.Rows[n].Cells[4].Value);


                //double s1 = Convert.ToDouble(dgvAllFeedCode.Rows[n].Cells[7].Value);

                double s1 = Convert.ToDouble(dgvAllFeedCode.Rows[n].Cells[5].Value);

                double s13 = s * 2;
                double s15 = s13 * s1;

                dgvAllFeedCode.Rows[n].Cells[4].Value = s15.ToString("#,0.00");
                //dgvAllFeedCode.Rows[n].Cells[4].Value = s13.ToString("#,0.000");
                //dgvAllFeedCode.Rows[n].Cells[7].Value = s15.ToString("#,0.000");
            }











            decimal tot = 0;

            for (int i = 0; i < dgvAllFeedCode.RowCount - 0; i++)
            {
                var value = dgvAllFeedCode.Rows[i].Cells["Quantity"].Value;
                if (value != DBNull.Value)
                {
                    tot += Convert.ToDecimal(value);
                }
            }
            if (tot == 0)
            {

            }

            decimal toty = 0;




            lblCountss200.Text = tot.ToString();
            label200.Text = toty.ToString();

        }

        public void RefreshDataGrid()
        {


            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);

            // AND rp_category='MICRO' ORDER BY rp_group
            string sqlquery = "select rpa.feed_code AS Feed_Code,rpa.rp_feed_type AS Feed_Type,rpa.rp_description,rpa.rp_group AS Groups,rpa.quantity AS Quantity,ax.p_nobatch AS Batch,rpa.production_id AS PRODID,rpa.item_code from [dbo].[rdf_recipe_to_production] rpa LEFT JOIN rdf_production_advance ax ON rpa.production_id=ax.prod_id WHERE rpa.rp_category='MICRO' AND rpa.production_id ='" + lblprodid.Text + "' AND rpa.is_active=1 AND ax.is_selected='1' AND ax.is_active=1 AND NOT ax.canceltheapprove IS NOT NULL  AND (ax.proddate='" + txtdateplusone.Text + "' OR ax.proddate='" + dtpreceivingdate.Text + "' OR ax.proddate='" + txtdateminus1.Text + "' OR ax.proddate='" + txtdateofoutminus2.Text + "' OR ax.proddate='" + txtplustwo.Text + "' OR ax.proddate='" + txtplusthree.Text + "' OR ax.proddate='"+lbldateplus5.Text+"') ORDER BY ax.prod_id ASC";





            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvAllFeedCode.DataSource = dt;
            lblrepack.Text = dgvAllFeedCode.RowCount.ToString();
            lblstatusremaining.Text = dgvAllFeedCode.RowCount.ToString();

            sql_con.Close();


            for (int n = 0; n < (dgvAllFeedCode.Rows.Count); n++)
            {
                double s = Convert.ToDouble(dgvAllFeedCode.Rows[n].Cells[4].Value);


                //double s1 = Convert.ToDouble(dgvAllFeedCode.Rows[n].Cells[7].Value);

                double s1 = Convert.ToDouble(dgvAllFeedCode.Rows[n].Cells[5].Value);

                double s13 = s * 2;
                double s15 = s13 * s1;

                dgvAllFeedCode.Rows[n].Cells[4].Value = s15.ToString("#,0.00");
                //dgvAllFeedCode.Rows[n].Cells[4].Value = s13.ToString("#,0.000");
                //dgvAllFeedCode.Rows[n].Cells[7].Value = s15.ToString("#,0.000");
            }











            decimal tot = 0;

            for (int i = 0; i < dgvAllFeedCode.RowCount - 0; i++)
            {
                var value = dgvAllFeedCode.Rows[i].Cells["Quantity"].Value;
                if (value != DBNull.Value)
                {
                    tot += Convert.ToDecimal(value);
                }
            }
            if (tot == 0)
            {

            }

            decimal toty = 0;




            lblCountss200.Text = tot.ToString();
            label200.Text = toty.ToString();



        }

        void RefreshMyDataGrid()
        {

            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);

            // AND rp_category='MICRO' ORDER BY rp_group
            string sqlquery = "select rpa.feed_code AS Feed_Code,rpa.rp_feed_type AS Feed_Type,rpa.rp_description,rpa.rp_group AS Groups,rpa.quantity AS Quantity,ax.p_nobatch AS Batch,rpa.production_id AS PRODID,rpa.item_code from [dbo].[rdf_recipe_to_production] rpa LEFT JOIN rdf_production_advance ax ON rpa.production_id=ax.prod_id WHERE rpa.rp_category='MICRO' AND rpa.production_id ='" + lblprodid.Text + "' AND rpa.is_active=1 AND ax.is_selected='1' AND ax.is_active=1 AND NOT ax.canceltheapprove IS NOT NULL  AND (ax.proddate='" + txtdateplusone.Text + "' OR ax.proddate='" + dtpreceivingdate.Text + "' OR ax.proddate='" + txtdateminus1.Text + "' OR ax.proddate='" + txtdateofoutminus2.Text + "' OR ax.proddate='" + txtplustwo.Text + "' OR ax.proddate='" + txtplusthree.Text + "' OR ax.proddate='"+lbldateplus5.Text+"') ORDER BY ax.prod_id ASC";


            //string sqlquery = "select rpa.feed_code AS Feed_Code,rpa.rp_feed_type AS Feed_Type,ax.p_nobatch AS Batch,rpa.rp_group AS Groups,rpa.quantity AS Quantity,rpa.production_id AS PRODID,rpa.rp_description from [dbo].[rdf_recipe_to_production] rpa LEFT JOIN rdf_production_advance ax ON rpa.production_id=ax.prod_id WHERE rpa.rp_category='MICRO' AND rpa.item_code ='" + txtitemcode.Text + "' AND rpa.is_active=1 AND ax.is_selected='1' AND ax.is_active=1 AND NOT ax.canceltheapprove IS NOT NULL  AND (ax.proddate='" + txtdateplusone.Text + "' OR ax.proddate='" + dtpreceivingdate.Text + "' OR ax.proddate='" + txtdateminus1.Text + "' OR ax.proddate='" + txtdateofoutminus2.Text + "') ORDER BY ax.prod_id ASC";

            //string sqlquery = "select rpa.feed_code AS Feed_Code,rpa.rp_feed_type AS Feed_Type,ax.p_nobatch AS Batch,rpa.rp_group AS Groups,rpa.item_code AS Item_Code,rpa.rp_description AS Description,rpa.quantity AS Quantity from [dbo].[rdf_recipe] rpa LEFT JOIN rdf_production_advance ax ON rpa.feed_code=ax.p_feed_code WHERE rpa.rp_category='MICRO' AND rpa.item_code ='" + txtitemcode.Text + "' AND rpa.is_active=1 AND ax.repacking_status='ready' ";



            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvAllFeedCode.DataSource = dt;
            lblrepack.Text = dgvAllFeedCode.RowCount.ToString();
            //lblcountFcode.Text = dgvAllFeedCode.RowCount.ToString();

            sql_con.Close();


            for (int n = 0; n < (dgvAllFeedCode.Rows.Count); n++)
            {
                double s = Convert.ToDouble(dgvAllFeedCode.Rows[n].Cells[4].Value);


                //double s1 = Convert.ToDouble(dgvAllFeedCode.Rows[n].Cells[7].Value);

                double s1 = Convert.ToDouble(dgvAllFeedCode.Rows[n].Cells[5].Value);

                double s13 = s * 2;
                double s15 = s13 * s1;

                dgvAllFeedCode.Rows[n].Cells[4].Value = s15.ToString("#,0.00");
                //dgvAllFeedCode.Rows[n].Cells[4].Value = s13.ToString("#,0.000");
                //dgvAllFeedCode.Rows[n].Cells[7].Value = s15.ToString("#,0.000");
            }











            decimal tot = 0;

            for (int i = 0; i < dgvAllFeedCode.RowCount - 0; i++)
            {
                var value = dgvAllFeedCode.Rows[i].Cells["Quantity"].Value;
                if (value != DBNull.Value)
                {
                    tot += Convert.ToDecimal(value);
                }
            }
            if (tot == 0)
            {

            }

            decimal toty = 0;




            lblCountss200.Text = tot.ToString();
            label200.Text = toty.ToString();
        }

        
        private void frmListofApproveRepacking_Load(object sender, EventArgs e)
        {
            txtbind.Visible = false;
            txtfinalstring.Visible = false;
            txtActualQty.Visible = false;

            dtpreceivingdate.Visible = false;
            txtproductionid.Visible = false;
            dgv1stView.Visible = false;
            txtdateplusone.Text = DateTime.Now.AddDays(1).ToString("M/d/yyyy");
            txtdateminus1.Text = DateTime.Now.AddDays(-1).ToString("M/d/yyyy");
            txtdateofoutminus2.Text = DateTime.Now.AddDays(-2).ToString("M/d/yyyy");
            txtplustwo.Text = DateTime.Now.AddDays(2).ToString("M/d/yyyy");
            txtplusthree.Text = DateTime.Now.AddDays(3).ToString("M/d/yyyy");
            lbldateplus5.Text = DateTime.Now.AddDays(4).ToString("M/d/yyyy");
            lblrepack.Visible = false;
            lblmainCount.Text = "0";
            bunifuStopRepacking.Visible = false;
            txtrecommendedsearch_TextChanged(sender, e);
            dtpreceivingdate.Value = DateTime.Now;
            dtprepackdate.Value = DateTime.Now;
            //txtillusion.BackColor = Color.Red;
            txtlastpack_TextChanged(sender, e);
            loadPrintingData();
            objStorProc = xClass.g_objStoredProc.GetCollections();

            //txtqtyoverall.Text = "120"; gagi
            txtrepackby.Text = userinfo.emp_name.ToUpper();

            lbluserid.Text = userinfo.user_id.ToString();
            if(lbluserid.Text =="2")
            {
                txtGood.Visible = true;
                lblavailable.Visible = true;
            }
            else
            {
                txtGood.Visible = false;
                lblavailable.Visible = false;
            }

            dgvActiveRepack.Visible = false;



            txtsearchitems_TextChanged(sender, e);




            txtBalance.Visible = false;
            myglobal.global_module = "Active";
            load_search();
            txt3rdsearch_TextChanged(sender, e);

            if (lblraws.Text == "0")
            {
                txtweighingscale.Enabled = false;
                txtweighingscale.BackColor = Color.White;
                lblfeedtype.Visible = false;
            }
            else
            {
                lblprodid.Text = dgv1stView.CurrentRow.Cells["prod_id"].Value.ToString();

                txtlastpack_TextChanged(sender, e);
            }

            txtitemcode_TextChanged(sender, e);
            txtsearchreceiving_TextChanged(sender, e);
            button4_Click_1(sender, e);


            dgv1stView.Columns[0].Width = 160;// The id column 
            dgv1stView.Columns[2].Width = 135;// The id column 

          



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

        void load_search()
        {

            dset_emp.Clear();



            dset_emp = objStorProc.sp_getMajorTables("ActiveMaterialRepack");

            doSearch();


        }
        DataSet dset_emp = new DataSet();
        void doSearch()
        {
            try
            {
                if (dset_emp.Tables.Count > 0)
                {
                    DataView dv = new DataView(dset_emp.Tables[0]);
                    if (myglobal.global_module == "EMPLOYEE")
                    {
                        //dv.RowFilter = "firstname like '%" + txtmainsearch.Text + "%' or lastname like '%" + txtsearch.Text + "%' or employee_number like '%" + txtsearch.Text + "%' or employment_status_name like '%" + txtsearch.Text + "%'";
                    }
                    else if (myglobal.global_module == "Active")
                    {

                        dv.RowFilter = "rp_item_code ='" + txtRawCode.Text + "'";

                    }
                    else if (myglobal.global_module == "VISITORS")
                    {
                        //dv.RowFilter = "visitors_lastname like '%" + txtsearch.Text + "%' or visitors_firstname like '%" + txtsearch.Text + "%'";
                    }
                    dgvActiveRepack.DataSource = dv;
                    lblactiverepack.Text = dgvActiveRepack.RowCount.ToString();
                    lblactiverepack.Text = (float.Parse(lblactiverepack.Text) + 1).ToString();
                    lblalreadyrepack.Text = (float.Parse(lblactiverepack.Text) - 1).ToString();
                }
            }
            catch (SyntaxErrorException)
            {
                MessageBox.Show("Invalid character found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            catch (EvaluateException)
            {
                MessageBox.Show("Invalid character found 2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            //if(lblcountFcode.Text.Trim() == lblmainCount.Text.Trim())
            //{


            //  lumpia



            //    lblmainCount.Text = "0";
            //}

        }



    

        void dataGridEmpty()
        {

            if (dgvStarChecking.Rows.Count > 0)
            {

                StartToday();
                //    MessageBox.Show("1");

                bunifuStart.Visible = false;

                bunifuStart.BackColor = Color.Yellow;


            }
            else
            {

                //MessageBox.Show("1");
                bunifuStart.Visible = true;

                //txtweighingscale.Focus();
                Startadvance();
                bunifuStart.BackColor = Color.White;


            }

        }
      

        private void txtsearchreceiving_TextChanged(object sender, EventArgs e)
        {

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "select r_item_id,received_id,r_item_code,totalnstock,r_mfg_date,r_expiry_date,days_to_expired,r_expected,r_actual_receiving,r_qty_delivered,QA_rgood,QA_reject,r_item_description,r_supplier,r_item_Category,r_qty_ordered,r_missing,actual_count_good,actual_count_reject,selected_uom,r_QA_by,r_receiving_by,r_total_delivered,r_waiting_delivered,r_primary_key,r_qty_delivered from [dbo].[rdf_microreceiving_entry] WHERE r_item_code='" + txtsearchreceiving.Text + "' AND receiving_status='1' ORDER BY days_to_expired ASC";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgv_table_2nd_sup.DataSource = dt;
            //dgv_table_2nd_sup.Columns["r_item_id2"].Visible = false;
            dgv_table_2nd_sup.Columns["totalnstock2"].Visible = false;
            dgv_table_2nd_sup.Columns["r_mfg_date"].Visible = false;
            dgv_table_2nd_sup.Columns["r_expiry_date"].Visible = false;
            lblreceived.Text = dgv_table_2nd_sup.RowCount.ToString();
            lbltotalreceived.Text = dgv_table_2nd_sup.RowCount.ToString();
            sql_con.Close();
        }
        
        private void dgv_table_2nd_sup_CurrentCellChanged(object sender, EventArgs e)
        {
            showVariable();
        }

        void showVariable()
        {

            if (dgv_table_2nd_sup.RowCount > 0)
            {
                if (dgv_table_2nd_sup.CurrentRow != null)
                {
                    if (dgv_table_2nd_sup.CurrentRow.Cells["received_id2"].Value != null)
                    {
                        p_id = Convert.ToInt32(dgv_table_2nd_sup.CurrentRow.Cells["received_id2"].Value);
                        txtID.Text = dgv_table_2nd_sup.CurrentRow.Cells["received_id2"].Value.ToString();
                        txtRawCode.Text = dgv_table_2nd_sup.CurrentRow.Cells["r_item_code2"].Value.ToString();
                        txttotalofStock.Text = dgv_table_2nd_sup.CurrentRow.Cells["totalnstock2"].Value.ToString();
                        txtGood.Text = dgv_table_2nd_sup.CurrentRow.Cells["actual_count_good"].Value.ToString();
                        //txtGood.Text = dgvMaster2.CurrentRow.Cells["qty_repack_available"].Value.ToString();
                        txtItemDescription.Text = dgv_table_2nd_sup.CurrentRow.Cells["r_item_description"].Value.ToString();
                        txtMainSupplier.Text = dgv_table_2nd_sup.CurrentRow.Cells["r_supplier2"].Value.ToString();

                        txtxp.Text = dgv_table_2nd_sup.CurrentRow.Cells["days_to_expired2"].Value.ToString();
                        txtexpected.Text = dgv_table_2nd_sup.CurrentRow.Cells["r_expected"].Value.ToString();
                        txtactualreceived.Text = dgv_table_2nd_sup.CurrentRow.Cells["r_actual_receiving"].Value.ToString();
                        cboCategory.Text = dgv_table_2nd_sup.CurrentRow.Cells["r_item_category"].Value.ToString();
                        txtqtymissing.Text = dgv_table_2nd_sup.CurrentRow.Cells["r_missing"].Value.ToString();
                        txtwhgood.Text = dgv_table_2nd_sup.CurrentRow.Cells["actual_count_good"].Value.ToString();
                        txtwhreject.Text = dgv_table_2nd_sup.CurrentRow.Cells["actual_count_reject"].Value.ToString();
                        txtuom.Text = dgv_table_2nd_sup.CurrentRow.Cells["selected_uom2"].Value.ToString();

                        txtqtyordered.Text = dgv_table_2nd_sup.CurrentRow.Cells["r_qty_ordered"].Value.ToString();
                        mfg_datePicker.Text = dgv_table_2nd_sup.CurrentRow.Cells["r_mfg_date"].Value.ToString();
                        xpired.Text = dgv_table_2nd_sup.CurrentRow.Cells["r_expiry_date"].Value.ToString();
                        ////txtActualQty.Text = dgv_table_2nd_sup.CurrentRow.Cells["r_qty_delivered2"].Value.ToString(); //remove qty_delivered

                        txtActualQty.Text = dgv_table_2nd_sup.CurrentRow.Cells["actual_count_good"].Value.ToString();
                        txtactualqtydeb.Text = dgv_table_2nd_sup.CurrentRow.Cells["r_qty_delivered2"].Value.ToString(); //remove qty_delivered

                        txtQAgood.Text = dgv_table_2nd_sup.CurrentRow.Cells["QA_rgood"].Value.ToString();
                        txtQAreject.Text = dgv_table_2nd_sup.CurrentRow.Cells["QA_reject"].Value.ToString();
                        txtQAby.Text = dgv_table_2nd_sup.CurrentRow.Cells["r_QA_by"].Value.ToString();
                        txtwhreceiving.Text = dgv_table_2nd_sup.CurrentRow.Cells["r_receiving_by"].Value.ToString();
                        txtqtytotaldelivered.Text = dgv_table_2nd_sup.CurrentRow.Cells["r_total_delivered"].Value.ToString();
                        txtwaitingdeliver.Text = dgv_table_2nd_sup.CurrentRow.Cells["r_waiting_delivered"].Value.ToString();
                        txtprimarypo.Text = dgv_table_2nd_sup.CurrentRow.Cells["r_primary_key"].Value.ToString();
                    }

                }
            }

        }
      


        void WarningNoInventory()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.ContentText = "No Inventory at This Entry '" + txtdesviewone.Text + "'";
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);

            popup.BodyColor = Color.DarkOrange;
            popup.Popup();

            popup.ContentColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            //popup.AnimationDuration = 1000;
            //popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);

            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }


        void CancelNotif()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.ContentText = "YOUR REQUEST FOR STOP REPACKING IS CANCELED";
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Green;
            popup.Popup();

            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            //popup.AnimationDuration = 1000;
            //popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);

            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }

        void StartRepackNotif()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.ContentText = "STARTING REPACKING ENTRY . . . . .";
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Green;
            popup.Popup();

            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            //popup.AnimationDuration = 1000;
            //popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);

            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }

        void Startadvance()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.ContentText = "ADVANCED REPACKING ENTRY ALREADY STOP";
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Red;
            popup.Popup();

            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            //popup.AnimationDuration = 1000;
            //popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);

            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }

        void FirstLine()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.ContentText = "YOU ARE ALREADY IN THE FIRST LINE";
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Green;
            popup.Popup();

            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            //popup.AnimationDuration = 1000;
            //popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);

            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;
            txtweighingscale.Select();
            txtweighingscale.Focus();

        }

        void LastLine()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.ContentText = "YOU ARE ALREADY IN THE LAST LINE";
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Red;
            popup.Popup();

            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            //popup.AnimationDuration = 1000;
            //popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);

            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }


        void RepackIDtoRepack()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.ContentText = "NO DATA FOUND !";
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Red;
            popup.Popup();

            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            //popup.AnimationDuration = 1000;
            //popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);

            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;

            txtitemcode_TextChanged(new object(), new System.EventArgs());
        }

        void StartToday()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.ContentText = "Starting Today Repacking Entry";
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.LightBlue;
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


        

        private void dgvAllFeedCode_CurrentCellChanged(object sender, EventArgs e)
        {
            show3Fomula();
        }

        void show3Fomula()
        {

            if (dgvAllFeedCode.RowCount > 0)
            {
                if (dgvAllFeedCode.CurrentRow != null)
                {
                    if (dgvAllFeedCode.CurrentRow.Cells["Feed_Code"].Value != null)
                    {
                        //p_id = Convert.ToInt32(dgv_table_2nd_sup.CurrentRow.Cells["received_id2"].Value);
                        txtselectweight.Text = dgvAllFeedCode.CurrentRow.Cells["Quantity"].Value.ToString();
                        cboDescription.Text = dgvAllFeedCode.CurrentRow.Cells["Feed_Code"].Value.ToString();
                        txtbatch.Text = dgvAllFeedCode.CurrentRow.Cells["Batch"].Value.ToString();
                        txtproductionid.Text = dgvAllFeedCode.CurrentRow.Cells["PRODID"].Value.ToString();
                        lblitemcode.Text = dgvAllFeedCode.CurrentRow.Cells["item_code1"].Value.ToString();
                        txtrawitemcode.Text = dgvAllFeedCode.CurrentRow.Cells["item_code1"].Value.ToString();
                        txtsearchreceiving.Text = dgvAllFeedCode.CurrentRow.Cells["item_code1"].Value.ToString();
                        txtdesviewone.Text = dgvAllFeedCode.CurrentRow.Cells["item_code1"].Value.ToString();
                        txtrecommendedsearch.Text = dgvAllFeedCode.CurrentRow.Cells["item_code1"].Value.ToString();
                    }

                }
            }

        }


        private void txtActualQty_TextChanged(object sender, EventArgs e)
        {


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (txtillusion.BackColor == Color.LightGreen)
            {
                txtillusion.BackColor = Color.LightBlue;
            }
            else
            {
                txtillusion.BackColor = Color.LightGreen;
            }


            if (txtweighingscale.Text.Trim() == string.Empty)
            {
                //this.BackColor = Color.CornflowerBlue; lako kepamu be
                timer1.Enabled = true;
                SendKeys.SendWait("{F7}"); // How to press enter?

            }
            else
            {

                if (txtselectweight.Text.Trim() == txtweighingscale.Text.Trim())
                {
                    timer1.Stop();
                    //MessageBox.Show("Same Data Proccesd!, Choose anothe entry Thanks:]"); //tiger
                    SameWeightNotify();
                    txtweighingscale.BackColor = Color.LightGreen;

                    //txtRawCode.Visible = true;
                    //label11.Visible = true;
                    txtweighingscale.Enabled = false;
                    btnReprint.Visible = false;

                    //txtRawCode.Select();
                    //txtRawCode.Focus();
                    //textBox1_Click(sender, e);
                    return;



                }
                else
                {
                    //MessageBox.Show("Error Not match!, Choose anothe entry Thanks:]");
                }



                //this.BackColor = Color.Red; comment my
                txtweighingscale.Text = "";

                SendKeys.SendWait("{F7}"); // How to press enter?
                //timer1.Enabled = false;
            }

        }
        void SameWeightNotify()
        {
            //deploy comment
            //PopupNotifier popup = new PopupNotifier();
            //popup.Image = Properties.Resources.info;
            //popup.TitleText = "Fedora Notifications";
            //popup.TitleColor = Color.White;
            //popup.TitlePadding = new Padding(95, 7, 0, 0);
            //popup.TitleFont = new Font("Tahoma", 10);
            //popup.ContentText = "Actual weight meet the standard weigfht ready for Repack";
            //popup.ContentColor = Color.White;
            //popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            //popup.Size = new Size(920, 270);
            //popup.ImageSize = new Size(175, 180);
            //popup.BodyColor = Color.Green;
            //popup.Popup();
            ////popup.AnimationDuration = 1000;
            ////popup.ShowOptionsButton.ToString();
            //popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            ////txtMainInput.Focus();
            ////txtMainInput.Select();
            //popup.Delay = 500;
            //popup.AnimationInterval = 10;
            //popup.AnimationDuration = 1000;


            //popup.ShowOptionsButton = true;

            btnSubmit.Visible = true;
            button5.Visible = true;
        }


        void RepackFinishNotify()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Raw Material repack successfully";
            popup.ContentColor = System.Drawing.Color.FromArgb(255, 255, 255);
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

            button5.Visible = false;
            doSearch();


        }


        void LowQuantityNotify()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "ACTUAL QTY ALREADY LOW FEDORA SYSTEM WILL BE SELECET ANOTHER RECEIVING ENTRY";
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

        private void txtweighingscale_Click(object sender, EventArgs e)
        {
            timer1_Tick(sender, e);
        }

        private void txtselectweight_TextChanged(object sender, EventArgs e)
        {

           
        }



        public void WarningNotifierScale()
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);

            popup.ContentText = "Please check the Weighing Scale Weighing Scale Connection Error";

            popup.ContentColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);


            popup.ContentHoverColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentPadding = new Padding(0);

            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80); ;
            popup.BodyColor = Color.DarkOrange;
            popup.Popup();
            //popup.AnimationDuration = 1000;
            //popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            txtweighingscale.Focus();

            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }

       void ByPassStockoutofReceiving()
        {
            //valentine source

            txtBalance.BackColor = Color.Yellow;

            groupBox1.Visible = true;
            groupBox5.Visible = true;



            SecondReceivingBindingSource();





            if (txtSecondReceivingCount.Text == "0")
            {

                //MessageBox.Show("No Data for Receiving 544545");
                //return;
                NoreceivingBindingSource();
                if (txtSecondReceivingCount.Text == "0")
                {



                }
                else
                {

                    MessageBox.Show("No Data for Receiving");
                    return;
                }
            }



            //bagong Puke

           

                txtSecondReceivedId.Text = dgvReceiving.CurrentRow.Cells["received_id"].Value.ToString();




              
                //gerard singian
                //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
                String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
                //deploy
                txtdatenowstamp.Text = DateTime.Now.ToString();

                SqlConnection sql_con = new SqlConnection(connetionString);



                string sqlquery = "UPDATE [dbo].[rdf_microreceiving_entry] SET receiving_status = '0',production_id_last_used='" + lblprodid.Text + "',target_weight='" + txtselectweight.Text + "',last_receiving_id='" + txtSecondReceivedId.Text + "',time_stamp_out='" + txtdatenowstamp.Text + "'  WHERE received_id = '" + txtID.Text + "'";

                sql_con.Open();
                SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
                SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
                DataTable dt = new DataTable();
                sdr.Fill(dt);
                dgvStockout.DataSource = dt;













                sql_con.Close();


                ////


                ////bags computation
                double bag1;
                double bag2;
                double baganswer;

                bag1 = double.Parse(txtselectweight.Text);
                bag2 = double.Parse(txtActualQty.Text);
                //bag2 = double.Parse(txtBalance.Text);
                ////baganswer = bag1 * 20;
                baganswer = bag1 - bag2;
                //baganswer = Math.Round(baganswer);
                //baganswer = Math.Round(baganswer);
                txtSubQtyShared.Text = Convert.ToString(baganswer);
                //
                txtrecommendedsearch_TextChanged(new object(), new System.EventArgs());

                //end

            

        }

        private void button2_Click(object sender, EventArgs e)
        {




            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to save the Transaction ? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                //MacroIfExist();
                if (lblraws.Text == "0")
                {
                    NoDataNotify();
                    txtselectweight.Enabled = false;
                    return;
                }


                btnSubmit.Visible = false;



                ///Pussy fucker 

                if (txtGood.Text.Trim() == txtweighingscale.Text.Trim())
                {

                }
                else
                {
                    forStockoutReceiving();
                }
                
 
                double mainbalance;
                double selectquantity;


                mainbalance = double.Parse(textBox1.Text);
                selectquantity = double.Parse(lblCountss200.Text);
                if (mainbalance < selectquantity)
                {
                    NoBalanceNotify();
          
                }
                else
                {

                }



                double ActualDeb;
                double SelectedWeightDeb;

                ActualDeb = double.Parse(txtActualQty.Text);
                SelectedWeightDeb = double.Parse(txtselectweight.Text);

                if (ActualDeb <= SelectedWeightDeb)
                {


                    if (txtneededqty.Text.Trim() == string.Empty)
                    {
                        ////MessageBox.Show("select ok in notifier");
                        ////return; alis muna 4/11/2020
                    }
                }

                else
                {


                }

                if (txtselectweight.Text.Trim() == string.Empty)
                {

                    MessageBox.Show("Please Select an Standard Weight", "Weighing Scale Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    cboDescription.Select();
                    return;

                }


                if (txtweighingscale.Text.Trim() == string.Empty)
                {
                    //MessageBox.Show("Please check the Weighing Scale", "Weighing Scale Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Information); NCOV
                    txtweighingscale.Focus();


                    WarningNotifierScale();
                    txtweighingscale.BackColor = Color.Yellow;
                    txtweighingscale_Click(sender, e);
                    return;

                }
                //3/21/2020
                ////if (txtselectweight.Text.Trim() == txtRawCode.Text.Trim())
                ////{
                ////    MessageBox.Show("2nd Entry of Checking Actual Quantity Succesfully!", "Ready To Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ////}
                ////else
                ////{
                ////    MessageBox.Show("Error", "Actual Quantity Change Immediately Error @ 2 Step checking Authentications", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ////    txtweighingscale_Click(sender, e);
                ////    txtselectweight.Focus();
                ////    txtselectweight.Select();
                ////    txtweighingscale.BackColor = Color.Yellow;
                ////    txtRawCode.BackColor = Color.LightGreen;
                ////    timer2.Stop();
                ////    return;
                ////}




                //if (txtID.Text.Trim() == lblsupreceivedid.Text.Trim())
                //{
                //    MessageBox.Show("Error same selection of Receiving Entry!, Choose anothe entry Thanks:]");
                //    return;
                //}
                //else
                //{
                //remove same selectio 3/23/2020
                //}




                ////bags computation
                double bag11;
                double bag22;
                double baganswers;
                double Allowances;

                bag11 = double.Parse(txtselectweight.Text);
                bag22 = double.Parse(txtActualQty.Text);
                ////baganswer = bag1 * 20;
                baganswers = bag11 - bag22;
                Allowances = baganswers + 10;





                if (txtselectweight.Text.Trim() == txtweighingscale.Text.Trim())
                {


                    //MessageBox.Show("same 2 Step Validation Succeed!"); Gerard 3/21/20

                    //qty raw materia; repack available
                    //first


                    ////double rp1;
                    ////double rp2;
                    ////double rpavailable;

                    ////rp1 = double.Parse(txtqtyoverall.Text);
                    ////rp2 = double.Parse(txtselectweight.Text);

                    ////rpavailable = rp1 + rp2;


                    ////txtrpavailable.Text = Convert.ToString(rpavailable); 3/22/2020

                    double ActualQtyP;
                    double SelectedWeight;

                    ActualQtyP = double.Parse(txtActualQty.Text);
                    SelectedWeight = double.Parse(txtselectweight.Text);

                    if (ActualQtyP <= SelectedWeight)
                    {
                        ////bags computation
                        double qty1;
                        double qty2;
                        double qtyanswer;

                        qty1 = double.Parse(txtSubQty.Text);
                        qty2 = double.Parse(txtSubQtyShared.Text);
                        qtyanswer = qty1 - qty2;
                        txtSubActual.Text = Convert.ToString(qtyanswer);


                        txtsearchpa_TextChanged(sender, e);  //Search for Receiving
                        txtsearchreceiving_TextChanged(sender, e);
                        txtrecommendedsearch_TextChanged(sender, e); //Search for Recommended top 2


                        try
                        {
                            txtqtyndeb.Text = (float.Parse(txtSubQty.Text) - float.Parse(txtSubQtyShared.Text)).ToString();//4/11/2020


                        }
                        catch (Exception)
                        {


                        }
                    }

                    else
                    {
                        try
                        {


                            txtqtyndeb.Text = (float.Parse(txtBalance.Text) * 1).ToString();
                        }
                        catch (Exception)
                        {


                        }

                        txtSubSupplier.Text = "";
                        txtSubItemCode.Text = "";
                        txtSubQty.Text = "";
                        txtSubDateReceived.Text = "";
                        txtSubexpired.Text = "";
                        lblsupreceivedid.Text = "";
                    }


                    txtlastpack_TextChanged(sender, e);  // searching methods
                    datalastpack_CurrentCellChanged(sender, e);  // bind the text
                    txtbind_TextChanged(sender, e); //  Execute the Final String

                    InsertDatatoPreparation(); // Insert materials Into the Basemixed
                    //txtfinalstring
                    mode = "add";
                    if (txtItemDescription.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Please enter Contact Details", "Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (saveMode())
                        {
                            /// loadSupplier();
                            string tmode = mode;

                            if (tmode == "add")
                            {
                                //  dgv1.CurrentCell = dgv1[0, dgv1.Rows.Count - 1];



                                RepackFinishNotify(); //Message Notifier
                                txtBalance.Text = "";
                                QueryUpdateforQArecipe(); //Repacking Details update
     
                                btnOutMaterial_Click(sender, e);//add into zero rdf recipe status


                                txtBalance.BackColor = Color.White;
                                txtqtyndeb.Text = "";
                                txtsearchreceiving_TextChanged(sender, e);

                                //march 23 at the top
                                txtweighingscale.Enabled = true;
                                //MessageBox.Show("Raw Materials Repack SuccesFully.", "Raw Material Repacking", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                txtmainsearch_TextChanged(sender, e); // 3 9 /2020
                                txtrawitemcode_TextChanged(sender, e);
                                //txtbind_TextChanged(sender, e); //  /3 /9 /20

                                //txtlastpack_TextChanged(sender, e);  // searching methods
                                //datalastpack_CurrentCellChanged(sender, e);  // 39 20

                                //load_RawNMaster(); Close MUna itech
                                groupBox7.Visible = true;
                                dataView.Visible = true;
                                loadPrintingData();
                                dataView.Rows[i].Cells["selected"].Value = true;
                                btnSubmit.Visible = false;
                                txtweighingscale.Text = "";
                                //btnSubmit.Enabled = false;
                                //Button1.Enabled = true;
                                //calling the dashboards!

                                //load_macro_count(); lakokepa sinbit
                                button2_Click_1(sender, e);
                                txtweighingscale.BackColor = Color.Yellow;





                                if (lblmainCount.Text == "0")
                                {
                                    //lblmainCount.Text = "1";
                                }

                                else
                                {
                                }


                                double MainCountPlus1;
                                //double rp2;
                                double Answered;

                                MainCountPlus1 = double.Parse(lblmainCount.Text);


                                Answered = MainCountPlus1 + 1;

                                lblmainCount.Text = Convert.ToString(Answered);

                                //RepackingProcess();



                                bunifuRepackingProcess_Click(sender, e);


                            }
                            else
                            {
                                //  dgv1.CurrentCell = dgv1[0, temp_hid];
                            }


                        }
                        else
                            MessageBox.Show("Failed");

                    }






                }
                else
                {
                    MessageBox.Show("Confirm standard weight is not matched with actual weight..?");



                    if (bag11 > bag22)
                    {
                        MessageBox.Show("Lest THan kulang !");
                        groupBox1.Visible = true;
                        //btnbrowse.Enabled = true;
                        groupBox5.Visible = true;


                        if (txtshareddeb.Text.Trim() == string.Empty)
                        {
                            MessageBox.Show("Please Select another Receiving Entry at the DataGrid !", "Sub Supplier Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //NeededProcedure();
                            dgvStockout.Visible = true;

                            txtneededqty.Text = Convert.ToString(baganswers);
                            return;

                        }




                        //txtneededqty.Text = Convert.ToString(baganswer);
                        txtAllowance.Text = Convert.ToString(Allowances);






                        return;
                    }

                    else
                    {
                        MessageBox.Show("Greater Than");
                        txtselectweight.Focus();
                        txtselectweight.Select();
                        txtweighingscale_Click(sender, e);
                        return;
                    }



                    //return;
                }


                //if (bag1 > bag2)
                //{
                //    MessageBox.Show("Lest THan");
                //    btnbrowse.Enabled = true;

                //    txtneededqty.Text = Convert.ToString(baganswer);
                //    txtAllowance.Text = Convert.ToString(Allowance);


                //    return;
                //}

                //else
                //{
                //    MessageBox.Show("Greater Than");
                //    return;
                //}

                txt3rdsearch_TextChanged(sender, e); //refresh bottom 5/15/2020
                load_search();
                txtRawCode_TextChanged(sender, e);
                if (lblraws.Text == "0")
                {
                    NoDataNotify();
                    txtweighingscale.Enabled = false;
                    timer1.Stop();
                    return;
                }
                else
                {
                    timer1_Tick(sender, e);
                    txtweighingscale.Focus();
                    txtweighingscale.Select();
                }

                //doSearch();
                //txtsearchitems_TextChanged(sender, e);


                //txtsearchreceiving_TextChanged(sender, e);
                //button4_Click_1(sender, e);

                RefreshMyDataGrid();
                show3Fomula();


                if (groupBox7.Visible == true)
                {
                    btnReprint.Visible = true;
                }
                if (lblmainCount.Text == "0")
                {

                    txtsearchitems_TextChanged(sender, e);
                    lblprodid.Text = dgv1stView.CurrentRow.Cells["prod_id"].Value.ToString();
                    txtitemcode_TextChanged(sender, e);

                    show3Fomula();
                    txtsearchreceiving_TextChanged(sender, e);


                }
                RefreshDataGrid();
                show3Fomula();
                lblcountFcode.Visible = false;
                lblstatusremaining.Visible = true;//kara


                //Visible hide the buttons
                button2.Visible = false;
            }

            else
            {

                return;
            }


        }


        public void loadPrintingData()
        {



            if (myClass.g_objStoredProc.getConnected() == true)
            {
                g_objStoredProcCollection = myClass.g_objStoredProc.GetCollections();

                dset = g_objStoredProcCollection.sp_IDGenerator(0, "SelectHR", "", "", 1);
                dset2 = g_objStoredProcCollection.sp_IDGenerator(1, "SelectCompany", "", "", 1);

                Rpt_Path = WFFDR.Properties.Settings.Default.fdg;

                //Rpt_Path = ini.IniReadValue("PATH", "Report_Path");

                xClass.ActivitiesLogs(userinfo.emp_name + " Generated " + myglobal.REPORT_NAME + " Report");
            }
            else
            {
                MessageBox.Show("Unable to connect in sql server", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }


            int number_of_rows = dset2.Tables[0].Rows.Count - 1;



            dset = g_objStoredProcCollection.sp_IDGenerator(1, "SearchRepackingFiltered", "All", txtSearchx.Text, 1);
            dataView.DataSource = dset.Tables[0];



            for (int i = 0; i <= dataView.RowCount; i++)
            {
                try
                {
                    dataView.Rows[i].Cells["selected"].Value = false;
                }
                catch (Exception) { }
            }

            try
            {
                //cmbHR_OIC.SelectedIndex = cmbHR_OIC.FindString("Rollaine Palo");
            }
            catch (Exception) { }

            rbt_check();



        }


        void rbt_check()
        {
            if (radioButton1.Checked == true)
            {
                mode = "company";
            }
            else if (radioButton2.Checked == true)
            {
                mode = "hw";
            }
        }





        public bool saveMode()
        {
            txtdatenowstamp.Text = DateTime.Now.ToString();

            if (mode == "add")
            {
                dSet.Clear();
                dSet = objStorProc.rdf_sp_new_micro_repacking(0, txtID.Text, cboCategory.Text, txtItemDescription.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "","", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "getbyname");

                if (dSet.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Raw Material Repacking is already added.", "Raw Materials", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //submit button that will be disabled 
                    btnSubmit.Enabled = false;

                    //calling the dashboard counts

                    //load_macro_count(); lakoe kepa
                    return false;
                }

                else
                {
                    dSet.Clear();

                    //goal muna ko to gagu!
                    dSets = objStorProc.rdf_sp_new_micro_repacking(0, txtID.Text.Trim(), cboCategory.Text.Trim(), txtRawCode.Text.Trim(), txtMainSupplier.Text.Trim(), txtItemDescription.Text.Trim(), lblactiverepack.Text.Trim(), txttotalofStock.Text.Trim(), mfg_datePicker.Text.Trim(), xpired.Text.Trim(), txtwhreject.Text.Trim(), txtxp.Text.Trim(), dtpreceivingdate.Text.Trim(), txtItemDescription.Text.Trim(), txtwhgood.Text.Trim(), txtwhreject.Text.Trim(), txtuom.Text.Trim(), "0", "0", "1", mfg_datePicker.Text.Trim(), xpired.Text.Trim(), txtqtyordered.Text.Trim(), txtQAby.Text.Trim(), txtexpected.Text.Trim(), txtqtymissing.Text.Trim(), txtactualreceived.Text.Trim(), txtQAgood.Text.Trim(), txtQAreject.Text.Trim(), txtwhreceiving.Text.Trim(), txtqtytotaldelivered.Text.Trim(), txtwaitingdeliver.Text.Trim(), txtselectweight.Text.Trim(), txtrepackby.Text.Trim(), txtmainstocks.Text.Trim(), txtBalance.Text.Trim(), txtneededqty.Text.Trim(), txtshareddeb.Text.Trim(), txtprimarypo.Text.Trim(), txtrpavailable.Text.Trim(), txtbatch.Text.Trim(), cboDescription.Text.Trim(), txtSubSupplier.Text.Trim(), lblsupreceivedid.Text.Trim(), txtSubItemCode.Text.Trim(), txtSubDateReceived.Text.Trim(), txtSubexpired.Text.Trim(), txtqtyndeb.Text.Trim(), txtSubQtyShared.Text.Trim(), txtSubActual.Text.Trim(), txtfinalstring.Text.Trim(), "MICROTO", txtproductionid.Text.Trim(), lblproddate.Text.Trim(),txtdatenowstamp.Text.Trim(), "add");


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




        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void txtrecommendedsearch_TextChanged(object sender, EventArgs e)
        {

            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            //deploy

            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "select TOP 2 r_item_id,received_id,r_item_code,r_supplier,totalnstock,selected_uom,uniquedate,r_qty_delivered,days_to_expired,actual_count_good AS WHGood from [dbo].[rdf_microreceiving_entry] WHERE r_item_code= '" + txtrecommendedsearch.Text + "' AND r_item_category='MICRO' AND receiving_status='1' ORDER BY days_to_expired ASC";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvStockout.DataSource = dt;
            sql_con.Close();
        }

        private void txtsearchpa_TextChanged(object sender, EventArgs e)
        {
            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            //deploy

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "select r_item_id,received_id,r_item_code,totalnstock,r_mfg_date,r_expiry_date,days_to_expired,r_expected,r_actual_receiving,r_qty_delivered,QA_rgood,QA_reject,r_item_description,r_supplier,r_item_Category,r_qty_ordered,r_missing,actual_count_good,actual_count_reject,selected_uom,r_QA_by,r_receiving_by,r_total_delivered,r_waiting_delivered,r_primary_key,r_qty_delivered from [dbo].[rdf_microreceiving_entry] WHERE r_item_code='" + txtrawitemcode.Text + "' AND receiving_status='1' ORDER BY days_to_expired ASC";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgv_table_2nd_sup.DataSource = dt;
            //dgv_table_2nd_sup.Columns["r_item_id2"].Visible = false;
            dgv_table_2nd_sup.Columns["totalnstock2"].Visible = false;
            dgv_table_2nd_sup.Columns["r_mfg_date"].Visible = false;
            dgv_table_2nd_sup.Columns["r_expiry_date"].Visible = false;
            lbldebsupplier.Text = dgv_table_2nd_sup.RowCount.ToString();
            sql_con.Close();
        }

        private void txtmainsearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbind_TextChanged(object sender, EventArgs e)
        {
            try
            {


                txtfinalstring.Text = (float.Parse(txtbind.Text) + 1).ToString();
            }
            catch (Exception)
            {


            }
        }

        private void txtlastpack_TextChanged(object sender, EventArgs e)
        {

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            //deploy
            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "select TOP 1 repack_id from [dbo].[rdf_repackin_entry] WHERE rp_item_category='MICRO' ORDER BY repack_id DESC ";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            datalastpack.DataSource = dt;
            sql_con.Close();
        }

        private void datalastpack_CurrentCellChanged(object sender, EventArgs e)
        {
            lastIDrepack();
        }

        void lastIDrepack()
        {

            if (datalastpack.RowCount > 0)
            {
                if (datalastpack.CurrentRow != null)
                {
                    if (datalastpack.CurrentRow.Cells["repack_id"].Value != null)
                    {
                        p_id = Convert.ToInt32(datalastpack.CurrentRow.Cells["repack_id"].Value);


                        //txtmainstocks.Text = dgvMaster.CurrentRow.Cells["total_quantity_raw"].Value.ToString(); alsi muna

                        txtbind.Text = datalastpack.CurrentRow.Cells["repack_id"].Value.ToString();









                        //wala muna this


                    }

                }
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            //proceess of repack kupra

            for (int i = 0; i <= dataView.RowCount - 1; i++)
            {
                try
                {
                    if (Convert.ToBoolean(dataView.Rows[i].Cells["selected"].Value.ToString()) == true)
                    {
                        dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dataView.Rows[i].Cells["ID"].Value.ToString()), "updaterepacking", "", "", 1);
                    }
                    else
                    {
                        dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dataView.Rows[i].Cells["ID"].Value.ToString()), "updaterepacking", "", "", 0);
                    }
                }
                catch
                {

                    dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dataView.Rows[i].Cells["ID"].Value.ToString()), "updaterepacking", "", "", 0);
                }

            }







            PrintDialog printDialog = new PrintDialog();


  


            rpt.Load(Rpt_Path + "\\MainRepackingBarcodeMicro.rpt");

            rpt.SetDatabaseLogon("sa", "FMf3dor@2o20");

            rpt.Refresh();
            myglobal.DATE_REPORT2 = txtfinalstring.Text;
            string mystringid = myglobal.DATE_REPORT2;
            rpt.SetParameterValue("@mystringid", mystringid);



            crV1.ReportSource = rpt;
            crV1.Refresh();



            rpt.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;


            rpt.PrintToPrinter(printDialog.PrinterSettings.Copies, printDialog.PrinterSettings.Collate, printDialog.PrinterSettings.ToPage, printDialog.PrinterSettings.ToPage);

            timer1_Tick(sender, e);
        }

        void ReprintingMethod()
        {
            //proceess of repack kupra

            for (int i = 0; i <= dataView.RowCount - 1; i++)
            {
                try
                {
                    if (Convert.ToBoolean(dataView.Rows[i].Cells["selected"].Value.ToString()) == true)
                    {
                        dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dataView.Rows[i].Cells["ID"].Value.ToString()), "updaterepacking", "", "", 1);
                    }
                    else
                    {
                        dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dataView.Rows[i].Cells["ID"].Value.ToString()), "updaterepacking", "", "", 0);
                    }
                }
                catch
                {

                    dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dataView.Rows[i].Cells["ID"].Value.ToString()), "updaterepacking", "", "", 0);
                }

            }







            PrintDialog printDialog = new PrintDialog();





            rpt.Load(Rpt_Path + "\\MainRepackingBarcodeMicroWithMarks.rpt");

            rpt.SetDatabaseLogon("sa", "FMf3dor@2o20");

            rpt.Refresh();
            myglobal.DATE_REPORT2 = txtMyLastID.Text;
            string mystringid = myglobal.DATE_REPORT2;
            rpt.SetParameterValue("@mystringid", mystringid);



            crV1.ReportSource = rpt;
            crV1.Refresh();



            rpt.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;


            rpt.PrintToPrinter(printDialog.PrinterSettings.Copies, printDialog.PrinterSettings.Collate, printDialog.PrinterSettings.ToPage, printDialog.PrinterSettings.ToPage);

            timer1_Tick(new object(), new System.EventArgs());
        }


        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                for (int i = 0; i <= dataView.RowCount; i++)
                {
                    try
                    {
                        dataView.Rows[i].Cells["selected"].Value = true;
                    }
                    catch (Exception) { }
                }
            }
            else
            {

                for (int i = 0; i <= dataView.RowCount; i++)
                {
                    try
                    {
                        dataView.Rows[i].Cells["selected"].Value = false;
                    }
                    catch (Exception) { }
                }
            }
        }

        private void txtsearchcode_TextChanged(object sender, EventArgs e)
        {
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            //deploy
            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "select repack_id as ID,rp_item_code,rp_item_description,rp_mfg_date,rp_expiry_date,days_to_expired,total_repack,repack_by from [dbo].[rdf_repackin_entry] WHERE repack_id ='" + txtsearchcode.Text + "'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataView.DataSource = dt;
            sql_con.Close();
        }

        private void dataPreviousPrint_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtrawitemcode_TextChanged(object sender, EventArgs e)
        {
            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            //deploy

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            //string sqlquery = "select item_id,item_code,item_description,total_quantity_raw,qty_repack_available,qty_repack from [dbo].[rdf_raw_materials] WHERE item_code = '" + txtrawitemcode.Text + "' or item_description ='" + txtrawitemcode.Text + "%' AND Category='MICRO' ";
            //string sqlquery = "select item_id,item_code,item_description,total_quantity_raw,qty_repack_available,qty_repack from [dbo].[rdf_raw_materials] WHERE item_code = '" + txtrawitemcode.Text + "' AND Category='MICRO' ";

            string sqlquery = "select emp.item_id,emp.item_code,emp.item_description,emp.total_quantity_raw,emp.qty_repack_available as ass,emp.qty_repack as adad,(ISNULL(t6.ISSUE,0) * 1  +ISNULL(t5.RECEIVING,0)) - (ISNULL(t3.SCADA,0)  + ISNULL(t7.OUTING,0) + ISNULL(t4.MACREPACK,0))   as qty_repack_available,ISNULL(t4.MACREPACK,0) as qty_repack from [dbo].[rdf_raw_materials] emp LEFT JOIN ( select BC.r_item_code, sum(CAST(REPLACE(BC.r_quantity,',','') as float))  as ISSUE from rdf_microreceiving_entry BC where BC.transaction_type='Miscellaneous Receipt' group by BC.r_item_code) t6 on emp.item_code = t6.r_item_code LEFT JOIN ( select BC.r_item_code, sum(CAST(REPLACE(BC.r_quantity,',','') as float))  as RECEIVING from rdf_microreceiving_entry BC where is_active='1' and BC.transaction_type='PO' group by BC.r_item_code) t5 on emp.item_code = t5.r_item_code LEFT JOIN ( select BC.theo_item_code, sum( BC.actual_qty ) as SCADA from theo_logs_tbl BC where CAST(date_time as date) BETWEEN '2021-01-12' and GETDATE() group by BC.theo_item_code ) t3 on emp.item_code = t3.theo_item_code LEFT JOIN ( select BC.item_code, sum(CAST(REPLACE(BC.qty,',','') as float))  as OUTING from rdf_transaction_out_progress BC where BC.is_active='1' group by BC.item_code) t7 on emp.item_code = t7.item_code LEFT JOIN ( select BC.rp_item_code, sum(CAST(BC.total_repack as float))  as MACREPACK  from rdf_repackin_entry BC where CAST(BC.production_date as date) BETWEEN '2021-01-12' and GETDATE()+30  group by BC.rp_item_code) t4 on emp.item_code = t4.rp_item_code WHERE emp.item_code = '"+txtrawitemcode.Text+"' AND emp.Category='MICRO' ";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvMaster2.DataSource = dt;

            sql_con.Close();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure that you want to Cancel The Micro Repacking? ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                lblbintype.Visible = false;
                lblbin.Visible = false;

                lblfeedtype.Visible = false;
 
                dtprepackdate.Visible = false;
                lblprodname.Visible = false;
                label21.Visible = false;
                label19.Visible = false;
                btnProdList.Visible = false;
                txtbatch.Visible = false;
                lblproductionid.Visible = false;
                lblbagorbin.Visible = false;

                groupBox7.Visible = false;
                dataView.Visible = false;
                btnHideProd.Visible = false;
                dataGridEmpty();
                btngreaterthan.Visible = false;
                btnlessthan.Visible = false;
                btnProdShow.Visible = false;
                dgvMaster2.Visible = false;
                //bunifuThinButton218.Visible = true;
                dgvProdToday.Visible = false;

                label11.Visible = false;
                lblalreadyrepack.Visible = false;
                lbltotalreceived.Visible = false;
         
                label55.Visible = false;
                //dgvMaster.Enabled = true;
                //bunifuStart.Visible = true;
                bunifuStopRepacking.Visible = false;
                timer1.Stop();
                txtillusion.Visible = false;
                label1.Visible = false;
                groupBox4.Visible = false; ;
                groupBox2.Visible = false;
                lblraws.Visible = false;
                dgvAllFeedCode.Visible = false;
                btnSubmit.Visible = false;
                dgv_table_2nd_sup.Visible = false;


                bunifuThinButton215.Visible = false;
            

                lblCountss200.Visible = false;
                lblFooterQTy.Visible = false;

                lbltotalitem.Visible = false;
                lblcountFcode.Visible = false;
                lblmainCount.Visible = false;
                lblitemcount.Visible = false;

                bunifuStartImport.Visible = false;
                dgv1stView.Visible = false;
            }
            else
            {
                CancelNotif();
                return;
            }
        }

        private void dgvMaster2_CurrentCellChanged(object sender, EventArgs e)
        {
            showValueMicroMaster();
        }

        void showValueMicroMaster()
        {

            if (dgvMaster2.RowCount > 0)
            {
                if (dgvMaster2.CurrentRow != null)
                {
                    if (dgvMaster2.CurrentRow.Cells["item_id"].Value != null)
                    {
                        p_id = Convert.ToInt32(dgvMaster2.CurrentRow.Cells["item_id"].Value);

                        //txtsearch.Text = dgvMaster.CurrentRow.Cells["item_code"].Value.ToString();

                        txtrecommendedsearch.Text = dgvMaster2.CurrentRow.Cells["item_code"].Value.ToString();
                        txtqtyoverall.Text = dgvMaster2.CurrentRow.Cells["qty_repack_available"].Value.ToString();
                        //txtmainstocks.Text = dgvMaster.CurrentRow.Cells["total_quantity_raw"].Value.ToString(); alsi muna

                        txtfuck.Text = dgvMaster2.CurrentRow.Cells["qty_repack"].Value.ToString();


                        txtstatic.Text = dgvMaster2.CurrentRow.Cells["total_quantity_raw"].Value.ToString();

                        //cboCategor.Text = dgvMaster.CurrentRow.Cells["item_description"].Value.ToString();

                        txtmainbalance.Text = dgvMaster2.CurrentRow.Cells["qty_repack_available"].Value.ToString();

                        textBox1.Text = dgvMaster2.CurrentRow.Cells["qty_repack_available"].Value.ToString();
                        txtSOH.Text = dgvMaster2.CurrentRow.Cells["qty_repack_available"].Value.ToString();
                        txtGood.Text = dgvMaster2.CurrentRow.Cells["qty_repack_available"].Value.ToString(); // aDDITIONAL NA FAKE


                        //wala muna this


                    }

                }
            }

        }

        private void txtrpavailable_TextChanged(object sender, EventArgs e)
        {
            if (txtqtyoverall.Text.Trim() == string.Empty)
            {
                //try
                //{

                //    txtmainstocks.Text = (float.Parse(txtstatic.Text) - float.Parse(txtselectweight.Text)).ToString();//remove mainstocks txtselectweight

                //}
                //catch (Exception)
                //{


                //} remove muna march 23


            }
            else
            {
                //

                try
                {

                    txtmainstocks.Text = (float.Parse(txtqtyoverall.Text) - float.Parse(txtselectweight.Text)).ToString();//remove mainstocks txtselectweight

                }
                catch (Exception)
                {


                }



            }
        }


        private void txtfuck_TextChanged(object sender, EventArgs e)
        {
            try
            {


                txtqtyoverall.Text = (float.Parse(txtfuck.Text) + float.Parse(txtselectweight.Text)).ToString("#,0.000");
            }
            catch (Exception)
            {


            }
        }

        private void txtSearchx_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvStockout_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtselectweight.Select();
            txtselectweight.Focus();
            //timer1_Tick(sender, e);

            if (dgv_table_2nd_sup.Rows.Count > -1)
            {
                txtSubSupplier.Text = dgvStockout.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtSubItemCode.Text = dgvStockout.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtSubQty.Text = dgvStockout.Rows[e.RowIndex].Cells[7].Value.ToString();
                txtSubDateReceived.Text = dgvStockout.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtSubexpired.Text = dgvStockout.Rows[e.RowIndex].Cells[7].Value.ToString();
                lblsupreceivedid.Text = dgvStockout.Rows[e.RowIndex].Cells[1].Value.ToString();
            }

            ////bags computation
            double bag1;
            double bag2;
            double baganswer;

            bag1 = double.Parse(txtselectweight.Text);
            bag2 = double.Parse(txtActualQty.Text);
            //bag2 = double.Parse(txtBalance.Text);
            ////baganswer = bag1 * 20;
            baganswer = bag1 - bag2;
            //baganswer = Math.Round(baganswer);
            //baganswer = Math.Round(baganswer);
            txtSubQtyShared.Text = Convert.ToString(baganswer);




            txtshareddeb.Text = Convert.ToString(baganswer);
            ////bags computation
            double qty1;
            double qty2;
            double qtyanswer;

            qty1 = double.Parse(txtSubQty.Text);
            qty2 = double.Parse(txtSubQtyShared.Text);
            qtyanswer = qty1 - qty2;
            txtSubActual.Text = Convert.ToString(qtyanswer);

            //evaluation formula
            double eval1;
            double eval2;
            double finaleval;

            eval1 = double.Parse(txtshareddeb.Text);
            eval2 = double.Parse(txtactualqtydeb.Text);
            finaleval = eval1 + eval2;
            txtfinalrepackdeb.Text = Convert.ToString(finaleval);

        }


        public void cellclickrecommended()
        {



        }
        private void txtRawCode_TextChanged(object sender, EventArgs e)
        {
            doSearch();
        }

        private void bunifuRepackingProcess_Click(object sender, EventArgs e)
        {
            //RepackingProcess();

            if (lblcountFcode.Text == lblmainCount.Text)
            {


                //MessageBox.Show("Matched!");
                //MatchedRepackNotif();
                timer1_Tick(sender, e);//5/5/2020
                UpdatePrepartiontoFinish();


                //3 query function james foul
                ViewDataProduction();
                ViewCellChanger();

                QueryTryCatchProdTimes();
                //4 query is for insert the audit trail
                dSet = objStorProc.rdf_sp_new_preparation(0, cboDescription.Text, txtrepackby.Text, "4.1 Micro Repacking Entry", "Repack a Micro Materials", txtdatenowstamp.Text, lblprodid.Text, txtbatch.Text, "", "", "", "", "", "", "", "", "", "", "addTrailLogs");




                lblmainCount.Text = "0";
                txtBalance.Text = "";
                txtsearchitems_TextChanged(sender, e);


                //MessageBox.Show("LIMIT EXCEED");
                btnTryOut_Click(sender, e);
                //btnOutMaterial_Click(sender, e);
                //txtsearchitems_TextChanged(sender, e);
                //QueryUpdateforQArecipe();
                //txtitemcode_TextChanged(sender, e);
                //dito lalagay ang out sa rdf_recipe to 1 is used na



                rpt.Refresh();
                crV1.Refresh();

                double ActualQtyP;
                double SelectedWeight;

                ActualQtyP = double.Parse(txtActualQty.Text);
                SelectedWeight = double.Parse(txtselectweight.Text);
                if (ActualQtyP <= SelectedWeight)
                {

                    //MessageBox.Show("Panget");5/5/2020

                    if (txtshareddeb.Text.Trim() == string.Empty)
                    {
                        ////bags computation
                        double bag1;
                        double bag2;
                        double baganswer;
                        //double Allowances;

                        bag1 = double.Parse(txtselectweight.Text);
                        bag2 = double.Parse(txtActualQty.Text);

                        baganswer = bag1 - bag2;





                        LowQuantityNotify();

                        dgvStockout.Visible = true;

                        txtneededqty.Text = Convert.ToString(baganswer);
                        cellclickrecommended();
                        ////return;
                        ///

                        //Computation! 
                        ////bags computation
                        double Clickrecommend1;
                        double Clickrecommend2;
                        double baganswerxxx;

                        Clickrecommend1 = double.Parse(txtselectweight.Text);
                        Clickrecommend2 = double.Parse(txtActualQty.Text);
                        //bag2 = double.Parse(txtBalance.Text);
                        ////baganswer = bag1 * 20;
                        baganswerxxx = Clickrecommend1 - Clickrecommend2;
                        //baganswer = Math.Round(baganswer);
                        //baganswer = Math.Round(baganswer);
                        txtSubQtyShared.Text = Convert.ToString(baganswerxxx);




                        txtshareddeb.Text = Convert.ToString(baganswer);
                        ////////bags computation
                        ////double qty1;
                        ////double qty2;
                        ////double qtyanswer;

                        ////qty1 = double.Parse(txtSubQty.Text);
                        ////qty2 = double.Parse(txtSubQtyShared.Text);
                        ////qtyanswer = qty1 - qty2;
                        ////txtSubActual.Text = Convert.ToString(qtyanswer);

                        //evaluation formula
                        double eval1;
                        double eval2;
                        double finaleval;

                        eval1 = double.Parse(txtshareddeb.Text);
                        eval2 = double.Parse(txtactualqtydeb.Text);
                        finaleval = eval1 + eval2;
                        txtfinalrepackdeb.Text = Convert.ToString(finaleval + (".000"));

                        //End of Computation
                    }

                    btnyesorno_Click(sender, e);














                    //}
                    //    else if (dialogResult == DialogResult.No)
                    //    {
                    //        return;
                    //    }

                    //end final
                }
                else
                {
                    //MessageBox.Show("Gwapo");
                    //btnOutMaterial_Click(sender, e);4/18/2020
                    txtsearchitems_TextChanged(sender, e);
                }


            }
            else
            {
                if (dgvAllFeedCode.Rows.Count >= 1)
                {
                    int i = dgvAllFeedCode.CurrentRow.Index + 1;
                    if (i >= -0 && i < dgvAllFeedCode.Rows.Count)
                        //if (i >= -1 && i < dgvAllFeedCode.Rows.Count)
                        dgvAllFeedCode.CurrentCell = dgvAllFeedCode.Rows[i].Cells[0];
                    show3Fomula(); // here the answer


                }
            }


            if (lblcountFcode.Text == "1")
            {


                show3Fomula(); // here the answer



                if (dgvAllFeedCode.Rows.Count >= 1)
                {
                    int i = dgvAllFeedCode.CurrentRow.Index + 1;
                    if (i >= -0 && i < dgvAllFeedCode.Rows.Count)
                        //if (i >= -1 && i < dgvAllFeedCode.Rows.Count)
                        //if (i >= -1 && i < dgvAllFeedCode.Rows.Count)
                        dgvAllFeedCode.CurrentCell = dgvAllFeedCode.Rows[i].Cells[0];
                    //show3Fomula(); // here the answer
                    btnbalance_Click(sender, e);//4/12/2020

                }

            }

            else
            {



                if (dgvAllFeedCode.Rows.Count >= 1)
                {
                    int i = dgvAllFeedCode.CurrentRow.Index + 0;
                    if (i >= -0 && i < dgvAllFeedCode.Rows.Count)
                        //if (i >= -1 && i < dgvAllFeedCode.Rows.Count)
                        dgvAllFeedCode.CurrentCell = dgvAllFeedCode.Rows[i].Cells[0];
                    show3Fomula(); // here the answer
                                   //QueryUpdateforQArecipe();
                                   //txtitemcode_TextChanged(sender, e);
                    btnbalance_Click(sender, e);//4/12/2020

                }
            }

        }

        void ViewDataProduction()
        {


            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "SELECT * FROM [dbo].[rdf_production_advance] WHERE prod_id= '" + lblprodid.Text + "' AND is_selected='1' ";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvUpdateTimeLampse.DataSource = dt;

            sql_con.Close();





        }





        void QueryTryCatchProdTimes()
        {
txtdatenowstamp.Text = DateTime.Now.ToString();
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            //deploy
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "UPDATE [dbo].[rdf_production_advance] SET micro_repacking_time='"+txtSumofRepacking.Text+"' WHERE prod_id= '" + lblprodid.Text + "'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvActiveRepack.DataSource = dt;

            sql_con.Close();




        }







        void RepackingProcess()
        {

        }

        private void bunifuHeaderRaw_Click(object sender, EventArgs e)
        {
            if (dgv1stView.Rows.Count >= 1)
            {
                int i = dgv1stView.CurrentRow.Index + 1;
                if (i >= -1 && i < dgv1stView.Rows.Count)
                    dgv1stView.CurrentCell = dgv1stView.Rows[i].Cells[0];
            }
        }

        private void btnTryOut_Click(object sender, EventArgs e)
        {
            if (dgv1stView.Rows.Count >= 1)
            {
                int i = dgv1stView.CurrentRow.Index + 1;
                if (i >= -0 && i < dgv1stView.Rows.Count)
                    //if (i >= -1 && i < dgv1stView.Rows.Count)
                    dgv1stView.CurrentCell = dgv1stView.Rows[i].Cells[0];
            }
        }

        private void dgvAllFeedCode_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAllFeedCode.Rows.Count > -1)
            {
                txtselectweight.Text = dgvAllFeedCode.Rows[e.RowIndex].Cells[4].Value.ToString();

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //if (dgvAllFeedCode.Rows.Count >= 1)
            //{
            //    int i = dgvAllFeedCode.CurrentRow.Index + 1;
            //    if (i >= -0 && i < dgvAllFeedCode.Rows.Count)
            //        //if (i >= -1 && i < dgvAllFeedCode.Rows.Count)
            //        dgvAllFeedCode.CurrentCell = dgvAllFeedCode.Rows[i].Cells[0];
            //    show3Fomula(); // here the answer


            //}

            if (dgvAllFeedCode.Rows.Count >= 1)
            {
                int i = dgvAllFeedCode.CurrentRow.Index + 1;
                if (i >= -0 && i < dgvAllFeedCode.Rows.Count)
                    //if (i >= -1 && i < dgvAllFeedCode.Rows.Count)
                    dgvAllFeedCode.CurrentCell = dgvAllFeedCode.Rows[i].Cells[0];
                show3Fomula(); // here the answer


            }
        }

        private void txtweighingscale_TextChanged(object sender, EventArgs e)
        {




            try
            {
                //txtBalance.Text = (float.Parse(txtActualQty.Text) - float.Parse(txtselectweight.Text)).ToString("#0,000");
                txtBalance.Text = (float.Parse(txtActualQty.Text) - float.Parse(txtselectweight.Text)).ToString();
            }
            catch (Exception)
            {


            }

            //2

            try
            {


                txtrpavailable.Text = (float.Parse(txtfuck.Text) + float.Parse(txtselectweight.Text)).ToString("#,0.000");
            }
            catch (Exception)
            {


            }


            //3  0.252

            try
            {

                txtmainstocks.Text = (float.Parse(txtmainbalance.Text) - float.Parse(txtselectweight.Text)).ToString("#,0.000");//remove mainstocks txtselectweight

            }
            catch (Exception)
            {


            }

      




        }


        void forStockoutReceiving()
        {



            //game na me

            double ActualDeb;
            double SelectedWeightDeb;

            ActualDeb = double.Parse(txtActualQty.Text);
            SelectedWeightDeb = double.Parse(txtselectweight.Text);

            if (ActualDeb <= SelectedWeightDeb)
            {


                if (txtneededqty.Text.Trim() == string.Empty)
                {
                    //MessageBox.Show("select ok in notifier");removed 4/12/2020
                    //metroButton2_Click(new object(), new System.EventArgs());
                    ByPassStockoutofReceiving();
                    //return;
                }
            }

            else
            {


            }

        }











        private void txtprimarypo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtmainstocks_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtstatic_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtrepackavailable_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtqtyoverall_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt3rdsearch_TextChanged(object sender, EventArgs e)
        {
            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            //deploy

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            //gerald             string sqlquery = "Select emp.prod_id as ID, emp.p_feed_code as Emp_Number, emp.p_bags as Department,emp.p_nobatch as TotalPack,emp.proddate as Production_Date, emp.repacking_status as repack_status from rdf_production_advance emp WHERE emp.proddate ='" + txtdateplusone.Text + "' OR emp.proddate ='"+dtpreceivingdate.Text+"' OR emp.proddate ='"+ txtdateminus1.Text+"' AND emp.is_selected=1 AND emp.repacking_status='ready' AND NOT emp.canceltheapprove IS NOT NULL";
            //string sqlquery = "Select emp.prod_id as ID, emp.p_feed_code as Emp_Number, emp.p_bags as Department,emp.p_nobatch as TotalPack,emp.proddate as Production_Date, emp.repacking_status as repack_status from rdf_production_advance emp WHERE emp.prod_id='" + txtproductionid.Text + "' AND emp.is_selected=1 AND emp.is_active=1 AND emp.canceltheapprove IS NULL AND (emp.proddate ='" + dtpreceivingdate.Text+"' OR emp.proddate ='"+txtdateplusone.Text+"' OR emp.proddate = '"+txtdateminus1.Text+"' OR emp.proddate='"+txtdateofoutminus2.Text+"') ORDER BY emp.proddate ASC";


            string sqlquery = "Select DISTINCT emp.prod_id as ID, emp.p_feed_code as Emp_Number, emp.p_bags as Department,emp.p_nobatch as TotalPack,emp.proddate as Production_Date, emp.repacking_status as repack_status from rdf_production_advance emp LEFT JOIN rdf_recipe_to_production arp ON emp.prod_id=arp.production_id WHERE arp.production_id='" + lblprodid.Text + "' AND arp.repacking_status='1' AND arp.is_active='1' AND emp.repacking_status='ready' AND arp.rp_category='MICRO' AND emp.is_selected=1 AND emp.is_active=1 AND emp.canceltheapprove IS NULL AND (emp.proddate ='" + dtpreceivingdate.Text + "' OR emp.proddate ='" + txtdateplusone.Text + "' OR emp.proddate = '" + txtdateminus1.Text + "' OR emp.proddate='" + txtdateofoutminus2.Text + "' OR emp.proddate='" + txtplustwo.Text + "' OR emp.proddate='" + txtplusthree.Text + "' OR emp.proddate='"+lbldateplus5.Text+"') ORDER BY emp.prod_id ASC";


            //string sqlquery = "Select DISTINCT emp.prod_id as ID, emp.p_feed_code as Emp_Number, emp.p_bags as Department,emp.p_nobatch as TotalPack,emp.proddate as Production_Date, emp.repacking_status as repack_status from rdf_production_advance emp LEFT JOIN rdf_recipe_to_production arp ON emp.prod_id=arp.production_id WHERE arp.item_code='" + txtitemcode.Text + "' AND arp.repacking_status='1' AND arp.is_active='1' AND emp.repacking_status='ready' AND arp.rp_category='MICRO' AND emp.is_selected=1 AND emp.is_active=1 AND emp.canceltheapprove IS NULL AND (emp.proddate ='" + dtpreceivingdate.Text + "' OR emp.proddate ='" + txtdateplusone.Text + "' OR emp.proddate = '" + txtdateminus1.Text + "' OR emp.proddate='" + txtdateofoutminus2.Text + "') ORDER BY emp.prod_id ASC";


            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvProdToday.DataSource = dt;
            lblcountprod3.Text = dgvProdToday.RowCount.ToString();

            sql_con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double ActualQtyP;
            double SelectedWeight;

            ActualQtyP = double.Parse(txtActualQty.Text);
            SelectedWeight = double.Parse(txtselectweight.Text);
            if (ActualQtyP <= SelectedWeight)
            {

                //MessageBox.Show("Panget");
            }
            else
            {
                //MessageBox.Show("Gwapo");
            }


        }

        private void cboDescription_TextChanged(object sender, EventArgs e)
        {



        }

        private void dgvStockout_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgvStockout.RowCount > 0)
            {
                if (dgvStockout.CurrentRow != null)
                {
                    if (dgvStockout.CurrentRow.Cells["received_id"].Value != null)
                    {
                        p_id = Convert.ToInt32(dgvStockout.CurrentRow.Cells["received_id"].Value);





                        txtmainbalance.Text = dgvMaster2.CurrentRow.Cells["qty_repack_available"].Value.ToString();

                        //txtSubSupplier.Text = dgvStockout.Rows[e.RowIndex].Cells[3].Value.ToString();
                        //txtSubItemCode.Text = dgvStockout.Rows[e.RowIndex].Cells[2].Value.ToString();
                        //txtSubQty.Text = dgvStockout.Rows[e.RowIndex].Cells[7].Value.ToString();
                        //txtSubDateReceived.Text = dgvStockout.Rows[e.RowIndex].Cells[6].Value.ToString();
                        //txtSubexpired.Text = dgvStockout.Rows[e.RowIndex].Cells[7].Value.ToString();
                        lblsupreceivedid.Text = dgvStockout.CurrentRow.Cells["received_id"].Value.ToString();
                        txtSubSupplier.Text = dgvStockout.CurrentRow.Cells["r_supplier"].Value.ToString();
                        txtSubItemCode.Text = dgvStockout.CurrentRow.Cells["r_item_code"].Value.ToString();
                        //txtSubQty.Text = dgvStockout.CurrentRow.Cells["r_qty_delivered"].Value.ToString();
                        txtSubQty.Text = dgvStockout.CurrentRow.Cells["WHGood"].Value.ToString();
                        txtSubexpired.Text = dgvStockout.CurrentRow.Cells["days_to_expired"].Value.ToString();
                        txtSubDateReceived.Text = dgvStockout.CurrentRow.Cells["uniquedate"].Value.ToString();
                    }

                }
            }
        }

        private void txtshareddeb_TextChanged(object sender, EventArgs e)
        {

        }

        //singian
        void QueryUpdateforQArecipe()
        {
            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            //deploy

            txtdatenowstamp.Text = DateTime.Now.ToString();

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "UPDATE [dbo].[rdf_recipe_to_production] SET is_active = '0',time_stamp_per_process='"+txtdatenowstamp.Text+ "', repacking_by='" + txtrepackby.Text + "' WHERE production_id = '" + txtproductionid.Text + "' AND feed_code = '" + cboDescription.Text + "' AND item_code = '" + txtrawitemcode.Text + "' ";

            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridView1.DataSource = dt;


            sql_con.Close();

        }


        void SecondReceivingBindingSource()
        {
            String connetionString2 = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            //deploy

            SqlConnection sql_con2 = new SqlConnection(connetionString2);


            string sqlquery2 = "select TOP 2 r_item_id,received_id,r_item_code,r_supplier,totalnstock,selected_uom,uniquedate,r_qty_delivered,days_to_expired,actual_count_good AS WHGood from [dbo].[rdf_microreceiving_entry] WHERE r_item_code= '" + txtrecommendedsearch.Text + "' AND r_item_category='MICRO' AND receiving_status='1' AND NOT received_id='" + txtID.Text + "' ORDER BY days_to_expired ASC";
            sql_con2.Open();
            SqlCommand sql_cmd2 = new SqlCommand(sqlquery2, sql_con2);
            SqlDataAdapter sdr2 = new SqlDataAdapter(sql_cmd2);
            DataTable dt2 = new DataTable();
            sdr2.Fill(dt2);
            dgvReceiving.DataSource = dt2;
            sql_con2.Close();
            txtSecondReceivingCount.Text = dgvReceiving.RowCount.ToString();

        }

        public void NoreceivingBindingSource()
        {
            String connetionString2 = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            //deploy

            SqlConnection sql_con2 = new SqlConnection(connetionString2);


            string sqlquery2 = "select TOP 2 r_item_id,received_id,r_item_code,r_supplier,totalnstock,selected_uom,uniquedate,r_qty_delivered,days_to_expired,actual_count_good AS WHGood from [dbo].[rdf_microreceiving_entry] WHERE r_item_code= '" + txtrecommendedsearch.Text + "' AND r_item_category='MICRO' AND NOT received_id='" + txtID.Text + "' ORDER BY days_to_expired ASC";
            sql_con2.Open();
            SqlCommand sql_cmd2 = new SqlCommand(sqlquery2, sql_con2);
            SqlDataAdapter sdr2 = new SqlDataAdapter(sql_cmd2);
            DataTable dt2 = new DataTable();
            sdr2.Fill(dt2);
            dgvReceiving.DataSource = dt2;
            sql_con2.Close();
            txtSecondReceivingCount.Text = dgvReceiving.RowCount.ToString();

        }


        private void metroButton2_Click(object sender, EventArgs e)
        {

            //Singian
            //if (MetroFramework.MetroMessageBox.Show(this, "Inventory is Already Low @ '" + txtItemDescription.Text + "', Allow Fedora System to Access Another Receiving Entry? ", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            //{

                txtBalance.BackColor = Color.Yellow;

                groupBox1.Visible = true;
                groupBox5.Visible = true;



                SecondReceivingBindingSource();





                if (txtSecondReceivingCount.Text == "0")

                {

                NoreceivingBindingSource();
                if (txtSecondReceivingCount.Text == "0")
                {



                }
                else
                {

                    MessageBox.Show("No Data for Receiving");
                    return;
                }


                }





                txtSecondReceivedId.Text = dgvReceiving.CurrentRow.Cells["received_id"].Value.ToString();




                String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
                //deploy
                txtdatenowstamp.Text = DateTime.Now.ToString();

                SqlConnection sql_con = new SqlConnection(connetionString);



                string sqlquery = "UPDATE [dbo].[rdf_microreceiving_entry] SET receiving_status = '0',production_id_last_used='"+lblprodid.Text+"',target_weight='"+txtselectweight.Text+ "',last_receiving_id='"+txtSecondReceivedId.Text+ "',time_stamp_out='"+txtdatenowstamp.Text+"'  WHERE received_id = '" + txtID.Text + "'";

                sql_con.Open();
                SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
                SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
                DataTable dt = new DataTable();
                sdr.Fill(dt);
                dgvStockout.DataSource = dt;













                sql_con.Close();


                ////


                ////bags computation
                double bag1;
                double bag2;
                double baganswer;

                bag1 = double.Parse(txtselectweight.Text);
                bag2 = double.Parse(txtActualQty.Text);
                //bag2 = double.Parse(txtBalance.Text);
                ////baganswer = bag1 * 20;
                baganswer = bag1 - bag2;
                //baganswer = Math.Round(baganswer);
                //baganswer = Math.Round(baganswer);
                txtSubQtyShared.Text = Convert.ToString(baganswer);
                //
                txtrecommendedsearch_TextChanged(sender, e);

                //end


            //}
            //else
            //{

            //    return;
            //}
        }

        private void btnyesorno_Click(object sender, EventArgs e)
        {
            metroButton2_Click(sender, e);
            //MessageBox.Show("Pak");
        }

        private void txtqtyndeb_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSubQty_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBalance_TextChanged(object sender, EventArgs e)
        {

        }



        private void metroToggle1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnOutMaterial_Click(object sender, EventArgs e)
        {
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "UPDATE [dbo].[rdf_recipe_to_production] SET repacking_status='1' WHERE feed_code='" + cboDescription.Text + "' AND item_code='" + txtrawitemcode.Text + "' AND production_id='" + txtproductionid.Text + "'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridView1.DataSource = dt;

            //txtsearchitems_TextChanged(sender, e);











            sql_con.Close();
        }


        void InsertDatatoPreparation()
        {

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            SqlConnection sql_con = new SqlConnection(connetionString);

            string sqlquery = "INSERT INTO [Fedoramain].[dbo].[rdf_preparations] (pre_prod_id,pre_feed_code,pre_feed_type,pre_item_code,pre_description,pre_batch,rep_item_code,rep_qty,rep_id,rep_is_active,rep_date_added,rep_added_by,preparation_date_finish) VALUES ('" + lblprodid.Text + "','" + cboDescription.Text + "','" + lblfeedtype.Text + "','" + lblitemcode.Text + "','" + txtItemDescription.Text + "','" + txtbatch.Text + "','" + lblitemcode.Text + "','" + txtselectweight.Text + "','" + txtfinalstring.Text + "','1','" + dtpreceivingdate.Text + "','" + txtrepackby.Text + "','" + dtpreceivingdate.Text + "')";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvPreparation.DataSource = dt;










            sql_con.Close();
        }

        void UpdatePrepartiontoFinish()
        {
            txtdatenowstamp.Text = DateTime.Now.ToString();
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            SqlConnection sql_con = new SqlConnection(connetionString);

            string sqlquery = "UPDATE [Fedoramain].[dbo].[rdf_production_advance] SET preparation_date_finish='" + dtpreceivingdate.Text + "', repacking_status='Finish',end_micro_repacking='"+txtdatenowstamp.Text+ "',micro_bit='1' WHERE prod_id='" + lblprodid.Text + "'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvPreparation.DataSource = dt;










            sql_con.Close();
        }

        private void txtweighingscale_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        void NoBalanceNotify()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "NOT ENOUGH BALANCE TO REPACK";
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

        void NoDataNotify()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "NOT ENOUGH MATERIALS TO REPACK";
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
            txtweighingscale.BackColor = Color.White;
            txtitemcode_TextChanged(new object(), new System.EventArgs());
        }

        private void button4_Click_1(object sender, EventArgs e)
        {


            if (dgv_table_2nd_sup.Rows.Count > 0)
            {
                //MessageBox.Show("1");
                txtweighingscale.Enabled = true;
                txtweighingscale.Focus();
                txtweighingscale.BackColor = Color.Yellow;
            }
            else
            {
                //    MessageBox.Show("1");
                WarningNoInventory();

                //txtItemDescription.Text = dgv1stView.CurrentRow.Cells["DESCRIPTION"].Value.ToString(); laarnie
                txtMainSupplier.Text = "";
                txttotalofStock.Text = "";
                txtweighingscale.Enabled = false;
                txtweighingscale.BackColor = Color.Yellow;
                return;

            }
        }

        private void lblCountss200_Click(object sender, EventArgs e)
        {

        }

        private void lblCountss200_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtItemDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtwhgood_TextChanged(object sender, EventArgs e)
        {

        }

    

        private void metroButton3_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Start Advanced Repacking ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                label1.Visible = true;
                btnProdShow.Visible = true;
                //Updaterdfrecipe();
                timer1.Start();
                btngreaterthan.Visible = true;
                btnlessthan.Visible = true;

                //panel1.Visible = true;

                StartRepackNotif();
                dgvAllFeedCode_CurrentCellChanged(sender, e);

                groupBox4.Visible = true;
                groupBox2.Visible = true;


                bunifuStart.Visible = false;
                bunifuStopRepacking.Visible = true;

                txtillusion.Visible = true;
                //btnSubmit.Visible = true;
                lblraws.Visible = true;
                label55.Visible = true;

                dgv_table_2nd_sup.Visible = true;
  
                txtweighingscale.Focus();
                txtweighingscale_Click(sender, e);
                //dgvMaster.Enabled = false;
                //Sum();

                lblCountss200.Visible = true;
                lblFooterQTy.Visible = true;

                show3Fomula();




                bunifuThinButton215.Visible = true;
      
                dgvAllFeedCode.Visible = true;
                lbltotalitem.Visible = true;
                //lblcountFcode.Visible = true; saturday work at a7/25/2020
                lblmainCount.Visible = true;
                lblitemcount.Visible = true;
                bunifuStartImport.Visible = true;
                dgv1stView.Visible = true;
                dgvAllFeedCode.Enabled = false;


                dgvMaster2.Visible = true;
            }
            else
            {
                return;
            }





        }



        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnbalance_Click(object sender, EventArgs e)
        {
            double ActualDeb;
            double SelectedWeightDeb;

            ActualDeb = double.Parse(txtActualQty.Text);
            SelectedWeightDeb = double.Parse(txtselectweight.Text);

            if (ActualDeb <= SelectedWeightDeb)
            {


                if (txtneededqty.Text.Trim() == string.Empty)
                {
                    //MessageBox.Show("select ok in notifier");removed 4/12/2020
                   
                   //Dampa
                    //metroButton2_Click(sender, e);
                    //MessageBox.Show("Puk");
                    //return;
                }
            }

            else
            {


            }

        }

        private void txtSubActual_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvProdToday_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Check the value of the e.ColumnIndex property if you want to apply this formatting only so some rcolumns.
            if (e.Value != null)
            {
                e.Value = e.Value.ToString().ToUpper();
                e.FormattingApplied = true;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        private void dgvProdToday_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dg = (DataGridView)sender;
            // Current row record
            string rowNumber = (e.RowIndex + 1).ToString();

            // Format row based on number of records displayed by using leading zeros
            while (rowNumber.Length < dg.RowCount.ToString().Length) rowNumber = "0" + rowNumber;

            // Position text
            SizeF size = e.Graphics.MeasureString(rowNumber, this.Font);
            if (dg.RowHeadersWidth < (int)(size.Width + 20)) dg.RowHeadersWidth = (int)(size.Width + 20);

            // Use default system text brush
            Brush b = SystemBrushes.ControlText;

            // Draw row number
            e.Graphics.DrawString(rowNumber, dg.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            txtweighingscale.Enabled = true;
            txtweighingscale.BackColor = Color.Yellow;
            txtweighingscale.Text = "";
            btnSubmit.Visible = false;
            txtweighingscale.Select();
            txtweighingscale.Focus();
            timer1.Start();

        }


        private void xpired_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void lblprodid_Click(object sender, EventArgs e)
        {
            txtitemcode_TextChanged(sender, e);
        }

        private void dgvAllFeedCode_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void dgvRawMats_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {

        }

        private void dgvRawMats_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void dgvRawMats_CurrentCellChanged(object sender, EventArgs e)
        {

        }

        private void dgv1stView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnReprint_Click(object sender, EventArgs e)
        {
            metroReprint_Click(sender, e);
            //button2_Click_1(sender, e);
            //btnReprint.Visible = false;
            //txtweighingscale.Focus();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroReprint_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Reprint the Previous Barcode ? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                panelCode.Visible = true;
                timer1.Stop();

                txtControlNumber.Focus();
                



            }

            else
            {

                panelCode.Visible = false;
                timer1.Start();
                timer1_Tick(sender, e);
                txtweighingscale.Focus();
                return;
            }
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            if (txtControlNumber.Text.Trim() == string.Empty)
            {
                FillEmptyFields();
                txtControlNumber.Focus();
            }

            if (txtControlNumber.Text == "787898")
            {
                panelCode.Visible = false;
                storedProcCntrNumber();
                txtControlNumber.Text = "";
                //button2_Click_1(sender, e);
                ReprintingMethod();
                btnReprint.Visible = false;

                timer1.Start();
                timer1_Tick(sender, e);
                txtweighingscale.Focus();






            }
            else if (txtControlNumber.Text == "787899")
            {
                panelCode.Visible = false;
                storedProcCntrNumber();
                txtControlNumber.Text = "";
                //button2_Click_1(sender, e);
                ReprintingMethod();
                btnReprint.Visible = false;
                timer1.Start();
                timer1_Tick(sender, e);
                txtweighingscale.Focus();


            }
            else if (txtControlNumber.Text == "787420")
            {
                panelCode.Visible = false;
                storedProcCntrNumber();
                txtControlNumber.Text = "";
                //button2_Click_1(sender, e);
                ReprintingMethod();
                btnReprint.Visible = false;
                timer1.Start();
                timer1_Tick(sender, e);
                txtweighingscale.Focus();
            }

            else
            {

                InvalidControlNumber();
                txtControlNumber.Text = "";
                txtControlNumber.Focus();
                return;
            }


            }


        void storedProcCntrNumber()
        {

            txtdatenowstamp.Text = DateTime.Now.ToString("M/d/yyyy");
            dSet.Clear();

            dSet = objStorProc.rdf_sp_new_preparation(0, "Reprint MICRO Repacking", txtControlNumber.Text, "MICRO REPACKING", txtrepackby.Text, txtdatenowstamp.Text, "", "", "", "", "", "", "", "", "", "", "", "", "addcontrolnumberlogs");

        }

        void FillEmptyFields()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "FILL UP THE EMPTY FIELDS !";
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


        void InvalidControlNumber()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.ContentText = "INVALID CONTROL NUMBER";
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Red;
            popup.Popup();

            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            //popup.AnimationDuration = 1000;
            //popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);

            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }

        private void txtControlNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnValidate_Click(sender, e);
            }
        }

        private void dgvPreparation_CurrentCellChanged(object sender, EventArgs e)
        {

        }

        private void dgvReceiving_CurrentCellChanged(object sender, EventArgs e)
        {

            //txtSecondReceivedId.Text = dgvReceiving.CurrentRow.Cells["received_id"].Value.ToString();

        }

        private void dgv1stView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void dgv1stView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {


            if (e.Value != null)
            {
                e.Value = e.Value.ToString().ToUpper();
                e.FormattingApplied = true;
            }
        }

        private void dataView_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataView.RowCount > 0)
            {
                if (dataView.CurrentRow != null)
                {
                    if (dataView.CurrentRow.Cells["Position"].Value != null)
                    {

                        txtMyLastID.Text = dataView.CurrentRow.Cells["string_id"].Value.ToString();

                    }

                }
            }




        }

        private void dgvUpdateTimeLampse_CurrentCellChanged(object sender, EventArgs e)
        {

            ViewCellChanger();
   

            }

        void ViewCellChanger()
        {


            if (dgvUpdateTimeLampse.RowCount > 0)
            {
                if (dgvUpdateTimeLampse.CurrentRow != null)
                {
                    if (dgvUpdateTimeLampse.CurrentRow.Cells["p_feed_code"].Value != null)
                    {
                        //p_id = Convert.ToInt32(dgvApproved.CurrentRow.Cells["prod_id"].Value);

                        txtstartmicrorepacking.Text = dgvUpdateTimeLampse.CurrentRow.Cells["start_micro_repacking"].Value.ToString();

                    }

                }
            }

            txtdatenowstamp.Text = DateTime.Now.ToString();


            DateTime time1 = DateTime.Parse(txtstartmicrorepacking.Text);
            DateTime time2 = DateTime.Parse(txtdatenowstamp.Text);

            TimeSpan difference = time2 - time1;



            txtSumofRepacking.Text = Convert.ToString(difference);







            



        }

        private void lblbagorbin_Click(object sender, EventArgs e)
        {

        }

        private void dgvRawMats_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {

        }

        private void dgvProdToday_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtbatch_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {


            txtitemcode_TextChanged(sender, e);
            lblmainCount.Text = "0";

            if (lblraws.Text == "0")
            {
                RepackIDtoRepack();
                return;
            }

            if (dgv1stView.Rows.Count >= 1)
            {
                int i = dgv1stView.CurrentRow.Index + 1;
                if (i >= -1 && i < dgv1stView.Rows.Count)
                    dgv1stView.CurrentCell = dgv1stView.Rows[i].Cells[0];
                else
                {
                    LastLine();
                    txtselectweight.Text = dgvAllFeedCode.CurrentRow.Cells["Quantity"].Value.ToString();
                    timer1_Tick(sender, e);
                    txtweighingscale.Focus();
                    return;
                }
            }


            //checkReceivingBalance();
            txt3rdsearch_TextChanged(sender, e);

            btnbalance_Click(sender, e);
            load_search();
            doSearch();
            lblprodid.Text = dgv1stView.CurrentRow.Cells["prod_id"].Value.ToString();
            txtitemcode_TextChanged(sender, e);
            show3Fomula();
            txtweighingscale.Focus();


        }

        private void button7_Click(object sender, EventArgs e)
        {
            lblmainCount.Text = "0";
            //if (dgv1stView.Rows.Count >= 1)
            //{
            //int i = dgv1stView.CurrentRow.Index - 1;
            //if (i >= -1 && i < dgv1stView.Rows.Count)
            //dgv1stView.CurrentCell = dgv1stView.Rows[i].Cells[0];

            //}
            if (lblraws.Text == "0")
            {
                RepackIDtoRepack();
                return;
            }
            int prev = this.dgv1stView.CurrentRow.Index - 1;
            if (prev >= 0)
            {

                this.dgv1stView.CurrentCell = this.dgv1stView.Rows[prev].Cells[this.dgv1stView.CurrentCell.ColumnIndex];
            }
            else
            {
                FirstLine();
                txtselectweight.Text = dgvAllFeedCode.CurrentRow.Cells["Quantity"].Value.ToString();
            }
            txt3rdsearch_TextChanged(sender, e);
            //checkReceivingBalance();
            btnbalance_Click(sender, e);
            load_search();
            doSearch();
            lblprodid.Text = dgv1stView.CurrentRow.Cells["prod_id"].Value.ToString();
            txtitemcode_TextChanged(sender, e);
            show3Fomula();
            txtweighingscale.Focus();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {

            //txtoptions.Text = "Date";
            Data();
            //if (MetroFramework.MetroMessageBox.Show(this, "Start Repacking of Materials Order By ID or Else Order by Production Date ? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            //{

            //    txtoptions.Text = "ID";
            //    Data();
 
            //}
            //else
            //{
            //    txtoptions.Text = "Date";
            //    Data();
            //}

        }
        void Data()
        {
            lblbintype.Visible = true;
            lblbin.Visible = true;


            lblfeedtype.Visible = true;
            btnProdList.Visible = true;
            dtprepackdate.Visible = true;
            label21.Visible = true;
            label19.Visible = true;

            txtbatch.Visible = true;
            lblprodname.Visible = true;
            lblalreadyrepack.Visible = true;
            //metroButton3_Click(sender,e);
            lbltotalreceived.Visible = true;
            label1.Visible = true;
            btnProdShow.Visible = true;
            //Updaterdfrecipe();
            timer1.Start();
            btngreaterthan.Visible = true;
            btnlessthan.Visible = true;
            lblbagorbin.Visible = true;
            lblproductionid.Visible = true;
            //panel1.Visible = true;

            StartRepackNotif();
            dgvAllFeedCode_CurrentCellChanged(new object(), new System.EventArgs());

            groupBox4.Visible = true;
            groupBox2.Visible = true;


            bunifuStart.Visible = false;
            bunifuStopRepacking.Visible = true;

            txtillusion.Visible = true;
            //btnSubmit.Visible = true;
            lblraws.Visible = true;
            label55.Visible = true;

            //dgv_table_2nd_sup.Visible = true;
            //bunifuThinButton219.Visible = true;
            txtweighingscale.Focus();
            txtweighingscale_Click(new object(), new System.EventArgs());
            //dgvMaster.Enabled = false;
            //Sum();

            lblCountss200.Visible = true;
            lblFooterQTy.Visible = true;

            show3Fomula();




            bunifuThinButton215.Visible = true;

            dgvAllFeedCode.Visible = true;
            lbltotalitem.Visible = true;
            lblcountFcode.Visible = true;
            lblmainCount.Visible = true;
            lblitemcount.Visible = true;
            bunifuStartImport.Visible = true;
            dgv1stView.Visible = true;
            //dgvAllFeedCode.Enabled = false;



            dgvMaster2.Visible = true;
        }
        private void button6_Click_2(object sender, EventArgs e)
        {

            metroButton1_Click(sender, e);
        }

        private void button6_Click_3(object sender, EventArgs e)
        {
            if (btnSubmit.Visible == true)
            {
                return;
            }
            else
            {

            }

            dgvProdToday.Visible = true;
            btnHideProd.Visible = true;

            label11.Visible = true;
            btnProdShow.Visible = false;
            lblcountprod3.Visible = true;


            dgvAllFeedCode.Visible = false;

            dgvRawMats.Visible = true;



            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            SqlConnection sql_con = new SqlConnection(connetionString);

            string sqlquery = "select rpa.feed_code AS Feed_Code,rpa.rp_feed_type AS Feed_Type,ax.p_nobatch AS Batch,rpa.rp_group AS Groups,rpa.quantity AS Quantity,rpa.production_id AS PRODID,rpa.rp_description,rpa.item_code from [dbo].[rdf_recipe_to_production] rpa LEFT JOIN rdf_production_advance ax ON rpa.production_id=ax.prod_id WHERE rpa.rp_category='MICRO' AND rpa.production_id ='" + lblprodid.Text + "' AND rpa.is_active=0 AND ax.is_selected='1' AND ax.is_active=1 AND NOT ax.canceltheapprove IS NOT NULL  AND (ax.proddate='" + txtdateplusone.Text + "' OR ax.proddate='" + dtpreceivingdate.Text + "' OR ax.proddate='" + txtdateminus1.Text + "' OR ax.proddate='" + txtdateofoutminus2.Text + "' OR ax.proddate='" + txtplustwo.Text + "' OR ax.proddate='" + txtplusthree.Text + "' OR ax.proddate='" + lbldateplus5.Text + "') ORDER BY ax.prod_id ASC";




            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvRawMats.DataSource = dt;


            sql_con.Close();


            for (int n = 0; n < (dgvRawMats.Rows.Count); n++)
            {
                double s = Convert.ToDouble(dgvRawMats.Rows[n].Cells[4].Value);


                //double s1 = Convert.ToDouble(dgvAllFeedCode.Rows[n].Cells[7].Value);

                double s1 = Convert.ToDouble(dgvRawMats.Rows[n].Cells[2].Value);

                //int s1 = Convert.ToInt32(dgv1stView.Rows[n].Cells[1].Value);
                double s13 = s * 2;
                double s15 = s13 * s1;

                //original computation 5/4/2020  double s15 = s13 * s1;


                dgvRawMats.Rows[n].Cells[4].Value = s15.ToString("#,0.000");
                //dgvAllFeedCode.Rows[n].Cells[4].Value = s13.ToString("#,0.000");
                //dgvAllFeedCode.Rows[n].Cells[7].Value = s15.ToString("#,0.000");
            }





        }

        private void button6_Click_4(object sender, EventArgs e)
        {
            dgvProdToday.Visible = false;
            btnProdShow.Visible = true;

            label11.Visible = false;
            btnHideProd.Visible = false;
            lblcountprod3.Visible = false;

            dgvAllFeedCode.Visible = true;

            dgvRawMats.Visible = false;
        }

        private void button6_Click_5(object sender, EventArgs e)
        {
            frmRepackingProductionCheckList asd = new frmRepackingProductionCheckList();
            asd.ShowDialog();
        }

        private void bunifuThinButton215_Enter(object sender, EventArgs e)
        {

        }

        private void label55_Click(object sender, EventArgs e)
        {

        }

    }
}
