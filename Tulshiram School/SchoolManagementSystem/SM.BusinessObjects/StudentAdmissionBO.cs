using System;
using System.Text;

namespace SchoolManagementSystem.BusinessObjects
{
    public class StudentAdmissionBO
    {
        private int _student_admission_id;
        public int student_admission_id
        {
            get { return _student_admission_id; }
            set { _student_admission_id = value; }
        }
        private string _student_code;
        public string student_code
        {
            get { return _student_code; }
            set { _student_code = value; }
        }
        private string _registration_no;
        public string registration_no
        {
            get { return _registration_no; }
            set { _registration_no = value; }
        }
        private string _full_name;
        public string full_name
        {
            get { return _full_name; }
            set { _full_name = value; }
        }
        private Nullable<DateTime> _admission_date;
        public Nullable<DateTime> admission_date
        {
            get { return _admission_date; }
            set { _admission_date = value; }
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
        private Nullable<int> _roll_no;
        public Nullable<int> roll_no
        {
            get { return _roll_no; }
            set { _roll_no = value; }
        }
        private Nullable<int> _student_status_id;
        public Nullable<int> student_status_id
        {
            get { return _student_status_id; }
            set { _student_status_id = value; }
        }
        private Nullable<int> _gender_id;
        public Nullable<int> gender_id
        {
            get { return _gender_id; }
            set { _gender_id = value; }
        }
        private Nullable<DateTime> _date_of_birth;
        public Nullable<DateTime> date_of_birth
        {
            get { return _date_of_birth; }
            set { _date_of_birth = value; }
        }
        private Nullable<int> _academic_year_id;
        public Nullable<int> academic_year_id
        {
            get { return _academic_year_id; }
            set { _academic_year_id = value; }
        }
        private Nullable<int> _district_id;
        public Nullable<int> district_id
        {
            get { return _district_id; }
            set { _district_id = value; }
        }
        private string _fathers_name;
        public string fathers_name
        {
            get { return _fathers_name; }
            set { _fathers_name = value; }
        }
        private string _fathers_education;
        public string fathers_education
        {
            get { return _fathers_education; }
            set { _fathers_education = value; }
        }
        private string _fathers_cell_no;
        public string fathers_cell_no
        {
            get { return _fathers_cell_no; }
            set { _fathers_cell_no = value; }
        }
        private Nullable<int> _father_occupation_id;
        public Nullable<int> father_occupation_id
        {
            get { return _father_occupation_id; }
            set { _father_occupation_id = value; }
        }
        private string _mothers_name;
        public string mothers_name
        {
            get { return _mothers_name; }
            set { _mothers_name = value; }
        }
        private string _mothers_cell_no;
        public string mothers_cell_no
        {
            get { return _mothers_cell_no; }
            set { _mothers_cell_no = value; }
        }
        private Nullable<decimal> _income_yearly;
        public Nullable<decimal> income_yearly
        {
            get { return _income_yearly; }
            set { _income_yearly = value; }
        }

        private string _local_guardian_name;
        public string local_guardian_name
        {
            get { return _local_guardian_name; }
            set { _local_guardian_name = value; }
        }
        private string _local_guardian_address;
        public string local_guardian_address
        {
            get { return _local_guardian_address; }
            set { _local_guardian_address = value; }
        }
        private string _local_guardian_cell_no;
        public string local_guardian_cell_no
        {
            get { return _local_guardian_cell_no; }
            set { _local_guardian_cell_no = value; }
        }
        private string _present_address;
        public string present_address
        {
            get { return _present_address; }
            set { _present_address = value; }
        }
        private string _parmanent_address;
        public string parmanent_address
        {
            get { return _parmanent_address; }
            set { _parmanent_address = value; }
        }
        private string _contact_no;
        public string contact_no
        {
            get { return _contact_no; }
            set { _contact_no = value; }
        }
        private string _student_previous_institude_name;
        public string student_previous_institude_name
        {
            get { return _student_previous_institude_name; }
            set { _student_previous_institude_name = value; }
        }
        private Nullable<DateTime> _previous_school_year;
        public Nullable<DateTime> previous_school_year
        {
            get { return _previous_school_year; }
            set { _previous_school_year = value; }
        }
        private Nullable<int> _last_class;
        public Nullable<int> last_class
        {
            get { return _last_class; }
            set { _last_class = value; }
        }
        private Nullable<decimal> _total_marks;
        public Nullable<decimal> total_marks
        {
            get { return _total_marks; }
            set { _total_marks = value; }
        }
        private Nullable<decimal> _obtained_marks;
        public Nullable<decimal> obtained_marks
        {
            get { return _obtained_marks; }
            set { _obtained_marks = value; }
        }
        private string _result;
        public string result
        {
            get { return _result; }
            set { _result = value; }
        }
        private Nullable<int> _record_created_by;
        public Nullable<int> record_created_by
        {
            get { return _record_created_by; }
            set { _record_created_by = value; }
        }
        private Nullable<DateTime> _record_created_date;
        public Nullable<DateTime> record_created_date
        {
            get { return _record_created_date; }
            set { _record_created_date = value; }
        }
        private Nullable<int> _record_modified_by;
        public Nullable<int> record_modified_by
        {
            get { return _record_modified_by; }
            set { _record_modified_by = value; }
        }
        private Nullable<DateTime> _record_modified_date;
        public Nullable<DateTime> record_modified_date
        {
            get { return _record_modified_date; }
            set { _record_modified_date = value; }
        }
    public StudentAdmissionBO()
	{ }
    }
}
