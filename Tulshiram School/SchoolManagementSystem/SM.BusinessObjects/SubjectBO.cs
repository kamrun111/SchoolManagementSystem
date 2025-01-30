using System;
using System.Text;

namespace SchoolManagementSystem.BusinessObjects
{
    public class SubjectBO
    {
        private int  _subject_id;
	public int subject_id
	{
		get { return _subject_id; }
		set { _subject_id = value; }
	}
	private string  _subject;
	public string subject
	{
		get { return _subject; }
		set { _subject = value; }
	}
	private Nullable<int>  _subject_code;
	public Nullable<int> subject_code
	{
		get { return _subject_code; }
		set { _subject_code = value; }
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
    public SubjectBO()
	{ }
    }
}
