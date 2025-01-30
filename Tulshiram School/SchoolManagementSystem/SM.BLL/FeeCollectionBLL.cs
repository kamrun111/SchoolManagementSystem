using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SchoolManagementSystem.BusinessObjects;
using SchoolManagementSystem.DAL;

namespace SchoolManagementSystem.BLL
{
    public class FeeCollectionBLL
    {
        private FeeCollectionDAL _feeCollectionDAL;

        public FeeCollectionDAL feeCollectionDAL
		{
            get { return _feeCollectionDAL; }
            set { _feeCollectionDAL = value; }
		}

        public FeeCollectionBLL()
		{
            feeCollectionDAL = new FeeCollectionDAL();
		}
        public DataSet FeeCollectionMonthly(int class_id, int payment_catagory_id,string Month)
        {
            try
            {
                return feeCollectionDAL.FeeCollectionMonthly(class_id, payment_catagory_id, Month);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet FeeCollectionMonthLoad(int student_id, int session_id)
        {
            try
            {
                return feeCollectionDAL.FeeCollectionMonthLoad(student_id, session_id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int FeeCollectionInsert(FeeCollectionBO feeCollectionBO, List<FeeCollectionDetailsBO> listFeeCollectionDetailsBO, FeePaymentBO feePaymentBO)
        {
            try
            {
                return feeCollectionDAL.FeeCollectionInsert(feeCollectionBO, listFeeCollectionDetailsBO, feePaymentBO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet FeeCollectionAll(DateTime From, DateTime To)
        {
            try
            {
                return feeCollectionDAL.FeeCollectionAll(From, To);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int FeeCollectionDonation(List<FeeCollectionBO> listFeeCollectionBO)
        {
            try
            {
                return feeCollectionDAL.FeeCollectionDonation(listFeeCollectionBO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet FeeCollectionDonationList(DateTime From, DateTime To)
        {
            try
            {
                return feeCollectionDAL.FeeCollectionDonationList(From, To);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
