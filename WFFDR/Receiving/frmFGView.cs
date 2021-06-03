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

        myclasses xClass = new myclasses();
        IStoredProcedures objStorProc = null;
        int rights_id = 0;

        frmFGReceivings ths;


        public frmFGView(frmFGReceivings frm, string ProductionID, string PrintingDate, string ProdPlan)
        {
            InitializeComponent();
            ths = frm;
            textBox1.TextChanged += new EventHandler(textBox1_TextChanged);
            this.ProdID = ProductionID;
            this.PrintingDate = PrintingDate;
            this.ProdPlan = ProdPlan;
        }
        public string ProdID { get; set; }
        public string PrintingDate { get; set; }

        public string ProdPlan { get; set; }
        private void frmFGView_Load(object sender, EventArgs e)
        {
            g_objStoredProcCollection = myClass.g_objStoredProc.GetCollections();
            objStorProc = xClass.g_objStoredProc.GetCollections();
            btnsave.Visible = true;
            rights_id = userinfo.user_rights_id;
            lblprodid.Text = ProdID;
            txtPrintingDate.Text = PrintingDate;
            txtProdDate.Text = ProdPlan;
            myglobal.global_module = "Active";
            txtaddedby.Text = userinfo.emp_name.ToUpper();
            txtdatenow.Text = DateTime.Now.ToString("MM/dd/yyyy");

            load_search();
            load_Pendingremark();
            load_Receivingremark();
          

            if (lblfound.Text == "0")

            {
                NoRecords();

                //this.Close();

                button1_Click(sender, e);



            }
            else
            {


            }
            Enable();
            btnDeSelect.Visible = false;
            textBox2.Text = "open";
            btnpending.Visible = false;
            
            lblbase.Text = "disable";
            btnSelect.Visible = true;




        }
        public void NoRecords()
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);

            popup.ContentText = "The Selected Production ID is already received by other user, Kindly choose another Production ID Thankyou!";

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

        void deselectAll()
        {
            for (int i = 0; i < dataView.RowCount; i++)
            {
                if (Convert.ToBoolean(dataView.Rows[i].Cells["selected"].Value = false))
                { }
                else
                {
                    textBox2.Text = "unselectall";
                    dataView.Rows[i].Cells["selected"].Value = false;
                }
                
            }

        }
        public void SumtheTotalBags()
        {
            decimal tot = 0;
            for (int i = 0; i < dataView.RowCount - 0; i++)
            {
                var value = dataView.Rows[i].Cells["ActualWeight"].Value;
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

        private void load_search()
        {
            dset_emp1.Clear();
            dset_emp1 = objStorProc.sp_GetCategory("callopenfgreceived",0, txtPrintingDate.Text,lblprodid.Text,"");
            doSearch();
        }
        DataSet dset_emp1 = new DataSet();
        private void doSearch()
        {

            try
            {
                if (dset_emp1.Tables.Count > 0)
                {
                    DataView dv = new DataView(dset_emp1.Tables[0]);
                    //if (myglobal.global_module == "EMPLOYEE")
                    //{

                    //}
                    //else if (myglobal.global_module == "Active")
                    //{

                    //    dv.RowFilter = "prod_adv like '%" + lblprodid.Text + "%' AND printing_date = '" + txtPrintingDate.Text + "'";
                    //}
                    //else if (myglobal.global_module == "VISITORS")
                    //{

                    //}
                    dataView.DataSource = dv;
                    lblfound.Text = dataView.RowCount.ToString();
                    Selectedrowtotal();
                    Selectedrowtotalquantity();
                    SumtheTotalBags();
                    Selectedrowtotalwithremarks();


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


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ths.textBox1.Text = textBox1.Text;
        }

        private void frmFGView_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (lblbase.Text == "epimanyaman")
            {
             
                textBox1.Text = "clearexit";
                

            }


            if (lblbase.Text == "disable")
            {
                fgreceivedresetview();
                textBox1.Text = "viewexit";
              

            }
            else
            { 

            if (lblbase.Text == "enable")
            { 
                var closemsg = (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to close this form? The remaining items will be count as a pending.", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning));
           
            if (closemsg==DialogResult.Yes)    

            {
                resetfgreceived();
                textBox1.Text = "warningexit";
            }

            else 
            {
                e.Cancel = true;
                return;

            }

            }
            }



        }

        public void resetfgreceived()
        {
            dSet.Clear();

            dSet = objStorProc.sp_rdf_fg_feedcodetransaction(0, lblprodid.Text, txtFeedCode.Text, txtFeedType.Text, "", "", txtPrintingDate.Text, "", "", "", "", txtaddedby.Text, "fgreceivedreset");


        }
        public void fgreceivedresetview()
        {
            dSet.Clear();

            dSet = objStorProc.sp_rdf_fg_feedcodetransaction(0, lblprodid.Text, txtFeedCode.Text, txtFeedType.Text, "", "", txtPrintingDate.Text, "", "", "", "", txtaddedby.Text, "fgreceivedresetview");


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
        void Selectbarcode()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Please select a barcode!";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Red;
            popup.Popup();
            //popup.AnimationDuration = 1000;
            //popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);

            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }

        void Afterclickok()
        {
            btnsave.Enabled = true;
            btnDeSelect.Visible = false;
            btnSelect.Visible = true;
            btnDeSelect.Enabled = true;
            btnSelect.Enabled = true;
            //btnsave.BackColor = Color.White;
            ControlBox = true;


        }

        void Clickok()
        {

            btnDeSelect.Visible = false;
            btnSelect.Visible = false;

            btnsave.Enabled = false;
            //btnsave.BackColor = Color.Teal;
            ControlBox = false;

        }


        public void Variance()
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to transact as a Variance?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Clickok();
                Disable();
                btnsave.Visible = false;
                btnpending.Visible = false;
                btnvariance.Enabled = false;



                for (int i = 0; i < dataView.Rows.Count; i++)
                {
                    try
                    {
                        if (Convert.ToBoolean(dataView.Rows[i].Cells["selected"].Value) == true)
                        {


                            this.dataView.CurrentCell = this.dataView.Rows[i].Cells[this.dataView.CurrentCell.ColumnIndex];

                            dset.Clear();
                            dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dataView.Rows[i].Cells["ID"].Value.ToString()), "variance", "", txtaddedby.Text.Trim(), 2);

                        }
                        else
                        {
                        
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Please Try again");
                    }


                }
                SuccessFullySaveFinishGoods();

              

                if (lblfound.Text == lbltotalselect.Text)
                {
                    lblbase.Text = "epimanyaman";
                    this.Close();


                }

                else
                {
                    Afterclickok();
                    Enable();
                    load_search();
                    btnSelect.Visible = true;
                    btnsave.Visible = true;
                    lblbase.Text = "enable";
                    btnpending.Visible = true;
                    btnpending.Enabled = true;
                 
                   
                    btnvariance.Enabled = true;
                    btnvariance.Visible = false;

                    textBox2.Text = "sarapyow123";
                    return;
                }
            }
            else
            {
                Enable();
                btnpending.Visible = true;
                btnsave.Visible = true;
                btnvariance.Visible = true;
                btnvariance.Enabled = true;
            }



        }

        public void load_Pendingremark()
        {

            xClass.fillComboBoxremark(CBpendingremark, "pendingremark", "", "","" ,dSet);
            
        }

        public void load_Receivingremark()
        {

            xClass.fillComboBoxremark(txtremarks, "receivingremark", "", "","", dSet);
           

        }

        public void Remarks()
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Please click ok  to update the finished goods! ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
            {
                Clickok();
                btnsave.Visible = false;
                btnvariance.Visible = false;



                for (int i = 0; i < dataView.Rows.Count; i++)
                {
                    try
                    {
                        if (Convert.ToBoolean(dataView.Rows[i].Cells["selected"].Value) == true)
                        {


                            this.dataView.CurrentCell = this.dataView.Rows[i].Cells[this.dataView.CurrentCell.ColumnIndex];

                           
                            dset.Clear();
                            dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dataView.Rows[i].Cells["ID"].Value.ToString()), "updateremarks", CBpendingremark.Text, txtaddedby.Text.Trim(), 3);

                        }
                        else
                        {
                           
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Please Try again");
                       
                    }


                }

            }



        }

        public void Finalsave()

        {
            if (MetroFramework.MetroMessageBox.Show(this, "Please click ok to receive the finished goods with a total of '" + lbltotalquantityselect.Text + "' quantity! ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
            {
                Clickok();



                for (int i = 0; i < dataView.Rows.Count; i++)
                {
                    try
                    {
                        if (Convert.ToBoolean(dataView.Rows[i].Cells["selected"].Value) == true)
                        {


                            this.dataView.CurrentCell = this.dataView.Rows[i].Cells[this.dataView.CurrentCell.ColumnIndex];

                            Feedcodetransaction();
                            dset.Clear();
                            dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dataView.Rows[i].Cells["ID"].Value.ToString()), "updatefinalreceived", txtdatenow.Text.Trim(), txtaddedby.Text.Trim(), 1);

                        }
                        else
                        {
                            
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Please Try again");
                       
                    }


                }

            }


           

        }


        private void Disable()
        {
            dataView.Enabled = false;
            btnsave.Enabled = false;
            btnSelect.Visible = false;
            btnDeSelect.Visible = false;
            ControlBox = false;
            //btnsave.BackColor = Color.Teal;
        }

        private void Enable()
        {

            dataView.Enabled = true;
            btnsave.Enabled = true;
            btnSelect.Enabled = true;
            btnDeSelect.Enabled = true;
            ControlBox = true;
            //btnsave.BackColor = Color.White;

        }
        void Nototalselected()
        {
            if (lbltotalselect.Text == "0")
            {
                Selectbarcode();
                return;
            }
            else

            {
                grpboxconfirm.Visible = true;

            }

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            Nototalselected();

            if (grpboxconfirm.Visible == true)
            {
                Disable();
                load_Receivingremark();
                
                CBpendingremark.Visible = false;
                txtremarks.Visible = true;
                txtremarks.SelectedIndex = -1;
                txtconfirm.Visible = true;
                confirmbtn.Visible = true;
                btnpending.Visible = false;
                btnpendingremarks.Visible = false;
                label14.Visible = false;

                label9.Visible = true;
                txtconfirm.Focus();
                this.dataView.CurrentCell = this.dataView.Rows[0].Cells[this.dataView.CurrentCell.ColumnIndex];
                btnvariance.Visible = false;
            }

            else

            {
                Enable();
                txtremarks.Visible = false;
                txtconfirm.Visible = false;
                textBox2.Text = "sarapyow123555";
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
            popup.ContentText = "Successful!";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
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
        private void dataView_CurrentCellChanged(object sender, EventArgs e)
        {

            if (dataView.CurrentRow != null)
            {
                if (dataView.CurrentRow.Cells["Feed_Code"].Value != null)
                {
                    txtFeedCode.Text = dataView.CurrentRow.Cells["Feed_Code"].Value.ToString();
                    txtFeedType.Text = dataView.CurrentRow.Cells["Feed_Type"].Value.ToString();
                    txtProductionDate.Text = dataView.CurrentRow.Cells["ProdDate"].Value.ToString();
                    txtfgoptions.Text = dataView.CurrentRow.Cells["OPTIONS"].Value.ToString();
                    txtfgqty.Text = dataView.CurrentRow.Cells["ActualWeight"].Value.ToString();
                    txtbxremarks.Text = dataView.CurrentRow.Cells["Remark"].Value.ToString();

                }
               
                
                    if (Convert.ToInt32(lblremarks.Text) > 0)
                    {
                        btnvariance.Visible = true;
                        btnpending.Visible = false;
                    }
                    else
                    {
                        btnvariance.Visible = false;
                        if (lblbase.Text == "enable")
                        {
                            btnpending.Visible = true;
                        }
                        else
                        {
                            btnpending.Visible = false;

                        }
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


        private void selectAll()
        {
            for (int i = 0; i < dataView.Rows.Count; i++)

            {
                if(Convert.ToBoolean(dataView.Rows[i].Cells["selected"].Value = true))
                { }
                else
                {
                    textBox2.Text = "selectall";
                    dataView.Rows[i].Cells["selected"].Value = true;
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
        //to accurate the selected records in datagridview
        private void dataView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataView.IsCurrentCellDirty)
            {
                dataView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }


        //to count the selected row in datagridview
        private void dataView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            Selectedrowtotalwithremarks();
            if (dataView.CurrentRow != null)
            {
                if (Convert.ToInt32(lblremarks.Text) > 0)
                {
                    btnvariance.Visible = true;
                    btnpending.Visible = false;
                }
                else
                {
                    btnvariance.Visible = false;
                    if (lblbase.Text == "enable")
                    { 
                    btnpending.Visible = true;
                    }
                    else
                    {
                        btnpending.Visible = false;

                    }
                }


            }







            textBox2.Text = String.Empty;
            Selectedrowtotal();
           
            Selectedrowtotalquantity();


            if (lblfound.Text == lbltotalselect.Text)

            {
                btnSelect.Visible = false;
                btnDeSelect.Visible = true;

            }
            else
            {
                btnSelect.Visible = true;
                btnDeSelect.Visible = false;

            }

        }


        private void Selectedrowtotalwithremarks()
        {


            int count = 0;
            int i = 0;


            for (i = 0; i <= dataView.RowCount - 1; i++)
            {
                if (Convert.ToBoolean(dataView.Rows[i].Cells["selected"].Value) == true)
                {
                    if (dataView.Rows[i].Cells["Remark"].Value.ToString() != String.Empty)
                    {
                        ++count;
                       
                    }
                    else
                    {
                        count = 0;
                    }
                   
                }
                lblremarks.Text = count.ToString();
              



            }
        }

        //to count the selected row of datagridview
        private void Selectedrowtotal()
        {


            int count = 0;
            int i = 0;


            for (i = 0; i <= dataView.RowCount - 1; i++)
            {
                if (Convert.ToBoolean(dataView.Rows[i].Cells["selected"].Value) == true)
                {
                    ++count;
                }
                lbltotalselect.Text = count.ToString();

            }
        }

        //to count the selected quantity of datagridview
        private void Selectedrowtotalquantity()

        {
            double sum = 0;

            for (int i = 0; i <= dataView.RowCount - 1; i++)
            {
                if (Convert.ToBoolean(dataView.Rows[i].Cells["selected"].Value) == true)
                {
                    sum += double.Parse(dataView.Rows[i].Cells["TOTAL"].Value.ToString());

                }

                lbltotalquantityselect.Text = sum.ToString();
            }


        }

        private void lbltotalweight_Click(object sender, EventArgs e)
        {

        }

        public void Wronginput()

        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Quantity inputted did not match!";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
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
    

        private void Feedcodetransaction()

        {
            dSet.Clear();
            dSet = objStorProc.sp_rdf_fg_feedcodetransaction(0, lblprodid.Text.Trim(), txtFeedCode.Text.Trim(), txtFeedType.Text.Trim(), txtfgoptions.Text.Trim(), txtfgqty.Text.Trim().ToString(), txtPrintingDate.Text.Trim().ToString(), txtProdDate.Text.Trim().ToString(), txtdatenow.Text.Trim(), "RECEIVED", txtremarks.Text, txtaddedby.Text.Trim(), "add");

        }

        private void confirmbtn_Click(object sender, EventArgs e)
        {

            if (txtremarks.SelectedIndex == -1)

            {
                EmptyFieldNotify();
                txtremarks.Focus();
                return;
            }
            if (txtconfirm.Text == String.Empty)

            {
                EmptyFieldNotify();
                txtconfirm.Focus();
                return;
            }
            


            if (txtconfirm.Text.Trim() == lbltotalquantityselect.Text.Trim())
            {
                txtconfirm.Text = String.Empty;
                grpboxconfirm.Visible = false;
                Finalsave();

                SuccessFullySaveFinishGoods();


                if (lblfound.Text == lbltotalselect.Text)
                {
                    lblbase.Text = "epimanyaman";
                    this.Close();
                }

                else
                {

                    Afterclickok();
                    Enable();
                    load_search();
                    btnpending.Visible = true;
                    btnpending.Enabled = true;
                    lblbase.Text = "enable";
                    btnSelect.Visible = true;
                    textBox2.Text = "sarap55";
                    return;
                }

            }
            else

            {
                txtconfirm.Text = String.Empty;
                Wronginput();

            }

        }

        private void Cancelbtn_Click(object sender, EventArgs e)
        {
            txtconfirm.Text = String.Empty;

            CBpendingremark.SelectedIndex = -1;
            txtconfirm.Visible = false;
            txtconfirm.Visible = false;
            label9.Visible = false;
            txtremarks.Visible = false;
           
            btnsave.Visible = true;
            

            grpboxconfirm.Visible = false;
            confirmbtn.Visible = false;
            btnpendingremarks.Visible = false;
            Enable();

           


            if(Convert.ToInt32(lblremarks.Text) > 0)

            {
                btnvariance.Visible = true;

            }
            else
            {

                btnvariance.Visible = false;
                if (btnpending.Visible == false)
                {


                    btnpending.Visible = false;
                    btnpending.Enabled = false;
                }
                else
                {

                    btnpending.Visible = true;
                    btnpending.Enabled = true;

                }
            }

            if (Convert.ToInt32(lblfound.Text) == Convert.ToInt32(lbltotalselect.Text))
            {
                btnSelect.Visible = false;
                btnDeSelect.Visible = true;
            }
            else
            {
                btnDeSelect.Visible = false;
                btnSelect.Visible = true;
            }


        }

        private void txtconfirm_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtconfirm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        public void EmptyFieldNotify()
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);

            popup.ContentText = "Please fill in the required Field!";

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

        private void btnpending_Click(object sender, EventArgs e)
        {

            Nototalselected();

           
            if (grpboxconfirm.Visible == true)
            {
                load_Pendingremark();
                Disable();
                txtremarks.Visible = false;
                CBpendingremark.SelectedIndex= -1;
                CBpendingremark.Visible = true;
                txtremarks.Text = String.Empty;
                txtconfirm.Visible = false;
                label9.Visible = false;
                btnpendingremarks.Visible = true;
               
                btnpending.Enabled = false;
                confirmbtn.Visible = false;
                label14.Visible = true;
                btnsave.Visible = false;
              
                this.dataView.CurrentCell = this.dataView.Rows[0].Cells[this.dataView.CurrentCell.ColumnIndex];
                btnvariance.Visible = false;
            }

            else

            {
                Enable();
                CBpendingremark.Visible = false;
                CBpendingremark.SelectedIndex = -1;
                txtremarks.Visible = false;
                txtconfirm.Visible = false;
                return;
            }
            




        }

        private void btnpendingremarks_Click(object sender, EventArgs e)
        {
            if (CBpendingremark.SelectedIndex == -1)

            {
                EmptyFieldNotify();
                CBpendingremark.Focus();
                return;
            }

            grpboxconfirm.Visible = false;
        
            Remarks();

            SuccessFullySaveFinishGoods();

            CBpendingremark.Visible = false;
            CBpendingremark.SelectedIndex = -1;
            txtremarks.Text = String.Empty;

           
                Afterclickok();
                Enable();
                load_search();
                btnSelect.Visible = true;
                btnsave.Visible = true;
                btnpending.Visible = true;
                btnpending.Enabled = true;
                btnvariance.Visible = false;
                textBox2.Text = "sarapyow";
                return;
           
        }

        private void dataView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (textBox2.Text == String.Empty)
            {

                return;

            }


            else
            {

                foreach (DataGridViewRow row in dataView.Rows)
                {

                    string remark = row.Cells["Remark"].Value.ToString();

                    if (remark != String.Empty)
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 0, 0);
                    }
                    else
                    {

                        

                    }
                }
                  
            }

             
  

        }

        private void dataView_Scroll(object sender, ScrollEventArgs e)
        {
            textBox2.Text = String.Empty;
        }

        private void btnvariance_Click(object sender, EventArgs e)
        {
           
            this.dataView.CurrentCell = this.dataView.Rows[0].Cells[this.dataView.CurrentCell.ColumnIndex];
            Variance();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
        
            this.Close();

          
        }

        private void CBpendingremark_Click(object sender, EventArgs e)
        {
            load_Pendingremark();
            CBpendingremark.SelectedIndex = -1;
        }

        private void txtremarks_Click(object sender, EventArgs e)
        {
            load_Receivingremark();
            txtremarks.SelectedIndex = -1;
        }
     
    }


}
 
 

