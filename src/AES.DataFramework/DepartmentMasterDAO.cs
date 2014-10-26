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
	public class DepartmentMasterDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "DEPARTMENT_MASTER";
		private string strSelectDepartmentMaster = "UDSP_SELECT_DEPARTMENT_MASTER";
		private string strInsertDepartmentMaster = "UDSP_INSERT_DEPARTMENT_MASTER";
		private string strUpdateDepartmentMaster = "UDSP_UPDATE_DEPARTMENT_MASTER";
		private string dbExecuteStatus = "";

		public DepartmentMaster SelectDepartmentMaster(DepartmentMaster objDepartmentMaster)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_DEPARTMENT_MASTER.DEPARTMENT_ID_PARAM(objParameterList , objDepartmentMaster.DepartmentId);
			UDSP_SELECT_DEPARTMENT_MASTER.DEPARTMENT_CODE_PARAM(objParameterList , objDepartmentMaster.DepartmentCode);
			UDSP_SELECT_DEPARTMENT_MASTER.DEPARTMENT_NAME_PARAM(objParameterList , objDepartmentMaster.DepartmentName);
			UDSP_SELECT_DEPARTMENT_MASTER.DESCRIPTION_PARAM(objParameterList , objDepartmentMaster.Description);
			if (objDepartmentMaster.Hod != null)
			{
				UDSP_SELECT_DEPARTMENT_MASTER.HOD_PARAM(objParameterList , objDepartmentMaster.Hod.EmployeeId);
			}
			UDSP_SELECT_DEPARTMENT_MASTER.RECORD_STATUS_PARAM(objParameterList , objDepartmentMaster.RecordStatus);
			try
			{
				Logger.LogInfo("DepartmentMasterDAO.cs : SelectDepartmentMaster() is started.");
				objDepartmentMaster.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectDepartmentMaster, CommandType.StoredProcedure);
				objDepartmentMaster.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("DepartmentMasterDAO.cs : SelectDepartmentMaster() is ended with success.");
			}
			catch (Exception ex)
			{
				objDepartmentMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("DepartmentMasterDAO.cs : SelectDepartmentMaster() is ended with error.");
			}
			return objDepartmentMaster;
		}

		public DepartmentMaster InsertDepartmentMaster(DepartmentMaster objDepartmentMaster)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_INSERT_DEPARTMENT_MASTER.DEPARTMENT_CODE_PARAM(objParameterList , objDepartmentMaster.DepartmentCode);
			UDSP_INSERT_DEPARTMENT_MASTER.DEPARTMENT_NAME_PARAM(objParameterList , objDepartmentMaster.DepartmentName);
			UDSP_INSERT_DEPARTMENT_MASTER.DESCRIPTION_PARAM(objParameterList , objDepartmentMaster.Description);
			if (objDepartmentMaster.Hod != null)
			{
				UDSP_INSERT_DEPARTMENT_MASTER.HOD_PARAM(objParameterList , objDepartmentMaster.Hod.EmployeeId);
			}
			UDSP_INSERT_DEPARTMENT_MASTER.VERSION_PARAM(objParameterList , objDepartmentMaster.Version);
			UDSP_INSERT_DEPARTMENT_MASTER.CREATED_BY_PARAM(objParameterList , objDepartmentMaster.CreatedBy);
			UDSP_INSERT_DEPARTMENT_MASTER.CREATED_ON_PARAM(objParameterList , objDepartmentMaster.CreatedOn);
			UDSP_INSERT_DEPARTMENT_MASTER.MODIFIED_BY_PARAM(objParameterList , objDepartmentMaster.ModifiedBy);
			UDSP_INSERT_DEPARTMENT_MASTER.MODIFIED_ON_PARAM(objParameterList , objDepartmentMaster.ModifiedOn);
			UDSP_INSERT_DEPARTMENT_MASTER.RECORD_STATUS_PARAM(objParameterList , objDepartmentMaster.RecordStatus);
			try
			{
				Logger.LogInfo("DepartmentMasterDAO.cs : InsertDepartmentMaster() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strInsertDepartmentMaster, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) > 0 )
					{
						objDepartmentMaster.DepartmentId = Convert.ToInt32(dbExecuteStatus);
						objDepartmentMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objDepartmentMaster.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("DepartmentMasterDAO.cs : InsertDepartmentMaster() is ended with success.");
				}
				else
				{
					objDepartmentMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("DepartmentMasterDAO.cs : InsertDepartmentMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objDepartmentMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("DepartmentMasterDAO.cs : InsertDepartmentMaster() is ended with error.");
			}
			return objDepartmentMaster;
		}

		public DepartmentMaster UpdateDepartmentMaster(DepartmentMaster objDepartmentMaster)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_UPDATE_DEPARTMENT_MASTER.DEPARTMENT_ID_PARAM(objParameterList , objDepartmentMaster.DepartmentId);
			UDSP_UPDATE_DEPARTMENT_MASTER.DEPARTMENT_CODE_PARAM(objParameterList , objDepartmentMaster.DepartmentCode);
			UDSP_UPDATE_DEPARTMENT_MASTER.DEPARTMENT_NAME_PARAM(objParameterList , objDepartmentMaster.DepartmentName);
			UDSP_UPDATE_DEPARTMENT_MASTER.DESCRIPTION_PARAM(objParameterList , objDepartmentMaster.Description);
			if (objDepartmentMaster.Hod != null)
			{
				UDSP_UPDATE_DEPARTMENT_MASTER.HOD_PARAM(objParameterList , objDepartmentMaster.Hod.EmployeeId);
			}
			UDSP_UPDATE_DEPARTMENT_MASTER.VERSION_PARAM(objParameterList , objDepartmentMaster.Version);
			UDSP_UPDATE_DEPARTMENT_MASTER.CREATED_BY_PARAM(objParameterList , objDepartmentMaster.CreatedBy);
			UDSP_UPDATE_DEPARTMENT_MASTER.CREATED_ON_PARAM(objParameterList , objDepartmentMaster.CreatedOn);
			UDSP_UPDATE_DEPARTMENT_MASTER.MODIFIED_BY_PARAM(objParameterList , objDepartmentMaster.ModifiedBy);
			UDSP_UPDATE_DEPARTMENT_MASTER.MODIFIED_ON_PARAM(objParameterList , objDepartmentMaster.ModifiedOn);
			UDSP_UPDATE_DEPARTMENT_MASTER.RECORD_STATUS_PARAM(objParameterList , objDepartmentMaster.RecordStatus);
			try
			{
				Logger.LogInfo("DepartmentMasterDAO.cs : UpdateDepartmentMaster() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strUpdateDepartmentMaster, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objDepartmentMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
					{
						objDepartmentMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					else
					{
						objDepartmentMaster.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("DepartmentMasterDAO.cs : UpdateDepartmentMaster() is ended with success.");
				}
				else
				{
					objDepartmentMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("DepartmentMasterDAO.cs : UpdateDepartmentMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objDepartmentMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("DepartmentMasterDAO.cs : UpdateDepartmentMaster() is ended with error.");
			}
			return objDepartmentMaster;
		}

		public DepartmentMaster ActivateDeactivateDepartmentMaster(DepartmentMaster objDepartmentMaster)
		{
			try
			{
				Logger.LogInfo("DepartmentMasterDAO.cs : ActivateDeactivateDepartmentMasterDAO() is started.");
				dbExecuteStatus = DataUtility.ActivateDeactivateObject(strDBTableName, objDepartmentMaster.DepartmentId,
										objDepartmentMaster.Version, objDepartmentMaster.RecordStatus, objDepartmentMaster.ModifiedBy);
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objDepartmentMaster.DbOperationStatus = CommonConstant.SUCCEED;
						Logger.LogInfo("DepartmentMasterDAO.cs : ActivateDeactivateDepartmentMaster() is ended with success.");
					}
					else
					{
						objDepartmentMaster.DbOperationStatus = CommonConstant.INVALID;
						Logger.LogInfo("DepartmentMasterDAO.cs : ActivateDeactivateDepartmentMaster() is ended with success.");
					}
				}
				else
				{
					objDepartmentMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("DepartmentMasterDAO.cs : ActivateDeactivateDepartmentMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objDepartmentMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("DepartmentMasterDAO.cs : ActivateDeactivateDepartmentMaster() is ended with error.");
			}
			return objDepartmentMaster;
		}

		public DepartmentMaster SelectRecordById(DepartmentMaster objDepartmentMaster)
		{
			try
			{
				Logger.LogInfo("DepartmentMasterDAO.cs : SelectRecordById() is started.");
				objDepartmentMaster.ObjectDataSet = DataUtility.SelectRecordById(strDBTableName, objDepartmentMaster.DepartmentId, objDepartmentMaster.Version, strSelectDepartmentMaster);
				if (GeneralUtility.IsInteger(objDepartmentMaster.ObjectDataSet.Tables[0].Rows[0][0]) && (objDepartmentMaster.ObjectDataSet.Tables[1].Columns.Count > 1))
				{
					if (Convert.ToInt32(objDepartmentMaster.ObjectDataSet.Tables[0].Rows[0][0]) > 0)
					{
						objDepartmentMaster.IsRecordChanged = false;
						objDepartmentMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objDepartmentMaster.IsRecordChanged = true;
						objDepartmentMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					Logger.LogInfo("DepartmentMasterDAO.cs : SelectRecordById() is ended with success.");
				}
				else
				{
					objDepartmentMaster.DbOperationStatus = CommonConstant.FAIL;
					dbExecuteStatus = objDepartmentMaster.ObjectDataSet.Tables[0].Rows[0][0].ToString() + " " + objDepartmentMaster.ObjectDataSet.Tables[1].Rows[0][0].ToString();
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("DepartmentMasterDAO.cs : SelectRecordById() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objDepartmentMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("DepartmentMasterDAO.cs : SelectRecordById() is ended with error.");
			}
			return objDepartmentMaster;
		}
	}
}
