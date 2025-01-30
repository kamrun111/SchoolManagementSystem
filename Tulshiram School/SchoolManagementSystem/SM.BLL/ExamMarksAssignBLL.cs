using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SchoolManagementSystem.BusinessObjects;
using SchoolManagementSystem.DAL;

namespace SchoolManagementSystem.BLL
{
    public class ExamMarksAssignBLL
    {
        private ExamMarksAssignDAL _examMarksAssignDAL;

        public ExamMarksAssignDAL examMarksAssignDAL
		{
            get { return _examMarksAssignDAL; }
            set { _examMarksAssignDAL = value; }
		}

        public ExamMarksAssignBLL()
		{
            examMarksAssignDAL = new ExamMarksAssignDAL();
		}
        public int ExamMarksAssign(ExamMarksAssignBO ExamMarksAssignBO)
        {
            try
            {
                return examMarksAssignDAL.ExamMarksAssign(ExamMarksAssignBO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet ExamMarksLoad(int exam_id,int class_id,int subject_id,int section_id,int session_id)
        {
            try
            {
                return examMarksAssignDAL.ExamMarksLoad(exam_id, class_id, subject_id, section_id, session_id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet ExamMarksCheck(int exam_id, int class_id, int subject_id)
        {
            try
            {
                return examMarksAssignDAL.ExamMarksCheck(exam_id, class_id, subject_id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int ExamMarksAssignUpdate(ExamMarksAssignBO oExamMarksAssignBO)
        {
            try
            {
                return examMarksAssignDAL.ExamMarksAssignUpdate(oExamMarksAssignBO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet ExamMarkSubjectLoad(int class_id, int session_id)
        {
            try
            {
                return examMarksAssignDAL.ExamMarkSubjectLoad(class_id,session_id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
