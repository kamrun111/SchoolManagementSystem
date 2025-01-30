using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using SchoolManagementSystem.BusinessObjects;

namespace SchoolManagementSystem.DAL
{
    public class ExpenditureOrderDAL
    {
        public ExpenditureOrderDAL()
		{
		}
        public int expenditureOrderInsert(ExpenditureOrder expenditureOrder, List<Expenditure> listexpenditure)
        {
            SqlConnection conn = DbHelper.GetOpenConnection();
            SqlTransaction trans = conn.BeginTransaction();
            int expenditureOrderID = 0;

            try
            {
                expenditureOrderID = AddexpenditureAutoID(trans, expenditureOrder);
                ExpenditureAdd(trans, expenditureOrderID, listexpenditure);

                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                expenditureOrderID = -1;
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return expenditureOrderID;
        }
        public int AddexpenditureAutoID(SqlTransaction trans, ExpenditureOrder expenditureOrder)
        {
            int result = 0;
            SqlParameter[] arParams = new SqlParameter[4];
            try
            {
                arParams[0] = new SqlParameter("@expenditure_order_id", expenditureOrder.expenditure_order_id);
                arParams[1] = new SqlParameter("@recordate", expenditureOrder.recordate);
                arParams[2] = new SqlParameter("@record_created_by", expenditureOrder.record_created_by);
                arParams[3] = new SqlParameter("@total_amount", expenditureOrder.total_amount);
                arParams[0].Direction = ParameterDirection.Output;


                SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "AddexpenditureAutoID", arParams);
                result = Convert.ToInt32(arParams[0].Value.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public void ExpenditureAdd(SqlTransaction trans, int expenditureOrderID, List<Expenditure> listexpenditure)
        {
            SqlParameter[] arParams = new SqlParameter[6];
            try
            {
                foreach (Expenditure element in listexpenditure)
                {
                    arParams[0] = new SqlParameter("@expencess_id", element.expencess_id);
                    arParams[1] = new SqlParameter("@amount", element.amount);
                    arParams[2] = new SqlParameter("@remarks", element.remarks);
                    arParams[3] = new SqlParameter("@recordate", element.recordate);
                    arParams[4] = new SqlParameter("@record_created_by", element.record_created_by);
                    arParams[5] = new SqlParameter("@expenditure_order_id", expenditureOrderID);


                    SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "ExpenditureAdd", arParams);
                }
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
                SqlParameter[] arParams = new SqlParameter[2];
                arParams[0] = new SqlParameter("@From", From);
                arParams[1] = new SqlParameter("@To", To);
                return DbHelper.GetDataSet(CommandType.StoredProcedure, "ExpenditureOrderList", arParams);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }
        public DataSet Collection(DateTime From, DateTime To)
        {
            try
            {
                SqlParameter[] arParams = new SqlParameter[2];
                arParams[0] = new SqlParameter("@From", From);
                arParams[1] = new SqlParameter("@To", To);
                return DbHelper.GetDataSet(CommandType.StoredProcedure, "Collection", arParams);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }
        public DataSet Balance(DateTime From, DateTime To)
        {
            try
            {
                SqlParameter[] arParams = new SqlParameter[2];
                arParams[0] = new SqlParameter("@Fromb", From);
                arParams[1] = new SqlParameter("@Tob", To);
                return DbHelper.GetDataSet(CommandType.StoredProcedure, "Balance", arParams);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }
        public int expenditureOrderUpdate(ExpenditureOrder expenditureOrder, List<Expenditure> listexpenditure)
        {
            SqlConnection conn = DbHelper.GetOpenConnection();
            SqlTransaction trans = conn.BeginTransaction();
            int result= 0;

            try
            {
                result = ExpenditureUpdate(trans, listexpenditure);
                ExpenditureOrderUpdate(trans, expenditureOrder);

                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                result = -1;
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }
        public void ExpenditureOrderUpdate(SqlTransaction trans, ExpenditureOrder expenditureOrder)
        {

            SqlParameter[] arParams = new SqlParameter[3];
            try
            {
                arParams[0] = new SqlParameter("@expenditure_order_id", expenditureOrder.expenditure_order_id);
                arParams[1] = new SqlParameter("@total_amount", expenditureOrder.total_amount);
                arParams[2] = new SqlParameter("@record_modified_by", expenditureOrder.record_modified_by);
                SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "ExpenditureOrderUpdate", arParams);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int ExpenditureUpdate(SqlTransaction trans, List<Expenditure> listexpenditure)
        {

            SqlParameter[] arParams = new SqlParameter[4];
            int result = 0;
            try
            {
                foreach (Expenditure element in listexpenditure)
                {
                    arParams[0] = new SqlParameter("@expenditure_id", element.expenditure_id);
                    arParams[1] = new SqlParameter("@amount", element.amount);
                    arParams[2] = new SqlParameter("@remarks", element.remarks);
                    arParams[3] = new SqlParameter("@record_modified_by", element.record_modified_by);
                    result = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "ExpenditureUpdate", arParams);

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}
