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
	public class QualificationMasterDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "QUALIFICATION_MASTER";
		private string strSelectQualificationMaster = "UDSP_SELECT_QUALIFICATION_MASTER";
		private string strInsertQualificationMaster = "UDSP_INSERT_QUALIFICATION_MASTER";
		private string strUpdateQualificationMaster = "UDSP_UPDATE_QUALIFICATION_MASTER";
		private string dbExecuteStatus = "";

		public QualificationMaster SelectQualificationMaster(QualificationMaster objQualificationMaster)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_QUALIFICATION_MASTER.QUALIFICATION_ID_PARAM(objParameterList , objQualificationMaster.QualificationId);
			UDSP_SELECT_QUALIFICATION_MASTER.QUALIFICATION_NAME_PARAM(objParameterList , objQualificationMaster.QualificationName);
			UDSP_SELECT_QUALIFICATION_MASTER.DESCRIPTION_PARAM(objParameterList , objQualificationMaster.Description);
			UDSP_SELECT_QUALIFICATION_MASTER.RECORD_STATUS_PARAM(objParameterList , objQualificationMaster.RecordStatus);
			try
			{
				Logger.LogInfo("QualificationMasterDAO.cs : SelectQualificationMaster() is started.");
				objQualificationMaster.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectQualificationMaster, CommandType.StoredProcedure);
				objQualificationMaster.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("QualificationMasterDAO.cs : SelectQualificationMaster() is ended with success.");
			}
			catch (Exception ex)
			{
				objQualificationMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("QualificationMasterDAO.cs : SelectQualificationMaster() is ended with error.");
			}
			return objQualificationMaster;
		}

		public QualificationMaster InsertQualificationMaster(QualificationMaster objQualificationMaster)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_INSERT_QUALIFICATION_MASTER.QUALIFICATION_NAME_PARAM(objParameterList , objQualificationMaster.QualificationName);
			UDSP_INSERT_QUALIFICATION_MASTER.DESCRIPTION_PARAM(objParameterList , objQualificationMaster.Description);
			UDSP_INSERT_QUALIFICATION_MASTER.VERSION_PARAM(objParameterList , objQualificationMaster.Version);
			UDSP_INSERT_QUALIFICATION_MASTER.CREATED_BY_PARAM(objParameterList , objQualificationMaster.CreatedBy);
			UDSP_INSERT_QUALIFICATION_MASTER.CREATED_ON_PARAM(objParameterList , objQualificationMaster.CreatedOn);
			UDSP_INSERT_QUALIFICATION_MASTER.MODIFIED_BY_PARAM(objParameterList , objQualificationMaster.ModifiedBy);
			UDSP_INSERT_QUALIFICATION_MASTER.MODIFIED_ON_PARAM(objParameterList , objQualificationMaster.ModifiedOn);
			UDSP_INSERT_QUALIFICATION_MASTER.RECORD_STATUS_PARAM(objParameterList , objQualificationMaster.RecordStatus);
			try
			{
				Logger.LogInfo("QualificationMasterDAO.cs : InsertQualificationMaster() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strInsertQualificationMaster, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) > 0 )
					{
						objQualificationMaster.QualificationId = Convert.ToInt32(dbExecuteStatus);
						objQualificationMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objQualificationMaster.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("QualificationMasterDAO.cs : InsertQualificationMaster() is ended with success.");
				}
				else
				{
					objQualificationMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("QualificationMasterDAO.cs : InsertQualificationMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objQualificationMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("QualificationMasterDAO.cs : InsertQualificationMaster() is ended with error.");
			}
			return objQualificationMaster;
		}

		public QualificationMaster UpdateQualificationMaster(QualificationMaster objQualificationMaster)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_UPDATE_QUALIFICATION_MASTER.QUALIFICATION_ID_PARAM(objParameterList , objQualificationMaster.QualificationId);
			UDSP_UPDATE_QUALIFICATION_MASTER.QUALIFICATION_NAME_PARAM(objParameterList , objQualificationMaster.QualificationName);
			UDSP_UPDATE_QUALIFICATION_MASTER.DESCRIPTION_PARAM(objParameterList , objQualificationMaster.Description);
			UDSP_UPDATE_QUALIFICATION_MASTER.VERSION_PARAM(objParameterList , objQualificationMaster.Version);
			UDSP_UPDATE_QUALIFICATION_MASTER.CREATED_BY_PARAM(objParameterList , objQualificationMaster.CreatedBy);
			UDSP_UPDATE_QUALIFICATION_MASTER.CREATED_ON_PARAM(objParameterList , objQualificationMaster.CreatedOn);
			UDSP_UPDATE_QUALIFICATION_MASTER.MODIFIED_BY_PARAM(objParameterList , objQualificationMaster.ModifiedBy);
			UDSP_UPDATE_QUALIFICATION_MASTER.MODIFIED_ON_PARAM(objParameterList , objQualificationMaster.ModifiedOn);
			UDSP_UPDATE_QUALIFICATION_MASTER.RECORD_STATUS_PARAM(objParameterList , objQualificationMaster.RecordStatus);
			try
			{
				Logger.LogInfo("QualificationMasterDAO.cs : UpdateQualificationMaster() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strUpdateQualificationMaster, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objQualificationMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
					{
						objQualificationMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					else
					{
						objQualificationMaster.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("QualificationMasterDAO.cs : UpdateQualificationMaster() is ended with success.");
				}
				else
				{
					objQualificationMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("QualificationMasterDAO.cs : UpdateQualificationMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objQualificationMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("QualificationMasterDAO.cs : UpdateQualificationMaster() is ended with error.");
			}
			return objQualificationMaster;
		}

		public QualificationMaster ActivateDeactivateQualificationMaster(QualificationMaster objQualificationMaster)
		{
			try
			{
				Logger.LogInfo("QualificationMasterDAO.cs : ActivateDeactivateQualificationMasterDAO() is started.");
				dbExecuteStatus = DataUtility.ActivateDeactivateObject(strDBTableName, objQualificationMaster.QualificationId,
										objQualificationMaster.Version, objQualificationMaster.RecordStatus, objQualificationMaster.ModifiedBy);
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objQualificationMaster.DbOperationStatus = CommonConstant.SUCCEED;
						Logger.LogInfo("QualificationMasterDAO.cs : ActivateDeactivateQualificationMaster() is ended with success.");
					}
					else
					{
						objQualificationMaster.DbOperationStatus = CommonConstant.INVALID;
						Logger.LogInfo("QualificationMasterDAO.cs : ActivateDeactivateQualificationMaster() is ended with success.");
					}
				}
				else
				{
					objQualificationMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("QualificationMasterDAO.cs : ActivateDeactivateQualificationMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objQualificationMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("QualificationMasterDAO.cs : ActivateDeactivateQualificationMaster() is ended with error.");
			}
			return objQualificationMaster;
		}

		public QualificationMaster SelectRecordById(QualificationMaster objQualificationMaster)
		{
			try
			{
				Logger.LogInfo("QualificationMasterDAO.cs : SelectRecordById() is started.");
				objQualificationMaster.ObjectDataSet = DataUtility.SelectRecordById(strDBTableName, objQualificationMaster.QualificationId, objQualificationMaster.Version, strSelectQualificationMaster);
				if (GeneralUtility.IsInteger(objQualificationMaster.ObjectDataSet.Tables[0].Rows[0][0]) && (objQualificationMaster.ObjectDataSet.Tables[1].Columns.Count > 1))
				{
					if (Convert.ToInt32(objQualificationMaster.ObjectDataSet.Tables[0].Rows[0][0]) > 0)
					{
						objQualificationMaster.IsRecordChanged = false;
						objQualificationMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objQualificationMaster.IsRecordChanged = true;
						objQualificationMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					Logger.LogInfo("QualificationMasterDAO.cs : SelectRecordById() is ended with success.");
				}
				else
				{
					objQualificationMaster.DbOperationStatus = CommonConstant.FAIL;
					dbExecuteStatus = objQualificationMaster.ObjectDataSet.Tables[0].Rows[0][0].ToString() + " " + objQualificationMaster.ObjectDataSet.Tables[1].Rows[0][0].ToString();
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("QualificationMasterDAO.cs : SelectRecordById() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objQualificationMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("QualificationMasterDAO.cs : SelectRecordById() is ended with error.");
			}
			return objQualificationMaster;
		}
	}
}
