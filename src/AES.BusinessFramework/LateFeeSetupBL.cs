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
	public class LateFeeSetupBL
	{
		private LateFeeSetupDAO objLateFeeSetupDAO = null;
		private LateFeeSetupDetail objLateFeeSetupDetail = null;
		private LateFeeSetupDetailBL objLateFeeSetupDetailBL = null;
		private const string strLateFeeSetupDetailRelationKey = "Late_Fee_Setup_Id";

		public LateFeeSetup SelectLateFeeSetup(LateFeeSetup objLateFeeSetup)
		{
			objLateFeeSetupDAO= new LateFeeSetupDAO();
			objLateFeeSetup = objLateFeeSetupDAO.SelectLateFeeSetup(objLateFeeSetup);
			return objLateFeeSetup;
		}

		public LateFeeSetup InsertLateFeeSetup(LateFeeSetup objLateFeeSetup)
		{
			objLateFeeSetupDAO= new LateFeeSetupDAO();
			objLateFeeSetupDetail= new LateFeeSetupDetail();
			objLateFeeSetupDetailBL= new LateFeeSetupDetailBL();

			using (TransactionScope objTransactionScope = new TransactionScope())
			{
				objLateFeeSetup = objLateFeeSetupDAO.InsertLateFeeSetup(objLateFeeSetup);
				if (objLateFeeSetup.DbOperationStatus != CommonConstant.SUCCEED)
				{
					return objLateFeeSetup;
				}

				objLateFeeSetupDetail.ObjectDataSet = DataUtility.UpdateDataColumnWithPrimaryKey(
							objLateFeeSetup.LateFeeSetupDetailData.Tables[0], strLateFeeSetupDetailRelationKey, objLateFeeSetup.LateFeeId).DataSet;

                objLateFeeSetupDetail.LateFeeSetupObject = objLateFeeSetup;
				objLateFeeSetupDetailBL.SubmitLateFeeSetupDetailData(objLateFeeSetupDetail);

				if (objLateFeeSetupDetail.DbOperationStatus != CommonConstant.SUCCEED)
				{
					objLateFeeSetup.DbOperationStatus = CommonConstant.FAIL;
					return objLateFeeSetup;
				}
				objTransactionScope.Complete();
			}
			return objLateFeeSetup;
		}

		public LateFeeSetup UpdateLateFeeSetup(LateFeeSetup objLateFeeSetup)
		{
			objLateFeeSetupDAO= new LateFeeSetupDAO();
			objLateFeeSetupDetail= new LateFeeSetupDetail();
			objLateFeeSetupDetailBL= new LateFeeSetupDetailBL();

			using (TransactionScope objTransactionScope = new TransactionScope())
			{
				objLateFeeSetup = objLateFeeSetupDAO.UpdateLateFeeSetup(objLateFeeSetup);
				if (objLateFeeSetup.DbOperationStatus != CommonConstant.SUCCEED)
				{
					return objLateFeeSetup;
				}

				objLateFeeSetupDetail.ObjectDataSet = DataUtility.UpdateDataColumnWithPrimaryKey(
							objLateFeeSetup.LateFeeSetupDetailData.Tables[0], strLateFeeSetupDetailRelationKey, objLateFeeSetup.LateFeeId).DataSet;

                objLateFeeSetupDetail.LateFeeSetupObject = objLateFeeSetup;
				objLateFeeSetupDetailBL.SubmitLateFeeSetupDetailData(objLateFeeSetupDetail);

				if (objLateFeeSetupDetail.DbOperationStatus != CommonConstant.SUCCEED)
				{
					objLateFeeSetup.DbOperationStatus = CommonConstant.FAIL;
					return objLateFeeSetup;
				}
				objTransactionScope.Complete();
			}
			return objLateFeeSetup;
		}

		public LateFeeSetup ActivateDeactivateLateFeeSetup(LateFeeSetup objLateFeeSetup)
		{
			objLateFeeSetupDAO= new LateFeeSetupDAO();
			objLateFeeSetup = objLateFeeSetupDAO.ActivateDeactivateLateFeeSetup(objLateFeeSetup);
			return objLateFeeSetup;
		}

		public LateFeeSetup SelectRecordById(LateFeeSetup objLateFeeSetup)
		{
			objLateFeeSetupDAO = new LateFeeSetupDAO();
			objLateFeeSetup = objLateFeeSetupDAO.SelectRecordById(objLateFeeSetup);
			if (!Convert.ToBoolean(objLateFeeSetup.IsRecordChanged)
					&& objLateFeeSetup.DbOperationStatus==CommonConstant.SUCCEED)
			{
				objLateFeeSetup.ConvertToObjectFromDataset(1);
			}
			return objLateFeeSetup ;
		}
	}
}
