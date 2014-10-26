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
	public class FeeScheduleDetailBL
	{
		private FeeScheduleDetailDAO objFeeScheduleDetailDAO = null;

		public FeeScheduleDetail SelectFeeScheduleDetail(FeeScheduleDetail objFeeScheduleDetail)
		{
			objFeeScheduleDetailDAO= new FeeScheduleDetailDAO();
			objFeeScheduleDetail = objFeeScheduleDetailDAO.SelectFeeScheduleDetail(objFeeScheduleDetail);
			return objFeeScheduleDetail;
		}

        public FeeScheduleDetail SelectFeeScheduleDetailData(FeeScheduleDetail objFeeScheduleDetail)
        {
            objFeeScheduleDetailDAO = new FeeScheduleDetailDAO();
            objFeeScheduleDetail = objFeeScheduleDetailDAO.SelectFeeScheduleDetailData(objFeeScheduleDetail);
            return objFeeScheduleDetail;
        }

		public FeeScheduleDetail SubmitFeeScheduleDetailData(FeeScheduleDetail objFeeScheduleDetail)
		{
			objFeeScheduleDetailDAO= new FeeScheduleDetailDAO();
			objFeeScheduleDetail = objFeeScheduleDetailDAO.SubmitFeeScheduleDetailData(objFeeScheduleDetail);
			return objFeeScheduleDetail;
		}

	}
}
