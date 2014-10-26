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
	public class LedgerMasterBL
	{
		private LedgerMasterDAO objLedgerMasterDAO = null;

		public LedgerMaster SelectLedgerMaster(LedgerMaster objLedgerMaster)
		{
			objLedgerMasterDAO= new LedgerMasterDAO();
			objLedgerMaster = objLedgerMasterDAO.SelectLedgerMaster(objLedgerMaster);
			return objLedgerMaster;
		}

		public LedgerMaster InsertLedgerMaster(LedgerMaster objLedgerMaster)
		{
			objLedgerMasterDAO= new LedgerMasterDAO();
			objLedgerMaster = objLedgerMasterDAO.InsertLedgerMaster(objLedgerMaster);
			return objLedgerMaster;
		}

		public LedgerMaster UpdateLedgerMaster(LedgerMaster objLedgerMaster)
		{
			objLedgerMasterDAO= new LedgerMasterDAO();
			objLedgerMaster = objLedgerMasterDAO.UpdateLedgerMaster(objLedgerMaster);
			return objLedgerMaster;
		}

		public LedgerMaster ActivateDeactivateLedgerMaster(LedgerMaster objLedgerMaster)
		{
			objLedgerMasterDAO= new LedgerMasterDAO();
			objLedgerMaster = objLedgerMasterDAO.ActivateDeactivateLedgerMaster(objLedgerMaster);
			return objLedgerMaster;
		}

		public LedgerMaster SelectRecordById(LedgerMaster objLedgerMaster)
		{
			objLedgerMasterDAO = new LedgerMasterDAO();
			objLedgerMaster = objLedgerMasterDAO.SelectRecordById(objLedgerMaster);
			if (!Convert.ToBoolean(objLedgerMaster.IsRecordChanged)
					&& objLedgerMaster.DbOperationStatus==CommonConstant.SUCCEED)
			{
				objLedgerMaster.ConvertToObjectFromDataset(1);
			}
			return objLedgerMaster ;
		}
	}
}
