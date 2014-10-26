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
    public class EmployeePreviousOrganisationDetailDAO
    {
        List<SqlParameter> objParameterList = null;
        private string strDBTableName = "EMPLOYEE_PREVIOUS_ORGANISATION_DETAIL";
        private string strSelectEmployeePreviousOrganisationDetail = "SP_SELECT_EMPLOYEE_PREVIOUS_ORGANISATION_DETAIL";
        private string strGetEmployeePreviousOrganisationDetail = "SP_GET_EMPLOYEE_PREVIOUS_ORGANISATION_DETAIL";
        private string strInsertEmployeePreviousOrganisationDetail = "UDSP_INSERT_EMPLOYEE_PREVIOUS_ORGANISATION_DETAIL";
        private string strUpdateEmployeePreviousOrganisationDetail = "UDSP_UPDATE_EMPLOYEE_PREVIOUS_ORGANISATION_DETAIL";
        private string dbExecuteStatus = "";

        public EmployeePreviousOrganisationDetail SelectEmployeePreviousOrganisationDetail(EmployeePreviousOrganisationDetail objEmployeePreviousOrganisationDetail)
        {
            objParameterList = new List<SqlParameter>();
            UDSP_SELECT_EMPLOYEE_PREVIOUS_ORGANISATION_DETAIL.EMPLOYEE_PREVIOUS_ORG_DETAIL_ID_PARAM(objParameterList, objEmployeePreviousOrganisationDetail.EmployeePreviousOrgDetailId);
            if (objEmployeePreviousOrganisationDetail.EmployeeObject != null)
            {
                UDSP_SELECT_EMPLOYEE_PREVIOUS_ORGANISATION_DETAIL.EMPLOYEE_ID_PARAM(objParameterList, objEmployeePreviousOrganisationDetail.EmployeeObject.EmployeeId);
            }
            UDSP_SELECT_EMPLOYEE_PREVIOUS_ORGANISATION_DETAIL.ORGANISATION_NAME_PARAM(objParameterList, objEmployeePreviousOrganisationDetail.OrganisationName);
            UDSP_SELECT_EMPLOYEE_PREVIOUS_ORGANISATION_DETAIL.PERIOD_FROM_PARAM(objParameterList, objEmployeePreviousOrganisationDetail.PeriodFrom);
            UDSP_SELECT_EMPLOYEE_PREVIOUS_ORGANISATION_DETAIL.PERIOD_TO_PARAM(objParameterList, objEmployeePreviousOrganisationDetail.PeriodTo);
            UDSP_SELECT_EMPLOYEE_PREVIOUS_ORGANISATION_DETAIL.CTC_PARAM(objParameterList, objEmployeePreviousOrganisationDetail.Ctc);
            if (objEmployeePreviousOrganisationDetail.CurrencyObject != null)
            {
                UDSP_SELECT_EMPLOYEE_PREVIOUS_ORGANISATION_DETAIL.CURRENCY_ID_PARAM(objParameterList, objEmployeePreviousOrganisationDetail.CurrencyObject.MetadataId);
            }
            UDSP_SELECT_EMPLOYEE_PREVIOUS_ORGANISATION_DETAIL.ENTRY_DESIGNATION_PARAM(objParameterList, objEmployeePreviousOrganisationDetail.EntryDesignation);
            UDSP_SELECT_EMPLOYEE_PREVIOUS_ORGANISATION_DETAIL.EXIT_DESIGNATION_PARAM(objParameterList, objEmployeePreviousOrganisationDetail.ExitDesignation);
            UDSP_SELECT_EMPLOYEE_PREVIOUS_ORGANISATION_DETAIL.SUPERVISOR_NAME_PARAM(objParameterList, objEmployeePreviousOrganisationDetail.SupervisorName);
            UDSP_SELECT_EMPLOYEE_PREVIOUS_ORGANISATION_DETAIL.SUPERVISOR_CONTACT_PARAM(objParameterList, objEmployeePreviousOrganisationDetail.SupervisorContact);
            UDSP_SELECT_EMPLOYEE_PREVIOUS_ORGANISATION_DETAIL.SUPERVISOR_DESIGNATION_PARAM(objParameterList, objEmployeePreviousOrganisationDetail.SupervisorDesignation);
            UDSP_SELECT_EMPLOYEE_PREVIOUS_ORGANISATION_DETAIL.DEPARTMENT_PARAM(objParameterList, objEmployeePreviousOrganisationDetail.Department);
            UDSP_SELECT_EMPLOYEE_PREVIOUS_ORGANISATION_DETAIL.NATURE_OF_WORK_PARAM(objParameterList, objEmployeePreviousOrganisationDetail.NatureOfWork);
            UDSP_SELECT_EMPLOYEE_PREVIOUS_ORGANISATION_DETAIL.ORGANISATION_ADDRESS_PARAM(objParameterList, objEmployeePreviousOrganisationDetail.OrganisationAddress);
            UDSP_SELECT_EMPLOYEE_PREVIOUS_ORGANISATION_DETAIL.WEB_ADDRESS_PARAM(objParameterList, objEmployeePreviousOrganisationDetail.WebAddress);
            UDSP_SELECT_EMPLOYEE_PREVIOUS_ORGANISATION_DETAIL.REASON_FOR_LEAVING_PARAM(objParameterList, objEmployeePreviousOrganisationDetail.ReasonForLeaving);
            UDSP_SELECT_EMPLOYEE_PREVIOUS_ORGANISATION_DETAIL.RECENT_ORDER_PARAM(objParameterList, objEmployeePreviousOrganisationDetail.RecentOrder);
            NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@CURRENCY_METADATA_ID", objEmployeePreviousOrganisationDetail.CurrencyObject.DataHolder);
            try
            {
                Logger.LogInfo("EmployeePreviousOrganisationDetailDAO.cs : SelectEmployeePreviousOrganisationDetail() is started.");
                objEmployeePreviousOrganisationDetail.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList, strSelectEmployeePreviousOrganisationDetail, CommandType.StoredProcedure);
                objEmployeePreviousOrganisationDetail.DbOperationStatus = CommonConstant.SUCCEED;
                Logger.LogInfo("EmployeePreviousOrganisationDetailDAO.cs : SelectEmployeePreviousOrganisationDetail() is ended with success.");
            }
            catch (Exception ex)
            {
                objEmployeePreviousOrganisationDetail.DbOperationStatus = CommonConstant.FAIL;
                Logger.LogError(ex.Message);
                Logger.LogInfo("EmployeePreviousOrganisationDetailDAO.cs : SelectEmployeePreviousOrganisationDetail() is ended with error.");
            }
            return objEmployeePreviousOrganisationDetail;
        }
        public EmployeePreviousOrganisationDetail SubmitEmployeePreviousOrganisationDetailData(EmployeePreviousOrganisationDetail objEmployeePreviousOrganisationDetail)
        {
            objParameterList = new List<SqlParameter>();
            UDSP_SELECT_EMPLOYEE_PREVIOUS_ORGANISATION_DETAIL.EMPLOYEE_PREVIOUS_ORG_DETAIL_ID_PARAM(objParameterList, objEmployeePreviousOrganisationDetail.EmployeePreviousOrgDetailId);
            if (objEmployeePreviousOrganisationDetail.EmployeeObject != null)
            {
                UDSP_SELECT_EMPLOYEE_PREVIOUS_ORGANISATION_DETAIL.EMPLOYEE_ID_PARAM(objParameterList, objEmployeePreviousOrganisationDetail.EmployeeObject.EmployeeId);
            }
            UDSP_SELECT_EMPLOYEE_PREVIOUS_ORGANISATION_DETAIL.ORGANISATION_NAME_PARAM(objParameterList, objEmployeePreviousOrganisationDetail.OrganisationName);
            UDSP_SELECT_EMPLOYEE_PREVIOUS_ORGANISATION_DETAIL.PERIOD_FROM_PARAM(objParameterList, objEmployeePreviousOrganisationDetail.PeriodFrom);
            UDSP_SELECT_EMPLOYEE_PREVIOUS_ORGANISATION_DETAIL.PERIOD_TO_PARAM(objParameterList, objEmployeePreviousOrganisationDetail.PeriodTo);
            UDSP_SELECT_EMPLOYEE_PREVIOUS_ORGANISATION_DETAIL.CTC_PARAM(objParameterList, objEmployeePreviousOrganisationDetail.Ctc);
            if (objEmployeePreviousOrganisationDetail.CurrencyObject != null)
            {
                UDSP_SELECT_EMPLOYEE_PREVIOUS_ORGANISATION_DETAIL.CURRENCY_ID_PARAM(objParameterList, objEmployeePreviousOrganisationDetail.CurrencyObject.MetadataId);
            }
            UDSP_SELECT_EMPLOYEE_PREVIOUS_ORGANISATION_DETAIL.ENTRY_DESIGNATION_PARAM(objParameterList, objEmployeePreviousOrganisationDetail.EntryDesignation);
            UDSP_SELECT_EMPLOYEE_PREVIOUS_ORGANISATION_DETAIL.EXIT_DESIGNATION_PARAM(objParameterList, objEmployeePreviousOrganisationDetail.ExitDesignation);
            UDSP_SELECT_EMPLOYEE_PREVIOUS_ORGANISATION_DETAIL.SUPERVISOR_NAME_PARAM(objParameterList, objEmployeePreviousOrganisationDetail.SupervisorName);
            UDSP_SELECT_EMPLOYEE_PREVIOUS_ORGANISATION_DETAIL.SUPERVISOR_CONTACT_PARAM(objParameterList, objEmployeePreviousOrganisationDetail.SupervisorContact);
            UDSP_SELECT_EMPLOYEE_PREVIOUS_ORGANISATION_DETAIL.SUPERVISOR_DESIGNATION_PARAM(objParameterList, objEmployeePreviousOrganisationDetail.SupervisorDesignation);
            UDSP_SELECT_EMPLOYEE_PREVIOUS_ORGANISATION_DETAIL.DEPARTMENT_PARAM(objParameterList, objEmployeePreviousOrganisationDetail.Department);
            UDSP_SELECT_EMPLOYEE_PREVIOUS_ORGANISATION_DETAIL.NATURE_OF_WORK_PARAM(objParameterList, objEmployeePreviousOrganisationDetail.NatureOfWork);          
            UDSP_SELECT_EMPLOYEE_PREVIOUS_ORGANISATION_DETAIL.ORGANISATION_ADDRESS_PARAM(objParameterList, objEmployeePreviousOrganisationDetail.OrganisationAddress);            
            UDSP_SELECT_EMPLOYEE_PREVIOUS_ORGANISATION_DETAIL.WEB_ADDRESS_PARAM(objParameterList, objEmployeePreviousOrganisationDetail.WebAddress);
            UDSP_SELECT_EMPLOYEE_PREVIOUS_ORGANISATION_DETAIL.REASON_FOR_LEAVING_PARAM(objParameterList, objEmployeePreviousOrganisationDetail.ReasonForLeaving);
            UDSP_SELECT_EMPLOYEE_PREVIOUS_ORGANISATION_DETAIL.RECENT_ORDER_PARAM(objParameterList, objEmployeePreviousOrganisationDetail.RecentOrder);
            try
            {
                Logger.LogInfo("EmployeePreviousOrganisationDetailDAO.cs : SubmitEmployeePreviousOrganisationDetailData() is started.");
                dbExecuteStatus = DBMANAGER.ExecuteDataSet(objParameterList, objEmployeePreviousOrganisationDetail.ObjectDataSet, strGetEmployeePreviousOrganisationDetail, CommandType.StoredProcedure).ToString();
                objEmployeePreviousOrganisationDetail.DbOperationStatus = CommonConstant.SUCCEED;
                Logger.LogInfo("EmployeePreviousOrganisationDetailDAO.cs : SubmitEmployeePreviousOrganisationDetailData() is ended with success.");
            }
            catch (Exception ex)
            {
                objEmployeePreviousOrganisationDetail.DbOperationStatus = CommonConstant.FAIL;
                Logger.LogError(ex.Message);
                Logger.LogInfo("EmployeePreviousOrganisationDetailDAO.cs : SubmitEmployeePreviousOrganisationDetailData() is ended with error.");
            }
            return objEmployeePreviousOrganisationDetail;
        }

    }
}
