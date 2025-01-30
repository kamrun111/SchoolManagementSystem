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
using SchoolManagementSystem.Reports;
using CrystalDecisions.CrystalReports.Engine;

namespace SchoolManagementSystem.Forms.Attendance
{
    public partial class FrmAttendance : BaseForm.FrmBase
    {
        public FrmAttendance()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime From = new DateTime(dtpFromDate.Value.Year, dtpFromDate.Value.Month, dtpFromDate.Value.Day, 0, 0, 0);
                DateTime To = new DateTime(dtpFromDate.Value.Year, dtpFromDate.Value.Month, dtpFromDate.Value.Day, 23, 59, 59);

                SqlConnection con = new SqlConnection("Data Source=FSCR-PC\\SQLEXPRESS;Initial Catalog=Attendance;User ID=sumon;Password=1234sumon123");
                //SqlConnection con = new SqlConnection("Data Source=KUKS-PC\\SQLEXPRESS;Initial Catalog=unis;User ID=sumon;Password=sumon123");
                SqlCommand cmd = new SqlCommand("LoadDate", con);
                cmd.CommandType=CommandType.StoredProcedure;
                con.Open();

                cmd.Parameters.AddWithValue("@From", From);
                cmd.Parameters.AddWithValue("@To", To);
                cmd.ExecuteNonQuery();


                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataTable dt = new DataTable();
                dt.Load(dr);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    grdAttendance.Rows.Add();
                    grdAttendance.Rows[i].Cells[0].Value = dt.Rows[i][0];
                    grdAttendance.Rows[i].Cells[1].Value = dt.Rows[i][1];
                    grdAttendance.Rows[i].Cells[2].Value = dt.Rows[i][2];
                    grdAttendance.Rows[i].Cells[3].Value = dt.Rows[i][3];
                }
     

