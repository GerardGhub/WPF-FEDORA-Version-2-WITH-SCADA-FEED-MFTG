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
    public partial class frmusers : Form
    {
        myclasses xClass = new myclasses();

        myclasses myClass = new myclasses();
        IStoredProcedures g_objStoredProcCollection = null;
        IStoredProcedures objStorProc = null;
        DataSet dSet = new DataSet();
        DataSet dSet_temp = new DataSet();
        DataSet dset_search = new DataSet();

        Boolean ready = false;

        string mode = "";
        int temp_id = 0;
        //int emp_id = 0;

        public frmusers()
        {
            InitializeComponent();
        }

        private void frmusers_Load(object sender, EventArgs e)
        {
            dgv_table.Visible = false;
            g_objStoredProcCollection = myClass.g_objStoredProc.GetCollections();
            loadUser_type();
            getFillItem();
            objStorProc = xClass.g_objStoredProc.GetCollections();

            lstUsers_Click(sender, e);
            myglobal.global_module = "Active";

            load_search();
        
        }


        void load_search()
        {
            dset_emp.Clear();

            if (myglobal.global_module == "EMPLOYEE")
            { dset_emp = objStorProc.sp_getMajorTables("employee"); }
            else if (myglobal.global_module == "MICRO")
            { dset_emp = objStorProc.sp_getMajorTables("micro_raw_materialsnew"); }
            else if (myglobal.global_module == "Active")
            { dset_emp = objStorProc.sp_getMajorTables("usercurrentcellchanged"); }
            else if (myglobal.global_module == "InActive")
            { dset_emp = objStorProc.sp_getMajorTables("InactiveFeedCode"); }
            else if (myglobal.global_module == "MACRO")
            { dset_emp = objStorProc.sp_getMajorTables("macro_raw_materialsnew"); }
            else if (myglobal.global_module == "RESIGNED EMPLOYEE")
            { dset_emp = objStorProc.sp_getMajorTables("employee_B"); }
            else if (myglobal.global_module == "PHONEBOOK")
            { dset_emp = objStorProc.sp_getMajorTables("phonebook"); }
            else if (myglobal.global_module == "DA")
            { dset_emp = objStorProc.sp_getMajorTables("get_da"); }
            else if (myglobal.global_module == "ATTENDANCE")
            { dset_emp = objStorProc.sp_getMajorTables("attendance_monitoring"); }
            else if (myglobal.global_module == "VISITORS")
            { dset_emp = objStorProc.sp_getMajorTables("visitors"); }
            doSearch();

        }
        void loadUser_type()
        {
            ready = false;
            myClass.fillComboBox(cbousertype, "user_type", dSet);
            ready = true;
        }

        private void getFillItem()
        {
            ready = false;
            myClass.fillListBox(lstUsers, "users", dSet);

            ready = true;
        }

        private void visible_button(Boolean e)
        {
            btnAdd.Visible = e;
            btnEdit.Visible = e;
            btnDelete.Visible = e;
            btnClose.Visible = e;

            btnUpdate.Visible = !e;
            btnCancel.Visible = !e;
        }

        private void disable_text(Boolean e)
        {
            //txtnumber.ReadOnly = e;
            txtname.ReadOnly = e;
            txtuser.ReadOnly = e;
            txtpassword.ReadOnly = e;

            cbousertype.Enabled = !e;

        }

        private void lstUsers_Click(object sender, EventArgs e)
        {
            doSearch();
            showvalue();
        }
        private void showvalue()
        {
            if (ready == true)
            {
                if (lstUsers.Items.Count > 0)
                {
                    temp_id = Convert.ToInt32(lstUsers.SelectedValue.ToString());
                    txtuser.Text = lstUsers.Text;
                }
            }

        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            mode = "add";
            //myClass.clearTxt2(groupBox1);
            myClass.clearTxt(this);

            visible_button(true);
            disable_text(true);
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            mode = "add";
            btnAdd.Visible = false;
            btnUpdate.Visible = true;
            txtname.Focus();
            txtname.Enabled = true;
            txtname.Text = "";
            txtname.Focus();

            cbousertype.Enabled = true;
            cbousertype.Text = "";

            txtpassword.Enabled = true;
            txtpassword.Text = "";


            txtuser.Enabled = true;
            txtuser.Text = "";
            //myClass.clearTxt2(groupBox1);
            //myClass.clearTxt(this);
            //txtuser.Text = "";
            //visible_button(true);
            btnUpdate.Visible = true;
            disable_text(false);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            metroButton1_Click(sender, e);
        }
        void FillTextbox()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "FILL UP THE REQUIRED FIELDS";
            popup.ContentColor = Color.Black;
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

        void SaveSuccessfully()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "NEW USER SUCCESSFULLY SAVE";
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


        }


        void UpdateSuccessfully()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "USER UPDATED SUCCESSFULLY";
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


        }

        void DeleteSuccessfully()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "USER DELETED SUCCESSFULLY";
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


        }



        public bool saveMode()
        {
            if (mode == "add")
            {
                dSet.Clear();
                dSet = g_objStoredProcCollection.sp_userfile(0, txtuser.Text.Trim(), "","", "validate");

                if (dSet.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Username already exist...", "Users", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtuser.Focus();
                    return false;
                }
                else
                {
                    dSet.Clear();
                    dSet = g_objStoredProcCollection.sp_userfile(0, Convert.ToInt32(cbousertype.SelectedValue.ToString()), txtuser.Text.Trim(), txtpassword.Text.Trim(), txtname.Text,cmbLocation.Text,cmbNotif.Text, "add");

                    return true;
                }

            }
            else if (mode == "edit")
            {
                dSet.Clear();
                dSet = g_objStoredProcCollection.sp_userfile(temp_id, txtuser.Text.Trim(), "",cmbLocation.Text.Trim(), "getbyname");

                dSet_temp.Clear();
                dSet_temp = g_objStoredProcCollection.sp_userfile(temp_id, txtuser.Text.Trim(), "","", "getbyid");

                if (dSet.Tables[0].Rows.Count > 0)
                {
                    int tmpID = Convert.ToInt32(dSet.Tables[0].Rows[0][0].ToString());
                    if (tmpID == temp_id)
                    {
                        dSet.Clear();
                        dSet = g_objStoredProcCollection.sp_userfile(temp_id, Convert.ToInt32(cbousertype.SelectedValue.ToString()), txtuser.Text.Trim(), txtpassword.Text.Trim(), txtname.Text.Trim(),cmbLocation.Text.Trim(),cmbNotif.Text.Trim(), "edit");

                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Username already exist...", "Users", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtuser.Focus();
                        return false;
                    }
                }
                else
                {
                    dSet.Clear();
                    dSet = g_objStoredProcCollection.sp_userfile(temp_id, Convert.ToInt32(cbousertype.SelectedValue.ToString()), txtuser.Text.Trim(), txtpassword.Text.Trim(), txtname.Text.Trim(),cmbLocation.Text.Trim(),cmbNotif.Text.Trim(), "edit");

                    return true;
                }
            }
            else if (mode == "delete")
            {
                dSet.Clear();


                dSet_temp.Clear();
                dSet_temp = g_objStoredProcCollection.sp_userfile(temp_id, "", "","", "delete");

                return true;
            }

            return false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            lstUsers.Enabled = false;
            if (lstUsers.Items.Count > 0)
            {
                mode = "edit";
                txtname.Enabled = true;
                cbousertype.Enabled = true;
                txtuser.Enabled = true;
                txtpassword.Enabled = true;
                button1.Visible = true;
                btnEdit.Visible = false;
                //visible_button(true);
                //disable_text(true);

            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure that you want to Save the New User "+txtname.Text+"", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (txtname.Text.Trim() == "")
                {
                    //MessageBox.Show("Please enter username ", "Users", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    FillTextbox();
                    txtname.BackColor = Color.Yellow;
                    txtname.Focus();
                    return;
                }
                if (cbousertype.Text.Trim() == "")
                {
                    //MessageBox.Show("Please enter username ", "Users", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FillTextbox();
                    cbousertype.BackColor = Color.Yellow;
                    cbousertype.Focus();
                    return;
                }
                if (txtuser.Text.Trim() == "")
                {
                    //MessageBox.Show("Please enter username ", "Users", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FillTextbox();
                    txtuser.BackColor = Color.Yellow;
                    txtuser.Focus();
                    return;
                }
                if (txtpassword.Text.Trim() == "")
                {
                    //MessageBox.Show("Please enter username ", "Users", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FillTextbox();
                    txtpassword.BackColor = Color.Yellow;
                    txtpassword.Focus();
                    return;
                }
                else
                {
                    if (saveMode())
                    {
                        getFillItem();
                        if (lstUsers.Items.Count > 0)
                        {
                            int index = lstUsers.FindString(txtuser.Text, 0);
                            if (index == -1) { index = 0; }
                            lstUsers.SelectedIndex = index;
                        }

                        mode = "";
                        SaveSuccessfully();
                        visible_button(true);
                        disable_text(true);

                        lstUsers_Click(sender, e);
                    }
                }
                cmbLocation.Enabled = false;
                cmbNotif.Enabled = false;
                txtname.Enabled = false;

            }
            else
            {

                return;
            }
            
        }

        private void txtname_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtname_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtname.BackColor = Color.White;
        }

        private void txtuser_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtuser.BackColor = Color.White;
        }

        private void txtpassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtpassword.BackColor = Color.White;
        }

        private void cbousertype_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbousertype.BackColor = Color.White;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            metroButton2_Click(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            metroButton4_Click(sender,e);
        }

        private void txtuser_TextChanged(object sender, EventArgs e)
        {
            //doSearch();
        }
        DataSet dset_emp = new DataSet();

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
                        //  dv.RowFilter = "item_id like '%" + txtsearch.Text + "%' or item_code like '%" + txtsearch.Text + "%' or item_description like '%" + txtsearch.Text + "%'";
                        //dv.RowFilter = "item_id like '%" + txtsearch.Text + "%' or item_code like '%" + txtsearch.Text + "%'";
                        dv.RowFilter = "username like '%" + txtuser.Text + "%'";

                    }
                    else if (myglobal.global_module == "VISITORS")
                    {
                        //dv.RowFilter = "visitors_lastname like '%" + txtsearch.Text + "%' or visitors_firstname like '%" + txtsearch.Text + "%'";
                    }
                    dgv_table.DataSource = dv;
                    lblrecords.Text = dgv_table.RowCount.ToString();
                }
            }
            catch (SyntaxErrorException)
            {
                MessageBox.Show("Invalid character found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtuser.Focus();
                return;
            }
            catch (EvaluateException)
            {
                MessageBox.Show("Invalid character found 2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtuser.Focus();
                return;
            }
        }

        private void dgv_table_CurrentCellChanged(object sender, EventArgs e)
        {
            showActiveUser();
        }


        void showActiveUser()
        {

            if (dgv_table.RowCount > 0)
            {
                if (dgv_table.CurrentRow != null)
                {
                    if (dgv_table.CurrentRow.Cells["username"].Value != null)
                    {
                        //p_id = Convert.ToInt32(dgv_table.CurrentRow.Cells["recipe_id"].Value);

                        txtname.Text = dgv_table.CurrentRow.Cells["employee_name"].Value.ToString();
                        cbousertype.Text = dgv_table.CurrentRow.Cells["user_rights_name"].Value.ToString();
                       txtuser.Text = dgv_table.CurrentRow.Cells["username"].Value.ToString();
                        txtpassword.Text = dgv_table.CurrentRow.Cells["password"].Value.ToString();

                    cmbLocation.Text = dgv_table.CurrentRow.Cells["user_section"].Value.ToString();

                      cmbNotif.Text = dgv_table.CurrentRow.Cells["receiving_status"].Value.ToString();
                        //txtfeedcode1.Text = dgv_table.CurrentRow.Cells["feed_code"].Value.ToString();
                        //txtfeedtype1.Text = dgv_table.CurrentRow.Cells["rp_feed_type"].Value.ToString();
                        //txtmainstocks.Text = dgvMaster.CurrentRow.Cells["total_quantity_raw"].Value.ToString();

                        //cboCategor.Text = dgvMaster.CurrentRow.Cells["item_description"].Value.ToString();






                        //wala muna this


                    }

                }
            }

        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure that you want to Update the User Information ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (lstUsers.Items.Count > 0)
                {
                    //if (MessageBox.Show("Are you sure you want to update this record?", "Users", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    //{
                        mode = "edit";
                        if (saveMode())
                        {
                            getFillItem();
                            if (lstUsers.Items.Count > 0)
                            {
                                int index = lstUsers.FindString(txtuser.Text, 0);
                                if (index == -1) { index = 0; }
                                lstUsers.SelectedIndex = index;
                            }

                            mode = "";
                            visible_button(true);
                            disable_text(true);
                            UpdateSuccessfully();
                            load_search();
                            doSearch();
                            button1.Visible = false;
                            btnEdit.Visible = true;
                            lstUsers_Click(sender, e);
                        lstUsers.Enabled = false;
                    }
                    }
                //}
                cmbLocation.Enabled = false;
                cmbNotif.Enabled = false;
            }
            else
            {
                button1.Visible = false;
                btnEdit.Visible = true;
                lstUsers.Enabled = true;
                return;
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure that you want to Delete the User Information ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (lstUsers.Items.Count > 0)
                {
                    //if (MessageBox.Show("Are you sure you want to update this record?", "Users", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    //{
                    mode = "delete";
                    if (saveMode())
                    {
                        getFillItem();
                        if (lstUsers.Items.Count > 0)
                        {
                            int index = lstUsers.FindString(txtuser.Text, 0);
                            if (index == -1) { index = 0; }
                            lstUsers.SelectedIndex = index;
                        }

                        mode = "";
                        visible_button(true);
                        disable_text(true);
                        DeleteSuccessfully();
                        load_search();
                        doSearch();
                        button1.Visible = false;
                        btnEdit.Visible = true;
                        lstUsers_Click(sender, e);
                    }
                }
                //}

            }
            else
            {
                button1.Visible = false;
                btnEdit.Visible = true;
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            metroButton2_Click(sender, e);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            metroButton4_Click(sender, e);
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            lstUsers.Enabled = false;
            cmbLocation.Enabled = true;
            cmbNotif.Enabled = true;
            if (lstUsers.Items.Count > 0)
            {
                mode = "edit";
                txtname.Enabled = true;
                txtname.ReadOnly= false;
                cbousertype.Enabled = true;
                txtuser.Enabled = true;
                txtuser.ReadOnly = false;
                txtpassword.Enabled = true;
                txtpassword.ReadOnly = false;
                button1.Visible = true;
                btnEdit.Visible = false;
                //visible_button(true);
                //disable_text(true);

            }
        }

        private void btnAdd_Click_2(object sender, EventArgs e)
        {
            mode = "add";
            btnUpdate.Visible = true;
            btnAdd.Visible = false;
            btnUpdate.Visible = true;
            txtname.Focus();
            txtname.Enabled = true;
            txtname.Text = "";
            txtname.Focus();

            cbousertype.Enabled = true;
            cbousertype.Text = "";

            txtpassword.Enabled = true;
            txtpassword.Text = "";


            txtuser.Enabled = true;
            txtuser.Text = "";
            //myClass.clearTxt2(groupBox1);
            //myClass.clearTxt(this);
            //txtuser.Text = "";
            //visible_button(true);
            btnUpdate.Visible = true;
            disable_text(false);
            cmbLocation.Enabled = true;
            cmbNotif.Enabled = true;
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            metroButton1_Click(sender, e);
        }

        private void lstUsers_CursorChanged(object sender, EventArgs e)
        {
            doSearch();
            showvalue();
        }

        private void lstUsers_MouseClick(object sender, MouseEventArgs e)
        {
            //doSearch();
            //showvalue();
        }

        private void lstUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            doSearch();
            showvalue();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            myglobal.REPORT_NAME = "Users";

            frmReport frmReport = new frmReport();
            //frmReport.MdiParent = this;
            frmReport.Show();


        }

        private void lstUsers_SelectedValueChanged(object sender, EventArgs e)
        {
            doSearch();
            showvalue();
        }
    }
}
  

