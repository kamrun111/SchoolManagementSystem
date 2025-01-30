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
    public partial class FrmCombainExamResult : BaseForm.FrmBase
    {
        public FrmCombainExamResult()
        {
            InitializeComponent();
        }
        CommonClass cs = new CommonClass();

        void GetLoad()
        {
            try
            {
                DataSet ds = cs.GetDataSet("StudentComboLoad");
                cs.PopulateComboBox(cmbSession, ds, 1, "session", "session_id");
                cs.PopulateComboBox(cmbShift, ds, 2, "shift", "shift_id");
                cs.PopulateComboBox(cmbClass, ds, 3, "class_name", "class_id");

             }
                catch
                {
                }
           }
        

        private void FrmSubjectGroupMark_Load(object sender, EventArgs e)
        {
            GetLoad();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                ExamCombineResultBLL examCombineResultBLL = new ExamCombineResultBLL();
                DataSet ds = examCombineResultBLL.ExamResultCombineLoad(Convert.ToInt32(cmbSession.SelectedValue), Convert.ToInt32(cmbShift.SelectedValue), Convert.ToInt32(cmbClass.SelectedValue));

                //if (ds.Tables[3].Rows.Count == 0)
                //{

                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        btnSave.Text = "Save";
                        grdStudentList.Rows.Clear();
                        int place = 0;
                        int PlaceInsection = 0;

                        List<SectionMap> maps = new List<SectionMap>();
                        SectionMap map = null;

                        foreach (DataRow row in ds.Tables[2].Rows)
                        {
                            map = new SectionMap();
                            map.SectionName = Convert.ToString(row["section_name"]);
                            map.NextPlace = 1;
                            maps.Add(map);
                        }

                        for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                        {
                            grdStudentList.Rows.Add();
                            grdStudentList.Rows[i].Cells[0].Value = ds.Tables[1].Rows[i][0];
                            grdStudentList.Rows[i].Cells[1].Value = ds.Tables[1].Rows[i][1];
                            grdStudentList.Rows[i].Cells[2].Value = ds.Tables[1].Rows[i][2];
                            grdStudentList.Rows[i].Cells[3].Value = ds.Tables[1].Rows[i][3];
                            grdStudentList.Rows[i].Cells[4].Value = ds.Tables[1].Rows[i][4];
                            grdStudentList.Rows[i].Cells[5].Value = ds.Tables[1].Rows[i][5];
                            grdStudentList.Rows[i].Cells[6].Value = ds.Tables[1].Rows[i][6];//section
                            grdStudentList.Rows[i].Cells[7].Value = ds.Tables[1].Rows[i][7];
                            grdStudentList.Rows[i].Cells[8].Value = ds.Tables[1].Rows[i][8];

                            if (grdStudentList.Rows[i].Cells[8].Value.ToString() != "F")
                            {
                                grdStudentList.Rows[i].Cells[9].Value = (place + i + 1).ToString();
                            }
                            grdStudentList.Rows[i].Cells[10].Value = GetNextPlace(maps, Convert.ToString(ds.Tables[1].Rows[i][6]));
                            grdStudentList.Rows[i].Cells[12].Value = ds.Tables[1].Rows[i][9];
                            grdStudentList.Rows[i].Cells[13].Value = ds.Tables[1].Rows[i][10];

                        }
                    }
                    else
                    {
                        MessageBox.Show("Exam Result Not Saved Yet. Please Save Exam Result to Prepare Combained Result");
                    }
                //}
                //else
                //    MessageBox.Show("Result Already Exist");
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
                List<ExamCombineResultBO> listExamCombineResultBO = new List<ExamCombineResultBO>();
                ExamCombineResultBLL examCombineResultBLL = new ExamCombineResultBLL();
                for (int i = 0; i < grdStudentList.Rows.Count; i++)
                {

                    ExamCombineResultBO examCombineResultBO = new ExamCombineResultBO();
                    examCombineResultBO.session_id = Convert.ToInt32(grdStudentList.Rows[i].Cells[0].Value);
                    examCombineResultBO.shift_id = Convert.ToInt32(grdStudentList.Rows[i].Cells[1].Value);
                    examCombineResultBO.class_id = Convert.ToInt32(grdStudentList.Rows[i].Cells[2].Value);
                    examCombineResultBO.section_id = Convert.ToInt32(grdStudentList.Rows[i].Cells[3].Value);
                    examCombineResultBO.student_id = Convert.ToInt32(grdStudentList.Rows[i].Cells[4].Value);
                    if (grdStudentList.Rows[i].Cells["roll"].Value != null)
                        examCombineResultBO.roll_no = Convert.ToInt32(grdStudentList.Rows[i].Cells["roll"].Value);
                    examCombineResultBO.gpa = Convert.ToDecimal(grdStudentList.Rows[i].Cells[7].Value);
                    examCombineResultBO.grade = grdStudentList.Rows[i].Cells["student_grade"].Value.ToString();
                    if (grdStudentList.Rows[i].Cells[9].Value != null)
                        examCombineResultBO.place = Convert.ToInt32(grdStudentList.Rows[i].Cells[9].Value);
                    if (grdStudentList.Rows[i].Cells["sectionPlace"].Value != null)
                        examCombineResultBO.place_in_section = Convert.ToInt32(grdStudentList.Rows[i].Cells["sectionPlace"].Value);
                    if (grdStudentList.Rows[i].Cells[11].Value != null)
                        examCombineResultBO.remarks = grdStudentList.Rows[i].Cells[11].Value.ToString();
                    if (grdStudentList.Rows[i].Cells[12].Value != null)
                        examCombineResultBO.total_marks = Convert.ToDecimal(grdStudentList.Rows[i].Cells[12].Value);
                    examCombineResultBO.record_created_by = ApplicatinLauncher._userId;
                    listExamCombineResultBO.Add(examCombineResultBO);

                }
                int result = 0;
                result = examCombineResultBLL.ExamCombineResultSave(listExamCombineResultBO);
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
                btnSave.Enabled = true;
            }
            catch
            {
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        class SectionMap
        {
            public string SectionName { get; set; }
            public int NextPlace { get; set; }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you want to Delete Combine Result?", "SMS", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
                ExamCombineResultBLL examCombineResultBLL = new ExamCombineResultBLL();
                DataSet ds = examCombineResultBLL.deleteCombineResult(Convert.ToInt32(cmbSession.SelectedValue), Convert.ToInt32(cmbShift.SelectedValue), Convert.ToInt32(cmbClass.SelectedValue));
                MessageBox.Show("Combine Result Deleted Successfully");
            }
            catch
            {
            }
        }



 


    }
}
