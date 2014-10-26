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
	public class RackMasterBL
	{
		private RackMasterDAO objRackMasterDAO = null;

		public RackMaster SelectRackMaster(RackMaster objRackMaster)
		{
			objRackMasterDAO= new RackMasterDAO();
			objRackMaster = objRackMasterDAO.SelectRackMaster(objRackMaster);
			return objRackMaster;
		}

		public RackMaster InsertRackMaster(RackMaster objRackMaster)
		{
			objRackMasterDAO= new RackMasterDAO();
			objRackMaster = objRackMasterDAO.InsertRackMaster(objRackMaster);
			return objRackMaster;
		}

		public RackMaster UpdateRackMaster(RackMaster objRackMaster)
		{
			objRackMasterDAO= new RackMasterDAO();
			objRackMaster = objRackMasterDAO.UpdateRackMaster(objRackMaster);
			return objRackMaster;
		}

		public RackMaster ActivateDeactivateRackMaster(RackMaster objRackMaster)
		{
			objRackMasterDAO= new RackMasterDAO();
			objRackMaster = objRackMasterDAO.ActivateDeactivateRackMaster(objRackMaster);
			return objRackMaster;
		}

		public RackMaster SelectRecordById(RackMaster objRackMaster)
		{
			objRackMasterDAO = new RackMasterDAO();
			objRackMaster = objRackMasterDAO.SelectRecordById(objRackMaster);
			if (!Convert.ToBoolean(objRackMaster.IsRecordChanged)
					&& objRackMaster.DbOperationStatus==CommonConstant.SUCCEED)
			{
				objRackMaster.ConvertToObjectFromDataset(1);
			}
			return objRackMaster ;
		}
	}
}
