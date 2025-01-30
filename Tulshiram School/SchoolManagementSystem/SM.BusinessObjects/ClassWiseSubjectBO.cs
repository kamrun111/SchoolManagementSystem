using System;
using System.Text;

namespace SchoolManagementSystem.BusinessObjects
{
    public class ClassWiseSubjectBO
    {
    private Nullable<int>  _class_wise_subject_id;
	public Nullable<int> class_wise_subject_id
	{
		get { return _class_wise_subject_id; }
		set { _class_wise_subject_id = value; }
	}
	private Nullable<int>  _subject_id;
	public Nullable<int> subject_id
	{
		get { return _subject_id; }
		set { _subject_id = value; }
	}
	private Nullable<int>  _class_id;
	public Nullable<int> class_id
	{
		get { return _class_id; }
		set { _class_id = value; }
	}
	private Nullable<int>  _shift_id;
	public Nullable<int> shift_id
	{
		get { return _shift_id; }
		set { _shift_id = value; }
	}
	private Nullable<int>  _status;
	public Nullable<int> status
	{
		get { return _status; }
		set { _status = value; }
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
    public ClassWiseSubjectBO()
	{ }
    }
}
