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
	public class ResourceManagementBL
	{
		private ResourceManagementDAO objResourceManagementDAO = null;

		public ResourceManagement SelectResourceManagement(ResourceManagement objResourceManagement)
		{
			objResourceManagementDAO= new ResourceManagementDAO();
			objResourceManagement = objResourceManagementDAO.SelectResourceManagement(objResourceManagement);
			return objResourceManagement;
		}

		public ResourceManagement InsertResourceManagement(ResourceManagement objResourceManagement)
		{
			objResourceManagementDAO= new ResourceManagementDAO();
			objResourceManagement = objResourceManagementDAO.InsertResourceManagement(objResourceManagement);
			return objResourceManagement;
		}

		public ResourceManagement UpdateResourceManagement(ResourceManagement objResourceManagement)
		{
			objResourceManagementDAO= new ResourceManagementDAO();
			objResourceManagement = objResourceManagementDAO.UpdateResourceManagement(objResourceManagement);
			return objResourceManagement;
		}

		public ResourceManagement ActivateDeactivateResourceManagement(ResourceManagement objResourceManagement)
		{
			objResourceManagementDAO= new ResourceManagementDAO();
			objResourceManagement = objResourceManagementDAO.ActivateDeactivateResourceManagement(objResourceManagement);
			return objResourceManagement;
		}

		public ResourceManagement SelectRecordById(ResourceManagement objResourceManagement)
		{
			objResourceManagementDAO = new ResourceManagementDAO();
			objResourceManagement = objResourceManagementDAO.SelectRecordById(objResourceManagement);
			if (!Convert.ToBoolean(objResourceManagement.IsRecordChanged)
					&& objResourceManagement.DbOperationStatus==CommonConstant.SUCCEED)
			{
				objResourceManagement.ConvertToObjectFromDataset(1);
			}
			return objResourceManagement ;
		}
	}
}
