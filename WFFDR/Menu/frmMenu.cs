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
using System.Diagnostics;
using System.Threading;

namespace WFFDR
{
    public partial class frmMenu : Form
    {
        // new frmusers user;

       // String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=hr_bak;Integrated Security=SSPI";
        String connetionString = @"Server=localhost\SQLEXPRESS;Initial Catalog=hr_bak;Integrated Security=SSPI";

        //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
        SqlConnection sql_con = new SqlConnection();
        SqlDataAdapter sql_da = new SqlDataAdapter();
        SqlCommand sql_cmd = new SqlCommand();
        DataTable dt = new DataTable();


        int i;

        myclasses xClass = new myclasses();
        IStoredProcedures objStorProc = null;


        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();
        DataSet dSet_temp = new DataSet();
        DataSet dset_delete = new DataSet();
    
        frmMicroProfile microviews;
        DataSet dSet = new DataSet();
        DataSet dset_rights = new DataSet();

        //forms INSIDE
        frmProductionLevel NewUser;


 


        int rights_id = 0;
        int emp_flag = 0;

        bool re = false;

        public frmMenu()
        {
            InitializeComponent();
        }

        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_MouseLeave(object sender, EventArgs e)
        {

        }

        private void panel7_MouseHover(object sender, EventArgs e)
        {

        }

        private void panel6_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_MouseLeave(object sender, EventArgs e)
        {

        }

        private void panel6_MouseHover(object sender, EventArgs e)
        {

        }

        private void panel5_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_MouseLeave(object sender, EventArgs e)
        {

        }

        private void panel5_MouseHover(object sender, EventArgs e)
        {

        }

        private void panel4_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_MouseLeave(object sender, EventArgs e)
        {

        }

        private void panel4_MouseHover(object sender, EventArgs e)
        {

        }

        private void p_visitors_Click(object sender, EventArgs e)
        {

        }

        private void p_visitors_MouseLeave(object sender, EventArgs e)
        {

        }

        private void p_visitors_MouseHover(object sender, EventArgs e)
        {

        }

        private void p_phonebook_Click(object sender, EventArgs e)
        {

        }

        private void p_phonebook_Paint(object sender, PaintEventArgs e)
        {

        }

        private void p_phonebook_MouseLeave(object sender, EventArgs e)
        {

        }

        private void p_phonebook_MouseHover(object sender, EventArgs e)
        {

        }

        private void p_tardiness_Click(object sender, EventArgs e)
        {

        }

        private void p_tardiness_Paint(object sender, PaintEventArgs e)
        {

        }

        private void p_tardiness_MouseLeave(object sender, EventArgs e)
        {

        }

        private void p_tardiness_MouseHover(object sender, EventArgs e)
        {

        }

        private void p_tardiness_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void p_attendance_Click(object sender, EventArgs e)
        {

        }

        private void p_attendance_Paint(object sender, PaintEventArgs e)
        {

        }

        private void p_attendance_MouseLeave(object sender, EventArgs e)
        {

        }

        private void p_attendance_MouseHover(object sender, EventArgs e)
        {

        }

        private void panel3_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void samplingDataOutputToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void othersToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            // txtsearch.Focus();
            // MY DATAGRID

          //j timer2.Start();
            dgv_table.Height = this.Height - 170;
            dgv_table.Width = this.Width - 171;

            // MY DATAGRID MICRO MATERIALS
            dgv_tablemicro.Height = this.Height - 170;
            dgv_tablemicro.Width = this.Width - 171;
            dgv_tablemicro.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            dgv_table.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
          
           // Calling the Stored PROC 
            objStorProc = xClass.g_objStoredProc.GetCollections();


            //forms
            microviews = new frmMicroProfile();

     


            lblactivemodule.Text = "HOME";
            rights_id = userinfo.user_rights_id;


            // Date NOW with Timer Tools
            lblTime.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt");


            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, pictureBox1.Width - 3, pictureBox1.Height - 3);
            Region rg = new Region(gp);
            pictureBox1.Region = rg;

         


            HIDE();

            lblTip.Text = userinfo.emp_name.ToUpper();

            txtActive.Text = userinfo.emp_name.ToUpper();

