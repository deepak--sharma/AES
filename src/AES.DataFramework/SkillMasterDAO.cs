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
	public class SkillMasterDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "SKILL_MASTER";
		private string strSelectSkillMaster = "UDSP_SELECT_SKILL_MASTER";
		private string strInsertSkillMaster = "UDSP_INSERT_SKILL_MASTER";
		private string strUpdateSkillMaster = "UDSP_UPDATE_SKILL_MASTER";
		private string dbExecuteStatus = "";

		public SkillMaster SelectSkillMaster(SkillMaster objSkillMaster)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_SKILL_MASTER.SKILL_ID_PARAM(objParameterList , objSkillMaster.SkillId);
			UDSP_SELECT_SKILL_MASTER.SKILL_NAME_PARAM(objParameterList , objSkillMaster.SkillName);
			UDSP_SELECT_SKILL_MASTER.DESCRIPTION_PARAM(objParameterList , objSkillMaster.Description);
			UDSP_SELECT_SKILL_MASTER.RECORD_STATUS_PARAM(objParameterList , objSkillMaster.RecordStatus);
			try
			{
				Logger.LogInfo("SkillMasterDAO.cs : SelectSkillMaster() is started.");
				objSkillMaster.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectSkillMaster, CommandType.StoredProcedure);
				objSkillMaster.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("SkillMasterDAO.cs : SelectSkillMaster() is ended with success.");
			}
			catch (Exception ex)
			{
				objSkillMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("SkillMasterDAO.cs : SelectSkillMaster() is ended with error.");
			}
			return objSkillMaster;
		}

		public SkillMaster InsertSkillMaster(SkillMaster objSkillMaster)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_INSERT_SKILL_MASTER.SKILL_NAME_PARAM(objParameterList , objSkillMaster.SkillName);
			UDSP_INSERT_SKILL_MASTER.DESCRIPTION_PARAM(objParameterList , objSkillMaster.Description);
			UDSP_INSERT_SKILL_MASTER.VERSION_PARAM(objParameterList , objSkillMaster.Version);
			UDSP_INSERT_SKILL_MASTER.CREATED_BY_PARAM(objParameterList , objSkillMaster.CreatedBy);
			UDSP_INSERT_SKILL_MASTER.CREATED_ON_PARAM(objParameterList , objSkillMaster.CreatedOn);
			UDSP_INSERT_SKILL_MASTER.MODIFIED_BY_PARAM(objParameterList , objSkillMaster.ModifiedBy);
			UDSP_INSERT_SKILL_MASTER.MODIFIED_ON_PARAM(objParameterList , objSkillMaster.ModifiedOn);
			UDSP_INSERT_SKILL_MASTER.RECORD_STATUS_PARAM(objParameterList , objSkillMaster.RecordStatus);
			try
			{
				Logger.LogInfo("SkillMasterDAO.cs : InsertSkillMaster() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strInsertSkillMaster, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) > 0 )
					{
						objSkillMaster.SkillId = Convert.ToInt32(dbExecuteStatus);
						objSkillMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objSkillMaster.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("SkillMasterDAO.cs : InsertSkillMaster() is ended with success.");
				}
				else
				{
					objSkillMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("SkillMasterDAO.cs : InsertSkillMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objSkillMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("SkillMasterDAO.cs : InsertSkillMaster() is ended with error.");
			}
			return objSkillMaster;
		}

		public SkillMaster UpdateSkillMaster(SkillMaster objSkillMaster)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_UPDATE_SKILL_MASTER.SKILL_ID_PARAM(objParameterList , objSkillMaster.SkillId);
			UDSP_UPDATE_SKILL_MASTER.SKILL_NAME_PARAM(objParameterList , objSkillMaster.SkillName);
			UDSP_UPDATE_SKILL_MASTER.DESCRIPTION_PARAM(objParameterList , objSkillMaster.Description);
			UDSP_UPDATE_SKILL_MASTER.VERSION_PARAM(objParameterList , objSkillMaster.Version);
			UDSP_UPDATE_SKILL_MASTER.CREATED_BY_PARAM(objParameterList , objSkillMaster.CreatedBy);
			UDSP_UPDATE_SKILL_MASTER.CREATED_ON_PARAM(objParameterList , objSkillMaster.CreatedOn);
			UDSP_UPDATE_SKILL_MASTER.MODIFIED_BY_PARAM(objParameterList , objSkillMaster.ModifiedBy);
			UDSP_UPDATE_SKILL_MASTER.MODIFIED_ON_PARAM(objParameterList , objSkillMaster.ModifiedOn);
			UDSP_UPDATE_SKILL_MASTER.RECORD_STATUS_PARAM(objParameterList , objSkillMaster.RecordStatus);
			try
			{
				Logger.LogInfo("SkillMasterDAO.cs : UpdateSkillMaster() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strUpdateSkillMaster, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objSkillMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
					{
						objSkillMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					else
					{
						objSkillMaster.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("SkillMasterDAO.cs : UpdateSkillMaster() is ended with success.");
				}
				else
				{
					objSkillMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("SkillMasterDAO.cs : UpdateSkillMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objSkillMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("SkillMasterDAO.cs : UpdateSkillMaster() is ended with error.");
			}
			return objSkillMaster;
		}

		public SkillMaster ActivateDeactivateSkillMaster(SkillMaster objSkillMaster)
		{
			try
			{
				Logger.LogInfo("SkillMasterDAO.cs : ActivateDeactivateSkillMasterDAO() is started.");
				dbExecuteStatus = DataUtility.ActivateDeactivateObject(strDBTableName, objSkillMaster.SkillId,
										objSkillMaster.Version, objSkillMaster.RecordStatus, objSkillMaster.ModifiedBy);
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objSkillMaster.DbOperationStatus = CommonConstant.SUCCEED;
						Logger.LogInfo("SkillMasterDAO.cs : ActivateDeactivateSkillMaster() is ended with success.");
					}
					else
					{
						objSkillMaster.DbOperationStatus = CommonConstant.INVALID;
						Logger.LogInfo("SkillMasterDAO.cs : ActivateDeactivateSkillMaster() is ended with success.");
					}
				}
				else
				{
					objSkillMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("SkillMasterDAO.cs : ActivateDeactivateSkillMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objSkillMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("SkillMasterDAO.cs : ActivateDeactivateSkillMaster() is ended with error.");
			}
			return objSkillMaster;
		}

		public SkillMaster SelectRecordById(SkillMaster objSkillMaster)
		{
			try
			{
				Logger.LogInfo("SkillMasterDAO.cs : SelectRecordById() is started.");
				objSkillMaster.ObjectDataSet = DataUtility.SelectRecordById(strDBTableName, objSkillMaster.SkillId, objSkillMaster.Version, strSelectSkillMaster);
				if (GeneralUtility.IsInteger(objSkillMaster.ObjectDataSet.Tables[0].Rows[0][0]) && (objSkillMaster.ObjectDataSet.Tables[1].Columns.Count > 1))
				{
					if (Convert.ToInt32(objSkillMaster.ObjectDataSet.Tables[0].Rows[0][0]) > 0)
					{
						objSkillMaster.IsRecordChanged = false;
						objSkillMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objSkillMaster.IsRecordChanged = true;
						objSkillMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					Logger.LogInfo("SkillMasterDAO.cs : SelectRecordById() is ended with success.");
				}
				else
				{
					objSkillMaster.DbOperationStatus = CommonConstant.FAIL;
					dbExecuteStatus = objSkillMaster.ObjectDataSet.Tables[0].Rows[0][0].ToString() + " " + objSkillMaster.ObjectDataSet.Tables[1].Rows[0][0].ToString();
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("SkillMasterDAO.cs : SelectRecordById() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objSkillMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("SkillMasterDAO.cs : SelectRecordById() is ended with error.");
			}
			return objSkillMaster;
		}
	}
}
