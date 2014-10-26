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
    public class PreviousSchoolEducationDetailBL
    {
        private PreviousSchoolEducationDetailDAO objPreviousSchoolEducationDetailDAO = null;
        private PreviousSchoolEducationMarksDetail objPreviousSchoolEducationMarksDetail = null;
        private PreviousSchoolEducationMarksDetailBL objPreviousSchoolEducationMarksDetailBL = null;
        private const string strPreviousSchoolEducationMarksDetailRelationKey = "Previous_School_Education_Id";

        public PreviousSchoolEducationDetail SelectPreviousSchoolEducationDetail(PreviousSchoolEducationDetail objPreviousSchoolEducationDetail)
        {
            objPreviousSchoolEducationDetailDAO = new PreviousSchoolEducationDetailDAO();
            objPreviousSchoolEducationDetail = objPreviousSchoolEducationDetailDAO.SelectPreviousSchoolEducationDetail(objPreviousSchoolEducationDetail);
            return objPreviousSchoolEducationDetail;
        }

        public PreviousSchoolEducationDetail SubmitPreviousSchoolEducationDetailData(PreviousSchoolEducationDetail objPreviousSchoolEducationDetail)
        {
            objPreviousSchoolEducationDetailDAO = new PreviousSchoolEducationDetailDAO();
            objPreviousSchoolEducationMarksDetail = new PreviousSchoolEducationMarksDetail();
            objPreviousSchoolEducationMarksDetailBL = new PreviousSchoolEducationMarksDetailBL();

            objPreviousSchoolEducationDetail = objPreviousSchoolEducationDetailDAO.SubmitPreviousSchoolEducationDetailData(objPreviousSchoolEducationDetail);
            if (objPreviousSchoolEducationDetail.DbOperationStatus != CommonConstant.SUCCEED)
            {
                return objPreviousSchoolEducationDetail;
            }

            objPreviousSchoolEducationMarksDetail.ObjectDataSet = DataUtility.UpdateDataColumnWithPrimaryKey(
                            objPreviousSchoolEducationDetail.PreviousSchoolEducationMarksDetailData.Tables[0], strPreviousSchoolEducationMarksDetailRelationKey,
                            objPreviousSchoolEducationDetail.PreviousSchoolEducationId).DataSet;

            objPreviousSchoolEducationMarksDetailBL.SubmitPreviousSchoolEducationMarksDetailData(objPreviousSchoolEducationMarksDetail);
            if (objPreviousSchoolEducationMarksDetail.DbOperationStatus != CommonConstant.SUCCEED)
            {
                objPreviousSchoolEducationDetail.DbOperationStatus = CommonConstant.FAIL;
                return objPreviousSchoolEducationDetail;
            }

            return objPreviousSchoolEducationDetail;
        }

        // For Wizard Control
        public PreviousSchoolEducationDetail SavePreviousSchoolEducationDetailData(PreviousSchoolEducationDetail objPreviousSchoolEducationDetail)
        {
            objPreviousSchoolEducationDetailDAO = new PreviousSchoolEducationDetailDAO();
            objPreviousSchoolEducationDetail = objPreviousSchoolEducationDetailDAO.SavePreviousSchoolEducationDetailData(objPreviousSchoolEducationDetail);

            return objPreviousSchoolEducationDetail;
        }
        public PreviousSchoolEducationDetail EdiPreviousSchoolEducationDetailData(PreviousSchoolEducationDetail objPreviousSchoolEducationDetail)
        {
            objPreviousSchoolEducationDetailDAO = new PreviousSchoolEducationDetailDAO();
            objPreviousSchoolEducationDetail = objPreviousSchoolEducationDetailDAO.EditPreviousSchoolEducationDetailData(objPreviousSchoolEducationDetail);

            return objPreviousSchoolEducationDetail;
        }
        public PreviousSchoolEducationDetail SelectSchoolEducationDetailById(PreviousSchoolEducationDetail objPreviousSchoolEducationDetail)
        {
            objPreviousSchoolEducationDetailDAO = new PreviousSchoolEducationDetailDAO();
            objPreviousSchoolEducationDetail = objPreviousSchoolEducationDetailDAO.SelectPreviousSchoolEducationDetail(objPreviousSchoolEducationDetail);

            if (objPreviousSchoolEducationDetail.DbOperationStatus == CommonConstant.SUCCEED)
            {
                objPreviousSchoolEducationDetail.ConvertToObjectFromDataset(0);
                objPreviousSchoolEducationDetail.ParentVersion = Convert.ToInt32(objPreviousSchoolEducationDetail.ObjectDataSet.Tables[1].Rows[0][0]);
                objPreviousSchoolEducationMarksDetail = new PreviousSchoolEducationMarksDetail();
                objPreviousSchoolEducationMarksDetailBL = new PreviousSchoolEducationMarksDetailBL();
                objPreviousSchoolEducationMarksDetail.PreviousSchoolEducationObject = new PreviousSchoolEducationDetail();
                objPreviousSchoolEducationMarksDetail.PreviousSchoolEducationObject.PreviousSchoolEducationId = objPreviousSchoolEducationDetail.PreviousSchoolEducationId;
                objPreviousSchoolEducationMarksDetail = objPreviousSchoolEducationMarksDetailBL.SelectPreviousSchoolEducationMarksDetail(objPreviousSchoolEducationMarksDetail);
                objPreviousSchoolEducationDetail.DbOperationStatus = objPreviousSchoolEducationMarksDetail.DbOperationStatus;
                if (objPreviousSchoolEducationDetail.DbOperationStatus == CommonConstant.SUCCEED)
                {
                    objPreviousSchoolEducationDetail.PreviousSchoolEducationMarksDetailData = objPreviousSchoolEducationMarksDetail.ObjectDataSet;
                }
            }
            return objPreviousSchoolEducationDetail;
        }

    }
}
