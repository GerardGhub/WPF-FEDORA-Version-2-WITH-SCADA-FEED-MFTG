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
    public partial class frmUserLognew : Form
    {
        myclasses myClass = new myclasses();
    
        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();
        DataSet dSet_temp = new DataSet();
        DataSet dSet = new DataSet();
 

      
        Boolean ready = false;
        myclasses xClass = new myclasses();
        IStoredProcedures objStorProc = null;
        int s_id = 0;

        public frmUserLognew()
        {
            InitializeComponent();
        }

        private void frmDistinctRepackingRecords_Load(object sender, EventArgs e)
        {
            objStorProc = xClass.g_objStoredProc.GetCollections();
            load_distinct_repacking_records();
            TotalRecord();

            loadModule_type();

            loadAuditTrail();
            load_search();
            dgvUsername.Visible = false;
        }

        void loadModule_type()
        {
            ready = false;
            myClass.fillComboBox(txtmodule, "module_type", dSet);
            ready = true;


            //ready = false;
            //xClass.fillComboBoxFilter(txtmodule, "module_type", dSet, txtmenuid.Text, 0);
            //ready = true;
            //s_id = showValue(txtmodule);

        }





        DataSet dset_emp1 = new DataSet();

        DataSet dset_emp2 = new DataSet();
        void doSearch()
        {
            try
            {
                if (dset_emp1.Tables.Count > 0)
                {
                    DataView dv = new DataView(dset_emp1.Tables[0]);
                    if (myglobal.global_module == "EMPLOYEE")
                    {
                        //dv.RowFilter = "firstname like '%" + txtmainsearch.Text + "%' or lastname like '%" + txtsearch.Text + "%' or employee_number like '%" + txtsearch.Text + "%' or employment_status_name like '%" + txtsearch.Text + "%'";
                    }
                    else if (myglobal.global_module == "Active")
                    {

                        dv.RowFilter = "Module = '" + txtmodule.Text + "'";

                    }
                    else if (myglobal.global_module == "VISITORS")
                    {
                        //dv.RowFilter = "visitors_lastname like '%" + txtsearch.Text + "%' or visitors_firstname like '%" + txtsearch.Text + "%'";
                    }
                    dgvTrail.DataSource = dv;
                    lblcountprod3.Text = dgvTrail.RowCount.ToString();

                    //gerard
                }
            }
            catch (SyntaxErrorException)
            {
                MessageBox.Show("Invalid character found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            catch (EvaluateException)
            {
                MessageBox.Show("Invalid character found 2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }


        }


        void load_search()
        {

            dset_emp1.Clear();




            dset_emp1 = objStorProc.sp_getMajorTables("distinctaudittrail");

            doSearch();


            dset_emp2.Clear();

            dset_emp2 = objStorProc.sp_getMajorTables("distinctaudittrailusername");
            doSearch2();

        }



        void ReverseSerchByUser()
        {

            dset_emp1.Clear();




            dset_emp1 = objStorProc.sp_getMajorTables("distinctaudittrail");

            doSearchReverse();

        }



        void doSearchReverse()
        {
            try
            {
                if (dset_emp1.Tables.Count > 0)
                {
                    DataView dv = new DataView(dset_emp1.Tables[0]);
                    if (myglobal.global_module == "EMPLOYEE")
                    {
                        //dv.RowFilter = "firstname like '%" + txtmainsearch.Text + "%' or lastname like '%" + txtsearch.Text + "%' or employee_number like '%" + txtsearch.Text + "%' or employment_status_name like '%" + txtsearch.Text + "%'";
                    }
                    else if (myglobal.global_module == "Active")
                    {

                        dv.RowFilter = "Username = '" + txtmyUser.Text + "' AND Module='"+txtmodule.Text+"'";

                    }
                    else if (myglobal.global_module == "VISITORS")
                    {
                        //dv.RowFilter = "visitors_lastname like '%" + txtsearch.Text + "%' or visitors_firstname like '%" + txtsearch.Text + "%'";
                    }
                    dgvTrail.DataSource = dv;
                    lblcountprod3.Text = dgvTrail.RowCount.ToString();

                    //gerard
                }
            }
            catch (SyntaxErrorException)
            {
                MessageBox.Show("Invalid character found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            catch (EvaluateException)
            {
                MessageBox.Show("Invalid character found 2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }


        }


        void doSearch2()
        {
            try
            {
                if (dset_emp2.Tables.Count > 0)
                {
                    DataView dv = new DataView(dset_emp2.Tables[0]);
                    if (myglobal.global_module == "EMPLOYEE")
                    {
                        //dv.RowFilter = "firstname like '%" + txtmainsearch.Text + "%' or lastname like '%" + txtsearch.Text + "%' or employee_number like '%" + txtsearch.Text + "%' or employment_status_name like '%" + txtsearch.Text + "%'";
                    }
                    else if (myglobal.global_module == "Active")
                    {

                        dv.RowFilter = "Module = '" + txtmodule.Text + "'";

                    }
                    else if (myglobal.global_module == "VISITORS")
                    {
                        //dv.RowFilter = "visitors_lastname like '%" + txtsearch.Text + "%' or visitors_firstname like '%" + txtsearch.Text + "%'";
                    }
                    dgvUsername.DataSource = dv;
                   lblusername.Text = dgvUsername.RowCount.ToString();

                    //gerard
                }
            }
            catch (SyntaxErrorException)
            {
                MessageBox.Show("Invalid character found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            catch (EvaluateException)
            {
                MessageBox.Show("Invalid character found 2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }


        }






























        //public int showValue(ComboBox cbo)
        //{
        //    int ids = 0;
        //    if (ready == true)
        //    {
        //        if (cbo.Items.Count > 0)
        //        {
        //            ids = Convert.ToInt32(cbo.SelectedValue.ToString());
        //        }
        //    }
        //    return ids;
        //}

        void loadAuditTrail()
        {

            string mcolumns = "test,User_id,Username,Module,Activity,DateAndTime,production_id,bags";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgvTrail, mcolumns, "distinctaudittrail");

        }
        public void load_distinct_repacking_records()
        {
            string mcolumns = "test,user_id,username,time_logs";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgvProdToday, mcolumns, "distinctrepackingrecords");
lblcountprod3.Text = dgvProdToday.RowCount.ToString();
            lblrecords.Text = dgvProdToday.RowCount.ToString();
        }


        void TotalRecord()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.ContentText = "TOTAL QTY OF SYSTEM LOGS IS " + lblcountprod3.Text + "!";
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Green;
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
        private void dgvProdToday_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void dgvTrail_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void txtmodule_SelectedValueChanged(object sender, EventArgs e)
        {
            doSearch();
            load_search();
            doSearch2();

        }

        private void dgvUsername_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void dgvUsername_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgvUsername.RowCount > 0)
            {
                if (dgvUsername.CurrentRow != null)
                {
                    if (dgvUsername.CurrentRow.Cells["Username20"].Value != null)
                    {
                        //p_id = Convert.ToInt32(dgvApproved.CurrentRow.Cells["prod_id"].Value);

                        txtmyUser.Text = dgvUsername.CurrentRow.Cells["Username20"].Value.ToString();

                    }

                }
            }
        }

        private void dgvUsername_Click(object sender, EventArgs e)
        {
            ReverseSerchByUser();
        }

        private void txtmodule_TextChanged(object sender, EventArgs e)
        {
            dgvUsername.Visible = true;

            dset_emp2 = objStorProc.sp_getMajorTables("distinctaudittrailusername");
            doSearch2();
        }
    }
}
