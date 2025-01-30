using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SchoolManagementSystem.BusinessObjects;
using SchoolManagementSystem.DAL;

namespace SchoolManagementSystem.BLL
{
    public class ExamResultBLL
    {
        private ExamResultDAL _examResultDAL;

        public ExamResultDAL examResultDAL
		{
            get { return _examResultDAL; }
            set { _examResultDAL = value; }
		}

        public ExamResultBLL()
		{
            examResultDAL = new ExamResultDAL();
		}
        public int ExamResultSave(List<ExamResultBO> listExamResultBO)
        {
            try
            {
                return examResultDAL.ExamResultSave(listExamResultBO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet ExamResultGrid(int session_id,int exam_id,int shif_id,int class_id,int section_id)
        {
            try
            {
                return examResultDAL.ExamResultGrid(session_id, exam_id, shif_id, class_id, section_id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
