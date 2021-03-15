using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFFDR
{
    public partial class frmGroup : Form
    {

        myclasses xClass = new myclasses();
        IStoredProcedures objStorProc = null;

        DataSet dSet = new DataSet();
        DataSet dset_section = new DataSet();
        DataSet dSet_temp = new DataSet();

        string mode = "";
        int p_id = 0; // variable for position id
        int d_id = 0;
        int temp_hid = 0;

        Boolean ready = false;
        public frmGroup()
        {
            InitializeComponent();
        }

        private void frmGroup_Load(object sender, EventArgs e)
        {
            objStorProc = xClass.g_objStoredProc.GetCollections();
            loadGroup();
            dgv1_CurrentCellChanged(sender, e);


            txtGroupName.Focus();
            DisableAndHide();
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
        void loadGroup()
        {
            ready = false;

            xClass.fillComboBox(cboGroup, "rdf_category", dSet);
            displayData(Convert.ToInt32(cboGroup.SelectedValue.ToString()));

            ready = true;
        }

        void displayData(int dept_id)
        {
            dset_section = objStorProc.sp_getFilterTables("filter_rdf_group", "", dept_id);

            if (dset_section.Tables.Count > 0)
            {
                DataView dv = new DataView(dset_section.Tables[0]);
                dgv1.DataSource = dv;
            }

        }

        private void dgv1_CurrentCellChanged(object sender, EventArgs e)
        {
            showRecords();

            // ToolStripBCancel.Visible = true;
            toolStripButtonDelete.Visible = true;

            toolStripButtonDelete.Visible = true;
            //   ToolStripButtonUpdate.Visible = true;
            ToolStripButtonEdit.Visible = true;
            cboGroup.Enabled = true;
        }

        void showRecords()
        {
            if (ready == true)
            {
                if (dgv1.CurrentRow != null)
                {
                    if (dgv1.CurrentRow.Cells["group_id"].Value != null)
                    {
                        p_id = Convert.ToInt32(dgv1.CurrentRow.Cells["group_id"].Value);
                        txtGroupName.Text = dgv1.CurrentRow.Cells["group_name"].Value.ToString();
                       txtDateAdded.Text = dgv1.CurrentRow.Cells["date_added"].Value.ToString();
                        txtAddedBy.Text = dgv1.CurrentRow.Cells["added_by"].Value.ToString();
                        cboGroup.Text = dgv1.CurrentRow.Cells["group_name"].Value.ToString();
                    }
                }
            }
        }





        public void DisableAndHide()
        {
            lblName.Visible = false;
            txtGroupName.Enabled = false;
            txtDateAdded.Enabled = false;
            txtAddedBy.Enabled = false;
            ToolStripBCancel.Visible = false;
            toolStripButtonDelete.Visible = true;
            toolStripButtonDelete.Visible = false;
            ToolStripButtonUpdate.Visible = false;
            toolStripButtonDelete.Visible = false;
            ToolStripButtonEdit.Visible = false;
        
            toolStripButtonMYUP.Visible = false;

        }

        private void cboGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ready == true)
                displayData(Convert.ToInt32(cboGroup.SelectedValue.ToString()));

            txtGroupName.Focus();
        }

        private void ToolStripButtonNew_Click(object sender, EventArgs e)
        {
            txtGroupName.Text = "";
            txtGroupName.Enabled = true;
            txtGroupName.Focus();
            txtDateAdded.Text = "";
            txtAddedBy.Text = "";



            txtDateAdded.Text = DateTime.Now.ToString("MM-dd-yyyy");
            cboGroup.Enabled = true;
            txtAddedBy.Text = userinfo.emp_name.ToUpper();

            ToolStripBCancel.Visible = true;
            ToolStripButtonUpdate.Visible = true;
        }

        private void ToolStripBCancel_Click(object sender, EventArgs e)
        {
            mode = "";
            toolStripButtonMYUP.Visible = false;
            ToolStripButtonNew.Visible = true;
            txtGroupName.Enabled = false;
            cboGroup.Enabled = false;
   

            ToolStripBCancel.Visible = false;
            toolStripButtonDelete.Visible = false;
            ToolStripButtonUpdate.Visible = false;
            ToolStripButtonEdit.Visible = false;
        }

        private void ToolStripButtonEdit_Click(object sender, EventArgs e)
        {
            ForEdit();
        }

        public void ForEdit()
        {
            txtGroupName.Enabled = true;
            ToolStripBCancel.Visible = true;
            toolStripButtonMYUP.Visible = true;

        }

        private void toolStripButtonMYUP_Click(object sender, EventArgs e)
        {
            mode = "edit";

            MessageBox.Show("Group Update SuccessFully " + lblName.Text + ". ", "Group", MessageBoxButtons.OK, MessageBoxIcon.Information);
            toolStripButtonMYUP.Visible = false;
            try
            {
                if (cboGroup.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please enter " + lblDepartment.Text + ". ", lblDepartment.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (txtGroupName.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please enter " + lblName.Text + ". ", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    if (saveMode())
                    {

                        if (cboGroup.Items.Count > 0)
                        {
                            int index = cboGroup.FindString(cboGroup.Text, 0);
                            if (index == -1) { index = 0; }
                            cboGroup.SelectedIndex = index;
                        }

                        displayData(Convert.ToInt32(cboGroup.SelectedValue.ToString()));
                        string tmode = mode;

                        if (tmode == "add")
                        {
                            dgv1.CurrentCell = dgv1[0, dgv1.Rows.Count - 1];
                        }
                        else
                        {
                            dgv1.CurrentCell = dgv1[0, temp_hid];
                        }

                        //  btnCancel_Click(sender, e);
                    }
                    else
                        MessageBox.Show("Unable to save record!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch
            {
                MessageBox.Show("Same value");
            }
        }



        public bool saveMode()
        {

            if (mode == "add")
            {
                dSet.Clear();
                //filter_feed_codes
                dSet = objStorProc.sp_getFilterTables("filter_rdf_group", txtGroupName.Text, Convert.ToInt32(cboGroup.SelectedValue.ToString()));
                if (dSet.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show(lblName.Text + " : [ " + txtGroupName.Text + " ] already exist...", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtGroupName.Focus();
                    return false;
                }

                else
                {
                    dSet.Clear();
                    dSet = objStorProc.rdf_sp_group(0, Convert.ToInt32(cboGroup.SelectedValue.ToString()), txtGroupName.Text, txtDateAdded.Text, txtAddedBy.Text, "add");

                    return true;
                }
            }
            else if (mode == "edit")
            {
                dSet.Clear();
                dSet = objStorProc.rdf_sp_group(0, 0, txtGroupName.Text, txtDateAdded.Text, txtAddedBy.Text, "getbyname");

                dSet_temp.Clear();
                dSet_temp = objStorProc.rdf_sp_group(p_id, 0, txtGroupName.Text, txtDateAdded.Text, txtAddedBy.Text, "getbyid");

                if (dSet.Tables[0].Rows.Count > 0)
                {
                    int tmpID = Convert.ToInt32(dSet.Tables[0].Rows[0][0].ToString());
                    int deptID = Convert.ToInt32(dSet.Tables[0].Rows[0][1].ToString());
                    if (tmpID == p_id)
                    {
                        dSet.Clear();
                        dSet = objStorProc.rdf_sp_group(p_id, Convert.ToInt32(cboGroup.SelectedValue.ToString()), txtGroupName.Text, txtDateAdded.Text, txtAddedBy.Text, "edit");


                        return true;
                    }
                    else if ((deptID == d_id) && (tmpID != p_id))
                    {
                        MessageBox.Show(lblName.Text + " : [ " + txtGroupName.Text + " ] already exist...", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtGroupName.Focus();
                        return false;
                    }
                }
                else
                {
                    dSet.Clear();
                    dSet = objStorProc.rdf_sp_group(p_id, Convert.ToInt32(cboGroup.SelectedValue.ToString()), txtGroupName.Text, txtDateAdded.Text, txtAddedBy.Text, "edit");


                    return true;
                }
            }
            else if (mode == "delete")
            {
                dSet.Clear();
                dSet = objStorProc.rdf_sp_group(p_id, 0, txtGroupName.Text, txtDateAdded.Text, txtAddedBy.Text, "delete");

                dSet_temp.Clear();
                dSet_temp = objStorProc.rdf_sp_group(p_id, 0, txtGroupName.Text, txtDateAdded.Text, txtAddedBy.Text, "delete");

                return true;
            }
            return false;
        }

        private void ToolStripButtonUpdate_Click(object sender, EventArgs e)
        {
            mode = "add";
            dSet = objStorProc.rdf_sp_group(0, Convert.ToInt32(cboGroup.SelectedValue.ToString()), txtGroupName.Text, txtDateAdded.Text, txtAddedBy.Text, "add");
            loadGroup();
            txtGroupName.Visible = false;
            try
            {
                if (cboGroup.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please enter " + lblDepartment.Text + ". ", lblDepartment.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (txtGroupName.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please enter value in the TextBox" + lblName.Text + ". ", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    if (saveMode())
                    {

                        if (cboGroup.Items.Count > 0)
                        {
                            int index = cboGroup.FindString(cboGroup.Text, 0);
                            if (index == -1) { index = 0; }
                            cboGroup.SelectedIndex = index;
                        }

                        displayData(Convert.ToInt32(cboGroup.SelectedValue.ToString()));
                        string tmode = mode;

                        if (tmode == "add")
                        {
                            dgv1.CurrentCell = dgv1[0, dgv1.Rows.Count - 1];
                        }
                        else
                        {
                            dgv1.CurrentCell = dgv1[0, temp_hid];
                        }

                        ToolStripBCancel_Click(sender, e);
                    }
                    else
                       MessageBox.Show("Unable to save record!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch
            {

                MessageBox.Show("Same values");
            }
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
           


            DialogResult dialogResult = MessageBox.Show("Are you Sure you want to Delete Selected Row?", "Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
                mode = "delete";
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
                return;
            }

            try
            {
                if (cboGroup.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please enter " + lblDepartment.Text + ". ", lblDepartment.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (txtGroupName.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please enter " + lblName.Text + ". ", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    if (saveMode())
                    {

                        if (cboGroup.Items.Count > 0)
                        {
                            int index = cboGroup.FindString(cboGroup.Text, 0);
                            if (index == -1) { index = 0; }
                            cboGroup.SelectedIndex = index;
                        }

                        displayData(Convert.ToInt32(cboGroup.SelectedValue.ToString()));
                        string tmode = mode;

                        if (tmode == "delete")
                        {
                            dgv1.CurrentCell = dgv1[0, dgv1.Rows.Count - 1];
                        }
                        else
                        {
                            dgv1.CurrentCell = dgv1[0, temp_hid];
                        }

                        //  btnCancel_Click(sender, e);
                        ToolStripBCancel_Click(sender, e);
                    }
                    else
                        MessageBox.Show("Unable to save record!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch
            {
                MessageBox.Show("Group Deleted SuccessFully " + lblName.Text + ". ", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
