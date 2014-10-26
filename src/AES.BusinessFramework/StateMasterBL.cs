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
	public class StateMasterBL
	{
		private StateMasterDAO objStateMasterDAO = null;

		public StateMaster SelectStateMaster(StateMaster objStateMaster)
		{
			objStateMasterDAO= new StateMasterDAO();
			objStateMaster = objStateMasterDAO.SelectStateMaster(objStateMaster);
			return objStateMaster;
		}

		public StateMaster InsertStateMaster(StateMaster objStateMaster)
		{
			objStateMasterDAO= new StateMasterDAO();
			objStateMaster = objStateMasterDAO.InsertStateMaster(objStateMaster);
			return objStateMaster;
		}

		public StateMaster UpdateStateMaster(StateMaster objStateMaster)
		{
			objStateMasterDAO= new StateMasterDAO();
			objStateMaster = objStateMasterDAO.UpdateStateMaster(objStateMaster);
			return objStateMaster;
		}

		public StateMaster ActivateDeactivateStateMaster(StateMaster objStateMaster)
		{
			objStateMasterDAO= new StateMasterDAO();
			objStateMaster = objStateMasterDAO.ActivateDeactivateStateMaster(objStateMaster);
			return objStateMaster;
		}

		public StateMaster SelectRecordById(StateMaster objStateMaster)
		{
			objStateMasterDAO = new StateMasterDAO();
			objStateMaster = objStateMasterDAO.SelectRecordById(objStateMaster);
			if (!Convert.ToBoolean(objStateMaster.IsRecordChanged)
					&& objStateMaster.DbOperationStatus==CommonConstant.SUCCEED)
			{
				objStateMaster.ConvertToObjectFromDataset(1);
			}
			return objStateMaster ;
		}
	}
}
