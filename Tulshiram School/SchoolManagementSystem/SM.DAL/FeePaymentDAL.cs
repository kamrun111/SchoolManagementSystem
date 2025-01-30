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
    public class FeePaymentDAL
    {
        public FeePaymentDAL()
        {
        }
        public int FeePaymentAdd(FeePaymentBO feePaymentBO)
        {
            SqlParameter[] arParams = new SqlParameter[5];
            SqlConnection conn = DbHelper.GetOpenConnection();
            int result = 0;
            try
            {
                arParams[0] = new SqlParameter("@fee_collection_id", feePaymentBO.fee_collection_id);
                arParams[1] = new SqlParameter("@net_payable", feePaymentBO.net_payable);
                arParams[2] = new SqlParameter("@fee_paid_amount", feePaymentBO.fee_paid_amount);
                arParams[3] = new SqlParameter("@record_created_by", feePaymentBO.record_created_by);
                arParams[4] = new SqlParameter("@fee_payment_id", feePaymentBO.fee_payment_id);
                arParams[4].Direction = ParameterDirection.Output;

                SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, "FeePaymentAdd", arParams);
                result = Convert.ToInt32(arParams[4].Value.ToString());


            }
            catch (Exception ex)
            {
                result = -1;
                throw ex;
            }
            finally
            {
                DbHelper.CloseConnection(conn);
            }
            return result;
        }
    }
}
