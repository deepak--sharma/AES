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
	public class MedicalMasterDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "MEDICAL_MASTER";
		private string strSelectMedicalMaster = "UDSP_SELECT_MEDICAL_MASTER";
		private string strInsertMedicalMaster = "UDSP_INSERT_MEDICAL_MASTER";
		private string strUpdateMedicalMaster = "UDSP_UPDATE_MEDICAL_MASTER";
		private string dbExecuteStatus = "";

		public MedicalMaster SelectMedicalMaster(MedicalMaster objMedicalMaster)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_MEDICAL_MASTER.MEDICAL_ID_PARAM(objParameterList , objMedicalMaster.MedicalId);
			UDSP_SELECT_MEDICAL_MASTER.MEDICAL_NAME_PARAM(objParameterList , objMedicalMaster.MedicalName);
			UDSP_SELECT_MEDICAL_MASTER.DESCRIPTION_PARAM(objParameterList , objMedicalMaster.Description);
			UDSP_SELECT_MEDICAL_MASTER.RECORD_STATUS_PARAM(objParameterList , objMedicalMaster.RecordStatus);
			try
			{
				Logger.LogInfo("MedicalMasterDAO.cs : SelectMedicalMaster() is started.");
				objMedicalMaster.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectMedicalMaster, CommandType.StoredProcedure);
				objMedicalMaster.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("MedicalMasterDAO.cs : SelectMedicalMaster() is ended with success.");
			}
			catch (Exception ex)
			{
				objMedicalMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("MedicalMasterDAO.cs : SelectMedicalMaster() is ended with error.");
			}
			return objMedicalMaster;
		}

		public MedicalMaster InsertMedicalMaster(MedicalMaster objMedicalMaster)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_INSERT_MEDICAL_MASTER.MEDICAL_NAME_PARAM(objParameterList , objMedicalMaster.MedicalName);
			UDSP_INSERT_MEDICAL_MASTER.DESCRIPTION_PARAM(objParameterList , objMedicalMaster.Description);
			UDSP_INSERT_MEDICAL_MASTER.VERSION_PARAM(objParameterList , objMedicalMaster.Version);
			UDSP_INSERT_MEDICAL_MASTER.CREATED_BY_PARAM(objParameterList , objMedicalMaster.CreatedBy);
			UDSP_INSERT_MEDICAL_MASTER.CREATED_ON_PARAM(objParameterList , objMedicalMaster.CreatedOn);
			UDSP_INSERT_MEDICAL_MASTER.MODIFIED_BY_PARAM(objParameterList , objMedicalMaster.ModifiedBy);
			UDSP_INSERT_MEDICAL_MASTER.MODIFIED_ON_PARAM(objParameterList , objMedicalMaster.ModifiedOn);
			UDSP_INSERT_MEDICAL_MASTER.RECORD_STATUS_PARAM(objParameterList , objMedicalMaster.RecordStatus);
			try
			{
				Logger.LogInfo("MedicalMasterDAO.cs : InsertMedicalMaster() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strInsertMedicalMaster, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) > 0 )
					{
						objMedicalMaster.MedicalId = Convert.ToInt32(dbExecuteStatus);
						objMedicalMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objMedicalMaster.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("MedicalMasterDAO.cs : InsertMedicalMaster() is ended with success.");
				}
				else
				{
					objMedicalMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("MedicalMasterDAO.cs : InsertMedicalMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objMedicalMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("MedicalMasterDAO.cs : InsertMedicalMaster() is ended with error.");
			}
			return objMedicalMaster;
		}

		public MedicalMaster UpdateMedicalMaster(MedicalMaster objMedicalMaster)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_UPDATE_MEDICAL_MASTER.MEDICAL_ID_PARAM(objParameterList , objMedicalMaster.MedicalId);
			UDSP_UPDATE_MEDICAL_MASTER.MEDICAL_NAME_PARAM(objParameterList , objMedicalMaster.MedicalName);
			UDSP_UPDATE_MEDICAL_MASTER.DESCRIPTION_PARAM(objParameterList , objMedicalMaster.Description);
			UDSP_UPDATE_MEDICAL_MASTER.VERSION_PARAM(objParameterList , objMedicalMaster.Version);
			UDSP_UPDATE_MEDICAL_MASTER.CREATED_BY_PARAM(objParameterList , objMedicalMaster.CreatedBy);
			UDSP_UPDATE_MEDICAL_MASTER.CREATED_ON_PARAM(objParameterList , objMedicalMaster.CreatedOn);
			UDSP_UPDATE_MEDICAL_MASTER.MODIFIED_BY_PARAM(objParameterList , objMedicalMaster.ModifiedBy);
			UDSP_UPDATE_MEDICAL_MASTER.MODIFIED_ON_PARAM(objParameterList , objMedicalMaster.ModifiedOn);
			UDSP_UPDATE_MEDICAL_MASTER.RECORD_STATUS_PARAM(objParameterList , objMedicalMaster.RecordStatus);
			try
			{
				Logger.LogInfo("MedicalMasterDAO.cs : UpdateMedicalMaster() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strUpdateMedicalMaster, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objMedicalMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
					{
						objMedicalMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					else
					{
						objMedicalMaster.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("MedicalMasterDAO.cs : UpdateMedicalMaster() is ended with success.");
				}
				else
				{
					objMedicalMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("MedicalMasterDAO.cs : UpdateMedicalMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objMedicalMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("MedicalMasterDAO.cs : UpdateMedicalMaster() is ended with error.");
			}
			return objMedicalMaster;
		}

		public MedicalMaster ActivateDeactivateMedicalMaster(MedicalMaster objMedicalMaster)
		{
			try
			{
				Logger.LogInfo("MedicalMasterDAO.cs : ActivateDeactivateMedicalMasterDAO() is started.");
				dbExecuteStatus = DataUtility.ActivateDeactivateObject(strDBTableName, objMedicalMaster.MedicalId,
										objMedicalMaster.Version, objMedicalMaster.RecordStatus, objMedicalMaster.ModifiedBy);
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objMedicalMaster.DbOperationStatus = CommonConstant.SUCCEED;
						Logger.LogInfo("MedicalMasterDAO.cs : ActivateDeactivateMedicalMaster() is ended with success.");
					}
					else
					{
						objMedicalMaster.DbOperationStatus = CommonConstant.INVALID;
						Logger.LogInfo("MedicalMasterDAO.cs : ActivateDeactivateMedicalMaster() is ended with success.");
					}
				}
				else
				{
					objMedicalMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("MedicalMasterDAO.cs : ActivateDeactivateMedicalMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objMedicalMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("MedicalMasterDAO.cs : ActivateDeactivateMedicalMaster() is ended with error.");
			}
			return objMedicalMaster;
		}

		public MedicalMaster SelectRecordById(MedicalMaster objMedicalMaster)
		{
			try
			{
				Logger.LogInfo("MedicalMasterDAO.cs : SelectRecordById() is started.");
				objMedicalMaster.ObjectDataSet = DataUtility.SelectRecordById(strDBTableName, objMedicalMaster.MedicalId, objMedicalMaster.Version, strSelectMedicalMaster);
				if (GeneralUtility.IsInteger(objMedicalMaster.ObjectDataSet.Tables[0].Rows[0][0]) && (objMedicalMaster.ObjectDataSet.Tables[1].Columns.Count > 1))
				{
					if (Convert.ToInt32(objMedicalMaster.ObjectDataSet.Tables[0].Rows[0][0]) > 0)
					{
						objMedicalMaster.IsRecordChanged = false;
						objMedicalMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objMedicalMaster.IsRecordChanged = true;
						objMedicalMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					Logger.LogInfo("MedicalMasterDAO.cs : SelectRecordById() is ended with success.");
				}
				else
				{
					objMedicalMaster.DbOperationStatus = CommonConstant.FAIL;
					dbExecuteStatus = objMedicalMaster.ObjectDataSet.Tables[0].Rows[0][0].ToString() + " " + objMedicalMaster.ObjectDataSet.Tables[1].Rows[0][0].ToString();
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("MedicalMasterDAO.cs : SelectRecordById() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objMedicalMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("MedicalMasterDAO.cs : SelectRecordById() is ended with error.");
			}
			return objMedicalMaster;
		}
	}
}
