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
    public partial class frmDepartment : Form
    {
        myclasses myClass = new myclasses();
        IStoredProcedures g_objStoredProcCollection = null;

        DataSet dSet = new DataSet();
        DataSet dSet_temp = new DataSet();
        Boolean ready = false;

        string mode = "";
        int temp_id = 0;

        public frmDepartment()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDepartment_Load(object sender, EventArgs e)
        {

            DisableButton();

            g_objStoredProcCollection = myClass.g_objStoredProc.GetCollections();

            getFillItem();

           lstDepartments_Click(sender, e);
        }
        public void DisableButton()
        {
            txtDepartment.Enabled = false;
            ToolStripBCancel.Visible = false;
            toolStripButtonDelete.Visible = true;
            toolStripButtonDelete.Visible = false;
            ToolStripButtonUpdate.Visible = false;
            toolStripButtonDelete.Visible = false;
            ToolStripButtonEdit.Visible = false;
            lblName.Visible = false;
            toolStripButtonMYUP.Visible = false;
            toolStripButtonCancel2.Visible = false;
        }

        private void showvalue()
        {
            if (ready == true)
            {
                if (lstDepartments.Items.Count > 0)
                {
                    temp_id = Convert.ToInt32(lstDepartments.SelectedValue.ToString());
                    txtDepartment.Text = lstDepartments.Text;
                }
            }

        }




        private void getFillItem()
        {
            ready = false;
            myClass.fillListBox(lstDepartments, "department", dSet);
            ready = true;
        }

        private void ToolStripButtonNew_Click(object sender, EventArgs e)
        {
            txtDepartment.Text = "";
            txtDepartment.Enabled = true;
            txtDepartment.Focus();
            ToolStripBCancel.Visible = true;
            ToolStripButtonUpdate.Visible = true;
        }

        private void lstDepartments_Click(object sender, EventArgs e)
        {
            showvalue();
           
           // ToolStripBCancel.Visible = true;
            toolStripButtonDelete.Visible = true;

            toolStripButtonDelete.Visible = true;
         //   ToolStripButtonUpdate.Visible = true;
            ToolStripButtonEdit.Visible = true;
        }

        private void ToolStripBCancel_Click(object sender, EventArgs e)
        {
            mode = "";
            toolStripButtonMYUP.Visible = false;
            ToolStripButtonNew.Visible = true;
            txtDepartment.Enabled = false;
            ToolStripBCancel.Visible = false;
            toolStripButtonDelete.Visible = false;
            ToolStripButtonUpdate.Visible = false;
            ToolStripButtonEdit.Visible = false;
        }


        public bool saveMode()
        {
            if (mode == "add")
            {
                dSet.Clear();
                dSet = g_objStoredProcCollection.sp_department(0, txtDepartment.Text, "getbyname");

                if (dSet.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show(lblName.Text + " : [ " + txtDepartment.Text + " ] already exist...", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDepartment.Focus();
                    return false;
                }
                else
                {
                    dSet.Clear();
                    dSet = g_objStoredProcCollection.sp_department(0, txtDepartment.Text, "add");

                    return true;
                }

            }
            else if (mode == "edit")
            {
                dSet.Clear();
                dSet = g_objStoredProcCollection.sp_department(0, txtDepartment.Text, "getbyname");

                dSet_temp.Clear();
                dSet_temp = g_objStoredProcCollection.sp_department(temp_id, txtDepartment.Text, "getbyid");

                if (dSet.Tables[0].Rows.Count > 0)
                {
                    int tmpID = Convert.ToInt32(dSet.Tables[0].Rows[0][0].ToString());
                    if (tmpID == temp_id)
                    {
                        dSet.Clear();
                        dSet = g_objStoredProcCollection.sp_department(temp_id, txtDepartment.Text, "edit");

                        return true;
                    }
                    else
                    {
                        MessageBox.Show(lblName.Text + " : [ " + txtDepartment.Text + " ] already exist...", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtDepartment.Focus();
                        return false;
                    }
                }
                else
                {
                    dSet.Clear();
                    dSet = g_objStoredProcCollection.sp_department(temp_id, txtDepartment.Text, "edit");

                    return true;
                }
            }
            else if (mode == "delete")
            {
                dSet.Clear();


                dSet_temp.Clear();
                dSet_temp = g_objStoredProcCollection.sp_department(temp_id, txtDepartment.Text, "delete");

                return true;
            }

            return false;
        }









        private void ToolStripButtonEdit_Click(object sender, EventArgs e)
        {
            ToolStripButtonNew.Visible = false;
            ToolStripButtonEdit.Visible = false;
            toolStripButtonMYUP.Visible = true;
            txtDepartment.Enabled = true;
            ToolStripBCancel.Visible = true;
            toolStripButtonDelete.Visible = false;
        }

        private void ToolStripButtonUpdate_Click(object sender, EventArgs e)
        {
            mode = "add";
            if (txtDepartment.Text.Trim() == "")
            {
                MessageBox.Show("Please enter " + lblName.Text + ". ", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (saveMode())
                {
                    MessageBox.Show("New Department added Succesfully!", "Department", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // this.Close();
                    getFillItem();
                    txtDepartment.Text = "";
                    txtDepartment.Enabled = false;
                }
            }

        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            mode = "delete";
            if (lstDepartments.Items.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to delete this record?", lblName.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    mode = "delete";
                    if (saveMode())
                    {
                        getFillItem();
                        if (lstDepartments.Items.Count > 0)
                        {
                            int index = lstDepartments.FindString(txtDepartment.Text, 0);
                            if (index == -1) { index = 0; }
                            lstDepartments.SelectedIndex = index;
                        }

                        mode = "";
                      //  visible_button(true);
                      //  enable_text(false);

                        lstDepartments_Click(sender, e);
                        MessageBox.Show("Department Delete Succesfully!", "Department", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void txtDepartment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ToolStripButtonUpdate_Click(sender, e);
        }

        private void toolStripButtonMYUP_Click(object sender, EventArgs e)
        {
            mode = "edit";

            if (txtDepartment.Text.Trim() == "")
            {
                MessageBox.Show("Please enter " + lblName.Text + ". ", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (saveMode())
                {
                    getFillItem();
                    if (lstDepartments.Items.Count > 0)
                    {
                        int index = lstDepartments.FindString(txtDepartment.Text, 0);
                        if (index == -1) { index = 0; }
                        lstDepartments.SelectedIndex = index;
                    }

                    mode = "";
                    // visible_button(true);
                    // enable_text(false);

                    MessageBox.Show("Department Edit Succesfully!", "Department", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lstDepartments_Click(sender, e);
                    ToolStripButtonNew.Visible = true;
                }
            }


        }

        private void toolStripButtonCancel2_Click(object sender, EventArgs e)
        {

        }

        private void lstDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
