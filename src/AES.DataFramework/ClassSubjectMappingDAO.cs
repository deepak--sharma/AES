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
	public class ClassSubjectMappingDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "CLASS_SUBJECT_MAPPING";
		private string strSelectClassSubjectMapping = "UDSP_SELECT_CLASS_SUBJECT_MAPPING";
		private string strInsertClassSubjectMapping = "UDSP_INSERT_CLASS_SUBJECT_MAPPING";
		private string strUpdateClassSubjectMapping = "UDSP_UPDATE_CLASS_SUBJECT_MAPPING";
		private string dbExecuteStatus = "";

		public ClassSubjectMapping SelectClassSubjectMapping(ClassSubjectMapping objClassSubjectMapping)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_CLASS_SUBJECT_MAPPING.CLASS_SUBJECT_MAPPING_ID_PARAM(objParameterList , objClassSubjectMapping.ClassSubjectMappingId);
			UDSP_SELECT_CLASS_SUBJECT_MAPPING.CLASS_SUBJECT_MAPPING_NAME_PARAM(objParameterList , objClassSubjectMapping.ClassSubjectMappingName);
			if (objClassSubjectMapping.ClassObject != null)
			{
				UDSP_SELECT_CLASS_SUBJECT_MAPPING.CLASS_ID_PARAM(objParameterList , objClassSubjectMapping.ClassObject.ClassId);
			}
			if (objClassSubjectMapping.SubjectObject != null)
			{
				UDSP_SELECT_CLASS_SUBJECT_MAPPING.SUBJECT_ID_PARAM(objParameterList , objClassSubjectMapping.SubjectObject.SubjectId);
			}
			UDSP_SELECT_CLASS_SUBJECT_MAPPING.DESCRIPTION_PARAM(objParameterList , objClassSubjectMapping.Description);
			UDSP_SELECT_CLASS_SUBJECT_MAPPING.RECORD_STATUS_PARAM(objParameterList , objClassSubjectMapping.RecordStatus);
			try
			{
				Logger.LogInfo("ClassSubjectMappingDAO.cs : SelectClassSubjectMapping() is started.");
				objClassSubjectMapping.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectClassSubjectMapping, CommandType.StoredProcedure);
				objClassSubjectMapping.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("ClassSubjectMappingDAO.cs : SelectClassSubjectMapping() is ended with success.");
			}
			catch (Exception ex)
			{
				objClassSubjectMapping.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("ClassSubjectMappingDAO.cs : SelectClassSubjectMapping() is ended with error.");
			}
			return objClassSubjectMapping;
		}

		public ClassSubjectMapping InsertClassSubjectMapping(ClassSubjectMapping objClassSubjectMapping)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_INSERT_CLASS_SUBJECT_MAPPING.CLASS_SUBJECT_MAPPING_NAME_PARAM(objParameterList , objClassSubjectMapping.ClassSubjectMappingName);
			if (objClassSubjectMapping.ClassObject != null)
			{
				UDSP_INSERT_CLASS_SUBJECT_MAPPING.CLASS_ID_PARAM(objParameterList , objClassSubjectMapping.ClassObject.ClassId);
			}
			if (objClassSubjectMapping.SubjectObject != null)
			{
				UDSP_INSERT_CLASS_SUBJECT_MAPPING.SUBJECT_ID_PARAM(objParameterList , objClassSubjectMapping.SubjectObject.SubjectId);
			}
			UDSP_INSERT_CLASS_SUBJECT_MAPPING.DESCRIPTION_PARAM(objParameterList , objClassSubjectMapping.Description);
			UDSP_INSERT_CLASS_SUBJECT_MAPPING.VERSION_PARAM(objParameterList , objClassSubjectMapping.Version);
			UDSP_INSERT_CLASS_SUBJECT_MAPPING.CREATED_BY_PARAM(objParameterList , objClassSubjectMapping.CreatedBy);
			UDSP_INSERT_CLASS_SUBJECT_MAPPING.CREATED_ON_PARAM(objParameterList , objClassSubjectMapping.CreatedOn);
			UDSP_INSERT_CLASS_SUBJECT_MAPPING.MODIFIED_BY_PARAM(objParameterList , objClassSubjectMapping.ModifiedBy);
			UDSP_INSERT_CLASS_SUBJECT_MAPPING.MODIFIED_ON_PARAM(objParameterList , objClassSubjectMapping.ModifiedOn);
			UDSP_INSERT_CLASS_SUBJECT_MAPPING.RECORD_STATUS_PARAM(objParameterList , objClassSubjectMapping.RecordStatus);
			try
			{
				Logger.LogInfo("ClassSubjectMappingDAO.cs : InsertClassSubjectMapping() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strInsertClassSubjectMapping, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) > 0 )
					{
						objClassSubjectMapping.ClassSubjectMappingId = Convert.ToInt32(dbExecuteStatus);
						objClassSubjectMapping.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objClassSubjectMapping.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("ClassSubjectMappingDAO.cs : InsertClassSubjectMapping() is ended with success.");
				}
				else
				{
					objClassSubjectMapping.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("ClassSubjectMappingDAO.cs : InsertClassSubjectMapping() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objClassSubjectMapping.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("ClassSubjectMappingDAO.cs : InsertClassSubjectMapping() is ended with error.");
			}
			return objClassSubjectMapping;
		}

		public ClassSubjectMapping UpdateClassSubjectMapping(ClassSubjectMapping objClassSubjectMapping)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_UPDATE_CLASS_SUBJECT_MAPPING.CLASS_SUBJECT_MAPPING_ID_PARAM(objParameterList , objClassSubjectMapping.ClassSubjectMappingId);
			UDSP_UPDATE_CLASS_SUBJECT_MAPPING.CLASS_SUBJECT_MAPPING_NAME_PARAM(objParameterList , objClassSubjectMapping.ClassSubjectMappingName);
			if (objClassSubjectMapping.ClassObject != null)
			{
				UDSP_UPDATE_CLASS_SUBJECT_MAPPING.CLASS_ID_PARAM(objParameterList , objClassSubjectMapping.ClassObject.ClassId);
			}
			if (objClassSubjectMapping.SubjectObject != null)
			{
				UDSP_UPDATE_CLASS_SUBJECT_MAPPING.SUBJECT_ID_PARAM(objParameterList , objClassSubjectMapping.SubjectObject.SubjectId);
			}
			UDSP_UPDATE_CLASS_SUBJECT_MAPPING.DESCRIPTION_PARAM(objParameterList , objClassSubjectMapping.Description);
			UDSP_UPDATE_CLASS_SUBJECT_MAPPING.VERSION_PARAM(objParameterList , objClassSubjectMapping.Version);
			UDSP_UPDATE_CLASS_SUBJECT_MAPPING.CREATED_BY_PARAM(objParameterList , objClassSubjectMapping.CreatedBy);
			UDSP_UPDATE_CLASS_SUBJECT_MAPPING.CREATED_ON_PARAM(objParameterList , objClassSubjectMapping.CreatedOn);
			UDSP_UPDATE_CLASS_SUBJECT_MAPPING.MODIFIED_BY_PARAM(objParameterList , objClassSubjectMapping.ModifiedBy);
			UDSP_UPDATE_CLASS_SUBJECT_MAPPING.MODIFIED_ON_PARAM(objParameterList , objClassSubjectMapping.ModifiedOn);
			UDSP_UPDATE_CLASS_SUBJECT_MAPPING.RECORD_STATUS_PARAM(objParameterList , objClassSubjectMapping.RecordStatus);
			try
			{
				Logger.LogInfo("ClassSubjectMappingDAO.cs : UpdateClassSubjectMapping() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strUpdateClassSubjectMapping, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objClassSubjectMapping.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
					{
						objClassSubjectMapping.DbOperationStatus = CommonConstant.INVALID;
					}
					else
					{
						objClassSubjectMapping.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("ClassSubjectMappingDAO.cs : UpdateClassSubjectMapping() is ended with success.");
				}
				else
				{
					objClassSubjectMapping.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("ClassSubjectMappingDAO.cs : UpdateClassSubjectMapping() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objClassSubjectMapping.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("ClassSubjectMappingDAO.cs : UpdateClassSubjectMapping() is ended with error.");
			}
			return objClassSubjectMapping;
		}

		public ClassSubjectMapping ActivateDeactivateClassSubjectMapping(ClassSubjectMapping objClassSubjectMapping)
		{
			try
			{
				Logger.LogInfo("ClassSubjectMappingDAO.cs : ActivateDeactivateClassSubjectMappingDAO() is started.");
				dbExecuteStatus = DataUtility.ActivateDeactivateObject(strDBTableName, objClassSubjectMapping.ClassSubjectMappingId,
										objClassSubjectMapping.Version, objClassSubjectMapping.RecordStatus, objClassSubjectMapping.ModifiedBy);
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objClassSubjectMapping.DbOperationStatus = CommonConstant.SUCCEED;
						Logger.LogInfo("ClassSubjectMappingDAO.cs : ActivateDeactivateClassSubjectMapping() is ended with success.");
					}
					else
					{
						objClassSubjectMapping.DbOperationStatus = CommonConstant.INVALID;
						Logger.LogInfo("ClassSubjectMappingDAO.cs : ActivateDeactivateClassSubjectMapping() is ended with success.");
					}
				}
				else
				{
					objClassSubjectMapping.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("ClassSubjectMappingDAO.cs : ActivateDeactivateClassSubjectMapping() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objClassSubjectMapping.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("ClassSubjectMappingDAO.cs : ActivateDeactivateClassSubjectMapping() is ended with error.");
			}
			return objClassSubjectMapping;
		}

		public ClassSubjectMapping SelectRecordById(ClassSubjectMapping objClassSubjectMapping)
		{
			try
			{
				Logger.LogInfo("ClassSubjectMappingDAO.cs : SelectRecordById() is started.");
				objClassSubjectMapping.ObjectDataSet = DataUtility.SelectRecordById(strDBTableName, objClassSubjectMapping.ClassSubjectMappingId, objClassSubjectMapping.Version, strSelectClassSubjectMapping);
				if (GeneralUtility.IsInteger(objClassSubjectMapping.ObjectDataSet.Tables[0].Rows[0][0]) && (objClassSubjectMapping.ObjectDataSet.Tables[1].Columns.Count > 1))
				{
					if (Convert.ToInt32(objClassSubjectMapping.ObjectDataSet.Tables[0].Rows[0][0]) > 0)
					{
						objClassSubjectMapping.IsRecordChanged = false;
						objClassSubjectMapping.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objClassSubjectMapping.IsRecordChanged = true;
						objClassSubjectMapping.DbOperationStatus = CommonConstant.INVALID;
					}
					Logger.LogInfo("ClassSubjectMappingDAO.cs : SelectRecordById() is ended with success.");
				}
				else
				{
					objClassSubjectMapping.DbOperationStatus = CommonConstant.FAIL;
					dbExecuteStatus = objClassSubjectMapping.ObjectDataSet.Tables[0].Rows[0][0].ToString() + " " + objClassSubjectMapping.ObjectDataSet.Tables[1].Rows[0][0].ToString();
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("ClassSubjectMappingDAO.cs : SelectRecordById() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objClassSubjectMapping.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("ClassSubjectMappingDAO.cs : SelectRecordById() is ended with error.");
			}
			return objClassSubjectMapping;
		}
	}
}
