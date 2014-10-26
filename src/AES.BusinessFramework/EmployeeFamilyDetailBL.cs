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
	public class EmployeeFamilyDetailBL
	{
		private EmployeeFamilyDetailDAO objEmployeeFamilyDetailDAO = null;
        EmployeeDetail objEmployeeDetail = null;
        EmployeeDetailBL objEmployeeDetailBL = null;       
        LicenceDetailBL objLicenceDetailBL = null;       
        ImmigrationDetailBL objImmigrationDetailBL = null;
        private const string strEmployeeFamilyDetailRelationKey = "Employee_Id";
        private const string strLicenceDetailRelationKey = "Member_Id";
        private const string strImmigrationDetailRelationKey = "Member_Id";

		public EmployeeFamilyDetail SelectEmployeeFamilyDetail(EmployeeFamilyDetail objEmployeeFamilyDetail)
		{
			objEmployeeFamilyDetailDAO= new EmployeeFamilyDetailDAO();
			objEmployeeFamilyDetail = objEmployeeFamilyDetailDAO.SelectEmployeeFamilyDetail(objEmployeeFamilyDetail);
			return objEmployeeFamilyDetail;
		}

        public EmployeeFamilyDetail SubmitEmployeeFamilyDetailData(EmployeeFamilyDetail objEmployeeFamilyDetail, LicenceDetail objLicenceDetail, ImmigrationDetail objImmigrationDetail)
		{
            objEmployeeFamilyDetailDAO = new EmployeeFamilyDetailDAO();
            objLicenceDetailBL = new LicenceDetailBL();
            objImmigrationDetailBL = new ImmigrationDetailBL();

            objEmployeeFamilyDetail.ObjectDataSet = DataUtility.UpdateDataColumnWithPrimaryKey(
                           objEmployeeFamilyDetail.ObjectDataSet.Tables[0], strEmployeeFamilyDetailRelationKey, objEmployeeFamilyDetail.EmployeeObject.EmployeeId).DataSet;
            objLicenceDetail.ObjectDataSet = DataUtility.UpdateDataColumnWithPrimaryKey(
                           objLicenceDetail.ObjectDataSet.Tables[0], strLicenceDetailRelationKey, objLicenceDetail.MemberObject.EmployeeId).DataSet;
            objImmigrationDetail.ObjectDataSet = DataUtility.UpdateDataColumnWithPrimaryKey(
                              objImmigrationDetail.ObjectDataSet.Tables[0], strImmigrationDetailRelationKey, objImmigrationDetail.MemberObject.EmployeeId).DataSet;

            using (TransactionScope objTransactionScope = new TransactionScope())
            {
                objEmployeeFamilyDetail = objEmployeeFamilyDetailDAO.SubmitEmployeeFamilyDetailData(objEmployeeFamilyDetail);
                if (objEmployeeFamilyDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    return objEmployeeFamilyDetail;
                }
                objLicenceDetail = objLicenceDetailBL.SubmitLicenceDetailData(objLicenceDetail);
                if (objLicenceDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    objEmployeeFamilyDetail.DbOperationStatus = objLicenceDetail.DbOperationStatus;
                    return objEmployeeFamilyDetail;
                }
                objImmigrationDetail = objImmigrationDetailBL.SubmitImmigrationDetailData(objImmigrationDetail);
                if (objImmigrationDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    objEmployeeFamilyDetail.DbOperationStatus = objLicenceDetail.DbOperationStatus;
                    return objEmployeeFamilyDetail;
                }

                objEmployeeDetail = objEmployeeFamilyDetail.EmployeeObject;
                objEmployeeDetailBL = new EmployeeDetailBL();
                objEmployeeDetail = objEmployeeDetailBL.UpdateEmployeeVersion(objEmployeeDetail);
                if (objEmployeeDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    objEmployeeFamilyDetail.DbOperationStatus = objEmployeeDetail.DbOperationStatus;
                    return objEmployeeFamilyDetail;
                }
                objTransactionScope.Complete();
            }
            return objEmployeeFamilyDetail;
		}

	}
}
