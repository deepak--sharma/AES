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
	public class ImmigrationDetailDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "IMMIGRATION_DETAIL";
		private string strSelectImmigrationDetail = "SP_SELECT_IMMIGRATION_DETAIL";
        private string strGetImmigrationDetail = "SP_GET_IMMIGRATION_DETAIL";
		private string strInsertImmigrationDetail = "UDSP_INSERT_IMMIGRATION_DETAIL";
		private string strUpdateImmigrationDetail = "UDSP_UPDATE_IMMIGRATION_DETAIL";
		private string dbExecuteStatus = "";

		public ImmigrationDetail SelectImmigrationDetail(ImmigrationDetail objImmigrationDetail)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_IMMIGRATION_DETAIL.IMMIGRATION_ID_PARAM(objParameterList , objImmigrationDetail.ImmigrationId);
			if (objImmigrationDetail.MemberObject != null)
			{
				UDSP_SELECT_IMMIGRATION_DETAIL.MEMBER_ID_PARAM(objParameterList , objImmigrationDetail.MemberObject.EmployeeId);
			}
			if (objImmigrationDetail.MemberTypeObject != null)
			{
				UDSP_SELECT_IMMIGRATION_DETAIL.MEMBER_TYPE_ID_PARAM(objParameterList , objImmigrationDetail.MemberTypeObject.MetadataId);
			}
			UDSP_SELECT_IMMIGRATION_DETAIL.PASSPORT_NO_PARAM(objParameterList , objImmigrationDetail.PassportNo);
			UDSP_SELECT_IMMIGRATION_DETAIL.PASSPORT_DETAIL_PARAM(objParameterList , objImmigrationDetail.PassportDetail);
			UDSP_SELECT_IMMIGRATION_DETAIL.ISSUE_DATE_PARAM(objParameterList , objImmigrationDetail.IssueDate);
			UDSP_SELECT_IMMIGRATION_DETAIL.EXPIRY_DATE_PARAM(objParameterList , objImmigrationDetail.ExpiryDate);
			UDSP_SELECT_IMMIGRATION_DETAIL.REVISE_DATE_PARAM(objParameterList , objImmigrationDetail.ReviseDate);
			UDSP_SELECT_IMMIGRATION_DETAIL.SPONSOR_PARAM(objParameterList , objImmigrationDetail.Sponsor);
            NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@IMMIGRATION_STATUS_METADATA_ID", objImmigrationDetail.StatusObject.DataHolder);
			if (objImmigrationDetail.StatusObject != null)
			{
				UDSP_SELECT_IMMIGRATION_DETAIL.STATUS_ID_PARAM(objParameterList , objImmigrationDetail.StatusObject.MetadataId);
			}
			UDSP_SELECT_IMMIGRATION_DETAIL.COMMENT_PARAM(objParameterList , objImmigrationDetail.Comment);
			try
			{
				Logger.LogInfo("ImmigrationDetailDAO.cs : SelectImmigrationDetail() is started.");
				objImmigrationDetail.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectImmigrationDetail, CommandType.StoredProcedure);
				objImmigrationDetail.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("ImmigrationDetailDAO.cs : SelectImmigrationDetail() is ended with success.");
			}
			catch (Exception ex)
			{
				objImmigrationDetail.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("ImmigrationDetailDAO.cs : SelectImmigrationDetail() is ended with error.");
			}
			return objImmigrationDetail;
		}
		public ImmigrationDetail SubmitImmigrationDetailData(ImmigrationDetail objImmigrationDetail)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_IMMIGRATION_DETAIL.IMMIGRATION_ID_PARAM(objParameterList , objImmigrationDetail.ImmigrationId);
			if (objImmigrationDetail.MemberObject != null)
			{
				UDSP_SELECT_IMMIGRATION_DETAIL.MEMBER_ID_PARAM(objParameterList , objImmigrationDetail.MemberObject.EmployeeId);
			}
			if (objImmigrationDetail.MemberTypeObject != null)
			{
				UDSP_SELECT_IMMIGRATION_DETAIL.MEMBER_TYPE_ID_PARAM(objParameterList , objImmigrationDetail.MemberTypeObject.MetadataId);
			}
			UDSP_SELECT_IMMIGRATION_DETAIL.PASSPORT_NO_PARAM(objParameterList , objImmigrationDetail.PassportNo);
			UDSP_SELECT_IMMIGRATION_DETAIL.PASSPORT_DETAIL_PARAM(objParameterList , objImmigrationDetail.PassportDetail);
			UDSP_SELECT_IMMIGRATION_DETAIL.ISSUE_DATE_PARAM(objParameterList , objImmigrationDetail.IssueDate);
			UDSP_SELECT_IMMIGRATION_DETAIL.EXPIRY_DATE_PARAM(objParameterList , objImmigrationDetail.ExpiryDate);
			UDSP_SELECT_IMMIGRATION_DETAIL.REVISE_DATE_PARAM(objParameterList , objImmigrationDetail.ReviseDate);
			UDSP_SELECT_IMMIGRATION_DETAIL.SPONSOR_PARAM(objParameterList , objImmigrationDetail.Sponsor);
			if (objImmigrationDetail.StatusObject != null)
			{
				UDSP_SELECT_IMMIGRATION_DETAIL.STATUS_ID_PARAM(objParameterList , objImmigrationDetail.StatusObject.MetadataId);
			}
			UDSP_SELECT_IMMIGRATION_DETAIL.COMMENT_PARAM(objParameterList , objImmigrationDetail.Comment);
			try
			{
				Logger.LogInfo("ImmigrationDetailDAO.cs : SubmitImmigrationDetailData() is started.");
                dbExecuteStatus = DBMANAGER.ExecuteDataSet(objParameterList, objImmigrationDetail.ObjectDataSet, strGetImmigrationDetail, CommandType.StoredProcedure).ToString();
				objImmigrationDetail.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("ImmigrationDetailDAO.cs : SubmitImmigrationDetailData() is ended with success.");
			}
			catch (Exception ex)
			{
				objImmigrationDetail.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("ImmigrationDetailDAO.cs : SubmitImmigrationDetailData() is ended with error.");
			}
			return objImmigrationDetail;
		}

	}
}
