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
    public partial class frmFeedcode : Form
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

        public frmFeedcode()
        {
            InitializeComponent();
        }

        private void frmFeedcode_Load(object sender, EventArgs e)
        {
            button1.Visible = false;
            //5j Form.Height = this.Height - 190;

            objStorProc = xClass.g_objStoredProc.GetCollections();
            loadFeedCode();
            dgv1_CurrentCellChanged(sender, e);


            txtFeedCode.Focus();
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
        public void DisableAndHide()
        {

            txtFeedCode.Enabled = false;
            txtFeedType.Enabled = false;
            txtSacksColor.Enabled = false;
            ToolStripBCancel.Visible = false;
            toolStripButtonDelete.Visible = true;
            toolStripButtonDelete.Visible = false;
            ToolStripButtonUpdate.Visible = false;
            toolStripButtonDelete.Visible = false;
            ToolStripButtonEdit.Visible = false;
    
            toolStripButtonMYUP.Visible = false;
      
        }

        void loadFeedCode()
        {
            ready = false;

            xClass.fillComboBox(cboProdType, "prod_type", dSet);
            displayData(Convert.ToInt32(cboProdType.SelectedValue.ToString()));

            ready = true;
        }
        private void ToolStripButtonNew_Click(object sender, EventArgs e)
        {
            txtFeedCode.Text = "";
            txtFeedCode.Enabled = true;
            txtFeedCode.Focus();
            txtFeedType.Text = "";
            txtFeedType.Enabled = true;
            txtSacksColor.Text = "";
            txtSacksColor.Enabled = true;

            ToolStripBCancel.Visible = true;
            ToolStripButtonUpdate.Visible = true;
        }

        private void ToolStripBCancel_Click(object sender, EventArgs e)
        {
            mode = "";
            toolStripButtonMYUP.Visible = false;
            ToolStripButtonNew.Visible = true;
            txtFeedCode.Enabled = false;
            txtFeedType.Enabled = false;
            txtSacksColor.Enabled = false;

            ToolStripBCancel.Visible = false;
            toolStripButtonDelete.Visible = false;
            ToolStripButtonUpdate.Visible = false;
            ToolStripButtonEdit.Visible = false;
        }

        private void lstFeedCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ready == true)
                displayData(Convert.ToInt32(cboProdType.SelectedValue.ToString()));

            txtFeedCode.Focus();
        }


        void displayData(int dept_id)
        {
            dset_section = objStorProc.sp_getFilterTables("filter_type_by_prod_type", "", dept_id);

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
        }

        void showRecords()
        {
            if (ready == true)
            {
                if (dgv1.CurrentRow != null)
                {
                    if (dgv1.CurrentRow.Cells["feed_id"].Value != null)
                    {
                        p_id = Convert.ToInt32(dgv1.CurrentRow.Cells["feed_id"].Value);
                        txtFeedCode.Text = dgv1.CurrentRow.Cells["feed_code"].Value.ToString();
                        txtFeedType.Text = dgv1.CurrentRow.Cells["feed_type"].Value.ToString();
                      txtSacksColor.Text = dgv1.CurrentRow.Cells["sack_color"].Value.ToString();
                        cboProdType.Text = dgv1.CurrentRow.Cells["type_name"].Value.ToString();
                    }
                }
            }
        }
        public void ForEdit()
        {
            txtFeedCode.Enabled = true;
            txtFeedType.Enabled = true;
            txtSacksColor.Enabled = true;
            toolStripButtonMYUP.Visible = true;

        }

        private void cboProdType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ready == true)
                displayData(Convert.ToInt32(cboProdType.SelectedValue.ToString()));

            txtFeedCode.Focus();
        }

        private void ToolStripButtonEdit_Click(object sender, EventArgs e)
        {
            ForEdit();
        }

        private void toolStripButtonMYUP_Click(object sender, EventArgs e)
        {
            mode = "edit";

            MessageBox.Show("Update SuccessFully " + lblName.Text + ". ", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            try
            {
                if (cboProdType.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please enter " + lblDepartment.Text + ". ", lblDepartment.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (txtFeedCode.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please enter " + lblName.Text + ". ", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    if (saveMode())
                    {

                        if (cboProdType.Items.Count > 0)
                        {
                            int index = cboProdType.FindString(cboProdType.Text, 0);
                            if (index == -1) { index = 0; }
                            cboProdType.SelectedIndex = index;
                        }

                        displayData(Convert.ToInt32(cboProdType.SelectedValue.ToString()));
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

        //bading 
        public bool saveMode()
        {

            if (mode == "add")
            {
                dSet.Clear();

                dSet = objStorProc.sp_getFilterTables("filter_feed_codes", txtFeedCode.Text, Convert.ToInt32(cboProdType.SelectedValue.ToString()));
                if (dSet.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show(lblName.Text + " : [ " + txtFeedCode.Text + " ] already exist...", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtFeedCode.Focus();
                    return false;
                }
                else
                {
                    dSet.Clear();
                    dSet = objStorProc.rdf_sp_feed_code(0, Convert.ToInt32(cboProdType.SelectedValue.ToString()), txtFeedCode.Text,txtFeedType.Text,txtSacksColor.Text, "add");

                    return true;
                }
            }
            else if (mode == "edit")
            {
                dSet.Clear();
                dSet = objStorProc.rdf_sp_feed_code(0, 0, txtFeedCode.Text, txtFeedType.Text, txtSacksColor.Text, "getbyname");

                dSet_temp.Clear();
                dSet_temp = objStorProc.rdf_sp_feed_code(p_id, 0, txtFeedCode.Text, txtFeedType.Text, txtSacksColor.Text, "getbyid");

                if (dSet.Tables[0].Rows.Count > 0)
                {
                    int tmpID = Convert.ToInt32(dSet.Tables[0].Rows[0][0].ToString());
                    int deptID = Convert.ToInt32(dSet.Tables[0].Rows[0][1].ToString());
                    if (tmpID == p_id)
                    {
                        dSet.Clear();
                        dSet = objStorProc.rdf_sp_feed_code(p_id, Convert.ToInt32(cboProdType.SelectedValue.ToString()), txtFeedCode.Text, txtFeedType.Text, txtSacksColor.Text, "edit");


                        return true;
                    }
                    else if ((deptID == d_id) && (tmpID != p_id))
                    {
                        MessageBox.Show(lblName.Text + " : [ " + txtFeedCode.Text + " ] already exist...", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtFeedCode.Focus();
                        return false;
                    }
                }
                else
                {
                    dSet.Clear();
                    dSet = objStorProc.rdf_sp_feed_code(p_id, Convert.ToInt32(cboProdType.SelectedValue.ToString()), txtFeedCode.Text, txtFeedType.Text, txtSacksColor.Text, "edit");


                    return true;
                }
            }
            else if (mode == "delete")
            {
                dSet.Clear();
                dSet = objStorProc.rdf_sp_feed_code(p_id, 0, txtFeedCode.Text, txtFeedType.Text, txtSacksColor.Text, "delete");

                dSet_temp.Clear();
                dSet_temp = objStorProc.rdf_sp_feed_code(p_id, 0, txtFeedCode.Text, txtFeedType.Text, txtSacksColor.Text, "delete");

                return true;
            }
            return false;
        }

        private void ToolStripButtonUpdate_Click(object sender, EventArgs e)
        {
            mode = "add";
            dSet = objStorProc.rdf_sp_feed_code(0, Convert.ToInt32(cboProdType.SelectedValue.ToString()), txtFeedCode.Text, txtFeedType.Text, txtSacksColor.Text, "add");
            loadFeedCode();
            try
            {
                if (cboProdType.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please enter " + lblDepartment.Text + ". ", lblDepartment.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (txtFeedCode.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please enter " + lblName.Text + ". ", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    if (saveMode())
                    {

                        if (cboProdType.Items.Count > 0)
                        {
                            int index = cboProdType.FindString(cboProdType.Text, 0);
                            if (index == -1) { index = 0; }
                            cboProdType.SelectedIndex = index;
                        }

                        displayData(Convert.ToInt32(cboProdType.SelectedValue.ToString()));
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
            mode = "delete";

   
            try
            {
                if (cboProdType.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please enter " + lblDepartment.Text + ". ", lblDepartment.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (txtFeedCode.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please enter " + lblName.Text + ". ", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    if (saveMode())
                    {

                        if (cboProdType.Items.Count > 0)
                        {
                            int index = cboProdType.FindString(cboProdType.Text, 0);
                            if (index == -1) { index = 0; }
                            cboProdType.SelectedIndex = index;
                        }

                        displayData(Convert.ToInt32(cboProdType.SelectedValue.ToString()));
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
                   MessageBox.Show("Feed Code Deleted SuccessFully " + lblName.Text + ". ", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random slumpGenerator = new Random();
            int tal = slumpGenerator.Next(0, 1000);
            txtFeedCode.Text = tal.ToString();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            doSearch();
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
                        dv.RowFilter = "firstname like '%" + txtsearch.Text + "%' or lastname like '%" + txtsearch.Text + "%' or employee_number like '%" + txtsearch.Text + "%' or employment_status_name like '%" + txtsearch.Text + "%'";
                    }
                    else if (myglobal.global_module == "RESIGNED EMPLOYEE")
                    {
                        dv.RowFilter = "firstname like '%" + txtsearch.Text + "%' or lastname like '%" + txtsearch.Text + "%' or employee_number like '%" + txtsearch.Text + "%' or employment_status_name like '%" + txtsearch.Text + "%'";
                    }
                    else if (myglobal.global_module == "PHONEBOOK")
                    {
                        dv.RowFilter = "company_name like '%" + txtsearch.Text + "%' or contact_name like '%" + txtsearch.Text + "%'";
                    }
                    else if (myglobal.global_module == "DA")
                    {
                        dv.RowFilter = "employee_name like '%" + txtsearch.Text + "%' or employee_number like '%" + txtsearch.Text + "%' or da_number like '%" + txtsearch.Text + "%'";
                    }
                    else if (myglobal.global_module == "ATTENDANCE")
                    {
                        dv.RowFilter = "lastname like '%" + txtsearch.Text + "%' or firstname like '%" + txtsearch.Text + "%'";
                    }
                    else if (myglobal.global_module == "VISITORS")
                    {
                        dv.RowFilter = "visitors_lastname like '%" + txtsearch.Text + "%' or visitors_firstname like '%" + txtsearch.Text + "%'";
                    }
                    dgv1.DataSource = dv;
                    lblrecords.Text = dgv1.RowCount.ToString();
                }
            }
            catch (SyntaxErrorException)
            {
                MessageBox.Show("Invalid character found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtsearch.Focus();
                return;
            }
            catch (EvaluateException)
            {
                MessageBox.Show("Invalid character found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtsearch.Focus();
                return;
            }
        }

    }
}
