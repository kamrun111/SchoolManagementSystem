using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SchoolManagementSystem.Forms.Login;
using SchoolManagementSystem.Forms;
using SchoolManagementSystem.Forms.Attendence;
using SchoolManagementSystem.Forms.Students;
using SchoolManagementSystem.Forms.Attendance;
using SchoolManagementSystem.Forms.Fees;
using SchoolManagementSystem.Forms.Dashboard;
using SchoolManagementSystem.Forms.Exam;
using SchoolManagementSystem.Forms.Accounts;
using SchoolManagementSystem.Forms.Stuff;
using SchoolManagementSystem.Forms.Subject;
using SchoolManagementSystem.Forms.Message;

namespace SchoolManagementSystem.MainForm
{
    public partial class FrmMain : Form
    {
        public static List<Form> _aliveForm = new List<Form>();
        private static string _userName;
        public static string UserName
        {
            get
            {               
                return _userName;
            }
        }

        public FrmMain(string userName)
        {
            InitializeComponent();
            _userName = userName;
        }

        //Begin: Added by Md. Tariqul Islam Sarker Dated: 29-Nov-2008
        public void OpenChildForm(Forms.BaseForm.FrmBase childForm)
        {
            foreach (Form existChildForm in this.MdiChildren)
            {
                if (existChildForm.Name == childForm.Name)
                {
                    childForm.Close();
                    existChildForm.BringToFront();
                    return;
                }
            }
            childForm.MdiParent = this;
            childForm.Show();
        }        
        //End:  Dated: 29-Nov-2008

        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.StatusLabelLoginName.Text = UserName.ToUpper();
            this.StatusTextLogedDateTime.Text = DateTime.Now.ToString("dd MMM, yyyy  hh:mm:ss tt");
        }

