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
	public class UserManagementDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "USER_MANAGEMENT";
		private string strSelectUserManagement = "UDSP_SELECT_USER_MANAGEMENT";
		private string strInsertUserManagement = "UDSP_INSERT_USER_MANAGEMENT";
		private string strUpdateUserManagement = "UDSP_UPDATE_USER_MANAGEMENT";
		private string dbExecuteStatus = "";

		public UserManagement SelectUserManagement(UserManagement objUserManagement)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_USER_MANAGEMENT.USER_ID_PARAM(objParameterList , objUserManagement.UserId);
			UDSP_SELECT_USER_MANAGEMENT.USER_NAME_PARAM(objParameterList , objUserManagement.UserName);
			UDSP_SELECT_USER_MANAGEMENT.PASSWORD_PARAM(objParameterList , objUserManagement.Password);
			if (objUserManagement.UserType != null)
			{
				UDSP_SELECT_USER_MANAGEMENT.USER_TYPE_PARAM(objParameterList , objUserManagement.UserType.MetadataId);
			}
			UDSP_SELECT_USER_MANAGEMENT.LAST_LOGIN_PARAM(objParameterList , objUserManagement.LastLogin);
			UDSP_SELECT_USER_MANAGEMENT.STATUS_PARAM(objParameterList , objUserManagement.Status);
			UDSP_SELECT_USER_MANAGEMENT.RECORD_STATUS_PARAM(objParameterList , objUserManagement.RecordStatus);
			try
			{
				Logger.LogInfo("UserManagementDAO.cs : SelectUserManagement() is started.");
				objUserManagement.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectUserManagement, CommandType.StoredProcedure);
				objUserManagement.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("UserManagementDAO.cs : SelectUserManagement() is ended with success.");
			}
			catch (Exception ex)
			{
				objUserManagement.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("UserManagementDAO.cs : SelectUserManagement() is ended with error.");
			}
			return objUserManagement;
		}

		public UserManagement InsertUserManagement(UserManagement objUserManagement)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_INSERT_USER_MANAGEMENT.USER_NAME_PARAM(objParameterList , objUserManagement.UserName);
			UDSP_INSERT_USER_MANAGEMENT.PASSWORD_PARAM(objParameterList , objUserManagement.Password);
			if (objUserManagement.UserType != null)
			{
				UDSP_INSERT_USER_MANAGEMENT.USER_TYPE_PARAM(objParameterList , objUserManagement.UserType.MetadataId);
			}
			UDSP_INSERT_USER_MANAGEMENT.LAST_LOGIN_PARAM(objParameterList , objUserManagement.LastLogin);
			UDSP_INSERT_USER_MANAGEMENT.STATUS_PARAM(objParameterList , objUserManagement.Status);
			UDSP_INSERT_USER_MANAGEMENT.VERSION_PARAM(objParameterList , objUserManagement.Version);
			UDSP_INSERT_USER_MANAGEMENT.CREATED_BY_PARAM(objParameterList , objUserManagement.CreatedBy);
			UDSP_INSERT_USER_MANAGEMENT.CREATED_ON_PARAM(objParameterList , objUserManagement.CreatedOn);
			UDSP_INSERT_USER_MANAGEMENT.MODIFIED_BY_PARAM(objParameterList , objUserManagement.ModifiedBy);
			UDSP_INSERT_USER_MANAGEMENT.MODIFIED_ON_PARAM(objParameterList , objUserManagement.ModifiedOn);
			UDSP_INSERT_USER_MANAGEMENT.RECORD_STATUS_PARAM(objParameterList , objUserManagement.RecordStatus);
			try
			{
				Logger.LogInfo("UserManagementDAO.cs : InsertUserManagement() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strInsertUserManagement, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) > 0 )
					{
						objUserManagement.UserId = Convert.ToInt32(dbExecuteStatus);
						objUserManagement.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objUserManagement.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("UserManagementDAO.cs : InsertUserManagement() is ended with success.");
				}
				else
				{
					objUserManagement.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("UserManagementDAO.cs : InsertUserManagement() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objUserManagement.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("UserManagementDAO.cs : InsertUserManagement() is ended with error.");
			}
			return objUserManagement;
		}

		public UserManagement UpdateUserManagement(UserManagement objUserManagement)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_UPDATE_USER_MANAGEMENT.USER_ID_PARAM(objParameterList , objUserManagement.UserId);
			UDSP_UPDATE_USER_MANAGEMENT.USER_NAME_PARAM(objParameterList , objUserManagement.UserName);
			UDSP_UPDATE_USER_MANAGEMENT.PASSWORD_PARAM(objParameterList , objUserManagement.Password);
			if (objUserManagement.UserType != null)
			{
				UDSP_UPDATE_USER_MANAGEMENT.USER_TYPE_PARAM(objParameterList , objUserManagement.UserType.MetadataId);
			}
			UDSP_UPDATE_USER_MANAGEMENT.LAST_LOGIN_PARAM(objParameterList , objUserManagement.LastLogin);
			UDSP_UPDATE_USER_MANAGEMENT.STATUS_PARAM(objParameterList , objUserManagement.Status);
			UDSP_UPDATE_USER_MANAGEMENT.VERSION_PARAM(objParameterList , objUserManagement.Version);
			UDSP_UPDATE_USER_MANAGEMENT.CREATED_BY_PARAM(objParameterList , objUserManagement.CreatedBy);
			UDSP_UPDATE_USER_MANAGEMENT.CREATED_ON_PARAM(objParameterList , objUserManagement.CreatedOn);
			UDSP_UPDATE_USER_MANAGEMENT.MODIFIED_BY_PARAM(objParameterList , objUserManagement.ModifiedBy);
			UDSP_UPDATE_USER_MANAGEMENT.MODIFIED_ON_PARAM(objParameterList , objUserManagement.ModifiedOn);
			UDSP_UPDATE_USER_MANAGEMENT.RECORD_STATUS_PARAM(objParameterList , objUserManagement.RecordStatus);
			try
			{
				Logger.LogInfo("UserManagementDAO.cs : UpdateUserManagement() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strUpdateUserManagement, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objUserManagement.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
					{
						objUserManagement.DbOperationStatus = CommonConstant.INVALID;
					}
					else
					{
						objUserManagement.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("UserManagementDAO.cs : UpdateUserManagement() is ended with success.");
				}
				else
				{
					objUserManagement.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("UserManagementDAO.cs : UpdateUserManagement() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objUserManagement.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("UserManagementDAO.cs : UpdateUserManagement() is ended with error.");
			}
			return objUserManagement;
		}

		public UserManagement ActivateDeactivateUserManagement(UserManagement objUserManagement)
		{
			try
			{
				Logger.LogInfo("UserManagementDAO.cs : ActivateDeactivateUserManagementDAO() is started.");
				dbExecuteStatus = DataUtility.ActivateDeactivateObject(strDBTableName, objUserManagement.UserId,
										objUserManagement.Version, objUserManagement.RecordStatus, objUserManagement.ModifiedBy);
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objUserManagement.DbOperationStatus = CommonConstant.SUCCEED;
						Logger.LogInfo("UserManagementDAO.cs : ActivateDeactivateUserManagement() is ended with success.");
					}
					else
					{
						objUserManagement.DbOperationStatus = CommonConstant.INVALID;
						Logger.LogInfo("UserManagementDAO.cs : ActivateDeactivateUserManagement() is ended with success.");
					}
				}
				else
				{
					objUserManagement.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("UserManagementDAO.cs : ActivateDeactivateUserManagement() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objUserManagement.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("UserManagementDAO.cs : ActivateDeactivateUserManagement() is ended with error.");
			}
			return objUserManagement;
		}

		public UserManagement SelectRecordById(UserManagement objUserManagement)
		{
			try
			{
				Logger.LogInfo("UserManagementDAO.cs : SelectRecordById() is started.");
				objUserManagement.ObjectDataSet = DataUtility.SelectRecordById(strDBTableName, objUserManagement.UserId, objUserManagement.Version, strSelectUserManagement);
				if (GeneralUtility.IsInteger(objUserManagement.ObjectDataSet.Tables[0].Rows[0][0]) && (objUserManagement.ObjectDataSet.Tables[1].Columns.Count > 1))
				{
					if (Convert.ToInt32(objUserManagement.ObjectDataSet.Tables[0].Rows[0][0]) > 0)
					{
						objUserManagement.IsRecordChanged = false;
						objUserManagement.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objUserManagement.IsRecordChanged = true;
						objUserManagement.DbOperationStatus = CommonConstant.INVALID;
					}
					Logger.LogInfo("UserManagementDAO.cs : SelectRecordById() is ended with success.");
				}
				else
				{
					objUserManagement.DbOperationStatus = CommonConstant.FAIL;
					dbExecuteStatus = objUserManagement.ObjectDataSet.Tables[0].Rows[0][0].ToString() + " " + objUserManagement.ObjectDataSet.Tables[1].Rows[0][0].ToString();
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("UserManagementDAO.cs : SelectRecordById() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objUserManagement.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("UserManagementDAO.cs : SelectRecordById() is ended with error.");
			}
			return objUserManagement;
		}
	}
}
