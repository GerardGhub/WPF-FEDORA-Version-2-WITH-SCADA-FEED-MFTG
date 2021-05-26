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
using Tulpep.NotificationWindow;

namespace WFFDR
{

    public partial class frmmicrowhpreparation : Form
    {

        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        DataSet ds = new DataSet();


        myclasses xClass = new myclasses();
        IStoredProcedures objStorProc = null;
        Boolean ready = false;
        DataSet dSet = new DataSet();

        DataSet dSets = new DataSet();
        DataSet dSet_temp = new DataSet();
        string mode = "";
        int p_id = 0;
        int temp_hid = 0;
        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();

        //declare as global

        int nRow;


        public frmmicrowhpreparation()
        {
            InitializeComponent();
        }

        private void frmmicrowhpreparation_Load(object sender, EventArgs e)
        {
          
            lbltotalread.Text = "0";

            txtaddedby.Text = userinfo.emp_name.ToUpper();








            HideMultiple();




            BtnSave.Visible = false;
            txtqtyactive.Text = "";
            //string s = (Convert.ToDouble(txt2.Text) / 100).ToString("0.00");

            //this.WindowState = FormWindowState.Maximized;

            load_Schedules();

            //nRow = dgv1stView.CurrentCell.RowIndex;4/18/2020



            // Calling the Stored PROC 
            objStorProc = xClass.g_objStoredProc.GetCollections();
            //this.WindowState = FormWindowState.Maximized;
            Callothers();
      

            calldisable();


            txtmainfeedcode_TextChanged(sender, e);

            if (label10.Text == "0")
            {
    
                NoDataFound2();
                btnlessthan.Visible = false;
                btngreaterthan.Visible = false;
                return;
            }

            if (txtitemcode1.Text.Trim() == string.Empty)
            {
                txt1.Enabled = false;
                NoDataFound2();






                label10.Visible = false;
                label12.Visible = false;
                    label1.Visible = false;

                    lblCountss.Visible = false;
                    label14.Visible = false;
                    label2.Visible = false;
      
                return;

            }
            else
            {
                nRow = dgv1stView.CurrentCell.RowIndex;
                txtitemcodeactive.Text = dgv1stView.CurrentRow.Cells["item_code"].Value.ToString();
                txtdescriptionactive.Text = dgv1stView.CurrentRow.Cells["rp_description"].Value.ToString();
                txtbatchactive.Text = dgv1stView.CurrentRow.Cells["p_nobatch"].Value.ToString();
                txtqtyactive.Text = dgv1stView.CurrentRow.Cells["quantity"].Value.ToString();
                txtsubstractrepack.Text = (float.Parse(txtactiveqtyrepack.Text) - 1).ToString();
            }

            //txtmainfeedcode_TextChanged(sender, e);
            StressHideTextBox();
            lblscannumber.Text = "0";
            btnShow_Click(sender, e);

            myglobal.global_module = "Active";
            load_search();
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


        DataSet dset_emp = new DataSet();
        void load_search()
        {

            dset_emp.Clear();



            dset_emp = objStorProc.sp_getMajorTables("SearchMicroPrepa");

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
                        //dv.RowFilter = "firstname like '%" + txtmainsearch.Text + "%' or lastname like '%" + txtsearch.Text + "%' or employee_number like '%" + txtsearch.Text + "%' or employment_status_name like '%" + txtsearch.Text + "%'";
                    }
                    else if (myglobal.global_module == "Active")
                    {

                        dv.RowFilter = "string_id like '%" + txtBarcode.Text + "%'";

                    }
                    else if (myglobal.global_module == "VISITORS")
                    {
                        //dv.RowFilter = "visitors_lastname like '%" + txtsearch.Text + "%' or visitors_firstname like '%" + txtsearch.Text + "%'";
                    }
                    dgvrepackdb.DataSource = dv;
                    //lblrecords.Text = dgvrepackdb.RowCount.ToString();

                    //txtMainInput.Text = "";
                    //txtMainInput.Select();
                    //txtMainInput.Focus();
                    //if (lblrecords.Text == "0")
                    //{
                    //    //MessageBox.Show("FG Barcode Not Found!");
                    //    NotExists();
                    //    panel1.Visible = false;
                    //    txtMainInput.Text = "";
                    //    txtMainInput.Select();
                    //    txtMainInput.Focus();

                    //}
                    //else
                    //{
                    //    panel1.Visible = true;
                    //    ValidatedSuccess();
                    //}
                }

            }

            catch (SyntaxErrorException)
            {
                MessageBox.Show("Invalid character found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //txtmainfeedcode.Focus();
                return;
            }
            catch (EvaluateException)
            {
                //MessageBox.Show("Invalid character found 2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //txtmainfeedcode.Focus();
                return;
            }


        }

        void NoDataFound2()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.ContentText = "No Data Found !, " + txtaddedby.Text + " !";
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Red;
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

