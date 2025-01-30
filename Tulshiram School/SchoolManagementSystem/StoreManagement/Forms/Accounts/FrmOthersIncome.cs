using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SchoolManagementSystem.BLL;
using SchoolManagementSystem.BusinessObjects;
using System.Data.Common;
using SchoolManagementSystem.Reports;
using CrystalDecisions.CrystalReports.Engine;

namespace SchoolManagementSystem.Forms.Accounts
{
    public partial class FrmOthersIncome : BaseForm.FrmBase
    {
        public FrmOthersIncome()
        {
            InitializeComponent();
        }
        CommonClass cs = new CommonClass();
        void GetLoad()
        {
            try
            {
                DataSet ds = cs.GetDataSet("IncomeHeadLoad");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    cs.PopulateComboBox(cmbOthersIncome, ds, 0, "income", "income_head_id");
                }
                cs.FillUpListview(lvwOthersIncome, ds, 1);
                btnSave.Enabled = true;
                txtamount.Text = "";
                txtremarks.Text = "";
            }
            catch
            {
            }
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbOthersIncome.SelectedIndex == -1)
                    return;
                if (txtamount.Text == "")
                {
                    txtamount.Focus();
                    return;
                }
                OtherIncomeBO otherIncomeBO = new OtherIncomeBO();
                OtherIncomeBLL otherIncomeBLL = new OtherIncomeBLL();
                otherIncomeBO.income_head_id = Convert.ToInt32(cmbOthersIncome.SelectedValue);
                otherIncomeBO.amount = Convert.ToDecimal(txtamount.Text);
                otherIncomeBO.date = Convert.ToDateTime(dtpdate.Value);
                otherIncomeBO.remarks = txtremarks.Text;
                otherIncomeBO.record_created_by = ApplicatinLauncher._userId;
                int result = otherIncomeBLL.OtherIncomeAdd(otherIncomeBO);
                if (result > 0)
                {
                    MessageBox.Show("Data Saved Successfully");
                    btnSave.Enabled = false;
                }

            }
            catch
            {
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmOthersIncome_Load(object sender, EventArgs e)
        {
            try
            {
                GetLoad();
            }
            catch
            {
            }
        }

        private void txtamount_KeyPress(object sender, KeyPressEventArgs e)
        {
            cs.NumCheck(e);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetLoad();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            FrmOthersIncomePrint frmOthersIncomePrint = new FrmOthersIncomePrint();
            frmOthersIncomePrint.ShowDialog();
        }

 
    }
}
