using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data.SqlClient;
using System.IO;
using System.Globalization;

namespace WFFDR
{
    public partial class frmmainreport : Form
    {

        myclasses xClass = new myclasses();

        //classess myClass = new classess();
        //ReportDocument rpt = new ReportDocument();
        ParameterDiscreteValue ParamValue = new ParameterDiscreteValue();
        ParameterFields ParamFields = new ParameterFields();
        ParameterField ParamField = new ParameterField();


        ParameterDiscreteValue ParamValue2 = new ParameterDiscreteValue();
        ParameterFields ParamFields2 = new ParameterFields();
        ParameterField ParamField2 = new ParameterField();



        ////public Ini.IniFile ini = new Ini.IniFile(Application.StartupPath + "\\config.ini");
        ParameterFieldDefinitions pFields;
        ParameterFieldDefinition pField;
        //ParameterFieldDefinition pField2;

        ParameterValues pValues = new ParameterValues();
        //ParameterValues pValues2 = new ParameterValues();

        ParameterDiscreteValue pDvalue = new ParameterDiscreteValue();

        ReportDocument rpt = new ReportDocument();
        string Rpt_Path = "";
        string hd;

        public frmmainreport()
        {
            InitializeComponent();
        }

        private void frmmainreport_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            displayReport();
            Rpt_Path = WFFDR.Properties.Settings.Default.fdg;

            xClass.ActivitiesLogs(userinfo.emp_name + " Generated " + myglobal.REPORT_NAME + " Report");
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



