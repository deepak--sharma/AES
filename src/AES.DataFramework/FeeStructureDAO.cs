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
	public class FeeStructureDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "FEE_STRUCTURE";
		private string strSelectFeeStructure = "UDSP_SELECT_FEE_STRUCTURE";
		private string strInsertFeeStructure = "UDSP_INSERT_FEE_STRUCTURE";
		private string strUpdateFeeStructure = "UDSP_UPDATE_FEE_STRUCTURE";
		private string dbExecuteStatus = "";

		public FeeStructure SelectFeeStructure(FeeStructure objFeeStructure)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_FEE_STRUCTURE.FEE_STRUCTURE_ID_PARAM(objParameterList , objFeeStructure.FeeStructureId);
			UDSP_SELECT_FEE_STRUCTURE.FEE_STRUCTURE_NAME_PARAM(objParameterList , objFeeStructure.FeeStructureName);
			UDSP_SELECT_FEE_STRUCTURE.DESCRIPTION_PARAM(objParameterList , objFeeStructure.Description);
			UDSP_SELECT_FEE_STRUCTURE.RECORD_STATUS_PARAM(objParameterList , objFeeStructure.RecordStatus);
			try
			{
				Logger.LogInfo("FeeStructureDAO.cs : SelectFeeStructure() is started.");
				objFeeStructure.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectFeeStructure, CommandType.StoredProcedure);
				objFeeStructure.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("FeeStructureDAO.cs : SelectFeeStructure() is ended with success.");
			}
			catch (Exception ex)
			{
				objFeeStructure.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("FeeStructureDAO.cs : SelectFeeStructure() is ended with error.");
			}
			return objFeeStructure;
		}

		public FeeStructure InsertFeeStructure(FeeStructure objFeeStructure)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_INSERT_FEE_STRUCTURE.FEE_STRUCTURE_NAME_PARAM(objParameterList , objFeeStructure.FeeStructureName);
			UDSP_INSERT_FEE_STRUCTURE.DESCRIPTION_PARAM(objParameterList , objFeeStructure.Description);
			UDSP_INSERT_FEE_STRUCTURE.VERSION_PARAM(objParameterList , objFeeStructure.Version);
			UDSP_INSERT_FEE_STRUCTURE.CREATED_BY_PARAM(objParameterList , objFeeStructure.CreatedBy);
			UDSP_INSERT_FEE_STRUCTURE.CREATED_ON_PARAM(objParameterList , objFeeStructure.CreatedOn);
			UDSP_INSERT_FEE_STRUCTURE.MODIFIED_BY_PARAM(objParameterList , objFeeStructure.ModifiedBy);
			UDSP_INSERT_FEE_STRUCTURE.MODIFIED_ON_PARAM(objParameterList , objFeeStructure.ModifiedOn);
			UDSP_INSERT_FEE_STRUCTURE.RECORD_STATUS_PARAM(objParameterList , objFeeStructure.RecordStatus);
			try
			{
				Logger.LogInfo("FeeStructureDAO.cs : InsertFeeStructure() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strInsertFeeStructure, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) > 0 )
					{
						objFeeStructure.FeeStructureId = Convert.ToInt32(dbExecuteStatus);
						objFeeStructure.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objFeeStructure.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("FeeStructureDAO.cs : InsertFeeStructure() is ended with success.");
				}
				else
				{
					objFeeStructure.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("FeeStructureDAO.cs : InsertFeeStructure() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objFeeStructure.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("FeeStructureDAO.cs : InsertFeeStructure() is ended with error.");
			}
			return objFeeStructure;
		}

		public FeeStructure UpdateFeeStructure(FeeStructure objFeeStructure)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_UPDATE_FEE_STRUCTURE.FEE_STRUCTURE_ID_PARAM(objParameterList , objFeeStructure.FeeStructureId);
			UDSP_UPDATE_FEE_STRUCTURE.FEE_STRUCTURE_NAME_PARAM(objParameterList , objFeeStructure.FeeStructureName);
			UDSP_UPDATE_FEE_STRUCTURE.DESCRIPTION_PARAM(objParameterList , objFeeStructure.Description);
			UDSP_UPDATE_FEE_STRUCTURE.VERSION_PARAM(objParameterList , objFeeStructure.Version);
			UDSP_UPDATE_FEE_STRUCTURE.CREATED_BY_PARAM(objParameterList , objFeeStructure.CreatedBy);
			UDSP_UPDATE_FEE_STRUCTURE.CREATED_ON_PARAM(objParameterList , objFeeStructure.CreatedOn);
			UDSP_UPDATE_FEE_STRUCTURE.MODIFIED_BY_PARAM(objParameterList , objFeeStructure.ModifiedBy);
			UDSP_UPDATE_FEE_STRUCTURE.MODIFIED_ON_PARAM(objParameterList , objFeeStructure.ModifiedOn);
			UDSP_UPDATE_FEE_STRUCTURE.RECORD_STATUS_PARAM(objParameterList , objFeeStructure.RecordStatus);
			try
			{
				Logger.LogInfo("FeeStructureDAO.cs : UpdateFeeStructure() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strUpdateFeeStructure, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objFeeStructure.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
					{
						objFeeStructure.DbOperationStatus = CommonConstant.INVALID;
					}
					else
					{
						objFeeStructure.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("FeeStructureDAO.cs : UpdateFeeStructure() is ended with success.");
				}
				else
				{
					objFeeStructure.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("FeeStructureDAO.cs : UpdateFeeStructure() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objFeeStructure.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("FeeStructureDAO.cs : UpdateFeeStructure() is ended with error.");
			}
			return objFeeStructure;
		}

		public FeeStructure ActivateDeactivateFeeStructure(FeeStructure objFeeStructure)
		{
			try
			{
				Logger.LogInfo("FeeStructureDAO.cs : ActivateDeactivateFeeStructureDAO() is started.");
				dbExecuteStatus = DataUtility.ActivateDeactivateObject(strDBTableName, objFeeStructure.FeeStructureId,
										objFeeStructure.Version, objFeeStructure.RecordStatus, objFeeStructure.ModifiedBy);
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objFeeStructure.DbOperationStatus = CommonConstant.SUCCEED;
						Logger.LogInfo("FeeStructureDAO.cs : ActivateDeactivateFeeStructure() is ended with success.");
					}
					else
					{
						objFeeStructure.DbOperationStatus = CommonConstant.INVALID;
						Logger.LogInfo("FeeStructureDAO.cs : ActivateDeactivateFeeStructure() is ended with success.");
					}
				}
				else
				{
					objFeeStructure.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("FeeStructureDAO.cs : ActivateDeactivateFeeStructure() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objFeeStructure.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("FeeStructureDAO.cs : ActivateDeactivateFeeStructure() is ended with error.");
			}
			return objFeeStructure;
		}

		public FeeStructure SelectRecordById(FeeStructure objFeeStructure)
		{
			try
			{
				Logger.LogInfo("FeeStructureDAO.cs : SelectRecordById() is started.");
				objFeeStructure.ObjectDataSet = DataUtility.SelectRecordById(strDBTableName, objFeeStructure.FeeStructureId, objFeeStructure.Version, strSelectFeeStructure);
				if (GeneralUtility.IsInteger(objFeeStructure.ObjectDataSet.Tables[0].Rows[0][0]) && (objFeeStructure.ObjectDataSet.Tables[1].Columns.Count > 1))
				{
					if (Convert.ToInt32(objFeeStructure.ObjectDataSet.Tables[0].Rows[0][0]) > 0)
					{
						objFeeStructure.IsRecordChanged = false;
						objFeeStructure.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objFeeStructure.IsRecordChanged = true;
						objFeeStructure.DbOperationStatus = CommonConstant.INVALID;
					}
					Logger.LogInfo("FeeStructureDAO.cs : SelectRecordById() is ended with success.");
				}
				else
				{
					objFeeStructure.DbOperationStatus = CommonConstant.FAIL;
					dbExecuteStatus = objFeeStructure.ObjectDataSet.Tables[0].Rows[0][0].ToString() + " " + objFeeStructure.ObjectDataSet.Tables[1].Rows[0][0].ToString();
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("FeeStructureDAO.cs : SelectRecordById() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objFeeStructure.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("FeeStructureDAO.cs : SelectRecordById() is ended with error.");
			}
			return objFeeStructure;
		}
	}
}
