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
    public class MessageGroupDAL
    {
        public MessageGroupDAL()
        {

        }
        public int MessageGroupAdd(MessageGroupBO messageGroupBO, List<MessageGroupDetailsBO> listMessageGroupDetailsBO)
        {
            SqlConnection conn = DbHelper.GetOpenConnection();
            SqlTransaction trans = conn.BeginTransaction();
            int ID = 0;
            try
            {
                ID = MessageGroupInsert(trans, messageGroupBO);
                MessageGroupDetailsAdd(trans, ID, listMessageGroupDetailsBO);
                trans.Commit();
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
        public int MessageGroupInsert(SqlTransaction trans, MessageGroupBO messageGroupBO)
        {

            SqlParameter[] arParams = new SqlParameter[4];
            int result = 0;
            try
            {
                arParams[0] = new SqlParameter("@group_name", messageGroupBO.group_name);
                arParams[1] = new SqlParameter("@member", messageGroupBO.member);
                arParams[2] = new SqlParameter("@record_created_by", messageGroupBO.record_created_by);
                arParams[3] = new SqlParameter("@message_group_id", messageGroupBO.message_group_id);

                arParams[3].Direction = ParameterDirection.Output;

                SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "MessageGroupInsert", arParams);
                result = Convert.ToInt32(arParams[3].Value.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        private void MessageGroupDetailsAdd(SqlTransaction trans, int ID, List<MessageGroupDetailsBO> listMessageGroupDetailsBO)
        {
            SqlParameter[] arParams = new SqlParameter[6];
            try
            {
                foreach (MessageGroupDetailsBO element in listMessageGroupDetailsBO)
                {
                    arParams[0] = new SqlParameter("@message_group_id", ID);
                    arParams[1] = new SqlParameter("@member_id", element.member_id);
                    arParams[2] = new SqlParameter("@member_reg", element.member_reg);
                    arParams[3] = new SqlParameter("@name", element.name);
                    arParams[4] = new SqlParameter("@contact_no", element.contact_no);
                    arParams[5] = new SqlParameter("@record_created_by", element.record_created_by);


                    SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "MessageGroupDetailsAdd", arParams);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
