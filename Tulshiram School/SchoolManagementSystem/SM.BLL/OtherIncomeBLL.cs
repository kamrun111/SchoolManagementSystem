using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SchoolManagementSystem.BusinessObjects;
using SchoolManagementSystem.DAL;

namespace SchoolManagementSystem.BLL
{
    public class OtherIncomeBLL
    {
        private OtherIncomeDAL _otherIncomeDAL;

        public OtherIncomeDAL otherIncomeDAL
		{
            get { return _otherIncomeDAL; }
            set { _otherIncomeDAL = value; }
		}

        public OtherIncomeBLL()
		{
            otherIncomeDAL = new OtherIncomeDAL();
		}
        public int OtherIncomeAdd(OtherIncomeBO otherIncomeBO)
        {
            try
            {
                return otherIncomeDAL.OtherIncomeAdd(otherIncomeBO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
