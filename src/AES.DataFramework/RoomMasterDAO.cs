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
	public class RoomMasterDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "ROOM_MASTER";
		private string strSelectRoomMaster = "UDSP_SELECT_ROOM_MASTER";
		private string strInsertRoomMaster = "UDSP_INSERT_ROOM_MASTER";
		private string strUpdateRoomMaster = "UDSP_UPDATE_ROOM_MASTER";
		private string dbExecuteStatus = "";

		public RoomMaster SelectRoomMaster(RoomMaster objRoomMaster)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_ROOM_MASTER.ROOM_ID_PARAM(objParameterList , objRoomMaster.RoomId);
			UDSP_SELECT_ROOM_MASTER.ROOM_NAME_PARAM(objParameterList , objRoomMaster.RoomName);
			if (objRoomMaster.RoomTypeObject != null)
			{
				UDSP_SELECT_ROOM_MASTER.ROOM_TYPE_ID_PARAM(objParameterList , objRoomMaster.RoomTypeObject.MetadataId);
			}
			UDSP_SELECT_ROOM_MASTER.SITTING_CAPACITY_PARAM(objParameterList , objRoomMaster.SittingCapacity);
			UDSP_SELECT_ROOM_MASTER.DESCRIPTION_PARAM(objParameterList , objRoomMaster.Description);
			UDSP_SELECT_ROOM_MASTER.RECORD_STATUS_PARAM(objParameterList , objRoomMaster.RecordStatus);
			try
			{
				Logger.LogInfo("RoomMasterDAO.cs : SelectRoomMaster() is started.");
				objRoomMaster.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectRoomMaster, CommandType.StoredProcedure);
				objRoomMaster.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("RoomMasterDAO.cs : SelectRoomMaster() is ended with success.");
			}
			catch (Exception ex)
			{
				objRoomMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("RoomMasterDAO.cs : SelectRoomMaster() is ended with error.");
			}
			return objRoomMaster;
		}

		public RoomMaster InsertRoomMaster(RoomMaster objRoomMaster)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_INSERT_ROOM_MASTER.ROOM_NAME_PARAM(objParameterList , objRoomMaster.RoomName);
			if (objRoomMaster.RoomTypeObject != null)
			{
				UDSP_INSERT_ROOM_MASTER.ROOM_TYPE_ID_PARAM(objParameterList , objRoomMaster.RoomTypeObject.MetadataId);
			}
			UDSP_INSERT_ROOM_MASTER.SITTING_CAPACITY_PARAM(objParameterList , objRoomMaster.SittingCapacity);
			UDSP_INSERT_ROOM_MASTER.DESCRIPTION_PARAM(objParameterList , objRoomMaster.Description);
			UDSP_INSERT_ROOM_MASTER.VERSION_PARAM(objParameterList , objRoomMaster.Version);
			UDSP_INSERT_ROOM_MASTER.CREATED_BY_PARAM(objParameterList , objRoomMaster.CreatedBy);
			UDSP_INSERT_ROOM_MASTER.CREATED_ON_PARAM(objParameterList , objRoomMaster.CreatedOn);
			UDSP_INSERT_ROOM_MASTER.MODIFIED_BY_PARAM(objParameterList , objRoomMaster.ModifiedBy);
			UDSP_INSERT_ROOM_MASTER.MODIFIED_ON_PARAM(objParameterList , objRoomMaster.ModifiedOn);
			UDSP_INSERT_ROOM_MASTER.RECORD_STATUS_PARAM(objParameterList , objRoomMaster.RecordStatus);
			try
			{
				Logger.LogInfo("RoomMasterDAO.cs : InsertRoomMaster() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strInsertRoomMaster, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) > 0 )
					{
						objRoomMaster.RoomId = Convert.ToInt32(dbExecuteStatus);
						objRoomMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objRoomMaster.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("RoomMasterDAO.cs : InsertRoomMaster() is ended with success.");
				}
				else
				{
					objRoomMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("RoomMasterDAO.cs : InsertRoomMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objRoomMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("RoomMasterDAO.cs : InsertRoomMaster() is ended with error.");
			}
			return objRoomMaster;
		}

		public RoomMaster UpdateRoomMaster(RoomMaster objRoomMaster)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_UPDATE_ROOM_MASTER.ROOM_ID_PARAM(objParameterList , objRoomMaster.RoomId);
			UDSP_UPDATE_ROOM_MASTER.ROOM_NAME_PARAM(objParameterList , objRoomMaster.RoomName);
			if (objRoomMaster.RoomTypeObject != null)
			{
				UDSP_UPDATE_ROOM_MASTER.ROOM_TYPE_ID_PARAM(objParameterList , objRoomMaster.RoomTypeObject.MetadataId);
			}
			UDSP_UPDATE_ROOM_MASTER.SITTING_CAPACITY_PARAM(objParameterList , objRoomMaster.SittingCapacity);
			UDSP_UPDATE_ROOM_MASTER.DESCRIPTION_PARAM(objParameterList , objRoomMaster.Description);
			UDSP_UPDATE_ROOM_MASTER.VERSION_PARAM(objParameterList , objRoomMaster.Version);
			UDSP_UPDATE_ROOM_MASTER.CREATED_BY_PARAM(objParameterList , objRoomMaster.CreatedBy);
			UDSP_UPDATE_ROOM_MASTER.CREATED_ON_PARAM(objParameterList , objRoomMaster.CreatedOn);
			UDSP_UPDATE_ROOM_MASTER.MODIFIED_BY_PARAM(objParameterList , objRoomMaster.ModifiedBy);
			UDSP_UPDATE_ROOM_MASTER.MODIFIED_ON_PARAM(objParameterList , objRoomMaster.ModifiedOn);
			UDSP_UPDATE_ROOM_MASTER.RECORD_STATUS_PARAM(objParameterList , objRoomMaster.RecordStatus);
			try
			{
				Logger.LogInfo("RoomMasterDAO.cs : UpdateRoomMaster() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strUpdateRoomMaster, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objRoomMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
					{
						objRoomMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					else
					{
						objRoomMaster.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("RoomMasterDAO.cs : UpdateRoomMaster() is ended with success.");
				}
				else
				{
					objRoomMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("RoomMasterDAO.cs : UpdateRoomMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objRoomMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("RoomMasterDAO.cs : UpdateRoomMaster() is ended with error.");
			}
			return objRoomMaster;
		}

		public RoomMaster ActivateDeactivateRoomMaster(RoomMaster objRoomMaster)
		{
			try
			{
				Logger.LogInfo("RoomMasterDAO.cs : ActivateDeactivateRoomMasterDAO() is started.");
				dbExecuteStatus = DataUtility.ActivateDeactivateObject(strDBTableName, objRoomMaster.RoomId,
										objRoomMaster.Version, objRoomMaster.RecordStatus, objRoomMaster.ModifiedBy);
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objRoomMaster.DbOperationStatus = CommonConstant.SUCCEED;
						Logger.LogInfo("RoomMasterDAO.cs : ActivateDeactivateRoomMaster() is ended with success.");
					}
					else
					{
						objRoomMaster.DbOperationStatus = CommonConstant.INVALID;
						Logger.LogInfo("RoomMasterDAO.cs : ActivateDeactivateRoomMaster() is ended with success.");
					}
				}
				else
				{
					objRoomMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("RoomMasterDAO.cs : ActivateDeactivateRoomMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objRoomMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("RoomMasterDAO.cs : ActivateDeactivateRoomMaster() is ended with error.");
			}
			return objRoomMaster;
		}

		public RoomMaster SelectRecordById(RoomMaster objRoomMaster)
		{
			try
			{
				Logger.LogInfo("RoomMasterDAO.cs : SelectRecordById() is started.");
				objRoomMaster.ObjectDataSet = DataUtility.SelectRecordById(strDBTableName, objRoomMaster.RoomId, objRoomMaster.Version, strSelectRoomMaster);
				if (GeneralUtility.IsInteger(objRoomMaster.ObjectDataSet.Tables[0].Rows[0][0]) && (objRoomMaster.ObjectDataSet.Tables[1].Columns.Count > 1))
				{
					if (Convert.ToInt32(objRoomMaster.ObjectDataSet.Tables[0].Rows[0][0]) > 0)
					{
						objRoomMaster.IsRecordChanged = false;
						objRoomMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objRoomMaster.IsRecordChanged = true;
						objRoomMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					Logger.LogInfo("RoomMasterDAO.cs : SelectRecordById() is ended with success.");
				}
				else
				{
					objRoomMaster.DbOperationStatus = CommonConstant.FAIL;
					dbExecuteStatus = objRoomMaster.ObjectDataSet.Tables[0].Rows[0][0].ToString() + " " + objRoomMaster.ObjectDataSet.Tables[1].Rows[0][0].ToString();
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("RoomMasterDAO.cs : SelectRecordById() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objRoomMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("RoomMasterDAO.cs : SelectRecordById() is ended with error.");
			}
			return objRoomMaster;
		}
	}
}
