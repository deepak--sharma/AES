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
	public class RoleManagementDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "ROLE_MANAGEMENT";
		private string strSelectRoleManagement = "UDSP_SELECT_ROLE_MANAGEMENT";
		private string strInsertRoleManagement = "UDSP_INSERT_ROLE_MANAGEMENT";
		private string strUpdateRoleManagement = "UDSP_UPDATE_ROLE_MANAGEMENT";
		private string dbExecuteStatus = "";

		public RoleManagement SelectRoleManagement(RoleManagement objRoleManagement)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_ROLE_MANAGEMENT.ROLE_ID_PARAM(objParameterList , objRoleManagement.RoleId);
			UDSP_SELECT_ROLE_MANAGEMENT.ROLE_NAME_PARAM(objParameterList , objRoleManagement.RoleName);
			UDSP_SELECT_ROLE_MANAGEMENT.DESCRIPTION_PARAM(objParameterList , objRoleManagement.Description);
			UDSP_SELECT_ROLE_MANAGEMENT.RECORD_STATUS_PARAM(objParameterList , objRoleManagement.RecordStatus);
			try
			{
				Logger.LogInfo("RoleManagementDAO.cs : SelectRoleManagement() is started.");
				objRoleManagement.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectRoleManagement, CommandType.StoredProcedure);
				objRoleManagement.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("RoleManagementDAO.cs : SelectRoleManagement() is ended with success.");
			}
			catch (Exception ex)
			{
				objRoleManagement.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("RoleManagementDAO.cs : SelectRoleManagement() is ended with error.");
			}
			return objRoleManagement;
		}

		public RoleManagement InsertRoleManagement(RoleManagement objRoleManagement)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_INSERT_ROLE_MANAGEMENT.ROLE_NAME_PARAM(objParameterList , objRoleManagement.RoleName);
			UDSP_INSERT_ROLE_MANAGEMENT.DESCRIPTION_PARAM(objParameterList , objRoleManagement.Description);
			UDSP_INSERT_ROLE_MANAGEMENT.VERSION_PARAM(objParameterList , objRoleManagement.Version);
			UDSP_INSERT_ROLE_MANAGEMENT.CREATED_BY_PARAM(objParameterList , objRoleManagement.CreatedBy);
			UDSP_INSERT_ROLE_MANAGEMENT.CREATED_ON_PARAM(objParameterList , objRoleManagement.CreatedOn);
			UDSP_INSERT_ROLE_MANAGEMENT.MODIFIED_BY_PARAM(objParameterList , objRoleManagement.ModifiedBy);
			UDSP_INSERT_ROLE_MANAGEMENT.MODIFIED_ON_PARAM(objParameterList , objRoleManagement.ModifiedOn);
			UDSP_INSERT_ROLE_MANAGEMENT.RECORD_STATUS_PARAM(objParameterList , objRoleManagement.RecordStatus);
			try
			{
				Logger.LogInfo("RoleManagementDAO.cs : InsertRoleManagement() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strInsertRoleManagement, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) > 0 )
					{
						objRoleManagement.RoleId = Convert.ToInt32(dbExecuteStatus);
						objRoleManagement.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objRoleManagement.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("RoleManagementDAO.cs : InsertRoleManagement() is ended with success.");
				}
				else
				{
					objRoleManagement.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("RoleManagementDAO.cs : InsertRoleManagement() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objRoleManagement.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("RoleManagementDAO.cs : InsertRoleManagement() is ended with error.");
			}
			return objRoleManagement;
		}

		public RoleManagement UpdateRoleManagement(RoleManagement objRoleManagement)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_UPDATE_ROLE_MANAGEMENT.ROLE_ID_PARAM(objParameterList , objRoleManagement.RoleId);
			UDSP_UPDATE_ROLE_MANAGEMENT.ROLE_NAME_PARAM(objParameterList , objRoleManagement.RoleName);
			UDSP_UPDATE_ROLE_MANAGEMENT.DESCRIPTION_PARAM(objParameterList , objRoleManagement.Description);
			UDSP_UPDATE_ROLE_MANAGEMENT.VERSION_PARAM(objParameterList , objRoleManagement.Version);
			UDSP_UPDATE_ROLE_MANAGEMENT.CREATED_BY_PARAM(objParameterList , objRoleManagement.CreatedBy);
			UDSP_UPDATE_ROLE_MANAGEMENT.CREATED_ON_PARAM(objParameterList , objRoleManagement.CreatedOn);
			UDSP_UPDATE_ROLE_MANAGEMENT.MODIFIED_BY_PARAM(objParameterList , objRoleManagement.ModifiedBy);
			UDSP_UPDATE_ROLE_MANAGEMENT.MODIFIED_ON_PARAM(objParameterList , objRoleManagement.ModifiedOn);
			UDSP_UPDATE_ROLE_MANAGEMENT.RECORD_STATUS_PARAM(objParameterList , objRoleManagement.RecordStatus);
			try
			{
				Logger.LogInfo("RoleManagementDAO.cs : UpdateRoleManagement() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strUpdateRoleManagement, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objRoleManagement.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
					{
						objRoleManagement.DbOperationStatus = CommonConstant.INVALID;
					}
					else
					{
						objRoleManagement.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("RoleManagementDAO.cs : UpdateRoleManagement() is ended with success.");
				}
				else
				{
					objRoleManagement.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("RoleManagementDAO.cs : UpdateRoleManagement() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objRoleManagement.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("RoleManagementDAO.cs : UpdateRoleManagement() is ended with error.");
			}
			return objRoleManagement;
		}

		public RoleManagement ActivateDeactivateRoleManagement(RoleManagement objRoleManagement)
		{
			try
			{
				Logger.LogInfo("RoleManagementDAO.cs : ActivateDeactivateRoleManagementDAO() is started.");
				dbExecuteStatus = DataUtility.ActivateDeactivateObject(strDBTableName, objRoleManagement.RoleId,
										objRoleManagement.Version, objRoleManagement.RecordStatus, objRoleManagement.ModifiedBy);
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objRoleManagement.DbOperationStatus = CommonConstant.SUCCEED;
						Logger.LogInfo("RoleManagementDAO.cs : ActivateDeactivateRoleManagement() is ended with success.");
					}
					else
					{
						objRoleManagement.DbOperationStatus = CommonConstant.INVALID;
						Logger.LogInfo("RoleManagementDAO.cs : ActivateDeactivateRoleManagement() is ended with success.");
					}
				}
				else
				{
					objRoleManagement.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("RoleManagementDAO.cs : ActivateDeactivateRoleManagement() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objRoleManagement.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("RoleManagementDAO.cs : ActivateDeactivateRoleManagement() is ended with error.");
			}
			return objRoleManagement;
		}

		public RoleManagement SelectRecordById(RoleManagement objRoleManagement)
		{
			try
			{
				Logger.LogInfo("RoleManagementDAO.cs : SelectRecordById() is started.");
				objRoleManagement.ObjectDataSet = DataUtility.SelectRecordById(strDBTableName, objRoleManagement.RoleId, objRoleManagement.Version, strSelectRoleManagement);
				if (GeneralUtility.IsInteger(objRoleManagement.ObjectDataSet.Tables[0].Rows[0][0]) && (objRoleManagement.ObjectDataSet.Tables[1].Columns.Count > 1))
				{
					if (Convert.ToInt32(objRoleManagement.ObjectDataSet.Tables[0].Rows[0][0]) > 0)
					{
						objRoleManagement.IsRecordChanged = false;
						objRoleManagement.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objRoleManagement.IsRecordChanged = true;
						objRoleManagement.DbOperationStatus = CommonConstant.INVALID;
					}
					Logger.LogInfo("RoleManagementDAO.cs : SelectRecordById() is ended with success.");
				}
				else
				{
					objRoleManagement.DbOperationStatus = CommonConstant.FAIL;
					dbExecuteStatus = objRoleManagement.ObjectDataSet.Tables[0].Rows[0][0].ToString() + " " + objRoleManagement.ObjectDataSet.Tables[1].Rows[0][0].ToString();
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("RoleManagementDAO.cs : SelectRecordById() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objRoleManagement.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("RoleManagementDAO.cs : SelectRecordById() is ended with error.");
			}
			return objRoleManagement;
		}
	}
}
