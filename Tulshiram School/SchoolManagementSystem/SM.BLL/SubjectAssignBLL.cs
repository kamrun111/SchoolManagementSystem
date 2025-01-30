using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SchoolManagementSystem.BusinessObjects;
using SchoolManagementSystem.DAL;

namespace SchoolManagementSystem.BLL
{
    public class SubjectAssignBLL
    {
        private SubjectAssignDAL _subjectAssignDAL;

        public SubjectAssignDAL subjectAssignDAL
        {
            get { return _subjectAssignDAL; }
            set { _subjectAssignDAL = value; }
        }
        public SubjectAssignBLL()
        {
            subjectAssignDAL = new SubjectAssignDAL();
        }
        public int SubjectAssignAdd(List<SubjectAssignBO> listSubjectAssignBO)
        {
            try
            {
                return subjectAssignDAL.SubjectAssignAdd(listSubjectAssignBO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
