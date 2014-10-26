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
    public class GuardianDetailBL
    {
        private GuardianDetailDAO objGuardianDetailDAO = null;

        public GuardianDetail SelectGuardianDetail(GuardianDetail objGuardianDetail)
        {
            objGuardianDetailDAO = new GuardianDetailDAO();
            objGuardianDetail = objGuardianDetailDAO.SelectGuardianDetail(objGuardianDetail);
            return objGuardianDetail;
        }

        public GuardianDetail InsertGuardianDetail(GuardianDetail objGuardianDetail)
        {
            objGuardianDetailDAO = new GuardianDetailDAO();
            objGuardianDetail = objGuardianDetailDAO.InsertGuardianDetail(objGuardianDetail);
            return objGuardianDetail;
        }

        public GuardianDetail UpdateGuardianDetail(GuardianDetail objGuardianDetail)
        {
            objGuardianDetailDAO = new GuardianDetailDAO();
            objGuardianDetail = objGuardianDetailDAO.UpdateGuardianDetail(objGuardianDetail);
            return objGuardianDetail;
        }

        public GuardianDetail SelectRecordById(GuardianDetail objGuardianDetail)
        {
            objGuardianDetailDAO = new GuardianDetailDAO();
            objGuardianDetail = objGuardianDetailDAO.SelectRecordById(objGuardianDetail);
            if (!Convert.ToBoolean(objGuardianDetail.IsRecordChanged)
                    && objGuardianDetail.DbOperationStatus == CommonConstant.SUCCEED)
            {
                objGuardianDetail.ConvertToObjectFromDataset(1);
            }
            return objGuardianDetail;
        }

        public GuardianDetail EditGuardianDetail(GuardianDetail _objFatherDetail, GuardianDetail _objMotherDetail, GuardianDetail _objGuardianDetail)
        {
            objGuardianDetailDAO = new GuardianDetailDAO();
            using (TransactionScope objTransactionScope = new TransactionScope())
            {
                _objFatherDetail = objGuardianDetailDAO.UpdateGuardianDetail(_objFatherDetail);
                if (_objFatherDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    _objGuardianDetail.DbOperationStatus = _objFatherDetail.DbOperationStatus;
                    return _objGuardianDetail;
                }

                _objMotherDetail = objGuardianDetailDAO.UpdateGuardianDetail(_objMotherDetail);
                if (_objMotherDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    _objGuardianDetail.DbOperationStatus = _objMotherDetail.DbOperationStatus;
                    return _objGuardianDetail;
                }

                _objGuardianDetail = objGuardianDetailDAO.UpdateGuardianDetail(_objGuardianDetail);
                if (_objGuardianDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    return _objGuardianDetail;
                }

                objTransactionScope.Complete();
            }
            return _objGuardianDetail;
        }
    }
}
