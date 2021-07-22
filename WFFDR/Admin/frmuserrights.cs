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
    public partial class frmuserrights : Form
    {

        myclasses xClass = new myclasses();
        IStoredProcedures objStorProc = null;
        DataSet dSet = new DataSet();
        string mode = "";
        int p_id = 0;
        int menu_id;
        int pkey = 0;
        //int i;
        Boolean ready = false;

        //audit_trails maudit_trails = new audit_trails();
        DataSet dSet_temp = new DataSet();

        public frmuserrights()
        {
            InitializeComponent();
        }

        private void frmuserrights_Load(object sender, EventArgs e)
        {
            objStorProc = xClass.g_objStoredProc.GetCollections();
            displayRecords();
           //loadAvailableMenu();
            lstuser_rights_Click(sender, e);
            FalseButton();
            dataView.Enabled = false;
            lstmenu.Enabled = false;
        }


        void FalseButton()

        {
            btnMenuUpdate.Enabled = false;
            btnRemove.Enabled = false;
            btncancel2.Enabled = false;
            btnselect.Enabled = false;
            btndeselect.Enabled = false;


        }
        void loadAvailableMenu()
        {
            xClass.fillDataGridView(dataView, cbcategory.Text, dSet);
            dataView.Columns[2].Width = 500;
            dataView.Columns[1].Width = 50;
            dataView.Columns[0].Width = 30;
            dataView.Columns[2].HeaderText = "Menu Name";
            dataView.Columns[3].Visible = false;
        }

        void displayRecords()
        {
            ready = false;
            xClass.fillListBox(lstuser_rights, "user_rights", dSet);
            ready = true;
        }

        private void lstuser_rights_Click(object sender, EventArgs e)
        {
            btnDelete.Visible = true;
            btnAddMenu.Visible = true;
            showvalue();
            loadMenu_byUsers();
        }

        public bool saveMode()
        {
            if (mode == "add")
            {
                dSet.Clear();
                dSet = objStorProc.sp_user_rights(0, txtRights.Text, "getbyname");

                if (dSet.Tables[0].Rows.Count > 0)
                {
                    Rightexists();
                    //MessageBox.Show(lblName.Text + " : [ " + txtRights.Text + " ] already exist...", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtRights.Focus();
                    return false;
                }
                else
                {
                    dSet.Clear();
                    dSet = objStorProc.sp_user_rights(0, txtRights.Text, "add");


                    return true;
                }
            }
            else if (mode == "edit")
            {
                dSet.Clear();
                dSet = objStorProc.sp_user_rights(0, txtRights.Text, "getbyname");

                dSet_temp.Clear();
                dSet_temp = objStorProc.sp_user_rights(p_id, txtRights.Text, "getbyid");

                if (dSet.Tables[0].Rows.Count > 0)
                {
                    int tmpID = Convert.ToInt32(dSet.Tables[0].Rows[0][0].ToString());
                    if (tmpID == p_id)
                    {
                        dSet.Clear();
                        dSet = objStorProc.sp_user_rights(p_id, txtRights.Text, "edit");


                        return true;
                    }
                    else
                    {
                        MessageBox.Show(lblName.Text + " : [ " + txtRights.Text + " ] already exist...", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtRights.Focus();
                        return false;
                    }
                }
                else
                {
                    dSet.Clear();
                    dSet = objStorProc.sp_user_rights(p_id, txtRights.Text, "edit");

                    return true;
                }
            }
            else if (mode == "delete")
            {
                dSet.Clear();
                dSet = objStorProc.sp_user_rights(p_id, txtRights.Text, "delete");

                dSet_temp.Clear();
                dSet_temp = objStorProc.sp_user_rights(p_id, txtRights.Text, "delete");

                return true;
            }
            return false;
        }
        void showvalue()
        {
            if (ready == true)
            {
                if (lstuser_rights.Items.Count > 0)
                {
                    p_id = Convert.ToInt32(lstuser_rights.SelectedValue.ToString());
                    txtRights.Text = lstuser_rights.Text;
                }
            }
        }

        private void lstuser_rights_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadMenu_byUsers();
        }

        void loadMenu_byUsers()
        {
            ready = false;
            xClass.fillListBox_Id(lstmenu, "filter_users", dSet, p_id, 0, 0);
            ready = true;
        }


        void selectAll()
        {
            for (int i = 0; i < dataView.RowCount; i++) { dataView.Rows[i].Cells[0].Value = true; }
        }
        void deselectAll()
        {
            for (int i = 0; i < dataView.RowCount; i++) { dataView.Rows[i].Cells[0].Value = false; }
        }

        private void dgv1_Click(object sender, EventArgs e)
        {
            menu_id = Convert.ToInt32(dataView.SelectedCells[1].Value);
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            mode = "add";
            btnAdd.Visible = false;
            //panel1.Visible = false;
            btnUpdate.Visible = true;
            txtRights.ReadOnly = false;
            btnDelete.Visible = false;
            btnAddMenu.Visible = false;
            txtRights.Text = "";
            txtRights.Focus();
            lstuser_rights.Enabled = false;
            //loadAvailableMenu();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            mode = "edit";
            //panel1.Visible = false;
            txtRights.ReadOnly = false;
            txtRights.Focus();
            lstuser_rights.Enabled = false;

            btnUpdate.Visible = true;
            btnEdit.Visible = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtRights.Text.Trim() == string.Empty)
            {
                SelectUserRights();
                lstuser_rights.Enabled = true;
                lstuser_rights.Focus();
                //txtRights.Focus();
                return;
                //MessageBox.Show("Please enter " + lblName.Text + ". ", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            metroButton3_Click(sender,e);
            //if (lstuser_rights.Items.Count > 0)
            //{
            //    if (MessageBox.Show("Are you sure you want to delete this record?", lblName.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            //    {
            //        mode = "delete";
            //        if (saveMode())
            //        {
            //            displayRecords();
            //            if (lstuser_rights.Items.Count > 0)
            //            {
            //                int index = lstuser_rights.FindString(txtRights.Text, 0);
            //                if (index == -1) { index = 0; }
            //                lstuser_rights.SelectedIndex = index;
            //            }
            //            mode = "";
            //            lstuser_rights_Click(sender, e);
            //        }
            //    }
            //}
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            mode = "";
            btnAdd.Visible = true;
            btnUpdate.Visible = false;
            btnEdit.Visible = true;
            txtRights.ReadOnly = true;
            lstuser_rights.Enabled = true;
            dataView.Visible = false;
            cbcategory.Visible = false;
            label3.Visible = false;


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtRights.Text.Trim() == string.Empty)
            {
                FillUserRights();
                txtRights.Focus();
                return;
                //MessageBox.Show("Please enter " + lblName.Text + ". ", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            metroButton2_Click(sender,e);
 
        }

        private void btnAddMenu_Click(object sender, EventArgs e)
        {
          
            dataView.Visible = true;
            label3.Visible = true;
            btncancel2.Visible = true;
            //loadAvailableMenu();
            dataView.Enabled = true;
            lstmenu.Enabled = true;
            lstuser_rights.Enabled = false;
            //panel3.Enabled = true;
            //panel2.Enabled = false;
            //panel1.Enabled = false;
            cbcategory.Visible = true;
            label3.Visible = true;

            btnAdd.Visible = false;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnCancel.Visible = false;
            btnEdit.Visible = false;
            panel3Enabled();
            UpdateMenu();
        }

        void UpdateMenu()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "FORMS AVAILABLE ACTIVATED !";
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


        void SaveUpdateMenu()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "SUCCESSFULLY UPDATE THE FORMS";
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
        void RemoveMenu()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "SUCCESSFULLY UNSELECT THE SELECTED MODULE";
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

        void Rightexists()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "WARNING USER RIGHTS ALREADY EXISTS " + txtRights.Text + " ";
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


        void panel3Enabled()
        {
            btnMenuUpdate.Enabled = true;
            btnRemove.Enabled = true;
            btncancel2.Enabled = true;
            btnselect.Enabled = true;
            btndeselect.Enabled = true;

        }

        private void btnMenuUpdate_Click(object sender, EventArgs e)
        {
            int x = 0;
            for (int i = 0; i < dataView.RowCount; i++)
            {
                if (Convert.ToBoolean(dataView.Rows[i].Cells[0].Value))
                    x++;
            }
            if (x <= 0)
            {
                MessageBox.Show("Please select a menu before updating.", "Incomplete Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
          
            }
            else
            {

                showvalue();
                for (int n = 0; n < dataView.RowCount; n++)
                {
                    if (Convert.ToBoolean(dataView.Rows[n].Cells[0].Value))
                    {
                        dSet.Clear();
                        dSet = objStorProc.sp_getMenu_by_user("get_already_added_forms", 0, p_id, Convert.ToInt32(dataView.Rows[n].Cells[1].Value));
                        if (dSet.Tables[0].Rows.Count > 0)
                        {
                            string temp = dSet.Tables[0].Rows[0][2].ToString();
                            MessageBox.Show("This menu is already added on your rights: " + temp);
                            deselectAll();
                            return;
                        }
                    }
                }

                for (int i = 0; i < dataView.RowCount; i++)
                {
                    dSet.Clear();
                    if (Convert.ToBoolean(dataView.Rows[i].Cells[0].Value))
                    {
                        dSet = objStorProc.sp_user_rights_details(0, p_id, Convert.ToInt32(dataView.Rows[i].Cells[1].Value), "add");
                    }
                }

                loadMenu_byUsers();
                SaveUpdateMenu();
                btndeselect_Click(sender, e);
                btncancel2_Click(sender, e);
                //panel1.Enabled = true;
            }
        }

        private void btncancel2_Click(object sender, EventArgs e)
        {

            btnselect.Visible = false;
            btndeselect.Visible = false;
            dataView.Visible = false;
            label3.Visible = false;
            btncancel2.Visible = false;
            //panel3.Enabled = false;
            //panel2.Enabled = true;
            //panel1.Enabled = true;
            deselectAll();
            dataView.Enabled = false;
            lstmenu.Enabled = false;
            lstuser_rights.Enabled = true;
            cbcategory.Visible = false;
            label3.Visible = false;
            btnAdd.Visible = true;
            btnUpdate.Visible = true;
            btnDelete.Visible = true;
            btnCancel.Visible = true;
            //btnEdit.Visible = true;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstmenu.Items.Count > 0)
            {
                showKey();
                dSet.Clear();
                dSet = objStorProc.sp_user_rights_details(pkey, "delete");

                dSet_temp.Clear();
                dSet_temp = objStorProc.sp_user_rights_details(pkey, "delete");

                lstuser_rights_Click(sender, e);
                RemoveMenu();

            }
        }


        private void showKey()
        {
            if (ready == true)
            {
                if (lstmenu.Items.Count > 0)
                {
                    pkey = Convert.ToInt32(lstmenu.SelectedValue.ToString());
                    loadMenu_byUsers();
                }
            }
        }

        private void btnselect_Click(object sender, EventArgs e)
        {
            selectAll();
            //metroButton1_Click(sender, e);
        }

        private void btndeselect_Click(object sender, EventArgs e)
        {
            deselectAll();
        }

        private void txtRights_TextChanged(object sender, EventArgs e)
        {
            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "select ks.menu_name AS MENU from [dbo].[user_rights] ra LEFT JOIN [dbo].[user_rights_details] ud ON ra.user_rights_id = ud.user_rights_id LEFT JOIN [dbo].[available_menu] ks ON ud.menu_id=ks.menu_id WHERE user_rights_name = '" + txtRights.Text + "' AND ud.is_active='1'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvAllFeedCode.DataSource = dt;
         
            sql_con.Close();
        }

        private void dgvAllFeedCode_CurrentCellChanged(object sender, EventArgs e)
        {
       
        }


        private void txtyourid_TextChanged(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure that you want to Insert The Policy", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                btnMenuUpdate_Click(sender, e);
                //this.ParentForm.Refresh();

            }
            else
            {

                return;
            }
        }

        private void dgv1_DoubleClick(object sender, EventArgs e)
        {
            metroButton1_Click(sender, e);
        
            }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure that you want to Removed The Access on Selected Form Menu", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                btnRemove_Click( sender, e);

            }
            else
            {

                return;
            }
        }

        private void lstmenu_DoubleClick(object sender, EventArgs e)
        {
            Delete_Click(sender,e);
        }
        void FillUserRights()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "WARNING FILL UP THE USER RIGHTS";
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

        void SelectUserRights()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Please Select User Rights";
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

        void UserRightsUpdated()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "USER RIGHTS UPDATED";
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
        void UserRightDeleted()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "USER RIGHTS DELETED SUCCESSFULLY !";
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

        private void metroButton2_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure that you want to Save the New User Type", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (txtRights.Text.Trim() == string.Empty)
                {
                    FillUserRights();
                    txtRights.Focus();
                    //MessageBox.Show("Please enter " + lblName.Text + ". ", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (saveMode())
                    {
                        displayRecords();
                        btnEdit.Visible = true;
                        btnUpdate.Visible = false;
                        if (lstuser_rights.Items.Count > 0)
                        {
                            int index = lstuser_rights.FindString(txtRights.Text, 0);
                            if (index == -1) { index = 0; }
                            lstuser_rights.SelectedIndex = index;
                        }
                        btnCancel_Click("", e);
                        btnAdd.Visible = true;
                        UserRightsUpdated();
                    }
                }

            }
            else
            {

                return;
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure that you want to Removed The User Right ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
             if (lstuser_rights.Items.Count > 0)
                {
                    //if (MessageBox.Show("Are you sure you want to delete this record?", lblName.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    //{
                        mode = "delete";
                        if (saveMode())
                        {
                            displayRecords();
                            if (lstuser_rights.Items.Count > 0)
                            {
                                int index = lstuser_rights.FindString(txtRights.Text, 0);
                                if (index == -1) { index = 0; }
                                lstuser_rights.SelectedIndex = index;
                            }
                            mode = "";
                            lstuser_rights_Click(sender, e);
                        UserRightDeleted();
                        }
                    }
                //}

            }
            else
            {

                return;
            }
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure that you want Update the User Rights", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
           

            }
            else
            {

                return;
            }
        }

        private void dgv1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbcategory_DropDownClosed(object sender, EventArgs e)
        {
            loadAvailableMenu();
            btnselect.Visible = true;
            btndeselect.Visible = true;
        }

        private void frmuserrights_FormClosing(object sender, FormClosingEventArgs e)
        {

            //MDIParent1 takla = new MDIParent1();
            //takla.MDIParent1_Load(sender, e);
            //test.Refresh();
            //test.Show();
        }
    }
}
