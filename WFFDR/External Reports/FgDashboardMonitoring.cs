using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFFDR
{
    public partial class FgDashboardMonitoring : Form
    {
        IStoredProcedures objStorProc = null;
        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();
        myclasses xClass = new myclasses();
        public FgDashboardMonitoring()
        {
            InitializeComponent();
        }

        private void FgDashboardMonitoring_Load(object sender, EventArgs e)
        {
            objStorProc = xClass.g_objStoredProc.GetCollections();
            myglobal.global_module = "Active";
            load_FGmonitoring();

        }
        //

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle = cp.ExStyle | 0x2000000;
                return cp;
            }
        }
        public void load_FGmonitoring()
        {
            string mcolumns = "test,prod_id,p_feed_code,feed_type,bags_int,batch_int,proddate,bagorbin,series_num";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dataView, mcolumns, "FGmonitoring");

        }

        void load_search()
        {
            //dito
            dset_emp1.Clear();

            dset_emp1 = objStorProc.sp_GetCategory("FGmonitoring",0, dateTimePicker12.Text.ToString(),"","");

            doSearch();


            dset_emp2.Clear();
            dset_emp2 = objStorProc.sp_GetCategory("FGReproccess", 0, dateTimePicker12.Text.ToString(), txtproductionid.Text,"");

            doSearch2();

            dset_emp3.Clear();
            dset_emp3 = objStorProc.sp_GetCategory("FGReproccessDone", 0, dateTimePicker12.Text.ToString(), txtproductionid.Text,"");

            doSearch3();

            dset_emp4.Clear();
            dset_emp4 = objStorProc.sp_GetCategory("FGGood", 0, dateTimePicker12.Text.ToString(), txtproductionid.Text,"");

            doSearch4();

            dset_emp5.Clear();
            dset_emp5 = objStorProc.sp_GetCategory("FGRejected", 0, dateTimePicker12.Text.ToString(), txtproductionid.Text,"");

            doSearch5();

            dset_emp6.Clear();
            dset_emp6 = objStorProc.sp_GetCategory("FGBaggingTotal", 0, dateTimePicker12.Text.ToString(), txtproductionid.Text,"");

            doSearch6();

            dset_emp7.Clear();
            dset_emp7 = objStorProc.sp_GetCategory("FGBulkTotal", 0, dateTimePicker12.Text.ToString(), txtproductionid.Text,"");


            doSearch7();

            dset_emp8.Clear();
            dset_emp8 = objStorProc.sp_GetCategory("FGtabalu", 0, "", txtproductionid.Text,"");

            doSearch8();


        }

        void loadsearch2()
        {
            dset_emp2.Clear();
           dset_emp2 = objStorProc.sp_GetCategory("FGReproccess", 0, dateTimePicker12.Text.ToString(), txtproductionid.Text,"");

            doSearch2();

            dset_emp3.Clear();
            dset_emp3 = objStorProc.sp_GetCategory("FGReproccessDone", 0, dateTimePicker12.Text.ToString(), txtproductionid.Text,"");

            doSearch3();

            dset_emp4.Clear();
            dset_emp4 = objStorProc.sp_GetCategory("FGGood", 0, dateTimePicker12.Text.ToString(), txtproductionid.Text,"");

            doSearch4();

            dset_emp5.Clear();
            dset_emp5 = objStorProc.sp_GetCategory("FGRejected", 0, dateTimePicker12.Text.ToString(), txtproductionid.Text,"");

            doSearch5();

            dset_emp6.Clear();
            dset_emp6 = objStorProc.sp_GetCategory("FGBaggingTotal", 0, dateTimePicker12.Text.ToString(), txtproductionid.Text,"");

            doSearch6();

            dset_emp7.Clear();
            dset_emp7 = objStorProc.sp_GetCategory("FGBulkTotal", 0, dateTimePicker12.Text.ToString(), txtproductionid.Text,"");


            doSearch7();

            dset_emp8.Clear();
            dset_emp8 = objStorProc.sp_GetCategory("FGtabalu", 0, "", txtproductionid.Text,"");

            doSearch8();

        }
        DataSet dset_emp1 = new DataSet();
        void doSearch()
        {
            try
            {
                    DataView dv = new DataView(dset_emp1.Tables[0]);
                if(dset_emp1.Tables != null)
                { 
                    dataView.DataSource = dv;
                    txtluffy.Text = dataView.RowCount.ToString();
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




        DataSet dset_emp2 = new DataSet();
        void doSearch2()
        {
            try
            {

                    DataView dv = new DataView(dset_emp2.Tables[0]);
                if (dset_emp2.Tables != null)
                {
                    dataView2.DataSource = dv;
                    txtreprocess.Text = dataView2.RowCount.ToString();
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







        DataSet dset_emp3 = new DataSet();
        void doSearch3()
        {
            try
            {
               
                    DataView dv = new DataView(dset_emp3.Tables[0]);
                if (dset_emp3.Tables != null)
                { 
                    dataView3.DataSource = dv;
                    txtreprocessdone.Text = dataView3.RowCount.ToString();
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


        DataSet dset_emp4 = new DataSet();
        void doSearch4()
        {
            try
            {

                    DataView dv = new DataView(dset_emp4.Tables[0]);
                if (dset_emp4.Tables != null)
                { 
                    dataView4.DataSource = dv;
                    lblgood.Text = dset_emp4.Tables[0].Rows[0][0].ToString();
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



        DataSet dset_emp5 = new DataSet();
        void doSearch5()
        {
            try
            {

                    DataView dv = new DataView(dset_emp5.Tables[0]);
                if (dset_emp5.Tables != null)
                { 
                    dataView5.DataSource = dv;
                    lblreject.Text = dataView5.RowCount.ToString();
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




        DataSet dset_emp6 = new DataSet();
        void doSearch6()
        {
            try
            {

                    DataView dv = new DataView(dset_emp6.Tables[0]);
                    if(dset_emp6.Tables != null)
                { 
                    dataView6.DataSource = dv;
                    lbltotal.Text = dataView6.RowCount.ToString();
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





        DataSet dset_emp7 = new DataSet();
        void doSearch7()
        {
            try
            {

                    DataView dv = new DataView(dset_emp7.Tables[0]);
                if (dset_emp7.Tables != null)
                { 
                    dataView7.DataSource = dv;
                    lbltotalbulk.Text = dataView7.RowCount.ToString();
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









            lblbulkgrandtotal.Text = dset_emp7.Tables[0].Rows[0][0].ToString();

            
           

            if (lblbulkgrandtotal.Text.Trim()== String.Empty)
            {
                lblbulkgrandtotal.Text = "0";
            }
            else
            {

                //lblgood.Text = (float.Parse(lblgood.Text) + float.Parse(lblbulkgrandtotal.Text)).ToString();

                //if (lblbulkgrandtotal.Text == "0")
                //{

                //}
                //else
                //{
                //    //lblgood.Text = (float.Parse(lblgood.Text) - 1).ToString();
                //}

            }

        }








        DataSet dset_emp8 = new DataSet();
        void doSearch8()
        {
            try
            {
                
                    DataView dv = new DataView(dset_emp8.Tables[0]);
                   if(dset_emp8.Tables!= null)
                { 
                    dataView8.DataSource = dv;
                    lblActiveProduction.Text = dataView8.RowCount.ToString();

                    if(lblActiveProduction.Text =="0")
                    {
                        lblstats.Text = "DONE";
                    }
                    else
                    {
                        
                        lblstats.Text = "IN PROGRESS";
                        if(lblgood.Text==String.Empty)
                        {

                            lblgood.Text = "0";
                        }

                    }
                }



            }
            catch (SyntaxErrorException)
            {
                MessageBox.Show("Invalid character found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            catch (EvaluateException)
            {
                MessageBox.Show("Invalid character found 234.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }


        }

        private void dataView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void btngreaterthan_Click(object sender, EventArgs e)
        {
            txtproductionid.Visible = true;
            lblprod.Visible = true;
            txtFeedCode.Visible = true;
            lblfeedtype.Visible = true;

            txtprod_id.Focus();
        }

        private void dateTimePicker12_ValueChanged(object sender, EventArgs e)
        {
           
            load_search();
         
            txtproductionid.Visible = true;
            lblprod.Visible = true;
            dataView.Visible = true;
            panel1.Visible = true;
            lblstats.Visible = true;
            groupBox1.Visible = true;
            label5.Visible = true;
            txtluffy.Visible = true;

            if (txtluffy.Text == "0")

            {
                label5.Visible = false;
                txtluffy.Visible = false;
                lblprod.Visible = false;
                txtproductionid.Visible = false;
                groupBox1.Visible = false;
                panel1.Visible = false;
                dataView.Visible = false;
                lblstats.Visible = false;
            }
            else
            {
                txtproductionid.Visible = true;
                lblprod.Visible = true;
                dataView.Visible = true;
                panel1.Visible = true;
                lblstats.Visible = true;
                groupBox1.Visible = true;
                label5.Visible = true;
                txtluffy.Visible = true;


            }

        }

        private void dataView_CurrentCellChanged(object sender, EventArgs e)
        {

            if (dataView.RowCount > 0)
            {
                if (dataView.CurrentRow != null)
                {
                    if (dataView.CurrentRow.Cells["p_feed_code"].Value != null)
                    {
                    
                  txtproductionid.Text = dataView.CurrentRow.Cells["prod_id"].Value.ToString();

                       
                    }

                }
            }


            loadsearch2();


        }
    }
}
