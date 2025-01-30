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
    public partial class FrmDonationCollection : BaseForm.FrmBase
    {
        public FrmDonationCollection()
        {
            InitializeComponent();
        }

        CommonClass cs = new CommonClass();
        private void FrmDonationCollection_Load(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = cs.GetDataSet("FeeCollectionDonationLoad");
                cs.FillUpListview(lvwStudentInformation, ds, 0);
                if (ds.Tables[1].Rows.Count > 0)
                {
                    txtCount.Text = ds.Tables[1].Rows[0][0].ToString();
                    txtTotalAmount.Text = ds.Tables[1].Rows[0][1].ToString();
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
                List<FeeCollectionBO> listFeeCollectionBO = new List<FeeCollectionBO>();
                FeeCollectionBLL feeCollectionBLL=new FeeCollectionBLL();

                 foreach (ListViewItem itemRow in this.lvwStudentInformation.Items)
                for (int i = 0; i < lvwStudentInformation.Items.Count; i++)
                {
                    FeeCollectionBO feeCollectionBO = new FeeCollectionBO();
                    feeCollectionBO.donation_received_by = ApplicatinLauncher._userId;
                    feeCollectionBO.payment_status = 1;
                    feeCollectionBO.fee_collection_id =Convert.ToInt32(lvwStudentInformation.Items[i].Text);
                    listFeeCollectionBO.Add(feeCollectionBO);
                }
                int result = feeCollectionBLL.FeeCollectionDonation(listFeeCollectionBO);
                if (result > 0)
                    MessageBox.Show("Data Saved Successfully");
                btnSave.Enabled = false;
            }
            catch
            {
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            lvwStudentInformation.Items.Clear();
            txtCount.Text = "";
            txtTotalAmount.Text = "";
        }
    }
}
