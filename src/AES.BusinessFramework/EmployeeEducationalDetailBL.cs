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
    public class EmployeeEducationalDetailBL
    {
        private EmployeeEducationalDetailDAO objEmployeeEducationalDetailDAO = null;
        EmployeeDetail objEmployeeDetail = null;
        EmployeeDetailBL objEmployeeDetailBL = null;
        private const string strEmployeeEducationalDetailRelationKey = "Employee_Id";

        public EmployeeEducationalDetail SelectEmployeeEducationalDetail(EmployeeEducationalDetail objEmployeeEducationalDetail)
        {
            objEmployeeEducationalDetailDAO = new EmployeeEducationalDetailDAO();
            objEmployeeEducationalDetail = objEmployeeEducationalDetailDAO.SelectEmployeeEducationalDetail(objEmployeeEducationalDetail);
            return objEmployeeEducationalDetail;
        }

        public EmployeeEducationalDetail SubmitEmployeeEducationalDetailData(EmployeeEducationalDetail objEmployeeEducationalDetail)
        {
            objEmployeeEducationalDetailDAO = new EmployeeEducationalDetailDAO();
            objEmployeeEducationalDetail.ObjectDataSet = DataUtility.UpdateDataColumnWithPrimaryKey(
                           objEmployeeEducationalDetail.ObjectDataSet.Tables[0], strEmployeeEducationalDetailRelationKey, objEmployeeEducationalDetail.EmployeeObject.EmployeeId).DataSet;

            using (TransactionScope objTransactionScope = new TransactionScope())
            {
                objEmployeeEducationalDetail = objEmployeeEducationalDetailDAO.SubmitEmployeeEducationalDetailData(objEmployeeEducationalDetail);
                if (objEmployeeEducationalDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    return objEmployeeEducationalDetail;
                }
                objEmployeeDetail = objEmployeeEducationalDetail.EmployeeObject;
                objEmployeeDetailBL = new EmployeeDetailBL();
                objEmployeeDetail = objEmployeeDetailBL.UpdateEmployeeVersion(objEmployeeDetail);
                if (objEmployeeDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    objEmployeeEducationalDetail.DbOperationStatus = objEmployeeDetail.DbOperationStatus;
                    return objEmployeeEducationalDetail;
                }
                objTransactionScope.Complete();
            }
            return objEmployeeEducationalDetail;
        }

    }
}
