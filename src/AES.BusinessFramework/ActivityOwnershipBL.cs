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
	public class ActivityOwnershipBL
	{
		private ActivityOwnershipDAO objActivityOwnershipDAO = null;

		public ActivityOwnership SelectActivityOwnership(ActivityOwnership objActivityOwnership)
		{
			objActivityOwnershipDAO= new ActivityOwnershipDAO();
			objActivityOwnership = objActivityOwnershipDAO.SelectActivityOwnership(objActivityOwnership);
			return objActivityOwnership;
		}

		public ActivityOwnership InsertActivityOwnership(ActivityOwnership objActivityOwnership)
		{
			objActivityOwnershipDAO= new ActivityOwnershipDAO();
			objActivityOwnership = objActivityOwnershipDAO.InsertActivityOwnership(objActivityOwnership);
			return objActivityOwnership;
		}

		public ActivityOwnership UpdateActivityOwnership(ActivityOwnership objActivityOwnership)
		{
			objActivityOwnershipDAO= new ActivityOwnershipDAO();
			objActivityOwnership = objActivityOwnershipDAO.UpdateActivityOwnership(objActivityOwnership);
			return objActivityOwnership;
		}

		public ActivityOwnership ActivateDeactivateActivityOwnership(ActivityOwnership objActivityOwnership)
		{
			objActivityOwnershipDAO= new ActivityOwnershipDAO();
			objActivityOwnership = objActivityOwnershipDAO.ActivateDeactivateActivityOwnership(objActivityOwnership);
			return objActivityOwnership;
		}

		public ActivityOwnership SelectRecordById(ActivityOwnership objActivityOwnership)
		{
			objActivityOwnershipDAO = new ActivityOwnershipDAO();
			objActivityOwnership = objActivityOwnershipDAO.SelectRecordById(objActivityOwnership);
			if (!Convert.ToBoolean(objActivityOwnership.IsRecordChanged)
					&& objActivityOwnership.DbOperationStatus==CommonConstant.SUCCEED)
			{
				objActivityOwnership.ConvertToObjectFromDataset(1);
			}
			return objActivityOwnership ;
		}
	}
}
