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
    public partial class FrmInvoiceList : BaseForm.FrmBase
    {
        public FrmInvoiceList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime From = new DateTime(dtpFromDate.Value.Year, dtpFromDate.Value.Month, dtpFromDate.Value.Day, 0, 0, 0);
                DateTime To = new DateTime(dtpToDate.Value.Year, dtpToDate.Value.Month, dtpToDate.Value.Day, 23, 59, 59);
                FeeCollectionBLL feeCollectionBLL = new FeeCollectionBLL();

                DataSet ds = feeCollectionBLL.FeeCollectionAll(From, To);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lvwStudentInformation.Items.Clear();
                    CommonClass cs = new CommonClass();
                    cs.FillUpListview(lvwStudentInformation, ds, 0);
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



        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvwStudentInformation.SelectedItems.Count > 0)
                    PrintInvoice(Convert.ToInt32(lvwStudentInformation.SelectedItems[0].Text));

            }
            catch
            {
            }
        }


    }
}
