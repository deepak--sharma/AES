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
	public class FeeRegisterDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "FEE_REGISTER";
		private string strSelectFeeRegister = "UDSP_SELECT_FEE_REGISTER";
		private string strInsertFeeRegister = "UDSP_INSERT_FEE_REGISTER";
		private string strUpdateFeeRegister = "UDSP_UPDATE_FEE_REGISTER";
		private string dbExecuteStatus = "";

		public FeeRegister SelectFeeRegister(FeeRegister objFeeRegister)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_FEE_REGISTER.FEE_REGISTER_ID_PARAM(objParameterList , objFeeRegister.FeeRegisterId);
			if (objFeeRegister.FeeStructureObject != null)
			{
				UDSP_SELECT_FEE_REGISTER.FEE_STRUCTURE_ID_PARAM(objParameterList , objFeeRegister.FeeStructureObject.FeeStructureId);
			}
			if (objFeeRegister.StudentObject != null)
			{
				UDSP_SELECT_FEE_REGISTER.STUDENT_ID_PARAM(objParameterList , objFeeRegister.StudentObject.StudentId);
			}
			if (objFeeRegister.ComponentObject != null)
			{
				UDSP_SELECT_FEE_REGISTER.COMPONENT_ID_PARAM(objParameterList , objFeeRegister.ComponentObject.FeeId);
			}
			UDSP_SELECT_FEE_REGISTER.COMPONENT_AMOUNT_PARAM(objParameterList , objFeeRegister.ComponentAmount);
			UDSP_SELECT_FEE_REGISTER.COMPONENT_TYPE_PARAM(objParameterList , objFeeRegister.ComponentType);
			UDSP_SELECT_FEE_REGISTER.PROCESS_DATE_PARAM(objParameterList , objFeeRegister.ProcessDate);
			UDSP_SELECT_FEE_REGISTER.RECORD_STATUS_PARAM(objParameterList , objFeeRegister.RecordStatus);
			try
			{
				Logger.LogInfo("FeeRegisterDAO.cs : SelectFeeRegister() is started.");
				objFeeRegister.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectFeeRegister, CommandType.StoredProcedure);
				objFeeRegister.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("FeeRegisterDAO.cs : SelectFeeRegister() is ended with success.");
			}
			catch (Exception ex)
			{
				objFeeRegister.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("FeeRegisterDAO.cs : SelectFeeRegister() is ended with error.");
			}
			return objFeeRegister;
		}

		public FeeRegister InsertFeeRegister(FeeRegister objFeeRegister)
		{
			objParameterList = new List<SqlParameter>();
				
			if (objFeeRegister.FeeStructureObject != null)
			{
				UDSP_INSERT_FEE_REGISTER.FEE_STRUCTURE_ID_PARAM(objParameterList , objFeeRegister.FeeStructureObject.FeeStructureId);
			}
			if (objFeeRegister.StudentObject != null)
			{
				UDSP_INSERT_FEE_REGISTER.STUDENT_ID_PARAM(objParameterList , objFeeRegister.StudentObject.StudentId);
			}
			if (objFeeRegister.ComponentObject != null)
			{
				UDSP_INSERT_FEE_REGISTER.COMPONENT_ID_PARAM(objParameterList , objFeeRegister.ComponentObject.FeeId);
			}
			UDSP_INSERT_FEE_REGISTER.COMPONENT_AMOUNT_PARAM(objParameterList , objFeeRegister.ComponentAmount);
			UDSP_INSERT_FEE_REGISTER.COMPONENT_TYPE_PARAM(objParameterList , objFeeRegister.ComponentType);
			UDSP_INSERT_FEE_REGISTER.PROCESS_DATE_PARAM(objParameterList , objFeeRegister.ProcessDate);
			UDSP_INSERT_FEE_REGISTER.VERSION_PARAM(objParameterList , objFeeRegister.Version);
			UDSP_INSERT_FEE_REGISTER.CREATED_BY_PARAM(objParameterList , objFeeRegister.CreatedBy);
			UDSP_INSERT_FEE_REGISTER.CREATED_ON_PARAM(objParameterList , objFeeRegister.CreatedOn);
			UDSP_INSERT_FEE_REGISTER.MODIFIED_BY_PARAM(objParameterList , objFeeRegister.ModifiedBy);
			UDSP_INSERT_FEE_REGISTER.MODIFIED_ON_PARAM(objParameterList , objFeeRegister.ModifiedOn);
			UDSP_INSERT_FEE_REGISTER.RECORD_STATUS_PARAM(objParameterList , objFeeRegister.RecordStatus);
			try
			{
				Logger.LogInfo("FeeRegisterDAO.cs : InsertFeeRegister() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strInsertFeeRegister, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) > 0 )
					{
						objFeeRegister.FeeRegisterId = Convert.ToInt32(dbExecuteStatus);
						objFeeRegister.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objFeeRegister.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("FeeRegisterDAO.cs : InsertFeeRegister() is ended with success.");
				}
				else
				{
					objFeeRegister.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("FeeRegisterDAO.cs : InsertFeeRegister() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objFeeRegister.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("FeeRegisterDAO.cs : InsertFeeRegister() is ended with error.");
			}
			return objFeeRegister;
		}

		public FeeRegister UpdateFeeRegister(FeeRegister objFeeRegister)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_UPDATE_FEE_REGISTER.FEE_REGISTER_ID_PARAM(objParameterList , objFeeRegister.FeeRegisterId);
			if (objFeeRegister.FeeStructureObject != null)
			{
				UDSP_UPDATE_FEE_REGISTER.FEE_STRUCTURE_ID_PARAM(objParameterList , objFeeRegister.FeeStructureObject.FeeStructureId);
			}
			if (objFeeRegister.StudentObject != null)
			{
				UDSP_UPDATE_FEE_REGISTER.STUDENT_ID_PARAM(objParameterList , objFeeRegister.StudentObject.StudentId);
			}
			if (objFeeRegister.ComponentObject != null)
			{
				UDSP_UPDATE_FEE_REGISTER.COMPONENT_ID_PARAM(objParameterList , objFeeRegister.ComponentObject.FeeId);
			}
			UDSP_UPDATE_FEE_REGISTER.COMPONENT_AMOUNT_PARAM(objParameterList , objFeeRegister.ComponentAmount);
			UDSP_UPDATE_FEE_REGISTER.COMPONENT_TYPE_PARAM(objParameterList , objFeeRegister.ComponentType);
			UDSP_UPDATE_FEE_REGISTER.PROCESS_DATE_PARAM(objParameterList , objFeeRegister.ProcessDate);
			UDSP_UPDATE_FEE_REGISTER.VERSION_PARAM(objParameterList , objFeeRegister.Version);
			UDSP_UPDATE_FEE_REGISTER.CREATED_BY_PARAM(objParameterList , objFeeRegister.CreatedBy);
			UDSP_UPDATE_FEE_REGISTER.CREATED_ON_PARAM(objParameterList , objFeeRegister.CreatedOn);
			UDSP_UPDATE_FEE_REGISTER.MODIFIED_BY_PARAM(objParameterList , objFeeRegister.ModifiedBy);
			UDSP_UPDATE_FEE_REGISTER.MODIFIED_ON_PARAM(objParameterList , objFeeRegister.ModifiedOn);
			UDSP_UPDATE_FEE_REGISTER.RECORD_STATUS_PARAM(objParameterList , objFeeRegister.RecordStatus);
			try
			{
				Logger.LogInfo("FeeRegisterDAO.cs : UpdateFeeRegister() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strUpdateFeeRegister, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objFeeRegister.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
					{
						objFeeRegister.DbOperationStatus = CommonConstant.INVALID;
					}
					else
					{
						objFeeRegister.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("FeeRegisterDAO.cs : UpdateFeeRegister() is ended with success.");
				}
				else
				{
					objFeeRegister.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("FeeRegisterDAO.cs : UpdateFeeRegister() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objFeeRegister.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("FeeRegisterDAO.cs : UpdateFeeRegister() is ended with error.");
			}
			return objFeeRegister;
		}

		public FeeRegister ActivateDeactivateFeeRegister(FeeRegister objFeeRegister)
		{
			try
			{
				Logger.LogInfo("FeeRegisterDAO.cs : ActivateDeactivateFeeRegisterDAO() is started.");
				dbExecuteStatus = DataUtility.ActivateDeactivateObject(strDBTableName, objFeeRegister.FeeRegisterId,
										objFeeRegister.Version, objFeeRegister.RecordStatus, objFeeRegister.ModifiedBy);
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objFeeRegister.DbOperationStatus = CommonConstant.SUCCEED;
						Logger.LogInfo("FeeRegisterDAO.cs : ActivateDeactivateFeeRegister() is ended with success.");
					}
					else
					{
						objFeeRegister.DbOperationStatus = CommonConstant.INVALID;
						Logger.LogInfo("FeeRegisterDAO.cs : ActivateDeactivateFeeRegister() is ended with success.");
					}
				}
				else
				{
					objFeeRegister.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("FeeRegisterDAO.cs : ActivateDeactivateFeeRegister() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objFeeRegister.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("FeeRegisterDAO.cs : ActivateDeactivateFeeRegister() is ended with error.");
			}
			return objFeeRegister;
		}

		public FeeRegister SelectRecordById(FeeRegister objFeeRegister)
		{
			try
			{
				Logger.LogInfo("FeeRegisterDAO.cs : SelectRecordById() is started.");
				objFeeRegister.ObjectDataSet = DataUtility.SelectRecordById(strDBTableName, objFeeRegister.FeeRegisterId, objFeeRegister.Version, strSelectFeeRegister);
				if (GeneralUtility.IsInteger(objFeeRegister.ObjectDataSet.Tables[0].Rows[0][0]) && (objFeeRegister.ObjectDataSet.Tables[1].Columns.Count > 1))
				{
					if (Convert.ToInt32(objFeeRegister.ObjectDataSet.Tables[0].Rows[0][0]) > 0)
					{
						objFeeRegister.IsRecordChanged = false;
						objFeeRegister.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objFeeRegister.IsRecordChanged = true;
						objFeeRegister.DbOperationStatus = CommonConstant.INVALID;
					}
					Logger.LogInfo("FeeRegisterDAO.cs : SelectRecordById() is ended with success.");
				}
				else
				{
					objFeeRegister.DbOperationStatus = CommonConstant.FAIL;
					dbExecuteStatus = objFeeRegister.ObjectDataSet.Tables[0].Rows[0][0].ToString() + " " + objFeeRegister.ObjectDataSet.Tables[1].Rows[0][0].ToString();
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("FeeRegisterDAO.cs : SelectRecordById() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objFeeRegister.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("FeeRegisterDAO.cs : SelectRecordById() is ended with error.");
			}
			return objFeeRegister;
		}
	}
}
