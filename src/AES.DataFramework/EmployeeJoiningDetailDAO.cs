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
    public class EmployeeJoiningDetailDAO
    {
        List<SqlParameter> objParameterList = null;
        private string strDBTableName = "EMPLOYEE_JOINING_DETAIL";
        private string strSelectEmployeeJoiningDetail = "SP_SELECT_EMPLOYEE_JOINING_DETAIL";
        private string strInsertEmployeeJoiningDetail = "SP_INSERT_EMPLOYEE_JOINING_DETAIL";
        private string strUpdateEmployeeJoiningDetail = "UDSP_UPDATE_EMPLOYEE_JOINING_DETAIL";
        private string dbExecuteStatus = "";

        public EmployeeJoiningDetail SelectEmployeeJoiningDetail(EmployeeJoiningDetail objEmployeeJoiningDetail)
        {
            objParameterList = new List<SqlParameter>();
            UDSP_SELECT_EMPLOYEE_JOINING_DETAIL.EMPLOYEE_ID_PARAM(objParameterList, objEmployeeJoiningDetail.EmployeeObject.EmployeeId);
            try
            {
                Logger.LogInfo("EmployeeJoiningDetailDAO.cs : SelectEmployeeJoiningDetail() is started.");
                objEmployeeJoiningDetail.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList, strSelectEmployeeJoiningDetail, CommandType.StoredProcedure);
                objEmployeeJoiningDetail.DbOperationStatus = CommonConstant.SUCCEED;
                Logger.LogInfo("EmployeeJoiningDetailDAO.cs : SelectEmployeeJoiningDetail() is ended with success.");
            }
            catch (Exception ex)
            {
                objEmployeeJoiningDetail.DbOperationStatus = CommonConstant.FAIL;
                Logger.LogError(ex.Message);
                Logger.LogInfo("EmployeeJoiningDetailDAO.cs : SelectEmployeeJoiningDetail() is ended with error.");
            }
            return objEmployeeJoiningDetail;
        }
        public EmployeeJoiningDetail SubmitEmployeeJoiningDetailData(EmployeeJoiningDetail objEmployeeJoiningDetail)
        {
            objParameterList = new List<SqlParameter>();

            UDSP_INSERT_EMPLOYEE_JOINING_DETAIL.EMPLOYEE_ID_PARAM(objParameterList, objEmployeeJoiningDetail.EmployeeObject.EmployeeId);
            UDSP_INSERT_EMPLOYEE_JOINING_DETAIL.JOINING_ID_PARAM(objParameterList, objEmployeeJoiningDetail.JoiningObject.JoiningId);
            UDSP_INSERT_EMPLOYEE_JOINING_DETAIL.DESCRIPTION_PARAM(objParameterList, objEmployeeJoiningDetail.Description);
            try
            {
                Logger.LogInfo("EmployeeJoiningDetailDAO.cs : SubmitEmployeeJoiningDetailData() is started.");
                dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList, strInsertEmployeeJoiningDetail, CommandType.StoredProcedure).ToString();
                if (GeneralUtility.IsInteger(dbExecuteStatus))
                {
                    if (Convert.ToInt32(dbExecuteStatus) > 0)
                    {
                        objEmployeeJoiningDetail.DbOperationStatus = CommonConstant.SUCCEED;
                    }
                    else
                    {
                        objEmployeeJoiningDetail.DbOperationStatus = CommonConstant.DUPLICATE;
                    }
                    Logger.LogInfo("EmployeeJoiningDetailDAO.cs : SubmitEmployeeJoiningDetailData() is ended with success.");
                }
                else
                {
                    objEmployeeJoiningDetail.DbOperationStatus = CommonConstant.FAIL;
                    Logger.LogInfo(dbExecuteStatus);
                    Logger.LogInfo("EmployeeJoiningDetailDAO.cs : SubmitEmployeeJoiningDetailData() is ended with error.");
                }
            }
            catch (Exception ex)
            {
                objEmployeeJoiningDetail.DbOperationStatus = CommonConstant.FAIL;
                Logger.LogError(ex.Message);
                Logger.LogInfo("EmployeeJoiningDetailDAO.cs : SubmitEmployeeJoiningDetailData() is ended with error.");
            }
            return objEmployeeJoiningDetail;
        }

    }
}
