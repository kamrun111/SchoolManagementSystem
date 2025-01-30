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
using System.IO;
using System.Net;



namespace SchoolManagementSystem.Forms.Students
{
    public partial class FrmStudentsAdmission : BaseForm.FrmBase
    {
        public FrmStudentsAdmission()
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
                    cs.PopulateComboBox(cmbStudentType, ds, 0, "student_status", "student_status_id");
                    cmbStudentType.SelectedValue = 1;
                    cs.PopulateComboBox(cmbSession, ds, 1, "session", "session_id");
                    cs.PopulateComboBox(cmbShift, ds, 2, "shift", "shift_id");
                    cs.PopulateComboBox(cmbClass, ds, 3, "class_name", "class_id");
                    cs.PopulateComboBox(cmbSection, ds, 4, "section_name", "section_id");
                    cs.PopulateComboBox(cmbPaymentType, ds, 5, "payment_catagory", "payment_catagory_id");
                }
                if (ds.Tables[6].Rows.Count > 0)
                {
                    cs.FillUpListview(lvwStudentInformation, ds, 6);
                }
                

            }
            catch
            {
            }
      
        }
        private void FrmStudentsAdmission_Load(object sender, EventArgs e)
        {
            try
            {
                GetLoad();
            }

            catch
            {

            }


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int StudentID = 0;
                if (txtStudent.Text == "")
                {
                    txtStudent.Focus();
                    return;
                }
                if (cmbClass.SelectedIndex == -1)
                {
                    cmbClass.Focus();
                    return;
                }
                if (cmbSection.SelectedIndex == -1)
                {
                    cmbSection.Focus();
                    return;
                }
                StudentBO studentBO = new StudentBO();
                StudentBLL studentBLL = new StudentBLL();
                studentBO.student_name = txtStudent.Text;
                studentBO.f_name = txtFatherName.Text;
                studentBO.m_name = txtMotherName.Text;
                studentBO.present_address = txtPtesentAddress.Text;
                studentBO.permanent_address = txtParmanentAddress.Text;
                if (rdomale.Checked == true)
                    studentBO.gender_id = 1;
                else
                    studentBO.gender_id = 2;
                studentBO.dob = Convert.ToDateTime(dtpDOB.Value);
                studentBO.blood_group = cmbBloodGroup.Text;     
                studentBO.session_id = Convert.ToInt32(cmbSession.SelectedValue);

                studentBO.shift_id = Convert.ToInt32(cmbShift.SelectedValue);
                studentBO.class_id = Convert.ToInt32(cmbClass.SelectedValue);
                studentBO.section_id = Convert.ToInt32(cmbSection.SelectedValue);
                studentBO.student_status = Convert.ToInt32(cmbStudentType.SelectedValue);
                studentBO.payment_catagory_id = Convert.ToInt32(cmbPaymentType.SelectedValue);
                studentBO.roll_no =Convert.ToInt32(txtRoll_No.Text);
                studentBO.contact = txtContact.Text;
                studentBO.image = txtfilePath.Text;
                studentBO.record_created_by = ApplicatinLauncher._userId;
                studentBO.record_modified_by = ApplicatinLauncher._userId;
                int result = 0;
                if (btnSave.Text == "Save")
                {
                    result = studentBLL.StudentAdd(studentBO);
                    StudentID = result;
                }
                else
                {
                    studentBO.student_id = Convert.ToInt32(lvwStudentInformation.SelectedItems[0].Text);
                    StudentID = Convert.ToInt32(lvwStudentInformation.SelectedItems[0].Text);
                    studentBO.image = lvwStudentInformation.SelectedItems[0].SubItems[1].Text + ".jpg";
                    result = studentBLL.StudentUpdate(studentBO);
                }

                    if (result > 0)
                    {
                        MessageBox.Show("Data Saved Sussessfully");
                        btnSave.Enabled = false;
                        //GetRefresh();
                        //GetLoad();

                    }
                    
                    if (pictureBox1.Image == null)
                    {
                        DataSet ds = cs.GetDataSetWithParameter("student_id", StudentID, "LoadStudentPicture");

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            string fname = ds.Tables[0].Rows[0][0].ToString() + ".jpg";
                            string location = txtfilePath.Text;

                            studentBO.image = fname;

                            result = studentBLL.StudentImageUpdate(studentBO);

                            if (txtfilePath.Text != "")
                            {
                                UploadImage(location, fname);
                                MessageBox.Show("Image Saved Successfully.");
                            }

                            
                        }
                    }
                    else if (pictureBox1.Image != null)
                    {
                        string location = txtfilePath.Text;
                        string fname1 = lvwStudentInformation.SelectedItems[0].SubItems[1].Text + ".jpg";
                        

                        if (txtfilePath.Text != fname1)
                            {
                                DeleteImage(location, fname1);
                                MessageBox.Show("Image Updated Successfully.");
                            }


                    }
                    studentBO = null;
                    //MessageBox.Show("Image Saved Successfully.");
                    GetRefresh();
                    GetLoad();
            }
            catch
            {
            }

        }

        public void UploadImage(string location, string filename)
        {
            try
            {
                string ftpfullpath = "ftp://win5078.site4now.net/Image/Student/";

                WebRequest ftp = WebRequest.Create(ftpfullpath + filename);
                ftp.Credentials = new NetworkCredential("image-001", "sumon123");

                ftp.Method = WebRequestMethods.Ftp.UploadFile;
                FileStream fs = File.OpenRead(location);
                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);
                fs.Close();
                Stream ftpstream = ftp.GetRequestStream();
                ftpstream.Write(buffer, 0, buffer.Length);
                ftpstream.Close();
            }
            catch
            {
            }
        }

        public void DeleteImage(string location, string filename)
        {
            try
            {

                if (pictureBox1.Image != null || txtfilePath.Text != "")
                {

                    string ftpfullpath = "ftp://win5078.site4now.net/Image/Student/";

                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpfullpath + fileName);
                    request.Method = WebRequestMethods.Ftp.DeleteFile;
                    request.Credentials = new NetworkCredential("image-001", "sumon123");

                    using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                    {
                        return response.StatusDescription;
                    }

                    WebRequest ftp = WebRequest.Create(ftpfullpath + filename);
                    ftp.Credentials = new NetworkCredential("image-001", "sumon123");
 
                    ftp.Method = WebRequestMethods.Ftp.UploadFile;
                    FileStream fs = File.OpenRead(location);
                    byte[] buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, buffer.Length);
                    fs.Close();
                    Stream ftpstream = ftp.GetRequestStream();
                    ftpstream.Write(buffer, 0, buffer.Length);
                    ftpstream.Close();


                    MessageBox.Show("Employee's New Picture Uploaded Succesfully");

                }
            }
            catch
            {
            }
        }

        void Update()
        {
            try
            {
            }
            catch
            {
            }
        }
        void GetRefresh()
        {
            try
            {
                txtRegisreationNo.Text = "";
                txtStudent.Text="";
                txtFatherName.Text="";
                txtMotherName.Text="";
                txtPtesentAddress.Text="";
                txtParmanentAddress.Text="";
                dtpDOB.Value=DateTime.Now;
                txtRoll_No.Text="";
                txtContact.Text="";
                txtfilePath.Text="";
                btnSave.Enabled = true;
                btnSave.Text = "Save";
                pictureBox1.Image = null;

            }
            catch
            {

            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                GetRefresh();
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

        private void txtnameSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                StudentBLL studentBLL=new StudentBLL();
                DataSet ds = studentBLL.StudentSearchName(txtnameSearch.Text,0);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    cs.FillUpListview(lvwStudentInformation, ds, 0);
                }
            }
            catch
            {
            }
        }

        private void txtRegSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                StudentBLL studentBLL = new StudentBLL();
                DataSet ds = studentBLL.StudentSearchName(txtRegSearch.Text, 1);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    cs.FillUpListview(lvwStudentInformation, ds, 0);
                }
            }
            catch
            {
            }

        }

        private void lvwStudentInformation_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvwStudentInformation.SelectedItems.Count > 0)
                {
                    DataSet ds = cs.GetDataSetWithParameter("@student_id", Convert.ToInt32(lvwStudentInformation.SelectedItems[0].Text), "StudentLoadParticular");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        pictureBox1.Image = null;
                        txtRegisreationNo.Text = ds.Tables[0].Rows[0][1].ToString();
                        txtStudent.Text = ds.Tables[0].Rows[0][2].ToString();
                        txtFatherName.Text = ds.Tables[0].Rows[0][3].ToString();
                        txtMotherName.Text = ds.Tables[0].Rows[0][4].ToString();
                        txtPtesentAddress.Text = ds.Tables[0].Rows[0][5].ToString();
                        txtParmanentAddress.Text = ds.Tables[0].Rows[0][6].ToString();
                        if (ds.Tables[0].Rows[0][7].ToString() == "1")
                            rdomale.Checked = true;
                        else
                            rdoFemale.Checked = true; ;
                        dtpDOB.Value = Convert.ToDateTime(ds.Tables[0].Rows[0][8]);
                        txtContact.Text = ds.Tables[0].Rows[0][9].ToString();
                        cmbBloodGroup.Text = ds.Tables[0].Rows[0][10].ToString();
                        cmbSession.SelectedValue = Convert.ToInt32(ds.Tables[0].Rows[0][11]);
                        cmbShift.SelectedValue = Convert.ToInt32(ds.Tables[0].Rows[0][12]);
                        cmbClass.SelectedValue = Convert.ToInt32(ds.Tables[0].Rows[0][13]);
                        cmbSection.SelectedValue = Convert.ToInt32(ds.Tables[0].Rows[0][14]);
                        txtRoll_No.Text = ds.Tables[0].Rows[0][15].ToString();
                        cmbPaymentType.SelectedValue = Convert.ToInt32(ds.Tables[0].Rows[0][16]);
                        if (ApplicatinLauncher._GroupName == "Administrator")
                        {
                            cmbStudentType.Enabled = true;
                        }
                        cmbStudentType.SelectedValue = Convert.ToInt32(ds.Tables[0].Rows[0][17]);
                        txtfilePath.Text = ds.Tables[0].Rows[0][18].ToString();
                        cmbPaymentType.Text = ds.Tables[0].Rows[0][16].ToString();     
                        btnSave.Text = "Update";
                        pictureBox1.ImageLocation = "http://ssumon-001-site1.itempurl.com/Image/Student/" + txtfilePath.Text;
                    }

                }
            }
            catch
            {
            }
        }



        
    }
}
