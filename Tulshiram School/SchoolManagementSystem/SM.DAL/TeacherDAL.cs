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
    public class TeacherDAL
    {
        public TeacherDAL()
        { }
        public int TeacherAdd(TeacherBO teacherBO)
        {
            SqlParameter[] arParams = new SqlParameter[12];
            try
            {
                arParams[0] = new SqlParameter("@teacher_name", teacherBO.teacher_name);
                arParams[1] = new SqlParameter("@father_name", teacherBO.father_name);
                arParams[2] = new SqlParameter("@mother_name", teacherBO.mother_name);
                arParams[3] = new SqlParameter("@address", teacherBO.address);

                arParams[4] = new SqlParameter("@gender_id", teacherBO.gender_id);
                arParams[5] = new SqlParameter("@contact", teacherBO.contact);
                arParams[6] = new SqlParameter("@shift_id", teacherBO.shift_id);
                arParams[7] = new SqlParameter("@teacher_status", teacherBO.teacher_status);

                arParams[8] = new SqlParameter("@image", teacherBO.image);
                arParams[9] = new SqlParameter("@dob", teacherBO.dob);
                arParams[10] = new SqlParameter("@joing_date", teacherBO.joing_date);
                arParams[11] = new SqlParameter("@record_created_by", teacherBO.record_created_by);
                return DbHelper.ExecuteNonQuery(CommandType.StoredProcedure, "TeacherAdd", arParams);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int TeacherUpdate(TeacherBO teacherBO)
        {

            SqlParameter[] arParams = new SqlParameter[13];
            try
            {
                arParams[0] = new SqlParameter("@teacher_name", teacherBO.teacher_name);
                arParams[1] = new SqlParameter("@father_name", teacherBO.father_name);
                arParams[2] = new SqlParameter("@mother_name", teacherBO.mother_name);
                arParams[3] = new SqlParameter("@address", teacherBO.address);

                arParams[4] = new SqlParameter("@gender_id", teacherBO.gender_id);
                arParams[5] = new SqlParameter("@contact", teacherBO.contact);
                arParams[6] = new SqlParameter("@shift_id", teacherBO.shift_id);
                arParams[7] = new SqlParameter("@teacher_status", teacherBO.teacher_status);

                arParams[8] = new SqlParameter("@image", teacherBO.image);
                arParams[9] = new SqlParameter("@dob", teacherBO.dob);
                arParams[10] = new SqlParameter("@joing_date", teacherBO.joing_date);
                arParams[11] = new SqlParameter("@record_modified_by", teacherBO.record_modified_by);
                arParams[12] = new SqlParameter("@teacher_id", teacherBO.teacher_id);

                return DbHelper.ExecuteNonQuery(CommandType.StoredProcedure, "TeacherUpdate", arParams);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
