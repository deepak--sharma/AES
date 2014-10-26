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
	public class FeeStructureDetailDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "FEE_STRUCTURE_DETAIL";
		private string strSelectFeeStructureDetail = "SP_SELECT_FEE_STRUCTURE_DETAIL";
		private string strInsertFeeStructureDetail = "UDSP_INSERT_FEE_STRUCTURE_DETAIL";
		private string strUpdateFeeStructureDetail = "UDSP_UPDATE_FEE_STRUCTURE_DETAIL";
		private string dbExecuteStatus = "";

		public FeeStructureDetail SelectFeeStructureDetail(FeeStructureDetail objFeeStructureDetail)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_FEE_STRUCTURE_DETAIL.FEE_STRUCTURE_DETAIL_ID_PARAM(objParameterList , objFeeStructureDetail.FeeStructureDetailId);
			if (objFeeStructureDetail.FeeStructureObject != null)
			{
				UDSP_SELECT_FEE_STRUCTURE_DETAIL.FEE_STRUCTURE_ID_PARAM(objParameterList , objFeeStructureDetail.FeeStructureObject.FeeStructureId);
			}
			if (objFeeStructureDetail.BranchObject != null)
			{
				UDSP_SELECT_FEE_STRUCTURE_DETAIL.BRANCH_ID_PARAM(objParameterList , objFeeStructureDetail.BranchObject.BranchId);
			}
			if (objFeeStructureDetail.ClassObject != null)
			{
				UDSP_SELECT_FEE_STRUCTURE_DETAIL.CLASS_ID_PARAM(objParameterList , objFeeStructureDetail.ClassObject.ClassId);
			}
			
			UDSP_SELECT_FEE_STRUCTURE_DETAIL.RECORD_STATUS_PARAM(objParameterList , objFeeStructureDetail.RecordStatus);
			try
			{
				Logger.LogInfo("FeeStructureDetailDAO.cs : SelectFeeStructureDetail() is started.");
				objFeeStructureDetail.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectFeeStructureDetail, CommandType.StoredProcedure);
				objFeeStructureDetail.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("FeeStructureDetailDAO.cs : SelectFeeStructureDetail() is ended with success.");
			}
			catch (Exception ex)
			{
				objFeeStructureDetail.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("FeeStructureDetailDAO.cs : SelectFeeStructureDetail() is ended with error.");
			}
			return objFeeStructureDetail;
		}

		public FeeStructureDetail InsertFeeStructureDetail(FeeStructureDetail objFeeStructureDetail)
		{
			objParameterList = new List<SqlParameter>();
				
			if (objFeeStructureDetail.FeeStructureObject != null)
			{
				UDSP_INSERT_FEE_STRUCTURE_DETAIL.FEE_STRUCTURE_ID_PARAM(objParameterList , objFeeStructureDetail.FeeStructureObject.FeeStructureId);
			}
			if (objFeeStructureDetail.BranchObject != null)
			{
				UDSP_INSERT_FEE_STRUCTURE_DETAIL.BRANCH_ID_PARAM(objParameterList , objFeeStructureDetail.BranchObject.BranchId);
			}
			if (objFeeStructureDetail.ClassObject != null)
			{
				UDSP_INSERT_FEE_STRUCTURE_DETAIL.CLASS_ID_PARAM(objParameterList , objFeeStructureDetail.ClassObject.ClassId);
			}
            if (objFeeStructureDetail.StreamObject != null)
			{
                NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@STREAM_ID", objFeeStructureDetail.StreamObject.StreamId);
			}
			
			UDSP_INSERT_FEE_STRUCTURE_DETAIL.VERSION_PARAM(objParameterList , objFeeStructureDetail.Version);
			UDSP_INSERT_FEE_STRUCTURE_DETAIL.CREATED_BY_PARAM(objParameterList , objFeeStructureDetail.CreatedBy);
			UDSP_INSERT_FEE_STRUCTURE_DETAIL.CREATED_ON_PARAM(objParameterList , objFeeStructureDetail.CreatedOn);
			UDSP_INSERT_FEE_STRUCTURE_DETAIL.MODIFIED_BY_PARAM(objParameterList , objFeeStructureDetail.ModifiedBy);
			UDSP_INSERT_FEE_STRUCTURE_DETAIL.MODIFIED_ON_PARAM(objParameterList , objFeeStructureDetail.ModifiedOn);
			UDSP_INSERT_FEE_STRUCTURE_DETAIL.RECORD_STATUS_PARAM(objParameterList , objFeeStructureDetail.RecordStatus);
			try
			{
				Logger.LogInfo("FeeStructureDetailDAO.cs : InsertFeeStructureDetail() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strInsertFeeStructureDetail, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) > 0 )
					{
						objFeeStructureDetail.FeeStructureDetailId = Convert.ToInt32(dbExecuteStatus);
						objFeeStructureDetail.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objFeeStructureDetail.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("FeeStructureDetailDAO.cs : InsertFeeStructureDetail() is ended with success.");
				}
				else
				{
					objFeeStructureDetail.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("FeeStructureDetailDAO.cs : InsertFeeStructureDetail() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objFeeStructureDetail.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("FeeStructureDetailDAO.cs : InsertFeeStructureDetail() is ended with error.");
			}
			return objFeeStructureDetail;
		}

		public FeeStructureDetail UpdateFeeStructureDetail(FeeStructureDetail objFeeStructureDetail)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_UPDATE_FEE_STRUCTURE_DETAIL.FEE_STRUCTURE_DETAIL_ID_PARAM(objParameterList , objFeeStructureDetail.FeeStructureDetailId);
			if (objFeeStructureDetail.FeeStructureObject != null)
			{
				UDSP_UPDATE_FEE_STRUCTURE_DETAIL.FEE_STRUCTURE_ID_PARAM(objParameterList , objFeeStructureDetail.FeeStructureObject.FeeStructureId);
			}
			if (objFeeStructureDetail.BranchObject != null)
			{
				UDSP_UPDATE_FEE_STRUCTURE_DETAIL.BRANCH_ID_PARAM(objParameterList , objFeeStructureDetail.BranchObject.BranchId);
			}
			if (objFeeStructureDetail.ClassObject != null)
			{
				UDSP_UPDATE_FEE_STRUCTURE_DETAIL.CLASS_ID_PARAM(objParameterList , objFeeStructureDetail.ClassObject.ClassId);
			}
              if (objFeeStructureDetail.StreamObject != null)
			{
                NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@STREAM_ID", objFeeStructureDetail.StreamObject.StreamId);
			}
			
			UDSP_UPDATE_FEE_STRUCTURE_DETAIL.VERSION_PARAM(objParameterList , objFeeStructureDetail.Version);
			UDSP_UPDATE_FEE_STRUCTURE_DETAIL.CREATED_BY_PARAM(objParameterList , objFeeStructureDetail.CreatedBy);
			UDSP_UPDATE_FEE_STRUCTURE_DETAIL.CREATED_ON_PARAM(objParameterList , objFeeStructureDetail.CreatedOn);
			UDSP_UPDATE_FEE_STRUCTURE_DETAIL.MODIFIED_BY_PARAM(objParameterList , objFeeStructureDetail.ModifiedBy);
			UDSP_UPDATE_FEE_STRUCTURE_DETAIL.MODIFIED_ON_PARAM(objParameterList , objFeeStructureDetail.ModifiedOn);
			UDSP_UPDATE_FEE_STRUCTURE_DETAIL.RECORD_STATUS_PARAM(objParameterList , objFeeStructureDetail.RecordStatus);
			try
			{
				Logger.LogInfo("FeeStructureDetailDAO.cs : UpdateFeeStructureDetail() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strUpdateFeeStructureDetail, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objFeeStructureDetail.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
					{
						objFeeStructureDetail.DbOperationStatus = CommonConstant.INVALID;
					}
					else
					{
						objFeeStructureDetail.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("FeeStructureDetailDAO.cs : UpdateFeeStructureDetail() is ended with success.");
				}
				else
				{
					objFeeStructureDetail.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("FeeStructureDetailDAO.cs : UpdateFeeStructureDetail() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objFeeStructureDetail.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("FeeStructureDetailDAO.cs : UpdateFeeStructureDetail() is ended with error.");
			}
			return objFeeStructureDetail;
		}

		public FeeStructureDetail ActivateDeactivateFeeStructureDetail(FeeStructureDetail objFeeStructureDetail)
		{
			try
			{
				Logger.LogInfo("FeeStructureDetailDAO.cs : ActivateDeactivateFeeStructureDetailDAO() is started.");
				dbExecuteStatus = DataUtility.ActivateDeactivateObject(strDBTableName, objFeeStructureDetail.FeeStructureDetailId,
										objFeeStructureDetail.Version, objFeeStructureDetail.RecordStatus, objFeeStructureDetail.ModifiedBy);
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objFeeStructureDetail.DbOperationStatus = CommonConstant.SUCCEED;
						Logger.LogInfo("FeeStructureDetailDAO.cs : ActivateDeactivateFeeStructureDetail() is ended with success.");
					}
					else
					{
						objFeeStructureDetail.DbOperationStatus = CommonConstant.INVALID;
						Logger.LogInfo("FeeStructureDetailDAO.cs : ActivateDeactivateFeeStructureDetail() is ended with success.");
					}
				}
				else
				{
					objFeeStructureDetail.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("FeeStructureDetailDAO.cs : ActivateDeactivateFeeStructureDetail() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objFeeStructureDetail.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("FeeStructureDetailDAO.cs : ActivateDeactivateFeeStructureDetail() is ended with error.");
			}
			return objFeeStructureDetail;
		}

		public FeeStructureDetail SelectRecordById(FeeStructureDetail objFeeStructureDetail)
		{
			try
			{
				Logger.LogInfo("FeeStructureDetailDAO.cs : SelectRecordById() is started.");
				objFeeStructureDetail.ObjectDataSet = DataUtility.SelectRecordById(strDBTableName, objFeeStructureDetail.FeeStructureDetailId, objFeeStructureDetail.Version, strSelectFeeStructureDetail);
				if (GeneralUtility.IsInteger(objFeeStructureDetail.ObjectDataSet.Tables[0].Rows[0][0]) && (objFeeStructureDetail.ObjectDataSet.Tables[1].Columns.Count > 1))
				{
					if (Convert.ToInt32(objFeeStructureDetail.ObjectDataSet.Tables[0].Rows[0][0]) > 0)
					{
						objFeeStructureDetail.IsRecordChanged = false;
						objFeeStructureDetail.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objFeeStructureDetail.IsRecordChanged = true;
						objFeeStructureDetail.DbOperationStatus = CommonConstant.INVALID;
					}
					Logger.LogInfo("FeeStructureDetailDAO.cs : SelectRecordById() is ended with success.");
				}
				else
				{
					objFeeStructureDetail.DbOperationStatus = CommonConstant.FAIL;
					dbExecuteStatus = objFeeStructureDetail.ObjectDataSet.Tables[0].Rows[0][0].ToString() + " " + objFeeStructureDetail.ObjectDataSet.Tables[1].Rows[0][0].ToString();
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("FeeStructureDetailDAO.cs : SelectRecordById() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objFeeStructureDetail.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("FeeStructureDetailDAO.cs : SelectRecordById() is ended with error.");
			}
			return objFeeStructureDetail;
		}
	}
}
