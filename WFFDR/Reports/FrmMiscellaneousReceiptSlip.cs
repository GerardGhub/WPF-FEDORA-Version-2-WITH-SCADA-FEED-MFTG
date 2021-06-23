using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace WFFDR.Reports
{
    public partial class FrmMiscellaneousReceiptSlip : Form
    {
        myclasses xClass = new myclasses();
        IStoredProcedures objStorProc = null;


        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();


        public myclasses classes = new myclasses();


        public DataSet dset = new DataSet();
        public FrmMiscellaneousReceiptSlip()
        {
            InitializeComponent();
        }

        private void FrmMiscellaneousReceiptSlip_Load(object sender, EventArgs e)
        {
            objStorProc = xClass.g_objStoredProc.GetCollections();
            load_Schedules();
            dtp1.MaxDate = DateTime.Now;
            dtp2.MaxDate = DateTime.Now;


            myglobal.global_module = "FGINVENTORY";

        }

        public void load_Schedules()
        {
            string mcolumns = "test,orderno,TotalBags,added_by,printing_date";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgvApproved, mcolumns, "transaction_miscellaneous_receiptshow");
            lblrecords.Text = dgvApproved.RowCount.ToString();

        }

        private void dgvApproved_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgvApproved.CurrentRow != null)
            {
                if (dgvApproved.CurrentRow.Cells["orderno"].Value != null)
                {
                    txtorder.Text = dgvApproved.CurrentRow.Cells["orderno"].Value.ToString();
                    lblencodedby.Text = dgvApproved.CurrentRow.Cells["added_by"].Value.ToString();
                    lbltotalqty.Text = dgvApproved.CurrentRow.Cells["TotalBags"].Value.ToString();
                    lbldate.Text = dgvApproved.CurrentRow.Cells["printing_date"].Value.ToString();
                }
            }
        }

        private void dgvApproved_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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
        DataSet dset_emp = new DataSet();
        public void load_search()
        {
            dset_emp.Clear();

            if (myglobal.global_module == "EMPLOYEE")
            { dset_emp = objStorProc.sp_getMajorTables("employee"); }
            else if (myglobal.global_module == "MICRO")
            { dset_emp = objStorProc.sp_getMajorTables("micro_raw_materialsnew"); }
            else if (myglobal.global_module == "FGINVENTORY")
            { dset_emp = objStorProc.sp_getMajorTables("transaction_miscellaneous_receiptshow"); }
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
                        dv.RowFilter = "printing_date >= '" + dtp1.Text + "' AND printing_date <='" + dtp2.Text + "'";
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            myglobal.DATE_REPORT = txtorder.Text;
            myglobal.DATE_REPORT2 = txtorder.Text;
            //myglobal.DATE_REPORT3 = lblmyfeedcode.Text;
            //myglobal.REPORT_NAME = "DailyProductionSchedule";
            myglobal.REPORT_NAME = "FGMiscellaneousReceipt";



            frmReport fr = new frmReport();

            fr.WindowState = FormWindowState.Maximized;
            fr.Show();

        }
        private static bool IsNameValid(string name)
        {
            if (string.IsNullOrEmpty(name))
                return true;
            else if (name.Any(c => c < '0' || c > '9'))

            {
                PopupNotifier popup = new PopupNotifier();
                popup.Image = Properties.Resources.info;
                popup.TitleText = "Fedora Notifications";
                popup.TitleColor = Color.White;
                popup.TitlePadding = new Padding(95, 7, 0, 0);
                popup.TitleFont = new Font("Tahoma", 10);
                popup.ContentText = "Sorry your Quantity must contain digits only!";
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


                return false;
            }
            else if (name.StartsWith("0"))
            {
                PopupNotifier popup = new PopupNotifier();
                popup.Image = Properties.Resources.info;
                popup.TitleText = "Fedora Notifications";
                popup.TitleColor = Color.White;
                popup.TitlePadding = new Padding(95, 7, 0, 0);
                popup.TitleFont = new Font("Tahoma", 10);
                popup.ContentText = "Sorry the quantity must not start from 0! ";
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

                return false;
            }

            return true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!IsNameValid(textBox2.Text))
            {
                textBox2.Text = string.Concat(textBox2
                .Text
                .Where(c => c >= '0' && c <= '9')
                .SkipWhile(c => c == '0'));
            }

            if (textBox2.Text == String.Empty)
            {
                load_Schedules();

            }

            else
            {
                load_search();


            }
        }

        private void dtp1_ValueChanged(object sender, EventArgs e)
        {

            load_search();
        }

        private void dtp2_ValueChanged(object sender, EventArgs e)
        {
            load_search();
        }
    }
}
