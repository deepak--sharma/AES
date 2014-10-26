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
	public class CashRegisterMasterDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "CASH_REGISTER_MASTER";
		private string strSelectCashRegisterMaster = "UDSP_SELECT_CASH_REGISTER_MASTER";
		private string strInsertCashRegisterMaster = "UDSP_INSERT_CASH_REGISTER_MASTER";
		private string strUpdateCashRegisterMaster = "UDSP_UPDATE_CASH_REGISTER_MASTER";
		private string dbExecuteStatus = "";

		public CashRegisterMaster SelectCashRegisterMaster(CashRegisterMaster objCashRegisterMaster)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_CASH_REGISTER_MASTER.CASH_REGISTER_ID_PARAM(objParameterList , objCashRegisterMaster.CashRegisterId);
			UDSP_SELECT_CASH_REGISTER_MASTER.CASH_REGISTER_NAME_PARAM(objParameterList , objCashRegisterMaster.CashRegisterName);
			if (objCashRegisterMaster.GroupObject != null)
			{
				UDSP_SELECT_CASH_REGISTER_MASTER.GROUP_ID_PARAM(objParameterList , objCashRegisterMaster.GroupObject.GroupId);
			}
			UDSP_SELECT_CASH_REGISTER_MASTER.OPENING_DATE_PARAM(objParameterList , objCashRegisterMaster.OpeningDate);
			UDSP_SELECT_CASH_REGISTER_MASTER.DR_CR_PARAM(objParameterList , objCashRegisterMaster.DrCr);
			UDSP_SELECT_CASH_REGISTER_MASTER.ON_DATE_PARAM(objParameterList , objCashRegisterMaster.OnDate);
			UDSP_SELECT_CASH_REGISTER_MASTER.DESCRIPTION_PARAM(objParameterList , objCashRegisterMaster.Description);
			UDSP_SELECT_CASH_REGISTER_MASTER.RECORD_STATUS_PARAM(objParameterList , objCashRegisterMaster.RecordStatus);
			try
			{
				Logger.LogInfo("CashRegisterMasterDAO.cs : SelectCashRegisterMaster() is started.");
				objCashRegisterMaster.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectCashRegisterMaster, CommandType.StoredProcedure);
				objCashRegisterMaster.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("CashRegisterMasterDAO.cs : SelectCashRegisterMaster() is ended with success.");
			}
			catch (Exception ex)
			{
				objCashRegisterMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("CashRegisterMasterDAO.cs : SelectCashRegisterMaster() is ended with error.");
			}
			return objCashRegisterMaster;
		}

		public CashRegisterMaster InsertCashRegisterMaster(CashRegisterMaster objCashRegisterMaster)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_INSERT_CASH_REGISTER_MASTER.CASH_REGISTER_NAME_PARAM(objParameterList , objCashRegisterMaster.CashRegisterName);
			if (objCashRegisterMaster.GroupObject != null)
			{
				UDSP_INSERT_CASH_REGISTER_MASTER.GROUP_ID_PARAM(objParameterList , objCashRegisterMaster.GroupObject.GroupId);
			}
			UDSP_INSERT_CASH_REGISTER_MASTER.OPENING_DATE_PARAM(objParameterList , objCashRegisterMaster.OpeningDate);
			UDSP_INSERT_CASH_REGISTER_MASTER.DR_CR_PARAM(objParameterList , objCashRegisterMaster.DrCr);
			UDSP_INSERT_CASH_REGISTER_MASTER.ON_DATE_PARAM(objParameterList , objCashRegisterMaster.OnDate);
			UDSP_INSERT_CASH_REGISTER_MASTER.DESCRIPTION_PARAM(objParameterList , objCashRegisterMaster.Description);
			UDSP_INSERT_CASH_REGISTER_MASTER.VERSION_PARAM(objParameterList , objCashRegisterMaster.Version);
			UDSP_INSERT_CASH_REGISTER_MASTER.CREATED_BY_PARAM(objParameterList , objCashRegisterMaster.CreatedBy);
			UDSP_INSERT_CASH_REGISTER_MASTER.CREATED_ON_PARAM(objParameterList , objCashRegisterMaster.CreatedOn);
			UDSP_INSERT_CASH_REGISTER_MASTER.MODIFIED_BY_PARAM(objParameterList , objCashRegisterMaster.ModifiedBy);
			UDSP_INSERT_CASH_REGISTER_MASTER.MODIFIED_ON_PARAM(objParameterList , objCashRegisterMaster.ModifiedOn);
			UDSP_INSERT_CASH_REGISTER_MASTER.RECORD_STATUS_PARAM(objParameterList , objCashRegisterMaster.RecordStatus);
			try
			{
				Logger.LogInfo("CashRegisterMasterDAO.cs : InsertCashRegisterMaster() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strInsertCashRegisterMaster, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) > 0 )
					{
						objCashRegisterMaster.CashRegisterId = Convert.ToInt32(dbExecuteStatus);
						objCashRegisterMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objCashRegisterMaster.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("CashRegisterMasterDAO.cs : InsertCashRegisterMaster() is ended with success.");
				}
				else
				{
					objCashRegisterMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("CashRegisterMasterDAO.cs : InsertCashRegisterMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objCashRegisterMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("CashRegisterMasterDAO.cs : InsertCashRegisterMaster() is ended with error.");
			}
			return objCashRegisterMaster;
		}

		public CashRegisterMaster UpdateCashRegisterMaster(CashRegisterMaster objCashRegisterMaster)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_UPDATE_CASH_REGISTER_MASTER.CASH_REGISTER_ID_PARAM(objParameterList , objCashRegisterMaster.CashRegisterId);
			UDSP_UPDATE_CASH_REGISTER_MASTER.CASH_REGISTER_NAME_PARAM(objParameterList , objCashRegisterMaster.CashRegisterName);
			if (objCashRegisterMaster.GroupObject != null)
			{
				UDSP_UPDATE_CASH_REGISTER_MASTER.GROUP_ID_PARAM(objParameterList , objCashRegisterMaster.GroupObject.GroupId);
			}
			UDSP_UPDATE_CASH_REGISTER_MASTER.OPENING_DATE_PARAM(objParameterList , objCashRegisterMaster.OpeningDate);
			UDSP_UPDATE_CASH_REGISTER_MASTER.DR_CR_PARAM(objParameterList , objCashRegisterMaster.DrCr);
			UDSP_UPDATE_CASH_REGISTER_MASTER.ON_DATE_PARAM(objParameterList , objCashRegisterMaster.OnDate);
			UDSP_UPDATE_CASH_REGISTER_MASTER.DESCRIPTION_PARAM(objParameterList , objCashRegisterMaster.Description);
			UDSP_UPDATE_CASH_REGISTER_MASTER.VERSION_PARAM(objParameterList , objCashRegisterMaster.Version);
			UDSP_UPDATE_CASH_REGISTER_MASTER.CREATED_BY_PARAM(objParameterList , objCashRegisterMaster.CreatedBy);
			UDSP_UPDATE_CASH_REGISTER_MASTER.CREATED_ON_PARAM(objParameterList , objCashRegisterMaster.CreatedOn);
			UDSP_UPDATE_CASH_REGISTER_MASTER.MODIFIED_BY_PARAM(objParameterList , objCashRegisterMaster.ModifiedBy);
			UDSP_UPDATE_CASH_REGISTER_MASTER.MODIFIED_ON_PARAM(objParameterList , objCashRegisterMaster.ModifiedOn);
			UDSP_UPDATE_CASH_REGISTER_MASTER.RECORD_STATUS_PARAM(objParameterList , objCashRegisterMaster.RecordStatus);
			try
			{
				Logger.LogInfo("CashRegisterMasterDAO.cs : UpdateCashRegisterMaster() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strUpdateCashRegisterMaster, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objCashRegisterMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
					{
						objCashRegisterMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					else
					{
						objCashRegisterMaster.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("CashRegisterMasterDAO.cs : UpdateCashRegisterMaster() is ended with success.");
				}
				else
				{
					objCashRegisterMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("CashRegisterMasterDAO.cs : UpdateCashRegisterMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objCashRegisterMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("CashRegisterMasterDAO.cs : UpdateCashRegisterMaster() is ended with error.");
			}
			return objCashRegisterMaster;
		}

		public CashRegisterMaster ActivateDeactivateCashRegisterMaster(CashRegisterMaster objCashRegisterMaster)
		{
			try
			{
				Logger.LogInfo("CashRegisterMasterDAO.cs : ActivateDeactivateCashRegisterMasterDAO() is started.");
				dbExecuteStatus = DataUtility.ActivateDeactivateObject(strDBTableName, objCashRegisterMaster.CashRegisterId,
										objCashRegisterMaster.Version, objCashRegisterMaster.RecordStatus, objCashRegisterMaster.ModifiedBy);
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objCashRegisterMaster.DbOperationStatus = CommonConstant.SUCCEED;
						Logger.LogInfo("CashRegisterMasterDAO.cs : ActivateDeactivateCashRegisterMaster() is ended with success.");
					}
					else
					{
						objCashRegisterMaster.DbOperationStatus = CommonConstant.INVALID;
						Logger.LogInfo("CashRegisterMasterDAO.cs : ActivateDeactivateCashRegisterMaster() is ended with success.");
					}
				}
				else
				{
					objCashRegisterMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("CashRegisterMasterDAO.cs : ActivateDeactivateCashRegisterMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objCashRegisterMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("CashRegisterMasterDAO.cs : ActivateDeactivateCashRegisterMaster() is ended with error.");
			}
			return objCashRegisterMaster;
		}

		public CashRegisterMaster SelectRecordById(CashRegisterMaster objCashRegisterMaster)
		{
			try
			{
				Logger.LogInfo("CashRegisterMasterDAO.cs : SelectRecordById() is started.");
				objCashRegisterMaster.ObjectDataSet = DataUtility.SelectRecordById(strDBTableName, objCashRegisterMaster.CashRegisterId, objCashRegisterMaster.Version, strSelectCashRegisterMaster);
				if (GeneralUtility.IsInteger(objCashRegisterMaster.ObjectDataSet.Tables[0].Rows[0][0]) && (objCashRegisterMaster.ObjectDataSet.Tables[1].Columns.Count > 1))
				{
					if (Convert.ToInt32(objCashRegisterMaster.ObjectDataSet.Tables[0].Rows[0][0]) > 0)
					{
						objCashRegisterMaster.IsRecordChanged = false;
						objCashRegisterMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objCashRegisterMaster.IsRecordChanged = true;
						objCashRegisterMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					Logger.LogInfo("CashRegisterMasterDAO.cs : SelectRecordById() is ended with success.");
				}
				else
				{
					objCashRegisterMaster.DbOperationStatus = CommonConstant.FAIL;
					dbExecuteStatus = objCashRegisterMaster.ObjectDataSet.Tables[0].Rows[0][0].ToString() + " " + objCashRegisterMaster.ObjectDataSet.Tables[1].Rows[0][0].ToString();
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("CashRegisterMasterDAO.cs : SelectRecordById() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objCashRegisterMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("CashRegisterMasterDAO.cs : SelectRecordById() is ended with error.");
			}
			return objCashRegisterMaster;
		}
	}
}
