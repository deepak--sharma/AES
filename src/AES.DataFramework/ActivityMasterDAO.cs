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
	public class ActivityMasterDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "ACTIVITY_MASTER";
		private string strSelectActivityMaster = "UDSP_SELECT_ACTIVITY_MASTER";
		private string strInsertActivityMaster = "UDSP_INSERT_ACTIVITY_MASTER";
		private string strUpdateActivityMaster = "UDSP_UPDATE_ACTIVITY_MASTER";
		private string dbExecuteStatus = "";

		public ActivityMaster SelectActivityMaster(ActivityMaster objActivityMaster)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_ACTIVITY_MASTER.ACTIVITY_ID_PARAM(objParameterList , objActivityMaster.ActivityId);
			UDSP_SELECT_ACTIVITY_MASTER.ACTIVITY_NAME_PARAM(objParameterList , objActivityMaster.ActivityName);
			UDSP_SELECT_ACTIVITY_MASTER.DESCRIPTION_PARAM(objParameterList , objActivityMaster.Description);
			UDSP_SELECT_ACTIVITY_MASTER.RECORD_STATUS_PARAM(objParameterList , objActivityMaster.RecordStatus);
			try
			{
				Logger.LogInfo("ActivityMasterDAO.cs : SelectActivityMaster() is started.");
				objActivityMaster.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectActivityMaster, CommandType.StoredProcedure);
				objActivityMaster.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("ActivityMasterDAO.cs : SelectActivityMaster() is ended with success.");
			}
			catch (Exception ex)
			{
				objActivityMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("ActivityMasterDAO.cs : SelectActivityMaster() is ended with error.");
			}
			return objActivityMaster;
		}

		public ActivityMaster InsertActivityMaster(ActivityMaster objActivityMaster)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_INSERT_ACTIVITY_MASTER.ACTIVITY_NAME_PARAM(objParameterList , objActivityMaster.ActivityName);
			UDSP_INSERT_ACTIVITY_MASTER.DESCRIPTION_PARAM(objParameterList , objActivityMaster.Description);
			UDSP_INSERT_ACTIVITY_MASTER.VERSION_PARAM(objParameterList , objActivityMaster.Version);
			UDSP_INSERT_ACTIVITY_MASTER.CREATED_BY_PARAM(objParameterList , objActivityMaster.CreatedBy);
			UDSP_INSERT_ACTIVITY_MASTER.CREATED_ON_PARAM(objParameterList , objActivityMaster.CreatedOn);
			UDSP_INSERT_ACTIVITY_MASTER.MODIFIED_BY_PARAM(objParameterList , objActivityMaster.ModifiedBy);
			UDSP_INSERT_ACTIVITY_MASTER.MODIFIED_ON_PARAM(objParameterList , objActivityMaster.ModifiedOn);
			UDSP_INSERT_ACTIVITY_MASTER.RECORD_STATUS_PARAM(objParameterList , objActivityMaster.RecordStatus);
			try
			{
				Logger.LogInfo("ActivityMasterDAO.cs : InsertActivityMaster() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strInsertActivityMaster, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) > 0 )
					{
						objActivityMaster.ActivityId = Convert.ToInt32(dbExecuteStatus);
						objActivityMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objActivityMaster.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("ActivityMasterDAO.cs : InsertActivityMaster() is ended with success.");
				}
				else
				{
					objActivityMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("ActivityMasterDAO.cs : InsertActivityMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objActivityMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("ActivityMasterDAO.cs : InsertActivityMaster() is ended with error.");
			}
			return objActivityMaster;
		}

		public ActivityMaster UpdateActivityMaster(ActivityMaster objActivityMaster)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_UPDATE_ACTIVITY_MASTER.ACTIVITY_ID_PARAM(objParameterList , objActivityMaster.ActivityId);
			UDSP_UPDATE_ACTIVITY_MASTER.ACTIVITY_NAME_PARAM(objParameterList , objActivityMaster.ActivityName);
			UDSP_UPDATE_ACTIVITY_MASTER.DESCRIPTION_PARAM(objParameterList , objActivityMaster.Description);
			UDSP_UPDATE_ACTIVITY_MASTER.VERSION_PARAM(objParameterList , objActivityMaster.Version);
			UDSP_UPDATE_ACTIVITY_MASTER.CREATED_BY_PARAM(objParameterList , objActivityMaster.CreatedBy);
			UDSP_UPDATE_ACTIVITY_MASTER.CREATED_ON_PARAM(objParameterList , objActivityMaster.CreatedOn);
			UDSP_UPDATE_ACTIVITY_MASTER.MODIFIED_BY_PARAM(objParameterList , objActivityMaster.ModifiedBy);
			UDSP_UPDATE_ACTIVITY_MASTER.MODIFIED_ON_PARAM(objParameterList , objActivityMaster.ModifiedOn);
			UDSP_UPDATE_ACTIVITY_MASTER.RECORD_STATUS_PARAM(objParameterList , objActivityMaster.RecordStatus);
			try
			{
				Logger.LogInfo("ActivityMasterDAO.cs : UpdateActivityMaster() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strUpdateActivityMaster, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objActivityMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
					{
						objActivityMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					else
					{
						objActivityMaster.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("ActivityMasterDAO.cs : UpdateActivityMaster() is ended with success.");
				}
				else
				{
					objActivityMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("ActivityMasterDAO.cs : UpdateActivityMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objActivityMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("ActivityMasterDAO.cs : UpdateActivityMaster() is ended with error.");
			}
			return objActivityMaster;
		}

		public ActivityMaster ActivateDeactivateActivityMaster(ActivityMaster objActivityMaster)
		{
			try
			{
				Logger.LogInfo("ActivityMasterDAO.cs : ActivateDeactivateActivityMasterDAO() is started.");
				dbExecuteStatus = DataUtility.ActivateDeactivateObject(strDBTableName, objActivityMaster.ActivityId,
										objActivityMaster.Version, objActivityMaster.RecordStatus, objActivityMaster.ModifiedBy);
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objActivityMaster.DbOperationStatus = CommonConstant.SUCCEED;
						Logger.LogInfo("ActivityMasterDAO.cs : ActivateDeactivateActivityMaster() is ended with success.");
					}
					else
					{
						objActivityMaster.DbOperationStatus = CommonConstant.INVALID;
						Logger.LogInfo("ActivityMasterDAO.cs : ActivateDeactivateActivityMaster() is ended with success.");
					}
				}
				else
				{
					objActivityMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("ActivityMasterDAO.cs : ActivateDeactivateActivityMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objActivityMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("ActivityMasterDAO.cs : ActivateDeactivateActivityMaster() is ended with error.");
			}
			return objActivityMaster;
		}

		public ActivityMaster SelectRecordById(ActivityMaster objActivityMaster)
		{
			try
			{
				Logger.LogInfo("ActivityMasterDAO.cs : SelectRecordById() is started.");
				objActivityMaster.ObjectDataSet = DataUtility.SelectRecordById(strDBTableName, objActivityMaster.ActivityId, objActivityMaster.Version, strSelectActivityMaster);
				if (GeneralUtility.IsInteger(objActivityMaster.ObjectDataSet.Tables[0].Rows[0][0]) && (objActivityMaster.ObjectDataSet.Tables[1].Columns.Count > 1))
				{
					if (Convert.ToInt32(objActivityMaster.ObjectDataSet.Tables[0].Rows[0][0]) > 0)
					{
						objActivityMaster.IsRecordChanged = false;
						objActivityMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objActivityMaster.IsRecordChanged = true;
						objActivityMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					Logger.LogInfo("ActivityMasterDAO.cs : SelectRecordById() is ended with success.");
				}
				else
				{
					objActivityMaster.DbOperationStatus = CommonConstant.FAIL;
					dbExecuteStatus = objActivityMaster.ObjectDataSet.Tables[0].Rows[0][0].ToString() + " " + objActivityMaster.ObjectDataSet.Tables[1].Rows[0][0].ToString();
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("ActivityMasterDAO.cs : SelectRecordById() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objActivityMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("ActivityMasterDAO.cs : SelectRecordById() is ended with error.");
			}
			return objActivityMaster;
		}
	}
}
