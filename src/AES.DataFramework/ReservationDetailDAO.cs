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
    public class ReservationDetailDAO
    {
        List<SqlParameter> objParameterList = null;
        private string strDBTableName = "RESERVATION_DETAIL";
        private string strSelectReservationDetail = "SP_SELECT_RESERVATION_DETAIL";
        private string strGetReservationDetail = "SP_GET_RESERVATION_DETAIL";
        private string strGetReservationDetailSchema = "SP_GET_RESERVATION_DETAIL_SCHEMA";
        private string strDeleteReservationDetail = "DELETE FROM RESERVATION_DETAIL WHERE REGISTRATION_ID=@REGISTRATION_ID";

        private string dbExecuteStatus = "";

        public ReservationDetail GetReservationDetail(ReservationDetail objReservationDetail)
        {
            objParameterList = new List<SqlParameter>();

            NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@RESERVATION_CRITERIA_IDS", objReservationDetail.DataHolder);
            if (objReservationDetail.RegistrationObject != null)
            {
                UDSP_SELECT_RESERVATION_DETAIL.REGISTRATION_ID_PARAM(objParameterList, objReservationDetail.RegistrationObject.RegistrationId);
            }            
            NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@FREE_SEAT_ID", objReservationDetail.FreeSeatId);
            NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@MANAGEMENT_SEAT_ID", objReservationDetail.ManagementSeatId);
            NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@RECORD_STATUS", objReservationDetail.RecordStatus);
            
            try
            {
                Logger.LogInfo("ReservationDetailDAO.cs : GetReservationDetail() is started.");
                objReservationDetail.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList, strGetReservationDetail, CommandType.StoredProcedure);
                objReservationDetail.DbOperationStatus = CommonConstant.SUCCEED;
                Logger.LogInfo("ReservationDetailDAO.cs : GetReservationDetail() is ended with success.");
            }
            catch (Exception ex)
            {
                objReservationDetail.DbOperationStatus = CommonConstant.FAIL;
                Logger.LogError(ex.Message);
                Logger.LogInfo("ReservationDetailDAO.cs : GetReservationDetail() is ended with error.");
            }
            return objReservationDetail;
        }

        public ReservationDetail GetReservationDetailSchema(ReservationDetail objReservationDetail)
        {            
            try
            {                
                Logger.LogInfo("ReservationDetailDAO.cs : GetReservationDetailSchema() is started.");
                objReservationDetail.ObjectDataSet = DBMANAGER.GetDataSet(strGetReservationDetailSchema, CommandType.StoredProcedure);
                objReservationDetail.DbOperationStatus = CommonConstant.SUCCEED;
                Logger.LogInfo("ReservationDetailDAO.cs : GetReservationDetailSchema() is ended with success.");
            }
            catch (Exception ex)
            {
                objReservationDetail.DbOperationStatus = CommonConstant.FAIL;
                Logger.LogError(ex.Message);
                Logger.LogInfo("ReservationDetailDAO.cs : GetReservationDetailSchema() is ended with error.");
            }
            return objReservationDetail;
        }

        public ReservationDetail SubmitReservationDetailData(ReservationDetail objReservationDetail)
        {
            objParameterList = new List<SqlParameter>();
            if (objReservationDetail.RegistrationObject != null)
            {
                NEWPARAMETERS.ADDPARAMETERS(objParameterList,"@REGISTRATION_ID",objReservationDetail.RegistrationObject.RegistrationId);
            }
            try
            {
                Logger.LogInfo("ReservationDetailDAO.cs : SubmitReservationDetailData() is started.");
                DBMANAGER.ExecuteQuery(objParameterList, strDeleteReservationDetail);
                dbExecuteStatus = DBMANAGER.ExecuteDataSet(new List<SqlParameter>(), objReservationDetail.ObjectDataSet, strGetReservationDetailSchema, CommandType.StoredProcedure).ToString();
                objReservationDetail.DbOperationStatus = CommonConstant.SUCCEED;
                Logger.LogInfo("ReservationDetailDAO.cs : SubmitReservationDetailData() is ended with success.");
            }
            catch (Exception ex)
            {
                objReservationDetail.DbOperationStatus = CommonConstant.FAIL;
                Logger.LogError(ex.Message);
                Logger.LogInfo("ReservationDetailDAO.cs : SubmitReservationDetailData() is ended with error.");
            }
            return objReservationDetail;
        }

    }
}
