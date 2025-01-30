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
using System.Net;
using System.IO;

namespace SchoolManagementSystem.Forms.Message
{
    public partial class FrmGroupMessage : BaseForm.FrmBase
    {
        public FrmGroupMessage()
        {
            InitializeComponent();
        }
        CommonClass cs = new CommonClass();

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        void GetLoad()
        {
            try
            {
                DataSet ds = cs.GetDataSet("MeaageGroupLoad");
                if (ds.Tables[0].Rows.Count > 0)
                    cs.FillUpListview(lvwGroup, ds, 0);
                txtGroupName.Text = "";
                txtMessage.Text = "";
                grdGroup.Rows.Clear();
            }
            catch
            {
            }

        }

        private void FrmGroupMessage_Load(object sender, EventArgs e)
        {
            GetLoad();
        }

        private void lvwGroup_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvwGroup.SelectedItems.Count > 0)
                {
                    txtGroupName.Text = lvwGroup.SelectedItems[0].SubItems[1].Text;
                    DataSet ds = cs.GetDataSetWithParameter("@message_group_id", Convert.ToInt32(lvwGroup.SelectedItems[0].Text),"MessageGroupLoadDetails");
                    if (ds.Tables[0].Rows.Count>0)
                    {
                        grdGroup.Rows.Clear();
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            grdGroup.Rows.Add();
                            grdGroup.Rows[i].Cells[0].Value = ds.Tables[0].Rows[i][0];
                            grdGroup.Rows[i].Cells[1].Value = ds.Tables[0].Rows[i][1];
                            grdGroup.Rows[i].Cells[2].Value = ds.Tables[0].Rows[i][2];
                            grdGroup.Rows[i].Cells[3].Value = ds.Tables[0].Rows[i][3];
                            grdGroup.Rows[i].Cells[4].Value = 1;
                        }
                    }


                }
            }
            catch
            {
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            doSendSms();
            MessageBox.Show("Message has been send");
        }
        public string doSendSms()
        {
            //========================infoBuzzer Credentials ========================= 
            string userName = "sms@scubesoftware.com"; // faiyazscr@gmail.com
            string passWord = "sms321";   // 65$321@
            string Url = "http://api.infobuzzer.net:8083/v3.1/SendSMS/sendSmsInfoStore";
            string responseText;
            //======================================================================== 

            DateTime myTime = DateTime.Now;
            string myTrxID = myTime.ToString("yyyy-MM-dd  HH:mm:ss");
            //======================SMS Objects============================= 

            string trxID = "20160111162410308";   //change it and give a unique ID 
            string trxTime = myTrxID;  //change and give a time            

            List<SMSCLASS> SMSObjList = new List<SMSCLASS>();
            for (int i = 0; i < grdGroup.Rows.Count; i++)
            {
                if (Convert.ToInt32(grdGroup.Rows[i].Cells[4].Value) == 1)
                {
                    string smsBody1 = txtMessage.Text;
                    SMSObjList.Add(new SMSCLASS(grdGroup.Rows[i].Cells[0].ToString(), myTrxID, "Faiyaz", "88" + grdGroup.Rows[i].Cells[3].Value.ToString(), smsBody1));
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetLoad();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtContact.Text == "")
                    return;
                grdGroup.Rows.Add();
                grdGroup.Rows[grdGroup.Rows.Count-1].Cells[0].Value = 1; 
                grdGroup.Rows[grdGroup.Rows.Count-1].Cells[3].Value =txtContact.Text;
                grdGroup.Rows[grdGroup.Rows.Count - 1].Cells[4].Value = 1; 

            }
            catch
            {
            }
        }
    }
}
