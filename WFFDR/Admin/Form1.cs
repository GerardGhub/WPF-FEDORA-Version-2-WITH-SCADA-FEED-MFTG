using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Tulpep.NotificationWindow;
using WFFDR;
using System.Reflection;
using System.Net.NetworkInformation;
using System.Data.SqlClient;
using SharpUpdate;




namespace WFFDR
{
    public partial class Form1 : Form, ISharpUpdatable
    {
        private SharpUpdater updater;

        public Uri xmlLocation;

        System.Media.SoundPlayer player = new System.Media.SoundPlayer();
        readonly myclasses xClass = new myclasses();
        IStoredProcedures objStorProc = null;
        // StoredProcedures trys = new StoredProcedures ();
        DataSet dSet = new DataSet();
        new frmMenu Menu;
      MDIParent1 mdiparent;
        //int p_id = 0;

        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();


        public Form1()
        {
            InitializeComponent();
            this.lbl1.Text = this.ApplicationAssembly.GetName().Version.ToString();
         
            //this.xmlLocation = new Uri("http://fedora:8068/Debug/update.xml");
            updater = new SharpUpdater(this);
        }

        private void Button2_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Are You Sure", "Application Exit", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (dialogResult == DialogResult.No)
            {

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Ping ping = new Ping();
            PingReply reply = ping.Send(txtserveripaddress.Text, 1000);
            //MessageBox.Show(reply.Status.ToString());
            txtipmessage.Text = reply.Status.ToString();
            if (txtipmessage.Text == "Success")
            {

 

            }
            else
            {
                ConncectionTimeoutNotifier();

                txtipmessage.Text = "";
                return;
            }



            objStorProc = xClass.g_objStoredProc.GetCollections();

            pictureBox1.BorderStyle = BorderStyle.None;
            txtdateofout.Text = DateTime.Now.AddDays(-3).ToString("M/d/yyyy");

            txtdateyesterday.Text = DateTime.Now.AddDays(-1).ToString("M/d/yyyy");
            lblyesterday2.Text = DateTime.Now.AddDays(-2).ToString("M/d/yyyy");
            lblyesterday3.Text = DateTime.Now.AddDays(-3).ToString("M/d/yyyy");

            txtdatenow.Text = DateTime.Now.ToString("M/d/yyyy");
            load_Schedules();
            //load_User();
            txtusername.Focus();
            txtusername.Select();
            myglobal.global_module = "Active";
            dset_emp.Clear();
            dset_emp = objStorProc.sp_getMajorTables("searchuserinlogin");
            //doSearch();
            //btnuserclick.Text = "";

            //updater.DoUpdate();
            load_materials();

            //this.lbl1.Text = this.ApplicationAssembly.GetName().Version.ToString();



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


        public void load_materials()
        {



                string mcolumns = "test,item_code,item_description";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
                pointer_module.populateModule(dsetHeader, dgvMaterials, mcolumns, "micro_raw_material_all");
                lblrecords.Text = dgvMaterials.RowCount.ToString();
    
        }
        #region SharpUpdate
        public string ApplicationName
        {
            get { return "WFFDR"; }
        }

        public string ApplicationID 
        {
         get { return "WFFDR"; }
        }
        public Uri UpdateXmlLocation
        {
            get { return new Uri("http://fedora:8068/Debug/update.xml"); }

        }
      

        public Form Context
        {
            get { return this; }

        }
        public Icon ApplicationIcon
        {

            get { return this.Icon; }
        }

  
        public Assembly ApplicationAssembly
        {

            get { return Assembly.GetExecutingAssembly(); }
        }
        #endregion




        //public string ApplicationName
        //{
        //    get { return "WFFDR"; }
        //}

        //public string ApplicationID
        //{
        //    get { return "WFFDR"; }
        //}

        //public Icon ApplicationIcon
        //{
        //    get { return this.Icon; }
        //}

        //public Uri UpdateXmlLocation
        //{
        //    get { return new Uri("http://fedora:8068/update.xml");  }

        //    //get { return new Uri("file://10.10.12.115/c$/myxml/update.xml"); }
        //}

        //public Assembly ApplicationAssembly
        //{
        //    get { return Assembly.GetExecutingAssembly(); }
        //}

        //public Form Context
        //{
        //    get { return this; }
        //}

        private void button1_Click_1(object sender, EventArgs e)
        {

            Menu = new frmMenu();
            Menu.Show();



        }

        public void load_Schedules()
        {
            string mcolumns = "test,rp_item_id";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgvApproved, mcolumns, "repacking_count");
            lblrecords.Text = dgvApproved.RowCount.ToString();

        }

