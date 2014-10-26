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
	public class DivisionMasterBL
	{
		private DivisionMasterDAO objDivisionMasterDAO = null;

		public DivisionMaster SelectDivisionMaster(DivisionMaster objDivisionMaster)
		{
			objDivisionMasterDAO= new DivisionMasterDAO();
			objDivisionMaster = objDivisionMasterDAO.SelectDivisionMaster(objDivisionMaster);
			return objDivisionMaster;
		}

		public DivisionMaster InsertDivisionMaster(DivisionMaster objDivisionMaster)
		{
			objDivisionMasterDAO= new DivisionMasterDAO();
			objDivisionMaster = objDivisionMasterDAO.InsertDivisionMaster(objDivisionMaster);
			return objDivisionMaster;
		}

		public DivisionMaster UpdateDivisionMaster(DivisionMaster objDivisionMaster)
		{
			objDivisionMasterDAO= new DivisionMasterDAO();
			objDivisionMaster = objDivisionMasterDAO.UpdateDivisionMaster(objDivisionMaster);
			return objDivisionMaster;
		}

		public DivisionMaster ActivateDeactivateDivisionMaster(DivisionMaster objDivisionMaster)
		{
			objDivisionMasterDAO= new DivisionMasterDAO();
			objDivisionMaster = objDivisionMasterDAO.ActivateDeactivateDivisionMaster(objDivisionMaster);
			return objDivisionMaster;
		}

		public DivisionMaster SelectRecordById(DivisionMaster objDivisionMaster)
		{
			objDivisionMasterDAO = new DivisionMasterDAO();
			objDivisionMaster = objDivisionMasterDAO.SelectRecordById(objDivisionMaster);
			if (!Convert.ToBoolean(objDivisionMaster.IsRecordChanged)
					&& objDivisionMaster.DbOperationStatus==CommonConstant.SUCCEED)
			{
				objDivisionMaster.ConvertToObjectFromDataset(1);
			}
			return objDivisionMaster ;
		}
	}
}
