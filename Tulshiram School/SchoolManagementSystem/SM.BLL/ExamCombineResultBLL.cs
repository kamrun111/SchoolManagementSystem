using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SchoolManagementSystem.BusinessObjects;
using SchoolManagementSystem.DAL;


namespace SchoolManagementSystem.BLL
{
    public class ExamCombineResultBLL
    {
        private ExamCombineResultDAL _examCombineResultDAL;

        public ExamCombineResultDAL examCombineResultDAL
		{
            get { return _examCombineResultDAL; }
            set { _examCombineResultDAL = value; }
		}

        public ExamCombineResultBLL()
		{
            examCombineResultDAL = new ExamCombineResultDAL();
		}
        public DataSet ExamResultCombineLoad(int session_id, int shift_id, int class_id)
        {
            try
            {
                return examCombineResultDAL.ExamResultCombineLoad(session_id, shift_id, class_id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int ExamCombineResultSave(List<ExamCombineResultBO> listExamCombineResultBO)
        {
            try
            {
                return examCombineResultDAL.ExamCombineResultSave(listExamCombineResultBO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet deleteCombineResult(int session_id, int shift_id, int class_id)
        {
            try
            {
                return examCombineResultDAL.deleteCombineResult(session_id, shift_id, class_id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
