using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace WFFDR
{
    public partial class frmproductionrepackchart : Form
    {
        public frmproductionrepackchart()
        {
            InitializeComponent();

            this.dgvProductionSchedules.DataError += this.DataGridView_DataError;
        }

        private void frmproductionrepackchart_Load(object sender, EventArgs e)
        {

            dgvProdToday2.Columns[3].Width = 70;//
            dgvProductionSchedules.Columns[3].Width = 70;//
            dgvProdToday3.Columns[2].Width = 70;//
            //Callround();
            lbldatenow.Text = DateTime.Now.ToString("M/d/yyyy");
            cmdFedoraModules.Text = "Overall Reports";
            OverAllReports();
            lbltitle.Visible = false;
            lblsumofgood.Visible = false;
        }



        private void dtpFilter_ValueChanged(object sender, EventArgs e)
        {

            if (cmdFedoraModules.Text == "Micro & Macro Repacking")
            {
                MicroandMacroRepacking();
                lblsumofgood.Visible = false;


            }
            else if (cmdFedoraModules.Text == "Production Planner")
            {
                ProductionPlanner();
                lbltitle.Visible = false;
                lblsumofgood.Visible = false;
            }
            else if (cmdFedoraModules.Text == "Micro Basemixed")
            {

                BasemixedModule();
                lbltitle.Visible = false;
                lblsumofgood.Visible = false;
            }
            else if (cmdFedoraModules.Text == "Production")
            {

                Production();
                lbltitle.Visible = false;
                lblsumofgood.Visible = false;
            }
            else if (cmdFedoraModules.Text == "Finished Goods")
            {

               FinishedGoodsMode();
                lbltitle.Visible = false;

            }
            else if(cmdFedoraModules.Text== "Overall Reports")
            {
                OverAllReports();
                lbltitle.Visible = false;
                lblsumofgood.Visible = false;
            }
            else if (cmdFedoraModules.Text == "Production Performance")
            {
                //OverAllReports();
                dtpTo.Visible = true;
                OverAllReportsFromTo();
                lbltitle.Visible = false;
                lblsumofgood.Visible = false;
            }
            else if (cmdFedoraModules.Text == "Work in Progress")
            {
                //OverAllReports();

                OverAllReportsFromToPending();
                lbltitle.Visible = false;
                lblsumofgood.Visible = false;
            }
            else
            {


            }



        }

       public void OverAllReports()
        {
            //PlannerView();
            OverAllView();
            TotalMicroRepacking();
            TotalMacroRepacking();
            CallBMXDone();
            CallProductionDone();
            CallFG();
            //dgvProductionSchedules.Visible = false;


            lblclose3.Visible = false;
            lblopen3.Visible = false;
            chart4.Visible = true;


            //plugin
            lblpers1.Visible = false;
            lblcancelpercentage.Visible = false;
            lblpendingpercentage.Visible = false;
            lblpers2.Visible = false;
            lblapprovepercentage.Visible = false;
            lblpers3.Visible = false;

            //additional pen
            pen5.Visible = false;
            pen6.Visible = false;
            pen7.Visible = false;
            pen8.Visible = false;
            pen9.Visible = false;
            pen10.Visible = false;
            pen11.Visible = false;
            pen12.Visible = false;

            //opener
            lblopen1.Visible = false;
            lblopen2.Visible = false;
            lblclose1.Visible = false;
            lblclose2.Visible = false;

            //proce
            lblprocess.Visible = false;
            lblrejected.Visible = false;


            double micropending;
            double donemicro;
            double basemixed;
            double donemacro;
            double productions;
            double fg;

            micropending = double.Parse(lbltotalprod.Text);
            donemicro = double.Parse(lbldonemicro.Text);
            donemacro = double.Parse(lblnotdonemicro2.Text);
            productions = double.Parse(lbltotalproductions.Text);
            basemixed = double.Parse(lbltotalbasemixed.Text);
            fg = double.Parse(lbltotalfg.Text);

            chart4.Series["Series1"].Points.Clear();


            chart4.Series["Series1"].Points.AddXY("Production Schedule", micropending);

            chart4.Series["Series1"].Points.AddXY("Micro Repacking", donemicro);

            chart4.Series["Series1"].Points.AddXY("Macro Repacking", donemacro);

            chart4.Series["Series1"].Points.AddXY("Micro Basemixed", basemixed);
            chart4.Series["Series1"].Points.AddXY("Production", productions);
            chart4.Series["Series1"].Points.AddXY("Finished Goods", fg);

            //pen 
            pen1.Visible = false;
            pen2.Visible = false;
            pen3.Visible = false;
            pen4.Visible = false;

            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            //add ons query and dev

            label2.Visible = true;
            pbRed.Visible = true;
            pbBlue.Visible = true;
            label3.Visible = true;
            pbOrange.Visible = true;
            label4.Visible = true;


            lbl1.Visible = false;

            lbl2.Visible = false;
            lbl3.Visible = false;
            pbred2.Visible = false;
            label6.Visible = false;
            pbblue2.Visible = false;
            label5.Visible = false;
            ////panel2.Visible = true;
            ////panel
            //panel3.Visible = false;
            //panel4.Visible = false;

            //minimal
            pbBlue.Visible = false;
            label3.Visible = false;
            lbldonemicro.Visible = false;
            pbOrange.Visible = false;
            label4.Visible = false;
            lblcancel.Visible = false;
            pbRed.Visible = false;
            label2.Visible = false;
            lblnotdonemicro2.Visible = false;



            //repacking
            lblmymicrodone.Visible = false;
            label7.Visible = false;
            myblue.Visible = false;


            lblmymicropending.Visible = false;
            label8.Visible = false;
            myred.Visible = false;

            //2nd 
            lblmico.Visible = false;
            lblmica.Visible = false;
            lblmacdone.Visible = false;
            lblmacpending.Visible = false;
        }

        public void OverAllReportsFromTo()
        {
            //PlannerView();
            OverAllViewPerformanceOntime();
            TotalMicroRepackingPerformanceOntime();

            TotalMacroRepackingPerformanceOntime();
            CallBMXDonePerformanceOntime();


            CallProductionDonePerformanceOntime();
            CallFGPerformanceOntime();
   
            //dgvProductionSchedules.Visible = false;


            lblclose3.Visible = false;
            lblopen3.Visible = false;
            chart4.Visible = true;


            //plugin
            lblpers1.Visible = false;
            lblcancelpercentage.Visible = false;
            lblpendingpercentage.Visible = false;
            lblpers2.Visible = false;
            lblapprovepercentage.Visible = false;
            lblpers3.Visible = false;

            //additional pen
            pen5.Visible = false;
            pen6.Visible = false;
            pen7.Visible = false;
            pen8.Visible = false;
            pen9.Visible = false;
            pen10.Visible = false;
            pen11.Visible = false;
            pen12.Visible = false;

            //opener
            lblopen1.Visible = false;
            lblopen2.Visible = false;
            lblclose1.Visible = false;
            lblclose2.Visible = false;

            //proce
            lblprocess.Visible = false;
            lblrejected.Visible = false;


            double micropending;
            double donemicro;
            double basemixed;
            double donemacro;
            double productions;
            double fg;

            micropending = double.Parse(lbltotalprod.Text);
            donemicro = double.Parse(lbldonemicro.Text);
            donemacro = double.Parse(lblnotdonemicro2.Text);
            productions = double.Parse(lbltotalproductions.Text);
            basemixed = double.Parse(lbltotalbasemixed.Text);
            fg = double.Parse(lbltotalfg.Text);

            chart4.Series["Series1"].Points.Clear();


            //chart4.Series["Series1"].Points.AddXY("Ontime", micropending);

            //chart4.Series["Series1"].Points.AddXY("Delayed", donemicro);

            //1
            chart4.Series["Series1"].Points.AddXY("Ontime", donemacro);


            chart4.Series["Series1"].Points.AddXY("Delayed", basemixed);
         
            //chart4.Series["Series1"].Points.AddXY("Production", productions);
            //chart4.Series["Series1"].Points.AddXY("Finished Goods", fg);


            //end
            //pen 
            pen1.Visible = false;
            pen2.Visible = false;
            pen3.Visible = false;
            pen4.Visible = false;

            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            //add ons query and dev

            label2.Visible = true;
            pbRed.Visible = true;
            pbBlue.Visible = true;
            label3.Visible = true;
            pbOrange.Visible = true;
            label4.Visible = true;


            lbl1.Visible = false;

            lbl2.Visible = false;
            lbl3.Visible = false;
            pbred2.Visible = false;
            label6.Visible = false;
            pbblue2.Visible = false;
            label5.Visible = false;
            ////panel2.Visible = true;
            ////panel
            //panel3.Visible = false;
            //panel4.Visible = false;

            //minimal
            pbBlue.Visible = false;
            label3.Visible = false;
            lbldonemicro.Visible = false;
            pbOrange.Visible = false;
            label4.Visible = false;
            lblcancel.Visible = false;
            pbRed.Visible = false;
            label2.Visible = false;
            lblnotdonemicro2.Visible = false;



            //repacking
            lblmymicrodone.Visible = false;
            label7.Visible = false;
            myblue.Visible = false;


            lblmymicropending.Visible = false;
            label8.Visible = false;
            myred.Visible = false;

            //2nd 
            lblmico.Visible = false;
            lblmica.Visible = false;
            lblmacdone.Visible = false;
            lblmacpending.Visible = false;


            //CallFormatting();

            Refresher2();
        }
        void Refresher2()
        {

            //reove muna 9/10/2020
            for (int n = 1; n < (dgvPP.Rows.Count); n++)
            {
                //double s = Convert.ToDouble(dgvImport.Rows[n].Cells[4].Value);


                //double s1 = Convert.ToDouble(dgvAllFeedCode.Rows[n].Cells[7].Value);
                //double tak = 2;
                DateTime s1 = Convert.ToDateTime(dgvPP.Rows[n].Cells[15].Value);
                DateTime s2 = Convert.ToDateTime(dgvPP.Rows[n].Cells[25].Value);
                DateTime b = DateTime.Parse(lbldatenow.Text);
                //double s7 = Convert.ToDouble(dataGridView1.Rows[n].Cells[3].Value);
                //int s1 = Convert.ToInt32(dgv1stView.Rows[n].Cells[1].Value);
                //double s13 = s * 2;
                //double s15 = s1 * 2;
                //double s18 = s7 * s15;
                //double sample = 4 + 4;
                //takla
                //dataGridView1.Rows[n].Cells[1].Value = s15.ToString();
                TimeSpan t = s1 - b;
                double NrOfDays = t.TotalDays;
                //28
                if (s1 == s2)
                {
                    dgvPP.Rows[n].Cells[28].Value = "ONTIME";
                    dgvPP.Rows[n].Cells[28].Style.BackColor = Color.CornflowerBlue;
                }
                else
                {
                    dgvPP.Rows[n].Cells[28].Value = "DELAY";
                    dgvPP.Rows[n].Cells[28].Style.BackColor = Color.Red;
                }
                //dgvProductionSchedules.Rows[n].Cells[25].Value = Convert.ToString(NrOfDays + " days");
                label11.Text = Convert.ToString(NrOfDays + "day");
            }
        }




        void CallFormatting()
        {


            if (cmdFedoraModules.Text == "Production Performance")
            {


                foreach (DataGridViewRow row in dgvProductionSchedules.Rows)
                {
                    if (row.Cells["PROD_PLAN"].Value == row.Cells["prodactual"].Value)
                    {
                        //row.Cells["buffer_of_stocks"].Style.BackColor = Color.LightGreen;
                        row.Cells["PROD_PLAN"].Style.BackColor = Color.LightSalmon;
                        row.Cells["prodactual"].Style.BackColor = Color.LightSalmon;
                    }
                    else
                    {
                        row.Cells["PROD_PLAN"].Style.BackColor = Color.LightSalmon;
                        row.Cells["prodactual"].Style.BackColor = Color.LightSalmon;
                    }
                    //else if (Convert.ToInt32(row.Cells["PROD_PLAN"].Value) < Convert.ToDouble(row.Cells["fg_finish_production"].Value))
                    //{
                    //    // row.DefaultCellStyle.BackColor = Color.LightSalmon; // Use it in order to colorize all cells of the row

                    //    //row.Cells["buffer_of_stocks"].Style.BackColor = Color.LightSalmon;
                    //}
                }

            }


        }

        public void OverAllReportsFromToPending()
        {
            //PlannerView();

            OverAllViewPerformancePending();
            TotalMicroRepackingPerformancePending();


            TotalMacroRepackingPerformancePending();
            CallBMXDonePerformancePending();
            
            
            
            CallProductionDonePerformancePending();
            CallFGPerformancePending();

            //dgvProductionSchedules.Visible = false;


            lblclose3.Visible = false;
            lblopen3.Visible = false;
            chart4.Visible = true;


            //plugin
            lblpers1.Visible = false;
            lblcancelpercentage.Visible = false;
            lblpendingpercentage.Visible = false;
            lblpers2.Visible = false;
            lblapprovepercentage.Visible = false;
            lblpers3.Visible = false;

            //additional pen
            pen5.Visible = false;
            pen6.Visible = false;
            pen7.Visible = false;
            pen8.Visible = false;
            pen9.Visible = false;
            pen10.Visible = false;
            pen11.Visible = false;
            pen12.Visible = false;

            //opener
            lblopen1.Visible = false;
            lblopen2.Visible = false;
            lblclose1.Visible = false;
            lblclose2.Visible = false;

            //proce
            lblprocess.Visible = false;
            lblrejected.Visible = false;


            double micropending;
            double donemicro;
            double basemixed;
            double donemacro;
            double productions;
            double fg;

            micropending = double.Parse(lbltotalprod.Text);
            donemicro = double.Parse(lbldonemicro.Text);
            donemacro = double.Parse(lblnotdonemicro2.Text);
            productions = double.Parse(lbltotalproductions.Text);
            basemixed = double.Parse(lbltotalbasemixed.Text);
            fg = double.Parse(lbltotalfg.Text);

            chart4.Series["Series1"].Points.Clear();




            chart4.Series["Series1"].Points.AddXY("DONE", donemicro);

            chart4.Series["Series1"].Points.AddXY("PENDING", micropending);
            //chart4.Series["Series1"].Points.AddXY("Macro Repacking", donemacro);

            //chart4.Series["Series1"].Points.AddXY("Micro Basemixed", basemixed);
            //chart4.Series["Series1"].Points.AddXY("Production", productions);
            //chart4.Series["Series1"].Points.AddXY("Finished Goods", fg);

            //pen 
            pen1.Visible = false;
            pen2.Visible = false;
            pen3.Visible = false;
            pen4.Visible = false;

            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            //add ons query and dev

            label2.Visible = true;
            pbRed.Visible = true;
            pbBlue.Visible = true;
            label3.Visible = true;
            pbOrange.Visible = true;
            label4.Visible = true;


            lbl1.Visible = false;

            lbl2.Visible = false;
            lbl3.Visible = false;
            pbred2.Visible = false;
            label6.Visible = false;
            pbblue2.Visible = false;
            label5.Visible = false;
            ////panel2.Visible = true;
            ////panel
            //panel3.Visible = false;
            //panel4.Visible = false;

            //minimal
            pbBlue.Visible = false;
            label3.Visible = false;
            lbldonemicro.Visible = false;
            pbOrange.Visible = false;
            label4.Visible = false;
            lblcancel.Visible = false;
            pbRed.Visible = false;
            label2.Visible = false;
            lblnotdonemicro2.Visible = false;



            //repacking
            lblmymicrodone.Visible = false;
            label7.Visible = false;
            myblue.Visible = false;


            lblmymicropending.Visible = false;
            label8.Visible = false;
            myred.Visible = false;

            //2nd 
            lblmico.Visible = false;
            lblmica.Visible = false;
            lblmacdone.Visible = false;
            lblmacpending.Visible = false;


            //LEAVE 2m 


            Refresher();





        }



        void Refresher()
        {

            //reove muna 9/10/2020
            for (int n = 0; n < (dgvWIP.Rows.Count); n++)
            {
                //double s = Convert.ToDouble(dgvImport.Rows[n].Cells[4].Value);


                //double s1 = Convert.ToDouble(dgvAllFeedCode.Rows[n].Cells[7].Value);
                //double tak = 2;
                DateTime s1 = Convert.ToDateTime(dgvWIP.Rows[n].Cells[15].Value);
                DateTime b = DateTime.Parse(lbldatenow.Text);
                //double s7 = Convert.ToDouble(dataGridView1.Rows[n].Cells[3].Value);
                //int s1 = Convert.ToInt32(dgv1stView.Rows[n].Cells[1].Value);
                //double s13 = s * 2;
                //double s15 = s1 * 2;
                //double s18 = s7 * s15;
                //double sample = 4 + 4;
                //takla
                //dataGridView1.Rows[n].Cells[1].Value = s15.ToString();
                TimeSpan t = s1 - b;
                double NrOfDays = t.TotalDays;
                //dgvProductionSchedules.Rows[n].Cells[25].Value = sample.ToString();
                dgvWIP.Rows[n].Cells[25].Value = Convert.ToString(NrOfDays + " days");
                label11.Text = Convert.ToString(NrOfDays + "day");
            }
        }

        public void FinishedGoodsMode()
        {

            chart2.Visible = false;
            chart3.Visible = false;
            chart4.Visible = false;
            //lblprocess.Visible = true;
            //lblrejected.Visible = true;
            lblmacro.Visible = false;
            lblmicro.Text = "Finished Goods Pie Chart";

            
            //pen 
            pen1.Visible = false;
            pen2.Visible = false;
            pen3.Visible = false;
            pen4.Visible = false;

            lblclose3.Visible = false;
            lblopen3.Visible = false;
            //opener
            lblopen1.Visible = true;
            lblopen2.Visible = true;
            lblclose1.Visible = true;
            lblclose2.Visible = true;

            //additional pen
            pen5.Visible = false;
            pen6.Visible = false;
            pen7.Visible = false;
            pen8.Visible = false;
            pen9.Visible = false;
            pen10.Visible = false;
            pen11.Visible = false;
            pen12.Visible = false;

            //for the textboxes
            lblmicro.Visible = true;

            //the textbox will appear here masarap
            lbldonemicro.Visible = true;
            lblnotdonemicro2.Visible = true;
            chart1.Visible = true;
            lblcancel.Visible = false;

            lbldonemacro.Visible = false;
            lblnotdonemacro2.Visible = false;

            //Call the query here will be excecuted !

            ////proce
            //lblprocess.Visible = true;
            //lblrejected.Visible = true;

            DoneFinishedGoods();
            PendingFinishedGoods();
            FinishedGoodsViewingQuery();

            //panel
            panel3.Visible = false;
            panel4.Visible = false;

            //repacking
            lblmymicrodone.Visible = false;
            label7.Visible = false;
            myblue.Visible = false;
            panel2.Visible = true;


            lblmymicropending.Visible = false;
            label8.Visible = false;
            myred.Visible = false;

            //rename == 
            label2.Text = "Pending";
            //label3.Text = "FG";
            //lbl1.Visible = true;

            //lbl2.Visible = true;
            //lbl3.Visible = true;

            ////plugin
            //lblpers1.Visible = false;
            //lblcancelpercentage.Visible = false;
            //lblpendingpercentage.Visible = true;
            //lblpers2.Visible = true;
            //lblapprovepercentage.Visible = true;
            //lblpers3.Visible = true;


            //I will put the code here for your documentaation

            double micropending;
            double donemicro;

            micropending = double.Parse(lblnotdonemicro2.Text);
            donemicro = double.Parse(lbldonemicro.Text);

            chart1.Series["s1"].Points.Clear();


            chart1.Series["s1"].Points.AddXY("Pending", micropending);

            chart1.Series["s1"].Points.AddXY("Finished Goods", donemicro);




            //computation percentage
            lblpendingpercentage.Text = (float.Parse(lblnotdonemicro2.Text) / float.Parse(lblmytotal.Text)).ToString();

            lblpendingpercentage.Text = (float.Parse(lblpendingpercentage.Text) * 100).ToString("#,0.0");


            lblapprovepercentage.Text = (float.Parse(lbldonemicro.Text) / float.Parse(lblmytotal.Text)).ToString();

            lblapprovepercentage.Text = (float.Parse(lblapprovepercentage.Text) * 100).ToString("#,0.0");

            label3.Text = "FG";










            /// addd ons will be place here madafaka
            /// 
            label2.Visible = true;
            pbRed.Visible = true;
            pbBlue.Visible = true;
            label3.Visible = true;
            pbOrange.Visible = false;
            label4.Visible = false;



            pbred2.Visible = false;
            label6.Visible = false;
            pbblue2.Visible = false;
            label5.Visible = false;


            /// sum of goodf
            /// 

            //decimal Total = 0;

            //for (int i = 0; i < dgvProductionSchedules.Rows.Count; i++)
            //{
            //    Total += Convert.ToDecimal(dgvProductionSchedules.Rows[i].Cells["total_good_count"].Value);
            //}

            //lblsumofgood.Text = Total.ToString();



            decimal tot = 0;

            for (int i = 0; i < dgvProductionSchedules.RowCount - 0; i++)
            {
                var value = dgvProductionSchedules.Rows[i].Cells["GOOD"].Value;
                if (value != DBNull.Value)
                {
                    tot += Convert.ToDecimal(value);
                }
            }
            if (tot == 0)
            {

            }
            //dgvImport.Rows[dgvImport.Rows.Count - 1].Cells["quantity2"].Value = tot.ToString();


            lblsumofgood.Text = tot.ToString();









            decimal tot1 = 0;

            for (int i1 = 0; i1 < dgvProductionSchedules.RowCount - 0; i1++)
            {
                var value1 = dgvProductionSchedules.Rows[i1].Cells["REPROCESS"].Value;
                if (value1 != DBNull.Value)
                {
                    tot1 += Convert.ToDecimal(value1);
                }
            }
            if (tot1 == 0)
            {

            }
            //dgvImport.Rows[dgvImport.Rows.Count - 1].Cells["quantity2"].Value = tot.ToString();


            lblprocess.Text = tot1.ToString();



            decimal tot2 = 0;

            for (int i2 = 0; i2 < dgvProductionSchedules.RowCount - 0; i2++)
            {
                var value2 = dgvProductionSchedules.Rows[i2].Cells["REJECT"].Value;
                if (value2 != DBNull.Value)
                {
                    tot2 += Convert.ToDecimal(value2);
                }
            }
            if (tot2 == 0)
            {

            }
            //dgvImport.Rows[dgvImport.Rows.Count - 1].Cells["quantity2"].Value = tot.ToString();


            lblrejected.Text = tot2.ToString();



            //lblreprocess.Visible = true;


            //2nd 
            lblmico.Visible = false;
            lblmica.Visible = false;
            lblmacdone.Visible = false;
            lblmacpending.Visible = false;

        }

        void Production()
        {
            chart2.Visible = false;
            chart3.Visible = false;
            chart4.Visible = false;

            lblmacro.Visible = false;
            lblmicro.Text = "Production Pie Chart";
            lblclose3.Visible = false;
            lblopen3.Visible = false;
            //for the textboxes
            lblmicro.Visible = true;

            //2nd 
            lblmico.Visible = false;
            lblmica.Visible = false;
            lblmacdone.Visible = false;
            lblmacpending.Visible = false;

            //the textbox will appear here masarap
            lbldonemicro.Visible = true;
            lblnotdonemicro2.Visible = true;
            chart1.Visible = true;
            lblcancel.Visible = false;

            lbldonemacro.Visible = false;
            lblnotdonemacro2.Visible = false;

            //additional pen
            pen5.Visible = false;
            pen6.Visible = false;
            pen7.Visible = false;
            pen8.Visible = false;
            pen9.Visible = false;
            pen10.Visible = false;
            pen11.Visible = false;
            pen12.Visible = false;

            //pen 
            pen1.Visible = false;
            pen2.Visible = false;
            pen3.Visible = false;
            pen4.Visible = false;

            //opener
            lblopen1.Visible = true;
            lblopen2.Visible = true;
            lblclose1.Visible = true;
            lblclose2.Visible = true;

            //Call the query here will be excecuted !
            DoneinProduction();
            PendinginProduction();
            ProductionViewBackend();

            lbl1.Visible = false;

            lbl2.Visible = false;
            lbl3.Visible = false;
            //proce
            lblprocess.Visible = false;
            lblrejected.Visible = false;
            //repacking
            lblmymicrodone.Visible = false;
            label7.Visible = false;
            myblue.Visible = false;
            panel2.Visible = true;


            lblmymicropending.Visible = false;
            label8.Visible = false;
            myred.Visible = false;

            //plugin
            lblpers1.Visible = false;
            lblcancelpercentage.Visible = false;
            lblpendingpercentage.Visible = true;
            lblpers2.Visible = true;
            lblapprovepercentage.Visible = true;
            lblpers3.Visible = true;

            //panel
            panel3.Visible = false;
            panel4.Visible = false;
            //rename == 
            label2.Text = "Pending";
            label3.Text = "Production";


            //I will put the code here for your documentaation

            double micropending;
            double donemicro;

            micropending = double.Parse(lblnotdonemicro2.Text);
            donemicro = double.Parse(lbldonemicro.Text);

            chart1.Series["s1"].Points.Clear();


            chart1.Series["s1"].Points.AddXY("Pending", micropending);

            chart1.Series["s1"].Points.AddXY("Production", donemicro);




            //computation percentage
            lblpendingpercentage.Text = (float.Parse(lblnotdonemicro2.Text) / float.Parse(lblmytotal.Text)).ToString();

            lblpendingpercentage.Text = (float.Parse(lblpendingpercentage.Text) * 100).ToString("#,0.0");


            lblapprovepercentage.Text = (float.Parse(lbldonemicro.Text) / float.Parse(lblmytotal.Text)).ToString();

            lblapprovepercentage.Text = (float.Parse(lblapprovepercentage.Text) * 100).ToString("#,0.0");












            //aaddd ons will be place here madafaka

            label2.Visible = true;
            pbRed.Visible = true;
            pbBlue.Visible = true;
            label3.Visible = true;
            pbOrange.Visible = false;
            label4.Visible = false;

            pbred2.Visible = false;
            label6.Visible = false;
            pbblue2.Visible = false;
            label5.Visible = false;

        }

        public void BasemixedModule()
        {
            chart2.Visible = false;
            chart3.Visible = false;
            chart4.Visible = false;

            lblmacro.Visible = false;
            lblmicro.Text = "Micro Basemixed Pie Chart";
            //pen 
            pen1.Visible = false;
            pen2.Visible = false;
            pen3.Visible = false;
            pen4.Visible = false;


            //additional pen
            pen5.Visible = false;
            pen6.Visible = false;
            pen7.Visible = false;
            pen8.Visible = false;
            pen9.Visible = false;
            pen10.Visible = false;
            pen11.Visible = false;
            pen12.Visible = false;

            lblclose3.Visible = false;
            lblopen3.Visible = false;
            //proce
            lblprocess.Visible = false;
            lblrejected.Visible = false;
            //for the textboxes
            lblmicro.Visible = true;

            //the textbox will appear here masarap
            lbldonemicro.Visible = true;
            lblnotdonemicro2.Visible = true;
            chart1.Visible = true;
            lblcancel.Visible = false;

            lbldonemacro.Visible = false;
            lblnotdonemacro2.Visible = false;

            //opener
            lblopen1.Visible = true;
            lblopen2.Visible = true;
            lblclose1.Visible = true;
            lblclose2.Visible = true;

            //Call the query here will be excecuted !
            //10/28/2020
     
            DoneinMicroBasemixed();

            PendingBasemixed();
            BasemixedViewinProd();



            //repacking
            lblmymicrodone.Visible = false;
            label7.Visible = false;
            myblue.Visible = false;
            panel2.Visible = true;
            lbl1.Visible = false;

            lbl2.Visible = false;
            lbl3.Visible = false;

            lblmymicropending.Visible = false;
            label8.Visible = false;
            myred.Visible = false;

            lblclose3.Visible = false;
            lblopen3.Visible = false;
            //rename == 
            label2.Text = "Pending";
            label3.Text = "Basemixed";

            //panel
            panel3.Visible = false;
            panel4.Visible = false;

            //plugin
            lblpers1.Visible = false;
            lblcancelpercentage.Visible = false;
            lblpendingpercentage.Visible = true;
            lblpers2.Visible = true;
            lblapprovepercentage.Visible = true;
            lblpers3.Visible = true;

            //I will put the code here for your documentaation

            double micropending;
            double donemicro;

            micropending = double.Parse(lblnotdonemicro2.Text);
            donemicro = double.Parse(lbldonemicro.Text);

            chart1.Series["s1"].Points.Clear();


            chart1.Series["s1"].Points.AddXY("Pending", micropending);

            chart1.Series["s1"].Points.AddXY("Micro Basemixed", donemicro);






            //computation percentage
            lblpendingpercentage.Text = (float.Parse(lblnotdonemicro2.Text) / float.Parse(lblmytotal.Text)).ToString();

            lblpendingpercentage.Text = (float.Parse(lblpendingpercentage.Text) * 100).ToString("#,0.0");


            lblapprovepercentage.Text = (float.Parse(lbldonemicro.Text) / float.Parse(lblmytotal.Text)).ToString();

            lblapprovepercentage.Text = (float.Parse(lblapprovepercentage.Text) * 100).ToString("#,0.0");











            //add ons will be place here

            label2.Visible = true;
            pbRed.Visible = true;
            pbBlue.Visible = true;
            label3.Visible = true;
            pbOrange.Visible = false;
            label4.Visible = false;



            pbred2.Visible = false;
            label6.Visible = false;
            pbblue2.Visible = false;
            label5.Visible = false;

            //2nd 
            lblmico.Visible = false;
            lblmica.Visible = false;
            lblmacdone.Visible = false;
            lblmacpending.Visible = false;
        }

        void DataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }


        public void ProductionPlanner()
        {
            chart2.Visible = false;
            chart3.Visible = false;
            chart4.Visible = false;
            lblmacro.Visible = false;
            lblmicro.Text = "Production Planner Pie Chart";

            ApporoveProddate();

            ApporovePending();
            PlannerView();

            ProductionCancelled();
            mYtotalQuery();
            chart1.Visible = true;

            //the textbox will appear here masarap
            lbldonemicro.Visible = true;
            lblnotdonemicro2.Visible = true;
            lblcancel.Visible = true;
            panel2.Visible = true;

            //pen 
            pen1.Visible = false;
            pen2.Visible = false;
            pen3.Visible = false;
            pen4.Visible = false;

            //additional pen
            pen5.Visible = false;
            pen6.Visible = false;
            pen7.Visible = false;
            pen8.Visible = false;
            pen9.Visible = false;
            pen10.Visible = false;
            pen11.Visible = false;
            pen12.Visible = false;


            //repacking
            lblmymicrodone.Visible = false;
            label7.Visible = false;
            myblue.Visible = false;

            //proce
            lblprocess.Visible = false;
            lblrejected.Visible = false;
            lbl1.Visible = false;

            lbl2.Visible = false;
            lbl3.Visible = false;

            lblclose3.Visible = true;
            lblopen3.Visible = true;
            //panel
            panel3.Visible = false;
            panel4.Visible = false;

            lblmymicropending.Visible = false;
            label8.Visible = false;
            myred.Visible = false;


            //opener
            lblopen1.Visible = true;
            lblopen2.Visible = true;
            lblclose1.Visible = true;
            lblclose2.Visible = true;

            //plugin
            lblpers1.Visible = true;
            lblcancelpercentage.Visible = true;
            lblpendingpercentage.Visible = true;
            lblpers2.Visible = true;
            lblapprovepercentage.Visible = true;
            lblpers3.Visible = true;

            //computation percentage
            lblpendingpercentage.Text = (float.Parse(lblnotdonemicro2.Text) / float.Parse(lblmytotal.Text)).ToString();

            lblpendingpercentage.Text = (float.Parse(lblpendingpercentage.Text) * 100).ToString("#,0.0");


            lblapprovepercentage.Text = (float.Parse(lbldonemicro.Text) / float.Parse(lblmytotal.Text)).ToString();

            lblapprovepercentage.Text = (float.Parse(lblapprovepercentage.Text) * 100).ToString("#,0.0");

    lblcancelpercentage.Text = (float.Parse(lblcancel.Text) / float.Parse(lblmytotal.Text)).ToString();

  lblcancelpercentage.Text = (float.Parse(lblcancelpercentage.Text) * 100).ToString("#,0.0");



            //double totalprod;
            //double answer;
            //totalprod = double.Parse(lbltotalprod.Text);
            //answer = totalprod * 100;

            //lblpendingpercentage.Text = Math.Round(answer, 1).ToString();






            //rename == 
            label2.Text = "Pending";
            label3.Text = "Approved";

            lbldonemacro.Visible = false;
            lblnotdonemacro2.Visible = false;
            //I will put the code here for your documentaation

            double micropending;
            double donemicro;
            double cancelproduction;
            micropending = double.Parse(lblnotdonemicro2.Text);
            donemicro = double.Parse(lbldonemicro.Text);
            cancelproduction = double.Parse(lblcancel.Text);
            chart1.Series["s1"].Points.Clear();


            chart1.Series["s1"].Points.AddXY("Pending", micropending);

            chart1.Series["s1"].Points.AddXY("Approved", donemicro);

            //10/27/2020
            //chart1.Series["s1"].Points.AddXY("Cancelled",cancelproduction);



            //double macropending;
            //double macrodone;
            //macropending = double.Parse(lblnotdonemacro2.Text);
            //macrodone = double.Parse(lbldonemacro.Text);

            //add ons query and dev

            label2.Visible = true;
            pbRed.Visible = true;
            pbBlue.Visible = true;
            label3.Visible = true;
            pbOrange.Visible = true;
            label4.Visible = true;

            pbred2.Visible = false;
            label6.Visible = false;
            pbblue2.Visible = false;
            label5.Visible = false;


            //2nd 
            lblmico.Visible = false;
            lblmica.Visible = false;
            lblmacdone.Visible = false;
            lblmacpending.Visible = false;

        }

        public void ApporoveProddate()
        {

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "Select emp.prod_id as ID, emp.p_feed_code as Emp_Number, emp.p_bags as Department,emp.p_nobatch as TotalPack,emp.proddate as Production_Date,emp.start_micro_repacking as MicroStart,emp.end_micro_repacking as MicroEnd,emp.start_macro_repacking as MacroStart,emp.end_macro_repacking as MacroEnd, emp.repacking_status as repack_status,emp.micro_repacking_time from rdf_production_advance emp WHERE emp.is_selected=1 AND emp.is_active=1 AND emp.canceltheapprove IS NULL AND CAST(emp.proddate as date) BETWEEN '" + dtpFilter.Text + "' AND '"+dtpTo.Text+"' ";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvProdToday.DataSource = dt;
            lbldonemicro.Text = dgvProdToday.RowCount.ToString();



            sql_con.Close();



        }

        void TotalMicroRepacking()
        {

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            //gerald             string sqlquery = "Select emp.prod_id as ID, emp.p_feed_code as Emp_Number, emp.p_bags as Department,emp.p_nobatch as TotalPack,emp.proddate as Production_Date, emp.repacking_status as repack_status from rdf_production_advance emp WHERE emp.proddate ='" + txtdateplusone.Text + "' OR emp.proddate ='"+dtpreceivingdate.Text+"' OR emp.proddate ='"+ txtdateminus1.Text+"' AND emp.is_selected=1 AND emp.repacking_status='ready' AND NOT emp.canceltheapprove IS NOT NULL";
    
                string sqlquery = "Select emp.prod_id as ID, emp.p_feed_code as Emp_Number, emp.p_bags as Department,emp.p_nobatch as TotalPack,emp.proddate as Production_Date,emp.start_micro_repacking as MicroStart,emp.end_micro_repacking as MicroEnd,emp.start_macro_repacking as MacroStart,emp.end_macro_repacking as MacroEnd, emp.repacking_status as repack_status,emp.micro_repacking_time from rdf_production_advance emp WHERE emp.is_selected=1 AND emp.is_active=1 AND emp.canceltheapprove IS NULL AND CAST(emp.proddate as date) BETWEEN '" + dtpFilter.Text + "' AND '"+dtpTo.Text+"' AND emp.end_micro_repacking IS NOT NULL ";
                sql_con.Open();
                SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
                SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
                DataTable dt = new DataTable();
                sdr.Fill(dt);
                dgvProdToday.DataSource = dt;
                lbldonemicro.Text = dgvProdToday.RowCount.ToString();



                sql_con.Close();








        }

        void TotalMicroRepackingPerformanceOntime()
        {

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);




            string sqlquery = "Select emp.prod_id as ID, emp.p_feed_code as Emp_Number, emp.p_bags as Department,emp.p_nobatch as TotalPack,emp.proddate as Production_Date,emp.start_micro_repacking as MicroStart,emp.end_micro_repacking as MicroEnd,emp.start_macro_repacking as MacroStart,emp.end_macro_repacking as MacroEnd, emp.repacking_status as repack_status,emp.micro_repacking_time from rdf_production_advance emp WHERE emp.is_selected='1' AND emp.is_active=1 AND emp.canceltheapprove IS NULL AND CAST(emp.finish_production_date as date) BETWEEN '" + dtpFilter.Text + "' AND '" + dtpTo.Text + "' AND emp.end_micro_repacking IS NOT NULL AND emp.is_selected='1' AND emp.is_active='1' ";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvProdToday.DataSource = dt;
            lbldonemicro.Text = dgvProdToday.RowCount.ToString();



            sql_con.Close();








        }

        void TotalMicroRepackingPerformancePending()
        {

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


 

            string sqlquery = "Select emp.prod_id as PROD_ID,emp.proddate as PROD_PLAN, emp.p_feed_code as FEEDCODE,emp.p_bags as BAGS,emp.is_active,emp.canceltheapprove,emp.is_selected as STATUS, emp.approved_date as PLANNING, emp.preparation_date_finish as MICRO,emp.macro_prep_status_date as MACRO, emp.BMX_finish_date as BASEDMIXED, emp.finish_production_date as PRODUCTION, emp.fg_date_finish as FG, empe.days_to_production as DAY from [dbo].[rdf_production_advance] emp LEFT JOIN [dbo].[rdf_finish_goods] empe ON emp.prod_id=empe.fg_prod_id WHERE NOT emp.canceltheapprove IS NOT NULL AND NOT emp.iscancelreason IS NOT NULL AND emp.iscancel IS NULL AND emp.finish_production_date IS NOT NULL AND emp.is_selected='1' AND emp.is_active='1'";


            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvProdToday.DataSource = dt;
            lbldonemicro.Text = dgvProdToday.RowCount.ToString();



            sql_con.Close();








        }


        void TotalMacroRepacking()
        {

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);



        

                string sqlquery = "Select emp.prod_id as ID, emp.p_feed_code as Emp_Number, emp.p_bags as Department,emp.p_nobatch as TotalPack,emp.proddate as Production_Date,emp.start_micro_repacking as MicroStart,emp.end_micro_repacking as MicroEnd,emp.start_macro_repacking as MacroStart,emp.end_macro_repacking as MacroEnd, emp.repacking_status as repack_status,emp.micro_repacking_time from rdf_production_advance emp WHERE emp.is_selected='1' AND emp.is_active=1 AND emp.canceltheapprove IS NULL AND CAST(emp.proddate as date) BETWEEN '" + dtpFilter.Text + "' AND '"+dtpTo.Text+"' AND emp.end_macro_repacking IS NOT NULL ";
                sql_con.Open();
                SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
                SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
                DataTable dt = new DataTable();
                sdr.Fill(dt);
                dgvProdToday2.DataSource = dt;
                lblnotdonemicro2.Text = dgvProdToday2.RowCount.ToString();



                sql_con.Close();





        }

        void TotalMacroRepackingPerformanceOntime()
        {

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            //gerald             string sqlquery = "Select emp.prod_id as ID, emp.p_feed_code as Emp_Number, emp.p_bags as Department,emp.p_nobatch as TotalPack,emp.proddate as Production_Date, emp.repacking_status as repack_status from rdf_production_advance emp WHERE emp.proddate ='" + txtdateplusone.Text + "' OR emp.proddate ='"+dtpreceivingdate.Text+"' OR emp.proddate ='"+ txtdateminus1.Text+"' AND emp.is_selected=1 AND emp.repacking_status='ready' AND NOT emp.canceltheapprove IS NOT NULL";

            string sqlquery = "Select emp.prod_id as PROD_ID,emp.proddate as PROD_PLAN, emp.p_feed_code as FEEDCODE,emp.p_bags as BAGS,emp.is_active,emp.canceltheapprove,emp.is_selected as STATUS, emp.approved_date as PLANNING, emp.preparation_date_finish as MICRO,emp.macro_prep_status_date as MACRO, emp.BMX_finish_date as BASEDMIXED, emp.finish_production_date as PRODUCTION, emp.fg_date_finish as FG, empe.days_to_production as DAY,emp.finish_production_date as prodactual from [dbo].[rdf_production_advance] emp LEFT JOIN [dbo].[rdf_finish_goods] empe ON emp.prod_id=empe.fg_prod_id WHERE CAST(emp.finish_production_date as date) BETWEEN '" + dtpFilter.Text + "' AND '" + dtpTo.Text + "' AND NOT emp.canceltheapprove IS NOT NULL AND NOT emp.iscancelreason IS NOT NULL AND emp.iscancel IS NULL AND emp.is_selected='1' AND emp.is_active='1' AND emp.proddate = emp.finish_production_date";


            //string sqlquery = "Select emp.prod_id as ID, emp.p_feed_code as Emp_Number, emp.p_bags as Department,emp.p_nobatch as TotalPack,emp.proddate as Production_Date,emp.start_micro_repacking as MicroStart,emp.end_micro_repacking as MicroEnd,emp.start_macro_repacking as MacroStart,emp.end_macro_repacking as MacroEnd, emp.repacking_status as repack_status,emp.micro_repacking_time from rdf_production_advance emp WHERE emp.is_selected=1 AND emp.is_active=1 AND emp.canceltheapprove IS NULL AND CAST(emp.finish_production_date as date) BETWEEN '" + dtpFilter.Text + "' AND '" + dtpTo.Text + "' AND emp.end_macro_repacking IS NOT NULL AND emp.is_selected='1' AND emp.is_active='1' ";


            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvProdToday2.DataSource = dt;
            lblnotdonemicro2.Text = dgvProdToday2.RowCount.ToString();



            sql_con.Close();





        }



        void TotalMacroRepackingPerformancePending()
        {

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);





            string sqlquery = "Select emp.prod_id as ID, emp.p_feed_code as Emp_Number, emp.p_bags as Department,emp.p_nobatch as TotalPack,emp.proddate as Production_Date,emp.start_micro_repacking as MicroStart,emp.end_micro_repacking as MicroEnd,emp.start_macro_repacking as MacroStart,emp.end_macro_repacking as MacroEnd, emp.repacking_status as repack_status,emp.micro_repacking_time from rdf_production_advance emp WHERE emp.is_selected=1 AND emp.is_active=1 AND emp.canceltheapprove IS NULL AND emp.end_macro_repacking IS NOT NULL  AND emp.finish_production_date IS NULL AND emp.is_selected='1' AND emp.is_active='1'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvProdToday2.DataSource = dt;
            lblnotdonemicro2.Text = dgvProdToday2.RowCount.ToString();



            sql_con.Close();





        }


        public void DoneinMicroBasemixed()
        {



            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            //gerald             string sqlquery = "Select emp.prod_id as ID, emp.p_feed_code as Emp_Number, emp.p_bags as Department,emp.p_nobatch as TotalPack,emp.proddate as Production_Date, emp.repacking_status as repack_status from rdf_production_advance emp WHERE emp.proddate ='" + txtdateplusone.Text + "' OR emp.proddate ='"+dtpreceivingdate.Text+"' OR emp.proddate ='"+ txtdateminus1.Text+"' AND emp.is_selected=1 AND emp.repacking_status='ready' AND NOT emp.canceltheapprove IS NOT NULL";
            string sqlquery = "Select emp.prod_id as ID, emp.p_feed_code as Emp_Number, emp.p_bags as Department,emp.p_nobatch as TotalPack,emp.proddate as Production_Date,emp.start_micro_repacking as MicroStart,emp.end_micro_repacking as MicroEnd,emp.start_macro_repacking as MacroStart,emp.end_macro_repacking as MacroEnd, emp.repacking_status as repack_status,emp.micro_repacking_time from rdf_production_advance emp WHERE emp.is_selected=1 AND emp.is_active=1 AND emp.canceltheapprove IS NULL AND CAST(emp.proddate as date) BETWEEN '" + dtpFilter.Text + "' AND '"+dtpTo.Text+"' AND emp.BMX_Status IS NOT NULL AND emp.iscancel IS NULL ";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvProdToday.DataSource = dt;
            lbldonemicro.Text = dgvProdToday.RowCount.ToString();



            sql_con.Close();

        }

        
        public void DoneinProduction()
        {


            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            //gerald             string sqlquery = "Select emp.prod_id as ID, emp.p_feed_code as Emp_Number, emp.p_bags as Department,emp.p_nobatch as TotalPack,emp.proddate as Production_Date, emp.repacking_status as repack_status from rdf_production_advance emp WHERE emp.proddate ='" + txtdateplusone.Text + "' OR emp.proddate ='"+dtpreceivingdate.Text+"' OR emp.proddate ='"+ txtdateminus1.Text+"' AND emp.is_selected=1 AND emp.repacking_status='ready' AND NOT emp.canceltheapprove IS NOT NULL";
            string sqlquery = "Select emp.prod_id as ID, emp.p_feed_code as Emp_Number, emp.p_bags as Department,emp.p_nobatch as TotalPack,emp.proddate as Production_Date,emp.start_micro_repacking as MicroStart,emp.end_micro_repacking as MicroEnd,emp.start_macro_repacking as MacroStart,emp.end_macro_repacking as MacroEnd, emp.repacking_status as repack_status,emp.micro_repacking_time from rdf_production_advance emp WHERE emp.is_selected=1 AND emp.is_active=1 AND emp.canceltheapprove IS NULL AND CAST(emp.proddate as date) BETWEEN '" + dtpFilter.Text + "' AND '"+dtpTo.Text+"' AND emp.finish_production_date IS NOT NULL AND emp.iscancel IS NULL ";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvProdToday.DataSource = dt;
            lbldonemicro.Text = dgvProdToday.RowCount.ToString();



            sql_con.Close();


        }


        void DoneFinishedGoods()
        {


            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            //gerald             string sqlquery = "Select emp.prod_id as ID, emp.p_feed_code as Emp_Number, emp.p_bags as Department,emp.p_nobatch as TotalPack,emp.proddate as Production_Date, emp.repacking_status as repack_status from rdf_production_advance emp WHERE emp.proddate ='" + txtdateplusone.Text + "' OR emp.proddate ='"+dtpreceivingdate.Text+"' OR emp.proddate ='"+ txtdateminus1.Text+"' AND emp.is_selected=1 AND emp.repacking_status='ready' AND NOT emp.canceltheapprove IS NOT NULL";
            string sqlquery = "Select emp.prod_id as ID, emp.p_feed_code as Emp_Number, emp.p_bags as Department,emp.p_nobatch as TotalPack,emp.proddate as Production_Date,emp.start_micro_repacking as MicroStart,emp.end_micro_repacking as MicroEnd,emp.start_macro_repacking as MacroStart,emp.end_macro_repacking as MacroEnd, emp.repacking_status as repack_status,emp.micro_repacking_time from rdf_production_advance emp WHERE emp.is_selected=1 AND emp.is_active=1 AND emp.canceltheapprove IS NULL AND CAST(emp.proddate as date) BETWEEN '" + dtpFilter.Text + "' AND '"+dtpTo.Text+"' AND emp.fg_date_finish IS NOT NULL AND emp.iscancel IS NULL ";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvProdToday.DataSource = dt;
            lbldonemicro.Text = dgvProdToday.RowCount.ToString();



            sql_con.Close();




        }


        public void ApporovePending()
        {

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            //gerald             string sqlquery = "Select emp.prod_id as ID, emp.p_feed_code as Emp_Number, emp.p_bags as Department,emp.p_nobatch as TotalPack,emp.proddate as Production_Date, emp.repacking_status as repack_status from rdf_production_advance emp WHERE emp.proddate ='" + txtdateplusone.Text + "' OR emp.proddate ='"+dtpreceivingdate.Text+"' OR emp.proddate ='"+ txtdateminus1.Text+"' AND emp.is_selected=1 AND emp.repacking_status='ready' AND NOT emp.canceltheapprove IS NOT NULL";
            string sqlquery = "Select emp.prod_id as ID, emp.p_feed_code as Emp_Number, emp.p_bags as Department,emp.p_nobatch as TotalPack,emp.proddate as Production_Date,emp.start_micro_repacking as MicroStart,emp.end_micro_repacking as MicroEnd,emp.start_macro_repacking as MacroStart,emp.end_macro_repacking as MacroEnd, emp.repacking_status as repack_status,emp.micro_repacking_time from rdf_production_advance emp WHERE emp.is_selected=0 AND emp.is_active=1 AND emp.canceltheapprove IS NULL AND CAST(emp.proddate as date) BETWEEN '" + dtpFilter.Text + "' AND '"+dtpTo.Text+"' AND emp.iscancel IS NULL ";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvProdToday2.DataSource = dt;
            lblnotdonemicro2.Text = dgvProdToday2.RowCount.ToString();



            sql_con.Close();



        }

        void PendingBasemixed()
        {

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            //gerald             string sqlquery = "Select emp.prod_id as ID, emp.p_feed_code as Emp_Number, emp.p_bags as Department,emp.p_nobatch as TotalPack,emp.proddate as Production_Date, emp.repacking_status as repack_status from rdf_production_advance emp WHERE emp.proddate ='" + txtdateplusone.Text + "' OR emp.proddate ='"+dtpreceivingdate.Text+"' OR emp.proddate ='"+ txtdateminus1.Text+"' AND emp.is_selected=1 AND emp.repacking_status='ready' AND NOT emp.canceltheapprove IS NOT NULL";
            string sqlquery = "Select emp.prod_id as ID, emp.p_feed_code as Emp_Number, emp.p_bags as Department,emp.p_nobatch as TotalPack,emp.proddate as Production_Date,emp.start_micro_repacking as MicroStart,emp.end_micro_repacking as MicroEnd,emp.start_macro_repacking as MacroStart,emp.end_macro_repacking as MacroEnd, emp.repacking_status as repack_status,emp.micro_repacking_time from rdf_production_advance emp WHERE emp.is_active=1 AND emp.canceltheapprove IS NULL AND CAST(emp.proddate as date) BETWEEN '" + dtpFilter.Text + "' AND '"+dtpTo.Text+"' AND emp.BMX_Status IS NULL AND emp.iscancel IS NULL ";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvProdToday2.DataSource = dt;
            lblnotdonemicro2.Text = dgvProdToday2.RowCount.ToString();



            sql_con.Close();





        }

        public void PendinginProduction()
        {

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            //gerald             string sqlquery = "Select emp.prod_id as ID, emp.p_feed_code as Emp_Number, emp.p_bags as Department,emp.p_nobatch as TotalPack,emp.proddate as Production_Date, emp.repacking_status as repack_status from rdf_production_advance emp WHERE emp.proddate ='" + txtdateplusone.Text + "' OR emp.proddate ='"+dtpreceivingdate.Text+"' OR emp.proddate ='"+ txtdateminus1.Text+"' AND emp.is_selected=1 AND emp.repacking_status='ready' AND NOT emp.canceltheapprove IS NOT NULL";
            string sqlquery = "Select emp.prod_id as ID, emp.p_feed_code as Emp_Number, emp.p_bags as Department,emp.p_nobatch as TotalPack,emp.proddate as Production_Date,emp.start_micro_repacking as MicroStart,emp.end_micro_repacking as MicroEnd,emp.start_macro_repacking as MacroStart,emp.end_macro_repacking as MacroEnd, emp.repacking_status as repack_status,emp.micro_repacking_time from rdf_production_advance emp WHERE emp.is_active=1 AND emp.canceltheapprove IS NULL AND CAST(emp.proddate as date) BETWEEN '" + dtpFilter.Text + "' AND '"+dtpTo.Text+"' AND emp.finish_production_date IS NULL AND emp.iscancel IS NULL ";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvProdToday2.DataSource = dt;
            lblnotdonemicro2.Text = dgvProdToday2.RowCount.ToString();



            sql_con.Close();





        }

        public void PendingFinishedGoods()
        {

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            //gerald             string sqlquery = "Select emp.prod_id as ID, emp.p_feed_code as Emp_Number, emp.p_bags as Department,emp.p_nobatch as TotalPack,emp.proddate as Production_Date, emp.repacking_status as repack_status from rdf_production_advance emp WHERE emp.proddate ='" + txtdateplusone.Text + "' OR emp.proddate ='"+dtpreceivingdate.Text+"' OR emp.proddate ='"+ txtdateminus1.Text+"' AND emp.is_selected=1 AND emp.repacking_status='ready' AND NOT emp.canceltheapprove IS NOT NULL";
            string sqlquery = "Select emp.prod_id as ID, emp.p_feed_code as Emp_Number, emp.p_bags as Department,emp.p_nobatch as TotalPack,emp.proddate as Production_Date,emp.start_micro_repacking as MicroStart,emp.end_micro_repacking as MicroEnd,emp.start_macro_repacking as MacroStart,emp.end_macro_repacking as MacroEnd, emp.repacking_status as repack_status,emp.micro_repacking_time from rdf_production_advance emp WHERE emp.is_active=1 AND emp.canceltheapprove IS NULL AND CAST(emp.proddate as date) BETWEEN '" + dtpFilter.Text + "' AND '"+dtpTo.Text+"' AND emp.fg_date_finish IS NULL AND emp.iscancel IS NULL ";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvProdToday2.DataSource = dt;
            lblnotdonemicro2.Text = dgvProdToday2.RowCount.ToString();



            sql_con.Close();






        }


        void ProductionCancelled()
        {

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            //gerald             string sqlquery = "Select emp.prod_id as ID, emp.p_feed_code as Emp_Number, emp.p_bags as Department,emp.p_nobatch as TotalPack,emp.proddate as Production_Date, emp.repacking_status as repack_status from rdf_production_advance emp WHERE emp.proddate ='" + txtdateplusone.Text + "' OR emp.proddate ='"+dtpreceivingdate.Text+"' OR emp.proddate ='"+ txtdateminus1.Text+"' AND emp.is_selected=1 AND emp.repacking_status='ready' AND NOT emp.canceltheapprove IS NOT NULL";
            string sqlquery = "Select emp.prod_id as ID, emp.p_feed_code as Emp_Number, emp.p_bags as Department,emp.p_nobatch as TotalPack,emp.proddate as Production_Date,emp.start_micro_repacking as MicroStart,emp.end_micro_repacking as MicroEnd,emp.start_macro_repacking as MacroStart,emp.end_macro_repacking as MacroEnd, emp.repacking_status as repack_status,emp.micro_repacking_time from rdf_production_advance emp WHERE CAST(emp.proddate as date) BETWEEN '" + dtpFilter.Text + "' AND '"+dtpTo.Text+"' AND emp.iscancel='1'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvProdCancel.DataSource = dt;
          lblcancel.Text = dgvProdCancel.RowCount.ToString();



            sql_con.Close();



        }


        void mYtotalQuery()
        {


            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            //gerald             string sqlquery = "Select emp.prod_id as ID, emp.p_feed_code as Emp_Number, emp.p_bags as Department,emp.p_nobatch as TotalPack,emp.proddate as Production_Date, emp.repacking_status as repack_status from rdf_production_advance emp WHERE emp.proddate ='" + txtdateplusone.Text + "' OR emp.proddate ='"+dtpreceivingdate.Text+"' OR emp.proddate ='"+ txtdateminus1.Text+"' AND emp.is_selected=1 AND emp.repacking_status='ready' AND NOT emp.canceltheapprove IS NOT NULL";
            string sqlquery = "Select emp.prod_id as ID, emp.p_feed_code as Emp_Number, emp.p_bags as Department,emp.p_nobatch as TotalPack,emp.proddate as Production_Date,emp.start_micro_repacking as MicroStart,emp.end_micro_repacking as MicroEnd,emp.start_macro_repacking as MacroStart,emp.end_macro_repacking as MacroEnd, emp.repacking_status as repack_status,emp.micro_repacking_time from rdf_production_advance emp WHERE CAST(emp.proddate as date) BETWEEN '" + dtpFilter.Text + "' AND '"+dtpTo.Text+"' AND NOT emp.canceltheapprove IS NOT NULL";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvtotalprod.DataSource = dt;
            lblmytotal.Text = dgvtotalprod.RowCount.ToString();



            sql_con.Close();

        }


        public void MicroandMacroRepacking()
        {
            chart1.Visible = false;
            chart3.Visible = true;
            chart4.Visible = false;
            MicroIN();
            MicroOut();
            MacroOut();
            MacroIN();
            ProdSchedulesMicro();
            //chart1.Titles.Add("Micro Pie Chart");

            double micropending;
            double donemicro;
            micropending = double.Parse(lblmymicropending.Text);
            donemicro = double.Parse(lblmymicrodone.Text);;
            chart3.Series["s1"].Points.Clear();

            lblnotdonemicro2.Visible = false;
            chart3.Series["s1"].Points.AddXY("Pending", micropending);

            chart3.Series["s1"].Points.AddXY("Done (MICRO)", donemicro);

            //panel
            panel3.Visible = true;
            panel4.Visible = true;

            //pen 
            pen1.Visible = true;
            pen2.Visible = true;
            pen3.Visible = true;
            pen4.Visible = true;
            lblclose3.Visible = false;
            lblopen3.Visible = false;
            //plugin
            //lblpers1.Visible = false;
            //lblcancelpercentage.Visible = false;
            //lblpendingpercentage.Visible = true;
            //lblpers2.Visible = true;
            //lblapprovepercentage.Visible = true;
            //lblpers3.Visible = true;


            //additional pen
            pen5.Visible = true;
            pen6.Visible = true;
            pen7.Visible = true;
            pen8.Visible = true;
            pen9.Visible = true;
            pen10.Visible = true;
            pen11.Visible = true;
            pen12.Visible = true;

            //opener
            lblopen1.Visible = false;
            lblopen2.Visible = false;
            lblclose1.Visible = false;
            lblclose2.Visible = false;



            lbl1.Visible = false;

            lbl2.Visible = false;
            lbl3.Visible = false;
            //rename == 
            label2.Text = "Pending Micro";
            label3.Text = "Done Micro";

            double macropending;
            double macrodone;
            macropending = double.Parse(lblnotdonemacro2.Text);
            macrodone = double.Parse(lbldonemacro.Text);



            //proce
            lblprocess.Visible = false;
            lblrejected.Visible = false;

            chart2.Series["s2"].Points.Clear();
            chart2.Series["s2"].Points.AddXY("Pending", macropending);
            chart2.Series["s2"].Points.AddXY("Done (MACRO)", macrodone);

            lblmacro.Visible = true;
            lblmicro.Visible = true;
            lbldonemicro.Visible = false;
            //lblnotdonemicro2.Visible = true;
            lbldonemacro.Visible = true;
            lblnotdonemacro2.Visible = true;
            chart2.Visible = true;
            lblmicro.Text = "Micro Pie Chart";
            lblcancel.Visible = false;
            panel2.Visible = false;


            //repacking
            lblmymicrodone.Visible = true;
            label7.Visible = true; 
            myblue.Visible = true;


            lblmymicropending.Visible = true;
            label8.Visible = true; 
            myred.Visible = true;

            // the addons pupup will, be place here madafaka!
            label2.Visible = false;
            pbRed.Visible = false;
            pbBlue.Visible = false;
            label3.Visible = false;
            pbOrange.Visible = false;
            label4.Visible = false;

            pbred2.Visible = true;
            label6.Visible = true;
            pbblue2.Visible = true;
            label5.Visible = true;



            //plugin
            lblpers1.Visible = false;
            lblcancelpercentage.Visible = false;
            lblpendingpercentage.Visible = false;
            lblpers2.Visible = false;
            lblapprovepercentage.Visible = false;
            lblpers3.Visible = false;




            //computation percentage
       lblmico.Text = (float.Parse(lblmymicrodone.Text) / float.Parse(lblmytotal.Text)).ToString();

            lblmico.Text = (float.Parse(lblmico.Text) * 100).ToString("#,0.0");


            lblmica.Text = (float.Parse(lblmymicropending.Text) / float.Parse(lblmytotal.Text)).ToString();

            lblmica.Text = (float.Parse(lblmica.Text) * 100).ToString("#,0.0");


            //gerard





            //computation percentage
            lblmacdone.Text = (float.Parse(lbldonemacro.Text) / float.Parse(lblmytotal.Text)).ToString();

            lblmacdone.Text = (float.Parse(lblmacdone.Text) * 100).ToString("#,0.0");


            lblmacpending.Text = (float.Parse(lblnotdonemacro2.Text) / float.Parse(lblmytotal.Text)).ToString();

            lblmacpending.Text = (float.Parse(lblmacpending.Text) * 100).ToString("#,0.0");


            //percotange
            lblmico.Visible = true;
            lblmica.Visible = true;
            lblmacdone.Visible = true;
            lblmacpending.Visible = true;



            SumdaTimeStamp();

            //  if (lblnotdonemicro2.Text == "0")
            //  {
            //      dgvProdToday2.Visible = false;
            //  }
            //  else
            //  {
            //      dgvProdToday2.Visible = true; ;
            //  }

            //  if (lbldonemicro.Text == "0")
            //  {
            //      dgvProdToday.Visible = false;
            //  }
            //  else
            //  {
            //      dgvProdToday.Visible = true;
            //  }


            //if (lblnotdonemacro2.Text=="0")
            //  {
            //      dgvProdToday3.Visible = false;
            //  }
            //else
            //  {
            //      dgvProdToday3.Visible = true;
            //  }

            //if (lbldonemacro.Text=="0")
            //  {
            //      dgvProdToday4.Visible = false;
            //  }
            //else
            //  {
            //      dgvProdToday4.Visible = true;
            //  }
            lbltitle.BringToFront();
            lbltitle.Visible = true;
            lblmicro.Visible = false;
        }

        void MicroIN()
        {

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            //gerald             string sqlquery = "Select emp.prod_id as ID, emp.p_feed_code as Emp_Number, emp.p_bags as Department,emp.p_nobatch as TotalPack,emp.proddate as Production_Date, emp.repacking_status as repack_status from rdf_production_advance emp WHERE emp.proddate ='" + txtdateplusone.Text + "' OR emp.proddate ='"+dtpreceivingdate.Text+"' OR emp.proddate ='"+ txtdateminus1.Text+"' AND emp.is_selected=1 AND emp.repacking_status='ready' AND NOT emp.canceltheapprove IS NOT NULL";
            string sqlquery = "Select emp.prod_id as ID, emp.p_feed_code as Emp_Number, emp.p_bags as Department,emp.p_nobatch as TotalPack,emp.proddate as Production_Date,emp.start_micro_repacking as MicroStart,emp.end_micro_repacking as MicroEnd,emp.start_macro_repacking as MacroStart,emp.end_macro_repacking as MacroEnd, emp.repacking_status as repack_status,emp.micro_repacking_time from rdf_production_advance emp WHERE emp.is_selected=1 AND emp.is_active=1 AND emp.canceltheapprove IS NULL AND CAST(emp.proddate as date) BETWEEN '" + dtpFilter.Text + "' AND '"+dtpTo.Text+"' AND emp.start_micro_repacking IS NOT NULL AND emp.end_micro_repacking IS NOT NULL";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvProdToday.DataSource = dt;
           lblmymicrodone.Text = dgvProdToday.RowCount.ToString();



            sql_con.Close();


            //int sum = 0;
            //for (Double i = 0; i < dgvProdToday.Rows.Count; ++i)
            //{
            //    sum += Convert.ToString(dgvProdToday.Rows[i].Cells[10].Value);
            //}
            //lbltotalmicro.Text = sum.ToString();



        }

        void MacroIN()
        {

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            //gerald             string sqlquery = "Select emp.prod_id as ID, emp.p_feed_code as Emp_Number, emp.p_bags as Department,emp.p_nobatch as TotalPack,emp.proddate as Production_Date, emp.repacking_status as repack_status from rdf_production_advance emp WHERE emp.proddate ='" + txtdateplusone.Text + "' OR emp.proddate ='"+dtpreceivingdate.Text+"' OR emp.proddate ='"+ txtdateminus1.Text+"' AND emp.is_selected=1 AND emp.repacking_status='ready' AND NOT emp.canceltheapprove IS NOT NULL";
            string sqlquery = "Select emp.prod_id as ID, emp.p_feed_code as Emp_Number, emp.p_bags as Department,emp.p_nobatch as TotalPack,emp.proddate as Production_Date,emp.start_micro_repacking as MicroStart,emp.end_micro_repacking as MicroEnd,emp.start_macro_repacking as MacroStart,emp.end_macro_repacking as MacroEnd, emp.repacking_status as repack_status from rdf_production_advance emp WHERE emp.is_selected=1 AND emp.is_active=1 AND emp.canceltheapprove IS NULL AND CAST(emp.proddate as date) BETWEEN '" + dtpFilter.Text + "' AND '"+dtpTo.Text+"' AND emp.start_macro_repacking IS NOT NULL AND emp.end_macro_repacking IS NOT NULL";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvProdToday4.DataSource = dt;
            lbldonemacro.Text = dgvProdToday4.RowCount.ToString();



            sql_con.Close();
        }






        void MicroOut()
        {

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            //gerald             string sqlquery = "Select emp.prod_id as ID, emp.p_feed_code as Emp_Number, emp.p_bags as Department,emp.p_nobatch as TotalPack,emp.proddate as Production_Date, emp.repacking_status as repack_status from rdf_production_advance emp WHERE emp.proddate ='" + txtdateplusone.Text + "' OR emp.proddate ='"+dtpreceivingdate.Text+"' OR emp.proddate ='"+ txtdateminus1.Text+"' AND emp.is_selected=1 AND emp.repacking_status='ready' AND NOT emp.canceltheapprove IS NOT NULL";
            string sqlquery = "Select emp.p_feed_code,emp.p_bags,emp.is_active,emp.canceltheapprove,emp.start_micro_repacking  from [dbo].[rdf_production_advance] emp WHERE emp.is_selected=1 AND emp.is_active=1 AND emp.canceltheapprove IS NULL AND CAST(emp.proddate as date) BETWEEN '" + dtpFilter.Text + "' AND '"+dtpTo.Text+"' AND emp.end_micro_repacking IS NULL";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvProdToday2.DataSource = dt;
            lblmymicropending.Text = dgvProdToday2.RowCount.ToString();



            sql_con.Close();
        }

        void ProdSchedulesMicro()
        {

           // dgvProductionSchedules.Columns["Column15"].Visible = true;
           // dgvProductionSchedules.Columns["Column14"].Visible = true;
           // dgvProductionSchedules.Columns["startmac"].Visible = true;
           // dgvProductionSchedules.Columns["Column11"].Visible = true;

           // dgvProductionSchedules.Columns["Column12"].Visible = true;

           //dgvProductionSchedules.Columns["Column13"].Visible = true;


            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            //gerald             string sqlquery = "Select emp.prod_id as ID, emp.p_feed_code as Emp_Number, emp.p_bags as Department,emp.p_nobatch as TotalPack,emp.proddate as Production_Date, emp.repacking_status as repack_status from rdf_production_advance emp WHERE emp.proddate ='" + txtdateplusone.Text + "' OR emp.proddate ='"+dtpreceivingdate.Text+"' OR emp.proddate ='"+ txtdateminus1.Text+"' AND emp.is_selected=1 AND emp.repacking_status='ready' AND NOT emp.canceltheapprove IS NOT NULL";
            string sqlquery = "Select emp.prod_id as PRODUCTION_ID,emp.p_feed_code as FEEDCODE,emp.p_bags as BAGS,emp.is_active,emp.canceltheapprove,emp.start_micro_repacking as MICRO_START,emp.end_micro_repacking as MICRO_END,emp.micro_repacking_time as MIC_DURATION, emp.start_macro_repacking as MACRO_START, emp.end_macro_repacking as MACRO_END,emp.macro_repacking_time as MAC_DURATION  from [dbo].[rdf_production_advance] emp WHERE emp.is_selected=1 AND emp.is_active=1 AND emp.canceltheapprove IS NULL AND CAST(emp.proddate as date) BETWEEN '" + dtpFilter.Text + "' AND '"+dtpTo.Text+"'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvProductionSchedules.DataSource = dt;
            //lblnotdonemicro2.Text = dgvProdToday2.RowCount.ToString();
            lblmytotal.Text = dgvProductionSchedules.RowCount.ToString();


            sql_con.Close();





        }

        void PlannerView()
        {



            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);

            string sqlquery = "Select emp.prod_id as PRODUCTION_ID,emp.p_feed_code as FEEDCODE,emp.p_bags as BAGS,emp.is_active,emp.canceltheapprove,emp.is_selected as STATUS,emp.dateadded as PLANNER,emp.aproved_date_time as APPROVER,emp.plannerAndapprover as DURATION  from [dbo].[rdf_production_advance] emp WHERE CAST(emp.proddate as date) BETWEEN '" + dtpFilter.Text + "' AND '"+dtpTo.Text+"' AND NOT emp.canceltheapprove IS NOT NULL AND NOT emp.iscancelreason IS NOT NULL AND emp.iscancel IS NULL AND emp.is_selected='1'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvProductionSchedules.DataSource = dt;
            //lblnotdonemicro2.Text = dgvProdToday2.RowCount.ToString();

