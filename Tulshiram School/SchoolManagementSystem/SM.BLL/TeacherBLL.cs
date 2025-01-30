using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SchoolManagementSystem.BusinessObjects;
using SchoolManagementSystem.DAL;

namespace SchoolManagementSystem.BLL
{
    public class TeacherBLL
    {
        private TeacherDAL _teacherDAL;

        public TeacherDAL teacherDAL
		{
            get { return _teacherDAL; }
            set { _teacherDAL = value; }
		}

        public TeacherBLL()
		{
            teacherDAL = new TeacherDAL();
		}
        public int TeacherAdd(TeacherBO teacherBO)
        {
            try
            {
                return teacherDAL.TeacherAdd(teacherBO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int TeacherUpdate(TeacherBO teacherBO)
        {
            try
            {
                return teacherDAL.TeacherUpdate(teacherBO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
