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
	public class FeeMasterBL
	{
		private FeeMasterDAO objFeeMasterDAO = null;

		public FeeMaster SelectFeeMaster(FeeMaster objFeeMaster)
		{
			objFeeMasterDAO= new FeeMasterDAO();
			objFeeMaster = objFeeMasterDAO.SelectFeeMaster(objFeeMaster);
			return objFeeMaster;
		}

		public FeeMaster InsertFeeMaster(FeeMaster objFeeMaster)
		{
			objFeeMasterDAO= new FeeMasterDAO();
			objFeeMaster = objFeeMasterDAO.InsertFeeMaster(objFeeMaster);
			return objFeeMaster;
		}

		public FeeMaster UpdateFeeMaster(FeeMaster objFeeMaster)
		{
			objFeeMasterDAO= new FeeMasterDAO();
			objFeeMaster = objFeeMasterDAO.UpdateFeeMaster(objFeeMaster);
			return objFeeMaster;
		}

		public FeeMaster ActivateDeactivateFeeMaster(FeeMaster objFeeMaster)
		{
			objFeeMasterDAO= new FeeMasterDAO();
			objFeeMaster = objFeeMasterDAO.ActivateDeactivateFeeMaster(objFeeMaster);
			return objFeeMaster;
		}

		public FeeMaster SelectRecordById(FeeMaster objFeeMaster)
		{
			objFeeMasterDAO = new FeeMasterDAO();
			objFeeMaster = objFeeMasterDAO.SelectRecordById(objFeeMaster);
			if (!Convert.ToBoolean(objFeeMaster.IsRecordChanged)
					&& objFeeMaster.DbOperationStatus==CommonConstant.SUCCEED)
			{
				objFeeMaster.ConvertToObjectFromDataset(1);
			}
			return objFeeMaster ;
		}
	}
}
