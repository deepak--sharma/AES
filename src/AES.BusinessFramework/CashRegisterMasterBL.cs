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
	public class CashRegisterMasterBL
	{
		private CashRegisterMasterDAO objCashRegisterMasterDAO = null;

		public CashRegisterMaster SelectCashRegisterMaster(CashRegisterMaster objCashRegisterMaster)
		{
			objCashRegisterMasterDAO= new CashRegisterMasterDAO();
			objCashRegisterMaster = objCashRegisterMasterDAO.SelectCashRegisterMaster(objCashRegisterMaster);
			return objCashRegisterMaster;
		}

		public CashRegisterMaster InsertCashRegisterMaster(CashRegisterMaster objCashRegisterMaster)
		{
			objCashRegisterMasterDAO= new CashRegisterMasterDAO();
			objCashRegisterMaster = objCashRegisterMasterDAO.InsertCashRegisterMaster(objCashRegisterMaster);
			return objCashRegisterMaster;
		}

		public CashRegisterMaster UpdateCashRegisterMaster(CashRegisterMaster objCashRegisterMaster)
		{
			objCashRegisterMasterDAO= new CashRegisterMasterDAO();
			objCashRegisterMaster = objCashRegisterMasterDAO.UpdateCashRegisterMaster(objCashRegisterMaster);
			return objCashRegisterMaster;
		}

		public CashRegisterMaster ActivateDeactivateCashRegisterMaster(CashRegisterMaster objCashRegisterMaster)
		{
			objCashRegisterMasterDAO= new CashRegisterMasterDAO();
			objCashRegisterMaster = objCashRegisterMasterDAO.ActivateDeactivateCashRegisterMaster(objCashRegisterMaster);
			return objCashRegisterMaster;
		}

		public CashRegisterMaster SelectRecordById(CashRegisterMaster objCashRegisterMaster)
		{
			objCashRegisterMasterDAO = new CashRegisterMasterDAO();
			objCashRegisterMaster = objCashRegisterMasterDAO.SelectRecordById(objCashRegisterMaster);
			if (!Convert.ToBoolean(objCashRegisterMaster.IsRecordChanged)
					&& objCashRegisterMaster.DbOperationStatus==CommonConstant.SUCCEED)
			{
				objCashRegisterMaster.ConvertToObjectFromDataset(1);
			}
			return objCashRegisterMaster ;
		}
	}
}
