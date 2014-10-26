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
	public class EmployeeDetailDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "EMPLOYEE_DETAIL";
		private string strSelectEmployeeDetail = "SP_SELECT_EMPLOYEE_DETAIL";
		private string strInsertEmployeeDetail = "UDSP_INSERT_EMPLOYEE_DETAIL";
		private string strUpdateEmployeeDetail = "UDSP_UPDATE_EMPLOYEE_DETAIL";
        private string strUpdateEmployeeVersion = "SP_UPDATE_EMPLOYEE_VERSION";
		private string dbExecuteStatus = "";

		public EmployeeDetail SelectEmployeeDetail(EmployeeDetail objEmployeeDetail)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_EMPLOYEE_DETAIL.EMPLOYEE_ID_PARAM(objParameterList , objEmployeeDetail.EmployeeId);
			UDSP_SELECT_EMPLOYEE_DETAIL.EMPLOYEE_CODE_PARAM(objParameterList , objEmployeeDetail.EmployeeCode);
			UDSP_SELECT_EMPLOYEE_DETAIL.FIRST_NAME_PARAM(objParameterList , objEmployeeDetail.FirstName);
			UDSP_SELECT_EMPLOYEE_DETAIL.MIDDLE_NAME_PARAM(objParameterList , objEmployeeDetail.MiddleName);
			UDSP_SELECT_EMPLOYEE_DETAIL.LAST_NAME_PARAM(objParameterList , objEmployeeDetail.LastName);
            NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@FATHER_NAME", objEmployeeDetail.FatherName);
			if (objEmployeeDetail.GenderObject != null)
			{
				UDSP_SELECT_EMPLOYEE_DETAIL.GENDER_ID_PARAM(objParameterList , objEmployeeDetail.GenderObject.MetadataId);
			}
			UDSP_SELECT_EMPLOYEE_DETAIL.DATE_OF_BIRTH_PARAM(objParameterList , objEmployeeDetail.DateOfBirth);
			if (objEmployeeDetail.MaritialStatusObject != null)
			{
				UDSP_SELECT_EMPLOYEE_DETAIL.MARITIAL_STATUS_ID_PARAM(objParameterList , objEmployeeDetail.MaritialStatusObject.MetadataId);
			}
			UDSP_SELECT_EMPLOYEE_DETAIL.MARRIAGE_DATE_PARAM(objParameterList , objEmployeeDetail.MarriageDate);
			UDSP_SELECT_EMPLOYEE_DETAIL.PHOTO_PARAM(objParameterList , objEmployeeDetail.Photo);
			if (objEmployeeDetail.EmployeeAdministrativeDetailObject != null)
			{
				UDSP_SELECT_EMPLOYEE_DETAIL.EMPLOYEE_ADMINISTRATIVE_DETAIL_ID_PARAM(objParameterList , objEmployeeDetail.EmployeeAdministrativeDetailObject.EmployeeAdministrativeDetailId);
			}
			if (objEmployeeDetail.EmployeeFinancialDetailObject != null)
			{
				UDSP_SELECT_EMPLOYEE_DETAIL.EMPLOYEE_FINANCIAL_DETAIL_ID_PARAM(objParameterList , objEmployeeDetail.EmployeeFinancialDetailObject.EmployeeFinancialDetailId);
			}
			if (objEmployeeDetail.ReligionObject != null)
			{
				UDSP_SELECT_EMPLOYEE_DETAIL.RELIGION_ID_PARAM(objParameterList , objEmployeeDetail.ReligionObject.MetadataId);
			}
			if (objEmployeeDetail.CastecategoryObject != null)
			{
				UDSP_SELECT_EMPLOYEE_DETAIL.CASTECATEGORY_ID_PARAM(objParameterList , objEmployeeDetail.CastecategoryObject.MetadataId);
			}
			if (objEmployeeDetail.NationalityObject != null)
			{
				UDSP_SELECT_EMPLOYEE_DETAIL.NATIONALITY_ID_PARAM(objParameterList , objEmployeeDetail.NationalityObject.MetadataId);
			}
			if (objEmployeeDetail.CurrentAddressObject != null)
			{
				UDSP_SELECT_EMPLOYEE_DETAIL.CURRENT_ADDRESS_ID_PARAM(objParameterList , objEmployeeDetail.CurrentAddressObject.AddressId);
			}
			if (objEmployeeDetail.PermanentAddressObject != null)
			{
				UDSP_SELECT_EMPLOYEE_DETAIL.PERMANENT_ADDRESS_ID_PARAM(objParameterList , objEmployeeDetail.PermanentAddressObject.AddressId);
			}
			if (objEmployeeDetail.PrimaryEmergencyObject != null)
			{
				UDSP_SELECT_EMPLOYEE_DETAIL.PRIMARY_EMERGENCY_ID_PARAM(objParameterList , objEmployeeDetail.PrimaryEmergencyObject.EmergencyDetailId);
			}
			if (objEmployeeDetail.SecondryEmergencyObject != null)
			{
				UDSP_SELECT_EMPLOYEE_DETAIL.SECONDRY_EMERGENCY_ID_PARAM(objParameterList , objEmployeeDetail.SecondryEmergencyObject.EmergencyDetailId);
			}
			UDSP_SELECT_EMPLOYEE_DETAIL.PERSONAL_EMAIL_ID_PARAM(objParameterList , objEmployeeDetail.PersonalEmailId);
			UDSP_SELECT_EMPLOYEE_DETAIL.OFFICE_EMAIL_ID_PARAM(objParameterList , objEmployeeDetail.OfficeEmailId);
			UDSP_SELECT_EMPLOYEE_DETAIL.IS_FRESHER_PARAM(objParameterList , objEmployeeDetail.IsFresher);
			UDSP_SELECT_EMPLOYEE_DETAIL.COMPAIGN_PARAM(objParameterList , objEmployeeDetail.Compaign);
			UDSP_SELECT_EMPLOYEE_DETAIL.SSN_NO_PARAM(objParameterList , objEmployeeDetail.SsnNo);
			UDSP_SELECT_EMPLOYEE_DETAIL.RECORD_STATUS_PARAM(objParameterList , objEmployeeDetail.RecordStatus);
			try
			{
				Logger.LogInfo("EmployeeDetailDAO.cs : SelectEmployeeDetail() is started.");
				objEmployeeDetail.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectEmployeeDetail, CommandType.StoredProcedure);
				objEmployeeDetail.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("EmployeeDetailDAO.cs : SelectEmployeeDetail() is ended with success.");
			}
			catch (Exception ex)
			{
				objEmployeeDetail.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("EmployeeDetailDAO.cs : SelectEmployeeDetail() is ended with error.");
			}
			return objEmployeeDetail;
		}

		public EmployeeDetail InsertEmployeeDetail(EmployeeDetail objEmployeeDetail)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_INSERT_EMPLOYEE_DETAIL.EMPLOYEE_CODE_PARAM(objParameterList , objEmployeeDetail.EmployeeCode);
			UDSP_INSERT_EMPLOYEE_DETAIL.FIRST_NAME_PARAM(objParameterList , objEmployeeDetail.FirstName);
			UDSP_INSERT_EMPLOYEE_DETAIL.MIDDLE_NAME_PARAM(objParameterList , objEmployeeDetail.MiddleName);
			UDSP_INSERT_EMPLOYEE_DETAIL.LAST_NAME_PARAM(objParameterList , objEmployeeDetail.LastName);
            NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@FATHER_NAME", objEmployeeDetail.FatherName);
			if (objEmployeeDetail.GenderObject != null)
			{
				UDSP_INSERT_EMPLOYEE_DETAIL.GENDER_ID_PARAM(objParameterList , objEmployeeDetail.GenderObject.MetadataId);
			}
			UDSP_INSERT_EMPLOYEE_DETAIL.DATE_OF_BIRTH_PARAM(objParameterList , objEmployeeDetail.DateOfBirth);
			if (objEmployeeDetail.MaritialStatusObject != null)
			{
				UDSP_INSERT_EMPLOYEE_DETAIL.MARITIAL_STATUS_ID_PARAM(objParameterList , objEmployeeDetail.MaritialStatusObject.MetadataId);
			}
			UDSP_INSERT_EMPLOYEE_DETAIL.MARRIAGE_DATE_PARAM(objParameterList , objEmployeeDetail.MarriageDate);
			UDSP_INSERT_EMPLOYEE_DETAIL.PHOTO_PARAM(objParameterList , objEmployeeDetail.Photo);
			if (objEmployeeDetail.EmployeeAdministrativeDetailObject != null)
			{
				UDSP_INSERT_EMPLOYEE_DETAIL.EMPLOYEE_ADMINISTRATIVE_DETAIL_ID_PARAM(objParameterList , objEmployeeDetail.EmployeeAdministrativeDetailObject.EmployeeAdministrativeDetailId);
			}
			if (objEmployeeDetail.EmployeeFinancialDetailObject != null)
			{
				UDSP_INSERT_EMPLOYEE_DETAIL.EMPLOYEE_FINANCIAL_DETAIL_ID_PARAM(objParameterList , objEmployeeDetail.EmployeeFinancialDetailObject.EmployeeFinancialDetailId);
			}
			if (objEmployeeDetail.ReligionObject != null)
			{
				UDSP_INSERT_EMPLOYEE_DETAIL.RELIGION_ID_PARAM(objParameterList , objEmployeeDetail.ReligionObject.MetadataId);
			}
			if (objEmployeeDetail.CastecategoryObject != null)
			{
				UDSP_INSERT_EMPLOYEE_DETAIL.CASTECATEGORY_ID_PARAM(objParameterList , objEmployeeDetail.CastecategoryObject.MetadataId);
			}
			if (objEmployeeDetail.NationalityObject != null)
			{
				UDSP_INSERT_EMPLOYEE_DETAIL.NATIONALITY_ID_PARAM(objParameterList , objEmployeeDetail.NationalityObject.MetadataId);
			}
			if (objEmployeeDetail.CurrentAddressObject != null)
			{
				UDSP_INSERT_EMPLOYEE_DETAIL.CURRENT_ADDRESS_ID_PARAM(objParameterList , objEmployeeDetail.CurrentAddressObject.AddressId);
			}
			if (objEmployeeDetail.PermanentAddressObject != null)
			{
				UDSP_INSERT_EMPLOYEE_DETAIL.PERMANENT_ADDRESS_ID_PARAM(objParameterList , objEmployeeDetail.PermanentAddressObject.AddressId);
			}
			if (objEmployeeDetail.PrimaryEmergencyObject != null)
			{
				UDSP_INSERT_EMPLOYEE_DETAIL.PRIMARY_EMERGENCY_ID_PARAM(objParameterList , objEmployeeDetail.PrimaryEmergencyObject.EmergencyDetailId);
			}
			if (objEmployeeDetail.SecondryEmergencyObject != null)
			{
				UDSP_INSERT_EMPLOYEE_DETAIL.SECONDRY_EMERGENCY_ID_PARAM(objParameterList , objEmployeeDetail.SecondryEmergencyObject.EmergencyDetailId);
			}
			UDSP_INSERT_EMPLOYEE_DETAIL.PERSONAL_EMAIL_ID_PARAM(objParameterList , objEmployeeDetail.PersonalEmailId);
			UDSP_INSERT_EMPLOYEE_DETAIL.OFFICE_EMAIL_ID_PARAM(objParameterList , objEmployeeDetail.OfficeEmailId);
			UDSP_INSERT_EMPLOYEE_DETAIL.IS_FRESHER_PARAM(objParameterList , objEmployeeDetail.IsFresher);
			UDSP_INSERT_EMPLOYEE_DETAIL.COMPAIGN_PARAM(objParameterList , objEmployeeDetail.Compaign);
			UDSP_INSERT_EMPLOYEE_DETAIL.SSN_NO_PARAM(objParameterList , objEmployeeDetail.SsnNo);
			UDSP_INSERT_EMPLOYEE_DETAIL.VERSION_PARAM(objParameterList , objEmployeeDetail.Version);
			UDSP_INSERT_EMPLOYEE_DETAIL.CREATED_BY_PARAM(objParameterList , objEmployeeDetail.CreatedBy);
			UDSP_INSERT_EMPLOYEE_DETAIL.CREATED_ON_PARAM(objParameterList , objEmployeeDetail.CreatedOn);
			UDSP_INSERT_EMPLOYEE_DETAIL.MODIFIED_BY_PARAM(objParameterList , objEmployeeDetail.ModifiedBy);
			UDSP_INSERT_EMPLOYEE_DETAIL.MODIFIED_ON_PARAM(objParameterList , objEmployeeDetail.ModifiedOn);
			UDSP_INSERT_EMPLOYEE_DETAIL.RECORD_STATUS_PARAM(objParameterList , objEmployeeDetail.RecordStatus);
			try
			{
				Logger.LogInfo("EmployeeDetailDAO.cs : InsertEmployeeDetail() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strInsertEmployeeDetail, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) > 0 )
					{
						objEmployeeDetail.EmployeeId = Convert.ToInt32(dbExecuteStatus);
						objEmployeeDetail.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objEmployeeDetail.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("EmployeeDetailDAO.cs : InsertEmployeeDetail() is ended with success.");
				}
				else
				{
					objEmployeeDetail.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("EmployeeDetailDAO.cs : InsertEmployeeDetail() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objEmployeeDetail.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("EmployeeDetailDAO.cs : InsertEmployeeDetail() is ended with error.");
			}
			return objEmployeeDetail;
		}

		public EmployeeDetail UpdateEmployeeDetail(EmployeeDetail objEmployeeDetail)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_UPDATE_EMPLOYEE_DETAIL.EMPLOYEE_ID_PARAM(objParameterList , objEmployeeDetail.EmployeeId);
			UDSP_UPDATE_EMPLOYEE_DETAIL.EMPLOYEE_CODE_PARAM(objParameterList , objEmployeeDetail.EmployeeCode);
			UDSP_UPDATE_EMPLOYEE_DETAIL.FIRST_NAME_PARAM(objParameterList , objEmployeeDetail.FirstName);
			UDSP_UPDATE_EMPLOYEE_DETAIL.MIDDLE_NAME_PARAM(objParameterList , objEmployeeDetail.MiddleName);
			UDSP_UPDATE_EMPLOYEE_DETAIL.LAST_NAME_PARAM(objParameterList , objEmployeeDetail.LastName);
            NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@FATHER_NAME", objEmployeeDetail.FatherName);
			if (objEmployeeDetail.GenderObject != null)
			{
				UDSP_UPDATE_EMPLOYEE_DETAIL.GENDER_ID_PARAM(objParameterList , objEmployeeDetail.GenderObject.MetadataId);
			}
			UDSP_UPDATE_EMPLOYEE_DETAIL.DATE_OF_BIRTH_PARAM(objParameterList , objEmployeeDetail.DateOfBirth);
			if (objEmployeeDetail.MaritialStatusObject != null)
			{
				UDSP_UPDATE_EMPLOYEE_DETAIL.MARITIAL_STATUS_ID_PARAM(objParameterList , objEmployeeDetail.MaritialStatusObject.MetadataId);
			}
			UDSP_UPDATE_EMPLOYEE_DETAIL.MARRIAGE_DATE_PARAM(objParameterList , objEmployeeDetail.MarriageDate);
			UDSP_UPDATE_EMPLOYEE_DETAIL.PHOTO_PARAM(objParameterList , objEmployeeDetail.Photo);
			if (objEmployeeDetail.EmployeeAdministrativeDetailObject != null)
			{
				UDSP_UPDATE_EMPLOYEE_DETAIL.EMPLOYEE_ADMINISTRATIVE_DETAIL_ID_PARAM(objParameterList , objEmployeeDetail.EmployeeAdministrativeDetailObject.EmployeeAdministrativeDetailId);
			}
			if (objEmployeeDetail.EmployeeFinancialDetailObject != null)
			{
				UDSP_UPDATE_EMPLOYEE_DETAIL.EMPLOYEE_FINANCIAL_DETAIL_ID_PARAM(objParameterList , objEmployeeDetail.EmployeeFinancialDetailObject.EmployeeFinancialDetailId);
			}
			if (objEmployeeDetail.ReligionObject != null)
			{
				UDSP_UPDATE_EMPLOYEE_DETAIL.RELIGION_ID_PARAM(objParameterList , objEmployeeDetail.ReligionObject.MetadataId);
			}
			if (objEmployeeDetail.CastecategoryObject != null)
			{
				UDSP_UPDATE_EMPLOYEE_DETAIL.CASTECATEGORY_ID_PARAM(objParameterList , objEmployeeDetail.CastecategoryObject.MetadataId);
			}
			if (objEmployeeDetail.NationalityObject != null)
			{
				UDSP_UPDATE_EMPLOYEE_DETAIL.NATIONALITY_ID_PARAM(objParameterList , objEmployeeDetail.NationalityObject.MetadataId);
			}
			if (objEmployeeDetail.CurrentAddressObject != null)
			{
				UDSP_UPDATE_EMPLOYEE_DETAIL.CURRENT_ADDRESS_ID_PARAM(objParameterList , objEmployeeDetail.CurrentAddressObject.AddressId);
			}
			if (objEmployeeDetail.PermanentAddressObject != null)
			{
				UDSP_UPDATE_EMPLOYEE_DETAIL.PERMANENT_ADDRESS_ID_PARAM(objParameterList , objEmployeeDetail.PermanentAddressObject.AddressId);
			}
			if (objEmployeeDetail.PrimaryEmergencyObject != null)
			{
				UDSP_UPDATE_EMPLOYEE_DETAIL.PRIMARY_EMERGENCY_ID_PARAM(objParameterList , objEmployeeDetail.PrimaryEmergencyObject.EmergencyDetailId);
			}
			if (objEmployeeDetail.SecondryEmergencyObject != null)
			{
				UDSP_UPDATE_EMPLOYEE_DETAIL.SECONDRY_EMERGENCY_ID_PARAM(objParameterList , objEmployeeDetail.SecondryEmergencyObject.EmergencyDetailId);
			}
			UDSP_UPDATE_EMPLOYEE_DETAIL.PERSONAL_EMAIL_ID_PARAM(objParameterList , objEmployeeDetail.PersonalEmailId);
			UDSP_UPDATE_EMPLOYEE_DETAIL.OFFICE_EMAIL_ID_PARAM(objParameterList , objEmployeeDetail.OfficeEmailId);
			UDSP_UPDATE_EMPLOYEE_DETAIL.IS_FRESHER_PARAM(objParameterList , objEmployeeDetail.IsFresher);
			UDSP_UPDATE_EMPLOYEE_DETAIL.COMPAIGN_PARAM(objParameterList , objEmployeeDetail.Compaign);
			UDSP_UPDATE_EMPLOYEE_DETAIL.SSN_NO_PARAM(objParameterList , objEmployeeDetail.SsnNo);
			UDSP_UPDATE_EMPLOYEE_DETAIL.VERSION_PARAM(objParameterList , objEmployeeDetail.Version);
			UDSP_UPDATE_EMPLOYEE_DETAIL.CREATED_BY_PARAM(objParameterList , objEmployeeDetail.CreatedBy);
			UDSP_UPDATE_EMPLOYEE_DETAIL.CREATED_ON_PARAM(objParameterList , objEmployeeDetail.CreatedOn);
			UDSP_UPDATE_EMPLOYEE_DETAIL.MODIFIED_BY_PARAM(objParameterList , objEmployeeDetail.ModifiedBy);
			UDSP_UPDATE_EMPLOYEE_DETAIL.MODIFIED_ON_PARAM(objParameterList , objEmployeeDetail.ModifiedOn);
			UDSP_UPDATE_EMPLOYEE_DETAIL.RECORD_STATUS_PARAM(objParameterList , objEmployeeDetail.RecordStatus);
			try
			{
				Logger.LogInfo("EmployeeDetailDAO.cs : UpdateEmployeeDetail() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strUpdateEmployeeDetail, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objEmployeeDetail.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
					{
						objEmployeeDetail.DbOperationStatus = CommonConstant.INVALID;
					}
					else
					{
						objEmployeeDetail.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("EmployeeDetailDAO.cs : UpdateEmployeeDetail() is ended with success.");
				}
				else
				{
					objEmployeeDetail.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("EmployeeDetailDAO.cs : UpdateEmployeeDetail() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objEmployeeDetail.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("EmployeeDetailDAO.cs : UpdateEmployeeDetail() is ended with error.");
			}
			return objEmployeeDetail;
		}

		public EmployeeDetail ActivateDeactivateEmployeeDetail(EmployeeDetail objEmployeeDetail)
		{
			try
			{
				Logger.LogInfo("EmployeeDetailDAO.cs : ActivateDeactivateEmployeeDetailDAO() is started.");
				dbExecuteStatus = DataUtility.ActivateDeactivateObject(strDBTableName, objEmployeeDetail.EmployeeId,
										objEmployeeDetail.Version, objEmployeeDetail.RecordStatus, objEmployeeDetail.ModifiedBy);
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objEmployeeDetail.DbOperationStatus = CommonConstant.SUCCEED;
						Logger.LogInfo("EmployeeDetailDAO.cs : ActivateDeactivateEmployeeDetail() is ended with success.");
					}
					else
					{
						objEmployeeDetail.DbOperationStatus = CommonConstant.INVALID;
						Logger.LogInfo("EmployeeDetailDAO.cs : ActivateDeactivateEmployeeDetail() is ended with success.");
					}
				}
				else
				{
					objEmployeeDetail.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("EmployeeDetailDAO.cs : ActivateDeactivateEmployeeDetail() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objEmployeeDetail.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("EmployeeDetailDAO.cs : ActivateDeactivateEmployeeDetail() is ended with error.");
			}
			return objEmployeeDetail;
		}

		public EmployeeDetail SelectRecordById(EmployeeDetail objEmployeeDetail)
		{
			try
			{
				Logger.LogInfo("EmployeeDetailDAO.cs : SelectRecordById() is started.");
				objEmployeeDetail.ObjectDataSet = DataUtility.SelectRecordById(strDBTableName, objEmployeeDetail.EmployeeId, objEmployeeDetail.Version, strSelectEmployeeDetail);
				if (GeneralUtility.IsInteger(objEmployeeDetail.ObjectDataSet.Tables[0].Rows[0][0]) && (objEmployeeDetail.ObjectDataSet.Tables[1].Columns.Count > 1))
				{
					if (Convert.ToInt32(objEmployeeDetail.ObjectDataSet.Tables[0].Rows[0][0]) > 0)
					{
						objEmployeeDetail.IsRecordChanged = false;
						objEmployeeDetail.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objEmployeeDetail.IsRecordChanged = true;
						objEmployeeDetail.DbOperationStatus = CommonConstant.INVALID;
					}
					Logger.LogInfo("EmployeeDetailDAO.cs : SelectRecordById() is ended with success.");
				}
				else
				{
					objEmployeeDetail.DbOperationStatus = CommonConstant.FAIL;
					dbExecuteStatus = objEmployeeDetail.ObjectDataSet.Tables[0].Rows[0][0].ToString() + " " + objEmployeeDetail.ObjectDataSet.Tables[1].Rows[0][0].ToString();
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("EmployeeDetailDAO.cs : SelectRecordById() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objEmployeeDetail.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("EmployeeDetailDAO.cs : SelectRecordById() is ended with error.");
			}
			return objEmployeeDetail;
		}

        public EmployeeDetail UpdateEmployeeVersion(EmployeeDetail objEmployeeDetail)
        {
            objParameterList = new List<SqlParameter>();
            NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@EMPLOYEE_ID", objEmployeeDetail.EmployeeId);
            NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@VERSION", objEmployeeDetail.Version);
            NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@MODIFIED_BY", objEmployeeDetail.ModifiedBy);
            NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@MODIFIED_ON", objEmployeeDetail.ModifiedOn);
            try
            {
                Logger.LogInfo("EmployeeDetailDAO.cs : UpdateEmployeeVersion() is started.");
                dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList, strUpdateEmployeeVersion, CommandType.StoredProcedure).ToString();
                if (GeneralUtility.IsInteger(dbExecuteStatus))
                {
                    if (Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
                    {
                        objEmployeeDetail.DbOperationStatus = CommonConstant.SUCCEED;
                    }
                    else if (Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
                    {
                        objEmployeeDetail.DbOperationStatus = CommonConstant.INVALID;
                    }
                    else
                    {
                        objEmployeeDetail.DbOperationStatus = CommonConstant.DUPLICATE;
                    }
                    Logger.LogInfo("EmployeeDetailDAO.cs : UpdateEmployeeVersion() is ended with success.");
                }
                else
                {
                    objEmployeeDetail.DbOperationStatus = CommonConstant.FAIL;
                    Logger.LogInfo(dbExecuteStatus);
                    Logger.LogInfo("EmployeeDetailDAO.cs : UpdateEmployeeVersion() is ended with error.");
                }
            }
            catch (Exception ex)
            {
                objEmployeeDetail.DbOperationStatus = CommonConstant.FAIL;
                Logger.LogError(ex.Message);
                Logger.LogInfo("EmployeeDetailDAO.cs : UpdateEmployeeVersion() is ended with error.");
            }
            return objEmployeeDetail;
        }
	}
}
