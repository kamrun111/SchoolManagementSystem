using System;
using System.Text;

namespace SchoolManagementSystem.BusinessObjects
{
    public class SettingBO
    {
        	private int  _setting_id;
	public int setting_id
	{
		get { return _setting_id; }
		set { _setting_id = value; }
	}
	private Nullable<int>  _payment_catagory_id;
	public Nullable<int> payment_catagory_id
	{
		get { return _payment_catagory_id; }
		set { _payment_catagory_id = value; }
	}
	private Nullable<int>  _fees_type_id;
	public Nullable<int> fees_type_id
	{
		get { return _fees_type_id; }
		set { _fees_type_id = value; }
	}
	private Nullable<int>  _fee_name_id;
	public Nullable<int> fee_name_id
	{
		get { return _fee_name_id; }
		set { _fee_name_id = value; }
	}
	private Nullable<int>  _class_id;
	public Nullable<int> class_id
	{
		get { return _class_id; }
		set { _class_id = value; }
	}
	private Nullable<decimal>  _amount;
	public Nullable<decimal> amount
	{
		get { return _amount; }
		set { _amount = value; }
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
    public SettingBO()
	{ }
    }
}
