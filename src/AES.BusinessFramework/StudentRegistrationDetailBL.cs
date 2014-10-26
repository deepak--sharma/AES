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
    public class StudentRegistrationDetailBL
    {
        private StudentRegistrationDetailDAO objStudentRegistrationDetailDAO = null;
        private CandidateDetail objCandidateDetail = null;
        private CandidateDetailBL objCandidateDetailBL = null;

        public StudentRegistrationDetail SearchStudentRegistrationDetail(StudentRegistrationDetail objStudentRegistrationDetail)
        {
            objStudentRegistrationDetailDAO = new StudentRegistrationDetailDAO();
            objStudentRegistrationDetail = objStudentRegistrationDetailDAO.SearchStudentRegistrationDetail(objStudentRegistrationDetail);
            return objStudentRegistrationDetail;
        }

        public StudentRegistrationDetail SelectStudentRegistrationDetail(StudentRegistrationDetail objStudentRegistrationDetail)
        {
            objStudentRegistrationDetailDAO = new StudentRegistrationDetailDAO();
            objStudentRegistrationDetail = objStudentRegistrationDetailDAO.SelectStudentRegistrationDetail(objStudentRegistrationDetail);
            return objStudentRegistrationDetail;
        }

        public StudentRegistrationDetail InsertStudentRegistrationDetail(StudentRegistrationDetail objStudentRegistrationDetail)
        {
            objStudentRegistrationDetailDAO = new StudentRegistrationDetailDAO();
            objCandidateDetailBL = new CandidateDetailBL();

            using (TransactionScope objTransactionScope = new TransactionScope())
            {
                objCandidateDetail = objCandidateDetailBL.InsertCandidateDetail(objStudentRegistrationDetail.CandidateObject);
                if (objCandidateDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    objStudentRegistrationDetail.DbOperationStatus = objCandidateDetail.DbOperationStatus;
                    return objStudentRegistrationDetail;
                }

                objStudentRegistrationDetail = objStudentRegistrationDetailDAO.InsertStudentRegistrationDetail(objStudentRegistrationDetail);
                if (objStudentRegistrationDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    return objStudentRegistrationDetail;
                }
                objTransactionScope.Complete();
            }
            return objStudentRegistrationDetail;
        }

        public StudentRegistrationDetail UpdateStudentRegistrationDetail(StudentRegistrationDetail objStudentRegistrationDetail)
        {
            objStudentRegistrationDetailDAO = new StudentRegistrationDetailDAO();
            objCandidateDetailBL = new CandidateDetailBL();

            using (TransactionScope objTransactionScope = new TransactionScope())
            {
                if (objStudentRegistrationDetail.CandidateObject.CandidateId != null)
                {
                    objCandidateDetail = objCandidateDetailBL.UpdateCandidateDetail(objStudentRegistrationDetail.CandidateObject);
                }
                else
                {
                    objCandidateDetail = objCandidateDetailBL.InsertCandidateDetail(objStudentRegistrationDetail.CandidateObject);
                }

                if (objCandidateDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    objStudentRegistrationDetail.DbOperationStatus = objCandidateDetail.DbOperationStatus;
                    return objStudentRegistrationDetail;
                }

                objStudentRegistrationDetail = objStudentRegistrationDetailDAO.UpdateStudentRegistrationDetail(objStudentRegistrationDetail);
                if (objStudentRegistrationDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    return objStudentRegistrationDetail;
                }
                objTransactionScope.Complete();
            }
            return objStudentRegistrationDetail;
        }

        public StudentRegistrationDetail EditStudentRegistrationStatus(Dictionary<int, int> dicRegistrationId, int registrationStatusId, string comment, string modifiedBy, DateTime modifiedOn)
        {
            objStudentRegistrationDetailDAO = new StudentRegistrationDetailDAO();
            StudentRegistrationDetail objStudentRegistrationDetail = null;

            //using (TransactionScope objTransactionScope = new TransactionScope())
            //{
                foreach (KeyValuePair<int, int> item in dicRegistrationId)
                {
                    objStudentRegistrationDetail = objStudentRegistrationDetailDAO.EditStudentRegistrationStatus(item.Key, item.Value, registrationStatusId,comment, modifiedBy, modifiedOn);
                    if (objStudentRegistrationDetail.DbOperationStatus != CommonConstant.SUCCEED)
                    {
                        return objStudentRegistrationDetail;
                    }
                }

            //    objTransactionScope.Complete();
            //}
            return objStudentRegistrationDetail;
        }

        public StudentRegistrationDetail ActivateDeactivateStudentRegistrationDetail(StudentRegistrationDetail objStudentRegistrationDetail)
        {
            objStudentRegistrationDetailDAO = new StudentRegistrationDetailDAO();
            objStudentRegistrationDetail = objStudentRegistrationDetailDAO.ActivateDeactivateStudentRegistrationDetail(objStudentRegistrationDetail);
            return objStudentRegistrationDetail;
        }

        public StudentRegistrationDetail SelectRecordById(StudentRegistrationDetail objStudentRegistrationDetail)
        {
            objStudentRegistrationDetailDAO = new StudentRegistrationDetailDAO();
            objStudentRegistrationDetail = objStudentRegistrationDetailDAO.SelectRecordById(objStudentRegistrationDetail);
            if (!Convert.ToBoolean(objStudentRegistrationDetail.IsRecordChanged)
                    && objStudentRegistrationDetail.DbOperationStatus == CommonConstant.SUCCEED)
            {
                objStudentRegistrationDetail.ConvertToObjectFromDataset(1);

                objStudentRegistrationDetail.RegistrationObject.RegistrationName =
                    objStudentRegistrationDetail.ObjectDataSet.Tables[1].Rows[0]["REGISTRATION_NAME"].ToString();
                if (objStudentRegistrationDetail.CandidateObject.CandidateId != null)
                {
                    objCandidateDetail = objStudentRegistrationDetail.CandidateObject;
                    objCandidateDetailBL = new CandidateDetailBL();
                    objCandidateDetail = objCandidateDetailBL.GetRecordById(objCandidateDetail);
                    objStudentRegistrationDetail.DbOperationStatus = objCandidateDetail.DbOperationStatus;
                }
            }
            return objStudentRegistrationDetail;
        }

        //For Wizard Control
        public StudentRegistrationDetail SaveStudentRegistrationDetail(StudentRegistrationDetail objStudentRegistrationDetail)
        {
            objStudentRegistrationDetailDAO = new StudentRegistrationDetailDAO();
            objCandidateDetailBL = new CandidateDetailBL();

            using (TransactionScope objTransactionScope = new TransactionScope())
            {
                objCandidateDetail = objCandidateDetailBL.SaveCandidateDetail(objStudentRegistrationDetail.CandidateObject);
                if (objCandidateDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    objStudentRegistrationDetail.DbOperationStatus = objCandidateDetail.DbOperationStatus;
                    return objStudentRegistrationDetail;
                }

                objStudentRegistrationDetail = objStudentRegistrationDetailDAO.InsertStudentRegistrationDetail(objStudentRegistrationDetail);
                if (objStudentRegistrationDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    return objStudentRegistrationDetail;
                }
                objTransactionScope.Complete();
            }
            return objStudentRegistrationDetail;
        }
        public StudentRegistrationDetail EditStudentRegistrationDetail(StudentRegistrationDetail objStudentRegistrationDetail)
        {
            objStudentRegistrationDetailDAO = new StudentRegistrationDetailDAO();
            objCandidateDetailBL = new CandidateDetailBL();

            using (TransactionScope objTransactionScope = new TransactionScope())
            {
                objCandidateDetail = objCandidateDetailBL.EditCandidateDetail(objStudentRegistrationDetail.CandidateObject);
                if (objCandidateDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    objStudentRegistrationDetail.DbOperationStatus = objCandidateDetail.DbOperationStatus;
                    return objStudentRegistrationDetail;
                }

                objStudentRegistrationDetail = objStudentRegistrationDetailDAO.UpdateStudentRegistrationDetail(objStudentRegistrationDetail);
                if (objStudentRegistrationDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    return objStudentRegistrationDetail;
                }
                objTransactionScope.Complete();
            }
            return objStudentRegistrationDetail;
        }
    }
}
