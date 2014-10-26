using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;
using AES.SolutionFramework;
using AES.DataFramework;
using AES.ObjectFramework;

namespace AES.BusinessFramework
{
	public class UserRoleMappingBL
	{
		private UserRoleMappingDAO objUserRoleMappingDAO = null;

		public UserRoleMapping SelectUserRoleMapping(UserRoleMapping objUserRoleMapping)
		{
			objUserRoleMappingDAO= new UserRoleMappingDAO();
			objUserRoleMapping = objUserRoleMappingDAO.SelectUserRoleMapping(objUserRoleMapping);
			return objUserRoleMapping;
		}

		public UserRoleMapping InsertUserRoleMapping(UserRoleMapping objUserRoleMapping)
		{
			objUserRoleMappingDAO= new UserRoleMappingDAO();
			objUserRoleMapping = objUserRoleMappingDAO.InsertUserRoleMapping(objUserRoleMapping);
			return objUserRoleMapping;
		}

		public UserRoleMapping UpdateUserRoleMapping(UserRoleMapping objUserRoleMapping)
		{
			objUserRoleMappingDAO= new UserRoleMappingDAO();
			objUserRoleMapping = objUserRoleMappingDAO.UpdateUserRoleMapping(objUserRoleMapping);
			return objUserRoleMapping;
		}

		public UserRoleMapping ActivateDeactivateUserRoleMapping(UserRoleMapping objUserRoleMapping)
		{
			objUserRoleMappingDAO= new UserRoleMappingDAO();
			objUserRoleMapping = objUserRoleMappingDAO.ActivateDeactivateUserRoleMapping(objUserRoleMapping);
			return objUserRoleMapping;
		}

		public UserRoleMapping SelectRecordById(UserRoleMapping objUserRoleMapping)
		{
			objUserRoleMappingDAO = new UserRoleMappingDAO();
			objUserRoleMapping = objUserRoleMappingDAO.SelectRecordById(objUserRoleMapping);
			if (!Convert.ToBoolean(objUserRoleMapping.IsRecordChanged)
					&& objUserRoleMapping.DbOperationStatus==CommonConstant.SUCCEED)
			{
				objUserRoleMapping.ConvertToObjectFromDataset(1);
			}
			return objUserRoleMapping ;
		}
	}
}
