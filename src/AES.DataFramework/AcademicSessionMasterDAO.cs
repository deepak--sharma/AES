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
	public class AcademicSessionMasterDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "ACADEMIC_SESSION_MASTER";
		private string strSelectAcademicSessionMaster = "UDSP_SELECT_ACADEMIC_SESSION_MASTER";
		private string strInsertAcademicSessionMaster = "UDSP_INSERT_ACADEMIC_SESSION_MASTER";
		private string strUpdateAcademicSessionMaster = "UDSP_UPDATE_ACADEMIC_SESSION_MASTER";
		private string dbExecuteStatus = "";

		public AcademicSessionMaster SelectAcademicSessionMaster(AcademicSessionMaster objAcademicSessionMaster)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_ACADEMIC_SESSION_MASTER.SESSION_ID_PARAM(objParameterList , objAcademicSessionMaster.SessionId);
			UDSP_SELECT_ACADEMIC_SESSION_MASTER.SESSION_NAME_PARAM(objParameterList , objAcademicSessionMaster.SessionName);
			UDSP_SELECT_ACADEMIC_SESSION_MASTER.RECORD_STATUS_PARAM(objParameterList , objAcademicSessionMaster.RecordStatus);
			try
			{
				Logger.LogInfo("AcademicSessionMasterDAO.cs : SelectAcademicSessionMaster() is started.");
				objAcademicSessionMaster.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectAcademicSessionMaster, CommandType.StoredProcedure);
				objAcademicSessionMaster.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("AcademicSessionMasterDAO.cs : SelectAcademicSessionMaster() is ended with success.");
			}
			catch (Exception ex)
			{
				objAcademicSessionMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("AcademicSessionMasterDAO.cs : SelectAcademicSessionMaster() is ended with error.");
			}
			return objAcademicSessionMaster;
		}

		public AcademicSessionMaster InsertAcademicSessionMaster(AcademicSessionMaster objAcademicSessionMaster)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_INSERT_ACADEMIC_SESSION_MASTER.SESSION_NAME_PARAM(objParameterList , objAcademicSessionMaster.SessionName);
			UDSP_INSERT_ACADEMIC_SESSION_MASTER.VERSION_PARAM(objParameterList , objAcademicSessionMaster.Version);
			UDSP_INSERT_ACADEMIC_SESSION_MASTER.CREATED_BY_PARAM(objParameterList , objAcademicSessionMaster.CreatedBy);
			UDSP_INSERT_ACADEMIC_SESSION_MASTER.CREATED_ON_PARAM(objParameterList , objAcademicSessionMaster.CreatedOn);
			UDSP_INSERT_ACADEMIC_SESSION_MASTER.MODIFIED_BY_PARAM(objParameterList , objAcademicSessionMaster.ModifiedBy);
			UDSP_INSERT_ACADEMIC_SESSION_MASTER.MODIFIED_ON_PARAM(objParameterList , objAcademicSessionMaster.ModifiedOn);
			UDSP_INSERT_ACADEMIC_SESSION_MASTER.RECORD_STATUS_PARAM(objParameterList , objAcademicSessionMaster.RecordStatus);
			try
			{
				Logger.LogInfo("AcademicSessionMasterDAO.cs : InsertAcademicSessionMaster() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strInsertAcademicSessionMaster, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) > 0 )
					{
						objAcademicSessionMaster.SessionId = Convert.ToInt32(dbExecuteStatus);
						objAcademicSessionMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objAcademicSessionMaster.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("AcademicSessionMasterDAO.cs : InsertAcademicSessionMaster() is ended with success.");
				}
				else
				{
					objAcademicSessionMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("AcademicSessionMasterDAO.cs : InsertAcademicSessionMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objAcademicSessionMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("AcademicSessionMasterDAO.cs : InsertAcademicSessionMaster() is ended with error.");
			}
			return objAcademicSessionMaster;
		}

		public AcademicSessionMaster UpdateAcademicSessionMaster(AcademicSessionMaster objAcademicSessionMaster)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_UPDATE_ACADEMIC_SESSION_MASTER.SESSION_ID_PARAM(objParameterList , objAcademicSessionMaster.SessionId);
			UDSP_UPDATE_ACADEMIC_SESSION_MASTER.SESSION_NAME_PARAM(objParameterList , objAcademicSessionMaster.SessionName);
			UDSP_UPDATE_ACADEMIC_SESSION_MASTER.VERSION_PARAM(objParameterList , objAcademicSessionMaster.Version);
			UDSP_UPDATE_ACADEMIC_SESSION_MASTER.CREATED_BY_PARAM(objParameterList , objAcademicSessionMaster.CreatedBy);
			UDSP_UPDATE_ACADEMIC_SESSION_MASTER.CREATED_ON_PARAM(objParameterList , objAcademicSessionMaster.CreatedOn);
			UDSP_UPDATE_ACADEMIC_SESSION_MASTER.MODIFIED_BY_PARAM(objParameterList , objAcademicSessionMaster.ModifiedBy);
			UDSP_UPDATE_ACADEMIC_SESSION_MASTER.MODIFIED_ON_PARAM(objParameterList , objAcademicSessionMaster.ModifiedOn);
			UDSP_UPDATE_ACADEMIC_SESSION_MASTER.RECORD_STATUS_PARAM(objParameterList , objAcademicSessionMaster.RecordStatus);
			try
			{
				Logger.LogInfo("AcademicSessionMasterDAO.cs : UpdateAcademicSessionMaster() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strUpdateAcademicSessionMaster, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objAcademicSessionMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
					{
						objAcademicSessionMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					else
					{
						objAcademicSessionMaster.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("AcademicSessionMasterDAO.cs : UpdateAcademicSessionMaster() is ended with success.");
				}
				else
				{
					objAcademicSessionMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("AcademicSessionMasterDAO.cs : UpdateAcademicSessionMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objAcademicSessionMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("AcademicSessionMasterDAO.cs : UpdateAcademicSessionMaster() is ended with error.");
			}
			return objAcademicSessionMaster;
		}

		public AcademicSessionMaster ActivateDeactivateAcademicSessionMaster(AcademicSessionMaster objAcademicSessionMaster)
		{
			try
			{
				Logger.LogInfo("AcademicSessionMasterDAO.cs : ActivateDeactivateAcademicSessionMasterDAO() is started.");
				dbExecuteStatus = DataUtility.ActivateDeactivateObject(strDBTableName, objAcademicSessionMaster.SessionId,
										objAcademicSessionMaster.Version, objAcademicSessionMaster.RecordStatus, objAcademicSessionMaster.ModifiedBy);
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objAcademicSessionMaster.DbOperationStatus = CommonConstant.SUCCEED;
						Logger.LogInfo("AcademicSessionMasterDAO.cs : ActivateDeactivateAcademicSessionMaster() is ended with success.");
					}
					else
					{
						objAcademicSessionMaster.DbOperationStatus = CommonConstant.INVALID;
						Logger.LogInfo("AcademicSessionMasterDAO.cs : ActivateDeactivateAcademicSessionMaster() is ended with success.");
					}
				}
				else
				{
					objAcademicSessionMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("AcademicSessionMasterDAO.cs : ActivateDeactivateAcademicSessionMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objAcademicSessionMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("AcademicSessionMasterDAO.cs : ActivateDeactivateAcademicSessionMaster() is ended with error.");
			}
			return objAcademicSessionMaster;
		}

		public AcademicSessionMaster SelectRecordById(AcademicSessionMaster objAcademicSessionMaster)
		{
			try
			{
				Logger.LogInfo("AcademicSessionMasterDAO.cs : SelectRecordById() is started.");
				objAcademicSessionMaster.ObjectDataSet = DataUtility.SelectRecordById(strDBTableName, objAcademicSessionMaster.SessionId, objAcademicSessionMaster.Version, strSelectAcademicSessionMaster);
				if (GeneralUtility.IsInteger(objAcademicSessionMaster.ObjectDataSet.Tables[0].Rows[0][0]) && (objAcademicSessionMaster.ObjectDataSet.Tables[1].Columns.Count > 1))
				{
					if (Convert.ToInt32(objAcademicSessionMaster.ObjectDataSet.Tables[0].Rows[0][0]) > 0)
					{
						objAcademicSessionMaster.IsRecordChanged = false;
						objAcademicSessionMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objAcademicSessionMaster.IsRecordChanged = true;
						objAcademicSessionMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					Logger.LogInfo("AcademicSessionMasterDAO.cs : SelectRecordById() is ended with success.");
				}
				else
				{
					objAcademicSessionMaster.DbOperationStatus = CommonConstant.FAIL;
					dbExecuteStatus = objAcademicSessionMaster.ObjectDataSet.Tables[0].Rows[0][0].ToString() + " " + objAcademicSessionMaster.ObjectDataSet.Tables[1].Rows[0][0].ToString();
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("AcademicSessionMasterDAO.cs : SelectRecordById() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objAcademicSessionMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("AcademicSessionMasterDAO.cs : SelectRecordById() is ended with error.");
			}
			return objAcademicSessionMaster;
		}
	}
}
