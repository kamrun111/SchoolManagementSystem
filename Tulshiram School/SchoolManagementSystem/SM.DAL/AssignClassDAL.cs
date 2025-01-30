using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using SchoolManagementSystem.BusinessObjects;

namespace SchoolManagementSystem.DAL
{
    public class AssignClassDAL
    {
        public AssignClassDAL()
        {
        }
        public DataSet StudentAttendanceLoad(int class_id, int section_id)
        {
            try
            {
                SqlParameter[] arParams = new SqlParameter[2];
                arParams[0] = new SqlParameter("@class_id", class_id);
                arParams[1] = new SqlParameter("@section_id", section_id);
                return DbHelper.GetDataSet(CommandType.StoredProcedure, "StudentAttendanceLoad", arParams);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }
    }
}
