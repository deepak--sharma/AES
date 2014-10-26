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
	public class JoiningMasterBL
	{
		private JoiningMasterDAO objJoiningMasterDAO = null;

		public JoiningMaster SelectJoiningMaster(JoiningMaster objJoiningMaster)
		{
			objJoiningMasterDAO= new JoiningMasterDAO();
			objJoiningMaster = objJoiningMasterDAO.SelectJoiningMaster(objJoiningMaster);
			return objJoiningMaster;
		}

		public JoiningMaster InsertJoiningMaster(JoiningMaster objJoiningMaster)
		{
			objJoiningMasterDAO= new JoiningMasterDAO();
			objJoiningMaster = objJoiningMasterDAO.InsertJoiningMaster(objJoiningMaster);
			return objJoiningMaster;
		}

		public JoiningMaster UpdateJoiningMaster(JoiningMaster objJoiningMaster)
		{
			objJoiningMasterDAO= new JoiningMasterDAO();
			objJoiningMaster = objJoiningMasterDAO.UpdateJoiningMaster(objJoiningMaster);
			return objJoiningMaster;
		}

		public JoiningMaster ActivateDeactivateJoiningMaster(JoiningMaster objJoiningMaster)
		{
			objJoiningMasterDAO= new JoiningMasterDAO();
			objJoiningMaster = objJoiningMasterDAO.ActivateDeactivateJoiningMaster(objJoiningMaster);
			return objJoiningMaster;
		}

		public JoiningMaster SelectRecordById(JoiningMaster objJoiningMaster)
		{
			objJoiningMasterDAO = new JoiningMasterDAO();
			objJoiningMaster = objJoiningMasterDAO.SelectRecordById(objJoiningMaster);
			if (!Convert.ToBoolean(objJoiningMaster.IsRecordChanged)
					&& objJoiningMaster.DbOperationStatus==CommonConstant.SUCCEED)
			{
				objJoiningMaster.ConvertToObjectFromDataset(1);
			}
			return objJoiningMaster ;
		}
	}
}
