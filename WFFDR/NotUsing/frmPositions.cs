using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WFFDR
{
    public partial class frmPositions : Form
    {
        myclasses xClass = new myclasses();

        IStoredProcedures objStorProc = null;

        DataSet dSet = new DataSet();
        DataSet dset_position = new DataSet();

        string mode = "";
        int p_id = 0;
        int temp_hid = 0;

        Boolean ready = false;

        DataSet dSet_temp = new DataSet();



        public frmPositions()
        {
            InitializeComponent();
        }

        private void frmPositions_Load(object sender, EventArgs e)
        {
            objStorProc = xClass.g_objStoredProc.GetCollections();
            loadSection();
            HideButtons();

            dgv1.Height = this.Height - 190;
        }


        public bool saveMode()
        {

            if (mode == "add")
            {
                //dSet.Clear();
                //dSet = objStorProc.sp_positions(0,0, txtname.Text,"getbyname");

                //if (dSet.Tables[0].Rows.Count > 0)
                //{
                //    MessageBox.Show(lblName.Text + " : [ " + txtname.Text + " ] already exist...", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    txtname.Focus();
                //    return false;
                //}
                //else
                //{
                dSet.Clear();
                dSet = objStorProc.sp_positions(0, Convert.ToInt32(cboSection.SelectedValue.ToString()), txtPosition.Text, "add");

                return true;
                //}
            }
            else if (mode == "edit")
            {
                dSet.Clear();
                dSet = objStorProc.sp_positions(0, 0, txtPosition.Text, "getbyname");

                dSet_temp.Clear();
                dSet_temp = objStorProc.sp_positions(p_id, 0, txtPosition.Text, "getbyid");

                if (dSet.Tables[0].Rows.Count > 0)
                {
                    int tmpID = Convert.ToInt32(dSet.Tables[0].Rows[0][0].ToString());
                    if (tmpID == p_id)
                    {
                        dSet.Clear();
                        dSet = objStorProc.sp_positions(p_id, Convert.ToInt32(cboSection.SelectedValue.ToString()), txtPosition.Text, "edit");


                        return true;
                    }
                    else
                    {
                        MessageBox.Show(lblName.Text + " : [ " + txtPosition.Text + " ] already exist...", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPosition.Focus();
                        return false;
                    }
                }
                else
                {
                    dSet.Clear();
                    dSet = objStorProc.sp_positions(p_id, Convert.ToInt32(cboSection.SelectedValue.ToString()), txtPosition.Text, "edit");


                    return true;
                }
            }
            else if (mode == "delete")
            {
                dSet.Clear();
                dSet = objStorProc.sp_positions(p_id, 0, txtPosition.Text, "delete");

                dSet_temp.Clear();
                dSet_temp = objStorProc.sp_positions(p_id, 0, txtPosition.Text, "delete");

                return true;
            }
            return false;
        }

        public void HideButtons()
        {
            txtPosition.Enabled = false;
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


        void loadSection()
        {
            ready = false;

            xClass.fillComboBox(cboSection, "section", dSet);
           displayData(Convert.ToInt32(cboSection.SelectedValue.ToString()));

            ready = true;
        }


        void displayData(int pos_id)
        {
            dset_position = objStorProc.sp_getFilterTables("filter_position_by_section_id", "", pos_id);

            if (dset_position.Tables.Count > 0)
            {
                DataView dv = new DataView(dset_position.Tables[0]);
        
                dgv1.DataSource = dv;
            }
        }
        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ToolStripBCancel_Click(object sender, EventArgs e)
        {
            mode = "";
            toolStripButtonMYUP.Visible = false;
            ToolStripButtonNew.Visible = true;
            txtPosition.Enabled = false;
            ToolStripBCancel.Visible = false;
            toolStripButtonDelete.Visible = false;
            ToolStripButtonUpdate.Visible = false;
            ToolStripButtonEdit.Visible = false;
        }

        private void toolStripButtonCancel2_Click(object sender, EventArgs e)
        {
            mode = "";
            toolStripButtonMYUP.Visible = false;
            ToolStripButtonNew.Visible = true;
            txtPosition.Enabled = false;
            ToolStripBCancel.Visible = false;
            toolStripButtonDelete.Visible = false;
            ToolStripButtonUpdate.Visible = false;
            ToolStripButtonEdit.Visible = false;
        }

        private void ToolStripButtonNew_Click(object sender, EventArgs e)
        {
            txtPosition.Text = "";
            txtPosition.Enabled = true;
            txtPosition.Focus();
            toolStripButtonCancel2.Visible = true;
            ToolStripButtonUpdate.Visible = true;
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
            if (ready == true)
            {
                if (dgv1.RowCount > 0)
                {
                    if (dgv1.CurrentRow != null)
                    {
                        if (dgv1.CurrentRow.Cells["position_id"].Value != null)
                        {
                            p_id = Convert.ToInt32(dgv1.CurrentRow.Cells["position_id"].Value);
                            txtPosition.Text = dgv1.CurrentRow.Cells["position_name"].Value.ToString();
                            cboSection.Text = dgv1.CurrentRow.Cells["section_name"].Value.ToString();
                        }
                    }
                }
            }
        }

        private void cboSection_SelectedValueChanged(object sender, EventArgs e)
        {
            if (ready == true)
                displayData(Convert.ToInt32(cboSection.SelectedValue.ToString()));
        }

        private void ToolStripButtonEdit_Click(object sender, EventArgs e)
        {
            ToolStripButtonNew.Visible = false;
            ToolStripButtonEdit.Visible = false;
            toolStripButtonMYUP.Visible = true;
            txtPosition.Enabled = true;
            ToolStripBCancel.Visible = true;
            toolStripButtonDelete.Visible = false;
        }

        private void toolStripButtonMYUP_Click(object sender, EventArgs e)
        {
            mode = "edit";
            MessageBox.Show("Position Entry Updated SuccesFully " + lblName.Text + ". ", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (cboSection.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter " + lblSection.Text + ". ", lblSection.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtPosition.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter " + lblName.Text + ". ", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (saveMode())
                {

                    if (cboSection.Items.Count > 0)
                    {
                        int index = cboSection.FindString(cboSection.Text, 0);
                        if (index == -1) { index = 0; }
                        cboSection.SelectedIndex = index;
                    }

                    displayData(Convert.ToInt32(cboSection.SelectedValue.ToString()));
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
                    MessageBox.Show("Failed");
            }
        }

        private void ToolStripButtonUpdate_Click(object sender, EventArgs e)
        {
            mode = "add";
            if (cboSection.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter " + lblSection.Text + ". ", lblSection.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtPosition.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter " + lblName.Text + ". ", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (saveMode())
                {

                    if (cboSection.Items.Count > 0)
                    {
                        int index = cboSection.FindString(cboSection.Text, 0);
                        if (index == -1) { index = 0; }
                        cboSection.SelectedIndex = index;
                    }

                    displayData(Convert.ToInt32(cboSection.SelectedValue.ToString()));
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
                    MessageBox.Show("New Position Entry Added SuccesFully " + lblName.Text + ". ", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                    MessageBox.Show("Failed");
            }
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            mode = "delete";
            MessageBox.Show("Position Entry Deleted SuccesFully " + lblName.Text + ". ", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (cboSection.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter " + lblSection.Text + ". ", lblSection.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtPosition.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter " + lblName.Text + ". ", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (saveMode())
                {

                    if (cboSection.Items.Count > 0)
                    {
                        int index = cboSection.FindString(cboSection.Text, 0);
                        if (index == -1) { index = 0; }
                        cboSection.SelectedIndex = index;
                    }

                    displayData(Convert.ToInt32(cboSection.SelectedValue.ToString()));
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
                    MessageBox.Show("Failed");
            }
        }
    
    }
}
