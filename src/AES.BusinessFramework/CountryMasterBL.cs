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
	public class CountryMasterBL
	{
		private CountryMasterDAO objCountryMasterDAO = null;

		public CountryMaster SelectCountryMaster(CountryMaster objCountryMaster)
		{
			objCountryMasterDAO= new CountryMasterDAO();
			objCountryMaster = objCountryMasterDAO.SelectCountryMaster(objCountryMaster);
			return objCountryMaster;
		}

		public CountryMaster InsertCountryMaster(CountryMaster objCountryMaster)
		{
			objCountryMasterDAO= new CountryMasterDAO();
			objCountryMaster = objCountryMasterDAO.InsertCountryMaster(objCountryMaster);
			return objCountryMaster;
		}

		public CountryMaster UpdateCountryMaster(CountryMaster objCountryMaster)
		{
			objCountryMasterDAO= new CountryMasterDAO();
			objCountryMaster = objCountryMasterDAO.UpdateCountryMaster(objCountryMaster);
			return objCountryMaster;
		}

		public CountryMaster ActivateDeactivateCountryMaster(CountryMaster objCountryMaster)
		{
			objCountryMasterDAO= new CountryMasterDAO();
			objCountryMaster = objCountryMasterDAO.ActivateDeactivateCountryMaster(objCountryMaster);
			return objCountryMaster;
		}

		public CountryMaster SelectRecordById(CountryMaster objCountryMaster)
		{
			objCountryMasterDAO = new CountryMasterDAO();
			objCountryMaster = objCountryMasterDAO.SelectRecordById(objCountryMaster);
			if (!Convert.ToBoolean(objCountryMaster.IsRecordChanged)
					&& objCountryMaster.DbOperationStatus==CommonConstant.SUCCEED)
			{
				objCountryMaster.ConvertToObjectFromDataset(1);
			}
			return objCountryMaster ;
		}
	}
}