            if (rights_id == 1 || rights_id == 2 || rights_id == 5)
            {
             //   mnuHolidays.Enabled = true;
              //  sicknessToolStripMenuItem.Enabled = true;

                if (rights_id == 2) // MIS
                {
                    // toolStripButton2.Visible = true;
                    bunifuFlatButton1.Enabled = false;
                }

               // bunifuFlatButton1.Visible = false;
            }

            }
        public void HIDE()
        {
            // menuStrip1.Visible = false;
          //  ToolStrip1USER.Visible = false;
            dgv_table.Visible = false;
            dgv_tablemicro.Visible = false;
            ToolStripButtonNew.Visible = false;
            ToolStripButtonEdit.Visible = false;
            toolStripButtonMYUP.Visible = false;
            ToolStripButtonUpdate.Visible = false;
            toolStripButtonDelete.Visible = false;
            ToolStripBCancel.Visible = false;
            toolStripButtonCancel2.Visible = false;

           labelSearch.Visible = false;
          txtsearch.Visible = false;

        }


        private void con_on()
        {
            sql_con = new SqlConnection();
            sql_con.ConnectionString = connetionString;
            sql_con.Open();
        }






        private void button1_Click(object sender, EventArgs e)
        {
          //  Application.Exit();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            // Application.Exit();
            this.WindowState = FormWindowState.Minimized;
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are You Sure That you want to Exit the Application", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.Yes)
            {
                //   Application.Exit();
                this.Close();

                Form1 una = new Form1();
                una.ShowDialog();

            }
            else if (dialogResult == DialogResult.No)
            {

            }

        

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {

        }

        private void calculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Calc.exe");

        }

        private void notepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Notepad.exe");
        }

        private void microsoftToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void microsoftWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("winword.exe");
        }

        private void microsoftExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("excel.exe");
        }

        private void powerPointToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("powerpnt.exe");
        }

        private void mnu_department_Click(object sender, EventArgs e)
        {

        }

        private void mnu_section_Click(object sender, EventArgs e)
        {

        }

        private void mnuposition_Click(object sender, EventArgs e)
        {

        }

        private void mnuHolidays_Click(object sender, EventArgs e)
        {

        }

        private void mnusickness_Click(object sender, EventArgs e)
        {

        }

        private void mnuleave_Click(object sender, EventArgs e)
        {

        }

        private void mnu_offense_Click(object sender, EventArgs e)
        {

        }

        private void availableMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void companyInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt");
        }

        private void bunifuFlatButton11_Click(object sender, EventArgs e)
        {
            //   frmusers users = new frmusers();
            //users.ShowDialog();
            panel_search.Visible = true;
            ToolStrip1USER.Visible = true;
            dgv_table.Visible = true;
            re = false;
            myglobal.global_module = "EMPLOYEE";
            //this.Text = "EMPLOYEE";
            lblactivemodule.Text = "EMPLOYEE";

            load_employees();
            btnresigned.Visible = emp_flag == 0 ? true : false;

            //

            ToolStripButtonNew.Visible = true;
            ToolStripButtonEdit.Visible = true;
            toolStripButtonMYUP.Visible = true;
            ToolStripButtonUpdate.Visible = true;
            toolStripButtonDelete.Visible = true;
            ToolStripBCancel.Visible = true;
            toolStripButtonCancel2.Visible = true;

            labelSearch.Visible = true;
            txtsearch.Visible = true;



            //




            //btnresigned.Visible = true;
            p_posted.Visible = false;


            emp_flag = 0;

        }

        void load_employees()
        {

            string mcolumns;   //= "test,emp.employee_id,employee_number,firstname,lastname,middlename,gender,address,contactno,birthdate,civil_status_name,sss_number,tin_number,philhealth_number,hdmf_number,hdmf_rtn,department_name,section_name,position_name,employment_status_name,date_hired,date_regularization,tax_name,salary_rate,salary_structure,salary_type_name,workers_name,in_case_of_emergency_name,in_case_of_emergency_contact_number";
                               //mcolumns; 
            if (emp_flag == 0)
            {
                mcolumns = "test,emp.employee_id,employee_number,firstname,lastname,middlename,gender,address,contactno,birthdate,civil_status_name,sss_number,tin_number,philhealth_number,hdmf_number,hdmf_rtn,department_name,section_name,position_name,employment_status_name,date_hired,date_regularization,tax_name,salary_rate,salary_structure,salary_type_name,workers_name,in_case_of_emergency_name,in_case_of_emergency_contact_number,PermanentAddress,Ros_hrd,Remarks";
                pointer_module.populateModule(dsetHeader, dgv_table, mcolumns, "employee");
            }
            else if (emp_flag == 2)
            {
                mcolumns = "test,emp.employee_id,employee_number,firstname,lastname,middlename,gender,address,contactno,birthdate,civil_status_name,sss_number,tin_number,philhealth_number,hdmf_number,hdmf_rtn,department_name,section_name,position_name,employment_status_name,date_hired,date_regularization,tax_name,salary_rate,salary_structure,salary_type_name,workers_name,in_case_of_emergency_name,in_case_of_emergency_contact_number,date_resigned,PermanentAddress,Ros_hrd,Remarks";
                pointer_module.populateModule(dsetHeader, dgv_table, mcolumns, "employee_b");
            }

            lblrecords.Text = dgv_table.RowCount.ToString();

            employee_header();
            load_search();

            emp_flag = 0;
        }
        void load_micro_materials()
        {

            string mcolumns;   //= "test,emp.employee_id,employee_number,firstname,lastname,middlename,gender,address,contactno,birthdate,civil_status_name,sss_number,tin_number,philhealth_number,hdmf_number,hdmf_rtn,department_name,section_name,position_name,employment_status_name,date_hired,date_regularization,tax_name,salary_rate,salary_structure,salary_type_name,workers_name,in_case_of_emergency_name,in_case_of_emergency_contact_number";
                               //mcolumns; 
            if (emp_flag == 0)
            {
                mcolumns = "item_id,item_code,category_name,item_description,classification,quantity,supplier,address,contact_no,date_added,expiration_details,delivery_details";
                pointer_module.populateModule(dsetHeader, dgv_tablemicro, mcolumns, "micro_raw_materials");
            }
            else if (emp_flag == 2)
            {
                mcolumns = "emp.item_id,emp.item_id,emp.supplier,emp.item_description,emp.classification,emp.quantity,emp.date_added,emp.expiration_details,emp.delivery_details";
                pointer_module.populateModule(dsetHeader, dgv_tablemicro, mcolumns, "micro_raw_materials");
            }

            lblrecords.Text = dgv_tablemicro.RowCount.ToString();

            micro_materials_header();
       //    load_searchMicro();

            emp_flag = 0;
        }






        DataSet dset_emp = new DataSet();



        void employee_header()
        {
            dgv_table.Columns[0].HeaderText = "ID";
            dgv_table.Columns[1].HeaderText = "Employee #";
            dgv_table.Columns[2].HeaderText = "First Names";
            dgv_table.Columns[3].HeaderText = "Last Name";
            dgv_table.Columns[4].HeaderText = "Middle Name";
            dgv_table.Columns[5].HeaderText = "Gender";
            dgv_table.Columns[6].HeaderText = "Address";
            dgv_table.Columns[7].HeaderText = "Contact #";
            dgv_table.Columns[8].HeaderText = "Birth Date";
            dgv_table.Columns[9].HeaderText = "Civil Status";
            dgv_table.Columns[10].HeaderText = "SSS #";
            dgv_table.Columns[11].HeaderText = "TIN #";
            dgv_table.Columns[12].HeaderText = "PhilHealth";
            dgv_table.Columns[13].HeaderText = "HDMF";
            dgv_table.Columns[14].HeaderText = "HDMF RTN";
            dgv_table.Columns[15].HeaderText = "Department";
            dgv_table.Columns[16].HeaderText = "Section";
            dgv_table.Columns[17].HeaderText = "Position";
            dgv_table.Columns[18].HeaderText = "Status";
            dgv_table.Columns[19].HeaderText = "Date Hired";
            dgv_table.Columns[20].HeaderText = "Date Regularization";
            dgv_table.Columns[21].HeaderText = "Tax Name";
            dgv_table.Columns[22].HeaderText = "Salary Rate";
            dgv_table.Columns[23].HeaderText = "Salary Structure";
            dgv_table.Columns[24].HeaderText = "Salary Type";
            dgv_table.Columns[25].HeaderText = "Type of Worker";
            dgv_table.Columns[26].HeaderText = "Contact Person Name";
            dgv_table.Columns[27].HeaderText = "Contact Person Number";

            this.dgv_table.Columns["Gender"].Frozen = true;

            if (emp_flag == 2)
            {
                // dgv_table.Columns[28].HeaderText = "Date Resigned";
                dgv_table.Columns[28].HeaderText = "Date Of Separation";
                dgv_table.Columns[29].HeaderText = "Reason Of Separation";
                dgv_table.Columns[30].HeaderText = "Remarks";
            }

        }


        void micro_materials_header()
        {
            dgv_table.Columns[0].HeaderText = "Item ID";
            dgv_table.Columns[1].HeaderText = "Item Code";
            dgv_table.Columns[2].HeaderText = "Item Category";
            dgv_table.Columns[3].HeaderText = "Description";
            dgv_table.Columns[4].HeaderText = "Classification";
            dgv_table.Columns[5].HeaderText = "Reorder Level";
            dgv_table.Columns[6].HeaderText = "Supplier";
            dgv_table.Columns[7].HeaderText = "Supplier Address";
            dgv_table.Columns[8].HeaderText = "Supplier Contact";
            dgv_table.Columns[9].HeaderText = "Date Added";
            dgv_table.Columns[10].HeaderText = "Expiration Details";
            dgv_table.Columns[11].HeaderText = "Delivery Details";


         //   this.dgv_tablemicro.Columns["quantity"].Frozen = true;

      //  //    if (emp_flag == 2)
       /// //    {
                // dgv_table.Columns[28].HeaderText = "Date Resigned";
           //     dgv_tablemicro.Columns[28].HeaderText = "Date Of Separation";
            //    dgv_tablemicro.Columns[29].HeaderText = "Reason Of Separation";
             //   dgv_tablemicro.Columns[30].HeaderText = "Remarks";
          /// // }

        }

        void load_search()
        {
            dset_emp.Clear();

            if (myglobal.global_module == "EMPLOYEE")
            { dset_emp = objStorProc.sp_getMajorTables("employee"); }
            else if (myglobal.global_module == "MICRO")
            { dset_emp = objStorProc.sp_getMajorTables("micro_raw_materialsnew"); }
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


  
        void doSearch()
        {
            try
            {
                if (dset_emp.Tables.Count > 0)
                {
                    DataView dv = new DataView(dset_emp.Tables[0]);
                    if (myglobal.global_module == "EMPLOYEE")
                    {
                        dv.RowFilter = "firstname like '%" + txtsearch.Text + "%' or lastname like '%" + txtsearch.Text + "%' or employee_number like '%" + txtsearch.Text + "%' or employment_status_name like '%" + txtsearch.Text + "%'";
                    }
                    else if (myglobal.global_module == "MICRO")
                    {
            //  dv.RowFilter = "item_id like '%" + txtsearch.Text + "%' or item_code like '%" + txtsearch.Text + "%' or item_description like '%" + txtsearch.Text + "%'";
                        //dv.RowFilter = "item_id like '%" + txtsearch.Text + "%' or item_code like '%" + txtsearch.Text + "%'";
                        dv.RowFilter = "item_description like '%" + txtsearch.Text + "%' or item_code like '%" + txtsearch.Text + "%'";
                    }
                    else if (myglobal.global_module == "RESIGNED EMPLOYEE")
                    {
                        dv.RowFilter = "firstname like '%" + txtsearch.Text + "%' or lastname like '%" + txtsearch.Text + "%' or employee_number like '%" + txtsearch.Text + "%' or employment_status_name like '%" + txtsearch.Text + "%'";
                    }
                    else if (myglobal.global_module == "PHONEBOOK")
                    {
                        dv.RowFilter = "company_name like '%" + txtsearch.Text + "%' or contact_name like '%" + txtsearch.Text + "%'";
                    }
                    else if (myglobal.global_module == "DA")
                    {
                        dv.RowFilter = "employee_name like '%" + txtsearch.Text + "%' or employee_number like '%" + txtsearch.Text + "%' or da_number like '%" + txtsearch.Text + "%'";
                    }
                    else if (myglobal.global_module == "ATTENDANCE")
                    {
                        dv.RowFilter = "lastname like '%" + txtsearch.Text + "%' or firstname like '%" + txtsearch.Text + "%'";
                    }
                    else if (myglobal.global_module == "VISITORS")
                    {
                        dv.RowFilter = "visitors_lastname like '%" + txtsearch.Text + "%' or visitors_firstname like '%" + txtsearch.Text + "%'";
                    }
                    dgv_table.DataSource = dv;
                    lblrecords.Text = dgv_table.RowCount.ToString();
                }
            }
            catch (SyntaxErrorException)
            {
                MessageBox.Show("Invalid character found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtsearch.Focus();
                return;
            }
            catch (EvaluateException)
            {
                MessageBox.Show("Invalid character found 2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtsearch.Focus();
                return;
            }
        }



       

        private void systemLockedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSystemLock sysLock = new frmSystemLock();
            sysLock.ShowDialog();
        }

        private void toolStripMenuDepartment_Click(object sender, EventArgs e)
        {
            frmDepartment dept = new frmDepartment();
            dept.ShowDialog();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            frmSections frmSec = new frmSections();
            frmSec.ShowDialog();
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            frmusers fusers = new frmusers();
            fusers.ShowDialog();
        }

        private void toolStripButtonCancel2_Click(object sender, EventArgs e)
        {
           
        }

        private void ToolStripButtonNew_Click(object sender, EventArgs e)
        {

            NewUser = new frmProductionLevel();
            NewUser.ShowDialog();
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            frmuserrights rights = new frmuserrights();
            rights.ShowDialog();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            doSearch();
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            frmPositions position = new frmPositions();
            position.ShowDialog();
        }

        private void feeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFeedcode fCode = new frmFeedcode();
            fCode.ShowDialog();
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategory category = new frmCategory();
            category.ShowDialog();
        }

        private void classificationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClassification classification = new frmClassification();
            classification.ShowDialog();
        }

        private void supplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSupplierdf Supplier = new frmSupplierdf();
            Supplier.ShowDialog();
        }

        private void itemCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuantity Code = new frmQuantity();
            Code.ShowDialog();
        }

        private void groupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGroup Group = new frmGroup();
            Group.ShowDialog();
        }

        private void toolStripMenuItem21_Click(object sender, EventArgs e)
        {
            frmFormula formula = new frmFormula();
            formula.ShowDialog();
        }

        private void productionTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmViewApproverCancelProd ProductionType = new frmViewApproverCancelProd();
            ProductionType.ShowDialog();
        }

        private void keyboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //  System.Diagnostics.Process.Start("osk.exe");Ke
            //ShowKeyboard();//
            //  Process.Start("osk.exe");
        //    System.Diagnostics.Process.Start(@"C:\%windir%\system32\osk.exe");
        }

        private static void ShowKeyboard()
        {
            var path64 = @"C:\Windows\system32\osk.exe";
            var path32 = @"C:\windows\system32\osk.exe";
            var path = (Environment.Is64BitOperatingSystem) ? path64 : path32;
            Process.Start(path);
        }

        private void formulaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFormula formula = new frmFormula();
            formula.ShowDialog();
        }

        private void dgv_table_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        

        }


        private void p_Micros_Click(object sender, EventArgs e)
        {



            re = false;
            myglobal.global_module = "MICRO";
 
            lblactivemodule.Text = "MICRO";

            load_micro();
            btnresigned.Visible = emp_flag == 0 ? true : false;
;
            p_posted.Visible = false;


            emp_flag = 0;
        }

        private void tsedit_Click(object sender, EventArgs e)
        {
            myglobal.mode = "edit";
            myglobal.updated = false;

            if (myglobal.global_module == "EMPLOYEE")
            {
         //      showEmployee();
       // employee.ShowDialog();

                if (myglobal.updated == true)
                {
         //           p_employee_Click(sender, e);
                }
                txtsearch.Focus();
                frmMenu sa = new frmMenu();

          //      sa.ActivitiesLogs(userinfo.emp_name + " Search Employee");
            }
            else if (myglobal.global_module == "MICRO")
            {


                 showMicroProfile();
              //  frmMicroProfile MicroViews = new frmMicroProfile();
                microviews.ShowDialog();

                if (myglobal.updated == true)
                {
                   p_Micros_Click(sender, e);
                }
                txtsearch.Focus();
                frmMenu sa = new frmMenu();

               // sa.ActivitiesLogs(userinfo.emp_name + " Search Employee");
              
            }
            else if (myglobal.global_module == "MICRO INVENxxTORY")
            {
                //   attendance.ShowDialog();

                if (myglobal.updated == true)
                {
                    //   p_attendance_Click(sender, e);
                    txtsearch.Focus();
                    frmMenu sa = new frmMenu();
                }
            }
            else if (myglobal.global_module == "ATTENDANCE")
            {
             //   attendance.ShowDialog();

                if (myglobal.updated == true)
                {
                    p_attendance_Click(sender, e);
                }
            }
            else if (myglobal.global_module == "TARDINESS")
            {
            //    tardiness.ShowDialog();

                if (myglobal.updated == true)
                {
                    p_tardiness_Click(sender, e);
                }
            }
            else if (myglobal.global_module == "DA")
            {
                //disciplinary2.ShowDialog();

                //if (myglobal.updated == true)
                //{
                //    p_da_Click(sender, e);
                //}
                int daId;

                daId = Convert.ToInt32(dgv_table.SelectedCells[0].Value.ToString());

        //        frmDisciplinaryAction frmDisciplinaryAction = new frmDisciplinaryAction();
           //     frmDisciplinaryAction.Show();
      //          frmDisciplinaryAction.LoadEmployeeeDisciplinary(daId);


            }
            else if (myglobal.global_module == "PHONEBOOK")
            {
             //phonebook.ShowDialog();

                if (myglobal.updated == true)
                {
                    p_phonebook_Click(sender, e);
                }
            }
            else if (myglobal.global_module == "VISITORS")
            {
              //  visitors.ShowDialog();

                if (myglobal.updated == true)
                {
                    p_visitors_Click(sender, e);
                }
            }
            else if (myglobal.global_module == "MANAGER")
            {
             //   employee.ShowDialog();

                if (myglobal.updated == true)
                {
                    panel3_Click(sender, e);
                }
            }
            else if (myglobal.global_module == "RESIGNED EMPLOYEE")
            {
               // employee.ShowDialog();
                if (myglobal.updated == true)
                {
             //       tsResigned_Click(sender, e);
                }
            }

        }


       void showMicroProfile()
        {
            if (dgv_table.RowCount > 0)
            {
                if (dgv_table.CurrentRow != null)
                {
                    if (dgv_table.CurrentRow.Cells["item_id"].Value != null)
                    {
                        try
                        {
                            myglobal.temp_id = Convert.ToInt32(dgv_table.CurrentRow.Cells["item_id"].Value);
                      microviews.temp_id = Convert.ToInt32(dgv_table.CurrentRow.Cells["item_id"].Value);
                     microviews.item_id= dgv_table.CurrentRow.Cells["item_id"].Value.ToString();
                           microviews.item_code = dgv_table.CurrentRow.Cells["item_code"].Value.ToString();
                          microviews.item_description = dgv_table.CurrentRow.Cells["item_description"].Value.ToString();
                          microviews.quantity = dgv_table.CurrentRow.Cells["quantity"].Value.ToString();
                            microviews.Category = dgv_table.CurrentRow.Cells["Category"].Value.ToString();
                          microviews.classification = dgv_table.CurrentRow.Cells["classification"].Value.ToString();
                               microviews.supplier = dgv_table.CurrentRow.Cells["supplier"].Value.ToString();
                          //  microviews.temp_ = Convert.ToInt32(dgv_table.CurrentRow.Cells["item_id"].Value);
                            microviews.contact_no = dgv_table.CurrentRow.Cells["contact_no"].Value.ToString();
                      microviews.address = dgv_table.CurrentRow.Cells["address"].Value.ToString();
                            microviews.email_address = dgv_table.CurrentRow.Cells["email_address"].Value.ToString();
                            microviews.item_location = dgv_table.CurrentRow.Cells["item_location"].Value.ToString();
                            microviews.item_remarks = dgv_table.CurrentRow.Cells["item_remarks"].Value.ToString();
                            microviews.added_by = dgv_table.CurrentRow.Cells["item_added_by"].Value.ToString();
                           //  microviews.date = dgv_table.CurrentRow.Cells["emp.added_by"].Value.ToString();
                         microviews.dateadded = Convert.ToDateTime(dgv_table.CurrentRow.Cells["date_added"].Value.ToString());
                           //coment   microviews.expirationdetails = Convert.ToDateTime(dgv_table.CurrentRow.Cells["expiration_details"].Value.ToString());
                            microviews.expirationdetails = dgv_table.CurrentRow.Cells["expiration_details"].Value.ToString();
                            microviews.delivery_details = dgv_table.CurrentRow.Cells["delivery_details"].Value.ToString();
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
                            //     employee.salarystructure = dgv_table.CurrentRow.Cells["salary_structure"].Value.ToString();
                            //      employee.salarytype = dgv_table.CurrentRow.Cells["salary_type_name"].Value.ToString();
                            //        employee.dateregularization = Convert.ToDateTime(dgv_table.CurrentRow.Cells["date_regularization"].Value.ToString()); // philip
                            //       employee.workers_name = dgv_table.CurrentRow.Cells["workers_name"].Value.ToString();
                            //         employee.ICOEName = dgv_table.CurrentRow.Cells["in_case_of_emergency_name"].Value.ToString();
                            //        employee.ICOENumber = dgv_table.CurrentRow.Cells["in_case_of_emergency_contact_number"].Value.ToString();

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



        public void ActivitiesLogs(string logs)
        {

            try
            {
                const string location = @"aActivities";

                if (!File.Exists(location))
                {
                    var createText = "New Activities Logs" + Environment.NewLine;
                    File.WriteAllText(location, createText);
                }
                var appendLogs = "Activities Logs: " + logs + " " + DateTime.Now + Environment.NewLine;
                File.AppendAllText(location, appendLogs);
            }
            catch (Exception ex)
            {
                const string location = @"aActivities";
                if (!File.Exists(location))
                {
                    TextWriter file = File.CreateText(@"C:\aActivities");
                    var createText = "New Activities Logs" + Environment.NewLine;

                    File.WriteAllText(location, createText);

                }
                var appendLogs = ex.Message + logs + DateTime.Now + Environment.NewLine;
                File.AppendAllText(location, appendLogs);

            }

        }




        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            frmFormula myformula = new frmFormula();
            myformula.ShowDialog();
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            panel_search.Visible = true;
            labelSearch.Visible = true;

            txtsearch.Visible = true;
            myglobal.global_module = "MICRO";
            //this.Text = "DISCIPLINARY ACTION";
            lblactivemodule.Text = "MICRO";
            load_micro();
            dgv_table.Visible = true;
            load_search();
            btnresigned.Visible = false;
            p_posted.Visible = true;
            txtsearch.Focus();


        }
        public void load_micro()
        {
            string mcolumns = "test,item_id,item_code,category_name,item_description,classification,quantity,supplier,address,contact_no,date_added,expiration_details,delivery_details";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgv_table, mcolumns, "micro_raw_materialsnew");
            lblrecords.Text = dgv_table.RowCount.ToString();
          // textBox1.Text = dgv_table.RowCount.ToString();
            micro_materials_header();
        }

     //   mcolumns = "item_id,item_code,category_name,item_description,classification,quantity,supplier,address,contact_no,date_added,expiration_details,delivery_details";
            //    pointer_module.populateModule(dsetHeader, dgv_tablemicro, mcolumns, "micro_raw_materials");

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dgv_tablemicro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtSearchMicro_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            frmMicroProfile ii = new frmMicroProfile();
            ii.ShowDialog();
        }

        private void dgv_table_DoubleClick(object sender, EventArgs e)
        {
            if (myglobal.global_module == "RESIGNED EMPLOYEE")
            {
                tsedit_Click(sender, e);


            }
            else if (myglobal.global_module == "MICRO")
            {
                tsedit_Click(sender, e);

            }
            else
            {
                //MessageBox.Show(dgv_table.CurrentRow.Cells["department_name"].Value.ToString() + "/n" + dgv_table.CurrentRow.Cells["section_name"].Value.ToString() + "/n" + dgv_table.CurrentRow.Cells["position_name"].Value.ToString());
                tsedit_Click(sender, e);
            }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            frmmicroreceivingentry ReceingMicro = new frmmicroreceivingentry();
            ReceingMicro.ShowDialog();


            lblactivemodule.Text = "MICRO RECEIVING ENTRY";



        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmBufferedInventory  NewRawMaterial = new frmBufferedInventory();
            NewRawMaterial.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            load_micro();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
               timer2.Stop();
            load_micro();
            Console.WriteLine("Hello World!!!"); //Code to Perform Task goes in between here
            timer2.Start();
        }

        private void systemOnlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFGMaterialTracking Online = new frmFGMaterialTracking();
            Online.ShowDialog();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            dgv_table.Visible = false;
        }

        private void fToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MDIParent1 parent = new MDIParent1();
            parent.ShowDialog();
        }
    }
}
