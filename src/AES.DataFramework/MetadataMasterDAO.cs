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
	public class MetadataMasterDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "METADATA_MASTER";
		private string strSelectMetadataMaster = "UDSP_SELECT_METADATA_MASTER";
		private string strInsertMetadataMaster = "UDSP_INSERT_METADATA_MASTER";
		private string strUpdateMetadataMaster = "UDSP_UPDATE_METADATA_MASTER";
		private string dbExecuteStatus = "";

		public MetadataMaster SelectMetadataMaster(MetadataMaster objMetadataMaster)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_METADATA_MASTER.METADATA_ID_PARAM(objParameterList , objMetadataMaster.MetadataId);
			if (objMetadataMaster.MetadataTypeObject != null)
			{
				UDSP_SELECT_METADATA_MASTER.METADATA_TYPE_ID_PARAM(objParameterList , objMetadataMaster.MetadataTypeObject.MetadataTypeId);
			}
			UDSP_SELECT_METADATA_MASTER.METADATA_NAME_PARAM(objParameterList , objMetadataMaster.MetadataName);
			UDSP_SELECT_METADATA_MASTER.METADATA_CODE_PARAM(objParameterList , objMetadataMaster.MetadataCode);
			UDSP_SELECT_METADATA_MASTER.IS_SYSTEM_TYPE_PARAM(objParameterList , objMetadataMaster.IsSystemType);
			UDSP_SELECT_METADATA_MASTER.RECORD_STATUS_PARAM(objParameterList , objMetadataMaster.RecordStatus);
			try
			{
				Logger.LogInfo("MetadataMasterDAO.cs : SelectMetadataMaster() is started.");
				objMetadataMaster.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectMetadataMaster, CommandType.StoredProcedure);
				objMetadataMaster.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("MetadataMasterDAO.cs : SelectMetadataMaster() is ended with success.");
			}
			catch (Exception ex)
			{
				objMetadataMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("MetadataMasterDAO.cs : SelectMetadataMaster() is ended with error.");
			}
			return objMetadataMaster;
		}

		public MetadataMaster InsertMetadataMaster(MetadataMaster objMetadataMaster)
		{
						return objMetadataMaster;
		}

		public MetadataMaster UpdateMetadataMaster(MetadataMaster objMetadataMaster)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_UPDATE_METADATA_MASTER.METADATA_ID_PARAM(objParameterList , objMetadataMaster.MetadataId);
			if (objMetadataMaster.MetadataTypeObject != null)
			{
				UDSP_UPDATE_METADATA_MASTER.METADATA_TYPE_ID_PARAM(objParameterList , objMetadataMaster.MetadataTypeObject.MetadataTypeId);
			}
			UDSP_UPDATE_METADATA_MASTER.METADATA_NAME_PARAM(objParameterList , objMetadataMaster.MetadataName);
			UDSP_UPDATE_METADATA_MASTER.METADATA_CODE_PARAM(objParameterList , objMetadataMaster.MetadataCode);
			UDSP_UPDATE_METADATA_MASTER.IS_SYSTEM_TYPE_PARAM(objParameterList , objMetadataMaster.IsSystemType);
			UDSP_UPDATE_METADATA_MASTER.VERSION_PARAM(objParameterList , objMetadataMaster.Version);
			UDSP_UPDATE_METADATA_MASTER.CREATED_BY_PARAM(objParameterList , objMetadataMaster.CreatedBy);
			UDSP_UPDATE_METADATA_MASTER.CREATED_ON_PARAM(objParameterList , objMetadataMaster.CreatedOn);
			UDSP_UPDATE_METADATA_MASTER.MODIFIED_BY_PARAM(objParameterList , objMetadataMaster.ModifiedBy);
			UDSP_UPDATE_METADATA_MASTER.MODIFIED_ON_PARAM(objParameterList , objMetadataMaster.ModifiedOn);
			UDSP_UPDATE_METADATA_MASTER.RECORD_STATUS_PARAM(objParameterList , objMetadataMaster.RecordStatus);
			try
			{
				Logger.LogInfo("MetadataMasterDAO.cs : UpdateMetadataMaster() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strUpdateMetadataMaster, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objMetadataMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
					{
						objMetadataMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					else
					{
						objMetadataMaster.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("MetadataMasterDAO.cs : UpdateMetadataMaster() is ended with success.");
				}
				else
				{
					objMetadataMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("MetadataMasterDAO.cs : UpdateMetadataMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objMetadataMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("MetadataMasterDAO.cs : UpdateMetadataMaster() is ended with error.");
			}
			return objMetadataMaster;
		}

		public MetadataMaster ActivateDeactivateMetadataMaster(MetadataMaster objMetadataMaster)
		{
			try
			{
				Logger.LogInfo("MetadataMasterDAO.cs : ActivateDeactivateMetadataMasterDAO() is started.");
				dbExecuteStatus = DataUtility.ActivateDeactivateObject(strDBTableName, objMetadataMaster.MetadataId,
										objMetadataMaster.Version, objMetadataMaster.RecordStatus, objMetadataMaster.ModifiedBy);
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objMetadataMaster.DbOperationStatus = CommonConstant.SUCCEED;
						Logger.LogInfo("MetadataMasterDAO.cs : ActivateDeactivateMetadataMaster() is ended with success.");
					}
					else
					{
						objMetadataMaster.DbOperationStatus = CommonConstant.INVALID;
						Logger.LogInfo("MetadataMasterDAO.cs : ActivateDeactivateMetadataMaster() is ended with success.");
					}
				}
				else
				{
					objMetadataMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("MetadataMasterDAO.cs : ActivateDeactivateMetadataMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objMetadataMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("MetadataMasterDAO.cs : ActivateDeactivateMetadataMaster() is ended with error.");
			}
			return objMetadataMaster;
		}

		public MetadataMaster SelectRecordById(MetadataMaster objMetadataMaster)
		{
			try
			{
				Logger.LogInfo("MetadataMasterDAO.cs : SelectRecordById() is started.");
				objMetadataMaster.ObjectDataSet = DataUtility.SelectRecordById(strDBTableName, objMetadataMaster.MetadataId, objMetadataMaster.Version, strSelectMetadataMaster);
				if (GeneralUtility.IsInteger(objMetadataMaster.ObjectDataSet.Tables[0].Rows[0][0]) && (objMetadataMaster.ObjectDataSet.Tables[1].Columns.Count > 1))
				{
					if (Convert.ToInt32(objMetadataMaster.ObjectDataSet.Tables[0].Rows[0][0]) > 0)
					{
						objMetadataMaster.IsRecordChanged = false;
						objMetadataMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objMetadataMaster.IsRecordChanged = true;
						objMetadataMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					Logger.LogInfo("MetadataMasterDAO.cs : SelectRecordById() is ended with success.");
				}
				else
				{
					objMetadataMaster.DbOperationStatus = CommonConstant.FAIL;
					dbExecuteStatus = objMetadataMaster.ObjectDataSet.Tables[0].Rows[0][0].ToString() + " " + objMetadataMaster.ObjectDataSet.Tables[1].Rows[0][0].ToString();
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("MetadataMasterDAO.cs : SelectRecordById() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objMetadataMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("MetadataMasterDAO.cs : SelectRecordById() is ended with error.");
			}
			return objMetadataMaster;
		}
	}
}
