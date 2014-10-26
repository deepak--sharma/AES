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
	public class ClassMasterDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "CLASS_MASTER";
		private string strSelectClassMaster = "UDSP_SELECT_CLASS_MASTER";
		private string strInsertClassMaster = "UDSP_INSERT_CLASS_MASTER";
		private string strUpdateClassMaster = "UDSP_UPDATE_CLASS_MASTER";
		private string dbExecuteStatus = "";

		public ClassMaster SelectClassMaster(ClassMaster objClassMaster)
		{
			objParameterList = new List<SqlParameter>();
                                    
			UDSP_SELECT_CLASS_MASTER.CLASS_ID_PARAM(objParameterList , objClassMaster.ClassId);
			UDSP_SELECT_CLASS_MASTER.CLASS_CODE_PARAM(objParameterList , objClassMaster.ClassCode);
			UDSP_SELECT_CLASS_MASTER.CLASS_NAME_PARAM(objParameterList , objClassMaster.ClassName);
			UDSP_SELECT_CLASS_MASTER.DESCRIPTION_PARAM(objParameterList , objClassMaster.Description);
			UDSP_SELECT_CLASS_MASTER.IS_STUDENT_PARAM(objParameterList , objClassMaster.IsStudent);
			UDSP_SELECT_CLASS_MASTER.RECORD_STATUS_PARAM(objParameterList , objClassMaster.RecordStatus);

			try
			{
				Logger.LogInfo("ClassMasterDAO.cs : SelectClassMaster() is started.");
				objClassMaster.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectClassMaster, CommandType.StoredProcedure);
				objClassMaster.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("ClassMasterDAO.cs : SelectClassMaster() is ended with success.");
			}
			catch (Exception ex)
			{
				objClassMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("ClassMasterDAO.cs : SelectClassMaster() is ended with error.");
			}
			return objClassMaster;
		}

		public ClassMaster InsertClassMaster(ClassMaster objClassMaster)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_INSERT_CLASS_MASTER.CLASS_CODE_PARAM(objParameterList , objClassMaster.ClassCode);
			UDSP_INSERT_CLASS_MASTER.CLASS_NAME_PARAM(objParameterList , objClassMaster.ClassName);
			UDSP_INSERT_CLASS_MASTER.DESCRIPTION_PARAM(objParameterList , objClassMaster.Description);
			UDSP_INSERT_CLASS_MASTER.IS_STUDENT_PARAM(objParameterList , objClassMaster.IsStudent);
			UDSP_INSERT_CLASS_MASTER.VERSION_PARAM(objParameterList , objClassMaster.Version);
			UDSP_INSERT_CLASS_MASTER.CREATED_BY_PARAM(objParameterList , objClassMaster.CreatedBy);
			UDSP_INSERT_CLASS_MASTER.CREATED_ON_PARAM(objParameterList , objClassMaster.CreatedOn);

            NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@ColoumA", DBNull.Value);
            NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@ColoumB", 12);
            NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@ColoumC", true);

            			
            UDSP_INSERT_CLASS_MASTER.MODIFIED_BY_PARAM(objParameterList , objClassMaster.ModifiedBy);
			UDSP_INSERT_CLASS_MASTER.MODIFIED_ON_PARAM(objParameterList , objClassMaster.ModifiedOn);
			UDSP_INSERT_CLASS_MASTER.RECORD_STATUS_PARAM(objParameterList , objClassMaster.RecordStatus);
			try
			{
				Logger.LogInfo("ClassMasterDAO.cs : InsertClassMaster() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strInsertClassMaster, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) > 0 )
					{
						objClassMaster.ClassId = Convert.ToInt32(dbExecuteStatus);
						objClassMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objClassMaster.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("ClassMasterDAO.cs : InsertClassMaster() is ended with success.");
				}
				else
				{
					objClassMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("ClassMasterDAO.cs : InsertClassMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objClassMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("ClassMasterDAO.cs : InsertClassMaster() is ended with error.");
			}
			return objClassMaster;
		}

		public ClassMaster UpdateClassMaster(ClassMaster objClassMaster)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_UPDATE_CLASS_MASTER.CLASS_ID_PARAM(objParameterList , objClassMaster.ClassId);
			UDSP_UPDATE_CLASS_MASTER.CLASS_CODE_PARAM(objParameterList , objClassMaster.ClassCode);
			UDSP_UPDATE_CLASS_MASTER.CLASS_NAME_PARAM(objParameterList , objClassMaster.ClassName);
			UDSP_UPDATE_CLASS_MASTER.DESCRIPTION_PARAM(objParameterList , objClassMaster.Description);
			UDSP_UPDATE_CLASS_MASTER.IS_STUDENT_PARAM(objParameterList , objClassMaster.IsStudent);
			UDSP_UPDATE_CLASS_MASTER.VERSION_PARAM(objParameterList , objClassMaster.Version);
			UDSP_UPDATE_CLASS_MASTER.CREATED_BY_PARAM(objParameterList , objClassMaster.CreatedBy);
			UDSP_UPDATE_CLASS_MASTER.CREATED_ON_PARAM(objParameterList , objClassMaster.CreatedOn);
			UDSP_UPDATE_CLASS_MASTER.MODIFIED_BY_PARAM(objParameterList , objClassMaster.ModifiedBy);
			UDSP_UPDATE_CLASS_MASTER.MODIFIED_ON_PARAM(objParameterList , objClassMaster.ModifiedOn);
			UDSP_UPDATE_CLASS_MASTER.RECORD_STATUS_PARAM(objParameterList , objClassMaster.RecordStatus);

            NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@ColoumA", DBNull.Value);
            NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@ColoumB", 12);
            NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@ColoumC", true);

			try
			{
				Logger.LogInfo("ClassMasterDAO.cs : UpdateClassMaster() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strUpdateClassMaster, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objClassMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
					{
						objClassMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					else
					{
						objClassMaster.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("ClassMasterDAO.cs : UpdateClassMaster() is ended with success.");
				}
				else
				{
					objClassMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("ClassMasterDAO.cs : UpdateClassMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objClassMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("ClassMasterDAO.cs : UpdateClassMaster() is ended with error.");
			}
			return objClassMaster;
		}

		public ClassMaster ActivateDeactivateClassMaster(ClassMaster objClassMaster)
		{
			try
			{
				Logger.LogInfo("ClassMasterDAO.cs : ActivateDeactivateClassMasterDAO() is started.");
				dbExecuteStatus = DataUtility.ActivateDeactivateObject(strDBTableName, objClassMaster.ClassId,
										objClassMaster.Version, objClassMaster.RecordStatus, objClassMaster.ModifiedBy);
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objClassMaster.DbOperationStatus = CommonConstant.SUCCEED;
						Logger.LogInfo("ClassMasterDAO.cs : ActivateDeactivateClassMaster() is ended with success.");
					}
					else
					{
						objClassMaster.DbOperationStatus = CommonConstant.INVALID;
						Logger.LogInfo("ClassMasterDAO.cs : ActivateDeactivateClassMaster() is ended with success.");
					}
				}
				else
				{
					objClassMaster.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("ClassMasterDAO.cs : ActivateDeactivateClassMaster() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objClassMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("ClassMasterDAO.cs : ActivateDeactivateClassMaster() is ended with error.");
			}
			return objClassMaster;
		}

		public ClassMaster SelectRecordById(ClassMaster objClassMaster)
		{
			try
			{
				Logger.LogInfo("ClassMasterDAO.cs : SelectRecordById() is started.");
				objClassMaster.ObjectDataSet = DataUtility.SelectRecordById(strDBTableName, objClassMaster.ClassId, objClassMaster.Version, strSelectClassMaster);
				if (GeneralUtility.IsInteger(objClassMaster.ObjectDataSet.Tables[0].Rows[0][0]) && (objClassMaster.ObjectDataSet.Tables[1].Columns.Count > 1))
				{
					if (Convert.ToInt32(objClassMaster.ObjectDataSet.Tables[0].Rows[0][0]) > 0)
					{
						objClassMaster.IsRecordChanged = false;
						objClassMaster.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objClassMaster.IsRecordChanged = true;
						objClassMaster.DbOperationStatus = CommonConstant.INVALID;
					}
					Logger.LogInfo("ClassMasterDAO.cs : SelectRecordById() is ended with success.");
				}
				else
				{
					objClassMaster.DbOperationStatus = CommonConstant.FAIL;
					dbExecuteStatus = objClassMaster.ObjectDataSet.Tables[0].Rows[0][0].ToString() + " " + objClassMaster.ObjectDataSet.Tables[1].Rows[0][0].ToString();
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("ClassMasterDAO.cs : SelectRecordById() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objClassMaster.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("ClassMasterDAO.cs : SelectRecordById() is ended with error.");
			}
			return objClassMaster;
		}
	}
}
