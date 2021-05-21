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
    public partial class frmFGReceivings : Form
    {

        //myclasses myClass = new myclasses();
        //IStoredProcedures g_objStoredProcCollection = null;
        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();
        //DataSet dSet_temp = new DataSet();
        //DataSet dset_rights = new DataSet();
        DataSet dSet = new DataSet();
        //Boolean ready = false;
        myclasses xClass = new myclasses();
        IStoredProcedures objStorProc = null;
        int rights_id = 0;

        public frmFGReceivings()
        {
            InitializeComponent();
        }

        private void frmFGReceivings_Load(object sender, EventArgs e)
        {
            // Calling the Stored PROC 
            objStorProc = xClass.g_objStoredProc.GetCollections();
            rights_id = userinfo.user_rights_id;
            myglobal.global_module = "Active";
            load_fg_inventory();
            //  GrandTotal();
            Loadform();
            colorlegend();
            txtProductionDate.MaxDate = DateTime.Now;
            dtpTo.MaxDate = DateTime.Now;
            textBox1.Text="pls";
            lbladdedby.Text = userinfo.emp_name.ToUpper();



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


        void colorlegend()
        {
            alarm.BackColor =  Color.FromArgb(255, 255, 0, 0);
            crtitical.BackColor =  Color.FromArgb(255, 255, 59, 59);
            alert2.BackColor =  Color.FromArgb(255, 255, 98, 98);
            alert1.BackColor = Color.FromArgb(255, 255, 118, 118);
            warning.BackColor = Color.FromArgb(255, 255, 172, 20);
            good.BackColor = Color.FromArgb(255, 10, 255, 10);






        }
        void Loadform()

        {
            txtProductionDate.Enabled = true;
            UseWaitCursor = false;
            //textBox1.Text = "";
            dtpTo.Enabled = true;
            btnReceived.Visible = true;
            dgv_table.Enabled = true;
            txtFeedCode.Enabled = true;
            txtFeedCode.Text = "";


        }

        //stored proc of datagridview data
        public void load_fg_inventory()
        {
            string mcolumns = "test,ProdID,ProdDate,PrintingDate,FeedCode,FeedType,BagsCount,BulkCount,GrandTotal,AGING,STATUS,PENDING";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgv_table, mcolumns, "fg_receiving2");
            lblrecords.Text = dgv_table.RowCount.ToString();
            //textBox1.Text = "wow";

            //this.dgv_table.Columns["ACTUAL"].Visible = false;

            //micro_materials_header();
        }



        //formula of Grandtotal column
      


        //Graphics only of datagridview
        private void dgv_table_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        public void openfgreceived()
        {
            dSet.Clear();

            dSet = objStorProc.sp_rdf_fg_feedcodetransaction(0,lblprodid.Text,lblfeedcode.Text,lblcategory.Text,"","", txtPrintingDate.Text,"","","","", "", "openfgreceived");


        }

        public void blockfgreceived()
        {

            dset_emp1.Clear();
            dset_emp1 = objStorProc.sp_getMajorTables("searchblockreceived");


            string mcolumns = "test,FeedCode,FeedType,ProdID,PrintingDate,fgstatus";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgvblocking, mcolumns, "searchblockreceived");
           

        }


        private void btnReceived_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            //btnReceived.BackColor = Color.Teal;
            //btnReceived.ForeColor = Color.White;

            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure want to receive this '" + lblfeedcode.Text + "' Finished Goods? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                //UseWaitCursor = true;

                blockfgreceived();

                if(blockprodid.Text == lblprodid.Text && blockstatus.Text== "3" && blockfgdate.Text == txtPrintingDate.Text)

                {
                    AlreadyOpen();
                    dgv_table.Enabled = true;
                    btnReceived.Enabled = true;
                    btnReceived.Visible = true;
                    txtFeedCode.Enabled = true;
                    dtpTo.Enabled = true;
                    txtProductionDate.Enabled = true;
                    textBox1.Text = "refreshlangawa";
                    load_fg_inventory();
                    

                    return;

                }
                else
                {


                }



                openfgreceived();
                dgv_table.Enabled = false;
                txtProductionDate.Enabled = false;
                txtFeedCode.Enabled = false;
                dtpTo.Enabled = false;
                btnReceived.Visible = false;
                //btnReceived.BackColor = Color.White;
                //btnReceived.ForeColor = Color.Black;



                frmFGView fgview = new frmFGView(this, lblprodid.Text, txtPrintingDate.Text, txtProdPlan.Text);

                fgview.Show();
                

            }
            else
            {
                //btnReceived.BackColor = Color.White;
                //btnReceived.ForeColor = Color.Black;
                return;
            }

        }

        private void dgv_table_CurrentCellChanged(object sender, EventArgs e)
        {

            if (dgv_table.CurrentRow != null)
            {
                if (dgv_table.CurrentRow.Cells["ProdID"].Value != null)
                {
                    lblprodid.Text = dgv_table.CurrentRow.Cells["ProdID"].Value.ToString();
                    txtPrintingDate.Text = dgv_table.CurrentRow.Cells["PrintingDate"].Value.ToString();
                    txtProdPlan.Text = dgv_table.CurrentRow.Cells["ProdDate"].Value.ToString();
                    lblfeedcode.Text = dgv_table.CurrentRow.Cells["FeedCode"].Value.ToString();
                    lblcategory.Text = dgv_table.CurrentRow.Cells["FeedType"].Value.ToString();
                    lblprod.Text = dgv_table.CurrentRow.Cells["ProdID"].Value.ToString();
                }
            }
            



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
            if(textBox1.Text==String.Empty)
            {
                return;
              
            }

            else
            {
                //dtpTo.Text = String.Empty;
                //txtProductionDate.Text = String.Empty;
                //txtFeedCode.Text ="";
                dgv_table.Enabled = true;
                btnReceived.Enabled = true;
                btnReceived.Visible = true;
                txtFeedCode.Enabled = true;
                dtpTo.Enabled = true;
                txtProductionDate.Enabled = true;
                load_fg_inventory();
            }
           
            //    frmFGReceivings_Load(sender, e);

        }

        private void txtFeedCode_TextChanged(object sender, EventArgs e)
        {
            if (txtProdID.Text.Trim() == string.Empty)
            {

            }
            else
            {
                load_search();
                //doSearch();

            }
        }


        void load_search()
        {
            dset_emp1.Clear();
            dset_emp1 = objStorProc.sp_getMajorTables("fg_receiving2");
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



                        dv.RowFilter = "PrintingDate >= #" + txtProductionDate.Text + "# AND PrintingDate <= #" + dtpTo.Text + "# AND FeedCode like '%" + txtFeedCode.Text + "%'";
                        textBox1.Text = "yeye";
                        //dv.RowFilter = "fg_proddate = '" + dateTimePitextBox1.Text = "yeye";cker12.Text + "' AND prod_adv like '%" + txtprod_id.Text + "%'";

                    }
                    else if (myglobal.global_module == "VISITORS")
                    {
                        //dv.RowFilter = "visitors_lastname like '%" + txtsearch.Text + "%' or visitors_firstname like '%" + txtsearch.Text + "%'";
                    }
                    dgv_table.DataSource = dv;
                    lblrecords.Text = dgv_table.RowCount.ToString();

                   


                    //textBox1.Text = "";

                    //gerard
                }
                //    GrandTotal();

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

        private void txtProductionDate_TextChanged(object sender, EventArgs e)
        {
            load_search();
            //doSearch();
        }

        private void txtProductionDate_ValueChanged(object sender, EventArgs e)
        {
            load_search();
            // doSearch();


        }

        private void txtFeedCode_TextChanged_1(object sender, EventArgs e)
        {
            load_search();
           
            //textBox1.Text = "oyyy";
            // doSearch();

        }

        private void lblfeedcode_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmFGReceivings_FormClosing(object sender, FormClosingEventArgs e)
        {
            load_fg_inventory();
            //frmFGReceivings_Load(sender, e);
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            load_search();
        }

        private void Formatting()
        {
            foreach (DataGridViewRow row in dgv_table.Rows)
            {

               
                

                   



                

                if (Convert.ToDouble(row.Cells["AGING"].Value) <= 30)
                {
                    row.Cells["STATUS"].Style.BackColor = Color.FromArgb(255, 255, 59, 59);
                    row.Cells["STATUS"].Style.ForeColor = Color.Black;
                    row.Cells["STATUS"].Value = "CRITICAL";
                    if (Convert.ToDouble(row.Cells["PENDING"].Value) > 0)
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 0, 0);
                        row.Cells["STATUS"].Style.BackColor = Color.FromArgb(255, 255, 0, 0);
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 241, 241, 242);
                    }
                    if (Convert.ToDouble(row.Cells["AGING"].Value) <= 21)
                    {
                        row.Cells["STATUS"].Style.BackColor = Color.FromArgb(255, 255, 98, 98);
                        row.Cells["STATUS"].Style.ForeColor = Color.Black;
                        row.Cells["STATUS"].Value = "ALERT LEVEL 2";
                        if (Convert.ToDouble(row.Cells["PENDING"].Value) > 0)
                        {
                            row.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 0, 0);
                            row.Cells["STATUS"].Style.BackColor = Color.FromArgb(255, 255, 0, 0);
                        }
                        else
                        {
                            row.DefaultCellStyle.BackColor = Color.FromArgb(255, 241, 241, 242);
                        }
                        if (Convert.ToDouble(row.Cells["AGING"].Value) <= 14)
                        {
                            row.Cells["STATUS"].Style.BackColor = Color.FromArgb(255, 255, 118, 118);
                            row.Cells["STATUS"].Style.ForeColor = Color.Black;
                            row.Cells["STATUS"].Value = "ALERT LEVEL 1";
                            if (Convert.ToDouble(row.Cells["PENDING"].Value) > 0)
                            {
                                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 0, 0);
                                row.Cells["STATUS"].Style.BackColor = Color.FromArgb(255, 255, 0, 0);
                            }
                            else
                            {
                                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 241, 241, 242);
                            }
                            if (Convert.ToDouble(row.Cells["AGING"].Value) <= 7)
                            {

                                row.Cells["STATUS"].Style.BackColor = Color.FromArgb(255, 255, 172, 20);
                                row.Cells["STATUS"].Style.ForeColor = Color.Black;
                                row.Cells["STATUS"].Value = "WARNING";
                                if (Convert.ToDouble(row.Cells["PENDING"].Value) > 0)
                                {
                                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 0, 0);
                                    row.Cells["STATUS"].Style.BackColor = Color.FromArgb(255, 255, 0, 0);
                                }
                                else
                                {
                                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 241, 241, 242);
                                }
                                if (Convert.ToDouble(row.Cells["AGING"].Value) <= 4)
                                {

                                    row.Cells["STATUS"].Style.BackColor = Color.FromArgb(255, 10, 255, 10);
                                    row.Cells["STATUS"].Style.ForeColor = Color.Black;
                                    row.Cells["STATUS"].Value = "GOOD";
                                    if (Convert.ToDouble(row.Cells["PENDING"].Value) > 0)
                                    {
                                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 0, 0);
                                        row.Cells["STATUS"].Style.BackColor = Color.FromArgb(255, 255, 0, 0);
                                    }
                                    else
                                    {
                                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 241, 241, 242);
                                    }
                                }
                            }
                        }
                    }

                }

                


                //if (Convert.ToDouble(row.Cells["PENDING"].Value) > 0 && (Convert.ToDouble(row.Cells["AGING"].Value) <= 4))
                //{
                //    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 0, 0);
                //}


                else
                {
                    row.Cells["STATUS"].Style.BackColor = Color.FromArgb(255, 255, 0, 0);
                    row.Cells["STATUS"].Style.ForeColor = Color.Black;
                    row.Cells["STATUS"].Value = "ALARM";
                  
                    if (Convert.ToDouble(row.Cells["PENDING"].Value) >= 1)
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 0, 0);
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 241, 241, 242);
                    }
                  




                }

            }

                

                
            
            
        }

        private void dgv_table_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (textBox1.Text == String.Empty)
            {

                return;

            }


            else
             {
                Formatting();
             }
      



           

        }



        private void dgv_table_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = String.Empty;
            if (dgv_table.CurrentRow != null)
            {
                if (dgv_table.CurrentRow.Cells["ProdID"].Value != null)
                {
                    lblprodid.Text = dgv_table.CurrentRow.Cells["ProdID"].Value.ToString();
                    txtPrintingDate.Text = dgv_table.CurrentRow.Cells["PrintingDate"].Value.ToString();
                    txtProdPlan.Text = dgv_table.CurrentRow.Cells["ProdDate"].Value.ToString();
                    lblfeedcode.Text = dgv_table.CurrentRow.Cells["FeedCode"].Value.ToString();
                    lblcategory.Text = dgv_table.CurrentRow.Cells["FeedType"].Value.ToString();
                    lblprod.Text = dgv_table.CurrentRow.Cells["ProdID"].Value.ToString();
                }
            }
        }

        private void dgv_table_Scroll(object sender, ScrollEventArgs e)
        {
            textBox1.Text = String.Empty;
        }

        private void txtFeedCode_Click(object sender, EventArgs e)
        {
            txtFeedCode.Text = String.Empty;
        }

        private void frmFGReceivings_Click(object sender, EventArgs e)
        {
            textBox1.Text = String.Empty;
        }

        private void dgv_table_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
           
        }

        private void dgv_table_ColumnSortModeChanged(object sender, DataGridViewColumnEventArgs e)
        {
           
           
        }

        private void txtProductionDate_Validated(object sender, EventArgs e)
        {
            textBox1.Text = String.Empty;
        }

        private void dtpTo_Validated(object sender, EventArgs e)
        {
            textBox1.Text = String.Empty;
        }

        private void txtFeedCode_Validated(object sender, EventArgs e)
        {
            textBox1.Text = String.Empty; 
        }

        private void txtProductionDate_Validating(object sender, CancelEventArgs e)
        {
            textBox1.Text = String.Empty; 
        }

        private void dtpTo_Validating(object sender, CancelEventArgs e)
        {
            textBox1.Text = String.Empty; 
        }

        private void txtFeedCode_Validating(object sender, CancelEventArgs e)
        { 
            textBox1.Text = String.Empty; 
        }

        private void dgvblocking_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgvblocking.CurrentRow != null)
            {

                blockprodid.Text = dgvblocking.CurrentRow.Cells["ProdID"].Value.ToString();
                blockstatus.Text = dgvblocking.CurrentRow.Cells["fgstatus"].Value.ToString();
                blockfgdate.Text = dgvblocking.CurrentRow.Cells["PrintingDate"].Value.ToString();
            }

        }
        void AlreadyOpen()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "The Production ID you chose is already opened by other user, Kindly choose another Production ID Thankyou!";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Orange;
            popup.Popup();
            //popup.AnimationDuration = 1000;
            //popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);

            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }
    }
}



