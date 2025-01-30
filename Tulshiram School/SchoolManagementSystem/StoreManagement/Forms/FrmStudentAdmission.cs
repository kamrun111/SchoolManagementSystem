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

namespace SchoolManagementSystem.Forms
{
    public partial class FrmStudentAdmission : BaseForm.FrmBase
    {
        public FrmStudentAdmission()
        {
            InitializeComponent();
        }
       
        CommonClass cs = new CommonClass();
        void GetLoad()
        {
            try
            {
                DataSet ds = cs.GetDataSet("StudentAdmissionLoad");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    cs.PopulateComboBox(cmbAdmittedClass, ds, 0, "class_name", "class_id");
                }
            }
            catch
            {
             }
        }
        private void FrmStudentRegistration_Load(object sender, EventArgs e)
        {
            GetLoad();
        }



        private void cmbAdmittedClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(cmbAdmittedClass.SelectedIndex>-1)
                {
                    DataSet ds = cs.GetDataSetWithParameter("@class_id", Convert.ToInt32(cmbAdmittedClass.SelectedValue), "StudentAdmissionSection");
                    if (ds.Tables[0].Rows.Count > 0)
                        cs.PopulateComboBox(cmbSection, ds, 0, "section_name", "section_id");

                }
            }
            catch
            {
            }
        }
        void GetRefresh()
        {
            try
            {
                txtStudentName.Text = "";
                dtpDOB.Value = DateTime.Now;
                txtRegisreationNo.Text = "";
                cmbAdmittedClass.Text = "<Select>";
                dtpAdmissionDate.Value = DateTime.Now;
                cmbSection.Text = "<Select>";
                txtFatherName.Text = "";
                txtParmanentAddress.Text="";
                txtParmanentAddress.Text = "";
                txtMotherName.Text = "";
                txtPreviousSchool.Text = "";
                cmbLastClass.Text = "<Select>";
                txtResult.Text = "";
                txtGuardianName.Text = "";
                txtGuardianContactNo.Text = "";
                btnSave.Enabled = true;
                grpParentInformation.BringToFront();
                lvwStudentInformation.Items.Clear();

            }
            catch
            {
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetRefresh();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtStudentName.Text =="")
                {
                    txtStudentName.Focus();
                    return;
                }
                if (cmbAdmittedClass.SelectedIndex==-1)
                {
                    cmbAdmittedClass.Focus();
                    return;
                }
                if (cmbSection.SelectedIndex == -1)
                {
                    cmbSection.Focus();
                    return;
                }
                StudentAdmissionBO studentAdmissionBO = new StudentAdmissionBO();
                StudentAdmissionBLL studentAdmissionBLL = new StudentAdmissionBLL();
                studentAdmissionBO.full_name=txtStudentName.Text;
                studentAdmissionBO.date_of_birth=dtpDOB.Value;
                studentAdmissionBO.registration_no=txtRegisreationNo.Text;
                studentAdmissionBO.class_id=Convert.ToInt32(cmbAdmittedClass.SelectedValue);
                if(rdomale.Checked==true)
                    studentAdmissionBO.gender_id= 1;
                else
                    studentAdmissionBO.gender_id= 2;

                studentAdmissionBO.admission_date=dtpAdmissionDate.Value;
                if(cmbSection.SelectedIndex!=-1)
                studentAdmissionBO.section_id=Convert.ToInt32(cmbSection.SelectedValue);
                studentAdmissionBO.fathers_name=txtFatherName.Text;
                studentAdmissionBO.parmanent_address=txtParmanentAddress.Text;
                studentAdmissionBO.present_address=txtPresentAddress.Text; 
                studentAdmissionBO.mothers_name=txtMotherName.Text;
                studentAdmissionBO.student_previous_institude_name=txtPreviousSchool.Text;
                studentAdmissionBO.last_class=Convert.ToInt32(cmbLastClass.SelectedValue);
                studentAdmissionBO.result=txtResult.Text;
                studentAdmissionBO.local_guardian_name= txtGuardianName.Text;
                studentAdmissionBO.local_guardian_cell_no=txtGuardianContactNo.Text;
                if (btnSave.Text == "Save")
                {
                    int result = studentAdmissionBLL.StudentAdmissionAdd(studentAdmissionBO);
                    if (result > 0)
                    {
                        MessageBox.Show("Data Saved Sussessfully");
                        btnSave.Enabled = false;
                    }

                }
                else
                    Update();

            }
            catch
            {
            }
        }
        void Save()
        {

        }
                
        void Update()
        {
        }

        private void btnParentInformation_Click(object sender, EventArgs e)
        {
            grpParentInformation.BringToFront();
        }

        private void btnGuardianInformation_Click(object sender, EventArgs e)
        {
            grpGuardianInformation.BringToFront();
        }

        private void btnPreviousSchoolInformation_Click(object sender, EventArgs e)
        {
            grpPreviousSchool.BringToFront();
        }

        private void btnCurrentInformation_Click(object sender, EventArgs e)
        {
           
        }

        private void txtnameSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                StudentAdmissionBLL studentAdmissionBLL = new StudentAdmissionBLL();
                 DataSet   ds = studentAdmissionBLL.StudentAdmissionSearch(txtnameSearch.Text, 0);
                 if (ds.Tables[0].Rows.Count > 0)
                 {
                     lvwStudentInformation.Items.Clear();
                     cs.FillUpListview(lvwStudentInformation, ds, 0);
                 }
            }
            catch
            {
            }
  
        }

        private void txtnameSearch_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                StudentAdmissionBLL studentAdmissionBLL = new StudentAdmissionBLL();
                DataSet ds = studentAdmissionBLL.StudentAdmissionSearch(txtnameSearch.Text, 0);
                if (ds.Tables[0].Rows.Count > 0)
                    cs.FillUpListview(lvwStudentInformation, ds, 0);
            }
            catch
            {
            }

        }



    }
}
