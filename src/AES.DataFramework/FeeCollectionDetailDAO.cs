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
	public class FeeCollectionDetailDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "FEE_COLLECTION_DETAIL";
		private string strSelectFeeCollectionDetail = "UDSP_SELECT_FEE_COLLECTION_DETAIL";
		private string strInsertFeeCollectionDetail = "UDSP_INSERT_FEE_COLLECTION_DETAIL";
		private string strUpdateFeeCollectionDetail = "UDSP_UPDATE_FEE_COLLECTION_DETAIL";
		private string dbExecuteStatus = "";

		public FeeCollectionDetail SelectFeeCollectionDetail(FeeCollectionDetail objFeeCollectionDetail)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_FEE_COLLECTION_DETAIL.FEE_COLLECTION_ID_PARAM(objParameterList , objFeeCollectionDetail.FeeCollectionId);
			if (objFeeCollectionDetail.StudentObject != null)
			{
				UDSP_SELECT_FEE_COLLECTION_DETAIL.STUDENT_ID_PARAM(objParameterList , objFeeCollectionDetail.StudentObject.StudentId);
			}
			UDSP_SELECT_FEE_COLLECTION_DETAIL.BASE_FEE_PARAM(objParameterList , objFeeCollectionDetail.BaseFee);
			UDSP_SELECT_FEE_COLLECTION_DETAIL.DISCOUNT_FEE_PARAM(objParameterList , objFeeCollectionDetail.DiscountFee);
			UDSP_SELECT_FEE_COLLECTION_DETAIL.LATE_FEE_PARAM(objParameterList , objFeeCollectionDetail.LateFee);
			UDSP_SELECT_FEE_COLLECTION_DETAIL.FINE_PARAM(objParameterList , objFeeCollectionDetail.Fine);
			UDSP_SELECT_FEE_COLLECTION_DETAIL.TOTAL_FEE_PARAM(objParameterList , objFeeCollectionDetail.TotalFee);
			UDSP_SELECT_FEE_COLLECTION_DETAIL.PREVIOUS_BALANCE_PARAM(objParameterList , objFeeCollectionDetail.PreviousBalance);
			UDSP_SELECT_FEE_COLLECTION_DETAIL.FEE_DEPOSITE_PARAM(objParameterList , objFeeCollectionDetail.FeeDeposite);
			UDSP_SELECT_FEE_COLLECTION_DETAIL.CURRENT_BALANCE_PARAM(objParameterList , objFeeCollectionDetail.CurrentBalance);
			UDSP_SELECT_FEE_COLLECTION_DETAIL.SUBMITION_DATE_PARAM(objParameterList , objFeeCollectionDetail.SubmitionDate);
			UDSP_SELECT_FEE_COLLECTION_DETAIL.RECORD_STATUS_PARAM(objParameterList , objFeeCollectionDetail.RecordStatus);
			try
			{
				Logger.LogInfo("FeeCollectionDetailDAO.cs : SelectFeeCollectionDetail() is started.");
				objFeeCollectionDetail.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectFeeCollectionDetail, CommandType.StoredProcedure);
				objFeeCollectionDetail.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("FeeCollectionDetailDAO.cs : SelectFeeCollectionDetail() is ended with success.");
			}
			catch (Exception ex)
			{
				objFeeCollectionDetail.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("FeeCollectionDetailDAO.cs : SelectFeeCollectionDetail() is ended with error.");
			}
			return objFeeCollectionDetail;
		}

		public FeeCollectionDetail InsertFeeCollectionDetail(FeeCollectionDetail objFeeCollectionDetail)
		{
			objParameterList = new List<SqlParameter>();
				
			if (objFeeCollectionDetail.StudentObject != null)
			{
				UDSP_INSERT_FEE_COLLECTION_DETAIL.STUDENT_ID_PARAM(objParameterList , objFeeCollectionDetail.StudentObject.StudentId);
			}
			UDSP_INSERT_FEE_COLLECTION_DETAIL.BASE_FEE_PARAM(objParameterList , objFeeCollectionDetail.BaseFee);
			UDSP_INSERT_FEE_COLLECTION_DETAIL.DISCOUNT_FEE_PARAM(objParameterList , objFeeCollectionDetail.DiscountFee);
			UDSP_INSERT_FEE_COLLECTION_DETAIL.LATE_FEE_PARAM(objParameterList , objFeeCollectionDetail.LateFee);
			UDSP_INSERT_FEE_COLLECTION_DETAIL.FINE_PARAM(objParameterList , objFeeCollectionDetail.Fine);
			UDSP_INSERT_FEE_COLLECTION_DETAIL.TOTAL_FEE_PARAM(objParameterList , objFeeCollectionDetail.TotalFee);
			UDSP_INSERT_FEE_COLLECTION_DETAIL.PREVIOUS_BALANCE_PARAM(objParameterList , objFeeCollectionDetail.PreviousBalance);
			UDSP_INSERT_FEE_COLLECTION_DETAIL.FEE_DEPOSITE_PARAM(objParameterList , objFeeCollectionDetail.FeeDeposite);
			UDSP_INSERT_FEE_COLLECTION_DETAIL.CURRENT_BALANCE_PARAM(objParameterList , objFeeCollectionDetail.CurrentBalance);
			UDSP_INSERT_FEE_COLLECTION_DETAIL.SUBMITION_DATE_PARAM(objParameterList , objFeeCollectionDetail.SubmitionDate);
			UDSP_INSERT_FEE_COLLECTION_DETAIL.VERSION_PARAM(objParameterList , objFeeCollectionDetail.Version);
			UDSP_INSERT_FEE_COLLECTION_DETAIL.CREATED_BY_PARAM(objParameterList , objFeeCollectionDetail.CreatedBy);
			UDSP_INSERT_FEE_COLLECTION_DETAIL.CREATED_ON_PARAM(objParameterList , objFeeCollectionDetail.CreatedOn);
			UDSP_INSERT_FEE_COLLECTION_DETAIL.MODIFIED_BY_PARAM(objParameterList , objFeeCollectionDetail.ModifiedBy);
			UDSP_INSERT_FEE_COLLECTION_DETAIL.MODIFIED_ON_PARAM(objParameterList , objFeeCollectionDetail.ModifiedOn);
			UDSP_INSERT_FEE_COLLECTION_DETAIL.RECORD_STATUS_PARAM(objParameterList , objFeeCollectionDetail.RecordStatus);
			try
			{
				Logger.LogInfo("FeeCollectionDetailDAO.cs : InsertFeeCollectionDetail() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strInsertFeeCollectionDetail, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) > 0 )
					{
						objFeeCollectionDetail.FeeCollectionId = Convert.ToInt32(dbExecuteStatus);
						objFeeCollectionDetail.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objFeeCollectionDetail.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("FeeCollectionDetailDAO.cs : InsertFeeCollectionDetail() is ended with success.");
				}
				else
				{
					objFeeCollectionDetail.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("FeeCollectionDetailDAO.cs : InsertFeeCollectionDetail() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objFeeCollectionDetail.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("FeeCollectionDetailDAO.cs : InsertFeeCollectionDetail() is ended with error.");
			}
			return objFeeCollectionDetail;
		}

		public FeeCollectionDetail UpdateFeeCollectionDetail(FeeCollectionDetail objFeeCollectionDetail)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_UPDATE_FEE_COLLECTION_DETAIL.FEE_COLLECTION_ID_PARAM(objParameterList , objFeeCollectionDetail.FeeCollectionId);
			if (objFeeCollectionDetail.StudentObject != null)
			{
				UDSP_UPDATE_FEE_COLLECTION_DETAIL.STUDENT_ID_PARAM(objParameterList , objFeeCollectionDetail.StudentObject.StudentId);
			}
			UDSP_UPDATE_FEE_COLLECTION_DETAIL.BASE_FEE_PARAM(objParameterList , objFeeCollectionDetail.BaseFee);
			UDSP_UPDATE_FEE_COLLECTION_DETAIL.DISCOUNT_FEE_PARAM(objParameterList , objFeeCollectionDetail.DiscountFee);
			UDSP_UPDATE_FEE_COLLECTION_DETAIL.LATE_FEE_PARAM(objParameterList , objFeeCollectionDetail.LateFee);
			UDSP_UPDATE_FEE_COLLECTION_DETAIL.FINE_PARAM(objParameterList , objFeeCollectionDetail.Fine);
			UDSP_UPDATE_FEE_COLLECTION_DETAIL.TOTAL_FEE_PARAM(objParameterList , objFeeCollectionDetail.TotalFee);
			UDSP_UPDATE_FEE_COLLECTION_DETAIL.PREVIOUS_BALANCE_PARAM(objParameterList , objFeeCollectionDetail.PreviousBalance);
			UDSP_UPDATE_FEE_COLLECTION_DETAIL.FEE_DEPOSITE_PARAM(objParameterList , objFeeCollectionDetail.FeeDeposite);
			UDSP_UPDATE_FEE_COLLECTION_DETAIL.CURRENT_BALANCE_PARAM(objParameterList , objFeeCollectionDetail.CurrentBalance);
			UDSP_UPDATE_FEE_COLLECTION_DETAIL.SUBMITION_DATE_PARAM(objParameterList , objFeeCollectionDetail.SubmitionDate);
			UDSP_UPDATE_FEE_COLLECTION_DETAIL.VERSION_PARAM(objParameterList , objFeeCollectionDetail.Version);
			UDSP_UPDATE_FEE_COLLECTION_DETAIL.CREATED_BY_PARAM(objParameterList , objFeeCollectionDetail.CreatedBy);
			UDSP_UPDATE_FEE_COLLECTION_DETAIL.CREATED_ON_PARAM(objParameterList , objFeeCollectionDetail.CreatedOn);
			UDSP_UPDATE_FEE_COLLECTION_DETAIL.MODIFIED_BY_PARAM(objParameterList , objFeeCollectionDetail.ModifiedBy);
			UDSP_UPDATE_FEE_COLLECTION_DETAIL.MODIFIED_ON_PARAM(objParameterList , objFeeCollectionDetail.ModifiedOn);
			UDSP_UPDATE_FEE_COLLECTION_DETAIL.RECORD_STATUS_PARAM(objParameterList , objFeeCollectionDetail.RecordStatus);
			try
			{
				Logger.LogInfo("FeeCollectionDetailDAO.cs : UpdateFeeCollectionDetail() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strUpdateFeeCollectionDetail, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objFeeCollectionDetail.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
					{
						objFeeCollectionDetail.DbOperationStatus = CommonConstant.INVALID;
					}
					else
					{
						objFeeCollectionDetail.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("FeeCollectionDetailDAO.cs : UpdateFeeCollectionDetail() is ended with success.");
				}
				else
				{
					objFeeCollectionDetail.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("FeeCollectionDetailDAO.cs : UpdateFeeCollectionDetail() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objFeeCollectionDetail.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("FeeCollectionDetailDAO.cs : UpdateFeeCollectionDetail() is ended with error.");
			}
			return objFeeCollectionDetail;
		}

		public FeeCollectionDetail ActivateDeactivateFeeCollectionDetail(FeeCollectionDetail objFeeCollectionDetail)
		{
			try
			{
				Logger.LogInfo("FeeCollectionDetailDAO.cs : ActivateDeactivateFeeCollectionDetailDAO() is started.");
				dbExecuteStatus = DataUtility.ActivateDeactivateObject(strDBTableName, objFeeCollectionDetail.FeeCollectionId,
										objFeeCollectionDetail.Version, objFeeCollectionDetail.RecordStatus, objFeeCollectionDetail.ModifiedBy);
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objFeeCollectionDetail.DbOperationStatus = CommonConstant.SUCCEED;
						Logger.LogInfo("FeeCollectionDetailDAO.cs : ActivateDeactivateFeeCollectionDetail() is ended with success.");
					}
					else
					{
						objFeeCollectionDetail.DbOperationStatus = CommonConstant.INVALID;
						Logger.LogInfo("FeeCollectionDetailDAO.cs : ActivateDeactivateFeeCollectionDetail() is ended with success.");
					}
				}
				else
				{
					objFeeCollectionDetail.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("FeeCollectionDetailDAO.cs : ActivateDeactivateFeeCollectionDetail() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objFeeCollectionDetail.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("FeeCollectionDetailDAO.cs : ActivateDeactivateFeeCollectionDetail() is ended with error.");
			}
			return objFeeCollectionDetail;
		}

		public FeeCollectionDetail SelectRecordById(FeeCollectionDetail objFeeCollectionDetail)
		{
			try
			{
				Logger.LogInfo("FeeCollectionDetailDAO.cs : SelectRecordById() is started.");
				objFeeCollectionDetail.ObjectDataSet = DataUtility.SelectRecordById(strDBTableName, objFeeCollectionDetail.FeeCollectionId, objFeeCollectionDetail.Version, strSelectFeeCollectionDetail);
				if (GeneralUtility.IsInteger(objFeeCollectionDetail.ObjectDataSet.Tables[0].Rows[0][0]) && (objFeeCollectionDetail.ObjectDataSet.Tables[1].Columns.Count > 1))
				{
					if (Convert.ToInt32(objFeeCollectionDetail.ObjectDataSet.Tables[0].Rows[0][0]) > 0)
					{
						objFeeCollectionDetail.IsRecordChanged = false;
						objFeeCollectionDetail.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objFeeCollectionDetail.IsRecordChanged = true;
						objFeeCollectionDetail.DbOperationStatus = CommonConstant.INVALID;
					}
					Logger.LogInfo("FeeCollectionDetailDAO.cs : SelectRecordById() is ended with success.");
				}
				else
				{
					objFeeCollectionDetail.DbOperationStatus = CommonConstant.FAIL;
					dbExecuteStatus = objFeeCollectionDetail.ObjectDataSet.Tables[0].Rows[0][0].ToString() + " " + objFeeCollectionDetail.ObjectDataSet.Tables[1].Rows[0][0].ToString();
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("FeeCollectionDetailDAO.cs : SelectRecordById() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objFeeCollectionDetail.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("FeeCollectionDetailDAO.cs : SelectRecordById() is ended with error.");
			}
			return objFeeCollectionDetail;
		}
	}
}
