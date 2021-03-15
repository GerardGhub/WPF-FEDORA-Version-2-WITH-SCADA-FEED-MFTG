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
using Tulpep.NotificationWindow;

namespace WFFDR
{
    public partial class frmwhmacropreparation : Form
    {
        SqlCommand cmd;
        //SqlDataAdapter da;
        //DataTable dt;
        DataSet ds = new DataSet();


        myclasses xClass = new myclasses();
        IStoredProcedures objStorProc = null;
        Boolean ready = false;
        DataSet dSet = new DataSet();

        DataSet dSets = new DataSet();
        DataSet dSet_temp = new DataSet();
        string mode = "";
        int p_id = 0;
        //int temp_hid = 0;
        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();

        //declare as global

        int nRow;
        public frmwhmacropreparation()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        
        private void frmwhmacropreparation_Load(object sender, EventArgs e)
        {
            txt1.Enabled = true;
            txt1.Select();
            txt1.Focus();
            lbltotalread.Text = "0";

            txtaddedby.Text = userinfo.emp_name.ToUpper();


            txtrecipe.Visible = false;
            txtcode1.Visible = false;
      

    


            mode = "active";
            HideMultiple();




            BtnSave.Visible = false;
            txtqtyactive.Text = "";
            //string s = (Convert.ToDouble(txt2.Text) / 100).ToString("0.00");

            //this.WindowState = FormWindowState.Maximized;

            load_Schedules();

            //nRow = dgv1stView.CurrentCell.RowIndex;4/18/2020

            myglobal.global_module = "Active";

            // Calling the Stored PROC 
            objStorProc = xClass.g_objStoredProc.GetCollections();
            //this.WindowState = FormWindowState.Maximized;
            Callothers();
      

            calldisable();



            txtmainfeedcode_TextChanged(sender, e);

            if (label10.Text == "0")
            {
                NoDataFound2();
                splitContainer1.Visible = false;
                return;
            }

                if (txtitemcode1.Text.Trim() == string.Empty)
    
            {
                lblbacthnolabel.Visible = false;
                lblmacroprepared.Visible = false;
                lbloutoflabel.Visible = false;
                lblbatch.Visible = false;
                lblbatchlabel.Visible = false;
                //splitContainer1.Visible = false;
                NoDataFound2();
                return;

            }
            else
            {
                nRow = dgv1stView.CurrentCell.RowIndex;
                txtitemcodeactive.Text = dgv1stView.CurrentRow.Cells["item_codedb"].Value.ToString();
                txtdescriptionactive.Text = dgv1stView.CurrentRow.Cells["rp_descriptiondb"].Value.ToString();
                txtbatchactive.Text = dgv1stView.CurrentRow.Cells["p_nobatchdb"].Value.ToString();
                txtqtyactive.Text = dgv1stView.CurrentRow.Cells["quantity"].Value.ToString();
                //x3 batch
                lbltotalbatch.Text = (float.Parse(label2.Text) * float.Parse(txtnobatch.Text)).ToString();
                txtsubtractrepack.Text = (float.Parse(txtactiverepack.Text) - 1).ToString();
            }
      
            //txtmainfeedcode_TextChanged(sender, e);
            StressHideTextBox();
            txtrepackavailable.Text = dgvMaster2.CurrentRow.Cells["qty_repack"].Value.ToString();
            load_search();

            txtmainfeedcode_TextChanged(sender,e);
            string s = (Convert.ToDouble(txtrepackavailable.Text) / 100).ToString("0.00");
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
        void HideMultiple()
        {
            row2();
            row3();
            row4();
            row5();
            row6();
            row7();
            row8();
            row9();
            row10();
            row11();
            row12();
            row13();
            row14();
            row15();
            row16();
            row17();
            row18();
            row19();
            row20();
            row21();
            row22();
            row23();
            row24();
            row25();

        }

        public void search()
        {
            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=hr_bak;Integrated Security=SSPI";
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "select repack_id,rp_item_id,rp_item_category,rp_item_code,rp_supplier,rp_item_description,total_repack,rp_expiry_date from [dbo].[rdf_repackin_entry] WHERE repack_id = " + txt1.Text + "";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr2 = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr2.Fill(dt);
            dgvrepackdb.DataSource = dt;
            dgvrepackdb.Visible = true;


            sql_con.Close();
        }



        void load_search()
        {

            dset_emp.Clear();



            dset_emp = objStorProc.sp_getMajorTables("MacroCountPrepared");


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

                        dv.RowFilter = "feed_code ='" + txtmainfeedcode.Text + "' AND production_id ='" + txtmasterid.Text + "' AND item_code ='" + txtitemcodeoriginal.Text + "' AND rp_description = '"+ txtdescriptionfinal.Text + "'";

                    }
                    else if (myglobal.global_module == "VISITORS")
                    {
                        //dv.RowFilter = "visitors_lastname like '%" + txtsearch.Text + "%' or visitors_firstname like '%" + txtsearch.Text + "%'";
                    }
                    dgvshowcount.DataSource = dv;
                 lblmacroprepared.Text = dgvshowcount.RowCount.ToString();
                    //txtsubtractrepack.Text = (float.Parse(txtactiverepack.Text) - 1).ToString();

                    //lblmacroprepared.Text = (float.Parse(lblmacroprepared.Text) + 1).ToString();
                }
            }
            catch (SyntaxErrorException)
            {
                MessageBox.Show("Invalid character found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmainfeedcode.Focus();
                return;
            }
            catch (EvaluateException)
            {
                MessageBox.Show("Invalid character found 2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmainfeedcode.Focus();
                return;
            }

           
        }












        public void searchscan()
        {
            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=hr_bak;Integrated Security=SSPI";
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "select repack_id,rp_item_id,rp_item_category,rp_item_code,rp_feed_code,rp_supplier,rp_item_description,total_repack,rp_expiry_date from [dbo].[rdf_repackin_entry] WHERE string_id = '" + txtscanid.Text + "'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr2 = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr2.Fill(dt);
            dgvrepackdb.DataSource = dt;
            dgvrepackdb.Visible = true;

  
            sql_con.Close();
        }





        public void search2()
        {
            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=hr_bak;Integrated Security=SSPI";
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "select repack_id,rp_item_id,rp_item_category,rp_item_code,rp_supplier,rp_item_description,total_repack,rp_expiry_date from [dbo].[rdf_repackin_entry] WHERE repack_id = " + txt2.Text + "";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr2 = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr2.Fill(dt);
            dgvrepackdb.DataSource = dt;
            dgvrepackdb.Visible = true;


            sql_con.Close();
        }


        public void search3()
        {
            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=hr_bak;Integrated Security=SSPI";
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "select repack_id,rp_item_id,rp_item_category,rp_item_code,rp_supplier,rp_item_description,total_repack,rp_expiry_date from [dbo].[rdf_repackin_entry] WHERE repack_id = " + txt3.Text + "";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr2 = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr2.Fill(dt);
            dgvrepackdb.DataSource = dt;
            dgvrepackdb.Visible = true;


            sql_con.Close();
        }

        public void search4()
        {
            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=hr_bak;Integrated Security=SSPI";
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "select repack_id,rp_item_id,rp_item_category,rp_item_code,rp_supplier,rp_item_description,total_repack,rp_expiry_date from [dbo].[rdf_repackin_entry] WHERE repack_id = " + txt4.Text + "";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr2 = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr2.Fill(dt);
            dgvrepackdb.DataSource = dt;
            dgvrepackdb.Visible = true;

            sql_con.Close();
        }


        public void search5()
        {
            String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=hr_bak;Integrated Security=SSPI";


            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "select repack_id,rp_item_id,rp_item_category,rp_item_code,rp_supplier,rp_item_description,total_repack,rp_expiry_date from [dbo].[rdf_repackin_entry] WHERE string_id = " + txt5.Text + "";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr2 = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr2.Fill(dt);
            dgvrepackdb.DataSource = dt;
            dgvrepackdb.Visible = true;

            sql_con.Close();
        }


        public void search6()
        {
            String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=hr_bak;Integrated Security=SSPI";


            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "select repack_id,rp_item_id,rp_item_category,rp_item_code,rp_supplier,rp_item_description,total_repack,rp_expiry_date from [dbo].[rdf_repackin_entry] WHERE repack_id = " + txt6.Text + "";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr2 = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr2.Fill(dt);
            dgvrepackdb.DataSource = dt;
            dgvrepackdb.Visible = true;

            sql_con.Close();
        }


        public void search7()
        {
            String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=hr_bak;Integrated Security=SSPI";


            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "select repack_id,rp_item_id,rp_item_category,rp_item_code,rp_supplier,rp_item_description,total_repack,rp_expiry_date from [dbo].[rdf_repackin_entry] WHERE repack_id = " + txt7.Text + "";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr2 = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr2.Fill(dt);
            dgvrepackdb.DataSource = dt;
            dgvrepackdb.Visible = true;

            sql_con.Close();
        }

        public void search8()
        {
            String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=hr_bak;Integrated Security=SSPI";


            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "select repack_id,rp_item_id,rp_item_category,rp_item_code,rp_supplier,rp_item_description,total_repack,rp_expiry_date from [dbo].[rdf_repackin_entry] WHERE repack_id = " + txt8.Text + "";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr2 = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr2.Fill(dt);
            dgvrepackdb.DataSource = dt;
            dgvrepackdb.Visible = true;

            sql_con.Close();
        }

    
      


 
  
        public void row2()
        {
            txtitemcode2.Visible = false;
            txtdescription2.Visible = false;
            txtbatch2.Visible = false;
            txtbatchtwo.Visible = false;
            txtsumtotal2.Visible = false;
            txtcode2.Visible = false;
            txttotalrepack2.Visible = false;
            txtqty2.Visible = false;
            txt2.Visible = false;


            lblnum2.Visible = false;
            b2.Visible = false;
        }
        public void row3()
        {
            txtitemcode3.Visible = false;
            txtdescription3.Visible = false;
            txtbatch3.Visible = false;
            txtqtybatch3.Visible = false;
            txtsumtotal3.Visible = false;
            txtcode3.Visible = false;
            txttotalrepack3.Visible = false;
            txtqty3.Visible = false;
            txt3.Visible = false;


            lblnum3.Visible = false;
            b3.Visible = false;
        }
        public void row4()
        {
            txtitemcode4.Visible = false;
            txtdescription4.Visible = false;
            txtbatch4.Visible = false;
            txtqtybatch4.Visible = false;
            txtsumtotal4.Visible = false;
            txtcode4.Visible = false;
            txttotalrepack4.Visible = false;
            txtqty4.Visible = false;
            txt4.Visible = false;


            lblnum4.Visible = false;
            b4.Visible = false;
        }


        public void row5()
        {
            txtitemcode5.Visible = false;
            txtdescription5.Visible = false;
            txtbatch5.Visible = false;
            txtqtybatch5.Visible = false;
            txtsumtotal5.Visible = false;
            txtcode5.Visible = false;
            txttotalrepack5.Visible = false;
            txtqty5.Visible = false;
            txt5.Visible = false;


            lblnum5.Visible = false;
            b5.Visible = false;
        }


        public void row6()
        {
            txtitemcode6.Visible = false;
            txtdescription6.Visible = false;
            txtbatch6.Visible = false;
            txtqtybatch6.Visible = false;
            txtsumtotal6.Visible = false;
            txtcode6.Visible = false;
            txttotalrepack6.Visible = false;
            txtqty6.Visible = false;
            txt6.Visible = false;

            b6.Visible = false;
            lblnum6.Visible = false;
            b6.Visible = false;
        }

        void SuccessFullyValidated()
        {
            double subjectquantity;
            double sagot;

            subjectquantity = double.Parse(lbltotalread.Text);
            sagot = subjectquantity + 1;

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.Black;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Entry No. " + sagot + " Successfully Validated " + txtdescription1.Text + " out of " + lblCounts.Text + "";
            popup.ContentColor = Color.Black;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.LightBlue;
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

            //*Total Sum of  Qty: "+lblCountss.Text+" And QTY Batch: "+label2.Text+" */




        }

        public void row7()
        {
            txtitemcode7.Visible = false;
            txtdescription7.Visible = false;
            txtbatch7.Visible = false;
            txtqtybatch7.Visible = false;
            txtsumtotal7.Visible = false;
            txtcode7.Visible = false;
            txttotalrepack7.Visible = false;
            txtqty7.Visible = false;
            txt7.Visible = false;


            lblnum7.Visible = false;
            b7.Visible = false;
        }



        public void row8()
        {
            txtitemcode8.Visible = false;
            txtdescription8.Visible = false;
            txtbatch8.Visible = false;
            txtqtybatch8.Visible = false;
            txtsumtotal8.Visible = false;
            txtcode8.Visible = false;
            txttotalrepack8.Visible = false;
            txtqty8.Visible = false;
            txt8.Visible = false;


            lblnum8.Visible = false;
            b8.Visible = false;
        }


        public void row9()
        {
            txtitemcode9.Visible = false;
            txtdescription9.Visible = false;
            txtbatch9.Visible = false;
            txtqtybatch9.Visible = false;
            txtsumtotal9.Visible = false;
            txtcode9.Visible = false;
            txttotalrepack9.Visible = false;
            txtqty9.Visible = false;
            txt9.Visible = false;


            lblnum9.Visible = false;
            b9.Visible = false;
        }

        public void row10()
        {
            txtitemcode10.Visible = false;
            txtdescription10.Visible = false;
            txtbatch10.Visible = false;
            txtqtybatch10.Visible = false;
            txtsumtotal10.Visible = false;
            txtcode10.Visible = false;
            txttotalrepack10.Visible = false;
            txtqty10.Visible = false;
            txt10.Visible = false;


            lblnum10.Visible = false;
            b10.Visible = false;
        }

        public void row11()
        {
            txtitemcode11.Visible = false;
            txtdescription11.Visible = false;
            txtbatch11.Visible = false;
            txtqtybatch11.Visible = false;
            txtsumtotal11.Visible = false;
            txtcode11.Visible = false;
            txttotalrepack11.Visible = false;
            txtqty11.Visible = false;
            txt11.Visible = false;


            b11.Visible = false;
            lblnum11.Visible = false;
        }

        public void row12()
        {
            txtitemcode12.Visible = false;
            txtdescription12.Visible = false;
            txtbatch12.Visible = false;
            txtqtybatch12.Visible = false;
            txtsumtotal12.Visible = false;
            txtcode12.Visible = false;
            txttotalrepack12.Visible = false;
            txtqty12.Visible = false;
            txt12.Visible = false;


            b12.Visible = false;
            lblnum12.Visible = false;
        }




        public void row13()
        {
            txtitemcode13.Visible = false;
            txtdescription13.Visible = false;
            txtbatch13.Visible = false;
            txtqtybatch13.Visible = false;
            txtsumtotal13.Visible = false;
            txtcode13.Visible = false;
            txttotalrepack13.Visible = false;
            txtqty13.Visible = false;
            txt13.Visible = false;


            b13.Visible = false;
            lblnum13.Visible = false;
        }

        public void row14()
        {
            txtitemcode14.Visible = false;
            txtdescription14.Visible = false;
            txtbatch14.Visible = false;
            txtqtybatch14.Visible = false;
            txtsumtotal14.Visible = false;
            txtcode14.Visible = false;
            txttotalrepack14.Visible = false;
            txtqty14.Visible = false;
            txt14.Visible = false;


            b14.Visible = false;
            lblnum14.Visible = false;
        }

        public void row15()
        {
            txtitemcode15.Visible = false;
            txtdescription15.Visible = false;
            txtbatch15.Visible = false;
            txtqtybatch15.Visible = false;
            txtsumtotal15.Visible = false;
            txtcode15.Visible = false;
            txttotalrepack15.Visible = false;
            txtqty15.Visible = false;
            txt15.Visible = false;


            b15.Visible = false;
            lblnum15.Visible = false;
        }

        public void row16()
        {
            txtitemcode16.Visible = false;
            txtdescription16.Visible = false;
            txtbatch16.Visible = false;
            txtqtybatch16.Visible = false;
            txtsumtotal16.Visible = false;
            txtcode16.Visible = false;
            txttotalrepack16.Visible = false;
            txtqty16.Visible = false;
            txt16.Visible = false;

            b16.Visible = false;
            lblnum16.Visible = false;
        }

        public void row17()
        {
            txtitemcode17.Visible = false;
            txtdescription17.Visible = false;
            txtbatch17.Visible = false;
            txtqtybatch17.Visible = false;
            txtsumtotal17.Visible = false;
            txtcode17.Visible = false;
            txttotalrepack17.Visible = false;
            txtqty17.Visible = false;
            txt17.Visible = false;
            b17.Visible = false;
            lblnum17.Visible = false;
        }



        public void col3()
        {
            txtitemcode3.Visible = true;
            txtdescription3.Visible = true;
            txtbatch3.Visible = true;
            txtqtybatch3.Visible = true;
            txtsumtotal3.Visible = true;
            txtcode3.Visible = true;
            txttotalrepack3.Visible = true;
            txtqty3.Visible = true;
            txt3.Visible = true;

            bunifu3rd.Visible = true;
            bunifuThinButton212.Visible = true;
            bunifuThinButton211.Visible = true;
            bunifuThinButton213.Visible = true;
            bunifuThinButton214.Visible = true;

            lblnum3.Visible = true;
            b3.Visible = true;

        }

        public void col4()
        {
            txtitemcode4.Visible = true;
            txtdescription4.Visible = true;
            txtbatch4.Visible = true;
            txtqtybatch4.Visible = true;
            txtsumtotal4.Visible = true;
            txtcode4.Visible = true;
            txttotalrepack4.Visible = true;
            txtqty4.Visible = true;
            txt4.Visible = true;

            bunifuThinButton215.Visible = true;
            bunifuThinButton216.Visible = true;
            bunifuThinButton217.Visible = true;
            bunifuThinButton218.Visible = true;
            bunifuThinButton219.Visible = true;
            lblnum4.Visible = true;
            b4.Visible = true;
        }
        void LimitExceeded()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Preparation Entry Already Exceeded at Checking Raw Materials Ready to Save";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.DarkOrange;
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
        public void col5()
        {
            txtitemcode5.Visible = true;
            txtdescription5.Visible = true;
            txtbatch5.Visible = true;
            txtqtybatch5.Visible = true;
            txtsumtotal5.Visible = true;
            txtcode5.Visible = true;
            txttotalrepack5.Visible = true;
            txtqty5.Visible = true;
            txt5.Visible = true;

            bunifuThinButton220.Visible = true;
            bunifuThinButton221.Visible = true;
            bunifuThinButton222.Visible = true;
            bunifuThinButton223.Visible = true;
            bunifuThinButton224.Visible = true;
            lblnum5.Visible = true;
            b5.Visible = true;
        }
        public void col6()
        {
            txtitemcode6.Visible = true;
            txtdescription6.Visible = true;
            txtbatch6.Visible = true;
            txtqtybatch6.Visible = true;
            txtsumtotal6.Visible = true;
            txtcode6.Visible = true;
            txttotalrepack6.Visible = true;
            txtqty6.Visible = true;
            txt6.Visible = true;

            bunifuThinButton225.Visible = true;
            bunifuThinButton226.Visible = true;
            bunifuThinButton227.Visible = true;
            bunifuThinButton228.Visible = true;
            bunifuThinButton229.Visible = true;
            lblnum6.Visible = true;
            b6.Visible = true;
        }

        public void col7()
        {
            txtitemcode7.Visible = true;
            txtdescription7.Visible = true;
            txtbatch7.Visible = true;
            txtqtybatch7.Visible = true;
            txtsumtotal7.Visible = true;
            txtcode7.Visible = true;
            txttotalrepack7.Visible = true;
            txtqty7.Visible = true;
            txt7.Visible = true;


            bunifuThinButton230.Visible = true;
            bunifuThinButton231.Visible = true;
            bunifuThinButton232.Visible = true;
            bunifuThinButton233.Visible = true;
            bunifuThinButton234.Visible = true;
            lblnum7.Visible = true;
            b7.Visible = true;

        }
        public void col8()
        {
            txtitemcode8.Visible = true;
            txtdescription8.Visible = true;
            txtbatch8.Visible = true;
            txtqtybatch8.Visible = true;
            txtsumtotal8.Visible = true;
            txtcode8.Visible = true;
            txttotalrepack8.Visible = true;
            txtqty8.Visible = true;
            txt8.Visible = true;




            bunifuThinButton235.Visible = true;
            bunifuThinButton238.Visible = true;
            bunifuThinButton241.Visible = true;
            bunifuThinButton244.Visible = true;
            bunifuThinButton247.Visible = true;
            lblnum8.Visible = true;
            b8.Visible = true;
        }
        public void col9()
        {
            txtitemcode9.Visible = true;
            txtdescription9.Visible = true;
            txtbatch9.Visible = true;
            txtqtybatch9.Visible = true;
            txtsumtotal9.Visible = true;
            txtcode9.Visible = true;
            txttotalrepack9.Visible = true;
            txtqty9.Visible = true;
            txt9.Visible = true;


            bunifuThinButton236.Visible = true;
            bunifuThinButton239.Visible = true;
            bunifuThinButton242.Visible = true;
            bunifuThinButton245.Visible = true;
            bunifuThinButton248.Visible = true;
            lblnum9.Visible = true;
            b9.Visible = true;


        }
        public void col10()
        {
            txtitemcode10.Visible = true;
            txtdescription10.Visible = true;
            txtbatch10.Visible = true;
            txtqtybatch10.Visible = true;
            txtsumtotal10.Visible = true;
            txtcode10.Visible = true;
            txttotalrepack10.Visible = true;
            txtqty10.Visible = true;
            txt10.Visible = true;



            bunifuThinButton237.Visible = true;
            bunifuThinButton240.Visible = true;
            bunifuThinButton243.Visible = true;
            bunifuThinButton246.Visible = true;
            bunifuThinButton249.Visible = true;
            lblnum10.Visible = true;
            b10.Visible = true;
        }
        public void col11()
        {
            txtitemcode11.Visible = true;
            txtdescription11.Visible = true;
            txtbatch11.Visible = true;
            txtqtybatch11.Visible = true;
            txtsumtotal11.Visible = true;
            txtcode11.Visible = true;
            txttotalrepack11.Visible = true;
            txtqty11.Visible = true;
            txt11.Visible = true;



            bunifuThinButton250.Visible = true;
            bunifuThinButton265.Visible = true;
            bunifuThinButton270.Visible = true;
            bunifuThinButton276.Visible = true;
            bunifuThinButton282.Visible = true;

            lblnum11.Visible = true;
            b11.Visible = true;

        }
        public void col12()
        {
            txtitemcode12.Visible = true;
            txtdescription12.Visible = true;
            txtbatch12.Visible = true;
            txtqtybatch12.Visible = true;
            txtsumtotal12.Visible = true;
            txtcode12.Visible = true;
            txttotalrepack12.Visible = true;
            txtqty12.Visible = true;
            txt12.Visible = true;


            bunifuThinButton251.Visible = true;
            bunifuThinButton266.Visible = true;
            bunifuThinButton271.Visible = true;
            bunifuThinButton277.Visible = true;
            bunifuThinButton283.Visible = true;

            lblnum12.Visible = true;
            b12.Visible = true;

        }
        public void col13()
        {
            txtitemcode13.Visible = true;
            txtdescription13.Visible = true;
            txtbatch13.Visible = true;
            txtqtybatch13.Visible = true;
            txtsumtotal13.Visible = true;
            txtcode13.Visible = true;
            txttotalrepack13.Visible = true;
            txtqty13.Visible = true;
            txt13.Visible = true;


            bunifuThinButton252.Visible = true;
            bunifuThinButton267.Visible = true;
            bunifuThinButton272.Visible = true;
            bunifuThinButton278.Visible = true;
            bunifuThinButton284.Visible = true;

            lblnum13.Visible = true;
            b13.Visible = true;

        }
        public void col14()
        {
            txtitemcode14.Visible = true;
            txtdescription14.Visible = true;
            txtbatch14.Visible = true;
            txtqtybatch14.Visible = true;
            txtsumtotal14.Visible = true;
            txtcode14.Visible = true;
            txttotalrepack14.Visible = true;
            txtqty14.Visible = true;
            txt14.Visible = true;



            bunifuThinButton253.Visible = true;
            bunifuThinButton268.Visible = true;
            bunifuThinButton273.Visible = true;
            bunifuThinButton279.Visible = true;
            bunifuThinButton285.Visible = true;
            lblnum14.Visible = true;
            b14.Visible = true;

        }
        public void col15()
        {
            txtitemcode15.Visible = true;
            txtdescription15.Visible = true;
            txtbatch15.Visible = true;
            txtqtybatch15.Visible = true;
            txtsumtotal15.Visible = true;
            txtcode15.Visible = true;
            txttotalrepack15.Visible = true;
            txtqty15.Visible = true;
            txt15.Visible = true;


            bunifuThinButton254.Visible = true;
            bunifuThinButton269.Visible = true;
            bunifuThinButton274.Visible = true;
            bunifuThinButton280.Visible = true;
            bunifuThinButton286.Visible = true;
            lblnum15.Visible = true;
            b15.Visible = true;

        }
        public void col16()
        {
            txtitemcode16.Visible = true;
            txtdescription16.Visible = true;
            txtbatch16.Visible = true;
            txtqtybatch16.Visible = true;
            txtsumtotal16.Visible = true;
            txtcode16.Visible = true;
            txttotalrepack16.Visible = true;
            txtqty16.Visible = true;
            txt16.Visible = true;


            bunifuThinButton255.Visible = true;
            bunifuThinButton288.Visible = true;
            bunifuThinButton275.Visible = true;
            bunifuThinButton281.Visible = true;
            bunifuThinButton287.Visible = true;

            lblnum16.Visible = true;
            b16.Visible = true;


        }

        public void col17()
        {
            txtitemcode17.Visible = true;
            txtdescription17.Visible = true;
            txtbatch17.Visible = true;
            txtqtybatch17.Visible = true;
            txtsumtotal17.Visible = true;
            txtcode17.Visible = true;
            txttotalrepack17.Visible = true;
            txtqty17.Visible = true;
            txt17.Visible = true;


            bunifuThinButton256.Visible = true;
            bunifuThinButton289.Visible = true;
            bunifuThinButton298.Visible = true;
            bunifuThinButton2107.Visible = true;
            bunifuThinButton2116.Visible = true;
            lblnum17.Visible = true;
            b17.Visible = true;

        }
        public void col18()
        {
            txtitemcode18.Visible = true;
            txtdescription18.Visible = true;
            txtbatch18.Visible = true;
            txtqtybatch18.Visible = true;
            txtsumtotal18.Visible = true;
            txtcode18.Visible = true;
            txttotalrepack18.Visible = true;
            txtqty18.Visible = true;
            txt18.Visible = true;


            bunifuThinButton257.Visible = true;
            bunifuThinButton290.Visible = true;
            bunifuThinButton299.Visible = true;
            bunifuThinButton2108.Visible = true;
            bunifuThinButton2117.Visible = true;
            lblnum18.Visible = true;
            b18.Visible = true;

        }

        public void col19()
        {
            txtitemcode19.Visible = true;
            txtdescription19.Visible = true;
            txtbatch19.Visible = true;
            txtqtybatch19.Visible = true;
            txtsumtotal19.Visible = true;
            txtcode19.Visible = true;
            txttotalrepack19.Visible = true;
            txtqty19.Visible = true;
            txt19.Visible = true;

            bunifuThinButton258.Visible = true;
            bunifuThinButton291.Visible = true;
            bunifuThinButton2100.Visible = true;
            bunifuThinButton2109.Visible = true;
            bunifuThinButton2118.Visible = true;
            lblnum19.Visible = true;
            b19.Visible = true;

        }

        public void col20()
        {
            txtitemcode20.Visible = true;
            txtdescription20.Visible = true;
            txtbatch20.Visible = true;
            txtqtybatch20.Visible = true;
            txtsumtotal20.Visible = true;
            txtcode20.Visible = true;
            txttotalrepack20.Visible = true;
            txtqty20.Visible = true;
            txt20.Visible = true;


            bunifuThinButton259.Visible = true;
            bunifuThinButton292.Visible = true;
            bunifuThinButton2101.Visible = true;
            bunifuThinButton2110.Visible = true;
            bunifuThinButton2119.Visible = true;
            lblnum20.Visible = true;
            b20.Visible = true;

        }
        public void col21()
        {
            txtitemcode21.Visible = true;
            txtdescription21.Visible = true;
            txtbatch21.Visible = true;
            txtqtybatch21.Visible = true;
            txtsumtotal21.Visible = true;
            txtcode21.Visible = true;
            txttotalrepack21.Visible = true;
            txtqty21.Visible = true;
            txt21.Visible = true;

            bunifuThinButton260.Visible = true;
            bunifuThinButton293.Visible = true;
            bunifuThinButton2102.Visible = true;
            bunifuThinButton2111.Visible = true;
            bunifuThinButton2120.Visible = true;


            lblnum21.Visible = true;

            b21.Visible = true;


        }
        public void col22()
        {
            txtitemcode22.Visible = true;
            txtdescription22.Visible = true;
            txtbatch22.Visible = true;
            txtqtybatch22.Visible = true;
            txtsumtotal22.Visible = true;
            txtcode22.Visible = true;
            txttotalrepack22.Visible = true;
            txtqty22.Visible = true;
            txt22.Visible = true;


            bunifuThinButton261.Visible = true;
            bunifuThinButton297.Visible = true;
            bunifuThinButton2103.Visible = true;
            bunifuThinButton2115.Visible = true;
            bunifuThinButton2123.Visible = true;
            lblnum22.Visible = true;
            b22.Visible = true;

        }

        public void col23()
        {
            txtitemcode23.Visible = true;
            txtdescription23.Visible = true;
            txtbatch23.Visible = true;
            txtqtybatch23.Visible = true;
            txtsumtotal23.Visible = true;
            txtcode23.Visible = true;
            txttotalrepack23.Visible = true;
            txtqty23.Visible = true;
            txt23.Visible = true;

            bunifuThinButton262.Visible = true;
            bunifuThinButton296.Visible = true;
            bunifuThinButton2104.Visible = true;
            bunifuThinButton2114.Visible = true;
            bunifuThinButton2124.Visible = true;
            b23.Visible = true;

            lblnum23.Visible = true;
        }

        public void col24()
        {
            txtitemcode24.Visible = true;
            txtdescription24.Visible = true;
            txtbatch24.Visible = true;
            txtqtybatch24.Visible = true;
            txtsumtotal24.Visible = true;
            txtcode24.Visible = true;
            txttotalrepack24.Visible = true;
            txtqty24.Visible = true;
            txt24.Visible = true;
            b24.Visible = true;


            bunifuThinButton263.Visible = true;
            bunifuThinButton295.Visible = true;
            bunifuThinButton2105.Visible = true;
            bunifuThinButton2113.Visible = true;
            bunifuThinButton2122.Visible = true;
            lblnum24.Visible = true;

        }

        public void col25()
        {
            txtitemcode25.Visible = true;
            txtdescription25.Visible = true;
            txtbatch25.Visible = true;
            txtqtybatch25.Visible = true;
            txtsumtotal250.Visible = true;
            txtcode25.Visible = true;
            txttotalrepack25.Visible = true;
            txtqty25.Visible = true;
            txt25.Visible = true;


            bunifuThinButton264.Visible = true;
            bunifuThinButton294.Visible = true;
            bunifuThinButton2106.Visible = true;
            bunifuThinButton2112.Visible = true;
            bunifuThinButton2121.Visible = true;
            lblnum25.Visible = true;
            b25.Visible = true;

        }

        public void row18()
        {
            txtitemcode18.Visible = false;
            txtdescription18.Visible = false;
            txtbatch18.Visible = false;
            txtqtybatch18.Visible = false;
            txtsumtotal18.Visible = false;
            txtcode18.Visible = false;
            txttotalrepack18.Visible = false;
            txtqty18.Visible = false;
            txt18.Visible = false;

            lblnum18.Visible = false;
            b18.Visible = false;
        }
        public void row19()
        {
            txtitemcode19.Visible = false;
            txtdescription19.Visible = false;
            txtbatch19.Visible = false;
            txtqtybatch19.Visible = false;
            txtsumtotal19.Visible = false;
            txtcode19.Visible = false;
            txttotalrepack19.Visible = false;
            txtqty19.Visible = false;
            txt19.Visible = false;

            lblnum19.Visible = false;
            b19.Visible = false;
        }
        public void row20()
        {
            txtitemcode20.Visible = false;
            txtdescription20.Visible = false;
            txtbatch20.Visible = false;
            txtqtybatch20.Visible = false;
            txtsumtotal20.Visible = false;
            txtcode20.Visible = false;
            txttotalrepack20.Visible = false;
            txtqty20.Visible = false;
            txt20.Visible = false;
            b20.Visible = false;
            lblnum20.Visible = false;
        }
        public void row21()
        {
            txtitemcode21.Visible = false;
            txtdescription21.Visible = false;
            txtbatch21.Visible = false;
            txtqtybatch21.Visible = false;
            txtsumtotal21.Visible = false;
            txtcode21.Visible = false;
            txttotalrepack21.Visible = false;
            txtqty21.Visible = false;
            txt21.Visible = false;
            lblnum21.Visible = false;
            b21.Visible = false;
        }
        public void row22()
        {
            txtitemcode22.Visible = false;
            txtdescription22.Visible = false;
            txtbatch22.Visible = false;
            txtqtybatch22.Visible = false;
            txtsumtotal22.Visible = false;
            txtcode22.Visible = false;
            txttotalrepack22.Visible = false;
            txtqty22.Visible = false;
            txt22.Visible = false;
            lblnum22.Visible = false;
            b22.Visible = false;
        }
        public void row23()
        {
            txtitemcode23.Visible = false;
            txtdescription23.Visible = false;
            txtbatch23.Visible = false;
            txtqtybatch23.Visible = false;
            txtsumtotal23.Visible = false;
            txtcode23.Visible = false;
            txttotalrepack23.Visible = false;
            txtqty23.Visible = false;
            txt23.Visible = false;
            lblnum23.Visible = false;
            b23.Visible = false;
            b23.Visible = false;
        }
        public void row24()
        {
            txtitemcode24.Visible = false;
            txtdescription24.Visible = false;
            txtbatch24.Visible = false;
            txtqtybatch24.Visible = false;
            txtsumtotal24.Visible = false;
            txtcode24.Visible = false;
            txttotalrepack24.Visible = false;
            txtqty24.Visible = false;
            txt24.Visible = false;
            lblnum24.Visible = false;
            b24.Visible = false;
        }
        public void row25()
        {
            txtitemcode25.Visible = false;
            txtdescription25.Visible = false;
            txtbatch25.Visible = false;
            txtqtybatch25.Visible = false;
            txtsumtotal250.Visible = false;
            txtcode25.Visible = false;
            txttotalrepack25.Visible = false;
            txtqty25.Visible = false;
            txt25.Visible = false;
            lblnum25.Visible = false;
            b25.Visible = false;
        }



        public void calldisable()
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            pictureBox9.Visible = false;
            pictureBox10.Visible = false;
            pictureBox11.Visible = false;
            pictureBox12.Visible = false;
            pictureBox13.Visible = false;
            pictureBox14.Visible = false;
            pictureBox15.Visible = false;
            pictureBox16.Visible = false;
            pictureBox17.Visible = false;
            pictureBox18.Visible = false;
            pictureBox19.Visible = false;
            pictureBox20.Visible = false;
            pictureBox21.Visible = false;
            pictureBox22.Visible = false;
            pictureBox23.Visible = false;
            pictureBox24.Visible = false;
            pictureBox25.Visible = false;
            groupBoxpack.Visible = false;
        }

