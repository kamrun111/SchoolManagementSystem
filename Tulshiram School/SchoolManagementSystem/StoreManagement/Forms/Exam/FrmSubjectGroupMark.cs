using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SchoolManagementSystem.Forms.Exam
{
    public partial class FrmSubjectGroupMark : Form
    {
        public FrmSubjectGroupMark()
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
                cs.PopulateComboBox(cmbSession, ds, 1, "session", "session_id");
                cs.PopulateComboBox(cmbShift, ds, 2, "shift", "shift_id");
                cs.PopulateComboBox(cmbExam, ds, 11, "exam_name", "exam_id");
                cs.PopulateComboBox(cmbSubjectGroup, ds, 13, "subject_group_name", "subject_group_id");

                cmbExam.SelectedIndexChanged += new EventHandler(cmbExam_SelectedIndexChanged);



            }
            catch
            {
            }
        }

        private void FrmSubjectGroupMark_Load(object sender, EventArgs e)
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
                //cmbSubject.SelectedIndexChanged -= new EventHandler(cmbSubject_SelectedIndexChanged);

                if (cmbClass.SelectedIndex > -1)
                {

                    DataSet ds = cs.GetDataSetWithParameter("@class_id", Convert.ToInt32(cmbClass.SelectedValue), "StudentSectionLoad");
                    if (ds.Tables[0].Rows.Count > 0)
                        cs.PopulateComboBox(cmbSection, ds, 0, "section_name", "section_id");

                    //DataSet da = cs.GetDataSetWithTwoIntParameter("@class_id", "@exam_id", Convert.ToInt32(cmbClass.SelectedValue), Convert.ToInt32(cmbExam.SelectedValue), "ExamMarksSubject");
                    //if (da.Tables[0].Rows.Count > 0)
                    //    cs.PopulateComboBox(cmbSubject, da, 0, "subject", "subject_id");

                }
                //cmbSubject.SelectedIndexChanged += new EventHandler(cmbSubject_SelectedIndexChanged);



            }
            catch
            {
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }
    }
}
