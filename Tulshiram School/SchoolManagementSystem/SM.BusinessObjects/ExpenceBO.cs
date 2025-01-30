using System;
using System.Text;

namespace SchoolManagementSystem.BusinessObjects
{
    public class ExpenceBO
    {
        private int  _expencess_id;
	public int expencess_id
	{
		get { return _expencess_id; }
		set { _expencess_id = value; }
	}
	private string  _expencess;
	public string expencess
	{
		get { return _expencess; }
		set { _expencess = value; }
	}
    public ExpenceBO()
	{ }
    }
}
