using System;
using System.Text;

namespace SchoolManagementSystem.BusinessObjects
{
    public class FeeCollectionDetailsBO
    {
        	private int  _fee_collection_details_id;
	public int fee_collection_details_id
	{
		get { return _fee_collection_details_id; }
		set { _fee_collection_details_id = value; }
	}
	private Nullable<int>  _fee_collection_id;
	public Nullable<int> fee_collection_id
	{
		get { return _fee_collection_id; }
		set { _fee_collection_id = value; }
	}
	private Nullable<int>  _fee_name_id;
	public Nullable<int> fee_name_id
	{
		get { return _fee_name_id; }
		set { _fee_name_id = value; }
	}
	private string  _month_name;
	public string month_name
	{
		get { return _month_name; }
		set { _month_name = value; }
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
    public FeeCollectionDetailsBO()
	{ }
    }
}
