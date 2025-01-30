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
using System.Net;
using System.IO;

namespace SchoolManagementSystem.Forms.Fees
{
    public partial class FrmOthersFeesCollection : BaseForm.FrmBase
    {
        public FrmOthersFeesCollection()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        CommonClass cs = new CommonClass();

        int ClassId, PaymentCatagoryId, FeeTypeID, StudentID, SessionID, SectionID = 0;

        private void txtRegSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                DataSet ds = cs.GetDataSetWithParameter("@reg_no", Convert.ToInt32(txtRegSearch.Text), "FeeCollectionStudent");
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
                    txtContact.Text = ds.Tables[0].Rows[0][6].ToString();
                                                                            
                   }
                
                

                }
            
            catch
            {
            }

        }

        void getLoad()
        {
            try
            {
                DataSet ds = cs.GetDataSet("FeeSettingLoad");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    cs.PopulateComboBox(cmbFeesName, ds, 0, "fee_name", "fee_name_id");
                    
                    btnSave.Enabled = true;
                 

                }
            }
            catch
            {
            }
        }

        private void FrmOthersFeesCollection_Load(object sender, EventArgs e)
        {
            getLoad();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbFeesName.SelectedIndex == -1)
                {
                    MessageBox.Show("Select item from list");
                    cmbFeesName.Focus();
                    return;
                }
                //if (txtamount.Text == "")
                //{
                //    MessageBox.Show("Please insert amount");
                //    txtamount.Focus();
                //    return;
                //}
                this.grdFeeCollection.CellValueChanged -= this.grdFeeCollection_CellValueChanged;
                grdFeeCollection.Rows.Add();
                grdFeeCollection.Rows[grdFeeCollection.Rows.Count - 1].Cells[1].Value = "2";
                grdFeeCollection.Rows[grdFeeCollection.Rows.Count - 1].Cells[3].Value = "Admission";
                grdFeeCollection.Rows[grdFeeCollection.Rows.Count - 1].Cells[0].Value = cmbFeesName.Text.ToString();
                //grdexpenditure.Rows[grdFeeCollection.Rows.Count - 1].Cells[1].Value = txtamount.Text.ToString();
                grdFeeCollection.Rows[grdFeeCollection.Rows.Count - 1].Cells[4].Value = Convert.ToInt32(cmbFeesName.SelectedValue);
                
                //int count = Convert.ToInt32(grdexpenditure.Rows.Count);
                //txtCount.Text = count.ToString();
                adjustGrandTotal();
                this.grdFeeCollection.CellValueChanged += this.grdFeeCollection_CellValueChanged;



            }
            catch
            {
            }
        }

        private void grdFeeCollection_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (e.ColumnIndex == 0) return;


            string msg = "";
            DataGridViewRow row = null;
            row = this.grdFeeCollection.Rows[e.RowIndex];
            try
            {
                string valueStr = (row.Cells[e.ColumnIndex].Value == null ? "" : row.Cells[e.ColumnIndex].Value.ToString());
                int valueNumeric = 0;
                int.TryParse(valueStr, out valueNumeric);
                if (valueNumeric < 0)
                {
                    MessageBox.Show("Please Insert Digits Properly");
                    row.Cells[e.ColumnIndex].Value = 0;
                    //return;
                }
                else if (!int.TryParse(valueStr, out valueNumeric))
                {
                    MessageBox.Show("Please Insert Digits Properly");
                    row.Cells[e.ColumnIndex].Value = 0;
                }
                adjustGrandTotal();

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
                for (int i = 0; i < this.grdFeeCollection.RowCount; i++)
                {
                    double subTotal = 0.00;
                    double.TryParse(this.grdFeeCollection.Rows[i].Cells["amount"].Value.ToString(), out subTotal);
                    grandTotal += subTotal;
                }
                this.txtTotalAmount.Text = grandTotal.ToString("00");
            }
            catch
            {
                //this.txtGrandTotal.Text = "00";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTotalAmount.Text != "")
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
                    feeCollectionBO.fine_amount = 0;
                    feeCollectionBO.total_amount = Convert.ToDecimal(txtTotalAmount.Text);
                    feeCollectionBO.paid_amount = Convert.ToDecimal(txtTotalAmount.Text);
                    feeCollectionBO.balance_amount = 0;
                    feeCollectionBO.payment_type = "Cash";
                    if (feeCollectionBO.balance_amount > 0)
                        feeCollectionBO.payment_status = 0;
                    else
                        feeCollectionBO.payment_status = 1;
                    feeCollectionBO.payment_month = "Admission";
                    feeCollectionBO.payment_catagory_id = PaymentCatagoryId;//General/Scolar
                    feeCollectionBO.record_created_by = ApplicatinLauncher._userId;

                    feePaymentBO.net_payable = Convert.ToDecimal(txtTotalAmount.Text);
                    feePaymentBO.fee_paid_amount = Convert.ToDecimal(txtTotalAmount.Text);
                    feePaymentBO.record_created_by = ApplicatinLauncher._userId;



                    for (int i = 0; i < grdFeeCollection.Rows.Count; i++)
                    {
                        FeeCollectionDetailsBO feeCollectionDetailsBO = new FeeCollectionDetailsBO();
                        feeCollectionDetailsBO.fee_name_id = Convert.ToInt32(grdFeeCollection.Rows[i].Cells[4].Value);
                        feeCollectionDetailsBO.month_name = grdFeeCollection.Rows[i].Cells[3].Value.ToString();
                        feeCollectionDetailsBO.amount = Convert.ToDecimal(grdFeeCollection.Rows[i].Cells[2].Value);
                        feeCollectionDetailsBO.record_created_by = ApplicatinLauncher._userId;
                        listFeeCollectionDetailsBO.Add(feeCollectionDetailsBO);
                    }
                    int result = feeCollectionBLL.FeeCollectionInsert(feeCollectionBO, listFeeCollectionDetailsBO, feePaymentBO);
                    if (result > 0)
                    {
                        btnSave.Enabled = false;
                        MessageBox.Show("DataSaved Successfully");
                        PrintInvoice(result);
                        listFeeCollectionDetailsBO = null;
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            
            txtRegSearch.Text = "";
            txtName.Text = "";
            txtSection.Text = "";
            txtClass.Text = "";
            txtRoll_No.Text = "";
            txtPaymentCategory.Text = "";
            txtContact.Text = "";
            //SessionID = "";
            //SectionID = "";
            //ClassId = "";
            //PaymentCatagoryId = "";
            grdFeeCollection.Rows.Clear();
            txtTotalAmount.Text = "";
            getLoad();

        }




    }


}
