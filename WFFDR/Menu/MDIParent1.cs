using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using System.Diagnostics;
using Tulpep.NotificationWindow;
using WFFDR.Reports;
using WFFDR.Finished_Goods;
using WFFDR.Set_UP;
using WFFDR.Admin;
using WFFDR.Production;

namespace WFFDR
{
    public partial class MDIParent1 : Form
    {
        private int childFormNumber = 0;

        String connetionString = @"Server=localhost\SQLEXPRESS;Initial Catalog=hr_bak;Integrated Security=SSPI";

        //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
        SqlConnection sql_con = new SqlConnection();
        SqlDataAdapter sql_da = new SqlDataAdapter();
        SqlCommand sql_cmd = new SqlCommand();
        DataTable dt = new DataTable();
  

        myclasses xClass = new myclasses();
        IStoredProcedures objStorProc = null;


        ReportDocument rpt = new ReportDocument();
        string Rpt_Path = "";

        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();
        DataSet dSet_temp = new DataSet();
        DataSet dset_delete = new DataSet();

        frmMicroProfile microviews;
        DataSet dSet = new DataSet();
        DataSet dset_rights = new DataSet();

        //forms INSIDE
        //frmProductionLevel NewUser;


        //Boolean is_clicked = false;
        //int delete_id = 0;

        //int rowcount = 0;
        int rights_id = 0;
        //int emp_flag = 0;

        bool re = false;
        //int countdown;

        public MDIParent1()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

            //SaveFileDialog saveFileDialog = new SaveFileDialog();
            //saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            //saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            //if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            //{
            //    string FileName = saveFileDialog.FileName;
            //}
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {

            metroButton1_Click(sender, e);
            // this.Close();

            //DialogResult dialogResult = MessageBox.Show("Are You Sure That you want to Exit the Application", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            //if (dialogResult == DialogResult.Yes)
            //{
            //    //   Application.Exit();
            //    this.Close();

            //    Form1 una = new Form1();
            //    una.ShowDialog();

            //}
            //else if (dialogResult == DialogResult.No)
            //{

            //}

        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        void PermanentHide()
        {

        }
        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
         

            frmmicroreceivingentry ChildForm = new frmmicroreceivingentry();
            ChildForm.MdiParent = this;
            ChildForm.Show();
            PermanentHide();
            lblactivemodule.Text = "MICRO RECEIVING";
            lblrecords.Text = "Empty Stringj";

        }

