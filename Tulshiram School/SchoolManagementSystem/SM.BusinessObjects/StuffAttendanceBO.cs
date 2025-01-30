using System;
using System.Text;

namespace SchoolManagementSystem.BusinessObjects
{
    public class StuffAttendanceBO
    {
        	private int  _stuff_attendance_id;
	public int stuff_attendance_id
	{
		get { return _stuff_attendance_id; }
		set { _stuff_attendance_id = value; }
	}
	private Nullable<int>  _stuff_id;
	public Nullable<int> stuff_id
	{
		get { return _stuff_id; }
		set { _stuff_id = value; }
	}
	private Nullable<int>  _shift_id;
	public Nullable<int> shift_id
	{
		get { return _shift_id; }
		set { _shift_id = value; }
	}
	private Nullable<DateTime>  _date;
	public Nullable<DateTime> date
	{
		get { return _date; }
		set { _date = value; }
	}
	private Nullable<int>  _status;
	public Nullable<int> status
	{
		get { return _status; }
		set { _status = value; }
	}
	private Nullable<int>  _reg_no;
	public Nullable<int> reg_no
	{
		get { return _reg_no; }
		set { _reg_no = value; }
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
    public StuffAttendanceBO()
	{ }
    }
}
