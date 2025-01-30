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


namespace SchoolManagementSystem.Forms.Accounts
{
    public partial class FrmDonationList : BaseForm.FrmBase
    {
        public FrmDonationList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime From = new DateTime(dtpFromDate.Value.Year, dtpFromDate.Value.Month, dtpFromDate.Value.Day, 0, 0, 0);
                DateTime To = new DateTime(dtpToDate.Value.Year, dtpToDate.Value.Month, dtpToDate.Value.Day, 23, 59, 59);

                FeeCollectionBLL feeCollectionBLL = new FeeCollectionBLL();
                DataSet ds = feeCollectionBLL.FeeCollectionDonationList(From, To);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    CommonClass cs = new CommonClass();
                    cs.FillUpListview(lvwStudentInformation, ds, 0);
                    txtCount.Text = ds.Tables[1].Rows[0][0].ToString();
                    txtTotalAmount.Text = ds.Tables[1].Rows[0][1].ToString();
                }
                else
                {
                    lvwStudentInformation.Items.Clear();
                    MessageBox.Show("No Data Found");
                    txtTotalAmount.Text = "";
                    txtCount.Text = "";
                }
            }
            catch
            {
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            lvwStudentInformation.Items.Clear();
            txtTotalAmount.Text = "";
            txtCount.Text = "";
            dtpFromDate.Value = DateTime.Now;
            dtpToDate.Value = DateTime.Now;
        }
    }
}
