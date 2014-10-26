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
	public class StateMasterDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "STATE_MASTER";
		private string strSelectStateMaster = "UDSP_SELECT_STATE_MASTER";
		private string strInsertStateMaster = "UDSP_INSERT_STATE_MASTER";
		private string strUpdateStateMaster = "UDSP_UPDATE_STATE_MASTER";
		private string dbExecuteStatus = "";

		public StateMaster SelectStateMaster(StateMaster objStateMaster)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_STATE_MASTER.STATE_ID_PARAM(objParameterList , objStateMaster.StateId);
			UDSP_SELECT_STATE_MASTER.STATE_NAME_PARAM(objParameterList , objStateMaster.StateName);
			if (objStateMaster.CountryObject != null)
			{
				UDSP_SELECT_STATE_MASTER.COUNTRY_ID_PARAM(objParameterList , objStateMaster.CountryObject.CountryId);
			}
			UDSP_SELECT_STATE_MASTER.DESCRIPTION_PARAM(objParameterList , objStateMaster.Description);
			UDSP_SELECT_STATE_MASTER.RECORD_STATUS_PARAM(objParameterList , objStateMaster.RecordStatus);
			try
			{
				Logger.LogInfo("StateMasterDAO.cs : SelectStateMaster() is started.");
				objStateMaster.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectStateMaster, CommandType.StoredProcedure);
				objStateMaster.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("StateMasterDAO.cs : SelectStateMaster() is ended with success.");
			}
			catch (Exception ex)
			{
				objStateMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("StateMasterDAO.cs : SelectStateMaster() is ended with error.");
			}
			return objStateMaster;
		}

		public StateMaster InsertStateMaster(StateMaster objStateMaster)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_INSERT_STATE_MASTER.STATE_NAME_PARAM(objParameterList , objStateMaster.StateName);
			if (objStateMaster.CountryObject != null)
			{
				UDSP_INSERT_STATE_MASTER.COUNTRY_ID_PARAM(objParameterList , objStateMaster.CountryObject.CountryId);
			}
			UDSP_INSERT_STATE_MASTER.DESCRIPTION_PARAM(objParameterList , objStateMaster.Description);
			UDSP_INSERT_STATE_MASTER.VERSION_PARAM(objParameterList , objStateMaster.Version);
			UDSP_INSERT_STATE_MASTER.CREATED_BY_PARAM(objParameterList , objStateMaster.CreatedBy);
			UDSP_INSERT_STATE_MASTER.CREATED_ON_PARAM(objParameterList , objStateMaster.CreatedOn);
			UDSP_INSERT_STATE_MASTER.MODIFIED_BY_PARAM(objParameterList , objStateMaster.ModifiedBy);
			UDSP_INSERT_STATE_MASTER.MODIFIED_ON_PARAM(objParameterList , objStateMaster.ModifiedOn);
			UDSP_INSERT_STATE_MASTER.RECORD_STATUS_PARAM(objParameterList , objStateMaster.RecordStatus);
			try
			{
				Logger.LogInfo("StateMasterDAO.cs : InsertStateMaster() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strInsertStateMaster, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) > 0 )
					{
						objStateMaster.StateId = Convert.ToInt32(dbExecuteStatus);
						objStateMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objStateMaster.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("StateMasterDAO.cs : InsertStateMaster() is ended with success.");
				}
				else
				{
					objStateMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("StateMasterDAO.cs : InsertStateMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objStateMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("StateMasterDAO.cs : InsertStateMaster() is ended with error.");
			}
			return objStateMaster;
		}

		public StateMaster UpdateStateMaster(StateMaster objStateMaster)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_UPDATE_STATE_MASTER.STATE_ID_PARAM(objParameterList , objStateMaster.StateId);
			UDSP_UPDATE_STATE_MASTER.STATE_NAME_PARAM(objParameterList , objStateMaster.StateName);
			if (objStateMaster.CountryObject != null)
			{
				UDSP_UPDATE_STATE_MASTER.COUNTRY_ID_PARAM(objParameterList , objStateMaster.CountryObject.CountryId);
			}
			UDSP_UPDATE_STATE_MASTER.DESCRIPTION_PARAM(objParameterList , objStateMaster.Description);
			UDSP_UPDATE_STATE_MASTER.VERSION_PARAM(objParameterList , objStateMaster.Version);
			UDSP_UPDATE_STATE_MASTER.CREATED_BY_PARAM(objParameterList , objStateMaster.CreatedBy);
			UDSP_UPDATE_STATE_MASTER.CREATED_ON_PARAM(objParameterList , objStateMaster.CreatedOn);
			UDSP_UPDATE_STATE_MASTER.MODIFIED_BY_PARAM(objParameterList , objStateMaster.ModifiedBy);
			UDSP_UPDATE_STATE_MASTER.MODIFIED_ON_PARAM(objParameterList , objStateMaster.ModifiedOn);
			UDSP_UPDATE_STATE_MASTER.RECORD_STATUS_PARAM(objParameterList , objStateMaster.RecordStatus);
			try
			{
				Logger.LogInfo("StateMasterDAO.cs : UpdateStateMaster() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strUpdateStateMaster, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objStateMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
					{
						objStateMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					else
					{
						objStateMaster.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("StateMasterDAO.cs : UpdateStateMaster() is ended with success.");
				}
				else
				{
					objStateMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("StateMasterDAO.cs : UpdateStateMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objStateMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("StateMasterDAO.cs : UpdateStateMaster() is ended with error.");
			}
			return objStateMaster;
		}

		public StateMaster ActivateDeactivateStateMaster(StateMaster objStateMaster)
		{
			try
			{
				Logger.LogInfo("StateMasterDAO.cs : ActivateDeactivateStateMasterDAO() is started.");
				dbExecuteStatus = DataUtility.ActivateDeactivateObject(strDBTableName, objStateMaster.StateId,
										objStateMaster.Version, objStateMaster.RecordStatus, objStateMaster.ModifiedBy);
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objStateMaster.DbOperationStatus = CommonConstant.SUCCEED;
						Logger.LogInfo("StateMasterDAO.cs : ActivateDeactivateStateMaster() is ended with success.");
					}
					else
					{
						objStateMaster.DbOperationStatus = CommonConstant.INVALID;
						Logger.LogInfo("StateMasterDAO.cs : ActivateDeactivateStateMaster() is ended with success.");
					}
				}
				else
				{
					objStateMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("StateMasterDAO.cs : ActivateDeactivateStateMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objStateMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("StateMasterDAO.cs : ActivateDeactivateStateMaster() is ended with error.");
			}
			return objStateMaster;
		}

		public StateMaster SelectRecordById(StateMaster objStateMaster)
		{
			try
			{
				Logger.LogInfo("StateMasterDAO.cs : SelectRecordById() is started.");
				objStateMaster.ObjectDataSet = DataUtility.SelectRecordById(strDBTableName, objStateMaster.StateId, objStateMaster.Version, strSelectStateMaster);
				if (GeneralUtility.IsInteger(objStateMaster.ObjectDataSet.Tables[0].Rows[0][0]) && (objStateMaster.ObjectDataSet.Tables[1].Columns.Count > 1))
				{
					if (Convert.ToInt32(objStateMaster.ObjectDataSet.Tables[0].Rows[0][0]) > 0)
					{
						objStateMaster.IsRecordChanged = false;
						objStateMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objStateMaster.IsRecordChanged = true;
						objStateMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					Logger.LogInfo("StateMasterDAO.cs : SelectRecordById() is ended with success.");
				}
				else
				{
					objStateMaster.DbOperationStatus = CommonConstant.FAIL;
					dbExecuteStatus = objStateMaster.ObjectDataSet.Tables[0].Rows[0][0].ToString() + " " + objStateMaster.ObjectDataSet.Tables[1].Rows[0][0].ToString();
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("StateMasterDAO.cs : SelectRecordById() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objStateMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("StateMasterDAO.cs : SelectRecordById() is ended with error.");
			}
			return objStateMaster;
		}
	}
}
