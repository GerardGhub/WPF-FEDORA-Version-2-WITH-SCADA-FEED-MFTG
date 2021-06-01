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
    public partial class frmFGReceipt : Form
    {

        myclasses xClass = new myclasses();
        DataSet dSet = new DataSet();
        //DataSet dSets = new DataSet();
        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();
        IStoredProcedures objStorProc = null;
        public frmFGReceipt()
        {
            InitializeComponent();
        }

        private void frmFGReceipt_Load(object sender, EventArgs e)
        {

            // Calling the Stored PROC 
            objStorProc = xClass.g_objStoredProc.GetCollections();


            txtaddedby.Text = userinfo.emp_name.ToUpper();
            
            loadFeedCode();
            DateTime dNow = DateTime.Now;
           mfg_datePicker.Text = (dNow.ToString("M/d/yyyy"));
            transdatenow.Text = dNow.ToString("MM/dd/yyyy");
            mfg_datePicker.MaxDate = DateTime.Now;
          


            load_Schedules();
            Disable();
            load_transactions_count();
            if (lblrecords.Text == "0")
            {
                btnTransact.Visible = false;
                button1.Visible = false;
                txtremarks.Text = "";
               
                    
            }
            else
            {
                dgvFG_CurrentCellChanged(sender, e);
                btnTransact.Visible = true;
                button1.Visible = true;
            }
            



        }

       private void Disable()

        {
            cboFeedCode.Enabled = false;
            btnInsert.Visible = true;
            btnsave.Visible = false;
            cboOptions.Enabled = false;
            cboFeedCode.Text = "";
            txtFeedType.Text = "";
            txtbags.Text = "";
            cboOptions.Text = "";
            //txtremarks.Enabled = false;
            txtbags.Enabled = false;

        }

        public void load_Schedules()
        {
            string mcolumns = "test,prod_adv,fg_feed_code,fg_feed_type,fg_bags,fg_batch,fg_options,actual_weight,fg_proddate,Remarks";
            pointer_module.populateModuleMoveOrder(dsetHeader, dgvFG, mcolumns, "callreceipt", txtaddedby.Text.ToString(),0,"","");
            lblrecords.Text = dgvFG.RowCount.ToString();
            this.dgvFG.Columns["Remarks"].Visible = false;
            this.dgvFG.Columns["prod_adv"].Visible = false;
        }
            void loadFeedCode()
        {


            xClass.fillComboBoxFGReceipt(cboFeedCode, "feed_code_fg_receipt_inactive", dSet);
            cboFeedCode.SelectedIndex = -1;

        }

        void Feedcodetransactionbag()

        {

            dSet.Clear();
            dSet = objStorProc.sp_rdf_fg_feedcodetransaction(0, txtorderno.Text.Trim(), fcmain.Text.Trim(), ftmain.Text.Trim(), cmain.Text.Trim(), bagweight.Text.Trim().ToString(), pmain.Text.Trim().ToString(), pmain.Text.Trim().ToString(), transdatenow.Text.Trim(), "RECEIPT", rmain.Text, abmain.Text.Trim(), "add");


        }

        void Feedcodetransactionbulk()
        {

            dSet.Clear();
            dSet = objStorProc.sp_rdf_fg_feedcodetransaction(0, txtorderno.Text.Trim(), fcmain.Text.Trim(), ftmain.Text.Trim(), cmain.Text.Trim(), qkmain.Text.Trim().ToString(), pmain.Text.Trim().ToString(), pmain.Text.Trim().ToString(), transdatenow.Text.Trim(), "RECEIPT", rmain.Text, abmain.Text.Trim(), "add");



        }

        void QueryOutFGRepackinbulk()
        {

            dSet.Clear();

            dSet = objStorProc.rdf_sp_new_finish_goods(0, txtorderno.Text.Trim(), fcmain.Text.Trim(), ftmain.Text.Trim(), qbmain.Text.Trim(), bnmain.Text.Trim(), pmain.Text.Trim(), pmain.Text.Trim(), pmain.Text.Trim(), pmain.Text.Trim(), pmain.Text, "1", abmain.Text.Trim(), qkmain.Text.Trim(), "NO BARCODE", qbmain.Text.Trim(), onmain.Text.Trim(), bnmain.Text.Trim(), qbmain.Text.Trim(), cmain.Text.Trim(), "Good", pmain.Text.Trim(), "0", "addbulk_receipt_repackin");

        }

        void QueryOutFGRepackin()

        {
            //    dSet.Clear();

            //    dSets = objStorProc.rdf_sp_new_finish_goods(0, cboFeedCode.Text.Trim(), cboFeedCode.Text.Trim(), txtFeedType.Text.Trim(), txtbags.Text.Trim(), txtbacthno.Text.Trim(), mfg_datePicker.Text.Trim(), mfg_datePicker.Text.Trim(), mfg_datePicker.Text.Trim(), mfg_datePicker.Text.Trim(), mfg_datePicker.Text, "1", txtaddedby.Text.Trim(), txttimes50.Text.Trim(), "NO BARCODE", txtbags.Text.Trim(), txtorderno.Text.Trim(), txtbacthno.Text.Trim(), txtbags.Text.Trim(), cboOptions.Text.Trim(), "Good", mfg_datePicker.Text.Trim(), "0", "rdf_pack_fg_receipt");

           
                dSet.Clear();

                dSet = objStorProc.rdf_sp_new_finish_goods(0, txtorderno.Text.Trim(), fcmain.Text.Trim(), ftmain.Text.Trim(), qbmain.Text.Trim(), bnmain.Text.Trim(), pmain.Text.Trim(), pmain.Text.Trim(), pmain.Text.Trim(), pmain.Text.Trim(), pmain.Text, "1", abmain.Text.Trim(), bagweight.Text.Trim(), "NO BARCODE", qbmain.Text.Trim(), onmain.Text.Trim(), bnmain.Text.Trim(), "0".ToString(), cmain.Text.Trim(),"Good", pmain.Text.Trim(), "0", "addbulk_receipt_repackin");
           
        }
        public void QueryStraightForwardFeedCode()
        {
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            //deploy
            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);
            string sqlquery = "select * from [dbo].[rdf_recipe] WHERE feed_code = '" + cboFeedCode.Text + "'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridView2.DataSource = dt;

            sql_con.Close();

        }



      


        private void cboFeedCode_SelectionChangeCommitted(object sender, EventArgs e)
        {

            QueryStraightForwardFeedCode();


        }

        private void dataGridView2_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataGridView2.RowCount > 0)
            {
                if (dataGridView2.CurrentRow != null)
                {
                    if (dataGridView2.CurrentRow.Cells["feed_code"].Value != null)
                    {
                        //p_id = Convert.ToInt32(dgv1stView.CurrentRow.Cells["prod"].Value);
                        txtFeedType.Text = dataGridView2.CurrentRow.Cells["rp_feed_type"].Value.ToString();

                    }

                }


            }
        }


      
        private void btnsave_Click(object sender, EventArgs e)
        {
            if (cboFeedCode.SelectedIndex == -1)
            {
                EmptyFieldNotify();
                cboFeedCode.Select();
                cboFeedCode.Focus();
                return;
            }

            if (cboOptions.SelectedIndex == -1)
            {
                EmptyFieldNotify();
                cboOptions.Select();
               cboOptions.Focus();
                return;
            }


             if(txtbags.Text == String.Empty)
            {

                EmptyFieldNotify();
                txtbags.Focus();
                return;
            }

            //if (txtbacthno.Text.Contains("."))
            //{

            //    //InvalidQuantity();
            //    //txtbags.Text = "";
            //    //txtbags.Focus();
            //    //return;
            //}
            if (txtremarks.Text == String.Empty)
            {
                EmptyFieldNotify();
                txtremarks.Focus();
                return;
            }
            if (txtFeedType.Text.Trim() == String.Empty)
            {

                EmptyFieldNotify();
                txtFeedType.Focus();
                return;
            }
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure of this " + mfg_datePicker.Text + " production date?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
               

            }
            else
            {
                mfg_datePicker.Select();
                mfg_datePicker.Focus();

                return;
            }

            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Miscellaneous Receipt this " + cboFeedCode.Text + " feedcode?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                //Do something bad
  

                if (cboOptions.Text == "BULK ENTRY")
                {
                    dSet.Clear();

                    dSet = objStorProc.rdf_sp_new_finish_goods(0, txtorderno.Text.Trim(), cboFeedCode.Text.Trim(), txtFeedType.Text.Trim(), txtbags.Text.Trim(), txtbacthno.Text.Trim(), mfg_datePicker.Text.Trim(), mfg_datePicker.Text.Trim(), mfg_datePicker.Text.Trim(), mfg_datePicker.Text.Trim(), mfg_datePicker.Text, "1", txtaddedby.Text.Trim(), txttimes50.Text.Trim(), "NO BARCODE", txtbags.Text.Trim(), txtorderno.Text.Trim(), txtbacthno.Text.Trim(), txtbags.Text.Trim(), cboOptions.Text.Trim(), "Good", mfg_datePicker.Text.Trim(), txtremarks.Text, "addbulk_receipt_hollow");
                    //txtremarks.Enabled = false;
                    txtbags.Enabled = false;

                    btnsave.Visible = false;
                    btnInsert.Visible = true;
                    SuccessFullyInsert();
                    txtbags.Text = "";
                    Clear();
                    frmFGReceipt_Load(sender, e);
                }
                else
                {

                    dSet.Clear();

                    dSet = objStorProc.rdf_sp_new_finish_goods(0, txtorderno.Text.Trim(), cboFeedCode.Text.Trim(), txtFeedType.Text.Trim(), txtbags.Text.Trim(), txtbacthno.Text.Trim(), mfg_datePicker.Text.Trim(), mfg_datePicker.Text.Trim(), mfg_datePicker.Text.Trim(), mfg_datePicker.Text.Trim(), mfg_datePicker.Text, "1", txtaddedby.Text.Trim(), txttimes50.Text.Trim(), "NO BARCODE", txtbags.Text.Trim(), txtorderno.Text.Trim(), txtbacthno.Text.Trim(), txtbags.Text.Trim(), cboOptions.Text.Trim(), "Good", mfg_datePicker.Text.Trim(), txtremarks.Text, "addbulk_receipt_hollow");

                    btnsave.Visible = false;
                    btnInsert.Visible = true;
                    SuccessFullyInsert();
                    txtbags.Text = "";
                    Clear();
                    frmFGReceipt_Load(sender, e);
                }


            }
            else
            {
                return;
            }


            }


        void EmptyFieldNotify()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Fill up the required Fields !";
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

        void InvalidQuantity ()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Invalid Quantity !";
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


        private void cboFeedCode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtbags_TextChanged(object sender, EventArgs e)
        {
            //if (txtbags.Text.Trim() == string.Empty)
            //{
            //    txttimes50.Text = "";
            //    txtbacthno.Text = "";


            //if (cboOptions.Text=="BULK ENTRY")
            //{ 



            //    txttimes50.Text = (float.Parse(txtbags.Text) * 50).ToString();
            //    txtbacthno.Text = (float.Parse(txtbags.Text) / 40).ToString();
            //}
            //}

            //else
            //{
            //    txttimes50.Text = "50".ToString();
            //    txtbacthno.Text = (float.Parse(txtbags.Text) / 40).ToString();

            //}


            if (txtbags.Text.Trim() == string.Empty)
            {
                txttimes50.Text = "";
                txtbacthno.Text = "";
            }

            else
            {

                txttimes50.Text = (float.Parse(txtbags.Text) * 50).ToString();
                txtbacthno.Text = (float.Parse(txtbags.Text) / 40).ToString();



            }


            
        }

        private void dgvFG_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void dgvFG_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgvFG.RowCount > 0)
            {
                if (dgvFG.CurrentRow != null)
                {
                    if (dgvFG.CurrentRow.Cells["prod_adv"].Value != null)
                    {
       


                        fcmain.Text = dgvFG.CurrentRow.Cells["fg_feed_code"].Value.ToString().ToUpper();
                        ftmain.Text = dgvFG.CurrentRow.Cells["fg_feed_type"].Value.ToString().ToUpper();
                        cmain.Text = dgvFG.CurrentRow.Cells["fg_options"].Value.ToString().ToUpper();
                        rmain.Text = dgvFG.CurrentRow.Cells["Remarks"].Value.ToString();
                        pmain.Text = dgvFG.CurrentRow.Cells["fg_proddate"].Value.ToString().ToUpper();
                        onmain.Text = dgvFG.CurrentRow.Cells["prod_adv"].Value.ToString().ToUpper();
                        qbmain.Text = dgvFG.CurrentRow.Cells["fg_bags"].Value.ToString().ToUpper();
                        bnmain.Text = dgvFG.CurrentRow.Cells["fg_batch"].Value.ToString().ToUpper();
                        qkmain.Text = dgvFG.CurrentRow.Cells["actual_weight"].Value.ToString().ToUpper();
                        abmain.Text = txtaddedby.Text;
                        idmain.Text = dgvFG.CurrentRow.Cells["fg_id"].Value.ToString().ToUpper();
                    }

                }
            }



        }

        private void txttimes50_TextChanged(object sender, EventArgs e)
        {

        }


        void Clear()

        {
           // cboFeedCode.Enabled = true;
          //  btnInsert.Visible = false;
          //  btnsave.Visible = true;
            cboOptions.Text = "";
            cboFeedCode.Text = "";
            txtFeedType.Text = "";
            txtbags.Text = "";
            cboOptions.Text = "";
            //txtorderno.Text = "";
           // txtaddedby.Text = "";

         //   txtremarks.Enabled = true;
         //  txtbags.Enabled = true;

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            cboFeedCode.Enabled = true;
            btnInsert.Visible = false;
            btnsave.Visible = true;
            cboOptions.Enabled = true;
            cboFeedCode.Text = "";
            txtFeedType.Text = "";
            txtbags.Text = "";
            cboOptions.Text = "";
            txtremarks.Enabled = true;
            txtbags.Enabled = true;

         
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnInsert.Visible = true;
            btnsave.Visible = false;
            cboFeedCode.Enabled = false;
        }

        public void SuccessFullyInsert()
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);

            popup.ContentText = "Successfully insert a new Finished Goods Receipt "+cboOptions.Text+"";

            popup.ContentColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);

            popup.ContentHoverColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentPadding = new Padding(0);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Green;
            popup.Popup();

            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);

            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;

            txtremarks.Text = "";
        }


        public void SuccessFullyCancel()
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);

            popup.ContentText = "Successfully cancelled a  Finished Goods Receipt " + cmain.Text + "";

            popup.ContentColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);

            popup.ContentHoverColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentPadding = new Padding(0);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Green;
            popup.Popup();

            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);

            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;

   
        }



        public void SuccessFullyTransactAllitems()
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);

            popup.ContentText = "Successfully Transactions of  Finished Goods Receipt " + cboOptions.Text + "";

            popup.ContentColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);

            popup.ContentHoverColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentPadding = new Padding(0);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Green;
            popup.Popup();

            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);

            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }
        private void lblrecords_Click(object sender, EventArgs e)
        {
            if(lblrecords.Text =="0")
            {
                btnTransact.Visible = false;
            }
            else
            {
                btnTransact.Visible = true;
            }
        }

        public void load_transactions_count()
        {
            string mcolumns = "test,order_no";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgvCountISSUE, mcolumns, "transaction_receipt_count");
            txtorderno.Text = dgvCountISSUE.RowCount.ToString();
            txtorderstable.Text = dgvCountISSUE.RowCount.ToString();
            txtordervalidation.Text = dgvCountISSUE.RowCount.ToString();

        }
        public void load_transactions_countvalidation()
        {
            string mcolumns = "test,order_no";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgvCountISSUE, mcolumns, "transaction_receipt_count");
            //txtorder.Text = dgvTransactions.RowCount.ToString();
            //txtorderstable.Text = dgvTransactions.RowCount.ToString();
            txtordervalidation.Text = dgvCountISSUE.RowCount.ToString();


        }

        public void load_transaction_countplus1()

        {




            //  txtorder.Text = dgvTransactions.RowCount.ToString();

            int sum = Convert.ToInt32(txtorderno.Text) + 1;

            txtorderno.Text = sum.ToString();

        }

        public void load_transaction_countplus1valid()

        {
            int sum = Convert.ToInt32(txtordervalidation.Text);
            

           int total = sum + 1;

            txtorderno.Text = total.ToString();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(lblrecords.Text=="0")

            {
                button1.Visible = false;
                load_transactions_count();

            }

            else

            {
                button1.Visible = true;


            }

            
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Cancel this feedcode " + fcmain.Text + " ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                dSet.Clear();

                dSet = objStorProc.rdf_sp_new_finish_goods(0, idmain.Text.Trim(), fcmain.Text.Trim(), ftmain.Text.Trim(), qbmain.Text.Trim(), bnmain.Text.Trim(), pmain.Text.Trim(), pmain.Text.Trim(), pmain.Text.Trim(), pmain.Text.Trim(), pmain.Text, "1", abmain.Text.Trim(), qkmain.Text.Trim(), "NO BARCODE", qbmain.Text.Trim(), onmain.Text.Trim(), bnmain.Text.Trim(), qbmain.Text.Trim(), cmain.Text.Trim(), "Good", pmain.Text.Trim(), "0", "addbulk_receipt_hollow_cancel_one");
                SuccessFullyCancel();
                load_Schedules();
                Clear();

                if (lblrecords.Text=="0")
                {

                    frmFGReceipt_Load(sender, e);
                    btnCancel_Click(sender, e);
                    Clear();
                }
                else
                {
                    return;
                }

            }
            else
            {
                return;
            }

        }

        public void FormClosingClearCache()
        {

            dSet.Clear();

            dSet = objStorProc.rdf_sp_new_finish_goods(0, onmain.Text.Trim(), fcmain.Text.Trim(), ftmain.Text.Trim(), qbmain.Text.Trim(), bnmain.Text.Trim(), pmain.Text.Trim(), pmain.Text.Trim(), pmain.Text.Trim(), pmain.Text.Trim(), pmain.Text, "1", abmain.Text.Trim(), qkmain.Text.Trim(), "NO BARCODE", qbmain.Text.Trim(), onmain.Text.Trim(), bnmain.Text.Trim(), qbmain.Text.Trim(), cmain.Text.Trim(), "Good", pmain.Text.Trim(), "0", "addbulk_receipt_hollow_clear");

        }

        private void btnTransact_Click(object sender, EventArgs e)
        {
            this.dgvFG.CurrentCell = this.dgvFG.Rows[0].Cells[this.dgvFG.CurrentCell.ColumnIndex];

            dgvFG_CurrentCellChanged( sender, e);


            //if (txtremarks.Text=="")

            //{

            //    EmptyFieldNotify();
            //    txtremarks.Focus();
            //    return;
            //}


            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to save all the Transaction " + txtaddedby.Text + " ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {


                this.dgvFG.Columns["Remarks"].Visible = true;
                this.dgvFG.Columns["prod_adv"].Visible = true;


                load_transactions_countvalidation();

                if (txtordervalidation.Text == txtorderstable.Text)
                {
                    load_transaction_countplus1();
                
                }
                else
                {
                    load_transaction_countplus1valid();
                   
                }


                btnNext_Click(sender, e);

                btnlessthan_Click(sender, e);

             
                dSet.Clear();
                dSet = objStorProc.rdf_sp_new_finish_goods(0, txtorderno.Text, onmain.Text, ftmain.Text.Trim(), qbmain.Text.Trim(), bnmain.Text.Trim(), pmain.Text.Trim(), pmain.Text.Trim(), pmain.Text.Trim(), pmain.Text.Trim(), pmain.Text, "1", txtaddedby.Text, qkmain.Text.Trim(), "NO BARCODE", qbmain.Text.Trim(), onmain.Text.Trim(), bnmain.Text.Trim(), qbmain.Text.Trim(), cmain.Text.Trim(), "Good", pmain.Text.Trim(), "0", "addbulk_receipt_hollow_all");


                SuccessFullyTransactAllitems();
                frmFGReceipt_Load(sender, e);
                Clear();
            }
            else
            {
                btnInsert_Click(sender, e);
                return;
            }

        }

        private void frmFGReceipt_FormClosing(object sender, FormClosingEventArgs e)
        {
           if(lblrecords.Text=="0")
            {

            }
            else
            { 
            
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to close this form? The transaction will be reset.", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                FormClosingClearCache();
            }


            else
            {
                e.Cancel = true;
                return;
            }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            btnlessthan_Click(sender, e);
        }

        private void btnlessthan_Click(object sender, EventArgs e)
        {




     
            //start   query 1

           // QueryOutFGRepackin();



            //MessageBox.Show("fff");


            if (dgvFG.Rows.Count >= 1)
            {


                int i = dgvFG.CurrentRow.Index + 1;
                if (i >= -1 && i < dgvFG.Rows.Count)

                {
                    dgvFG.CurrentCell = dgvFG.Rows[i].Cells[1];
                
                if (cmain.Text == "Bagging")
                {
                    btnNext_Click(sender, e);
                }
                else
                {
                      //  MessageBox.Show("BULK");
                       QueryOutFGRepackinbulk();
                        Feedcodetransactionbulk();

                    }
                }




                else
                {
                    //LastLine();
                    //MessageBox.Show("Last muna nyan  haha");

                    //frmFGReceipt_Load(sender, e);


                    return;
                }



                button2_Click(sender, e);


            }




        }

        private void txtbags_KeyPress(object sender, KeyPressEventArgs e)
        {


            if (!char.IsControl(e.KeyChar)
    && !char.IsDigit(e.KeyChar)
    && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }

        }

        private void btnNext_Click(object sender, EventArgs e)
        {


            //start   query 1

            //QueryOutFGRepackin();

            if(cmain.Text=="Bagging")

            { 
            for (int i = 0; i < Convert.ToInt32(qbmain.Text); i++)
            {

                 //  MessageBox.Show("Bag yan boy"+i);
                   QueryOutFGRepackin();
                   Feedcodetransactionbag();
            }
            }

            else if(cmain.Text == "BULK ENTRY")

            {

               // MessageBox.Show("Bulk baby");
               QueryOutFGRepackinbulk();
                Feedcodetransactionbulk();
            }

            else
            {

               
                //return;
            }






        }

        private void btnLoop_Click(object sender, EventArgs e)
        {
            btnNext_Click(sender, e);
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }
    }

}
