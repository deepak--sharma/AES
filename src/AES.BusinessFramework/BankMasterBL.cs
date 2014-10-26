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
	public class BankMasterBL
	{
		private BankMasterDAO objBankMasterDAO = null;

		public BankMaster SelectBankMaster(BankMaster objBankMaster)
		{
			objBankMasterDAO= new BankMasterDAO();
			objBankMaster = objBankMasterDAO.SelectBankMaster(objBankMaster);
			return objBankMaster;
		}

		public BankMaster InsertBankMaster(BankMaster objBankMaster)
		{
			objBankMasterDAO= new BankMasterDAO();
			objBankMaster = objBankMasterDAO.InsertBankMaster(objBankMaster);
			return objBankMaster;
		}

		public BankMaster UpdateBankMaster(BankMaster objBankMaster)
		{
			objBankMasterDAO= new BankMasterDAO();
			objBankMaster = objBankMasterDAO.UpdateBankMaster(objBankMaster);
			return objBankMaster;
		}

		public BankMaster ActivateDeactivateBankMaster(BankMaster objBankMaster)
		{
			objBankMasterDAO= new BankMasterDAO();
			objBankMaster = objBankMasterDAO.ActivateDeactivateBankMaster(objBankMaster);
			return objBankMaster;
		}

		public BankMaster SelectRecordById(BankMaster objBankMaster)
		{
			objBankMasterDAO = new BankMasterDAO();
			objBankMaster = objBankMasterDAO.SelectRecordById(objBankMaster);
			if (!Convert.ToBoolean(objBankMaster.IsRecordChanged)
					&& objBankMaster.DbOperationStatus==CommonConstant.SUCCEED)
			{
				objBankMaster.ConvertToObjectFromDataset(1);
			}
			return objBankMaster ;
		}
	}
}
