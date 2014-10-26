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
	public class ItemTypeDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "ITEM_TYPE";
		private string strSelectItemType = "UDSP_SELECT_ITEM_TYPE";
		private string strInsertItemType = "UDSP_INSERT_ITEM_TYPE";
		private string strUpdateItemType = "UDSP_UPDATE_ITEM_TYPE";
		private string dbExecuteStatus = "";

		public ItemType SelectItemType(ItemType objItemType)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_ITEM_TYPE.ITEM_TYPE_ID_PARAM(objParameterList , objItemType.ItemTypeId);
			UDSP_SELECT_ITEM_TYPE.ITEM_TYPE_NAME_PARAM(objParameterList , objItemType.ItemTypeName);
			UDSP_SELECT_ITEM_TYPE.ORDER_BY_FIELDS_PARAM(objParameterList , objItemType.OrderByFields);
			UDSP_SELECT_ITEM_TYPE.DESCRIPTION_PARAM(objParameterList , objItemType.Description);
			UDSP_SELECT_ITEM_TYPE.RECORD_STATUS_PARAM(objParameterList , objItemType.RecordStatus);
			try
			{
				Logger.LogInfo("ItemTypeDAO.cs : SelectItemType() is started.");
				objItemType.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectItemType, CommandType.StoredProcedure);
				objItemType.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("ItemTypeDAO.cs : SelectItemType() is ended with success.");
			}
			catch (Exception ex)
			{
				objItemType.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("ItemTypeDAO.cs : SelectItemType() is ended with error.");
			}
			return objItemType;
		}

		public ItemType InsertItemType(ItemType objItemType)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_INSERT_ITEM_TYPE.ITEM_TYPE_NAME_PARAM(objParameterList , objItemType.ItemTypeName);
			UDSP_INSERT_ITEM_TYPE.ORDER_BY_FIELDS_PARAM(objParameterList , objItemType.OrderByFields);
			UDSP_INSERT_ITEM_TYPE.DESCRIPTION_PARAM(objParameterList , objItemType.Description);
			UDSP_INSERT_ITEM_TYPE.VERSION_PARAM(objParameterList , objItemType.Version);
			UDSP_INSERT_ITEM_TYPE.CREATED_BY_PARAM(objParameterList , objItemType.CreatedBy);
			UDSP_INSERT_ITEM_TYPE.CREATED_ON_PARAM(objParameterList , objItemType.CreatedOn);
			UDSP_INSERT_ITEM_TYPE.MODIFIED_BY_PARAM(objParameterList , objItemType.ModifiedBy);
			UDSP_INSERT_ITEM_TYPE.MODIFIED_ON_PARAM(objParameterList , objItemType.ModifiedOn);
			UDSP_INSERT_ITEM_TYPE.RECORD_STATUS_PARAM(objParameterList , objItemType.RecordStatus);
			try
			{
				Logger.LogInfo("ItemTypeDAO.cs : InsertItemType() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strInsertItemType, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) > 0 )
					{
						objItemType.ItemTypeId = Convert.ToInt32(dbExecuteStatus);
						objItemType.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objItemType.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("ItemTypeDAO.cs : InsertItemType() is ended with success.");
				}
				else
				{
					objItemType.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("ItemTypeDAO.cs : InsertItemType() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objItemType.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("ItemTypeDAO.cs : InsertItemType() is ended with error.");
			}
			return objItemType;
		}

		public ItemType UpdateItemType(ItemType objItemType)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_UPDATE_ITEM_TYPE.ITEM_TYPE_ID_PARAM(objParameterList , objItemType.ItemTypeId);
			UDSP_UPDATE_ITEM_TYPE.ITEM_TYPE_NAME_PARAM(objParameterList , objItemType.ItemTypeName);
			UDSP_UPDATE_ITEM_TYPE.ORDER_BY_FIELDS_PARAM(objParameterList , objItemType.OrderByFields);
			UDSP_UPDATE_ITEM_TYPE.DESCRIPTION_PARAM(objParameterList , objItemType.Description);
			UDSP_UPDATE_ITEM_TYPE.VERSION_PARAM(objParameterList , objItemType.Version);
			UDSP_UPDATE_ITEM_TYPE.CREATED_BY_PARAM(objParameterList , objItemType.CreatedBy);
			UDSP_UPDATE_ITEM_TYPE.CREATED_ON_PARAM(objParameterList , objItemType.CreatedOn);
			UDSP_UPDATE_ITEM_TYPE.MODIFIED_BY_PARAM(objParameterList , objItemType.ModifiedBy);
			UDSP_UPDATE_ITEM_TYPE.MODIFIED_ON_PARAM(objParameterList , objItemType.ModifiedOn);
			UDSP_UPDATE_ITEM_TYPE.RECORD_STATUS_PARAM(objParameterList , objItemType.RecordStatus);
			try
			{
				Logger.LogInfo("ItemTypeDAO.cs : UpdateItemType() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strUpdateItemType, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objItemType.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
					{
						objItemType.DbOperationStatus = CommonConstant.INVALID;
					}
					else
					{
						objItemType.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("ItemTypeDAO.cs : UpdateItemType() is ended with success.");
				}
				else
				{
					objItemType.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("ItemTypeDAO.cs : UpdateItemType() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objItemType.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("ItemTypeDAO.cs : UpdateItemType() is ended with error.");
			}
			return objItemType;
		}

		public ItemType ActivateDeactivateItemType(ItemType objItemType)
		{
			try
			{
				Logger.LogInfo("ItemTypeDAO.cs : ActivateDeactivateItemTypeDAO() is started.");
				dbExecuteStatus = DataUtility.ActivateDeactivateObject(strDBTableName, objItemType.ItemTypeId,
										objItemType.Version, objItemType.RecordStatus, objItemType.ModifiedBy);
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objItemType.DbOperationStatus = CommonConstant.SUCCEED;
						Logger.LogInfo("ItemTypeDAO.cs : ActivateDeactivateItemType() is ended with success.");
					}
					else
					{
						objItemType.DbOperationStatus = CommonConstant.INVALID;
						Logger.LogInfo("ItemTypeDAO.cs : ActivateDeactivateItemType() is ended with success.");
					}
				}
				else
				{
					objItemType.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("ItemTypeDAO.cs : ActivateDeactivateItemType() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objItemType.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("ItemTypeDAO.cs : ActivateDeactivateItemType() is ended with error.");
			}
			return objItemType;
		}

		public ItemType SelectRecordById(ItemType objItemType)
		{
			try
			{
				Logger.LogInfo("ItemTypeDAO.cs : SelectRecordById() is started.");
				objItemType.ObjectDataSet = DataUtility.SelectRecordById(strDBTableName, objItemType.ItemTypeId, objItemType.Version, strSelectItemType);
				if (GeneralUtility.IsInteger(objItemType.ObjectDataSet.Tables[0].Rows[0][0]) && (objItemType.ObjectDataSet.Tables[1].Columns.Count > 1))
				{
					if (Convert.ToInt32(objItemType.ObjectDataSet.Tables[0].Rows[0][0]) > 0)
					{
						objItemType.IsRecordChanged = false;
						objItemType.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objItemType.IsRecordChanged = true;
						objItemType.DbOperationStatus = CommonConstant.INVALID;
					}
					Logger.LogInfo("ItemTypeDAO.cs : SelectRecordById() is ended with success.");
				}
				else
				{
					objItemType.DbOperationStatus = CommonConstant.FAIL;
					dbExecuteStatus = objItemType.ObjectDataSet.Tables[0].Rows[0][0].ToString() + " " + objItemType.ObjectDataSet.Tables[1].Rows[0][0].ToString();
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("ItemTypeDAO.cs : SelectRecordById() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objItemType.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("ItemTypeDAO.cs : SelectRecordById() is ended with error.");
			}
			return objItemType;
		}
	}
}
