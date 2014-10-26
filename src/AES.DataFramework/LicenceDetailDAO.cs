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
	public class LicenceDetailDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "LICENCE_DETAIL";
		private string strSelectLicenceDetail = "SP_SELECT_LICENCE_DETAIL";
        private string strGetLicenceDetail = "SP_GET_LICENCE_DETAIL";
		private string strInsertLicenceDetail = "UDSP_INSERT_LICENCE_DETAIL";
		private string strUpdateLicenceDetail = "UDSP_UPDATE_LICENCE_DETAIL";
		private string dbExecuteStatus = "";

		public LicenceDetail SelectLicenceDetail(LicenceDetail objLicenceDetail)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_LICENCE_DETAIL.LICENCE_DETAIL_ID_PARAM(objParameterList , objLicenceDetail.LicenceDetailId);
			if (objLicenceDetail.MemberObject != null)
			{
				UDSP_SELECT_LICENCE_DETAIL.MEMBER_ID_PARAM(objParameterList , objLicenceDetail.MemberObject.EmployeeId);
			}
			if (objLicenceDetail.MemberTypeObject != null)
			{
				UDSP_SELECT_LICENCE_DETAIL.MEMBER_TYPE_ID_PARAM(objParameterList , objLicenceDetail.MemberTypeObject.MetadataId);
			}
			if (objLicenceDetail.LicenceTypeObject != null)
			{
				UDSP_SELECT_LICENCE_DETAIL.LICENCE_TYPE_ID_PARAM(objParameterList , objLicenceDetail.LicenceTypeObject.MetadataId);
			}
			UDSP_SELECT_LICENCE_DETAIL.LICENCE_NUMBER_PARAM(objParameterList , objLicenceDetail.LicenceNumber);
			UDSP_SELECT_LICENCE_DETAIL.ISSUE_DATE_PARAM(objParameterList , objLicenceDetail.IssueDate);
			UDSP_SELECT_LICENCE_DETAIL.EXP_DATE_PARAM(objParameterList , objLicenceDetail.ExpDate);
			UDSP_SELECT_LICENCE_DETAIL.COMMENTS_PARAM(objParameterList , objLicenceDetail.Comments);
            NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@LICENCE_TYPE_METADATA_ID", objLicenceDetail.LicenceTypeObject.DataHolder);
			try
			{
				Logger.LogInfo("LicenceDetailDAO.cs : SelectLicenceDetail() is started.");
				objLicenceDetail.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectLicenceDetail, CommandType.StoredProcedure);
				objLicenceDetail.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("LicenceDetailDAO.cs : SelectLicenceDetail() is ended with success.");
			}
			catch (Exception ex)
			{
				objLicenceDetail.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("LicenceDetailDAO.cs : SelectLicenceDetail() is ended with error.");
			}
			return objLicenceDetail;
		}
		public LicenceDetail SubmitLicenceDetailData(LicenceDetail objLicenceDetail)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_LICENCE_DETAIL.LICENCE_DETAIL_ID_PARAM(objParameterList , objLicenceDetail.LicenceDetailId);
			if (objLicenceDetail.MemberObject != null)
			{
				UDSP_SELECT_LICENCE_DETAIL.MEMBER_ID_PARAM(objParameterList , objLicenceDetail.MemberObject.EmployeeId);
			}
			if (objLicenceDetail.MemberTypeObject != null)
			{
				UDSP_SELECT_LICENCE_DETAIL.MEMBER_TYPE_ID_PARAM(objParameterList , objLicenceDetail.MemberTypeObject.MetadataId);
			}
			if (objLicenceDetail.LicenceTypeObject != null)
			{
				UDSP_SELECT_LICENCE_DETAIL.LICENCE_TYPE_ID_PARAM(objParameterList , objLicenceDetail.LicenceTypeObject.MetadataId);
			}
			UDSP_SELECT_LICENCE_DETAIL.LICENCE_NUMBER_PARAM(objParameterList , objLicenceDetail.LicenceNumber);
			UDSP_SELECT_LICENCE_DETAIL.ISSUE_DATE_PARAM(objParameterList , objLicenceDetail.IssueDate);
			UDSP_SELECT_LICENCE_DETAIL.EXP_DATE_PARAM(objParameterList , objLicenceDetail.ExpDate);
			UDSP_SELECT_LICENCE_DETAIL.COMMENTS_PARAM(objParameterList , objLicenceDetail.Comments);
			try
			{
				Logger.LogInfo("LicenceDetailDAO.cs : SubmitLicenceDetailData() is started.");
                dbExecuteStatus = DBMANAGER.ExecuteDataSet(objParameterList, objLicenceDetail.ObjectDataSet, strGetLicenceDetail, CommandType.StoredProcedure).ToString();
				objLicenceDetail.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("LicenceDetailDAO.cs : SubmitLicenceDetailData() is ended with success.");
			}
			catch (Exception ex)
			{
				objLicenceDetail.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("LicenceDetailDAO.cs : SubmitLicenceDetailData() is ended with error.");
			}
			return objLicenceDetail;
		}

	}
}
