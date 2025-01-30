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
    public partial class FrmSubjectEntry : BaseForm.FrmBase
    {
        public FrmSubjectEntry()
        {
            InitializeComponent();
        }

        CommonClass cs = new CommonClass();
        void GetLoad()
        {
            try
            {
                DataSet ds = cs.GetDataSet("SubjectEditLoad");
                cs.FillUpListview(lvwSubject, ds, 0);
                btnSave.Enabled = true;
                txtSubject.Text = "";
                txtSubjectCode.Text = "";
            }
            catch
            {
            }
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSubject.Text == "")
                {
                    txtSubject.Focus();
                    return;
                }

                SubjectBO subjectBO = new SubjectBO();
                SubjectBLL subjectBLL = new SubjectBLL();
                subjectBO.subject = txtSubject.Text;
                subjectBO.subject_code = Convert.ToInt32(txtSubjectCode.Text);
                if (cmbSubjectStatus.Text=="Compolsary")
                    subjectBO.is_main=1;
                else
                    subjectBO.is_main = 0;
                subjectBO.record_created_by = ApplicatinLauncher._userId;

                int result = 0;

                if (btnSave.Text == "Save")
                    result = subjectBLL.SubjectADD(subjectBO);
                else
                {
                    subjectBO.subject_id = Convert.ToInt32(lvwSubject.SelectedItems[0].Text);
                    result = subjectBLL.SubjectUpdate(subjectBO);
                }


                if (result > 0)
                {
                    MessageBox.Show("Data Saved Sussessfully");
                    btnSave.Enabled = false;
                    GetRefresh();
                    GetLoad();

                }
                subjectBO = null;
            }
            catch
            {
            }
        }

        void GetRefresh()
        {
            try
              {
                  txtSubject.Text = "";
                  txtSubjectCode.Text = "";
                  cmbSubjectStatus.SelectedValue = "";
                  btnSave.Enabled = true;
                  btnSave.Text = "Save";
              }
            catch
             {
             }

            }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetRefresh();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmSubjectEntry_Load(object sender, EventArgs e)
        {
            GetLoad();
        }

        private void lvwSubject_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    if (lvwSubject.SelectedItems.Count > 0)
                    {
                        txtSubject.Text = lvwSubject.SelectedItems[0].SubItems[1].Text;
                        txtSubjectCode.Text = lvwSubject.SelectedItems[0].SubItems[2].Text;
                        if (lvwSubject.SelectedItems[0].SubItems[3].Text == "1")
                            cmbSubjectStatus.Text = "Compolsary";
                        else
                            cmbSubjectStatus.Text = "Optional";
                            btnSave.Text = "Update";


                    }
                }
                catch
                {
                }
            }

        }
    }
}
