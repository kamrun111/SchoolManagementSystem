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

namespace SchoolManagementSystem.Forms.Students
{
    public partial class FrmStudentList : BaseForm.FrmBase
    {
        public FrmStudentList()
        {
            InitializeComponent();
        }
        CommonClass cs = new CommonClass();
        void GetLoad()
        {
            try
            {
                StudentBLL studentBLL = new StudentBLL();
                DataSet ds = studentBLL.StudentComboLoad();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtRegisreationNo.Text = "";
                    txtStudentName.Text = "";
                    txtFatherName.Text = "";
                    txtMotherName.Text = "";
                    txtPresentAddress.Text = "";
                    txtParmanentaddress.Text = "";
                    txtcontact.Text = "";
                    txtRoll.Text = "";
                    cs.PopulateComboBox(cmbShift, ds, 2, "shift", "shift_id");
                    cs.PopulateComboBox(cmbClass, ds, 3, "class_name", "class_id");
                    cs.PopulateComboBox(cmbSection, ds, 4, "section_name", "section_id");

                    cs.PopulateComboBox(cmbStudenttype, ds, 0, "student_status", "student_status_id");
                    cs.PopulateComboBox(cmbSession, ds, 1, "session", "session_id");
                    cs.PopulateComboBox(cmbStudentClass, ds, 8, "class_name", "class_id");
                    cs.PopulateComboBox(cmbStudentSection, ds, 9, "section_name", "section_id");
                    cs.PopulateComboBox(cmbPaymentCategory, ds, 5, "payment_catagory", "payment_catagory_id");
                    cs.PopulateComboBox(cmbStudentShift, ds, 10, "shift", "shift_id");
                }
                if (ds.Tables[7].Rows.Count > 0)
                {
                    cs.FillUpListview(lvwStudentInformation, ds, 7);
                }


            }
            catch
            {
            }

        }
        private void FrmStudentList_Load(object sender, EventArgs e)
        {
            GetLoad();
        }

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbClass.SelectedIndex > -1)
                {
                    cmbSection.DataSource = null;
                    StudentBLL studentBLL = new StudentBLL();
                    DataSet ds = studentBLL.StudentSectionLoad(Convert.ToInt32(cmbClass.SelectedValue));
                    if (ds.Tables[0].Rows.Count > 0)
                        cs.PopulateComboBox(cmbSection, ds, 0, "section_name", "section_id");
                        lvwStudentInformation.Items.Clear();
                        cs.FillUpListview(lvwStudentInformation, ds, 1);
                    
                }
            }
            catch
            {
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbSection.SelectedIndex > -1)
                {
                    StudentBLL studentBLL = new StudentBLL();
                    DataSet ds = studentBLL.StudentListLoad(Convert.ToInt32(cmbClass.SelectedValue), Convert.ToInt32(cmbSection.SelectedValue));
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lvwStudentInformation.Items.Clear();
                        cs.FillUpListview(lvwStudentInformation, ds, 0);
                    }
                }
            }
            catch
            {
            }
        }

        private void lvwStudentInformation_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvwStudentInformation.SelectedItems.Count > 0)
                {
                    DataSet ds = cs.GetDataSetWithParameter("@student_id", Convert.ToInt32(lvwStudentInformation.SelectedItems[0].Text), "StudentLoadParticular");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtRegisreationNo.Text = ds.Tables[0].Rows[0][1].ToString();
                        txtStudentName.Text = ds.Tables[0].Rows[0][2].ToString();
                        txtFatherName.Text = ds.Tables[0].Rows[0][3].ToString();
                        txtMotherName.Text = ds.Tables[0].Rows[0][4].ToString();
                        txtPresentAddress.Text=ds.Tables[0].Rows[0][5].ToString();
                        txtParmanentaddress.Text=ds.Tables[0].Rows[0][6].ToString();
                        if (ds.Tables[0].Rows[0][7].ToString()=="1")
                            rdomale.Checked = true;
                        else
                            rdoFemale.Checked = true; ;
                        dtpDOB.Value = Convert.ToDateTime(ds.Tables[0].Rows[0][8]);
                        txtcontact.Text=ds.Tables[0].Rows[0][9].ToString();
                        cmbBloodGroup.Text=ds.Tables[0].Rows[0][10].ToString();
                        cmbSession.SelectedValue= Convert.ToInt32(ds.Tables[0].Rows[0][11]);
                        cmbStudentShift.SelectedValue = Convert.ToInt32(ds.Tables[0].Rows[0][12]);
                        cmbStudentClass.SelectedValue = Convert.ToInt32(ds.Tables[0].Rows[0][13]);
                        cmbStudentSection.SelectedValue = Convert.ToInt32(ds.Tables[0].Rows[0][14]);
                        txtRoll.Text=ds.Tables[0].Rows[0][15].ToString();
                        cmbPaymentCategory.SelectedValue = Convert.ToInt32(ds.Tables[0].Rows[0][16]);
                        cmbStudenttype.SelectedValue = Convert.ToInt32(ds.Tables[0].Rows[0][17]);
                        //Image image = Image.FromFile(@"\\PC-PC\ID Photo\Students\" + ds.Tables[0].Rows[0][18].ToString());//   //\\KUKS-PC\Image   //\\FSCR-PC\ID Photo\Students\
                        pictureBox1.ImageLocation = "http://ssumon-001-site1.itempurl.com/Image/Student/" + ds.Tables[0].Rows[0][18].ToString();
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbSection.SelectedIndex != -1)
                    StudentPrintReport(Convert.ToInt32(cmbShift.SelectedValue), Convert.ToInt32(cmbClass.SelectedValue), Convert.ToInt32(cmbSection.SelectedValue));
                else
                    StudentPrintReport(Convert.ToInt32(cmbShift.SelectedValue), Convert.ToInt32(cmbClass.SelectedValue), 0);


            }
            catch
            {
            }

        }


        public void StudentPrintReport(int shift_id, int class_id, int section_id)
        {
            try
            {
                CrystalDecisions.Shared.TableLogOnInfo tliCurrent;
                ReportDocument rptCustomersOrders = new StudentPrintReport();

                foreach (CrystalDecisions.CrystalReports.Engine.Table tbCurrent in rptCustomersOrders.Database.Tables)
                {
                    tliCurrent = tbCurrent.LogOnInfo;
                    tliCurrent.ConnectionInfo.ServerName = FormHelper.DBServerName;
                    tliCurrent.ConnectionInfo.UserID = FormHelper.DBUser;
                    tliCurrent.ConnectionInfo.Password = FormHelper.DBUserPassword;
                    tliCurrent.ConnectionInfo.DatabaseName = FormHelper.DBName;
                    tbCurrent.ApplyLogOnInfo(tliCurrent);
                }


                rptCustomersOrders.SetParameterValue("@shift_id", shift_id);
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



 





    }
}
