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
    public class ExamCombineResultDAL
    {
        public ExamCombineResultDAL()
        {
        }
        public DataSet ExamResultCombineLoad(int session_id, int shift_id, int class_id)
        {
            try
            {
                SqlParameter[] arParams = new SqlParameter[3];
                arParams[0] = new SqlParameter("@session_id", session_id);
                arParams[1] = new SqlParameter("@shift_id", shift_id);
                arParams[2] = new SqlParameter("@class_id", class_id);
                return DbHelper.GetDataSet(CommandType.StoredProcedure, "ExamResultCombineLoad", arParams);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }

        public int ExamCombineResultSave(List<ExamCombineResultBO> listExamCombineResultBO)
        {
            SqlConnection conn = DbHelper.GetOpenConnection();
            SqlTransaction trans = conn.BeginTransaction();
            SqlParameter[] arParams = new SqlParameter[15];
            int result = 0;
            try
            {
                foreach (ExamCombineResultBO element in listExamCombineResultBO)
                {
                    arParams[0] = new SqlParameter("@session_id", element.session_id);
                    arParams[1] = new SqlParameter("@shift_id", element.shift_id);
                    arParams[2] = new SqlParameter("@class_id", element.class_id);
                    arParams[3] = new SqlParameter("@section_id", element.section_id);
                    arParams[4] = new SqlParameter("@student_id", element.student_id);
                    arParams[5] = new SqlParameter("@grade", element.grade);

                    arParams[6] = new SqlParameter("@gpa", element.gpa);
                    arParams[7] = new SqlParameter("@place", element.place);
                    arParams[8] = new SqlParameter("@total_present", element.total_present);
                    arParams[9] = new SqlParameter("@total_absent", element.total_absent);
                    arParams[10] = new SqlParameter("@remarks", element.remarks);
                    arParams[11] = new SqlParameter("@record_created_by", element.record_created_by);
                    arParams[12] = new SqlParameter("@place_in_section", element.place_in_section);
                    arParams[13] = new SqlParameter("@roll_no", element.roll_no); 
                    arParams[14] = new SqlParameter("@total_marks", element.total_marks);

                    result = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "ExamCombineResultSave", arParams);
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
            return result;//


        }
        public DataSet deleteCombineResult(int session_id, int shift_id, int class_id)
        {
            try
            {
                SqlParameter[] arParams = new SqlParameter[3];
                arParams[0] = new SqlParameter("@session_id", session_id);
                arParams[1] = new SqlParameter("@shift_id", shift_id);
                arParams[2] = new SqlParameter("@class_id", class_id);
                return DbHelper.GetDataSet(CommandType.StoredProcedure, "deleteCombineResult", arParams);
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
