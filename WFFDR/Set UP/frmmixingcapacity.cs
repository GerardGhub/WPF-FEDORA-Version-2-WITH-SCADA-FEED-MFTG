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
    public partial class frmmixingcapacity : Form
    {
        myclasses xClass = new myclasses();
        IStoredProcedures objStorProc = null;
        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();
        int p_id = 0;
        DataSet dSet_temp = new DataSet();
        public frmmixingcapacity()
        {
            InitializeComponent();
        }

        private void frmmixingcapacity_Load(object sender, EventArgs e)
        {

            objStorProc = xClass.g_objStoredProc.GetCollections();

            txtaddedby.Text = userinfo.emp_name.ToUpper();
            myglobal.global_module = "Active";
            ListofActiveFormulationFeedCode();
            BindYellowCorn();
        }


        public void BindYellowCorn()
        {
            String cone = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            SqlConnection con = new SqlConnection(cone);

            con.Open();
            string strCmd = "select * FROM [dbo].[rdf_yellow_corn] where is_active='1'";

            SqlCommand cmd = new SqlCommand(strCmd, con);
            SqlDataAdapter da = new SqlDataAdapter(strCmd, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cboCorn.DataSource = ds.Tables[0];
            cboCorn.DisplayMember = "corn_name";
            cboCorn.ValueMember = "corn_code";

       txtcorntype.Text = cboCorn.ValueMember.ToString();
            cmd.ExecuteNonQuery();
            con.Close();


        }

        public void ListofActiveFormulationFeedCode()
        {
            string mcolumns = "test,rp_feed_type,mixing_capacity,TimeStamp,corn_type_formula,qa_corn_code  ";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgv_table, mcolumns, "activeformulationmgmtmixingcapacity");
            lbl1.Text = dgv_table.RowCount.ToString();
        }

        private void dgv_table_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgv_table.RowCount > 0)
            {
                if (dgv_table.CurrentRow != null)
                {
                    if (dgv_table.CurrentRow.Cells["rp_feed_type"].Value != null)
                    {
                        //p_id = Convert.ToInt32(dgv_table.CurrentRow.Cells["recipe_id"].Value);

                        lblfeedtype.Text = dgv_table.CurrentRow.Cells["rp_feed_type"].Value.ToString();


                        txtcapacity.Text = dgv_table.CurrentRow.Cells["mixing_capacity"].Value.ToString();

                      txtcbocorn.Text = dgv_table.CurrentRow.Cells["qa_corn_code"].Value.ToString();

                 txtcorntype.Text = dgv_table.CurrentRow.Cells["corn_type_formula"].Value.ToString();
                        //new data propmting
                        cboCorn.Text = dgv_table.CurrentRow.Cells["qa_corn_code"].Value.ToString();

                    }

                }
            }

        }

        private void lblfeedtype_Click(object sender, EventArgs e)
        {

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            if(txtcapacity.Text.Trim() == string.Empty)
            {
                RequiredField();
                txtcapacity.Focus();
                return;
            }

            if (txtcorntype.Text.Trim() == string.Empty)
            {
                RequiredField();
                txtcorntype.Focus();
                return;
            }



            if (txtby40.Text.Contains("."))
            {
                //MessageBox.Show("Approved");
                InvalidCapacity();
                return;

            }


            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Update the Mixing Capacity of selected Feed Type?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                txtdatetime.Text = DateTime.Now.ToString();

                String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

                SqlConnection sql_con = new SqlConnection(connetionString);



                string sqlquery = "UPDATE [dbo].[rdf_recipe] SET mixing_capacity='" + txtcapacity.Text + "', mixing_capacity_timestamp ='"+txtdatetime.Text+ "', mixing_capacity_modified_by='"+txtaddedby.Text+ "',corn_type_formula='"+txtcorntype.Text+"',qa_corn_code='"+cboCorn.Text+"'  WHERE rp_feed_type = '" + lblfeedtype.Text + "'  ";



                sql_con.Open();
                SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
                SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
                DataTable dt = new DataTable();
                sdr.Fill(dt);
                dgvInactive.DataSource = dt;

                ListofActiveFormulationFeedCode();
                dgv_table.Enabled = true;
                //cboFeedType_SelectedValueChanged(sender, e);
                //dgvImport.Refresh();
                activeNotify();
                sql_con.Close();
                cboCorn.Visible = false;
                txtcbocorn.Visible = true;
                txtcorntype.Text = "";
                btnedit.Visible = true;
                btnUpdate.Visible = false;
            }
            else
            {

                return;
            }













        }

        void activeNotify()
        {

            Tulpep.NotificationWindow.PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Mixing Capacity Successfully Update !";
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


        void RequiredField()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Fill up the required Fields!";
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









        void InvalidCapacity()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Invalid Mixing Capacity !";
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


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            metroButton2_Click(sender, e);
        }

        private void txtcapacity_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            cboCorn_SelectionChangeCommitted(sender,e);

            btnUpdate.Visible = true;
            txtcapacity.Enabled = true;
            btnedit.Visible = false;
            cboCorn.Enabled = true;
            txtcapacity.Focus();
            txtcbocorn.Visible = false;
            cboCorn.Visible = true;
            cboCorn.Text = dgv_table.CurrentRow.Cells["qa_corn_code"].Value.ToString();

            dgv_table.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnUpdate.Visible = false;
            btnedit.Visible = true;
            cboCorn.Enabled = false;
            txtcapacity.Enabled = false;
            txtcbocorn.Visible = true;
            cboCorn.Visible = false;
            dgv_table.Enabled = true;
        }

        private void txtcapacity_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtcapacity_TextChanged(object sender, EventArgs e)
        {


            try
            {


                txtby40.Text = (float.Parse(txtcapacity.Text) / 40).ToString();

                //lblrunningqty.Text = (float.Parse(txtbags.Text) + float.Parse(lblactualCount.Text)).ToString();
            }
            catch (Exception)
            {


            }




            if (txtby40.Text.Contains("."))
            {
                //MessageBox.Show("Approved");

               txtcapacity.BackColor = Color.Yellow;

            }
            else
            {
                txtcapacity.BackColor = Color.White;
                //MessageBox.Show("DisApproved");
            }





        }

        private void txtby40_TextChanged(object sender, EventArgs e)
        {




        }

        private void dgv_table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtaddedby_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgv_table_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void cboCorn_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboCorn_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtcorntype.Text = cboCorn.SelectedValue.ToString();
        }

        private void txtcbocorn_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
