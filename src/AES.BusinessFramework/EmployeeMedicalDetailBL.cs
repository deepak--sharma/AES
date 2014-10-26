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
	public class EmployeeMedicalDetailBL
	{
		private EmployeeMedicalDetailDAO objEmployeeMedicalDetailDAO = null;
        EmployeeDetail objEmployeeDetail = null;
        EmployeeDetailBL objEmployeeDetailBL = null;
        EmployeeMedicalDetail objEmployeeMedicalDetail = null;

		public EmployeeMedicalDetail SelectEmployeeMedicalDetail(EmployeeMedicalDetail objEmployeeMedicalDetail)
		{
			objEmployeeMedicalDetailDAO= new EmployeeMedicalDetailDAO();
			objEmployeeMedicalDetail = objEmployeeMedicalDetailDAO.SelectEmployeeMedicalDetail(objEmployeeMedicalDetail);
			return objEmployeeMedicalDetail;
		}

        public EmployeeMedicalDetail SubmitEmployeeMedicalDetailData(List<EmployeeMedicalDetail> objEmployeeMedicalDetailList)
        {
            objEmployeeMedicalDetailDAO = new EmployeeMedicalDetailDAO();
            using (TransactionScope objTransactionScope = new TransactionScope())
            {
                foreach (EmployeeMedicalDetail _objEmployeeMedicalDetail in objEmployeeMedicalDetailList)
                {
                    objEmployeeMedicalDetail = objEmployeeMedicalDetailDAO.SubmitEmployeeMedicalDetailData(_objEmployeeMedicalDetail);
                    if (objEmployeeMedicalDetail.DbOperationStatus != CommonConstant.SUCCEED)
                    {
                        return objEmployeeMedicalDetail;
                    }
                }
                objEmployeeDetail = objEmployeeMedicalDetailList[0].EmployeeObject;
                objEmployeeDetailBL = new EmployeeDetailBL();
                objEmployeeDetail = objEmployeeDetailBL.UpdateEmployeeVersion(objEmployeeDetail);
                if (objEmployeeDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    objEmployeeMedicalDetail.DbOperationStatus = objEmployeeDetail.DbOperationStatus;
                    return objEmployeeMedicalDetail;
                }

                objTransactionScope.Complete();
            }
            return objEmployeeMedicalDetail;
        }

	}
}
