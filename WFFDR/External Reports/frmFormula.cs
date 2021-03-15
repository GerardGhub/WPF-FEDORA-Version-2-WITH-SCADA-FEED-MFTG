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

    public partial class frmFormula : Form
    {
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        DataSet ds = new DataSet();

        myclasses xClass = new myclasses();
        IStoredProcedures objStorProc = null;

        DataSet dSet = new DataSet();
        DataSet dset_section = new DataSet();
        DataSet dSet_temp = new DataSet();

        string mode = "";
        int p_id = 0; // variable for position id
        int d_id = 0;
        int temp_hid = 0;
        int s_id = 0;
        int pos_id = 0;
        public string position = "";
        string model;
        Boolean ready = false;

        public frmFormula()
        {
            InitializeComponent();
        }

        private void frmFormula_Load(object sender, EventArgs e)
        {
            //btnsum_Click(sender, e);
            mode = "startinsert";
     

            model = "show";
            DisableTextBox();

            //this.WindowState = FormWindowState.Maximized;
            txtdatenow.Text = DateTime.Now.ToString();


            objStorProc = xClass.g_objStoredProc.GetCollections();
            loadFormula();
            loadFormula2();
            dgv1_CurrentCellChanged(sender, e);




            loadRawFormula();
            cboCategory_SelectedValueChanged(sender, e);
            txtgetfeedcode.Text = "0";
            CallOther();

            //
                            button2.Visible = false;
                button1.Visible = false;
                btnAdd.Visible = false;
                bunifuThinButton210.Visible = false;

            btnsum_Click(sender, e);
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

        void CallOther()
        {
            txtQuantity.Focus();
            txtModified_By.Text = userinfo.emp_name.ToUpper();
            cboFeedType.Text = "";
            txtQtyNew.Visible = false;
            cboQTYxxx.Visible = false;
            cboCategory.Text = "";
        }

        public void ClearTextNew()
        {
            ////cboFeedType.Text = "";
            txtFeedCode.Text = "";
            txtItemCode.Text = "";
            txtQuantity.Text = "";
            txtgetfeedcode.Text = "";
            cboCategory.Text = "";
            cboGroup.Text = "";
        }


        void loadFormula()
        {
            ready = false;

            xClass.fillComboBoxFormula(cboFeedType, "rdf_recipe_pro_new", dSet);
            //xClass.fillComboBox(cboFeedType, "rdf_recipe_pro_new", dSet);
            ////////displayData(Convert.ToInt32(cboFeedType.SelectedValue.ToString()));

            //displayData(cboFeedType.SelectedValue.ToString()));

            ready = true;
        }


        void loadFormula2()
        {
            ready = false;

            xClass.fillComboBoxFormula(cmb2, "rdf_recipe_pro_new", dSet);
            //xClass.fillComboBox(cboFeedType, "rdf_recipe_pro_new", dSet);
            ////////displayData(Convert.ToInt32(cboFeedType.SelectedValue.ToString()));

            //displayData(cboFeedType.SelectedValue.ToString()));

            ready = true;
        }

        void SaveNotify()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "SUCCESSFULLY ADDED A NEW RAW MATERIAL";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(920, 270);
            popup.ImageSize = new Size(175, 180);
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


        }

        void SuccessIn()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "RAW MATERIALS MARK AS ACTIVE";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(920, 270);
            popup.ImageSize = new Size(175, 180);
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


        }


        void SuccessOut()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "RAW MATERIAL MARK AS INACTIVE";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(920, 270);
            popup.ImageSize = new Size(175, 180);
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


        }


        void displayData(int dept_id)
        {
            dset_section = objStorProc.sp_getFilterTables("filter_Formula", "", dept_id);
            // dset_section = objStorProc.sp_getFilterTables("filter_type_by_prod_type", "", dept_id);

            if (dset_section.Tables.Count > 0)
            {
                DataView dv = new DataView(dset_section.Tables[0]);
                dgvImport.DataSource = dv;

                textBox1.Text = "jajas";
            }

        }

        public void DisableTextBox()
        {
            txtLast_Modified.Enabled = false;
            txtModified_By.Enabled = false;
            btnAdd.Enabled = false;
            txtItemCode.Enabled = false;
            //   btnNew.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnCancel.Enabled = false;
            btnUpdate.Visible = false;
            txtFeedCode.Enabled = false;
            txtQuantity.Enabled = false;

            //  cboFeedType.Enabled = false;
            cboCategory.Enabled = false;
            cboDescription.Enabled = false;
            cboGroup.Enabled = false;
            //txttype.Enabled = false;

            button1.Enabled = false;
            btnDelete.Enabled = false;
        }

        public void DisLocate()
        {
            txtLast_Modified.Enabled = false;
            txtModified_By.Enabled = false;
            //btnAdd.Enabled = false;
            txtItemCode.Enabled = false;
            //   btnNew.Enabled = false;
            //btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            //btnCancel.Enabled = false;

            txtFeedCode.Enabled = false;
            //txtQuantity.Enabled = false;

            //  cboFeedType.Enabled = false;
            cboCategory.Enabled = false;
            //cboDescription.Enabled = false;
            cboGroup.Enabled = false;
            txttype.Enabled = false;

            //button1.Enabled = false;
            btnDelete.Enabled = false;
        }

        public void ForEdit()
        {

         
            btnEdit.Visible = false;
            btnCancel.Enabled = true;

            // txtQuantity.Enabled = true;
            cboFeedType.Enabled = true;
            cboFeedType.Visible = true;
            //cboCategory.Enabled = true;
     
            //cboGroup.Enabled = true;
            txttype.Visible = true;
        }

        public void ForCancel()
        {
            mode = "";
            btnEdit.Visible = true;
            btnUpdate.Visible = false;
            txtFeedCode.Enabled = false;


            cboCategory.Enabled = false;
            cboDescription.Enabled = false;
            cboGroup.Enabled = false;

        }

        private void dgv1_CurrentCellChanged(object sender, EventArgs e)
        {
            showRecords();

            // ToolStripBCancel.Visible = true;
            btnDelete.Enabled = true;

            // toolStripButtonDelete.Visible = true;
            //   ToolStripButtonUpdate.Visible = true;
            btnEdit.Enabled = true;
        }

        void showRecords()
        {
            if (ready == true)
            {
                if (dgv1.CurrentRow != null)
                {
                    //////if (dgv1.CurrentRow.Cells["ID"].Value != null)
                    //////{
                    //////    p_id = Convert.ToInt32(dgv1.CurrentRow.Cells["ID"].Value);
                    //////  txtFeedCode.Text = dgv1.CurrentRow.Cells["FeedCode"].Value.ToString();
                    //////   cboCategory.Text = dgv1.CurrentRow.Cells["Category"].Value.ToString();
                    //////    txtItemCode.Text = dgv1.CurrentRow.Cells["ItemCode"].Value.ToString();
                    //////    txtQuantity.Text = dgv1.CurrentRow.Cells["Quantity"].Value.ToString();
                    //////    txtModified_By.Text = dgv1.CurrentRow.Cells["ModifyBY"].Value.ToString();
                    //////    txtLast_Modified.Text = dgv1.CurrentRow.Cells["LastModified"].Value.ToString();
                    //////    //  cboProdType.Text = dgv1.CurrentRow.Cells["type_name"].Value.ToString();
                    //////}
                }
            }
        }






        private void cboFeedType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ready == true)

                btnsum_Click(sender, e);
            //displayData(Convert.ToInt32(cboFeedType.SelectedValue.ToString()));
            txtgetfeedcode.Text = cboFeedType.SelectedValue.ToString();

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "select recipe_id,feed_code,rp_feed_type,rp_type,modified_by,last_modified from [dbo].[rdf_recipe] WHERE feed_code = '" + cboFeedType.Text + "' AND is_active=1";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvMaster.DataSource = dt;


            sql_con.Close();




            //    txtFeedCode.Focus();
        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboFeedType_SelectedValueChanged(object sender, EventArgs e)
        {
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "select distinct r.recipe_id,r.rp_type,r.feed_code,r.rp_feed_type,r.item_code,r.rp_description,r.rp_category,r.rp_group,r.quantity,raw.price,r.modified_by,r.last_modified,r.last_modified as ONE_TON, r.quantity as QTY_PROD,raw.price as TWO_TONS  from [dbo].[rdf_recipe] r LEFT JOIN [dbo].[rdf_raw_materials] raw ON r.item_code=raw.item_code WHERE r.feed_code = '" + cboFeedType.Text + "' AND r.is_active=1";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvImport.DataSource = dt;


            sql_con.Close();
            txtmat1.Text = dgvImport.RowCount.ToString();








            Equation();

            //btnsum_Click(sender, e);

            if (txt1.Text.Trim() == string.Empty)
            {
                return;
            }
            if (txt21.Text.Trim() == string.Empty)
            {
                return;
            }

            txtdiff1.Text = (float.Parse(txt1.Text) - float.Parse(txt21.Text)).ToString("#,0.00");
            txtdiff2.Text = (float.Parse(txt2.Text) - float.Parse(txt22.Text)).ToString("#,0.00");
            txtdiff3.Text = (float.Parse(txt3.Text) - float.Parse(txt23.Text)).ToString("#,0.00");
            txtdiff4.Text = (float.Parse(txt4.Text) - float.Parse(txt24.Text)).ToString("#,0.00");

        }
        public void Equation()
        {
            //reove muna 9/10/2020
            for (int n = 0; n < (dgvImport.Rows.Count); n++)
            {
                //double s = Convert.ToDouble(dgvImport.Rows[n].Cells[4].Value);


                //double s1 = Convert.ToDouble(dgvAllFeedCode.Rows[n].Cells[7].Value);

                double s1 = Convert.ToDouble(dgvImport.Rows[n].Cells[10].Value);
                double s7 = Convert.ToDouble(dgvImport.Rows[n].Cells[9].Value);
                double s70 = Convert.ToDouble(dgvImport.Rows[n].Cells[14].Value);
                //int s1 = Convert.ToInt32(dgv1stView.Rows[n].Cells[1].Value);
                //double s13 = s * 2;
                double s15 = s1 * s7;
                double s18 = s7 * 2;

                //dgvImport.Rows[n].Cells[7].Value = s15.ToString("#,0.000");
                dgvImport.Rows[n].Cells[14].Value = s18.ToString();
   
                dgvImport.Rows[n].Cells[13].Value = s15.ToString();
                //dgvAllFeedCode.Rows[n].Cells[7].Value = s15.ToString("#,0.000");

                double s180 = s1 * s18;

                dgvImport.Rows[n].Cells[15].Value = s180.ToString();

            }


        }


        public void Equation2()
        {
            //reove muna 9/10/2020
            for (int n = 0; n < (dgvImport2.Rows.Count); n++)
            {


                double s1 = Convert.ToDouble(dgvImport2.Rows[n].Cells[10].Value);
                double s7 = Convert.ToDouble(dgvImport2.Rows[n].Cells[9].Value);
                double s70 = Convert.ToDouble(dgvImport2.Rows[n].Cells[14].Value);
                //int s1 = Convert.ToInt32(dgv1stView.Rows[n].Cells[1].Value);
                //double s13 = s * 2;
                double s15 = s1 * s7;
                double s18 = s7 * 2;

                //dgvImport.Rows[n].Cells[7].Value = s15.ToString("#,0.000");
                dgvImport2.Rows[n].Cells[14].Value = s18.ToString();

                dgvImport2.Rows[n].Cells[13].Value = s15.ToString();
                //dgvAllFeedCode.Rows[n].Cells[7].Value = s15.ToString("#,0.000");

                double s180 = s1 * s18;

                dgvImport2.Rows[n].Cells[15].Value = s180.ToString();

            }


        }


        void CheckofData()
        {
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "select distinct recipe_id,rp_type,feed_code,rp_feed_type,item_code,rp_description,rp_category,rp_group,quantity,modified_by,last_modified from [dbo].[rdf_recipe] WHERE feed_code = '" + cboFeedType.Text + "' AND is_active=1";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvImport.DataSource = dt;


            sql_con.Close();
           

        }


        void loadFeedCode()
        {
            //   ready = false;
            //      xClass.fillComboBoxFilter(cboFeedCode, "filter_section", dSet, cboFeedType.Text, 0);
            //    ready = true;
            //  s_id = showValueFcode(cboFeedCode);
        }

        public int showValueFcode(ComboBox cbo)
        {
            int ids = 0;
            if (ready == true)
            {
                if (cbo.Items.Count > 0)
                {
                    ids = Convert.ToInt32(cbo.SelectedValue.ToString());
                }
            }
            return ids;
        }

        private void cboFeedCode_SelectedValueChanged(object sender, EventArgs e)
        {

            //    if (cboFeedCode.Text.Trim() != "")
            //   {
            //   loadPosition();
            //  s_id = showValueFcode(cboFeedCode);
            // cboPosition.Text = "";
            //   }

        }


        private void cboFeedCode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboCategory_SelectedValueChanged(object sender, EventArgs e)
        {
            //if (cboCategory.Text.Trim() != "")
            //{
            //    loadDescription();
            //    cboDescription.Text = "";
            //}



            if (cboCategory.Text.Trim() != "")
            {
                ////loadGroupFinal(); lako kepa
                ///
                loadRawFormula();
                //cboDescription.Text = "";5/8/2020

                loadQTYFinal();
                cboQTYxxx.Text = "";
            }


        }


        void loadCategory()
        {
            //department
            ready = false;
            xClass.fillComboBox(cboCategory, "rdf_category", dSet);
            ready = true;
        }

        void loadRawFormula()
        {
            //department
            ready = false;
            xClass.fillComboBoxFormulaDescription(cboDescription, "rdf_formula_rawmats", dSet);
            ready = true;
        }


        void loadDescription()
        {
            ready = false;
            xClass.fillComboBoxFilter(cboDescription, "filter_rdf_raw_materials_new", dSet, cboCategory.Text, 0);
            ready = true;
            s_id = showValue(cboDescription);
        }

        void loadCategoryFormula()
        {
            ready = false;
            xClass.fillComboBoxFilter(cboCategory, "filter_rdf_raw_materials_category", dSet, cboDescription.Text, 0);
            ready = true;
            s_id = showValue(cboCategory);
        }

        public int showValue(ComboBox cbo)
        {
            int ids = 0;
            if (ready == true)
            {
                if (cbo.Items.Count > 0)
                {
                    ids = Convert.ToInt32(cbo.SelectedValue.ToString());
                }
            }
            return ids;
        }

        private void cboDescription_SelectedValueChanged(object sender, EventArgs e)
        {
            if (ready == true)
                txtgetdescription.Text = cboDescription.SelectedValue.ToString();


            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);



            //string sqlquery = "select item_id,item_category,item_code,item_description from [dbo].[rdf_raw_materials] WHERE item_code ='" + cboDescription.Text + "'";


            string sqlquery = "select rw.item_id,rw.item_code,rw.Category,rw.item_description,rw.item_group from [dbo].[rdf_raw_materials] rw WHERE rw.item_code = '" + cboDescription.Text + "'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvMasterRaw.DataSource = dt;


            sql_con.Close();





            if (cboDescription.Text.Trim() != "")
            {
                //loadDescription();
                loadCategoryFormula();
                //loadGroupFinal();
                //cboDescription.Text = "";5/8/2020
            }
            txtQuantity.Text = "";
          
        }

        void loadQTYFinal()
        {
            ready = false;
            //filter_rdf_raw_materials
            xClass.fillComboBoxFilter(cboQTYxxx, "filter_rdf_qty_sample", dSet, cboDescription.Text, 0);
            ready = true;
            s_id = showValueQTY(cboGroup);
        }

        void loadItemCode()
        {
            //   ready = false;
            //   xClass.fillComboBoxFilter(cboItemCode, "filter_rdf_raw_materials_item_code", dSet, cboDescription.Text, 0);
            //   ready = true;
            //   s_id = showValueItemCode(cboItemCode);
        }

        void loadGroupFinal()
        {
            ready = false;
            //filter_rdf_raw_materials
            xClass.fillComboBoxFilter(cboGroup, "filter_rdf_group_final", dSet, cboDescription.Text, 0);
            ready = true;
            s_id = showValueGroup(cboGroup);
        }

        public int showValueItemCode(ComboBox cbo)
        {
            int ids = 0;
            if (ready == true)
            {
                if (cbo.Items.Count > 0)
                {
                    ids = Convert.ToInt32(cbo.SelectedValue.ToString());
                }
            }
            return ids;
        }

        private void comboBox4_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboGroup.Text.Trim() != "")
            {
                pos_id = showValueGroup(cboGroup);
                cboGroup.Text = position;
            }
        }

        public int showValueGroup(ComboBox cbo)
        {
            int ids = 0;
            if (ready == true)
            {
                if (cbo.Items.Count > 0)
                {
                    ids = Convert.ToInt32(cbo.SelectedValue.ToString());
                }
            }
            return ids;
        }

        private void cboGroup_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtQuantity.Text = "";
            btnAdd.Enabled = true;
            ClearTextNew();
            ForEdit();
            button1.Enabled = true;
            txtFeedCode.Enabled = true;
            txtQuantity.Enabled = true;
            btnUpdate.Enabled = false;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //mode = "delete";


            //try
            //{
            //    if (cboFeedType.Text.Trim() == string.Empty)
            //    {
            //        MessageBox.Show("Please enter " + lblDepartment.Text + ". ", lblDepartment.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return;
            //    }

            //    if (txtFeedCode.Text.Trim() == string.Empty)
            //    {
            //        MessageBox.Show("Please enter " + lblName.Text + ". ", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return;
            //    }
            //    else
            //    {
            //        if (saveMode())
            //        {

            //            if (cboFeedType.Items.Count > 0)
            //            {
            //                int index = cboFeedType.FindString(cboFeedType.Text, 0);
            //                if (index == -1) { index = 0; }
            //                cboFeedType.SelectedIndex = index;
            //            }

            //            displayData(Convert.ToInt32(cboFeedType.SelectedValue.ToString()));
            //            string tmode = mode;

            //            if (tmode == "add")
            //            {
            //                dgvImport.CurrentCell = dgvImport[0, dgvImport.Rows.Count - 1];
            //            }
            //            else
            //            {
            //                dgvImport.CurrentCell = dgvImport[0, temp_hid];
            //            }

            //            //  btnCancel_Click(sender, e);
            //        }
            //        else
            //            MessageBox.Show("Unable to save record!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }

            //}
            //catch
            //{
            //    MessageBox.Show("Feed Code Deleted SuccessFully " + lblName.Text + ". ", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }




        //public bool saveMode()
        //{

        //    if (mode == "add")
        //    {
        //        dSet.Clear();

        //        dSet = objStorProc.sp_getFilterTables("filter_FormulaCRUD", cboFeedType.Text, Convert.ToInt32(cboFeedType.SelectedValue.ToString()));
        //        if (dSet.Tables[0].Rows.Count > 0)
        //        {
        //            MessageBox.Show(lblName.Text + " : [ " + cboFeedType.Text + " ] already exist...", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            txtFeedCode.Focus();
        //            return false;
        //        }


        //        //dSet = objStorProc.sp_getFilterTables("filter_FormulaCRUD", txtFeedCode.Text, Convert.ToInt32(cboFeedType.SelectedValue.ToString()));
        //        //if (dSet.Tables[0].Rows.Count > 0)
        //        //{
        //        //    MessageBox.Show(lblName.Text + " : [ " + txtFeedCode.Text + " ] already exist...", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        //    txtFeedCode.Focus();
        //        //    return false;
        //        //}
        //        else
        //        {
        //            dSet.Clear();
        //            dSet = objStorProc.rdf_sp_myrecipe(0, Convert.ToInt32(cboFeedType.SelectedValue.ToString()), 0,cboDescription.Text, Convert.ToInt32(cboDescription.SelectedValue.ToString()), 0, txtQuantity.Text, txtModified_By.Text,cboFeedType.Text, "add");

        //            return true;
        //        }
        //    }
        //    else if (mode == "edit")
        //    {
        //        dSet.Clear();
        //        dSet = objStorProc.rdf_sp_myrecipe(0, 0, 0, txtItemCode.Text, 0, 0, txtQuantity.Text, txtModified_By.Text,cboFeedType.Text, "getbyname");

        //        dSet_temp.Clear();
        //        dSet_temp = objStorProc.rdf_sp_myrecipe(p_id, 0, 0,txtItemCode.Text, 0, 0, txtQuantity.Text, txtModified_By.Text,cboFeedType.Text, "getbyid");

        //        if (dSet.Tables[0].Rows.Count > 0)
        //        {
        //            int tmpID = Convert.ToInt32(dSet.Tables[0].Rows[0][0].ToString());
        //            int deptID = Convert.ToInt32(dSet.Tables[0].Rows[0][1].ToString());
        //            if (tmpID == p_id)
        //            {
        //                dSet.Clear();
        //                dSet = objStorProc.rdf_sp_myrecipe(p_id, Convert.ToInt32(cboFeedType.SelectedValue.ToString()), Convert.ToInt32(cboCategory.SelectedValue.ToString()), txtItemCode.Text, Convert.ToInt32(cboDescription.SelectedValue.ToString()), Convert.ToInt32(cboGroup.SelectedValue.ToString()), txtQuantity.Text, txtModified_By.Text,cboFeedType.Text, "edit");


        //                return true;
        //            }
        //            else if ((deptID == d_id) && (tmpID != p_id))
        //            {
        //                MessageBox.Show(lblName.Text + " : [ " + txtFeedCode.Text + " ] already exist...", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                txtFeedCode.Focus();
        //                return false;
        //            }
        //        }
        //        else
        //        {
        //            dSet.Clear();
        //            //  dSet = objStorProc.rdf_sp_myrecipe(p_id, Convert.ToInt32(cboFeedType.SelectedValue.ToString()), txtFeedCode.Text, txtFeedType.Text, txtSacksColor.Text, "edit");
        //            dSet = objStorProc.rdf_sp_myrecipe(p_id, Convert.ToInt32(cboFeedType.SelectedValue.ToString()), Convert.ToInt32(cboCategory.SelectedValue.ToString()), txtItemCode.Text, Convert.ToInt32(cboDescription.SelectedValue.ToString()), Convert.ToInt32(cboGroup.SelectedValue.ToString()), txtQuantity.Text, txtModified_By.Text,cboFeedType.Text, "edit");

        //            return true;
        //        }
        //    }
        //    else if (mode == "delete")
        //    {
        //        dSet.Clear();
        //        dSet = objStorProc.rdf_sp_myrecipe(p_id, 0, 0,txtItemCode.Text, 0, 0, txtQuantity.Text, txtModified_By.Text,cboFeedType.Text, "delete");

        //        dSet_temp.Clear();
        //        dSet_temp = objStorProc.rdf_sp_myrecipe(p_id, 0, 0,txtItemCode.Text, 0, 0, txtQuantity.Text, txtModified_By.Text,cboFeedType.Text, "delete");

        //        return true;
        //    }
        //    return false;
        //}

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ForEdit();
            btnUpdate.Enabled = true;
            txtQuantity.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ForCancel();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (txtQuantity.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter " + lblDepartment.Text + ". ", lblDepartment.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cboFeedType.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter " + lblDepartment.Text + ". ", lblDepartment.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtItemCode.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter " + lblDepartment.Text + ". ", lblDepartment.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "UPDATE [dbo].[rdf_recipe] SET quantity='" + txtQuantity.Text + "', last_modified='" + txtdatenow.Text + "', modified_by='" + txtModified_By.Text + "'  WHERE recipe_id = '" + txtrecipe.Text + "'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvMaster.DataSource = dt;

            cboFeedType_SelectedValueChanged(sender, e);
            dgvImport.Refresh();
            sql_con.Close();



            // mode = "edit";
            ////dSet = objStorProc.rdf_sp_myrecipe(p_id, Convert.ToChar(cboFeedType.SelectedValue), 0, txtItemCode.Text, 0, 0, txtQuantity.Text, txtModified_By.Text,cboFeedType.Text, "edit");
            // MessageBox.Show("Formula Updated SuccessFully " + lblName.Text + ". ", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            // try
            // {
            //     if (cboFeedType.Text.Trim() == string.Empty)
            //     {
            //         MessageBox.Show("Please enter " + lblDepartment.Text + ". ", lblDepartment.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //         return;
            //     }

            //     if (txtFeedCode.Text.Trim() == string.Empty)
            //     {
            //         MessageBox.Show("Please enter " + lblName.Text + ". ", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //         return;
            //     }
            //     else
            //     {
            //         if (saveMode())
            //         {

            //             if (cboFeedType.Items.Count > 0)
            //             {
            //                 int index = cboFeedType.FindString(cboFeedType.Text, 0);
            //                 if (index == -1) { index = 0; }
            //                 cboFeedType.SelectedIndex = index;
            //             }

            //             displayData(Convert.ToInt32(cboFeedType.SelectedValue.ToString()));
            //             string tmode = mode;

            //             if (tmode == "add")
            //             {
            //                 dgvImport.CurrentCell = dgvImport[0, dgvImport.Rows.Count - 1];
            //             }
            //             else
            //             {
            //                 dgvImport.CurrentCell = dgvImport[0, temp_hid];
            //             }

            //             //  btnCancel_Click(sender, e);
            //         }
            //         else
            //             MessageBox.Show("Unable to save record!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //     }

            // }
            // catch
            // {
            //     MessageBox.Show("Same value");
            // }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {



            try
            {
                if (cboFeedType.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please enter 1 " + lblDepartment.Text + ". ", lblDepartment.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (txtQuantity.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please enter Quantity" + lblName.Text + ". ", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {






                    String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
                    SqlConnection sql_con = new SqlConnection(connetionString);




                    cmd = new SqlCommand("SELECT feed_code FROM [dbo].[rdf_recipe]  WHERE feed_code='" + cboFeedType.Text + "' AND item_code='" + cboDescription.Text + "' AND rp_category='" + cboCategory.Text + "' AND is_active=1", sql_con);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    da.Fill(ds);
                    int i = ds.Tables[0].Rows.Count;
                    if (i > 0)
                    {
                        MessageBox.Show("The Formula" + cboFeedType.Text + "Already Exists !");
                        ds.Clear();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("The Formula" + cboFeedType.Text + "Not Exists You can Proceed Saving!");
                        //return; // ang gulo ntyo mga bugok
                    }










                    mode = "add";
                    //  dSet = objStorProc.rdf_sp_feed_code(0, Convert.ToInt32(cboProdType.SelectedValue.ToString()), txtFeedCode.Text, txtFeedType.Text, txtSacksColor.Text, "add");

                    dSet = objStorProc.rdf_sp_myrecipe(0, 0, 0, cboDescription.Text, 0, 0, txtQuantity.Text, txtModified_By.Text, cboFeedType.Text, txttype.Text, txtFeedCode.Text, txtItemCode.Text, cboCategory.Text, cboGroup.Text, "add");

                    DisLocate();

                    cboFeedType_SelectedValueChanged(sender, e);
                    ////loadFormula();
                    //if (saveMode())
                    //    {

                    //        if (cboFeedType.Items.Count > 0)
                    //        {
                    //            int index = cboFeedType.FindString(cboFeedType.Text, 0);
                    //            if (index == -1) { index = 0; }
                    //            cboFeedType.SelectedIndex = index;
                    //        }

                    //        displayData(Convert.ToInt32(cboFeedType.SelectedValue.ToString()));
                    //        string tmode = mode;

                    //        if (tmode == "add")
                    //        {
                    //            dgv1.CurrentCell = dgv1[0, dgv1.Rows.Count - 1];
                    //        }
                    //        else
                    //        {
                    //            dgv1.CurrentCell = dgv1[0, temp_hid];
                    //        }

                    //        btnCancel_Click(sender, e);
                    //    }
                    //    else
                    //        MessageBox.Show("Unable to save record!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            catch
            {

                MessageBox.Show("Same values");
            }
        }

        private void cboFeedType_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void cboQTYxxx_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboGroup.Text.Trim() != "")
            {
                pos_id = showValueQTY(cboQTYxxx);
                cboQTYxxx.Text = position;
            }
        }

        public int showValueQTY(ComboBox cbo)
        {
            int ids = 0;
            if (ready == true)
            {
                if (cbo.Items.Count > 0)
                {
                    ids = Convert.ToInt32(cbo.SelectedValue.ToString());
                }
            }
            return ids;
        }

        private void txtFeedCode_TextChanged(object sender, EventArgs e)
        {



        }

        private void cboDescription_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtgetfeedcode_TextChanged(object sender, EventArgs e)
        {


        }

        private void dgvMaster_CurrentCellChanged(object sender, EventArgs e)
        {
            showValueFeedCode();
        }

        void showValueFeedCode()
        {

            if (dgvMaster.RowCount > 0)
            {
                if (dgvMaster.CurrentRow != null)
                {
                    if (dgvMaster.CurrentRow.Cells["recipe_id"].Value != null)
                    {
                        p_id = Convert.ToInt32(dgvMaster.CurrentRow.Cells["recipe_id"].Value);
                        //txtID.Text = dgv_table.CurrentRow.Cells["received_id"].Value.ToString();
                        txtFeedCode.Text = dgvMaster.CurrentRow.Cells["rp_feed_type"].Value.ToString();
                        txttype.Text = dgvMaster.CurrentRow.Cells["rp_type"].Value.ToString();


                    }

                }
            }

        }

        private void dgvMasterRaw_CurrentCellChanged(object sender, EventArgs e)
        {
            showValueDescriptox();
        }
        public void showValueDescriptox()
        {
            if (dgvMasterRaw.RowCount > 0)
            {
                if (dgvMasterRaw.CurrentRow != null)
                {
                    if (dgvMasterRaw.CurrentRow.Cells["item_id"].Value != null)
                    {
                        p_id = Convert.ToInt32(dgvMasterRaw.CurrentRow.Cells["item_id"].Value);
                        //txtID.Text = dgv_table.CurrentRow.Cells["received_id"].Value.ToString();
                        txtItemCode.Text = dgvMasterRaw.CurrentRow.Cells["item_description"].Value.ToString();
                        cboCategory.Text = dgvMasterRaw.CurrentRow.Cells["Category"].Value.ToString();
                        cboGroup.Text = dgvMasterRaw.CurrentRow.Cells["item_group"].Value.ToString();

                    }

                }
            }



        }

        private void dgvImport_CurrentCellChanged(object sender, EventArgs e)
        {
            showImportDataGrid();
            //btnEdit.Visible = true;
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
                        txtFeedCode.Text = dgvImport.CurrentRow.Cells["feed_code"].Value.ToString();
                        cboCategory.Text = dgvImport.CurrentRow.Cells["rp_category"].Value.ToString();
                        txtItemCode.Text = dgvImport.CurrentRow.Cells["rp_description"].Value.ToString();
                        cboDescription.Text = dgvImport.CurrentRow.Cells["item_code"].Value.ToString();
                        txtQuantity.Text = dgvImport.CurrentRow.Cells["quantity2"].Value.ToString();
                        txtrecipe.Text = dgvImport.CurrentRow.Cells["recipe_id"].Value.ToString();

                        txtcodes.Text = dgvImport.CurrentRow.Cells["item_code"].Value.ToString();
txtmaincode.Text = dgvImport.CurrentRow.Cells["feed_code"].Value.ToString();
                        txtFeedCoder.Text = dgvImport.CurrentRow.Cells["feed_code"].Value.ToString();
                        //txtModified_By.Text = dgvImport.CurrentRow.Cells["ModifyBY"].Value.ToString();
                        //txtLast_Modified.Text = dgvImport.CurrentRow.Cells["LastModified"].Value.ToString();
                        //  cboProdType.Text = dgv1.CurrentRow.Cells["type_name"].Value.ToString();
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

            for (int i = 0; i < dgvImport.RowCount - 0; i++)
            {
                var value = dgvImport.Rows[i].Cells["quantity2"].Value;
                if (value != DBNull.Value)
                {
                    tot += Convert.ToDecimal(value);
                }
            }
            if (tot == 0)
            {

            }


            //price

            decimal tot1 = 0;

            for (int i1 = 0; i1 < dgvImport.RowCount - 0; i1++)
            {
                var value1 = dgvImport.Rows[i1].Cells["price"].Value;
                if (value1 != DBNull.Value)
                {
                    tot1 += Convert.ToDecimal(value1);
                }
            }
            if (tot1 == 0)
            {

            }

lbltotalprice.Text = tot1.ToString("#,0.00");
         txt2.Text = tot1.ToString("#,0.00");

            //1 tons

            decimal tot2 = 0;

            for (int i2 = 0; i2 < dgvImport.RowCount - 0; i2++)
            {
                var value2 = dgvImport.Rows[i2].Cells["ONE_TON"].Value;
                if (value2 != DBNull.Value)
                {
                    tot2 += Convert.ToDecimal(value2);
                }
            }
            if (tot2 == 0)
            {

            }
            lbl1tons.Text = tot2.ToString("#,0.00");
            txt3.Text = tot2.ToString("#,0.00");
            //2 tons


            decimal tot3 = 0;

            for (int i3= 0; i3 < dgvImport.RowCount - 0; i3++)
            {
                var value3 = dgvImport.Rows[i3].Cells["TWO_TONS"].Value;
                if (value3 != DBNull.Value)
                {
                    tot3 += Convert.ToDecimal(value3);
                }
            }
            if (tot3 == 0)
            {

            }
            lbl2tons.Text = tot3.ToString("#,0.00");
            txt4.Text = tot3.ToString("#,0.00");

            //qty price x2
            decimal tot4 = 0;

            for (int i4 = 0; i4 < dgvImport.RowCount - 0; i4++)
            {
                var value4 = dgvImport.Rows[i4].Cells["QTY_PROD"].Value;
                if (value4 != DBNull.Value)
                {
                    tot4 += Convert.ToDecimal(value4);
                }
            }
            if (tot4 == 0)
            {

            }
     lblpriceqtyprod.Text = tot4.ToString("#,0.00");


            //dgvImport.Rows[dgvImport.Rows.Count - 1].Cells["quantity2"].Value = tot.ToString();

            lblCounts.Text = dgvImport.RowCount.ToString();
            lblCountss.Text = tot.ToString("#,0.00");

            txt1.Text = tot.ToString("#,0.00");
        }

        private void g(object sender, EventArgs e)
        {

        }

        private void txtgetdescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtrecipe_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFeedCoder_TextChanged(object sender, EventArgs e)
        {
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "select feed_code, item_code, rp_description, last_modified from [dbo].[rdf_recipe] WHERE feed_code = '" + txtFeedCoder.Text + "' AND is_active=0";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr2 = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr2.Fill(dt);
            dataGridView1.DataSource = dt;


            sql_con.Close();
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            Notactive();


        }
        void Notactive()
        {
            if (ready == true)
            {
                if (dataGridView1.CurrentRow != null)
                {
                    if (dataGridView1.CurrentRow.Cells["item_code"].Value != null)
                    {
                        //p_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["recipe_id"].Value);
                        txtcodesmain.Text = dataGridView1.CurrentRow.Cells["item_code"].Value.ToString();



                    }
                }
            }
        }

        private void btnforward_Click(object sender, EventArgs e)
        {
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "UPDATE [dbo].[rdf_recipe] SET is_active='0' WHERE item_code = '" + txtcodes.Text + "' AND feed_code = '" + txtFeedCoder.Text + "'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr2 = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr2.Fill(dt);
            dataGridView1.DataSource = dt;

            txtFeedCoder_TextChanged(sender, e);

            //MessageBox.Show("Success OUT!");

            sql_con.Close();
            CheckofData();
            btnsum_Click(sender, e);
            SuccessOut();
        }

        private void btnback_Click(object sender, EventArgs e)
        {


            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);

            string sqlquery = "UPDATE [dbo].[rdf_recipe] SET is_active='1' WHERE item_code = '" + txtcodesmain.Text + "' AND feed_code = '" + txtFeedCoder.Text + "'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr2 = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr2.Fill(dt);
            dataGridView1.DataSource = dt;

            txtFeedCoder_TextChanged(sender, e);
       
            //MessageBox.Show("Success IN!");
            sql_con.Close();
            CheckofData();
            btnsum_Click(sender, e);
            SuccessIn();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtQuantity.Text = "";
            btnAdd.Enabled = true;
            ClearTextNew();
            ForEdit();
            cboFeedType.Text = "";
            cboDescription.Enabled = true;
            txtItemCode.Text = "";
            button1.Enabled = true;
            txtFeedCode.Enabled = true;
            txtQuantity.Enabled = true;
            btnUpdate.Enabled = false;
            txtItemCode.Enabled = true;
            cboFeedType.Select();
            cboFeedType.Focus();
            btnCancel.Visible = true;
            btnAdd.Visible = true;
            //button1.Visible = true;
            button2.Visible = false;
            btnNew.Visible = false;
        }

        void EmptyFieldNotify()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "FILL UP THE REQUIRED FIELDS";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(920, 270);
            popup.ImageSize = new Size(175, 180);
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

            txtQuantity.Focus();
        }

        void FeedTypeNull()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Select a Feed Type to Modify";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(920, 270);
            popup.ImageSize = new Size(175, 180);
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

            txtQuantity.Focus();
        }
        void EmptyFieldNotify2()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Select Raw Materials";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(920, 270);
            popup.ImageSize = new Size(175, 180);
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

            cboDescription.Focus();
        }



        void ItemCodeAlreadyExist()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = ""+ txtItemCode.Text + " ALREADY IN FORMULATION ENTRY !";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(920, 270);
            popup.ImageSize = new Size(175, 180);
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

            cboDescription.Focus();
        }













        private void btnNew_Click_1(object sender, EventArgs e)
        {
            txtQuantity.Text = "";
            btnAdd.Enabled = true;
            ClearTextNew();
            ForEdit();
            button1.Enabled = true;
            txtFeedCode.Enabled = true;
            txtQuantity.Enabled = true;
            btnUpdate.Enabled = false;
            txtItemCode.Enabled = true;
            cboFeedType.Select();
            cboFeedType.Focus();
            btnCancel.Visible = true;
            btnAdd.Visible = true;
            //button1.Visible = true;
            button2.Visible = false;
            btnNew.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (mode == "startinsert")
            {
                btnUpdate.Visible = false;
                btnCancel.Visible = false;
                button1.IdleFillColor = Color.DarkSeaGreen;
                button1.IdleForecolor = Color.White;
                button1.IdleLineColor = Color.White;
                cboDescription.Text = "";
                btnAdd2.Visible = true;
                cboDescription.Enabled = true;
                mode = "finallyinsert";
                cboDescription.Focus();


            }

            else
            {
                button2.Visible = true;
                btnAdd2.Visible = false;
                button1.IdleFillColor = Color.LightGray;
                btnUpdate.Visible = true;
                btnCancel.Visible = true;
                cboDescription.Enabled = false;
                mode = "startinsert";


            }






        }
     
          
    
        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (cboFeedType.Text.Trim() == string.Empty)
                {
                    FeedTypeNull();
                    cboFeedType.Focus();
                    //MessageBox.Show("Please enter 1 " + lblDepartment.Text + ". ", lblDepartment.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (txtQuantity.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtQuantity.Focus();
                    //MessageBox.Show("Please enter Quantity" + lblName.Text + ". ", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {

                    


                    String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
                    SqlConnection sql_con = new SqlConnection(connetionString);




                    cmd = new SqlCommand("SELECT feed_code FROM [dbo].[rdf_recipe]  WHERE feed_code='" + cboFeedType.Text + "' AND item_code='" + cboDescription.Text + "' AND rp_category='" + cboCategory.Text + "' AND is_active=1", sql_con);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    da.Fill(ds);
                    int i = ds.Tables[0].Rows.Count;
                    if (i > 0)
                    {
                        FeedCodeExist();
                        //MessageBox.Show("The Formula" + cboFeedType.Text + "Already Exists !");
                        ds.Clear();
                        return;
                    }
                    else
                    {
                        //MessageBox.Show("The Formula" + cboFeedType.Text + "Not Exists You can Proceed Saving!");
                        //return; // ang gulo ntyo mga bugok
                    }










                    mode = "add";
                    //  dSet = objStorProc.rdf_sp_feed_code(0, Convert.ToInt32(cboProdType.SelectedValue.ToString()), txtFeedCode.Text, txtFeedType.Text, txtSacksColor.Text, "add");

                    dSet = objStorProc.rdf_sp_myrecipe(0, 0, 0, cboDescription.Text, 0, 0, txtQuantity.Text, txtModified_By.Text, cboFeedType.Text, txttype.Text, txtFeedCode.Text, txtItemCode.Text, cboCategory.Text, cboGroup.Text, "add");

                    DisLocate();

                    cboFeedType_SelectedValueChanged(sender, e);
                    ////loadFormula();
                    //if (saveMode())
                    //    {

                    //        if (cboFeedType.Items.Count > 0)
                    //        {
                    //            int index = cboFeedType.FindString(cboFeedType.Text, 0);
                    //            if (index == -1) { index = 0; }
                    //            cboFeedType.SelectedIndex = index;
                    //        }

                    //        displayData(Convert.ToInt32(cboFeedType.SelectedValue.ToString()));
                    //        string tmode = mode;

                    //        if (tmode == "add")
                    //        {
                    //            dgv1.CurrentCell = dgv1[0, dgv1.Rows.Count - 1];
                    //        }
                    //        else
                    //        {
                    //            dgv1.CurrentCell = dgv1[0, temp_hid];
                    //        }

                    //        btnCancel_Click(sender, e);
                    //    }
                    //    else
                    //        MessageBox.Show("Unable to save record!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            catch
            {

                MessageBox.Show("Same values");
            }
        }

        void FeedCodeExist()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.ContentText = "FEED CODE " + cboFeedType.Text + " ALREADY EXISTS!";
            popup.Size = new Size(920, 270);
            popup.ImageSize = new Size(175, 220);
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


        void Save()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.ContentText = "FEED CODE " + cboFeedType.Text + " SUCCESSFULLY SAVE!";
            popup.Size = new Size(920, 270);
            popup.ImageSize = new Size(175, 220);
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

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            ForEdit();
            btnUpdate.Enabled = true;
            //txtQuantity.Enabled = true;
            ////btnUpdate.Visible = true; chuppe muna working
            btnEdit.Visible = false;
            btnCancel.Visible = true;
            button2.Visible = false;
            btnNew.Visible = false;
            button1.Visible = true;
            button1.Enabled = true;
    cboFeedType.Text = dgvImport.CurrentRow.Cells["feed_code"].Value.ToString();
            cboFeedType_SelectedIndexChanged(sender, e);
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            metroButton2_Click(sender, e);

        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            btnAdd.Visible = false;
            btnCancel.Visible = false;
            cboFeedType.Enabled = false;
                cboDescription.Enabled = false;

            button1.Visible = false;

            cboCategory.Enabled = false;
            btnUpdate.Visible = false;
            btnEdit.Visible = true;
            txtQuantity.Enabled = false;
            button2.Visible = true;
            //btnNew.Visible = true;
        }

        private void bunifuThinButton210_Click(object sender, EventArgs e)
        {
            
            if (model == "show")
            {
                //GroupBox1.Visible = false;
                bunifuThinButton210.ButtonText = "INACTIVE HIDE";
                dataGridView1.Visible = true;
                lblinactive.Visible = true;
                lblinactive.Text = "Formulation Inactive Table Management";
                btnback.Visible = true;
                btnforward.Visible = true;
                       model = "hide";
            }
            else
            {

                dataGridView1.Visible = false;
                //lblinfo.Text = "Formulation Table Management";
                bunifuThinButton210.ButtonText = "INACTIVE SHOW";
                btnback.Visible = false;
                btnforward.Visible = false;
                lblinactive.Visible = false;
                model = "show";
            }
        }

        private void dgvImport_Click(object sender, EventArgs e)
        {
            //btnEdit.Visible = true;
        }

        private void cboDescription_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void dgvImport_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void btnAdd2_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboFeedType.Text.Trim() == string.Empty)
                {
                    FeedTypeNull();
                    //MessageBox.Show("Please enter 1 " + lblDepartment.Text + ". ", lblDepartment.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (txtQuantity.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtQuantity.Focus();
                    //MessageBox.Show("Please enter Quantity" + lblName.Text + ". ", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (cboDescription.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify2();
                    //MessageBox.Show("Please enter Quantity" + lblName.Text + ". ", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {





                    String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
                    SqlConnection sql_con = new SqlConnection(connetionString);




                    cmd = new SqlCommand("SELECT feed_code FROM [dbo].[rdf_recipe]  WHERE feed_code='" + cboFeedType.Text + "' AND item_code='" + cboDescription.Text + "' AND rp_category='" + cboCategory.Text + "' AND is_active=1", sql_con);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    da.Fill(ds);
                    int i = ds.Tables[0].Rows.Count;
                    if (i > 0)
                    {
                        ItemCodeAlreadyExist();
                        //MessageBox.Show("The Formula" + cboFeedType.Text + "Already Exists !");
                        ds.Clear();
                        return;
                    }
                    else
                    {
                        //MessageBox.Show("The Formula" + cboFeedType.Text + "Not Exists You can Proceed Saving!");

                        SaveNotify();
                        //return; // ang gulo ntyo mga bugok
                    }










                    mode = "add";
                    //  dSet = objStorProc.rdf_sp_feed_code(0, Convert.ToInt32(cboProdType.SelectedValue.ToString()), txtFeedCode.Text, txtFeedType.Text, txtSacksColor.Text, "add");

                    dSet = objStorProc.rdf_sp_myrecipe(0, 0, 0, cboDescription.Text, 0, 0, txtQuantity.Text, txtModified_By.Text, cboFeedType.Text, txttype.Text, txtFeedCode.Text, txtItemCode.Text, cboCategory.Text, cboGroup.Text, "add");

                    DisLocate();

                    cboFeedType_SelectedValueChanged(sender, e);

                    cboFeedType_SelectedIndexChanged(sender,e);

                    //txtFeedCode.Text = dgvImport.CurrentRow.Cells["feed_code"].Value.ToString();

                }

            }

            catch
            {

                MessageBox.Show("Same values");
            }

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {

            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Update the Formulation of "+ txtItemCode.Text + " to "+txtQuantity.Text+" ? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                if (txtQuantity.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please enter " + lblDepartment.Text + ". ", lblDepartment.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (cboFeedType.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please enter " + lblDepartment.Text + ". ", lblDepartment.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (txtItemCode.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please enter " + lblDepartment.Text + ". ", lblDepartment.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                txtdatenow.Text = DateTime.Now.ToString();
                String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

                //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
                SqlConnection sql_con = new SqlConnection(connetionString);



                string sqlquery = "UPDATE [dbo].[rdf_recipe] SET quantity='" + txtQuantity.Text + "', last_modified='" + txtdatenow.Text + "', modified_by='" + txtModified_By.Text + "'  WHERE recipe_id = '" + txtrecipe.Text + "'";
                sql_con.Open();
                SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
                SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
                DataTable dt = new DataTable();
                sdr.Fill(dt);
                dgvMaster.DataSource = dt;




                //4 query is for insert the audit trail
                dSet = objStorProc.rdf_sp_new_preparation(0, cboFeedType.Text, txtModified_By.Text, "8.3.2 Formulation Adjustment", "Change Formulation Quantity", txtFeedCode.Text, txtItemCode.Text, txtQuantity.Text, "", "", "", "", "", "", "", "", "", "", "addTrailLogs");













                cboFeedType_SelectedValueChanged(sender, e);
                dgvImport.Refresh();
                sql_con.Close();
                btnEdit.Visible = true;
                button2.Visible = true;
                btnNew.Visible = true;

            }

            else
            {


                return;
            }


            }

        private void bunifuThinButton28_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton214_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {

        }

        private void dgvImport_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (e.ColumnIndex > 0)
            {
                if (dgvImport.Columns[e.ColumnIndex].Name.ToLower().Contains("ONE_TON"))
                {
                    if (e.Value.ToString() != "")
                    {
                        double d = double.Parse(e.Value.ToString());
                        e.Value = d.ToString("n0");
                    }
                }
            }




            if (e.ColumnIndex > 0)
            {
                if (dgvImport.Columns[e.ColumnIndex].Name.ToLower().Contains("quantity2"))
                {
                    if (e.Value.ToString() != "")
                    {
                        double d = double.Parse(e.Value.ToString());
                        e.Value = d.ToString("n0");
                    }
                }
            }



        }

        private void dgvImport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {

        }

        private void txttype_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton26_Click(object sender, EventArgs e)
        {

        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtItemCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton27_Click(object sender, EventArgs e)
        {

        }

        private void txtcodes_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton211_Click(object sender, EventArgs e)
        {

        }

        private void txtmaincode_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmb2_SelectedValueChanged(object sender, EventArgs e)
        {
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "select distinct r.recipe_id,r.rp_type,r.feed_code,r.rp_feed_type,r.item_code,r.rp_description,r.rp_category,r.rp_group,r.quantity,raw.price,r.modified_by,r.last_modified,r.last_modified as ONE_TON, r.quantity as QTY_PROD,raw.price as TWO_TONS  from [dbo].[rdf_recipe] r LEFT JOIN [dbo].[rdf_raw_materials] raw ON r.item_code=raw.item_code WHERE r.feed_code = '" + cmb2.Text + "' AND r.is_active=1";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvImport2.DataSource = dt;

            txtmat2.Text = dgvImport2.RowCount.ToString();
            sql_con.Close();









            Equation2();
            sumofComparison();

            if(txt1.Text.Trim() == string.Empty)
            {
                return;
            }
            if (txt21.Text.Trim() == string.Empty)
            {
                return;
            }

            txtdiff1.Text = (float.Parse(txt1.Text) - float.Parse(txt21.Text)).ToString("#,0.00");
            txtdiff2.Text = (float.Parse(txt2.Text) - float.Parse(txt22.Text)).ToString("#,0.00");
            txtdiff3.Text = (float.Parse(txt3.Text) - float.Parse(txt23.Text)).ToString("#,0.00");
            txtdiff4.Text = (float.Parse(txt4.Text) - float.Parse(txt24.Text)).ToString("#,0.00");
        }


        public void sumofComparison()
        {

            //dgvImport2[6, dgvImport2.Rows.Count - 1].Value = "Total";
            //dgvImport2.Rows[dgvImport2.Rows.Count - 1].Cells[0].Style.BackColor = Color.Green;
            //dgvImport2.Rows[dgvImport2.Rows.Count - 1].Cells[0].Style.ForeColor = Color.Red;
            decimal tot = 0;

            for (int i = 0; i < dgvImport2.RowCount - 0; i++)
            {
                var value = dgvImport2.Rows[i].Cells["quantity3"].Value;
                if (value != DBNull.Value)
                {
                    tot += Convert.ToDecimal(value);
                }
            }
            if (tot == 0)
            {

            }

            txt21.Text = tot.ToString("#,0.00");
            //price

            decimal tot1 = 0;

            for (int i1 = 0; i1 < dgvImport2.RowCount - 0; i1++)
            {
                var value1 = dgvImport2.Rows[i1].Cells["price2"].Value;
                if (value1 != DBNull.Value)
                {
                    tot1 += Convert.ToDecimal(value1);
                }
            }
            if (tot1 == 0)
            {

            }


            txt22.Text = tot1.ToString("#,0.00");

            //1 tons

            decimal tot2 = 0;

            for (int i2 = 0; i2 < dgvImport2.RowCount - 0; i2++)
            {
                var value2 = dgvImport2.Rows[i2].Cells["ONE_TON"].Value;
                if (value2 != DBNull.Value)
                {
                    tot2 += Convert.ToDecimal(value2);
                }
            }
            if (tot2 == 0)
            {

            }
            txt23.Text = tot2.ToString("#,0.00");

            //2 tons


            decimal tot3 = 0;

            for (int i3 = 0; i3 < dgvImport2.RowCount - 0; i3++)
            {
                var value3 = dgvImport2.Rows[i3].Cells["TWO_TONS"].Value;
                if (value3 != DBNull.Value)
                {
                    tot3 += Convert.ToDecimal(value3);
                }
            }
            if (tot3 == 0)
            {

            }
            txt24.Text = tot3.ToString("#,0.00");




        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtmat1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