        void StressHideTextBox()
        {
            txt1.Text = "";
            txt1.BackColor = Color.White;
            //
            bunifuThinButton22.Visible = false;
            bunifuThinButton27.Visible = false;
            bunifuThinButton28.Visible = false;
            bunifuThinButton29.Visible = false;
            bunifuThinButton210.Visible = false;


            //3\  
            bunifu3rd.Visible = false;
            bunifuThinButton212.Visible = false;
            bunifuThinButton211.Visible = false;
            bunifuThinButton213.Visible = false;
            bunifuThinButton214.Visible = false;
            //4
            bunifuThinButton215.Visible = false;
            bunifuThinButton216.Visible = false;
            bunifuThinButton217.Visible = false;
            bunifuThinButton218.Visible = false;
            bunifuThinButton219.Visible = false;

            //5

            bunifuThinButton220.Visible = false;
            bunifuThinButton221.Visible = false;
            bunifuThinButton222.Visible = false;
            bunifuThinButton223.Visible = false;
            bunifuThinButton224.Visible = false;
            //6

            bunifuThinButton225.Visible = false;
            bunifuThinButton226.Visible = false;
            bunifuThinButton227.Visible = false;

            bunifuThinButton228.Visible = false;
            bunifuThinButton229.Visible = false;

            //7
            bunifuThinButton230.Visible = false;
            bunifuThinButton231.Visible = false;
            bunifuThinButton232.Visible = false;
            bunifuThinButton233.Visible = false;
            bunifuThinButton234.Visible = false;
            //8
            bunifuThinButton235.Visible = false;
            bunifuThinButton238.Visible = false;
            bunifuThinButton241.Visible = false;
            bunifuThinButton244.Visible = false;
            bunifuThinButton247.Visible = false;

            //9
            bunifuThinButton236.Visible = false;
            bunifuThinButton239.Visible = false;
            bunifuThinButton242.Visible = false;
            bunifuThinButton245.Visible = false;
            bunifuThinButton248.Visible = false;
            //10
            bunifuThinButton237.Visible = false;
            bunifuThinButton240.Visible = false;
            bunifuThinButton243.Visible = false;
            bunifuThinButton246.Visible = false;
            bunifuThinButton249.Visible = false;
            //11
            bunifuThinButton250.Visible = false;
            bunifuThinButton265.Visible = false;
            bunifuThinButton270.Visible = false;
            bunifuThinButton276.Visible = false;
            bunifuThinButton282.Visible = false;
            //12
            bunifuThinButton251.Visible = false;
            bunifuThinButton266.Visible = false;
            bunifuThinButton271.Visible = false;
            bunifuThinButton277.Visible = false;
            bunifuThinButton283.Visible = false;
            //13
            bunifuThinButton252.Visible = false;
            bunifuThinButton267.Visible = false;
            bunifuThinButton272.Visible = false;
            bunifuThinButton278.Visible = false;
            bunifuThinButton284.Visible = false;
            //14

            bunifuThinButton253.Visible = false;
            bunifuThinButton268.Visible = false;
            bunifuThinButton273.Visible = false;
            bunifuThinButton279.Visible = false;
            bunifuThinButton285.Visible = false;

            //15
            bunifuThinButton254.Visible = false;
            bunifuThinButton269.Visible = false;
            bunifuThinButton274.Visible = false;
            bunifuThinButton280.Visible = false;
            bunifuThinButton286.Visible = false;

            //15
            bunifuThinButton255.Visible = false;
            bunifuThinButton288.Visible = false;
            bunifuThinButton275.Visible = false;
            bunifuThinButton281.Visible = false;
            bunifuThinButton287.Visible = false;
            //17

            bunifuThinButton256.Visible = false;
            bunifuThinButton289.Visible = false;
            bunifuThinButton298.Visible = false;
            bunifuThinButton2107.Visible = false;
            bunifuThinButton2116.Visible = false;

            //18
            bunifuThinButton257.Visible = false;
            bunifuThinButton290.Visible = false;
            bunifuThinButton299.Visible = false;
            bunifuThinButton2108.Visible = false;
            bunifuThinButton2117.Visible = false;
            //19

            bunifuThinButton258.Visible = false;
            bunifuThinButton291.Visible = false;
            bunifuThinButton2100.Visible = false;
            bunifuThinButton2109.Visible = false;
            bunifuThinButton2118.Visible = false;

            //20
            bunifuThinButton259.Visible = false;
            bunifuThinButton292.Visible = false;
            bunifuThinButton2101.Visible = false;
            bunifuThinButton2110.Visible = false;
            bunifuThinButton2119.Visible = false;
            //21
            bunifuThinButton260.Visible = false;
            bunifuThinButton293.Visible = false;
            bunifuThinButton2102.Visible = false;
            bunifuThinButton2111.Visible = false;
            bunifuThinButton2120.Visible = false;

            //22
            bunifuThinButton261.Visible = false;
            bunifuThinButton297.Visible = false;
            bunifuThinButton2103.Visible = false;
            bunifuThinButton2115.Visible = false;
            bunifuThinButton2123.Visible = false;

            //23

            bunifuThinButton262.Visible = false;
            bunifuThinButton296.Visible = false;
            bunifuThinButton2104.Visible = false;
            bunifuThinButton2114.Visible = false;
            bunifuThinButton2124.Visible = false;

            //24
            bunifuThinButton263.Visible = false;
            bunifuThinButton295.Visible = false;
            bunifuThinButton2105.Visible = false;
            bunifuThinButton2113.Visible = false;
            bunifuThinButton2122.Visible = false;

            //25
            bunifuThinButton264.Visible = false;
            bunifuThinButton294.Visible = false;
            bunifuThinButton2106.Visible = false;
            bunifuThinButton2112.Visible = false;
            bunifuThinButton2121.Visible = false;

        }

