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
	public class UserManagementBL
	{
		private UserManagementDAO objUserManagementDAO = null;

		public UserManagement SelectUserManagement(UserManagement objUserManagement)
		{
			objUserManagementDAO= new UserManagementDAO();
			objUserManagement = objUserManagementDAO.SelectUserManagement(objUserManagement);
			return objUserManagement;
		}

		public UserManagement InsertUserManagement(UserManagement objUserManagement)
		{
			objUserManagementDAO= new UserManagementDAO();
			objUserManagement = objUserManagementDAO.InsertUserManagement(objUserManagement);
			return objUserManagement;
		}

		public UserManagement UpdateUserManagement(UserManagement objUserManagement)
		{
			objUserManagementDAO= new UserManagementDAO();
			objUserManagement = objUserManagementDAO.UpdateUserManagement(objUserManagement);
			return objUserManagement;
		}

		public UserManagement ActivateDeactivateUserManagement(UserManagement objUserManagement)
		{
			objUserManagementDAO= new UserManagementDAO();
			objUserManagement = objUserManagementDAO.ActivateDeactivateUserManagement(objUserManagement);
			return objUserManagement;
		}

		public UserManagement SelectRecordById(UserManagement objUserManagement)
		{
			objUserManagementDAO = new UserManagementDAO();
			objUserManagement = objUserManagementDAO.SelectRecordById(objUserManagement);
			if (!Convert.ToBoolean(objUserManagement.IsRecordChanged)
					&& objUserManagement.DbOperationStatus==CommonConstant.SUCCEED)
			{
				objUserManagement.ConvertToObjectFromDataset(1);
			}
			return objUserManagement ;
		}
	}
}
