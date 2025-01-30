using System;
using System.Text;

namespace SchoolManagementSystem.BusinessObjects
{
    public class FeeCollectionBO
    {
        	private int  _fee_collection_id;
	public int fee_collection_id
	{
		get { return _fee_collection_id; }
		set { _fee_collection_id = value; }
	}
	private string  _invoice_no;
	public string invoice_no
	{
		get { return _invoice_no; }
		set { _invoice_no = value; }
	}
	private Nullable<int>  _student_id;
	public Nullable<int> student_id
	{
		get { return _student_id; }
		set { _student_id = value; }
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
    private Nullable<decimal> _fine_amount;
    public Nullable<decimal> fine_amount
	{
        get { return _fine_amount; }
        set { _fine_amount = value; }
	}
	private Nullable<decimal>  _total_amount;
	public Nullable<decimal> total_amount
	{
		get { return _total_amount; }
		set { _total_amount = value; }
	}
	private Nullable<decimal>  _paid_amount;
	public Nullable<decimal> paid_amount
	{
		get { return _paid_amount; }
		set { _paid_amount = value; }
	}
	private Nullable<decimal>  _balance_amount;
	public Nullable<decimal> balance_amount
	{
		get { return _balance_amount; }
		set { _balance_amount = value; }
	}
	private string  _payment_type;
	public string payment_type
	{
		get { return _payment_type; }
		set { _payment_type = value; }
	}
	private int  _payment_status;
	public int payment_status
	{
		get { return _payment_status; }
		set { _payment_status = value; }
	}
	private string  _payment_month;
	public string payment_month
	{
		get { return _payment_month; }
		set { _payment_month = value; }
	}
	private Nullable<DateTime>  _payment_date;
	public Nullable<DateTime> payment_date
	{
		get { return _payment_date; }
		set { _payment_date = value; }
	}
    private Nullable<int> _donation_received_by;
    public Nullable<int> donation_received_by
	{
        get { return _donation_received_by; }
        set { _donation_received_by = value; }
	}
    private Nullable<DateTime> _donation_collection_date;
    public Nullable<DateTime> donation_collection_date
    {
        get { return _donation_collection_date; }
        set { _donation_collection_date = value; }
    }
	private Nullable<int>  _payment_catagory_id;
	public Nullable<int> payment_catagory_id
	{
		get { return _payment_catagory_id; }
		set { _payment_catagory_id = value; }
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
    public FeeCollectionBO()
	{ }
    }
}
