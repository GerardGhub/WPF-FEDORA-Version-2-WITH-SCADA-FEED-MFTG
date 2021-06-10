using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace WFFDR
{
    public partial class frmFGMoveorderPrinting : Form
    {


        myclasses xClass = new myclasses();
        IStoredProcedures objStorProc = null;
        DataSet dSets = new DataSet();

        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();
        DataSet dSet_temp = new DataSet();
        DataSet dset_delete = new DataSet();

        DataSet dSet = new DataSet();
        DataSet dset_rights = new DataSet();


        private const int BaudRate = 9600;
   
        DataSet dset_section = new DataSet();
        Boolean ready = false;


        //weighing

        public myclasses classes = new myclasses();
        myclasses myClass = new myclasses();


        public DataSet dset = new DataSet();
        DataSet dset2 = new DataSet();
        DataSet dset3 = new DataSet();





        public frmFGMoveorderPrinting()
        {
            InitializeComponent();
        }

        private void frmFGMoveorderPrinting_Load(object sender, EventArgs e)
        {

            // Calling the Stored PROC 
            objStorProc = xClass.g_objStoredProc.GetCollections();
            load_Schedules();
            if (lblrecords.Text == "0")

            {
                NoRecords();
               
                btnPrint.Visible = false;

                button1_Click(sender, e);
                

            }

            else
            {
                

            }


            textBox1.Text = "";
            this.BringToFront();
            myglobal.global_module = "FGINVENTORY";


          
        }

        public void load_Schedules()
        {
            string mcolumns = "test,order_no,added_by,TotalBags,date_added,PENDING";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgvApproved, mcolumns, "transaction_move_order");
            lblrecords.Text = dgvApproved.RowCount.ToString();

        }

        private void dgvApproved_CurrentCellChanged(object sender, EventArgs e)
        {


            if (dgvApproved.CurrentRow != null)
            {
                if (dgvApproved.CurrentRow.Cells["order_no"].Value != null)
                {
                    txtorder.Text = dgvApproved.CurrentRow.Cells["order_no"].Value.ToString();



                }
            }

        }

        private void bntPrint_Click(object sender, EventArgs e)
        {

            myglobal.DATE_REPORT = txtorder.Text;
            //myglobal.DATE_REPORT2 = f2.Text;
            //myglobal.DATE_REPORT3 = lblmyfeedcode.Text;
            //myglobal.REPORT_NAME = "DailyProductionSchedule";
            myglobal.REPORT_NAME = "FGMoveOrder";



            frmReport fr = new frmReport();

            fr.WindowState = FormWindowState.Maximized;
            fr.Show();


        }

        private void dgvApproved_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {




        }

        private void dgvApproved_CurrentCellChanged_1(object sender, EventArgs e)
        {
            if (dgvApproved.CurrentRow != null)
            {
                if (dgvApproved.CurrentRow.Cells["order_no"].Value != null)
                {
                    txtorder.Text = dgvApproved.CurrentRow.Cells["order_no"].Value.ToString();
                    lblencodedby.Text = dgvApproved.CurrentRow.Cells["added_by"].Value.ToString();
                    lbltotalqty.Text = dgvApproved.CurrentRow.Cells["TotalBags"].Value.ToString();
                    lbldate.Text = dgvApproved.CurrentRow.Cells["date_added"].Value.ToString();
                }
            }
        }

        private void dgvApproved_RowPostPaint_1(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void dgvApproved_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lbldate_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            load_Schedules();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            frmFGMoveorderPrinting_Load(sender, e);
        }

        private void dgvApproved_DoubleClick(object sender, EventArgs e)
        {
            frmShowOrder shower = new frmShowOrder(txtorder.Text, lblencodedby.Text, lbltotalqty.Text, lbldate.Text, this);
            shower.Show();
        }

        public void NoRecords()
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);

            popup.ContentText = "No records found!";

            popup.ContentColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);

            popup.ContentHoverColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentPadding = new Padding(0);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Red;
            popup.Popup();

            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);

            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {
            load_search();
            doSearch();
            //GrandTotal();
        }



        DataSet dset_emp = new DataSet();
        public void load_search()
        {
            dset_emp.Clear();

            if (myglobal.global_module == "EMPLOYEE")
            { dset_emp = objStorProc.sp_getMajorTables("employee"); }
            else if (myglobal.global_module == "MICRO")
            { dset_emp = objStorProc.sp_getMajorTables("micro_raw_materialsnew"); }
            else if (myglobal.global_module == "FGINVENTORY")
            { dset_emp = objStorProc.sp_getMajorTables("transaction_move_order"); }
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
                        //dv.RowFilter = "firstname like '%" + txtsearch.Text + "%' or lastname like '%" + txtsearch.Text + "%' or employee_number like '%" + txtsearch.Text + "%' or employment_status_name like '%" + txtsearch.Text + "%'";
                    }

                    else if (myglobal.global_module == "FGINVENTORY")
                    {
                        //  dv.RowFilter = "item_id like '%" + txtsearch.Text + "%' or item_code like '%" + txtsearch.Text + "%' or item_description like '%" + txtsearch.Text + "%'";
                        //dv.RowFilter = "item_id like '%" + txtsearch.Text + "%' or item_code like '%" + txtsearch.Text + "%'";
                        dv.RowFilter = "order_no like '%" + txtsearchs.Text + "%'";
                    }

                    else if (myglobal.global_module == "VISITORS")
                    {
                        dv.RowFilter = "visitors_lastname like '%" + txtsearchs.Text + "%' or visitors_firstname like '%" + txtsearchs.Text + "%'";
                    }
                    dgvApproved.DataSource = dv;
                    lblrecords.Text = dgvApproved.RowCount.ToString();
                }
            }
            catch (SyntaxErrorException)
            {
                MessageBox.Show("Invalid character found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtsearchs.Focus();
                return;
            }
            catch (EvaluateException)
            {
                MessageBox.Show("Invalid character found 2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtsearchs.Focus();
                return;
            }

        }

        private void dgvApproved_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {

            myglobal.DATE_REPORT = txtorder.Text;
            //myglobal.DATE_REPORT2 = f2.Text;
            //myglobal.DATE_REPORT3 = lblmyfeedcode.Text;
            //myglobal.REPORT_NAME = "DailyProductionSchedule";
            myglobal.REPORT_NAME = "FGMoveOrderReprint";



            frmReport fr = new frmReport();

            fr.WindowState = FormWindowState.Maximized;
            fr.Show();
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmFGMoveorderPrinting_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void frmFGMoveorderPrinting_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {  
         this.BeginInvoke(new MethodInvoker(Close));
        }
    }
}
