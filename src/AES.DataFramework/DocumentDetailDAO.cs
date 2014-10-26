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
	public class DocumentDetailDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "DOCUMENT_DETAIL";
		private string strSelectDocumentDetail = "UDSP_SELECT_DOCUMENT_DETAIL";
		private string strInsertDocumentDetail = "UDSP_INSERT_DOCUMENT_DETAIL";
		private string strUpdateDocumentDetail = "UDSP_UPDATE_DOCUMENT_DETAIL";
		private string dbExecuteStatus = "";

		public DocumentDetail SelectDocumentDetail(DocumentDetail objDocumentDetail)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_DOCUMENT_DETAIL.DOCUMENT_DETAIL_ID_PARAM(objParameterList , objDocumentDetail.DocumentDetailId);
			UDSP_SELECT_DOCUMENT_DETAIL.MEMBER_ID_PARAM(objParameterList , objDocumentDetail.MemberId);
			if (objDocumentDetail.MemberTypeObject != null)
			{
				UDSP_SELECT_DOCUMENT_DETAIL.MEMBER_TYPE_ID_PARAM(objParameterList , objDocumentDetail.MemberTypeObject.MetadataId);
			}
			if (objDocumentDetail.DocumentObject != null)
			{
				UDSP_SELECT_DOCUMENT_DETAIL.DOCUMENT_ID_PARAM(objParameterList , objDocumentDetail.DocumentObject.MetadataId);
			}
			UDSP_SELECT_DOCUMENT_DETAIL.DOCUMENT_DESCRIPTION_PARAM(objParameterList , objDocumentDetail.DocumentDescription);
			UDSP_SELECT_DOCUMENT_DETAIL.DOCUMENT_PATH_PARAM(objParameterList , objDocumentDetail.DocumentPath);
			UDSP_SELECT_DOCUMENT_DETAIL.COMMENTS_PARAM(objParameterList , objDocumentDetail.Comments);
			UDSP_SELECT_DOCUMENT_DETAIL.UPLOAD_DATE_PARAM(objParameterList , objDocumentDetail.UploadDate);
			try
			{
				Logger.LogInfo("DocumentDetailDAO.cs : SelectDocumentDetail() is started.");
				objDocumentDetail.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectDocumentDetail, CommandType.StoredProcedure);
				objDocumentDetail.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("DocumentDetailDAO.cs : SelectDocumentDetail() is ended with success.");
			}
			catch (Exception ex)
			{
				objDocumentDetail.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("DocumentDetailDAO.cs : SelectDocumentDetail() is ended with error.");
			}
			return objDocumentDetail;
		}

		public DocumentDetail InsertDocumentDetail(DocumentDetail objDocumentDetail)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_INSERT_DOCUMENT_DETAIL.MEMBER_ID_PARAM(objParameterList , objDocumentDetail.MemberId);
			if (objDocumentDetail.MemberTypeObject != null)
			{
				UDSP_INSERT_DOCUMENT_DETAIL.MEMBER_TYPE_ID_PARAM(objParameterList , objDocumentDetail.MemberTypeObject.MetadataId);
			}
			if (objDocumentDetail.DocumentObject != null)
			{
				UDSP_INSERT_DOCUMENT_DETAIL.DOCUMENT_ID_PARAM(objParameterList , objDocumentDetail.DocumentObject.MetadataId);
			}
			UDSP_INSERT_DOCUMENT_DETAIL.DOCUMENT_DESCRIPTION_PARAM(objParameterList , objDocumentDetail.DocumentDescription);
			UDSP_INSERT_DOCUMENT_DETAIL.DOCUMENT_PATH_PARAM(objParameterList , objDocumentDetail.DocumentPath);
			UDSP_INSERT_DOCUMENT_DETAIL.COMMENTS_PARAM(objParameterList , objDocumentDetail.Comments);
			UDSP_INSERT_DOCUMENT_DETAIL.UPLOAD_DATE_PARAM(objParameterList , objDocumentDetail.UploadDate);
			try
			{
				Logger.LogInfo("DocumentDetailDAO.cs : InsertDocumentDetail() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strInsertDocumentDetail, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) > 0 )
					{
						objDocumentDetail.DocumentDetailId = Convert.ToInt32(dbExecuteStatus);
						objDocumentDetail.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objDocumentDetail.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("DocumentDetailDAO.cs : InsertDocumentDetail() is ended with success.");
				}
				else
				{
					objDocumentDetail.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("DocumentDetailDAO.cs : InsertDocumentDetail() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objDocumentDetail.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("DocumentDetailDAO.cs : InsertDocumentDetail() is ended with error.");
			}
			return objDocumentDetail;
		}

		public DocumentDetail UpdateDocumentDetail(DocumentDetail objDocumentDetail)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_UPDATE_DOCUMENT_DETAIL.DOCUMENT_DETAIL_ID_PARAM(objParameterList , objDocumentDetail.DocumentDetailId);
			UDSP_UPDATE_DOCUMENT_DETAIL.MEMBER_ID_PARAM(objParameterList , objDocumentDetail.MemberId);
			if (objDocumentDetail.MemberTypeObject != null)
			{
				UDSP_UPDATE_DOCUMENT_DETAIL.MEMBER_TYPE_ID_PARAM(objParameterList , objDocumentDetail.MemberTypeObject.MetadataId);
			}
			if (objDocumentDetail.DocumentObject != null)
			{
				UDSP_UPDATE_DOCUMENT_DETAIL.DOCUMENT_ID_PARAM(objParameterList , objDocumentDetail.DocumentObject.MetadataId);
			}
			UDSP_UPDATE_DOCUMENT_DETAIL.DOCUMENT_DESCRIPTION_PARAM(objParameterList , objDocumentDetail.DocumentDescription);
			UDSP_UPDATE_DOCUMENT_DETAIL.DOCUMENT_PATH_PARAM(objParameterList , objDocumentDetail.DocumentPath);
			UDSP_UPDATE_DOCUMENT_DETAIL.COMMENTS_PARAM(objParameterList , objDocumentDetail.Comments);
			UDSP_UPDATE_DOCUMENT_DETAIL.UPLOAD_DATE_PARAM(objParameterList , objDocumentDetail.UploadDate);
			try
			{
				Logger.LogInfo("DocumentDetailDAO.cs : UpdateDocumentDetail() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strUpdateDocumentDetail, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objDocumentDetail.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
					{
						objDocumentDetail.DbOperationStatus = CommonConstant.INVALID;
					}
					else
					{
						objDocumentDetail.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("DocumentDetailDAO.cs : UpdateDocumentDetail() is ended with success.");
				}
				else
				{
					objDocumentDetail.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("DocumentDetailDAO.cs : UpdateDocumentDetail() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objDocumentDetail.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("DocumentDetailDAO.cs : UpdateDocumentDetail() is ended with error.");
			}
			return objDocumentDetail;
		}

		public DocumentDetail SelectRecordById(DocumentDetail objDocumentDetail)
		{
			try
			{
				Logger.LogInfo("DocumentDetailDAO.cs : SelectRecordById() is started.");
				objDocumentDetail.ObjectDataSet = DataUtility.SelectRecordById(strDBTableName, objDocumentDetail.DocumentDetailId, objDocumentDetail.Version, strSelectDocumentDetail);
				if (GeneralUtility.IsInteger(objDocumentDetail.ObjectDataSet.Tables[0].Rows[0][0]) && (objDocumentDetail.ObjectDataSet.Tables[1].Columns.Count > 1))
				{
					if (Convert.ToInt32(objDocumentDetail.ObjectDataSet.Tables[0].Rows[0][0]) > 0)
					{
						objDocumentDetail.IsRecordChanged = false;
						objDocumentDetail.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objDocumentDetail.IsRecordChanged = true;
						objDocumentDetail.DbOperationStatus = CommonConstant.INVALID;
					}
					Logger.LogInfo("DocumentDetailDAO.cs : SelectRecordById() is ended with success.");
				}
				else
				{
					objDocumentDetail.DbOperationStatus = CommonConstant.FAIL;
					dbExecuteStatus = objDocumentDetail.ObjectDataSet.Tables[0].Rows[0][0].ToString() + " " + objDocumentDetail.ObjectDataSet.Tables[1].Rows[0][0].ToString();
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("DocumentDetailDAO.cs : SelectRecordById() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objDocumentDetail.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("DocumentDetailDAO.cs : SelectRecordById() is ended with error.");
			}
			return objDocumentDetail;
		}
	}
}
