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
	public class ActivityDetailBL
	{
		private ActivityDetailDAO objActivityDetailDAO = null;
		private StudentAttendance objStudentAttendance = null;
		private StudentAttendanceBL objStudentAttendanceBL = null;
		private const string strStudentAttendanceRelationKey = "Activity_Detail_Id";

		public ActivityDetail SelectActivityDetail(ActivityDetail objActivityDetail)
		{
			objActivityDetailDAO= new ActivityDetailDAO();
			objActivityDetail = objActivityDetailDAO.SelectActivityDetail(objActivityDetail);
			return objActivityDetail;
		}

		public ActivityDetail InsertActivityDetail(ActivityDetail objActivityDetail)
		{
			objActivityDetailDAO= new ActivityDetailDAO();
			objStudentAttendance= new StudentAttendance();
			objStudentAttendanceBL= new StudentAttendanceBL();

			using (TransactionScope objTransactionScope = new TransactionScope())
			{
				objActivityDetail = objActivityDetailDAO.InsertActivityDetail(objActivityDetail);
				if (objActivityDetail.DbOperationStatus != CommonConstant.SUCCEED)
				{
					return objActivityDetail;
				}

				objStudentAttendance.ObjectDataSet = DataUtility.UpdateDataColumnWithPrimaryKey(
							objActivityDetail.StudentAttendanceData.Tables[0], strStudentAttendanceRelationKey, objActivityDetail.ActivityDetailId).DataSet;

				objStudentAttendanceBL.SubmitStudentAttendanceData(objStudentAttendance);

				if (objStudentAttendance.DbOperationStatus != CommonConstant.SUCCEED)
				{
					objActivityDetail.DbOperationStatus = CommonConstant.FAIL;
					return objActivityDetail;
				}
				objTransactionScope.Complete();
			}
			return objActivityDetail;
		}

		public ActivityDetail UpdateActivityDetail(ActivityDetail objActivityDetail)
		{
			objActivityDetailDAO= new ActivityDetailDAO();
			objStudentAttendance= new StudentAttendance();
			objStudentAttendanceBL= new StudentAttendanceBL();

			using (TransactionScope objTransactionScope = new TransactionScope())
			{
				objActivityDetail = objActivityDetailDAO.UpdateActivityDetail(objActivityDetail);
				if (objActivityDetail.DbOperationStatus != CommonConstant.SUCCEED)
				{
					return objActivityDetail;
				}

				objStudentAttendance.ObjectDataSet = DataUtility.UpdateDataColumnWithPrimaryKey(
							objActivityDetail.StudentAttendanceData.Tables[0], strStudentAttendanceRelationKey, objActivityDetail.ActivityDetailId).DataSet;

				objStudentAttendanceBL.SubmitStudentAttendanceData(objStudentAttendance);

				if (objStudentAttendance.DbOperationStatus != CommonConstant.SUCCEED)
				{
					objActivityDetail.DbOperationStatus = CommonConstant.FAIL;
					return objActivityDetail;
				}
				objTransactionScope.Complete();
			}
			return objActivityDetail;
		}

		public ActivityDetail ActivateDeactivateActivityDetail(ActivityDetail objActivityDetail)
		{
			objActivityDetailDAO= new ActivityDetailDAO();
			objActivityDetail = objActivityDetailDAO.ActivateDeactivateActivityDetail(objActivityDetail);
			return objActivityDetail;
		}

		public ActivityDetail SelectRecordById(ActivityDetail objActivityDetail)
		{
			objActivityDetailDAO = new ActivityDetailDAO();
			objActivityDetail = objActivityDetailDAO.SelectRecordById(objActivityDetail);
			if (!Convert.ToBoolean(objActivityDetail.IsRecordChanged)
					&& objActivityDetail.DbOperationStatus==CommonConstant.SUCCEED)
			{
				objActivityDetail.ConvertToObjectFromDataset(1);
			}
			return objActivityDetail ;
		}
	}
}
