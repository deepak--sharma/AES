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
	public class RackGroupMasterDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "RACK_GROUP_MASTER";
		private string strSelectRackGroupMaster = "UDSP_SELECT_RACK_GROUP_MASTER";
		private string strInsertRackGroupMaster = "UDSP_INSERT_RACK_GROUP_MASTER";
		private string strUpdateRackGroupMaster = "UDSP_UPDATE_RACK_GROUP_MASTER";
		private string dbExecuteStatus = "";

		public RackGroupMaster SelectRackGroupMaster(RackGroupMaster objRackGroupMaster)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_RACK_GROUP_MASTER.RACK_GROUP_ID_PARAM(objParameterList , objRackGroupMaster.RackGroupId);
			UDSP_SELECT_RACK_GROUP_MASTER.RACK_GROUP_NAME_PARAM(objParameterList , objRackGroupMaster.RackGroupName);
			UDSP_SELECT_RACK_GROUP_MASTER.DESCRIPTION_PARAM(objParameterList , objRackGroupMaster.Description);
			UDSP_SELECT_RACK_GROUP_MASTER.RECORD_STATUS_PARAM(objParameterList , objRackGroupMaster.RecordStatus);
			try
			{
				Logger.LogInfo("RackGroupMasterDAO.cs : SelectRackGroupMaster() is started.");
				objRackGroupMaster.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectRackGroupMaster, CommandType.StoredProcedure);
				objRackGroupMaster.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("RackGroupMasterDAO.cs : SelectRackGroupMaster() is ended with success.");
			}
			catch (Exception ex)
			{
				objRackGroupMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("RackGroupMasterDAO.cs : SelectRackGroupMaster() is ended with error.");
			}
			return objRackGroupMaster;
		}

		public RackGroupMaster InsertRackGroupMaster(RackGroupMaster objRackGroupMaster)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_INSERT_RACK_GROUP_MASTER.RACK_GROUP_NAME_PARAM(objParameterList , objRackGroupMaster.RackGroupName);
			UDSP_INSERT_RACK_GROUP_MASTER.DESCRIPTION_PARAM(objParameterList , objRackGroupMaster.Description);
			UDSP_INSERT_RACK_GROUP_MASTER.VERSION_PARAM(objParameterList , objRackGroupMaster.Version);
			UDSP_INSERT_RACK_GROUP_MASTER.CREATED_BY_PARAM(objParameterList , objRackGroupMaster.CreatedBy);
			UDSP_INSERT_RACK_GROUP_MASTER.CREATED_ON_PARAM(objParameterList , objRackGroupMaster.CreatedOn);
			UDSP_INSERT_RACK_GROUP_MASTER.MODIFIED_BY_PARAM(objParameterList , objRackGroupMaster.ModifiedBy);
			UDSP_INSERT_RACK_GROUP_MASTER.MODIFIED_ON_PARAM(objParameterList , objRackGroupMaster.ModifiedOn);
			UDSP_INSERT_RACK_GROUP_MASTER.RECORD_STATUS_PARAM(objParameterList , objRackGroupMaster.RecordStatus);
			try
			{
				Logger.LogInfo("RackGroupMasterDAO.cs : InsertRackGroupMaster() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strInsertRackGroupMaster, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) > 0 )
					{
						objRackGroupMaster.RackGroupId = Convert.ToInt32(dbExecuteStatus);
						objRackGroupMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objRackGroupMaster.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("RackGroupMasterDAO.cs : InsertRackGroupMaster() is ended with success.");
				}
				else
				{
					objRackGroupMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("RackGroupMasterDAO.cs : InsertRackGroupMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objRackGroupMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("RackGroupMasterDAO.cs : InsertRackGroupMaster() is ended with error.");
			}
			return objRackGroupMaster;
		}

		public RackGroupMaster UpdateRackGroupMaster(RackGroupMaster objRackGroupMaster)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_UPDATE_RACK_GROUP_MASTER.RACK_GROUP_ID_PARAM(objParameterList , objRackGroupMaster.RackGroupId);
			UDSP_UPDATE_RACK_GROUP_MASTER.RACK_GROUP_NAME_PARAM(objParameterList , objRackGroupMaster.RackGroupName);
			UDSP_UPDATE_RACK_GROUP_MASTER.DESCRIPTION_PARAM(objParameterList , objRackGroupMaster.Description);
			UDSP_UPDATE_RACK_GROUP_MASTER.VERSION_PARAM(objParameterList , objRackGroupMaster.Version);
			UDSP_UPDATE_RACK_GROUP_MASTER.CREATED_BY_PARAM(objParameterList , objRackGroupMaster.CreatedBy);
			UDSP_UPDATE_RACK_GROUP_MASTER.CREATED_ON_PARAM(objParameterList , objRackGroupMaster.CreatedOn);
			UDSP_UPDATE_RACK_GROUP_MASTER.MODIFIED_BY_PARAM(objParameterList , objRackGroupMaster.ModifiedBy);
			UDSP_UPDATE_RACK_GROUP_MASTER.MODIFIED_ON_PARAM(objParameterList , objRackGroupMaster.ModifiedOn);
			UDSP_UPDATE_RACK_GROUP_MASTER.RECORD_STATUS_PARAM(objParameterList , objRackGroupMaster.RecordStatus);
			try
			{
				Logger.LogInfo("RackGroupMasterDAO.cs : UpdateRackGroupMaster() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strUpdateRackGroupMaster, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objRackGroupMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
					{
						objRackGroupMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					else
					{
						objRackGroupMaster.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("RackGroupMasterDAO.cs : UpdateRackGroupMaster() is ended with success.");
				}
				else
				{
					objRackGroupMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("RackGroupMasterDAO.cs : UpdateRackGroupMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objRackGroupMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("RackGroupMasterDAO.cs : UpdateRackGroupMaster() is ended with error.");
			}
			return objRackGroupMaster;
		}

		public RackGroupMaster ActivateDeactivateRackGroupMaster(RackGroupMaster objRackGroupMaster)
		{
			try
			{
				Logger.LogInfo("RackGroupMasterDAO.cs : ActivateDeactivateRackGroupMasterDAO() is started.");
				dbExecuteStatus = DataUtility.ActivateDeactivateObject(strDBTableName, objRackGroupMaster.RackGroupId,
										objRackGroupMaster.Version, objRackGroupMaster.RecordStatus, objRackGroupMaster.ModifiedBy);
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objRackGroupMaster.DbOperationStatus = CommonConstant.SUCCEED;
						Logger.LogInfo("RackGroupMasterDAO.cs : ActivateDeactivateRackGroupMaster() is ended with success.");
					}
					else
					{
						objRackGroupMaster.DbOperationStatus = CommonConstant.INVALID;
						Logger.LogInfo("RackGroupMasterDAO.cs : ActivateDeactivateRackGroupMaster() is ended with success.");
					}
				}
				else
				{
					objRackGroupMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("RackGroupMasterDAO.cs : ActivateDeactivateRackGroupMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objRackGroupMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("RackGroupMasterDAO.cs : ActivateDeactivateRackGroupMaster() is ended with error.");
			}
			return objRackGroupMaster;
		}

		public RackGroupMaster SelectRecordById(RackGroupMaster objRackGroupMaster)
		{
			try
			{
				Logger.LogInfo("RackGroupMasterDAO.cs : SelectRecordById() is started.");
				objRackGroupMaster.ObjectDataSet = DataUtility.SelectRecordById(strDBTableName, objRackGroupMaster.RackGroupId, objRackGroupMaster.Version, strSelectRackGroupMaster);
				if (GeneralUtility.IsInteger(objRackGroupMaster.ObjectDataSet.Tables[0].Rows[0][0]) && (objRackGroupMaster.ObjectDataSet.Tables[1].Columns.Count > 1))
				{
					if (Convert.ToInt32(objRackGroupMaster.ObjectDataSet.Tables[0].Rows[0][0]) > 0)
					{
						objRackGroupMaster.IsRecordChanged = false;
						objRackGroupMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objRackGroupMaster.IsRecordChanged = true;
						objRackGroupMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					Logger.LogInfo("RackGroupMasterDAO.cs : SelectRecordById() is ended with success.");
				}
				else
				{
					objRackGroupMaster.DbOperationStatus = CommonConstant.FAIL;
					dbExecuteStatus = objRackGroupMaster.ObjectDataSet.Tables[0].Rows[0][0].ToString() + " " + objRackGroupMaster.ObjectDataSet.Tables[1].Rows[0][0].ToString();
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("RackGroupMasterDAO.cs : SelectRecordById() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objRackGroupMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("RackGroupMasterDAO.cs : SelectRecordById() is ended with error.");
			}
			return objRackGroupMaster;
		}
	}
}
