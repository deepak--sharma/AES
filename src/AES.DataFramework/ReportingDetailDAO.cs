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
    public class ReportingDetailDAO
    {
        List<SqlParameter> objParameterList = null;
        private string strDBTableName = "REPORTING_DETAIL";
        private string strSelectReportingDetail = "SP_SELECT_REPORTING_DETAIL";
        private string strInsertReportingDetail = "SP_INSERT_REPORTING_DETAIL";
        private string strUpdateReportingDetail = "UDSP_UPDATE_REPORTING_DETAIL";
        private string dbExecuteStatus = "";

        public ReportingDetail SelectReportingDetail(ReportingDetail objReportingDetail)
        {
            objParameterList = new List<SqlParameter>();
            UDSP_SELECT_REPORTING_DETAIL.EMPLOYEE_ID_PARAM(objParameterList, objReportingDetail.EmployeeObject.EmployeeId);
            try
            {
                Logger.LogInfo("ReportingDetailDAO.cs : SelectReportingDetail() is started.");
                objReportingDetail.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList, strSelectReportingDetail, CommandType.StoredProcedure);
                objReportingDetail.DbOperationStatus = CommonConstant.SUCCEED;
                Logger.LogInfo("ReportingDetailDAO.cs : SelectReportingDetail() is ended with success.");
            }
            catch (Exception ex)
            {
                objReportingDetail.DbOperationStatus = CommonConstant.FAIL;
                Logger.LogError(ex.Message);
                Logger.LogInfo("ReportingDetailDAO.cs : SelectReportingDetail() is ended with error.");
            }
            return objReportingDetail;
        }
        public ReportingDetail SubmitReportingDetailData(ReportingDetail objReportingDetail)
        {
            objParameterList = new List<SqlParameter>();
            if (objReportingDetail.EmployeeObject != null)
            {
                UDSP_INSERT_REPORTING_DETAIL.EMPLOYEE_ID_PARAM(objParameterList, objReportingDetail.EmployeeObject.EmployeeId);
            }
            if (objReportingDetail.SupervisorObject != null)
            {
                UDSP_INSERT_REPORTING_DETAIL.SUPERVISOR_ID_PARAM(objParameterList, objReportingDetail.SupervisorObject.EmployeeId);
            }
            UDSP_INSERT_REPORTING_DETAIL.OTHER_DETAIL_PARAM(objParameterList, objReportingDetail.OtherDetail);
            UDSP_INSERT_REPORTING_DETAIL.IS_PRIMARY_PARAM(objParameterList, objReportingDetail.IsPrimary);
            try
            {
                Logger.LogInfo("ReportingDetailDAO.cs : SubmitReportingDetailData() is started.");
                dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList, strInsertReportingDetail, CommandType.StoredProcedure).ToString();
                if (GeneralUtility.IsInteger(dbExecuteStatus))
                {
                    if (Convert.ToInt32(dbExecuteStatus) > 0)
                    {
                        objReportingDetail.DbOperationStatus = CommonConstant.SUCCEED;
                    }
                    else
                    {
                        objReportingDetail.DbOperationStatus = CommonConstant.DUPLICATE;
                    }
                    Logger.LogInfo("ReportingDetailDAO.cs : SubmitReportingDetailData() is ended with success.");
                }
                else
                {
                    objReportingDetail.DbOperationStatus = CommonConstant.FAIL;
                    Logger.LogInfo(dbExecuteStatus);
                    Logger.LogInfo("ReportingDetailDAO.cs : SubmitReportingDetailData() is ended with error.");
                }
            }
            catch (Exception ex)
            {
                objReportingDetail.DbOperationStatus = CommonConstant.FAIL;
                Logger.LogError(ex.Message);
                Logger.LogInfo("ReportingDetailDAO.cs : SubmitReportingDetailData() is ended with error.");
            }
            return objReportingDetail;
        }

    }
}