        private void MDIParent1_Load(object sender, EventArgs e)
        {
           
            statusStrip.Visible = false;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
         

            //FormBorderStyle = FormBorderStyle.None;
            //TopMost = true;
            //WindowState = FormWindowState.Maximized;
            Rpt_Path = WFFDR.Properties.Settings.Default.fdg;


            // dgv_table DataGridViewer = new dgv_table();

            //dgv_table.Height = this.Height - 312;
            //dgv_table.Width = this.Width - 340;
            //dgv_table.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            //picturebox round
            //System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            //gp.AddEllipse(0, 0, pictureBox1.Width - 3, pictureBox1.Height - 3);
            //Region rg = new Region(gp);
            //pictureBox1.Region = rg;
            //timer1.Start();

            //timer1_Tick(sender, e);


            // Calling the Stored PROC 
            objStorProc = xClass.g_objStoredProc.GetCollections();


            //forms
            microviews = new frmMicroProfile();

            toolStripStatusLabel9.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt");
            // Date NOW with Timer Tools
            lblTime.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt");

            lblactivemodule.Text = "HOME";
            rights_id = userinfo.user_rights_id;

            //ControlBox = true;
            HIDE();

            lblTip.Text = userinfo.emp_name.ToUpper();
            lblTip2.Text = userinfo.emp_name.ToUpper();
            lbluserid.Text = userinfo.user_id.ToString();



           
     lbluserrightsid.Text = userinfo.user_rights_id.ToString();
            //txtActive.Text = userinfo.emp_name.ToUpper();

            //rights here
            rights_id = userinfo.user_rights_id;

            dset_rights.Clear();
            dset_rights = objStorProc.sp_getFilterTables("get_accessible_menu", "", rights_id);

            if (dset_rights.Tables.Count > 0)
            {
                for (int x = 0; x < dset_rights.Tables[0].Rows.Count; x++)
                {
                    string form_name = dset_rights.Tables[0].Rows[x][1].ToString();

                    if (form_name == "frmAttendanceMonitoring")
                    {
                        //p_attendance.Enabled = true;
                        //mnu_rpt_attendance.Enabled = true;
                    }

                    else if (form_name == "frmUserRights")
                    {
                        Userights1.Visible = true;
                    }
                    else if (form_name == "frmLeaveOptions")
                    {
                        //mnu_rpt_attendance.Enabled = true;
                    }

                    else if (form_name == "frmEmployeeList")
                    {
                        //employeeListToolStripMenuItem.Enabled = true;
                    }
                    else if (form_name == "frmSeperatedEmployees")
                    {
                        //mnuSeperated.Enabled = true;
                    }
                    else if (form_name == "Ros")
                    {
                        //  button1.Enabled = true;
                    }
                    else if (form_name == "ToolStripReceiving")
                    {
                        //  button1.Enabled = true;
                        ToolReceiving1.Visible = true;
                    }
                    else if (form_name == "ToolStripInventory")
                    {
                        //  button1.Enabled = true;
                        toolStripInventory1.Visible = true;
                    }
                    else if (form_name == "ToolStripRepacking")
                    {
                        //  button1.Enabled = true;
                        toolRepacking1.Visible = true; ;
                    }
                    else if (form_name == "ToolStripReports")
                    {
                        //  button1.Enabled = true;
                        toolReports1.Visible = true;
                    }
                    else if (form_name == "ToolStripProductionPlanning")
                    {
                        //  button1.Enabled = true;
                        toolProdPlanning1.Visible = true;
                    }
                    else if (form_name == "ToolStripPreparation")
                    {
                        //  button1.Enabled = true;
                        toolStripPreparation1.Visible = true;
                    }
                    else if (form_name == "ToolStripMicroMixing")
                    {
                        //  button1.Enabled = true;
                        toolStripMicroMixing1.Visible = true;
                    }
                    else if (form_name == "ToolStripProduction")
                    {

                        toolStripProduction1.Visible = true;
                    }
                    else if (form_name == "ToolStripFinishGoods")
                    {

                        toolStripFinishGoods1.Visible = true;
                    }
                    else if (form_name == "frmProductionSchedule")
                    {

                        toolStripProductionSchedule1.Enabled = true;

                    }
                    else if (form_name == "frmFormulationApproval")
                    {

                        toolStripProductionApproval1.Enabled = true;

                    }
                    else if (form_name == "frmFormulationManagement")
                    {

                        formulationManagementToolStripMenuItem1.Enabled = true;

                    }
                    else if (form_name == "frmFormula")
                    {

                        formulationTableToolStripMenuItem911.Enabled = true;

                    }
                    else if (form_name == "frmuserrights")
                    {

                        toolStripManageRights1.Enabled = true;

                    }
                    else if (form_name == "frmFormsAvailable")
                    {

                        toolStripFormsAvailable1.Enabled = true;

                    }
                    else if (form_name == "frmuser")
                    {

                        toolStripUserManagement1.Enabled = true;

                    }
                    else if (form_name == "frmmicroreceivingentry")
                    {

                        toolStripMicroReceiving1.Enabled = true;

                    }
                    else if (form_name == "frmMacroInventory")
                    {

                        toolStripMacroInventory1.Enabled = true;

                    }
                    else if (form_name == "frmMicroInventory")
                    {

                        toolStripMicroInventory1.Enabled = true;

                    }
                    else if (form_name == "frmfullDepreciationReceiving")
                    {

                        fullDepreciationRepackingToolStripMenuItem1.Enabled = true;

                    }
                    else if (form_name == "frmListofApproveRepacking")
                    {

                        toolStripRepacking1.Enabled = true;

                    }
                    else if (form_name == "frmGenerateRepackingBarcodeID")
                    {

                        toolStripPrintRepackingEntry1.Enabled = true;

                    }
                    else if (form_name == "ToolStripBarcodeBookList")
                    {

                        toolStripWarehouseBarcodes1.Enabled = true;

                    }
                    //else if (form_name == "ToolStripExceltoFedora")
                    //{

                    //    tootStripExceltoFedora1.Enabled = true;

                    //}
                    else if (form_name == "frmmicrowhpreparation")
                    {

                        toolStripMicroPreparation1.Enabled = true;

                    }
                    else if (form_name == "frmPreparationofMixing")
                    {

                        ToolMicroMixing1.Enabled = true;

                    }
                    else if (form_name == "frmCategory")
                    {

                        itemCategoryToolStripMenuItem1.Enabled = true;

                    }
                    else if (form_name == "frmGroup")
                    {

                        ToolStripGroup.Enabled = true;

                    }
                    else if (form_name == "frmActiveRepackingMonitoring")
                    {

                        activeRepackingMonitoringToolStripMenuItem1.Enabled = true;

                    }
                    else if (form_name == "frmDistinctRepackingRecords")
                    {

                        distinctRepackingRecordsToolStripMenuItem1.Enabled = true;

                    }

                    else if (form_name == "frmMicroMaterialRepackingTracking")
                    {

                        toolMacroRepacking1.Enabled = true;

                    }
                    else if (form_name == "frmMacroMaterialRepackingTracking")
                    {
                        MacroRepackingEntry1.Enabled = true;
                    }

                    else if (form_name == "frmRepackingRpt")
                    {
                        reportinToolStrip1.Enabled = true;
                    }
                    else if (form_name == "frmPrintBasemixedEntry")
                    {
                        ToolStripBaseMixed1.Enabled = true;
                    }

                    else if (form_name == "MDIParent1")
                    {
                        toolStripMacroReceiving1.Enabled = true;
                    }


                    else if (form_name == "frmwhmacropreparation")
                    {
                        toolStripMacroPreparation1.Enabled = true;
                    }
                    else if (form_name == "frmListofMacroRepacking")
                    {
                        toolStripMenuItem111.Enabled = true;
                    }
                    //else if (form_name == "MDIParent1Main")
                    //{
                    //    productionPlanningToolStripMenuItem1.Enabled = true;
                    //} 10/28/2020
                    else if (form_name == "MDIParent2")
                    {
                        inventoryToolStripMenuItem1.Enabled = true;
                    }
                    else if (form_name == "frmFinishGoods")
                    {
                        toolGoodsMonitoring.Enabled = true;

                    }
                    else if (form_name == "frmProductionEntry")
                    {
                        toolProdProcesss.Enabled = true;
                    }
                    else if (form_name == "frmFGMaterialTracking")
                    {
                        toolFGmaterialTracking.Enabled = true;
                    }
                    else if (form_name == "frmApproveQAMacro")
                    {
                        toolStripMenuItem9.Enabled = true;
                    }
                    else if (form_name == "frmApproveQA")
                    {
                        toolStripMenuItem17.Enabled = true;
                    }
                    else if (form_name == "ToolStripBarcodeReceipt")
                    {
                        barcodeReceiptToolStripMenuItem.Enabled = true;
                    }
                    else if (form_name == "ToolStripInternalReports")
                    {
                        internalReportsToolStripMenuItem.Enabled = true;
                    }
                    else if (form_name == "toolStripImport")
                    {

                        toolStripSplitButton1.Visible = true;
                    }

                    else if (form_name == "frmproductionrepackchart")
                    {
                        repackingPieChartToolStripMenuItem.Enabled = true;
                    }

                    else if (form_name == "frmMicroMaterialRepackingTracking")
                    {
                        toolMacroRepacking1.Enabled = true;
                    }
                    else if (form_name == "receivingCrystalreport")
                    {
                        receivingToolStripMenuItem.Enabled = true;
                    }
                    else if (form_name == "frmFGReprocessModule")
                    {
                        ggToolStripMenuItem.Enabled = true;//Reprocess Mo*/dul
                    }
                    else if (form_name == "frmaddUsers")
                    {
                        productionLevelToolStripMenuItem.Enabled = true;
                    }
                    else if (form_name == "totalFGProducedToolStripMenuItem")
                    {
                        totalFGProducedToolStripMenuItem.Enabled = true;
                    }
                    else if (form_name == "microMacroMaterialUsedToolStripMenuItem")
                    {
                        microMacroMaterialUsedToolStripMenuItem.Enabled = true;
                    }
                    else if (form_name == "totalFGDelayedToolStripMenuItem")
                    {
                        totalFGDelayedToolStripMenuItem.Enabled = true;
                    }
                    else if (form_name == "dailyProductionReportsToolStripMenuItem")
                    {
                        dailyProductionReportsToolStripMenuItem.Enabled = true;
                    }
                    else if (form_name == "fGMonitoringToolStripMenuItem")
                    {
                        fGMonitoringToolStripMenuItem.Enabled = true;
                    }
                    else if (form_name == "frmTheoroticalLogSheet")
                    {
                        theoroticalLogsToolStripMenuItem.Enabled = true;
                    }
                    else if (form_name == "reprintMonitoringToolStripMenuItem")
                    {
                        reprintMonitoringToolStripMenuItem.Enabled = true;
                    }
                    else if (form_name == "CrystalReportFile")
                    {

                        efficiencyScheduleOverActualProducedToolStripMenuItem.Enabled = true; // Efficenvy over actual Prod

                    }
                    else if (form_name == "systemUpdateToolStripMenuItem") //Admin System Update
                    {
                        systemUpdateToolStripMenuItem.Enabled = true;
                    }
                    else if (form_name == "printFinishedGoodsEntryToolStripMenuItem") //FG Bagging
                    {
                        printFinishedGoodsEntryToolStripMenuItem.Enabled = true;
                    }
                    else if (form_name == "printFGBulkEntryToolStripMenuItem") //FG Reprinting
                    {
                        printFGBulkEntryToolStripMenuItem.Enabled = true;
                    }
                    else if (form_name == "toolStripMenuItem25") //po sumary
                    {
                        toolStripMenuItem25.Enabled = true;
                    }
                    else if (form_name == "toolStripMenuItem27") // formulation table
                    {
                        toolStripMenuItem27.Enabled = true;
                    }
                    else if (form_name == "toolStripMenuItem28") // raw materials
                    {
                        toolStripMenuItem28.Enabled = true;
                    }
                    else if (form_name == "toolStripMenuItem29") // Supplier
                    {
                        toolStripMenuItem29.Enabled = true;
                    }
                    else if (form_name == "ProductionLevel")
                    {
                        productionLevelToolStripMenuItem.Enabled = true;
                    }
                    else if (form_name == "frmFormulationList")
                    {
                        listOfFormulationToolStripMenuItem.Enabled = true;
                    }
                    else if (form_name == "frmmixingcapacity")
                    {
                        mixingCapacityToolStripMenuItem.Enabled = true;
                    }
                    else if (form_name == "fmProductionHours")
                    {
                        productionHoursToolStripMenuItem.Enabled = true;

                    }
                    else if (form_name == "MaterialReportRepacking")
                    {
                        microMacroMaterialUsedRepackingDateToolStripMenuItem.Enabled = true;
                    }
                    else if (form_name == "SETUP")
                    {
                        tsPSetup.Visible = true;
                    }
                    else if (form_name == "frmviewApproverCancelProd")
                    {
                        tstProdLogs.Enabled = true;
                    }
                    else if (form_name == "frmMaterialUsedOverProductionDate")
                    {
                        tsTProdDateMaterials.Enabled = true;
                    }

                    else if (form_name == "frmFGMainInventory")
                    {
                        fGInventoryToolStripMenuItem.Enabled = true;
                    }
                    else if (form_name == "MoveOrderMenu")
                    {
                        moveOrderToolStripMenuItem.Enabled = true;
                    }
                    else if (form_name == "MoveOrder")
                    {
                        moverOrderToolStripMenuItem.Enabled = true;
                    }

                    else if (form_name == "TransactMoveOrder")
                    {
                        transactMoveOrderToolStripMenuItem.Enabled = true;
                    }


                    //
                    else if (form_name == "MiscellaneousTransaction")
                    {
                        miscellaneousTransactionToolStripMenuItem1.Enabled = true;
                    }


                    else if (form_name == "MiscellaneousTransactionIN")
                    {
                        miscellaneousTransactionReceiptInToolStripMenuItem.Enabled = true;
                    }

                    else if (form_name == "MiscellaneousTransactionOUT")
                    {
                        miscellaneousTransactionIssueOutToolStripMenuItem.Enabled = true;
                    }
                    else if (form_name == "FGReceiving")
                    {
                        fGReceivingToolStripMenuItem.Enabled = true;
                    }

                    else if (form_name == "MixingCombination")
                    {
                        mixingCombinationToolStripMenuItem.Enabled = true;
                    }

                    else if (form_name == "WarehouseManagement")
                    {
                        warehouseManagementToolStripMenuItem.Enabled = true;
                    }


                    else if (form_name == "CustomerManagement")
                    {
                        customerManagementToolStripMenuItem.Enabled = true;
                    }


                    else if (form_name == "frmReprocessAdjustment")
                    {
                        reprocessAdjusmtneToolStripMenuItem.Enabled = true;
                    }

                    else if (form_name == "frmFGReprocessReports")
                    {
                        fGReprocessToolStripMenuItem1.Enabled = true;
                    }

                    else if (form_name == "frmBulkValueMgmt")
                    {
                        bulkEntryManagementToolStripMenuItem.Enabled = true;
                    }


                    else if (form_name == "frmRawMaterialsDataRepack")
                    {

                        rawMateriaslDataToolStripMenuItem.Enabled = true;
                    }
                    else if (form_name == "frmProductionAutomation")
                    {

                        automToolStripMenuItem.Enabled = true;
                    }

                    else if (form_name == "FGMiscellaneousTransactiontoolStripMenuItem30")
                    {
                        FGMiscellaneousTransactiontoolStripMenuItem30.Enabled = true;
                    }
                    else if (form_name == "frmFGReceipt")
                    {
                        toolStripMenuItem32.Enabled = true;
                    }

                    else if (form_name == "ExternalReports")
                    {
                        externalReportsToolStripMenuItem.Enabled = true;
                    }
                    else if (form_name == "MacroReceiving")
                    {
                        toolStripMenuItem83.Enabled = true;
                    }

                    else if (form_name == "FGReceivingReports")
                    {
                        fGReceivingToolStripMenuItem1.Enabled = true;
                    }
                    else if (form_name == "TotalFGProducedFGDate")
                    {
                        toolStripMenuItem84.Enabled = true;
                    }
                    else if (form_name == "FGMiscelaneousIssue")
                    {
                        toolStripMenuItem33.Enabled = true;
                    }

                    else if (form_name == "Printing")
                    {
                        pRINTINGToolStripMenuItem.Enabled = true;
                    }
                    else if (form_name == "TheoScadaReports")
                    {
                        scadaReportBasedOnProductionToolStripMenuItem.Enabled = true;
                    }
                    else if (form_name == "DashBoardMenu")
                    {
                        dashboardToolStripMenuItem.Enabled = true;
                    }
                    else if (form_name == "frmMaterialStatusReports")
                    {
                        generateRawMaterialsStatusToolStripMenuItem.Enabled = true;
                    }
                    else if (form_name == "fGReprocessReports")
                    {
                        fGReprocessReportsToolStripMenuItem.Enabled = true;
                    }
                    else if (form_name == "InventoryMovementReports")
                    {
                        inventoryMovementToolStripMenuItem.Enabled = true;
                    }
                    else if (form_name == "MixingCapacityReports")
                    {
                        mixingCapacityCornTypeToolStripMenuItem.Enabled = true;
                    }

                    else if (form_name == "MonthlyInventoryReports")
                    {
                        monthlyInventoryToolStripMenuItem.Enabled = true;
                    }

                    else if (form_name == "FGMoveOrderReports")
                    {
                        fGInvetToolStripMenuItem.Enabled = true;
                    }

                    else if (form_name == "RawMatsMiscleanousReports")
                    {
                        miscellaneousTransactionToolStripMenuItem2.Enabled = true;
                    }
                    
                    else if(form_name =="RMNearlyExpiry")
                    {
                        rMNearlyExpiredReportToolStripMenuItem.Enabled = true;
                    }
                    else if(form_name =="BufferStockReport")
                    {
                        tSBufferedStocks.Enabled = true;
                    }

                    else if (form_name == "FGTransformationReport")
                    {
                        toolFGTransformation.Enabled = true;
                    }
                    else if(form_name == "InventoryReports")
                    {
                        toolStripMenuItem35.Enabled = true;
                    }
                    else if(form_name =="ProductionPlanningControllerProduction")
                    {
                        productionPlanControllerToolStripMenuItem.Enabled = true;
                    }
                    else if(form_name =="frmScadaMonitoringPerProdPlan")
                    {

                        scadaReportBasedOnProdPlanToolStripMenuItem.Enabled = true;
                    }
                    else if(form_name== "FrmFGMiscellaneousIssueFinance")
                    {

                        fGMiscellaneousIssueFinanceToolStripMenuItem.Enabled = true;
                    }
                    else if(form_name== "fMMiscellaneiousTransactionReportToolStripMenuItem")
                    {
                        fMMiscellaneiousTransactionReportToolStripMenuItem.Enabled = true;
                    }
                    else if (form_name == "plateNumberManagementToolStripMenuItem")
                    {
                        plateNumberManagementToolStripMenuItem.Enabled = true;
                    }
                    else if (form_name == "finishedGoodsReprocessUniversalModuleToolStripMenu")
                    {
                        finishedGoodsReprocessUniversalModuleToolStripMenu.Enabled = true;
                    }
                   

                }

            }
            load_posummary_report();
            //load_posummary_reportmacro();
            load_posummary_report_macro();
            load_fgreceiving();
            myglobal.global_module = "Active";
            load_search();


            if (rights_id == 1 || rights_id == 2 || rights_id == 5)
            {
                //   mnuHolidays.Enabled = true;
                //  sicknessToolStripMenuItem.Enabled = true;

                if (rights_id == 2) // MIS
                {
                    // toolStripButton2.Visible = true;
                    ////bunifuFlatButton1.Enabled = false;  lako kepa ini
                }

                // bunifuFlatButton1.Visible = false;
            }


            WelcomeUser();
            if(lblTip.Text=="MANG TONY")
            {
                if(lblallmaterials.Text=="0")
                {
                    timer2.Stop();
                    return;
                }
                else
                {

                    timer2.Enabled = true;
                    timer2.Start();
                    timer2_Tick(sender, e);
                   
                }


            }

            if(lbluserrightsid.Text=="1034")
            {

                if (lblallmaterials.Text == "0")
                {
                    timer2.Stop();
                    //return;
                }
                else
                {

                    timer2.Enabled = true;
                    timer2.Start();
                    timer2_Tick(sender, e);

                }

            }

          

            txtReceivingStatus.Text = userinfo.receiving_status.ToString();
            if (txtReceivingStatus.Text == "RM On")
            {
               
                Buffer();

                if (lblmacroreceiving.Text == "0")
                {

                    //timer2.Stop();
                    //return;

                }

                else
                {
                   
                    timer2.Enabled = true;
                    timer2.Start();
                    timer2_Tick(sender, e);
                }

                if (lblallmaterials.Text == "0")
                {

                    //timer2.Stop();
                    //return;
                }
                else
                {
                  
                    timer2.Enabled = true;
                    timer2.Start();
                    timer2_Tick(sender, e);

                }

               
              
                



                //}

            }//closing tag RM receiving notifications
            if (txtReceivingStatus.Text == "FG On")
            {


                Buffer();
                if (lblfgreceiving.Text == "0")
                {
                    //timer2.Stop();
                    //return;
                }
                else
                {

                    timer3.Enabled = true;
                    timer3.Start();
                    timer3_Tick(sender, e);

                }

            }
            //Closing of tag FG receiving notifications

            txtmysection.Text = userinfo.user_section.ToString();
            txtmysection.Visible = false;
            if(txtmysection.Text=="Office")
            {
                ControlBox = true;
            }
            else
            {
                ControlBox = false;
            }

            txtReceivingStatus.Visible = false;
     
    


            dateTimePicker1.Visible = false;

           // UserLogs
            dSet.Clear();

            dSet = objStorProc.rdf_sp_new_preparation(0, lbluserid.Text, lblTip2.Text, toolStripStatusLabel9.Text, dateTimePicker2.Text, lbluserrightsid.Text, "", "", "", "", "", "", "", "", "", "", "", "", "userlogs");
            dateTimePicker2.Visible = false;

            load_updates();
            if(lblupdates.Text=="0")
            {

            }
            else
            {
    
              MyBelovedLight.Visible = true;
                WelcomeUpdateCount();
            }

 
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

        void Buffer()
        {
            load_Final_Buffer();
            if (SlowMovingIConCount.Text == "0")
            {
                NearlyExpired.Visible = false;
                SlowMovingIConCount.Visible = false;
                SlowMovingICon.Visible = false;
           
            }
            else
            {
                NearlyExpired.Visible = true;
                //SlowMovingIConCount.Visible = true;
                SlowMovingICon.Visible = true;
          
            }

        }
        public void load_updates()
        {
            string mcolumns = "test,update_id,module,update_remarks,update_objective,update_date,added_by";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgvUnread, mcolumns, "distinctupdatefedora");
           lblupdates.Text = dgvUnread.RowCount.ToString();

        }
        void load_search()
        {

            dset_empi.Clear();



            dset_empi = objStorProc.sp_getMajorTables("MicroReceivingNewer");
            doSearch();

        }

