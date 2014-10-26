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
    public class SiblingDetailBL
    {
        private SiblingDetailDAO objSiblingDetailDAO = null;

        public SiblingDetail SelectSiblingDetail(SiblingDetail objSiblingDetail)
        {
            objSiblingDetailDAO = new SiblingDetailDAO();
            objSiblingDetail = objSiblingDetailDAO.SelectSiblingDetail(objSiblingDetail);
            return objSiblingDetail;
        }

        public SiblingDetail SubmitSiblingDetailData(SiblingDetail objSiblingDetail)
        {
            objSiblingDetailDAO = new SiblingDetailDAO();
            objSiblingDetail = objSiblingDetailDAO.SubmitSiblingDetailData(objSiblingDetail);
            return objSiblingDetail;
        }

        // For Wizard Control
        public SiblingDetail SaveSiblingDetailData(SiblingDetail objSiblingDetail)
        {
            objSiblingDetailDAO = new SiblingDetailDAO();
            objSiblingDetail = objSiblingDetailDAO.SaveSiblingDetailData(objSiblingDetail);
            return objSiblingDetail;
        }
        public SiblingDetail EditSiblingDetail(SiblingDetail objSiblingDetail1, SiblingDetail objSiblingDetail2)
        {
            objSiblingDetailDAO = new SiblingDetailDAO();
            using (TransactionScope objTransactionScope = new TransactionScope())
            {
                objSiblingDetail1 = objSiblingDetailDAO.EditSiblingDetail(objSiblingDetail1);
                if (objSiblingDetail1.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    return objSiblingDetail1;
                }

                objSiblingDetail2 = objSiblingDetailDAO.EditSiblingDetail(objSiblingDetail2);
                if (objSiblingDetail2.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    objSiblingDetail1.DbOperationStatus = objSiblingDetail2.DbOperationStatus;
                    return objSiblingDetail1;
                }

                objTransactionScope.Complete();
            }
            return objSiblingDetail1;
        }
    }
}