        public void load_User()
        {
            string mcolumns = "test,username";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgvuserrecommend, mcolumns, "searchuserinlogin");

        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            metroButton1_Click(sender, e);


        }



        private void txtpassword_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtpassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnlog_Click_1(sender, e);
            }
        }


        public void FilltextboxErrorNotifier()
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);

            popup.ContentText = "Warning , Fill up the Empty Fields";

            popup.ContentColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);

            popup.ContentHoverColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentPadding = new Padding(0);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            //popup.Size = new Size(920, 270);
            //popup.ImageSize = new Size(175, 220);
            popup.BodyColor = Color.Red;
            popup.Popup();

            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);

            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }




        private void btnlog_Click_1(object sender, EventArgs e)
        {

            dSet.Clear();
            dSet = objStorProc.rdf_sp_prod_schedules(0, txtdatenow.Text, "", "", "", "", "", "", "", "", "","", "", "extractedrawmats");

            if (dSet.Tables[0].Rows.Count > 0)
            {

            }
            else
            {
                //MessageBox.Show("b");
                InsertRawMatsRpt();
                //return;
            }


            dSet.Clear();
            dSet = objStorProc.rdf_sp_prod_schedules(0, txtdatenow.Text, "", "", "", "", "", "", "", "", "","", "", "injectedrawmatsinrecipe");

            if (dSet.Tables[0].Rows.Count > 0)
            {

            }
            else
            {
                //MessageBox.Show("b");
                if (lblid.Text == "2")
                {
                    btnlessthan_Click(sender, e);
                }
                //return;
            }





            if (lblrecords.Text == "0")
            {

                dSet.Clear();

                dSet = objStorProc.rdf_sp_new_preparation(0, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "insertrepacking");

            }
            else
            {
                dSet.Clear();
                //dSet = objStorProc.rdf_sp_prod_schedules(0, txt1.Text, "", "", "", "", "", "", "existsornot");
                dSet = objStorProc.rdf_sp_new_preparation(0, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "deletepreparation");
            }

            if (txtusername.Text.Trim() == string.Empty)
            {
                FilltextboxErrorNotifier();
                return;

            }


            //out ang bulk data expiration sya ng one day
            dSet.Clear();
            dSet = objStorProc.sp_userfile(0, txtdateyesterday.Text.Trim(), txtpassword.Text.Trim(), "", "updatebulk_data_expired");

            dSet.Clear();
            dSet = objStorProc.sp_userfile(0, lblyesterday2.Text.Trim(), txtpassword.Text.Trim(), "", "updatebulk_data_expired");


            //debug muna eto
            //dSet.Clear();
            //dSet = objStorProc.sp_userfile(0, lblyesterday3.Text.Trim(), txtpassword.Text.Trim(), "", "updatebulk_data_expired");




            dSet.Clear();

            dSet = objStorProc.rdf_sp_new_preparation(0, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "updatereprinting");
            //mali
            dSet.Clear();
            dSet = objStorProc.rdf_sp_new_preparation(0, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "updaterecipetoproduction");

            ///modified
            dSet.Clear();
            dSet = objStorProc.sp_userfile(0, txtusername.Text.Trim(), txtpassword.Text.Trim(), "", "validate");



       



  

            if (dSet.Tables[0].Rows.Count > 0)
            {
                userinfo.set_user_parameters(dSet);
                myglobal.user_password = txtpassword.Text;

                player.SoundLocation = @"C:\Reports\Fedora_Voice\Fresh-morning-Welcome-po-sa-Fe1608971554.wav";
                player.Play();

                string winpath = Environment.GetEnvironmentVariable("windir");
                string path = System.IO.Path.GetDirectoryName(
                              System.Windows.Forms.Application.ExecutablePath);

                //Program Files(x86)\DiniTools\WeighConsole.exe"

                //System.Diagnostics.Process.Start(@"C:\Program Files (x86)\DiniTools\WeighConsole.exe");//deploy


                //  MessageBox.Show("perfect!", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Menu = new frmMenu();
                // Menu.Show();
                mdiparent = new MDIParent1();
                mdiparent.Show();



                this.Close();

            }
            else
            {
                //player.SoundLocation = @"C:\Reports\windows_error_msg.wav";
                //player.Play();
                //MessageBox.Show("Sorry! You are not allowed to use this system!", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NotAllowToUsed();
                //txtusername.Text = "";
                //txtpassword.Text = "";
                //txtusername.Focus();
            }
        }


        void NotAllowToUsed()
        {
            //(MetroFramework.MetroMessageBox.Show(this, "Sorry! You are not allowed to use this system! " + txtusername.Text + "", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning));

            MetroFramework.MetroMessageBox.Show(this, "Sorry! You are not allowed to use this system! ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //Application.Exit();
            txtusername.Text = "";
            txtpassword.Text = "";
            txtusername.Focus();


        }
        private void txtusername_TextChanged(object sender, EventArgs e)
        {
            //   txtusername.Focus();

            Ping ping = new Ping();
            PingReply reply = ping.Send(txtserveripaddress.Text, 1000);
            //MessageBox.Show(reply.Status.ToString());
            txtipmessage.Text = reply.Status.ToString();
            if (txtipmessage.Text == "Success")
            {

        

            }
            else
            {
                ConncectionTimeoutNotifier();

                txtipmessage.Text = "";
                return;
            }



            dset_emp = objStorProc.sp_getMajorTables("searchuserinlogin");
            doSearch();
            if (txtusername.Text.Trim() == string.Empty)
            {
                btnuserclick.Text = "";
            }


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

                        dv.RowFilter = "username like '%" + txtusername.Text + "%'";

                    }
                    else if (myglobal.global_module == "VISITORS")
                    {
                        //dv.RowFilter = "visitors_lastname like '%" + txtsearch.Text + "%' or visitors_firstname like '%" + txtsearch.Text + "%'";
                    }
                    dgvuserrecommend.DataSource = dv;
                    //lblrecords.Text = dgv_table.RowCount.ToString();
                }
            }
            catch (SyntaxErrorException)
            {
                MessageBox.Show("Invalid character found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtusername.Focus();
                return;
            }
            catch (EvaluateException)
            {
                MessageBox.Show("Invalid character found 2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtusername.Focus();
                return;
            }
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MDIParent1 pengari = new MDIParent1();
            pengari.ShowDialog();

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            player.SoundLocation = @"C:\Reports\Fedora_Voice\Mag-la-logout-ka-na-po-ba-tala1608971918.wav";
            player.Play();

            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Exit " + txtusername.Text + "?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {

                return;
            }
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            btnlog_Click_1(sender, e);
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            btnExit_Click(sender, e);
        }

        private void bunifuThinButton215_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.White;
            button1.Visible = false;
            button3.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.LightSlateGray;
            button3.Visible = false;

            button1.Visible = true;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            txtpassword.PasswordChar = '\0';
        }

        private void btneye_Click(object sender, EventArgs e)
        {

            txtpassword.PasswordChar = '\0';
            btneye.Visible = false;
            btneyeclose.Visible = true;

        }

        private void btneyeclose_Click(object sender, EventArgs e)
        {
            txtpassword.PasswordChar = '*';
            btneyeclose.Visible = false;
            btneye.Visible = true;
        }

        private void dgvuserrecommend_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgvuserrecommend.RowCount > 0)
            {
                if (dgvuserrecommend.CurrentRow != null)
                {
                    if (dgvuserrecommend.CurrentRow.Cells["username"].Value != null)
                    {
                        //p_id = Convert.ToInt32(dgv_table.CurrentRow.Cells["recipe_id"].Value);

                        btnuserclick.Text = dgvuserrecommend.CurrentRow.Cells["username"].Value.ToString();

                        lblid.Text = dgvuserrecommend.CurrentRow.Cells["user_rights_id"].Value.ToString();







                        //wala muna this


                    }

                }
            }

        }

        private void btnuserclick_Click(object sender, EventArgs e)
        {
            string username = btnuserclick.Text;
            txtusername.Text = username;
        }

        private void txtusername_KeyPress(object sender, KeyPressEventArgs e)
        {

            Ping ping = new Ping();
            PingReply reply = ping.Send(txtserveripaddress.Text, 1000);
            //MessageBox.Show(reply.Status.ToString());
            txtipmessage.Text = reply.Status.ToString();
            if (txtipmessage.Text == "Success")
            {



            }
            else
            {
                ConncectionTimeoutNotifier();

                txtipmessage.Text = "";
                return;
            }



            dset_emp = objStorProc.sp_getMajorTables("searchuserinlogin");
            doSearch();
        }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {
            if (txtpassword.Text.Trim() == string.Empty)
            {

            }
            else
            {
                btnuserclick.Text = "";
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //updater = new SharpUpdate.SharpUpdater(this);

            //updater.DoUpdate();
            //Application.Exit
            //System.IO.File.Move(@"c:\test\SomeFile.txt", @"c:\test\SomeFile2.txt");

            //            string file = "c:\test\SomeFile.txt"
            //string moveTo = "c:\test\test\SomeFile.txt"

            //if (File.Exists(moveTo))
            //            {
            //                File.Delete(moveTo);
            //            }

            //            File.Move(file, moveTo);


        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Ping ping = new Ping();
            PingReply reply = ping.Send(txtserveripaddress.Text, 1000);
            //MessageBox.Show(reply.Status.ToString());
            txtipmessage.Text = reply.Status.ToString();
            if (txtipmessage.Text == "Success")
            {

                btnlog_Click_1(sender, e);

            }
            else
            {
                ConncectionTimeoutNotifier();

                txtipmessage.Text = "";
                return;
            }

        }


        public void ConncectionTimeoutNotifier()
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);

            popup.ContentText = "Conncection Timeout! Please Contact 09985933785 - MIS Support Boss Peng";

            popup.ContentColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);

            popup.ContentHoverColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentPadding = new Padding(0);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            //popup.Size = new Size(920, 270);
            //popup.ImageSize = new Size(175, 220);
            popup.BodyColor = Color.Red;
            popup.Popup();

            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);

            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }
        private void btnExits_Click(object sender, EventArgs e)
        {
            btnExit_Click(sender, e);
        }

        private void GroupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void lbl1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }


        public void InsertRawMatsRpt()
        {
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            //deploy
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "INSERT INTO [dbo].[copy_rdf_raw_materials] (item_code,item_description,Category,buffer_of_stocks,total_quantity_raw,qty_repack_available,qty_production,date_extracted,qty_repack,item_group) SELECT item_code,item_description,Category,buffer_of_stocks,total_quantity_raw,qty_repack_available,qty_production,'" + txtdatenow.Text + "',qty_repack,item_group FROM rdf_raw_materials WHERE is_active='1'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvuserrecommend.DataSource = dt;

            sql_con.Close();


        }
        private void bunifuThinButton24_Click_1(object sender, EventArgs e)
        {

 


    










        }


        void SearchRecipe()
        {


            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "select top(1) item_code, rp_description,CAST(proddate as date) as LastUsed,DATEDIFF(DAY,CAST(proddate as date),CAST(GETDATE() as date)) as MOVEMENT from rdf_recipe_to_production where item_code='" + txtItemCode.Text+"'  and CAST(proddate as date) < CAST(GETDATE() as date) ORDER BY CAST(proddate as date) DESC";






            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvRecipeInsert.DataSource = dt;
            lblrecordcount.Text = dgvRecipeInsert.RowCount.ToString();
            sql_con.Close();

        }

        void UpdatelastusedRawMats()
        {


            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "UPDATE [dbo].[rdf_raw_materials] set last_used ='"+txtLastUsed.Text+ "', materials_injected_date='"+txtdatenow.Text+"',report ='"+txtreport.Text+"'  where item_code='" + txtItemCode.Text+"'";

            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvUpdateRawMats.DataSource = dt;

            sql_con.Close();

        }




        private void btnlessthan_Click(object sender, EventArgs e)
        {
            SearchRecipe();
            showValueRecipe();
            MovingFunctionality();
            UpdatelastusedRawMats();
            //MessageBox.Show("" + txtItemCode.Text + "");
            //for debugging porpuses only dont touch animal;
            if (dgvMaterials.Rows.Count >= 1)
            {
             

                int i = dgvMaterials.CurrentRow.Index + 1;
                if (i >= -1 && i < dgvMaterials.Rows.Count)
                    dgvMaterials.CurrentCell = dgvMaterials.Rows[i].Cells[1];

   
                else
                {
                    //LastLine();
                    //MessageBox.Show("Last muna nyan  haha");

                    //frmMoveOrder_Load(sender, e);
                    return;
                }



                button4_Click(sender, e);


            }





















        }

        private void button4_Click(object sender, EventArgs e)
        {
            btnlessthan_Click(sender, e);
        }

        private void dgvMaterials_CurrentCellChanged(object sender, EventArgs e)
        {
            showValue();
        }

        void showValue()
        {

            if (dgvMaterials.RowCount > 0)
            {
                if (dgvMaterials.CurrentRow != null)
                {
                    if (dgvMaterials.CurrentRow.Cells["item_code"].Value != null)
                    {

                        txtItemCode.Text = dgvMaterials.CurrentRow.Cells["item_code"].Value.ToString();


                    }
                }
            }

        }

        private void dgvRecipeInsert_CurrentCellChanged(object sender, EventArgs e)
        {
            showValueRecipe();
        }

        void showValueRecipe()
        {

            if (dgvRecipeInsert.RowCount > 0)
            {
                if (dgvRecipeInsert.CurrentRow != null)
                {
                    if (dgvRecipeInsert.CurrentRow.Cells["item_code2"].Value != null)
                    {

                        txtLastUsed.Text = dgvRecipeInsert.CurrentRow.Cells["LastUsed"].Value.ToString();

                     txtMovingtesting.Text = dgvRecipeInsert.CurrentRow.Cells["MOVEMENT"].Value.ToString();

                    }
                }
            }

        }

        public void MovingFunctionality()
        {
            if (txtMovingtesting.Text.Trim() == string.Empty)
            {
                txtMovingtesting.Text = "9999";
            }

            double DaysOfmoving;


            DaysOfmoving = double.Parse(txtMovingtesting.Text);
            if (lblrecordcount.Text == "0")
            {
                txtreport.Text = "NON MOVING";
                txtLastUsed.Text = DateTime.Now.AddDays(-356).ToString();
                //txtLastUsed.Text = DateTime.Now.AddDays(-300).ToString();

                //puks
            }
            else
            {

                if (DaysOfmoving == 1 || DaysOfmoving == 0)
                {

                    //MessageBox.Show("Fast Moving");
                    txtreport.Text = "FAST MOVING";
                }
                else if (DaysOfmoving == 2 || DaysOfmoving == 3 || DaysOfmoving == 4 || DaysOfmoving == 5)
                {
                    //MessageBox.Show("Slow Moving");
                    txtreport.Text = "SLOW MOVING";
                }
                else
                {
                    //MessageBox.Show("NonMoving Moving");
                    txtreport.Text = "NON MOVING";
                }
            }

        }

        private void bunifuThinButton24_Click_2(object sender, EventArgs e)
        {
 

        }

        private void btncheckupdate_Click(object sender, EventArgs e)
        {
            updater.DoUpdate();
        }
    }
}
