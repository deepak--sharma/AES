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
	public class ActivityScheduleDetailBL
	{
		private ActivityScheduleDetailDAO objActivityScheduleDetailDAO = null;

		public ActivityScheduleDetail SelectActivityScheduleDetail(ActivityScheduleDetail objActivityScheduleDetail)
		{
			objActivityScheduleDetailDAO= new ActivityScheduleDetailDAO();
			objActivityScheduleDetail = objActivityScheduleDetailDAO.SelectActivityScheduleDetail(objActivityScheduleDetail);
			return objActivityScheduleDetail;
		}

		public ActivityScheduleDetail InsertActivityScheduleDetail(ActivityScheduleDetail objActivityScheduleDetail)
		{
			objActivityScheduleDetailDAO= new ActivityScheduleDetailDAO();
			objActivityScheduleDetail = objActivityScheduleDetailDAO.InsertActivityScheduleDetail(objActivityScheduleDetail);
			return objActivityScheduleDetail;
		}

		public ActivityScheduleDetail UpdateActivityScheduleDetail(ActivityScheduleDetail objActivityScheduleDetail)
		{
			objActivityScheduleDetailDAO= new ActivityScheduleDetailDAO();
			objActivityScheduleDetail = objActivityScheduleDetailDAO.UpdateActivityScheduleDetail(objActivityScheduleDetail);
			return objActivityScheduleDetail;
		}

		public ActivityScheduleDetail ActivateDeactivateActivityScheduleDetail(ActivityScheduleDetail objActivityScheduleDetail)
		{
			objActivityScheduleDetailDAO= new ActivityScheduleDetailDAO();
			objActivityScheduleDetail = objActivityScheduleDetailDAO.ActivateDeactivateActivityScheduleDetail(objActivityScheduleDetail);
			return objActivityScheduleDetail;
		}

		public ActivityScheduleDetail SelectRecordById(ActivityScheduleDetail objActivityScheduleDetail)
		{
			objActivityScheduleDetailDAO = new ActivityScheduleDetailDAO();
			objActivityScheduleDetail = objActivityScheduleDetailDAO.SelectRecordById(objActivityScheduleDetail);
			if (!Convert.ToBoolean(objActivityScheduleDetail.IsRecordChanged)
					&& objActivityScheduleDetail.DbOperationStatus==CommonConstant.SUCCEED)
			{
				objActivityScheduleDetail.ConvertToObjectFromDataset(1);
			}
			return objActivityScheduleDetail ;
		}
	}
}
