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
    public class AddressDetailDAO
    {
        List<SqlParameter> objParameterList = null;
        private string strDBTableName = "ADDRESS_DETAIL";
        private string strSelectAddressDetail = "UDSP_SELECT_ADDRESS_DETAIL";
        private string strInsertAddressDetail = "UDSP_INSERT_ADDRESS_DETAIL";
        private string strUpdateAddressDetail = "UDSP_UPDATE_ADDRESS_DETAIL";
        private string strGetDefaultCountryStateCity = "UDSP_GET_DEFAULT_COUNTRY_STATE_CITY";
        private string strInsertEmployeeAddress = "SP_INSERT_EMPLOYEE_ADDRESS_DETAIL";
        private string strUpdateEmployeeAddress = "SP_UPDATE_EMPLOYEE_ADDRESS_DETAIL";
        private string dbExecuteStatus = "";

        public AddressDetail SelectAddressDetail(AddressDetail objAddressDetail)
        {
            objParameterList = new List<SqlParameter>();
            UDSP_SELECT_ADDRESS_DETAIL.ADDRESS_ID_PARAM(objParameterList, objAddressDetail.AddressId);
            UDSP_SELECT_ADDRESS_DETAIL.ADDRESS_LINE1_PARAM(objParameterList, objAddressDetail.AddressLine1);
            UDSP_SELECT_ADDRESS_DETAIL.ADDRESS_LINE2_PARAM(objParameterList, objAddressDetail.AddressLine2);
            if (objAddressDetail.CityObject != null)
            {
                UDSP_SELECT_ADDRESS_DETAIL.CITY_ID_PARAM(objParameterList, objAddressDetail.CityObject.CityId);
            }
            if (objAddressDetail.StateObject != null)
            {
                UDSP_SELECT_ADDRESS_DETAIL.STATE_ID_PARAM(objParameterList, objAddressDetail.StateObject.StateId);
            }
            if (objAddressDetail.CountryObject != null)
            {
                UDSP_SELECT_ADDRESS_DETAIL.COUNTRY_ID_PARAM(objParameterList, objAddressDetail.CountryObject.CountryId);
            }
            UDSP_SELECT_ADDRESS_DETAIL.DISTRICT_PARAM(objParameterList, objAddressDetail.District);
            UDSP_SELECT_ADDRESS_DETAIL.PIN_CODE_PARAM(objParameterList, objAddressDetail.PinCode);
            UDSP_SELECT_ADDRESS_DETAIL.LANDMARK_PARAM(objParameterList, objAddressDetail.Landmark);
            UDSP_SELECT_ADDRESS_DETAIL.LANDLINE_NO_PARAM(objParameterList, objAddressDetail.LandlineNo);
            UDSP_SELECT_ADDRESS_DETAIL.MOBILE_NO_PARAM(objParameterList, objAddressDetail.MobileNo);
            UDSP_SELECT_ADDRESS_DETAIL.EMAIL_ID_PARAM(objParameterList, objAddressDetail.EmailId);
            try
            {
                Logger.LogInfo("AddressDetailDAO.cs : SelectAddressDetail() is started.");
                objAddressDetail.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList, strSelectAddressDetail, CommandType.StoredProcedure);
                objAddressDetail.DbOperationStatus = CommonConstant.SUCCEED;
                Logger.LogInfo("AddressDetailDAO.cs : SelectAddressDetail() is ended with success.");
            }
            catch (Exception ex)
            {
                objAddressDetail.DbOperationStatus = CommonConstant.FAIL;
                Logger.LogError(ex.Message);
                Logger.LogInfo("AddressDetailDAO.cs : SelectAddressDetail() is ended with error.");
            }
            return objAddressDetail;
        }

        public AddressDetail InsertAddressDetail(AddressDetail objAddressDetail)
        {
            objParameterList = new List<SqlParameter>();

            UDSP_INSERT_ADDRESS_DETAIL.ADDRESS_LINE1_PARAM(objParameterList, objAddressDetail.AddressLine1);
            UDSP_INSERT_ADDRESS_DETAIL.ADDRESS_LINE2_PARAM(objParameterList, objAddressDetail.AddressLine2);
            if (objAddressDetail.CityObject != null)
            {
                UDSP_INSERT_ADDRESS_DETAIL.CITY_ID_PARAM(objParameterList, objAddressDetail.CityObject.CityId);
            }
            if (objAddressDetail.StateObject != null)
            {
                UDSP_INSERT_ADDRESS_DETAIL.STATE_ID_PARAM(objParameterList, objAddressDetail.StateObject.StateId);
            }
            if (objAddressDetail.CountryObject != null)
            {
                UDSP_INSERT_ADDRESS_DETAIL.COUNTRY_ID_PARAM(objParameterList, objAddressDetail.CountryObject.CountryId);
            }
            UDSP_INSERT_ADDRESS_DETAIL.DISTRICT_PARAM(objParameterList, objAddressDetail.District);
            UDSP_INSERT_ADDRESS_DETAIL.PIN_CODE_PARAM(objParameterList, objAddressDetail.PinCode);
            UDSP_INSERT_ADDRESS_DETAIL.LANDMARK_PARAM(objParameterList, objAddressDetail.Landmark);
            UDSP_INSERT_ADDRESS_DETAIL.LANDLINE_NO_PARAM(objParameterList, objAddressDetail.LandlineNo);
            UDSP_INSERT_ADDRESS_DETAIL.MOBILE_NO_PARAM(objParameterList, objAddressDetail.MobileNo);
            UDSP_INSERT_ADDRESS_DETAIL.EMAIL_ID_PARAM(objParameterList, objAddressDetail.EmailId);
            try
            {
                Logger.LogInfo("AddressDetailDAO.cs : InsertAddressDetail() is started.");
                dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList, strInsertAddressDetail, CommandType.StoredProcedure).ToString();
                if (GeneralUtility.IsInteger(dbExecuteStatus))
                {
                    if (Convert.ToInt32(dbExecuteStatus) > 0)
                    {
                        objAddressDetail.AddressId = Convert.ToInt32(dbExecuteStatus);
                        objAddressDetail.DbOperationStatus = CommonConstant.SUCCEED;
                    }
                    else
                    {
                        objAddressDetail.DbOperationStatus = CommonConstant.DUPLICATE;
                    }
                    Logger.LogInfo("AddressDetailDAO.cs : InsertAddressDetail() is ended with success.");
                }
                else
                {
                    objAddressDetail.DbOperationStatus = CommonConstant.FAIL;
                    Logger.LogInfo(dbExecuteStatus);
                    Logger.LogInfo("AddressDetailDAO.cs : InsertAddressDetail() is ended with error.");
                }
            }
            catch (Exception ex)
            {
                objAddressDetail.DbOperationStatus = CommonConstant.FAIL;
                Logger.LogError(ex.Message);
                Logger.LogInfo("AddressDetailDAO.cs : InsertAddressDetail() is ended with error.");
            }
            return objAddressDetail;
        }

        public AddressDetail UpdateAddressDetail(AddressDetail objAddressDetail)
        {
            objParameterList = new List<SqlParameter>();

            UDSP_UPDATE_ADDRESS_DETAIL.ADDRESS_ID_PARAM(objParameterList, objAddressDetail.AddressId);
            UDSP_UPDATE_ADDRESS_DETAIL.ADDRESS_LINE1_PARAM(objParameterList, objAddressDetail.AddressLine1);
            UDSP_UPDATE_ADDRESS_DETAIL.ADDRESS_LINE2_PARAM(objParameterList, objAddressDetail.AddressLine2);
            if (objAddressDetail.CityObject != null)
            {
                UDSP_UPDATE_ADDRESS_DETAIL.CITY_ID_PARAM(objParameterList, objAddressDetail.CityObject.CityId);
            }
            if (objAddressDetail.StateObject != null)
            {
                UDSP_UPDATE_ADDRESS_DETAIL.STATE_ID_PARAM(objParameterList, objAddressDetail.StateObject.StateId);
            }
            if (objAddressDetail.CountryObject != null)
            {
                UDSP_UPDATE_ADDRESS_DETAIL.COUNTRY_ID_PARAM(objParameterList, objAddressDetail.CountryObject.CountryId);
            }
            UDSP_UPDATE_ADDRESS_DETAIL.DISTRICT_PARAM(objParameterList, objAddressDetail.District);
            UDSP_UPDATE_ADDRESS_DETAIL.PIN_CODE_PARAM(objParameterList, objAddressDetail.PinCode);
            UDSP_UPDATE_ADDRESS_DETAIL.LANDMARK_PARAM(objParameterList, objAddressDetail.Landmark);
            UDSP_UPDATE_ADDRESS_DETAIL.LANDLINE_NO_PARAM(objParameterList, objAddressDetail.LandlineNo);
            UDSP_UPDATE_ADDRESS_DETAIL.MOBILE_NO_PARAM(objParameterList, objAddressDetail.MobileNo);
            UDSP_UPDATE_ADDRESS_DETAIL.EMAIL_ID_PARAM(objParameterList, objAddressDetail.EmailId);
            try
            {
                Logger.LogInfo("AddressDetailDAO.cs : UpdateAddressDetail() is started.");
                dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList, strUpdateAddressDetail, CommandType.StoredProcedure).ToString();
                if (GeneralUtility.IsInteger(dbExecuteStatus))
                {
                    if (Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
                    {
                        objAddressDetail.DbOperationStatus = CommonConstant.SUCCEED;
                    }
                    else if (Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
                    {
                        objAddressDetail.DbOperationStatus = CommonConstant.INVALID;
                    }
                    else
                    {
                        objAddressDetail.DbOperationStatus = CommonConstant.DUPLICATE;
                    }
                    Logger.LogInfo("AddressDetailDAO.cs : UpdateAddressDetail() is ended with success.");
                }
                else
                {
                    objAddressDetail.DbOperationStatus = CommonConstant.FAIL;
                    Logger.LogInfo(dbExecuteStatus);
                    Logger.LogInfo("AddressDetailDAO.cs : UpdateAddressDetail() is ended with error.");
                }
            }
            catch (Exception ex)
            {
                objAddressDetail.DbOperationStatus = CommonConstant.FAIL;
                Logger.LogError(ex.Message);
                Logger.LogInfo("AddressDetailDAO.cs : UpdateAddressDetail() is ended with error.");
            }
            return objAddressDetail;
        }

        public AddressDetail SelectRecordById(AddressDetail objAddressDetail)
        {
            try
            {
                Logger.LogInfo("AddressDetailDAO.cs : SelectRecordById() is started.");
                objAddressDetail.ObjectDataSet = DataUtility.SelectRecordById(strDBTableName, objAddressDetail.AddressId, objAddressDetail.Version, strSelectAddressDetail);
                if (GeneralUtility.IsInteger(objAddressDetail.ObjectDataSet.Tables[0].Rows[0][0]) && (objAddressDetail.ObjectDataSet.Tables[1].Columns.Count > 1))
                {
                    if (Convert.ToInt32(objAddressDetail.ObjectDataSet.Tables[0].Rows[0][0]) > 0)
                    {
                        objAddressDetail.IsRecordChanged = false;
                        objAddressDetail.DbOperationStatus = CommonConstant.SUCCEED;
                    }
                    else
                    {
                        objAddressDetail.IsRecordChanged = true;
                        objAddressDetail.DbOperationStatus = CommonConstant.INVALID;
                    }
                    Logger.LogInfo("AddressDetailDAO.cs : SelectRecordById() is ended with success.");
                }
                else
                {
                    objAddressDetail.DbOperationStatus = CommonConstant.FAIL;
                    dbExecuteStatus = objAddressDetail.ObjectDataSet.Tables[0].Rows[0][0].ToString() + " " + objAddressDetail.ObjectDataSet.Tables[1].Rows[0][0].ToString();
                    Logger.LogInfo(dbExecuteStatus);
                    Logger.LogInfo("AddressDetailDAO.cs : SelectRecordById() is ended with error.");
                }
            }
            catch (Exception ex)
            {
                objAddressDetail.DbOperationStatus = CommonConstant.FAIL;
                Logger.LogError(ex.Message);
                Logger.LogInfo("AddressDetailDAO.cs : SelectRecordById() is ended with error.");
            }
            return objAddressDetail;
        }

        public AddressDetail SelectDefaultCoutryStateCity(AddressDetail objAddressDetail)
        {
            objParameterList = new List<SqlParameter>();
            SqlParameter objParameter = null;

            objParameter = new SqlParameter("@RECORD_STATUS", objAddressDetail.RecordStatus);
            objParameterList.Add(objParameter);
            objParameter = new SqlParameter("@COUNTRY_ID", objAddressDetail.CountryObject.CountryId);
            objParameter.SqlDbType = SqlDbType.Int;
            objParameter.Direction = ParameterDirection.InputOutput;
            objParameterList.Add(objParameter);
            objParameter = new SqlParameter("@STATE_ID", objAddressDetail.StateObject.StateId);
            objParameter.SqlDbType = SqlDbType.Int;
            objParameter.Direction = ParameterDirection.InputOutput;
            objParameterList.Add(objParameter);
            objParameter = new SqlParameter("@CITY_ID", objAddressDetail.CityObject.CityId);
            objParameter.SqlDbType = SqlDbType.Int;
            objParameter.Direction = ParameterDirection.InputOutput;
            objParameterList.Add(objParameter);

            try
            {
                Logger.LogInfo("AddressDetailDAO.cs : SelectDefaultCoutryStateCity() is started.");
                objAddressDetail.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList, strGetDefaultCountryStateCity, CommandType.StoredProcedure);
                if (objParameterList[1].Value != DBNull.Value)
                { objAddressDetail.CountryObject.CountryId = Convert.ToInt32(objParameterList[1].Value); }
                else
                { objAddressDetail.CountryObject.CountryId = null; }
                if (objParameterList[2].Value != DBNull.Value)
                { objAddressDetail.StateObject.StateId = Convert.ToInt32(objParameterList[2].Value); }
                else
                { objAddressDetail.StateObject.StateId = null; }
                if (objParameterList[3].Value != DBNull.Value)
                { objAddressDetail.CityObject.CityId = Convert.ToInt32(objParameterList[3].Value); }
                else
                { objAddressDetail.CityObject.CityId = null; }

                objAddressDetail.DbOperationStatus = CommonConstant.SUCCEED;
                Logger.LogInfo("AddressDetailDAO.cs : SelectDefaultCoutryStateCity() is ended with success.");
            }
            catch (Exception ex)
            {
                objAddressDetail.DbOperationStatus = CommonConstant.FAIL;
                Logger.LogError(ex.Message);
                Logger.LogInfo("AddressDetailDAO.cs : SelectDefaultCoutryStateCity() is ended with error.");
            }

            return objAddressDetail;
        }

        public AddressDetail SaveEmployeeAddress(AddressDetail objAddressDetail)
        {
            objParameterList = new List<SqlParameter>();

            UDSP_INSERT_ADDRESS_DETAIL.ADDRESS_LINE1_PARAM(objParameterList, objAddressDetail.AddressLine1);
            UDSP_INSERT_ADDRESS_DETAIL.ADDRESS_LINE2_PARAM(objParameterList, objAddressDetail.AddressLine2);
            if (objAddressDetail.CityObject != null)
            {
                UDSP_INSERT_ADDRESS_DETAIL.CITY_ID_PARAM(objParameterList, objAddressDetail.CityObject.CityId);
            }
            if (objAddressDetail.StateObject != null)
            {
                UDSP_INSERT_ADDRESS_DETAIL.STATE_ID_PARAM(objParameterList, objAddressDetail.StateObject.StateId);
            }
            if (objAddressDetail.CountryObject != null)
            {
                UDSP_INSERT_ADDRESS_DETAIL.COUNTRY_ID_PARAM(objParameterList, objAddressDetail.CountryObject.CountryId);
            }
            UDSP_INSERT_ADDRESS_DETAIL.DISTRICT_PARAM(objParameterList, objAddressDetail.District);
            UDSP_INSERT_ADDRESS_DETAIL.PIN_CODE_PARAM(objParameterList, objAddressDetail.PinCode);
            UDSP_INSERT_ADDRESS_DETAIL.LANDMARK_PARAM(objParameterList, objAddressDetail.Landmark);
            UDSP_INSERT_ADDRESS_DETAIL.LANDLINE_NO_PARAM(objParameterList, objAddressDetail.LandlineNo);
            UDSP_INSERT_ADDRESS_DETAIL.MOBILE_NO_PARAM(objParameterList, objAddressDetail.MobileNo);
            UDSP_INSERT_ADDRESS_DETAIL.EMAIL_ID_PARAM(objParameterList, objAddressDetail.EmailId);
            NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@MODIFIED_BY", objAddressDetail.ModifiedBy);
            NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@PARENT_ID", objAddressDetail.ParentId);
            NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@PARENT_VERSION", objAddressDetail.ParentVersion);
            try
            {
                Logger.LogInfo("AddressDetailDAO.cs : InsertAddressDetail() is started.");
                dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList, strInsertEmployeeAddress, CommandType.StoredProcedure).ToString();
                if (GeneralUtility.IsInteger(dbExecuteStatus))
                {
                    if (Convert.ToInt32(dbExecuteStatus) > 0)
                    {
                        objAddressDetail.AddressId = Convert.ToInt32(dbExecuteStatus);
                        objAddressDetail.DbOperationStatus = CommonConstant.SUCCEED;
                    }
                    else
                    {
                        objAddressDetail.DbOperationStatus = CommonConstant.DUPLICATE;
                    }
                    Logger.LogInfo("AddressDetailDAO.cs : InsertAddressDetail() is ended with success.");
                }
                else
                {
                    objAddressDetail.DbOperationStatus = CommonConstant.FAIL;
                    Logger.LogInfo(dbExecuteStatus);
                    Logger.LogInfo("AddressDetailDAO.cs : InsertAddressDetail() is ended with error.");
                }
            }
            catch (Exception ex)
            {
                objAddressDetail.DbOperationStatus = CommonConstant.FAIL;
                Logger.LogError(ex.Message);
                Logger.LogInfo("AddressDetailDAO.cs : InsertAddressDetail() is ended with error.");
            }
            return objAddressDetail;
        }

        public AddressDetail EditEmployeeAddress(AddressDetail objAddressDetail)
        {
            objParameterList = new List<SqlParameter>();

            UDSP_UPDATE_ADDRESS_DETAIL.ADDRESS_ID_PARAM(objParameterList, objAddressDetail.AddressId);
            UDSP_UPDATE_ADDRESS_DETAIL.ADDRESS_LINE1_PARAM(objParameterList, objAddressDetail.AddressLine1);
            UDSP_UPDATE_ADDRESS_DETAIL.ADDRESS_LINE2_PARAM(objParameterList, objAddressDetail.AddressLine2);
            if (objAddressDetail.CityObject != null)
            {
                UDSP_UPDATE_ADDRESS_DETAIL.CITY_ID_PARAM(objParameterList, objAddressDetail.CityObject.CityId);
            }
            if (objAddressDetail.StateObject != null)
            {
                UDSP_UPDATE_ADDRESS_DETAIL.STATE_ID_PARAM(objParameterList, objAddressDetail.StateObject.StateId);
            }
            if (objAddressDetail.CountryObject != null)
            {
                UDSP_UPDATE_ADDRESS_DETAIL.COUNTRY_ID_PARAM(objParameterList, objAddressDetail.CountryObject.CountryId);
            }
            UDSP_UPDATE_ADDRESS_DETAIL.DISTRICT_PARAM(objParameterList, objAddressDetail.District);
            UDSP_UPDATE_ADDRESS_DETAIL.PIN_CODE_PARAM(objParameterList, objAddressDetail.PinCode);
            UDSP_UPDATE_ADDRESS_DETAIL.LANDMARK_PARAM(objParameterList, objAddressDetail.Landmark);
            UDSP_UPDATE_ADDRESS_DETAIL.LANDLINE_NO_PARAM(objParameterList, objAddressDetail.LandlineNo);
            UDSP_UPDATE_ADDRESS_DETAIL.MOBILE_NO_PARAM(objParameterList, objAddressDetail.MobileNo);
            UDSP_UPDATE_ADDRESS_DETAIL.EMAIL_ID_PARAM(objParameterList, objAddressDetail.EmailId);
            NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@MODIFIED_BY", objAddressDetail.ModifiedBy);
            NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@PARENT_ID", objAddressDetail.ParentId);
            NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@PARENT_VERSION", objAddressDetail.ParentVersion);
            try
            {
                Logger.LogInfo("AddressDetailDAO.cs : UpdateAddressDetail() is started.");
                dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList, strUpdateEmployeeAddress, CommandType.StoredProcedure).ToString();
                if (GeneralUtility.IsInteger(dbExecuteStatus))
                {
                    if (Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
                    {
                        objAddressDetail.DbOperationStatus = CommonConstant.SUCCEED;
                    }
                    else if (Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
                    {
                        objAddressDetail.DbOperationStatus = CommonConstant.INVALID;
                    }
                    else
                    {
                        objAddressDetail.DbOperationStatus = CommonConstant.DUPLICATE;
                    }
                    Logger.LogInfo("AddressDetailDAO.cs : UpdateAddressDetail() is ended with success.");
                }
                else
                {
                    objAddressDetail.DbOperationStatus = CommonConstant.FAIL;
                    Logger.LogInfo(dbExecuteStatus);
                    Logger.LogInfo("AddressDetailDAO.cs : UpdateAddressDetail() is ended with error.");
                }
            }
            catch (Exception ex)
            {
                objAddressDetail.DbOperationStatus = CommonConstant.FAIL;
                Logger.LogError(ex.Message);
                Logger.LogInfo("AddressDetailDAO.cs : UpdateAddressDetail() is ended with error.");
            }
            return objAddressDetail;
        }
    }
}
