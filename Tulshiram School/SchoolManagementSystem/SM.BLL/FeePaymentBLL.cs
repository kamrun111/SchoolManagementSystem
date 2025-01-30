using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SchoolManagementSystem.BusinessObjects;
using SchoolManagementSystem.DAL;

namespace SchoolManagementSystem.BLL
{
    public class FeePaymentBLL
    {
        private FeePaymentDAL _feePaymentDAL;

        public FeePaymentDAL feePaymentDAL
		{
            get { return _feePaymentDAL; }
            set { _feePaymentDAL = value; }
		}

        public FeePaymentBLL()
		{
            feePaymentDAL = new FeePaymentDAL();
		}
        public int FeePaymentAdd(FeePaymentBO feePaymentBO)
        {
            try
            {
                return feePaymentDAL.FeePaymentAdd(feePaymentBO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
