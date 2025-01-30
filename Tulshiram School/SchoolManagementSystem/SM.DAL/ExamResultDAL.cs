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
    public class ExamResultDAL
    {
        public ExamResultDAL()
        {
        }
        public int ExamResultSave(List<ExamResultBO> listExamResultBO)
        {
            SqlConnection conn = DbHelper.GetOpenConnection();
            SqlTransaction trans = conn.BeginTransaction();
            SqlParameter[] arParams = new SqlParameter[16];
            int result = 0;
            try
            {
                foreach (ExamResultBO element in listExamResultBO)
                {
                    arParams[0] = new SqlParameter("@exam_id", element.exam_id);
                    arParams[1] = new SqlParameter("@session_id", element.session_id);
                    arParams[2] = new SqlParameter("@shift_id", element.shift_id);
                    arParams[3] = new SqlParameter("@class_id", element.class_id);
                    arParams[4] = new SqlParameter("@section_id", element.section_id);
                    arParams[5] = new SqlParameter("@student_id", element.student_id);
                    arParams[6] = new SqlParameter("@total_no", element.total_no);
                    arParams[7] = new SqlParameter("@grade", element.grade);

                    arParams[8] = new SqlParameter("@gpa", element.gpa);
                    arParams[9] = new SqlParameter("@place", element.place);
                    arParams[10] = new SqlParameter("@total_present", element.total_present);
                    arParams[11] = new SqlParameter("@total_absent", element.total_absent);
                    arParams[12] = new SqlParameter("@remarks", element.remarks);
                    arParams[13] = new SqlParameter("@record_created_by", element.record_created_by);
                    arParams[14] = new SqlParameter("@place_in_section", element.place_in_section);
                    arParams[15] = new SqlParameter("@roll_no", element.roll_no);

                    result = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "ExamResultSave", arParams);
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


        public DataSet ExamResultGrid(int session_id, int exam_id, int shif_id, int class_id, int section_id)
        {
            try
            {
                SqlParameter[] arParams = new SqlParameter[5];

                arParams[0] = new SqlParameter("@session_id", session_id);
                arParams[1] = new SqlParameter("@exam_id", exam_id);
                arParams[2] = new SqlParameter("@shift_id", shif_id);
                arParams[3] = new SqlParameter("@class_id", class_id);
                arParams[4] = new SqlParameter("@section_id", section_id);
                return DbHelper.GetDataSet(CommandType.StoredProcedure, "ExamResultGrid", arParams);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }

        public DataSet CombineResultCheck(int session_id, int shif_id,int class_id)
        {
            try
            {
                SqlParameter[] arParams = new SqlParameter[3];

                arParams[0] = new SqlParameter("@session_id", session_id);
                arParams[1] = new SqlParameter("@shift_id", shif_id);
                arParams[2] = new SqlParameter("@class_id", class_id);

                return DbHelper.GetDataSet(CommandType.StoredProcedure, "CombineResultCheck", arParams);
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
