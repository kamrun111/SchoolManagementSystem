using System;
using System.Text;

namespace SchoolManagementSystem.BusinessObjects
{
    public class ExamResultBO
    {
        private int _exam_result_id;

        public int exam_result_id	
        {
            get { return _exam_result_id; }
            set { _exam_result_id = value; }
        }


        private Nullable<int> _exam_id;

        public Nullable<int> exam_id	
        {
            get { return _exam_id; }
            set { _exam_id = value; }
        }

        private Nullable<int> _session_id;

        public Nullable<int> session_id
        {
            get { return _session_id; }
            set { _session_id = value; }
        }

        private Nullable<int> _shift_id;

        public Nullable<int> shift_id
        {
            get { return _shift_id; }
            set { _shift_id = value; }
        }

        private Nullable<int> _class_id;

        public Nullable<int> class_id
        {
            get { return _class_id; }
            set { _class_id = value; }
        }

        private Nullable<int> _section_id;

        public Nullable<int> section_id
        {
            get { return _section_id; }
            set { _section_id = value; }
        }

        private Nullable<int> _student_id;

        public Nullable<int> student_id
        {
            get { return _student_id; }
            set { _student_id = value; }
        }
        private Nullable<int> _roll_no;

        public Nullable<int> roll_no
        {
            get { return _roll_no; }
            set { _roll_no = value; }
        }
        private Nullable<Decimal> _total_no;

        public Nullable<Decimal> total_no
        {
            get { return _total_no; }
            set { _total_no = value; }
        }

        private string _grade;

        public string grade
        {
            get { return _grade; }
            set { _grade = value; }
        }

        private Nullable<Decimal> _gpa;

        public Nullable<Decimal> gpa
        {
            get { return _gpa; }
            set { _gpa = value; }
        }

        private Nullable<int> _place;

        public Nullable<int> place
        {
            get { return _place; }
            set { _place = value; }
        }//


        private Nullable<int> _place_in_section;

        public Nullable<int> place_in_section
        {
            get { return _place_in_section; }
            set { _place_in_section = value; }
        }

        private Nullable<int> _total_present;

        public Nullable<int> total_present
        {
            get { return _total_present; }
            set { _total_present = value; }
        }

        private Nullable<int> _total_absent;

        public Nullable<int> total_absent
        {
            get { return _total_absent; }
            set { _total_absent = value; }
        }

        private string _remarks;

        public string remarks
        {
            get { return _remarks; }
            set { _remarks = value; }
        }

        private Nullable<DateTime> _recordate;

        public Nullable<DateTime> recordate
        {
            get { return _recordate; }
            set { _recordate = value; }
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

        public ExamResultBO()
		{ }
    }
}