                //grdAttendance.DataSource = dt;
            }
        



            
            catch
            {
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
              

                if(grdAttendance.Rows.Count!=0)
                {
                    CommonClass cs = new CommonClass();
                    DataSet ds = cs.GetDataSet("AttendanceLoad");/// save data
                    List<StudentAttendanceBO> listStudentAttendanceBO = new List<StudentAttendanceBO>();
                    List<TeacherAttendanceBO> listTeacherAttendanceBO = new List<TeacherAttendanceBO>();
                    List<StuffAttendanceBO> listStuffAttendanceBO = new List<StuffAttendanceBO>();
                    StudentAttendanceBLL studentAttendanceBLL=new StudentAttendanceBLL();

                    for (int i = 0; i < grdAttendance.Rows.Count; i++)
                    {
                        if (Convert.ToInt32(grdAttendance.Rows[i].Cells[2].Value) > 500)
                        {
                            StudentAttendanceBO studentAttendanceBO = new StudentAttendanceBO();
                            studentAttendanceBO.reg_no = Convert.ToInt32(grdAttendance.Rows[i].Cells[2].Value);
                            studentAttendanceBO.date = Convert.ToDateTime(grdAttendance.Rows[i].Cells[1].Value);
                            listStudentAttendanceBO.Add(studentAttendanceBO);
                        }
                        if ((Convert.ToInt32(grdAttendance.Rows[i].Cells[2].Value) >0 && Convert.ToInt32(grdAttendance.Rows[i].Cells[2].Value) <200  ))
                        {
                            TeacherAttendanceBO teacherAttendanceBO = new TeacherAttendanceBO();
                            teacherAttendanceBO.reg_no = Convert.ToInt32(grdAttendance.Rows[i].Cells[2].Value);
                            teacherAttendanceBO.date = Convert.ToDateTime(grdAttendance.Rows[i].Cells[1].Value);
                            listTeacherAttendanceBO.Add(teacherAttendanceBO);
                        }

                        if ((Convert.ToInt32(grdAttendance.Rows[i].Cells[2].Value) >200 && Convert.ToInt32(grdAttendance.Rows[i].Cells[2].Value)<500) )
                            
                        {
                            StuffAttendanceBO stuffAttendanceBO = new StuffAttendanceBO();
                            stuffAttendanceBO.reg_no = Convert.ToInt32(grdAttendance.Rows[i].Cells[2].Value);
                            stuffAttendanceBO.date = Convert.ToDateTime(grdAttendance.Rows[i].Cells[1].Value);
                            listStuffAttendanceBO.Add(stuffAttendanceBO);
                        }
                        
                        

                    }
                    int result = studentAttendanceBLL.AttendanceUpdate(listStudentAttendanceBO, listTeacherAttendanceBO, listStuffAttendanceBO);
                    if (result > 0)
                    {
                        MessageBox.Show("Data Saved Successfully");
                        btnSave.Enabled = false;
                    }
                    //DateTime From = new DateTime(dtpFromDate.Value.Year, dtpFromDate.Value.Month, dtpFromDate.Value.Day, 0, 0, 0);
                    //PrintTeacher(From);
                    //PrintStuff(From);


                }
            }
            catch
            {
            }
        }
        public void PrintTeacher(DateTime Date)
        {
            try
            {
                CrystalDecisions.Shared.TableLogOnInfo tliCurrent;
                ReportDocument rptCustomersOrders = new AttendanceReport();

                foreach (CrystalDecisions.CrystalReports.Engine.Table tbCurrent in rptCustomersOrders.Database.Tables)
                {
                    tliCurrent = tbCurrent.LogOnInfo;

                    tliCurrent.ConnectionInfo.ServerName = FormHelper.DBServerName;
                    tliCurrent.ConnectionInfo.UserID = FormHelper.DBUser; ;
                    tliCurrent.ConnectionInfo.Password = FormHelper.DBUserPassword;
                    tliCurrent.ConnectionInfo.DatabaseName = FormHelper.DBName;
                    tbCurrent.ApplyLogOnInfo(tliCurrent);
                }

                rptCustomersOrders.SetParameterValue("@datetime", Date);

                FrmGenericReportViewer frmGenericReportViewer = new FrmGenericReportViewer();
                frmGenericReportViewer.crvParameter.DisplayGroupTree = false;
                frmGenericReportViewer.crvParameter.ReportSource = rptCustomersOrders;
                frmGenericReportViewer.Show();

            }
            catch
            {
            }
        }
        public void PrintStuff(DateTime Date)
        {
            try
            {
                CrystalDecisions.Shared.TableLogOnInfo tliCurrent;
                ReportDocument rptCustomersOrders = new AttendanceReportStuff();

                foreach (CrystalDecisions.CrystalReports.Engine.Table tbCurrent in rptCustomersOrders.Database.Tables)
                {
                    tliCurrent = tbCurrent.LogOnInfo;

                    tliCurrent.ConnectionInfo.ServerName = FormHelper.DBServerName;
                    tliCurrent.ConnectionInfo.UserID = FormHelper.DBUser; ;
                    tliCurrent.ConnectionInfo.Password = FormHelper.DBUserPassword;
                    tliCurrent.ConnectionInfo.DatabaseName = FormHelper.DBName;
                    tbCurrent.ApplyLogOnInfo(tliCurrent);
                }

                rptCustomersOrders.SetParameterValue("@datetime", Date);

                FrmGenericReportViewer frmGenericReportViewer = new FrmGenericReportViewer();
                frmGenericReportViewer.crvParameter.DisplayGroupTree = false;
                frmGenericReportViewer.crvParameter.ReportSource = rptCustomersOrders;
                frmGenericReportViewer.Show();

            }
            catch
            {
            }
        }

        public void PrintStudent(DateTime Date)
        {
            try
            {
                CrystalDecisions.Shared.TableLogOnInfo tliCurrent;
                ReportDocument rptCustomersOrders = new AttendanceReportStudent();

                foreach (CrystalDecisions.CrystalReports.Engine.Table tbCurrent in rptCustomersOrders.Database.Tables)
                {
                    tliCurrent = tbCurrent.LogOnInfo;

                    tliCurrent.ConnectionInfo.ServerName = FormHelper.DBServerName;
                    tliCurrent.ConnectionInfo.UserID = FormHelper.DBUser; ;
                    tliCurrent.ConnectionInfo.Password = FormHelper.DBUserPassword;
                    tliCurrent.ConnectionInfo.DatabaseName = FormHelper.DBName;
                    tbCurrent.ApplyLogOnInfo(tliCurrent);
                }

                rptCustomersOrders.SetParameterValue("@datetime", Date);

                FrmGenericReportViewer frmGenericReportViewer = new FrmGenericReportViewer();
                frmGenericReportViewer.crvParameter.DisplayGroupTree = false;
                frmGenericReportViewer.crvParameter.ReportSource = rptCustomersOrders;
                frmGenericReportViewer.Show();

            }
            catch
            {
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DateTime From = new DateTime(dtpFromDate.Value.Year, dtpFromDate.Value.Month, dtpFromDate.Value.Day, 0, 0, 0);
            PrintTeacher(From);
            PrintStuff(From);
            PrintStudent(From);
        }

  
    }
}
