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
using System.Data.OleDb;
using System.Runtime.InteropServices;
using System.Threading;
using System.Drawing.Imaging;
using System.Collections;
using System.IO;
using System.Activities.Expressions;
using Tulpep.NotificationWindow;
using System.Drawing.Drawing2D;

//using MetroFramework;

namespace WFFDR
{
    public partial class frmmicroreceivingentry : Form
    {


        System.Media.SoundPlayer player = new System.Media.SoundPlayer();

        //     private static readonly DailyTimeRecordsRepository DailyTimeRecordsRepository = new DailyTimeRecordsRepository();
        //DataTable dt;
        DataSet ds = new DataSet();

        string constr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\xx\Fedoramain_offline.accdb; Persist Security Info=False;";
        OleDbConnection oc = new OleDbConnection();

   /*     String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI"*/
    String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
        //  String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true;Connection Timeout=1";
        //String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true";
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();

        SqlCommand cmd1 = new SqlCommand();
        OleDbCommand cmd_off = new OleDbCommand();
        OleDbDataReader dr_off;
        SqlDataReader dr; SqlDataReader dr12;
        //bool activateTheme = false; int themeCount = 0;
        DataTable dtPrev = new DataTable();
        DataRow dRow;
        IStoredProcedures objStorProc = null;

        DataSet dSet_temp = new DataSet();
        DataSet dset_emp = new DataSet();
        myclasses xClass = new myclasses();
        DataSet dsImage = new DataSet();
        public Byte[] imageByte = null;
        Boolean move = false;
        string hld = "", ti = "", lo = "", li = "", to = "";
        int id = 0;
        int p_id = 0;
        int ctr = 0/*, ctr2 = 0, roundtrip = 0*/;
        string /*quarter, year, */prevId;
        //string prev1 = "", prev2 = "";
        string empNamexX;
        Boolean hw_on = false;

        TimeSpan start = TimeSpan.Parse("07:00:00"); // 10 PM
                                                     //TimeSpan end = TimeSpan.Parse("07:39:59"); // 2am
        TimeSpan endhw = TimeSpan.Parse("07:20:59"); // 2am
        DateTime now = DateTime.Now;
        TimeSpan currenttime;
        string currentdate;
        Boolean success = false;
        Boolean sw = false;
        string ttime = "";


        string sample = "";

        //start of expiration declaration
        string expired1 = "";
        string expired2 = "";
        string expired3 = "";
        string expired4 = "";


        //end
        int idx = 0;
        int dtr_type = 0;
        string errorempnum;
        string mode = ""; //mymode

        Boolean ready = false;
        DataSet dSet = new DataSet();
        DataSet dSets = new DataSet();
        myglobal pointer_module = new myglobal();

        Boolean lodi = false; //image
        DataSet dsetHeader = new DataSet();

        frmProfileMicroPrev micropreviews;

        public string str;



        //    DateTime date1 = new DateTime(12, 25, 2019);
        // DateTime date2 = dateTimePicker1.Value as DateTime;
        IStoredProcedures g_objStoredProcCollection = null; //image

        //string msg;
        //private int EmployeeId { get; set; }




        public frmmicroreceivingentry()
        {
            InitializeComponent();


        }

        
        private void frmmicroreceivingentry_Load(object sender, EventArgs e)
        {
            lstvEmployee.Visible = false;

            HideQA();
            HideWh();
            txtPrimaryKey.Visible = false;

            //this.WindowState = FormWindowState.Maximized;
            //the dashboard count
            txtreceivedby.Text = userinfo.emp_name.ToUpper();

            //load macro counts
            load_macro_count();
            txtactual_receiving.Text = "0";

            DisableViewingMicro();

            DisableMainGroupBox();
            groupBox7.Visible = false;
            //forms
            micropreviews = new frmProfileMicroPrev();
            DateTime dt = DateTime.Now;
            textBox2.Text = dt.ToString("MM/dd/yyyy");

            dateTimePicker2.Value = DateTime.Now;

            loadMicro_Entry();
            txtMainInput.Focus();
            txtMainInput.Select();
            //  pictureBox1.Image = Image.FromFile(@"C:\pics\" + @"\Employee.png");
            //  @"C:\Users\bobo\idiot_is_calling.wav
            this.TopMost = true;
            loadSupplier();
            //gegemuna  txtAddedBy.Text = userinfo.emp_name.ToUpper();

            TimeSpan start = TimeSpan.Parse("07:00"); // 10 PM
            TimeSpan end = TimeSpan.Parse("07:20:59"); // 2am
            DateTime now = DateTime.Now;
            TimeSpan currenttime = TimeSpan.Parse(now.ToString("HH:mm:ss"));
            objStorProc = xClass.g_objStoredProc.GetCollections();


            frmMenu Menu = new frmMenu();


            forDisable();

            timer1.Start();
            timer2.Start();



        
            set_dg();
            myglobal.global_module = "MicroReceiving";

            load_search();


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

            if (myglobal.global_module == "EMPLOYEE")
            { dset_emp = objStorProc.sp_getMajorTables("employee"); }
            else if (myglobal.global_module == "MICRO")
            { dset_emp = objStorProc.sp_getMajorTables("micro_raw_materialsnew"); }
            else if (myglobal.global_module == "MicroReceiving")
            { dset_emp = objStorProc.sp_getMajorTables("viewmicroreceiving"); }
            else if (myglobal.global_module == "InActive")
            { dset_emp = objStorProc.sp_getMajorTables("InactiveFeedCode"); }
            else if (myglobal.global_module == "MACRO")
            { dset_emp = objStorProc.sp_getMajorTables("macro_raw_materialsnew"); }
            else if (myglobal.global_module == "RESIGNED EMPLOYEE")
            { dset_emp = objStorProc.sp_getMajorTables("employee_B"); }
            else if (myglobal.global_module == "PHONEBOOK")
            { dset_emp = objStorProc.sp_getMajorTables("phonebook"); }
            else if (myglobal.global_module == "DA")
            { dset_emp = objStorProc.sp_getMajorTables("get_da"); }
            else if (myglobal.global_module == "ATTENDANCE")
            { dset_emp = objStorProc.sp_getMajorTables("attendance_monitoring"); }
            else if (myglobal.global_module == "VISITORS")
            { dset_emp = objStorProc.sp_getMajorTables("visitors"); }
            doSearch();

        }


        void HideWh()
        {
            label48.Visible = false;
            bunifuwh.Visible = false;
            bunifuThinButton21.Visible = false;
            radKilo.Visible = false;
            label45.Visible = false;
            label39.Visible = false;
            bunifuThinButton27.Visible = false;
            txtPrimaryKey.Visible = false;
            label29.Visible = false;
            bunifuThinButton22.Visible = false;
            txtActualStocks.Visible = false;
            txtrepackavailable.Visible = false;
            bunifuThinButton26.Visible = false;
            label22.Visible = false;
            txtUpdatedStock.Visible = false;
            txtUpdatedStock2.Visible = false;
            bunifuThinButton23.Visible = false;
            label42.Visible = false;
            txtgood.Visible = false;
            label41.Visible = false;
            txtreject.Visible = false;
            bunifuThinButton24.Visible = false;
            label72.Visible = false;
        }
        void HideQA()
        {
            bunifuThinButton28.Visible = false;
            label60.Visible = false;
            label70.Visible = false;
            label71.Visible = false;
            bunifuThinButton29.Visible = false;
            txtqtydelivered.Visible = false;
            label44.Visible = false;
            txtqtygood.Visible = false;
            bunifuThinButton210.Visible = false;
        }
        void ShowQA()

        {
            bunifuThinButton28.Visible = true;
            label60.Visible = true;
            label70.Visible = true;
            label71.Visible = true;
            bunifuThinButton29.Visible = true;
            txtqtydelivered.Visible = true;
            label44.Visible = true;
            txtqtygood.Visible = true;
            bunifuThinButton210.Visible = true;
        }
        void ShowWh()
        {
            label72.Visible = true;
            label48.Visible = true;
            bunifuwh.Visible = true;
            bunifuThinButton21.Visible = true;
            radKilo.Visible = true;
            label45.Visible = true;
            label39.Visible = true;
            bunifuThinButton27.Visible = true;
            txtPrimaryKey.Visible = true;
            label29.Visible = true;
            bunifuThinButton22.Visible = true;
            txtActualStocks.Visible = true;
            txtrepackavailable.Visible = true;
            bunifuThinButton26.Visible = true;
            label22.Visible = true;
            txtUpdatedStock.Visible = true;
            txtUpdatedStock2.Visible = true;
            bunifuThinButton23.Visible = true;
            label42.Visible = true;
            txtgood.Visible = true;
            label41.Visible = true;
            txtreject.Visible = true;
            bunifuThinButton24.Visible = true;
        }


        public void load_macro_count()
        {
            string mcolumns = "item_code";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgv_macro_count, mcolumns, "macro_counter");
            // Menu.lblrecords.Text = dgv_table.RowCount.ToString();

            //     poreceived_header();
        }






