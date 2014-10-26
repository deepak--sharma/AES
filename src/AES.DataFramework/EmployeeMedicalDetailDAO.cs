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
    public class EmployeeMedicalDetailDAO
    {
        List<SqlParameter> objParameterList = null;
        private string strDBTableName = "EMPLOYEE_MEDICAL_DETAIL";
        private string strSelectEmployeeMedicalDetail = "SP_SELECT_EMPLOYEE_MEDICAL_DETAIL";
        private string strInsertEmployeeMedicalDetail = "SP_INSERT_EMPLOYEE_MEDICAL_DETAIL";
        private string strUpdateEmployeeMedicalDetail = "UDSP_UPDATE_EMPLOYEE_MEDICAL_DETAIL";
        private string dbExecuteStatus = "";

        public EmployeeMedicalDetail SelectEmployeeMedicalDetail(EmployeeMedicalDetail objEmployeeMedicalDetail)
        {
            objParameterList = new List<SqlParameter>();
            UDSP_SELECT_EMPLOYEE_MEDICAL_DETAIL.EMPLOYEE_ID_PARAM(objParameterList, objEmployeeMedicalDetail.EmployeeObject.EmployeeId);
            try
            {
                Logger.LogInfo("EmployeeMedicalDetailDAO.cs : SelectEmployeeMedicalDetail() is started.");
                objEmployeeMedicalDetail.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList, strSelectEmployeeMedicalDetail, CommandType.StoredProcedure);
                objEmployeeMedicalDetail.DbOperationStatus = CommonConstant.SUCCEED;
                Logger.LogInfo("EmployeeMedicalDetailDAO.cs : SelectEmployeeMedicalDetail() is ended with success.");
            }
            catch (Exception ex)
            {
                objEmployeeMedicalDetail.DbOperationStatus = CommonConstant.FAIL;
                Logger.LogError(ex.Message);
                Logger.LogInfo("EmployeeMedicalDetailDAO.cs : SelectEmployeeMedicalDetail() is ended with error.");
            }
            return objEmployeeMedicalDetail;
        }
        public EmployeeMedicalDetail SubmitEmployeeMedicalDetailData(EmployeeMedicalDetail objEmployeeMedicalDetail)
        {
            objParameterList = new List<SqlParameter>();
            UDSP_INSERT_EMPLOYEE_MEDICAL_DETAIL.EMPLOYEE_ID_PARAM(objParameterList, objEmployeeMedicalDetail.EmployeeObject.EmployeeId);
            UDSP_INSERT_EMPLOYEE_MEDICAL_DETAIL.MEDICAL_ID_PARAM(objParameterList, objEmployeeMedicalDetail.MedicalObject.MedicalId);
            UDSP_INSERT_EMPLOYEE_MEDICAL_DETAIL.DESCRIPTION_PARAM(objParameterList, objEmployeeMedicalDetail.Description);
            try
            {
                Logger.LogInfo("EmployeeMedicalDetailDAO.cs : SubmitEmployeeMedicalDetailData() is started.");
                dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList, strInsertEmployeeMedicalDetail, CommandType.StoredProcedure).ToString();
                if (GeneralUtility.IsInteger(dbExecuteStatus))
                {
                    if (Convert.ToInt32(dbExecuteStatus) > 0)
                    {
                        objEmployeeMedicalDetail.DbOperationStatus = CommonConstant.SUCCEED;
                    }
                    else
                    {
                        objEmployeeMedicalDetail.DbOperationStatus = CommonConstant.DUPLICATE;
                    }
                    Logger.LogInfo("EmployeeMedicalDetailDAO.cs : SubmitEmployeeMedicalDetailData() is ended with success.");
                }
                else
                {
                    objEmployeeMedicalDetail.DbOperationStatus = CommonConstant.FAIL;
                    Logger.LogInfo(dbExecuteStatus);
                    Logger.LogInfo("EmployeeMedicalDetailDAO.cs : SubmitEmployeeMedicalDetailData() is ended with error.");
                }
            }
            catch (Exception ex)
            {
                objEmployeeMedicalDetail.DbOperationStatus = CommonConstant.FAIL;
                Logger.LogError(ex.Message);
                Logger.LogInfo("EmployeeMedicalDetailDAO.cs : SubmitEmployeeMedicalDetailData() is ended with error.");
            }
            return objEmployeeMedicalDetail;
        }

    }
}
