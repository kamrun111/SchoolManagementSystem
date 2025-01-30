using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SchoolManagementSystem.BusinessObjects;
using SchoolManagementSystem.DAL;

namespace SchoolManagementSystem.BLL
{
    public class StuffBLL
    {
        private StuffDAL _stuffDAL;

        public StuffDAL stuffDAL
		{
            get { return _stuffDAL; }
            set { _stuffDAL = value; }
		}

        public StuffBLL()
		{
            stuffDAL = new StuffDAL();
		}
        public int StuffAdd(StuffBO stuffBO)
        {
            try
            {
                return stuffDAL.StuffAdd(stuffBO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int StuffUpdate(StuffBO stuffBO)
        {
            try
            {
                return stuffDAL.StuffUpdate(stuffBO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