        void forDisable()
        {
            groupBox3.Visible = false;
            //   groupBoxinfo.Visible = false;

            txtItemDescription.Enabled = false;
            //txtID.Enabled = false;
            //cboCategory.Enabled = false;
            //txtItemCode.Enabled = false;
            cboclassification.Enabled = false;
            //txtQuantity.Visible = false;
            txtQuantity2.Visible = false;
            //    btnSubmit.Visible = false;
            txtqtyproduction.Visible = false;
            txtfinalproductionplanner.Visible = false;

        }
        void set_dg()
        {
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.Width = 110;
            }
        }


        public void loadSupplier()
        {
            ready = false;

            xClass.fillComboBox(cboSupplier, "my_supplier_rdf", dSet);
            // displayData(Convert.ToInt32(cboDepartment.SelectedValue.ToString()));

            ready = true;

        }
        private void txtMainInput_Leave(object sender, EventArgs e)
        {
            // this.Activate();
            //this.TopMost = true;
            // txtMainInput.Focus();
            // txtMainInput.Select();

            if (txtMainInput.Focused == true)
            {
                this.Activate();
                this.TopMost = true;
                txtMainInput.Focus();
                txtMainInput.Select();

            }
        }

        private void insert_ti(int id, string date, string time, string exp1)
        {
            string exp11 = txtxp.Text;
            mode = "insTimeIn";
            con_on();
            SqlCommand cmd = new SqlCommand("rdf_sp_TimeKeeper", con);
            cmd.Parameters.AddWithValue("@mode", mode);
            cmd.Parameters.AddWithValue("@empid", id);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@dtrTime", time);
            cmd.Parameters.AddWithValue("@exp1", exp1);
            //    cmd.Parameters.AddWithValue("exp1",Value = textBox4.Text);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.ExecuteNonQuery();
            con.Close();

        }

        public void gerard()
        {

            dSet = objStorProc.rdf_sp_TimeKeeper(0, textBox1.Text, textBox1.Text, textBox1.Text, "intTimeIn");
            /*
            int id=0;
                string date="";
                string time="";
                string exp1="";
            string mode="";

            mode = "insTimeIn";
            con_on();
            SqlCommand cmd = new SqlCommand("rdf_sp_TimeKeeper", con);
            cmd.Parameters.AddWithValue("@mode", mode);
            cmd.Parameters.AddWithValue("@empid", id);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@dtrTime", time);
            cmd.Parameters.AddWithValue("@exp1", textBox1.Text);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.ExecuteNonQuery();
            con.Close();
            */
        }

        private void update_li(int id, string date, string time, int dtrid, string exp3)
        {
            mode = "updLunchIn";
            con_on();
            SqlCommand cmd = new SqlCommand("rdf_sp_TimeKeeper", con);
            cmd.Parameters.AddWithValue("@mode", mode);
            cmd.Parameters.AddWithValue("@empid", id);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@dtrTime", time);
            cmd.Parameters.AddWithValue("@dtrID", dtrid);
            cmd.Parameters.AddWithValue("@exp3", exp3);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void update_to(int id, string date, string time, int dtrid, string exp4)
        {
            mode = "updTimeOut";
            con_on();
            SqlCommand cmd = new SqlCommand("rdf_sp_TimeKeeper", con);
            cmd.Parameters.AddWithValue("@mode", mode);
            cmd.Parameters.AddWithValue("@empid", id);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@dtrTime", time);
            cmd.Parameters.AddWithValue("@dtrID", dtrid);
            cmd.Parameters.AddWithValue("@exp4", exp4);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void update_entry5(int id, string date, string time, int dtrid)
        {
            mode = "updEntryFive";
            con_on();
            SqlCommand cmd = new SqlCommand("rdf_sp_TimeKeeper", con);
            cmd.Parameters.AddWithValue("@mode", mode);
            cmd.Parameters.AddWithValue("@empid", id);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@dtrTime", time);
            cmd.Parameters.AddWithValue("@dtrID", dtrid);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void update_entry6(int id, string date, string time, int dtrid)
        {
            mode = "updEntrySix";
            con_on();
            SqlCommand cmd = new SqlCommand("rdf_sp_TimeKeeper", con);
            cmd.Parameters.AddWithValue("@mode", mode);
            cmd.Parameters.AddWithValue("@empid", id);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@dtrTime", time);
            cmd.Parameters.AddWithValue("@dtrID", dtrid);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void update_entry7(int id, string date, string time, int dtrid)
        {
            mode = "updEntrySeven";
            con_on();
            SqlCommand cmd = new SqlCommand("rdf_sp_TimeKeeper", con);
            cmd.Parameters.AddWithValue("@mode", mode);
            cmd.Parameters.AddWithValue("@empid", id);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@dtrTime", time);
            cmd.Parameters.AddWithValue("@dtrID", dtrid);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private Boolean con_on()
        {

            try
            {

                con = new SqlConnection();
                con.ConnectionString = connetionString;
                con.Open();
                tkMode.Text = "";
                return true;
            }
            catch (Exception)
            {

                return false;
            }






        }
        private void con_off()
        {
            oc.Close();
            oc = new OleDbConnection();
            oc.ConnectionString = constr;


            oc.Open();


        }


        private void normal_dtr()
        {
            int id1 = 0;
            start = TimeSpan.Parse("07:00:00");
            endhw = TimeSpan.Parse("07:20:59"); // 2amS
            now = DateTime.Now;
            currenttime = TimeSpan.Parse(now.ToString("HH:mm:ss"));
            currentdate = DateTime.Today.ToString("MM/dd/yyyy");

            //autocomputer expired open start
            //DateTime FirstDate = dateTimePicker2.Value; change muna sa main mfg date
            DateTime FirstDate = mfg_datePicker.Value;
            DateTime SecondDate = xpired.Value;


            // Difference in days, hours, and minutes.
            TimeSpan ts = FirstDate - SecondDate;

            // Difference in days.
            int differenceInDays = ts.Days;
            txtxp.Text = differenceInDays.ToString();

            //open closed start



            // currentdate = DateTime.Today.ToString("yyyy-MM-dd");
            success = false;
            sw = false;
            move = false;
            ttime = now.ToString("h:mmtt");

            String tae = txtxp.Text.ToString();
            sample = textBox1.Text;

            //Value ng expiration dito  open start
            expired1 = differenceInDays.ToString();
            expired2 = differenceInDays.ToString();
            expired3 = differenceInDays.ToString();
            expired4 = differenceInDays.ToString();
            //open closed muna


            //murit
            //   textBox1.Text
            // expired1 = txtxp.Value.ToString();
            // expired1 = 118;
            //     expired1 = txtxp.
            // expired1 = DateTime.Today.ToString("yyyy-MM-dd");
            //    txtxp.Text = expired1.ToString();
            // expired1 = txtxp.Text.Value();

            SqlDataReader dr1 = get_id();




            SqlDataReader dr2 = get_status();



            /*

            if (dr2.HasRows)
            {

                sw = true;
                while (dr2.Read())
                    id1 = Convert.ToInt32(dr2[0].ToString());

                 MessageBox.Show("Not Here 1!");

            }

            else

      

                lblMessage.Text = "QA.";


                player.SoundLocation = @"C:\Users\bobo\windows_error_msg.wav";
                player.Play();
                */


            //1
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
            SqlConnection sql_con = new SqlConnection(connetionString);

            cmd1 = new SqlCommand("SELECT item_code FROM [dbo].[rdf_raw_materials]  WHERE item_code='" + txtMainInput.Text + "' AND Category='MACRO'", sql_con);

            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);

            da1.Fill(ds);
            int i = ds.Tables[0].Rows.Count;
            if (i > 0)
            {
                //MessageBox.Show("Macro Yan Micro Entry Only!");  ncov
                MacroErrorNotifier();
                ds.Clear();
                return;
            }




            cmd = new SqlCommand("SELECT item_code FROM [dbo].[rdf_raw_materials]  WHERE item_code='" + txtMainInput.Text + "'", sql_con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(ds);
            int i1 = ds.Tables[0].Rows.Count;
            if (i1 > 0)
            {

                //
                if (dr1.HasRows)
                {

                    sw = true;
                    while (dr1.Read())
                        id1 = Convert.ToInt32(dr1[0].ToString());

                    //MessageBox.Show("The Receiving of  Micro Materials Successs !");
                    //MicroReadNotify();remove welcome
                    groupBoxinfo.Visible = true;
                    ShowQA();
                    ShowWh();
     
                        groupBox8.Visible = true;
                    //lstvEmployee.Visible = true; remove ncov
                    lblFullname.Visible = true;
                    btnSubmit.Visible = true;
                    metroButton2.Visible = true;
                    buSave.Visible = true;
                    ds.Clear();
                    //return;




                    // MessageBox.Show("Not Here 1!");
                }

                else

                {
                    //ErrorNotifier();


                    lblMessage.Text = "Micro Raw Materials Doesn't Exists Or Is not already check By QA.";
                    txtMainInput.Text = "";

                    player.SoundLocation = @"C:\Reports\windows_error_msg.wav";
                    player.Play();
                    //this.Controls.Clear();
                    //this.InitializeComponent();
                    //s


                    //groupBoxinfo.Visible = false;
                    //groupBox1.Visible = false;
                    //groupBox2.Visible = false;
                    //groupBox8.Visible = false;
                    //lstvEmployee.Visible = false;
                    //lblFullname.Visible = false;
                    //btnSubmit.Visible = false;
                    //e


                    //this.Controls.Clear();

                }

            }
            else
            {


                //lblMessage.Text = "Micro Raw Materials Doesn't Exists Or Is not already check By QA"; 3/17/20 ncov
                player.SoundLocation = @"C:\Users\bobo\windows_error_msg.wav";
                player.Play();
                ErrorNotifier();
                return;


            }

            //if (txtgood.Text.Trim() == string.Empty) //ncov Specialist
            //{

            //    lstvEmployee.Visible = false;
            //    return;

            //}





            /*for overnight emp*/
            if (sw)
            {


                CreateLogs(txtMainInput.Text);
                //string q = "";
                sw = false;
                id = id1;


                dr = onyt();


                ////here
                //if (txtgood.Text.Trim() == string.Empty) //ncov Specialist
                //{

                //    //lstvEmployee.Visible = false;
                //    return;

                //}
                if (dr.HasRows)
                {
                    dtr_type = 0;

                    while (dr.Read())
                    {
                        dtr_type = Convert.ToInt32(dr[1].ToString());
                    }

                 

                    dr = select_Id(id, currentdate);


                    string login = "", Lout = "", Lin = "", Tout = "";

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            login = dr[0].ToString();
                            Lout = dr[1].ToString();
                            Lin = dr[2].ToString();
                            Tout = dr[3].ToString();
            
                            idx = Convert.ToInt32(dr[4].ToString());
                       
                        }


                    }

                    check_time(currentdate, idx);

                    if (login != "")
                    {
                        //   DateTime dt = Convert.ToDateTime(login);
                        //     if (DateTime.Compare(DateTime.Now, dt.AddMinutes(5)) >= 0)
                        //       {

                        if (dtr_type == 2)
                        {
                            store_rec();
                        }
                        else if (dtr_type == 1)
                        {

                            if (Tout == "")
                            {
                                try
                                {

                                    DateTime dt = Convert.ToDateTime(ti);
                                    if (is_time(dt.AddMinutes(5)))
                                    {

                                        update_to(id, currentdate, ttime, idx, expired4);
                                        lblMessage.Text = "Success Time Out 3";
                                        lblMessage.ForeColor = Color.Black;
                                        move = true;
                                        ctr++;
                                        btnSubmit.Visible = true;
                                    }
                                    else
                                    {
                                        lblMessage.Text = "Please Comeback after 5 min";
                                        lblMessage.ForeColor = Color.Black;
                                        move = false;

                                    }
                                }
                                catch (Exception/* ex*/)
                                {
                                    update_to(id, currentdate, ttime, idx, expired4);
                                    lblMessage.Text = "Success Time Out 4";
                                    lblMessage.ForeColor = Color.Black;
                                    move = true;
                                    ctr++;
                                }

                            }

                         




                            else
                            {
                                try
                                {
                                    DateTime dt = Convert.ToDateTime(to);

                                    if (is_time(dt.AddMinutes(5)))
                                    {

                                        //  insert_ti(id, currentdate, ttime, expired1);
                                        move = true;
                                        con.Close();
                                        ctr++;
                                        lblMessage.Text = "Success Time In 1";
                                        lblMessage.ForeColor = Color.Black;
                                        btnSubmit.Visible = true;
                                    }
                                    else
                                    {
                                        lblMessage.Text = "Please Comeback after 5 min";
                                        move = false;

                                    }

                                }
                                catch (Exception/* ex*/)
                                {

                                    insert_ti(id, currentdate, ttime, expired1);
                                    move = true;
                                    con.Close();
                                    ctr++;
                                    lblMessage.Text = "Success Time In 2";
                                    lblMessage.ForeColor = Color.Black;
                                    btnSubmit.Visible = true;
                                }

                            }



                        }



                    }

                
                    else if (login == "" && Lout != "") // ADDED TESTING
                    {
                        if (Lin == "")
                        {
                            try
                            {

                                DateTime dt = Convert.ToDateTime(Lout);
                                if (is_time(dt.AddMinutes(5)))
                                {

                                    update_li(id, currentdate, ttime, idx, expired3);
                                    lblMessage.Text = "Success Lunch In 1";
                                    lblMessage.ForeColor = Color.Black;
                                    move = true;
                                    ctr++;
                                }
                                else
                                {
                                    lblMessage.Text = "Please Comeback after 5 min";
                                    lblMessage.ForeColor = Color.Black;
                                    move = false;

                                }
                            }
                            catch (Exception /*ex*/)
                            {
                                update_li(id, currentdate, ttime, idx, expired3);
                                lblMessage.Text = "Success Lunch In 2";
                                lblMessage.ForeColor = Color.Black;
                                move = true;
                                ctr++;
                            }
                        }
                        else if (Tout == "")
                        {
                            try
                            {

                                DateTime dt = Convert.ToDateTime(Lin);
                                if (is_time(dt.AddMinutes(5)))
                                {
                                    update_to(id, currentdate, ttime, idx, expired4);
                                    lblMessage.Text = "Success Time Out 5";
                                    lblMessage.ForeColor = Color.Black;
                                    move = true;
                                    ctr++;
                                }
                                else
                                {
                                    lblMessage.Text = "Please Comeback after 5 min";
                                    lblMessage.ForeColor = Color.Black;
                                    move = false;
                                }
                            }
                            catch (Exception/* ex*/)
                            {
                                update_to(id, currentdate, ttime, idx, expired4);
                                lblMessage.Text = "Success Time Out 6";
                                lblMessage.ForeColor = Color.Black;
                                move = true;
                                ctr++;
                            }

                        }
                        else if (Lout != "" && Lin != "" && Tout != "")
                        {
                            try
                            {

                                DateTime dt = Convert.ToDateTime(to);
                                if (is_time(dt.AddMinutes(5)))
                                {

                                    insert_ti(id, currentdate, ttime, textBox1.Text);
                                    move = true;
                                    ctr++;
                                    con.Close();
                                    lblMessage.Text = "Success Time In 3";
                                    lblMessage.ForeColor = Color.Black;
                                    btnSubmit.Visible = true;
                                }
                                else
                                {
                                    lblMessage.Text = "Please Comeback after 5 min";
                                    lblMessage.ForeColor = Color.Black;
                                    move = false;
                                }
                            }
                            catch (Exception/* ex*/)
                            {
                                insert_ti(id, currentdate, ttime, expired1);
                                move = true;
                                ctr++;
                                con.Close();
                                lblMessage.Text = "Success Time In 4";
                                lblMessage.ForeColor = Color.Black;
                                btnSubmit.Visible = true;
                            }
                        }
                    }
                    else if (login == "" && Lout == "" && Lin == "" && Tout == "")
                    {

                        string lastdate = DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd");

                        dr = select_lastDtr(id, lastdate);


                        login = "";
                        Lout = "";
                        Lin = ""; Tout = "";
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                login = dr[0].ToString();
                                Lout = dr[1].ToString();
                                Lin = dr[2].ToString();
                                Tout = dr[3].ToString();
                            }
                        }
                        con.Close();

                        if (Tout == "" && login != "")
                        {
                            if (dtr_type == 2)
                            {

                                /*new*/
                                if (Lout == "")
                                {

                                    try
                                    {
                                        DateTime dt = Convert.ToDateTime(ti);

                                        if (is_time(dt.AddMinutes(5)))
                                        {
                                            insert_lo(id, currentdate, ttime, expired2);
                                            move = true;
                                            ctr++;

                                        }
                                        else
                                        {
                                            lblMessage.Text = "Please Comeback after 5 min";
                                            lblMessage.ForeColor = Color.Black;
                                            move = false;

                                        }

                                    }
                                    catch (Exception/* ex*/)
                                    {
                                        insert_lo(id, currentdate, ttime, expired2);
                                        move = true;
                                        ctr++;

                                    }




                                }
                                else if (Lin == "")
                                {

                                    try
                                    {
                                        DateTime dt = Convert.ToDateTime(lo);

                                        if (is_time(dt.AddMinutes(5)))
                                        {
                                            insert_li(id, currentdate, ttime, expired3);
                                            move = true;
                                            ctr++;
                                        }
                                        else
                                        {
                                            lblMessage.Text = "Please Comeback after 5 min";
                                            lblMessage.ForeColor = Color.Black;
                                            move = false;


                                        }
                                    }
                                    catch (Exception /*ex*/)
                                    {
                                        insert_li(id, currentdate, ttime, expired3);
                                        move = true;
                                        ctr++;
                                    }





                                }
                                else if (Tout == "")
                                {
                                    try
                                    {

                                        DateTime dt = Convert.ToDateTime(li);
                                        if (is_time(dt.AddMinutes(5)))
                                        {

                                            insert_to(id, currentdate, ttime, expired4);
                                            move = true;
                                            ctr++;

                                        }
                                        else
                                        {
                                            lblMessage.Text = "Please Comeback after 5 min";
                                            lblMessage.ForeColor = Color.Black;
                                            move = false;
                                        }
                                    }
                                    catch (Exception /*ex*/)
                                    {
                                        insert_to(id, currentdate, ttime, expired4);
                                        move = true;
                                        ctr++;
                                    }


                                }
                                else if (login != "" && Lout != "" && Lin != "" && Tout != "")
                                {

                                    try
                                    {

                                        DateTime dt = Convert.ToDateTime(to);
                                        if (is_time(dt.AddMinutes(5)))
                                        {
                                            update_to(id, currentdate, ttime, idx, expired4);
                                            lblMessage.Text = "Success Time Out 7";
                                            lblMessage.ForeColor = Color.Black;
                                            //move = false;
                                            move = true;
                                            ctr++;
                                        }
                                        else
                                        {
                                            dt = Convert.ToDateTime(to);
                                            if (is_time(dt.AddMinutes(5)))
                                            {
                                                insert_to(id, currentdate, ttime, expired4);
                                                move = true;
                                                ctr++;

                                            }
                                            else
                                            {
                                                lblMessage.Text = "Please Comeback after 5 min";
                                                lblMessage.ForeColor = Color.Black;
                                                move = false;
                                            }

                                        }

                                    }
                                    catch (Exception /*ex*/)
                                    {
                                        insert_to(id, currentdate, ttime, expired4);
                                        move = true;
                                        ctr++;

                                    }


                                }


                                /*newend*/




                            }
                            else if (dtr_type == 1)
                            {

                                try
                                {

                                    DateTime dt = Convert.ToDateTime(to);
                                    if (is_time(dt.AddMinutes(5)))
                                    {
                                        insert_to(id, currentdate, ttime, expired4);
                                        move = true;
                                        ctr++;
                                        lblMessage.Text = "Success Time Out 8";
                                        lblMessage.ForeColor = Color.Black;

                                    }

                                    else
                                    {
                                        lblMessage.Text = "Please Comeback after 5 min";
                                        lblMessage.ForeColor = Color.Black;
                                        move = false;
                                    }

                                }
                                catch (Exception /*ex*/)
                                {
                                    insert_to(id, currentdate, ttime, expired4);
                                    move = true;
                                    ctr++;
                                    lblMessage.Text = "Success Time In 5";
                                    lblMessage.ForeColor = Color.Black;
                                    btnSubmit.Visible = true;
                                }

                            }



                        }
                        else
                        {

                            try
                            {

                                DateTime dt = Convert.ToDateTime(to);
                                if (is_time(dt.AddMinutes(5)))
                                {
                                    insert_ti(id, currentdate, ttime, expired1);
                                    move = true;
                                    ctr++;
                                    lblMessage.Text = "Success Time In 6";
                                    lblMessage.ForeColor = Color.Black;
                                    btnSubmit.Visible = true;

                                }
                                else
                                {
                                    lblMessage.Text = "Please Comeback after 5 min";
                                    lblMessage.ForeColor = Color.Black;
                                    move = false;
                                }
                            }
                            catch (Exception /*ex*/)
                            {
                                insert_ti(id, currentdate, ttime, textBox1.Text);
                                move = true;
                                ctr++;
                                lblMessage.Text = "Success Time In 7";
                                lblMessage.ForeColor = Color.Black;
                            }



                        }


                    }
                    else
                    {

                        try
                        {

                            DateTime dt = Convert.ToDateTime(to);
                            if (is_time(dt.AddMinutes(5)))
                            {
                                insert_ti(id, currentdate, ttime, txtxp.Text);
                                move = true;
                                ctr++;

                                lblMessage.Text = "Success Time In 8";
                                lblMessage.ForeColor = Color.Black;
                                btnSubmit.Visible = true;

                            }
                            else
                            {
                                lblMessage.Text = "Please Comeback after 5 min";
                                lblMessage.ForeColor = Color.Black;
                                move = false;
                            }
                        }
                        catch (Exception /*ex*/)
                        {
                            insert_ti(id, currentdate, ttime, txtxp.Text);
                            move = true;
                            ctr++;

                            lblMessage.Text = "Success Time In 9";
                            btnSubmit.Visible = true;

                        }

                    }


                }
                else
                {


                    store_rec(); // NORMAL DTR store 1 gerard1

                }



            }
            //hw_mode();


        }


     
        private void insert_to(int id, string date, string time, string exp4)
        {
            mode = "insTimeOut";
            con_on();
            SqlCommand cmd = new SqlCommand("rdf_sp_TimeKeeper", con);
            cmd.Parameters.AddWithValue("@mode", mode);
            cmd.Parameters.AddWithValue("@empid", id);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@dtrTime", time);
            cmd.Parameters.AddWithValue("@exp4", exp4);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void insert_entry5(int id, string date, string time)
        {
            mode = "insEntryFive";
            con_on();
            SqlCommand cmd = new SqlCommand("rdf_sp_TimeKeeper", con);
            cmd.Parameters.AddWithValue("@mode", mode);
            cmd.Parameters.AddWithValue("@empid", id);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@dtrTime", time);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void insert_entry6(int id, string date, string time)
        {
            mode = "insEntrySix";
            con_on();
            SqlCommand cmd = new SqlCommand("rdf_sp_TimeKeeper", con);
            cmd.Parameters.AddWithValue("@mode", mode);
            cmd.Parameters.AddWithValue("@empid", id);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@dtrTime", time);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void insert_entry7(int id, string date, string time)
        {
            mode = "insEntrySeven";
            con_on();
            SqlCommand cmd = new SqlCommand("rdf_sp_TimeKeeper", con);
            cmd.Parameters.AddWithValue("@mode", mode);
            cmd.Parameters.AddWithValue("@empid", id);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@dtrTime", time);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void insert_li(int id, string date, string time, string exp3)
        {
            mode = "insTimeLi";
            con_on();
            SqlCommand cmd = new SqlCommand("rdf_sp_TimeKeeper", con);
            cmd.Parameters.AddWithValue("@mode", mode);
            cmd.Parameters.AddWithValue("@empid", id);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@dtrTime", time);
            cmd.Parameters.AddWithValue("@exp3", exp3);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void insert_lo(int id, string date, string time, string exp2)
        {
            mode = "insTimeLo";
            con_on();
            SqlCommand cmd = new SqlCommand("rdf_sp_TimeKeeper", con);
            cmd.Parameters.AddWithValue("@mode", mode);
            cmd.Parameters.AddWithValue("@empid", id);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@dtrTime", time);
            cmd.Parameters.AddWithValue("@exp2", exp2);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.ExecuteNonQuery();
            con.Close();
        }

        private SqlDataReader select_lastDtr(int id, string date)
        {
            mode = "selectLastDTR";
            con_on();
            SqlCommand cmd = new SqlCommand("rdf_sp_TimeKeeper", con);
            cmd.Parameters.AddWithValue("@mode", mode);
            cmd.Parameters.AddWithValue("@empid", id);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.CommandType = CommandType.StoredProcedure;
            //con.Close();

            return cmd.ExecuteReader();
        }
        private void check_time(string date_current, int idpass)
        {

            con_on();

            string q = "select  [attendance_date],[entry1],[entry2],[entry3],[entry4] from DT_RAW_RECORDS where attendance_date = @a and [ID] = @b"; // DTRecords
                                                                                                                                                     //    string q = "select  [Attendance_Date],[TimeIn],[LunchOut],[LunchIn],[TimeOut] from DTRecords where Attendance_Date = @a and [ID] = @b"; // DTRecords
            cmd = new SqlCommand(q, con);
            cmd.Parameters.AddWithValue("a", date_current);
            cmd.Parameters.AddWithValue("b", idpass);
            dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {

                while (dr.Read())
                {
                    //baliwkaba december 31 2019 By Gerard
                    if (dr[1].ToString() != "")
                        ti = dr[0].ToString() + " " + dr[1].ToString();
                    if (dr[2].ToString() != "")
                        lo = dr[0].ToString() + " " + dr[2].ToString();
                    if (dr[3].ToString() != "")
                        li = dr[0].ToString() + " " + dr[3].ToString();
                    if (dr[4].ToString() != "")
                        to = dr[0].ToString() + " " + dr[4].ToString();
                    //   if (dr[5].ToString() != "")
                    //       e5 = dr[0].ToString() + " " + dr[5].ToString();
                    //   if (dr[6].ToString() != "")
                    //       e6 = dr[0].ToString() + " " + dr[6].ToString();
                    //    if (dr[7].ToString() != "")
                    //      e7 = dr[0].ToString() + " " + dr[7].ToString();
                }

            }
            else
            {

                String dt1 = DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd");

                q = "select  [Attendance_Date],[TimeIn],[LunchOut],[LunchIn],[TimeOut] from DTRecords where Attendance_Date = @a  and [ID] = @b";
                cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("a", dt1);
                cmd.Parameters.AddWithValue("b", idpass);

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (dr[1].ToString() != "")
                        ti = dr[0].ToString() + " " + dr[1].ToString();
                    if (dr[2].ToString() != "")
                        lo = dr[0].ToString() + " " + dr[2].ToString();
                    if (dr[3].ToString() != "")
                        li = dr[0].ToString() + " " + dr[3].ToString();
                    if (dr[4].ToString() != "")
                        to = dr[0].ToString() + " " + dr[4].ToString();
                    //   if (dr[5].ToString() != "")
                    //       e5 = dr[0].ToString() + " " + dr[5].ToString();
                    //   if (dr[6].ToString() != "")
                    //      e6 = dr[0].ToString() + " " + dr[6].ToString();
                    // if (dr[7].ToString() != "")
                    //   e7 = dr[0].ToString() + " " + dr[7].ToString();
                }


            }

            con.Close();

        }

        private SqlDataReader onyt()
        {
            mode = "overnightSched";
            con_on();
            SqlCommand cmd = new SqlCommand("sp_TimeKeeping", con);
            cmd.Parameters.AddWithValue("@mode", mode);
            cmd.Parameters.AddWithValue("@empnum", txtMainInput.Text);
            cmd.CommandType = CommandType.StoredProcedure;
            //con.Close();

            return cmd.ExecuteReader();
        } //  

        private void CreateLogsDTR(string info)
        {
            try
            {
                const string path = @"DTR(Error).txt";
                var appendEmployeeNumber = "DTR Failed | Reason : " + info + " | Date & Time : " + DateTime.Now + Environment.NewLine;
                File.AppendAllText(path, appendEmployeeNumber);
            }
            catch (Exception ex)
            {
                const string path = @"DTR(Error).txt";
                var appendEmployeeNumber = ex.Message + info + DateTime.Now + Environment.NewLine;
                File.AppendAllText(path, appendEmployeeNumber);
            }
        }

        private void CreateLogs(string employeeNumber)
        {
            try
            {
                const string path = @"Logs.txt";

                //if (!File.Exists(path))
                //{
                //    var createText = "New Timekeeping Logs" + Environment.NewLine;



                //    File.WriteAllText(path, createText);
                //}


                var appendEmployeeNumber = "Employee Number: " + employeeNumber + " " + DateTime.Now + Environment.NewLine;
                File.AppendAllText(path, appendEmployeeNumber);
            }
            catch (Exception ex)
            {
                const string path = @"Logs.txt";

                //if (!File.Exists(path))
                //{

                //    TextWriter file = File.CreateText(@"C:\Logs.txt");
                //    var createText = "New Timekeeping Logs" + Environment.NewLine;

                //    File.WriteAllText(path, createText);
                //}

                var appendEmployeeNumber = ex.Message + employeeNumber + DateTime.Now + Environment.NewLine;
                File.AppendAllText(path, appendEmployeeNumber);
            }
        }

        private void store_rec()
        {
            //string q;


            //q = "select [ID] from DTRecords where [ID] = (SELECT max([ID]) FROM [DTRecords] where Employee_ID = @a and Attendance_Date = @b)";
            Boolean sw1 = false;

            dr = select_Id(id, currentdate);

            if (dr.HasRows)
            {
                sw1 = true;
                while (dr.Read())
                    idx = Convert.ToInt32(dr[4]);
            }
            else
            {
                try
                {

                  
                    DateTime dt = Convert.ToDateTime(to);

                    if (is_time(dt.AddMinutes(5)))
                    {

                        insert_ti(id, currentdate, ttime, txtxp.Text);
                        move = true;
                        ctr++;
                        lblMessage.Text = "Success Time In 10";
                        lblMessage.ForeColor = Color.Black;
                        btnSubmit.Visible = true;
                        ;
                    }
                    else
                    {

                        lblMessage.Text = "Please Comeback after 5 min";
                        lblMessage.ForeColor = Color.Black;
                        move = false;
                    }

                }
                catch (Exception /*ex*/)
                {

                    //dSet = objStorProc.rdf_sp_TimeKeeper(0, textBox1.Text, textBox1.Text, textBox1.Text, "insTimeIn");
                    //return = true;
                    //   insert_ti(id, currentdate, ttime, textBox1.Text, "insTimeIn");

                    string exp11 = "";
                    exp11 = textBox4.Text;
                    // textBox4.Text = exp11;
                    //insert_ti(id, currentdate, ttime, expired1);  4/12/2020
                    // gerard();
                    /*
                   int id = 0;
                   string date = "01/07/2020";
                   string time = "9:54PM";
                    


                   mode = "insTimeIn";
                   con_on();
                  SqlCommand cmd = new SqlCommand("rdf_sp_TimeKeeper", con);
                   cmd.Parameters.AddWithValue("@mode", mode);
                    cmd.Parameters.AddWithValue("@empid", id);
                  cmd.Parameters.AddWithValue("@date", date);
                   cmd.Parameters.AddWithValue("@dtrTime", time);
                   cmd.Parameters.AddWithValue("@exp1", textBox4.Text);
                   cmd.CommandType = CommandType.StoredProcedure;

                  cmd.ExecuteNonQuery();
                   con.Close();

                    */
           


                    move = true;
                    ctr++;
                    lblMessage.Text = "Entry No.1 Success Received";
                    lblMessage.ForeColor = Color.Black;

                    //Entry1Success();
                    groupBoxinfo.Visible = true;
                    btnSubmit.Visible = true;
                  
                }

            

            }
            con.Close();
            /*for regular emp*/
            if (sw1)
            {


                dr = select_Id2(id, currentdate, idx);

                sw1 = false;
                string login = "", Lout = "", Lin = "", Tout = "";

                while (dr.Read())
                {
                    login = dr[0].ToString();
                    Lout = dr[1].ToString();
                    Lin = dr[2].ToString();
                    Tout = dr[3].ToString();
                }

                con.Close();


                if (login == "")
                {

                    lblMessage.Text = "Success Time In 12";
                    lblMessage.ForeColor = Color.Black;

                    update_ti(id, currentdate, ttime, idx);
                    move = true;
                    ctr++;

                }
                else if (Lout == "")
                {
                    DateTime dt = Convert.ToDateTime(login);

                    if (is_time(dt.AddSeconds(25)))
                    // if (is_time(dt.AddMinutes(5)))
                    {

                        update_lo(id, currentdate, ttime, idx, expired2);
                        lblMessage.Text = "Entry No. 2 Success Received";
                        lblMessage.ForeColor = Color.Black;
                        Entry2Success();
                        groupBoxinfo.Visible = true;
                        move = true;
                        ctr++;
                        btnSubmit.Visible = true;

                    }
                    else
                    {
                        lblMessage.Text = "Please Swipe after 25 Seconds";
                        lblMessage.ForeColor = Color.Black;
                        move = false;

                    }



                }
                else if (Lin == "")
                {

                    DateTime dt = Convert.ToDateTime(Lout);

                    if (is_time(dt.AddMinutes(5)))
                    {
                        update_li(id, currentdate, ttime, idx, expired3);
                        lblMessage.Text = "Entry No.3 Success Received";
                        lblMessage.ForeColor = Color.Black;
                        Entry3Success();
                        groupBoxinfo.Visible = true;
                        move = true;
                        ctr++;
                        btnSubmit.Visible = true;
                    }
                    else
                    {
                        lblMessage.Text = "Please Comeback after 5 min";
                        lblMessage.ForeColor = Color.Black;
                        move = false;


                    }



                }
                else if (Tout == "")
                {


                    DateTime dt = Convert.ToDateTime(Lin);
                    if (is_time(dt.AddMinutes(5)))
                    {

                        update_to(id, currentdate, ttime, idx, expired4);
                        lblMessage.Text = "Entry No.4 Success Received 1";
                        lblMessage.ForeColor = Color.Black;
                        Entry4Success();
                        groupBoxinfo.Visible = true;
                        move = true;
                        ctr++;
                        btnSubmit.Visible = true;

                    }
                    else
                    {
                        lblMessage.Text = "Please Comeback after 5 min";
                        lblMessage.ForeColor = Color.Black;
                        move = false;

                    }



                }
                else if (login != "" && Lout != "" && Lin != "" && Tout != "")
                {
                    DateTime dt = Convert.ToDateTime(Tout);
                    if (is_time(dt.AddMinutes(5)))
                    {

                        update_to(id, currentdate, ttime, idx, expired4);
                        lblMessage.Text = "Success Time Out 2";
                        lblMessage.ForeColor = Color.Black;

                        move = true;
                        ctr++;
                    }
                    else
                    {

                        lblMessage.Text = "Please Comeback after 5 min";
                        lblMessage.ForeColor = Color.Black;
                        move = false;
                    }

                }


            }
            con.Close();




        }

        private void update_ti(int id, string date, string time, int dtrid)
        {
            mode = "updTimeIn";
            con_on();
            SqlCommand cmd = new SqlCommand("sp_TimeKeeping", con);
            cmd.Parameters.AddWithValue("@mode", mode);
            cmd.Parameters.AddWithValue("@empid", id);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@dtrTime", time);
            cmd.Parameters.AddWithValue("@dtrID", dtrid);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void update_lo(int id, string date, string time, int dtrid, string exp2)
        {
            mode = "updLunchOut";
            con_on();
            SqlCommand cmd = new SqlCommand("rdf_sp_TimeKeeper", con);
            cmd.Parameters.AddWithValue("@mode", mode);
            cmd.Parameters.AddWithValue("@empid", id);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@dtrTime", time);
            cmd.Parameters.AddWithValue("@dtrID", dtrid);
            cmd.Parameters.AddWithValue("@exp2", exp2);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private SqlDataReader select_Id2(int id, string date, int dtId)
        {
            mode = "selectDTR2";
            con_on();
            SqlCommand cmd = new SqlCommand("rdf_sp_TimeKeeper", con);
            cmd.Parameters.AddWithValue("@mode", mode);
            cmd.Parameters.AddWithValue("@empid", id);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@dtrID", dtId);
            cmd.CommandType = CommandType.StoredProcedure;
            //con.Close();

            return cmd.ExecuteReader();
        }

        private SqlDataReader select_Id(int id, string date)
        {
            mode = "selectDTR";
            con_on();
            SqlCommand cmd = new SqlCommand("rdf_sp_TimeKeeper", con);
            cmd.Parameters.AddWithValue("@mode", mode);
            cmd.Parameters.AddWithValue("@empid", id);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.CommandType = CommandType.StoredProcedure;
            //con.Close();
            return cmd.ExecuteReader();
        } //  


        private Boolean is_time(DateTime dt)
        {
            if (DateTime.Compare(DateTime.Now, dt) >= 0)
            {
                return true;
            }
            else
                return false;

            //return true;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void radBags_CheckedChanged(object sender, EventArgs e)
        {
            //txtQuantity.Visible = true;
            txtQuantity.Focus();
            txtQuantity.Select();
            txtQuantity2.Visible = false;
        }

        private void radKilo_CheckedChanged(object sender, EventArgs e)
        {
            txtQuantity2.Visible = true;
            txtQuantity2.Focus();
            txtQuantity2.Select();
            //txtQuantity.Visible = false;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtQuantity.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please select Quantity Procedure", "Quantity Received", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox3.Focus();
                textBox3.Select();
                return;
            }


            btncomputedays_Click(sender, e);




            if (txtFinalQty.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please select Quantity Procedure", "Quantity Received", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtFinalQty.Focus();
                txtFinalQty.Select();
                return;
            }



            if (txtgood.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please Input your Actual Count", "Quantity Good", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtgood.Focus();
                txtgood.Select();
                return;
            }




            /*




            DateTime FirstDate = dateTimePicker2.Value;
                DateTime SecondDate = xpired.Value;
                // Difference in days, hours, and minutes.
                TimeSpan ts = SecondDate - FirstDate;
                // Difference in days.
                int differenceInDays = ts.Days;
                txtxp.Text = differenceInDays.ToString();


            MessageBox.Show(txtxp.Text);
   */

            mode = "add";
            if (txtItemDescription.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter Description", "Item Description", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtFinalQty.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter Quantity", "Item Quantity", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtFinalQty.Focus();
                txtFinalQty.Select();
                return;
            }

            if (xpired.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter Expiration Date", "Expiration Date", MessageBoxButtons.OK, MessageBoxIcon.Information);
                xpired.Focus();
                xpired.Select();
                return;
            }



            ///add a new stocks
            /// buje gaming
            double num1;
            double num2;
            double answer;
            num1 = double.Parse(txtFinalQty.Text);
            num2 = double.Parse(txtActualStocks.Text);
            answer = num1 + num2;
            // textBox4.Text = Convert.ToString(answer);
            txtUpdatedStock.Text = Convert.ToString(answer);

            txtUpdatedStock2.Text = Convert.ToString(answer);

            if (txtItemCode.Text.Trim() == string.Empty)
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




                        MessageBox.Show("Raw Materials Received SuccesFully.", "Raw Material Received", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //calling the dashboards!

                        load_macro_count();
                        bunifuHeaderRaw.Visible = false;
                        txtMainInput.Focus();
                

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
                    MessageBox.Show("Failed");
                //frmMenu sa = new frmMenu();

                //sa.ActivitiesLogs(userinfo.emp_name + "update offenses");
            }
        }


        string uomselect = string.Empty;
        public bool saveMode()
        {

            if (mode == "add")
            {
                dSet.Clear();
                dSet = objStorProc.rdf_sp_new_micro_received(0, txtID.Text, cboCategory.Text, txtItemDescription.Text, "", "", "", "", "","", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "","","","","","PO","PO", "getbyname");

                if (dSet.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Raw Material is already added.", "Raw Materials", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMainInput.Focus();
                    //submit button that will be disabled 
                    btnSubmit.Enabled = false;
                    bunifuHeaderRaw.Visible = false;
                    //calling the dashboard counts

                    load_macro_count();
                    return false;
                }

                else
                {
                    dSet.Clear();
                    //// dSet = objStorProc.rdf_sp_new_micro(0, Convert.ToInt32(cbocategory.SelectedValue.ToString()), txtItemCode.Text.Trim(), Convert.ToInt32(cboSupplier.SelectedValue.ToString()), txtDescription.Text.Trim(), cboClassification.Text.Trim(), txtReorderLevel.Text.Trim(), txtDateAdded.Text.Trim(), txtExpirationDetails.Text.Trim(), txtLocation.Text.Trim(), txtDeliveryDetails.Text.Trim(), txtItemAddedBy.Text.Trim(), "add");

                    dSets = objStorProc.rdf_sp_new_micro_received(0, txtID.Text.Trim(), cboCategory.Text.Trim(), txtItemCode.Text.Trim(), cboSupplier.Text.Trim(), txtItemDescription.Text.Trim(), cboclassification.Text.Trim(), txtFinalQty.Text.Trim(), dateTimePicker2.Text.Trim(), xpired.Text.Trim(), txtAddedBy.Text.Trim(), txtxp.Text.Trim(), textBox2.Text.Trim(), txtUpdatedStock.Text.Trim(), txtgood.Text.Trim(), txtreject.Text.Trim(), txtoracleuom.Text.Trim(), txtposumid.Text.Trim(), uomselect, txtqtygood.Text.Trim(), mfg_datePicker.Text.Trim(), xpired.Text.Trim(), txtqtyordered.Text.Trim(), txtQABy.Text.Trim(), txtexpected.Text.Trim(), txtmissing.Text.Trim(), txtactual_receiving.Text.Trim(), txtqtygood.Text.Trim(), txtqtyreject.Text.Trim(), txtreceivedby.Text.Trim(), txtactual_receiving.Text.Trim(), txtqtywaiting.Text.Trim(), txtPrimaryKey.Text.Trim(), "1",txtrepackupdated.Text.Trim(),txtqa1.Text.Trim(),txtqa2.Text.Trim(),txtqa3.Text.Trim(),txtfinalproductionplanner.Text.Trim(),"PO","PO", "add");
                    //remove txtQuantity
                    txtfinalproductionplanner.Text = "";
                    // dSets = objStorProc.rdf_sp_new_micro_updated(0, txtID.Text.Trim(), cboCategory.Text.Trim(), txtItemCode.Text.Trim(), cboSupplier.Text.Trim(), txtItemDescription.Text.Trim(), cboclassification.Text.Trim(), txtFinalQty.Text.Trim(), dateTimePicker2.Text.Trim(), xpired.Text.Trim(), txtAddedBy.Text.Trim(), txtxp.Text.Trim(),txtxp.Text.Trim(), "update");
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
                        txtMainInput.Focus();
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

        private void txtReorderLevel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
     (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void dgv_table_MouseClick(object sender, MouseEventArgs e)
        {
            //  MessageBox.Show("Dot Net Perls is awesome.");
            loadMicro_Entry();
        }



        void loadMicro_Entry()
        {
            ready = false;
            xClass.fillListBox_Fedora(lstmenu, "filter_micro_entry", dSet, p_id, 0, 0);
            ready = true;
        }

        private void dgv_table_Leave(object sender, EventArgs e)
        {
            txtMainInput.Focus();
            txtMainInput.Select();
        }

        private void dgv_table_CurrentCellChanged(object sender, EventArgs e)
        {

            txtMainInput.Focus();
            //  txtMainInput.Select();
        }





        void DisableViewingMicro()
        {
            // alis myunagroupBoxinfo.Visible = false;
            txtrreceivedid.Enabled = false;
            //txtritemcode.Enabled = false;
            txtTotalS.Enabled = false;
            txtreorderlevel.Enabled = false;
            cborcategory.Enabled = false;
            txtrdescription.Enabled = false;
            txtLocation.Enabled = false;
            txtraddedby.Enabled = false;
            cboClass.Enabled = false;
            date_added.Enabled = false;
            txtDeliveryDetails.Enabled = false;
            dtpExpireddate.Enabled = false;
            txtexpiration_details.Enabled = false;
            txtreject2.Visible = false;

            //master LISt
            lblFullname.Visible = false;
            groupBoxinfo.Visible = false;
            HideQA();
            groupBox8.Visible = false;
            btnSubmit.Visible = false;
            lstvEmployee.Visible = false;


        }
        void DisableMainGroupBox()
        {
            mfg_datePicker.Enabled = false;
            xpired.Enabled = false;
            txtoracleuom.Enabled = false;


            txtxp.Enabled = false;
            //txtreject.Enabled = false;
            txtPerBag.Enabled = false;
            txtMultiply.Visible = false;
            txtID.Enabled = false;
            txtItemDescription.Enabled = false;
            //cboCategory.Enabled = false;
            //txtItemCode.Enabled = false;
            cboclassification.Enabled = false;
            dateTimePicker2.Enabled = false;
            //j   txtQuantity.Enabled = false;
            //  txtxp.Enabled = false;
            //cboSupplier.Enabled = false;
            txtAddedBy.Enabled = false;
            //   xpired.Enabled = false;
            //txtFinalQty.Enabled = false;
            txtActualStocks.Enabled = false;
            txtrepackavailable.Enabled = false;
            //txtUpdatedStock.Enabled = false; ncov

        }
        public void btncomputedays_Click(object sender, EventArgs e)
        {
            DateTime FirstDate = mfg_datePicker.Value;
            // DateTime FirstDate = dateTimePicker2.Value; to mfg date
            DateTime SecondDate = xpired.Value;
            // Difference in days, hours, and minutes.
            TimeSpan ts = SecondDate - FirstDate;
            // Difference in days.
            int differenceInDays = ts.Days;
            txtxp.Text = differenceInDays.ToString();

            //  Console.WriteLine("Difference in days: {0} ", differenceInDays);



            //bags computation
            double bag1;
            //double bag2;
            double baganswer;

            //bag1 = double.Parse(txtQuantity.Text);
            bag1 = double.Parse(txtgood.Text);
            //bag2 = double.Parse(txtPerBag.Text);
            //baganswer = bag1 * 20;
            baganswer = bag1 * 1;

            txtFinalQty.Text = Convert.ToString(baganswer);

        }

        private void dgv_table_DoubleClick(object sender, EventArgs e)
        {
            //   loadImage();
            // showMicroProfile();

            //  frmProfileMicroPrev mi = new frmProfileMicroPrev();
            //  mi.ShowDialog();
            //  mi.BringToFront();
            // frmaddUsers user = new frmaddUsers();
            // user.ShowDialog();
            cboClass.Text = "Good";
            groupBox3.Visible = true;
            txtMainInput.Focus();
            txtMainInput.Select();
            if (myglobal.updated == true)
            {
                //   p_Micros_Click(sender, e);
            }
            // txtsearch.Focus();
            frmMenu sa = new frmMenu();

        }


        private void loadImage()
        {
            dsImage = g_objStoredProcCollection.sp_micro_new(myglobal.temp_id, "", "getImageMicroReceived");
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

            }
            catch (Exception)
            {

            }
        }

        private void txtFinalQty_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void radBags_CheckedChanged_1(object sender, EventArgs e)
        {
            //change value of the bags
            txtx1.Text = "1";
            try
            {
                txtPerBag.Text = (float.Parse(txtPerBag2.Text) * float.Parse(txtx1.Text)).ToString();
            }
            catch (Exception)
            {


            }





            uomselect = "Bags";
            txtQuantity.Visible = true;
            txtQuantity2.Visible = false;
            txtMultiply.Visible = true;
            txtQuantity.Focus();
            txtQuantity.Enabled = false;
            txtMultiply.Enabled = false;
        }

        private void radKilo_CheckedChanged_1(object sender, EventArgs e)
        {
            uomselect = "Kilogram";
            txtQuantity.Visible = true;
            txtQuantity2.Visible = true;
            txtQuantity2.Focus();
            txtMultiply.Visible = false;
            txtPerBag.Text = "1";
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtxp_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void txtMainInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            //MessageBox.Show("gagagagannadsnd");
         


            if (txtMainInput.Text == "999999")
            {
                /////  Form2 frm2 = new Form2(this);
                /////  frm2.ShowDialog();
            }
            else
            {

                //  groupBoxinfo.Visible = true;

                try
                {

                    //   txthw.Visible = false;
                    lblMessage.Visible = false;
                    ///    groupBoxinfo.Visible = false;
                    groupBox3.Visible = false;

                    //int id1 = 0;
                    DateTime now = DateTime.Now;


                    if (e.KeyChar == (char)13)
                    {

                        lblMessage.Text = "";


                        if (con_on())
                        {
                            //bigbang
                            //lblMessage.Visible = true; alsi muna contra ncov

                            if (hw_on && TimeSpan.Parse(now.ToString("HH:mm:ss")) >= TimeSpan.Parse("07:00:00"))
                            {

                                /////hw_mode();

                                if_sched();

                                if (!sw)
                                {
                                    //alis muna buje  normal_dtr();
                                }


                            }
                            else
                            {

                                if (check_flexi() || check_ds())
                                {
                                    con.Close();
                                    ////    hw_mode2();
                                }

                                Thread.Sleep(50);
                                normal_dtr();


                                TimeSpan start = TimeSpan.Parse("03:00:00"); // 10 PM
                                TimeSpan end = TimeSpan.Parse("06:59:59"); // 2am
                                TimeSpan currenttime = TimeSpan.Parse(now.ToString("HH:mm:ss"));
                                if (currenttime >= start && currenttime <= end)
                                {
                                    ////hw_mode();
                                }


                                /////////////////////////// JAN 21, 2019

                            }





                            txtMainInput.Text = "";
                            Thread.Sleep(250);


                            if (move)
                            {
                                try
                                {

                                    if (dtPrev.Rows.Count >= 3)
                                    {
                                        dtPrev.Rows.RemoveAt(dtPrev.Rows.Count - 1);
                                        //dataGridView1.Rows.RemoveAt(dtPrev.Rows.Count - 1);
                                    }

                                    if (ctr > 1)
                                    {
                                        add_prev(prevId);
                                    }

                                    prevId = id.ToString();
                                    show_info(id, currentdate);
                                    hld = txtMainInput.Text;
                                    //dgCount.Text = dtPrev.Rows.Count.ToString();
                                    //dgCount.Text = dataGridView1.Rows.Count.ToString();
                                }
                                catch (Exception /*ex*/)
                                {
                                    show_info(id, currentdate);
                                    hld = txtMainInput.Text;
                                }

                            }

                            //  con.Close(); wag iclose para continues ang swipe!!

                            // MessageBox.Show(lblMessage.Text);
                        }
                        else //
                        {
                            tkMode.Text = "Offline Mode";
                            //  store_rec_offline();


                            txtMainInput.Text = "";





                            if (move)
                            {
                                try
                                {
                                    if (ctr > 1)
                                    {

                                        lstvPrevious.Items.Clear();

                                        lstvPrevious.Items.Add(lstvEmployee.Items[0].Text);
                                        lstvPrevious.Items[lstvPrevious.Items.Count - 1].SubItems.Add(lstvEmployee.Items[0].SubItems[1].Text);
                                        lstvPrevious.Items[lstvPrevious.Items.Count - 1].SubItems.Add(lstvEmployee.Items[0].SubItems[2].Text);
                                        lstvPrevious.Items[lstvPrevious.Items.Count - 1].SubItems.Add(lstvEmployee.Items[0].SubItems[3].Text);
                                        lstvPrevious.Items[lstvPrevious.Items.Count - 1].SubItems.Add(lstvEmployee.Items[0].SubItems[4].Text);

                                    }

                                    show_info_offline(id, currentdate);
                                    hld = txtMainInput.Text;
                                }
                                catch (Exception/* ex*/)
                                {
                                    show_info_offline(id, currentdate);
                                    hld = txtMainInput.Text;
                                }

                            }

                        }

                        Thread.Sleep(100);
                    }
                }
                catch (Exception ex)
                {

                    errorempnum = txtMainInput.Text;
                    CreateLogsDTR(ex.Message);

                    // //  Form2 frm2 = new Form2(this);
                    ////  frm2.Show();

                    //new Thread(() => printscreen()).Start();
                }
            }
        }

        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            // if (tabMain.SelectedTab == tabPage1)
            // {
            ////     MessageBox.Show("TASK LIST PAGE");
            // }
            // else if (tabMain.SelectedTab == tabPage2d)
            // {

            //  //   txtsearch.
            //  //     MessageBox.Show("SCHEDULE PAGE");

            // }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgv_po_approve_CurrentCellChanged(object sender, EventArgs e)
        {
            txtMainInput.Focus();
        }

        private void txtactual_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtgood_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtreject.Text = (float.Parse(txtactual.Text) - float.Parse(txtgood.Text)).ToString();
            }
            catch (Exception)
            {


            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnone_Click(object sender, EventArgs e)
        {
            SendKeys.Send("1");
        }

        private void txtbagrenew_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBox7.Text = (float.Parse(txtuno.Text) * float.Parse(txtbagrenew.Text)).ToString();
            }
            catch (Exception)
            {


            }
        }

        private void txtgood_TextChanged_1(object sender, EventArgs e)
        {
            try
            {


                txtreject2.Text = (float.Parse(txtqtygood.Text) - float.Parse(txtgood.Text)).ToString();

       

            }
            catch (Exception)
            {


            }

            try
            {


                txtqa1.Text = (float.Parse(txtqtygoodqa.Text) - float.Parse(txtreject.Text)).ToString();
            }
            catch (Exception)
            {


            }


            try
            {


                txtqa2.Text = (float.Parse(txtqtyvoidqa.Text) + float.Parse(txtreject.Text)).ToString();
            }
            catch (Exception)
            {


            }



            try
            {


                txtqa3.Text = (float.Parse(txtqtyremarksqa.Text) + float.Parse(txtreject.Text)).ToString();
            }
            catch (Exception)
            {


            }




            //


            try
            {


                txtUpdatedStock.Text = (float.Parse(txtActualStocks.Text) + float.Parse(txtgood.Text)).ToString();
                txtUpdatedStock2.Text = (float.Parse(txtActualStocks.Text) + float.Parse(txtgood.Text)).ToString();
            }
            catch (Exception)
            {


            }

            try
            {


                txtrepackupdated.Text = (float.Parse(txtrepackavailable.Text) + float.Parse(txtgood.Text)).ToString();
            }
            catch (Exception)
            {


            }

            try
            {


                txtfinalproductionplanner.Text = (float.Parse(txtgood.Text) + float.Parse(txtqtyproduction.Text)).ToString();
            }
            catch (Exception)
            {


            }




            if (txtgood.Text.Trim() == string.Empty)
            {

                txtUpdatedStock.Text = "";
                txtUpdatedStock2.Text = "";
                txtgood.BackColor = Color.Yellow;

                txtreject.Text = "";
                txtrepackupdated.Text = "";
                txtqa1.Text = "";
                txtqa2.Text = "";
                txtqa3.Text = "";
                txtfinalproductionplanner.Text = "";
            }
            else
            {
                txtgood.BackColor = Color.White;
                txtUpdatedStock2.Text = string.Format("{0:#,##0}", double.Parse(txtUpdatedStock2.Text));

                //txtUpdatedStock.Text = string.Format("{0:#,##0.00}", double.Parse(txtUpdatedStock.Text));
            }


            if(txtreject.Text.Trim() == string.Empty)
            {

            }
            else
            {
                txtreject.Text = string.Format("{0:#,##0}", double.Parse(txtreject.Text));

            }
        }

        void LessThanQAGoodNotify()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "YOUR ACTUAL QUANTITY GOOD IS HIGHER THAN THE ACTUAL RECEIVED, PLEASE TRY AGAIN. FOUND NEGATIVE VALUE!";
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

        private void btnSubmit_Click_1(object sender, EventArgs e)
        {
            if (txtgood.Text.Trim() == string.Empty)
            {
             
                WHqtyGoodNotify();

                txtgood.BackColor = Color.YellowGreen;
                txtgood.Focus();
                return;

            }


            if (txtreject2.Text.StartsWith("-"))
            {
                //Code if negative
                //MessageBox.Show("Your Actual Qty Good is Higher than QA good, Please Try again. Found Negative Value!", txtreject2.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                LessThanQAGoodNotify();
                txtgood.BackColor = Color.Yellow;
                //txtreject2.Visible = true;
                //txtreject2.BackColor = Color.Yellow;
                //LessThanQAGoodNotify();
                return;



            }

            if (txtQuantity.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please select Quantity Procedure", "Quantity Received", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox3.Focus();
                textBox3.Select();

                txtQuantity.BackColor = Color.Yellow;
                return;

            }


            btncomputedays_Click(sender, e);




            if (txtFinalQty.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please select Quantity Procedure", "Quantity Received", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtFinalQty.Focus();
                txtFinalQty.Select();
                return;
            }



            ////if (txtgood.Text.Trim() == string.Empty)
            ////{
            ////    MessageBox.Show("Please Input your Actual Count", "Quantity Good", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ////    txtgood.Focus();
            ////    txtgood.Select();
            ////    return;
            ////}




            /*




            DateTime FirstDate = dateTimePicker2.Value;
                DateTime SecondDate = xpired.Value;
                // Difference in days, hours, and minutes.
                TimeSpan ts = SecondDate - FirstDate;
                // Difference in days.
                int differenceInDays = ts.Days;
                txtxp.Text = differenceInDays.ToString();


            MessageBox.Show(txtxp.Text);
   */



            mode = "add";
            if (txtItemDescription.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter Description", "Item Description", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //if (txtFinalQty.Text.Trim() == string.Empty)
            //{
            //    MessageBox.Show("Please enter Quantity", "Item Quantity", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    txtFinalQty.Focus();
            //    txtFinalQty.Select();
            //    return;
            //}

            if (xpired.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter Expiration Date", "Expiration Date", MessageBoxButtons.OK, MessageBoxIcon.Information);
                xpired.Focus();
                xpired.Select();
                return;
            }




                if (saveMode())
                {
                    /// loadSupplier();
                    string tmode = mode;

                    if (tmode == "add")
                    {
                    //  dgv1.CurrentCell = dgv1[0, dgv1.Rows.Count - 1];




                    //MessageBox.Show("Raw Materials Received SuccesFully.", "Raw Material Received", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    //btnnotexist_Click(sender, e); 3/30/2020

                    RawMatsSuccess();
                    txtPoNumber.Visible = false;
                    bunifuHeaderRaw.Visible = false;
                    metroButton2.Visible = false;
                    buSave.Visible = false;
                    lblFullname.Visible = false;
                    groupBoxinfo.Visible = false;
                    HideQA();
                    HideWh();

                    bunifuSave.Visible = false;
                    btnSubmit.Visible = false;

                    //hello
                    bunifuSave.Visible = false;
                        //calling the dashboards!
                        btnSubmit.Visible = false;
                        load_macro_count();

                    frmmicroreceivingentry_Load(sender, e);
                    txtMainInput.Select();
                    txtMainInput.Focus();

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
                {
                    MessageBox.Show("Failed");
                    //frmMenu sa = new frmMenu();

                    //sa.ActivitiesLogs(userinfo.emp_name + "update offenses");
                }

            //}x

            //else if (dialogResult == DialogResult.No)x
            //{
            //    return;x
            //}x
            




            //if (txtItemCode.Text.Trim() == string.Empty)
            //{
            //    MessageBox.Show("Please enter Contact Details", "Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //else
            //{
            //    if (saveMode())
            //    {
            //        /// loadSupplier();
            //        string tmode = mode;

            //        //if (tmode == "add")
            //        //{
            //        //    //  dgv1.CurrentCell = dgv1[0, dgv1.Rows.Count - 1];




            //        //    //MessageBox.Show("Raw Materials Received SuccesFully.", "Raw Material Received", MessageBoxButtons.OK, MessageBoxIcon.Information); remove now

            //        //    //calling the dashboards!
            //        //    btnSubmit.Visible = false;
            //        //    load_macro_count();



            //        //    //   Mainmenu.Refresh();
            //        //    //   this.Close();
            //        //}
            //        //else
            //        //{
            //        //    //  dgv1.CurrentCell = dgv1[0, temp_hid];
            //        //}

            //        /// btnCancel_Click(sender, e);

            //    }
            //    else
            //        MessageBox.Show("Failed");
            //    //frmMenu sa = new frmMenu();

            //    //sa.ActivitiesLogs(userinfo.emp_name + "update offenses");
            //}
        }

        private void radBags_CheckedChanged_2(object sender, EventArgs e)
        {
            //txtQuantity.Visible = true;
            //txtQuantity.Focus();
            //txtQuantity.Select();
            //txtQuantity2.Visible = false;

            //change value of the bags
            txtx1.Text = "1";
            try
            {
                txtPerBag.Text = (float.Parse(txtPerBag2.Text) * float.Parse(txtx1.Text)).ToString();
            }
            catch (Exception)
            {


            }





            uomselect = "Bags";
            txtQuantity.Visible = true;
            txtQuantity2.Visible = false;
            txtMultiply.Visible = true;
            txtQuantity.Focus();
            txtQuantity.Enabled = false;
            txtMultiply.Enabled = false;
        }

        private void radKilo_CheckedChanged_2(object sender, EventArgs e)
        {
            txtQuantity2.Visible = true;
            txtQuantity2.Focus();
            txtQuantity2.Select();
            radKilo.Checked = true;
            txtQuantity.Visible = false;
        }

        private void txtPerBag2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtreject_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtqtyreject_TextChanged(object sender, EventArgs e)
        {



        }

        private void txtreject2_TextChanged(object sender, EventArgs e)
        {
            try
            {


                txtreject.Text = (float.Parse(txtreject2.Text) + 0).ToString();

                //txtreject.Text = (float.Parse(txtqtyreject.Text) + float.Parse(txtreject2.Text)).ToString();4/17/2020 mygeerard
            }
            catch (Exception)
            {


            }
        }

        private void btncomputedays_Click_1(object sender, EventArgs e)
        {

        }

        private void show_info_offline(int id, string a1)
        {



            if (ctr > 1 && move)
            {


                pctboxPrevious.Image = pctboxImage.Image;
                lblPreviousEmployeeName.Text = lblFullname.Text;
                lblPreviousPosition.Text = lblPosition.Text;

                /*
                con_on();

                string qq = "select ID from Health_wellnessDTRecords_3 where employee_number = @a and Attendance_Date = @b";
                cmd = new SqlCommand(qq, con);
                cmd.Parameters.AddWithValue("a", hld);
                cmd.Parameters.AddWithValue("b", a1);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    id = Convert.ToInt32(dr[0]);

                 } 
                if (dr.HasRows)
                {
                    txthw2.Visible = true;

                }         
                else
                    txthw2.Visible = false;

                con.Close();
                cmd.Dispose();
                con.Dispose();
                */


            }
            if (ctr > 1000)
                ctr = 2;

            string q = "select ee.lastname,ee.firstname,ee.middlename,pp.position_name " +
                "from employee ee left join positions pp on pp.position_id = ee.position_id where ee.employee_id = " + id;
            con_off();
            cmd_off = new OleDbCommand(q, oc);

            //cmd.Parameters.AddWithValue("aa", id);
            dr_off = cmd_off.ExecuteReader();

            if (dr_off.HasRows)
            {

                while (dr_off.Read())
                {
                    lblFullname.Text = dr_off[1].ToString() + " " + dr_off[2].ToString() + " " + dr_off[0].ToString();
                    //lblPosition.Text = dr_off[3].ToString();

                }

            }
            con.Close();

            try
            {
                pctboxImage.Image = Image.FromFile("c:\\pics " + @"\" + id.ToString() + ".jpg");


            }
            catch (Exception /*Ex*/)
            {
                pctboxImage.Image = Image.FromFile("c:\\pics " + @"\Employee.png");
            }
            try
            {
                TimeSpan start = TimeSpan.Parse("03:00:00"); // 10 PM
                TimeSpan end = TimeSpan.Parse("06:59:59"); // 2am
                TimeSpan currenttime = TimeSpan.Parse(now.ToString("HH:mm:ss"));
                //    q = "select * from DTRecords where [ID] = (SELECT max([ID]) FROM [DTRecords] where Employee_ID = @a and Attendance_Date = @b)";
                q = "select * from DT_RAW_RECORDS where [id] = (SELECT max([id]) FROM [DT_RAW_RECORDS] where employee_id = @a and attendance_date = @b)";
                con_off();
                cmd_off = new OleDbCommand(q, oc);
                cmd_off.Parameters.AddWithValue("a", id);
                cmd_off.Parameters.AddWithValue("b", a1);
                dr_off = cmd_off.ExecuteReader();
                lstvEmployee.Items.Clear();
                while (dr_off.Read())
                {
                    if (!sw || (currenttime >= start && currenttime <= end))
                    {

                        lstvEmployee.Items.Add(dr_off[2].ToString());
                        lstvEmployee.Items[lstvEmployee.Items.Count - 1].SubItems.Add(dr_off[3].ToString());
                        lstvEmployee.Items[lstvEmployee.Items.Count - 1].SubItems.Add(dr_off[4].ToString());
                        lstvEmployee.Items[lstvEmployee.Items.Count - 1].SubItems.Add(dr_off[5].ToString());
                        lstvEmployee.Items[lstvEmployee.Items.Count - 1].SubItems.Add(dr_off[6].ToString());
                    }
                }
            }
            catch (Exception /*ex*/)
            {


            }


            con.Close();


        }


        private void txtqtydelivered_TextChanged(object sender, EventArgs e)
        {
            //try
            //{


            //    txttotaldel.Text = (float.Parse(txtqtydelivered.Text) - float.Parse(txtactual_receiving.Text)).ToString();
            //}
            //catch (Exception)
            //{


            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Computation();
        }
        public void Computation()
        {

            ////bags computation
            double totaldev1;
            double totaldev2;
            double baganswer;


            totaldev1 = double.Parse(txtqtydelivered.Text);
            totaldev2 = double.Parse(txtactual_receiving.Text);
            ////baganswer = bag1 * 20;
            baganswer = totaldev1 + totaldev2;

            txttotaldel.Text = Convert.ToString(baganswer);

            //2

        }

        private void txtMainInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnnotexist_Click(object sender, EventArgs e)
        {
            RawMatsSuccess();
            metroButton2.Visible = false;
            buSave.Visible = false;
            lblFullname.Visible = false;
            groupBoxinfo.Visible = false;
            HideQA();
           HideWh();
  
                bunifuSave.Visible = false;
            btnSubmit.Visible = false;
        }

        public void ErrorNotifier()
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);

            popup.ContentText = "MICRO RAW MATERIAL DOESN't EXISTS OR IS NOT ALREADY CHECK BY QA.!";

            popup.ContentColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);

            popup.ContentHoverColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentPadding = new Padding(0);

            //popup.Size = new Size(920, 270);
            //popup.ImageSize = new Size(175, 220);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Red;
            popup.Popup();
            popup.IsRightToLeft = false;
            //popup.AnimationDuration = 1000;
            //popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            txtMainInput.Focus();
            txtMainInput.Select();
            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }



        public void MacroErrorNotifier()
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);

            popup.ContentText = "NO TRANSACTION FOR RECEIVING ENTRY AT THIS MATERIAL OR MACRO MATERIAL ERROR";

            popup.ContentColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
           

            popup.ContentHoverColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentPadding = new Padding(0);

            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Red;
            popup.Popup();
            //popup.AnimationDuration = 1000;
            //popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            txtMainInput.Focus();
            txtMainInput.Select();
            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }
        void MicroReadNotify()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.information;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.Black;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Micro Raw Materials Validated Success!";
            popup.Size = new Size(920, 270);
            popup.ImageSize = new Size(175, 180);
            popup.BodyColor = Color.DeepSkyBlue;
            popup.Popup();
            //popup.AnimationDuration = 1000;
            //popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            txtMainInput.Focus();
            txtMainInput.Select();
            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;

            bunifuHeaderRaw.Visible = true;
        }



        void RawMatsSuccess()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.ContentColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "RAW MATERIALS SUCCESSFULLY RECEIVED";
     
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Green;
            popup.Popup();
            //popup.AnimationDuration = 1000;
            //popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            txtMainInput.Focus();
            txtMainInput.Select();
            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;
            txtgood.Text = "";
            txtreject.Text = "";
            txtMainInput.Select();
            txtMainInput.Focus();
        }


        void CancelRawMatsSuccess()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "RAW MATERIAL RECEIVING CANCELLED";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Green;
            popup.Popup();
            //popup.AnimationDuration = 1000;
            //popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            txtMainInput.Focus();
            txtMainInput.Select();
            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;
            txtgood.Text = "";
            txtreject.Text = "";

        }





        void Entry1Success()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "RAW MATERIAL SUCCESSFULLY VALIDATED '" + lblFullname.Text + "' AND THE NO. OF ITEM TO BE RECEIVED IS '" + lblrecords.Text + "'";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Gray;
            popup.Popup();
            //popup.AnimationDuration = 1000;
            //popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            txtMainInput.Focus();
            txtMainInput.Select();
            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;

            txtgood.Focus();
            load_search();
            doSearch();
            txtPoNumber.Visible = true;
        }


        void Entry2Success()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Entry No. 2 Successful Validated !";
            popup.ContentColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(920, 270);
            popup.ImageSize = new Size(175, 180);
            popup.BodyColor = Color.DarkGreen;
            popup.Popup();
            //popup.AnimationDuration = 1000;
            //popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            txtMainInput.Focus();
            txtMainInput.Select();
            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }


        void Entry3Success()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Entry No. 3 Successful Validated !";
            popup.ContentColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(920, 270);
            popup.ImageSize = new Size(175, 180);
            popup.BodyColor = Color.DarkGreen;
            popup.Popup();
            //popup.AnimationDuration = 1000;
            //popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            txtMainInput.Focus();
            txtMainInput.Select();
            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }


        void Entry4Success()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Entry No. 4 Successful Validated !";
            popup.ContentColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(920, 270);
            popup.ImageSize = new Size(175, 180);
            popup.BodyColor = Color.DarkGreen;
            popup.Popup();
            //popup.AnimationDuration = 1000;
            //popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            txtMainInput.Focus();
            txtMainInput.Select();
            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }

        void WHqtyGoodNotify()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.ContentText = "FILL UP THE REQUIRED FIELD AT WAREHOUSE QUANTITY GOOD";
            popup.Size = new Size(920, 270);
            popup.ImageSize = new Size(175, 220);
            popup.BodyColor = Color.Red;
            popup.Popup();

            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            //popup.AnimationDuration = 1000;
            //popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            txtMainInput.Focus();
            txtMainInput.Select();
            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }

        private void bunifuMainInput_KeyPress(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {
            //MetroFramework.MetroMessageBox.Show(this, "OK", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            MetroFramework.MetroMessageBox.Show(this, "OK", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            //if(MetroFramework.MetroMessageBox.Show(this, "YesNo/Cancel", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to save the data?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
           
                btnSubmit_Click_1(sender, e);
            }
            else
            {

                return;
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            MetroFramework.MetroMessageBox.Show(this, "Error", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            MetroFramework.MetroMessageBox.Show(this, "Warning", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void bunifuSave_Click(object sender, EventArgs e)
        {
            metroButton2_Click(sender, e);

            //if (MetroFramework.MetroMessageBox.Show(this, "YesNo/Cancel", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //{

            //}

        }

        private void bunifuTextbox2_OnTextChange(object sender, EventArgs e)
        {

        }

        private void txtActualStocks_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtgood_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    metroButton2_Click(sender, e);
            //}
        }

        private bool check_ds()
        {
            mode = "checkDS";
            con_on();
            SqlCommand cmd = new SqlCommand("sp_TimeKeeping", con);
            cmd.Parameters.AddWithValue("@mode", mode);
            cmd.Parameters.AddWithValue("@empnum", txtMainInput.Text);
            cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd"));
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();

            if (dr.HasRows)
                return true;
            else
                return false;
        }

      private void button4_Click(object sender, EventArgs e)
        {
            expirationdays();
        }

        private void label41_Click(object sender, EventArgs e)
        {

        }

        private void btntimetable_Click(object sender, EventArgs e)
        {
           
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            



 
        }

        private void txtgood_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);



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










            //     double inputNumber;
            //     bool isNumber = double.TryParse(txtgood.Text, out inputNumber);
            //     //txtqtygood.Text = string.Format("{0:#,##0.00}", double.Parse(txtqtygood.Text));
            //     string withCommas = inputNumber.ToString("#,##0");
            //txtgood.Text = withCommas;


        }

        private void txtMainInput_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    txtMainInput_KeyPress(sender, e);
            //}
        }

        private void bunifuHeaderRaw_Click(object sender, EventArgs e)
        {
            metroButton7_Click(sender, e);
        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Cancel The Receiving of Raw Materials ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                CancelRawMatsSuccess();

                dgvProduceBy.Visible = false;
                metroButton2.Visible = false;
                buSave.Visible = false;
                lblFullname.Visible = false;
                groupBoxinfo.Visible = false;
                HideQA();
                HideWh();
                bunifuHeaderRaw.Visible = false;
                bunifuSave.Visible = false;
                btnSubmit.Visible = false;

                //hello
                bunifuSave.Visible = false;
                //calling the dashboards!
                btnSubmit.Visible = false;
                txtPoNumber.Visible = false;
            }
            else
            {
                return;
            }
        }

        private void txtPrimaryKey_TextChanged(object sender, EventArgs e)
        {
            doSearch();
        }

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
                    else if (myglobal.global_module == "MicroReceiving")
                    {
                        //  dv.RowFilter = "item_id like '%" + txtsearch.Text + "%' or item_code like '%" + txtsearch.Text + "%' or item_description like '%" + txtsearch.Text + "%'";
                        //dv.RowFilter = "item_id like '%" + txtsearch.Text + "%' or item_code like '%" + txtsearch.Text + "%'";
                        dv.RowFilter = "primary_key ='" + txtPrimaryKey.Text + "'";

                    }
                    else if (myglobal.global_module == "VISITORS")
                    {
                        //dv.RowFilter = "visitors_lastname like '%" + txtsearch.Text + "%' or visitors_firstname like '%" + txtsearch.Text + "%'";
                    }
                    dgvProduceBy.DataSource = dv;
                    lblrecords.Text = dgvProduceBy.RowCount.ToString();
                }
            }
            catch (SyntaxErrorException)
            {
                MessageBox.Show("Invalid character found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPrimaryKey.Focus();
                return;
            }
            catch (EvaluateException)
            {
                MessageBox.Show("Invalid character found 2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPrimaryKey.Focus();
                return;
            }
        }

        private void dgvProduceBy_CurrentCellChanged(object sender, EventArgs e)
        {
            showReceiving();
        }

        void showReceiving()
        {

            if (dgvProduceBy.RowCount > 0)
            {
                if (dgvProduceBy.CurrentRow != null)
                {
                    if (dgvProduceBy.CurrentRow.Cells["po_number"].Value != null)
                    {
                        //p_id = Convert.ToInt32(dgv_table_2nd_sup.CurrentRow.Cells["received_id2"].Value);
                    txtPoNumber.Text = dgvProduceBy.CurrentRow.Cells["po_number"].Value.ToString();
                    txtqtygoodqa.Text = dgvProduceBy.CurrentRow.Cells["qty_good"].Value.ToString();
                        txtqtyvoidqa.Text = dgvProduceBy.CurrentRow.Cells["qty_void"].Value.ToString();
                    txtqtyremarksqa.Text = dgvProduceBy.CurrentRow.Cells["qty_remarks"].Value.ToString();
                    }

                }
            }

        }

        private void lblFullname_Click(object sender, EventArgs e)
        {
            //dgvProduceBy.Visible = true;
        }

        private void txtrepackupdated_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtfinalproductionplanner_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtqtygoodqa_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtqtygood_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPoNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtqa1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtqa2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtqa3_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtrepackavailable_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtqtyproduction_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void txttotaldel_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtoracleuom_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtx1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPerBag_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtmissing_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtexpected_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFinalQty_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtQuantity2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtqtywaiting_TextChanged(object sender, EventArgs e)
        {

        }

        private void buSave_Click(object sender, EventArgs e)
        {
            if(txtgood.Text.Trim() == string.Empty)
            {

            }
            else
            {
                if (txtgood.Text.Contains("."))
                {

                }
                else
                {

                    txtgood.Text = string.Format("{0:#,##0}", double.Parse(txtgood.Text));
                }
            }
            metroButton2_Click(sender, e);
        }

        private void txtUpdatedStock_TextChanged(object sender, EventArgs e)
        {
 
        }

        private void txtgood_MouseLeave(object sender, EventArgs e)
        {
       
        }

        private void txtgood_KeyUp(object sender, KeyEventArgs e)
        {
          
        }

        private void txtgood_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void txtgood_Leave(object sender, EventArgs e)
        {

        }

        private bool check_flexi()
        {
            mode = "checkFlex";
            con_on();
            SqlCommand cmd = new SqlCommand("sp_TimeKeeping", con);
            cmd.Parameters.AddWithValue("@mode", mode);
            cmd.Parameters.AddWithValue("@empnum", txtMainInput.Text);
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();

            if (dr.HasRows)
                return true;
            else
                return false;
        }


        private SqlDataReader get_id()                                              /// TESTING PURPOSES : sp_TimeKeeping   STORED PROCEDURE    sp_TimeKeeping   sp_TimeKeeping sp_TKSample    ||         // sp_TimeKeeping
        {
            mode = "getEmpID";
            con_on();
            SqlCommand cmd = new SqlCommand("sp_microraw_TimeKeeping", con);
            cmd.Parameters.AddWithValue("@mode", mode);
            cmd.Parameters.AddWithValue("@item_code", txtMainInput.Text);
            cmd.CommandType = CommandType.StoredProcedure;
            //con.Close();
            //buje
            return cmd.ExecuteReader();
        }

        private SqlDataReader get_status()                                              /// TESTING PURPOSES : sp_TimeKeeping   STORED PROCEDURE    sp_TimeKeeping   sp_TimeKeeping sp_TKSample    ||         // sp_TimeKeeping
        {
            mode = "getstatus";
            con_on();
            SqlCommand cmd = new SqlCommand("sp_microraw_TimeKeeping", con);
            cmd.Parameters.AddWithValue("@mode", mode);
            cmd.Parameters.AddWithValue("@item_code", txtMainInput.Text);
            cmd.CommandType = CommandType.StoredProcedure;
            //con.Close();
            //buje
            return cmd.ExecuteReader();
        }
        private void if_sched()
        {
            try
            {

                dr = dsched(DateTime.Today.ToString("yyyy-MM-dd"), DateTime.Now.ToString("HH:mm:ss"));
                string time_holder = "";
                while (dr.Read())
                {
                    time_holder = dr[0].ToString();
                }
                con.Close();


                if (time_holder != "")
                {


                    if (TimeSpan.Parse(Convert.ToDateTime(time_holder).ToString("HH:mm:ss")) < TimeSpan.Parse("08:00:00"))
                    {
                        if (TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss")) <= TimeSpan.Parse("07:20:59"))
                            sw = false;
                    }


                }


            }
            catch (Exception)
            {

            }

        }


        private SqlDataReader dsched(string date, string dtime)
        {
            mode = "checkDynamicSched";
            con_on();
            SqlCommand cmd = new SqlCommand("sp_TimeKeeping", con);
            cmd.Parameters.AddWithValue("@mode", mode);
            cmd.Parameters.AddWithValue("@empnum", txtMainInput.Text);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@dschedTime", dtime);
            cmd.CommandType = CommandType.StoredProcedure;
            //con.Close();

            return cmd.ExecuteReader();
        }
        void add_prev(string id)
        {
            dRow = dtPrev.NewRow();
            //var dRow = new DataGridViewRow();
            try
            {
                dRow["Image"] = Image.FromFile("c:\\pics " + @"\" + id + ".jpg");
            }
            catch
            {
                dRow["Image"] = Image.FromFile("c:\\pics " + @"\Employee.jpg");
            }

            dRow["Name"] = empNamexX; //lblFullname.Text
            dRow["TimeIn"] = lstvEmployee.Items[0].SubItems[1].Text;
            dRow["LunchOut"] = lstvEmployee.Items[0].SubItems[2].Text;
            dRow["LunchIn"] = lstvEmployee.Items[0].SubItems[3].Text;
            dRow["TimeOut"] = lstvEmployee.Items[0].SubItems[4].Text;
    

            dtPrev.Rows.InsertAt(dRow, 0);
         
            set_dg();
        }
        void expirationdays()
        {

            //autocomputer expired open start
            DateTime FirstDate = mfg_datePicker.Value;
            DateTime SecondDate = xpired.Value;


            // Difference in days, hours, and minutes.
            TimeSpan ts = SecondDate - FirstDate;

            // Difference in days.
            int differenceInDays = ts.Days;
            txtxp.Text = differenceInDays.ToString();
        }


        private void show_info(int id, string a1)
        {

            if (ctr > 1000)
                ctr = 2;

            string q = " select TOP 1 emp.item_id, emp.item_code, emp.Category, emp.item_description, emp.classification, emp.quantity, sr.supplier, sr.address, sr.contact_no, sr.email_address, emp.date_added, emp.expiration_details,emp.delivery_details,emp.date_added,emp.item_location,emp.item_remarks,emp.item_added_by,emp.total_quantity_raw,emp.per_bag,po.expiry_date,po.qty_ordered,po.qty_delivered,po.qty_waiting,po.Password,po.qty_reject,po.mfg_date,po.qty_uom,po.po_sum_id,po.stacking_level,po.qty_missing,po.qty_delivered,po.QA_by,po.qty_total_delivered,po.primary_key,po.vendor_name,po.qty_total_delivered,po.Password,emp.qty_repack_available,po.qty_good,po.qty_void,po.qty_remarks,emp.qty_production " +
       "FROM rdf_raw_materials emp LEFT JOIN rdf_category st ON emp.item_category = st.category_id LEFT JOIN rdf_supplier sr ON emp.supplier = sr.supplier_id LEFT JOIN rdf_po_summary_retail po ON emp.item_code = po.item_code WHERE emp.item_id = @a AND emp.is_active = 1 AND po.IsActive=1 AND po.checklist_approval='Approved' ORDER BY po.po_sum_id ASC";

            //   string q = "select e.lastname,e.firstname,e.middlename,p.position_name,p.position_id,e.employee_number " +
            //   "from employee e left join positions p on p.position_id = e.position_id where e.employee_id = @a";
            con_on();
            cmd = new SqlCommand(q, con);
            cmd.Parameters.AddWithValue("a", id);
            dr = cmd.ExecuteReader();

            //autocomputer expired open start
            DateTime FirstDate = mfg_datePicker.Value;
            DateTime SecondDate = xpired.Value;


            // Difference in days, hours, and minutes.
            TimeSpan ts = SecondDate - FirstDate;

            // Difference in days.
            int differenceInDays = ts.Days;
            txtxp.Text = differenceInDays.ToString();

            //open closed start
            //Value ng expiration dito  open start
            expired1 = differenceInDays.ToString();
            expired2 = differenceInDays.ToString();
            expired3 = differenceInDays.ToString();
            expired4 = differenceInDays.ToString();
            //open closed muna


            if (dr.HasRows)
            {

                while (dr.Read())
                {
                    txtgood.Focus();
                    empNamexX = dr[1].ToString() + " " + dr[0].ToString();
                    lblFullname.Text = dr[3].ToString();
                    lblPosition.Text = dr[3].ToString();
                    txtItemDescription.Text = dr[3].ToString();
                    posiid.Text = dr[4].ToString();
                    txtItemCode.Text = dr[1].ToString();
                    //varcharimage.Text = dr[5].ToString();
                    cboCategory.Text = dr[2].ToString();
                    //bunifuTex.Text = dr[6].ToString();
                    txtID.Text = dr[0].ToString();
                    cboclassification.Text = dr[4].ToString();
                    txtActualStocks.Text = dr[17].ToString();
                    txtPerBag.Text = dr[18].ToString();

                    //start po Left Join viewing
                    xpired.Text = dr[19].ToString();
                    //textBox5.Text = dr[19].ToString();

                    ////
                    //lbldashboard1.Text = dr[20].ToString();
                    //lbldashboard2.Text = dr[21].ToString();
                    //lbldashboard3.Text = dr[22].ToString();
                    //lbldashboard4.Text = dr[23].ToString();
                    //lbldashboard5.Text = dr[24].ToString();

                    txtqtyordered.Text = dr[20].ToString();
                    //txtqtydelivered.Text = dr[21].ToString();

                    txtqtydelivered.Text = dr[35].ToString();



                    txtqtywaiting.Text = dr[22].ToString();
                    //txtqtygood.Text = dr[23].ToString();

                    txtqtygood.Text = dr[36].ToString();
                    txtqtyreject.Text = dr[24].ToString();






                    mfg_datePicker.Text = dr[25].ToString();
                    //txtQuantity.Text = dr[21].ToString(); lako kepa ini anakputa!
                    txtQuantity.Text = dr[32].ToString();
                    txtactual.Text = dr[21].ToString();
                    //txtposumid.Text = dr[22].ToString();
                    txtoracleuom.Text = dr[26].ToString();
                    txtposumid.Text = dr[27].ToString();
                    txtPerBag2.Text = dr[18].ToString();
                    txtexpected.Text = dr[28].ToString();
                    txtmissing.Text = dr[29].ToString();

                    txtactual_receiving.Text = dr[30].ToString();
                    txtQABy.Text = dr[31].ToString();

                    txtPrimaryKey.Text = dr[33].ToString();

                    cboSupplier.Text = dr[34].ToString();
                    txtrepackavailable.Text = dr[37].ToString();


                    txtqtyproduction.Text = dr[41].ToString();
                    LoadViewBoxes();


                    bunifuSave.Visible = true;
                    btnSubmit.Enabled = true;
                    //txtQuantity.Text = "";
                    txtFinalQty.Text = "";
                    txtUpdatedStock.Text = "";
                    txtUpdatedStock2.Text = "";
                    expirationdays();

                    Entry1Success();
                    bunifuHeaderRaw.Visible = true;

                    //ending inventory
                    //txtqtygood.Text = string.Format("{0:#,##0}", double.Parse(txtqtygood.Text));
                    //txtqtydelivered.Text = string.Format("{0:#,##0}", double.Parse(txtqtydelivered.Text));
                  //txtrepackavailable.Text = string.Format("{0:#,##0}", double.Parse(txtrepackavailable.Text));
                    load_search();
                    doSearch();
        

                }

            }
            con.Close();

            try
            {
                //    pctboxImage.Image = Image.FromFile("c:\\pics " + @"\" + id.ToString() + ".jpg");
                pctboxImage.Image = Image.FromFile(@"C:\pics\" + @"\" + id.ToString() + ".jpg");
            }
            catch (Exception /*Ex*/)
            {
                // pctboxImage.Image = Image.FromFile("c:\\pics " + @"\Employee.png");
                pctboxImage.Image = Image.FromFile(@"C:\pics\" + @"\Employee.png");
            }

            try
            {
                TimeSpan start = TimeSpan.Parse("03:00:00"); // 10 PM
                TimeSpan end = TimeSpan.Parse("06:59:59"); // 2am
                TimeSpan currenttime = TimeSpan.Parse(now.ToString("HH:mm:ss"));

                dr = select_Id(id, a1);
                lstvEmployee.Items.Clear();
                while (dr.Read())
                {
                    if (!sw || (currenttime >= start && currenttime <= end)) // 
                    {

                        lstvEmployee.Items.Add(dr[5].ToString());
                        lstvEmployee.Items[lstvEmployee.Items.Count - 1].SubItems.Add(dr[0].ToString());
                        lstvEmployee.Items[lstvEmployee.Items.Count - 1].SubItems.Add(dr[1].ToString());
                        lstvEmployee.Items[lstvEmployee.Items.Count - 1].SubItems.Add(dr[2].ToString());
                        lstvEmployee.Items[lstvEmployee.Items.Count - 1].SubItems.Add(dr[3].ToString());
                        //  lstvEmployee.Items[lstvEmployee.Items.Count - 1].SubItems.Add(dr[4].ToString());
                        //  lstvEmployee.Items[lstvEmployee.Items.Count - 1].SubItems.Add(dr[5].ToString());
                        // lstvEmployee.Items[lstvEmployee.Items.Count - 1].SubItems.Add(dr[6].ToString());
                    }
                }
            }
            catch (Exception /*ex*/)
            {


            }


        }

        public void LoadViewBoxes()
        {
            lblFullname.Visible = true;
            groupBoxinfo.Visible = true;
            ShowQA();
            ShowWh();
        
                btnSubmit.Visible = true;
            //lstvEmployee.Visible = true;
            groupBox8.Visible = true;

        }

    }
}
