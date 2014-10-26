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
	public class GradeMasterBL
	{
		private GradeMasterDAO objGradeMasterDAO = null;

		public GradeMaster SelectGradeMaster(GradeMaster objGradeMaster)
		{
			objGradeMasterDAO= new GradeMasterDAO();
			objGradeMaster = objGradeMasterDAO.SelectGradeMaster(objGradeMaster);
			return objGradeMaster;
		}

		public GradeMaster InsertGradeMaster(GradeMaster objGradeMaster)
		{
			objGradeMasterDAO= new GradeMasterDAO();
			objGradeMaster = objGradeMasterDAO.InsertGradeMaster(objGradeMaster);
			return objGradeMaster;
		}

		public GradeMaster UpdateGradeMaster(GradeMaster objGradeMaster)
		{
			objGradeMasterDAO= new GradeMasterDAO();
			objGradeMaster = objGradeMasterDAO.UpdateGradeMaster(objGradeMaster);
			return objGradeMaster;
		}

		public GradeMaster ActivateDeactivateGradeMaster(GradeMaster objGradeMaster)
		{
			objGradeMasterDAO= new GradeMasterDAO();
			objGradeMaster = objGradeMasterDAO.ActivateDeactivateGradeMaster(objGradeMaster);
			return objGradeMaster;
		}

		public GradeMaster SelectRecordById(GradeMaster objGradeMaster)
		{
			objGradeMasterDAO = new GradeMasterDAO();
			objGradeMaster = objGradeMasterDAO.SelectRecordById(objGradeMaster);
			if (!Convert.ToBoolean(objGradeMaster.IsRecordChanged)
					&& objGradeMaster.DbOperationStatus==CommonConstant.SUCCEED)
			{
				objGradeMaster.ConvertToObjectFromDataset(1);
			}
			return objGradeMaster ;
		}
	}
}
