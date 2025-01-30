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
    public class ExamMarksAssignDAL
    {
        public ExamMarksAssignDAL()
        {
        }
        public int ExamMarksAssign(ExamMarksAssignBO oExamMarksAssignBO)
        {
            SqlParameter[] arParams = new SqlParameter[14];
            try
            {
                arParams[0] = new SqlParameter("@exam_id", oExamMarksAssignBO.exam_id);
                arParams[1] = new SqlParameter("@class_id", oExamMarksAssignBO.class_id);
                arParams[2] = new SqlParameter("@subject_id", oExamMarksAssignBO.subject_id);

                arParams[3] = new SqlParameter("@exam_total_marks", oExamMarksAssignBO.exam_total_marks);
                arParams[4] = new SqlParameter("@theory_marks", oExamMarksAssignBO.theory_marks);
                arParams[5] = new SqlParameter("@theory_pass_marks", oExamMarksAssignBO.theory_pass_marks);

                arParams[6] = new SqlParameter("@objective_marks", oExamMarksAssignBO.objective_marks);
                arParams[7] = new SqlParameter("@objective_pass_marks", oExamMarksAssignBO.objective_pass_marks);
                arParams[8] = new SqlParameter("@practical_marks", oExamMarksAssignBO.practical_marks);

                arParams[9] = new SqlParameter("@practical_pass_marks", oExamMarksAssignBO.practical_pass_marks);
                arParams[10] = new SqlParameter("@result_marks", oExamMarksAssignBO.result_marks);
                arParams[11] = new SqlParameter("@class_test_marks", oExamMarksAssignBO.class_test_marks);

                arParams[12] = new SqlParameter("@class_test_pass_marks", oExamMarksAssignBO.class_test_pass_marks);
                arParams[13] = new SqlParameter("@record_created_by", oExamMarksAssignBO.record_created_by);

                return DbHelper.ExecuteNonQuery(CommandType.StoredProcedure, "ExamMarksAssign", arParams);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet ExamMarksLoad(int exam_id, int class_id, int subject_id, int section_id, int session_id)
        {
            try
            {
                SqlParameter[] arParams = new SqlParameter[5];
                arParams[0] = new SqlParameter("@exam_id", exam_id);
                arParams[1] = new SqlParameter("@class_id", class_id);
                arParams[2] = new SqlParameter("@subject_id", subject_id);
                arParams[3] = new SqlParameter("@section_id", section_id);
                arParams[4] = new SqlParameter("@session_id", session_id);
                return DbHelper.GetDataSet(CommandType.StoredProcedure, "ExamMarksLoad", arParams);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }
        public DataSet ExamMarksCheck(int exam_id, int class_id, int subject_id)
        {
            try
            {
                SqlParameter[] arParams = new SqlParameter[3];
                arParams[0] = new SqlParameter("@exam_id", exam_id);
                arParams[1] = new SqlParameter("@class_id", class_id);
                arParams[2] = new SqlParameter("@subject_id", subject_id);
                return DbHelper.GetDataSet(CommandType.StoredProcedure, "ExamMarksCheck", arParams);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }
        public DataSet ExamMarkSubjectLoad( int class_id,int session_id)
        {
            try
            {
                SqlParameter[] arParams = new SqlParameter[2];
                arParams[0] = new SqlParameter("@class_id", class_id);
                arParams[1] = new SqlParameter("@session_id", session_id);
                return DbHelper.GetDataSet(CommandType.StoredProcedure, "ExamMarkSubjectLoad", arParams);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }
        public int ExamMarksAssignUpdate(ExamMarksAssignBO oExamMarksAssignBO)
        {

            SqlParameter[] arParams = new SqlParameter[15];
            try
            {
                arParams[0] = new SqlParameter("@exam_marks_assign_id", oExamMarksAssignBO.exam_marks_assign_id);
                arParams[1] = new SqlParameter("@exam_id", oExamMarksAssignBO.exam_id);
                arParams[2] = new SqlParameter("@class_id", oExamMarksAssignBO.class_id);
                arParams[3] = new SqlParameter("@subject_id", oExamMarksAssignBO.subject_id);


                arParams[4] = new SqlParameter("@exam_total_marks", oExamMarksAssignBO.exam_total_marks);
                arParams[5] = new SqlParameter("@theory_marks", oExamMarksAssignBO.theory_marks);
                arParams[6] = new SqlParameter("@theory_pass_marks", oExamMarksAssignBO.theory_pass_marks);
                arParams[7] = new SqlParameter("@objective_marks", oExamMarksAssignBO.objective_marks);

                arParams[8] = new SqlParameter("@objective_pass_marks", oExamMarksAssignBO.objective_pass_marks);
                arParams[9] = new SqlParameter("@practical_marks", oExamMarksAssignBO.practical_marks);
                arParams[10] = new SqlParameter("@practical_pass_marks", oExamMarksAssignBO.practical_pass_marks);
                arParams[11] = new SqlParameter("@result_marks", oExamMarksAssignBO.result_marks);

                arParams[12] = new SqlParameter("@class_test_marks", oExamMarksAssignBO.class_test_marks);
                arParams[13] = new SqlParameter("@class_test_pass_marks", oExamMarksAssignBO.class_test_pass_marks);
                arParams[14] = new SqlParameter("@record_modified_by", oExamMarksAssignBO.record_modified_by);



                return DbHelper.ExecuteNonQuery(CommandType.StoredProcedure, "ExamMarksAssignUpdate", arParams);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



                
                
    }
}
