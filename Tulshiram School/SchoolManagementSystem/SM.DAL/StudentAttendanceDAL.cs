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
    public class StudentAttendanceDAL
    {
        public StudentAttendanceDAL()
        {
        }

        public int AttendanceUpdate(List<StudentAttendanceBO> listStudentAttendanceBO, List<TeacherAttendanceBO> listTeacherAttendanceBO, List<StuffAttendanceBO> listStuffAttendanceBO)
        {
            SqlConnection conn = DbHelper.GetOpenConnection();
            SqlTransaction trans = conn.BeginTransaction();
            int ID = 0;
            try
            {
                AttendanceStudentUpdate(trans, listStudentAttendanceBO);
                AttendanceTeacherUpdate(trans, listTeacherAttendanceBO);
                AttendanceStuffUpdate(trans, listStuffAttendanceBO);

                trans.Commit();
                ID = 1;
            }
            catch (Exception Ex)
            {
                trans.Rollback();
                throw Ex;
            }
            finally
            {
                conn.Close();
            }
            return ID;
        }
        private void AttendanceStudentUpdate(SqlTransaction trans, List<StudentAttendanceBO> listStudentAttendanceBO)
        {
            SqlParameter[] arParams = new SqlParameter[2];
            try
            {
                foreach (StudentAttendanceBO element in listStudentAttendanceBO)
                {
                    arParams[0] = new SqlParameter("@reg_no", element.reg_no);
                    arParams[1] = new SqlParameter("@date", element.date);
                   
                    SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "AttendanceStudentUpdate", arParams);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void AttendanceTeacherUpdate(SqlTransaction trans, List<TeacherAttendanceBO> listTeacherAttendanceBO)
        {
            SqlParameter[] arParams = new SqlParameter[2];
            try
            {
                foreach (TeacherAttendanceBO element in listTeacherAttendanceBO)
                {
                    arParams[0] = new SqlParameter("@reg_no", element.reg_no);
                    arParams[1] = new SqlParameter("@date", element.date);

                    SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "AttendanceTeacherUpdate", arParams);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void AttendanceStuffUpdate(SqlTransaction trans, List<StuffAttendanceBO> listStuffAttendanceBO)
        {
            SqlParameter[] arParams = new SqlParameter[2];
            try
            {
                foreach (StuffAttendanceBO element in listStuffAttendanceBO)
                {
                    arParams[0] = new SqlParameter("@reg_no", element.reg_no);
                    arParams[1] = new SqlParameter("@date", element.date);

                    SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "AttendanceStuffUpdate", arParams);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
