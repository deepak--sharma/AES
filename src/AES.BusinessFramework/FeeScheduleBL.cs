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
	public class FeeScheduleBL
	{
		private FeeScheduleDAO objFeeScheduleDAO = null;
		private FeeScheduleDetail objFeeScheduleDetail = null;
		private FeeScheduleDetailBL objFeeScheduleDetailBL = null;
		private const string strFeeScheduleDetailRelationKey = "Fee_Schedule_Id";

		public FeeSchedule SelectFeeSchedule(FeeSchedule objFeeSchedule)
		{
			objFeeScheduleDAO= new FeeScheduleDAO();
			objFeeSchedule = objFeeScheduleDAO.SelectFeeSchedule(objFeeSchedule);
			return objFeeSchedule;
		}

		public FeeSchedule InsertFeeSchedule(FeeSchedule objFeeSchedule)
		{
			objFeeScheduleDAO= new FeeScheduleDAO();
			objFeeScheduleDetail= new FeeScheduleDetail();
			objFeeScheduleDetailBL= new FeeScheduleDetailBL();

			using (TransactionScope objTransactionScope = new TransactionScope())
			{
				objFeeSchedule = objFeeScheduleDAO.InsertFeeSchedule(objFeeSchedule);
				if (objFeeSchedule.DbOperationStatus != CommonConstant.SUCCEED)
				{
					return objFeeSchedule;
				}

				objFeeScheduleDetail.ObjectDataSet = DataUtility.UpdateDataColumnWithPrimaryKey(
							objFeeSchedule.FeeScheduleDetailData.Tables[0], strFeeScheduleDetailRelationKey, objFeeSchedule.FeeScheduleId).DataSet;
                objFeeScheduleDetail.FeeScheduleObject = objFeeSchedule;

				objFeeScheduleDetailBL.SubmitFeeScheduleDetailData(objFeeScheduleDetail);

				if (objFeeScheduleDetail.DbOperationStatus != CommonConstant.SUCCEED)
				{
					objFeeSchedule.DbOperationStatus = CommonConstant.FAIL;
					return objFeeSchedule;
				}
				objTransactionScope.Complete();
			}
			return objFeeSchedule;
		}

		public FeeSchedule UpdateFeeSchedule(FeeSchedule objFeeSchedule)
		{
			objFeeScheduleDAO= new FeeScheduleDAO();
			objFeeScheduleDetail= new FeeScheduleDetail();
			objFeeScheduleDetailBL= new FeeScheduleDetailBL();

			using (TransactionScope objTransactionScope = new TransactionScope())
			{
				objFeeSchedule = objFeeScheduleDAO.UpdateFeeSchedule(objFeeSchedule);
				if (objFeeSchedule.DbOperationStatus != CommonConstant.SUCCEED)
				{
					return objFeeSchedule;
				}

				objFeeScheduleDetail.ObjectDataSet = DataUtility.UpdateDataColumnWithPrimaryKey(
							objFeeSchedule.FeeScheduleDetailData.Tables[0], strFeeScheduleDetailRelationKey, objFeeSchedule.FeeScheduleId).DataSet;
                objFeeScheduleDetail.FeeScheduleObject = objFeeSchedule;

				objFeeScheduleDetailBL.SubmitFeeScheduleDetailData(objFeeScheduleDetail);

				if (objFeeScheduleDetail.DbOperationStatus != CommonConstant.SUCCEED)
				{
					objFeeSchedule.DbOperationStatus = CommonConstant.FAIL;
					return objFeeSchedule;
				}
				objTransactionScope.Complete();
			}
			return objFeeSchedule;
		}

		public FeeSchedule ActivateDeactivateFeeSchedule(FeeSchedule objFeeSchedule)
		{
			objFeeScheduleDAO= new FeeScheduleDAO();
			objFeeSchedule = objFeeScheduleDAO.ActivateDeactivateFeeSchedule(objFeeSchedule);
			return objFeeSchedule;
		}

		public FeeSchedule SelectRecordById(FeeSchedule objFeeSchedule)
		{
			objFeeScheduleDAO = new FeeScheduleDAO();
			objFeeSchedule = objFeeScheduleDAO.SelectRecordById(objFeeSchedule);
			if (!Convert.ToBoolean(objFeeSchedule.IsRecordChanged)
					&& objFeeSchedule.DbOperationStatus==CommonConstant.SUCCEED)
			{
				objFeeSchedule.ConvertToObjectFromDataset(1);
			}
			return objFeeSchedule ;
		}
	}
}
