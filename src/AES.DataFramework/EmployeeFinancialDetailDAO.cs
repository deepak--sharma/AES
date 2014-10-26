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
	public class EmployeeFinancialDetailDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "EMPLOYEE_FINANCIAL_DETAIL";
		private string strSelectEmployeeFinancialDetail = "UDSP_SELECT_EMPLOYEE_FINANCIAL_DETAIL";
		private string strInsertEmployeeFinancialDetail = "SP_INSERT_EMPLOYEE_FINANCIAL_DETAIL";
		private string strUpdateEmployeeFinancialDetail = "SP_UPDATE_EMPLOYEE_FINANCIAL_DETAIL";
		private string dbExecuteStatus = "";

		public EmployeeFinancialDetail SelectEmployeeFinancialDetail(EmployeeFinancialDetail objEmployeeFinancialDetail)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_EMPLOYEE_FINANCIAL_DETAIL.EMPLOYEE_FINANCIAL_DETAIL_ID_PARAM(objParameterList , objEmployeeFinancialDetail.EmployeeFinancialDetailId);
			UDSP_SELECT_EMPLOYEE_FINANCIAL_DETAIL.PAN_CARD_NO_PARAM(objParameterList , objEmployeeFinancialDetail.PanCardNo);
			UDSP_SELECT_EMPLOYEE_FINANCIAL_DETAIL.PF_NO_PARAM(objParameterList , objEmployeeFinancialDetail.PfNo);
			UDSP_SELECT_EMPLOYEE_FINANCIAL_DETAIL.ESI_NO_PARAM(objParameterList , objEmployeeFinancialDetail.EsiNo);
			UDSP_SELECT_EMPLOYEE_FINANCIAL_DETAIL.IS_PAN_APPROVED_PARAM(objParameterList , objEmployeeFinancialDetail.IsPanApproved);
			UDSP_SELECT_EMPLOYEE_FINANCIAL_DETAIL.ACCOUNT_NO_PARAM(objParameterList , objEmployeeFinancialDetail.AccountNo);
			if (objEmployeeFinancialDetail.AccountTypeObject != null)
			{
				UDSP_SELECT_EMPLOYEE_FINANCIAL_DETAIL.ACCOUNT_TYPE_ID_PARAM(objParameterList , objEmployeeFinancialDetail.AccountTypeObject.MetadataId);
			}
			UDSP_SELECT_EMPLOYEE_FINANCIAL_DETAIL.VPF_PERCENT_PARAM(objParameterList , objEmployeeFinancialDetail.VpfPercent);
			UDSP_SELECT_EMPLOYEE_FINANCIAL_DETAIL.VPF_AMOUNT_PARAM(objParameterList , objEmployeeFinancialDetail.VpfAmount);
			UDSP_SELECT_EMPLOYEE_FINANCIAL_DETAIL.IS_CONSENT_FOR_ECS_PARAM(objParameterList , objEmployeeFinancialDetail.IsConsentForEcs);
			UDSP_SELECT_EMPLOYEE_FINANCIAL_DETAIL.IS_VPF_ELIGIBLE_PARAM(objParameterList , objEmployeeFinancialDetail.IsVpfEligible);
			UDSP_SELECT_EMPLOYEE_FINANCIAL_DETAIL.IS_PF_DEDUCTED_PARAM(objParameterList , objEmployeeFinancialDetail.IsPfDeducted);
			UDSP_SELECT_EMPLOYEE_FINANCIAL_DETAIL.LEDGER_ID_PARAM(objParameterList , objEmployeeFinancialDetail.LedgerId);
			UDSP_SELECT_EMPLOYEE_FINANCIAL_DETAIL.IS_SALARY_HOLD_PARAM(objParameterList , objEmployeeFinancialDetail.IsSalaryHold);
            if (objEmployeeFinancialDetail.PaymentModeObject != null)
            {
                UDSP_SELECT_EMPLOYEE_FINANCIAL_DETAIL.PAYMENT_MODE_ID_PARAM(objParameterList, objEmployeeFinancialDetail.PaymentModeObject.MetadataId);
            }
			if (objEmployeeFinancialDetail.BankObject != null)
			{
				UDSP_SELECT_EMPLOYEE_FINANCIAL_DETAIL.BANK_ID_PARAM(objParameterList , objEmployeeFinancialDetail.BankObject.BankId);
			}
			try
			{
				Logger.LogInfo("EmployeeFinancialDetailDAO.cs : SelectEmployeeFinancialDetail() is started.");
				objEmployeeFinancialDetail.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectEmployeeFinancialDetail, CommandType.StoredProcedure);
				objEmployeeFinancialDetail.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("EmployeeFinancialDetailDAO.cs : SelectEmployeeFinancialDetail() is ended with success.");
			}
			catch (Exception ex)
			{
				objEmployeeFinancialDetail.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("EmployeeFinancialDetailDAO.cs : SelectEmployeeFinancialDetail() is ended with error.");
			}
			return objEmployeeFinancialDetail;
		}

		public EmployeeFinancialDetail InsertEmployeeFinancialDetail(EmployeeFinancialDetail objEmployeeFinancialDetail)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_INSERT_EMPLOYEE_FINANCIAL_DETAIL.PAN_CARD_NO_PARAM(objParameterList , objEmployeeFinancialDetail.PanCardNo);
			UDSP_INSERT_EMPLOYEE_FINANCIAL_DETAIL.PF_NO_PARAM(objParameterList , objEmployeeFinancialDetail.PfNo);
			UDSP_INSERT_EMPLOYEE_FINANCIAL_DETAIL.ESI_NO_PARAM(objParameterList , objEmployeeFinancialDetail.EsiNo);
			UDSP_INSERT_EMPLOYEE_FINANCIAL_DETAIL.IS_PAN_APPROVED_PARAM(objParameterList , objEmployeeFinancialDetail.IsPanApproved);
			UDSP_INSERT_EMPLOYEE_FINANCIAL_DETAIL.ACCOUNT_NO_PARAM(objParameterList , objEmployeeFinancialDetail.AccountNo);
			if (objEmployeeFinancialDetail.AccountTypeObject != null)
			{
				UDSP_INSERT_EMPLOYEE_FINANCIAL_DETAIL.ACCOUNT_TYPE_ID_PARAM(objParameterList , objEmployeeFinancialDetail.AccountTypeObject.MetadataId);
			}
			UDSP_INSERT_EMPLOYEE_FINANCIAL_DETAIL.VPF_PERCENT_PARAM(objParameterList , objEmployeeFinancialDetail.VpfPercent);
			UDSP_INSERT_EMPLOYEE_FINANCIAL_DETAIL.VPF_AMOUNT_PARAM(objParameterList , objEmployeeFinancialDetail.VpfAmount);
			UDSP_INSERT_EMPLOYEE_FINANCIAL_DETAIL.IS_CONSENT_FOR_ECS_PARAM(objParameterList , objEmployeeFinancialDetail.IsConsentForEcs);
			UDSP_INSERT_EMPLOYEE_FINANCIAL_DETAIL.IS_VPF_ELIGIBLE_PARAM(objParameterList , objEmployeeFinancialDetail.IsVpfEligible);
			UDSP_INSERT_EMPLOYEE_FINANCIAL_DETAIL.IS_PF_DEDUCTED_PARAM(objParameterList , objEmployeeFinancialDetail.IsPfDeducted);
			UDSP_INSERT_EMPLOYEE_FINANCIAL_DETAIL.LEDGER_ID_PARAM(objParameterList , objEmployeeFinancialDetail.LedgerId);
			UDSP_INSERT_EMPLOYEE_FINANCIAL_DETAIL.IS_SALARY_HOLD_PARAM(objParameterList , objEmployeeFinancialDetail.IsSalaryHold);
            if (objEmployeeFinancialDetail.PaymentModeObject != null)
            {
                UDSP_INSERT_EMPLOYEE_FINANCIAL_DETAIL.PAYMENT_MODE_ID_PARAM(objParameterList, objEmployeeFinancialDetail.PaymentModeObject.MetadataId);
            }
			if (objEmployeeFinancialDetail.BankObject != null)
			{
				UDSP_INSERT_EMPLOYEE_FINANCIAL_DETAIL.BANK_ID_PARAM(objParameterList , objEmployeeFinancialDetail.BankObject.BankId);
			}
            NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@MODIFIED_BY", objEmployeeFinancialDetail.ModifiedBy);
            NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@PARENT_ID", objEmployeeFinancialDetail.ParentId);
            NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@PARENT_VERSION", objEmployeeFinancialDetail.ParentVersion);
			try
			{
				Logger.LogInfo("EmployeeFinancialDetailDAO.cs : InsertEmployeeFinancialDetail() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strInsertEmployeeFinancialDetail, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) > 0 )
					{
						objEmployeeFinancialDetail.EmployeeFinancialDetailId = Convert.ToInt32(dbExecuteStatus);
						objEmployeeFinancialDetail.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objEmployeeFinancialDetail.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("EmployeeFinancialDetailDAO.cs : InsertEmployeeFinancialDetail() is ended with success.");
				}
				else
				{
					objEmployeeFinancialDetail.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("EmployeeFinancialDetailDAO.cs : InsertEmployeeFinancialDetail() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objEmployeeFinancialDetail.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("EmployeeFinancialDetailDAO.cs : InsertEmployeeFinancialDetail() is ended with error.");
			}
			return objEmployeeFinancialDetail;
		}

		public EmployeeFinancialDetail UpdateEmployeeFinancialDetail(EmployeeFinancialDetail objEmployeeFinancialDetail)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_UPDATE_EMPLOYEE_FINANCIAL_DETAIL.EMPLOYEE_FINANCIAL_DETAIL_ID_PARAM(objParameterList , objEmployeeFinancialDetail.EmployeeFinancialDetailId);
			UDSP_UPDATE_EMPLOYEE_FINANCIAL_DETAIL.PAN_CARD_NO_PARAM(objParameterList , objEmployeeFinancialDetail.PanCardNo);
			UDSP_UPDATE_EMPLOYEE_FINANCIAL_DETAIL.PF_NO_PARAM(objParameterList , objEmployeeFinancialDetail.PfNo);
			UDSP_UPDATE_EMPLOYEE_FINANCIAL_DETAIL.ESI_NO_PARAM(objParameterList , objEmployeeFinancialDetail.EsiNo);
			UDSP_UPDATE_EMPLOYEE_FINANCIAL_DETAIL.IS_PAN_APPROVED_PARAM(objParameterList , objEmployeeFinancialDetail.IsPanApproved);
			UDSP_UPDATE_EMPLOYEE_FINANCIAL_DETAIL.ACCOUNT_NO_PARAM(objParameterList , objEmployeeFinancialDetail.AccountNo);
			if (objEmployeeFinancialDetail.AccountTypeObject != null)
			{
				UDSP_UPDATE_EMPLOYEE_FINANCIAL_DETAIL.ACCOUNT_TYPE_ID_PARAM(objParameterList , objEmployeeFinancialDetail.AccountTypeObject.MetadataId);
			}
			UDSP_UPDATE_EMPLOYEE_FINANCIAL_DETAIL.VPF_PERCENT_PARAM(objParameterList , objEmployeeFinancialDetail.VpfPercent);
			UDSP_UPDATE_EMPLOYEE_FINANCIAL_DETAIL.VPF_AMOUNT_PARAM(objParameterList , objEmployeeFinancialDetail.VpfAmount);
			UDSP_UPDATE_EMPLOYEE_FINANCIAL_DETAIL.IS_CONSENT_FOR_ECS_PARAM(objParameterList , objEmployeeFinancialDetail.IsConsentForEcs);
			UDSP_UPDATE_EMPLOYEE_FINANCIAL_DETAIL.IS_VPF_ELIGIBLE_PARAM(objParameterList , objEmployeeFinancialDetail.IsVpfEligible);
			UDSP_UPDATE_EMPLOYEE_FINANCIAL_DETAIL.IS_PF_DEDUCTED_PARAM(objParameterList , objEmployeeFinancialDetail.IsPfDeducted);
			UDSP_UPDATE_EMPLOYEE_FINANCIAL_DETAIL.LEDGER_ID_PARAM(objParameterList , objEmployeeFinancialDetail.LedgerId);
			UDSP_UPDATE_EMPLOYEE_FINANCIAL_DETAIL.IS_SALARY_HOLD_PARAM(objParameterList , objEmployeeFinancialDetail.IsSalaryHold);
            if (objEmployeeFinancialDetail.PaymentModeObject != null)
            {
                UDSP_UPDATE_EMPLOYEE_FINANCIAL_DETAIL.PAYMENT_MODE_ID_PARAM(objParameterList, objEmployeeFinancialDetail.PaymentModeObject.MetadataId);
            }
			if (objEmployeeFinancialDetail.BankObject != null)
			{
				UDSP_UPDATE_EMPLOYEE_FINANCIAL_DETAIL.BANK_ID_PARAM(objParameterList , objEmployeeFinancialDetail.BankObject.BankId);
			}
            NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@MODIFIED_BY", objEmployeeFinancialDetail.ModifiedBy);
            NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@PARENT_ID", objEmployeeFinancialDetail.ParentId);
            NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@PARENT_VERSION", objEmployeeFinancialDetail.ParentVersion);
			try
			{
				Logger.LogInfo("EmployeeFinancialDetailDAO.cs : UpdateEmployeeFinancialDetail() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strUpdateEmployeeFinancialDetail, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objEmployeeFinancialDetail.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
					{
						objEmployeeFinancialDetail.DbOperationStatus = CommonConstant.INVALID;
					}
					else
					{
						objEmployeeFinancialDetail.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("EmployeeFinancialDetailDAO.cs : UpdateEmployeeFinancialDetail() is ended with success.");
				}
				else
				{
					objEmployeeFinancialDetail.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("EmployeeFinancialDetailDAO.cs : UpdateEmployeeFinancialDetail() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objEmployeeFinancialDetail.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("EmployeeFinancialDetailDAO.cs : UpdateEmployeeFinancialDetail() is ended with error.");
			}
			return objEmployeeFinancialDetail;
		}

		public EmployeeFinancialDetail SelectRecordById(EmployeeFinancialDetail objEmployeeFinancialDetail)
		{
			try
			{
				Logger.LogInfo("EmployeeFinancialDetailDAO.cs : SelectRecordById() is started.");
				objEmployeeFinancialDetail.ObjectDataSet = DataUtility.SelectRecordById(strDBTableName, objEmployeeFinancialDetail.EmployeeFinancialDetailId, objEmployeeFinancialDetail.Version, strSelectEmployeeFinancialDetail);
				if (GeneralUtility.IsInteger(objEmployeeFinancialDetail.ObjectDataSet.Tables[0].Rows[0][0]) && (objEmployeeFinancialDetail.ObjectDataSet.Tables[1].Columns.Count > 1))
				{
					if (Convert.ToInt32(objEmployeeFinancialDetail.ObjectDataSet.Tables[0].Rows[0][0]) > 0)
					{
						objEmployeeFinancialDetail.IsRecordChanged = false;
						objEmployeeFinancialDetail.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objEmployeeFinancialDetail.IsRecordChanged = true;
						objEmployeeFinancialDetail.DbOperationStatus = CommonConstant.INVALID;
					}
					Logger.LogInfo("EmployeeFinancialDetailDAO.cs : SelectRecordById() is ended with success.");
				}
				else
				{
					objEmployeeFinancialDetail.DbOperationStatus = CommonConstant.FAIL;
					dbExecuteStatus = objEmployeeFinancialDetail.ObjectDataSet.Tables[0].Rows[0][0].ToString() + " " + objEmployeeFinancialDetail.ObjectDataSet.Tables[1].Rows[0][0].ToString();
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("EmployeeFinancialDetailDAO.cs : SelectRecordById() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objEmployeeFinancialDetail.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("EmployeeFinancialDetailDAO.cs : SelectRecordById() is ended with error.");
			}
			return objEmployeeFinancialDetail;
		}
	}
}
