using System;
using System.Text;

namespace SchoolManagementSystem.BusinessObjects
{
    public class MessageGroupDetailsBO
    {
        private int _message_group_details_id;
        public int message_group_details_id
        {
            get { return _message_group_details_id; }
            set { _message_group_details_id = value; }
        }
        private Nullable<int> _message_group_id;
        public Nullable<int> message_group_id
        {
            get { return _message_group_id; }
            set { _message_group_id = value; }
        }
        private Nullable<int> _member_id;
        public Nullable<int> member_id
        {
            get { return _member_id; }
            set { _member_id = value; }
        }
        private Nullable<int> _member_reg;
        public Nullable<int> member_reg
        {
            get { return _member_reg; }
            set { _member_reg = value; }
        }
        private string _name;
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _contact_no;
        public string contact_no
        {
            get { return _contact_no; }
            set { _contact_no = value; }
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
        public MessageGroupDetailsBO()
        { }
    }
}
