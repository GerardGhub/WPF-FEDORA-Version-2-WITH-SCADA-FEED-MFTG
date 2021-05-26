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
    public partial class frmFormsAvailable : Form
    {
        myclasses xClass = new myclasses();
        IStoredProcedures objStorProc = null;

        DataSet dSet = new DataSet();

        string mode = "";
        int p_id = 0;
        int temp_hid = 0;

        Boolean ready = false;


        DataSet dSet_temp = new DataSet();

        public frmFormsAvailable()
        {
            InitializeComponent();
        }

        private void frmFormsAvailable_Load(object sender, EventArgs e)
        {
            objStorProc = xClass.g_objStoredProc.GetCollections();
            displayData();
            dgv1_CurrentCellChanged(sender, e);




        }
        void displayData()      //method for loading available_menus
        {
            ready = false;
            xClass.fillDataGridView(dgv1, "available_menu", dSet);
            ready = true;
        }

        private void dgv1_CurrentCellChanged(object sender, EventArgs e)
        {
            showValue();
        }

        void showValue()
        {
            if (dgv1.Rows.Count > 0)
            {
                if (dgv1.CurrentRow != null)
                {
                    if (dgv1.CurrentRow.Cells["menu_id"].Value != null)
                    {
                        p_id = Convert.ToInt32(dgv1.CurrentRow.Cells["menu_id"].Value);
                        txtfname.Text = dgv1.CurrentRow.Cells["menu_form_name"].Value.ToString();
                        txtmname.Text = dgv1.CurrentRow.Cells["menu_name"].Value.ToString();
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            mode = "add";
            btn_visible(false);
            txt_read_only(false);
            txtmname.Enabled = true;
            txtfname.Enabled = true;
            txtmname.Select();
            txtmname.Focus();
        }
        void btn_visible(Boolean val)
        {
            btnAdd.Visible = val;
            btnEdit.Visible = val;
            btnDelete.Visible = val;
            btnClose.Visible = val;

            btnUpdate.Visible = !val;
            btnCancel.Visible = !val;
        }

        void txt_read_only(Boolean val)
        {
            txtfname.ReadOnly = val;
            txtmname.ReadOnly = val;

            if (val == false)
            {
                if (mode == "add")
                {
                    txtmname.Text = "";
                    txtfname.Text = "";
                    txtmname.Focus();
                }
                else
                {
                    txtmname.Focus();
                }
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            metroSample_Click(sender,e);

        
        }

        public bool saveMode()      //method for saving of data base on mode (add,edit,delete)
        {

            if (mode == "add")
            {
                dSet.Clear();
                dSet = objStorProc.sp_available_menu(0, txtmname.Text, "", "getbyname");

                if (dSet.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show(lblMenu.Text + " : [ " + txtmname.Text + " ] already exist...", lblMenu.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtmname.Focus();
                    return false;
                }
                else
                {
                    dSet.Clear();
                    dSet = objStorProc.sp_available_menu(0, txtmname.Text, txtfname.Text, "add");
                    //maudit_trails.create_audit_trail("add", dSet_temp, dSet, "positions");
                    return true;
                }
            }
            else if (mode == "edit")
            {
                dSet.Clear();
                dSet = objStorProc.sp_available_menu(0, txtmname.Text, "", "getbyname");

                dSet_temp.Clear();
                dSet_temp = objStorProc.sp_available_menu(p_id, txtmname.Text, "", "getbyid");

                if (dSet.Tables[0].Rows.Count > 0)
                {
                    int tmpID = Convert.ToInt32(dSet.Tables[0].Rows[0][0].ToString());
                    if (tmpID == p_id)
                    {
                        dSet.Clear();
                        dSet = objStorProc.sp_available_menu(p_id, txtmname.Text, txtfname.Text, "edit");
                        UpdateNotify();
                        //maudit_trails.create_audit_trail("edit", dSet_temp, dSet, "available_menu");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show(lblMenu.Text + " : [ " + txtmname.Text + " ] already exist...", lblMenu.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtmname.Focus();
                        return false;
                    }
                }
                else
                {
                    dSet.Clear();
                    dSet = objStorProc.sp_available_menu(p_id, txtmname.Text, txtfname.Text, "edit");

                    //maudit_trails.create_audit_trail("edit", dSet_temp, dSet, "available_menu");
                    //return true;
                }
            }
            else if (mode == "delete")
            {
                dSet.Clear();
                dSet = objStorProc.sp_available_menu(p_id, txtmname.Text, "", "delete");

                dSet_temp.Clear();
                dSet_temp = objStorProc.sp_available_menu(p_id, txtmname.Text, "", "delete");

                return true;
            }
            return false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            mode = "";
            txt_read_only(true);
            btn_visible(true);
            dgv1_CurrentCellChanged(sender, e);
            txtmname.Enabled = false;
            txtfname.Enabled = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgv1.RowCount > 0)
            {
                temp_hid = dgv1.CurrentRow.Index;
                txtfname.Enabled = true;
                txtmname.Enabled = true;
                mode = "edit";
                btn_visible(false);
                txt_read_only(false);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgv1.Rows.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to delete this record?", lblMenu.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    mode = "delete";

                    if (saveMode())
                    {
                        displayData();
                        btnCancel_Click("", e);
                    }
                }
            }
        }

        private void metroSample_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure that you want to update the Form Information", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (txtmname.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please enter " + lblMenu.Text + ". ", lblMenu.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (txtfname.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please enter " + lblName.Text + ". ", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (saveMode())
                    {
                        displayData();
                        string tmode = mode;

                        if (tmode == "add")
                        {
                            dgv1.CurrentCell = dgv1[0, dgv1.Rows.Count - 1];
                            UpdateNotify();
                        }
                        else
                        {
                            dgv1.CurrentCell = dgv1[0, temp_hid];
                 
                        }
                        btnCancel_Click(sender, e);
                        UpdateNotify();
                    }
                    else
                        //MessageBox.Show("Failed ss");
                        //btnUpdate_Click(sender, e);
                        bunifuThinButton24_Click(sender, e);
                    return;
                }
            }

            else
            {
                return;
            }


            }





        void UpdateNotify()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "SUCCESSFULLY UPDATE FORM INFORMATION";
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

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            if (txtmname.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter " + lblMenu.Text + ". ", lblMenu.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtfname.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter " + lblName.Text + ". ", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (saveMode())
                {
                    displayData();
                    string tmode = mode;

                    if (tmode == "add")
                    {
                        dgv1.CurrentCell = dgv1[0, dgv1.Rows.Count - 1];
                    }
                    else
                    {
                        dgv1.CurrentCell = dgv1[0, temp_hid];
                    }
                    btnCancel_Click(sender, e);
                }
                else
                    //MessageBox.Show("Failed ss");
                    //btnUpdate_Click(sender, e);
                return;
            }
        }

        private void dgv1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {

            DataGridView dg = (DataGridView)sender;
            // Current row record
            string rowNumber = (e.RowIndex + 1).ToString();

            // Format row based on number of records displayed by using leading zeros
            while (rowNumber.Length < dg.RowCount.ToString().Length) rowNumber = "0" + rowNumber;

            // Position text
            SizeF size = e.Graphics.MeasureString(rowNumber, this.Font);
            if (dg.RowHeadersWidth < (int)(size.Width + 20)) dg.RowHeadersWidth = (int)(size.Width + 20);

            // Use default system text brush
            Brush b = SystemBrushes.ControlText;

            // Draw row number
            e.Graphics.DrawString(rowNumber, dg.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
        }

        private void dgv1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void dgv1_CurrentCellChanged_1(object sender, EventArgs e)
        {
            showValue();
        }

        private void dgv1_RowPostPaint_1(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    }
