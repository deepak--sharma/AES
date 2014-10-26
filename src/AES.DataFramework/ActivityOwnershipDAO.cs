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
	public class ActivityOwnershipDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "ACTIVITY_OWNERSHIP";
		private string strSelectActivityOwnership = "UDSP_SELECT_ACTIVITY_OWNERSHIP";
		private string strInsertActivityOwnership = "UDSP_INSERT_ACTIVITY_OWNERSHIP";
		private string strUpdateActivityOwnership = "UDSP_UPDATE_ACTIVITY_OWNERSHIP";
		private string dbExecuteStatus = "";

		public ActivityOwnership SelectActivityOwnership(ActivityOwnership objActivityOwnership)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_ACTIVITY_OWNERSHIP.OWNERSHIP_ID_PARAM(objParameterList , objActivityOwnership.OwnershipId);
			if (objActivityOwnership.ActivityScheduleObject != null)
			{
				UDSP_SELECT_ACTIVITY_OWNERSHIP.ACTIVITY_SCHEDULE_ID_PARAM(objParameterList , objActivityOwnership.ActivityScheduleObject.ActivityScheduleId);
			}
			UDSP_SELECT_ACTIVITY_OWNERSHIP.MEMBER_ID_PARAM(objParameterList , objActivityOwnership.MemberId);
			if (objActivityOwnership.OwnershipStatusObject != null)
			{
				UDSP_SELECT_ACTIVITY_OWNERSHIP.OWNERSHIP_STATUS_ID_PARAM(objParameterList , objActivityOwnership.OwnershipStatusObject.MetadataId);
			}
			UDSP_SELECT_ACTIVITY_OWNERSHIP.COMMENT_PARAM(objParameterList , objActivityOwnership.Comment);
			UDSP_SELECT_ACTIVITY_OWNERSHIP.RECORD_STATUS_PARAM(objParameterList , objActivityOwnership.RecordStatus);
			try
			{
				Logger.LogInfo("ActivityOwnershipDAO.cs : SelectActivityOwnership() is started.");
				objActivityOwnership.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectActivityOwnership, CommandType.StoredProcedure);
				objActivityOwnership.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("ActivityOwnershipDAO.cs : SelectActivityOwnership() is ended with success.");
			}
			catch (Exception ex)
			{
				objActivityOwnership.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("ActivityOwnershipDAO.cs : SelectActivityOwnership() is ended with error.");
			}
			return objActivityOwnership;
		}

		public ActivityOwnership InsertActivityOwnership(ActivityOwnership objActivityOwnership)
		{
			objParameterList = new List<SqlParameter>();
				
			if (objActivityOwnership.ActivityScheduleObject != null)
			{
				UDSP_INSERT_ACTIVITY_OWNERSHIP.ACTIVITY_SCHEDULE_ID_PARAM(objParameterList , objActivityOwnership.ActivityScheduleObject.ActivityScheduleId);
			}
			UDSP_INSERT_ACTIVITY_OWNERSHIP.MEMBER_ID_PARAM(objParameterList , objActivityOwnership.MemberId);
			if (objActivityOwnership.OwnershipStatusObject != null)
			{
				UDSP_INSERT_ACTIVITY_OWNERSHIP.OWNERSHIP_STATUS_ID_PARAM(objParameterList , objActivityOwnership.OwnershipStatusObject.MetadataId);
			}
			UDSP_INSERT_ACTIVITY_OWNERSHIP.COMMENT_PARAM(objParameterList , objActivityOwnership.Comment);
			UDSP_INSERT_ACTIVITY_OWNERSHIP.VERSION_PARAM(objParameterList , objActivityOwnership.Version);
			UDSP_INSERT_ACTIVITY_OWNERSHIP.CREATED_BY_PARAM(objParameterList , objActivityOwnership.CreatedBy);
			UDSP_INSERT_ACTIVITY_OWNERSHIP.CREATED_ON_PARAM(objParameterList , objActivityOwnership.CreatedOn);
			UDSP_INSERT_ACTIVITY_OWNERSHIP.MODIFIED_BY_PARAM(objParameterList , objActivityOwnership.ModifiedBy);
			UDSP_INSERT_ACTIVITY_OWNERSHIP.MODIFIED_ON_PARAM(objParameterList , objActivityOwnership.ModifiedOn);
			UDSP_INSERT_ACTIVITY_OWNERSHIP.RECORD_STATUS_PARAM(objParameterList , objActivityOwnership.RecordStatus);
			try
			{
				Logger.LogInfo("ActivityOwnershipDAO.cs : InsertActivityOwnership() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strInsertActivityOwnership, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) > 0 )
					{
						objActivityOwnership.OwnershipId = Convert.ToInt32(dbExecuteStatus);
						objActivityOwnership.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objActivityOwnership.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("ActivityOwnershipDAO.cs : InsertActivityOwnership() is ended with success.");
				}
				else
				{
					objActivityOwnership.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("ActivityOwnershipDAO.cs : InsertActivityOwnership() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objActivityOwnership.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("ActivityOwnershipDAO.cs : InsertActivityOwnership() is ended with error.");
			}
			return objActivityOwnership;
		}

		public ActivityOwnership UpdateActivityOwnership(ActivityOwnership objActivityOwnership)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_UPDATE_ACTIVITY_OWNERSHIP.OWNERSHIP_ID_PARAM(objParameterList , objActivityOwnership.OwnershipId);
			if (objActivityOwnership.ActivityScheduleObject != null)
			{
				UDSP_UPDATE_ACTIVITY_OWNERSHIP.ACTIVITY_SCHEDULE_ID_PARAM(objParameterList , objActivityOwnership.ActivityScheduleObject.ActivityScheduleId);
			}
			UDSP_UPDATE_ACTIVITY_OWNERSHIP.MEMBER_ID_PARAM(objParameterList , objActivityOwnership.MemberId);
			if (objActivityOwnership.OwnershipStatusObject != null)
			{
				UDSP_UPDATE_ACTIVITY_OWNERSHIP.OWNERSHIP_STATUS_ID_PARAM(objParameterList , objActivityOwnership.OwnershipStatusObject.MetadataId);
			}
			UDSP_UPDATE_ACTIVITY_OWNERSHIP.COMMENT_PARAM(objParameterList , objActivityOwnership.Comment);
			UDSP_UPDATE_ACTIVITY_OWNERSHIP.VERSION_PARAM(objParameterList , objActivityOwnership.Version);
			UDSP_UPDATE_ACTIVITY_OWNERSHIP.CREATED_BY_PARAM(objParameterList , objActivityOwnership.CreatedBy);
			UDSP_UPDATE_ACTIVITY_OWNERSHIP.CREATED_ON_PARAM(objParameterList , objActivityOwnership.CreatedOn);
			UDSP_UPDATE_ACTIVITY_OWNERSHIP.MODIFIED_BY_PARAM(objParameterList , objActivityOwnership.ModifiedBy);
			UDSP_UPDATE_ACTIVITY_OWNERSHIP.MODIFIED_ON_PARAM(objParameterList , objActivityOwnership.ModifiedOn);
			UDSP_UPDATE_ACTIVITY_OWNERSHIP.RECORD_STATUS_PARAM(objParameterList , objActivityOwnership.RecordStatus);
			try
			{
				Logger.LogInfo("ActivityOwnershipDAO.cs : UpdateActivityOwnership() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strUpdateActivityOwnership, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objActivityOwnership.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
					{
						objActivityOwnership.DbOperationStatus = CommonConstant.INVALID;
					}
					else
					{
						objActivityOwnership.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("ActivityOwnershipDAO.cs : UpdateActivityOwnership() is ended with success.");
				}
				else
				{
					objActivityOwnership.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("ActivityOwnershipDAO.cs : UpdateActivityOwnership() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objActivityOwnership.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("ActivityOwnershipDAO.cs : UpdateActivityOwnership() is ended with error.");
			}
			return objActivityOwnership;
		}

		public ActivityOwnership ActivateDeactivateActivityOwnership(ActivityOwnership objActivityOwnership)
		{
			try
			{
				Logger.LogInfo("ActivityOwnershipDAO.cs : ActivateDeactivateActivityOwnershipDAO() is started.");
				dbExecuteStatus = DataUtility.ActivateDeactivateObject(strDBTableName, objActivityOwnership.OwnershipId,
										objActivityOwnership.Version, objActivityOwnership.RecordStatus, objActivityOwnership.ModifiedBy);
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objActivityOwnership.DbOperationStatus = CommonConstant.SUCCEED;
						Logger.LogInfo("ActivityOwnershipDAO.cs : ActivateDeactivateActivityOwnership() is ended with success.");
					}
					else
					{
						objActivityOwnership.DbOperationStatus = CommonConstant.INVALID;
						Logger.LogInfo("ActivityOwnershipDAO.cs : ActivateDeactivateActivityOwnership() is ended with success.");
					}
				}
				else
				{
					objActivityOwnership.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("ActivityOwnershipDAO.cs : ActivateDeactivateActivityOwnership() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objActivityOwnership.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("ActivityOwnershipDAO.cs : ActivateDeactivateActivityOwnership() is ended with error.");
			}
			return objActivityOwnership;
		}

		public ActivityOwnership SelectRecordById(ActivityOwnership objActivityOwnership)
		{
			try
			{
				Logger.LogInfo("ActivityOwnershipDAO.cs : SelectRecordById() is started.");
				objActivityOwnership.ObjectDataSet = DataUtility.SelectRecordById(strDBTableName, objActivityOwnership.OwnershipId, objActivityOwnership.Version, strSelectActivityOwnership);
				if (GeneralUtility.IsInteger(objActivityOwnership.ObjectDataSet.Tables[0].Rows[0][0]) && (objActivityOwnership.ObjectDataSet.Tables[1].Columns.Count > 1))
				{
					if (Convert.ToInt32(objActivityOwnership.ObjectDataSet.Tables[0].Rows[0][0]) > 0)
					{
						objActivityOwnership.IsRecordChanged = false;
						objActivityOwnership.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objActivityOwnership.IsRecordChanged = true;
						objActivityOwnership.DbOperationStatus = CommonConstant.INVALID;
					}
					Logger.LogInfo("ActivityOwnershipDAO.cs : SelectRecordById() is ended with success.");
				}
				else
				{
					objActivityOwnership.DbOperationStatus = CommonConstant.FAIL;
					dbExecuteStatus = objActivityOwnership.ObjectDataSet.Tables[0].Rows[0][0].ToString() + " " + objActivityOwnership.ObjectDataSet.Tables[1].Rows[0][0].ToString();
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("ActivityOwnershipDAO.cs : SelectRecordById() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objActivityOwnership.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("ActivityOwnershipDAO.cs : SelectRecordById() is ended with error.");
			}
			return objActivityOwnership;
		}
	}
}
