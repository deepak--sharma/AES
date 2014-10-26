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
	public class JoiningMasterDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "JOINING_MASTER";
		private string strSelectJoiningMaster = "UDSP_SELECT_JOINING_MASTER";
		private string strInsertJoiningMaster = "UDSP_INSERT_JOINING_MASTER";
		private string strUpdateJoiningMaster = "UDSP_UPDATE_JOINING_MASTER";
		private string dbExecuteStatus = "";

		public JoiningMaster SelectJoiningMaster(JoiningMaster objJoiningMaster)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_JOINING_MASTER.JOINING_ID_PARAM(objParameterList , objJoiningMaster.JoiningId);
			UDSP_SELECT_JOINING_MASTER.JOINING_NAME_PARAM(objParameterList , objJoiningMaster.JoiningName);
			UDSP_SELECT_JOINING_MASTER.DESCRIPTION_PARAM(objParameterList , objJoiningMaster.Description);
			UDSP_SELECT_JOINING_MASTER.RECORD_STATUS_PARAM(objParameterList , objJoiningMaster.RecordStatus);
			try
			{
				Logger.LogInfo("JoiningMasterDAO.cs : SelectJoiningMaster() is started.");
				objJoiningMaster.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectJoiningMaster, CommandType.StoredProcedure);
				objJoiningMaster.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("JoiningMasterDAO.cs : SelectJoiningMaster() is ended with success.");
			}
			catch (Exception ex)
			{
				objJoiningMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("JoiningMasterDAO.cs : SelectJoiningMaster() is ended with error.");
			}
			return objJoiningMaster;
		}

		public JoiningMaster InsertJoiningMaster(JoiningMaster objJoiningMaster)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_INSERT_JOINING_MASTER.JOINING_NAME_PARAM(objParameterList , objJoiningMaster.JoiningName);
			UDSP_INSERT_JOINING_MASTER.DESCRIPTION_PARAM(objParameterList , objJoiningMaster.Description);
			UDSP_INSERT_JOINING_MASTER.VERSION_PARAM(objParameterList , objJoiningMaster.Version);
			UDSP_INSERT_JOINING_MASTER.CREATED_BY_PARAM(objParameterList , objJoiningMaster.CreatedBy);
			UDSP_INSERT_JOINING_MASTER.CREATED_ON_PARAM(objParameterList , objJoiningMaster.CreatedOn);
			UDSP_INSERT_JOINING_MASTER.MODIFIED_BY_PARAM(objParameterList , objJoiningMaster.ModifiedBy);
			UDSP_INSERT_JOINING_MASTER.MODIFIED_ON_PARAM(objParameterList , objJoiningMaster.ModifiedOn);
			UDSP_INSERT_JOINING_MASTER.RECORD_STATUS_PARAM(objParameterList , objJoiningMaster.RecordStatus);
			try
			{
				Logger.LogInfo("JoiningMasterDAO.cs : InsertJoiningMaster() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strInsertJoiningMaster, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) > 0 )
					{
						objJoiningMaster.JoiningId = Convert.ToInt32(dbExecuteStatus);
						objJoiningMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objJoiningMaster.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("JoiningMasterDAO.cs : InsertJoiningMaster() is ended with success.");
				}
				else
				{
					objJoiningMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("JoiningMasterDAO.cs : InsertJoiningMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objJoiningMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("JoiningMasterDAO.cs : InsertJoiningMaster() is ended with error.");
			}
			return objJoiningMaster;
		}

		public JoiningMaster UpdateJoiningMaster(JoiningMaster objJoiningMaster)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_UPDATE_JOINING_MASTER.JOINING_ID_PARAM(objParameterList , objJoiningMaster.JoiningId);
			UDSP_UPDATE_JOINING_MASTER.JOINING_NAME_PARAM(objParameterList , objJoiningMaster.JoiningName);
			UDSP_UPDATE_JOINING_MASTER.DESCRIPTION_PARAM(objParameterList , objJoiningMaster.Description);
			UDSP_UPDATE_JOINING_MASTER.VERSION_PARAM(objParameterList , objJoiningMaster.Version);
			UDSP_UPDATE_JOINING_MASTER.CREATED_BY_PARAM(objParameterList , objJoiningMaster.CreatedBy);
			UDSP_UPDATE_JOINING_MASTER.CREATED_ON_PARAM(objParameterList , objJoiningMaster.CreatedOn);
			UDSP_UPDATE_JOINING_MASTER.MODIFIED_BY_PARAM(objParameterList , objJoiningMaster.ModifiedBy);
			UDSP_UPDATE_JOINING_MASTER.MODIFIED_ON_PARAM(objParameterList , objJoiningMaster.ModifiedOn);
			UDSP_UPDATE_JOINING_MASTER.RECORD_STATUS_PARAM(objParameterList , objJoiningMaster.RecordStatus);
			try
			{
				Logger.LogInfo("JoiningMasterDAO.cs : UpdateJoiningMaster() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strUpdateJoiningMaster, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objJoiningMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
					{
						objJoiningMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					else
					{
						objJoiningMaster.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("JoiningMasterDAO.cs : UpdateJoiningMaster() is ended with success.");
				}
				else
				{
					objJoiningMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("JoiningMasterDAO.cs : UpdateJoiningMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objJoiningMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("JoiningMasterDAO.cs : UpdateJoiningMaster() is ended with error.");
			}
			return objJoiningMaster;
		}

		public JoiningMaster ActivateDeactivateJoiningMaster(JoiningMaster objJoiningMaster)
		{
			try
			{
				Logger.LogInfo("JoiningMasterDAO.cs : ActivateDeactivateJoiningMasterDAO() is started.");
				dbExecuteStatus = DataUtility.ActivateDeactivateObject(strDBTableName, objJoiningMaster.JoiningId,
										objJoiningMaster.Version, objJoiningMaster.RecordStatus, objJoiningMaster.ModifiedBy);
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objJoiningMaster.DbOperationStatus = CommonConstant.SUCCEED;
						Logger.LogInfo("JoiningMasterDAO.cs : ActivateDeactivateJoiningMaster() is ended with success.");
					}
					else
					{
						objJoiningMaster.DbOperationStatus = CommonConstant.INVALID;
						Logger.LogInfo("JoiningMasterDAO.cs : ActivateDeactivateJoiningMaster() is ended with success.");
					}
				}
				else
				{
					objJoiningMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("JoiningMasterDAO.cs : ActivateDeactivateJoiningMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objJoiningMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("JoiningMasterDAO.cs : ActivateDeactivateJoiningMaster() is ended with error.");
			}
			return objJoiningMaster;
		}

		public JoiningMaster SelectRecordById(JoiningMaster objJoiningMaster)
		{
			try
			{
				Logger.LogInfo("JoiningMasterDAO.cs : SelectRecordById() is started.");
				objJoiningMaster.ObjectDataSet = DataUtility.SelectRecordById(strDBTableName, objJoiningMaster.JoiningId, objJoiningMaster.Version, strSelectJoiningMaster);
				if (GeneralUtility.IsInteger(objJoiningMaster.ObjectDataSet.Tables[0].Rows[0][0]) && (objJoiningMaster.ObjectDataSet.Tables[1].Columns.Count > 1))
				{
					if (Convert.ToInt32(objJoiningMaster.ObjectDataSet.Tables[0].Rows[0][0]) > 0)
					{
						objJoiningMaster.IsRecordChanged = false;
						objJoiningMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objJoiningMaster.IsRecordChanged = true;
						objJoiningMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					Logger.LogInfo("JoiningMasterDAO.cs : SelectRecordById() is ended with success.");
				}
				else
				{
					objJoiningMaster.DbOperationStatus = CommonConstant.FAIL;
					dbExecuteStatus = objJoiningMaster.ObjectDataSet.Tables[0].Rows[0][0].ToString() + " " + objJoiningMaster.ObjectDataSet.Tables[1].Rows[0][0].ToString();
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("JoiningMasterDAO.cs : SelectRecordById() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objJoiningMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("JoiningMasterDAO.cs : SelectRecordById() is ended with error.");
			}
			return objJoiningMaster;
		}
	}
}
