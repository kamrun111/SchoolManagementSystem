using System;
using System.Text;

namespace SchoolManagementSystem.BusinessObjects
{
   public  class SubjectAssignBO
    {
       	private int  _subject_assign_id;
	public int subject_assign_id
	{
		get { return _subject_assign_id; }
		set { _subject_assign_id = value; }
	}
	private Nullable<int>  _shift_id;
	public Nullable<int> shift_id
	{
		get { return _shift_id; }
		set { _shift_id = value; }
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
	private Nullable<int>  _session_id;
	public Nullable<int> session_id
	{
		get { return _session_id; }
		set { _session_id = value; }
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
	private Nullable<int>  _assign;
	public Nullable<int> assign
	{
		get { return _assign; }
		set { _assign = value; }
	}
	private Nullable<int>  _is_main;
	public Nullable<int> is_main
	{
		get { return _is_main; }
		set { _is_main = value; }
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
    public SubjectAssignBO()
	{ }
    }
}
