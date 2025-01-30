using System;
using System.Text;

namespace SchoolManagementSystem.BusinessObjects
{
    public class FeePaymentBO
    {
    private int  _fee_payment_id;
	public int fee_payment_id
	{
		get { return _fee_payment_id; }
		set { _fee_payment_id = value; }
	}
	private int  _fee_collection_id;
	public int fee_collection_id
	{
		get { return _fee_collection_id; }
		set { _fee_collection_id = value; }
	}
    private Nullable<decimal> _net_payable;
    public Nullable<decimal> net_payable
    {
        get { return _net_payable; }
        set { _net_payable = value; }
    }
	private Nullable<decimal>  _fee_paid_amount;
	public Nullable<decimal> fee_paid_amount
	{
		get { return _fee_paid_amount; }
		set { _fee_paid_amount = value; }
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
    public FeePaymentBO()
	{ }

    }
}
