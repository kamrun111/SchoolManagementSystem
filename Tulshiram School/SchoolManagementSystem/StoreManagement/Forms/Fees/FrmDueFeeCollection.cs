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
using SchoolManagementSystem.Reports;

namespace SchoolManagementSystem.Forms.Fees
{
    public partial class FrmDueFeeCollection : BaseForm.FrmBase
    {
        public FrmDueFeeCollection()
        {
            InitializeComponent();
        }
        CommonClass cs = new CommonClass();
        int studentID, sessionID = 0;
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        public void Getload()
        {
            lvwDueList.Items.Clear();
            txtTotalAmount.Text = "00.00";
            txtFineAmount.Text = "00.00";
            txtNetPayable.Text = "00.00";
            txtAdvance.Text = "00.00";
            txtDue.Text = "00.00";
            txtRegSearch.Text = "";
            btnSave.Enabled = true;
            DataSet ds = cs.GetDataSetWithTwoIntParameter("@student_id", "@session_id", 0, 0, "DueFeeLoad");
            if (ds.Tables[0].Rows.Count > 0)
                cs.FillUpListview(lvwDueList, ds, 0);
        }
        public void GetProduct(int student_id, int session_id)
        {
            try
            {
                lvwDueList.Items.Clear();
                studentID = student_id; sessionID = session_id;
                DataSet ds = cs.GetDataSetWithTwoIntParameter("@student_id","@session_id",studentID, sessionID,"DueFeeLoad");
                if (ds.Tables[1].Rows.Count > 1)
                    cs.FillUpListview(lvwDueList, ds, 1);
            }
            catch
            {
            }
        }

        private void FrmDueFeeCollection_Load(object sender, EventArgs e)
        {
            Getload();
            GetProduct(studentID, sessionID);
        }

        private void btnfresh_Click(object sender, EventArgs e)
        {
            Getload();
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                cs.NumCheck(e);
                DataSet ds = cs.GetDataSetWithParameter("@reg_no", Convert.ToInt32(txtRegSearch.Text), "DueFeeStudentSearch");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    cs.FillUpListview(lvwDueList, ds, 0);
                }
            }
            catch
            {
            }
        }

        private void lvwDueList_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvwDueList.SelectedItems.Count > 0)
                {
                    DataSet ds = cs.GetDataSetWithParameter("@fee_collection_id", Convert.ToInt32(lvwDueList.SelectedItems[0].Text), "FeeDetailsLoad");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        grdFeeCollection.Rows.Clear();
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            grdFeeCollection.Rows.Add();
                            grdFeeCollection.Rows[i].Cells[0].Value = ds.Tables[0].Rows[i][0];
                            grdFeeCollection.Rows[i].Cells[1].Value = ds.Tables[0].Rows[i][1];
                            grdFeeCollection.Rows[i].Cells[2].Value = ds.Tables[0].Rows[i][2];
                            grdFeeCollection.Rows[i].Cells[3].Value = ds.Tables[0].Rows[i][3];
                            grdFeeCollection.Rows[i].Cells[4].Value = ds.Tables[0].Rows[i][4];
                            grdFeeCollection.Rows[i].Cells[5].Value = ds.Tables[0].Rows[i][5];
                        }

                        txtTotalAmount.Text = ds.Tables[0].Rows[0][7].ToString();
                        txtFineAmount.Text = ds.Tables[0].Rows[0][6].ToString();
                        txtNetPayable.Text = ds.Tables[0].Rows[0][10].ToString();
                        txtAdvance.Text = ds.Tables[0].Rows[0][8].ToString();
                        txtDue.Text = ds.Tables[0].Rows[0][9].ToString();
                    }
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
                if (grdFeeCollection.Rows.Count != 0)
                {
                    FeePaymentBO feePaymentBO = new FeePaymentBO();
                    FeePaymentBLL feePaymentBLL = new FeePaymentBLL();
                    feePaymentBO.fee_collection_id = Convert.ToInt32(lvwDueList.SelectedItems[0].Text);
                    feePaymentBO.net_payable = Convert.ToDecimal(txtNetPayable.Text);
                    feePaymentBO.fee_paid_amount = Convert.ToDecimal(txtDue.Text);
                    feePaymentBO.record_created_by = ApplicatinLauncher._userId;
                    int result = feePaymentBLL.FeePaymentAdd(feePaymentBO);
                    if (result > 0)
                    {
                        MessageBox.Show("Data Saved Successfully");
                        btnSave.Enabled = false;
                        PrintInvoice(Convert.ToInt32(lvwDueList.SelectedItems[0].Text));
                        grdFeeCollection.Rows.Clear();
                    }
                }
            }
            catch
            {
            }
        }


        public void PrintInvoice(int ID)
        {
            try
            {
                CrystalDecisions.Shared.TableLogOnInfo tliCurrent;
                FeeCollectionInvoice11 rptCustomersOrders = new FeeCollectionInvoice11();

                foreach (CrystalDecisions.CrystalReports.Engine.Table tbCurrent in rptCustomersOrders.Database.Tables)
                {
                    tliCurrent = tbCurrent.LogOnInfo;

                    tliCurrent.ConnectionInfo.ServerName = FormHelper.DBServerName;
                    tliCurrent.ConnectionInfo.UserID = FormHelper.DBUser; ;
                    tliCurrent.ConnectionInfo.Password = FormHelper.DBUserPassword;
                    tliCurrent.ConnectionInfo.DatabaseName = FormHelper.DBName;
                    tbCurrent.ApplyLogOnInfo(tliCurrent);
                }

                rptCustomersOrders.SetParameterValue("@fee_collection_id", ID);
                rptCustomersOrders.SetParameterValue("@fee_collectionID", ID);

                FrmGenericReportViewer frmGenericReportViewer = new FrmGenericReportViewer();
                frmGenericReportViewer.crvParameter.DisplayGroupTree = false;
                frmGenericReportViewer.crvParameter.ReportSource = rptCustomersOrders;
                frmGenericReportViewer.Show();

            }
            catch
            {
            }
        }

        public void PrintDueList()
        {
            try
            {
                CrystalDecisions.Shared.TableLogOnInfo tliCurrent;
                DueCollectionListReport rptCustomersOrders = new DueCollectionListReport();

                foreach (CrystalDecisions.CrystalReports.Engine.Table tbCurrent in rptCustomersOrders.Database.Tables)
                {
                    tliCurrent = tbCurrent.LogOnInfo;

                    tliCurrent.ConnectionInfo.ServerName = FormHelper.DBServerName;
                    tliCurrent.ConnectionInfo.UserID = FormHelper.DBUser; ;
                    tliCurrent.ConnectionInfo.Password = FormHelper.DBUserPassword;
                    tliCurrent.ConnectionInfo.DatabaseName = FormHelper.DBName;
                    tbCurrent.ApplyLogOnInfo(tliCurrent);
                }

         

                FrmGenericReportViewer frmGenericReportViewer = new FrmGenericReportViewer();
                frmGenericReportViewer.crvParameter.DisplayGroupTree = false;
                frmGenericReportViewer.crvParameter.ReportSource = rptCustomersOrders;
                frmGenericReportViewer.Show();

            }
            catch
            {
            }
        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDueList();
        }




    }
}
