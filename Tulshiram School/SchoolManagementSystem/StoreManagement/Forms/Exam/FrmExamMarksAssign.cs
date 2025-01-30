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

namespace SchoolManagementSystem.Forms.Exam
{
    public partial class FrmExamMarksAssign : BaseForm.FrmBase
    {
        public FrmExamMarksAssign()
        {
            InitializeComponent();
        }
        CommonClass cs = new CommonClass();

        void GetLoad()
        {
            try
            {
                DataSet ds = cs.GetDataSet("StudentComboLoad");
                cs.PopulateComboBox(cmbExam, ds, 11, "exam_name", "exam_id");
                cs.PopulateComboBox(cmbClass, ds, 3, "class_name", "class_id");
                cs.PopulateComboBox(cmbSubject, ds, 12, "subject", "subject_id");
                btnSave.Enabled = true;
                txtExamTotalNo.Text = "";
                txtTheoryTotal.Text = "";
                txtTheoryPassNo.Text = "";
                txtObjectiveTotal.Text = "";
                txtObjectivePassNo.Text = "";
                txtPracticalTotal.Text = "";
                txtPracticalPassNo.Text = "";
                txtResultMarks.Text = "";
                textClassTestTotal.Text = "";
                txtClassTestPassMarks.Text = "";
                DataSet da = cs.GetDataSet("ExamMarksAssignLoad");
                cs.FillUpListview(lvwStudentInformation,da,0);
                btnSave.Text = "Save";
            }
            catch
            {
            }
        }

        private void FrmExamMarksAssign_Load(object sender, EventArgs e)
        {
            GetLoad();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

  

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ExamMarksAssignBO examMarksAssignBO = new ExamMarksAssignBO();
                ExamMarksAssignBLL examMarksAssignBLL = new ExamMarksAssignBLL();
                examMarksAssignBO.exam_id = Convert.ToInt32(cmbExam.SelectedValue);
                examMarksAssignBO.class_id = Convert.ToInt32(cmbClass.SelectedValue);
                examMarksAssignBO.subject_id = Convert.ToInt32(cmbSubject.SelectedValue);
                if (txtExamTotalNo.Text != "")
                    examMarksAssignBO.exam_total_marks = Convert.ToDecimal(txtExamTotalNo.Text);
                if(txtTheoryTotal.Text!="")
                    examMarksAssignBO.theory_marks = Convert.ToDecimal(txtTheoryTotal.Text);
                if (txtTheoryPassNo.Text != "")
                    examMarksAssignBO.theory_pass_marks = Convert.ToDecimal(txtTheoryPassNo.Text);
                if (txtObjectiveTotal.Text != "")
                    examMarksAssignBO.objective_marks = Convert.ToDecimal(txtObjectiveTotal.Text);
                if (txtObjectivePassNo.Text != "")
                    examMarksAssignBO.objective_pass_marks = Convert.ToDecimal(txtObjectivePassNo.Text);
                if (txtPracticalTotal.Text != "")
                    examMarksAssignBO.practical_marks = Convert.ToDecimal(txtPracticalTotal.Text);
                if (txtPracticalPassNo.Text != "")
                    examMarksAssignBO.practical_pass_marks = Convert.ToDecimal(txtPracticalPassNo.Text);
                if (txtResultMarks.Text != "")
                    examMarksAssignBO.result_marks = Convert.ToDecimal(txtResultMarks.Text);
                if (textClassTestTotal.Text != "")
                    examMarksAssignBO.class_test_marks = Convert.ToDecimal(textClassTestTotal.Text);
                if (textClassTestTotal.Text == "")
                    examMarksAssignBO.class_test_marks =0;
                if (txtClassTestPassMarks.Text != "")
                    examMarksAssignBO.class_test_pass_marks = Convert.ToDecimal(txtClassTestPassMarks.Text);
                examMarksAssignBO.record_created_by = ApplicatinLauncher._userId;
                int result = 0;
                if (btnSave.Text == "Save")
                {
                    DataSet ds = examMarksAssignBLL.ExamMarksCheck(Convert.ToInt32(cmbExam.SelectedValue), Convert.ToInt32(cmbClass.SelectedValue), Convert.ToInt32(cmbSubject.SelectedValue));
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        MessageBox.Show("Data Already Exist");
                        return;
                    }
                    result = examMarksAssignBLL.ExamMarksAssign(examMarksAssignBO);
                }
                else
                {
                    examMarksAssignBO.exam_marks_assign_id = Convert.ToInt32(lvwStudentInformation.SelectedItems[0].SubItems[0].Text);
                    result = examMarksAssignBLL.ExamMarksAssignUpdate(examMarksAssignBO);
                }
                if (result > 0)
                {
                    MessageBox.Show("Data Saved successFully");
                    btnSave.Enabled = false;
                    GetLoad();
                }
                
            }
            catch
            {
            }
        }

        private void txtExamTotalNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            cs.NumCheck(e);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                GetLoad();
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
                    btnSave.Text = "Update";
                    cmbExam.SelectedValue = Convert.ToInt32(lvwStudentInformation.SelectedItems[0].SubItems[1].Text);
                    cmbClass.SelectedValue = Convert.ToInt32(lvwStudentInformation.SelectedItems[0].SubItems[2].Text);
                    cmbSubject.SelectedValue = Convert.ToInt32(lvwStudentInformation.SelectedItems[0].SubItems[3].Text);
                    txtExamTotalNo.Text = lvwStudentInformation.SelectedItems[0].SubItems[6].Text;
                    txtTheoryTotal.Text = lvwStudentInformation.SelectedItems[0].SubItems[7].Text;
                    txtTheoryPassNo.Text = lvwStudentInformation.SelectedItems[0].SubItems[8].Text;
                    txtObjectiveTotal.Text = lvwStudentInformation.SelectedItems[0].SubItems[9].Text;
                    txtObjectivePassNo.Text = lvwStudentInformation.SelectedItems[0].SubItems[10].Text;
                    txtPracticalTotal.Text = lvwStudentInformation.SelectedItems[0].SubItems[11].Text;
                    txtPracticalPassNo.Text = lvwStudentInformation.SelectedItems[0].SubItems[12].Text;

                    txtResultMarks.Text = lvwStudentInformation.SelectedItems[0].SubItems[13].Text;
                    textClassTestTotal.Text = lvwStudentInformation.SelectedItems[0].SubItems[14].Text;
                    txtClassTestPassMarks.Text = lvwStudentInformation.SelectedItems[0].SubItems[15].Text;
                    
                }
            }
            catch
            {
            }
        }

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbClass.SelectedIndex != -1)
                {
                    ExamMarksAssignBLL examMarksAssignBLL = new ExamMarksAssignBLL();
                    DataSet ds = examMarksAssignBLL.ExamMarkSubjectLoad(Convert.ToInt32(cmbClass.SelectedValue), ApplicatinLauncher.session_id);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        cs.PopulateComboBox(cmbSubject, ds, 0, "subject", "subject_id");
                    }

                }
            }
            catch
            {
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                ExamMarksAssignBLL examMarksAssignBLL = new ExamMarksAssignBLL();
                DataSet ds = examMarksAssignBLL.ExamMarksCheck(Convert.ToInt32(cmbExam.SelectedValue), Convert.ToInt32(cmbClass.SelectedValue), 1);
                cs.FillUpListview(lvwStudentInformation, ds, 0);


            }
            catch
            {
            }
        }

       
    }
}
