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
    public partial class FrmExpenditureEdit : BaseForm.FrmBase
    {
        public FrmExpenditureEdit()
        {
            InitializeComponent();
        }
        CommonClass cs = new CommonClass();
        private void txtvoucharNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    DataSet ds = cs.GetDataSetWithStringParameter("@expenditure_no", txtvoucharNo.Text, "ExpenditureInvoiceLoad");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        grdexpenditure.Rows.Clear();
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            grdexpenditure.Rows.Add();
                            grdexpenditure.Rows[i].Cells[0].Value = ds.Tables[0].Rows[i][1];
                            grdexpenditure.Rows[i].Cells[1].Value = ds.Tables[0].Rows[i][2];
                            grdexpenditure.Rows[i].Cells[2].Value = ds.Tables[0].Rows[i][3];
                            grdexpenditure.Rows[i].Cells[3].Value = ds.Tables[0].Rows[i][4];
                            grdexpenditure.Rows[i].Cells[4].Value = ds.Tables[0].Rows[i][5];
                            grdexpenditure.Rows[i].Cells[5].Value = ds.Tables[0].Rows[i][6];
                            grdexpenditure.Rows[i].Cells[6].Value = ds.Tables[0].Rows[i][7];



                        }
                        adjustGrandTotal();
                    }
                    else
                        MessageBox.Show("No Data Found");
                    
                }
            }
            catch
            {
            }
        }
        void adjustGrandTotal()
        {
            try
            {
                double grandTotal = 0;
                for (int i = 0; i < this.grdexpenditure.RowCount; i++)
                {
                    double subTotal = 0.00;
                    double.TryParse(this.grdexpenditure.Rows[i].Cells["amount"].Value.ToString(), out subTotal);
                    grandTotal += subTotal;
                }
                this.txtTotal.Text = grandTotal.ToString("00");
            }
            catch
            {
                
            }
        }

        private void grdexpenditure_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (grdexpenditure.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("Do you want to Edit?", "SMS", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return;
                    }
                    txtAmount.Text= (Convert.ToDecimal(grdexpenditure.SelectedRows[0].Cells["amount"].Value).ToString());
                }
                else
                    MessageBox.Show("Select item from list");
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
                {
                    grdexpenditure.SelectedRows[0].Cells["amount"].Value = txtAmount.Text;
                    adjustGrandTotal();
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
                if (grdexpenditure.Rows.Count == 0)
                    return;

                ExpenditureOrder expenditureOrder = new ExpenditureOrder();
                ExpenditureOrderBLL expenditureOrderBLL = new ExpenditureOrderBLL();
                List<Expenditure> listExpenditure = new List<Expenditure>();

                expenditureOrder.total_amount = Convert.ToDecimal(txtTotal.Text);
                expenditureOrder.record_modified_by = ApplicatinLauncher._userId;
                expenditureOrder.expenditure_order_id =Convert.ToInt32(grdexpenditure.SelectedRows[0].Cells["expenditure_order_id"].Value);
                for (int i = 0; i < grdexpenditure.Rows.Count; i++)
                {
                    Expenditure expenditure = new Expenditure();
                    expenditure.amount = Convert.ToDecimal(grdexpenditure.Rows[i].Cells[3].Value);
                    expenditure.remarks = grdexpenditure.Rows[i].Cells[4].Value.ToString();
                    expenditure.record_modified_by = ApplicatinLauncher._userId;
                    expenditure.expenditure_id = Convert.ToInt32(grdexpenditure.Rows[i].Cells["expenditure_id"].Value);

                    listExpenditure.Add(expenditure);
                }
                int Result = expenditureOrderBLL.expenditureOrderUpdate(expenditureOrder, listExpenditure);

                if (Result > 0)
                {
                    MessageBox.Show("Data Saved Successfully");
                    btnSave.Enabled = false;
                }
            }
            catch
            {
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            grdexpenditure.Rows.Clear();
            txtAmount.Text="";
            txtTotal.Text = "";
            txtvoucharNo.Text = "";
        }
    }
}
