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
    public class SubjectDAL
    {
        public SubjectDAL()
        { }

        public int SubjectADD(SubjectBO subjectBO)
        {
            SqlParameter[] arParams = new SqlParameter[4];
            try
            {
                arParams[0] = new SqlParameter("@subject", subjectBO.subject);
                arParams[1] = new SqlParameter("@subject_code", subjectBO.subject_code);
                arParams[2] = new SqlParameter("@is_main", subjectBO.is_main);
                arParams[3] = new SqlParameter("@record_created_by", subjectBO.record_created_by);


                return DbHelper.ExecuteNonQuery(CommandType.StoredProcedure, "SubjectADD", arParams);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int SubjectUpdate(SubjectBO subjectBO)
        {
            SqlParameter[] arParams = new SqlParameter[5];
            try
            {
                arParams[0] = new SqlParameter("@subject", subjectBO.subject);
                arParams[1] = new SqlParameter("@subject_code", subjectBO.subject_code);
                arParams[2] = new SqlParameter("@is_main", subjectBO.is_main);
                arParams[3] = new SqlParameter("@record_modified_by", subjectBO.record_modified_by);
                arParams[4] = new SqlParameter("@subject_id", subjectBO.subject_id);


                return DbHelper.ExecuteNonQuery(CommandType.StoredProcedure, "SubjectUpdate", arParams);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
