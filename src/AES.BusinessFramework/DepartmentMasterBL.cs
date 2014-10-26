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
	public class DepartmentMasterBL
	{
		private DepartmentMasterDAO objDepartmentMasterDAO = null;

		public DepartmentMaster SelectDepartmentMaster(DepartmentMaster objDepartmentMaster)
		{
			objDepartmentMasterDAO= new DepartmentMasterDAO();
			objDepartmentMaster = objDepartmentMasterDAO.SelectDepartmentMaster(objDepartmentMaster);
			return objDepartmentMaster;
		}

		public DepartmentMaster InsertDepartmentMaster(DepartmentMaster objDepartmentMaster)
		{
			objDepartmentMasterDAO= new DepartmentMasterDAO();
			objDepartmentMaster = objDepartmentMasterDAO.InsertDepartmentMaster(objDepartmentMaster);
			return objDepartmentMaster;
		}

		public DepartmentMaster UpdateDepartmentMaster(DepartmentMaster objDepartmentMaster)
		{
			objDepartmentMasterDAO= new DepartmentMasterDAO();
			objDepartmentMaster = objDepartmentMasterDAO.UpdateDepartmentMaster(objDepartmentMaster);
			return objDepartmentMaster;
		}

		public DepartmentMaster ActivateDeactivateDepartmentMaster(DepartmentMaster objDepartmentMaster)
		{
			objDepartmentMasterDAO= new DepartmentMasterDAO();
			objDepartmentMaster = objDepartmentMasterDAO.ActivateDeactivateDepartmentMaster(objDepartmentMaster);
			return objDepartmentMaster;
		}

		public DepartmentMaster SelectRecordById(DepartmentMaster objDepartmentMaster)
		{
			objDepartmentMasterDAO = new DepartmentMasterDAO();
			objDepartmentMaster = objDepartmentMasterDAO.SelectRecordById(objDepartmentMaster);
			if (!Convert.ToBoolean(objDepartmentMaster.IsRecordChanged)
					&& objDepartmentMaster.DbOperationStatus==CommonConstant.SUCCEED)
			{
				objDepartmentMaster.ConvertToObjectFromDataset(1);
			}
			return objDepartmentMaster ;
		}
	}
}
