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
    public class StudentDAL
    {
        public StudentDAL()
		{
		}
        public DataSet StudentComboLoad()
        {
            try
            {
                return DbHelper.GetDataSet(CommandType.StoredProcedure, "StudentComboLoad");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }
        public int StudentAdd(StudentBO studentBO)
        {
            SqlParameter[] arParams = new SqlParameter[19];
            SqlConnection conn = DbHelper.GetOpenConnection();
            int result = 0;
            try
            {
                arParams[0] = new SqlParameter("@student_id", SqlDbType.Int, 4);
                arParams[1] = new SqlParameter("@student_name", studentBO.student_name);
                arParams[2] = new SqlParameter("@f_name", studentBO.f_name);
                arParams[3] = new SqlParameter("@m_name", studentBO.m_name);
                arParams[4] = new SqlParameter("@present_address", studentBO.present_address);


                arParams[5] = new SqlParameter("@permanent_address", studentBO.permanent_address);
                arParams[6] = new SqlParameter("@gender_id", studentBO.gender_id);
                arParams[7] = new SqlParameter("@dob", studentBO.dob);
                arParams[8] = new SqlParameter("@contact", studentBO.contact);
                arParams[9] = new SqlParameter("@blood_group", studentBO.blood_group);


                arParams[10] = new SqlParameter("@session_id", studentBO.session_id);
                arParams[11] = new SqlParameter("@shift_id", studentBO.shift_id);
                arParams[12] = new SqlParameter("@class_id", studentBO.class_id);
                arParams[13] = new SqlParameter("@section_id", studentBO.section_id);
                arParams[14] = new SqlParameter("@roll_no", studentBO.roll_no);

                arParams[15] = new SqlParameter("@payment_catagory_id", studentBO.payment_catagory_id);
                arParams[16] = new SqlParameter("@student_status", studentBO.student_status);
                arParams[17] = new SqlParameter("@image", studentBO.image);
                arParams[18] = new SqlParameter("@record_created_by", studentBO.record_created_by);


                arParams[0].Direction = ParameterDirection.Output;

                SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, "StudentAdd", arParams);
                result = Convert.ToInt32(arParams[0].Value.ToString());


            }
            catch (Exception ex)
            {
                result = -1;
                throw ex;
            }
            finally
            {
                DbHelper.CloseConnection(conn);
            }
            return result;
        }
        public DataSet StudentSectionLoad(int class_id)
        {
            try
            {
                SqlParameter[] arParams = new SqlParameter[1];
                arParams[0] = new SqlParameter("@class_id", class_id);
                return DbHelper.GetDataSet(CommandType.StoredProcedure, "StudentSectionLoad", arParams);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }
        public DataSet StudentSearchName(string student_name,int flag)
        {
            try
            {
                SqlParameter[] arParams = new SqlParameter[2];
                arParams[0] = new SqlParameter("@student_name", student_name);
                arParams[1] = new SqlParameter("@flag", flag);
                return DbHelper.GetDataSet(CommandType.StoredProcedure, "StudentSearchName", arParams);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }
        public DataSet StudentDueList(int class_id, int section_id, int shift_id, string Month)
        {
            try
            {
                SqlParameter[] arParams = new SqlParameter[4];
                arParams[0] = new SqlParameter("@class_id", class_id);
                arParams[1] = new SqlParameter("@section_id", section_id);
                arParams[2] = new SqlParameter("@shift_id", shift_id);
                arParams[3] = new SqlParameter("@Month", Month);
                return DbHelper.GetDataSet(CommandType.StoredProcedure, "duelist", arParams);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }
        public DataSet StudentListLoad(int class_id, int section_id)
        {
            try
            {
                SqlParameter[] arParams = new SqlParameter[2];
                arParams[0] = new SqlParameter("@class_id", class_id);
                arParams[1] = new SqlParameter("@section_id", section_id);
                return DbHelper.GetDataSet(CommandType.StoredProcedure, "StudentListLoad", arParams);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }
        public int StudentUpdate(StudentBO studentBO)
        {

            SqlParameter[] arParams = new SqlParameter[19];
            try
            {
                arParams[0] = new SqlParameter("@student_id", studentBO.student_id);
                arParams[1] = new SqlParameter("@student_name", studentBO.student_name);
                arParams[2] = new SqlParameter("@f_name", studentBO.f_name);
                arParams[3] = new SqlParameter("@m_name", studentBO.m_name);
                arParams[4] = new SqlParameter("@present_address", studentBO.present_address);


                arParams[5] = new SqlParameter("@permanent_address", studentBO.permanent_address);
                arParams[6] = new SqlParameter("@gender_id", studentBO.gender_id);
                arParams[7] = new SqlParameter("@dob", studentBO.dob);
                arParams[8] = new SqlParameter("@contact", studentBO.contact);
                arParams[9] = new SqlParameter("@blood_group", studentBO.blood_group);


                arParams[10] = new SqlParameter("@session_id", studentBO.session_id);
                arParams[11] = new SqlParameter("@shift_id", studentBO.shift_id);
                arParams[12] = new SqlParameter("@class_id", studentBO.class_id);
                arParams[13] = new SqlParameter("@section_id", studentBO.section_id);
                arParams[14] = new SqlParameter("@roll_no", studentBO.roll_no);

                arParams[15] = new SqlParameter("@payment_catagory_id", studentBO.payment_catagory_id);
                arParams[16] = new SqlParameter("@student_status", studentBO.student_status);
                arParams[17] = new SqlParameter("@image", studentBO.image);
                arParams[18] = new SqlParameter("@record_modified_by", studentBO.record_modified_by);
                return DbHelper.ExecuteNonQuery(CommandType.StoredProcedure, "StudentUpdate", arParams);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int StudentImageUpdate(StudentBO studentBO)
        {

            SqlParameter[] arParams = new SqlParameter[2];
            try
            {
                arParams[0] = new SqlParameter("@student_id", studentBO.student_id);
                
                arParams[1] = new SqlParameter("@image", studentBO.image);

                return DbHelper.ExecuteNonQuery(CommandType.StoredProcedure, "StudentImageUpdate", arParams);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int StudentPromotionAdd(List<StudentBO> listStudentBO)
        {
            SqlConnection conn = DbHelper.GetOpenConnection();
            SqlTransaction trans = conn.BeginTransaction();
            SqlParameter[] arParams = new SqlParameter[7];
            int result = 0;
            try
            {
                foreach (StudentBO element in listStudentBO)
                {
                    arParams[0] = new SqlParameter("@shift_id", element.shift_id);
                    arParams[1] = new SqlParameter("@class_id", element.class_id);
                    arParams[2] = new SqlParameter("@section_id", element.section_id);
                    arParams[3] = new SqlParameter("@session_id", element.session_id);
                    arParams[4] = new SqlParameter("@student_id", element.student_id);
                    arParams[5] = new SqlParameter("@record_modified_by", element.record_modified_by);
                    arParams[6] = new SqlParameter("@roll_no", element.roll_no);


                    result = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "StudentPromotionAdd", arParams);
                }
                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                result = -1;
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

    }
}
