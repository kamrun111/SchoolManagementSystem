using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SchoolManagementSystem.Forms.Dashboard
{
    public partial class FrmDashboard : BaseForm.FrmBase
    {
        public FrmDashboard()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            try
            {
                CommonClass cs = new CommonClass();
                DataSet ds = cs.GetDataSet("DashBoardLoad");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtStudent.Text = ds.Tables[0].Rows[0][0].ToString();
                    txtStudentPresent.Text = ds.Tables[1].Rows[0][0].ToString();
                    txtabsentstudent.Text = ds.Tables[2].Rows[0][0].ToString();
                    txtTotalTeacher.Text = ds.Tables[3].Rows[0][0].ToString();
                    txtPresentTeacher.Text = ds.Tables[4].Rows[0][0].ToString();
                    txtAbsentTeacher.Text = ds.Tables[5].Rows[0][0].ToString(); 
                    txtStuff.Text = ds.Tables[6].Rows[0][0].ToString(); 
                    txtPresentStuff.Text = ds.Tables[7].Rows[0][0].ToString();
                    txtAbsentStuff.Text = ds.Tables[8].Rows[0][0].ToString();

                    txtCollection.Text = ds.Tables[9].Rows[0][0].ToString();
                    txtdue.Text = ds.Tables[10].Rows[0][0].ToString();
                    txtTodaysTotalCollection.Text = ds.Tables[15].Rows[0][0].ToString();
                    txtTotalDue.Text = ds.Tables[11].Rows[0][0].ToString();
                    txtOtherCollection.Text = ds.Tables[12].Rows[0][0].ToString();
                    txtTotalFeeCollection.Text = ds.Tables[16].Rows[0][0].ToString();
                    txtTodaysExpenditure.Text = ds.Tables[13].Rows[0][0].ToString();
                    txtTotalExpenditure.Text = ds.Tables[14].Rows[0][0].ToString();
                    txtTotalCollection.Text = (Convert.ToDecimal(txtTotalFeeCollection.Text) + Convert.ToDecimal(txtOtherCollection.Text)).ToString();
                    txtBalance.Text = (Convert.ToDecimal(txtTotalCollection.Text) - Convert.ToDecimal(txtTotalExpenditure.Text)).ToString();
                    txtBankDeposite.Text = ds.Tables[17].Rows[0][0].ToString();
                    txtCashInHand.Text = (Convert.ToDecimal(txtBalance.Text) - Convert.ToDecimal(txtBankDeposite.Text)).ToString();

                }
            }
            catch
            {
            }
        }

        

        
    }
}
