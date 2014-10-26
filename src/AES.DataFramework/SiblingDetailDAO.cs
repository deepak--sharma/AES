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
	public class SiblingDetailDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "SIBLING_DETAIL";
        private string strParentDBTableName = "STUDENT_REGISTRATION_DETAIL";
        private string strSelectParentDetail = "SP_SELECT_STUDENT_REGISTRATION_DETAIL";
		private string strSelectSiblingDetail = "SP_SELECT_SIBLING_DETAIL";
		private string strInsertSiblingDetail = "UDSP_INSERT_SIBLING_DETAIL";
		private string strUpdateSiblingDetail = "UDSP_UPDATE_SIBLING_DETAIL";
        private string strEditSiblingDetail = "SP_UPDATE_SIBLING_DETAIL";
		private string dbExecuteStatus = "";

		public SiblingDetail SelectSiblingDetail(SiblingDetail objSiblingDetail)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_SIBLING_DETAIL.SIBLING_ID_PARAM(objParameterList , objSiblingDetail.SiblingId);
			UDSP_SELECT_SIBLING_DETAIL.FULL_NAME_PARAM(objParameterList , objSiblingDetail.FullName);
			UDSP_SELECT_SIBLING_DETAIL.DATE_OF_BIRTH_PARAM(objParameterList , objSiblingDetail.DateOfBirth);
			if (objSiblingDetail.CandidateObject != null)
			{
				UDSP_SELECT_SIBLING_DETAIL.CANDIDATE_ID_PARAM(objParameterList , objSiblingDetail.CandidateObject.CandidateId);
			}
			if (objSiblingDetail.GenderObject != null)
			{
				UDSP_SELECT_SIBLING_DETAIL.GENDER_ID_PARAM(objParameterList , objSiblingDetail.GenderObject.MetadataId);
			}
			if (objSiblingDetail.SchoolObject != null)
			{
				UDSP_SELECT_SIBLING_DETAIL.SCHOOL_ID_PARAM(objParameterList , objSiblingDetail.SchoolObject.SchoolId);
			}
			UDSP_SELECT_SIBLING_DETAIL.SCHOOL_NAME_PARAM(objParameterList , objSiblingDetail.SchoolName);
			UDSP_SELECT_SIBLING_DETAIL.SCHOOL_ADDRESS_PARAM(objParameterList , objSiblingDetail.SchoolAddress);
			UDSP_SELECT_SIBLING_DETAIL.SCHOOL_CONTACTS_PARAM(objParameterList , objSiblingDetail.SchoolContacts);
			if (objSiblingDetail.ClassObject != null)
			{
				UDSP_SELECT_SIBLING_DETAIL.CLASS_ID_PARAM(objParameterList , objSiblingDetail.ClassObject.ClassId);
			}
			UDSP_SELECT_SIBLING_DETAIL.REGISTRATION_NUMBER_PARAM(objParameterList , objSiblingDetail.RegistrationNumber);
			UDSP_SELECT_SIBLING_DETAIL.IS_CANDIDATE_PARAM(objParameterList , objSiblingDetail.IsCandidate);           
			try
			{
				Logger.LogInfo("SiblingDetailDAO.cs : SelectSiblingDetail() is started.");
				objSiblingDetail.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectSiblingDetail, CommandType.StoredProcedure);
                StudentRegistrationDetail objStudentRegistrationDetail = new StudentRegistrationDetail();
                objStudentRegistrationDetail.ObjectDataSet = DataUtility.SelectRecordById(strParentDBTableName, objSiblingDetail.ParentId, null, strSelectParentDetail);
                objSiblingDetail.ParentVersion = Convert.ToInt32(objStudentRegistrationDetail.ObjectDataSet.Tables[1].Rows[0]["Version"]);
				objSiblingDetail.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("SiblingDetailDAO.cs : SelectSiblingDetail() is ended with success.");
			}
			catch (Exception ex)
			{
				objSiblingDetail.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("SiblingDetailDAO.cs : SelectSiblingDetail() is ended with error.");
			}
			return objSiblingDetail;
		}
		public SiblingDetail SubmitSiblingDetailData(SiblingDetail objSiblingDetail)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_SIBLING_DETAIL.SIBLING_ID_PARAM(objParameterList , objSiblingDetail.SiblingId);
			UDSP_SELECT_SIBLING_DETAIL.FULL_NAME_PARAM(objParameterList , objSiblingDetail.FullName);
			UDSP_SELECT_SIBLING_DETAIL.DATE_OF_BIRTH_PARAM(objParameterList , objSiblingDetail.DateOfBirth);
			if (objSiblingDetail.CandidateObject != null)
			{
				UDSP_SELECT_SIBLING_DETAIL.CANDIDATE_ID_PARAM(objParameterList , objSiblingDetail.CandidateObject.CandidateId);
			}
			if (objSiblingDetail.GenderObject != null)
			{
				UDSP_SELECT_SIBLING_DETAIL.GENDER_ID_PARAM(objParameterList , objSiblingDetail.GenderObject.MetadataId);
			}
			if (objSiblingDetail.SchoolObject != null)
			{
				UDSP_SELECT_SIBLING_DETAIL.SCHOOL_ID_PARAM(objParameterList , objSiblingDetail.SchoolObject.SchoolId);
			}
			UDSP_SELECT_SIBLING_DETAIL.SCHOOL_NAME_PARAM(objParameterList , objSiblingDetail.SchoolName);
			UDSP_SELECT_SIBLING_DETAIL.SCHOOL_ADDRESS_PARAM(objParameterList , objSiblingDetail.SchoolAddress);
			UDSP_SELECT_SIBLING_DETAIL.SCHOOL_CONTACTS_PARAM(objParameterList , objSiblingDetail.SchoolContacts);
			if (objSiblingDetail.ClassObject != null)
			{
				UDSP_SELECT_SIBLING_DETAIL.CLASS_ID_PARAM(objParameterList , objSiblingDetail.ClassObject.ClassId);
			}
			UDSP_SELECT_SIBLING_DETAIL.REGISTRATION_NUMBER_PARAM(objParameterList , objSiblingDetail.RegistrationNumber);
			UDSP_SELECT_SIBLING_DETAIL.IS_CANDIDATE_PARAM(objParameterList , objSiblingDetail.IsCandidate);
			try
			{
				Logger.LogInfo("SiblingDetailDAO.cs : SubmitSiblingDetailData() is started.");
				dbExecuteStatus = DBMANAGER.ExecuteDataSet(objParameterList,objSiblingDetail.ObjectDataSet,strSelectSiblingDetail, CommandType.StoredProcedure).ToString();
				objSiblingDetail.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("SiblingDetailDAO.cs : SubmitSiblingDetailData() is ended with success.");
			}
			catch (Exception ex)
			{
				objSiblingDetail.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("SiblingDetailDAO.cs : SubmitSiblingDetailData() is ended with error.");
			}
			return objSiblingDetail;
		}

        // For Wizard Control
        public SiblingDetail SaveSiblingDetailData(SiblingDetail objSiblingDetail)
        {
            objParameterList = new List<SqlParameter>();
            UDSP_INSERT_SIBLING_DETAIL.FULL_NAME_PARAM(objParameterList, objSiblingDetail.FullName);
            UDSP_INSERT_SIBLING_DETAIL.DATE_OF_BIRTH_PARAM(objParameterList, objSiblingDetail.DateOfBirth);
            if (objSiblingDetail.CandidateObject != null)
            {
                UDSP_INSERT_SIBLING_DETAIL.CANDIDATE_ID_PARAM(objParameterList, objSiblingDetail.CandidateObject.CandidateId);
            }
            if (objSiblingDetail.GenderObject != null)
            {
                UDSP_INSERT_SIBLING_DETAIL.GENDER_ID_PARAM(objParameterList, objSiblingDetail.GenderObject.MetadataId);
            }
            if (objSiblingDetail.SchoolObject != null)
            {
                UDSP_INSERT_SIBLING_DETAIL.SCHOOL_ID_PARAM(objParameterList, objSiblingDetail.SchoolObject.SchoolId);
            }
            UDSP_INSERT_SIBLING_DETAIL.SCHOOL_NAME_PARAM(objParameterList, objSiblingDetail.SchoolName);
            UDSP_INSERT_SIBLING_DETAIL.SCHOOL_ADDRESS_PARAM(objParameterList, objSiblingDetail.SchoolAddress);
            UDSP_INSERT_SIBLING_DETAIL.SCHOOL_CONTACTS_PARAM(objParameterList, objSiblingDetail.SchoolContacts);
            if (objSiblingDetail.ClassObject != null)
            {
                UDSP_INSERT_SIBLING_DETAIL.CLASS_ID_PARAM(objParameterList, objSiblingDetail.ClassObject.ClassId);
            }
            UDSP_INSERT_SIBLING_DETAIL.REGISTRATION_NUMBER_PARAM(objParameterList, objSiblingDetail.RegistrationNumber);
            UDSP_INSERT_SIBLING_DETAIL.IS_CANDIDATE_PARAM(objParameterList, objSiblingDetail.IsCandidate);
            NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@IS_REQUIRED", objSiblingDetail.IsRequired);
            try
            {
                Logger.LogInfo("SiblingDetailDAO.cs : SaveSiblingDetailData() is started.");
                dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList, strInsertSiblingDetail, CommandType.StoredProcedure).ToString();
                if (GeneralUtility.IsInteger(dbExecuteStatus))
                {
                    if (Convert.ToInt32(dbExecuteStatus) > 0)
                    {
                        objSiblingDetail.SiblingId = Convert.ToInt32(dbExecuteStatus);
                        objSiblingDetail.DbOperationStatus = CommonConstant.SUCCEED;
                    }
                    else
                    {
                        objSiblingDetail.DbOperationStatus = CommonConstant.DUPLICATE;
                    }
                    Logger.LogInfo("SiblingDetailDAO.cs : SaveSiblingDetailData() is ended with success.");
                }
                else
                {
                    objSiblingDetail.DbOperationStatus = CommonConstant.FAIL;
                    Logger.LogInfo(dbExecuteStatus);
                    Logger.LogInfo("SiblingDetailDAO.cs : SaveSiblingDetailData() is ended with error.");
                }
            }
            catch (Exception ex)
            {
                objSiblingDetail.DbOperationStatus = CommonConstant.FAIL;
                Logger.LogError(ex.Message);
                Logger.LogInfo("SiblingDetailDAO.cs : SaveSiblingDetailData() is ended with error.");
            }
            return objSiblingDetail;
        }
        public SiblingDetail EditSiblingDetail(SiblingDetail objSiblingDetail)
        {
            objParameterList = new List<SqlParameter>();
            UDSP_UPDATE_SIBLING_DETAIL.SIBLING_ID_PARAM(objParameterList, objSiblingDetail.SiblingId);
            UDSP_UPDATE_SIBLING_DETAIL.FULL_NAME_PARAM(objParameterList, objSiblingDetail.FullName);
            UDSP_UPDATE_SIBLING_DETAIL.DATE_OF_BIRTH_PARAM(objParameterList, objSiblingDetail.DateOfBirth);
            if (objSiblingDetail.CandidateObject != null)
            {
                UDSP_UPDATE_SIBLING_DETAIL.CANDIDATE_ID_PARAM(objParameterList, objSiblingDetail.CandidateObject.CandidateId);
            }
            if (objSiblingDetail.GenderObject != null)
            {
                UDSP_UPDATE_SIBLING_DETAIL.GENDER_ID_PARAM(objParameterList, objSiblingDetail.GenderObject.MetadataId);
            }
            if (objSiblingDetail.SchoolObject != null)
            {
                UDSP_UPDATE_SIBLING_DETAIL.SCHOOL_ID_PARAM(objParameterList, objSiblingDetail.SchoolObject.SchoolId);
            }
            UDSP_UPDATE_SIBLING_DETAIL.SCHOOL_NAME_PARAM(objParameterList, objSiblingDetail.SchoolName);
            UDSP_UPDATE_SIBLING_DETAIL.SCHOOL_ADDRESS_PARAM(objParameterList, objSiblingDetail.SchoolAddress);
            UDSP_UPDATE_SIBLING_DETAIL.SCHOOL_CONTACTS_PARAM(objParameterList, objSiblingDetail.SchoolContacts);
            if (objSiblingDetail.ClassObject != null)
            {
                UDSP_UPDATE_SIBLING_DETAIL.CLASS_ID_PARAM(objParameterList, objSiblingDetail.ClassObject.ClassId);
            }
            UDSP_UPDATE_SIBLING_DETAIL.REGISTRATION_NUMBER_PARAM(objParameterList, objSiblingDetail.RegistrationNumber);
            UDSP_UPDATE_SIBLING_DETAIL.IS_CANDIDATE_PARAM(objParameterList, objSiblingDetail.IsCandidate);
            NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@IS_REQUIRED", objSiblingDetail.IsRequired);
            NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@PARENT_ID", objSiblingDetail.ParentId);
            NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@PARENT_VERSION", objSiblingDetail.ParentVersion);
            try
            {
                Logger.LogInfo("SiblingDetailDAO.cs : EditSiblingDetail() is started.");
                dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList, strEditSiblingDetail, CommandType.StoredProcedure).ToString();
                if (GeneralUtility.IsInteger(dbExecuteStatus))
                {
                    if (Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
                    {
                        objSiblingDetail.DbOperationStatus = CommonConstant.SUCCEED;
                    }
                    else if (Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
                    {
                        objSiblingDetail.DbOperationStatus = CommonConstant.INVALID;
                    }
                    else
                    {
                        objSiblingDetail.DbOperationStatus = CommonConstant.DUPLICATE;
                    }
                    Logger.LogInfo("SiblingDetailDAO.cs : EditSiblingDetail() is ended with success.");
                }
                else
                {
                    objSiblingDetail.DbOperationStatus = CommonConstant.FAIL;
                    Logger.LogInfo(dbExecuteStatus);
                    Logger.LogInfo("SiblingDetailDAO.cs : EditSiblingDetail() is ended with error.");
                }
            }
            catch (Exception ex)
            {
                objSiblingDetail.DbOperationStatus = CommonConstant.FAIL;
                Logger.LogError(ex.Message);
                Logger.LogInfo("SiblingDetailDAO.cs : EditSiblingDetail() is ended with error.");
            }
            return objSiblingDetail;
        }

	}
}