        private void userCreationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenChildForm(new FrmUserCreation());
           
        }

        private void UserGroup_Click(object sender, EventArgs e)
        {
            FrmUserGroupCreation frmUserGroupCreation = new FrmUserGroupCreation();
            frmUserGroupCreation.Show();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmChangePassword frmChangePassword = new FrmChangePassword();
            frmChangePassword.ShowDialog();
        }

        private void studentInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmStudentsAdmission frmStudentsRegistration = new FrmStudentsAdmission();
            frmStudentsRegistration.Show();
        }

        private void studentAttendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmStudentAttendance frmStudentAttendance = new FrmStudentAttendance();
            frmStudentAttendance.Show();
        }

        private void dailyAttendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAttendance frmAttendance = new FrmAttendance();
            frmAttendance.Show();
        }

        private void messageSentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSmsSent frmSmsSent = new FrmSmsSent();
            frmSmsSent.Show();
        }

        private void collectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFeesCollection frmFeesCollection = new FrmFeesCollection();
            frmFeesCollection.Show();
        }

        private void invoiceListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmInvoiceList frmInvoiceList = new FrmInvoiceList();
            frmInvoiceList.Show();
        }

        private void studentListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmStudentList frmStudentList = new FrmStudentList();
            frmStudentList.Show();
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDashboard frmDashboard = new FrmDashboard();
            frmDashboard.Show();
        }

        private void examMarksEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmExamMarksEntry frmExamMarksEntry = new FrmExamMarksEntry();
            frmExamMarksEntry.Show();
        
        }

        private void donationCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDonationCollection frmDonationCollection = new FrmDonationCollection();
            frmDonationCollection.Show();
        }

        private void voucherEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDailyExpenditure frmDailyExpenditure = new FrmDailyExpenditure();
            frmDailyExpenditure.Show();
        }

        private void voucherPrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmExpenditurePrint frmExpenditurePrint = new FrmExpenditurePrint();
            frmExpenditurePrint.Show();
        }

        private void donationListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDonationList frmDonationList = new FrmDonationList();
            frmDonationList.Show();
        }

        private void collectionExpenditureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCollectionExpenditure frmCollectionExpenditure = new FrmCollectionExpenditure();
            frmCollectionExpenditure.Show();
        }

        private void teacherInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTeacherAdd frmTeacherAdd = new FrmTeacherAdd();
            frmTeacherAdd.Show();
        }

        private void teacherInformationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmTeacherAdd frmTeacherAdd = new FrmTeacherAdd();
            frmTeacherAdd.Show();
        }

        private void stuffInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmStuffAdd frmStuffAdd = new FrmStuffAdd();
            frmStuffAdd.Show();
        }

        private void feesSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFeeSetting frmFeeSetting = new FrmFeeSetting();
            frmFeeSetting.Show();
        }

        private void dueCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDueFeeCollection frmDueFeeCollection = new FrmDueFeeCollection();
            frmDueFeeCollection.Show();
        }

        private void examMarksAssignToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmExamMarksAssign frmExamMarksAssign = new FrmExamMarksAssign();
            frmExamMarksAssign.Show();
        }

        private void subjectAssignToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSubjectAssign frmSubjectAssign = new FrmSubjectAssign();
            frmSubjectAssign.Show();
        }

        private void examResultToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmExamResult frmExamResult = new FrmExamResult();
            frmExamResult.Show();
        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmExamReport frmExamReport = new FrmExamReport();
            frmExamReport.Show();
        }

        private void voucherReviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmExpenditureEdit frmExpenditureEdit = new FrmExpenditureEdit();
            frmExpenditureEdit.Show();
        }

        private void othersIncomeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOthersIncome frmOthersIncome = new FrmOthersIncome();
            frmOthersIncome.Show();
        }

        private void chequeEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCheaqueEntry frmCheaqueEntry = new FrmCheaqueEntry();
            frmCheaqueEntry.Show();
        }

        private void bankTransToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmChequePayment frmChequePayment = new FrmChequePayment();
            frmChequePayment.Show();
        }

        private void expenseHeadAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmExpenceHeadEntry frmExpenceHeadEntry = new FrmExpenceHeadEntry();
            frmExpenceHeadEntry.Show();
        }

        private void subjectAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSubjectEntry frmSubjectEntry = new FrmSubjectEntry();
            frmSubjectEntry.Show();
        }

        private void bankReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmChequeReport frmChequeReport = new FrmChequeReport();
            frmChequeReport.Show();
        }

        private void collectionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDailyCollection frmDailyCollection = new FrmDailyCollection();
            frmDailyCollection.Show();
        }

        private void headwiseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCollectionExpenditureReport frmCollectionExpenditureReport = new FrmCollectionExpenditureReport();
            frmCollectionExpenditureReport.Show();
        }

        private void messageGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGroupCreate frmGroupCreate = new FrmGroupCreate();
            frmGroupCreate.Show();

        }

        private void groupMessageSendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGroupMessage frmGroupMessage = new FrmGroupMessage();
            frmGroupMessage.Show();

        }

        private void monthlyReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMonthlyReport frmMonthlyReport = new FrmMonthlyReport();
            frmMonthlyReport.Show();
        }

        private void subjectGroupEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSubjectGroupMark frmSubjectGroupMark = new FrmSubjectGroupMark();
            frmSubjectGroupMark.Show();
        }

        private void attendanceReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAttendanceReport frmAttendanceReport = new FrmAttendanceReport();
            frmAttendanceReport.Show();
        }

        private void combineResultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCombainExamResult frmCombainExamResult = new FrmCombainExamResult();
            frmCombainExamResult.Show();

        }

        private void dBBackUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmDBBackup frmDBBackup = new FrmDBBackup();
                frmDBBackup.Show();
            }
            catch
            {
            }
        }

        private void studentPromotionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPromotionClassList frmPromotionClassList = new FrmPromotionClassList();
            frmPromotionClassList.Show();
        }

        private void classwiseSubjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmSubjectSeclection frmSubjectSeclection = new FrmSubjectSeclection();
                frmSubjectSeclection.Show();
            }
            catch
            {
            }
        }

        private void classwiseMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmClassWiseMessage frmClassWiseMessage = new FrmClassWiseMessage();
                frmClassWiseMessage.Show();
            }
            catch
            {
            }
        }

        private void othersFeesCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmOthersFeesCollection frmOthersFeesCollection = new FrmOthersFeesCollection();
                frmOthersFeesCollection.Show();
            }
            catch
            {
            }

        }

        private void studentLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmPaymentLegar frmPaymentLegar = new FrmPaymentLegar();
                frmPaymentLegar.Show();
            }
            catch
            {
            }
        }

        private void dueListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmDueList frmDueList = new FrmDueList();
                frmDueList.Show();
            }
            catch
            {
            }
        }

      

       

       
       

 

        




 

      
       
    }
}