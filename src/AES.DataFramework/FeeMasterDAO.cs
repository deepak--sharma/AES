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
	public class FeeMasterDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "FEE_MASTER";
		private string strSelectFeeMaster = "SP_SELECT_FEE_MASTER";
		private string strInsertFeeMaster = "UDSP_INSERT_FEE_MASTER";
		private string strUpdateFeeMaster = "UDSP_UPDATE_FEE_MASTER";
		private string dbExecuteStatus = "";

		public FeeMaster SelectFeeMaster(FeeMaster objFeeMaster)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_FEE_MASTER.FEE_ID_PARAM(objParameterList , objFeeMaster.FeeId);
			UDSP_SELECT_FEE_MASTER.FEE_CODE_PARAM(objParameterList , objFeeMaster.FeeCode);
			UDSP_SELECT_FEE_MASTER.FEE_NAME_PARAM(objParameterList , objFeeMaster.FeeName);
			if (objFeeMaster.FeeGroupObject != null)
			{
				UDSP_SELECT_FEE_MASTER.FEE_GROUP_ID_PARAM(objParameterList , objFeeMaster.FeeGroupObject.MetadataId);
			}
			if (objFeeMaster.FrequencyObject != null)
			{
				UDSP_SELECT_FEE_MASTER.FREQUENCY_ID_PARAM(objParameterList , objFeeMaster.FrequencyObject.MetadataId);
			}
			UDSP_SELECT_FEE_MASTER.IS_MANDATORY_PARAM(objParameterList , objFeeMaster.IsMandatory);
			UDSP_SELECT_FEE_MASTER.IS_REFUNDABLE_PARAM(objParameterList , objFeeMaster.IsRefundable);           

			if (objFeeMaster.ApplicableTo != null)
			{
				UDSP_SELECT_FEE_MASTER.APPLICABLE_TO_PARAM(objParameterList , objFeeMaster.ApplicableTo.MetadataId);
			}
			UDSP_SELECT_FEE_MASTER.DESCRIPTION_PARAM(objParameterList , objFeeMaster.Description);
			UDSP_SELECT_FEE_MASTER.RECORD_STATUS_PARAM(objParameterList , objFeeMaster.RecordStatus);
			try
			{
				Logger.LogInfo("FeeMasterDAO.cs : SelectFeeMaster() is started.");
				objFeeMaster.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectFeeMaster, CommandType.StoredProcedure);
				objFeeMaster.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("FeeMasterDAO.cs : SelectFeeMaster() is ended with success.");
			}
			catch (Exception ex)
			{
				objFeeMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("FeeMasterDAO.cs : SelectFeeMaster() is ended with error.");
			}
			return objFeeMaster;
		}

		public FeeMaster InsertFeeMaster(FeeMaster objFeeMaster)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_INSERT_FEE_MASTER.FEE_CODE_PARAM(objParameterList , objFeeMaster.FeeCode);
			UDSP_INSERT_FEE_MASTER.FEE_NAME_PARAM(objParameterList , objFeeMaster.FeeName);
			if (objFeeMaster.FeeGroupObject != null)
			{
				UDSP_INSERT_FEE_MASTER.FEE_GROUP_ID_PARAM(objParameterList , objFeeMaster.FeeGroupObject.MetadataId);
			}
			if (objFeeMaster.FrequencyObject != null)
			{
				UDSP_INSERT_FEE_MASTER.FREQUENCY_ID_PARAM(objParameterList , objFeeMaster.FrequencyObject.MetadataId);
			}
			UDSP_INSERT_FEE_MASTER.IS_MANDATORY_PARAM(objParameterList , objFeeMaster.IsMandatory);
			UDSP_INSERT_FEE_MASTER.IS_REFUNDABLE_PARAM(objParameterList , objFeeMaster.IsRefundable);
			if (objFeeMaster.ApplicableTo != null)
			{
				UDSP_INSERT_FEE_MASTER.APPLICABLE_TO_PARAM(objParameterList , objFeeMaster.ApplicableTo.MetadataId);
			}
			UDSP_INSERT_FEE_MASTER.DESCRIPTION_PARAM(objParameterList , objFeeMaster.Description);
			UDSP_INSERT_FEE_MASTER.VERSION_PARAM(objParameterList , objFeeMaster.Version);
			UDSP_INSERT_FEE_MASTER.CREATED_BY_PARAM(objParameterList , objFeeMaster.CreatedBy);
			UDSP_INSERT_FEE_MASTER.CREATED_ON_PARAM(objParameterList , objFeeMaster.CreatedOn);
			UDSP_INSERT_FEE_MASTER.MODIFIED_BY_PARAM(objParameterList , objFeeMaster.ModifiedBy);
			UDSP_INSERT_FEE_MASTER.MODIFIED_ON_PARAM(objParameterList , objFeeMaster.ModifiedOn);
			UDSP_INSERT_FEE_MASTER.RECORD_STATUS_PARAM(objParameterList , objFeeMaster.RecordStatus);
			try
			{
				Logger.LogInfo("FeeMasterDAO.cs : InsertFeeMaster() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strInsertFeeMaster, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) > 0 )
					{
						objFeeMaster.FeeId = Convert.ToInt32(dbExecuteStatus);
						objFeeMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objFeeMaster.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("FeeMasterDAO.cs : InsertFeeMaster() is ended with success.");
				}
				else
				{
					objFeeMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("FeeMasterDAO.cs : InsertFeeMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objFeeMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("FeeMasterDAO.cs : InsertFeeMaster() is ended with error.");
			}
			return objFeeMaster;
		}

		public FeeMaster UpdateFeeMaster(FeeMaster objFeeMaster)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_UPDATE_FEE_MASTER.FEE_ID_PARAM(objParameterList , objFeeMaster.FeeId);
			UDSP_UPDATE_FEE_MASTER.FEE_CODE_PARAM(objParameterList , objFeeMaster.FeeCode);
			UDSP_UPDATE_FEE_MASTER.FEE_NAME_PARAM(objParameterList , objFeeMaster.FeeName);
			if (objFeeMaster.FeeGroupObject != null)
			{
				UDSP_UPDATE_FEE_MASTER.FEE_GROUP_ID_PARAM(objParameterList , objFeeMaster.FeeGroupObject.MetadataId);
			}
			if (objFeeMaster.FrequencyObject != null)
			{
				UDSP_UPDATE_FEE_MASTER.FREQUENCY_ID_PARAM(objParameterList , objFeeMaster.FrequencyObject.MetadataId);
			}
			UDSP_UPDATE_FEE_MASTER.IS_MANDATORY_PARAM(objParameterList , objFeeMaster.IsMandatory);
			UDSP_UPDATE_FEE_MASTER.IS_REFUNDABLE_PARAM(objParameterList , objFeeMaster.IsRefundable);
			if (objFeeMaster.ApplicableTo != null)
			{
				UDSP_UPDATE_FEE_MASTER.APPLICABLE_TO_PARAM(objParameterList , objFeeMaster.ApplicableTo.MetadataId);
			}
			UDSP_UPDATE_FEE_MASTER.DESCRIPTION_PARAM(objParameterList , objFeeMaster.Description);
			UDSP_UPDATE_FEE_MASTER.VERSION_PARAM(objParameterList , objFeeMaster.Version);
			UDSP_UPDATE_FEE_MASTER.CREATED_BY_PARAM(objParameterList , objFeeMaster.CreatedBy);
			UDSP_UPDATE_FEE_MASTER.CREATED_ON_PARAM(objParameterList , objFeeMaster.CreatedOn);
			UDSP_UPDATE_FEE_MASTER.MODIFIED_BY_PARAM(objParameterList , objFeeMaster.ModifiedBy);
			UDSP_UPDATE_FEE_MASTER.MODIFIED_ON_PARAM(objParameterList , objFeeMaster.ModifiedOn);
			UDSP_UPDATE_FEE_MASTER.RECORD_STATUS_PARAM(objParameterList , objFeeMaster.RecordStatus);
			try
			{
				Logger.LogInfo("FeeMasterDAO.cs : UpdateFeeMaster() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strUpdateFeeMaster, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objFeeMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
					{
						objFeeMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					else
					{
						objFeeMaster.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("FeeMasterDAO.cs : UpdateFeeMaster() is ended with success.");
				}
				else
				{
					objFeeMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("FeeMasterDAO.cs : UpdateFeeMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objFeeMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("FeeMasterDAO.cs : UpdateFeeMaster() is ended with error.");
			}
			return objFeeMaster;
		}

		public FeeMaster ActivateDeactivateFeeMaster(FeeMaster objFeeMaster)
		{
			try
			{
				Logger.LogInfo("FeeMasterDAO.cs : ActivateDeactivateFeeMasterDAO() is started.");
				dbExecuteStatus = DataUtility.ActivateDeactivateObject(strDBTableName, objFeeMaster.FeeId,
										objFeeMaster.Version, objFeeMaster.RecordStatus, objFeeMaster.ModifiedBy);
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objFeeMaster.DbOperationStatus = CommonConstant.SUCCEED;
						Logger.LogInfo("FeeMasterDAO.cs : ActivateDeactivateFeeMaster() is ended with success.");
					}
					else
					{
						objFeeMaster.DbOperationStatus = CommonConstant.INVALID;
						Logger.LogInfo("FeeMasterDAO.cs : ActivateDeactivateFeeMaster() is ended with success.");
					}
				}
				else
				{
					objFeeMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("FeeMasterDAO.cs : ActivateDeactivateFeeMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objFeeMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("FeeMasterDAO.cs : ActivateDeactivateFeeMaster() is ended with error.");
			}
			return objFeeMaster;
		}

		public FeeMaster SelectRecordById(FeeMaster objFeeMaster)
		{
			try
			{
				Logger.LogInfo("FeeMasterDAO.cs : SelectRecordById() is started.");
				objFeeMaster.ObjectDataSet = DataUtility.SelectRecordById(strDBTableName, objFeeMaster.FeeId, objFeeMaster.Version, strSelectFeeMaster);
				if (GeneralUtility.IsInteger(objFeeMaster.ObjectDataSet.Tables[0].Rows[0][0]) && (objFeeMaster.ObjectDataSet.Tables[1].Columns.Count > 1))
				{
					if (Convert.ToInt32(objFeeMaster.ObjectDataSet.Tables[0].Rows[0][0]) > 0)
					{
						objFeeMaster.IsRecordChanged = false;
						objFeeMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objFeeMaster.IsRecordChanged = true;
						objFeeMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					Logger.LogInfo("FeeMasterDAO.cs : SelectRecordById() is ended with success.");
				}
				else
				{
					objFeeMaster.DbOperationStatus = CommonConstant.FAIL;
					dbExecuteStatus = objFeeMaster.ObjectDataSet.Tables[0].Rows[0][0].ToString() + " " + objFeeMaster.ObjectDataSet.Tables[1].Rows[0][0].ToString();
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("FeeMasterDAO.cs : SelectRecordById() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objFeeMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("FeeMasterDAO.cs : SelectRecordById() is ended with error.");
			}
			return objFeeMaster;
		}
	}
}
