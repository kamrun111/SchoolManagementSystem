using System;
using System.Data;
using System.Windows.Forms;
using SchoolManagementSystem.BLL;

namespace SchoolManagementSystem.Forms.Login
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            txtUserName.Text = "";
            txtUserName.Focus();
        }
               
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                UserBLL userBLL = new UserBLL();

                if (userBLL.Login(txtUserName.Text.ToString(), txtUserPassword.Text.ToString()))
                {
                    this.DialogResult = DialogResult.OK;
                    ApplicatinLauncher._userName = txtUserName.Text;
                    DataSet dss = userBLL.UserIDGet(txtUserName.Text.ToString());
                    ApplicatinLauncher._userId = Convert.ToInt32(dss.Tables[0].Rows[0][0]);
                    ApplicatinLauncher._groupID = Convert.ToInt32(dss.Tables[0].Rows[0][1]);
                    ApplicatinLauncher._floorID = Convert.ToInt32(dss.Tables[0].Rows[0][2]);
                    ApplicatinLauncher._floor = Convert.ToString(dss.Tables[0].Rows[0][3]);
                    ApplicatinLauncher._GroupName = Convert.ToString(dss.Tables[0].Rows[0][4]);
                    ApplicatinLauncher._realname = Convert.ToString(dss.Tables[0].Rows[0][5]);

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Login failed");
                    txtUserName.Text = "";
                    txtUserPassword.Text = "";
                    txtUserName.Focus();
                }
            }
            catch
            {
            }
        }

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==13)
            {
                txtUserPassword.Focus();
            }
        }

        private void txtUserPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnLogin.Focus();
            }
        }

        private void btnLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            btnLogin_Click(null, null);
        }

        private void btnCancel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Close();
            }
        }
    }
}