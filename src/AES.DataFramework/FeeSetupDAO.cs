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
    public class FeeSetupDAO
    {
        List<SqlParameter> objParameterList = null;
        private string strDBTableName = "FEE_SETUP";
        private string strSelectFeeSetup = "SP_SELECT_FEE_SETUP";
        private string strSelectFeeSetupSchema = "SELECT * FROM FEE_SETUP WHERE 1 <> 1";
        private string strInsertFeeSetup = "UDSP_INSERT_FEE_SETUP";
        private string strUpdateFeeSetup = "UDSP_UPDATE_FEE_SETUP";
        private string strDeleteQuery = "DELETE FROM FEE_SETUP WHERE FEE_STRUCTURE_DETAIL_ID = @FEE_STRUCTURE_DETAIL_ID";
        private string dbExecuteStatus = "";

        public FeeSetup SelectFeeSetup(FeeSetup objFeeSetup)
        {
            objParameterList = new List<SqlParameter>();

            if (objFeeSetup.FeeStructureDetailObject != null)
            {
                UDSP_SELECT_FEE_SETUP.FEE_STRUCTURE_DETAIL_ID_PARAM(objParameterList, objFeeSetup.FeeStructureDetailObject.FeeStructureDetailId);
            }
            NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@RECORD_STATUS", objFeeSetup.RecordStatus);
            try
            {
                Logger.LogInfo("FeeSetupDAO.cs : SelectFeeSetup() is started.");
                objFeeSetup.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList, strSelectFeeSetup, CommandType.StoredProcedure);
                objFeeSetup.DbOperationStatus = CommonConstant.SUCCEED;
                Logger.LogInfo("FeeSetupDAO.cs : SelectFeeSetup() is ended with success.");
            }
            catch (Exception ex)
            {
                objFeeSetup.DbOperationStatus = CommonConstant.FAIL;
                Logger.LogError(ex.Message);
                Logger.LogInfo("FeeSetupDAO.cs : SelectFeeSetup() is ended with error.");
            }
            return objFeeSetup;
        }
        public FeeSetup SelectFeeSetupSchema(FeeSetup objFeeSetup)
        {
            try
            {
                Logger.LogInfo("FeeSetupDAO.cs : SelectFeeSetup() is started.");
                objFeeSetup.ObjectDataSet = DBMANAGER.GetDataSet(strSelectFeeSetupSchema, CommandType.Text);
                objFeeSetup.DbOperationStatus = CommonConstant.SUCCEED;
                Logger.LogInfo("FeeSetupDAO.cs : SelectFeeSetup() is ended with success.");
            }
            catch (Exception ex)
            {
                objFeeSetup.DbOperationStatus = CommonConstant.FAIL;
                Logger.LogError(ex.Message);
                Logger.LogInfo("FeeSetupDAO.cs : SelectFeeSetup() is ended with error.");
            }
            return objFeeSetup;
        }
        public FeeSetup SubmitFeeSetupData(FeeSetup objFeeSetup)
        {
            objParameterList = new List<SqlParameter>();

            if (objFeeSetup.FeeStructureDetailObject != null)
            {
                NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@FEE_STRUCTURE_DETAIL_ID", objFeeSetup.FeeStructureDetailObject.FeeStructureDetailId);
            }

            try
            {
                Logger.LogInfo("FeeSetupDAO.cs : SubmitFeeSetupData() is started.");
                DBMANAGER.ExecuteQuery(objParameterList, strDeleteQuery);
                DBMANAGER.ExecuteDataSet(objFeeSetup.ObjectDataSet, strSelectFeeSetupSchema, CommandType.Text).ToString();
                objFeeSetup.DbOperationStatus = CommonConstant.SUCCEED;
                Logger.LogInfo("FeeSetupDAO.cs : SubmitFeeSetupData() is ended with success.");
            }
            catch (Exception ex)
            {
                objFeeSetup.DbOperationStatus = CommonConstant.FAIL;
                Logger.LogError(ex.Message);
                Logger.LogInfo("FeeSetupDAO.cs : SubmitFeeSetupData() is ended with error.");
            }
            return objFeeSetup;
        }

    }
}
