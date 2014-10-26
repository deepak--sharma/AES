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
	public class EmployeeJoiningDetailBL
	{
		private EmployeeJoiningDetailDAO objEmployeeJoiningDetailDAO = null;
        EmployeeDetail objEmployeeDetail = null;
        EmployeeDetailBL objEmployeeDetailBL = null;
        EmployeeJoiningDetail objEmployeeJoiningDetail=null;

		public EmployeeJoiningDetail SelectEmployeeJoiningDetail(EmployeeJoiningDetail objEmployeeJoiningDetail)
		{
			objEmployeeJoiningDetailDAO= new EmployeeJoiningDetailDAO();
			objEmployeeJoiningDetail = objEmployeeJoiningDetailDAO.SelectEmployeeJoiningDetail(objEmployeeJoiningDetail);
			return objEmployeeJoiningDetail;
		}

        public EmployeeJoiningDetail SubmitEmployeeJoiningDetailData(List<EmployeeJoiningDetail> objEmployeeJoiningDetailList)
		{
            objEmployeeJoiningDetailDAO = new EmployeeJoiningDetailDAO();
            using (TransactionScope objTransactionScope = new TransactionScope())
            {
                foreach (EmployeeJoiningDetail _objEmployeeJoiningDetail in objEmployeeJoiningDetailList)
                {
                    objEmployeeJoiningDetail = objEmployeeJoiningDetailDAO.SubmitEmployeeJoiningDetailData(_objEmployeeJoiningDetail);
                    if (objEmployeeJoiningDetail.DbOperationStatus != CommonConstant.SUCCEED)
                    {
                        return objEmployeeJoiningDetail;
                    }
                }
                objEmployeeDetail = objEmployeeJoiningDetailList[0].EmployeeObject;               
                objEmployeeDetailBL = new EmployeeDetailBL();
                objEmployeeDetail = objEmployeeDetailBL.UpdateEmployeeVersion(objEmployeeDetail);
                if (objEmployeeDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    objEmployeeJoiningDetail.DbOperationStatus = objEmployeeDetail.DbOperationStatus;
                    return objEmployeeJoiningDetail;
                }

                objTransactionScope.Complete();
            }
            return objEmployeeJoiningDetail;
		}

	}
}
