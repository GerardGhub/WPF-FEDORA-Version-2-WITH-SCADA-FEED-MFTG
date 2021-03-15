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
    public partial class frmTransactMoveOrderQtyUpdate : Form
    {
        frmShowOrder ths;
        public frmTransactMoveOrderQtyUpdate(frmShowOrder frm, string prodid, string order_no, string encodedby, string actualqty, string input, string inventory, string available, string subtract, string moveorder, string actual, string addition, string totalmoveorder, string key)
        {
            InitializeComponent();
            ths = frm;
            textBox1.TextChanged += new EventHandler(textBox1_TextChanged);
            this.prodid = prodid;
            this.order_no = order_no;
            this.encodedby = encodedby;
            this.actualqty = actualqty;
            this.input = input;
            this.inventory = inventory;
            this.available = available;
            this.subtract = subtract;
            this.moveorder = moveorder;
            this.actual = actual;
            this.addition = addition;
            this.totalmoveorder = totalmoveorder;
            this.key = key;
        }
        public string prodid { get; set; }
        public string order_no { get; set; }
        public string encodedby { get; set; }
        public string actualqty { get; set; }
        public string input { get; set; }
        public string subtract { get; set; }
        public string moveorder { get; set; }
        public string actual { get; set; }
        public string inventory { get; set; }
        public string available { get; set; }
        public string addition { get; set; }
        public string totalmoveorder { get; set; }
        public string key { get; set; }


        private void frmTransactMoveOrderQtyUpdate_Load(object sender, EventArgs e)
        {

            lblprodid.Text = prodid;
            lblorder.Text = order_no;
            lblencodedby.Text = encodedby;
            txtactualqty.Text = actualqty;
            txtinput.Text = input;
            lblfginventory.Text = inventory;
            lblavailable.Text = available;
            lblsubtract.Text = subtract;
            txtmoveorder.Text = moveorder;
            lblactual.Text = actual;
            lbladdition.Text = addition;
            lbltotalmoveorder.Text = totalmoveorder;
            lblid.Text = key;
            txtinput.Text = "";
            txtinput_TextChanged(sender, e);
            txtinput.Focus();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ths.textBox1.Text = textBox1.Text;
        }

        private void txtinput_TextChanged(object sender, EventArgs e)
        {
            if (lblfginventory.Text.Trim() == string.Empty)
            {
            }
            else
            {
                if (txtmoveorder.Text.Trim() == string.Empty)
                {
                    lblavailable.Text = (float.Parse(lblfginventory.Text) - float.Parse(txtactualqty.Text)).ToString();
                    lblsubtract.Text = (float.Parse(txtinput.Text) - float.Parse(lblfginventory.Text)).ToString();
                }
                else
                {
                    lblavailable.Text = (float.Parse(lblfginventory.Text) - float.Parse(txtmoveorder.Text)).ToString();


                    if (txtinput.Text.Trim() == string.Empty)
                    {

                        lblactual.Text = "0";
                        lblsubtract.Text = "0";
                        //lbltotalmoveorder.Text = "0";

                        //show the move order here
                        //txtmoveorder.Text = dgvshowinventory.CurrentRow.Cells["move_order_qty"].Value.ToString();
                    }
                    else
                    {



                        lbladdition.Text = (float.Parse(txtactualqty.Text) + float.Parse(lblavailable.Text)).ToString();
                        lblsubtract.Text = (float.Parse(lbladdition.Text) - float.Parse(txtinput.Text)).ToString();
                        lblactual.Text = (float.Parse(txtinput.Text) - float.Parse(txtactualqty.Text)).ToString();

                        lbltotalmoveorder.Text = (float.Parse(txtmoveorder.Text) + float.Parse(lblactual.Text)).ToString();
                    }


                }

            }
        }
        public void QtyOver()
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);

            popup.ContentText = "out of stock!";

            popup.ContentColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);

            popup.ContentHoverColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentPadding = new Padding(0);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Red;
            popup.Popup();

            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);

            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }


        public void InvalidQuantity()
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);

            popup.ContentText = "Invalid Quantity!";

            popup.ContentColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);

            popup.ContentHoverColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentPadding = new Padding(0);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Red;
            popup.Popup();

            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);

            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }
        public void SaveSuccessFull()
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);

            popup.ContentText = "Transaction Successfully Approved";

            popup.ContentColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);

            popup.ContentHoverColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentPadding = new Padding(0);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Green;
            popup.Popup();

            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);

            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }

        void UpdateData()
        {
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            ////        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "UPDATE [dbo].[transact_rdf_move_order]  SET qty='" + txtinput.Text + "' where move_id='" + lblid.Text + "'";

            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvUpdateSource.DataSource = dt;

            sql_con.Close();


        }


        void UpdateData2()
        {
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            ////        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "UPDATE [dbo].[rdf_production_advance]  SET move_order_qty='" + lbltotalmoveorder.Text + "', last_qty_input='" + txtactualqty.Text + "', actual_available='" + lblsubtract.Text + "' where prod_id='" + lblprodid.Text + "'";

            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvUpdateSource.DataSource = dt;

            sql_con.Close();


        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtinput.Text.Trim() == string.Empty)
            {
                InvalidQuantity();
                txtinput.Text = "";
                txtinput.Focus();
                return;
            }

            if (txtinput.Text == "0")
            {
                InvalidQuantity();
                txtinput.Text = "";
                txtinput.Focus();
                return;
            }

            if (lblsubtract.Text.StartsWith("-"))
            {
                //MessageBox.Show("Error");
                QtyOver();
                txtinput.BackColor = Color.Yellow;
                txtinput.Focus();
                return;
            }

            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Upate the Quantity ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                UpdateData();
                UpdateData2();


                textBox1.Text = "DONE";
                SaveSuccessFull();
                this.Close();

            }
            else
            {

                return;
            }















        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtinput.Text.Trim() == string.Empty)
            {
                InvalidQuantity();
                txtinput.Text = "";
                txtinput.Focus();
                return;
            }

            if (txtinput.Text == "0")
            {
                InvalidQuantity();
                txtinput.Text = "";
                txtinput.Focus();
                return;
            }

            if (lblsubtract.Text.StartsWith("-"))
            {
                //MessageBox.Show("Error");
                QtyOver();
                txtinput.BackColor = Color.Yellow;
                txtinput.Focus();
                return;
            }

            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Upate the Quantity ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                UpdateData();
                UpdateData2();


                textBox1.Text = "DONE";
                SaveSuccessFull();
                this.Close();

            }
            else
            {

                return;
            }






        }
    }
}
