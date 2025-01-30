﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SchoolManagementSystem.BLL;
using SchoolManagementSystem.BusinessObjects;
using CrystalDecisions.CrystalReports.Engine;
using SchoolManagementSystem.Reports;



namespace SchoolManagementSystem.Forms.Accounts
{
    public partial class FrmDailyCollection : BaseForm.FrmBase
    {
        public FrmDailyCollection()
        {
            InitializeComponent();
        }

        //private void btnPrint_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        DateTime From = new DateTime(dtpFromDate.Value.Year, dtpFromDate.Value.Month, dtpFromDate.Value.Day, 0, 0, 0);
        //        DateTime To = new DateTime(dtpToDate.Value.Year, dtpToDate.Value.Month, dtpToDate.Value.Day, 23, 59, 59);
        //        ExpenditureOrderBLL expenditureOrderBLL = new ExpenditureOrderBLL();
        //        DataSet ds = expenditureOrderBLL.CollectionReport(From, To);
        //        decimal Advanced = 0;
        //        decimal Pathology = 0;
        //        decimal XRay = 0;
        //        decimal USG = 0;
        //        decimal ECG = 0;
        //        decimal Investigation_Payment = 0;
        //        decimal OutdoorCollection = 0;
        //        decimal Collection = 0;//@from

        //        decimal Vaccine = 0;
        //        decimal OutDoor = 0;
        //        decimal BloodBank = 0;
        //        decimal Ambulance = 0;
        //        decimal Biopsy = 0;
        //        decimal OutDoorOT = 0;
        //        decimal Others = 0;
        //        decimal OutDoorDiscount = 0;


        //        Advanced = Convert.ToDecimal(ds.Tables[0].Rows[0][0]) - Convert.ToDecimal(ds.Tables[20].Rows[0][0]);
        //        Pathology = Convert.ToDecimal(ds.Tables[1].Rows[0][0]) - Convert.ToDecimal(ds.Tables[8].Rows[0][0]);
        //        XRay = Convert.ToDecimal(ds.Tables[2].Rows[0][0]) - Convert.ToDecimal(ds.Tables[9].Rows[0][0]);
        //        USG = Convert.ToDecimal(ds.Tables[3].Rows[0][0]) - Convert.ToDecimal(ds.Tables[10].Rows[0][0]);
        //        ECG = Convert.ToDecimal(ds.Tables[4].Rows[0][0]) - Convert.ToDecimal(ds.Tables[11].Rows[0][0]);
        //        OutdoorCollection = Convert.ToDecimal(ds.Tables[5].Rows[0][0]);

        //        Vaccine = Convert.ToDecimal(ds.Tables[12].Rows[0][0]);
        //        OutDoor = Convert.ToDecimal(ds.Tables[13].Rows[0][0]);
        //        BloodBank = Convert.ToDecimal(ds.Tables[14].Rows[0][0]);
        //        Ambulance = Convert.ToDecimal(ds.Tables[15].Rows[0][0]);
        //        Biopsy = Convert.ToDecimal(ds.Tables[16].Rows[0][0]);
        //        OutDoorOT = Convert.ToDecimal(ds.Tables[18].Rows[0][0]);
        //        Others = Convert.ToDecimal(ds.Tables[17].Rows[0][0]);
        //        OutDoorDiscount = Convert.ToDecimal(ds.Tables[19].Rows[0][0]);

        //        Investigation_Payment = Convert.ToDecimal(ds.Tables[21].Rows[0][0]);

        //        Collection = Advanced + Investigation_Payment + OutdoorCollection;

        //        CrystalDecisions.Shared.TableLogOnInfo tliCurrent;
        //        ReportDocument rptCustomersOrders = new CollectionsummaryNew();

        //        foreach (CrystalDecisions.CrystalReports.Engine.Table tbCurrent in rptCustomersOrders.Database.Tables)
        //        {
        //            tliCurrent = tbCurrent.LogOnInfo;
        //            tliCurrent.ConnectionInfo.ServerName = FormHelper.DBServerName;
        //            tliCurrent.ConnectionInfo.UserID = FormHelper.DBUser;
        //            tliCurrent.ConnectionInfo.Password = FormHelper.DBUserPassword;
        //            tliCurrent.ConnectionInfo.DatabaseName = FormHelper.DBName;
        //            tbCurrent.ApplyLogOnInfo(tliCurrent);
        //        }
        //        rptCustomersOrders.SetParameterValue("@from", From);
        //        rptCustomersOrders.SetParameterValue("@to", To);

        //        rptCustomersOrders.SetParameterValue("@Advanced", Advanced);
        //        rptCustomersOrders.SetParameterValue("@Pathology", Pathology);
        //        rptCustomersOrders.SetParameterValue("@XRay", XRay);
        //        rptCustomersOrders.SetParameterValue("@USG", USG);
        //        rptCustomersOrders.SetParameterValue("@ECG", ECG);
        //        rptCustomersOrders.SetParameterValue("@OutdoorCollection", OutdoorCollection);
        //        rptCustomersOrders.SetParameterValue("@Collection", Collection);//

