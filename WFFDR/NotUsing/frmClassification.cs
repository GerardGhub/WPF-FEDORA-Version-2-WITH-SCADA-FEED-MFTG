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
    public partial class frmClassification : Form
    {
        myclasses myClass = new myclasses();
        IStoredProcedures g_objStoredProcCollection = null;

        DataSet dSet = new DataSet();
        DataSet dSet_temp = new DataSet();
        Boolean ready = false;

        string mode = "";
        int temp_id = 0;






        public frmClassification()
        {
            InitializeComponent();
        }

        private void frmClassification_Load(object sender, EventArgs e)
        {
            DisableButton();

            g_objStoredProcCollection = myClass.g_objStoredProc.GetCollections();

            getFillItem();

            lstClassification_Click(sender, e);


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
        private void lstClassification_Click(object sender, EventArgs e)
        {

            showvalue();


            toolStripButtonDelete.Visible = true;

            toolStripButtonDelete.Visible = true;

            ToolStripButtonEdit.Visible = true;
        }


        public bool saveMode()
        {
            if (mode == "add")
            {
                dSet.Clear();
                dSet = g_objStoredProcCollection.rdf_sp_classification(0, txtClassification.Text, "getbyname");

                if (dSet.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show(lblName.Text + " : [ " + txtClassification.Text + " ] already exist...", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtClassification.Focus();
                    return false;
                }
                else
                {
                    dSet.Clear();
                    dSet = g_objStoredProcCollection.rdf_sp_classification(0, txtClassification.Text, "add");

                    return true;
                }

            }
            else if (mode == "edit")
            {
                dSet.Clear();
                dSet = g_objStoredProcCollection.rdf_sp_classification(0, txtClassification.Text, "getbyname");

                dSet_temp.Clear();
                dSet_temp = g_objStoredProcCollection.rdf_sp_classification(temp_id, txtClassification.Text, "getbyid");

                if (dSet.Tables[0].Rows.Count > 0)
                {
                    int tmpID = Convert.ToInt32(dSet.Tables[0].Rows[0][0].ToString());
                    if (tmpID == temp_id)
                    {
                        dSet.Clear();
                        dSet = g_objStoredProcCollection.rdf_sp_classification(temp_id, txtClassification.Text, "edit");

                        return true;
                    }
                    else
                    {
                        MessageBox.Show(lblName.Text + " : [ " + txtClassification.Text + " ] already exist...", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtClassification.Focus();
                        return false;
                    }
                }
                else
                {
                    dSet.Clear();
                    dSet = g_objStoredProcCollection.rdf_sp_classification(temp_id, txtClassification.Text, "edit");

                    return true;
                }
            }
            else if (mode == "delete")
            {
                dSet.Clear();


                dSet_temp.Clear();
                dSet_temp = g_objStoredProcCollection.rdf_sp_classification(temp_id, txtClassification.Text, "delete");

                return true;
            }

            return false;
        }
        

        private void showvalue()
        {
            if (ready == true)
            {
                if (lstClassification.Items.Count > 0)
                {
                    temp_id = Convert.ToInt32(lstClassification.SelectedValue.ToString());
                    txtClassification.Text = lstClassification.Text;
                }
            }

        }
        public void DisableButton()
        {
            lblName.Visible = false;
            txtClassification.Enabled = false;
            toolStripButtonCancel2.Visible = false;
            toolStripButtonDelete.Visible = true;
            toolStripButtonDelete.Visible = false;
            ToolStripButtonUpdate.Visible = false;
            toolStripButtonDelete.Visible = false;
            ToolStripButtonEdit.Visible = false;
           // lblNames.Visible = false;
            toolStripButtonMYUP.Visible = false;
            toolStripButtonCancel2.Visible = false;
        }
        private void getFillItem()
        {
            ready = false;
            myClass.fillListBox(lstClassification, "rdf_classification", dSet);
            ready = true;
        }

        private void ToolStripButtonNew_Click(object sender, EventArgs e)
        {
            txtClassification.Text = "";
            txtClassification.Enabled = true;
            txtClassification.Focus();
            toolStripButtonCancel2.Visible = true;
            ToolStripButtonUpdate.Visible = true;
        }

        private void ToolStripBCancel_Click(object sender, EventArgs e)
        {
            mode = "";
            toolStripButtonMYUP.Visible = false;
            ToolStripButtonNew.Visible = true;
            txtClassification.Enabled = false;
            toolStripButtonCancel2.Visible = false;
            toolStripButtonDelete.Visible = false;
            ToolStripButtonUpdate.Visible = false;
            ToolStripButtonEdit.Visible = false;
        }

        private void ToolStripButtonEdit_Click(object sender, EventArgs e)
        {
            ToolStripButtonNew.Visible = false;
            ToolStripButtonEdit.Visible = false;
            toolStripButtonMYUP.Visible = true;
            txtClassification.Enabled = true;
            toolStripButtonCancel2.Visible = true;
            toolStripButtonDelete.Visible = false;
        }
        
        private void ToolStripButtonUpdate_Click(object sender, EventArgs e)
        {
            mode = "add";
            if (txtClassification.Text.Trim() == "")
            {
                MessageBox.Show("Please enter " + lblName.Text + ". ", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (saveMode())
                {
                    MessageBox.Show("New Classification added Succesfully!", "Classification", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // this.Close();
                    getFillItem();
                    txtClassification.Text = "";
                    txtClassification.Enabled = false;
                }
            }
        }

        private void lstClassification_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtClassification_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ToolStripButtonUpdate_Click(sender, e);
        }

        private void toolStripButtonMYUP_Click(object sender, EventArgs e)
        {
            mode = "edit";

            if (txtClassification.Text.Trim() == "")
            {
                MessageBox.Show("Please enter " + lblName.Text + ". ", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (saveMode())
                {
                    getFillItem();
                    if (lstClassification.Items.Count > 0)
                    {
                        int index = lstClassification.FindString(txtClassification.Text, 0);
                        if (index == -1) { index = 0; }
                        lstClassification.SelectedIndex = index;
                    }

                    mode = "";
                    // visible_button(true);
                    // enable_text(false);

                    MessageBox.Show("Classification Edit Succesfully!", "Classification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lstClassification_Click(sender, e);
                    ToolStripButtonNew.Visible = true;
                    txtClassification.Enabled = false;
                }
            }
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            mode = "delete";



            if (txtClassification.Text.Trim() == "")
            {
                MessageBox.Show("Please enter " + lblName.Text + ". ", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (saveMode())
                {
                    getFillItem();
                    if (lstClassification.Items.Count > 0)
                    {
                        int index = lstClassification.FindString(txtClassification.Text, 0);
                        if (index == -1) { index = 0; }
                        lstClassification.SelectedIndex = index;
                    }

                    mode = "";
                    // visible_button(true);
                    // enable_text(false);

                    MessageBox.Show("Classification Deleted Succesfully!", "Classification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lstClassification_Click(sender, e);
                    ToolStripButtonNew.Visible = true;
                }
            }

        }

   
}
}
