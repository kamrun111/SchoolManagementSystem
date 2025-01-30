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
    public class ExpenceDAL
    {
        public ExpenceDAL()
        { }

        public int ExpencessAdd(ExpenceBO expenceBO)
        {
            SqlParameter[] arParams = new SqlParameter[1];
            try
            {
                arParams[0] = new SqlParameter("@expencess", expenceBO.expencess);
               

                return DbHelper.ExecuteNonQuery(CommandType.StoredProcedure, "ExpencessAdd", arParams);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ExpencessUpdate(ExpenceBO expenceBO)
        {
            SqlParameter[] arParams = new SqlParameter[2];
            try
            {
                arParams[0] = new SqlParameter("@expencess_id", expenceBO.expencess_id);
                arParams[1] = new SqlParameter("@expencess", expenceBO.expencess);


                return DbHelper.ExecuteNonQuery(CommandType.StoredProcedure, "ExpencessUpdate", arParams);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
