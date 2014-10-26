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
	public class FeeCollectionDetailBL
	{
		private FeeCollectionDetailDAO objFeeCollectionDetailDAO = null;

		public FeeCollectionDetail SelectFeeCollectionDetail(FeeCollectionDetail objFeeCollectionDetail)
		{
			objFeeCollectionDetailDAO= new FeeCollectionDetailDAO();
			objFeeCollectionDetail = objFeeCollectionDetailDAO.SelectFeeCollectionDetail(objFeeCollectionDetail);
			return objFeeCollectionDetail;
		}

		public FeeCollectionDetail InsertFeeCollectionDetail(FeeCollectionDetail objFeeCollectionDetail)
		{
			objFeeCollectionDetailDAO= new FeeCollectionDetailDAO();
			objFeeCollectionDetail = objFeeCollectionDetailDAO.InsertFeeCollectionDetail(objFeeCollectionDetail);
			return objFeeCollectionDetail;
		}

		public FeeCollectionDetail UpdateFeeCollectionDetail(FeeCollectionDetail objFeeCollectionDetail)
		{
			objFeeCollectionDetailDAO= new FeeCollectionDetailDAO();
			objFeeCollectionDetail = objFeeCollectionDetailDAO.UpdateFeeCollectionDetail(objFeeCollectionDetail);
			return objFeeCollectionDetail;
		}

		public FeeCollectionDetail ActivateDeactivateFeeCollectionDetail(FeeCollectionDetail objFeeCollectionDetail)
		{
			objFeeCollectionDetailDAO= new FeeCollectionDetailDAO();
			objFeeCollectionDetail = objFeeCollectionDetailDAO.ActivateDeactivateFeeCollectionDetail(objFeeCollectionDetail);
			return objFeeCollectionDetail;
		}

		public FeeCollectionDetail SelectRecordById(FeeCollectionDetail objFeeCollectionDetail)
		{
			objFeeCollectionDetailDAO = new FeeCollectionDetailDAO();
			objFeeCollectionDetail = objFeeCollectionDetailDAO.SelectRecordById(objFeeCollectionDetail);
			if (!Convert.ToBoolean(objFeeCollectionDetail.IsRecordChanged)
					&& objFeeCollectionDetail.DbOperationStatus==CommonConstant.SUCCEED)
			{
				objFeeCollectionDetail.ConvertToObjectFromDataset(1);
			}
			return objFeeCollectionDetail ;
		}
	}
}
