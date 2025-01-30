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
    public class StudentAdmissionDAL
    {
        public StudentAdmissionDAL()
        {
        }
        public int StudentAdmissionAdd(StudentAdmissionBO studentAdmissionBO)
        {
            SqlParameter[] arParams = new SqlParameter[31];
            SqlConnection conn = DbHelper.GetOpenConnection();
            int result = 0;
            try
            {
                arParams[0] = new SqlParameter("@registration_no", studentAdmissionBO.registration_no);
                arParams[1] = new SqlParameter("@full_name", studentAdmissionBO.full_name);
                arParams[2] = new SqlParameter("@admission_date", studentAdmissionBO.admission_date);
                arParams[3] = new SqlParameter("@class_id", studentAdmissionBO.class_id);
                arParams[4] = new SqlParameter("@section_id", studentAdmissionBO.section_id);


                arParams[5] = new SqlParameter("@roll_no", studentAdmissionBO.roll_no);
                arParams[6] = new SqlParameter("@student_status_id", studentAdmissionBO.student_status_id);
                arParams[7] = new SqlParameter("@gender_id", studentAdmissionBO.gender_id);
                arParams[8] = new SqlParameter("@date_of_birth", studentAdmissionBO.date_of_birth);
                arParams[9] = new SqlParameter("@academic_year_id", studentAdmissionBO.academic_year_id);


                arParams[10] = new SqlParameter("@district_id", studentAdmissionBO.district_id);
                arParams[11] = new SqlParameter("@fathers_name", studentAdmissionBO.fathers_name);
                arParams[12] = new SqlParameter("@fathers_education", studentAdmissionBO.fathers_education);
                arParams[13] = new SqlParameter("@fathers_cell_no", studentAdmissionBO.fathers_cell_no);
                arParams[14] = new SqlParameter("@father_occupation_id", studentAdmissionBO.father_occupation_id);

                arParams[15] = new SqlParameter("@mothers_name", studentAdmissionBO.mothers_name);
                arParams[16] = new SqlParameter("@mothers_cell_no", studentAdmissionBO.mothers_cell_no);
                arParams[17] = new SqlParameter("@income_yearly", studentAdmissionBO.income_yearly);
                arParams[18] = new SqlParameter("@local_guardian_name", studentAdmissionBO.local_guardian_name);

                arParams[19] = new SqlParameter("@local_guardian_address", studentAdmissionBO.local_guardian_address);
                arParams[20] = new SqlParameter("@local_guardian_cell_no", studentAdmissionBO.local_guardian_cell_no);
                arParams[21] = new SqlParameter("@present_address", studentAdmissionBO.present_address);
                arParams[22] = new SqlParameter("@parmanent_address", studentAdmissionBO.parmanent_address);
                arParams[23] = new SqlParameter("@contact_no", studentAdmissionBO.contact_no);

                arParams[24] = new SqlParameter("@student_previous_institude_name", studentAdmissionBO.student_previous_institude_name);
                arParams[25] = new SqlParameter("@previous_school_year", studentAdmissionBO.previous_school_year);
                arParams[26] = new SqlParameter("@total_marks", studentAdmissionBO.total_marks);
                arParams[27] = new SqlParameter("@obtained_marks", studentAdmissionBO.obtained_marks);
                arParams[28] = new SqlParameter("@record_created_by", studentAdmissionBO.record_created_by);
                arParams[29] = new SqlParameter("@result", studentAdmissionBO.result);
                arParams[30] = new SqlParameter("@student_admission_id", SqlDbType.Int, 4);
                arParams[30].Direction = ParameterDirection.Output;

                SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, "StudentAdmissionAdd", arParams);
                result = Convert.ToInt32(arParams[30].Value.ToString());


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

        public DataSet StudentAdmissionSearch(string name, int class_id)
        {
            try
            {
                SqlParameter[] arParams = new SqlParameter[2];
                arParams[0] = new SqlParameter("@name", name);
                arParams[1] = new SqlParameter("@class_id", class_id);

                return DbHelper.GetDataSet(CommandType.StoredProcedure, "StudentAdmissionSearch", arParams);
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
