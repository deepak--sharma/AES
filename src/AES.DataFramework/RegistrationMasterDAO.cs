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
    public class RegistrationMasterDAO
    {
        List<SqlParameter> objParameterList = null;
        private string strDBTableName = "REGISTRATION_MASTER";
        private string strSelectRegistrationMaster = "UDSP_SELECT_REGISTRATION_MASTER";
        private string strInsertRegistrationMaster = "UDSP_INSERT_REGISTRATION_MASTER";
        private string strUpdateRegistrationMaster = "UDSP_UPDATE_REGISTRATION_MASTER";
        private string strFetchActiveRegistration = "SP_FETCH_ACTIVE_REGISTRATION";
        private string dbExecuteStatus = "";

        public RegistrationMaster SelectRegistrationMaster(RegistrationMaster objRegistrationMaster)
        {
            objParameterList = new List<SqlParameter>();
            UDSP_SELECT_REGISTRATION_MASTER.REGISTRATION_ID_PARAM(objParameterList, objRegistrationMaster.RegistrationId);
            UDSP_SELECT_REGISTRATION_MASTER.REGISTRATION_NAME_PARAM(objParameterList, objRegistrationMaster.RegistrationName);
            if (objRegistrationMaster.ClassObject != null)
            {
                UDSP_SELECT_REGISTRATION_MASTER.CLASS_ID_PARAM(objParameterList, objRegistrationMaster.ClassObject.ClassId);
            }
            if (objRegistrationMaster.BranchObject != null)
            {
                UDSP_SELECT_REGISTRATION_MASTER.BRANCH_ID_PARAM(objParameterList, objRegistrationMaster.BranchObject.BranchId);
            }
            UDSP_SELECT_REGISTRATION_MASTER.START_DATE_PARAM(objParameterList, objRegistrationMaster.StartDate);
            UDSP_SELECT_REGISTRATION_MASTER.END_DATE_PARAM(objParameterList, objRegistrationMaster.EndDate);
            if (objRegistrationMaster.AcademicSessionObject != null)
            {
                UDSP_SELECT_REGISTRATION_MASTER.ACADEMIC_SESSION_ID_PARAM(objParameterList, objRegistrationMaster.AcademicSessionObject.SessionId);
            }
            UDSP_SELECT_REGISTRATION_MASTER.TOTAL_SEAT_PARAM(objParameterList, objRegistrationMaster.TotalSeat);
            UDSP_SELECT_REGISTRATION_MASTER.FREE_SEAT_PARAM(objParameterList, objRegistrationMaster.FreeSeat);
            UDSP_SELECT_REGISTRATION_MASTER.MANAGEMENT_SEAT_PARAM(objParameterList, objRegistrationMaster.ManagementSeat);
            UDSP_SELECT_REGISTRATION_MASTER.REGISTRATION_FEE_PARAM(objParameterList, objRegistrationMaster.RegistrationFee);
            UDSP_SELECT_REGISTRATION_MASTER.IS_PARTIAL_FEE_ALLOWED_PARAM(objParameterList, objRegistrationMaster.IsPartialFeeAllowed);
            UDSP_SELECT_REGISTRATION_MASTER.IS_RESERVATION_ALLOWED_PARAM(objParameterList, objRegistrationMaster.IsReservationAllowed);
            UDSP_SELECT_REGISTRATION_MASTER.ELIGIBILITY_PARAM(objParameterList, objRegistrationMaster.Eligibility);
            UDSP_SELECT_REGISTRATION_MASTER.INSTRUCTION_PARAM(objParameterList, objRegistrationMaster.Instruction);
            UDSP_SELECT_REGISTRATION_MASTER.DISCLAIMER_PARAM(objParameterList, objRegistrationMaster.Disclaimer);
            UDSP_SELECT_REGISTRATION_MASTER.RECORD_STATUS_PARAM(objParameterList, objRegistrationMaster.RecordStatus);
            //Added property for Registration Status and StreamId
            if (objRegistrationMaster.RegistrationStatusObject != null)
            {
                NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@REGISTRATION_STATUS_ID", objRegistrationMaster.RegistrationStatusObject.MetadataId);
            }
            if (objRegistrationMaster.StreamObject != null)
            {
                NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@STREAM_ID", objRegistrationMaster.StreamObject.StreamId);
            }
            try
            {
                Logger.LogInfo("RegistrationMasterDAO.cs : SelectRegistrationMaster() is started.");
                objRegistrationMaster.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList, strSelectRegistrationMaster, CommandType.StoredProcedure);
                objRegistrationMaster.DbOperationStatus = CommonConstant.SUCCEED;
                Logger.LogInfo("RegistrationMasterDAO.cs : SelectRegistrationMaster() is ended with success.");
            }
            catch (Exception ex)
            {
                objRegistrationMaster.DbOperationStatus = CommonConstant.FAIL;
                Logger.LogError(ex.Message);
                Logger.LogInfo("RegistrationMasterDAO.cs : SelectRegistrationMaster() is ended with error.");
            }
            return objRegistrationMaster;
        }

        public RegistrationMaster InsertRegistrationMaster(RegistrationMaster objRegistrationMaster)
        {
            objParameterList = new List<SqlParameter>();

            UDSP_INSERT_REGISTRATION_MASTER.REGISTRATION_NAME_PARAM(objParameterList, objRegistrationMaster.RegistrationName);
            if (objRegistrationMaster.ClassObject != null)
            {
                UDSP_INSERT_REGISTRATION_MASTER.CLASS_ID_PARAM(objParameterList, objRegistrationMaster.ClassObject.ClassId);
            }
            if (objRegistrationMaster.BranchObject != null)
            {
                UDSP_INSERT_REGISTRATION_MASTER.BRANCH_ID_PARAM(objParameterList, objRegistrationMaster.BranchObject.BranchId);
            }
            UDSP_INSERT_REGISTRATION_MASTER.START_DATE_PARAM(objParameterList, objRegistrationMaster.StartDate);
            UDSP_INSERT_REGISTRATION_MASTER.END_DATE_PARAM(objParameterList, objRegistrationMaster.EndDate);
            if (objRegistrationMaster.AcademicSessionObject != null)
            {
                UDSP_INSERT_REGISTRATION_MASTER.ACADEMIC_SESSION_ID_PARAM(objParameterList, objRegistrationMaster.AcademicSessionObject.SessionId);
            }
            UDSP_INSERT_REGISTRATION_MASTER.TOTAL_SEAT_PARAM(objParameterList, objRegistrationMaster.TotalSeat);
            UDSP_INSERT_REGISTRATION_MASTER.FREE_SEAT_PARAM(objParameterList, objRegistrationMaster.FreeSeat);
            UDSP_INSERT_REGISTRATION_MASTER.MANAGEMENT_SEAT_PARAM(objParameterList, objRegistrationMaster.ManagementSeat);
            UDSP_INSERT_REGISTRATION_MASTER.REGISTRATION_FEE_PARAM(objParameterList, objRegistrationMaster.RegistrationFee);
            UDSP_INSERT_REGISTRATION_MASTER.IS_PARTIAL_FEE_ALLOWED_PARAM(objParameterList, objRegistrationMaster.IsPartialFeeAllowed);
            UDSP_INSERT_REGISTRATION_MASTER.IS_RESERVATION_ALLOWED_PARAM(objParameterList, objRegistrationMaster.IsReservationAllowed);
            UDSP_INSERT_REGISTRATION_MASTER.ELIGIBILITY_PARAM(objParameterList, objRegistrationMaster.Eligibility);
            UDSP_INSERT_REGISTRATION_MASTER.INSTRUCTION_PARAM(objParameterList, objRegistrationMaster.Instruction);
            UDSP_INSERT_REGISTRATION_MASTER.DISCLAIMER_PARAM(objParameterList, objRegistrationMaster.Disclaimer);
            UDSP_INSERT_REGISTRATION_MASTER.VERSION_PARAM(objParameterList, objRegistrationMaster.Version);
            UDSP_INSERT_REGISTRATION_MASTER.CREATED_BY_PARAM(objParameterList, objRegistrationMaster.CreatedBy);
            UDSP_INSERT_REGISTRATION_MASTER.CREATED_ON_PARAM(objParameterList, objRegistrationMaster.CreatedOn);
            UDSP_INSERT_REGISTRATION_MASTER.MODIFIED_BY_PARAM(objParameterList, objRegistrationMaster.ModifiedBy);
            UDSP_INSERT_REGISTRATION_MASTER.MODIFIED_ON_PARAM(objParameterList, objRegistrationMaster.ModifiedOn);
            UDSP_INSERT_REGISTRATION_MASTER.RECORD_STATUS_PARAM(objParameterList, objRegistrationMaster.RecordStatus);
            //Added property for Registration Status and StreamId
            if (objRegistrationMaster.RegistrationStatusObject != null)
            {
                NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@REGISTRATION_STATUS_ID", objRegistrationMaster.RegistrationStatusObject.MetadataId);
            }
            if (objRegistrationMaster.StreamObject != null)
            {
                NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@STREAM_ID", objRegistrationMaster.StreamObject.StreamId);
            }
            try
            {
                Logger.LogInfo("RegistrationMasterDAO.cs : InsertRegistrationMaster() is started.");
                dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList, strInsertRegistrationMaster, CommandType.StoredProcedure).ToString();
                if (GeneralUtility.IsInteger(dbExecuteStatus))
                {
                    if (Convert.ToInt32(dbExecuteStatus) > 0)
                    {
                        objRegistrationMaster.RegistrationId = Convert.ToInt32(dbExecuteStatus);
                        objRegistrationMaster.DbOperationStatus = CommonConstant.SUCCEED;
                    }
                    else
                    {
                        objRegistrationMaster.DbOperationStatus = CommonConstant.DUPLICATE;
                    }
                    Logger.LogInfo("RegistrationMasterDAO.cs : InsertRegistrationMaster() is ended with success.");
                }
                else
                {
                    objRegistrationMaster.DbOperationStatus = CommonConstant.FAIL;
                    Logger.LogInfo(dbExecuteStatus);
                    Logger.LogInfo("RegistrationMasterDAO.cs : InsertRegistrationMaster() is ended with error.");
                }
            }
            catch (Exception ex)
            {
                objRegistrationMaster.DbOperationStatus = CommonConstant.FAIL;
                Logger.LogError(ex.Message);
                Logger.LogInfo("RegistrationMasterDAO.cs : InsertRegistrationMaster() is ended with error.");
            }
            return objRegistrationMaster;
        }

        public RegistrationMaster UpdateRegistrationMaster(RegistrationMaster objRegistrationMaster)
        {
            objParameterList = new List<SqlParameter>();

            UDSP_UPDATE_REGISTRATION_MASTER.REGISTRATION_ID_PARAM(objParameterList, objRegistrationMaster.RegistrationId);
            UDSP_UPDATE_REGISTRATION_MASTER.REGISTRATION_NAME_PARAM(objParameterList, objRegistrationMaster.RegistrationName);
            if (objRegistrationMaster.ClassObject != null)
            {
                UDSP_UPDATE_REGISTRATION_MASTER.CLASS_ID_PARAM(objParameterList, objRegistrationMaster.ClassObject.ClassId);
            }
            if (objRegistrationMaster.BranchObject != null)
            {
                UDSP_UPDATE_REGISTRATION_MASTER.BRANCH_ID_PARAM(objParameterList, objRegistrationMaster.BranchObject.BranchId);
            }
            UDSP_UPDATE_REGISTRATION_MASTER.START_DATE_PARAM(objParameterList, objRegistrationMaster.StartDate);
            UDSP_UPDATE_REGISTRATION_MASTER.END_DATE_PARAM(objParameterList, objRegistrationMaster.EndDate);
            if (objRegistrationMaster.AcademicSessionObject != null)
            {
                UDSP_UPDATE_REGISTRATION_MASTER.ACADEMIC_SESSION_ID_PARAM(objParameterList, objRegistrationMaster.AcademicSessionObject.SessionId);
            }
            UDSP_UPDATE_REGISTRATION_MASTER.TOTAL_SEAT_PARAM(objParameterList, objRegistrationMaster.TotalSeat);
            UDSP_UPDATE_REGISTRATION_MASTER.FREE_SEAT_PARAM(objParameterList, objRegistrationMaster.FreeSeat);
            UDSP_UPDATE_REGISTRATION_MASTER.MANAGEMENT_SEAT_PARAM(objParameterList, objRegistrationMaster.ManagementSeat);
            UDSP_UPDATE_REGISTRATION_MASTER.REGISTRATION_FEE_PARAM(objParameterList, objRegistrationMaster.RegistrationFee);
            UDSP_UPDATE_REGISTRATION_MASTER.IS_PARTIAL_FEE_ALLOWED_PARAM(objParameterList, objRegistrationMaster.IsPartialFeeAllowed);
            UDSP_UPDATE_REGISTRATION_MASTER.IS_RESERVATION_ALLOWED_PARAM(objParameterList, objRegistrationMaster.IsReservationAllowed);
            UDSP_UPDATE_REGISTRATION_MASTER.ELIGIBILITY_PARAM(objParameterList, objRegistrationMaster.Eligibility);
            UDSP_UPDATE_REGISTRATION_MASTER.INSTRUCTION_PARAM(objParameterList, objRegistrationMaster.Instruction);
            UDSP_UPDATE_REGISTRATION_MASTER.DISCLAIMER_PARAM(objParameterList, objRegistrationMaster.Disclaimer);
            UDSP_UPDATE_REGISTRATION_MASTER.VERSION_PARAM(objParameterList, objRegistrationMaster.Version);
            UDSP_UPDATE_REGISTRATION_MASTER.CREATED_BY_PARAM(objParameterList, objRegistrationMaster.CreatedBy);
            UDSP_UPDATE_REGISTRATION_MASTER.CREATED_ON_PARAM(objParameterList, objRegistrationMaster.CreatedOn);
            UDSP_UPDATE_REGISTRATION_MASTER.MODIFIED_BY_PARAM(objParameterList, objRegistrationMaster.ModifiedBy);
            UDSP_UPDATE_REGISTRATION_MASTER.MODIFIED_ON_PARAM(objParameterList, objRegistrationMaster.ModifiedOn);
            UDSP_UPDATE_REGISTRATION_MASTER.RECORD_STATUS_PARAM(objParameterList, objRegistrationMaster.RecordStatus);
            //Added property for Registration Status and StreamId
            if (objRegistrationMaster.RegistrationStatusObject != null)
            {
                NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@REGISTRATION_STATUS_ID", objRegistrationMaster.RegistrationStatusObject.MetadataId);
            }
            if (objRegistrationMaster.StreamObject != null)
            {
                NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@STREAM_ID", objRegistrationMaster.StreamObject.StreamId);
            }
            try
            {
                Logger.LogInfo("RegistrationMasterDAO.cs : UpdateRegistrationMaster() is started.");
                dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList, strUpdateRegistrationMaster, CommandType.StoredProcedure).ToString();
                if (GeneralUtility.IsInteger(dbExecuteStatus))
                {
                    if (Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
                    {
                        objRegistrationMaster.DbOperationStatus = CommonConstant.SUCCEED;
                    }
                    else if (Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
                    {
                        objRegistrationMaster.DbOperationStatus = CommonConstant.INVALID;
                    }
                    else
                    {
                        objRegistrationMaster.DbOperationStatus = CommonConstant.DUPLICATE;
                    }
                    Logger.LogInfo("RegistrationMasterDAO.cs : UpdateRegistrationMaster() is ended with success.");
                }
                else
                {
                    objRegistrationMaster.DbOperationStatus = CommonConstant.FAIL;
                    Logger.LogInfo(dbExecuteStatus);
                    Logger.LogInfo("RegistrationMasterDAO.cs : UpdateRegistrationMaster() is ended with error.");
                }
            }
            catch (Exception ex)
            {
                objRegistrationMaster.DbOperationStatus = CommonConstant.FAIL;
                Logger.LogError(ex.Message);
                Logger.LogInfo("RegistrationMasterDAO.cs : UpdateRegistrationMaster() is ended with error.");
            }
            return objRegistrationMaster;
        }

        public RegistrationMaster ActivateDeactivateRegistrationMaster(RegistrationMaster objRegistrationMaster)
        {
            try
            {
                Logger.LogInfo("RegistrationMasterDAO.cs : ActivateDeactivateRegistrationMasterDAO() is started.");
                dbExecuteStatus = DataUtility.ActivateDeactivateObject(strDBTableName, objRegistrationMaster.RegistrationId,
                                        objRegistrationMaster.Version, objRegistrationMaster.RecordStatus, objRegistrationMaster.ModifiedBy);
                if (GeneralUtility.IsInteger(dbExecuteStatus))
                {
                    if (Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
                    {
                        objRegistrationMaster.DbOperationStatus = CommonConstant.SUCCEED;
                        Logger.LogInfo("RegistrationMasterDAO.cs : ActivateDeactivateRegistrationMaster() is ended with success.");
                    }
                    else
                    {
                        objRegistrationMaster.DbOperationStatus = CommonConstant.INVALID;
                        Logger.LogInfo("RegistrationMasterDAO.cs : ActivateDeactivateRegistrationMaster() is ended with success.");
                    }
                }
                else
                {
                    objRegistrationMaster.DbOperationStatus = CommonConstant.FAIL;
                    Logger.LogInfo(dbExecuteStatus);
                    Logger.LogInfo("RegistrationMasterDAO.cs : ActivateDeactivateRegistrationMaster() is ended with error.");
                }
            }
            catch (Exception ex)
            {
                objRegistrationMaster.DbOperationStatus = CommonConstant.FAIL;
                Logger.LogError(ex.Message);
                Logger.LogInfo("RegistrationMasterDAO.cs : ActivateDeactivateRegistrationMaster() is ended with error.");
            }
            return objRegistrationMaster;
        }

        public RegistrationMaster SelectRecordById(RegistrationMaster objRegistrationMaster)
        {
            try
            {
                Logger.LogInfo("RegistrationMasterDAO.cs : SelectRecordById() is started.");
                objRegistrationMaster.ObjectDataSet = DataUtility.SelectRecordById(strDBTableName, objRegistrationMaster.RegistrationId, objRegistrationMaster.Version, strSelectRegistrationMaster);
                if (GeneralUtility.IsInteger(objRegistrationMaster.ObjectDataSet.Tables[0].Rows[0][0]) && (objRegistrationMaster.ObjectDataSet.Tables[1].Columns.Count > 1))
                {
                    if (Convert.ToInt32(objRegistrationMaster.ObjectDataSet.Tables[0].Rows[0][0]) > 0)
                    {
                        objRegistrationMaster.IsRecordChanged = false;
                        objRegistrationMaster.DbOperationStatus = CommonConstant.SUCCEED;
                    }
                    else
                    {
                        objRegistrationMaster.IsRecordChanged = true;
                        objRegistrationMaster.DbOperationStatus = CommonConstant.INVALID;
                    }
                    Logger.LogInfo("RegistrationMasterDAO.cs : SelectRecordById() is ended with success.");
                }
                else
                {
                    objRegistrationMaster.DbOperationStatus = CommonConstant.FAIL;
                    dbExecuteStatus = objRegistrationMaster.ObjectDataSet.Tables[0].Rows[0][0].ToString() + " " + objRegistrationMaster.ObjectDataSet.Tables[1].Rows[0][0].ToString();
                    Logger.LogInfo(dbExecuteStatus);
                    Logger.LogInfo("RegistrationMasterDAO.cs : SelectRecordById() is ended with error.");
                }
            }
            catch (Exception ex)
            {
                objRegistrationMaster.DbOperationStatus = CommonConstant.FAIL;
                Logger.LogError(ex.Message);
                Logger.LogInfo("RegistrationMasterDAO.cs : SelectRecordById() is ended with error.");
            }
            return objRegistrationMaster;
        }

        public RegistrationMaster FetchActiveRegistration(RegistrationMaster objRegistrationMaster)
        {
            objParameterList = new List<SqlParameter>();
            if (objRegistrationMaster.BranchObject != null)
            {
                UDSP_SELECT_REGISTRATION_MASTER.BRANCH_ID_PARAM(objParameterList, objRegistrationMaster.BranchObject.BranchId);
            }
            //Added property for Registration Status and StreamId
            if (objRegistrationMaster.RegistrationStatusObject != null)
            {
                NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@REGISTRATION_STATUS_ID", objRegistrationMaster.RegistrationStatusObject.MetadataId);
            }

            try
            {
                Logger.LogInfo("RegistrationMasterDAO.cs : FetchActiveRegistration() is started.");
                objRegistrationMaster.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList, strFetchActiveRegistration, CommandType.StoredProcedure);
                objRegistrationMaster.DbOperationStatus = CommonConstant.SUCCEED;
                Logger.LogInfo("RegistrationMasterDAO.cs : FetchActiveRegistration() is ended with success.");
            }
            catch (Exception ex)
            {
                objRegistrationMaster.DbOperationStatus = CommonConstant.FAIL;
                Logger.LogError(ex.Message);
                Logger.LogInfo("RegistrationMasterDAO.cs : FetchActiveRegistration() is ended with error.");
            }
            return objRegistrationMaster;
        }
    }
}
