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
    public class StuffDAL
    {
        public StuffDAL()
        {
        }
        public int StuffAdd(StuffBO stuffBO)
        {
            SqlParameter[] arParams = new SqlParameter[12];
            try
            {
                arParams[0] = new SqlParameter("@stuff_name", stuffBO.stuff_name);
                arParams[1] = new SqlParameter("@father_name", stuffBO.father_name);
                arParams[2] = new SqlParameter("@mother_name", stuffBO.mother_name);
                arParams[3] = new SqlParameter("@address", stuffBO.address);

                arParams[4] = new SqlParameter("@gender_id", stuffBO.gender_id);
                arParams[5] = new SqlParameter("@contact", stuffBO.contact);
                arParams[6] = new SqlParameter("@shift_id", stuffBO.shift_id);
                arParams[7] = new SqlParameter("@stuff_status", stuffBO.stuff_status);

                arParams[8] = new SqlParameter("@image", stuffBO.image);
                arParams[9] = new SqlParameter("@dob", stuffBO.dob);
                arParams[10] = new SqlParameter("@joing_date", stuffBO.joing_date);
                arParams[11] = new SqlParameter("@record_created_by", stuffBO.record_created_by);
                return DbHelper.ExecuteNonQuery(CommandType.StoredProcedure, "StuffAdd", arParams);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int StuffUpdate(StuffBO stuffBO)
        {

            SqlParameter[] arParams = new SqlParameter[13];
            try
            {
                arParams[0] = new SqlParameter("@stuff_name", stuffBO.stuff_name);
                arParams[1] = new SqlParameter("@father_name", stuffBO.father_name);
                arParams[2] = new SqlParameter("@mother_name", stuffBO.mother_name);
                arParams[3] = new SqlParameter("@address", stuffBO.address);

                arParams[4] = new SqlParameter("@gender_id", stuffBO.gender_id);
                arParams[5] = new SqlParameter("@contact", stuffBO.contact);
                arParams[6] = new SqlParameter("@shift_id", stuffBO.shift_id);
                arParams[7] = new SqlParameter("@stuff_status", stuffBO.stuff_status);

                arParams[8] = new SqlParameter("@image", stuffBO.image);
                arParams[9] = new SqlParameter("@dob", stuffBO.dob);
                arParams[10] = new SqlParameter("@joing_date", stuffBO.joing_date);
                arParams[11] = new SqlParameter("@record_modified_by", stuffBO.record_modified_by);
                arParams[12] = new SqlParameter("@stuff_id", stuffBO.stuff_id);

                return DbHelper.ExecuteNonQuery(CommandType.StoredProcedure, "StuffUpdate", arParams);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }






    }
}
