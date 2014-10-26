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
	public class CompanyMasterDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "COMPANY_MASTER";
		private string strSelectCompanyMaster = "UDSP_SELECT_COMPANY_MASTER";
		private string strInsertCompanyMaster = "UDSP_INSERT_COMPANY_MASTER";
		private string strUpdateCompanyMaster = "UDSP_UPDATE_COMPANY_MASTER";
		private string dbExecuteStatus = "";

		public CompanyMaster SelectCompanyMaster(CompanyMaster objCompanyMaster)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_COMPANY_MASTER.COMPANY_ID_PARAM(objParameterList , objCompanyMaster.CompanyId);
			UDSP_SELECT_COMPANY_MASTER.COMPANY_NAME_PARAM(objParameterList , objCompanyMaster.CompanyName);
			UDSP_SELECT_COMPANY_MASTER.LST_NO_PARAM(objParameterList , objCompanyMaster.LstNo);
			UDSP_SELECT_COMPANY_MASTER.CST_NO_PARAM(objParameterList , objCompanyMaster.CstNo);
			UDSP_SELECT_COMPANY_MASTER.EXCISE_NO_PARAM(objParameterList , objCompanyMaster.ExciseNo);
			UDSP_SELECT_COMPANY_MASTER.ECC_NO_PARAM(objParameterList , objCompanyMaster.EccNo);
			UDSP_SELECT_COMPANY_MASTER.IEN_NO_PARAM(objParameterList , objCompanyMaster.IenNo);
			if (objCompanyMaster.CompanyAddressObject != null)
			{
				UDSP_SELECT_COMPANY_MASTER.COMPANY_ADDRESS_ID_PARAM(objParameterList , objCompanyMaster.CompanyAddressObject.AddressId);
			}
			UDSP_SELECT_COMPANY_MASTER.RECORD_STATUS_PARAM(objParameterList , objCompanyMaster.RecordStatus);
			try
			{
				Logger.LogInfo("CompanyMasterDAO.cs : SelectCompanyMaster() is started.");
				objCompanyMaster.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectCompanyMaster, CommandType.StoredProcedure);
				objCompanyMaster.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("CompanyMasterDAO.cs : SelectCompanyMaster() is ended with success.");
			}
			catch (Exception ex)
			{
				objCompanyMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("CompanyMasterDAO.cs : SelectCompanyMaster() is ended with error.");
			}
			return objCompanyMaster;
		}

		public CompanyMaster InsertCompanyMaster(CompanyMaster objCompanyMaster)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_INSERT_COMPANY_MASTER.COMPANY_NAME_PARAM(objParameterList , objCompanyMaster.CompanyName);
			UDSP_INSERT_COMPANY_MASTER.LST_NO_PARAM(objParameterList , objCompanyMaster.LstNo);
			UDSP_INSERT_COMPANY_MASTER.CST_NO_PARAM(objParameterList , objCompanyMaster.CstNo);
			UDSP_INSERT_COMPANY_MASTER.EXCISE_NO_PARAM(objParameterList , objCompanyMaster.ExciseNo);
			UDSP_INSERT_COMPANY_MASTER.ECC_NO_PARAM(objParameterList , objCompanyMaster.EccNo);
			UDSP_INSERT_COMPANY_MASTER.IEN_NO_PARAM(objParameterList , objCompanyMaster.IenNo);
			if (objCompanyMaster.CompanyAddressObject != null)
			{
				UDSP_INSERT_COMPANY_MASTER.COMPANY_ADDRESS_ID_PARAM(objParameterList , objCompanyMaster.CompanyAddressObject.AddressId);
			}
			UDSP_INSERT_COMPANY_MASTER.VERSION_PARAM(objParameterList , objCompanyMaster.Version);
			UDSP_INSERT_COMPANY_MASTER.CREATED_BY_PARAM(objParameterList , objCompanyMaster.CreatedBy);
			UDSP_INSERT_COMPANY_MASTER.CREATED_ON_PARAM(objParameterList , objCompanyMaster.CreatedOn);
			UDSP_INSERT_COMPANY_MASTER.MODIFIED_BY_PARAM(objParameterList , objCompanyMaster.ModifiedBy);
			UDSP_INSERT_COMPANY_MASTER.MODIFIED_ON_PARAM(objParameterList , objCompanyMaster.ModifiedOn);
			UDSP_INSERT_COMPANY_MASTER.RECORD_STATUS_PARAM(objParameterList , objCompanyMaster.RecordStatus);
			try
			{
				Logger.LogInfo("CompanyMasterDAO.cs : InsertCompanyMaster() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strInsertCompanyMaster, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) > 0 )
					{
						objCompanyMaster.CompanyId = Convert.ToInt32(dbExecuteStatus);
						objCompanyMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objCompanyMaster.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("CompanyMasterDAO.cs : InsertCompanyMaster() is ended with success.");
				}
				else
				{
					objCompanyMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("CompanyMasterDAO.cs : InsertCompanyMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objCompanyMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("CompanyMasterDAO.cs : InsertCompanyMaster() is ended with error.");
			}
			return objCompanyMaster;
		}

		public CompanyMaster UpdateCompanyMaster(CompanyMaster objCompanyMaster)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_UPDATE_COMPANY_MASTER.COMPANY_ID_PARAM(objParameterList , objCompanyMaster.CompanyId);
			UDSP_UPDATE_COMPANY_MASTER.COMPANY_NAME_PARAM(objParameterList , objCompanyMaster.CompanyName);
			UDSP_UPDATE_COMPANY_MASTER.LST_NO_PARAM(objParameterList , objCompanyMaster.LstNo);
			UDSP_UPDATE_COMPANY_MASTER.CST_NO_PARAM(objParameterList , objCompanyMaster.CstNo);
			UDSP_UPDATE_COMPANY_MASTER.EXCISE_NO_PARAM(objParameterList , objCompanyMaster.ExciseNo);
			UDSP_UPDATE_COMPANY_MASTER.ECC_NO_PARAM(objParameterList , objCompanyMaster.EccNo);
			UDSP_UPDATE_COMPANY_MASTER.IEN_NO_PARAM(objParameterList , objCompanyMaster.IenNo);
			if (objCompanyMaster.CompanyAddressObject != null)
			{
				UDSP_UPDATE_COMPANY_MASTER.COMPANY_ADDRESS_ID_PARAM(objParameterList , objCompanyMaster.CompanyAddressObject.AddressId);
			}
			UDSP_UPDATE_COMPANY_MASTER.VERSION_PARAM(objParameterList , objCompanyMaster.Version);
			UDSP_UPDATE_COMPANY_MASTER.CREATED_BY_PARAM(objParameterList , objCompanyMaster.CreatedBy);
			UDSP_UPDATE_COMPANY_MASTER.CREATED_ON_PARAM(objParameterList , objCompanyMaster.CreatedOn);
			UDSP_UPDATE_COMPANY_MASTER.MODIFIED_BY_PARAM(objParameterList , objCompanyMaster.ModifiedBy);
			UDSP_UPDATE_COMPANY_MASTER.MODIFIED_ON_PARAM(objParameterList , objCompanyMaster.ModifiedOn);
			UDSP_UPDATE_COMPANY_MASTER.RECORD_STATUS_PARAM(objParameterList , objCompanyMaster.RecordStatus);
			try
			{
				Logger.LogInfo("CompanyMasterDAO.cs : UpdateCompanyMaster() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strUpdateCompanyMaster, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objCompanyMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
					{
						objCompanyMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					else
					{
						objCompanyMaster.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("CompanyMasterDAO.cs : UpdateCompanyMaster() is ended with success.");
				}
				else
				{
					objCompanyMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("CompanyMasterDAO.cs : UpdateCompanyMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objCompanyMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("CompanyMasterDAO.cs : UpdateCompanyMaster() is ended with error.");
			}
			return objCompanyMaster;
		}

		public CompanyMaster ActivateDeactivateCompanyMaster(CompanyMaster objCompanyMaster)
		{
			try
			{
				Logger.LogInfo("CompanyMasterDAO.cs : ActivateDeactivateCompanyMasterDAO() is started.");
				dbExecuteStatus = DataUtility.ActivateDeactivateObject(strDBTableName, objCompanyMaster.CompanyId,
										objCompanyMaster.Version, objCompanyMaster.RecordStatus, objCompanyMaster.ModifiedBy);
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objCompanyMaster.DbOperationStatus = CommonConstant.SUCCEED;
						Logger.LogInfo("CompanyMasterDAO.cs : ActivateDeactivateCompanyMaster() is ended with success.");
					}
					else
					{
						objCompanyMaster.DbOperationStatus = CommonConstant.INVALID;
						Logger.LogInfo("CompanyMasterDAO.cs : ActivateDeactivateCompanyMaster() is ended with success.");
					}
				}
				else
				{
					objCompanyMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("CompanyMasterDAO.cs : ActivateDeactivateCompanyMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objCompanyMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("CompanyMasterDAO.cs : ActivateDeactivateCompanyMaster() is ended with error.");
			}
			return objCompanyMaster;
		}

		public CompanyMaster SelectRecordById(CompanyMaster objCompanyMaster)
		{
			try
			{
				Logger.LogInfo("CompanyMasterDAO.cs : SelectRecordById() is started.");
				objCompanyMaster.ObjectDataSet = DataUtility.SelectRecordById(strDBTableName, objCompanyMaster.CompanyId, objCompanyMaster.Version, strSelectCompanyMaster);
				if (GeneralUtility.IsInteger(objCompanyMaster.ObjectDataSet.Tables[0].Rows[0][0]) && (objCompanyMaster.ObjectDataSet.Tables[1].Columns.Count > 1))
				{
					if (Convert.ToInt32(objCompanyMaster.ObjectDataSet.Tables[0].Rows[0][0]) > 0)
					{
						objCompanyMaster.IsRecordChanged = false;
						objCompanyMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objCompanyMaster.IsRecordChanged = true;
						objCompanyMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					Logger.LogInfo("CompanyMasterDAO.cs : SelectRecordById() is ended with success.");
				}
				else
				{
					objCompanyMaster.DbOperationStatus = CommonConstant.FAIL;
					dbExecuteStatus = objCompanyMaster.ObjectDataSet.Tables[0].Rows[0][0].ToString() + " " + objCompanyMaster.ObjectDataSet.Tables[1].Rows[0][0].ToString();
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("CompanyMasterDAO.cs : SelectRecordById() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objCompanyMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("CompanyMasterDAO.cs : SelectRecordById() is ended with error.");
			}
			return objCompanyMaster;
		}
	}
}
