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
	public class FeeDiscountSetupBL
	{
		private FeeDiscountSetupDAO objFeeDiscountSetupDAO = null;

		public FeeDiscountSetup SelectFeeDiscountSetup(FeeDiscountSetup objFeeDiscountSetup)
		{
			objFeeDiscountSetupDAO= new FeeDiscountSetupDAO();
			objFeeDiscountSetup = objFeeDiscountSetupDAO.SelectFeeDiscountSetup(objFeeDiscountSetup);
			return objFeeDiscountSetup;
		}

		public FeeDiscountSetup InsertFeeDiscountSetup(FeeDiscountSetup objFeeDiscountSetup)
		{
			objFeeDiscountSetupDAO= new FeeDiscountSetupDAO();
			objFeeDiscountSetup = objFeeDiscountSetupDAO.InsertFeeDiscountSetup(objFeeDiscountSetup);
			return objFeeDiscountSetup;
		}

		public FeeDiscountSetup UpdateFeeDiscountSetup(FeeDiscountSetup objFeeDiscountSetup)
		{
			objFeeDiscountSetupDAO= new FeeDiscountSetupDAO();
			objFeeDiscountSetup = objFeeDiscountSetupDAO.UpdateFeeDiscountSetup(objFeeDiscountSetup);
			return objFeeDiscountSetup;
		}

		public FeeDiscountSetup ActivateDeactivateFeeDiscountSetup(FeeDiscountSetup objFeeDiscountSetup)
		{
			objFeeDiscountSetupDAO= new FeeDiscountSetupDAO();
			objFeeDiscountSetup = objFeeDiscountSetupDAO.ActivateDeactivateFeeDiscountSetup(objFeeDiscountSetup);
			return objFeeDiscountSetup;
		}

		public FeeDiscountSetup SelectRecordById(FeeDiscountSetup objFeeDiscountSetup)
		{
			objFeeDiscountSetupDAO = new FeeDiscountSetupDAO();
			objFeeDiscountSetup = objFeeDiscountSetupDAO.SelectRecordById(objFeeDiscountSetup);
			if (!Convert.ToBoolean(objFeeDiscountSetup.IsRecordChanged)
					&& objFeeDiscountSetup.DbOperationStatus==CommonConstant.SUCCEED)
			{
				objFeeDiscountSetup.ConvertToObjectFromDataset(1);
			}
			return objFeeDiscountSetup ;
		}
	}
}
