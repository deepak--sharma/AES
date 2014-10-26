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
	public class ItemMasterDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "ITEM_MASTER";
		private string strSelectItemMaster = "UDSP_SELECT_ITEM_MASTER";
		private string strInsertItemMaster = "UDSP_INSERT_ITEM_MASTER";
		private string strUpdateItemMaster = "UDSP_UPDATE_ITEM_MASTER";
		private string dbExecuteStatus = "";

		public ItemMaster SelectItemMaster(ItemMaster objItemMaster)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_ITEM_MASTER.ITEM_ID_PARAM(objParameterList , objItemMaster.ItemId);
			UDSP_SELECT_ITEM_MASTER.ITEM_CODE_PARAM(objParameterList , objItemMaster.ItemCode);
			UDSP_SELECT_ITEM_MASTER.BAR_CODE_PARAM(objParameterList , objItemMaster.BarCode);
			if (objItemMaster.ClassSubjectObject != null)
			{
				UDSP_SELECT_ITEM_MASTER.CLASS_SUBJECT_ID_PARAM(objParameterList , objItemMaster.ClassSubjectObject.ClassSubjectMappingId);
			}
			UDSP_SELECT_ITEM_MASTER.WRITER_NAME_PARAM(objParameterList , objItemMaster.WriterName);
			UDSP_SELECT_ITEM_MASTER.PUBLISHER_NAME_PARAM(objParameterList , objItemMaster.PublisherName);
			if (objItemMaster.MediumObject != null)
			{
				UDSP_SELECT_ITEM_MASTER.MEDIUM_ID_PARAM(objParameterList , objItemMaster.MediumObject.MetadataId);
			}
			UDSP_SELECT_ITEM_MASTER.EDITION_PARAM(objParameterList , objItemMaster.Edition);
			UDSP_SELECT_ITEM_MASTER.PUBLISH_DATE_PARAM(objParameterList , objItemMaster.PublishDate);
			UDSP_SELECT_ITEM_MASTER.VOLUME_PARAM(objParameterList , objItemMaster.Volume);
			if (objItemMaster.RackObject != null)
			{
				UDSP_SELECT_ITEM_MASTER.RACK_ID_PARAM(objParameterList , objItemMaster.RackObject.RackId);
			}
			UDSP_SELECT_ITEM_MASTER.CELL_ID_PARAM(objParameterList , objItemMaster.CellId);
			if (objItemMaster.ItemTypeObject != null)
			{
				UDSP_SELECT_ITEM_MASTER.ITEM_TYPE_ID_PARAM(objParameterList , objItemMaster.ItemTypeObject.ItemTypeId);
			}
			UDSP_SELECT_ITEM_MASTER.RECORD_STATUS_PARAM(objParameterList , objItemMaster.RecordStatus);
			try
			{
				Logger.LogInfo("ItemMasterDAO.cs : SelectItemMaster() is started.");
				objItemMaster.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectItemMaster, CommandType.StoredProcedure);
				objItemMaster.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("ItemMasterDAO.cs : SelectItemMaster() is ended with success.");
			}
			catch (Exception ex)
			{
				objItemMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("ItemMasterDAO.cs : SelectItemMaster() is ended with error.");
			}
			return objItemMaster;
		}

		public ItemMaster InsertItemMaster(ItemMaster objItemMaster)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_INSERT_ITEM_MASTER.ITEM_CODE_PARAM(objParameterList , objItemMaster.ItemCode);
			UDSP_INSERT_ITEM_MASTER.BAR_CODE_PARAM(objParameterList , objItemMaster.BarCode);
			if (objItemMaster.ClassSubjectObject != null)
			{
				UDSP_INSERT_ITEM_MASTER.CLASS_SUBJECT_ID_PARAM(objParameterList , objItemMaster.ClassSubjectObject.ClassSubjectMappingId);
			}
			UDSP_INSERT_ITEM_MASTER.WRITER_NAME_PARAM(objParameterList , objItemMaster.WriterName);
			UDSP_INSERT_ITEM_MASTER.PUBLISHER_NAME_PARAM(objParameterList , objItemMaster.PublisherName);
			if (objItemMaster.MediumObject != null)
			{
				UDSP_INSERT_ITEM_MASTER.MEDIUM_ID_PARAM(objParameterList , objItemMaster.MediumObject.MetadataId);
			}
			UDSP_INSERT_ITEM_MASTER.EDITION_PARAM(objParameterList , objItemMaster.Edition);
			UDSP_INSERT_ITEM_MASTER.PUBLISH_DATE_PARAM(objParameterList , objItemMaster.PublishDate);
			UDSP_INSERT_ITEM_MASTER.VOLUME_PARAM(objParameterList , objItemMaster.Volume);
			if (objItemMaster.RackObject != null)
			{
				UDSP_INSERT_ITEM_MASTER.RACK_ID_PARAM(objParameterList , objItemMaster.RackObject.RackId);
			}
			UDSP_INSERT_ITEM_MASTER.CELL_ID_PARAM(objParameterList , objItemMaster.CellId);
			if (objItemMaster.ItemTypeObject != null)
			{
				UDSP_INSERT_ITEM_MASTER.ITEM_TYPE_ID_PARAM(objParameterList , objItemMaster.ItemTypeObject.ItemTypeId);
			}
			UDSP_INSERT_ITEM_MASTER.VERSION_PARAM(objParameterList , objItemMaster.Version);
			UDSP_INSERT_ITEM_MASTER.CREATED_BY_PARAM(objParameterList , objItemMaster.CreatedBy);
			UDSP_INSERT_ITEM_MASTER.CREATED_ON_PARAM(objParameterList , objItemMaster.CreatedOn);
			UDSP_INSERT_ITEM_MASTER.MODIFIED_BY_PARAM(objParameterList , objItemMaster.ModifiedBy);
			UDSP_INSERT_ITEM_MASTER.MODIFIED_ON_PARAM(objParameterList , objItemMaster.ModifiedOn);
			UDSP_INSERT_ITEM_MASTER.RECORD_STATUS_PARAM(objParameterList , objItemMaster.RecordStatus);
			try
			{
				Logger.LogInfo("ItemMasterDAO.cs : InsertItemMaster() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strInsertItemMaster, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) > 0 )
					{
						objItemMaster.ItemId = Convert.ToInt32(dbExecuteStatus);
						objItemMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objItemMaster.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("ItemMasterDAO.cs : InsertItemMaster() is ended with success.");
				}
				else
				{
					objItemMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("ItemMasterDAO.cs : InsertItemMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objItemMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("ItemMasterDAO.cs : InsertItemMaster() is ended with error.");
			}
			return objItemMaster;
		}

		public ItemMaster UpdateItemMaster(ItemMaster objItemMaster)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_UPDATE_ITEM_MASTER.ITEM_ID_PARAM(objParameterList , objItemMaster.ItemId);
			UDSP_UPDATE_ITEM_MASTER.ITEM_CODE_PARAM(objParameterList , objItemMaster.ItemCode);
			UDSP_UPDATE_ITEM_MASTER.BAR_CODE_PARAM(objParameterList , objItemMaster.BarCode);
			if (objItemMaster.ClassSubjectObject != null)
			{
				UDSP_UPDATE_ITEM_MASTER.CLASS_SUBJECT_ID_PARAM(objParameterList , objItemMaster.ClassSubjectObject.ClassSubjectMappingId);
			}
			UDSP_UPDATE_ITEM_MASTER.WRITER_NAME_PARAM(objParameterList , objItemMaster.WriterName);
			UDSP_UPDATE_ITEM_MASTER.PUBLISHER_NAME_PARAM(objParameterList , objItemMaster.PublisherName);
			if (objItemMaster.MediumObject != null)
			{
				UDSP_UPDATE_ITEM_MASTER.MEDIUM_ID_PARAM(objParameterList , objItemMaster.MediumObject.MetadataId);
			}
			UDSP_UPDATE_ITEM_MASTER.EDITION_PARAM(objParameterList , objItemMaster.Edition);
			UDSP_UPDATE_ITEM_MASTER.PUBLISH_DATE_PARAM(objParameterList , objItemMaster.PublishDate);
			UDSP_UPDATE_ITEM_MASTER.VOLUME_PARAM(objParameterList , objItemMaster.Volume);
			if (objItemMaster.RackObject != null)
			{
				UDSP_UPDATE_ITEM_MASTER.RACK_ID_PARAM(objParameterList , objItemMaster.RackObject.RackId);
			}
			UDSP_UPDATE_ITEM_MASTER.CELL_ID_PARAM(objParameterList , objItemMaster.CellId);
			if (objItemMaster.ItemTypeObject != null)
			{
				UDSP_UPDATE_ITEM_MASTER.ITEM_TYPE_ID_PARAM(objParameterList , objItemMaster.ItemTypeObject.ItemTypeId);
			}
			UDSP_UPDATE_ITEM_MASTER.VERSION_PARAM(objParameterList , objItemMaster.Version);
			UDSP_UPDATE_ITEM_MASTER.CREATED_BY_PARAM(objParameterList , objItemMaster.CreatedBy);
			UDSP_UPDATE_ITEM_MASTER.CREATED_ON_PARAM(objParameterList , objItemMaster.CreatedOn);
			UDSP_UPDATE_ITEM_MASTER.MODIFIED_BY_PARAM(objParameterList , objItemMaster.ModifiedBy);
			UDSP_UPDATE_ITEM_MASTER.MODIFIED_ON_PARAM(objParameterList , objItemMaster.ModifiedOn);
			UDSP_UPDATE_ITEM_MASTER.RECORD_STATUS_PARAM(objParameterList , objItemMaster.RecordStatus);
			try
			{
				Logger.LogInfo("ItemMasterDAO.cs : UpdateItemMaster() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strUpdateItemMaster, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objItemMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
					{
						objItemMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					else
					{
						objItemMaster.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("ItemMasterDAO.cs : UpdateItemMaster() is ended with success.");
				}
				else
				{
					objItemMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("ItemMasterDAO.cs : UpdateItemMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objItemMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("ItemMasterDAO.cs : UpdateItemMaster() is ended with error.");
			}
			return objItemMaster;
		}

		public ItemMaster ActivateDeactivateItemMaster(ItemMaster objItemMaster)
		{
			try
			{
				Logger.LogInfo("ItemMasterDAO.cs : ActivateDeactivateItemMasterDAO() is started.");
				dbExecuteStatus = DataUtility.ActivateDeactivateObject(strDBTableName, objItemMaster.ItemId,
										objItemMaster.Version, objItemMaster.RecordStatus, objItemMaster.ModifiedBy);
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objItemMaster.DbOperationStatus = CommonConstant.SUCCEED;
						Logger.LogInfo("ItemMasterDAO.cs : ActivateDeactivateItemMaster() is ended with success.");
					}
					else
					{
						objItemMaster.DbOperationStatus = CommonConstant.INVALID;
						Logger.LogInfo("ItemMasterDAO.cs : ActivateDeactivateItemMaster() is ended with success.");
					}
				}
				else
				{
					objItemMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("ItemMasterDAO.cs : ActivateDeactivateItemMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objItemMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("ItemMasterDAO.cs : ActivateDeactivateItemMaster() is ended with error.");
			}
			return objItemMaster;
		}

		public ItemMaster SelectRecordById(ItemMaster objItemMaster)
		{
			try
			{
				Logger.LogInfo("ItemMasterDAO.cs : SelectRecordById() is started.");
				objItemMaster.ObjectDataSet = DataUtility.SelectRecordById(strDBTableName, objItemMaster.ItemId, objItemMaster.Version, strSelectItemMaster);
				if (GeneralUtility.IsInteger(objItemMaster.ObjectDataSet.Tables[0].Rows[0][0]) && (objItemMaster.ObjectDataSet.Tables[1].Columns.Count > 1))
				{
					if (Convert.ToInt32(objItemMaster.ObjectDataSet.Tables[0].Rows[0][0]) > 0)
					{
						objItemMaster.IsRecordChanged = false;
						objItemMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objItemMaster.IsRecordChanged = true;
						objItemMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					Logger.LogInfo("ItemMasterDAO.cs : SelectRecordById() is ended with success.");
				}
				else
				{
					objItemMaster.DbOperationStatus = CommonConstant.FAIL;
					dbExecuteStatus = objItemMaster.ObjectDataSet.Tables[0].Rows[0][0].ToString() + " " + objItemMaster.ObjectDataSet.Tables[1].Rows[0][0].ToString();
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("ItemMasterDAO.cs : SelectRecordById() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objItemMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("ItemMasterDAO.cs : SelectRecordById() is ended with error.");
			}
			return objItemMaster;
		}
	}
}
