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

namespace SchoolManagementSystem.Forms.Students
{
    public partial class FrmStudentPromotion : Form
    {
        public FrmStudentPromotion(int promotionClassId)
        {
            InitializeComponent();
            lblPromotionClassID.Text = promotionClassId.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        CommonClass cs = new CommonClass();
        void GetLoad()
        {
            try
            {
                DataSet ds = cs.GetDataSetWithParameter("@promotionClassId", Convert.ToInt32(lblPromotionClassID.Text), "PromotionStudentLoad");
                cs.PopulateComboBox(cmbSession, ds,1, "session", "session_id");
                cs.PopulateComboBox(cmbClass, ds, 2, "class_name", "class_id");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    grdStudentList.Rows.Clear();
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
                        grdStudentList.Rows[i].Cells[7].Value = true;
                    }
                    lblCount.Text = grdStudentList.Rows.Count.ToString();
                }
            }
            catch
            {
            }
        }
        private void FrmStudentPromotion_Load(object sender, EventArgs e)
        {
            try
            {
                GetLoad();
            }
            catch
            {
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                lblCount.Text = "";
                btnSave.Enabled = true;
                GetLoad();
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
                    cmbSection.DataSource = null;
                    StudentBLL studentBLL = new StudentBLL();
                    DataSet ds = studentBLL.StudentSectionLoad(Convert.ToInt32(cmbClass.SelectedValue));
                    if (ds.Tables[0].Rows.Count > 0)
                        cs.PopulateComboBox(cmbSection, ds, 0, "section_name", "section_id");
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
                if (cmbSession.SelectedIndex == -1)
                    return;
                if (cmbClass.SelectedIndex == -1)
                    return;
                if (cmbSection.SelectedIndex == -1)
                    return;
                List<StudentBO> listStudentBO = new List<StudentBO>();
                StudentBLL studentBLL = new StudentBLL();
                for (int i = 0; i < grdStudentList.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(grdStudentList.Rows[i].Cells["Select"].Value) == true)
                    {
                        StudentBO studentBO = new StudentBO();
                        studentBO.student_id = Convert.ToInt32(grdStudentList.Rows[i].Cells[0].Value);
                        studentBO.session_id = Convert.ToInt32(cmbSession.SelectedValue);
                        studentBO.class_id = Convert.ToInt32(cmbClass.SelectedValue);
                        studentBO.section_id = Convert.ToInt32(cmbSection.SelectedValue);
                        studentBO.shift_id = Convert.ToInt32(grdStudentList.Rows[i].Cells["shift_id"].Value);
                        if (grdStudentList.Rows[i].Cells["NewRoll"].Value != null && grdStudentList.Rows[i].Cells["NewRoll"].Value.ToString() != "")
                            studentBO.roll_no = Convert.ToInt32(grdStudentList.Rows[i].Cells["NewRoll"].Value);
                        listStudentBO.Add(studentBO);
                    }
                }
                int result = studentBLL.StudentPromotionAdd(listStudentBO);
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
            }
            catch
            {
            }
        }
    }
}
