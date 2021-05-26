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
    public partial class frmQCImportPending : Form
    {

        myclasses xClass = new myclasses();
        IStoredProcedures objStorProc = null;

        int p_id = 0;
        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();

        public frmQCImportPending()
        {
            InitializeComponent();
        }

        private void frmQCImportPending_Load(object sender, EventArgs e)
        {
            objStorProc = xClass.g_objStoredProc.GetCollections();
            load_pending_oracle_upload();
        }

        public void load_pending_oracle_upload()
        {
            string mcolumns = "test,po_sum_id,item_code,item_description,pr_number,pr_date,po_number,po_date";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgv_table, mcolumns, "pending_oracle_upload");
            //  lblrecords.Text = dgv_table.RowCount.ToString();
            // textBox1.Text = dgv_table.RowCount.ToString();
           // micro_materials_header();
        }




    }
}
