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
	public class StudentDetailDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "STUDENT_DETAIL";
		private string strSelectStudentDetail = "UDSP_SELECT_STUDENT_DETAIL";
        private string strInsertStudentDetail = "SP_INSERT_STUDENT_DETAIL";        
		private string strUpdateStudentDetail = "UDSP_UPDATE_STUDENT_DETAIL";
		private string dbExecuteStatus = "";

		public StudentDetail SelectStudentDetail(StudentDetail objStudentDetail)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_STUDENT_DETAIL.STUDENT_ID_PARAM(objParameterList , objStudentDetail.StudentId);
			if (objStudentDetail.StudentRegistrationObject != null)
			{
				UDSP_SELECT_STUDENT_DETAIL.STUDENT_REGISTRATION_ID_PARAM(objParameterList , objStudentDetail.StudentRegistrationObject.StudentRegistrationId);
			}
			if (objStudentDetail.SectionObject != null)
			{
				UDSP_SELECT_STUDENT_DETAIL.SECTION_ID_PARAM(objParameterList , objStudentDetail.SectionObject.SectionId);
			}
			if (objStudentDetail.StreamObject != null)
			{
				UDSP_SELECT_STUDENT_DETAIL.STREAM_ID_PARAM(objParameterList , objStudentDetail.StreamObject.StreamId);
			}
			UDSP_SELECT_STUDENT_DETAIL.ROLL_NO_PARAM(objParameterList , objStudentDetail.RollNo);
			if (objStudentDetail.FeeStructureObject != null)
			{
				UDSP_SELECT_STUDENT_DETAIL.FEE_STRUCTURE_ID_PARAM(objParameterList , objStudentDetail.FeeStructureObject.FeeStructureId);
			}
			UDSP_SELECT_STUDENT_DETAIL.ADMISSION_DATE_PARAM(objParameterList , objStudentDetail.AdmissionDate);
			UDSP_SELECT_STUDENT_DETAIL.RECORD_STATUS_PARAM(objParameterList , objStudentDetail.RecordStatus);
			try
			{
				Logger.LogInfo("StudentDetailDAO.cs : SelectStudentDetail() is started.");
				objStudentDetail.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectStudentDetail, CommandType.StoredProcedure);
				objStudentDetail.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("StudentDetailDAO.cs : SelectStudentDetail() is ended with success.");
			}
			catch (Exception ex)
			{
				objStudentDetail.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("StudentDetailDAO.cs : SelectStudentDetail() is ended with error.");
			}
			return objStudentDetail;
		}

		public StudentDetail InsertStudentDetail(StudentDetail objStudentDetail)
		{
			objParameterList = new List<SqlParameter>();
				
			if (objStudentDetail.StudentRegistrationObject != null)
			{
				UDSP_INSERT_STUDENT_DETAIL.STUDENT_REGISTRATION_ID_PARAM(objParameterList , objStudentDetail.StudentRegistrationObject.StudentRegistrationId);
			}
			if (objStudentDetail.SectionObject != null)
			{
                UDSP_INSERT_STUDENT_DETAIL.SECTION_ID_PARAM(objParameterList, objStudentDetail.SectionObject.SectionId);
			}
			if (objStudentDetail.StreamObject != null)
			{
				UDSP_INSERT_STUDENT_DETAIL.STREAM_ID_PARAM(objParameterList , objStudentDetail.StreamObject.StreamId);
			}
			UDSP_INSERT_STUDENT_DETAIL.ROLL_NO_PARAM(objParameterList , objStudentDetail.RollNo);
			if (objStudentDetail.FeeStructureObject != null)
			{
				UDSP_INSERT_STUDENT_DETAIL.FEE_STRUCTURE_ID_PARAM(objParameterList , objStudentDetail.FeeStructureObject.FeeStructureId);
			}
			UDSP_INSERT_STUDENT_DETAIL.ADMISSION_DATE_PARAM(objParameterList , objStudentDetail.AdmissionDate);
			UDSP_INSERT_STUDENT_DETAIL.VERSION_PARAM(objParameterList , objStudentDetail.Version);
			UDSP_INSERT_STUDENT_DETAIL.CREATED_BY_PARAM(objParameterList , objStudentDetail.CreatedBy);
			UDSP_INSERT_STUDENT_DETAIL.CREATED_ON_PARAM(objParameterList , objStudentDetail.CreatedOn);
			UDSP_INSERT_STUDENT_DETAIL.MODIFIED_BY_PARAM(objParameterList , objStudentDetail.ModifiedBy);
			UDSP_INSERT_STUDENT_DETAIL.MODIFIED_ON_PARAM(objParameterList , objStudentDetail.ModifiedOn);
			UDSP_INSERT_STUDENT_DETAIL.RECORD_STATUS_PARAM(objParameterList , objStudentDetail.RecordStatus);
			try
			{
				Logger.LogInfo("StudentDetailDAO.cs : InsertStudentDetail() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strInsertStudentDetail, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) > 0 )
					{
						objStudentDetail.StudentId = Convert.ToInt32(dbExecuteStatus);
						objStudentDetail.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objStudentDetail.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("StudentDetailDAO.cs : InsertStudentDetail() is ended with success.");
				}
				else
				{
					objStudentDetail.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("StudentDetailDAO.cs : InsertStudentDetail() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objStudentDetail.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("StudentDetailDAO.cs : InsertStudentDetail() is ended with error.");
			}
			return objStudentDetail;
		}

		public StudentDetail UpdateStudentDetail(StudentDetail objStudentDetail)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_UPDATE_STUDENT_DETAIL.STUDENT_ID_PARAM(objParameterList , objStudentDetail.StudentId);
			if (objStudentDetail.StudentRegistrationObject != null)
			{
				UDSP_UPDATE_STUDENT_DETAIL.STUDENT_REGISTRATION_ID_PARAM(objParameterList , objStudentDetail.StudentRegistrationObject.StudentRegistrationId);
			}
			if (objStudentDetail.SectionObject != null)
			{
                UDSP_UPDATE_STUDENT_DETAIL.SECTION_ID_PARAM(objParameterList, objStudentDetail.SectionObject.SectionId);
			}
			if (objStudentDetail.StreamObject != null)
			{
				UDSP_UPDATE_STUDENT_DETAIL.STREAM_ID_PARAM(objParameterList , objStudentDetail.StreamObject.StreamId);
			}
			UDSP_UPDATE_STUDENT_DETAIL.ROLL_NO_PARAM(objParameterList , objStudentDetail.RollNo);
			if (objStudentDetail.FeeStructureObject != null)
			{
				UDSP_UPDATE_STUDENT_DETAIL.FEE_STRUCTURE_ID_PARAM(objParameterList , objStudentDetail.FeeStructureObject.FeeStructureId);
			}
			UDSP_UPDATE_STUDENT_DETAIL.ADMISSION_DATE_PARAM(objParameterList , objStudentDetail.AdmissionDate);
			UDSP_UPDATE_STUDENT_DETAIL.VERSION_PARAM(objParameterList , objStudentDetail.Version);
			UDSP_UPDATE_STUDENT_DETAIL.CREATED_BY_PARAM(objParameterList , objStudentDetail.CreatedBy);
			UDSP_UPDATE_STUDENT_DETAIL.CREATED_ON_PARAM(objParameterList , objStudentDetail.CreatedOn);
			UDSP_UPDATE_STUDENT_DETAIL.MODIFIED_BY_PARAM(objParameterList , objStudentDetail.ModifiedBy);
			UDSP_UPDATE_STUDENT_DETAIL.MODIFIED_ON_PARAM(objParameterList , objStudentDetail.ModifiedOn);
			UDSP_UPDATE_STUDENT_DETAIL.RECORD_STATUS_PARAM(objParameterList , objStudentDetail.RecordStatus);
			try
			{
				Logger.LogInfo("StudentDetailDAO.cs : UpdateStudentDetail() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strUpdateStudentDetail, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objStudentDetail.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
					{
						objStudentDetail.DbOperationStatus = CommonConstant.INVALID;
					}
					else
					{
						objStudentDetail.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("StudentDetailDAO.cs : UpdateStudentDetail() is ended with success.");
				}
				else
				{
					objStudentDetail.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("StudentDetailDAO.cs : UpdateStudentDetail() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objStudentDetail.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("StudentDetailDAO.cs : UpdateStudentDetail() is ended with error.");
			}
			return objStudentDetail;
		}

		public StudentDetail ActivateDeactivateStudentDetail(StudentDetail objStudentDetail)
		{
			try
			{
				Logger.LogInfo("StudentDetailDAO.cs : ActivateDeactivateStudentDetailDAO() is started.");
				dbExecuteStatus = DataUtility.ActivateDeactivateObject(strDBTableName, objStudentDetail.StudentId,
										objStudentDetail.Version, objStudentDetail.RecordStatus, objStudentDetail.ModifiedBy);
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objStudentDetail.DbOperationStatus = CommonConstant.SUCCEED;
						Logger.LogInfo("StudentDetailDAO.cs : ActivateDeactivateStudentDetail() is ended with success.");
					}
					else
					{
						objStudentDetail.DbOperationStatus = CommonConstant.INVALID;
						Logger.LogInfo("StudentDetailDAO.cs : ActivateDeactivateStudentDetail() is ended with success.");
					}
				}
				else
				{
					objStudentDetail.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("StudentDetailDAO.cs : ActivateDeactivateStudentDetail() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objStudentDetail.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("StudentDetailDAO.cs : ActivateDeactivateStudentDetail() is ended with error.");
			}
			return objStudentDetail;
		}

		public StudentDetail SelectRecordById(StudentDetail objStudentDetail)
		{
			try
			{
				Logger.LogInfo("StudentDetailDAO.cs : SelectRecordById() is started.");
				objStudentDetail.ObjectDataSet = DataUtility.SelectRecordById(strDBTableName, objStudentDetail.StudentId, objStudentDetail.Version, strSelectStudentDetail);
				if (GeneralUtility.IsInteger(objStudentDetail.ObjectDataSet.Tables[0].Rows[0][0]) && (objStudentDetail.ObjectDataSet.Tables[1].Columns.Count > 1))
				{
					if (Convert.ToInt32(objStudentDetail.ObjectDataSet.Tables[0].Rows[0][0]) > 0)
					{
						objStudentDetail.IsRecordChanged = false;
						objStudentDetail.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objStudentDetail.IsRecordChanged = true;
						objStudentDetail.DbOperationStatus = CommonConstant.INVALID;
					}
					Logger.LogInfo("StudentDetailDAO.cs : SelectRecordById() is ended with success.");
				}
				else
				{
					objStudentDetail.DbOperationStatus = CommonConstant.FAIL;
					dbExecuteStatus = objStudentDetail.ObjectDataSet.Tables[0].Rows[0][0].ToString() + " " + objStudentDetail.ObjectDataSet.Tables[1].Rows[0][0].ToString();
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("StudentDetailDAO.cs : SelectRecordById() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objStudentDetail.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("StudentDetailDAO.cs : SelectRecordById() is ended with error.");
			}
			return objStudentDetail;
		}
	}
}
