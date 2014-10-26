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
	public class GradeMasterDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "GRADE_MASTER";
		private string strSelectGradeMaster = "UDSP_SELECT_GRADE_MASTER";
		private string strInsertGradeMaster = "UDSP_INSERT_GRADE_MASTER";
		private string strUpdateGradeMaster = "UDSP_UPDATE_GRADE_MASTER";
		private string dbExecuteStatus = "";

		public GradeMaster SelectGradeMaster(GradeMaster objGradeMaster)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_GRADE_MASTER.GRADE_ID_PARAM(objParameterList , objGradeMaster.GradeId);
			UDSP_SELECT_GRADE_MASTER.GRADE_NAME_PARAM(objParameterList , objGradeMaster.GradeName);
			UDSP_SELECT_GRADE_MASTER.DESCRIPTION_PARAM(objParameterList , objGradeMaster.Description);
			UDSP_SELECT_GRADE_MASTER.RECORD_STATUS_PARAM(objParameterList , objGradeMaster.RecordStatus);
			try
			{
				Logger.LogInfo("GradeMasterDAO.cs : SelectGradeMaster() is started.");
				objGradeMaster.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectGradeMaster, CommandType.StoredProcedure);
				objGradeMaster.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("GradeMasterDAO.cs : SelectGradeMaster() is ended with success.");
			}
			catch (Exception ex)
			{
				objGradeMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("GradeMasterDAO.cs : SelectGradeMaster() is ended with error.");
			}
			return objGradeMaster;
		}

		public GradeMaster InsertGradeMaster(GradeMaster objGradeMaster)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_INSERT_GRADE_MASTER.GRADE_NAME_PARAM(objParameterList , objGradeMaster.GradeName);
			UDSP_INSERT_GRADE_MASTER.DESCRIPTION_PARAM(objParameterList , objGradeMaster.Description);
			UDSP_INSERT_GRADE_MASTER.VERSION_PARAM(objParameterList , objGradeMaster.Version);
			UDSP_INSERT_GRADE_MASTER.CREATED_BY_PARAM(objParameterList , objGradeMaster.CreatedBy);
			UDSP_INSERT_GRADE_MASTER.CREATED_ON_PARAM(objParameterList , objGradeMaster.CreatedOn);
			UDSP_INSERT_GRADE_MASTER.MODIFIED_BY_PARAM(objParameterList , objGradeMaster.ModifiedBy);
			UDSP_INSERT_GRADE_MASTER.MODIFIED_ON_PARAM(objParameterList , objGradeMaster.ModifiedOn);
			UDSP_INSERT_GRADE_MASTER.RECORD_STATUS_PARAM(objParameterList , objGradeMaster.RecordStatus);
			try
			{
				Logger.LogInfo("GradeMasterDAO.cs : InsertGradeMaster() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strInsertGradeMaster, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) > 0 )
					{
						objGradeMaster.GradeId = Convert.ToInt32(dbExecuteStatus);
						objGradeMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objGradeMaster.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("GradeMasterDAO.cs : InsertGradeMaster() is ended with success.");
				}
				else
				{
					objGradeMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("GradeMasterDAO.cs : InsertGradeMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objGradeMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("GradeMasterDAO.cs : InsertGradeMaster() is ended with error.");
			}
			return objGradeMaster;
		}

		public GradeMaster UpdateGradeMaster(GradeMaster objGradeMaster)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_UPDATE_GRADE_MASTER.GRADE_ID_PARAM(objParameterList , objGradeMaster.GradeId);
			UDSP_UPDATE_GRADE_MASTER.GRADE_NAME_PARAM(objParameterList , objGradeMaster.GradeName);
			UDSP_UPDATE_GRADE_MASTER.DESCRIPTION_PARAM(objParameterList , objGradeMaster.Description);
			UDSP_UPDATE_GRADE_MASTER.VERSION_PARAM(objParameterList , objGradeMaster.Version);
			UDSP_UPDATE_GRADE_MASTER.CREATED_BY_PARAM(objParameterList , objGradeMaster.CreatedBy);
			UDSP_UPDATE_GRADE_MASTER.CREATED_ON_PARAM(objParameterList , objGradeMaster.CreatedOn);
			UDSP_UPDATE_GRADE_MASTER.MODIFIED_BY_PARAM(objParameterList , objGradeMaster.ModifiedBy);
			UDSP_UPDATE_GRADE_MASTER.MODIFIED_ON_PARAM(objParameterList , objGradeMaster.ModifiedOn);
			UDSP_UPDATE_GRADE_MASTER.RECORD_STATUS_PARAM(objParameterList , objGradeMaster.RecordStatus);
			try
			{
				Logger.LogInfo("GradeMasterDAO.cs : UpdateGradeMaster() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strUpdateGradeMaster, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objGradeMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
					{
						objGradeMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					else
					{
						objGradeMaster.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("GradeMasterDAO.cs : UpdateGradeMaster() is ended with success.");
				}
				else
				{
					objGradeMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("GradeMasterDAO.cs : UpdateGradeMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objGradeMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("GradeMasterDAO.cs : UpdateGradeMaster() is ended with error.");
			}
			return objGradeMaster;
		}

		public GradeMaster ActivateDeactivateGradeMaster(GradeMaster objGradeMaster)
		{
			try
			{
				Logger.LogInfo("GradeMasterDAO.cs : ActivateDeactivateGradeMasterDAO() is started.");
				dbExecuteStatus = DataUtility.ActivateDeactivateObject(strDBTableName, objGradeMaster.GradeId,
										objGradeMaster.Version, objGradeMaster.RecordStatus, objGradeMaster.ModifiedBy);
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objGradeMaster.DbOperationStatus = CommonConstant.SUCCEED;
						Logger.LogInfo("GradeMasterDAO.cs : ActivateDeactivateGradeMaster() is ended with success.");
					}
					else
					{
						objGradeMaster.DbOperationStatus = CommonConstant.INVALID;
						Logger.LogInfo("GradeMasterDAO.cs : ActivateDeactivateGradeMaster() is ended with success.");
					}
				}
				else
				{
					objGradeMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("GradeMasterDAO.cs : ActivateDeactivateGradeMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objGradeMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("GradeMasterDAO.cs : ActivateDeactivateGradeMaster() is ended with error.");
			}
			return objGradeMaster;
		}

		public GradeMaster SelectRecordById(GradeMaster objGradeMaster)
		{
			try
			{
				Logger.LogInfo("GradeMasterDAO.cs : SelectRecordById() is started.");
				objGradeMaster.ObjectDataSet = DataUtility.SelectRecordById(strDBTableName, objGradeMaster.GradeId, objGradeMaster.Version, strSelectGradeMaster);
				if (GeneralUtility.IsInteger(objGradeMaster.ObjectDataSet.Tables[0].Rows[0][0]) && (objGradeMaster.ObjectDataSet.Tables[1].Columns.Count > 1))
				{
					if (Convert.ToInt32(objGradeMaster.ObjectDataSet.Tables[0].Rows[0][0]) > 0)
					{
						objGradeMaster.IsRecordChanged = false;
						objGradeMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objGradeMaster.IsRecordChanged = true;
						objGradeMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					Logger.LogInfo("GradeMasterDAO.cs : SelectRecordById() is ended with success.");
				}
				else
				{
					objGradeMaster.DbOperationStatus = CommonConstant.FAIL;
					dbExecuteStatus = objGradeMaster.ObjectDataSet.Tables[0].Rows[0][0].ToString() + " " + objGradeMaster.ObjectDataSet.Tables[1].Rows[0][0].ToString();
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("GradeMasterDAO.cs : SelectRecordById() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objGradeMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("GradeMasterDAO.cs : SelectRecordById() is ended with error.");
			}
			return objGradeMaster;
		}
	}
}
