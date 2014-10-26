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
	public class FeeScheduleDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "FEE_SCHEDULE";
		private string strSelectFeeSchedule = "SP_SELECT_FEE_SCHEDULE";
		private string strInsertFeeSchedule = "UDSP_INSERT_FEE_SCHEDULE";
		private string strUpdateFeeSchedule = "UDSP_UPDATE_FEE_SCHEDULE";
		private string dbExecuteStatus = "";

		public FeeSchedule SelectFeeSchedule(FeeSchedule objFeeSchedule)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_FEE_SCHEDULE.FEE_SCHEDULE_ID_PARAM(objParameterList , objFeeSchedule.FeeScheduleId);
			UDSP_SELECT_FEE_SCHEDULE.NO_OF_INSTANCES_PARAM(objParameterList , objFeeSchedule.NoOfInstances);
			if (objFeeSchedule.FeeProcessModeObject != null)
			{
				UDSP_SELECT_FEE_SCHEDULE.FEE_PROCESS_MODE_ID_PARAM(objParameterList , objFeeSchedule.FeeProcessModeObject.MetadataId);
			}
			if (objFeeSchedule.BranchObject != null)
			{
				UDSP_SELECT_FEE_SCHEDULE.BRANCH_ID_PARAM(objParameterList , objFeeSchedule.BranchObject.BranchId);
			}
			if (objFeeSchedule.ClassObject != null)
			{
				UDSP_SELECT_FEE_SCHEDULE.CLASS_ID_PARAM(objParameterList , objFeeSchedule.ClassObject.ClassId);
			}			
			UDSP_SELECT_FEE_SCHEDULE.RECORD_STATUS_PARAM(objParameterList , objFeeSchedule.RecordStatus);
			try
			{
				Logger.LogInfo("FeeScheduleDAO.cs : SelectFeeSchedule() is started.");
				objFeeSchedule.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectFeeSchedule, CommandType.StoredProcedure);
				objFeeSchedule.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("FeeScheduleDAO.cs : SelectFeeSchedule() is ended with success.");
			}
			catch (Exception ex)
			{
				objFeeSchedule.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("FeeScheduleDAO.cs : SelectFeeSchedule() is ended with error.");
			}
			return objFeeSchedule;
		}

		public FeeSchedule InsertFeeSchedule(FeeSchedule objFeeSchedule)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_INSERT_FEE_SCHEDULE.NO_OF_INSTANCES_PARAM(objParameterList , objFeeSchedule.NoOfInstances);
			if (objFeeSchedule.FeeProcessModeObject != null)
			{
				UDSP_INSERT_FEE_SCHEDULE.FEE_PROCESS_MODE_ID_PARAM(objParameterList , objFeeSchedule.FeeProcessModeObject.MetadataId);
			}
			if (objFeeSchedule.BranchObject != null)
			{
				UDSP_INSERT_FEE_SCHEDULE.BRANCH_ID_PARAM(objParameterList , objFeeSchedule.BranchObject.BranchId);
			}
			if (objFeeSchedule.ClassObject != null)
			{
				UDSP_INSERT_FEE_SCHEDULE.CLASS_ID_PARAM(objParameterList , objFeeSchedule.ClassObject.ClassId);
			}
            if (objFeeSchedule.StreamObject!= null)
            {
                NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@STREAM_ID", objFeeSchedule.StreamObject.StreamId);
            }			
			UDSP_INSERT_FEE_SCHEDULE.VERSION_PARAM(objParameterList , objFeeSchedule.Version);
			UDSP_INSERT_FEE_SCHEDULE.CREATED_BY_PARAM(objParameterList , objFeeSchedule.CreatedBy);
			UDSP_INSERT_FEE_SCHEDULE.CREATED_ON_PARAM(objParameterList , objFeeSchedule.CreatedOn);
			UDSP_INSERT_FEE_SCHEDULE.MODIFIED_BY_PARAM(objParameterList , objFeeSchedule.ModifiedBy);
			UDSP_INSERT_FEE_SCHEDULE.MODIFIED_ON_PARAM(objParameterList , objFeeSchedule.ModifiedOn);
			UDSP_INSERT_FEE_SCHEDULE.RECORD_STATUS_PARAM(objParameterList , objFeeSchedule.RecordStatus);
			try
			{
				Logger.LogInfo("FeeScheduleDAO.cs : InsertFeeSchedule() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strInsertFeeSchedule, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) > 0 )
					{
						objFeeSchedule.FeeScheduleId = Convert.ToInt32(dbExecuteStatus);
						objFeeSchedule.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objFeeSchedule.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("FeeScheduleDAO.cs : InsertFeeSchedule() is ended with success.");
				}
				else
				{
					objFeeSchedule.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("FeeScheduleDAO.cs : InsertFeeSchedule() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objFeeSchedule.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("FeeScheduleDAO.cs : InsertFeeSchedule() is ended with error.");
			}
			return objFeeSchedule;
		}

		public FeeSchedule UpdateFeeSchedule(FeeSchedule objFeeSchedule)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_UPDATE_FEE_SCHEDULE.FEE_SCHEDULE_ID_PARAM(objParameterList , objFeeSchedule.FeeScheduleId);
			UDSP_UPDATE_FEE_SCHEDULE.NO_OF_INSTANCES_PARAM(objParameterList , objFeeSchedule.NoOfInstances);
			if (objFeeSchedule.FeeProcessModeObject != null)
			{
				UDSP_UPDATE_FEE_SCHEDULE.FEE_PROCESS_MODE_ID_PARAM(objParameterList , objFeeSchedule.FeeProcessModeObject.MetadataId);
			}
			if (objFeeSchedule.BranchObject != null)
			{
				UDSP_UPDATE_FEE_SCHEDULE.BRANCH_ID_PARAM(objParameterList , objFeeSchedule.BranchObject.BranchId);
			}
			if (objFeeSchedule.ClassObject != null)
			{
				UDSP_UPDATE_FEE_SCHEDULE.CLASS_ID_PARAM(objParameterList , objFeeSchedule.ClassObject.ClassId);
			}
            if (objFeeSchedule.StreamObject != null)
            {
                NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@STREAM_ID", objFeeSchedule.StreamObject.StreamId);
            }			
			UDSP_UPDATE_FEE_SCHEDULE.VERSION_PARAM(objParameterList , objFeeSchedule.Version);
			UDSP_UPDATE_FEE_SCHEDULE.CREATED_BY_PARAM(objParameterList , objFeeSchedule.CreatedBy);
			UDSP_UPDATE_FEE_SCHEDULE.CREATED_ON_PARAM(objParameterList , objFeeSchedule.CreatedOn);
			UDSP_UPDATE_FEE_SCHEDULE.MODIFIED_BY_PARAM(objParameterList , objFeeSchedule.ModifiedBy);
			UDSP_UPDATE_FEE_SCHEDULE.MODIFIED_ON_PARAM(objParameterList , objFeeSchedule.ModifiedOn);
			UDSP_UPDATE_FEE_SCHEDULE.RECORD_STATUS_PARAM(objParameterList , objFeeSchedule.RecordStatus);
			try
			{
				Logger.LogInfo("FeeScheduleDAO.cs : UpdateFeeSchedule() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strUpdateFeeSchedule, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objFeeSchedule.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
					{
						objFeeSchedule.DbOperationStatus = CommonConstant.INVALID;
					}
					else
					{
						objFeeSchedule.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("FeeScheduleDAO.cs : UpdateFeeSchedule() is ended with success.");
				}
				else
				{
					objFeeSchedule.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("FeeScheduleDAO.cs : UpdateFeeSchedule() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objFeeSchedule.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("FeeScheduleDAO.cs : UpdateFeeSchedule() is ended with error.");
			}
			return objFeeSchedule;
		}

		public FeeSchedule ActivateDeactivateFeeSchedule(FeeSchedule objFeeSchedule)
		{
			try
			{
				Logger.LogInfo("FeeScheduleDAO.cs : ActivateDeactivateFeeScheduleDAO() is started.");
				dbExecuteStatus = DataUtility.ActivateDeactivateObject(strDBTableName, objFeeSchedule.FeeScheduleId,
										objFeeSchedule.Version, objFeeSchedule.RecordStatus, objFeeSchedule.ModifiedBy);
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objFeeSchedule.DbOperationStatus = CommonConstant.SUCCEED;
						Logger.LogInfo("FeeScheduleDAO.cs : ActivateDeactivateFeeSchedule() is ended with success.");
					}
					else
					{
						objFeeSchedule.DbOperationStatus = CommonConstant.INVALID;
						Logger.LogInfo("FeeScheduleDAO.cs : ActivateDeactivateFeeSchedule() is ended with success.");
					}
				}
				else
				{
					objFeeSchedule.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("FeeScheduleDAO.cs : ActivateDeactivateFeeSchedule() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objFeeSchedule.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("FeeScheduleDAO.cs : ActivateDeactivateFeeSchedule() is ended with error.");
			}
			return objFeeSchedule;
		}

		public FeeSchedule SelectRecordById(FeeSchedule objFeeSchedule)
		{
			try
			{
				Logger.LogInfo("FeeScheduleDAO.cs : SelectRecordById() is started.");
				objFeeSchedule.ObjectDataSet = DataUtility.SelectRecordById(strDBTableName, objFeeSchedule.FeeScheduleId, objFeeSchedule.Version, strSelectFeeSchedule);
				if (GeneralUtility.IsInteger(objFeeSchedule.ObjectDataSet.Tables[0].Rows[0][0]) && (objFeeSchedule.ObjectDataSet.Tables[1].Columns.Count > 1))
				{
					if (Convert.ToInt32(objFeeSchedule.ObjectDataSet.Tables[0].Rows[0][0]) > 0)
					{
						objFeeSchedule.IsRecordChanged = false;
						objFeeSchedule.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objFeeSchedule.IsRecordChanged = true;
						objFeeSchedule.DbOperationStatus = CommonConstant.INVALID;
					}
					Logger.LogInfo("FeeScheduleDAO.cs : SelectRecordById() is ended with success.");
				}
				else
				{
					objFeeSchedule.DbOperationStatus = CommonConstant.FAIL;
					dbExecuteStatus = objFeeSchedule.ObjectDataSet.Tables[0].Rows[0][0].ToString() + " " + objFeeSchedule.ObjectDataSet.Tables[1].Rows[0][0].ToString();
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("FeeScheduleDAO.cs : SelectRecordById() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objFeeSchedule.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("FeeScheduleDAO.cs : SelectRecordById() is ended with error.");
			}
			return objFeeSchedule;
		}
	}
}
