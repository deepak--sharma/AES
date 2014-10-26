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
	public class GroupMasterBL
	{
		private GroupMasterDAO objGroupMasterDAO = null;

		public GroupMaster SelectGroupMaster(GroupMaster objGroupMaster)
		{
			objGroupMasterDAO= new GroupMasterDAO();
			objGroupMaster = objGroupMasterDAO.SelectGroupMaster(objGroupMaster);
			return objGroupMaster;
		}

		public GroupMaster InsertGroupMaster(GroupMaster objGroupMaster)
		{
			objGroupMasterDAO= new GroupMasterDAO();
			objGroupMaster = objGroupMasterDAO.InsertGroupMaster(objGroupMaster);
			return objGroupMaster;
		}

		public GroupMaster UpdateGroupMaster(GroupMaster objGroupMaster)
		{
			objGroupMasterDAO= new GroupMasterDAO();
			objGroupMaster = objGroupMasterDAO.UpdateGroupMaster(objGroupMaster);
			return objGroupMaster;
		}

		public GroupMaster ActivateDeactivateGroupMaster(GroupMaster objGroupMaster)
		{
			objGroupMasterDAO= new GroupMasterDAO();
			objGroupMaster = objGroupMasterDAO.ActivateDeactivateGroupMaster(objGroupMaster);
			return objGroupMaster;
		}

		public GroupMaster SelectRecordById(GroupMaster objGroupMaster)
		{
			objGroupMasterDAO = new GroupMasterDAO();
			objGroupMaster = objGroupMasterDAO.SelectRecordById(objGroupMaster);
			if (!Convert.ToBoolean(objGroupMaster.IsRecordChanged)
					&& objGroupMaster.DbOperationStatus==CommonConstant.SUCCEED)
			{
				objGroupMaster.ConvertToObjectFromDataset(1);
			}
			return objGroupMaster ;
		}
	}
}
