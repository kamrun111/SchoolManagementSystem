using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SchoolManagementSystem.BusinessObjects;
using SchoolManagementSystem.DAL;

namespace SchoolManagementSystem.BLL
{
    public class MessageGroupDetailsBLL
    {
        private MessageGroupDetailsDAL _messageGroupDetailsDAL;

        public MessageGroupDetailsDAL messageGroupDetailsDAL
        {
            get { return _messageGroupDetailsDAL; }
            set { _messageGroupDetailsDAL = value; }
        }
        public MessageGroupDetailsBLL()
        {
            messageGroupDetailsDAL = new MessageGroupDetailsDAL();
        }
    }
}
