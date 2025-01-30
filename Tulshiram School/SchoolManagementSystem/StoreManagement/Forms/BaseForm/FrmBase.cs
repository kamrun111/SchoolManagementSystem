using System;
using System.Data;
using System.Windows.Forms;
using SchoolManagementSystem.BLL;
using SchoolManagementSystem.BusinessObjects;
using SchoolManagementSystem.MainForm;

namespace SchoolManagementSystem.Forms.BaseForm
{
    public partial class FrmBase : Form
    {
        public int UserID;
        public FrmBase()
        {
            InitializeComponent();
        }
        
        
        
        public new void Show()
        {   
  
            try
            {
                PermittedForm permittedForm = new PermittedForm();
                PermittedFormBLL permittedFormBLL = new PermittedFormBLL();
                string form = base.Name;
                string user_name = FrmMain.UserName;
                permittedFormBLL.GetFormPermission(form, user_name);
               
                DataSet ds = permittedFormBLL.GetFormPermission(form, user_name);
                                   
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                { 
                    UserID=Convert.ToInt32(ds.Tables[0].Rows[0][4]);
                    sbyte view = Convert.ToSByte(ds.Tables[0].Rows[0][3].ToString());
                    if (view == 1)
                    {
                        base.Show();
                        base.Text =base.Text+ " --- School Management System ";
                        ApplicatinLauncher._Insert = Convert.ToSByte(ds.Tables[0].Rows[0][0].ToString());
                        ApplicatinLauncher._edit = Convert.ToSByte(ds.Tables[0].Rows[0][1].ToString());
                        ApplicatinLauncher._Delete = Convert.ToSByte(ds.Tables[0].Rows[0][2].ToString());
                        ApplicatinLauncher.session_id = Convert.ToInt32(ds.Tables[2].Rows[0][0].ToString());
                    }
                }
                else
                    MessageBox.Show("You have no permission");
            }

            catch
            {
               
            }
        }


    }
}