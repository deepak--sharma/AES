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
    public class GuardianDetailDAO
    {
        List<SqlParameter> objParameterList = null;
        private string strDBTableName = "GUARDIAN_DETAIL";
        private string strParentDBTableName = "STUDENT_REGISTRATION_DETAIL";
        private string strSelectParentDetail = "SP_SELECT_STUDENT_REGISTRATION_DETAIL";
        private string strSelectGuardianDetail = "UDSP_SELECT_GUARDIAN_DETAIL";
        private string strInsertGuardianDetail = "UDSP_INSERT_GUARDIAN_DETAIL";
        private string strUpdateGuardianDetail = "SP_UPDATE_GUARDIAN_DETAIL";
        private string dbExecuteStatus = "";

        public GuardianDetail SelectGuardianDetail(GuardianDetail objGuardianDetail)
        {
            objParameterList = new List<SqlParameter>();
            UDSP_SELECT_GUARDIAN_DETAIL.GUARDIAN_ID_PARAM(objParameterList, objGuardianDetail.GuardianId);
            UDSP_SELECT_GUARDIAN_DETAIL.FULL_NAME_PARAM(objParameterList, objGuardianDetail.FullName);
            UDSP_SELECT_GUARDIAN_DETAIL.DATE_OF_BIRTH_PARAM(objParameterList, objGuardianDetail.DateOfBirth);
            UDSP_SELECT_GUARDIAN_DETAIL.CONTACT_NO_PARAM(objParameterList, objGuardianDetail.ContactNo);
            UDSP_SELECT_GUARDIAN_DETAIL.DESIGNATION_PARAM(objParameterList, objGuardianDetail.Designation);
            UDSP_SELECT_GUARDIAN_DETAIL.QUALIFICATION_PARAM(objParameterList, objGuardianDetail.Qualification);
            if (objGuardianDetail.NationalityObject != null)
            {
                UDSP_SELECT_GUARDIAN_DETAIL.NATIONALITY_ID_PARAM(objParameterList, objGuardianDetail.NationalityObject.MetadataId);
            }
            UDSP_SELECT_GUARDIAN_DETAIL.RELATION_PARAM(objParameterList, objGuardianDetail.Relation);
            UDSP_SELECT_GUARDIAN_DETAIL.IS_GUARDIAN_PARAM(objParameterList, objGuardianDetail.IsGuardian);
            UDSP_SELECT_GUARDIAN_DETAIL.IS_STAFF_PARAM(objParameterList, objGuardianDetail.IsStaff);
            UDSP_SELECT_GUARDIAN_DETAIL.WAS_STUDENT_PARAM(objParameterList, objGuardianDetail.WasStudent);
            UDSP_SELECT_GUARDIAN_DETAIL.OFFICE_DETAIL_PARAM(objParameterList, objGuardianDetail.OfficeDetail);
            try
            {
                Logger.LogInfo("GuardianDetailDAO.cs : SelectGuardianDetail() is started.");
                objGuardianDetail.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList, strSelectGuardianDetail, CommandType.StoredProcedure);
                objGuardianDetail.DbOperationStatus = CommonConstant.SUCCEED;
                Logger.LogInfo("GuardianDetailDAO.cs : SelectGuardianDetail() is ended with success.");
            }
            catch (Exception ex)
            {
                objGuardianDetail.DbOperationStatus = CommonConstant.FAIL;
                Logger.LogError(ex.Message);
                Logger.LogInfo("GuardianDetailDAO.cs : SelectGuardianDetail() is ended with error.");
            }
            return objGuardianDetail;
        }

        public GuardianDetail InsertGuardianDetail(GuardianDetail objGuardianDetail)
        {
            objParameterList = new List<SqlParameter>();

            UDSP_INSERT_GUARDIAN_DETAIL.FULL_NAME_PARAM(objParameterList, objGuardianDetail.FullName);
            UDSP_INSERT_GUARDIAN_DETAIL.DATE_OF_BIRTH_PARAM(objParameterList, objGuardianDetail.DateOfBirth);
            UDSP_INSERT_GUARDIAN_DETAIL.CONTACT_NO_PARAM(objParameterList, objGuardianDetail.ContactNo);
            UDSP_INSERT_GUARDIAN_DETAIL.DESIGNATION_PARAM(objParameterList, objGuardianDetail.Designation);
            UDSP_INSERT_GUARDIAN_DETAIL.QUALIFICATION_PARAM(objParameterList, objGuardianDetail.Qualification);
            if (objGuardianDetail.NationalityObject != null)
            {
                UDSP_INSERT_GUARDIAN_DETAIL.NATIONALITY_ID_PARAM(objParameterList, objGuardianDetail.NationalityObject.MetadataId);
            }
            UDSP_INSERT_GUARDIAN_DETAIL.RELATION_PARAM(objParameterList, objGuardianDetail.Relation);
            UDSP_INSERT_GUARDIAN_DETAIL.IS_GUARDIAN_PARAM(objParameterList, objGuardianDetail.IsGuardian);
            UDSP_INSERT_GUARDIAN_DETAIL.IS_STAFF_PARAM(objParameterList, objGuardianDetail.IsStaff);
            UDSP_INSERT_GUARDIAN_DETAIL.WAS_STUDENT_PARAM(objParameterList, objGuardianDetail.WasStudent);
            UDSP_INSERT_GUARDIAN_DETAIL.OFFICE_DETAIL_PARAM(objParameterList, objGuardianDetail.OfficeDetail);
            try
            {
                Logger.LogInfo("GuardianDetailDAO.cs : InsertGuardianDetail() is started.");
                dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList, strInsertGuardianDetail, CommandType.StoredProcedure).ToString();
                if (GeneralUtility.IsInteger(dbExecuteStatus))
                {
                    if (Convert.ToInt32(dbExecuteStatus) > 0)
                    {
                        objGuardianDetail.GuardianId = Convert.ToInt32(dbExecuteStatus);
                        objGuardianDetail.DbOperationStatus = CommonConstant.SUCCEED;
                    }
                    else
                    {
                        objGuardianDetail.DbOperationStatus = CommonConstant.DUPLICATE;
                    }
                    Logger.LogInfo("GuardianDetailDAO.cs : InsertGuardianDetail() is ended with success.");
                }
                else
                {
                    objGuardianDetail.DbOperationStatus = CommonConstant.FAIL;
                    Logger.LogInfo(dbExecuteStatus);
                    Logger.LogInfo("GuardianDetailDAO.cs : InsertGuardianDetail() is ended with error.");
                }
            }
            catch (Exception ex)
            {
                objGuardianDetail.DbOperationStatus = CommonConstant.FAIL;
                Logger.LogError(ex.Message);
                Logger.LogInfo("GuardianDetailDAO.cs : InsertGuardianDetail() is ended with error.");
            }
            return objGuardianDetail;
        }

        public GuardianDetail UpdateGuardianDetail(GuardianDetail objGuardianDetail)
        {
            objParameterList = new List<SqlParameter>();

            UDSP_UPDATE_GUARDIAN_DETAIL.GUARDIAN_ID_PARAM(objParameterList, objGuardianDetail.GuardianId);
            UDSP_UPDATE_GUARDIAN_DETAIL.FULL_NAME_PARAM(objParameterList, objGuardianDetail.FullName);
            UDSP_UPDATE_GUARDIAN_DETAIL.DATE_OF_BIRTH_PARAM(objParameterList, objGuardianDetail.DateOfBirth);
            UDSP_UPDATE_GUARDIAN_DETAIL.CONTACT_NO_PARAM(objParameterList, objGuardianDetail.ContactNo);
            UDSP_UPDATE_GUARDIAN_DETAIL.DESIGNATION_PARAM(objParameterList, objGuardianDetail.Designation);
            UDSP_UPDATE_GUARDIAN_DETAIL.QUALIFICATION_PARAM(objParameterList, objGuardianDetail.Qualification);
            if (objGuardianDetail.NationalityObject != null)
            {
                UDSP_UPDATE_GUARDIAN_DETAIL.NATIONALITY_ID_PARAM(objParameterList, objGuardianDetail.NationalityObject.MetadataId);
            }
            UDSP_UPDATE_GUARDIAN_DETAIL.RELATION_PARAM(objParameterList, objGuardianDetail.Relation);
            UDSP_UPDATE_GUARDIAN_DETAIL.IS_GUARDIAN_PARAM(objParameterList, objGuardianDetail.IsGuardian);
            UDSP_UPDATE_GUARDIAN_DETAIL.IS_STAFF_PARAM(objParameterList, objGuardianDetail.IsStaff);
            UDSP_UPDATE_GUARDIAN_DETAIL.WAS_STUDENT_PARAM(objParameterList, objGuardianDetail.WasStudent);
            UDSP_UPDATE_GUARDIAN_DETAIL.OFFICE_DETAIL_PARAM(objParameterList, objGuardianDetail.OfficeDetail);
            NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@PARENT_ID", objGuardianDetail.ParentId);
            NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@PARENT_VERSION", objGuardianDetail.ParentVersion);
            try
            {
                Logger.LogInfo("GuardianDetailDAO.cs : UpdateGuardianDetail() is started.");
                dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList, strUpdateGuardianDetail, CommandType.StoredProcedure).ToString();
                if (GeneralUtility.IsInteger(dbExecuteStatus))
                {
                    if (Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
                    {
                        objGuardianDetail.DbOperationStatus = CommonConstant.SUCCEED;
                    }
                    else if (Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
                    {
                        objGuardianDetail.DbOperationStatus = CommonConstant.INVALID;
                    }
                    else
                    {
                        objGuardianDetail.DbOperationStatus = CommonConstant.DUPLICATE;
                    }
                    Logger.LogInfo("GuardianDetailDAO.cs : UpdateGuardianDetail() is ended with success.");
                }
                else
                {
                    objGuardianDetail.DbOperationStatus = CommonConstant.FAIL;
                    Logger.LogInfo(dbExecuteStatus);
                    Logger.LogInfo("GuardianDetailDAO.cs : UpdateGuardianDetail() is ended with error.");
                }
            }
            catch (Exception ex)
            {
                objGuardianDetail.DbOperationStatus = CommonConstant.FAIL;
                Logger.LogError(ex.Message);
                Logger.LogInfo("GuardianDetailDAO.cs : UpdateGuardianDetail() is ended with error.");
            }
            return objGuardianDetail;
        }

        public GuardianDetail SelectRecordById(GuardianDetail objGuardianDetail)
        {
            try
            {
                Logger.LogInfo("GuardianDetailDAO.cs : SelectRecordById() is started.");                
                objGuardianDetail.ObjectDataSet = DataUtility.SelectRecordById(strDBTableName, objGuardianDetail.GuardianId, objGuardianDetail.Version, strSelectGuardianDetail);
                StudentRegistrationDetail objStudentRegistrationDetail = new StudentRegistrationDetail();
                objStudentRegistrationDetail.ObjectDataSet = DataUtility.SelectRecordById(strParentDBTableName, objGuardianDetail.ParentId, null, strSelectParentDetail);
                if (GeneralUtility.IsInteger(objGuardianDetail.ObjectDataSet.Tables[0].Rows[0][0]) && (objGuardianDetail.ObjectDataSet.Tables[1].Columns.Count > 1))
                {
                    if (Convert.ToInt32(objGuardianDetail.ObjectDataSet.Tables[0].Rows[0][0]) > 0)
                    {
                        objGuardianDetail.ParentVersion = Convert.ToInt32(objStudentRegistrationDetail.ObjectDataSet.Tables[1].Rows[0]["Version"]);
                        objGuardianDetail.IsRecordChanged = false;
                        objGuardianDetail.DbOperationStatus = CommonConstant.SUCCEED;
                    }
                    else
                    {
                        objGuardianDetail.IsRecordChanged = true;
                        objGuardianDetail.DbOperationStatus = CommonConstant.INVALID;
                    }
                    Logger.LogInfo("GuardianDetailDAO.cs : SelectRecordById() is ended with success.");
                }
                else
                {
                    objGuardianDetail.DbOperationStatus = CommonConstant.FAIL;
                    dbExecuteStatus = objGuardianDetail.ObjectDataSet.Tables[0].Rows[0][0].ToString() + " " + objGuardianDetail.ObjectDataSet.Tables[1].Rows[0][0].ToString();
                    Logger.LogInfo(dbExecuteStatus);
                    Logger.LogInfo("GuardianDetailDAO.cs : SelectRecordById() is ended with error.");
                }
            }
            catch (Exception ex)
            {
                objGuardianDetail.DbOperationStatus = CommonConstant.FAIL;
                Logger.LogError(ex.Message);
                Logger.LogInfo("GuardianDetailDAO.cs : SelectRecordById() is ended with error.");
            }
            return objGuardianDetail;
        }
    }
}
