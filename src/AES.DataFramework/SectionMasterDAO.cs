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
	public class SectionMasterDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "SECTION_MASTER";
		private string strSelectSectionMaster = "UDSP_SELECT_SECTION_MASTER";
		private string strInsertSectionMaster = "UDSP_INSERT_SECTION_MASTER";
		private string strUpdateSectionMaster = "UDSP_UPDATE_SECTION_MASTER";
		private string dbExecuteStatus = "";

		public SectionMaster SelectSectionMaster(SectionMaster objSectionMaster)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_SECTION_MASTER.SECTION_ID_PARAM(objParameterList , objSectionMaster.SectionId);
			UDSP_SELECT_SECTION_MASTER.SECTION_NAME_PARAM(objParameterList , objSectionMaster.SectionName);
			UDSP_SELECT_SECTION_MASTER.DESCRIPTION_PARAM(objParameterList , objSectionMaster.Description);
			UDSP_SELECT_SECTION_MASTER.RECORD_STATUS_PARAM(objParameterList , objSectionMaster.RecordStatus);
			try
			{
				Logger.LogInfo("SectionMasterDAO.cs : SelectSectionMaster() is started.");
				objSectionMaster.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectSectionMaster, CommandType.StoredProcedure);
				objSectionMaster.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("SectionMasterDAO.cs : SelectSectionMaster() is ended with success.");
			}
			catch (Exception ex)
			{
				objSectionMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("SectionMasterDAO.cs : SelectSectionMaster() is ended with error.");
			}
			return objSectionMaster;
		}

		public SectionMaster InsertSectionMaster(SectionMaster objSectionMaster)
		{
			objParameterList = new List<SqlParameter>();				
			
			UDSP_INSERT_SECTION_MASTER.SECTION_NAME_PARAM(objParameterList , objSectionMaster.SectionName);
			UDSP_INSERT_SECTION_MASTER.DESCRIPTION_PARAM(objParameterList , objSectionMaster.Description);
			UDSP_INSERT_SECTION_MASTER.VERSION_PARAM(objParameterList , objSectionMaster.Version);
			UDSP_INSERT_SECTION_MASTER.CREATED_BY_PARAM(objParameterList , objSectionMaster.CreatedBy);
			UDSP_INSERT_SECTION_MASTER.CREATED_ON_PARAM(objParameterList , objSectionMaster.CreatedOn);
			UDSP_INSERT_SECTION_MASTER.MODIFIED_BY_PARAM(objParameterList , objSectionMaster.ModifiedBy);
			UDSP_INSERT_SECTION_MASTER.MODIFIED_ON_PARAM(objParameterList , objSectionMaster.ModifiedOn);
			UDSP_INSERT_SECTION_MASTER.RECORD_STATUS_PARAM(objParameterList , objSectionMaster.RecordStatus);
			try
			{
				Logger.LogInfo("SectionMasterDAO.cs : InsertSectionMaster() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strInsertSectionMaster, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) > 0 )
					{
						objSectionMaster.SectionId = Convert.ToInt32(dbExecuteStatus);
						objSectionMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objSectionMaster.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("SectionMasterDAO.cs : InsertSectionMaster() is ended with success.");
				}
				else
				{
					objSectionMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("SectionMasterDAO.cs : InsertSectionMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objSectionMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("SectionMasterDAO.cs : InsertSectionMaster() is ended with error.");
			}
			return objSectionMaster;
		}

		public SectionMaster UpdateSectionMaster(SectionMaster objSectionMaster)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_UPDATE_SECTION_MASTER.SECTION_ID_PARAM(objParameterList , objSectionMaster.SectionId);			
			UDSP_UPDATE_SECTION_MASTER.SECTION_NAME_PARAM(objParameterList , objSectionMaster.SectionName);
			UDSP_UPDATE_SECTION_MASTER.DESCRIPTION_PARAM(objParameterList , objSectionMaster.Description);
			UDSP_UPDATE_SECTION_MASTER.VERSION_PARAM(objParameterList , objSectionMaster.Version);
			UDSP_UPDATE_SECTION_MASTER.CREATED_BY_PARAM(objParameterList , objSectionMaster.CreatedBy);
			UDSP_UPDATE_SECTION_MASTER.CREATED_ON_PARAM(objParameterList , objSectionMaster.CreatedOn);
			UDSP_UPDATE_SECTION_MASTER.MODIFIED_BY_PARAM(objParameterList , objSectionMaster.ModifiedBy);
			UDSP_UPDATE_SECTION_MASTER.MODIFIED_ON_PARAM(objParameterList , objSectionMaster.ModifiedOn);
			UDSP_UPDATE_SECTION_MASTER.RECORD_STATUS_PARAM(objParameterList , objSectionMaster.RecordStatus);
			try
			{
				Logger.LogInfo("SectionMasterDAO.cs : UpdateSectionMaster() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strUpdateSectionMaster, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objSectionMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
					{
						objSectionMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					else
					{
						objSectionMaster.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("SectionMasterDAO.cs : UpdateSectionMaster() is ended with success.");
				}
				else
				{
					objSectionMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("SectionMasterDAO.cs : UpdateSectionMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objSectionMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("SectionMasterDAO.cs : UpdateSectionMaster() is ended with error.");
			}
			return objSectionMaster;
		}

		public SectionMaster ActivateDeactivateSectionMaster(SectionMaster objSectionMaster)
		{
			try
			{
				Logger.LogInfo("SectionMasterDAO.cs : ActivateDeactivateSectionMasterDAO() is started.");
				dbExecuteStatus = DataUtility.ActivateDeactivateObject(strDBTableName, objSectionMaster.SectionId,
										objSectionMaster.Version, objSectionMaster.RecordStatus, objSectionMaster.ModifiedBy);
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objSectionMaster.DbOperationStatus = CommonConstant.SUCCEED;
						Logger.LogInfo("SectionMasterDAO.cs : ActivateDeactivateSectionMaster() is ended with success.");
					}
					else
					{
						objSectionMaster.DbOperationStatus = CommonConstant.INVALID;
						Logger.LogInfo("SectionMasterDAO.cs : ActivateDeactivateSectionMaster() is ended with success.");
					}
				}
				else
				{
					objSectionMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("SectionMasterDAO.cs : ActivateDeactivateSectionMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objSectionMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("SectionMasterDAO.cs : ActivateDeactivateSectionMaster() is ended with error.");
			}
			return objSectionMaster;
		}

		public SectionMaster SelectRecordById(SectionMaster objSectionMaster)
		{
			try
			{
				Logger.LogInfo("SectionMasterDAO.cs : SelectRecordById() is started.");
				objSectionMaster.ObjectDataSet = DataUtility.SelectRecordById(strDBTableName, objSectionMaster.SectionId, objSectionMaster.Version, strSelectSectionMaster);
				if (GeneralUtility.IsInteger(objSectionMaster.ObjectDataSet.Tables[0].Rows[0][0]) && (objSectionMaster.ObjectDataSet.Tables[1].Columns.Count > 1))
				{
					if (Convert.ToInt32(objSectionMaster.ObjectDataSet.Tables[0].Rows[0][0]) > 0)
					{
						objSectionMaster.IsRecordChanged = false;
						objSectionMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objSectionMaster.IsRecordChanged = true;
						objSectionMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					Logger.LogInfo("SectionMasterDAO.cs : SelectRecordById() is ended with success.");
				}
				else
				{
					objSectionMaster.DbOperationStatus = CommonConstant.FAIL;
					dbExecuteStatus = objSectionMaster.ObjectDataSet.Tables[0].Rows[0][0].ToString() + " " + objSectionMaster.ObjectDataSet.Tables[1].Rows[0][0].ToString();
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("SectionMasterDAO.cs : SelectRecordById() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objSectionMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("SectionMasterDAO.cs : SelectRecordById() is ended with error.");
			}
			return objSectionMaster;
		}
	}
}
