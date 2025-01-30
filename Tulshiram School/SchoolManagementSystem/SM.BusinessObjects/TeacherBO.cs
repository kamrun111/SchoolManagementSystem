using System;
using System.Text;

namespace SchoolManagementSystem.BusinessObjects
{
    public class TeacherBO
    {
    private int  _teacher_id;
	public int teacher_id
	{
		get { return _teacher_id; }
		set { _teacher_id = value; }
	}
	private Nullable<int>  _reg_no;
	public Nullable<int> reg_no
	{
		get { return _reg_no; }
		set { _reg_no = value; }
	}
	private string  _teacher_name;
	public string teacher_name
	{
		get { return _teacher_name; }
		set { _teacher_name = value; }
	}
	private string  _father_name;
	public string father_name
	{
		get { return _father_name; }
		set { _father_name = value; }
	}
	private string  _mother_name;
	public string mother_name
	{
		get { return _mother_name; }
		set { _mother_name = value; }
	}
	private string _address;
	public string address
	{
		get { return _address; }
		set { _address = value; }
	}
	private Nullable<int>  _gender_id;
	public Nullable<int> gender_id
	{
		get { return _gender_id; }
		set { _gender_id = value; }
	}
	private string  _contact;
	public string contact
	{
		get { return _contact; }
		set { _contact = value; }
	}
	private Nullable<int>  _shift_id;
	public Nullable<int> shift_id
	{
		get { return _shift_id; }
		set { _shift_id = value; }
	}
	private Nullable<int>  _teacher_status;
	public Nullable<int> teacher_status
	{
		get { return _teacher_status; }
		set { _teacher_status = value; }
	}
	private string  _image;
	public string image
	{
		get { return _image; }
		set { _image = value; }
	}
    private Nullable<DateTime> _dob;
    public Nullable<DateTime> dob
    {
        get { return _dob; }
        set { _dob = value; }
    }
	private Nullable<DateTime>  _joing_date;
	public Nullable<DateTime> joing_date
	{
		get { return _joing_date; }
		set { _joing_date = value; }
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
    public TeacherBO()
	{ }
    }
}
