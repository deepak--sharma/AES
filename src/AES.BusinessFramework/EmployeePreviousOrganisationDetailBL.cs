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
	public class EmployeePreviousOrganisationDetailBL
	{
		private EmployeePreviousOrganisationDetailDAO objEmployeePreviousOrganisationDetailDAO = null;
        EmployeeDetail objEmployeeDetail = null;
        EmployeeDetailBL objEmployeeDetailBL = null;
        private const string strEmployeePreviousOrganisationDetailRelationKey = "Employee_Id";

		public EmployeePreviousOrganisationDetail SelectEmployeePreviousOrganisationDetail(EmployeePreviousOrganisationDetail objEmployeePreviousOrganisationDetail)
		{
			objEmployeePreviousOrganisationDetailDAO= new EmployeePreviousOrganisationDetailDAO();
			objEmployeePreviousOrganisationDetail = objEmployeePreviousOrganisationDetailDAO.SelectEmployeePreviousOrganisationDetail(objEmployeePreviousOrganisationDetail);
			return objEmployeePreviousOrganisationDetail;
		}

		public EmployeePreviousOrganisationDetail SubmitEmployeePreviousOrganisationDetailData(EmployeePreviousOrganisationDetail objEmployeePreviousOrganisationDetail)
		{
            objEmployeePreviousOrganisationDetailDAO = new EmployeePreviousOrganisationDetailDAO();
            objEmployeePreviousOrganisationDetail.ObjectDataSet = DataUtility.UpdateDataColumnWithPrimaryKey(
                           objEmployeePreviousOrganisationDetail.ObjectDataSet.Tables[0], strEmployeePreviousOrganisationDetailRelationKey, objEmployeePreviousOrganisationDetail.EmployeeObject.EmployeeId).DataSet;

            using (TransactionScope objTransactionScope = new TransactionScope())
            {
                objEmployeePreviousOrganisationDetail = objEmployeePreviousOrganisationDetailDAO.SubmitEmployeePreviousOrganisationDetailData(objEmployeePreviousOrganisationDetail);
                if (objEmployeePreviousOrganisationDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    return objEmployeePreviousOrganisationDetail;
                }
                objEmployeeDetail = objEmployeePreviousOrganisationDetail.EmployeeObject;
                objEmployeeDetailBL = new EmployeeDetailBL();
                objEmployeeDetail = objEmployeeDetailBL.UpdateEmployeeVersion(objEmployeeDetail);
                if (objEmployeeDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    objEmployeePreviousOrganisationDetail.DbOperationStatus = objEmployeeDetail.DbOperationStatus;
                    return objEmployeePreviousOrganisationDetail;
                }
                objTransactionScope.Complete();
            }
            return objEmployeePreviousOrganisationDetail;
            		
		}

	}
}
