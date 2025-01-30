using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SchoolManagementSystem.BusinessObjects;
using SchoolManagementSystem.DAL;

namespace SchoolManagementSystem.BLL
{
    public class StuffAttendanceBLL
    {
        private StuffAttendanceDAL _stuffAttendanceDAL;

        public StuffAttendanceDAL stuffAttendanceDAL
		{
            get { return _stuffAttendanceDAL; }
            set { _stuffAttendanceDAL = value; }
		}

        public StuffAttendanceBLL()
		{
            stuffAttendanceDAL = new StuffAttendanceDAL();
		}
    }
}
