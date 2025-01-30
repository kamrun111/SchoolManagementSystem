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
    public partial class FrmExpenceHeadEntry : BaseForm.FrmBase
    {
        public FrmExpenceHeadEntry()
        {
            InitializeComponent();
        }

        CommonClass cs = new CommonClass();
        void GetLoad()
        {
            try
            {
                DataSet ds = cs.GetDataSet("ExpencessLoad");

                cs.FillUpListview(lvwExpense, ds, 0);
                btnSave.Enabled = true;
                txtExpenceHead.Text = "";
                
            }
            catch
            {
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtExpenceHead.Text == "")
                {
                    txtExpenceHead.Focus();
                    return;
                }

                ExpenceBO expenceBO = new ExpenceBO();
                ExpenceBLL expenceBLL = new ExpenceBLL();
                expenceBO.expencess = txtExpenceHead.Text;
                int result = 0; 

                if (btnSave.Text == "Save")
                    result = expenceBLL.ExpencessAdd(expenceBO);
                else
                {
                    expenceBO.expencess_id = Convert.ToInt32(lvwExpense.SelectedItems[0].Text);
                    result = expenceBLL.ExpencessUpdate(expenceBO);
                }


                if (result > 0)
                {
                    MessageBox.Show("Data Saved Sussessfully");
                    btnSave.Enabled = false;
                    GetRefresh();
                    GetLoad();

                }
                expenceBO = null;


            }
            catch
            {
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetRefresh();

        }

        void GetRefresh()
        {
            try
            {
                txtExpenceHead.Text = "";
                btnSave.Enabled = true;
                btnSave.Text = "Save";
            }
            catch
            {
            }

        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmExpenceHeadEntry_Load(object sender, EventArgs e)
        {
            try
            {
                GetLoad();
            }
            catch
            {
            }
        }

        private void lvwExpense_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    if (lvwExpense.SelectedItems.Count > 0)
                    {
                        DataSet ds = cs.GetDataSetWithParameter("@expencess_id", Convert.ToInt32(lvwExpense.SelectedItems[0].Text), "ExpencessEdit");
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            txtExpenceHead.Text = ds.Tables[0].Rows[0][1].ToString();
                            btnSave.Text = "Update";
                        }

                    }
                }
                catch
                {
                }
            }
        }
    }
}
