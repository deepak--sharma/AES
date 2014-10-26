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
	public class SchoolMasterDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "SCHOOL_MASTER";
		private string strSelectSchoolMaster = "UDSP_SELECT_SCHOOL_MASTER";
		private string strInsertSchoolMaster = "UDSP_INSERT_SCHOOL_MASTER";
		private string strUpdateSchoolMaster = "UDSP_UPDATE_SCHOOL_MASTER";
		private string dbExecuteStatus = "";

		public SchoolMaster SelectSchoolMaster(SchoolMaster objSchoolMaster)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_SCHOOL_MASTER.SCHOOL_ID_PARAM(objParameterList , objSchoolMaster.SchoolId);
			UDSP_SELECT_SCHOOL_MASTER.SCHOOL_CODE_PARAM(objParameterList , objSchoolMaster.SchoolCode);
			UDSP_SELECT_SCHOOL_MASTER.SCHOOL_NAME_PARAM(objParameterList , objSchoolMaster.SchoolName);
			UDSP_SELECT_SCHOOL_MASTER.SCHOOL_HEAD_PARAM(objParameterList , objSchoolMaster.SchoolHead);
			UDSP_SELECT_SCHOOL_MASTER.ESTABLISHED_ON_PARAM(objParameterList , objSchoolMaster.EstablishedOn);
			UDSP_SELECT_SCHOOL_MASTER.LOGO_PARAM(objParameterList , objSchoolMaster.Logo);
			UDSP_SELECT_SCHOOL_MASTER.WEB_ADDRESS_PARAM(objParameterList , objSchoolMaster.WebAddress);
			if (objSchoolMaster.SchoolAddressObject != null)
			{
				UDSP_SELECT_SCHOOL_MASTER.SCHOOL_ADDRESS_ID_PARAM(objParameterList , objSchoolMaster.SchoolAddressObject.AddressId);
			}
			UDSP_SELECT_SCHOOL_MASTER.DESCRIPTION_PARAM(objParameterList , objSchoolMaster.Description);
			UDSP_SELECT_SCHOOL_MASTER.RECORD_STATUS_PARAM(objParameterList , objSchoolMaster.RecordStatus);
			try
			{
				Logger.LogInfo("SchoolMasterDAO.cs : SelectSchoolMaster() is started.");
				objSchoolMaster.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectSchoolMaster, CommandType.StoredProcedure);
				objSchoolMaster.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("SchoolMasterDAO.cs : SelectSchoolMaster() is ended with success.");
			}
			catch (Exception ex)
			{
				objSchoolMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("SchoolMasterDAO.cs : SelectSchoolMaster() is ended with error.");
			}
			return objSchoolMaster;
		}

		public SchoolMaster InsertSchoolMaster(SchoolMaster objSchoolMaster)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_INSERT_SCHOOL_MASTER.SCHOOL_CODE_PARAM(objParameterList , objSchoolMaster.SchoolCode);
			UDSP_INSERT_SCHOOL_MASTER.SCHOOL_NAME_PARAM(objParameterList , objSchoolMaster.SchoolName);
			UDSP_INSERT_SCHOOL_MASTER.SCHOOL_HEAD_PARAM(objParameterList , objSchoolMaster.SchoolHead);
			UDSP_INSERT_SCHOOL_MASTER.ESTABLISHED_ON_PARAM(objParameterList , objSchoolMaster.EstablishedOn);
			UDSP_INSERT_SCHOOL_MASTER.LOGO_PARAM(objParameterList , objSchoolMaster.Logo);
			UDSP_INSERT_SCHOOL_MASTER.WEB_ADDRESS_PARAM(objParameterList , objSchoolMaster.WebAddress);
			if (objSchoolMaster.SchoolAddressObject != null)
			{
				UDSP_INSERT_SCHOOL_MASTER.SCHOOL_ADDRESS_ID_PARAM(objParameterList , objSchoolMaster.SchoolAddressObject.AddressId);
			}
			UDSP_INSERT_SCHOOL_MASTER.DESCRIPTION_PARAM(objParameterList , objSchoolMaster.Description);
			UDSP_INSERT_SCHOOL_MASTER.VERSION_PARAM(objParameterList , objSchoolMaster.Version);
			UDSP_INSERT_SCHOOL_MASTER.CREATED_BY_PARAM(objParameterList , objSchoolMaster.CreatedBy);
			UDSP_INSERT_SCHOOL_MASTER.CREATED_ON_PARAM(objParameterList , objSchoolMaster.CreatedOn);
			UDSP_INSERT_SCHOOL_MASTER.MODIFIED_BY_PARAM(objParameterList , objSchoolMaster.ModifiedBy);
			UDSP_INSERT_SCHOOL_MASTER.MODIFIED_ON_PARAM(objParameterList , objSchoolMaster.ModifiedOn);
			UDSP_INSERT_SCHOOL_MASTER.RECORD_STATUS_PARAM(objParameterList , objSchoolMaster.RecordStatus);
			try
			{
				Logger.LogInfo("SchoolMasterDAO.cs : InsertSchoolMaster() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strInsertSchoolMaster, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) > 0 )
					{
						objSchoolMaster.SchoolId = Convert.ToInt32(dbExecuteStatus);
						objSchoolMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objSchoolMaster.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("SchoolMasterDAO.cs : InsertSchoolMaster() is ended with success.");
				}
				else
				{
					objSchoolMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("SchoolMasterDAO.cs : InsertSchoolMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objSchoolMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("SchoolMasterDAO.cs : InsertSchoolMaster() is ended with error.");
			}
			return objSchoolMaster;
		}

		public SchoolMaster UpdateSchoolMaster(SchoolMaster objSchoolMaster)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_UPDATE_SCHOOL_MASTER.SCHOOL_ID_PARAM(objParameterList , objSchoolMaster.SchoolId);
			UDSP_UPDATE_SCHOOL_MASTER.SCHOOL_CODE_PARAM(objParameterList , objSchoolMaster.SchoolCode);
			UDSP_UPDATE_SCHOOL_MASTER.SCHOOL_NAME_PARAM(objParameterList , objSchoolMaster.SchoolName);
			UDSP_UPDATE_SCHOOL_MASTER.SCHOOL_HEAD_PARAM(objParameterList , objSchoolMaster.SchoolHead);
			UDSP_UPDATE_SCHOOL_MASTER.ESTABLISHED_ON_PARAM(objParameterList , objSchoolMaster.EstablishedOn);
			UDSP_UPDATE_SCHOOL_MASTER.LOGO_PARAM(objParameterList , objSchoolMaster.Logo);
			UDSP_UPDATE_SCHOOL_MASTER.WEB_ADDRESS_PARAM(objParameterList , objSchoolMaster.WebAddress);
			if (objSchoolMaster.SchoolAddressObject != null)
			{
				UDSP_UPDATE_SCHOOL_MASTER.SCHOOL_ADDRESS_ID_PARAM(objParameterList , objSchoolMaster.SchoolAddressObject.AddressId);
			}
			UDSP_UPDATE_SCHOOL_MASTER.DESCRIPTION_PARAM(objParameterList , objSchoolMaster.Description);
			UDSP_UPDATE_SCHOOL_MASTER.VERSION_PARAM(objParameterList , objSchoolMaster.Version);
			UDSP_UPDATE_SCHOOL_MASTER.CREATED_BY_PARAM(objParameterList , objSchoolMaster.CreatedBy);
			UDSP_UPDATE_SCHOOL_MASTER.CREATED_ON_PARAM(objParameterList , objSchoolMaster.CreatedOn);
			UDSP_UPDATE_SCHOOL_MASTER.MODIFIED_BY_PARAM(objParameterList , objSchoolMaster.ModifiedBy);
			UDSP_UPDATE_SCHOOL_MASTER.MODIFIED_ON_PARAM(objParameterList , objSchoolMaster.ModifiedOn);
			UDSP_UPDATE_SCHOOL_MASTER.RECORD_STATUS_PARAM(objParameterList , objSchoolMaster.RecordStatus);
			try
			{
				Logger.LogInfo("SchoolMasterDAO.cs : UpdateSchoolMaster() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strUpdateSchoolMaster, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objSchoolMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
					{
						objSchoolMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					else
					{
						objSchoolMaster.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("SchoolMasterDAO.cs : UpdateSchoolMaster() is ended with success.");
				}
				else
				{
					objSchoolMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("SchoolMasterDAO.cs : UpdateSchoolMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objSchoolMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("SchoolMasterDAO.cs : UpdateSchoolMaster() is ended with error.");
			}
			return objSchoolMaster;
		}

		public SchoolMaster ActivateDeactivateSchoolMaster(SchoolMaster objSchoolMaster)
		{
			try
			{
				Logger.LogInfo("SchoolMasterDAO.cs : ActivateDeactivateSchoolMasterDAO() is started.");
				dbExecuteStatus = DataUtility.ActivateDeactivateObject(strDBTableName, objSchoolMaster.SchoolId,
										objSchoolMaster.Version, objSchoolMaster.RecordStatus, objSchoolMaster.ModifiedBy);
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objSchoolMaster.DbOperationStatus = CommonConstant.SUCCEED;
						Logger.LogInfo("SchoolMasterDAO.cs : ActivateDeactivateSchoolMaster() is ended with success.");
					}
					else
					{
						objSchoolMaster.DbOperationStatus = CommonConstant.INVALID;
						Logger.LogInfo("SchoolMasterDAO.cs : ActivateDeactivateSchoolMaster() is ended with success.");
					}
				}
				else
				{
					objSchoolMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("SchoolMasterDAO.cs : ActivateDeactivateSchoolMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objSchoolMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("SchoolMasterDAO.cs : ActivateDeactivateSchoolMaster() is ended with error.");
			}
			return objSchoolMaster;
		}

		public SchoolMaster SelectRecordById(SchoolMaster objSchoolMaster)
		{
			try
			{
				Logger.LogInfo("SchoolMasterDAO.cs : SelectRecordById() is started.");
				objSchoolMaster.ObjectDataSet = DataUtility.SelectRecordById(strDBTableName, objSchoolMaster.SchoolId, objSchoolMaster.Version, strSelectSchoolMaster);
				if (GeneralUtility.IsInteger(objSchoolMaster.ObjectDataSet.Tables[0].Rows[0][0]) && (objSchoolMaster.ObjectDataSet.Tables[1].Columns.Count > 1))
				{
					if (Convert.ToInt32(objSchoolMaster.ObjectDataSet.Tables[0].Rows[0][0]) > 0)
					{
						objSchoolMaster.IsRecordChanged = false;
						objSchoolMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objSchoolMaster.IsRecordChanged = true;
						objSchoolMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					Logger.LogInfo("SchoolMasterDAO.cs : SelectRecordById() is ended with success.");
				}
				else
				{
					objSchoolMaster.DbOperationStatus = CommonConstant.FAIL;
					dbExecuteStatus = objSchoolMaster.ObjectDataSet.Tables[0].Rows[0][0].ToString() + " " + objSchoolMaster.ObjectDataSet.Tables[1].Rows[0][0].ToString();
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("SchoolMasterDAO.cs : SelectRecordById() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objSchoolMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("SchoolMasterDAO.cs : SelectRecordById() is ended with error.");
			}
			return objSchoolMaster;
		}
	}
}
