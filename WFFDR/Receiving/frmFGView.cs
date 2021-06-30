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
        DataSet dset_emp1 = new DataSet();
        DataSet dset_emp2 = new DataSet();

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
            Load_search2();
          
            load_Pendingremark();
            load_Pendingremark2(); 
            load_Receivingremark();
            Load_Varianceremark();

            if (lblfound.Text == "0")
            {
                tabControl1.SelectedTab = tabpen;
                dataView2_CurrentCellChanged(sender, e);

                if (dataView2.CurrentRow != null)
                { 

                txtFeedCode.Text = dataView2.CurrentRow.Cells["Feed_Code2"].Value.ToString();
                txtFeedType.Text = dataView2.CurrentRow.Cells["Feed_Type2"].Value.ToString();
                    //lblprodid.Text=
                }
            }
            timer1.Start();

            if (lblfound.Text == "0" && lblfound2.Text == "0")

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
                this.dataView.CurrentCell = this.dataView.Rows[i].Cells[this.dataView.CurrentCell.ColumnIndex];
                if (Convert.ToBoolean(dataView.Rows[i].Cells["selected"].Value = false))
                { }
                else
                {
                  
                    textBox2.Text = "unselectall";
                    dataView.Rows[i].Cells["selected"].Value = false;
                }
                
            }

        }

        void deselectAll2()
        {
            for (int i = 0; i < dataView2.RowCount; i++)
            {
                this.dataView2.CurrentCell = this.dataView2.Rows[i].Cells[this.dataView2.CurrentCell.ColumnIndex];
                if (Convert.ToBoolean(dataView2.Rows[i].Cells["selected2"].Value = false))
                { }
                else
                {
                    
                    textBox2.Text = "unselectall2";
                    dataView2.Rows[i].Cells["selected2"].Value = false;
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

        public void SumtheTotalBags2()
        {
            decimal tot = 0;
            for (int i = 0; i < dataView2.RowCount - 0; i++)
            {
                var value = dataView2.Rows[i].Cells["ActualWeight2"].Value;
                if (value != DBNull.Value)
                {
                    tot += Convert.ToDecimal(value);
                }
            }
            if (tot == 0)
            {

            }

            lbltotalweight2.Text = tot.ToString("#,0.00");
            lbltotalbags2.Text = tot.ToString("#,0.00");
            lbltotalbags2.Text = (float.Parse(lbltotalbags2.Text) / 50).ToString("#,0.00");

        }



        private void load_search()
        {
            dset_emp1.Clear();
            dset_emp1 = objStorProc.sp_GetCategory("callopenfgreceived",0, txtPrintingDate.Text,lblprodid.Text,"");
            doSearch();
        }
    
        private void doSearch()
        {

            try
            {
                if (dset_emp1.Tables.Count > 0)
                {
                    DataView dv = new DataView(dset_emp1.Tables[0]);
                
                    dataView.DataSource = dv;
                    lblfound.Text = dataView.RowCount.ToString();
                    Selectedrowtotal();
                    Selectedrowtotalquantity();
                    SumtheTotalBags();
                    Selectedrowtotalwithremarks();


                    if (lblfound.Text == "0")
                    {
                        btnDeSelect.Visible = false;
                        btnSelect.Visible = false;
                        btnsave.Visible = false;
                        btnpending.Visible = false;
                    }
                    else
                    {
                        btnDeSelect.Visible = true;
                        btnSelect.Visible = true;
                        btnsave.Visible = true;
                        btnpending.Visible = true;
                        btnsave.Enabled = true;

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
                MessageBox.Show("Invalid character found 2 Gerard.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }


        }

        private void Load_search2()
        {
            dset_emp2.Clear();
            dset_emp2 = objStorProc.sp_GetCategory("callopenfgpending", 0, txtPrintingDate.Text, lblprodid.Text, "");
            doSearch2();
        }


        private void doSearch2()
        {

            try
            {
                if (dset_emp2.Tables.Count > 0)
                {
                    DataView dv = new DataView(dset_emp2.Tables[0]);
                   
                    dataView2.DataSource = dv;
                    lblfound2.Text = dataView2.RowCount.ToString();
                    Selectedrowtotal2();
                    Selectedrowtotalquantity2();
                    SumtheTotalBags2();

                    if (lblfound2.Text == "0")
                    {
                        btnDeSelecttwo.Visible = false;
                        btnSelecttwo.Visible = false;
                        btnsave2.Visible = false;
                        btnvariance.Visible = false;
                    }
                    else
                    {

                        btnDeSelecttwo.Visible = true;
                        btnSelecttwo.Visible = true;
                        btnSelecttwo.BringToFront();
                        btnsave2.Visible = true;
                        btnvariance.Visible = true;
                        btnsave2.Enabled = true;

                    }

                    //Selectedrowtotalwithremarks();


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

                    if (closemsg == DialogResult.Yes)

                    {
                        if (lblfound.Text != "0")
                        {
                            resetfgreceived();
                        }
                        if (lblfound2.Text != "0")
                        { 
                            resetfgreceived2();
                        }
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

        public void resetfgreceived2()
        {
            dSet.Clear();

            dSet = objStorProc.sp_rdf_fg_feedcodetransaction(0, lblprodid.Text, txtFeedCode.Text, txtFeedType.Text, "", "", txtPrintingDate.Text, "", "", "", "", txtaddedby.Text, "fgreceivedreset2");


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
            //btnsave.Enabled = true;
            btnDeSelect.Visible = false;
            btnSelect.Visible = true;
            btnDeSelect.Enabled = true;
            btnSelect.Enabled = true;
            //btnsave.BackColor = Color.White;
            ControlBox = true;


        }


        void Afterclickok2()
        {
            //btnsave.Enabled = true;
            btnDeSelecttwo.Visible = false;
            btnSelecttwo.Visible = true;
            btnDeSelecttwo.Enabled = true;
            btnSelecttwo.Enabled = true;
            //btnsave.BackColor = Color.White;
            ControlBox = true;


        }

        void Clickok()
        {

            btnDeSelect.Visible = false;
            btnSelect.Visible = false;

            //btnsave.Enabled = false;
            //btnsave.BackColor = Color.Teal;
            ControlBox = false;

        }


        public void Variance()
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Please click ok to transact as a Variance.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
            {
                //Clickok();
                //Disable();
                //btnsave.Visible = false;
                //btnpending.Visible = false;
                //btnvariance.Enabled = false;
              



                for (int i = 0; i < dataView2.Rows.Count; i++)
                {
                    try
                    {
                        if (Convert.ToBoolean(dataView2.Rows[i].Cells["selected2"].Value) == true)
                        {


                            this.dataView2.CurrentCell = this.dataView2.Rows[i].Cells[this.dataView2.CurrentCell.ColumnIndex];

                            dset.Clear();
                            dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dataView2.Rows[i].Cells["ID2"].Value.ToString()), "variance", cbvariance.Text, txtaddedby.Text.Trim(), 2);

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

                Load_search2();
                load_search();

                if (lblfound.Text == lblfound2.Text)
                {
                    lblbase.Text = "epimanyaman";
                    this.Close();


                }

                else
                {
                    Afterclickok2();
                    Enable2();
                   
                    load_search();
                    btnSelecttwo.Visible = true;
                    //btnsave.Visible = true;
                    lblbase.Text = "enable";
                    btnvariance.Enabled = true;
                    btnsave2.Visible = true;

                    Load_search2();

               
                    //btnpending.Visible = true;
                    //btnpending.Enabled = true;


                    //btnvariance.Enabled = true;
                    //btnvariance.Visible = false;

                    textBox2.Text = "sarapyow123";
                    return;
                }
            }
            else
            {
                Enable2();
                //btnpending.Visible = true;
                //btnsave.Visible = true;
                //btnvariance.Visible = true;
                //btnvariance.Enabled = true;
            }



        }

        public void load_Pendingremark()
        {
            dSet.Clear();
            xClass.fillComboBoxremark(CBpendingremark, "pendingremark", "", "","" ,dSet);
            
        }

        public void load_Pendingremark2()
        {
            dSet.Clear();
            xClass.fillComboBoxremark(cbpendingreceived, "receivingremark", "", "", "", dSet);

        }

        public void load_Receivingremark()
        {
            dSet.Clear();
            xClass.fillComboBoxremark(txtremarks, "receivingremark", "", "","", dSet);
           

        }


        public void Load_Varianceremark()
        {
            dSet.Clear();
            xClass.fillComboBoxremark(cbvariance, "varianceremark", "", "", "", dSet);

        }

        public void Remarks()
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Please click ok  to update the finished goods! ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
            {
                Clickok();
                //btnsave.Visible = false;
                //btnvariance.Visible = false;



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

        public void Finalsave2()

        {
            if (MetroFramework.MetroMessageBox.Show(this, "Please click ok to receive the finished goods with a total of '" + lbltotalquantityselect.Text + "' quantity! ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
            {
                Clickok();



                for (int i = 0; i < dataView2.Rows.Count; i++)
                {
                    try
                    {
                        if (Convert.ToBoolean(dataView2.Rows[i].Cells["selected2"].Value) == true)
                        {


                            this.dataView2.CurrentCell = this.dataView2.Rows[i].Cells[this.dataView2.CurrentCell.ColumnIndex];

                            Feedcodetransaction2();
                            dset.Clear();
                            dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dataView2.Rows[i].Cells["ID2"].Value.ToString()), "updatefinalreceived", txtdatenow.Text.Trim(), txtaddedby.Text.Trim(), 1);

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
            //btnsave.Enabled = false;
            btnSelect.Visible = false;
            btnDeSelect.Visible = false;
            ControlBox = false;
            //btnsave.BackColor = Color.Teal;
        }

        private void Disable2()
        {
            dataView2.Enabled = false;
            //btnsave.Enabled = false;
            btnSelecttwo.Visible = false;
            btnDeSelecttwo.Visible = false;
            ControlBox = false;
            //btnsave.BackColor = Color.Teal;
        }

        private void Enable2()
        {

            dataView2.Enabled = true;
            //btnsave.Enabled = true;
            btnSelecttwo.Visible = true;
            btnDeSelecttwo.Visible = true;

            ControlBox = true;
            //btnsave.BackColor = Color.White;

        }

        private void Enable()
        {

            dataView.Enabled = true;
            //btnsave.Enabled = true;
            btnSelect.Visible = true;
            btnDeSelect.Visible = true;
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
                grpboxconfirm.BringToFront();
            }

        }



        void Nototalselected2()
        {
            if (lbltotalselect2.Text == "0")
            {
                Selectbarcode();
                return;
            }
            else

            {
                grpvariance.Visible = true;

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
                btnsave.Enabled = false;
                btnpendingremarks.Visible = false;
                label14.Visible = false;

                label9.Visible = true;
                txtconfirm.Focus();
                this.dataView.CurrentCell = this.dataView.Rows[0].Cells[this.dataView.CurrentCell.ColumnIndex];
                //btnvariance.Visible = false;
            }

            else

            {
                Enable();
                txtremarks.Visible = false;
                txtconfirm.Visible = false;
                textBox2.Text = "sarapyowsavesavemu";
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
               
                
                    //if (Convert.ToInt32(lblremarks.Text) > 0)
                    //{
                    //    btnvariance.Visible = true;
                    //    btnpending.Visible = false;
                    //}
                    //else
                    //{
                    //    btnvariance.Visible = false;
                    //    if (lblbase.Text == "enable")
                    //    {
                    //        btnpending.Visible = true;
                    //    }
                    //    else
                    //    {
                    //        btnpending.Visible = false;

                    //    }
                    //}


                
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

                this.dataView.CurrentCell = this.dataView.Rows[i].Cells[this.dataView.CurrentCell.ColumnIndex];
                if (Convert.ToBoolean(dataView.Rows[i].Cells["selected"].Value = true))
                { }
                else
                {
                   
                    textBox2.Text = "selectall";
                    dataView.Rows[i].Cells["selected"].Value = true;
                }
            }
        }

        private void selectAll2()
        {
            for (int i = 0; i < dataView2.Rows.Count; i++)

            {
                this.dataView2.CurrentCell = this.dataView2.Rows[i].Cells[this.dataView2.CurrentCell.ColumnIndex];

                if (Convert.ToBoolean(dataView2.Rows[i].Cells["selected2"].Value = true))
                { }
                else
                {
                    
                    textBox2.Text = "selectall2";
                    dataView2.Rows[i].Cells["selected2"].Value = true;
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

            
            //if (dataView.CurrentRow != null)
            //{
              
            //    if (Convert.ToInt32(lblremarks.Text) > 0)
            //    {
            //        btnvariance.Visible = true;
            //        btnpending.Visible = false;
            //    }
            //    else
            //    {
            //        btnvariance.Visible = false;
            //        if (lblbase.Text == "enable")
            //        { 
            //        btnpending.Visible = true;
            //        }
            //        else
            //        {
            //            btnpending.Visible = false;

            //        }
            //    }


            //}


            //Disablered();








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

        public void Disablered()
        {

            if (dataView.CurrentRow != null)
            {
                if (lblhelp.Text == "helpme")
                { 
                if (Convert.ToInt32(lblremarks.Text) > 0 && dataView.CurrentRow.Cells["Remark"].Value == null)
                {

                    btnpending.Visible = false;
                    btnvariance.Visible = false;
                    btnsave.Visible = false;
                        MessageBox.Show("help nawawala");
                  
                   
                }
                else if(Convert.ToInt32(lblremarks.Text) == 0 && dataView.CurrentRow.Cells["Remark"].Value != null)
                {
                    //btnpending.Visible = true;
                        btnvariance.Visible = true;
                        btnsave.Visible = true;
                        MessageBox.Show("help babalik");


                }

                }



            }

        }


        //public void Disablered()
        //{

        //    if (dataView.CurrentRow != null)
        //    {
        //        if (btnvariance.Visible == true)
        //        {

        //            if (Convert.ToInt32(lblremarks.Text) > 0 && dataView.CurrentRow.Cells["Remark"].Value != null)
        //            {
        //                dataView.Columns["selected"].ReadOnly = false;
        //                dataView.CurrentRow.Cells["selected"].Value = true;
        //                MessageBox.Show("RED");

        //            }
        //            else if (Convert.ToInt32(lblremarks.Text) > 0 && dataView.CurrentRow.Cells["Remark"].Value == null)
        //            {


        //                dataView.Columns["selected"].ReadOnly = true;
        //                dataView.CurrentRow.Cells["selected"].Value = false;
        //                MessageBox.Show("white");
        //                //return;
        //            }
        //        }
        //      if (btnpending.Visible == true)
        //        {
        //            if (Convert.ToInt32(lblremarks.Text) > 0 && dataView.CurrentRow.Cells["Remark"].Value != null)
        //            {
        //                dataView.Columns["selected"].ReadOnly = true;
        //                dataView.CurrentRow.Cells["selected"].Value = false;
        //                MessageBox.Show("yellowred");


        //            }
        //            else if (Convert.ToInt32(lblremarks.Text) > 0 && dataView.CurrentRow.Cells["Remark"].Value == null)
        //            {


        //                dataView.Columns["selected"].ReadOnly = false;
        //                dataView.CurrentRow.Cells["selected"].Value = true;
        //                MessageBox.Show("yellowwhite");
        //                //return;
        //            }

        //        }
        //        //{
        //        //    dataView.Columns["selected"].ReadOnly = false;
        //        //    dataView.CurrentRow.Cells["selected"].Value = true;
        //        //}

        //    }

        //}

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


        private void Selectedrowtotal2()
        {


            int count = 0;
            int i = 0;


            for (i = 0; i <= dataView2.RowCount - 1; i++)
            {
                if (Convert.ToBoolean(dataView2.Rows[i].Cells["selected2"].Value) == true)
                {
                    ++count;
                }
                lbltotalselect2.Text = count.ToString();

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


        private void Selectedrowtotalquantity2()

        {
            double sum = 0;

            for (int i = 0; i <= dataView2.RowCount - 1; i++)
            {
                if (Convert.ToBoolean(dataView2.Rows[i].Cells["selected2"].Value) == true)
                {
                    sum += double.Parse(dataView2.Rows[i].Cells["TOTAL2"].Value.ToString());

                }

                lbltotalquantityselect2.Text = sum.ToString();
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

        private void Feedcodetransaction2()

        {
            dSet.Clear();
            dSet = objStorProc.sp_rdf_fg_feedcodetransaction(0, lblprodid.Text.Trim(), txtFeedCode2.Text.Trim(), txtFeedType2.Text.Trim(), txtfgoptions2.Text.Trim(), textBox7.Text.Trim().ToString(), txtPrintingDate.Text.Trim().ToString(), txtProdDate.Text.Trim().ToString(), txtdatenow.Text.Trim(), "RECEIVED", cbpendingreceived.Text, txtaddedby.Text.Trim(), "add");

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

                Load_search2();
                load_search();
                if (lblfound.Text == "0" && lblfound2.Text=="0")
                {
                    lblbase.Text = "epimanyaman";
                    this.Close();
                }

                else
                {

                    Afterclickok();
                    Enable();
              
                    btnpending.Visible = true;
                    btnpending.Enabled = true;
                    btnsave.Enabled = true;
                    lblbase.Text = "enable";
                    btnSelect.Visible = true;
                    textBox2.Text = "sarap55";
                    load_search();
                    Load_search2();
                    if (txtFeedCode.Text == "" && txtFeedType.Text == "")
                    {
                        txtFeedCode.Text = txtFeedCode2.Text;
                        txtFeedType.Text = txtFeedType2.Text;
                        //lblprodid.Text=

                    }
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
            btnsave.Enabled = true;


            grpboxconfirm.Visible = false;
            confirmbtn.Visible = false;
            btnpendingremarks.Visible = false;
            Enable();
            if(lblbase.Text == "enable")
            {
                btnpending.Enabled = true;
                btnpending.Visible = true;

            }
           


            

                //{
                //    btnvariance.Visible = true;

                //}
                //else
                //{

                //    btnvariance.Visible = false;
                //    if (btnpending.Visible == false)
                //    {


                //        btnpending.Visible = false;
                //        btnpending.Enabled = false;
                //    }
                //    else
                //    {

                //        btnpending.Visible = true;
                //        btnpending.Enabled = true;

                //    }
                //}

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
                //btnvariance.Visible = false;
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
               
            btnSelect.Visible = true;
            //btnsave.Visible = true;
            //btnpending.Visible = true;
            btnpending.Enabled = true;
            btnsave.Visible = true;
            load_search();
            Load_search2();
            if(txtFeedCode.Text=="" && txtFeedType.Text=="")
            {
                txtFeedCode.Text = txtFeedCode2.Text;
                txtFeedType.Text = txtFeedType2.Text;
                //lblprodid.Text=

            }

          

            //btnvariance.Visible = false;
            textBox2.Text = "sarapyowpending";
                lblhelp.Text = "helpme";
                return;
           
        }

        private void dataView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
           

             
  

        }

        private void dataView_Scroll(object sender, ScrollEventArgs e)
        {
            textBox2.Text = String.Empty;
        }

        private void btnvariance_Click(object sender, EventArgs e)
        {
            Nototalselected2();


            if(grpvariance.Visible==true)
            { 
            this.dataView2.CurrentCell = this.dataView2.Rows[0].Cells[this.dataView2.CurrentCell.ColumnIndex];
            grpvariance.Visible = true;
            cbvariance.Visible = true;
                confirmvariance.Visible = true;
            cbvariance.SelectedIndex = -1;
            lblpendingreceived.Visible = false;
            txtqtypendingreceived.Visible = false;
            btnpendingreceived.Visible = false;
            cbpendingreceived.Visible = false;
                btnvariance.Enabled = false;
                btnsave2.Visible = false;
          
                Disable2();


            }

            else

            {
                Enable2();

                textBox2.Text = "sarapyowvariance";
                return;
            }

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

        private void confirmvariance_Click(object sender, EventArgs e)
        {
           
            if(cbvariance.SelectedIndex == -1)
            {
                EmptyFieldNotify();
                cbvariance.Focus();
                cbvariance.Select();
               
                return;
            }
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to transact as a Variance?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Variance();
              
                grpvariance.Visible = false;
                cbvariance.SelectedIndex = -1;

            }
            else
            {
                return;

            }
        }

        private void cancelvariance_Click(object sender, EventArgs e)
        {
            grpvariance.Visible = false;
            cbvariance.SelectedIndex = -1;
            cbpendingreceived.SelectedIndex = -1;
            btnvariance.Enabled = true;
            btnvariance.Visible = true;
            btnsave2.Visible = true;
            btnsave2.Enabled = true;
            confirmvariance.Visible = false;
            btnpendingreceived.Visible = false;
            Enable2();


        }

        private void cbvariance_Click(object sender, EventArgs e)
        {
            Load_Varianceremark();
            cbvariance.SelectedIndex = -1;
        }

        private void btnsave2_Click(object sender, EventArgs e)
        {
            Nototalselected2();

            if (grpvariance.Visible == true)
            {
                Disable2();
                load_Receivingremark();
                confirmvariance.Visible = false;
                cbvariance.Visible = false;
                lblpendingreceived.Visible = true;
                txtqtypendingreceived.Visible = true;
                btnpendingreceived.Visible = true;
                cbpendingreceived.Visible = true;

                this.dataView2.CurrentCell = this.dataView2.Rows[0].Cells[this.dataView2.CurrentCell.ColumnIndex];
                btnvariance.Visible = false;
                btnsave2.Enabled = false;
            }

            else

            {
                Enable2();
               
                textBox2.Text = "sarapyowpendingreceived";
                return;
            }
        }

        private void btnDeSelecttwo_Click(object sender, EventArgs e)
        {
            btnSelecttwo.Visible = true;
            btnDeSelecttwo.Visible = false;
            deselectAll2();
        }

        private void btnSelecttwo_Click(object sender, EventArgs e)
        {
            btnSelecttwo.Visible = false;
            btnDeSelecttwo.Visible = true;
            selectAll2();
        }

        private void dataView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (textBox2.Text == String.Empty)
            {

                return;

            }


            else
            {

                foreach (DataGridViewRow row in dataView2.Rows)
                {

                    string remark = row.Cells["Remark2"].Value.ToString();

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

        private void cbpendingreceived_Click(object sender, EventArgs e)
        {
            load_Pendingremark2();
            cbpendingreceived.SelectedIndex = -1;
        }

        private void btnpendingreceived_Click(object sender, EventArgs e)
        {
            if (cbpendingreceived.SelectedIndex == -1)

            {
                EmptyFieldNotify();
                cbpendingreceived.Focus();
                return;
            }
            if (txtqtypendingreceived.Text == String.Empty)

            {
                EmptyFieldNotify();
                txtqtypendingreceived.Focus();
                return;
            }



            if (txtqtypendingreceived.Text.Trim() == lbltotalquantityselect2.Text.Trim())
            {
                txtqtypendingreceived.Text = String.Empty;
                grpvariance.Visible = false;
                Finalsave2();

                SuccessFullySaveFinishGoods();

                Load_search2();
                load_search();
                if (lblfound.Text == "0" && lblfound2.Text =="0" )
                {
                    lblbase.Text = "epimanyaman";
                    this.Close();
                }

                else
                {

                    Afterclickok2();
                    Enable2();

                    Load_search2();
                    load_search();
                    lblbase.Text = "enable";
                    btnSelect.Visible = true;

                  

                    textBox2.Text = "sarapbalikka";
                    return;
                }

            }
            else

            {
                txtqtypendingreceived.Text = String.Empty;
                Wronginput();

            }

        }

        private void txtqtypendingreceived_KeyPress(object sender, KeyPressEventArgs e)
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

        private void dataView2_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataView2.CurrentRow != null)
            {
                if (dataView2.CurrentRow.Cells["Feed_Code2"].Value != null)
                {
                    txtFeedCode2.Text = dataView2.CurrentRow.Cells["Feed_Code2"].Value.ToString();
                    txtFeedType2.Text = dataView2.CurrentRow.Cells["Feed_Type2"].Value.ToString();
                    txtProductionDate2.Text = dataView2.CurrentRow.Cells["ProdDate2"].Value.ToString();
                    txtfgoptions2.Text = dataView2.CurrentRow.Cells["OPTIONS2"].Value.ToString();
                    textBox7.Text = dataView2.CurrentRow.Cells["ActualWeight2"].Value.ToString();
                    textBox8.Text = dataView2.CurrentRow.Cells["Remark2"].Value.ToString();

                }

            }
        }

        private void dataView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Selectedrowtotalwithremarks();






            textBox2.Text = String.Empty;
            Selectedrowtotal2();

            Selectedrowtotalquantity2();


            if (lblfound2.Text == lbltotalselect2.Text)

            {
                btnSelecttwo.Visible = false;
                btnDeSelecttwo.Visible = true;

            }
            else
            {
                btnSelecttwo.Visible = true;
                btnDeSelecttwo.Visible = false;

            }

        }

        private void dataView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void dataView2_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataView2.IsCurrentCellDirty)
            {
                dataView2.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void lblfound2_TextChanged(object sender, EventArgs e)
        {
            lblpendingbell.Text = lblfound2.Text;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Notification();
        }

        public void Notification()
        {

            if (lblfound2.Text != "0")
            {
                lblpendingbell.Visible = true;
                notifpending.Image = Properties.Resources.alarm_filled_14px1;
                //notifpending.BringToFront();
             
            }
            else
            {
                lblpendingbell.Visible = false;
                notifpending.Image = Properties.Resources.alarm_18px;

            }
        }

        private void txtFeedCode2_TextChanged(object sender, EventArgs e)
        {

        }
    }


}
 
 

