using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFFDR
{
    public partial class frmSections : Form
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

        public frmSections()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSections_Load(object sender, EventArgs e)
        {

            objStorProc = xClass.g_objStoredProc.GetCollections();
            loadDepartment();
            dgv1_CurrentCellChanged(sender, e);

            DisableButton();
        }


        void showRecords()
        {
            if (ready == true)
            {
                if (dgv1.CurrentRow != null)
                {
                    if (dgv1.CurrentRow.Cells["section_id"].Value != null)
                    {
                        p_id = Convert.ToInt32(dgv1.CurrentRow.Cells["section_id"].Value);
                        txtSection.Text = dgv1.CurrentRow.Cells["section_name"].Value.ToString();
                        cboDepartment.Text = dgv1.CurrentRow.Cells["department_name"].Value.ToString();
                    }
                }
            }
        }

        void loadDepartment()
        {
            ready = false;

            xClass.fillComboBox(cboDepartment, "department", dSet);
           cboDepartment.SelectedValue.ToString();

            ready = true;
        }


        void displayData(int dept_id)
        {
            dset_section = objStorProc.sp_getFilterTables("filter_section_by_department_id", "", dept_id);

            if (dset_section.Tables.Count > 0)
            {
                DataView dv = new DataView(dset_section.Tables[0]);
                dgv1.DataSource = dv;
            }

        }

        public void DisableButton()
        {
            txtSection.Enabled = false;
            ToolStripBCancel.Visible = false;
            toolStripButtonDelete.Visible = true;
            toolStripButtonDelete.Visible = false;
            ToolStripButtonUpdate.Visible = false;
            toolStripButtonDelete.Visible = false;
            ToolStripButtonEdit.Visible = false;
          //  lblName.Visible = false;
            toolStripButtonMYUP.Visible = false;
          //  toolStripButtonCancel2.Visible = false;
        }

        private void dgv1_CurrentCellChanged(object sender, EventArgs e)
        {
            showRecords();

            // ToolStripBCancel.Visible = true;
            toolStripButtonDelete.Visible = true;

            toolStripButtonDelete.Visible = true;
            //   ToolStripButtonUpdate.Visible = true;
            ToolStripButtonEdit.Visible = true;
        }

        private void cboDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ready == true)
                displayData(Convert.ToInt32(cboDepartment.SelectedValue.ToString()));

            txtSection.Focus();
        }

        private void ToolStripButtonNew_Click(object sender, EventArgs e)
        {

            txtSection.Text = "";
            txtSection.Enabled = true;
            txtSection.Focus();
            ToolStripBCancel.Visible = true;
            ToolStripButtonUpdate.Visible = true;
        }

        private void ToolStripBCancel_Click(object sender, EventArgs e)
        {

            mode = "";
            toolStripButtonMYUP.Visible = false;
            ToolStripButtonNew.Visible = true;
            txtSection.Enabled = false;
            ToolStripBCancel.Visible = false;
            toolStripButtonDelete.Visible = false;
            ToolStripButtonUpdate.Visible = false;
            ToolStripButtonEdit.Visible = false;
        }

        private void ToolStripButtonUpdate_Click(object sender, EventArgs e)
        {
            mode = "add";
            try
            {
                if (cboDepartment.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please enter " + lblDepartment.Text + ". ", lblDepartment.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (txtSection.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please enter " + lblName.Text + ". ", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    if (saveMode())
                    {

                        if (cboDepartment.Items.Count > 0)
                        {
                            int index = cboDepartment.FindString(cboDepartment.Text, 0);
                            if (index == -1) { index = 0; }
                            cboDepartment.SelectedIndex = index;
                        }

                        displayData(Convert.ToInt32(cboDepartment.SelectedValue.ToString()));
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
                MessageBox.Show("Same value");
            }
        }


        public bool saveMode()
        {

            if (mode == "add")
            {
                dSet.Clear();

                dSet = objStorProc.sp_getFilterTables("filter_section", txtSection.Text, Convert.ToInt32(cboDepartment.SelectedValue.ToString()));
                if (dSet.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show(lblName.Text + " : [ " + txtSection.Text + " ] already exist...", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSection.Focus();
                    return false;
                }
                else
                {
                    dSet.Clear();
                    dSet = objStorProc.sp_section(0, Convert.ToInt32(cboDepartment.SelectedValue.ToString()), txtSection.Text, "add");

                    return true;
                }
            }
            else if (mode == "edit")
            {
                dSet.Clear();
                dSet = objStorProc.sp_section(0, 0, txtSection.Text, "getbyname");

                dSet_temp.Clear();
                dSet_temp = objStorProc.sp_section(p_id, 0, txtSection.Text, "getbyid");

                if (dSet.Tables[0].Rows.Count > 0)
                {
                    int tmpID = Convert.ToInt32(dSet.Tables[0].Rows[0][0].ToString());
                    int deptID = Convert.ToInt32(dSet.Tables[0].Rows[0][1].ToString());
                    if (tmpID == p_id)
                    {
                        dSet.Clear();
                        dSet = objStorProc.sp_section(p_id, Convert.ToInt32(cboDepartment.SelectedValue.ToString()), txtSection.Text, "edit");


                        return true;
                    }
                    else if ((deptID == d_id) && (tmpID != p_id))
                    {
                        MessageBox.Show(lblName.Text + " : [ " + txtSection.Text + " ] already exist...", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtSection.Focus();
                        return false;
                    }
                }
                else
                {
                    dSet.Clear();
                    dSet = objStorProc.sp_section(p_id, Convert.ToInt32(cboDepartment.SelectedValue.ToString()), txtSection.Text, "edit");


                    return true;
                }
            }
            else if (mode == "delete")
            {
                dSet.Clear();
                dSet = objStorProc.sp_section(p_id, 0, txtSection.Text, "delete");

                dSet_temp.Clear();
                dSet_temp = objStorProc.sp_section(p_id, 0, txtSection.Text, "delete");

                return true;
            }
            return false;
        }

        private void txtSection_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ToolStripButtonUpdate_Click(sender, e);
        }

        private void ToolStripButtonEdit_Click(object sender, EventArgs e)
        {
            ToolStripButtonNew.Visible = false;
            ToolStripButtonEdit.Visible = false;
            toolStripButtonMYUP.Visible = true;
            txtSection.Enabled = true;
            ToolStripBCancel.Visible = true;
            toolStripButtonDelete.Visible = false;
        }

        private void toolStripButtonMYUP_Click(object sender, EventArgs e)
        {
            mode = "edit";

            MessageBox.Show("Update SuccessFully " + lblName.Text + ". ", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            try
            {
                if (cboDepartment.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please enter " + lblDepartment.Text + ". ", lblDepartment.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (txtSection.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please enter " + lblName.Text + ". ", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    if (saveMode())
                    {

                        if (cboDepartment.Items.Count > 0)
                        {
                            int index = cboDepartment.FindString(cboDepartment.Text, 0);
                            if (index == -1) { index = 0; }
                            cboDepartment.SelectedIndex = index;
                        }

                        displayData(Convert.ToInt32(cboDepartment.SelectedValue.ToString()));
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

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            mode = "delete";

            MessageBox.Show("Section Deleted SuccessFully " + lblName.Text + ". ", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            try
            {
                if (cboDepartment.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please enter " + lblDepartment.Text + ". ", lblDepartment.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (txtSection.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please enter " + lblName.Text + ". ", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    if (saveMode())
                    {

                        if (cboDepartment.Items.Count > 0)
                        {
                            int index = cboDepartment.FindString(cboDepartment.Text, 0);
                            if (index == -1) { index = 0; }
                            cboDepartment.SelectedIndex = index;
                        }

                        displayData(Convert.ToInt32(cboDepartment.SelectedValue.ToString()));
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
    
    }
}
