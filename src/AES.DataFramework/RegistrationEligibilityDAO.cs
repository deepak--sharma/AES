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
    public class RegistrationEligibilityDAO
    {
        List<SqlParameter> objParameterList = null;
        private string strDBTableName = "REGISTRATION_ELIGIBILITY";
        private string strGetRegistrationEligibilitySchema = "SP_GET_REGISTRATION_ELIGIBILITY_SCHEMA";
        private string strGetRegistrationEligibility = "SP_GET_REGISTRATION_ELIGIBILITY";
        private string strInsertRegistrationEligibility = "UDSP_INSERT_REGISTRATION_ELIGIBILITY";
        private string strUpdateRegistrationEligibility = "UDSP_UPDATE_REGISTRATION_ELIGIBILITY";
        private string strDeleteRegistrationEligibility = "DELETE FROM REGISTRATION_ELIGIBILITY WHERE REGISTRATION_ID=@REGISTRATION_ID";
        private string dbExecuteStatus = "";

        public RegistrationEligibility GetRegistrationEligibilitySchema(RegistrationEligibility objRegistrationEligibility)
        {
            objParameterList = new List<SqlParameter>();
            try
            {
                Logger.LogInfo("RegistrationEligibilityDAO.cs : GetRegistrationEligibilitySchema() is started.");
                objRegistrationEligibility.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList, strGetRegistrationEligibilitySchema, CommandType.StoredProcedure);
                objRegistrationEligibility.DbOperationStatus = CommonConstant.SUCCEED;
                Logger.LogInfo("RegistrationEligibilityDAO.cs : GetRegistrationEligibilitySchema() is ended with success.");
            }
            catch (Exception ex)
            {
                objRegistrationEligibility.DbOperationStatus = CommonConstant.FAIL;
                Logger.LogError(ex.Message);
                Logger.LogInfo("RegistrationEligibilityDAO.cs : GetRegistrationEligibilitySchema() is ended with error.");
            }
            return objRegistrationEligibility;
        }
        public RegistrationEligibility GetRegistrationEligibility(RegistrationEligibility objRegistrationEligibility)
        {
            objParameterList = new List<SqlParameter>();

            if (objRegistrationEligibility.RegistrationObject != null)
            {
                UDSP_SELECT_REGISTRATION_ELIGIBILITY.REGISTRATION_ID_PARAM(objParameterList, objRegistrationEligibility.RegistrationObject.RegistrationId);
            }
            NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@ELIGIBILITY_FACTOR_ID", objRegistrationEligibility.EligibilityObject.DataHolder);
            NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@RECORD_STATUS", objRegistrationEligibility.RecordStatus);

            try
            {
                Logger.LogInfo("RegistrationEligibilityDAO.cs : GetRegistrationEligibility() is started.");
                objRegistrationEligibility.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList, strGetRegistrationEligibility, CommandType.StoredProcedure);
                objRegistrationEligibility.DbOperationStatus = CommonConstant.SUCCEED;
                Logger.LogInfo("RegistrationEligibilityDAO.cs : GetRegistrationEligibility() is ended with success.");
            }
            catch (Exception ex)
            {
                objRegistrationEligibility.DbOperationStatus = CommonConstant.FAIL;
                Logger.LogError(ex.Message);
                Logger.LogInfo("RegistrationEligibilityDAO.cs : GetRegistrationEligibility() is ended with error.");
            }
            return objRegistrationEligibility;
        }
        public RegistrationEligibility SubmitRegistrationEligibilityData(RegistrationEligibility objRegistrationEligibility)
        {
            objParameterList = new List<SqlParameter>();
            
            if (objRegistrationEligibility.RegistrationObject != null)
            {
                UDSP_SELECT_REGISTRATION_ELIGIBILITY.REGISTRATION_ID_PARAM(objParameterList, objRegistrationEligibility.RegistrationObject.RegistrationId);
            }
            
            try
            {
                Logger.LogInfo("RegistrationEligibilityDAO.cs : SubmitRegistrationEligibilityData() is started.");
                DBMANAGER.ExecuteQuery(objParameterList, strDeleteRegistrationEligibility);
                dbExecuteStatus = DBMANAGER.ExecuteDataSet(new List<SqlParameter>(), objRegistrationEligibility.ObjectDataSet, strGetRegistrationEligibilitySchema, CommandType.StoredProcedure).ToString();
                objRegistrationEligibility.DbOperationStatus = CommonConstant.SUCCEED;
                Logger.LogInfo("RegistrationEligibilityDAO.cs : SubmitRegistrationEligibilityData() is ended with success.");
            }
            catch (Exception ex)
            {
                objRegistrationEligibility.DbOperationStatus = CommonConstant.FAIL;
                Logger.LogError(ex.Message);
                Logger.LogInfo("RegistrationEligibilityDAO.cs : SubmitRegistrationEligibilityData() is ended with error.");
            }
            return objRegistrationEligibility;
        }

    }
}
