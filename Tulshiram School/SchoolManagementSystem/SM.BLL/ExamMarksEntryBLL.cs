using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SchoolManagementSystem.BusinessObjects;
using SchoolManagementSystem.DAL;

namespace SchoolManagementSystem.BLL
{
    public class ExamMarksEntryBLL
    {
        private ExamMarksEntryDAL _examMarksEntryDAL;

        public ExamMarksEntryDAL examMarksEntryDAL
		{
            get { return _examMarksEntryDAL; }
            set { _examMarksEntryDAL = value; }
		}

        public ExamMarksEntryBLL()
		{
            examMarksEntryDAL = new ExamMarksEntryDAL();
		}
        public int ExamMarksEntryAdd(List<ExamMarksEntryBO> listExamMarksEntryBO)
        {
            try
            {
                return examMarksEntryDAL.ExamMarksEntryAdd(listExamMarksEntryBO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int ExamMarksEntryUpdate(List<ExamMarksEntryBO> listExamMarksEntryBO)
        {
            try
            {
                return examMarksEntryDAL.ExamMarksEntryUpdate(listExamMarksEntryBO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet ExamResultLoad1(int session_id,int exam_id, int class_id)
        {
            try
            {
                return examMarksEntryDAL.ExamResultLoad1(session_id, exam_id, class_id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet deleteResult(int session_id, int exam_id, int class_id)
        {
            try
            {
                return examMarksEntryDAL.deleteResult(session_id, exam_id, class_id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
