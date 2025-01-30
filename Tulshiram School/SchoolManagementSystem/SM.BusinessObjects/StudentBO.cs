using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolManagementSystem.BusinessObjects
{
    public class StudentBO
    {
        	private int  _student_id;
	public int student_id
	{
		get { return _student_id; }
		set { _student_id = value; }
	}
	private string  _reg_no;
	public string reg_no
	{
		get { return _reg_no; }
		set { _reg_no = value; }
	}
	private string  _student_name;
    public string student_name
	{
		get { return _student_name; }
		set { _student_name = value; }
	}
    private string _f_name;
    public string f_name
	{
		get { return _f_name; }
		set { _f_name = value; }
	}
    private string _m_name;
	public string m_name
	{
		get { return _m_name; }
		set { _m_name = value; }
	}
    private string _present_address;
    public string present_address
	{
		get { return _present_address; }
		set { _present_address = value; }
	}
    private string _permanent_address;
	public string permanent_address
	{
		get { return _permanent_address; }
		set { _permanent_address = value; }
	}
	private Nullable<int>  _gender_id;
	public Nullable<int> gender_id
	{
		get { return _gender_id; }
		set { _gender_id = value; }
	}
	private Nullable<DateTime>  _dob;
	public Nullable<DateTime> dob
	{
		get { return _dob; }
		set { _dob = value; }
	}
    private string _contact;
	public string contact
	{
		get { return _contact; }
		set { _contact = value; }
	}
    private string _blood_group;
    public string blood_group
	{
		get { return _blood_group; }
		set { _blood_group = value; }
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
	private Nullable<int>  _roll_no;
	public Nullable<int> roll_no
	{
		get { return _roll_no; }
		set { _roll_no = value; }
	}
	private Nullable<int>  _payment_catagory_id;
	public Nullable<int> payment_catagory_id
	{
		get { return _payment_catagory_id; }
		set { _payment_catagory_id = value; }
	}
	private Nullable<int>  _student_status;
	public Nullable<int> student_status
	{
		get { return _student_status; }
		set { _student_status = value; }
	}
	private string  _image;
	public string image
	{
		get { return _image; }
		set { _image = value; }
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
	public StudentBO()
	{ }


}
}
    

