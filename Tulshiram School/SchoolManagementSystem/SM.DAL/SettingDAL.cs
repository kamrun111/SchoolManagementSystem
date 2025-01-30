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
    public class SettingDAL
    {
        public SettingDAL()
        {
        }
        public int SettingADD(SettingBO settingBO)
        {
            SqlParameter[] arParams = new SqlParameter[6];
            try
            {
                arParams[0] = new SqlParameter("@payment_catagory_id", settingBO.payment_catagory_id);
                arParams[1] = new SqlParameter("@fees_type_id", settingBO.fees_type_id);
                arParams[2] = new SqlParameter("@fee_name_id", settingBO.fee_name_id);
                arParams[3] = new SqlParameter("@class_id", settingBO.class_id);
                arParams[4] = new SqlParameter("@amount", settingBO.amount);
                arParams[5] = new SqlParameter("@record_created_by", settingBO.record_created_by);

                return DbHelper.ExecuteNonQuery(CommandType.StoredProcedure, "SettingADD", arParams);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int SettingUpdate(SettingBO settingBO)
        {

            SqlParameter[] arParams = new SqlParameter[7];
            try
            {
                arParams[0] = new SqlParameter("@payment_catagory_id", settingBO.payment_catagory_id);
                arParams[1] = new SqlParameter("@fees_type_id", settingBO.fees_type_id);
                arParams[2] = new SqlParameter("@fee_name_id", settingBO.fee_name_id);
                arParams[3] = new SqlParameter("@class_id", settingBO.class_id);
                arParams[4] = new SqlParameter("@amount", settingBO.amount);
                arParams[5] = new SqlParameter("@setting_id", settingBO.setting_id);
                arParams[6] = new SqlParameter("@record_modified_by", settingBO.record_modified_by);

                return DbHelper.ExecuteNonQuery(CommandType.StoredProcedure, "SettingUpdate", arParams);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
