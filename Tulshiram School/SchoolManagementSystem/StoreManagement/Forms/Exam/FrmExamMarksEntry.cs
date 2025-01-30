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
    public partial class FrmExamMarksEntry : BaseForm.FrmBase
    {
        public FrmExamMarksEntry()
        {
            InitializeComponent();
        }
        CommonClass cs = new CommonClass();
        int exam_marks_assignID,Subject_Group_ID = 0;

        void GetLoad()
        {
            try
            {
                cmbExam.SelectedIndexChanged -= new EventHandler(cmbExam_SelectedIndexChanged);
                DataSet ds = cs.GetDataSet("StudentComboLoad");
                cs.PopulateComboBox(cmbExam, ds, 11, "exam_name", "exam_id");
                cmbExam.SelectedIndexChanged += new EventHandler(cmbExam_SelectedIndexChanged);

             

            }
            catch
            {
            }
        }

        private void FrmExamMarksEntry_Load(object sender, EventArgs e)
        {
            GetLoad();
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
                cmbSubject.SelectedIndexChanged -= new EventHandler(cmbSubject_SelectedIndexChanged);

                if (cmbClass.SelectedIndex > -1)
                {

                    DataSet ds = cs.GetDataSetWithParameter("@class_id", Convert.ToInt32(cmbClass.SelectedValue), "StudentSectionLoad");
                    if (ds.Tables[0].Rows.Count > 0)
                        cs.PopulateComboBox(cmbSection, ds, 0, "section_name", "section_id");

                    DataSet da=cs.GetDataSetWithTwoIntParameter("@class_id","@exam_id",Convert.ToInt32(cmbClass.SelectedValue),Convert.ToInt32(cmbExam.SelectedValue),"ExamMarksSubject");
                    if (da.Tables[0].Rows.Count > 0)
                        cs.PopulateComboBox(cmbSubject, da, 0, "subject", "subject_id");

                }
                cmbSubject.SelectedIndexChanged += new EventHandler(cmbSubject_SelectedIndexChanged);



            }
            catch
            {
                this.Close();
            }

        }

        private void cmbSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbSubject.SelectedIndex > -1)
                {
                    this.grdStudentList.CellValueChanged -= this.grdStudentList_CellValueChanged;

                   


                    ExamMarksAssignBLL examMarksAssignBLL = new ExamMarksAssignBLL();
                    DataSet ds = examMarksAssignBLL.ExamMarksLoad(Convert.ToInt32(cmbExam.SelectedValue), Convert.ToInt32(cmbClass.SelectedValue), Convert.ToInt32(cmbSubject.SelectedValue), Convert.ToInt32(cmbSection.SelectedValue), ApplicatinLauncher.session_id);
                    if (ds.Tables[0].Rows.Count > 0)
                    
                    {
                        exam_marks_assignID = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                        txtExamTotalNo.Text = ds.Tables[0].Rows[0][1].ToString();
                        txtTheoryTotal.Text = ds.Tables[0].Rows[0][2].ToString();
                        txtObjectiveTotal.Text = ds.Tables[0].Rows[0][3].ToString();
                        txtPracticalTotal.Text = ds.Tables[0].Rows[0][4].ToString();
                        txtExamTotal.Text = ds.Tables[0].Rows[0][5].ToString();
                        txtCTTotal.Text = ds.Tables[0].Rows[0][6].ToString();

                        txtTheoryPass.Text = ds.Tables[0].Rows[0][7].ToString();
                        txtObjectivePass.Text = ds.Tables[0].Rows[0][8].ToString();
                        txtPracticalPass.Text = ds.Tables[0].Rows[0][9].ToString();
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        btnSave.Text = "Update";
                        grdStudentList.Rows.Clear();
                        for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                        {
                            grdStudentList.Rows.Add();
                            grdStudentList.Rows[i].Cells[0].Value = ds.Tables[1].Rows[i][0];
                            grdStudentList.Rows[i].Cells[1].Value = ds.Tables[1].Rows[i][1];
                            grdStudentList.Rows[i].Cells[2].Value = ds.Tables[1].Rows[i][2];
                            grdStudentList.Rows[i].Cells[3].Value = ds.Tables[1].Rows[i][3];
                            grdStudentList.Rows[i].Cells[4].Value = ds.Tables[1].Rows[i][4];
                            grdStudentList.Rows[i].Cells[5].Value = ds.Tables[1].Rows[i][5];
                            grdStudentList.Rows[i].Cells[6].Value = ds.Tables[1].Rows[i][6];
                            grdStudentList.Rows[i].Cells[7].Value = ds.Tables[1].Rows[i][7];
                            grdStudentList.Rows[i].Cells[8].Value = ds.Tables[1].Rows[i][8];
                            grdStudentList.Rows[i].Cells[9].Value = ds.Tables[1].Rows[i][9];
                            grdStudentList.Rows[i].Cells[10].Value = ds.Tables[1].Rows[i][10];
                            grdStudentList.Rows[i].Cells[11].Value = ds.Tables[1].Rows[i][11];
                            grdStudentList.Rows[i].Cells[12].Value = ds.Tables[1].Rows[i][12];
                            grdStudentList.Rows[i].Cells[13].Value = ds.Tables[1].Rows[i][13];
                            grdStudentList.Rows[i].Cells[14].Value = ds.Tables[1].Rows[i][14];
                           

                        }
                        
                    }
                    else
                    {
                        if (ds.Tables[2].Rows.Count > 0)
                        {
                            btnSave.Text = "Save";
                            grdStudentList.Rows.Clear();
                            for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
                            {
                                grdStudentList.Rows.Add();
                                grdStudentList.Rows[i].Cells[0].Value = 0;
                                grdStudentList.Rows[i].Cells[1].Value = ds.Tables[2].Rows[i][0];
                                grdStudentList.Rows[i].Cells[2].Value = ds.Tables[2].Rows[i][1];
                                grdStudentList.Rows[i].Cells[3].Value = ds.Tables[2].Rows[i][2];
                                grdStudentList.Rows[i].Cells["subject_status_id"].Value = ds.Tables[2].Rows[i][3];

                            }
                        }
                    }
                    Subject_Group_ID = Convert.ToInt32(ds.Tables[3].Rows[0][0]);

                    if (txtTheoryTotal.Text == "")
                        grdStudentList.Columns[4].Visible = false;
                    else
                        grdStudentList.Columns[4].Visible = true;
                    if (txtObjectiveTotal.Text == "")
                        grdStudentList.Columns[5].Visible = false;
                    else
                        grdStudentList.Columns[5].Visible = true;
                    if (txtPracticalTotal.Text == "")
                        grdStudentList.Columns[6].Visible = false;
                    else
                        grdStudentList.Columns[6].Visible = true;


                    

                    this.grdStudentList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdStudentList_CellValueChanged);



                }
            }
            catch
            {
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

 
        private void calculateTotal(DataGridViewRow row)
        {
            try
            {
                double theory = 0;
                double objective = 0;
                double practical = 0;
                double totalMarks = 0.00;
                double CT = 0;
                

                if (row.Cells["Theory"].Value!= null && row.Cells["Theory"].Value.ToString() != "")
                    double.TryParse(row.Cells["Theory"].Value.ToString(), out theory);
                if (row.Cells["Objective"].Value != null )
                    double.TryParse(row.Cells["Objective"].Value.ToString(), out objective);
                if (row.Cells["Practical"].Value!= null )
                    double.TryParse(row.Cells["Practical"].Value.ToString(), out practical);
                totalMarks = theory + objective + practical;

                this.grdStudentList.CellValueChanged -= this.grdStudentList_CellValueChanged;
                row.Cells["exam_total"].Value = totalMarks.ToString("0#.#0");
                row.Cells["Exam_Obtain"].Value = (totalMarks * Convert.ToDouble(txtExamTotal.Text) / Convert.ToDouble(txtExamTotalNo.Text)).ToString("0#.#0");
                if (row.Cells["CT_no"].Value != null || row.Cells["CT_no"].Value.ToString() != "")
                    CT = Convert.ToDouble(row.Cells["CT_no"].Value);
                row.Cells["Result_Total"].Value = (Convert.ToDouble(row.Cells["Exam_Obtain"].Value) + CT).ToString("0#.#0");//
                row.Cells["Percentage"].Value = ((Convert.ToDouble(row.Cells["Result_Total"].Value) * 100) / (Convert.ToDouble(txtExamTotal.Text) +Convert.ToDouble(txtCTTotal.Text))).ToString("0#.#0");
                CalculateGpa(row);
                CalculateIndivisualPass(row, theory, objective, practical);
                this.grdStudentList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdStudentList_CellValueChanged);



            }
            catch
            {
                this.grdStudentList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdStudentList_CellValueChanged);

            }
            
        }



        private void CalculateIndivisualPass(DataGridViewRow row,double  t,double o,double p)
        {
            try
            {
                if (txtTheoryPass.Text != "")
                {
                    if (Convert.ToDouble(txtTheoryPass.Text) > t)
                    {
                        row.Cells["grade"].Value = "F";
                        row.Cells["gpa"].Value = "0";
                    }

                }
                if (txtObjectivePass.Text != "")
                {
                    if (Convert.ToDouble(txtObjectivePass.Text) > o)
                    {
                        row.Cells["grade"].Value = "F";
                        row.Cells["gpa"].Value = "0";
                    }

                }
                if (txtPracticalPass.Text != "")
                {
                    if (Convert.ToDouble(txtPracticalPass.Text) > p)
                    {
                        row.Cells["grade"].Value = "F";
                        row.Cells["gpa"].Value = "0";
                    }

                }
            }
            catch
            {
            }
        }
        private void CalculateGpa(DataGridViewRow row)
        {
            try
            {
                if (Convert.ToDouble(row.Cells["Percentage"].Value) >= 0 && (Convert.ToDouble(row.Cells["Percentage"].Value) <= 32.99))
                {
                    row.Cells["grade"].Value = "F";
                    row.Cells["gpa"].Value = "0";
                }
                else if (Convert.ToDouble(row.Cells["Percentage"].Value) >= 33 && (Convert.ToDouble(row.Cells["Percentage"].Value) <= 39.99))
                {
                    row.Cells["grade"].Value = "D";
                    row.Cells["gpa"].Value = "1";
                }
                else if (Convert.ToDouble(row.Cells["Percentage"].Value) >= 40 && (Convert.ToDouble(row.Cells["Percentage"].Value) <= 49.99))
                {
                    row.Cells["grade"].Value = "c";
                    row.Cells["gpa"].Value = "2";
                }
                else if (Convert.ToDouble(row.Cells["Percentage"].Value) >= 50 && (Convert.ToDouble(row.Cells["Percentage"].Value) <= 59.99))
                {
                    row.Cells["grade"].Value = "B";
                    row.Cells["gpa"].Value = "3";
                }
                else if (Convert.ToDouble(row.Cells["Percentage"].Value) >= 60 && (Convert.ToDouble(row.Cells["Percentage"].Value) <= 69.99))
                {
                    row.Cells["grade"].Value = "A-";
                    row.Cells["gpa"].Value = "3.50";
                }
                else if (Convert.ToDouble(row.Cells["Percentage"].Value) >= 70 && (Convert.ToDouble(row.Cells["Percentage"].Value) <= 79.99))
                {
                    row.Cells["grade"].Value = "A";
                    row.Cells["gpa"].Value = "4";
                }

                else if (Convert.ToDouble(row.Cells["Percentage"].Value) >= 80 && (Convert.ToDouble(row.Cells["Percentage"].Value) <= 100))
                {
                    row.Cells["grade"].Value = "A+";
                    row.Cells["gpa"].Value = "5.00";
                }
            }
            catch
            {
            }
        }

        private void grdStudentList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            string msg = "";
            DataGridViewRow row = null;
            try
            {

                row = this.grdStudentList.Rows[e.RowIndex];
                string valueStr = (row.Cells[e.ColumnIndex].Value == null ? "" : row.Cells[e.ColumnIndex].Value.ToString());
                double valueNumeric = 0;
                double.TryParse(valueStr, out valueNumeric);
           

                if (e.ColumnIndex == 4 || e.ColumnIndex == 5 || e.ColumnIndex == 6)
                {
                    if (valueNumeric < 0)
                    {
                        msg = "Please provide a valid number";
                        return;

                    }
                }
                this.calculateTotal(row);

            }
            catch
            {
            }
            finally
            {
                if (msg != "")
                {
                    MessageBox.Show(msg, "SMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.grdStudentList.CellValueChanged -= this.grdStudentList_CellValueChanged;
                    row.Cells[e.ColumnIndex].Value = null;
                    row.Cells[e.ColumnIndex].Selected = true;
                    this.grdStudentList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdStudentList_CellValueChanged);
                }
            }
        }


     void Check()
        {
            try
            {
                for (int i = 0; i < grdStudentList.Rows.Count; i++)
                {
                    if(grdStudentList.Rows[i].Cells["Percentage"].Value!=null && grdStudentList.Rows[i].Cells["Percentage"].Value != DBNull.Value)
                    {
                            if (Convert.ToDouble(grdStudentList.Rows[i].Cells["Percentage"].Value) >= 0 && (Convert.ToDouble(grdStudentList.Rows[i].Cells["Percentage"].Value) <= 32.99))
                            {
                                grdStudentList.Rows[i].Cells["grade"].Value = "F";
                                grdStudentList.Rows[i].Cells["gpa"].Value = "0";
                            }
                            else if (Convert.ToDouble(grdStudentList.Rows[i].Cells["Percentage"].Value) >= 33 && (Convert.ToDouble(grdStudentList.Rows[i].Cells["Percentage"].Value) <= 39.99))
                            {
                                grdStudentList.Rows[i].Cells["grade"].Value = "D";
                                grdStudentList.Rows[i].Cells["gpa"].Value = "1";
                            }
                            else if (Convert.ToDouble(grdStudentList.Rows[i].Cells["Percentage"].Value) >= 40 && (Convert.ToDouble(grdStudentList.Rows[i].Cells["Percentage"].Value) <= 49.99))
                            {
                                grdStudentList.Rows[i].Cells["grade"].Value = "c";
                                grdStudentList.Rows[i].Cells["gpa"].Value = "2";
                            }
                            else if (Convert.ToDouble(grdStudentList.Rows[i].Cells["Percentage"].Value) >= 50 && (Convert.ToDouble(grdStudentList.Rows[i].Cells["Percentage"].Value) <= 59.99))
                            {
                                grdStudentList.Rows[i].Cells["grade"].Value = "B";
                                grdStudentList.Rows[i].Cells["gpa"].Value = "3";
                            }
                            else if (Convert.ToDouble(grdStudentList.Rows[i].Cells["Percentage"].Value) >= 60 && (Convert.ToDouble(grdStudentList.Rows[i].Cells["Percentage"].Value) <= 69.99))
                            {
                                grdStudentList.Rows[i].Cells["grade"].Value = "A-";
                                grdStudentList.Rows[i].Cells["gpa"].Value = "3.50";
                            }
                            else if (Convert.ToDouble(grdStudentList.Rows[i].Cells["Percentage"].Value) >= 70 && (Convert.ToDouble(grdStudentList.Rows[i].Cells["Percentage"].Value) <= 79.99))
                            {
                                grdStudentList.Rows[i].Cells["grade"].Value = "A";
                                grdStudentList.Rows[i].Cells["gpa"].Value = "4";
                            }

                            else if (Convert.ToDouble(grdStudentList.Rows[i].Cells["Percentage"].Value) >= 80 && (Convert.ToDouble(grdStudentList.Rows[i].Cells["Percentage"].Value) <= 100))
                            {
                                grdStudentList.Rows[i].Cells["grade"].Value = "A+";
                                grdStudentList.Rows[i].Cells["gpa"].Value = "5.00";
                            }


                            if (txtTheoryPass.Text != "")
                            {
                                if (Convert.ToDouble(txtTheoryPass.Text) > Convert.ToDouble(grdStudentList.Rows[i].Cells["Theory"].Value))
                                {
                                    grdStudentList.Rows[i].Cells["grade"].Value = "F";
                                    grdStudentList.Rows[i].Cells["gpa"].Value = "0";
                                }

                            }
                            if (txtObjectivePass.Text != "")
                            {
                                if (Convert.ToDouble(txtObjectivePass.Text) > Convert.ToDouble(grdStudentList.Rows[i].Cells["Objective"].Value))
                                {
                                    grdStudentList.Rows[i].Cells["grade"].Value = "F";
                                    grdStudentList.Rows[i].Cells["gpa"].Value = "0";
                                }

                            }
                            if (txtPracticalPass.Text != "")
                            {
                                if (Convert.ToDouble(txtPracticalPass.Text) > Convert.ToDouble(grdStudentList.Rows[i].Cells["Practical"].Value))
                                {
                                    grdStudentList.Rows[i].Cells["grade"].Value = "F";
                                    grdStudentList.Rows[i].Cells["gpa"].Value = "0";
                                }

                            }
                    }
                    
                }
            }
            catch
            {
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                List<ExamMarksEntryBO> listExamMarksEntryBO = new List<ExamMarksEntryBO>();
                ExamMarksEntryBLL examMarksEntryBLL = new ExamMarksEntryBLL();
                for (int i = 0; i < grdStudentList.Rows.Count; i++)
                {

                    ExamMarksEntryBO examMarksEntryBO = new ExamMarksEntryBO();
                    examMarksEntryBO.exam_marks_assign_id = exam_marks_assignID;
                    examMarksEntryBO.exam_id = Convert.ToInt32(cmbExam.SelectedValue);
                    examMarksEntryBO.session_id = ApplicatinLauncher.session_id;
                    examMarksEntryBO.shift_id = 1;
                    examMarksEntryBO.class_id = Convert.ToInt32(cmbClass.SelectedValue);
                    examMarksEntryBO.section_id = Convert.ToInt32(cmbSection.SelectedValue);
                    examMarksEntryBO.student_id = Convert.ToInt32(grdStudentList.Rows[i].Cells[1].Value);
                    examMarksEntryBO.subject_id = Convert.ToInt32(cmbSubject.SelectedValue);
                    if (grdStudentList.Rows[i].Cells["Theory"].Value != null && grdStudentList.Rows[i].Cells["Theory"].Value != DBNull.Value)
                        examMarksEntryBO.theory = Convert.ToDecimal(grdStudentList.Rows[i].Cells["Theory"].Value);
                    if (grdStudentList.Rows[i].Cells["Objective"].Value != null && grdStudentList.Rows[i].Cells["Objective"].Value != DBNull.Value)
                        examMarksEntryBO.objective = Convert.ToDecimal(grdStudentList.Rows[i].Cells["Objective"].Value);
                    if (grdStudentList.Rows[i].Cells[6].Value != null && grdStudentList.Rows[i].Cells[6].Value !=DBNull.Value)
                        examMarksEntryBO.practical = Convert.ToDecimal(grdStudentList.Rows[i].Cells[6].Value);
                    if (grdStudentList.Rows[i].Cells["exam_total"].Value != null && grdStudentList.Rows[i].Cells["exam_total"].Value != DBNull.Value)
                        examMarksEntryBO.exam_total = Convert.ToDecimal(grdStudentList.Rows[i].Cells["exam_total"].Value);//theory+objective+Pratical
                    if(txtCTTotal.Text=="")
                        txtCTTotal.Text="00.00";
                    examMarksEntryBO.result_total = Convert.ToDecimal(txtExamTotal.Text) + Convert.ToDecimal(txtCTTotal.Text);//(exam+ct)//
                    if (grdStudentList.Rows[i].Cells["Result_Total"].Value != null && grdStudentList.Rows[i].Cells["Result_Total"].Value != DBNull.Value)
                        examMarksEntryBO.result_obtain_total = Convert.ToDecimal(grdStudentList.Rows[i].Cells["Exam_Obtain"].Value);
                    if(txtCTTotal.Text!="")
                        examMarksEntryBO.class_test_total = Convert.ToDecimal(txtCTTotal.Text);
                    if (grdStudentList.Rows[i].Cells["CT_no"].Value != null && grdStudentList.Rows[i].Cells["CT_no"].Value!= DBNull.Value)
                        examMarksEntryBO.class_test_obtain_total = Convert.ToDecimal(grdStudentList.Rows[i].Cells["CT_no"].Value);
                    if (grdStudentList.Rows[i].Cells["grade"].Value != null && grdStudentList.Rows[i].Cells["grade"].Value != DBNull.Value)
                        examMarksEntryBO.grade = grdStudentList.Rows[i].Cells["grade"].Value.ToString();
                    if (grdStudentList.Rows[i].Cells["gpa"].Value != null && grdStudentList.Rows[i].Cells["gpa"].Value != DBNull.Value)
                        examMarksEntryBO.gpa = Convert.ToDecimal(grdStudentList.Rows[i].Cells["gpa"].Value);
                    if (grdStudentList.Rows[i].Cells["Percentage"].Value != null && grdStudentList.Rows[i].Cells["Percentage"].Value != DBNull.Value)
                        examMarksEntryBO.percentage = Convert.ToDecimal(grdStudentList.Rows[i].Cells["Percentage"].Value);
                    examMarksEntryBO.status = 0;
                    if (grdStudentList.Rows[i].Cells["subject_status_id"].Value != null && grdStudentList.Rows[i].Cells["subject_status_id"].Value != DBNull.Value)

                    examMarksEntryBO.subject_status_id = Convert.ToInt32(grdStudentList.Rows[i].Cells["subject_status_id"].Value);
                    if (grdStudentList.Rows[i].Cells["Result_Total"].Value != null && grdStudentList.Rows[i].Cells["Result_Total"].Value != DBNull.Value)

                        examMarksEntryBO.grand_total = Convert.ToDecimal(grdStudentList.Rows[i].Cells["Result_Total"].Value);
                    examMarksEntryBO.subject_group_id = Subject_Group_ID;


                    examMarksEntryBO.record_created_by = ApplicatinLauncher._userId;
                    examMarksEntryBO.record_modified_by = ApplicatinLauncher._userId;

                    if(grdStudentList.Rows[i].Cells[0].Value.ToString() !="0")
                        examMarksEntryBO.exam_marks_entry_id = Convert.ToInt32(grdStudentList.Rows[i].Cells[0].Value);
                    listExamMarksEntryBO.Add(examMarksEntryBO);
                }
                int result = 0;
                if (btnSave.Text == "Save")
                    result = examMarksEntryBLL.ExamMarksEntryAdd(listExamMarksEntryBO);
                else
                {
                    result = examMarksEntryBLL.ExamMarksEntryUpdate(listExamMarksEntryBO);

                }
                if (result > 0)
                {
                    MessageBox.Show("Data Saved Seccessfully");
                    btnSave.Enabled = false;
                }
                Subject_Group_ID = 0;
            }
            catch
            {
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetLoad();
            cmbClass.Text = "";
            cmbSection.Text = "";
            cmbSubject.Text = "";
            txtExamTotalNo.Text = "";
            txtTheoryTotal.Text = "";
            txtTheoryPass.Text = "";
            txtObjectiveTotal.Text = "";
            txtObjectivePass.Text = "";
            txtPracticalTotal.Text = "";
            txtPracticalPass.Text = "";
            txtExamTotal.Text = "";
            txtCTTotal.Text = "";
            grdStudentList.Rows.Clear();
            btnSave.Text = "Save";
            btnSave.Enabled = true;
            exam_marks_assignID = 0;
            Subject_Group_ID = 0;
            grdStudentList.Columns[4].Visible = true;
            grdStudentList.Columns[5].Visible = true;
            grdStudentList.Columns[6].Visible = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Check();
        }



        

        

        

        
    }
}
