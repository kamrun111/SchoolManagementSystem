
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

namespace SchoolManagementSystem.Forms.Subject
{
    public partial class FrmSubjectAssign : BaseForm.FrmBase
    {
        public FrmSubjectAssign()
        {
            InitializeComponent();
        }
        CommonClass cs = new CommonClass();
        int Ismain,Assign = 0;

        void GetLoad()
        {
            try
            {
                cmbClass.SelectedIndexChanged -= new EventHandler(cmbClass_SelectedIndexChanged);

                cmbSection.SelectedIndexChanged -= new System.EventHandler(cmbSection_SelectedIndexChanged);
                DataSet ds = cs.GetDataSet("StudentComboLoad");
                cs.PopulateComboBox(cmbShift, ds, 2, "shift", "shift_id");
                cs.PopulateComboBox(cmbClass, ds, 3, "class_name", "class_id");
                cmbClass.SelectedIndexChanged += new EventHandler(cmbClass_SelectedIndexChanged);
                cmbSection.SelectedIndexChanged += new EventHandler(cmbSection_SelectedIndexChanged);
                cmbShift.SelectedValue = 1;

            }
            catch
            {
            }
        }


        private void FrmSubjectAssign_Load(object sender, EventArgs e)
        {
            GetLoad();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbClass.SelectedIndex > -1)
                {
                    cmbSection.SelectedIndexChanged -= new System.EventHandler(cmbSection_SelectedIndexChanged);

                    cmbSection.DataSource = null;
                    StudentBLL studentBLL = new StudentBLL();
                    DataSet ds = studentBLL.StudentSectionLoad(Convert.ToInt32(cmbClass.SelectedValue));
                    if (ds.Tables[0].Rows.Count > 0)
                        cs.PopulateComboBox(cmbSection, ds, 0, "section_name", "section_id");
                    cmbSection.SelectedIndexChanged += new EventHandler(cmbSection_SelectedIndexChanged);

                    DataSet da = cs.GetDataSetWithParameter("@class_id", Convert.ToInt32(cmbClass.SelectedValue), "SubjectLoadClassWise");
                    if (da.Tables[0].Rows.Count > 0)
                    {
                        grdSubjectList.Rows.Clear();
                        for (int i = 0; i < da.Tables[0].Rows.Count; i++)
                        {
                            grdSubjectList.Rows.Add();
                            grdSubjectList.Rows[i].Cells[0].Value = 1;
                            grdSubjectList.Rows[i].Cells[1].Value = da.Tables[0].Rows[i][0];
                            grdSubjectList.Rows[i].Cells[2].Value = da.Tables[0].Rows[i][1];



                        }
                    }
                    else
                        grdStudentList.Rows.Clear();

                    

                }
            }
            catch
            {
            }
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
                        grdStudentList.Rows.Clear();
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            grdStudentList.Rows.Add();
                            grdStudentList.Rows[i].Cells[0].Value = 1;
                            grdStudentList.Rows[i].Cells[1].Value = ds.Tables[0].Rows[i][0];
                            grdStudentList.Rows[i].Cells[2].Value = ds.Tables[0].Rows[i][1];
                            grdStudentList.Rows[i].Cells[3].Value = ds.Tables[0].Rows[i][5];
                            grdStudentList.Rows[i].Cells[4].Value = ds.Tables[0].Rows[i][2];
                            grdStudentList.Rows[i].Cells[5].Value = ds.Tables[0].Rows[i][9];
                         
                         
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private void rdoCompolsary_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = cs.GetDataSet("SubjectLoad");
                if (rdoCompolsary.Checked == true)
                {
                    rdoCompolsaryAssign.Checked = true;
                    Ismain = 1;
                    grdSubjectList.Rows.Clear();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        grdSubjectList.Rows.Add();
                        grdSubjectList.Rows[i].Cells[0].Value = 1;
                        grdSubjectList.Rows[i].Cells[1].Value = ds.Tables[0].Rows[i][0];
                        grdSubjectList.Rows[i].Cells[2].Value = ds.Tables[0].Rows[i][1];
                       


                    }
                }
                else
                {
                    Ismain = 0;
                    grdSubjectList.Rows.Clear();
                    for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                    {
                        grdSubjectList.Rows.Add();
                        grdSubjectList.Rows[i].Cells[0].Value = 1;
                        grdSubjectList.Rows[i].Cells[1].Value = ds.Tables[1].Rows[i][0];
                        grdSubjectList.Rows[i].Cells[2].Value = ds.Tables[1].Rows[i][1];



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
                if (grdStudentList.Rows.Count == 0)
                    return;
                if (grdSubjectList.Rows.Count == 0)
                    return;
                List<SubjectAssignBO> listSubjectAssignBO = new List<SubjectAssignBO>();
                SubjectAssignBLL subjectAssignBLL = new SubjectAssignBLL();

                for (int j = 0; j < grdSubjectList.Rows.Count; j++)
                {
                    if (rdoCompolsaryAssign.Checked == true)
                    {
                        Ismain = 1;
                    }
                    else
                        Ismain = 0;
                    if (Convert.ToInt32(grdSubjectList.Rows[j].Cells[0].Value) == 1)
                    {
                        for (int i = 0; i < grdStudentList.Rows.Count; i++)
                        {
                           
                                SubjectAssignBO subjectAssignBO = new SubjectAssignBO();
                                subjectAssignBO.shift_id = Convert.ToInt32(cmbShift.SelectedValue);
                                subjectAssignBO.class_id = Convert.ToInt32(cmbClass.SelectedValue);
                                subjectAssignBO.section_id = Convert.ToInt32(cmbSection.SelectedValue);
                                subjectAssignBO.session_id=Convert.ToInt32(grdStudentList.Rows[i].Cells[5].Value);
                                subjectAssignBO.student_id = Convert.ToInt32(grdStudentList.Rows[i].Cells[1].Value);
                                subjectAssignBO.subject_id = Convert.ToInt32(grdSubjectList.Rows[j].Cells[1].Value);
                                if (Convert.ToInt32(grdStudentList.Rows[i].Cells[0].Value) == 1)
                                    subjectAssignBO.assign = 1;
                                else
                                    subjectAssignBO.assign = 0;

                                subjectAssignBO.is_main = Ismain;
                                subjectAssignBO.record_created_by = ApplicatinLauncher._userId;
                                subjectAssignBO.session_id = ApplicatinLauncher.session_id;
                                listSubjectAssignBO.Add(subjectAssignBO);
                            
                        }
                    }
                }
                int result = subjectAssignBLL.SubjectAssignAdd(listSubjectAssignBO);
                if (result > 0)
                    MessageBox.Show("Data Saved Successfully");
                btnSave.Enabled = false;
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

                for (int i = 0; i < grdSubjectList.Rows.Count; i++)
                {
                    grdSubjectList.Rows[i].Cells[0].Value = true;

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

                for (int i = 0; i < grdSubjectList.Rows.Count; i++)
                {
                    grdSubjectList.Rows[i].Cells[0].Value = false;

                }
            }


            catch
            {
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            grdStudentList.Rows.Clear();
            grdSubjectList.Rows.Clear();
            btnSave.Enabled = true;

        }
     

       

       
    }
}
