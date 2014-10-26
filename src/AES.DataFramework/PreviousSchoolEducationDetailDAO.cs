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
	public class PreviousSchoolEducationDetailDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "PREVIOUS_SCHOOL_EDUCATION_DETAIL";
		private string strSelectPreviousSchoolEducationDetail = "SP_SELECT_PREVIOUS_SCHOOL_EDUCATION_DETAIL";
		private string strInsertPreviousSchoolEducationDetail = "UDSP_INSERT_PREVIOUS_SCHOOL_EDUCATION_DETAIL";
		private string strEditPreviousSchoolEducationDetail = "SP_UPDATE_PREVIOUS_SCHOOL_EDUCATION_DETAIL";
        private string strSavePreviousSchoolEducationDetail = "SP_INSERT_PREVIOUS_SCHOOL_EDUCATION_DETAIL";
		private string dbExecuteStatus = "";
          
		public PreviousSchoolEducationDetail SelectPreviousSchoolEducationDetail(PreviousSchoolEducationDetail objPreviousSchoolEducationDetail)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_PREVIOUS_SCHOOL_EDUCATION_DETAIL.PREVIOUS_SCHOOL_EDUCATION_ID_PARAM(objParameterList , objPreviousSchoolEducationDetail.PreviousSchoolEducationId);
			if (objPreviousSchoolEducationDetail.CandidateObject != null)
			{
				UDSP_SELECT_PREVIOUS_SCHOOL_EDUCATION_DETAIL.CANDIDATE_ID_PARAM(objParameterList , objPreviousSchoolEducationDetail.CandidateObject.CandidateId);
			}
			if (objPreviousSchoolEducationDetail.SchoolObject != null)
			{
				UDSP_SELECT_PREVIOUS_SCHOOL_EDUCATION_DETAIL.SCHOOL_ID_PARAM(objParameterList , objPreviousSchoolEducationDetail.SchoolObject.SchoolId);
			}
			UDSP_SELECT_PREVIOUS_SCHOOL_EDUCATION_DETAIL.SCHOOL_NAME_PARAM(objParameterList , objPreviousSchoolEducationDetail.SchoolName);
			UDSP_SELECT_PREVIOUS_SCHOOL_EDUCATION_DETAIL.SCHOOL_ADDRESS_PARAM(objParameterList , objPreviousSchoolEducationDetail.SchoolAddress);
			UDSP_SELECT_PREVIOUS_SCHOOL_EDUCATION_DETAIL.SCHOOL_CONTACTS_PARAM(objParameterList , objPreviousSchoolEducationDetail.SchoolContacts);
			if (objPreviousSchoolEducationDetail.ClassObject != null)
			{
				UDSP_SELECT_PREVIOUS_SCHOOL_EDUCATION_DETAIL.CLASS_ID_PARAM(objParameterList , objPreviousSchoolEducationDetail.ClassObject.ClassId);
			}
			UDSP_SELECT_PREVIOUS_SCHOOL_EDUCATION_DETAIL.REGISTRATION_NUMBER_PARAM(objParameterList , objPreviousSchoolEducationDetail.RegistrationNumber);
			if (objPreviousSchoolEducationDetail.AcademicSessionObject != null)
			{
				UDSP_SELECT_PREVIOUS_SCHOOL_EDUCATION_DETAIL.ACADEMIC_SESSION_ID_PARAM(objParameterList , objPreviousSchoolEducationDetail.AcademicSessionObject.SessionId);
			}
			UDSP_SELECT_PREVIOUS_SCHOOL_EDUCATION_DETAIL.RESULT_STATUS_PARAM(objParameterList , objPreviousSchoolEducationDetail.ResultStatus);
			UDSP_SELECT_PREVIOUS_SCHOOL_EDUCATION_DETAIL.MARKS_PERCENT_PARAM(objParameterList , objPreviousSchoolEducationDetail.MarksPercent);
			UDSP_SELECT_PREVIOUS_SCHOOL_EDUCATION_DETAIL.SUPPORTED_DOCUMENTS_PARAM(objParameterList , objPreviousSchoolEducationDetail.SupportedDocuments);
            NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@PARENT_ID", objPreviousSchoolEducationDetail.ParentId);
			try
			{
				Logger.LogInfo("PreviousSchoolEducationDetailDAO.cs : SelectPreviousSchoolEducationDetail() is started.");
				objPreviousSchoolEducationDetail.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectPreviousSchoolEducationDetail, CommandType.StoredProcedure);
				objPreviousSchoolEducationDetail.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("PreviousSchoolEducationDetailDAO.cs : SelectPreviousSchoolEducationDetail() is ended with success.");
			}
			catch (Exception ex)
			{
				objPreviousSchoolEducationDetail.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("PreviousSchoolEducationDetailDAO.cs : SelectPreviousSchoolEducationDetail() is ended with error.");
			}
			return objPreviousSchoolEducationDetail;
		}
		public PreviousSchoolEducationDetail SubmitPreviousSchoolEducationDetailData(PreviousSchoolEducationDetail objPreviousSchoolEducationDetail)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_PREVIOUS_SCHOOL_EDUCATION_DETAIL.PREVIOUS_SCHOOL_EDUCATION_ID_PARAM(objParameterList , objPreviousSchoolEducationDetail.PreviousSchoolEducationId);
			if (objPreviousSchoolEducationDetail.CandidateObject != null)
			{
				UDSP_SELECT_PREVIOUS_SCHOOL_EDUCATION_DETAIL.CANDIDATE_ID_PARAM(objParameterList , objPreviousSchoolEducationDetail.CandidateObject.CandidateId);
			}
			if (objPreviousSchoolEducationDetail.SchoolObject != null)
			{
				UDSP_SELECT_PREVIOUS_SCHOOL_EDUCATION_DETAIL.SCHOOL_ID_PARAM(objParameterList , objPreviousSchoolEducationDetail.SchoolObject.SchoolId);
			}
			UDSP_SELECT_PREVIOUS_SCHOOL_EDUCATION_DETAIL.SCHOOL_NAME_PARAM(objParameterList , objPreviousSchoolEducationDetail.SchoolName);
			UDSP_SELECT_PREVIOUS_SCHOOL_EDUCATION_DETAIL.SCHOOL_ADDRESS_PARAM(objParameterList , objPreviousSchoolEducationDetail.SchoolAddress);
			UDSP_SELECT_PREVIOUS_SCHOOL_EDUCATION_DETAIL.SCHOOL_CONTACTS_PARAM(objParameterList , objPreviousSchoolEducationDetail.SchoolContacts);
			if (objPreviousSchoolEducationDetail.ClassObject != null)
			{
				UDSP_SELECT_PREVIOUS_SCHOOL_EDUCATION_DETAIL.CLASS_ID_PARAM(objParameterList , objPreviousSchoolEducationDetail.ClassObject.ClassId);
			}
			UDSP_SELECT_PREVIOUS_SCHOOL_EDUCATION_DETAIL.REGISTRATION_NUMBER_PARAM(objParameterList , objPreviousSchoolEducationDetail.RegistrationNumber);
			if (objPreviousSchoolEducationDetail.AcademicSessionObject != null)
			{
				UDSP_SELECT_PREVIOUS_SCHOOL_EDUCATION_DETAIL.ACADEMIC_SESSION_ID_PARAM(objParameterList , objPreviousSchoolEducationDetail.AcademicSessionObject.SessionId);
			}
			UDSP_SELECT_PREVIOUS_SCHOOL_EDUCATION_DETAIL.RESULT_STATUS_PARAM(objParameterList , objPreviousSchoolEducationDetail.ResultStatus);
			UDSP_SELECT_PREVIOUS_SCHOOL_EDUCATION_DETAIL.MARKS_PERCENT_PARAM(objParameterList , objPreviousSchoolEducationDetail.MarksPercent);
			UDSP_SELECT_PREVIOUS_SCHOOL_EDUCATION_DETAIL.SUPPORTED_DOCUMENTS_PARAM(objParameterList , objPreviousSchoolEducationDetail.SupportedDocuments);
			try
			{
				Logger.LogInfo("PreviousSchoolEducationDetailDAO.cs : SubmitPreviousSchoolEducationDetailData() is started.");
				dbExecuteStatus = DBMANAGER.ExecuteDataSet(objParameterList,objPreviousSchoolEducationDetail.ObjectDataSet,strSelectPreviousSchoolEducationDetail, CommandType.StoredProcedure).ToString();
				objPreviousSchoolEducationDetail.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("PreviousSchoolEducationDetailDAO.cs : SubmitPreviousSchoolEducationDetailData() is ended with success.");
			}
			catch (Exception ex)
			{
				objPreviousSchoolEducationDetail.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("PreviousSchoolEducationDetailDAO.cs : SubmitPreviousSchoolEducationDetailData() is ended with error.");
			}
			return objPreviousSchoolEducationDetail;
		}

        // For Wizard Control
        public PreviousSchoolEducationDetail SavePreviousSchoolEducationDetailData(PreviousSchoolEducationDetail objPreviousSchoolEducationDetail)
        {
            objParameterList = new List<SqlParameter>();
            if (objPreviousSchoolEducationDetail.CandidateObject != null)
            {
                SP_INSERT_PREVIOUS_SCHOOL_EDUCATION_DETAIL.CANDIDATE_ID_PARAM(objParameterList, objPreviousSchoolEducationDetail.CandidateObject.CandidateId);
            }
            if (objPreviousSchoolEducationDetail.SchoolObject != null)
            {
                SP_INSERT_PREVIOUS_SCHOOL_EDUCATION_DETAIL.SCHOOL_ID_PARAM(objParameterList, objPreviousSchoolEducationDetail.SchoolObject.SchoolId);
            }
            SP_INSERT_PREVIOUS_SCHOOL_EDUCATION_DETAIL.SCHOOL_NAME_PARAM(objParameterList, objPreviousSchoolEducationDetail.SchoolName);
            SP_INSERT_PREVIOUS_SCHOOL_EDUCATION_DETAIL.SCHOOL_ADDRESS_PARAM(objParameterList, objPreviousSchoolEducationDetail.SchoolAddress);
            SP_INSERT_PREVIOUS_SCHOOL_EDUCATION_DETAIL.SCHOOL_CONTACTS_PARAM(objParameterList, objPreviousSchoolEducationDetail.SchoolContacts);
            if (objPreviousSchoolEducationDetail.ClassObject != null)
            {
                SP_INSERT_PREVIOUS_SCHOOL_EDUCATION_DETAIL.CLASS_ID_PARAM(objParameterList, objPreviousSchoolEducationDetail.ClassObject.ClassId);
            }
            SP_INSERT_PREVIOUS_SCHOOL_EDUCATION_DETAIL.REGISTRATION_NUMBER_PARAM(objParameterList, objPreviousSchoolEducationDetail.RegistrationNumber);
            if (objPreviousSchoolEducationDetail.AcademicSessionObject != null)
            {
                UDSP_SELECT_PREVIOUS_SCHOOL_EDUCATION_DETAIL.ACADEMIC_SESSION_ID_PARAM(objParameterList, objPreviousSchoolEducationDetail.AcademicSessionObject.SessionId);
            }
            SP_INSERT_PREVIOUS_SCHOOL_EDUCATION_DETAIL.RESULT_STATUS_PARAM(objParameterList, objPreviousSchoolEducationDetail.ResultStatus);
            SP_INSERT_PREVIOUS_SCHOOL_EDUCATION_DETAIL.MARKS_PERCENT_PARAM(objParameterList, objPreviousSchoolEducationDetail.MarksPercent);
            SP_INSERT_PREVIOUS_SCHOOL_EDUCATION_DETAIL.SUPPORTED_DOCUMENTS_PARAM(objParameterList, objPreviousSchoolEducationDetail.SupportedDocuments);
            SP_INSERT_PREVIOUS_SCHOOL_EDUCATION_DETAIL.PREVIOUS_SCHOOL_MARKS_DETAIL_PARAM(objParameterList, objPreviousSchoolEducationDetail.PreviousSchoolEducationMarksDetailString);
            NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@IS_REQUIRED", objPreviousSchoolEducationDetail.IsRequired);
            try
            {
                Logger.LogInfo("PreviousSchoolEducationDetailDAO.cs : SavePreviousSchoolEducationDetailData() is started.");
                dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList, strSavePreviousSchoolEducationDetail, CommandType.StoredProcedure).ToString();
                if (GeneralUtility.IsInteger(dbExecuteStatus))
                {
                    if (Convert.ToInt32(dbExecuteStatus) > 0)
                    {
                        objPreviousSchoolEducationDetail.PreviousSchoolEducationId = Convert.ToInt32(dbExecuteStatus);
                        objPreviousSchoolEducationDetail.DbOperationStatus = CommonConstant.SUCCEED;
                    }
                    else
                    {
                        objPreviousSchoolEducationDetail.DbOperationStatus = CommonConstant.DUPLICATE;
                    }
                    Logger.LogInfo("PreviousSchoolEducationDetailDAO.cs : SavePreviousSchoolEducationDetailData() is ended with success.");
                }
                else
                {
                    objPreviousSchoolEducationDetail.DbOperationStatus = CommonConstant.FAIL;
                    Logger.LogInfo(dbExecuteStatus);
                    Logger.LogInfo("PreviousSchoolEducationDetailDAO.cs : SavePreviousSchoolEducationDetailData() is ended with error.");
                }
            }
            catch (Exception ex)
            {
                objPreviousSchoolEducationDetail.DbOperationStatus = CommonConstant.FAIL;
                Logger.LogError(ex.Message);
                Logger.LogInfo("PreviousSchoolEducationDetailDAO.cs : SavePreviousSchoolEducationDetailData() is ended with error.");
            }
            return objPreviousSchoolEducationDetail;
        }
        public PreviousSchoolEducationDetail EditPreviousSchoolEducationDetailData(PreviousSchoolEducationDetail objPreviousSchoolEducationDetail)
        {
            objParameterList = new List<SqlParameter>();
            SP_UPDATE_PREVIOUS_SCHOOL_EDUCATION_DETAIL.PREVIOUS_SCHOOL_EDUCATION_ID_PARAM(objParameterList, objPreviousSchoolEducationDetail.PreviousSchoolEducationId);
            if (objPreviousSchoolEducationDetail.CandidateObject != null)
            {
                SP_UPDATE_PREVIOUS_SCHOOL_EDUCATION_DETAIL.CANDIDATE_ID_PARAM(objParameterList, objPreviousSchoolEducationDetail.CandidateObject.CandidateId);
            }
            if (objPreviousSchoolEducationDetail.SchoolObject != null)
            {
                SP_UPDATE_PREVIOUS_SCHOOL_EDUCATION_DETAIL.SCHOOL_ID_PARAM(objParameterList, objPreviousSchoolEducationDetail.SchoolObject.SchoolId);
            }
            SP_UPDATE_PREVIOUS_SCHOOL_EDUCATION_DETAIL.SCHOOL_NAME_PARAM(objParameterList, objPreviousSchoolEducationDetail.SchoolName);
            SP_UPDATE_PREVIOUS_SCHOOL_EDUCATION_DETAIL.SCHOOL_ADDRESS_PARAM(objParameterList, objPreviousSchoolEducationDetail.SchoolAddress);
            SP_UPDATE_PREVIOUS_SCHOOL_EDUCATION_DETAIL.SCHOOL_CONTACTS_PARAM(objParameterList, objPreviousSchoolEducationDetail.SchoolContacts);
            if (objPreviousSchoolEducationDetail.ClassObject != null)
            {
                SP_UPDATE_PREVIOUS_SCHOOL_EDUCATION_DETAIL.CLASS_ID_PARAM(objParameterList, objPreviousSchoolEducationDetail.ClassObject.ClassId);
            }
            SP_UPDATE_PREVIOUS_SCHOOL_EDUCATION_DETAIL.REGISTRATION_NUMBER_PARAM(objParameterList, objPreviousSchoolEducationDetail.RegistrationNumber);
            if (objPreviousSchoolEducationDetail.AcademicSessionObject != null)
            {
                SP_UPDATE_PREVIOUS_SCHOOL_EDUCATION_DETAIL.ACADEMIC_SESSION_ID_PARAM(objParameterList, objPreviousSchoolEducationDetail.AcademicSessionObject.SessionId);
            }
            SP_UPDATE_PREVIOUS_SCHOOL_EDUCATION_DETAIL.RESULT_STATUS_PARAM(objParameterList, objPreviousSchoolEducationDetail.ResultStatus);
            SP_UPDATE_PREVIOUS_SCHOOL_EDUCATION_DETAIL.MARKS_PERCENT_PARAM(objParameterList, objPreviousSchoolEducationDetail.MarksPercent);
            SP_UPDATE_PREVIOUS_SCHOOL_EDUCATION_DETAIL.SUPPORTED_DOCUMENTS_PARAM(objParameterList, objPreviousSchoolEducationDetail.SupportedDocuments);
            SP_UPDATE_PREVIOUS_SCHOOL_EDUCATION_DETAIL.PREVIOUS_SCHOOL_MARKS_DETAIL_PARAM(objParameterList, objPreviousSchoolEducationDetail.PreviousSchoolEducationMarksDetailString);
            SP_UPDATE_PREVIOUS_SCHOOL_EDUCATION_DETAIL.MODIFIED_BY_PARAM(objParameterList, objPreviousSchoolEducationDetail.ModifiedBy);
            NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@IS_REQUIRED", objPreviousSchoolEducationDetail.IsRequired);
            NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@PARENT_ID", objPreviousSchoolEducationDetail.ParentId);
            NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@PARENT_VERSION", objPreviousSchoolEducationDetail.ParentVersion);
            try
            {
                Logger.LogInfo("PreviousSchoolEducationDetailDAO.cs : EditPreviousSchoolEducationDetailData() is started.");
                dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList, strEditPreviousSchoolEducationDetail, CommandType.StoredProcedure).ToString();
                if (GeneralUtility.IsInteger(dbExecuteStatus))
                {
                    if (Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
                    {
                        objPreviousSchoolEducationDetail.DbOperationStatus = CommonConstant.SUCCEED;
                    }
                    else if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
                    {
                        objPreviousSchoolEducationDetail.DbOperationStatus = CommonConstant.INVALID;
                    }
                    else
                    {
                        objPreviousSchoolEducationDetail.DbOperationStatus = CommonConstant.DUPLICATE;
                    }
                    Logger.LogInfo("PreviousSchoolEducationDetailDAO.cs : EditPreviousSchoolEducationDetailData() is ended with success.");
                }
                else
                {
                    objPreviousSchoolEducationDetail.DbOperationStatus = CommonConstant.FAIL;
                    Logger.LogInfo(dbExecuteStatus);
                    Logger.LogInfo("PreviousSchoolEducationDetailDAO.cs : EditPreviousSchoolEducationDetailData() is ended with error.");
                }
            }
            catch (Exception ex)
            {
                objPreviousSchoolEducationDetail.DbOperationStatus = CommonConstant.FAIL;
                Logger.LogError(ex.Message);
                Logger.LogInfo("PreviousSchoolEducationDetailDAO.cs : EditPreviousSchoolEducationDetailData() is ended with error.");
            }
            return objPreviousSchoolEducationDetail;
        }

	}
}
