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
	public class GroupMasterDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "GROUP_MASTER";
		private string strSelectGroupMaster = "UDSP_SELECT_GROUP_MASTER";
		private string strInsertGroupMaster = "UDSP_INSERT_GROUP_MASTER";
		private string strUpdateGroupMaster = "UDSP_UPDATE_GROUP_MASTER";
		private string dbExecuteStatus = "";

		public GroupMaster SelectGroupMaster(GroupMaster objGroupMaster)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_GROUP_MASTER.GROUP_ID_PARAM(objParameterList , objGroupMaster.GroupId);
			UDSP_SELECT_GROUP_MASTER.GROUP_NAME_PARAM(objParameterList , objGroupMaster.GroupName);
			if (objGroupMaster.ParentGroupObject != null)
			{
				UDSP_SELECT_GROUP_MASTER.PARENT_GROUP_ID_PARAM(objParameterList , objGroupMaster.ParentGroupObject.GroupId);
			}
			UDSP_SELECT_GROUP_MASTER.DESCRIPTION_PARAM(objParameterList , objGroupMaster.Description);
			UDSP_SELECT_GROUP_MASTER.RECORD_STATUS_PARAM(objParameterList , objGroupMaster.RecordStatus);
			try
			{
				Logger.LogInfo("GroupMasterDAO.cs : SelectGroupMaster() is started.");
				objGroupMaster.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectGroupMaster, CommandType.StoredProcedure);
				objGroupMaster.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("GroupMasterDAO.cs : SelectGroupMaster() is ended with success.");
			}
			catch (Exception ex)
			{
				objGroupMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("GroupMasterDAO.cs : SelectGroupMaster() is ended with error.");
			}
			return objGroupMaster;
		}

		public GroupMaster InsertGroupMaster(GroupMaster objGroupMaster)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_INSERT_GROUP_MASTER.GROUP_NAME_PARAM(objParameterList , objGroupMaster.GroupName);
			if (objGroupMaster.ParentGroupObject != null)
			{
				UDSP_INSERT_GROUP_MASTER.PARENT_GROUP_ID_PARAM(objParameterList , objGroupMaster.ParentGroupObject.GroupId);
			}
			UDSP_INSERT_GROUP_MASTER.DESCRIPTION_PARAM(objParameterList , objGroupMaster.Description);
			UDSP_INSERT_GROUP_MASTER.VERSION_PARAM(objParameterList , objGroupMaster.Version);
			UDSP_INSERT_GROUP_MASTER.CREATED_BY_PARAM(objParameterList , objGroupMaster.CreatedBy);
			UDSP_INSERT_GROUP_MASTER.CREATED_ON_PARAM(objParameterList , objGroupMaster.CreatedOn);
			UDSP_INSERT_GROUP_MASTER.MODIFIED_BY_PARAM(objParameterList , objGroupMaster.ModifiedBy);
			UDSP_INSERT_GROUP_MASTER.MODIFIED_ON_PARAM(objParameterList , objGroupMaster.ModifiedOn);
			UDSP_INSERT_GROUP_MASTER.RECORD_STATUS_PARAM(objParameterList , objGroupMaster.RecordStatus);
			try
			{
				Logger.LogInfo("GroupMasterDAO.cs : InsertGroupMaster() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strInsertGroupMaster, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) > 0 )
					{
						objGroupMaster.GroupId = Convert.ToInt32(dbExecuteStatus);
						objGroupMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objGroupMaster.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("GroupMasterDAO.cs : InsertGroupMaster() is ended with success.");
				}
				else
				{
					objGroupMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("GroupMasterDAO.cs : InsertGroupMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objGroupMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("GroupMasterDAO.cs : InsertGroupMaster() is ended with error.");
			}
			return objGroupMaster;
		}

		public GroupMaster UpdateGroupMaster(GroupMaster objGroupMaster)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_UPDATE_GROUP_MASTER.GROUP_ID_PARAM(objParameterList , objGroupMaster.GroupId);
			UDSP_UPDATE_GROUP_MASTER.GROUP_NAME_PARAM(objParameterList , objGroupMaster.GroupName);
			if (objGroupMaster.ParentGroupObject != null)
			{
				UDSP_UPDATE_GROUP_MASTER.PARENT_GROUP_ID_PARAM(objParameterList , objGroupMaster.ParentGroupObject.GroupId);
			}
			UDSP_UPDATE_GROUP_MASTER.DESCRIPTION_PARAM(objParameterList , objGroupMaster.Description);
			UDSP_UPDATE_GROUP_MASTER.VERSION_PARAM(objParameterList , objGroupMaster.Version);
			UDSP_UPDATE_GROUP_MASTER.CREATED_BY_PARAM(objParameterList , objGroupMaster.CreatedBy);
			UDSP_UPDATE_GROUP_MASTER.CREATED_ON_PARAM(objParameterList , objGroupMaster.CreatedOn);
			UDSP_UPDATE_GROUP_MASTER.MODIFIED_BY_PARAM(objParameterList , objGroupMaster.ModifiedBy);
			UDSP_UPDATE_GROUP_MASTER.MODIFIED_ON_PARAM(objParameterList , objGroupMaster.ModifiedOn);
			UDSP_UPDATE_GROUP_MASTER.RECORD_STATUS_PARAM(objParameterList , objGroupMaster.RecordStatus);
			try
			{
				Logger.LogInfo("GroupMasterDAO.cs : UpdateGroupMaster() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strUpdateGroupMaster, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objGroupMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
					{
						objGroupMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					else
					{
						objGroupMaster.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("GroupMasterDAO.cs : UpdateGroupMaster() is ended with success.");
				}
				else
				{
					objGroupMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("GroupMasterDAO.cs : UpdateGroupMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objGroupMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("GroupMasterDAO.cs : UpdateGroupMaster() is ended with error.");
			}
			return objGroupMaster;
		}

		public GroupMaster ActivateDeactivateGroupMaster(GroupMaster objGroupMaster)
		{
			try
			{
				Logger.LogInfo("GroupMasterDAO.cs : ActivateDeactivateGroupMasterDAO() is started.");
				dbExecuteStatus = DataUtility.ActivateDeactivateObject(strDBTableName, objGroupMaster.GroupId,
										objGroupMaster.Version, objGroupMaster.RecordStatus, objGroupMaster.ModifiedBy);
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objGroupMaster.DbOperationStatus = CommonConstant.SUCCEED;
						Logger.LogInfo("GroupMasterDAO.cs : ActivateDeactivateGroupMaster() is ended with success.");
					}
					else
					{
						objGroupMaster.DbOperationStatus = CommonConstant.INVALID;
						Logger.LogInfo("GroupMasterDAO.cs : ActivateDeactivateGroupMaster() is ended with success.");
					}
				}
				else
				{
					objGroupMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("GroupMasterDAO.cs : ActivateDeactivateGroupMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objGroupMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("GroupMasterDAO.cs : ActivateDeactivateGroupMaster() is ended with error.");
			}
			return objGroupMaster;
		}

		public GroupMaster SelectRecordById(GroupMaster objGroupMaster)
		{
			try
			{
				Logger.LogInfo("GroupMasterDAO.cs : SelectRecordById() is started.");
				objGroupMaster.ObjectDataSet = DataUtility.SelectRecordById(strDBTableName, objGroupMaster.GroupId, objGroupMaster.Version, strSelectGroupMaster);
				if (GeneralUtility.IsInteger(objGroupMaster.ObjectDataSet.Tables[0].Rows[0][0]) && (objGroupMaster.ObjectDataSet.Tables[1].Columns.Count > 1))
				{
					if (Convert.ToInt32(objGroupMaster.ObjectDataSet.Tables[0].Rows[0][0]) > 0)
					{
						objGroupMaster.IsRecordChanged = false;
						objGroupMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objGroupMaster.IsRecordChanged = true;
						objGroupMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					Logger.LogInfo("GroupMasterDAO.cs : SelectRecordById() is ended with success.");
				}
				else
				{
					objGroupMaster.DbOperationStatus = CommonConstant.FAIL;
					dbExecuteStatus = objGroupMaster.ObjectDataSet.Tables[0].Rows[0][0].ToString() + " " + objGroupMaster.ObjectDataSet.Tables[1].Rows[0][0].ToString();
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("GroupMasterDAO.cs : SelectRecordById() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objGroupMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("GroupMasterDAO.cs : SelectRecordById() is ended with error.");
			}
			return objGroupMaster;
		}
	}
}
