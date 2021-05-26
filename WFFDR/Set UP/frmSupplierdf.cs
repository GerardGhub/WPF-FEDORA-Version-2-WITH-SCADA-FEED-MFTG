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
    public partial class frmSupplierdf : Form
    {
        myclasses xClass = new myclasses();

        IStoredProcedures objStorProc = null;

        DataSet dSet = new DataSet();
        DataSet dset_offense = new DataSet();

        string mode = "";
        int p_id = 0;
        int temp_hid = 0;

        Boolean ready = false;

        DataSet dSet_temp = new DataSet();

        public frmSupplierdf()
        {
            InitializeComponent();
        }

        private void ToolStripButtonNew_Click(object sender, EventArgs e)
        {
            txtSupplier.Text = "";
            txtSupplier.Enabled = true;
            txtSupplier.Focus();

            //Contact
            txtContactNo.Text = "";
            txtContactNo.Enabled = true;

            //Address
            txtAddress.Text = "";
            txtAddress.Enabled = true;

            //Email Address
            txtEmailAddress.Text = "";
            txtEmailAddress.Enabled = true;

            toolStripButtonCancel2.Visible = true;
            ToolStripButtonUpdate.Visible = true;
        }

        private void frmSupplierdf_Load(object sender, EventArgs e)
        {
            objStorProc = xClass.g_objStoredProc.GetCollections();
            loadSupplier();
            DisableButton();

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
        public void DisableButton()
        {
            //lblName.Visible = false;
            txtSupplier.Enabled = false;
            txtContactNo.Enabled = false;
            txtEmailAddress.Enabled = false;
            txtAddress.Enabled = false;

            // ToolStripBCancel.Visible = false;
            toolStripButtonDelete.Visible = true;
            toolStripButtonDelete.Visible = false;
            ToolStripButtonUpdate.Visible = false;
            toolStripButtonDelete.Visible = false;
            ToolStripButtonEdit.Visible = false;
            //lblNames.Visible = false;
            toolStripButtonMYUP.Visible = false;
            toolStripButtonCancel2.Visible = false;
        }


        void loadSupplier()
        {
            dset_offense.Clear();
            dset_offense = objStorProc.sp_getMajorTables("get_rdf_supplier");

            if (dset_offense.Tables[0].Rows.Count > 0)
            {
                DataView dv = new DataView(dset_offense.Tables[0]);
                dgv1.DataSource = dv;

                string mcolumns = "test,supplier_id,supplier,contact_no,address,email_address";
                for (int i = 0; i < dgv1.Columns.Count; i++)
                {
                    if (mcolumns.IndexOf(dgv1.Columns[i].Name.ToString()) > 0)
                    {
                        dgv1.Columns[i].Visible = true;
                    }
                    else
                    {
                        dgv1.Columns[i].Visible = false;
                    }
                }
            }
        }

        private void toolStripButtonCancel2_Click(object sender, EventArgs e)
        {
            mode = "";
            toolStripButtonMYUP.Visible = false;
            ToolStripButtonNew.Visible = true;
            txtSupplier.Enabled = false;
            txtContactNo.Enabled = false;
            txtAddress.Enabled = false;
            txtEmailAddress.Enabled = false;

            toolStripButtonCancel2.Visible = false;
            toolStripButtonDelete.Visible = false;
            ToolStripButtonUpdate.Visible = false;
            ToolStripButtonEdit.Visible = false;
        }

        private void ToolStripButtonUpdate_Click(object sender, EventArgs e)
        {
            mode = "add";
            if (txtSupplier.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter Supplier Name", "Supplier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtContactNo.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter Contact Details", "Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (saveMode())
                {
                    loadSupplier();
                    string tmode = mode;

                    if (tmode == "add")
                    {
                         //  dgv1.CurrentCell = dgv1[0, dgv1.Rows.Count - 1];

                        MessageBox.Show("Supplier Added SuccesFully.", "Supplier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ToolStripButtonUpdate.Visible = false;
                    }
                    else
                    {
                        dgv1.CurrentCell = dgv1[0, temp_hid];
                    }

                   /// btnCancel_Click(sender, e);

                }
                else
                    MessageBox.Show("Failed");
                //frmMenu sa = new frmMenu();

                //sa.ActivitiesLogs(userinfo.emp_name + "update offenses");
            }
        }



        public bool saveMode()
        {

            if (mode == "add")
            {
                dSet.Clear();
                dSet = objStorProc.rdf_sp_supplier(0, txtSupplier.Text, "","","", "getbyname");

                if (dSet.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Offense code is already added.", "Offense", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSupplier.Focus();
                    return false;
                }
                else
                {
                    dSet.Clear();
                    dSet = objStorProc.rdf_sp_supplier(0, txtSupplier.Text.Trim(), txtContactNo.Text.Trim(), txtAddress.Text.Trim(), txtEmailAddress.Text.Trim(), "add");

                    return true;
                }
            }
            else if (mode == "edit")
            {
                dSet.Clear();
                dSet = objStorProc.rdf_sp_supplier(0, txtSupplier.Text, txtContactNo.Text,txtAddress.Text,txtEmailAddress.Text, "getbyname");

                dSet_temp.Clear();
                dSet_temp = objStorProc.rdf_sp_supplier(p_id, txtSupplier.Text, txtContactNo.Text,txtAddress.Text,txtEmailAddress.Text, "getbyid");

                if (dSet.Tables[0].Rows.Count > 0)
                {
                    int tmpID = Convert.ToInt32(dSet.Tables[0].Rows[0][0].ToString());
                    if (tmpID == p_id)
                    {
                        dSet.Clear();
                        dSet = objStorProc.rdf_sp_supplier(p_id, txtSupplier.Text.Trim(), txtContactNo.Text.Trim(), txtAddress.Text.Trim(), txtEmailAddress.Text.Trim(), "edit");


                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Offense code is already added.", "Offense", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtSupplier.Focus();
                        return false;
                    }
                }
                else
                {
                    dSet.Clear();
                    dSet = dSet = objStorProc.rdf_sp_supplier(p_id, txtSupplier.Text.Trim(), txtContactNo.Text.Trim(), txtAddress.Text.Trim(), txtEmailAddress.Text.Trim(), "edit");


                    return true;
                }
            }
            else if (mode == "delete")
            {
                dSet.Clear();
                dSet = objStorProc.rdf_sp_supplier(p_id, "", "","","", "delete");

                //dSet_temp.Clear();
                //dSet_temp = objStorProc.sp_positions(p_id,0,"","delete");

                return true;
            }
            return false;
        }

        private void dgv1_CurrentCellChanged(object sender, EventArgs e)
        {
            showValue();

            toolStripButtonDelete.Visible = true;

            toolStripButtonDelete.Visible = true;

            ToolStripButtonEdit.Visible = true;
        }


        void showValue()
        {

            if (dgv1.RowCount > 0)
            {
                if (dgv1.CurrentRow != null)
                {
                    if (dgv1.CurrentRow.Cells["supplier_id"].Value != null)
                    {
                        p_id = Convert.ToInt32(dgv1.CurrentRow.Cells["supplier_id"].Value);
                        txtSupplier.Text = dgv1.CurrentRow.Cells["supplier"].Value.ToString();
                        txtContactNo.Text = dgv1.CurrentRow.Cells["contact_no"].Value.ToString();
                        txtAddress.Text = dgv1.CurrentRow.Cells["address"].Value.ToString();
                        txtEmailAddress.Text = dgv1.CurrentRow.Cells["email_address"].Value.ToString();

                    }
                }
            }

        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            mode = "delete";
            if (dgv1.Rows.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to delete this record?", "Offese", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    mode = "delete";

                    if (saveMode())
                    {
                        loadSupplier();
                        // btnCancel_Click(sender, e);
                        mode = "";

                     //  btn_visible(true);
                       //// txt_read_only(true);
                        dgv1_CurrentCellChanged(sender, e);

                        //frmMenu sa = new frmMenu();

                        //sa.ActivitiesLogs(userinfo.emp_name + "Delete offenses");
                    }
                }
            }
        }

        private void ToolStripButtonEdit_Click(object sender, EventArgs e)
        {
            ToolStripButtonNew.Visible = false;
            ToolStripButtonEdit.Visible = false;
            toolStripButtonMYUP.Visible = true;
            txtSupplier.Enabled = true;
            txtContactNo.Enabled = true;
            txtAddress.Enabled = true;
            txtEmailAddress.Enabled = true;
            toolStripButtonCancel2.Visible = true;
            toolStripButtonDelete.Visible = false;
        }

        private void toolStripButtonMYUP_Click(object sender, EventArgs e)
        {
           mode = "edit";
            if (txtSupplier.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter Offense Code", "Offense", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtContactNo.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter Offense Description", "Offense", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (saveMode())
                {
                    loadSupplier();
                    string tmode = mode;
                    
                    if (tmode == "edit")
                    {
                        // dgv1.CurrentCell = dgv1[0, dgv1.Rows.Count - 1];
                        toolStripButtonMYUP.Visible = false;
                        MessageBox.Show("Supplier Update Successfully", "Supplier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        dgv1.CurrentCell = dgv1[0, temp_hid];
                    }

                 //   btnCancel_Click(sender, e);

                }
                else
                    MessageBox.Show("Failedes");
                //frmMenu sa = new frmMenu();

                //sa.ActivitiesLogs(userinfo.emp_name + "update offenses");
            }

        }
    }
}
