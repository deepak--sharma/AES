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
	public class StreamMasterDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "STREAM_MASTER";
		private string strSelectStreamMaster = "UDSP_SELECT_STREAM_MASTER";
		private string strInsertStreamMaster = "UDSP_INSERT_STREAM_MASTER";
		private string strUpdateStreamMaster = "UDSP_UPDATE_STREAM_MASTER";
		private string dbExecuteStatus = "";

		public StreamMaster SelectStreamMaster(StreamMaster objStreamMaster)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_STREAM_MASTER.STREAM_ID_PARAM(objParameterList , objStreamMaster.StreamId);			
			UDSP_SELECT_STREAM_MASTER.STREAM_NAME_PARAM(objParameterList , objStreamMaster.StreamName);
			UDSP_SELECT_STREAM_MASTER.DESCRIPTION_PARAM(objParameterList , objStreamMaster.Description);
			UDSP_SELECT_STREAM_MASTER.IS_STUDENT_PARAM(objParameterList , objStreamMaster.IsStudent);
			UDSP_SELECT_STREAM_MASTER.RECORD_STATUS_PARAM(objParameterList , objStreamMaster.RecordStatus);
			try
			{
				Logger.LogInfo("StreamMasterDAO.cs : SelectStreamMaster() is started.");
				objStreamMaster.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectStreamMaster, CommandType.StoredProcedure);
				objStreamMaster.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("StreamMasterDAO.cs : SelectStreamMaster() is ended with success.");
			}
			catch (Exception ex)
			{
				objStreamMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("StreamMasterDAO.cs : SelectStreamMaster() is ended with error.");
			}
			return objStreamMaster;
		}

		public StreamMaster InsertStreamMaster(StreamMaster objStreamMaster)
		{
			objParameterList = new List<SqlParameter>();			
			
			UDSP_INSERT_STREAM_MASTER.STREAM_NAME_PARAM(objParameterList , objStreamMaster.StreamName);
			UDSP_INSERT_STREAM_MASTER.DESCRIPTION_PARAM(objParameterList , objStreamMaster.Description);
			UDSP_INSERT_STREAM_MASTER.IS_STUDENT_PARAM(objParameterList , objStreamMaster.IsStudent);
			UDSP_INSERT_STREAM_MASTER.VERSION_PARAM(objParameterList , objStreamMaster.Version);
			UDSP_INSERT_STREAM_MASTER.CREATED_BY_PARAM(objParameterList , objStreamMaster.CreatedBy);
			UDSP_INSERT_STREAM_MASTER.CREATED_ON_PARAM(objParameterList , objStreamMaster.CreatedOn);
			UDSP_INSERT_STREAM_MASTER.MODIFIED_BY_PARAM(objParameterList , objStreamMaster.ModifiedBy);
			UDSP_INSERT_STREAM_MASTER.MODIFIED_ON_PARAM(objParameterList , objStreamMaster.ModifiedOn);
			UDSP_INSERT_STREAM_MASTER.RECORD_STATUS_PARAM(objParameterList , objStreamMaster.RecordStatus);
			try
			{
				Logger.LogInfo("StreamMasterDAO.cs : InsertStreamMaster() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strInsertStreamMaster, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) > 0 )
					{
						objStreamMaster.StreamId = Convert.ToInt32(dbExecuteStatus);
						objStreamMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objStreamMaster.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("StreamMasterDAO.cs : InsertStreamMaster() is ended with success.");
				}
				else
				{
					objStreamMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("StreamMasterDAO.cs : InsertStreamMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objStreamMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("StreamMasterDAO.cs : InsertStreamMaster() is ended with error.");
			}
			return objStreamMaster;
		}

		public StreamMaster UpdateStreamMaster(StreamMaster objStreamMaster)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_UPDATE_STREAM_MASTER.STREAM_ID_PARAM(objParameterList , objStreamMaster.StreamId);			
			UDSP_UPDATE_STREAM_MASTER.STREAM_NAME_PARAM(objParameterList , objStreamMaster.StreamName);
			UDSP_UPDATE_STREAM_MASTER.DESCRIPTION_PARAM(objParameterList , objStreamMaster.Description);
			UDSP_UPDATE_STREAM_MASTER.IS_STUDENT_PARAM(objParameterList , objStreamMaster.IsStudent);
			UDSP_UPDATE_STREAM_MASTER.VERSION_PARAM(objParameterList , objStreamMaster.Version);
			UDSP_UPDATE_STREAM_MASTER.CREATED_BY_PARAM(objParameterList , objStreamMaster.CreatedBy);
			UDSP_UPDATE_STREAM_MASTER.CREATED_ON_PARAM(objParameterList , objStreamMaster.CreatedOn);
			UDSP_UPDATE_STREAM_MASTER.MODIFIED_BY_PARAM(objParameterList , objStreamMaster.ModifiedBy);
			UDSP_UPDATE_STREAM_MASTER.MODIFIED_ON_PARAM(objParameterList , objStreamMaster.ModifiedOn);
			UDSP_UPDATE_STREAM_MASTER.RECORD_STATUS_PARAM(objParameterList , objStreamMaster.RecordStatus);
			try
			{
				Logger.LogInfo("StreamMasterDAO.cs : UpdateStreamMaster() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strUpdateStreamMaster, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objStreamMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
					{
						objStreamMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					else
					{
						objStreamMaster.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("StreamMasterDAO.cs : UpdateStreamMaster() is ended with success.");
				}
				else
				{
					objStreamMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("StreamMasterDAO.cs : UpdateStreamMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objStreamMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("StreamMasterDAO.cs : UpdateStreamMaster() is ended with error.");
			}
			return objStreamMaster;
		}

		public StreamMaster ActivateDeactivateStreamMaster(StreamMaster objStreamMaster)
		{
			try
			{
				Logger.LogInfo("StreamMasterDAO.cs : ActivateDeactivateStreamMasterDAO() is started.");
				dbExecuteStatus = DataUtility.ActivateDeactivateObject(strDBTableName, objStreamMaster.StreamId,
										objStreamMaster.Version, objStreamMaster.RecordStatus, objStreamMaster.ModifiedBy);
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objStreamMaster.DbOperationStatus = CommonConstant.SUCCEED;
						Logger.LogInfo("StreamMasterDAO.cs : ActivateDeactivateStreamMaster() is ended with success.");
					}
					else
					{
						objStreamMaster.DbOperationStatus = CommonConstant.INVALID;
						Logger.LogInfo("StreamMasterDAO.cs : ActivateDeactivateStreamMaster() is ended with success.");
					}
				}
				else
				{
					objStreamMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("StreamMasterDAO.cs : ActivateDeactivateStreamMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objStreamMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("StreamMasterDAO.cs : ActivateDeactivateStreamMaster() is ended with error.");
			}
			return objStreamMaster;
		}

		public StreamMaster SelectRecordById(StreamMaster objStreamMaster)
		{
			try
			{
				Logger.LogInfo("StreamMasterDAO.cs : SelectRecordById() is started.");
				objStreamMaster.ObjectDataSet = DataUtility.SelectRecordById(strDBTableName, objStreamMaster.StreamId, objStreamMaster.Version, strSelectStreamMaster);
				if (GeneralUtility.IsInteger(objStreamMaster.ObjectDataSet.Tables[0].Rows[0][0]) && (objStreamMaster.ObjectDataSet.Tables[1].Columns.Count > 1))
				{
					if (Convert.ToInt32(objStreamMaster.ObjectDataSet.Tables[0].Rows[0][0]) > 0)
					{
						objStreamMaster.IsRecordChanged = false;
						objStreamMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objStreamMaster.IsRecordChanged = true;
						objStreamMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					Logger.LogInfo("StreamMasterDAO.cs : SelectRecordById() is ended with success.");
				}
				else
				{
					objStreamMaster.DbOperationStatus = CommonConstant.FAIL;
					dbExecuteStatus = objStreamMaster.ObjectDataSet.Tables[0].Rows[0][0].ToString() + " " + objStreamMaster.ObjectDataSet.Tables[1].Rows[0][0].ToString();
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("StreamMasterDAO.cs : SelectRecordById() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objStreamMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("StreamMasterDAO.cs : SelectRecordById() is ended with error.");
			}
			return objStreamMaster;
		}
	}
}
