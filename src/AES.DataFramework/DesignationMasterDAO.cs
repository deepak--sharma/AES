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
	public class DesignationMasterDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "DESIGNATION_MASTER";
		private string strSelectDesignationMaster = "UDSP_SELECT_DESIGNATION_MASTER";
		private string strInsertDesignationMaster = "UDSP_INSERT_DESIGNATION_MASTER";
		private string strUpdateDesignationMaster = "UDSP_UPDATE_DESIGNATION_MASTER";
		private string dbExecuteStatus = "";

		public DesignationMaster SelectDesignationMaster(DesignationMaster objDesignationMaster)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_DESIGNATION_MASTER.DESIGNATION_ID_PARAM(objParameterList , objDesignationMaster.DesignationId);
			UDSP_SELECT_DESIGNATION_MASTER.DESIGNATION_CODE_PARAM(objParameterList , objDesignationMaster.DesignationCode);
			UDSP_SELECT_DESIGNATION_MASTER.DESIGNATION_NAME_PARAM(objParameterList , objDesignationMaster.DesignationName);
			UDSP_SELECT_DESIGNATION_MASTER.DESCRIPTION_PARAM(objParameterList , objDesignationMaster.Description);
			UDSP_SELECT_DESIGNATION_MASTER.RECORD_STATUS_PARAM(objParameterList , objDesignationMaster.RecordStatus);
			try
			{
				Logger.LogInfo("DesignationMasterDAO.cs : SelectDesignationMaster() is started.");
				objDesignationMaster.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectDesignationMaster, CommandType.StoredProcedure);
				objDesignationMaster.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("DesignationMasterDAO.cs : SelectDesignationMaster() is ended with success.");
			}
			catch (Exception ex)
			{
				objDesignationMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("DesignationMasterDAO.cs : SelectDesignationMaster() is ended with error.");
			}
			return objDesignationMaster;
		}

		public DesignationMaster InsertDesignationMaster(DesignationMaster objDesignationMaster)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_INSERT_DESIGNATION_MASTER.DESIGNATION_CODE_PARAM(objParameterList , objDesignationMaster.DesignationCode);
			UDSP_INSERT_DESIGNATION_MASTER.DESIGNATION_NAME_PARAM(objParameterList , objDesignationMaster.DesignationName);
			UDSP_INSERT_DESIGNATION_MASTER.DESCRIPTION_PARAM(objParameterList , objDesignationMaster.Description);
			UDSP_INSERT_DESIGNATION_MASTER.VERSION_PARAM(objParameterList , objDesignationMaster.Version);
			UDSP_INSERT_DESIGNATION_MASTER.CREATED_BY_PARAM(objParameterList , objDesignationMaster.CreatedBy);
			UDSP_INSERT_DESIGNATION_MASTER.CREATED_ON_PARAM(objParameterList , objDesignationMaster.CreatedOn);
			UDSP_INSERT_DESIGNATION_MASTER.MODIFIED_BY_PARAM(objParameterList , objDesignationMaster.ModifiedBy);
			UDSP_INSERT_DESIGNATION_MASTER.MODIFIED_ON_PARAM(objParameterList , objDesignationMaster.ModifiedOn);
			UDSP_INSERT_DESIGNATION_MASTER.RECORD_STATUS_PARAM(objParameterList , objDesignationMaster.RecordStatus);
			try
			{
				Logger.LogInfo("DesignationMasterDAO.cs : InsertDesignationMaster() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strInsertDesignationMaster, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) > 0 )
					{
						objDesignationMaster.DesignationId = Convert.ToInt32(dbExecuteStatus);
						objDesignationMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objDesignationMaster.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("DesignationMasterDAO.cs : InsertDesignationMaster() is ended with success.");
				}
				else
				{
					objDesignationMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("DesignationMasterDAO.cs : InsertDesignationMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objDesignationMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("DesignationMasterDAO.cs : InsertDesignationMaster() is ended with error.");
			}
			return objDesignationMaster;
		}

		public DesignationMaster UpdateDesignationMaster(DesignationMaster objDesignationMaster)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_UPDATE_DESIGNATION_MASTER.DESIGNATION_ID_PARAM(objParameterList , objDesignationMaster.DesignationId);
			UDSP_UPDATE_DESIGNATION_MASTER.DESIGNATION_CODE_PARAM(objParameterList , objDesignationMaster.DesignationCode);
			UDSP_UPDATE_DESIGNATION_MASTER.DESIGNATION_NAME_PARAM(objParameterList , objDesignationMaster.DesignationName);
			UDSP_UPDATE_DESIGNATION_MASTER.DESCRIPTION_PARAM(objParameterList , objDesignationMaster.Description);
			UDSP_UPDATE_DESIGNATION_MASTER.VERSION_PARAM(objParameterList , objDesignationMaster.Version);
			UDSP_UPDATE_DESIGNATION_MASTER.CREATED_BY_PARAM(objParameterList , objDesignationMaster.CreatedBy);
			UDSP_UPDATE_DESIGNATION_MASTER.CREATED_ON_PARAM(objParameterList , objDesignationMaster.CreatedOn);
			UDSP_UPDATE_DESIGNATION_MASTER.MODIFIED_BY_PARAM(objParameterList , objDesignationMaster.ModifiedBy);
			UDSP_UPDATE_DESIGNATION_MASTER.MODIFIED_ON_PARAM(objParameterList , objDesignationMaster.ModifiedOn);
			UDSP_UPDATE_DESIGNATION_MASTER.RECORD_STATUS_PARAM(objParameterList , objDesignationMaster.RecordStatus);
			try
			{
				Logger.LogInfo("DesignationMasterDAO.cs : UpdateDesignationMaster() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strUpdateDesignationMaster, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objDesignationMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
					{
						objDesignationMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					else
					{
						objDesignationMaster.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("DesignationMasterDAO.cs : UpdateDesignationMaster() is ended with success.");
				}
				else
				{
					objDesignationMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("DesignationMasterDAO.cs : UpdateDesignationMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objDesignationMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("DesignationMasterDAO.cs : UpdateDesignationMaster() is ended with error.");
			}
			return objDesignationMaster;
		}

		public DesignationMaster ActivateDeactivateDesignationMaster(DesignationMaster objDesignationMaster)
		{
			try
			{
				Logger.LogInfo("DesignationMasterDAO.cs : ActivateDeactivateDesignationMasterDAO() is started.");
				dbExecuteStatus = DataUtility.ActivateDeactivateObject(strDBTableName, objDesignationMaster.DesignationId,
										objDesignationMaster.Version, objDesignationMaster.RecordStatus, objDesignationMaster.ModifiedBy);
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objDesignationMaster.DbOperationStatus = CommonConstant.SUCCEED;
						Logger.LogInfo("DesignationMasterDAO.cs : ActivateDeactivateDesignationMaster() is ended with success.");
					}
					else
					{
						objDesignationMaster.DbOperationStatus = CommonConstant.INVALID;
						Logger.LogInfo("DesignationMasterDAO.cs : ActivateDeactivateDesignationMaster() is ended with success.");
					}
				}
				else
				{
					objDesignationMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("DesignationMasterDAO.cs : ActivateDeactivateDesignationMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objDesignationMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("DesignationMasterDAO.cs : ActivateDeactivateDesignationMaster() is ended with error.");
			}
			return objDesignationMaster;
		}

		public DesignationMaster SelectRecordById(DesignationMaster objDesignationMaster)
		{
			try
			{
				Logger.LogInfo("DesignationMasterDAO.cs : SelectRecordById() is started.");
				objDesignationMaster.ObjectDataSet = DataUtility.SelectRecordById(strDBTableName, objDesignationMaster.DesignationId, objDesignationMaster.Version, strSelectDesignationMaster);
				if (GeneralUtility.IsInteger(objDesignationMaster.ObjectDataSet.Tables[0].Rows[0][0]) && (objDesignationMaster.ObjectDataSet.Tables[1].Columns.Count > 1))
				{
					if (Convert.ToInt32(objDesignationMaster.ObjectDataSet.Tables[0].Rows[0][0]) > 0)
					{
						objDesignationMaster.IsRecordChanged = false;
						objDesignationMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objDesignationMaster.IsRecordChanged = true;
						objDesignationMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					Logger.LogInfo("DesignationMasterDAO.cs : SelectRecordById() is ended with success.");
				}
				else
				{
					objDesignationMaster.DbOperationStatus = CommonConstant.FAIL;
					dbExecuteStatus = objDesignationMaster.ObjectDataSet.Tables[0].Rows[0][0].ToString() + " " + objDesignationMaster.ObjectDataSet.Tables[1].Rows[0][0].ToString();
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("DesignationMasterDAO.cs : SelectRecordById() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objDesignationMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("DesignationMasterDAO.cs : SelectRecordById() is ended with error.");
			}
			return objDesignationMaster;
		}
	}
}
