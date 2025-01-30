using System;
using System.Text;

namespace SchoolManagementSystem.BusinessObjects
{
    public class AssignClassBO
    {
    private int  _assign_class_id;
	public int assign_class_id
	{
		get { return _assign_class_id; }
		set { _assign_class_id = value; }
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
	private Nullable<int>  _teacher_id;
	public Nullable<int> teacher_id
	{
		get { return _teacher_id; }
		set { _teacher_id = value; }
	}
	private Nullable<int>  _session_id;
	public Nullable<int> session_id
	{
		get { return _session_id; }
		set { _session_id = value; }
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
    public AssignClassBO()
	{ }
    }
}