        void displayReport()
        {
            if (myglobal.REPORT_NAME == "ATTENDANCE_SUMMARY")
            {
                rpt.Load(Rpt_Path + "\\SummaryAttendanceReport.rpt");
                rpt.SetDatabaseLogon("sa", "Nescafe3in1");
                rpt.Refresh();

                if (myglobal.selected_only == 1)
                {
                    crV1.SelectionFormula = "{Command.leave_id} = " + myglobal.temp_id + "";
                }
                else if ((myglobal.with_date == 1) && (myglobal.selected_only == 0))
                {
                    crV1.SelectionFormula = "Date({Command.leave_date}) >= #" + myglobal.DATE_START + "# AND Date({Command.leave_date}) <= #" + myglobal.DATE_END + "#";
                }
                else if ((myglobal.selected_only == 1) && (myglobal.with_date == 1))
                {
                    crV1.SelectionFormula = "{Command.leave_id} = " + myglobal.temp_id + " AND Date({Command.leave_date}) >= #" + myglobal.DATE_START + "#";
                }
                //crV1.SelectionFormula = "Date({Command.leave_date}) >= #" + myglobal.DATE_START + "#";
                crV1.ReportSource = rpt;
                crV1.Refresh();
            }
            else if (myglobal.REPORT_NAME == "INCreport") // INCreport
            {
                rpt.Load(Rpt_Path + "\\IncompleteLogs.rpt");
                rpt.SetDatabaseLogon("sa", "Nescafe3in1");
                rpt.Refresh();
                rpt.SetParameterValue("@date", myglobal.DATE_START.ToString("yyyy-MM-dd"));
                crV1.ReportSource = rpt;
                crV1.Refresh();
            }
            else if (myglobal.REPORT_NAME == "AttendancePerSickness")
            {
                rpt.Load(Rpt_Path + "\\AttendancePerSickness.rpt");
                rpt.SetDatabaseLogon("sa", "Nescafe3in1");
                rpt.Refresh();

                crV1.SelectionFormula = "{Command.sickness_id} = " + myglobal.temp_id + "";
                crV1.ReportSource = rpt;
                crV1.Refresh();
            }
            else if (myglobal.REPORT_NAME == "AttendancePerDepartment")
            {
                rpt.Load(Rpt_Path + "\\AttendancePerDepartment.rpt");
                rpt.SetDatabaseLogon("sa", "Nescafe3in1");
                rpt.Refresh();

                if (myglobal.with_date == 1)
                {
                    crV1.SelectionFormula = "{Command.department_id} = " + myglobal.temp_id + " AND Date({Command.leave_date}) >= #" + myglobal.DATE_START + "# AND Date({Command.leave_date}) >= #" + myglobal.DATE_END + "#";
                }
                else
                {
                    crV1.SelectionFormula = "{Command.department_id} = " + myglobal.temp_id + "";
                }

                crV1.ReportSource = rpt;
                crV1.Refresh();
            }

            else if (myglobal.REPORT_NAME == "SICKNESS_SUMMARY")
            {
                rpt.Load(Rpt_Path + "\\SicknessReport.rpt");
                rpt.SetDatabaseLogon("sa", "Nescafe3in1");
                rpt.Refresh();

                crV1.SelectionFormula = "Date({Command.leave_date}) >= #" + myglobal.DATE_START + "# AND Date({Command.leave_date}) >= #" + myglobal.DATE_END + "#";
                crV1.ReportSource = rpt;
                crV1.Refresh();
            }
            else if (myglobal.REPORT_NAME == "TARDINESS")
            {
                rpt.Load(Rpt_Path + "\\TardinessReport.rpt");
                rpt.SetDatabaseLogon("sa", "Nescafe3in1");
                rpt.Refresh();

                crV1.SelectionFormula = "Date({Command.date_late}) >= #" + myglobal.DATE_START + "#";
                crV1.ReportSource = rpt;
                crV1.Refresh();
            }
  
            else if (myglobal.REPORT_NAME == "DailyTimeRecordPerEmployee")
            {


                if ((myglobal.selected_only == 1) && (myglobal.with_date == 0))
                {
                    rpt.Load(Rpt_Path + "\\DailyTimeRecordPerEmployee.rpt");
                    rpt.SetDatabaseLogon("sa", "Nescafe3in1");
                    rpt.Refresh();

                    crV1.SelectionFormula = "{Command.employee_id} = " + myglobal.temp_id + "";

                    crV1.ReportSource = rpt;
                    crV1.Refresh();
                }
                else if ((myglobal.selected_only == 1) && (myglobal.with_date == 1))
                {
                    rpt.Load(Rpt_Path + "\\DailyTimeRecordPerEmployee1.rpt");
                    rpt.SetDatabaseLogon("sa", "Nescafe3in1");
                    rpt.Refresh();

                    rpt.SetParameterValue("@a", myglobal.DATE_START);
                    rpt.SetParameterValue("@b", myglobal.DATE_END);
                    rpt.SetParameterValue("@c", myglobal.temp_id);
                    rpt.SetParameterValue("@d", myglobal.employee_name);
                    //crV1.SelectionFormula = "{Command.employee_id} = " + Convert.ToString(myglobal.temp_id) + " AND Date({Command.attendance_date}) >= #" + myglobal.DATE_START + "# AND Date({Command.attendance_date}) <= #" + myglobal.DATE_END + "#";

                    crV1.ReportSource = rpt;
                    crV1.Refresh();
                }
                else if (myglobal.with_date == 1)
                {
                    rpt.Load(Rpt_Path + "\\DailyTimeRecordPerEmployeeAS.rpt");
                    rpt.SetDatabaseLogon("sa", "Nescafe3in1");
                    rpt.Refresh();

                    rpt.SetParameterValue("@a", myglobal.DATE_START);
                    rpt.SetParameterValue("@b", myglobal.DATE_END);
                    //crV1.SelectionFormula = "Date({Command.attendance_date}) >= #" + myglobal.DATE_START + "# AND Date({Command.attendance_date}) <= #" + myglobal.DATE_END + "#";

                    crV1.ReportSource = rpt;
                    crV1.Refresh();
                }
            }

            else if (myglobal.REPORT_NAME == "BARCODE")
            {
                rpt.Load(Rpt_Path + "\\BarCode.rpt");
                rpt.SetDatabaseLogon("sa", "Nescafe3in1");
                rpt.Refresh();

                crV1.SelectionFormula = "{Command.employee_id} = " + myglobal.temp_id + "";
                crV1.ReportSource = rpt;
                crV1.Refresh();
            }
            else if (myglobal.REPORT_NAME == "EmployeeList")
            {
                rpt.Load(Rpt_Path + "\\EmployeeList.rpt");
                rpt.SetDatabaseLogon("sa", "Nescafe3in1");
                rpt.Refresh();

                //crV1.SelectionFormula = "{Command.employee_id} = " + myglobal.temp_id + "";
                crV1.ReportSource = rpt;
                crV1.Refresh();
            }
            else if (myglobal.REPORT_NAME == "Absent")
            {
                rpt.Load(Rpt_Path + "\\ListofAbsent.rpt");
                rpt.SetDatabaseLogon("sa", "Nescafe3in1");
                rpt.Refresh();

                //crV1.SelectionFormula = "DATE({Command.Attendance_Date}) = DATE('" + myglobal.DATE_REPORT + "')";
                //crV1.ReportSource = rpt;
                //crV1.Refresh();
                string ddate = myglobal.DATE_START.ToString("yyyy-MM-dd");
                rpt.SetParameterValue("@attendance", "'" + ddate + "'");

                //single_parameter("@attendance", myglobal.DATE_START);
                crV1.ReportSource = rpt;
                crV1.Refresh();
            }
            else if (myglobal.REPORT_NAME == "MANPOWER")
            {
                rpt.Load(Rpt_Path + "\\MIS.rpt");
                rpt.SetDatabaseLogon("sa", "Nescafe3in1");
                rpt.Refresh();

                crV1.ReportSource = rpt;
                crV1.Refresh();
            }
  

            else if (myglobal.REPORT_NAME == "late2")
            {
                rpt.Load(Rpt_Path + "\\late2.rpt");
                rpt.SetDatabaseLogon("sa", "Nescafe3in1");
                rpt.Refresh();

                if (myglobal.Filter == "employee_number")
                {
                    crV1.SelectionFormula = "Date({Command.Expr1003}) IN DateValue( #" + myglobal.DATE_START + "# ) TO DateValue (#" + myglobal.DATE_END + "#) and  {Command.employee_number} like '*" + myglobal.Searchcategory + "*'";
                    ParamField.Name = "Department";
                    ParamValue.Value = "";
                }
                else if (myglobal.Filter == "firstname")
                {
                    crV1.SelectionFormula = "Date({Command.Expr1003}) IN DateValue( #" + myglobal.DATE_START + "# ) TO DateValue (#" + myglobal.DATE_END + "#) and  {Command.firstname} like '*" + myglobal.Searchcategory + "*'";
                    ParamField.Name = "Department";
                    ParamValue.Value = "";
                }
                else if (myglobal.Filter == "lastname" || myglobal.Filter == "All")
                {
                    crV1.SelectionFormula = "Date({Command.Expr1003}) IN DateValue( #" + myglobal.DATE_START + "# ) TO DateValue (#" + myglobal.DATE_END + "#) and  {Command.lastname} like '*" + myglobal.Searchcategory + "*'";
                    ParamField.Name = "Department";
                    ParamValue.Value = "";

                }
                else if (myglobal.Filter == "Department")
                {
                    crV1.SelectionFormula = "Date({Command.Expr1003}) >= DateValue( #" + myglobal.DATE_START + "# ) and Date({Command.Expr1003}) <= DateValue (#" + myglobal.DATE_END + "#)  and  {Command.department_id} = " + myglobal.department_id + "";
                    ParamField.Name = "Department";
                    ParamValue.Value = myglobal.department_name;



                }

                ParamField.CurrentValues.Add(ParamValue);
                ParamFields.Add(ParamField);
                crV1.ParameterFieldInfo = ParamFields;
                crV1.ReportSource = rpt;
                crV1.Refresh();
            }




            else if (myglobal.REPORT_NAME == "Loan_List")
            {
                rpt.Load(Rpt_Path + "\\Loan_List.rpt");
                rpt.SetDatabaseLogon("sa", "Nescafe3in1");
                rpt.Refresh();
                //if (myglobal.Filter == "Loan_from")
                //{



                //    crV1.SelectionFormula = "{Command.Loan_from} like '*" + myglobal.loan_from + "*' AND  {Command.Loan_Type} like '*" + myglobal.loan_type + "*' ";

                //}
                //else
                //{

                //    crV1.SelectionFormula = "{Command." + myglobal.Filter + "} like '*" + myglobal.Searchcategory + "*'";



                //}
                crV1.ReportSource = rpt;
                crV1.Refresh();
            }
            else if (myglobal.REPORT_NAME == "Loan_Spreadsheet")
            {
                rpt.Load(Rpt_Path + "\\Loan_Spreadsheet.rpt");
                rpt.SetDatabaseLogon("sa", "Nescafe3in1");
                rpt.SetParameterValue("@a", myglobal.ln_type);
                rpt.SetParameterValue("@b", myglobal.ln_worksheet);
                rpt.SetParameterValue("@title", myglobal.ln_title);
                rpt.SetParameterValue("@Fl", myglobal.loan_filter);
                rpt.SetParameterValue("@Fl1", myglobal.loan_filter1);

                crV1.ReportSource = rpt;
                crV1.Refresh();
            }
            else if (myglobal.REPORT_NAME == "Loan_History")
            {
                rpt.Load(Rpt_Path + "\\Loan_History.rpt");
                rpt.SetDatabaseLogon("sa", "Nescafe3in1");
                rpt.Refresh();



                if (myglobal.Filter == "Loan_from")
                {



                    crV1.SelectionFormula = "{Command.Loan_from} like '*" + myglobal.loan_from + "*' AND  {Command.Loan_Type} like '*" + myglobal.loan_type + "*' ";

                }
                else
                {

                    crV1.SelectionFormula = "{Command." + myglobal.Filter + "} like '*" + myglobal.Searchcategory + "*'";



                }
                crV1.ReportSource = rpt;
                crV1.Refresh();
            }




            else if (myglobal.REPORT_NAME == "Loan_breakdown")
            {
                rpt.Load(Rpt_Path + "\\Loan_breakdown.rpt");
                rpt.SetDatabaseLogon("sa", "Nescafe3in1");
                rpt.Refresh();
                if (myglobal.Filter == "Loan_from")
                {



                    crV1.SelectionFormula = "{Command.Loan_from} like '*" + myglobal.loan_from + "*' AND  {Command.Loan_Type} like '*" + myglobal.loan_type + "*' ";

                }
                else
                {

                    crV1.SelectionFormula = "{Command." + myglobal.Filter + "} like '*" + myglobal.Searchcategory + "*'";



                }
                crV1.ReportSource = rpt;
                crV1.Refresh();
            }
            else if (myglobal.REPORT_NAME == "SeperatedEmployees")
            {
                rpt.Load(Rpt_Path + "\\SeperatedEmployees.rpt");
                rpt.SetDatabaseLogon("sa", "Nescafe3in1");
                rpt.Refresh();
                rpt.SetParameterValue("@year", myglobal.etc);
                crV1.ReportSource = rpt;
                crV1.Refresh();
            }

            else if (myglobal.REPORT_NAME == "DASummary")
            {
                rpt.Load(Rpt_Path + "\\DAReport.rpt");
                rpt.SetDatabaseLogon("sa", "Nescafe3in1");
                rpt.Refresh();
                crV1.SelectionFormula = "Date({Command.date_posted}) >= #" + myglobal.DATE_START + "# AND Date({Command.date_posted}) <= #" + myglobal.DATE_END + "#";
                rpt.SetParameterValue("@dep", myglobal.position);
                crV1.ReportSource = rpt;
                crV1.Refresh();
            }
            else if (myglobal.REPORT_NAME == "DASummaryWithDep")
            {
                rpt.Load(Rpt_Path + "\\DAReport.rpt");
                rpt.SetDatabaseLogon("sa", "Nescafe3in1");
                rpt.Refresh();
                crV1.SelectionFormula = "Date({Command.date_posted}) >= #" + myglobal.DATE_START + "# AND Date({Command.date_posted}) <= #" + myglobal.DATE_END + "# AND {Command.department_id} = " + myglobal.temp_number + "";
                rpt.SetParameterValue("@dep", myglobal.position);
                crV1.ReportSource = rpt;
                crV1.Refresh();
            }
            else if (myglobal.REPORT_NAME == "DASummaryPerEmployee")
            {
                rpt.Load(Rpt_Path + "\\DAPerEmployee.rpt");
                rpt.SetDatabaseLogon("sa", "Nescafe3in1");
                rpt.Refresh();

                if (myglobal.selected_only == 1 && myglobal.with_date == 0)
                {
                    crV1.SelectionFormula = "{Command.employee_id} = " + myglobal.temp_id + " AND {Command.offense_description} = '" + myglobal.offense_description + "'";
                }

                else if (myglobal.selected_only == 1 && myglobal.with_date == 1)
                {
                    crV1.SelectionFormula = "{Command.employee_id} = " + myglobal.temp_id + " AND {Command.offense_description} = '" + myglobal.offense_description + "' AND Date({Command.date_posted}) IN DateValue( #" + myglobal.DATE_START + "# ) TO DateValue (#" + myglobal.DATE_END + "#)";
                }
                else if (myglobal.selected_only == 0 && myglobal.with_date == 1)
                {
                    crV1.SelectionFormula = "{Command.employee_id} = " + myglobal.temp_id + " AND Date({Command.date_posted}) IN DateValue( #" + myglobal.DATE_START + "# ) TO DateValue (#" + myglobal.DATE_END + "#)";
                }
                else
                {
                    crV1.SelectionFormula = "{Command.employee_id} = " + myglobal.temp_id + "";
                }
                crV1.ReportSource = rpt;
                crV1.Refresh();
            }
            else if (myglobal.REPORT_NAME == "AttendanceSummaryA")
            {
                rpt.Load(Rpt_Path + "\\AttendanceSummaryA.rpt");
                rpt.SetDatabaseLogon("sa", "Nescafe3in1");
                rpt.Refresh();

                // if (myglobal.with_date == 1)
                // {
                crV1.SelectionFormula = "{Command.employee_id} = " + myglobal.temp_id + " AND Date({Command.DateOfLeave}) >= #" + myglobal.DATE_START + "# AND Date({Command.DateOfLeave}) <= #" + myglobal.DATE_END + "#";
                // }
                //else
                //{
                //    crV1.SelectionFormula = "{Command.department_id} = " + myglobal.temp_id + "";
                //}

                crV1.ReportSource = rpt;
                crV1.Refresh();
            }

            else if (myglobal.REPORT_NAME == "IDReport")
            {
                rpt.Load(Rpt_Path + "\\IDReport.rpt");
                ////////rpt.SetDatabaseLogon("sa", "Nescafe3in1");
                rpt.Refresh();

                crV1.SelectionFormula = "{Command.lastname} like '*" + myglobal.Searchcategory + "*' or  {Command.firstname} like '*" + myglobal.Searchcategory + "*'or  {Command.department_name} like '*" + myglobal.Searchcategory + "*' or  {Command.position_name} like '*" + myglobal.Searchcategory + "*' AND  {Command.employment_status_name} like '*" + myglobal.Filter + "*'";




                //ParamField.Name = "Approved";
                //ParamValue.Value = myglobal.employee_name ;
                //ParamField.CurrentValues.Add(ParamValue);
                //ParamFields.Add(ParamField);
                //ParamField2.Name = "Validity";
                //ParamValue2.Value = myglobal.validity ;
                //ParamField2.CurrentValues.Add(ParamValue2);
                //ParamFields2.Add(ParamField2);=
                //crV1.ParameterFieldInfo = ParamFields;
                //crV1.ParameterFieldInfo = ParamFields2;

                rpt.SetParameterValue("Approved", myglobal.employee_name);
                rpt.SetParameterValue("Validity", myglobal.validity);
                rpt.SetParameterValue("Position", myglobal.position);

                crV1.ReportSource = rpt;
                crV1.Refresh();
            }

            else if (myglobal.REPORT_NAME == "IDRepackReport")
            {
                rpt.Load(Rpt_Path + "\\IDRepackReport.rpt");
                ////////rpt.SetDatabaseLogon("sa", "Nescafe3in1");
                rpt.Refresh();

                crV1.SelectionFormula = "{Command.rp_item_description} like '*" + myglobal.Searchcategory + "*' or  {Command.rp_classification} like '*" + myglobal.Searchcategory + "*'or  {Command.rp_item_code} like '*" + myglobal.Searchcategory + "*' or  {Command.rp_mfg_date} like '*" + myglobal.Searchcategory + "*'  AND  {Command.rp_expiry_date} like '*" + myglobal.Filter + "*'";




                //ParamField.Name = "Approved";
                //ParamValue.Value = myglobal.employee_name ;
                //ParamField.CurrentValues.Add(ParamValue);
                //ParamFields.Add(ParamField);
                //ParamField2.Name = "Validity";
                //ParamValue2.Value = myglobal.validity ;
                //ParamField2.CurrentValues.Add(ParamValue2);
                //ParamFields2.Add(ParamField2);=
                //crV1.ParameterFieldInfo = ParamFields;
                //crV1.ParameterFieldInfo = ParamFields2;

                rpt.SetParameterValue("Approved", myglobal.rp_item_description);
                rpt.SetParameterValue("Validity", myglobal.validity);
                rpt.SetParameterValue("Position", myglobal.position);

                crV1.ReportSource = rpt;
                crV1.Refresh();
            }

            else if (myglobal.REPORT_NAME == "MicroBook")
            {
                rpt.Load(Rpt_Path + "\\MicroBook.rpt");
                ////////rpt.SetDatabaseLogon("sa", "Nescafe3in1");
                rpt.Refresh();

                crV1.SelectionFormula = "{Command.rp_item_description} like '*" + myglobal.Searchcategory + "*' or  {Command.rp_classification} like '*" + myglobal.Searchcategory + "*'or  {Command.rp_item_code} like '*" + myglobal.Searchcategory + "*' or  {Command.rp_mfg_date} like '*" + myglobal.Searchcategory + "*'  AND  {Command.rp_expiry_date} like '*" + myglobal.Filter + "*'";




                //ParamField.Name = "Approved";
                //ParamValue.Value = myglobal.employee_name ;
                //ParamField.CurrentValues.Add(ParamValue);
                //ParamFields.Add(ParamField);
                //ParamField2.Name = "Validity";
                //ParamValue2.Value = myglobal.validity ;
                //ParamField2.CurrentValues.Add(ParamValue2);
                //ParamFields2.Add(ParamField2);=
                //crV1.ParameterFieldInfo = ParamFields;
                //crV1.ParameterFieldInfo = ParamFields2;

                rpt.SetParameterValue("Approved", myglobal.rp_item_description);
                rpt.SetParameterValue("Validity", myglobal.validity);
                rpt.SetParameterValue("Position", myglobal.position);

                crV1.ReportSource = rpt;
                crV1.Refresh();
            }
            else if (myglobal.REPORT_NAME == "IDReport(HW)")
            {
                rpt.Load(Rpt_Path + "\\IDReport(HW).rpt");
                rpt.SetDatabaseLogon("sa", "Nescafe3in1");
                rpt.Refresh();

                crV1.SelectionFormula = "{Command.lastname} like '*" + myglobal.Searchcategory + "*' or  {Command.firstname} like '*" + myglobal.Searchcategory + "*'or  {Command.department_name} like '*" + myglobal.Searchcategory + "*' or  {Command.position_name} like '*" + myglobal.Searchcategory + "*' AND  {Command.employment_status_name} like '*" + myglobal.Filter + "*'";




                //ParamField.Name = "Approved";
                //ParamValue.Value = myglobal.employee_name ;
                //ParamField.CurrentValues.Add(ParamValue);
                //ParamFields.Add(ParamField);
                //ParamField2.Name = "Validity";
                //ParamValue2.Value = myglobal.validity ;
                //ParamField2.CurrentValues.Add(ParamValue2);
                //ParamFields2.Add(ParamField2);=
                //crV1.ParameterFieldInfo = ParamFields;
                //crV1.ParameterFieldInfo = ParamFields2;

                rpt.SetParameterValue("Approved", myglobal.employee_name);
                rpt.SetParameterValue("Validity", myglobal.validity);
                rpt.SetParameterValue("Position", myglobal.position);

                crV1.ReportSource = rpt;
                crV1.Refresh();
            }
            else if (myglobal.REPORT_NAME == "LEAVE_REPORT")
            {
                rpt.Load(Rpt_Path + "\\LeaveReport.rpt");
                rpt.SetDatabaseLogon("sa", "Nescafe3in1");
                rpt.Refresh();


                //crV1.SelectionFormula = "{Command.ID} = " + myglobal.temp_id + "";

                //rpt.SetParameterValue("@startdate", myglobal.DATE_START);
                //rpt.SetParameterValue("@enddate", myglobal.DATE_END);
                //rpt.SetParameterValue("Position", myglobal.position);

                crV1.ReportSource = rpt;
                crV1.Refresh();
            }
            else if (myglobal.REPORT_NAME == "LEAVE_REPORTB1")
            {
                rpt.Load(Rpt_Path + "\\LeaveReportB1.rpt");
                rpt.SetDatabaseLogon("sa", "Nescafe3in1");
                rpt.Refresh();


                if (myglobal.rptflag == 1)
                {
                    //crV1.SelectionFormula = "{Command.employee_id} = " + Convert.ToString(myglobal.temp_id) + " AND Date({Command.attendance_date}) >= #" + myglobal.DATE_START + "# AND Date({Command.attendance_date}) <= #" + myglobal.DATE_END + "#";
                    //crV1.SelectionFormula = "{Command.ID} = " + myglobal.temp_id + "";
                    crV1.SelectionFormula = "{Command.ID} = " + myglobal.temp_id + " AND Date({Command.date_created}) >= #" + myglobal.DATE_START + "# AND Date({Command.date_created}) <= #" + myglobal.DATE_END + "#";

                }
                else if (myglobal.rptflag == 2)
                {
                    //crV1.SelectionFormula = "{Command.ID} = " + myglobal.temp_id + "";
                    crV1.SelectionFormula = "Date({Command.date_created}) >= #" + myglobal.DATE_START + "# AND Date({Command.date_created}) <= #" + myglobal.DATE_END + "#";
                }
                //crV1.SelectionFormula = "{Command.ID} = " + myglobal.temp_id + "";

                //rpt.SetParameterValue("@startdate", myglobal.DATE_START);
                //rpt.SetParameterValue("@enddate", myglobal.DATE_END);
                //rpt.SetParameterValue("Position", myglobal.position);


                crV1.ReportSource = rpt;
                crV1.Refresh();

            }

            else if (myglobal.REPORT_NAME == "VisitorsReport")
            {
                rpt.Load(Rpt_Path + "\\VisitorsReport.rpt");
                rpt.SetDatabaseLogon("sa", "Nescafe3in1");
                rpt.Refresh();

                crV1.SelectionFormula = "Date({Command.DATE}) >= #" + myglobal.DATE_START + "# AND Date({Command.DATE}) <= #" + myglobal.DATE_END + "#";


                rpt.SetParameterValue("@startdate", myglobal.DATE_START.ToString("dd/MM/yyyy"));
                rpt.SetParameterValue("@enddate", myglobal.DATE_END.ToString("dd/MM/yyyy"));
                //rpt.SetParameterValue("Position", myglobal.position);

                crV1.ReportSource = rpt;
                crV1.Refresh();
            }
            else if (myglobal.REPORT_NAME == "AbsentReporNew")
            {


                if (myglobal.temp_id != 1)
                    rpt.Load(Rpt_Path + "\\ARall.rpt");
                else
                    rpt.Load(Rpt_Path + "\\ARallWith.rpt");
                rpt.SetDatabaseLogon("sa", "Nescafe3in1");
                rpt.Refresh();
                string ddate = myglobal.DATE_START.ToString("yyyy-MM-dd");
                rpt.SetParameterValue("@ddate", ddate);
                //rpt.SetParameterValue("@ddate", myglobal.DATE_START.ToString("dd/MM/yyyy"));
                //rpt.SetParameterValue("@ddate",DateTime.Now.ToString("yyyy-MM-dd"));
                //rpt.SetParameterValue("@ddate","2018-03-10");
                //rpt.SetParameterValue("Position", myglobal.position);
                crV1.ReportSource = rpt;
                crV1.Refresh();

            }
            else if (myglobal.REPORT_NAME == "Absentbydep")
            {

                if (myglobal.temp_id != 1)
                    rpt.Load(Rpt_Path + "\\AR1.rpt");
                else
                    rpt.Load(Rpt_Path + "\\AR1With.rpt");

                rpt.SetDatabaseLogon("sa", "Nescafe3in1");
                rpt.Refresh();
                string ddate = myglobal.DATE_START.ToString("yyyy-MM-dd");
                rpt.SetParameterValue("@ddate", ddate);
                rpt.SetParameterValue("@bb", myglobal.swtcherprint);


                //rpt.SetParameterValue("@ddate", myglobal.DATE_START.ToString("dd/MM/yyyy"));
                //rpt.SetParameterValue("@ddate",DateTime.Now.ToString("yyyy-MM-dd"));
                //rpt.SetParameterValue("@ddate","2018-03-10");
                //rpt.SetParameterValue("Position", myglobal.position);
                crV1.ReportSource = rpt;
                crV1.Refresh();

            }
            else if (myglobal.REPORT_NAME == "DailyLate")
            {


                rpt.Load(Rpt_Path + "\\DailyReportLate.rpt");
                rpt.SetDatabaseLogon("sa", "Nescafe3in1");
                rpt.Refresh();
                string ddate = myglobal.DATE_REPORT;
                rpt.SetParameterValue("@ddate", ddate);

                //rpt.SetParameterValue("@ddate", myglobal.DATE_START.ToString("dd/MM/yyyy"));
                //rpt.SetParameterValue("@ddate",DateTime.Now.ToString("yyyy-MM-dd"));
                //rpt.SetParameterValue("@ddate","2018-03-10");
                //rpt.SetParameterValue("Position", myglobal.position);
                crV1.ReportSource = rpt;
                crV1.Refresh();

            }
            else if (myglobal.REPORT_NAME == "bdaygen")
            {



                rpt.Load(Rpt_Path + "\\bdaygen.rpt");
                rpt.SetDatabaseLogon("sa", "Nescafe3in1");
                rpt.Refresh();
                string ddate = myglobal.DATE_REPORT;


                rpt.SetParameterValue("@d", "'" + Convert.ToInt32((Convert.ToDateTime(myglobal.DATE_REPORT).ToString("MM"))).ToString() + "'");
                rpt.SetParameterValue("datename", @"Birthday Celebrants for the Month of " + Convert.ToDateTime(myglobal.DATE_REPORT).ToString("MMMM yyyy"));
              //  rpt.SetParameterValue("@printedby", "Printed By: " + CultureInfo.CurrentCulture.TextInfo.ToTitleCase(userinfo.emp_name.ToLower()));
                //rpt.SetParameterValue("@ddate", myglobal.DATE_START.ToString("dd/MM/yyyy"));
                //rpt.SetParameterValue("@ddate",DateTime.Now.ToString("yyyy-MM-dd"));
                //rpt.SetParameterValue("@ddate","2018-03-10");
                //rpt.SetParameterValue("Position", myglobal.position);
                crV1.ReportSource = rpt;
                crV1.Refresh();

            }

            else if (myglobal.REPORT_NAME == "lmRemoved")
            {
                rpt.Load("C:/Reports/RemovedFromLoanList.rpt"); //RemovedFromLoanList
                rpt.SetDatabaseLogon("sa", "Nescafe3in1");
                rpt.Refresh();
                rpt.SetParameterValue("@a", myglobal.loan_from_type);
                if (myglobal.loan_from_type == "PAG-IBIG")
                {
                    hd = "HDMF";
                }
                else if (myglobal.loan_from_type == "SSS")
                {
                    hd = "SSS";
                }
                rpt.SetParameterValue("@b", hd);
                crV1.ReportSource = rpt;
                crV1.Refresh();
            }

            else if (myglobal.REPORT_NAME == "OTReport")
            {
                rpt.Load("C:/Reports/listofreqot.rpt"); //RemovedFromLoanList
                rpt.SetDatabaseLogon("sa", "Nescafe3in1");
                rpt.Refresh();
                rpt.SetParameterValue("@date", myglobal.DATE_REPORT);
                crV1.ReportSource = rpt;
                crV1.Refresh();
            } // OTSchedReport

            else if (myglobal.REPORT_NAME == "OTSchedReport")
            {
                rpt.Load("C:/Reports/listofschedot.rpt"); //RemovedFromLoanList
                rpt.SetDatabaseLogon("sa", "Nescafe3in1");
                rpt.Refresh();
                rpt.SetParameterValue("@date", myglobal.DATE_REPORT);
                crV1.ReportSource = rpt;
                crV1.Refresh();
            } // OTSchedReport
            else if (myglobal.REPORT_NAME == "OTDTR")
            {
                rpt.Load("C:/Reports/DTR(OT).rpt"); //RemovedFromLoanList
                rpt.SetDatabaseLogon("sa", "Nescafe3in1");
                rpt.Refresh();
                rpt.SetParameterValue("@a", Convert.ToString(myglobal.DATE_START.ToString("yyyy-MM-dd")));
                rpt.SetParameterValue("@b", Convert.ToString(myglobal.DATE_END.ToString("yyyy-MM-dd")));
                rpt.SetParameterValue("@c", myglobal.temp_id);
                rpt.SetParameterValue("@d", myglobal.employee_name);
                crV1.ReportSource = rpt;
                crV1.Refresh();
            }
            else if (myglobal.REPORT_NAME == "empexp")
            {
                rpt.Load("C:/Reports/empexpiry.rpt"); //RemovedFromLoanList
                rpt.SetDatabaseLogon("sa", "Nescafe3in1");
                rpt.Refresh();
                rpt.SetParameterValue("@startdate", myglobal.DATE_START.ToString("yyyy-MM-dd"));
                rpt.SetParameterValue("@enddate", myglobal.DATE_END.ToString("yyyy-MM-dd"));
                crV1.ReportSource = rpt;
                crV1.Refresh();
            }
            else if (myglobal.REPORT_NAME == "empeval")
            {
                rpt.Load("C:/Reports/evaluationperiod.rpt"); //RemovedFromLoanList
                rpt.SetDatabaseLogon("sa", "Nescafe3in1");
                rpt.Refresh();
                rpt.SetParameterValue("@month", myglobal.DATE_START.ToString("yyyy-MM"));
                rpt.SetParameterValue("@monthname", myglobal.DATE_START.Month.ToString("MMMM"));
                rpt.SetParameterValue("@start", myglobal.DATE_START.ToString("yyyy-MM-dd"));
                rpt.SetParameterValue("@end", myglobal.DATE_END.ToString("yyyy-MM-dd"));
                crV1.ReportSource = rpt;
                crV1.Refresh();
            }
            else if (myglobal.REPORT_NAME == "empecomplement")
            {
                rpt.Load("C:/Reports/EmployeesComplement.rpt"); //RemovedFromLoanList
                rpt.SetDatabaseLogon("sa", "Nescafe3in1");
                rpt.Refresh();
                crV1.ReportSource = rpt;
                crV1.Refresh();
            }
        }




        private void MacroBook1_InitReport(object sender, EventArgs e)
        {

        }
    }
}
