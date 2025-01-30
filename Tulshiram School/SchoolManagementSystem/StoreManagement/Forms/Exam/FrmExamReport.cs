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
using SchoolManagementSystem.Reports;
using CrystalDecisions.CrystalReports.Engine;

namespace SchoolManagementSystem.Forms.Exam
{
    public partial class FrmExamReport : BaseForm.FrmBase
    {
        public FrmExamReport()
        {
            InitializeComponent();
        }
        CommonClass cs = new CommonClass();


        void GetLoad()
        {
            try
            {
                cmbExam.SelectedIndexChanged -= new EventHandler(cmbExam_SelectedIndexChanged);
                DataSet ds = cs.GetDataSet("StudentComboLoad");
                cs.PopulateComboBox(cmbsession, ds, 1, "session", "session_id");
                cs.PopulateComboBox(cmbExam, ds, 11, "exam_name", "exam_id");
                cmbExam.SelectedIndexChanged += new EventHandler(cmbExam_SelectedIndexChanged);
                grdStudentList.Rows.Clear();



            }
            catch
            {
            }
        }
   

        private void FrmExamReport_Load(object sender, EventArgs e)
        {
            GetLoad();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmbExam_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbClass.SelectedIndexChanged -= new EventHandler(cmbClass_SelectedIndexChanged);
                if (cmbExam.SelectedIndex > -1)
                {

                    DataSet ds = cs.GetDataSetWithParameter("@class_id", Convert.ToInt32(cmbExam.SelectedValue), "StudentSectionLoad");
                    if (ds.Tables[2].Rows.Count > 0)
                        cs.PopulateComboBox(cmbClass, ds, 2, "class_name", "class_id");


                }

                cmbClass.SelectedIndexChanged += new EventHandler(cmbClass_SelectedIndexChanged);
            }
            catch
            {
            }
        }

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (cmbClass.SelectedIndex > -1)
                {

                    DataSet ds = cs.GetDataSetWithParameter("@class_id", Convert.ToInt32(cmbClass.SelectedValue), "StudentSectionLoad");
                    if (ds.Tables[0].Rows.Count > 0)
                        cs.PopulateComboBox(cmbSection, ds, 0, "section_name", "section_id");

                }
                

            }
            catch
            {
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdoTabulation.Checked == true)
                    PrintTabulation(Convert.ToInt32(cmbsession.SelectedValue), Convert.ToInt32(cmbExam.SelectedValue), Convert.ToInt32(cmbClass.SelectedValue), Convert.ToInt32(cmbSection.SelectedValue));
                if(rdoStudentFail.Checked==true)
                    TotalFailReport(Convert.ToInt32(cmbsession.SelectedValue), Convert.ToInt32(cmbExam.SelectedValue),1);
                if (rdoGradeReport.Checked == true)
                    GradeReport(Convert.ToInt32(cmbsession.SelectedValue), Convert.ToInt32(cmbExam.SelectedValue), 1);

            }
            catch
            {
            }

        }
        public void PrintTabulation(int session_id, int exam_id, int class_id, int section_id)
        {
            try
            {
                CrystalDecisions.Shared.TableLogOnInfo tliCurrent;
                ReportDocument rptCustomersOrders = new ExamTabulationSheet();

                foreach (CrystalDecisions.CrystalReports.Engine.Table tbCurrent in rptCustomersOrders.Database.Tables)
                {
                    tliCurrent = tbCurrent.LogOnInfo;
                    tliCurrent.ConnectionInfo.ServerName = FormHelper.DBServerName;
                    tliCurrent.ConnectionInfo.UserID = FormHelper.DBUser;
                    tliCurrent.ConnectionInfo.Password = FormHelper.DBUserPassword;
                    tliCurrent.ConnectionInfo.DatabaseName = FormHelper.DBName;
                    tbCurrent.ApplyLogOnInfo(tliCurrent);
                }


                rptCustomersOrders.SetParameterValue("@session_id", session_id);
                rptCustomersOrders.SetParameterValue("@exam_id", exam_id);
                rptCustomersOrders.SetParameterValue("@class_id", class_id);
                rptCustomersOrders.SetParameterValue("@section_id", section_id);



                FrmGenericReportViewer frmGenericReportViewer = new FrmGenericReportViewer();
                frmGenericReportViewer.crvParameter.DisplayGroupTree = false;
                frmGenericReportViewer.crvParameter.ReportSource = rptCustomersOrders;
                frmGenericReportViewer.Show();
            }
            catch
            {
            }
        }
        public void TotalFailReport(int session_id, int exam_id, int shift_id)
        {
            try
            {
                CrystalDecisions.Shared.TableLogOnInfo tliCurrent;
                ReportDocument rptCustomersOrders = new TotalFailReport();

                foreach (CrystalDecisions.CrystalReports.Engine.Table tbCurrent in rptCustomersOrders.Database.Tables)
                {
                    tliCurrent = tbCurrent.LogOnInfo;
                    tliCurrent.ConnectionInfo.ServerName = FormHelper.DBServerName;
                    tliCurrent.ConnectionInfo.UserID = FormHelper.DBUser;
                    tliCurrent.ConnectionInfo.Password = FormHelper.DBUserPassword;
                    tliCurrent.ConnectionInfo.DatabaseName = FormHelper.DBName;
                    tbCurrent.ApplyLogOnInfo(tliCurrent);
                }

                rptCustomersOrders.SetParameterValue("@session_id", session_id);
                rptCustomersOrders.SetParameterValue("@exam_id", exam_id);
                rptCustomersOrders.SetParameterValue("@shift_id", shift_id);
                
                FrmGenericReportViewer frmGenericReportViewer = new FrmGenericReportViewer();
                frmGenericReportViewer.crvParameter.DisplayGroupTree = false;
                frmGenericReportViewer.crvParameter.ReportSource = rptCustomersOrders;
                frmGenericReportViewer.Show();
            }
            catch
            {
            }
        }

        public void GradeReport(int session_id, int exam_id, int shift_id)
        {
            try
            {
                CrystalDecisions.Shared.TableLogOnInfo tliCurrent;
                ReportDocument rptCustomersOrders = new ClassWiseCountReport();

                foreach (CrystalDecisions.CrystalReports.Engine.Table tbCurrent in rptCustomersOrders.Database.Tables)
                {
                    tliCurrent = tbCurrent.LogOnInfo;
                    tliCurrent.ConnectionInfo.ServerName = FormHelper.DBServerName;
                    tliCurrent.ConnectionInfo.UserID = FormHelper.DBUser;
                    tliCurrent.ConnectionInfo.Password = FormHelper.DBUserPassword;
                    tliCurrent.ConnectionInfo.DatabaseName = FormHelper.DBName;
                    tbCurrent.ApplyLogOnInfo(tliCurrent);
                }

                rptCustomersOrders.SetParameterValue("@session_id", session_id);
                rptCustomersOrders.SetParameterValue("@exam_id", exam_id);

                FrmGenericReportViewer frmGenericReportViewer = new FrmGenericReportViewer();
                frmGenericReportViewer.crvParameter.DisplayGroupTree = false;
                frmGenericReportViewer.crvParameter.ReportSource = rptCustomersOrders;
                frmGenericReportViewer.Show();
            }
            catch
            {
            }
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            try
            {
                grdStudentList.Rows.Clear();
                ExamResultBLL examResultBLL = new ExamResultBLL();
                DataSet ds = examResultBLL.ExamResultGrid(Convert.ToInt32(cmbsession.SelectedValue), Convert.ToInt32(cmbExam.SelectedValue),1, Convert.ToInt32(cmbClass.SelectedValue), Convert.ToInt32(cmbSection.SelectedValue));
                if (ds.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        grdStudentList.Rows.Add();
                        grdStudentList.Rows[i].Cells[0].Value = true ;
                        grdStudentList.Rows[i].Cells[1].Value = ds.Tables[0].Rows[i][0];
                        grdStudentList.Rows[i].Cells[2].Value = ds.Tables[0].Rows[i][1];
                        grdStudentList.Rows[i].Cells[3].Value = ds.Tables[0].Rows[i][2];
                        grdStudentList.Rows[i].Cells[4].Value = ds.Tables[0].Rows[i][3];
                        grdStudentList.Rows[i].Cells[5].Value = ds.Tables[0].Rows[i][4];
                        grdStudentList.Rows[i].Cells[6].Value = ds.Tables[0].Rows[i][5];
                        grdStudentList.Rows[i].Cells[7].Value = ds.Tables[0].Rows[i][6];
                       


                    }
                }


            }
            catch
            {
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetLoad();
        }

        private void btnIndividualPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if ((Convert.ToInt32(cmbClass.SelectedValue) > 3) )
                    NineTen();

               // if (Convert.ToInt32(cmbClass.SelectedValue) == 9)
                   // Eight();
                else if (Convert.ToInt32(cmbClass.SelectedValue) < 4)
                    SixSeven();
            }
            catch
            {
            }

        }

        void NineTen()
        {
        try
            {
                                
                if (grdStudentList.Rows.Count > 0)
                {
                    for (int i = 0; i < grdStudentList.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(grdStudentList.Rows[i].Cells[0].Value)==true )
                        {
                            CrystalDecisions.Shared.TableLogOnInfo tliCurrent;
                            ReportDocument rptCustomersOrders = new IndividualResultFinalNineTen();

                            foreach (CrystalDecisions.CrystalReports.Engine.Table tbCurrent in rptCustomersOrders.Database.Tables)
                            {
                                tliCurrent = tbCurrent.LogOnInfo;
                                tliCurrent.ConnectionInfo.ServerName = FormHelper.DBServerName;
                                tliCurrent.ConnectionInfo.UserID = FormHelper.DBUser;
                                tliCurrent.ConnectionInfo.Password = FormHelper.DBUserPassword;
                                tliCurrent.ConnectionInfo.DatabaseName = FormHelper.DBName;
                                tbCurrent.ApplyLogOnInfo(tliCurrent);
                            }
                            rptCustomersOrders.SetParameterValue("@exam_id", Convert.ToInt32(grdStudentList.Rows[i].Cells[1].Value));
                            rptCustomersOrders.SetParameterValue("@session_id", Convert.ToInt32(grdStudentList.Rows[i].Cells[2].Value));
                            rptCustomersOrders.SetParameterValue("@shift_id", 1);

                            rptCustomersOrders.SetParameterValue("@class_id", Convert.ToInt32(grdStudentList.Rows[i].Cells[4].Value));
                            rptCustomersOrders.SetParameterValue("@section_id", Convert.ToInt32(grdStudentList.Rows[i].Cells[5].Value));
                            rptCustomersOrders.SetParameterValue("@roll_no", Convert.ToInt32(grdStudentList.Rows[i].Cells[6].Value));

                            FrmGenericReportViewer frmGenericReportViewer = new FrmGenericReportViewer();
                            frmGenericReportViewer.crvParameter.DisplayGroupTree = false;
                            frmGenericReportViewer.crvParameter.ReportSource = rptCustomersOrders;
                            frmGenericReportViewer.Show();
                            rptCustomersOrders.PrintToPrinter(1, false, 0, 0);
                        }
                    }
                }
            }
            catch
            {
            }
        }

        void SixSeven()
        {
            try
            {

                if (grdStudentList.Rows.Count > 0)
                {
                    for (int i = 0; i < grdStudentList.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(grdStudentList.Rows[i].Cells[0].Value) == true)
                        {
                            CrystalDecisions.Shared.TableLogOnInfo tliCurrent;
                            ReportDocument rptCustomersOrders = new IndividualResultFinal();

                            foreach (CrystalDecisions.CrystalReports.Engine.Table tbCurrent in rptCustomersOrders.Database.Tables)
                            {
                                tliCurrent = tbCurrent.LogOnInfo;
                                tliCurrent.ConnectionInfo.ServerName = FormHelper.DBServerName;
                                tliCurrent.ConnectionInfo.UserID = FormHelper.DBUser;
                                tliCurrent.ConnectionInfo.Password = FormHelper.DBUserPassword;
                                tliCurrent.ConnectionInfo.DatabaseName = FormHelper.DBName;
                                tbCurrent.ApplyLogOnInfo(tliCurrent);
                            }
                            rptCustomersOrders.SetParameterValue("@exam_id", Convert.ToInt32(grdStudentList.Rows[i].Cells[1].Value));
                            rptCustomersOrders.SetParameterValue("@session_id", Convert.ToInt32(grdStudentList.Rows[i].Cells[2].Value));
                            rptCustomersOrders.SetParameterValue("@shift_id", 1);

                            rptCustomersOrders.SetParameterValue("@class_id", Convert.ToInt32(grdStudentList.Rows[i].Cells[4].Value));
                            rptCustomersOrders.SetParameterValue("@section_id", Convert.ToInt32(grdStudentList.Rows[i].Cells[5].Value));
                            rptCustomersOrders.SetParameterValue("@roll_no", Convert.ToInt32(grdStudentList.Rows[i].Cells[6].Value));

                            FrmGenericReportViewer frmGenericReportViewer = new FrmGenericReportViewer();
                            frmGenericReportViewer.crvParameter.DisplayGroupTree = false;
                            frmGenericReportViewer.crvParameter.ReportSource = rptCustomersOrders;
                            frmGenericReportViewer.Show();
                            rptCustomersOrders.PrintToPrinter(1, false, 0, 0);
                        }
                    }
                }
            }
            catch
            {
            }
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                for (int i = 0; i < grdStudentList.Rows.Count; i++)
                {
                    grdStudentList.Rows[i].Cells[0].Value = true;

                }
            }
            catch
            {
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                for (int i = 0; i < grdStudentList.Rows.Count; i++)
                {
                    grdStudentList.Rows[i].Cells[0].Value = false;

                }
            }
            catch
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                Combinesummary();
                CombainFailReport();
                CrystalDecisions.Shared.TableLogOnInfo tliCurrent;
                ReportDocument rptCustomersOrders = new CombineResultCount();

                foreach (CrystalDecisions.CrystalReports.Engine.Table tbCurrent in rptCustomersOrders.Database.Tables)
                {
                    tliCurrent = tbCurrent.LogOnInfo;
                    tliCurrent.ConnectionInfo.ServerName = FormHelper.DBServerName;
                    tliCurrent.ConnectionInfo.UserID = FormHelper.DBUser;
                    tliCurrent.ConnectionInfo.Password = FormHelper.DBUserPassword;
                    tliCurrent.ConnectionInfo.DatabaseName = FormHelper.DBName;
                    tbCurrent.ApplyLogOnInfo(tliCurrent);
                }
                
                rptCustomersOrders.SetParameterValue("@session_id", Convert.ToInt32(cmbsession.SelectedValue));


                FrmGenericReportViewer frmGenericReportViewer = new FrmGenericReportViewer();
                frmGenericReportViewer.crvParameter.DisplayGroupTree = false;
                frmGenericReportViewer.crvParameter.ReportSource = rptCustomersOrders;
                frmGenericReportViewer.Show();


            }
            catch
            {
            }
        }


        void Combinesummary()
        {
            try
            {

                CrystalDecisions.Shared.TableLogOnInfo tliCurrent;
                ReportDocument rptCustomersOrders = new SummaryResultCombain();

                foreach (CrystalDecisions.CrystalReports.Engine.Table tbCurrent in rptCustomersOrders.Database.Tables)
                {
                    tliCurrent = tbCurrent.LogOnInfo;
                    tliCurrent.ConnectionInfo.ServerName = FormHelper.DBServerName;
                    tliCurrent.ConnectionInfo.UserID = FormHelper.DBUser;
                    tliCurrent.ConnectionInfo.Password = FormHelper.DBUserPassword;
                    tliCurrent.ConnectionInfo.DatabaseName = FormHelper.DBName;
                    tbCurrent.ApplyLogOnInfo(tliCurrent);
                }
                rptCustomersOrders.SetParameterValue("@session_id", Convert.ToInt32(cmbsession.SelectedValue));
                rptCustomersOrders.SetParameterValue("@shift_id", 1);

                rptCustomersOrders.SetParameterValue("@class_id", Convert.ToInt32(cmbClass.SelectedValue));
                //rptCustomersOrders.SetParameterValue("@section_id", Convert.ToInt32(cmbSection.SelectedValue));

                FrmGenericReportViewer frmGenericReportViewer = new FrmGenericReportViewer();
                frmGenericReportViewer.crvParameter.DisplayGroupTree = false;
                frmGenericReportViewer.crvParameter.ReportSource = rptCustomersOrders;
                frmGenericReportViewer.Show();


            }
            catch
            {
            }
        }


        void CombainFailReport()
        {
            try
            {

                CrystalDecisions.Shared.TableLogOnInfo tliCurrent;
                ReportDocument rptCustomersOrders = new TotalCombainFailReport1();

                foreach (CrystalDecisions.CrystalReports.Engine.Table tbCurrent in rptCustomersOrders.Database.Tables)
                {
                    tliCurrent = tbCurrent.LogOnInfo;
                    tliCurrent.ConnectionInfo.ServerName = FormHelper.DBServerName;
                    tliCurrent.ConnectionInfo.UserID = FormHelper.DBUser;
                    tliCurrent.ConnectionInfo.Password = FormHelper.DBUserPassword;
                    tliCurrent.ConnectionInfo.DatabaseName = FormHelper.DBName;
                    tbCurrent.ApplyLogOnInfo(tliCurrent);
                }
                rptCustomersOrders.SetParameterValue("@session_id", Convert.ToInt32(cmbsession.SelectedValue));
                //rptCustomersOrders.SetParameterValue("@shift_id", 1);

                //rptCustomersOrders.SetParameterValue("@class_id", Convert.ToInt32(cmbClass.SelectedValue));
                //rptCustomersOrders.SetParameterValue("@section_id", Convert.ToInt32(cmbSection.SelectedValue));

                FrmGenericReportViewer frmGenericReportViewer = new FrmGenericReportViewer();
                frmGenericReportViewer.crvParameter.DisplayGroupTree = false;
                frmGenericReportViewer.crvParameter.ReportSource = rptCustomersOrders;
                frmGenericReportViewer.Show();


            }
            catch
            {
            }
        }

        private void btnCombinePrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdStudentList.Rows.Count > 0)
                {
                    for (int i = 0; i < grdStudentList.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(grdStudentList.Rows[i].Cells[0].Value) == true)
                        {
                            CrystalDecisions.Shared.TableLogOnInfo tliCurrent;
                            ReportDocument rptCustomersOrders = new CombainIndividualResultFinal();

                            foreach (CrystalDecisions.CrystalReports.Engine.Table tbCurrent in rptCustomersOrders.Database.Tables)
                            {
                                tliCurrent = tbCurrent.LogOnInfo;
                                tliCurrent.ConnectionInfo.ServerName = FormHelper.DBServerName;
                                tliCurrent.ConnectionInfo.UserID = FormHelper.DBUser;
                                tliCurrent.ConnectionInfo.Password = FormHelper.DBUserPassword;
                                tliCurrent.ConnectionInfo.DatabaseName = FormHelper.DBName;
                                tbCurrent.ApplyLogOnInfo(tliCurrent);
                            }
                            rptCustomersOrders.SetParameterValue("@session_id", Convert.ToInt32(grdStudentList.Rows[i].Cells[2].Value));
                            rptCustomersOrders.SetParameterValue("@shift_id", 1);
                            rptCustomersOrders.SetParameterValue("@class_id", Convert.ToInt32(grdStudentList.Rows[i].Cells[4].Value));
                            rptCustomersOrders.SetParameterValue("@section_id", Convert.ToInt32(grdStudentList.Rows[i].Cells[5].Value));
                            rptCustomersOrders.SetParameterValue("@roll_no", Convert.ToInt32(grdStudentList.Rows[i].Cells[6].Value));

                            FrmGenericReportViewer frmGenericReportViewer = new FrmGenericReportViewer();
                            frmGenericReportViewer.crvParameter.DisplayGroupTree = false;
                            frmGenericReportViewer.crvParameter.ReportSource = rptCustomersOrders;
                            frmGenericReportViewer.Show();
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private void btnIndividulSummary_Click(object sender, EventArgs e)
        {
            try
            {

                CrystalDecisions.Shared.TableLogOnInfo tliCurrent;
                ReportDocument rptCustomersOrders = new SummaryResult();

                foreach (CrystalDecisions.CrystalReports.Engine.Table tbCurrent in rptCustomersOrders.Database.Tables)
                {
                    tliCurrent = tbCurrent.LogOnInfo;
                    tliCurrent.ConnectionInfo.ServerName = FormHelper.DBServerName;
                    tliCurrent.ConnectionInfo.UserID = FormHelper.DBUser;
                    tliCurrent.ConnectionInfo.Password = FormHelper.DBUserPassword;
                    tliCurrent.ConnectionInfo.DatabaseName = FormHelper.DBName;
                    tbCurrent.ApplyLogOnInfo(tliCurrent);
                }
                rptCustomersOrders.SetParameterValue("@session_id", Convert.ToInt32(cmbsession.SelectedValue));
                //rptCustomersOrders.SetParameterValue("@shift_id", 1);

                rptCustomersOrders.SetParameterValue("@class_id", Convert.ToInt32(cmbClass.SelectedValue));
                rptCustomersOrders.SetParameterValue("@exam_id", Convert.ToInt32(cmbExam.SelectedValue));

                FrmGenericReportViewer frmGenericReportViewer = new FrmGenericReportViewer();
                frmGenericReportViewer.crvParameter.DisplayGroupTree = false;
                frmGenericReportViewer.crvParameter.ReportSource = rptCustomersOrders;
                frmGenericReportViewer.Show();


            }
            catch
            {
            }
            
        }

 


    }
}
