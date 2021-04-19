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
    public partial class frmMaterialUsedOverProductionDate : Form
    {
        String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
        //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
        //    String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true";
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        string sw;

        DataTable dt;
        DataSet ds = new DataSet();
        DataSet dSet_temp = new DataSet();

        myclasses xClass = new myclasses();
        IStoredProcedures objStorProc = null;
        Boolean ready = false;
        DataSet dSet = new DataSet();

        DataSet dSets = new DataSet();

        //string mode = "";
        //int p_id = 0;
        //int temp_hid = 0;
        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();

        //declare as global

        //int nRow;

        public frmMaterialUsedOverProductionDate()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void frmMaterialUsedOverProductionDate_Load(object sender, EventArgs e)
        {
            // Calling the Stored PROC 
            objStorProc = xClass.g_objStoredProc.GetCollections();
            myglobal.global_module = "Active";

            //TotalTheo();
            dSet.Clear();
            //dSet = objStorProc.rdf_sp_prod_schedules(0, txt1.Text, "", "", "", "", "", "", "existsornot");
            dSet = objStorProc.rdf_sp_new_preparation(0, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "updaterecipetoproduction");
            dateTimePicker2_ValueChanged(sender, e);
            dtp2_ValueChanged(sender, e);
            btnlessthan.Enabled = true;
     
            txtuserid.Text = userinfo.user_id.ToString();
        }

        void NodataFound()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "No Data Found!";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80); ;
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


        void QueryOutProduction()
        {

            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            SqlConnection sql_con = new SqlConnection(connetionString);

            //string sqlquery = "UPDATE [dbo].[rdf_recipe_to_production] SET total_qty='" + txtsavetotalqty.Text + "'  WHERE production_id ='" + txtprodid.Text + "' AND item_code='" + txtitemcode.Text + "'";

            string sqlquery = "UPDATE [dbo].[rdf_recipe_to_production] SET total_qty='" + txtsavetotalqty.Text + "',total_prod='" + lbltotalproduction.Text + "',theo_additional_qty='" + txttotalTheo.Text + "',grandtotalrpt='" + txtgrandtotal.Text + "',variance_percentage='" + lblvariancepercentage.Text + "'  WHERE actual_production_date  BETWEEN '" + dateTimePicker2.Text + "' AND '" + dtp2.Text + "' AND item_code='" + txtitemcode.Text + "'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridView3.DataSource = dt;
            //dgvMaster.Visible = true;
            ////dgv_table_2nd_sup.Visible = true;
            //lblmicroview.Visible = true;
            sql_con.Close();
        }


        void DatabaseBusy()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Database is busy another user currently generating the report!";
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
            dSet.Clear();
            dSet = objStorProc.rdf_sp_prod_schedules(0, "", "", "", "", "", "", "", "","","", "","", "formulationbusy");

            if (dSet.Tables[0].Rows.Count > 0)
            {
                //MessageBox.Show("YEs");
                if (txtuserid.Text.Trim() == txtuseridcompare.Text.Trim())
                {

                }
                else
                {
                    DatabaseBusy();  //2
                    return;
                }
            }
            else
            {
      txtuseridcompare.Text = (float.Parse(txtuserid.Text) * 1).ToString();

                //MessageBox.Show("No");

                //return;

            }


            ControlBox = false;

            btnlessthan.Enabled = false;

            if (lblrecords2.Text == "0")
            {
                NodataFound();
                dSet.Clear();
                //dSet = objStorProc.rdf_sp_prod_schedules(0, txt1.Text, "", "", "", "", "", "", "existsornot");
                dSet = objStorProc.rdf_sp_new_preparation(0, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "updaterecipetoproduction");

                return;
            }

            if (lblrecords.Text == "0")
            {
                btnPrint_Click(sender, e);
                //MessageBox.Show("takla");

                picload.Visible = false;
                return;
            }
            else
            {

                picload.Visible = true;
            }

            QuerySearchMaterial2();
            QuerySearchMaterial3();
            //doSearch3();
            TotalTheo();
            dataGridView2_CurrentCellChanged(sender, e);

            double smallvalue;

            smallvalue = double.Parse(txttotalqtynew.Text);

            //if (smallvalue < 1)
            //{

            //MessageBox.Show(txttotalqty.Text);

            //MessageBox.Show(txttotalqtynew.Text);
            //return;

            txtsavetotalqty.Text = (float.Parse(txttotalqty.Text) + float.Parse(txttotalqtynew.Text)).ToString("#,0.000");


   

            txtgrandtotal.Text = (float.Parse(txtsavetotalqty.Text) + float.Parse(txttotalTheo.Text)).ToString("#,0.00"); //lovely



            ///Get the formulation of the variance percentage
            lblformulation.Text = (float.Parse(txtgrandtotal.Text) - float.Parse(txtsavetotalqty.Text)).ToString();

            if (lblcategory.Text == "MACRO")
            {
                lblvariancepercentage.Text = (float.Parse(lblformulation.Text) / float.Parse(txtgrandtotal.Text)).ToString("#,0.000");

                //2

                double sagot;
                double grandtotal;

                double timesanswer;


                sagot = double.Parse(lblvariancepercentage.Text);


                grandtotal = sagot * 100;
                timesanswer = grandtotal / 100;

                lblvariancepercentage.Text = Math.Round(timesanswer, 3).ToString();




                //if(lblvariancepercentage.Text=="label2")
                //{
                //    lblvariancepercentage.Text = "0";
                //}
            }





            //End of Formulation of the variance percentage
            if (lblgroup.Text == "Validate")
            {
                lblvariancepercentage.Text = "0";
            }




            QueryOutProduction();


            lblvariancepercentage.Text = "0";


            if (dataGridView1.Rows.Count >= 1)
            {


                int i = dataGridView1.CurrentRow.Index + 1;
                if (i >= -1 && i < dataGridView1.Rows.Count)
                    dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[1];




                //dgvMaster_Click(sender,e);

                else
                {
                    //LastLine();
                    ////MessageBox.Show("Last LIne");
                    //load_search();
                    //btngreaterthan_Click(sender, e);
                    btnPrint_Click(sender, e);


                    dSet.Clear();
                    //dSet = objStorProc.rdf_sp_prod_schedules(0, txt1.Text, "", "", "", "", "", "", "existsornot");
                    dSet = objStorProc.rdf_sp_new_preparation(0, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "updaterecipetoproductionversion2");
                    txtuseridcompare.Text = "";
                    this.dataGridView1.CurrentCell = this.dataGridView1.Rows[0].Cells[this.dataGridView1.CurrentCell.ColumnIndex];
                    picload.Visible = false;

                    ControlBox = true;
                    return;
                }
            }
            btnreset_Click(sender, e);















        }

        void QuerySearchMaterial()
        {


            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            SqlConnection sql_con = new SqlConnection(connetionString);

            //string sqlquery = "UPDATE [dbo].[rdf_recipe_to_production] SET total_qty='" + txtsavetotalqty.Text + "'  WHERE production_id ='" + txtprodid.Text + "' AND item_code='" + txtitemcode.Text + "'";


            //string sqlquery = "SELECT DISTINCT emp.prod_id,mprep.quantity,emp.proddate as takla,emp.p_nobatch,mprep.item_code,mprep.rp_description,mprep.rp_category,mprep.rp_group,mprep.total_qty,mprep.total_prod,mprep.proddate as proddate1 FROM [dbo].[rdf_production_advance] emp LEFT JOIN [dbo].[rdf_recipe_to_production] mprep ON emp.prod_id=mprep.production_id WHERE emp.proddate BETWEEN '" + dateTimePicker2.Text + "' AND '" + dtp2.Text + "' AND mprep.feed_type IS NULL AND emp.is_selected='1' ORDER BY item_code DESC";

            //string sqlquery = "SELECT DISTINCT emp.prod_id,mprep.quantity,emp.proddate as takla,emp.p_nobatch,mprep.item_code,mprep.rp_description,mprep.rp_category,mprep.rp_group,mprep.total_qty,mprep.total_prod,mprep.proddate as proddate1 FROM [dbo].[rdf_production_advance] emp LEFT JOIN [dbo].[rdf_recipe_to_production] mprep ON emp.prod_id=mprep.production_id WHERE emp.proddate BETWEEN '" + dateTimePicker2.Text + "' AND '" + dtp2.Text + "' AND mprep.feed_type IS NULL AND emp.is_selected='1' ORDER BY item_code DESC";


            string sqlquery = "SELECT DISTINCT emp.prod_id,mprep.quantity,emp.proddate as takla,emp.p_nobatch,mprep.item_code,mprep.rp_description,mprep.rp_category,mprep.rp_group,mprep.total_qty,mprep.total_prod,mprep.proddate as proddate1 FROM [dbo].[rdf_production_advance] emp LEFT JOIN [dbo].[rdf_recipe_to_production] mprep ON emp.prod_id=mprep.production_id WHERE emp.finish_production_date BETWEEN '" + dateTimePicker2.Text + "' AND '" + dtp2.Text + "' AND mprep.feed_type IS NULL AND emp.is_selected='1' AND NOT emp.canceltheapprove IS NOT NULL ORDER BY item_code DESC";


            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridView1.DataSource = dt;
            lblrecords.Text = dataGridView1.RowCount.ToString();
            sql_con.Close();



        }


        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dtp2_ValueChanged(sender, e);
            //load_search();
            QuerySearchMaterial3();
            QuerySearchMaterial();
            Refresh();
            QuerySearchMaterial2();

            //TotalTheo();

            dataGridView1_CurrentCellChanged(sender, e);
            if (lblrecords.Text == "0")
            {

            }
            else
            {

                //txtsavetotalqty.Text = (float.Parse(txttotalqty.Text) - float.Parse(txttotalqtynew.Text)).ToString();
            }






        }


        void QuerySearchMaterial2()
        {

            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            SqlConnection sql_con = new SqlConnection(connetionString);

            //string sqlquery = "UPDATE [dbo].[rdf_recipe_to_production] SET total_qty='" + txtsavetotalqty.Text + "'  WHERE production_id ='" + txtprodid.Text + "' AND item_code='" + txtitemcode.Text + "'";
            //buldit
            string sqlquery = "SELECT DISTINCT emp.prod_id,mprep.quantity,emp.proddate as takla,emp.p_nobatch,mprep.item_code,mprep.rp_description,mprep.rp_category,mprep.rp_group,mprep.total_qty,mprep.total_prod,mprep.proddate as proddate1 FROM [dbo].[rdf_production_advance] emp LEFT JOIN [dbo].[rdf_recipe_to_production] mprep ON emp.prod_id=mprep.production_id WHERE emp.finish_production_date BETWEEN '" + dateTimePicker2.Text + "' AND '" + dtp2.Text + "' AND mprep.item_code='" + txtitemcode.Text + "' AND emp.is_selected='1' AND NOT emp.canceltheapprove IS NOT NULL";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridView2.DataSource = dt;
            lblrecords2.Text = dataGridView2.RowCount.ToString();
            sql_con.Close();
        }

        void QuerySearchMaterial3()
        {


            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            SqlConnection sql_con = new SqlConnection(connetionString);

            //string sqlquery = "UPDATE [dbo].[rdf_recipe_to_production] SET total_qty='" + txtsavetotalqty.Text + "'  WHERE production_id ='" + txtprodid.Text + "' AND item_code='" + txtitemcode.Text + "'";

            //string sqlquery = "	SELECT emp.prod_id,emp.proddate FROM [dbo].[rdf_production_advance] emp WHERE emp.proddate BETWEEN '" + dateTimePicker2.Text + "' AND '" + dtp2.Text + "' AND emp.is_selected='1' AND NOT emp.canceltheapprove IS NOT NULL";



            string sqlquery = "	SELECT DISTINCT emp.prod_id,emp.finish_production_date FROM [dbo].[rdf_production_advance] emp  LEFT JOIN [dbo].[rdf_recipe_to_production] karat ON emp.prod_id=karat.production_id WHERE emp.finish_production_date BETWEEN '" + dateTimePicker2.Text + "' AND '" + dtp2.Text + "' AND karat.item_code='" + txtitemcode.Text + "' AND emp.is_selected='1' AND NOT emp.canceltheapprove IS NOT NULL";

            //            SELECT emp.prod_id,emp.proddate FROM[dbo].[rdf_production_advance] emp LEFT JOIN rdf_recipe_to_production karat ON emp.prod_id=karat.production_id WHERE emp.proddate BETWEEN '7/30/2020' AND '7/30/2020' AND emp.is_selected='1' AND NOT emp.canceltheapprove IS NOT NULL

            //AND karat.item_code= 'MIC0034'




            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridView4.DataSource = dt;
            lbltotalproduction.Text = dataGridView4.RowCount.ToString();
            sql_con.Close();

        }

        void TotalTheo()
        {


            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "	SELECT * FROM [dbo].[rdf_production_pending_theo] emp WHERE emp.date_added BETWEEN '" + dateTimePicker2.Text + "' AND '" + dtp2.Text + "' AND emp.is_active='2' AND item_code ='" + txtitemcode.Text + "'";






            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvTheo.DataSource = dt;

            sql_con.Close();


            //double sum = 0;
            //for (int i = 0; i < dgvTheo.Rows.Count; ++i)
            //{
            //    sum += Convert.ToDouble(dgvTheo.Rows[i].Cells["my_variance"].Value);
            //}

            ////lblCounts.Text = dgvImport.RowCount.ToString();
            //txttotalTheo.Text = sum.ToString();


            decimal tot = 0;

            for (int i = 0; i < dgvTheo.RowCount - 0; i++)
            {
                var value = dgvTheo.Rows[i].Cells["my_variance"].Value;
                if (value != DBNull.Value)
                {
                    tot += Convert.ToDecimal(value);
                }
            }
            if (tot == 0)
            {

            }

            txttotalTheo.Text = tot.ToString("#,0.00");



        }


        void Refresh()
        {
            for (int n = 0; n < (dataGridView1.Rows.Count); n++)
            {
                //double s = Convert.ToDouble(dgvImport.Rows[n].Cells[4].Value);


                //double s1 = Convert.ToDouble(dgvAllFeedCode.Rows[n].Cells[7].Value);

                double s1 = Convert.ToDouble(dataGridView1.Rows[n].Cells[1].Value);
                double s7 = Convert.ToDouble(dataGridView1.Rows[n].Cells[3].Value);
                //int s1 = Convert.ToInt32(dgv1stView.Rows[n].Cells[1].Value);
                //double s13 = s * 2;
                double s15 = s1 * 2;
                double s18 = s7 * s15;

                //dgvImport.Rows[n].Cells[7].Value = s15.ToString("#,0.000");
                dataGridView1.Rows[n].Cells[1].Value = s15.ToString();


                dataGridView1.Rows[n].Cells[10].Value = s18.ToString();
                //dgvAllFeedCode.Rows[n].Cells[7].Value = s15.ToString("#,0.000");
            }
        }



        private void dtp2_ValueChanged(object sender, EventArgs e)
        {
            QuerySearchMaterial3();
            QuerySearchMaterial();
            Refresh();
            QuerySearchMaterial2();


            TotalTheo();
            dataGridView1_CurrentCellChanged(sender, e);
            if (lblrecords.Text == "0")
            {

            }
            else
            {

                //txtsavetotalqty.Text = (float.Parse(txttotalqty.Text) - float.Parse(txttotalqtynew.Text)).ToString();
            }

        }

        private void dataGridView2_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataGridView2.RowCount > 0)
            {
                if (dataGridView2.CurrentRow != null)
                {
                    if (dataGridView2.CurrentRow.Cells["item_code"].Value != null)
                    {
                        //p_id = Convert.ToInt32(dataView.CurrentRow.Cells["prod_id"].Value);
                        lblcategory.Text = dataGridView2.CurrentRow.Cells["rp_category"].Value.ToString();
                        lblgroup.Text = dataGridView2.CurrentRow.Cells["rp_group"].Value.ToString();

                        txttotalqtynew.Text = dataGridView2.CurrentRow.Cells["total_qty"].Value.ToString();
                        txtdescription.Text = dataGridView2.CurrentRow.Cells["rp_description"].Value.ToString();
                        //txtprodid.Text = dataGridView2.CurrentRow.Cells["production_id"].Value.ToString();
                    }

                }
            }




        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                if (dataGridView1.CurrentRow != null)
                {
                    if (dataGridView1.CurrentRow.Cells["item_code"].Value != null)
                    {
                        //p_id = Convert.ToInt32(dataView.CurrentRow.Cells["prod_id"].Value);

                        txtproddate.Text = dataGridView1.CurrentRow.Cells["takla"].Value.ToString();
                        txttotalqty.Text = dataGridView1.CurrentRow.Cells["proddate1"].Value.ToString();
                        /*                        txttotalqty.Text = dataGridView1.CurrentRow.Cells["quantity"].Value.ToString()*/
                        //;
                        txtitemcode.Text = dataGridView1.CurrentRow.Cells["item_code"].Value.ToString();


                    }

                }
            }




        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            btnlessthan_Click(sender, e);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            myglobal.DATE_REPORT = dateTimePicker2.Text;
            myglobal.DATE_REPORT2 = dtp2.Text;
            //myglobal.REPORT_NAME = "DailyProductionSchedule";
            myglobal.REPORT_NAME = "FGMicroMaterialUsedProd";



            frmReport fr = new frmReport();
            fr.WindowState = FormWindowState.Maximized;
            fr.Show();
            frmMaterialUsedOverProductionDate_Load(sender, e);
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txttotalqty_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnGenerateMicro_Click(object sender, EventArgs e)
        {
            myglobal.DATE_REPORT = dtp10.Text;
            myglobal.DATE_REPORT2 = dtp20.Text;
            //myglobal.REPORT_NAME = "DailyProductionSchedule";
            myglobal.REPORT_NAME = "MicroMaterialUsedNewProd";



            frmReport fr = new frmReport();
            fr.WindowState = FormWindowState.Maximized;
            fr.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myglobal.DATE_REPORT = dtp10.Text;
            myglobal.DATE_REPORT2 = dtp20.Text;
            //myglobal.REPORT_NAME = "DailyProductionSchedule";
            myglobal.REPORT_NAME = "MacroMaterialUsedNewProd";



            frmReport fr = new frmReport();
            fr.WindowState = FormWindowState.Maximized;
            fr.Show();
        }
    }
}
