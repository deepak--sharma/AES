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
	public class LateFeeSetupDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "LATE_FEE_SETUP";
        private string strSelectLateFeeSetup = "SP_SELECT_LATE_FEE_SETUP";
		private string strInsertLateFeeSetup = "UDSP_INSERT_LATE_FEE_SETUP";
		private string strUpdateLateFeeSetup = "UDSP_UPDATE_LATE_FEE_SETUP";
		private string dbExecuteStatus = "";

		public LateFeeSetup SelectLateFeeSetup(LateFeeSetup objLateFeeSetup)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_LATE_FEE_SETUP.LATE_FEE_ID_PARAM(objParameterList , objLateFeeSetup.LateFeeId);
			if (objLateFeeSetup.BranchObject != null)
			{
				UDSP_SELECT_LATE_FEE_SETUP.BRANCH_ID_PARAM(objParameterList , objLateFeeSetup.BranchObject.BranchId);
			}
			if (objLateFeeSetup.ClassObject != null)
			{
				UDSP_SELECT_LATE_FEE_SETUP.CLASS_ID_PARAM(objParameterList , objLateFeeSetup.ClassObject.ClassId);
			}
			if (objLateFeeSetup.StreamObject != null)
			{
				UDSP_SELECT_LATE_FEE_SETUP.STREAM_ID_PARAM(objParameterList , objLateFeeSetup.StreamObject.StreamId);
			}
			UDSP_SELECT_LATE_FEE_SETUP.RECORD_STATUS_PARAM(objParameterList , objLateFeeSetup.RecordStatus);
			try
			{
				Logger.LogInfo("LateFeeSetupDAO.cs : SelectLateFeeSetup() is started.");
				objLateFeeSetup.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectLateFeeSetup, CommandType.StoredProcedure);
				objLateFeeSetup.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("LateFeeSetupDAO.cs : SelectLateFeeSetup() is ended with success.");
			}
			catch (Exception ex)
			{
				objLateFeeSetup.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("LateFeeSetupDAO.cs : SelectLateFeeSetup() is ended with error.");
			}
			return objLateFeeSetup;
		}

		public LateFeeSetup InsertLateFeeSetup(LateFeeSetup objLateFeeSetup)
		{
			objParameterList = new List<SqlParameter>();
				
			if (objLateFeeSetup.BranchObject != null)
			{
				UDSP_INSERT_LATE_FEE_SETUP.BRANCH_ID_PARAM(objParameterList , objLateFeeSetup.BranchObject.BranchId);
			}
			if (objLateFeeSetup.ClassObject != null)
			{
				UDSP_INSERT_LATE_FEE_SETUP.CLASS_ID_PARAM(objParameterList , objLateFeeSetup.ClassObject.ClassId);
			}
			if (objLateFeeSetup.StreamObject != null)
			{
				UDSP_INSERT_LATE_FEE_SETUP.STREAM_ID_PARAM(objParameterList , objLateFeeSetup.StreamObject.StreamId);
			}
			UDSP_INSERT_LATE_FEE_SETUP.VERSION_PARAM(objParameterList , objLateFeeSetup.Version);
			UDSP_INSERT_LATE_FEE_SETUP.CREATED_BY_PARAM(objParameterList , objLateFeeSetup.CreatedBy);
			UDSP_INSERT_LATE_FEE_SETUP.CREATED_ON_PARAM(objParameterList , objLateFeeSetup.CreatedOn);
			UDSP_INSERT_LATE_FEE_SETUP.MODIFIED_BY_PARAM(objParameterList , objLateFeeSetup.ModifiedBy);
			UDSP_INSERT_LATE_FEE_SETUP.MODIFIED_ON_PARAM(objParameterList , objLateFeeSetup.ModifiedOn);
			UDSP_INSERT_LATE_FEE_SETUP.RECORD_STATUS_PARAM(objParameterList , objLateFeeSetup.RecordStatus);
			try
			{
				Logger.LogInfo("LateFeeSetupDAO.cs : InsertLateFeeSetup() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strInsertLateFeeSetup, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) > 0 )
					{
						objLateFeeSetup.LateFeeId = Convert.ToInt32(dbExecuteStatus);
						objLateFeeSetup.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objLateFeeSetup.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("LateFeeSetupDAO.cs : InsertLateFeeSetup() is ended with success.");
				}
				else
				{
					objLateFeeSetup.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("LateFeeSetupDAO.cs : InsertLateFeeSetup() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objLateFeeSetup.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("LateFeeSetupDAO.cs : InsertLateFeeSetup() is ended with error.");
			}
			return objLateFeeSetup;
		}

		public LateFeeSetup UpdateLateFeeSetup(LateFeeSetup objLateFeeSetup)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_UPDATE_LATE_FEE_SETUP.LATE_FEE_ID_PARAM(objParameterList , objLateFeeSetup.LateFeeId);
			if (objLateFeeSetup.BranchObject != null)
			{
				UDSP_UPDATE_LATE_FEE_SETUP.BRANCH_ID_PARAM(objParameterList , objLateFeeSetup.BranchObject.BranchId);
			}
			if (objLateFeeSetup.ClassObject != null)
			{
				UDSP_UPDATE_LATE_FEE_SETUP.CLASS_ID_PARAM(objParameterList , objLateFeeSetup.ClassObject.ClassId);
			}
			if (objLateFeeSetup.StreamObject != null)
			{
				UDSP_UPDATE_LATE_FEE_SETUP.STREAM_ID_PARAM(objParameterList , objLateFeeSetup.StreamObject.StreamId);
			}
			UDSP_UPDATE_LATE_FEE_SETUP.VERSION_PARAM(objParameterList , objLateFeeSetup.Version);
			UDSP_UPDATE_LATE_FEE_SETUP.CREATED_BY_PARAM(objParameterList , objLateFeeSetup.CreatedBy);
			UDSP_UPDATE_LATE_FEE_SETUP.CREATED_ON_PARAM(objParameterList , objLateFeeSetup.CreatedOn);
			UDSP_UPDATE_LATE_FEE_SETUP.MODIFIED_BY_PARAM(objParameterList , objLateFeeSetup.ModifiedBy);
			UDSP_UPDATE_LATE_FEE_SETUP.MODIFIED_ON_PARAM(objParameterList , objLateFeeSetup.ModifiedOn);
			UDSP_UPDATE_LATE_FEE_SETUP.RECORD_STATUS_PARAM(objParameterList , objLateFeeSetup.RecordStatus);
			try
			{
				Logger.LogInfo("LateFeeSetupDAO.cs : UpdateLateFeeSetup() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strUpdateLateFeeSetup, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objLateFeeSetup.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
					{
						objLateFeeSetup.DbOperationStatus = CommonConstant.INVALID;
					}
					else
					{
						objLateFeeSetup.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("LateFeeSetupDAO.cs : UpdateLateFeeSetup() is ended with success.");
				}
				else
				{
					objLateFeeSetup.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("LateFeeSetupDAO.cs : UpdateLateFeeSetup() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objLateFeeSetup.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("LateFeeSetupDAO.cs : UpdateLateFeeSetup() is ended with error.");
			}
			return objLateFeeSetup;
		}

		public LateFeeSetup ActivateDeactivateLateFeeSetup(LateFeeSetup objLateFeeSetup)
		{
			try
			{
				Logger.LogInfo("LateFeeSetupDAO.cs : ActivateDeactivateLateFeeSetupDAO() is started.");
				dbExecuteStatus = DataUtility.ActivateDeactivateObject(strDBTableName, objLateFeeSetup.LateFeeId,
										objLateFeeSetup.Version, objLateFeeSetup.RecordStatus, objLateFeeSetup.ModifiedBy);
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objLateFeeSetup.DbOperationStatus = CommonConstant.SUCCEED;
						Logger.LogInfo("LateFeeSetupDAO.cs : ActivateDeactivateLateFeeSetup() is ended with success.");
					}
					else
					{
						objLateFeeSetup.DbOperationStatus = CommonConstant.INVALID;
						Logger.LogInfo("LateFeeSetupDAO.cs : ActivateDeactivateLateFeeSetup() is ended with success.");
					}
				}
				else
				{
					objLateFeeSetup.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("LateFeeSetupDAO.cs : ActivateDeactivateLateFeeSetup() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objLateFeeSetup.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("LateFeeSetupDAO.cs : ActivateDeactivateLateFeeSetup() is ended with error.");
			}
			return objLateFeeSetup;
		}

		public LateFeeSetup SelectRecordById(LateFeeSetup objLateFeeSetup)
		{
			try
			{
				Logger.LogInfo("LateFeeSetupDAO.cs : SelectRecordById() is started.");
				objLateFeeSetup.ObjectDataSet = DataUtility.SelectRecordById(strDBTableName, objLateFeeSetup.LateFeeId, objLateFeeSetup.Version, strSelectLateFeeSetup);
				if (GeneralUtility.IsInteger(objLateFeeSetup.ObjectDataSet.Tables[0].Rows[0][0]) && (objLateFeeSetup.ObjectDataSet.Tables[1].Columns.Count > 1))
				{
					if (Convert.ToInt32(objLateFeeSetup.ObjectDataSet.Tables[0].Rows[0][0]) > 0)
					{
						objLateFeeSetup.IsRecordChanged = false;
						objLateFeeSetup.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objLateFeeSetup.IsRecordChanged = true;
						objLateFeeSetup.DbOperationStatus = CommonConstant.INVALID;
					}
					Logger.LogInfo("LateFeeSetupDAO.cs : SelectRecordById() is ended with success.");
				}
				else
				{
					objLateFeeSetup.DbOperationStatus = CommonConstant.FAIL;
					dbExecuteStatus = objLateFeeSetup.ObjectDataSet.Tables[0].Rows[0][0].ToString() + " " + objLateFeeSetup.ObjectDataSet.Tables[1].Rows[0][0].ToString();
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("LateFeeSetupDAO.cs : SelectRecordById() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objLateFeeSetup.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("LateFeeSetupDAO.cs : SelectRecordById() is ended with error.");
			}
			return objLateFeeSetup;
		}
	}
}
