using System;
using System.Data;
using SchoolManagementSystem.BusinessObjects;
using SchoolManagementSystem.DAL;

namespace SchoolManagementSystem.BLL
{
    public class StudentAdmissionBLL
    {
        private StudentAdmissionDAL _studentAdmissionDAL;

        public StudentAdmissionDAL studentAdmissionDAL
		{
            get { return _studentAdmissionDAL; }
            set { _studentAdmissionDAL = value; }
		}

        public StudentAdmissionBLL()
		{
            studentAdmissionDAL = new StudentAdmissionDAL();
		}
        public int StudentAdmissionAdd(StudentAdmissionBO oStudentAdmissionBO)
        {
            try
            {
                return studentAdmissionDAL.StudentAdmissionAdd(oStudentAdmissionBO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet StudentAdmissionSearch(string name, int class_id)
        {
            try
            {
                return studentAdmissionDAL.StudentAdmissionSearch(name, class_id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
