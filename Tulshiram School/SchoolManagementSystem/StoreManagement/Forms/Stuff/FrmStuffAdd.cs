using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SchoolManagementSystem.BusinessObjects;
using SchoolManagementSystem.BLL;

namespace SchoolManagementSystem.Forms.Stuff
{
    public partial class FrmStuffAdd : BaseForm.FrmBase
    {
        public FrmStuffAdd()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        CommonClass cs = new CommonClass();

        void GetLoad()
        {
            try
            {
                DataSet ds = cs.GetDataSetWithParameter("@id", 0, "StuffInformationLoad");
                cs.PopulateComboBox(cmbType, ds, 0, "student_status", "student_status_id");
                cmbType.SelectedValue = 1;
                cs.PopulateComboBox(cmbShift, ds, 1, "shift", "shift_id");
                cmbShift.SelectedValue = 1;
                cs.FillUpListview(lvwStuffInformation, ds, 2);
            }
            catch
            {
            }
        }

        private void FrmStuffAdd_Load(object sender, EventArgs e)
        {
            try
            {

                //WindowState = FormWindowState.Maximized;
                GetLoad();
            }
            catch
            {
            }
        }
        bool CheckAll()
        {
            try
            {
                if (txtStuff.Text == "")
                {
                    txtStuff.Focus();
                    return false;
                }
                if (cmbShift.SelectedIndex == -1)
                {
                    cmbShift.Focus();
                    return false;
                }
                if (txtFatherName.Text == "")
                {
                    txtFatherName.Focus();
                    return false;
                }
                if (txtMotherName.Text == "")
                {
                    txtMotherName.Focus();
                    return false;
                }
                if (txtAddress.Text == "")
                {
                    txtAddress.Focus();
                    return false;
                }
                if (txtContact.Text == "")
                {
                    txtContact.Focus();
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void txtnameSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                DataSet ds = cs.GetDataSetWithStringParameter("@teacher_name", txtnameSearch.Text, "TeacherSearchName");
                if (ds.Tables[1].Rows.Count > 0)
                {
                    cs.FillUpListview(lvwStuffInformation, ds, 1);
                }
            }
            catch
            {
            }
        }

        private void lvwStuffInformation_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvwStuffInformation.SelectedItems.Count > 0)
                {
                    btnSave.Text = "Update";
                    DataSet ds = cs.GetDataSetWithParameter("@id", Convert.ToInt32(lvwStuffInformation.SelectedItems[0].Text), "StuffInformationLoad");
                    if (ds.Tables[3].Rows.Count > 0)
                    {
                        txtRegisreationNo.Text = ds.Tables[3].Rows[0][1].ToString();
                        txtStuff.Text = ds.Tables[3].Rows[0][2].ToString();
                        cmbShift.SelectedValue = 1;
                        txtFatherName.Text = ds.Tables[3].Rows[0][8].ToString();
                        txtMotherName.Text = ds.Tables[3].Rows[0][9].ToString();
                        txtfilePath.Text = ds.Tables[3].Rows[0][10].ToString();
                        if (ds.Tables[3].Rows[0][11].ToString() != "")
                            dtpDOB.Value = Convert.ToDateTime(ds.Tables[3].Rows[0][11]);
                        if (ds.Tables[3].Rows[0][4].ToString() == "Male")
                            rdomale.Checked = true;
                        else
                            rdoFemale.Checked = true; ;
                        if (ds.Tables[3].Rows[0][7].ToString() != "")
                            dtpJoiningDate.Value = Convert.ToDateTime(ds.Tables[3].Rows[0][7]);
                        txtContact.Text = ds.Tables[3].Rows[0][5].ToString();
                        txtAddress.Text = ds.Tables[3].Rows[0][12].ToString();
                        btnSave.Text = "Update";
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
                if (CheckAll() == true)
                {
                    StuffBO stuffBO = new StuffBO();
                    StuffBLL stuffBLL = new StuffBLL();
                    stuffBO.stuff_name = txtStuff.Text;
                    stuffBO.father_name = txtFatherName.Text;
                    stuffBO.mother_name = txtMotherName.Text;
                    stuffBO.address = txtAddress.Text;
                    stuffBO.contact = txtContact.Text;
                    stuffBO.dob = Convert.ToDateTime(dtpDOB.Value);
                    stuffBO.joing_date = Convert.ToDateTime(dtpJoiningDate.Value);
                    stuffBO.shift_id = 1;
                    stuffBO.stuff_status = Convert.ToInt32(cmbType.SelectedValue);
                    if (rdomale.Checked == true)
                        stuffBO.gender_id = 1;
                    else
                        stuffBO.gender_id = 2;
                    stuffBO.image = txtfilePath.Text;
                    stuffBO.record_created_by = ApplicatinLauncher._userId;
                    int result = 0;
                    if (btnSave.Text == "Save")
                        result = stuffBLL.StuffAdd(stuffBO);
                    else
                    {
                        stuffBO.record_modified_by = ApplicatinLauncher._userId;
                        stuffBO.stuff_id = Convert.ToInt32(lvwStuffInformation.SelectedItems[0].Text);
                        result = stuffBLL.StuffUpdate(stuffBO);
                    }

                    if (result > 0)
                    {
                        MessageBox.Show("Data Saved Sussessfully");
                        btnSave.Enabled = false;
                        GetRefresh();
                        GetLoad();

                    }
                    stuffBO = null;

                }

            }
            catch
            {
            }
        }
        void GetRefresh()
        {
            try
            {
                txtStuff.Text = "";
                txtFatherName.Text = "";
                txtMotherName.Text = "";
                txtAddress.Text = "";
                txtContact.Text = "";
                dtpDOB.Value = DateTime.Now;
                dtpJoiningDate.Value = DateTime.Now;
                txtnameSearch.Text = "";
                cmbShift.SelectedIndex = 1;
                txtfilePath.Text = "";
                btnSave.Enabled = true;
                txtRegisreationNo.Text = "";
                btnSave.Text = "Save";

            }
            catch
            {

            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetRefresh();
            GetLoad();
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog f = new OpenFileDialog();
                //f.Filter = "All files|*.*|JPEGs|*.jpg|*.bmp|GIFs|*.gif";
                if (f.ShowDialog() == DialogResult.OK)
                {
                    txtfilePath.Text = f.FileName;

                }
            }
            catch
            {
            }
        }
    }
}
