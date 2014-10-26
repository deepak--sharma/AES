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
	public class ActivityScheduleDetailDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "ACTIVITY_SCHEDULE_DETAIL";
		private string strSelectActivityScheduleDetail = "UDSP_SELECT_ACTIVITY_SCHEDULE_DETAIL";
		private string strInsertActivityScheduleDetail = "UDSP_INSERT_ACTIVITY_SCHEDULE_DETAIL";
		private string strUpdateActivityScheduleDetail = "UDSP_UPDATE_ACTIVITY_SCHEDULE_DETAIL";
		private string dbExecuteStatus = "";

		public ActivityScheduleDetail SelectActivityScheduleDetail(ActivityScheduleDetail objActivityScheduleDetail)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_ACTIVITY_SCHEDULE_DETAIL.ACTIVITY_SCHEDULE_ID_PARAM(objParameterList , objActivityScheduleDetail.ActivityScheduleId);
			if (objActivityScheduleDetail.ActivityDetailObject != null)
			{
				UDSP_SELECT_ACTIVITY_SCHEDULE_DETAIL.ACTIVITY_DETAIL_ID_PARAM(objParameterList , objActivityScheduleDetail.ActivityDetailObject.ActivityDetailId);
			}
			UDSP_SELECT_ACTIVITY_SCHEDULE_DETAIL.START_TIME_PARAM(objParameterList , objActivityScheduleDetail.StartTime);
			UDSP_SELECT_ACTIVITY_SCHEDULE_DETAIL.END_TIME_PARAM(objParameterList , objActivityScheduleDetail.EndTime);
			UDSP_SELECT_ACTIVITY_SCHEDULE_DETAIL.START_DATE_PARAM(objParameterList , objActivityScheduleDetail.StartDate);
			UDSP_SELECT_ACTIVITY_SCHEDULE_DETAIL.END_DATE_PARAM(objParameterList , objActivityScheduleDetail.EndDate);
			if (objActivityScheduleDetail.BranchObject != null)
			{
				UDSP_SELECT_ACTIVITY_SCHEDULE_DETAIL.BRANCH_ID_PARAM(objParameterList , objActivityScheduleDetail.BranchObject.BranchId);
			}
			UDSP_SELECT_ACTIVITY_SCHEDULE_DETAIL.VENUE_PARAM(objParameterList , objActivityScheduleDetail.Venue);
			UDSP_SELECT_ACTIVITY_SCHEDULE_DETAIL.ACTUAL_START_TIME_PARAM(objParameterList , objActivityScheduleDetail.ActualStartTime);
			UDSP_SELECT_ACTIVITY_SCHEDULE_DETAIL.ACTUAL_END_TIME_PARAM(objParameterList , objActivityScheduleDetail.ActualEndTime);
			UDSP_SELECT_ACTIVITY_SCHEDULE_DETAIL.ACTUAL_START_DATE_PARAM(objParameterList , objActivityScheduleDetail.ActualStartDate);
			UDSP_SELECT_ACTIVITY_SCHEDULE_DETAIL.ACTUAL_END_DATE_PARAM(objParameterList , objActivityScheduleDetail.ActualEndDate);
			if (objActivityScheduleDetail.ActivityStatusObject != null)
			{
				UDSP_SELECT_ACTIVITY_SCHEDULE_DETAIL.ACTIVITY_STATUS_ID_PARAM(objParameterList , objActivityScheduleDetail.ActivityStatusObject.MetadataId);
			}
			UDSP_SELECT_ACTIVITY_SCHEDULE_DETAIL.RECORD_STATUS_PARAM(objParameterList , objActivityScheduleDetail.RecordStatus);
			try
			{
				Logger.LogInfo("ActivityScheduleDetailDAO.cs : SelectActivityScheduleDetail() is started.");
				objActivityScheduleDetail.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectActivityScheduleDetail, CommandType.StoredProcedure);
				objActivityScheduleDetail.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("ActivityScheduleDetailDAO.cs : SelectActivityScheduleDetail() is ended with success.");
			}
			catch (Exception ex)
			{
				objActivityScheduleDetail.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("ActivityScheduleDetailDAO.cs : SelectActivityScheduleDetail() is ended with error.");
			}
			return objActivityScheduleDetail;
		}

		public ActivityScheduleDetail InsertActivityScheduleDetail(ActivityScheduleDetail objActivityScheduleDetail)
		{
			objParameterList = new List<SqlParameter>();
				
			if (objActivityScheduleDetail.ActivityDetailObject != null)
			{
				UDSP_INSERT_ACTIVITY_SCHEDULE_DETAIL.ACTIVITY_DETAIL_ID_PARAM(objParameterList , objActivityScheduleDetail.ActivityDetailObject.ActivityDetailId);
			}
			UDSP_INSERT_ACTIVITY_SCHEDULE_DETAIL.START_TIME_PARAM(objParameterList , objActivityScheduleDetail.StartTime);
			UDSP_INSERT_ACTIVITY_SCHEDULE_DETAIL.END_TIME_PARAM(objParameterList , objActivityScheduleDetail.EndTime);
			UDSP_INSERT_ACTIVITY_SCHEDULE_DETAIL.START_DATE_PARAM(objParameterList , objActivityScheduleDetail.StartDate);
			UDSP_INSERT_ACTIVITY_SCHEDULE_DETAIL.END_DATE_PARAM(objParameterList , objActivityScheduleDetail.EndDate);
			if (objActivityScheduleDetail.BranchObject != null)
			{
				UDSP_INSERT_ACTIVITY_SCHEDULE_DETAIL.BRANCH_ID_PARAM(objParameterList , objActivityScheduleDetail.BranchObject.BranchId);
			}
			UDSP_INSERT_ACTIVITY_SCHEDULE_DETAIL.VENUE_PARAM(objParameterList , objActivityScheduleDetail.Venue);
			UDSP_INSERT_ACTIVITY_SCHEDULE_DETAIL.ACTUAL_START_TIME_PARAM(objParameterList , objActivityScheduleDetail.ActualStartTime);
			UDSP_INSERT_ACTIVITY_SCHEDULE_DETAIL.ACTUAL_END_TIME_PARAM(objParameterList , objActivityScheduleDetail.ActualEndTime);
			UDSP_INSERT_ACTIVITY_SCHEDULE_DETAIL.ACTUAL_START_DATE_PARAM(objParameterList , objActivityScheduleDetail.ActualStartDate);
			UDSP_INSERT_ACTIVITY_SCHEDULE_DETAIL.ACTUAL_END_DATE_PARAM(objParameterList , objActivityScheduleDetail.ActualEndDate);
			if (objActivityScheduleDetail.ActivityStatusObject != null)
			{
				UDSP_INSERT_ACTIVITY_SCHEDULE_DETAIL.ACTIVITY_STATUS_ID_PARAM(objParameterList , objActivityScheduleDetail.ActivityStatusObject.MetadataId);
			}
			UDSP_INSERT_ACTIVITY_SCHEDULE_DETAIL.VERSION_PARAM(objParameterList , objActivityScheduleDetail.Version);
			UDSP_INSERT_ACTIVITY_SCHEDULE_DETAIL.CREATED_BY_PARAM(objParameterList , objActivityScheduleDetail.CreatedBy);
			UDSP_INSERT_ACTIVITY_SCHEDULE_DETAIL.CREATED_ON_PARAM(objParameterList , objActivityScheduleDetail.CreatedOn);
			UDSP_INSERT_ACTIVITY_SCHEDULE_DETAIL.MODIFIED_BY_PARAM(objParameterList , objActivityScheduleDetail.ModifiedBy);
			UDSP_INSERT_ACTIVITY_SCHEDULE_DETAIL.MODIFIED_ON_PARAM(objParameterList , objActivityScheduleDetail.ModifiedOn);
			UDSP_INSERT_ACTIVITY_SCHEDULE_DETAIL.RECORD_STATUS_PARAM(objParameterList , objActivityScheduleDetail.RecordStatus);
			try
			{
				Logger.LogInfo("ActivityScheduleDetailDAO.cs : InsertActivityScheduleDetail() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strInsertActivityScheduleDetail, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) > 0 )
					{
						objActivityScheduleDetail.ActivityScheduleId = Convert.ToInt32(dbExecuteStatus);
						objActivityScheduleDetail.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objActivityScheduleDetail.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("ActivityScheduleDetailDAO.cs : InsertActivityScheduleDetail() is ended with success.");
				}
				else
				{
					objActivityScheduleDetail.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("ActivityScheduleDetailDAO.cs : InsertActivityScheduleDetail() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objActivityScheduleDetail.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("ActivityScheduleDetailDAO.cs : InsertActivityScheduleDetail() is ended with error.");
			}
			return objActivityScheduleDetail;
		}

		public ActivityScheduleDetail UpdateActivityScheduleDetail(ActivityScheduleDetail objActivityScheduleDetail)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_UPDATE_ACTIVITY_SCHEDULE_DETAIL.ACTIVITY_SCHEDULE_ID_PARAM(objParameterList , objActivityScheduleDetail.ActivityScheduleId);
			if (objActivityScheduleDetail.ActivityDetailObject != null)
			{
				UDSP_UPDATE_ACTIVITY_SCHEDULE_DETAIL.ACTIVITY_DETAIL_ID_PARAM(objParameterList , objActivityScheduleDetail.ActivityDetailObject.ActivityDetailId);
			}
			UDSP_UPDATE_ACTIVITY_SCHEDULE_DETAIL.START_TIME_PARAM(objParameterList , objActivityScheduleDetail.StartTime);
			UDSP_UPDATE_ACTIVITY_SCHEDULE_DETAIL.END_TIME_PARAM(objParameterList , objActivityScheduleDetail.EndTime);
			UDSP_UPDATE_ACTIVITY_SCHEDULE_DETAIL.START_DATE_PARAM(objParameterList , objActivityScheduleDetail.StartDate);
			UDSP_UPDATE_ACTIVITY_SCHEDULE_DETAIL.END_DATE_PARAM(objParameterList , objActivityScheduleDetail.EndDate);
			if (objActivityScheduleDetail.BranchObject != null)
			{
				UDSP_UPDATE_ACTIVITY_SCHEDULE_DETAIL.BRANCH_ID_PARAM(objParameterList , objActivityScheduleDetail.BranchObject.BranchId);
			}
			UDSP_UPDATE_ACTIVITY_SCHEDULE_DETAIL.VENUE_PARAM(objParameterList , objActivityScheduleDetail.Venue);
			UDSP_UPDATE_ACTIVITY_SCHEDULE_DETAIL.ACTUAL_START_TIME_PARAM(objParameterList , objActivityScheduleDetail.ActualStartTime);
			UDSP_UPDATE_ACTIVITY_SCHEDULE_DETAIL.ACTUAL_END_TIME_PARAM(objParameterList , objActivityScheduleDetail.ActualEndTime);
			UDSP_UPDATE_ACTIVITY_SCHEDULE_DETAIL.ACTUAL_START_DATE_PARAM(objParameterList , objActivityScheduleDetail.ActualStartDate);
			UDSP_UPDATE_ACTIVITY_SCHEDULE_DETAIL.ACTUAL_END_DATE_PARAM(objParameterList , objActivityScheduleDetail.ActualEndDate);
			if (objActivityScheduleDetail.ActivityStatusObject != null)
			{
				UDSP_UPDATE_ACTIVITY_SCHEDULE_DETAIL.ACTIVITY_STATUS_ID_PARAM(objParameterList , objActivityScheduleDetail.ActivityStatusObject.MetadataId);
			}
			UDSP_UPDATE_ACTIVITY_SCHEDULE_DETAIL.VERSION_PARAM(objParameterList , objActivityScheduleDetail.Version);
			UDSP_UPDATE_ACTIVITY_SCHEDULE_DETAIL.CREATED_BY_PARAM(objParameterList , objActivityScheduleDetail.CreatedBy);
			UDSP_UPDATE_ACTIVITY_SCHEDULE_DETAIL.CREATED_ON_PARAM(objParameterList , objActivityScheduleDetail.CreatedOn);
			UDSP_UPDATE_ACTIVITY_SCHEDULE_DETAIL.MODIFIED_BY_PARAM(objParameterList , objActivityScheduleDetail.ModifiedBy);
			UDSP_UPDATE_ACTIVITY_SCHEDULE_DETAIL.MODIFIED_ON_PARAM(objParameterList , objActivityScheduleDetail.ModifiedOn);
			UDSP_UPDATE_ACTIVITY_SCHEDULE_DETAIL.RECORD_STATUS_PARAM(objParameterList , objActivityScheduleDetail.RecordStatus);
			try
			{
				Logger.LogInfo("ActivityScheduleDetailDAO.cs : UpdateActivityScheduleDetail() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strUpdateActivityScheduleDetail, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objActivityScheduleDetail.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
					{
						objActivityScheduleDetail.DbOperationStatus = CommonConstant.INVALID;
					}
					else
					{
						objActivityScheduleDetail.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("ActivityScheduleDetailDAO.cs : UpdateActivityScheduleDetail() is ended with success.");
				}
				else
				{
					objActivityScheduleDetail.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("ActivityScheduleDetailDAO.cs : UpdateActivityScheduleDetail() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objActivityScheduleDetail.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("ActivityScheduleDetailDAO.cs : UpdateActivityScheduleDetail() is ended with error.");
			}
			return objActivityScheduleDetail;
		}

		public ActivityScheduleDetail ActivateDeactivateActivityScheduleDetail(ActivityScheduleDetail objActivityScheduleDetail)
		{
			try
			{
				Logger.LogInfo("ActivityScheduleDetailDAO.cs : ActivateDeactivateActivityScheduleDetailDAO() is started.");
				dbExecuteStatus = DataUtility.ActivateDeactivateObject(strDBTableName, objActivityScheduleDetail.ActivityScheduleId,
										objActivityScheduleDetail.Version, objActivityScheduleDetail.RecordStatus, objActivityScheduleDetail.ModifiedBy);
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objActivityScheduleDetail.DbOperationStatus = CommonConstant.SUCCEED;
						Logger.LogInfo("ActivityScheduleDetailDAO.cs : ActivateDeactivateActivityScheduleDetail() is ended with success.");
					}
					else
					{
						objActivityScheduleDetail.DbOperationStatus = CommonConstant.INVALID;
						Logger.LogInfo("ActivityScheduleDetailDAO.cs : ActivateDeactivateActivityScheduleDetail() is ended with success.");
					}
				}
				else
				{
					objActivityScheduleDetail.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("ActivityScheduleDetailDAO.cs : ActivateDeactivateActivityScheduleDetail() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objActivityScheduleDetail.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("ActivityScheduleDetailDAO.cs : ActivateDeactivateActivityScheduleDetail() is ended with error.");
			}
			return objActivityScheduleDetail;
		}

		public ActivityScheduleDetail SelectRecordById(ActivityScheduleDetail objActivityScheduleDetail)
		{
			try
			{
				Logger.LogInfo("ActivityScheduleDetailDAO.cs : SelectRecordById() is started.");
				objActivityScheduleDetail.ObjectDataSet = DataUtility.SelectRecordById(strDBTableName, objActivityScheduleDetail.ActivityScheduleId, objActivityScheduleDetail.Version, strSelectActivityScheduleDetail);
				if (GeneralUtility.IsInteger(objActivityScheduleDetail.ObjectDataSet.Tables[0].Rows[0][0]) && (objActivityScheduleDetail.ObjectDataSet.Tables[1].Columns.Count > 1))
				{
					if (Convert.ToInt32(objActivityScheduleDetail.ObjectDataSet.Tables[0].Rows[0][0]) > 0)
					{
						objActivityScheduleDetail.IsRecordChanged = false;
						objActivityScheduleDetail.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objActivityScheduleDetail.IsRecordChanged = true;
						objActivityScheduleDetail.DbOperationStatus = CommonConstant.INVALID;
					}
					Logger.LogInfo("ActivityScheduleDetailDAO.cs : SelectRecordById() is ended with success.");
				}
				else
				{
					objActivityScheduleDetail.DbOperationStatus = CommonConstant.FAIL;
					dbExecuteStatus = objActivityScheduleDetail.ObjectDataSet.Tables[0].Rows[0][0].ToString() + " " + objActivityScheduleDetail.ObjectDataSet.Tables[1].Rows[0][0].ToString();
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("ActivityScheduleDetailDAO.cs : SelectRecordById() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objActivityScheduleDetail.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("ActivityScheduleDetailDAO.cs : SelectRecordById() is ended with error.");
			}
			return objActivityScheduleDetail;
		}
	}
}
