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
using System.IO;
using System.IO.Ports;
using CrystalDecisions.CrystalReports.Engine;
using System.Drawing.Printing;

namespace WFFDR
{
    public partial class frmrepackingentry : Form
    {
        private int childFormNumber = 0;
        PaperSize paperSize = new PaperSize("papersize", 520, 820); //page size 2X1 inches approx



        //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"

        ////SqlDataAdapter sql_da = new SqlDataAdapter();

        ////SqlCommand sql_cmd = new SqlCommand();
        ////SqlDataReader dr;

        int i;
        string mode = ""; //mymode
        myclasses xClass = new myclasses();
        IStoredProcedures objStorProc = null;
        DataSet dSets = new DataSet();

        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();
        DataSet dSet_temp = new DataSet();
        DataSet dset_delete = new DataSet();

        frmMicroReceivingInfo microviews;
        DataSet dSet = new DataSet();
        DataSet dset_rights = new DataSet();

        private SerialPort _serialPort;
        private const int BaudRate = 9600;
   
        DataSet dset_section = new DataSet();
        Boolean ready = false;
        bool re = false;
        int p_id = 0;
        int s_id = 0;
        //weighing

        public myclasses classes = new myclasses();
        myclasses myClass = new myclasses();
   
        IStoredProcedures g_objStoredProcCollection = null;
        public DataSet dset = new DataSet();
        DataSet dset2 = new DataSet();
        DataSet dset3 = new DataSet();
   
        ReportDocument rpt = new ReportDocument();
        string Rpt_Path = "";

        //user rights class
        int rights_id = 0;

        public frmrepackingentry()
        {
            InitializeComponent();
        }

        private void frmrepackingentry_Load(object sender, EventArgs e)
        {
            txtlastpack_TextChanged(sender, e);
            txtActualFormula.Text = "1";
            txtbatch.Text = "1";
            txtActualFormula.Text = "1";
            txtqtyoverall.Text = "0";
            txtselectweight.Text = "0"; ///gago
            txtneededqty.Text = "0";
            microviews = new frmMicroReceivingInfo();
       txtrepackby.Text = userinfo.emp_name.ToUpper();
         
            //assuming the name "panel1" in the Panel1 of the SplitContainer
            //panel1.MaximumSize = new Size(10, 10); //max 300 x 300
            myglobal.global_module = "REPACKING";
            lblactivemodule.Text = "REPACKING";

            //call the data of receiving entry
           // load_micro_receiving_entry();

            //call the data of receiving entry
           load_2ndSupplier();

            //make my window full screen mutong!
            this.WindowState = FormWindowState.Maximized;
            //hide all my functions!
            HideFunctions();
            //disable our textbox
            DisableTextBox();

            //Call othes Functions
            CallOther();
            // Calling the Stored PROC 
            objStorProc = xClass.g_objStoredProc.GetCollections();

            loadStandardWeight();
            load_RawNMaster();
            load_StockoutEntry();


            loadPrintingData();


            loadFeedCode();
            loadCategory();
        }

        void loadCategory()
        {
            //department
            ready = false;
            xClass.fillComboBox(cboCategor, "rdf_repack_raw_mats", dSet);
            ready = true;
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
        public void userRights()
        {

            rights_id = userinfo.user_rights_id;

            if (rights_id == 1 || rights_id == 2 || rights_id == 5)
            {
                //   mnuHolidays.Enabled = true;
                //  sicknessToolStripMenuItem.Enabled = true;

                if (rights_id == 2) // MIS
                {
                    // toolStripButton2.Visible = true;
                    //bunifuFlatButton1.Enabled = false; you musst add dito gusto mong ihide
                }

                // bunifuFlatButton1.Visible = false;
            }
        }
        //print an ID
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

            //cmbHR_OIC.DataSource = dset.Tables[0].DefaultView;
            //cmbHR_OIC.DisplayMember = dset.Tables[0].Columns[0].ToString();
            //cmbHR_OIC.ValueMember = dset.Tables[0].Columns[1].ToString();

            int number_of_rows = dset2.Tables[0].Rows.Count - 1;


            //txtfooter.Text = dset2.Tables[0].Rows[number_of_rows]["company_name"].ToString() + Environment.NewLine
            //                + dset2.Tables[0].Rows[number_of_rows]["company_address_number"].ToString() + Environment.NewLine
            //                + dset2.Tables[0].Rows[number_of_rows]["company_phone_number"].ToString();

            dset = g_objStoredProcCollection.sp_IDGenerator(1, "SearchRepackingFiltered", "All", txtSearchx.Text, 1);
            dataView.DataSource = dset.Tables[0];

            //dset = g_objStoredProcCollection.sp_IDGenerator(1, "Search", "All", txtSearch.Text, 1);
            //dataView.DataSource = dset.Tables[0];

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


        public void clearpackingentry()
        {

            dataView.Rows[i].Cells["selected"].Value = false;
            txtActualQty.Text = "";
            txtselectweight.Text = "";
            txtshareddeb.Text = "";
            txtweighingscale.Text = "";
            txtneededqty.Text = "0";
            txtactualqtydeb.Text = "";
            txtfinalrepackdeb.Text = "";
            btnSubmit.Enabled = true;
            Newpackingentry();
            updatetotalrepacking();
        }

        public void Newpackingentry()
        {
            //qty raw materia; repack available
            double newpack1;
            //double newpack2;
            double packavailable;

            newpack1 = double.Parse(txtBalance.Text);
            //newpack2 = double.Parse(txtselectweight.Text);

            packavailable = newpack1 * 1;


            txtActualQty.Text = Convert.ToString(packavailable);
            txtactualqtydeb.Text = Convert.ToString(packavailable);


        }

        public void updatetotalrepacking()
        {
            double updatepack1;
            double totalupdate;

            updatepack1 = double.Parse(txtrpavailable.Text);

            totalupdate = updatepack1 * 1;

            txtqtyoverall.Text = Convert.ToString(totalupdate);


        }



        public void load_RawNMaster()
        {
            string mcolumns = "test,item_id,item_code,item_description,total_quantity_raw,qty_repack,qty_repack_available";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgvMaster, mcolumns, "raw_material_receiving_repacking");
            //  lblrecords.Text = dgv_table.RowCount.ToString();
            // textBox1.Text = dgv_table.RowCount.ToString();
            //RawMaster_header();
        }
        void loadStandardWeight()
        {
            ready = false;

            xClass.fillComboBoxRepacking(cboStandardWeight, "standard_weight", dSet);
            //displayData(Convert.ToInt32(cboStandardWeight.SelectedValue.ToString()));

            ready = true;

        }

        void loadFeedCode()
        {
            ready = false;

            xClass.fillComboBoxRepacking(cboFeedCode, "feed_code_formula_recipe", dSet);
            //displayData(Convert.ToInt32(cboStandardWeight.SelectedValue.ToString()));

            ready = true;

        }
        private void readData()
        {
           // label1.Text = serialPort1.ReadExisting();


        }

        void CallOther()
        {
            //groupBox7.Visible = false;

            tabControl1.Visible = false;
            txtweighingscale.Select();
            txtmainstocks.Text = "0";
            txtselectweight.Text = "0";
           dtprepackdate.Value = DateTime.Now;
            txtmainsearch.Focus();
           ////groupBox5.Visible = false;
            //tabPage3.Visible = false;
            //tabPage2.Visible = false;

        }
        void HideFunctions()
        {
            textBox1.Visible = false;
            label11.Visible = false;
            //groupBox5.Visible = false;
            //btnSubmit.Visible = false;
            lblmicroview.Visible = false;
            lblnoted.Visible = false;
            button2.Visible = false;
            dataView.Visible = false;
            dgvMaster.Visible = false;
            dgv_table_2nd_sup.Visible = false;
        }
        void DisableTextBox()

