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
	public class BankMasterDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "BANK_MASTER";
		private string strSelectBankMaster = "UDSP_SELECT_BANK_MASTER";
		private string strInsertBankMaster = "UDSP_INSERT_BANK_MASTER";
		private string strUpdateBankMaster = "UDSP_UPDATE_BANK_MASTER";
		private string dbExecuteStatus = "";

		public BankMaster SelectBankMaster(BankMaster objBankMaster)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_BANK_MASTER.BANK_ID_PARAM(objParameterList , objBankMaster.BankId);
			UDSP_SELECT_BANK_MASTER.BANK_CODE_PARAM(objParameterList , objBankMaster.BankCode);
			UDSP_SELECT_BANK_MASTER.BANK_NAME_PARAM(objParameterList , objBankMaster.BankName);
			UDSP_SELECT_BANK_MASTER.BANK_ADDRESS_ID_PARAM(objParameterList , objBankMaster.BankAddressId);
			UDSP_SELECT_BANK_MASTER.DESCRIPTION_PARAM(objParameterList , objBankMaster.Description);
			UDSP_SELECT_BANK_MASTER.RECORD_STATUS_PARAM(objParameterList , objBankMaster.RecordStatus);
			try
			{
				Logger.LogInfo("BankMasterDAO.cs : SelectBankMaster() is started.");
				objBankMaster.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectBankMaster, CommandType.StoredProcedure);
				objBankMaster.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("BankMasterDAO.cs : SelectBankMaster() is ended with success.");
			}
			catch (Exception ex)
			{
				objBankMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("BankMasterDAO.cs : SelectBankMaster() is ended with error.");
			}
			return objBankMaster;
		}

		public BankMaster InsertBankMaster(BankMaster objBankMaster)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_INSERT_BANK_MASTER.BANK_CODE_PARAM(objParameterList , objBankMaster.BankCode);
			UDSP_INSERT_BANK_MASTER.BANK_NAME_PARAM(objParameterList , objBankMaster.BankName);
			UDSP_INSERT_BANK_MASTER.BANK_ADDRESS_ID_PARAM(objParameterList , objBankMaster.BankAddressId);
			UDSP_INSERT_BANK_MASTER.DESCRIPTION_PARAM(objParameterList , objBankMaster.Description);
			UDSP_INSERT_BANK_MASTER.VERSION_PARAM(objParameterList , objBankMaster.Version);
			UDSP_INSERT_BANK_MASTER.CREATED_BY_PARAM(objParameterList , objBankMaster.CreatedBy);
			UDSP_INSERT_BANK_MASTER.CREATED_ON_PARAM(objParameterList , objBankMaster.CreatedOn);
			UDSP_INSERT_BANK_MASTER.MODIFIED_BY_PARAM(objParameterList , objBankMaster.ModifiedBy);
			UDSP_INSERT_BANK_MASTER.MODIFIED_ON_PARAM(objParameterList , objBankMaster.ModifiedOn);
			UDSP_INSERT_BANK_MASTER.RECORD_STATUS_PARAM(objParameterList , objBankMaster.RecordStatus);
			try
			{
				Logger.LogInfo("BankMasterDAO.cs : InsertBankMaster() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strInsertBankMaster, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) > 0 )
					{
						objBankMaster.BankId = Convert.ToInt32(dbExecuteStatus);
						objBankMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objBankMaster.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("BankMasterDAO.cs : InsertBankMaster() is ended with success.");
				}
				else
				{
					objBankMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("BankMasterDAO.cs : InsertBankMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objBankMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("BankMasterDAO.cs : InsertBankMaster() is ended with error.");
			}
			return objBankMaster;
		}

		public BankMaster UpdateBankMaster(BankMaster objBankMaster)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_UPDATE_BANK_MASTER.BANK_ID_PARAM(objParameterList , objBankMaster.BankId);
			UDSP_UPDATE_BANK_MASTER.BANK_CODE_PARAM(objParameterList , objBankMaster.BankCode);
			UDSP_UPDATE_BANK_MASTER.BANK_NAME_PARAM(objParameterList , objBankMaster.BankName);
			UDSP_UPDATE_BANK_MASTER.BANK_ADDRESS_ID_PARAM(objParameterList , objBankMaster.BankAddressId);
			UDSP_UPDATE_BANK_MASTER.DESCRIPTION_PARAM(objParameterList , objBankMaster.Description);
			UDSP_UPDATE_BANK_MASTER.VERSION_PARAM(objParameterList , objBankMaster.Version);
			UDSP_UPDATE_BANK_MASTER.CREATED_BY_PARAM(objParameterList , objBankMaster.CreatedBy);
			UDSP_UPDATE_BANK_MASTER.CREATED_ON_PARAM(objParameterList , objBankMaster.CreatedOn);
			UDSP_UPDATE_BANK_MASTER.MODIFIED_BY_PARAM(objParameterList , objBankMaster.ModifiedBy);
			UDSP_UPDATE_BANK_MASTER.MODIFIED_ON_PARAM(objParameterList , objBankMaster.ModifiedOn);
			UDSP_UPDATE_BANK_MASTER.RECORD_STATUS_PARAM(objParameterList , objBankMaster.RecordStatus);
			try
			{
				Logger.LogInfo("BankMasterDAO.cs : UpdateBankMaster() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strUpdateBankMaster, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objBankMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
					{
						objBankMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					else
					{
						objBankMaster.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("BankMasterDAO.cs : UpdateBankMaster() is ended with success.");
				}
				else
				{
					objBankMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("BankMasterDAO.cs : UpdateBankMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objBankMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("BankMasterDAO.cs : UpdateBankMaster() is ended with error.");
			}
			return objBankMaster;
		}

		public BankMaster ActivateDeactivateBankMaster(BankMaster objBankMaster)
		{
			try
			{
				Logger.LogInfo("BankMasterDAO.cs : ActivateDeactivateBankMasterDAO() is started.");
				dbExecuteStatus = DataUtility.ActivateDeactivateObject(strDBTableName, objBankMaster.BankId,
										objBankMaster.Version, objBankMaster.RecordStatus, objBankMaster.ModifiedBy);
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objBankMaster.DbOperationStatus = CommonConstant.SUCCEED;
						Logger.LogInfo("BankMasterDAO.cs : ActivateDeactivateBankMaster() is ended with success.");
					}
					else
					{
						objBankMaster.DbOperationStatus = CommonConstant.INVALID;
						Logger.LogInfo("BankMasterDAO.cs : ActivateDeactivateBankMaster() is ended with success.");
					}
				}
				else
				{
					objBankMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("BankMasterDAO.cs : ActivateDeactivateBankMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objBankMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("BankMasterDAO.cs : ActivateDeactivateBankMaster() is ended with error.");
			}
			return objBankMaster;
		}

		public BankMaster SelectRecordById(BankMaster objBankMaster)
		{
			try
			{
				Logger.LogInfo("BankMasterDAO.cs : SelectRecordById() is started.");
				objBankMaster.ObjectDataSet = DataUtility.SelectRecordById(strDBTableName, objBankMaster.BankId, objBankMaster.Version, strSelectBankMaster);
				if (GeneralUtility.IsInteger(objBankMaster.ObjectDataSet.Tables[0].Rows[0][0]) && (objBankMaster.ObjectDataSet.Tables[1].Columns.Count > 1))
				{
					if (Convert.ToInt32(objBankMaster.ObjectDataSet.Tables[0].Rows[0][0]) > 0)
					{
						objBankMaster.IsRecordChanged = false;
						objBankMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objBankMaster.IsRecordChanged = true;
						objBankMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					Logger.LogInfo("BankMasterDAO.cs : SelectRecordById() is ended with success.");
				}
				else
				{
					objBankMaster.DbOperationStatus = CommonConstant.FAIL;
					dbExecuteStatus = objBankMaster.ObjectDataSet.Tables[0].Rows[0][0].ToString() + " " + objBankMaster.ObjectDataSet.Tables[1].Rows[0][0].ToString();
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("BankMasterDAO.cs : SelectRecordById() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objBankMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("BankMasterDAO.cs : SelectRecordById() is ended with error.");
			}
			return objBankMaster;
		}
	}
}
