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

namespace SchoolManagementSystem.Forms.Accounts
{
    public partial class FrmCollectionExpenditure : BaseForm.FrmBase
    {
        public FrmCollectionExpenditure()
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
                CommonClass cs = new CommonClass();
                DataSet ds = cs.GetDataSetWithTwoDateParameter("@From", "@To", From, To, "CollectionExpenditure");
                decimal TotalCollection=0,TotalExpenditure = 0;

                if (ds.Tables[0].Rows.Count > 0)
                {
                    grdFeeCollection.Rows.Clear();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        grdFeeCollection.Rows.Add();
                        grdFeeCollection.Rows[i].Cells[0].Value = ds.Tables[0].Rows[i][0];
                        grdFeeCollection.Rows[i].Cells[1].Value = ds.Tables[0].Rows[i][1];
                        grdFeeCollection.Rows[i].Cells[2].Value = ds.Tables[0].Rows[i][2];
                        TotalCollection = TotalCollection + Convert.ToDecimal(ds.Tables[0].Rows[i][2]);

                    }
                    txtTotalCollection.Text = TotalCollection.ToString("0#.#0");
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    grdExpenditureCollection.Rows.Clear();
                    for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                    {
                        grdExpenditureCollection.Rows.Add();
                        grdExpenditureCollection.Rows[i].Cells[0].Value = ds.Tables[1].Rows[i][0];
                        grdExpenditureCollection.Rows[i].Cells[1].Value = ds.Tables[1].Rows[i][1];
                        grdExpenditureCollection.Rows[i].Cells[2].Value = ds.Tables[1].Rows[i][2];
                        TotalExpenditure = TotalExpenditure + Convert.ToDecimal(ds.Tables[1].Rows[i][2]);

                    }
                    txtTotalExpenditure.Text = TotalExpenditure.ToString("0#.#0");
                }

            }
            catch
            {
            }
        }
        void Refresh()
        {
            try
            {
                DateTime From = DateTime.Now;
                DateTime To = DateTime.Now;
                txtTotalCollection.Text = "";
                txtTotalExpenditure.Text = "";
                grdFeeCollection.Rows.Clear();
                grdExpenditureCollection.Rows.Clear();
            }
            catch
            {
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}