        public void Callothers()
        {

            DateTime dNow = DateTime.Now;
            txtdatenow.Text = (dNow.ToString("MM/dd/yyyy"));

        }
        public void load_Schedules()
        {
            string mcolumns = "prod_id,p_feed_code,rp_feed_type,p_bags,p_nobatch,proddate,repacking_status";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgvMaster, mcolumns, "schedules_approved_preparation2macro");
            label10.Text = dgvMaster.RowCount.ToString();
            // textBox1.Text = dgv_table.RowCount.ToString();
            lblpuke.Text = dgvMaster.RowCount.ToString();
        }

        private void txtmainfeedcode_TextChanged(object sender, EventArgs e)
        {

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=hr_bak;Integrated Security=SSPI";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);

            // AND rp_category='MICRO' ORDER BY rp_group
            //            string sqlquery = "select DISTINCT adv.prod_id,rpa.feed_code,rpa.rp_feed_type,rpa.rp_group,rpa.item_code,rpa.rp_description,adv.p_nobatch,rpa.quantity,rpa.quantity from [dbo].[rdf_recipe_to_production] rpa LEFT JOIN rdf_production_advance adv ON rpa.production_id=adv.prod_id WHERE rpa.feed_code = '" + txtmainfeedcode.Text + "' AND rp_category='MICRO' AND rpa.is_active=0";sdsd
            string sqlquery = "select adv.prod_id,rpa.feed_code,rpa.rp_feed_type,rpa.rp_group,rpa.item_code,rpa.rp_description,adv.p_nobatch,rpa.quantity,rpa.quantity,rpa.recipe_id from [dbo].[rdf_recipe_to_production] rpa LEFT JOIN rdf_production_advance adv ON rpa.production_id=adv.prod_id WHERE rp_category='MACRO' AND rpa.repacking_status='1' AND rpa.production_id = '" + txtmasterid.Text + "' AND rpa.rp_group='Validate' AND rpa.macro_is_prepared IS NOT NULL ORDER BY rpa.item_code DESC";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvImport.DataSource = dt;
            lbltotalprepared.Text = dgvImport.RowCount.ToString();
            lbltotalprepared2.Text = dgvImport.RowCount.ToString();
            sql_con.Close();

        }
        void times2query()
        {
            for (int n = 0; n < (dgvImport.Rows.Count); n++)
            {
                //double s = Convert.ToDouble(dgvImport.Rows[n].Cells[4].Value);


                //double s1 = Convert.ToDouble(dgvAllFeedCode.Rows[n].Cells[7].Value);

                double s1 = Convert.ToDouble(dgvImport.Rows[n].Cells[7].Value);

                //int s1 = Convert.ToInt32(dgv1stView.Rows[n].Cells[1].Value);
                //double s13 = s * 2;
                double s15 = s1 * 2;

                //dgvImport.Rows[n].Cells[7].Value = s15.ToString("#,0.000");
                dgvImport.Rows[n].Cells[7].Value = s15.ToString();


                //dgvAllFeedCode.Rows[n].Cells[4].Value = s13.ToString("#,0.000");
                //dgvAllFeedCode.Rows[n].Cells[7].Value = s15.ToString("#,0.000");
            }


        }

        private void txtmasterid_TextChanged(object sender, EventArgs e)
        {
            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=hr_bak;Integrated Security=SSPI";
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);

            // AND rp_category='MICRO' ORDER BY rp_group
            //            string sqlquery = "select DISTINCT adv.prod_id,rpa.feed_code,rpa.rp_feed_type,rpa.rp_group,rpa.item_code,rpa.rp_description,adv.p_nobatch,rpa.quantity,rpa.quantity from [dbo].[rdf_recipe_to_production] rpa LEFT JOIN rdf_production_advance adv ON rpa.production_id=adv.prod_id WHERE rpa.feed_code = '" + txtmainfeedcode.Text + "' AND rp_category='MICRO' AND rpa.is_active=0";
            string sqlquery = "select adv.prod_id,rpa.feed_code,rpa.rp_feed_type,rpa.rp_group,rpa.item_code,rpa.rp_description,adv.p_nobatch,rpa.quantity,rpa.quantity,rpa.recipe_id from [dbo].[rdf_recipe_to_production] rpa LEFT JOIN rdf_production_advance adv ON rpa.production_id=adv.prod_id WHERE rp_category='MACRO' AND rpa.is_active='0' AND rpa.production_id = '" + txtmasterid.Text + "' AND rpa.rp_group='Validate' AND rpa.macro_is_prepared IS NULL ORDER BY rpa.item_code DESC ";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgv1stView.DataSource = dt;

            sql_con.Close();
            //mekeni




            String connetionString2 = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //String connetionString2 = @"Server=FM-MMERCADO-L;Initial Catalog=hr_bak;Integrated Security=SSPI";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con2 = new SqlConnection(connetionString2);

            // AND rp_category='MICRO' ORDER BY rp_group
            string sqlquery2 = "select rpa.feed_code,rpa.rp_feed_type,rpa.rp_group,rpa.item_code,rpa.rp_description,rpa.quantity,rpa.quantity from [dbo].[rdf_recipe_to_production] rpa WHERE rpa.production_id = '" + txtmasterid.Text + "' AND rpa.rp_category='MACRO' AND rp_group='Validate'";
            sql_con.Open();
            SqlCommand sql_cmd2 = new SqlCommand(sqlquery2, sql_con2);
            SqlDataAdapter sdr2 = new SqlDataAdapter(sql_cmd2);
            DataTable dt2 = new DataTable();
            sdr2.Fill(dt2);
            dgvLastFeedCode.DataSource = dt2;
            lbltotalcounts.Text = dgvLastFeedCode.RowCount.ToString();

            sql_con2.Close();














            for (int n = 0; n < (dgv1stView.Rows.Count); n++)
            {
                double s = Convert.ToDouble(dgv1stView.Rows[n].Cells[7].Value);
                double s1 = Convert.ToDouble(dgv1stView.Rows[n].Cells[6].Value);
                //int s1 = Convert.ToInt32(dgv1stView.Rows[n].Cells[1].Value);
                double s13 = s * 2;
                double s15 = s1 * s13;
                dgv1stView.Rows[n].Cells[7].Value = s13.ToString("#,0.000");
                //dgv1stView.Rows[n].Cells[8].Value = s15.ToString("#,0.000");
                dgv1stView.Rows[n].Cells[8].Value = s13.ToString("#,0.000");
            }










            decimal tot = 0;

            for (int i = 0; i < dgv1stView.RowCount - 1; i++)
            {
                var value = dgv1stView.Rows[i].Cells["quantity"].Value;
                if (value != DBNull.Value)
                {
                    tot += Convert.ToDecimal(value);
                }
            }
            if (tot == 0)
            {

            }

            decimal toty = 0;

            for (int i = 0; i < dgv1stView.RowCount - 1; i++)
            {
                var value = dgv1stView.Rows[i].Cells["quantity1"].Value;
                if (value != DBNull.Value)
                {
                    toty += Convert.ToDecimal(value);
                }
            }
            if (toty == 0)
            {

            }
            //answer = s1 * 2;
            //dgv1stView.CurrentRow.Cells[2].Value = answer;
            //dgv1stView.CurrentRow.Cells[3].Value = answer;


            //dgv1stView.Rows[dgv1stView.Rows.Count - 1].Cells[0].Value = answer;
            //dgv1stView.Rows[dgv1stView.Rows.Count - 2].Cells["quantity"].Value = tot.ToString();



            lblCountss.Text = tot.ToString();
            label2.Text = toty.ToString();
            lblCounts.Text = dgv1stView.RowCount.ToString();


           

            txt1.Enabled = true;
            txtscanid.Select();
            txtscanid.Focus();
        }

        void RepackRawMatsFirst()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "This Production Entry is not Already Done for Repacking";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.DarkOrange;
            popup.Popup();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }

        void NoDataFound()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "NO DATA FOUND !";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Red;
            popup.Popup();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;
            splitContainer1.Visible = false;

        }


        void showValueDailyProduction()
        {

            if (dgvMaster.RowCount > 0)
            {
                if (dgvMaster.CurrentRow != null)
                {
                    if (dgvMaster.CurrentRow.Cells["prod_id"].Value != null)
                    {
                        p_id = Convert.ToInt32(dgvMaster.CurrentRow.Cells["prod_id"].Value);

                        txtmainfeedcode.Text = dgvMaster.CurrentRow.Cells["p_feed_code"].Value.ToString();
                        txtstatus.Text = dgvMaster.CurrentRow.Cells["repacking_status"].Value.ToString();
                        txtmasterid.Text = dgvMaster.CurrentRow.Cells["prod_id"].Value.ToString();
                        txtnobatch.Text = dgvMaster.CurrentRow.Cells["p_nobatch"].Value.ToString();
                        lblbatch.Text = dgvMaster.CurrentRow.Cells["p_nobatch"].Value.ToString();


        


                    }

                }
            }

        }
        private void dgvMaster_CurrentCellChanged(object sender, EventArgs e)
        {
            showValueDailyProduction();
            //4/24/2020

            if (lbltotalprepared.Text == "0")
            {
                if (lblCounts.Text == lbltotalcounts.Text)
                {
                    //bunifuStart.Enabled = false;
                    txtscanid.Enabled = true;
                    txtscanid.Select();
                    txtscanid.Focus();
                }
                else
                {

                    //bunifuStart.Enabled = true;
                    //bunifuStart.Enabled = false;
                    txtscanid.Enabled = false;
                }
            }
            else
            {
                txtscanid.Enabled = true;
                txtscanid.Select();
                txtscanid.Focus();
            }


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

        void NoDataFound2()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.ContentText = "NO DATA FOUND "+txtaddedby.Text+"!";
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
            timer1_Tick(new object(), new System.EventArgs());

        }
        private void btnlessthan_Click(object sender, EventArgs e)
        {
            if(label10.Text=="0")
            {
                NoDataFound();
                return;
            }
            txtmainfeedcode_TextChanged(sender, e);
            ////txtQuantity.Text = dgvImport.CurrentRow.Cells["quantity2"].Value.ToString();

            //txtitemcode_TextChanged(sender, e);
            //lblmainCount.Text = "0";
            if (dgvMaster.Rows.Count >= 1)
            {


                int i = dgvMaster.CurrentRow.Index + 1;
                if (i >= -1 && i < dgvMaster.Rows.Count)
                    dgvMaster.CurrentCell = dgvMaster.Rows[i].Cells[1];




                //dgvMaster_Click(sender,e);
                else
                {
                    LastLine();
                    txtscanid.Select();
                    txtscanid.Focus();
                    //txtselectweight.Text = dgvAllFeedCode.CurrentRow.Cells["Quantity"].Value.ToString();
                    //timer1_Tick(sender, e);
                    //txtweighingscale.Focus();

                    //txtQuantity.Text = dgvImport.CurrentRow.Cells["quantity2"].Value.ToString();

                    return;
                }
            }
            //}
            ////txttotalQty.Text = (float.Parse(txtQuantity.Text) * float.Parse(txtnobatch.Text)).ToString();
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


        }


        void RepackIdNotExists()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "RAW MATERIAL REPACK IS NOT EXISTS";
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
        private void btngreaterthan_Click(object sender, EventArgs e)
        {
            if (label10.Text=="0")
            {
                NoDataFound();
                return;
            }

            txtmainfeedcode_TextChanged(sender, e);
            //txtQuantity.Text = dgvImport.CurrentRow.Cells["quantity2"].Value.ToString();
            //if (dgv1stView.Rows.Count >= 1)
            //{
            //int i = dgv1stView.CurrentRow.Index - 1;
            //if (i >= -1 && i < dgv1stView.Rows.Count)
            //dgv1stView.CurrentCell = dgv1stView.Rows[i].Cells[0];

            //}''

            int prev = this.dgvMaster.CurrentRow.Index - 1;
            if (prev >= 0)
            {

                this.dgvMaster.CurrentCell = this.dgvMaster.Rows[prev].Cells[this.dgvMaster.CurrentCell.ColumnIndex];
                //dgvMaster_Click(sender, e);
            }
            else
            {
                FirstLine();
                txtscanid.Select();
                txtscanid.Focus();
                ////txtQuantity.Text = dgvImport.CurrentRow.Cells["quantity2"].Value.ToString();
            }


            ////txttotalQty.Text = (float.Parse(txtQuantity.Text) * float.Parse(txtnobatch.Text)).ToString();
            ////checkReceivingBalance();
            //btnbalance_Click(sender, e);
        }

        private void dgvImport_CurrentCellChanged(object sender, EventArgs e)
        {
            ready = true;
            showImportDataGrid2();
        }

        void showImportDataGrid2()
        {
            if (ready == true)
            {
                if (dgvImport.CurrentRow != null)
                {
                    if (dgvImport.CurrentRow.Cells["recipe_id"].Value != null)
                    {
                        p_id = Convert.ToInt32(dgvImport.CurrentRow.Cells["recipe_id"].Value);
                        //txtItemCode.Text = dgvImport.CurrentRow.Cells["item_code"].Value.ToString();
                        txtQuantity.Text = dgvImport.CurrentRow.Cells["quantity2"].Value.ToString();
                        txtitemdescription.Text = dgvImport.CurrentRow.Cells["rp_description"].Value.ToString();

                    }
                }
            }
        }

        private void txtItemCode_TextChanged(object sender, EventArgs e)
        {
            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=hr_bak;Integrated Security=SSPI";
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "select item_id,item_code,item_description,total_quantity_raw,qty_repack_available,qty_repack,qty_production,active_qty_repack from [dbo].[rdf_raw_materials] WHERE item_code = '" + txtItemCode.Text + "'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvMaster2.DataSource = dt;
            //dgvMaster.Visible = true;
            ////dgv_table_2nd_sup.Visible = true;
            //lblmicroview.Visible = true;
            sql_con.Close();
        }

        private void dgvMaster2_CurrentCellChanged(object sender, EventArgs e)
        {
            ready = true;
            showRawMatsDataGrid();
        }

        void showRawMatsDataGrid()
        {
            if (ready == true)
            {
                if (dgvMaster2.CurrentRow != null)
                {
                    if (dgvMaster2.CurrentRow.Cells["item_id"].Value != null)
                    {
                        p_id = Convert.ToInt32(dgvMaster2.CurrentRow.Cells["item_id"].Value);
                        txtrepackavailable.Text = dgvMaster2.CurrentRow.Cells["qty_repack"].Value.ToString();
                    txtactiverepack.Text = dgvMaster2.CurrentRow.Cells["active_qty_repack"].Value.ToString();

                    }
                }
            }
        }

        void ReadyforPreparation()
        {
            double subjectquantity;
            double sagot;

            subjectquantity = double.Parse(lbltotalread.Text);
            sagot = subjectquantity * 1;

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.information;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.Black;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = " QTY Needed for Preparations, Already Match Ready To Save!,  Entry No. " + sagot + " out of " + lblCounts.Text + "";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(920, 270);
            popup.ImageSize = new Size(175, 180);
            popup.BodyColor = Color.CornflowerBlue;
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

            //*Total Sum of  Qty: "+lblCountss.Text+" And QTY Batch: "+label2.Text+" */

            txttotalQty.Text = (float.Parse(txtQuantity.Text) * float.Parse(txtnobatch.Text)).ToString();


        }

        private void txt1_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);


            txtqtybactchactive.Text = dgv1stView.CurrentRow.Cells["quantity"].Value.ToString();

            //bunifuStart.BackColor = Color.DarkSeaGreen;
            dgvMaster.Enabled = false;
            bunifuStart.Visible = false;
            bunifuStopPreparation.Visible = true;
            dgv1stView.Enabled = false;
            btngreaterthan.BackColor = Color.LightGray;
            btnlessthan.BackColor = Color.LightGray;
            btngreaterthan.Enabled = false;
            btnlessthan.Enabled = false;
            //if (Convert.ToInt32(e.KeyChar) == 13)
            //{
            //    button1_Click(sender, e);
            //    txt1.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
            //}

        }
        void RepackIDExists()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "WARNING CANNOT BE USED THE RAW MATERIAL REPACK, BECAUSE ITS  ALREADY IN THE PRODUCTION !";
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

        void RepackIDExists2()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Repack ID is Not Exists !";
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
        private void txt1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gerard1_Click(sender, e);
            }
        }

        void BarcodeNotFound()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "BARCODE INPUT NOT FOUND !";
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



        void ItemCodeNotMatched()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "ITEM CODE NOT MATCHED !";
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




        void ItemCodeValueNotmacthed()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.information;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Item Quantity Not Match IN Our Needed!, Choose the Exactly item Quantity";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(920, 270);
            popup.ImageSize = new Size(175, 180);
            popup.BodyColor = Color.DarkOrange;
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


        public void col2()
        {
            txtitemcode2.Visible = true;
            txtdescription2.Visible = true;
            txtbatch2.Visible = true;
            txtbatchtwo.Visible = true;
            txtsumtotal2.Visible = true;
            txtcode2.Visible = true;
            txttotalrepack2.Visible = true;
            txtqty2.Visible = true;
            txt2.Visible = true;

            //2
            bunifuThinButton22.Visible = true;
            bunifuThinButton27.Visible = true;
            bunifuThinButton28.Visible = true;
            bunifuThinButton29.Visible = true;
            bunifuThinButton210.Visible = true;
            lblnum2.Visible = true;
            b2.Visible = true;


        }



        void Dochecking()
        {
            if (lbltotalread.Text == "17")
            {

                if (lblCounts.Text.Trim() == lbltotalread.Text.Trim())
                {
                    //MessageBox.Show("Qty Needed Match Ready TO Save <3");
                    ReadyforPreparation();
                    BtnSave.Visible = true;
                    //row18();
                    //row19();
                    return;
                }
                else
                {

                    //if (dgv1stView.Rows.Count >= 1)
                    //{
                    //    int i = dgv1stView.CurrentRow.Index + 1;
                    //    if (i >= -1 && i < dgv1stView.Rows.Count)

                    //        txtitemcode18.Text = dgv1stView.CurrentRow.Cells["item_code"].Value.ToString();
                    //    txtdescription18.Text = dgv1stView.CurrentRow.Cells["rp_description"].Value.ToString();
                    //    txtbatch18.Text = dgv1stView.CurrentRow.Cells["p_nobatch"].Value.ToString();
                    //    txtqty18.Text = dgv1stView.CurrentRow.Cells["quantity"].Value.ToString();

                    //    dgv1stView.CurrentCell = dgv1stView.Rows[i].Cells[0];
                    //}





                    col18();
                    txt18.Focus();
                    txt18.Select();
                }
                //BtnSave.Visible = true;

                //dv.RowFilter = "firstname like '%" + txtsearch.Text + "%' or lastname like '%" + txtsearch.Text + "%' or employee_number like '%" + txtsearch.Text + "%' or employment_status_name like '%" + txtsearch.Text + "%'";
            }
            else if (lbltotalread.Text == "1")


            {
                if (lblCounts.Text.Trim() == lbltotalread.Text.Trim())
                {
                    //MessageBox.Show("Qty Needed Match Ready TO Save <3");
                    ReadyforPreparation();
                    BtnSave.Visible = true;
                }
                else
                {
                    col2();
                    txt2.Focus();
                    txt2.Select();
                }
            }
            else if (lbltotalread.Text == "2")
            {
                if (lblCounts.Text.Trim() == lbltotalread.Text.Trim())
                {
                    //MessageBox.Show("Qty Needed Match Ready TO Save <3");
                    ReadyforPreparation();
                    BtnSave.Visible = true;
                }
                else
                {
                    col3();
                    txt3.Focus();
                    txt3.Select();
                }
            }
            else if (lbltotalread.Text == "3")
            {
                if (lblCounts.Text.Trim() == lbltotalread.Text.Trim())
                {
                    //MessageBox.Show("Qty Needed Match Ready TO Save <3");
                    ReadyforPreparation();
                    BtnSave.Visible = true;
                }
                else
                {
                    col4();
                    txt4.Focus();
                    txt4.Select();
                }
            }
            else if (lbltotalread.Text == "4")
            {
                if (lblCounts.Text.Trim() == lbltotalread.Text.Trim())
                {
                    //MessageBox.Show("Qty Needed Match Ready TO Save <3");
                    ReadyforPreparation();
                    BtnSave.Visible = true;
                }
                else
                {
                    col5();
                    txt5.Focus();
                    txt5.Select();
                }
            }
            else if (lbltotalread.Text == "5")
            {
                if (lblCounts.Text.Trim() == lbltotalread.Text.Trim())
                {
                    //MessageBox.Show("Qty Needed Match Ready TO Save <3");
                    ReadyforPreparation();
                    BtnSave.Visible = true;
                }
                else
                {
                    col6();
                    txt6.Focus();
                    txt6.Select();
                }
            }
            else if (lbltotalread.Text == "6")
            {
                if (lblCounts.Text.Trim() == lbltotalread.Text.Trim())
                {
                    //MessageBox.Show("Qty Needed Match Ready TO Save <3");
                    ReadyforPreparation();
                    BtnSave.Visible = true;
                }
                else
                {
                    col7();
                    txt7.Focus();
                    txt7.Select();
                }
            }
            else if (lbltotalread.Text == "7")
            {
                if (lblCounts.Text.Trim() == lbltotalread.Text.Trim())
                {
                    //MessageBox.Show("Qty Needed Match Ready TO Save <3");
                    ReadyforPreparation();
                    BtnSave.Visible = true;
                }
                else
                {
                    col8();
                    txt8.Focus();
                    txt8.Select();
                }
            }
            else if (lbltotalread.Text == "8")
            {
                if (lblCounts.Text.Trim() == lbltotalread.Text.Trim())
                {
                    //MessageBox.Show("Qty Needed Match Ready TO Save <3");
                    ReadyforPreparation();
                    BtnSave.Visible = true;
                }
                else
                {
                    col9();
                    txt9.Focus();
                    txt9.Select();
                }
            }
            else if (lbltotalread.Text == "9")
            {
                if (lblCounts.Text.Trim() == lbltotalread.Text.Trim())
                {
                    //MessageBox.Show("Qty Needed Match Ready TO Save <3");
                    ReadyforPreparation();
                    BtnSave.Visible = true;
                }
                else
                {
                    col10();
                    txt10.Focus();
                    txt10.Select();
                }
            }
            else if (lbltotalread.Text == "10")
            {
                if (lblCounts.Text.Trim() == lbltotalread.Text.Trim())
                {
                    //MessageBox.Show("Qty Needed Match Ready TO Save <3");
                    ReadyforPreparation();
                    BtnSave.Visible = true;
                }
                else
                {
                    col11();
                    txt11.Focus();
                    txt11.Select();
                }
            }
            else if (lbltotalread.Text == "11")
            {
                if (lblCounts.Text.Trim() == lbltotalread.Text.Trim())
                {
                    //MessageBox.Show("Qty Needed Match Ready TO Save <3");
                    ReadyforPreparation();
                    BtnSave.Visible = true;
                }
                else
                {
                    col12();
                    txt12.Focus();
                    txt12.Select();
                }
            }
            else if (lbltotalread.Text == "12")
            {
                if (lblCounts.Text.Trim() == lbltotalread.Text.Trim())
                {
                    //MessageBox.Show("Qty Needed Match Ready TO Save <3");
                    ReadyforPreparation();
                    BtnSave.Visible = true;
                }
                else
                {
                    col13();
                    txt13.Focus();
                    txt13.Select();
                }
            }
            else if (lbltotalread.Text == "13")
            {
                if (lblCounts.Text.Trim() == lbltotalread.Text.Trim())
                {
                    //MessageBox.Show("Qty Needed Match Ready TO Save <3");
                    ReadyforPreparation();
                    BtnSave.Visible = true;
                }
                else
                {
                    col14();
                    txt14.Focus();
                    txt14.Select();
                }
            }
            else if (lbltotalread.Text == "14")
            {
                if (lblCounts.Text.Trim() == lbltotalread.Text.Trim())
                {
                    //MessageBox.Show("Qty Needed Match Ready TO Save <3");
                    ReadyforPreparation();
                    BtnSave.Visible = true;
                }
                else
                {
                    col15();
                    txt15.Focus();
                    txt15.Select();
                }
            }
            else if (lbltotalread.Text == "15")
            {
                if (lblCounts.Text.Trim() == lbltotalread.Text.Trim())
                {
                    //MessageBox.Show("Qty Needed Match Ready TO Save <3");
                    ReadyforPreparation();
                    BtnSave.Visible = true;
                }
                else
                {
                    col16();
                    txt16.Focus();
                    txt16.Select();
                }
            }
            else if (lbltotalread.Text == "16")
            {
                if (lblCounts.Text.Trim() == lbltotalread.Text.Trim())
                {
                    //MessageBox.Show("Qty Needed Match Ready TO Save <3");
                    ReadyforPreparation();
                    BtnSave.Visible = true;
                }
                else
                {
                    col17();
                    txt17.Focus();
                    txt17.Select();
                }
            }
            else if (lbltotalread.Text == "18")
            {
                if (lblCounts.Text.Trim() == lbltotalread.Text.Trim())
                {
                    //MessageBox.Show("Qty Needed Match Ready TO Save <3");
                    ReadyforPreparation();
                    BtnSave.Visible = true;
                }
                else
                {
                    col19();
                    txt19.Focus();
                    txt19.Select();
                }
            }
            else if (lbltotalread.Text == "19")
            {
                if (lblCounts.Text.Trim() == lbltotalread.Text.Trim())
                {
                    //MessageBox.Show("Qty Needed Match Ready TO Save <3");
                    ReadyforPreparation();
                    BtnSave.Visible = true;
                }
                else
                {
                    col20();
                    txt20.Focus();
                    txt20.Select();
                }
            }
            else if (lbltotalread.Text == "20")
            {
                if (lblCounts.Text.Trim() == lbltotalread.Text.Trim())
                {
                    //MessageBox.Show("Qty Needed Match Ready TO Save <3");
                    ReadyforPreparation();
                    BtnSave.Visible = true;
                }
                else
                {
                    col21();
                    txt21.Focus();
                    txt21.Select();
                }
            }
            else if (lbltotalread.Text == "21")
            {
                if (lblCounts.Text.Trim() == lbltotalread.Text.Trim())
                {
                    //MessageBox.Show("Qty Needed Match Ready TO Save <3");
                    ReadyforPreparation();
                    BtnSave.Visible = true;
                }
                else
                {
                    col22();
                    txt22.Focus();
                    txt22.Select();
                }
            }
            else if (lbltotalread.Text == "22")
            {
                if (lblCounts.Text.Trim() == lbltotalread.Text.Trim())
                {
                    //MessageBox.Show("Qty Needed Match Ready TO Save <3");
                    ReadyforPreparation();
                    BtnSave.Visible = true;
                }
                else
                {
                    col23();
                    txt23.Focus();
                    txt23.Select();
                }
            }
            else if (lbltotalread.Text == "23")
            {
                if (lblCounts.Text.Trim() == lbltotalread.Text.Trim())
                {
                    //MessageBox.Show("Qty Needed Match Ready TO Save <3");
                    ReadyforPreparation();
                    BtnSave.Visible = true;
                }
                else
                {
                    col24();
                    txt24.Focus();
                    txt24.Select();
                }
            }
            else if (lbltotalread.Text == "24")
            {
                if (lblCounts.Text.Trim() == lbltotalread.Text.Trim())
                {
                    //MessageBox.Show("Qty Needed Match Ready TO Save <3");
                    ReadyforPreparation();
                    BtnSave.Visible = true;
                    row25();

                    return;
                }
                else
                {
                    col25();
                    txt25.Focus();
                    txt25.Select();
                }
            }
            else if (lbltotalread.Text == "25")
            {
                if (lblCounts.Text.Trim() == lbltotalread.Text.Trim())
                {
                    //MessageBox.Show("Qty Needed Match Ready TO Save <3");
                    ReadyforPreparation();
                    BtnSave.Visible = true;

                    return;
                }
                else
                {
                    //col18();
                    //txt18.Focus();
                    //txt18.Select();
                }
            }
            else
            {

            }

        }
        private void gerard1_Click(object sender, EventArgs e)
        {

            //start
            dSet.Clear();
            //dSet = objStorProc.rdf_sp_prod_schedules(0, txt1.Text, "", "", "", "", "", "", "existsornot");
            dSet = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text, txtmainfeedcode.Text, label24.Text, "", "", "", "", "", "", "", txt1.Text, "", "", "", "", "", "", "existsornot");

            if (dSet.Tables[0].Rows.Count > 0)
            {
                //MessageBox.Show("NOT RECOGNISE", "Offense", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //cboFeedCode.Focus();
                RepackIDExists();
                txt1.Text = "";
                txt1.Focus();
                return;
            }
            else
            {
                //FeedCodeNotExists();

            }
           




            if (dgv1stView.Rows.Count >= 1)
            {
                int i = dgv1stView.CurrentRow.Index + 1;
                if (i >= -1 && i < dgv1stView.Rows.Count)



                    if (txt1.Text.Trim() == string.Empty)
                    {

                        BarcodeNotFound();//4/18/2020
                        //MessageBox.Show("Part1", "Barcode Input Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt1.Select();
                        txt1.Focus();
                        txt1.BackColor = Color.Yellow;


                        return;
                    }
                    else
                    {
                        String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
                        //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=hr_bak;Integrated Security=SSPI";
                        SqlConnection sql_con = new SqlConnection(connetionString);

                        cmd = new SqlCommand("SELECT repack_id FROM [dbo].[rdf_repackin_entry]  WHERE repack_id=" + txt1.Text + "", sql_con);

                        SqlDataAdapter daks = new SqlDataAdapter(cmd);

                        daks.Fill(ds);
                        int ia = ds.Tables[0].Rows.Count;
                        if (ia > 0)
                        {
                            //MessageBox.Show("The Formula" + txt1.Text + "Already Exists !");

                            search();
                            txtcode1.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                            txttotalrepack1.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                            txt1.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();


                          




                            if (txtitemcodeactive.Text.Trim() == txtcode1.Text.Trim())
                            {
                                //MessageBox.Show("Proceed Match Code");

                            }
                            else
                            {
                                //MessageBox.Show("Item Code Not Match!, Choose the exactly item Thanks God Bless:]");
                                ItemCodeNotMatched();
                                txt1.Text = "";
                                txt1.Focus();
                                txt1.Text = "";
                                return;

                            }



                            if (txttotalrepack1.Text.Trim() == txtsumtotalactive.Text.Trim())
                            {
                                //MessageBox.Show("Qty Needed Match <3");

                            }
                            else
                            {
                                //MessageBox.Show("Item Quantity Not Match IN Our Needed!, Choose the exactly item Quantity Thanks! ");
                                ItemCodeValueNotmacthed();
                                txt1.Text = "";
                                txt1.Focus();
                                return;
                            }



                            txt1.BackColor = Color.LightGreen;
                            pictureBox1.Visible = true;
                            groupBoxpack.Visible = true;
                            button1.Text = "Validated";
                            //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                            txt2.Focus();
                            txt2.Select();
                            SuccessFullyValidated();
                            dgv1stView.CurrentCell = dgv1stView.Rows[i].Cells[0];

                            ds.Clear();







                            //return;
                        }
                        else
                        {
                            RepackIdNotExists();//4/18/2020
                            //MessageBox.Show("The Raw Material Repack" + txt1.Text + "Not Exists !!");
                            txt1.BackColor = Color.Yellow;
                            txt1.Text = "";
                            txt1.Focus();
                            return;
                            //return; // ang gulo ntyo mga bugok
                        }





                        //pictureBox1.Visible = true;
                        //button1.Text = "Validated";
                        //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                        //txt2.Focus();
                        //txt2.Select();
                        //dgv1stView.CurrentCell = dgv1stView.Rows[i].Cells[0];





                        if (txt2.Text.Trim() == string.Empty)
                        {
                            lbltotalread.Text = "1";

                            Dochecking();
                            txt1.Enabled = false;
                            button1.Enabled = false;


                            txt1.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                            txtcode1.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                            txttotalrepack1.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                            txtsumtotal2.Text = dgv1stView.CurrentRow.Cells["quantity1"].Value.ToString();

                            txtitemcode2.Text = dgv1stView.CurrentRow.Cells["item_code"].Value.ToString();
                            txtdescription2.Text = dgv1stView.CurrentRow.Cells["rp_description"].Value.ToString();
                            txtbatch2.Text = dgv1stView.CurrentRow.Cells["p_nobatch"].Value.ToString();
                            txtqty2.Text = dgv1stView.CurrentRow.Cells["quantity"].Value.ToString();

                            return;
                        }





                        else
                        {
                            search();
                            txtcode1.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                            txttotalrepack1.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                            txt1.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                            txt23.Focus();
                        }

                    }

                else
                {
                    //MessageBox.Show("LIMIT Exceed at 1");
                    LimitExceeded();
                    //gerard singian



                    if (txt1.Text.Trim() == string.Empty)
                    {

                        MessageBox.Show("Part1", "Barcode Input Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt1.Select();
                        txt1.Focus();
                        txt1.BackColor = Color.Yellow;


                        return;
                    }
                    else
                    {
                        String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
                        //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=hr_bak;Integrated Security=SSPI";
                        SqlConnection sql_con = new SqlConnection(connetionString);

                        cmd = new SqlCommand("SELECT repack_id FROM [dbo].[rdf_repackin_entry]  WHERE repack_id=" + txt1.Text + "", sql_con);

                        SqlDataAdapter daks = new SqlDataAdapter(cmd);

                        daks.Fill(ds);
                        int ia = ds.Tables[0].Rows.Count;
                        if (ia > 0)
                        {
                            //MessageBox.Show("The Formula" + txt1.Text + "Already Exists !");

                            search();
                            txtcode1.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                            txttotalrepack1.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                            txt1.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();

                            if (txtitemcodeactive.Text.Trim() == txtcode1.Text.Trim())
                            {
                                //MessageBox.Show("Proceed Match Code");

                            }
                            else
                            {
                                MessageBox.Show("Item Code Not Match!, Choose the exactly item Thanks God Bless:]");
                                return;
                            }



                            if (txttotalrepack1.Text.Trim() == txtqtyactive.Text.Trim())
                            {
                                //MessageBox.Show("Qty Needed Match <3");

                            }
                            else
                            {
                                MessageBox.Show("Item Quantity Not Match IN Our Needed!, Choose the exactly item Quantity Thanks! ");
                                txt1.Text = "";
                                return;
                            }



                            txt1.BackColor = Color.LightGreen;
                            pictureBox1.Visible = true;
                            groupBoxpack.Visible = true;
                            button1.Text = "Validated";
                            //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                            txt2.Focus();
                            txt2.Select();
                            //dgv1stView.CurrentCell = dgv1stView.Rows[i].Cells[0];
                            ds.Clear();







                            //return;
                        }
                        else
                        {
                            MessageBox.Show("The Raw Material Repack" + txt1.Text + "Not Exists !!");
                            txt1.BackColor = Color.Yellow;
                            txt1.Text = "";
                            return;
                            //return; // ang gulo ntyo mga bugok
                        }





                        //pictureBox1.Visible = true;
                        //button1.Text = "Validated";
                        //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                        //txt2.Focus();
                        //txt2.Select();
                        //dgv1stView.CurrentCell = dgv1stView.Rows[i].Cells[0];





                        if (txt2.Text.Trim() == string.Empty)
                        {
                            lbltotalread.Text = "1";
                            Dochecking();
                            txt1.Enabled = false;
                            button1.Enabled = false;


                            txt1.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                            txtcode1.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                            txttotalrepack1.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                            txtitemcode2.Text = dgv1stView.CurrentRow.Cells["item_code"].Value.ToString();
                            txtdescription2.Text = dgv1stView.CurrentRow.Cells["rp_description"].Value.ToString();
                            txtbatch2.Text = dgv1stView.CurrentRow.Cells["p_nobatch"].Value.ToString();
                            txtqty2.Text = dgv1stView.CurrentRow.Cells["quantity"].Value.ToString();

                            return;
                        }





                        else
                        {
                            search();
                            txtcode1.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                            txttotalrepack1.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                            txt1.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                            txt23.Focus();
                        }

                    }


                }

            }
        }

        private void txt2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gerard2_Click(sender, e);
            }
        }

        private void txt3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gerard3_Click(sender, e);
            }
        }

        private void txt4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gerard4_Click(sender, e);
            }
        }

        private void gerard2_Click(object sender, EventArgs e)
        {

            //start
            dSet.Clear();

            dSet = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text, txtmainfeedcode.Text, label24.Text, "", "", "", "", "", "", "", txt2.Text, "", "", "", "", "", "", "existsornot");

            if (dSet.Tables[0].Rows.Count > 0)
            {

                RepackIDExists();
                txt2.Text = "";
                txt2.Focus();
                return;
            }
            else
            {
                //FeedCodeNotExists();

            }



            if (dgv1stView.Rows.Count >= 1)
            {
                int i = dgv1stView.CurrentRow.Index + 1;
                if (i >= -1 && i < dgv1stView.Rows.Count)



                    if (txt2.Text.Trim() == string.Empty)
                    {

                        BarcodeNotFound();
                        //MessageBox.Show("Part2", "Barcode Input Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt2.Select();
                        txt2.Focus();
                        txt2.BackColor = Color.Yellow;


                        return;
                    }
                    else
                    {
                        String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
                        //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=hr_bak;Integrated Security=SSPI";
                        SqlConnection sql_con = new SqlConnection(connetionString);

                        cmd = new SqlCommand("SELECT repack_id FROM [dbo].[rdf_repackin_entry]  WHERE repack_id=" + txt2.Text + "", sql_con);

                        SqlDataAdapter daks = new SqlDataAdapter(cmd);

                        daks.Fill(ds);
                        int ia = ds.Tables[0].Rows.Count;
                        if (ia > 0)
                        {
                            //MessageBox.Show("The Formula" + txt2.Text + "Already Exists !");

                            search2();
                            txtcode2.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                            txttotalrepack2.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                            txt2.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();



                            if (txtitemcode2.Text.Trim() == txtcode2.Text.Trim())
                            {
                                //MessageBox.Show("Proceed Match Code");

                            }
                            else
                            {
                                ItemCodeNotMatched();
                                //MessageBox.Show("Item Code Not Match!, Choose the exactly item Thanks God Bless:]");
                                txt2.Text = "";
                                txt2.Focus();
                                return;
                            }


                            //if (txttotalrepack2.Text.Trim() == txtqty2.Text.Trim())
                            if (txttotalrepack2.Text.Trim() == txtsumtotal2.Text.Trim())
                            {
                                //MessageBox.Show("Qty Needed Match <3");

                            }
                            else
                            {
                                ItemCodeValueNotmacthed();
                                txt2.Text = "";
                                txt2.Focus();
                                //MessageBox.Show("Item Quantity Not Match IN Our Needed!, Choose the exactly item Quantity Thanks! ");
                                return;
                            }



                            txt2.BackColor = Color.LightGreen;
                            pictureBox2.Visible = true;
                            button2.Text = "Validated";
                            //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                            txt3.Focus();
                            txt3.Select();
                            SuccessFullyValidated();
                            dgv1stView.CurrentCell = dgv1stView.Rows[i].Cells[0];
                            ;
                            ds.Clear();







                            //return;
                        }
                        else
                        {
                            RepackIdNotExists();
                            //MessageBox.Show("The Raw Material Repack" + txt1.Text + "Not Exists !!");
                            txt2.Text = "";
                            txt2.Focus();
                            txt2.BackColor = Color.Yellow;
                            return;
                            //return; // ang gulo ntyo mga bugok
                        }





                        //pictureBox1.Visible = true;
                        //button1.Text = "Validated";
                        //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                        //txt2.Focus();
                        //txt2.Select();
                        //dgv1stView.CurrentCell = dgv1stView.Rows[i].Cells[0];





                        if (txt3.Text.Trim() == string.Empty)
                        {
                            lbltotalread.Text = "2";
                            //SuccessFullyValidated();
                            Dochecking();
                            txt2.Enabled = false;
                            button2.Enabled = false;



                            //txt3.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                            //txtcode3.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                            //txttotalrepack3.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();
                            txtsumtotal3.Text = dgv1stView.CurrentRow.Cells["quantity1"].Value.ToString();
                            txtitemcode3.Text = dgv1stView.CurrentRow.Cells["item_code"].Value.ToString();
                            txtdescription3.Text = dgv1stView.CurrentRow.Cells["rp_description"].Value.ToString();
                            txtbatch3.Text = dgv1stView.CurrentRow.Cells["p_nobatch"].Value.ToString();
                            txtqty3.Text = dgv1stView.CurrentRow.Cells["quantity"].Value.ToString();

                            return;
                        }



                        else
                        {
                            search2();
                            txtcode2.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                            txttotalrepack2.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                            txt2.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                            txt3.Focus();
                        }


                    }

                else
                {
                    LimitExceeded();
                    //MessageBox.Show("LIMIT Exceed at 2");


                    if (txt2.Text.Trim() == string.Empty)
                    {

                        MessageBox.Show("Part2", "Barcode Input Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt2.Select();
                        txt2.Focus();
                        txt2.BackColor = Color.Yellow;


                        return;
                    }
                    else
                    {
                        String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
                        //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=hr_bak;Integrated Security=SSPI";
                        SqlConnection sql_con = new SqlConnection(connetionString);

                        cmd = new SqlCommand("SELECT repack_id FROM [dbo].[rdf_repackin_entry]  WHERE repack_id=" + txt2.Text + "", sql_con);

                        SqlDataAdapter daks = new SqlDataAdapter(cmd);

                        daks.Fill(ds);
                        int ia = ds.Tables[0].Rows.Count;
                        if (ia > 0)
                        {
                            //MessageBox.Show("The Formula" + txt2.Text + "Already Exists !");

                            search2();
                            txtcode2.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                            txttotalrepack2.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                            txt2.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();

                            if (txtitemcode2.Text.Trim() == txtcode2.Text.Trim())
                            {
                                //MessageBox.Show("Proceed Match Code");

                            }
                            else
                            {
                                MessageBox.Show("Item Code Not Match!, Choose the exactly item Thanks God Bless:]");
                                return;
                            }



                            if (txttotalrepack2.Text.Trim() == txtqty2.Text.Trim())
                            {
                                //MessageBox.Show("Qty Needed Match <3");

                            }
                            else
                            {
                                MessageBox.Show("Item Quantity Not Match IN Our Needed!, Choose the exactly item Quantity Thanks! ");
                                return;
                            }



                            txt2.BackColor = Color.LightGreen;
                            pictureBox2.Visible = true;
                            button2.Text = "Validated";
                            //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                            txt3.Focus();
                            txt3.Select();
                            //dgv1stView.CurrentCell = dgv1stView.Rows[i].Cells[0];
                            ds.Clear();







                            //return;
                        }
                        else
                        {
                            MessageBox.Show("The Raw Material Repack" + txt1.Text + "Not Exists !!");
                            txt2.Text = "";
                            txt2.BackColor = Color.Yellow;
                            return;
                            //return; // ang gulo ntyo mga bugok
                        }





                        //pictureBox1.Visible = true;
                        //button1.Text = "Validated";
                        //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                        //txt2.Focus();
                        //txt2.Select();
                        //dgv1stView.CurrentCell = dgv1stView.Rows[i].Cells[0];





                        if (txt3.Text.Trim() == string.Empty)
                        {
                            lbltotalread.Text = "2";
                            SuccessFullyValidated();
                            Dochecking();
                            txt2.Enabled = false;
                            button2.Enabled = false;



                            //txt3.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                            //txtcode3.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                            //txttotalrepack3.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                            txtitemcode3.Text = dgv1stView.CurrentRow.Cells["item_code"].Value.ToString();
                            txtdescription3.Text = dgv1stView.CurrentRow.Cells["rp_description"].Value.ToString();
                            txtbatch3.Text = dgv1stView.CurrentRow.Cells["p_nobatch"].Value.ToString();
                            txtqty3.Text = dgv1stView.CurrentRow.Cells["quantity"].Value.ToString();

                            return;
                        }



                        else
                        {
                            search2();
                            txtcode2.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                            txttotalrepack2.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                            txt2.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                            txt3.Focus();
                        }


                    }


                }



            }


        }

        private void gerard3_Click(object sender, EventArgs e)
        {
            //start
            dSet.Clear();

            dSet = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text, txtmainfeedcode.Text, label24.Text, "", "", "", "", "", "", "", txt3.Text, "", "", "", "", "", "", "existsornot");

            if (dSet.Tables[0].Rows.Count > 0)
            {

                RepackIDExists();
                txt3.Text = "";
                txt3.Focus();
                return;
            }
            else
            {
                //FeedCodeNotExists();

            }






            if (dgv1stView.Rows.Count >= 1)
            {
                int i = dgv1stView.CurrentRow.Index + 1;
                if (i >= -1 && i < dgv1stView.Rows.Count)



                    if (txt3.Text.Trim() == string.Empty)
                    {
                        BarcodeNotFound();
                        //MessageBox.Show("Part5", "Barcode Input Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt3.Select();
                        txt3.Focus();
                        txt3.BackColor = Color.Yellow;


                        return;
                    }
                    else
                    {
                        String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
                        //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=hr_bak;Integrated Security=SSPI";
                        SqlConnection sql_con = new SqlConnection(connetionString);

                        cmd = new SqlCommand("SELECT repack_id FROM [dbo].[rdf_repackin_entry]  WHERE repack_id=" + txt3.Text + "", sql_con);

                        SqlDataAdapter daks = new SqlDataAdapter(cmd);

                        daks.Fill(ds);
                        int ia = ds.Tables[0].Rows.Count;
                        if (ia > 0)
                        {
                            //MessageBox.Show("The Formula" + txt4.Text + "Already Exists !");

                            search3();
                            txtcode3.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                            txttotalrepack3.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                            txt3.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();

                            if (txtitemcode3.Text.Trim() == txtcode3.Text.Trim())
                            {
                                //MessageBox.Show("Proceed Match Code");

                            }
                            else
                            {
                                ItemCodeNotMatched();
                                txt3.Text = "";
                                txt3.Focus();
                                //MessageBox.Show("Item Code Not Match!, Choose the exactly item Thanks God Bless:]");
                                return;
                            }



                            //if (txttotalrepack5.Text.Trim() == txtqty5.Text.Trim())
                            if (txttotalrepack3.Text.Trim() == txtsumtotal3.Text.Trim())
                            {
                                //MessageBox.Show("Qty Needed Match <3");

                            }
                            else
                            {
                                ItemCodeValueNotmacthed();
                                txt3.Text = "";
                                txt3.Focus();
                                //MessageBox.Show("Item Quantity Not Match IN Our Needed!, Choose the exactly item Quantity Thanks! ");
                                return;
                            }



                            txt3.BackColor = Color.LightGreen;
                            pictureBox3.Visible = true;
                            button3.Text = "Validated";
                            //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                            txt4.Focus();
                            txt4.Select();
                            SuccessFullyValidated();
                            dgv1stView.CurrentCell = dgv1stView.Rows[i].Cells[0];
                            //SuccessFullyValidated();
                            ds.Clear();







                            //return;
                        }
                        else
                        {
                            RepackIdNotExists();
                            //MessageBox.Show("The Raw Material Repack" + txt5.Text + "Not Exists !!");
                            txt3.Text = "";
                            txt3.Focus();
                            txt3.BackColor = Color.Yellow;
                            return;
                            //return; // ang gulo ntyo mga bugok
                        }











                        if (txt4.Text.Trim() == string.Empty)
                        {
                            lbltotalread.Text = "3";

                            Dochecking();
                            txt4.Focus();
                            txt3.Enabled = false;
                            button5.Enabled = false;


                            //txt3.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                            //txtcode3.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                            //txttotalrepack3.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();
                            txtsumtotal4.Text = dgv1stView.CurrentRow.Cells["quantity1"].Value.ToString();
                            txtitemcode4.Text = dgv1stView.CurrentRow.Cells["item_code"].Value.ToString();
                            txtdescription4.Text = dgv1stView.CurrentRow.Cells["rp_description"].Value.ToString();
                            txtbatch4.Text = dgv1stView.CurrentRow.Cells["p_nobatch"].Value.ToString();
                            txtqty4.Text = dgv1stView.CurrentRow.Cells["quantity"].Value.ToString();

                            return;
                        }



                        else
                        {
                            search3();
                            txtcode3.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                            txttotalrepack3.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                            txt3.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                            txt4.Focus();
                        }
                    }

                else
                {

                    //MessageBox.Show("LIMIT Exceed at 5");
                    LimitExceeded();


                    if (txt3.Text.Trim() == string.Empty)
                    {

                        MessageBox.Show("Part5", "Barcode Input Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt3.Select();
                        txt3.Focus();
                        txt3.BackColor = Color.Yellow;


                        return;
                    }
                    else
                    {
                        String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
                        //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=hr_bak;Integrated Security=SSPI";
                        SqlConnection sql_con = new SqlConnection(connetionString);

                        cmd = new SqlCommand("SELECT repack_id FROM [dbo].[rdf_repackin_entry]  WHERE repack_id=" + txt3.Text + "", sql_con);

                        SqlDataAdapter daks = new SqlDataAdapter(cmd);

                        daks.Fill(ds);
                        int ia = ds.Tables[0].Rows.Count;
                        if (ia > 0)
                        {
                            //MessageBox.Show("The Formula" + txt4.Text + "Already Exists !");

                            search3();
                            txtcode3.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                            txttotalrepack3.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                            txt3.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();

                            if (txtitemcode3.Text.Trim() == txtcode3.Text.Trim())
                            {
                                //MessageBox.Show("Proceed Match Code");

                            }
                            else
                            {
                                MessageBox.Show("Item Code Not Match!, Choose the exactly item Thanks God Bless:]");
                                return;
                            }



                            //if (txttotalrepack5.Text.Trim() == txtqty5.Text.Trim())
                            if (txttotalrepack3.Text.Trim() == txtsumtotal3.Text.Trim())
                            {
                                //MessageBox.Show("Qty Needed Match <3");

                            }
                            else
                            {
                                MessageBox.Show("Item Quantity Not Match IN Our Needed!, Choose the exactly item Quantity Thanks! ");
                                return;
                            }



                            txt3.BackColor = Color.LightGreen;
                            pictureBox3.Visible = true;
                            button3.Text = "Validated";
                            //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                            txt4.Focus();
                            txt4.Select();
                            //dgv1stView.CurrentCell = dgv1stView.Rows[i].Cells[0];
                            ds.Clear();







                            //return;
                        }
                        else
                        {
                            MessageBox.Show("The Raw Material Repack" + txt3.Text + "Not Exists !!");
                            txt3.Text = "";
                            txt3.BackColor = Color.Yellow;
                            return;
                            //return; // ang gulo ntyo mga bugok
                        }





                        //pictureBox1.Visible = true;
                        //button1.Text = "Validated";
                        //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                        //txt2.Focus();
                        //txt2.Select();
                        //dgv1stView.CurrentCell = dgv1stView.Rows[i].Cells[0];





                        if (txt4.Text.Trim() == string.Empty)
                        {
                            lbltotalread.Text = "3";
                            SuccessFullyValidated();
                            Dochecking();
                            txt4.Focus();
                            txt3.Enabled = false;
                            button3.Enabled = false;


                            //txt3.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                            //txtcode3.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                            //txttotalrepack3.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                            txtitemcode4.Text = dgv1stView.CurrentRow.Cells["item_code"].Value.ToString();
                            txtdescription4.Text = dgv1stView.CurrentRow.Cells["rp_description"].Value.ToString();
                            txtbatch4.Text = dgv1stView.CurrentRow.Cells["p_nobatch"].Value.ToString();
                            txtqty4.Text = dgv1stView.CurrentRow.Cells["quantity"].Value.ToString();

                            return;
                        }



                        else
                        {
                            search3();
                            txtcode3.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                            txttotalrepack3.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                            txt3.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                            txt4.Focus();
                        }
                    }

                }

            }

        }

        private void gerard4_Click(object sender, EventArgs e)
        {
            //start
            dSet.Clear();

            dSet = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text, txtmainfeedcode.Text, label24.Text, "", "", "", "", "", "", "", txt4.Text, "", "", "", "", "", "", "existsornot");

            if (dSet.Tables[0].Rows.Count > 0)
            {

                RepackIDExists();
                txt4.Text = "";
                txt4.Focus();
                return;
            }
            else
            {


            }







            if (dgv1stView.Rows.Count >= 1)
            {
                int i = dgv1stView.CurrentRow.Index + 1;
                if (i >= -1 && i < dgv1stView.Rows.Count)



                    if (txt4.Text.Trim() == string.Empty)
                    {
                        BarcodeNotFound();
                        //MessageBox.Show("Part4", "Barcode Input Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt4.Select();
                        txt4.Focus();
                        txt4.BackColor = Color.Yellow;


                        return;
                    }
                    else
                    {
                        String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
                        //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=hr_bak;Integrated Security=SSPI";
                        SqlConnection sql_con = new SqlConnection(connetionString);

                        cmd = new SqlCommand("SELECT repack_id FROM [dbo].[rdf_repackin_entry]  WHERE repack_id=" + txt4.Text + "", sql_con);

                        SqlDataAdapter daks = new SqlDataAdapter(cmd);

                        daks.Fill(ds);
                        int ia = ds.Tables[0].Rows.Count;
                        if (ia > 0)
                        {
                            //MessageBox.Show("The Formula" + txt4.Text + "Already Exists !");

                            search4();
                            txtcode4.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                            txttotalrepack4.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                            txt4.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();

                            if (txtitemcode4.Text.Trim() == txtcode4.Text.Trim())
                            {
                                //MessageBox.Show("Proceed Match Code");

                            }
                            else
                            {
                                ItemCodeNotMatched();
                                txt4.Text = "";
                                txt4.Focus();
                                //MessageBox.Show("Item Code Not Match!, Choose the exactly item Thanks God Bless:]");
                                return;
                            }



                            //if (txttotalrepack4.Text.Trim() == txtqty4.Text.Trim())
                            if (txttotalrepack4.Text.Trim() == txtsumtotal4.Text.Trim())
                            {
                                //MessageBox.Show("Qty Needed Match <3");

                            }
                            else
                            {
                                ItemCodeValueNotmacthed();
                                txt4.Text = "";
                                txt4.Focus();
                                //MessageBox.Show("Item Quantity Not Match IN Our Needed!, Choose the exactly item Quantity Thanks! ");
                                return;
                            }



                            txt4.BackColor = Color.LightGreen;
                            pictureBox4.Visible = true;
                            button4.Text = "Validated";
                            //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                            txt5.Focus();
                            txt5.Select();
                            SuccessFullyValidated();
                            dgv1stView.CurrentCell = dgv1stView.Rows[i].Cells[0];
                            ds.Clear();







                            //return;
                        }
                        else
                        {
                            RepackIdNotExists();
                            //MessageBox.Show("The Raw Material Repack" + txt4.Text + "Not Exists !!");
                            txt4.Text = "";
                            txt4.Focus();
                            txt4.BackColor = Color.Yellow;
                            return;
                            //return; // ang gulo ntyo mga bugok
                        }





                        //pictureBox1.Visible = true;
                        //button1.Text = "Validated";
                        //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                        //txt2.Focus();
                        //txt2.Select();
                        //dgv1stView.CurrentCell = dgv1stView.Rows[i].Cells[0];





                        if (txt5.Text.Trim() == string.Empty)
                        {
                            lbltotalread.Text = "4";

                            Dochecking();
                            txt4.Enabled = false;
                            button4.Enabled = false;

                            //txt3.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                            //txtcode3.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                            //txttotalrepack3.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();
                            txtsumtotal5.Text = dgv1stView.CurrentRow.Cells["quantity1"].Value.ToString();
                            txtitemcode5.Text = dgv1stView.CurrentRow.Cells["item_code"].Value.ToString();
                            txtdescription5.Text = dgv1stView.CurrentRow.Cells["rp_description"].Value.ToString();
                            txtbatch5.Text = dgv1stView.CurrentRow.Cells["p_nobatch"].Value.ToString();
                            txtqty5.Text = dgv1stView.CurrentRow.Cells["quantity"].Value.ToString();

                            return;
                        }




                        else
                        {
                            search4();
                            txtcode4.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                            txttotalrepack4.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                            txt4.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                            txt5.Focus();
                        }
                    }

                else
                {
                    //MessageBox.Show("LIMIT Exceed at 4");

                    LimitExceeded();

                    if (txt4.Text.Trim() == string.Empty)
                    {

                        MessageBox.Show("Part4", "Barcode Input Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt4.Select();
                        txt4.Focus();
                        txt4.BackColor = Color.Yellow;


                        return;
                    }
                    else
                    {

                        //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=hr_bak;Integrated Security=SSPI";
                        String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
                        SqlConnection sql_con = new SqlConnection(connetionString);

                        cmd = new SqlCommand("SELECT repack_id FROM [dbo].[rdf_repackin_entry]  WHERE repack_id=" + txt4.Text + "", sql_con);

                        SqlDataAdapter daks = new SqlDataAdapter(cmd);

                        daks.Fill(ds);
                        int ia = ds.Tables[0].Rows.Count;
                        if (ia > 0)
                        {
                            //MessageBox.Show("The Formula" + txt4.Text + "Already Exists !");

                            search4();
                            txtcode4.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                            txttotalrepack4.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                            txt4.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();

                            if (txtitemcode4.Text.Trim() == txtcode4.Text.Trim())
                            {
                                //MessageBox.Show("Proceed Match Code");

                            }
                            else
                            {
                                MessageBox.Show("Item Code Not Match!, Choose the exactly item Thanks God Bless:]");
                                return;
                            }



                            //if (txttotalrepack4.Text.Trim() == txtqty4.Text.Trim())
                            if (txttotalrepack4.Text.Trim() == txtsumtotal4.Text.Trim())
                            {
                                //MessageBox.Show("Qty Needed Match <3");

                            }
                            else
                            {
                                MessageBox.Show("Item Quantity Not Match IN Our Needed!, Choose the exactly item Quantity Thanks! ");
                                return;
                            }



                            txt4.BackColor = Color.LightGreen;
                            pictureBox4.Visible = true;
                            button4.Text = "Validated";
                            //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                            txt5.Focus();
                            txt5.Select();
                            //dgv1stView.CurrentCell = dgv1stView.Rows[i].Cells[0];
                            ds.Clear();







                            //return;
                        }
                        else
                        {
                            MessageBox.Show("The Raw Material Repack" + txt4.Text + "Not Exists !!");
                            txt4.Text = "";
                            txt4.BackColor = Color.Yellow;
                            return;
                            //return; // ang gulo ntyo mga bugok
                        }





                        //pictureBox1.Visible = true;
                        //button1.Text = "Validated";
                        //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                        //txt2.Focus();
                        //txt2.Select();
                        //dgv1stView.CurrentCell = dgv1stView.Rows[i].Cells[0];





                        if (txt5.Text.Trim() == string.Empty)
                        {
                            lbltotalread.Text = "4";
                            SuccessFullyValidated();
                            Dochecking();
                            txt4.Enabled = false;
                            button4.Enabled = false;

                            //txt3.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                            //txtcode3.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                            //txttotalrepack3.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                            txtitemcode5.Text = dgv1stView.CurrentRow.Cells["item_code"].Value.ToString();
                            txtdescription5.Text = dgv1stView.CurrentRow.Cells["rp_description"].Value.ToString();
                            txtbatch5.Text = dgv1stView.CurrentRow.Cells["p_nobatch"].Value.ToString();
                            txtqty5.Text = dgv1stView.CurrentRow.Cells["quantity"].Value.ToString();

                            return;
                        }




                        else
                        {
                            search4();
                            txtcode4.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                            txttotalrepack4.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                            txt4.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                            txt5.Focus();
                        }
                    }


                }

            }
        }

        private void dgv1stView_CurrentCellChanged(object sender, EventArgs e)
        {
            showPreparation();
        }


        void showPreparation()
        {

            if (dgv1stView.RowCount > 0)
            {
                if (dgv1stView.CurrentRow != null)
                {
                    if (dgv1stView.CurrentRow.Cells["prod_id"].Value != null)
                    {
                        p_id = Convert.ToInt32(dgv1stView.CurrentRow.Cells["prod_id"].Value);

                        txtitemcode1.Text = dgv1stView.CurrentRow.Cells["item_codedb"].Value.ToString();
                      txtItemCode.Text = dgv1stView.CurrentRow.Cells["item_codedb"].Value.ToString();
                        txtitemcodeoriginal.Text = dgv1stView.CurrentRow.Cells["item_codedb"].Value.ToString();
                        txtdescription1.Text = dgv1stView.CurrentRow.Cells["rp_descriptiondb"].Value.ToString();
                        txtbatch1.Text = dgv1stView.CurrentRow.Cells["p_nobatchdb"].Value.ToString();
                        txtqty1.Text = dgv1stView.CurrentRow.Cells["quantity"].Value.ToString();
                        txtdescriptionfinal.Text = dgv1stView.CurrentRow.Cells["rp_descriptiondb"].Value.ToString();
                        txtqtyneededx2.Text = dgv1stView.CurrentRow.Cells["quantity1"].Value.ToString();
                        label24.Text = dgv1stView.CurrentRow.Cells["rp_feed_typedb"].Value.ToString();
                        txtprodid.Text = dgv1stView.CurrentRow.Cells["prod_id"].Value.ToString();
        txtrecipe.Text = dgv1stView.CurrentRow.Cells["recipe_id2"].Value.ToString();


                        //txtrecommendedsearch.Text = dgvMaster.CurrentRow.Cells["item_code"].Value.ToString();
                        //txtqtyoverall.Text = dgvMaster.CurrentRow.Cells["qty_repack_available"].Value.ToString();
                        //txtmainstocks.Text = dgvMaster.CurrentRow.Cells["total_quantity_raw"].Value.ToString();

                        //cboCategor.Text = dgvMaster.CurrentRow.Cells["item_description"].Value.ToString();






                        //wala muna this


                    }

                }
            }

        }

        private void dgvrepackdb_CurrentCellChanged(object sender, EventArgs e)
        {
            showRepackingChanged();
        }
        void showRepackingChanged()
        {

            if (dgvrepackdb.RowCount > 0)
            {
                if (dgvrepackdb.CurrentRow != null)
                {
                    if (dgvrepackdb.CurrentRow.Cells["repack_id"].Value != null)
                    {
                        p_id = Convert.ToInt32(dgvrepackdb.CurrentRow.Cells["repack_id"].Value);

                        //txt1.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString(); wla muna
                        txtcodeuna.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                        txtqtyuna.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();


                        txtFeedCodeRepack.Text = dgvrepackdb.CurrentRow.Cells["rp_feed_code"].Value.ToString();

                        //txtrecommendedsearch.Text = dgvMaster.CurrentRow.Cells["item_code"].Value.ToString();
                        //txtqtyoverall.Text = dgvMaster.CurrentRow.Cells["qty_repack_available"].Value.ToString();
                        //txtmainstocks.Text = dgvMaster.CurrentRow.Cells["total_quantity_raw"].Value.ToString();

                        //cboCategor.Text = dgvMaster.CurrentRow.Cells["item_description"].Value.ToString();






                        //wala muna this


                    }

                }
            }

        }

        private void txttotalrepack2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbatchtwo_TextChanged(object sender, EventArgs e)
        {
            try
            {


                txtsumtotal2.Text = (float.Parse(txtqty2.Text) * 1).ToString("#,0.000");
            }
            catch (Exception)
            {


            }
        }

        private void bunifuStopPreparation_Click(object sender, EventArgs e)
        {
            metroButton1_Click(sender, e);
        }
        void HideGifters()
        {
            txt2.Text = "";
            txt3.Text = "";
            txt4.Text = "";
            txt5.Text = "";
            txt6.Text = "";
            txt7.Text = "";
            txt8.Text = "";
            txt9.Text = "";
            txt10.Text = "";
            txt11.Text = "";
            txt12.Text = "";
            txt13.Text = "";
            txt14.Text = "";
            txt15.Text = "";
            txt16.Text = "";
            txt17.Text = "";
            txt18.Text = "";
            txt19.Text = "";
            txt20.Text = "";
            txt21.Text = "";
            txt22.Text = "";
            txt23.Text = "";
            txt24.Text = "";
            txt25.Text = "";

            //2
            txtitemcode2.Visible = false;
            txtdescription2.Visible = false;
            txtbatch2.Visible = false;
            txtbatchtwo.Visible = false;
            txtsumtotal2.Visible = false;
            txtcode2.Visible = false;
            txttotalrepack2.Visible = false;
            txtqty2.Visible = false;
            txt2.Visible = false;
            lblnum2.Visible = false;
            txt2.Enabled = true;
            txt2.BackColor = Color.White;
            b2.Visible = false;
            //3
            txtitemcode3.Visible = false;
            txtdescription3.Visible = false;
            txtbatch3.Visible = false;
            txtqtybatch3.Visible = false;
            txtsumtotal3.Visible = false;
            txtcode3.Visible = false;
            txttotalrepack3.Visible = false;
            txtqty3.Visible = false;
            txt3.Visible = false;
            lblnum3.Visible = false;
            txt3.Enabled = true;
            txt3.BackColor = Color.White;
            b3.Visible = false;
            //4
            txtitemcode4.Visible = false;
            txtdescription4.Visible = false;
            txtbatch4.Visible = false;
            txtqtybatch4.Visible = false;
            txtsumtotal4.Visible = false;
            txtcode4.Visible = false;
            txttotalrepack4.Visible = false;
            txtqty4.Visible = false;
            txt4.Visible = false;
            lblnum4.Visible = false;
            txt4.Enabled = true;
            txt4.BackColor = Color.White;
            b4.Visible = false;
            //5
            txtitemcode5.Visible = false;
            txtdescription5.Visible = false;
            txtbatch5.Visible = false;
            txtqtybatch5.Visible = false;
            txtsumtotal5.Visible = false;
            txtcode5.Visible = false;
            txttotalrepack5.Visible = false;
            txtqty5.Visible = false;
            txt5.Visible = false;
            lblnum5.Visible = false;
            txt5.Enabled = true;
            txt5.BackColor = Color.White;
            b5.Visible = false;
            //6
            txtitemcode6.Visible = false;
            txtdescription6.Visible = false;
            txtbatch6.Visible = false;
            txtqtybatch6.Visible = false;
            txtsumtotal6.Visible = false;
            txtcode6.Visible = false;
            txttotalrepack6.Visible = false;
            txtqty6.Visible = false;
            txt6.Visible = false;
            lblnum6.Visible = false;
            txt6.Enabled = true;
            txt6.BackColor = Color.White;
            b6.Visible = false;
            //7
            txtitemcode7.Visible = false;
            txtdescription7.Visible = false;
            txtbatch7.Visible = false;
            txtqtybatch7.Visible = false;
            txtsumtotal7.Visible = false;
            txtcode7.Visible = false;
            txttotalrepack7.Visible = false;
            txtqty7.Visible = false;
            txt7.Visible = false;
            lblnum7.Visible = false;
            txt7.Enabled = true;
            txt7.BackColor = Color.White;
            b7.Visible = false;
            //8
            txtitemcode8.Visible = false;
            txtdescription8.Visible = false;
            txtbatch8.Visible = false;
            txtqtybatch8.Visible = false;
            txtsumtotal8.Visible = false;
            txtcode8.Visible = false;
            txttotalrepack8.Visible = false;
            txtqty8.Visible = false;
            txt8.Visible = false;
            lblnum8.Visible = false;
            txt8.Enabled = true;
            txt8.BackColor = Color.White;
            b8.Visible = false;
            //9
            txtitemcode9.Visible = false;
            txtdescription9.Visible = false;
            txtbatch9.Visible = false;
            txtqtybatch9.Visible = false;
            txtsumtotal9.Visible = false;
            txtcode9.Visible = false;
            txttotalrepack9.Visible = false;
            txtqty9.Visible = false;
            txt9.Visible = false;
            lblnum9.Visible = false;
            txt9.Enabled = true;
            txt9.BackColor = Color.White;
            b9.Visible = false;
            //10
            txtitemcode10.Visible = false;
            txtdescription10.Visible = false;
            txtbatch10.Visible = false;
            txtqtybatch10.Visible = false;
            txtsumtotal10.Visible = false;
            txtcode10.Visible = false;
            txttotalrepack10.Visible = false;
            txtqty10.Visible = false;
            txt10.Visible = false;
            lblnum10.Visible = false;
            txt10.Enabled = true;
            txt10.BackColor = Color.White;
            b10.Visible = false;
            //11
            txtitemcode11.Visible = false;
            txtdescription11.Visible = false;
            txtbatch11.Visible = false;
            txtqtybatch11.Visible = false;
            txtsumtotal11.Visible = false;
            txtcode11.Visible = false;
            txttotalrepack11.Visible = false;
            txtqty11.Visible = false;
            txt11.Visible = false;
            lblnum11.Visible = false;
            txt11.Enabled = true;
            txt11.BackColor = Color.White;
            b11.Visible = false;
            //12
            txtitemcode12.Visible = false;
            txtdescription12.Visible = false;
            txtbatch12.Visible = false;
            txtqtybatch12.Visible = false;
            txtsumtotal12.Visible = false;
            txtcode12.Visible = false;
            txttotalrepack12.Visible = false;
            txtqty12.Visible = false;
            txt12.Visible = false;
            lblnum12.Visible = false;
            txt12.Enabled = true;
            txt12.BackColor = Color.White;
            b12.Visible = false;
            //13

            txtitemcode13.Visible = false;
            txtdescription13.Visible = false;
            txtbatch13.Visible = false;
            txtqtybatch13.Visible = false;
            txtsumtotal13.Visible = false;
            txtcode13.Visible = false;
            txttotalrepack13.Visible = false;
            txtqty13.Visible = false;
            txt13.Visible = false;
            lblnum13.Visible = false;
            txt13.Enabled = true;
            txt13.BackColor = Color.White;
            b13.Visible = false;
            //14
            txtitemcode14.Visible = false;
            txtdescription14.Visible = false;
            txtbatch14.Visible = false;
            txtqtybatch14.Visible = false;
            txtsumtotal14.Visible = false;
            txtcode14.Visible = false;
            txttotalrepack14.Visible = false;
            txtqty14.Visible = false;
            txt14.Visible = false;
            lblnum14.Visible = false;
            txt14.Enabled = true;
            txt14.BackColor = Color.White;
            b14.Visible = false;
            //15
            txtitemcode15.Visible = false;
            txtdescription15.Visible = false;
            txtbatch15.Visible = false;
            txtqtybatch15.Visible = false;
            txtsumtotal15.Visible = false;
            txtcode15.Visible = false;
            txttotalrepack15.Visible = false;
            txtqty15.Visible = false;
            txt15.Visible = false;
            lblnum15.Visible = false;
            txt15.Enabled = true;
            txt15.BackColor = Color.White;
            b15.Visible = false;
            calldisable();

            //16
            txtitemcode16.Visible = false;
            txtdescription16.Visible = false;
            txtbatch16.Visible = false;
            txtqtybatch16.Visible = false;
            txtsumtotal16.Visible = false;
            txtcode16.Visible = false;
            txttotalrepack16.Visible = false;
            txtqty16.Visible = false;
            txt16.Visible = false;
            lblnum16.Visible = false;
            txt16.Enabled = true;
            txt16.BackColor = Color.White;
            b16.Visible = false;
            //17
            txtitemcode17.Visible = false;
            txtdescription17.Visible = false;
            txtbatch17.Visible = false;
            txtqtybatch17.Visible = false;
            txtsumtotal17.Visible = false;
            txtcode17.Visible = false;
            txttotalrepack17.Visible = false;
            txtqty17.Visible = false;
            txt17.Visible = false;
            lblnum17.Visible = false;
            txt17.Enabled = true;
            txt17.BackColor = Color.White;
            b17.Visible = false;
            //18
            txtitemcode18.Visible = false;
            txtdescription18.Visible = false;
            txtbatch18.Visible = false;
            txtqtybatch18.Visible = false;
            txtsumtotal18.Visible = false;
            txtcode18.Visible = false;
            txttotalrepack18.Visible = false;
            txtqty18.Visible = false;
            txt18.Visible = false;
            lblnum18.Visible = false;
            txt18.Enabled = true;
            txt18.BackColor = Color.White;
            b18.Visible = false;
            //19
            txtitemcode19.Visible = false;
            txtdescription19.Visible = false;
            txtbatch19.Visible = false;
            txtqtybatch19.Visible = false;
            txtsumtotal19.Visible = false;
            txtcode19.Visible = false;
            txttotalrepack19.Visible = false;
            txtqty19.Visible = false;
            txt19.Visible = false;
            lblnum19.Visible = false;
            txt19.Enabled = true;
            txt19.BackColor = Color.White;
            b19.Visible = false;
            //20
            txtitemcode20.Visible = false;
            txtdescription20.Visible = false;
            txtbatch20.Visible = false;
            txtqtybatch20.Visible = false;
            txtsumtotal20.Visible = false;
            txtcode20.Visible = false;
            txttotalrepack20.Visible = false;
            txtqty20.Visible = false;
            txt20.Visible = false;
            lblnum20.Visible = false;
            txt20.Enabled = true;
            txt20.BackColor = Color.White;
            b20.Visible = false;
            //21
            txtitemcode21.Visible = false;
            txtdescription21.Visible = false;
            txtbatch21.Visible = false;
            txtqtybatch21.Visible = false;
            txtsumtotal21.Visible = false;
            txtcode21.Visible = false;
            txttotalrepack21.Visible = false;
            txtqty21.Visible = false;
            txt21.Visible = false;
            lblnum21.Visible = false;
            txt21.Enabled = true;
            txt21.BackColor = Color.White;
            b21.Visible = false;
            //22
            txtitemcode22.Visible = false;
            txtdescription22.Visible = false;
            txtbatch22.Visible = false;
            txtqtybatch22.Visible = false;
            txtsumtotal22.Visible = false;
            txtcode22.Visible = false;
            txttotalrepack22.Visible = false;
            txtqty22.Visible = false;
            txt22.Visible = false;
            lblnum22.Visible = false;
            txt22.Enabled = true;
            txt22.BackColor = Color.White;
            b22.Visible = false;
            //23
            txtitemcode23.Visible = false;
            txtdescription23.Visible = false;
            txtbatch23.Visible = false;
            txtqtybatch23.Visible = false;
            txtsumtotal23.Visible = false;
            txtcode23.Visible = false;
            txttotalrepack23.Visible = false;
            txtqty23.Visible = false;
            txt23.Visible = false;
            lblnum23.Visible = false;
            txt23.Enabled = true;
            txt23.BackColor = Color.White;
            b23.Visible = false;
            //24
            txtitemcode24.Visible = false;
            txtdescription24.Visible = false;
            txtbatch24.Visible = false;
            txtqtybatch24.Visible = false;
            txtsumtotal24.Visible = false;
            txtcode24.Visible = false;
            txttotalrepack24.Visible = false;
            txtqty24.Visible = false;
            txt24.Visible = false;
            lblnum24.Visible = false;
            txt24.Enabled = true;
            txt24.BackColor = Color.White;
            b24.Visible = false;
            //25

            txtitemcode25.Visible = false;
            txtdescription25.Visible = false;
            txtbatch25.Visible = false;
            txtqtybatch25.Visible = false;
            txtsumtotal250.Visible = false;
            txtcode25.Visible = false;
            txttotalrepack25.Visible = false;
            txtqty25.Visible = false;
            txt25.Visible = false;
            lblnum25.Visible = false;
            txt25.Enabled = true;
            txt25.BackColor = Color.White;
            b25.Visible = false;

            lbltotalread.Text = "0";
            BtnSave.Visible = false;
            txt1.Enabled = true;
            txt1.Focus();
            txt1.Select();
        }
        private void metroButton1_Click(object sender, EventArgs e)
        {

            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure that you want to Cancel the Preparations of " + txtmainfeedcode.Text + " ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                txt1.Enabled = true;
                dgvMaster.Enabled = true;
                bunifuStopPreparation.Visible = false;
                btngreaterthan.BackColor = Color.CornflowerBlue;
                btnlessthan.BackColor = Color.CornflowerBlue;
                btngreaterthan.Enabled = true;
                btnlessthan.Enabled = true;
                txttotalrepack1.Text = "";
                frmmicrowhpreparation solate = new frmmicrowhpreparation();

                //this.Close();
                //solate.ShowDialog();
                frmwhmacropreparation_Load(sender, e);
                StressHideTextBox();
                HideGifters();
                txtcode1.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                txt1.Text = "";
                txt1.Select();
                txt1.Focus();

                //txtqtybactchactive.Text = dgv1stView.CurrentRow.Cells["quantity"].Value.ToString();
            }

            else
            {
                return;
            }
        }

        private void txt1_TextChanged(object sender, EventArgs e)
        {
            if (txt1.Text.Trim() == string.Empty)
            {
                btngreaterthan.Enabled = true;
                btnlessthan.Enabled = true;
                btngreaterthan.BackColor = Color.CornflowerBlue;
                btnlessthan.BackColor = Color.CornflowerBlue;
                bunifuStart.Visible = true;
            }

            else
            {
                txt1.BackColor = Color.White;
            }
        }

        private void txt5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gerard5_Click(sender, e);
            }
        }

        private void txt6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gerard6_Click(sender, e);
            }
        }
      
        private void txt7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gerard7_Click(sender, e);
            }
        }

        private void txt8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gerard8_Click(sender, e);
            }
        }

        private void gerard5_Click(object sender, EventArgs e)
        {
            //start
            dSet.Clear();

            dSet = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text, txtmainfeedcode.Text, label24.Text, "", "", "", "", "", "", "", txt5.Text, "", "", "", "", "", "", "existsornot");

            if (dSet.Tables[0].Rows.Count > 0)
            {

                RepackIDExists();
                txt5.Text = "";
                txt5.Focus();
                return;
            }
            else
            {


            }





            if (dgv1stView.Rows.Count >= 1)
            {
                int i = dgv1stView.CurrentRow.Index + 1;
                if (i >= -1 && i < dgv1stView.Rows.Count)



                    if (txt5.Text.Trim() == string.Empty)
                    {
                        BarcodeNotFound();
                        //MessageBox.Show("Part5", "Barcode Input Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt5.Select();
                        txt5.Focus();
                        txt5.BackColor = Color.Yellow;


                        return;
                    }
                    else
                    {

                        //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=hr_bak;Integrated Security=SSPI";
                        String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
                        SqlConnection sql_con = new SqlConnection(connetionString);

                        cmd = new SqlCommand("SELECT repack_id FROM [dbo].[rdf_repackin_entry]  WHERE repack_id=" + txt5.Text + "", sql_con);

                        SqlDataAdapter daks = new SqlDataAdapter(cmd);

                        daks.Fill(ds);
                        int ia = ds.Tables[0].Rows.Count;
                        if (ia > 0)
                        {
                            //MessageBox.Show("The Formula" + txt4.Text + "Already Exists !");

                            search5();
                            txtcode5.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                            txttotalrepack5.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                            txt5.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();

                            if (txtitemcode5.Text.Trim() == txtcode5.Text.Trim())
                            {
                                //MessageBox.Show("Proceed Match Code");

                            }
                            else
                            {
                                ItemCodeNotMatched();
                                txt5.Text = "";
                                txt5.Focus();
                                //MessageBox.Show("Item Code Not Match!, Choose the exactly item Thanks God Bless:]");
                                return;
                            }



                            //if (txttotalrepack5.Text.Trim() == txtqty5.Text.Trim())
                            if (txttotalrepack5.Text.Trim() == txtsumtotal5.Text.Trim())
                            {
                                //MessageBox.Show("Qty Needed Match <3");

                            }
                            else
                            {
                                ItemCodeValueNotmacthed();
                                txt5.Text = "";
                                txt5.Focus();
                                //MessageBox.Show("Item Quantity Not Match IN Our Needed!, Choose the exactly item Quantity Thanks! ");
                                return;
                            }



                            txt5.BackColor = Color.LightGreen;
                            pictureBox5.Visible = true;
                            button5.Text = "Validated";
                            //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                            txt6.Focus();
                            txt6.Select();
                            SuccessFullyValidated();
                            dgv1stView.CurrentCell = dgv1stView.Rows[i].Cells[0];
                            ds.Clear();







                            //return;
                        }
                        else
                        {
                            RepackIdNotExists();
                            //MessageBox.Show("The Raw Material Repack" + txt5.Text + "Not Exists !!");
                            txt5.Text = "";
                            txt5.Focus();
                            txt5.BackColor = Color.Yellow;
                            return;
                            //return; // ang gulo ntyo mga bugok
                        }





                        //pictureBox1.Visible = true;
                        //button1.Text = "Validated";
                        //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                        //txt2.Focus();
                        //txt2.Select();
                        //dgv1stView.CurrentCell = dgv1stView.Rows[i].Cells[0];





                        if (txt6.Text.Trim() == string.Empty)
                        {
                            lbltotalread.Text = "5";

                            Dochecking();
                            txt6.Focus();
                            txt5.Enabled = false;
                            button5.Enabled = false;


                            //txt3.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                            //txtcode3.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                            //txttotalrepack3.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                            txtsumtotal6.Text = dgv1stView.CurrentRow.Cells["quantity1"].Value.ToString();
                            txtitemcode6.Text = dgv1stView.CurrentRow.Cells["item_code"].Value.ToString();
                            txtdescription6.Text = dgv1stView.CurrentRow.Cells["rp_description"].Value.ToString();
                            txtbatch6.Text = dgv1stView.CurrentRow.Cells["p_nobatch"].Value.ToString();
                            txtqty6.Text = dgv1stView.CurrentRow.Cells["quantity"].Value.ToString();

                            return;
                        }



                        else
                        {
                            search5();
                            txtcode5.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                            txttotalrepack5.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                            txt5.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                            txt6.Focus();
                        }
                    }

                else
                {

                    //MessageBox.Show("LIMIT Exceed at 5");
                    LimitExceeded();


                    if (txt5.Text.Trim() == string.Empty)
                    {

                        MessageBox.Show("Part5", "Barcode Input Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt5.Select();
                        txt5.Focus();
                        txt5.BackColor = Color.Yellow;


                        return;
                    }
                    else
                    {

                        //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=hr_bak;Integrated Security=SSPI";
                        String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
                        SqlConnection sql_con = new SqlConnection(connetionString);

                        cmd = new SqlCommand("SELECT repack_id FROM [dbo].[rdf_repackin_entry]  WHERE repack_id=" + txt5.Text + "", sql_con);

                        SqlDataAdapter daks = new SqlDataAdapter(cmd);

                        daks.Fill(ds);
                        int ia = ds.Tables[0].Rows.Count;
                        if (ia > 0)
                        {
                            //MessageBox.Show("The Formula" + txt4.Text + "Already Exists !");

                            search5();
                            txtcode5.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                            txttotalrepack5.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                            txt5.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();

                            if (txtitemcode5.Text.Trim() == txtcode5.Text.Trim())
                            {
                                //MessageBox.Show("Proceed Match Code");

                            }
                            else
                            {
                                MessageBox.Show("Item Code Not Match!, Choose the exactly item Thanks God Bless:]");
                                return;
                            }



                            //if (txttotalrepack5.Text.Trim() == txtqty5.Text.Trim())
                            if (txttotalrepack5.Text.Trim() == txtsumtotal5.Text.Trim())
                            {
                                //MessageBox.Show("Qty Needed Match <3");

                            }
                            else
                            {
                                MessageBox.Show("Item Quantity Not Match IN Our Needed!, Choose the exactly item Quantity Thanks! ");
                                return;
                            }



                            txt5.BackColor = Color.LightGreen;
                            pictureBox5.Visible = true;
                            button5.Text = "Validated";
                            //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                            txt6.Focus();
                            txt6.Select();
                            //dgv1stView.CurrentCell = dgv1stView.Rows[i].Cells[0];
                            ds.Clear();







                            //return;
                        }
                        else
                        {
                            MessageBox.Show("The Raw Material Repack" + txt5.Text + "Not Exists !!");
                            txt5.Text = "";
                            txt5.BackColor = Color.Yellow;
                            return;
                            //return; // ang gulo ntyo mga bugok
                        }





                        //pictureBox1.Visible = true;
                        //button1.Text = "Validated";
                        //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                        //txt2.Focus();
                        //txt2.Select();
                        //dgv1stView.CurrentCell = dgv1stView.Rows[i].Cells[0];





                        if (txt6.Text.Trim() == string.Empty)
                        {
                            lbltotalread.Text = "5";
                            SuccessFullyValidated();
                            Dochecking();
                            txt6.Focus();
                            txt5.Enabled = false;
                            button5.Enabled = false;


                            //txt3.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                            //txtcode3.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                            //txttotalrepack3.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                            txtitemcode6.Text = dgv1stView.CurrentRow.Cells["item_code"].Value.ToString();
                            txtdescription6.Text = dgv1stView.CurrentRow.Cells["rp_description"].Value.ToString();
                            txtbatch6.Text = dgv1stView.CurrentRow.Cells["p_nobatch"].Value.ToString();
                            txtqty6.Text = dgv1stView.CurrentRow.Cells["quantity"].Value.ToString();

                            return;
                        }



                        else
                        {
                            search5();
                            txtcode5.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                            txttotalrepack5.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                            txt5.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                            txt6.Focus();
                        }
                    }

                }

            }
        }

        private void gerard6_Click(object sender, EventArgs e)
        {


            //start
            dSet.Clear();

            dSet = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text, txtmainfeedcode.Text, label24.Text, "", "", "", "", "", "", "", txt6.Text, "", "", "", "", "", "", "existsornot");

            if (dSet.Tables[0].Rows.Count > 0)
            {

                RepackIDExists();
                txt6.Text = "";
                txt6.Focus();
                return;
            }
            else
            {


            }






            if (dgv1stView.Rows.Count >= 1)
            {
                int i = dgv1stView.CurrentRow.Index + 1;
                if (i >= -1 && i < dgv1stView.Rows.Count)



                    if (txt6.Text.Trim() == string.Empty)
                    {

                        //MessageBox.Show("Part6", "Barcode Input Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BarcodeNotFound();
                        txt6.Select();
                        txt6.Focus();
                        txt6.BackColor = Color.Yellow;


                        return;
                    }
                    else
                    {

                        //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=hr_bak;Integrated Security=SSPI";
                        String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
                        SqlConnection sql_con = new SqlConnection(connetionString);

                        cmd = new SqlCommand("SELECT repack_id FROM [dbo].[rdf_repackin_entry]  WHERE repack_id=" + txt6.Text + "", sql_con);

                        SqlDataAdapter daks = new SqlDataAdapter(cmd);

                        daks.Fill(ds);
                        int ia = ds.Tables[0].Rows.Count;
                        if (ia > 0)
                        {
                            //MessageBox.Show("The Formula" + txt6.Text + "Already Exists !");

                            search6();
                            txtcode6.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                            txttotalrepack6.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                            txt6.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();

                            if (txtitemcode6.Text.Trim() == txtcode6.Text.Trim())
                            {
                                //MessageBox.Show("Proceed Match Code");

                            }
                            else
                            {
                                ItemCodeNotMatched();
                                txt6.Text = "";
                                txt6.Focus();
                                //MessageBox.Show("Item Code Not Match!, Choose the exactly item Thanks God Bless:]");
                                return;
                            }



                            if (txttotalrepack6.Text.Trim() == txtsumtotal6.Text.Trim())
                            {
                                //MessageBox.Show("Qty Needed Match <3");

                            }
                            else
                            {
                                ItemCodeValueNotmacthed();
                                txt6.Text = "";
                                txt6.Focus();
                                //MessageBox.Show("Item Quantity Not Match IN Our Needed!, Choose the exactly item Quantity Thanks! ");
                                return;
                            }



                            txt6.BackColor = Color.LightGreen;
                            pictureBox6.Visible = true;
                            button6.Text = "Validated";
                            //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                            txt7.Focus();
                            txt7.Select();
                            SuccessFullyValidated();
                            dgv1stView.CurrentCell = dgv1stView.Rows[i].Cells[0];
                            ds.Clear();







                            //return;
                        }
                        else
                        {
                            RepackIdNotExists();
                            //MessageBox.Show("The Raw Material Repack" + txt6.Text + "Not Exists !!");
                            txt6.Text = "";
                            txt6.Focus();
                            txt6.BackColor = Color.Yellow;
                            return;
                            //return; // ang gulo ntyo mga bugok
                        }





                        //pictureBox1.Visible = true;
                        //button1.Text = "Validated";
                        //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                        //txt2.Focus();
                        //txt2.Select();
                        //dgv1stView.CurrentCell = dgv1stView.Rows[i].Cells[0];





                        if (txt7.Text.Trim() == string.Empty)
                        {
                            lbltotalread.Text = "6";
                            //SuccessFullyValidated();
                            Dochecking();
                            txt7.Focus();
                            txt6.Enabled = false;
                            button6.Enabled = false;
                            //txt3.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                            //txtcode3.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                            //txttotalrepack3.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                            txtsumtotal7.Text = dgv1stView.CurrentRow.Cells["quantity1"].Value.ToString();
                            txtitemcode7.Text = dgv1stView.CurrentRow.Cells["item_code"].Value.ToString();
                            txtdescription7.Text = dgv1stView.CurrentRow.Cells["rp_description"].Value.ToString();
                            txtbatch7.Text = dgv1stView.CurrentRow.Cells["p_nobatch"].Value.ToString();
                            txtqty7.Text = dgv1stView.CurrentRow.Cells["quantity"].Value.ToString();

                            return;
                        }



                        else
                        {
                            search6();
                            txtcode6.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                            txttotalrepack6.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                            txt6.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                            txt7.Focus();
                        }

                    }

                else
                {
                    //MessageBox.Show("LIMIT Exceed at 6");

                    LimitExceeded();

                    if (txt6.Text.Trim() == string.Empty)
                    {

                        MessageBox.Show("Part6", "Barcode Input Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt6.Select();
                        txt6.Focus();
                        txt6.BackColor = Color.Yellow;


                        return;
                    }
                    else
                    {

                        //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=hr_bak;Integrated Security=SSPI";
                        String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
                        SqlConnection sql_con = new SqlConnection(connetionString);

                        cmd = new SqlCommand("SELECT repack_id FROM [dbo].[rdf_repackin_entry]  WHERE repack_id=" + txt6.Text + "", sql_con);

                        SqlDataAdapter daks = new SqlDataAdapter(cmd);

                        daks.Fill(ds);
                        int ia = ds.Tables[0].Rows.Count;
                        if (ia > 0)
                        {
                            //MessageBox.Show("The Formula" + txt6.Text + "Already Exists !");

                            search6();
                            txtcode6.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                            txttotalrepack6.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                            txt6.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();

                            if (txtitemcode6.Text.Trim() == txtcode6.Text.Trim())
                            {
                                //MessageBox.Show("Proceed Match Code");

                            }
                            else
                            {
                                MessageBox.Show("Item Code Not Match!, Choose the exactly item Thanks God Bless:]");
                                return;
                            }



                            if (txttotalrepack6.Text.Trim() == txtsumtotal6.Text.Trim())
                            {
                                //MessageBox.Show("Qty Needed Match <3");

                            }
                            else
                            {
                                MessageBox.Show("Item Quantity Not Match IN Our Needed!, Choose the exactly item Quantity Thanks! ");
                                return;
                            }



                            txt6.BackColor = Color.LightGreen;
                            pictureBox6.Visible = true;
                            button6.Text = "Validated";
                            //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                            txt7.Focus();
                            txt7.Select();
                            //dgv1stView.CurrentCell = dgv1stView.Rows[i].Cells[0];
                            ds.Clear();







                            //return;
                        }
                        else
                        {
                            MessageBox.Show("The Raw Material Repack" + txt6.Text + "Not Exists !!");
                            txt6.Text = "";
                            txt6.BackColor = Color.Yellow;
                            return;
                            //return; // ang gulo ntyo mga bugok
                        }





                        //pictureBox1.Visible = true;
                        //button1.Text = "Validated";
                        //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                        //txt2.Focus();
                        //txt2.Select();
                        //dgv1stView.CurrentCell = dgv1stView.Rows[i].Cells[0];





                        if (txt7.Text.Trim() == string.Empty)
                        {
                            lbltotalread.Text = "6";
                            Dochecking();
                            txt7.Focus();
                            txt6.Enabled = false;
                            button6.Enabled = false;
                            //txt3.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                            //txtcode3.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                            //txttotalrepack3.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                            txtitemcode7.Text = dgv1stView.CurrentRow.Cells["item_code"].Value.ToString();
                            txtdescription7.Text = dgv1stView.CurrentRow.Cells["rp_description"].Value.ToString();
                            txtbatch7.Text = dgv1stView.CurrentRow.Cells["p_nobatch"].Value.ToString();
                            txtqty7.Text = dgv1stView.CurrentRow.Cells["quantity"].Value.ToString();

                            return;
                        }



                        else
                        {
                            search6();
                            txtcode6.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                            txttotalrepack6.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                            txt6.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                            txt7.Focus();
                        }

                    }

                }
            }
        }

        private void gerard7_Click(object sender, EventArgs e)
        {

            //start
            dSet.Clear();

            dSet = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text, txtmainfeedcode.Text, label24.Text, "", "", "", "", "", "", "", txt7.Text, "", "", "", "", "", "", "existsornot");

            if (dSet.Tables[0].Rows.Count > 0)
            {

                RepackIDExists();
                txt7.Text = "";
                txt7.Focus();
                return;
            }
            else
            {


            }



            if (dgv1stView.Rows.Count >= 1)
            {
                int i = dgv1stView.CurrentRow.Index + 1;
                if (i >= -1 && i < dgv1stView.Rows.Count)



                    if (txt7.Text.Trim() == string.Empty)
                    {
                        BarcodeNotFound();
                        //MessageBox.Show("Part7", "Barcode Input Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt7.Select();
                        txt7.Focus();
                        txt7.BackColor = Color.Yellow;


                        return;
                    }
                    else
                    {

                        //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=hr_bak;Integrated Security=SSPI";
                        String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
                        SqlConnection sql_con = new SqlConnection(connetionString);

                        cmd = new SqlCommand("SELECT repack_id FROM [dbo].[rdf_repackin_entry]  WHERE repack_id=" + txt7.Text + "", sql_con);

                        SqlDataAdapter daks = new SqlDataAdapter(cmd);

                        daks.Fill(ds);
                        int ia = ds.Tables[0].Rows.Count;
                        if (ia > 0)
                        {
                            //MessageBox.Show("The Formula" + txt7.Text + "Already Exists !");

                            search7();
                            txtcode7.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                            txttotalrepack7.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                            txt7.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();

                            if (txtitemcode7.Text.Trim() == txtcode7.Text.Trim())
                            {
                                //MessageBox.Show("Proceed Match Code");

                            }
                            else
                            {
                                ItemCodeNotMatched();
                                txt7.Text = "";
                                txt7.Focus();
                                //MessageBox.Show("Item Code Not Match!, Choose the exactly item Thanks!");
                                return;
                            }



                            if (txttotalrepack7.Text.Trim() == txtsumtotal7.Text.Trim())
                            {
                                //MessageBox.Show("Qty Needed Match <3");

                            }
                            else
                            {
                                ItemCodeValueNotmacthed();
                                txt7.Text = "";
                                txt7.Focus();
                                //MessageBox.Show("Item Quantity Not Match IN Our Needed!, Choose the exactly item Quantity Thanks! ");
                                return;
                            }



                            txt7.BackColor = Color.LightGreen;
                            pictureBox7.Visible = true;
                            button7.Text = "Validated";
                            //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                            txt8.Focus();
                            txt8.Select();
                            SuccessFullyValidated();
                            dgv1stView.CurrentCell = dgv1stView.Rows[i].Cells[0];
                            ds.Clear();







                            //return;
                        }
                        else
                        {
                            RepackIdNotExists();
                            //MessageBox.Show("The Raw Material Repack" + txt7.Text + "Not Exists !!");
                            txt7.BackColor = Color.Yellow;
                            txt7.Text = "";
                            txt7.Focus();
                            return;
                            //return; // ang gulo ntyo mga bugok
                        }





                        //pictureBox1.Visible = true;
                        //button1.Text = "Validated";
                        //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                        //txt2.Focus();
                        //txt2.Select();
                        //dgv1stView.CurrentCell = dgv1stView.Rows[i].Cells[0];





                        if (txt8.Text.Trim() == string.Empty)
                        {
                            lbltotalread.Text = "7";
                            //SuccessFullyValidated();
                            Dochecking();
                            txt8.Focus();
                            txt7.Enabled = false;
                            button7.Enabled = false;
                            //txt3.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                            //txtcode3.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                            //txttotalrepack3.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();
                            txtsumtotal8.Text = dgv1stView.CurrentRow.Cells["quantity1"].Value.ToString();
                            txtitemcode8.Text = dgv1stView.CurrentRow.Cells["item_code"].Value.ToString();
                            txtdescription8.Text = dgv1stView.CurrentRow.Cells["rp_description"].Value.ToString();
                            txtbatch8.Text = dgv1stView.CurrentRow.Cells["p_nobatch"].Value.ToString();
                            txtqty8.Text = dgv1stView.CurrentRow.Cells["quantity"].Value.ToString();

                            return;
                        }







                        else
                        {
                            search7();
                            txtcode7.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                            txttotalrepack7.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                            txt7.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                            txt7.Focus();
                        }

                    }

                //MessageBox.Show("LIMIT Exceed at 7");
                LimitExceeded();


                if (txt7.Text.Trim() == string.Empty)
                {
                    BarcodeNotFound();
                    //MessageBox.Show("Part7", "Barcode Input Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt7.Select();
                    txt7.Focus();
                    txt7.BackColor = Color.Yellow;


                    return;
                }
                else
                {

                    //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=hr_bak;Integrated Security=SSPI";
                    String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
                    SqlConnection sql_con = new SqlConnection(connetionString);

                    cmd = new SqlCommand("SELECT repack_id FROM [dbo].[rdf_repackin_entry]  WHERE repack_id=" + txt7.Text + "", sql_con);

                    SqlDataAdapter daks = new SqlDataAdapter(cmd);

                    daks.Fill(ds);
                    int ia = ds.Tables[0].Rows.Count;
                    if (ia > 0)
                    {
                        //MessageBox.Show("The Formula" + txt7.Text + "Already Exists !");

                        search7();
                        txtcode7.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                        txttotalrepack7.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                        txt7.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();

                        if (txtitemcode7.Text.Trim() == txtcode7.Text.Trim())
                        {
                            //MessageBox.Show("Proceed Match Code");

                        }
                        else


                        {
                            ItemCodeNotMatched();
                            //MessageBox.Show("Item Code Not Match!, Choose the exactly item Thanks!");
                            return;
                        }



                        if (txttotalrepack7.Text.Trim() == txtsumtotal.Text.Trim())
                        {
                            //MessageBox.Show("Qty Needed Match <3");

                        }
                        else
                        {
                            ItemCodeValueNotmacthed();
                            //MessageBox.Show("Item Quantity Not Match IN Our Needed!, Choose the exactly item Quantity Thanks! ");
                            return;
                        }



                        txt7.BackColor = Color.LightGreen;
                        pictureBox7.Visible = true;
                        button7.Text = "Validated";
                        //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                        txt8.Focus();
                        txt8.Select();
                        //dgv1stView.CurrentCell = dgv1stView.Rows[i].Cells[0];
                        ds.Clear();







                        //return;
                    }
                    else
                    {
                        MessageBox.Show("The Raw Material Repack" + txt7.Text + "Not Exists !!");
                        txt7.BackColor = Color.Yellow;
                        txt7.Text = "";
                        return;
                        //return; // ang gulo ntyo mga bugok
                    }





                    //pictureBox1.Visible = true;
                    //button1.Text = "Validated";
                    //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());n
                    //txt2.Focus();
                    //txt2.Select();
                    //dgv1stView.CurrentCell = dgv1stView.Rows[i].Cells[0];





                    if (txt8.Text.Trim() == string.Empty)
                    {
                        lbltotalread.Text = "7";
                        Dochecking();
                        txt8.Focus();
                        txt7.Enabled = false;
                        button7.Enabled = false;
                        //txt3.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                        //txtcode3.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                        //txttotalrepack3.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                        txtitemcode8.Text = dgv1stView.CurrentRow.Cells["item_code"].Value.ToString();
                        txtdescription8.Text = dgv1stView.CurrentRow.Cells["rp_description"].Value.ToString();
                        txtbatch8.Text = dgv1stView.CurrentRow.Cells["p_nobatch"].Value.ToString();
                        txtqty8.Text = dgv1stView.CurrentRow.Cells["quantity"].Value.ToString();

                        return;
                    }







                    else
                    {
                        search7();
                        txtcode7.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                        txttotalrepack7.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                        txt7.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                        txt7.Focus();
                    }

                }

            }
        }





        void QueryInsertMacroPreparation()
        {

            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=hr_bak;Integrated Security=SSPI";
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "INSERT INTO [dbo].[rdf_preparations_macro] (pre_prod_id,pre_feed_code,rep_item_code,rep_id,pre_feed_type,rep_qty,pre_item_code,pre_description,pre_batch,pre_qty_batch,pre_sum_total,preparation_date_finish,rep_added_by,rep_is_active,rep_qa_id) VALUES ('" + txtmasterid.Text + "','" + txtmainfeedcode.Text + "','" + txtcode1.Text + "','" + txtscanid.Text + "','" + label24.Text + "','" + txtqtyneededx2.Text + "','" + txtitemcodeoriginal.Text + "','" + txtdescription1.Text + "','" + txtnobatch.Text + "','" + lblCountss.Text + "','" + label2.Text + "','" + txtdatenow.Text + "','" + txtaddedby.Text + "',1,'" + txt1.Text + "')";
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvView.DataSource = dt;
            //dgvMaster.Visible = true;
            ////dgv_table_2nd_sup.Visible = true;
            //lblmicroview.Visible = true;
            sql_con.Close();
            QueryUpdaterecipetoproduction();
            QueryOutRawMaterials();
            QueryOutRepacking();
            //QueryUpdaterecipetoproduction();
            PreparationAlreadySave();
   
        }



        void QueryOutRepacking()
        {

            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=hr_bak;Integrated Security=SSPI";
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "UPDATE [dbo].[rdf_repackin_entry] SET is_prepared='1'  WHERE rp_item_code= '" + txtitemcodeoriginal.Text + "' AND repack_id='" + txtscanid.Text + "' AND rp_batch='" + txtnobatch.Text + "'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvView.DataSource = dt;
            //dgvMaster.Visible = true;
            ////dgv_table_2nd_sup.Visible = true;
            //lblmicroview.Visible = true;
            sql_con.Close();
        }

        void QueryOutRawMaterials()
        {

            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=hr_bak;Integrated Security=SSPI";

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            SqlConnection sql_con = new SqlConnection(connetionString);

            txtsubtractrepack.Text = (float.Parse(txtactiverepack.Text) - 1).ToString();

            string sqlquery = "UPDATE [dbo].[rdf_raw_materials] SET qty_repack='"+txtinventory.Text+"',active_qty_repack='"+txtsubtractrepack.Text+"'  WHERE item_code= '" + txtitemcodeoriginal.Text + "' ";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvView.DataSource = dt;
            //dgvMaster.Visible = true;
            ////dgv_table_2nd_sup.Visible = true;
            //lblmicroview.Visible = true;
            sql_con.Close();
        }







        void PreparationAlreadySave()
        {
            double subjectquantity;
            double sagot;

            subjectquantity = double.Parse(lbltotalread.Text);
            sagot = subjectquantity + 1;

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "CHECKING FOR " + txtdescription1.Text + " SUCCESSFULL !";
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

            //*Total Sum of  Qty: "+lblCountss.Text+" And QTY Batch: "+label2.Text+" */
            txtinventory.Text = "";
            txtgetqtyrepack.Text = "";
            txtscanid.Text = "";
            txtscanid.Select();
            txtscanid.Focus();


        }

        void SuccesfullyPrepared()
        {
            double subjectquantity;
            double sagot;

            subjectquantity = double.Parse(lbltotalread.Text);
            sagot = subjectquantity + 1;

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "PREPARATION FOR THE FEED TYPE " + label24.Text + " IS ALREADY DONE !";
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
            if (label10.Text == "0")
            {
                NoDataFound();
                return;
            }

            //*Total Sum of  Qty: "+lblCountss.Text+" And QTY Batch: "+label2.Text+" */
            txtinventory.Text = "";
            txtgetqtyrepack.Text = "";
            txtscanid.Text = "";
            txtscanid.Select();
            txtscanid.Focus();


        }


        void QueryUpdaterecipetoproduction()
        {

            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=hr_bak;Integrated Security=SSPI";
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "UPDATE [dbo].[rdf_recipe_to_production] SET macro_is_prepared='1'  WHERE recipe_id= '" + txtrecipe.Text + "'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvView.DataSource = dt;
            //dgvMaster.Visible = true;
            ////dgv_table_2nd_sup.Visible = true;
            //lblmicroview.Visible = true;
            sql_con.Close();
        }

        void QueryOutProduction()
        {

            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=hr_bak;Integrated Security=SSPI";

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "UPDATE [dbo].[rdf_production_advance] SET macro_prep_status='1',macro_prep_status_date='"+txtdatenow.Text+"'  WHERE prod_id= '" + txtmasterid.Text + "'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvView.DataSource = dt;
            //dgvMaster.Visible = true;
            ////dgv_table_2nd_sup.Visible = true;
            //lblmicroview.Visible = true;
            sql_con.Close();
        }
















        private void gerard8_Click(object sender, EventArgs e)
        {

            //start
            dSet.Clear();

            dSet = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text, txtmainfeedcode.Text, label24.Text, "", "", "", "", "", "", "", txt8.Text, "", "", "", "", "", "", "existsornot");

            if (dSet.Tables[0].Rows.Count > 0)
            {

                RepackIDExists();
                txt8.Text = "";
                txt8.Focus();
                return;
            }
            else
            {


            }













            if (dgv1stView.Rows.Count >= 1)
            {
                int i = dgv1stView.CurrentRow.Index + 1;
                if (i >= -1 && i < dgv1stView.Rows.Count)



                    if (txt8.Text.Trim() == string.Empty)
                    {
                        BarcodeNotFound();

                        //MessageBox.Show("Part8", "Barcode Input Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt8.Select();
                        txt8.Focus();
                        txt8.BackColor = Color.Yellow;


                        return;
                    }
                    else
                    {

                        //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=hr_bak;Integrated Security=SSPI";
                        String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
                        SqlConnection sql_con = new SqlConnection(connetionString);

                        cmd = new SqlCommand("SELECT repack_id FROM [dbo].[rdf_repackin_entry]  WHERE repack_id=" + txt8.Text + "", sql_con);

                        SqlDataAdapter daks = new SqlDataAdapter(cmd);

                        daks.Fill(ds);
                        int ia = ds.Tables[0].Rows.Count;
                        if (ia > 0)
                        {
                            //MessageBox.Show("The Formula" + txt8.Text + "Already Exists !");

                            search8();
                            txtcode8.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                            txttotalrepack8.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                            txt8.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();

                            if (txtitemcode8.Text.Trim() == txtcode8.Text.Trim())
                            {
                                //MessageBox.Show("Proceed Match Code");

                            }
                            else
                            {
                                ItemCodeNotMatched();
                                txt8.Text = "";
                                txt8.Focus();
                                //MessageBox.Show("Item Code Not Match!, Choose the exactly item Thanks!");
                                return;
                            }



                            if (txttotalrepack8.Text.Trim() == txtsumtotal8.Text.Trim())
                            {
                                //MessageBox.Show("Qty Needed Match <3");

                            }
                            else
                            {
                                ItemCodeValueNotmacthed();
                                txt8.Text = "";
                                txt8.Focus();
                                //MessageBox.Show("Item Quantity Not Match IN Our Needed!, Choose the exactly item Quantity Thanks! ");
                                return;
                            }



                            txt8.BackColor = Color.LightGreen;
                            pictureBox8.Visible = true;
                            button8.Text = "Validated";
                            //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                            txt9.Focus();
                            txt9.Select();
                            SuccessFullyValidated();
                            dgv1stView.CurrentCell = dgv1stView.Rows[i].Cells[0];
                            ds.Clear();







                            //return;
                        }
                        else
                        {
                            RepackIdNotExists();
                            //MessageBox.Show("The Raw Material Repack" + txt8.Text + "Not Exists !!");
                            txt8.Text = "";
                            txt8.BackColor = Color.Yellow;
                            txt8.Focus();
                            return;
                            //return; // ang gulo ntyo mga bugok
                        }





                        //pictureBox1.Visible = true;
                        //button1.Text = "Validated";
                        //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                        //txt2.Focus();
                        //txt2.Select();
                        //dgv1stView.CurrentCell = dgv1stView.Rows[i].Cells[0];





                        if (txt9.Text.Trim() == string.Empty)
                        {
                            lbltotalread.Text = "8";
                            //SuccessFullyValidated();
                            Dochecking();
                            txt8.Enabled = false;
                            button8.Enabled = false;


                            //txt3.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                            //txtcode3.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                            //txttotalrepack3.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();
                            txtsumtotal9.Text = dgv1stView.CurrentRow.Cells["quantity1"].Value.ToString();
                            txtitemcode9.Text = dgv1stView.CurrentRow.Cells["item_code"].Value.ToString();
                            txtdescription9.Text = dgv1stView.CurrentRow.Cells["rp_description"].Value.ToString();
                            txtbatch9.Text = dgv1stView.CurrentRow.Cells["p_nobatch"].Value.ToString();
                            txtqty9.Text = dgv1stView.CurrentRow.Cells["quantity"].Value.ToString();

                            return;
                        }




                        else
                        {
                            search8();
                            txtcode8.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                            txttotalrepack8.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                            txt8.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                            txt9.Focus();
                        }


                    }

                else
                {
                    //MessageBox.Show("LIMIT Exceed at 8");
                    LimitExceeded();


                    if (txt8.Text.Trim() == string.Empty)
                    {
                        BarcodeNotFound();
                        //MessageBox.Show("Part8", "Barcode Input Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt8.Select();
                        txt8.Focus();
                        txt8.BackColor = Color.Yellow;


                        return;
                    }
                    else
                    {

                        //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=hr_bak;Integrated Security=SSPI";
                        String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
                        SqlConnection sql_con = new SqlConnection(connetionString);

                        cmd = new SqlCommand("SELECT repack_id FROM [dbo].[rdf_repackin_entry]  WHERE repack_id=" + txt8.Text + "", sql_con);

                        SqlDataAdapter daks = new SqlDataAdapter(cmd);

                        daks.Fill(ds);
                        int ia = ds.Tables[0].Rows.Count;
                        if (ia > 0)
                        {
                            //MessageBox.Show("The Formula" + txt8.Text + "Already Exists !");

                            search8();
                            txtcode8.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                            txttotalrepack8.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                            txt8.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();

                            if (txtitemcode8.Text.Trim() == txtcode8.Text.Trim())
                            {
                                //MessageBox.Show("Proceed Match Code");

                            }
                            else
                            {
                                ItemCodeNotMatched();
                                //MessageBox.Show("Item Code Not Match!, Choose the exactly item Thanks!");
                                return;
                            }



                            if (txttotalrepack8.Text.Trim() == txtsumtotal8.Text.Trim())
                            {
                                //MessageBox.Show("Qty Needed Match <3");

                            }
                            else
                            {
                                ItemCodeValueNotmacthed();
                                //MessageBox.Show("Item Quantity Not Match IN Our Needed!, Choose the exactly item Quantity Thanks! ");
                                return;
                            }



                            txt8.BackColor = Color.LightGreen;
                            pictureBox8.Visible = true;
                            button8.Text = "Validated";
                            //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                            txt9.Focus();
                            txt9.Select();
                            //dgv1stView.CurrentCell = dgv1stView.Rows[i].Cells[0];
                            ds.Clear();







                            //return;
                        }
                        else
                        {
                            RepackIdNotExists();
                            //MessageBox.Show("The Raw Material Repack" + txt8.Text + "Not Exists !!");
                            txt8.Text = "";
                            txt8.BackColor = Color.Yellow;
                            return;
                            //return; // ang gulo ntyo mga bugok
                        }





                        //pictureBox1.Visible = true;
                        //button1.Text = "Validated";
                        //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                        //txt2.Focus();
                        //txt2.Select();
                        //dgv1stView.CurrentCell = dgv1stView.Rows[i].Cells[0];





                        if (txt9.Text.Trim() == string.Empty)
                        {
                            lbltotalread.Text = "8";
                            Dochecking();
                            txt8.Enabled = false;
                            button8.Enabled = false;


                            //txt3.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                            //txtcode3.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                            //txttotalrepack3.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                            txtitemcode9.Text = dgv1stView.CurrentRow.Cells["item_code"].Value.ToString();
                            txtdescription9.Text = dgv1stView.CurrentRow.Cells["rp_description"].Value.ToString();
                            txtbatch9.Text = dgv1stView.CurrentRow.Cells["p_nobatch"].Value.ToString();
                            txtqty9.Text = dgv1stView.CurrentRow.Cells["quantity"].Value.ToString();

                            return;
                        }




                        else
                        {
                            search8();
                            txtcode8.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                            txttotalrepack8.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                            txt8.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                            txt9.Focus();
                        }


                    }

                }

            }
            }

        private void btnultrasave_Click(object sender, EventArgs e)
        {


            if (txtscanid.Text.Trim() == string.Empty)
            {

                BarcodeNotFound();//4/18/2020
                         
                txtscanid.Select();
                txtscanid.Focus();
                txtscanid.BackColor = Color.Yellow;


                return;
            }

            dSet.Clear();
            //dSet = objStorProc.rdf_sp_prod_schedules(0, txt1.Text, "", "", "", "", "", "", "existsornot");
            dSet = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text, txtmainfeedcode.Text, label24.Text, "", "", "", "", "", "", "", txtscanid.Text, "", "", "", "", "", "", "existsornotmacro");

            if (dSet.Tables[0].Rows.Count > 0)
            {
                //MessageBox.Show("NOT RECOGNISE", "Offense", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //cboFeedCode.Focus();
                RepackIDExists();
                txtscanid.Text = "";
                txtscanid.Focus();
                return;
            }
            else
            {
                //FeedCodeNotExists();

            }

            dSet.Clear();
            //dSet = objStorProc.rdf_sp_prod_schedules(0, txt1.Text, "", "", "", "", "", "", "existsornot");
            dSet = objStorProc.rdf_sp_new_preparation(0, txtscanid.Text, txtmainfeedcode.Text, label24.Text, "", "", "", "", "", "", "", txtscanid.Text, "", "", "", "", "", "", "existsornotrepack");

            if (dSet.Tables[0].Rows.Count > 0)
            {
                //MessageBox.Show("NOT RECOGNISE", "Offense", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //cboFeedCode.Focus();
                //RepackIDExists();
                //RepackIDExists2();
                //txtscanid.Text = "";
                //txtscanid.Focus();
                //MessageBox.Show("Ling");
                //return;
            }
            else
            {
                //FeedCodeNotExists();
                RepackIDExists2();
                txtscanid.Text = "";
                txtscanid.Focus();
                return;
            }


            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=hr_bak;Integrated Security=SSPI";
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            SqlConnection sql_con = new SqlConnection(connetionString);

            cmd = new SqlCommand("SELECT string_id FROM [dbo].[rdf_repackin_entry]  WHERE string_id='" + txtscanid.Text + "' AND rp_item_category='MACRO' ", sql_con);

            SqlDataAdapter daks = new SqlDataAdapter(cmd);

            daks.Fill(ds);
            int ia = ds.Tables[0].Rows.Count;
            if (ia > 0)
            {
                //MessageBox.Show("The Formula" + txt1.Text + "Already Exists !");

                searchscan();
                txtcode1.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                txttotalrepack1.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                txtqtyneededx2.Text = dgv1stView.CurrentRow.Cells["quantity1"].Value.ToString();
                txtgetqtyrepack.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();


                txt1.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();






                //bill gates programmer
                // 7/6/2020 gerard roque singian developer copyright
                if (txtFeedCodeRepack.Text.Trim() == string.Empty)
                {

                }
                else
                {
                    if (txtmainfeedcode.Text.Trim() == txtFeedCodeRepack.Text.Trim())
                    {

                    }
                    else
                    {


                        FeedCodeNotMatch();
                        txtscanid.Text = "";
                        txtscanid.Focus();
                        return;
                    }
                }






                if (txtitemcodeoriginal.Text.Trim() == txtcode1.Text.Trim())
                {
                    //MessageBox.Show("Proceed Match Code");

                }
                else
                {
                    //MessageBox.Show("Item Code Not Match!, Choose the exactly item Thanks God Bless:]");
                    ItemCodeNotMatched();
                    txtscanid.Text = "";
                    txtscanid.Focus();
                    txtscanid.Text = "";
                    return;

                }











                if (txtqtyneededx2.Text.Trim() == txtgetqtyrepack.Text.Trim())
                {
                    //MessageBox.Show("Qty Needed Match <3");

                }
                else
                {
                    //MessageBox.Show("Item Quantity Not Match IN Our Needed!, Choose the exactly item Quantity Thanks! ");
                    ItemCodeValueNotmacthed();
                    txtscanid.Text = "";
                    txtscanid.Focus();
                    return;
                }




            }

















            else
            {
                    RepackIdNotExists();//4/18/2020
                                        //MessageBox.Show("The Raw Material Repack" + txt1.Text + "Not Exists !!");
                   txtscanid.BackColor = Color.Yellow;
                    txtscanid.Text = "";
                    txtscanid.Focus();
                    return;
                    //return; // ang gulo ntyo mga bugok
                }




            txtinventory.Text = (float.Parse(txtrepackavailable.Text) - float.Parse(txtqtyneededx2.Text)).ToString("0.00");



            QueryInsertMacroPreparation();
            txtItemCode_TextChanged(sender,e);
            showPreparation();
            txtrepackavailable.Text = dgvMaster2.CurrentRow.Cells["qty_repack"].Value.ToString();
            txtmasterid_TextChanged(sender, e);



            if (lblCounts.Text == "0")
            {
                QueryOutProduction();
                load_Schedules();


                SuccesfullyPrepared();
                txtscanid.Select();
                txtscanid.Focus();
            }
            txtrecipe_TextChanged(sender,e);
            load_search();
            txtItemCode_TextChanged(sender,e);

            txtmainfeedcode_TextChanged(sender, e);
            ready = true;
            showRawMatsDataGrid();
        }

        void FeedCodeNotMatch()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "FEED CODE NOT MATCH";
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


        private void txtqtybactchactive_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtscanid_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtscanid_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                btnultrasave_Click(sender, e);
            }
        }

        private void dgv1stView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            // var grid = sender as DataGridView;
            //var rowIdx = (e.RowIndex + 1).ToString();

            //var centerFormat = new StringFormat()
            //{
            //    // right alignment might actually make more sense for numbers
            //    Alignment = StringAlignment.Center,
            //    LineAlignment = StringAlignment.Center
            //};

            //var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            //e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label10_TextChanged(object sender, EventArgs e)
        {
            //if (label10.Text == "0")
            //{
            //    panel2.Visible = false;
            //}
            //else
            //{

            //    panel2.Visible = true;
           
            //}
        }

        private void bunifuUndo_Click(object sender, EventArgs e)
        {
            if (mode == "active")
            {
                panel2.Visible = true;
                bunifuUndo.ButtonText = "HIDE (INFORMATION)";
            
                mode = "sira";
            }
            else
            {
                panel2.Visible = false;
                bunifuUndo.ButtonText = "SHOW INFORMATION";
                mode = "active";
       
       
            }
        }

        private void lblCountss_TextChanged(object sender, EventArgs e)
        {

          
        }

        private void dgvMaster_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                e.Value = e.Value.ToString().ToUpper();
                e.FormattingApplied = true;
            }
        }

        private void dgv1stView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                e.Value = e.Value.ToString().ToUpper();
                e.FormattingApplied = true;
            }
        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void txtrecipe_TextChanged(object sender, EventArgs e)
        {
            doSearch();
        }

        private void txtitemcodeoriginal_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvMaster2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {
                if (dgvMaster2.Columns[e.ColumnIndex].Name.ToLower().Contains("qty_repack"))
                {
                    if (e.Value.ToString() != "")
                    {
                        double d = double.Parse(e.Value.ToString());
                        e.Value = d.ToString("n");
                    }
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            timer1.Start();
            if(label10.Text=="0")
            {
                load_Schedules();
            }
            else
            {
                splitContainer1.Visible = true;
                timer1.Stop();
            }
  
            
        }
    }
}
;