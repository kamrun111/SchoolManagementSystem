using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SchoolManagementSystem.BusinessObjects;
using SchoolManagementSystem.DAL;

namespace SchoolManagementSystem.BLL
{
    public class ClassWiseSubjectBLL
    {
        private ClassWiseSubjectDAL _classWiseSubjectDAL;

        public ClassWiseSubjectDAL classWiseSubjectDAL
		{
            get { return _classWiseSubjectDAL; }
            set { _classWiseSubjectDAL = value; }
		}

        public ClassWiseSubjectBLL()
		{
            classWiseSubjectDAL = new ClassWiseSubjectDAL();
		}
        public int ClassWiseSubjectAdd(List<ClassWiseSubjectBO> listClassWiseSubjectBO)
        {
            try
            {
                return classWiseSubjectDAL.ClassWiseSubjectAdd(listClassWiseSubjectBO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
