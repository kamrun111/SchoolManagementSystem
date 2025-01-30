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

namespace SchoolManagementSystem.Forms.Students
{
    public partial class FrmPromotionClassList : BaseForm.FrmBase
    {
        public FrmPromotionClassList()
        {
            InitializeComponent();
        }
        CommonClass cs = new CommonClass();
        private void FrmPromotionClassList_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    DataSet ds = cs.GetDataSet("PromotionClassLoad");
            //    if (ds.Tables[0].Rows.Count > 0)
            //        cs.PopulateComboBox(cmbFromSession, ds, 0, "session", "session_id");
            //    cs.PopulateComboBox(cmbToSession, ds, 1, "session", "session_id");
            //}
            //catch
            //{
            //}
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = cs.GetDataSet("PromotionClassGenerate");
                if (ds.Tables[0].Rows.Count > 0)
                    cs.FillUpListview(lvwStudentInformation, ds, 0);
            }
            catch
            {
            }
        }

        private void btnPromotion_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvwStudentInformation.SelectedItems.Count > 0)
                {
                    FrmStudentPromotion oFrmStudentPromotion = new FrmStudentPromotion(Convert.ToInt32(lvwStudentInformation.SelectedItems[0].Text));
                    oFrmStudentPromotion.ShowDialog();
                    oFrmStudentPromotion.Dispose();
                }
            }
            catch
            {
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
