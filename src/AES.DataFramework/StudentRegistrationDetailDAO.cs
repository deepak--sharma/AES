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
    public class StudentRegistrationDetailDAO
    {
        List<SqlParameter> objParameterList = null;
        private string strDBTableName = "STUDENT_REGISTRATION_DETAIL";

        private string strSearchStudentRegistrationDetail = "SP_SEARCH_STUDENT_REGISTRATION_DETAIL";
        private string strSelectStudentRegistrationDetail = "SP_SELECT_STUDENT_REGISTRATION_DETAIL";
        private string strInsertStudentRegistrationDetail = "UDSP_INSERT_STUDENT_REGISTRATION_DETAIL";
        private string strUpdateStudentRegistrationDetail = "UDSP_UPDATE_STUDENT_REGISTRATION_DETAIL";
        private string strUpdateStudentRegistrationStatus = "SP_UPDATE_STUDENT_REGISTRATION_STATUS";
        private string dbExecuteStatus = "";

        public StudentRegistrationDetail SearchStudentRegistrationDetail(StudentRegistrationDetail objStudentRegistrationDetail)
        {
            objParameterList = new List<SqlParameter>();
            UDSP_SELECT_STUDENT_REGISTRATION_DETAIL.STUDENT_REGISTRATION_ID_PARAM(objParameterList, objStudentRegistrationDetail.StudentRegistrationId);
            UDSP_SELECT_STUDENT_REGISTRATION_DETAIL.REGISTRATION_NUMBER_PARAM(objParameterList, objStudentRegistrationDetail.RegistrationNumber);
            if (objStudentRegistrationDetail.RegistrationStatusObject != null)
            {
                UDSP_SELECT_STUDENT_REGISTRATION_DETAIL.REGISTRATION_STATUS_ID_PARAM(objParameterList, objStudentRegistrationDetail.RegistrationStatusObject.MetadataId);
            }
            NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@START_DATE", objStudentRegistrationDetail.StartDate);
            NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@END_DATE", objStudentRegistrationDetail.EndDate);
            UDSP_SELECT_STUDENT_REGISTRATION_DETAIL.RECORD_STATUS_PARAM(objParameterList, objStudentRegistrationDetail.RecordStatus);
            try
            {
                Logger.LogInfo("StudentRegistrationDetailDAO.cs : SearchStudentRegistrationDetail() is started.");
                objStudentRegistrationDetail.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList, strSearchStudentRegistrationDetail, CommandType.StoredProcedure);
                objStudentRegistrationDetail.DbOperationStatus = CommonConstant.SUCCEED;
                Logger.LogInfo("StudentRegistrationDetailDAO.cs : SearchStudentRegistrationDetail() is ended with success.");
            }
            catch (Exception ex)
            {
                objStudentRegistrationDetail.DbOperationStatus = CommonConstant.FAIL;
                Logger.LogError(ex.Message);
                Logger.LogInfo("StudentRegistrationDetailDAO.cs : SearchStudentRegistrationDetail() is ended with error.");
            }
            return objStudentRegistrationDetail;
        }

        public StudentRegistrationDetail SelectStudentRegistrationDetail(StudentRegistrationDetail objStudentRegistrationDetail)
        {
            objParameterList = new List<SqlParameter>();
            UDSP_SELECT_STUDENT_REGISTRATION_DETAIL.STUDENT_REGISTRATION_ID_PARAM(objParameterList, objStudentRegistrationDetail.StudentRegistrationId);
            UDSP_SELECT_STUDENT_REGISTRATION_DETAIL.REGISTRATION_NUMBER_PARAM(objParameterList, objStudentRegistrationDetail.RegistrationNumber);
            if (objStudentRegistrationDetail.CandidateObject != null)
            {
                UDSP_SELECT_STUDENT_REGISTRATION_DETAIL.CANDIDATE_ID_PARAM(objParameterList, objStudentRegistrationDetail.CandidateObject.CandidateId);
            }
            if (objStudentRegistrationDetail.RegistrationObject != null)
            {
                UDSP_SELECT_STUDENT_REGISTRATION_DETAIL.REGISTRATION_ID_PARAM(objParameterList, objStudentRegistrationDetail.RegistrationObject.RegistrationId);
            }
            UDSP_SELECT_STUDENT_REGISTRATION_DETAIL.FEE_SUBMITED_PARAM(objParameterList, objStudentRegistrationDetail.FeeSubmited);
            if (objStudentRegistrationDetail.BoardingTypeObject != null)
            {
                UDSP_SELECT_STUDENT_REGISTRATION_DETAIL.BOARDING_TYPE_ID_PARAM(objParameterList, objStudentRegistrationDetail.BoardingTypeObject.MetadataId);
            }
            UDSP_SELECT_STUDENT_REGISTRATION_DETAIL.IS_TRANSPORT_REQUIRED_PARAM(objParameterList, objStudentRegistrationDetail.IsTransportRequired);
            UDSP_SELECT_STUDENT_REGISTRATION_DETAIL.REGISTRATION_DATE_PARAM(objParameterList, objStudentRegistrationDetail.RegistrationDate);
            if (objStudentRegistrationDetail.RegistrationStatusObject != null)
            {
                UDSP_SELECT_STUDENT_REGISTRATION_DETAIL.REGISTRATION_STATUS_ID_PARAM(objParameterList, objStudentRegistrationDetail.RegistrationStatusObject.MetadataId);
            }
            UDSP_SELECT_STUDENT_REGISTRATION_DETAIL.DISTANCE_PARAM(objParameterList, objStudentRegistrationDetail.Distance);
            UDSP_SELECT_STUDENT_REGISTRATION_DETAIL.RECORD_STATUS_PARAM(objParameterList, objStudentRegistrationDetail.RecordStatus);
            try
            {
                Logger.LogInfo("StudentRegistrationDetailDAO.cs : SelectStudentRegistrationDetail() is started.");
                objStudentRegistrationDetail.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList, strSelectStudentRegistrationDetail, CommandType.StoredProcedure);
                objStudentRegistrationDetail.DbOperationStatus = CommonConstant.SUCCEED;
                Logger.LogInfo("StudentRegistrationDetailDAO.cs : SelectStudentRegistrationDetail() is ended with success.");
            }
            catch (Exception ex)
            {
                objStudentRegistrationDetail.DbOperationStatus = CommonConstant.FAIL;
                Logger.LogError(ex.Message);
                Logger.LogInfo("StudentRegistrationDetailDAO.cs : SelectStudentRegistrationDetail() is ended with error.");
            }
            return objStudentRegistrationDetail;
        }

        public StudentRegistrationDetail InsertStudentRegistrationDetail(StudentRegistrationDetail objStudentRegistrationDetail)
        {
            objParameterList = new List<SqlParameter>();

            UDSP_INSERT_STUDENT_REGISTRATION_DETAIL.REGISTRATION_NUMBER_PARAM(objParameterList, objStudentRegistrationDetail.RegistrationNumber);
            if (objStudentRegistrationDetail.CandidateObject != null)
            {
                UDSP_INSERT_STUDENT_REGISTRATION_DETAIL.CANDIDATE_ID_PARAM(objParameterList, objStudentRegistrationDetail.CandidateObject.CandidateId);
            }
            if (objStudentRegistrationDetail.RegistrationObject != null)
            {
                UDSP_INSERT_STUDENT_REGISTRATION_DETAIL.REGISTRATION_ID_PARAM(objParameterList, objStudentRegistrationDetail.RegistrationObject.RegistrationId);
            }
            UDSP_INSERT_STUDENT_REGISTRATION_DETAIL.FEE_SUBMITED_PARAM(objParameterList, objStudentRegistrationDetail.FeeSubmited);
            if (objStudentRegistrationDetail.BoardingTypeObject != null)
            {
                UDSP_INSERT_STUDENT_REGISTRATION_DETAIL.BOARDING_TYPE_ID_PARAM(objParameterList, objStudentRegistrationDetail.BoardingTypeObject.MetadataId);
            }
            UDSP_INSERT_STUDENT_REGISTRATION_DETAIL.IS_TRANSPORT_REQUIRED_PARAM(objParameterList, objStudentRegistrationDetail.IsTransportRequired);
            UDSP_INSERT_STUDENT_REGISTRATION_DETAIL.REGISTRATION_DATE_PARAM(objParameterList, objStudentRegistrationDetail.RegistrationDate);
            if (objStudentRegistrationDetail.RegistrationStatusObject != null)
            {
                UDSP_INSERT_STUDENT_REGISTRATION_DETAIL.REGISTRATION_STATUS_ID_PARAM(objParameterList, objStudentRegistrationDetail.RegistrationStatusObject.MetadataId);
            }
            UDSP_INSERT_STUDENT_REGISTRATION_DETAIL.DISTANCE_PARAM(objParameterList, objStudentRegistrationDetail.Distance);
            UDSP_INSERT_STUDENT_REGISTRATION_DETAIL.VERSION_PARAM(objParameterList, objStudentRegistrationDetail.Version);
            UDSP_INSERT_STUDENT_REGISTRATION_DETAIL.CREATED_BY_PARAM(objParameterList, objStudentRegistrationDetail.CreatedBy);
            UDSP_INSERT_STUDENT_REGISTRATION_DETAIL.CREATED_ON_PARAM(objParameterList, objStudentRegistrationDetail.CreatedOn);
            UDSP_INSERT_STUDENT_REGISTRATION_DETAIL.MODIFIED_BY_PARAM(objParameterList, objStudentRegistrationDetail.ModifiedBy);
            UDSP_INSERT_STUDENT_REGISTRATION_DETAIL.MODIFIED_ON_PARAM(objParameterList, objStudentRegistrationDetail.ModifiedOn);
            UDSP_INSERT_STUDENT_REGISTRATION_DETAIL.RECORD_STATUS_PARAM(objParameterList, objStudentRegistrationDetail.RecordStatus);
            try
            {
                Logger.LogInfo("StudentRegistrationDetailDAO.cs : InsertStudentRegistrationDetail() is started.");
                dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList, strInsertStudentRegistrationDetail, CommandType.StoredProcedure).ToString();
                if (GeneralUtility.IsInteger(dbExecuteStatus))
                {
                    if (Convert.ToInt32(dbExecuteStatus) > 0)
                    {
                        objStudentRegistrationDetail.StudentRegistrationId = Convert.ToInt32(dbExecuteStatus);
                        objStudentRegistrationDetail.DbOperationStatus = CommonConstant.SUCCEED;
                    }
                    else
                    {
                        objStudentRegistrationDetail.DbOperationStatus = CommonConstant.DUPLICATE;
                    }
                    Logger.LogInfo("StudentRegistrationDetailDAO.cs : InsertStudentRegistrationDetail() is ended with success.");
                }
                else
                {
                    objStudentRegistrationDetail.DbOperationStatus = CommonConstant.FAIL;
                    Logger.LogInfo(dbExecuteStatus);
                    Logger.LogInfo("StudentRegistrationDetailDAO.cs : InsertStudentRegistrationDetail() is ended with error.");
                }
            }
            catch (Exception ex)
            {
                objStudentRegistrationDetail.DbOperationStatus = CommonConstant.FAIL;
                Logger.LogError(ex.Message);
                Logger.LogInfo("StudentRegistrationDetailDAO.cs : InsertStudentRegistrationDetail() is ended with error.");
            }
            return objStudentRegistrationDetail;
        }

        public StudentRegistrationDetail UpdateStudentRegistrationDetail(StudentRegistrationDetail objStudentRegistrationDetail)
        {
            objParameterList = new List<SqlParameter>();

            UDSP_UPDATE_STUDENT_REGISTRATION_DETAIL.STUDENT_REGISTRATION_ID_PARAM(objParameterList, objStudentRegistrationDetail.StudentRegistrationId);
            UDSP_UPDATE_STUDENT_REGISTRATION_DETAIL.REGISTRATION_NUMBER_PARAM(objParameterList, objStudentRegistrationDetail.RegistrationNumber);
            if (objStudentRegistrationDetail.CandidateObject != null)
            {
                UDSP_UPDATE_STUDENT_REGISTRATION_DETAIL.CANDIDATE_ID_PARAM(objParameterList, objStudentRegistrationDetail.CandidateObject.CandidateId);
            }
            if (objStudentRegistrationDetail.RegistrationObject != null)
            {
                UDSP_UPDATE_STUDENT_REGISTRATION_DETAIL.REGISTRATION_ID_PARAM(objParameterList, objStudentRegistrationDetail.RegistrationObject.RegistrationId);
            }
            UDSP_UPDATE_STUDENT_REGISTRATION_DETAIL.FEE_SUBMITED_PARAM(objParameterList, objStudentRegistrationDetail.FeeSubmited);
            if (objStudentRegistrationDetail.BoardingTypeObject != null)
            {
                UDSP_UPDATE_STUDENT_REGISTRATION_DETAIL.BOARDING_TYPE_ID_PARAM(objParameterList, objStudentRegistrationDetail.BoardingTypeObject.MetadataId);
            }
            UDSP_UPDATE_STUDENT_REGISTRATION_DETAIL.IS_TRANSPORT_REQUIRED_PARAM(objParameterList, objStudentRegistrationDetail.IsTransportRequired);
            UDSP_UPDATE_STUDENT_REGISTRATION_DETAIL.REGISTRATION_DATE_PARAM(objParameterList, objStudentRegistrationDetail.RegistrationDate);
            if (objStudentRegistrationDetail.RegistrationStatusObject != null)
            {
                UDSP_UPDATE_STUDENT_REGISTRATION_DETAIL.REGISTRATION_STATUS_ID_PARAM(objParameterList, objStudentRegistrationDetail.RegistrationStatusObject.MetadataId);
            }
            UDSP_UPDATE_STUDENT_REGISTRATION_DETAIL.DISTANCE_PARAM(objParameterList, objStudentRegistrationDetail.Distance);
            UDSP_UPDATE_STUDENT_REGISTRATION_DETAIL.VERSION_PARAM(objParameterList, objStudentRegistrationDetail.Version);
            UDSP_UPDATE_STUDENT_REGISTRATION_DETAIL.CREATED_BY_PARAM(objParameterList, objStudentRegistrationDetail.CreatedBy);
            UDSP_UPDATE_STUDENT_REGISTRATION_DETAIL.CREATED_ON_PARAM(objParameterList, objStudentRegistrationDetail.CreatedOn);
            UDSP_UPDATE_STUDENT_REGISTRATION_DETAIL.MODIFIED_BY_PARAM(objParameterList, objStudentRegistrationDetail.ModifiedBy);
            UDSP_UPDATE_STUDENT_REGISTRATION_DETAIL.MODIFIED_ON_PARAM(objParameterList, objStudentRegistrationDetail.ModifiedOn);
            UDSP_UPDATE_STUDENT_REGISTRATION_DETAIL.RECORD_STATUS_PARAM(objParameterList, objStudentRegistrationDetail.RecordStatus);
            try
            {
                Logger.LogInfo("StudentRegistrationDetailDAO.cs : UpdateStudentRegistrationDetail() is started.");
                dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList, strUpdateStudentRegistrationDetail, CommandType.StoredProcedure).ToString();
                if (GeneralUtility.IsInteger(dbExecuteStatus))
                {
                    if (Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
                    {
                        objStudentRegistrationDetail.DbOperationStatus = CommonConstant.SUCCEED;
                    }
                    else if (Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
                    {
                        objStudentRegistrationDetail.DbOperationStatus = CommonConstant.INVALID;
                    }
                    else
                    {
                        objStudentRegistrationDetail.DbOperationStatus = CommonConstant.DUPLICATE;
                    }
                    Logger.LogInfo("StudentRegistrationDetailDAO.cs : UpdateStudentRegistrationDetail() is ended with success.");
                }
                else
                {
                    objStudentRegistrationDetail.DbOperationStatus = CommonConstant.FAIL;
                    Logger.LogInfo(dbExecuteStatus);
                    Logger.LogInfo("StudentRegistrationDetailDAO.cs : UpdateStudentRegistrationDetail() is ended with error.");
                }
            }
            catch (Exception ex)
            {
                objStudentRegistrationDetail.DbOperationStatus = CommonConstant.FAIL;
                Logger.LogError(ex.Message);
                Logger.LogInfo("StudentRegistrationDetailDAO.cs : UpdateStudentRegistrationDetail() is ended with error.");
            }
            return objStudentRegistrationDetail;
        }

        public StudentRegistrationDetail EditStudentRegistrationStatus(int registrationId, int version, int registrationStatusId, string comment, string modifiedBy, DateTime modifiedOn)
        {
            StudentRegistrationDetail objStudentRegistrationDetail = new StudentRegistrationDetail();
            objParameterList = new List<SqlParameter>();

            UDSP_UPDATE_STUDENT_REGISTRATION_DETAIL.STUDENT_REGISTRATION_ID_PARAM(objParameterList, registrationId);
            UDSP_UPDATE_STUDENT_REGISTRATION_DETAIL.REGISTRATION_STATUS_ID_PARAM(objParameterList, registrationStatusId);
            NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@Comment", comment);
            UDSP_UPDATE_STUDENT_REGISTRATION_DETAIL.VERSION_PARAM(objParameterList, version);
            UDSP_UPDATE_STUDENT_REGISTRATION_DETAIL.MODIFIED_BY_PARAM(objParameterList, modifiedBy);
            UDSP_UPDATE_STUDENT_REGISTRATION_DETAIL.MODIFIED_ON_PARAM(objParameterList, modifiedOn);

            try
            {
                Logger.LogInfo("StudentRegistrationDetailDAO.cs : UpdateStudentRegistrationStatus() is started.");
                dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList, strUpdateStudentRegistrationStatus, CommandType.StoredProcedure).ToString();
                if (GeneralUtility.IsInteger(dbExecuteStatus))
                {
                    if (Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
                    {
                        objStudentRegistrationDetail.DbOperationStatus = CommonConstant.SUCCEED;
                    }
                    else if (Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
                    {
                        objStudentRegistrationDetail.DbOperationStatus = CommonConstant.INVALID;
                    }
                    else
                    {
                        objStudentRegistrationDetail.DbOperationStatus = CommonConstant.DUPLICATE;
                    }
                    Logger.LogInfo("StudentRegistrationDetailDAO.cs : UpdateStudentRegistrationStatus() is ended with success.");
                }
                else
                {
                    objStudentRegistrationDetail.DbOperationStatus = CommonConstant.FAIL;
                    Logger.LogInfo(dbExecuteStatus);
                    Logger.LogInfo("StudentRegistrationDetailDAO.cs : UpdateStudentRegistrationStatus() is ended with error.");
                }
            }
            catch (Exception ex)
            {
                objStudentRegistrationDetail.DbOperationStatus = CommonConstant.FAIL;
                Logger.LogError(ex.Message);
                Logger.LogInfo("StudentRegistrationDetailDAO.cs : UpdateStudentRegistrationDetail() is ended with error.");
            }
            return objStudentRegistrationDetail;
        }

        public StudentRegistrationDetail ActivateDeactivateStudentRegistrationDetail(StudentRegistrationDetail objStudentRegistrationDetail)
        {
            try
            {
                Logger.LogInfo("StudentRegistrationDetailDAO.cs : ActivateDeactivateStudentRegistrationDetailDAO() is started.");
                dbExecuteStatus = DataUtility.ActivateDeactivateObject(strDBTableName, objStudentRegistrationDetail.StudentRegistrationId,
                                        objStudentRegistrationDetail.Version, objStudentRegistrationDetail.RecordStatus, objStudentRegistrationDetail.ModifiedBy);
                if (GeneralUtility.IsInteger(dbExecuteStatus))
                {
                    if (Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
                    {
                        objStudentRegistrationDetail.DbOperationStatus = CommonConstant.SUCCEED;
                        Logger.LogInfo("StudentRegistrationDetailDAO.cs : ActivateDeactivateStudentRegistrationDetail() is ended with success.");
                    }
                    else
                    {
                        objStudentRegistrationDetail.DbOperationStatus = CommonConstant.INVALID;
                        Logger.LogInfo("StudentRegistrationDetailDAO.cs : ActivateDeactivateStudentRegistrationDetail() is ended with success.");
                    }
                }
                else
                {
                    objStudentRegistrationDetail.DbOperationStatus = CommonConstant.FAIL;
                    Logger.LogInfo(dbExecuteStatus);
                    Logger.LogInfo("StudentRegistrationDetailDAO.cs : ActivateDeactivateStudentRegistrationDetail() is ended with error.");
                }
            }
            catch (Exception ex)
            {
                objStudentRegistrationDetail.DbOperationStatus = CommonConstant.FAIL;
                Logger.LogError(ex.Message);
                Logger.LogInfo("StudentRegistrationDetailDAO.cs : ActivateDeactivateStudentRegistrationDetail() is ended with error.");
            }
            return objStudentRegistrationDetail;
        }

        public StudentRegistrationDetail SelectRecordById(StudentRegistrationDetail objStudentRegistrationDetail)
        {
            try
            {
                Logger.LogInfo("StudentRegistrationDetailDAO.cs : SelectRecordById() is started.");
                objStudentRegistrationDetail.ObjectDataSet = DataUtility.SelectRecordById(strDBTableName, objStudentRegistrationDetail.StudentRegistrationId, objStudentRegistrationDetail.Version, strSelectStudentRegistrationDetail);
                if (GeneralUtility.IsInteger(objStudentRegistrationDetail.ObjectDataSet.Tables[0].Rows[0][0]) && (objStudentRegistrationDetail.ObjectDataSet.Tables[1].Columns.Count > 1))
                {
                    if (Convert.ToInt32(objStudentRegistrationDetail.ObjectDataSet.Tables[0].Rows[0][0]) > 0)
                    {
                        objStudentRegistrationDetail.IsRecordChanged = false;
                        objStudentRegistrationDetail.DbOperationStatus = CommonConstant.SUCCEED;
                    }
                    else
                    {
                        objStudentRegistrationDetail.IsRecordChanged = true;
                        objStudentRegistrationDetail.DbOperationStatus = CommonConstant.INVALID;
                    }
                    Logger.LogInfo("StudentRegistrationDetailDAO.cs : SelectRecordById() is ended with success.");
                }
                else
                {
                    objStudentRegistrationDetail.DbOperationStatus = CommonConstant.FAIL;
                    dbExecuteStatus = objStudentRegistrationDetail.ObjectDataSet.Tables[0].Rows[0][0].ToString() + " " + objStudentRegistrationDetail.ObjectDataSet.Tables[1].Rows[0][0].ToString();
                    Logger.LogInfo(dbExecuteStatus);
                    Logger.LogInfo("StudentRegistrationDetailDAO.cs : SelectRecordById() is ended with error.");
                }
            }
            catch (Exception ex)
            {
                objStudentRegistrationDetail.DbOperationStatus = CommonConstant.FAIL;
                Logger.LogError(ex.Message);
                Logger.LogInfo("StudentRegistrationDetailDAO.cs : SelectRecordById() is ended with error.");
            }
            return objStudentRegistrationDetail;
        }
    }
}
