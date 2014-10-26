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
	public class SubjectMasterDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "SUBJECT_MASTER";
		private string strSelectSubjectMaster = "UDSP_SELECT_SUBJECT_MASTER";
		private string strInsertSubjectMaster = "UDSP_INSERT_SUBJECT_MASTER";
		private string strUpdateSubjectMaster = "UDSP_UPDATE_SUBJECT_MASTER";
		private string dbExecuteStatus = "";

		public SubjectMaster SelectSubjectMaster(SubjectMaster objSubjectMaster)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_SUBJECT_MASTER.SUBJECT_ID_PARAM(objParameterList , objSubjectMaster.SubjectId);
			UDSP_SELECT_SUBJECT_MASTER.SUBJECT_CODE_PARAM(objParameterList , objSubjectMaster.SubjectCode);
			UDSP_SELECT_SUBJECT_MASTER.SUBJECT_NAME_PARAM(objParameterList , objSubjectMaster.SubjectName);
			UDSP_SELECT_SUBJECT_MASTER.DESCRIPTION_PARAM(objParameterList , objSubjectMaster.Description);
			UDSP_SELECT_SUBJECT_MASTER.RECORD_STATUS_PARAM(objParameterList , objSubjectMaster.RecordStatus);
			try
			{
				Logger.LogInfo("SubjectMasterDAO.cs : SelectSubjectMaster() is started.");
				objSubjectMaster.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectSubjectMaster, CommandType.StoredProcedure);
				objSubjectMaster.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("SubjectMasterDAO.cs : SelectSubjectMaster() is ended with success.");
			}
			catch (Exception ex)
			{
				objSubjectMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("SubjectMasterDAO.cs : SelectSubjectMaster() is ended with error.");
			}
			return objSubjectMaster;
		}

		public SubjectMaster InsertSubjectMaster(SubjectMaster objSubjectMaster)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_INSERT_SUBJECT_MASTER.SUBJECT_CODE_PARAM(objParameterList , objSubjectMaster.SubjectCode);
			UDSP_INSERT_SUBJECT_MASTER.SUBJECT_NAME_PARAM(objParameterList , objSubjectMaster.SubjectName);
			UDSP_INSERT_SUBJECT_MASTER.DESCRIPTION_PARAM(objParameterList , objSubjectMaster.Description);
			UDSP_INSERT_SUBJECT_MASTER.VERSION_PARAM(objParameterList , objSubjectMaster.Version);
			UDSP_INSERT_SUBJECT_MASTER.CREATED_BY_PARAM(objParameterList , objSubjectMaster.CreatedBy);
			UDSP_INSERT_SUBJECT_MASTER.CREATED_ON_PARAM(objParameterList , objSubjectMaster.CreatedOn);
			UDSP_INSERT_SUBJECT_MASTER.MODIFIED_BY_PARAM(objParameterList , objSubjectMaster.ModifiedBy);
			UDSP_INSERT_SUBJECT_MASTER.MODIFIED_ON_PARAM(objParameterList , objSubjectMaster.ModifiedOn);
			UDSP_INSERT_SUBJECT_MASTER.RECORD_STATUS_PARAM(objParameterList , objSubjectMaster.RecordStatus);
			try
			{
				Logger.LogInfo("SubjectMasterDAO.cs : InsertSubjectMaster() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strInsertSubjectMaster, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) > 0 )
					{
						objSubjectMaster.SubjectId = Convert.ToInt32(dbExecuteStatus);
						objSubjectMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objSubjectMaster.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("SubjectMasterDAO.cs : InsertSubjectMaster() is ended with success.");
				}
				else
				{
					objSubjectMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("SubjectMasterDAO.cs : InsertSubjectMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objSubjectMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("SubjectMasterDAO.cs : InsertSubjectMaster() is ended with error.");
			}
			return objSubjectMaster;
		}

		public SubjectMaster UpdateSubjectMaster(SubjectMaster objSubjectMaster)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_UPDATE_SUBJECT_MASTER.SUBJECT_ID_PARAM(objParameterList , objSubjectMaster.SubjectId);
			UDSP_UPDATE_SUBJECT_MASTER.SUBJECT_CODE_PARAM(objParameterList , objSubjectMaster.SubjectCode);
			UDSP_UPDATE_SUBJECT_MASTER.SUBJECT_NAME_PARAM(objParameterList , objSubjectMaster.SubjectName);
			UDSP_UPDATE_SUBJECT_MASTER.DESCRIPTION_PARAM(objParameterList , objSubjectMaster.Description);
			UDSP_UPDATE_SUBJECT_MASTER.VERSION_PARAM(objParameterList , objSubjectMaster.Version);
			UDSP_UPDATE_SUBJECT_MASTER.CREATED_BY_PARAM(objParameterList , objSubjectMaster.CreatedBy);
			UDSP_UPDATE_SUBJECT_MASTER.CREATED_ON_PARAM(objParameterList , objSubjectMaster.CreatedOn);
			UDSP_UPDATE_SUBJECT_MASTER.MODIFIED_BY_PARAM(objParameterList , objSubjectMaster.ModifiedBy);
			UDSP_UPDATE_SUBJECT_MASTER.MODIFIED_ON_PARAM(objParameterList , objSubjectMaster.ModifiedOn);
			UDSP_UPDATE_SUBJECT_MASTER.RECORD_STATUS_PARAM(objParameterList , objSubjectMaster.RecordStatus);
			try
			{
				Logger.LogInfo("SubjectMasterDAO.cs : UpdateSubjectMaster() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strUpdateSubjectMaster, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objSubjectMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
					{
						objSubjectMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					else
					{
						objSubjectMaster.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("SubjectMasterDAO.cs : UpdateSubjectMaster() is ended with success.");
				}
				else
				{
					objSubjectMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("SubjectMasterDAO.cs : UpdateSubjectMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objSubjectMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("SubjectMasterDAO.cs : UpdateSubjectMaster() is ended with error.");
			}
			return objSubjectMaster;
		}

		public SubjectMaster ActivateDeactivateSubjectMaster(SubjectMaster objSubjectMaster)
		{
			try
			{
				Logger.LogInfo("SubjectMasterDAO.cs : ActivateDeactivateSubjectMasterDAO() is started.");
				dbExecuteStatus = DataUtility.ActivateDeactivateObject(strDBTableName, objSubjectMaster.SubjectId,
										objSubjectMaster.Version, objSubjectMaster.RecordStatus, objSubjectMaster.ModifiedBy);
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objSubjectMaster.DbOperationStatus = CommonConstant.SUCCEED;
						Logger.LogInfo("SubjectMasterDAO.cs : ActivateDeactivateSubjectMaster() is ended with success.");
					}
					else
					{
						objSubjectMaster.DbOperationStatus = CommonConstant.INVALID;
						Logger.LogInfo("SubjectMasterDAO.cs : ActivateDeactivateSubjectMaster() is ended with success.");
					}
				}
				else
				{
					objSubjectMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("SubjectMasterDAO.cs : ActivateDeactivateSubjectMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objSubjectMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("SubjectMasterDAO.cs : ActivateDeactivateSubjectMaster() is ended with error.");
			}
			return objSubjectMaster;
		}

		public SubjectMaster SelectRecordById(SubjectMaster objSubjectMaster)
		{
			try
			{
				Logger.LogInfo("SubjectMasterDAO.cs : SelectRecordById() is started.");
				objSubjectMaster.ObjectDataSet = DataUtility.SelectRecordById(strDBTableName, objSubjectMaster.SubjectId, objSubjectMaster.Version, strSelectSubjectMaster);
				if (GeneralUtility.IsInteger(objSubjectMaster.ObjectDataSet.Tables[0].Rows[0][0]) && (objSubjectMaster.ObjectDataSet.Tables[1].Columns.Count > 1))
				{
					if (Convert.ToInt32(objSubjectMaster.ObjectDataSet.Tables[0].Rows[0][0]) > 0)
					{
						objSubjectMaster.IsRecordChanged = false;
						objSubjectMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objSubjectMaster.IsRecordChanged = true;
						objSubjectMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					Logger.LogInfo("SubjectMasterDAO.cs : SelectRecordById() is ended with success.");
				}
				else
				{
					objSubjectMaster.DbOperationStatus = CommonConstant.FAIL;
					dbExecuteStatus = objSubjectMaster.ObjectDataSet.Tables[0].Rows[0][0].ToString() + " " + objSubjectMaster.ObjectDataSet.Tables[1].Rows[0][0].ToString();
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("SubjectMasterDAO.cs : SelectRecordById() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objSubjectMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("SubjectMasterDAO.cs : SelectRecordById() is ended with error.");
			}
			return objSubjectMaster;
		}
	}
}
