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
	public class ResourceManagementDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "RESOURCE_MANAGEMENT";
		private string strSelectResourceManagement = "UDSP_SELECT_RESOURCE_MANAGEMENT";
		private string strInsertResourceManagement = "UDSP_INSERT_RESOURCE_MANAGEMENT";
		private string strUpdateResourceManagement = "UDSP_UPDATE_RESOURCE_MANAGEMENT";
		private string dbExecuteStatus = "";

		public ResourceManagement SelectResourceManagement(ResourceManagement objResourceManagement)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_RESOURCE_MANAGEMENT.RESOURCE_ID_PARAM(objParameterList , objResourceManagement.ResourceId);
			UDSP_SELECT_RESOURCE_MANAGEMENT.RESOURCE_NAME_PARAM(objParameterList , objResourceManagement.ResourceName);
			UDSP_SELECT_RESOURCE_MANAGEMENT.URL_PARAM(objParameterList , objResourceManagement.Url);
			if (objResourceManagement.ParentResourceObject != null)
			{
				UDSP_SELECT_RESOURCE_MANAGEMENT.PARENT_RESOURCE_ID_PARAM(objParameterList , objResourceManagement.ParentResourceObject.ResourceId);
			}
			UDSP_SELECT_RESOURCE_MANAGEMENT.RECORD_STATUS_PARAM(objParameterList , objResourceManagement.RecordStatus);
			try
			{
				Logger.LogInfo("ResourceManagementDAO.cs : SelectResourceManagement() is started.");
				objResourceManagement.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectResourceManagement, CommandType.StoredProcedure);
				objResourceManagement.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("ResourceManagementDAO.cs : SelectResourceManagement() is ended with success.");
			}
			catch (Exception ex)
			{
				objResourceManagement.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("ResourceManagementDAO.cs : SelectResourceManagement() is ended with error.");
			}
			return objResourceManagement;
		}

		public ResourceManagement InsertResourceManagement(ResourceManagement objResourceManagement)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_INSERT_RESOURCE_MANAGEMENT.RESOURCE_NAME_PARAM(objParameterList , objResourceManagement.ResourceName);
			UDSP_INSERT_RESOURCE_MANAGEMENT.URL_PARAM(objParameterList , objResourceManagement.Url);
			if (objResourceManagement.ParentResourceObject != null)
			{
				UDSP_INSERT_RESOURCE_MANAGEMENT.PARENT_RESOURCE_ID_PARAM(objParameterList , objResourceManagement.ParentResourceObject.ResourceId);
			}
			UDSP_INSERT_RESOURCE_MANAGEMENT.VERSION_PARAM(objParameterList , objResourceManagement.Version);
			UDSP_INSERT_RESOURCE_MANAGEMENT.CREATED_BY_PARAM(objParameterList , objResourceManagement.CreatedBy);
			UDSP_INSERT_RESOURCE_MANAGEMENT.CREATED_ON_PARAM(objParameterList , objResourceManagement.CreatedOn);
			UDSP_INSERT_RESOURCE_MANAGEMENT.MODIFIED_BY_PARAM(objParameterList , objResourceManagement.ModifiedBy);
			UDSP_INSERT_RESOURCE_MANAGEMENT.MODIFIED_ON_PARAM(objParameterList , objResourceManagement.ModifiedOn);
			UDSP_INSERT_RESOURCE_MANAGEMENT.RECORD_STATUS_PARAM(objParameterList , objResourceManagement.RecordStatus);
			try
			{
				Logger.LogInfo("ResourceManagementDAO.cs : InsertResourceManagement() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strInsertResourceManagement, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) > 0 )
					{
						objResourceManagement.ResourceId = Convert.ToInt32(dbExecuteStatus);
						objResourceManagement.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objResourceManagement.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("ResourceManagementDAO.cs : InsertResourceManagement() is ended with success.");
				}
				else
				{
					objResourceManagement.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("ResourceManagementDAO.cs : InsertResourceManagement() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objResourceManagement.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("ResourceManagementDAO.cs : InsertResourceManagement() is ended with error.");
			}
			return objResourceManagement;
		}

		public ResourceManagement UpdateResourceManagement(ResourceManagement objResourceManagement)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_UPDATE_RESOURCE_MANAGEMENT.RESOURCE_ID_PARAM(objParameterList , objResourceManagement.ResourceId);
			UDSP_UPDATE_RESOURCE_MANAGEMENT.RESOURCE_NAME_PARAM(objParameterList , objResourceManagement.ResourceName);
			UDSP_UPDATE_RESOURCE_MANAGEMENT.URL_PARAM(objParameterList , objResourceManagement.Url);
			if (objResourceManagement.ParentResourceObject != null)
			{
				UDSP_UPDATE_RESOURCE_MANAGEMENT.PARENT_RESOURCE_ID_PARAM(objParameterList , objResourceManagement.ParentResourceObject.ResourceId);
			}
			UDSP_UPDATE_RESOURCE_MANAGEMENT.VERSION_PARAM(objParameterList , objResourceManagement.Version);
			UDSP_UPDATE_RESOURCE_MANAGEMENT.CREATED_BY_PARAM(objParameterList , objResourceManagement.CreatedBy);
			UDSP_UPDATE_RESOURCE_MANAGEMENT.CREATED_ON_PARAM(objParameterList , objResourceManagement.CreatedOn);
			UDSP_UPDATE_RESOURCE_MANAGEMENT.MODIFIED_BY_PARAM(objParameterList , objResourceManagement.ModifiedBy);
			UDSP_UPDATE_RESOURCE_MANAGEMENT.MODIFIED_ON_PARAM(objParameterList , objResourceManagement.ModifiedOn);
			UDSP_UPDATE_RESOURCE_MANAGEMENT.RECORD_STATUS_PARAM(objParameterList , objResourceManagement.RecordStatus);
			try
			{
				Logger.LogInfo("ResourceManagementDAO.cs : UpdateResourceManagement() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strUpdateResourceManagement, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objResourceManagement.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
					{
						objResourceManagement.DbOperationStatus = CommonConstant.INVALID;
					}
					else
					{
						objResourceManagement.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("ResourceManagementDAO.cs : UpdateResourceManagement() is ended with success.");
				}
				else
				{
					objResourceManagement.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("ResourceManagementDAO.cs : UpdateResourceManagement() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objResourceManagement.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("ResourceManagementDAO.cs : UpdateResourceManagement() is ended with error.");
			}
			return objResourceManagement;
		}

		public ResourceManagement ActivateDeactivateResourceManagement(ResourceManagement objResourceManagement)
		{
			try
			{
				Logger.LogInfo("ResourceManagementDAO.cs : ActivateDeactivateResourceManagementDAO() is started.");
				dbExecuteStatus = DataUtility.ActivateDeactivateObject(strDBTableName, objResourceManagement.ResourceId,
										objResourceManagement.Version, objResourceManagement.RecordStatus, objResourceManagement.ModifiedBy);
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objResourceManagement.DbOperationStatus = CommonConstant.SUCCEED;
						Logger.LogInfo("ResourceManagementDAO.cs : ActivateDeactivateResourceManagement() is ended with success.");
					}
					else
					{
						objResourceManagement.DbOperationStatus = CommonConstant.INVALID;
						Logger.LogInfo("ResourceManagementDAO.cs : ActivateDeactivateResourceManagement() is ended with success.");
					}
				}
				else
				{
					objResourceManagement.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("ResourceManagementDAO.cs : ActivateDeactivateResourceManagement() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objResourceManagement.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("ResourceManagementDAO.cs : ActivateDeactivateResourceManagement() is ended with error.");
			}
			return objResourceManagement;
		}

		public ResourceManagement SelectRecordById(ResourceManagement objResourceManagement)
		{
			try
			{
				Logger.LogInfo("ResourceManagementDAO.cs : SelectRecordById() is started.");
				objResourceManagement.ObjectDataSet = DataUtility.SelectRecordById(strDBTableName, objResourceManagement.ResourceId, objResourceManagement.Version, strSelectResourceManagement);
				if (GeneralUtility.IsInteger(objResourceManagement.ObjectDataSet.Tables[0].Rows[0][0]) && (objResourceManagement.ObjectDataSet.Tables[1].Columns.Count > 1))
				{
					if (Convert.ToInt32(objResourceManagement.ObjectDataSet.Tables[0].Rows[0][0]) > 0)
					{
						objResourceManagement.IsRecordChanged = false;
						objResourceManagement.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objResourceManagement.IsRecordChanged = true;
						objResourceManagement.DbOperationStatus = CommonConstant.INVALID;
					}
					Logger.LogInfo("ResourceManagementDAO.cs : SelectRecordById() is ended with success.");
				}
				else
				{
					objResourceManagement.DbOperationStatus = CommonConstant.FAIL;
					dbExecuteStatus = objResourceManagement.ObjectDataSet.Tables[0].Rows[0][0].ToString() + " " + objResourceManagement.ObjectDataSet.Tables[1].Rows[0][0].ToString();
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("ResourceManagementDAO.cs : SelectRecordById() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objResourceManagement.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("ResourceManagementDAO.cs : SelectRecordById() is ended with error.");
			}
			return objResourceManagement;
		}
	}
}
