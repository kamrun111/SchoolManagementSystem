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
    public class ExamMarksEntryDAL
    {
        public ExamMarksEntryDAL()
        {
        }
        public int ExamMarksEntryAdd(List<ExamMarksEntryBO> listExamMarksEntryBO)
        {
            SqlConnection conn = DbHelper.GetOpenConnection();
            SqlTransaction trans = conn.BeginTransaction();
            SqlParameter[] arParams = new SqlParameter[24];
            int result = 0;
            try
            {
                foreach (ExamMarksEntryBO element in listExamMarksEntryBO)
                {
                    arParams[0] = new SqlParameter("@exam_marks_assign_id", element.exam_marks_assign_id);
                    arParams[1] = new SqlParameter("@exam_id", element.exam_id);
                    arParams[2] = new SqlParameter("@session_id", element.session_id);
                    arParams[3] = new SqlParameter("@shift_id", element.shift_id);
                    arParams[4] = new SqlParameter("@class_id", element.class_id);
                    arParams[5] = new SqlParameter("@section_id", element.section_id);
                    arParams[6] = new SqlParameter("@student_id", element.student_id);
                    arParams[7] = new SqlParameter("@subject_id", element.subject_id);
                    arParams[8] = new SqlParameter("@theory", element.theory);

                    arParams[9] = new SqlParameter("@objective", element.objective);
                    arParams[10] = new SqlParameter("@practical", element.practical);
                    arParams[11] = new SqlParameter("@exam_total", element.exam_total);
                    arParams[12] = new SqlParameter("@result_total", element.result_total);
                    arParams[13] = new SqlParameter("@result_obtain_total", element.result_obtain_total);
                    arParams[14] = new SqlParameter("@class_test_total", element.class_test_total);
                    arParams[15] = new SqlParameter("@class_test_obtain_total", element.class_test_obtain_total);
                    arParams[16] = new SqlParameter("@grade", element.grade);
                    arParams[17] = new SqlParameter("@gpa", element.gpa);
                    arParams[18] = new SqlParameter("@status", element.status);
                    arParams[19] = new SqlParameter("@subject_status_id", element.subject_status_id);
                    arParams[20] = new SqlParameter("@record_created_by", element.record_created_by);
                    arParams[21] = new SqlParameter("@percentage", element.percentage); 
                    arParams[22] = new SqlParameter("@subject_group_id", element.subject_group_id);
                    arParams[23] = new SqlParameter("@grand_total", element.grand_total); 

                    result = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "ExamMarksEntryAdd", arParams);
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

        public int ExamMarksEntryUpdate(List<ExamMarksEntryBO> listExamMarksEntryBO)
        {
            SqlConnection conn = DbHelper.GetOpenConnection();
            SqlTransaction trans = conn.BeginTransaction();
            SqlParameter[] arParams = new SqlParameter[21];
            int result = 0;
            try
            {
                foreach (ExamMarksEntryBO element in listExamMarksEntryBO)
                {
                    arParams[0] = new SqlParameter("@exam_marks_entry_id", element.exam_marks_entry_id);
                    arParams[1] = new SqlParameter("@theory", element.theory);
                    arParams[2] = new SqlParameter("@objective", element.objective);
                    arParams[3] = new SqlParameter("@practical", element.practical);
                    arParams[4] = new SqlParameter("@exam_total", element.exam_total);
                    arParams[5] = new SqlParameter("@result_total", element.result_total);
                    arParams[6] = new SqlParameter("@result_obtain_total", element.result_obtain_total);
                    arParams[7] = new SqlParameter("@class_test_obtain_total", element.class_test_obtain_total);
                    arParams[8] = new SqlParameter("@percentage", element.percentage);
                    arParams[9] = new SqlParameter("@grade", element.grade);
                    arParams[10] = new SqlParameter("@gpa", element.gpa);
                    arParams[11] = new SqlParameter("@record_modified_by", element.record_modified_by);
                    arParams[12] = new SqlParameter("@subject_group_id", element.subject_group_id);


                    arParams[13] = new SqlParameter("@session_id", element.session_id);
                    arParams[14] = new SqlParameter("@exam_id", element.exam_id);
                    arParams[15] = new SqlParameter("@shift_id", element.shift_id);
                    arParams[16] = new SqlParameter("@class_id", element.class_id);
                    arParams[17] = new SqlParameter("@section_id", element.section_id);
                    arParams[18]= new SqlParameter("@subject_id", element.subject_id);
                    arParams[19] = new SqlParameter("@student_id", element.student_id);
                    arParams[20] = new SqlParameter("@grand_total", element.grand_total);

                    result = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "ExamMarksEntryUpdate", arParams);
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

        public DataSet ExamResultLoad1(int session_id,int exam_id, int class_id)
        {
            try
            {
                SqlParameter[] arParams = new SqlParameter[3];
                arParams[0] = new SqlParameter("@session_id", session_id);
                arParams[1] = new SqlParameter("@exam_id", exam_id);
                arParams[2] = new SqlParameter("@class_id", class_id);
                return DbHelper.GetDataSet(CommandType.StoredProcedure, "ExamResultLoad1", arParams);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }
        public DataSet deleteResult(int session_id, int exam_id, int class_id)
        {
            try
            {
                SqlParameter[] arParams = new SqlParameter[3];
                arParams[0] = new SqlParameter("@session_id", session_id);
                arParams[1] = new SqlParameter("@exam_id", exam_id);
                arParams[2] = new SqlParameter("@class_id", class_id);
                return DbHelper.GetDataSet(CommandType.StoredProcedure, "deleteResult", arParams);
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
