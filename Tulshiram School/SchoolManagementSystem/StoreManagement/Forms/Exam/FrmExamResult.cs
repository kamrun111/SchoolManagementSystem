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
    public partial class FrmExamResult : BaseForm.FrmBase
    {
        public FrmExamResult()
        {
            InitializeComponent();
        }
        CommonClass cs = new CommonClass();
        string Grade ="";
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        void getLoad()
        {
            try
            {
                DataSet ds = cs.GetDataSet("StudentComboLoad");
                cs.PopulateComboBox(cmbSession, ds, 1, "session", "session_id");
                cs.PopulateComboBox(cmbExam, ds, 11, "exam_name", "exam_id");
                cs.PopulateComboBox(cmbClass, ds, 3, "class_name", "class_id");
                

            }
            catch
            {
            }
        }

        private void FrmExamResult_Load(object sender, EventArgs e)
        {
            try
            {
                getLoad();
            }
            catch
            {
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                ExamMarksEntryBLL examMarksEntryBLL = new ExamMarksEntryBLL();
                DataSet ds = examMarksEntryBLL.ExamResultLoad1(Convert.ToInt32(cmbSession.SelectedValue), Convert.ToInt32(cmbExam.SelectedValue), Convert.ToInt32(cmbClass.SelectedValue));
                if (ds.Tables[2].Rows.Count == 0)
                {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    btnSave.Text = "Save";
                    grdStudentList.Rows.Clear();
                    int place = 0;
                    int PlaceInsection = 0;

                    List<SectionMap> maps = new List<SectionMap>();
                    SectionMap map = null;

                    foreach (DataRow row in ds.Tables[1].Rows)
                    {
                        map = new SectionMap();
                        map.SectionName = Convert.ToString(row["section_name"]);
                        map.NextPlace = 1;
                        maps.Add(map);
                    }                    

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        grdStudentList.Rows.Add();
                        grdStudentList.Rows[i].Cells[0].Value = ds.Tables[0].Rows[i][0]; 
                        grdStudentList.Rows[i].Cells[1].Value = ds.Tables[0].Rows[i][1];
                        grdStudentList.Rows[i].Cells[2].Value = ds.Tables[0].Rows[i][2];
                        grdStudentList.Rows[i].Cells[3].Value = ds.Tables[0].Rows[i][3];
                        grdStudentList.Rows[i].Cells[4].Value = ds.Tables[0].Rows[i][4];
                        grdStudentList.Rows[i].Cells[5].Value = ds.Tables[0].Rows[i][5];
                        grdStudentList.Rows[i].Cells[6].Value = ds.Tables[0].Rows[i][6];
                        grdStudentList.Rows[i].Cells[7].Value = ds.Tables[0].Rows[i][7];
                        grdStudentList.Rows[i].Cells[8].Value = ds.Tables[0].Rows[i][8];
                        grdStudentList.Rows[i].Cells[9].Value = ds.Tables[0].Rows[i][9];
                        grdStudentList.Rows[i].Cells[10].Value = ds.Tables[0].Rows[i][11];
                        grdStudentList.Rows[i].Cells[11].Value = ds.Tables[0].Rows[i][10];
                        if (grdStudentList.Rows[i].Cells[10].Value.ToString()!="F")
                        {
                            grdStudentList.Rows[i].Cells[12].Value = (place + i + 1).ToString();
                        }
                        grdStudentList.Rows[i].Cells[14].Value = GetNextPlace(maps, Convert.ToString(ds.Tables[0].Rows[i][10]));
                        
                    }
                    
                    }
                }
                else
                    MessageBox.Show("Result Already Exist");
            }
            catch
            {
            }
        }
        private void CalculateGpa(double gpa)
        {
            try
            {
                Grade = "";
                if (gpa == 0)
                {
                    Grade = "F";

                }
                else if (gpa >= 1 && gpa < 2)
                {
                    Grade = "D";

                }
                else if (gpa >= 2 && gpa < 3)
                {
                    Grade = "C";
                }

                else if (gpa >= 3 && gpa < 3.5)
                {
                    Grade = "B";

                }
                else if (gpa >= 3.5 && gpa < 4)
                {
                    Grade = "A-";
                }

                else if (gpa >= 4 && gpa < 5)
                {
                    Grade = "A";
                }
                else if (gpa == 5)
                {
                    Grade = "A+";
                }

            }
            catch
            {
            }
        }

        private int GetNextPlace(List<SectionMap> maps, string sectionName)
        {
            int NextPlace = 0;

            foreach (SectionMap map in maps)
            {
                if (map.SectionName == sectionName)
                {
                    NextPlace = map.NextPlace;
                    map.NextPlace++;
                    break;
                }
            }

            return NextPlace;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                List<ExamResultBO> listExamResultBO = new List<ExamResultBO>();
                ExamResultBLL examResultBLL = new ExamResultBLL();
                for (int i = 0; i < grdStudentList.Rows.Count; i++)
                {

                    ExamResultBO examResultBO = new ExamResultBO();
                    examResultBO.exam_id = Convert.ToInt32(grdStudentList.Rows[i].Cells[0].Value);
                    examResultBO.session_id = Convert.ToInt32(grdStudentList.Rows[i].Cells[1].Value);
                    examResultBO.shift_id = Convert.ToInt32(grdStudentList.Rows[i].Cells[2].Value);
                    examResultBO.class_id = Convert.ToInt32(grdStudentList.Rows[i].Cells[3].Value);
                    examResultBO.section_id = Convert.ToInt32(grdStudentList.Rows[i].Cells[4].Value); 
                    examResultBO.student_id = Convert.ToInt32(grdStudentList.Rows[i].Cells[5].Value);
                    examResultBO.total_no = Convert.ToInt32(grdStudentList.Rows[i].Cells[8].Value);
                    examResultBO.gpa = Convert.ToDecimal(grdStudentList.Rows[i].Cells[9].Value);
                    examResultBO.grade = grdStudentList.Rows[i].Cells["student_grade"].Value.ToString();
                    if (grdStudentList.Rows[i].Cells[12].Value != null)
                        examResultBO.place = Convert.ToInt32(grdStudentList.Rows[i].Cells[12].Value);
                    if(grdStudentList.Rows[i].Cells[13].Value!=null)
                     examResultBO.remarks = grdStudentList.Rows[i].Cells[13].Value.ToString();
                    examResultBO.record_created_by = ApplicatinLauncher._userId;
                    if (grdStudentList.Rows[i].Cells["sectionPlace"].Value != null)
                        examResultBO.place_in_section = Convert.ToInt32(grdStudentList.Rows[i].Cells["sectionPlace"].Value);
                    if (grdStudentList.Rows[i].Cells["roll"].Value != null)
                        examResultBO.roll_no = Convert.ToInt32(grdStudentList.Rows[i].Cells["roll"].Value);
                    listExamResultBO.Add(examResultBO);

                }
                int result = 0;
                result=examResultBLL.ExamResultSave(listExamResultBO);
                if (result > 0)
                {
                    MessageBox.Show("Data Saved Successfully");
                    btnSave.Enabled = false;
                }

            }
            catch
            {
            }
        }

        void refresh()
        {
            try
            {
                grdStudentList.Rows.Clear();
                Grade = "";
                btnSave.Enabled = true;
            }
            catch
            {
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you want to Delete Result?", "SMS", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
                ExamMarksEntryBLL examMarksEntryBLL = new ExamMarksEntryBLL();
                DataSet ds = examMarksEntryBLL.deleteResult(Convert.ToInt32(cmbSession.SelectedValue), Convert.ToInt32(cmbExam.SelectedValue), Convert.ToInt32(cmbClass.SelectedValue));
                MessageBox.Show("Result deleted successfully");
            }
            catch
            {
            }
        }





    }

    class SectionMap
    {
        public string SectionName { get; set; }
        public int NextPlace { get; set; }
    }
}
