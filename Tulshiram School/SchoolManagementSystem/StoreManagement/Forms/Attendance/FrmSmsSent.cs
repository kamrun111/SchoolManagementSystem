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
using System.Data.SqlClient;
using System.Net;
using System.IO;
using SchoolManagementSystem.Reports;
using CrystalDecisions.CrystalReports.Engine;

namespace SchoolManagementSystem.Forms.Attendance
{
    public partial class FrmSmsSent : BaseForm.FrmBase
    {
        public FrmSmsSent()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime From = new DateTime(dtpFromDate.Value.Year, dtpFromDate.Value.Month, dtpFromDate.Value.Day, 0, 0, 0);
                CommonClass cs = new CommonClass();
                DataSet ds = cs.GetDataSetWithDateParameter("@Date", From, "AbsentStudentSMS");
                if (ds.Tables[0].Rows.Count > 0)
                {


                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                    grdStudent.Rows.Add();
                    grdStudent.Rows[i].Cells[0].Value = ds.Tables[0].Rows[i][0];
                    grdStudent.Rows[i].Cells[1].Value = ds.Tables[0].Rows[i][1];
                    grdStudent.Rows[i].Cells[2].Value = ds.Tables[0].Rows[i][2];
                    grdStudent.Rows[i].Cells[3].Value = ds.Tables[0].Rows[i][3];
                    grdStudent.Rows[i].Cells[4].Value = ds.Tables[0].Rows[i][4];
                    grdStudent.Rows[i].Cells[5].Value = ds.Tables[0].Rows[i][5];
                    grdStudent.Rows[i].Cells[6].Value = ds.Tables[0].Rows[i][6];
                    grdStudent.Rows[i].Cells[8].Value = 1;
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
                doSendSms();
            }
            catch
            {
            }
        }
        public string doSendSms()
        {
            //========================infoBuzzer Credentials ========================= 
            string userName = "faiyazscr@gmail.com"; //sms@scubesoftware.com
            string passWord = "65$321@";  //sms321
            string Url = "http://api.infobuzzer.net:8083/v3.1/SendSMS/sendSmsInfoStore";
            string responseText;
            //======================================================================== 

            DateTime myTime = DateTime.Now;
            string myTrxID = myTime.ToString("yyyy-MM-dd  HH:mm:ss");
            //======================SMS Objects============================= 

            string trxID = "20160111162410308";   //change it and give a unique ID 
            string trxTime = myTrxID;  //change and give a time            

            List<SMSCLASS> SMSObjList = new List<SMSCLASS>();
            for (int i = 0; i < grdStudent.Rows.Count; i++)
            {
                if(Convert.ToInt32(grdStudent.Rows[i].Cells[8].Value) ==1)
                {
                    string smsBody1 = "Dear Parent, Your child is Absent in school Today. Please Provide reason by Calling his/her Class Teacher. Thank you";
                    SMSObjList.Add(new SMSCLASS(grdStudent.Rows[i].Cells[1].ToString(), myTrxID, "Faiyaz", "88" + grdStudent.Rows[i].Cells[6].Value.ToString(), smsBody1));
                }
            }

           // //1st SMS 
           //string smsBody1 = "1st Test SMS from .Net @ " ;
           // SMSObjList.Add(new SMSCLASS(trxID, myTrxID, "jhorotek", "8801717829244", smsBody1));


            ////2nd SMS 
            //string smsBody2 = "2nd Test SMS from .Net @ " + myTrxID;
            //SMSObjList.Add(new SMSCLASS("20160111162410309", "2016-01-13 08:31:11", "jhorotek", "8801714133069", smsBody2));


            //========================================================================= 

            /* 
             *  ___________________________________________________________________________ 
             *   
             *  >>>>>>>>>>> No need to change anything below this point <<<<<<<<<<<<<<<<<< 
             *  ___________________________________________________________________________ 
             */

            try
            {

                HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(Url);


                //-------------------------------jSON Object Creation------------------------- 
                Encoding encoding = new UTF8Encoding();
                string postData = this.jSonObjForInfoBuzzerSMS(trxID, trxTime, SMSObjList);
                byte[] data = encoding.GetBytes(postData);
                //---------------------------------------------------------------------------- 

                httpWReq.ProtocolVersion = HttpVersion.Version11;
                httpWReq.Method = "POST";
                httpWReq.ContentType = "application/json"; //charset=UTF-8";   
                 

                string _auth = string.Format("{0}:{1}", userName, passWord);
                string _enc = Convert.ToBase64String(Encoding.ASCII.GetBytes(_auth));
                string _cred = string.Format("{0} {1}", "Basic", _enc);
   

                httpWReq.Headers[HttpRequestHeader.Authorization] = _cred;
                httpWReq.ContentLength = data.Length;


                Stream stream = httpWReq.GetRequestStream();
                stream.Write(data, 0, data.Length);
                stream.Close();

                HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();
                string s = response.ToString();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                String jsonresponse = "";
                String temp = null;
                while ((temp = reader.ReadLine()) != null)
                {
                    jsonresponse += temp;
                }
                return jsonresponse;
            }
            catch (WebException e)
            {

                using (WebResponse response = e.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)response;
                    Console.WriteLine("Error code: {0}", httpResponse.StatusCode);
                    using (Stream data = response.GetResponseStream())
                    using (var reader = new StreamReader(data))
                    {
                        responseText = reader.ReadToEnd();
                        Console.WriteLine(responseText);
                    }
                }
                return responseText;
            }
        }



        //jSON OBject Convertion.................................................................. 
        string jSonObjForInfoBuzzerSMS(string trxID, string trxTime, List<SMSCLASS> SMSObjList)
        {
            int nSMSCount = SMSObjList.Count;

            string myInfoBuzzerSMSObject = @"{" +
                        "\"trxID\": \"" + trxID + "\"," +
                        "\"trxTime\": \"" + trxTime + "\"," +
                        "\"smsDatumArray\": [";

            for (int i = 0; i < nSMSCount; i++)
            {

                if (i > 0)
                {
                    myInfoBuzzerSMSObject += ",";
                }
                myInfoBuzzerSMSObject += this.jSonFromSMSObj(SMSObjList[i]);



            }
            myInfoBuzzerSMSObject += "]" +
                   "}";
            return myInfoBuzzerSMSObject;
        }



        string jSonFromSMSObj(SMSCLASS objSMSCLASS)
        {
            string jSonOfASMS = "{" +
            "\"smsID\": \"" + objSMSCLASS.smsID + "\"," +
            "\"smsSendTime\": \"" + objSMSCLASS.smsSendTime + "\"," +
            "\"mask\": \"" + objSMSCLASS.mask + "\"," +
            "\"mobileNo\": \"" + objSMSCLASS.mobileNo + "\"," +
            "\"smsBody\": \"" + objSMSCLASS.smsBody + "\"" +
            "}";
            return jSonOfASMS;
        }
        public class SMSCLASS
        {
            public string smsID;
            public string smsSendTime;
            public string mask;
            public string mobileNo;
            public string smsBody;

            public SMSCLASS(string smsID, string smsSendTime, string mask, string mobileNo, string smsBody)
            {
                this.smsID = smsID;
                this.smsSendTime = smsSendTime;
                this.mask = mask;
                this.mobileNo = mobileNo;
                this.smsBody = smsBody;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DateTime From = new DateTime(dtpFromDate.Value.Year, dtpFromDate.Value.Month, dtpFromDate.Value.Day, 0, 0, 0);
            PrintTeacherAbsent(From);
            PrintStuffAbsent(From);
            PrintStudentAbsent(From);
        }

        public void PrintTeacherAbsent(DateTime Date)
        {
            try
            {
                CrystalDecisions.Shared.TableLogOnInfo tliCurrent;
                ReportDocument rptCustomersOrders = new AbsentReport();

                foreach (CrystalDecisions.CrystalReports.Engine.Table tbCurrent in rptCustomersOrders.Database.Tables)
                {
                    tliCurrent = tbCurrent.LogOnInfo;

                    tliCurrent.ConnectionInfo.ServerName = FormHelper.DBServerName;
                    tliCurrent.ConnectionInfo.UserID = FormHelper.DBUser; ;
                    tliCurrent.ConnectionInfo.Password = FormHelper.DBUserPassword;
                    tliCurrent.ConnectionInfo.DatabaseName = FormHelper.DBName;
                    tbCurrent.ApplyLogOnInfo(tliCurrent);
                }

                rptCustomersOrders.SetParameterValue("@datetime", Date);

                FrmGenericReportViewer frmGenericReportViewer = new FrmGenericReportViewer();
                frmGenericReportViewer.crvParameter.DisplayGroupTree = false;
                frmGenericReportViewer.crvParameter.ReportSource = rptCustomersOrders;
                frmGenericReportViewer.Show();

            }
            catch
            {
            }
        }
        public void PrintStuffAbsent(DateTime Date)
        {
            try
            {
                CrystalDecisions.Shared.TableLogOnInfo tliCurrent;
                ReportDocument rptCustomersOrders = new AbsentReportStuff();

                foreach (CrystalDecisions.CrystalReports.Engine.Table tbCurrent in rptCustomersOrders.Database.Tables)
                {
                    tliCurrent = tbCurrent.LogOnInfo;

                    tliCurrent.ConnectionInfo.ServerName = FormHelper.DBServerName;
                    tliCurrent.ConnectionInfo.UserID = FormHelper.DBUser; ;
                    tliCurrent.ConnectionInfo.Password = FormHelper.DBUserPassword;
                    tliCurrent.ConnectionInfo.DatabaseName = FormHelper.DBName;
                    tbCurrent.ApplyLogOnInfo(tliCurrent);
                }

                rptCustomersOrders.SetParameterValue("@datetime", Date);

                FrmGenericReportViewer frmGenericReportViewer = new FrmGenericReportViewer();
                frmGenericReportViewer.crvParameter.DisplayGroupTree = false;
                frmGenericReportViewer.crvParameter.ReportSource = rptCustomersOrders;
                frmGenericReportViewer.Show();

            }
            catch
            {
            }
        }

        public void PrintStudentAbsent(DateTime Date)
        {
            try
            {
                CrystalDecisions.Shared.TableLogOnInfo tliCurrent;
                ReportDocument rptCustomersOrders = new AbsentReportStudent();

                foreach (CrystalDecisions.CrystalReports.Engine.Table tbCurrent in rptCustomersOrders.Database.Tables)
                {
                    tliCurrent = tbCurrent.LogOnInfo;

                    tliCurrent.ConnectionInfo.ServerName = FormHelper.DBServerName;
                    tliCurrent.ConnectionInfo.UserID = FormHelper.DBUser; ;
                    tliCurrent.ConnectionInfo.Password = FormHelper.DBUserPassword;
                    tliCurrent.ConnectionInfo.DatabaseName = FormHelper.DBName;
                    tbCurrent.ApplyLogOnInfo(tliCurrent);
                }

                rptCustomersOrders.SetParameterValue("@datetime", Date);

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
