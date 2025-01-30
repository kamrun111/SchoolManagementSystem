using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SchoolManagementSystem.BusinessObjects;
using SchoolManagementSystem.DAL;

namespace SchoolManagementSystem.BLL
{
    public class MessageGroupBLL
    {
        private MessageGroupDAL _messageGroupDAL;

        public MessageGroupDAL messageGroupDAL
		{
            get { return _messageGroupDAL; }
            set { _messageGroupDAL = value; }
		}

        public MessageGroupBLL()
		{
            messageGroupDAL = new MessageGroupDAL();
		}
        public int MessageGroupAdd(MessageGroupBO messageGroupBO, List<MessageGroupDetailsBO> listMessageGroupDetailsBO)
        {
            try
            {
                return messageGroupDAL.MessageGroupAdd(messageGroupBO, listMessageGroupDetailsBO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
