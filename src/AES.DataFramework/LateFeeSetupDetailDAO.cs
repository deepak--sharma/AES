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
	public class LateFeeSetupDetailDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "LATE_FEE_SETUP_DETAIL";
		private string strSelectLateFeeSetupDetail = "SP_SELECT_LATE_FEE_SETUP_DETAIL";
        private string strSelectLateFeeSetupDetailSchema = "SP_SELECT_LATE_FEE_SETUP_DETAIL_SCHEMA";
		private string strInsertLateFeeSetupDetail = "UDSP_INSERT_LATE_FEE_SETUP_DETAIL";
		private string strUpdateLateFeeSetupDetail = "UDSP_UPDATE_LATE_FEE_SETUP_DETAIL";
        private string strDeleteLateFeeDetailData = "DELETE FROM LATE_FEE_SETUP_DETAIL WHERE LATE_FEE_SETUP_ID=@LATE_FEE_SETUP_ID";
		private string dbExecuteStatus = "";

		public LateFeeSetupDetail SelectLateFeeSetupDetail(LateFeeSetupDetail objLateFeeSetupDetail)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_LATE_FEE_SETUP_DETAIL.LATE_FEE_SETUP_DETAIL_ID_PARAM(objParameterList , objLateFeeSetupDetail.LateFeeSetupDetailId);
			if (objLateFeeSetupDetail.LateFeeSetupObject != null)
			{
				UDSP_SELECT_LATE_FEE_SETUP_DETAIL.LATE_FEE_SETUP_ID_PARAM(objParameterList , objLateFeeSetupDetail.LateFeeSetupObject.LateFeeId);
			}
			UDSP_SELECT_LATE_FEE_SETUP_DETAIL.START_RANGE_PARAM(objParameterList , objLateFeeSetupDetail.StartRange);
			UDSP_SELECT_LATE_FEE_SETUP_DETAIL.END_RANGE_PARAM(objParameterList , objLateFeeSetupDetail.EndRange);
			UDSP_SELECT_LATE_FEE_SETUP_DETAIL.AMOUNT_PARAM(objParameterList , objLateFeeSetupDetail.Amount);
			if (objLateFeeSetupDetail.FrequencyObject != null)
			{
				UDSP_SELECT_LATE_FEE_SETUP_DETAIL.FREQUENCY_ID_PARAM(objParameterList , objLateFeeSetupDetail.FrequencyObject.MetadataId);
			}
			try
			{
				Logger.LogInfo("LateFeeSetupDetailDAO.cs : SelectLateFeeSetupDetail() is started.");
				objLateFeeSetupDetail.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectLateFeeSetupDetail, CommandType.StoredProcedure);
				objLateFeeSetupDetail.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("LateFeeSetupDetailDAO.cs : SelectLateFeeSetupDetail() is ended with success.");
			}
			catch (Exception ex)
			{
				objLateFeeSetupDetail.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("LateFeeSetupDetailDAO.cs : SelectLateFeeSetupDetail() is ended with error.");
			}
			return objLateFeeSetupDetail;
		}
		public LateFeeSetupDetail SubmitLateFeeSetupDetailData(LateFeeSetupDetail objLateFeeSetupDetail)
		{
			objParameterList = new List<SqlParameter>();
			if (objLateFeeSetupDetail.LateFeeSetupObject != null)
			{
				UDSP_SELECT_LATE_FEE_SETUP_DETAIL.LATE_FEE_SETUP_ID_PARAM(objParameterList , objLateFeeSetupDetail.LateFeeSetupObject.LateFeeId);
			}	
			
			try
			{
				Logger.LogInfo("LateFeeSetupDetailDAO.cs : SubmitLateFeeSetupDetailData() is started.");
                DBMANAGER.ExecuteQuery(objParameterList, strDeleteLateFeeDetailData);
                dbExecuteStatus = DBMANAGER.ExecuteDataSet(objLateFeeSetupDetail.ObjectDataSet, strSelectLateFeeSetupDetailSchema, CommandType.StoredProcedure).ToString();
				objLateFeeSetupDetail.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("LateFeeSetupDetailDAO.cs : SubmitLateFeeSetupDetailData() is ended with success.");
			}
			catch (Exception ex)
			{
				objLateFeeSetupDetail.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("LateFeeSetupDetailDAO.cs : SubmitLateFeeSetupDetailData() is ended with error.");
			}
			return objLateFeeSetupDetail;
		}

	}
}