            groupBox1.Visible = false;
            dgvMaster.Visible = false;
            lblCountss.Text = "0";
            label2.Text = "0";
            bunifuStopPreparation.Visible = false;
            label12.Visible = false;
            label10.Visible = false;
            label1.Visible = false;
                lblCountss.Visible = false;
                label14.Visible = false;
                label2.Visible = false;

        }


        void HideMultiple()
        {
            row2();
            row3();
            row4();
            row5();
            row6();
            row7();
            row8();
            row9();
            row10();
            row11();
            row12();
            row13();
            row14();
            row15();
            row16();
            row17();
            row18();
            row19();
            row20();
            row21();
            row22();
            row23();
            row24();
            row25();

        }

        void SuccessFullyValidated()
        {
            //remove 6/7/2020
            //double subjectquantity;
            //double sagot;


            //subjectquantity = double.Parse(lblscannumber.Text);
            //sagot = subjectquantity * 1;
            ////lblscannumber.Text = Convert.ToString(sagot);

            //PopupNotifier popup = new PopupNotifier();
            //popup.Image = Properties.Resources.info;
            //popup.TitleColor = Color.White;
            //popup.TitlePadding = new Padding(95, 7, 0, 0);
            //popup.TitleFont = new Font("Tahoma", 10);
            //popup.ContentText = "ENTRY NO. " + sagot + " SUCCESSFULLY VALIDATED " + txtMyItemDescription.Text + " OUT OF " + lblCounts.Text + "";
            //popup.ContentColor = Color.White;
            //popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            //popup.Size = new Size(920, 270);
            //popup.ImageSize = new Size(175, 180);
            //popup.BodyColor = Color.Green;
            //popup.Popup();
            ////popup.AnimationDuration = 1000;
            ////popup.ShowOptionsButton.ToString();
            //popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            ////txtMainInput.Focus();
            ////txtMainInput.Select();
            //popup.Delay = 20;
            //popup.AnimationInterval = 2;
            //popup.AnimationDuration = 100;


            //popup.ShowOptionsButton = true;

            //*Total Sum of  Qty: "+lblCountss.Text+" And QTY Batch: "+label2.Text+" */
            bunifuStopPreparation.Visible = true;
            bunifuStart.Visible = false;
            btngreaterthan.Enabled = false;
            btnlessthan.Enabled = false;
            if (lblCounts.Text == lblscannumber.Text)
            {
                ReadyforPreparation();
                BtnSave.Visible = true;
            }


        }



        void SuccessFullyValidatedFinal()
        {
            double subjectquantity;
            double sagot;

            subjectquantity = double.Parse(lbltotalread.Text);
            sagot = subjectquantity - 1;

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.Black;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Entry No. " + sagot + " Successfully Validated " + txtdescription1.Text + " out of " + lblCounts.Text + "";
            popup.ContentColor = Color.Black;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.LightBlue;
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

            //*Total Sum of  Qty: "+lblCountss.Text+" And QTY Batch: "+label2.Text+" */




        }


        void ReadyforPreparation()
        {
            double subjectquantity;
            double sagot;

            subjectquantity = double.Parse(lbltotalread.Text);
            sagot = subjectquantity * 1;

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = " QTY NEEDED FOR PREPARATION, ALREADY MATCH READY TO SAVE!,  ENTRY NO. " + lblscannumber.Text + " OUT OF " + lblCounts.Text + "";
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

            //*Total Sum of  Qty: "+lblCountss.Text+" And QTY Batch: "+label2.Text+" */

            txttotalQty.Text = (float.Parse(txtQuantity.Text) * float.Parse(txtnobatch.Text)).ToString();


        }

        void PreparationAlreadySave()
        {
            double subjectquantity;
            double sagot;

            subjectquantity = double.Parse(lbltotalread.Text);
            sagot = subjectquantity + 1;

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "PREPARATION FOR "+txtmainfeedcode.Text+" SUCCESSFULLY SAVE !";
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

            //*Total Sum of  Qty: "+lblCountss.Text+" And QTY Batch: "+label2.Text+" */

            if (label10.Text =="0")
            {
                txtitemcodeactive.Text = "";
                    txtitemcodeactive.Text = "";
                    txtsumtotalactive.Text = "";
                    txttotalrepack1.Text = "";
                //splitContainer1.Visible = false;
                NoDataFound2();
                btnlessthan.Visible = false;
                btngreaterthan.Visible = false;
            }



        }



        void RepackIdNotExists()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "RAW MATERIAL REPACK ID IS NOT EXISTS";
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


        void FeedCodeNotMatch()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "FEED CODE NOT MATCH";
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

        void RepackIDExists()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "WARNING CANNOT BE USED THE MATERIAL REPACK, BECAUSE ITS ALREADY IN THE PRODUCTION !";
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

        void PreparedAlready()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "ITEM ALREADY PREPARED !";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80); ;
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



        void ActualNeedandActualCOuntisnotEqual()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Actual Need to Repack at this Feed Code is " + lbltotalcounts.Text + " You are already repack a number of " + lblCounts.Text + " cannot Proceed to Preparations";
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



        void LimitExceeded()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Preparation Entry Already Exceeded at Checking Raw Materials Ready to Save";
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

        void RepackRawMatsFirst()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "THIS PRODUCTION ENTRY IS NOT ALREADY DONE FOR REPACKING";
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



        void BarcodeNotFound()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "BARCODE INPUT NOT FOUND !";
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



        void ItemCodeNotMatched()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "ITEM CODE NOT MATCHED !";
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




        void ItemCodeValueNotmacthed()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "ITEM QUANTITY IS NOT MATCH IN OUR NEEDED!, CHOOSE THE EXACTLY ITEM";
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






        void Dochecking()
        {
            //if (lbltotalread.Text == "17")
            //{

            //    if (lblCounts.Text.Trim() == lbltotalread.Text.Trim())
            //    {
            //        //MessageBox.Show("Qty Needed Match Ready TO Save <3");
            //        ReadyforPreparation();
            //        BtnSave.Visible = true;
            //        //row18();
            //        //row19();
            //        return;
            //    }
            //    else
            //    {

            





            //        col18();
            //        txt18.Focus();
            //        txt18.Select();
            //    }
            //    //BtnSave.Visible = true;

            //    //dv.RowFilter = "firstname like '%" + txtsearch.Text + "%' or lastname like '%" + txtsearch.Text + "%' or employee_number like '%" + txtsearch.Text + "%' or employment_status_name like '%" + txtsearch.Text + "%'";
            //}
            //else if (lbltotalread.Text == "1")


            //{
            //    if (lblCounts.Text.Trim() == lbltotalread.Text.Trim())
            //    {
            //        //MessageBox.Show("Qty Needed Match Ready TO Save <3");
            //        //ReadyforPreparation();
            //        //BtnSave.Visible = true;
            //    }
            //    else
            //    {
            //        col2();
            //        txt2.Focus();
            //        txt2.Select();
            //    }
            //}
            //else if (lbltotalread.Text == "2")
            //{
            //    if (lblCounts.Text.Trim() == lbltotalread.Text.Trim())
            //    {
            //        //MessageBox.Show("Qty Needed Match Ready TO Save <3");
            //        ReadyforPreparation();
            //        BtnSave.Visible = true;
            //    }
            //    else
            //    {
            //        col3();
            //        txt3.Focus();
            //        txt3.Select();
            //    }
            //}
            //else if (lbltotalread.Text == "3")
            //{
            //    if (lblCounts.Text.Trim() == lbltotalread.Text.Trim())
            //    {
            //        //MessageBox.Show("Qty Needed Match Ready TO Save <3");
            //        ReadyforPreparation();
            //        BtnSave.Visible = true;
            //    }
            //    else
            //    {
            //        col4();
            //        txt4.Focus();
            //        txt4.Select();
            //    }
            //}
            //else if (lbltotalread.Text == "4")
            //{
            //    if (lblCounts.Text.Trim() == lbltotalread.Text.Trim())
            //    {
            //        //MessageBox.Show("Qty Needed Match Ready TO Save <3");
            //        ReadyforPreparation();
            //        BtnSave.Visible = true;
            //    }
            //    else
            //    {
            //        col5();
            //        txt5.Focus();
            //        txt5.Select();
            //    }
            //}
            //else if (lbltotalread.Text == "5")
            //{
            //    if (lblCounts.Text.Trim() == lbltotalread.Text.Trim())
            //    {
            //        //MessageBox.Show("Qty Needed Match Ready TO Save <3");
            //        ReadyforPreparation();
            //        BtnSave.Visible = true;
            //    }
            //    else
            //    {
            //        col6();
            //        txt6.Focus();
            //        txt6.Select();
            //    }
            //}
            //else if (lbltotalread.Text == "6")
            //{
            //    if (lblCounts.Text.Trim() == lbltotalread.Text.Trim())
            //    {
            //        //MessageBox.Show("Qty Needed Match Ready TO Save <3");
            //        ReadyforPreparation();
            //        BtnSave.Visible = true;
            //    }
            //    else
            //    {
            //        col7();
            //        txt7.Focus();
            //        txt7.Select();
            //    }
            //}
            //else if (lbltotalread.Text == "7")
            //{
            //    if (lblCounts.Text.Trim() == lbltotalread.Text.Trim())
            //    {
            //        //MessageBox.Show("Qty Needed Match Ready TO Save <3");
            //        ReadyforPreparation();
            //        BtnSave.Visible = true;
            //    }
            //    else
            //    {
            //        col8();
            //        txt8.Focus();
            //        txt8.Select();
            //    }
            //}
            //else if (lbltotalread.Text == "8")
            //{
            //    if (lblCounts.Text.Trim() == lbltotalread.Text.Trim())
            //    {
            //        //MessageBox.Show("Qty Needed Match Ready TO Save <3");
            //        ReadyforPreparation();
            //        BtnSave.Visible = true;
            //    }
            //    else
            //    {
            //        col9();
            //        txt9.Focus();
            //        txt9.Select();
            //    }
            //}
            //else if (lbltotalread.Text == "9")
            //{
            //    if (lblCounts.Text.Trim() == lbltotalread.Text.Trim())
            //    {
            //        //MessageBox.Show("Qty Needed Match Ready TO Save <3");
            //        ReadyforPreparation();
            //        BtnSave.Visible = true;
            //    }
            //    else
            //    {
            //        col10();
            //        txt10.Focus();
            //        txt10.Select();
            //    }
            //}
            //else if (lbltotalread.Text == "10")
            //{
            //    if (lblCounts.Text.Trim() == lbltotalread.Text.Trim())
            //    {
            //        //MessageBox.Show("Qty Needed Match Ready TO Save <3");
            //        ReadyforPreparation();
            //        BtnSave.Visible = true;
            //    }
            //    else
            //    {
            //        col11();
            //        txt11.Focus();
            //        txt11.Select();
            //    }
            //}
            //else if (lbltotalread.Text == "11")
            //{
            //    if (lblCounts.Text.Trim() == lbltotalread.Text.Trim())
            //    {
            //        //MessageBox.Show("Qty Needed Match Ready TO Save <3");
            //        ReadyforPreparation();
            //        BtnSave.Visible = true;
            //    }
            //    else
            //    {
            //        col12();
            //        txt12.Focus();
            //        txt12.Select();
            //    }
            //}
            //else if (lbltotalread.Text == "12")
            //{
            //    if (lblCounts.Text.Trim() == lbltotalread.Text.Trim())
            //    {
            //        //MessageBox.Show("Qty Needed Match Ready TO Save <3");
            //        ReadyforPreparation();
            //        BtnSave.Visible = true;
            //    }
            //    else
            //    {
            //        col13();
            //        txt13.Focus();
            //        txt13.Select();
            //    }
            //}
            //else if (lbltotalread.Text == "13")
            //{
            //    if (lblCounts.Text.Trim() == lbltotalread.Text.Trim())
            //    {
            //        //MessageBox.Show("Qty Needed Match Ready TO Save <3");
            //        ReadyforPreparation();
            //        BtnSave.Visible = true;
            //    }
            //    else
            //    {
            //        col14();
            //        txt14.Focus();
            //        txt14.Select();
            //    }
            //}
            //else if (lbltotalread.Text == "14")
            //{
            //    if (lblCounts.Text.Trim() == lbltotalread.Text.Trim())
            //    {
            //        //MessageBox.Show("Qty Needed Match Ready TO Save <3");
            //        ReadyforPreparation();
            //        BtnSave.Visible = true;
            //    }
            //    else
            //    {
            //        col15();
            //        txt15.Focus();
            //        txt15.Select();
            //    }
            //}
            //else if (lbltotalread.Text == "15")
            //{
            //    if (lblCounts.Text.Trim() == lbltotalread.Text.Trim())
            //    {
            //        //MessageBox.Show("Qty Needed Match Ready TO Save <3");
            //        ReadyforPreparation();
            //        BtnSave.Visible = true;
            //    }
            //    else
            //    {
            //        col16();
            //        txt16.Focus();
            //        txt16.Select();
            //    }
            //}
            //else if (lbltotalread.Text == "16")
            //{
            //    if (lblCounts.Text.Trim() == lbltotalread.Text.Trim())
            //    {
            //        //MessageBox.Show("Qty Needed Match Ready TO Save <3");
            //        //ReadyforPreparation();
            //        //BtnSave.Visible = true;5/18/2020
                    
            //    }
            //    else
            //    {
            //        col17();
            //        txt17.Focus();
            //        txt17.Select();
            //    }
            //}
            //else if (lbltotalread.Text == "18")
            //{
            //    if (lblCounts.Text.Trim() == lbltotalread.Text.Trim())
            //    {
            //        //MessageBox.Show("Qty Needed Match Ready TO Save <3");
            //        ReadyforPreparation();
            //        BtnSave.Visible = true;
            //    }
            //    else
            //    {
            //        col19();
            //        txt19.Focus();
            //        txt19.Select();
            //    }
            //}
            //else if (lbltotalread.Text == "19")
            //{
            //    if (lblCounts.Text.Trim() == lbltotalread.Text.Trim())
            //    {
            //        //MessageBox.Show("Qty Needed Match Ready TO Save <3");
            //        ReadyforPreparation();
            //        BtnSave.Visible = true;
            //    }
            //    else
            //    {
            //        col20();
            //        txt20.Focus();
            //        txt20.Select();
            //    }
            //}
            //else if (lbltotalread.Text == "20")
            //{
            //    if (lblCounts.Text.Trim() == lbltotalread.Text.Trim())
            //    {
            //        //MessageBox.Show("Qty Needed Match Ready TO Save <3");
            //        ReadyforPreparation();
            //        BtnSave.Visible = true;
            //    }
            //    else
            //    {
            //        col21();
            //        txt21.Focus();
            //        txt21.Select();
            //    }
            //}
            //else if (lbltotalread.Text == "21")
            //{
            //    if (lblCounts.Text.Trim() == lbltotalread.Text.Trim())
            //    {
            //        //MessageBox.Show("Qty Needed Match Ready TO Save <3");
            //        ReadyforPreparation();
            //        BtnSave.Visible = true;
            //    }
            //    else
            //    {
            //        col22();
            //        txt22.Focus();
            //        txt22.Select();
            //    }
            //}
            //else if (lbltotalread.Text == "22")
            //{
            //    if (lblCounts.Text.Trim() == lbltotalread.Text.Trim())
            //    {
            //        //MessageBox.Show("Qty Needed Match Ready TO Save <3");
            //        ReadyforPreparation();
            //        BtnSave.Visible = true;
            //    }
            //    else
            //    {
            //        col23();
            //        txt23.Focus();
            //        txt23.Select();
            //    }
            //}
            //else if (lbltotalread.Text == "23")
            //{
            //    if (lblCounts.Text.Trim() == lbltotalread.Text.Trim())
            //    {
            //        //MessageBox.Show("Qty Needed Match Ready TO Save <3");
            //        ReadyforPreparation();
            //        BtnSave.Visible = true;
            //    }
            //    else
            //    {
            //        col24();
            //        txt24.Focus();
            //        txt24.Select();
            //    }
            //}
            //else if (lbltotalread.Text == "24")
            //{
            //    if (lblCounts.Text.Trim() == lbltotalread.Text.Trim())
            //    {
            //        //MessageBox.Show("Qty Needed Match Ready TO Save <3");
            //        ReadyforPreparation();
            //        BtnSave.Visible = true;
            //        row25();

            //        return;
            //    }
            //    else
            //    {
            //        col25();
            //        txt25.Focus();
            //        txt25.Select();
            //    }
            //}
            //else if (lbltotalread.Text == "25")
            //{
            //    if (lblCounts.Text.Trim() == lbltotalread.Text.Trim())
            //    {
            //        //MessageBox.Show("Qty Needed Match Ready TO Save <3");
            //        //ReadyforPreparation();
            //        //BtnSave.Visible = true;

            //        return;
            //    }
            //    else
            //    {
            //        //col18();
            //        //txt18.Focus();
            //        //txt18.Select();
            //    }
            //}
            //else
            //{

            //}

        }

        public void col2()
        {
            txtitemcode2.Visible = true;
            txtdescription2.Visible = true;
            txtbatch2.Visible = true;
            txtbatchtwo.Visible = true;
            txtsumtotal2.Visible = true;
            txtcode2.Visible = true;
            txttotalrepack2.Visible = true;
            txtqty2.Visible = true;
            txt2.Visible = true;

            //2
            bunifuThinButton22.Visible = true;
            bunifuThinButton27.Visible = true;
            bunifuThinButton28.Visible = true;
            bunifuThinButton29.Visible = true;
            bunifuThinButton210.Visible = true;
            lblnum2.Visible = true;
            b2.Visible = true;


        }
        void StressHideTextBox()
        {
            txt1.Text = "";
            txt1.BackColor = Color.White;
            //
            bunifuThinButton22.Visible = false;
            bunifuThinButton27.Visible = false;
            bunifuThinButton28.Visible = false;
            bunifuThinButton29.Visible = false;
            bunifuThinButton210.Visible = false;


            //3\  
            bunifu3rd.Visible = false;
            bunifuThinButton212.Visible = false;
            bunifuThinButton211.Visible = false;
            bunifuThinButton213.Visible = false;
            bunifuThinButton214.Visible = false;
            //4
            bunifuThinButton215.Visible = false;
            bunifuThinButton216.Visible = false;
            bunifuThinButton217.Visible = false;
            bunifuThinButton218.Visible = false;
            bunifuThinButton219.Visible = false;

            //5

            bunifuThinButton220.Visible = false;
            bunifuThinButton221.Visible = false;
            bunifuThinButton222.Visible = false;
            bunifuThinButton223.Visible = false;
            bunifuThinButton224.Visible = false;
            //6

            bunifuThinButton225.Visible = false;
            bunifuThinButton226.Visible = false;
            bunifuThinButton227.Visible = false;

            bunifuThinButton228.Visible = false;
            bunifuThinButton229.Visible = false;

            //7
            bunifuThinButton230.Visible = false;
            bunifuThinButton231.Visible = false;
            bunifuThinButton232.Visible = false;
            bunifuThinButton233.Visible = false;
            bunifuThinButton234.Visible = false;
            //8
            bunifuThinButton235.Visible = false;
            bunifuThinButton238.Visible = false;
            bunifuThinButton241.Visible = false;
            bunifuThinButton244.Visible = false;
            bunifuThinButton247.Visible = false;

            //9
            bunifuThinButton236.Visible = false;
            bunifuThinButton239.Visible = false;
            bunifuThinButton242.Visible = false;
            bunifuThinButton245.Visible = false;
            bunifuThinButton248.Visible = false;
            //10
            bunifuThinButton237.Visible = false;
            bunifuThinButton240.Visible = false;
            bunifuThinButton243.Visible = false;
            bunifuThinButton246.Visible = false;
            bunifuThinButton249.Visible = false;
            //11
            bunifuThinButton250.Visible = false;
            bunifuThinButton265.Visible = false;
            bunifuThinButton270.Visible = false;
            bunifuThinButton276.Visible = false;
            bunifuThinButton282.Visible = false;
            //12
            bunifuThinButton251.Visible = false;
            bunifuThinButton266.Visible = false;
            bunifuThinButton271.Visible = false;
            bunifuThinButton277.Visible = false;
            bunifuThinButton283.Visible = false;
            //13
            bunifuThinButton252.Visible = false;
            bunifuThinButton267.Visible = false;
            bunifuThinButton272.Visible = false;
            bunifuThinButton278.Visible = false;
            bunifuThinButton284.Visible = false;
            //14

            bunifuThinButton253.Visible = false;
            bunifuThinButton268.Visible = false;
            bunifuThinButton273.Visible = false;
            bunifuThinButton279.Visible = false;
            bunifuThinButton285.Visible = false;

            //15
            bunifuThinButton254.Visible = false;
            bunifuThinButton269.Visible = false;
            bunifuThinButton274.Visible = false;
            bunifuThinButton280.Visible = false;
            bunifuThinButton286.Visible = false;

            //15
            bunifuThinButton255.Visible = false;
            bunifuThinButton288.Visible = false;
            bunifuThinButton275.Visible = false;
            bunifuThinButton281.Visible = false;
            bunifuThinButton287.Visible = false;
            //17

            bunifuThinButton256.Visible = false;
            bunifuThinButton289.Visible = false;
            bunifuThinButton298.Visible = false;
            bunifuThinButton2107.Visible = false;
            bunifuThinButton2116.Visible = false;

            //18
            bunifuThinButton257.Visible = false;
            bunifuThinButton290.Visible = false;
            bunifuThinButton299.Visible = false;
            bunifuThinButton2108.Visible = false;
            bunifuThinButton2117.Visible = false;
            //19

            bunifuThinButton258.Visible = false;
            bunifuThinButton291.Visible = false;
            bunifuThinButton2100.Visible = false;
            bunifuThinButton2109.Visible = false;
            bunifuThinButton2118.Visible = false;

            //20
            bunifuThinButton259.Visible = false;
            bunifuThinButton292.Visible = false;
            bunifuThinButton2101.Visible = false;
            bunifuThinButton2110.Visible = false;
            bunifuThinButton2119.Visible = false;
            //21
            bunifuThinButton260.Visible = false;
            bunifuThinButton293.Visible = false;
            bunifuThinButton2102.Visible = false;
            bunifuThinButton2111.Visible = false;
            bunifuThinButton2120.Visible = false;

            //22
            bunifuThinButton261.Visible = false;
            bunifuThinButton297.Visible = false;
            bunifuThinButton2103.Visible = false;
            bunifuThinButton2115.Visible = false;
            bunifuThinButton2123.Visible = false;

            //23

            bunifuThinButton262.Visible = false;
            bunifuThinButton296.Visible = false;
            bunifuThinButton2104.Visible = false;
            bunifuThinButton2114.Visible = false;
            bunifuThinButton2124.Visible = false;

            //24
            bunifuThinButton263.Visible = false;
            bunifuThinButton295.Visible = false;
            bunifuThinButton2105.Visible = false;
            bunifuThinButton2113.Visible = false;
            bunifuThinButton2122.Visible = false;

            //25
            bunifuThinButton264.Visible = false;
            bunifuThinButton294.Visible = false;
            bunifuThinButton2106.Visible = false;
            bunifuThinButton2112.Visible = false;
            bunifuThinButton2121.Visible = false;

        }

        public void row2()
        {
            txtitemcode2.Visible = false;
            txtdescription2.Visible = false;
            txtbatch2.Visible = false;
            txtbatchtwo.Visible = false;
            txtsumtotal2.Visible = false;
            txtcode2.Visible = false;
            txttotalrepack2.Visible = false;
            txtqty2.Visible = false;
            txt2.Visible = false;


            lblnum2.Visible = false;
            b2.Visible = false;
        }
        public void row3()
        {
            txtitemcode3.Visible = false;
            txtdescription3.Visible = false;
            txtbatch3.Visible = false;
            txtqtybatch3.Visible = false;
            txtsumtotal3.Visible = false;
            txtcode3.Visible = false;
            txttotalrepack3.Visible = false;
            txtqty3.Visible = false;
            txt3.Visible = false;


            lblnum3.Visible = false;
            b3.Visible = false;
        }
        public void row4()
        {
            txtitemcode4.Visible = false;
            txtdescription4.Visible = false;
            txtbatch4.Visible = false;
            txtqtybatch4.Visible = false;
            txtsumtotal4.Visible = false;
            txtcode4.Visible = false;
            txttotalrepack4.Visible = false;
            txtqty4.Visible = false;
            txt4.Visible = false;


            lblnum4.Visible = false;
            b4.Visible = false;
        }


        public void row5()
        {
            txtitemcode5.Visible = false;
            txtdescription5.Visible = false;
            txtbatch5.Visible = false;
            txtqtybatch5.Visible = false;
            txtsumtotal5.Visible = false;
            txtcode5.Visible = false;
            txttotalrepack5.Visible = false;
            txtqty5.Visible = false;
            txt5.Visible = false;


            lblnum5.Visible = false;
            b5.Visible = false;
        }


        public void row6()
        {
            txtitemcode6.Visible = false;
            txtdescription6.Visible = false;
            txtbatch6.Visible = false;
            txtqtybatch6.Visible = false;
            txtsumtotal6.Visible = false;
            txtcode6.Visible = false;
            txttotalrepack6.Visible = false;
            txtqty6.Visible = false;
            txt6.Visible = false;

            b6.Visible = false;
            lblnum6.Visible = false;
            b6.Visible = false;
        }
        public void row7()
        {
            txtitemcode7.Visible = false;
            txtdescription7.Visible = false;
            txtbatch7.Visible = false;
            txtqtybatch7.Visible = false;
            txtsumtotal7.Visible = false;
            txtcode7.Visible = false;
            txttotalrepack7.Visible = false;
            txtqty7.Visible = false;
            txt7.Visible = false;


            lblnum7.Visible = false;
            b7.Visible = false;
        }



        public void row8()
        {
            txtitemcode8.Visible = false;
            txtdescription8.Visible = false;
            txtbatch8.Visible = false;
            txtqtybatch8.Visible = false;
            txtsumtotal8.Visible = false;
            txtcode8.Visible = false;
            txttotalrepack8.Visible = false;
            txtqty8.Visible = false;
            txt8.Visible = false;


            lblnum8.Visible = false;
            b8.Visible = false;
        }


        public void row9()
        {
            txtitemcode9.Visible = false;
            txtdescription9.Visible = false;
            txtbatch9.Visible = false;
            txtqtybatch9.Visible = false;
            txtsumtotal9.Visible = false;
            txtcode9.Visible = false;
            txttotalrepack9.Visible = false;
            txtqty9.Visible = false;
            txt9.Visible = false;


            lblnum9.Visible = false;
            b9.Visible = false;
        }

        public void row10()
        {
            txtitemcode10.Visible = false;
            txtdescription10.Visible = false;
            txtbatch10.Visible = false;
            txtqtybatch10.Visible = false;
            txtsumtotal10.Visible = false;
            txtcode10.Visible = false;
            txttotalrepack10.Visible = false;
            txtqty10.Visible = false;
            txt10.Visible = false;


            lblnum10.Visible = false;
            b10.Visible = false;
        }

        public void row11()
        {
            txtitemcode11.Visible = false;
            txtdescription11.Visible = false;
            txtbatch11.Visible = false;
            txtqtybatch11.Visible = false;
            txtsumtotal11.Visible = false;
            txtcode11.Visible = false;
            txttotalrepack11.Visible = false;
            txtqty11.Visible = false;
            txt11.Visible = false;


            b11.Visible = false;
            lblnum11.Visible = false;
        }

        public void row12()
        {
            txtitemcode12.Visible = false;
            txtdescription12.Visible = false;
            txtbatch12.Visible = false;
            txtqtybatch12.Visible = false;
            txtsumtotal12.Visible = false;
            txtcode12.Visible = false;
            txttotalrepack12.Visible = false;
            txtqty12.Visible = false;
            txt12.Visible = false;


            b12.Visible = false;
            lblnum12.Visible = false;
        }




        public void row13()
        {
            txtitemcode13.Visible = false;
            txtdescription13.Visible = false;
            txtbatch13.Visible = false;
            txtqtybatch13.Visible = false;
            txtsumtotal13.Visible = false;
            txtcode13.Visible = false;
            txttotalrepack13.Visible = false;
            txtqty13.Visible = false;
            txt13.Visible = false;


            b13.Visible = false;
            lblnum13.Visible = false;
        }

        public void row14()
        {
            txtitemcode14.Visible = false;
            txtdescription14.Visible = false;
            txtbatch14.Visible = false;
            txtqtybatch14.Visible = false;
            txtsumtotal14.Visible = false;
            txtcode14.Visible = false;
            txttotalrepack14.Visible = false;
            txtqty14.Visible = false;
            txt14.Visible = false;


            b14.Visible = false;
            lblnum14.Visible = false;
        }

        public void row15()
        {
            txtitemcode15.Visible = false;
            txtdescription15.Visible = false;
            txtbatch15.Visible = false;
            txtqtybatch15.Visible = false;
            txtsumtotal15.Visible = false;
            txtcode15.Visible = false;
            txttotalrepack15.Visible = false;
            txtqty15.Visible = false;
            txt15.Visible = false;


            b15.Visible = false;
            lblnum15.Visible = false;
        }

        public void row16()
        {
            txtitemcode16.Visible = false;
            txtdescription16.Visible = false;
            txtbatch16.Visible = false;
            txtqtybatch16.Visible = false;
            txtsumtotal16.Visible = false;
            txtcode16.Visible = false;
            txttotalrepack16.Visible = false;
            txtqty16.Visible = false;
            txt16.Visible = false;

            b16.Visible = false;
            lblnum16.Visible = false;
        }

        public void row17()
        {
            txtitemcode17.Visible = false;
            txtdescription17.Visible = false;
            txtbatch17.Visible = false;
            txtqtybatch17.Visible = false;
            txtsumtotal17.Visible = false;
            txtcode17.Visible = false;
            txttotalrepack17.Visible = false;
            txtqty17.Visible = false;
            txt17.Visible = false;
            b17.Visible = false;
            lblnum17.Visible = false;
        }



        public void col3()
        {
            txtitemcode3.Visible = true;
            txtdescription3.Visible = true;
            txtbatch3.Visible = true;
            txtqtybatch3.Visible = true;
            txtsumtotal3.Visible = true;
            txtcode3.Visible = true;
            txttotalrepack3.Visible = true;
            txtqty3.Visible = true;
            txt3.Visible = true;

            bunifu3rd.Visible = true;
            bunifuThinButton212.Visible = true;
            bunifuThinButton211.Visible = true;
            bunifuThinButton213.Visible = true;
            bunifuThinButton214.Visible = true;

            lblnum3.Visible = true;
            b3.Visible = true;

        }

        public void col4()
        {
            txtitemcode4.Visible = true;
            txtdescription4.Visible = true;
            txtbatch4.Visible = true;
            txtqtybatch4.Visible = true;
            txtsumtotal4.Visible = true;
            txtcode4.Visible = true;
            txttotalrepack4.Visible = true;
            txtqty4.Visible = true;
            txt4.Visible = true;

            bunifuThinButton215.Visible = true;
            bunifuThinButton216.Visible = true;
            bunifuThinButton217.Visible = true;
            bunifuThinButton218.Visible = true;
            bunifuThinButton219.Visible = true;
            lblnum4.Visible = true;
            b4.Visible = true;
        }

        public void col5()
        {
            txtitemcode5.Visible = true;
            txtdescription5.Visible = true;
            txtbatch5.Visible = true;
            txtqtybatch5.Visible = true;
            txtsumtotal5.Visible = true;
            txtcode5.Visible = true;
            txttotalrepack5.Visible = true;
            txtqty5.Visible = true;
            txt5.Visible = true;

            bunifuThinButton220.Visible = true;
            bunifuThinButton221.Visible = true;
            bunifuThinButton222.Visible = true;
            bunifuThinButton223.Visible = true;
            bunifuThinButton224.Visible = true;
            lblnum5.Visible = true;
            b5.Visible = true;
        }
        public void col6()
        {
            txtitemcode6.Visible = true;
            txtdescription6.Visible = true;
            txtbatch6.Visible = true;
            txtqtybatch6.Visible = true;
            txtsumtotal6.Visible = true;
            txtcode6.Visible = true;
            txttotalrepack6.Visible = true;
            txtqty6.Visible = true;
            txt6.Visible = true;

            bunifuThinButton225.Visible = true;
            bunifuThinButton226.Visible = true;
            bunifuThinButton227.Visible = true;
            bunifuThinButton228.Visible = true;
            bunifuThinButton229.Visible = true;
            lblnum6.Visible = true;
            b6.Visible = true;
        }

        public void col7()
        {
            txtitemcode7.Visible = true;
            txtdescription7.Visible = true;
            txtbatch7.Visible = true;
            txtqtybatch7.Visible = true;
            txtsumtotal7.Visible = true;
            txtcode7.Visible = true;
            txttotalrepack7.Visible = true;
            txtqty7.Visible = true;
            txt7.Visible = true;


            bunifuThinButton230.Visible = true;
            bunifuThinButton231.Visible = true;
            bunifuThinButton232.Visible = true;
            bunifuThinButton233.Visible = true;
            bunifuThinButton234.Visible = true;
            lblnum7.Visible = true;
            b7.Visible = true;

        }
        public void col8()
        {
            txtitemcode8.Visible = true;
            txtdescription8.Visible = true;
            txtbatch8.Visible = true;
            txtqtybatch8.Visible = true;
            txtsumtotal8.Visible = true;
            txtcode8.Visible = true;
            txttotalrepack8.Visible = true;
            txtqty8.Visible = true;
            txt8.Visible = true;




            bunifuThinButton235.Visible = true;
            bunifuThinButton238.Visible = true;
            bunifuThinButton241.Visible = true;
            bunifuThinButton244.Visible = true;
            bunifuThinButton247.Visible = true;
            lblnum8.Visible = true;
            b8.Visible = true;
        }
        public void col9()
        {
            txtitemcode9.Visible = true;
            txtdescription9.Visible = true;
            txtbatch9.Visible = true;
            txtqtybatch9.Visible = true;
            txtsumtotal9.Visible = true;
            txtcode9.Visible = true;
            txttotalrepack9.Visible = true;
            txtqty9.Visible = true;
            txt9.Visible = true;


            bunifuThinButton236.Visible = true;
            bunifuThinButton239.Visible = true;
            bunifuThinButton242.Visible = true;
            bunifuThinButton245.Visible = true;
            bunifuThinButton248.Visible = true;
            lblnum9.Visible = true;
            b9.Visible = true;


        }
        public void col10()
        {
            txtitemcode10.Visible = true;
            txtdescription10.Visible = true;
            txtbatch10.Visible = true;
            txtqtybatch10.Visible = true;
            txtsumtotal10.Visible = true;
            txtcode10.Visible = true;
            txttotalrepack10.Visible = true;
            txtqty10.Visible = true;
            txt10.Visible = true;



            bunifuThinButton237.Visible = true;
            bunifuThinButton240.Visible = true;
            bunifuThinButton243.Visible = true;
            bunifuThinButton246.Visible = true;
            bunifuThinButton249.Visible = true;
            lblnum10.Visible = true;
            b10.Visible = true;
        }
        public void col11()
        {
            txtitemcode11.Visible = true;
            txtdescription11.Visible = true;
            txtbatch11.Visible = true;
            txtqtybatch11.Visible = true;
            txtsumtotal11.Visible = true;
            txtcode11.Visible = true;
            txttotalrepack11.Visible = true;
            txtqty11.Visible = true;
            txt11.Visible = true;



            bunifuThinButton250.Visible = true;
            bunifuThinButton265.Visible = true;
            bunifuThinButton270.Visible = true;
            bunifuThinButton276.Visible = true;
            bunifuThinButton282.Visible = true;

            lblnum11.Visible = true;
            b11.Visible = true;

        }
        public void col12()
        {
            txtitemcode12.Visible = true;
            txtdescription12.Visible = true;
            txtbatch12.Visible = true;
            txtqtybatch12.Visible = true;
            txtsumtotal12.Visible = true;
            txtcode12.Visible = true;
            txttotalrepack12.Visible = true;
            txtqty12.Visible = true;
            txt12.Visible = true;


            bunifuThinButton251.Visible = true;
            bunifuThinButton266.Visible = true;
            bunifuThinButton271.Visible = true;
            bunifuThinButton277.Visible = true;
            bunifuThinButton283.Visible = true;

            lblnum12.Visible = true;
            b12.Visible = true;

        }
        public void col13()
        {
            txtitemcode13.Visible = true;
            txtdescription13.Visible = true;
            txtbatch13.Visible = true;
            txtqtybatch13.Visible = true;
            txtsumtotal13.Visible = true;
            txtcode13.Visible = true;
            txttotalrepack13.Visible = true;
            txtqty13.Visible = true;
            txt13.Visible = true;


            bunifuThinButton252.Visible = true;
            bunifuThinButton267.Visible = true;
            bunifuThinButton272.Visible = true;
            bunifuThinButton278.Visible = true;
            bunifuThinButton284.Visible = true;

            lblnum13.Visible = true;
            b13.Visible = true;

        }
        public void col14()
        {
            txtitemcode14.Visible = true;
            txtdescription14.Visible = true;
            txtbatch14.Visible = true;
            txtqtybatch14.Visible = true;
            txtsumtotal14.Visible = true;
            txtcode14.Visible = true;
            txttotalrepack14.Visible = true;
            txtqty14.Visible = true;
            txt14.Visible = true;



            bunifuThinButton253.Visible = true;
            bunifuThinButton268.Visible = true;
            bunifuThinButton273.Visible = true;
            bunifuThinButton279.Visible = true;
            bunifuThinButton285.Visible = true;
            lblnum14.Visible = true;
            b14.Visible = true;

        }
        public void col15()
        {
            txtitemcode15.Visible = true;
            txtdescription15.Visible = true;
            txtbatch15.Visible = true;
            txtqtybatch15.Visible = true;
            txtsumtotal15.Visible = true;
            txtcode15.Visible = true;
            txttotalrepack15.Visible = true;
            txtqty15.Visible = true;
            txt15.Visible = true;


            bunifuThinButton254.Visible = true;
            bunifuThinButton269.Visible = true;
            bunifuThinButton274.Visible = true;
            bunifuThinButton280.Visible = true;
            bunifuThinButton286.Visible = true;
            lblnum15.Visible = true;
            b15.Visible = true;

        }
        public void col16()
        {
            txtitemcode16.Visible = true;
            txtdescription16.Visible = true;
            txtbatch16.Visible = true;
            txtqtybatch16.Visible = true;
            txtsumtotal16.Visible = true;
            txtcode16.Visible = true;
            txttotalrepack16.Visible = true;
            txtqty16.Visible = true;
            txt16.Visible = true;


            bunifuThinButton255.Visible = true;
            bunifuThinButton288.Visible = true;
            bunifuThinButton275.Visible = true;
            bunifuThinButton281.Visible = true;
            bunifuThinButton287.Visible = true;

            lblnum16.Visible = true;
            b16.Visible = true;


        }

        public void col17()
        {
            txtitemcode17.Visible = true;
            txtdescription17.Visible = true;
            txtbatch17.Visible = true;
            txtqtybatch17.Visible = true;
            txtsumtotal17.Visible = true;
            txtcode17.Visible = true;
            txttotalrepack17.Visible = true;
            txtqty17.Visible = true;
            txt17.Visible = true;


            bunifuThinButton256.Visible = true;
            bunifuThinButton289.Visible = true;
            bunifuThinButton298.Visible = true;
            bunifuThinButton2107.Visible = true;
            bunifuThinButton2116.Visible = true;
            lblnum17.Visible = true;
            b17.Visible = true;

        }
        public void col18()
        {
            txtitemcode18.Visible = true;
            txtdescription18.Visible = true;
            txtbatch18.Visible = true;
            txtqtybatch18.Visible = true;
            txtsumtotal18.Visible = true;
            txtcode18.Visible = true;
            txttotalrepack18.Visible = true;
            txtqty18.Visible = true;
            txt18.Visible = true;


            bunifuThinButton257.Visible = true;
            bunifuThinButton290.Visible = true;
            bunifuThinButton299.Visible = true;
            bunifuThinButton2108.Visible = true;
            bunifuThinButton2117.Visible = true;
            lblnum18.Visible = true;
            b18.Visible = true;

        }

        public void col19()
        {
            txtitemcode19.Visible = true;
            txtdescription19.Visible = true;
            txtbatch19.Visible = true;
            txtqtybatch19.Visible = true;
            txtsumtotal19.Visible = true;
            txtcode19.Visible = true;
            txttotalrepack19.Visible = true;
            txtqty19.Visible = true;
            txt19.Visible = true;

            bunifuThinButton258.Visible = true;
            bunifuThinButton291.Visible = true;
            bunifuThinButton2100.Visible = true;
            bunifuThinButton2109.Visible = true;
            bunifuThinButton2118.Visible = true;
            lblnum19.Visible = true;
            b19.Visible = true;

        }

        public void col20()
        {
            txtitemcode20.Visible = true;
            txtdescription20.Visible = true;
            txtbatch20.Visible = true;
            txtqtybatch20.Visible = true;
            txtsumtotal20.Visible = true;
            txtcode20.Visible = true;
            txttotalrepack20.Visible = true;
            txtqty20.Visible = true;
            txt20.Visible = true;


            bunifuThinButton259.Visible = true;
            bunifuThinButton292.Visible = true;
            bunifuThinButton2101.Visible = true;
            bunifuThinButton2110.Visible = true;
            bunifuThinButton2119.Visible = true;
            lblnum20.Visible = true;
            b20.Visible = true;

        }
        public void col21()
        {
            txtitemcode21.Visible = true;
            txtdescription21.Visible = true;
            txtbatch21.Visible = true;
            txtqtybatch21.Visible = true;
            txtsumtotal21.Visible = true;
            txtcode21.Visible = true;
            txttotalrepack21.Visible = true;
            txtqty21.Visible = true;
            txt21.Visible = true;

            bunifuThinButton260.Visible = true;
            bunifuThinButton293.Visible = true;
            bunifuThinButton2102.Visible = true;
            bunifuThinButton2111.Visible = true;
            bunifuThinButton2120.Visible = true;


            lblnum21.Visible = true;

            b21.Visible = true;


        }
        public void col22()
        {
            txtitemcode22.Visible = true;
            txtdescription22.Visible = true;
            txtbatch22.Visible = true;
            txtqtybatch22.Visible = true;
            txtsumtotal22.Visible = true;
            txtcode22.Visible = true;
            txttotalrepack22.Visible = true;
            txtqty22.Visible = true;
            txt22.Visible = true;


            bunifuThinButton261.Visible = true;
            bunifuThinButton297.Visible = true;
            bunifuThinButton2103.Visible = true;
            bunifuThinButton2115.Visible = true;
            bunifuThinButton2123.Visible = true;
            lblnum22.Visible = true;
            b22.Visible = true;

        }

        public void col23()
        {
            txtitemcode23.Visible = true;
            txtdescription23.Visible = true;
            txtbatch23.Visible = true;
            txtqtybatch23.Visible = true;
            txtsumtotal23.Visible = true;
            txtcode23.Visible = true;
            txttotalrepack23.Visible = true;
            txtqty23.Visible = true;
            txt23.Visible = true;

            bunifuThinButton262.Visible = true;
            bunifuThinButton296.Visible = true;
            bunifuThinButton2104.Visible = true;
            bunifuThinButton2114.Visible = true;
            bunifuThinButton2124.Visible = true;
            b23.Visible = true;

            lblnum23.Visible = true;
        }

        public void col24()
        {
            txtitemcode24.Visible = true;
            txtdescription24.Visible = true;
            txtbatch24.Visible = true;
            txtqtybatch24.Visible = true;
            txtsumtotal24.Visible = true;
            txtcode24.Visible = true;
            txttotalrepack24.Visible = true;
            txtqty24.Visible = true;
            txt24.Visible = true;
            b24.Visible = true;


            bunifuThinButton263.Visible = true;
            bunifuThinButton295.Visible = true;
            bunifuThinButton2105.Visible = true;
            bunifuThinButton2113.Visible = true;
            bunifuThinButton2122.Visible = true;
            lblnum24.Visible = true;

        }

        public void col25()
        {
            txtitemcode25.Visible = true;
            txtdescription25.Visible = true;
            txtbatch25.Visible = true;
            txtqtybatch25.Visible = true;
            txtsumtotal250.Visible = true;
            txtcode25.Visible = true;
            txttotalrepack25.Visible = true;
            txtqty25.Visible = true;
            txt25.Visible = true;


            bunifuThinButton264.Visible = true;
            bunifuThinButton294.Visible = true;
            bunifuThinButton2106.Visible = true;
            bunifuThinButton2112.Visible = true;
            bunifuThinButton2121.Visible = true;
            lblnum25.Visible = true;
            b25.Visible = true;

        }

        public void row18()
        {
            txtitemcode18.Visible = false;
            txtdescription18.Visible = false;
            txtbatch18.Visible = false;
            txtqtybatch18.Visible = false;
            txtsumtotal18.Visible = false;
            txtcode18.Visible = false;
            txttotalrepack18.Visible = false;
            txtqty18.Visible = false;
            txt18.Visible = false;

            lblnum18.Visible = false;
            b18.Visible = false;
        }
        public void row19()
        {
            txtitemcode19.Visible = false;
            txtdescription19.Visible = false;
            txtbatch19.Visible = false;
            txtqtybatch19.Visible = false;
            txtsumtotal19.Visible = false;
            txtcode19.Visible = false;
            txttotalrepack19.Visible = false;
            txtqty19.Visible = false;
            txt19.Visible = false;

            lblnum19.Visible = false;
            b19.Visible = false;
        }
        public void row20()
        {
            txtitemcode20.Visible = false;
            txtdescription20.Visible = false;
            txtbatch20.Visible = false;
            txtqtybatch20.Visible = false;
            txtsumtotal20.Visible = false;
            txtcode20.Visible = false;
            txttotalrepack20.Visible = false;
            txtqty20.Visible = false;
            txt20.Visible = false;
            b20.Visible = false;
            lblnum20.Visible = false;
        }
        public void row21()
        {
            txtitemcode21.Visible = false;
            txtdescription21.Visible = false;
            txtbatch21.Visible = false;
            txtqtybatch21.Visible = false;
            txtsumtotal21.Visible = false;
            txtcode21.Visible = false;
            txttotalrepack21.Visible = false;
            txtqty21.Visible = false;
            txt21.Visible = false;
            lblnum21.Visible = false;
            b21.Visible = false;
        }
        public void row22()
        {
            txtitemcode22.Visible = false;
            txtdescription22.Visible = false;
            txtbatch22.Visible = false;
            txtqtybatch22.Visible = false;
            txtsumtotal22.Visible = false;
            txtcode22.Visible = false;
            txttotalrepack22.Visible = false;
            txtqty22.Visible = false;
            txt22.Visible = false;
            lblnum22.Visible = false;
            b22.Visible = false;
        }
        public void row23()
        {
            txtitemcode23.Visible = false;
            txtdescription23.Visible = false;
            txtbatch23.Visible = false;
            txtqtybatch23.Visible = false;
            txtsumtotal23.Visible = false;
            txtcode23.Visible = false;
            txttotalrepack23.Visible = false;
            txtqty23.Visible = false;
            txt23.Visible = false;
            lblnum23.Visible = false;
            b23.Visible = false;
            b23.Visible = false;
        }
        public void row24()
        {
            txtitemcode24.Visible = false;
            txtdescription24.Visible = false;
            txtbatch24.Visible = false;
            txtqtybatch24.Visible = false;
            txtsumtotal24.Visible = false;
            txtcode24.Visible = false;
            txttotalrepack24.Visible = false;
            txtqty24.Visible = false;
            txt24.Visible = false;
            lblnum24.Visible = false;
            b24.Visible = false;
        }
        public void row25()
        {
            txtitemcode25.Visible = false;
            txtdescription25.Visible = false;
            txtbatch25.Visible = false;
            txtqtybatch25.Visible = false;
            txtsumtotal250.Visible = false;
            txtcode25.Visible = false;
            txttotalrepack25.Visible = false;
            txtqty25.Visible = false;
            txt25.Visible = false;
            lblnum25.Visible = false;
            b25.Visible = false;
        }



        public void calldisable()
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            pictureBox9.Visible = false;
            pictureBox10.Visible = false;
            pictureBox11.Visible = false;
            pictureBox12.Visible = false;
            pictureBox13.Visible = false;
            pictureBox14.Visible = false;
            pictureBox15.Visible = false;
            pictureBox16.Visible = false;
            pictureBox17.Visible = false;
            pictureBox18.Visible = false;
            pictureBox19.Visible = false;
            pictureBox20.Visible = false;
            pictureBox21.Visible = false;
            pictureBox22.Visible = false;
            pictureBox23.Visible = false;
            pictureBox24.Visible = false;
            pictureBox25.Visible = false;
         
        }
        public void Callothers()
        {

            DateTime dNow = DateTime.Now;
            txtdatenow.Text = (dNow.ToString("MM/dd/yyyy"));

        }
        public void load_Schedules()
        {
            string mcolumns = "prod_id,p_feed_code,rp_feed_type,p_bags,p_nobatch,proddate,repacking_status";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgvMaster, mcolumns, "schedules_approved_preparation2");
            label10.Text = dgvMaster.RowCount.ToString();
            // textBox1.Text = dgv_table.RowCount.ToString();

        }
        //to get the accurate loading of my pages
     
        private void dgvMaster_CurrentCellChanged(object sender, EventArgs e)
        {
            showValueDailyProduction();
            //4/24/2020

            if (lblCounts.Text == lbltotalcounts.Text)
            {
                //bunifuStart.Enabled = false;
                txtBarcode.Enabled = true;
                txtBarcode.Select();
                txtBarcode.Focus();
            }
            else
            {

                //bunifuStart.Enabled = true;
                //bunifuStart.Enabled = false;
                txt1.Enabled = false;
                txtBarcode.Enabled = false;
            }



            //if (txtstatus.Text == "ready")
            //{
            //    //bunifuStart.Enabled = false;
            //    bunifuStart.Visible = true;
            //}
            //else
            //{

            //    //bunifuStart.Enabled = true;
            //    bunifuStart.Visible = false;
            //}
        }


        void showValueDailyProduction()
        {

            if (dgvMaster.RowCount > 0)
            {
                if (dgvMaster.CurrentRow != null)
                {
                    if (dgvMaster.CurrentRow.Cells["prod_id"].Value != null)
                    {
                        p_id = Convert.ToInt32(dgvMaster.CurrentRow.Cells["prod_id"].Value);

                        txtmainfeedcode.Text = dgvMaster.CurrentRow.Cells["p_feed_code"].Value.ToString();
                        txtstatus.Text = dgvMaster.CurrentRow.Cells["repacking_status"].Value.ToString();
                        txtmasterid.Text = dgvMaster.CurrentRow.Cells["prod_id"].Value.ToString();
                        txtnobatch.Text = dgvMaster.CurrentRow.Cells["p_nobatch"].Value.ToString();
                        //txtrecommendedsearch.Text = dgvMaster.CurrentRow.Cells["item_code"].Value.ToString();
                        //txtqtyoverall.Text = dgvMaster.CurrentRow.Cells["qty_repack_available"].Value.ToString();
                        //txtmainstocks.Text = dgvMaster.CurrentRow.Cells["total_quantity_raw"].Value.ToString();

                        //cboCategor.Text = dgvMaster.CurrentRow.Cells["item_description"].Value.ToString();






                        //wala muna this


                    }

                }
            }

        }

        private void txtmainfeedcode_TextChanged(object sender, EventArgs e)
        {

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            //deploy

            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=hr_bak;Integrated Security=SSPI";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);
            


            string sqlquery = "select distinct recipe_id,rp_type,feed_code,item_code,rp_description,rp_category,rp_group,quantity from [dbo].[rdf_recipe_to_production] WHERE production_id= '" + txtmasterid.Text + "' AND rp_category='MICRO'  ORDER BY rp_category DESC";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvImport.DataSource = dt;

            times2query();

            sql_con.Close();
       



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
        private void dgvMaster_DoubleClick(object sender, EventArgs e)
        {
            dgv1stView.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {



            doSearch();
            //search();
            txtcode1.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                            txttotalrepack1.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                            //txt1.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();


                           
                          

                      


                            if (txtitemcodeactive.Text.Trim() == txtcode1.Text.Trim())
                            {
                                //MessageBox.Show("Proceed Match Code");

                            }
                            else
                            {
        
                                //ItemCodeNotMatched();
                                txt1.Text = "";
             
                    
                                //txtBarcode.Text = "";
                                txtBarcode.Focus();
                                txtBarcode.Text = "";
                     
                                return;
                        
                            }
            //txt1.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
            txt1.Text = dgvrepackdb.CurrentRow.Cells["string_id"].Value.ToString();

                         if (txttotalrepack1.Text.Trim() == txtsumtotalactive.Text.Trim())
                            {
                //MessageBox.Show("Qty Needed Match <3");
                pictureBox1.Visible = true;
            }
                            else
                            {
                                //MessageBox.Show("Item Quantity Not Match IN Our Needed!, Choose the exactly item Quantity Thanks! ");
                                ItemCodeValueNotmacthed();
                                txt1.Text = "";
                                txtBarcode.Text = "";
                                txtBarcode.Focus();
                           
                                return;
                            }



                            txt1.BackColor = Color.LightGreen;

                            groupBoxpack.Visible = true;
                            button1.Text = "Validated";
            //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
            ds.Clear();

            if(txt1.Text.Trim()==string.Empty)
            {

            }
            else
            {
                pictureBox1.Visible = false;
            }

            txtBarcode.Text = "";
            txtBarcode.Focus();
                       txtBarcode.Select();
            double sagot;
            double subjectquantity;

            subjectquantity = double.Parse(lblscannumber.Text);
            sagot = subjectquantity + 1;
            lblscannumber.Text = Convert.ToString(sagot);
            SuccessFullyValidated();
                 
                            //lblscannumber.Text = "2";
                      

                          




                  

                   





                      

                 

            


            
        }

        private void dgv1stView_CurrentCellChanged(object sender, EventArgs e)
        {
            showPreparation();

            //if (lblCounts.Text.Trim() == lbltotalread.Text.Trim())
            //{
            //    MessageBox.Show("Qty Needed Match Ready TO Save <3");
            //    BtnSave.Visible = true;

            //}

        }





        void showPreparation()
        {

            if (dgv1stView.RowCount > 0)
            {
                if (dgv1stView.CurrentRow != null)
                {
                    if (dgv1stView.CurrentRow.Cells["prod_id"].Value != null)
                    {
                        p_id = Convert.ToInt32(dgv1stView.CurrentRow.Cells["prod_id"].Value);

                        txtitemcode1.Text = dgv1stView.CurrentRow.Cells["item_code"].Value.ToString();
                        txtdescription1.Text = dgv1stView.CurrentRow.Cells["rp_description"].Value.ToString();
                        txtbatch1.Text = dgv1stView.CurrentRow.Cells["p_nobatch"].Value.ToString();
                        txtqty1.Text = dgv1stView.CurrentRow.Cells["quantity"].Value.ToString();
                        label24.Text = dgv1stView.CurrentRow.Cells["rp_feed_type"].Value.ToString();
                        txtprodid.Text = dgv1stView.CurrentRow.Cells["prod_id"].Value.ToString();



                        //txtrecommendedsearch.Text = dgvMaster.CurrentRow.Cells["item_code"].Value.ToString();
                        //txtqtyoverall.Text = dgvMaster.CurrentRow.Cells["qty_repack_available"].Value.ToString();
                        //txtmainstocks.Text = dgvMaster.CurrentRow.Cells["total_quantity_raw"].Value.ToString();

                        //cboCategor.Text = dgvMaster.CurrentRow.Cells["item_description"].Value.ToString();






                        //wala muna this


                    }

                }
            }

        }

        private void txtqty1_TextChanged(object sender, EventArgs e)
        {
            try
            {


                txtqtybacth.Text = (float.Parse(txtqty1.Text) * 1).ToString();
            }
            catch (Exception)
            {


            }
        }

        private void txtsumtotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtqtybacth_TextChanged(object sender, EventArgs e)
        {
            try
            {


                txtsumtotal.Text = (float.Parse(txtqtybacth.Text) * float.Parse(txtbatch1.Text)).ToString();
            }
            catch (Exception)
            {


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            doSearch();
            //search();
            txtcode2.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
            txttotalrepack2.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

            //txt1.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();








            if (txtitemcode2.Text.Trim() == txtcode2.Text.Trim())
            {
                //MessageBox.Show("Proceed Match Code");

            }
            else
            {

                //ItemCodeNotMatched();
                txt2.Text = "";



                txtBarcode.Text = "";
                txtBarcode.Focus();
                txtBarcode.Text = "";

                return;

            }


            txt2.Text = dgvrepackdb.CurrentRow.Cells["string_id"].Value.ToString();

            if (txttotalrepack2.Text.Trim() == txtsumtotal2.Text.Trim())
            {
                //MessageBox.Show("Qty Needed Match <3");
                pictureBox2.Visible = true;
            }
            else
            {
                //MessageBox.Show("Item Quantity Not Match IN Our Needed!, Choose the exactly item Quantity Thanks! ");
                ItemCodeValueNotmacthed();
                txt2.Text = "";
                txtBarcode.Text = "";
                txtBarcode.Focus();

                return;
            }



            txt2.BackColor = Color.LightGreen;

            groupBoxpack.Visible = true;
            button2.Text = "Validated";
            //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
            ds.Clear();

            if (txt2.Text.Trim() == string.Empty)
            {

            }
            else
            {
                pictureBox2.Visible = false;
            }



            double sagot;
            double subjectquantity;

            subjectquantity = double.Parse(lblscannumber.Text);
            sagot = subjectquantity + 1;
            lblscannumber.Text = Convert.ToString(sagot);
            SuccessFullyValidated();

            txtBarcode.Text = "";
            txtBarcode.Focus();
            txtBarcode.Select();

         












            if(txt1.Text.Trim()==string.Empty)
            {
                txttotalrepack1.Text = "";
            }










        }

        private void dgv1stView_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            //showPreparation();
        }

        private void dgv1stView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                int row = dgv1stView.CurrentRow.Index;
                int col = dgv1stView.CurrentCell.ColumnIndex;
            }
        }

        private void dgv1stView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtitemcode1.Text = dgv1stView.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtitemcode2.Text = dgv1stView.Rows[e.RowIndex].Cells[3].Value.ToString();
            //txtSubItemCode.Text = dgv_table_2nd_sup.Rows[e.RowIndex].Cells[2].Value.ToString();
            //txtSubQty.Text = dgv_table_2nd_sup.Rows[e.RowIndex].Cells[4].Value.ToString();
            //txtSubDateReceived.Text = dgv_table_2nd_sup.Rows[e.RowIndex].Cells[6].Value.ToString();
            //txtSubexpired.Text = dgv_table_2nd_sup.Rows[e.RowIndex].Cells[7].Value.ToString();

            //txtItemDescription.Text = dgv_table_2nd_sup.Rows[e.RowIndex].Cells[6].Value.ToString();
            //txtMainSupplier.Text = dgv_table_2nd_sup.Rows[e.RowIndex].Cells[3].Value.ToString();

            //txtID.Text = dgv_table_2nd_sup.Rows[e.RowIndex].Cells[0].Value.ToString();
            //txtItemCode.Text = dgv_table_2nd_sup.Rows[e.RowIndex].Cells[2].Value.ToString();
            //txtexpected.Text = dgv_table_2nd_sup.Rows[e.RowIndex].Cells[7].Value.ToString();




        }

        private void btn323_Click(object sender, EventArgs e)
        {
            if (dgv1stView.Rows.Count >= 1)
            {
                int i = dgv1stView.CurrentRow.Index + 1;
                if (i >= -1 && i < dgv1stView.Rows.Count)
                    dgv1stView.CurrentCell = dgv1stView.Rows[i].Cells[0];
            }
        }

        private void txtqtybactchactive_TextChanged(object sender, EventArgs e)
        {
            try
            {


                txtsumtotalactive.Text = (float.Parse(txtqtyactive.Text) * float.Parse(txtbatchactive.Text)).ToString("#,0.000");
            }
            catch (Exception)
            {


            }
        }

        private void txtqtyactive_TextChanged(object sender, EventArgs e)
        {
            try
            {


                txtqtybactchactive.Text = (float.Parse(txtqtyactive.Text) * 1).ToString();
            }
            catch (Exception)
            {


            }
        }

        private void txtqty2_TextChanged(object sender, EventArgs e)
        {


            try
            {


                txtbatchtwo.Text = (float.Parse(txtqty2.Text) * 1).ToString("#,0.000");
            }
            catch (Exception)
            {


            }



            //try
            //{


            //    txttotalrepack2.Text = (float.Parse(txttotalrepack2.Text) * 1).ToString("#,0.000");
            //}
            //catch (Exception)
            //{


            //}
        }

        private void txtbatchtwo_TextChanged(object sender, EventArgs e)
        {
            try
            {


                txtsumtotal2.Text = (float.Parse(txtqty2.Text) * 1).ToString("#,0.000");
            }
            catch (Exception)
            {


            }
        }

        private void txtqty3_TextChanged(object sender, EventArgs e)
        {
            try
            {


                txtqtybatch3.Text = (float.Parse(txtqty3.Text) * 1).ToString("#,0.000");
            }
            catch (Exception)
            {


            }
        }

        private void txtqtybatch3_TextChanged(object sender, EventArgs e)
        {
            try
            {

                //txtsumtotal3.Text = (float.Parse(txtqty3.Text) * float.Parse(txtbatch3.Text)).ToString("#,0.000");
                txtsumtotal3.Text = (float.Parse(txtqty3.Text) * 1).ToString("#,0.000");
            }
            catch (Exception)
            {


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            doSearch();

            //search();
            txtcode3.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
            txttotalrepack3.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

            //txt1.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();








            if (txtitemcode3.Text.Trim() == txtcode3.Text.Trim())
            {
                //MessageBox.Show("Proceed Match Code");

            }
            else
            {

                //ItemCodeNotMatched();
                txt3.Text = "";
         
                txtBarcode.Focus();
                txtBarcode.Text = "";

                return;

            }


            txt3.Text = dgvrepackdb.CurrentRow.Cells["string_id"].Value.ToString();

            if (txttotalrepack3.Text.Trim() == txtsumtotal3.Text.Trim())
            {
                //MessageBox.Show("Qty Needed Match <3");
                pictureBox3.Visible = true;
            }
            else
            {
                //MessageBox.Show("Item Quantity Not Match IN Our Needed!, Choose the exactly item Quantity Thanks! ");
                ItemCodeValueNotmacthed();
                txt3.Text = "";
                txtBarcode.Text = "";
                txtBarcode.Focus();

                return;
            }



            txt3.BackColor = Color.LightGreen;
   
            groupBoxpack.Visible = true;
            button3.Text = "Validated";
            //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
            ds.Clear();
            txtBarcode.Text = "";
            txtBarcode.Focus();
            txtBarcode.Select();

      if(txt3.Text.Trim()==string.Empty)
            {

            }
      else
            {
                pictureBox3.Visible = false;
            }

            double sagot;
            double subjectquantity;

            subjectquantity = double.Parse(lblscannumber.Text);
            sagot = subjectquantity + 1;
            lblscannumber.Text = Convert.ToString(sagot);
            SuccessFullyValidated();


















        }

        private void txtqty4_TextChanged(object sender, EventArgs e)
        {
            try
            {


                txtqtybatch4.Text = (float.Parse(txtqty4.Text) * 1).ToString("#,0.000");
            }
            catch (Exception)
            {


            }
        }

        private void txtqtybatch4_TextChanged(object sender, EventArgs e)
        {
            try
            {


                txtsumtotal4.Text = (float.Parse(txtqty4.Text) * 1).ToString("#,0.000");
            }
            catch (Exception)
            {


            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            doSearch();

            //search();
            txtcode4.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
            txttotalrepack4.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

            //txt1.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();








            if (txtitemcode4.Text.Trim() == txtcode4.Text.Trim())
            {
                //MessageBox.Show("Proceed Match Code");

            }
            else
            {

                //ItemCodeNotMatched();
                txt4.Text = "";

                txtBarcode.Focus();
                txtBarcode.Text = "";

                return;

            }


            txt4.Text = dgvrepackdb.CurrentRow.Cells["string_id"].Value.ToString();

            if (txttotalrepack4.Text.Trim() == txtsumtotal4.Text.Trim())
            {
                //MessageBox.Show("Qty Needed Match <3");

            }
            else
            {
                //MessageBox.Show("Item Quantity Not Match IN Our Needed!, Choose the exactly item Quantity Thanks! ");
                ItemCodeValueNotmacthed();
                txt4.Text = "";
                txtBarcode.Text = "";
                txtBarcode.Focus();

                return;
            }



            txt4.BackColor = Color.LightGreen;
            //pictureBox4.Visible = true;
            groupBoxpack.Visible = true;
            button4.Text = "Validated";
            //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
            ds.Clear();
            txtBarcode.Text = "";
            txtBarcode.Focus();
            txtBarcode.Select();


            double sagot;
            double subjectquantity;

            subjectquantity = double.Parse(lblscannumber.Text);
            sagot = subjectquantity + 1;
            lblscannumber.Text = Convert.ToString(sagot);
            SuccessFullyValidated();





        }

        private void label61_Click(object sender, EventArgs e)
        {

        }

        private void textBox26_TextChanged(object sender, EventArgs e)
        {
            try
            {


                txtqtybatch7.Text = (float.Parse(txtqty7.Text) * 1).ToString("#,0.000");
            }
            catch (Exception)
            {


            }
        }

        private void button7_Click(object sender, EventArgs e)
        {


            doSearch();

            //search();
            txtcode7.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
            txttotalrepack7.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

            //txt1.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();








            if (txtitemcode7.Text.Trim() == txtcode7.Text.Trim())
            {
                //MessageBox.Show("Proceed Match Code");

            }
            else
            {

                //ItemCodeNotMatched();
                txt7.Text = "";

                txtBarcode.Focus();
                txtBarcode.Text = "";

                return;

            }


            txt7.Text = dgvrepackdb.CurrentRow.Cells["string_id"].Value.ToString();

            if (txttotalrepack7.Text.Trim() == txtsumtotal7.Text.Trim())
            {
                //MessageBox.Show("Qty Needed Match <3");

            }
            else
            {
                //MessageBox.Show("Item Quantity Not Match IN Our Needed!, Choose the exactly item Quantity Thanks! ");
                ItemCodeValueNotmacthed();
                txt7.Text = "";
                txtBarcode.Text = "";
                txtBarcode.Focus();

                return;
            }



            txt7.BackColor = Color.LightGreen;
            //pictureBox7.Visible = true;
            groupBoxpack.Visible = true;
            button7.Text = "Validated";
            ds.Clear();
            txtBarcode.Text = "";
            txtBarcode.Focus();
            txtBarcode.Select();


            double sagot;
            double subjectquantity;

            subjectquantity = double.Parse(lblscannumber.Text);
            sagot = subjectquantity + 1;
            lblscannumber.Text = Convert.ToString(sagot);
            SuccessFullyValidated();

        }

        private void label55_Click(object sender, EventArgs e)
        {

        }

        private void label56_Click(object sender, EventArgs e)
        {

        }

        private void textBox27_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox28_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox29_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox30_TextChanged(object sender, EventArgs e)
        {
            try
            {


                txtsumtotal7.Text = (float.Parse(txtqty7.Text) * 1).ToString("#,0.000");
            }
            catch (Exception)
            {


            }
        }

        private void textBox31_TextChanged(object sender, EventArgs e)
        {

        }

        private void label57_Click(object sender, EventArgs e)
        {

        }

        private void label58_Click(object sender, EventArgs e)
        {

        }

        private void label59_Click(object sender, EventArgs e)
        {

        }

        private void textBox33_TextChanged(object sender, EventArgs e)
        {

        }

        private void label60_Click(object sender, EventArgs e)
        {

        }

        private void textBox34_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void txtqty5_TextChanged(object sender, EventArgs e)
        {
            try
            {


                txtqtybatch5.Text = (float.Parse(txtqty5.Text) * 1).ToString("#,0.000");
            }
            catch (Exception)
            {


            }
        }

        private void txtqtybatch5_TextChanged(object sender, EventArgs e)
        {
            try
            {


                txtsumtotal5.Text = (float.Parse(txtqty5.Text) * 1).ToString("#,0.000");
            }
            catch (Exception)
            {


            }
        }

        private void button5_Click(object sender, EventArgs e)
        {


            doSearch();

            //search();
            txtcode5.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
            txttotalrepack5.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

            //txt1.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();








            if (txtitemcode5.Text.Trim() == txtcode5.Text.Trim())
            {
                //MessageBox.Show("Proceed Match Code");

            }
            else
            {

                //ItemCodeNotMatched();
                txt5.Text = "";

                txtBarcode.Focus();
                txtBarcode.Text = "";

                return;

            }


            txt5.Text = dgvrepackdb.CurrentRow.Cells["string_id"].Value.ToString();

            if (txttotalrepack5.Text.Trim() == txtsumtotal5.Text.Trim())
            {
                //MessageBox.Show("Qty Needed Match <3");

            }
            else
            {
                //MessageBox.Show("Item Quantity Not Match IN Our Needed!, Choose the exactly item Quantity Thanks! ");
                ItemCodeValueNotmacthed();
                txt5.Text = "";
                txtBarcode.Text = "";
                txtBarcode.Focus();

                return;
            }



            txt5.BackColor = Color.LightGreen;
            //pictureBox5.Visible = true;
            groupBoxpack.Visible = true;
            button5.Text = "Validated";
            ds.Clear();
            txtBarcode.Text = "";
            txtBarcode.Focus();
            txtBarcode.Select();


            double sagot;
            double subjectquantity;

            subjectquantity = double.Parse(lblscannumber.Text);
            sagot = subjectquantity + 1;
            lblscannumber.Text = Convert.ToString(sagot);
            SuccessFullyValidated();


        }

        private void txtqty6_TextChanged(object sender, EventArgs e)
        {
            try
            {


                txtqtybatch6.Text = (float.Parse(txtqty6.Text) * 1).ToString("#,0.000");
            }
            catch (Exception)
            {


            }
        }

        private void txtqtybatch6_TextChanged(object sender, EventArgs e)
        {
            try
            {


                txtsumtotal6.Text = (float.Parse(txtqty6.Text) * 1).ToString("#,0.000");
            }
            catch (Exception)
            {


            }
        }

        private void button6_Click(object sender, EventArgs e)
        {


            doSearch();

            //search();
            txtcode6.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
            txttotalrepack6.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

            //txt1.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();








            if (txtitemcode6.Text.Trim() == txtcode6.Text.Trim())
            {
                //MessageBox.Show("Proceed Match Code");

            }
            else
            {

                //ItemCodeNotMatched();
                txt6.Text = "";

                txtBarcode.Focus();
                txtBarcode.Text = "";

                return;

            }


            txt6.Text = dgvrepackdb.CurrentRow.Cells["string_id"].Value.ToString();

            if (txttotalrepack6.Text.Trim() == txtsumtotal6.Text.Trim())
            {
                //MessageBox.Show("Qty Needed Match <3");

            }
            else
            {
                //MessageBox.Show("Item Quantity Not Match IN Our Needed!, Choose the exactly item Quantity Thanks! ");
                ItemCodeValueNotmacthed();
                txt6.Text = "";
                txtBarcode.Text = "";
                txtBarcode.Focus();

                return;
            }



            txt6.BackColor = Color.LightGreen;
            //pictureBox6.Visible = true;
            groupBoxpack.Visible = true;
            button6.Text = "Validated";
            ds.Clear();
            txtBarcode.Text = "";
            txtBarcode.Focus();
            txtBarcode.Select();


            double sagot;
            double subjectquantity;

            subjectquantity = double.Parse(lblscannumber.Text);
            sagot = subjectquantity + 1;
            lblscannumber.Text = Convert.ToString(sagot);
            SuccessFullyValidated();



        }

        private void txtqty8_TextChanged(object sender, EventArgs e)
        {
            try
            {


                txtqtybatch8.Text = (float.Parse(txtqty8.Text) * 1).ToString("#,0.000");
            }
            catch (Exception)
            {


            }
        }

        private void txtqtybatch8_TextChanged(object sender, EventArgs e)
        {
            try
            {


                txtsumtotal8.Text = (float.Parse(txtqty8.Text) * 1).ToString("#,0.000");
            }
            catch (Exception)
            {


            }
        }

        private void button8_Click(object sender, EventArgs e)
        {


            doSearch();

            //search();
            txtcode8.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
            txttotalrepack8.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

            //txt1.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();








            if (txtitemcode8.Text.Trim() == txtcode8.Text.Trim())
            {
                //MessageBox.Show("Proceed Match Code");

            }
            else
            {

                //ItemCodeNotMatched();
                txt8.Text = "";

                txtBarcode.Focus();
                txtBarcode.Text = "";

                return;

            }


            txt8.Text = dgvrepackdb.CurrentRow.Cells["string_id"].Value.ToString();

            if (txttotalrepack8.Text.Trim() == txtsumtotal8.Text.Trim())
            {
                //MessageBox.Show("Qty Needed Match <3");

            }
            else
            {
                //MessageBox.Show("Item Quantity Not Match IN Our Needed!, Choose the exactly item Quantity Thanks! ");
                ItemCodeValueNotmacthed();
                txt8.Text = "";
                txtBarcode.Text = "";
                txtBarcode.Focus();

                return;
            }



            txt8.BackColor = Color.LightGreen;
            //pictureBox8.Visible = true;
            groupBoxpack.Visible = true;
            button8.Text = "Validated";
            ////MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
            //txtBarcode.Focus();
            //txtBarcode.Select();
            //SuccessFullyValidated();


            //ds.Clear();
            //txtBarcode.Text = "";
            ds.Clear();
            txtBarcode.Text = "";
            txtBarcode.Focus();
            txtBarcode.Select();


            double sagot;
            double subjectquantity;

            subjectquantity = double.Parse(lblscannumber.Text);
            sagot = subjectquantity + 1;
            lblscannumber.Text = Convert.ToString(sagot);
            SuccessFullyValidated();





        }

        private void txtqty9_TextChanged(object sender, EventArgs e)
        {
            try
            {


                txtqtybatch9.Text = (float.Parse(txtqty9.Text) * 1).ToString("#,0.000");
            }
            catch (Exception)
            {


            }
        }

        private void txtqtybatch9_TextChanged(object sender, EventArgs e)
        {
            try
            {


                txtsumtotal9.Text = (float.Parse(txtqty9.Text) * 1).ToString("#,0.000");
            }
            catch (Exception)
            {


            }
        }

        private void button9_Click(object sender, EventArgs e)
        {


            doSearch();

            //search();
            txtcode9.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
            txttotalrepack9.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

            //txt1.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();








            if (txtitemcode9.Text.Trim() == txtcode9.Text.Trim())
            {
                //MessageBox.Show("Proceed Match Code");

            }
            else
            {

                //ItemCodeNotMatched();
                txt9.Text = "";

                txtBarcode.Focus();
                txtBarcode.Text = "";

                return;

            }


            txt9.Text = dgvrepackdb.CurrentRow.Cells["string_id"].Value.ToString();

            if (txttotalrepack9.Text.Trim() == txtsumtotal9.Text.Trim())
            {
                //MessageBox.Show("Qty Needed Match <3");

            }
            else
            {
                //MessageBox.Show("Item Quantity Not Match IN Our Needed!, Choose the exactly item Quantity Thanks! ");
                ItemCodeValueNotmacthed();
                txt9.Text = "";
                txtBarcode.Text = "";
                txtBarcode.Focus();

                return;
            }



            txt9.BackColor = Color.LightGreen;
            //pictureBox9.Visible = true;
            groupBoxpack.Visible = true;
            button9.Text = "Validated";
            ////MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
            //txtBarcode.Focus();
            //txtBarcode.Select();
            //SuccessFullyValidated();


            //ds.Clear();
            //txtBarcode.Text = "";
            ds.Clear();
            txtBarcode.Text = "";
            txtBarcode.Focus();
            txtBarcode.Select();


            double sagot;
            double subjectquantity;

            subjectquantity = double.Parse(lblscannumber.Text);
            sagot = subjectquantity + 1;
            lblscannumber.Text = Convert.ToString(sagot);
            SuccessFullyValidated();

        }

        private void txtqty10_TextChanged(object sender, EventArgs e)
        {
            try
            {


                txtqtybatch10.Text = (float.Parse(txtqty10.Text) * 1).ToString("#,0.000");
            }
            catch (Exception)
            {


            }
        }

        private void txtqtybatch10_TextChanged(object sender, EventArgs e)
        {
            try
            {


                txtsumtotal10.Text = (float.Parse(txtqty10.Text) * 1).ToString("#,0.000");
            }
            catch (Exception)
            {


            }
        }

        private void button10_Click(object sender, EventArgs e)
        {


            doSearch();

            //search();
            txtcode10.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
            txttotalrepack10.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

            //txt1.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();








            if (txtitemcode10.Text.Trim() == txtcode10.Text.Trim())
            {
                //MessageBox.Show("Proceed Match Code");

            }
            else
            {

                //ItemCodeNotMatched();
                txt10.Text = "";

                txtBarcode.Focus();
                txtBarcode.Text = "";

                return;

            }


            txt10.Text = dgvrepackdb.CurrentRow.Cells["string_id"].Value.ToString();

            if (txttotalrepack10.Text.Trim() == txtsumtotal10.Text.Trim())
            {
                //MessageBox.Show("Qty Needed Match <3");

            }
            else
            {
                //MessageBox.Show("Item Quantity Not Match IN Our Needed!, Choose the exactly item Quantity Thanks! ");
                ItemCodeValueNotmacthed();
                txt10.Text = "";
                txtBarcode.Text = "";
                txtBarcode.Focus();

                return;
            }



            txt10.BackColor = Color.LightGreen;
            //pictureBox10.Visible = true;
            groupBoxpack.Visible = true;
            button10.Text = "Validated";
            ds.Clear();
            txtBarcode.Text = "";
            txtBarcode.Focus();
            txtBarcode.Select();


            double sagot;
            double subjectquantity;

            subjectquantity = double.Parse(lblscannumber.Text);
            sagot = subjectquantity + 1;
            lblscannumber.Text = Convert.ToString(sagot);
            SuccessFullyValidated();

        }

        private void txtqty11_TextChanged(object sender, EventArgs e)
        {
            try
            {


                txtqtybatch11.Text = (float.Parse(txtqty11.Text) * 1).ToString("#,0.000");
            }
            catch (Exception)
            {


            }
        }

        private void txtqtybatch11_TextChanged(object sender, EventArgs e)
        {
            try
            {


                txtsumtotal11.Text = (float.Parse(txtqty11.Text) * 1).ToString("#,0.000");
            }
            catch (Exception)
            {


            }
        }

        private void txtitemcode11_TextChanged(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

            doSearch();

            //search();
            txtcode11.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
            txttotalrepack11.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

            //txt1.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();








            if (txtitemcode11.Text.Trim() == txtcode11.Text.Trim())
            {
                //MessageBox.Show("Proceed Match Code");

            }
            else
            {

                //ItemCodeNotMatched();
                txt11.Text = "";

                txtBarcode.Focus();
                txtBarcode.Text = "";

                return;

            }


            txt11.Text = dgvrepackdb.CurrentRow.Cells["string_id"].Value.ToString();

            if (txttotalrepack11.Text.Trim() == txtsumtotal11.Text.Trim())
            {
                //MessageBox.Show("Qty Needed Match <3");

            }
            else
            {
                //MessageBox.Show("Item Quantity Not Match IN Our Needed!, Choose the exactly item Quantity Thanks! ");
                ItemCodeValueNotmacthed();
                txt11.Text = "";
                txtBarcode.Text = "";
                txtBarcode.Focus();

                return;
            }



            txt11.BackColor = Color.LightGreen;
            //pictureBox11.Visible = true;
            groupBoxpack.Visible = true;
            button11.Text = "Validated";
            ds.Clear();
            txtBarcode.Text = "";
            txtBarcode.Focus();
            txtBarcode.Select();


            double sagot;
            double subjectquantity;

            subjectquantity = double.Parse(lblscannumber.Text);
            sagot = subjectquantity + 1;
            lblscannumber.Text = Convert.ToString(sagot);
            SuccessFullyValidated();

        }

        private void txtqty12_TextChanged(object sender, EventArgs e)
        {
            try
            {


                txtqtybatch12.Text = (float.Parse(txtqty12.Text) * 1).ToString("#,0.000");
            }
            catch (Exception)
            {


            }
        }

        private void txtqtybatch12_TextChanged(object sender, EventArgs e)
        {
            try
            {


                txtsumtotal12.Text = (float.Parse(txtqty12.Text) * 1).ToString("#,0.000");
            }
            catch (Exception)
            {


            }
        }

        private void button12_Click(object sender, EventArgs e)
        {


            doSearch();

            //search();
            txtcode12.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
            txttotalrepack12.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

            //txt1.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();








            if (txtitemcode12.Text.Trim() == txtcode12.Text.Trim())
            {
                //MessageBox.Show("Proceed Match Code");

            }
            else
            {

                //ItemCodeNotMatched();
                txt12.Text = "";

                txtBarcode.Focus();
                txtBarcode.Text = "";

                return;

            }


            txt12.Text = dgvrepackdb.CurrentRow.Cells["string_id"].Value.ToString();

            if (txttotalrepack12.Text.Trim() == txtsumtotal12.Text.Trim())
            {
                //MessageBox.Show("Qty Needed Match <3");

            }
            else
            {
                //MessageBox.Show("Item Quantity Not Match IN Our Needed!, Choose the exactly item Quantity Thanks! ");
                ItemCodeValueNotmacthed();
                txt12.Text = "";
                txtBarcode.Text = "";
                txtBarcode.Focus();

                return;
            }



            txt12.BackColor = Color.LightGreen;
            //pictureBox12.Visible = true;
            groupBoxpack.Visible = true;
            button12.Text = "Validated";
            ds.Clear();
            txtBarcode.Text = "";
            txtBarcode.Focus();
            txtBarcode.Select();


            double sagot;
            double subjectquantity;

            subjectquantity = double.Parse(lblscannumber.Text);
            sagot = subjectquantity + 1;
            lblscannumber.Text = Convert.ToString(sagot);
            SuccessFullyValidated();


        }

        private void txtqty13_TextChanged(object sender, EventArgs e)
        {
            try
            {


                txtqtybatch13.Text = (float.Parse(txtqty13.Text) * 1).ToString("#,0.000");
            }
            catch (Exception)
            {


            }
        }

        private void txtqtybatch13_TextChanged(object sender, EventArgs e)
        {
            try
            {


                txtsumtotal13.Text = (float.Parse(txtqty13.Text) * 1).ToString("#,0.000");
            }
            catch (Exception)
            {


            }
        }

        private void button13_Click(object sender, EventArgs e)
        {


            doSearch();

            //search();
            txtcode13.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
            txttotalrepack13.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

            //txt1.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();








            if (txtitemcode13.Text.Trim() == txtcode13.Text.Trim())
            {
                //MessageBox.Show("Proceed Match Code");

            }
            else
            {

                //ItemCodeNotMatched();
                txt13.Text = "";

                txtBarcode.Focus();
                txtBarcode.Text = "";

                return;

            }


            txt13.Text = dgvrepackdb.CurrentRow.Cells["string_id"].Value.ToString();

            if (txttotalrepack13.Text.Trim() == txtsumtotal13.Text.Trim())
            {
                //MessageBox.Show("Qty Needed Match <3");

            }
            else
            {
                //MessageBox.Show("Item Quantity Not Match IN Our Needed!, Choose the exactly item Quantity Thanks! ");
                ItemCodeValueNotmacthed();
                txt13.Text = "";
                txtBarcode.Text = "";
                txtBarcode.Focus();

                return;
            }



            txt13.BackColor = Color.LightGreen;
            //pictureBox13.Visible = true;
            groupBoxpack.Visible = true;
            button13.Text = "Validated";
            ds.Clear();
            txtBarcode.Text = "";
            txtBarcode.Focus();
            txtBarcode.Select();


            double sagot;
            double subjectquantity;

            subjectquantity = double.Parse(lblscannumber.Text);
            sagot = subjectquantity + 1;
            lblscannumber.Text = Convert.ToString(sagot);
            SuccessFullyValidated();

        }



        private void txtqty14_TextChanged(object sender, EventArgs e)
        {
            try
            {


                txtqtybatch14.Text = (float.Parse(txtqty14.Text) * 1).ToString("#,0.000");
            }
            catch (Exception)
            {


            }
        }

        private void txtqtybatch14_TextChanged(object sender, EventArgs e)
        {
            try
            {


                txtsumtotal14.Text = (float.Parse(txtqty14.Text) * 1).ToString("#,0.000");
            }
            catch (Exception)
            {


            }
        }

        private void button14_Click(object sender, EventArgs e)
        {

            doSearch();

            //search();
            txtcode14.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
            txttotalrepack14.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

            //txt1.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();








            if (txtitemcode14.Text.Trim() == txtcode14.Text.Trim())
            {
                //MessageBox.Show("Proceed Match Code");

            }
            else
            {

                //ItemCodeNotMatched();
                txt14.Text = "";

                txtBarcode.Focus();
                txtBarcode.Text = "";

                return;

            }


            txt14.Text = dgvrepackdb.CurrentRow.Cells["string_id"].Value.ToString();

            if (txttotalrepack14.Text.Trim() == txtsumtotal14.Text.Trim())
            {
                //MessageBox.Show("Qty Needed Match <3");

            }
            else
            {
                //MessageBox.Show("Item Quantity Not Match IN Our Needed!, Choose the exactly item Quantity Thanks! ");
                ItemCodeValueNotmacthed();
                txt14.Text = "";
                txtBarcode.Text = "";
                txtBarcode.Focus();

                return;
            }



            txt14.BackColor = Color.LightGreen;
            //pictureBox14.Visible = true;
            groupBoxpack.Visible = true;
            button14.Text = "Validated";
            ds.Clear();
            txtBarcode.Text = "";
            txtBarcode.Focus();
            txtBarcode.Select();


            double sagot;
            double subjectquantity;

            subjectquantity = double.Parse(lblscannumber.Text);
            sagot = subjectquantity + 1;
            lblscannumber.Text = Convert.ToString(sagot);
            SuccessFullyValidated();

        }

        private void txtqty15_TextChanged(object sender, EventArgs e)
        {
            try
            {


                txtqtybatch15.Text = (float.Parse(txtqty15.Text) * 1).ToString("#,0.000");
            }
            catch (Exception)
            {


            }
        }

        private void txtqtybatch15_TextChanged(object sender, EventArgs e)
        {
            try
            {


                txtsumtotal15.Text = (float.Parse(txtqty15.Text) * 1).ToString("#,0.000");
            }
            catch (Exception)
            {


            }
        }

        private void button15_Click(object sender, EventArgs e)
        {


            doSearch();

            //search();
            txtcode15.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
            txttotalrepack15.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

            //txt1.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();








            if (txtitemcode15.Text.Trim() == txtcode15.Text.Trim())
            {
                //MessageBox.Show("Proceed Match Code");

            }
            else
            {

                //ItemCodeNotMatched();
                txt15.Text = "";

                txtBarcode.Focus();
                txtBarcode.Text = "";

                return;

            }


            txt15.Text = dgvrepackdb.CurrentRow.Cells["string_id"].Value.ToString();

            if (txttotalrepack15.Text.Trim() == txtsumtotal15.Text.Trim())
            {
                //MessageBox.Show("Qty Needed Match <3");

            }
            else
            {
                //MessageBox.Show("Item Quantity Not Match IN Our Needed!, Choose the exactly item Quantity Thanks! ");
                ItemCodeValueNotmacthed();
                txt15.Text = "";
                txtBarcode.Text = "";
                txtBarcode.Focus();

                return;
            }



            txt15.BackColor = Color.LightGreen;
            //pictureBox15.Visible = true;
            groupBoxpack.Visible = true;
            button15.Text = "Validated";
            ds.Clear();
            txtBarcode.Text = "";
            txtBarcode.Focus();
            txtBarcode.Select();


            double sagot;
            double subjectquantity;

            subjectquantity = double.Parse(lblscannumber.Text);
            sagot = subjectquantity + 1;
            lblscannumber.Text = Convert.ToString(sagot);
            SuccessFullyValidated();

        }


        private void txtqty16_TextChanged(object sender, EventArgs e)
        {
            try
            {


                txtqtybatch16.Text = (float.Parse(txtqty16.Text) * 1).ToString("#,0.000");
            }
            catch (Exception)
            {


            }
        }

        private void txtqtybatch16_TextChanged(object sender, EventArgs e)
        {
            try
            {


                txtsumtotal16.Text = (float.Parse(txtqty16.Text) * 1).ToString("#,0.000");
            }
            catch (Exception)
            {


            }
        }

        private void button16_Click(object sender, EventArgs e)
        {


            doSearch();

            //search();
            txtcode16.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
            txttotalrepack16.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

            //txt1.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();








            if (txtitemcode16.Text.Trim() == txtcode16.Text.Trim())
            {
                //MessageBox.Show("Proceed Match Code");

            }
            else
            {

                //ItemCodeNotMatched();
                txt16.Text = "";

                txtBarcode.Focus();
                txtBarcode.Text = "";

                return;

            }


            txt16.Text = dgvrepackdb.CurrentRow.Cells["string_id"].Value.ToString();

            if (txttotalrepack16.Text.Trim() == txtsumtotal16.Text.Trim())
            {
                //MessageBox.Show("Qty Needed Match <3");

            }
            else
            {
                //MessageBox.Show("Item Quantity Not Match IN Our Needed!, Choose the exactly item Quantity Thanks! ");
                ItemCodeValueNotmacthed();
                txt16.Text = "";
                txtBarcode.Text = "";
                txtBarcode.Focus();

                return;
            }



            txt16.BackColor = Color.LightGreen;
            //pictureBox16.Visible = true;
            groupBoxpack.Visible = true;
            button16.Text = "Validated";
            ds.Clear();
            txtBarcode.Text = "";
            txtBarcode.Focus();
            txtBarcode.Select();


            double sagot;
            double subjectquantity;

            subjectquantity = double.Parse(lblscannumber.Text);
            sagot = subjectquantity + 1;
            lblscannumber.Text = Convert.ToString(sagot);
            SuccessFullyValidated();

        }

        private void button17_Click(object sender, EventArgs e)
        {

            doSearch();

            //search();
            txtcode17.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
            txttotalrepack17.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

            //txt1.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();








            if (txtitemcode17.Text.Trim() == txtcode17.Text.Trim())
            {
                //MessageBox.Show("Proceed Match Code");

            }
            else
            {

                //ItemCodeNotMatched();
                txt17.Text = "";

                txtBarcode.Focus();
                txtBarcode.Text = "";

                return;

            }


            txt17.Text = dgvrepackdb.CurrentRow.Cells["string_id"].Value.ToString();

            if (txttotalrepack17.Text.Trim() == txtsumtotal17.Text.Trim())
            {
                //MessageBox.Show("Qty Needed Match <3");
                pictureBox17.Visible = true;
            }
            else
            {
                //MessageBox.Show("Item Quantity Not Match IN Our Needed!, Choose the exactly item Quantity Thanks! ");
                ItemCodeValueNotmacthed();
                txt17.Text = "";
                txtBarcode.Text = "";
                txtBarcode.Focus();

                return;
            }
            if (txt17.Text.Trim() == string.Empty)
            {
       
            }
            else
            {
     
                pictureBox17.Visible = false;
            }


            txt17.BackColor = Color.LightGreen;
            //pictureBox17.Visible = true;
            groupBoxpack.Visible = true;
            button17.Text = "Validated";
            //MessageBox.Show("NEXT !", dgv1stView.Rows[i].Cells[5].Value.ToString());
            ds.Clear();
            txtBarcode.Text = "";
            txtBarcode.Focus();
            txtBarcode.Select();


            double sagot;
            double subjectquantity;

            subjectquantity = double.Parse(lblscannumber.Text);
            sagot = subjectquantity + 1;
            lblscannumber.Text = Convert.ToString(sagot);
            SuccessFullyValidated();




        }




        private void txtqty17_TextChanged(object sender, EventArgs e)
        {
            try
            {


                txtqtybatch17.Text = (float.Parse(txtqty17.Text) * 1).ToString("#,0.000");
            }
            catch (Exception)
            {


            }
        }

        private void txtqtybatch17_TextChanged(object sender, EventArgs e)
        {
            try
            {


                txtsumtotal17.Text = (float.Parse(txtqty17.Text) * 1).ToString("#,0.000");
            }
            catch (Exception)
            {


            }
        }

        private void txt1_TextChanged(object sender, EventArgs e)
        {
            if (txt1.Text.Trim() == string.Empty)
            {
                btngreaterthan.Enabled = true;
                  btnlessthan.Enabled = true;
                //btngreaterthan.BackColor = Color.CornflowerBlue;
                //btnlessthan.BackColor = Color.CornflowerBlue;
                bunifuStart.Visible = true;
            }

            else
            {
                txt1.BackColor = Color.White;
            }

        }














        private void txt1_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);


            txtqtybactchactive.Text = dgv1stView.CurrentRow.Cells["quantity"].Value.ToString();
      
            //bunifuStart.BackColor = Color.DarkSeaGreen;
            dgvMaster.Enabled = false;
            bunifuStart.Visible = false;
            bunifuStopPreparation.Visible = true;
            dgv1stView.Enabled = false;
            btngreaterthan.BackColor = Color.LightGray;
            btnlessthan.BackColor = Color.LightGray;
            btngreaterthan.Enabled = false;
            btnlessthan.Enabled = false;
            //if (Convert.ToInt32(e.KeyChar) == 13)
            //{
            //    button1_Click(sender, e);
            //    txt1.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
            //}

        }


     


        private void txt1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }

        }

        private void dgvrepackdb_CurrentCellChanged(object sender, EventArgs e)
        {
            showRepackingChanged();
        }



        void showRepackingChanged()
        {

            if (dgvrepackdb.RowCount > 0)
            {
                if (dgvrepackdb.CurrentRow != null)
                {
                    if (dgvrepackdb.CurrentRow.Cells["repack_id"].Value != null)
                    {
                        p_id = Convert.ToInt32(dgvrepackdb.CurrentRow.Cells["repack_id"].Value);

                        //txt1.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString(); wla muna
                        txtcodeuna.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                        txtqtyuna.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();
                txtmyItemCode.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                       stringid.Text = dgvrepackdb.CurrentRow.Cells["string_id"].Value.ToString();
                        txtMyItemDescription.Text = dgvrepackdb.CurrentRow.Cells["rp_item_description"].Value.ToString();

                        txtFeedCodeRepack.Text = dgvrepackdb.CurrentRow.Cells["rp_feed_code"].Value.ToString();
                        //txtrecommendedsearch.Text = dgvMaster.CurrentRow.Cells["item_code"].Value.ToString();
                        //txtqtyoverall.Text = dgvMaster.CurrentRow.Cells["qty_repack_available"].Value.ToString();
                        //txtmainstocks.Text = dgvMaster.CurrentRow.Cells["total_quantity_raw"].Value.ToString();

                        //cboCategor.Text = dgvMaster.CurrentRow.Cells["item_description"].Value.ToString();






                        //wala muna this


                    }

                }
            }

        }

        private void txttotalrepack2_TextChanged(object sender, EventArgs e)
        {


        }

        private void txttotalrepack1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtqty2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //string s = (Convert.ToDouble(txt2.Text) / 100).ToString("0.00");
        }

        private void txt2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void txt3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                //button3_Click(sender, e);
            }
        }

        private void txt4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                //button4_Click(sender, e);
            }
        }

        private void txt5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            //if (Convert.ToInt32(e.KeyChar) == 13)
            //{
            //    button5_Click(sender, e);
            //}
        }

        private void txt2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2_Click(sender, e);
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox26_TextChanged_1(object sender, EventArgs e)
        {
            try
            {


                txtsumtotal18.Text = (float.Parse(txtqty18.Text) * 1).ToString("#,0.000");
            }
            catch (Exception)
            {


            }
        }

        private void lblCounts_Click(object sender, EventArgs e)
        {

        }

        private void txt17_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt17_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button17_Click(sender, e);
            }
        }

        private void txt11_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button11_Click(sender, e);
            }

        }

        private void txt11_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt14_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button14_Click(sender, e);
            }
        }

        private void txt14_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt13_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt13_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button13_Click(sender, e);
            }
        }

        private void txt12_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button12_Click(sender, e);
            }
        }

        private void txt12_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void txt10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void txt10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button10_Click(sender, e);
            }
        }

        private void txt9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button9_Click(sender, e);
            }
        }

        private void txt9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button5_Click(sender, e);
            }
        }

        private void txt6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button6_Click(sender, e);
            }
        }

        private void txt7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button7_Click(sender, e);
            }
        }

        private void txt7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void txt8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void txt8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button8_Click(sender, e);
            }
        }

        private void txt16_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button16_Click(sender, e);
            }
        }

        private void txt16_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void txt15_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button15_Click(sender, e);
            }
        }

        private void txt15_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void button20_Click(object sender, EventArgs e)
        {
            doSearch();

            //search();
            txtcode20.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
            txttotalrepack20.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

            //txt1.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();








            if (txtitemcode20.Text.Trim() == txtcode20.Text.Trim())
            {
                //MessageBox.Show("Proceed Match Code");

            }
            else
            {

                //ItemCodeNotMatched();
                txt20.Text = "";

                txtBarcode.Focus();
                txtBarcode.Text = "";

                return;

            }


            txt20.Text = dgvrepackdb.CurrentRow.Cells["string_id"].Value.ToString();

            if (txttotalrepack20.Text.Trim() == txtsumtotal20.Text.Trim())
            {
                //MessageBox.Show("Qty Needed Match <3");
                pictureBox20.Visible = true;
            }
            else
            {
                //MessageBox.Show("Item Quantity Not Match IN Our Needed!, Choose the exactly item Quantity Thanks! ");
                ItemCodeValueNotmacthed();
                txt20.Text = "";
                txtBarcode.Text = "";
                txtBarcode.Focus();

                return;
            }

            if(txt20.Text.Trim()==string.Empty)
            {

            }
            else
            {
                pictureBox20.Visible = false;
            }

            txt20.BackColor = Color.LightGreen;

            groupBoxpack.Visible = true;
            button20.Text = "Validated";
            ds.Clear();
            txtBarcode.Text = "";
            txtBarcode.Focus();
            txtBarcode.Select();


            double sagot;
            double subjectquantity;

            subjectquantity = double.Parse(lblscannumber.Text);
            sagot = subjectquantity + 1;
            lblscannumber.Text = Convert.ToString(sagot);
            SuccessFullyValidated();


        }

        private void BtnSave_Click(object sender, EventArgs e)
        {


            metroButton3_Click(sender, e);
          















        }






















        public bool saveMode()
        {

            if (mode == "add")
            {
                dSet.Clear();
                dSet = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text, txtmainfeedcode.Text, label24.Text, "", "", "", "", "", "", "", "","", "", "", "", "", "", "getbyname");

                if (dSet.Tables[0].Rows.Count > 0)
                {
                    //MessageBox.Show("Raw Material is already added bugokj.", "Raw Materials", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //txtMainInput.Focus();
                    //submit button that will be disabled 
          

                    //calling the dashboard counts
                    //buje
                    dSets = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text.Trim(), txtmainfeedcode.Text.Trim(), label24.Text.Trim(), txtitemcodeactive.Text.Trim(), txtdescriptionactive.Text.Trim(), txtbatchactive.Text.Trim(), txtqtybactchactive.Text.Trim(), txtsumtotalactive.Text.Trim(), txtcode1.Text.Trim(), txttotalrepack1.Text.Trim(), txt1.Text.Trim(), "1", "2", "1", txtdatenow.Text.Trim(), txtaddedby.Text.Trim(),"", "add");

                    dSets = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text.Trim(), txtmainfeedcode.Text.Trim(), label24.Text.Trim(), txtitemcode2.Text.Trim(), txtdescription2.Text.Trim(), txtbatch2.Text.Trim(), txtbatchtwo.Text.Trim(), txtsumtotal2.Text.Trim(), txtcode2.Text.Trim(), txttotalrepack2.Text.Trim(), txt2.Text.Trim(), "1", "2", "1", txtdatenow.Text.Trim(), txtaddedby.Text.Trim(),"", "add2");
                    dSets = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text.Trim(), txtmainfeedcode.Text.Trim(), label24.Text.Trim(), txtitemcode3.Text.Trim(), txtdescription3.Text.Trim(), txtbatch3.Text.Trim(), txtqtybatch3.Text.Trim(), txtsumtotal3.Text.Trim(), txtcode3.Text.Trim(), txttotalrepack3.Text.Trim(), txt3.Text.Trim(), "1", "2", "1", txtdatenow.Text.Trim(), txtaddedby.Text.Trim(),"", "add3");
                    dSets = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text.Trim(), txtmainfeedcode.Text.Trim(), label24.Text.Trim(), txtitemcode4.Text.Trim(), txtdescription4.Text.Trim(), txtbatch4.Text.Trim(), txtqtybatch4.Text.Trim(), txtsumtotal4.Text.Trim(), txtcode4.Text.Trim(), txttotalrepack4.Text.Trim(), txt4.Text.Trim(), "1", "2", "1", txtdatenow.Text.Trim(), txtaddedby.Text.Trim(),"", "add4");
                    dSets = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text.Trim(), txtmainfeedcode.Text.Trim(), label24.Text.Trim(), txtitemcode5.Text.Trim(), txtdescription5.Text.Trim(), txtbatch5.Text.Trim(), txtqtybatch5.Text.Trim(), txtsumtotal5.Text.Trim(), txtcode5.Text.Trim(), txttotalrepack5.Text.Trim(), txt5.Text.Trim(), "1", "2", "1", txtdatenow.Text.Trim(), txtaddedby.Text.Trim(),"", "add5");
                    dSets = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text.Trim(), txtmainfeedcode.Text.Trim(), label24.Text.Trim(), txtitemcode6.Text.Trim(), txtdescription6.Text.Trim(), txtbatch6.Text.Trim(), txtqtybatch6.Text.Trim(), txtsumtotal6.Text.Trim(), txtcode6.Text.Trim(), txttotalrepack6.Text.Trim(), txt6.Text.Trim(), "1", "2", "1", txtdatenow.Text.Trim(), txtaddedby.Text.Trim(),"", "add6");
                    dSets = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text.Trim(), txtmainfeedcode.Text.Trim(), label24.Text.Trim(), txtitemcode7.Text.Trim(), txtdescription7.Text.Trim(), txtbatch7.Text.Trim(), txtqtybatch7.Text.Trim(), txtsumtotal7.Text.Trim(), txtcode7.Text.Trim(), txttotalrepack7.Text.Trim(), txt7.Text.Trim(), "1", "2", "1", txtdatenow.Text.Trim(), txtaddedby.Text.Trim(),"", "add7");
                    dSets = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text.Trim(), txtmainfeedcode.Text.Trim(), label24.Text.Trim(), txtitemcode8.Text.Trim(), txtdescription8.Text.Trim(), txtbatch8.Text.Trim(), txtqtybatch8.Text.Trim(), txtsumtotal8.Text.Trim(), txtcode8.Text.Trim(), txttotalrepack8.Text.Trim(), txt8.Text.Trim(), "1", "2", "1", txtdatenow.Text.Trim(), txtaddedby.Text.Trim(),"", "add8");
                    dSets = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text.Trim(), txtmainfeedcode.Text.Trim(), label24.Text.Trim(), txtitemcode9.Text.Trim(), txtdescription9.Text.Trim(), txtbatch9.Text.Trim(), txtqtybatch9.Text.Trim(), txtsumtotal9.Text.Trim(), txtcode9.Text.Trim(), txttotalrepack9.Text.Trim(), txt9.Text.Trim(), "1", "2", "1", txtdatenow.Text.Trim(), txtaddedby.Text.Trim(),"", "add9");
                    dSets = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text.Trim(), txtmainfeedcode.Text.Trim(), label24.Text.Trim(), txtitemcode10.Text.Trim(), txtdescription10.Text.Trim(), txtbatch10.Text.Trim(), txtqtybatch10.Text.Trim(), txtsumtotal10.Text.Trim(), txtcode10.Text.Trim(), txttotalrepack10.Text.Trim(), txt10.Text.Trim(), "1", "2", "1", txtdatenow.Text.Trim(), txtaddedby.Text.Trim(),"", "add10");
                    dSets = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text.Trim(), txtmainfeedcode.Text.Trim(), label24.Text.Trim(), txtitemcode11.Text.Trim(), txtdescription11.Text.Trim(), txtbatch11.Text.Trim(), txtqtybatch11.Text.Trim(), txtsumtotal11.Text.Trim(), txtcode11.Text.Trim(), txttotalrepack11.Text.Trim(), txt11.Text.Trim(), "1", "2", "1", txtdatenow.Text.Trim(), txtaddedby.Text.Trim(),"", "add11");
                    dSets = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text.Trim(), txtmainfeedcode.Text.Trim(), label24.Text.Trim(), txtitemcode12.Text.Trim(), txtdescription12.Text.Trim(), txtbatch12.Text.Trim(), txtqtybatch12.Text.Trim(), txtsumtotal12.Text.Trim(), txtcode12.Text.Trim(), txttotalrepack12.Text.Trim(), txt12.Text.Trim(), "1", "2", "1", txtdatenow.Text.Trim(), txtaddedby.Text.Trim(),"", "add12");
                    dSets = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text.Trim(), txtmainfeedcode.Text.Trim(), label24.Text.Trim(), txtitemcode13.Text.Trim(), txtdescription13.Text.Trim(), txtbatch13.Text.Trim(), txtqtybatch13.Text.Trim(), txtsumtotal13.Text.Trim(), txtcode13.Text.Trim(), txttotalrepack13.Text.Trim(), txt13.Text.Trim(), "1", "2", "1", txtdatenow.Text.Trim(), txtaddedby.Text.Trim(),"", "add13");
                    dSets = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text.Trim(), txtmainfeedcode.Text.Trim(), label24.Text.Trim(), txtitemcode14.Text.Trim(), txtdescription14.Text.Trim(), txtbatch14.Text.Trim(), txtqtybatch14.Text.Trim(), txtsumtotal14.Text.Trim(), txtcode14.Text.Trim(), txttotalrepack14.Text.Trim(), txt14.Text.Trim(), "1", "2", "1", txtdatenow.Text.Trim(), txtaddedby.Text.Trim(),"", "add14");
                    dSets = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text.Trim(), txtmainfeedcode.Text.Trim(), label24.Text.Trim(), txtitemcode15.Text.Trim(), txtdescription15.Text.Trim(), txtbatch15.Text.Trim(), txtqtybatch15.Text.Trim(), txtsumtotal15.Text.Trim(), txtcode15.Text.Trim(), txttotalrepack15.Text.Trim(), txt15.Text.Trim(), "1", "2", "1", txtdatenow.Text.Trim(), txtaddedby.Text.Trim(),"", "add15");


                    dSets = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text.Trim(), txtmainfeedcode.Text.Trim(), label24.Text.Trim(), txtitemcode16.Text.Trim(), txtdescription16.Text.Trim(), txtbatch16.Text.Trim(), txtqtybatch16.Text.Trim(), txtsumtotal16.Text.Trim(), txtcode16.Text.Trim(), txttotalrepack16.Text.Trim(), txt16.Text.Trim(), "1", "2", "1", txtdatenow.Text.Trim(), txtaddedby.Text.Trim(),"", "add16");
                    dSets = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text.Trim(), txtmainfeedcode.Text.Trim(), label24.Text.Trim(), txtitemcode17.Text.Trim(), txtdescription17.Text.Trim(), txtbatch17.Text.Trim(), txtqtybatch17.Text.Trim(), txtsumtotal17.Text.Trim(), txtcode17.Text.Trim(), txttotalrepack17.Text.Trim(), txt17.Text.Trim(), "1", "2", "1", txtdatenow.Text.Trim(), txtaddedby.Text.Trim(),"", "add17");

                    dSets = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text.Trim(), txtmainfeedcode.Text.Trim(), label24.Text.Trim(), txtitemcode18.Text.Trim(), txtdescription18.Text.Trim(), txtbatch18.Text.Trim(), txtqtybatch18.Text.Trim(), txtsumtotal18.Text.Trim(), txtcode18.Text.Trim(), txttotalrepack18.Text.Trim(), txt18.Text.Trim(), "1", "2", "1", txtdatenow.Text.Trim(), txtaddedby.Text.Trim(),"", "add18");
                    dSets = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text.Trim(), txtmainfeedcode.Text.Trim(), label24.Text.Trim(), txtitemcode19.Text.Trim(), txtdescription19.Text.Trim(), txtbatch19.Text.Trim(), txtqtybatch19.Text.Trim(), txtsumtotal19.Text.Trim(), txtcode19.Text.Trim(), txttotalrepack19.Text.Trim(), txt19.Text.Trim(), "1", "2", "1", txtdatenow.Text.Trim(), txtaddedby.Text.Trim(),"", "add19");
                    dSets = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text.Trim(), txtmainfeedcode.Text.Trim(), label24.Text.Trim(), txtitemcode20.Text.Trim(), txtdescription20.Text.Trim(), txtbatch20.Text.Trim(), txtqtybatch20.Text.Trim(), txtsumtotal20.Text.Trim(), txtcode20.Text.Trim(), txttotalrepack20.Text.Trim(), txt20.Text.Trim(), "1", "2", "1", txtdatenow.Text.Trim(), txtaddedby.Text.Trim(),"", "add20");

                    dSets = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text.Trim(), txtmainfeedcode.Text.Trim(), label24.Text.Trim(), txtitemcode21.Text.Trim(), txtdescription21.Text.Trim(), txtbatch21.Text.Trim(), txtqtybatch21.Text.Trim(), txtsumtotal21.Text.Trim(), txtcode21.Text.Trim(), txttotalrepack21.Text.Trim(), txt21.Text.Trim(), "1", "2", "1", txtdatenow.Text.Trim(), txtaddedby.Text.Trim(),"", "add21");
                    dSets = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text.Trim(), txtmainfeedcode.Text.Trim(), label24.Text.Trim(), txtitemcode22.Text.Trim(), txtdescription22.Text.Trim(), txtbatch22.Text.Trim(), txtqtybatch22.Text.Trim(), txtsumtotal22.Text.Trim(), txtcode22.Text.Trim(), txttotalrepack22.Text.Trim(), txt22.Text.Trim(), "1", "2", "1", txtdatenow.Text.Trim(), txtaddedby.Text.Trim(),"", "add22");
                    dSets = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text.Trim(), txtmainfeedcode.Text.Trim(), label24.Text.Trim(), txtitemcode23.Text.Trim(), txtdescription23.Text.Trim(), txtbatch23.Text.Trim(), txtqtybatch23.Text.Trim(), txtsumtotal23.Text.Trim(), txtcode23.Text.Trim(), txttotalrepack23.Text.Trim(), txt23.Text.Trim(), "1", "2", "1", txtdatenow.Text.Trim(), txtaddedby.Text.Trim(),"", "add23");
                    dSets = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text.Trim(), txtmainfeedcode.Text.Trim(), label24.Text.Trim(), txtitemcode24.Text.Trim(), txtdescription24.Text.Trim(), txtbatch24.Text.Trim(), txtqtybatch24.Text.Trim(), txtsumtotal24.Text.Trim(), txtcode24.Text.Trim(), txttotalrepack24.Text.Trim(), txt24.Text.Trim(), "1", "2", "1", txtdatenow.Text.Trim(), txtaddedby.Text.Trim(),"", "add24");
                    dSets = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text.Trim(), txtmainfeedcode.Text.Trim(), label24.Text.Trim(), txtitemcode25.Text.Trim(), txtdescription25.Text.Trim(), txtbatch25.Text.Trim(), txtqtybatch25.Text.Trim(), txtsumtotal250.Text.Trim(), txtcode25.Text.Trim(), txttotalrepack25.Text.Trim(), txt25.Text.Trim(), "1", "2", "1", txtdatenow.Text.Trim(), txtaddedby.Text.Trim(),"", "add25");
                    //load_macro_count();
                    load_Schedules();
                    showValueDailyProduction();

                    return false;
                }

                else
                {
                    dSet.Clear();

                    //buje
                    dSets = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text.Trim(), txtmainfeedcode.Text.Trim(), label24.Text.Trim(), txtitemcodeactive.Text.Trim(), txtdescriptionactive.Text.Trim(), txtbatchactive.Text.Trim(), txtqtybactchactive.Text.Trim(), txtsumtotalactive.Text.Trim(), txtcode1.Text.Trim(), txttotalrepack1.Text.Trim(), txt1.Text.Trim(), "1", "2", "1", txtdatenow.Text.Trim(), txtaddedby.Text.Trim(), "", "add");

                    dSets = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text.Trim(), txtmainfeedcode.Text.Trim(), label24.Text.Trim(), txtitemcode2.Text.Trim(), txtdescription2.Text.Trim(), txtbatch2.Text.Trim(), txtbatchtwo.Text.Trim(), txtsumtotal2.Text.Trim(), txtcode2.Text.Trim(), txttotalrepack2.Text.Trim(), txt2.Text.Trim(), "1", "2", "1", txtdatenow.Text.Trim(), txtaddedby.Text.Trim(), "", "add2");
                    dSets = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text.Trim(), txtmainfeedcode.Text.Trim(), label24.Text.Trim(), txtitemcode3.Text.Trim(), txtdescription3.Text.Trim(), txtbatch3.Text.Trim(), txtqtybatch3.Text.Trim(), txtsumtotal3.Text.Trim(), txtcode3.Text.Trim(), txttotalrepack3.Text.Trim(), txt3.Text.Trim(), "1", "2", "1", txtdatenow.Text.Trim(), txtaddedby.Text.Trim(), "", "add3");
                    dSets = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text.Trim(), txtmainfeedcode.Text.Trim(), label24.Text.Trim(), txtitemcode4.Text.Trim(), txtdescription4.Text.Trim(), txtbatch4.Text.Trim(), txtqtybatch4.Text.Trim(), txtsumtotal4.Text.Trim(), txtcode4.Text.Trim(), txttotalrepack4.Text.Trim(), txt4.Text.Trim(), "1", "2", "1", txtdatenow.Text.Trim(), txtaddedby.Text.Trim(), "", "add4");
                    dSets = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text.Trim(), txtmainfeedcode.Text.Trim(), label24.Text.Trim(), txtitemcode5.Text.Trim(), txtdescription5.Text.Trim(), txtbatch5.Text.Trim(), txtqtybatch5.Text.Trim(), txtsumtotal5.Text.Trim(), txtcode5.Text.Trim(), txttotalrepack5.Text.Trim(), txt5.Text.Trim(), "1", "2", "1", txtdatenow.Text.Trim(), txtaddedby.Text.Trim(), "", "add5");
                    dSets = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text.Trim(), txtmainfeedcode.Text.Trim(), label24.Text.Trim(), txtitemcode6.Text.Trim(), txtdescription6.Text.Trim(), txtbatch6.Text.Trim(), txtqtybatch6.Text.Trim(), txtsumtotal6.Text.Trim(), txtcode6.Text.Trim(), txttotalrepack6.Text.Trim(), txt6.Text.Trim(), "1", "2", "1", txtdatenow.Text.Trim(), txtaddedby.Text.Trim(), "", "add6");
                    dSets = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text.Trim(), txtmainfeedcode.Text.Trim(), label24.Text.Trim(), txtitemcode7.Text.Trim(), txtdescription7.Text.Trim(), txtbatch7.Text.Trim(), txtqtybatch7.Text.Trim(), txtsumtotal7.Text.Trim(), txtcode7.Text.Trim(), txttotalrepack7.Text.Trim(), txt7.Text.Trim(), "1", "2", "1", txtdatenow.Text.Trim(), txtaddedby.Text.Trim(), "", "add7");
                    dSets = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text.Trim(), txtmainfeedcode.Text.Trim(), label24.Text.Trim(), txtitemcode8.Text.Trim(), txtdescription8.Text.Trim(), txtbatch8.Text.Trim(), txtqtybatch8.Text.Trim(), txtsumtotal8.Text.Trim(), txtcode8.Text.Trim(), txttotalrepack8.Text.Trim(), txt8.Text.Trim(), "1", "2", "1", txtdatenow.Text.Trim(), txtaddedby.Text.Trim(), "", "add8");
                    dSets = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text.Trim(), txtmainfeedcode.Text.Trim(), label24.Text.Trim(), txtitemcode9.Text.Trim(), txtdescription9.Text.Trim(), txtbatch9.Text.Trim(), txtqtybatch9.Text.Trim(), txtsumtotal9.Text.Trim(), txtcode9.Text.Trim(), txttotalrepack9.Text.Trim(), txt9.Text.Trim(), "1", "2", "1", txtdatenow.Text.Trim(), txtaddedby.Text.Trim(), "", "add9");
                    dSets = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text.Trim(), txtmainfeedcode.Text.Trim(), label24.Text.Trim(), txtitemcode10.Text.Trim(), txtdescription10.Text.Trim(), txtbatch10.Text.Trim(), txtqtybatch10.Text.Trim(), txtsumtotal10.Text.Trim(), txtcode10.Text.Trim(), txttotalrepack10.Text.Trim(), txt10.Text.Trim(), "1", "2", "1", txtdatenow.Text.Trim(), txtaddedby.Text.Trim(), "", "add10");
                    dSets = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text.Trim(), txtmainfeedcode.Text.Trim(), label24.Text.Trim(), txtitemcode11.Text.Trim(), txtdescription11.Text.Trim(), txtbatch11.Text.Trim(), txtqtybatch11.Text.Trim(), txtsumtotal11.Text.Trim(), txtcode11.Text.Trim(), txttotalrepack11.Text.Trim(), txt11.Text.Trim(), "1", "2", "1", txtdatenow.Text.Trim(), txtaddedby.Text.Trim(), "", "add11");
                    dSets = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text.Trim(), txtmainfeedcode.Text.Trim(), label24.Text.Trim(), txtitemcode12.Text.Trim(), txtdescription12.Text.Trim(), txtbatch12.Text.Trim(), txtqtybatch12.Text.Trim(), txtsumtotal12.Text.Trim(), txtcode12.Text.Trim(), txttotalrepack12.Text.Trim(), txt12.Text.Trim(), "1", "2", "1", txtdatenow.Text.Trim(), txtaddedby.Text.Trim(), "", "add12");
                    dSets = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text.Trim(), txtmainfeedcode.Text.Trim(), label24.Text.Trim(), txtitemcode13.Text.Trim(), txtdescription13.Text.Trim(), txtbatch13.Text.Trim(), txtqtybatch13.Text.Trim(), txtsumtotal13.Text.Trim(), txtcode13.Text.Trim(), txttotalrepack13.Text.Trim(), txt13.Text.Trim(), "1", "2", "1", txtdatenow.Text.Trim(), txtaddedby.Text.Trim(), "", "add13");
                    dSets = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text.Trim(), txtmainfeedcode.Text.Trim(), label24.Text.Trim(), txtitemcode14.Text.Trim(), txtdescription14.Text.Trim(), txtbatch14.Text.Trim(), txtqtybatch14.Text.Trim(), txtsumtotal14.Text.Trim(), txtcode14.Text.Trim(), txttotalrepack14.Text.Trim(), txt14.Text.Trim(), "1", "2", "1", txtdatenow.Text.Trim(), txtaddedby.Text.Trim(), "", "add14");
                    dSets = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text.Trim(), txtmainfeedcode.Text.Trim(), label24.Text.Trim(), txtitemcode15.Text.Trim(), txtdescription15.Text.Trim(), txtbatch15.Text.Trim(), txtqtybatch15.Text.Trim(), txtsumtotal15.Text.Trim(), txtcode15.Text.Trim(), txttotalrepack15.Text.Trim(), txt15.Text.Trim(), "1", "2", "1", txtdatenow.Text.Trim(), txtaddedby.Text.Trim(), "", "add15");


                    dSets = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text.Trim(), txtmainfeedcode.Text.Trim(), label24.Text.Trim(), txtitemcode16.Text.Trim(), txtdescription16.Text.Trim(), txtbatch16.Text.Trim(), txtqtybatch16.Text.Trim(), txtsumtotal16.Text.Trim(), txtcode16.Text.Trim(), txttotalrepack16.Text.Trim(), txt16.Text.Trim(), "1", "2", "1", txtdatenow.Text.Trim(), txtaddedby.Text.Trim(), "", "add16");
                    dSets = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text.Trim(), txtmainfeedcode.Text.Trim(), label24.Text.Trim(), txtitemcode17.Text.Trim(), txtdescription17.Text.Trim(), txtbatch17.Text.Trim(), txtqtybatch17.Text.Trim(), txtsumtotal17.Text.Trim(), txtcode17.Text.Trim(), txttotalrepack17.Text.Trim(), txt17.Text.Trim(), "1", "2", "1", txtdatenow.Text.Trim(), txtaddedby.Text.Trim(), "", "add17");

                    dSets = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text.Trim(), txtmainfeedcode.Text.Trim(), label24.Text.Trim(), txtitemcode18.Text.Trim(), txtdescription18.Text.Trim(), txtbatch18.Text.Trim(), txtqtybatch18.Text.Trim(), txtsumtotal18.Text.Trim(), txtcode18.Text.Trim(), txttotalrepack18.Text.Trim(), txt18.Text.Trim(), "1", "2", "1", txtdatenow.Text.Trim(), txtaddedby.Text.Trim(), "", "add18");
                    dSets = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text.Trim(), txtmainfeedcode.Text.Trim(), label24.Text.Trim(), txtitemcode19.Text.Trim(), txtdescription19.Text.Trim(), txtbatch19.Text.Trim(), txtqtybatch19.Text.Trim(), txtsumtotal19.Text.Trim(), txtcode19.Text.Trim(), txttotalrepack19.Text.Trim(), txt19.Text.Trim(), "1", "2", "1", txtdatenow.Text.Trim(), txtaddedby.Text.Trim(), "", "add19");
                    dSets = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text.Trim(), txtmainfeedcode.Text.Trim(), label24.Text.Trim(), txtitemcode20.Text.Trim(), txtdescription20.Text.Trim(), txtbatch20.Text.Trim(), txtqtybatch20.Text.Trim(), txtsumtotal20.Text.Trim(), txtcode20.Text.Trim(), txttotalrepack20.Text.Trim(), txt20.Text.Trim(), "1", "2", "1", txtdatenow.Text.Trim(), txtaddedby.Text.Trim(), "", "add20");

                    dSets = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text.Trim(), txtmainfeedcode.Text.Trim(), label24.Text.Trim(), txtitemcode21.Text.Trim(), txtdescription21.Text.Trim(), txtbatch21.Text.Trim(), txtqtybatch21.Text.Trim(), txtsumtotal21.Text.Trim(), txtcode21.Text.Trim(), txttotalrepack21.Text.Trim(), txt21.Text.Trim(), "1", "2", "1", txtdatenow.Text.Trim(), txtaddedby.Text.Trim(), "", "add21");
                    dSets = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text.Trim(), txtmainfeedcode.Text.Trim(), label24.Text.Trim(), txtitemcode22.Text.Trim(), txtdescription22.Text.Trim(), txtbatch22.Text.Trim(), txtqtybatch22.Text.Trim(), txtsumtotal22.Text.Trim(), txtcode22.Text.Trim(), txttotalrepack22.Text.Trim(), txt22.Text.Trim(), "1", "2", "1", txtdatenow.Text.Trim(), txtaddedby.Text.Trim(), "", "add22");
                    dSets = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text.Trim(), txtmainfeedcode.Text.Trim(), label24.Text.Trim(), txtitemcode23.Text.Trim(), txtdescription23.Text.Trim(), txtbatch23.Text.Trim(), txtqtybatch23.Text.Trim(), txtsumtotal23.Text.Trim(), txtcode23.Text.Trim(), txttotalrepack23.Text.Trim(), txt23.Text.Trim(), "1", "2", "1", txtdatenow.Text.Trim(), txtaddedby.Text.Trim(), "", "add23");
                    dSets = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text.Trim(), txtmainfeedcode.Text.Trim(), label24.Text.Trim(), txtitemcode24.Text.Trim(), txtdescription24.Text.Trim(), txtbatch24.Text.Trim(), txtqtybatch24.Text.Trim(), txtsumtotal24.Text.Trim(), txtcode24.Text.Trim(), txttotalrepack24.Text.Trim(), txt24.Text.Trim(), "1", "2", "1", txtdatenow.Text.Trim(), txtaddedby.Text.Trim(), "", "add24");
                    dSets = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text.Trim(), txtmainfeedcode.Text.Trim(), label24.Text.Trim(), txtitemcode25.Text.Trim(), txtdescription25.Text.Trim(), txtbatch25.Text.Trim(), txtqtybatch25.Text.Trim(), txtsumtotal250.Text.Trim(), txtcode25.Text.Trim(), txttotalrepack25.Text.Trim(), txt25.Text.Trim(), "1", "2", "1", txtdatenow.Text.Trim(), txtaddedby.Text.Trim(), "", "add25");
                    load_Schedules();
                    showValueDailyProduction();
                    return true;
                }
            }
            //else if (mode == "add2")
            //{

            //    dSet.Clear();
            //    dSet = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text, txtmainfeedcode.Text, label24.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "getbyname");

            //    if (dSet.Tables[0].Rows.Count > 0)
            //    {
            //        MessageBox.Show("Raw Material is already added.", "Raw Materials", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        //txtMainInput.Focus();
            //        //submit button that will be disabled 
            //        BtnSave.Enabled = false;

            //        //calling the dashboard counts

            //        //load_macro_count();
            //        return false;
            //    }

            //    else
            //    {
            //        dSet.Clear();


            //        dSets = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text.Trim(), txtmainfeedcode.Text.Trim(), label24.Text.Trim(), txtitemcodeactive.Text.Trim(), txtdescriptionactive.Text.Trim(), txtbatchactive.Text.Trim(), txtbatchtwo.Text.Trim(), txtsumtotal2.Text.Trim(), txtcode2.Text.Trim(), txttotalrepack2.Text.Trim(), txt2.Text.Trim(), "1", "2", "1", txtdatenow.Text.Trim(), txtaddedby.Text.Trim(), "add2");

            //        return true;
            //    }

            //}
            else if (mode == "edit")
            {
                dSet.Clear();
                /// dSet = objStorProc.rdf_sp_supplier(0, txtSupplier.Text, txtContactNo.Text, txtAddress.Text, txtEmailAddress.Text, "getbyname");

                dSet_temp.Clear();
                /// dSet_temp = objStorProc.rdf_sp_supplier(p_id, txtSupplier.Text, txtContactNo.Text, txtAddress.Text, txtEmailAddress.Text, "getbyid");

                if (dSet.Tables[0].Rows.Count > 0)
                {
                    int tmpID = Convert.ToInt32(dSet.Tables[0].Rows[0][0].ToString());
                    if (tmpID == p_id)
                    {
                        dSet.Clear();
                        ///   dSet = objStorProc.rdf_sp_supplier(p_id, txtSupplier.Text.Trim(), txtContactNo.Text.Trim(), txtAddress.Text.Trim(), txtEmailAddress.Text.Trim(), "edit");


                        return true;
                    }

                    else
                    {
                        MessageBox.Show("Offense code is already added.", "Offense", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //txtMainInput.Focus();
                        return false;
                    }
                }
                else
                {
                    dSet.Clear();
                    ///        dSet = dSet = objStorProc.rdf_sp_supplier(p_id, txtSupplier.Text.Trim(), txtContactNo.Text.Trim(), txtAddress.Text.Trim(), txtEmailAddress.Text.Trim(), "edit");


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


        private void txtqty18_TextChanged(object sender, EventArgs e)
        {
            try
            {


                txtqtybatch18.Text = (float.Parse(txtqty18.Text) * 1).ToString("#,0.000");
            }
            catch (Exception)
            {


            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            doSearch();

            //search();
            txtcode18.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
            txttotalrepack18.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

            //txt1.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();








            if (txtitemcode18.Text.Trim() == txtcode18.Text.Trim())
            {
                //MessageBox.Show("Proceed Match Code");

            }
            else
            {

                //ItemCodeNotMatched();
                txt18.Text = "";

                txtBarcode.Focus();
                txtBarcode.Text = "";

                return;

            }


            txt18.Text = dgvrepackdb.CurrentRow.Cells["string_id"].Value.ToString();

            if (txttotalrepack18.Text.Trim() == txtsumtotal18.Text.Trim())
            {
                //MessageBox.Show("Qty Needed Match <3");
                pictureBox18.Visible = true;
            }
            else
            {
                //MessageBox.Show("Item Quantity Not Match IN Our Needed!, Choose the exactly item Quantity Thanks! ");
                ItemCodeValueNotmacthed();
                txt18.Text = "";
                txtBarcode.Text = "";
                txtBarcode.Focus();

                return;
            }
            if (txt18.Text.Trim() == string.Empty)
            {

            }
            else
            {

                pictureBox18.Visible = false;
            }


            txt18.BackColor = Color.LightGreen;
            //pictureBox18.Visible = true;
            groupBoxpack.Visible = true;
            button18.Text = "Validated";
            ds.Clear();
            txtBarcode.Text = "";
            txtBarcode.Focus();
            txtBarcode.Select();


            double sagot;
            double subjectquantity;

            subjectquantity = double.Parse(lblscannumber.Text);
            sagot = subjectquantity + 1;
            lblscannumber.Text = Convert.ToString(sagot);
            SuccessFullyValidated();

        }

        private void txttotalrepack3_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt18_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt17_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtqty19_TextChanged(object sender, EventArgs e)
        {
            try
            {


                txtqtybatch19.Text = (float.Parse(txtqty19.Text) * 1).ToString("#,0.000");
            }
            catch (Exception)
            {


            }
        }

        private void txtqty20_TextChanged(object sender, EventArgs e)
        {
            try
            {


                txtqtybatch20.Text = (float.Parse(txtqty20.Text) * 1).ToString("#,0.000");
            }
            catch (Exception)
            {


            }
        }

        private void txtqty21_TextChanged(object sender, EventArgs e)
        {
            try
            {


                txtqtybatch21.Text = (float.Parse(txtqty21.Text) * 1).ToString("#,0.000");
            }
            catch (Exception)
            {


            }
        }

        private void txtqty22_TextChanged(object sender, EventArgs e)
        {
            try
            {


                txtqtybatch22.Text = (float.Parse(txtqty22.Text) * 1).ToString("#,0.000");
            }
            catch (Exception)
            {


            }
        }

        private void txtqty23_TextChanged(object sender, EventArgs e)
        {
            try
            {


                txtqtybatch23.Text = (float.Parse(txtqty23.Text) * 1).ToString("#,0.000");
            }
            catch (Exception)
            {


            }
        }

        private void txtqty24_TextChanged(object sender, EventArgs e)
        {
            try
            {


                txtqtybatch24.Text = (float.Parse(txtqty24.Text) * 1).ToString("#,0.000");
            }
            catch (Exception)
            {


            }
        }

        private void txtqty25_TextChanged(object sender, EventArgs e)
        {
            try
            {


                txtqtybatch25.Text = (float.Parse(txtqty25.Text) * 1).ToString("#,0.000");
            }
            catch (Exception)
            {


            }
        }

        private void txtqtybatch19_TextChanged(object sender, EventArgs e)
        {
            try
            {


                txtsumtotal19.Text = (float.Parse(txtqty19.Text) * 1).ToString("#,0.000");
            }
            catch (Exception)
            {


            }
        }

        private void txtqtybatch20_TextChanged(object sender, EventArgs e)
        {
            try
            {


                txtsumtotal20.Text = (float.Parse(txtqty20.Text) * 1).ToString("#,0.000");
            }
            catch (Exception)
            {


            }
        }

        private void txtqtybatch21_TextChanged(object sender, EventArgs e)
        {
            try
            {


                txtsumtotal21.Text = (float.Parse(txtqty21.Text) * 1).ToString("#,0.000");
            }
            catch (Exception)
            {


            }
        }

        private void txtqtybatch22_TextChanged(object sender, EventArgs e)
        {
            try
            {


                txtsumtotal22.Text = (float.Parse(txtqty22.Text) * 1).ToString("#,0.000");
            }
            catch (Exception)
            {


            }
        }

        private void txtqtybatch23_TextChanged(object sender, EventArgs e)
        {
            try
            {


                txtsumtotal23.Text = (float.Parse(txtqty23.Text) * 1).ToString("#,0.000");
            }
            catch (Exception)
            {


            }
        }

        private void txtqtybatch24_TextChanged(object sender, EventArgs e)
        {
            try
            {


                txtsumtotal24.Text = (float.Parse(txtqty24.Text) * 1).ToString("#,0.000");
            }
            catch (Exception)
            {


            }
        }

        private void txtqtybatch25_TextChanged(object sender, EventArgs e)
        {
            try
            {


                txtsumtotal250.Text = (float.Parse(txtqty25.Text) * 1).ToString("#,0.000");
            }
            catch (Exception)
            {


            }
        }

        private void button19_Click(object sender, EventArgs e)
        {


            doSearch();

            //search();
            txtcode19.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
            txttotalrepack19.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

            //txt1.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();








            if (txtitemcode19.Text.Trim() == txtcode19.Text.Trim())
            {
                //MessageBox.Show("Proceed Match Code");

            }
            else
            {

                //ItemCodeNotMatched();
                txt19.Text = "";

                txtBarcode.Focus();
                txtBarcode.Text = "";

                return;

            }


            txt19.Text = dgvrepackdb.CurrentRow.Cells["string_id"].Value.ToString();

            if (txttotalrepack19.Text.Trim() == txtsumtotal19.Text.Trim())
            {
                //MessageBox.Show("Qty Needed Match <3");
                pictureBox19.Visible = true;
            }
            else
            {
                //MessageBox.Show("Item Quantity Not Match IN Our Needed!, Choose the exactly item Quantity Thanks! ");
                ItemCodeValueNotmacthed();
                txt19.Text = "";
                txtBarcode.Text = "";
                txtBarcode.Focus();

                return;
            }
            if (txt19.Text.Trim() == string.Empty)
            {

            }
            else
            {

                pictureBox19.Visible = false;
            }


            txt19.BackColor = Color.LightGreen;
    
            groupBoxpack.Visible = true;
            button19.Text = "Validated";
            ds.Clear();
            txtBarcode.Text = "";
            txtBarcode.Focus();
            txtBarcode.Select();


            double sagot;
            double subjectquantity;

            subjectquantity = double.Parse(lblscannumber.Text);
            sagot = subjectquantity + 1;
            lblscannumber.Text = Convert.ToString(sagot);
            SuccessFullyValidated();



        }

        private void button23_Click(object sender, EventArgs e)
        {

            doSearch();

            //search();
            txtcode23.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
            txttotalrepack23.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

            //txt1.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();








            if (txtitemcode23.Text.Trim() == txtcode23.Text.Trim())
            {
                //MessageBox.Show("Proceed Match Code");

            }
            else
            {

                //ItemCodeNotMatched();
                txt23.Text = "";

                txtBarcode.Focus();
                txtBarcode.Text = "";

                return;

            }


            txt23.Text = dgvrepackdb.CurrentRow.Cells["string_id"].Value.ToString();

            if (txttotalrepack23.Text.Trim() == txtsumtotal23.Text.Trim())
            {
                //MessageBox.Show("Qty Needed Match <3");
                pictureBox23.Visible = true;
            }
            else
            {
                //MessageBox.Show("Item Quantity Not Match IN Our Needed!, Choose the exactly item Quantity Thanks! ");
                ItemCodeValueNotmacthed();
                txt23.Text = "";
                txtBarcode.Text = "";
                txtBarcode.Focus();

                return;
            }
            if(txt23.Text.Trim()==string.Empty)
            {

            }
            else
            {
                pictureBox23.Visible = false;
            }


            txt23.BackColor = Color.LightGreen;
         
            groupBoxpack.Visible = true;
            button23.Text = "Validated";
            ds.Clear();
            txtBarcode.Text = "";
            txtBarcode.Focus();
            txtBarcode.Select();


            double sagot;
            double subjectquantity;

            subjectquantity = double.Parse(lblscannumber.Text);
            sagot = subjectquantity + 1;
            lblscannumber.Text = Convert.ToString(sagot);
            SuccessFullyValidated();
        }

        private void button21_Click(object sender, EventArgs e)
        {

            doSearch();

            //search();
            txtcode21.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
            txttotalrepack21.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

            //txt1.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();








            if (txtitemcode21.Text.Trim() == txtcode21.Text.Trim())
            {
                //MessageBox.Show("Proceed Match Code");

            }
            else
            {

                //ItemCodeNotMatched();
                txt21.Text = "";

                txtBarcode.Focus();
                txtBarcode.Text = "";

                return;

            }


            txt21.Text = dgvrepackdb.CurrentRow.Cells["string_id"].Value.ToString();

            if (txttotalrepack21.Text.Trim() == txtsumtotal21.Text.Trim())
            {
                //MessageBox.Show("Qty Needed Match <3");
                pictureBox21.Visible = true;
            }
            else
            {
                //MessageBox.Show("Item Quantity Not Match IN Our Needed!, Choose the exactly item Quantity Thanks! ");
                ItemCodeValueNotmacthed();
                txt21.Text = "";
                txtBarcode.Text = "";
                txtBarcode.Focus();

                return;
            }

            if (txt21.Text.Trim() == string.Empty)
            {
;
            }
            else
 
                {
                    pictureBox21.Visible = false;
                }

            txt21.BackColor = Color.LightGreen;

            groupBoxpack.Visible = true;
            button21.Text = "Validated";
            ds.Clear();
            txtBarcode.Text = "";
            txtBarcode.Focus();
            txtBarcode.Select();


            double sagot;
            double subjectquantity;

            subjectquantity = double.Parse(lblscannumber.Text);
            sagot = subjectquantity + 1;
            lblscannumber.Text = Convert.ToString(sagot);
            SuccessFullyValidated();

        }

        private void button22_Click(object sender, EventArgs e)
        {
            doSearch();

            //search();
            txtcode22.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
            txttotalrepack22.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

            //txt1.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();








            if (txtitemcode22.Text.Trim() == txtcode22.Text.Trim())
            {
                //MessageBox.Show("Proceed Match Code");

            }
            else
            {

                //ItemCodeNotMatched();
                txt22.Text = "";

                txtBarcode.Focus();
                txtBarcode.Text = "";

                return;

            }


            txt22.Text = dgvrepackdb.CurrentRow.Cells["string_id"].Value.ToString();

            if (txttotalrepack22.Text.Trim() == txtsumtotal22.Text.Trim())
            {
                //MessageBox.Show("Qty Needed Match <3");
                pictureBox22.Visible = true;
            }
            else
            {
                //MessageBox.Show("Item Quantity Not Match IN Our Needed!, Choose the exactly item Quantity Thanks! ");
                ItemCodeValueNotmacthed();
                txt22.Text = "";
                txtBarcode.Text = "";
                txtBarcode.Focus();

                return;
            }
            if (txt22.Text.Trim() == string.Empty)
            {
;
            }
            else
            {
                pictureBox22.Visible = false;
            }


            txt22.BackColor = Color.LightGreen;
      
            groupBoxpack.Visible = true;
            button22.Text = "Validated";
            ds.Clear();
            txtBarcode.Text = "";
            txtBarcode.Focus();
            txtBarcode.Select();


            double sagot;
            double subjectquantity;

            subjectquantity = double.Parse(lblscannumber.Text);
            sagot = subjectquantity + 1;
            lblscannumber.Text = Convert.ToString(sagot);
            SuccessFullyValidated();

        }

        private void button24_Click(object sender, EventArgs e)
        {


            doSearch();

            //search();
            txtcode24.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
            txttotalrepack24.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

            //txt1.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();








            if (txtitemcode24.Text.Trim() == txtcode24.Text.Trim())
            {
                //MessageBox.Show("Proceed Match Code");

            }
            else
            {

                //ItemCodeNotMatched();
                txt24.Text = "";

                txtBarcode.Focus();
                txtBarcode.Text = "";

                return;

            }


            txt24.Text = dgvrepackdb.CurrentRow.Cells["string_id"].Value.ToString();

            if (txttotalrepack24.Text.Trim() == txtsumtotal24.Text.Trim())
            {
                //MessageBox.Show("Qty Needed Match <3");
                pictureBox24.Visible = true;
            }
            else
            {
                //MessageBox.Show("Item Quantity Not Match IN Our Needed!, Choose the exactly item Quantity Thanks! ");
                ItemCodeValueNotmacthed();
                txt24.Text = "";
                txtBarcode.Text = "";
                txtBarcode.Focus();

                return;
            }
            if (txt24.Text.Trim() == string.Empty)
            {

            }
            else
            {
                pictureBox24.Visible = false;
            }


            txt24.BackColor = Color.LightGreen;

            groupBoxpack.Visible = true;
            button24.Text = "Validated";
            ds.Clear();
            txtBarcode.Text = "";
            txtBarcode.Focus();
            txtBarcode.Select();


            double sagot;
            double subjectquantity;

            subjectquantity = double.Parse(lblscannumber.Text);
            sagot = subjectquantity + 1;
            lblscannumber.Text = Convert.ToString(sagot);
            SuccessFullyValidated();

        }

        private void button25_Click(object sender, EventArgs e)
        {

            doSearch();

            //search();
            txtcode25.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
            txttotalrepack25.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

            //txt1.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();








            if (txtitemcode25.Text.Trim() == txtcode25.Text.Trim())
            {
                //MessageBox.Show("Proceed Match Code");

            }
            else
            {

                //ItemCodeNotMatched();
                txt25.Text = "";

                txtBarcode.Focus();
                txtBarcode.Text = "";

                return;

            }


            txt25.Text = dgvrepackdb.CurrentRow.Cells["string_id"].Value.ToString();

            if (txttotalrepack25.Text.Trim() == txtsumtotal250.Text.Trim())
            {
                //MessageBox.Show("Qty Needed Match <3");
                pictureBox25.Visible = true;
            }
            else
            {
                //MessageBox.Show("Item Quantity Not Match IN Our Needed!, Choose the exactly item Quantity Thanks! ");
                ItemCodeValueNotmacthed();
                txt25.Text = "";
                txtBarcode.Text = "";
                txtBarcode.Focus();

                return;
            }

            if(txt25.Text.Trim()==string.Empty)
            {

            }
            else
            {
                pictureBox25.Visible = false;
            }

            txt25.BackColor = Color.LightGreen;
         
            groupBoxpack.Visible = true;
            button25.Text = "Validated";
            ds.Clear();
            txtBarcode.Text = "";
            txtBarcode.Focus();
            txtBarcode.Select();


            double sagot;
            double subjectquantity;

            subjectquantity = double.Parse(lblscannumber.Text);
            sagot = subjectquantity + 1;
            lblscannumber.Text = Convert.ToString(sagot);
            SuccessFullyValidated();
        }

        private void txt18_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button18_Click(sender, e);
            }
        }

        private void txt18_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt19_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt19_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt19_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button19_Click(sender, e);
            }
        }

        private void txt20_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button20_Click(sender, e);
            }
        }

        private void txt20_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt21_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt21_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button21_Click(sender, e);
            }
        }

        private void txt22_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt22_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button22_Click(sender, e);
            }
        }

        private void txt23_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button23_Click(sender, e);
            }
        }

        private void txt23_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt24_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt24_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button24_Click(sender, e);
            }
        }

        private void txt25_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button25_Click(sender, e);
            }
        }

        private void txt25_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {




        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void txtmainsearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button3_Click(sender, e);
            }
        }

        private void txt4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button4_Click(sender, e);
            }
        }

        private void txtcode1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvMaster_Click(object sender, EventArgs e)
        {
            lbltotalcounts.Visible = true;
            //bunifuStart.Visible = true;
            dgv1stView.Visible = true;
      
            //txtmainfeedcode.Text = dgvMaster.CurrentRow.Cells["p_feed_code"].Value.ToString();
            //txtsumtotalactive.Text = dgv1stView.CurrentRow.Cells["quantity1"].Value.ToString();
            //countsBelow();


            if (txtstatus.Text == "ready")
            {
                //bunifuStart.Enabled = false;
                bunifuStart.Visible = true;
            }
            else
            {

                //bunifuStart.Enabled = true;
                ActualNeedandActualCOuntisnotEqual();
                bunifuStart.Visible = false;
            }















        }

        void countsBelow()
        {
            label11.Visible = true;
            lblCounts.Visible = true;
        
            lblCountss.Visible = true;
            label2.Visible = true;
     
            lbltotalread.Visible = true;
        }


        private void bunifuStart_Click(object sender, EventArgs e)
        {
            metroClose_Click(sender, e);

        }

        private void bunifuStopPreparation_Click(object sender, EventArgs e)
        {
            metroButton1_Click(sender,e);
           
        }

        private void txtsumtotal19_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt22_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnlessthan_Click(object sender, EventArgs e)
        {
                    lbltotalread.Text = "0";
            txt2.Text = string.Empty;
   
            StressHideTextBox();
            HideGifters();
            txtmainfeedcode_TextChanged(sender, e);
 

            txtQuantity.Text = dgvImport.CurrentRow.Cells["quantity2"].Value.ToString();

            //txtitemcode_TextChanged(sender, e);
            //lblmainCount.Text = "0";
            if (dgvMaster.Rows.Count >= 1)
            {


                int i = dgvMaster.CurrentRow.Index + 1;
                if (i >= -1 && i < dgvMaster.Rows.Count)
                    dgvMaster.CurrentCell = dgvMaster.Rows[i].Cells[1];




                //dgvMaster_Click(sender,e);
                else
                {
                    LastLine();
                    //txtselectweight.Text = dgvAllFeedCode.CurrentRow.Cells["Quantity"].Value.ToString();
                    //timer1_Tick(sender, e);
                    //txtweighingscale.Focus();

                    txtQuantity.Text = dgvImport.CurrentRow.Cells["quantity2"].Value.ToString();
                    if (lblCounts.Text == lbltotalcounts.Text)
                    {

                        //bunifuStart.Enabled = false;

                        btnShow_Click(sender, e);
                        txtBarcode.Enabled = true;
                        txtBarcode.Select();
                        txtBarcode.Focus();
                    }
                    else
                    {

                        //bunifuStart.Enabled = true;
                        //bunifuStart.Enabled = false;
                        RepackRawMatsFirst();
                        txt1.Enabled = false;
                        txtBarcode.Enabled = false;
                    }

                    return;
                }
            }
            //}
            txttotalQty.Text = (float.Parse(txtQuantity.Text) * float.Parse(txtnobatch.Text)).ToString();


            if (lblCounts.Text == lbltotalcounts.Text)
            {
                txtsubstractrepack.Text = (float.Parse(txtactiveqtyrepack.Text) - 1).ToString();
                //bunifuStart.Enabled = false;

                btnShow_Click(sender, e);
                txtBarcode.Enabled = true;
                txtBarcode.Select();
                txtBarcode.Focus();
            }
            else
            {

                //bunifuStart.Enabled = true;
                //bunifuStart.Enabled = false;
                RepackRawMatsFirst();
                txt1.Enabled = false;
                txtBarcode.Enabled = false;
            }
       
            load_search();

        }




        void LastLine()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.ContentText = "YOU ARE ALREADY IN THE LAST LINE";
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Red;
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

        private void btngreaterthan_Click(object sender, EventArgs e)
        {
            //lbltotalread.Text = "0";
            //txtmainfeedcode_TextChanged(sender, e);
            //StressHideTextBox();
            //HideGifters();
            //lblscannumber.Text = "0";
       
            //txtQuantity.Text = dgvImport.CurrentRow.Cells["quantity2"].Value.ToString();


            lbltotalread.Text = "0";
            txt2.Text = string.Empty;

            StressHideTextBox(); //deploy
            HideGifters();
            txtmainfeedcode_TextChanged(sender, e);


            txtQuantity.Text = dgvImport.CurrentRow.Cells["quantity2"].Value.ToString();

            int prev = this.dgvMaster.CurrentRow.Index - 1;
            if (prev >= 0)
            {

                this.dgvMaster.CurrentCell = this.dgvMaster.Rows[prev].Cells[this.dgvMaster.CurrentCell.ColumnIndex];
                //dgvMaster_Click(sender, e);
                btnShow_Click(sender, e);
            }
            else
            {
                FirstLine();
      
                txtQuantity.Text = dgvImport.CurrentRow.Cells["quantity2"].Value.ToString();
                btnShow_Click(sender, e);
                if (lblCounts.Text == lbltotalcounts.Text)
                {

                    //bunifuStart.Enabled = false;
                    txtsubstractrepack.Text = (float.Parse(txtactiveqtyrepack.Text) - 1).ToString();
                    //btnShow_Click(sender, e);
                    txtBarcode.Enabled = true;
                    txtBarcode.Select();
                    txtBarcode.Focus();
                }
                else
                {

                    //bunifuStart.Enabled = true;
                    //bunifuStart.Enabled = false;
                    RepackRawMatsFirst();
                    txt1.Enabled = false;
                    txtBarcode.Enabled = false;
                }
                txtQuantity.Text = dgvImport.CurrentRow.Cells["quantity2"].Value.ToString();
            }
  

            txttotalQty.Text = (float.Parse(txtQuantity.Text) * float.Parse(txtnobatch.Text)).ToString();
            ////checkReceivingBalance();
            //btnbalance_Click(sender, e);
            if (lblCounts.Text == lbltotalcounts.Text)
            {

                //bunifuStart.Enabled = false;

                //btnShow_Click(sender, e);
                txtBarcode.Enabled = true;
                txtBarcode.Select();
                txtBarcode.Focus();
            }
            else
            {

                //bunifuStart.Enabled = true;
                //bunifuStart.Enabled = false;
                RepackRawMatsFirst();
                txt1.Enabled = false;
                txtBarcode.Enabled = false;
            }

            load_search();
        }



        void FirstLine()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.ContentText = "YOU ARE ALREADY IN THE FIRST LINE";
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

        private void txtmasterid_TextChanged(object sender, EventArgs e)
        {
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=hr_bak;Integrated Security=SSPI";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);

            // AND rp_category='MICRO' ORDER BY rp_group
            //            string sqlquery = "select DISTINCT adv.prod_id,rpa.feed_code,rpa.rp_feed_type,rpa.rp_group,rpa.item_code,rpa.rp_description,adv.p_nobatch,rpa.quantity,rpa.quantity from [dbo].[rdf_recipe_to_production] rpa LEFT JOIN rdf_production_advance adv ON rpa.production_id=adv.prod_id WHERE rpa.feed_code = '" + txtmainfeedcode.Text + "' AND rp_category='MICRO' AND rpa.is_active=0";
            string sqlquery = "select adv.prod_id,rpa.feed_code,rpa.rp_feed_type,rpa.rp_group,rpa.item_code,rpa.rp_description,adv.p_nobatch,rpa.quantity,rpa.quantity from [dbo].[rdf_recipe_to_production] rpa LEFT JOIN rdf_production_advance adv ON rpa.production_id=adv.prod_id WHERE rp_category='MICRO' AND rpa.is_active='0' AND rpa.production_id = '" + txtmasterid.Text + "' ";
            //string sqlquery = "select adv.prod_id,rpa.feed_code,rpa.rp_feed_type,rpa.rp_group,rpa.item_code,rpa.rp_description,adv.p_nobatch,rpa.quantity,rpa.quantity from [dbo].[rdf_recipe_to_production] rpa LEFT JOIN rdf_production_advance adv ON rpa.production_id=adv.prod_id WHERE rp_category='MICRO' AND rpa.repacking_status='1' AND rpa.production_id = '" + txtmasterid.Text + "' ";


            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgv1stView.DataSource = dt;

            sql_con.Close();
            //mekeni






            String connetionString2 = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            //String connetionString2 = @"Server=FM-MMERCADO-L;Initial Catalog=hr_bak;Integrated Security=SSPI";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con2 = new SqlConnection(connetionString2);

            // AND rp_category='MICRO' ORDER BY rp_group
            string sqlquery2 = "select DISTINCT rpa.feed_code,rpa.rp_feed_type,rpa.rp_group,rpa.item_code,rpa.rp_description,rpa.quantity,rpa.quantity from [dbo].[rdf_recipe] rpa WHERE rpa.feed_code = '" + txtmainfeedcode.Text + "' AND rpa.rp_category='MICRO' AND rpa.is_active=1";
            sql_con.Open();
            SqlCommand sql_cmd2 = new SqlCommand(sqlquery2, sql_con2);
            SqlDataAdapter sdr2 = new SqlDataAdapter(sql_cmd2);
            DataTable dt2 = new DataTable();
            sdr2.Fill(dt2);
            dgvLastFeedCode.DataSource = dt2;
            lbltotalcounts.Text = dgvLastFeedCode.RowCount.ToString();

            sql_con2.Close();














            for (int n = 0; n < (dgv1stView.Rows.Count); n++)
            {
                double s = Convert.ToDouble(dgv1stView.Rows[n].Cells[7].Value);
                double s1 = Convert.ToDouble(dgv1stView.Rows[n].Cells[6].Value);
                //int s1 = Convert.ToInt32(dgv1stView.Rows[n].Cells[1].Value);
                double s13 = s * 2;
                double s15 = s1 * s13;
                dgv1stView.Rows[n].Cells[7].Value = s13.ToString("#,0.000");
                dgv1stView.Rows[n].Cells[8].Value = s15.ToString("#,0.000");
            }










            decimal tot = 0;

            for (int i = 0; i < dgv1stView.RowCount - 0; i++)
            {
                var value = dgv1stView.Rows[i].Cells["quantity"].Value;
                if (value != DBNull.Value)
                {
                    tot += Convert.ToDecimal(value);
                }
            }
            if (tot == 0)
            {

            }

            decimal toty = 0;

            for (int i = 0; i < dgv1stView.RowCount - 0; i++)
            {
                var value = dgv1stView.Rows[i].Cells["quantity1"].Value;
                if (value != DBNull.Value)
                {
                    toty += Convert.ToDecimal(value);
                }
            }
            if (toty == 0)
            {

            }
            //answer = s1 * 2;
            //dgv1stView.CurrentRow.Cells[2].Value = answer;
            //dgv1stView.CurrentRow.Cells[3].Value = answer;


            //dgv1stView.Rows[dgv1stView.Rows.Count - 1].Cells[0].Value = answer;
            //dgv1stView.Rows[dgv1stView.Rows.Count - 2].Cells["quantity"].Value = tot.ToString();


            lblCounts.Text = dgv1stView.RowCount.ToString();
            lblCountss.Text = tot.ToString();
            label2.Text = toty.ToString();


  
            if (lblCountss.Text == "0")
            {
                //lbltotalread.Text = "1";
                //MessageBox.Show("Meron");
                RepackRawMatsFirst();
                txt1.Enabled = false;
                txtdescriptionactive.Text = "";
                txtqtybactchactive.Text = "";
                return;
            }
            else
            {
                lbltotalread.Text = "0";
                txt1.Enabled = false;
                txt1.Select();
                txt1.Focus();
                //txtQuantity.Text = "1";
                //txtnobatch.Text = "1";

                //txttotalQty.Text = (float.Parse(txtQuantity.Text) * float.Parse(txtnobatch.Text)).ToString();
            }


            txtitemcode1.Text = dgv1stView.CurrentRow.Cells["item_code"].Value.ToString();
            txtdescription1.Text = dgv1stView.CurrentRow.Cells["rp_description"].Value.ToString();
            txtdescriptionactive.Text = dgv1stView.CurrentRow.Cells["rp_description"].Value.ToString();
            txtitemcodeactive.Text = dgv1stView.CurrentRow.Cells["item_code"].Value.ToString();
            txtbatchactive.Text = dgv1stView.CurrentRow.Cells["p_nobatch"].Value.ToString();
            txtqtybactchactive.Text = dgv1stView.CurrentRow.Cells["quantity"].Value.ToString();
            txtsumtotalactive.Text = dgv1stView.CurrentRow.Cells["quantity1"].Value.ToString();

          
            txt1.Enabled = true;
            txt1.Select();
            txt1.Focus();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            frmmicrowhpreparation_Load(sender, e);
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to save the Preparations of " + txtmainfeedcode.Text + "? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {



                btnRollback_Click(sender, e);

                mode = "add";
                if (txtmainfeedcode.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please Select production", "Production Today", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (saveMode())
                    {
                        /// loadSupplier();
                        string tmode = mode;

                        if (tmode == "add")
                        {
                            //  dgv1.CurrentCell = dgv1[0, dgv1.Rows.Count - 1];



                            PreparationAlreadySave();
                            //MessageBox.Show("Micro Preparation  SuccesFully Saved !.", "Raw Material Received", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            //calling the dashboards!
                            BtnSave.Visible = false;
                       
                            //button27_Click(sender, e);



                            //   Mainmenu.Refresh();
                            //   this.Close();
                        }
                        else
                        {
                            //  dgv1.CurrentCell = dgv1[0, temp_hid];
                        }

                        /// btnCancel_Click(sender, e);

                    }
                    else
                    {

                    }
                       // MessageBox.Show("Failed");

                }
                //btnRollback_Click(sender, e);
                //frmmicrowhpreparation_Load(sender, e);
                StressHideTextBox();
                HideGifters();
                txt1.Text = "";
                txttotalQty.Text = "";
                this.dgvImport.CurrentCell = this.dgvImport.Rows[0].Cells[this.dgvImport.CurrentCell.ColumnIndex];

            }
            else
            {
                return;
            }


            if (label10.Text == "0")
            {
                txtitemcodeactive.Text = "";
                txtitemcodeactive.Text = "";
                txtsumtotalactive.Text = "";
                txttotalrepack1.Text = "";
                BtnSave.Visible = false;
                btnbarcode.Enabled = false;
                NoDataFound2();
            }
            else
            {
                BtnSave.Enabled = true;
                BtnSave.Visible = false;
                btnShow_Click(sender, e);
            }

            lblscannumber.Text = "0";
        }



        private void metroButton1_Click(object sender, EventArgs e)
        {

            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to cancel the Preparations of " + txtmainfeedcode.Text + "? ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                lbltotalread.Text = "0";
                //txt1.Enabled = true;
                dgvMaster.Enabled = true;
                bunifuStopPreparation.Visible = false;
                //btngreaterthan.BackColor = Color.CornflowerBlue;
                //btnlessthan.BackColor = Color.CornflowerBlue;
                btngreaterthan.Enabled = true;
                btnlessthan.Enabled = true;
                txttotalrepack1.Text = "";

                bunifuStart.Visible = true;
                
                //this.Close();
                //solate.ShowDialog();
                //frmmicrowhpreparation_Load(sender, e);
                StressHideTextBox();
                HideGifters();
                txtmainfeedcode_TextChanged(sender,e);

                BtnSave.Visible = false;

                this.dgv1stView.CurrentCell = this.dgv1stView.Rows[0].Cells[this.dgv1stView.CurrentCell.ColumnIndex];
                txtcode1.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                txtitemcodeactive.Text = dgv1stView.CurrentRow.Cells["item_code"].Value.ToString();
                lblscannumber.Text = "0";
                btnShow_Click(sender,e);
                txtBarcode.Text = "";
                txtBarcode.Select();
                txtBarcode.Focus();
     
                //txtqtybactchactive.Text = dgv1stView.CurrentRow.Cells["quantity"].Value.ToString();
            }

            else
            {
                return;
            }



            }


        void HideGifters()
        {
            txt2.Text = "";
            txt3.Text = "";
            txt4.Text = "";
            txt5.Text = "";
            txt6.Text = "";
            txt7.Text = "";
            txt8.Text = "";
            txt9.Text = "";
            txt10.Text = "";
            txt11.Text = "";
            txt12.Text = "";
            txt13.Text = "";
            txt14.Text = "";
            txt15.Text = "";
            txt16.Text = "";
            txt17.Text = "";
            txt18.Text = "";
            txt19.Text = "";
            txt20.Text = "";
            txt21.Text = "";
            txt22.Text = "";
            txt23.Text = "";
            txt24.Text = "";
            txt25.Text = "";



            txttotalrepack1.Text = "";
            txttotalrepack2.Text = "";

            txttotalrepack3.Text = "";
            txttotalrepack4.Text = "";
            txttotalrepack5.Text = "";
            txttotalrepack6.Text = "";
            txttotalrepack7.Text = "";
            txttotalrepack8.Text = "";
            txttotalrepack9.Text = "";
            txttotalrepack10.Text = "";
            txttotalrepack11.Text = "";
            txttotalrepack12.Text = "";
            txttotalrepack13.Text = "";
            txttotalrepack14.Text = "";
            txttotalrepack15.Text = "";
            txttotalrepack16.Text = "";
            txttotalrepack17.Text = "";
            txttotalrepack18.Text = "";
            txttotalrepack19.Text = "";
            txttotalrepack20.Text = "";
            txttotalrepack21.Text = "";
            txttotalrepack22.Text = "";
            txttotalrepack23.Text = "";
            txttotalrepack24.Text = "";
            txttotalrepack25.Text = "";





























            //2
            txtitemcode2.Visible = false;
            txtdescription2.Visible = false;
            txtbatch2.Visible = false;
            txtbatchtwo.Visible = false;
            txtsumtotal2.Visible = false;
            txtcode2.Visible = false;
            txttotalrepack2.Visible = false;
            txtqty2.Visible = false;
            txt2.Visible = false;
            lblnum2.Visible = false;

            txt2.BackColor = Color.White;
            b2.Visible = false;
            //3
            txtitemcode3.Visible = false;
            txtdescription3.Visible = false;
            txtbatch3.Visible = false;
            txtqtybatch3.Visible = false;
            txtsumtotal3.Visible = false;
            txtcode3.Visible = false;
            txttotalrepack3.Visible = false;
            txtqty3.Visible = false;
            txt3.Visible = false;
            lblnum3.Visible = false;
       
            txt3.BackColor = Color.White;
            b3.Visible = false;
            //4
            txtitemcode4.Visible = false;
            txtdescription4.Visible = false;
            txtbatch4.Visible = false;
            txtqtybatch4.Visible = false;
            txtsumtotal4.Visible = false;
            txtcode4.Visible = false;
            txttotalrepack4.Visible = false;
            txtqty4.Visible = false;
            txt4.Visible = false;
            lblnum4.Visible = false;
     
            txt4.BackColor = Color.White;
            b4.Visible = false;
            //5
            txtitemcode5.Visible = false;
            txtdescription5.Visible = false;
            txtbatch5.Visible = false;
            txtqtybatch5.Visible = false;
            txtsumtotal5.Visible = false;
            txtcode5.Visible = false;
            txttotalrepack5.Visible = false;
            txtqty5.Visible = false;
            txt5.Visible = false;
            lblnum5.Visible = false;
       
            txt5.BackColor = Color.White;
            b5.Visible = false;
            //6
            txtitemcode6.Visible = false;
            txtdescription6.Visible = false;
            txtbatch6.Visible = false;
            txtqtybatch6.Visible = false;
            txtsumtotal6.Visible = false;
            txtcode6.Visible = false;
            txttotalrepack6.Visible = false;
            txtqty6.Visible = false;
            txt6.Visible = false;
            lblnum6.Visible = false;
         
            txt6.BackColor = Color.White;
            b6.Visible = false;
            //7
            txtitemcode7.Visible = false;
            txtdescription7.Visible = false;
            txtbatch7.Visible = false;
            txtqtybatch7.Visible = false;
            txtsumtotal7.Visible = false;
            txtcode7.Visible = false;
            txttotalrepack7.Visible = false;
            txtqty7.Visible = false;
            txt7.Visible = false;
            lblnum7.Visible = false;
       
            txt7.BackColor = Color.White;
            b7.Visible = false;
            //8
            txtitemcode8.Visible = false;
            txtdescription8.Visible = false;
            txtbatch8.Visible = false;
            txtqtybatch8.Visible = false;
            txtsumtotal8.Visible = false;
            txtcode8.Visible = false;
            txttotalrepack8.Visible = false;
            txtqty8.Visible = false;
            txt8.Visible = false;
            lblnum8.Visible = false;
    
            txt8.BackColor = Color.White;
            b8.Visible = false;
            //9
            txtitemcode9.Visible = false;
            txtdescription9.Visible = false;
            txtbatch9.Visible = false;
            txtqtybatch9.Visible = false;
            txtsumtotal9.Visible = false;
            txtcode9.Visible = false;
            txttotalrepack9.Visible = false;
            txtqty9.Visible = false;
            txt9.Visible = false;
            lblnum9.Visible = false;
      
            txt9.BackColor = Color.White;
            b9.Visible = false;
            //10
            txtitemcode10.Visible = false;
            txtdescription10.Visible = false;
            txtbatch10.Visible = false;
            txtqtybatch10.Visible = false;
            txtsumtotal10.Visible = false;
            txtcode10.Visible = false;
            txttotalrepack10.Visible = false;
            txtqty10.Visible = false;
            txt10.Visible = false;
            lblnum10.Visible = false;

            txt10.BackColor = Color.White;
            b10.Visible = false;
            //11
            txtitemcode11.Visible = false;
            txtdescription11.Visible = false;
            txtbatch11.Visible = false;
            txtqtybatch11.Visible = false;
            txtsumtotal11.Visible = false;
            txtcode11.Visible = false;
            txttotalrepack11.Visible = false;
            txtqty11.Visible = false;
            txt11.Visible = false;
            lblnum11.Visible = false;

            txt11.BackColor = Color.White;
            b11.Visible = false;
            //12
            txtitemcode12.Visible = false;
            txtdescription12.Visible = false;
            txtbatch12.Visible = false;
            txtqtybatch12.Visible = false;
            txtsumtotal12.Visible = false;
            txtcode12.Visible = false;
            txttotalrepack12.Visible = false;
            txtqty12.Visible = false;
            txt12.Visible = false;
            lblnum12.Visible = false;
       
            txt12.BackColor = Color.White;
            b12.Visible = false;
            //13

            txtitemcode13.Visible = false;
            txtdescription13.Visible = false;
            txtbatch13.Visible = false;
            txtqtybatch13.Visible = false;
            txtsumtotal13.Visible = false;
            txtcode13.Visible = false;
            txttotalrepack13.Visible = false;
            txtqty13.Visible = false;
            txt13.Visible = false;
            lblnum13.Visible = false;
   
            txt13.BackColor = Color.White;
            b13.Visible = false;
            //14
            txtitemcode14.Visible = false;
            txtdescription14.Visible = false;
            txtbatch14.Visible = false;
            txtqtybatch14.Visible = false;
            txtsumtotal14.Visible = false;
            txtcode14.Visible = false;
            txttotalrepack14.Visible = false;
            txtqty14.Visible = false;
            txt14.Visible = false;
            lblnum14.Visible = false;
         
            txt14.BackColor = Color.White;
            b14.Visible = false;
            //15
            txtitemcode15.Visible = false;
            txtdescription15.Visible = false;
            txtbatch15.Visible = false;
            txtqtybatch15.Visible = false;
            txtsumtotal15.Visible = false;
            txtcode15.Visible = false;
            txttotalrepack15.Visible = false;
            txtqty15.Visible = false;
            txt15.Visible = false;
            lblnum15.Visible = false;

            txt15.BackColor = Color.White;
            b15.Visible = false;
            calldisable();

            //16
            txtitemcode16.Visible = false;
            txtdescription16.Visible = false;
            txtbatch16.Visible = false;
            txtqtybatch16.Visible = false;
            txtsumtotal16.Visible = false;
            txtcode16.Visible = false;
            txttotalrepack16.Visible = false;
            txtqty16.Visible = false;
            txt16.Visible = false;
            lblnum16.Visible = false;
 
            txt16.BackColor = Color.White;
            b16.Visible = false;
            //17
            txtitemcode17.Visible = false;
            txtdescription17.Visible = false;
            txtbatch17.Visible = false;
            txtqtybatch17.Visible = false;
            txtsumtotal17.Visible = false;
            txtcode17.Visible = false;
            txttotalrepack17.Visible = false;
            txtqty17.Visible = false;
            txt17.Visible = false;
            lblnum17.Visible = false;
     
            txt17.BackColor = Color.White;
            b17.Visible = false;
            //18
            txtitemcode18.Visible = false;
            txtdescription18.Visible = false;
            txtbatch18.Visible = false;
            txtqtybatch18.Visible = false;
            txtsumtotal18.Visible = false;
            txtcode18.Visible = false;
            txttotalrepack18.Visible = false;
            txtqty18.Visible = false;
            txt18.Visible = false;
            lblnum18.Visible = false;

            txt18.BackColor = Color.White;
            b18.Visible = false;
            //19
            txtitemcode19.Visible = false;
            txtdescription19.Visible = false;
            txtbatch19.Visible = false;
            txtqtybatch19.Visible = false;
            txtsumtotal19.Visible = false;
            txtcode19.Visible = false;
            txttotalrepack19.Visible = false;
            txtqty19.Visible = false;
            txt19.Visible = false;
            lblnum19.Visible = false;
 
            txt19.BackColor = Color.White;
            b19.Visible = false;
            //20
            txtitemcode20.Visible = false;
            txtdescription20.Visible = false;
            txtbatch20.Visible = false;
            txtqtybatch20.Visible = false;
            txtsumtotal20.Visible = false;
            txtcode20.Visible = false;
            txttotalrepack20.Visible = false;
            txtqty20.Visible = false;
            txt20.Visible = false;
            lblnum20.Visible = false;
 
            txt20.BackColor = Color.White;
            b20.Visible = false;
            //21
            txtitemcode21.Visible = false;
            txtdescription21.Visible = false;
            txtbatch21.Visible = false;
            txtqtybatch21.Visible = false;
            txtsumtotal21.Visible = false;
            txtcode21.Visible = false;
            txttotalrepack21.Visible = false;
            txtqty21.Visible = false;
            txt21.Visible = false;
            lblnum21.Visible = false;
  
            txt21.BackColor = Color.White;
            b21.Visible = false;
            //22
            txtitemcode22.Visible = false;
            txtdescription22.Visible = false;
            txtbatch22.Visible = false;
            txtqtybatch22.Visible = false;
            txtsumtotal22.Visible = false;
            txtcode22.Visible = false;
            txttotalrepack22.Visible = false;
            txtqty22.Visible = false;
            txt22.Visible = false;
            lblnum22.Visible = false;
     
            txt22.BackColor = Color.White;
            b22.Visible = false;
            //23
            txtitemcode23.Visible = false;
            txtdescription23.Visible = false;
            txtbatch23.Visible = false;
            txtqtybatch23.Visible = false;
            txtsumtotal23.Visible = false;
            txtcode23.Visible = false;
            txttotalrepack23.Visible = false;
            txtqty23.Visible = false;
            txt23.Visible = false;
            lblnum23.Visible = false;
       
            txt23.BackColor = Color.White;
            b23.Visible = false;
            //24
            txtitemcode24.Visible = false;
            txtdescription24.Visible = false;
            txtbatch24.Visible = false;
            txtqtybatch24.Visible = false;
            txtsumtotal24.Visible = false;
            txtcode24.Visible = false;
            txttotalrepack24.Visible = false;
            txtqty24.Visible = false;
            txt24.Visible = false;
            lblnum24.Visible = false;
         
            txt24.BackColor = Color.White;
            b24.Visible = false;
            //25

            txtitemcode25.Visible = false;
            txtdescription25.Visible = false;
            txtbatch25.Visible = false;
            txtqtybatch25.Visible = false;
            txtsumtotal250.Visible = false;
            txtcode25.Visible = false;
            txttotalrepack25.Visible = false;
            txtqty25.Visible = false;
            txt25.Visible = false;
            lblnum25.Visible = false;
       
            txt25.BackColor = Color.White;
            b25.Visible = false;

            ////lbltotalread.Text = "0";
            ////BtnSave.Visible = false;
            ////txt1.Enabled = true;
            ////txt1.Focus();
            ////txt1.Select();
        }
        private void bunifuThinButton266_Click(object sender, EventArgs e)
        {

        }

        private void bunifuMinimized_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void metroClose_Click(object sender, EventArgs e)
        {

            if (MetroFramework.MetroMessageBox.Show(this, "Data will not be save, are you sure you want to Exit ? ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {

                return;
            }
            }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvMaster_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvMaster_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Check the value of the e.ColumnIndex property if you want to apply this formatting only so some rcolumns.
            if (e.Value != null)
            {
                e.Value = e.Value.ToString().ToUpper();
                e.FormattingApplied = true;
            }
        }

        private void dgvMaster_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //var grid = sender as DataGridView;
            //var rowIdx = (e.RowIndex + 1).ToString();

            //var centerFormat = new StringFormat()
            //{
            //    // right alignment might actually make more sense for numbers
            //    Alignment = StringAlignment.Center,
            //    LineAlignment = StringAlignment.Center
            //};

            //var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            //e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void dgvImport_CurrentCellChanged(object sender, EventArgs e)
        {
            ready = true;
            showImportDataGrid2();
        }

        void showImportDataGrid2()
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

                    }
                }
            }
        }

        private void txtItemCode_TextChanged(object sender, EventArgs e)
        {
            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=hr_bak;Integrated Security=SSPI";
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "select item_id,item_code,item_description,total_quantity_raw,qty_repack_available,qty_repack,qty_production,active_qty_repack from [dbo].[rdf_raw_materials] WHERE item_code = '" + txtItemCode.Text + "'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvMaster2.DataSource = dt;
            //dgvMaster.Visible = true;
            ////dgv_table_2nd_sup.Visible = true;
            //lblmicroview.Visible = true;
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
                        txtrepackavailable.Text = dgvMaster2.CurrentRow.Cells["qty_repack"].Value.ToString();

                      txtactiveqtyrepack.Text = dgvMaster2.CurrentRow.Cells["active_qty_repack"].Value.ToString();
                    }
                }
            }
        }
        //jessa
        void QueryOutProduction()
        {

            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=hr_bak;Integrated Security=SSPI";
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "UPDATE [dbo].[rdf_raw_materials] SET qty_repack='" + txtdeductions.Text + "', active_qty_repack='"+txtsubstractrepack.Text+"'  WHERE item_code= '" + txtItemCode.Text + "'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgv1stView.DataSource = dt;
         
            sql_con.Close();
        }
        void QueryOutRepacking()
        {

            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=hr_bak;Integrated Security=SSPI";
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            SqlConnection sql_con = new SqlConnection(connetionString);

            string sqlquery = "UPDATE [dbo].[rdf_repackin_entry] SET is_prepared='1'  WHERE rp_item_code= '" + txtItemCode.Text + "' AND prod_id_repack='" + txtmasterid.Text + "' AND rp_batch='" + txtnobatch.Text + "' AND rp_item_category='MICRO'";

            //string sqlquery = "UPDATE [dbo].[rdf_repackin_entry] SET is_prepared='1'  WHERE rp_item_code= '" + txtItemCode.Text + "' AND repack_id='"+txtscanid.Text+"' AND rp_batch='"+txtnobatch.Text+"'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvView.DataSource = dt;

            sql_con.Close();
        }
        private void btnRollback_Click(object sender, EventArgs e)
        {
            txttotalQty.Text = (float.Parse(txtQuantity.Text) * float.Parse(txtnobatch.Text)).ToString();
            double rp1;
            double rp2;
            double rpavailable;

            rp1 = double.Parse(txtrepackavailable.Text);
            rp2 = double.Parse(txttotalQty.Text);

            rpavailable = rp1 - rp2;


            txtdeductions.Text = Convert.ToString(rpavailable);
      txtsubstractrepack.Text = (float.Parse(txtactiveqtyrepack.Text) - 1).ToString();
            //WithBalanceNotify(); alis muna 4 / 13 / 2020
            QueryOutProduction();
            QueryOutRepacking();
            txtdeductions.Text = "";
            btnlessthan3_Click(sender, e);
        }

        private void btnlessthan3_Click(object sender, EventArgs e)
        {


            if (dgvImport.Rows.Count >= 1)
            {
                int i = dgvImport.CurrentRow.Index + 1;
                if (i >= -1 && i < dgvImport.Rows.Count)
                    dgvImport.CurrentCell = dgvImport.Rows[i].Cells[0];
                else
                {

                    //MessageBox.Show("Finish  Cancel"); Remove na 4/14/2020

                    //btngreaterthan_Click(sender, e); remove muna 5/6/2020 bujerard

                    //ForApproval();
                    //Approved();
                    //bunifuThinButton26_Click(sender, e);
                    return;
                }
            }


    
            txttotalQty.Text = (float.Parse(txtQuantity.Text) * float.Parse(txtnobatch.Text)).ToString();

            double rp1;
            double rp2;
            double rpavailables;

            rp1 = double.Parse(txtrepackavailable.Text);
            rp2 = double.Parse(txttotalQty.Text);

            rpavailables = rp1 - rp2;
            txtdeductions.Text = Convert.ToString(rpavailables);
            txtsubstractrepack.Text = (float.Parse(txtactiveqtyrepack.Text) - 1).ToString();
            //WithBalanceNotify();
            QueryOutProduction();
            QueryOutRepacking();
            txtdeductions.Text = "";
            btnRollback_Click(sender, e);
            //MessageBox.Show("1");
            //}
            //else


            //{
        }

        private void txttotalQty_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtsumtotalactive_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnSave_Click_1(object sender, EventArgs e)
        {
            metroButton3_Click(sender, e);
        }
        void checking()
        {
     
            if(lbltotalread.Text=="0")
            {
                lbltotalread.Text = "1";
            }
            else if(lbltotalread.Text=="1")
            {
                lbltotalread.Text = "2";
                col2();
            }
            else if (lbltotalread.Text == "2")
            {
                lbltotalread.Text = "3";
                col3();
            }

            else
            {
                MessageBox.Show("Sabog!");
                return;
            }






        }

        private void btnShow_Click(object sender, EventArgs e)
        {

            if (lblCounts.Text == lbltotalcounts.Text)
            {

                //bunifuStart.Enabled = false;

                //btnShow_Click(sender, e);
                txtBarcode.Enabled = true;
                txtBarcode.Select();
                txtBarcode.Focus();
            }
            else
            {

                //bunifuStart.Enabled = true;
                //bunifuStart.Enabled = false;
                RepackRawMatsFirst();
                txt1.Enabled = false;
                txtBarcode.Enabled = false;
                return;
            }




            if (lbltotalread.Text == "0")
            {
                lbltotalread.Text = "1";


                btnclickme_Click(sender, e);

            }
            else if (lbltotalread.Text == "1")
            {

                //lbltotalread.Text = "2";
                if (txt2.Text.Trim() == string.Empty)
                {
                    bunifuThinButton2125_Click(sender, e);
                    lbltotalread.Text = "2";

                    Dochecking();
                    txt1.Enabled = false;
                    button1.Enabled = false;


                    //txt2.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                    //txtcode2.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                    //txttotalrepack2.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

           
                    if (lblCounts.Text == lbltotalread.Text)
                    {
                        this.dgv1stView.CurrentCell = this.dgv1stView.Rows[0].Cells[this.dgv1stView.CurrentCell.ColumnIndex];
                        return;
                    }
                    txtitemcode2.Text = dgv1stView.CurrentRow.Cells["item_code"].Value.ToString();
                    txtdescription2.Text = dgv1stView.CurrentRow.Cells["rp_description"].Value.ToString();
                    txtbatch2.Text = dgv1stView.CurrentRow.Cells["p_nobatch"].Value.ToString();
                    txtqty2.Text = dgv1stView.CurrentRow.Cells["quantity1"].Value.ToString();
                    col2();
                    btnclickme_Click(sender, e);
                    return;
                }

              
            }
            else if (lbltotalread.Text == "2")
            {

                //lbltotalread.Text = "2";
                if (txt3.Text.Trim() == string.Empty)
                {
                    bunifuThinButton2125_Click(sender, e);
                    lbltotalread.Text = "3";

                    Dochecking();
                    txt1.Enabled = false;
                    button1.Enabled = false;


                    //txt2.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                    //txtcode2.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                    //txttotalrepack2.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                    txtitemcode3.Text = dgv1stView.CurrentRow.Cells["item_code"].Value.ToString();
                    txtdescription3.Text = dgv1stView.CurrentRow.Cells["rp_description"].Value.ToString();
                    txtbatch3.Text = dgv1stView.CurrentRow.Cells["p_nobatch"].Value.ToString();
                    txtqty3.Text = dgv1stView.CurrentRow.Cells["quantity1"].Value.ToString();
                    col3();
                    if (lblCounts.Text == lbltotalread.Text)
                    {
                        this.dgv1stView.CurrentCell = this.dgv1stView.Rows[0].Cells[this.dgv1stView.CurrentCell.ColumnIndex];
                        return;
                    }

                    btnclickme_Click(sender, e);
                    return;
                }

            }
            else if (lbltotalread.Text == "3")
            {

                if (txt4.Text.Trim() == string.Empty)
                {
                    bunifuThinButton2125_Click(sender, e);
                    lbltotalread.Text = "4";

                    Dochecking();
                    txt1.Enabled = false;
                    button1.Enabled = false;


                    //txt2.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                    //txtcode2.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                    //txttotalrepack2.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                    txtitemcode4.Text = dgv1stView.CurrentRow.Cells["item_code"].Value.ToString();
                    txtdescription4.Text = dgv1stView.CurrentRow.Cells["rp_description"].Value.ToString();
                    txtbatch4.Text = dgv1stView.CurrentRow.Cells["p_nobatch"].Value.ToString();
                    txtqty4.Text = dgv1stView.CurrentRow.Cells["quantity1"].Value.ToString();
                    col4();
                    if (lblCounts.Text == lbltotalread.Text)
                    {
                        this.dgv1stView.CurrentCell = this.dgv1stView.Rows[0].Cells[this.dgv1stView.CurrentCell.ColumnIndex];
                        return;
                    }

                    btnclickme_Click(sender, e);
                    return;
                }
            }
            else if (lbltotalread.Text == "4")
            {

                if (txt5.Text.Trim() == string.Empty)
                {
                    bunifuThinButton2125_Click(sender, e);
                    lbltotalread.Text = "5";

                    Dochecking();
                    txt1.Enabled = false;
                    button1.Enabled = false;


                    //txt2.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                    //txtcode2.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                    //txttotalrepack2.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                    txtitemcode5.Text = dgv1stView.CurrentRow.Cells["item_code"].Value.ToString();
                    txtdescription5.Text = dgv1stView.CurrentRow.Cells["rp_description"].Value.ToString();
                    txtbatch5.Text = dgv1stView.CurrentRow.Cells["p_nobatch"].Value.ToString();
                    txtqty5.Text = dgv1stView.CurrentRow.Cells["quantity1"].Value.ToString();
                    col5();
                    if (lblCounts.Text == lbltotalread.Text)
                    {
                        this.dgv1stView.CurrentCell = this.dgv1stView.Rows[0].Cells[this.dgv1stView.CurrentCell.ColumnIndex];
                        return;
                    }

                    btnclickme_Click(sender, e);
                    return;
                }
            }
            else if (lbltotalread.Text == "5")
            {

                if (txt6.Text.Trim() == string.Empty)
                {
                    bunifuThinButton2125_Click(sender, e);
                    lbltotalread.Text = "6";

                    Dochecking();
                    txt1.Enabled = false;
                    button1.Enabled = false;


                    //txt2.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                    //txtcode2.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                    //txttotalrepack2.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                    txtitemcode6.Text = dgv1stView.CurrentRow.Cells["item_code"].Value.ToString();
                    txtdescription6.Text = dgv1stView.CurrentRow.Cells["rp_description"].Value.ToString();
                    txtbatch6.Text = dgv1stView.CurrentRow.Cells["p_nobatch"].Value.ToString();
                    txtqty6.Text = dgv1stView.CurrentRow.Cells["quantity1"].Value.ToString();
                    col6();
                    if (lblCounts.Text == lbltotalread.Text)
                    {
                        this.dgv1stView.CurrentCell = this.dgv1stView.Rows[0].Cells[this.dgv1stView.CurrentCell.ColumnIndex];
                        return;
                    }

                    btnclickme_Click(sender, e);
                    return;
                }
            }
            else if (lbltotalread.Text == "6")
            {

                if (txt7.Text.Trim() == string.Empty)
                {
                    bunifuThinButton2125_Click(sender, e);
                    lbltotalread.Text = "7";

                    Dochecking();
                    txt1.Enabled = false;
                    button1.Enabled = false;


                    //txt2.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                    //txtcode2.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                    //txttotalrepack2.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                    txtitemcode7.Text = dgv1stView.CurrentRow.Cells["item_code"].Value.ToString();
                    txtdescription7.Text = dgv1stView.CurrentRow.Cells["rp_description"].Value.ToString();
                    txtbatch7.Text = dgv1stView.CurrentRow.Cells["p_nobatch"].Value.ToString();
                    txtqty7.Text = dgv1stView.CurrentRow.Cells["quantity1"].Value.ToString();
                    col7();
                    if (lblCounts.Text == lbltotalread.Text)
                    {
                        this.dgv1stView.CurrentCell = this.dgv1stView.Rows[0].Cells[this.dgv1stView.CurrentCell.ColumnIndex];
                        return;
                    }

                    btnclickme_Click(sender, e);
                    return;
                }
            }
            else if (lbltotalread.Text == "7")
            {

                if (txt8.Text.Trim() == string.Empty)
                {
                    bunifuThinButton2125_Click(sender, e);
                    lbltotalread.Text = "8";

                    Dochecking();
                    txt1.Enabled = false;
                    button1.Enabled = false;


                    //txt2.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                    //txtcode2.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                    //txttotalrepack2.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                    txtitemcode8.Text = dgv1stView.CurrentRow.Cells["item_code"].Value.ToString();
                    txtdescription8.Text = dgv1stView.CurrentRow.Cells["rp_description"].Value.ToString();
                    txtbatch8.Text = dgv1stView.CurrentRow.Cells["p_nobatch"].Value.ToString();
                    txtqty8.Text = dgv1stView.CurrentRow.Cells["quantity1"].Value.ToString();
                    col8();
                    if (lblCounts.Text == lbltotalread.Text)
                    {
                        this.dgv1stView.CurrentCell = this.dgv1stView.Rows[0].Cells[this.dgv1stView.CurrentCell.ColumnIndex];
                        return;
                    }

                    btnclickme_Click(sender, e);
                    return;
                }
            }
            else if (lbltotalread.Text == "8")
            {

                if (txt9.Text.Trim() == string.Empty)
                {
                    bunifuThinButton2125_Click(sender, e);
                    lbltotalread.Text = "9";

                    Dochecking();
                    txt1.Enabled = false;
                    button1.Enabled = false;


                    //txt2.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                    //txtcode2.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                    //txttotalrepack2.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                    txtitemcode9.Text = dgv1stView.CurrentRow.Cells["item_code"].Value.ToString();
                    txtdescription9.Text = dgv1stView.CurrentRow.Cells["rp_description"].Value.ToString();
                    txtbatch9.Text = dgv1stView.CurrentRow.Cells["p_nobatch"].Value.ToString();
                    txtqty9.Text = dgv1stView.CurrentRow.Cells["quantity1"].Value.ToString();
                    col9();
                    if (lblCounts.Text == lbltotalread.Text)
                    {
                        this.dgv1stView.CurrentCell = this.dgv1stView.Rows[0].Cells[this.dgv1stView.CurrentCell.ColumnIndex];
                        return;
                    }

                    btnclickme_Click(sender, e);
                    return;
                }
            }
            else if (lbltotalread.Text == "9")
            {

                if (txt10.Text.Trim() == string.Empty)
                {
                    bunifuThinButton2125_Click(sender, e);
                    lbltotalread.Text = "10";

                    Dochecking();
                    txt1.Enabled = false;
                    button1.Enabled = false;


                    //txt2.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                    //txtcode2.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                    //txttotalrepack2.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                    txtitemcode10.Text = dgv1stView.CurrentRow.Cells["item_code"].Value.ToString();
                    txtdescription10.Text = dgv1stView.CurrentRow.Cells["rp_description"].Value.ToString();
                    txtbatch10.Text = dgv1stView.CurrentRow.Cells["p_nobatch"].Value.ToString();
                    txtqty10.Text = dgv1stView.CurrentRow.Cells["quantity1"].Value.ToString();
                    col10();
                    if (lblCounts.Text == lbltotalread.Text)
                    {
                        this.dgv1stView.CurrentCell = this.dgv1stView.Rows[0].Cells[this.dgv1stView.CurrentCell.ColumnIndex];
                        return;
                    }

                    btnclickme_Click(sender, e);
                    return;
                }
            }
            else if (lbltotalread.Text == "10")
            {

                if (txt11.Text.Trim() == string.Empty)
                {
                    bunifuThinButton2125_Click(sender, e);
                    lbltotalread.Text = "11";

                    Dochecking();
                    txt1.Enabled = false;
                    button1.Enabled = false;


                    //txt2.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                    //txtcode2.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                    //txttotalrepack2.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                    txtitemcode11.Text = dgv1stView.CurrentRow.Cells["item_code"].Value.ToString();
                    txtdescription11.Text = dgv1stView.CurrentRow.Cells["rp_description"].Value.ToString();
                    txtbatch11.Text = dgv1stView.CurrentRow.Cells["p_nobatch"].Value.ToString();
                    txtqty11.Text = dgv1stView.CurrentRow.Cells["quantity1"].Value.ToString();
                    col11();
                    if (lblCounts.Text == lbltotalread.Text)
                    {
                        this.dgv1stView.CurrentCell = this.dgv1stView.Rows[0].Cells[this.dgv1stView.CurrentCell.ColumnIndex];
                        return;
                    }

                    btnclickme_Click(sender, e);
                    return;
                }
            }
            else if (lbltotalread.Text == "11")
            {

                if (txt12.Text.Trim() == string.Empty)
                {
                    bunifuThinButton2125_Click(sender, e);
                    lbltotalread.Text = "12";

                    Dochecking();
                    txt1.Enabled = false;
                    button1.Enabled = false;


                    //txt2.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                    //txtcode2.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                    //txttotalrepack2.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                    txtitemcode12.Text = dgv1stView.CurrentRow.Cells["item_code"].Value.ToString();
                    txtdescription12.Text = dgv1stView.CurrentRow.Cells["rp_description"].Value.ToString();
                    txtbatch12.Text = dgv1stView.CurrentRow.Cells["p_nobatch"].Value.ToString();
                    txtqty12.Text = dgv1stView.CurrentRow.Cells["quantity1"].Value.ToString();
                    col12();
                    if (lblCounts.Text == lbltotalread.Text)
                    {
                        this.dgv1stView.CurrentCell = this.dgv1stView.Rows[0].Cells[this.dgv1stView.CurrentCell.ColumnIndex];
                        return;
                    }

                    btnclickme_Click(sender, e);
                    return;
                }
            }
            else if (lbltotalread.Text == "12")
            {

                if (txt12.Text.Trim() == string.Empty)
                {
                    bunifuThinButton2125_Click(sender, e);
                    lbltotalread.Text = "13";

                    Dochecking();
                    txt1.Enabled = false;
                    button1.Enabled = false;


                    //txt2.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                    //txtcode2.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                    //txttotalrepack2.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                    txtitemcode13.Text = dgv1stView.CurrentRow.Cells["item_code"].Value.ToString();
                    txtdescription13.Text = dgv1stView.CurrentRow.Cells["rp_description"].Value.ToString();
                    txtbatch13.Text = dgv1stView.CurrentRow.Cells["p_nobatch"].Value.ToString();
                    txtqty13.Text = dgv1stView.CurrentRow.Cells["quantity1"].Value.ToString();
                    col13();
                    if (lblCounts.Text == lbltotalread.Text)
                    {
                        this.dgv1stView.CurrentCell = this.dgv1stView.Rows[0].Cells[this.dgv1stView.CurrentCell.ColumnIndex];
                        return;
                    }

                    btnclickme_Click(sender, e);
                    return;
                }
            }
            else if (lbltotalread.Text == "13")
            {

                if (txt14.Text.Trim() == string.Empty)
                {
                    bunifuThinButton2125_Click(sender, e);
                    lbltotalread.Text = "14";

                    Dochecking();
                    txt1.Enabled = false;
                    button1.Enabled = false;


                    //txt2.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                    //txtcode2.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                    //txttotalrepack2.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                    txtitemcode14.Text = dgv1stView.CurrentRow.Cells["item_code"].Value.ToString();
                    txtdescription14.Text = dgv1stView.CurrentRow.Cells["rp_description"].Value.ToString();
                    txtbatch14.Text = dgv1stView.CurrentRow.Cells["p_nobatch"].Value.ToString();
                    txtqty14.Text = dgv1stView.CurrentRow.Cells["quantity1"].Value.ToString();
                    col14();
                    if (lblCounts.Text == lbltotalread.Text)
                    {
                        this.dgv1stView.CurrentCell = this.dgv1stView.Rows[0].Cells[this.dgv1stView.CurrentCell.ColumnIndex];
                        return;
                    }

                    btnclickme_Click(sender, e);
                    return;
                }
            }
            else if (lbltotalread.Text == "14")
            {

                if (txt15.Text.Trim() == string.Empty)
                {
                    bunifuThinButton2125_Click(sender, e);
                    lbltotalread.Text = "15";

                    Dochecking();
                    txt1.Enabled = false;
                    button1.Enabled = false;


                    //txt2.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                    //txtcode2.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                    //txttotalrepack2.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                    txtitemcode15.Text = dgv1stView.CurrentRow.Cells["item_code"].Value.ToString();
                    txtdescription15.Text = dgv1stView.CurrentRow.Cells["rp_description"].Value.ToString();
                    txtbatch15.Text = dgv1stView.CurrentRow.Cells["p_nobatch"].Value.ToString();
                    txtqty15.Text = dgv1stView.CurrentRow.Cells["quantity1"].Value.ToString();
                    col15();
                    if (lblCounts.Text == lbltotalread.Text)
                    {
                        this.dgv1stView.CurrentCell = this.dgv1stView.Rows[0].Cells[this.dgv1stView.CurrentCell.ColumnIndex];
                        return;
                    }

                    btnclickme_Click(sender, e);
                    return;
                }
            }
            else if (lbltotalread.Text == "15")
            {

                if (txt16.Text.Trim() == string.Empty)
                {
                    bunifuThinButton2125_Click(sender, e);
                    lbltotalread.Text = "16";

                    Dochecking();
                    txt1.Enabled = false;
                    button1.Enabled = false;


                    //txt2.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                    //txtcode2.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                    //txttotalrepack2.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                    txtitemcode16.Text = dgv1stView.CurrentRow.Cells["item_code"].Value.ToString();
                    txtdescription16.Text = dgv1stView.CurrentRow.Cells["rp_description"].Value.ToString();
                    txtbatch16.Text = dgv1stView.CurrentRow.Cells["p_nobatch"].Value.ToString();
                    txtqty16.Text = dgv1stView.CurrentRow.Cells["quantity1"].Value.ToString();
                    col16();

                    if(lblCounts.Text == lbltotalread.Text)
                    {
                        this.dgv1stView.CurrentCell = this.dgv1stView.Rows[0].Cells[this.dgv1stView.CurrentCell.ColumnIndex];
                        return;
                    }


                    btnclickme_Click(sender, e);
                    return;
                }
            }
            else if (lbltotalread.Text == "16")
            {

                if (txt17.Text.Trim() == string.Empty)
                {
                    bunifuThinButton2125_Click(sender, e);
                    lbltotalread.Text = "17";

                    Dochecking();
                    txt1.Enabled = false;
                    button1.Enabled = false;


                    //txt2.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                    //txtcode2.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                    //txttotalrepack2.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                    txtitemcode17.Text = dgv1stView.CurrentRow.Cells["item_code"].Value.ToString();
                    txtdescription17.Text = dgv1stView.CurrentRow.Cells["rp_description"].Value.ToString();
                    txtbatch17.Text = dgv1stView.CurrentRow.Cells["p_nobatch"].Value.ToString();
                    txtqty17.Text = dgv1stView.CurrentRow.Cells["quantity1"].Value.ToString();
                    col17();

                    if (lblCounts.Text == lbltotalread.Text)
                    {
                        this.dgv1stView.CurrentCell = this.dgv1stView.Rows[0].Cells[this.dgv1stView.CurrentCell.ColumnIndex];
                        return;
                    }

                    btnclickme_Click(sender, e);
                    return;
                }
            }
            else if (lbltotalread.Text == "17")
            {

                if (txt18.Text.Trim() == string.Empty)
                {
                    bunifuThinButton2125_Click(sender, e);
                    lbltotalread.Text = "18";

                    Dochecking();
                    txt1.Enabled = false;
                    button1.Enabled = false;


                    //txt2.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                    //txtcode2.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                    //txttotalrepack2.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                    txtitemcode18.Text = dgv1stView.CurrentRow.Cells["item_code"].Value.ToString();
                    txtdescription18.Text = dgv1stView.CurrentRow.Cells["rp_description"].Value.ToString();
                    txtbatch18.Text = dgv1stView.CurrentRow.Cells["p_nobatch"].Value.ToString();
                    txtqty18.Text = dgv1stView.CurrentRow.Cells["quantity1"].Value.ToString();
                    col18();

                    if (lblCounts.Text == lbltotalread.Text)
                    {
                        this.dgv1stView.CurrentCell = this.dgv1stView.Rows[0].Cells[this.dgv1stView.CurrentCell.ColumnIndex];
                        return;
                    }

                    btnclickme_Click(sender, e);
                    return;
                }
            }
            else if (lbltotalread.Text == "18")
            {

                if (txt19.Text.Trim() == string.Empty)
                {
                    bunifuThinButton2125_Click(sender, e);
                    lbltotalread.Text = "19";

                    Dochecking();
                    txt1.Enabled = false;
                    button1.Enabled = false;


                    //txt2.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                    //txtcode2.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                    //txttotalrepack2.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                    txtitemcode19.Text = dgv1stView.CurrentRow.Cells["item_code"].Value.ToString();
                    txtdescription19.Text = dgv1stView.CurrentRow.Cells["rp_description"].Value.ToString();
                    txtbatch19.Text = dgv1stView.CurrentRow.Cells["p_nobatch"].Value.ToString();
                    txtqty19.Text = dgv1stView.CurrentRow.Cells["quantity1"].Value.ToString();
                    col19();

                    if (lblCounts.Text == lbltotalread.Text)
                    {
                        this.dgv1stView.CurrentCell = this.dgv1stView.Rows[0].Cells[this.dgv1stView.CurrentCell.ColumnIndex];
                        return;
                    }

                    btnclickme_Click(sender, e);
                    return;
                }
            }
            else if (lbltotalread.Text == "19")
            {

                if (txt20.Text.Trim() == string.Empty)
                {
                    bunifuThinButton2125_Click(sender, e);
                    lbltotalread.Text = "20";

                    Dochecking();
                    txt1.Enabled = false;
                    button1.Enabled = false;


                    //txt2.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                    //txtcode2.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                    //txttotalrepack2.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                    txtitemcode20.Text = dgv1stView.CurrentRow.Cells["item_code"].Value.ToString();
                    txtdescription20.Text = dgv1stView.CurrentRow.Cells["rp_description"].Value.ToString();
                    txtbatch20.Text = dgv1stView.CurrentRow.Cells["p_nobatch"].Value.ToString();
                    txtqty20.Text = dgv1stView.CurrentRow.Cells["quantity1"].Value.ToString();
                    col20();

                    if (lblCounts.Text == lbltotalread.Text)
                    {
                        this.dgv1stView.CurrentCell = this.dgv1stView.Rows[0].Cells[this.dgv1stView.CurrentCell.ColumnIndex];
                        return;
                    }

                    btnclickme_Click(sender, e);
                    return;
                }
            }
            else if (lbltotalread.Text == "20")
            {

                if (txt21.Text.Trim() == string.Empty)
                {
                    bunifuThinButton2125_Click(sender, e);
                    lbltotalread.Text = "21";

                    Dochecking();
                    txt1.Enabled = false;
                    button1.Enabled = false;


                    //txt2.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                    //txtcode2.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                    //txttotalrepack2.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                    txtitemcode21.Text = dgv1stView.CurrentRow.Cells["item_code"].Value.ToString();
                    txtdescription21.Text = dgv1stView.CurrentRow.Cells["rp_description"].Value.ToString();
                    txtbatch21.Text = dgv1stView.CurrentRow.Cells["p_nobatch"].Value.ToString();
                    txtqty21.Text = dgv1stView.CurrentRow.Cells["quantity1"].Value.ToString();
                    col21();

                    if (lblCounts.Text == lbltotalread.Text)
                    {
                        this.dgv1stView.CurrentCell = this.dgv1stView.Rows[0].Cells[this.dgv1stView.CurrentCell.ColumnIndex];
                        return;
                    }

                    btnclickme_Click(sender, e);
                    return;
                }
            }
            else if (lbltotalread.Text == "21")
            {

                if (txt22.Text.Trim() == string.Empty)
                {
                    bunifuThinButton2125_Click(sender, e);
                    lbltotalread.Text = "22";

                    Dochecking();
                    txt1.Enabled = false;
                    button1.Enabled = false;


                    //txt2.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                    //txtcode2.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                    //txttotalrepack2.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                    txtitemcode22.Text = dgv1stView.CurrentRow.Cells["item_code"].Value.ToString();
                    txtdescription22.Text = dgv1stView.CurrentRow.Cells["rp_description"].Value.ToString();
                    txtbatch22.Text = dgv1stView.CurrentRow.Cells["p_nobatch"].Value.ToString();
                    txtqty22.Text = dgv1stView.CurrentRow.Cells["quantity1"].Value.ToString();
                    col22();

                    if (lblCounts.Text == lbltotalread.Text)
                    {
                        this.dgv1stView.CurrentCell = this.dgv1stView.Rows[0].Cells[this.dgv1stView.CurrentCell.ColumnIndex];
                        return;
                    }

                    btnclickme_Click(sender, e);
                    return;
                }
            }
            else if (lbltotalread.Text == "22")
            {

                if (txt23.Text.Trim() == string.Empty)
                {
                    bunifuThinButton2125_Click(sender, e);
                    lbltotalread.Text = "23";

                    Dochecking();
                    txt1.Enabled = false;
                    button1.Enabled = false;


                    //txt2.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                    //txtcode2.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                    //txttotalrepack2.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                    txtitemcode23.Text = dgv1stView.CurrentRow.Cells["item_code"].Value.ToString();
                    txtdescription23.Text = dgv1stView.CurrentRow.Cells["rp_description"].Value.ToString();
                    txtbatch23.Text = dgv1stView.CurrentRow.Cells["p_nobatch"].Value.ToString();
                    txtqty23.Text = dgv1stView.CurrentRow.Cells["quantity1"].Value.ToString();
                    col23();

                    if (lblCounts.Text == lbltotalread.Text)
                    {
                        this.dgv1stView.CurrentCell = this.dgv1stView.Rows[0].Cells[this.dgv1stView.CurrentCell.ColumnIndex];
                        return;
                    }

                    btnclickme_Click(sender, e);
                    return;
                }
            }
            else if (lbltotalread.Text == "23")
            {

                if (txt24.Text.Trim() == string.Empty)
                {
                    bunifuThinButton2125_Click(sender, e);
                    lbltotalread.Text = "24";

                    Dochecking();
                    txt1.Enabled = false;
                    button1.Enabled = false;


                    //txt2.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                    //txtcode2.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                    //txttotalrepack2.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                    txtitemcode24.Text = dgv1stView.CurrentRow.Cells["item_code"].Value.ToString();
                    txtdescription24.Text = dgv1stView.CurrentRow.Cells["rp_description"].Value.ToString();
                    txtbatch24.Text = dgv1stView.CurrentRow.Cells["p_nobatch"].Value.ToString();
                    txtqty24.Text = dgv1stView.CurrentRow.Cells["quantity1"].Value.ToString();
                    col24();

                    if (lblCounts.Text == lbltotalread.Text)
                    {
                        this.dgv1stView.CurrentCell = this.dgv1stView.Rows[0].Cells[this.dgv1stView.CurrentCell.ColumnIndex];
                        return;
                    }

                    btnclickme_Click(sender, e);
                    return;
                }
            }
            else if (lbltotalread.Text == "24")
            {

                if (txt25.Text.Trim() == string.Empty)
                {
                    bunifuThinButton2125_Click(sender, e);
                    lbltotalread.Text = "25";

                    Dochecking();
                    txt1.Enabled = false;
                    button1.Enabled = false;


                    //txt2.Text = dgvrepackdb.CurrentRow.Cells["repack_id"].Value.ToString();
                    //txtcode2.Text = dgvrepackdb.CurrentRow.Cells["rp_item_code"].Value.ToString();
                    //txttotalrepack2.Text = dgvrepackdb.CurrentRow.Cells["total_repack"].Value.ToString();

                    txtitemcode25.Text = dgv1stView.CurrentRow.Cells["item_code"].Value.ToString();
                    txtdescription25.Text = dgv1stView.CurrentRow.Cells["rp_description"].Value.ToString();
                    txtbatch25.Text = dgv1stView.CurrentRow.Cells["p_nobatch"].Value.ToString();
                    txtqty25.Text = dgv1stView.CurrentRow.Cells["quantity1"].Value.ToString();
                    col25();

                    if (lblCounts.Text == lbltotalread.Text)
                    {
                        this.dgv1stView.CurrentCell = this.dgv1stView.Rows[0].Cells[this.dgv1stView.CurrentCell.ColumnIndex];
                        return;
                    }

                    btnclickme_Click(sender, e);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Sabog!");
                return;
            }


            //if (dgv1stView.Rows.Count >= 1)
            //{


            //    int i = dgv1stView.CurrentRow.Index + 1;
            //    if (i >= -1 && i < dgv1stView.Rows.Count)
            //        dgv1stView.CurrentCell = dgv1stView.Rows[i].Cells[1];



            //    //dgvMaster_Click(sender,e);
            //    else
            //    {
            //        LastLine();
            //        //txtselectweight.Text = dgvAllFeedCode.CurrentRow.Cells["Quantity"].Value.ToString();
            //        //timer1_Tick(sender, e);
            //        //txtweighingscale.Focus();

            //        //txtQuantity.Text = dgvImport.CurrentRow.Cells["quantity2"].Value.ToString();

            //        return;
            //    }
            //}









        }

        private void bunifuThinButton2125_Click(object sender, EventArgs e)
        {

            if (dgv1stView.Rows.Count >= 1)
            {


                int i = dgv1stView.CurrentRow.Index + 1;
                if (i >= -1 && i < dgv1stView.Rows.Count)
                    dgv1stView.CurrentCell = dgv1stView.Rows[i].Cells[1];



                //dgvMaster_Click(sender,e);
                else
                {
                    LastLine();
                    //txtselectweight.Text = dgvAllFeedCode.CurrentRow.Cells["Quantity"].Value.ToString();
                    //timer1_Tick(sender, e);
                    //txtweighingscale.Focus();

                    //txtQuantity.Text = dgvImport.CurrentRow.Cells["quantity2"].Value.ToString();

                    return;
                }
            }

        }

        void checkifNull()
        {


            if (txt1.Text.Trim() == txtBarcode.Text.Trim())
            {
                PreparedAlready();
                txtBarcode.Text = "";
                txtBarcode.Select();
                txtBarcode.Focus();
                return;
            }

            if (txt2.Text.Trim() == txtBarcode.Text.Trim())
            {
                PreparedAlready();
                txtBarcode.Text = "";
                txtBarcode.Select();
                txtBarcode.Focus();
                return;
            }
            if (txt3.Text.Trim() == txtBarcode.Text.Trim())
            {
                PreparedAlready();
                txtBarcode.Text = "";
                txtBarcode.Select();
                txtBarcode.Focus();
                return;
            }
            if (txt4.Text.Trim() == txtBarcode.Text.Trim())
            {
                PreparedAlready();
                txtBarcode.Text = "";
                txtBarcode.Select();
                txtBarcode.Focus();
                return;
            }
            if (txt5.Text.Trim() == txtBarcode.Text.Trim())
            {
                PreparedAlready();
                txtBarcode.Text = "";
                txtBarcode.Select();
                txtBarcode.Focus();
                return;
            }
            if (txt6.Text.Trim() == txtBarcode.Text.Trim())
            {
                PreparedAlready();
                txtBarcode.Text = "";
                txtBarcode.Select();
                txtBarcode.Focus();
                return;
            }
            if (txt7.Text.Trim() == txtBarcode.Text.Trim())
            {
                PreparedAlready();
                txtBarcode.Text = "";
                txtBarcode.Select();
                txtBarcode.Focus();
                return;
            }
            if (txt8.Text.Trim() == txtBarcode.Text.Trim())
            {
                PreparedAlready();
                txtBarcode.Text = "";
                txtBarcode.Select();
                txtBarcode.Focus();
                return;
            }
            if (txt9.Text.Trim() == txtBarcode.Text.Trim())
            {
                PreparedAlready();
                txtBarcode.Text = "";
                txtBarcode.Select();
                txtBarcode.Focus();
                return;
            }
            if (txt10.Text.Trim() == txtBarcode.Text.Trim())
            {
                PreparedAlready();
                txtBarcode.Text = "";
                txtBarcode.Select();
                txtBarcode.Focus();
                return;
            }
            if (txt11.Text.Trim() == txtBarcode.Text.Trim())
            {
                PreparedAlready();
                
                txtBarcode.Text = "";
                txtBarcode.Select();
                txtBarcode.Focus();
                return;
            }
            if (txt12.Text.Trim() == txtBarcode.Text.Trim())
            {
                PreparedAlready();
                txtBarcode.Text = "";
                txtBarcode.Select();
                txtBarcode.Focus();
                return;
            }
            if (txt13.Text.Trim() == txtBarcode.Text.Trim())
            {
                PreparedAlready();
                txtBarcode.Text = "";
                txtBarcode.Select();
                txtBarcode.Focus();
                return;
            }
            if (txt14.Text.Trim() == txtBarcode.Text.Trim())
            {
                PreparedAlready();
                txtBarcode.Text = "";
                txtBarcode.Select();
                txtBarcode.Focus();
                return;
            }
            if (txt15.Text.Trim() == txtBarcode.Text.Trim())
            {
                PreparedAlready();
                txtBarcode.Text = "";
                txtBarcode.Select();
                txtBarcode.Focus();
                return;
            }
            if (txt16.Text.Trim() == txtBarcode.Text.Trim())
            {
                PreparedAlready();
                txtBarcode.Text = "";
                txtBarcode.Select();
                txtBarcode.Focus();
                return;
            }
            if (txt17.Text.Trim() == txtBarcode.Text.Trim())
            {
                PreparedAlready();
                txtBarcode.Text = "";
                txtBarcode.Select();
                txtBarcode.Focus();
                return;
            }
            if (txt18.Text.Trim() == txtBarcode.Text.Trim())
            {
                PreparedAlready();
                txtBarcode.Text = "";
                txtBarcode.Select();
                txtBarcode.Focus();
                return;
            }
            if (txt19.Text.Trim() == txtBarcode.Text.Trim())
            {
                PreparedAlready();
                txtBarcode.Text = "";
                txtBarcode.Select();
                txtBarcode.Focus();
                return;
            }
            if (txt20.Text.Trim() == txtBarcode.Text.Trim())
            {
                PreparedAlready();
                txtBarcode.Text = "";
                txtBarcode.Select();
                txtBarcode.Focus();
                return;
            }
            if (txt21.Text.Trim() == txtBarcode.Text.Trim())
            {
                PreparedAlready();
                txtBarcode.Text = "";
                txtBarcode.Select();
                txtBarcode.Focus();
                return;
            }
            if (txt22.Text.Trim() == txtBarcode.Text.Trim())
            {
                PreparedAlready();
                txtBarcode.Text = "";
                txtBarcode.Select();
                txtBarcode.Focus();
                return;
            }
            if (txt23.Text.Trim() == txtBarcode.Text.Trim())
            {
                PreparedAlready();
                txtBarcode.Text = "";
                txtBarcode.Select();
                txtBarcode.Focus();
                return;
            }
            if (txt24.Text.Trim() == txtBarcode.Text.Trim())
            {
                PreparedAlready();
                txtBarcode.Text = "";
                txtBarcode.Select();
                txtBarcode.Focus();
                return;
            }
            if (txt25.Text.Trim() == txtBarcode.Text.Trim())
            {
                PreparedAlready();
                txtBarcode.Text = "";
                txtBarcode.Select();
                txtBarcode.Focus();
                return;
            }



        }
        private void btnclickme_Click(object sender, EventArgs e)
        {
            btnShow_Click(sender, e);
        }




        private void btnbarcode_Click(object sender, EventArgs e)
        {


            if (txtBarcode.Text.Trim() == string.Empty)
            {

                BarcodeNotFound();//4/18/2020

                txtBarcode.Select();
                txtBarcode.Focus();
                txtBarcode.BackColor = Color.Yellow;


                return;
            }


            dSet.Clear();

            dSet = objStorProc.rdf_sp_new_micro_repacking(0, "", "", "", "","", "","", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", txtBarcode.Text, "", "", "existing");

            if (dSet.Tables[0].Rows.Count > 0)
            {


            }
            else
            {
                RepackIdNotExists();
                txtBarcode.Text = "";
                txtBarcode.Focus();
                return;
            }



            //start
            dSet.Clear();

            dSet = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text, txtmainfeedcode.Text, label24.Text, "", "", "", "", "", "", "", txtBarcode.Text, "", "", "", "", "", "", "existsornot");

            if (dSet.Tables[0].Rows.Count > 0)
            {

                RepackIDExists();
                txtBarcode.Text = "";
                txtBarcode.Focus();
                return;
            }
            else
            {
                //FeedCodeNotExists();

            }
            checkifNull();

        

            load_search();

            //bill gates programmer
            // 7/6/2020 gerard roque singian developer copyright
            if (txtFeedCodeRepack.Text.Trim() == string.Empty)
            {

            }
            else
            {
                if (txtmainfeedcode.Text.Trim() == txtFeedCodeRepack.Text.Trim())
                {

                }
                else
                {


                    FeedCodeNotMatch();
                    txtBarcode.Text = "";
                    txtBarcode.Focus();
                    return;
                }
            }
            if (txtmyItemCode.Text == txtitemcodeactive.Text)
            {

                button1_Click(sender, e);
            }
            if (lblCounts.Text == "1")
            {
                return;
            }
            if (txtmyItemCode.Text == txtitemcode2.Text)
            {



                button2_Click(sender, e);
            }
            if (lblCounts.Text == "2")
            {
                return;
            }
            if (txtmyItemCode.Text == txtitemcode3.Text)
            {
 


                button3_Click(sender, e);
            }
            if (lblCounts.Text == "3")
            {
                return;
            }
            if (txtmyItemCode.Text == txtitemcode4.Text)
            {


                button4_Click(sender, e);
            }
            if (lblCounts.Text == "4")
            {
                return;
            }
            if (txtmyItemCode.Text == txtitemcode5.Text)
            {


                button5_Click(sender, e);
            }
            if (lblCounts.Text == "5")
            {
                return;
            }
            if (txtmyItemCode.Text == txtitemcode6.Text)
            {


                button6_Click(sender, e);
            }
            if (lblCounts.Text == "6")
            {
                return;
            }
            if (txtmyItemCode.Text == txtitemcode7.Text)
            {

                button7_Click(sender, e);
            }
            if (lblCounts.Text == "7")
            {
                return;
            }
            if (txtmyItemCode.Text == txtitemcode8.Text)
            {


                button8_Click(sender, e);
            }
            if (lblCounts.Text == "8")
            {
                return;
            }
            if (txtmyItemCode.Text == txtitemcode9.Text)
            {
 

                button9_Click(sender, e);
            }
            if (lblCounts.Text == "9")
            {
                return;
            }
            if (txtmyItemCode.Text == txtitemcode10.Text)
            {
  
                button10_Click(sender, e);
            }
            if (lblCounts.Text == "10")
            {
                return;
            }
            if (txtmyItemCode.Text == txtitemcode11.Text)
            {
    
                button11_Click(sender, e);
            }
            if (lblCounts.Text == "11")
            {
                return;
            }
            if (txtmyItemCode.Text == txtitemcode12.Text)
            {
     
                button12_Click(sender, e);
            }
            if (lblCounts.Text == "12")
            {
                return;
            }
            if (txtmyItemCode.Text == txtitemcode13.Text)
            {

                button13_Click(sender, e);
            }
            if (lblCounts.Text == "13")
            {
                return;
            }
            if (txtmyItemCode.Text == txtitemcode14.Text)
            {
        
                button14_Click(sender, e);
            }
            if (lblCounts.Text == "14")
            {
                return;
            }
            if (txtmyItemCode.Text == txtitemcode15.Text)
            {
  
                button15_Click(sender, e);
            }
            if (lblCounts.Text == "15")
            {
                return;
            }
            if (txtmyItemCode.Text == txtitemcode16.Text)
            {

                button16_Click(sender, e);
            }
            if(lblCounts.Text=="16")
            {
                return;
            }
            //here
            if (txtmyItemCode.Text == txtitemcode17.Text)
            {
    
                button17_Click(sender, e);
       
            }
            if (lblCounts.Text == "17")
            {
                return;
            }
            if (txtmyItemCode.Text == txtitemcode18.Text)
            {
                //if (txt18.Text.Trim() == string.Empty)
                //{

                //}
                //else
                //{
                //    PreparedAlready();
                //    txtBarcode.Select();
                //    txtBarcode.Focus();
                //    return;
                //}
                button18_Click(sender, e);
   
            }
            if (lblCounts.Text == "18")
            {
                return;
            }
            if (txtmyItemCode.Text == txtitemcode19.Text)
            {
                //if (txt19.Text.Trim() == string.Empty)
                //{

                //}
                //else
                //{
                //    PreparedAlready();
                //    txtBarcode.Select();
                //    txtBarcode.Focus();
                //    return;
                //}
                button19_Click(sender, e);
            }
            if (lblCounts.Text == "19")
            {
                return;
            }
            if (txtmyItemCode.Text == txtitemcode20.Text)
            {
                //if (txt20.Text.Trim() == string.Empty)
                //{

                //}
                //else
                //{
                //    PreparedAlready();
                //    txtBarcode.Select();
                //    txtBarcode.Focus();
                //    return;
                //}
                button20_Click(sender, e);

            }
            if (lblCounts.Text == "20")
            {
                return;
            }
            if (txtmyItemCode.Text == txtitemcode21.Text)
            {
                //if (txt21.Text.Trim() == string.Empty)
                //{

                //}
                //else
                //{
                //    PreparedAlready();
                //    txtBarcode.Select();
                //    txtBarcode.Focus();
                //    return;
                //}
                button21_Click(sender, e);
            }
            if (lblCounts.Text == "21")
            {
                return;
            }
            if (txtmyItemCode.Text == txtitemcode22.Text)
            {
                //if (txt22.Text.Trim() == string.Empty)
                //{

                //}
                //else
                //{
                //    PreparedAlready();
                //    txtBarcode.Select();
                //    txtBarcode.Focus();
                //    return;
                //}
                button22_Click(sender, e);
            }
            if (lblCounts.Text == "22")
            {
                return;
            }
            if (txtmyItemCode.Text == txtitemcode23.Text)
            {
                //if (txt23.Text.Trim() == string.Empty)
                //{

                //}
                //else
                //{
                //    PreparedAlready();
                //    txtBarcode.Select();
                //    txtBarcode.Focus();
                //    return;
                //}
                button23_Click(sender, e);
            }
            if (lblCounts.Text == "23")
            {
                return;
            }
            if (txtmyItemCode.Text == txtitemcode24.Text)
            {
                //if (txt24.Text.Trim() == string.Empty)
                //{

                //}
                //else
                //{
                //    PreparedAlready();
                //    txtBarcode.Select();
                //    txtBarcode.Focus();
                //    return;
                //}
                button24_Click(sender, e);
            }
            if (lblCounts.Text == "24")
            {
                return;
            }
            if (txtmyItemCode.Text == txtitemcode25.Text)
            {
                //if (txt25.Text.Trim() == string.Empty)
                //{

                //}
                //else
                //{
                //    PreparedAlready();
                //    txtBarcode.Select();
                //    txtBarcode.Focus();
                //    return;
                //}
                button25_Click(sender, e);
            }
            if (lblCounts.Text == "25")
            {
                return;
            }


        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            doSearch();
            if (txtBarcode.Text.Trim() == string.Empty)
            {
      
            }

            else
            {
                txtBarcode.BackColor = Color.White;
            }
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                btnbarcode_Click(sender, e);
            }

        }

        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void txtsumtotal2_TextChanged(object sender, EventArgs e)
        {

        }

        private void b25_Click(object sender, EventArgs e)
        {

        }
    }



}




