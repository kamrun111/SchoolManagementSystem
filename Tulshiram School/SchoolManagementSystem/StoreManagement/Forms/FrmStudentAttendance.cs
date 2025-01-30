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

namespace SchoolManagementSystem.Forms.Attendence
{
    public partial class FrmStudentAttendance : BaseForm.FrmBase
    {
        public FrmStudentAttendance()
        {
            InitializeComponent();
        }
        CommonClass cs = new CommonClass();
        void GetLoad()
        {
            try
            {
                this.cmbClass.SelectedIndexChanged -= this.cmbClass_SelectedIndexChanged;
                DataSet ds = cs.GetDataSet("StudentAdmissionLoad");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    cs.PopulateComboBox(cmbClass, ds, 0, "class_name", "class_id");
                    cs.PopulateComboBox(cmbTeacher, ds, 1, "teacher_name", "teacher_id");
                }
                this.cmbClass.SelectedIndexChanged += new System.EventHandler(this.cmbClass_SelectedIndexChanged);
            }
            catch
            {
            }
        }

        private void FrmStudentAttendance_Load(object sender, EventArgs e)
        {
            GetLoad();
        }

        private void cmbSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbSection.SelectedIndex > -1)
                {
                    AssignClassBLL assignClassBLL = new AssignClassBLL();
                    DataSet ds = assignClassBLL.StudentAttendanceLoad(Convert.ToInt32(cmbClass.SelectedValue),Convert.ToInt32(cmbSection.SelectedValue));
                    if (ds.Tables[0].Rows.Count > 0)
                        cmbTeacher.SelectedValue = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                    else
                        cmbTeacher.SelectedIndex = -1;

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
                if (cmbClass.SelectedIndex > -1)
                {
                    DataSet ds = cs.GetDataSetWithParameter("@class_id", Convert.ToInt32(cmbClass.SelectedValue), "StudentAdmissionSection");
                    if (ds.Tables[0].Rows.Count > 0)
                        cs.PopulateComboBox(cmbSection, ds, 0, "section_name", "section_id");

                }
            }
            catch
            {
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch
            {
            }
                      
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
