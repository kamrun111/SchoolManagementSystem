using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SchoolManagementSystem.BusinessObjects;
using SchoolManagementSystem.DAL;

namespace SchoolManagementSystem.BLL
{
    public class SettingBLL
    {
        private SettingDAL _settingDAL;

		public SettingDAL settingDAL
		{
			get { return _settingDAL; }
			set { _settingDAL = value; }
		}

        public SettingBLL()
		{
			settingDAL = new SettingDAL();
		}
        public int SettingADD(SettingBO settingBO)
        {
            try
            {
                return settingDAL.SettingADD(settingBO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int SettingUpdate(SettingBO settingBO)
        {
            try
            {
                return settingDAL.SettingUpdate(settingBO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
