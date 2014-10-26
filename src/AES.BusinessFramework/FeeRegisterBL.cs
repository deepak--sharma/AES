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
	public class FeeRegisterBL
	{
		private FeeRegisterDAO objFeeRegisterDAO = null;

		public FeeRegister SelectFeeRegister(FeeRegister objFeeRegister)
		{
			objFeeRegisterDAO= new FeeRegisterDAO();
			objFeeRegister = objFeeRegisterDAO.SelectFeeRegister(objFeeRegister);
			return objFeeRegister;
		}

		public FeeRegister InsertFeeRegister(FeeRegister objFeeRegister)
		{
			objFeeRegisterDAO= new FeeRegisterDAO();
			objFeeRegister = objFeeRegisterDAO.InsertFeeRegister(objFeeRegister);
			return objFeeRegister;
		}

		public FeeRegister UpdateFeeRegister(FeeRegister objFeeRegister)
		{
			objFeeRegisterDAO= new FeeRegisterDAO();
			objFeeRegister = objFeeRegisterDAO.UpdateFeeRegister(objFeeRegister);
			return objFeeRegister;
		}

		public FeeRegister ActivateDeactivateFeeRegister(FeeRegister objFeeRegister)
		{
			objFeeRegisterDAO= new FeeRegisterDAO();
			objFeeRegister = objFeeRegisterDAO.ActivateDeactivateFeeRegister(objFeeRegister);
			return objFeeRegister;
		}

		public FeeRegister SelectRecordById(FeeRegister objFeeRegister)
		{
			objFeeRegisterDAO = new FeeRegisterDAO();
			objFeeRegister = objFeeRegisterDAO.SelectRecordById(objFeeRegister);
			if (!Convert.ToBoolean(objFeeRegister.IsRecordChanged)
					&& objFeeRegister.DbOperationStatus==CommonConstant.SUCCEED)
			{
				objFeeRegister.ConvertToObjectFromDataset(1);
			}
			return objFeeRegister ;
		}
	}
}
