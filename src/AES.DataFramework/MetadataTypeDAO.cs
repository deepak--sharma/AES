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
	public class MetadataTypeDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "METADATA_TYPE";
		private string strSelectMetadataType = "UDSP_SELECT_METADATA_TYPE";
		private string strInsertMetadataType = "UDSP_INSERT_METADATA_TYPE";
		private string strUpdateMetadataType = "UDSP_UPDATE_METADATA_TYPE";
		private string dbExecuteStatus = "";

		public MetadataType SelectMetadataType(MetadataType objMetadataType)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_METADATA_TYPE.METADATA_TYPE_ID_PARAM(objParameterList , objMetadataType.MetadataTypeId);
			UDSP_SELECT_METADATA_TYPE.METADATA_TYPE_NAME_PARAM(objParameterList , objMetadataType.MetadataTypeName);
			UDSP_SELECT_METADATA_TYPE.RECORD_STATUS_PARAM(objParameterList , objMetadataType.RecordStatus);
			try
			{
				Logger.LogInfo("MetadataTypeDAO.cs : SelectMetadataType() is started.");
				objMetadataType.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectMetadataType, CommandType.StoredProcedure);
				objMetadataType.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("MetadataTypeDAO.cs : SelectMetadataType() is ended with success.");
			}
			catch (Exception ex)
			{
				objMetadataType.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("MetadataTypeDAO.cs : SelectMetadataType() is ended with error.");
			}
			return objMetadataType;
		}

		public MetadataType InsertMetadataType(MetadataType objMetadataType)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_INSERT_METADATA_TYPE.METADATA_TYPE_NAME_PARAM(objParameterList , objMetadataType.MetadataTypeName);
			UDSP_INSERT_METADATA_TYPE.VERSION_PARAM(objParameterList , objMetadataType.Version);
			UDSP_INSERT_METADATA_TYPE.CREATED_BY_PARAM(objParameterList , objMetadataType.CreatedBy);
			UDSP_INSERT_METADATA_TYPE.CREATED_ON_PARAM(objParameterList , objMetadataType.CreatedOn);
			UDSP_INSERT_METADATA_TYPE.MODIFIED_BY_PARAM(objParameterList , objMetadataType.ModifiedBy);
			UDSP_INSERT_METADATA_TYPE.MODIFIED_ON_PARAM(objParameterList , objMetadataType.ModifiedOn);
			UDSP_INSERT_METADATA_TYPE.RECORD_STATUS_PARAM(objParameterList , objMetadataType.RecordStatus);
			try
			{
				Logger.LogInfo("MetadataTypeDAO.cs : InsertMetadataType() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strInsertMetadataType, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) > 0 )
					{
						objMetadataType.MetadataTypeId = Convert.ToInt32(dbExecuteStatus);
						objMetadataType.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objMetadataType.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("MetadataTypeDAO.cs : InsertMetadataType() is ended with success.");
				}
				else
				{
					objMetadataType.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("MetadataTypeDAO.cs : InsertMetadataType() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objMetadataType.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("MetadataTypeDAO.cs : InsertMetadataType() is ended with error.");
			}
			return objMetadataType;
		}

		public MetadataType UpdateMetadataType(MetadataType objMetadataType)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_UPDATE_METADATA_TYPE.METADATA_TYPE_ID_PARAM(objParameterList , objMetadataType.MetadataTypeId);
			UDSP_UPDATE_METADATA_TYPE.METADATA_TYPE_NAME_PARAM(objParameterList , objMetadataType.MetadataTypeName);
			UDSP_UPDATE_METADATA_TYPE.VERSION_PARAM(objParameterList , objMetadataType.Version);
			UDSP_UPDATE_METADATA_TYPE.CREATED_BY_PARAM(objParameterList , objMetadataType.CreatedBy);
			UDSP_UPDATE_METADATA_TYPE.CREATED_ON_PARAM(objParameterList , objMetadataType.CreatedOn);
			UDSP_UPDATE_METADATA_TYPE.MODIFIED_BY_PARAM(objParameterList , objMetadataType.ModifiedBy);
			UDSP_UPDATE_METADATA_TYPE.MODIFIED_ON_PARAM(objParameterList , objMetadataType.ModifiedOn);
			UDSP_UPDATE_METADATA_TYPE.RECORD_STATUS_PARAM(objParameterList , objMetadataType.RecordStatus);
			try
			{
				Logger.LogInfo("MetadataTypeDAO.cs : UpdateMetadataType() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strUpdateMetadataType, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objMetadataType.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
					{
						objMetadataType.DbOperationStatus = CommonConstant.INVALID;
					}
					else
					{
						objMetadataType.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("MetadataTypeDAO.cs : UpdateMetadataType() is ended with success.");
				}
				else
				{
					objMetadataType.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("MetadataTypeDAO.cs : UpdateMetadataType() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objMetadataType.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("MetadataTypeDAO.cs : UpdateMetadataType() is ended with error.");
			}
			return objMetadataType;
		}

		public MetadataType ActivateDeactivateMetadataType(MetadataType objMetadataType)
		{
			try
			{
				Logger.LogInfo("MetadataTypeDAO.cs : ActivateDeactivateMetadataTypeDAO() is started.");
				dbExecuteStatus = DataUtility.ActivateDeactivateObject(strDBTableName, objMetadataType.MetadataTypeId,
										objMetadataType.Version, objMetadataType.RecordStatus, objMetadataType.ModifiedBy);
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objMetadataType.DbOperationStatus = CommonConstant.SUCCEED;
						Logger.LogInfo("MetadataTypeDAO.cs : ActivateDeactivateMetadataType() is ended with success.");
					}
					else
					{
						objMetadataType.DbOperationStatus = CommonConstant.INVALID;
						Logger.LogInfo("MetadataTypeDAO.cs : ActivateDeactivateMetadataType() is ended with success.");
					}
				}
				else
				{
					objMetadataType.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("MetadataTypeDAO.cs : ActivateDeactivateMetadataType() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objMetadataType.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("MetadataTypeDAO.cs : ActivateDeactivateMetadataType() is ended with error.");
			}
			return objMetadataType;
		}

		public MetadataType SelectRecordById(MetadataType objMetadataType)
		{
			try
			{
				Logger.LogInfo("MetadataTypeDAO.cs : SelectRecordById() is started.");
				objMetadataType.ObjectDataSet = DataUtility.SelectRecordById(strDBTableName, objMetadataType.MetadataTypeId, objMetadataType.Version, strSelectMetadataType);
				if (GeneralUtility.IsInteger(objMetadataType.ObjectDataSet.Tables[0].Rows[0][0]) && (objMetadataType.ObjectDataSet.Tables[1].Columns.Count > 1))
				{
					if (Convert.ToInt32(objMetadataType.ObjectDataSet.Tables[0].Rows[0][0]) > 0)
					{
						objMetadataType.IsRecordChanged = false;
						objMetadataType.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objMetadataType.IsRecordChanged = true;
						objMetadataType.DbOperationStatus = CommonConstant.INVALID;
					}
					Logger.LogInfo("MetadataTypeDAO.cs : SelectRecordById() is ended with success.");
				}
				else
				{
					objMetadataType.DbOperationStatus = CommonConstant.FAIL;
					dbExecuteStatus = objMetadataType.ObjectDataSet.Tables[0].Rows[0][0].ToString() + " " + objMetadataType.ObjectDataSet.Tables[1].Rows[0][0].ToString();
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("MetadataTypeDAO.cs : SelectRecordById() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objMetadataType.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("MetadataTypeDAO.cs : SelectRecordById() is ended with error.");
			}
			return objMetadataType;
		}
	}
}
