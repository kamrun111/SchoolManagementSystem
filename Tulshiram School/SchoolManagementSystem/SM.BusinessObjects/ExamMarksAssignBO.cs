using System;
using System.Text;

namespace SchoolManagementSystem.BusinessObjects
{
    public class ExamMarksAssignBO
    {
        private int  _exam_marks_assign_id;
        public int exam_marks_assign_id
	    {
            get { return _exam_marks_assign_id; }
            set { _exam_marks_assign_id = value; }
	    }
	    private Nullable<int>  _exam_id;
	    public Nullable<int> exam_id
	    {
		    get { return _exam_id; }
		    set { _exam_id = value; }
	    }
	    private Nullable<int>  _class_id;
	    public Nullable<int> class_id
	    {
		    get { return _class_id; }
		    set { _class_id = value; }
	    }
	    private Nullable<int>  _subject_id;
	    public Nullable<int> subject_id
	    {
		    get { return _subject_id; }
		    set { _subject_id = value; }
	    }
	    private Nullable<decimal>  _exam_total_marks;
	    public Nullable<decimal> exam_total_marks
	    {
		    get { return _exam_total_marks; }
		    set { _exam_total_marks = value; }
	    }
	    private Nullable<decimal>  _theory_marks;
	    public Nullable<decimal> theory_marks
	    {
		    get { return _theory_marks; }
		    set { _theory_marks = value; }
	    }
	    private Nullable<decimal>  _theory_pass_marks;
	    public Nullable<decimal> theory_pass_marks
	    {
		    get { return _theory_pass_marks; }
		    set { _theory_pass_marks = value; }
	    }
	    private Nullable<decimal>  _objective_marks;
	    public Nullable<decimal> objective_marks
	    {
		    get { return _objective_marks; }
		    set { _objective_marks = value; }
	    }
	    private Nullable<decimal>  _objective_pass_marks;
	    public Nullable<decimal> objective_pass_marks
	    {
		    get { return _objective_pass_marks; }
		    set { _objective_pass_marks = value; }
	    }
	    private Nullable<decimal>  _practical_marks;
	    public Nullable<decimal> practical_marks
	    {
		    get { return _practical_marks; }
		    set { _practical_marks = value; }
	    }
	    private Nullable<decimal>  _practical_pass_marks;
	    public Nullable<decimal> practical_pass_marks
	    {
		    get { return _practical_pass_marks; }
		    set { _practical_pass_marks = value; }
	    }
	    private Nullable<decimal>  _result_marks;
	    public Nullable<decimal> result_marks
	    {
		    get { return _result_marks; }
		    set { _result_marks = value; }
	    }
	    private Nullable<decimal>  _class_test_marks;
	    public Nullable<decimal> class_test_marks
	    {
		    get { return _class_test_marks; }
		    set { _class_test_marks = value; }
	    }
	    private Nullable<decimal>  _class_test_pass_marks;
	    public Nullable<decimal> class_test_pass_marks
	    {
		    get { return _class_test_pass_marks; }
		    set { _class_test_pass_marks = value; }
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
        public ExamMarksAssignBO()
	    { }
    }
}
