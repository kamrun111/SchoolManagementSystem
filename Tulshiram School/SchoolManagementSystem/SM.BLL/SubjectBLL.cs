using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SchoolManagementSystem.BusinessObjects;
using SchoolManagementSystem.DAL;

namespace SchoolManagementSystem.BLL
{
    public class SubjectBLL
    {
        private SubjectDAL _subjectDAL;

        public SubjectDAL subjectDAL
		{
            get { return _subjectDAL; }
            set { _subjectDAL = value; }
		}

        public SubjectBLL()
		{
            subjectDAL = new SubjectDAL();
		}


        public int SubjectADD(SubjectBO subjectBO)
        {
            try
            {
                return subjectDAL.SubjectADD(subjectBO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int SubjectUpdate(SubjectBO subjectBO)
        {
            try
            {
                return subjectDAL.SubjectUpdate(subjectBO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
