using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SchoolManagementSystem.BusinessObjects;
using SchoolManagementSystem.DAL;

namespace SchoolManagementSystem.BLL
{
    public class StudentBLL
    {
        private StudentDAL _studentDAL;

        public StudentDAL studentDAL
		{
            get { return _studentDAL; }
            set { _studentDAL = value; }
		}

        public StudentBLL()
		{
			studentDAL = new StudentDAL();
		}

        public DataSet StudentComboLoad()
        {
            try
            {
                return studentDAL.StudentComboLoad();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int StudentAdd(StudentBO oStudentBO)
        {
            try
            {
                return studentDAL.StudentAdd(oStudentBO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet StudentSectionLoad(int class_id)
        {
            try
            {
                return studentDAL.StudentSectionLoad(class_id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet StudentSearchName(string name,int flag)
        {
            try
            {
                return studentDAL.StudentSearchName(name,flag);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet StudentListLoad(int class_id, int section_id)
        {
            try
            {
                return studentDAL.StudentListLoad(class_id, section_id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet StudentDueList(int class_id, int section_id, int shift_id, string Month)
        {
            try
            {
                return studentDAL.StudentDueList(class_id, section_id, shift_id, Month);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int StudentUpdate(StudentBO oStudentBO)
        {
            try
            {
                return studentDAL.StudentUpdate(oStudentBO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int StudentImageUpdate(StudentBO oStudentBO)
        {
            try
            {
                return studentDAL.StudentImageUpdate(oStudentBO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int StudentPromotionAdd(List<StudentBO> listStudentBO)
        {
            try
            {
                return studentDAL.StudentPromotionAdd(listStudentBO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