        {

            //GroupBOXES
            //groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;


            Button1.Enabled = false;

            btnbrowse.Enabled = false;
            txtSubSupplier.Enabled = false;
                txtSubItemCode.Enabled = false;
            txtSubQty.Enabled = false;
            txtSubQtyShared.Enabled = false;
            txtSubexpired.Enabled = false;
            txtSubActual.Enabled = false;
            txtsearch.Enabled = false;
            txtActualQty.Enabled = false;
          //  txtselectweight.Enabled = false;
            txtBalance.Enabled = false;

            //menu
            txtID.Enabled = false;
            dtpreceivingdate.Enabled = false;
            txtItemDescription.Enabled = false;
            txtMainSupplier.Enabled = false;
            cboCategory.Enabled = false;
            txtxp.Enabled = false;
            txtItemCode.Enabled = false;

            txtqtymissing.Enabled = false;

            mfg_datePicker.Enabled = false;
            xpired.Enabled = false;
            dtprepackdate.Enabled = false;
        }



        public void load_micro_receiving_entry()
        {
            string mcolumns = "test,received_id,r_item_code,r_totalnstock,r_mfg_date,r_expiry_date,days_to_expired";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgv_table, mcolumns, "raw_material_partial_receiving");
          //  lblrecords.Text = dgv_table.RowCount.ToString();
            // textBox1.Text = dgv_table.RowCount.ToString();
            micro_materials_header();
        }

