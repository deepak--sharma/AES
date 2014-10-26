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
    public class CandidateDetailBL
    {
        private CandidateDetailDAO objCandidateDetailDAO = null;
        private GuardianDetail objGuardianDetail = null;
        private GuardianDetailBL objGuardianDetailBL = null;
        private AddressDetail objAddressDetail = null;
        private AddressDetailBL objAddressDetailBL = null;
        private PreviousSchoolEducationDetail objPreviousSchoolEducationDetail = null;
        private PreviousSchoolEducationDetailBL objPreviousSchoolEducationDetailBL = null;
        private const string strPreviousSchoolEducationDetailRelationKey = "Candidate_Id";
        private SiblingDetail objSiblingDetail = null;
        private SiblingDetailBL objSiblingDetailBL = null;
        private const string strSiblingDetailRelationKey = "Candidate_Id";

        public CandidateDetail SelectCandidateDetail(CandidateDetail objCandidateDetail)
        {
            objCandidateDetailDAO = new CandidateDetailDAO();
            objCandidateDetail = objCandidateDetailDAO.SelectCandidateDetail(objCandidateDetail);
            return objCandidateDetail;
        }

        public CandidateDetail InsertCandidateDetail(CandidateDetail objCandidateDetail)
        {
            objCandidateDetailDAO = new CandidateDetailDAO();
            objGuardianDetailBL = new GuardianDetailBL();
            objAddressDetailBL = new AddressDetailBL();
            objPreviousSchoolEducationDetail = new PreviousSchoolEducationDetail();
            objPreviousSchoolEducationDetailBL = new PreviousSchoolEducationDetailBL();
            objSiblingDetail = new SiblingDetail();
            objSiblingDetailBL = new SiblingDetailBL();
            objGuardianDetail = objGuardianDetailBL.InsertGuardianDetail(objCandidateDetail.FatherObject);
            if (objGuardianDetail.DbOperationStatus != CommonConstant.SUCCEED)
            {
                objCandidateDetail.DbOperationStatus = objGuardianDetail.DbOperationStatus;
                return objCandidateDetail;
            }

            objGuardianDetail = objGuardianDetailBL.InsertGuardianDetail(objCandidateDetail.MotherObject);
            if (objGuardianDetail.DbOperationStatus != CommonConstant.SUCCEED)
            {
                objCandidateDetail.DbOperationStatus = objGuardianDetail.DbOperationStatus;
                return objCandidateDetail;
            }

            objGuardianDetail = objGuardianDetailBL.InsertGuardianDetail(objCandidateDetail.GuardianObject);
            if (objGuardianDetail.DbOperationStatus != CommonConstant.SUCCEED)
            {
                objCandidateDetail.DbOperationStatus = objGuardianDetail.DbOperationStatus;
                return objCandidateDetail;
            }

            objAddressDetail = objAddressDetailBL.InsertAddressDetail(objCandidateDetail.CurrentAddressObject);
            if (objAddressDetail.DbOperationStatus != CommonConstant.SUCCEED)
            {
                objCandidateDetail.DbOperationStatus = objAddressDetail.DbOperationStatus;
                return objCandidateDetail;
            }

            objAddressDetail = objAddressDetailBL.InsertAddressDetail(objCandidateDetail.PermanentAddressObject);
            if (objAddressDetail.DbOperationStatus != CommonConstant.SUCCEED)
            {
                objCandidateDetail.DbOperationStatus = objAddressDetail.DbOperationStatus;
                return objCandidateDetail;
            }

            objCandidateDetail = objCandidateDetailDAO.InsertCandidateDetail(objCandidateDetail);
            if (objCandidateDetail.DbOperationStatus != CommonConstant.SUCCEED)
            {
                return objCandidateDetail;
            }

            objSiblingDetail.ObjectDataSet = DataUtility.UpdateDataColumnWithPrimaryKey(
                            objCandidateDetail.SiblingDetailData.Tables[0], strSiblingDetailRelationKey, objCandidateDetail.CandidateId).DataSet;

            objSiblingDetailBL.SubmitSiblingDetailData(objSiblingDetail);

            if (objSiblingDetail.DbOperationStatus != CommonConstant.SUCCEED)
            {
                objCandidateDetail.DbOperationStatus = CommonConstant.FAIL;
                return objCandidateDetail;
            }

            objPreviousSchoolEducationDetail.ObjectDataSet = DataUtility.UpdateDataColumnWithPrimaryKey(
                            objCandidateDetail.PreviousSchoolEducationDetailData.Tables[0], strPreviousSchoolEducationDetailRelationKey, objCandidateDetail.CandidateId).DataSet;

            objPreviousSchoolEducationDetailBL.SubmitPreviousSchoolEducationDetailData(objPreviousSchoolEducationDetail);

            if (objPreviousSchoolEducationDetail.DbOperationStatus != CommonConstant.SUCCEED)
            {
                objCandidateDetail.DbOperationStatus = CommonConstant.FAIL;
                return objCandidateDetail;
            }

            return objCandidateDetail;
        }

        public CandidateDetail UpdateCandidateDetail(CandidateDetail objCandidateDetail)
        {
            objCandidateDetailDAO = new CandidateDetailDAO();
            objGuardianDetailBL = new GuardianDetailBL();
            objAddressDetailBL = new AddressDetailBL();
            objPreviousSchoolEducationDetail = new PreviousSchoolEducationDetail();
            objPreviousSchoolEducationDetailBL = new PreviousSchoolEducationDetailBL();
            objSiblingDetail = new SiblingDetail();
            objSiblingDetailBL = new SiblingDetailBL();
            if (objCandidateDetail.FatherObject.GuardianId != null)
            { objGuardianDetail = objGuardianDetailBL.UpdateGuardianDetail(objCandidateDetail.FatherObject); }
            else
            { objGuardianDetail = objGuardianDetailBL.InsertGuardianDetail(objCandidateDetail.FatherObject); }

            if (objGuardianDetail.DbOperationStatus != CommonConstant.SUCCEED)
            {
                objCandidateDetail.DbOperationStatus = objGuardianDetail.DbOperationStatus;
                return objCandidateDetail;
            }

            if (objCandidateDetail.MotherObject.GuardianId != null)
            { objGuardianDetail = objGuardianDetailBL.UpdateGuardianDetail(objCandidateDetail.MotherObject); }
            else
            { objGuardianDetail = objGuardianDetailBL.InsertGuardianDetail(objCandidateDetail.MotherObject); }

            if (objGuardianDetail.DbOperationStatus != CommonConstant.SUCCEED)
            {
                objCandidateDetail.DbOperationStatus = objGuardianDetail.DbOperationStatus;
                return objCandidateDetail;
            }

            if (objCandidateDetail.GuardianObject.GuardianId != null)
            { objGuardianDetail = objGuardianDetailBL.UpdateGuardianDetail(objCandidateDetail.GuardianObject); }
            else
            { objGuardianDetail = objGuardianDetailBL.InsertGuardianDetail(objCandidateDetail.GuardianObject); }

            if (objGuardianDetail.DbOperationStatus != CommonConstant.SUCCEED)
            {
                objCandidateDetail.DbOperationStatus = objGuardianDetail.DbOperationStatus;
                return objCandidateDetail;
            }

            if (objCandidateDetail.CurrentAddressObject.AddressId != null)
            { objAddressDetail = objAddressDetailBL.UpdateAddressDetail(objCandidateDetail.CurrentAddressObject); }
            else
            { objAddressDetail = objAddressDetailBL.InsertAddressDetail(objCandidateDetail.CurrentAddressObject); }

            if (objAddressDetail.DbOperationStatus != CommonConstant.SUCCEED)
            {
                objCandidateDetail.DbOperationStatus = objAddressDetail.DbOperationStatus;
                return objCandidateDetail;
            }

            if (objCandidateDetail.PermanentAddressObject.AddressId != null)
            { objAddressDetail = objAddressDetailBL.UpdateAddressDetail(objCandidateDetail.PermanentAddressObject); }
            else
            { objAddressDetail = objAddressDetailBL.InsertAddressDetail(objCandidateDetail.PermanentAddressObject); }

            if (objAddressDetail.DbOperationStatus != CommonConstant.SUCCEED)
            {
                objCandidateDetail.DbOperationStatus = objAddressDetail.DbOperationStatus;
                return objCandidateDetail;
            }

            objCandidateDetail = objCandidateDetailDAO.UpdateCandidateDetail(objCandidateDetail);
            if (objCandidateDetail.DbOperationStatus != CommonConstant.SUCCEED)
            {
                return objCandidateDetail;
            }
            return objCandidateDetail;
        }

        public CandidateDetail SelectRecordById(CandidateDetail objCandidateDetail)
        {
            objCandidateDetailDAO = new CandidateDetailDAO();
            objCandidateDetail = objCandidateDetailDAO.SelectRecordById(objCandidateDetail);
            if (!Convert.ToBoolean(objCandidateDetail.IsRecordChanged)
                    && objCandidateDetail.DbOperationStatus == CommonConstant.SUCCEED)
            {
                objCandidateDetail.ConvertToObjectFromDataset(1);

                if (objCandidateDetail.FatherObject.GuardianId != null)
                {
                    objGuardianDetail = objCandidateDetail.FatherObject;
                    objGuardianDetailBL = new GuardianDetailBL();
                    objGuardianDetail = objGuardianDetailBL.SelectRecordById(objGuardianDetail);
                    objCandidateDetail.DbOperationStatus = objGuardianDetail.DbOperationStatus;
                }

                if (objCandidateDetail.MotherObject.GuardianId != null)
                {
                    objGuardianDetail = objCandidateDetail.MotherObject;
                    objGuardianDetailBL = new GuardianDetailBL();
                    objGuardianDetail = objGuardianDetailBL.SelectRecordById(objGuardianDetail);
                    objCandidateDetail.DbOperationStatus = objGuardianDetail.DbOperationStatus;
                }

                if (objCandidateDetail.GuardianObject.GuardianId != null)
                {
                    objGuardianDetail = objCandidateDetail.GuardianObject;
                    objGuardianDetailBL = new GuardianDetailBL();
                    objGuardianDetail = objGuardianDetailBL.SelectRecordById(objGuardianDetail);
                    objCandidateDetail.DbOperationStatus = objGuardianDetail.DbOperationStatus;
                }

                if (objCandidateDetail.CurrentAddressObject.AddressId != null)
                {
                    objAddressDetail = objCandidateDetail.CurrentAddressObject;
                    objAddressDetailBL = new AddressDetailBL();
                    objAddressDetail = objAddressDetailBL.SelectRecordById(objAddressDetail);
                    objCandidateDetail.DbOperationStatus = objAddressDetail.DbOperationStatus;
                }

                if (objCandidateDetail.PermanentAddressObject.AddressId != null)
                {
                    objAddressDetail = objCandidateDetail.PermanentAddressObject;
                    objAddressDetailBL = new AddressDetailBL();
                    objAddressDetail = objAddressDetailBL.SelectRecordById(objAddressDetail);
                    objCandidateDetail.DbOperationStatus = objAddressDetail.DbOperationStatus;
                }
            }
            return objCandidateDetail;
        }

        // For Wizard Control
        public CandidateDetail SaveCandidateDetail(CandidateDetail objCandidateDetail)
        {
            objCandidateDetailDAO = new CandidateDetailDAO();
            objGuardianDetailBL = new GuardianDetailBL();
            objAddressDetailBL = new AddressDetailBL();
            objPreviousSchoolEducationDetail = new PreviousSchoolEducationDetail();
            objPreviousSchoolEducationDetailBL = new PreviousSchoolEducationDetailBL();
            objSiblingDetail = new SiblingDetail();
            objSiblingDetailBL = new SiblingDetailBL();

            objGuardianDetail = objGuardianDetailBL.InsertGuardianDetail(objCandidateDetail.FatherObject);
            if (objGuardianDetail.DbOperationStatus != CommonConstant.SUCCEED)
            {
                objCandidateDetail.DbOperationStatus = objGuardianDetail.DbOperationStatus;
                return objCandidateDetail;
            }

            objGuardianDetail = objGuardianDetailBL.InsertGuardianDetail(objCandidateDetail.MotherObject);
            if (objGuardianDetail.DbOperationStatus != CommonConstant.SUCCEED)
            {
                objCandidateDetail.DbOperationStatus = objGuardianDetail.DbOperationStatus;
                return objCandidateDetail;
            }

            if (objCandidateDetail.GuardianObject != null)
            {
                objGuardianDetail = objGuardianDetailBL.InsertGuardianDetail(objCandidateDetail.GuardianObject);
                if (objGuardianDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    objCandidateDetail.DbOperationStatus = objGuardianDetail.DbOperationStatus;
                    return objCandidateDetail;
                }
            }

            objAddressDetail = objAddressDetailBL.InsertAddressDetail(objCandidateDetail.CurrentAddressObject);
            if (objAddressDetail.DbOperationStatus != CommonConstant.SUCCEED)
            {
                objCandidateDetail.DbOperationStatus = objAddressDetail.DbOperationStatus;
                return objCandidateDetail;
            }

            objCandidateDetail = objCandidateDetailDAO.InsertCandidateDetail(objCandidateDetail);
            if (objCandidateDetail.DbOperationStatus != CommonConstant.SUCCEED)
            {
                return objCandidateDetail;
            }

            objCandidateDetail.SiblingDetailObject1.CandidateObject = new CandidateDetail();
            objCandidateDetail.SiblingDetailObject1.CandidateObject.CandidateId = objCandidateDetail.CandidateId;
            objSiblingDetailBL.SaveSiblingDetailData(objCandidateDetail.SiblingDetailObject1);
            if (objCandidateDetail.SiblingDetailObject1.DbOperationStatus != CommonConstant.SUCCEED)
            {
                objCandidateDetail.DbOperationStatus = CommonConstant.FAIL;
                return objCandidateDetail;
            }

            objCandidateDetail.SiblingDetailObject2.CandidateObject = new CandidateDetail();
            objCandidateDetail.SiblingDetailObject2.CandidateObject.CandidateId = objCandidateDetail.CandidateId;
            objSiblingDetailBL.SaveSiblingDetailData(objCandidateDetail.SiblingDetailObject2);
            if (objCandidateDetail.SiblingDetailObject2.DbOperationStatus != CommonConstant.SUCCEED)
            {
                objCandidateDetail.DbOperationStatus = CommonConstant.FAIL;
                return objCandidateDetail;
            }

            objCandidateDetail.PreviousSchoolEducationDetailObject.CandidateObject = new CandidateDetail();
            objCandidateDetail.PreviousSchoolEducationDetailObject.CandidateObject.CandidateId = objCandidateDetail.CandidateId;
            objCandidateDetail.PreviousSchoolEducationDetailObject =
                    objPreviousSchoolEducationDetailBL.SavePreviousSchoolEducationDetailData(objCandidateDetail.PreviousSchoolEducationDetailObject);
            if (objCandidateDetail.PreviousSchoolEducationDetailObject.DbOperationStatus != CommonConstant.SUCCEED)
            {
                objCandidateDetail.DbOperationStatus = CommonConstant.FAIL;
                return objCandidateDetail;
            }

            return objCandidateDetail;
        }
        public CandidateDetail EditCandidateDetail(CandidateDetail objCandidateDetail)
        {
            objCandidateDetailDAO = new CandidateDetailDAO();
            objAddressDetailBL = new AddressDetailBL();

            objAddressDetail = objAddressDetailBL.UpdateAddressDetail(objCandidateDetail.CurrentAddressObject);
            if (objAddressDetail.DbOperationStatus != CommonConstant.SUCCEED)
            {
                objCandidateDetail.DbOperationStatus = objAddressDetail.DbOperationStatus;
                return objCandidateDetail;
            }

            objCandidateDetail = objCandidateDetailDAO.UpdateCandidateDetail(objCandidateDetail);
            if (objCandidateDetail.DbOperationStatus != CommonConstant.SUCCEED)
            {
                return objCandidateDetail;
            }
            return objCandidateDetail;
        }
        public CandidateDetail GetRecordById(CandidateDetail objCandidateDetail)
        {
            objCandidateDetailDAO = new CandidateDetailDAO();
            objCandidateDetail = objCandidateDetailDAO.SelectRecordById(objCandidateDetail);
            if (!Convert.ToBoolean(objCandidateDetail.IsRecordChanged)
                    && objCandidateDetail.DbOperationStatus == CommonConstant.SUCCEED)
            {
                objCandidateDetail.ConvertToObjectFromDataset(1);
                if (objCandidateDetail.CurrentAddressObject.AddressId != null)
                {
                    objAddressDetail = objCandidateDetail.CurrentAddressObject;
                    objAddressDetailBL = new AddressDetailBL();
                    objAddressDetail = objAddressDetailBL.SelectRecordById(objAddressDetail);
                    objCandidateDetail.DbOperationStatus = objAddressDetail.DbOperationStatus;
                }

            }
            return objCandidateDetail;
        }


    }
}
