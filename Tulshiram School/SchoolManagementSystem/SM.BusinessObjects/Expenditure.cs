using System;
using System.Text;

namespace SchoolManagementSystem.BusinessObjects
{
    [Serializable()]
    public class Expenditure
    {
        private int _expenditure_id;

        public int expenditure_id	
        {
            get { return _expenditure_id; }
            set { _expenditure_id = value; }
        }

        private Nullable<int> _expenditure_order_id;

        public Nullable<int> expenditure_order_id
        {
            get { return _expenditure_order_id; }
            set { _expenditure_order_id = value; }
        }

        private Nullable<int> _expencess_id;

        public Nullable<int> expencess_id	
        {
            get { return _expencess_id; }
            set { _expencess_id = value; }
        }

        private Nullable<Decimal> _amount;

        public Nullable<Decimal> amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        private string _remarks;

        public string remarks
        {
            get { return _remarks; }
            set { _remarks = value; }
        }

        private Nullable<DateTime> _recordate;

        public Nullable<DateTime> recordate
        {
            get { return _recordate; }
            set { _recordate = value; }
        }

        private Nullable<DateTime> _record_created_date;

        public Nullable<DateTime> record_created_date
        {
            get { return _record_created_date; }
            set { _record_created_date = value; }
        }

        private Nullable<int> _record_created_by;

        public Nullable<int> record_created_by
        {
            get { return _record_created_by; }
            set { _record_created_by = value; }
        }

        private Nullable<DateTime> _record_modified_date;

        public Nullable<DateTime> record_modified_date
        {
            get { return _record_modified_date; }
            set { _record_modified_date = value; }
        }

        private Nullable<int> _record_modified_by;

        public Nullable<int> record_modified_by
        {
            get { return _record_modified_by; }
            set { _record_modified_by = value; }
        }

        public Expenditure()
		{ }

        public Expenditure(int expenditure_id,Nullable<int> expenditure_order_id, Nullable<int> expencess_id, Nullable<decimal> amount,string remarks,Nullable<DateTime> recordate, Nullable<DateTime> record_created_date, Nullable<int> record_created_by, Nullable<DateTime> record_modified_date, Nullable<int> record_modified_by)
		{
            this.expenditure_id = expenditure_id;
            this.expenditure_order_id = expenditure_order_id;
            this.expencess_id = expencess_id;
            this.amount = amount;
            this.remarks = remarks;
            this.recordate = recordate;
			this.record_created_date = record_created_date;
			this.record_created_by = record_created_by;
			this.record_modified_date = record_modified_date;
			this.record_modified_by = record_modified_by;
		}
 
    }
}
