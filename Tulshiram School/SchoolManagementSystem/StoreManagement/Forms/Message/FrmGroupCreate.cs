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

namespace SchoolManagementSystem.Forms.Message
{
    public partial class FrmGroupCreate : BaseForm.FrmBase
    {
        public FrmGroupCreate()
        {
            InitializeComponent();
        }
        CommonClass cs = new CommonClass();

        void GetLoad()
        {
            try
            {
                cmbClass.SelectedIndexChanged -= new EventHandler(cmbClass_SelectedIndexChanged);
                StudentBLL studentBLL = new StudentBLL();
                DataSet ds = studentBLL.StudentComboLoad();
                if (ds.Tables[0].Rows.Count > 0)
                {

                    cs.PopulateComboBox(cmbShift, ds, 2, "shift", "shift_id");
                    cs.PopulateComboBox(cmbClass, ds, 3, "class_name", "class_id");
                    cmbMemberType.Text = "<Select>";
                }
                cmbClass.SelectedIndexChanged += new EventHandler(cmbClass_SelectedIndexChanged);
                label2.Text = "";
                groupBox3.Enabled = false;
                btnSave.Enabled = true;
                grdGroup.Rows.Clear();
                DataSet da = cs.GetDataSet("MeaageGroupLoad");
                if (da.Tables[0].Rows.Count > 0)
                    cs.FillUpListview(lvwGroup, da, 0);


            }
            catch
            {
            }
        }

        private void FrmGroupCreate_Load(object sender, EventArgs e)
        {
            GetLoad();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                cmbSection.SelectedIndexChanged -= new EventHandler(cmbSection_SelectedIndexChanged);
                if (cmbClass.SelectedIndex > -1)
                {
                    cmbSection.DataSource = null;
                    StudentBLL studentBLL = new StudentBLL();
                    DataSet ds = studentBLL.StudentSectionLoad(Convert.ToInt32(cmbClass.SelectedValue));
                    if (ds.Tables[0].Rows.Count > 0)
                        cs.PopulateComboBox(cmbSection, ds, 0, "section_name", "section_id");
                }
                cmbSection.SelectedIndexChanged += new EventHandler(cmbSection_SelectedIndexChanged);

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
                        grdGroup.Rows.Clear();
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            grdGroup.Rows.Add();
                            grdGroup.Rows[i].Cells[0].Value = ds.Tables[0].Rows[i][0];
                            grdGroup.Rows[i].Cells[1].Value = ds.Tables[0].Rows[i][1];
                            grdGroup.Rows[i].Cells[2].Value = ds.Tables[0].Rows[i][2];
                            grdGroup.Rows[i].Cells[3].Value = ds.Tables[0].Rows[i][4];
                            grdGroup.Rows[i].Cells[4].Value = ds.Tables[0].Rows[i][6];
                            grdGroup.Rows[i].Cells[5].Value = 1;
                        }
                       
                    }
                    label2.Text = grdGroup.Rows.Count.ToString();
                }
            }
            catch
            {
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetLoad();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtgroup_name.Text == "")
                    return;
                MessageGroupBO messageGroupBO = new MessageGroupBO();
                MessageGroupBLL messageGroupBLL = new MessageGroupBLL();
                List<MessageGroupDetailsBO> listMessageGroupDetailsBO = new List<MessageGroupDetailsBO>();
                messageGroupBO.group_name = txtgroup_name.Text;
                messageGroupBO.member = cmbMemberType.Text;
                messageGroupBO.record_created_by = ApplicatinLauncher._userId;
                for (int i = 0; i < grdGroup.Rows.Count; i++)
                {
                    if (Convert.ToInt32(grdGroup.Rows[i].Cells[5].Value) == 1)
                    {
                        MessageGroupDetailsBO messageGroupDetailsBO = new MessageGroupDetailsBO();
                        messageGroupDetailsBO.member_id = Convert.ToInt32(grdGroup.Rows[i].Cells[0].Value);
                        messageGroupDetailsBO.member_reg = Convert.ToInt32(grdGroup.Rows[i].Cells[1].Value);
                        messageGroupDetailsBO.name = grdGroup.Rows[i].Cells[2].Value.ToString();
                        messageGroupDetailsBO.contact_no = grdGroup.Rows[i].Cells[4].Value.ToString();
                        messageGroupDetailsBO.record_created_by = ApplicatinLauncher._userId;
                        listMessageGroupDetailsBO.Add(messageGroupDetailsBO);
                    }

                }
                int result = messageGroupBLL.MessageGroupAdd(messageGroupBO, listMessageGroupDetailsBO);
                if (result > 0)
                {
                    MessageBox.Show("Group Saved Successfully");
                    btnSave.Enabled = false;
                }
                GetLoad();


            }
            catch
            {
            }
        }


      



        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = cs.GetDataSet("MessageGroupLoad");
                if (cmbMemberType.Text == "Student")
                {
                    groupBox3.Enabled = true;
                    grdGroup.Rows.Clear();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        grdGroup.Rows.Add();
                        grdGroup.Rows[i].Cells[0].Value = ds.Tables[0].Rows[i][0];
                        grdGroup.Rows[i].Cells[1].Value = ds.Tables[0].Rows[i][1];
                        grdGroup.Rows[i].Cells[2].Value = ds.Tables[0].Rows[i][2];
                        grdGroup.Rows[i].Cells[3].Value = ds.Tables[0].Rows[i][3];
                        grdGroup.Rows[i].Cells[4].Value = ds.Tables[0].Rows[i][4];
                        grdGroup.Rows[i].Cells[5].Value = 1;
                    }
                }
                if (cmbMemberType.Text == "Teacher")
                {
                    grdGroup.Rows.Clear();
                    for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                    {
                        grdGroup.Rows.Add();
                        grdGroup.Rows[i].Cells[0].Value = ds.Tables[1].Rows[i][0];
                        grdGroup.Rows[i].Cells[1].Value = ds.Tables[1].Rows[i][1];
                        grdGroup.Rows[i].Cells[2].Value = ds.Tables[1].Rows[i][2];
                        grdGroup.Rows[i].Cells[3].Value = ds.Tables[1].Rows[i][3];
                        grdGroup.Rows[i].Cells[4].Value = ds.Tables[1].Rows[i][4];
                        grdGroup.Rows[i].Cells[5].Value = 1;
                    }
                }
                if (cmbMemberType.Text == "Stuff")
                {
                    grdGroup.Rows.Clear();
                    for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
                    {
                        grdGroup.Rows.Add();
                        grdGroup.Rows[i].Cells[0].Value = ds.Tables[2].Rows[i][0];
                        grdGroup.Rows[i].Cells[1].Value = ds.Tables[2].Rows[i][1];
                        grdGroup.Rows[i].Cells[2].Value = ds.Tables[2].Rows[i][2];
                        grdGroup.Rows[i].Cells[3].Value = ds.Tables[2].Rows[i][3];
                        grdGroup.Rows[i].Cells[4].Value = ds.Tables[2].Rows[i][4];
                        grdGroup.Rows[i].Cells[5].Value = 1;
                    }
                }
                label2.Text = grdGroup.Rows.Count.ToString();

            }
            catch
            {
            }
        }




    }
}
