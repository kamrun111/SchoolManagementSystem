using System;
using System.Text;

namespace SchoolManagementSystem.BusinessObjects
{
    public class ExamMarksEntryBO
    {
        	private int  _exam_marks_entry_id;
	public int exam_marks_entry_id
	{
		get { return _exam_marks_entry_id; }
		set { _exam_marks_entry_id = value; }
	}
	private Nullable<int>  _exam_marks_assign_id;
	public Nullable<int> exam_marks_assign_id
	{
		get { return _exam_marks_assign_id; }
		set { _exam_marks_assign_id = value; }
	}
	private Nullable<int>  _exam_id;
	public Nullable<int> exam_id
	{
		get { return _exam_id; }
		set { _exam_id = value; }
	}
	private Nullable<int>  _session_id;
	public Nullable<int> session_id
	{
		get { return _session_id; }
		set { _session_id = value; }
	}
	private Nullable<int>  _shift_id;
	public Nullable<int> shift_id
	{
		get { return _shift_id; }
		set { _shift_id = value; }
	}
    private decimal _grand_total;
    public decimal grand_total
	{
        get { return _grand_total; }
        set { _grand_total = value; }
	}
	private Nullable<int>  _class_id;
	public Nullable<int> class_id
	{
		get { return _class_id; }
		set { _class_id = value; }
	}
	private Nullable<int>  _section_id;
	public Nullable<int> section_id
	{
		get { return _section_id; }
		set { _section_id = value; }
	}
	private Nullable<int>  _student_id;
	public Nullable<int> student_id
	{
		get { return _student_id; }
		set { _student_id = value; }
	}
	private Nullable<int>  _subject_id;
	public Nullable<int> subject_id
	{
		get { return _subject_id; }
		set { _subject_id = value; }
	}
    private Nullable<int> _subject_group_id;
    public Nullable<int> subject_group_id
    {
        get { return _subject_group_id; }
        set { _subject_group_id = value; }
    }
	private Nullable<decimal>  _theory;
	public Nullable<decimal> theory
	{
		get { return _theory; }
		set { _theory = value; }
	}
	private Nullable<decimal>  _objective;
	public Nullable<decimal> objective
	{
		get { return _objective; }
		set { _objective = value; }
	}
	private Nullable<decimal>  _practical;
	public Nullable<decimal> practical
	{
		get { return _practical; }
		set { _practical = value; }
	}
	private Nullable<decimal>  _exam_total;
	public Nullable<decimal> exam_total
	{
		get { return _exam_total; }
		set { _exam_total = value; }
	}
	private Nullable<decimal>  _result_total;
	public Nullable<decimal> result_total
	{
		get { return _result_total; }
		set { _result_total = value; }
	}
	private Nullable<decimal>  _result_obtain_total;
	public Nullable<decimal> result_obtain_total
	{
		get { return _result_obtain_total; }
		set { _result_obtain_total = value; }
	}
	private Nullable<decimal>  _class_test_total;
	public Nullable<decimal> class_test_total
	{
		get { return _class_test_total; }
		set { _class_test_total = value; }
	}
	private Nullable<decimal>  _class_test_obtain_total;
	public Nullable<decimal> class_test_obtain_total
	{
		get { return _class_test_obtain_total; }
		set { _class_test_obtain_total = value; }
	}
    private Nullable<decimal> _percentage;
    public Nullable<decimal> percentage
    {
        get { return _percentage; }
        set { _percentage = value; }
    }
	private string  _grade;
	public string grade
	{
		get { return _grade; }
		set { _grade = value; }
	}
	private Nullable<decimal>  _gpa;
	public Nullable<decimal> gpa
	{
		get { return _gpa; }
		set { _gpa = value; }
	}
	private Nullable<int>  _status;
	public Nullable<int> status
	{
		get { return _status; }
		set { _status = value; }
	}
	private Nullable<int>  _subject_status_id;
	public Nullable<int> subject_status_id
	{
		get { return _subject_status_id; }
		set { _subject_status_id = value; }
	}
	private Nullable<DateTime>  _record_created_date;
	public Nullable<DateTime> record_created_date
	{
		get { return _record_created_date; }
		set { _record_created_date = value; }
	}
	private Nullable<int>  _record_created_by;
	public Nullable<int> record_created_by
	{
		get { return _record_created_by; }
		set { _record_created_by = value; }
	}
	private Nullable<DateTime>  _record_modified_date;
	public Nullable<DateTime> record_modified_date
	{
		get { return _record_modified_date; }
		set { _record_modified_date = value; }
	}
	private Nullable<int>  _record_modified_by;
	public Nullable<int> record_modified_by
	{
		get { return _record_modified_by; }
		set { _record_modified_by = value; }
	}
    public ExamMarksEntryBO()
	{ }
    }
}
