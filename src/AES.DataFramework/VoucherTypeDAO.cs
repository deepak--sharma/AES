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
	public class VoucherTypeDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "VOUCHER_TYPE";
		private string strSelectVoucherType = "UDSP_SELECT_VOUCHER_TYPE";
		private string strInsertVoucherType = "UDSP_INSERT_VOUCHER_TYPE";
		private string strUpdateVoucherType = "UDSP_UPDATE_VOUCHER_TYPE";
		private string dbExecuteStatus = "";

		public VoucherType SelectVoucherType(VoucherType objVoucherType)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_VOUCHER_TYPE.VOUCHER_TYPE_ID_PARAM(objParameterList , objVoucherType.VoucherTypeId);
			UDSP_SELECT_VOUCHER_TYPE.VOUCHER_TYPE_NAME_PARAM(objParameterList , objVoucherType.VoucherTypeName);
			UDSP_SELECT_VOUCHER_TYPE.SERIAL_NUMBER_MODE_PARAM(objParameterList , objVoucherType.SerialNumberMode);
			UDSP_SELECT_VOUCHER_TYPE.SERIAL_NUMBER_PREFIX_PARAM(objParameterList , objVoucherType.SerialNumberPrefix);
			UDSP_SELECT_VOUCHER_TYPE.NUMERICAL_WIDTH_PARAM(objParameterList , objVoucherType.NumericalWidth);
			UDSP_SELECT_VOUCHER_TYPE.IS_ZERO_PREFIX_PARAM(objParameterList , objVoucherType.IsZeroPrefix);
			UDSP_SELECT_VOUCHER_TYPE.STARTING_NUMBER_PARAM(objParameterList , objVoucherType.StartingNumber);
			UDSP_SELECT_VOUCHER_TYPE.RECORD_STATUS_PARAM(objParameterList , objVoucherType.RecordStatus);
			try
			{
				Logger.LogInfo("VoucherTypeDAO.cs : SelectVoucherType() is started.");
				objVoucherType.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectVoucherType, CommandType.StoredProcedure);
				objVoucherType.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("VoucherTypeDAO.cs : SelectVoucherType() is ended with success.");
			}
			catch (Exception ex)
			{
				objVoucherType.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("VoucherTypeDAO.cs : SelectVoucherType() is ended with error.");
			}
			return objVoucherType;
		}

		public VoucherType InsertVoucherType(VoucherType objVoucherType)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_INSERT_VOUCHER_TYPE.VOUCHER_TYPE_NAME_PARAM(objParameterList , objVoucherType.VoucherTypeName);
			UDSP_INSERT_VOUCHER_TYPE.SERIAL_NUMBER_MODE_PARAM(objParameterList , objVoucherType.SerialNumberMode);
			UDSP_INSERT_VOUCHER_TYPE.SERIAL_NUMBER_PREFIX_PARAM(objParameterList , objVoucherType.SerialNumberPrefix);
			UDSP_INSERT_VOUCHER_TYPE.NUMERICAL_WIDTH_PARAM(objParameterList , objVoucherType.NumericalWidth);
			UDSP_INSERT_VOUCHER_TYPE.IS_ZERO_PREFIX_PARAM(objParameterList , objVoucherType.IsZeroPrefix);
			UDSP_INSERT_VOUCHER_TYPE.STARTING_NUMBER_PARAM(objParameterList , objVoucherType.StartingNumber);
			UDSP_INSERT_VOUCHER_TYPE.VERSION_PARAM(objParameterList , objVoucherType.Version);
			UDSP_INSERT_VOUCHER_TYPE.CREATED_BY_PARAM(objParameterList , objVoucherType.CreatedBy);
			UDSP_INSERT_VOUCHER_TYPE.CREATED_ON_PARAM(objParameterList , objVoucherType.CreatedOn);
			UDSP_INSERT_VOUCHER_TYPE.MODIFIED_BY_PARAM(objParameterList , objVoucherType.ModifiedBy);
			UDSP_INSERT_VOUCHER_TYPE.MODIFIED_ON_PARAM(objParameterList , objVoucherType.ModifiedOn);
			UDSP_INSERT_VOUCHER_TYPE.RECORD_STATUS_PARAM(objParameterList , objVoucherType.RecordStatus);
			try
			{
				Logger.LogInfo("VoucherTypeDAO.cs : InsertVoucherType() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strInsertVoucherType, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) > 0 )
					{
						objVoucherType.VoucherTypeId = Convert.ToInt32(dbExecuteStatus);
						objVoucherType.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objVoucherType.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("VoucherTypeDAO.cs : InsertVoucherType() is ended with success.");
				}
				else
				{
					objVoucherType.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("VoucherTypeDAO.cs : InsertVoucherType() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objVoucherType.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("VoucherTypeDAO.cs : InsertVoucherType() is ended with error.");
			}
			return objVoucherType;
		}

		public VoucherType UpdateVoucherType(VoucherType objVoucherType)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_UPDATE_VOUCHER_TYPE.VOUCHER_TYPE_ID_PARAM(objParameterList , objVoucherType.VoucherTypeId);
			UDSP_UPDATE_VOUCHER_TYPE.VOUCHER_TYPE_NAME_PARAM(objParameterList , objVoucherType.VoucherTypeName);
			UDSP_UPDATE_VOUCHER_TYPE.SERIAL_NUMBER_MODE_PARAM(objParameterList , objVoucherType.SerialNumberMode);
			UDSP_UPDATE_VOUCHER_TYPE.SERIAL_NUMBER_PREFIX_PARAM(objParameterList , objVoucherType.SerialNumberPrefix);
			UDSP_UPDATE_VOUCHER_TYPE.NUMERICAL_WIDTH_PARAM(objParameterList , objVoucherType.NumericalWidth);
			UDSP_UPDATE_VOUCHER_TYPE.IS_ZERO_PREFIX_PARAM(objParameterList , objVoucherType.IsZeroPrefix);
			UDSP_UPDATE_VOUCHER_TYPE.STARTING_NUMBER_PARAM(objParameterList , objVoucherType.StartingNumber);
			UDSP_UPDATE_VOUCHER_TYPE.VERSION_PARAM(objParameterList , objVoucherType.Version);
			UDSP_UPDATE_VOUCHER_TYPE.CREATED_BY_PARAM(objParameterList , objVoucherType.CreatedBy);
			UDSP_UPDATE_VOUCHER_TYPE.CREATED_ON_PARAM(objParameterList , objVoucherType.CreatedOn);
			UDSP_UPDATE_VOUCHER_TYPE.MODIFIED_BY_PARAM(objParameterList , objVoucherType.ModifiedBy);
			UDSP_UPDATE_VOUCHER_TYPE.MODIFIED_ON_PARAM(objParameterList , objVoucherType.ModifiedOn);
			UDSP_UPDATE_VOUCHER_TYPE.RECORD_STATUS_PARAM(objParameterList , objVoucherType.RecordStatus);
			try
			{
				Logger.LogInfo("VoucherTypeDAO.cs : UpdateVoucherType() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strUpdateVoucherType, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objVoucherType.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
					{
						objVoucherType.DbOperationStatus = CommonConstant.INVALID;
					}
					else
					{
						objVoucherType.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("VoucherTypeDAO.cs : UpdateVoucherType() is ended with success.");
				}
				else
				{
					objVoucherType.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("VoucherTypeDAO.cs : UpdateVoucherType() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objVoucherType.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("VoucherTypeDAO.cs : UpdateVoucherType() is ended with error.");
			}
			return objVoucherType;
		}

		public VoucherType ActivateDeactivateVoucherType(VoucherType objVoucherType)
		{
			try
			{
				Logger.LogInfo("VoucherTypeDAO.cs : ActivateDeactivateVoucherTypeDAO() is started.");
				dbExecuteStatus = DataUtility.ActivateDeactivateObject(strDBTableName, objVoucherType.VoucherTypeId,
										objVoucherType.Version, objVoucherType.RecordStatus, objVoucherType.ModifiedBy);
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objVoucherType.DbOperationStatus = CommonConstant.SUCCEED;
						Logger.LogInfo("VoucherTypeDAO.cs : ActivateDeactivateVoucherType() is ended with success.");
					}
					else
					{
						objVoucherType.DbOperationStatus = CommonConstant.INVALID;
						Logger.LogInfo("VoucherTypeDAO.cs : ActivateDeactivateVoucherType() is ended with success.");
					}
				}
				else
				{
					objVoucherType.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("VoucherTypeDAO.cs : ActivateDeactivateVoucherType() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objVoucherType.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("VoucherTypeDAO.cs : ActivateDeactivateVoucherType() is ended with error.");
			}
			return objVoucherType;
		}

		public VoucherType SelectRecordById(VoucherType objVoucherType)
		{
			try
			{
				Logger.LogInfo("VoucherTypeDAO.cs : SelectRecordById() is started.");
				objVoucherType.ObjectDataSet = DataUtility.SelectRecordById(strDBTableName, objVoucherType.VoucherTypeId, objVoucherType.Version, strSelectVoucherType);
				if (GeneralUtility.IsInteger(objVoucherType.ObjectDataSet.Tables[0].Rows[0][0]) && (objVoucherType.ObjectDataSet.Tables[1].Columns.Count > 1))
				{
					if (Convert.ToInt32(objVoucherType.ObjectDataSet.Tables[0].Rows[0][0]) > 0)
					{
						objVoucherType.IsRecordChanged = false;
						objVoucherType.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objVoucherType.IsRecordChanged = true;
						objVoucherType.DbOperationStatus = CommonConstant.INVALID;
					}
					Logger.LogInfo("VoucherTypeDAO.cs : SelectRecordById() is ended with success.");
				}
				else
				{
					objVoucherType.DbOperationStatus = CommonConstant.FAIL;
					dbExecuteStatus = objVoucherType.ObjectDataSet.Tables[0].Rows[0][0].ToString() + " " + objVoucherType.ObjectDataSet.Tables[1].Rows[0][0].ToString();
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("VoucherTypeDAO.cs : SelectRecordById() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objVoucherType.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("VoucherTypeDAO.cs : SelectRecordById() is ended with error.");
			}
			return objVoucherType;
		}
	}
}
