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
    public partial class FrmFeesCollection : BaseForm.FrmBase
    {
        public FrmFeesCollection()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        CommonClass cs = new CommonClass();
        int ClassId, PaymentCatagoryId, FeeTypeID,StudentID,SessionID,SectionID = 0;
        string Month = "";

        private void txtRegSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                DataSet ds = cs.GetDataSetWithParameter("@reg_no", Convert.ToInt32(txtRegSearch.Text),"FeeCollectionStudent");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    StudentID = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                    txtName.Text = ds.Tables[0].Rows[0][2].ToString();
                    txtSection.Text = ds.Tables[0].Rows[0][3].ToString();
                    txtClass.Text = ds.Tables[0].Rows[0][4].ToString();
                    txtRoll_No.Text = ds.Tables[0].Rows[0][5].ToString();
                    txtPaymentCategory.Text = ds.Tables[0].Rows[0][10].ToString();
                    ClassId = Convert.ToInt32(ds.Tables[0].Rows[0][7]);
                    PaymentCatagoryId = Convert.ToInt32(ds.Tables[0].Rows[0][9]);
                    SessionID = Convert.ToInt32(ds.Tables[0].Rows[0][11]);
                    SectionID = Convert.ToInt32(ds.Tables[0].Rows[0][8]);
                }
                ds = null;
                FeeCollectionBLL feeCollectionBLL = new FeeCollectionBLL();
                ds = feeCollectionBLL.FeeCollectionMonthLoad(StudentID, SessionID);
                var cat = GetAll(this, typeof(Button));//to get all the button
                if(ds.Tables[0].Rows.Count>0)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        foreach (Button b in cat)
                        {

                            if (b.Text == ds.Tables[0].Rows[i][2].ToString())
                            {
                                b.Enabled = false;
                                b.BackColor = Color.Blue;
                                if(ds.Tables[0].Rows[i][3].ToString()=="0")
                                    b.BackColor = Color.Purple;
                            }
                            
                            
                        }

                    }

                }
            }
            catch
            {
            }

        }

        private void btnJanuary_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtRegSearch.Text != "")
                {
                    Button button = (Button)sender;
                    Month= button.Text;
                    
                    FeeCollectionBLL feeCollectionBLL = new FeeCollectionBLL();
                    DataSet ds = feeCollectionBLL.FeeCollectionMonthly(ClassId, PaymentCatagoryId, Month);
                    decimal Total = 0;
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
                            Total =Total+ Convert.ToDecimal(ds.Tables[0].Rows[i][3]);
                        }
                    }
                    txtTotalAmount.Text=Total.ToString("0#.#0");
                    txtFineAmount.Text = "00.00";
                    //if (ds.Tables[1].Rows.Count > 0)
                    //{
                    //    if (ds.Tables[1].Rows[0][4] !="")
                    //    {
                    //        if (DateTime.Now > Convert.ToDateTime(ds.Tables[1].Rows[0][4]))
                    //            txtFineAmount.Text = ds.Tables[0].Rows[0][3].ToString();

                    //    }
                    //    if (ds.Tables[0].Rows[0][4] == null)
                    //        txtFineAmount.Text = "00.00";
                    //}
                }
            }
            catch
            {
            }
        }

        private void txtPaidAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                cs.NumCheck(e);

            }
            catch
            {
            }
        }

        private void txtPaidAmount_Leave(object sender, EventArgs e)
        {
            try
            {
                decimal balance = 0;
                balance = Convert.ToDecimal(txtTotalAmount.Text) + Convert.ToDecimal(txtFineAmount.Text) - Convert.ToDecimal(txtPaidAmount.Text);
                txtBalanceAmount.Text = balance.ToString("0#.#0");
                if (Convert.ToDecimal(txtPaidAmount.Text) > Convert.ToDecimal(txtTotalAmount.Text))
                {
                    MessageBox.Show("Insert Correctly");
                    txtPaidAmount.Text = "";
                    txtBalanceAmount.Text = "";
                    return;

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
                if (txtPaidAmount.Text != "")
                {
                    if (grdFeeCollection.Rows.Count == 0)
                        return;
                    FeeCollectionBO feeCollectionBO = new FeeCollectionBO();
                    FeePaymentBO feePaymentBO = new FeePaymentBO();
                    FeeCollectionBLL feeCollectionBLL = new FeeCollectionBLL();
                    
                    List<FeeCollectionDetailsBO> listFeeCollectionDetailsBO = new List<FeeCollectionDetailsBO>();

                    feeCollectionBO.student_id = StudentID;
                    feeCollectionBO.class_id = ClassId;
                    feeCollectionBO.section_id = SectionID;
                    feeCollectionBO.session_id = SessionID;
                    feeCollectionBO.fine_amount = Convert.ToDecimal(txtFineAmount.Text);
                    feeCollectionBO.total_amount = Convert.ToDecimal(txtTotalAmount.Text);
                    feeCollectionBO.paid_amount = Convert.ToDecimal(txtPaidAmount.Text);
                    feeCollectionBO.balance_amount = Convert.ToDecimal(txtBalanceAmount.Text);
                    feeCollectionBO.payment_type = "Cash";
                    if (feeCollectionBO.balance_amount > 0)
                        feeCollectionBO.payment_status = 0;
                    else
                        feeCollectionBO.payment_status = 1;
                    feeCollectionBO.payment_month = Month;
                    feeCollectionBO.payment_catagory_id = PaymentCatagoryId;//General/Scolar
                    feeCollectionBO.record_created_by = ApplicatinLauncher._userId;

                    feePaymentBO.net_payable = Convert.ToDecimal(txtPaidAmount.Text) + Convert.ToDecimal(txtFineAmount.Text);
                    feePaymentBO.fee_paid_amount = Convert.ToDecimal(txtPaidAmount.Text);
                    feePaymentBO.record_created_by = ApplicatinLauncher._userId;



                    for (int i = 0; i < grdFeeCollection.Rows.Count; i++)
                    {
                        FeeCollectionDetailsBO feeCollectionDetailsBO = new FeeCollectionDetailsBO();
                        feeCollectionDetailsBO.fee_name_id = Convert.ToInt32(grdFeeCollection.Rows[i].Cells[5].Value);
                        feeCollectionDetailsBO.month_name = grdFeeCollection.Rows[i].Cells[4].Value.ToString();
                        feeCollectionDetailsBO.amount = Convert.ToDecimal(grdFeeCollection.Rows[i].Cells[3].Value);
                        feeCollectionDetailsBO.record_created_by = ApplicatinLauncher._userId;
                        listFeeCollectionDetailsBO.Add(feeCollectionDetailsBO);
                    }
                    int result = feeCollectionBLL.FeeCollectionInsert(feeCollectionBO, listFeeCollectionDetailsBO, feePaymentBO);
                    if (result > 0)
                    {
                        MessageBox.Show("DataSaved Successfully");
                        btnSave.Enabled = false;
                        PrintInvoice(result);
                        listFeeCollectionDetailsBO = null;
                    }
                }
                
            }
            catch
            {
            }

        }

        private void FrmFeesCollection_Load(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch
            {
            }
        }
        public IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }

        void GetRefresh()
        {
            try
            {
                var cat = GetAll(this, typeof(Button));//to get all the button
                foreach (Button b in cat)
                {
                        b.Enabled = true;
                        b.BackColor = Color.Transparent;

                }
                grdFeeCollection.Rows.Clear();
                ClassId=0; PaymentCatagoryId=0; FeeTypeID=0;StudentID=0;SessionID=0;SectionID=0;
                Month="";
                txtName.Text ="";
                txtSection.Text = "";
                txtClass.Text = "";
                txtRoll_No.Text = "";
                txtPaymentCategory.Text = "";
                txtRegSearch.Text = "";
                txtTotalAmount.Text = "";
                txtPaidAmount.Text = "";
                txtBalanceAmount.Text = "";
                txtFineAmount.Text = "";


            }
            catch
            {
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                GetRefresh();
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

        private void txtPaidAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSave.Focus();
        }

        private void btnDue_Click(object sender, EventArgs e)
        {
            try
            {
                FrmDueFeeCollection frmDueFeeCollection = new FrmDueFeeCollection();
                frmDueFeeCollection.GetProduct(StudentID, SessionID); 
                frmDueFeeCollection.ShowDialog();

                //frmDueFeeCollection.Dispose();


            }
            catch
            {
            }
        }






  




    }
}
