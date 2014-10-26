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
	public class RoleResourceMappingBL
	{
		private RoleResourceMappingDAO objRoleResourceMappingDAO = null;

		public RoleResourceMapping SelectRoleResourceMapping(RoleResourceMapping objRoleResourceMapping)
		{
			objRoleResourceMappingDAO= new RoleResourceMappingDAO();
			objRoleResourceMapping = objRoleResourceMappingDAO.SelectRoleResourceMapping(objRoleResourceMapping);
			return objRoleResourceMapping;
		}

		public RoleResourceMapping InsertRoleResourceMapping(RoleResourceMapping objRoleResourceMapping)
		{
			objRoleResourceMappingDAO= new RoleResourceMappingDAO();
			objRoleResourceMapping = objRoleResourceMappingDAO.InsertRoleResourceMapping(objRoleResourceMapping);
			return objRoleResourceMapping;
		}

		public RoleResourceMapping UpdateRoleResourceMapping(RoleResourceMapping objRoleResourceMapping)
		{
			objRoleResourceMappingDAO= new RoleResourceMappingDAO();
			objRoleResourceMapping = objRoleResourceMappingDAO.UpdateRoleResourceMapping(objRoleResourceMapping);
			return objRoleResourceMapping;
		}

		public RoleResourceMapping ActivateDeactivateRoleResourceMapping(RoleResourceMapping objRoleResourceMapping)
		{
			objRoleResourceMappingDAO= new RoleResourceMappingDAO();
			objRoleResourceMapping = objRoleResourceMappingDAO.ActivateDeactivateRoleResourceMapping(objRoleResourceMapping);
			return objRoleResourceMapping;
		}

		public RoleResourceMapping SelectRecordById(RoleResourceMapping objRoleResourceMapping)
		{
			objRoleResourceMappingDAO = new RoleResourceMappingDAO();
			objRoleResourceMapping = objRoleResourceMappingDAO.SelectRecordById(objRoleResourceMapping);
			if (!Convert.ToBoolean(objRoleResourceMapping.IsRecordChanged)
					&& objRoleResourceMapping.DbOperationStatus==CommonConstant.SUCCEED)
			{
				objRoleResourceMapping.ConvertToObjectFromDataset(1);
			}
			return objRoleResourceMapping ;
		}
	}
}
