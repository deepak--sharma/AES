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
	public class RackMasterDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "RACK_MASTER";
		private string strSelectRackMaster = "UDSP_SELECT_RACK_MASTER";
		private string strInsertRackMaster = "UDSP_INSERT_RACK_MASTER";
		private string strUpdateRackMaster = "UDSP_UPDATE_RACK_MASTER";
		private string dbExecuteStatus = "";

		public RackMaster SelectRackMaster(RackMaster objRackMaster)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_RACK_MASTER.RACK_ID_PARAM(objParameterList , objRackMaster.RackId);
			UDSP_SELECT_RACK_MASTER.RACK_CODE_PARAM(objParameterList , objRackMaster.RackCode);
			UDSP_SELECT_RACK_MASTER.NO_OF_ROWS_PARAM(objParameterList , objRackMaster.NoOfRows);
			UDSP_SELECT_RACK_MASTER.NO_OF_COLUMNS_PARAM(objParameterList , objRackMaster.NoOfColumns);
			if (objRackMaster.RackGroupObject != null)
			{
				UDSP_SELECT_RACK_MASTER.RACK_GROUP_ID_PARAM(objParameterList , objRackMaster.RackGroupObject.RackGroupId);
			}
			UDSP_SELECT_RACK_MASTER.DESCRIPITION_PARAM(objParameterList , objRackMaster.Descripition);
			UDSP_SELECT_RACK_MASTER.RECORD_STATUS_PARAM(objParameterList , objRackMaster.RecordStatus);
			try
			{
				Logger.LogInfo("RackMasterDAO.cs : SelectRackMaster() is started.");
				objRackMaster.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectRackMaster, CommandType.StoredProcedure);
				objRackMaster.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("RackMasterDAO.cs : SelectRackMaster() is ended with success.");
			}
			catch (Exception ex)
			{
				objRackMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("RackMasterDAO.cs : SelectRackMaster() is ended with error.");
			}
			return objRackMaster;
		}

		public RackMaster InsertRackMaster(RackMaster objRackMaster)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_INSERT_RACK_MASTER.RACK_CODE_PARAM(objParameterList , objRackMaster.RackCode);
			UDSP_INSERT_RACK_MASTER.NO_OF_ROWS_PARAM(objParameterList , objRackMaster.NoOfRows);
			UDSP_INSERT_RACK_MASTER.NO_OF_COLUMNS_PARAM(objParameterList , objRackMaster.NoOfColumns);
			if (objRackMaster.RackGroupObject != null)
			{
				UDSP_INSERT_RACK_MASTER.RACK_GROUP_ID_PARAM(objParameterList , objRackMaster.RackGroupObject.RackGroupId);
			}
			UDSP_INSERT_RACK_MASTER.DESCRIPITION_PARAM(objParameterList , objRackMaster.Descripition);
			UDSP_INSERT_RACK_MASTER.VERSION_PARAM(objParameterList , objRackMaster.Version);
			UDSP_INSERT_RACK_MASTER.CREATED_BY_PARAM(objParameterList , objRackMaster.CreatedBy);
			UDSP_INSERT_RACK_MASTER.CREATED_ON_PARAM(objParameterList , objRackMaster.CreatedOn);
			UDSP_INSERT_RACK_MASTER.MODIFIED_BY_PARAM(objParameterList , objRackMaster.ModifiedBy);
			UDSP_INSERT_RACK_MASTER.MODIFIED_ON_PARAM(objParameterList , objRackMaster.ModifiedOn);
			UDSP_INSERT_RACK_MASTER.RECORD_STATUS_PARAM(objParameterList , objRackMaster.RecordStatus);
			try
			{
				Logger.LogInfo("RackMasterDAO.cs : InsertRackMaster() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strInsertRackMaster, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) > 0 )
					{
						objRackMaster.RackId = Convert.ToInt32(dbExecuteStatus);
						objRackMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objRackMaster.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("RackMasterDAO.cs : InsertRackMaster() is ended with success.");
				}
				else
				{
					objRackMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("RackMasterDAO.cs : InsertRackMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objRackMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("RackMasterDAO.cs : InsertRackMaster() is ended with error.");
			}
			return objRackMaster;
		}

		public RackMaster UpdateRackMaster(RackMaster objRackMaster)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_UPDATE_RACK_MASTER.RACK_ID_PARAM(objParameterList , objRackMaster.RackId);
			UDSP_UPDATE_RACK_MASTER.RACK_CODE_PARAM(objParameterList , objRackMaster.RackCode);
			UDSP_UPDATE_RACK_MASTER.NO_OF_ROWS_PARAM(objParameterList , objRackMaster.NoOfRows);
			UDSP_UPDATE_RACK_MASTER.NO_OF_COLUMNS_PARAM(objParameterList , objRackMaster.NoOfColumns);
			if (objRackMaster.RackGroupObject != null)
			{
				UDSP_UPDATE_RACK_MASTER.RACK_GROUP_ID_PARAM(objParameterList , objRackMaster.RackGroupObject.RackGroupId);
			}
			UDSP_UPDATE_RACK_MASTER.DESCRIPITION_PARAM(objParameterList , objRackMaster.Descripition);
			UDSP_UPDATE_RACK_MASTER.VERSION_PARAM(objParameterList , objRackMaster.Version);
			UDSP_UPDATE_RACK_MASTER.CREATED_BY_PARAM(objParameterList , objRackMaster.CreatedBy);
			UDSP_UPDATE_RACK_MASTER.CREATED_ON_PARAM(objParameterList , objRackMaster.CreatedOn);
			UDSP_UPDATE_RACK_MASTER.MODIFIED_BY_PARAM(objParameterList , objRackMaster.ModifiedBy);
			UDSP_UPDATE_RACK_MASTER.MODIFIED_ON_PARAM(objParameterList , objRackMaster.ModifiedOn);
			UDSP_UPDATE_RACK_MASTER.RECORD_STATUS_PARAM(objParameterList , objRackMaster.RecordStatus);
			try
			{
				Logger.LogInfo("RackMasterDAO.cs : UpdateRackMaster() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strUpdateRackMaster, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objRackMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
					{
						objRackMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					else
					{
						objRackMaster.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("RackMasterDAO.cs : UpdateRackMaster() is ended with success.");
				}
				else
				{
					objRackMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("RackMasterDAO.cs : UpdateRackMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objRackMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("RackMasterDAO.cs : UpdateRackMaster() is ended with error.");
			}
			return objRackMaster;
		}

		public RackMaster ActivateDeactivateRackMaster(RackMaster objRackMaster)
		{
			try
			{
				Logger.LogInfo("RackMasterDAO.cs : ActivateDeactivateRackMasterDAO() is started.");
				dbExecuteStatus = DataUtility.ActivateDeactivateObject(strDBTableName, objRackMaster.RackId,
										objRackMaster.Version, objRackMaster.RecordStatus, objRackMaster.ModifiedBy);
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objRackMaster.DbOperationStatus = CommonConstant.SUCCEED;
						Logger.LogInfo("RackMasterDAO.cs : ActivateDeactivateRackMaster() is ended with success.");
					}
					else
					{
						objRackMaster.DbOperationStatus = CommonConstant.INVALID;
						Logger.LogInfo("RackMasterDAO.cs : ActivateDeactivateRackMaster() is ended with success.");
					}
				}
				else
				{
					objRackMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("RackMasterDAO.cs : ActivateDeactivateRackMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objRackMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("RackMasterDAO.cs : ActivateDeactivateRackMaster() is ended with error.");
			}
			return objRackMaster;
		}

		public RackMaster SelectRecordById(RackMaster objRackMaster)
		{
			try
			{
				Logger.LogInfo("RackMasterDAO.cs : SelectRecordById() is started.");
				objRackMaster.ObjectDataSet = DataUtility.SelectRecordById(strDBTableName, objRackMaster.RackId, objRackMaster.Version, strSelectRackMaster);
				if (GeneralUtility.IsInteger(objRackMaster.ObjectDataSet.Tables[0].Rows[0][0]) && (objRackMaster.ObjectDataSet.Tables[1].Columns.Count > 1))
				{
					if (Convert.ToInt32(objRackMaster.ObjectDataSet.Tables[0].Rows[0][0]) > 0)
					{
						objRackMaster.IsRecordChanged = false;
						objRackMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objRackMaster.IsRecordChanged = true;
						objRackMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					Logger.LogInfo("RackMasterDAO.cs : SelectRecordById() is ended with success.");
				}
				else
				{
					objRackMaster.DbOperationStatus = CommonConstant.FAIL;
					dbExecuteStatus = objRackMaster.ObjectDataSet.Tables[0].Rows[0][0].ToString() + " " + objRackMaster.ObjectDataSet.Tables[1].Rows[0][0].ToString();
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("RackMasterDAO.cs : SelectRecordById() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objRackMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("RackMasterDAO.cs : SelectRecordById() is ended with error.");
			}
			return objRackMaster;
		}
	}
}
