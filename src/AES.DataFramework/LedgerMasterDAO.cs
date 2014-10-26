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
	public class LedgerMasterDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "LEDGER_MASTER";
		private string strSelectLedgerMaster = "UDSP_SELECT_LEDGER_MASTER";
		private string strInsertLedgerMaster = "UDSP_INSERT_LEDGER_MASTER";
		private string strUpdateLedgerMaster = "UDSP_UPDATE_LEDGER_MASTER";
		private string dbExecuteStatus = "";

		public LedgerMaster SelectLedgerMaster(LedgerMaster objLedgerMaster)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_LEDGER_MASTER.LEDGER_ID_PARAM(objParameterList , objLedgerMaster.LedgerId);
			UDSP_SELECT_LEDGER_MASTER.LEDGER_NAME_PARAM(objParameterList , objLedgerMaster.LedgerName);
			if (objLedgerMaster.GroupObject != null)
			{
				UDSP_SELECT_LEDGER_MASTER.GROUP_ID_PARAM(objParameterList , objLedgerMaster.GroupObject.GroupId);
			}
			UDSP_SELECT_LEDGER_MASTER.OPENING_BALANCE_PARAM(objParameterList , objLedgerMaster.OpeningBalance);
			UDSP_SELECT_LEDGER_MASTER.OPENING_DATE_PARAM(objParameterList , objLedgerMaster.OpeningDate);
			UDSP_SELECT_LEDGER_MASTER.DR_CR_PARAM(objParameterList , objLedgerMaster.DrCr);
			UDSP_SELECT_LEDGER_MASTER.ON_DATE_PARAM(objParameterList , objLedgerMaster.OnDate);
			UDSP_SELECT_LEDGER_MASTER.DESCRIPTION_PARAM(objParameterList , objLedgerMaster.Description);
			UDSP_SELECT_LEDGER_MASTER.RECORD_STATUS_PARAM(objParameterList , objLedgerMaster.RecordStatus);
			try
			{
				Logger.LogInfo("LedgerMasterDAO.cs : SelectLedgerMaster() is started.");
				objLedgerMaster.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectLedgerMaster, CommandType.StoredProcedure);
				objLedgerMaster.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("LedgerMasterDAO.cs : SelectLedgerMaster() is ended with success.");
			}
			catch (Exception ex)
			{
				objLedgerMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("LedgerMasterDAO.cs : SelectLedgerMaster() is ended with error.");
			}
			return objLedgerMaster;
		}

		public LedgerMaster InsertLedgerMaster(LedgerMaster objLedgerMaster)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_INSERT_LEDGER_MASTER.LEDGER_NAME_PARAM(objParameterList , objLedgerMaster.LedgerName);
			if (objLedgerMaster.GroupObject != null)
			{
				UDSP_INSERT_LEDGER_MASTER.GROUP_ID_PARAM(objParameterList , objLedgerMaster.GroupObject.GroupId);
			}
			UDSP_INSERT_LEDGER_MASTER.OPENING_BALANCE_PARAM(objParameterList , objLedgerMaster.OpeningBalance);
			UDSP_INSERT_LEDGER_MASTER.OPENING_DATE_PARAM(objParameterList , objLedgerMaster.OpeningDate);
			UDSP_INSERT_LEDGER_MASTER.DR_CR_PARAM(objParameterList , objLedgerMaster.DrCr);
			UDSP_INSERT_LEDGER_MASTER.ON_DATE_PARAM(objParameterList , objLedgerMaster.OnDate);
			UDSP_INSERT_LEDGER_MASTER.DESCRIPTION_PARAM(objParameterList , objLedgerMaster.Description);
			UDSP_INSERT_LEDGER_MASTER.VERSION_PARAM(objParameterList , objLedgerMaster.Version);
			UDSP_INSERT_LEDGER_MASTER.CREATED_BY_PARAM(objParameterList , objLedgerMaster.CreatedBy);
			UDSP_INSERT_LEDGER_MASTER.CREATED_ON_PARAM(objParameterList , objLedgerMaster.CreatedOn);
			UDSP_INSERT_LEDGER_MASTER.MODIFIED_BY_PARAM(objParameterList , objLedgerMaster.ModifiedBy);
			UDSP_INSERT_LEDGER_MASTER.MODIFIED_ON_PARAM(objParameterList , objLedgerMaster.ModifiedOn);
			UDSP_INSERT_LEDGER_MASTER.RECORD_STATUS_PARAM(objParameterList , objLedgerMaster.RecordStatus);
			try
			{
				Logger.LogInfo("LedgerMasterDAO.cs : InsertLedgerMaster() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strInsertLedgerMaster, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) > 0 )
					{
						objLedgerMaster.LedgerId = Convert.ToInt32(dbExecuteStatus);
						objLedgerMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objLedgerMaster.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("LedgerMasterDAO.cs : InsertLedgerMaster() is ended with success.");
				}
				else
				{
					objLedgerMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("LedgerMasterDAO.cs : InsertLedgerMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objLedgerMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("LedgerMasterDAO.cs : InsertLedgerMaster() is ended with error.");
			}
			return objLedgerMaster;
		}

		public LedgerMaster UpdateLedgerMaster(LedgerMaster objLedgerMaster)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_UPDATE_LEDGER_MASTER.LEDGER_ID_PARAM(objParameterList , objLedgerMaster.LedgerId);
			UDSP_UPDATE_LEDGER_MASTER.LEDGER_NAME_PARAM(objParameterList , objLedgerMaster.LedgerName);
			if (objLedgerMaster.GroupObject != null)
			{
				UDSP_UPDATE_LEDGER_MASTER.GROUP_ID_PARAM(objParameterList , objLedgerMaster.GroupObject.GroupId);
			}
			UDSP_UPDATE_LEDGER_MASTER.OPENING_BALANCE_PARAM(objParameterList , objLedgerMaster.OpeningBalance);
			UDSP_UPDATE_LEDGER_MASTER.OPENING_DATE_PARAM(objParameterList , objLedgerMaster.OpeningDate);
			UDSP_UPDATE_LEDGER_MASTER.DR_CR_PARAM(objParameterList , objLedgerMaster.DrCr);
			UDSP_UPDATE_LEDGER_MASTER.ON_DATE_PARAM(objParameterList , objLedgerMaster.OnDate);
			UDSP_UPDATE_LEDGER_MASTER.DESCRIPTION_PARAM(objParameterList , objLedgerMaster.Description);
			UDSP_UPDATE_LEDGER_MASTER.VERSION_PARAM(objParameterList , objLedgerMaster.Version);
			UDSP_UPDATE_LEDGER_MASTER.CREATED_BY_PARAM(objParameterList , objLedgerMaster.CreatedBy);
			UDSP_UPDATE_LEDGER_MASTER.CREATED_ON_PARAM(objParameterList , objLedgerMaster.CreatedOn);
			UDSP_UPDATE_LEDGER_MASTER.MODIFIED_BY_PARAM(objParameterList , objLedgerMaster.ModifiedBy);
			UDSP_UPDATE_LEDGER_MASTER.MODIFIED_ON_PARAM(objParameterList , objLedgerMaster.ModifiedOn);
			UDSP_UPDATE_LEDGER_MASTER.RECORD_STATUS_PARAM(objParameterList , objLedgerMaster.RecordStatus);
			try
			{
				Logger.LogInfo("LedgerMasterDAO.cs : UpdateLedgerMaster() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strUpdateLedgerMaster, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objLedgerMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
					{
						objLedgerMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					else
					{
						objLedgerMaster.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("LedgerMasterDAO.cs : UpdateLedgerMaster() is ended with success.");
				}
				else
				{
					objLedgerMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("LedgerMasterDAO.cs : UpdateLedgerMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objLedgerMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("LedgerMasterDAO.cs : UpdateLedgerMaster() is ended with error.");
			}
			return objLedgerMaster;
		}

		public LedgerMaster ActivateDeactivateLedgerMaster(LedgerMaster objLedgerMaster)
		{
			try
			{
				Logger.LogInfo("LedgerMasterDAO.cs : ActivateDeactivateLedgerMasterDAO() is started.");
				dbExecuteStatus = DataUtility.ActivateDeactivateObject(strDBTableName, objLedgerMaster.LedgerId,
										objLedgerMaster.Version, objLedgerMaster.RecordStatus, objLedgerMaster.ModifiedBy);
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objLedgerMaster.DbOperationStatus = CommonConstant.SUCCEED;
						Logger.LogInfo("LedgerMasterDAO.cs : ActivateDeactivateLedgerMaster() is ended with success.");
					}
					else
					{
						objLedgerMaster.DbOperationStatus = CommonConstant.INVALID;
						Logger.LogInfo("LedgerMasterDAO.cs : ActivateDeactivateLedgerMaster() is ended with success.");
					}
				}
				else
				{
					objLedgerMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("LedgerMasterDAO.cs : ActivateDeactivateLedgerMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objLedgerMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("LedgerMasterDAO.cs : ActivateDeactivateLedgerMaster() is ended with error.");
			}
			return objLedgerMaster;
		}

		public LedgerMaster SelectRecordById(LedgerMaster objLedgerMaster)
		{
			try
			{
				Logger.LogInfo("LedgerMasterDAO.cs : SelectRecordById() is started.");
				objLedgerMaster.ObjectDataSet = DataUtility.SelectRecordById(strDBTableName, objLedgerMaster.LedgerId, objLedgerMaster.Version, strSelectLedgerMaster);
				if (GeneralUtility.IsInteger(objLedgerMaster.ObjectDataSet.Tables[0].Rows[0][0]) && (objLedgerMaster.ObjectDataSet.Tables[1].Columns.Count > 1))
				{
					if (Convert.ToInt32(objLedgerMaster.ObjectDataSet.Tables[0].Rows[0][0]) > 0)
					{
						objLedgerMaster.IsRecordChanged = false;
						objLedgerMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objLedgerMaster.IsRecordChanged = true;
						objLedgerMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					Logger.LogInfo("LedgerMasterDAO.cs : SelectRecordById() is ended with success.");
				}
				else
				{
					objLedgerMaster.DbOperationStatus = CommonConstant.FAIL;
					dbExecuteStatus = objLedgerMaster.ObjectDataSet.Tables[0].Rows[0][0].ToString() + " " + objLedgerMaster.ObjectDataSet.Tables[1].Rows[0][0].ToString();
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("LedgerMasterDAO.cs : SelectRecordById() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objLedgerMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("LedgerMasterDAO.cs : SelectRecordById() is ended with error.");
			}
			return objLedgerMaster;
		}
	}
}
