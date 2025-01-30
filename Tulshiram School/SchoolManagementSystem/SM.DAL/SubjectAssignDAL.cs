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
    public class SubjectAssignDAL
    {
        public SubjectAssignDAL()
        {
        }
        public int SubjectAssignAdd(List<SubjectAssignBO> listSubjectAssignBO)
        {
            SqlConnection conn = DbHelper.GetOpenConnection();
            SqlTransaction trans = conn.BeginTransaction();
            SqlParameter[] arParams = new SqlParameter[9];
            int result = 0;
            try
            {
                foreach (SubjectAssignBO element in listSubjectAssignBO)
                {
                    arParams[0] = new SqlParameter("@shift_id", element.shift_id);
                    arParams[1] = new SqlParameter("@class_id", element.class_id);
                    arParams[2] = new SqlParameter("@section_id", element.section_id);
                    arParams[3] = new SqlParameter("@session_id", element.session_id);
                    arParams[4] = new SqlParameter("@student_id", element.student_id);
                    arParams[5] = new SqlParameter("@subject_id", element.subject_id);
                    arParams[6] = new SqlParameter("@assign", element.assign);
                    arParams[7] = new SqlParameter("@is_main", element.is_main);
                    arParams[8] = new SqlParameter("@record_created_by", element.record_created_by);


                    result = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "SubjectAssignAdd", arParams);
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
