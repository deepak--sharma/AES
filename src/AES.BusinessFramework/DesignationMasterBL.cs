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
	public class DesignationMasterBL
	{
		private DesignationMasterDAO objDesignationMasterDAO = null;

		public DesignationMaster SelectDesignationMaster(DesignationMaster objDesignationMaster)
		{
			objDesignationMasterDAO= new DesignationMasterDAO();
			objDesignationMaster = objDesignationMasterDAO.SelectDesignationMaster(objDesignationMaster);
			return objDesignationMaster;
		}

		public DesignationMaster InsertDesignationMaster(DesignationMaster objDesignationMaster)
		{
			objDesignationMasterDAO= new DesignationMasterDAO();
			objDesignationMaster = objDesignationMasterDAO.InsertDesignationMaster(objDesignationMaster);
			return objDesignationMaster;
		}

		public DesignationMaster UpdateDesignationMaster(DesignationMaster objDesignationMaster)
		{
			objDesignationMasterDAO= new DesignationMasterDAO();
			objDesignationMaster = objDesignationMasterDAO.UpdateDesignationMaster(objDesignationMaster);
			return objDesignationMaster;
		}

		public DesignationMaster ActivateDeactivateDesignationMaster(DesignationMaster objDesignationMaster)
		{
			objDesignationMasterDAO= new DesignationMasterDAO();
			objDesignationMaster = objDesignationMasterDAO.ActivateDeactivateDesignationMaster(objDesignationMaster);
			return objDesignationMaster;
		}

		public DesignationMaster SelectRecordById(DesignationMaster objDesignationMaster)
		{
			objDesignationMasterDAO = new DesignationMasterDAO();
			objDesignationMaster = objDesignationMasterDAO.SelectRecordById(objDesignationMaster);
			if (!Convert.ToBoolean(objDesignationMaster.IsRecordChanged)
					&& objDesignationMaster.DbOperationStatus==CommonConstant.SUCCEED)
			{
				objDesignationMaster.ConvertToObjectFromDataset(1);
			}
			return objDesignationMaster ;
		}
	}
}
