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
	public class CityMasterDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "CITY_MASTER";
		private string strSelectCityMaster = "UDSP_SELECT_CITY_MASTER";
		private string strInsertCityMaster = "UDSP_INSERT_CITY_MASTER";
		private string strUpdateCityMaster = "UDSP_UPDATE_CITY_MASTER";
		private string dbExecuteStatus = "";

		public CityMaster SelectCityMaster(CityMaster objCityMaster)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_CITY_MASTER.CITY_ID_PARAM(objParameterList , objCityMaster.CityId);
			UDSP_SELECT_CITY_MASTER.CITY_NAME_PARAM(objParameterList , objCityMaster.CityName);
			if (objCityMaster.StateObject != null)
			{
				UDSP_SELECT_CITY_MASTER.STATE_ID_PARAM(objParameterList , objCityMaster.StateObject.StateId);
			}
			UDSP_SELECT_CITY_MASTER.IS_DEFAULT_SELECTED_PARAM(objParameterList , objCityMaster.IsDefaultSelected);
			UDSP_SELECT_CITY_MASTER.DESCRIPTION_PARAM(objParameterList , objCityMaster.Description);
			UDSP_SELECT_CITY_MASTER.RECORD_STATUS_PARAM(objParameterList , objCityMaster.RecordStatus);
			try
			{
				Logger.LogInfo("CityMasterDAO.cs : SelectCityMaster() is started.");
				objCityMaster.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectCityMaster, CommandType.StoredProcedure);
				objCityMaster.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("CityMasterDAO.cs : SelectCityMaster() is ended with success.");
			}
			catch (Exception ex)
			{
				objCityMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("CityMasterDAO.cs : SelectCityMaster() is ended with error.");
			}
			return objCityMaster;
		}

		public CityMaster InsertCityMaster(CityMaster objCityMaster)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_INSERT_CITY_MASTER.CITY_NAME_PARAM(objParameterList , objCityMaster.CityName);
			if (objCityMaster.StateObject != null)
			{
				UDSP_INSERT_CITY_MASTER.STATE_ID_PARAM(objParameterList , objCityMaster.StateObject.StateId);
			}
			UDSP_INSERT_CITY_MASTER.IS_DEFAULT_SELECTED_PARAM(objParameterList , objCityMaster.IsDefaultSelected);
			UDSP_INSERT_CITY_MASTER.DESCRIPTION_PARAM(objParameterList , objCityMaster.Description);
			UDSP_INSERT_CITY_MASTER.VERSION_PARAM(objParameterList , objCityMaster.Version);
			UDSP_INSERT_CITY_MASTER.CREATED_BY_PARAM(objParameterList , objCityMaster.CreatedBy);
			UDSP_INSERT_CITY_MASTER.CREATED_ON_PARAM(objParameterList , objCityMaster.CreatedOn);
			UDSP_INSERT_CITY_MASTER.MODIFIED_BY_PARAM(objParameterList , objCityMaster.ModifiedBy);
			UDSP_INSERT_CITY_MASTER.MODIFIED_ON_PARAM(objParameterList , objCityMaster.ModifiedOn);
			UDSP_INSERT_CITY_MASTER.RECORD_STATUS_PARAM(objParameterList , objCityMaster.RecordStatus);
			try
			{
				Logger.LogInfo("CityMasterDAO.cs : InsertCityMaster() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strInsertCityMaster, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) > 0 )
					{
						objCityMaster.CityId = Convert.ToInt32(dbExecuteStatus);
						objCityMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objCityMaster.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("CityMasterDAO.cs : InsertCityMaster() is ended with success.");
				}
				else
				{
					objCityMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("CityMasterDAO.cs : InsertCityMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objCityMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("CityMasterDAO.cs : InsertCityMaster() is ended with error.");
			}
			return objCityMaster;
		}

		public CityMaster UpdateCityMaster(CityMaster objCityMaster)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_UPDATE_CITY_MASTER.CITY_ID_PARAM(objParameterList , objCityMaster.CityId);
			UDSP_UPDATE_CITY_MASTER.CITY_NAME_PARAM(objParameterList , objCityMaster.CityName);
			if (objCityMaster.StateObject != null)
			{
				UDSP_UPDATE_CITY_MASTER.STATE_ID_PARAM(objParameterList , objCityMaster.StateObject.StateId);
			}
			UDSP_UPDATE_CITY_MASTER.IS_DEFAULT_SELECTED_PARAM(objParameterList , objCityMaster.IsDefaultSelected);
			UDSP_UPDATE_CITY_MASTER.DESCRIPTION_PARAM(objParameterList , objCityMaster.Description);
			UDSP_UPDATE_CITY_MASTER.VERSION_PARAM(objParameterList , objCityMaster.Version);
			UDSP_UPDATE_CITY_MASTER.CREATED_BY_PARAM(objParameterList , objCityMaster.CreatedBy);
			UDSP_UPDATE_CITY_MASTER.CREATED_ON_PARAM(objParameterList , objCityMaster.CreatedOn);
			UDSP_UPDATE_CITY_MASTER.MODIFIED_BY_PARAM(objParameterList , objCityMaster.ModifiedBy);
			UDSP_UPDATE_CITY_MASTER.MODIFIED_ON_PARAM(objParameterList , objCityMaster.ModifiedOn);
			UDSP_UPDATE_CITY_MASTER.RECORD_STATUS_PARAM(objParameterList , objCityMaster.RecordStatus);
			try
			{
				Logger.LogInfo("CityMasterDAO.cs : UpdateCityMaster() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strUpdateCityMaster, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objCityMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
					{
						objCityMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					else
					{
						objCityMaster.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("CityMasterDAO.cs : UpdateCityMaster() is ended with success.");
				}
				else
				{
					objCityMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("CityMasterDAO.cs : UpdateCityMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objCityMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("CityMasterDAO.cs : UpdateCityMaster() is ended with error.");
			}
			return objCityMaster;
		}

		public CityMaster ActivateDeactivateCityMaster(CityMaster objCityMaster)
		{
			try
			{
				Logger.LogInfo("CityMasterDAO.cs : ActivateDeactivateCityMasterDAO() is started.");
				dbExecuteStatus = DataUtility.ActivateDeactivateObject(strDBTableName, objCityMaster.CityId,
										objCityMaster.Version, objCityMaster.RecordStatus, objCityMaster.ModifiedBy);
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objCityMaster.DbOperationStatus = CommonConstant.SUCCEED;
						Logger.LogInfo("CityMasterDAO.cs : ActivateDeactivateCityMaster() is ended with success.");
					}
					else
					{
						objCityMaster.DbOperationStatus = CommonConstant.INVALID;
						Logger.LogInfo("CityMasterDAO.cs : ActivateDeactivateCityMaster() is ended with success.");
					}
				}
				else
				{
					objCityMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("CityMasterDAO.cs : ActivateDeactivateCityMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objCityMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("CityMasterDAO.cs : ActivateDeactivateCityMaster() is ended with error.");
			}
			return objCityMaster;
		}

		public CityMaster SelectRecordById(CityMaster objCityMaster)
		{
			try
			{
				Logger.LogInfo("CityMasterDAO.cs : SelectRecordById() is started.");
				objCityMaster.ObjectDataSet = DataUtility.SelectRecordById(strDBTableName, objCityMaster.CityId, objCityMaster.Version, strSelectCityMaster);
				if (GeneralUtility.IsInteger(objCityMaster.ObjectDataSet.Tables[0].Rows[0][0]) && (objCityMaster.ObjectDataSet.Tables[1].Columns.Count > 1))
				{
					if (Convert.ToInt32(objCityMaster.ObjectDataSet.Tables[0].Rows[0][0]) > 0)
					{
						objCityMaster.IsRecordChanged = false;
						objCityMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objCityMaster.IsRecordChanged = true;
						objCityMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					Logger.LogInfo("CityMasterDAO.cs : SelectRecordById() is ended with success.");
				}
				else
				{
					objCityMaster.DbOperationStatus = CommonConstant.FAIL;
					dbExecuteStatus = objCityMaster.ObjectDataSet.Tables[0].Rows[0][0].ToString() + " " + objCityMaster.ObjectDataSet.Tables[1].Rows[0][0].ToString();
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("CityMasterDAO.cs : SelectRecordById() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objCityMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("CityMasterDAO.cs : SelectRecordById() is ended with error.");
			}
			return objCityMaster;
		}
	}
}
