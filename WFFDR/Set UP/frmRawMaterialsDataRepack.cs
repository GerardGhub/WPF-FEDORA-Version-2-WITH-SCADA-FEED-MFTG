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
    public partial class frmRawMaterialsDataRepack : Form
    {
        int rowindex;
        int i;
        string mode = ""; //mymode
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
        int sec;
        DataSet dset_section = new DataSet();
        Boolean ready = false;
        bool re = false;
        int p_id = 0;
        int s_id = 0;
        //weighing

        public myclasses classes = new myclasses();
        myclasses myClass = new myclasses();


        public DataSet dset = new DataSet();
        DataSet dset2 = new DataSet();
        DataSet dset3 = new DataSet();


        public frmRawMaterialsDataRepack()
        {
            InitializeComponent();
        }

        private void txtItemCode_TextChanged(object sender, EventArgs e)
        {
            load_search();
            doSearch();
        }

        DataSet dset_emp = new DataSet();
        public void load_search()
        {
            try
            {



            dset_emp.Clear();

            if (myglobal.global_module == "EMPLOYEE")
            { dset_emp = objStorProc.sp_getMajorTables("employee"); }
            else if (myglobal.global_module == "MICRO")
            { dset_emp = objStorProc.sp_getMajorTables("micro_raw_materialsnew"); }
            else if (myglobal.global_module == "FGINVENTORY")
            { dset_emp = objStorProc.sp_getMajorTables("transaction_repacking"); }
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
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

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
                        dv.RowFilter = "rp_item_code like'%" + txtItemCode.Text + "%' and uniquedate ='" + dtpFilter.Text+ "'";
                    }

                    else if (myglobal.global_module == "VISITORS")
                    {
                        dv.RowFilter = "visitors_lastname like '%" + txtItemCode.Text + "%' or visitors_firstname like '%" + txtItemCode.Text + "%'";
                    }
                    dgvApproved.DataSource = dv;
                    lblrecords.Text = dgvApproved.RowCount.ToString();
                }
            }
            catch (SyntaxErrorException)
            {
                MessageBox.Show("Invalid character found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
              txtItemCode.Focus();
                return;
            }
            catch (EvaluateException)
            {
                MessageBox.Show("Invalid character found 2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
             txtItemCode.Focus();
                return;
            }




 

           double sum = 0;
            for (int i = 0; i < dgvApproved.Rows.Count; ++i)
            {
                sum += Convert.ToDouble(dgvApproved.Rows[i].Cells[6].Value);
            }
            lblstock.Text = sum.ToString();





        }

        private void frmRawMaterialsDataRepack_Load(object sender, EventArgs e)
        {
            // Calling the Stored PROC 
            objStorProc = xClass.g_objStoredProc.GetCollections();


            myglobal.global_module = "FGINVENTORY";
            ItemCode();
        }






        public void load_search2()
        {
            dset_emp.Clear();

            if (myglobal.global_module == "EMPLOYEE")
            { dset_emp = objStorProc.sp_getMajorTables("employee"); }
            else if (myglobal.global_module == "MICRO")
            { dset_emp = objStorProc.sp_getMajorTables("micro_raw_materialsnew"); }
            else if (myglobal.global_module == "PRODPLAN")
            { dset_emp = objStorProc.sp_getMajorTables("transaction_prod_plan"); }
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


            doSearch2();

        }

        void doSearch2()
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

                    else if (myglobal.global_module == "PRODPLAN")
                    {
                        //  dv.RowFilter = "item_id like '%" + txtsearch.Text + "%' or item_code like '%" + txtsearch.Text + "%' or item_description like '%" + txtsearch.Text + "%'";
                        //dv.RowFilter = "item_id like '%" + txtsearch.Text + "%' or item_code like '%" + txtsearch.Text + "%'";
                        dv.RowFilter = "item_code like'%" + txtItemCode.Text + "%' and proddate ='" + dtpFilter.Text + "'";
                    }

                    else if (myglobal.global_module == "VISITORS")
                    {
                        dv.RowFilter = "visitors_lastname like '%" + txtItemCode.Text + "%' or visitors_firstname like '%" + txtItemCode.Text + "%'";
                    }
                    dgvProdPlan.DataSource = dv;
                    lblrecords.Text = dgvProdPlan.RowCount.ToString();
                }
            }
            catch (SyntaxErrorException)
            {
                MessageBox.Show("Invalid character found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtItemCode.Focus();
                return;
            }
            catch (EvaluateException)
            {
                MessageBox.Show("Invalid character found 2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtItemCode.Focus();
                return;
            }






            //double sum = 0;
            //for (int i = 0; i < dgvApproved.Rows.Count; ++i)
            //{
            //    sum += Convert.ToDouble(dgvApproved.Rows[i].Cells[6].Value);
            //}
            //lblstock.Text = sum.ToString();





        }


        void ItemCode()
        {
            ready = false;

            xClass.fillComboBoxWH(txtItemCode, "item_code_in_formulation", dSet);
            //displayData(Convert.ToInt32(cboStandardWeight.SelectedValue.ToString()));

            ready = true;

        }
        private void txtItemCode_TextChanged_1(object sender, EventArgs e)
        {

        }


        public void FilltextboxErrorNotifier()
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);

            popup.ContentText = "Error Undefined the Materials Group !";

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

        private void dtpFilter_Validating(object sender, CancelEventArgs e)
        {

        }

        private void dtpFilter_ValueChanged(object sender, EventArgs e)
        {
            load_search();
            doSearch();
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

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (cmdFedoraModules.Text == "Repacking Date")
            {
                dgvApproved.Visible = true;
                dgvProdPlan.Visible = false;
                myglobal.global_module = "FGINVENTORY";
                load_search();
                doSearch();
            }
            else if (cmdFedoraModules.Text == "Production Plan")
            {
                dgvApproved.Visible = false;
                dgvProdPlan.Visible = true;
                myglobal.global_module = "PRODPLAN";

                load_search2();
                doSearch2();
                GrandTotal();
            }
            else if (cmdFedoraModules.Text == "Production Date")
            {

            }

            else
            {
                FilltextboxErrorNotifier();
                txtItemCode.Text = "";

            }
        }

        void GrandTotal()
        {

            for (int n = 0; n < (dgvProdPlan.Rows.Count); n++)
            {
                //9

                double s1 = Convert.ToDouble(dgvProdPlan.Rows[n].Cells[6].Value);

                double s2 = Convert.ToDouble(dgvProdPlan.Rows[n].Cells[7].Value);
                double s3 = Convert.ToDouble(dgvProdPlan.Rows[n].Cells[8].Value);
                double s4 = Convert.ToDouble(dgvProdPlan.Rows[n].Cells[9].Value);

                //double s4 = Convert.ToDouble(dgv_table.Rows[n].Cells[4].Value);
                //double s5 = Convert.ToDouble(dgv_table.Rows[n].Cells[5].Value);




                double grandtotal = s1 * 2;

                double onhand = s3 * s4;

                //dgv_table.Rows[n].Cells[4].Value = grandtotal.ToString();
                dgvProdPlan.Rows[n].Cells[8].Value = grandtotal.ToString();


                dgvProdPlan.Rows[n].Cells[9].Value = onhand.ToString();





                double sum = 0;
                for (int i = 0; i < dgvProdPlan.Rows.Count; ++i)
                {
                    sum += Convert.ToDouble(dgvProdPlan.Rows[i].Cells[9].Value);
                }
                lblstock.Text = sum.ToString();










            }

        }


        private void cmdFedoraModules_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
