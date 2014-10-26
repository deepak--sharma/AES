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
	public class ReportingDetailBL
	{
		private ReportingDetailDAO objReportingDetailDAO = null;
        EmployeeDetail objEmployeeDetail = null;
        EmployeeDetailBL objEmployeeDetailBL = null;
        private string strReportingDetailRelationKey = "Employee_Id";

		public ReportingDetail SelectReportingDetail(ReportingDetail objReportingDetail)
		{
			objReportingDetailDAO= new ReportingDetailDAO();
			objReportingDetail = objReportingDetailDAO.SelectReportingDetail(objReportingDetail);
			return objReportingDetail;
		}

        public ReportingDetail SubmitReportingDetailData(List<ReportingDetail> objReportingDetailList)
		{
            objReportingDetailDAO = new ReportingDetailDAO();
            ReportingDetail objReportingDetail = null;
            using (TransactionScope objTransactionScope = new TransactionScope())
            {
                foreach (ReportingDetail _objReportingDetail in objReportingDetailList)
                {
                    objReportingDetail = objReportingDetailDAO.SubmitReportingDetailData(_objReportingDetail);
                    if (objReportingDetail.DbOperationStatus != CommonConstant.SUCCEED)
                    {
                        return objReportingDetail;
                    }
                }

                objEmployeeDetail = objReportingDetailList[0].EmployeeObject;
                objEmployeeDetailBL = new EmployeeDetailBL();
                objEmployeeDetail = objEmployeeDetailBL.UpdateEmployeeVersion(objEmployeeDetail);
                if (objEmployeeDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    objReportingDetail.DbOperationStatus = objEmployeeDetail.DbOperationStatus;
                    return objReportingDetail;
                }
                objTransactionScope.Complete();
            }            
			return objReportingDetail;
		}

	}
}
