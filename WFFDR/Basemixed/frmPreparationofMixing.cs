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
using CrystalDecisions.CrystalReports.Engine;
using System.Drawing.Printing;
using System.IO;
using Tulpep.NotificationWindow;

namespace WFFDR
{
    public partial class lblnum2323 : Form
    {


        SqlCommand cmd;
        //SqlDataAdapter da;
        //DataTable dt;
        DataSet ds = new DataSet();

        myclasses xClass = new myclasses();
        IStoredProcedures objStorProc = null;

        public myclasses classes = new myclasses();
        myclasses myClass = new myclasses();

        IStoredProcedures g_objStoredProcCollection = null;
        Boolean ready = false;
        DataSet dSet = new DataSet();

        DataSet dSets = new DataSet();
        DataSet dSet_temp = new DataSet();
        string mode = "";
        int p_id = 0;
        //int temp_hid = 0;
        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();

        public DataSet dset = new DataSet();
        DataSet dset2 = new DataSet();
        //DataSet dset3 = new DataSet();
        int i;

        ReportDocument rpt = new ReportDocument();
        string Rpt_Path = "";

        public lblnum2323()
        {
            InitializeComponent();
        }

        private void frmPreparationofMixing_Load(object sender, EventArgs e)
        {
                             lblbatch.Columns[0].Width = 50;// The id column 
            lblbatchcount.Text = "0";
            radioButton1.Select();
            txtaddedby.Text = userinfo.emp_name.ToUpper();
            //this.WindowState = FormWindowState.Maximized;
            // Calling the Stored PROC 
            objStorProc = xClass.g_objStoredProc.GetCollections();




            //Rpt_Path = WFFDR.Properties.Settings.Default.fdg;


            loadPrintingData();


            if (lblnumplusone.Text == "0")
            {
                dgvCount_CurrentCellChanged(sender, e);
            }




            load_Schedules();
            PictureBoxes();

            CallHideTextBoxes();
            hideAllbatch();
            //txtmainfeedcode_TextChanged_1(sender, e);
            //DocheckingBatch();
            HideAll();
            checkEntry();

            if (txtluffy.Text == "0")
            {
                lblshow1.Visible = false;
                lblshow2.Visible = false;
                lbltotalbags.Visible = false;
                lbltotalbin.Visible = false;

            }
            else
            {
                lbltotalbags.Visible = true;
                lbltotalbin.Visible = true;
                lblshow1.Visible = true;
                lblshow2.Visible = true;


                btnlessthan_Click(sender, e);
                txtBarcode.Enabled = true;

                txtBarcode.Focus();
                txtBarcode.Select();

            }

            lbltotalread.Text = "0";

            if(txtluffy.Text=="0")
            {

            }
            else
            {
                label8.Visible = true;

            }
            ControlBox = true;
       
        }



        public void checkEntry()
        {
            if (txtluffy.Text == "0")
            {
                btnReprint.Visible = true;
                txtluffy.Visible = false;
                dgvMaster.Visible = false;
                label1.Visible = false;
                label5.Visible = false;
                lblbatch.Visible = false;
                label63.Visible = false;
                lblCounts.Visible = false;
                lblCountss.Visible = false;
                label64.Visible = false;
                label65.Visible = false;
                lblkg.Visible = false;
                label74.Visible = false;
                lbllost.Visible = false;
                label8.Visible = false;
                txtchecking1.Visible = false;
                txtchecking2.Visible = false;
                txtchecking3.Visible = false;
                txtchecking4.Visible = false;
                txtchecking5.Visible = false;
                txtchecking6.Visible = false;
                txtchecking7.Visible = false;
                txtchecking8.Visible = false;
                txtchecking9.Visible = false;

                txtchecking10.Visible = false;
                txtchecking11.Visible = false;
                txtchecking12.Visible = false;
                txtchecking13.Visible = false;
                txtchecking14.Visible = false;
                txtchecking15.Visible = false;
                txtchecking16.Visible = false;
                txtchecking17.Visible = false;

                txtchecking18.Visible = false;
                txtchecking19.Visible = false;
                txtchecking20.Visible = false;
                txtchecking21.Visible = false;
                txtchecking22.Visible = false;
                txtchecking23.Visible = false;
                txtchecking24.Visible = false;
                txtchecking25.Visible = false;
                NoDataFound2();
                lbltotalbags.Visible = true;
                lbltotalbin.Visible = true;
                lblshow1.Visible = true;
                lblshow2.Visible = true;
                return;

            }
            else
            {
  
                //frmPreparationofMixing_Load(new object(), new System.EventArgs());
                txtBarcode.Enabled = true;
                txtBarcode.Focus();
                txtBarcode.Select();
            }
            txtchecking1.Visible = false;
        }

        void NoDataFound2()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.ContentText = "NO DATA FOUND " + txtaddedby.Text + "!";
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
            lblpers.Visible = false;
            lblpercentvar.Visible = false;
            lblsymbol.Visible = false;
        timer2_Tick(new object(), new System.EventArgs());
        }







        void NaPreparedNa()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.ContentText = "Ang Raw Mats Na Ini SCAN mo Ay Natapos ng Ma Prepared " + txtaddedby.Text + "!";
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

            timer2_Tick(new object(), new System.EventArgs());
        }













        void AlreadyPrepared()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.ContentText = "ITEM ALREADY PREPARED!";
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


        public void loadPrintingData()
        {


            if (myClass.g_objStoredProc.getConnected() == true)
            {
                g_objStoredProcCollection = myClass.g_objStoredProc.GetCollections();

                dset = g_objStoredProcCollection.sp_IDGenerator(0, "SelectHR", "", "", 1);
                dset2 = g_objStoredProcCollection.sp_IDGenerator(1, "SelectCompany", "", "", 1);

                Rpt_Path = WFFDR.Properties.Settings.Default.fdg;

                //Rpt_Path = ini.IniReadValue("PATH", "Report_Path");

                //xClass.ActivitiesLogs(userinfo.emp_name + " Generated " + myglobal.REPORT_NAME + " Report");
            }
            else
            {
                MessageBox.Show("Unable to connect in sql server", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }


            dset = g_objStoredProcCollection.sp_IDGenerator(1, "SearchBasedMixFiltered", "All", txtSearchx.Text, 1);
            dataView.DataSource = dset.Tables[0];




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









        void CallHideTextBoxes()
        {
            BtnSave.Visible = false;
            lblbatch.Enabled = false;
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


        void hideAllbatch()
        {

            txtactual2.Visible = false;
            txtactual3.Visible = false;
            txtactual4.Visible = false;
            txtactual5.Visible = false;
            txtactual6.Visible = false;
            txtactual7.Visible = false;
            txtactual8.Visible = false;
            txtactual9.Visible = false;
            txtactual10.Visible = false;
            txtactual11.Visible = false;
            txtactual12.Visible = false;
            txtactual13.Visible = false;

            txtactual14.Visible = false;
            txtactual15.Visible = false;
            txtactual16.Visible = false;
            txtactual17.Visible = false;
            txtactual18.Visible = false;
            txtactual19.Visible = false;

            txtactual20.Visible = false;
            txtactual21.Visible = false;
            txtactual22.Visible = false;
            txtactual23.Visible = false;
            txtactual24.Visible = false;
            txtactual25.Visible = false;
            txtactual26.Visible = false;
            txtactual27.Visible = false;
            txtactual28.Visible = false;
            txtactual29.Visible = false;
            txtactual30.Visible = false;
            txtactual31.Visible = false;
            txtactual32.Visible = false;
            txtactual33.Visible = false;

            txtactual34.Visible = false;
            txtactual35.Visible = false;
            txtactual36.Visible = false;
            txtactual37.Visible = false;
            txtactual38.Visible = false;
            txtactual39.Visible = false;
            txtactual40.Visible = false;
            txtactual41.Visible = false;
            txtactual42.Visible = false;
            txtactual43.Visible = false;
            txtactual44.Visible = false;
            txtactual45.Visible = false;
            txtactual46.Visible = false;
            txtactual47.Visible = false;
            txtactual48.Visible = false;
            txtactual49.Visible = false;
            txtactual50.Visible = false;

            if (lblbatchcount.Text == "0")


            {

                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
                {
                    //MessageBox.Show("Qty Need Batch Match Ready TO Save <3");date
                    BtnSave.Visible = true;
                    //row18();
                    //row19();
                    return;
                }
                else
                {





                    //true

                    //batchtrue3();


                    batch2();
                    batch3();
                    batch4();
                    batch5();
                    batch6();
                    batch7();
                    batch8();
                    batch9();
                    batch10();
                    batch11();
                    batch12();
                    batch13();
                    batch14();
                    batch15();
                    batch16();
                    batch17();
                    batch18();
                    batch19();
                    batch20();
                    batch21();
                    batch22();
                    batch23();
                    batch24();
                    batch25();
                    batch26();
                    batch27();
                    batch28();
                    batch29();
                    batch30();
                    batch31();
                    batch32();
                    batch33();
                    batch34();
                    batch35();
                    batch36();
                    batch37();
                    batch38();
                    batch39();
                    batch40();

                    batch41();
                    batch42();
                    batch43();
                    batch44();
                    batch45();
                    batch46();
                    batch47();
                    batch48();
                    batch49();
                    batch50();

                }
            }


        }
        public void load_Schedules()
        {
            string mcolumns = "test,prod_id,p_feed_code,rp_feed_type,p_bags,p_nobatch,proddate";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgvMaster, mcolumns, "schedulesmixing");

            txtluffy.Text = dgvMaster.RowCount.ToString();

        }


        public void PictureBoxes()
        {
            pictureBox26.Visible = false;
            pictureBox27.Visible = false;
            pictureBox28.Visible = false;
            pictureBox29.Visible = false;
            pictureBox30.Visible = false;
            pictureBox31.Visible = false;
            pictureBox32.Visible = false;
            pictureBox33.Visible = false;
            pictureBox34.Visible = false;
            pictureBox35.Visible = false;
            pictureBox36.Visible = false;
            pictureBox37.Visible = false;
            pictureBox38.Visible = false;
            pictureBox39.Visible = false;
            pictureBox40.Visible = false;
            pictureBox41.Visible = false;
            pictureBox42.Visible = false;
            pictureBox43.Visible = false;
            pictureBox44.Visible = false;
            pictureBox45.Visible = false;


            pictureBox46.Visible = false;
            pictureBox47.Visible = false;
            pictureBox48.Visible = false;
            pictureBox49.Visible = false;
            pictureBox50.Visible = false;

        }
        private void dgvMaster_CurrentCellChanged(object sender, EventArgs e)
        {


        }

        void showMixing()
        {

            if (dgvMaster.RowCount > 0)
            {
                if (dgvMaster.CurrentRow != null)
                {
                    if (dgvMaster.CurrentRow.Cells["prod_id"].Value != null)
                    {
                        p_id = Convert.ToInt32(dgvMaster.CurrentRow.Cells["prod_id"].Value);

                        txtmainfeedcode.Text = dgvMaster.CurrentRow.Cells["prod_id"].Value.ToString();
                        label61.Text = dgvMaster.CurrentRow.Cells["p_nobatch"].Value.ToString();

                        txtFeedCode.Text = dgvMaster.CurrentRow.Cells["p_feed_code"].Value.ToString().ToUpper();

                        txtFeedType.Text = dgvMaster.CurrentRow.Cells["rp_feed_type"].Value.ToString();

                        txtBags.Text = dgvMaster.CurrentRow.Cells["p_bags"].Value.ToString();
                        txtproddate.Text = dgvMaster.CurrentRow.Cells["proddate"].Value.ToString();

                        lblbatchview.Text = dgvMaster.CurrentRow.Cells["p_nobatch"].Value.ToString();

                        lblnum1.Text = dgvMaster.CurrentRow.Cells["p_nobatch"].Value.ToString();

                        lblnum2.Text = dgvMaster.CurrentRow.Cells["p_nobatch"].Value.ToString();

                        lblnum3.Text = dgvMaster.CurrentRow.Cells["p_nobatch"].Value.ToString();

                        lblnum4.Text = dgvMaster.CurrentRow.Cells["p_nobatch"].Value.ToString();

                        lblnum5.Text = dgvMaster.CurrentRow.Cells["p_nobatch"].Value.ToString();
                        lblnum6.Text = dgvMaster.CurrentRow.Cells["p_nobatch"].Value.ToString();
                        lblnum7.Text = dgvMaster.CurrentRow.Cells["p_nobatch"].Value.ToString();
                        lblnum8.Text = dgvMaster.CurrentRow.Cells["p_nobatch"].Value.ToString();
                        lblnum9.Text = dgvMaster.CurrentRow.Cells["p_nobatch"].Value.ToString();
                        lblnum10.Text = dgvMaster.CurrentRow.Cells["p_nobatch"].Value.ToString();
                        lblnum11.Text = dgvMaster.CurrentRow.Cells["p_nobatch"].Value.ToString();
                        lblnum12.Text = dgvMaster.CurrentRow.Cells["p_nobatch"].Value.ToString();
                        lblnum13.Text = dgvMaster.CurrentRow.Cells["p_nobatch"].Value.ToString();
                        lblnum14.Text = dgvMaster.CurrentRow.Cells["p_nobatch"].Value.ToString();
                        lblnum15.Text = dgvMaster.CurrentRow.Cells["p_nobatch"].Value.ToString();
                        lblnum16.Text = dgvMaster.CurrentRow.Cells["p_nobatch"].Value.ToString();
                        lblnum17.Text = dgvMaster.CurrentRow.Cells["p_nobatch"].Value.ToString();
                        lblnum18.Text = dgvMaster.CurrentRow.Cells["p_nobatch"].Value.ToString();
                        lblnum19.Text = dgvMaster.CurrentRow.Cells["p_nobatch"].Value.ToString();
                        lblnum20.Text = dgvMaster.CurrentRow.Cells["p_nobatch"].Value.ToString();





                        //txtrecommendedsearch.Text = dgvMaster.CurrentRow.Cells["item_code"].Value.ToString();
                        //txtqtyoverall.Text = dgvMaster.CurrentRow.Cells["qty_repack_available"].Value.ToString();
                        //txtmainstocks.Text = dgvMaster.CurrentRow.Cells["total_quantity_raw"].Value.ToString();

                        //cboCategor.Text = dgvMaster.CurrentRow.Cells["item_description"].Value.ToString();






                        //wala muna this


                    }

                }
            }

        }

        private void txtmainfeedcode_TextChanged(object sender, EventArgs e)
        {

            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);

            // AND rp_category='MICRO' ORDER BY rp_group
            string sqlquery = "select adv.prod_id,rpa.feed_code,rpa.rp_feed_type,rpa.rp_group,rpa.item_code,rpa.rp_description,adv.p_nobatch,rpa.quantity,rpa.quantity from [dbo].[rdf_recipe] rpa LEFT JOIN rdf_production_advance adv ON rpa.feed_code=adv.p_feed_code WHERE rpa.feed_code = '" + txtmainfeedcode.Text + "' AND rp_category='MICRO'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            lblbatch.DataSource = dt;
            lblbatch.Visible = true;

            //dgv1stView.Columns["prod_id"].Visible = false;
            //dgv1stView.Columns["feed_code"].Visible = false;
            //dgv1stView.Columns["rp_feed_type"].Visible = false;
            //dgv_table_2nd_sup.Visible = true;
            //lblmicroview.Visible = true;
            sql_con.Close();

        }

        private void dgvMaster_CurrentCellChanged_1(object sender, EventArgs e)
        {
            showMixing();
            txtBarcode.Select();
            txtBarcode.Focus();
            DocheckingBatch();
        }

        private void txtmainfeedcode_TextChanged_1(object sender, EventArgs e)
        {
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            SqlConnection sql_con = new SqlConnection(connetionString);

            // AND rp_category='MICRO' ORDER BY rp_group TOP "+lbltotalmicro.Text+"
            string sqlquery = "select distinct rpa.pre_prod_id,rpa.pre_item_code,rpa.pre_description,rpa.pre_batch,rpa.pre_sum_total,rpa.rep_qty,rpa.rep_id from [dbo].[rdf_preparations] rpa LEFT JOIN [dbo].[rdf_recipe_to_production] aa ON rpa.pre_item_code=aa.item_code WHERE rpa.pre_prod_id = '" + txtmainfeedcode.Text + "' AND rpa.rep_is_active='1'";



            //10/5/2020
            //string sqlquery = "select rpa.pre_prod_id,rpa.pre_item_code,rpa.pre_description,rpa.pre_batch,rpa.pre_sum_total,rpa.rep_qty,rpa.rep_id from [dbo].[rdf_preparations] rpa WHERE rpa.pre_prod_id = '" + txtmainfeedcode.Text + "' AND rpa.rep_is_active='1'";





            //string sqlquery = "select rpa.pre_prod_id,rpa.pre_item_code,rpa.pre_description,rpa.pre_batch,pre_qty_batch,rpa.pre_sum_total,rpa.rep_id from [dbo].[rdf_preparations] rpa WHERE rpa.pre_prod_id = '" + txtmainfeedcode.Text + "' AND rpa.rep_is_active='1' AND NOT rpa.rep_id =''";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            lblbatch.DataSource = dt;
            lblbatch.Visible = true;


            sql_con.Close();




            for (int n = 0; n < (lblbatch.Rows.Count); n++)
            {
                double s = Convert.ToDouble(lblbatch.Rows[n].Cells[4].Value);
                double s1 = Convert.ToDouble(lblbatch.Rows[n].Cells[6].Value);
                //double s10 = Convert.ToDouble(lblbatch.Rows[n].Cells[6].Value);


                //double s13 = s1 * s;
                //double s15 = s1 * s13;

                double s25 = s1 / s;





                lblbatch.Rows[n].Cells[5].Value = s25.ToString("#,0.00"); //7/30/2020


            }









            decimal tot = 0;

            for (int i = 0; i < lblbatch.RowCount - 0; i++)
            {
                var value = lblbatch.Rows[i].Cells["pre_sum_total"].Value;
                if (value != DBNull.Value)
                {
                    tot += Convert.ToDecimal(value);
                }
            }
            if (tot == 0)
            {

            }

            decimal toty = 0;

            for (int i = 0; i < lblbatch.RowCount - 0; i++)
            {
                var value = lblbatch.Rows[i].Cells["rep_qty"].Value;
                if (value != DBNull.Value)
                {
                    toty += Convert.ToDecimal(value);
                }
            }
            if (toty == 0)
            {

            }



            lblCounts.Text = lblbatch.RowCount.ToString();
            lblCountss.Text = tot.ToString();
            lblkg.Text = toty.ToString();

            //Group1
            txtqty1.Text = tot.ToString();
            txtqty2.Text = tot.ToString();
            txtqty3.Text = tot.ToString();
            txtqty4.Text = tot.ToString();
            txtqty5.Text = tot.ToString();
            txtqty6.Text = tot.ToString();
            txtqty7.Text = tot.ToString();
            txtqty8.Text = tot.ToString();
            txtqty9.Text = tot.ToString();
            txtqty10.Text = tot.ToString();
            txtqty11.Text = tot.ToString();
            txtqty12.Text = tot.ToString();
            txtqty13.Text = tot.ToString();
            txtqty14.Text = tot.ToString();
            txtqty15.Text = tot.ToString();
            txtqty16.Text = tot.ToString();
            txtqty17.Text = tot.ToString();
            txtqty18.Text = tot.ToString();
            txtqty19.Text = tot.ToString();
            txtqty20.Text = tot.ToString();
            txtqty21.Text = tot.ToString();
            txtqty22.Text = tot.ToString();
            txtqty23.Text = tot.ToString();
            txtqty24.Text = tot.ToString();
            txtqty25.Text = tot.ToString();
            txtqty26.Text = tot.ToString();
            txtqty27.Text = tot.ToString();
            txtqty28.Text = tot.ToString();
            txtqty29.Text = tot.ToString();
            txtqty30.Text = tot.ToString();
            txtqty31.Text = tot.ToString();
            txtqty32.Text = tot.ToString();
            txtqty33.Text = tot.ToString();
            txtqty34.Text = tot.ToString();
            txtqty35.Text = tot.ToString();

            txtqty36.Text = tot.ToString();
            txtqty37.Text = tot.ToString();
            txtqty38.Text = tot.ToString();
            txtqty39.Text = tot.ToString();
            txtqty40.Text = tot.ToString();
            txtqty41.Text = tot.ToString();
            txtqty42.Text = tot.ToString();
            txtqty43.Text = tot.ToString();

            txtqty44.Text = tot.ToString();
            txtqty45.Text = tot.ToString();
            txtqty46.Text = tot.ToString();
            txtqty47.Text = tot.ToString();
            txtqty48.Text = tot.ToString();
            txtqty49.Text = tot.ToString();
            txtqty50.Text = tot.ToString();
            txtneeded.Text = tot.ToString();

        }

        private void textBox103_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblbatch_CurrentCellChanged(object sender, EventArgs e)
        {
            showMixingFormulationData();
        }

        void showMixingFormulationData()
        {

            if (lblbatch.RowCount > 0)
            {
                if (lblbatch.CurrentRow != null)
                {
                    if (lblbatch.CurrentRow.Cells["pre_prod_id"].Value != null)
                    {
                        p_id = Convert.ToInt32(lblbatch.CurrentRow.Cells["pre_prod_id"].Value);

                        txtactiveselection.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();





                    }

                }
            }

        }

        private void butun1_Click(object sender, EventArgs e)
        {




            if (lblbatch.Rows.Count >= 1)
            {
                int i = lblbatch.CurrentRow.Index + 1;
                if (i >= -1 && i < lblbatch.Rows.Count)



                    if (txtchecking1.Text.Trim() == string.Empty)
                    {

                        MessageBox.Show("Part1", "Barcode Input Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtchecking1.Select();
                        txtchecking1.Focus();
                        txtchecking1.BackColor = Color.Yellow;


                        return;
                    }
                    else
                    {

                        //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
                        String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
                        SqlConnection sql_con = new SqlConnection(connetionString);

                        cmd = new SqlCommand("SELECT string_id FROM [dbo].[rdf_repackin_entry]  WHERE string_id='" + txtchecking1.Text + "'", sql_con);

                        SqlDataAdapter daks = new SqlDataAdapter(cmd);

                        daks.Fill(ds);
                        int ia = ds.Tables[0].Rows.Count;
                        if (ia > 0)
                        {
                            //MessageBox.Show("The Formula" + txt1.Text + "Already Exists !");

                            search();
                            dgvrepackdb.Visible = true;
                            //txtcode1.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                            //txttotalrepack1.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                            //txt1.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();

                            if (txtactiveselection.Text.Trim() == txtchecking1.Text.Trim())
                            {
                                //MessageBox.Show("Proceed Match Code");

                            }
                            else
                            {
                                MessageBox.Show("Repak ID Not Match!, Choose the exactly item Thanks !");
                                txtchecking1.Text = "";
                                return;
                            }


                            txtrepcom1.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();

                            txtchecking1.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();

                            txtchecking1.BackColor = Color.LightGreen;
                            pictureBox26.Visible = true;
                            //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                            txtchecking2.Focus();
                            txtchecking2.Select();
                            lblbatch.CurrentCell = lblbatch.Rows[i].Cells[0];
                            ds.Clear();







                            //return;
                        }
                        else
                        {
                            MessageBox.Show("The Repacking Selected" + txtchecking1.Text + " IS Not Exists !!");
                            txtchecking1.BackColor = Color.Yellow;
                            txtchecking1.Text = "";
                            return;
                            //return; // ang gulo ntyo mga bugok
                        }





                        //pictureBox1.Visible = true;
                        //button1.Text = "Validated";
                        //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                        //txt2.Focus();
                        //txt2.Select();
                        //dgv1stView.CurrentCell = dgv1stView.Rows[i].Cells[0];





                        if (txtchecking2.Text.Trim() == string.Empty)
                        {
                            lbltotalread.Text = "1";
                            Dochecking();
                            txtchecking1.Enabled = false;



                            //txt1.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                            //txtcode1.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                            //txttotalrepack1.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                            //txtchecking2.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();
                            txtrepcom2.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();
                            //txtdescription2.Text = dgv1stView.CurrentRow.Cells["rp_description"].Value.ToString();
                            //txtbatch2.Text = dgv1stView.CurrentRow.Cells["p_nobatch"].Value.ToString();
                            //txtqty2.Text = dgv1stView.CurrentRow.Cells["quantity"].Value.ToString();

                            return;
                        }


                    }
            }


            else
            {
                search();
                //txtcode1.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                //txttotalrepack1.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                //txt1.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                //txt23.Focus();
            }

        }



        public void search()
        {
            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "select repack_id,rp_item_id,rp_item_category,rp_item_code from [dbo].[rdf_repackin_entry] WHERE string_id = '" + txtchecking1.Text + "'";
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
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "select repack_id,rp_item_id,rp_item_category,rp_item_code from [dbo].[rdf_repackin_entry] WHERE string_id = '" + txtchecking2.Text + "'";
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
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "select repack_id,rp_item_id,rp_item_category,rp_item_code from [dbo].[rdf_repackin_entry] WHERE string_id = '" + txtchecking3.Text + "'";
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
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "select repack_id,rp_item_id,rp_item_category,rp_item_code from [dbo].[rdf_repackin_entry] WHERE string_id = '" + txtchecking4.Text + "'";
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
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "select repack_id,rp_item_id,rp_item_category,rp_item_code from [dbo].[rdf_repackin_entry] WHERE string_id = '" + txtchecking5.Text + "'";
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
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "select repack_id,rp_item_id,rp_item_category,rp_item_code from [dbo].[rdf_repackin_entry] WHERE string_id = '" + txtchecking6.Text + "'";
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
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "select repack_id,rp_item_id,rp_item_category,rp_item_code from [dbo].[rdf_repackin_entry] WHERE string_id = '" + txtchecking7.Text + "'";
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
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "select repack_id,rp_item_id,rp_item_category,rp_item_code from [dbo].[rdf_repackin_entry] WHERE string_id = '" + txtchecking8.Text + "'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr2 = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr2.Fill(dt);
            dgvrepackdb.DataSource = dt;
            dgvrepackdb.Visible = true;

            sql_con.Close();
        }


        public void search9()
        {
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "select repack_id,rp_item_id,rp_item_category,rp_item_code from [dbo].[rdf_repackin_entry] WHERE string_id = '" + txtchecking9.Text + "'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr2 = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr2.Fill(dt);
            dgvrepackdb.DataSource = dt;
            dgvrepackdb.Visible = true;

            sql_con.Close();
        }



        public void search10()
        {
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "select repack_id,rp_item_id,rp_item_category,rp_item_code from [dbo].[rdf_repackin_entry] WHERE string_id = '" + txtchecking10.Text + "'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr2 = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr2.Fill(dt);
            dgvrepackdb.DataSource = dt;
            dgvrepackdb.Visible = true;

            sql_con.Close();
        }


        public void search11()
        {
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "select repack_id,rp_item_id,rp_item_category,rp_item_code from [dbo].[rdf_repackin_entry] WHERE string_id = '" + txtchecking11.Text + "'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr2 = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr2.Fill(dt);
            dgvrepackdb.DataSource = dt;
            dgvrepackdb.Visible = true;

            sql_con.Close();
        }


        public void search12()
        {
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "select repack_id,rp_item_id,rp_item_category,rp_item_code from [dbo].[rdf_repackin_entry] WHERE string_id = '" + txtchecking12.Text + "'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr2 = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr2.Fill(dt);
            dgvrepackdb.DataSource = dt;
            dgvrepackdb.Visible = true;

            sql_con.Close();
        }


        public void search13()
        {
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "select repack_id,rp_item_id,rp_item_category,rp_item_code from [dbo].[rdf_repackin_entry] WHERE string_id = '" + txtchecking13.Text + "'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr2 = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr2.Fill(dt);
            dgvrepackdb.DataSource = dt;
            dgvrepackdb.Visible = true;

            sql_con.Close();
        }


        public void search14()
        {
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "select repack_id,rp_item_id,rp_item_category,rp_item_code from [dbo].[rdf_repackin_entry] WHERE string_id = '" + txtchecking14.Text + "'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr2 = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr2.Fill(dt);
            dgvrepackdb.DataSource = dt;
            dgvrepackdb.Visible = true;

            sql_con.Close();
        }


        public void search15()
        {
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "select repack_id,rp_item_id,rp_item_category,rp_item_code from [dbo].[rdf_repackin_entry] WHERE string_id = '" + txtchecking15.Text + "'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr2 = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr2.Fill(dt);
            dgvrepackdb.DataSource = dt;
            dgvrepackdb.Visible = true;

            sql_con.Close();
        }


        public void search16()
        {
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "select repack_id,rp_item_id,rp_item_category,rp_item_code from [dbo].[rdf_repackin_entry] WHERE string_id = '" + txtchecking16.Text + "'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr2 = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr2.Fill(dt);
            dgvrepackdb.DataSource = dt;
            dgvrepackdb.Visible = true;

            sql_con.Close();
        }


        public void search17()
        {
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "select repack_id,rp_item_id,rp_item_category,rp_item_code from [dbo].[rdf_repackin_entry] WHERE string_id = '" + txtchecking17.Text + "'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr2 = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr2.Fill(dt);
            dgvrepackdb.DataSource = dt;
            dgvrepackdb.Visible = true;

            sql_con.Close();
        }

        public void search18()
        {
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "select repack_id,rp_item_id,rp_item_category,rp_item_code from [dbo].[rdf_repackin_entry] WHERE string_id = '" + txtchecking18.Text + "'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr2 = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr2.Fill(dt);
            dgvrepackdb.DataSource = dt;
            dgvrepackdb.Visible = true;

            sql_con.Close();
        }

        public void search19()
        {
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "select repack_id,rp_item_id,rp_item_category,rp_item_code from [dbo].[rdf_repackin_entry] WHERE string_id = '" + txtchecking19.Text + "'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr2 = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr2.Fill(dt);
            dgvrepackdb.DataSource = dt;
            dgvrepackdb.Visible = true;

            sql_con.Close();
        }

        public void search20()
        {
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "select repack_id,rp_item_id,rp_item_category,rp_item_code from [dbo].[rdf_repackin_entry] WHERE string_id = '" + txtchecking20.Text + "'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr2 = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr2.Fill(dt);
            dgvrepackdb.DataSource = dt;
            dgvrepackdb.Visible = true;

            sql_con.Close();
        }

        public void search21()
        {
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);

            
            string sqlquery = "select repack_id,rp_item_id,rp_item_category,rp_item_code from [dbo].[rdf_repackin_entry] WHERE string_id = '" + txtchecking21.Text + "'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr2 = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr2.Fill(dt);
            dgvrepackdb.DataSource = dt;
            dgvrepackdb.Visible = true;

            sql_con.Close();
        }

        public void search22()
        {
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "select repack_id,rp_item_id,rp_item_category,rp_item_code from [dbo].[rdf_repackin_entry] WHERE string_id = '" + txtchecking22.Text + "'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr2 = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr2.Fill(dt);
            dgvrepackdb.DataSource = dt;
            dgvrepackdb.Visible = true;

            sql_con.Close();
        }

        public void search23()
        {
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "select repack_id,rp_item_id,rp_item_category,rp_item_code from [dbo].[rdf_repackin_entry] WHERE string_id = '" + txtchecking23.Text + "'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr2 = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr2.Fill(dt);
            dgvrepackdb.DataSource = dt;
            dgvrepackdb.Visible = true;

            sql_con.Close();
        }

        public void search24()
        {
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "select repack_id,rp_item_id,rp_item_category,rp_item_code from [dbo].[rdf_repackin_entry] WHERE string_id = '" + txtchecking24.Text + "'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr2 = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr2.Fill(dt);
            dgvrepackdb.DataSource = dt;
            dgvrepackdb.Visible = true;

            sql_con.Close();
        }

        public void search25()
        {
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "select repack_id,rp_item_id,rp_item_category,rp_item_code from [dbo].[rdf_repackin_entry] WHERE string_id = '" + txtchecking25.Text + "'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr2 = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr2.Fill(dt);
            dgvrepackdb.DataSource = dt;
            dgvrepackdb.Visible = true;

            sql_con.Close();
        }

        void Dochecking()
        {

            //You must add code here!!

            if (lbltotalread.Text == "17")
            {

                if (lblCounts.Text.Trim() == lbltotalread.Text.Trim())
                {
          
                    Timer();
                    batchtrue1();
                    panel1.Visible = true;
                    BtnSave.Visible = true;
                    txtactual1.Enabled = true;
                    txtactual1.BringToFront();
                    txtactual1.Focus();
                    txtactual1.Select();
                    ValidateOkay();
                    txtactual1.Visible = true;
                    txtactual1.Enabled = true;
                    txtactual1.BringToFront();
                    txtactual1.Select();
                    txtactual1.Focus();
                    txtactual1.BackColor = Color.Yellow;
                    return;
                }
                else
                {






                    //col18();
                    txt18.Focus();
                    txt18.Select();
                }


            }
            else if (lbltotalread.Text == "1")


            {
                if (lblCounts.Text.Trim() == lbltotalread.Text.Trim())
                {
          
                    Timer();
                    txtactual1.Visible = true;
                    panel1.Visible = true;
                    BtnSave.Visible = true;
                    batchtrue1();
                    txtactual1.BringToFront();
                    txtactual1.Enabled = true;
                    txtactual1.Focus();
                    txtactual1.Select();
                    ValidateOkay();
                    txtactual1.Visible = true;
                    txtactual1.Enabled = true;
                    txtactual1.BringToFront();
                    txtactual1.Select();
                    txtactual1.Focus();
                    txtactual1.BackColor = Color.Yellow;
                }
                else
                {
                    //col2();
                    txt2.Focus();
                    txt2.Select();
                }
            }


            else if (lbltotalread.Text == "16")


            {
                if (lblCounts.Text.Trim() == lbltotalread.Text.Trim())
                {
                    //MessageBox.Show("Qty Needed Match Ready TO Save Gerard <3");date

                    Timer();
                    panel1.Visible = true;
                    BtnSave.Visible = true;
                    batchtrue1();
                    txtactual1.Enabled = true;
                    txtactual1.BringToFront();
                    txtactual1.Focus();
                    txtactual1.Select();

                    ValidateOkay();
                    txtactual1.Visible = true;
                    txtactual1.Enabled = true;
                    txtactual1.BringToFront();
                    txtactual1.Select();
                    txtactual1.Focus();
                    txtactual1.BackColor = Color.Yellow;

                }
                else
                {
                    //col2();
                    txt17.Focus();
                    txt17.Select();
                }
            }
        }


        void batch1()
        {
            lblnum1.Visible = false;
            txtqty1.Visible = false;
            txtactual1.Visible = false;
            btn1.Visible = false;

        }

        void batch2()
        {
            lblnum2.Visible = false;
            txtqty2.Visible = false;
            txtactual2.Visible = false;
            btn2.Visible = false;

        }



        void batch4()
        {
            lblnum4.Visible = false;
            txtqty4.Visible = false;
            txtactual4.Visible = false;
            btn4.Visible = false;

        }

        void batch3()
        {
            lblnum3.Visible = false;
            txtqty3.Visible = false;
            txtactual3.Visible = false;
            btn3.Visible = false;

        }


        void batch5()
        {
            lblnum5.Visible = false;
            txtqty5.Visible = false;
            txtactual5.Visible = false;
            btn5.Visible = false;

        }
        void batch6()
        {
            lblnum6.Visible = false;
            txtqty6.Visible = false;
            txtactual6.Visible = false;
            btn6.Visible = false;

        }

        void batch7()
        {
            lblnum7.Visible = false;
            txtqty7.Visible = false;
            txtactual7.Visible = false;
            btn7.Visible = false;

        }
        void batch8()
        {
            lblnum8.Visible = false;
            txtqty8.Visible = false;
            txtactual8.Visible = false;
            btn8.Visible = false;

        }
        void batch9()
        {
            lblnum9.Visible = false;
            txtqty9.Visible = false;
            txtactual9.Visible = false;
            btn9.Visible = false;

        }
        void batch10()
        {
            lblnum10.Visible = false;
            txtqty10.Visible = false;
            txtactual10.Visible = false;
            btn10.Visible = false;

        }
        void batch11()
        {
            lblnum11.Visible = false;
            txtqty11.Visible = false;
            txtactual11.Visible = false;
            btn11.Visible = false;

        }

        void batch12()
        {
            lblnum12.Visible = false;
            txtqty12.Visible = false;
            txtactual12.Visible = false;
            btn12.Visible = false;

        }

        void batch13()
        {
            lblnum13.Visible = false;
            txtqty13.Visible = false;
            txtactual13.Visible = false;
            btn13.Visible = false;

        }

        void batch14()
        {
            lblnum14.Visible = false;
            txtqty14.Visible = false;
            txtactual14.Visible = false;
            btn14.Visible = false;

        }

        void batch15()
        {
            lblnum15.Visible = false;
            txtqty15.Visible = false;
            txtactual15.Visible = false;
            btn15.Visible = false;

        }

        void batch16()
        {
            lblnum16.Visible = false;
            txtqty16.Visible = false;
            txtactual16.Visible = false;
            btn16.Visible = false;

        }

        void batch17()
        {
            lblnum17.Visible = false;
            txtqty17.Visible = false;
            txtactual17.Visible = false;
            btn17.Visible = false;

        }

        void batch18()
        {
            lblnum18.Visible = false;
            txtqty18.Visible = false;
            txtactual18.Visible = false;
            btn18.Visible = false;

        }

        void batch19()
        {
            lblnum19.Visible = false;
            txtqty19.Visible = false;
            txtactual19.Visible = false;
            btn19.Visible = false;

        }
        void batch20()
        {
            lblnum20.Visible = false;
            txtqty20.Visible = false;
            txtactual20.Visible = false;
            btn20.Visible = false;

        }
        void batch21()
        {
            lblnum21.Visible = false;
            txtqty21.Visible = false;
            txtactual21.Visible = false;
            btn21.Visible = false;

        }
        void batch22()
        {
            lblnum22.Visible = false;
            txtqty22.Visible = false;
            txtactual22.Visible = false;
            btn22.Visible = false;

        }
        void batch23()
        {
            lblnum23.Visible = false;
            txtqty23.Visible = false;
            txtactual23.Visible = false;
            btn23.Visible = false;

        }
        void batch24()
        {
            lblnum24.Visible = false;
            txtqty24.Visible = false;
            txtactual24.Visible = false;
            btn24.Visible = false;

        }
        void batch25()
        {
            lblnum25.Visible = false;
            txtqty25.Visible = false;
            txtactual25.Visible = false;
            btn25.Visible = false;

        }
        void batch26()
        {
            lblnum26.Visible = false;
            txtqty26.Visible = false;
            txtactual26.Visible = false;
            btn26.Visible = false;

        }
        void batch27()
        {
            lblnum27.Visible = false;
            txtqty27.Visible = false;
            txtactual27.Visible = false;
            btn27.Visible = false;

        }
        void batch28()
        {
            lblnum28.Visible = false;
            txtqty28.Visible = false;
            txtactual28.Visible = false;
            btn28.Visible = false;

        }

        void batch29()
        {
            lblnum29.Visible = false;
            txtqty29.Visible = false;
            txtactual29.Visible = false;
            btn29.Visible = false;

        }

        void batch30()
        {
            lblnum30.Visible = false;
            txtqty30.Visible = false;
            txtactual30.Visible = false;
            btn30.Visible = false;
        }

        void batch31()
        {
            lblnum31.Visible = false;
            txtqty31.Visible = false;
            txtactual31.Visible = false;
            btn31.Visible = false;

        }
        void batch32()
        {
            lblnum32.Visible = false;
            txtqty32.Visible = false;
            txtactual32.Visible = false;
            btn32.Visible = false;

        }
        void batch33()
        {
            lblnum33.Visible = false;
            txtqty33.Visible = false;
            txtactual33.Visible = false;
            btn33.Visible = false;

        }
        void batch34()
        {
            lblnum34.Visible = false;
            txtqty34.Visible = false;
            txtactual34.Visible = false;
            btn34.Visible = false;

        }
        void batch35()
        {
            lblnum35.Visible = false;
            txtqty35.Visible = false;
            txtactual35.Visible = false;
            btn35.Visible = false;

        }
        void batch36()
        {
            lblnum36.Visible = false;
            txtqty36.Visible = false;
            txtactual36.Visible = false;
            btn36.Visible = false;

        }
        void batch37()
        {
            lblnum37.Visible = false;
            txtqty37.Visible = false;
            txtactual37.Visible = false;
            btn37.Visible = false;

        }
        void batch38()
        {
            lblnum38.Visible = false;
            txtqty38.Visible = false;
            txtactual38.Visible = false;
            btn38.Visible = false;

        }
        void batch39()
        {
            lblnum39.Visible = false;
            txtqty39.Visible = false;
            txtactual39.Visible = false;
            btn39.Visible = false;

        }
        void batch40()
        {
            lblnum40.Visible = false;
            txtqty40.Visible = false;
            txtactual40.Visible = false;
            btn40.Visible = false;

        }

        void batch41()
        {
            lblnum41.Visible = false;
            txtqty41.Visible = false;
            txtactual41.Visible = false;
            btn41.Visible = false;

        }

        void batch42()
        {
            lblnum42.Visible = false;
            txtqty42.Visible = false;
            txtactual42.Visible = false;
            btn42.Visible = false;

        }

        void batch43()
        {
            lblnum43.Visible = false;
            txtqty43.Visible = false;
            txtactual43.Visible = false;
            btn43.Visible = false;

        }

        void batch44()
        {
            lblnum44.Visible = false;
            txtqty44.Visible = false;
            txtactual44.Visible = false;
            btn44.Visible = false;

        }
        void batch45()
        {
            lblnum45.Visible = false;
            txtqty45.Visible = false;
            txtactual45.Visible = false;
            btn45.Visible = false;

        }

        void batch46()
        {
            lblnum46.Visible = false;
            txtqty46.Visible = false;
            txtactual46.Visible = false;
            btn46.Visible = false;

        }

        void batch47()
        {
            lblnum47.Visible = false;
            txtqty47.Visible = false;
            txtactual47.Visible = false;
            btn47.Visible = false;

        }

        void batch48()
        {
            lblnum48.Visible = false;
            txtqty48.Visible = false;
            txtactual48.Visible = false;
            btn48.Visible = false;

        }

        void batch49()
        {
            lblnum49.Visible = false;
            txtqty49.Visible = false;
            txtactual49.Visible = false;
            btn49.Visible = false;

        }

        void batch50()
        {
            lblnum50.Visible = false;
            txtqty50.Visible = false;
            txtactual50.Visible = false;
            btn50.Visible = false;

        }






        void batchtrue2()
        {
            txtactual2.BringToFront();


            lblnum2.Visible = true;
            txtqty2.Visible = true;
            txtactual2.Visible = true;
            btn2.Visible = true;

        }


        void batchtrue1()
        {
            lblnum1.Visible = true;
            txtqty1.Visible = true;
            txtactual1.Visible = true;
            txtactual1.BringToFront();
            btn1.Visible = true;
            btn1.Enabled = true;
            btn2.Enabled = true;
            btn3.Enabled = true;
            btn4.Enabled = true;
            btn5.Enabled = true;
            btn6.Enabled = true;
            btn7.Enabled = true;
            btn8.Enabled = true;
            btn9.Enabled = true;
            btn10.Enabled = true;


        }


        void batchtrue3()
        {
            txtactual3.BringToFront();
            lblnum3.Visible = true;
            txtqty3.Visible = true;
            txtactual3.Visible = true;
            btn3.Visible = true;

        }


        void batchtrue4()
        {
            txtactual4.BringToFront();
            lblnum4.Visible = true;
            txtqty4.Visible = true;
            txtactual4.Visible = true;
            btn4.Visible = true;

        }

        void batchtrue5()
        {
            txtactual5.BringToFront();
            lblnum5.Visible = true;
            txtqty5.Visible = true;
            txtactual5.Visible = true;
            btn5.Visible = true;

        }

        void batchtrue6()
        {
            txtactual6.BringToFront();
            lblnum6.Visible = true;
            txtqty6.Visible = true;
            txtactual6.Visible = true;
            btn6.Visible = true;

        }

        void batchtrue7()
        {
            txtactual7.BringToFront();
            lblnum7.Visible = true;
            txtqty7.Visible = true;
            txtactual7.Visible = true;
            btn7.Visible = true;

        }

        void batchtrue8()
        {
            txtactual8.BringToFront();
            lblnum8.Visible = true;
            txtqty8.Visible = true;
            txtactual8.Visible = true;
            btn8.Visible = true;

        }

        void batchtrue9()
        {
            txtactual9.BringToFront();
            lblnum9.Visible = true;
            txtqty9.Visible = true;
            txtactual9.Visible = true;
            btn9.Visible = true;

        }

        void batchtrue10()
        {
            txtactual10.BringToFront();
            lblnum10.Visible = true;
            txtqty10.Visible = true;
            txtactual10.Visible = true;
            btn10.Visible = true;

        }

        void batchtrue11()
        {
            txtactual11.BringToFront();
            lblnum11.Visible = true;
            txtqty11.Visible = true;
            txtactual11.Visible = true;
            btn11.Visible = true;

        }

        void batchtrue12()
        {
            txtactual2.BringToFront();
            lblnum12.Visible = true;
            txtqty12.Visible = true;
            txtactual12.Visible = true;
            btn12.Visible = true;

        }

        void batchtrue13()
        {
            txtactual3.BringToFront();
            lblnum13.Visible = true;
            txtqty13.Visible = true;
            txtactual13.Visible = true;
            btn13.Visible = true;

        }

        void batchtrue14()
        {
            txtactual4.BringToFront();
            lblnum14.Visible = true;
            txtqty14.Visible = true;
            txtactual14.Visible = true;
            btn14.Visible = true;

        }

        void batchtrue15()
        {
            txtactual5.BringToFront();
            lblnum15.Visible = true;
            txtqty15.Visible = true;
            txtactual15.Visible = true;
            btn15.Visible = true;

        }
        void batchtrue16()
        {
            txtactual6.BringToFront();
            lblnum16.Visible = true;
            txtqty16.Visible = true;
            txtactual16.Visible = true;
            btn16.Visible = true;

        }
        void batchtrue17()
        {
            txtactual7.BringToFront();
            lblnum17.Visible = true;
            txtqty17.Visible = true;
            txtactual17.Visible = true;
            btn17.Visible = true;

        }
        void batchtrue18()
        {
            txtactual8.BringToFront();
            lblnum18.Visible = true;
            txtqty18.Visible = true;
            txtactual18.Visible = true;
            btn18.Visible = true;

        }
        void batchtrue19()
        {
            txtactual9.BringToFront();
            lblnum19.Visible = true;
            txtqty19.Visible = true;
            txtactual19.Visible = true;
            btn19.Visible = true;

        }
        void batchtrue20()
        {
            txtactual20.BringToFront();
            lblnum20.Visible = true;
            txtqty20.Visible = true;
            txtactual20.Visible = true;
            btn20.Visible = true;

        }
        void batchtrue21()
        {
            txtactual21.BringToFront();
            lblnum21.Visible = true;
            txtqty21.Visible = true;
            txtactual21.Visible = true;
            btn21.Visible = true;

        }
        void batchtrue22()
        {
            txtactual22.BringToFront();
            lblnum22.Visible = true;
            txtqty22.Visible = true;
            txtactual22.Visible = true;
            btn22.Visible = true;

        }
        void batchtrue23()
        {
            txtactual23.BringToFront();
            lblnum23.Visible = true;
            txtqty23.Visible = true;
            txtactual23.Visible = true;
            btn23.Visible = true;

        }
        void batchtrue24()
        {
            txtactual24.BringToFront();
            lblnum24.Visible = true;
            txtqty24.Visible = true;
            txtactual24.Visible = true;
            btn24.Visible = true;

        }
        void batchtrue25()
        {
            txtactual25.BringToFront();
            lblnum25.Visible = true;
            txtqty25.Visible = true;
            txtactual25.Visible = true;
            btn25.Visible = true;

        }
        void batchtrue26()
        {
            txtactual26.BringToFront();
            lblnum26.Visible = true;
            txtqty26.Visible = true;
            txtactual26.Visible = true;
            btn26.Visible = true;

        }
        void batchtrue27()
        {
            txtactual27.BringToFront();
            lblnum27.Visible = true;
            txtqty27.Visible = true;
            txtactual27.Visible = true;
            btn27.Visible = true;

        }
        void batchtrue28()
        {
            txtactual28.BringToFront();
            lblnum28.Visible = true;
            txtqty28.Visible = true;
            txtactual28.Visible = true;
            btn28.Visible = true;

        }
        void batchtrue29()
        {
            txtactual29.BringToFront();
            lblnum29.Visible = true;
            txtqty29.Visible = true;
            txtactual29.Visible = true;
            btn29.Visible = true;

        }
        void batchtrue30()
        {
            txtactual30.BringToFront();
            lblnum30.Visible = true;
            txtqty30.Visible = true;
            txtactual30.Visible = true;
            btn30.Visible = true;

        }
        void batchtrue31()
        {
            txtactual31.BringToFront();
            lblnum31.Visible = true;
            txtqty31.Visible = true;
            txtactual31.Visible = true;
            btn31.Visible = true;

        }
        void batchtrue32()
        {
            txtactual32.BringToFront();
            lblnum32.Visible = true;
            txtqty32.Visible = true;
            txtactual32.Visible = true;
            btn32.Visible = true;

        }
        void batchtrue33()
        {
            txtactual33.BringToFront();
            lblnum33.Visible = true;
            txtqty33.Visible = true;
            txtactual33.Visible = true;
            btn33.Visible = true;

        }
        void batchtrue34()
        {
            txtactual34.BringToFront();
            lblnum34.Visible = true;
            txtqty34.Visible = true;
            txtactual34.Visible = true;
            btn34.Visible = true;

        }
        void batchtrue35()
        {
            txtactual35.BringToFront();
            lblnum35.Visible = true;
            txtqty35.Visible = true;
            txtactual35.Visible = true;
            btn35.Visible = true;

        }
        void batchtrue36()
        {
            txtactual36.BringToFront();
            lblnum36.Visible = true;
            txtqty36.Visible = true;
            txtactual36.Visible = true;
            btn36.Visible = true;

        }
        void batchtrue37()
        {
            txtactual37.BringToFront();
            lblnum37.Visible = true;
            txtqty37.Visible = true;
            txtactual37.Visible = true;
            btn37.Visible = true;

        }
        void batchtrue38()
        {
            txtactual38.BringToFront();
            lblnum38.Visible = true;
            txtqty38.Visible = true;
            txtactual38.Visible = true;
            btn38.Visible = true;

        }
        void batchtrue39()
        {
            txtactual39.BringToFront();
            lblnum39.Visible = true;
            txtqty39.Visible = true;
            txtactual39.Visible = true;
            btn39.Visible = true;

        }
        void batchtrue40()
        {
            txtactual40.BringToFront();
            lblnum40.Visible = true;
            txtqty40.Visible = true;
            txtactual40.Visible = true;
            btn40.Visible = true;

        }
        void batchtrue41()
        {
            txtactual41.BringToFront();
            lblnum41.Visible = true;
            txtqty41.Visible = true;
            txtactual41.Visible = true;
            btn41.Visible = true;

        }
        void batchtrue42()
        {
            txtactual42.BringToFront();
            lblnum42.Visible = true;
            txtqty42.Visible = true;
            txtactual42.Visible = true;
            btn42.Visible = true;

        }
        void batchtrue43()
        {
            txtactual43.BringToFront();
            lblnum43.Visible = true;
            txtqty43.Visible = true;
            txtactual43.Visible = true;
            btn43.Visible = true;

        }
        void batchtrue44()
        {
            txtactual44.BringToFront();
            lblnum44.Visible = true;
            txtqty44.Visible = true;
            txtactual44.Visible = true;
            btn44.Visible = true;

        }
        void batchtrue45()
        {
            txtactual45.BringToFront();
            lblnum45.Visible = true;
            txtqty45.Visible = true;
            txtactual45.Visible = true;
            btn45.Visible = true;

        }
        void batchtrue46()
        {
            txtactual46.BringToFront();
            lblnum46.Visible = true;
            txtqty46.Visible = true;
            txtactual46.Visible = true;
            btn46.Visible = true;

        }
        void batchtrue47()
        {
            txtactual47.BringToFront();
            lblnum47.Visible = true;
            txtqty47.Visible = true;
            txtactual47.Visible = true;
            btn47.Visible = true;

        }
        void batchtrue48()
        {
            txtactual48.BringToFront();
            lblnum48.Visible = true;
            txtqty48.Visible = true;
            txtactual48.Visible = true;
            btn48.Visible = true;

        }
        void batchtrue49()
        {
            txtactual49.BringToFront();
            lblnum49.Visible = true;
            txtqty49.Visible = true;
            txtactual49.Visible = true;
            btn49.Visible = true;

        }
        void batchtrue50()
        {
            txtactual50.BringToFront();
            lblnum50.Visible = true;
            txtqty50.Visible = true;
            txtactual50.Visible = true;
            btn50.Visible = true;

        }
        void batcht51()
        {
            lblnum51.Visible = false;
            txtqty51.Visible = false;
            txtactual51.Visible = false;
            btn51.Visible = false;

        }
        void batchtrue51()
        {
            lblnum51.Visible = true;
            txtqty51.Visible = true;
            txtactual51.Visible = true;
            btn51.Visible = true;

        }


        void DocheckingBatch()
        {

            //            //You must add code here!!

            //            if (lblbatchcount.Text == "5")
            //            {

            //                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
            //                {
            //                    //MessageBox.Show("Qty Need Batch Match Ready TO Save <3");laarnie dy
            //                    BtnSave.Visible = true;
            //                    //row18();
            //                    //row19();

            //                    return;
            //                }
            //                else
            //                {

            //                    batch6();

            //                    batch7();
            //                    batch8();

            //                    batch9();
            //                    batch10();


            //                        //true
            //                        ////////batchtrue2();gg
            //                        ////////batchtrue3();gg
            //                        ////////batchtrue4();gg
            //                        batchtrue5();

            //                        //col18();
            //                        //txt18.Focus();
            //                        //txt18.Select();
            //                    }
            //                //BtnSave.Visible = true;

            //                //dv.RowFilter = "firstname like '%" + txtsearch.Text + "%' or lastname like '%" + txtsearch.Text + "%' or employee_number like '%" + txtsearch.Text + "%' or employment_status_name like '%" + txtsearch.Text + "%'";
            //            }
            //            else if (label61.Text == "456")


            //            {
            //                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
            //                {
            //                    //MessageBox.Show("Qty Need Batch Match Ready TO Save <3");
            //                    BtnSave.Visible = true;
            //                    //row18();
            //                    //row19();
            //                    return;
            //                }
            //                else
            //                {

            //                    batch5();
            //                    batch6();

            //                    batch7();
            //                    batch8();

            //                    batch9();
            //                    batch10();

            //                    //true
            //                    batchtrue2();
            //                    batchtrue3();
            //                    batchtrue4();


            //                }
            //            }


            //            else if (label61.Text == "3")


            //            {

            //                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
            //                {
            //                    //MessageBox.Show("Qty Need Batch Match Ready TO Save <3");
            //                    BtnSave.Visible = true;
            //                    //row18();
            //                    //row19();
            //                    return;
            //                }
            //                else
            //                {

            //                    batch4();
            //                    batch3();
            //                    batch5();
            //                    batch6();

            //                    batch7();
            //                    batch8();

            //                    batch9();
            //                    batch10();

            //                    //true

            //                    batchtrue3();


            //                }
            //            }


            //            else if (lblbatchcount.Text == "1")


            //            {

            //                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
            //                {
            //                    //MessageBox.Show("Qty Need Batch Match Ready TO Save <3");
            //                    BtnSave.Visible = true;
            //                    //row18();
            //                    //row19();
            //                    return;
            //                }
            //                else
            //                {
            //                    batch1();
            //                    batch4();
            //                    batch3();
            //                    batch5();
            //                    batch6();

            //                    batch7();
            //                    batch8();

            //                    batch9();
            //                    batch10();

            //                    //true

            //                    //batchtrue3();
            //                    batchtrue2();

            //                }
            //            }



            //            else if (label61.Text == "60")


            //            {

            //                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
            //            {
            //                //MessageBox.Show("Qty Need Batch Match Ready TO Save <3");
            //                BtnSave.Visible = true;
            //                //row18();
            //                //row19();
            //                return;
            //            }
            //            else
            //            {



            //                batch7();
            //                batch8();

            //                batch9();
            //                batch10();

            //                //true

            //                //batchtrue3();
            //                batchtrue2();
            //                    batchtrue3();
            //                    batchtrue4();
            //                    batchtrue5();
            //                    batchtrue6();

            //                }
            //        }




            //            else if (label61.Text == "7")


            //            {

            //                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
            //                {
            //                    //MessageBox.Show("Qty Need Batch Match Ready TO Save <3");
            //                    BtnSave.Visible = true;
            //                    //row18();
            //                    //row19();
            //                    return;
            //                }
            //                else
            //                {




            //                    batch8();

            //                    batch9();
            //                    batch10();

            //                    //true

            //                    //batchtrue3();
            //                    batchtrue2();
            //                    batchtrue3();
            //                    batchtrue4();
            //                    batchtrue5();
            //                    batchtrue6();
            //                    batchtrue7();


            //                }
            //            }



            //            else if (label61.Text == "8")


            //            {

            //                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
            //                {
            ///*                    MessageBox.Show("Qty Need Batch Match Ready TO Save <3")*/;
            //                    BtnSave.Visible = true;
            //                    //row18();
            //                    //row19();
            //                    return;
            //                }
            //                else
            //                {




            //                    batch8();

            //                    batch9();
            //                    batch10();

            //                    //true

            //                    //batchtrue3();
            //                    batchtrue2();
            //                    batchtrue3();
            //                    batchtrue4();
            //                    batchtrue5();
            //                    batchtrue6();
            //                    batchtrue7();
            //                    batchtrue8();


            //                }
            //            }







            //            else if (label61.Text == "9")


            //            {

            //                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
            //                {
            //                    //MessageBox.Show("Qty Need Batch Match Ready TO Save <3");
            //                    BtnSave.Visible = true;
            //                    //row18();
            //                    //row19();
            //                    return;
            //                }
            //                else
            //                {





            //                    batch9();
            //                    batch10();

            //                    //true

            //                    //batchtrue3();
            //                    batchtrue2();
            //                    batchtrue3();
            //                    batchtrue4();
            //                    batchtrue5();
            //                    batchtrue6();
            //                    batchtrue7();
            //                    batchtrue8();
            //                    batchtrue9();


            //                }
            //            }




            //            else if (label61.Text == "130")


            //            {

            //                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
            //                {
            //                    //MessageBox.Show("Qty Need Batch Match Ready TO Save <3");
            //                    BtnSave.Visible = true;
            //                    //row18();
            //                    //row19();
            //                    return;
            //                }
            //                else
            //                {





            //                    //true

            //                    //batchtrue3();
            //                    batchtrue2();
            //                    batchtrue3();
            //                    batchtrue4();
            //                    batchtrue5();
            //                    batchtrue6();
            //                    batchtrue7();
            //                    batchtrue8();
            //                    batchtrue9();
            //                    batchtrue10();

            //                }
            //            }



            //            else if (label61.Text == "1")


            //            {

            //                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
            //                {
            //                    //MessageBox.Show("Qty Need Batch Match Ready TO Save <3");
            //                    BtnSave.Visible = true;
            //                    //row18();
            //                    //row19();
            //                    return;
            //                }
            //                else
            //                {





            //                    //true

            //                    //batchtrue3();


            //                    batch2();
            //                    batch3();
            //                    batch4();
            //                    batch6();
            //                    batch6();
            //                    batch7();
            //                    batch8();
            //                    batch9();
            //                    batch10();


            //                }
            //            }


            //            else if (lblbatchcount.Text == "0")


            //            {

            //                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
            //                {
            //                    //MessageBox.Show("Qty Need Batch Match Ready TO Save <3");
            //                    BtnSave.Visible = true;
            //                    //row18();
            //                    //row19();
            //                    return;
            //                }
            //                else
            //                {





            //                    //true

            //                    //batchtrue3();


            //                    batch2();
            //                    batch3();
            //                    batch4();
            //                    batch5();
            //                    batch6();
            //                    batch7();
            //                    batch8();
            //                    batch9();
            //                    batch10();
            //                    batch11();
            //                    batch12();
            //                    batch13();
            //                    batch14();
            //                    batch15();
            //                    batch16();
            //                    batch17();
            //                    batch18();
            //                    batch19();
            //                    batch20();
            //                    batch21();
            //                    batch22();
            //                    batch23();
            //                    batch24();
            //                    batch25();
            //                    batch26();
            //                    batch27();
            //                    batch28();
            //                    batch29();
            //                    batch30();
            //                    batch31();
            //                    batch32();
            //                    batch33();
            //                    batch34();
            //                    batch35();
            //                    batch36();
            //                    batch37();
            //                    batch38();
            //                    batch39();
            //                    batch40();

            //                    batch41();
            //                    batch42();
            //                    batch43();
            //                    batch44();
            //                    batch45();
            //                    batch46();
            //                    batch47();
            //                    batch48();
            //                    batch49();
            //                    batch50();

            //                }
            //            }




        }
        void HideAll()
        {

            batch2();
            batch3();
            batch4();
            batch5();
            batch6();
            batch7();
            batch8();
            batch9();
            batch10();
            batch11();
            batch12();
            batch13();
            batch14();
            batch15();
            batch16();
            batch17();
            batch18();
            batch19();
            batch20();
            batch21();
            batch22();
            batch23();
            batch24();
            batch25();
            batch26();
            batch27();
            batch28();
            batch29();
            batch30();
            batch31();
            batch32();
            batch33();
            batch34();
            batch35();
            batch36();
            batch37();
            batch38();
            batch39();
            batch40();

            batch41();
            batch42();
            batch43();
            batch44();
            batch45();
            batch46();
            batch47();
            batch48();
            batch49();
            batch50();
        }
        private void txtchecking1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtchecking1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                butun1_Click(sender, e);
            }
        }

        private void txtchecking2_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                butun2_Click(sender, e);
            }
        }

        private void txtchecking2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void butun2_Click(object sender, EventArgs e)
        {


            if (lblbatch.Rows.Count >= 1)
            {
                int i = lblbatch.CurrentRow.Index + 1;
                if (i >= -1 && i < lblbatch.Rows.Count)



                    if (txtchecking2.Text.Trim() == string.Empty)
                    {

                        MessageBox.Show("Part2", "Barcode Input Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtchecking2.Select();
                        txtchecking2.Focus();
                        txtchecking2.BackColor = Color.Yellow;


                        return;
                    }
                    else
                    {
                        String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
                        SqlConnection sql_con = new SqlConnection(connetionString);

                        cmd = new SqlCommand("SELECT string_id FROM [dbo].[rdf_repackin_entry]  WHERE string_id='" + txtchecking2.Text + "'", sql_con);

                        SqlDataAdapter daks = new SqlDataAdapter(cmd);

                        daks.Fill(ds);
                        int ia = ds.Tables[0].Rows.Count;
                        if (ia > 0)
                        {
                            //MessageBox.Show("The Formula" + txt1.Text + "Already Exists !");

                            search2();
                            //txtcode1.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                            //txttotalrepack1.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                            //txt1.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();

                            if (txtrepcom2.Text.Trim() == txtchecking2.Text.Trim())
                            {
                                //MessageBox.Show("Proceed Match Code");

                            }
                            else
                            {
                                MessageBox.Show("Repak ID Not Match!, Choose the exactly item Thanks !");
                                txtchecking2.Text = "";
                                return;
                            }


                            txtrepcom2.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();

                            txtchecking2.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();

                            txtchecking2.BackColor = Color.LightGreen;
                            pictureBox27.Visible = true;
                            //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                            txtchecking3.Focus();
                            txtchecking3.Select();
                            lblbatch.CurrentCell = lblbatch.Rows[i].Cells[0];
                            ds.Clear();







                            //return;
                        }
                        else
                        {
                            MessageBox.Show("The Repacking Selected" + txtchecking2.Text + " IS Not Exists !!");
                            txtchecking2.BackColor = Color.Yellow;
                            txtchecking2.Text = "";
                            return;
                            //return; // ang gulo ntyo mga bugok
                        }





                        //pictureBox1.Visible = true;
                        //button1.Text = "Validated";
                        //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                        //txt2.Focus();
                        //txt2.Select();
                        //dgv1stView.CurrentCell = dgv1stView.Rows[i].Cells[0];





                        if (txtchecking3.Text.Trim() == string.Empty)
                        {
                            lbltotalread.Text = "2";
                            Dochecking();
                            txtchecking2.Enabled = false;



                            //txt1.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                            //txtcode1.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                            //txttotalrepack1.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                            //txtchecking2.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();
                            txtrepcom3.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();
                            //txtdescription2.Text = dgv1stView.CurrentRow.Cells["rp_description"].Value.ToString();
                            //txtbatch2.Text = dgv1stView.CurrentRow.Cells["p_nobatch"].Value.ToString();
                            //txtqty2.Text = dgv1stView.CurrentRow.Cells["quantity"].Value.ToString();

                            return;
                        }


                    }
            }


            else
            {
                search2();
                //txtcode1.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                //txttotalrepack1.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                //txt1.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                //txt23.Focus();
            }
        }

        private void butun3_Click(object sender, EventArgs e)
        {

            if (lblbatch.Rows.Count >= 1)
            {
                int i = lblbatch.CurrentRow.Index + 1;
                if (i >= -1 && i < lblbatch.Rows.Count)



                    if (txtchecking3.Text.Trim() == string.Empty)
                    {

                        MessageBox.Show("Part3", "Barcode Input Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtchecking3.Select();
                        txtchecking3.Focus();
                        txtchecking3.BackColor = Color.Yellow;


                        return;
                    }
                    else
                    {

                        String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
                        SqlConnection sql_con = new SqlConnection(connetionString);
                        
                        cmd = new SqlCommand("SELECT string_id FROM [dbo].[rdf_repackin_entry]  WHERE string_id='" + txtchecking3.Text + "'", sql_con);

                        SqlDataAdapter daks = new SqlDataAdapter(cmd);

                        daks.Fill(ds);
                        int ia = ds.Tables[0].Rows.Count;
                        if (ia > 0)
                        {
                            //MessageBox.Show("The Formula" + txt1.Text + "Already Exists !");

                            search3();
                            //txtcode1.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                            //txttotalrepack1.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                            //txt1.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();

                            if (txtrepcom3.Text.Trim() == txtchecking3.Text.Trim())
                            {
                                //MessageBox.Show("Proceed Match Code");

                            }
                            else
                            {
                                MessageBox.Show("Repak ID Not Match!, Choose the exactly item Thanks !");
                                txtchecking3.Text = "";
                                return;
                            }


                            txtrepcom3.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();

                            txtchecking3.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();

                            txtchecking3.BackColor = Color.LightGreen;
                            pictureBox28.Visible = true;
                            //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                            txtchecking4.Focus();
                            txtchecking4.Select();
                            lblbatch.CurrentCell = lblbatch.Rows[i].Cells[0];
                            ds.Clear();







                            //return;
                        }
                        else
                        {
                            MessageBox.Show("The Repacking Selected" + txtchecking3.Text + " IS Not Exists !!");
                            txtchecking3.BackColor = Color.Yellow;
                            txtchecking3.Text = "";
                            return;
                            //return; // ang gulo ntyo mga bugok
                        }





                        //pictureBox1.Visible = true;
                        //button1.Text = "Validated";
                        //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                        //txt2.Focus();
                        //txt2.Select();
                        //dgv1stView.CurrentCell = dgv1stView.Rows[i].Cells[0];





                        if (txtchecking4.Text.Trim() == string.Empty)
                        {
                            lbltotalread.Text = "3";
                            Dochecking();
                            txtchecking3.Enabled = false;



                            //txt1.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                            //txtcode1.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                            //txttotalrepack1.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                            //txtchecking2.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();
                            txtrepcom4.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();
                            //txtdescription2.Text = dgv1stView.CurrentRow.Cells["rp_description"].Value.ToString();
                            //txtbatch2.Text = dgv1stView.CurrentRow.Cells["p_nobatch"].Value.ToString();
                            //txtqty2.Text = dgv1stView.CurrentRow.Cells["quantity"].Value.ToString();

                            return;
                        }


                    }
            }


            else
            {
                search3();
                //txtcode1.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                //txttotalrepack1.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                //txt1.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                //txt23.Focus();
            }





        }

        private void txtchecking3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                butun3_Click(sender, e);
            }
        }

        private void txtchecking3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtchecking4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtchecking4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                butun4_Click(sender, e);
            }
        }

        private void butun4_Click(object sender, EventArgs e)
        {
            if (lblbatch.Rows.Count >= 1)
            {
                int i = lblbatch.CurrentRow.Index + 1;
                if (i >= -1 && i < lblbatch.Rows.Count)



                    if (txtchecking4.Text.Trim() == string.Empty)
                    {

                        MessageBox.Show("Part4", "Barcode Input Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtchecking4.Select();
                        txtchecking4.Focus();
                        txtchecking4.BackColor = Color.Yellow;


                        return;
                    }
                    else
                    {

                        String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
                        SqlConnection sql_con = new SqlConnection(connetionString);

                        cmd = new SqlCommand("SELECT string_id FROM [dbo].[rdf_repackin_entry]  WHERE string_id='" + txtchecking4.Text + "'", sql_con);

                        SqlDataAdapter daks = new SqlDataAdapter(cmd);

                        daks.Fill(ds);
                        int ia = ds.Tables[0].Rows.Count;
                        if (ia > 0)
                        {
                            //MessageBox.Show("The Formula" + txt1.Text + "Already Exists !");

                            search4();
                            //txtcode1.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                            //txttotalrepack1.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                            //txt1.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();

                            if (txtrepcom4.Text.Trim() == txtchecking4.Text.Trim())
                            {
                                //MessageBox.Show("Proceed Match Code");

                            }
                            else
                            {
                                MessageBox.Show("Repak ID Not Match!, Choose the exactly item Thanks !");
                                txtchecking4.Text = "";
                                return;
                            }


                            txtrepcom4.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();

                            txtchecking4.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();

                            txtchecking4.BackColor = Color.LightGreen;
                            pictureBox29.Visible = true;
                            //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                            txtchecking5.Focus();
                            txtchecking5.Select();
                            lblbatch.CurrentCell = lblbatch.Rows[i].Cells[0];
                            ds.Clear();







                            //return;
                        }
                        else
                        {
                            MessageBox.Show("The Repacking Selected" + txtchecking4.Text + " IS Not Exists !!");
                            txtchecking4.BackColor = Color.Yellow;
                            txtchecking4.Text = "";
                            return;
                            //return; // ang gulo ntyo mga bugok
                        }





                        //pictureBox1.Visible = true;
                        //button1.Text = "Validated";
                        //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                        //txt2.Focus();
                        //txt2.Select();
                        //dgv1stView.CurrentCell = dgv1stView.Rows[i].Cells[0];





                        if (txtchecking5.Text.Trim() == string.Empty)
                        {
                            lbltotalread.Text = "4";
                            Dochecking();
                            txtchecking4.Enabled = false;



                            //txt1.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                            //txtcode1.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                            //txttotalrepack1.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                            //txtchecking2.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();
                            txtrepcom5.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();
                            //txtdescription2.Text = dgv1stView.CurrentRow.Cells["rp_description"].Value.ToString();
                            //txtbatch2.Text = dgv1stView.CurrentRow.Cells["p_nobatch"].Value.ToString();
                            //txtqty2.Text = dgv1stView.CurrentRow.Cells["quantity"].Value.ToString();

                            return;
                        }


                    }
            }


            else
            {
                search4();
                //txtcode1.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                //txttotalrepack1.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                //txt1.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                //txt23.Focus();
            }
        }

        private void butun5_Click(object sender, EventArgs e)
        {
            if (lblbatch.Rows.Count >= 1)
            {
                int i = lblbatch.CurrentRow.Index + 1;
                if (i >= -1 && i < lblbatch.Rows.Count)



                    if (txtchecking5.Text.Trim() == string.Empty)
                    {

                        MessageBox.Show("Part5", "Barcode Input Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtchecking5.Select();
                        txtchecking5.Focus();
                        txtchecking5.BackColor = Color.Yellow;


                        return;
                    }
                    else
                    {

                        String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
                        SqlConnection sql_con = new SqlConnection(connetionString);

                        cmd = new SqlCommand("SELECT string_id FROM [dbo].[rdf_repackin_entry]  WHERE string_id='" + txtchecking5.Text + "'", sql_con);

                        SqlDataAdapter daks = new SqlDataAdapter(cmd);

                        daks.Fill(ds);
                        int ia = ds.Tables[0].Rows.Count;
                        if (ia > 0)
                        {
                            //MessageBox.Show("The Formula" + txt1.Text + "Already Exists !");

                            search5();


                            if (txtrepcom5.Text.Trim() == txtchecking5.Text.Trim())
                            {
                                //MessageBox.Show("Proceed Match Code");

                            }
                            else
                            {
                                MessageBox.Show("Repak ID Not Match!, Choose the exactly item Thanks !");
                                txtchecking5.Text = "";
                                return;
                            }


                            txtrepcom5.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();

                            txtchecking5.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();

                            txtchecking5.BackColor = Color.LightGreen;
                            pictureBox30.Visible = true;
                            //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                            txtchecking6.Focus();
                            txtchecking6.Select();
                            lblbatch.CurrentCell = lblbatch.Rows[i].Cells[0];
                            ds.Clear();







                            //return;
                        }
                        else
                        {
                            MessageBox.Show("The Repacking Selected" + txtchecking5.Text + " IS Not Exists !!");
                            txtchecking5.BackColor = Color.Yellow;
                            txtchecking5.Text = "";
                            return;
                            //return; // ang gulo ntyo mga bugok
                        }





                        //pictureBox1.Visible = true;
                        //button1.Text = "Validated";
                        //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                        //txt2.Focus();
                        //txt2.Select();
                        //dgv1stView.CurrentCell = dgv1stView.Rows[i].Cells[0];





                        if (txtchecking6.Text.Trim() == string.Empty)
                        {
                            lbltotalread.Text = "5";
                            Dochecking();
                            txtchecking5.Enabled = false;



                            //txt1.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                            //txtcode1.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                            //txttotalrepack1.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                            //txtchecking2.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();
                            txtrepcom6.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();
                            //txtdescription2.Text = dgv1stView.CurrentRow.Cells["rp_description"].Value.ToString();
                            //txtbatch2.Text = dgv1stView.CurrentRow.Cells["p_nobatch"].Value.ToString();
                            //txtqty2.Text = dgv1stView.CurrentRow.Cells["quantity"].Value.ToString();

                            return;
                        }


                    }
            }


            else
            {
                search4();
                //txtcode1.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                //txttotalrepack1.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                //txt1.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                //txt23.Focus();
            }
        }

        private void butun6_Click(object sender, EventArgs e)
        {
            if (lblbatch.Rows.Count >= 1)
            {
                int i = lblbatch.CurrentRow.Index + 1;
                if (i >= -1 && i < lblbatch.Rows.Count)



                    if (txtchecking6.Text.Trim() == string.Empty)
                    {

                        MessageBox.Show("Part6", "Barcode Input Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtchecking6.Select();
                        txtchecking6.Focus();
                        txtchecking6.BackColor = Color.Yellow;


                        return;
                    }
                    else
                    {

                        String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
                        SqlConnection sql_con = new SqlConnection(connetionString);

                        cmd = new SqlCommand("SELECT string_id FROM [dbo].[rdf_repackin_entry]  WHERE string_id='" + txtchecking6.Text + "'", sql_con);

                        SqlDataAdapter daks = new SqlDataAdapter(cmd);

                        daks.Fill(ds);
                        int ia = ds.Tables[0].Rows.Count;
                        if (ia > 0)
                        {
                            //MessageBox.Show("The Formula" + txt1.Text + "Already Exists !");

                            search6();
                            //txtcode1.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                            //txttotalrepack1.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                            //txt1.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();

                            if (txtrepcom6.Text.Trim() == txtchecking6.Text.Trim())
                            {
                                //MessageBox.Show("Proceed Match Code");

                            }
                            else
                            {
                                MessageBox.Show("Repak ID Not Match!, Choose the exactly item Thanks !");
                                txtchecking6.Text = "";
                                return;
                            }


                            txtrepcom6.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();

                            txtchecking6.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();

                            txtchecking6.BackColor = Color.LightGreen;
                            pictureBox31.Visible = true;
                            //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                            txtchecking7.Focus();
                            txtchecking7.Select();
                            lblbatch.CurrentCell = lblbatch.Rows[i].Cells[0];
                            ds.Clear();







                            //return;
                        }
                        else
                        {
                            MessageBox.Show("The Repacking Selected" + txtchecking6.Text + " IS Not Exists !!");
                            txtchecking6.BackColor = Color.Yellow;
                            txtchecking6.Text = "";
                            return;
                            //return; // ang gulo ntyo mga bugok
                        }





                        //pictureBox1.Visible = true;
                        //button1.Text = "Validated";
                        //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                        //txt2.Focus();
                        //txt2.Select();
                        //dgv1stView.CurrentCell = dgv1stView.Rows[i].Cells[0];





                        if (txtchecking7.Text.Trim() == string.Empty)
                        {
                            lbltotalread.Text = "6";
                            Dochecking();
                            txtchecking6.Enabled = false;



                            //txt1.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                            //txtcode1.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                            //txttotalrepack1.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                            //txtchecking2.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();
                            txtrepcom7.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();
                            //txtdescription2.Text = dgv1stView.CurrentRow.Cells["rp_description"].Value.ToString();
                            //txtbatch2.Text = dgv1stView.CurrentRow.Cells["p_nobatch"].Value.ToString();
                            //txtqty2.Text = dgv1stView.CurrentRow.Cells["quantity"].Value.ToString();

                            return;
                        }


                    }
            }


            else
            {
                search6();
                //txtcode1.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                //txttotalrepack1.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                //txt1.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                //txt23.Focus();
            }
        }

        private void butun7_Click(object sender, EventArgs e)
        {
            if (lblbatch.Rows.Count >= 1)
            {
                int i = lblbatch.CurrentRow.Index + 1;
                if (i >= -1 && i < lblbatch.Rows.Count)



                    if (txtchecking7.Text.Trim() == string.Empty)
                    {

                        MessageBox.Show("Part7", "Barcode Input Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtchecking7.Select();
                        txtchecking7.Focus();
                        txtchecking7.BackColor = Color.Yellow;


                        return;
                    }
                    else
                    {

                        String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
                        SqlConnection sql_con = new SqlConnection(connetionString);

                        cmd = new SqlCommand("SELECT string_id FROM [dbo].[rdf_repackin_entry]  WHERE string_id='" + txtchecking7.Text + "'", sql_con);

                        SqlDataAdapter daks = new SqlDataAdapter(cmd);

                        daks.Fill(ds);
                        int ia = ds.Tables[0].Rows.Count;
                        if (ia > 0)
                        {
                            //MessageBox.Show("The Formula" + txt1.Text + "Already Exists !");

                            search7();


                            if (txtrepcom7.Text.Trim() == txtchecking7.Text.Trim())
                            {
                                //MessageBox.Show("Proceed Match Code");

                            }
                            else
                            {
                                MessageBox.Show("Repak ID Not Match!, Choose the exactly item Thanks !");
                                txtchecking6.Text = "";
                                return;
                            }


                            txtrepcom7.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();

                            txtchecking7.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();

                            txtchecking7.BackColor = Color.LightGreen;
                            pictureBox32.Visible = true;
                            //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                            txtchecking8.Focus();
                            txtchecking8.Select();
                            lblbatch.CurrentCell = lblbatch.Rows[i].Cells[0];
                            ds.Clear();







                            //return;
                        }
                        else
                        {
                            MessageBox.Show("The Repacking Selected" + txtchecking7.Text + " IS Not Exists !!");
                            txtchecking7.BackColor = Color.Yellow;
                            txtchecking7.Text = "";
                            return;
                            //return; // ang gulo ntyo mga bugok
                        }





                        //pictureBox1.Visible = true;
                        //button1.Text = "Validated";
                        //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                        //txt2.Focus();
                        //txt2.Select();
                        //dgv1stView.CurrentCell = dgv1stView.Rows[i].Cells[0];





                        if (txtchecking8.Text.Trim() == string.Empty)
                        {
                            lbltotalread.Text = "7";
                            Dochecking();
                            txtchecking7.Enabled = false;



                            //txt1.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                            //txtcode1.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                            //txttotalrepack1.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                            //txtchecking2.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();
                            txtrepcom8.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();
                            //txtdescription2.Text = dgv1stView.CurrentRow.Cells["rp_description"].Value.ToString();
                            //txtbatch2.Text = dgv1stView.CurrentRow.Cells["p_nobatch"].Value.ToString();
                            //txtqty2.Text = dgv1stView.CurrentRow.Cells["quantity"].Value.ToString();

                            return;
                        }


                    }
            }


            else
            {
                search7();
                //txtcode1.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                //txttotalrepack1.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                //txt1.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                //txt23.Focus();
            }
        }

        private void buton8_Click(object sender, EventArgs e)
        {
            if (lblbatch.Rows.Count >= 1)
            {
                int i = lblbatch.CurrentRow.Index + 1;
                if (i >= -1 && i < lblbatch.Rows.Count)



                    if (txtchecking8.Text.Trim() == string.Empty)
                    {

                        MessageBox.Show("Part8", "Barcode Input Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtchecking8.Select();
                        txtchecking8.Focus();
                        txtchecking8.BackColor = Color.Yellow;


                        return;
                    }
                    else
                    {

                        String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
                        SqlConnection sql_con = new SqlConnection(connetionString);

                        cmd = new SqlCommand("SELECT string_id FROM [dbo].[rdf_repackin_entry]  WHERE string_id='" + txtchecking8.Text + "'", sql_con);

                        SqlDataAdapter daks = new SqlDataAdapter(cmd);

                        daks.Fill(ds);
                        int ia = ds.Tables[0].Rows.Count;
                        if (ia > 0)
                        {
                            //MessageBox.Show("The Formula" + txt1.Text + "Already Exists !");

                            search8();
                            //txtcode1.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                            //txttotalrepack1.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                            //txt1.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();

                            if (txtrepcom8.Text.Trim() == txtchecking8.Text.Trim())
                            {
                                //MessageBox.Show("Proceed Match Code");

                            }
                            else
                            {
                                MessageBox.Show("Repak ID Not Match!, Choose the exactly item Thanks !");
                                txtchecking8.Text = "";
                                return;
                            }


                            txtrepcom8.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();

                            txtchecking8.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();

                            txtchecking8.BackColor = Color.LightGreen;
                            pictureBox33.Visible = true;
                            //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                            txtchecking9.Focus();
                            txtchecking9.Select();
                            lblbatch.CurrentCell = lblbatch.Rows[i].Cells[0];
                            ds.Clear();







                            //return;
                        }
                        else
                        {
                            MessageBox.Show("The Repacking Selected" + txtchecking8.Text + " IS Not Exists !!");
                            txtchecking8.BackColor = Color.Yellow;
                            txtchecking8.Text = "";
                            return;
                            //return; // ang gulo ntyo mga bugok
                        }





                        //pictureBox1.Visible = true;
                        //button1.Text = "Validated";
                        //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                        //txt2.Focus();
                        //txt2.Select();
                        //dgv1stView.CurrentCell = dgv1stView.Rows[i].Cells[0];





                        if (txtchecking9.Text.Trim() == string.Empty)
                        {
                            lbltotalread.Text = "8";
                            Dochecking();
                            txtchecking8.Enabled = false;




                            txtrepcom9.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();


                            return;
                        }


                    }
            }


            else
            {
                search8();

            }
        }

        private void buton9_Click(object sender, EventArgs e)
        {




            if (txtchecking9.Text.Trim() == string.Empty)
            {

                MessageBox.Show("Part 9", "Barcode Input Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtchecking9.Select();
                txtchecking9.Focus();
                txtchecking9.BackColor = Color.Yellow;


                return;
            }
            else
            {

                String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
                SqlConnection sql_con = new SqlConnection(connetionString);

                cmd = new SqlCommand("SELECT string_id FROM [dbo].[rdf_repackin_entry]  WHERE string_id='" + txtchecking9.Text + "'", sql_con);

                SqlDataAdapter daks = new SqlDataAdapter(cmd);

                daks.Fill(ds);
                int ia = ds.Tables[0].Rows.Count;
                if (ia > 0)
                {


                    search9();


                    if (txtBarcode.Text.Trim() == txtchecking9.Text.Trim())
                    {


                    }
                    else
                    {
                        MessageBox.Show("Repak ID Not Match!, Choose the exactly item Thanks !");
                        txtchecking9.Text = "";
                        return;
                    }


                    txtrepcom9.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();



                    txtchecking9.BackColor = Color.LightGreen;
                    pictureBox34.Visible = true;
                    //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                    txtchecking10.Focus();
                    txtchecking10.Select();
                    lblbatch.CurrentCell = lblbatch.Rows[i].Cells[0];
                    CountNumber();
                    txtchecking9.Visible = true;
                    ds.Clear();







                    //return;
                }
                else
                {
                    MessageBox.Show("The Repacking Selected" + txtchecking9.Text + " IS Not Exists !!");
                    txtchecking9.BackColor = Color.Yellow;
                    txtchecking9.Text = "";
                    return;
                    //return; // ang gulo ntyo mga bugok
                }










                if (txtchecking10.Text.Trim() == string.Empty)
                {
                    lbltotalread.Text = "9";
                    Dochecking();
                    txtchecking9.Enabled = false;




                    txtrepcom10.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();


                    return;
                }


            }

        }

        private void txtchecking5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                butun5_Click(sender, e);
            }
        }

        private void txtchecking5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtchecking6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                butun6_Click(sender, e);
            }
        }

        private void txtchecking6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtchecking7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                butun7_Click(sender, e);
            }
        }

        private void txtchecking7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtchecking8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buton8_Click(sender, e);
            }
        }

        private void txtchecking8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void buton10_Click(object sender, EventArgs e)
        {




            if (txtchecking10.Text.Trim() == string.Empty)
            {


                BarcodeNotFound();
                txtchecking10.Select();
                txtchecking10.Focus();
                txtchecking10.BackColor = Color.Yellow;


                return;
            }
            else
            {

                String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
                SqlConnection sql_con = new SqlConnection(connetionString);

                cmd = new SqlCommand("SELECT string_id FROM [dbo].[rdf_repackin_entry]  WHERE string_id='" + txtchecking10.Text + "'", sql_con);

                SqlDataAdapter daks = new SqlDataAdapter(cmd);

                daks.Fill(ds);
                int ia = ds.Tables[0].Rows.Count;
                if (ia > 0)
                {
                    //MessageBox.Show("The Formula" + txt1.Text + "Already Exists !");

                    search10();


                    if (txtBarcode.Text.Trim() == txtchecking10.Text.Trim())
                    {
                        //MessageBox.Show("Proceed Match Code");

                    }
                    else
                    {
                        //MessageBox.Show("Repak ID Not Match!, Choose the exactly item Thanks !");
                        RepackIDNotMatched();
                        txtchecking10.Text = "";
                        txtchecking10.Select();
                        txtchecking10.Focus();
                        return;
                    }


                    txtrepcom10.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();



                    txtchecking10.BackColor = Color.LightGreen;
                    pictureBox35.Visible = true;
                    //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                    txtchecking11.Focus();
                    txtchecking11.Select();
                    lblbatch.CurrentCell = lblbatch.Rows[i].Cells[0];

                    CountNumber();
                    txtchecking10.Visible = true;
                    ds.Clear();







                    //return;
                }
                else
                {
                    //MessageBox.Show("The Repacking Selected" + txtchecking10.Text + " IS Not Exists !!");
                    RepackIdNotExists();
                    txtchecking10.BackColor = Color.Yellow;
                    txtchecking10.Text = "";
                    txtchecking10.Select();
                    txtchecking10.Focus();
                    return;
                    //return; // ang gulo ntyo mga bugok
                }











                //if (txtchecking11.Text.Trim() == string.Empty)
                //{
                //    lbltotalread.Text = "10";
                //    Dochecking();
                //    txtchecking10.Enabled = false;
                //    txtchecking11.Visible = true;
                //    txtchecking11.Select();
                //    txtchecking11.Focus();


                //    txtrepcom11.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();


                //    return;
                //}


            }

        }

        private void buton11_Click(object sender, EventArgs e)
        {



            if (txtchecking11.Text.Trim() == string.Empty)
            {


                BarcodeNotFound();
                txtBarcode.Select();
                txtBarcode.Focus();
                txtBarcode.BackColor = Color.Yellow;


                return;
            }
            else
            {

                String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
                SqlConnection sql_con = new SqlConnection(connetionString);

                cmd = new SqlCommand("SELECT string_id FROM [dbo].[rdf_repackin_entry]  WHERE string_id='" + txtchecking11.Text + "'", sql_con);

                SqlDataAdapter daks = new SqlDataAdapter(cmd);

                daks.Fill(ds);
                int ia = ds.Tables[0].Rows.Count;
                if (ia > 0)
                {


                    search11();


                    if (txtBarcode.Text.Trim() == txtchecking11.Text.Trim())
                    {


                    }
                    else
                    {
                        RepackIDNotMatched();
                        //MessageBox.Show("Repak ID Not Match!, Choose the exactly item Thanks !");
                        txtchecking11.Text = "";
                        txtchecking11.Select();
                        txtchecking11.Focus();
                        return;
                    }


                    txtrepcom11.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();



                    txtchecking11.BackColor = Color.LightGreen;
                    pictureBox36.Visible = true;
                    //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                    txtchecking12.Focus();
                    txtchecking12.Select();

                    CountNumber();
                    txtchecking11.Visible = true;
                    ds.Clear();







                    //return;
                }
                else
                {
                    //MessageBox.Show("The Repacking Selected" + txtchecking11.Text + " IS Not Exists !!");
                    RepackIdNotExists();
                    txtchecking11.BackColor = Color.Yellow;
                    txtchecking11.Text = "";
                    txtchecking11.Select();
                    txtchecking11.Focus();
                    return;
                    //return; // ang gulo ntyo mga bugok
                }










                //if (txtchecking12.Text.Trim() == string.Empty)
                //{
                //    lbltotalread.Text = "11";
                //    Dochecking();
                //    txtchecking11.Enabled = false;
                //    txtchecking12.Visible = true;
                //    txtchecking12.Select();
                //    txtchecking12.Focus();



                //    ;
                //    txtrepcom12.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();


                //    return;
                //}


            }

        }

        private void buton12_Click(object sender, EventArgs e)
        {




            if (txtchecking12.Text.Trim() == string.Empty)
            {


                BarcodeNotFound();
                txtchecking12.Select();
                txtchecking12.Focus();
                txtchecking12.BackColor = Color.Yellow;


                return;
            }
            else
            {

                String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
                SqlConnection sql_con = new SqlConnection(connetionString);

                cmd = new SqlCommand("SELECT string_id FROM [dbo].[rdf_repackin_entry]  WHERE string_id='" + txtchecking12.Text + "'", sql_con);

                SqlDataAdapter daks = new SqlDataAdapter(cmd);

                daks.Fill(ds);
                int ia = ds.Tables[0].Rows.Count;
                if (ia > 0)
                {


                    search12();


                    if (txtBarcode.Text.Trim() == txtchecking12.Text.Trim())
                    {
                        //MessageBox.Show("Proceed Match Code");

                    }
                    else
                    {
                        //MessageBox.Show("Repak ID Not Match!, Choose the exactly item Thanks !");
                        RepackIdNotExists();
                        txtBarcode.Text = "";
                        txtBarcode.Select();
                        txtBarcode.Focus();
                        return;
                    }


                    txtrepcom12.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();



                    txtchecking12.BackColor = Color.LightGreen;
                    pictureBox37.Visible = true;
                    //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                    txtchecking13.Focus();
                    txtchecking13.Select();
                    CountNumber();
                    txtchecking12.Visible = true;
                    ds.Clear();







                    //return;
                }
                else
                {
                    //MessageBox.Show("The Repacking Selected" + txtchecking12.Text + " IS Not Exists !!");
                    RepackIdNotExists();
                    txtchecking12.BackColor = Color.Yellow;
                    txtchecking12.Text = "";
                    txtchecking12.Select();
                    txtchecking12.Focus();
                    return;
                    //return; // ang gulo ntyo mga bugok
                }











                //if (txtchecking13.Text.Trim() == string.Empty)
                //{
                //    lbltotalread.Text = "12";
                //    Dochecking();
                //    txtchecking12.Enabled = false;
                //    txtchecking13.Visible = true;
                //    txtchecking13.Select();
                //    txtchecking13.Focus();




                //    txtrepcom13.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();

                //    return;
                //}


            }

        }

        private void buton13_Click(object sender, EventArgs e)
        {



            if (txtchecking13.Text.Trim() == string.Empty)
            {

                BarcodeNotFound();
                txtBarcode.Select();
                txtBarcode.Focus();
                txtBarcode.BackColor = Color.Yellow;


                return;
            }
            else
            {

                String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
                SqlConnection sql_con = new SqlConnection(connetionString);

                cmd = new SqlCommand("SELECT string_id FROM [dbo].[rdf_repackin_entry]  WHERE string_id='" + txtchecking13.Text + "'", sql_con);

                SqlDataAdapter daks = new SqlDataAdapter(cmd);

                daks.Fill(ds);
                int ia = ds.Tables[0].Rows.Count;
                if (ia > 0)
                {
                    //MessageBox.Show("The Formula" + txt1.Text + "Already Exists !");

                    search13();


                    if (txtBarcode.Text.Trim() == txtchecking13.Text.Trim())
                    {
                        //MessageBox.Show("Proceed Match Code");

                    }
                    else
                    {
                        //MessageBox.Show("Repak ID Not Match!, Choose the exactly item Thanks !");
                        RepackIDNotMatched();
                        txtBarcode.Text = "";
                        txtBarcode.Select();
                        txtBarcode.Focus();
                        return;
                    }


                    txtrepcom13.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();


                    txtchecking13.BackColor = Color.LightGreen;
                    pictureBox38.Visible = true;
                    //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                    txtchecking14.Focus();
                    txtchecking14.Select();
                    CountNumber();
                    txtchecking13.Visible = true;


                    ds.Clear();







                    //return;
                }
                else
                {
                    //MessageBox.Show("The Repacking Selected" + txtchecking13.Text + " IS Not Exists !!");
                    RepackIdNotExists();
                    txtchecking13.BackColor = Color.Yellow;
                    txtchecking13.Text = "";
                    txtchecking13.Select();
                    txtchecking13.Focus();
                    return;
                    //return; // ang gulo ntyo mga bugok
                }











                //if (txtchecking14.Text.Trim() == string.Empty)
                //{
                //    lbltotalread.Text = "13";
                //    Dochecking();
                //    txtchecking13.Enabled = false;
                //    txtchecking14.Visible = true;
                //    txtchecking14.Select();
                //    txtchecking14.Focus();



                //    txtrepcom14.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();


                //    return;
                //}


            }

        }

        private void buton14_Click(object sender, EventArgs e)
        {




            if (txtchecking14.Text.Trim() == string.Empty)
            {
                BarcodeNotFound();
                //MessageBox.Show("Part 14", "Barcode Input Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtchecking14.Select();
                txtchecking14.Focus();
                txtchecking14.BackColor = Color.Yellow;


                return;
            }
            else
            {
                String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
                SqlConnection sql_con = new SqlConnection(connetionString);

                cmd = new SqlCommand("SELECT string_id FROM [dbo].[rdf_repackin_entry]  WHERE string_id='" + txtchecking14.Text + "'", sql_con);

                SqlDataAdapter daks = new SqlDataAdapter(cmd);

                daks.Fill(ds);
                int ia = ds.Tables[0].Rows.Count;
                if (ia > 0)
                {
                    //MessageBox.Show("The Formula" + txt1.Text + "Already Exists !");

                    search14();


                    if (txtBarcode.Text.Trim() == txtchecking14.Text.Trim())
                    {
                        //MessageBox.Show("Proceed Match Code");

                    }
                    else
                    {
                        //MessageBox.Show("Repak ID Not Match!, Choose the exactly item Thanks !");
                        RepackIDNotMatched();
                        txtBarcode.Text = "";
                        txtBarcode.Select();
                        txtBarcode.Focus();
                        return;
                    }


                    txtrepcom14.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();


                    txtchecking14.BackColor = Color.LightGreen;
                    pictureBox39.Visible = true;
                    //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                    txtchecking14.Focus();
                    txtchecking14.Select();
                    CountNumber();
                    txtchecking14.Visible = true;

                    ds.Clear();







                    //return;
                }
                else
                {
                    //MessageBox.Show("The Repacking Selected" + txtchecking14.Text + " IS Not Exists !!");
                    RepackIdNotExists();
                    txtchecking14.BackColor = Color.Yellow;
                    txtchecking14.Text = "";
                    txtchecking14.Select();
                    txtchecking14.Focus();
                    return;
                    //return; // ang gulo ntyo mga bugok
                }









                //if (txtchecking15.Text.Trim() == string.Empty) //bobo gerard
                //{
                //    lbltotalread.Text = "14";
                //    Dochecking();
                //    txtchecking14.Enabled = false;
                //    txtchecking15.Visible = true;
                //    txtchecking15.Select();
                //    txtchecking15.Focus();



                //    txtrepcom15.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();


                //    return;
                //}


            }

        }

        private void buton15_Click(object sender, EventArgs e)
        {




            if (txtchecking15.Text.Trim() == string.Empty)
            {

                //MessageBox.Show("Part 15", "Barcode Input Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BarcodeNotFound();
                txtchecking15.Select();
                txtchecking15.Focus();
                txtchecking15.BackColor = Color.Yellow;


                return;
            }
            else
            {

                String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
                SqlConnection sql_con = new SqlConnection(connetionString);

                cmd = new SqlCommand("SELECT string_id FROM [dbo].[rdf_repackin_entry]  WHERE string_id='" + txtchecking15.Text + "'", sql_con);

                SqlDataAdapter daks = new SqlDataAdapter(cmd);

                daks.Fill(ds);
                int ia = ds.Tables[0].Rows.Count;
                if (ia > 0)
                {
                    //MessageBox.Show("The Formula" + txt1.Text + "Already Exists !");

                    search15();


                    if (txtBarcode.Text.Trim() == txtchecking15.Text.Trim())
                    {
                        //MessageBox.Show("Proceed Match Code");

                    }
                    else
                    {

                        RepackIDNotMatched();
                        txtchecking15.Text = "";
                        txtchecking15.Select();
                        txtchecking15.Focus();
                        return;
                    }


                    txtrepcom15.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();



                    txtchecking15.BackColor = Color.LightGreen;
                    pictureBox40.Visible = true;
                    //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                    txtchecking16.Focus();
                    txtchecking16.Select();
                    CountNumber();
                    txtchecking15.Visible = true;
                    //lblbatch.CurrentCell = lblbatch.Rows[i].Cells[0];
                    ds.Clear();







                    //return;
                }
                else
                {
                    //MessageBox.Show("The Repacking Selected" + txtchecking14.Text + " IS Not Exists !!");
                    RepackIdNotExists();
                    txtchecking15.BackColor = Color.Yellow;
                    txtchecking15.Text = "";
                    txtchecking15.Select();
                    txtchecking15.Focus();
                    return;
                    //return; // ang gulo ntyo mga bugok
                }








                //bobo gerard
                //if (txtchecking16.Text.Trim() == string.Empty)
                //{
                //    lbltotalread.Text = "15";
                //    Dochecking();
                //    txtchecking15.Enabled = false;
                //    txtchecking16.Visible = true;
                //    txtchecking16.Select();
                //    txtchecking16.Focus();




                //    txtrepcom16.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();


                //    return;
                //}



            }
        }

        private void buton16_Click(object sender, EventArgs e)
        {



            if (txtchecking16.Text.Trim() == string.Empty)
            {
                BarcodeNotFound();
                //MessageBox.Show("Part 16", "Barcode Input Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtchecking16.Select();
                txtchecking16.Focus();
                txtchecking16.BackColor = Color.Yellow;


                return;
            }
            else
            {

                String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
                SqlConnection sql_con = new SqlConnection(connetionString);

                cmd = new SqlCommand("SELECT string_id FROM [dbo].[rdf_repackin_entry]  WHERE string_id='" + txtchecking16.Text + "'", sql_con);

                SqlDataAdapter daks = new SqlDataAdapter(cmd);

                daks.Fill(ds);
                int ia = ds.Tables[0].Rows.Count;
                if (ia > 0)
                {


                    search16();


                    if (txtBarcode.Text.Trim() == txtchecking16.Text.Trim())
                    {
                        //MessageBox.Show("Proceed Match Code");

                    }
                    else
                    {
                        RepackIDNotMatched();
                        //MessageBox.Show("Repak ID Not Match!, Choose the exactly item Thanks !");
                        txtchecking16.Text = "";
                        txtchecking16.Select();
                        txtchecking16.Focus();
                        return;
                    }


                    txtrepcom16.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();



                    txtchecking16.BackColor = Color.LightGreen;
                    pictureBox41.Visible = true;

                    txtchecking17.Focus();
                    txtchecking17.Select();

                    CountNumber();
                    txtchecking16.Visible = true;

                    ds.Clear();







                    //return;
                }
                else
                {
                    RepackIdNotExists();
                    //MessageBox.Show("The Repacking Selected" + txtchecking16.Text + " IS Not Exists !!");
                    txtchecking16.BackColor = Color.Yellow;
                    txtchecking16.Text = "";
                    txtchecking16.Select();
                    txtchecking16.Focus();
                    return;
                    //return; // ang gulo ntyo mga bugok
                }













            }





        }

        void CountNumber()
        {

            double labeltotalread;
            double sama;

            labeltotalread = double.Parse(lbltotalread.Text);

            sama = labeltotalread + 1;

            lbltotalread.Text = Convert.ToString(sama);



            //creepy

            if (lblCounts.Text.Trim() == lbltotalread.Text.Trim())
            {
                //MessageBox.Show("Qty Needed Match Ready TO Save Gerard <3");date

         
                Timer();
                panel1.Visible = true;
                BtnSave.Visible = true;
                batchtrue1();
                txtactual1.BringToFront();
                txtactual1.Enabled = true;
                txtactual1.Focus();
                txtactual1.Select();
                ValidateOkay();
                txtactual1.Visible = true;
                txtactual1.Enabled = true;
                txtactual1.BringToFront();
                txtactual1.Select();
                txtactual1.Focus();
                txtactual1.BackColor = Color.Yellow;

            }

        }

        void ValidateOkay()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "RAW MATERIALS VALIDATED SUCCESSFULLY!";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Green;
            popup.Popup();

            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);

            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;

            txtBarcode.Enabled = false;

            //keni
           
            //dSet.Clear();
            //dSet = objStorProc.rdf_sp_new_micro_bmx(0, txtmainfeedcode.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "startbasemixed");



            actualTextboxColorYellow();

        }

        public void startbmx()
        {
            dSet.Clear();
            dSet = objStorProc.rdf_sp_new_micro_bmx(0, txtmainfeedcode.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "startbasemixed");

        }

        void actualTextboxColorYellow()
        {
            txtactual1.BackColor = Color.Yellow;
            txtactual2.BackColor = Color.Yellow;
            txtactual3.BackColor = Color.Yellow;
            txtactual4.BackColor = Color.Yellow;

            txtactual5.BackColor = Color.Yellow;
            txtactual6.BackColor = Color.Yellow;
            txtactual7.BackColor = Color.Yellow;
            txtactual8.BackColor = Color.Yellow;
            txtactual9.BackColor = Color.Yellow;
            txtactual10.BackColor = Color.Yellow;
            txtactual11.BackColor = Color.Yellow;
            txtactual12.BackColor = Color.Yellow;
            txtactual13.BackColor = Color.Yellow;

            txtactual14.BackColor = Color.Yellow;
            txtactual15.BackColor = Color.Yellow;
            txtactual16.BackColor = Color.Yellow;
            txtactual17.BackColor = Color.Yellow;
            txtactual18.BackColor = Color.Yellow;
            txtactual19.BackColor = Color.Yellow;

            txtactual20.BackColor = Color.Yellow;
            txtactual21.BackColor = Color.Yellow;
            txtactual22.BackColor = Color.Yellow;
            txtactual23.BackColor = Color.Yellow;
            txtactual24.BackColor = Color.Yellow;

            txtactual25.BackColor = Color.Yellow;
            txtactual26.BackColor = Color.Yellow;
            txtactual27.BackColor = Color.Yellow;
            txtactual28.BackColor = Color.Yellow;
            txtactual29.BackColor = Color.Yellow;
            txtactual30.BackColor = Color.Yellow;

            txtactual31.BackColor = Color.Yellow;
            txtactual32.BackColor = Color.Yellow;
            txtactual33.BackColor = Color.Yellow;
            txtactual34.BackColor = Color.Yellow;
            txtactual35.BackColor = Color.Yellow;
            txtactual36.BackColor = Color.Yellow;
            txtactual37.BackColor = Color.Yellow;

            txtactual38.BackColor = Color.Yellow;
            txtactual39.BackColor = Color.Yellow;
            txtactual40.BackColor = Color.Yellow;
            txtactual41.BackColor = Color.Yellow;
            txtactual42.BackColor = Color.Yellow;
            txtactual43.BackColor = Color.Yellow;

            txtactual44.BackColor = Color.Yellow;
            txtactual45.BackColor = Color.Yellow;
            txtactual46.BackColor = Color.Yellow;
            txtactual47.BackColor = Color.Yellow;
            txtactual48.BackColor = Color.Yellow;

            txtactual49.BackColor = Color.Yellow;
            txtactual50.BackColor = Color.Yellow;
        }










        void ValidateBasemixedPrinting()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "RAW MATERIAL MIXING SUCCESSFULLY VALIDATED!";
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
            txtactual1.Visible = true;
            txtactual1.Enabled = true;
            txtactual1.Select();
            txtactual1.Focus();
            panel1.Visible = false;

            //SaveAutomatically();

            //bunifuSubmit_Click(sender,e);

            bunifuSubmit_Click(new object(), new System.EventArgs());

        }
        private void txtchecking17_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtchecking17_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                buton17_Click(sender, e);
            }

        }

        private void buton17_Click(object sender, EventArgs e)
        {




            if (txtchecking17.Text.Trim() == string.Empty)
            {

                //MessageBox.Show("Part 17", "Barcode Input Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BarcodeNotFound();
                txtchecking17.Select();
                txtchecking17.Focus();
                txtchecking17.BackColor = Color.Yellow;


                return;
            }
            else
            {

                String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
                SqlConnection sql_con = new SqlConnection(connetionString);

                cmd = new SqlCommand("SELECT string_id FROM [dbo].[rdf_repackin_entry]  WHERE string_id='" + txtchecking17.Text + "'", sql_con);

                SqlDataAdapter daks = new SqlDataAdapter(cmd);

                daks.Fill(ds);
                int ia = ds.Tables[0].Rows.Count;
                if (ia > 0)
                {
                    //MessageBox.Show("The Formula" + txt1.Text + "Already Exists !");

                    search17();

                    if (txtBarcode.Text.Trim() == txtchecking17.Text.Trim())
                    {
                        //MessageBox.Show("Proceed Match Code");

                    }
                    else
                    {
                        RepackIDNotMatched();
                        //MessageBox.Show("Repak ID Not Match!, Choose the exactly item Thanks !");
                        txtchecking17.Text = "";
                        txtchecking17.Select();
                        txtchecking17.Focus();
                        return;
                    }


                    txtrepcom17.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();



                    txtchecking17.BackColor = Color.LightGreen;
                    pictureBox42.Visible = true;
                    //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                    txtchecking18.Focus();
                    txtchecking18.Select();
                    CountNumber();
                    txtchecking17.Visible = true;

                    ds.Clear();







                    //return;
                }
                else
                {
                    //MessageBox.Show("The Repacking Selected" + txtchecking17.Text + " IS Not Exists !!");
                    RepackIdNotExists();
                    txtchecking17.BackColor = Color.Yellow;
                    txtchecking17.Text = "";
                    txtchecking17.Select();
                    txtchecking17.Focus();
                    return;
                    //return; // ang gulo ntyo mga bugok
                }













            }


        }



        private void txtchecking16_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                buton16_Click(sender, e);
            }
        }

        private void txtchecking16_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtchecking15_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtchecking15_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buton15_Click(sender, e);
            }
        }

        private void txtchecking14_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buton14_Click(sender, e);
            }
        }

        private void txtchecking14_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtchecking13_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtchecking13_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buton13_Click(sender, e);
            }
        }

        private void txtchecking12_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtchecking12_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buton12_Click(sender, e);
            }
        }

        private void txtchecking11_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buton11_Click(sender, e);
            }
        }

        private void txtchecking11_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtchecking10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtchecking10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buton10_Click(sender, e);
            }
        }

        private void txtchecking9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buton9_Click(sender, e);
            }
        }

        private void txtchecking9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }


        void EmptyFieldNotify()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "FILL UP THE REQUIRED FIELDS";
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

        private void btn1_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            if (MetroFramework.MetroMessageBox.Show(this, $"Save the batch Entry   { lblbatchcount.Text}  Out of { label61.Text}  batch", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

        

                if (txtactual1.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtactual1.Focus();
                    txtactual1.Select();
                    txtactual1.BackColor = Color.Yellow;
                    return;
                }


                if (lblvalidate.Text.Trim() == label61.Text.Trim())
                {

                }
                else
                {

                    if (txtneeded.Text.Trim() == txtactual1.Text.Trim())
                    {
        
                    }
                    else
                    {
                        //gaspar
                        QuantityNotMatched();
                        txtactual1.Text = "";
                        txtactual1.Focus();
                        timer1.Start();

                        return;
                    }

                }




            }

            else

            {
                txtactual1.Text = "";
                timer1.Start();
                txtactual1.Focus();
                return;
            }

            //timer1.Stop();

            BtnSave.Visible = true;
            double qty1;
            double actual1;

            qty1 = double.Parse(txtqty1.Text);
            actual1 = double.Parse(txtactual1.Text);

            if (qty1 < actual1)
            {

                OverQuantity();
                txtactual1.Text = "";
                timer1.Start();
                txtactual1.Focus();
                return;
            }

            else
            {

                txtactual1.Enabled = false;
                BtnSave.Enabled = true;

                //txtactual2.Enabled = true;
                //txtactual2.Focus();

            }

            //txtrpavailable.Text = (float.Parse(txtfuck.Text) + float.Parse(txtselectweight.Text)).ToString("#,0.000");

            lblrunningtotal.Text = (float.Parse(txtactual1.Text) * 1).ToString("#,0.00");

            lblactualweight.Text = (float.Parse(txtactual1.Text) * 1).ToString(); //lusaw
            btn1.Enabled = false;
            lbllost.Text = (float.Parse(lblrunningtotal.Text) - float.Parse(lblkg.Text)).ToString("#,0.00");
            lblbatchcount.Text = "1";



            //Procedure
            BtnSave_Click(sender, e);

        }

        private void btn2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (MetroFramework.MetroMessageBox.Show(this, $"Save the batch Entry   { lblbatchcount.Text}  Out of { label61.Text}  batch", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (txtactual2.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtactual2.Focus();
                    txtactual2.Select();
                    txtactual2.BackColor = Color.Yellow;
                    return;
                }

                if (lblvalidate.Text.Trim() == label61.Text.Trim())
                {

                }
                else
                {

                    if (txtneeded.Text.Trim() == txtactual2.Text.Trim())
                    {

                    }
                    else
                    {
                        //gaspar
                        QuantityNotMatched();
                        txtactual2.Text = "";
                        txtactual2.Focus();
                        timer1.Start();

                        return;
                    }

                }








            }

            else

            {
                txtactual2.Text = "";
                timer1.Start();
                txtactual2.Focus();
                return;
            }
            //timer1.Stop();

            double qty1;
            double actual1;

            qty1 = double.Parse(txtqty2.Text);
            actual1 = double.Parse(txtactual2.Text);

            if (qty1 < actual1)
            {

                OverQuantity();
          
                txtactual2.Text = "";
                timer1.Start();
                txtactual2.Focus();
                return;
            }

            else
            {

                txtactual2.Enabled = false;
                //txtactual3.Enabled = true;
                //txtactual3.Focus();
            }






            lblrunningtotal.Text = (float.Parse(txtactual2.Text) + float.Parse(lblrunningtotal.Text)).ToString("#,0.00");
            lblactualweight.Text = (float.Parse(txtactual2.Text) * 1).ToString(); //lusaw
            btn2.Enabled = false;

            lbllost.Text = (float.Parse(lblrunningtotal.Text) - float.Parse(lblkg.Text)).ToString("#,0.00");
            lblbatchcount.Text = "2";
            BtnSave.Enabled = true;
            
            BtnSave_Click(sender, e);

        }

        private void btn3_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            if (MetroFramework.MetroMessageBox.Show(this, $"Save the batch Entry   { lblbatchcount.Text}  Out of { label61.Text} batch", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (txtactual3.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtactual3.Focus();
                    txtactual3.Select();
                    txtactual3.BackColor = Color.Yellow;
                    return;
                }



                if (lblvalidate.Text.Trim() == label61.Text.Trim())
                {

                }
                else
                {

                    if (txtneeded.Text.Trim() == txtactual3.Text.Trim())
                    {

                    }
                    else
                    {
                        //gaspar
                        QuantityNotMatched();
                        txtactual3.Text = "";
                        txtactual3.Focus();
                        timer1.Start();

                        return;
                    }

                }







            }

            else

            {
                txtactual3.Text = "";
                timer1.Start();
                txtactual3.Focus();
                return;
            }
  

            double qty1;
            double actual1;

            qty1 = double.Parse(txtqty3.Text);
            actual1 = double.Parse(txtactual3.Text);

            if (qty1 < actual1)
            {

                OverQuantity();
                txtactual3.Text = "";
                timer1.Start();
                txtactual3.Focus();
                return;
            }

            else
            {

                //txtactual3.Enabled = false;
                //txtactual4.Enabled = true;
                txtactual4.Focus();
            }



            lblrunningtotal.Text = (float.Parse(txtactual3.Text) + float.Parse(lblrunningtotal.Text)).ToString("#,0.00");
            lblactualweight.Text = (float.Parse(txtactual3.Text) * 1).ToString(); //lusaw
            btn3.Enabled = false;
            lbllost.Text = (float.Parse(lblrunningtotal.Text) - float.Parse(lblkg.Text)).ToString("#,0.00");
            lblbatchcount.Text = "3";
            txtactual3.Enabled = false;
            BtnSave.Enabled = true;
            BtnSave_Click(sender, e);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (MetroFramework.MetroMessageBox.Show(this, $"Save the batch Entry   { lblbatchcount.Text}  Out of { label61.Text} batch", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (txtactual4.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtactual4.Focus();
                    txtactual4.Select();
                    txtactual4.BackColor = Color.Yellow;
                    return;
                }



                if (lblvalidate.Text.Trim() == label61.Text.Trim())
                {

                }
                else
                {

                    if (txtneeded.Text.Trim() == txtactual4.Text.Trim())
                    {

                    }
                    else
                    {
                        //gaspar
                        QuantityNotMatched();
                        txtactual4.Text = "";
                        txtactual4.Focus();
                        timer1.Start();

                        return;
                    }

                }



            }







            else

            {
                txtactual4.Text="";
                timer1.Start();
                txtactual4.Focus();
                return;
            }


            double qty1;
            double actual1;

            qty1 = double.Parse(txtqty4.Text);
            actual1 = double.Parse(txtactual4.Text);

            if (qty1 < actual1)
            {

                OverQuantity();
                timer1.Start();
                
                txtactual4.Text = "";
                txtactual4.Focus();
                return;
            }

            else
            {

                //txtactual4.Enabled = false;
                //txtactual5.Enabled = true;
                txtactual5.Focus();
            }



            lblrunningtotal.Text = (float.Parse(txtactual4.Text) + float.Parse(lblrunningtotal.Text)).ToString("#,0.00");
            lblactualweight.Text = (float.Parse(txtactual4.Text) * 1).ToString(); //lusaw
            btn4.Enabled = false;
            lbllost.Text = (float.Parse(lblrunningtotal.Text) - float.Parse(lblkg.Text)).ToString("#,0.00");
            lblbatchcount.Text = "4";
            txtactual4.Enabled = false;
            BtnSave.Enabled = true;
            BtnSave_Click(sender, e);

        }

        private void btn5_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (MetroFramework.MetroMessageBox.Show(this, $"Save the batch Entry   { lblbatchcount.Text}  Out of { label61.Text} batch", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (txtactual5.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtactual5.Focus();
                    txtactual5.Select();
                    txtactual5.BackColor = Color.Yellow;
                    return;
                }


                if (lblvalidate.Text.Trim() == label61.Text.Trim())
                {

                }
                else
                {

                    if (txtneeded.Text.Trim() == txtactual5.Text.Trim())
                    {

                    }
                    else
                    {
                        //gaspar
                        QuantityNotMatched();
                        txtactual5.Text = "";
                        txtactual5.Focus();
                        timer1.Start();

                        return;
                    }

                }









            }




            else

            {
                txtactual5.Text = "";
                timer1.Start();
                txtactual5.Focus();
                return;
            }


            double qty1;
            double actual1;

            qty1 = double.Parse(txtqty5.Text);
            actual1 = double.Parse(txtactual5.Text);

            if (qty1 < actual1)
            {

                OverQuantity();
                txtactual5.Text = "";
                timer1.Start();
                txtactual5.Focus();
                return;
            }

            else
            {

                txtactual5.Enabled = false;
                txtactual6.Enabled = true;
                txtactual6.Focus();
            }





            lblrunningtotal.Text = (float.Parse(txtactual5.Text) + float.Parse(lblrunningtotal.Text)).ToString("#,0.00");

            lblactualweight.Text = (float.Parse(txtactual5.Text) * 1).ToString(); //lusaw
            btn5.Enabled = false;
            lblbatchcount.Text = "5";
            lbllost.Text = (float.Parse(lblrunningtotal.Text) - float.Parse(lblkg.Text)).ToString("#,0.00");
            DocheckingBatch();
            BtnSave.Enabled = true;
            BtnSave_Click(sender, e);
        }

        private void txtactual1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn1_Click(sender, e);
            }
        }

        private void txtactual2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn2_Click(sender, e);
            }
        }

        private void txtactual3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn3_Click(sender, e);
            }
        }

        private void txtactual4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn4_Click(sender, e);
            }
        }

        private void txtactual5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn5_Click(sender, e);
            }
        }

        private void button65_Click(object sender, EventArgs e)
        {

            //bujegaming
            myglobal.REPORT_NAME = "PrintBMX";
            //rpt.Refresh();
            //crV1.Refresh();

            PrintDialog printDialog = new PrintDialog();
            //if (printDialog.ShowDialog() == DialogResult.OK)


            rpt.Load(Rpt_Path + "\\bmx.rpt");
            rpt.SetDatabaseLogon("sa", "FMf3dor@2o20");
            rpt.Refresh();


            myglobal.DATE_REPORT2 = lbllastid.Text;
            string mystringid = myglobal.DATE_REPORT2;
            rpt.SetParameterValue("@myprimarykey", mystringid);







            crV1.ReportSource = rpt;
            crV1.Refresh();



            rpt.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;


            rpt.PrintToPrinter(printDialog.PrinterSettings.Copies, printDialog.PrinterSettings.Collate, printDialog.PrinterSettings.ToPage, printDialog.PrinterSettings.ToPage);






            //rpt.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;

            //rpt.PrintToPrinter(printDialog.PrinterSettings.Copies, printDialog.PrinterSettings.Collate, printDialog.PrinterSettings.ToPage, printDialog.PrinterSettings.ToPage);
            //////}

            //button65.Enabled = false;
            checkPrinting();





        }

        void checkPrinting()
        {
            if (lblbatchcount.Text == "1")
            {
                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
                {
                    //MessageBox.Show("Qty Need Batch Match Ready TO Save <3");
                    BtnSave.Visible = true;
                    ValidateBasemixedPrinting();
                    bunifuSubmit.Visible = true;

                    //takla
                    return;
                }
                else
                {

                    //true

                    //batchtrue3();
                    if (txtactual2.Text.Trim() == string.Empty)
                    {
                        txtactual2.BringToFront();
                        txtactual2.Select();
                        
                        txtactual2.Focus();
                        txtactual2.Enabled = true;
                        //BtnSave.Enabled = true;
                    }
                    batch1();
                    batch4();
                    batch3();
                    batch5();
                    batch6();

                    batch7();
                    batch8();

                    batch9();
                    batch10();

                    //true

                    //batchtrue3();
                    batchtrue2();
                    txtactual2.Select();
                    txtactual2.Focus();
                    timer1.Start();


                    //MessageBox.Show("PUTA KA!");
                }

            }
            else if (lblbatchcount.Text == "2")
            {
                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
                {
                    //MessageBox.Show("Qty Need Batch Match Ready TO Save <3");
                    ValidateBasemixedPrinting();
                    bunifuSubmit.Visible = true;
                    BtnSave.Visible = true;

                    return;
                }
                else
                {

                    if (txtactual3.Text.Trim() == string.Empty)
                    {
                        txtactual3.Enabled = true;
                        txtactual3.BringToFront();
                        txtactual3.Select();
                        txtactual3.Focus();
           
                        //BtnSave.Enabled = true;
                    }

                    if (button65.Enabled == false)
                    {
                        txtactual3.Select();
                        txtactual3.Focus();
                        txtactual3.Enabled = true;
                        //BtnSave.Enabled = true;
                    }

                    batch4();
                    batch3();
                    batch2();
                    batch5();
                    batch6();

                    batch7();
                    batch8();

                    batch9();
                    batch10();

                    //true

                    batchtrue3();
                    txtactual3.Select();
                    txtactual3.Focus();
                    timer1.Start();
                }

            }
            else if (lblbatchcount.Text == "3")
            {
                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
                {
                    //MessageBox.Show("Qty Need Batch Match Ready TO Save <3");
                    BtnSave.Visible = true;
                    ValidateBasemixedPrinting();
                    bunifuSubmit.Visible = true;

                    return;
                }
                else
                {

                    if (txtactual4.Text.Trim() == string.Empty)
                    {
                        txtactual4.Enabled = true;
                        txtactual4.BringToFront();
                        txtactual4.Select();
                        txtactual4.Focus();
           


                    }

                    if (lblbatchcount.Text == "3")
                    {

                    }
                    batch5();
                    batch6();
                    batch3();
                    batch7();
                    batch8();

                    batch9();
                    batch10();

                    //true
                    //batchtrue2();
                    //batchtrue3();
                    batchtrue4();
                    txtactual4.Select();
                    txtactual4.Focus();
                    timer1.Start();
                }



            }
            else if (lblbatchcount.Text == "4")
            {
                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
                {
                    //MessageBox.Show("Qty Need Batch Match Ready TO Save <3");
                    ValidateBasemixedPrinting();
                    bunifuSubmit.Visible = true;
                    BtnSave.Visible = true;

                    return;
                }
                else
                {

                    if (txtactual5.Text.Trim() == string.Empty)
                    {

                        txtactual5.Enabled = true;
                        txtactual5.BringToFront();
                        txtactual5.Select();
                        txtactual5.Focus();
          

                    }
                    if (lblbatchcount.Text == "4")
                    {
                        txtactual5.Focus();
                        txtactual5.Enabled = true;
                    }
                    batch1();
                    batch2();
                    batch3();
                    batch4();
                    batch6();

                    batch7();
                    batch8();

                    batch9();
                    batch10();

                    //true
                    //batchtrue2();
                    //batchtrue3();
                    batchtrue5();
                    txtactual5.Select();
                    txtactual5.Focus();
                    timer1.Start();
                }

            }

            else if (lblbatchcount.Text == "5")
            {
                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
                {
                    //MessageBox.Show("Qty Need Batch Match Ready TO Save <3");
                    BtnSave.Visible = true;
                    //bunifuSubmit.Visible = true;
                    ValidateBasemixedPrinting();
                    bunifuSubmit.Visible = true;
                    return;
                }
                else
                {

                    //true

                    if (txtactual6.Text.Trim() == string.Empty)
                    {
                        txtactual6.Enabled = true;
                        txtactual6.BringToFront();
                        txtactual6.Select();
                        txtactual6.Focus();
               

                    }

                    if (lblbatchcount.Text == "5")
                    {
                        txtactual6.Focus();
                        txtactual6.Enabled = true;
                    }
                    batch1();
                    batch2();
                    batch3();
                    batch4();
                    batch5();

                    batch7();
                    batch8();

                    batch9();
                    batch10();

                    //true
                    //batchtrue2();
                    //batchtrue3();
                    batchtrue6();
                    txtactual6.Select();
                    txtactual6.Focus();
                    timer1.Start();
                }
            }
            else if (lblbatchcount.Text == "6")
            {
                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
                {
                    ValidateBasemixedPrinting();
                    bunifuSubmit.Visible = true;
                    BtnSave.Visible = true;

                    return;
                }
                else
                {

                    //true

                    if (txtactual7.Text.Trim() == string.Empty)
                    {
                        txtactual7.Enabled = true;
                        txtactual7.BringToFront();
                        txtactual7.Select();
                        txtactual7.Focus();

                    }

                    if (lblbatchcount.Text == "6")
                    {
                        txtactual7.Focus();
                        txtactual7.Enabled = true;
                    }
                    batch1();
                    batch2();
                    batch3();
                    batch4();
                    batch5();
                    batch6();
                    //batch7();
                    batch8();

                    batch9();
                    batch10();

                    //true
                    //batchtrue2();
                    //batchtrue3();
                    batchtrue7();
                    txtactual7.Select();
                    txtactual7.Focus();
                    timer1.Start();
                }
            }
            else if (lblbatchcount.Text == "7")
            {
                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
                {
                    ValidateBasemixedPrinting();
                    bunifuSubmit.Visible = true;
                    BtnSave.Visible = true;
                    return;
                }
                else
                {

                    //true

                    if (txtactual8.Text.Trim() == string.Empty)
                    {
                        txtactual8.Enabled = true;
                        txtactual8.BringToFront();
                        txtactual8.Select();
                        txtactual8.Focus();

                    }

                    if (lblbatchcount.Text == "7")
                    {
                        txtactual8.Focus();
                        txtactual8.Enabled = true;
                    }
                    batch1();
                    batch2();
                    batch3();
                    batch4();
                    batch5();
                    batch6();
                    batch7();
                    //batch8();

                    batch9();
                    batch10();

                    //true
                    //batchtrue2();
                    //batchtrue3();
                    batchtrue8();
                    txtactual8.Select();
                    txtactual8.Focus();
                    timer1.Start();
                }
            }
            else if (lblbatchcount.Text == "8")
            {
                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
                {
                    ValidateBasemixedPrinting();
                    bunifuSubmit.Visible = true;
                    BtnSave.Visible = true;
                    return;
                }
                else
                {

                    //true

                    if (txtactual9.Text.Trim() == string.Empty)
                    {
                        //txtactual6.Focus();
                        //txtactual6.Enabled = true;
                        txtactual9.Enabled = true;
                        txtactual9.BringToFront();
                        txtactual9.Select();
                        txtactual9.Focus();

                    }

                    if (lblbatchcount.Text == "8")
                    {
                        txtactual9.Focus();
                        txtactual9.Enabled = true;
                    }
                    batch1();
                    batch2();
                    batch3();
                    batch4();
                    batch5();
                    batch6();
                    batch7();
                    batch8();

                    //batch9();
                    batch10();

                    //true
                    //batchtrue2();
                    //batchtrue3();
                    batchtrue9();
                    txtactual9.Select();
                    txtactual9.Focus();
                    timer1.Start();
                }

            }

            else if (lblbatchcount.Text == "9")
            {
                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
                {
                    ValidateBasemixedPrinting();
                    bunifuSubmit.Visible = true;
                    BtnSave.Visible = true;
                    return;
                }
                else
                {

                    //true

                    if (txtactual10.Text.Trim() == string.Empty)
                    {
                        txtactual10.Enabled = true;
                        txtactual10.BringToFront();
                        txtactual10.Select();
                        txtactual10.Focus();

                    }

                    if (lblbatchcount.Text == "9")
                    {
                        txtactual10.Focus();
                        txtactual10.Enabled = true;
                    }
                    batch1();
                    batch2();
                    batch3();
                    batch4();
                    batch5();
                    batch6();
                    batch7();
                    batch8();

                    batch9();
                    //batch10();

                    //true
                    //batchtrue2();
                    //batchtrue3();
                    batchtrue10();
                    txtactual10.Select();
                    txtactual10.Focus();
                    timer1.Start();
                }
            }

            else if (lblbatchcount.Text == "10")
            {
                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
                {
                    ValidateBasemixedPrinting();
                    bunifuSubmit.Visible = true;
                    BtnSave.Visible = true;
                    return;
                }
                else
                {

                    //true

                    if (txtactual10.Text.Trim() == string.Empty)
                    {
                        txtactual10.Enabled = true;
                        txtactual10.BringToFront();
                        txtactual10.Select();
                        txtactual10.Focus();
         

                    }

                    if (lblbatchcount.Text == "10")
                    {
                        txtactual11.Focus();
                        txtactual11.Enabled = true;
                    }
                    batch1();
                    batch2();
                    batch3();
                    batch4();
                    batch5();
                    batch6();
                    batch7();
                    batch8();

                    batch9();
                    batch10();

                    //true
                    //batchtrue2();
                    //batchtrue3();
                    batchtrue11();
                    txtactual11.Select();
                    txtactual11.Focus();
                    timer1.Start();
                }
            }
            else if (lblbatchcount.Text == "11")
            {
                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
                {
                    ValidateBasemixedPrinting();
                    bunifuSubmit.Visible = true;
                    BtnSave.Visible = true;
                    return;
                }
                else
                {

                    //true

                    if (txtactual11.Text.Trim() == string.Empty)
                    {
                        txtactual11.Enabled = true;
                        txtactual11.BringToFront();
                        txtactual11.Select();
                        txtactual11.Focus();

                    }

                    if (lblbatchcount.Text == "11")
                    {
                        txtactual12.Focus();
                        txtactual12.Enabled = true;
                    }
                    batch1();
                    batch2();
                    batch3();
                    batch4();
                    batch5();
                    batch6();
                    batch7();
                    batch8();

                    batch9();
                    batch10();
                    batch11();
                    //true
                    //batchtrue2();
                    //batchtrue3();
                    batchtrue12();
                    txtactual12.Select();
                    txtactual12.Focus();
                    timer1.Start();
                }
            }
            else if (lblbatchcount.Text == "12")
            {
                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
                {
                    ValidateBasemixedPrinting();
                    bunifuSubmit.Visible = true;
                    BtnSave.Visible = true;
                    return;
                }
                else
                {

                    //true

                    if (txtactual12.Text.Trim() == string.Empty)
                    {
                        txtactual12.Enabled = true;
                        txtactual12.BringToFront();
                        txtactual12.Select();
                        txtactual12.Focus();


                    }

                    if (lblbatchcount.Text == "12")
                    {
                        txtactual13.Focus();
                        txtactual13.Enabled = true;
                    }
                    batch1();
                    batch2();
                    batch3();
                    batch4();
                    batch5();
                    batch6();
                    batch7();
                    batch8();

                    batch9();
                    batch10();
                    batch11();
                    batch12();
                    //true
                    //batchtrue2();
                    //batchtrue3();
                    batchtrue13();
                    txtactual13.Select();
                    txtactual13.Focus();
                    timer1.Start();
                }
            }
            else if (lblbatchcount.Text == "13")
            {
                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
                {
                    ValidateBasemixedPrinting();
                    bunifuSubmit.Visible = true;
                    BtnSave.Visible = true; ;
                    return;
                }
                else
                {

                    //true

                    if (txtactual13.Text.Trim() == string.Empty)
                    {
                        txtactual13.Enabled = true;
                        txtactual13.BringToFront();
                        txtactual13.Select();
                        txtactual13.Focus();

                    }

                    if (lblbatchcount.Text == "13")
                    {
                        txtactual14.Focus();
                        txtactual14.Enabled = true;
                    }
                    batch1();
                    batch2();
                    batch3();
                    batch4();
                    batch5();
                    batch6();
                    batch7();
                    batch8();

                    batch9();
                    batch10();
                    batch11();
                    batch12();
                    batch13();

                    //true
                    //batchtrue2();
                    //batchtrue3();
                    batchtrue14();
                    txtactual14.Select();
                    txtactual14.Focus();
                    timer1.Start();
                }
            }
            else if (lblbatchcount.Text == "14")
            {
                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
                {
                    ValidateBasemixedPrinting();
                    bunifuSubmit.Visible = true;
                    BtnSave.Visible = true;
                    return;
                }
                else
                {

                    //true

                    if (txtactual14.Text.Trim() == string.Empty)
                    {
                        txtactual14.Enabled = true;
                        txtactual14.BringToFront();
                        txtactual14.Select();
                        txtactual14.Focus();
                   

                    }

                    if (lblbatchcount.Text == "14")
                    {
                        txtactual15.Focus();
                        txtactual15.Enabled = true;
                    }
                    batch1();
                    batch2();
                    batch3();
                    batch4();
                    batch5();
                    batch6();
                    batch7();
                    batch8();

                    batch9();
                    batch10();
                    batch11();
                    batch12();
                    batch13();
                    batch14();
                    //true
                    //batchtrue2();
                    //batchtrue3();
                    batchtrue15();
                    txtactual15.Select();
                    txtactual15.Focus();
                    timer1.Start();
                }
            }
            else if (lblbatchcount.Text == "15")
            {
                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
                {
                    ValidateBasemixedPrinting();
                    bunifuSubmit.Visible = true;
                    BtnSave.Visible = true;
                    return;
                }
                else
                {

                    //true

                    if (txtactual15.Text.Trim() == string.Empty)
                    {
                        txtactual15.Enabled = true;
                        txtactual15.BringToFront();
                        txtactual15.Select();
                        txtactual15.Focus();

                    }

                    if (lblbatchcount.Text == "15")
                    {
                        txtactual16.Focus();
                        txtactual16.Enabled = true;
                    }
                    batch1();
                    batch2();
                    batch3();
                    batch4();
                    batch5();
                    batch6();
                    batch7();
                    batch8();

                    batch9();
                    batch10();
                    batch11();
                    batch12();
                    batch13();
                    batch14();
                    batch15();
                    //true
                    //batchtrue2();
                    //batchtrue3();
                    batchtrue16();
                    txtactual16.Select();
                    txtactual16.Focus();
                    timer1.Start();
                }
            }
            else if (lblbatchcount.Text == "16")
            {
                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
                {
                    ValidateBasemixedPrinting();
                    bunifuSubmit.Visible = true;
                    BtnSave.Visible = true;
                    return;
                }
                else
                {

                    //true

                    if (txtactual16.Text.Trim() == string.Empty)
                    {
                        txtactual16.Enabled = true;
                        txtactual16.BringToFront();
                        txtactual16.Select();
                        txtactual16.Focus();


                    }

                    if (lblbatchcount.Text == "16")
                    {
                        txtactual17.Focus();
                        txtactual17.Enabled = true;
                    }
                    batch1();
                    batch2();
                    batch3();
                    batch4();
                    batch5();
                    batch6();
                    batch7();
                    batch8();

                    batch9();
                    batch10();
                    batch11();
                    batch12();
                    batch13();
                    batch14();
                    batch15();
                    batch16();
                    //true
                    //batchtrue2();
                    //batchtrue3();
                    batchtrue17();
                    txtactual17.Select();
                    txtactual17.Focus();
                    timer1.Start();
                }
            }
            else if (lblbatchcount.Text == "17")
            {
                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
                {
                    ValidateBasemixedPrinting();
                    bunifuSubmit.Visible = true;
                    BtnSave.Visible = true;
                    return;
                }
                else
                {

                    //true

                    if (txtactual17.Text.Trim() == string.Empty)
                    {
                        txtactual17.Enabled = true;
                        txtactual17.BringToFront();
                        txtactual17.Select();
                        txtactual17.Focus();

                    }

                    if (lblbatchcount.Text == "17")
                    {
                        txtactual18.Focus();
                        txtactual18.Enabled = true;
                    }
                    batch1();
                    batch2();
                    batch3();
                    batch4();
                    batch5();
                    batch6();
                    batch7();
                    batch8();

                    batch9();
                    batch10();
                    batch11();
                    batch12();
                    batch13();
                    batch14();
                    batch15();
                    batch16();
                    batch17();
                    //true
                    //batchtrue2();
                    //batchtrue3();
                    batchtrue18();
                    txtactual18.Select();
                    txtactual18.Focus();
                    timer1.Start();
                }
            }
            else if (lblbatchcount.Text == "18")
            {
                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
                {
                    ValidateBasemixedPrinting();
                    bunifuSubmit.Visible = true;
                    BtnSave.Visible = true;
                    return;
                }
                else
                {

                    //true

                    if (txtactual18.Text.Trim() == string.Empty)
                    {
                        txtactual18.Enabled = true;
                        txtactual18.BringToFront();
                        txtactual18.Select();
                        txtactual18.Focus();

                    }

                    if (lblbatchcount.Text == "18")
                    {
                        txtactual19.Focus();
                        txtactual19.Enabled = true;
                    }
                    batch1();
                    batch2();
                    batch3();
                    batch4();
                    batch5();
                    batch6();
                    batch7();
                    batch8();

                    batch9();
                    batch10();
                    batch11();
                    batch12();
                    batch13();
                    batch14();
                    batch15();
                    batch16();
                    batch17();
                    batch18();

                    //true
                    //batchtrue2();
                    //batchtrue3();
                    batchtrue19();
                    txtactual19.Select();
                    txtactual19.Focus();
                    timer1.Start();
                }
            }
            else if (lblbatchcount.Text == "19")
            {
                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
                {
                    ValidateBasemixedPrinting();
                    bunifuSubmit.Visible = true;
                    BtnSave.Visible = true;
                    return;
                }
                else
                {

                    //true

                    if (txtactual19.Text.Trim() == string.Empty)
                    {
                        txtactual19.Enabled = true;
                        txtactual19.BringToFront();
                        txtactual19.Select();
                        txtactual19.Focus();

                    }

                    if (lblbatchcount.Text == "19")
                    {
                        txtactual20.Focus();
                        txtactual20.Enabled = true;
                    }
                    batch1();
                    batch2();
                    batch3();
                    batch4();
                    batch5();
                    batch6();
                    batch7();
                    batch8();

                    batch9();
                    batch10();
                    batch11();
                    batch12();
                    batch13();
                    batch14();
                    batch15();
                    batch16();
                    batch17();
                    batch18();
                    batch19();
                    //true
                    //batchtrue2();
                    //batchtrue3();
                    batchtrue20();
                    txtactual20.Select();
                    txtactual20.Focus();
                    timer1.Start();
                }
            }
            else if (lblbatchcount.Text == "20")
            {
                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
                {
                    ValidateBasemixedPrinting();
                    bunifuSubmit.Visible = true;
                    BtnSave.Visible = true;
                    return;
                }
                else
                {

                    //true

                    if (txtactual20.Text.Trim() == string.Empty)
                    {
                        txtactual20.Enabled = true;
                        txtactual20.BringToFront();
                        txtactual20.Select();
                        txtactual20.Focus();

                    }

                    if (lblbatchcount.Text == "20")
                    {
                        txtactual21.Focus();
                        txtactual21.Enabled = true;
                    }
                    batch1();
                    batch2();
                    batch3();
                    batch4();
                    batch5();
                    batch6();
                    batch7();
                    batch8();

                    batch9();
                    batch10();
                    batch11();
                    batch12();
                    batch13();
                    batch14();
                    batch15();
                    batch16();
                    batch17();
                    batch18();
                    batch19();
                    batch20();
                    //true
                    //batchtrue2();
                    //batchtrue3();
                    batchtrue21();
                    txtactual21.Select();
                    txtactual21.Focus();
                    timer1.Start();
                }
            }
            //
            else if (lblbatchcount.Text == "21")
            {
                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
                {
                    ValidateBasemixedPrinting();
                    bunifuSubmit.Visible = true;
                    BtnSave.Visible = true;
                    return;
                }
                else
                {

                    //true

                    if (txtactual21.Text.Trim() == string.Empty)
                    {
                        txtactual21.Enabled = true;
                        txtactual21.BringToFront();
                        txtactual21.Select();
                        txtactual21.Focus();

                    }

                    if (lblbatchcount.Text == "21")
                    {
                        txtactual22.Focus();
                        txtactual22.Enabled = true;
                    }
                    batch1();
                    batch2();
                    batch3();
                    batch4();
                    batch5();
                    batch6();
                    batch7();
                    batch8();

                    batch9();
                    batch10();
                    batch11();
                    batch12();
                    batch13();
                    batch14();
                    batch15();
                    batch16();
                    batch17();
                    batch18();
                    batch19();
                    batch20();
                    batch21();
                    //true
                    //batchtrue2();
                    //batchtrue3();
                    batchtrue22();
                    txtactual22.Select();
                    txtactual22.Focus();
                    timer1.Start();
                }
            }

            else if (lblbatchcount.Text == "22")
            {
                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
                {
                    ValidateBasemixedPrinting();
                    bunifuSubmit.Visible = true;
                    BtnSave.Visible = true;
                    return;
                }
                else
                {

                    //true

                    if (txtactual22.Text.Trim() == string.Empty)
                    {
                        txtactual22.Enabled = true;
                        txtactual22.BringToFront();
                        txtactual22.Select();
                        txtactual22.Focus();

                    }

                    if (lblbatchcount.Text == "22")
                    {
                        txtactual23.Focus();
                        txtactual23.Enabled = true;
                    }
                    batch1();
                    batch2();
                    batch3();
                    batch4();
                    batch5();
                    batch6();
                    batch7();
                    batch8();

                    batch9();
                    batch10();
                    batch11();
                    batch12();
                    batch13();
                    batch14();
                    batch15();
                    batch16();
                    batch17();
                    batch18();
                    batch19();
                    batch20();
                    batch21();
                    batch22();
                    //true
                    //batchtrue2();
                    //batchtrue3();
                    batchtrue23();
                    txtactual23.Select();
                    txtactual23.Focus();
                    timer1.Start();
                }
            }
            else if (lblbatchcount.Text == "23")
            {
                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
                {
                    ValidateBasemixedPrinting();
                    bunifuSubmit.Visible = true;
                    BtnSave.Visible = true;
                    return;
                }
                else
                {

                    //true

                    if (txtactual23.Text.Trim() == string.Empty)
                    {
                       txtactual23.Enabled=true;
                        txtactual23.BringToFront();
                        txtactual23.Select();
                        txtactual23.Focus();

                    }

                    if (lblbatchcount.Text == "23")
                    {
                        txtactual24.Focus();
                        txtactual24.Enabled = true;
                    }
                    batch1();
                    batch2();
                    batch3();
                    batch4();
                    batch5();
                    batch6();
                    batch7();
                    batch8();

                    batch9();
                    batch10();
                    batch11();
                    batch12();
                    batch13();
                    batch14();
                    batch15();
                    batch16();
                    batch17();
                    batch18();
                    batch19();
                    batch20();
                    batch21();
                    batch22();
                    batch23();
                    //true
                    //batchtrue2();
                    //batchtrue3();
                    batchtrue24();
                    txtactual24.Select();
                    txtactual24.Focus();
                    timer1.Start();
                }
            }
            else if (lblbatchcount.Text == "24")
            {
                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
                {
                    ValidateBasemixedPrinting();
                    bunifuSubmit.Visible = true;
                    BtnSave.Visible = true;
                    return;
                }
                else
                {

                    //true

                    if (txtactual24.Text.Trim() == string.Empty)
                    {
                        txtactual24.Enabled = true;
                        txtactual24.BringToFront();
                        txtactual24.Select();
                        txtactual24.Focus();

                    }

                    if (lblbatchcount.Text == "24")
                    {
                        txtactual25.Focus();
                        txtactual25.Enabled = true;
                    }
                    batch1();
                    batch2();
                    batch3();
                    batch4();
                    batch5();
                    batch6();
                    batch7();
                    batch8();

                    batch9();
                    batch10();
                    batch11();
                    batch12();
                    batch13();
                    batch14();
                    batch15();
                    batch16();
                    batch17();
                    batch18();
                    batch19();
                    batch20();
                    batch21();
                    batch22();
                    batch23();
                    batch24();
                    //true
                    //batchtrue2();
                    //batchtrue3();
                    batchtrue25();
                    txtactual25.Select();
                    txtactual25.Focus();
                    timer1.Start();
                }
            }
            else if (lblbatchcount.Text == "25")
            {
                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
                {
                    ValidateBasemixedPrinting();
                    bunifuSubmit.Visible = true;
                    BtnSave.Visible = true;
                    return;
                }
                else
                {

                    //true

                    if (txtactual25.Text.Trim() == string.Empty)
                    {
                        txtactual25.Enabled = true;
                        txtactual25.BringToFront();
                        txtactual25.Focus();
                        txtactual25.Focus();

                    }

                    if (lblbatchcount.Text == "25")
                    {
                        txtactual26.Focus();
                        txtactual26.Enabled = true;
                    }
                    batch1();
                    batch2();
                    batch3();
                    batch4();
                    batch5();
                    batch6();
                    batch7();
                    batch8();

                    batch9();
                    batch10();
                    batch11();
                    batch12();
                    batch13();
                    batch14();
                    batch15();
                    batch16();
                    batch17();
                    batch18();
                    batch19();
                    batch20();
                    batch21();
                    batch22();
                    batch23();
                    batch24();
                    batch25();
                    //true
                    //batchtrue2();
                    //batchtrue3();
                    batchtrue26();
                    txtactual26.Select();
                    txtactual26.Focus();
                    txtactual26.Focus();
                    timer1.Start();
                }
            }
            else if (lblbatchcount.Text == "26")
            {
                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
                {
                    ValidateBasemixedPrinting();
                    bunifuSubmit.Visible = true;
                    BtnSave.Visible = true;
                    return;
                }
                else
                {

                    //true

                    if (txtactual26.Text.Trim() == string.Empty)
                    {
                        //txtactual6.Focus();
                        //txtactual6.Enabled = true;

                    }

                    if (lblbatchcount.Text == "26")
                    {
                        txtactual27.Focus();
                        txtactual27.Enabled = true;
                    }
                    batch1();
                    batch2();
                    batch3();
                    batch4();
                    batch5();
                    batch6();
                    batch7();
                    batch8();

                    batch9();
                    batch10();
                    batch11();
                    batch12();
                    batch13();
                    batch14();
                    batch15();
                    batch16();
                    batch17();
                    batch18();
                    batch19();
                    batch20();
                    batch21();
                    batch22();
                    batch23();
                    batch24();
                    batch25();
                    batch26();
                    //true
                    //batchtrue2();
                    //batchtrue3();
                    batchtrue27();
                    txtactual27.Select();
                    txtactual27.Focus();
                    timer1.Start();
                }
            }
            else if (lblbatchcount.Text == "27")
            {
                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
                {
                    ValidateBasemixedPrinting();
                    bunifuSubmit.Visible = true;
                    BtnSave.Visible = true;
                    return;
                }
                else
                {

                    //true

                    if (txtactual27.Text.Trim() == string.Empty)
                    {
                        //txtactual6.Focus();
                        //txtactual6.Enabled = true;

                    }

                    if (lblbatchcount.Text == "27")
                    {
                        txtactual28.Focus();
                        txtactual28.Enabled = true;
                    }
                    batch1();
                    batch2();
                    batch3();
                    batch4();
                    batch5();
                    batch6();
                    batch7();
                    batch8();

                    batch9();
                    batch10();
                    batch11();
                    batch12();
                    batch13();
                    batch14();
                    batch15();
                    batch16();
                    batch17();
                    batch18();
                    batch19();
                    batch20();
                    batch21();
                    batch22();
                    batch23();
                    batch24();
                    batch25();
                    batch26();
                    batch27();
                    //true
                    //batchtrue2();
                    //batchtrue3();
                    batchtrue28();
                    txtactual28.Select();
                    txtactual28.Focus();
                    timer1.Start();
                }
            }
            else if (lblbatchcount.Text == "28")
            {
                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
                {
                    ValidateBasemixedPrinting();
                    bunifuSubmit.Visible = true;
                    BtnSave.Visible = true;
                    return;
                }
                else
                {

                    //true

                    if (txtactual28.Text.Trim() == string.Empty)
                    {
                        //txtactual6.Focus();
                        //txtactual6.Enabled = true;

                    }

                    if (lblbatchcount.Text == "28")
                    {
                        txtactual29.Focus();
                        txtactual29.Enabled = true;
                    }
                    batch1();
                    batch2();
                    batch3();
                    batch4();
                    batch5();
                    batch6();
                    batch7();
                    batch8();

                    batch9();
                    batch10();
                    batch11();
                    batch12();
                    batch13();
                    batch14();
                    batch15();
                    batch16();
                    batch17();
                    batch18();
                    batch19();
                    batch20();
                    batch21();
                    batch22();
                    batch23();
                    batch24();
                    batch25();
                    batch26();
                    batch27();
                    batch28();
                    //true
                    //batchtrue2();
                    //batchtrue3();
                    batchtrue29();
                    txtactual29.Select();
                    txtactual29.Focus();
                    timer1.Start();
                }
            }
            else if (lblbatchcount.Text == "29")
            {
                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
                {
                    ValidateBasemixedPrinting();
                    bunifuSubmit.Visible = true;
                    BtnSave.Visible = true;
                    return;
                }
                else
                {

                    //true

                    if (txtactual29.Text.Trim() == string.Empty)
                    {
                        //txtactual6.Focus();
                        //txtactual6.Enabled = true;

                    }

                    if (lblbatchcount.Text == "29")
                    {
                        txtactual30.Focus();
                        txtactual30.Enabled = true;
                    }
                    batch1();
                    batch2();
                    batch3();
                    batch4();
                    batch5();
                    batch6();
                    batch7();
                    batch8();

                    batch9();
                    batch10();
                    batch11();
                    batch12();
                    batch13();
                    batch14();
                    batch15();
                    batch16();
                    batch17();
                    batch18();
                    batch19();
                    batch20();
                    batch21();
                    batch22();
                    batch23();
                    batch24();
                    batch25();
                    batch26();
                    batch27();
                    batch28();
                    batch29();
                    //true
                    //batchtrue2();
                    //batchtrue3();
                    batchtrue30();
                    txtactual30.Select();
                    txtactual30.Focus();
                    timer1.Start();
                }
            }
            else if (lblbatchcount.Text == "30")
            {
                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
                {
                    ValidateBasemixedPrinting();
                    bunifuSubmit.Visible = true;
                    BtnSave.Visible = true;
                    return;
                }
                else
                {

                    //true

                    if (txtactual30.Text.Trim() == string.Empty)
                    {
                        //txtactual6.Focus();
                        //txtactual6.Enabled = true;

                    }

                    if (lblbatchcount.Text == "30")
                    {
                        txtactual31.Focus();
                        txtactual31.Enabled = true;
                    }
                    batch1();
                    batch2();
                    batch3();
                    batch4();
                    batch5();
                    batch6();
                    batch7();
                    batch8();

                    batch9();
                    batch10();
                    batch11();
                    batch12();
                    batch13();
                    batch14();
                    batch15();
                    batch16();
                    batch17();
                    batch18();
                    batch19();
                    batch20();
                    batch21();
                    batch22();
                    batch23();
                    batch24();
                    batch25();
                    batch26();
                    batch27();
                    batch28();
                    batch29();
                    batch30();
                    //true
                    //batchtrue2();
                    //batchtrue3();
                    batchtrue31();
                    txtactual31.Select();
                    txtactual31.Focus();
                    timer1.Start();
                }
            }

            else if (lblbatchcount.Text == "31")
            {
                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
                {
                    ValidateBasemixedPrinting();
                    bunifuSubmit.Visible = true;
                    BtnSave.Visible = true;
                    return;
                }
                else
                {

                    //true

                    if (txtactual31.Text.Trim() == string.Empty)
                    {
                        //txtactual6.Focus();
                        //txtactual6.Enabled = true;

                    }

                    if (lblbatchcount.Text == "31")
                    {
                        txtactual32.Focus();
                        txtactual32.Enabled = true;
                    }
                    batch1();
                    batch2();
                    batch3();
                    batch4();
                    batch5();
                    batch6();
                    batch7();
                    batch8();

                    batch9();
                    batch10();
                    batch11();
                    batch12();
                    batch13();
                    batch14();
                    batch15();
                    batch16();
                    batch17();
                    batch18();
                    batch19();
                    batch20();
                    batch21();
                    batch22();
                    batch23();
                    batch24();
                    batch25();
                    batch26();
                    batch27();
                    batch28();
                    batch29();
                    batch30();
                    batch31();
                    //true
                    //batchtrue2();
                    //batchtrue3();
                    batchtrue32();
                    txtactual32.Select();
                    txtactual32.Focus();
                    timer1.Start();
                }
            }
            else if (lblbatchcount.Text == "32")
            {
                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
                {
                    ValidateBasemixedPrinting();
                    bunifuSubmit.Visible = true;
                    BtnSave.Visible = true;
                    return;
                }
                else
                {

                    //true

                    if (txtactual32.Text.Trim() == string.Empty)
                    {
                        //txtactual6.Focus();
                        //txtactual6.Enabled = true;

                    }

                    if (lblbatchcount.Text == "32")
                    {
                        txtactual33.Focus();
                        txtactual33.Enabled = true;
                    }
                    batch1();
                    batch2();
                    batch3();
                    batch4();
                    batch5();
                    batch6();
                    batch7();
                    batch8();

                    batch9();
                    batch10();
                    batch11();
                    batch12();
                    batch13();
                    batch14();
                    batch15();
                    batch16();
                    batch17();
                    batch18();
                    batch19();
                    batch20();
                    batch21();
                    batch22();
                    batch23();
                    batch24();
                    batch25();
                    batch26();
                    batch27();
                    batch28();
                    batch29();
                    batch30();
                    batch31();
                    batch32();
                    //true
                    //batchtrue2();
                    //batchtrue3();
                    batchtrue33();
                    txtactual33.Select();
                    txtactual33.Focus();
                    timer1.Start();
                }
            }

            else if (lblbatchcount.Text == "33")
            {
                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
                {
                    ValidateBasemixedPrinting();
                    bunifuSubmit.Visible = true;
                    BtnSave.Visible = true;
                    return;
                }
                else
                {

                    //true

                    if (txtactual33.Text.Trim() == string.Empty)
                    {
                        //txtactual6.Focus();
                        //txtactual6.Enabled = true;

                    }

                    if (lblbatchcount.Text == "33")
                    {
                        txtactual34.Focus();
                        txtactual34.Enabled = true;
                    }
                    batch1();
                    batch2();
                    batch3();
                    batch4();
                    batch5();
                    batch6();
                    batch7();
                    batch8();

                    batch9();
                    batch10();
                    batch11();
                    batch12();
                    batch13();
                    batch14();
                    batch15();
                    batch16();
                    batch17();
                    batch18();
                    batch19();
                    batch20();
                    batch21();
                    batch22();
                    batch23();
                    batch24();
                    batch25();
                    batch26();
                    batch27();
                    batch28();
                    batch29();
                    batch30();
                    batch31();
                    batch32();
                    batch33();
                    //true
                    //batchtrue2();
                    //batchtrue3();
                    batchtrue34();
                    txtactual34.Select();
                    txtactual34.Focus();
                    timer1.Start();
                }
            }

            else if (lblbatchcount.Text == "34")
            {
                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
                {
                    ValidateBasemixedPrinting();
                    bunifuSubmit.Visible = true;
                    BtnSave.Visible = true;
                    return;
                }
                else
                {

                    //true

                    if (txtactual34.Text.Trim() == string.Empty)
                    {
                        //txtactual6.Focus();
                        //txtactual6.Enabled = true;

                    }

                    if (lblbatchcount.Text == "34")
                    {
                        txtactual35.Focus();
                        txtactual35.Enabled = true;
                    }
                    batch1();
                    batch2();
                    batch3();
                    batch4();
                    batch5();
                    batch6();
                    batch7();
                    batch8();

                    batch9();
                    batch10();
                    batch11();
                    batch12();
                    batch13();
                    batch14();
                    batch15();
                    batch16();
                    batch17();
                    batch18();
                    batch19();
                    batch20();
                    batch21();
                    batch22();
                    batch23();
                    batch24();
                    batch25();
                    batch26();
                    batch27();
                    batch28();
                    batch29();
                    batch30();
                    batch31();
                    batch32();
                    batch33();
                    batch34();
                    //true
                    //batchtrue2();
                    //batchtrue3();
                    batchtrue35();
                    txtactual35.Select();
                    txtactual35.Focus();
                    timer1.Start();
                }
            }

            else if (lblbatchcount.Text == "35")
            {
                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
                {
                    ValidateBasemixedPrinting();
                    bunifuSubmit.Visible = true;
                    BtnSave.Visible = true;
                    return;
                }
                else
                {

                    //true

                    if (txtactual35.Text.Trim() == string.Empty)
                    {
                        //txtactual6.Focus();
                        //txtactual6.Enabled = true;

                    }

                    if (lblbatchcount.Text == "35")
                    {
                        txtactual36.Focus();
                        txtactual36.Enabled = true;
                    }
                    batch1();
                    batch2();
                    batch3();
                    batch4();
                    batch5();
                    batch6();
                    batch7();
                    batch8();

                    batch9();
                    batch10();
                    batch11();
                    batch12();
                    batch13();
                    batch14();
                    batch15();
                    batch16();
                    batch17();
                    batch18();
                    batch19();
                    batch20();
                    batch21();
                    batch22();
                    batch23();
                    batch24();
                    batch25();
                    batch26();
                    batch27();
                    batch28();
                    batch29();
                    batch30();
                    batch31();
                    batch32();
                    batch33();
                    batch34();
                    batch35();
                    //true
                    //batchtrue2();
                    //batchtrue3();
                    batchtrue36();
                    txtactual36.Select();
                    txtactual36.Focus();
                    timer1.Start();
                }
            }

            else if (lblbatchcount.Text == "36")
            {
                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
                {
                    ValidateBasemixedPrinting();
                    bunifuSubmit.Visible = true;
                    BtnSave.Visible = true;
                    return;
                }
                else
                {

                    //true

                    if (txtactual36.Text.Trim() == string.Empty)
                    {
                        //txtactual6.Focus();
                        //txtactual6.Enabled = true;

                    }

                    if (lblbatchcount.Text == "36")
                    {
                        txtactual37.Focus();
                        txtactual37.Enabled = true;
                    }
                    batch1();
                    batch2();
                    batch3();
                    batch4();
                    batch5();
                    batch6();
                    batch7();
                    batch8();

                    batch9();
                    batch10();
                    batch11();
                    batch12();
                    batch13();
                    batch14();
                    batch15();
                    batch16();
                    batch17();
                    batch18();
                    batch19();
                    batch20();
                    batch21();
                    batch22();
                    batch23();
                    batch24();
                    batch25();
                    batch26();
                    batch27();
                    batch28();
                    batch29();
                    batch30();
                    batch31();
                    batch32();
                    batch33();
                    batch34();
                    batch35();
                    batch36();
                    //true
                    //batchtrue2();
                    //batchtrue3();
                    batchtrue37();
                    txtactual37.Select();
                    txtactual37.Focus();
                    timer1.Start();
                }
            }

            else if (lblbatchcount.Text == "37")
            {
                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
                {
                    ValidateBasemixedPrinting();
                    bunifuSubmit.Visible = true;
                    BtnSave.Visible = true;
                    return;
                }
                else
                {

                    //true

                    if (txtactual37.Text.Trim() == string.Empty)
                    {
                        //txtactual6.Focus();
                        //txtactual6.Enabled = true;

                    }

                    if (lblbatchcount.Text == "37")
                    {
                        txtactual38.Focus();
                        txtactual38.Enabled = true;
                    }
                    batch1();
                    batch2();
                    batch3();
                    batch4();
                    batch5();
                    batch6();
                    batch7();
                    batch8();

                    batch9();
                    batch10();
                    batch11();
                    batch12();
                    batch13();
                    batch14();
                    batch15();
                    batch16();
                    batch17();
                    batch18();
                    batch19();
                    batch20();
                    batch21();
                    batch22();
                    batch23();
                    batch24();
                    batch25();
                    batch26();
                    batch27();
                    batch28();
                    batch29();
                    batch30();
                    batch31();
                    batch32();
                    batch33();
                    batch34();
                    batch35();
                    batch36();
                    batch37();
                    //true
                    //batchtrue2();
                    //batchtrue3();
                    batchtrue38();
                    txtactual38.Select();
                    txtactual38.Focus();
                    timer1.Start();
                }
            }

            else if (lblbatchcount.Text == "38")
            {
                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
                {
                    ValidateBasemixedPrinting();
                    bunifuSubmit.Visible = true;
                    BtnSave.Visible = true;
                    return;
                }
                else
                {

                    //true

                    if (txtactual38.Text.Trim() == string.Empty)
                    {
                        //txtactual6.Focus();
                        //txtactual6.Enabled = true;

                    }

                    if (lblbatchcount.Text == "38")
                    {
                        txtactual39.Focus();
                        txtactual39.Enabled = true;
                    }
                    batch1();
                    batch2();
                    batch3();
                    batch4();
                    batch5();
                    batch6();
                    batch7();
                    batch8();

                    batch9();
                    batch10();
                    batch11();
                    batch12();
                    batch13();
                    batch14();
                    batch15();
                    batch16();
                    batch17();
                    batch18();
                    batch19();
                    batch20();
                    batch21();
                    batch22();
                    batch23();
                    batch24();
                    batch25();
                    batch26();
                    batch27();
                    batch28();
                    batch29();
                    batch30();
                    batch31();
                    batch32();
                    batch33();
                    batch34();
                    batch35();
                    batch36();
                    batch37();
                    batch38();
                    //true
                    //batchtrue2();
                    //batchtrue3();
                    batchtrue39();
                    txtactual39.Select();
                    txtactual39.Focus();
                    timer1.Start();
                }
            }

            else if (lblbatchcount.Text == "39")
            {
                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
                {
                    ValidateBasemixedPrinting();
                    bunifuSubmit.Visible = true;
                    BtnSave.Visible = true;
                    return;
                }
                else
                {

                    //true

                    if (txtactual39.Text.Trim() == string.Empty)
                    {
                        //txtactual6.Focus();
                        //txtactual6.Enabled = true;

                    }

                    if (lblbatchcount.Text == "39")
                    {
                        txtactual40.Focus();
                        txtactual40.Enabled = true;
                    }
                    batch1();
                    batch2();
                    batch3();
                    batch4();
                    batch5();
                    batch6();
                    batch7();
                    batch8();

                    batch9();
                    batch10();
                    batch11();
                    batch12();
                    batch13();
                    batch14();
                    batch15();
                    batch16();
                    batch17();
                    batch18();
                    batch19();
                    batch20();
                    batch21();
                    batch22();
                    batch23();
                    batch24();
                    batch25();
                    batch26();
                    batch27();
                    batch28();
                    batch29();
                    batch30();
                    batch31();
                    batch32();
                    batch33();
                    batch34();
                    batch35();
                    batch36();
                    batch37();
                    batch38();
                    batch39();
                    //true
                    //batchtrue2();
                    //batchtrue3();
                    batchtrue40();
                    txtactual40.Select();
                    txtactual40.Focus();
                    timer1.Start();
                }
            }

            else if (lblbatchcount.Text == "40")
            {
                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
                {
                    ValidateBasemixedPrinting();
                    bunifuSubmit.Visible = true;
                    BtnSave.Visible = true;
                    return;
                }
                else
                {

                    //true

                    if (txtactual40.Text.Trim() == string.Empty)
                    {
                        //txtactual6.Focus();
                        //txtactual6.Enabled = true;

                    }

                    if (lblbatchcount.Text == "40")
                    {
                        txtactual41.Focus();
                        txtactual41.Enabled = true;
                    }
                    batch1();
                    batch2();
                    batch3();
                    batch4();
                    batch5();
                    batch6();
                    batch7();
                    batch8();

                    batch9();
                    batch10();
                    batch11();
                    batch12();
                    batch13();
                    batch14();
                    batch15();
                    batch16();
                    batch17();
                    batch18();
                    batch19();
                    batch20();
                    batch21();
                    batch22();
                    batch23();
                    batch24();
                    batch25();
                    batch26();
                    batch27();
                    batch28();
                    batch29();
                    batch30();
                    batch31();
                    batch32();
                    batch33();
                    batch34();
                    batch35();
                    batch36();
                    batch37();
                    batch38();
                    batch39();
                    batch40();
                    //true
                    //batchtrue2();
                    //batchtrue3();
                    batchtrue41();
                    txtactual41.Select();
                    txtactual41.Focus();
                    timer1.Start();
                }
            }

            else if (lblbatchcount.Text == "41")
            {
                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
                {
                    ValidateBasemixedPrinting();
                    bunifuSubmit.Visible = true;
                    BtnSave.Visible = true;
                    return;
                }
                else
                {

                    //true

                    if (txtactual41.Text.Trim() == string.Empty)
                    {
                        //txtactual6.Focus();
                        //txtactual6.Enabled = true;

                    }

                    if (lblbatchcount.Text == "41")
                    {
                        txtactual42.Focus();
                        txtactual42.Enabled = true;
                    }
                    batch1();
                    batch2();
                    batch3();
                    batch4();
                    batch5();
                    batch6();
                    batch7();
                    batch8();

                    batch9();
                    batch10();
                    batch11();
                    batch12();
                    batch13();
                    batch14();
                    batch15();
                    batch16();
                    batch17();
                    batch18();
                    batch19();
                    batch20();
                    batch21();
                    batch22();
                    batch23();
                    batch24();
                    batch25();
                    batch26();
                    batch27();
                    batch28();
                    batch29();
                    batch30();
                    batch31();
                    batch32();
                    batch33();
                    batch34();
                    batch35();
                    batch36();
                    batch37();
                    batch38();
                    batch39();
                    batch40();
                    batch41();
                    //true
                    //batchtrue2();
                    //batchtrue3();
                    batchtrue42();
                    txtactual42.Select();
                    txtactual42.Focus();
                    timer1.Start();
                }
            }

            else if (lblbatchcount.Text == "42")
            {
                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
                {
                    ValidateBasemixedPrinting();
                    bunifuSubmit.Visible = true;
                    BtnSave.Visible = true;
                    return;
                }
                else
                {

                    //true

                    if (txtactual42.Text.Trim() == string.Empty)
                    {
                        //txtactual6.Focus();
                        //txtactual6.Enabled = true;

                    }

                    if (lblbatchcount.Text == "42")
                    {
                        txtactual43.Focus();
                        txtactual43.Enabled = true;
                    }
                    batch1();
                    batch2();
                    batch3();
                    batch4();
                    batch5();
                    batch6();
                    batch7();
                    batch8();

                    batch9();
                    batch10();
                    batch11();
                    batch12();
                    batch13();
                    batch14();
                    batch15();
                    batch16();
                    batch17();
                    batch18();
                    batch19();
                    batch20();
                    batch21();
                    batch22();
                    batch23();
                    batch24();
                    batch25();
                    batch26();
                    batch27();
                    batch28();
                    batch29();
                    batch30();
                    batch31();
                    batch32();
                    batch33();
                    batch34();
                    batch35();
                    batch36();
                    batch37();
                    batch38();
                    batch39();
                    batch40();
                    batch41();
                    batch42();
                    //true
                    //batchtrue2();
                    //batchtrue3();
                    batchtrue43();
                    txtactual43.Select();
                    txtactual43.Focus();
                    timer1.Start();
                }
            }

            else if (lblbatchcount.Text == "43")
            {
                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
                {
                    ValidateBasemixedPrinting();
                    bunifuSubmit.Visible = true;
                    BtnSave.Visible = true;
                    return;
                }
                else
                {

                    //true

                    if (txtactual43.Text.Trim() == string.Empty)
                    {
                        //txtactual6.Focus();
                        //txtactual6.Enabled = true;

                    }

                    if (lblbatchcount.Text == "43")
                    {
                        txtactual44.Focus();
                        txtactual44.Enabled = true;
                    }
                    batch1();
                    batch2();
                    batch3();
                    batch4();
                    batch5();
                    batch6();
                    batch7();
                    batch8();

                    batch9();
                    batch10();
                    batch11();
                    batch12();
                    batch13();
                    batch14();
                    batch15();
                    batch16();
                    batch17();
                    batch18();
                    batch19();
                    batch20();
                    batch21();
                    batch22();
                    batch23();
                    batch24();
                    batch25();
                    batch26();
                    batch27();
                    batch28();
                    batch29();
                    batch30();
                    batch31();
                    batch32();
                    batch33();
                    batch34();
                    batch35();
                    batch36();
                    batch37();
                    batch38();
                    batch39();
                    batch40();
                    batch41();
                    batch42();
                    batch43();
                    //true
                    //batchtrue2();
                    //batchtrue3();
                    batchtrue44();
                    txtactual44.Select();
                    txtactual44.Focus();
                    timer1.Start();
                }
            }
            else if (lblbatchcount.Text == "44")
            {
                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
                {
                    ValidateBasemixedPrinting();
                    bunifuSubmit.Visible = true;
                    BtnSave.Visible = true;
                    return;
                }
                else
                {

                    //true

                    if (txtactual44.Text.Trim() == string.Empty)
                    {
                        //txtactual6.Focus();
                        //txtactual6.Enabled = true;

                    }

                    if (lblbatchcount.Text == "44")
                    {
                        txtactual45.Focus();
                        txtactual45.Enabled = true;
                    }
                    batch1();
                    batch2();
                    batch3();
                    batch4();
                    batch5();
                    batch6();
                    batch7();
                    batch8();

                    batch9();
                    batch10();
                    batch11();
                    batch12();
                    batch13();
                    batch14();
                    batch15();
                    batch16();
                    batch17();
                    batch18();
                    batch19();
                    batch20();
                    batch21();
                    batch22();
                    batch23();
                    batch24();
                    batch25();
                    batch26();
                    batch27();
                    batch28();
                    batch29();
                    batch30();
                    batch31();
                    batch32();
                    batch33();
                    batch34();
                    batch35();
                    batch36();
                    batch37();
                    batch38();
                    batch39();
                    batch40();
                    batch41();
                    batch42();
                    batch43();
                    batch44();
                    //true
                    //batchtrue2();
                    //batchtrue3();
                    batchtrue45();
                    txtactual45.Select();
                    txtactual45.Focus();
                    timer1.Start();
                }
            }
            else if (lblbatchcount.Text == "45")
            {
                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
                {
                    ValidateBasemixedPrinting();
                    bunifuSubmit.Visible = true;
                    BtnSave.Visible = true;
                    return;
                }
                else
                {

                    //true

                    if (txtactual45.Text.Trim() == string.Empty)
                    {
                        //txtactual6.Focus();
                        //txtactual6.Enabled = true;

                    }

                    if (lblbatchcount.Text == "45")
                    {
                        txtactual46.Focus();
                        txtactual46.Enabled = true;
                    }
                    batch1();
                    batch2();
                    batch3();
                    batch4();
                    batch5();
                    batch6();
                    batch7();
                    batch8();

                    batch9();
                    batch10();
                    batch11();
                    batch12();
                    batch13();
                    batch14();
                    batch15();
                    batch16();
                    batch17();
                    batch18();
                    batch19();
                    batch20();
                    batch21();
                    batch22();
                    batch23();
                    batch24();
                    batch25();
                    batch26();
                    batch27();
                    batch28();
                    batch29();
                    batch30();
                    batch31();
                    batch32();
                    batch33();
                    batch34();
                    batch35();
                    batch36();
                    batch37();
                    batch38();
                    batch39();
                    batch40();
                    batch41();
                    batch42();
                    batch43();
                    batch44();
                    batch45();
                    //true
                    //batchtrue2();
                    //batchtrue3();
                    batchtrue46();
                    txtactual46.Select();
                    txtactual46.Focus();
                    timer1.Start();
                }
            }
            else if (lblbatchcount.Text == "46")
            {
                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
                {
                    ValidateBasemixedPrinting();
                    bunifuSubmit.Visible = true;
                    BtnSave.Visible = true;
                    return;
                }
                else
                {

                    //true

                    if (txtactual46.Text.Trim() == string.Empty)
                    {
                        //txtactual6.Focus();
                        //txtactual6.Enabled = true;

                    }

                    if (lblbatchcount.Text == "46")
                    {
                        txtactual47.Focus();
                        txtactual47.Enabled = true;
                    }
                    batch1();
                    batch2();
                    batch3();
                    batch4();
                    batch5();
                    batch6();
                    batch7();
                    batch8();

                    batch9();
                    batch10();
                    batch11();
                    batch12();
                    batch13();
                    batch14();
                    batch15();
                    batch16();
                    batch17();
                    batch18();
                    batch19();
                    batch20();
                    batch21();
                    batch22();
                    batch23();
                    batch24();
                    batch25();
                    batch26();
                    batch27();
                    batch28();
                    batch29();
                    batch30();
                    batch31();
                    batch32();
                    batch33();
                    batch34();
                    batch35();
                    batch36();
                    batch37();
                    batch38();
                    batch39();
                    batch40();
                    batch41();
                    batch42();
                    batch43();
                    batch44();
                    batch45();
                    batch46();
                    batch47();
                    //true
                    //batchtrue2();
                    //batchtrue3();
                    batchtrue48();
                    txtactual48.Select();
                    txtactual48.Focus();
                    timer1.Start();
                }
            }
            else if (lblbatchcount.Text == "47")
            {
                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
                {
                    ValidateBasemixedPrinting();
                    bunifuSubmit.Visible = true;
                    BtnSave.Visible = true;
                    return;
                }
                else
                {

                    //true

                    if (txtactual47.Text.Trim() == string.Empty)
                    {
                        //txtactual6.Focus();
                        //txtactual6.Enabled = true;

                    }

                    if (lblbatchcount.Text == "47")
                    {
                        txtactual48.Focus();
                        txtactual48.Enabled = true;
                    }
                    batch1();
                    batch2();
                    batch3();
                    batch4();
                    batch5();
                    batch6();
                    batch7();
                    batch8();

                    batch9();
                    batch10();
                    batch11();
                    batch12();
                    batch13();
                    batch14();
                    batch15();
                    batch16();
                    batch17();
                    batch18();
                    batch19();
                    batch20();
                    batch21();
                    batch22();
                    batch23();
                    batch24();
                    batch25();
                    batch26();
                    batch27();
                    batch28();
                    batch29();
                    batch30();
                    batch31();
                    batch32();
                    batch33();
                    batch34();
                    batch35();
                    batch36();
                    batch37();
                    batch38();
                    batch39();
                    batch40();
                    batch41();
                    batch42();
                    batch43();
                    batch44();
                    batch45();
                    batch46();
                    batch47();
                    //true
                    //batchtrue2();
                    //batchtrue3();
                    batchtrue48();
                    txtactual48.Select();
                    txtactual48.Focus();
                    timer1.Start();
                }
            }
            else if (lblbatchcount.Text == "48")
            {
                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
                {
                    ValidateBasemixedPrinting();
                    bunifuSubmit.Visible = true;
                    BtnSave.Visible = true;
                    return;
                }
                else
                {

                    //true

                    if (txtactual48.Text.Trim() == string.Empty)
                    {
                        //txtactual6.Focus();
                        //txtactual6.Enabled = true;

                    }

                    if (lblbatchcount.Text == "48")
                    {
                        txtactual49.Focus();
                        txtactual49.Enabled = true;
                    }
                    batch1();
                    batch2();
                    batch3();
                    batch4();
                    batch5();
                    batch6();
                    batch7();
                    batch8();

                    batch9();
                    batch10();
                    batch11();
                    batch12();
                    batch13();
                    batch14();
                    batch15();
                    batch16();
                    batch17();
                    batch18();
                    batch19();
                    batch20();
                    batch21();
                    batch22();
                    batch23();
                    batch24();
                    batch25();
                    batch26();
                    batch27();
                    batch28();
                    batch29();
                    batch30();
                    batch31();
                    batch32();
                    batch33();
                    batch34();
                    batch35();
                    batch36();
                    batch37();
                    batch38();
                    batch39();
                    batch40();
                    batch41();
                    batch42();
                    batch43();
                    batch44();
                    batch45();
                    batch46();
                    batch47();
                    batch48();
                    //true
                    //batchtrue2();
                    //batchtrue3();
                    batchtrue49();
                    txtactual49.Select();
                    txtactual49.Focus();
                    timer1.Start();
                }
            }
            else if (lblbatchcount.Text == "49")
            {
                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
                {
                    ValidateBasemixedPrinting();
                    bunifuSubmit.Visible = true;
                    BtnSave.Visible = true;
                    return;
                }
                else
                {

                    //true

                    if (txtactual49.Text.Trim() == string.Empty)
                    {
                        //txtactual6.Focus();
                        //txtactual6.Enabled = true;

                    }

                    if (lblbatchcount.Text == "49")
                    {
                        txtactual50.Focus();
                        txtactual50.Enabled = true;
                    }
                    batch1();
                    batch2();
                    batch3();
                    batch4();
                    batch5();
                    batch6();
                    batch7();
                    batch8();

                    batch9();
                    batch10();
                    batch11();
                    batch12();
                    batch13();
                    batch14();
                    batch15();
                    batch16();
                    batch17();
                    batch18();
                    batch19();
                    batch20();
                    batch21();
                    batch22();
                    batch23();
                    batch24();
                    batch25();
                    batch26();
                    batch27();
                    batch28();
                    batch29();
                    batch30();
                    batch31();
                    batch32();
                    batch33();
                    batch34();
                    batch35();
                    batch36();
                    batch37();
                    batch38();
                    batch39();
                    batch40();
                    batch41();
                    batch42();
                    batch43();
                    batch44();
                    batch45();
                    batch46();
                    batch47();
                    batch48();
                    batch49();
                    //true
                    //batchtrue2();
                    //batchtrue3();
                    batchtrue50();
                    txtactual50.Select();
                    txtactual50.Focus();
                    timer1.Start();
                }
            }
            else if (lblbatchcount.Text == "50")
            {
                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
                {
                    ValidateBasemixedPrinting();
                    bunifuSubmit.Visible = true;
                    BtnSave.Visible = true;
                    return;
                }
                else
                {

                    //true

                    if (txtactual50.Text.Trim() == string.Empty)
                    {
                        //txtactual6.Focus();
                        //txtactual6.Enabled = true;

                    }

                    if (lblbatchcount.Text == "50")
                    {
                        txtactual51.Focus();
                        txtactual51.Enabled = true;
                    }
                    batch1();
                    batch2();
                    batch3();
                    batch4();
                    batch5();
                    batch6();
                    batch7();
                    batch8();

                    batch9();
                    batch10();
                    batch11();
                    batch12();
                    batch13();
                    batch14();
                    batch15();
                    batch16();
                    batch17();
                    batch18();
                    batch19();
                    batch20();
                    batch21();
                    batch22();
                    batch23();
                    batch24();
                    batch25();
                    batch26();
                    batch27();
                    batch28();
                    batch29();
                    batch30();
                    batch31();
                    batch32();
                    batch33();
                    batch34();
                    batch35();
                    batch36();
                    batch37();
                    batch38();
                    batch39();
                    batch40();
                    batch41();
                    batch42();
                    batch43();

                    batch44();
                    batch45();
                    batch46();
                    batch47();
                    batch48();
                    batch49();
                    batch50();
                    //true
                    //batchtrue2();
                    //batchtrue3();
                    batchtrue51();
                    txtactual51.Select();
                    txtactual51.Focus();
                    timer1.Start();
                }
            }
            else if (lblbatchcount.Text == "43")
            {
                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
                {
                    //MessageBox.Show("Qty Need Batch Match Ready TO Save <3");
                    BtnSave.Visible = true;
                    bunifuSubmit.Visible = true;
                    return;
                }
                else
                {

                    //true

                    if (txtactual43.Text.Trim() == string.Empty)
                    {
                        //txtactual6.Focus();
                        //txtactual6.Enabled = true;

                    }

                    if (lblbatchcount.Text == "43")
                    {
                        txtactual44.Focus();
                        txtactual44.Enabled = true;
                    }
                    batch1();
                    batch2();
                    batch3();
                    batch4();
                    batch5();
                    batch6();
                    batch7();
                    batch8();

                    batch9();
                    batch10();
                    batch11();
                    batch12();
                    batch13();
                    batch14();
                    batch15();
                    batch16();
                    batch17();
                    batch18();
                    batch19();
                    batch20();
                    batch21();
                    batch22();
                    batch23();
                    batch24();
                    batch25();
                    batch26();
                    batch27();
                    batch28();
                    batch29();
                    batch30();
                    batch31();
                    batch32();
                    batch33();
                    batch34();
                    batch35();
                    batch36();
                    batch37();
                    batch38();
                    batch39();
                    batch40();
                    batch41();
                    batch42();
                    batch43();
                    //true
                    //batchtrue2();
                    //batchtrue3();
                    batchtrue44();
                    txtactual44.Select();
                    txtactual44.Focus();
                    timer1.Start();
                }
            }
            else if (lblbatchcount.Text == "43")
            {
                if (label61.Text.Trim() == lblbatchcount.Text.Trim())
                {
                    //MessageBox.Show("Qty Need Batch Match Ready TO Save <3");
                    BtnSave.Visible = true;
                    bunifuSubmit.Visible = true;
                    return;
                }
                else
                {

                    //true

                    if (txtactual43.Text.Trim() == string.Empty)
                    {
                        //txtactual6.Focus();
                        //txtactual6.Enabled = true;

                    }

                    if (lblbatchcount.Text == "43")
                    {
                        txtactual44.Focus();
                        txtactual44.Enabled = true;
                    }
                    batch1();
                    batch2();
                    batch3();
                    batch4();
                    batch5();
                    batch6();
                    batch7();
                    batch8();

                    batch9();
                    batch10();
                    batch11();
                    batch12();
                    batch13();
                    batch14();
                    batch15();
                    batch16();
                    batch17();
                    batch18();
                    batch19();
                    batch20();
                    batch21();
                    batch22();
                    batch23();
                    batch24();
                    batch25();
                    batch26();
                    batch27();
                    batch28();
                    batch29();
                    batch30();
                    batch31();
                    batch32();
                    batch33();
                    batch34();
                    batch35();
                    batch36();
                    batch37();
                    batch38();
                    batch39();
                    batch40();
                    batch41();
                    batch42();
                    batch43();
                    //true
                    //batchtrue2();
                    //batchtrue3();
                    batchtrue44();
                    txtactual44.Select();
                    txtactual44.Focus();
                    timer1.Start();
                }
            }
            else
            {
                MessageBox.Show("Out of Range !");
            }

        }

        private void btnstart_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Start a Mixing Barcoding", "Entire Field will be Disabled!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                dgvMaster.Enabled = false;
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }


        }

        private void button37_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Cancel Entire Mixing Barcoding", "Entire Field will be Enabled!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                dgvMaster.Enabled = true;
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        private void btnsample_Click(object sender, EventArgs e)
        {
            loadPrintingData();
            //dataView.Rows[i].Cells["selected"].Value = true;
            dataView.Rows[i].Cells["selected"].Value = true;
        }

        private void dataView_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataView.RowCount > 0)
            {
                if (dataView.CurrentRow != null)
                {
                    if (dataView.CurrentRow.Cells["ID"].Value != null)
                    {
                        //p_id = Convert.ToInt32(dgvMaster.CurrentRow.Cells["prod_id"].Value);


                        lblnumplusone.Text = dataView.CurrentRow.Cells["ID"].Value.ToString();
                        lbllastid.Text = dataView.CurrentRow.Cells["bmx_id_string"].Value.ToString();





                        //txtrecommendedsearch.Text = dgvMaster.CurrentRow.Cells["item_code"].Value.ToString();
                        //txtqtyoverall.Text = dgvMaster.CurrentRow.Cells["qty_repack_available"].Value.ToString();
                        //txtmainstocks.Text = dgvMaster.CurrentRow.Cells["total_quantity_raw"].Value.ToString();

                        //cboCategor.Text = dgvMaster.CurrentRow.Cells["item_description"].Value.ToString();






                        //wala muna this


                    }

                }
            }

            lblnumplusone.Text = (float.Parse(lblnumplusone.Text) + 1).ToString();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {

            mode = "add";
            if (txtchecking1.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please Fill out all the required Textbox", "Message Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }



            

            else
            {
                if (saveMode())
                {
                    /// loadSupplier();
                    string tmode = mode;

                    if (tmode == "add")
                    {

                        SaveNotifyBasemixed();

   

                        //dataView.Visible = true;
                        loadPrintingData();

                        dataView_CurrentCellChanged(sender, e);


                        BtnSave.Enabled = false;
                        //rpt.Refresh();
                        //crV1.Refresh();
                        PercentageRefresh();

                        button65_Click(sender, e);//Printing

                    }
                    else
                    {
                        //  dgv1.CurrentCell = dgv1[0, temp_hid];
                    }

                    /// btnCancel_Click(sender, e);

                }
                else
                    MessageBox.Show("Failed");

            }







            btnReprint.Visible = true;

        }

        void PercentageRefresh()
        {
            lblPercentage.Text = (float.Parse(lbllost.Text) / float.Parse(lblkg.Text)).ToString();


            //Formulation of the variance percentage

            double sagot;
            double grandtotal;

            sagot = double.Parse(lblPercentage.Text);

            
            grandtotal = sagot * 100;


        lblpercentvar.Text = Math.Round(grandtotal, 2).ToString();
        }
        void SaveNotifyBasemixed()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "BASEMIXED SUCCESSFULLY SAVE ,BARCODE IS READY FOR PRINTING";
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

            ControlBox = false;
        }



        public bool saveMode()
        {

            if (mode == "add")
            {
                dSet.Clear();
                dSet = objStorProc.rdf_sp_new_micro_bmx(0, txtFeedCode.Text, txtmainfeedcode.Text, txtFeedType.Text, "", "", "", "", "", "", "", "", "", "", "", "getbyname");

                if (dSet.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Raw Material Repacking is already added.", "Raw Materials", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //submit button that will be disabled 


                    return false;
                }

                else
                {
                    dSet.Clear();

                    //goal muna ko to gagu!
                    dSets = objStorProc.rdf_sp_new_micro_bmx(0, txtmainfeedcode.Text.Trim(), txtFeedCode.Text.Trim(), txtFeedType.Text.Trim(), txtBags.Text.Trim(), label61.Text.Trim(), txtproddate.Text.Trim(), lblCountss.Text.Trim(), lblkg.Text.Trim(), lblCounts.Text.Trim(), lblbatchcount.Text.Trim(), "1", txtaddedby.Text.Trim(), lblactualweight.Text.Trim(), lblnumplusone.Text.Trim(), "add");


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

        private void txtFeedCode_TextChanged(object sender, EventArgs e)
        {
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);

            // AND rp_category='MICRO' ORDER BY rp_group
            string sqlquery = "SELECT IDENT_CURRENT('rdf_repackin_bmx') ";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvCount.DataSource = dt;
            //lbltotalmicro.Text = dgvCount.RowCount.ToString();


            sql_con.Close(); //4//29/2020

        }

        private void label61_Click(object sender, EventArgs e)
        {

        }

        private void label61_TextChanged(object sender, EventArgs e)
        {
            DocheckingBatch();
        }

        private void dgvMaster_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {

            if (dgvMaster.RowCount > 0)
            {
                if (dgvMaster.CurrentRow != null)
                {
                    if (dgvMaster.CurrentRow.Cells["p_feed_code"].Value != null)
                    {
                        //p_id = Convert.ToInt32(dgv1stView.CurrentRow.Cells["prod"].Value);

                        lbltotalbags.Text = dgvMaster.CurrentRow.Cells["bagorbin"].Value.ToString();
                        lbltotalbin.Text = dgvMaster.CurrentRow.Cells["additional_bin"].Value.ToString();


                    }

                }
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



        void QuantityNotMatched()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "QUANTITY NOT MATCHED !";
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

        void OverQuantity()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Warning Qty is Over !";
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



        void RepackIDNotMatched()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "REPACK ID IS NOT MATCH !";
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

        void RepackIdNotExists()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "RAW MATERIALS REPACK ID IS NOT EXISTS";
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
        private void butun1_Click_1(object sender, EventArgs e)
        {




            if (txtchecking1.Text.Trim() == string.Empty)
            {
                BarcodeNotFound();

                txtBarcode.Select();
                txtBarcode.Focus();
                txtBarcode.BackColor = Color.Yellow;


                return;
            }
            else
            {

                String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
                SqlConnection sql_con = new SqlConnection(connetionString);

                cmd = new SqlCommand("SELECT string_id FROM [dbo].[rdf_repackin_entry]  WHERE string_id='" + txtchecking1.Text + "'", sql_con);

                SqlDataAdapter daks = new SqlDataAdapter(cmd);

                daks.Fill(ds);
                int ia = ds.Tables[0].Rows.Count;
                if (ia > 0)
                {
                    //MessageBox.Show("The Formula" + txt1.Text + "Already Exists !");
                    //bosspeng
                    search();
                    dgvrepackdb.Visible = true;


                    if (txtBarcode.Text.Trim() == txtchecking1.Text.Trim())
                    {
                        //MessageBox.Show("Proceed Match Code");

                    }
                    else
                    {
                        RepackIDNotMatched();


                        txtBarcode.Text = "";
                        txtBarcode.Select();
                        txtBarcode.Focus();
                        return;
                    }


                    txtrepcom1.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();


                    txtchecking1.BackColor = Color.LightGreen;
                    pictureBox26.Visible = true;
                    //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                    txtBarcode.Text = "";
                    txtBarcode.Focus();
                    txtBarcode.Select();

                    CountNumber();
                    txtchecking1.Visible = true;



                    //lblbatch.CurrentCell = lblbatch.Rows[i].Cells[0];
                    ds.Clear();







                    //return;
                }
                else
                {
                    RepackIdNotExists();
                    //MessageBox.Show("The Repacking Selected" + txtchecking1.Text + " IS Not Exists !!");
                    txtchecking1.BackColor = Color.Yellow;
                    txtchecking1.Text = "";
                    txtchecking1.Select();
                    txtchecking1.Focus();
                    return;
                    //return; // ang gulo ntyo mga bugok
                }










                if (txtchecking2.Text.Trim() == string.Empty)
                {
                    lbltotalread.Text = "1";
                    Dochecking();
                    txtchecking1.Enabled = false;
                    txtchecking2.Visible = true;
                    txtchecking2.Select();
                    txtchecking2.Focus();


                    txtrepcom2.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();


                    return;
                }


            }


        }

        private void txtchecking1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                butun1_Click_1(sender, e);
            }
        }

        private void txtchecking2_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                butun2_Click_1(sender, e);
            }
        }

        private void butun2_Click_1(object sender, EventArgs e)
        {





            if (txtchecking2.Text.Trim() == string.Empty)
            {
                BarcodeNotFound();

                txtBarcode.Select();
                txtBarcode.Focus();
                txtBarcode.BackColor = Color.Yellow;


                return;
            }
            else
            {

                String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
                SqlConnection sql_con = new SqlConnection(connetionString);

                cmd = new SqlCommand("SELECT string_id FROM [dbo].[rdf_repackin_entry]  WHERE string_id='" + txtchecking2.Text + "'", sql_con);

                SqlDataAdapter daks = new SqlDataAdapter(cmd);

                daks.Fill(ds);
                int ia = ds.Tables[0].Rows.Count;
                if (ia > 0)
                {


                    search2();


                    if (txtBarcode.Text.Trim() == txtchecking2.Text.Trim())
                    {
                        //MessageBox.Show("Proceed Match Code");

                    }
                    else
                    {
                        RepackIDNotMatched();
                        //MessageBox.Show("Repak ID Not Match!, Choose the exactly item Thanks !");
                        txtBarcode.Text = "";
                        txtBarcode.Select();
                        txtchecking2.Focus();
                        return;
                    }


                    txtrepcom2.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();


                    txtchecking2.BackColor = Color.LightGreen;
                    pictureBox27.Visible = true;
                    //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                    txtBarcode.Text = "";
                    txtBarcode.Focus();
                    txtBarcode.Select();
                    lblbatch.CurrentCell = lblbatch.Rows[i].Cells[0];


                    CountNumber();
                    txtchecking2.Visible = true;
                    ds.Clear();







                    //return;
                }
                else
                {
                    RepackIdNotExists();
                    //MessageBox.Show("The Repacking Selected" + txtchecking2.Text + " IS Not Exists !!");
                    txtchecking2.BackColor = Color.Yellow;
                    txtBarcode.Text = "";
                    txtBarcode.Select();
                    txtBarcode.Focus();
                    return;
                    //return; // ang gulo ntyo mga bugok
                }









                //if (txtchecking3.Text.Trim() == string.Empty)
                //{
                //    lbltotalread.Text = "2";
                //    Dochecking();
                //    txtchecking2.Enabled = false;
                //    txtchecking3.Visible = true;
                //    txtchecking3.Select();
                //    txtchecking3.Focus();
                //    dgvMaster.Enabled = false;
                //    bunifuStart.Visible = false;
                //    ControlBox = false;

                //    txtrepcom3.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();


                //    return;
                //}


            }

        }

        private void txtchecking3_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                butun3_Click_1(sender, e);
            }
        }

        private void butun3_Click_1(object sender, EventArgs e)
        {




            if (txtchecking3.Text.Trim() == string.Empty)
            {

                BarcodeNotFound();
                txtBarcode.Select();
                txtBarcode.Focus();
                txtBarcode.BackColor = Color.Yellow;


                return;
            }
            else
            {

                String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
                SqlConnection sql_con = new SqlConnection(connetionString);

                cmd = new SqlCommand("SELECT string_id FROM [dbo].[rdf_repackin_entry]  WHERE string_id='" + txtchecking3.Text + "'", sql_con);

                SqlDataAdapter daks = new SqlDataAdapter(cmd);

                daks.Fill(ds);
                int ia = ds.Tables[0].Rows.Count;
                if (ia > 0)
                {


                    search3();


                    if (txtBarcode.Text.Trim() == txtchecking3.Text.Trim())
                    {
                        //MessageBox.Show("Proceed Match Code");

                    }
                    else
                    {
                        RepackIdNotExists();
                        //MessageBox.Show("Repak ID Not Match!, Choose the exactly item Thanks !");
                        txtchecking3.Text = "";
                        txtchecking3.Select();
                        txtchecking3.Focus();
                        return;
                    }


                    txtrepcom3.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();



                    txtchecking3.BackColor = Color.LightGreen;
                    pictureBox28.Visible = true;

                    txtBarcode.Focus();
                    txtBarcode.Select();

                    CountNumber();
                    txtchecking3.Visible = true;


                    //lblbatch.CurrentCell = lblbatch.Rows[i].Cells[0];
                    ds.Clear();







                    //return;
                }
                else
                {
                    //MessageBox.Show("The Repacking Selected" + txtchecking3.Text + " IS Not Exists !!");
                    RepackIdNotExists();
                    txtchecking3.BackColor = Color.Yellow;
                    txtBarcode.Text = "";
                    txtBarcode.Select();
                    txtBarcode.Focus();
                    return;
                    //return; // ang gulo ntyo mga bugok
                }











                //if (txtchecking4.Text.Trim() == string.Empty)
                //{
                //    lbltotalread.Text = "3";
                //    Dochecking();
                //    txtchecking3.Enabled = false;
                //    txtchecking4.Visible = true;
                //    txtchecking4.Select();
                //    txtchecking4.Focus();




                //    txtrepcom4.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();


                //    return;
                //}


            }
            //}


            //else
            //{
            //    search3();

            //}




        }

        private void txtchecking4_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                butun4_Click_1(sender, e);
            }
        }

        private void butun4_Click_1(object sender, EventArgs e)
        {




            if (txtchecking4.Text.Trim() == string.Empty)
            {
                BarcodeNotFound();


                txtBarcode.Select();
                txtBarcode.Focus();
                txtBarcode.BackColor = Color.Yellow;


                return;
            }
            else
            {

                String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
                SqlConnection sql_con = new SqlConnection(connetionString);

                cmd = new SqlCommand("SELECT string_id FROM [dbo].[rdf_repackin_entry]  WHERE string_id='" + txtchecking4.Text + "'", sql_con);

                SqlDataAdapter daks = new SqlDataAdapter(cmd);

                daks.Fill(ds);
                int ia = ds.Tables[0].Rows.Count;
                if (ia > 0)
                {


                    search4();


                    if (txtBarcode.Text.Trim() == txtchecking4.Text.Trim())
                    {


                    }
                    else
                    {
                        RepackIDNotMatched();

                        txtBarcode.Text = "";
                        txtBarcode.Select();
                        txtBarcode.Focus();
                        return;
                    }


                    txtrepcom4.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();



                    txtchecking4.BackColor = Color.LightGreen;
                    pictureBox29.Visible = true;

                    txtBarcode.Focus();
                    txtBarcode.Select();

                    CountNumber();
                    txtchecking4.Visible = true;



                    ds.Clear();







                    //return;
                }
                else
                {
                    RepackIdNotExists();
                    //MessageBox.Show("The Repacking Selected" + txtchecking4.Text + " IS Not Exists !!");
                    txtchecking4.BackColor = Color.Yellow;
                    txtchecking4.Text = "";
                    txtchecking4.Select();
                    txtchecking4.Focus();
                    return;
                    //return; // ang gulo ntyo mga bugok
                }









                //if (txtchecking5.Text.Trim() == string.Empty)
                //{
                //    lbltotalread.Text = "4";
                //    Dochecking();
                //    txtchecking4.Enabled = false;
                //    txtchecking5.Visible = true;

                //    txtchecking5.Select();
                //    txtchecking5.Focus();


                //    //txt1.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                //    //txtcode1.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                //    //txttotalrepack1.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                //    //txtchecking2.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();
                //    txtrepcom5.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();
                //    //txtdescription2.Text = dgv1stView.CurrentRow.Cells["rp_description"].Value.ToString();
                //    //txtbatch2.Text = dgv1stView.CurrentRow.Cells["p_nobatch"].Value.ToString();
                //    //txtqty2.Text = dgv1stView.CurrentRow.Cells["quantity"].Value.ToString();

                //    return;
                //}


            }

        }

        private void txtchecking5_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                butun5_Click_1(sender, e);
            }
        }

        private void butun5_Click_1(object sender, EventArgs e)
        {




            if (txtchecking5.Text.Trim() == string.Empty)
            {

                //MessageBox.Show("Part5", "Barcode Input Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BarcodeNotFound();
                txtBarcode.Select();
                txtBarcode.Focus();
                txtBarcode.BackColor = Color.Yellow;


                return;
            }
            else
            {

                //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
                String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
                SqlConnection sql_con = new SqlConnection(connetionString);

                cmd = new SqlCommand("SELECT string_id FROM [dbo].[rdf_repackin_entry]  WHERE string_id='" + txtchecking5.Text + "'", sql_con);

                SqlDataAdapter daks = new SqlDataAdapter(cmd);

                daks.Fill(ds);
                int ia = ds.Tables[0].Rows.Count;
                if (ia > 0)
                {


                    search5();


                    if (txtBarcode.Text.Trim() == txtchecking5.Text.Trim())
                    {
                        //MessageBox.Show("Proceed Match Code");

                    }
                    else
                    {

                        RepackIDNotMatched();
                        txtBarcode.Text = "";
                        txtBarcode.Select();
                        txtBarcode.Focus();
                        return;
                    }


                    txtrepcom5.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();



                    txtchecking5.BackColor = Color.LightGreen;
                    pictureBox30.Visible = true;

                    txtBarcode.Text = "";
                    txtBarcode.Focus();
                    txtBarcode.Select();

                    CountNumber();
                    txtchecking5.Visible = true;


                    ds.Clear();







                    //return;
                }
                else
                {
                    //MessageBox.Show("The Repacking Selected" + txtchecking5.Text + " IS Not Exists !!");
                    RepackIdNotExists();
                    txtBarcode.BackColor = Color.Yellow;
                    txtBarcode.Text = "";
                    txtBarcode.Select();
                    txtBarcode.Focus();
                    return;
                    //return; // ang gulo ntyo mga bugok
                }











                //if (txtchecking6.Text.Trim() == string.Empty)
                //{
                //    lbltotalread.Text = "5";
                //    Dochecking();
                //    txtchecking5.Enabled = false;
                //    txtchecking6.Visible = true;
                //    txtchecking6.Select();
                //    txtchecking6.Focus();



                //    txtrepcom6.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();


                //    return;
                //}


            }

        }

        private void txtchecking6_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                butun6_Click_1(sender, e);
            }
        }

        private void butun6_Click_1(object sender, EventArgs e)
        {




            if (txtchecking6.Text.Trim() == string.Empty)
            {
                BarcodeNotFound();
                //MessageBox.Show("Part6", "Barcode Input Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtchecking6.Select();
                txtchecking6.Focus();
                txtchecking6.BackColor = Color.Yellow;


                return;
            }
            else
            {

                //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
                String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
                SqlConnection sql_con = new SqlConnection(connetionString);

                cmd = new SqlCommand("SELECT string_id FROM [dbo].[rdf_repackin_entry]  WHERE string_id='" + txtchecking6.Text + "'", sql_con);

                SqlDataAdapter daks = new SqlDataAdapter(cmd);

                daks.Fill(ds);
                int ia = ds.Tables[0].Rows.Count;
                if (ia > 0)
                {
                    //MessageBox.Show("The Formula" + txt1.Text + "Already Exists !");

                    search6();


                    if (txtBarcode.Text.Trim() == txtchecking6.Text.Trim())
                    {
                        //MessageBox.Show("Proceed Match Code");

                    }
                    else
                    {
                        RepackIDNotMatched();
                        //MessageBox.Show("Repak ID Not Match!, Choose the exactly item Thanks !");
                        txtBarcode.Text = "";
                        txtchecking6.Select();
                        txtchecking6.Focus();
                        return;
                    }


                    txtrepcom6.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();



                    txtchecking6.BackColor = Color.LightGreen;
                    pictureBox31.Visible = true;
                    //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                    txtchecking7.Focus();
                    txtchecking7.Select();

                    CountNumber();
                    txtchecking6.Visible = true;

                    ds.Clear();







                    //return;
                }
                else
                {
                    //MessageBox.Show("The Repacking Selected" + txtchecking6.Text + " IS Not Exists !!");
                    RepackIdNotExists();
                    txtchecking6.BackColor = Color.Yellow;
                    txtchecking6.Text = "";
                    txtchecking6.Select();
                    txtchecking6.Focus();
                    return;
                    //return; // ang gulo ntyo mga bugok
                }










                //if (txtchecking7.Text.Trim() == string.Empty)
                //{
                //    lbltotalread.Text = "6";
                //    Dochecking();
                //    txtchecking6.Enabled = false;
                //    txtchecking7.Visible = true;
                //    txtchecking7.Select();
                //    txtchecking7.Focus();


                //    //txt1.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                //    //txtcode1.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                //    //txttotalrepack1.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                //    //txtchecking2.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();
                //    txtrepcom7.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();
                //    //txtdescription2.Text = dgv1stView.CurrentRow.Cells["rp_description"].Value.ToString();
                //    //txtbatch2.Text = dgv1stView.CurrentRow.Cells["p_nobatch"].Value.ToString();
                //    //txtqty2.Text = dgv1stView.CurrentRow.Cells["quantity"].Value.ToString();

                //    return;
                //}


            }

        }

        private void txtchecking7_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                butun7_Click_1(sender, e);
            }
        }

        private void butun7_Click_1(object sender, EventArgs e)
        {




            if (txtchecking7.Text.Trim() == string.Empty)
            {

                //MessageBox.Show("Part7", "Barcode Input Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BarcodeNotFound();
                txtchecking7.Select();
                txtchecking7.Focus();
                txtchecking7.BackColor = Color.Yellow;


                return;
            }
            else
            {

                //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
                String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
                SqlConnection sql_con = new SqlConnection(connetionString);

                cmd = new SqlCommand("SELECT string_id FROM [dbo].[rdf_repackin_entry]  WHERE string_id='" + txtchecking7.Text + "'", sql_con);

                SqlDataAdapter daks = new SqlDataAdapter(cmd);

                daks.Fill(ds);
                int ia = ds.Tables[0].Rows.Count;
                if (ia > 0)
                {


                    search7();


                    if (txtBarcode.Text.Trim() == txtchecking7.Text.Trim())
                    {


                    }
                    else
                    {

                        RepackIDNotMatched();
                        txtchecking7.Text = "";
                        txtchecking7.Select();
                        txtchecking7.Focus();
                        return;
                    }


                    txtrepcom7.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();



                    txtchecking7.BackColor = Color.LightGreen;
                    pictureBox32.Visible = true;
                    txtBarcode.Focus();
                    txtBarcode.Select();

                    CountNumber();
                    txtchecking7.Visible = true;



                    ds.Clear();







                    //return;
                }
                else
                {
                    RepackIdNotExists();

                    txtchecking7.BackColor = Color.Yellow;
                    txtchecking7.Text = "";
                    txtchecking7.Select();
                    txtchecking7.Focus();
                    return;
                    //return; // ang gulo ntyo mga bugok
                }











                //if (txtchecking8.Text.Trim() == string.Empty)
                //{
                //    lbltotalread.Text = "7";
                //    Dochecking();
                //    txtchecking7.Enabled = false;
                //    txtchecking8.Visible = true;
                //    txtchecking8.Select();
                //    txtchecking8.Focus();



                //    txtrepcom8.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();


                //    return;
                //}


            }

        }

        private void txtchecking8_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                butun8_Click(sender, e);
            }
        }

        private void butun8_Click(object sender, EventArgs e)
        {




            if (txtchecking8.Text.Trim() == string.Empty)
            {
                BarcodeNotFound();
                //MessageBox.Show("Part8", "Barcode Input Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtchecking8.Select();
                txtchecking8.Focus();
                txtchecking8.BackColor = Color.Yellow;


                return;
            }
            else
            {

                //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
                String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
                SqlConnection sql_con = new SqlConnection(connetionString);

                cmd = new SqlCommand("SELECT string_id FROM [dbo].[rdf_repackin_entry]  WHERE string_id='" + txtchecking8.Text + "'", sql_con);

                SqlDataAdapter daks = new SqlDataAdapter(cmd);

                daks.Fill(ds);
                int ia = ds.Tables[0].Rows.Count;
                if (ia > 0)
                {
                    //MessageBox.Show("The Formula" + txt1.Text + "Already Exists !");

                    search8();


                    if (txtBarcode.Text.Trim() == txtchecking8.Text.Trim())
                    {
                        //MessageBox.Show("Proceed Match Code");

                    }
                    else
                    {
                        RepackIDNotMatched();
                        //MessageBox.Show("Repak ID Not Match!, Choose the exactly item Thanks !");
                        txtchecking8.Text = "";
                        txtchecking8.Select();
                        txtchecking8.Focus();
                        return;
                    }


                    txtrepcom8.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();



                    txtchecking8.BackColor = Color.LightGreen;
                    pictureBox33.Visible = true;
                    //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                    txtchecking8.Focus();
                    txtchecking8.Select();

                    CountNumber();
                    txtchecking8.Visible = true;


                    ds.Clear();







                    //return;
                }
                else
                {
                    //MessageBox.Show("The Repacking Selected" + txtchecking8.Text + " IS Not Exists !!");
                    RepackIdNotExists();
                    txtchecking8.BackColor = Color.Yellow;
                    txtchecking8.Text = "";
                    txtchecking8.Select();
                    txtchecking8.Focus();
                    return;
                    //return; // ang gulo ntyo mga bugok
                }










                //if (txtchecking9.Text.Trim() == string.Empty)
                //{
                //    lbltotalread.Text = "8";
                //    Dochecking();
                //    txtchecking8.Enabled = false;
                //    txtchecking9.Visible = true;
                //    txtchecking9.Focus();
                //    txtchecking9.Select();

                //    txtrepcom9.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();

                //    return;
                //}


            }

        }

        private void txtchecking9_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buton9_Click_1(sender, e);
            }
        }

        private void buton9_Click_1(object sender, EventArgs e)
        {
            if (lblbatch.Rows.Count >= 1)
            {
                int i = lblbatch.CurrentRow.Index + 1;
                if (i >= -1 && i < lblbatch.Rows.Count)



                    if (txtchecking9.Text.Trim() == string.Empty)
                    {
                        BarcodeNotFound();
                        //MessageBox.Show("Part 9", "Barcode Input Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtchecking9.Select();
                        txtchecking9.Focus();
                        txtchecking9.BackColor = Color.Yellow;


                        return;
                    }
                    else
                    {

                        //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
                        String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
                        SqlConnection sql_con = new SqlConnection(connetionString);

                        cmd = new SqlCommand("SELECT string_id FROM [dbo].[rdf_repackin_entry]  WHERE string_id='" + txtchecking9.Text + "'", sql_con);

                        SqlDataAdapter daks = new SqlDataAdapter(cmd);

                        daks.Fill(ds);
                        int ia = ds.Tables[0].Rows.Count;
                        if (ia > 0)
                        {


                            search9();

                            if (txtrepcom9.Text.Trim() == txtchecking9.Text.Trim())
                            {
                                //MessageBox.Show("Proceed Match Code");

                            }
                            else
                            {
                                RepackIDNotMatched();
                                //MessageBox.Show("Repak ID Not Match!, Choose the exactly item Thanks !");
                                txtchecking9.Text = "";
                                txtchecking9.Select();
                                txtchecking9.Focus();
                                return;
                            }


                            txtrepcom9.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();

                            //txtchecking9.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();

                            txtchecking9.BackColor = Color.LightGreen;
                            pictureBox34.Visible = true;
                            //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                            CountNumber();
                            txtchecking9.Visible = true;
                            txtchecking10.Focus();
                            txtchecking10.Select();
                            lblbatch.CurrentCell = lblbatch.Rows[i].Cells[0];
                            ds.Clear();







                            //return;
                        }
                        else
                        {
                            RepackIDNotMatched();
                            //MessageBox.Show("The Repacking Selected" + txtchecking9.Text + " IS Not Exists !!");
                            txtchecking9.BackColor = Color.Yellow;
                            txtchecking9.Text = "";
                            txtchecking9.Select();
                            txtchecking9.Focus();
                            return;
                            //return; // ang gulo ntyo mga bugok
                        }










                        //if (txtchecking10.Text.Trim() == string.Empty)
                        //{
                        //    lbltotalread.Text = "9";
                        //    Dochecking();
                        //    txtchecking9.Enabled = false;
                        //    txtchecking10.Visible = true;
                        //    txtchecking10.Select();
                        //    txtchecking10.Focus();



                        //    txtrepcom10.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();

                        //    return;
                        //}


                    }
            }


            else
            {
                search9();

            }
        }

        private void txtchecking10_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buton10_Click_1(sender, e);
            }
        }

        private void buton10_Click_1(object sender, EventArgs e)
        {
            buton10_Click(sender, e);
        }

        private void txtchecking11_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buton11_Click_1(sender, e);
            }
        }

        private void buton11_Click_1(object sender, EventArgs e)
        {
            buton11_Click(sender, e);
        }

        private void txtchecking12_KeyDown_1(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                buton12_Click_1(sender, e);
            }
        }

        private void buton12_Click_1(object sender, EventArgs e)
        {
            buton12_Click(sender, e);
        }

        private void txtchecking13_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buton13_Click_1(sender, e);
            }
        }

        private void buton13_Click_1(object sender, EventArgs e)
        {
            buton13_Click(sender, e);
        }

        private void txtchecking14_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buton14_Click_1(sender, e);
            }
        }

        private void buton14_Click_1(object sender, EventArgs e)
        {
            buton14_Click(sender, e);
        }

        private void txtchecking15_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buton15_Click_1(sender, e);
            }
        }

        private void buton15_Click_1(object sender, EventArgs e)
        {
            buton15_Click(sender, e);
        }

        private void txtchecking16_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buton16_Click_1(sender, e);
            }
        }

        private void buton16_Click_1(object sender, EventArgs e)
        {
            buton16_Click(sender, e);
        }

        private void txtchecking17_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buton17_Click_1(sender, e);
            }
        }

        private void buton17_Click_1(object sender, EventArgs e)
        {
            buton17_Click(sender, e);
        }

        private void txtchecking18_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buton18_Click(sender, e);
            }
        }

        private void buton18_Click(object sender, EventArgs e)
        {




            if (txtchecking18.Text.Trim() == string.Empty)
            {

                //MessageBox.Show("Part 18", "Barcode Input Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BarcodeNotFound();
                txtchecking18.Select();
                txtchecking18.Focus();
                txtchecking18.BackColor = Color.Yellow;


                return;
            }
            else
            {

                //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
                String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
                SqlConnection sql_con = new SqlConnection(connetionString);

                cmd = new SqlCommand("SELECT string_id FROM [dbo].[rdf_repackin_entry]  WHERE string_id='" + txtchecking18.Text + "'", sql_con);

                SqlDataAdapter daks = new SqlDataAdapter(cmd);

                daks.Fill(ds);
                int ia = ds.Tables[0].Rows.Count;
                if (ia > 0)
                {


                    search18();


                    if (txtBarcode.Text.Trim() == txtchecking18.Text.Trim())
                    {
                        //MessageBox.Show("Proceed Match Code");

                    }
                    else
                    {
                        RepackIDNotMatched();
                        //MessageBox.Show("Repak ID Not Match!, Choose the exactly item Thanks !");
                        txtchecking18.Text = "";
                        txtchecking18.Select();
                        txtchecking18.Focus();
                        return;
                    }


                    txtrepcom18.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();



                    txtchecking18.BackColor = Color.LightGreen;
                    pictureBox43.Visible = true;
                    //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                    txtchecking19.Focus();
                    txtchecking19.Select();

                    CountNumber();
                    txtchecking18.Visible = true;
                    ds.Clear();







                    //return;
                }
                else
                {
                    RepackIdNotExists();
                    //MessageBox.Show("The Repacking Selected" + txtchecking18.Text + " IS Not Exists !!");
                    txtchecking18.BackColor = Color.Yellow;
                    txtchecking18.Text = "";
                    txtchecking18.Select();
                    txtchecking18.Focus();
                    return;
                    //return; // ang gulo ntyo mga bugok
                }





            }





        }

        private void bunifuSubmit_Click(object sender, EventArgs e)
        {
            ViewDataProduction();
            ViewCellChanger();

            //pekpek
            txtdatenowstamp.Text = DateTime.Now.ToString();
            // this is the new update to remove the existing timespan errror
            DateTime time1 = DateTime.Parse(txtstartmacrorepacking.Text);
            DateTime time2 = DateTime.Parse(txtdatenowstamp.Text);

            TimeSpan difference = time2 - time1;



            txtSumofRepacking.Text = Convert.ToString(difference);





            mode = "add";
            if (txtmainfeedcode.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please Select production", "Production Today", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (saveMode2())
                {
                    /// loadSupplier();
                    string tmode = mode;

                    if (tmode == "add")
                    {
                        //  dgv1.CurrentCell = dgv1[0, dgv1.Rows.Count - 1];



                        //////PreparationAlreadySave();


                        //calling the dashboards!
                        bunifuSubmit.Visible = false;
                        //button27_Click(sender, e);



                        //   Mainmenu.Refresh();
                        //   this.Close();
                    }
                    else
                    {
                        //  dgv1.CurrentCell = dgv1[0, temp_hid];
                    }

                    /// btnCancel_Click(sender, e);

                }
                else
                    MessageBox.Show("F");

            }


            //3 query function james foul
            ViewDataProduction();
            ViewCellChanger();

            QueryTryCatchProdTimes(); //gerard singian
            //4 query is for insert the audit trail
            dSet = objStorProc.rdf_sp_new_preparation(0, txtFeedCode.Text, txtaddedby.Text, "5.1 Micro Material Mixing", "Perform the Basemixed Mixing", txtdatenowstamp.Text, txtmainfeedcode.Text, label61.Text, "", "", "", "", "", "", "", "", "", "", "addTrailLogs");

            lblpercentvar.Text = "0";

            SaveClear();
            dgvMaster_CurrentCellChanged_1(sender, e);
            lbllost.Text = "0";
            timer1.Stop();

            dgvMaster.Enabled = false;
            bunifuStart.Visible = true;
            hideAllbatch();
            panel1.Visible = false;
            lbltotalread.Text = "0";
            btnlessthan_Click(sender, e);
            SaveSuccesfull();
        }

        void ViewDataProduction()
        {


            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "SELECT * FROM [dbo].[rdf_production_advance] WHERE prod_id= '" + txtmainfeedcode.Text + "' AND is_selected='1' ";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvUpdateTimeLampse.DataSource = dt;

            sql_con.Close();

            lblcountfg.Text = dgvUpdateTimeLampse.RowCount.ToString();



        }





        void QueryTryCatchProdTimes()
        {
            txtdatenowstamp.Text = DateTime.Now.ToString();
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            //deploy
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "UPDATE [dbo].[rdf_production_advance] SET basemixed_time='" + txtSumofRepacking.Text + "' WHERE prod_id= '" + txtmainfeedcode.Text + "'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvUpdateTimeLampse.DataSource = dt;

            sql_con.Close();




        }



        void SaveAutomatically()
        {

 

        }

        void SaveSuccesfull()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "MICRO MIXING SUCCESSFULLY SAVE !";
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
            SaveClear();
            txtBarcode.Visible = true;
            lbllost.Text = "0";
            bunifuSubmit.Visible = false;
            if (txtluffy.Text == "0")
            {


            }
            else
            {

                lbltotalread.Text = "0";
                txtBarcode.Enabled = true;
                txtBarcode.Select();
                txtBarcode.Focus();
            }
            frmPreparationofMixing_Load(new object(), new System.EventArgs());
        }



































        void SaveClear()
        {
            txtchecking1.Text = "";
            txtchecking1.BackColor = Color.White;
            txtBarcode.Visible = false;
            txtBarcode.Select();
            txtBarcode.Focus();
            txtactual1.Text = "";


            txtchecking2.Text = "";
            txtchecking2.BackColor = Color.White;
            txtchecking2.Visible = false;
            txtactual2.Text = "";

            txtchecking3.Text = "";
            txtchecking3.BackColor = Color.White;
            txtchecking3.Visible = false;
            txtactual3.Text = "";

            txtchecking4.Text = "";
            txtchecking4.BackColor = Color.White;
            txtchecking4.Visible = false;
            txtactual4.Text = "";

            txtchecking5.Text = "";
            txtchecking5.BackColor = Color.White;
            txtchecking5.Visible = false;
            txtactual5.Text = "";

            txtchecking6.Text = "";
            txtchecking6.BackColor = Color.White;
            txtchecking6.Visible = false;
            txtactual6.Text = "";

            txtchecking7.Text = "";
            txtchecking7.BackColor = Color.White;
            txtchecking7.Visible = false;
            txtactual7.Text = "";

            txtchecking8.Text = "";
            txtchecking8.BackColor = Color.White;
            txtchecking8.Visible = false;
            txtactual8.Text = "";

            txtchecking9.Text = "";
            txtchecking9.BackColor = Color.White;
            txtchecking9.Visible = false;
            txtactual9.Text = "";

            txtchecking10.Text = "";
            txtchecking10.BackColor = Color.White;
            txtchecking10.Visible = false;
            txtactual10.Text = "";

            txtchecking11.Text = "";
            txtchecking11.BackColor = Color.White;
            txtchecking11.Visible = false;

            txtchecking12.Text = "";
            txtchecking12.BackColor = Color.White;
            txtchecking12.Visible = false;

            txtchecking13.Text = "";
            txtchecking13.BackColor = Color.White;
            txtchecking13.Visible = false;

            txtchecking14.Text = "";
            txtchecking14.BackColor = Color.White;
            txtchecking14.Visible = false;

            txtchecking15.Text = "";
            txtchecking15.BackColor = Color.White;
            txtchecking15.Visible = false;

            txtchecking16.Text = "";
            txtchecking16.BackColor = Color.White;
            txtchecking16.Visible = false;

            txtchecking17.Text = "";
            txtchecking17.BackColor = Color.White;
            txtchecking17.Visible = false;

            txtchecking18.Text = "";
            txtchecking18.BackColor = Color.White;
            txtchecking18.Visible = false;

            txtchecking19.Text = "";
            txtchecking19.BackColor = Color.White;
            txtchecking19.Visible = false;

            txtchecking20.Text = "";
            txtchecking20.BackColor = Color.White;
            txtchecking20.Visible = false;

            txtchecking21.Text = "";
            txtchecking21.BackColor = Color.White;
            txtchecking21.Visible = false;

            txtchecking22.Text = "";
            txtchecking22.BackColor = Color.White;
            txtchecking22.Visible = false;

            txtchecking23.Text = "";
            txtchecking23.BackColor = Color.White;
            txtchecking23.Visible = false;


            txtchecking24.Text = "";
            txtchecking24.BackColor = Color.White;
            txtchecking24.Visible = false;

            txtchecking25.Text = "";
            txtchecking25.BackColor = Color.White;
            txtchecking25.Visible = false;

            txtchecking26.Text = "";
            txtchecking26.BackColor = Color.White;
            txtchecking26.Enabled = true;













            txtrepcom1.Text = "";
            txtrepcom2.Text = "";
            txtrepcom3.Text = "";
            txtrepcom4.Text = "";
            txtrepcom5.Text = "";
            txtrepcom6.Text = "";
            txtrepcom7.Text = "";
            txtrepcom8.Text = "";
            txtrepcom9.Text = "";
            txtrepcom10.Text = "";
            txtrepcom11.Text = "";
            txtrepcom12.Text = "";
            txtrepcom13.Text = "";
            txtrepcom14.Text = "";
            txtrepcom15.Text = "";
            txtrepcom16.Text = "";
            txtrepcom17.Text = "";
            txtrepcom18.Text = "";
            txtrepcom19.Text = "";
            txtrepcom20.Text = "";
            txtrepcom21.Text = "";
            txtrepcom22.Text = "";
            txtrepcom23.Text = "";
            txtrepcom24.Text = "";
            txtrepcom25.Text = "";

            PictureBoxhide();
        }

        void PictureBoxhide()
        {
            pictureBox26.Visible = false;
            pictureBox27.Visible = false;
            pictureBox28.Visible = false;
            pictureBox29.Visible = false;
            pictureBox30.Visible = false;
            pictureBox31.Visible = false;
            pictureBox32.Visible = false;
            pictureBox33.Visible = false;
            pictureBox34.Visible = false;
            pictureBox35.Visible = false;
            pictureBox36.Visible = false;
            pictureBox37.Visible = false;
            pictureBox38.Visible = false;
            pictureBox39.Visible = false;
            pictureBox40.Visible = false;
            pictureBox41.Visible = false;
            pictureBox42.Visible = false;
            pictureBox43.Visible = false;
            pictureBox44.Visible = false;
            pictureBox45.Visible = false;
            pictureBox46.Visible = false;
            pictureBox47.Visible = false;
            pictureBox48.Visible = false;
            pictureBox49.Visible = false;
            pictureBox50.Visible = false;

        }



        public bool saveMode2()
        {
            txtdatenowstamp.Text = DateTime.Now.ToString("M/d/yyyy");
            //summer
            //lblPercentage.Text = (float.Parse(lbllost.Text) / float.Parse(lblrunningtotal.Text)).ToString();



            ////Formulation of the variance percentage

            //double sagot;
            //double grandtotal;

            //sagot = double.Parse(lblPercentage.Text);


            //grandtotal = sagot * 100;


            //lblPerctentageAndDivisor.Text = Math.Round(grandtotal, 3).ToString();




            if (mode == "add")
            {
                dSet.Clear();
                dSet = objStorProc.rdf_sp_new_basemixed(0, "", txtmainfeedcode.Text, lblnum24.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "","", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "getbyname");

                if (dSet.Tables[0].Rows.Count > 0)
                {

                    BtnSave.Enabled = false;

                    //calling the dashboard counts
                    //buje
                    //dSets = objStorProc.rdf_sp_new_basemixed(0, txtproddate.Text.Trim(), txtFeedCode.Text.Trim(), txtFeedType.Text.Trim(), txtBags.Text.Trim(), txtmainfeedcode.Text.Trim(), label61.Text.Trim(), lblCounts.Text.Trim(), lblCountss.Text.Trim(), lblkg.Text.Trim(), lblrunningtotal.Text.Trim(), lbllost.Text.Trim(),txtdatenowstamp,Text.Trim(), txtactual1.Text.Trim(), txtactual2.Text.Trim(), txtactual3.Text.Trim(), txtactual4.Text.Trim(), txtactual5.Text.Trim(), txtactual6.Text.Trim(), txtactual7.Text.Trim(), txtactual8.Text.Trim(), txtactual9.Text.Trim(), txtactual10.Text.Trim(), txtactual11.Text.Trim(), txtactual12.Text.Trim(), txtactual13.Text.Trim(), txtactual14.Text.Trim(), txtactual15.Text.Trim(), txtactual16.Text.Trim(), txtactual17.Text.Trim(), txtactual18.Text.Trim(), txtactual19.Text.Trim(), txtactual20.Text.Trim(), txtactual21.Text.Trim(), txtactual22.Text.Trim(), txtactual23.Text.Trim(), txtactual24.Text.Trim(), txtactual25.Text.Trim(), txtactual26.Text.Trim(), txtactual27.Text.Trim(), txtactual28.Text.Trim(), txtactual29.Text.Trim(), txtactual30.Text.Trim(), txtactual31.Text.Trim(), txtactual32.Text.Trim(), txtactual33.Text.Trim(), txtactual34.Text.Trim(), txtactual35.Text.Trim(), txtactual36.Text.Trim(), txtactual37.Text.Trim(), txtactual38.Text.Trim(), txtactual39.Text.Trim(), txtactual40.Text.Trim(), txtactual41.Text.Trim(), txtactual42.Text.Trim(), txtactual43.Text.Trim(), txtactual44.Text.Trim(), txtactual45.Text.Trim(), txtactual46.Text.Trim(), txtactual47.Text.Trim(), txtactual48.Text.Trim(), txtactual49.Text.Trim(), txtactual50.Text.Trim(), "add");

                    dSets = objStorProc.rdf_sp_new_basemixed(0, txtproddate.Text.Trim(), txtFeedCode.Text.Trim(), txtFeedType.Text.Trim(), txtBags.Text.Trim(), txtmainfeedcode.Text.Trim(), label61.Text.Trim(), lblCounts.Text.Trim(), lblCountss.Text.Trim(), lblkg.Text.Trim(), lblrunningtotal.Text.Trim(), lbllost.Text.Trim(), txtdatenowstamp.Text.Trim(), txtactual1.Text.Trim(), txtactual2.Text.Trim(), txtactual3.Text.Trim(), txtactual4.Text.Trim(), txtactual5.Text.Trim(), txtactual6.Text.Trim(), txtactual7.Text.Trim(), txtactual8.Text.Trim(), txtactual9.Text.Trim(), txtactual10.Text.Trim(), txtactual11.Text.Trim(), txtactual12.Text.Trim(), txtactual13.Text.Trim(), txtactual14.Text.Trim(), txtactual15.Text.Trim(), txtactual16.Text.Trim(), txtactual17.Text.Trim(), txtactual18.Text.Trim(), txtactual19.Text.Trim(), txtactual20.Text.Trim(), txtactual21.Text.Trim(), txtactual22.Text.Trim(), txtactual23.Text.Trim(), txtactual24.Text.Trim(), txtactual25.Text.Trim(), txtactual26.Text.Trim(), txtactual27.Text.Trim(), txtactual28.Text.Trim(), txtactual29.Text.Trim(), txtactual30.Text.Trim(), txtactual31.Text.Trim(), txtactual32.Text.Trim(), txtactual33.Text.Trim(), txtactual34.Text.Trim(), txtactual35.Text.Trim(), txtactual36.Text.Trim(), txtactual37.Text.Trim(), txtactual38.Text.Trim(), txtactual39.Text.Trim(), txtactual40.Text.Trim(), txtactual41.Text.Trim(), txtactual42.Text.Trim(), txtactual43.Text.Trim(), txtactual44.Text.Trim(), txtactual45.Text.Trim(), txtactual46.Text.Trim(), txtactual47.Text.Trim(), txtactual48.Text.Trim(), txtactual49.Text.Trim(), txtactual50.Text.Trim(), lblpercentvar.Text.Trim(), "add");
                    //load_macro_count();
                    load_Schedules();
                    //showValueDailyProduction();
                    lblbatchcount.Text = "0";
                    checkEntry();
                    return false;
                }

                else
                {
                    dSet.Clear();
                    //dSets = objStorProc.rdf_sp_new_basemixed(0, txtproddate.Text.Trim(), txtFeedCode.Text.Trim(), txtFeedType.Text.Trim(), txtBags.Text.Trim(), txtmainfeedcode.Text.Trim(), label61.Text.Trim(), lblCounts.Text.Trim(), lblCountss.Text.Trim(), lblkg.Text.Trim(), lblrunningtotal.Text.Trim(), lbllost.Text.Trim(), "", txtactual1.Text.Trim(), txtactual2.Text.Trim(), txtactual3.Text.Trim(), txtactual4.Text.Trim(), txtactual5.Text.Trim(), txtactual6.Text.Trim(), txtactual7.Text.Trim(), txtactual8.Text.Trim(), txtactual9.Text.Trim(), txtactual10.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(),"", "add");
                    //dSets = objStorProc.rdf_sp_new_basemixed(0, txtproddate.Text.Trim(), txtFeedCode.Text.Trim(), txtFeedType.Text.Trim(), txtBags.Text.Trim(), txtmainfeedcode.Text.Trim(), label61.Text.Trim(), lblCounts.Text.Trim(), lblCountss.Text.Trim(), lblkg.Text.Trim(), lblrunningtotal.Text.Trim(), lbllost.Text.Trim(), "", txtactual1.Text.Trim(), txtactual2.Text.Trim(), txtactual3.Text.Trim(), txtactual4.Text.Trim(), txtactual5.Text.Trim(), txtactual6.Text.Trim(), txtactual7.Text.Trim(), txtactual8.Text.Trim(), txtactual9.Text.Trim(), txtactual10.Text.Trim(), txtactual11.Text.Trim(), txtactual12.Text.Trim(), txtactual13.Text.Trim(), txtactual14.Text.Trim(), txtactual15.Text.Trim(), txtactual16.Text.Trim(), txtactual17.Text.Trim(), txtactual18.Text.Trim(), txtactual19.Text.Trim(), txtactual20.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), txtactual1.Text.Trim(), "", "add");
                    dSets = objStorProc.rdf_sp_new_basemixed(0, txtproddate.Text.Trim(), txtFeedCode.Text.Trim(), txtFeedType.Text.Trim(), txtBags.Text.Trim(), txtmainfeedcode.Text.Trim(), label61.Text.Trim(), lblCounts.Text.Trim(), lblCountss.Text.Trim(), lblkg.Text.Trim(), lblrunningtotal.Text.Trim(), lbllost.Text.Trim(), txtdatenowstamp.Text.Trim(), txtactual1.Text.Trim(), txtactual2.Text.Trim(), txtactual3.Text.Trim(), txtactual4.Text.Trim(), txtactual5.Text.Trim(), txtactual6.Text.Trim(), txtactual7.Text.Trim(), txtactual8.Text.Trim(), txtactual9.Text.Trim(), txtactual10.Text.Trim(), txtactual11.Text.Trim(), txtactual12.Text.Trim(), txtactual13.Text.Trim(), txtactual14.Text.Trim(), txtactual15.Text.Trim(), txtactual16.Text.Trim(), txtactual17.Text.Trim(), txtactual18.Text.Trim(), txtactual19.Text.Trim(), txtactual20.Text.Trim(), txtactual21.Text.Trim(), txtactual22.Text.Trim(), txtactual23.Text.Trim(), txtactual24.Text.Trim(), txtactual25.Text.Trim(), txtactual26.Text.Trim(), txtactual27.Text.Trim(), txtactual28.Text.Trim(), txtactual29.Text.Trim(), txtactual30.Text.Trim(), txtactual31.Text.Trim(), txtactual32.Text.Trim(), txtactual33.Text.Trim(), txtactual34.Text.Trim(), txtactual35.Text.Trim(), txtactual36.Text.Trim(), txtactual37.Text.Trim(), txtactual38.Text.Trim(), txtactual39.Text.Trim(), txtactual40.Text.Trim(), txtactual41.Text.Trim(), txtactual42.Text.Trim(), txtactual43.Text.Trim(), txtactual44.Text.Trim(), txtactual45.Text.Trim(), txtactual46.Text.Trim(), txtactual47.Text.Trim(), txtactual48.Text.Trim(), txtactual49.Text.Trim(), txtactual50.Text.Trim(), lblpercentvar.Text.Trim(),  "add");
                    load_Schedules();
                    //showValueDailyProduction();
                    lblbatchcount.Text = "0";
                    checkEntry();
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
                        //txtMainInput.Focus();
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

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {

        }

        public void Timer()
        {

            if (lblbatchcount.Text == "0")
            {
                if (txtactual1.Text.Trim() == string.Empty)
                {
                    //this.BackColor = Color.CornflowerBlue; lako kepamu be
                    timer1.Enabled = true;
                    timer1.Start();
                    txtactual1.Select();
                    txtactual1.Focus();
                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
                else
                {


                    txtactual1.Text = "";

                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
            }
            else

            {
                MessageBox.Show("Timer IS Missing");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {



            if (lblbatchcount.Text == "0")
            {
                if (txtactual1.Text.Trim() == string.Empty)
                {
                    //this.BackColor = Color.CornflowerBlue; lako kepamu be
                    timer1.Enabled = true;
                    timer1.Start();
                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
                else
                {


                    txtactual1.Text = "";

                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
            }
            else if (lblbatchcount.Text == "1")
            {

                if (txtactual2.Text.Trim() == string.Empty)
                {
                    //this.BackColor = Color.CornflowerBlue; lako kepamu be
                    timer1.Enabled = true;
                    timer1.Start();
                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
                else
                {


                    txtactual2.Text = "";

                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
            }
            else if (lblbatchcount.Text == "2")
            {

                if (txtactual3.Text.Trim() == string.Empty)
                {
                    //this.BackColor = Color.CornflowerBlue; lako kepamu be
                    timer1.Enabled = true;
                    timer1.Start();
                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
                else
                {


                    txtactual3.Text = "";

                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
            }

            else if (lblbatchcount.Text == "3")
            {

                if (txtactual4.Text.Trim() == string.Empty)
                {
                    //this.BackColor = Color.CornflowerBlue; lako kepamu be
                    timer1.Enabled = true;
                    timer1.Start();
                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
                else
                {


                    txtactual4.Text = "";

                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
            }


            else if (lblbatchcount.Text == "4")
            {

                if (txtactual5.Text.Trim() == string.Empty)
                {
                    //this.BackColor = Color.CornflowerBlue; lako kepamu be
                    timer1.Enabled = true;
                    timer1.Start();
                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
                else
                {


                    txtactual5.Text = "";

                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
            }


            else if (lblbatchcount.Text == "5")
            {

                if (txtactual6.Text.Trim() == string.Empty)
                {
                    //this.BackColor = Color.CornflowerBlue; lako kepamu be
                    timer1.Enabled = true;
                    timer1.Start();
                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
                else
                {


                    txtactual6.Text = "";

                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
            }

            else if (lblbatchcount.Text == "6")
            {

                if (txtactual7.Text.Trim() == string.Empty)
                {
                    //this.BackColor = Color.CornflowerBlue; lako kepamu be
                    timer1.Enabled = true;
                    timer1.Start();
                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
                else
                {


                    txtactual7.Text = "";

                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
            }


            else if (lblbatchcount.Text == "7")
            {

                if (txtactual8.Text.Trim() == string.Empty)
                {
                    //this.BackColor = Color.CornflowerBlue; lako kepamu be
                    timer1.Enabled = true;
                    timer1.Start();
                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
                else
                {


                    txtactual8.Text = "";

                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
            }

            else if (lblbatchcount.Text == "8")
            {

                if (txtactual9.Text.Trim() == string.Empty)
                {
                    //this.BackColor = Color.CornflowerBlue; lako kepamu be
                    timer1.Enabled = true;
                    timer1.Start();
                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
                else
                {


                    txtactual9.Text = "";

                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
            }


            else if (lblbatchcount.Text == "9")
            {

                if (txtactual10.Text.Trim() == string.Empty)
                {
                    //this.BackColor = Color.CornflowerBlue; lako kepamu be
                    timer1.Enabled = true;
                    timer1.Start();
                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
                else
                {


                    txtactual10.Text = "";

                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
            }

            else if (lblbatchcount.Text == "10")
            {

                if (txtactual11.Text.Trim() == string.Empty)
                {
                    //this.BackColor = Color.CornflowerBlue; lako kepamu be
                    timer1.Enabled = true;
                    timer1.Start();
                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
                else
                {


                    txtactual11.Text = "";

                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
            }
            else if (lblbatchcount.Text == "11")
            {

                if (txtactual12.Text.Trim() == string.Empty)
                {
                    //this.BackColor = Color.CornflowerBlue; lako kepamu be
                    timer1.Enabled = true;
                    timer1.Start();
                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
                else
                {


                    txtactual12.Text = "";

                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
            }
            else if (lblbatchcount.Text == "12")
            {

                if (txtactual13.Text.Trim() == string.Empty)
                {
                    //this.BackColor = Color.CornflowerBlue; lako kepamu be
                    timer1.Enabled = true;
                    timer1.Start();
                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
                else
                {


                    txtactual13.Text = "";

                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
            }
            else if (lblbatchcount.Text == "13")
            {

                if (txtactual14.Text.Trim() == string.Empty)
                {
                    //this.BackColor = Color.CornflowerBlue; lako kepamu be
                    timer1.Enabled = true;
                    timer1.Start();
                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
                else
                {


                    txtactual14.Text = "";

                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
            }
            else if (lblbatchcount.Text == "14")
            {

                if (txtactual15.Text.Trim() == string.Empty)
                {
                    //this.BackColor = Color.CornflowerBlue; lako kepamu be
                    timer1.Enabled = true;
                    timer1.Start();
                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
                else
                {


                    txtactual15.Text = "";

                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
            }
            else if (lblbatchcount.Text == "15")
            {

                if (txtactual16.Text.Trim() == string.Empty)
                {
                    //this.BackColor = Color.CornflowerBlue; lako kepamu be
                    timer1.Enabled = true;
                    timer1.Start();
                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
                else
                {


                    txtactual16.Text = "";

                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
            }
            else if (lblbatchcount.Text == "16")
            {

                if (txtactual17.Text.Trim() == string.Empty)
                {
                    //this.BackColor = Color.CornflowerBlue; lako kepamu be
                    timer1.Enabled = true;
                    timer1.Start();
                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
                else
                {


                    txtactual17.Text = "";

                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
            }
            else if (lblbatchcount.Text == "17")
            {

                if (txtactual18.Text.Trim() == string.Empty)
                {
                    //this.BackColor = Color.CornflowerBlue; lako kepamu be
                    timer1.Enabled = true;
                    timer1.Start();
                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
                else
                {


                    txtactual18.Text = "";

                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
            }
            else if (lblbatchcount.Text == "18")
            {

                if (txtactual19.Text.Trim() == string.Empty)
                {
                    //this.BackColor = Color.CornflowerBlue; lako kepamu be
                    timer1.Enabled = true;
                    timer1.Start();
                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
                else
                {


                    txtactual19.Text = "";

                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
            }
            else if (lblbatchcount.Text == "19")
            {

                if (txtactual20.Text.Trim() == string.Empty)
                {
                    //this.BackColor = Color.CornflowerBlue; lako kepamu be
                    timer1.Enabled = true;
                    timer1.Start();
                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
                else
                {


                    txtactual20.Text = "";

                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
            }
            else if (lblbatchcount.Text == "20")
            {

                if (txtactual21.Text.Trim() == string.Empty)
                {
                    //this.BackColor = Color.CornflowerBlue; lako kepamu be
                    timer1.Enabled = true;
                    timer1.Start();
                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
                else
                {


                    txtactual21.Text = "";

                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
            }
            else if (lblbatchcount.Text == "21")
            {

                if (txtactual22.Text.Trim() == string.Empty)
                {
                    //this.BackColor = Color.CornflowerBlue; lako kepamu be
                    timer1.Enabled = true;
                    timer1.Start();
                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
                else
                {


                    txtactual22.Text = "";

                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
            }
            else if (lblbatchcount.Text == "22")
            {

                if (txtactual23.Text.Trim() == string.Empty)
                {
                    //this.BackColor = Color.CornflowerBlue; lako kepamu be
                    timer1.Enabled = true;
                    timer1.Start();
                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
                else
                {


                    txtactual23.Text = "";

                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
            }
            else if (lblbatchcount.Text == "23")
            {

                if (txtactual24.Text.Trim() == string.Empty)
                {
                    //this.BackColor = Color.CornflowerBlue; lako kepamu be
                    timer1.Enabled = true;
                    timer1.Start();
                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
                else
                {


                    txtactual24.Text = "";

                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
            }
            else if (lblbatchcount.Text == "24")
            {

                if (txtactual25.Text.Trim() == string.Empty)
                {
                    //this.BackColor = Color.CornflowerBlue; lako kepamu be
                    timer1.Enabled = true;
                    timer1.Start();
                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
                else
                {


                    txtactual25.Text = "";

                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
            }
            else if (lblbatchcount.Text == "25")
            {

                if (txtactual26.Text.Trim() == string.Empty)
                {
                    //this.BackColor = Color.CornflowerBlue; lako kepamu be
                    timer1.Enabled = true;
                    timer1.Start();
                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
                else
                {


                    txtactual26.Text = "";

                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
            }

            else if (lblbatchcount.Text == "26")
            {

                if (txtactual27.Text.Trim() == string.Empty)
                {
                    //this.BackColor = Color.CornflowerBlue; lako kepamu be
                    timer1.Enabled = true;
                    timer1.Start();
                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
                else
                {


                    txtactual27.Text = "";

                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
            }

            else if (lblbatchcount.Text == "27")
            {

                if (txtactual28.Text.Trim() == string.Empty)
                {
                    //this.BackColor = Color.CornflowerBlue; lako kepamu be
                    timer1.Enabled = true;
                    timer1.Start();
                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
                else
                {


                    txtactual28.Text = "";

                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
            }

            else if (lblbatchcount.Text == "28")
            {

                if (txtactual29.Text.Trim() == string.Empty)
                {
                    //this.BackColor = Color.CornflowerBlue; lako kepamu be
                    timer1.Enabled = true;
                    timer1.Start();
                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
                else
                {


                    txtactual29.Text = "";

                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
            }

            else if (lblbatchcount.Text == "29")
            {

                if (txtactual30.Text.Trim() == string.Empty)
                {
                    //this.BackColor = Color.CornflowerBlue; lako kepamu be
                    timer1.Enabled = true;
                    timer1.Start();
                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
                else
                {


                    txtactual30.Text = "";

                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
            }

            else if (lblbatchcount.Text == "30")
            {

                if (txtactual31.Text.Trim() == string.Empty)
                {
                    //this.BackColor = Color.CornflowerBlue; lako kepamu be
                    timer1.Enabled = true;
                    timer1.Start();
                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
                else
                {


                    txtactual31.Text = "";

                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
            }

            else if (lblbatchcount.Text == "31")
            {

                if (txtactual32.Text.Trim() == string.Empty)
                {
                    //this.BackColor = Color.CornflowerBlue; lako kepamu be
                    timer1.Enabled = true;
                    timer1.Start();
                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
                else
                {


                    txtactual32.Text = "";

                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
            }

            else if (lblbatchcount.Text == "32")
            {

                if (txtactual33.Text.Trim() == string.Empty)
                {
                    //this.BackColor = Color.CornflowerBlue; lako kepamu be
                    timer1.Enabled = true;
                    timer1.Start();
                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
                else
                {


                    txtactual33.Text = "";

                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
            }

            else if (lblbatchcount.Text == "33")
            {

                if (txtactual34.Text.Trim() == string.Empty)
                {
                    //this.BackColor = Color.CornflowerBlue; lako kepamu be
                    timer1.Enabled = true;
                    timer1.Start();
                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
                else
                {


                    txtactual34.Text = "";

                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
            }

            else if (lblbatchcount.Text == "34")
            {

                if (txtactual35.Text.Trim() == string.Empty)
                {
                    //this.BackColor = Color.CornflowerBlue; lako kepamu be
                    timer1.Enabled = true;
                    timer1.Start();
                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
                else
                {


                    txtactual35.Text = "";

                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
            }

            else if (lblbatchcount.Text == "35")
            {

                if (txtactual36.Text.Trim() == string.Empty)
                {
                    //this.BackColor = Color.CornflowerBlue; lako kepamu be
                    timer1.Enabled = true;
                    timer1.Start();
                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
                else
                {


                    txtactual36.Text = "";

                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
            }

            else if (lblbatchcount.Text == "36")
            {

                if (txtactual37.Text.Trim() == string.Empty)
                {
                    //this.BackColor = Color.CornflowerBlue; lako kepamu be
                    timer1.Enabled = true;
                    timer1.Start();
                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
                else
                {


                    txtactual37.Text = "";

                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
            }

            else if (lblbatchcount.Text == "37")
            {

                if (txtactual38.Text.Trim() == string.Empty)
                {
                    //this.BackColor = Color.CornflowerBlue; lako kepamu be
                    timer1.Enabled = true;
                    timer1.Start();
                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
                else
                {


                    txtactual38.Text = "";

                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
            }

            else if (lblbatchcount.Text == "38")
            {

                if (txtactual39.Text.Trim() == string.Empty)
                {
                    //this.BackColor = Color.CornflowerBlue; lako kepamu be
                    timer1.Enabled = true;
                    timer1.Start();
                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
                else
                {


                    txtactual39.Text = "";

                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
            }

            else if (lblbatchcount.Text == "39")
            {

                if (txtactual40.Text.Trim() == string.Empty)
                {
                    //this.BackColor = Color.CornflowerBlue; lako kepamu be
                    timer1.Enabled = true;
                    timer1.Start();
                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
                else
                {


                    txtactual40.Text = "";

                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
            }

            else if (lblbatchcount.Text == "40")
            {

                if (txtactual41.Text.Trim() == string.Empty)
                {
                    //this.BackColor = Color.CornflowerBlue; lako kepamu be
                    timer1.Enabled = true;
                    timer1.Start();
                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
                else
                {


                    txtactual41.Text = "";

                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
            }
            else if (lblbatchcount.Text == "41")
            {

                if (txtactual42.Text.Trim() == string.Empty)
                {
                    //this.BackColor = Color.CornflowerBlue; lako kepamu be
                    timer1.Enabled = true;
                    timer1.Start();
                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
                else
                {


                    txtactual42.Text = "";

                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
            }
            else if (lblbatchcount.Text == "42")
            {

                if (txtactual43.Text.Trim() == string.Empty)
                {
                    //this.BackColor = Color.CornflowerBlue; lako kepamu be
                    timer1.Enabled = true;
                    timer1.Start();
                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
                else
                {


                    txtactual43.Text = "";

                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
            }
            else if (lblbatchcount.Text == "43")
            {

                if (txtactual44.Text.Trim() == string.Empty)
                {
                    //this.BackColor = Color.CornflowerBlue; lako kepamu be
                    timer1.Enabled = true;
                    timer1.Start();
                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
                else
                {


                    txtactual44.Text = "";

                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
            }
            else if (lblbatchcount.Text == "44")
            {

                if (txtactual45.Text.Trim() == string.Empty)
                {
                    //this.BackColor = Color.CornflowerBlue; lako kepamu be
                    timer1.Enabled = true;
                    timer1.Start();
                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
                else
                {


                    txtactual45.Text = "";

                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
            }
            else if (lblbatchcount.Text == "45")
            {

                if (txtactual46.Text.Trim() == string.Empty)
                {
                    //this.BackColor = Color.CornflowerBlue; lako kepamu be
                    timer1.Enabled = true;
                    timer1.Start();
                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
                else
                {


                    txtactual46.Text = "";

                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
            }
            else if (lblbatchcount.Text == "46")
            {

                if (txtactual47.Text.Trim() == string.Empty)
                {
                    //this.BackColor = Color.CornflowerBlue; lako kepamu be
                    timer1.Enabled = true;
                    timer1.Start();
                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
                else
                {


                    txtactual47.Text = "";

                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
            }
            else if (lblbatchcount.Text == "47")
            {

                if (txtactual48.Text.Trim() == string.Empty)
                {
                    //this.BackColor = Color.CornflowerBlue; lako kepamu be
                    timer1.Enabled = true;
                    timer1.Start();
                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
                else
                {


                    txtactual48.Text = "";

                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
            }
            else if (lblbatchcount.Text == "48")
            {

                if (txtactual49.Text.Trim() == string.Empty)
                {
                    //this.BackColor = Color.CornflowerBlue; lako kepamu be
                    timer1.Enabled = true;
                    timer1.Start();
                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
                else
                {


                    txtactual49.Text = "";

                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
            }
            else if (lblbatchcount.Text == "49")
            {

                if (txtactual50.Text.Trim() == string.Empty)
                {
                    //this.BackColor = Color.CornflowerBlue; lako kepamu be
                    timer1.Enabled = true;
                    timer1.Start();
                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
                else
                {


                    txtactual50.Text = "";

                    SendKeys.SendWait("{F7}"); // How to press enter?

                }
            }

            else
            {
                MessageBox.Show("NULL");
            }





        }

        private void btn6_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (MetroFramework.MetroMessageBox.Show(this, $"Save the batch Entry   { lblbatchcount.Text}  Out of { label61.Text} batch", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                if (txtactual6.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtactual6.Focus();
                    txtactual6.Select();
                    txtactual6.BackColor = Color.Yellow;
                    return;
                }


                if (lblvalidate.Text.Trim() == label61.Text.Trim())
                {

                }
                else
                {

                    if (txtneeded.Text.Trim() == txtactual6.Text.Trim())
                    {

                    }
                    else
                    {
                        //gaspar
                        QuantityNotMatched();
                        txtactual6.Text = "";
                        txtactual6.Focus();
                        timer1.Start();

                        return;
                    }

                }




            }

            else

            {
                txtactual6.Text = "";
                timer1.Start();
                txtactual6.Focus();
                return;
            }


            double qty1;
            double actual1;

            qty1 = double.Parse(txtqty6.Text);
            actual1 = double.Parse(txtactual6.Text);

            if (qty1 < actual1)
            {

                OverQuantity();
                timer1.Start();
                    txtactual6.Text = "";
                txtactual6.Focus();
                return;
            }

            else
            {

                txtactual6.Enabled = false;
                txtactual7.Enabled = true;
                txtactual7.Focus();
            }





            lblrunningtotal.Text = (float.Parse(txtactual6.Text) + float.Parse(lblrunningtotal.Text)).ToString("#,0.00");

            lblactualweight.Text = (float.Parse(txtactual6.Text) * 1).ToString(); //lusaw
            btn6.Enabled = false;
            lblbatchcount.Text = "6";
            lbllost.Text = (float.Parse(lblrunningtotal.Text) - float.Parse(lblkg.Text)).ToString("#,0.00");
            DocheckingBatch();
            BtnSave.Enabled = true;
            BtnSave_Click(sender, e);




















        }

        private void txtactual4_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtactual4_Click(object sender, EventArgs e)
        {
            timer1_Tick(sender, e);
        }

        private void txtactual1_Click(object sender, EventArgs e)
        {
            timer1_Tick(sender, e);
        }

        private void txtactual2_Click(object sender, EventArgs e)
        {
            timer1_Tick(sender, e);
        }

        private void txtactual3_Click(object sender, EventArgs e)
        {
            timer1_Tick(sender, e);
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (MetroFramework.MetroMessageBox.Show(this, $"Save the batch Entry   { lblbatchcount.Text}  Out of { label61.Text} batch", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                if (txtactual7.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtactual7.Focus();
                    txtactual7.Select();
                    txtactual7.BackColor = Color.Yellow;
                    return;
                }

                if (lblvalidate.Text.Trim() == label61.Text.Trim())
                {

                }
                else
                {

                    if (txtneeded.Text.Trim() == txtactual7.Text.Trim())
                    {

                    }
                    else
                    {
                        //gaspar
                        QuantityNotMatched();
                        txtactual7.Text = "";
                        txtactual7.Focus();
                        timer1.Start();

                        return;
                    }

                }

            }





            else
            {
                txtactual7.Text = "";
                timer1.Start();
                txtactual7.Focus();
                return;
            }


            double qty1;
            double actual1;

            qty1 = double.Parse(txtqty7.Text);
            actual1 = double.Parse(txtactual7.Text);

            if (qty1 < actual1)
            {

                OverQuantity();
                
                txtactual7.Text = "";
                timer1.Start();
                txtactual7.Focus();
                return;
            }

            else
            {

                txtactual7.Enabled = false;
                txtactual8.Enabled = true;
                txtactual8.Focus();
            }





            lblrunningtotal.Text = (float.Parse(txtactual7.Text) + float.Parse(lblrunningtotal.Text)).ToString("#,0.00");

            lblactualweight.Text = (float.Parse(txtactual7.Text) * 1).ToString(); //lusaw
            btn7.Enabled = false;
            lblbatchcount.Text = "7";
            lbllost.Text = (float.Parse(lblrunningtotal.Text) - float.Parse(lblkg.Text)).ToString("#,0.00");
            DocheckingBatch();
            BtnSave.Enabled = true;
            BtnSave_Click(sender, e);






        }

        private void btn8_Click(object sender, EventArgs e)
        {
            timer1.Stop();


            if (MetroFramework.MetroMessageBox.Show(this, $"Save the batch Entry   { lblbatchcount.Text}  Out of { label61.Text} batch", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                if (txtactual8.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtactual8.Focus();
                    txtactual8.Select();
                    txtactual8.BackColor = Color.Yellow;
                    return;
                }

                if (lblvalidate.Text.Trim() == label61.Text.Trim())
                {

                }
                else
                {

                    if (txtneeded.Text.Trim() == txtactual8.Text.Trim())
                    {

                    }
                    else
                    {
                        //gaspar
                        QuantityNotMatched();
                        txtactual8.Text = "";
                        txtactual8.Focus();
                        timer1.Start();

                        return;
                    }

                }


            }




                else

                {
                txtactual8.Text = "";
                timer1.Start();
                txtactual8.Focus();
                return;
                }
       

            double qty1;
            double actual1;

            qty1 = double.Parse(txtqty8.Text);
            actual1 = double.Parse(txtactual8.Text);

            if (qty1 < actual1)
            {

                OverQuantity();
                txtactual8.Text = "";
                timer1.Start();
                txtactual8.Focus();
                return;
            }

            else
            {

                txtactual8.Enabled = false;
                txtactual9.Enabled = true;
                txtactual9.Focus();
            }





            lblrunningtotal.Text = (float.Parse(txtactual8.Text) + float.Parse(lblrunningtotal.Text)).ToString("#,0.00");

            lblactualweight.Text = (float.Parse(txtactual8.Text) * 1).ToString(); //lusaw
            btn6.Enabled = false;
            lblbatchcount.Text = "8";
            lbllost.Text = (float.Parse(lblrunningtotal.Text) - float.Parse(lblkg.Text)).ToString("#,0.00");
            DocheckingBatch();
            BtnSave.Enabled = true;
            BtnSave_Click(sender, e);






        }

        private void btn9_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (MetroFramework.MetroMessageBox.Show(this, $"Save the batch Entry   { lblbatchcount.Text}  Out of { label61.Text} batch", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (txtactual9.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtactual9.Focus();
                    txtactual9.Select();
                    txtactual9.BackColor = Color.Yellow;
                    return;
                }

                if (lblvalidate.Text.Trim() == label61.Text.Trim())
                {

                }
                else
                {

                    if (txtneeded.Text.Trim() == txtactual9.Text.Trim())
                    {

                    }
                    else
                    {
                        //gaspar
                        QuantityNotMatched();
                        txtactual9.Text = "";
                        txtactual9.Focus();
                        timer1.Start();

                        return;
                    }

                }
            }

            else

            {
                txtactual9.Text = "";
                timer1.Start();
                txtactual9.Focus();
                return;
            }


            double qty1;
            double actual1;

            qty1 = double.Parse(txtqty9.Text);
            actual1 = double.Parse(txtactual9.Text);

            if (qty1 < actual1)
            {

                OverQuantity();

                txtactual9.Text = "";
                timer1.Start();
                txtactual9.Focus();
                return;
            }

            else
            {

                txtactual9.Enabled = false;
                txtactual10.Enabled = true;
                txtactual10.Focus();
            }





            lblrunningtotal.Text = (float.Parse(txtactual9.Text) + float.Parse(lblrunningtotal.Text)).ToString("#,0.00");

            lblactualweight.Text = (float.Parse(txtactual9.Text) * 1).ToString(); //lusaw
            btn6.Enabled = false;
            lblbatchcount.Text = "9";
            lbllost.Text = (float.Parse(lblrunningtotal.Text) - float.Parse(lblkg.Text)).ToString("#,0.00");
            DocheckingBatch();
            BtnSave.Enabled = true;
            BtnSave_Click(sender, e);






        }

        private void btn10_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (MetroFramework.MetroMessageBox.Show(this, $"Save the batch Entry   { lblbatchcount.Text}  Out of { label61.Text} batch", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (txtactual10.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtactual10.Focus();
                    txtactual10.Select();
                    txtactual10.BackColor = Color.Yellow;
                    return;
                }

                if (lblvalidate.Text.Trim() == label61.Text.Trim())
                {

                }
                else
                {

                    if (txtneeded.Text.Trim() == txtactual10.Text.Trim())
                    {

                    }
                    else
                    {
                        //gaspar
                        QuantityNotMatched();
                        txtactual10.Text = "";
                        txtactual10.Focus();
                        timer1.Start();

                        return;
                    }

                }


            }

            else

            {
                txtactual10.Text = "";
                timer1.Start();
                txtactual10.Focus();
                return;
            }


            double qty1;
            double actual1;

            qty1 = double.Parse(txtqty10.Text);
            actual1 = double.Parse(txtactual10.Text);

            if (qty1 < actual1)
            {

                OverQuantity();
                txtactual10.Text = "";
                timer1.Start();
                txtactual10.Focus();
                return;
            }

            else
            {

                txtactual10.Enabled = false;
                txtactual11.Enabled = true;
                txtactual11.Focus();
            }





            lblrunningtotal.Text = (float.Parse(txtactual10.Text) + float.Parse(lblrunningtotal.Text)).ToString("#,0.00");

            lblactualweight.Text = (float.Parse(txtactual10.Text) * 1).ToString(); //lusaw
            btn6.Enabled = false;
            lblbatchcount.Text = "10";
            lbllost.Text = (float.Parse(lblrunningtotal.Text) - float.Parse(lblkg.Text)).ToString("#,0.00");
            DocheckingBatch();
            BtnSave.Enabled = true;
            BtnSave_Click(sender, e);






        }

        private void txtactual6_Click(object sender, EventArgs e)
        {
            timer1_Tick(sender, e);
        }

        private void txtactual7_Click(object sender, EventArgs e)
        {
            timer1_Tick(sender, e);
        }

        private void txtactual8_Click(object sender, EventArgs e)
        {
            timer1_Tick(sender, e);
        }

        private void txtactual9_Click(object sender, EventArgs e)
        {
            timer1_Tick(sender, e);
        }

        private void btn11_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (MetroFramework.MetroMessageBox.Show(this, $"Save the batch Entry   { lblbatchcount.Text}  Out of { label61.Text} batch", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (txtactual11.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtactual11.Focus();
                    txtactual11.Select();
                    txtactual11.BackColor = Color.Yellow;
                    return;
                }

                if (lblvalidate.Text.Trim() == label61.Text.Trim())
                {

                }
                else
                {

                    if (txtneeded.Text.Trim() == txtactual11.Text.Trim())
                    {

                    }
                    else
                    {
                        //gaspar
                        QuantityNotMatched();
                        txtactual11.Text = "";
                        txtactual11.Focus();
                        timer1.Start();

                        return;
                    }

                }
            }

            else

            {
                txtactual11.Text = "";
                timer1.Start();
                txtactual11.Focus();
                return;
            }
            timer1.Stop();

            double qty1;
            double actual1;

            qty1 = double.Parse(txtqty11.Text);
            actual1 = double.Parse(txtactual11.Text);

            if (qty1 < actual1)
            {

                OverQuantity();
                txtactual11.Text = "";
                timer1.Start();
                txtactual11.Focus();
                return;
            }

            else
            {

                txtactual11.Enabled = false;
                txtactual12.Enabled = true;

                txtactual12.Focus();
            }





            lblrunningtotal.Text = (float.Parse(txtactual11.Text) + float.Parse(lblrunningtotal.Text)).ToString("#,0.00");

            lblactualweight.Text = (float.Parse(txtactual11.Text) * 1).ToString(); //lusaw
            btn6.Enabled = false;
            lblbatchcount.Text = "11";
            lbllost.Text = (float.Parse(lblrunningtotal.Text) - float.Parse(lblkg.Text)).ToString("#,0.00");
            DocheckingBatch();
            BtnSave.Enabled = true;
            BtnSave_Click(sender, e);



        }

        private void btn12_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            if (MetroFramework.MetroMessageBox.Show(this, $"Save the batch Entry   { lblbatchcount.Text}  Out of { label61.Text} batch", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (txtactual12.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtactual12.Focus();
                    txtactual12.Select();
                    txtactual12.BackColor = Color.Yellow;
                    return;
                }

                if (lblvalidate.Text.Trim() == label61.Text.Trim())
                {

                }
                else
                {

                    if (txtneeded.Text.Trim() == txtactual12.Text.Trim())
                    {

                    }
                    else
                    {
                        //gaspar
                        QuantityNotMatched();
                        txtactual12.Text = "";
                        txtactual12.Focus();
                        timer1.Start();

                        return;
                    }

                }
            }

            else

            {
                txtactual12.Text = "";
                timer1.Start();

                txtactual12.Focus();
                return;
            }
        

            double qty1;
            double actual1;

            qty1 = double.Parse(txtqty12.Text);
            actual1 = double.Parse(txtactual12.Text);

            if (qty1 < actual1)
            {

                OverQuantity();
                txtactual12.Text = "";
                timer1.Start();
                txtactual12.Focus();
                return;
            }

            else
            {

                txtactual12.Enabled = false;
                txtactual13.Enabled = true;

                txtactual13.Focus();
            }





            lblrunningtotal.Text = (float.Parse(txtactual12.Text) + float.Parse(lblrunningtotal.Text)).ToString("#,0.00");

            lblactualweight.Text = (float.Parse(txtactual12.Text) * 1).ToString(); //lusaw
            btn6.Enabled = false;
            lblbatchcount.Text = "12";
            lbllost.Text = (float.Parse(lblrunningtotal.Text) - float.Parse(lblkg.Text)).ToString("#,0.00");
            DocheckingBatch();
            BtnSave.Enabled = true;
            BtnSave_Click(sender, e);

        }

        private void btn13_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            if (MetroFramework.MetroMessageBox.Show(this, $"Save the batch Entry   { lblbatchcount.Text}  Out of { label61.Text} batch", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (txtactual13.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtactual13.Focus();
                    txtactual13.Select();
                    txtactual13.BackColor = Color.Yellow;
                    return;
                }

                if (lblvalidate.Text.Trim() == label61.Text.Trim())
                {

                }
                else
                {

                    if (txtneeded.Text.Trim() == txtactual13.Text.Trim())
                    {

                    }
                    else
                    {
                        //gaspar
                        QuantityNotMatched();
                        txtactual13.Text = "";
                        txtactual13.Focus();
                        timer1.Start();

                        return;
                    }

                }

            }

            else

            {
                txtactual13.Text = "";
                timer1.Start();
                txtactual13.Focus();
                return;
            }
      

            double qty1;
            double actual1;

            qty1 = double.Parse(txtqty13.Text);
            actual1 = double.Parse(txtactual13.Text);

            if (qty1 < actual1)
            {

                OverQuantity();
                txtactual13.Text = "";
                timer1.Start();
                txtactual13.Focus();
                return;
            }

            else
            {

                txtactual13.Enabled = false;
                txtactual14.Enabled = true;

                txtactual14.Focus();
            }





            lblrunningtotal.Text = (float.Parse(txtactual13.Text) + float.Parse(lblrunningtotal.Text)).ToString("#,0.00");

            lblactualweight.Text = (float.Parse(txtactual13.Text) * 1).ToString(); //lusaw
            btn6.Enabled = false;
            lblbatchcount.Text = "13";
            lbllost.Text = (float.Parse(lblrunningtotal.Text) - float.Parse(lblkg.Text)).ToString("#,0.00");

            DocheckingBatch();
            BtnSave.Enabled = true;
            BtnSave_Click(sender, e);

        }

        private void btn14_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            if (MetroFramework.MetroMessageBox.Show(this, $"Save the batch Entry   { lblbatchcount.Text}  Out of { label61.Text} batch", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                if (txtactual14.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtactual14.Focus();
                    txtactual14.Select();
                    txtactual14.BackColor = Color.Yellow;
                    return;
                }
                if (lblvalidate.Text.Trim() == label61.Text.Trim())
                {

                }
                else
                {

                    if (txtneeded.Text.Trim() == txtactual14.Text.Trim())
                    {

                    }
                    else
                    {
                        //gaspar
                        QuantityNotMatched();
                        txtactual14.Text = "";
                        txtactual14.Focus();
                        timer1.Start();

                        return;
                    }

                }

            }

            else

            {
                txtactual14.Text = "";
                timer1.Start();
                txtactual14.Focus();
                return;
            }

     

            double qty1;
            double actual1;

            qty1 = double.Parse(txtqty14.Text);
            actual1 = double.Parse(txtactual14.Text);

            if (qty1 < actual1)
            {

                OverQuantity();
                txtactual14.Text = "";
                timer1.Start();
                txtactual14.Focus();
                return;
            }

            else
            {

                txtactual14.Enabled = false;
                txtactual15.Enabled = true;

                txtactual15.Focus();
            }





            lblrunningtotal.Text = (float.Parse(txtactual14.Text) + float.Parse(lblrunningtotal.Text)).ToString("#,0.00");

            lblactualweight.Text = (float.Parse(txtactual14.Text) * 1).ToString(); //lusaw
            btn6.Enabled = false;
            lblbatchcount.Text = "14";
            lbllost.Text = (float.Parse(lblrunningtotal.Text) - float.Parse(lblkg.Text)).ToString("#,0.00");
            DocheckingBatch();
            BtnSave.Enabled = true;
            BtnSave_Click(sender, e);
        }

        private void btn15_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            if (MetroFramework.MetroMessageBox.Show(this, $"Save the batch Entry   { lblbatchcount.Text}  Out of { label61.Text} batch", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (txtactual15.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtactual15.Focus();
                    txtactual15.Select();
                    txtactual15.BackColor = Color.Yellow;
                    return;
                }


                if (lblvalidate.Text.Trim() == label61.Text.Trim())
                {

                }
                else
                {

                    if (txtneeded.Text.Trim() == txtactual15.Text.Trim())
                    {

                    }
                    else
                    {
                        //gaspar
                        QuantityNotMatched();
                        txtactual15.Text = "";
                        txtactual15.Focus();
                        timer1.Start();

                        return;
                    }

                }
            }

            else

            {
                txtactual15.Text = "";
                timer1.Start();
                txtactual15.Focus();
                return;
            }
  
            double qty1;
            double actual1;

            qty1 = double.Parse(txtqty15.Text);
            actual1 = double.Parse(txtactual15.Text);

            if (qty1 < actual1)
            {

                OverQuantity();
                txtactual15.Text = "";
                timer1.Start();
                txtactual15.Focus();
                return;
            }

            else
            {

                txtactual15.Enabled = false;
                txtactual16.Enabled = true;

                txtactual16.Focus();
            }





            lblrunningtotal.Text = (float.Parse(txtactual15.Text) + float.Parse(lblrunningtotal.Text)).ToString("#,0.00");

            lblactualweight.Text = (float.Parse(txtactual15.Text) * 1).ToString(); //lusaw
            btn6.Enabled = false;
            lblbatchcount.Text = "15";
            lbllost.Text = (float.Parse(lblrunningtotal.Text) - float.Parse(lblkg.Text)).ToString("#,0.00");
            DocheckingBatch();
            BtnSave.Enabled = true;
            BtnSave_Click(sender, e);
        }

        private void btn16_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (MetroFramework.MetroMessageBox.Show(this, $"Save the batch Entry   { lblbatchcount.Text}  Out of { label61.Text} batch", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (txtactual16.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtactual16.Focus();
                    txtactual16.Select();
                    txtactual16.BackColor = Color.Yellow;
                    return;
                }

                if (lblvalidate.Text.Trim() == label61.Text.Trim())
                {

                }
                else
                {

                    if (txtneeded.Text.Trim() == txtactual16.Text.Trim())
                    {

                    }
                    else
                    {
                        //gaspar
                        QuantityNotMatched();
                        txtactual16.Text = "";
                        txtactual16.Focus();
                        timer1.Start();

                        return;
                    }

                }
            }

            else

            {
                txtactual16.Text = "";
                timer1.Start();
                txtactual16.Focus();
                return;
            }
            timer1.Stop();

            double qty1;
            double actual1;

            qty1 = double.Parse(txtqty16.Text);
            actual1 = double.Parse(txtactual16.Text);

            if (qty1 < actual1)
            {

                OverQuantity();
                txtactual16.Text = "";
                timer1.Start();
                txtactual16.Focus();
                return;
            }

            else
            {

                txtactual16.Enabled = false;
                txtactual17.Enabled = true;

                txtactual17.Focus();
            }





            lblrunningtotal.Text = (float.Parse(txtactual16.Text) + float.Parse(lblrunningtotal.Text)).ToString("#,0.00");

            lblactualweight.Text = (float.Parse(txtactual16.Text) * 1).ToString(); //lusaw
            btn6.Enabled = false;
            lblbatchcount.Text = "16";
            lbllost.Text = (float.Parse(lblrunningtotal.Text) - float.Parse(lblkg.Text)).ToString("#,0.00");
            DocheckingBatch();
            BtnSave.Enabled = true;
            BtnSave_Click(sender, e);
        }

        private void btn17_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (MetroFramework.MetroMessageBox.Show(this, $"Save the batch Entry   { lblbatchcount.Text}  Out of { label61.Text} batch", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (txtactual17.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtactual17.Focus();
                    txtactual17.Select();
                    txtactual17.BackColor = Color.Yellow;
                    return;
                }

                if (lblvalidate.Text.Trim() == label61.Text.Trim())
                {

                }
                else
                {

                    if (txtneeded.Text.Trim() == txtactual17.Text.Trim())
                    {

                    }
                    else
                    {
                        //gaspar
                        QuantityNotMatched();
                        txtactual17.Text = "";
                        txtactual17.Focus();
                        timer1.Start();

                        return;
                    }

                }

            }

            else

            {
                txtactual17.Text = "";
                timer1.Start();
                txtactual17.Focus();
                return;
            }
            timer1.Stop();

            double qty1;
            double actual1;

            qty1 = double.Parse(txtqty17.Text);
            actual1 = double.Parse(txtactual17.Text);

            if (qty1 < actual1)
            {

                OverQuantity();
                txtactual17.Text = "";
                timer1.Start();
                txtactual17.Focus();
                return;
            }

            else
            {

                txtactual17.Enabled = false;
                txtactual18.Enabled = true;

                txtactual18.Focus();
            }





            lblrunningtotal.Text = (float.Parse(txtactual17.Text) + float.Parse(lblrunningtotal.Text)).ToString("#,0.00");

            lblactualweight.Text = (float.Parse(txtactual17.Text) * 1).ToString(); //lusaw
            btn6.Enabled = false;
            lblbatchcount.Text = "17";
            lbllost.Text = (float.Parse(lblrunningtotal.Text) - float.Parse(lblkg.Text)).ToString("#,0.00");
            DocheckingBatch();
            BtnSave.Enabled = true;
            BtnSave_Click(sender, e);
        }

        private void btn18_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (MetroFramework.MetroMessageBox.Show(this, $"Save the batch Entry  { lblbatchcount.Text}  Out of { label61.Text} batch", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (txtactual18.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtactual18.Focus();
                    txtactual18.Select();
                    txtactual18.BackColor = Color.Yellow;
                    return;
                }
                if (lblvalidate.Text.Trim() == label61.Text.Trim())
                {

                }
                else
                {

                    if (txtneeded.Text.Trim() == txtactual18.Text.Trim())
                    {

                    }
                    else
                    {
                        //gaspar
                        QuantityNotMatched();
                        txtactual18.Text = "";
                        txtactual18.Focus();
                        timer1.Start();

                        return;
                    }

                }
            }

            else

            {
                txtactual18.Text = "";
                timer1.Start();
                txtactual18.Focus();
                return;
            }
            timer1.Stop();

            double qty1;
            double actual1;

            qty1 = double.Parse(txtqty18.Text);
            actual1 = double.Parse(txtactual18.Text);

            if (qty1 < actual1)
            {

                OverQuantity();

                txtactual18.Text = "";
                timer1.Start();
                txtactual18.Focus();
                return;
            }

            else
            {

                txtactual18.Enabled = false;
                txtactual19.Enabled = true;

                txtactual19.Focus();
            }





            lblrunningtotal.Text = (float.Parse(txtactual18.Text) + float.Parse(lblrunningtotal.Text)).ToString("#,0.00");

            lblactualweight.Text = (float.Parse(txtactual18.Text) * 1).ToString(); //lusaw
            btn6.Enabled = false;
            lblbatchcount.Text = "18";
            lbllost.Text = (float.Parse(lblrunningtotal.Text) - float.Parse(lblkg.Text)).ToString("#,0.00");
            DocheckingBatch();
            BtnSave.Enabled = true;
            BtnSave_Click(sender, e);
        }

        private void btn19_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (MetroFramework.MetroMessageBox.Show(this, $"Save the batch Entry   { lblbatchcount.Text}  Out of { label61.Text} batch", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (txtactual19.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtactual19.Focus();
                    txtactual19.Select();
                    txtactual19.BackColor = Color.Yellow;
                    return;
                }

                if (lblvalidate.Text.Trim() == label61.Text.Trim())
                {

                }
                else
                {

                    if (txtneeded.Text.Trim() == txtactual19.Text.Trim())
                    {

                    }
                    else
                    {
                        //gaspar
                        QuantityNotMatched();
                        txtactual19.Text = "";
                        txtactual19.Focus();
                        timer1.Start();

                        return;
                    }

                }
            }

            else

            {
                txtactual19.Text = "";
                timer1.Start();
                txtactual19.Focus();
                return;
            }
            timer1.Stop();

            double qty1;
            double actual1;

            qty1 = double.Parse(txtqty19.Text);
            actual1 = double.Parse(txtactual19.Text);

            if (qty1 < actual1)
            {

                OverQuantity();
                txtactual19.Text = "";
                timer1.Start();
                txtactual19.Focus();
                return;
            }

            else
            {

                txtactual19.Enabled = false;
                txtactual20.Enabled = true;

                txtactual20.Focus();
            }





            lblrunningtotal.Text = (float.Parse(txtactual19.Text) + float.Parse(lblrunningtotal.Text)).ToString("#,0.00");

            lblactualweight.Text = (float.Parse(txtactual19.Text) * 1).ToString(); //lusaw
            btn6.Enabled = false;
            lblbatchcount.Text = "19";
            lbllost.Text = (float.Parse(lblrunningtotal.Text) - float.Parse(lblkg.Text)).ToString("#,0.00");
            DocheckingBatch();
            BtnSave.Enabled = true;
            BtnSave_Click(sender, e);
        }

        private void btn20_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (MetroFramework.MetroMessageBox.Show(this, $"Save the batch Entrry   { lblbatchcount.Text}  Out of { label61.Text} batch", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                if (txtactual20.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtactual20.Focus();
                    txtactual20.Select();
                    txtactual20.BackColor = Color.Yellow;
                    return;
                }
                if (lblvalidate.Text.Trim() == label61.Text.Trim())
                {

                }
                else
                {

                    if (txtneeded.Text.Trim() == txtactual20.Text.Trim())
                    {

                    }
                    else
                    {
                        //gaspar
                        QuantityNotMatched();
                        txtactual20.Text = "";
                        txtactual20.Focus();
                        timer1.Start();

                        return;
                    }

                }
            }

            else

            {
                txtactual20.Text = "";
                timer1.Start();
                txtactual20.Focus();
                return;
            }
            timer1.Stop();

            double qty1;
            double actual1;

            qty1 = double.Parse(txtqty20.Text);
            actual1 = double.Parse(txtactual20.Text);

            if (qty1 < actual1)
            {

                OverQuantity();
                txtactual20.Text = "";
                timer1.Start();
                txtactual20.Focus();
                return;
            }

            else
            {

                txtactual20.Enabled = false;
                txtactual21.Enabled = true;

                txtactual21.Focus();
            }





            lblrunningtotal.Text = (float.Parse(txtactual20.Text) + float.Parse(lblrunningtotal.Text)).ToString("#,0.00");

            lblactualweight.Text = (float.Parse(txtactual20.Text) * 1).ToString(); //lusaw
            btn6.Enabled = false;
            lblbatchcount.Text = "20";
            lbllost.Text = (float.Parse(lblrunningtotal.Text) - float.Parse(lblkg.Text)).ToString("#,0.00");
            DocheckingBatch();
            BtnSave.Enabled = true;
            BtnSave_Click(sender, e);
        }

        private void txtactual10_Click(object sender, EventArgs e)
        {
            timer1_Tick(sender, e);
        }

        private void txtactual11_Click(object sender, EventArgs e)
        {
            timer1_Tick(sender, e);
        }

        private void txtactual12_Click(object sender, EventArgs e)
        {
            timer1_Tick(sender, e);
        }

        private void txtactual13_Click(object sender, EventArgs e)
        {
            timer1_Tick(sender, e);
        }

        private void txtactual14_Click(object sender, EventArgs e)
        {
            timer1_Tick(sender, e);
        }

        private void txtactual15_Click(object sender, EventArgs e)
        {
            timer1_Tick(sender, e);
        }

        private void txtactual16_Click(object sender, EventArgs e)
        {
            timer1_Tick(sender, e);
        }

        private void txtactual17_Click(object sender, EventArgs e)
        {
            timer1_Tick(sender, e);
        }

        private void txtactual18_Click(object sender, EventArgs e)
        {
            timer1_Tick(sender, e);
        }

        private void txtactual19_Click(object sender, EventArgs e)
        {
            timer1_Tick(sender, e);
        }

        private void txtactual20_Click(object sender, EventArgs e)
        {
            timer1_Tick(sender, e);
        }

        private void btn21_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (MetroFramework.MetroMessageBox.Show(this, $"Save the batch Entry  { lblbatchcount.Text}  Out of { label61.Text} batch", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (txtactual21.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtactual21.Focus();
                    txtactual21.Select();
                    txtactual21.BackColor = Color.Yellow;
                    return;
                }
                if (lblvalidate.Text.Trim() == label61.Text.Trim())
                {

                }
                else
                {

                    if (txtneeded.Text.Trim() == txtactual21.Text.Trim())
                    {

                    }
                    else
                    {
                        //gaspar
                        QuantityNotMatched();
                        txtactual21.Text = "";
                        txtactual21.Focus();
                        timer1.Start();

                        return;
                    }

                }
            }

            else

            {
                txtactual21.Text = "";
                timer1.Start();
                txtactual21.Focus();
                return;
            }
  

            double qty1;
            double actual1;

            qty1 = double.Parse(txtqty21.Text);
            actual1 = double.Parse(txtactual21.Text);

            if (qty1 < actual1)
            {
                OverQuantity();
                txtactual21.Text = "";
                timer1.Start();
                txtactual21.Focus();

                return;
            }

            else
            {

                txtactual21.Enabled = false;
                txtactual22.Enabled = true;

                txtactual22.Focus();
            }





            lblrunningtotal.Text = (float.Parse(txtactual21.Text) + float.Parse(lblrunningtotal.Text)).ToString("#,0.00");

            lblactualweight.Text = (float.Parse(txtactual21.Text) * 1).ToString(); //lusaw
            btn6.Enabled = false;
            lblbatchcount.Text = "21";
            lbllost.Text = (float.Parse(lblrunningtotal.Text) - float.Parse(lblkg.Text)).ToString("#,0.00");
            DocheckingBatch();
            BtnSave.Enabled = true;
            BtnSave_Click(sender, e);
        }

        private void btn22_Click(object sender, EventArgs e)
        {
            timer1.Stop();
                if (MetroFramework.MetroMessageBox.Show(this, $"Save the batch Entry   { lblbatchcount.Text}  Out of { label61.Text} batch", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {

                if (txtactual22.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtactual22.Focus();
                    txtactual22.Select();
                    txtactual22.BackColor = Color.Yellow;
                    return;
                }

                if (lblvalidate.Text.Trim() == label61.Text.Trim())
                {

                }
                else
                {

                    if (txtneeded.Text.Trim() == txtactual22.Text.Trim())
                    {

                    }
                    else
                    {
                        //gaspar
                        QuantityNotMatched();
                        txtactual22.Text = "";
                        txtactual22.Focus();
                        timer1.Start();

                        return;
                    }

                }


            }

                else

                {
                txtactual22.Text = "";
                timer1.Start();
                txtactual22.Focus();
                return;
                }
                timer1.Stop();

            double qty1;
            double actual1;

            qty1 = double.Parse(txtqty22.Text);
            actual1 = double.Parse(txtactual22.Text);

            if (qty1 < actual1)
            {

                OverQuantity();
                txtactual22.Text = "";
                timer1.Start();
                txtactual22.Focus();
                return;
            }

            else
            {

                txtactual22.Enabled = false;
                txtactual23.Enabled = true;

                txtactual23.Focus();
            }





            lblrunningtotal.Text = (float.Parse(txtactual22.Text) + float.Parse(lblrunningtotal.Text)).ToString("#,0.00");

            lblactualweight.Text = (float.Parse(txtactual22.Text) * 1).ToString(); //lusaw
            btn6.Enabled = false;
            lblbatchcount.Text = "22";
            lbllost.Text = (float.Parse(lblrunningtotal.Text) - float.Parse(lblkg.Text)).ToString("#,0.00");
            DocheckingBatch();
            BtnSave.Enabled = true;
            BtnSave_Click(sender, e);
        }

        private void btn23_Click(object sender, EventArgs e)
        {
            timer1.Stop();
                if (MetroFramework.MetroMessageBox.Show(this, $"Save the batch Entry   { lblbatchcount.Text}  Out of { label61.Text} batch", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                if (txtactual23.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtactual23.Focus();
                    txtactual23.Select();
                    txtactual23.BackColor = Color.Yellow;
                    return;
                }



                if (lblvalidate.Text.Trim() == label61.Text.Trim())
                {

                }
                else
                {

                    if (txtneeded.Text.Trim() == txtactual23.Text.Trim())
                    {

                    }
                    else
                    {
                        //gaspar
                        QuantityNotMatched();
                        txtactual23.Text = "";
                        txtactual23.Focus();
                        timer1.Start();

                        return;
                    }

                }



            }

            else

                {
                txtactual23.Text = "";
                timer1.Start();
                txtactual23.Focus();
                return;
                }
                timer1.Stop();

            double qty1;
            double actual1;

            qty1 = double.Parse(txtqty23.Text);
            actual1 = double.Parse(txtactual23.Text);

            if (qty1 < actual1)
            {

                OverQuantity();
                txtactual23.Text = "";
                timer1.Start();
                txtactual23.Focus();

                return;
            }

            else
            {

                txtactual23.Enabled = false;
                txtactual24.Enabled = true;

                txtactual24.Focus();
            }





            lblrunningtotal.Text = (float.Parse(txtactual23.Text) + float.Parse(lblrunningtotal.Text)).ToString("#,0.00");

            lblactualweight.Text = (float.Parse(txtactual23.Text) * 1).ToString(); //lusaw
            btn6.Enabled = false;
            lblbatchcount.Text = "23";
            lbllost.Text = (float.Parse(lblrunningtotal.Text) - float.Parse(lblkg.Text)).ToString("#,0.00");
            DocheckingBatch();
            BtnSave.Enabled = true;
            BtnSave_Click(sender, e);
        }

        private void btn24_Click(object sender, EventArgs e)
        {
            timer1.Stop();
                if (MetroFramework.MetroMessageBox.Show(this, $"Save the batch Entry   { lblbatchcount.Text}  Out of { label61.Text} batch", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                if (txtactual24.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtactual24.Focus();
                    txtactual24.Select();
                    txtactual24.BackColor = Color.Yellow;
                    return;
                }


                if (lblvalidate.Text.Trim() == label61.Text.Trim())
                {

                }
                else
                {

                    if (txtneeded.Text.Trim() == txtactual24.Text.Trim())
                    {

                    }
                    else
                    {
                        //gaspar
                        QuantityNotMatched();
                        txtactual24.Text = "";
                        txtactual24.Focus();
                        timer1.Start();

                        return;
                    }

                }
            }

                else

                {
                txtactual24.Text = "";
                timer1.Start();
                txtactual24.Focus();
                return;
                }
 

            double qty1;
            double actual1;

            qty1 = double.Parse(txtqty24.Text);
            actual1 = double.Parse(txtactual24.Text);

            if (qty1 < actual1)
            {
                OverQuantity();

                txtactual24.Text = "";
                timer1.Start();
                txtactual24.Focus();
                return;
            }

            else
            {

                txtactual24.Enabled = false;
                txtactual25.Enabled = true;

                txtactual25.Focus();
            }





            lblrunningtotal.Text = (float.Parse(txtactual24.Text) + float.Parse(lblrunningtotal.Text)).ToString("#,0.00");

            lblactualweight.Text = (float.Parse(txtactual24.Text) * 1).ToString(); //lusaw
            btn6.Enabled = false;
            lblbatchcount.Text = "24";
            lbllost.Text = (float.Parse(lblrunningtotal.Text) - float.Parse(lblkg.Text)).ToString("#,0.00");
            DocheckingBatch();
            BtnSave.Enabled = true;
            BtnSave_Click(sender, e);
        }

        private void btn25_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            if (MetroFramework.MetroMessageBox.Show(this, $"Save the batch Entry   { lblbatchcount.Text}  Out of { label61.Text} batch", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {


                if (txtactual25.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtactual25.Focus();
                    txtactual25.Select();
                    txtactual25.BackColor = Color.Yellow;
                    return;
                }

                if (lblvalidate.Text.Trim() == label61.Text.Trim())
                {

                }
                else
                {

                    if (txtneeded.Text.Trim() == txtactual25.Text.Trim())
                    {

                    }
                    else
                    {
                        //gaspar
                        QuantityNotMatched();
                        txtactual25.Text = "";
                        txtactual25.Focus();
                        timer1.Start();

                        return;
                    }

                }
            }

                else

                {
                txtactual25.Text = "";
                timer1.Start();
                txtactual25.Focus();
                return;
                }
        

            double qty1;
            double actual1;

            qty1 = double.Parse(txtqty25.Text);
            actual1 = double.Parse(txtactual25.Text);

            if (qty1 < actual1)
            {

                OverQuantity();

                txtactual25.Text = "";
                timer1.Start();
                txtactual25.Focus();
                return;
            }

            else
            {

                txtactual25.Enabled = false;
                txtactual26.Enabled = true;

                txtactual26.Focus();
            }





            lblrunningtotal.Text = (float.Parse(txtactual25.Text) + float.Parse(lblrunningtotal.Text)).ToString("#,0.00");

            lblactualweight.Text = (float.Parse(txtactual25.Text) * 1).ToString(); //lusaw
            btn6.Enabled = false;
            lblbatchcount.Text = "25";
            lbllost.Text = (float.Parse(lblrunningtotal.Text) - float.Parse(lblkg.Text)).ToString("#,0.00");
            DocheckingBatch();
            BtnSave.Enabled = true;
            BtnSave_Click(sender, e);
        }

        private void btn26_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (MetroFramework.MetroMessageBox.Show(this, $"Save the batch Entry   { lblbatchcount.Text}  Out of { label61.Text} batch", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (txtactual26.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtactual26.Focus();
                    txtactual26.Select();
                    txtactual26.BackColor = Color.Yellow;
                    return;
                }

                if (lblvalidate.Text.Trim() == label61.Text.Trim())
                {

                }
                else
                {

                    if (txtneeded.Text.Trim() == txtactual26.Text.Trim())
                    {

                    }
                    else
                    {
                        //gaspar
                        QuantityNotMatched();
                        txtactual26.Text = "";
                        txtactual26.Focus();
                        timer1.Start();

                        return;
                    }

                }
            }

            else

            {
                txtactual26.Text = "";
                timer1.Start();
                txtactual26.Select();
                return;
            }


            double qty1;
            double actual1;

            qty1 = double.Parse(txtqty26.Text);
            actual1 = double.Parse(txtactual26.Text);

            if (qty1 < actual1)
            {

                OverQuantity();

                txtactual26.Text = "";
                timer1.Start();
                txtactual26.Focus();
                return;
            }

            else
            {

                txtactual26.Enabled = false;
                txtactual27.Enabled = true;

                txtactual27.Focus();
            }





            lblrunningtotal.Text = (float.Parse(txtactual26.Text) + float.Parse(lblrunningtotal.Text)).ToString("#,0.00");

            lblactualweight.Text = (float.Parse(txtactual26.Text) * 1).ToString(); //lusaw
            btn6.Enabled = false;
            lblbatchcount.Text = "26";
            lbllost.Text = (float.Parse(lblrunningtotal.Text) - float.Parse(lblkg.Text)).ToString("#,0.00");
            DocheckingBatch();
            BtnSave.Enabled = true;
            BtnSave_Click(sender, e);
        }

        private void btn27_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (MetroFramework.MetroMessageBox.Show(this, $"Save the batch Entry   { lblbatchcount.Text}  Out of { label61.Text} batch", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (txtactual27.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtactual27.Focus();
                    txtactual27.Select();
                    txtactual27.BackColor = Color.Yellow;
                    return;
                }

                if (lblvalidate.Text.Trim() == label61.Text.Trim())
                {

                }
                else
                {

                    if (txtneeded.Text.Trim() == txtactual27.Text.Trim())
                    {

                    }
                    else
                    {
                        //gaspar
                        QuantityNotMatched();
                        txtactual27.Text = "";
                        txtactual27.Focus();
                        timer1.Start();

                        return;
                    }

                }

            }

            else

            {
                txtactual27.Text = "";
                timer1.Start();
                txtactual27.Focus();
                return;
            }
            timer1.Stop();

            double qty1;
            double actual1;

            qty1 = double.Parse(txtqty27.Text);
            actual1 = double.Parse(txtactual27.Text);

            if (qty1 < actual1)
            {

                OverQuantity();
                
                txtactual27.Text = "";
                timer1.Start();
                txtactual27.Focus();
                return;
            }

            else
            {

                txtactual27.Enabled = false;
                txtactual28.Enabled = true;

                txtactual28.Focus();
            }





            lblrunningtotal.Text = (float.Parse(txtactual27.Text) + float.Parse(lblrunningtotal.Text)).ToString("#,0.00");

            lblactualweight.Text = (float.Parse(txtactual27.Text) * 1).ToString(); //lusaw
            btn6.Enabled = false;
            lblbatchcount.Text = "27";
            lbllost.Text = (float.Parse(lblrunningtotal.Text) - float.Parse(lblkg.Text)).ToString("#,0.00");
            DocheckingBatch();
            BtnSave.Enabled = true;
            BtnSave_Click(sender, e);
        }

        private void btn28_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (MetroFramework.MetroMessageBox.Show(this, $"Save the batch Entry  { lblbatchcount.Text}  Out of { label61.Text} batch", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                if (txtactual28.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtactual28.Focus();
                    txtactual28.Select();
                    txtactual28.BackColor = Color.Yellow;
                    return;
                }
                if (lblvalidate.Text.Trim() == label61.Text.Trim())
                {

                }
                else
                {

                    if (txtneeded.Text.Trim() == txtactual28.Text.Trim())
                    {

                    }
                    else
                    {
                        //gaspar
                        QuantityNotMatched();
                        txtactual28.Text = "";
                        txtactual28.Focus();
                        timer1.Start();

                        return;
                    }

                }
            }

            else

            {
                txtactual28.Text = "";
                timer1.Start();
                txtactual28.Focus();
                return;
            }
            timer1.Stop();

            double qty1;
            double actual1;

            qty1 = double.Parse(txtqty28.Text);
            actual1 = double.Parse(txtactual28.Text);

            if (qty1 < actual1)
            {

                OverQuantity();
                txtactual28.Text = "";
                timer1.Start();
                txtactual28.Focus();
                return;
            }

            else
            {

                txtactual28.Enabled = false;
                txtactual29.Enabled = true;

                txtactual29.Focus();
            }





            lblrunningtotal.Text = (float.Parse(txtactual28.Text) + float.Parse(lblrunningtotal.Text)).ToString("#,0.00");

            lblactualweight.Text = (float.Parse(txtactual28.Text) * 1).ToString(); //lusaw
            btn6.Enabled = false;
            lblbatchcount.Text = "28";
            lbllost.Text = (float.Parse(lblrunningtotal.Text) - float.Parse(lblkg.Text)).ToString("#,0.00");
            DocheckingBatch();
            BtnSave.Enabled = true;
            BtnSave_Click(sender, e);
        }

        private void btn29_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (MetroFramework.MetroMessageBox.Show(this, $"Save the batch Entry   { lblbatchcount.Text}  Out of { label61.Text} batch", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                if (txtactual29.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtactual29.Focus();
                    txtactual29.Select();
                    txtactual29.BackColor = Color.Yellow;
                    return;
                }
                if (lblvalidate.Text.Trim() == label61.Text.Trim())
                {

                }
                else
                {

                    if (txtneeded.Text.Trim() == txtactual29.Text.Trim())
                    {

                    }
                    else
                    {
                        //gaspar
                        QuantityNotMatched();
                        txtactual29.Text = "";
                        txtactual29.Focus();
                        timer1.Start();

                        return;
                    }

                }
            }

            else

            {
                txtactual29.Text = "";
                timer1.Start();
                txtactual29.Focus();
                return;
            }
            timer1.Stop();

            double qty1;
            double actual1;

            qty1 = double.Parse(txtqty29.Text);
            actual1 = double.Parse(txtactual29.Text);

            if (qty1 < actual1)
            {

                OverQuantity();
                txtactual29.Text = "";
                timer1.Start();
                txtactual29.Focus();
                return;
            }

            else
            {

                txtactual29.Enabled = false;
                txtactual30.Enabled = true;

                txtactual30.Focus();
            }





            lblrunningtotal.Text = (float.Parse(txtactual29.Text) + float.Parse(lblrunningtotal.Text)).ToString("#,0.00");

            lblactualweight.Text = (float.Parse(txtactual29.Text) * 1).ToString(); //lusaw
            btn6.Enabled = false;
            lblbatchcount.Text = "29";
            lbllost.Text = (float.Parse(lblrunningtotal.Text) - float.Parse(lblkg.Text)).ToString("#,0.00");
            DocheckingBatch();
            BtnSave.Enabled = true;
            BtnSave_Click(sender, e);
        }

        private void btn30_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (MetroFramework.MetroMessageBox.Show(this, $"Save the batch Entry   { lblbatchcount.Text}  Out of { label61.Text} batch", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (txtactual30.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtactual30.Focus();
                    txtactual30.Select();
                    txtactual30.BackColor = Color.Yellow;
                    return;
                }
                if (lblvalidate.Text.Trim() == label61.Text.Trim())
                {

                }
                else
                {

                    if (txtneeded.Text.Trim() == txtactual30.Text.Trim())
                    {

                    }
                    else
                    {
                        //gaspar
                        QuantityNotMatched();
                        txtactual30.Text = "";
                        txtactual30.Focus();
                        timer1.Start();

                        return;
                    }

                }
            }

            else

            {
                txtactual30.Text = "";
                timer1.Start();
                txtactual30.Focus();
                return;
            }
            timer1.Stop();

            double qty1;
            double actual1;

            qty1 = double.Parse(txtqty30.Text);
            actual1 = double.Parse(txtactual30.Text);

            if (qty1 < actual1)
            {
                OverQuantity();
                txtactual30.Text = "";
                timer1.Start();
                txtactual30.Focus();
                return;
            }

            else
            {

                txtactual30.Enabled = false;
                txtactual31.Enabled = true;

                txtactual31.Focus();
            }





            lblrunningtotal.Text = (float.Parse(txtactual30.Text) + float.Parse(lblrunningtotal.Text)).ToString("#,0.00");

            lblactualweight.Text = (float.Parse(txtactual30.Text) * 1).ToString(); //lusaw
            btn6.Enabled = false;
            lblbatchcount.Text = "30";
            lbllost.Text = (float.Parse(lblrunningtotal.Text) - float.Parse(lblkg.Text)).ToString("#,0.00");
            DocheckingBatch();
            BtnSave.Enabled = true;
            BtnSave_Click(sender, e);
        }

        private void txtactual26_Click(object sender, EventArgs e)
        {
            timer1_Tick(sender, e);
        }

        private void txtactual27_Click(object sender, EventArgs e)
        {
            timer1_Tick(sender, e);
        }

        private void txtactual28_Click(object sender, EventArgs e)
        {
            timer1_Tick(sender, e);
        }

        private void txtactual29_Click(object sender, EventArgs e)
        {
            timer1_Tick(sender, e);
        }

        private void btn31_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (MetroFramework.MetroMessageBox.Show(this, $"Save the batch Entry   { lblbatchcount.Text}  Out of { label61.Text} batch", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (txtactual31.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtactual31.Focus();
                    txtactual31.Select();
                    txtactual31.BackColor = Color.Yellow;
                    return;
                }
                if (lblvalidate.Text.Trim() == label61.Text.Trim())
                {

                }
                else
                {

                    if (txtneeded.Text.Trim() == txtactual31.Text.Trim())
                    {

                    }
                    else
                    {
                        //gaspar
                        QuantityNotMatched();
                        txtactual31.Text = "";
                        txtactual31.Focus();
                        timer1.Start();

                        return;
                    }

                }


            }

            else

            {
                txtactual31.Text = "";
                timer1.Start();
                txtactual31.Focus();
                return;
            }
            timer1.Stop();

            double qty1;
            double actual1;

            qty1 = double.Parse(txtqty31.Text);
            actual1 = double.Parse(txtactual31.Text);

            if (qty1 < actual1)
            {

                OverQuantity();
                txtactual31.Text = "";
                timer1.Start();
                txtactual31.Focus();
                return;
            }

            else
            {

                txtactual31.Enabled = false;
                txtactual32.Enabled = true;

                txtactual32.Focus();
            }





            lblrunningtotal.Text = (float.Parse(txtactual31.Text) + float.Parse(lblrunningtotal.Text)).ToString("#,0.00");

            lblactualweight.Text = (float.Parse(txtactual31.Text) * 1).ToString(); //lusaw
            btn6.Enabled = false;
            lblbatchcount.Text = "31";
            lbllost.Text = (float.Parse(lblrunningtotal.Text) - float.Parse(lblkg.Text)).ToString("#,0.00");
            DocheckingBatch();
            BtnSave.Enabled = true;
            BtnSave_Click(sender, e);
        }

        private void btn32_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (MetroFramework.MetroMessageBox.Show(this, $"Save the batch Entry   { lblbatchcount.Text}  Out of { label61.Text} batch", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (txtactual32.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtactual32.Focus();
                    txtactual32.Select();
                    txtactual32.BackColor = Color.Yellow;
                    return;
                }
                if (lblvalidate.Text.Trim() == label61.Text.Trim())
                {

                }
                else
                {

                    if (txtneeded.Text.Trim() == txtactual32.Text.Trim())
                    {

                    }
                    else
                    {
                        //gaspar
                        QuantityNotMatched();
                        txtactual32.Text = "";
                        txtactual32.Focus();
                        timer1.Start();

                        return;
                    }

                }
            }

            else

            {
                txtactual32.Text = "";
                timer1.Start();
                txtactual32.Focus();
                return;
            }
            timer1.Stop();

            double qty1;
            double actual1;

            qty1 = double.Parse(txtqty32.Text);
            actual1 = double.Parse(txtactual32.Text);

            if (qty1 < actual1)
            {

                OverQuantity();
                txtactual32.Text = "";
                timer1.Start();
                txtactual32.Focus();
                return;
            }

            else
            {

                txtactual32.Enabled = false;
                txtactual33.Enabled = true;

                txtactual33.Focus();
            }





            lblrunningtotal.Text = (float.Parse(txtactual32.Text) + float.Parse(lblrunningtotal.Text)).ToString("#,0.00");

            lblactualweight.Text = (float.Parse(txtactual32.Text) * 1).ToString(); //lusaw
            btn6.Enabled = false;
            lblbatchcount.Text = "33";
            lbllost.Text = (float.Parse(lblrunningtotal.Text) - float.Parse(lblkg.Text)).ToString("#,0.00");
            DocheckingBatch();
            BtnSave.Enabled = true;
            BtnSave_Click(sender, e);
        }

        private void btn33_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (MetroFramework.MetroMessageBox.Show(this, $"Save the batch Entry  { lblbatchcount.Text}  Out of { label61.Text} batch", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                if (txtactual33.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtactual33.Focus();
                    txtactual33.Select();
                    txtactual33.BackColor = Color.Yellow;
                    return;
                }
                if (lblvalidate.Text.Trim() == label61.Text.Trim())
                {

                }
                else
                {

                    if (txtneeded.Text.Trim() == txtactual33.Text.Trim())
                    {

                    }
                    else
                    {
                        //gaspar
                        QuantityNotMatched();
                        txtactual33.Text = "";
                        txtactual33.Focus();
                        timer1.Start();

                        return;
                    }

                }
            }

            else

            {
                txtactual33.Text = "";
                timer1.Start();
                txtactual33.Focus();
                return;
            }
  

            double qty1;
            double actual1;

            qty1 = double.Parse(txtqty33.Text);
            actual1 = double.Parse(txtactual33.Text);

            if (qty1 < actual1)
            {
                OverQuantity();
                txtactual33.Text = "";
                timer1.Start();
                txtactual33.Focus();
                return;
            }

            else
            {

                txtactual33.Enabled = false;
                txtactual34.Enabled = true;

                txtactual34.Focus();
            }





            lblrunningtotal.Text = (float.Parse(txtactual33.Text) + float.Parse(lblrunningtotal.Text)).ToString("#,0.00");

            lblactualweight.Text = (float.Parse(txtactual33.Text) * 1).ToString(); //lusaw
            btn6.Enabled = false;
            lblbatchcount.Text = "33";
            lbllost.Text = (float.Parse(lblrunningtotal.Text) - float.Parse(lblkg.Text)).ToString("#,0.00");
            DocheckingBatch();
            BtnSave.Enabled = true;
            BtnSave_Click(sender, e);
        }

        private void btn34_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (MetroFramework.MetroMessageBox.Show(this, $"Save the batch Entry   { lblbatchcount.Text}  Out of { label61.Text} batch", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (txtactual34.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtactual34.Focus();
                    txtactual34.Select();
                    txtactual34.BackColor = Color.Yellow;
                    return;
                }

                if (lblvalidate.Text.Trim() == label61.Text.Trim())
                {

                }
                else
                {

                    if (txtneeded.Text.Trim() == txtactual34.Text.Trim())
                    {

                    }
                    else
                    {
                        //gaspar
                        QuantityNotMatched();
                        txtactual34.Text = "";
                        txtactual34.Focus();
                        timer1.Start();

                        return;
                    }

                }

            }

            else

            {
                txtactual34.Text = "";
                timer1.Start();
                txtactual34.Focus();
                return;
            }
            timer1.Stop();

            double qty1;
            double actual1;

            qty1 = double.Parse(txtqty34.Text);
            actual1 = double.Parse(txtactual34.Text);

            if (qty1 < actual1)
            {

                OverQuantity();
                txtactual34.Text = "";
                timer1.Start();
                txtactual34.Focus();
                return;
            }

            else
            {

                txtactual34.Enabled = false;
                txtactual35.Enabled = true;

                txtactual35.Focus();
            }





            lblrunningtotal.Text = (float.Parse(txtactual34.Text) + float.Parse(lblrunningtotal.Text)).ToString("#,0.00");

            lblactualweight.Text = (float.Parse(txtactual34.Text) * 1).ToString(); //lusaw
            btn6.Enabled = false;
            lblbatchcount.Text = "34";
            lbllost.Text = (float.Parse(lblrunningtotal.Text) - float.Parse(lblkg.Text)).ToString("#,0.00");
            DocheckingBatch();
            BtnSave.Enabled = true;
            BtnSave_Click(sender, e);
        }

        private void btn38_Click(object sender, EventArgs e)
        {

            if (MetroFramework.MetroMessageBox.Show(this, $"Save the basemixed   { lblbatchcount.Text}  AND { label61.Text} ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (txtactual38.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtactual38.Focus();
                    txtactual38.Select();
                    txtactual38.BackColor = Color.Yellow;
                    return;
                }

            }

            else

            {
                txtactual38.Focus();
                return;
            }
            timer1.Stop();

            double qty1;
            double actual1;

            qty1 = double.Parse(txtqty38.Text);
            actual1 = double.Parse(txtactual38.Text);

            if (qty1 < actual1)
            {

                MessageBox.Show("Less Than !");
                txtactual38.Text = "";
                return;
            }

            else
            {

                txtactual38.Enabled = false;
                txtactual39.Enabled = true;

                txtactual39.Focus();
            }





            lblrunningtotal.Text = (float.Parse(txtactual38.Text) + float.Parse(lblrunningtotal.Text)).ToString("#,0.00");

            lblactualweight.Text = (float.Parse(txtactual38.Text) * 1).ToString(); //lusaw
            btn6.Enabled = false;
            lblbatchcount.Text = "38";
            lbllost.Text = (float.Parse(lblrunningtotal.Text) - float.Parse(lblkg.Text)).ToString("#,0.00");
            DocheckingBatch();
            BtnSave.Enabled = true;
            BtnSave_Click(sender, e);
        }

        private void btn35_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (MetroFramework.MetroMessageBox.Show(this, $"Save the batch Entry   { lblbatchcount.Text}  Out of { label61.Text} batch", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (txtactual35.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtactual35.Focus();
                    txtactual35.Select();
                    txtactual35.BackColor = Color.Yellow;
                    return;
                }
                if (lblvalidate.Text.Trim() == label61.Text.Trim())
                {

                }
                else
                {

                    if (txtneeded.Text.Trim() == txtactual35.Text.Trim())
                    {

                    }
                    else
                    {
                        //gaspar
                        QuantityNotMatched();
                        txtactual35.Text = "";
                        txtactual35.Focus();
                        timer1.Start();

                        return;
                    }

                }
            }

            else

            {
                txtactual35.Text = "";
                timer1.Start();
                txtactual35.Focus();
                return;
            }
            timer1.Stop();

            double qty1;
            double actual1;

            qty1 = double.Parse(txtqty35.Text);
            actual1 = double.Parse(txtactual35.Text);

            if (qty1 < actual1)
            {
                OverQuantity();
                txtactual35.Text = "";
                timer1.Start();
                txtactual35.Focus();
                return;
            }

            else
            {

                txtactual35.Enabled = false;
                txtactual36.Enabled = true;

                txtactual36.Focus();
            }





            lblrunningtotal.Text = (float.Parse(txtactual35.Text) + float.Parse(lblrunningtotal.Text)).ToString("#,0.00");

            lblactualweight.Text = (float.Parse(txtactual35.Text) * 1).ToString(); //lusaw
            btn6.Enabled = false;
            lblbatchcount.Text = "35";
            lbllost.Text = (float.Parse(lblrunningtotal.Text) - float.Parse(lblkg.Text)).ToString("#,0.00");
            DocheckingBatch();
            BtnSave.Enabled = true;
            BtnSave_Click(sender, e);
        }

        private void btn36_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (MetroFramework.MetroMessageBox.Show(this, $"Save the batch Entry   { lblbatchcount.Text}  Out of { label61.Text} batch", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (txtactual36.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtactual36.Focus();
                    txtactual36.Select();
                    txtactual36.BackColor = Color.Yellow;
                    return;
                }
                if (lblvalidate.Text.Trim() == label61.Text.Trim())
                {

                }
                else
                {

                    if (txtneeded.Text.Trim() == txtactual36.Text.Trim())
                    {

                    }
                    else
                    {
                        //gaspar
                        QuantityNotMatched();
                        txtactual36.Text = "";
                        txtactual36.Focus();
                        timer1.Start();

                        return;
                    }

                }
            }

            else

            {
                txtactual36.Text = "";
                timer1.Start();
                txtactual36.Focus();
                return;
            }
            timer1.Stop();

            double qty1;
            double actual1;

            qty1 = double.Parse(txtqty36.Text);
            actual1 = double.Parse(txtactual36.Text);

            if (qty1 < actual1)
            {

                OverQuantity();

                txtactual36.Text = "";
                timer1.Start();
                txtactual36.Focus();
                return;
            }

            else
            {

                txtactual36.Enabled = false;
                txtactual37.Enabled = true;

                txtactual37.Focus();
            }





            lblrunningtotal.Text = (float.Parse(txtactual36.Text) + float.Parse(lblrunningtotal.Text)).ToString("#,0.00");

            lblactualweight.Text = (float.Parse(txtactual36.Text) * 1).ToString(); //lusaw
            btn6.Enabled = false;
            lblbatchcount.Text = "36";
            lbllost.Text = (float.Parse(lblrunningtotal.Text) - float.Parse(lblkg.Text)).ToString("#,0.00");
            DocheckingBatch();
            BtnSave.Enabled = true;
            BtnSave_Click(sender, e);
        }

        private void btn37_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (MetroFramework.MetroMessageBox.Show(this, $"Save the batch Entry   { lblbatchcount.Text}  Out of { label61.Text} batch", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                if (txtactual37.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtactual37.Focus();
                    txtactual37.Select();
                    txtactual37.BackColor = Color.Yellow;
                    return;
                }
                if (lblvalidate.Text.Trim() == label61.Text.Trim())
                {

                }
                else
                {

                    if (txtneeded.Text.Trim() == txtactual37.Text.Trim())
                    {

                    }
                    else
                    {
                        //gaspar
                        QuantityNotMatched();
                        txtactual37.Text = "";
                        txtactual37.Focus();
                        timer1.Start();

                        return;
                    }

                }
            }

            else

            {
                txtactual37.Text = "";
                timer1.Start();
                txtactual37.Focus();
                return;
            }
  

            double qty1;
            double actual1;

            qty1 = double.Parse(txtqty37.Text);
            actual1 = double.Parse(txtactual37.Text);

            if (qty1 < actual1)
            {

                OverQuantity();

                txtactual37.Text = "";
                timer1.Start();
                txtactual37.Focus();
                return;
            }

            else
            {

                txtactual37.Enabled = false;
                txtactual38.Enabled = true;

                txtactual38.Focus();
            }





            lblrunningtotal.Text = (float.Parse(txtactual37.Text) + float.Parse(lblrunningtotal.Text)).ToString("#,0.00");

            lblactualweight.Text = (float.Parse(txtactual37.Text) * 1).ToString(); //lusaw
            btn6.Enabled = false;
            lblbatchcount.Text = "37";
            lbllost.Text = (float.Parse(lblrunningtotal.Text) - float.Parse(lblkg.Text)).ToString("#,0.00");
            DocheckingBatch();
            BtnSave.Enabled = true;
            BtnSave_Click(sender, e);
        }

        private void btn39_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (MetroFramework.MetroMessageBox.Show(this, $"Save the batch Entry   { lblbatchcount.Text}  Out of { label61.Text} batch", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                if (txtactual39.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtactual39.Focus();
                    txtactual39.Select();
                    txtactual39.BackColor = Color.Yellow;
                    return;
                }
                if (lblvalidate.Text.Trim() == label61.Text.Trim())
                {

                }
                else
                {

                    if (txtneeded.Text.Trim() == txtactual39.Text.Trim())
                    {

                    }
                    else
                    {
                        //gaspar
                        QuantityNotMatched();
                        txtactual39.Text = "";
                        txtactual39.Focus();
                        timer1.Start();

                        return;
                    }

                }
            }

            else

            {
                txtactual39.Text = "";
                timer1.Start();
                txtactual39.Focus();
                return;
            }
            timer1.Stop();

            double qty1;
            double actual1;

            qty1 = double.Parse(txtqty39.Text);
            actual1 = double.Parse(txtactual39.Text);

            if (qty1 < actual1)
            {
                OverQuantity();
                txtactual39.Text = "";
                timer1.Start();
                txtactual39.Focus();
                return;
            }

            else
            {

                txtactual39.Enabled = false;
                txtactual40.Enabled = true;

                txtactual40.Focus();
            }





            lblrunningtotal.Text = (float.Parse(txtactual39.Text) + float.Parse(lblrunningtotal.Text)).ToString("#,0.00");

            lblactualweight.Text = (float.Parse(txtactual39.Text) * 1).ToString(); //lusaw
            btn6.Enabled = false;
            lblbatchcount.Text = "39";
            lbllost.Text = (float.Parse(lblrunningtotal.Text) - float.Parse(lblkg.Text)).ToString("#,0.00");
            DocheckingBatch();
            BtnSave.Enabled = true;
            BtnSave_Click(sender, e);
        }

        private void btn40_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (MetroFramework.MetroMessageBox.Show(this, $"Save the batch Entry   { lblbatchcount.Text}  Out of { label61.Text} bacth", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                if (txtactual40.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtactual40.Focus();
                    txtactual40.Select();
                    txtactual40.BackColor = Color.Yellow;
                    return;
                }
                if (lblvalidate.Text.Trim() == label61.Text.Trim())
                {

                }
                else
                {

                    if (txtneeded.Text.Trim() == txtactual40.Text.Trim())
                    {

                    }
                    else
                    {
                        //gaspar
                        QuantityNotMatched();
                        txtactual40.Text = "";
                        txtactual40.Focus();
                        timer1.Start();

                        return;
                    }

                }
            }

            else

            {
                txtactual40.Text = "";
                timer1.Start();
                txtactual40.Focus();
                return;
            }
            timer1.Stop();

            double qty1;
            double actual1;

            qty1 = double.Parse(txtqty40.Text);
            actual1 = double.Parse(txtactual40.Text);

            if (qty1 < actual1)
            {

                OverQuantity();
                txtactual40.Text = "";
                timer1.Start();
                txtactual40.Focus();
                return;
            }

            else
            {

                txtactual40.Enabled = false;
                txtactual41.Enabled = true;

                txtactual41.Focus();
            }





            lblrunningtotal.Text = (float.Parse(txtactual40.Text) + float.Parse(lblrunningtotal.Text)).ToString("#,0.00");

            lblactualweight.Text = (float.Parse(txtactual40.Text) * 1).ToString(); //lusaw
            btn6.Enabled = false;
            lblbatchcount.Text = "40";
            lbllost.Text = (float.Parse(lblrunningtotal.Text) - float.Parse(lblkg.Text)).ToString("#,0.00");
            DocheckingBatch();
            BtnSave.Enabled = true;
            BtnSave_Click(sender, e);
        }

        private void txtactual31_Click(object sender, EventArgs e)
        {
            timer1_Tick(sender, e);
        }

        private void txtactual32_Click(object sender, EventArgs e)
        {
            timer1_Tick(sender, e);
        }

        private void txtactual33_Click(object sender, EventArgs e)
        {
            timer1_Tick(sender, e);
        }

        private void txtactual34_Click(object sender, EventArgs e)
        {
            timer1_Tick(sender, e);
        }

        private void txtactual35_Click(object sender, EventArgs e)
        {
            timer1_Tick(sender, e);
        }

        private void txtactual36_Click(object sender, EventArgs e)
        {
            timer1_Tick(sender, e);
        }

        private void txtactual37_Click(object sender, EventArgs e)
        {
            timer1_Tick(sender, e);
        }

        private void txtactual38_Click(object sender, EventArgs e)
        {
            timer1_Tick(sender, e);
        }

        private void txtactual39_Click(object sender, EventArgs e)
        {
            timer1_Tick(sender, e);
        }

        private void txtactual40_Click(object sender, EventArgs e)
        {
            timer1_Tick(sender, e);
        }

        private void btn41_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (MetroFramework.MetroMessageBox.Show(this, $"Save the batch Entry { lblbatchcount.Text}  Out of { label61.Text} batch", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                if (txtactual41.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtactual41.Focus();
                    txtactual41.Select();
                    txtactual41.BackColor = Color.Yellow;
                    return;
                }
                if (lblvalidate.Text.Trim() == label61.Text.Trim())
                {

                }
                else
                {

                    if (txtneeded.Text.Trim() == txtactual41.Text.Trim())
                    {

                    }
                    else
                    {
                        //gaspar
                        QuantityNotMatched();
                        txtactual41.Text = "";
                        txtactual41.Focus();
                        timer1.Start();

                        return;
                    }

                }
            }

            else

            {
                txtactual41.Text = "";
                timer1.Start();
                txtactual41.Focus();
                return;
            }
            timer1.Stop();

            double qty1;
            double actual1;

            qty1 = double.Parse(txtqty41.Text);
            actual1 = double.Parse(txtactual41.Text);

            if (qty1 < actual1)
            {
                OverQuantity();
                txtactual41.Text = "";
                timer1.Start();
                txtactual41.Focus();
                return;
            }

            else
            {

                txtactual41.Enabled = false;
                txtactual42.Enabled = true;

                txtactual42.Focus();
            }





            lblrunningtotal.Text = (float.Parse(txtactual41.Text) + float.Parse(lblrunningtotal.Text)).ToString("#,0.00");

            lblactualweight.Text = (float.Parse(txtactual41.Text) * 1).ToString(); //lusaw
            btn6.Enabled = false;
            lblbatchcount.Text = "41";
            lbllost.Text = (float.Parse(lblrunningtotal.Text) - float.Parse(lblkg.Text)).ToString("#,0.00");
            DocheckingBatch();
            BtnSave.Enabled = true;
            BtnSave_Click(sender, e);
        }

        private void btn42_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (MetroFramework.MetroMessageBox.Show(this, $"Save the batch Entry   { lblbatchcount.Text}  Out of { label61.Text} batch", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (txtactual42.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtactual42.Focus();
                    txtactual42.Select();
                    txtactual42.BackColor = Color.Yellow;
                    return;
                }
                if (lblvalidate.Text.Trim() == label61.Text.Trim())
                {

                }
                else
                {

                    if (txtneeded.Text.Trim() == txtactual42.Text.Trim())
                    {

                    }
                    else
                    {
                        //gaspar
                        QuantityNotMatched();
                        txtactual42.Text = "";
                        txtactual42.Focus();
                        timer1.Start();

                        return;
                    }

                }
            }

            else

            {
                txtactual42.Text = "";
                timer1.Start();

                txtactual42.Focus();
                return;
            }
            timer1.Stop();

            double qty1;
            double actual1;

            qty1 = double.Parse(txtqty42.Text);
            actual1 = double.Parse(txtactual42.Text);

            if (qty1 < actual1)
            {

                OverQuantity();
                txtactual42.Text = "";
                timer1.Start();
                txtactual42.Focus();
                return;
            }

            else
            {

                txtactual42.Enabled = false;
                txtactual43.Enabled = true;

                txtactual43.Focus();
            }





            lblrunningtotal.Text = (float.Parse(txtactual42.Text) + float.Parse(lblrunningtotal.Text)).ToString("#,0.00");

            lblactualweight.Text = (float.Parse(txtactual42.Text) * 1).ToString(); //lusaw
            btn6.Enabled = false;
            lblbatchcount.Text = "42";
            lbllost.Text = (float.Parse(lblrunningtotal.Text) - float.Parse(lblkg.Text)).ToString("#,0.00");
            DocheckingBatch();
            BtnSave.Enabled = true;
            BtnSave_Click(sender, e);
        }

        private void btn43_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (MetroFramework.MetroMessageBox.Show(this, $"Save the batch Entry   { lblbatchcount.Text}  Out of { label61.Text} batch", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (txtactual43.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtactual43.Focus();
                    txtactual43.Select();
                    txtactual43.BackColor = Color.Yellow;
                    return;
                }
                if (lblvalidate.Text.Trim() == label61.Text.Trim())
                {

                }
                else
                {

                    if (txtneeded.Text.Trim() == txtactual43.Text.Trim())
                    {

                    }
                    else
                    {
                        //gaspar
                        QuantityNotMatched();
                        txtactual43.Text = "";
                        txtactual43.Focus();
                        timer1.Start();

                        return;
                    }

                }


            }

            else

            {
                txtactual43.Text = "";
                timer1.Start();
                txtactual43.Focus();
                return;
            }
            timer1.Stop();

            double qty1;
            double actual1;

            qty1 = double.Parse(txtqty43.Text);
            actual1 = double.Parse(txtactual43.Text);

            if (qty1 < actual1)
            {

                OverQuantity();
                
                txtactual43.Text = "";
                timer1.Start();
                txtactual43.Focus();
                return;
            }

            else
            {

                txtactual43.Enabled = false;
                txtactual44.Enabled = true;

                txtactual44.Focus();
            }





            lblrunningtotal.Text = (float.Parse(txtactual43.Text) + float.Parse(lblrunningtotal.Text)).ToString("#,0.00");

            lblactualweight.Text = (float.Parse(txtactual43.Text) * 1).ToString(); //lusaw
            btn6.Enabled = false;
            lblbatchcount.Text = "43";
            lbllost.Text = (float.Parse(lblrunningtotal.Text) - float.Parse(lblkg.Text)).ToString("#,0.00");
            DocheckingBatch();
            BtnSave.Enabled = true;
            BtnSave_Click(sender, e);
        }

        private void btn44_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (MetroFramework.MetroMessageBox.Show(this, $"Save the batch Entry   { lblbatchcount.Text}  Out of { label61.Text} batch", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                if (txtactual44.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtactual44.Focus();
                    txtactual44.Select();
                    txtactual44.BackColor = Color.Yellow;
                    return;
                }
                if (lblvalidate.Text.Trim() == label61.Text.Trim())
                {

                }
                else
                {

                    if (txtneeded.Text.Trim() == txtactual44.Text.Trim())
                    {

                    }
                    else
                    {
                        //gaspar
                        QuantityNotMatched();
                        txtactual44.Text = "";
                        txtactual44.Focus();
                        timer1.Start();

                        return;
                    }

                }



            }

            else

            {
                txtactual44.Text = "";
                timer1.Start();
                txtactual44.Focus();
                return;
            }
            timer1.Stop();

            double qty1;
            double actual1;

            qty1 = double.Parse(txtqty44.Text);
            actual1 = double.Parse(txtactual44.Text);

            if (qty1 < actual1)
            {

                OverQuantity();
                txtactual44.Text = "";
                timer1.Start();
                txtactual44.Focus();
                return;
            }

            else
            {

                txtactual44.Enabled = false;
                txtactual45.Enabled = true;

                txtactual45.Focus();
            }





            lblrunningtotal.Text = (float.Parse(txtactual44.Text) + float.Parse(lblrunningtotal.Text)).ToString("#,0.00");

            lblactualweight.Text = (float.Parse(txtactual44.Text) * 1).ToString(); //lusaw
            btn6.Enabled = false;
            lblbatchcount.Text = "44";
            lbllost.Text = (float.Parse(lblrunningtotal.Text) - float.Parse(lblkg.Text)).ToString("#,0.00");
            DocheckingBatch();
            BtnSave.Enabled = true;
            BtnSave_Click(sender, e);
        }

        private void btn45_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (MetroFramework.MetroMessageBox.Show(this, $"Save the batch Entry   { lblbatchcount.Text}  Out of { label61.Text} batch", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                if (txtactual45.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtactual45.Focus();
                    txtactual45.Select();
                    txtactual45.BackColor = Color.Yellow;
                    return;
                }

                if (lblvalidate.Text.Trim() == label61.Text.Trim())
                {

                }
                else
                {

                    if (txtneeded.Text.Trim() == txtactual45.Text.Trim())
                    {

                    }
                    else
                    {
                        //gaspar
                        QuantityNotMatched();
                        txtactual45.Text = "";
                        txtactual45.Focus();
                        timer1.Start();

                        return;
                    }

                }

            }

            else

            {
                txtactual45.Text = "";
                timer1.Start();
                txtactual45.Focus();
                return;
            }
            timer1.Stop();

            double qty1;
            double actual1;

            qty1 = double.Parse(txtqty45.Text);
            actual1 = double.Parse(txtactual45.Text);

            if (qty1 < actual1)
            {
                OverQuantity();
                txtactual45.Text = "";
                timer1.Start();
                txtactual45.Focus();
                return;
            }

            else
            {

                txtactual45.Enabled = false;
                txtactual46.Enabled = true;

                txtactual46.Focus();
            }





            lblrunningtotal.Text = (float.Parse(txtactual45.Text) + float.Parse(lblrunningtotal.Text)).ToString("#,0.00");

            lblactualweight.Text = (float.Parse(txtactual45.Text) * 1).ToString(); //lusaw
            btn6.Enabled = false;
            lblbatchcount.Text = "45";
            lbllost.Text = (float.Parse(lblrunningtotal.Text) - float.Parse(lblkg.Text)).ToString("#,0.00");
            DocheckingBatch();
            BtnSave.Enabled = true;
            BtnSave_Click(sender, e);
        }

        private void btn46_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (MetroFramework.MetroMessageBox.Show(this, $"Save the batch Entry   { lblbatchcount.Text}  Out of { label61.Text} batch", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (txtactual46.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtactual46.Focus();
                    txtactual46.Select();
                    txtactual46.BackColor = Color.Yellow;
                    return;
                }
                if (lblvalidate.Text.Trim() == label61.Text.Trim())
                {

                }
                else
                {

                    if (txtneeded.Text.Trim() == txtactual46.Text.Trim())
                    {

                    }
                    else
                    {
                        //gaspar
                        QuantityNotMatched();
                        txtactual46.Text = "";
                        txtactual46.Focus();
                        timer1.Start();

                        return;
                    }

                }

            }

            else

            {
                txtactual46.Text = "";
                timer1.Start();
                txtactual46.Focus();
                return;
            }
            timer1.Stop();

            double qty1;
            double actual1;

            qty1 = double.Parse(txtqty46.Text);
            actual1 = double.Parse(txtactual46.Text);

            if (qty1 < actual1)
            {

                OverQuantity();
                txtactual46.Text = "";
                timer1.Start();
                txtactual46.Focus();
                return;
            }

            else
            {

                txtactual46.Enabled = false;
                txtactual47.Enabled = true;

                txtactual47.Focus();
            }





            lblrunningtotal.Text = (float.Parse(txtactual46.Text) + float.Parse(lblrunningtotal.Text)).ToString("#,0.00");

            lblactualweight.Text = (float.Parse(txtactual46.Text) * 1).ToString(); //lusaw
            btn6.Enabled = false;
            lblbatchcount.Text = "46";
            lbllost.Text = (float.Parse(lblrunningtotal.Text) - float.Parse(lblkg.Text)).ToString("#,0.00");
            DocheckingBatch();
            BtnSave.Enabled = true;
            BtnSave_Click(sender, e);
        }

        private void btn47_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (MetroFramework.MetroMessageBox.Show(this, $"Save the batch Entry   { lblbatchcount.Text}  Out of { label61.Text} batch", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                if (txtactual47.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtactual47.Focus();
                    txtactual47.Select();
                    txtactual47.BackColor = Color.Yellow;
                    return;
                }
                if (lblvalidate.Text.Trim() == label61.Text.Trim())
                {

                }
                else
                {

                    if (txtneeded.Text.Trim() == txtactual47.Text.Trim())
                    {

                    }
                    else
                    {
                        //gaspar
                        QuantityNotMatched();
                        txtactual47.Text = "";
                        txtactual47.Focus();
                        timer1.Start();

                        return;
                    }

                }
            }

            else

            {
                txtactual47.Text = "";
                timer1.Start();
                txtactual47.Focus();
                return;
            }
            timer1.Stop();

            double qty1;
            double actual1;

            qty1 = double.Parse(txtqty47.Text);
            actual1 = double.Parse(txtactual47.Text);

            if (qty1 < actual1)
            {

                OverQuantity();
                txtactual47.Text = "";
                timer1.Start();
                txtactual47.Focus();
                return;
            }

            else
            {

                txtactual47.Enabled = false;
                txtactual48.Enabled = true;

                txtactual48.Focus();
            }





            lblrunningtotal.Text = (float.Parse(txtactual47.Text) + float.Parse(lblrunningtotal.Text)).ToString("#,0.00");

            lblactualweight.Text = (float.Parse(txtactual47.Text) * 1).ToString(); //lusaw
            btn6.Enabled = false;
            lblbatchcount.Text = "47";
            lbllost.Text = (float.Parse(lblrunningtotal.Text) - float.Parse(lblkg.Text)).ToString("#,0.00");
            DocheckingBatch();
            BtnSave.Enabled = true;
            BtnSave_Click(sender, e);
        }

        private void btn48_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (MetroFramework.MetroMessageBox.Show(this, $"Save the batch Entry  { lblbatchcount.Text}  Out of { label61.Text} batch", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                if (txtactual48.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtactual48.Focus();
                    txtactual48.Select();
                    txtactual48.BackColor = Color.Yellow;
                    return;
                }
                if (lblvalidate.Text.Trim() == label61.Text.Trim())
                {

                }
                else
                {

                    if (txtneeded.Text.Trim() == txtactual48.Text.Trim())
                    {

                    }
                    else
                    {
                        //gaspar
                        QuantityNotMatched();
                        txtactual48.Text = "";
                        txtactual48.Focus();
                        timer1.Start();

                        return;
                    }

                }
            }

            else

            {
                txtactual48.Text = "";
                timer1.Start();

                txtactual48.Focus();
                return;
            }
            timer1.Stop();

            double qty1;
            double actual1;

            qty1 = double.Parse(txtqty48.Text);
            actual1 = double.Parse(txtactual48.Text);

            if (qty1 < actual1)
            {

                OverQuantity();
                txtactual48.Text = "";
                timer1.Start();
                txtactual48.Focus();
                return;
            }

            else
            {

                txtactual48.Enabled = false;
                txtactual49.Enabled = true;

                txtactual49.Focus();
            }





            lblrunningtotal.Text = (float.Parse(txtactual48.Text) + float.Parse(lblrunningtotal.Text)).ToString("#,0.00");

            lblactualweight.Text = (float.Parse(txtactual48.Text) * 1).ToString(); //lusaw
            btn6.Enabled = false;
            lblbatchcount.Text = "48";
            lbllost.Text = (float.Parse(lblrunningtotal.Text) - float.Parse(lblkg.Text)).ToString("#,0.00");
            DocheckingBatch();
            BtnSave.Enabled = true;
            BtnSave_Click(sender, e);
        }

        private void btn49_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (MetroFramework.MetroMessageBox.Show(this, $"Save the batch Entry { lblbatchcount.Text}  Out of { label61.Text} batch", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (txtactual49.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtactual49.Focus();
                    txtactual49.Select();
                    txtactual49.BackColor = Color.Yellow;
                    return;
                }
                if (lblvalidate.Text.Trim() == label61.Text.Trim())
                {

                }
                else
                {

                    if (txtneeded.Text.Trim() == txtactual49.Text.Trim())
                    {

                    }
                    else
                    {
                        //gaspar
                        QuantityNotMatched();
                        txtactual49.Text = "";
                        txtactual49.Focus();
                        timer1.Start();

                        return;
                    }

                }

            }

            else

            {
                txtactual49.Text = "";
                timer1.Start();
                txtactual49.Focus();
                return;
            }
            timer1.Stop();

            double qty1;
            double actual1;

            qty1 = double.Parse(txtqty49.Text);
            actual1 = double.Parse(txtactual49.Text);

            if (qty1 < actual1)
            {

                OverQuantity();
                txtactual49.Text = "";
                timer1.Start();
                txtactual49.Focus();
                return;
            }

            else
            {

                txtactual49.Enabled = false;
                txtactual50.Enabled = true;

                txtactual50.Focus();
            }





            lblrunningtotal.Text = (float.Parse(txtactual49.Text) + float.Parse(lblrunningtotal.Text)).ToString("#,0.00");

            lblactualweight.Text = (float.Parse(txtactual49.Text) * 1).ToString(); //lusaw
            btn6.Enabled = false;
            lblbatchcount.Text = "49";
            lbllost.Text = (float.Parse(lblrunningtotal.Text) - float.Parse(lblkg.Text)).ToString("#,0.00");
            DocheckingBatch();
            BtnSave.Enabled = true;
            BtnSave_Click(sender, e);
        }

        private void btn50_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (MetroFramework.MetroMessageBox.Show(this, $"Save the batch Entry   { lblbatchcount.Text} Out of { label61.Text} batch", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (txtactual50.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtactual50.Focus();
                    txtactual50.Select();
                    txtactual50.BackColor = Color.Yellow;
                    return;
                }
                if (lblvalidate.Text.Trim() == label61.Text.Trim())
                {

                }
                else
                {

                    if (txtneeded.Text.Trim() == txtactual50.Text.Trim())
                    {

                    }
                    else
                    {
                        //gaspar
                        QuantityNotMatched();
                        txtactual50.Text = "";
                        txtactual50.Focus();
                        timer1.Start();

                        return;
                    }

                }

            }

            else

            {
                txtactual50.Text = "";
                timer1.Start();
                txtactual50.Focus();
                return;
            }
            timer1.Stop();

            double qty1;
            double actual1;

            qty1 = double.Parse(txtqty50.Text);
            actual1 = double.Parse(txtactual50.Text);

            if (qty1 < actual1)
            {

                OverQuantity();
                txtactual50.Text = "";
                timer1.Start();
                txtactual50.Focus();
                return;
            }

            else
            {

                txtactual50.Enabled = false;
                txtactual51.Enabled = true;

                txtactual51.Focus();
            }





            lblrunningtotal.Text = (float.Parse(txtactual50.Text) + float.Parse(lblrunningtotal.Text)).ToString("#,0.00");

            lblactualweight.Text = (float.Parse(txtactual50.Text) * 1).ToString(); //lusaw
            btn6.Enabled = false;
            lblbatchcount.Text = "50";
            lbllost.Text = (float.Parse(lblrunningtotal.Text) - float.Parse(lblkg.Text)).ToString("#,0.00");
            DocheckingBatch();
            BtnSave.Enabled = true;
            BtnSave_Click(sender, e);
        }

        private void lblnum42_Click(object sender, EventArgs e)
        {

        }

        private void dgvMaster_Click(object sender, EventArgs e)
        {
            txtmainfeedcode_TextChanged_1(sender, e);
        }

        private void buton19_Click(object sender, EventArgs e)
        {




            if (txtchecking19.Text.Trim() == string.Empty)
            {

                //MessageBox.Show("Part 19", "Barcode Input Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BarcodeNotFound();
                txtchecking19.Select();
                txtchecking19.Focus();
                txtchecking19.BackColor = Color.Yellow;


                return;
            }
            else
            {

                //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
                String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
                SqlConnection sql_con = new SqlConnection(connetionString);

                cmd = new SqlCommand("SELECT string_id FROM [dbo].[rdf_repackin_entry]  WHERE string_id='" + txtchecking19.Text + "'", sql_con);

                SqlDataAdapter daks = new SqlDataAdapter(cmd);

                daks.Fill(ds);
                int ia = ds.Tables[0].Rows.Count;
                if (ia > 0)
                {


                    search19();


                    if (txtBarcode.Text.Trim() == txtchecking19.Text.Trim())
                    {
                        //MessageBox.Show("Proceed Match Code");

                    }
                    else
                    {

                        RepackIDNotMatched();
                        txtchecking19.Text = "";
                        txtchecking19.Select();
                        txtchecking19.Focus();

                        return;
                    }


                    txtrepcom19.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();



                    txtchecking19.BackColor = Color.LightGreen;
                    pictureBox44.Visible = true;
                    //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                    txtchecking20.Focus();
                    txtchecking20.Select();

                    CountNumber();
                    txtchecking19.Visible = true;
                    ds.Clear();







                    //return;
                }
                else
                {
                    //MessageBox.Show("The Repacking Selected" + txtchecking19.Text + " IS Not Exists !!");
                    RepackIdNotExists();
                    txtchecking19.BackColor = Color.Yellow;
                    txtchecking19.Text = "";
                    txtchecking19.Select();
                    txtchecking19.Focus();
                    return;
                    //return; // ang gulo ntyo mga bugok
                }







            }





        }

        private void buton20_Click(object sender, EventArgs e)
        {



            if (txtchecking20.Text.Trim() == string.Empty)
            {

                //MessageBox.Show("Part 20", "Barcode Input Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BarcodeNotFound();
                txtchecking20.Select();
                txtchecking20.Focus();
                txtchecking20.BackColor = Color.Yellow;


                return;
            }
            else
            {

                //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
                String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
                SqlConnection sql_con = new SqlConnection(connetionString);

                cmd = new SqlCommand("SELECT string_id FROM [dbo].[rdf_repackin_entry]  WHERE string_id='" + txtchecking20.Text + "'", sql_con);

                SqlDataAdapter daks = new SqlDataAdapter(cmd);

                daks.Fill(ds);
                int ia = ds.Tables[0].Rows.Count;
                if (ia > 0)
                {
                    //MessageBox.Show("The Formula" + txt1.Text + "Already Exists !");

                    search20();


                    if (txtBarcode.Text.Trim() == txtchecking20.Text.Trim())
                    {
                        //MessageBox.Show("Proceed Match Code");

                    }
                    else
                    {
                        //MessageBox.Show("Repak ID Not Match!, Choose the exactly item Thanks !");
                        RepackIDNotMatched();
                        txtchecking20.Text = "";
                        txtchecking20.Select();
                        txtchecking20.Focus();
                        return;
                    }


                    txtrepcom20.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();

                    //txtchecking20.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();

                    txtchecking20.BackColor = Color.LightGreen;
                    pictureBox45.Visible = true;
                    //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                    txtchecking21.Focus();
                    txtchecking21.Select();

                    CountNumber();
                    txtchecking20.Visible = true;
                    ds.Clear();







                    //return;
                }
                else
                {
                    //MessageBox.Show("The Repacking Selected" + txtchecking20.Text + " IS Not Exists !!");
                    RepackIdNotExists();
                    txtchecking20.BackColor = Color.Yellow;
                    txtchecking20.Text = "";
                    txtchecking20.Select();
                    txtchecking20.Focus();
                    return;
                    //return; // ang gulo ntyo mga bugok
                }






            }



        }

        private void buton21_Click(object sender, EventArgs e)
        {



            if (txtchecking21.Text.Trim() == string.Empty)
            {

                //MessageBox.Show("Part 21", "Barcode Input Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BarcodeNotFound();
                txtchecking21.Select();
                txtchecking21.Focus();
                txtchecking21.BackColor = Color.Yellow;


                return;
            }
            else
            {

                //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
                String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
                SqlConnection sql_con = new SqlConnection(connetionString);

                cmd = new SqlCommand("SELECT string_id FROM [dbo].[rdf_repackin_entry]  WHERE string_id='" + txtchecking21.Text + "'", sql_con);

                SqlDataAdapter daks = new SqlDataAdapter(cmd);

                daks.Fill(ds);
                int ia = ds.Tables[0].Rows.Count;
                if (ia > 0)
                {
                    //MessageBox.Show("The Formula" + txt1.Text + "Already Exists !");

                    search21();


                    if (txtBarcode.Text.Trim() == txtchecking21.Text.Trim())
                    {
                        //MessageBox.Show("Proceed Match Code");

                    }
                    else
                    {
                        RepackIdNotExists();
                        txtchecking21.Text = "";
                        txtchecking21.Select();
                        txtchecking21.Focus();
                        return;
                    }


                    txtrepcom21.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();



                    txtchecking21.BackColor = Color.LightGreen;
                    pictureBox46.Visible = true;
                    //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                    txtchecking22.Focus();
                    txtchecking22.Select();
                    CountNumber();
                    txtchecking21.Visible = true;
                    ds.Clear();







                    //return;
                }
                else
                {
                    //MessageBox.Show("The Repacking Selected" + txtchecking21.Text + " IS Not Exists !!");
                    RepackIdNotExists();
                    txtchecking21.BackColor = Color.Yellow;
                    txtchecking21.Text = "";
                    txtchecking21.Select();
                    txtchecking21.Focus();
                    return;
                    //return; // ang gulo ntyo mga bugok
                }














            }

        }

        private void buton22_Click(object sender, EventArgs e)
        {




            if (txtchecking22.Text.Trim() == string.Empty)
            {

                //MessageBox.Show("Part 22", "Barcode Input Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BarcodeNotFound();
                txtchecking22.Select();
                txtchecking22.Focus();
                txtchecking22.BackColor = Color.Yellow;


                return;
            }
            else
            {

                //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
                String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
                SqlConnection sql_con = new SqlConnection(connetionString);

                cmd = new SqlCommand("SELECT string_id FROM [dbo].[rdf_repackin_entry]  WHERE string_id='" + txtchecking22.Text + "'", sql_con);

                SqlDataAdapter daks = new SqlDataAdapter(cmd);

                daks.Fill(ds);
                int ia = ds.Tables[0].Rows.Count;
                if (ia > 0)
                {
                    //MessageBox.Show("The Formula" + txt1.Text + "Already Exists !");

                    search22();


                    if (txtBarcode.Text.Trim() == txtchecking22.Text.Trim())
                    {
                        //MessageBox.Show("Proceed Match Code");

                    }
                    else
                    {
                        //MessageBox.Show("Repak ID Not Match!, Choose the exactly item Thanks !");
                        RepackIDNotMatched();
                        txtchecking22.Text = "";
                        txtchecking22.Select();
                        txtchecking22.Focus();
                        return;
                    }


                    txtrepcom22.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();

                    txtchecking22.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();

                    txtchecking22.BackColor = Color.LightGreen;
                    pictureBox47.Visible = true;
                    //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                    txtchecking23.Focus();
                    txtchecking23.Select();
                    CountNumber();
                    txtchecking22.Visible = true;
                    ds.Clear();







                    //return;
                }
                else
                {
                    //MessageBox.Show("The Repacking Selected" + txtchecking22.Text + " IS Not Exists !!");
                    RepackIdNotExists();
                    txtchecking22.BackColor = Color.Yellow;
                    txtchecking22.Text = "";
                    txtchecking22.Select();
                    txtchecking22.Focus();
                    return;
                    //return; // ang gulo ntyo mga bugok
                }








            }
        }

        private void buton23_Click(object sender, EventArgs e)
        {
            if (lblbatch.Rows.Count >= 1)
            {
                int i = lblbatch.CurrentRow.Index + 1;
                if (i >= -1 && i < lblbatch.Rows.Count)



                    if (txtchecking23.Text.Trim() == string.Empty)
                    {

                        //MessageBox.Show("Part 23", "Barcode Input Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BarcodeNotFound();
                        txtchecking23.Select();
                        txtchecking23.Focus();
                        txtchecking23.BackColor = Color.Yellow;


                        return;
                    }
                    else
                    {

                        //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
                        String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
                        SqlConnection sql_con = new SqlConnection(connetionString);

                        cmd = new SqlCommand("SELECT string_id FROM [dbo].[rdf_repackin_entry]  WHERE string_id='" + txtchecking23.Text + "'", sql_con);

                        SqlDataAdapter daks = new SqlDataAdapter(cmd);

                        daks.Fill(ds);
                        int ia = ds.Tables[0].Rows.Count;
                        if (ia > 0)
                        {
                            //MessageBox.Show("The Formula" + txt1.Text + "Already Exists !");

                            search23();


                            if (txtBarcode.Text.Trim() == txtchecking23.Text.Trim())
                            {
                                //MessageBox.Show("Proceed Match Code");

                            }
                            else
                            {
                                //MessageBox.Show("Repak ID Not Match!, Choose the exactly item Thanks !");
                                RepackIDNotMatched();
                                txtchecking23.Text = "";
                                txtchecking23.Select();
                                txtchecking23.Focus();
                                return;
                            }


                            txtrepcom23.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();



                            txtchecking23.BackColor = Color.LightGreen;
                            pictureBox48.Visible = true;
                            //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                            txtchecking24.Focus();
                            txtchecking24.Select();
                            txtchecking23.Visible = true;

                            lblbatch.CurrentCell = lblbatch.Rows[i].Cells[0];
                            ds.Clear();







                            //return;
                        }
                        else
                        {
                            //MessageBox.Show("The Repacking Selected" + txtchecking23.Text + " IS Not Exists !!");
                            RepackIdNotExists();
                            txtchecking23.BackColor = Color.Yellow;
                            txtchecking23.Text = "";
                            txtchecking23.Select();
                            txtchecking23.Focus();
                            return;
                            //return; // ang gulo ntyo mga bugok
                        }








                    }


            }
        }

        private void buton24_Click(object sender, EventArgs e)
        {




            if (txtchecking24.Text.Trim() == string.Empty)
            {

                //MessageBox.Show("Part 24", "Barcode Input Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BarcodeNotFound();
                txtchecking24.Select();
                txtchecking24.Focus();
                txtchecking24.BackColor = Color.Yellow;


                return;
            }
            else
            {

                //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
                String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
                SqlConnection sql_con = new SqlConnection(connetionString);

                cmd = new SqlCommand("SELECT string_id FROM [dbo].[rdf_repackin_entry]  WHERE string_id='" + txtchecking24.Text + "'", sql_con);

                SqlDataAdapter daks = new SqlDataAdapter(cmd);

                daks.Fill(ds);
                int ia = ds.Tables[0].Rows.Count;
                if (ia > 0)
                {
                    //MessageBox.Show("The Formula" + txt1.Text + "Already Exists !");

                    search24();


                    if (txtBarcode.Text.Trim() == txtchecking24.Text.Trim())
                    {
                        //MessageBox.Show("Proceed Match Code");

                    }
                    else
                    {
                        //MessageBox.Show("Repak ID Not Match!, Choose the exactly item Thanks !");
                        RepackIDNotMatched();
                        txtchecking24.Text = "";
                        txtchecking24.Select();
                        txtchecking24.Focus();
                        return;
                    }


                    txtrepcom24.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();



                    txtchecking24.BackColor = Color.LightGreen;
                    pictureBox49.Visible = true;
                    //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
                    txtchecking25.Focus();
                    txtchecking25.Select();
                    CountNumber();
                    txtchecking24.Visible = true;







                    //return;
                }
                else
                {
                    //MessageBox.Show("The Repacking Selected" + txtchecking24.Text + " IS Not Exists !!");
                    RepackIdNotExists();
                    txtchecking24.BackColor = Color.Yellow;
                    txtchecking24.Text = "";
                    txtchecking24.Select();
                    txtchecking24.Focus();
                    return;
                    //return; // ang gulo ntyo mga bugok
                }








            }
        }

        private void buton25_Click(object sender, EventArgs e)
        {




            if (txtchecking24.Text.Trim() == string.Empty)
            {

                //MessageBox.Show("Part 25", "Barcode Input Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BarcodeNotFound();
                txtchecking25.Select();
                txtchecking25.Focus();
                txtchecking25.BackColor = Color.Yellow;


                return;
            }
            else
            {

                //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
                String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
                SqlConnection sql_con = new SqlConnection(connetionString);

                cmd = new SqlCommand("SELECT string_id FROM [dbo].[rdf_repackin_entry]  WHERE string_id='" + txtchecking25.Text + "'", sql_con);

                SqlDataAdapter daks = new SqlDataAdapter(cmd);

                daks.Fill(ds);
                int ia = ds.Tables[0].Rows.Count;
                if (ia > 0)
                {
                    //MessageBox.Show("The Formula" + txt1.Text + "Already Exists !");

                    search25();


                    if (txtBarcode.Text.Trim() == txtchecking25.Text.Trim())
                    {
                        //MessageBox.Show("Proceed Match Code");

                    }
                    else
                    {
                        //MessageBox.Show("Repak ID Not Match!, Choose the exactly item Thanks !");
                        RepackIDNotMatched();
                        txtchecking25.Text = "";
                        txtchecking25.Select();
                        txtchecking25.Focus();
                        return;
                    }


                    txtrepcom25.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();

                    txtchecking25.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();

                    txtchecking25.BackColor = Color.LightGreen;
                    pictureBox50.Visible = true;

                    lblbatch.CurrentCell = lblbatch.Rows[i].Cells[0];

                    CountNumber();
                    txtchecking25.Visible = true;
                    ds.Clear();







                    //return;
                }
                else
                {
                    //MessageBox.Show("The Repacking Selected" + txtchecking25.Text + " IS Not Exists !!");
                    RepackIdNotExists();
                    txtchecking25.BackColor = Color.Yellow;
                    txtchecking25.Text = "";
                    txtchecking25.Select();
                    txtchecking25.Focus();
                    return;
                    //return; // ang gulo ntyo mga bugok
                }










            }
        }

        private void txtchecking19_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buton19_Click(sender, e);
            }
        }

        private void txtchecking20_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buton20_Click(sender, e);
            }
        }

        private void txtchecking21_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buton21_Click(sender, e);
            }
        }

        private void txtchecking22_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buton22_Click(sender, e);
            }
        }

        private void txtchecking23_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buton23_Click(sender, e);
            }
        }

        private void txtchecking24_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buton24_Click(sender, e);
            }
        }

        private void txtchecking25_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buton25_Click(sender, e);
            }
        }

        private void txtchecking16_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void txtactual50_TextChanged(object sender, EventArgs e)
        {

        }


        private void txtactual1_TextChanged(object sender, EventArgs e)
        {

        }
        private void dgvCount_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgvCount.RowCount > 0)
            {
                if (dgvCount.CurrentRow != null)
                {
                    if (dgvCount.CurrentRow.Cells["Column1"].Value != null)
                    {
                        //p_id = Convert.ToInt32(dgvMaster.CurrentRow.Cells["prod_id"].Value);


                        lbltotalmicro.Text = dgvCount.CurrentRow.Cells["Column1"].Value.ToString();






                        //txtrecommendedsearch.Text = dgvMaster.CurrentRow.Cells["item_code"].Value.ToString();
                        //txtqtyoverall.Text = dgvMaster.CurrentRow.Cells["qty_repack_available"].Value.ToString();
                        //txtmainstocks.Text = dgvMaster.CurrentRow.Cells["total_quantity_raw"].Value.ToString();

                        //cboCategor.Text = dgvMaster.CurrentRow.Cells["item_description"].Value.ToString();






                        //wala muna this


                    }

                }
                lblnumplusone.Text = (float.Parse(lbltotalmicro.Text) + 1).ToString();
            }


        }

        private void bunifuMinimized_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

            if (MetroFramework.MetroMessageBox.Show(this, "Data will not be save, are you sure to Exit? ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {

                return;
            }
        }

        private void bunifuStart_Click(object sender, EventArgs e)
        {
            metroButton1_Click(sender, e);
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblbatch_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void lblbatch_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void dgvMaster_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //var grid = sender as DataGridView;
            //var rowIdx = (e.RowIndex + 2).ToString();

            //var centerFormat = new StringFormat()
            //{
            //    // right alignment might actually make more sense for numbers
            //    Alignment = StringAlignment.Center,
            //    LineAlignment = StringAlignment.Center
            //};

            //var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            //e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void dgvMaster_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {

        }

        private void txtchecking21_TextChanged(object sender, EventArgs e)
        {


        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {

        }

        private void txtchecking1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtchecking2_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtchecking3_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtchecking4_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtchecking5_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnScan_Click(object sender, EventArgs e)
        {


            





            if (txtBarcode.Text.Trim() == txtchecking1.Text.Trim())
            {
                if (txtchecking1.Visible == true)
                {
                    txtBarcode.Text = "";
                    NaPreparedNa();
        
                        txtBarcode.Focus();
                    txtBarcode.Select();
                    return;
                }
                else
                {

                }




                butun1_Click_1(sender, e);

                txtBarcode.Text = "";
                txtBarcode.Focus();
                txtBarcode.Select();


            }
            else if (txtBarcode.Text == txtchecking2.Text)

            {
                if (txtchecking2.Visible == true)
                {
                    txtBarcode.Text = "";
                    NaPreparedNa();
                    txtBarcode.Focus();
                    txtBarcode.Select();
                    return;
                }
                else
                {

                }



                butun2_Click_1(sender, e);
                txtBarcode.Text = "";
                txtBarcode.Focus();
                txtBarcode.Select();

            }
            else if (txtBarcode.Text == txtchecking3.Text)

            {
                if (txtchecking3.Visible == true)
                {
                    txtBarcode.Text = "";
                    NaPreparedNa();
                    txtBarcode.Focus();
                    txtBarcode.Select();
                    return;
                }
                else
                {

                }



                butun3_Click_1(sender, e);
                txtBarcode.Text = "";
                txtBarcode.Focus();
                txtBarcode.Select();

            }
            else if (txtBarcode.Text == txtchecking4.Text)

            {
                if (txtchecking4.Visible == true)
                {
                    txtBarcode.Text = "";
                    NaPreparedNa();
                    txtBarcode.Focus();
                    txtBarcode.Select();
                    return;
                }
                else
                {

                }


                butun4_Click_1(sender, e);
                txtBarcode.Text = "";
                txtBarcode.Focus();
                txtBarcode.Select();
            }
            else if (txtBarcode.Text == txtchecking5.Text)

            {
                if (txtchecking5.Visible == true)
                {
                    txtBarcode.Text = "";
                    NaPreparedNa();
                    txtBarcode.Focus();
                    txtBarcode.Select();
                    return;
                }
                else
                {

                }


                butun5_Click_1(sender, e);
                txtBarcode.Text = "";
                txtBarcode.Focus();
                txtBarcode.Select();

            }
            else if (txtBarcode.Text == txtchecking6.Text)

            {
                if (txtchecking6.Visible == true)
                {
                    txtBarcode.Text = "";
                    NaPreparedNa();
                    txtBarcode.Focus();
                    txtBarcode.Select();
                    return;
                }
                else
                {

                }




                butun6_Click_1(sender, e);
                txtBarcode.Text = "";
                txtBarcode.Focus();
                txtBarcode.Select();

            }
            else if (txtBarcode.Text == txtchecking7.Text)

            {
                if (txtchecking7.Visible == true)
                {
                    txtBarcode.Text = "";
                    NaPreparedNa();
                    txtBarcode.Focus();
                    txtBarcode.Select();
                    return;
                }
                else
                {

                }


                butun7_Click_1(sender, e);
                txtBarcode.Text = "";
                txtBarcode.Focus();
                txtBarcode.Select();
            }
            else if (txtBarcode.Text == txtchecking8.Text)

            {

                if (txtchecking8.Visible == true)
                {
                    txtBarcode.Text = "";
                    NaPreparedNa();
                    txtBarcode.Focus();
                    txtBarcode.Select();
                    return;
                }
                else
                {

                }




                butun8_Click(sender, e);
                txtBarcode.Text = "";
                txtBarcode.Focus();
                txtBarcode.Select();

            }
            else if (txtBarcode.Text == txtchecking9.Text)

            {

                if (txtchecking9.Visible == true)
                {
                    txtBarcode.Text = "";
                    NaPreparedNa();
                    txtBarcode.Focus();
                    txtBarcode.Select();
                    return;
                }
                else
                {

                }







                buton9_Click(sender, e);
                txtBarcode.Text = "";
                txtBarcode.Focus();
                txtBarcode.Select();

            }
            else if (txtBarcode.Text == txtchecking10.Text)

            {
                if (txtchecking10.Visible == true)
                {
                    txtBarcode.Text = "";
                    NaPreparedNa();
                    txtBarcode.Focus();
                    txtBarcode.Select();
                    return;
                }
                else
                {

                }


                buton10_Click(sender, e);
                txtBarcode.Text = "";
                txtBarcode.Focus();
                txtBarcode.Select();
            }
            else if (txtBarcode.Text == txtchecking11.Text)

            {
                if (txtchecking11.Visible == true)
                {
                    txtBarcode.Text = "";
                    NaPreparedNa();
                    txtBarcode.Focus();
                    txtBarcode.Select();
                    return;

                }
                else
                {

                }


                buton11_Click(sender, e);
                txtBarcode.Text = "";
                txtBarcode.Focus();
                txtBarcode.Select();

            }
            else if (txtBarcode.Text == txtchecking12.Text)

            {
                if (txtchecking12.Visible == true)
                {
                    txtBarcode.Text = "";
                    NaPreparedNa();
                    txtBarcode.Focus();
                    txtBarcode.Select();
                    return;
                }
                else
                {

                }

                buton12_Click(sender, e);
                txtBarcode.Text = "";
                txtBarcode.Focus();
                txtBarcode.Select();

            }
            else if (txtBarcode.Text == txtchecking13.Text)

            {
                if (txtchecking13.Visible == true)
                {
                    txtBarcode.Text = "";
                    NaPreparedNa();
                    txtBarcode.Focus();
                    txtBarcode.Select();
                    return;

                }
                else
                {

                }


                buton13_Click(sender, e);
                txtBarcode.Text = "";
                txtBarcode.Focus();
                txtBarcode.Select();

            }
            else if (txtBarcode.Text == txtchecking14.Text)

            {
                if (txtchecking14.Visible == true)
                {
                    txtBarcode.Text = "";
                    NaPreparedNa();
                    txtBarcode.Focus();
                    txtBarcode.Select();
                    return;
                }
                else
                {

                }


                buton14_Click(sender, e);
                txtBarcode.Text = "";
                txtBarcode.Focus();
                txtBarcode.Select();

            }
            else if (txtBarcode.Text == txtchecking15.Text)

            {
                if (txtchecking15.Visible == true)
                {
                    txtBarcode.Text = "";
                    NaPreparedNa();
                    txtBarcode.Focus();
                    txtBarcode.Select();
                    return;
                }
                else
                {

                }



                buton15_Click(sender, e);
                txtBarcode.Text = "";
                txtBarcode.Focus();
                txtBarcode.Select();

            }
            else if (txtBarcode.Text == txtchecking16.Text)

            {

                if (txtchecking16.Visible == true)
                {
                    txtBarcode.Text = "";
                    NaPreparedNa();
                    txtBarcode.Focus();
                    txtBarcode.Select();
                    return;
                }
                else
                {

                }


                buton16_Click(sender, e);
                txtBarcode.Text = "";
                txtBarcode.Focus();
                txtBarcode.Select();

            }
            else if (txtBarcode.Text == txtchecking17.Text)

            {
                if (txtchecking17.Visible == true)
                {
                    txtBarcode.Text = "";
                    NaPreparedNa();
                    txtBarcode.Focus();
                    txtBarcode.Select();
                    return;
                }
                else
                {

                }



                buton17_Click(sender, e);
                txtBarcode.Text = "";
                txtBarcode.Focus();
                txtBarcode.Select();

            }

            else if (txtBarcode.Text == txtchecking18.Text)

            {
                if (txtchecking18.Visible == true)
                {
                    txtBarcode.Text = "";
                    NaPreparedNa();
                    txtBarcode.Focus();
                    txtBarcode.Select();
                    return;
                }
                else
                {

                }


                buton18_Click(sender, e);
                txtBarcode.Text = "";
                txtBarcode.Focus();
                txtBarcode.Select();

            }

            else if (txtBarcode.Text == txtchecking19.Text)

            {
                if (txtchecking19.Visible == true)
                {
                    txtBarcode.Text = "";
                    NaPreparedNa();
                    txtBarcode.Focus();
                    txtBarcode.Select();
                    return;
                }
                else
                {

                }


                buton19_Click(sender, e);
                txtBarcode.Text = "";
                txtBarcode.Focus();
                txtBarcode.Select();

            }

            else if (txtBarcode.Text == txtchecking20.Text)

            {
                if (txtchecking20.Visible == true)
                {
                    txtBarcode.Text = "";
                    NaPreparedNa();
                    txtBarcode.Focus();
                    txtBarcode.Select();
                    return;
                }
                else
                {

                }

                buton20_Click(sender, e);
                txtBarcode.Text = "";
                txtBarcode.Focus();
                txtBarcode.Select();

            }

            else if (txtBarcode.Text == txtchecking21.Text)

            {
                if (txtchecking21.Visible == true)
                {
                    txtBarcode.Text = "";
                    NaPreparedNa();
                    txtBarcode.Focus();
                    txtBarcode.Select();
                    return;
                }
                else
                {

                }


                buton21_Click(sender, e);
                txtBarcode.Text = "";
                txtBarcode.Focus();
                txtBarcode.Select();

            }

            else if (txtBarcode.Text == txtchecking22.Text)

            {
                if (txtchecking22.Visible == true)
                {
                    txtBarcode.Text = "";
                    NaPreparedNa();
                    txtBarcode.Focus();
                    txtBarcode.Select();
                    return;
                }
                else
                {

                }

                buton22_Click(sender, e);
                txtBarcode.Text = "";
                txtBarcode.Focus();
                txtBarcode.Select();

            }

            else if (txtBarcode.Text == txtchecking23.Text)

            {
                if (txtchecking23.Visible == true)
                {
                    txtBarcode.Text = "";
                    NaPreparedNa();
                    txtBarcode.Focus();
                    txtBarcode.Select();
                    return;
                }
                else
                {

                }


                buton23_Click(sender, e);
                txtBarcode.Text = "";
                txtBarcode.Focus();
                txtBarcode.Select();

            }
            else if (txtBarcode.Text == txtchecking24.Text)

            {
                if (txtchecking24.Visible == true)
                {
                    txtBarcode.Text = "";
                    NaPreparedNa();
                    txtBarcode.Focus();
                    txtBarcode.Select();
                    return;
                }
                else
                {

                }

                buton24_Click(sender, e);
                txtBarcode.Text = "";
                txtBarcode.Focus();
                txtBarcode.Select();

            }

            else if (txtBarcode.Text == txtchecking25.Text)

            {
                if (txtchecking25.Visible == true)
                {
                    txtBarcode.Text = "";
                    NaPreparedNa();
                    txtBarcode.Focus();
                    txtBarcode.Select();
                    return;
                }
                else
                {

                }


                buton25_Click(sender, e);
                txtBarcode.Text = "";
                txtBarcode.Focus();
                txtBarcode.Select();

            }







            else
            {
                RepackIdNotExists();
                txtBarcode.Text = "";
                txtBarcode.Focus();


            }




        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnScan_Click(sender, e);
                if (lbltotalread.Text=="1")
                {
                    startbmx();

                }
            }
        }

        void NextProcedure()
        {

            if (lblbatch.Rows.Count >= 1)
            {


                int i = lblbatch.CurrentRow.Index + 1;
                if (i >= -1 && i < lblbatch.Rows.Count)
                    lblbatch.CurrentCell = lblbatch.Rows[i].Cells[1];




                //dgvMaster_Click(sender,e);
                else
                {
                    //LastLine();
                    //MessageBox.Show("Last Line");

                    lblbatch.CurrentCell = lblbatch.Rows[0].Cells[0];
                    return;
                }
            }
        }


        private void btnlessthan_Click(object sender, EventArgs e)
        {
            if (txtchecking1.Text.Trim() == string.Empty)
            {
                txtchecking1.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();

                NextProcedure();
                lblcounter.Text = "1";
                if (lblCounts.Text == lblcounter.Text)
                {
                    return;
                }



            }





            if (txtchecking2.Text.Trim() == string.Empty)
            {

                txtchecking2.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();

                NextProcedure();

                lblcounter.Text = "2";
                if (lblCounts.Text == lblcounter.Text)
                {
                    return;
                }
            }
            if (txtchecking3.Text.Trim() == string.Empty)
            {

                txtchecking3.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();

                NextProcedure();

                lblcounter.Text = "3";
                if (lblCounts.Text == lblcounter.Text)
                {
                    return;
                }
            }
            if (txtchecking4.Text.Trim() == string.Empty)
            {

                txtchecking4.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();

                NextProcedure();

                lblcounter.Text = "4";
                if (lblCounts.Text == lblcounter.Text)
                {
                    return;
                }
            }
            if (txtchecking5.Text.Trim() == string.Empty)
            {

                txtchecking5.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();

                NextProcedure();

                lblcounter.Text = "5";
                if (lblCounts.Text == lblcounter.Text)
                {
                    return;
                }
            }
            if (txtchecking6.Text.Trim() == string.Empty)
            {

                txtchecking6.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();

                NextProcedure();

                lblcounter.Text = "6";
                if (lblCounts.Text == lblcounter.Text)
                {
                    return;
                }
            }
            if (txtchecking7.Text.Trim() == string.Empty)
            {

                txtchecking7.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();


                NextProcedure();
                lblcounter.Text = "7";
                if (lblCounts.Text == lblcounter.Text)
                {
                    return;
                }
            }
            if (txtchecking8.Text.Trim() == string.Empty)
            {

                txtchecking8.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();


                NextProcedure();
                lblcounter.Text = "8";
                if (lblCounts.Text == lblcounter.Text)
                {
                    return;
                }
            }
            if (txtchecking9.Text.Trim() == string.Empty)
            {

                txtchecking9.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();

                NextProcedure();
                lblcounter.Text = "9";
                if (lblCounts.Text == lblcounter.Text)
                {
                    return;
                }
            }
            if (txtchecking10.Text.Trim() == string.Empty)
            {

                txtchecking10.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();

                NextProcedure();
                lblcounter.Text = "10";
                if (lblCounts.Text == lblcounter.Text)
                {
                    return;
                }
            }
            if (txtchecking11.Text.Trim() == string.Empty)
            {

                txtchecking11.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();

                NextProcedure();

                lblcounter.Text = "11";
                if (lblCounts.Text == lblcounter.Text)
                {
                    return;
                }
            }
            if (txtchecking12.Text.Trim() == string.Empty)
            {

                txtchecking12.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();


                NextProcedure();
                lblcounter.Text = "12";
                if (lblCounts.Text == lblcounter.Text)
                {
                    return;
                }
            }
            if (txtchecking13.Text.Trim() == string.Empty)
            {

                txtchecking13.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();

                NextProcedure();

                lblcounter.Text = "13";
                if (lblCounts.Text == lblcounter.Text)
                {
                    return;
                }
            }
            if (txtchecking14.Text.Trim() == string.Empty)
            {

                txtchecking14.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();

                NextProcedure();

                lblcounter.Text = "14";
                if (lblCounts.Text == lblcounter.Text)
                {
                    return;
                }
            }
            if (txtchecking15.Text.Trim() == string.Empty)
            {

                txtchecking15.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();

                NextProcedure();

                lblcounter.Text = "15";
                if (lblCounts.Text == lblcounter.Text)
                {
                    return;
                }
            }
            if (txtchecking16.Text.Trim() == string.Empty)
            {

                txtchecking16.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();


                NextProcedure();
                lblcounter.Text = "16";
                if (lblCounts.Text == lblcounter.Text)
                {
                    return;
                }
            }
            if (txtchecking17.Text.Trim() == string.Empty)
            {

                txtchecking17.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();

                NextProcedure();

                lblcounter.Text = "17";
                if (lblCounts.Text == lblcounter.Text)
                {
                    return;
                }
            }
            if (txtchecking18.Text.Trim() == string.Empty)
            {

                txtchecking18.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();


                NextProcedure();
                lblcounter.Text = "18";
                if (lblCounts.Text == lblcounter.Text)
                {
                    return;
                }
            }
            if (txtchecking19.Text.Trim() == string.Empty)
            {

                txtchecking19.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();


                NextProcedure();
                lblcounter.Text = "19";
                if (lblCounts.Text == lblcounter.Text)
                {
                    return;
                }
            }
            if (txtchecking20.Text.Trim() == string.Empty)
            {

                txtchecking20.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();

                NextProcedure();

                lblcounter.Text = "20";
                if (lblCounts.Text == lblcounter.Text)
                {
                    return;
                }
            }
            if (txtchecking21.Text.Trim() == string.Empty)
            {

                txtchecking21.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();


                NextProcedure();
                lblcounter.Text = "21";
                if (lblCounts.Text == lblcounter.Text)
                {
                    return;
                }
            }
            if (txtchecking22.Text.Trim() == string.Empty)
            {

                txtchecking22.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();


                NextProcedure();
                lblcounter.Text = "22";
                if (lblCounts.Text == lblcounter.Text)
                {
                    return;
                }
            }
            if (txtchecking23.Text.Trim() == string.Empty)
            {

                txtchecking23.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();

                NextProcedure();
                lblcounter.Text = "23";
                if (lblCounts.Text == lblcounter.Text)
                {
                    return;
                }
            }
            if (txtchecking24.Text.Trim() == string.Empty)
            {

                txtchecking24.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();

                NextProcedure();

                lblcounter.Text = "24";
                if (lblCounts.Text == lblcounter.Text)
                {
                    return;
                }
            }
            if (txtchecking25.Text.Trim() == string.Empty)
            {

                txtchecking25.Text = lblbatch.CurrentRow.Cells["rep_id"].Value.ToString();

                NextProcedure();

                lblcounter.Text = "25";
                if (lblCounts.Text == lblcounter.Text)
                {
                    return;
                }
            }



        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtqty50_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblcounter_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Start();
            if(txtluffy.Text=="0")
            {

                load_Schedules();

            }
            else
            {


                txtluffy.Visible = true;
                dgvMaster.Visible = true;
                label1.Visible = true;
                label5.Visible = true;
                lblbatch.Visible = true;
                label63.Visible = true;
                lblCounts.Visible = true;
                lblCountss.Visible = true;
                label64.Visible = true;
                label65.Visible = true;
                lblkg.Visible = true;
                label74.Visible = true;
                lbllost.Visible = true;
                label8.Visible = true;

























                timer2.Stop();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtactual1.Focus();
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
                return;
            }
        }

        private void btnReprint_Click(object sender, EventArgs e)
        {
            metroReprint_Click(sender, e);
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
        private void btnValidate_Click(object sender, EventArgs e)
        {
            if (txtControlNumber.Text.Trim() == string.Empty)
            {
                FillEmptyFields();
                txtControlNumber.Focus();
                return;
            }

            if (txtControlNumber.Text == "787898")
            {
                panelCode.Visible = false;
                storedProcCntrNumber();
                txtControlNumber.Text = "";
                //button2_Click_1(sender, e);

                button65_Click(sender, e);//Printing
                timer1.Start();
                timer1_Tick(sender, e);
                btnReprint.Visible = false;
                //txtweighingscale.Focus();

            }
            else if (txtControlNumber.Text == "787899")
            {
                panelCode.Visible = false;
                storedProcCntrNumber();
                txtControlNumber.Text = "";
                //button2_Click_1(sender, e);

                button65_Click(sender, e);//Printing
                timer1.Start();
                timer1_Tick(sender, e);
                btnReprint.Visible = false;

            }
            else if (txtControlNumber.Text == "787420")
            {

                panelCode.Visible = false;
                storedProcCntrNumber();
                txtControlNumber.Text = "";
                //button2_Click_1(sender, e);

                button65_Click(sender, e);//Printing
                timer1.Start();
                timer1_Tick(sender, e);
                btnReprint.Visible = false;


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

            dSet = objStorProc.rdf_sp_new_preparation(0, "Reprint Micro Basemixed", txtControlNumber.Text, "MICRO BASEMIXED", txtaddedby.Text, txtdatenowstamp.Text, "", "", "", "", "", "", "", "", "", "", "", "", "addcontrolnumberlogs");

        }

        private void txtControlNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               btnValidate_Click(sender, e);
            }
        }

        private void dgvMaster_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                e.Value = e.Value.ToString().ToUpper();
                e.FormattingApplied = true;
            }
        }

        private void metroSavePrinting_Click(object sender, EventArgs e)
        {


            if (MetroFramework.MetroMessageBox.Show(this, $"Save the basemixed   { lblbatchcount.Text}  AND { lblbatchcount.Text} ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {


            }

            else

            {

                return;
            }




















        }

        private void lblCountss_Click(object sender, EventArgs e)
        {



        }

        private void lblCountss_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblbatchcount_TextChanged(object sender, EventArgs e)
        {
            try
            {


                lblvalidate.Text = (float.Parse(lblbatchcount.Text) + 1).ToString();
            }
            catch (Exception)
            {


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

                        txtstartmacrorepacking.Text = dgvUpdateTimeLampse.CurrentRow.Cells["start_of_basemixed"].Value.ToString();

                    }

                }
            }

            txtdatenowstamp.Text = DateTime.Now.ToString();

            //if (lblcountfg.Text == "0")
            //{

            //}
            //else
            //{
            //    DateTime time1 = DateTime.Parse(txtstartmacrorepacking.Text);
            //    DateTime time2 = DateTime.Parse(txtdatenowstamp.Text);

            //    TimeSpan difference = time1 - time2;



            //    txtSumofRepacking.Text = Convert.ToString(difference);

            //}
            //version 2
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            button65_Click(sender, e);
        }

        private void lbllost_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
