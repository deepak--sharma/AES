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
	public class FeeSetupBL
	{
		private FeeSetupDAO objFeeSetupDAO = null;

		public FeeSetup SelectFeeSetup(FeeSetup objFeeSetup)
		{
			objFeeSetupDAO= new FeeSetupDAO();
			objFeeSetup = objFeeSetupDAO.SelectFeeSetup(objFeeSetup);
			return objFeeSetup;
		}

        public FeeSetup SelectFeeSetupSchema(FeeSetup objFeeSetup)
        {
            objFeeSetupDAO = new FeeSetupDAO();
            objFeeSetup = objFeeSetupDAO.SelectFeeSetupSchema(objFeeSetup);
            return objFeeSetup;
        }

		public FeeSetup SubmitFeeSetupData(FeeSetup objFeeSetup)
		{
			objFeeSetupDAO= new FeeSetupDAO();
			objFeeSetup = objFeeSetupDAO.SubmitFeeSetupData(objFeeSetup);
			return objFeeSetup;
		}

	}
}
