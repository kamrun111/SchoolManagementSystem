using System;
using System.Data;
using SchoolManagementSystem.BusinessObjects;
using SchoolManagementSystem.DAL;

namespace SchoolManagementSystem.BLL
{
    public class FeeCollectionDetailsBLL
    {
        private FeeCollectionDetailsDAL _feeCollectionDetailsDAL;

        public FeeCollectionDetailsDAL feeCollectionDetailsDAL
		{
            get { return _feeCollectionDetailsDAL; }
            set { _feeCollectionDetailsDAL = value; }
		}

        public FeeCollectionDetailsBLL()
		{
            feeCollectionDetailsDAL = new FeeCollectionDetailsDAL();
		}
    }
}