        DataSet dset_empi = new DataSet();
        void doSearch()
        {
            try
            {
                if (dset_empi.Tables.Count > 0)
                {
                    DataView dv = new DataView(dset_empi.Tables[0]);
                    if (myglobal.global_module == "EMPLOYEE")
                    {
                        //dv.RowFilter = "firstname like '%" + txtmainsearch.Text + "%' or lastname like '%" + txtsearch.Text + "%' or employee_number like '%" + txtsearch.Text + "%' or employment_status_name like '%" + txtsearch.Text + "%'";
                    }
                    else if (myglobal.global_module == "Active")
                    {

                        dv.RowFilter = "DateChecklistCreated = '" + dateTimePicker1.Text + "'";

                    }
                    else if (myglobal.global_module == "VISITORS")
                    {
                        //dv.RowFilter = "visitors_lastname like '%" + txtsearch.Text + "%' or visitors_firstname like '%" + txtsearch.Text + "%'";
                    }
                    dataGridView1.DataSource = dv;
              lblnew.Text = dataGridView1.RowCount.ToString();
                    //gerard
                }
            }
            catch (SyntaxErrorException)
            {
                MessageBox.Show("Invalid character found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //txtmainfeedcode.Focus();
                return;
            }
            catch (EvaluateException)
            {
                MessageBox.Show("Invalid character found 2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //txtmainfeedcode.Focus();
                return;
            }

            for (int n = 0; n < (dataGridView1.Rows.Count); n++)
            {
                //double s = Convert.ToDouble(dgvImport.Rows[n].Cells[4].Value);


                //double s1 = Convert.ToDouble(dgvAllFeedCode.Rows[n].Cells[7].Value);

                double s1 = Convert.ToDouble(dataGridView1.Rows[n].Cells[3].Value);

                //int s1 = Convert.ToInt32(dgv1stView.Rows[n].Cells[1].Value);
                //double s13 = s * 2;
                double s15 = s1 * 2;

                //dgvImport.Rows[n].Cells[7].Value = s15.ToString("#,0.000");
                dataGridView1.Rows[n].Cells[3].Value = s15.ToString("#,0.000");


                //dgvAllFeedCode.Rows[n].Cells[4].Value = s13.ToString("#,0.000");
                //dgvAllFeedCode.Rows[n].Cells[7].Value = s15.ToString("#,0.000");
            }
        }
        public void HIDE()
        {

            labelSearch.Visible = false;
  
        }

        public void load_Final_Buffer()
        {
            string mcolumns = "test,item_code,item_description";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgvBufferNotifier, mcolumns, "RawmatsBuffer");
            // Menu.lblrecords.Text = dgv_table.RowCount.ToString();
            SlowMovingIConCount.Text = dgvBufferNotifier.RowCount.ToString();
            //poreceived_header();
        }


        public void load_posummary_report()
        {
            string mcolumns = "test,po_number,item_code,item_description,qty_ordered,Password";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgv_po_approve, mcolumns, "qa_po_receiving");
            // Menu.lblrecords.Text = dgv_table.RowCount.ToString();
            lblallmaterials.Text = dgv_po_approve.RowCount.ToString();
            //poreceived_header();
        }

        public void load_fgreceiving()
        {
            string mcolumns = "test,ProdID,ProdDate,PrintingDate,FeedCode,FeedType";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgvfgreceiving, mcolumns, "fg_receivingnotify");
            // Menu.lblrecords.Text = dgv_table.RowCount.ToString();
            lblfgreceiving.Text = dgvfgreceiving.RowCount.ToString();
            //poreceived_header();
        }

        //public void load_posummary_reportmacro()
        //{
        //    string mcolumns = "test,po_number,item_code,item_description,qty_ordered,Password";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
        //    pointer_module.populateModule(dsetHeader, dgvmacroreceiving, mcolumns, "qa_po_receivingmacro");
        //    // Menu.lblrecords.Text = dgv_table.RowCount.ToString();
        //    lblmacroreceiving.Text = dgvmacroreceiving.RowCount.ToString();
        //    //poreceived_header();
        //}


        public void load_posummary_report_macro()
        {
            string mcolumns = "test,po_number,itcode,itdesc,qty_ordered,Password";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgvmacroreceiving, mcolumns, "qa_po_receivingmacronotify");

