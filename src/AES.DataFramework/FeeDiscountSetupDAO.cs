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
	public class FeeDiscountSetupDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "FEE_DISCOUNT_SETUP";
		private string strSelectFeeDiscountSetup = "UDSP_SELECT_FEE_DISCOUNT_SETUP";
		private string strInsertFeeDiscountSetup = "UDSP_INSERT_FEE_DISCOUNT_SETUP";
		private string strUpdateFeeDiscountSetup = "UDSP_UPDATE_FEE_DISCOUNT_SETUP";
		private string dbExecuteStatus = "";

		public FeeDiscountSetup SelectFeeDiscountSetup(FeeDiscountSetup objFeeDiscountSetup)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_FEE_DISCOUNT_SETUP.FEE_DISCOUNT_ID_PARAM(objParameterList , objFeeDiscountSetup.FeeDiscountId);
			if (objFeeDiscountSetup.FeeStructureDetailObject != null)
			{
				UDSP_SELECT_FEE_DISCOUNT_SETUP.FEE_STRUCTURE_DETAIL_ID_PARAM(objParameterList , objFeeDiscountSetup.FeeStructureDetailObject.FeeStructureDetailId);
			}
			if (objFeeDiscountSetup.DiscountTypeObject != null)
			{
				UDSP_SELECT_FEE_DISCOUNT_SETUP.DISCOUNT_TYPE_ID_PARAM(objParameterList , objFeeDiscountSetup.DiscountTypeObject.FeeId);
			}
			UDSP_SELECT_FEE_DISCOUNT_SETUP.DISCOUNT_TYPE_VALUE_PARAM(objParameterList , objFeeDiscountSetup.DiscountTypeValue);
			UDSP_SELECT_FEE_DISCOUNT_SETUP.DISCOUNT_AMOUNT_PARAM(objParameterList , objFeeDiscountSetup.DiscountAmount);
			UDSP_SELECT_FEE_DISCOUNT_SETUP.IS_PERCENT_PARAM(objParameterList , objFeeDiscountSetup.IsPercent);
			UDSP_SELECT_FEE_DISCOUNT_SETUP.EFFECTIVE_DATE_PARAM(objParameterList , objFeeDiscountSetup.EffectiveDate);			
			try
			{
				Logger.LogInfo("FeeDiscountSetupDAO.cs : SelectFeeDiscountSetup() is started.");
				objFeeDiscountSetup.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectFeeDiscountSetup, CommandType.StoredProcedure);
				objFeeDiscountSetup.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("FeeDiscountSetupDAO.cs : SelectFeeDiscountSetup() is ended with success.");
			}
			catch (Exception ex)
			{
				objFeeDiscountSetup.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("FeeDiscountSetupDAO.cs : SelectFeeDiscountSetup() is ended with error.");
			}
			return objFeeDiscountSetup;
		}

		public FeeDiscountSetup InsertFeeDiscountSetup(FeeDiscountSetup objFeeDiscountSetup)
		{
			objParameterList = new List<SqlParameter>();
				
			if (objFeeDiscountSetup.FeeStructureDetailObject != null)
			{
				UDSP_INSERT_FEE_DISCOUNT_SETUP.FEE_STRUCTURE_DETAIL_ID_PARAM(objParameterList , objFeeDiscountSetup.FeeStructureDetailObject.FeeStructureDetailId);
			}
			if (objFeeDiscountSetup.DiscountTypeObject != null)
			{
				UDSP_INSERT_FEE_DISCOUNT_SETUP.DISCOUNT_TYPE_ID_PARAM(objParameterList , objFeeDiscountSetup.DiscountTypeObject.FeeId);
			}
			UDSP_INSERT_FEE_DISCOUNT_SETUP.DISCOUNT_TYPE_VALUE_PARAM(objParameterList , objFeeDiscountSetup.DiscountTypeValue);
			UDSP_INSERT_FEE_DISCOUNT_SETUP.DISCOUNT_AMOUNT_PARAM(objParameterList , objFeeDiscountSetup.DiscountAmount);
			UDSP_INSERT_FEE_DISCOUNT_SETUP.IS_PERCENT_PARAM(objParameterList , objFeeDiscountSetup.IsPercent);
			UDSP_INSERT_FEE_DISCOUNT_SETUP.EFFECTIVE_DATE_PARAM(objParameterList , objFeeDiscountSetup.EffectiveDate);
			
			try
			{
				Logger.LogInfo("FeeDiscountSetupDAO.cs : InsertFeeDiscountSetup() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strInsertFeeDiscountSetup, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) > 0 )
					{
						objFeeDiscountSetup.FeeDiscountId = Convert.ToInt32(dbExecuteStatus);
						objFeeDiscountSetup.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objFeeDiscountSetup.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("FeeDiscountSetupDAO.cs : InsertFeeDiscountSetup() is ended with success.");
				}
				else
				{
					objFeeDiscountSetup.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("FeeDiscountSetupDAO.cs : InsertFeeDiscountSetup() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objFeeDiscountSetup.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("FeeDiscountSetupDAO.cs : InsertFeeDiscountSetup() is ended with error.");
			}
			return objFeeDiscountSetup;
		}

		public FeeDiscountSetup UpdateFeeDiscountSetup(FeeDiscountSetup objFeeDiscountSetup)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_UPDATE_FEE_DISCOUNT_SETUP.FEE_DISCOUNT_ID_PARAM(objParameterList , objFeeDiscountSetup.FeeDiscountId);
			if (objFeeDiscountSetup.FeeStructureDetailObject != null)
			{
				UDSP_UPDATE_FEE_DISCOUNT_SETUP.FEE_STRUCTURE_DETAIL_ID_PARAM(objParameterList , objFeeDiscountSetup.FeeStructureDetailObject.FeeStructureDetailId);
			}
			if (objFeeDiscountSetup.DiscountTypeObject != null)
			{
				UDSP_UPDATE_FEE_DISCOUNT_SETUP.DISCOUNT_TYPE_ID_PARAM(objParameterList , objFeeDiscountSetup.DiscountTypeObject.FeeId);
			}
			UDSP_UPDATE_FEE_DISCOUNT_SETUP.DISCOUNT_TYPE_VALUE_PARAM(objParameterList , objFeeDiscountSetup.DiscountTypeValue);
			UDSP_UPDATE_FEE_DISCOUNT_SETUP.DISCOUNT_AMOUNT_PARAM(objParameterList , objFeeDiscountSetup.DiscountAmount);
			UDSP_UPDATE_FEE_DISCOUNT_SETUP.IS_PERCENT_PARAM(objParameterList , objFeeDiscountSetup.IsPercent);
			UDSP_UPDATE_FEE_DISCOUNT_SETUP.EFFECTIVE_DATE_PARAM(objParameterList , objFeeDiscountSetup.EffectiveDate);
			
			try
			{
				Logger.LogInfo("FeeDiscountSetupDAO.cs : UpdateFeeDiscountSetup() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strUpdateFeeDiscountSetup, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objFeeDiscountSetup.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
					{
						objFeeDiscountSetup.DbOperationStatus = CommonConstant.INVALID;
					}
					else
					{
						objFeeDiscountSetup.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("FeeDiscountSetupDAO.cs : UpdateFeeDiscountSetup() is ended with success.");
				}
				else
				{
					objFeeDiscountSetup.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("FeeDiscountSetupDAO.cs : UpdateFeeDiscountSetup() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objFeeDiscountSetup.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("FeeDiscountSetupDAO.cs : UpdateFeeDiscountSetup() is ended with error.");
			}
			return objFeeDiscountSetup;
		}

		public FeeDiscountSetup ActivateDeactivateFeeDiscountSetup(FeeDiscountSetup objFeeDiscountSetup)
		{
			try
			{
				Logger.LogInfo("FeeDiscountSetupDAO.cs : ActivateDeactivateFeeDiscountSetupDAO() is started.");
				dbExecuteStatus = DataUtility.ActivateDeactivateObject(strDBTableName, objFeeDiscountSetup.FeeDiscountId,
										objFeeDiscountSetup.Version, objFeeDiscountSetup.RecordStatus, objFeeDiscountSetup.ModifiedBy);
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objFeeDiscountSetup.DbOperationStatus = CommonConstant.SUCCEED;
						Logger.LogInfo("FeeDiscountSetupDAO.cs : ActivateDeactivateFeeDiscountSetup() is ended with success.");
					}
					else
					{
						objFeeDiscountSetup.DbOperationStatus = CommonConstant.INVALID;
						Logger.LogInfo("FeeDiscountSetupDAO.cs : ActivateDeactivateFeeDiscountSetup() is ended with success.");
					}
				}
				else
				{
					objFeeDiscountSetup.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("FeeDiscountSetupDAO.cs : ActivateDeactivateFeeDiscountSetup() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objFeeDiscountSetup.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("FeeDiscountSetupDAO.cs : ActivateDeactivateFeeDiscountSetup() is ended with error.");
			}
			return objFeeDiscountSetup;
		}

		public FeeDiscountSetup SelectRecordById(FeeDiscountSetup objFeeDiscountSetup)
		{
			try
			{
				Logger.LogInfo("FeeDiscountSetupDAO.cs : SelectRecordById() is started.");
				objFeeDiscountSetup.ObjectDataSet = DataUtility.SelectRecordById(strDBTableName, objFeeDiscountSetup.FeeDiscountId, objFeeDiscountSetup.Version, strSelectFeeDiscountSetup);
				if (GeneralUtility.IsInteger(objFeeDiscountSetup.ObjectDataSet.Tables[0].Rows[0][0]) && (objFeeDiscountSetup.ObjectDataSet.Tables[1].Columns.Count > 1))
				{
					if (Convert.ToInt32(objFeeDiscountSetup.ObjectDataSet.Tables[0].Rows[0][0]) > 0)
					{
						objFeeDiscountSetup.IsRecordChanged = false;
						objFeeDiscountSetup.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objFeeDiscountSetup.IsRecordChanged = true;
						objFeeDiscountSetup.DbOperationStatus = CommonConstant.INVALID;
					}
					Logger.LogInfo("FeeDiscountSetupDAO.cs : SelectRecordById() is ended with success.");
				}
				else
				{
					objFeeDiscountSetup.DbOperationStatus = CommonConstant.FAIL;
					dbExecuteStatus = objFeeDiscountSetup.ObjectDataSet.Tables[0].Rows[0][0].ToString() + " " + objFeeDiscountSetup.ObjectDataSet.Tables[1].Rows[0][0].ToString();
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("FeeDiscountSetupDAO.cs : SelectRecordById() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objFeeDiscountSetup.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("FeeDiscountSetupDAO.cs : SelectRecordById() is ended with error.");
			}
			return objFeeDiscountSetup;
		}
	}
}
