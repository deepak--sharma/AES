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
	public class FeeStructureDetailBL
	{
		private FeeStructureDetailDAO objFeeStructureDetailDAO = null;
		private FeeSetup objFeeSetup = null;
		private FeeSetupBL objFeeSetupBL = null;
		private const string strFeeSetupRelationKey = "Fee_Structure_Detail_Id";

		public FeeStructureDetail SelectFeeStructureDetail(FeeStructureDetail objFeeStructureDetail)
		{
			objFeeStructureDetailDAO= new FeeStructureDetailDAO();
			objFeeStructureDetail = objFeeStructureDetailDAO.SelectFeeStructureDetail(objFeeStructureDetail);
			return objFeeStructureDetail;
		}

		public FeeStructureDetail InsertFeeStructureDetail(FeeStructureDetail objFeeStructureDetail)
		{
			objFeeStructureDetailDAO= new FeeStructureDetailDAO();
			objFeeSetup= new FeeSetup();
			objFeeSetupBL= new FeeSetupBL();

			using (TransactionScope objTransactionScope = new TransactionScope())
			{
				objFeeStructureDetail = objFeeStructureDetailDAO.InsertFeeStructureDetail(objFeeStructureDetail);
				if (objFeeStructureDetail.DbOperationStatus != CommonConstant.SUCCEED)
				{
					return objFeeStructureDetail;
				}

				objFeeSetup.ObjectDataSet = DataUtility.UpdateDataColumnWithPrimaryKey(
							objFeeStructureDetail.FeeSetupData.Tables[0], strFeeSetupRelationKey, objFeeStructureDetail.FeeStructureDetailId).DataSet;

                objFeeSetup.FeeStructureDetailObject = objFeeStructureDetail;
				objFeeSetupBL.SubmitFeeSetupData(objFeeSetup);

				if (objFeeSetup.DbOperationStatus != CommonConstant.SUCCEED)
				{
					objFeeStructureDetail.DbOperationStatus = CommonConstant.FAIL;
					return objFeeStructureDetail;
				}
				objTransactionScope.Complete();
			}
			return objFeeStructureDetail;
		}

		public FeeStructureDetail UpdateFeeStructureDetail(FeeStructureDetail objFeeStructureDetail)
		{
			objFeeStructureDetailDAO= new FeeStructureDetailDAO();
			objFeeSetup= new FeeSetup();
			objFeeSetupBL= new FeeSetupBL();

			using (TransactionScope objTransactionScope = new TransactionScope())
			{
				objFeeStructureDetail = objFeeStructureDetailDAO.UpdateFeeStructureDetail(objFeeStructureDetail);
				if (objFeeStructureDetail.DbOperationStatus != CommonConstant.SUCCEED)
				{
					return objFeeStructureDetail;
				}

				objFeeSetup.ObjectDataSet = DataUtility.UpdateDataColumnWithPrimaryKey(
							objFeeStructureDetail.FeeSetupData.Tables[0], strFeeSetupRelationKey, objFeeStructureDetail.FeeStructureDetailId).DataSet;

                objFeeSetup.FeeStructureDetailObject = objFeeStructureDetail;
				objFeeSetupBL.SubmitFeeSetupData(objFeeSetup);

				if (objFeeSetup.DbOperationStatus != CommonConstant.SUCCEED)
				{
					objFeeStructureDetail.DbOperationStatus = CommonConstant.FAIL;
					return objFeeStructureDetail;
				}
				objTransactionScope.Complete();
			}
			return objFeeStructureDetail;
		}

		public FeeStructureDetail ActivateDeactivateFeeStructureDetail(FeeStructureDetail objFeeStructureDetail)
		{
			objFeeStructureDetailDAO= new FeeStructureDetailDAO();
			objFeeStructureDetail = objFeeStructureDetailDAO.ActivateDeactivateFeeStructureDetail(objFeeStructureDetail);
			return objFeeStructureDetail;
		}

		public FeeStructureDetail SelectRecordById(FeeStructureDetail objFeeStructureDetail)
		{
			objFeeStructureDetailDAO = new FeeStructureDetailDAO();
			objFeeStructureDetail = objFeeStructureDetailDAO.SelectRecordById(objFeeStructureDetail);
			if (!Convert.ToBoolean(objFeeStructureDetail.IsRecordChanged)
					&& objFeeStructureDetail.DbOperationStatus==CommonConstant.SUCCEED)
			{
				objFeeStructureDetail.ConvertToObjectFromDataset(1);
			}
			return objFeeStructureDetail ;
		}
	}
}
