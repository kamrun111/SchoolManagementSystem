using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SchoolManagementSystem.BusinessObjects;
using SchoolManagementSystem.DAL;

namespace SchoolManagementSystem.BLL
{
	public class ExpenditureBLL
	{
        private ExpenditureDAL _expenditureDAL;

        public ExpenditureDAL expenditureDAL
		{
            get { return _expenditureDAL; }
            set { _expenditureDAL = value; }
		}

        public ExpenditureBLL()
		{
            expenditureDAL = new ExpenditureDAL();
		}
        public int expenditureadd(List<Expenditure> listExpenditure)
        {
            try
            {
                return expenditureDAL.expenditureadd(listExpenditure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
	}
}
