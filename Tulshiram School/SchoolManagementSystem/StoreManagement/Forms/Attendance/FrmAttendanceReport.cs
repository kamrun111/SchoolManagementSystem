using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SchoolManagementSystem.Forms;
using SchoolManagementSystem.BusinessObjects;
using SchoolManagementSystem.BLL;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using SchoolManagementSystem.Reports;

namespace SchoolManagementSystem.Forms.Attendance
{
    public partial class FrmAttendanceReport : BaseForm.FrmBase
    {
        public FrmAttendanceReport()
        {
            InitializeComponent();
        }
        CommonClass cs = new CommonClass();
        void GetLoad()
        {
            try
            {
                DataSet ds = cs.GetDataSet("AttendanceAllLoad");
                if (rdoStudent.Checked == true)
                    cs.PopulateComboBox(comboBox, ds, 0, "Name", "student_id");
                if (rdoTeacher.Checked == true)
                    cs.PopulateComboBox(comboBox, ds, 1, "teacher_name", "teacher_id");
                if (rdoStuff.Checked == true)
                    cs.PopulateComboBox(comboBox, ds, 2, "stuff_name", "stuff_id");
            }
            catch
            {
            }
            
        }

        private void FrmAttendanceReport_Load(object sender, EventArgs e)
        {
            GetLoad();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetLoad(); 
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime From = new DateTime(dtpFromDate.Value.Year, dtpFromDate.Value.Month, dtpFromDate.Value.Day, 0, 0, 0);
                DateTime To = new DateTime(dtpToDate.Value.Year, dtpToDate.Value.Month, dtpToDate.Value.Day, 23, 59, 59);
                if (rdoTeacher.Checked == true)
                    Print(From, To, 0);
                if (rdoStuff.Checked == true)
                    Print(From, To, 1);
                if (rdoStudent.Checked == true)
                    PrintStudent(From, To);


            }
            catch
            {
            }

        }
        public void Print(DateTime From,DateTime To,int teacher)
        {
            try
            {
                CrystalDecisions.Shared.TableLogOnInfo tliCurrent;
                ReportDocument rptCustomersOrders = new AttendanceReportDateWise();

                foreach (CrystalDecisions.CrystalReports.Engine.Table tbCurrent in rptCustomersOrders.Database.Tables)
                {
                    tliCurrent = tbCurrent.LogOnInfo;

                    tliCurrent.ConnectionInfo.ServerName = FormHelper.DBServerName;
                    tliCurrent.ConnectionInfo.UserID = FormHelper.DBUser; ;
                    tliCurrent.ConnectionInfo.Password = FormHelper.DBUserPassword;
                    tliCurrent.ConnectionInfo.DatabaseName = FormHelper.DBName;
                    tbCurrent.ApplyLogOnInfo(tliCurrent);
                }

                rptCustomersOrders.SetParameterValue("@From", From);
                rptCustomersOrders.SetParameterValue("@To", To);
                rptCustomersOrders.SetParameterValue("@teacher", teacher);


                FrmGenericReportViewer frmGenericReportViewer = new FrmGenericReportViewer();
                frmGenericReportViewer.crvParameter.DisplayGroupTree = false;
                frmGenericReportViewer.crvParameter.ReportSource = rptCustomersOrders;
                frmGenericReportViewer.Show();

            }
            catch
            {
            }
        }
        public void PrintStudent(DateTime From, DateTime To)
        {
            try
            {
                CrystalDecisions.Shared.TableLogOnInfo tliCurrent;
                ReportDocument rptCustomersOrders = new AttendanceReportStudentDateWise();

                foreach (CrystalDecisions.CrystalReports.Engine.Table tbCurrent in rptCustomersOrders.Database.Tables)
                {
                    tliCurrent = tbCurrent.LogOnInfo;

                    tliCurrent.ConnectionInfo.ServerName = FormHelper.DBServerName;
                    tliCurrent.ConnectionInfo.UserID = FormHelper.DBUser; ;
                    tliCurrent.ConnectionInfo.Password = FormHelper.DBUserPassword;
                    tliCurrent.ConnectionInfo.DatabaseName = FormHelper.DBName;
                    tbCurrent.ApplyLogOnInfo(tliCurrent);
                }

                rptCustomersOrders.SetParameterValue("@From", From);
                rptCustomersOrders.SetParameterValue("@To", To);


                FrmGenericReportViewer frmGenericReportViewer = new FrmGenericReportViewer();
                frmGenericReportViewer.crvParameter.DisplayGroupTree = false;
                frmGenericReportViewer.crvParameter.ReportSource = rptCustomersOrders;
                frmGenericReportViewer.Show();

            }
            catch
            {
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }




       
    }
}
