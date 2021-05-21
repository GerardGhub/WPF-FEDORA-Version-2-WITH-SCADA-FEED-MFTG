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
    public partial class frmAnotherReports : Form
    {




        DataSet dSet_temp = new DataSet();

        myclasses xClass = new myclasses();
        IStoredProcedures objStorProc = null;
        Boolean ready = false;
        DataSet dSet = new DataSet();

        DataSet dSets = new DataSet();


        //int p_id = 0;

        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();

        //declare as global



        public frmAnotherReports()
        {
            InitializeComponent();
        }

        private void btndailyprod_Click(object sender, EventArgs e)
        {
            myglobal.DATE_REPORT = dtpprod1.Text;
            myglobal.DATE_REPORT2 = dtpprod2.Text;
            //myglobal.REPORT_NAME = "DailyProductionSchedule";
            myglobal.REPORT_NAME = "ProductionPlanning";



            frmReport fr = new frmReport();

            fr.WindowState = FormWindowState.Maximized;
            fr.Show();
        }



        void NodataFound()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "No Data Found!!";
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


        void final()
        {

            //PopupNotifier popup = new PopupNotifier();
            //popup.Image = Properties.Resources.info;
            //popup.TitleText = "Fedora Notifications";
            //popup.TitleColor = Color.White;
            //popup.TitlePadding = new Padding(95, 7, 0, 0);
            //popup.TitleFont = new Font("Tahoma", 10);
            //popup.ContentText = "Validating Micro Materials Please wait...";
            //popup.ContentColor = Color.White;
            //popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            //popup.Size = new Size(350, 100);
            //popup.ImageSize = new Size(70, 80); ;
            //popup.BodyColor = Color.CornflowerBlue;
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



        }











        private void button2_Click(object sender, EventArgs e)
        {



        }

        private void btnlessthan_Click(object sender, EventArgs e)
        {
            btnlessthan.BackColor = Color.Red;
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
                return;
            }
            else
            {

                //picload.Visible = true;
            }


            QuerySearchMaterial2();
            QuerySearchMaterial3();

            checkyMyTheorotical();


            dataGridView1_CurrentCellChanged(sender, e);
            dataGridView2_CurrentCellChanged(sender, e);

            dgvTheoQuery_CurrentCellChanged(sender,e);

            TotalTheo();
            txtsavetotalqty.Text = (float.Parse(txttotalqty.Text) + float.Parse(txttotalqtynew.Text)).ToString("#,0.00");//

            //txtsavetotalqty.Text = (float.Parse(txttotalqty.Text) + float.Parse(txttotalqtynew.Text)).ToString("#,0.000");//buje
            //txtgrandtotal.Text = (float.Parse(txtsavetotalqty.Text) + float.Parse(txttotalTheo.Text)).ToString();


            QueryOutProduction();



            //MessageBox.Show("OK");

            lbltitle.Text = dataGridView1.CurrentRow.Cells["rp_item_code"].Value.ToString();

     


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
    
                    //btngreaterthan_Click(sender, e);
                    btnPrint_Click(sender, e);


                    dSet.Clear();
                    //dSet = objStorProc.rdf_sp_prod_schedules(0, txt1.Text, "", "", "", "", "", "", "existsornot");
                    dSet = objStorProc.rdf_sp_new_preparation(0, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "updaterecipetoproductionversion2");




                    this.dataGridView1.CurrentCell = this.dataGridView1.Rows[0].Cells[this.dataGridView1.CurrentCell.ColumnIndex];
                    //picload.Visible = false;
                    btnlessthan.BackColor = Color.White;
                    btnlessthan.Enabled = true;

                    ControlBox = true;

                    return;
                }
            }



        //    if (dgvTheoQuery.Rows.Count >= 1)
        //    {

        //        //MessageBox.Show("OK");

        //        int i = dgvTheoQuery.CurrentRow.Index + 1;
        //        if (i >= -1 && i < dgvTheoQuery.Rows.Count)
        //            dgvTheoQuery.CurrentCell = dgvTheoQuery.Rows[i].Cells[1];




        //        //dgvMaster_Click(sender,e);

        //        else
        //        {

        //            //this.dgvTheoQuery.CurrentCell = this.dgvTheoQuery.Rows[0].Cells[this.dgvTheoQuery.CurrentCell.ColumnIndex];

        //            lbltheoitemcode.Text = "";
        //        checkyMyTheorotical();


     
        //        dgvTheoQuery_CurrentCellChanged(sender, e);

        //        //    //return;
        //    }
        //}

















            btnreset_Click(sender, e);





















        }


        void OutProd()
        {


            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            SqlConnection sql_con = new SqlConnection(connetionString);

            //string sqlquery = "UPDATE [dbo].[rdf_recipe_to_production] SET total_qty='" + txtsavetotalqty.Text + "'  WHERE production_id ='" + txtprodid.Text + "' AND item_code='" + txtitemcode.Text + "'";

            //string sqlquery = "UPDATE [dbo].[rdf_recipe_to_production] SET total_qty='" + txtsavetotalqty.Text + "',total_prod='" + lbltotalproduction.Text + "',theo_additional_qty='" + txttotalTheo.Text + "',grandtotalrpt='" + txtgrandtotal.Text + "'  WHERE proddate  BETWEEN '" + dateTimePicker2.Text + "' AND '" + dtp2.Text + "' AND item_code='" + txtitemcode.Text + "'";

            //string sqlquery = "UPDATE [dbo].[rdf_recipe_to_production] SET total_qty='" + txtsavetotalqty.Text + "',total_prod='" + lbltotalproduction.Text + "',theo_additional_qty='" + txttotalTheo.Text + "',grandtotalrpt='" + txtgrandtotal.Text + "' WHERE item_code='" + txtitemcode.Text + "'";



            string sqlquery = "UPDATE [dbo].[rdf_recipe_to_production] SET total_qty='" + txtsavetotalqty.Text + "', total_prod='"+lbltotaltheoprod.Text+"', theo_additional_qty ='"+txtgrandtotalvariance.Text+"',grandtotalrpt='"+lblsum.Text+ "', variance_percentage='"+lblvariancepercentage.Text+"' WHERE item_code='" + lbltheoitemcode.Text + "'";

            



            //string sqlquery = "UPDATE [dbo].[rdf_recipe_to_production] SET total_qty='" + txtsavetotalqty.Text + "',total_prod='" + lbltotalproduction.Text + "',theo_additional_qty='" + txttotalTheo.Text + "',grandtotalrpt='" + txtgrandtotal.Text + "'  WHERE proddate='" + txtproddate.Text + "' AND item_code='" + txtitemcode.Text + "' AND production_id='" + lblprodid.Text + "'";


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


        void QueryOutProduction()
        {

            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            SqlConnection sql_con = new SqlConnection(connetionString);

            //string sqlquery = "UPDATE [dbo].[rdf_recipe_to_production] SET total_qty='" + txtsavetotalqty.Text + "'  WHERE production_id ='" + txtprodid.Text + "' AND item_code='" + txtitemcode.Text + "'";

            //string sqlquery = "UPDATE [dbo].[rdf_recipe_to_production] SET total_qty='" + txtsavetotalqty.Text + "',total_prod='" + lbltotalproduction.Text + "',theo_additional_qty='" + txttotalTheo.Text + "',grandtotalrpt='" + txtgrandtotal.Text + "'  WHERE proddate  BETWEEN '" + dateTimePicker2.Text + "' AND '" + dtp2.Text + "' AND item_code='" + txtitemcode.Text + "'";

            //string sqlquery = "UPDATE [dbo].[rdf_recipe_to_production] SET total_qty='" + txtsavetotalqty.Text + "',total_prod='" + lbltotalproduction.Text + "',theo_additional_qty='" + txttotalTheo.Text + "',grandtotalrpt='" + txtgrandtotal.Text + "' WHERE item_code='" + txtitemcode.Text + "'";



            string sqlquery = "UPDATE [dbo].[rdf_recipe_to_production] SET total_qty='" + txtsavetotalqty.Text + "',total_prod='" + lbltotalproduction.Text + "' WHERE item_code='" + txtitemcode.Text + "'";





            //string sqlquery = "UPDATE [dbo].[rdf_recipe_to_production] SET total_qty='" + txtsavetotalqty.Text + "',total_prod='" + lbltotalproduction.Text + "',theo_additional_qty='" + txttotalTheo.Text + "',grandtotalrpt='" + txtgrandtotal.Text + "'  WHERE proddate='" + txtproddate.Text + "' AND item_code='" + txtitemcode.Text + "' AND production_id='" + lblprodid.Text + "'";


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










        void TotalTheo()
        {


            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "	SELECT * FROM [dbo].[rdf_production_pending_theo] emp WHERE emp.is_active='2' AND emp.item_code ='"+lbltheoitemcode.Text+"' AND emp.prod_id='"+lblprodid.Text+"'";



            //string sqlquery = "	SELECT * FROM [dbo].[rdf_production_pending_theo] emp WHERE emp.production_date BETWEEN '" + dateTimePicker2.Text + "' AND '" + dtp2.Text + "' AND emp.is_active='2' AND item_code ='" + txtitemcode.Text + "'";



            //pek


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

            txttotalTheo.Text = tot.ToString();



        }






        void QuerySearchMaterial2()
        {

            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            SqlConnection sql_con = new SqlConnection(connetionString);

            //string sqlquery = "UPDATE [dbo].[rdf_recipe_to_production] SET total_qty='" + txtsavetotalqty.Text + "'  WHERE production_id ='" + txtprodid.Text + "' AND item_code='" + txtitemcode.Text + "'";
            //buldit
            //////  old string sqlquery = "SELECT emp.prod_id,emp.proddate as takla,emp.p_nobatch,rpk.rp_item_code,rpk.rp_item_description,rpk.rp_item_category,rpk.total_repack,rpk.production_date as proddate1 FROM [dbo].[rdf_production_advance] emp LEFT JOIN rdf_repackin_entry rpk ON emp.prod_id=rpk.prod_id_repack WHERE rpk.uniquedate BETWEEN '" + dateTimePicker2.Text + "' AND '" + dtp2.Text + "' AND rpk.rp_item_code='" + txtitemcode.Text + "' AND emp.is_selected='1' AND NOT emp.canceltheapprove IS NOT NULL";

            string sqlquery = "SELECT DISTINCT emp.prod_id,mprep.quantity,emp.proddate as takla,emp.p_nobatch,mprep.item_code,mprep.rp_description,mprep.rp_category,mprep.rp_group,mprep.total_qty,mprep.total_prod,mprep.proddate as proddate1 FROM [dbo].[rdf_production_advance] emp LEFT JOIN [dbo].[rdf_recipe_to_production] mprep ON emp.prod_id=mprep.production_id WHERE mprep.proddate ='" +txtproddate.Text+"' AND mprep.production_id='"+lblprodid.Text+"' AND mprep.item_code='" + txtitemcode.Text + "' AND emp.is_selected='1' AND NOT emp.canceltheapprove IS NOT NULL";


            ///3

            //string sqlquery = "SELECT DISTINCT emp.prod_id,mprep.quantity,emp.proddate as takla,emp.p_nobatch,mprep.item_code,mprep.rp_description,mprep.rp_category,mprep.rp_group,mprep.total_qty,mprep.total_prod,mprep.proddate as proddate1 FROM [dbo].[rdf_production_advance] emp LEFT JOIN [dbo].[rdf_recipe_to_production] mprep ON emp.prod_id=mprep.production_id LEFT JOIN rdf_repackin_entry rpk ON emp.prod_id=rpk.prod_id_repack WHERE rpk.uniquedate BETWEEN '" + dateTimePicker2.Text + "' AND '" + dtp2.Text + "' AND mprep.item_code='" + txtitemcode.Text + "' AND emp.is_selected='1' AND NOT emp.canceltheapprove IS NOT NULL";

            ////string sqlquery = "SELECT DISTINCT emp.prod_id,mprep.quantity,emp.proddate as takla,emp.p_nobatch,mprep.item_code,mprep.rp_description,mprep.rp_category,mprep.rp_group,mprep.total_qty,mprep.total_prod,mprep.proddate as proddate1 FROM [dbo].[rdf_production_advance] emp LEFT JOIN [dbo].[rdf_recipe_to_production] mprep ON emp.prod_id=mprep.production_id WHERE emp.proddate BETWEEN '" + dateTimePicker2.Text + "' AND '" + dtp2.Text + "' AND mprep.item_code='" + txtitemcode.Text + "' AND emp.is_selected='1' AND NOT emp.canceltheapprove IS NOT NULL";
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


            string sqlquery = "	SELECT DISTINCT emp.prod_id,emp.proddate FROM [dbo].[rdf_production_advance] emp LEFT JOIN rdf_repackin_entry rpk ON emp.prod_id=rpk.prod_id_repack  WHERE CAST(rpk.uniquedate as date) BETWEEN '" + dateTimePicker2.Text + "' AND '" + dtp2.Text + "' AND rpk.rp_item_code='" + txtitemcode.Text + "' AND emp.is_selected='1' AND NOT emp.canceltheapprove IS NOT NULL";
            //string sqlquery = "	SELECT DISTINCT emp.prod_id,emp.proddate FROM [dbo].[rdf_production_advance] emp  LEFT JOIN [dbo].[rdf_recipe_to_production] karat ON emp.prod_id=karat.production_id WHERE emp.proddate BETWEEN '" + dateTimePicker2.Text + "' AND '" + dtp2.Text + "' AND karat.item_code='" + txtitemcode.Text + "' AND emp.is_selected='1' AND NOT emp.canceltheapprove IS NOT NULL";





            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridView4.DataSource = dt;
            lbltotalproduction.Text = dataGridView4.RowCount.ToString();
            sql_con.Close();
        }





        void QueryTheoProd()
        {

            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            SqlConnection sql_con = new SqlConnection(connetionString);

            //string sqlquery = "UPDATE [dbo].[rdf_recipe_to_production] SET total_qty='" + txtsavetotalqty.Text + "'  WHERE production_id ='" + txtprodid.Text + "' AND item_code='" + txtitemcode.Text + "'";

            //string sqlquery = "	SELECT emp.prod_id,emp.proddate FROM [dbo].[rdf_production_advance] emp WHERE emp.proddate BETWEEN '" + dateTimePicker2.Text + "' AND '" + dtp2.Text + "' AND emp.is_selected='1' AND NOT emp.canceltheapprove IS NOT NULL";


            //string sqlquery = "	SELECT DISTINCT emp.prod_id,emp.proddate FROM [dbo].[rdf_production_advance] emp LEFT JOIN rdf_repackin_entry rpk ON emp.prod_id=rpk.prod_id_repack  WHERE rpk.uniquedate BETWEEN '" + dateTimePicker2.Text + "' AND '" + dtp2.Text + "' AND rpk.rp_item_code='" + lbltheoitemcode.Text + "' AND emp.is_selected='1' AND NOT emp.canceltheapprove IS NOT NULL";



            string sqlquery = "SELECT DISTINCT emp.prod_id,emp.proddate FROM [dbo].[rdf_production_advance] emp LEFT JOIN rdf_production_pending_theo rpk ON emp.prod_id=rpk.prod_id LEFT JOIN rdf_repackin_entry ax On emp.prod_id=ax.prod_id_repack WHERE rpk.item_code='" + lbltheoitemcode.Text + "' AND CAST(ax.uniquedate as date) BETWEEN '"+dateTimePicker2.Text+"' AND '"+dtp2.Text+"' AND emp.is_selected='1' AND NOT emp.canceltheapprove IS NOT NULL";




            //string sqlquery = "	SELECT DISTINCT emp.prod_id,emp.proddate FROM [dbo].[rdf_production_advance] emp  LEFT JOIN [dbo].[rdf_recipe_to_production] karat ON emp.prod_id=karat.production_id WHERE emp.proddate BETWEEN '" + dateTimePicker2.Text + "' AND '" + dtp2.Text + "' AND karat.item_code='" + txtitemcode.Text + "' AND emp.is_selected='1' AND NOT emp.canceltheapprove IS NOT NULL";

            //            SELECT emp.prod_id,emp.proddate FROM[dbo].[rdf_production_advance] emp LEFT JOIN rdf_recipe_to_production karat ON emp.prod_id=karat.production_id WHERE emp.proddate BETWEEN '7/30/2020' AND '7/30/2020' AND emp.is_selected='1' AND NOT emp.canceltheapprove IS NOT NULL

            //AND karat.item_code= 'MIC0034'




            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridView4.DataSource = dt;
            lbltotaltheoprod.Text = dataGridView4.RowCount.ToString();
            sql_con.Close();
        }





        private void btnPrint_Click(object sender, EventArgs e)
        {

            myglobal.DATE_REPORT = dateTimePicker2.Text;
            myglobal.DATE_REPORT2 = dtp2.Text;
            //myglobal.REPORT_NAME = "DailyProductionSchedule";
            myglobal.REPORT_NAME = "FGMicroMaterialUsedRepacking";



            frmReport fr = new frmReport();
            fr.WindowState = FormWindowState.Maximized;
            fr.Show();







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


                        txttotalqtynew.Text = dataGridView2.CurrentRow.Cells["total_qty"].Value.ToString();
                        txtdescription.Text = dataGridView2.CurrentRow.Cells["rp_description"].Value.ToString();
                        //txtprodid.Text = dataGridView2.CurrentRow.Cells["production_id"].Value.ToString();
                    }

                }
            }


        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            btnlessthan_Click(sender, e);
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dtp2_ValueChanged(sender, e);

            QuerySearchMaterial3();
            QuerySearchMaterial();
            //Refresh();
            QuerySearchMaterial2();

            checkyMyTheorotical();



            dgvTheoQuery_CurrentCellChanged(sender, e);
            TotalTheo();

    

            dataGridView1_CurrentCellChanged(sender, e);
            dataGridView2_CurrentCellChanged(sender, e);
            firstQuery();
            //ShowRecipe();

            if (lblrecords.Text == "0")
            {

            }
            else
            {

                //txtsavetotalqty.Text = (float.Parse(txttotalqty.Text) - float.Parse(txttotalqtynew.Text)).ToString();
            }







        }







        void QuerySearchMaterial()
        {


            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "SELECT emp.prod_id,rpk.total_repack,emp.proddate as takla,emp.p_nobatch,rpk.rp_item_code,rpk.rp_item_description,rpk.rp_item_category,rpk.production_date as proddate1 FROM [dbo].[rdf_production_advance] emp LEFT JOIN rdf_repackin_entry rpk ON emp.prod_id = rpk.prod_id_repack WHERE CAST(rpk.uniquedate as date) BETWEEN '"+dateTimePicker2.Text+"' AND '"+dtp2.Text+ "' AND emp.is_selected='1' AND NOT emp.canceltheapprove IS NOT NULL AND emp.end_micro_repacking IS NOT NULL ORDER BY emp.prod_id DESC";



            //string sqlquery = "SELECT DISTINCT emp.prod_id,mprep.quantity,emp.proddate as takla,emp.p_nobatch,mprep.item_code,mprep.rp_description,mprep.rp_category,mprep.rp_group,mprep.total_qty,mprep.total_prod,mprep.proddate as proddate1 FROM [dbo].[rdf_production_advance] emp LEFT JOIN [dbo].[rdf_recipe_to_production] mprep ON emp.prod_id=mprep.production_id LEFT JOIN rdf_repackin_entry rpk ON emp.prod_id = rpk.prod_id_repack WHERE rpk.uniquedate BETWEEN '" + dateTimePicker2.Text + "' AND '" + dtp2.Text + "' AND mprep.feed_type IS NULL AND emp.is_selected='1' AND NOT emp.canceltheapprove IS NOT NULL ORDER BY item_code DESC";



            //string sqlquery = "SELECT DISTINCT emp.prod_id,mprep.quantity,emp.proddate as takla,emp.p_nobatch,mprep.item_code,mprep.rp_description,mprep.rp_category,mprep.rp_group,mprep.total_qty,mprep.total_prod,mprep.proddate as proddate1 FROM [dbo].[rdf_production_advance] emp LEFT JOIN [dbo].[rdf_recipe_to_production] mprep ON emp.prod_id=mprep.production_id WHERE emp.proddate BETWEEN '" + dateTimePicker2.Text + "' AND '" + dtp2.Text + "' AND mprep.feed_type IS NULL AND emp.is_selected='1' AND NOT emp.canceltheapprove IS NOT NULL ORDER BY item_code DESC";


            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridView1.DataSource = dt;
            lblrecords.Text = dataGridView1.RowCount.ToString();
            sql_con.Close();


  
        }



        void firstQuery()
        {



            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "SELECT DISTINCT emp.prod_id,emp.proddate as takla,emp.p_nobatch FROM [dbo].[rdf_production_advance] emp LEFT JOIN rdf_repackin_entry rpk ON emp.prod_id = rpk.prod_id_repack WHERE CAST(rpk.uniquedate as date) BETWEEN '" + dateTimePicker2.Text + "' AND '" + dtp2.Text + "' AND emp.is_selected='1' AND NOT emp.canceltheapprove IS NOT NULL AND emp.end_micro_repacking IS NOT NULL ORDER BY emp.prod_id DESC";




            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvDuplicate.DataSource = dt;

            sql_con.Close();





        }

        void checkyMyTheorotical()
        {



            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            SqlConnection sql_con = new SqlConnection(connetionString);



     


            string sqlquery = "SELECT DISTINCT emp.prod_id,mprep.quantity,emp.proddate as takla,emp.p_nobatch,mprep.item_code,mprep.rp_description,mprep.rp_category,mprep.rp_group,mprep.total_qty,mprep.total_prod,mprep.proddate as proddate1 FROM [dbo].[rdf_production_advance] emp LEFT JOIN [dbo].[rdf_recipe_to_production] mprep ON emp.prod_id=mprep.production_id WHERE mprep.production_id='"+lblprodid.Text+ "' AND (mprep.rp_group='Theoretical1' OR mprep.rp_group='Theoretical2') AND emp.is_selected='1' AND NOT emp.canceltheapprove IS NOT NULL ORDER BY emp.prod_id DESC";



            sql_con.Open();            //lblrecords.Text = dataGridView1.RowCount.ToString();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
          dgvTheoQuery.DataSource = dt;
            lbltotalTheo.Text = dgvTheoQuery.RowCount.ToString();
            sql_con.Close();






        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                if (dataGridView1.CurrentRow != null)
                {
                    if (dataGridView1.CurrentRow.Cells["rp_item_code"].Value != null)
                    {
                        //p_id = Convert.ToInt32(dataView.CurrentRow.Cells["prod_id"].Value);

                        txtproddate.Text = dataGridView1.CurrentRow.Cells["takla"].Value.ToString();
                        //txttotalqty.Text = dataGridView1.CurrentRow.Cells["proddate1"].Value.ToString();

                        //txtproddate.Text = dataGridView1.CurrentRow.Cells["takla"].Value.ToString();
                        txttotalqty.Text = dataGridView1.CurrentRow.Cells["total_repack"].Value.ToString();
                        txtitemcode.Text = dataGridView1.CurrentRow.Cells["rp_item_code"].Value.ToString();


                    }

                }
            }
        }

        private void dtp2_ValueChanged(object sender, EventArgs e)
        {

            QuerySearchMaterial3();
            QuerySearchMaterial();
            //Refresh();
            QuerySearchMaterial2();


            TotalTheo();
            dataGridView1_CurrentCellChanged(sender, e);
            firstQuery();
            if (lblrecords.Text == "0")
            {

            }
            else
            {

                //txtsavetotalqty.Text = (float.Parse(txttotalqty.Text) - float.Parse(txttotalqtynew.Text)).ToString();
            }


        }

        private void frmAnotherReports_Load(object sender, EventArgs e)
        {
            lblnumberbasis.Text = "0";
            // Calling the Stored PROC 
            objStorProc = xClass.g_objStoredProc.GetCollections();
            myglobal.global_module = "Active";

            //TotalTheo();
            dSet.Clear();
            //dSet = objStorProc.rdf_sp_prod_schedules(0, txt1.Text, "", "", "", "", "", "", "existsornot");
            dSet = objStorProc.rdf_sp_new_preparation(0, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "updaterecipetoproduction");


            if (myglobal.rep_gen == "MaterialUsedRepacking")
            {

                panel7.Visible = true;
                panel300.Visible = false;
                panel300.SendToBack();
                panel7.BringToFront();
            }
            else
            {
                panel300.Visible = true;
                panel7.Visible = false;
            }
        }


        private void dataGridView1_CurrentCellChanged_1(object sender, EventArgs e)
        {

            if (dataGridView1.RowCount > 0)
            {
                if (dataGridView1.CurrentRow != null)
                {
                    if (dataGridView1.CurrentRow.Cells["rp_item_code"].Value != null)
                    {
                        //p_id = Convert.ToInt32(dataView.CurrentRow.Cells["prod_id"].Value);

                        txtproddate.Text = dataGridView1.CurrentRow.Cells["takla"].Value.ToString();
                        //txttotalqty.Text = dataGridView1.CurrentRow.Cells["proddate1"].Value.ToString();

                        txttotalqty.Text = dataGridView1.CurrentRow.Cells["total_repack"].Value.ToString();
                        txtitemcode.Text = dataGridView1.CurrentRow.Cells["rp_item_code"].Value.ToString();
                        lblprodid.Text = dataGridView1.CurrentRow.Cells["prod_id"].Value.ToString();

                    }

                }
            }






        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            //QuerySearchMaterial();
            //dataGridView1_CurrentCellChanged(sender, e);



            dgvDuplicate_CurrentCellChanged(sender, e); // lbltheoitemcode textbox binding
            lblprodid.Text = dgvDuplicate.CurrentRow.Cells["prod_id"].Value.ToString();
            //checkyMyTheorotical();

            //TotalTheo();   // get tyhe total production schedule  alis muna


            dgvTheoQuery_CurrentCellChanged(sender, e);


            ShowRecipe();  // show rdf_recipe_tro_productiontablle active based in formulation



            myFormulation();  //get recipe _to _production


            QueryTheoProd();
            dgvformulation_CurrentCellChanged(sender, e);







            lbldata2.Text = dgvformulation.CurrentRow.Cells["total_qty"].Value.ToString();


          //  txtsavetotalqty.Text = (float.Parse(txttotalrecipe.Text) + float.Parse(lbldata2.Text)).ToString("#,##0");
            txtsavetotalqty.Text = (float.Parse(txttotalrecipe.Text) + float.Parse(lbldata2.Text)).ToString("#,0.00");




           // double savetotalqty;




           // savetotalqty = double.Parse(txtsavetotalqty.Text);




           //txtsavetotalqty.Text = Math.Round(savetotalqty, 3).ToString();










            txtgrandtotalvariance.Text = (float.Parse(lbltotalvariance.Text) + float.Parse(lblrecipevariance.Text)).ToString("#,0.00");//



            lblsum.Text = (float.Parse(txtsavetotalqty.Text) + float.Parse(txtgrandtotalvariance.Text)).ToString("#,0.00");//


            //lblsum.Text = (float.Parse(lblsumofgrand.Text) + float.Parse(txttotalTheograndtotal.Text)).ToString();


          lblvariancepercentage.Text = (float.Parse(txtgrandtotalvariance.Text) / float.Parse(lblsum.Text)).ToString("#,0.000");


            //Formulation of the variance percentage

            double sagot;
            double grandtotal;

            //sagot = double.Parse(lblvariancepercentage.Text);


            //grandtotal = sagot * 100;


            //lblvariancepercentage.Text = Math.Round(grandtotal, 1).ToString();


            double timesanswer;


            sagot = double.Parse(lblvariancepercentage.Text);


            grandtotal = sagot * 100;
            timesanswer = grandtotal / 100;

            lblvariancepercentage.Text = Math.Round(timesanswer, 3).ToString();



            OutProd();
            //clear cache data!
            txttotalrecipe.Text = "0";

            lbldata2.Text = "0";

            //MessageBox.Show("Karrie " + lbltheoitemcode.Text + "");


            lbldata1.Text = dgvTheoQuery.CurrentRow.Cells["item_code"].Value.ToString();



            if (dgvTheoQuery.Rows.Count >= 1)
            {
              

                int i = dgvTheoQuery.CurrentRow.Index + 1;
                if (i >= -1 && i < dgvTheoQuery.Rows.Count)
                  dgvTheoQuery.CurrentCell = dgvTheoQuery.Rows[i].Cells[1];


                else
                {





                    //lblnumberbasis.Text = "1";  // next dgvduplicate row
                    //MessageBox.Show("break line");
                    //button2_Click_1(sender, e); // alis muna 9/17/2020

                    //executePrintingTheo();


                    //gaga

                    if (dgvDuplicate.Rows.Count >= 1)
                    {


                        int i2 = dgvDuplicate.CurrentRow.Index + 1;
                        if (i2 >= -1 && i2 < dgvDuplicate.Rows.Count)
                            dgvDuplicate.CurrentCell = dgvDuplicate.Rows[i2].Cells[1];











                        //dgvMaster_Click(sender,e);

                        else
                        {

                            //this.dgvDuplicate.CurrentCell = this.dgvDuplicate.Rows[0].Cells[this.dgvDuplicate.CurrentCell.ColumnIndex];

                            //lbltheoitemcode.Text = "";
                            //MessageBox.Show("Ogre");

                            btnsubclick_Click(new object(), new System.EventArgs());


                            //MessageBox.Show("Please wait for the final");
                            final();
                            btnlessthan_Click(new object(), new System.EventArgs());

                            return;
                        }
                    }

                    checkyMyTheorotical();    // view dgvquery based on production id

                    //TotalTheo(); alis muna 9/16
                    dgvTheoQuery_CurrentCellChanged(new object(), new System.EventArgs());














                    dgvDuplicate_CurrentCellChanged(sender, e);













                    ////this.dgvTheoQuery.CurrentCell = this.dgvTheoQuery.Rows[0].Cells[this.dgvTheoQuery.CurrentCell.ColumnIndex];

                    //lbltheoitemcode.Text = "";
                    //lbltheoitemcode.Text = "";

                    //return;
                }
            }





            dgvDuplicate_CurrentCellChanged(sender, e);
            btnrefreshbtn1_Click(sender, e);








        }

        private void dgvTheoQuery_CurrentCellChanged(object sender, EventArgs e)
        {



            if (dgvTheoQuery.RowCount > 0)
            {
                if (dgvTheoQuery.CurrentRow != null)
                {
                    if (dgvTheoQuery.CurrentRow.Cells["item_code"].Value != null)
                    {
                        //p_id = Convert.ToInt32(dataView.CurrentRow.Cells["prod_id"].Value);


             lbltheoitemcode.Text = dgvTheoQuery.CurrentRow.Cells["item_code"].Value.ToString();


                    }

                }
            }






        }

        private void txttotalTheo_TextChanged(object sender, EventArgs e)
        {
    
        }

        private void lbltheoitemcode_TextChanged(object sender, EventArgs e)
        {
            TotalTheo();
            
        }


        void myFormulation()
        {

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "	SELECT * FROM [dbo].[rdf_recipe_to_production] WHERE item_code='" + lbltheoitemcode.Text + "'";





            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
           dgvformulation.DataSource = dt;

            sql_con.Close();


        }


        void ShowRecipe()
        {


            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "	SELECT  a.prod_id,a.item_code,a.actual_qty_needed,a.my_variance FROM [dbo].[rdf_production_pending_theo] a WHERE a.prod_id='" + lblprodid.Text+"' AND a.item_code='"+lbltheoitemcode.Text+"' AND a.is_active='2'";






            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvrecipe.DataSource = dt;

            lblrecipecount.Text = dgvrecipe.RowCount.ToString();

            sql_con.Close();


            //double sum = 0;
            //for (int i = 0; i < dgvTheo.Rows.Count; ++i)
            //{
            //    sum += Convert.ToDouble(dgvTheo.Rows[i].Cells["my_variance"].Value);
            //}

            ////lblCounts.Text = dgvImport.RowCount.ToString();
            //txttotalTheo.Text = sum.ToString();












            //times2query();







            decimal tot = 0;

            for (int i = 0; i < dgvrecipe.RowCount - 0; i++)
            {
                var value = dgvrecipe.Rows[i].Cells["actual_qty_needed"].Value;
                if (value != DBNull.Value)
                {
                    tot += Convert.ToDecimal(value);
                }
            }
            if (tot == 0)
            {

            }

            txttotalrecipe.Text = tot.ToString();








            //info();



            //MessageBox.Show(" " + txttotalrecipe.Text + " AND " + lbltheoitemcode.Text + " AND " + lblprodid.Text + " ");




            decimal tot2 = 0;

            for (int i = 0; i < dgvrecipe.RowCount - 0; i++)
            {
                var value = dgvrecipe.Rows[i].Cells["my_variance"].Value;
                if (value != DBNull.Value)
                {
                    tot2 += Convert.ToDecimal(value);
                }
            }
            if (tot2 == 0)
            {

            }

    lbltotalvariance.Text = tot2.ToString();




            if(lblrecipecount.Text =="0")
            {
                Execute2ndRecipe();
            }



        }




        public void Execute2ndRecipe()
        {




            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "	SELECT a.production_id,a.item_code,a.quantity,a.quantity FROM [dbo].[rdf_recipe_to_production] a WHERE a.production_id='" + lblprodid.Text + "' AND a.item_code='" + lbltheoitemcode.Text + "'";




            //string sqlquery = "	SELECT a.item_code,a.production_id,b.p_nobatch,a.quantity,a.quantity FROM [dbo].[rdf_recipe_to_production] a LEFT JOIN rdf_production_advance b  ON a.production_id = b.prod_id WHERE a.production_id='" + lblprodid.Text + "' AND a.item_code='" + lbltheoitemcode.Text + "'";


            //string sqlquery = "	SELECT * FROM [dbo].[rdf_production_pending_theo] emp WHERE emp.production_date BETWEEN '" + dateTimePicker2.Text + "' AND '" + dtp2.Text + "' AND emp.is_active='2' AND item_code ='" + txtitemcode.Text + "'";



            //pek


            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvrecipe.DataSource = dt;

            //lblrecipecount.Text = dgvrecipe.RowCount.ToString();

            sql_con.Close();


            //double sum = 0;
            //for (int i = 0; i < dgvTheo.Rows.Count; ++i)
            //{
            //    sum += Convert.ToDouble(dgvTheo.Rows[i].Cells["my_variance"].Value);
            //}

            ////lblCounts.Text = dgvImport.RowCount.ToString();
            //txttotalTheo.Text = sum.ToString();












            times2query();







            decimal tot = 0;

            for (int i = 0; i < dgvrecipe.RowCount - 0; i++)
            {
                var value = dgvrecipe.Rows[i].Cells["quantity1"].Value;
                if (value != DBNull.Value)
                {
                    tot += Convert.ToDecimal(value);
                }
            }
            if (tot == 0)
            {

            }

            txttotalrecipe.Text = tot.ToString();






            //decimal tot2 = 0;

            //for (int i = 0; i < dgvrecipe.RowCount - 0; i++)
            //{
            //    var value = dgvrecipe.Rows[i].Cells["my_variance"].Value;
            //    if (value != DBNull.Value)
            //    {
            //        tot2 += Convert.ToDecimal(value);
            //    }
            //}
            //if (tot2 == 0)
            //{

            //}

            //lbltotalvariance.Text = tot2.ToString();


















        }


        void times2query()
        {
            for (int n = 0; n < (dgvrecipe.Rows.Count); n++)
            {


                double s1 = Convert.ToDouble(dgvrecipe.Rows[n].Cells[2].Value);

                //double batch = Convert.ToDouble(dgvrecipe.Rows[n].Cells[2].Value);

                
                double s15 = s1 * 2;

                //double answer = s15 * batch;
                //dgvImport.Rows[n].Cells[7].Value = s15.ToString("#,0.000");
                //dgvrecipe.Rows[n].Cells[4].Value = s15.ToString();
                dgvrecipe.Rows[n].Cells[3].Value = s15.ToString();


            }


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

        private void button2_Click_1(object sender, EventArgs e)
        {

            dSet.Clear();
            dSet = objStorProc.rdf_sp_prod_schedules(0, "", "", "", "", "", "", "", "", "","","","", "formulationbusy");

            if (dSet.Tables[0].Rows.Count > 0)
            {
                DatabaseBusy();
                return;
            }
            else
            {



            }

            ControlBox = false;


            dateTimePicker2_ValueChanged(sender, e);  // the data are already list here !
            dtp2_ValueChanged(sender, e); // value changed for the data number 2
            


            //dateTimePicker2.Enabled = false;
            dtp2.Enabled = false;
            btnlessthan.Enabled = false;
            button2.Enabled = false;
            dateTimePicker2.Enabled = false;
            //dateTimePicker2.Enabled = false;
            //firstQuery();
            //QuerySearchMaterial();
            dgvDuplicate_CurrentCellChanged(sender, e);
            lblprodid.Text = dgvDuplicate.CurrentRow.Cells["prod_id"].Value.ToString();
            checkyMyTheorotical();    // view dgvquery based on production id

            //TotalTheo(); alis muna 9/16
            dgvTheoQuery_CurrentCellChanged(sender, e);   //   lbltheoitemcode labeled


            ShowRecipe();  // Show the production pending theorotical

            myFormulation();  // bind the rdf Recipe table
            QueryTheoProd(); // copunt number of prod_id
            
            dgvformulation_CurrentCellChanged(sender, e);

            lbldata2.Text = dgvformulation.CurrentRow.Cells["total_qty"].Value.ToString();

            txtsavetotalqty.Text = (float.Parse(txttotalrecipe.Text) + float.Parse(lbldata2.Text)).ToString("#,0.00");//


          //  double savetotalqty;




          //  savetotalqty = double.Parse(txtsavetotalqty.Text);




          //txtsavetotalqty.Text = Math.Round(savetotalqty, 3).ToString();


            txtgrandtotalvariance.Text = (float.Parse(lbltotalvariance.Text) + float.Parse(lblrecipevariance.Text)).ToString("#,0.00");


            lblsum.Text = (float.Parse(txtsavetotalqty.Text) + float.Parse(txtgrandtotalvariance.Text)).ToString("#,0.00");


            //lblsum.Text = (float.Parse(lblsumofgrand.Text) + float.Parse(txttotalTheograndtotal.Text)).ToString();


            //txtgrandtotal.Text = (float.Parse(txtsavetotalqty.Text) + float.Parse(lbltotalvariance.Text)).ToString();


            lblvariancepercentage.Text = (float.Parse(txtgrandtotalvariance.Text) / float.Parse(lblsum.Text)).ToString("#,0.000");

            double sagot;
            double grandtotal;

            sagot = double.Parse(lblvariancepercentage.Text);


            grandtotal = sagot * 100;


            lblvariancepercentage.Text = Math.Round(grandtotal, 3).ToString();






            OutProd();


            //MessageBox.Show("HEllo");
            if (lblnumberbasis.Text == "1")
            {

  
                if (dgvDuplicate.Rows.Count >= 1)
                {


                    int i = dgvDuplicate.CurrentRow.Index + 1;
                    if (i >= -1 && i < dgvDuplicate.Rows.Count)
                        dgvDuplicate.CurrentCell = dgvDuplicate.Rows[i].Cells[1];











                    //dgvMaster_Click(sender,e);

                    else
                    {

                        //this.dgvDuplicate.CurrentCell = this.dgvDuplicate.Rows[0].Cells[this.dgvDuplicate.CurrentCell.ColumnIndex];

                        //lbltheoitemcode.Text = "";
                        //MessageBox.Show("Ogre");

                        btnsubclick_Click(sender, e);

                        btnlessthan_Click(sender, e);
                        return;
                    }
                }

            }

            lbltransactionstart.Text = "2";








            //start


            if (dgvTheoQuery.Rows.Count >= 1)
            {


                int i = dgvTheoQuery.CurrentRow.Index + 1;
                if (i >= -1 && i < dgvTheoQuery.Rows.Count)
                    dgvTheoQuery.CurrentCell = dgvTheoQuery.Rows[i].Cells[1];


                else
                {

                    button2_Click_1(sender, e);

                    //return;
                }
            }
            //end
















            lblnumberbasis.Text = "1";  // next dgvduplicate row









            button1_Click(sender,e);




            dateTimePicker2.Enabled = false;


        }

        public void executePrintingTheo()
        {


            if (dgvDuplicate.Rows.Count >= 1)
            {


                int i = dgvDuplicate.CurrentRow.Index + 1;
                if (i >= -1 && i < dgvDuplicate.Rows.Count)
                    dgvDuplicate.CurrentCell = dgvDuplicate.Rows[i].Cells[1];











                //dgvMaster_Click(sender,e);

                else
                {

                    //this.dgvDuplicate.CurrentCell = this.dgvDuplicate.Rows[0].Cells[this.dgvDuplicate.CurrentCell.ColumnIndex];

                    //lbltheoitemcode.Text = "";
                    //MessageBox.Show("Ogre");

                    btnsubclick_Click(new object(), new System.EventArgs());


                    //MessageBox.Show("Please wait for the final");
                    final();
                    btnlessthan_Click(new object(), new System.EventArgs());

                    return;
                }
            }

            checkyMyTheorotical();    // view dgvquery based on production id

            //TotalTheo(); alis muna 9/16
            dgvTheoQuery_CurrentCellChanged(new object(), new System.EventArgs());






        }


        private void btnrefreshbtn1_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void dgvformulation_CurrentCellChanged(object sender, EventArgs e)
        {

            if (dgvformulation.RowCount > 0)
            {
                if (dgvformulation.CurrentRow != null)
                {
                    if (dgvformulation.CurrentRow.Cells["item_code"].Value != null)
                    {
                        //p_id = Convert.ToInt32(dataView.CurrentRow.Cells["prod_id"].Value);


                        lbldata2.Text = dgvformulation.CurrentRow.Cells["total_qty"].Value.ToString();
                 lblrecipevariance.Text = dgvformulation.CurrentRow.Cells["theo_additional_qty"].Value.ToString();
                        txttotalTheograndtotal.Text = dgvformulation.CurrentRow.Cells["grandtotalrpt"].Value.ToString();


                    }

                }
            }



        }

        private void dgvDuplicate_CurrentCellChanged(object sender, EventArgs e)
        {



            if (dgvDuplicate.RowCount > 0)
            {
                if (dgvDuplicate.CurrentRow != null)
                {
                    if (dgvDuplicate.CurrentRow.Cells["takla"].Value != null)
                    {
                        //p_id = Convert.ToInt32(dataView.CurrentRow.Cells["prod_id"].Value);

                        txtproddate.Text = dgvDuplicate.CurrentRow.Cells["takla"].Value.ToString();
                        //txttotalqty.Text = dataGridView1.CurrentRow.Cells["proddate1"].Value.ToString();

                        //txttotalqty.Text = dgvDuplicate.CurrentRow.Cells["total_repack"].Value.ToString();
                        //txtitemcode.Text = dgvDuplicate.CurrentRow.Cells["rp_item_code"].Value.ToString();
                        lblprodid.Text = dgvDuplicate.CurrentRow.Cells["prod_id"].Value.ToString();

                    }

                }
            }













        }

        private void dgvDuplicate_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void btnsubclick_Click(object sender, EventArgs e)
        {
            dtp2_ValueChanged(sender, e);

            QuerySearchMaterial3();
            QuerySearchMaterial();
            //Refresh();
            QuerySearchMaterial2();

            checkyMyTheorotical();



            dgvTheoQuery_CurrentCellChanged(sender, e);
            TotalTheo();



            dataGridView1_CurrentCellChanged(sender, e);
            dataGridView2_CurrentCellChanged(sender, e);
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dtpprod1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dgvTheoQuery_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {


            myglobal.DATE_REPORT = dtp10.Text;
            myglobal.DATE_REPORT2 = dtp20.Text;

            myglobal.REPORT_NAME = "RepackingEntryPrint";

            frmReport fr = new frmReport();

            fr.WindowState = FormWindowState.Maximized;
            fr.Show();

        }
    }
}
