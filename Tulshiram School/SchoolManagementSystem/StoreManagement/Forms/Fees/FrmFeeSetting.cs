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

namespace SchoolManagementSystem.Forms.Fees
{
    public partial class FrmFeeSetting : BaseForm.FrmBase
    {
        public FrmFeeSetting()
        {
            InitializeComponent();
        }
        CommonClass cs = new CommonClass();

        void getLoad()
        {
            try
            {
                DataSet ds = cs.GetDataSet("FeeSettingLoad");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    cs.PopulateComboBox(cmbFeesName, ds, 0, "fee_name", "fee_name_id");
                    cs.PopulateComboBox(cmbFeesType, ds, 1, "fees_type", "fees_type_id");
                    cs.PopulateComboBox(cmbPaymentCategory, ds, 2, "payment_catagory", "payment_catagory_id");
                    cs.PopulateComboBox(cmbClass, ds, 3, "class_name", "class_id");
                    cs.FillUpListview(lvwFeesSetting, ds, 4);
                    txtAmount.Text = "";
                    btnSave.Enabled = true;
                    btnSave.Text = "Save";

                }
            }
            catch
            {
            }
        }

        private void FrmFeeSetting_Load(object sender, EventArgs e)
        {
            getLoad();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        bool CheckAll()
        {
            try
            {
                if (cmbPaymentCategory.SelectedIndex==-1)
                {
                    cmbPaymentCategory.Focus();
                    return false;
                }
                if (cmbFeesType.SelectedIndex == -1)
                {
                    cmbFeesType.Focus();
                    return false;
                }
                if (cmbFeesName.SelectedIndex == -1)
                {
                    cmbFeesName.Focus();
                    return false;
                }
                if (cmbClass.SelectedIndex == -1)
                {
                    cmbClass.Focus();
                    return false;
                }
                if (txtAmount.Text=="")
                {
                    txtAmount.Focus();
                    return false;
                }

        
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckAll() == true)
                {
                    SettingBO settingBO = new SettingBO();
                    SettingBLL settingBLL = new SettingBLL();
                    settingBO.payment_catagory_id = Convert.ToInt32(cmbPaymentCategory.SelectedValue);
                    settingBO.fees_type_id = Convert.ToInt32(cmbFeesType.SelectedValue);
                    settingBO.fee_name_id = Convert.ToInt32(cmbFeesName.SelectedValue);
                    settingBO.class_id = Convert.ToInt32(cmbClass.SelectedValue);
                    settingBO.amount = Convert.ToDecimal(txtAmount.Text);
                    settingBO.record_created_by = ApplicatinLauncher._userId;
                    int result = 0;
                    if (btnSave.Text == "Save")
                        result = settingBLL.SettingADD(settingBO);
                    else
                    {
                        settingBO.setting_id = Convert.ToInt32(lvwFeesSetting.SelectedItems[0].Text);
                        settingBO.record_modified_by = ApplicatinLauncher._userId;
                        result = settingBLL.SettingUpdate(settingBO);
                    }
                    if (result > 0)
                    {
                        MessageBox.Show("Data Saved Successfully");
                        btnSave.Enabled = false;
                        getLoad();
                    }
                }
            }
            catch
            {
            }
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                cs.NumCheck(e);
                if (e.KeyChar == 13)
                    btnSave.Focus();
            }
            catch
            {
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            getLoad();
        }

        private void lvwFeesSetting_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvwFeesSetting.SelectedItems.Count > 0)
                {
                    cmbFeesName.SelectedValue = Convert.ToInt32(lvwFeesSetting.SelectedItems[0].SubItems[6].Text);
                    cmbFeesType.SelectedValue = Convert.ToInt32(lvwFeesSetting.SelectedItems[0].SubItems[7].Text);
                    cmbPaymentCategory.SelectedValue = Convert.ToInt32(lvwFeesSetting.SelectedItems[0].SubItems[8].Text);
                    cmbClass.SelectedValue = Convert.ToInt32(lvwFeesSetting.SelectedItems[0].SubItems[9].Text);
                    txtAmount.Text = lvwFeesSetting.SelectedItems[0].SubItems[5].Text;
                    btnSave.Text = "Update";
                }
            }
            catch
            {
            }
        }
    }
}
