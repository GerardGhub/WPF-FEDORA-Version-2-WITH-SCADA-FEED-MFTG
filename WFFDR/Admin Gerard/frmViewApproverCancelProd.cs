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
    public partial class frmViewApproverCancelProd : Form
    {
        myclasses xClass = new myclasses();
        IStoredProcedures objStorProc = null;
        Boolean ready = false;
        DataSet dSet = new DataSet();
        DataSet dSet_temp = new DataSet();
        string mode = "";
        int p_id = 0;
        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();


        public frmViewApproverCancelProd()
        {
            InitializeComponent();
        }

        private void frmProdType_Load(object sender, EventArgs e)
        {
            txtdatenow.Text = DateTime.Now.ToString();
            mfg_datePicker.MinDate = DateTime.Today;
            objStorProc = xClass.g_objStoredProc.GetCollections();

            load_SchedulesCancelByApprover();

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
        public void load_SchedulesCancelByApprover()
        {
            string mcolumns = "test,prod_id.p_feed_code,p_bags,p_nobatch,proddate,dateadded,iscancelapprover,approver_cancelrequest_date";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgvApproved, mcolumns, "schedules_approved_approver_cancel");
            //  lblrecords.Text = dgv_table.RowCount.ToString();
            // textBox1.Text = dgv_table.RowCount.ToString();
            lbllost.Text = dgvApproved.RowCount.ToString();

        }

        private void dgvApproved_CurrentCellChanged(object sender, EventArgs e)
        {
            mfg_datePicker2.Visible = true;
            if (dgvApproved.RowCount > 0)
            {
                if (dgvApproved.CurrentRow != null)
                {
                    if (dgvApproved.CurrentRow.Cells["prod_id"].Value != null)
                    {
                        p_id = Convert.ToInt32(dgvApproved.CurrentRow.Cells["prod_id"].Value);

                        txtproductionid.Text = dgvApproved.CurrentRow.Cells["prod_id"].Value.ToString();
                        cboFeedCode.Text = dgvApproved.CurrentRow.Cells["fcode"].Value.ToString();
                        txtbags.Text = dgvApproved.CurrentRow.Cells["bags"].Value.ToString();
                        txtnobatch.Text = dgvApproved.CurrentRow.Cells["batch"].Value.ToString();
                        mfg_datePicker2.Text = dgvApproved.CurrentRow.Cells["prod"].Value.ToString();
                    txtreason.Text = dgvApproved.CurrentRow.Cells["iscancelapprover"].Value.ToString();
                        //txtdatenow.Text = dgvApproved.CurrentRow.Cells["added"].Value.ToString();
                    }

                }
            }
        }

        private void bunifuThinButton27_Click(object sender, EventArgs e)
        {
            mfg_datePicker.Text = dgvApproved.CurrentRow.Cells["prod"].Value.ToString();
            dgvApproved_Click(sender,e);
            if (txtnobatch.Text.Trim() == string.Empty)
            {

            }
            else
            {

                //1/24/2021
                txttotalQty.Text = (float.Parse(txtQuantity.Text) * float.Parse(txtnobatch.Text)).ToString();
            }
            mfg_datePicker.Visible = true;
            mfg_datePicker2.Visible = false;
            mfg_datePicker.Enabled = true;
            txtbags.Enabled = true;
            bunifuThinButton27.Visible = false;
            bunifuThinButton210.Visible = true;
            bunifuUndo.Visible = true;
            dgvApproved.Enabled = false;
            btnSubmit.Enabled = false;
            bunifuCancel.Enabled = false;
        }

        void EmptyFieldNotify()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Fill up the Empty Field First";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.DarkOrange;
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



        void BagsDotNotify()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Your Actual Bags Is not meet our Requirment Batch at'" + txtnobatch.Text + "'!";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.DarkOrange;
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

        private void metroButton2_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, " Start of Validation and Update the Production Schedule ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {






                if (txtbags.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtbags.Focus();
                    txtbags.Select();
                    txtbags.BackColor = Color.Yellow;
                    return;
                }


                if (txtnobatch.Text.Contains("."))
                {
                    //MessageBox.Show("Approved");
                    BagsDotNotify();
                    txtbags.BackColor = Color.Yellow;
                    txtbags.Focus();
                    txtbags.Select();
                    return;
                }
                else
                {
                    //MessageBox.Show("DisApproved");
                }

                double mainbalance;
                double selectquantity;


                mainbalance = double.Parse(txtrepackavailable.Text);
                selectquantity = double.Parse(txttotalQty.Text);
                if (mainbalance < selectquantity)
                {
                    NoBalanceNotify();
                    btngreaterthan_Click(sender, e);
                    bunifuUndo_Click(sender, e);
                    //bunifuReset_Click(sender, e);

                    //this.dgvImport.CurrentCell = this.dgvImport.Rows[0].Cells[this.dgvImport.CurrentCell.ColumnIndex];
                    txtbags.BackColor = Color.Yellow;
                    txtbags.Focus();
                    return;
                }
                else
                {
                    //WithBalanceNotify(); alis muna 4/13/2020
                    btnlessthan_Click(sender, e);
                    //MessageBox.Show("1");

                }






            }
            else
            {
                bunifuUndo_Click(sender, e);
                return;
            }
        }
        void NoBalanceNotify()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Not Enough Stock for " + txtitemdescription.Text + " Current Balance is " + txtrepackavailable.Text + " and the Actual Needed for Production is " + txttotalQty.Text + "";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.DarkOrange;
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

            //this.dgvImport.CurrentCell = this.dgvImport.Rows[0].Cells[this.dgvImport.CurrentCell.ColumnIndex];
            //dgvImport.Refresh();



        }


        public bool saveMode()
        {

            if (mode == "add")
            {
                dSet.Clear();
                dSet = objStorProc.rdf_sp_prod_schedules(0, cboFeedCode.Text, txtbags.Text, "", "", "", "","","","","","","", "getbyname");

                if (dSet.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("animals", "Offense", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboFeedCode.Focus();
                    return false;
                }
                else
                {
                    dSet.Clear();
                    dSet = objStorProc.rdf_sp_prod_schedules(0, cboFeedCode.Text.Trim(), txtbags.Text.Trim(), txtnobatch.Text.Trim(), mfg_datePicker.Text.Trim(), txtdatenow.Text.Trim(), txtreason.Text.Trim(),textBox1.Text.Trim(),"","","","","", "add");

                    return true;
                }
            }
            else if (mode == "edit")
            {
                dSet.Clear();
                //dSet = objStorProc.rdf_sp_supplier(0, txtSupplier.Text, txtContactNo.Text, txtAddress.Text, txtEmailAddress.Text, "getbyname"); buje muna
                dSet = objStorProc.rdf_sp_prod_schedules(0, cboFeedCode.Text.Trim(), txtbags.Text.Trim(), txtnobatch.Text.Trim(), mfg_datePicker.Text.Trim(), txtdatenow.Text.Trim(), txtreason.Text.Trim(),textBox1.Text.Trim(),"","","","","", "getbyfeedcode");
                dSet_temp.Clear();


                //dSet_temp = objStorProc.rdf_sp_supplier(p_id, txtSupplier.Text, txtContactNo.Text, txtAddress.Text, txtEmailAddress.Text, "getbyid"); buje muna
                dSet_temp = objStorProc.rdf_sp_prod_schedules(p_id, cboFeedCode.Text.Trim(), txtbags.Text.Trim(), txtnobatch.Text.Trim(), mfg_datePicker.Text.Trim(), txtdatenow.Text.Trim(), txtreason.Text.Trim(),textBox1.Text.Trim(),"","","","","", "getbyid");
                if (dSet.Tables[0].Rows.Count > 0)
                {
                    int tmpID = Convert.ToInt32(dSet.Tables[0].Rows[0][7].ToString());
                    if (tmpID == p_id)
                    {
                        dSet.Clear();
                        //dSet = objStorProc.rdf_sp_supplier(p_id, txtSupplier.Text.Trim(), txtContactNo.Text.Trim(), txtAddress.Text.Trim(), txtEmailAddress.Text.Trim(), "edit"); buje muna
                        dSet = objStorProc.rdf_sp_prod_schedules(p_id, cboFeedCode.Text.Trim(), txtbags.Text.Trim(), txtnobatch.Text.Trim(), mfg_datePicker.Text.Trim(), txtdatenow.Text.Trim(), txtreason.Text.Trim(),textBox1.Text.Trim(),"","","","","", "edit");

                        return true;
                    }
                    else
                    {
                        //MessageBox.Show("Offense code is already added.", "Offense", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dSet = objStorProc.rdf_sp_prod_schedules(p_id, cboFeedCode.Text.Trim(), txtbags.Text.Trim(), txtnobatch.Text.Trim(), mfg_datePicker.Text.Trim(), txtdatenow.Text.Trim(), txtreason.Text.Trim(),textBox1.Text.Trim(),"","","","","", "edit");
                        //load_Schedules();
                        load_SchedulesCancelByApprover();
                        UpdateOkay();
                        return false;
                    }
                }
                else
                {
                    dSet.Clear();
                    //dSet = dSet = objStorProc.rdf_sp_supplier(p_id, txtSupplier.Text.Trim(), txtContactNo.Text.Trim(), txtAddress.Text.Trim(), txtEmailAddress.Text.Trim(), "edit"); buje muna


                    return true;
                }
            }
            else if (mode == "cancel")
            {
                dSet.Clear();
                dSet = objStorProc.rdf_sp_prod_schedules(0, cboFeedCode.Text.Trim(), txtbags.Text.Trim(), txtnobatch.Text.Trim(), mfg_datePicker.Text.Trim(), txtdatenow.Text.Trim(), txtreason.Text.Trim(),textBox1.Text.Trim(),"","","","","", "getbyname");
                dSet_temp.Clear();



                dSet_temp = objStorProc.rdf_sp_prod_schedules(p_id, cboFeedCode.Text.Trim(), txtbags.Text.Trim(), txtnobatch.Text.Trim(), mfg_datePicker.Text.Trim(), txtdatenow.Text.Trim(), txtreason.Text.Trim(),textBox1.Text.Trim(),"","","","","", "getbyid");
                if (dSet.Tables[0].Rows.Count > 0)
                {
                    int tmpID = Convert.ToInt32(dSet.Tables[0].Rows[0][7].ToString());
                    if (tmpID == p_id)
                    {
                        dSet.Clear();

                        dSet = objStorProc.rdf_sp_prod_schedules(p_id, cboFeedCode.Text.Trim(), txtbags.Text.Trim(), txtnobatch.Text.Trim(), mfg_datePicker.Text.Trim(), txtdatenow.Text.Trim(), txtreason.Text.Trim(),textBox1.Text.Trim(),"","","","","", "cancel");

                        return true;
                    }
                    else
                    {
                        //MessageBox.Show("Offense code is already added.", "Offense", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        load_SchedulesCancelByApprover();
                        return false;
                    }
                }
                else
                {
                    dSet.Clear();



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

        void UpdateOkay()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Production Schedule Updated Successfully !";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.DarkGreen;
            popup.Popup();
            popup.AnimationDuration = 1000;
            popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;
            cboFeedCode.Focus();
            dgvApproved.Enabled = true;


        }

        private void bunifuThinButton210_Click(object sender, EventArgs e)
        {
          
            metroButton2_Click(sender,e);
        }

        private void bunifuUndo_Click(object sender, EventArgs e)
        {
            txtbags.BackColor = Color.White;
            dgvApproved_CurrentCellChanged(sender, e);
            txtbags.Enabled = false;
            bunifuThinButton210.Visible = false;
            bunifuThinButton27.Visible = true;
            //bunifuThinButton29_Click(sender, e); bolang
            bunifuUndo.Visible = false;
            mfg_datePicker.Visible = false;
            dgvApproved.Enabled = true;
            mfg_datePicker2.Visible = true;
            bunifuSubmit.Visible = false;
            bunifuCancel.Visible = true;
            bunifuThinButton26.Enabled = false;
            dgvApproved.Enabled = true;
            btnSubmit.Enabled = true;
            bunifuCancel.Enabled = true;

            btnSubmit.Enabled = true;
            bunifuThinButton27.Enabled = true;
        }

        private void txtbags_TextChanged(object sender, EventArgs e)
        {
           
            try
            {


                txtnobatch.Text = (float.Parse(txtbags.Text) / 40).ToString();
            }
            catch (Exception)
            {


            }

            if (txtbags.Text.Trim() == string.Empty)
            {

                txtnobatch.Text = "";
                txtbags.BackColor = Color.White;

            }
            else
            {

                txtbags.BackColor = Color.White;







            }


            if (txtnobatch.Text.Contains("."))
            {
                //MessageBox.Show("Approved");

                txtnobatch.BackColor = Color.Yellow;

            }
            else
            {
                txtnobatch.BackColor = Color.White;
                //MessageBox.Show("DisApproved");
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuSubmit_Click(object sender, EventArgs e)
        {
            metroButton3_Click(sender, e);
        }

        private void dgvApproved_Click(object sender, EventArgs e)
        {
            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "select distinct recipe_id,rp_type,feed_code,item_code,rp_description,rp_category,rp_group,quantity,rp_feed_type from [dbo].[rdf_recipe] WHERE feed_code = '" + cboFeedCode.Text + "' AND is_active=1 ORDER BY rp_category DESC";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvImport.DataSource = dt;



            sql_con.Close();
            if (ready == true)
                ready = true;
                btnsum_Click(sender, e);
            times2query();

            dgvImport_CurrentCellChanged(sender, e);
            //txtbags.Text = "";
            //txtbags.Focus();


        }


        void times2query()
        {
            for (int n = 0; n < (dgvImport.Rows.Count); n++)
            {
                //double s = Convert.ToDouble(dgvImport.Rows[n].Cells[4].Value);


                //double s1 = Convert.ToDouble(dgvAllFeedCode.Rows[n].Cells[7].Value);

                double s1 = Convert.ToDouble(dgvImport.Rows[n].Cells[7].Value);

                //int s1 = Convert.ToInt32(dgv1stView.Rows[n].Cells[1].Value);
                //double s13 = s * 2;
                double s15 = s1 * 2;

                //dgvImport.Rows[n].Cells[7].Value = s15.ToString("#,0.000");
                dgvImport.Rows[n].Cells[7].Value = s15.ToString();


                //dgvAllFeedCode.Rows[n].Cells[4].Value = s13.ToString("#,0.000");
                //dgvAllFeedCode.Rows[n].Cells[7].Value = s15.ToString("#,0.000");
            }


        }


        private void dgvImport_CurrentCellChanged(object sender, EventArgs e)
        {
            ready = true;
            showImportDataGrid();
        }


        void showImportDataGrid()
        {

            if (ready == true)
            {
                if (dgvImport.CurrentRow != null)
                {
                    if (dgvImport.CurrentRow.Cells["recipe_id"].Value != null)
                    {
                        p_id = Convert.ToInt32(dgvImport.CurrentRow.Cells["recipe_id"].Value);
                        txtItemCode.Text = dgvImport.CurrentRow.Cells["item_code"].Value.ToString();
                        txtQuantity.Text = dgvImport.CurrentRow.Cells["quantity2"].Value.ToString();
                        txtitemdescription.Text = dgvImport.CurrentRow.Cells["rp_description"].Value.ToString();
                     textBox1.Text = dgvImport.CurrentRow.Cells["rp_feed_type"].Value.ToString();

                    }
                }
            }
        }

        private void btnsum_Click(object sender, EventArgs e)
        {
            dgvImport[6, dgvImport.Rows.Count - 1].Value = "Total";
            dgvImport.Rows[dgvImport.Rows.Count - 1].Cells[0].Style.BackColor = Color.Green;
            dgvImport.Rows[dgvImport.Rows.Count - 1].Cells[0].Style.ForeColor = Color.Red;
            decimal tot = 0;

            for (int i = 0; i < dgvImport.RowCount - 1; i++)
            {
                var value = dgvImport.Rows[i].Cells["quantity2"].Value;
                if (value != DBNull.Value)
                {
                    tot += Convert.ToDecimal(value) * 2;
                }
            }
            if (tot == 0)
            {

            }
            //dgvImport.Rows[dgvImport.Rows.Count - 1].Cells["quantity2"].Value = tot.ToString();

            lblCounts.Text = dgvImport.RowCount.ToString();
            lblCountss.Text = tot.ToString();
        }

        private void btnlessthan_Click(object sender, EventArgs e)
        {
            if (dgvImport.Rows.Count >= 1)
            {
                int i = dgvImport.CurrentRow.Index + 1;
                if (i >= -1 && i < dgvImport.Rows.Count)
                    dgvImport.CurrentCell = dgvImport.Rows[i].Cells[0];

                else
                {

                    this.dgvImport.CurrentCell = this.dgvImport.Rows[0].Cells[this.dgvImport.CurrentCell.ColumnIndex];

                    metroSave_Click(sender, e);
  
                    return;
                }
                txttotalQty.Text = (float.Parse(txtQuantity.Text) * float.Parse(txtnobatch.Text)).ToString();
                double mainbalance;
                double selectquantity;


                mainbalance = double.Parse(txtrepackavailable.Text);
                selectquantity = double.Parse(txttotalQty.Text);
                if (mainbalance < selectquantity)
                {
                    NoBalanceNotify();
                    btngreaterthan_Click(sender, e);
                    bunifuUndo_Click(sender, e);
                    //bunifuReset_Click(sender, e);
                    //this.dgvImport.CurrentCell = this.dgvImport.Rows[0].Cells[this.dgvImport.CurrentCell.ColumnIndex];
                    txtbags.BackColor = Color.Yellow;
                    txtbags.Focus();
                    return;
                }
                else
                {
                    //MessageBox.Show("Keribels");
                    txttotalQty.Text = (float.Parse(txtQuantity.Text) * float.Parse(txtnobatch.Text)).ToString();
                    btnStartingValidation_Click(sender, e);

                }

            }
        }

        private void btnStartingValidation_Click(object sender, EventArgs e)
        {

            double mainbalance;
            double selectquantity;


            mainbalance = double.Parse(txtrepackavailable.Text);
            selectquantity = double.Parse(txttotalQty.Text);
            if (mainbalance < selectquantity)
            {
                NoBalanceNotify();
                btngreaterthan_Click(sender, e);
                bunifuUndo_Click(sender, e);
                //this.dgvImport.CurrentCell = this.dgvImport.Rows[0].Cells[this.dgvImport.CurrentCell.ColumnIndex];
                txtbags.BackColor = Color.Yellow;
                txtbags.Focus();
                return;
            }
            else
            {
                //WithBalanceNotify(); alis muna 4/13/2020
                btnlessthan_Click(sender, e);
                //MessageBox.Show("1");

            }
        }

        private void txtItemCode_TextChanged(object sender, EventArgs e)
        {
            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "select a.item_id,a.item_code,a.item_description,a.total_quantity_raw,a.qty_repack_available,a.qty_repack,a.qty_production,ISNULL(t5.RECEIVING,0) + ISNULL(t6.ISSUE,0) - ISNULL(t2.MACRESERVED,0) as RESERVED from [dbo].[rdf_raw_materials] a LEFT JOIN ( select BC.r_item_code, sum(CAST(REPLACE(BC.r_quantity,',','') as float))  as RECEIVING from rdf_microreceiving_entry BC where is_active='1' and BC.transaction_type='PO' group by BC.r_item_code) t5 on a.item_code = t5.r_item_code LEFT JOIN ( select BC.r_item_code, sum(CAST(REPLACE(BC.actual_count_good,',','') as float))  as ISSUE from rdf_microreceiving_entry BC where BC.receiving_status='1' and BC.is_active='1' and BC.transaction_type='Miscellaneous Receipt' group by BC.r_item_code) t6 on a.item_code = t6.r_item_code LEFT JOIN ( select BC.item_code, sum(CAST(BC.quantity as float)* 2)  as MACRESERVED from rdf_recipe_to_production BC where CAST(BC.proddate as date) BETWEEN '2021-01-12' and GETDATE()+30 and status_of_person IS NULL group by BC.item_code) t2 on a.item_code = t2.item_code WHERE a.item_code = '" + txtItemCode.Text + "'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvMaster2.DataSource = dt;

            sql_con.Close();
        }

        private void dgvMaster2_CurrentCellChanged(object sender, EventArgs e)
        {
            showRawMatsDataGrid();
        }

        void showRawMatsDataGrid()
        {
            if (ready == true)
            {
                if (dgvMaster2.CurrentRow != null)
                {
                    if (dgvMaster2.CurrentRow.Cells["item_id"].Value != null)
                    {
                        p_id = Convert.ToInt32(dgvMaster2.CurrentRow.Cells["item_id"].Value);
                        txtrepackavailable.Text = dgvMaster2.CurrentRow.Cells["RESERVED"].Value.ToString();


                    }
                }
            }
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {

        }

        private void metroSave_Click(object sender, EventArgs e)
        {

            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Save The Production Schedule?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                bunifuThinButton210.Visible = false;
                bunifuThinButton27.Visible = true;
                bunifuUndo.Visible = false;
                //dgvApproved_CurrentCellChanged(sender, e);
                //bunifuThinButton29_Click(sender, e);//bolang

                mode = "edit";
                if (txtbags.Text.Trim() == string.Empty)
                {

                }


                else
                {




                    QueryDeleteRecipe();


                    dSet.Clear();
                    dSet = objStorProc.rdf_sp_prod_schedules(0, txtproductionid.Text, "", "", "", "", "", "", "", "", "", "","", "exchangeFormulation");

                    if (dSet.Tables[0].Rows.Count > 0)
                    {
    
                        //MessageBox.Show("A");
                        //return;
                    }
                    else
                    {
                        //MessageBox.Show("b");
                        FormulationeXTRACTION();

                    }

                    //gerard singian malakas
                    QueryUpdateProdSchedules();
                    btnfinishvalidation_Click(sender, e); // gerard 4/20/2020
                    UpdateOkay();

                    load_SchedulesCancelByApprover();
  
                }
            }
            else
            {
                return;
            }



            }


        public void FormulationeXTRACTION()
        {
            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            //deploy
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "INSERT [dbo].[rdf_recipe_to_production] (item_code, quantity, feed_code,repacking_status,production_id,is_active,rp_type,rp_feed_type,rp_description,rp_category,rp_group,total_qty,total_prod,proddate,formulation_qty,batch) SELECT item_code,quantity, feed_code, '1','" + txtproductionid.Text + "','1',rp_type,rp_feed_type,rp_description,rp_category,rp_group,'0','0','"+mfg_datePicker.Text+"',CAST(quantity as float)*2 * '" + txtnobatch.Text + "','" + txtnobatch.Text + "' FROM rdf_recipe WHERE feed_code= '" + cboFeedCode.Text + "' AND rp_category='MICRO'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvRunningRecipe.DataSource = dt;

            sql_con.Close();


            DoMicroChecking();

            //MessageBox.Show("New Data Inserted Into Database!");

        }


        void DoMicroChecking()
        {
            if (txtnobatch.Text == "1")
            {
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "2")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "2")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "3")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "4")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "5")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "6")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "7")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "8")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "9")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "10")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "11")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "12")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "13")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "14")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "15")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "16")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "17")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();

                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "18")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "19")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "20")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "21")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "22")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "23")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "24")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "25")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "26")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "27")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "28")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "29")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "30")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "31")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();

            }
            else if (txtnobatch.Text == "32")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();

                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();

                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();

                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "33")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();

                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "34")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();

                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "35")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();


            }
            else if (txtnobatch.Text == "36")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();

            }
            else if (txtnobatch.Text == "37")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();

            }
            else if (txtnobatch.Text == "38")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();

            }

            else if (txtnobatch.Text == "39")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();

            }
            else if (txtnobatch.Text == "40")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "41")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "42")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "43")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "44")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "45")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "46")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "47")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "48")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "49")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();

            }
            else if (txtnobatch.Text == "50")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();


            }
            else
            {
                MessageBox.Show("Bacth Not Found!");
            }
        }

        void mainPrimaryMacro()
        {


            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            //deploy
            SqlConnection sql_con = new SqlConnection(connetionString);



            //string sqlquery = "INSERT [dbo].[rdf_recipe_to_production] (item_code, quantity, feed_code,repacking_status,production_id,is_active,rp_type,rp_feed_type,rp_description,rp_category,rp_group) SELECT item_code, quantity, feed_code, repacking_status,'" + txtid.Text + "',is_active,rp_type,rp_feed_type,rp_description,rp_category,rp_group FROM rdf_recipe WHERE feed_code= '" + cboFeedCode.Text + "' AND rp_category='MICRO'"AND rp_group='Validate';
            string sqlquery = "INSERT [dbo].[rdf_recipe_to_production] (item_code, quantity, feed_code,repacking_status,production_id,is_active,rp_type,rp_feed_type,rp_description,rp_category,rp_group,total_prod,total_qty,proddate) SELECT item_code, quantity, feed_code, '0','" + txtproductionid.Text + "',is_active,rp_type,rp_feed_type,rp_description,rp_category,rp_group,'0','0','" + mfg_datePicker.Text + "' FROM rdf_recipe WHERE feed_code= '" + cboFeedCode.Text + "' AND rp_category='MACRO'";


            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvRunningRecipe.DataSource = dt;
            //dgvMaster.Visible = true;
            ////dgv_table_2nd_sup.Visible = true;
            //lblmicroview.Visible = true;
            sql_con.Close();

        }


        //Gerard Singian AMMY
        void QueryUpdateProdSchedules()
        {

            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "UPDATE [dbo].[rdf_production_advance] SET repacking_status='ready' ,p_bags= '" + txtbags.Text + "',p_nobatch='" + txtnobatch.Text + "',proddate='" + mfg_datePicker.Text + "', iscancelapproverbit=NULL  WHERE prod_id= '" + txtproductionid.Text + "'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
          dgvUpdate.DataSource = dt;
            //dgvMaster.Visible = true;
            ////dgv_table_2nd_sup.Visible = true;
            //lblmicroview.Visible = true;


            sql_con.Close();
        }

        void QueryDeleteRecipe()
        {

            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "DELETE [dbo].[rdf_recipe_to_production] WHERE production_id= '" + txtproductionid.Text + "'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvUpdate.DataSource = dt;
            //dgvMaster.Visible = true;
            ////dgv_table_2nd_sup.Visible = true;
            //lblmicroview.Visible = true;


            sql_con.Close();
        }





        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {

        }

        private void btngreaterthan_Click(object sender, EventArgs e)
        {
            int prev = this.dgvImport.CurrentRow.Index - 1;
            if (prev >= 0)
            {

                this.dgvImport.CurrentCell = this.dgvImport.Rows[0].Cells[this.dgvImport.CurrentCell.ColumnIndex];

            }
            else
            {
         
            }
        }

        private void btnfinishvalidation_Click(object sender, EventArgs e)
        {

            double mainbalance;
            double selectquantity;


            mainbalance = double.Parse(txtrepackavailable.Text);
            selectquantity = double.Parse(txttotalQty.Text);
            if (selectquantity > mainbalance)
            {
                NoBalanceNotify();
                return;
            }
            else
            {
                txttotalQty.Text = (float.Parse(txtQuantity.Text) * float.Parse(txtnobatch.Text)).ToString();
                double rp1;
                double rp2;
                double rpavailable;

                rp1 = double.Parse(txtrepackavailable.Text);
                rp2 = double.Parse(txttotalQty.Text);

                rpavailable = rp1 - rp2;


                txtdeductions.Text = Convert.ToString(rpavailable);
                //WithBalanceNotify(); alis muna 4 / 13 / 2020
                QueryOutProduction();
                txtdeductions.Text = "";
                btnlessthan2_Click(sender, e);
                //MessageBox.Show("1");

            }




        }

        void QueryOutProduction()
        {

            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "UPDATE [dbo].[rdf_raw_materials] SET qty_production='" + txtdeductions.Text + "'  WHERE item_code= '" + txtItemCode.Text + "'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvUpdate.DataSource = dt;
            //dgvMaster.Visible = true;
            ////dgv_table_2nd_sup.Visible = true;
            //lblmicroview.Visible = true;
            sql_con.Close();
        }


        private void btnlessthan2_Click(object sender, EventArgs e)
        {

            if (dgvImport.Rows.Count >= 1)
            {
                int i = dgvImport.CurrentRow.Index + 1;
                if (i >= -1 && i < dgvImport.Rows.Count)
                    dgvImport.CurrentCell = dgvImport.Rows[i].Cells[0];
                else
                {
                    //LastLine();
                    //MessageBox.Show("Finish na"); 4/14/2020

                    btngreaterthan_Click(sender, e);
                    //bunifuThinButton26_Click(sender, e);
                    return;
                }
            }


            double mainbalance;
            double selectquantity;


            mainbalance = double.Parse(txtrepackavailable.Text);
            selectquantity = double.Parse(txtQuantity.Text);
            if (mainbalance < selectquantity)
            {
                NoBalanceNotify();
                return;
            }
            else


            {
                txttotalQty.Text = (float.Parse(txtQuantity.Text) * float.Parse(txtnobatch.Text)).ToString();

                double rp1;
                double rp2;
                double rpavailables;

                rp1 = double.Parse(txtrepackavailable.Text);
                rp2 = double.Parse(txttotalQty.Text);

                rpavailables = rp1 - rp2;
                txtdeductions.Text = Convert.ToString(rpavailables);
                //WithBalanceNotify();
                QueryOutProduction();
                txtdeductions.Text = "";
                btnfinishvalidation_Click(sender, e);
                //btnlessthan_Click(sender, e);
                //MessageBox.Show("1");

            }
        }

        private void bunifuReset_Click(object sender, EventArgs e)
        {
            txtbags.BackColor = Color.White;
            txtbags.Text = "";
            dgvApproved_CurrentCellChanged(sender, e);
            //txtbags.Enabled = false;
            //bunifuThinButton210.Visible = false;
            //bunifuThinButton27.Visible = true;
            //bunifuThinButton29_Click(sender, e); bolang
            bunifuUndo.Visible = false;
            mfg_datePicker.Visible = false;
            dgvApproved.Enabled = true;
            mfg_datePicker2.Visible = true;
            bunifuSubmit.Visible = false;
            bunifuCancel.Visible = true;
            bunifuThinButton26.Enabled = false;
            dgvApproved.Enabled = true;
            btnSubmit.Enabled = true;
            bunifuCancel.Enabled = true;

            btnSubmit.Enabled = true;
            bunifuThinButton27.Enabled = true;
        }

        private void bunifuCancel_Click(object sender, EventArgs e)
        {
            //txtreason.Enabled = true;
            //txtreason.Focus();
            metroButton3_Click(sender, e);
        }

        void SelectEntryatDataGridNotify()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "SELECT ENTRY AT THE DATAGRID FIRST !";
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
        private void metroButton3_Click(object sender, EventArgs e)
        {


            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Cancel the Production Schedule? ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                //bunifuCancel.Visible = true;
                //txtreason.Enabled = false;
                //bunifuSubmit.Visible = false;

                //mode = "cancel";
                //if (txtreason.Text.Trim() == string.Empty)
                //{
                //    SelectEntryatDataGridNotify();
                //    txtreason.Focus();
                //    return;
                //}


                //else
                //{


                btncancelquery_Click(sender, e);

                load_SchedulesCancelByApprover();


                cancelNotify();





            }

            //    }

            //}

            else
            {
                return;

            }

        }

        void cancelNotify()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "CANCELING OF PRODUCTION SCHEDULE SUCCESSFULLY DONE";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Green;
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

            bunifuThinButton24.Visible = false;
            label6.Visible = false;

            txtreason.Visible = false;
            txtreason.Text = "";

        }

        private void btncancelquery_Click(object sender, EventArgs e)
        {
            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=FedoraMain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);

            //string sqlquery = "UPDATE [dbo].[rdf_recipe] SET receiving_status = '0'  WHERE received_id = '" + txtID.Text + "'";


            string sqlquery = "UPDATE [dbo].[rdf_production_advance] SET iscancel='1' WHERE prod_id='" + txtproductionid.Text + "'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
           dgvoutcancel.DataSource = dt;

            //txtsearchitems_TextChanged(sender, e);











            sql_con.Close();
        }

        private void bunifuThinButton212_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton28_Click(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton29_Click(object sender, EventArgs e)
        {

        }
    }


}
