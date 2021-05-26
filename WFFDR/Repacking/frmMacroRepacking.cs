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

namespace WFFDR
{
    public partial class frmMacroRepacking : Form
    {
        myclasses myClass = new myclasses();
        IStoredProcedures g_objStoredProcCollection = null;
        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();
        DataSet dSet_temp = new DataSet();
        DataSet dSet = new DataSet();
        int p_id = 0;
        int temp_hid = 0;
        string mode = "";
        Boolean ready = false;
        myclasses xClass = new myclasses();
        IStoredProcedures objStorProc = null;
        public frmMacroRepacking()
        {
            InitializeComponent();
        }

        private void frmMacroRepacking_Load(object sender, EventArgs e)
        {
            txtItemCode.Visible = false;
            objStorProc = xClass.g_objStoredProc.GetCollections();

            myglobal.global_module = "MICRO";
            load_micro();
            mode = "active";
            txtitemcodeinactive_TextChanged(sender, e);
        }

        public void load_micro()
        {
            string mcolumns = "test,item_code,item_description,Category,item_group,qty_repack,qty_repack_available";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgv_table, mcolumns, "macro_raw_materialsnew");
            lblrecords.Text = dgv_table.RowCount.ToString();
            lblrecord.Text = dgv_table.RowCount.ToString();
            // textBox1.Text = dgv_table.RowCount.ToString();
            //micro_materials_header();
        }






        private void txtitemcodeinactive_TextChanged(object sender, EventArgs e)
        {
            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=hr_bak;Integrated Security=SSPI";

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "select repack_id,rp_item_code,rp_supplier,rp_feed_code,rp_batch,total_repack,repack_by from [dbo].[rdf_repackin_entry] WHERE rp_item_code like '%" + txtitemcodeinactive.Text + "%' AND is_prepared IS NOT NULL";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridView1.DataSource = dt;
            lblrepackcount2.Text = dataGridView1.RowCount.ToString();
            sql_con.Close();
        }

        private void dgv_table_CurrentCellChanged(object sender, EventArgs e)
        {
            showValue();
        }

        void showValue()
        {

            if (dgv_table.RowCount > 0)
            {
                if (dgv_table.CurrentRow != null)
                {
                    if (dgv_table.CurrentRow.Cells["item_id"].Value != null)
                    {
                        p_id = Convert.ToInt32(dgv_table.CurrentRow.Cells["item_id"].Value);
                        txtItemCode.Text = dgv_table.CurrentRow.Cells["item_code2"].Value.ToString();
                        txtitemcodeinactive.Text = dgv_table.CurrentRow.Cells["item_code2"].Value.ToString();

                    }
                }
            }

        }

        private void txtItemCode_TextChanged(object sender, EventArgs e)
        {
            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=hr_bak;Integrated Security=SSPI";
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "select repack_id,rp_item_code,rp_supplier,rp_feed_code,rp_batch,total_repack,repack_by from [dbo].[rdf_repackin_entry] WHERE rp_item_code like '%" + txtItemCode.Text + "%' AND is_prepared IS NULL";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgv_table_2nd_sup.DataSource = dt;
            lblrepackcount.Text = dgv_table_2nd_sup.RowCount.ToString();
            sql_con.Close();
        }

        private void bunifuUndo_Click(object sender, EventArgs e)
        {
            if (mode == "active")
            {
                dgv_table_2nd_sup.Visible = false;
                dataGridView1.Visible = true;
                toolStripLabel1.Text = "Inactive Macro Raw Materials Repacking Entry";
                lblrepackcount.Visible = false;
                lblrepackcount2.Visible = true;
                mode = "inactive";
                bunifuUndo.ButtonText = "HIDE REPACK (DESCRIPTION)";
            }
            else
            {
                dataGridView1.Visible = false;
                bunifuUndo.ButtonText = "SHOW REPACK";
                mode = "active";
                toolStripLabel1.Text = "Macro Raw Materials Repacking Entry";
                dgv_table_2nd_sup.Visible = true;
                lblrepackcount.Visible = true;
                lblrepackcount2.Visible = false;
            }
        }

        private void dgv_table_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {
                if (dgv_table.Columns[e.ColumnIndex].Name.ToLower().Contains("qty_repack_available"))
                {
                    if (e.Value.ToString() != "")
                    {
                        double d = double.Parse(e.Value.ToString());
                        e.Value = d.ToString("n0");
                    }
                }
            }
        }
    }
}