        void micro_materials_header()
        {
            dgv_table.Columns[0].HeaderText = "ID";
            dgv_table.Columns[1].HeaderText = "Code";
            dgv_table.Columns[2].HeaderText = "Stocks";
            dgv_table.Columns[3].HeaderText = "No.Repacking";
            dgv_table.Columns[4].HeaderText = "Available";
            dgv_table.Columns[5].HeaderText = "Expiration";
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


        void RawMaster_header()
        {
            dgvMaster.Columns[0].HeaderText = "ID";
            dgvMaster.Columns[1].HeaderText = "Item Code";
            dgvMaster.Columns[2].HeaderText = "Description";
            dgvMaster.Columns[3].HeaderText = "Qty Stocks";
            dgvMaster.Columns[4].HeaderText = "Repack Available";




            //this.dgv_table.Columns["per_bag"].Frozen = true;



        }






        public void load_StockoutEntry()
        {
            string mcolumns = "test,r_item_id,received_id,r_item_code,r_supplier,totalnstock,selected_uom,uniquedate,days_to_expired,r_qty_delivered";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgvStockout, mcolumns, "raw_material_micro_Stockout");
            //  lblrecords.Text = dgv_table.RowCount.ToString();
            // textBox1.Text = dgv_table.RowCount.ToString();
            //micro_2ndSupplier_header();
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
            dgv_table_2nd_sup.Columns[7].HeaderText = "Expiration";
  
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
                    if (dgv_table.CurrentRow.Cells["received_id"].Value != null)
                    {
                        p_id = Convert.ToInt32(dgv_table.CurrentRow.Cells["received_id"].Value);
                        txtID.Text = dgv_table.CurrentRow.Cells["received_id"].Value.ToString();
                        txtsearch.Text = dgv_table.CurrentRow.Cells["r_item_code"].Value.ToString();
                        txtItemDescription.Text = dgv_table.CurrentRow.Cells["r_item_description"].Value.ToString();
                        txtMainSupplier.Text = dgv_table.CurrentRow.Cells["r_supplier"].Value.ToString();                        txtxp.Text = dgv_table.CurrentRow.Cells["days_to_expired"].Value.ToString();
                        cboCategory.Text = dgv_table.CurrentRow.Cells["r_item_category"].Value.ToString();

                        txtqtymissing.Text = dgv_table.CurrentRow.Cells["selected_uom"].Value.ToString();
                        txtItemCode.Text = dgv_table.CurrentRow.Cells["r_item_code"].Value.ToString();

                        mfg_datePicker.Text = dgv_table.CurrentRow.Cells["r_mfg_date"].Value.ToString();
                       xpired.Text = dgv_table.CurrentRow.Cells["r_expiry_date"].Value.ToString();
                        txtActualQty.Text = dgv_table.CurrentRow.Cells["r_qty_delivered"].Value.ToString();
                        dtpreceivingdate.Text = dgv_table.CurrentRow.Cells["r_receiving_date"].Value.ToString();
                        //txtContactNo.Text = dgv1.CurrentRow.Cells["contact_no"].Value.ToString();
                        //txtAddress.Text = dgv1.CurrentRow.Cells["address"].Value.ToString();
                        //txtEmailAddress.Text = dgv1.CurrentRow.Cells["email_address"].Value.ToString();

                    }
           
                }
            }

        }



        private void btnbrowse_Click(object sender, EventArgs e)
        {

            load_2ndSupplier();
        }



  




        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            ////   doSearch();

            String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=hr_bak;Integrated Security=SSPI";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);

    

            string sqlquery = "select r_item_id,received_id,r_item_code,r_supplier,totalnstock,selected_uom,uniquedate,days_to_expired from [dbo].[rdf_microreceiving_entry] WHERE r_item_code='" + txtsearch.Text + "' ORDER BY days_to_expired ASC";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery,sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgv_table_2nd_sup.DataSource = dt;
            sql_con.Close();







        }

        private void txtSubSupplier_TextChanged(object sender, EventArgs e)
        {

        }
        private delegate void Closure();
        private void SerialPortOnDataReceived(object sender, SerialDataReceivedEventArgs serialDataReceivedEventArgs)
        {
            if (InvokeRequired)     //<-- Makes sure the function is invoked to work properly in the UI-Thread
                BeginInvoke(new Closure(() => { SerialPortOnDataReceived(sender, serialDataReceivedEventArgs); }));     //<-- Function invokes itself
            else
            {
                int dataLength = _serialPort.BytesToRead;
                byte[] data = new byte[dataLength];
                int nbrDataRead = _serialPort.Read(data, 0, dataLength);
                if (nbrDataRead == 0)
                    return;
                string str = System.Text.Encoding.UTF8.GetString(data);
                txtweighingscale.Text = str.ToString();
            }
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            txtweighingscale.Enabled = true;
            dgvMaster_CurrentCellChanged(sender, e);
            dataView.Rows[i].Cells["selected"].Value = false;
            button2.Visible = false;
            clearpackingentry();
            Button1.Enabled = false;
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (txtweighingscale.Text.Trim() == string.Empty) 
            {
                //this.BackColor = Color.CornflowerBlue; lako kepamu be
                timer1.Enabled = true;
                            SendKeys.SendWait("{F7}"); // How to press enter?
                //if (txtselectweight.Text.Trim() == txtweighingscale.Text.Trim())
                //{
                //    MessageBox.Show("Same Data Proccesd!, Choose anothe entry Thanks:]");
                //    timer1.Stop();
                //    return;
                //}
                //else
                //{
                //    //MessageBox.Show("Error Not match!, Choose anothe entry Thanks:]");
                //}
            }
            else
            {

                if (txtselectweight.Text.Trim() == txtweighingscale.Text.Trim())
                {
                    timer1.Stop();
                    MessageBox.Show("Same Data Proccesd!, Choose anothe entry Thanks:]");
                    txtweighingscale.BackColor = Color.LightGreen;

                    textBox1.Visible = true;
                    label11.Visible = true;
                    txtweighingscale.Enabled = false;

                    textBox1.Select();
                    textBox1.Focus();
                    textBox1_Click(sender, e);
                    return;
                    if (textBox1.Text.Trim() == string.Empty)
                    {
                        textBox1.Select();
                        textBox1.Focus();
                        textBox1_Click(sender, e);
                        timer2_Tick(sender, e);
                        textBox1.Select();
                        textBox1.Focus();
                    }

                   
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

        private void frmrepackingentry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.K)
            {
                txtweighingscale.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtBalance.Text.StartsWith("-"))
            {
                //Code if negative
                //MessageBox.Show("Your Actual Qty Good is Higher than QA good, Please Try again. Found Negative Value!", txtBalance.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                //txtBalance.BackColor = Color.Yellow;
                //txtreject2.Visible = true;
                //txtreject2.BackColor = Color.Yellow;
                //return;
                if (txtshareddeb.Text.Trim() == string.Empty)
                {
                    ////bags computation
                    double bag1;
                    double bag2;
                    double baganswer;
                    //double Allowances;

                    bag1 = double.Parse(txtselectweight.Text);
                    bag2 = double.Parse(txtActualQty.Text);
                    ////baganswer = bag1 * 20;
                    baganswer = bag1 - bag2;
              //      Allowances = baganswer + 10;





                    MessageBox.Show("Please Select another Receiving Entry at the DataGrid !", "Sub Supplier Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //NeededProcedure();
                    dgvStockout.Visible = true;

                    txtneededqty.Text = Convert.ToString(baganswer);
                    return;

                }
                //start
                DialogResult dialogResult = MessageBox.Show("Your Actual Quantity is less than the selected Qty Do you want to Proceed ? ", "Select Receiving Entry Utang Muna?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //do something
                    //frmFullDepreciationReceiving zoro = new frmFullDepreciationReceiving();
                    //zoro.ShowDialog();


                    txtBalance.BackColor = Color.Yellow;

                    String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=hr_bak;Integrated Security=SSPI";

                    //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
                    SqlConnection sql_con = new SqlConnection(connetionString);



                    string sqlquery = "UPDATE [dbo].[rdf_microreceiving_entry] SET receiving_status = '0'  WHERE received_id = '" + txtID.Text + "'";

                    sql_con.Open();
                    SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
                    SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
                    DataTable dt = new DataTable();
                    sdr.Fill(dt);
                    dgvStockout.DataSource = dt;


                    //cboFeedType_SelectedValueChanged(sender, e);
                    //dgvImport.Refresh();
                    sql_con.Close();
                    txtrecommendedsearch_TextChanged(sender, e);
                    txtsearch_TextChanged_1(sender, e);

                    //end
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }


              

            }
            //main stocks computation
            ////double aldous1;
            ////double aldous2;
            ////double aldousstacktotal;

            ////aldous1 = double.Parse(txtmainstocks.Text);
            ////aldous2 = double.Parse(txtrpavailable.Text);
            ////aldousstacktotal = aldous1 - aldous2;

            ////txtmainstocks.Text = Convert.ToString(aldousstacktotal);


            if (txtselectweight.Text.Trim() == string.Empty)
            {

                MessageBox.Show("Please Select an Standard Weight", "Weighing Scale Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Information);

               cboDescription.Select();
                return;
    
            }


            if (txtweighingscale.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please check the Weighing Scale", "Weighing Scale Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtselectweight.Focus();
                txtselectweight.Select();
                txtweighingscale.BackColor = Color.Yellow;
                txtweighingscale_Click(sender, e);
                return;

            }
            if (txtselectweight.Text.Trim() == textBox1.Text.Trim())
            {
                MessageBox.Show("2nd Entry of Checking Actual Quantity Succesfully!", "Ready To Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Error", "Actual Quantity Change Immediately Error @ 2 Step checking Authentications", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtweighingscale_Click(sender, e);
                txtselectweight.Focus();
                txtselectweight.Select();
                txtweighingscale.BackColor = Color.Yellow;
                textBox1.BackColor = Color.LightGreen;
                timer2.Stop();
                return;
            }




            if (txtID.Text.Trim() == lblsupreceivedid.Text.Trim())
            {
                MessageBox.Show("Error same selection of Receiving Entry!, Choose anothe entry Thanks:]");
                return;
            }
            else
            {
               
            }


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
                MessageBox.Show("same 2 Step Validation Succeed!");

                //qty raw materia; repack available
                //first
                double rp1;
                double rp2;
                double rpavailable;

                rp1 = double.Parse(txtqtyoverall.Text);
                rp2 = double.Parse(txtselectweight.Text);

                rpavailable = rp1 + rp2;


                txtrpavailable.Text = Convert.ToString(rpavailable);






                mode = "add";
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




                            MessageBox.Show("Raw Materials Repack SuccesFully.", "Raw Material Repacking", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            txtmainsearch_TextChanged(sender, e); // 3 9 /2020

                            txtbind_TextChanged(sender, e); //  /3 /9 /20

                            txtlastpack_TextChanged(sender, e);  // searching methods
                            datalastpack_CurrentCellChanged(sender, e);  // 39 20

                            //load_RawNMaster(); Close MUna itech
                            groupBox7.Visible = true;
                            dataView.Visible = true;
                            loadPrintingData();
                            dataView.Rows[i].Cells["selected"].Value = true;
                            button2.Visible = true;
                            btnSubmit.Enabled = false;
                            Button1.Enabled = true;
                            //calling the dashboards!

                            //load_macro_count(); lakokepa



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

                }






            }
            else
            {
                MessageBox.Show("Confirm standard weight is not matched with actual weight..?");



                if (bag11 > bag22)
                {
                    MessageBox.Show("Lest THan kulang !");
                    groupBox1.Visible = true;
                    btnbrowse.Enabled = true;
                    groupBox5.Visible = true;
                    //////start
                    ////DialogResult dialogResult = MessageBox.Show("Your Low Entry Materials will be move at another Module ", "View Receiving Depreciation Entry ?", MessageBoxButtons.YesNo);
                    ////if (dialogResult == DialogResult.Yes)
                    ////{
                    ////    //do something
                    ////    frmFullDepreciationReceiving zoro = new frmFullDepreciationReceiving();
                    ////    zoro.ShowDialog();
                    ////}
                    ////else if (dialogResult == DialogResult.No)
                    ////{
                    ////    //do something else
                    ////}


                    ////String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=hr_bak;Integrated Security=SSPI";

                    //////        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
                    ////SqlConnection sql_con = new SqlConnection(connetionString);



                    ////string sqlquery = "UPDATE [dbo].[rdf_microreceiving_entry] SET receiving_status = '0'  WHERE received_id = '" + txtID.Text + "'";

                    ////sql_con.Open();
                    ////SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
                    ////SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
                    ////DataTable dt = new DataTable();
                    ////sdr.Fill(dt);
                    ////dgvStockout.DataSource = dt;


                    //////cboFeedType_SelectedValueChanged(sender, e);
                    //////dgvImport.Refresh();
                    ////sql_con.Close();
                    ////txtrecommendedsearch_TextChanged(sender, e);
                    ////txtsearch_TextChanged_1(sender, e);

                    //////end

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
                    txtweighingscale_Click(sender,e);
                    return;
                }



                return;
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



        }




        public bool saveMode()
        {

            if (mode == "add")
            {
                dSet.Clear();
                dSet = objStorProc.rdf_sp_new_micro_repacking(0, txtID.Text, cboCategory.Text, txtItemDescription.Text, "", "", "","", "", "", "","","", "", "", "", "", "","", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "","","","","","","","","","","","","","","","","","","","", "getbyname");

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
                    dSets = objStorProc.rdf_sp_new_micro_repacking(0, txtID.Text.Trim(), cboCategory.Text.Trim(), txtItemCode.Text.Trim(), txtMainSupplier.Text.Trim(), txtItemDescription.Text.Trim(), "Good", txttotalofStock.Text.Trim(), mfg_datePicker.Text.Trim(), xpired.Text.Trim(), txtwhreject.Text.Trim(), txtxp.Text.Trim(), dtpreceivingdate.Text.Trim(), txtItemDescription.Text.Trim(), txtwhgood.Text.Trim(), txtwhreject.Text.Trim(), txtuom.Text.Trim(), "0", "0", "1", mfg_datePicker.Text.Trim(), xpired.Text.Trim(), txtqtyordered.Text.Trim(), txtQAby.Text.Trim(), txtexpected.Text.Trim(), txtqtymissing.Text.Trim(), txtactualreceived.Text.Trim(), txtQAgood.Text.Trim(), txtQAreject.Text.Trim(), txtwhreceiving.Text.Trim(), txtqtytotaldelivered.Text.Trim(), txtwaitingdeliver.Text.Trim(),txtselectweight.Text.Trim(),txtrepackby.Text.Trim(), txtmainstocks.Text.Trim(),txtBalance.Text.Trim(), txtneededqty.Text.Trim(), txtshareddeb.Text.Trim(),txtprimarypo.Text.Trim(),txtrpavailable.Text.Trim(),txtbatch.Text.Trim(),cboDescription.Text.Trim(),txtSubSupplier.Text.Trim(), lblsupreceivedid.Text.Trim(),txtSubItemCode.Text.Trim(),txtSubDateReceived.Text.Trim(),txtSubexpired.Text.Trim(),txtSubQty.Text.Trim(),txtSubQtyShared.Text.Trim(),txtSubActual.Text.Trim(),txtfinalstring.Text.Trim(),"MICROKA","","","", "add");

      
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
























        private void txtweighingscale_Click(object sender, EventArgs e)
        {
            // SendKeys.SendWait("{F7}"); // How to press enter?

            timer1_Tick(sender, e); 
            //lakoe kepa 2/21/2020
        }

        private void txtweighingscale_TextChanged(object sender, EventArgs e)
        {
            //SendKeys.SendWait("{F7}"); // How to press enter?
            //try
            //{


            //    textBox1.Text = (float.Parse(txtweighingscale.Text) * 1).ToString();
            //}
            //catch (Exception)
            //{


            //}

        }

        private void btngenerateid_Click(object sender, EventArgs e)
        {
            frmGenerateRepackingBarcodeID packingid = new frmGenerateRepackingBarcodeID();
            packingid.ShowDialog();
        }

        private void txtweighingscale_MouseLeave(object sender, EventArgs e)
        {
            //timer1.Enabled = false;
        }

        private void dgv_table_DoubleClick(object sender, EventArgs e)
        {

            showMicroProfile();
            //  frmMicroProfile MicroViews = new frmMicroProfile();
            microviews.ShowDialog();
   

        
        }


        void showMicroProfile()
        {
            if (dgv_table.RowCount > 0)
            {
                if (dgv_table.CurrentRow != null)
                {
                    if (dgv_table.CurrentRow.Cells["received_id"].Value != null)
                    {
                        try
                        {
                            myglobal.temp_id = Convert.ToInt32(dgv_table.CurrentRow.Cells["received_id"].Value);
                            microviews.temp_id = Convert.ToInt32(dgv_table.CurrentRow.Cells["received_id"].Value);
                            microviews.received_id = dgv_table.CurrentRow.Cells["received_id"].Value.ToString();
                            //microviews.r_item_id = dgv_table.CurrentRow.Cells["r_item_id"].Value.ToString();
                            microviews.r_item_description = dgv_table.CurrentRow.Cells["r_item_description"].Value.ToString();
                            microviews.r_supplier = dgv_table.CurrentRow.Cells["r_supplier"].Value.ToString();
                            microviews.r_item_category = dgv_table.CurrentRow.Cells["r_item_category"].Value.ToString();
                            microviews.days_to_expired = dgv_table.CurrentRow.Cells["days_to_expired"].Value.ToString();
                            microviews.r_item_code = dgv_table.CurrentRow.Cells["r_item_code"].Value.ToString();
                            microviews.r_classification = dgv_table.CurrentRow.Cells["r_classification"].Value.ToString();
                            microviews.selected_uom = dgv_table.CurrentRow.Cells["selected_uom"].Value.ToString();
                            microviews.r_quantity = dgv_table.CurrentRow.Cells["r_quantity"].Value.ToString();
                            microviews.actual_count_good = dgv_table.CurrentRow.Cells["actual_count_good"].Value.ToString();
                            microviews.actual_count_reject = dgv_table.CurrentRow.Cells["actual_count_reject"].Value.ToString();
                            //microviews.address = dgv_table.CurrentRow.Cells["address"].Value.ToString();
                            //microviews.email_address = dgv_table.CurrentRow.Cells["email_address"].Value.ToString();
                            //microviews.item_location = dgv_table.CurrentRow.Cells["item_location"].Value.ToString();
                            //microviews.item_remarks = dgv_table.CurrentRow.Cells["item_remarks"].Value.ToString();
                            //microviews.total_quantity_raw = dgv_table.CurrentRow.Cells["total_quantity_raw"].Value.ToString();
                            //microviews.added_by = dgv_table.CurrentRow.Cells["item_added_by"].Value.ToString();




                            //  microviews.date = dgv_table.CurrentRow.Cells["emp.added_by"].Value.ToString();
                            //microviews.dateadded = Convert.ToDateTime(dgv_table.CurrentRow.Cells["date_added"].Value.ToString());
                            //coment   microviews.expirationdetails = Convert.ToDateTime(dgv_table.CurrentRow.Cells["expiration_details"].Value.ToString());
                            //microviews.expirationdetails = dgv_table.CurrentRow.Cells["expiration_details"].Value.ToString();
                            //microviews.delivery_details = dgv_table.CurrentRow.Cells["delivery_details"].Value.ToString();
                            //microviews.per_bag = dgv_table.CurrentRow.Cells["per_bag"].Value.ToString();



                            //        employee.section = dgv_table.CurrentRow.Cells["section_name"].Value.ToString();
                            //        employee.position = dgv_table.CurrentRow.Cells["position_name"].Value.ToString();
                            //        employee.employee_status = dgv_table.CurrentRow.Cells["employment_status_name"].Value.ToString();
                            //       employee.birthdate = Convert.ToDateTime(dgv_table.CurrentRow.Cells["birthdate"].Value.ToString());
                            //       employee.datehired = Convert.ToDateTime(dgv_table.CurrentRow.Cells["date_hired"].Value.ToString());
                            //     employee.tax_name = dgv_table.CurrentRow.Cells["tax_name"].Value.ToString();
                            //         employee.philhealth_no = dgv_table.CurrentRow.Cells["philhealth_number"].Value.ToString();
                            //     employee.hdmf_no = dgv_table.CurrentRow.Cells["hdmf_number"].Value.ToString();
                            //      employee.hdmf_rtn = dgv_table.CurrentRow.Cells["hdmf_rtn"].Value.ToString();
                            //       employee.salaryrate = dgv_table.CurrentRow.Cells["salary_rate"].Value.ToString();


                            if (!re)
                            {
                                //  employee.permanendAddress = dgv_table.CurrentRow.Cells["PermanentAddress"].Value.ToString();

                            }


                            //   myglobal.loan_type = dgv_table.CurrentRow.Cells["employee_number"].Value.ToString();
                            //   myglobal.employee_name = dgv_table.CurrentRow.Cells["lastname"].Value.ToString() + " , " + dgv_table.CurrentRow.Cells["firstname"].Value.ToString();
                            //    employee.Ros_hrd = dgv_table.CurrentRow.Cells["Ros_hrd"].Value.ToString();
                            //    employee.Remarks = dgv_table.CurrentRow.Cells["Remarks"].Value.ToString();
                        }
                        catch (FormatException)
                        {

                            MessageBox.Show("Ooops! Something went wrong.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtsearch.Focus();
                            return;
                        }

                    }
                }
            }
        }

        private void cboStandardWeight_SelectedIndexChanged(object sender, EventArgs e)
        {
    
            if (ready == true)
                //displayData(Convert.ToInt32(cboStandardWeight.SelectedValue.ToString()));
                txtbatch.Text = cboStandardWeight.SelectedValue.ToString();

            //qty raw materia; repack available
            //double rp1;
            //double rp2;
            //double rpavailable;

            //rp1 = double.Parse(txtqtyoverall.Text);
            //rp2 = double.Parse(txtselectweight.Text);

            //rpavailable = rp1 + rp2;


            //txtrpavailable.Text = Convert.ToString(rpavailable);



            //lako1 to
            //qty raw materia; repack available
            ////double rp1;
            ////double rp2;
            ////double rpavailable;

            ////rp1 = double.Parse(txtqtyoverall.Text);
            ////rp2 = double.Parse(txtselectweight.Text);

            ////rpavailable = rp1 + rp2;


            ////txtrpavailable.Text = Convert.ToString(rpavailable);




        
            ////bags computation
            //double bag1;
            //double bag2;
            //double baganswer;

            //bag1 = double.Parse(txtActualQty.Text);
            //bag2 = double.Parse(txtselectweight.Text);
            ////baganswer = bag1 * 20;
            //baganswer = bag1 - bag2;

            //txtBalance.Text = Convert.ToString(baganswer);
            //baganswer = Math.Round(baganswer);

            try
            {
                txtBalance.Text = (float.Parse(txtActualQty.Text) - float.Parse(txtselectweight.Text)).ToString();
            }
            catch (Exception)
            {


            }







            //this.textB.Text += Environment.NewLine + this.comboBox1.SelectedItem;
            txtweighingscale.Focus();
        }

        void displayData(int dept_id)
        {
            //dset_section = objStorProc.sp_getFilterTables("filter_section_by_department_id", "", dept_id);

            //if (dset_section.Tables.Count > 0)
            //{
            //    DataView dv = new DataView(dset_section.Tables[0]);
            //  //  dgv1.DataSource = dv;
            //}

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtAddedBy_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgv_table_2nd_sup_CurrentCellChanged(object sender, EventArgs e)
        {

        }

        private void txtsearch_TextChanged_1(object sender, EventArgs e)
        {
            String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=hr_bak;Integrated Security=SSPI";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "select r_item_id,received_id,r_item_code,totalnstock,r_mfg_date,r_expiry_date,days_to_expired,r_expected,r_actual_receiving,r_qty_delivered,QA_rgood,QA_reject,r_item_description,r_supplier,r_item_Category,r_qty_ordered,r_missing,actual_count_good,actual_count_reject,selected_uom,r_QA_by,r_receiving_by,r_total_delivered,r_waiting_delivered,r_primary_key,r_qty_delivered from [dbo].[rdf_microreceiving_entry] WHERE r_item_code='" + txtsearch.Text + "' AND receiving_status='1' ORDER BY days_to_expired ASC";
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

    


      

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (tabControl1.SelectedTab == tabPage1)
            //{
            //    //MessageBox.Show("TASK LIST PAGE");
            //}
            //else if (tabControl1.SelectedTab == tabPage2)
            //{
            //    //panel_title.Visible = false;
            //    //txtsearch.
            //    //  MessageBox.Show("SCHEDULE PAGE");

            //}
        }

        private void dgv_table_2nd_sup_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void dgv_table_CurrentCellChanged_1(object sender, EventArgs e)
        {
          
        }



        void showValueMicroMaster()
        {

            if (dgvMaster.RowCount > 0)
            {
                if (dgvMaster.CurrentRow != null)
                {
                    if (dgvMaster.CurrentRow.Cells["item_id"].Value != null)
                    {
                        p_id = Convert.ToInt32(dgvMaster.CurrentRow.Cells["item_id"].Value);
                
                        txtsearch.Text = dgvMaster.CurrentRow.Cells["item_code"].Value.ToString();

                        txtrecommendedsearch.Text = dgvMaster.CurrentRow.Cells["item_code"].Value.ToString();
                        txtqtyoverall.Text = dgvMaster.CurrentRow.Cells["qty_repack_available"].Value.ToString();
                        //txtmainstocks.Text = dgvMaster.CurrentRow.Cells["total_quantity_raw"].Value.ToString(); alsi muna

                        txtfuck.Text = dgvMaster.CurrentRow.Cells["qty_repack"].Value.ToString();


                        txtstatic.Text = dgvMaster.CurrentRow.Cells["total_quantity_raw"].Value.ToString();

                        cboCategor.Text = dgvMaster.CurrentRow.Cells["item_description"].Value.ToString();






                        //wala muna this


                    }

                }
            }

        }

        private void dgvMaster_CurrentCellChanged(object sender, EventArgs e)
        {
            showValueMicroMaster();
      
        }

        private void dgvMaster_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgv_table_2nd_sup.Visible = true;
            lblnoted.Visible = true;
            //tabControl1.SelectedTab = tabPage3;
        }

        private void txtmainsearch_TextChanged(object sender, EventArgs e)
        {
            String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=hr_bak;Integrated Security=SSPI";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "select item_id,item_code,item_description,total_quantity_raw,qty_repack_available,qty_repack from [dbo].[rdf_raw_materials] WHERE item_code = '" + txtmainsearch.Text + "' or item_description ='" + txtmainsearch.Text + "%' AND Category='MICRO' ";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvMaster.DataSource = dt;
            dgvMaster.Visible = true;
            //dgv_table_2nd_sup.Visible = true;
            lblmicroview.Visible = true;
            sql_con.Close();



            if (txtmainsearch.Text.Trim() == string.Empty)
            {
                load_micro_receiving_entry();

            }
        }

        private void dgv_table_2nd_sup_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        public void load_2ndSupplier()
        {


            string mcolumns = "test,r_item_id,received_id,r_item_code,totalnstock,r_mfg_date,r_expiry_date,days_to_expired,r_expected,r_item_description,r_actual_receiving,r_supplier,r_item_category,r_qty_delivered,r_qty_ordered,r_missing,actual_count_good,actual_count_reject,selected_uom,QA_reject,QA_rgood,r_QA_by,r_receiving_by,r_total_delivered,r_waiting_delivered,r_primary_key";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgv_table_2nd_sup, mcolumns, "raw_material_micro_dosSupplier");

            //pointer_module.populateModule(dsetHeader, dgv_table, mcolumns, "raw_material_partial_receiving");
            //string mcolumns = "test,r_item_id,received_id,r_item_code,r_supplier,totalnstock,selected_uom,uniquedate,days_to_expired,r_item_description";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            //pointer_module.populateModule(dsetHeader, dgv_table_2nd_sup, mcolumns, "raw_material_micro_dosSupplier");




            //  lblrecords.Text = dgv_table.RowCount.ToString();
            // textBox1.Text = dgv_table.RowCount.ToString();
            //micro_2ndSupplier_header();
        }
        private void dgv_table_2nd_sup_CellClick_2(object sender, DataGridViewCellEventArgs e)
        {

            txtselectweight.Text = "";
            txtBalance.Text = "";
            //if (dgv_table_2nd_sup.Rows.Count > -1)
            //{
            //    txtSubSupplier.Text = dgv_table_2nd_sup.Rows[e.RowIndex].Cells[3].Value.ToString();
            //    txtSubItemCode.Text = dgv_table_2nd_sup.Rows[e.RowIndex].Cells[2].Value.ToString();
            //    txtSubQty.Text = dgv_table_2nd_sup.Rows[e.RowIndex].Cells[4].Value.ToString();
            //    txtSubDateReceived.Text = dgv_table_2nd_sup.Rows[e.RowIndex].Cells[6].Value.ToString();
            //    txtSubexpired.Text = dgv_table_2nd_sup.Rows[e.RowIndex].Cells[7].Value.ToString();

            //    txtItemDescription.Text = dgv_table_2nd_sup.Rows[e.RowIndex].Cells[6].Value.ToString();
            //    txtMainSupplier.Text = dgv_table_2nd_sup.Rows[e.RowIndex].Cells[3].Value.ToString();

            //    txtID.Text = dgv_table_2nd_sup.Rows[e.RowIndex].Cells[0].Value.ToString();
            //    txtItemCode.Text = dgv_table_2nd_sup.Rows[e.RowIndex].Cells[2].Value.ToString();
            //    txtexpected.Text = dgv_table_2nd_sup.Rows[e.RowIndex].Cells[7].Value.ToString();

            //    //2nd marami datang dito

            //    //txtItemDescription.Text = dgv_table_2nd_sup.CurrentRow.Cells["r_item_description"].Value.ToString();
            //    //txtMainSupplier.Text = dgv_table_2nd_sup.CurrentRow.Cells["r_supplier"].Value.ToString();

            //    //lbldashboard1.Text = dgv_table_2nd_sup.CurrentRow.Cells["totalnstock"].Value.ToString();
            //    //txtxp.Text = dgv_table_2nd_sup.CurrentRow.Cells["days_to_expired"].Value.ToString();
            //    //cboCategory.Text = dgv_table_2nd_sup.CurrentRow.Cells["r_item_category"].Value.ToString();
            //    //lblactualgood.Text = dgv_table_2nd_sup.CurrentRow.Cells["actual_count_good"].Value.ToString();
            //    //lblactualreject.Text = dgv_table.CurrentRow.Cells["actual_count_reject"].Value.ToString();
            //    //txtuom.Text = dgv_table.CurrentRow.Cells["selected_uom"].Value.ToString();
            //    //txtItemCode.Text = dgv_table.CurrentRow.Cells["r_item_code"].Value.ToString();
            //    //lbldelivered.Text = dgv_table.CurrentRow.Cells["r_qty_delivered"].Value.ToString();
            //    //lblqtyordered.Text = dgv_table.CurrentRow.Cells["r_qty_ordered"].Value.ToString();
            //    //mfg_datePicker.Text = dgv_table.CurrentRow.Cells["r_mfg_date"].Value.ToString();
            //    //xpired.Text = dgv_table.CurrentRow.Cells["r_expiry_date"].Value.ToString();
            //    //txtActualQty.Text = dgv_table.CurrentRow.Cells["r_qty_delivered"].Value.ToString();
            //    //dtpreceivingdate.Text = dgv_table.CurrentRow.Cells["r_receiving_date"].Value.ToString();


            //}



            //tabControl1.SelectedTab = tabPage1;


            tabControl1.Visible = true;
            tabControl1.SelectedTab = tabPage1;

            groupBox2.Visible = true;
            //groupBox3.Visible = true;
            groupBox4.Visible = true;
        }

        private void dgv_table_2nd_sup_CurrentCellChanged_1(object sender, EventArgs e)
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
      txtItemCode.Text = dgv_table_2nd_sup.CurrentRow.Cells["r_item_code2"].Value.ToString();
                        txttotalofStock.Text = dgv_table_2nd_sup.CurrentRow.Cells["totalnstock2"].Value.ToString();

                        txtItemDescription.Text = dgv_table_2nd_sup.CurrentRow.Cells["r_item_description"].Value.ToString();
                        txtMainSupplier.Text = dgv_table_2nd_sup.CurrentRow.Cells["r_supplier2"].Value.ToString();
                        //lbldashboard1.Text = dgv_table.CurrentRow.Cells["totalnstock"].Value.ToString();
                        txtxp.Text = dgv_table_2nd_sup.CurrentRow.Cells["days_to_expired2"].Value.ToString();
                        txtexpected.Text = dgv_table_2nd_sup.CurrentRow.Cells["r_expected"].Value.ToString();
                        txtactualreceived.Text = dgv_table_2nd_sup.CurrentRow.Cells["r_actual_receiving"].Value.ToString();
                        cboCategory.Text = dgv_table_2nd_sup.CurrentRow.Cells["r_item_category"].Value.ToString();
                        txtqtymissing.Text = dgv_table_2nd_sup.CurrentRow.Cells["r_missing"].Value.ToString();
                   txtwhgood.Text = dgv_table_2nd_sup.CurrentRow.Cells["actual_count_good"].Value.ToString();
                        txtwhreject.Text = dgv_table_2nd_sup.CurrentRow.Cells["actual_count_reject"].Value.ToString();
                        txtuom.Text = dgv_table_2nd_sup.CurrentRow.Cells["selected_uom2"].Value.ToString();
                        //txtItemCode.Text = dgv_table.CurrentRow.Cells["r_item_code"].Value.ToString();
                        //lbldelivered.Text = dgv_table.CurrentRow.Cells["r_qty_delivered"].Value.ToString();
                        txtqtyordered.Text = dgv_table_2nd_sup.CurrentRow.Cells["r_qty_ordered"].Value.ToString();
                        mfg_datePicker.Text = dgv_table_2nd_sup.CurrentRow.Cells["r_mfg_date"].Value.ToString();
                        xpired.Text = dgv_table_2nd_sup.CurrentRow.Cells["r_expiry_date"].Value.ToString();
                        txtActualQty.Text = dgv_table_2nd_sup.CurrentRow.Cells["r_qty_delivered2"].Value.ToString(); //remove qty_delivered

                        //txtActualQty.Text = dgv_table_2nd_sup.CurrentRow.Cells["r_qty_delivered2"].Value.ToString(); //remove qty_delivered
                        txtactualqtydeb.Text = dgv_table_2nd_sup.CurrentRow.Cells["r_qty_delivered2"].Value.ToString(); //remove qty_delivered
                        //dtpreceivingdate.Text = dgv_table.CurrentRow.Cells["r_receiving_date"].Value.ToString();
                        txtQAgood.Text = dgv_table_2nd_sup.CurrentRow.Cells["QA_rgood"].Value.ToString();
                        txtQAreject.Text = dgv_table_2nd_sup.CurrentRow.Cells["QA_reject"].Value.ToString();
                        txtQAby.Text = dgv_table_2nd_sup.CurrentRow.Cells["r_QA_by"].Value.ToString();
                        txtwhreceiving.Text = dgv_table_2nd_sup.CurrentRow.Cells["r_receiving_by"].Value.ToString();
                        txtqtytotaldelivered.Text = dgv_table_2nd_sup.CurrentRow.Cells["r_total_delivered"].Value.ToString();
                        txtwaitingdeliver.Text = dgv_table_2nd_sup.CurrentRow.Cells["r_waiting_delivered"].Value.ToString();
                        txtprimarypo.Text = dgv_table_2nd_sup.CurrentRow.Cells["r_primary_key"].Value.ToString();
                    }
                    //tabControl1.Visible = true;
                    //tabControl1.SelectedTab = tabPage1;
                 
                    //groupBox2.Visible = true;
                    ////groupBox3.Visible = true;
                    //groupBox4.Visible = true;
                }
            }

        }

        private void dgvStockout_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtselectweight.Select();
            txtselectweight.Focus();
            timer1_Tick(sender, e);

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

        private void txtrecommendedsearch_TextChanged(object sender, EventArgs e)
        {
            ////   doSearch();

            String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=hr_bak;Integrated Security=SSPI";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);

            //string sqlquery = "select item_id,item_code,item_description,total_quantity_raw from [dbo].[rdf_raw_materials] WHERE item_code like '%" + txtmainsearch.Text + "%' or item_description like '%" + txtmainsearch.Text + "%' ";
            //string sqlquery = "select TOP 2 r_item_id,received_id,r_item_code,r_supplier,totalnstock,selected_uom,uniquedate,r_qty_delivered,days_to_expired from [dbo].[rdf_microreceiving_entry] WHERE r_item_code='" + txtsearch.Text + "' AND r_qty_delivered BETWEEN '" + txtneededqty.Text + "' AND 40000 ORDER BY days_to_expired DESC";

            //string sqlquery = "select TOP 2 r_item_id,received_id,r_item_code,r_supplier,totalnstock,selected_uom,uniquedate,r_qty_delivered,days_to_expired from [dbo].[rdf_microreceiving_entry] WHERE r_item_code like '%" + txtrecommendedsearch.Text + "%' AND r_qty_delivered BETWEEN '" + txtneededqty.Text + "' AND 40000 ORDER BY days_to_expired DESC";
            string sqlquery = "select TOP 2 r_item_id,received_id,r_item_code,r_supplier,totalnstock,selected_uom,uniquedate,r_qty_delivered,days_to_expired from [dbo].[rdf_microreceiving_entry] WHERE r_item_code= '" + txtrecommendedsearch.Text + "' AND r_item_category='MICRO' AND receiving_status='1' ORDER BY days_to_expired ASC";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvStockout.DataSource = dt;
            sql_con.Close();


        }
        public void NeededProcedure()
        {


            String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=hr_bak;Integrated Security=SSPI";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);

            string sqlquery = "select TOP 2 r_item_id,received_id,r_item_code,r_supplier,totalnstock,selected_uom,uniquedate,r_qty_delivered,days_to_expired from [dbo].[rdf_microreceiving_entry] WHERE r_item_code like '%" + txtrecommendedsearch.Text + "%' AND r_qty_delivered BETWEEN '" + txtneededqty.Text + "' AND 40000 ORDER BY days_to_expired DESC";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvStockout.DataSource = dt;
            sql_con.Close();

        }




        private void dgvMaster_DoubleClick(object sender, EventArgs e)
        {
            //tabControl1.SelectedTab = tabPage2;
            //dataView.Visible = true;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            //myglobal.Searchcategory = txtSearchx.Text;
            //myglobal.employee_name = cmbHR_OIC.Text;//cmbHR_OIC.Text;
            //myglobal.position = cmbPos.Text;//cmbPos.Text;
            //myglobal.validity = dt.Text;

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

        

            if (mode == "company")
            {
                myglobal.REPORT_NAME = "IDRepackReport";

                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == DialogResult.OK)
  
                {
                    //CrystalDecisions.CrystalReports.Engine.ReportDocument reportDocument = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    rpt.Load(Rpt_Path + "\\IDRepackReportMain.rpt");

                    printDialog.AllowCurrentPage = true;
             

                    //rpt.Load(Rpt_Path + "\\IDRepackReport.rpt");
                    //////////rpt.SetDatabaseLogon("sa", "Nescafe3in1");
                    rpt.Refresh();

                    crV1.SelectionFormula = "{Command.rp_item_description} like '*" + myglobal.Searchcategory + "*' or  {Command.rp_classification} like '*" + myglobal.Searchcategory + "*'or  {Command.rp_item_code} like '*" + myglobal.Searchcategory + "*' or  {Command.rp_mfg_date} like '*" + myglobal.Searchcategory + "*'  AND  {Command.rp_expiry_date} like '*" + myglobal.Filter + "*'";






                    rpt.SetParameterValue("Approved", myglobal.rp_item_description);
                    rpt.SetParameterValue("Validity", myglobal.validity);
                    rpt.SetParameterValue("Position", myglobal.position);

                    crV1.ReportSource = rpt;
                    crV1.Refresh();



                    rpt.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;
           
                    rpt.PrintToPrinter(printDialog.PrinterSettings.Copies, printDialog.PrinterSettings.Collate, printDialog.PrinterSettings.ToPage, printDialog.PrinterSettings.ToPage);
                }



            }
            else if (mode == "hw")
            {
                myglobal.REPORT_NAME = "IDReport(HW)";
            }
            //frmReport frmReport = new frmReport();
        }

        private void txtsearchcode_TextChanged(object sender, EventArgs e)
        {
            String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=hr_bak;Integrated Security=SSPI";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
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

        private void button3_Click(object sender, EventArgs e)
        {
          
        }

        private void dgvMaster_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtmainsearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeypressHide();
        }
        void KeypressHide()
        {
            txtsearch.Text = "";
            tabControl1.Visible = false;
            dgv_table_2nd_sup.Visible = false;
        }

        private void cbocategor_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboCategory.Text.Trim() != "")
            {
                loadDescription();
                cboDescription.Text = "";
            }

        }

        void loadDescription()
        {
            ready = false;
            xClass.fillComboBoxFilter(cboDescription, "filter_rdf_raw_materials_repacking", dSet, cboCategor.Text, 0);
            ready = true;
            s_id = showValue(cboDescription);
        }

        public int showValue(ComboBox cbo)
        {
            int ids = 0;
            if (ready == true)
            {
                if (cbo.Items.Count > 0)
                {
                    ids = Convert.ToInt32(cbo.SelectedValue.ToString());
                }
            }
            return ids;
        }

        private void cboDescription_SelectedValueChanged(object sender, EventArgs e)
        {
            txtweighingscale.Focus();
            txtweighingscale.Select();

            txtweighingscale_Click(sender, e);
            dgv_table_2nd_sup_CurrentCellChanged_1(sender, e);//for support
            dgvMasterRaw_CurrentCellChanged(sender, e);//for support




        }

        private void cboDescription_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtweighingscale.Focus();
            txtweighingscale.Select();
            dgvMaster_CurrentCellChanged(sender,e);// lasing ako 2/23/2020
            dgvMasterRaw_CurrentCellChanged(sender, e);//for support
            txtActualFormula_TextChanged(sender, e);
            txtActualFormula_Click(sender, e);


            txtselectfeedform.Text = cboDescription.SelectedValue.ToString();

            //txtActualFormula.Text = dgvMasterRaw.CurrentRow.Cells["quantity"].Value.ToString();


            String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=hr_bak;Integrated Security=SSPI";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);

            ////txtmainsearch.Focus();
            ////txtmainsearch.Select();
            /////clear
            ///
            //txtselectweight.Clear(); alis muna 382020
            textBox1.Clear();

            //string sqlquery = "select item_id,item_category,item_code,item_description from [dbo].[rdf_raw_materials] WHERE item_code ='" + cboDescription.Text + "'";


            string sqlquery = "select distinct recipe_id,feed_type,quantity from [dbo].[rdf_recipe] WHERE recipe_id= '" + txtselectfeedform.Text + "' AND rp_category='MICRO' ";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvMasterRaw.DataSource = dt;
            //dgvMasterRaw.Visible = true;

            sql_con.Close();


            try
            {
                txtBalance.Text = (float.Parse(txtActualQty.Text) - float.Parse(txtselectweight.Text)).ToString("#0,000");
            }
            catch (Exception)
            {


            }


        }

        private void dgvMasterRaw_CurrentCellChanged(object sender, EventArgs e)
        {
            showValueFeedWeight();
  
        }

        public void showValueFeedWeight()
        {
            if (dgvMasterRaw.RowCount > 0)
            {
                if (dgvMasterRaw.CurrentRow != null)
                {
                    if (dgvMasterRaw.CurrentRow.Cells["recipe_id"].Value != null)
                    {
                        p_id = Convert.ToInt32(dgvMasterRaw.CurrentRow.Cells["recipe_id"].Value);
                        //txtID.Text = dgv_table.CurrentRow.Cells["received_id"].Value.ToString();
                        txtActualFormula.Text = dgvMasterRaw.CurrentRow.Cells["quantity"].Value.ToString();


                 

                    }

                }
            }



        }

        private void txtActualFormula_TextChanged(object sender, EventArgs e)
        {
            //if (txtActualFormula.Text.Trim() == string.Empty)
            //{
            //    ////bags computation

            //    txtActualFormula.Text = "2";
            //}
            //else
            //{

                //txtselectweight.Text = (float.Parse(txtActualFormula.Text) * 2).ToString("#,0.000");
            //}
        }

        private void cboStandardWeight_SelectedValueChanged(object sender, EventArgs e)
        {
           ////// txtselectweight.Text = "0";
           ////// //qty raw materia; repack available
           ////// double batch1;
           ////// double batch2;
           ////// double batch0;
           ////// double batchavailable;
           ////// double totalbatch;
           ////// string gago;

           ////// batch0 = double.Parse(txtActualFormula.Text);
           ////// batch1 = double.Parse(txtselectweight.Text);
           ////// batch2 = double.Parse(txtbatch.Text);

           ////// batchavailable = batch0 * 2;
           ////// totalbatch = batchavailable * batch2;

           //////gago =  totalbatch.ToString("#,0.000");


           ////// txtselectweight.Text = gago;
        }

        private void txtbatch_TextChanged(object sender, EventArgs e)
        {
            txtselectweight.Text = "0";
           
            //qty raw materia; repack available
            double batch1;
            double batch2;
            double batch0;
            double batchavailable;
            double totalbatch;
            string gago;

            batch0 = double.Parse(txtActualFormula.Text);
            batch1 = double.Parse(txtselectweight.Text);
            batch2 = double.Parse(txtbatch.Text);

            batchavailable = batch0 * 2;
            totalbatch = batchavailable * batch2;

            gago = totalbatch.ToString("#,0.000");


            txtselectweight.Text = gago;
        }

        private void txtselectweight_TextChanged(object sender, EventArgs e)
        {
 

            try
            {

              
                txtrpavailable.Text = (float.Parse(txtqtyoverall.Text) + float.Parse(txtselectweight.Text)).ToString("#,0.000");
            }
            catch (Exception)
            {


            }
        }

        private void txtrpavailable_TextChanged(object sender, EventArgs e)
        {
            if (txtqtyoverall.Text.Trim() == string.Empty)
            {
                try
                {

                    txtmainstocks.Text = (float.Parse(txtstatic.Text) - float.Parse(txtselectweight.Text)).ToString();//remove mainstocks txtselectweight

                }
                catch (Exception)
                {


                }


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

        private void btnstartrepacking_Click(object sender, EventArgs e)
        {
            txtweighingscale.Focus();
            txtweighingscale.Select();
            //timer1_Tick(sender, e);
        }

        private void txtweighingscale_Leave(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            //if (txtweighingscale.Focused == true)
            //{
            //    this.Activate();
            //    this.TopMost = true;
            //    txtweighingscale.Focus();
            //    txtweighingscale.Select();

            //}
        }

        private void txtweighingscale_MouseClick(object sender, MouseEventArgs e)
        {
            timer1_Tick(sender, e);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void dgvMasterRaw_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == string.Empty)
            {
                this.BackColor = Color.CornflowerBlue;
                timer2.Enabled = true;
                timer2.Start();
                SendKeys.SendWait("{F7}"); // How to press enter?
            }
            else
            {
                if (txtselectweight.Text.Trim() == textBox1.Text.Trim())
                {
                    timer2.Enabled = false;
                    timer2.Stop();
                    MessageBox.Show("Same Quantity Again!, Ready To Save Na!");
                   textBox1.BackColor = Color.LightGreen;
                    btnSubmit.Visible = true;
                    return;
           
                }
                else
                {

                }




                    this.BackColor = Color.Red;
                textBox1.Text = "";

                SendKeys.SendWait("{F7}"); // How to press enter?
                //timer1.Enabled = false;
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            timer2_Tick(sender, e);
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            timer2_Tick(sender, e);
        }

        private void txtselectfeedform_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtneededqty_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            txtselectweight.Clear();
            txtbatch.Text = "1";
            txtselectweight.Clear();

        }

        private void button4_Click(object sender, EventArgs e)


        {
            //DialogResult dialogResult = MessageBox.Show("Your Low Entry Materials will be move at another Module ", "View Receiving Depreciation Entry ?", MessageBoxButtons.YesNo);
            //if (dialogResult == DialogResult.Yes)
            //{
            //    //do something
            //    frmFullDepreciationReceiving zoro = new frmFullDepreciationReceiving();
            //    zoro.ShowDialog();
            //}
            //else if (dialogResult == DialogResult.No)
            //{
            //    //do something else
            //}


            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=hr_bak;Integrated Security=SSPI";

            ////        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            //SqlConnection sql_con = new SqlConnection(connetionString);



            //string sqlquery = "UPDATE [dbo].[rdf_microreceiving_entry] SET receiving_status = '0'  WHERE received_id = '" + txtID.Text + "'";

            //sql_con.Open();
            //SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            //SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            //DataTable dt = new DataTable();
            //sdr.Fill(dt);
            //dgvStockout.DataSource = dt;


            ////cboFeedType_SelectedValueChanged(sender, e);
            ////dgvImport.Refresh();
            //sql_con.Close();
            //txtrecommendedsearch_TextChanged(sender, e);
            //txtsearch_TextChanged_1(sender, e);

        }

        private void dgvStockout_CurrentCellChanged(object sender, EventArgs e)
        {
            //if (dgv_table_2nd_sup.Rows.Count > -1)
            //{
            //    txtSubSupplier.Text = dgvStockout.Rows[e.RowIndex].Cells[3].Value.ToString();
            //    txtSubItemCode.Text = dgvStockout.Rows[e.RowIndex].Cells[2].Value.ToString();
            //    txtSubQty.Text = dgvStockout.Rows[e.RowIndex].Cells[7].Value.ToString();
            //    txtSubDateReceived.Text = dgvStockout.Rows[e.RowIndex].Cells[6].Value.ToString();
            //    txtSubexpired.Text = dgvStockout.CurrentRow.Cells[.Value.ToString();
            //    lblsupreceivedid.Text = dgvStockout.Rows[e.RowIndex].Cells[1].Value.ToString();
            //}

            //if (dgv_table_2nd_sup.RowCount > 0)
            //{
            //    if (dgv_table_2nd_sup.CurrentRow != null)
            //    {
            //        if (dgv_table_2nd_sup.CurrentRow.Cells["received_id"].Value != null)
            //        {
            //            p_id = Convert.ToInt32(dgv_table_2nd_sup.CurrentRow.Cells["received_id"].Value);

            //       lblsupreceivedid.Text = dgv_table_2nd_sup.CurrentRow.Cells["received_id"].Value.ToString();

            //            //txtrecommendedsearch.Text = dgv_table_2nd_sup.CurrentRow.Cells["item_code"].Value.ToString();
            //            //txtqtyoverall.Text = dgv_table_2nd_sup.CurrentRow.Cells["qty_repack_available"].Value.ToString();
            //            //txtmainstocks.Text = dgv_table_2nd_sup.CurrentRow.Cells["total_quantity_raw"].Value.ToString();

            //            //cboCategor.Text = dgv_table_2nd_sup.CurrentRow.Cells["item_description"].Value.ToString();






            //            //wala muna this


            //        }

            //    }
            //}
        }

        private void dgv_table_2nd_sup_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtSubQtyShared_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtshareddeb_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSubQty_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboFeedCode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //txtselectweight.Text = "544";
            //try
            //{
            

            //    txtselectweight.Text = (float.Parse(textBox2.Text) * 2).ToString("#,0.000");
            //}
            //catch (Exception)
            //{


            //}
        }

        private void txtselectweight_TextChanged_1(object sender, EventArgs e)
        {



            try
            {


                txtrpavailable.Text = (float.Parse(txtfuck.Text) + float.Parse(txtselectweight.Text)).ToString("#,0.000");
            }
            catch (Exception)
            {


            }

        }

        private void dgv_table_2nd_sup_CursorChanged(object sender, EventArgs e)
        {

        }

        private void cboDescription_Click(object sender, EventArgs e)
        {
            dgvMaster_CurrentCellChanged(sender, e);
        }

        private void txtActualFormula_Click(object sender, EventArgs e)
        {
            txtselectweight.Text = (float.Parse(txtActualFormula.Text) * 2).ToString("#,0.000");
        }

        private void cboDescription_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtselectweight.Text = (float.Parse(txtActualFormula.Text) * 2).ToString("#,0.000");
        }

        private void txtmainstocks_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtrepackavailable_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtqtyoverall_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtlastpack_TextChanged(object sender, EventArgs e)
        {
            String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=hr_bak;Integrated Security=SSPI";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "select TOP 1 repack_id from [dbo].[rdf_repackin_entry] ORDER BY repack_id DESC ";
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


;






                        //wala muna this


                    }

                }
            }

        }

        private void txtfinalstring_TextChanged(object sender, EventArgs e)
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

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {

        }

        private void txtwhgood_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtfuck_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtprimarypo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtstatic_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboCategor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
