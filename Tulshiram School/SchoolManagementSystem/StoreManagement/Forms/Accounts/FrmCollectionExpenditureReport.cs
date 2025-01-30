using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SchoolManagementSystem.BLL;
using CrystalDecisions.CrystalReports.Engine;
using SchoolManagementSystem.Reports;

namespace SchoolManagementSystem.Forms.Accounts
{
    public partial class FrmCollectionExpenditureReport : BaseForm.FrmBase
    {
        public FrmCollectionExpenditureReport()
        {
            InitializeComponent();
        }
        CommonClass cs = new CommonClass();

        private void FrmCollectionExpenditureReport_Load(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = cs.GetDataSet("IncomeHead");
                if (ds.Tables[0].Rows.Count>0)
                {
                    cs.PopulateComboBox(cmbCollection, ds, 0, "fee_name", "fee_name_id");
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    cs.PopulateComboBox(cmbExpenditure, ds, 1, "expencess", "expencess_id");
                }
            }
            catch
            {
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void CollectionPrint(int id, DateTime From, DateTime To)
        {
            try
            {
               

                CrystalDecisions.Shared.TableLogOnInfo tliCurrent;
                ReportDocument rptCustomersOrders = new CollectionHeadWiseIncomeReport();

                foreach (CrystalDecisions.CrystalReports.Engine.Table tbCurrent in rptCustomersOrders.Database.Tables)
                {
                    tliCurrent = tbCurrent.LogOnInfo;
                    tliCurrent.ConnectionInfo.ServerName = FormHelper.DBServerName;
                    tliCurrent.ConnectionInfo.UserID = FormHelper.DBUser;
                    tliCurrent.ConnectionInfo.Password = FormHelper.DBUserPassword;
                    tliCurrent.ConnectionInfo.DatabaseName = FormHelper.DBName;
                    tbCurrent.ApplyLogOnInfo(tliCurrent);
                }
                rptCustomersOrders.SetParameterValue("@From", From);
                rptCustomersOrders.SetParameterValue("@To", To);
                rptCustomersOrders.SetParameterValue("@fee_name_id", id);



                FrmGenericReportViewer frmGenericReportViewer = new FrmGenericReportViewer();
                frmGenericReportViewer.crvParameter.DisplayGroupTree = false;
                frmGenericReportViewer.crvParameter.ReportSource = rptCustomersOrders;
                frmGenericReportViewer.Show();
            }
            catch
            {
            }
        }

        void ExpenditurePrint(int id, DateTime From, DateTime To)
        {
            try
            {


                CrystalDecisions.Shared.TableLogOnInfo tliCurrent;
                ReportDocument rptCustomersOrders = new ExpenditureHeadWiseIncomeReport();

                foreach (CrystalDecisions.CrystalReports.Engine.Table tbCurrent in rptCustomersOrders.Database.Tables)
                {
                    tliCurrent = tbCurrent.LogOnInfo;
                    tliCurrent.ConnectionInfo.ServerName = FormHelper.DBServerName;
                    tliCurrent.ConnectionInfo.UserID = FormHelper.DBUser;
                    tliCurrent.ConnectionInfo.Password = FormHelper.DBUserPassword;
                    tliCurrent.ConnectionInfo.DatabaseName = FormHelper.DBName;
                    tbCurrent.ApplyLogOnInfo(tliCurrent);
                }
                rptCustomersOrders.SetParameterValue("@From", From);
                rptCustomersOrders.SetParameterValue("@To", To);
                rptCustomersOrders.SetParameterValue("@expencess_id", id);



                FrmGenericReportViewer frmGenericReportViewer = new FrmGenericReportViewer();
                frmGenericReportViewer.crvParameter.DisplayGroupTree = false;
                frmGenericReportViewer.crvParameter.ReportSource = rptCustomersOrders;
                frmGenericReportViewer.Show();
            }
            catch
            {
            }
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            try
            {
            DateTime From = new DateTime(dtpFromDate.Value.Year, dtpFromDate.Value.Month, dtpFromDate.Value.Day, 0, 0, 0);
            DateTime To = new DateTime(dtpToDate.Value.Year, dtpToDate.Value.Month, dtpToDate.Value.Day, 23, 59, 59);
            if(rdoCollection.Checked==true)
                CollectionPrint(Convert.ToInt32(cmbCollection.SelectedValue),From,To);
            if(rdoExpenditure.Checked==true)
                ExpenditurePrint(Convert.ToInt32(cmbExpenditure.SelectedValue),From,To);

            }
            
            catch
            {
            }
        }
    }
}
