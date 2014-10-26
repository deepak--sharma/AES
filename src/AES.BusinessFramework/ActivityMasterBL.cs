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
	public class ActivityMasterBL
	{
		private ActivityMasterDAO objActivityMasterDAO = null;

		public ActivityMaster SelectActivityMaster(ActivityMaster objActivityMaster)
		{
			objActivityMasterDAO= new ActivityMasterDAO();
			objActivityMaster = objActivityMasterDAO.SelectActivityMaster(objActivityMaster);
			return objActivityMaster;
		}

		public ActivityMaster InsertActivityMaster(ActivityMaster objActivityMaster)
		{
			objActivityMasterDAO= new ActivityMasterDAO();
			objActivityMaster = objActivityMasterDAO.InsertActivityMaster(objActivityMaster);
			return objActivityMaster;
		}

		public ActivityMaster UpdateActivityMaster(ActivityMaster objActivityMaster)
		{
			objActivityMasterDAO= new ActivityMasterDAO();
			objActivityMaster = objActivityMasterDAO.UpdateActivityMaster(objActivityMaster);
			return objActivityMaster;
		}

		public ActivityMaster ActivateDeactivateActivityMaster(ActivityMaster objActivityMaster)
		{
			objActivityMasterDAO= new ActivityMasterDAO();
			objActivityMaster = objActivityMasterDAO.ActivateDeactivateActivityMaster(objActivityMaster);
			return objActivityMaster;
		}

		public ActivityMaster SelectRecordById(ActivityMaster objActivityMaster)
		{
			objActivityMasterDAO = new ActivityMasterDAO();
			objActivityMaster = objActivityMasterDAO.SelectRecordById(objActivityMaster);
			if (!Convert.ToBoolean(objActivityMaster.IsRecordChanged)
					&& objActivityMaster.DbOperationStatus==CommonConstant.SUCCEED)
			{
				objActivityMaster.ConvertToObjectFromDataset(1);
			}
			return objActivityMaster ;
		}
	}
}
