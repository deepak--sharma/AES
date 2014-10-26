using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SolutionFramework.EventLogger;
using AES.SolutionFramework;
using AES.ObjectFramework;

namespace AES.DataFramework
{
	public class CountryMasterDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "COUNTRY_MASTER";
		private string strSelectCountryMaster = "UDSP_SELECT_COUNTRY_MASTER";
		private string strInsertCountryMaster = "UDSP_INSERT_COUNTRY_MASTER";
		private string strUpdateCountryMaster = "UDSP_UPDATE_COUNTRY_MASTER";
		private string dbExecuteStatus = "";

		public CountryMaster SelectCountryMaster(CountryMaster objCountryMaster)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_COUNTRY_MASTER.COUNTRY_ID_PARAM(objParameterList , objCountryMaster.CountryId);
			UDSP_SELECT_COUNTRY_MASTER.COUNTRY_NAME_PARAM(objParameterList , objCountryMaster.CountryName);
			UDSP_SELECT_COUNTRY_MASTER.DESCRIPTION_PARAM(objParameterList , objCountryMaster.Description);
			UDSP_SELECT_COUNTRY_MASTER.RECORD_STATUS_PARAM(objParameterList , objCountryMaster.RecordStatus);
			try
			{
				Logger.LogInfo("CountryMasterDAO.cs : SelectCountryMaster() is started.");
				objCountryMaster.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectCountryMaster, CommandType.StoredProcedure);
				objCountryMaster.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("CountryMasterDAO.cs : SelectCountryMaster() is ended with success.");
			}
			catch (Exception ex)
			{
				objCountryMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("CountryMasterDAO.cs : SelectCountryMaster() is ended with error.");
			}
			return objCountryMaster;
		}

		public CountryMaster InsertCountryMaster(CountryMaster objCountryMaster)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_INSERT_COUNTRY_MASTER.COUNTRY_NAME_PARAM(objParameterList , objCountryMaster.CountryName);
			UDSP_INSERT_COUNTRY_MASTER.DESCRIPTION_PARAM(objParameterList , objCountryMaster.Description);
			UDSP_INSERT_COUNTRY_MASTER.VERSION_PARAM(objParameterList , objCountryMaster.Version);
			UDSP_INSERT_COUNTRY_MASTER.CREATED_BY_PARAM(objParameterList , objCountryMaster.CreatedBy);
			UDSP_INSERT_COUNTRY_MASTER.CREATED_ON_PARAM(objParameterList , objCountryMaster.CreatedOn);
			UDSP_INSERT_COUNTRY_MASTER.MODIFIED_BY_PARAM(objParameterList , objCountryMaster.ModifiedBy);
			UDSP_INSERT_COUNTRY_MASTER.MODIFIED_ON_PARAM(objParameterList , objCountryMaster.ModifiedOn);
			UDSP_INSERT_COUNTRY_MASTER.RECORD_STATUS_PARAM(objParameterList , objCountryMaster.RecordStatus);
			try
			{
				Logger.LogInfo("CountryMasterDAO.cs : InsertCountryMaster() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strInsertCountryMaster, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) > 0 )
					{
						objCountryMaster.CountryId = Convert.ToInt32(dbExecuteStatus);
						objCountryMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objCountryMaster.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("CountryMasterDAO.cs : InsertCountryMaster() is ended with success.");
				}
				else
				{
					objCountryMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("CountryMasterDAO.cs : InsertCountryMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objCountryMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("CountryMasterDAO.cs : InsertCountryMaster() is ended with error.");
			}
			return objCountryMaster;
		}

		public CountryMaster UpdateCountryMaster(CountryMaster objCountryMaster)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_UPDATE_COUNTRY_MASTER.COUNTRY_ID_PARAM(objParameterList , objCountryMaster.CountryId);
			UDSP_UPDATE_COUNTRY_MASTER.COUNTRY_NAME_PARAM(objParameterList , objCountryMaster.CountryName);
			UDSP_UPDATE_COUNTRY_MASTER.DESCRIPTION_PARAM(objParameterList , objCountryMaster.Description);
			UDSP_UPDATE_COUNTRY_MASTER.VERSION_PARAM(objParameterList , objCountryMaster.Version);
			UDSP_UPDATE_COUNTRY_MASTER.CREATED_BY_PARAM(objParameterList , objCountryMaster.CreatedBy);
			UDSP_UPDATE_COUNTRY_MASTER.CREATED_ON_PARAM(objParameterList , objCountryMaster.CreatedOn);
			UDSP_UPDATE_COUNTRY_MASTER.MODIFIED_BY_PARAM(objParameterList , objCountryMaster.ModifiedBy);
			UDSP_UPDATE_COUNTRY_MASTER.MODIFIED_ON_PARAM(objParameterList , objCountryMaster.ModifiedOn);
			UDSP_UPDATE_COUNTRY_MASTER.RECORD_STATUS_PARAM(objParameterList , objCountryMaster.RecordStatus);
			try
			{
				Logger.LogInfo("CountryMasterDAO.cs : UpdateCountryMaster() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strUpdateCountryMaster, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objCountryMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
					{
						objCountryMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					else
					{
						objCountryMaster.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("CountryMasterDAO.cs : UpdateCountryMaster() is ended with success.");
				}
				else
				{
					objCountryMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("CountryMasterDAO.cs : UpdateCountryMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objCountryMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("CountryMasterDAO.cs : UpdateCountryMaster() is ended with error.");
			}
			return objCountryMaster;
		}

		public CountryMaster ActivateDeactivateCountryMaster(CountryMaster objCountryMaster)
		{
			try
			{
				Logger.LogInfo("CountryMasterDAO.cs : ActivateDeactivateCountryMasterDAO() is started.");
				dbExecuteStatus = DataUtility.ActivateDeactivateObject(strDBTableName, objCountryMaster.CountryId,
										objCountryMaster.Version, objCountryMaster.RecordStatus, objCountryMaster.ModifiedBy);
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objCountryMaster.DbOperationStatus = CommonConstant.SUCCEED;
						Logger.LogInfo("CountryMasterDAO.cs : ActivateDeactivateCountryMaster() is ended with success.");
					}
					else
					{
						objCountryMaster.DbOperationStatus = CommonConstant.INVALID;
						Logger.LogInfo("CountryMasterDAO.cs : ActivateDeactivateCountryMaster() is ended with success.");
					}
				}
				else
				{
					objCountryMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("CountryMasterDAO.cs : ActivateDeactivateCountryMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objCountryMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("CountryMasterDAO.cs : ActivateDeactivateCountryMaster() is ended with error.");
			}
			return objCountryMaster;
		}

		public CountryMaster SelectRecordById(CountryMaster objCountryMaster)
		{
			try
			{
				Logger.LogInfo("CountryMasterDAO.cs : SelectRecordById() is started.");
				objCountryMaster.ObjectDataSet = DataUtility.SelectRecordById(strDBTableName, objCountryMaster.CountryId, objCountryMaster.Version, strSelectCountryMaster);
				if (GeneralUtility.IsInteger(objCountryMaster.ObjectDataSet.Tables[0].Rows[0][0]) && (objCountryMaster.ObjectDataSet.Tables[1].Columns.Count > 1))
				{
					if (Convert.ToInt32(objCountryMaster.ObjectDataSet.Tables[0].Rows[0][0]) > 0)
					{
						objCountryMaster.IsRecordChanged = false;
						objCountryMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objCountryMaster.IsRecordChanged = true;
						objCountryMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					Logger.LogInfo("CountryMasterDAO.cs : SelectRecordById() is ended with success.");
				}
				else
				{
					objCountryMaster.DbOperationStatus = CommonConstant.FAIL;
					dbExecuteStatus = objCountryMaster.ObjectDataSet.Tables[0].Rows[0][0].ToString() + " " + objCountryMaster.ObjectDataSet.Tables[1].Rows[0][0].ToString();
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("CountryMasterDAO.cs : SelectRecordById() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objCountryMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("CountryMasterDAO.cs : SelectRecordById() is ended with error.");
			}
			return objCountryMaster;
		}
	}
}
