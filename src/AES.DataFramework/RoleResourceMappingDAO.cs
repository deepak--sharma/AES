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
	public class RoleResourceMappingDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "ROLE_RESOURCE_MAPPING";
		private string strSelectRoleResourceMapping = "UDSP_SELECT_ROLE_RESOURCE_MAPPING";
		private string strInsertRoleResourceMapping = "UDSP_INSERT_ROLE_RESOURCE_MAPPING";
		private string strUpdateRoleResourceMapping = "UDSP_UPDATE_ROLE_RESOURCE_MAPPING";
		private string dbExecuteStatus = "";

		public RoleResourceMapping SelectRoleResourceMapping(RoleResourceMapping objRoleResourceMapping)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_ROLE_RESOURCE_MAPPING.ROLE_RESOURCE_MAPPING_ID_PARAM(objParameterList , objRoleResourceMapping.RoleResourceMappingId);
			if (objRoleResourceMapping.RoleObject != null)
			{
				UDSP_SELECT_ROLE_RESOURCE_MAPPING.ROLE_ID_PARAM(objParameterList , objRoleResourceMapping.RoleObject.RoleId);
			}
			if (objRoleResourceMapping.ResourceObject != null)
			{
				UDSP_SELECT_ROLE_RESOURCE_MAPPING.RESOURCE_ID_PARAM(objParameterList , objRoleResourceMapping.ResourceObject.ResourceId);
			}
			UDSP_SELECT_ROLE_RESOURCE_MAPPING.VIEW_PARAM(objParameterList , objRoleResourceMapping.View);
			UDSP_SELECT_ROLE_RESOURCE_MAPPING.CREATE_PARAM(objParameterList , objRoleResourceMapping.Create);
			UDSP_SELECT_ROLE_RESOURCE_MAPPING.EDIT_PARAM(objParameterList , objRoleResourceMapping.Edit);
			UDSP_SELECT_ROLE_RESOURCE_MAPPING.DELETE_PARAM(objParameterList , objRoleResourceMapping.Delete);
			UDSP_SELECT_ROLE_RESOURCE_MAPPING.DOWNLOAD_PARAM(objParameterList , objRoleResourceMapping.Download);
			UDSP_SELECT_ROLE_RESOURCE_MAPPING.RECORD_STATUS_PARAM(objParameterList , objRoleResourceMapping.RecordStatus);
			try
			{
				Logger.LogInfo("RoleResourceMappingDAO.cs : SelectRoleResourceMapping() is started.");
				objRoleResourceMapping.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectRoleResourceMapping, CommandType.StoredProcedure);
				objRoleResourceMapping.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("RoleResourceMappingDAO.cs : SelectRoleResourceMapping() is ended with success.");
			}
			catch (Exception ex)
			{
				objRoleResourceMapping.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("RoleResourceMappingDAO.cs : SelectRoleResourceMapping() is ended with error.");
			}
			return objRoleResourceMapping;
		}

		public RoleResourceMapping InsertRoleResourceMapping(RoleResourceMapping objRoleResourceMapping)
		{
			objParameterList = new List<SqlParameter>();
				
			if (objRoleResourceMapping.RoleObject != null)
			{
				UDSP_INSERT_ROLE_RESOURCE_MAPPING.ROLE_ID_PARAM(objParameterList , objRoleResourceMapping.RoleObject.RoleId);
			}
			if (objRoleResourceMapping.ResourceObject != null)
			{
				UDSP_INSERT_ROLE_RESOURCE_MAPPING.RESOURCE_ID_PARAM(objParameterList , objRoleResourceMapping.ResourceObject.ResourceId);
			}
			UDSP_INSERT_ROLE_RESOURCE_MAPPING.VIEW_PARAM(objParameterList , objRoleResourceMapping.View);
			UDSP_INSERT_ROLE_RESOURCE_MAPPING.CREATE_PARAM(objParameterList , objRoleResourceMapping.Create);
			UDSP_INSERT_ROLE_RESOURCE_MAPPING.EDIT_PARAM(objParameterList , objRoleResourceMapping.Edit);
			UDSP_INSERT_ROLE_RESOURCE_MAPPING.DELETE_PARAM(objParameterList , objRoleResourceMapping.Delete);
			UDSP_INSERT_ROLE_RESOURCE_MAPPING.DOWNLOAD_PARAM(objParameterList , objRoleResourceMapping.Download);
			UDSP_INSERT_ROLE_RESOURCE_MAPPING.VERSION_PARAM(objParameterList , objRoleResourceMapping.Version);
			UDSP_INSERT_ROLE_RESOURCE_MAPPING.CREATED_BY_PARAM(objParameterList , objRoleResourceMapping.CreatedBy);
			UDSP_INSERT_ROLE_RESOURCE_MAPPING.CREATED_ON_PARAM(objParameterList , objRoleResourceMapping.CreatedOn);
			UDSP_INSERT_ROLE_RESOURCE_MAPPING.MODIFIED_BY_PARAM(objParameterList , objRoleResourceMapping.ModifiedBy);
			UDSP_INSERT_ROLE_RESOURCE_MAPPING.MODIFIED_ON_PARAM(objParameterList , objRoleResourceMapping.ModifiedOn);
			UDSP_INSERT_ROLE_RESOURCE_MAPPING.RECORD_STATUS_PARAM(objParameterList , objRoleResourceMapping.RecordStatus);
			try
			{
				Logger.LogInfo("RoleResourceMappingDAO.cs : InsertRoleResourceMapping() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strInsertRoleResourceMapping, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) > 0 )
					{
						objRoleResourceMapping.RoleResourceMappingId = Convert.ToInt32(dbExecuteStatus);
						objRoleResourceMapping.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objRoleResourceMapping.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("RoleResourceMappingDAO.cs : InsertRoleResourceMapping() is ended with success.");
				}
				else
				{
					objRoleResourceMapping.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("RoleResourceMappingDAO.cs : InsertRoleResourceMapping() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objRoleResourceMapping.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("RoleResourceMappingDAO.cs : InsertRoleResourceMapping() is ended with error.");
			}
			return objRoleResourceMapping;
		}

		public RoleResourceMapping UpdateRoleResourceMapping(RoleResourceMapping objRoleResourceMapping)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_UPDATE_ROLE_RESOURCE_MAPPING.ROLE_RESOURCE_MAPPING_ID_PARAM(objParameterList , objRoleResourceMapping.RoleResourceMappingId);
			if (objRoleResourceMapping.RoleObject != null)
			{
				UDSP_UPDATE_ROLE_RESOURCE_MAPPING.ROLE_ID_PARAM(objParameterList , objRoleResourceMapping.RoleObject.RoleId);
			}
			if (objRoleResourceMapping.ResourceObject != null)
			{
				UDSP_UPDATE_ROLE_RESOURCE_MAPPING.RESOURCE_ID_PARAM(objParameterList , objRoleResourceMapping.ResourceObject.ResourceId);
			}
			UDSP_UPDATE_ROLE_RESOURCE_MAPPING.VIEW_PARAM(objParameterList , objRoleResourceMapping.View);
			UDSP_UPDATE_ROLE_RESOURCE_MAPPING.CREATE_PARAM(objParameterList , objRoleResourceMapping.Create);
			UDSP_UPDATE_ROLE_RESOURCE_MAPPING.EDIT_PARAM(objParameterList , objRoleResourceMapping.Edit);
			UDSP_UPDATE_ROLE_RESOURCE_MAPPING.DELETE_PARAM(objParameterList , objRoleResourceMapping.Delete);
			UDSP_UPDATE_ROLE_RESOURCE_MAPPING.DOWNLOAD_PARAM(objParameterList , objRoleResourceMapping.Download);
			UDSP_UPDATE_ROLE_RESOURCE_MAPPING.VERSION_PARAM(objParameterList , objRoleResourceMapping.Version);
			UDSP_UPDATE_ROLE_RESOURCE_MAPPING.CREATED_BY_PARAM(objParameterList , objRoleResourceMapping.CreatedBy);
			UDSP_UPDATE_ROLE_RESOURCE_MAPPING.CREATED_ON_PARAM(objParameterList , objRoleResourceMapping.CreatedOn);
			UDSP_UPDATE_ROLE_RESOURCE_MAPPING.MODIFIED_BY_PARAM(objParameterList , objRoleResourceMapping.ModifiedBy);
			UDSP_UPDATE_ROLE_RESOURCE_MAPPING.MODIFIED_ON_PARAM(objParameterList , objRoleResourceMapping.ModifiedOn);
			UDSP_UPDATE_ROLE_RESOURCE_MAPPING.RECORD_STATUS_PARAM(objParameterList , objRoleResourceMapping.RecordStatus);
			try
			{
				Logger.LogInfo("RoleResourceMappingDAO.cs : UpdateRoleResourceMapping() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strUpdateRoleResourceMapping, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objRoleResourceMapping.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
					{
						objRoleResourceMapping.DbOperationStatus = CommonConstant.INVALID;
					}
					else
					{
						objRoleResourceMapping.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("RoleResourceMappingDAO.cs : UpdateRoleResourceMapping() is ended with success.");
				}
				else
				{
					objRoleResourceMapping.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("RoleResourceMappingDAO.cs : UpdateRoleResourceMapping() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objRoleResourceMapping.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("RoleResourceMappingDAO.cs : UpdateRoleResourceMapping() is ended with error.");
			}
			return objRoleResourceMapping;
		}

		public RoleResourceMapping ActivateDeactivateRoleResourceMapping(RoleResourceMapping objRoleResourceMapping)
		{
			try
			{
				Logger.LogInfo("RoleResourceMappingDAO.cs : ActivateDeactivateRoleResourceMappingDAO() is started.");
				dbExecuteStatus = DataUtility.ActivateDeactivateObject(strDBTableName, objRoleResourceMapping.RoleResourceMappingId,
										objRoleResourceMapping.Version, objRoleResourceMapping.RecordStatus, objRoleResourceMapping.ModifiedBy);
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objRoleResourceMapping.DbOperationStatus = CommonConstant.SUCCEED;
						Logger.LogInfo("RoleResourceMappingDAO.cs : ActivateDeactivateRoleResourceMapping() is ended with success.");
					}
					else
					{
						objRoleResourceMapping.DbOperationStatus = CommonConstant.INVALID;
						Logger.LogInfo("RoleResourceMappingDAO.cs : ActivateDeactivateRoleResourceMapping() is ended with success.");
					}
				}
				else
				{
					objRoleResourceMapping.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("RoleResourceMappingDAO.cs : ActivateDeactivateRoleResourceMapping() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objRoleResourceMapping.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("RoleResourceMappingDAO.cs : ActivateDeactivateRoleResourceMapping() is ended with error.");
			}
			return objRoleResourceMapping;
		}

		public RoleResourceMapping SelectRecordById(RoleResourceMapping objRoleResourceMapping)
		{
			try
			{
				Logger.LogInfo("RoleResourceMappingDAO.cs : SelectRecordById() is started.");
				objRoleResourceMapping.ObjectDataSet = DataUtility.SelectRecordById(strDBTableName, objRoleResourceMapping.RoleResourceMappingId, objRoleResourceMapping.Version, strSelectRoleResourceMapping);
				if (GeneralUtility.IsInteger(objRoleResourceMapping.ObjectDataSet.Tables[0].Rows[0][0]) && (objRoleResourceMapping.ObjectDataSet.Tables[1].Columns.Count > 1))
				{
					if (Convert.ToInt32(objRoleResourceMapping.ObjectDataSet.Tables[0].Rows[0][0]) > 0)
					{
						objRoleResourceMapping.IsRecordChanged = false;
						objRoleResourceMapping.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objRoleResourceMapping.IsRecordChanged = true;
						objRoleResourceMapping.DbOperationStatus = CommonConstant.INVALID;
					}
					Logger.LogInfo("RoleResourceMappingDAO.cs : SelectRecordById() is ended with success.");
				}
				else
				{
					objRoleResourceMapping.DbOperationStatus = CommonConstant.FAIL;
					dbExecuteStatus = objRoleResourceMapping.ObjectDataSet.Tables[0].Rows[0][0].ToString() + " " + objRoleResourceMapping.ObjectDataSet.Tables[1].Rows[0][0].ToString();
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("RoleResourceMappingDAO.cs : SelectRecordById() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objRoleResourceMapping.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("RoleResourceMappingDAO.cs : SelectRecordById() is ended with error.");
			}
			return objRoleResourceMapping;
		}
	}
}