        //        rptCustomersOrders.SetParameterValue("@Vaccine", Vaccine);
        //        rptCustomersOrders.SetParameterValue("@OutDoor", OutDoor);
        //        rptCustomersOrders.SetParameterValue("@BloodBank", BloodBank);
        //        rptCustomersOrders.SetParameterValue("@Ambulance", Ambulance);
        //        rptCustomersOrders.SetParameterValue("@Biopsy", Biopsy);
        //        rptCustomersOrders.SetParameterValue("@OutDoorOT", OutDoorOT);
        //        rptCustomersOrders.SetParameterValue("@Others", Others);
        //        rptCustomersOrders.SetParameterValue("@OutDoorDiscount", OutDoorDiscount);
        //        rptCustomersOrders.SetParameterValue("@Investigation_Payment", Investigation_Payment);

        //        FrmGenericReportViewer frmGenericReportViewer = new FrmGenericReportViewer();
        //        frmGenericReportViewer.crvParameter.DisplayGroupTree = false;
        //        frmGenericReportViewer.crvParameter.ReportSource = rptCustomersOrders;
        //        frmGenericReportViewer.Show();
                
        //    }
        //    catch
        //    {
        //    }
        //}

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btndue_Click(object sender, EventArgs e)
        {
        //    try
        //    {
        //        DateTime From = new DateTime(dtpFromDate.Value.Year, dtpFromDate.Value.Month, dtpFromDate.Value.Day, 0, 0, 0);
        //        DateTime To = new DateTime(dtpToDate.Value.Year, dtpToDate.Value.Month, dtpToDate.Value.Day, 23, 59, 59);

        //        CrystalDecisions.Shared.TableLogOnInfo tliCurrent;
        //        ReportDocument rptCustomersOrders = new DailyInvestigationDues();

        //        foreach (CrystalDecisions.CrystalReports.Engine.Table tbCurrent in rptCustomersOrders.Database.Tables)
        //        {
        //            tliCurrent = tbCurrent.LogOnInfo;
        //            tliCurrent.ConnectionInfo.ServerName = FormHelper.DBServerName;
        //            tliCurrent.ConnectionInfo.UserID = FormHelper.DBUser;
        //            tliCurrent.ConnectionInfo.Password = FormHelper.DBUserPassword;
        //            tliCurrent.ConnectionInfo.DatabaseName = FormHelper.DBName;
        //            tbCurrent.ApplyLogOnInfo(tliCurrent);
        //        }
        //        rptCustomersOrders.SetParameterValue("@from", From);
        //        rptCustomersOrders.SetParameterValue("@to", To);



        //        FrmGenericReportViewer frmGenericReportViewer = new FrmGenericReportViewer();
        //        frmGenericReportViewer.crvParameter.DisplayGroupTree = false;
        //        frmGenericReportViewer.crvParameter.ReportSource = rptCustomersOrders;
        //        frmGenericReportViewer.Show();
        //    }
        //    catch
        //    {
        //    }
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime From = new DateTime(dtpFromDate.Value.Year, dtpFromDate.Value.Month, dtpFromDate.Value.Day, 0, 0, 0);
                DateTime To = new DateTime(dtpToDate.Value.Year, dtpToDate.Value.Month, dtpToDate.Value.Day, 23, 59, 59);

                CrystalDecisions.Shared.TableLogOnInfo tliCurrent;
                ReportDocument rptCustomersOrders = new DatewiseCollectionInvoice();

                foreach (CrystalDecisions.CrystalReports.Engine.Table tbCurrent in rptCustomersOrders.Database.Tables)
                {
                    tliCurrent = tbCurrent.LogOnInfo;
                    tliCurrent.ConnectionInfo.ServerName = FormHelper.DBServerName;
                    tliCurrent.ConnectionInfo.UserID = FormHelper.DBUser;
                    tliCurrent.ConnectionInfo.Password = FormHelper.DBUserPassword;
                    tliCurrent.ConnectionInfo.DatabaseName = FormHelper.DBName;
                    tbCurrent.ApplyLogOnInfo(tliCurrent);
                }
                rptCustomersOrders.SetParameterValue("@from", From);
                rptCustomersOrders.SetParameterValue("@to", To);



                FrmGenericReportViewer frmGenericReportViewer = new FrmGenericReportViewer();
                frmGenericReportViewer.crvParameter.DisplayGroupTree = false;
                frmGenericReportViewer.crvParameter.ReportSource = rptCustomersOrders;
                frmGenericReportViewer.Show();
            }
            catch
            {
            }

        }
    }
}
