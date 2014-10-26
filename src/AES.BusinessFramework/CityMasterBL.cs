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
	public class CityMasterBL
	{
		private CityMasterDAO objCityMasterDAO = null;

		public CityMaster SelectCityMaster(CityMaster objCityMaster)
		{
			objCityMasterDAO= new CityMasterDAO();
			objCityMaster = objCityMasterDAO.SelectCityMaster(objCityMaster);
			return objCityMaster;
		}

		public CityMaster InsertCityMaster(CityMaster objCityMaster)
		{
			objCityMasterDAO= new CityMasterDAO();
			objCityMaster = objCityMasterDAO.InsertCityMaster(objCityMaster);
			return objCityMaster;
		}

		public CityMaster UpdateCityMaster(CityMaster objCityMaster)
		{
			objCityMasterDAO= new CityMasterDAO();
			objCityMaster = objCityMasterDAO.UpdateCityMaster(objCityMaster);
			return objCityMaster;
		}

		public CityMaster ActivateDeactivateCityMaster(CityMaster objCityMaster)
		{
			objCityMasterDAO= new CityMasterDAO();
			objCityMaster = objCityMasterDAO.ActivateDeactivateCityMaster(objCityMaster);
			return objCityMaster;
		}

		public CityMaster SelectRecordById(CityMaster objCityMaster)
		{
			objCityMasterDAO = new CityMasterDAO();
			objCityMaster = objCityMasterDAO.SelectRecordById(objCityMaster);
			if (!Convert.ToBoolean(objCityMaster.IsRecordChanged)
					&& objCityMaster.DbOperationStatus==CommonConstant.SUCCEED)
			{
				objCityMaster.ConvertToObjectFromDataset(1);
			}
			return objCityMaster ;
		}
	}
}
