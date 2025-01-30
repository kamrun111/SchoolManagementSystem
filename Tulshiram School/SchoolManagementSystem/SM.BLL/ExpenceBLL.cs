using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SchoolManagementSystem.BusinessObjects;
using SchoolManagementSystem.DAL;

namespace SchoolManagementSystem.BLL
{
    public class ExpenceBLL
    {
        private ExpenceDAL _expenceDAL;

        public ExpenceDAL expenceDAL
		{
            get { return _expenceDAL; }
            set { _expenceDAL = value; }
		}

        public ExpenceBLL()
		{
            expenceDAL = new ExpenceDAL();
		}

        public int ExpencessAdd(ExpenceBO expenceBO)
        {
            try
            {
                return expenceDAL.ExpencessAdd(expenceBO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ExpencessUpdate(ExpenceBO expenceBO)
        {
            try
            {
                return expenceDAL.ExpencessUpdate(expenceBO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
