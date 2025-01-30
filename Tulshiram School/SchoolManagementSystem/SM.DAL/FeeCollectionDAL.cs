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
    public class FeeCollectionDAL
    {
        public FeeCollectionDAL()
        {
        }
        public DataSet FeeCollectionMonthly(int class_id, int payment_catagory_id, string Month)
        {
            try
            {
                SqlParameter[] arParams = new SqlParameter[3];
                arParams[0] = new SqlParameter("@class_id", class_id);
                arParams[1] = new SqlParameter("@payment_catagory_id", payment_catagory_id);
                arParams[2] = new SqlParameter("@Month", Month);
                return DbHelper.GetDataSet(CommandType.StoredProcedure, "FeeCollectionMonthly", arParams);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }
        public DataSet FeeCollectionMonthLoad(int student_id, int session_id)
        {
            try
            {
                SqlParameter[] arParams = new SqlParameter[2];
                arParams[0] = new SqlParameter("@student_id", student_id);
                arParams[1] = new SqlParameter("@session_id", session_id);
                return DbHelper.GetDataSet(CommandType.StoredProcedure, "FeeCollectionMonthLoad", arParams);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }

        public int FeeCollectionInsert(FeeCollectionBO feeCollectionBO, List<FeeCollectionDetailsBO> listFeeCollectionDetailsBO, FeePaymentBO feePaymentBO)
        {
            SqlConnection conn = DbHelper.GetOpenConnection();
            SqlTransaction trans = conn.BeginTransaction();
            int ID = 0;
            try
            {
                ID = FeeCollectionAdd(trans, feeCollectionBO);
                FeeCollectionDetailsAdd(trans, ID, listFeeCollectionDetailsBO);
                FeePaymentAdd(trans,ID, feePaymentBO);
                trans.Commit();
            }
            catch (Exception Ex)
            {
                trans.Rollback();
                throw Ex;
            }
            finally
            {
                conn.Close();
            }
            return ID;
        }

        public int FeeCollectionAdd(SqlTransaction trans, FeeCollectionBO feeCollectionBO)
        {

            SqlParameter[] arParams = new SqlParameter[14];
            int result = 0;
            try
            {
                arParams[0] = new SqlParameter("@student_id", feeCollectionBO.student_id);
                arParams[1] = new SqlParameter("@class_id", feeCollectionBO.class_id);
                arParams[2] = new SqlParameter("@section_id", feeCollectionBO.section_id);
                arParams[3] = new SqlParameter("@session_id", feeCollectionBO.session_id);
                arParams[4] = new SqlParameter("@fine_amount", feeCollectionBO.fine_amount);

                arParams[5] = new SqlParameter("@total_amount", feeCollectionBO.total_amount);
                arParams[6] = new SqlParameter("@paid_amount", feeCollectionBO.paid_amount);
                arParams[7] = new SqlParameter("@balance_amount", feeCollectionBO.balance_amount);
                arParams[8] = new SqlParameter("@payment_type", feeCollectionBO.payment_type);
                arParams[9] = new SqlParameter("@payment_status", feeCollectionBO.payment_status);
            
                arParams[10] = new SqlParameter("@payment_month", feeCollectionBO.payment_month);
                arParams[11] = new SqlParameter("@payment_catagory_id", feeCollectionBO.payment_catagory_id);
                arParams[12] = new SqlParameter("@record_created_by", feeCollectionBO.record_created_by); 
                arParams[13] = new SqlParameter("@fee_collection_id ", feeCollectionBO.fee_collection_id);
                arParams[13].Direction = ParameterDirection.Output;

                SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "FeeCollectionAdd", arParams);
                result = Convert.ToInt32(arParams[13].Value.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }


        private void FeeCollectionDetailsAdd(SqlTransaction trans, int ID, List<FeeCollectionDetailsBO> listFeeCollectionDetailsBO)
        {
            SqlParameter[] arParams = new SqlParameter[5];
            try
            {
                foreach (FeeCollectionDetailsBO element in listFeeCollectionDetailsBO)
                {
                    arParams[0] = new SqlParameter("@fee_collection_id", ID);
                    arParams[1] = new SqlParameter("@fee_name_id", element.fee_name_id);
                    arParams[2] = new SqlParameter("@month_name", element.month_name);
                    arParams[3] = new SqlParameter("@amount", element.amount);
                    arParams[4] = new SqlParameter("@record_created_by", element.record_created_by);

                    SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "FeeCollectionDetailsAdd", arParams);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void FeePaymentAdd(SqlTransaction trans, int ID, FeePaymentBO feePaymentBO)
        {
            SqlParameter[] arParams = new SqlParameter[4];
            try
            {

                    arParams[0] = new SqlParameter("@fee_collection_id", ID);
                    arParams[1] = new SqlParameter("@net_payable", feePaymentBO.net_payable);
                    arParams[2] = new SqlParameter("@fee_paid_amount", feePaymentBO.fee_paid_amount);
                    arParams[3] = new SqlParameter("@record_created_by", feePaymentBO.record_created_by);


                    SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "FeePaymentInsert", arParams);
                
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
                SqlParameter[] arParams = new SqlParameter[2];
                arParams[0] = new SqlParameter("@From", From);
                arParams[1] = new SqlParameter("@To", To);
                return DbHelper.GetDataSet(CommandType.StoredProcedure, "FeeCollectionAll", arParams);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }
        public int FeeCollectionDonation(List<FeeCollectionBO> listFeeCollectionBO)
        {
            SqlConnection conn = DbHelper.GetOpenConnection();
            SqlTransaction trans = conn.BeginTransaction();
            SqlParameter[] arParams = new SqlParameter[2];
            int result = 0;
            try
            {
                foreach (FeeCollectionBO element in listFeeCollectionBO)
                {
                    arParams[0] = new SqlParameter("@fee_collection_id", element.fee_collection_id);
                    arParams[1] = new SqlParameter("@donation_received_by", element.donation_received_by);
                    

                    result = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "FeeCollectionDonation", arParams);
                }
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

        public DataSet FeeCollectionDonationList(DateTime From, DateTime To)
        {
            try
            {
                SqlParameter[] arParams = new SqlParameter[2];
                arParams[0] = new SqlParameter("@From", From);
                arParams[1] = new SqlParameter("@To", To);
                return DbHelper.GetDataSet(CommandType.StoredProcedure, "FeeCollectionDonationList", arParams);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }
    }
}
