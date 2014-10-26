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
	public class AttendanceMasterDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "ATTENDANCE_MASTER";
		private string strSelectAttendanceMaster = "UDSP_SELECT_ATTENDANCE_MASTER";
		private string strInsertAttendanceMaster = "UDSP_INSERT_ATTENDANCE_MASTER";
		private string strUpdateAttendanceMaster = "UDSP_UPDATE_ATTENDANCE_MASTER";
		private string dbExecuteStatus = "";

		public AttendanceMaster SelectAttendanceMaster(AttendanceMaster objAttendanceMaster)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_ATTENDANCE_MASTER.ATTENDANCE_ID_PARAM(objParameterList , objAttendanceMaster.AttendanceId);
			UDSP_SELECT_ATTENDANCE_MASTER.MEMBER_ID_PARAM(objParameterList , objAttendanceMaster.MemberId);
			if (objAttendanceMaster.MemberTypeObject != null)
			{
				UDSP_SELECT_ATTENDANCE_MASTER.MEMBER_TYPE_ID_PARAM(objParameterList , objAttendanceMaster.MemberTypeObject.MetadataId);
			}
			UDSP_SELECT_ATTENDANCE_MASTER.ACTIVITY_DETAIL_ID_PARAM(objParameterList , objAttendanceMaster.ActivityDetailId);
			if (objAttendanceMaster.AttendanceStatusObject != null)
			{
				UDSP_SELECT_ATTENDANCE_MASTER.ATTENDANCE_STATUS_ID_PARAM(objParameterList , objAttendanceMaster.AttendanceStatusObject.MetadataId);
			}
			UDSP_SELECT_ATTENDANCE_MASTER.ATTENDANCE_DATE_PARAM(objParameterList , objAttendanceMaster.AttendanceDate);
			UDSP_SELECT_ATTENDANCE_MASTER.IN_TIME_PARAM(objParameterList , objAttendanceMaster.InTime);
			UDSP_SELECT_ATTENDANCE_MASTER.OUT_TIME_PARAM(objParameterList , objAttendanceMaster.OutTime);
			if (objAttendanceMaster.MarkedBy != null)
			{
				UDSP_SELECT_ATTENDANCE_MASTER.MARKED_BY_PARAM(objParameterList , objAttendanceMaster.MarkedBy.EmployeeId);
			}
			UDSP_SELECT_ATTENDANCE_MASTER.RECORD_STATUS_PARAM(objParameterList , objAttendanceMaster.RecordStatus);
			try
			{
				Logger.LogInfo("AttendanceMasterDAO.cs : SelectAttendanceMaster() is started.");
				objAttendanceMaster.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectAttendanceMaster, CommandType.StoredProcedure);
				objAttendanceMaster.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("AttendanceMasterDAO.cs : SelectAttendanceMaster() is ended with success.");
			}
			catch (Exception ex)
			{
				objAttendanceMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("AttendanceMasterDAO.cs : SelectAttendanceMaster() is ended with error.");
			}
			return objAttendanceMaster;
		}

		public AttendanceMaster InsertAttendanceMaster(AttendanceMaster objAttendanceMaster)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_INSERT_ATTENDANCE_MASTER.MEMBER_ID_PARAM(objParameterList , objAttendanceMaster.MemberId);
			if (objAttendanceMaster.MemberTypeObject != null)
			{
				UDSP_INSERT_ATTENDANCE_MASTER.MEMBER_TYPE_ID_PARAM(objParameterList , objAttendanceMaster.MemberTypeObject.MetadataId);
			}
			UDSP_INSERT_ATTENDANCE_MASTER.ACTIVITY_DETAIL_ID_PARAM(objParameterList , objAttendanceMaster.ActivityDetailId);
			if (objAttendanceMaster.AttendanceStatusObject != null)
			{
				UDSP_INSERT_ATTENDANCE_MASTER.ATTENDANCE_STATUS_ID_PARAM(objParameterList , objAttendanceMaster.AttendanceStatusObject.MetadataId);
			}
			UDSP_INSERT_ATTENDANCE_MASTER.ATTENDANCE_DATE_PARAM(objParameterList , objAttendanceMaster.AttendanceDate);
			UDSP_INSERT_ATTENDANCE_MASTER.IN_TIME_PARAM(objParameterList , objAttendanceMaster.InTime);
			UDSP_INSERT_ATTENDANCE_MASTER.OUT_TIME_PARAM(objParameterList , objAttendanceMaster.OutTime);
			if (objAttendanceMaster.MarkedBy != null)
			{
				UDSP_INSERT_ATTENDANCE_MASTER.MARKED_BY_PARAM(objParameterList , objAttendanceMaster.MarkedBy.EmployeeId);
			}
			UDSP_INSERT_ATTENDANCE_MASTER.VERSION_PARAM(objParameterList , objAttendanceMaster.Version);
			UDSP_INSERT_ATTENDANCE_MASTER.CREATED_BY_PARAM(objParameterList , objAttendanceMaster.CreatedBy);
			UDSP_INSERT_ATTENDANCE_MASTER.CREATED_ON_PARAM(objParameterList , objAttendanceMaster.CreatedOn);
			UDSP_INSERT_ATTENDANCE_MASTER.MODIFIED_BY_PARAM(objParameterList , objAttendanceMaster.ModifiedBy);
			UDSP_INSERT_ATTENDANCE_MASTER.MODIFIED_ON_PARAM(objParameterList , objAttendanceMaster.ModifiedOn);
			UDSP_INSERT_ATTENDANCE_MASTER.RECORD_STATUS_PARAM(objParameterList , objAttendanceMaster.RecordStatus);
			try
			{
				Logger.LogInfo("AttendanceMasterDAO.cs : InsertAttendanceMaster() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strInsertAttendanceMaster, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) > 0 )
					{
						objAttendanceMaster.AttendanceId = Convert.ToInt32(dbExecuteStatus);
						objAttendanceMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objAttendanceMaster.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("AttendanceMasterDAO.cs : InsertAttendanceMaster() is ended with success.");
				}
				else
				{
					objAttendanceMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("AttendanceMasterDAO.cs : InsertAttendanceMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objAttendanceMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("AttendanceMasterDAO.cs : InsertAttendanceMaster() is ended with error.");
			}
			return objAttendanceMaster;
		}

		public AttendanceMaster UpdateAttendanceMaster(AttendanceMaster objAttendanceMaster)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_UPDATE_ATTENDANCE_MASTER.ATTENDANCE_ID_PARAM(objParameterList , objAttendanceMaster.AttendanceId);
			UDSP_UPDATE_ATTENDANCE_MASTER.MEMBER_ID_PARAM(objParameterList , objAttendanceMaster.MemberId);
			if (objAttendanceMaster.MemberTypeObject != null)
			{
				UDSP_UPDATE_ATTENDANCE_MASTER.MEMBER_TYPE_ID_PARAM(objParameterList , objAttendanceMaster.MemberTypeObject.MetadataId);
			}
			UDSP_UPDATE_ATTENDANCE_MASTER.ACTIVITY_DETAIL_ID_PARAM(objParameterList , objAttendanceMaster.ActivityDetailId);
			if (objAttendanceMaster.AttendanceStatusObject != null)
			{
				UDSP_UPDATE_ATTENDANCE_MASTER.ATTENDANCE_STATUS_ID_PARAM(objParameterList , objAttendanceMaster.AttendanceStatusObject.MetadataId);
			}
			UDSP_UPDATE_ATTENDANCE_MASTER.ATTENDANCE_DATE_PARAM(objParameterList , objAttendanceMaster.AttendanceDate);
			UDSP_UPDATE_ATTENDANCE_MASTER.IN_TIME_PARAM(objParameterList , objAttendanceMaster.InTime);
			UDSP_UPDATE_ATTENDANCE_MASTER.OUT_TIME_PARAM(objParameterList , objAttendanceMaster.OutTime);
			if (objAttendanceMaster.MarkedBy != null)
			{
				UDSP_UPDATE_ATTENDANCE_MASTER.MARKED_BY_PARAM(objParameterList , objAttendanceMaster.MarkedBy.EmployeeId);
			}
			UDSP_UPDATE_ATTENDANCE_MASTER.VERSION_PARAM(objParameterList , objAttendanceMaster.Version);
			UDSP_UPDATE_ATTENDANCE_MASTER.CREATED_BY_PARAM(objParameterList , objAttendanceMaster.CreatedBy);
			UDSP_UPDATE_ATTENDANCE_MASTER.CREATED_ON_PARAM(objParameterList , objAttendanceMaster.CreatedOn);
			UDSP_UPDATE_ATTENDANCE_MASTER.MODIFIED_BY_PARAM(objParameterList , objAttendanceMaster.ModifiedBy);
			UDSP_UPDATE_ATTENDANCE_MASTER.MODIFIED_ON_PARAM(objParameterList , objAttendanceMaster.ModifiedOn);
			UDSP_UPDATE_ATTENDANCE_MASTER.RECORD_STATUS_PARAM(objParameterList , objAttendanceMaster.RecordStatus);
			try
			{
				Logger.LogInfo("AttendanceMasterDAO.cs : UpdateAttendanceMaster() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strUpdateAttendanceMaster, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objAttendanceMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
					{
						objAttendanceMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					else
					{
						objAttendanceMaster.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("AttendanceMasterDAO.cs : UpdateAttendanceMaster() is ended with success.");
				}
				else
				{
					objAttendanceMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("AttendanceMasterDAO.cs : UpdateAttendanceMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objAttendanceMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("AttendanceMasterDAO.cs : UpdateAttendanceMaster() is ended with error.");
			}
			return objAttendanceMaster;
		}

		public AttendanceMaster ActivateDeactivateAttendanceMaster(AttendanceMaster objAttendanceMaster)
		{
			try
			{
				Logger.LogInfo("AttendanceMasterDAO.cs : ActivateDeactivateAttendanceMasterDAO() is started.");
				dbExecuteStatus = DataUtility.ActivateDeactivateObject(strDBTableName, objAttendanceMaster.AttendanceId,
										objAttendanceMaster.Version, objAttendanceMaster.RecordStatus, objAttendanceMaster.ModifiedBy);
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objAttendanceMaster.DbOperationStatus = CommonConstant.SUCCEED;
						Logger.LogInfo("AttendanceMasterDAO.cs : ActivateDeactivateAttendanceMaster() is ended with success.");
					}
					else
					{
						objAttendanceMaster.DbOperationStatus = CommonConstant.INVALID;
						Logger.LogInfo("AttendanceMasterDAO.cs : ActivateDeactivateAttendanceMaster() is ended with success.");
					}
				}
				else
				{
					objAttendanceMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("AttendanceMasterDAO.cs : ActivateDeactivateAttendanceMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objAttendanceMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("AttendanceMasterDAO.cs : ActivateDeactivateAttendanceMaster() is ended with error.");
			}
			return objAttendanceMaster;
		}

		public AttendanceMaster SelectRecordById(AttendanceMaster objAttendanceMaster)
		{
			try
			{
				Logger.LogInfo("AttendanceMasterDAO.cs : SelectRecordById() is started.");
				objAttendanceMaster.ObjectDataSet = DataUtility.SelectRecordById(strDBTableName, objAttendanceMaster.AttendanceId, objAttendanceMaster.Version, strSelectAttendanceMaster);
				if (GeneralUtility.IsInteger(objAttendanceMaster.ObjectDataSet.Tables[0].Rows[0][0]) && (objAttendanceMaster.ObjectDataSet.Tables[1].Columns.Count > 1))
				{
					if (Convert.ToInt32(objAttendanceMaster.ObjectDataSet.Tables[0].Rows[0][0]) > 0)
					{
						objAttendanceMaster.IsRecordChanged = false;
						objAttendanceMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objAttendanceMaster.IsRecordChanged = true;
						objAttendanceMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					Logger.LogInfo("AttendanceMasterDAO.cs : SelectRecordById() is ended with success.");
				}
				else
				{
					objAttendanceMaster.DbOperationStatus = CommonConstant.FAIL;
					dbExecuteStatus = objAttendanceMaster.ObjectDataSet.Tables[0].Rows[0][0].ToString() + " " + objAttendanceMaster.ObjectDataSet.Tables[1].Rows[0][0].ToString();
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("AttendanceMasterDAO.cs : SelectRecordById() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objAttendanceMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("AttendanceMasterDAO.cs : SelectRecordById() is ended with error.");
			}
			return objAttendanceMaster;
		}
	}
}
