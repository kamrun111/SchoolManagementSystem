using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SchoolManagementSystem.BLL;
using SchoolManagementSystem.BusinessObjects;

namespace SchoolManagementSystem.Forms.Subject
{
    public partial class FrmSubjectSeclection : Form
    {
        public FrmSubjectSeclection()
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

                    cs.PopulateComboBox(cmbShift, ds, 2, "shift", "shift_id");
                    cs.PopulateComboBox(cmbClass, ds, 3, "class_name", "class_id");
                }
                DataSet da = cs.GetDataSet("SubjectEditLoad");
                if (da.Tables[0].Rows.Count > 0)
                {
                    grdSubjectList.Rows.Clear();
                    for (int i = 0; i < da.Tables[0].Rows.Count; i++)
                    {
                        grdSubjectList.Rows.Add();
                        grdSubjectList.Rows[i].Cells[0].Value = 0;
                        grdSubjectList.Rows[i].Cells[1].Value = da.Tables[0].Rows[i][0];
                        grdSubjectList.Rows[i].Cells[2].Value = da.Tables[0].Rows[i][1];
                       


                    }
                }
                cs.FillUpListview(lvwSubject, da, 1);
            }
            catch
            {
            }
        }
        private void FrmSubjectSeclection_Load(object sender, EventArgs e)
        {
            try
            {
                GetLoad();
            }
            catch
            {
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbShift.Text == "<Select>")
                {
                    cmbShift.Focus();
                    return;
                }
                if (cmbClass.Text == "<Select>")
                {
                    cmbClass.Focus();
                    return;
                }

                List<ClassWiseSubjectBO> listClassWiseSubjectBO = new List<ClassWiseSubjectBO>();
                ClassWiseSubjectBLL classWiseSubjectBLL = new ClassWiseSubjectBLL();
                for (int i = 0; i < grdSubjectList.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(grdSubjectList.Rows[i].Cells[0].Value) == true)
                    {
                        ClassWiseSubjectBO classWiseSubjectBO = new ClassWiseSubjectBO();
                        classWiseSubjectBO.shift_id = Convert.ToInt32(cmbShift.SelectedValue);
                        classWiseSubjectBO.class_id = Convert.ToInt32(cmbClass.SelectedValue);
                        classWiseSubjectBO.subject_id = Convert.ToInt32(grdSubjectList.Rows[i].Cells[1].Value);
                        classWiseSubjectBO.record_created_by = ApplicatinLauncher._userId;
                        if (Convert.ToInt32(grdSubjectList.Rows[i].Cells[0].Value) == 1)
                            classWiseSubjectBO.status = 1;
                        else
                            classWiseSubjectBO.status = 0;
                        listClassWiseSubjectBO.Add(classWiseSubjectBO);

                    }
                 }
                    int result = classWiseSubjectBLL.ClassWiseSubjectAdd(listClassWiseSubjectBO);
                    if (result > 0)
                        MessageBox.Show("Data Saved Successfully");
                    btnSave.Enabled = false;
                
                
            }
            catch
            {
            }
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
    }
}
