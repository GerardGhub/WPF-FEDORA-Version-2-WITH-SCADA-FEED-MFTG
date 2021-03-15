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
    public partial class frmQuantity : Form
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
        int s_id = 0;
        //int pos_id = 0;
        public string position = "";

        Boolean ready = false;

        public frmQuantity()
        {
            InitializeComponent();
        }

        private void frmQuantity_Load(object sender, EventArgs e)
        {
            dgvQuantity_CurrentCellChanged(sender, e);

            loadQuantityCBO();
            cboCategory_SelectedValueChanged(sender, e);

            objStorProc = xClass.g_objStoredProc.GetCollections();


        }

        void loadQuantityCBO()
        {
            ready = false;

            xClass.fillComboBox(cboDescription, "rdf_raw_material_qty", dSet);
      //     displayData(Convert.ToInt32(cboDescription.SelectedValue.ToString()));

            ready = true;
        }

        private void cboDescription_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ready == true)
                displayData(Convert.ToInt32(cboDescription.SelectedValue.ToString()));
        }

        void displayData(int dept_id)
        {
            dset_section = objStorProc.sp_getFilterTables("filter_finalqty", "", dept_id);


            if (dset_section.Tables.Count > 0)
            {
                DataView dv = new DataView(dset_section.Tables[0]);
                dgvQuantity.DataSource = dv;

       
            }

        }

        private void dgvQuantity_CurrentCellChanged(object sender, EventArgs e)
        {
           showRecords();



        }


        void showRecords()
        {
            if (ready == true)
            {
                if (dgvQuantity.CurrentRow != null)
                {
                    if (dgvQuantity.CurrentRow.Cells["quantity_id"].Value != null)
                    {
                        p_id = Convert.ToInt32(dgvQuantity.CurrentRow.Cells["quantity_id"].Value);
                      //  txtFeedCode.Text = dgv1.CurrentRow.Cells["feed_code"].Value.ToString();
                      //  cboDescription.Text = dgvQuantity.CurrentRow.Cells["category_name"].Value.ToString();
                     //   txtItemCode.Text = dgv1.CurrentRow.Cells["item_code"].Value.ToString();
                      //  txtModified_By.Text = dgv1.CurrentRow.Cells["modified_by"].Value.ToString();
                     //   txtLast_Modified.Text = dgv1.CurrentRow.Cells["last_modified"].Value.ToString();
                        //  cboProdType.Text = dgv1.CurrentRow.Cells["type_name"].Value.ToString();
                    }
                }
            }
        }

        private void cboCategory_SelectedValueChanged(object sender, EventArgs e)
        {
            /*
            if (cboCategory.Text.Trim() != "")
            {
                loadDescriptionFinal();
                cboDescription.Text = "";
            }
            */
        }

        void loadDescriptionFinal()
        {
            ready = false;
            //filter_rdf_raw_materials
            xClass.fillComboBoxFilter(cboCategory, "filter_rdf_category_finale", dSet, cboDescription.Text, 0);
            ready = true;
            s_id = showValueDescripto(cboCategory);
        }

        public int showValueDescripto(ComboBox cbo)
        {
            int ids = 0;
            if (ready == true)
            {
                if (cbo.Items.Count > 0)
                {
                    ids = Convert.ToInt32(cbo.SelectedValue.ToString());
                }
            }
            return ids;
        }

    }
}
