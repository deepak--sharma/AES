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
	public class DivisionMasterDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "DIVISION_MASTER";
		private string strSelectDivisionMaster = "UDSP_SELECT_DIVISION_MASTER";
		private string strInsertDivisionMaster = "UDSP_INSERT_DIVISION_MASTER";
		private string strUpdateDivisionMaster = "UDSP_UPDATE_DIVISION_MASTER";
		private string dbExecuteStatus = "";

		public DivisionMaster SelectDivisionMaster(DivisionMaster objDivisionMaster)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_DIVISION_MASTER.DIVISION_ID_PARAM(objParameterList , objDivisionMaster.DivisionId);
			if (objDivisionMaster.DepartmentObject != null)
			{
				UDSP_SELECT_DIVISION_MASTER.DEPARTMENT_ID_PARAM(objParameterList , objDivisionMaster.DepartmentObject.DepartmentId);
			}
			UDSP_SELECT_DIVISION_MASTER.DIVISION_CODE_PARAM(objParameterList , objDivisionMaster.DivisionCode);
			UDSP_SELECT_DIVISION_MASTER.DIVISION_NAME_PARAM(objParameterList , objDivisionMaster.DivisionName);
			UDSP_SELECT_DIVISION_MASTER.DESCRIPTION_PARAM(objParameterList , objDivisionMaster.Description);
			UDSP_SELECT_DIVISION_MASTER.RECORD_STATUS_PARAM(objParameterList , objDivisionMaster.RecordStatus);
			try
			{
				Logger.LogInfo("DivisionMasterDAO.cs : SelectDivisionMaster() is started.");
				objDivisionMaster.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectDivisionMaster, CommandType.StoredProcedure);
				objDivisionMaster.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("DivisionMasterDAO.cs : SelectDivisionMaster() is ended with success.");
			}
			catch (Exception ex)
			{
				objDivisionMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("DivisionMasterDAO.cs : SelectDivisionMaster() is ended with error.");
			}
			return objDivisionMaster;
		}

		public DivisionMaster InsertDivisionMaster(DivisionMaster objDivisionMaster)
		{
			objParameterList = new List<SqlParameter>();
				
			if (objDivisionMaster.DepartmentObject != null)
			{
				UDSP_INSERT_DIVISION_MASTER.DEPARTMENT_ID_PARAM(objParameterList , objDivisionMaster.DepartmentObject.DepartmentId);
			}
			UDSP_INSERT_DIVISION_MASTER.DIVISION_CODE_PARAM(objParameterList , objDivisionMaster.DivisionCode);
			UDSP_INSERT_DIVISION_MASTER.DIVISION_NAME_PARAM(objParameterList , objDivisionMaster.DivisionName);
			UDSP_INSERT_DIVISION_MASTER.DESCRIPTION_PARAM(objParameterList , objDivisionMaster.Description);
			UDSP_INSERT_DIVISION_MASTER.VERSION_PARAM(objParameterList , objDivisionMaster.Version);
			UDSP_INSERT_DIVISION_MASTER.CREATED_BY_PARAM(objParameterList , objDivisionMaster.CreatedBy);
			UDSP_INSERT_DIVISION_MASTER.CREATED_ON_PARAM(objParameterList , objDivisionMaster.CreatedOn);
			UDSP_INSERT_DIVISION_MASTER.MODIFIED_BY_PARAM(objParameterList , objDivisionMaster.ModifiedBy);
			UDSP_INSERT_DIVISION_MASTER.MODIFIED_ON_PARAM(objParameterList , objDivisionMaster.ModifiedOn);
			UDSP_INSERT_DIVISION_MASTER.RECORD_STATUS_PARAM(objParameterList , objDivisionMaster.RecordStatus);
			try
			{
				Logger.LogInfo("DivisionMasterDAO.cs : InsertDivisionMaster() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strInsertDivisionMaster, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) > 0 )
					{
						objDivisionMaster.DivisionId = Convert.ToInt32(dbExecuteStatus);
						objDivisionMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objDivisionMaster.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("DivisionMasterDAO.cs : InsertDivisionMaster() is ended with success.");
				}
				else
				{
					objDivisionMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("DivisionMasterDAO.cs : InsertDivisionMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objDivisionMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("DivisionMasterDAO.cs : InsertDivisionMaster() is ended with error.");
			}
			return objDivisionMaster;
		}

		public DivisionMaster UpdateDivisionMaster(DivisionMaster objDivisionMaster)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_UPDATE_DIVISION_MASTER.DIVISION_ID_PARAM(objParameterList , objDivisionMaster.DivisionId);
			if (objDivisionMaster.DepartmentObject != null)
			{
				UDSP_UPDATE_DIVISION_MASTER.DEPARTMENT_ID_PARAM(objParameterList , objDivisionMaster.DepartmentObject.DepartmentId);
			}
			UDSP_UPDATE_DIVISION_MASTER.DIVISION_CODE_PARAM(objParameterList , objDivisionMaster.DivisionCode);
			UDSP_UPDATE_DIVISION_MASTER.DIVISION_NAME_PARAM(objParameterList , objDivisionMaster.DivisionName);
			UDSP_UPDATE_DIVISION_MASTER.DESCRIPTION_PARAM(objParameterList , objDivisionMaster.Description);
			UDSP_UPDATE_DIVISION_MASTER.VERSION_PARAM(objParameterList , objDivisionMaster.Version);
			UDSP_UPDATE_DIVISION_MASTER.CREATED_BY_PARAM(objParameterList , objDivisionMaster.CreatedBy);
			UDSP_UPDATE_DIVISION_MASTER.CREATED_ON_PARAM(objParameterList , objDivisionMaster.CreatedOn);
			UDSP_UPDATE_DIVISION_MASTER.MODIFIED_BY_PARAM(objParameterList , objDivisionMaster.ModifiedBy);
			UDSP_UPDATE_DIVISION_MASTER.MODIFIED_ON_PARAM(objParameterList , objDivisionMaster.ModifiedOn);
			UDSP_UPDATE_DIVISION_MASTER.RECORD_STATUS_PARAM(objParameterList , objDivisionMaster.RecordStatus);
			try
			{
				Logger.LogInfo("DivisionMasterDAO.cs : UpdateDivisionMaster() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strUpdateDivisionMaster, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objDivisionMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
					{
						objDivisionMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					else
					{
						objDivisionMaster.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("DivisionMasterDAO.cs : UpdateDivisionMaster() is ended with success.");
				}
				else
				{
					objDivisionMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("DivisionMasterDAO.cs : UpdateDivisionMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objDivisionMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("DivisionMasterDAO.cs : UpdateDivisionMaster() is ended with error.");
			}
			return objDivisionMaster;
		}

		public DivisionMaster ActivateDeactivateDivisionMaster(DivisionMaster objDivisionMaster)
		{
			try
			{
				Logger.LogInfo("DivisionMasterDAO.cs : ActivateDeactivateDivisionMasterDAO() is started.");
				dbExecuteStatus = DataUtility.ActivateDeactivateObject(strDBTableName, objDivisionMaster.DivisionId,
										objDivisionMaster.Version, objDivisionMaster.RecordStatus, objDivisionMaster.ModifiedBy);
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objDivisionMaster.DbOperationStatus = CommonConstant.SUCCEED;
						Logger.LogInfo("DivisionMasterDAO.cs : ActivateDeactivateDivisionMaster() is ended with success.");
					}
					else
					{
						objDivisionMaster.DbOperationStatus = CommonConstant.INVALID;
						Logger.LogInfo("DivisionMasterDAO.cs : ActivateDeactivateDivisionMaster() is ended with success.");
					}
				}
				else
				{
					objDivisionMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("DivisionMasterDAO.cs : ActivateDeactivateDivisionMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objDivisionMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("DivisionMasterDAO.cs : ActivateDeactivateDivisionMaster() is ended with error.");
			}
			return objDivisionMaster;
		}

		public DivisionMaster SelectRecordById(DivisionMaster objDivisionMaster)
		{
			try
			{
				Logger.LogInfo("DivisionMasterDAO.cs : SelectRecordById() is started.");
				objDivisionMaster.ObjectDataSet = DataUtility.SelectRecordById(strDBTableName, objDivisionMaster.DivisionId, objDivisionMaster.Version, strSelectDivisionMaster);
				if (GeneralUtility.IsInteger(objDivisionMaster.ObjectDataSet.Tables[0].Rows[0][0]) && (objDivisionMaster.ObjectDataSet.Tables[1].Columns.Count > 1))
				{
					if (Convert.ToInt32(objDivisionMaster.ObjectDataSet.Tables[0].Rows[0][0]) > 0)
					{
						objDivisionMaster.IsRecordChanged = false;
						objDivisionMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objDivisionMaster.IsRecordChanged = true;
						objDivisionMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					Logger.LogInfo("DivisionMasterDAO.cs : SelectRecordById() is ended with success.");
				}
				else
				{
					objDivisionMaster.DbOperationStatus = CommonConstant.FAIL;
					dbExecuteStatus = objDivisionMaster.ObjectDataSet.Tables[0].Rows[0][0].ToString() + " " + objDivisionMaster.ObjectDataSet.Tables[1].Rows[0][0].ToString();
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("DivisionMasterDAO.cs : SelectRecordById() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objDivisionMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("DivisionMasterDAO.cs : SelectRecordById() is ended with error.");
			}
			return objDivisionMaster;
		}
	}
}
