using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace WFFDR
{
    public partial class frmFGView : Form
    {
        myclasses myClass = new myclasses();
        IStoredProcedures g_objStoredProcCollection = null;
        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();
        DataSet dSet_temp = new DataSet();
        public DataSet dset = new DataSet();
        DataSet dset_rights = new DataSet();
        DataSet dSet = new DataSet();
        int p_id = 0;
        int temp_hid = 0;
        string mode = "";
        int emp_flag = 0;
        Boolean ready = false;
        myclasses xClass = new myclasses();
        IStoredProcedures objStorProc = null;
        int rights_id = 0;
        DataSet dset2 = new DataSet();
        frmFGReceivings ths;


        public frmFGView(frmFGReceivings frm, string ProductionID, string PrintingDate)
        {
            InitializeComponent();
            ths = frm;
            textBox1.TextChanged += new EventHandler(textBox1_TextChanged);
            this.ProdID = ProductionID;
            this.PrintingDate = PrintingDate;
        }
        public string ProdID{get; set; }
        public string PrintingDate { get; set; }
        private void frmFGView_Load(object sender, EventArgs e)
        {


     
















            //for (int i = 0; i <= dataView.RowCount; i++)
            //{
            //    try
            //    {
            //        dataView.Rows[i].Cells["selected"].Value = false;
            //    }
            //    catch (Exception) { }
            //}

            //try
            //{

            //}
            //catch (Exception) { }
            //btnsave.Visible = true;
            //objStorProc = xClass.g_objStoredProc.GetCollections();
            //rights_id = userinfo.user_rights_id;
            //deselectAll();
            //// dateTimePicker12.Text = DateTime.Now.ToString("m/d/yyyy");
            //lblprodid.Text = ProdID;
            //txtPrintingDate.Text = PrintingDate;
            //myglobal.global_module = "Active";

            //txtaddedby.Text = userinfo.emp_name.ToUpper();
            //txtdatenow.Text = DateTime.Now.ToString("M/d/yyyy");
            //load_search();
            //doSearch();
            //SumtheTotalBags();












            g_objStoredProcCollection = myClass.g_objStoredProc.GetCollections();

            objStorProc = xClass.g_objStoredProc.GetCollections();

            //if (myClass.g_objStoredProc.getConnected() == true)
            //{


            //    dset = g_objStoredProcCollection.sp_IDGenerator(0, "SelectHR", "", "", 1);
            //    dset2 = g_objStoredProcCollection.sp_IDGenerator(1, "SelectCompany", "", "", 1);



            //    xClass.ActivitiesLogs(userinfo.emp_name + " Generated " + myglobal.REPORT_NAME + " Report");
            //}
            //else
            //{
            //    MessageBox.Show("Unable to connect in sql server", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    this.Close();
            //}



            //int number_of_rows = dset2.Tables[0].Rows.Count - 1;



            //dset = g_objStoredProcCollection.sp_IDGenerator(1, "SearchFGReprint", "All", txtSearch.Text, 1);
            //dataView.DataSource = dset.Tables[0];
















            btnsave.Visible = true;

            rights_id = userinfo.user_rights_id;
            //deselectAll();pekpek
            // dateTimePicker12.Text = DateTime.Now.ToString("m/d/yyyy");
            lblprodid.Text = ProdID;
            txtPrintingDate.Text = PrintingDate;
            myglobal.global_module = "Active";

            txtaddedby.Text = userinfo.emp_name.ToUpper();
            txtdatenow.Text = DateTime.Now.ToString("M/d/yyyy");
            load_search();
            //doSearch();
            SumtheTotalBags();
            //sumOfActualWeight();


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

            }
            catch (Exception) { }


        }

        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cp = base.CreateParams;
        //        cp.ExStyle = cp.ExStyle | 0x2000000;
        //        return cp;
        //    }
        //}

       public void sumOfActualWeight()
        {

            for (int n = 0; n < (dataView.Rows.Count); n++)
            {
                double s = Convert.ToDouble(dataView.Rows[n].Cells[4].Value);
                //double s1 = Convert.ToDouble(lblbatch.Rows[n].Cells[6].Value);
                //double s10 = Convert.ToDouble(lblbatch.Rows[n].Cells[6].Value);


                //double s13 = s1 * s;
                //double s15 = s1 * s13;

                double s25 = s * 2;





                dataView.Rows[n].Cells[17].Value = s25.ToString("#,0.00"); //7/30/2020


            }



        }

        void deselectAll()
        {
            for (int i = 0; i < dataView.RowCount; i++) { dataView.Rows[i].Cells[0].Value = false; }
        }


        public void InsertTransaction()
        {
            txtdatenow.Text = DateTime.Now.ToString("M/d/yyyy");
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            ////        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "INSERT INTO [dbo].[tblreceivingfgtransactions]  (feed_code,feed_type,production_date,fg_date,receiving_date,added_by,date_added,production_id) VALUES" +
                "('"+txtFeedCode.Text+"','"+txtFeedType.Text+"','"+txtProductionDate.Text+"','"+txtPrintingDate.Text+"','"+txtdatenow.Text+"','"+txtaddedby.Text+"','"+txtdatenow.Text+"','"+lblprodid.Text+"')";

            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvTransactionInsert.DataSource = dt;

            sql_con.Close();


        }

        public void SumtheTotalBags()
        {



                decimal tot = 0;
       

            for (int i = 0; i < dataView.RowCount - 0; i++)
            {
                var value = dataView.Rows[i].Cells["ActualWeight"].Value;

              //  double divisor = value / 50;
                //double s1 = Convert.ToDouble(dataView.Rows[i].Cells[6].Value);
                //double s13 = s1 * s;
                //double s15 = s1 * s13;


                if (value != DBNull.Value)
                {
                    tot += Convert.ToDecimal(value);
                }
            }
            if (tot == 0)
            {

            }

            lbltotalweight.Text = tot.ToString("#,0.00");
            lbltotalbags.Text = tot.ToString("#,0.00");

            lbltotalbags.Text = (float.Parse(lbltotalbags.Text) / 50).ToString("#,0.00");

        }




        public void SumtheTotalSelected()
        {


            decimal tot = 0;


         //   if (Convert.ToBoolean(dataView.Rows[i].Cells["selected"].Value.ToString()) == true)
            
                for (int i = 0; i < dataView.RowCount - 0; i++)
            {
                var value = dataView.Rows[i].Cells["ActualWeight"].Value;

                //  double divisor = value / 50;
                //double s1 = Convert.ToDouble(dataView.Rows[i].Cells[6].Value);
                //double s13 = s1 * s;
                //double s15 = s1 * s13;


                if (value != DBNull.Value)
                {
                    tot += Convert.ToDecimal(value);
                }
            }
            if (tot == 0)
            {

            }

            //lbltotalweight.Text = tot.ToString("#,0.00");
            lbltotalselected.Text = tot.ToString("#,0.00");

            lbltotalselected.Text = (float.Parse(lbltotalselected.Text) / 50).ToString("#,0.00");

        }
        void load_search()
        {

            dset_emp1.Clear();

            dset_emp1 = objStorProc.sp_getMajorTables("searchrepackforreceipt");

            doSearch();


        }
        DataSet dset_emp1 = new DataSet();
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

                        //dv.RowFilter = "fg_proddate = '" + dateTimePicker12.Text + "' AND prod_adv like '%" + txtprod_id.Text + "%' AND BagSack like '%" + txtbags.Text + "%' ";
                        dv.RowFilter = "printing_date = '" + txtPrintingDate.Text + "' AND prod_adv like '%" + lblprodid.Text + "%'";


                        //dv.RowFilter = "fg_proddate = '" + dateTimePicker12.Text + "' AND prod_adv like '%" + txtprod_id.Text + "%'";

                    }
                    else if (myglobal.global_module == "VISITORS")
                    {
                        //dv.RowFilter = "visitors_lastname like '%" + txtsearch.Text + "%' or visitors_firstname like '%" + txtsearch.Text + "%'";
                    }
                    dataView.DataSource = dv;
                    lblfound.Text = dataView.RowCount.ToString();

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
                MessageBox.Show("Invalid character found 2 Gerard.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            //}
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ths.textBox1.Text = textBox1.Text;
        }

        private void frmFGView_FormClosing(object sender, FormClosingEventArgs e)
        {
            textBox1.Text = "Gerard MaLAKAS";
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

        private void btnsave_Click(object sender, EventArgs e)
        {

            //if (MetroFramework.MetroMessageBox.Show(this, "Print Finished Goods Bagging Barcoding Entry? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            //{
            //    btnsave.Visible = false;


            //    //myglobal.Searchcategory = txtSearch.Text;
            //    //myglobal.employee_name = cmbHR_OIC.Text;//cmbHR_OIC.Text;
            //    //myglobal.position = cmbPos.Text;//cmbPos.Text;
            //    //myglobal.validity = dt.Text;

            //    //for (int i = 2; i <= dataView.RowCount - 1; i++)
            //    for (int i = 0; i <= dataView.RowCount - 1; i++)
            //    {
            //        try
            //        {
            //            if (Convert.ToBoolean(dataView.Rows[i].Cells["selected"].Value.ToString()) == true)
            //            {
            //                //dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dataView.Rows[i].Cells["ID"].Value.ToString()), "updatefgreceiving", "", "", 1);




            //                dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dataView.Rows[i].Cells["ID"].Value.ToString()), "updatefinalreceived", txtdatenow.Text.Trim(), txtaddedby.Text.Trim(), 1);

            //                //deselectAll();
            //                //load_search();
            //                //doSearch();
            //                //SumtheTotalBags();
            //            }
            //            else
            //            {
            //                //   dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dataView.Rows[i].Cells["ID"].Value.ToString()), "updatefgreceiving", "", "", 0);
            //                dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dataView.Rows[i].Cells["ID"].Value.ToString()), "updatefinalreceived", "", "", 0);
            //            }
            //        }
            //        catch
            //        {
            //            dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dataView.Rows[i].Cells["ID"].Value.ToString()), "updatefinalreceived", "", "", 0);


            //            //    dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dataView.Rows[i].Cells["ID"].Value.ToString()), "updatefgreceiving", "", "", 0);
            //        }

            //    }

            //    deselectAll();
            //    load_search();
            //    doSearch();
            //    SumtheTotalBags();
            //    btnsave.Visible = true;

            //}
            //else
            //{
            //    return;
            //}











            if (MetroFramework.MetroMessageBox.Show(this, "Print Finished Goods Bagging Barcoding Entry? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                UseWaitCursor = true;
              dataView.Enabled = false;
                btnsave.Enabled = false;
                btnsave.BackColor = Color.Red;
                btnSelect.Enabled = false;
                ControlBox = false;
                //myglobal.Searchcategory = txtSearch.Text;
                //myglobal.employee_name = cmbHR_OIC.Text;//cmbHR_OIC.Text;
                //myglobal.position = cmbPos.Text;//cmbPos.Text;
                //myglobal.validity = dt.Text;

                //for (int i = 2; i <= dataView.RowCount - 1; i++)
                for (int i = 0; i <= dataView.RowCount - 1; i++)
                {
                    try
                    {
                        if (Convert.ToBoolean(dataView.Rows[i].Cells["selected"].Value.ToString()) == true)
                        {


                            dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dataView.Rows[i].Cells["ID"].Value.ToString()), "updatefinalreceived", txtdatenow.Text.Trim(), txtaddedby.Text.Trim(), 1);

                            //deselectAll();
                            //load_search();
                            //doSearch();
                            //SumtheTotalBags();
                        }
                        else
                        {
                            //   dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dataView.Rows[i].Cells["ID"].Value.ToString()), "updatefgreceiving", "", "", 0);
                            dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dataView.Rows[i].Cells["ID"].Value.ToString()), "updatefinalreceived", "", "", 0);
                        }
                    }
                    catch
                    {
                        dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dataView.Rows[i].Cells["ID"].Value.ToString()), "updatefinalreceived", "", "", 0);


                        //    dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dataView.Rows[i].Cells["ID"].Value.ToString()), "updatefgreceiving", "", "", 0);
                    }

    
                    btnsave.Enabled = true;
                    btnsave.BackColor = Color.White;
                    ControlBox = true;
                }
                InsertTransaction();
                deselectAll();
                load_search();
                doSearch();
                SumtheTotalBags();
                SuccessFullySaveFinishGoods();
                btnSelect.Enabled = true;
                UseWaitCursor = false;

            }
            else
            {
                return;
            }

        }


        void SuccessFullySaveFinishGoods()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "SuccessFully Received Finish Goods";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Green;
            popup.Popup();
            //popup.AnimationDuration = 1000;
            //popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
 
            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }
        private void dataView_CurrentCellChanged(object sender, EventArgs e)
        {

            if (dataView.CurrentRow != null)
            {
                if (dataView.CurrentRow.Cells["Feed_Code"].Value != null)
                {
                    txtFeedCode.Text = dataView.CurrentRow.Cells["Feed_Code"].Value.ToString();

                    txtFeedType.Text = dataView.CurrentRow.Cells["Feed_Type"].Value.ToString();
                   txtProductionDate.Text = dataView.CurrentRow.Cells["ProdDate"].Value.ToString();

                }
            }

        }

        private void btnDeSelect_Click(object sender, EventArgs e)
        {
            btnSelect.Visible = true;
            btnDeSelect.Visible = false;
            deselectAll();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            btnSelect.Visible = false;
            btnDeSelect.Visible = true;

            selectAll();
        }

        void selectAll()
        {
            for (int i = 0; i < dataView.RowCount; i++) { dataView.Rows[i].Cells[0].Value = true; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmFGView_Load(sender, e);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
