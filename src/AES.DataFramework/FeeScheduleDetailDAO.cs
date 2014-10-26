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
    public class FeeScheduleDetailDAO
    {
        List<SqlParameter> objParameterList = null;
        private string strDBTableName = "FEE_SCHEDULE_DETAIL";
        private string strSelectFeeScheduleDetail = "SP_SELECT_FEE_SCHEDULE_DETAIL";
        private string strSelectFeeScheduleDetailData = "UDSP_SELECT_FEE_SCHEDULE_DETAIL";
        private string strDeleteFeeScheduleDetailData = "DELETE FROM FEE_SCHEDULE_DETAIL WHERE FEE_SCHEDULE_ID=@FEE_SCHEDULE_ID";
        private string strInsertFeeScheduleDetail = "UDSP_INSERT_FEE_SCHEDULE_DETAIL";
        private string strUpdateFeeScheduleDetail = "UDSP_UPDATE_FEE_SCHEDULE_DETAIL";
        private string dbExecuteStatus = "";

        public FeeScheduleDetail SelectFeeScheduleDetail(FeeScheduleDetail objFeeScheduleDetail)
        {
            objParameterList = new List<SqlParameter>();
            if (objFeeScheduleDetail.FeeScheduleObject != null)
            {
                UDSP_SELECT_FEE_SCHEDULE_DETAIL.FEE_SCHEDULE_ID_PARAM(objParameterList, objFeeScheduleDetail.FeeScheduleObject.FeeScheduleId);
                NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@NO_OF_INSTANCES", objFeeScheduleDetail.FeeScheduleObject.NoOfInstances);
                NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@IS_POST_PAYMENT", objFeeScheduleDetail.FeeScheduleObject.DataHolder);
            }

            try
            {
                Logger.LogInfo("FeeScheduleDetailDAO.cs : SelectFeeScheduleDetail() is started.");
                objFeeScheduleDetail.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList, strSelectFeeScheduleDetail, CommandType.StoredProcedure);
                objFeeScheduleDetail.DbOperationStatus = CommonConstant.SUCCEED;
                Logger.LogInfo("FeeScheduleDetailDAO.cs : SelectFeeScheduleDetail() is ended with success.");
            }
            catch (Exception ex)
            {
                objFeeScheduleDetail.DbOperationStatus = CommonConstant.FAIL;
                Logger.LogError(ex.Message);
                Logger.LogInfo("FeeScheduleDetailDAO.cs : SelectFeeScheduleDetail() is ended with error.");
            }
            return objFeeScheduleDetail;
        }

        public FeeScheduleDetail SelectFeeScheduleDetailData(FeeScheduleDetail objFeeScheduleDetail)
        {
            objParameterList = new List<SqlParameter>();
            if (objFeeScheduleDetail.FeeScheduleObject != null)
            {
                UDSP_SELECT_FEE_SCHEDULE_DETAIL.FEE_SCHEDULE_ID_PARAM(objParameterList, objFeeScheduleDetail.FeeScheduleObject.FeeScheduleId);
            }
            try
            {
                Logger.LogInfo("FeeScheduleDetailDAO.cs : SelectFeeScheduleDetailData() is started.");
                objFeeScheduleDetail.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList, strSelectFeeScheduleDetailData, CommandType.StoredProcedure);
                objFeeScheduleDetail.DbOperationStatus = CommonConstant.SUCCEED;
                Logger.LogInfo("FeeScheduleDetailDAO.cs : SelectFeeScheduleDetailData() is ended with success.");
            }
            catch (Exception ex)
            {
                objFeeScheduleDetail.DbOperationStatus = CommonConstant.FAIL;
                Logger.LogError(ex.Message);
                Logger.LogInfo("FeeScheduleDetailDAO.cs : SelectFeeScheduleDetailData() is ended with error.");
            }
            return objFeeScheduleDetail;
        }

        public FeeScheduleDetail SubmitFeeScheduleDetailData(FeeScheduleDetail objFeeScheduleDetail)
        {
            objParameterList = new List<SqlParameter>();
            List<SqlParameter> deleteParamList = new List<SqlParameter>();
            if (objFeeScheduleDetail.FeeScheduleObject != null)
            {
                UDSP_SELECT_FEE_SCHEDULE_DETAIL.FEE_SCHEDULE_ID_PARAM(objParameterList, objFeeScheduleDetail.FeeScheduleObject.FeeScheduleId);
                NEWPARAMETERS.ADDPARAMETERS(deleteParamList, "@FEE_SCHEDULE_ID", objFeeScheduleDetail.FeeScheduleObject.FeeScheduleId);
            }
            else
            {
                UDSP_SELECT_FEE_SCHEDULE_DETAIL.FEE_SCHEDULE_ID_PARAM(objParameterList, null);
                NEWPARAMETERS.ADDPARAMETERS(deleteParamList, "@FEE_SCHEDULE_ID", null);
            }
            try
            {
                Logger.LogInfo("FeeScheduleDetailDAO.cs : SubmitFeeScheduleDetailData() is started.");
                DBMANAGER.ExecuteQuery(deleteParamList, strDeleteFeeScheduleDetailData);
                dbExecuteStatus = DBMANAGER.ExecuteDataSet(objParameterList, objFeeScheduleDetail.ObjectDataSet, strSelectFeeScheduleDetailData, CommandType.StoredProcedure).ToString();
                objFeeScheduleDetail.DbOperationStatus = CommonConstant.SUCCEED;
                Logger.LogInfo("FeeScheduleDetailDAO.cs : SubmitFeeScheduleDetailData() is ended with success.");
            }
            catch (Exception ex)
            {
                objFeeScheduleDetail.DbOperationStatus = CommonConstant.FAIL;
                Logger.LogError(ex.Message);
                Logger.LogInfo("FeeScheduleDetailDAO.cs : SubmitFeeScheduleDetailData() is ended with error.");
            }
            return objFeeScheduleDetail;
        }

    }
}
