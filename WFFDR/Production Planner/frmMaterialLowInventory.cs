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
    public partial class frmMaterialLowInventory : Form
    {

        myclasses xClass = new myclasses();

        IStoredProcedures objStorProc = null;

        Boolean ready = false;
        DataSet dSet = new DataSet();
        DataSet dset = new DataSet();

        DataSet dset2 = new DataSet();
        DataSet dSet_temp = new DataSet();

        int p_id = 0;

        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();



        public frmMaterialLowInventory()
        {
            InitializeComponent();
        }

        public frmMaterialLowInventory(string feedCode,string feedType, string productionDate,string bags, string batch, string bagorbin, string mixingcapacity,string records)
        {
            InitializeComponent();
            this.FeedCode = feedCode;
            this.FeedType = feedType;
            this.ProductionDate = productionDate;
            this.Bags = bags;
            this.Batch = batch;
            this.BagAndBin = bagorbin;
            this.MixingCapacity = mixingcapacity;
            this.Records = records;

        }
        public string FeedCode { get; set; }
        public string FeedType { get; set; }
        public string ProductionDate { get; set; }
        public string Bags { get; set; }
        public string Batch { get; set; }
        public string BagAndBin { get; set; }
        public string MixingCapacity { get; set; }
        public string Records { get; set; }
        private void frmMaterialLowInventory_Load(object sender, EventArgs e)
        {



            txtFeedCode.Text = FeedCode;
            textBox1.Text = FeedType;
            mfg_datePicker2.Text = ProductionDate;
            txtbags.Text = Bags;
            txtnobatch.Text = Batch;
            cmbBagandBin.Text = BagAndBin;
            txtseries.Text = MixingCapacity;
            lblrecords.Text = Records;
            //sample
            //txtnobatch.Text = "480";
            //txtFeedCode.Text = "FMP400Y";
            //txtseries.Text = "300";
            //txtbags.Text = "80";
            // Calling the Stored PROC 
            //TransactionButton();

            //lblmainItemError.Text = dgvImport.CurrentRow.Cells["rp_description"].Value.ToString();
            objStorProc = xClass.g_objStoredProc.GetCollections();
            CallData();
            CallDataforMicro();

            showImportDataGrid();
            textBox2.Text = "2";

            txtItemCode_TextChanged(sender, e);
            showRawMatsDataGrid();

            lblCounts.Text = dgvImport.RowCount.ToString();
            TotalBatchQty();



            btnAdd.ButtonText = "CHECK INVENTORY BELOW "+lblmainItemError.Text+"";

            CallDataVariance();
        }

        void TotalBatchQty()
        {
            decimal tot = 0;
            for (int i = 0; i < dgvImport.RowCount - 1; i++)
            {
                var value = dgvImport.Rows[i].Cells["quantity2"].Value;
                if (value != DBNull.Value)
                {
                    tot += Convert.ToDecimal(value) * 2;

                }


            }






            if (tot == 0)
            {

            }


            lblCountss.Text = tot.ToString();

        }

        private void mfg_datePicker_ValueChanged(object sender, EventArgs e)
        {

        }




        void BagvsMixing()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = " Actual Bags is Less than the Mixing Capacity !";
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


        void times2query()
        {
            for (int n = 0; n < (dgvImport.Rows.Count); n++)
            {


                double s1 = Convert.ToDouble(dgvImport.Rows[n].Cells[7].Value);

                //double s13 = s * 2;
                double s15 = s1 * 2;

                //dgvImport.Rows[n].Cells[7].Value = s15.ToString("#,0.000");
                dgvImport.Rows[n].Cells[7].Value = s15.ToString();



                //double totalQty = Convert.ToDouble(dgvImport.Rows[n].Cells[7].Value);

                //double s13 = s * 2;
                double batch;
                batch = double.Parse(txtnobatch.Text);

                double totalQuantity = s15 * batch;

                //dgvImport.Rows[n].Cells[7].Value = s15.ToString("#,0.000");
                dgvImport.Rows[n].Cells[8].Value = totalQuantity.ToString();



            }


        }


        public void TransactionButton()

        {
            double validation1;
            double validation2;

            validation1 = double.Parse(txtseries.Text);
            validation2 = double.Parse(txtbags.Text);

            if (validation1 < validation2)
            {
                BagvsMixing();
                txtbags.Text = "";
                txtbags.Focus();
                return;
            }
            else
            {

            }

            double mainbalance;
            double selectquantity;


            mainbalance = double.Parse(txtrepackavailable.Text);
            selectquantity = double.Parse(txttotalQty.Text);
            if (mainbalance < selectquantity)
            {
                NoBalanceNotify();


                txtbags.BackColor = Color.Yellow;
                txtbags.Focus();
                return;
            }
            else
            {
                //WithBalanceNotify(); alis muna 4/13/2020
                btnlessthan_Click(new object(), new System.EventArgs());
                //MessageBox.Show("1");

            }
            load_search();
            //Computation();
   














        }



        void CallDataVariance()
        {
            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";

            //deploy
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "select distinct rec.recipe_id,rec.rp_type,rec.feed_code,rec.item_code,rec.rp_description,rec.rp_category,rec.rp_group,rec.quantity,rec.quantity as qty3,a.qty_production from [dbo].[rdf_recipe] rec LEFT JOIN [dbo].[rdf_raw_materials] a ON rec.item_code=a.item_code WHERE rec.feed_code = '" + txtFeedCode.Text + "' AND rec.is_active=1 AND rec.quantity > a.qty_production ORDER BY rec.rp_category DESC";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
           dgvVariance.DataSource = dt;



            for (int n = 0; n < (dgvVariance.Rows.Count); n++)
            {


                double s1 = Convert.ToDouble(dgvVariance.Rows[n].Cells[7].Value);

                //double s13 = s * 2;
                double s15 = s1 * 2;

     
              dgvVariance.Rows[n].Cells[7].Value = s15.ToString();




                double batch;
                batch = double.Parse(txtnobatch.Text);

                double totalQuantity = s15 * batch;

                //dgvImport.Rows[n].Cells[7].Value = s15.ToString("#,0.000");
                dgvVariance.Rows[n].Cells[7].Value = totalQuantity.ToString();



            }













            lbloutstock.Text = dgvVariance.RowCount.ToString();

            sql_con.Close();






        }





        void CallData()
        {
            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";

            //deploy
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "select distinct rec.recipe_id,rec.rp_type,rec.feed_code,rec.item_code,rec.rp_description,rec.rp_category,rec.rp_group,rec.quantity,rec.quantity,a.qty_production as saas,ISNULL(t5.RECEIVING,0) + ISNULL(t6.ISSUE,0) - ISNULL(t2.MACRESERVED,0)- ISNULL(t7.OUTING,0) as qty_production from [dbo].[rdf_recipe] rec LEFT JOIN [dbo].[rdf_raw_materials] a ON rec.item_code=a.item_code  LEFT JOIN ( select BC.r_item_code, sum(CAST(REPLACE(BC.r_quantity,',','') as float))  as ISSUE from rdf_microreceiving_entry BC where BC.is_active='1' and BC.transaction_type='Miscellaneous Receipt' group by BC.r_item_code) t6 on a.item_code = t6.r_item_code LEFT JOIN ( select BC.item_code, sum(CAST(BC.quantity as float)* 2)  as MACRESERVED from rdf_recipe_to_production BC where CAST(BC.proddate as date) BETWEEN '2021-01-12' and GETDATE()+30 and status_of_person IS NULL group by BC.item_code) t2 on a.item_code = t2.item_code LEFT JOIN ( select BC.r_item_code, sum(CAST(REPLACE(BC.r_quantity,',','') as float))  as RECEIVING from rdf_microreceiving_entry BC where is_active='1' and BC.transaction_type='PO' group by BC.r_item_code) t5 on a.item_code = t5.r_item_code   LEFT JOIN ( select BC.item_code, sum(CAST(REPLACE(BC.qty,',','') as float))  as OUTING from rdf_transaction_out_progress BC where BC.is_active='1' group by BC.item_code) t7 on a.item_code = t7.item_code WHERE rec.feed_code = '" + txtFeedCode.Text + "' AND rec.is_active=1 AND rec.rp_category='MACRO' AND (ISNULL(t5.RECEIVING,0) + ISNULL(t6.ISSUE,0) - ISNULL(t2.MACRESERVED,0)- ISNULL(t7.OUTING,0)) < (CAST(rec.quantity as float)*2*" + txtnobatch.Text + ") ORDER BY rec.rp_category DESC";


            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvImport.DataSource = dt;



            ////sql_con.Close();


            //dset.Clear();
            //dset = objStorProc.sp_GetCategory("Calldatablockingoflowinventory", Convert.ToInt32(txtnobatch.Text), txtFeedCode.Text, "", "");

            //try
            //{
            //    if (dset.Tables.Count > 0)
            //    {
            //        DataView dv = new DataView(dset.Tables[0]);

            //        dgvImport.DataSource = dv;

            //    }
            //}
            //catch (SyntaxErrorException)
            //{
            //    MessageBox.Show("Invalid character found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //    return;
            //}
            //catch (EvaluateException)
            //{
            //    MessageBox.Show("Invalid character found 2 Gerard.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //    return;
            //}



            //if (ready == true)
            //valentine

            lblCounts.Text = dgvImport.RowCount.ToString();

            double lbltotalMacroMaterials;


            lbltotalMacroMaterials = double.Parse(lblCounts.Text);

            if (lbltotalMacroMaterials > 0)
            {

                btnsum_Click(new object(), new System.EventArgs());
                times2query();

                dgvImport_CurrentCellChanged(new object(), new System.EventArgs());
            }
            else
            {

            }

        }


        void CallDataforMicro()
        {

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);



            //string sqlquery = "select distinct rec.recipe_id,rec.rp_type,rec.feed_code,rec.item_code,rec.rp_description,rec.rp_category,rec.rp_group,rec.quantity,rec.quantity,a.qty_production as saas,ISNULL(t5.RECEIVING,0) + ISNULL(t6.ISSUE,0) - ISNULL(t2.MACRESERVED,0) as qty_production from [dbo].[rdf_recipe] rec LEFT JOIN [dbo].[rdf_raw_materials] a ON rec.item_code=a.item_code  LEFT JOIN ( select BC.r_item_code, sum(CAST(REPLACE(BC.actual_count_good,',','') as float))  as ISSUE from rdf_microreceiving_entry BC where BC.receiving_status='1' and BC.is_active='1' and BC.transaction_type='Miscellaneous Receipt' group by BC.r_item_code) t6 on a.item_code = t6.r_item_code LEFT JOIN ( select BC.item_code, sum(CAST(BC.formulation_qty as float))  as MACRESERVED from rdf_recipe_to_production BC where CAST(BC.proddate as date) BETWEEN '2021-01-12' and GETDATE()+30 and status_of_person IS NULL group by BC.item_code) t2 on a.item_code = t2.item_code LEFT JOIN ( select BC.r_item_code, sum(CAST(REPLACE(BC.r_quantity,',','') as float))  as RECEIVING from rdf_microreceiving_entry BC where is_active='1' and BC.transaction_type='PO' group by BC.r_item_code) t5 on a.item_code = t5.r_item_code WHERE rec.feed_code = '" + txtFeedCode.Text + "' AND rec.is_active=1 AND rec.rp_category='MICRO' ORDER BY rec.rp_category DESC";
           
            string sqlquery = "select distinct rec.recipe_id,rec.rp_type,rec.feed_code,rec.item_code,rec.rp_description,rec.rp_category,rec.rp_group,rec.quantity,rec.quantity,a.qty_production as saas,ISNULL(t5.RECEIVING,0) + ISNULL(t6.ISSUE,0) - ISNULL(t2.MACRESERVED,0) - ISNULL(t7.OUTING,0) as qty_production from [dbo].[rdf_recipe] rec LEFT JOIN [dbo].[rdf_raw_materials] a ON rec.item_code=a.item_code  LEFT JOIN ( select BC.r_item_code, sum(CAST(REPLACE(BC.r_quantity,',','') as float))  as RECEIVING from rdf_microreceiving_entry BC where BC.transaction_type='PO' group by BC.r_item_code) t5 on a.item_code = t5.r_item_code LEFT JOIN ( select BC.r_item_code, sum(CAST(REPLACE(BC.r_quantity,',','') as float))  as ISSUE from rdf_microreceiving_entry BC where BC.transaction_type='Miscellaneous Receipt' group by BC.r_item_code) t6 on a.item_code = t6.r_item_code LEFT JOIN ( select BC.item_code, sum(CAST(BC.formulation_qty as float))  as MACRESERVED from rdf_recipe_to_production BC where CAST(BC.proddate as date) BETWEEN '2021-01-12' and GETDATE()+30 and status_of_person IS NULL group by BC.item_code) t2 on a.item_code = t2.item_code LEFT JOIN ( select BC.item_code, sum(CAST(REPLACE(BC.qty,',','') as float))  as OUTING from rdf_transaction_out_progress BC where BC.is_active='1' group by BC.item_code) t7 on a.item_code = t7.item_code WHERE rec.feed_code = '"+txtFeedCode.Text+ "' AND rec.is_active=1 AND rec.rp_category='MICRO' AND ISNULL(t5.RECEIVING,0) + ISNULL(t6.ISSUE,0) - ISNULL(t2.MACRESERVED,0) - ISNULL(t7.OUTING,0) < CAST(rec.quantity as float)*2*" + txtnobatch.Text+" ORDER BY rec.rp_category DESC";


            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvMicroImport.DataSource = dt;
            lbltotalmicro.Text = dgvMicroImport.RowCount.ToString();


            sql_con.Close();
            //if (ready == true)
            //valentine

            double lbltotalMicroMaterials;


            lbltotalMicroMaterials = double.Parse(lbltotalmicro.Text);

            if (lbltotalMicroMaterials > 0)
            {
                MicroSummaryData();
                MICROtimesProd();
            }
            else
            {
    
            }


        }

        void MICROtimesProd()
        {
            for (int n = 0; n < (dgvMicroImport.Rows.Count); n++)
            {


                double s1 = Convert.ToDouble(dgvMicroImport.Rows[n].Cells[7].Value);

         
                double s15 = s1 * 2;


                dgvMicroImport.Rows[n].Cells[7].Value = s15.ToString();



                double batch;
                batch = double.Parse(txtnobatch.Text);

                double totalQuantity = s15 * batch;

                //dgvImport.Rows[n].Cells[7].Value = s15.ToString("#,0.000");
                dgvMicroImport.Rows[n].Cells[8].Value = totalQuantity.ToString();



            }
        }

        void MicroSummaryData()
        {
            try
            {

     



            dgvMicroImport[6, dgvMicroImport.Rows.Count - 1].Value = "Total";
            dgvMicroImport.Rows[dgvMicroImport.Rows.Count - 1].Cells[0].Style.BackColor = Color.Green;
            dgvMicroImport.Rows[dgvMicroImport.Rows.Count - 1].Cells[0].Style.ForeColor = Color.Red;
            decimal tot = 0;
            //decimal tot2 = 0;
            decimal batching;
            batching = decimal.Parse(txtnobatch.Text);

            for (int i = 0; i < dgvMicroImport.RowCount - 1; i++)
            {
                var value = dgvMicroImport.Rows[i].Cells["quantity5"].Value;
                if (value != DBNull.Value)
                {
                    tot += Convert.ToDecimal(value) * 2;

                }





            }






            if (tot == 0)
            {

            }


            lblgrandotal.Text = tot.ToString();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }




        void showRawMatsDataGrid()
        {
      
                if (dgvMaster2.CurrentRow != null)
                {
                    if (dgvMaster2.CurrentRow.Cells["item_id"].Value != null)
                    {
                        p_id = Convert.ToInt32(dgvMaster2.CurrentRow.Cells["item_id"].Value);
                        txtrepackavailable.Text = dgvMaster2.CurrentRow.Cells["RESERVED"].Value.ToString();


                    }
                }
            
        }



        void load_search()
        {
            dataGridView2.Visible = false;
            dset_emp.Clear();

            dset_emp2.Clear();


            dset_emp = objStorProc.sp_getMajorTables("GetFeedType");
            dset_emp2 = objStorProc.sp_getMajorTables("GetProductionLevel");
            doSearch3();
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

                        //dv.RowFilter = "feed_code like '%" + cboFeedCode.Text + "%'";
                        dv.RowFilter = "feed_code like '%" + txtFeedCode.Text + "%'";


                    }
                    else if (myglobal.global_module == "VISITORS")
                    {

                    }
                    dataGridView2.DataSource = dv;
                    //lblrecords.Text = dgv_table.RowCount.ToString();gerard
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


        }

        DataSet dset_emp2 = new DataSet();
        void doSearch3()
        {
            try
            {
                if (dset_emp2.Tables.Count > 0)
                {
                    DataView dv = new DataView(dset_emp2.Tables[0]);
                    if (myglobal.global_module == "EMPLOYEE")
                    {
                        //dv.RowFilter = "firstname like '%" + txtmainsearch.Text + "%' or lastname like '%" + txtsearch.Text + "%' or employee_number like '%" + txtsearch.Text + "%' or employment_status_name like '%" + txtsearch.Text + "%'";
                    }
                    else if (myglobal.global_module == "Active")
                    {

                        dv.RowFilter = "proddate = '" + dtpCompare.Text + "'";

                    }
                    else if (myglobal.global_module == "VISITORS")
                    {
                        //dv.RowFilter = "visitors_lastname like '%" + txtsearch.Text + "%' or visitors_firstname like '%" + txtsearch.Text + "%'";
                    }
                    dataGridView4.DataSource = dv;
                    lblcountprod.Text = dataGridView4.RowCount.ToString();
                    //txtseries.Text = dataGridView4.RowCount.ToString();
                    //double count1;

                    //double seriescount;

                    //count1 = double.Parse(txtseries.Text);
                    //rp2 = double.Parse(txtnobatch.Text);

                    //seriescount = count1 + 1;
                    //txtseries.Text = Convert.ToString(seriescount);

                    //double lblx;
                    //double lbly;
                    //lblx = double.Parse(txtbags.Text);
                    //lbly = double.Parse(txtbagsprinting.Text);

                    //lblxx.Text = Math.Round(lblx, 5).ToString("#,0.00");
                    //lblyy.Text = Math.Round(lbly, 5).ToString("#,0.00");



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




            int sum = 0;
            for (int i = 0; i < dataGridView4.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dataGridView4.Rows[i].Cells[3].Value);
            }

            //lblCounts.Text = dgvImport.RowCount.ToString();
            lblactualCount.Text = sum.ToString();



        }




        void NoBalanceNotify()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "NOT ENOUGH STOCK FOR " + txtitemdescription.Text + " CURRENT BALANCE IS " + txtrepackavailable.Text + " AND THE ACTUAL NEEDED FOR PRODUCTION IS " + txttotalQty.Text + "";
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

        private void btnlessthan_Click(object sender, EventArgs e)
        {





            if (dgvImport.Rows.Count >= 1)
            {
                int i = dgvImport.CurrentRow.Index + 1;
                if (i >= -1 && i < dgvImport.Rows.Count)
                    dgvImport.CurrentCell = dgvImport.Rows[i].Cells[0];

                else
                {

                    this.dgvImport.CurrentCell = this.dgvImport.Rows[0].Cells[this.dgvImport.CurrentCell.ColumnIndex];
                    bunifuThinButton26_Click(sender, e);
                    //MessageBox.Show("Nasa last Line knaa");
                    return;
                }
                //txttotalQty.Text = (float.Parse(txtQuantity.Text) * float.Parse(txtnobatch.Text)).ToString();//bobo
                double mainbalance;
                double selectquantity;


                mainbalance = double.Parse(txtrepackavailable.Text);
                selectquantity = double.Parse(txttotalQty.Text);
                if (mainbalance < selectquantity)
                {
                    NoBalanceNotify();

                    //this.dgvImport.CurrentCell = this.dgvImport.Rows[0].Cells[this.dgvImport.CurrentCell.ColumnIndex];
                    txtbags.BackColor = Color.Yellow;
                    txtbags.Focus();
                    return;
                }
                else
                {
                    ////MessageBox.Show("Keribels");
                    //txttotalQty.Text = (float.Parse(txtQuantity.Text) * float.Parse(txtnobatch.Text)).ToString();//bobo
                    btnStartingValidation_Click(sender, e);

                }

            }






















        }

        private void bunifuThinButton26_Click(object sender, EventArgs e)
        {





            metroButton1_Click(sender, e);


        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            //if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to save the Production Schedule ? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            //{
            //    //MessageBox.Show("Bolang!");
            //    //mode = "add";


            //    //if (txtnobatch.Text.Trim() == string.Empty)
            //    //{

            //    //}
            //    //else
            //    //{
            //    //    if (saveMode())
            //    //    {

            //    //        string tmode = mode;

            //    //        if (tmode == "add")
            //    //        {


            //    //            //AddedSuccess();
            //    //            //bunifuThinButton29_Click(sender, e);
            //    //            //btnfinishvalidation_Click(sender, e); ///dito muna ang minus querys
            //    //            //Clear();
            //    //            //load_Schedules_approved();
            //    //            //load_Schedules();



            //    //        }
            //    //        else
            //    //        {
            //    //            //dgvMaster.CurrentCell = dgvMaster[0, temp_hid];
            //    //        }

            //    //        /// btnCancel_Click(sender, e);

            //    //    }
            //    //    else
            //    //        MessageBox.Show("Failed");

            //    //}







            //}
            //else
            //{

            //    return;
            //}
        }

        private void btnStartingValidation_Click(object sender, EventArgs e)
        {




            double validation1;
            double validation2;

            validation1 = double.Parse(txtseries.Text);
            validation2 = double.Parse(txtbags.Text);

            if (validation1 < validation2)
            {
                BagvsMixing();
                txtbags.Text = "";
                txtbags.Focus();
                return;
            }
            else
            {

            }












            double mainbalance;
            double selectquantity;


            mainbalance = double.Parse(txtrepackavailable.Text);
            selectquantity = double.Parse(txttotalQty.Text);
            if (mainbalance < selectquantity)
            {
                NoBalanceNotify();


                txtbags.BackColor = Color.Yellow;
                txtbags.Focus();
                return;
            }
            else
            {
                //WithBalanceNotify(); alis muna 4/13/2020
                btnlessthan_Click(sender, e);
                //MessageBox.Show("1");

            }
            load_search();
   



        }

        private void dgvMaster2_CurrentCellChanged(object sender, EventArgs e)
        {
            showRawMatsDataGrid();
        }

        private void dgvImport_CurrentCellChanged(object sender, EventArgs e)
        {

            showImportDataGrid();
        }


        void showImportDataGrid()
        {
        
                if (dgvImport.CurrentRow != null)
                {
                    if (dgvImport.CurrentRow.Cells["recipe_id"].Value != null)
                    {
                        p_id = Convert.ToInt32(dgvImport.CurrentRow.Cells["recipe_id"].Value);
                        txtItemCode.Text = dgvImport.CurrentRow.Cells["item_code"].Value.ToString();
                        txtQuantity.Text = dgvImport.CurrentRow.Cells["quantity2"].Value.ToString();
                        txtitemdescription.Text = dgvImport.CurrentRow.Cells["rp_description"].Value.ToString();
                    txttotalQty.Text = dgvImport.CurrentRow.Cells["quantity1"].Value.ToString();


                }
                }


            //if (textBox2.Text == "2")
            //{

            //}
            //else
            //{


            //    txttotalQty.Text = (float.Parse(txtQuantity.Text) * float.Parse(txtnobatch.Text)).ToString();
            //}
        }

        private void btnsum_Click(object sender, EventArgs e)
        {
            //dgvImport[6, dgvImport.Rows.Count - 1].Value = "Total";
            //dgvImport.Rows[dgvImport.Rows.Count - 1].Cells[0].Style.BackColor = Color.Green;
            //dgvImport.Rows[dgvImport.Rows.Count - 1].Cells[0].Style.ForeColor = Color.Red;
            decimal tot = 0;
            //decimal tot2 = 0;
            decimal batching;
            batching = decimal.Parse(txtnobatch.Text);

            for (int i = 0; i < dgvImport.RowCount - 1; i++)
            {
                var value = dgvImport.Rows[i].Cells["quantity2"].Value;
                if (value != DBNull.Value)
                {
                    tot += Convert.ToDecimal(value) * 2;
         
                }





            }






            if (tot == 0)
            {

            }

   
            lblCountss.Text = tot.ToString();
        }

        private void txtItemCode_TextChanged(object sender, EventArgs e)
        {
            //deploy
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "select a.item_id,a.item_code,a.item_description,a.total_quantity_raw,a.qty_repack_available,a.qty_repack,a.qty_production,ISNULL(t5.RECEIVING,0) + ISNULL(t6.ISSUE,0) - ISNULL(t2.MACRESERVED,0) as RESERVED from [dbo].[rdf_raw_materials] a LEFT JOIN ( select BC.r_item_code, sum(CAST(REPLACE(BC.r_quantity,',','') as float))  as RECEIVING from rdf_microreceiving_entry BC where is_active='1' and BC.transaction_type='PO' group by BC.r_item_code) t5 on a.item_code = t5.r_item_code LEFT JOIN ( select BC.r_item_code, sum(CAST(REPLACE(BC.actual_count_good,',','') as float))  as ISSUE from rdf_microreceiving_entry BC where BC.receiving_status='1' and BC.is_active='1' and BC.transaction_type='Miscellaneous Receipt' group by BC.r_item_code) t6 on a.item_code = t6.r_item_code LEFT JOIN ( select BC.item_code, sum(CAST(BC.quantity as float)* 2)  as MACRESERVED from rdf_recipe_to_production BC where CAST(BC.proddate as date) BETWEEN '2021-01-12' and GETDATE()+30 and status_of_person IS NULL group by BC.item_code) t2 on a.item_code = t2.item_code WHERE a.item_code = '" + txtItemCode.Text + "'";
            //string sqlquery = "select item_id,item_code,item_description,total_quantity_raw,qty_repack_available,qty_repack,qty_production from [dbo].[rdf_raw_materials] WHERE item_code = '" + txtItemCode.Text + "'";
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




            //if (textBox2.Text=="2")
            //{

            //}
            //else
            //{


            //    txttotalQty.Text = (float.Parse(txtQuantity.Text) * float.Parse(txtnobatch.Text)).ToString();
            //}




        }

        private void txtnobatch_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvImport_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dgvImport.Enabled = true;

            btnAdd.ButtonText = "ON CHECKING INVENTORY BELOW " + lblmainItemError.Text + "";
        }

        private void dgvImport_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {
                if (dgvImport.Columns[e.ColumnIndex].Name.ToLower().Contains("qty_production"))
                {
                    if (e.Value.ToString() != "")
                    {
                        double d = double.Parse(e.Value.ToString());
                        e.Value = d.ToString("n0");
                    }
                }
            }




            foreach (DataGridViewRow row in dgvImport.Rows)
            {
                if (Convert.ToDouble(row.Cells["quantity1"].Value) > Convert.ToDouble(row.Cells["qty_production"].Value))
                {
                    //row.Cells["buffer_of_stocks"].Style.BackColor = Color.LightGreen;
                    row.Cells["item_code"].Style.BackColor = Color.LightSalmon;
                    row.Cells["rp_description"].Style.BackColor = Color.LightSalmon;
                    row.Cells["feed_code"].Style.BackColor = Color.LightSalmon;
                    row.Cells["rp_category"].Style.BackColor = Color.LightSalmon;
                    row.Cells["rp_type"].Style.BackColor = Color.LightSalmon;
                    row.Cells["recipe_id"].Style.BackColor = Color.LightSalmon;
                    row.Cells["rp_group"].Style.BackColor = Color.LightSalmon;
                    row.Cells["quantity2"].Style.BackColor = Color.LightSalmon;
                    row.Cells["quantity1"].Style.BackColor = Color.LightSalmon;

                    row.Cells["qty_production"].Style.BackColor = Color.LightSalmon;

                }
                else if (Convert.ToDouble(row.Cells["quantity1"].Value) < Convert.ToDouble(row.Cells["qty_production"].Value))
                {
                    // row.DefaultCellStyle.BackColor = Color.LightSalmon; // Use it in order to colorize all cells of the row

                    //row.Cells["buffer_of_stocks"].Style.BackColor = Color.LightSalmon;
                }
            }












        }

        private void dgvMicroImport_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void dgvMicroImport_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {



            foreach (DataGridViewRow row in dgvMicroImport.Rows)
            {
                if (Convert.ToDouble(row.Cells["quantity10"].Value) > Convert.ToDouble(row.Cells["qty_production2"].Value))
                {
                    //row.Cells["buffer_of_stocks"].Style.BackColor = Color.LightGreen;
                    row.Cells["item_code2"].Style.BackColor = Color.LightSalmon;
                    row.Cells["rp_description2"].Style.BackColor = Color.LightSalmon;
                    row.Cells["feed_code2"].Style.BackColor = Color.LightSalmon;
                    row.Cells["rp_category2"].Style.BackColor = Color.LightSalmon;
                    row.Cells["rp_type2"].Style.BackColor = Color.LightSalmon;
                    row.Cells["recipe_id2"].Style.BackColor = Color.LightSalmon;
                    row.Cells["rp_group2"].Style.BackColor = Color.LightSalmon;
                    row.Cells["quantity5"].Style.BackColor = Color.LightSalmon;
                    row.Cells["quantity10"].Style.BackColor = Color.LightSalmon;

                    row.Cells["qty_production2"].Style.BackColor = Color.LightSalmon;

                }
                else if (Convert.ToDouble(row.Cells["quantity10"].Value) < Convert.ToDouble(row.Cells["qty_production2"].Value))
                {
                    // row.DefaultCellStyle.BackColor = Color.LightSalmon; // Use it in order to colorize all cells of the row

                    //row.Cells["buffer_of_stocks"].Style.BackColor = Color.LightSalmon;
                }
            }




        }
    }
}
