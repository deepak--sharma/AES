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
	public class RoleManagementBL
	{
		private RoleManagementDAO objRoleManagementDAO = null;

		public RoleManagement SelectRoleManagement(RoleManagement objRoleManagement)
		{
			objRoleManagementDAO= new RoleManagementDAO();
			objRoleManagement = objRoleManagementDAO.SelectRoleManagement(objRoleManagement);
			return objRoleManagement;
		}

		public RoleManagement InsertRoleManagement(RoleManagement objRoleManagement)
		{
			objRoleManagementDAO= new RoleManagementDAO();
			objRoleManagement = objRoleManagementDAO.InsertRoleManagement(objRoleManagement);
			return objRoleManagement;
		}

		public RoleManagement UpdateRoleManagement(RoleManagement objRoleManagement)
		{
			objRoleManagementDAO= new RoleManagementDAO();
			objRoleManagement = objRoleManagementDAO.UpdateRoleManagement(objRoleManagement);
			return objRoleManagement;
		}

		public RoleManagement ActivateDeactivateRoleManagement(RoleManagement objRoleManagement)
		{
			objRoleManagementDAO= new RoleManagementDAO();
			objRoleManagement = objRoleManagementDAO.ActivateDeactivateRoleManagement(objRoleManagement);
			return objRoleManagement;
		}

		public RoleManagement SelectRecordById(RoleManagement objRoleManagement)
		{
			objRoleManagementDAO = new RoleManagementDAO();
			objRoleManagement = objRoleManagementDAO.SelectRecordById(objRoleManagement);
			if (!Convert.ToBoolean(objRoleManagement.IsRecordChanged)
					&& objRoleManagement.DbOperationStatus==CommonConstant.SUCCEED)
			{
				objRoleManagement.ConvertToObjectFromDataset(1);
			}
			return objRoleManagement ;
		}
	}
}