lbltotalprod.Text = dgvProductionSchedules.RowCount.ToString();



            sql_con.Close();





        }


        void OverAllView()
        {



            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            //gerald             string sqlquery = "Select emp.prod_id as ID, emp.p_feed_code as Emp_Number, emp.p_bags as Department,emp.p_nobatch as TotalPack,emp.proddate as Production_Date, emp.repacking_status as repack_status from rdf_production_advance emp WHERE emp.proddate ='" + txtdateplusone.Text + "' OR emp.proddate ='"+dtpreceivingdate.Text+"' OR emp.proddate ='"+ txtdateminus1.Text+"' AND emp.is_selected=1 AND emp.repacking_status='ready' AND NOT emp.canceltheapprove IS NOT NULL";

            //if (cmdFedoraModules.Text == "Overall Reports From and To")
            //{


                string sqlquery = "Select emp.prod_id as PROD_ID,emp.proddate as PROD_PLAN, emp.p_feed_code as FEEDCODE,emp.p_bags as BAGS,emp.is_active,emp.canceltheapprove,emp.is_selected as STATUS, emp.is_selected as PLANNING, emp.micro_bit as MICRO,emp.macro_bit as MACRO, emp.micro_mixing_automation as BASEDMIXED, emp.production_bit as PRODUCTION, emp.fg_bit as FG, empe.days_to_production as DAY  from [dbo].[rdf_production_advance] emp LEFT JOIN [dbo].[rdf_finish_goods] empe ON emp.prod_id=empe.fg_prod_id WHERE CAST(emp.proddate as date) BETWEEN '" + dtpFilter.Text + "' AND '"+dtpTo.Text+"' AND emp.is_selected='1' AND NOT emp.canceltheapprove IS NOT NULL AND NOT emp.iscancelreason IS NOT NULL AND emp.iscancel IS NULL";


                sql_con.Open();
                SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
                SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
                DataTable dt = new DataTable();
                sdr.Fill(dt);
                dgvProductionSchedules.DataSource = dt;
                //lblnotdonemicro2.Text = dgvProdToday2.RowCount.ToString();

                lbltotalprod.Text = dgvProductionSchedules.RowCount.ToString();



                sql_con.Close();





        }


        void OverAllViewPerformanceOntime()
        {



            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);




            string sqlquery = "Select emp.prod_id as PROD_ID,emp.proddate as PROD_PLAN, emp.p_feed_code as FEEDCODE,emp.p_bags as BAGS,emp.is_active,emp.canceltheapprove,emp.is_selected as STATUS, emp.approved_date as PLANNING, emp.preparation_date_finish as MICRO,emp.macro_prep_status_date as MACRO, emp.BMX_finish_date as BASEDMIXED, emp.finish_production_date as PRODUCTION, emp.fg_date_finish as FG, empe.days_to_production as DAY, empe.days_to_production as DAYA from [dbo].[rdf_production_advance] emp LEFT JOIN [dbo].[rdf_finish_goods] empe ON emp.prod_id=empe.fg_prod_id WHERE CAST(emp.finish_production_date as date) BETWEEN '" + dtpFilter.Text + "' AND '" + dtpTo.Text + "' AND NOT emp.canceltheapprove IS NOT NULL AND NOT emp.iscancelreason IS NOT NULL AND emp.iscancel IS NULL AND emp.is_selected='1' AND emp.is_active='1'";


            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvPP.DataSource = dt;
            //lblnotdonemicro2.Text = dgvProdToday2.RowCount.ToString();

            lbltotalprod.Text = dgvPP.RowCount.ToString();



            sql_con.Close();





        }

        void OverAllViewPerformancePending()
        {



            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);




            string sqlquery = "Select emp.prod_id as PROD_ID,emp.proddate as PROD_PLAN, emp.p_feed_code as FEEDCODE,emp.p_bags as BAGS,emp.is_active,emp.canceltheapprove,emp.is_selected as STATUS, emp.approved_date as PLANNING, emp.preparation_date_finish as MICRO,emp.macro_prep_status_date as MACRO, emp.BMX_finish_date as BASEDMIXED, empe.days_to_production as DAY from [dbo].[rdf_production_advance] emp LEFT JOIN [dbo].[rdf_finish_goods] empe ON emp.prod_id=empe.fg_prod_id WHERE NOT emp.canceltheapprove IS NOT NULL AND NOT emp.iscancelreason IS NOT NULL AND emp.iscancel IS NULL AND emp.finish_production_date IS NULL AND emp.is_selected='1' AND emp.is_active='1' ORDER BY CAST(emp.proddate as date) ASC";


            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvWIP.DataSource = dt;
            //lblnotdonemicro2.Text = dgvProdToday2.RowCount.ToString();

            lbltotalprod.Text = dgvWIP.RowCount.ToString();



            sql_con.Close();





        }






        public void BasemixedViewinProd()
        {

   

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            //gerald             string sqlquery = "Select emp.prod_id as ID, emp.p_feed_code as Emp_Number, emp.p_bags as Department,emp.p_nobatch as TotalPack,emp.proddate as Production_Date, emp.repacking_status as repack_status from rdf_production_advance emp WHERE emp.proddate ='" + txtdateplusone.Text + "' OR emp.proddate ='"+dtpreceivingdate.Text+"' OR emp.proddate ='"+ txtdateminus1.Text+"' AND emp.is_selected=1 AND emp.repacking_status='ready' AND NOT emp.canceltheapprove IS NOT NULL";
            string sqlquery = "  Select DISTINCT emp.prod_id as PRODUCTION_ID,emp.p_feed_code as FEEDCODE,emp.p_bags as BAGS,emp.is_active,emp.canceltheapprove,emp.BMX_Status as STATUS,bmx.added_by as CREATED_BY, emp.start_of_basemixed as START,emp.microbasemixed_ending as FINISHED,  datediff(MINUTE, emp.start_of_basemixed, emp.microbasemixed_ending) as MINUTES  from [dbo].[rdf_production_advance] emp  LEFT JOIN rdf_repackin_bmx bmx ON emp.prod_id=bmx.prod_adv WHERE CAST(emp.proddate as date) BETWEEN '" + dtpFilter.Text + "' AND '"+dtpTo.Text+"' AND NOT emp.canceltheapprove IS NOT NULL AND NOT emp.iscancelreason IS NOT NULL AND emp.iscancel IS NULL AND emp.is_selected='1'";


            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvProductionSchedules.DataSource = dt;

            lblmytotal.Text = dgvProductionSchedules.RowCount.ToString();


            sql_con.Close();





        }

        void CallBMXDone()
        {


            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            //gerald             string sqlquery = "Select emp.prod_id as ID, emp.p_feed_code as Emp_Number, emp.p_bags as Department,emp.p_nobatch as TotalPack,emp.proddate as Production_Date, emp.repacking_status as repack_status from rdf_production_advance emp WHERE emp.proddate ='" + txtdateplusone.Text + "' OR emp.proddate ='"+dtpreceivingdate.Text+"' OR emp.proddate ='"+ txtdateminus1.Text+"' AND emp.is_selected=1 AND emp.repacking_status='ready' AND NOT emp.canceltheapprove IS NOT NULL";

        

                string sqlquery = "Select emp.prod_id as PRODUCTION_ID,emp.p_feed_code,emp.p_bags as BAGS,emp.is_active,emp.canceltheapprove,emp.BMX_Status as STATUS,emp.start_of_basemixed as START,emp.microbasemixed_ending as FINISHED,emp.basemixed_time as TIMESTAMP  from [dbo].[rdf_production_advance] emp WHERE CAST(emp.proddate as date) BETWEEN '" + dtpFilter.Text + "' AND '"+dtpTo.Text+"' AND NOT emp.canceltheapprove IS NOT NULL AND NOT emp.iscancelreason IS NOT NULL AND emp.iscancel IS NULL AND emp.BMX_Status IS NOT NULL";
                sql_con.Open();
                SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
                SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
                DataTable dt = new DataTable();
                sdr.Fill(dt);
                dgvProdToday3.DataSource = dt;
                lbltotalbasemixed.Text = dgvProdToday3.RowCount.ToString();



                sql_con.Close();





        }

        void CallBMXDonePerformanceOntime()
        {


            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            //gerald             string sqlquery = "Select emp.prod_id as ID, emp.p_feed_code as Emp_Number, emp.p_bags as Department,emp.p_nobatch as TotalPack,emp.proddate as Production_Date, emp.repacking_status as repack_status from rdf_production_advance emp WHERE emp.proddate ='" + txtdateplusone.Text + "' OR emp.proddate ='"+dtpreceivingdate.Text+"' OR emp.proddate ='"+ txtdateminus1.Text+"' AND emp.is_selected=1 AND emp.repacking_status='ready' AND NOT emp.canceltheapprove IS NOT NULL";



            //string sqlquery = "Select emp.prod_id as PRODUCTION_ID,emp.p_feed_code,emp.p_bags as BAGS,emp.is_active,emp.canceltheapprove,emp.BMX_Status as STATUS,emp.start_of_basemixed as START,emp.microbasemixed_ending as FINISHED,emp.basemixed_time as TIMESTAMP  from [dbo].[rdf_production_advance] emp WHERE CAST(emp.finish_production_date as date) BETWEEN '" + dtpFilter.Text + "' AND '" + dtpTo.Text + "' AND NOT emp.canceltheapprove IS NOT NULL AND NOT emp.iscancelreason IS NOT NULL AND emp.iscancel IS NULL AND emp.BMX_Status IS NOT NULL AND emp.is_selected='1' AND emp.is_active='1' ";

            string sqlquery = "Select emp.prod_id as PROD_ID,emp.proddate as PROD_PLAN, emp.p_feed_code as FEEDCODE,emp.p_bags as BAGS,emp.is_active,emp.canceltheapprove,emp.is_selected as STATUS, emp.approved_date as PLANNING, emp.preparation_date_finish as MICRO,emp.macro_prep_status_date as MACRO, emp.BMX_finish_date as BASEDMIXED, emp.finish_production_date as PRODUCTION, emp.fg_date_finish as FG, empe.days_to_production as DAY,emp.finish_production_date as prodactual from [dbo].[rdf_production_advance] emp LEFT JOIN [dbo].[rdf_finish_goods] empe ON emp.prod_id=empe.fg_prod_id WHERE CAST(emp.finish_production_date as date) BETWEEN '" + dtpFilter.Text + "' AND '" + dtpTo.Text + "' AND NOT emp.canceltheapprove IS NOT NULL AND NOT emp.iscancelreason IS NOT NULL AND emp.iscancel IS NULL AND emp.is_selected='1' AND emp.is_active='1' AND NOT emp.proddate = emp.finish_production_date";


            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvProdToday3.DataSource = dt;
            lbltotalbasemixed.Text = dgvProdToday3.RowCount.ToString();



            sql_con.Close();





        }

        void CallBMXDonePerformancePending()
        {


            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            //gerald             string sqlquery = "Select emp.prod_id as ID, emp.p_feed_code as Emp_Number, emp.p_bags as Department,emp.p_nobatch as TotalPack,emp.proddate as Production_Date, emp.repacking_status as repack_status from rdf_production_advance emp WHERE emp.proddate ='" + txtdateplusone.Text + "' OR emp.proddate ='"+dtpreceivingdate.Text+"' OR emp.proddate ='"+ txtdateminus1.Text+"' AND emp.is_selected=1 AND emp.repacking_status='ready' AND NOT emp.canceltheapprove IS NOT NULL";



            string sqlquery = "Select emp.prod_id as PRODUCTION_ID,emp.p_feed_code,emp.p_bags as BAGS,emp.is_active,emp.canceltheapprove,emp.BMX_Status as STATUS,emp.start_of_basemixed as START,emp.microbasemixed_ending as FINISHED,emp.basemixed_time as TIMESTAMP  from [dbo].[rdf_production_advance] emp WHERE NOT emp.canceltheapprove IS NOT NULL AND NOT emp.iscancelreason IS NOT NULL AND emp.iscancel IS NULL AND emp.BMX_Status IS NOT NULL  AND NOT emp.finish_production_date IS NULL AND emp.is_selected='1' AND emp.is_active='1'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvProdToday3.DataSource = dt;
            lbltotalbasemixed.Text = dgvProdToday3.RowCount.ToString();



            sql_con.Close();





        }



        void CallProductionDone()
        {

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            //gerald             string sqlquery = "Select emp.prod_id as ID, emp.p_feed_code as Emp_Number, emp.p_bags as Department,emp.p_nobatch as TotalPack,emp.proddate as Production_Date, emp.repacking_status as repack_status from rdf_production_advance emp WHERE emp.proddate ='" + txtdateplusone.Text + "' OR emp.proddate ='"+dtpreceivingdate.Text+"' OR emp.proddate ='"+ txtdateminus1.Text+"' AND emp.is_selected=1 AND emp.repacking_status='ready' AND NOT emp.canceltheapprove IS NOT NULL";

   
                string sqlquery = "Select emp.prod_id as PRODUCTION_ID,emp.p_feed_code,emp.p_bags as BAGS,emp.is_active,emp.canceltheapprove,emp.BMX_Status as STATUS,emp.start_of_basemixed as START,emp.microbasemixed_ending as FINISHED,emp.basemixed_time as TIMESTAMP  from [dbo].[rdf_production_advance] emp WHERE CAST(emp.proddate as date) BETWEEN '" + dtpFilter.Text + "' AND '"+dtpTo.Text+"' AND NOT emp.canceltheapprove IS NOT NULL AND NOT emp.iscancelreason IS NOT NULL AND emp.iscancel IS NULL AND emp.finish_production_date IS NOT NULL";
                sql_con.Open();
                SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
                SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
                DataTable dt = new DataTable();
                sdr.Fill(dt);
                dgvProdToday4.DataSource = dt;
                lbltotalproductions.Text = dgvProdToday4.RowCount.ToString();



                sql_con.Close();



        }


        void CallProductionDonePerformanceOntime()
        {

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            //gerald             string sqlquery = "Select emp.prod_id as ID, emp.p_feed_code as Emp_Number, emp.p_bags as Department,emp.p_nobatch as TotalPack,emp.proddate as Production_Date, emp.repacking_status as repack_status from rdf_production_advance emp WHERE emp.proddate ='" + txtdateplusone.Text + "' OR emp.proddate ='"+dtpreceivingdate.Text+"' OR emp.proddate ='"+ txtdateminus1.Text+"' AND emp.is_selected=1 AND emp.repacking_status='ready' AND NOT emp.canceltheapprove IS NOT NULL";


            string sqlquery = "Select emp.prod_id as PRODUCTION_ID,emp.p_feed_code,emp.p_bags as BAGS,emp.is_active,emp.canceltheapprove,emp.BMX_Status as STATUS,emp.start_of_basemixed as START,emp.microbasemixed_ending as FINISHED,emp.basemixed_time as TIMESTAMP  from [dbo].[rdf_production_advance] emp WHERE CAST(emp.finish_production_date as date) BETWEEN '" + dtpFilter.Text + "' AND '" + dtpTo.Text + "' AND NOT emp.canceltheapprove IS NOT NULL AND NOT emp.iscancelreason IS NOT NULL AND emp.iscancel IS NULL AND emp.finish_production_date IS NOT NULL AND emp.is_selected='1' AND emp.is_active='1'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvProdToday4.DataSource = dt;
            lbltotalproductions.Text = dgvProdToday4.RowCount.ToString();



            sql_con.Close();



        }


        void CallProductionDonePerformancePending()
        {

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            //gerald             string sqlquery = "Select emp.prod_id as ID, emp.p_feed_code as Emp_Number, emp.p_bags as Department,emp.p_nobatch as TotalPack,emp.proddate as Production_Date, emp.repacking_status as repack_status from rdf_production_advance emp WHERE emp.proddate ='" + txtdateplusone.Text + "' OR emp.proddate ='"+dtpreceivingdate.Text+"' OR emp.proddate ='"+ txtdateminus1.Text+"' AND emp.is_selected=1 AND emp.repacking_status='ready' AND NOT emp.canceltheapprove IS NOT NULL";


            string sqlquery = "Select emp.prod_id as PRODUCTION_ID,emp.p_feed_code,emp.p_bags as BAGS,emp.is_active,emp.canceltheapprove,emp.BMX_Status as STATUS,emp.start_of_basemixed as START,emp.microbasemixed_ending as FINISHED,emp.basemixed_time as TIMESTAMP  from [dbo].[rdf_production_advance] emp WHERE NOT emp.canceltheapprove IS NOT NULL AND NOT emp.iscancelreason IS NOT NULL AND emp.iscancel IS NULL AND emp.finish_production_date IS NOT NULL  AND finish_production_date IS NULL AND emp.is_selected='1' AND emp.is_active='1'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvProdToday4.DataSource = dt;
            lbltotalproductions.Text = dgvProdToday4.RowCount.ToString();



            sql_con.Close();



        }


        void CallFG()
        {

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            //gerald             string sqlquery = "Select emp.prod_id as ID, emp.p_feed_code as Emp_Number, emp.p_bags as Department,emp.p_nobatch as TotalPack,emp.proddate as Production_Date, emp.repacking_status as repack_status from rdf_production_advance emp WHERE emp.proddate ='" + txtdateplusone.Text + "' OR emp.proddate ='"+dtpreceivingdate.Text+"' OR emp.proddate ='"+ txtdateminus1.Text+"' AND emp.is_selected=1 AND emp.repacking_status='ready' AND NOT emp.canceltheapprove IS NOT NULL";

        

                string sqlquery = "Select emp.prod_id as PRODUCTION_ID,emp.p_feed_code,emp.p_bags as BAGS,emp.is_active,emp.canceltheapprove,emp.BMX_Status as STATUS,emp.start_of_basemixed as START,emp.microbasemixed_ending as FINISHED,emp.basemixed_time as TIMESTAMP  from [dbo].[rdf_production_advance] emp WHERE CAST(emp.proddate as date) BETWEEN '" + dtpFilter.Text + "' AND '"+dtpTo.Text+"' AND NOT emp.canceltheapprove IS NOT NULL AND NOT emp.iscancelreason IS NOT NULL AND emp.iscancel IS NULL AND emp.fg_date_finish IS NOT NULL";
                sql_con.Open();
                SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
                SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
                DataTable dt = new DataTable();
                sdr.Fill(dt);
                dgvFG.DataSource = dt;
                lbltotalfg.Text = dgvFG.RowCount.ToString();



                sql_con.Close();



        }


        void CallFGPerformanceOntime()
        {

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);




            string sqlquery = "Select emp.prod_id as PRODUCTION_ID,emp.p_feed_code,emp.p_bags as BAGS,emp.is_active,emp.canceltheapprove,emp.BMX_Status as STATUS,emp.start_of_basemixed as START,emp.microbasemixed_ending as FINISHED,emp.basemixed_time as TIMESTAMP  from [dbo].[rdf_production_advance] emp WHERE CAST(emp.finish_production_date as date) BETWEEN '" + dtpFilter.Text + "' AND '" + dtpTo.Text + "' AND NOT emp.canceltheapprove IS NOT NULL AND NOT emp.iscancelreason IS NOT NULL AND emp.iscancel IS NULL AND emp.fg_date_finish IS NOT NULL AND emp.is_selected='1' AND emp.is_active='1'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvFG.DataSource = dt;
            lbltotalfg.Text = dgvFG.RowCount.ToString();



            sql_con.Close();



        }


        void CallFGPerformancePending()
        {

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);





            string sqlquery = "Select emp.prod_id as PRODUCTION_ID,emp.p_feed_code,emp.p_bags as BAGS,emp.is_active,emp.canceltheapprove,emp.BMX_Status as STATUS,emp.start_of_basemixed as START,emp.microbasemixed_ending as FINISHED,emp.basemixed_time as TIMESTAMP  from [dbo].[rdf_production_advance] emp WHERE NOT emp.canceltheapprove IS NOT NULL AND NOT emp.iscancelreason IS NOT NULL AND emp.iscancel IS NULL AND emp.fg_date_finish IS NOT NULL AND emp.finish_production_date IS NULL AND emp.is_selected='1' AND emp.is_active='1'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvFG.DataSource = dt;
            lbltotalfg.Text = dgvFG.RowCount.ToString();



            sql_con.Close();



        }

        void ProductionViewBackend()
        {


    

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "Select emp.prod_id as PRODUCTION_ID,emp.p_feed_code as FEEDCODE,emp.p_bags as BAGS,emp.is_active,emp.canceltheapprove,emp.finish_production_by as CREATED_BY,emp.start_of_production as START,emp.end_of_production as FINISHED,emp.production_time as DURATION  from [dbo].[rdf_production_advance] emp WHERE CAST(emp.proddate as date) BETWEEN '" + dtpFilter.Text + "' AND '"+dtpTo.Text+"' AND NOT emp.canceltheapprove IS NOT NULL AND NOT emp.iscancelreason IS NOT NULL AND emp.iscancel IS NULL AND emp.is_selected='1'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvProductionSchedules.DataSource = dt;

            lblmytotal.Text = dgvProductionSchedules.RowCount.ToString();


            sql_con.Close();



        }

        public void FinishedGoodsViewingQuery()
        {




            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "Select emp.prod_id as ID,emp.p_feed_code as FEEDCODE,emp.p_bags as BAGS,emp.is_active,emp.bagorbin as SACK_BIN, emp.canceltheapprove,a.bags_total as BAGGING,a.bulkentry_total as BIN,emp.total_good_count + a.bulkentry_total as GOOD,emp.total_reprocess_count as REPROCESS, emp.total_reject_count as REJECT,emp.fg_by as CREATED_BY, emp.start_fg_processs as START,emp.end_fg_processs as FINISHED,emp.fg_time as DURATION  from [dbo].[rdf_production_advance] emp LEFT JOIN rdf_finish_goods a ON emp.prod_id=a.fg_prod_id WHERE CAST(emp.proddate as date) BETWEEN '" + dtpFilter.Text + "' AND '"+dtpTo.Text+"' AND NOT emp.canceltheapprove IS NOT NULL AND NOT emp.iscancelreason IS NOT NULL AND emp.iscancel IS NULL AND emp.is_selected='1'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvProductionSchedules.DataSource = dt;

            lblmytotal.Text = dgvProductionSchedules.RowCount.ToString();


            sql_con.Close();



        }



        void SumdaTimeStamp()
        {

            ////dgvImport[6, dgvImport.Rows.Count - 1].Value = "Total";
            ////dgvImport.Rows[dgvImport.Rows.Count - 1].Cells[0].Style.BackColor = Color.Green;
            ////dgvImport.Rows[dgvImport.Rows.Count - 1].Cells[0].Style.ForeColor = Color.Red;
            //decimal tot = 0;

            //for (int i = 0; i < dgvProdToday.RowCount - 1; i++)
            //{
            //    var value = dgvProdToday.Rows[i].Cells["MicroStart"].Value;
            //    if (value != DBNull.Value)
            //        //{
            //        //    tot += Convert.ToDecimal(value);
            //        TimeSpan difference = value - value;
            //    }
            //}
            //if (tot == 0)
            //{

            //}
            ////dgvImport.Rows[dgvImport.Rows.Count - 1].Cells["quantity2"].Value = tot.ToString();

            ////lblCounts.Text = dgvImport.RowCount.ToString();
            //lbltotaltimeStamp.Text = tot.ToString();

            //TimeSpan sum;
            //TimeSpan total = DateTime.Parse("00:00:00");

            //for (int i = 0; i < dgvProdToday.Rows.Count; ++i)
            //{
            //    string time = Convert.ToString(dgvProdToday.Rows[i].Cells[5].Value);
            //    sum = TimeSpan.Parse(time);
            //    total = total.Add(sum);
            //}


            //lbltotaltimeStamp.Text = total.ToString();
        }






        void MacroOut()
        {

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "Select emp.p_feed_code,emp.p_bags,emp.start_micro_repacking from rdf_production_advance emp WHERE emp.is_selected='1' AND emp.is_active=1 AND emp.canceltheapprove IS NULL AND CAST(emp.proddate as date) BETWEEN '" + dtpFilter.Text + "' AND '"+dtpTo.Text+"' AND emp.end_macro_repacking IS NULL";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvProdToday3.DataSource = dt;
            lblnotdonemacro2.Text = dgvProdToday3.RowCount.ToString();



            sql_con.Close();
        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void dgvProdToday_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {

            ////var grid = sender as DataGridView;
            ////var rowIdx = (e.RowIndex + 1).ToString();

            ////var centerFormat = new StringFormat()
            ////{
            ////    // right alignment might actually make more sense for numbers
            ////    Alignment = StringAlignment.Center,
            ////    LineAlignment = StringAlignment.Center
            ////};

            ////var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            ////e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);









        }

        private void cmdFedoraModules_TextChanged(object sender, EventArgs e)
        {



            //////if (cmdFedoraModules.Text == "Micro & Macro Repacking")
            //////{
            //////    MicroandMacroRepacking();
            //////}
            //////else
            //////{


            //////}

        }

        private void cmdFedoraModules_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmdFedoraModules_SelectedValueChanged(object sender, EventArgs e)
        {
        
            dgvProductionSchedules.Visible = true;
            dgvPP.Visible = false;
            dgvWIP.Visible = false;

            dtpFilter.Visible = true;
            dtpTo.Visible = true;
            label10.Visible = true;
            label9.Visible = true;

            if (cmdFedoraModules.Text == "Micro & Macro Repacking")
            {
                dgvProductionSchedules.Visible = true;
                dgvPP.Visible = false;
                dgvWIP.Visible = false;

                MicroandMacroRepacking();
                lblsumofgood.Visible = false;


            }
            else if (cmdFedoraModules.Text == "Production Planner")
            {
                dgvProductionSchedules.Visible = true;
                dgvPP.Visible = false;
                dgvWIP.Visible = false;

                ProductionPlanner();
                lbltitle.Visible = false;
                lblsumofgood.Visible = false;
            }
            else if (cmdFedoraModules.Text == "Micro Basemixed")
            {
                dgvProductionSchedules.Visible = true;
                dgvPP.Visible = false;
                dgvWIP.Visible = false;

                BasemixedModule();
                lbltitle.Visible = false;
                lblsumofgood.Visible = false;
            }
            else if (cmdFedoraModules.Text == "Production")
            {
                dgvProductionSchedules.Visible = true;
                dgvPP.Visible = false;
                dgvWIP.Visible = false;

                Production();
                lbltitle.Visible = false;
                lblsumofgood.Visible = false;
            }
            else if (cmdFedoraModules.Text == "Finished Goods")
            {
                dgvProductionSchedules.Visible = true;
                dgvPP.Visible = false;
                dgvWIP.Visible = false;

                FinishedGoodsMode();
                lbltitle.Visible = false;
                //lblsumofgood.Visible = true;
            }
            else if (cmdFedoraModules.Text == "Overall Reports")
            {
                dgvProductionSchedules.Visible = true;
                dgvPP.Visible = false;
                dgvWIP.Visible = false;


                OverAllReports();
                lbltitle.Visible = false;
                lblsumofgood.Visible = false;
                label11.Visible = false;
                lblmicro.Visible = false;
            }
            else if (cmdFedoraModules.Text == "Overall Reports From and To")
            {
                //OverAllReports();
                dgvProductionSchedules.Visible = true;
                dgvPP.Visible = false;
                dgvWIP.Visible = false;

                OverAllReportsFromTo();
                lbltitle.Visible = false;
                lblsumofgood.Visible = false;
            }
            else if (cmdFedoraModules.Text == "Production Performance")
            {
                dgvProductionSchedules.Visible = false;
                dgvPP.Visible = true;
                dgvWIP.Visible = false;


                //OverAllReports();
                lblmicro.Visible = false;
                lblmacro.Visible = false;
                OverAllReportsFromTo();
                lbltitle.Visible = false;
                lblsumofgood.Visible = false;
            }
            else if (cmdFedoraModules.Text == "Work in Progress")
            {
                //OverAllReports();
                dgvProductionSchedules.Visible = false;
                dgvPP.Visible = false;
                dgvWIP.Visible = true;


                OverAllReportsFromToPending();
                lbltitle.Visible = false;
                lblsumofgood.Visible = false;

                //

                dtpFilter.Visible = false;
                dtpTo.Visible = false;
                label10.Visible = false;
                label9.Visible = false;
            }


            else
            {


            }
            dgvProductionSchedules.Refresh();

        }

        private void dgvProductionSchedules_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Exit ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {

                return;
            }
        }

        private void lblsumofgood_Click(object sender, EventArgs e)
        {

        }

        private void lblpers2_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            if (cmdFedoraModules.Text == "Micro & Macro Repacking")
            {
                MicroandMacroRepacking();
                lblsumofgood.Visible = false;


            }
            else if (cmdFedoraModules.Text == "Production Planner")
            {
                ProductionPlanner();
                lbltitle.Visible = false;
                lblsumofgood.Visible = false;
            }
            else if (cmdFedoraModules.Text == "Micro Basemixed")
            {

                BasemixedModule();
                lbltitle.Visible = false;
                lblsumofgood.Visible = false;
            }
            else if (cmdFedoraModules.Text == "Production")
            {

                Production();
                lbltitle.Visible = false;
                lblsumofgood.Visible = false;
            }
            else if (cmdFedoraModules.Text == "Finished Goods")
            {

                FinishedGoodsMode();
                lbltitle.Visible = false;
                //lblsumofgood.Visible = true;
            }
            else if (cmdFedoraModules.Text == "Overall Reports")
            {
                OverAllReports();
                lbltitle.Visible = false;
                lblsumofgood.Visible = false;
            }
            else if (cmdFedoraModules.Text == "Production Performance")
            {
                //OverAllReports();

                dtpTo.Visible = true;
                OverAllReportsFromTo();
                lbltitle.Visible = false;
                lblsumofgood.Visible = false;
            }
            else if (cmdFedoraModules.Text == "Work in Progress")
            {
                //OverAllReports();

                OverAllReportsFromToPending();
                lbltitle.Visible = false;
                lblsumofgood.Visible = false;
            }
            else
            {


            }





        }

        private void dgvProductionSchedules_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            //if (cmdFedoraModules.Text == "Production Performance")
            //{


            //    foreach (DataGridViewRow row in dgvProductionSchedules.Rows)
                
            //        if (row.Cells["PROD_PLAN"].Value) == (row.Cells["10/29/2020"].Value)
            //        {
            //            //row.Cells["buffer_of_stocks"].Style.BackColor = Color.LightGreen;
            //            row.Cells["PROD_PLAN"].Style.BackColor = Color.LightSalmon;
            //            row.Cells["prodactual"].Style.BackColor = Color.LightSalmon;
            //        }
            //        else
            //        {
            //            //row.Cells["PROD_PLAN"].Style.BackColor = Color.LightSalmon;
            //            //row.Cells["prodactual"].Style.BackColor = Color.LightSalmon;
            //        }
            //        //else if (Convert.ToInt32(row.Cells["PROD_PLAN"].Value) < Convert.ToDouble(row.Cells["fg_finish_production"].Value))
            //        //{
            //        //    // row.DefaultCellStyle.BackColor = Color.LightSalmon; // Use it in order to colorize all cells of the row

            //        //    //row.Cells["buffer_of_stocks"].Style.BackColor = Color.LightSalmon;
            //        //}
            //    }

            //}





        }
    }
}
