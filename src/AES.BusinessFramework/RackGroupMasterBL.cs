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
	public class RackGroupMasterBL
	{
		private RackGroupMasterDAO objRackGroupMasterDAO = null;

		public RackGroupMaster SelectRackGroupMaster(RackGroupMaster objRackGroupMaster)
		{
			objRackGroupMasterDAO= new RackGroupMasterDAO();
			objRackGroupMaster = objRackGroupMasterDAO.SelectRackGroupMaster(objRackGroupMaster);
			return objRackGroupMaster;
		}

		public RackGroupMaster InsertRackGroupMaster(RackGroupMaster objRackGroupMaster)
		{
			objRackGroupMasterDAO= new RackGroupMasterDAO();
			objRackGroupMaster = objRackGroupMasterDAO.InsertRackGroupMaster(objRackGroupMaster);
			return objRackGroupMaster;
		}

		public RackGroupMaster UpdateRackGroupMaster(RackGroupMaster objRackGroupMaster)
		{
			objRackGroupMasterDAO= new RackGroupMasterDAO();
			objRackGroupMaster = objRackGroupMasterDAO.UpdateRackGroupMaster(objRackGroupMaster);
			return objRackGroupMaster;
		}

		public RackGroupMaster ActivateDeactivateRackGroupMaster(RackGroupMaster objRackGroupMaster)
		{
			objRackGroupMasterDAO= new RackGroupMasterDAO();
			objRackGroupMaster = objRackGroupMasterDAO.ActivateDeactivateRackGroupMaster(objRackGroupMaster);
			return objRackGroupMaster;
		}

		public RackGroupMaster SelectRecordById(RackGroupMaster objRackGroupMaster)
		{
			objRackGroupMasterDAO = new RackGroupMasterDAO();
			objRackGroupMaster = objRackGroupMasterDAO.SelectRecordById(objRackGroupMaster);
			if (!Convert.ToBoolean(objRackGroupMaster.IsRecordChanged)
					&& objRackGroupMaster.DbOperationStatus==CommonConstant.SUCCEED)
			{
				objRackGroupMaster.ConvertToObjectFromDataset(1);
			}
			return objRackGroupMaster ;
		}
	}
}
