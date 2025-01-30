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
   public  class ClassWiseSubjectDAL
    {
       public ClassWiseSubjectDAL()
       {
       }
       public int ClassWiseSubjectAdd(List<ClassWiseSubjectBO> listClassWiseSubjectBO)
       {
           SqlConnection conn = DbHelper.GetOpenConnection();
           SqlTransaction trans = conn.BeginTransaction();
           SqlParameter[] arParams = new SqlParameter[5];
           int result = 0;
           try
           {
               foreach (ClassWiseSubjectBO element in listClassWiseSubjectBO)
               {
                   arParams[0] = new SqlParameter("@shift_id", element.shift_id);
                   arParams[1] = new SqlParameter("@class_id", element.class_id);
                   arParams[2] = new SqlParameter("@subject_id", element.subject_id);
                   arParams[3] = new SqlParameter("@status", element.status);
                   arParams[4] = new SqlParameter("@record_created_by", element.record_created_by);


                   result = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "ClassWiseSubjectAdd", arParams);
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
    }
}
