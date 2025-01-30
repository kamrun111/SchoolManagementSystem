using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SchoolManagementSystem.BusinessObjects;
using SchoolManagementSystem.DAL;

namespace SchoolManagementSystem.BLL
{
    public class ExpenditureOrderBLL
    {
        private ExpenditureOrderDAL _expenditureOrderDAL;

        public ExpenditureOrderDAL expenditureOrderDAL
        {
            get { return _expenditureOrderDAL; }
            set { _expenditureOrderDAL = value; }
        }
        public ExpenditureOrderBLL()
        {
            expenditureOrderDAL = new ExpenditureOrderDAL();
        }

        public int expenditureOrderInsert(ExpenditureOrder expenditureOrder, List<Expenditure> listexpenditure)
        {
            try
            {
                return expenditureOrderDAL.expenditureOrderInsert(expenditureOrder, listexpenditure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int expenditureOrderUpdate(ExpenditureOrder expenditureOrder, List<Expenditure> listexpenditure)
        {
            try
            {
                return expenditureOrderDAL.expenditureOrderUpdate(expenditureOrder, listexpenditure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet ExpenditureOrderList(DateTime From, DateTime To)
        {
            try
            {
                return expenditureOrderDAL.ExpenditureOrderList(From, To);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Collection(DateTime From, DateTime To)
        {
            try
            {
                return expenditureOrderDAL.Collection(From, To);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Balance(DateTime From, DateTime To)
        {
            try
            {
                return expenditureOrderDAL.Balance(From, To);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
