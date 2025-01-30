using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SchoolManagementSystem.BusinessObjects;
using SchoolManagementSystem.DAL;
namespace SchoolManagementSystem.BLL
{
    public class AssignClassBLL
    {
        private AssignClassDAL _assignClassDAL;

		public AssignClassDAL assignClassDAL
		{
			get { return _assignClassDAL; }
			set { _assignClassDAL = value; }
		}

        public AssignClassBLL()
		{
			assignClassDAL = new AssignClassDAL();
		}

        public DataSet StudentAttendanceLoad(int class_id, int section_id)
        {
            try
            {
                return assignClassDAL.StudentAttendanceLoad(class_id, section_id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
