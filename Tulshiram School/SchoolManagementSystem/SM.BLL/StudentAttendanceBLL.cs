using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SchoolManagementSystem.BusinessObjects;
using SchoolManagementSystem.DAL;

namespace SchoolManagementSystem.BLL
{
    public class StudentAttendanceBLL
    {
        private StudentAttendanceDAL _studentAttendanceDAL;

        public StudentAttendanceDAL studentAttendanceDAL
		{
            get { return _studentAttendanceDAL; }
            set { _studentAttendanceDAL = value; }
		}

        public StudentAttendanceBLL()
		{
            studentAttendanceDAL = new StudentAttendanceDAL();
		}
        public int AttendanceUpdate(List<StudentAttendanceBO> listStudentAttendanceBO, List<TeacherAttendanceBO> listTeacherAttendanceBO, List<StuffAttendanceBO> listStuffAttendanceBO)
        {
            try
            {
                return studentAttendanceDAL.AttendanceUpdate(listStudentAttendanceBO, listTeacherAttendanceBO, listStuffAttendanceBO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
