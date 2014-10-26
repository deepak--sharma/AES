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
	public class UserRoleMappingDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "USER_ROLE_MAPPING";
		private string strSelectUserRoleMapping = "UDSP_SELECT_USER_ROLE_MAPPING";
		private string strInsertUserRoleMapping = "UDSP_INSERT_USER_ROLE_MAPPING";
		private string strUpdateUserRoleMapping = "UDSP_UPDATE_USER_ROLE_MAPPING";
		private string dbExecuteStatus = "";

		public UserRoleMapping SelectUserRoleMapping(UserRoleMapping objUserRoleMapping)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_USER_ROLE_MAPPING.USER_ROLE_MAPPING_ID_PARAM(objParameterList , objUserRoleMapping.UserRoleMappingId);
			if (objUserRoleMapping.UserObject != null)
			{
				UDSP_SELECT_USER_ROLE_MAPPING.USER_ID_PARAM(objParameterList , objUserRoleMapping.UserObject.UserId);
			}
			if (objUserRoleMapping.RoleObject != null)
			{
				UDSP_SELECT_USER_ROLE_MAPPING.ROLE_ID_PARAM(objParameterList , objUserRoleMapping.RoleObject.RoleId);
			}
			UDSP_SELECT_USER_ROLE_MAPPING.RECORD_STATUS_PARAM(objParameterList , objUserRoleMapping.RecordStatus);
			try
			{
				Logger.LogInfo("UserRoleMappingDAO.cs : SelectUserRoleMapping() is started.");
				objUserRoleMapping.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectUserRoleMapping, CommandType.StoredProcedure);
				objUserRoleMapping.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("UserRoleMappingDAO.cs : SelectUserRoleMapping() is ended with success.");
			}
			catch (Exception ex)
			{
				objUserRoleMapping.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("UserRoleMappingDAO.cs : SelectUserRoleMapping() is ended with error.");
			}
			return objUserRoleMapping;
		}

		public UserRoleMapping InsertUserRoleMapping(UserRoleMapping objUserRoleMapping)
		{
			objParameterList = new List<SqlParameter>();
				
			if (objUserRoleMapping.UserObject != null)
			{
				UDSP_INSERT_USER_ROLE_MAPPING.USER_ID_PARAM(objParameterList , objUserRoleMapping.UserObject.UserId);
			}
			if (objUserRoleMapping.RoleObject != null)
			{
				UDSP_INSERT_USER_ROLE_MAPPING.ROLE_ID_PARAM(objParameterList , objUserRoleMapping.RoleObject.RoleId);
			}
			UDSP_INSERT_USER_ROLE_MAPPING.VERSION_PARAM(objParameterList , objUserRoleMapping.Version);
			UDSP_INSERT_USER_ROLE_MAPPING.CREATED_BY_PARAM(objParameterList , objUserRoleMapping.CreatedBy);
			UDSP_INSERT_USER_ROLE_MAPPING.CREATED_ON_PARAM(objParameterList , objUserRoleMapping.CreatedOn);
			UDSP_INSERT_USER_ROLE_MAPPING.MODIFIED_BY_PARAM(objParameterList , objUserRoleMapping.ModifiedBy);
			UDSP_INSERT_USER_ROLE_MAPPING.MODIFIED_ON_PARAM(objParameterList , objUserRoleMapping.ModifiedOn);
			UDSP_INSERT_USER_ROLE_MAPPING.RECORD_STATUS_PARAM(objParameterList , objUserRoleMapping.RecordStatus);
			try
			{
				Logger.LogInfo("UserRoleMappingDAO.cs : InsertUserRoleMapping() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strInsertUserRoleMapping, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) > 0 )
					{
						objUserRoleMapping.UserRoleMappingId = Convert.ToInt32(dbExecuteStatus);
						objUserRoleMapping.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objUserRoleMapping.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("UserRoleMappingDAO.cs : InsertUserRoleMapping() is ended with success.");
				}
				else
				{
					objUserRoleMapping.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("UserRoleMappingDAO.cs : InsertUserRoleMapping() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objUserRoleMapping.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("UserRoleMappingDAO.cs : InsertUserRoleMapping() is ended with error.");
			}
			return objUserRoleMapping;
		}

		public UserRoleMapping UpdateUserRoleMapping(UserRoleMapping objUserRoleMapping)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_UPDATE_USER_ROLE_MAPPING.USER_ROLE_MAPPING_ID_PARAM(objParameterList , objUserRoleMapping.UserRoleMappingId);
			if (objUserRoleMapping.UserObject != null)
			{
				UDSP_UPDATE_USER_ROLE_MAPPING.USER_ID_PARAM(objParameterList , objUserRoleMapping.UserObject.UserId);
			}
			if (objUserRoleMapping.RoleObject != null)
			{
				UDSP_UPDATE_USER_ROLE_MAPPING.ROLE_ID_PARAM(objParameterList , objUserRoleMapping.RoleObject.RoleId);
			}
			UDSP_UPDATE_USER_ROLE_MAPPING.VERSION_PARAM(objParameterList , objUserRoleMapping.Version);
			UDSP_UPDATE_USER_ROLE_MAPPING.CREATED_BY_PARAM(objParameterList , objUserRoleMapping.CreatedBy);
			UDSP_UPDATE_USER_ROLE_MAPPING.CREATED_ON_PARAM(objParameterList , objUserRoleMapping.CreatedOn);
			UDSP_UPDATE_USER_ROLE_MAPPING.MODIFIED_BY_PARAM(objParameterList , objUserRoleMapping.ModifiedBy);
			UDSP_UPDATE_USER_ROLE_MAPPING.MODIFIED_ON_PARAM(objParameterList , objUserRoleMapping.ModifiedOn);
			UDSP_UPDATE_USER_ROLE_MAPPING.RECORD_STATUS_PARAM(objParameterList , objUserRoleMapping.RecordStatus);
			try
			{
				Logger.LogInfo("UserRoleMappingDAO.cs : UpdateUserRoleMapping() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strUpdateUserRoleMapping, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objUserRoleMapping.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
					{
						objUserRoleMapping.DbOperationStatus = CommonConstant.INVALID;
					}
					else
					{
						objUserRoleMapping.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("UserRoleMappingDAO.cs : UpdateUserRoleMapping() is ended with success.");
				}
				else
				{
					objUserRoleMapping.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("UserRoleMappingDAO.cs : UpdateUserRoleMapping() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objUserRoleMapping.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("UserRoleMappingDAO.cs : UpdateUserRoleMapping() is ended with error.");
			}
			return objUserRoleMapping;
		}

		public UserRoleMapping ActivateDeactivateUserRoleMapping(UserRoleMapping objUserRoleMapping)
		{
			try
			{
				Logger.LogInfo("UserRoleMappingDAO.cs : ActivateDeactivateUserRoleMappingDAO() is started.");
				dbExecuteStatus = DataUtility.ActivateDeactivateObject(strDBTableName, objUserRoleMapping.UserRoleMappingId,
										objUserRoleMapping.Version, objUserRoleMapping.RecordStatus, objUserRoleMapping.ModifiedBy);
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objUserRoleMapping.DbOperationStatus = CommonConstant.SUCCEED;
						Logger.LogInfo("UserRoleMappingDAO.cs : ActivateDeactivateUserRoleMapping() is ended with success.");
					}
					else
					{
						objUserRoleMapping.DbOperationStatus = CommonConstant.INVALID;
						Logger.LogInfo("UserRoleMappingDAO.cs : ActivateDeactivateUserRoleMapping() is ended with success.");
					}
				}
				else
				{
					objUserRoleMapping.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("UserRoleMappingDAO.cs : ActivateDeactivateUserRoleMapping() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objUserRoleMapping.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("UserRoleMappingDAO.cs : ActivateDeactivateUserRoleMapping() is ended with error.");
			}
			return objUserRoleMapping;
		}

		public UserRoleMapping SelectRecordById(UserRoleMapping objUserRoleMapping)
		{
			try
			{
				Logger.LogInfo("UserRoleMappingDAO.cs : SelectRecordById() is started.");
				objUserRoleMapping.ObjectDataSet = DataUtility.SelectRecordById(strDBTableName, objUserRoleMapping.UserRoleMappingId, objUserRoleMapping.Version, strSelectUserRoleMapping);
				if (GeneralUtility.IsInteger(objUserRoleMapping.ObjectDataSet.Tables[0].Rows[0][0]) && (objUserRoleMapping.ObjectDataSet.Tables[1].Columns.Count > 1))
				{
					if (Convert.ToInt32(objUserRoleMapping.ObjectDataSet.Tables[0].Rows[0][0]) > 0)
					{
						objUserRoleMapping.IsRecordChanged = false;
						objUserRoleMapping.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objUserRoleMapping.IsRecordChanged = true;
						objUserRoleMapping.DbOperationStatus = CommonConstant.INVALID;
					}
					Logger.LogInfo("UserRoleMappingDAO.cs : SelectRecordById() is ended with success.");
				}
				else
				{
					objUserRoleMapping.DbOperationStatus = CommonConstant.FAIL;
					dbExecuteStatus = objUserRoleMapping.ObjectDataSet.Tables[0].Rows[0][0].ToString() + " " + objUserRoleMapping.ObjectDataSet.Tables[1].Rows[0][0].ToString();
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("UserRoleMappingDAO.cs : SelectRecordById() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objUserRoleMapping.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("UserRoleMappingDAO.cs : SelectRecordById() is ended with error.");
			}
			return objUserRoleMapping;
		}
	}
}
