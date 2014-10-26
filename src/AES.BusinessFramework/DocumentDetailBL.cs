using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;
using AES.SolutionFramework;
using AES.DataFramework;
using AES.ObjectFramework;

namespace AES.BusinessFramework
{
	public class DocumentDetailBL
	{
		private DocumentDetailDAO objDocumentDetailDAO = null;

		public DocumentDetail SelectDocumentDetail(DocumentDetail objDocumentDetail)
		{
			objDocumentDetailDAO= new DocumentDetailDAO();
			objDocumentDetail = objDocumentDetailDAO.SelectDocumentDetail(objDocumentDetail);
			return objDocumentDetail;
		}

		public DocumentDetail InsertDocumentDetail(DocumentDetail objDocumentDetail)
		{
			objDocumentDetailDAO= new DocumentDetailDAO();
			objDocumentDetail = objDocumentDetailDAO.InsertDocumentDetail(objDocumentDetail);
			return objDocumentDetail;
		}

		public DocumentDetail UpdateDocumentDetail(DocumentDetail objDocumentDetail)
		{
			objDocumentDetailDAO= new DocumentDetailDAO();
			objDocumentDetail = objDocumentDetailDAO.UpdateDocumentDetail(objDocumentDetail);
			return objDocumentDetail;
		}

		public DocumentDetail SelectRecordById(DocumentDetail objDocumentDetail)
		{
			objDocumentDetailDAO = new DocumentDetailDAO();
			objDocumentDetail = objDocumentDetailDAO.SelectRecordById(objDocumentDetail);
			if (!Convert.ToBoolean(objDocumentDetail.IsRecordChanged)
					&& objDocumentDetail.DbOperationStatus==CommonConstant.SUCCEED)
			{
				objDocumentDetail.ConvertToObjectFromDataset(1);
			}
			return objDocumentDetail ;
		}
	}
}
