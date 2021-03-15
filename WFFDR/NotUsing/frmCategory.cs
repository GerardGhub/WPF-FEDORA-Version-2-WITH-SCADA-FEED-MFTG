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
    public partial class frmCategory : Form
    {
        myclasses myClass = new myclasses();
        IStoredProcedures g_objStoredProcCollection = null;

        DataSet dSet = new DataSet();
        DataSet dSet_temp = new DataSet();
        Boolean ready = false;

        string mode = "";
        int temp_id = 0;






        public frmCategory()
        {
            InitializeComponent();
        }

        private void frmCategory_Load(object sender, EventArgs e)
        {
            
            DisableButton();

            g_objStoredProcCollection = myClass.g_objStoredProc.GetCollections();

            getFillItem();

            lstCategory_Click(sender, e);
        }
        public void DisableButton()
        {
            lblName.Visible = false;
            txtCategory.Enabled = false;
            ToolStripBCancel.Visible = false;
            toolStripButtonDelete.Visible = true;
            toolStripButtonDelete.Visible = false;
            ToolStripButtonUpdate.Visible = false;
            toolStripButtonDelete.Visible = false;
            ToolStripButtonEdit.Visible = false;

            toolStripButtonMYUP.Visible = false;
            toolStripButtonCancel2.Visible = false;
        }
        private void getFillItem()
        {
            ready = false;
            myClass.fillListBox(lstCategory, "rdf_category", dSet);
            ready = true;
        }

        private void lstCategory_Click(object sender, EventArgs e)
        {
            showvalue();

 
            toolStripButtonDelete.Visible = true;

            toolStripButtonDelete.Visible = true;

            ToolStripButtonEdit.Visible = true;
        }

        private void showvalue()
        {
            if (ready == true)
            {
                if (lstCategory.Items.Count > 0)
                {
                    temp_id = Convert.ToInt32(lstCategory.SelectedValue.ToString());
                    txtCategory.Text = lstCategory.Text;
                }
            }

        }

        private void ToolStripButtonNew_Click(object sender, EventArgs e)
        {
            txtCategory.Text = "";
            txtCategory.Enabled = true;
            txtCategory.Focus();
            ToolStripBCancel.Visible = true;
            ToolStripButtonUpdate.Visible = true;
        }

        private void ToolStripBCancel_Click(object sender, EventArgs e)
        {
            mode = "";
            toolStripButtonMYUP.Visible = false;
            ToolStripButtonNew.Visible = true;
            txtCategory.Enabled = false;
            ToolStripBCancel.Visible = false;
            toolStripButtonDelete.Visible = false;
            ToolStripButtonUpdate.Visible = false;
            ToolStripButtonEdit.Visible = false;
        }

        private void ToolStripButtonUpdate_Click(object sender, EventArgs e)
        {
            mode = "add";
            if (txtCategory.Text.Trim() == "")
            {
                MessageBox.Show("Please enter " + lblName.Text + ". ", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (saveMode())
                {
                    MessageBox.Show("New Category added Succesfully!", "Department", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // this.Close();
                    getFillItem();
                    txtCategory.Text = "";
                    txtCategory.Enabled = false;
                }
            }
        }


        public bool saveMode()
        {
            if (mode == "add")
            {
                dSet.Clear();
                dSet = g_objStoredProcCollection.rdf_sp_category(0, txtCategory.Text, "getbyname");

                if (dSet.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show(lblName.Text + " : [ " + txtCategory.Text + " ] already exist...", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCategory.Focus();
                    return false;
                }
                else
                {
                    dSet.Clear();
                    dSet = g_objStoredProcCollection.rdf_sp_category(0, txtCategory.Text, "add");

                    return true;
                }

            }
            else if (mode == "edit")
            {
                dSet.Clear();
                dSet = g_objStoredProcCollection.rdf_sp_category(0, txtCategory.Text, "getbyname");

                dSet_temp.Clear();
                dSet_temp = g_objStoredProcCollection.rdf_sp_category(temp_id, txtCategory.Text, "getbyid");

                if (dSet.Tables[0].Rows.Count > 0)
                {
                    int tmpID = Convert.ToInt32(dSet.Tables[0].Rows[0][0].ToString());
                    if (tmpID == temp_id)
                    {
                        dSet.Clear();
                        dSet = g_objStoredProcCollection.rdf_sp_category(temp_id, txtCategory.Text, "edit");

                        return true;
                    }
                    else
                    {
                        MessageBox.Show(lblName.Text + " : [ " + txtCategory.Text + " ] already exist...", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCategory.Focus();
                        return false;
                    }
                }
                else
                {
                    dSet.Clear();
                    dSet = g_objStoredProcCollection.rdf_sp_category(temp_id, txtCategory.Text, "edit");

                    return true;
                }
            }
            else if (mode == "delete")
            {
                dSet.Clear();


                dSet_temp.Clear();
                dSet_temp = g_objStoredProcCollection.rdf_sp_category(temp_id, txtCategory.Text, "delete");

                return true;
            }

            return false;
        }

        private void ToolStripButtonEdit_Click(object sender, EventArgs e)
        {
            ToolStripButtonNew.Visible = false;
            ToolStripButtonEdit.Visible = false;
            toolStripButtonMYUP.Visible = true;
            txtCategory.Enabled = true;
            ToolStripBCancel.Visible = true;
            toolStripButtonDelete.Visible = false;
        }

        private void toolStripButtonMYUP_Click(object sender, EventArgs e)
        {
            mode = "edit";

            if (txtCategory.Text.Trim() == "")
            {
                MessageBox.Show("Please enter " + lblName.Text + ". ", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (saveMode())
                {
                    getFillItem();
                    if (lstCategory.Items.Count > 0)
                    {
                        int index = lstCategory.FindString(txtCategory.Text, 0);
                        if (index == -1) { index = 0; }
                        lstCategory.SelectedIndex = index;
                    }

                    mode = "";
                    // visible_button(true);
                    // enable_text(false);

                    MessageBox.Show("Category Edit Succesfully!", "Category", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lstCategory_Click(sender, e);
                    ToolStripButtonNew.Visible = true;
                    txtCategory.Enabled = false;
                }
            }

        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            mode = "delete";



            if (txtCategory.Text.Trim() == "")
            {
                MessageBox.Show("Please enter " + lblName.Text + ". ", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (saveMode())
                {
                    getFillItem();
                    if (lstCategory.Items.Count > 0)
                    {
                        int index = lstCategory.FindString(txtCategory.Text, 0);
                        if (index == -1) { index = 0; }
                        lstCategory.SelectedIndex = index;
                    }

                    mode = "";
                    // visible_button(true);
                    // enable_text(false);

                    MessageBox.Show("Category Deleted Succesfully!", "Category", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lstCategory_Click(sender, e);
                    ToolStripButtonNew.Visible = true;
                }
            }

        }
    
    }
}
