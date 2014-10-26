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
    public class SkillDetailBL
    {
        EmployeeDetail objEmployeeDetail = null;
        EmployeeDetailBL objEmployeeDetailBL = null;
        private SkillDetailDAO objSkillDetailDAO = null;
        private KnownLanguageBL objKnownLanguageBL = null;
        private string strSkillDetailRelationKey = "Member_Id";
        private string strKnownLanguageRelationKey = "Member_Id";

        SkillDetail objSkillDetail;
        KnownLanguage objKnownLanguage;

        public SkillDetail SelectSkillDetail(SkillDetail objSkillDetail)
        {
            objSkillDetailDAO = new SkillDetailDAO();
            objSkillDetail = objSkillDetailDAO.SelectSkillDetail(objSkillDetail);
            return objSkillDetail;
        }

        public SkillDetail SubmitSkillDetailData(List<SkillDetail> objSkillDetailList, List<KnownLanguage> objKnownLanguageList )
        {
            objSkillDetailDAO = new SkillDetailDAO();
            objKnownLanguageBL = new KnownLanguageBL();
            objSkillDetail = new SkillDetail();
            objKnownLanguage = new KnownLanguage();
            
            using (TransactionScope objTransactionScope = new TransactionScope())
            {
                foreach (SkillDetail _objSkillDetail in objSkillDetailList)
                {
                    objSkillDetail = objSkillDetailDAO.SubmitSkillDetailData(_objSkillDetail);
                    if (objSkillDetail.DbOperationStatus != CommonConstant.SUCCEED)
                    {
                        return objSkillDetail;
                    }
                }
                foreach (KnownLanguage _objKnownLanguage in objKnownLanguageList)
                {
                    objKnownLanguage = objKnownLanguageBL.SubmitKnownLanguageData(_objKnownLanguage);
                    if (objKnownLanguage.DbOperationStatus != CommonConstant.SUCCEED)
                    {
                        objSkillDetail.DbOperationStatus = objKnownLanguage.DbOperationStatus;
                        return objSkillDetail;
                    }
                }
                objEmployeeDetail = new EmployeeDetail();
                objSkillDetail = objSkillDetailList[0];
                objEmployeeDetail.EmployeeId = objSkillDetail.ParentId;
                objEmployeeDetail.Version = objSkillDetail.ParentVersion;
                objEmployeeDetail.ModifiedBy = objSkillDetail.ModifiedBy;
                objEmployeeDetail.ModifiedOn = objSkillDetail.ModifiedOn;
                objEmployeeDetailBL = new EmployeeDetailBL();
                objEmployeeDetail = objEmployeeDetailBL.UpdateEmployeeVersion(objEmployeeDetail);
                if (objEmployeeDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    objSkillDetail.DbOperationStatus = objEmployeeDetail.DbOperationStatus;
                    return objSkillDetail;
                }

                objTransactionScope.Complete();
            }          
            return objSkillDetail;
        }

    }
}