            lblmacroreceiving.Text = dgvmacroreceiving.RowCount.ToString();

        }
        void WelcomeUser ()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Welcome to Fedora Automation System!";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Gray;
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

        void WelcomeUpdateCount()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "CLICK THE NOTIFICATIONS BELL TO SEE THE TOTAL " + lblupdates.Text + " SYSTEM UPDATES";
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
        void NotifyFGReceiving()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "YOU HAVE " + lblfgreceiving.Text + " FINISHED GOOD FOR RECEIVING!";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Gray;
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
            //popup.ContentText = "TOTAL QUANTITY OF RAW MATERIALS TO BE RECEIVED IS " + lblallmaterials.Text + " AND THE NEW ITEM " + lblnew.Text + " " + lblTip.Text + " ";

            Buffer();
        }
        void NoofReceivedmacro()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "YOU HAVE " + lblmacroreceiving.Text + " MACRO TRANSACTION!";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Gray;
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
            //popup.ContentText = "TOTAL QUANTITY OF RAW MATERIALS TO BE RECEIVED IS " + lblallmaterials.Text + " AND THE NEW ITEM " + lblnew.Text + " " + lblTip.Text + " ";

            Buffer();
        }
        void NoofReceived()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White; 
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "YOU HAVE "+lblallmaterials.Text+" MICRO TRANSACTION!";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Gray;
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
            //popup.ContentText = "TOTAL QUANTITY OF RAW MATERIALS TO BE RECEIVED IS " + lblallmaterials.Text + " AND THE NEW ITEM " + lblnew.Text + " " + lblTip.Text + " ";

            Buffer();
        }

        private void con_on()
        {
            sql_con = new SqlConnection();
            sql_con.ConnectionString = connetionString;
            sql_con.Open();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel9.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt");
        }

        private void bunifuFlatButtonMicro_Click(object sender, EventArgs e)
        {

        }

    
        DataSet dset_emp = new DataSet();

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
      
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
       
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            frmFormula ChildFormFormula = new frmFormula();
            ChildFormFormula.MdiParent = this;
            ChildFormFormula.Show();
        }

        private void dgv_table_DoubleClick(object sender, EventArgs e)
        {
            if (myglobal.global_module == "RESIGNED EMPLOYEE")
            {
                tsedit_Click(sender, e);
            }
            else if (myglobal.global_module == "MICRO")
            {
                tsedit_Click(sender, e);

            }
            else if (myglobal.global_module == "MACRO")
            {
                tsedit_Click(sender, e);

            }
            else
            {
                //MessageBox.Show(dgv_table.CurrentRow.Cells["department_name"].Value.ToString() + "/n" + dgv_table.CurrentRow.Cells["section_name"].Value.ToString() + "/n" + dgv_table.CurrentRow.Cells["position_name"].Value.ToString());
                tsedit_Click(sender, e);
            }
        }

        private void tsedit_Click(object sender, EventArgs e)
        {
            myglobal.mode = "edit";
            myglobal.updated = false;

            if (myglobal.global_module == "EMPLOYEE")
            {
                //      showEmployee();
                // employee.ShowDialog();

                if (myglobal.updated == true)
                {
                    //           p_employee_Click(sender, e);
                }

                frmMenu sa = new frmMenu();

                //      sa.ActivitiesLogs(userinfo.emp_name + " Search Employee");
            }
            else if (myglobal.global_module == "MICRO")
            {


                showMicroProfile();
                //  frmMicroProfile MicroViews = new frmMicroProfile();
                microviews.ShowDialog();

                if (myglobal.updated == true)
                {
                    //  p_Micros_Click(sender, e);
                }
     
                frmMenu sa = new frmMenu();

                // sa.ActivitiesLogs(userinfo.emp_name + " Search Employee");

            }

            else if (myglobal.global_module == "MACRO")
            {


                showMicroProfile();
                //  frmMicroProfile MicroViews = new frmMicroProfile();
                microviews.ShowDialog();

                if (myglobal.updated == true)
                {
                    //  p_Micros_Click(sender, e);
                }
    
                frmMenu sa = new frmMenu();

                // sa.ActivitiesLogs(userinfo.emp_name + " Search Employee");

            }
            else if (myglobal.global_module == "MICRO INVENxxTORY")
            {
                //   attendance.ShowDialog();

                if (myglobal.updated == true)
                {
                    //   p_attendance_Click(sender, e);
             
                    frmMenu sa = new frmMenu();
                }
            }
            else if (myglobal.global_module == "ATTENDANCE")
            {
                //   attendance.ShowDialog();

                if (myglobal.updated == true)
                {
                    //    p_attendance_Click(sender, e);
                }
            }
            else if (myglobal.global_module == "TARDINESS")
            {
                //    tardiness.ShowDialog();

                if (myglobal.updated == true)
                {
                    //  p_tardiness_Click(sender, e);
                }
            }
            else if (myglobal.global_module == "DA")
            {
                //disciplinary2.ShowDialog();

                //if (myglobal.updated == true)
                //{
                //    p_da_Click(sender, e);
                //}
  

                //        frmDisciplinaryAction frmDisciplinaryAction = new frmDisciplinaryAction();
                //     frmDisciplinaryAction.Show();
                //          frmDisciplinaryAction.LoadEmployeeeDisciplinary(daId);


            }
            else if (myglobal.global_module == "PHONEBOOK")
            {
                //phonebook.ShowDialog();

                if (myglobal.updated == true)
                {
                    //   p_phonebook_Click(sender, e);
                }
            }
            else if (myglobal.global_module == "VISITORS")
            {
                //  visitors.ShowDialog();

                if (myglobal.updated == true)
                {
                    //   p_visitors_Click(sender, e);
                }
            }
            else if (myglobal.global_module == "MANAGER")
            {
                //   employee.ShowDialog();

                if (myglobal.updated == true)
                {
                    //  panel3_Click(sender, e);
                }
            }
            else if (myglobal.global_module == "RESIGNED EMPLOYEE")
            {
                // employee.ShowDialog();
                if (myglobal.updated == true)
                {
                    //       tsResigned_Click(sender, e);
                }
            }

        }

        void showMicroProfile()
        {
          
        }

        private void toolStripMenuDepartment_Click(object sender, EventArgs e)
        {
            frmDepartment dept = new frmDepartment();
            dept.ShowDialog();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            frmSections frmSec = new frmSections();
            frmSec.ShowDialog();
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            frmPositions position = new frmPositions();
            position.ShowDialog();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            frmFeedcode fCode = new frmFeedcode();
            fCode.ShowDialog();
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategory category = new frmCategory();
            category.ShowDialog();
        }

        private void supplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSupplierdf Supplier = new frmSupplierdf();
            Supplier.ShowDialog();
        }

        private void classificationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClassification classification = new frmClassification();
            classification.ShowDialog();
        }

        private void groupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGroup Group = new frmGroup();
            Group.ShowDialog();
        }

        private void productionTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmViewApproverCancelProd ProductionType = new frmViewApproverCancelProd();
            ProductionType.ShowDialog();
        }

        private void toolStripButtonNew_Click(object sender, EventArgs e)
        {
            frmBufferedInventory NewRawMaterial = new frmBufferedInventory();
            NewRawMaterial.ShowDialog();
        }

        private void bunifuFlatButton9_Click(object sender, EventArgs e)
        {
   
            //  frmImportQC importQC = new frmImportQC();
            //importQC.ShowDialog();
            frmImportQC ChildForm = new frmImportQC();
            ChildForm.MdiParent = this;
            ChildForm.Show();
        }

        private void productionScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductionSchedule prod_sched = new frmProductionSchedule();
            prod_sched.ShowDialog();
        }

        private void txtsearch_TextChanged_1(object sender, EventArgs e)
        {
       
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmSystemLock sysLock = new frmSystemLock();
            sysLock.ShowDialog();
        }

        private void bunifuFlatButton12_Click(object sender, EventArgs e)
        {
            bool Isopen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "frmrepackingentry")
                {
                    Isopen = true;
                    f.BringToFront();
                    break;
                }
            }

            if (Isopen == false)

            {
         
                frmrepackingentry ChildPorn = new frmrepackingentry();
                ChildPorn.MdiParent = this;
                ChildPorn.Show();
            }






           
        }

        private void sdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMicroReceivingInfo info = new frmMicroReceivingInfo();
            info.ShowDialog();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {

        }

        private void standardWeightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMacroInventory standardtimbang = new frmMacroInventory();
            standardtimbang.ShowDialog();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            frmGenerateRepackingBarcodeID packingid = new frmGenerateRepackingBarcodeID();
            packingid.ShowDialog();
        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {

          
            //frmMasterlistRepacking masterlist = new frmMasterlistRepacking();
            //masterlist.ShowDialog();
            frmMasterlistRepacking Repackingmaster = new frmMasterlistRepacking();
            Repackingmaster.MdiParent = this;
            Repackingmaster.Show();
          //  panel_title.Visible = false;
        }

        private void bunifuFlatButton13_Click(object sender, EventArgs e)
        {
            frmuserrights rightsofuser = new frmuserrights();
            rightsofuser.ShowDialog();
        }

        private void approveQASummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmApproveQA ApprovePOSummary = new frmApproveQA();
            ApprovePOSummary.ShowDialog();
        }

        private void microReceivingEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTheoScada MicroReceived = new frmTheoScada();
            MicroReceived.MdiParent = this;
            MicroReceived.Show();
  
        }

        private void panel_title_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void prodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReprocessAdjustment proddashboard = new frmReprocessAdjustment();
            proddashboard.ShowDialog();
        }

        private void supplierEvaluationToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmMaterialStatusReports evaluation = new frmMaterialStatusReports();
            evaluation.MdiParent = this;
            evaluation.Show();

        }

        private void bunifuFlatButton11_Click(object sender, EventArgs e)
        {

            frmTheoScada MicroReceived = new frmTheoScada();
            MicroReceived.MdiParent = this;
            MicroReceived.Show();

        }

        private void btnsamplelang_Click(object sender, EventArgs e)
        {
            lblnum2323 prep = new lblnum2323();
       prep.MdiParent = this;
            prep.Show();
     


        }

        private void macroToolStripMenuItem_Click(object sender, EventArgs e)
        {
       
        }

        private void microToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            myglobal.REPORT_NAME = "MicroBook";
            rpt.Load(Rpt_Path + "\\MicroBook.rpt");

                frmReport frmReport = new frmReport();
            frmReport.MdiParent = this;
            frmReport.Show();



        
        }

        private void macroToolStripMenuItem1_Click(object sender, EventArgs e)
        {
 
            myglobal.REPORT_NAME = "MacroBook";
            rpt.Load(Rpt_Path + "\\MacroBook.rpt");

            frmReport frmReport = new frmReport();
            frmReport.MdiParent = this;
            frmReport.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

            //frmPreparationofMixing prep = new frmPreparationofMixing();
        
          
            frmListofApproveRepacking prep = new frmListofApproveRepacking();
            prep.MdiParent = this;
            prep.Show();
            //approvedRepack.ShowDialog();
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            // panel_search.Visible = true;
            labelSearch.Visible = true;
     
            frmmicroreceivingentry microreceiving = new frmmicroreceivingentry();
            microreceiving.Close();
    
            myglobal.global_module = "MACRO";

            lblactivemodule.Text = "MACRO";
     

        }

        private void formulationTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            frmImportFormula ChildForm = new frmImportFormula();
            ChildForm.MdiParent = this;
            ChildForm.Show();
        }

        private void rawMaterialsToolStripMenuItem_Click(object sender, EventArgs e)
        {
   
            frmImportRawMaterials ChildForm = new frmImportRawMaterials();
            ChildForm.MdiParent = this;
            ChildForm.Show();
        }

        private void supplierToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            frmImportSupplier ChildForm = new frmImportSupplier();
            ChildForm.MdiParent = this;
            ChildForm.Show();
        }

        private void formulationManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFormulationManagement ManageFormula = new frmFormulationManagement();
            ManageFormula.ShowDialog();
        }

        private void fgfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string winpath = Environment.GetEnvironmentVariable("windir");
            string path = System.IO.Path.GetDirectoryName(
                          System.Windows.Forms.Application.ExecutablePath);

            //Program Files(x86)\DiniTools\WeighConsole.exe"

            System.Diagnostics.Process.Start(@"C:\Program Files (x86)\DiniTools\WeighConsole.exe");
        }

        private void keyboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string winpath = Environment.GetEnvironmentVariable("windir");
            string path = System.IO.Path.GetDirectoryName(
                          System.Windows.Forms.Application.ExecutablePath);

            //Process.Start(@"C:\\WINDOWS\system32\osk.exe");
        }

        private void fullDepreciationReceivingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFullDepreciationReceiving FullReceived = new frmFullDepreciationReceiving();
            FullReceived.ShowDialog();
        }

        private void qAWebsiteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmMicroInventory website = new frmMicroInventory();
            website.MdiParent = this;
            website.Show();
        }

        private void bunifuFlatButton10_Click(object sender, EventArgs e)
        {
            frmProductionSchedule ChildPorn = new frmProductionSchedule();
            ChildPorn.MdiParent = this;

            ChildPorn.Show();
        }

        private void microPreparationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmmicrowhpreparation micronew = new frmmicrowhpreparation();
            micronew.MdiParent = this;
            micronew.Show();

        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {

        }

        private void frmapprovalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFormulationApproval micronew = new frmFormulationApproval();
            micronew.MdiParent = this;
            micronew.Show();
     
        }

        private void bulditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMacroInventory macronews = new frmMacroInventory();
            macronews.MdiParent = this;
            macronews.Show();
        }

        private void mToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmMicroInventory micronews = new frmMicroInventory();
            micronews.MdiParent = this;
            micronews.Show();
        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {

        }

        private void toolMenuMicro_Click(object sender, EventArgs e)
        {


        
        }

        private void txtsearch_TextChanged_2(object sender, EventArgs e)
        {
 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.shutdown_64px;
            popup.TitleText = "Fedora";
            popup.ContentText = "Thank you for wathcing this Video !";
   popup.Size = new Size(920, 270);
            popup.BodyColor = Color.DarkSeaGreen;
            popup.Popup();

            //popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);



            popup.ShowOptionsButton = true;


        }

        private void ToolMixing_Click(object sender, EventArgs e)
        {
            lblnum2323 prep = new lblnum2323();
            prep.MdiParent = this;
            prep.Show();


        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure that you want to Logout " + lblTip.Text + " ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();

                Form1 una = new Form1();
                una.ShowDialog();
            }
            else
            {

                return;
            }
        }

        private void toolMicroRepacking_Click(object sender, EventArgs e)
        {
        
            bool Isopen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "frmrepackingentry")
                {
                    Isopen = true;
                    f.BringToFront();
                    break;
                }
            }

            if (Isopen == false)

            {
       
                frmrepackingentry ChildPorn = new frmrepackingentry();
                ChildPorn.MdiParent = this;
                ChildPorn.Show();
            }

        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            frmGenerateRepackingBarcodeID packingid = new frmGenerateRepackingBarcodeID();
            packingid.ShowDialog();
        }

        private void toolStripMenuItem18_Click(object sender, EventArgs e)
        {
            frmProductionSchedule ChildPorn = new frmProductionSchedule();
            ChildPorn.MdiParent = this;
 
            ChildPorn.Show();
        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
          
            //  frmImportQC importQC = new frmImportQC();
            //importQC.ShowDialog();
            frmImportQC ChildForm = new frmImportQC();
            ChildForm.MdiParent = this;
            ChildForm.Show();
        }

        private void macroRawMaterialToolStripMenuItem_Click(object sender, EventArgs e)
        {
     
            myglobal.REPORT_NAME = "MicroBook";
            rpt.Load(Rpt_Path + "\\MicroBook.rpt");

            frmReport frmReport = new frmReport();
            frmReport.MdiParent = this;
            frmReport.Show();
        }

        private void microRawMaterialToolStripMenuItem_Click(object sender, EventArgs e)
        {
      
            myglobal.REPORT_NAME = "MacroBook";
            rpt.Load(Rpt_Path + "\\MacroBook.rpt");

            frmReport frmReport = new frmReport();
            frmReport.MdiParent = this;
            frmReport.Show();
        }

        private void poSummaryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            //  frmImportQC importQC = new frmImportQC();
            //importQC.ShowDialog();
            frmImportQC ChildForm = new frmImportQC();
            ChildForm.MdiParent = this;
            ChildForm.Show();
        }

        private void formulationTableToolStripMenuItem1_Click(object sender, EventArgs e)
        {
      
            frmImportFormula ChildForm = new frmImportFormula();
            ChildForm.MdiParent = this;
            ChildForm.Show();
        }

        private void rawMaterialsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
     
            frmImportRawMaterials ChildForm = new frmImportRawMaterials();
            ChildForm.MdiParent = this;
            ChildForm.Show();
        }

        private void supplierToolStripMenuItem2_Click(object sender, EventArgs e)
        {
        
            frmImportSupplier ChildForm = new frmImportSupplier();
            ChildForm.MdiParent = this;
            ChildForm.Show();
        }

        private void toolStripMenuItem20_Click(object sender, EventArgs e)
        {
            frmFormulationManagement ManageFormula = new frmFormulationManagement();
            ManageFormula.MdiParent = this;
            ManageFormula.Show();
        }

        private void fullDepreciationReceivingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmFullDepreciationReceiving FullReceived = new frmFullDepreciationReceiving();
            FullReceived.MdiParent = this;
            FullReceived.Show();
        }

        private void repackingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmPreparationofMixing prep = new frmPreparationofMixing();

 
            frmListofApproveRepacking prep = new frmListofApproveRepacking();
            prep.MdiParent = this;
            prep.Show();
            //approvedRepack.ShowDialog();
        }

        private void toolStripMenuItem19_Click(object sender, EventArgs e)
        {
            frmFormulationApproval micronew = new frmFormulationApproval();
            micronew.MdiParent = this;
            micronew.Show();
     
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmmicrowhpreparation micronew = new frmmicrowhpreparation();
            micronew.MdiParent = this;
            micronew.Show();
 

        }

        private void formulationToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //frmFormula myformula = new frmFormula();
            //myformula.ShowDialog();

            frmFormula ChildFormFormula = new frmFormula();
            ChildFormFormula.MdiParent = this;
            ChildFormFormula.Show();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuSearch_Click(object sender, EventArgs e)
        {

        }

        private void listOfReceivedItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmmicroreceivingentry ChildForm = new frmmicroreceivingentry();
            ChildForm.MdiParent = this;
            ChildForm.Show();
            PermanentHide();
            lblactivemodule.Text = "MICRO RECEIVING";
            lblrecords.Text = "Null Entry";
        }

        private void microReceivingTransformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmApproveQA ApprovePOSummary = new frmApproveQA();
            ApprovePOSummary.MdiParent = this;
            ApprovePOSummary.Show();

        }

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmMicroInventory micronews = new frmMicroInventory();
                micronews.MdiParent = this;
            micronews.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmMacroInventory macronews = new frmMacroInventory();
            macronews.MdiParent = this;
            macronews.Show();
        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            frmuserrights user = new frmuserrights();
            user.ShowDialog();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            frmFormsAvailable available = new frmFormsAvailable();
            available.ShowDialog();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            frmusers userview = new frmusers();
                userview.ShowDialog();
        }

        private void microReceivingTransformationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmTheoScada MicroReceived = new frmTheoScada();
            MicroReceived.MdiParent = this;
            MicroReceived.Show();
        }

        private void tootStripExceltoFedora_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem21_Click(object sender, EventArgs e)
        {
            frmwhmacropreparation micronew = new frmwhmacropreparation();
            micronew.MdiParent = this;
            micronew.Show();
        }

        private void ToolStripItemCategory_Click(object sender, EventArgs e)
        {
            frmCategory category = new frmCategory();
            category.MdiParent = this;
            category.Show();
        }

        private void ToolStripGroup_Click(object sender, EventArgs e)
        {
            frmGroup Group = new frmGroup();
            Group.ShowDialog();
        }

        private void ToolStripActiveRepackingMonitoring_Click(object sender, EventArgs e)
        {
            frmActiveRepackingMonitoring activemonitoring = new frmActiveRepackingMonitoring();
            activemonitoring.MdiParent = this;
            activemonitoring.Show();
        }

        private void ToolStripActiveRepackingMonitoring_Click_1(object sender, EventArgs e)
        {
            frmActiveRepackingMonitoring activemonitoring = new frmActiveRepackingMonitoring();
            activemonitoring.MdiParent = this;
            activemonitoring.Show();
        }

        private void ToolStripDistinctRepackingRecords_Click(object sender, EventArgs e)
        {
            frmUserLognew distinctrecords = new frmUserLognew();
            distinctrecords.MdiParent = this;
            distinctrecords.Show();
        }

        private void ToolStripBaseMixed_Click(object sender, EventArgs e)
        {
            frmPrintBasemixedEntry PrintinBM = new frmPrintBasemixedEntry();
            PrintinBM.MdiParent = this;
            PrintinBM.Show();
        }

        private void rawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RawMatsRepackingTracking RAW = new RawMatsRepackingTracking();
            RAW.MdiParent = this;
          RAW.Show();
        }

        private void hellobuje_Click(object sender, EventArgs e)
        {

        }

        private void toolMacroRepacking_Click(object sender, EventArgs e)
        {
            //frmListofMacroRepacking RAW = new frmListofMacroRepacking();
            //RAW.MdiParent = this;
            //RAW.Show();

            RawMatsRepackingTracking RAW = new RawMatsRepackingTracking();
            RAW.MdiParent = this;
            RAW.Show();
        }

        private void toolStripMenuItem1_Click_2(object sender, EventArgs e)
        {
            frmListofMacroRepacking RAW = new frmListofMacroRepacking();
            RAW.MdiParent = this;
            RAW.Show();
            //frmListofApproveRepacking prep = new frmListofApproveRepacking();
            //prep.MdiParent = this;
            //prep.Show();
        }

        private void macroReceivingEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMacroReceivingEntry ChildForm = new frmMacroReceivingEntry();
            ChildForm.MdiParent = this;
            ChildForm.Show();
            PermanentHide();
            lblactivemodule.Text = "MCRO RECEIVING";
            lblrecords.Text = "Null Entry";
        
        }

        private void listOfMacroReceivingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmApproveQAMacro ChildForm = new fmApproveQAMacro();
            ChildForm.MdiParent = this;
            ChildForm.Show();

        }

        private void MacroRepackingEntry_Click(object sender, EventArgs e)
        {
            frmMacroRepacking RAW = new frmMacroRepacking();
            RAW.MdiParent = this;
            RAW.Show();
        }

        private void toolMacroRepacking_Click_1(object sender, EventArgs e)
        {
            RawMatsRepackingTracking RAW = new RawMatsRepackingTracking();
            RAW.MdiParent = this;
            RAW.Show();
        }

        private void distinctRepackingRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserLognew distinctrecords = new frmUserLognew();
            distinctrecords.MdiParent = this;
            distinctrecords.Show();
        }

        private void fullDepreciationRepackingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFullDepreciationReceiving FullReceived = new frmFullDepreciationReceiving();
            FullReceived.MdiParent = this;
            FullReceived.Show();
        }

        private void formulationManagementToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmFormulationManagement ManageFormula = new frmFormulationManagement();
            ManageFormula.MdiParent = this;
            ManageFormula.Show();
        }

        private void formulationTableToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmFormula ChildFormFormula = new frmFormula();
            ChildFormFormula.MdiParent = this;
            ChildFormFormula.Show();
        }

        private void itemCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategory category = new frmCategory();
            category.MdiParent = this;
            category.Show();
        }

        private void toolStripMacroReceiving_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem26_Click(object sender, EventArgs e)
        {
           txtremainingbatch prep = new txtremainingbatch();
            prep.MdiParent = this;
            prep.Show();
        }

        private void activeRepackingMonitoringToolStripMenuItem_Click(object sender, EventArgs e)
        {

          frmActiveRepackingMonitoring category = new frmActiveRepackingMonitoring();
            category.MdiParent = this;
            category.Show();
        }

        private void toolFinishGoods_Click(object sender, EventArgs e)
        {
            frmFinishGoods prep = new frmFinishGoods();
            prep.MdiParent = this;
            prep.Show();
        }

        private void dailyProductionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myglobal.rep_gen = "Daily";
            frmDailyProductions prep = new frmDailyProductions();
            prep.MdiParent = this;
            prep.Show();
        }

        private void fToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFGMaterialTracking prep = new frmFGMaterialTracking();
            prep.MdiParent = this;
            prep.Show();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Start();
            load_posummary_report();
            load_posummary_report_macro();
          
            load_search();
            load_Final_Buffer();
            if(SlowMovingIConCount.Text=="0")
            {
               SlowMovingICon.Visible = false;
               SlowMovingIConCount.Visible = false;
                
            }
            else
            {
            SlowMovingICon.Visible = true;
                //SlowMovingIConCount.Visible = true;
                NearlyExpired.Visible = true;
            }

            if (lblallmaterials.Text == "0")
            {
                //timer2.Stop();
        
            }
            else
            {
                NoofReceived();

            }

            if(lblmacroreceiving.Text == "0")
            {


            }

            else
            {

                NoofReceivedmacro();
            }

           

        }

        private void toolStripMacroInventory1_Click(object sender, EventArgs e)
        {
            frmMacroInventory macronews = new frmMacroInventory();
            macronews.MdiParent = this;
            macronews.Show();
        }

        private void toolStripMicroInventory1_Click(object sender, EventArgs e)
        {
            frmMicroInventory micronews = new frmMicroInventory();
            micronews.MdiParent = this;
            micronews.Show();
        }

        private void macroReceivingEntryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmMacroReceivingEntry ChildForm = new frmMacroReceivingEntry();
            ChildForm.MdiParent = this;
            ChildForm.Show();
            PermanentHide();
            lblactivemodule.Text = "MCRO RECEIVING";
            lblrecords.Text = "Null Entry";
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {

            fmApproveQAMacro ChildForm = new fmApproveQAMacro();
            ChildForm.MdiParent = this;
            ChildForm.Show();

        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            frmmicroreceivingentry ChildForm = new frmmicroreceivingentry();
            ChildForm.MdiParent = this;
            ChildForm.Show();
            PermanentHide();
            lblactivemodule.Text = "MICRO RECEIVING";
            lblrecords.Text = "Null Entry";
        }

        private void toolStripMenuItem17_Click_1(object sender, EventArgs e)
        {
            frmApproveQA ApprovePOSummary = new frmApproveQA();
            ApprovePOSummary.MdiParent = this;
            ApprovePOSummary.Show();
        }

        private void toolStripProductionSchedule1_Click(object sender, EventArgs e)
        {
            frmProductionSchedule ChildPorn = new frmProductionSchedule();
            ChildPorn.MdiParent = this;

            ChildPorn.Show();
        }

        private void toolStripProductionApproval1_Click(object sender, EventArgs e)
        {
            frmFormulationApproval micronew = new frmFormulationApproval();
            micronew.MdiParent = this;
            micronew.Show();
        }

        private void toolStripRepacking1_Click(object sender, EventArgs e)
        {
            frmListofApproveRepacking prep = new frmListofApproveRepacking();
         
            prep.MdiParent = this;
            prep.FormBorderStyle = FormBorderStyle.FixedSingle;
            prep.Show();
        }

        private void toolStripMenuItem111_Click(object sender, EventArgs e)
        {
            frmListofMacroRepacking RAW = new frmListofMacroRepacking();
            RAW.MdiParent = this;
            RAW.FormBorderStyle = FormBorderStyle.FixedSingle;
            RAW.Show();
        }

        private void toolStripMicroPreparation1_Click(object sender, EventArgs e)
        {
            frmmicrowhpreparation micronew = new frmmicrowhpreparation();
            micronew.MdiParent = this;
            micronew.Show();
        }

        private void toolStripMacroPreparation1_Click(object sender, EventArgs e)
        {
            frmwhmacropreparation micronew = new frmwhmacropreparation();
            micronew.MdiParent = this;
            micronew.Show();
        }

        private void ToolMicroMixing1_Click(object sender, EventArgs e)
        {
            lblnum2323 prep = new lblnum2323();
            prep.MdiParent = this;
            prep.Show();
        }

        private void toolStripMenuItem261_Click(object sender, EventArgs e)
        {
            txtremainingbatch prep = new txtremainingbatch();
            prep.MdiParent = this;
            prep.Show();
        }

        private void toolStripMenuItem28_Click(object sender, EventArgs e)
        {
            frmFinishGoods prep = new frmFinishGoods();
            prep.MdiParent = this;
            prep.Show();
        }

        private void toolStripMenuItem29_Click(object sender, EventArgs e)
        {
            frmFGMaterialTracking prep = new frmFGMaterialTracking();
            prep.MdiParent = this;
            prep.Show();
        }

        private void toolStripManageRights1_Click(object sender, EventArgs e)
        {
            frmuserrights user = new frmuserrights();
            user.ShowDialog();
        }

        private void toolStripFormsAvailable1_Click(object sender, EventArgs e)
        {
            frmFormsAvailable available = new frmFormsAvailable();
            available.ShowDialog();
        }

        private void toolStripUserManagement1_Click(object sender, EventArgs e)
        {
            frmusers userview = new frmusers();
            userview.MdiParent = this;
            userview.Show();
        }

        private void toolStripPrintRepackingEntry1_Click(object sender, EventArgs e)
        {
            frmGenerateRepackingBarcodeID packingid = new frmGenerateRepackingBarcodeID();
            packingid.ShowDialog();
        }

        private void toolStripMenuItem32_Click(object sender, EventArgs e)
        {
            //myglobal.REPORT_NAME = "MacroBook";
            //rpt.Load(Rpt_Path + "\\MacroBook.rpt");

            //frmReport frmReport = new frmReport();
            //frmReport.MdiParent = this;
            //frmReport.Show();
        }

        private void toolStripMenuItem33_Click(object sender, EventArgs e)
        {
            //myglobal.REPORT_NAME = "MicroBook";
            //rpt.Load(Rpt_Path + "\\MicroBook.rpt");

            //frmReport frmReport = new frmReport();
            //frmReport.MdiParent = this;
            //frmReport.Show();
        }

        private void toolStripMenuItem35_Click(object sender, EventArgs e)
        {
            frmImportQC ChildForm = new frmImportQC();
            ChildForm.MdiParent = this;
            ChildForm.Show();
        }

        private void toolStripMenuItem36_Click(object sender, EventArgs e)
        {
            frmImportFormula ChildForm = new frmImportFormula();
            ChildForm.MdiParent = this;
            ChildForm.Show();
        }

        private void toolStripMenuItem37_Click(object sender, EventArgs e)
        {
            frmImportRawMaterials ChildForm = new frmImportRawMaterials();
            ChildForm.MdiParent = this;
            ChildForm.Show();
        }

        private void toolStripMenuItem38_Click(object sender, EventArgs e)
        {
            frmImportSupplier ChildForm = new frmImportSupplier();
            ChildForm.MdiParent = this;
            ChildForm.Show();
        }

        private void ToolStripBaseMixed1_Click(object sender, EventArgs e)
        {
            frmPrintBasemixedEntry PrintinBM = new frmPrintBasemixedEntry();
            PrintinBM.MdiParent = this;
            PrintinBM.Show();
        }

        private void MacroRepackingEntry1_Click(object sender, EventArgs e)
        {
            frmMacroRepacking RAW = new frmMacroRepacking();
            RAW.MdiParent = this;
            RAW.Show();
        }

        private void toolMacroRepacking1_Click(object sender, EventArgs e)
        {
            RawMatsRepackingTracking RAW = new RawMatsRepackingTracking();
            RAW.MdiParent = this;
            RAW.Show();
        }

        private void activeRepackingMonitoringToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmActiveRepackingMonitoring category = new frmActiveRepackingMonitoring();
            category.MdiParent = this;
            category.Show();
        }

        private void formulationManagementToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmFormulationManagement ManageFormula = new frmFormulationManagement();
            ManageFormula.MdiParent = this;
            ManageFormula.Show();
        }

        private void formulationTableToolStripMenuItem911_Click(object sender, EventArgs e)
        {
            frmFormula ChildFormFormula = new frmFormula();
            ChildFormFormula.MdiParent = this;
            ChildFormFormula.Show();
        }

        private void toolStripMenuItem49_Click(object sender, EventArgs e)
        {
            myglobal.rep_gen = "Daily";
            frmDailyProductions prep = new frmDailyProductions();
            prep.MdiParent = this;
            prep.Show();
        }

        private void itemCategoryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmCategory category = new frmCategory();
            category.MdiParent = this;
            category.Show();
        }

        private void distinctRepackingRecordsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmUserLognew distinctrecords = new frmUserLognew();
            distinctrecords.MdiParent = this;
            distinctrecords.Show();
        }

        private void fullDepreciationRepackingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmFullDepreciationReceiving FullReceived = new frmFullDepreciationReceiving();
            FullReceived.MdiParent = this;
            FullReceived.Show();
        }

        private void totalFGProducedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myglobal.rep_gen = "FG";
            frmDailyProductions prep = new frmDailyProductions();

            prep.MdiParent = this;
            prep.Show();
 

        }

        private void microMacroMaterialUsedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myglobal.rep_gen = "MaterialUsed";
            frmDailyProductions prep = new frmDailyProductions();

            prep.MdiParent = this;
            prep.Show();
        }

        private void printRepackingEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGenerateRepackingBarcodeID packingid = new frmGenerateRepackingBarcodeID();
            packingid.MdiParent = this;
            packingid.Show();

        }

        private void ToolStripBaseMixed1_Click_1(object sender, EventArgs e)
        {
            frmPrintBasemixedEntry PrintinBM = new frmPrintBasemixedEntry();
            PrintinBM.MdiParent = this;
            PrintinBM.Show();
        }

        private void printFinishedGoodsEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReprintFinishedGoods PrintinBM = new frmReprintFinishedGoods();
            PrintinBM.MdiParent = this;
            PrintinBM.Show();
        }

        private void printFGBulkEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGenerateRepackingBulkEntry PrintinBM = new frmGenerateRepackingBulkEntry();
            PrintinBM.MdiParent = this;
            PrintinBM.Show();
        }

        private void efficiencyScheduleOverActualProducedToolStripMenuItem_Click(object sender, EventArgs e)
        {
     

            frmEfficiencyofFG  PrintinBM = new frmEfficiencyofFG();
            PrintinBM.MdiParent = this;
            PrintinBM.Show();
        }

        private void inventoryToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolFGmaterialTracking_Click(object sender, EventArgs e)
        {
            frmFGMaterialTracking prep = new frmFGMaterialTracking();
            prep.MdiParent = this;
            prep.Show();
        }

        private void distinctRepackingRecordsToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            frmUserLognew distinctrecords = new frmUserLognew();
            distinctrecords.MdiParent = this;
            distinctrecords.Show();
        }

        private void systemUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmsystemupdate frmsystemupdate1 = new frmsystemupdate();
            frmsystemupdate1.MdiParent = this;
            frmsystemupdate1.Show();
        }

        private void pictureBoxnotif_Click(object sender, EventArgs e)
        {
            frmsystemupdate frmsystemupdate1 = new frmsystemupdate();
            frmsystemupdate1.MdiParent = this;
            frmsystemupdate1.Show();
        }

        private void microMaterialReceivingHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myglobal.rep_gen = "Micro";
            frmMicroMaterialReceivingHistory frmsystemupdate1 = new frmMicroMaterialReceivingHistory();
            frmsystemupdate1.MdiParent = this;
            frmsystemupdate1.Show();



        }

        private void macroMaterialReceivingHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myglobal.rep_gen = "Macros";
            frmMicroMaterialReceivingHistory frmsystemupdate1 = new frmMicroMaterialReceivingHistory();
            frmsystemupdate1.MdiParent = this;
            frmsystemupdate1.Show();


        }

        private void aAAdditivesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myglobal.REPORT_NAME = "MicroBook";
            rpt.Load(Rpt_Path + "\\MicroBook.rpt");

            frmReport frmReport = new frmReport();
            frmReport.MdiParent = this;
            frmReport.Show();
        }

        private void sasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductionLevel pepe = new frmProductionLevel();
            pepe.Show();
        }

        private void acidifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myglobal.REPORT_NAME = "MicroBookAcidifier";
            rpt.Load(Rpt_Path + "\\MicroBookAcidifier.rpt");

            frmReport frmReport = new frmReport();
            frmReport.MdiParent = this;
            frmReport.Show();
        }

        private void cholineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myglobal.REPORT_NAME = "MicroBookCholine";
            rpt.Load(Rpt_Path + "\\MicroBookCholine.rpt");

            frmReport frmReport = new frmReport();
            frmReport.MdiParent = this;
            frmReport.Show();
        }

        private void medicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myglobal.REPORT_NAME = "MicroBookMedication";
            rpt.Load(Rpt_Path + "\\MicroBookMedication.rpt");

            frmReport frmReport = new frmReport();
            frmReport.MdiParent = this;
            frmReport.Show();
        }

        private void minPmxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myglobal.REPORT_NAME = "MicroBookMin Pmx";
            rpt.Load(Rpt_Path + "\\MicroBookMin Pmx.rpt");

            frmReport frmReport = new frmReport();
            frmReport.MdiParent = this;
            frmReport.Show();
        }

        private void uSSOYAHIPROToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myglobal.REPORT_NAME = "MicroBookUSSOYA";
            rpt.Load(Rpt_Path + "\\MicroBookUSSOYA.rpt");

            frmReport frmReport = new frmReport();
            frmReport.MdiParent = this;
            frmReport.Show();
        }

        private void validateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myglobal.REPORT_NAME = "MicroBookValidate";
            //rpt.Load(Rpt_Path + "\\MicroBookValidate.rpt");

            frmReport frmReport = new frmReport();
            frmReport.MdiParent = this;
            frmReport.Show();
        }

        private void vitPmxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myglobal.REPORT_NAME = "MicroBookVit Pmx";
            rpt.Load(Rpt_Path + "\\MicroBookVit Pmx.rpt");

            frmReport frmReport = new frmReport();
            frmReport.MdiParent = this;
            frmReport.Show();
        }

        private void validateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            myglobal.REPORT_NAME = "MacroBookValidate";

            rpt.Load(Rpt_Path + "\\MacroBookValidate.rpt");

            frmReport frmReport = new frmReport();
            frmReport.MdiParent = this;
            frmReport.Show();

            //rpt.Load(Rpt_Path + "\\FGMicroMaterialUsed.rpt");
     
            ////rpt.SetDatabaseLogon("sa", "Nescafe3in1");
            //rpt.Refresh();
            //string ddate = myglobal.DATE_REPORT;
            //string ddate2 = myglobal.DATE_REPORT2;

            //rpt.SetParameterValue("@ddate", ddate);
            //rpt.SetParameterValue("@ddate2", ddate2);
            //crV1.ReportSource = rpt;
            //crV1.Refresh();
        }

        private void theoretical1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myglobal.REPORT_NAME = "MacroBookTheoretical1";
            rpt.Load(Rpt_Path + "\\MacroBookTheoretical1.rpt");

            frmReport frmReport = new frmReport();
            frmReport.MdiParent = this;
            frmReport.Show();
        }

        private void theoretical2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myglobal.REPORT_NAME = "MacroBookTheoretical2";
            rpt.Load(Rpt_Path + "\\MacroBookTheoretical2.rpt");

            frmReport frmReport = new frmReport();
            frmReport.MdiParent = this;
            frmReport.Show();
        }

        private void toolStripMenuItem25_Click(object sender, EventArgs e)
        {
            frmImportQC ChildForm = new frmImportQC();
            ChildForm.MdiParent = this;
            ChildForm.Show();
        }

        private void toolStripMenuItem27_Click(object sender, EventArgs e)
        {
            frmImportFormula ChildForm = new frmImportFormula();
            ChildForm.MdiParent = this;
            ChildForm.Show();
        }


        private void toolStripMenuItem28_Click_1(object sender, EventArgs e)
        {
            frmImportRawMaterials ChildForm = new frmImportRawMaterials();
            ChildForm.MdiParent = this;
            ChildForm.Show();
        }

        private void toolStripMenuItem29_Click_1(object sender, EventArgs e)
        {
            frmImportSupplier ChildForm = new frmImportSupplier();
            ChildForm.MdiParent = this;
            ChildForm.Show();
        }

        private void toolStripMenuItem29_Click_2(object sender, EventArgs e)
        {
            frmImportSupplier ChildForm = new frmImportSupplier();
            ChildForm.MdiParent = this;
            ChildForm.Show();
        }

        private void productionLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductionLevel ChildForm = new frmProductionLevel();
            ChildForm.MdiParent = this;
            ChildForm.Show();
        }

        private void totalFGDelayedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //myglobal.rep_gen = "FGDelayed";
            //frmDailyProductions prep = new frmDailyProductions();

            //prep.MdiParent = this;

            //prep.Show();


            frmFGDelayed PrintinBM = new frmFGDelayed();
            PrintinBM.MdiParent = this;
            PrintinBM.Show();
        }

        private void toolStripFinishGoods1_ButtonClick(object sender, EventArgs e)
        {

        }

        private void Userights1_ButtonClick(object sender, EventArgs e)
        {

        }

        private void receivingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void listOfFormulationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFormulationList prep = new frmFormulationList();

            prep.MdiParent = this;

            prep.Show();
        }

        private void listOfReceivingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dailyProductionReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myglobal.rep_gen = "DailyProd";
           frmDailyProductionReports prep = new frmDailyProductionReports();

            prep.MdiParent = this;

            prep.Show();
        }

        private void mixingCapacityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmmixingcapacity prep = new frmmixingcapacity();

            prep.MdiParent = this;

            prep.Show();
        }

        private void repackingPieChartToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmproductionrepackchart prep = new frmproductionrepackchart();

            prep.MdiParent = this;

            prep.Show();
        }

        private void formulationToProductionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFormulationtoProduction prep = new frmFormulationtoProduction();

            prep.MdiParent = this;

            prep.Show();
        }

        private void fGMonitoringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FgDashboardMonitoring prep = new FgDashboardMonitoring();

            prep.MdiParent = this;

            prep.Show();
        }

        private void theoroticalLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTheoroticalLogSheet prep = new frmTheoroticalLogSheet();

            prep.MdiParent = this;

            prep.Show();
        }

        private void reprintMonitoringToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmReprintMonitoring prep = new frmReprintMonitoring();

            prep.MdiParent = this;

            prep.Show();


        }

        private void fGReprocessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFGReprocessModule prep = new frmFGReprocessModule();

            prep.MdiParent = this;

            prep.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBoxnotif_Click(sender, e);
        }

        private void MyBelovedLight_Click(object sender, EventArgs e)
        {
            pictureBoxnotif_Click(sender, e);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
   
            frmSystemLock prep = new frmSystemLock();

            prep.MdiParent = this;

            prep.Show();


        }

        private void BufferPic_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "View Buffered Inventory " + lblTip.Text + "?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {


                frmBufferedInventory prep = new frmBufferedInventory();

                prep.MdiParent = this;

                prep.Show();

            }
            else
            {

                return;
            }




        }

        private void ggToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFGReprocessModule prep = new frmFGReprocessModule();

            prep.MdiParent = this;

            prep.Show();
        }

        private void productionHoursToolStripMenuItem_Click(object sender, EventArgs e)
        {

            fmProductionHours music = new fmProductionHours();
            music.MdiParent = this;
            music.Show();




        }

        private void allMicroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myglobal.REPORT_NAME = "MicroAll";
            rpt.Load(Rpt_Path + "\\MicroAll.rpt");

            frmReport frmReport = new frmReport();
            frmReport.MdiParent = this;
            frmReport.Show();
        }

        private void productionPlanningToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripWarehouseBarcodes1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem35_Click_1(object sender, EventArgs e)
        {

            myglobal.REPORT_NAME = "MacroAll";
            rpt.Load(Rpt_Path + "\\MacroAll.rpt");

            frmReport frmReport = new frmReport();
            frmReport.MdiParent = this;
            frmReport.Show();


        }

        private void microMacroMaterialUsedRepackingDateToolStripMenuItem_Click(object sender, EventArgs e)
        {

            myglobal.rep_gen = "MaterialUsedRepacking";
      frmAnotherReports prep = new frmAnotherReports();

            prep.MdiParent = this;
            prep.Show();


        }

        private void fileMenu_Click(object sender, EventArgs e)
        {

        }

        private void editMenu_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
  
            if(lblshowfedora.Text=="1")
            {
                pBFedora.Visible = false;

                lblshowfedora.Text = "0";
            }
            else
            {
                pBFedora.Visible = true;
                lblshowfedora.Text = "1";
            }

        }

        private void toolReports1_ButtonClick(object sender, EventArgs e)
        {

        }

        private void tstProdLogs_Click(object sender, EventArgs e)
        {

         frmViewApproverCancelProd music = new frmViewApproverCancelProd();
            music.MdiParent = this;
            music.Show();

        }

        private void mixingCapacityToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmmixingcapacity prep = new frmmixingcapacity();

            prep.MdiParent = this;

            prep.Show();
        }

        private void formulationManagementToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            frmFormulationManagement ManageFormula = new frmFormulationManagement();
            ManageFormula.MdiParent = this;
            ManageFormula.Show();
        }

        private void productionLevelToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmProductionLevel ChildForm = new frmProductionLevel();
            ChildForm.MdiParent = this;
            ChildForm.Show();
        }

        private void toolStripMenuItem53_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem54_Click(object sender, EventArgs e)
        {


        }

        private void toolStripMenuItem68_Click(object sender, EventArgs e)
        {



        }

        private void toolStripMenuItem69_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem71_Click(object sender, EventArgs e)
        {


        }

        private void toolStripMenuItem72_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem73_Click(object sender, EventArgs e)
        {


        }

        private void toolStripMenuItem74_Click(object sender, EventArgs e)
        {



        }

        private void toolStripMenuItem75_Click(object sender, EventArgs e)
        {



        }

        private void toolStripMenuItem76_Click(object sender, EventArgs e)
        {


        }

        private void toolStripMenuItem77_Click(object sender, EventArgs e)
        {


        }

        private void toolStripMenuItem78_Click(object sender, EventArgs e)
        {


        }

        private void toolStripMenuItem79_Click(object sender, EventArgs e)
        {







        }

        private void pRINTINGToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem53_Click_1(object sender, EventArgs e)
        {


        }

        private void toolStripMenuItem54_Click_1(object sender, EventArgs e)
        {


        }

        private void toolStripMenuItem68_Click_1(object sender, EventArgs e)
        {



        }

        private void toolStripMenuItem69_Click_1(object sender, EventArgs e)
        {







        }

        private void toolStripMenuItem71_Click_1(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem72_Click_1(object sender, EventArgs e)
        {



        }

        private void toolStripMenuItem73_Click_1(object sender, EventArgs e)
        {



        }

        private void toolStripMenuItem74_Click_1(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem75_Click_1(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem76_Click_1(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem77_Click_1(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem78_Click_1(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem79_Click_1(object sender, EventArgs e)
        {

        }

        private void repackingPieChartToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmproductionrepackchart prep = new frmproductionrepackchart();

            prep.MdiParent = this;

            prep.Show();


        }

        private void activeRepackingMonitoringToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            frmActiveRepackingMonitoring category = new frmActiveRepackingMonitoring();
            category.MdiParent = this;
            category.Show();
        }

        private void fullDepreciationRepackingToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            frmFullDepreciationReceiving FullReceived = new frmFullDepreciationReceiving();
            FullReceived.MdiParent = this;
            FullReceived.Show();
        }

        private void formulationTableToolStripMenuItem911_Click_1(object sender, EventArgs e)
        {
            frmFormula ChildFormFormula = new frmFormula();
            ChildFormFormula.MdiParent = this;
            ChildFormFormula.Show();
        }

        private void listOfFormulationToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            frmFormulationList prep = new frmFormulationList();

            prep.MdiParent = this;

            prep.Show();

        }

        private void fGMonitoringToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FgDashboardMonitoring prep = new FgDashboardMonitoring();

            prep.MdiParent = this;

            prep.Show();


        }

        private void productionHoursToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            fmProductionHours music = new fmProductionHours();
            music.MdiParent = this;
            music.Show();


        }

        private void toolStripMenuItem82_Click(object sender, EventArgs e)
        {
            frmGenerateRepackingBarcodeID packingid = new frmGenerateRepackingBarcodeID();
            packingid.MdiParent = this;
            packingid.Show();

        }

        private void externalReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripNBaseMixed1_Click(object sender, EventArgs e)
        {

            frmPrintBasemixedEntry PrintinBM = new frmPrintBasemixedEntry();
            PrintinBM.MdiParent = this;
            PrintinBM.Show();
        }

        private void printFinishedGoodsEntryToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmReprintFinishedGoods PrintinBM = new frmReprintFinishedGoods();
            PrintinBM.MdiParent = this;
            PrintinBM.Show();
        }

        private void printFGBulkEntryToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            frmGenerateRepackingBulkEntry PrintinBM = new frmGenerateRepackingBulkEntry();
            PrintinBM.MdiParent = this;
            PrintinBM.Show();

        }

        private void toolStripMenuItem82_Click_1(object sender, EventArgs e)
        {
            myglobal.rep_gen = "Micro";
            frmMicroMaterialReceivingHistory frmsystemupdate1 = new frmMicroMaterialReceivingHistory();
            frmsystemupdate1.MdiParent = this;
            frmsystemupdate1.Show();
        }

        private void toolStripMenuItem83_Click(object sender, EventArgs e)
        {
            myglobal.rep_gen = "Macros";
            frmMicroMaterialReceivingHistory frmsystemupdate1 = new frmMicroMaterialReceivingHistory();
            frmsystemupdate1.MdiParent = this;
            frmsystemupdate1.Show();
        }

        private void theoroticalLogsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmTheoroticalLogSheet prep = new frmTheoroticalLogSheet();

            prep.MdiParent = this;

            prep.Show();
        }

        private void reprintMonitoringToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmReprintMonitoring prep = new frmReprintMonitoring();

            prep.MdiParent = this;

            prep.Show();
        }

        private void toolStripMenuItem71_Click_2(object sender, EventArgs e)
        {
            myglobal.REPORT_NAME = "MicroBook";
            rpt.Load(Rpt_Path + "\\MicroBook.rpt");

            frmReport frmReport = new frmReport();
            frmReport.MdiParent = this;
            frmReport.Show();
        }

        private void toolStripMenuItem72_Click_2(object sender, EventArgs e)
        {
            myglobal.REPORT_NAME = "MicroBookAcidifier";
            rpt.Load(Rpt_Path + "\\MicroBookAcidifier.rpt");

            frmReport frmReport = new frmReport();
            frmReport.MdiParent = this;
            frmReport.Show();
        }

        private void toolStripMenuItem73_Click_2(object sender, EventArgs e)
        {
            myglobal.REPORT_NAME = "MicroBookCholine";
            rpt.Load(Rpt_Path + "\\MicroBookCholine.rpt");

            frmReport frmReport = new frmReport();
            frmReport.MdiParent = this;
            frmReport.Show();
        }

        private void toolStripMenuItem74_Click_2(object sender, EventArgs e)
        {
            myglobal.REPORT_NAME = "MicroBookMedication";
            rpt.Load(Rpt_Path + "\\MicroBookMedication.rpt");

            frmReport frmReport = new frmReport();
            frmReport.MdiParent = this;
            frmReport.Show();
        }

        private void toolStripMenuItem75_Click_2(object sender, EventArgs e)
        {
            myglobal.REPORT_NAME = "MicroBookMin Pmx";
            rpt.Load(Rpt_Path + "\\MicroBookMin Pmx.rpt");

            frmReport frmReport = new frmReport();
            frmReport.MdiParent = this;
            frmReport.Show();
        }

        private void toolStripMenuItem76_Click_2(object sender, EventArgs e)
        {
            myglobal.REPORT_NAME = "MicroBookUSSOYA";
            rpt.Load(Rpt_Path + "\\MicroBookUSSOYA.rpt");

            frmReport frmReport = new frmReport();
            frmReport.MdiParent = this;
            frmReport.Show();
        }

        private void toolStripMenuItem77_Click_2(object sender, EventArgs e)
        {
            myglobal.REPORT_NAME = "MicroBookValidate";
            //rpt.Load(Rpt_Path + "\\MicroBookValidate.rpt");

            frmReport frmReport = new frmReport();
            frmReport.MdiParent = this;
            frmReport.Show();
        }

        private void toolStripMenuItem78_Click_2(object sender, EventArgs e)
        {
            myglobal.REPORT_NAME = "MicroBookVit Pmx";
            rpt.Load(Rpt_Path + "\\MicroBookVit Pmx.rpt");

            frmReport frmReport = new frmReport();
            frmReport.MdiParent = this;
            frmReport.Show();
        }

        private void toolStripMenuItem79_Click_2(object sender, EventArgs e)
        {
            myglobal.REPORT_NAME = "MicroAll";
            rpt.Load(Rpt_Path + "\\MicroAll.rpt");

            frmReport frmReport = new frmReport();
            frmReport.MdiParent = this;
            frmReport.Show();
        }

        private void toolStripMenuItem53_Click_2(object sender, EventArgs e)
        {
            myglobal.REPORT_NAME = "MacroBookValidate";

            rpt.Load(Rpt_Path + "\\MacroBookValidate.rpt");

            frmReport frmReport = new frmReport();
            frmReport.MdiParent = this;
            frmReport.Show();
        }

        private void toolStripMenuItem54_Click_2(object sender, EventArgs e)
        {
            myglobal.REPORT_NAME = "MacroBookTheoretical1";
            rpt.Load(Rpt_Path + "\\MacroBookTheoretical1.rpt");

            frmReport frmReport = new frmReport();
            frmReport.MdiParent = this;
            frmReport.Show();

        }

        private void toolStripMenuItem68_Click_2(object sender, EventArgs e)
        {
            myglobal.REPORT_NAME = "MacroBookTheoretical2";
            rpt.Load(Rpt_Path + "\\MacroBookTheoretical2.rpt");

            frmReport frmReport = new frmReport();
            frmReport.MdiParent = this;
            frmReport.Show();
        }

        private void toolStripMenuItem69_Click_2(object sender, EventArgs e)
        {
            myglobal.REPORT_NAME = "MacroAll";
            rpt.Load(Rpt_Path + "\\MacroAll.rpt");

            frmReport frmReport = new frmReport();
            frmReport.MdiParent = this;
            frmReport.Show();
        }

        private void fGInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFGMainInventory micronews = new frmFGMainInventory();
            micronews.MdiParent = this;
            micronews.Show();
        }

        private void moverOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMoveOrder moveorder = new frmMoveOrder();
            moveorder.MdiParent = this;
            moveorder.Show();
        }

        private void toolStripMenuItem70_Click(object sender, EventArgs e)
        {
         frmMoveOrderDonePrinted micronews = new frmMoveOrderDonePrinted();
            micronews.MdiParent = this;
            micronews.Show();
        }

        private void moveOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void transactMoveOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFGMoveorderPrinting micronews = new frmFGMoveorderPrinting();
            micronews.MdiParent = this;
            micronews.Show();
        }

        private void tsPSetup_ButtonClick(object sender, EventArgs e)
        {

        }

        private void fGInvetToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mixingCombinationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCombinationCode micronews = new frmCombinationCode();
            micronews.MdiParent = this;
            micronews.Show();
        }

        private void warehouseManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {


            frmWarehouseMgmt micronews = new frmWarehouseMgmt();
            micronews.MdiParent = this;
            micronews.Show();
        }

        private void customerManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void customerManagementToolStripMenuItem_Click_1(object sender, EventArgs e)
        {


            frmCustomer customer = new frmCustomer();
            customer.MdiParent = this;
            customer.Show();
        }

        private void fGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFGReprocessReports customer = new frmFGReprocessReports();
            customer.MdiParent = this;
            customer.Show();
        }

        private void fGReprocessLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFGReprocessReports customer = new frmFGReprocessReports();
            customer.MdiParent = this;
            customer.Show();
        }

        private void fGReprocessToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmFGReprocessReports customer = new frmFGReprocessReports();
            customer.MdiParent = this;
            customer.Show();
        }

        private void internalReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tsTProdDateMaterials_Click(object sender, EventArgs e)
        {

            frmMaterialUsedOverProductionDate material = new frmMaterialUsedOverProductionDate();
            material.MdiParent = this;
            material.Show();


        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripMenuItem84_Click(object sender, EventArgs e)
        {

            frmProdDatetoFGReport ProdateToFGFilterring = new frmProdDatetoFGReport();
            ProdateToFGFilterring.MdiParent = this;
            ProdateToFGFilterring.Show();

        }

        private void formulationToProductionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmFormulationtoProduction prep = new frmFormulationtoProduction();

            prep.MdiParent = this;

            prep.Show();
        }

        private void rawMateriaslDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRawMaterialsDataRepack prep = new frmRawMaterialsDataRepack();

            prep.MdiParent = this;

            prep.Show();

        }

        private void bulkEntryManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBulkValueMgmt prep = new frmBulkValueMgmt();

            prep.MdiParent = this;

            prep.Show();
        }

        private void receivingReceiptToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmReceivingReceipt received = new frmReceivingReceipt();
            received.MdiParent = this;
            received.Show();

        }

        private void miscellaneousTransactionReceiptInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMiscellaneoustransactionIssueIN newreceiving = new frmMiscellaneoustransactionIssueIN();
            newreceiving.MdiParent = this;
            newreceiving.Show();


        }

        private void miscellaneousTransactionIssueOutToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmMiscellaneousReceiving newMISreceiving = new frmMiscellaneousReceiving();
            newMISreceiving.MdiParent = this;
            newMISreceiving.Show();


        }

        private void OUT_Click(object sender, EventArgs e)
        {

            frmMiscellaneousOutReport jade = new frmMiscellaneousOutReport();

            jade.MdiParent = this;
           jade.Show();


        }

        private void IN_Click(object sender, EventArgs e)
        {

            frmMiscelleneousReceipt jade = new frmMiscelleneousReceipt();

            jade.MdiParent = this;
            jade.Show();

        }

        private void fGReceivingEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFGReceivings jade = new frmFGReceivings();

            jade.MdiParent = this;
            jade.Show();
        }

        private void fGReceivingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
        }

        private void productionSchedulesListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRepackingProductionCheckList asd = new frmRepackingProductionCheckList();
       asd.MdiParent = this;
            asd.Show();
        }

        private void productionScheToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRepackingProductionCheckList asd = new frmRepackingProductionCheckList();
            asd.MdiParent = this;
            asd.Show();
        }

        private void automToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmProductionAutomation ruel = new frmProductionAutomation();

            ruel.MdiParent = this;
            ruel.Show();

        }

        private void reprocessAdjusmtneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReprocessAdjustment ruel = new frmReprocessAdjustment();

            ruel.MdiParent = this;
            ruel.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //frmMenu ruel = new frmMenu();

            //ruel.MdiParent = this;
            //ruel.Show();
        }

        private void fGReprocessToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {

            frmFGReprocessReports customer = new frmFGReprocessReports();
            customer.MdiParent = this;
            customer.Show();

        }

        private void theoreticalScadaDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTheoScada Scada = new frmTheoScada();
            Scada.MdiParent = this;
            Scada.Show();
        }

        private void SlowMovingICon_Click(object sender, EventArgs e)
        {





        }

        private void SlowMovingICon_Click_1(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "View Buffered Inventory " + lblTip.Text + "?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {


                frmBufferedInventory prep = new frmBufferedInventory();

                prep.MdiParent = this;

                prep.Show();

            }
            else
            {

                return;
            }
        }

        private void NearlyExpired_Click(object sender, EventArgs e)
        {



            if (MetroFramework.MetroMessageBox.Show(this, "View Raw Material Expired & Nearly Expiration " + lblTip.Text + "?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {


                frmNearlyExpired prep = new frmNearlyExpired();

                prep.MdiParent = this;

                prep.Show();

            }
            else
            {

                return;
            }


        }

        private void toolStripMenuItem32_Click_1(object sender, EventArgs e)
        {

            frmFGReceipt newreceiving = new frmFGReceipt();
            newreceiving.MdiParent = this;
            newreceiving.Show();


        }

        private void toolStripMenuItem33_Click_1(object sender, EventArgs e)
        {

          frmFGIssue newreceiving = new frmFGIssue();
            newreceiving.MdiParent = this;
            newreceiving.Show();
        }

        private void miscellaneousTransactionToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void generateRawMaterialsStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmMaterialStatusReports newreceiving = new frmMaterialStatusReports();
            newreceiving.MdiParent = this;
            newreceiving.Show();

        }

        private void mACROToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            frmMonthlyInventory newreceiving = new frmMonthlyInventory();
            newreceiving.MdiParent = this;
            newreceiving.Show();
        }

        private void mICROToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            frmMonthlyInventoryMicro newreceiving = new frmMonthlyInventoryMicro();
            newreceiving.MdiParent = this;
            newreceiving.Show();
        }

        private void inventoryMovementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRawMatsTheoMovementReports MovementRpt = new frmRawMatsTheoMovementReports();
            MovementRpt.MdiParent = this;
            MovementRpt.Show();
        }

        private void fGReprocessReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void reprocessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myglobal.REPORT_NAME = "ReprocessData";
      

            frmReport frmReport = new frmReport();

            frmReport.Show();
        }

        private void mixingCronTyoeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myglobal.REPORT_NAME = "MixingCapacity";

            frmReport frmReport = new frmReport();

            frmReport.Show();


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            frmMaterialLowInventory MovementRpt = new frmMaterialLowInventory();
            MovementRpt.MdiParent = this;
            MovementRpt.Show();
        }

        private void toolStripMenuItem70_Click_1(object sender, EventArgs e)
        {
            frmFGMoveorderPrinting micronews = new frmFGMoveorderPrinting();
            micronews.MdiParent = this;
            micronews.Show();
        }

        private void IN_Click_1(object sender, EventArgs e)
        {
            frmMiscelleneousReceipt jade = new frmMiscelleneousReceipt();

            jade.MdiParent = this;
            jade.Show();

        }

        private void OUT_Click_1(object sender, EventArgs e)
        {
            frmMiscellaneousOutReport jade = new frmMiscellaneousOutReport();

            jade.MdiParent = this;
            jade.Show();

        }

        private void theoreticalScadaDataToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //frmTheoScada Scada = new frmTheoScada();
            //Scada.MdiParent = this;
            //Scada.Show();
        }

        private void productionHoursToolStripMenuItem_Click_2(object sender, EventArgs e)
        {

            fmProductionHours music = new fmProductionHours();
            music.MdiParent = this;
            music.Show();
        }

        private void fGInvetToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

           
        }

        private void rMNearlyExpiredReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmNearlyExpired prep = new frmNearlyExpired();

            prep.MdiParent = this;

            prep.Show();
        }

        private void toolFGTransformation_Click(object sender, EventArgs e)
        {
           frmFGTransformationReport prep = new frmFGTransformationReport();

            prep.MdiParent = this;

            prep.Show();
        }

        private void tSBufferedStocks_Click(object sender, EventArgs e)
        {
            frmBufferedInventory prep = new frmBufferedInventory();

            prep.MdiParent = this;

            prep.Show();
        }

        private void microToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            myglobal.REPORT_NAME = "MicroInventorys";

            frmReport frmReport = new frmReport();
            //frmReport.MdiParent = this;
            frmReport.Show();
        }

        private void macroToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            myglobal.REPORT_NAME = "MacroInventorys";
            frmReport frmReport = new frmReport();
            frmReport.Show();

        }

        private void toolStripMenuItem49_Click_1(object sender, EventArgs e)
        {

           frmQAReports prep = new frmQAReports();
            prep.MdiParent = this;
            prep.Show();
        }

        private void productionPlanControllerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductionPlanController prep = new frmProductionPlanController();
            prep.MdiParent = this;
            prep.Show();

        }

        private void scadaReportBasedOnProdPlanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmScadaMonitoringPerProdPlan proteinShake = new frmScadaMonitoringPerProdPlan();
            proteinShake.MdiParent = this;
            proteinShake.Show();
        }

        private void scadaReportBasedOnProductionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTheoScada Scada = new frmTheoScada();
            Scada.MdiParent = this;
            Scada.Show();
        }

        private void fGMiscellaneousIssueFinanceToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FrmFGMiscellaneousFinanceIssue FGMiscellaneousIssueFinance = new FrmFGMiscellaneousFinanceIssue();
            FGMiscellaneousIssueFinance.MdiParent = this;
            FGMiscellaneousIssueFinance.Show();

           
        }

        private void fGReceivedReportTransactionDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmfGTransactReceivedReport FGTransactReceived = new FrmfGTransactReceivedReport();

            FGTransactReceived.MdiParent = this;
            FGTransactReceived.Show();
        }

        private void fGReceivedReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFGReceivingReports Jreceiving = new frmFGReceivingReports();

            Jreceiving.MdiParent = this;
            Jreceiving.Show();
        }

        private void fGMoveOrderSlipToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            
            FrmMoveOrderPickSlip FGMoveOrderPickSlipPrint = new FrmMoveOrderPickSlip();

            FGMoveOrderPickSlipPrint.MdiParent = this;
            FGMoveOrderPickSlipPrint.Show();
        }

        private void fGTransactMoveOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTransactMoveOrderReports TransactMoveorder = new frmTransactMoveOrderReports();
            TransactMoveorder.MdiParent = this;
            TransactMoveorder.Show();
            
        }

        private void rECEIPTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFGMiscellaneousReceiptReports FrmFGMiscellaneousReceiptReports = new FrmFGMiscellaneousReceiptReports();
            FrmFGMiscellaneousReceiptReports.MdiParent = this;
            FrmFGMiscellaneousReceiptReports.Show();
        }

        private void iSSUEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFGMiscellaneousIssueReports FGMiscellaneousIssueReports = new FrmFGMiscellaneousIssueReports();
            FGMiscellaneousIssueReports.MdiParent = this;
            FGMiscellaneousIssueReports.Show();
        }

        private void fGInventoryTransactionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFGInventoryTransactionReport FGTransactionReport = new FrmFGInventoryTransactionReport();
            FGTransactionReport.MdiParent = this;
            FGTransactionReport.Show();
        }

        private void fGInventoryFeedcodeTransactionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFeedcodeTransactionReport FGFeedcodeTransactionReport = new FrmFeedcodeTransactionReport();
            FGFeedcodeTransactionReport.MdiParent = this;
            FGFeedcodeTransactionReport.Show();
        }

        private void fGStockOnHandReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myglobal.REPORT_NAME = "FGStockonhandReports";



            frmReport fr = new frmReport();
            fr.WindowState = FormWindowState.Maximized;
            fr.Show();
        }

        private void fGInventoryMovementReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFGInventoryMovementReport FGInventoryMovementReport = new FrmFGInventoryMovementReport();
            FGInventoryMovementReport.MdiParent = this;
            FGInventoryMovementReport.Show();
        }

        private void plateNumberManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPlatenumber platenumber = new FrmPlatenumber();
            platenumber.MdiParent = this;
            platenumber.Show();
        }

        private void fGVarianceReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myglobal.REPORT_NAME = "FGVarianceReport";



            frmReport fr = new frmReport();
            fr.WindowState = FormWindowState.Maximized;
            fr.Show();
        }

        private void fGTransactionVarianceReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTransactionVarianceReport transactvariancereport = new FrmTransactionVarianceReport();
            transactvariancereport.MdiParent = this;
            transactvariancereport.Show();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            timer3.Start();
            load_fgreceiving();
            load_Final_Buffer();
            if (SlowMovingIConCount.Text == "0")
            {
                SlowMovingICon.Visible = false;
                SlowMovingIConCount.Visible = false;

            }
            else
            {
                SlowMovingICon.Visible = true;
                //SlowMovingIConCount.Visible = true;
                NearlyExpired.Visible = true;
            }


            if (lblfgreceiving.Text == "0")
            {
                

            }

            else
            {
                NotifyFGReceiving();

            }
        }

        private void reprocessreportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmreprocessreport reprocess = new frmreprocessreport();
            reprocess.MdiParent = this;
            reprocess.Show();
        }

        private void repackingAdjustmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRepackingAdjustment repacking = new FrmRepackingAdjustment();
            repacking.MdiParent = this;
            repacking.Show();
            
        }

        private void finishedGoodsReprocessUniversalModuleToolStripMenu_Click(object sender, EventArgs e)
        {
            frmFGReprocessUniversalModule reprocessuniversal = new frmFGReprocessUniversalModule();
            reprocessuniversal.MdiParent = this;
            reprocessuniversal.Show();
        }

        private void taggingOfFeedTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTaggingofFeedtype tag = new frmTaggingofFeedtype();
            tag.MdiParent = this;
            tag.Show();
        }
    }
    
}
