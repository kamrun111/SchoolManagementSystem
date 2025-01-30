using System;
using System.Text;

namespace SchoolManagementSystem.BusinessObjects
{
    public class MessageGroupBO
    {
        private int _message_group_id;
        public int message_group_id
        {
            get { return _message_group_id; }
            set { _message_group_id = value; }
        }
        private string _group_name;
        public string group_name
        {
            get { return _group_name; }
            set { _group_name = value; }
        }
        private string _member;
        public string member
        {
            get { return _member; }
            set { _member = value; }
        }
        private string _message;
        public string message
        {
            get { return _message; }
            set { _message = value; }
        }
        private Nullable<DateTime> _record_created_date;
        public Nullable<DateTime> record_created_date
        {
            get { return _record_created_date; }
            set { _record_created_date = value; }
        }
        private Nullable<int> _record_created_by;
        public Nullable<int> record_created_by
        {
            get { return _record_created_by; }
            set { _record_created_by = value; }
        }
        private Nullable<DateTime> _record_modified_date;
        public Nullable<DateTime> record_modified_date
        {
            get { return _record_modified_date; }
            set { _record_modified_date = value; }
        }
        private Nullable<int> _record_modified_by;
        public Nullable<int> record_modified_by
        {
            get { return _record_modified_by; }
            set { _record_modified_by = value; }
        }
        public MessageGroupBO()
        { }
    }
}
