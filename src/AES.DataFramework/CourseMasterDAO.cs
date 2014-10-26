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
	public class CourseMasterDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "COURSE_MASTER";
		private string strSelectCourseMaster = "UDSP_SELECT_COURSE_MASTER";
		private string strInsertCourseMaster = "UDSP_INSERT_COURSE_MASTER";
		private string strUpdateCourseMaster = "UDSP_UPDATE_COURSE_MASTER";
		private string dbExecuteStatus = "";

		public CourseMaster SelectCourseMaster(CourseMaster objCourseMaster)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_COURSE_MASTER.COURSE_ID_PARAM(objParameterList , objCourseMaster.CourseId);
			UDSP_SELECT_COURSE_MASTER.COURSE_NAME_PARAM(objParameterList , objCourseMaster.CourseName);
			UDSP_SELECT_COURSE_MASTER.DESCRIPTION_PARAM(objParameterList , objCourseMaster.Description);
			UDSP_SELECT_COURSE_MASTER.RECORD_STATUS_PARAM(objParameterList , objCourseMaster.RecordStatus);
			try
			{
				Logger.LogInfo("CourseMasterDAO.cs : SelectCourseMaster() is started.");
				objCourseMaster.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectCourseMaster, CommandType.StoredProcedure);
				objCourseMaster.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("CourseMasterDAO.cs : SelectCourseMaster() is ended with success.");
			}
			catch (Exception ex)
			{
				objCourseMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("CourseMasterDAO.cs : SelectCourseMaster() is ended with error.");
			}
			return objCourseMaster;
		}

		public CourseMaster InsertCourseMaster(CourseMaster objCourseMaster)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_INSERT_COURSE_MASTER.COURSE_NAME_PARAM(objParameterList , objCourseMaster.CourseName);
			UDSP_INSERT_COURSE_MASTER.DESCRIPTION_PARAM(objParameterList , objCourseMaster.Description);
			UDSP_INSERT_COURSE_MASTER.VERSION_PARAM(objParameterList , objCourseMaster.Version);
			UDSP_INSERT_COURSE_MASTER.CREATED_BY_PARAM(objParameterList , objCourseMaster.CreatedBy);
			UDSP_INSERT_COURSE_MASTER.CREATED_ON_PARAM(objParameterList , objCourseMaster.CreatedOn);
			UDSP_INSERT_COURSE_MASTER.MODIFIED_BY_PARAM(objParameterList , objCourseMaster.ModifiedBy);
			UDSP_INSERT_COURSE_MASTER.MODIFIED_ON_PARAM(objParameterList , objCourseMaster.ModifiedOn);
			UDSP_INSERT_COURSE_MASTER.RECORD_STATUS_PARAM(objParameterList , objCourseMaster.RecordStatus);
			try
			{
				Logger.LogInfo("CourseMasterDAO.cs : InsertCourseMaster() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strInsertCourseMaster, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) > 0 )
					{
						objCourseMaster.CourseId = Convert.ToInt32(dbExecuteStatus);
						objCourseMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objCourseMaster.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("CourseMasterDAO.cs : InsertCourseMaster() is ended with success.");
				}
				else
				{
					objCourseMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("CourseMasterDAO.cs : InsertCourseMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objCourseMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("CourseMasterDAO.cs : InsertCourseMaster() is ended with error.");
			}
			return objCourseMaster;
		}

		public CourseMaster UpdateCourseMaster(CourseMaster objCourseMaster)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_UPDATE_COURSE_MASTER.COURSE_ID_PARAM(objParameterList , objCourseMaster.CourseId);
			UDSP_UPDATE_COURSE_MASTER.COURSE_NAME_PARAM(objParameterList , objCourseMaster.CourseName);
			UDSP_UPDATE_COURSE_MASTER.DESCRIPTION_PARAM(objParameterList , objCourseMaster.Description);
			UDSP_UPDATE_COURSE_MASTER.VERSION_PARAM(objParameterList , objCourseMaster.Version);
			UDSP_UPDATE_COURSE_MASTER.CREATED_BY_PARAM(objParameterList , objCourseMaster.CreatedBy);
			UDSP_UPDATE_COURSE_MASTER.CREATED_ON_PARAM(objParameterList , objCourseMaster.CreatedOn);
			UDSP_UPDATE_COURSE_MASTER.MODIFIED_BY_PARAM(objParameterList , objCourseMaster.ModifiedBy);
			UDSP_UPDATE_COURSE_MASTER.MODIFIED_ON_PARAM(objParameterList , objCourseMaster.ModifiedOn);
			UDSP_UPDATE_COURSE_MASTER.RECORD_STATUS_PARAM(objParameterList , objCourseMaster.RecordStatus);
			try
			{
				Logger.LogInfo("CourseMasterDAO.cs : UpdateCourseMaster() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strUpdateCourseMaster, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objCourseMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
					{
						objCourseMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					else
					{
						objCourseMaster.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("CourseMasterDAO.cs : UpdateCourseMaster() is ended with success.");
				}
				else
				{
					objCourseMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("CourseMasterDAO.cs : UpdateCourseMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objCourseMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("CourseMasterDAO.cs : UpdateCourseMaster() is ended with error.");
			}
			return objCourseMaster;
		}

		public CourseMaster ActivateDeactivateCourseMaster(CourseMaster objCourseMaster)
		{
			try
			{
				Logger.LogInfo("CourseMasterDAO.cs : ActivateDeactivateCourseMasterDAO() is started.");
				dbExecuteStatus = DataUtility.ActivateDeactivateObject(strDBTableName, objCourseMaster.CourseId,
										objCourseMaster.Version, objCourseMaster.RecordStatus, objCourseMaster.ModifiedBy);
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objCourseMaster.DbOperationStatus = CommonConstant.SUCCEED;
						Logger.LogInfo("CourseMasterDAO.cs : ActivateDeactivateCourseMaster() is ended with success.");
					}
					else
					{
						objCourseMaster.DbOperationStatus = CommonConstant.INVALID;
						Logger.LogInfo("CourseMasterDAO.cs : ActivateDeactivateCourseMaster() is ended with success.");
					}
				}
				else
				{
					objCourseMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("CourseMasterDAO.cs : ActivateDeactivateCourseMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objCourseMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("CourseMasterDAO.cs : ActivateDeactivateCourseMaster() is ended with error.");
			}
			return objCourseMaster;
		}

		public CourseMaster SelectRecordById(CourseMaster objCourseMaster)
		{
			try
			{
				Logger.LogInfo("CourseMasterDAO.cs : SelectRecordById() is started.");
				objCourseMaster.ObjectDataSet = DataUtility.SelectRecordById(strDBTableName, objCourseMaster.CourseId, objCourseMaster.Version, strSelectCourseMaster);
				if (GeneralUtility.IsInteger(objCourseMaster.ObjectDataSet.Tables[0].Rows[0][0]) && (objCourseMaster.ObjectDataSet.Tables[1].Columns.Count > 1))
				{
					if (Convert.ToInt32(objCourseMaster.ObjectDataSet.Tables[0].Rows[0][0]) > 0)
					{
						objCourseMaster.IsRecordChanged = false;
						objCourseMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objCourseMaster.IsRecordChanged = true;
						objCourseMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					Logger.LogInfo("CourseMasterDAO.cs : SelectRecordById() is ended with success.");
				}
				else
				{
					objCourseMaster.DbOperationStatus = CommonConstant.FAIL;
					dbExecuteStatus = objCourseMaster.ObjectDataSet.Tables[0].Rows[0][0].ToString() + " " + objCourseMaster.ObjectDataSet.Tables[1].Rows[0][0].ToString();
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("CourseMasterDAO.cs : SelectRecordById() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objCourseMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("CourseMasterDAO.cs : SelectRecordById() is ended with error.");
			}
			return objCourseMaster;
		}
	}
}
