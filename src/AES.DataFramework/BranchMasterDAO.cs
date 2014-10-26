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
	public class BranchMasterDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "BRANCH_MASTER";
		private string strSelectBranchMaster = "UDSP_SELECT_BRANCH_MASTER";
		private string strInsertBranchMaster = "UDSP_INSERT_BRANCH_MASTER";
		private string strUpdateBranchMaster = "UDSP_UPDATE_BRANCH_MASTER";
		private string dbExecuteStatus = "";

		public BranchMaster SelectBranchMaster(BranchMaster objBranchMaster)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_BRANCH_MASTER.BRANCH_ID_PARAM(objParameterList , objBranchMaster.BranchId);
			UDSP_SELECT_BRANCH_MASTER.BRANCH_CODE_PARAM(objParameterList , objBranchMaster.BranchCode);
			UDSP_SELECT_BRANCH_MASTER.BRANCH_NAME_PARAM(objParameterList , objBranchMaster.BranchName);
			if (objBranchMaster.BranchHeadObject != null)
			{
				UDSP_SELECT_BRANCH_MASTER.BRANCH_HEAD_ID_PARAM(objParameterList , objBranchMaster.BranchHeadObject.EmployeeId);
			}
			UDSP_SELECT_BRANCH_MASTER.ESTABLISHED_ON_PARAM(objParameterList , objBranchMaster.EstablishedOn);
			if (objBranchMaster.BranchAddressObject != null)
			{
				UDSP_SELECT_BRANCH_MASTER.BRANCH_ADDRESS_ID_PARAM(objParameterList , objBranchMaster.BranchAddressObject.AddressId);
			}
			UDSP_SELECT_BRANCH_MASTER.DESCRIPTION_PARAM(objParameterList , objBranchMaster.Description);
			UDSP_SELECT_BRANCH_MASTER.RECORD_STATUS_PARAM(objParameterList , objBranchMaster.RecordStatus);
			try
			{
				Logger.LogInfo("BranchMasterDAO.cs : SelectBranchMaster() is started.");
				objBranchMaster.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectBranchMaster, CommandType.StoredProcedure);
				objBranchMaster.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("BranchMasterDAO.cs : SelectBranchMaster() is ended with success.");
			}
			catch (Exception ex)
			{
				objBranchMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("BranchMasterDAO.cs : SelectBranchMaster() is ended with error.");
			}
			return objBranchMaster;
		}

		public BranchMaster InsertBranchMaster(BranchMaster objBranchMaster)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_INSERT_BRANCH_MASTER.BRANCH_CODE_PARAM(objParameterList , objBranchMaster.BranchCode);
			UDSP_INSERT_BRANCH_MASTER.BRANCH_NAME_PARAM(objParameterList , objBranchMaster.BranchName);
			if (objBranchMaster.BranchHeadObject != null)
			{
				UDSP_INSERT_BRANCH_MASTER.BRANCH_HEAD_ID_PARAM(objParameterList , objBranchMaster.BranchHeadObject.EmployeeId);
			}
			UDSP_INSERT_BRANCH_MASTER.ESTABLISHED_ON_PARAM(objParameterList , objBranchMaster.EstablishedOn);
			if (objBranchMaster.BranchAddressObject != null)
			{
				UDSP_INSERT_BRANCH_MASTER.BRANCH_ADDRESS_ID_PARAM(objParameterList , objBranchMaster.BranchAddressObject.AddressId);
			}
			UDSP_INSERT_BRANCH_MASTER.DESCRIPTION_PARAM(objParameterList , objBranchMaster.Description);
			UDSP_INSERT_BRANCH_MASTER.VERSION_PARAM(objParameterList , objBranchMaster.Version);
			UDSP_INSERT_BRANCH_MASTER.CREATED_BY_PARAM(objParameterList , objBranchMaster.CreatedBy);
			UDSP_INSERT_BRANCH_MASTER.CREATED_ON_PARAM(objParameterList , objBranchMaster.CreatedOn);
			UDSP_INSERT_BRANCH_MASTER.MODIFIED_BY_PARAM(objParameterList , objBranchMaster.ModifiedBy);
			UDSP_INSERT_BRANCH_MASTER.MODIFIED_ON_PARAM(objParameterList , objBranchMaster.ModifiedOn);
			UDSP_INSERT_BRANCH_MASTER.RECORD_STATUS_PARAM(objParameterList , objBranchMaster.RecordStatus);
			try
			{
				Logger.LogInfo("BranchMasterDAO.cs : InsertBranchMaster() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strInsertBranchMaster, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) > 0 )
					{
						objBranchMaster.BranchId = Convert.ToInt32(dbExecuteStatus);
						objBranchMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objBranchMaster.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("BranchMasterDAO.cs : InsertBranchMaster() is ended with success.");
				}
				else
				{
					objBranchMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("BranchMasterDAO.cs : InsertBranchMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objBranchMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("BranchMasterDAO.cs : InsertBranchMaster() is ended with error.");
			}
			return objBranchMaster;
		}

		public BranchMaster UpdateBranchMaster(BranchMaster objBranchMaster)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_UPDATE_BRANCH_MASTER.BRANCH_ID_PARAM(objParameterList , objBranchMaster.BranchId);
			UDSP_UPDATE_BRANCH_MASTER.BRANCH_CODE_PARAM(objParameterList , objBranchMaster.BranchCode);
			UDSP_UPDATE_BRANCH_MASTER.BRANCH_NAME_PARAM(objParameterList , objBranchMaster.BranchName);
			if (objBranchMaster.BranchHeadObject != null)
			{
				UDSP_UPDATE_BRANCH_MASTER.BRANCH_HEAD_ID_PARAM(objParameterList , objBranchMaster.BranchHeadObject.EmployeeId);
			}
			UDSP_UPDATE_BRANCH_MASTER.ESTABLISHED_ON_PARAM(objParameterList , objBranchMaster.EstablishedOn);
			if (objBranchMaster.BranchAddressObject != null)
			{
				UDSP_UPDATE_BRANCH_MASTER.BRANCH_ADDRESS_ID_PARAM(objParameterList , objBranchMaster.BranchAddressObject.AddressId);
			}
			UDSP_UPDATE_BRANCH_MASTER.DESCRIPTION_PARAM(objParameterList , objBranchMaster.Description);
			UDSP_UPDATE_BRANCH_MASTER.VERSION_PARAM(objParameterList , objBranchMaster.Version);
			UDSP_UPDATE_BRANCH_MASTER.CREATED_BY_PARAM(objParameterList , objBranchMaster.CreatedBy);
			UDSP_UPDATE_BRANCH_MASTER.CREATED_ON_PARAM(objParameterList , objBranchMaster.CreatedOn);
			UDSP_UPDATE_BRANCH_MASTER.MODIFIED_BY_PARAM(objParameterList , objBranchMaster.ModifiedBy);
			UDSP_UPDATE_BRANCH_MASTER.MODIFIED_ON_PARAM(objParameterList , objBranchMaster.ModifiedOn);
			UDSP_UPDATE_BRANCH_MASTER.RECORD_STATUS_PARAM(objParameterList , objBranchMaster.RecordStatus);
			try
			{
				Logger.LogInfo("BranchMasterDAO.cs : UpdateBranchMaster() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strUpdateBranchMaster, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objBranchMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
					{
						objBranchMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					else
					{
						objBranchMaster.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("BranchMasterDAO.cs : UpdateBranchMaster() is ended with success.");
				}
				else
				{
					objBranchMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("BranchMasterDAO.cs : UpdateBranchMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objBranchMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("BranchMasterDAO.cs : UpdateBranchMaster() is ended with error.");
			}
			return objBranchMaster;
		}

		public BranchMaster ActivateDeactivateBranchMaster(BranchMaster objBranchMaster)
		{
			try
			{
				Logger.LogInfo("BranchMasterDAO.cs : ActivateDeactivateBranchMasterDAO() is started.");
				dbExecuteStatus = DataUtility.ActivateDeactivateObject(strDBTableName, objBranchMaster.BranchId,
										objBranchMaster.Version, objBranchMaster.RecordStatus, objBranchMaster.ModifiedBy);
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objBranchMaster.DbOperationStatus = CommonConstant.SUCCEED;
						Logger.LogInfo("BranchMasterDAO.cs : ActivateDeactivateBranchMaster() is ended with success.");
					}
					else
					{
						objBranchMaster.DbOperationStatus = CommonConstant.INVALID;
						Logger.LogInfo("BranchMasterDAO.cs : ActivateDeactivateBranchMaster() is ended with success.");
					}
				}
				else
				{
					objBranchMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("BranchMasterDAO.cs : ActivateDeactivateBranchMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objBranchMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("BranchMasterDAO.cs : ActivateDeactivateBranchMaster() is ended with error.");
			}
			return objBranchMaster;
		}

		public BranchMaster SelectRecordById(BranchMaster objBranchMaster)
		{
			try
			{
				Logger.LogInfo("BranchMasterDAO.cs : SelectRecordById() is started.");
				objBranchMaster.ObjectDataSet = DataUtility.SelectRecordById(strDBTableName, objBranchMaster.BranchId, objBranchMaster.Version, strSelectBranchMaster);
				if (GeneralUtility.IsInteger(objBranchMaster.ObjectDataSet.Tables[0].Rows[0][0]) && (objBranchMaster.ObjectDataSet.Tables[1].Columns.Count > 1))
				{
					if (Convert.ToInt32(objBranchMaster.ObjectDataSet.Tables[0].Rows[0][0]) > 0)
					{
						objBranchMaster.IsRecordChanged = false;
						objBranchMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objBranchMaster.IsRecordChanged = true;
						objBranchMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					Logger.LogInfo("BranchMasterDAO.cs : SelectRecordById() is ended with success.");
				}
				else
				{
					objBranchMaster.DbOperationStatus = CommonConstant.FAIL;
					dbExecuteStatus = objBranchMaster.ObjectDataSet.Tables[0].Rows[0][0].ToString() + " " + objBranchMaster.ObjectDataSet.Tables[1].Rows[0][0].ToString();
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("BranchMasterDAO.cs : SelectRecordById() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objBranchMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("BranchMasterDAO.cs : SelectRecordById() is ended with error.");
			}
			return objBranchMaster;
		}
	}
}
