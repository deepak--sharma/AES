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
    public class EmployeeDetailBL
    {
        private EmployeeDetailDAO objEmployeeDetailDAO = null;
        private EmployeeAdministrativeDetail objEmployeeAdministrativeDetail = null;
        private EmployeeAdministrativeDetailBL objEmployeeAdministrativeDetailBL = null;
        private EmployeeFinancialDetail objEmployeeFinancialDetail = null;
        private EmployeeFinancialDetailBL objEmployeeFinancialDetailBL = null;
        private AddressDetail objAddressDetail = null;
        private AddressDetailBL objAddressDetailBL = null;
        private EmergencyDetail objEmergencyDetail = null;
        private EmergencyDetailBL objEmergencyDetailBL = null;
        private EmployeeJoiningDetail objEmployeeJoiningDetail = null;
        private EmployeeJoiningDetailBL objEmployeeJoiningDetailBL = null;
        private const string strEmployeeJoiningDetailRelationKey = "Employee_Id";
        private ReportingDetail objReportingDetail = null;
        private ReportingDetailBL objReportingDetailBL = null;
        private const string strReportingDetailRelationKey = "Employee_ID";
        private SkillDetail objSkillDetail = null;
        private SkillDetailBL objSkillDetailBL = null;
        private const string strSkillDetailRelationKey = "Member_Id";
        private KnownLanguage objKnownLanguage = null;
        private KnownLanguageBL objKnownLanguageBL = null;
        private const string strKnownLanguageRelationKey = "Member_ID";
        private ImmigrationDetail objImmigrationDetail = null;
        private ImmigrationDetailBL objImmigrationDetailBL = null;
        private const string strImmigrationDetailRelationKey = "Member_ID";
        private LicenceDetail objLicenceDetail = null;
        private LicenceDetailBL objLicenceDetailBL = null;
        private const string strLicenceDetailRelationKey = "Member_Id";
        private EmployeePreviousOrganisationDetail objEmployeePreviousOrganisationDetail = null;
        private EmployeePreviousOrganisationDetailBL objEmployeePreviousOrganisationDetailBL = null;
        private const string strEmployeePreviousOrganisationDetailRelationKey = "Employee_Id";
        private EmployeeFamilyDetail objEmployeeFamilyDetail = null;
        private EmployeeFamilyDetailBL objEmployeeFamilyDetailBL = null;
        private const string strEmployeeFamilyDetailRelationKey = "Employee_Id";
        private EmployeeEducationalDetail objEmployeeEducationalDetail = null;
        private EmployeeEducationalDetailBL objEmployeeEducationalDetailBL = null;
        private const string strEmployeeEducationalDetailRelationKey = "Employee_Id";
        private EmployeeMedicalDetail objEmployeeMedicalDetail = null;
        private EmployeeMedicalDetailBL objEmployeeMedicalDetailBL = null;
        private const string strEmployeeMedicalDetailRelationKey = "Employee_Id";

        public EmployeeDetail SelectEmployeeDetail(EmployeeDetail objEmployeeDetail)
        {
            objEmployeeDetailDAO = new EmployeeDetailDAO();
            objEmployeeDetail = objEmployeeDetailDAO.SelectEmployeeDetail(objEmployeeDetail);
            return objEmployeeDetail;
        }

        public EmployeeDetail InsertEmployeeDetail(EmployeeDetail objEmployeeDetail)
        {
            objEmployeeDetailDAO = new EmployeeDetailDAO();
            objEmployeeAdministrativeDetailBL = new EmployeeAdministrativeDetailBL();
            objEmployeeFinancialDetailBL = new EmployeeFinancialDetailBL();
            objAddressDetailBL = new AddressDetailBL();
            objEmergencyDetailBL = new EmergencyDetailBL();
            objEmployeeJoiningDetail = new EmployeeJoiningDetail();
            objEmployeeJoiningDetailBL = new EmployeeJoiningDetailBL();
            objReportingDetail = new ReportingDetail();
            objReportingDetailBL = new ReportingDetailBL();
            objSkillDetail = new SkillDetail();
            objSkillDetailBL = new SkillDetailBL();
            objKnownLanguage = new KnownLanguage();
            objKnownLanguageBL = new KnownLanguageBL();
            objImmigrationDetail = new ImmigrationDetail();
            objImmigrationDetailBL = new ImmigrationDetailBL();
            objLicenceDetail = new LicenceDetail();
            objLicenceDetailBL = new LicenceDetailBL();
            objEmployeePreviousOrganisationDetail = new EmployeePreviousOrganisationDetail();
            objEmployeePreviousOrganisationDetailBL = new EmployeePreviousOrganisationDetailBL();
            objEmployeeFamilyDetail = new EmployeeFamilyDetail();
            objEmployeeFamilyDetailBL = new EmployeeFamilyDetailBL();
            objEmployeeEducationalDetail = new EmployeeEducationalDetail();
            objEmployeeEducationalDetailBL = new EmployeeEducationalDetailBL();
            objEmployeeMedicalDetail = new EmployeeMedicalDetail();
            objEmployeeMedicalDetailBL = new EmployeeMedicalDetailBL();

            using (TransactionScope objTransactionScope = new TransactionScope())
            {
                objEmployeeAdministrativeDetail = objEmployeeAdministrativeDetailBL.InsertEmployeeAdministrativeDetail(objEmployeeDetail.EmployeeAdministrativeDetailObject);
                if (objEmployeeAdministrativeDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    objEmployeeDetail.DbOperationStatus = objEmployeeAdministrativeDetail.DbOperationStatus;
                    return objEmployeeDetail;
                }

                objEmployeeFinancialDetail = objEmployeeFinancialDetailBL.InsertEmployeeFinancialDetail(objEmployeeDetail.EmployeeFinancialDetailObject);
                if (objEmployeeFinancialDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    objEmployeeDetail.DbOperationStatus = objEmployeeFinancialDetail.DbOperationStatus;
                    return objEmployeeDetail;
                }

                objAddressDetail = objAddressDetailBL.InsertAddressDetail(objEmployeeDetail.CurrentAddressObject);
                if (objAddressDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    objEmployeeDetail.DbOperationStatus = objAddressDetail.DbOperationStatus;
                    return objEmployeeDetail;
                }

                objAddressDetail = objAddressDetailBL.InsertAddressDetail(objEmployeeDetail.PermanentAddressObject);
                if (objAddressDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    objEmployeeDetail.DbOperationStatus = objAddressDetail.DbOperationStatus;
                    return objEmployeeDetail;
                }

                objEmergencyDetail = objEmergencyDetailBL.InsertEmergencyDetail(objEmployeeDetail.PrimaryEmergencyObject);
                if (objEmergencyDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    objEmployeeDetail.DbOperationStatus = objEmergencyDetail.DbOperationStatus;
                    return objEmployeeDetail;
                }

                objEmergencyDetail = objEmergencyDetailBL.InsertEmergencyDetail(objEmployeeDetail.SecondryEmergencyObject);
                if (objEmergencyDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    objEmployeeDetail.DbOperationStatus = objEmergencyDetail.DbOperationStatus;
                    return objEmployeeDetail;
                }

                objEmployeeDetail = objEmployeeDetailDAO.InsertEmployeeDetail(objEmployeeDetail);
                if (objEmployeeDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    return objEmployeeDetail;
                }

                objEmployeeJoiningDetail.ObjectDataSet = DataUtility.UpdateDataColumnWithPrimaryKey(
                            objEmployeeDetail.EmployeeJoiningDetailData.Tables[0], strEmployeeJoiningDetailRelationKey, objEmployeeDetail.EmployeeId).DataSet;

               // objEmployeeJoiningDetailBL.SubmitEmployeeJoiningDetailData(objEmployeeJoiningDetail);

                if (objEmployeeJoiningDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    objEmployeeDetail.DbOperationStatus = CommonConstant.FAIL;
                    return objEmployeeDetail;
                }

                objReportingDetail.ObjectDataSet = DataUtility.UpdateDataColumnWithPrimaryKey(
                            objEmployeeDetail.ReportingDetailData.Tables[0], strReportingDetailRelationKey, objEmployeeDetail.EmployeeId).DataSet;

               // objReportingDetailBL.SubmitReportingDetailData(objReportingDetail);

                if (objReportingDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    objEmployeeDetail.DbOperationStatus = CommonConstant.FAIL;
                    return objEmployeeDetail;
                }

                objSkillDetail.ObjectDataSet = DataUtility.UpdateDataColumnWithPrimaryKey(
                            objEmployeeDetail.SkillDetailData.Tables[0], strSkillDetailRelationKey, objEmployeeDetail.EmployeeId).DataSet;

                //objSkillDetailBL.SubmitSkillDetailData(objSkillDetail,null);

                if (objSkillDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    objEmployeeDetail.DbOperationStatus = CommonConstant.FAIL;
                    return objEmployeeDetail;
                }

                objKnownLanguage.ObjectDataSet = DataUtility.UpdateDataColumnWithPrimaryKey(
                            objEmployeeDetail.KnownLanguageData.Tables[0], strKnownLanguageRelationKey, objEmployeeDetail.EmployeeId).DataSet;

                objKnownLanguageBL.SubmitKnownLanguageData(objKnownLanguage);

                if (objKnownLanguage.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    objEmployeeDetail.DbOperationStatus = CommonConstant.FAIL;
                    return objEmployeeDetail;
                }

                objImmigrationDetail.ObjectDataSet = DataUtility.UpdateDataColumnWithPrimaryKey(
                            objEmployeeDetail.ImmigrationDetailData.Tables[0], strImmigrationDetailRelationKey, objEmployeeDetail.EmployeeId).DataSet;

                objImmigrationDetailBL.SubmitImmigrationDetailData(objImmigrationDetail);

                if (objImmigrationDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    objEmployeeDetail.DbOperationStatus = CommonConstant.FAIL;
                    return objEmployeeDetail;
                }

                objLicenceDetail.ObjectDataSet = DataUtility.UpdateDataColumnWithPrimaryKey(
                            objEmployeeDetail.LicenceDetailData.Tables[0], strLicenceDetailRelationKey, objEmployeeDetail.EmployeeId).DataSet;

                objLicenceDetailBL.SubmitLicenceDetailData(objLicenceDetail);

                if (objLicenceDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    objEmployeeDetail.DbOperationStatus = CommonConstant.FAIL;
                    return objEmployeeDetail;
                }

                objEmployeePreviousOrganisationDetail.ObjectDataSet = DataUtility.UpdateDataColumnWithPrimaryKey(
                            objEmployeeDetail.EmployeePreviousOrganisationDetailData.Tables[0], strEmployeePreviousOrganisationDetailRelationKey, objEmployeeDetail.EmployeeId).DataSet;

                objEmployeePreviousOrganisationDetailBL.SubmitEmployeePreviousOrganisationDetailData(objEmployeePreviousOrganisationDetail);

                if (objEmployeePreviousOrganisationDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    objEmployeeDetail.DbOperationStatus = CommonConstant.FAIL;
                    return objEmployeeDetail;
                }

                objEmployeeFamilyDetail.ObjectDataSet = DataUtility.UpdateDataColumnWithPrimaryKey(
                            objEmployeeDetail.EmployeeFamilyDetailData.Tables[0], strEmployeeFamilyDetailRelationKey, objEmployeeDetail.EmployeeId).DataSet;

               // objEmployeeFamilyDetailBL.SubmitEmployeeFamilyDetailData(objEmployeeFamilyDetail);

                if (objEmployeeFamilyDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    objEmployeeDetail.DbOperationStatus = CommonConstant.FAIL;
                    return objEmployeeDetail;
                }

                objEmployeeEducationalDetail.ObjectDataSet = DataUtility.UpdateDataColumnWithPrimaryKey(
                            objEmployeeDetail.EmployeeEducationalDetailData.Tables[0], strEmployeeEducationalDetailRelationKey, objEmployeeDetail.EmployeeId).DataSet;

                objEmployeeEducationalDetailBL.SubmitEmployeeEducationalDetailData(objEmployeeEducationalDetail);

                if (objEmployeeEducationalDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    objEmployeeDetail.DbOperationStatus = CommonConstant.FAIL;
                    return objEmployeeDetail;
                }

                objEmployeeMedicalDetail.ObjectDataSet = DataUtility.UpdateDataColumnWithPrimaryKey(
                            objEmployeeDetail.EmployeeMedicalDetailData.Tables[0], strEmployeeMedicalDetailRelationKey, objEmployeeDetail.EmployeeId).DataSet;

               // objEmployeeMedicalDetailBL.SubmitEmployeeMedicalDetailData(objEmployeeMedicalDetail);

                if (objEmployeeMedicalDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    objEmployeeDetail.DbOperationStatus = CommonConstant.FAIL;
                    return objEmployeeDetail;
                }
                objTransactionScope.Complete();
            }
            return objEmployeeDetail;
        }

        public EmployeeDetail UpdateEmployeeDetail(EmployeeDetail objEmployeeDetail)
        {
            objEmployeeDetailDAO = new EmployeeDetailDAO();
            objEmployeeAdministrativeDetailBL = new EmployeeAdministrativeDetailBL();
            objEmployeeFinancialDetailBL = new EmployeeFinancialDetailBL();
            objAddressDetailBL = new AddressDetailBL();
            objEmergencyDetailBL = new EmergencyDetailBL();
            objEmployeeJoiningDetail = new EmployeeJoiningDetail();
            objEmployeeJoiningDetailBL = new EmployeeJoiningDetailBL();
            objReportingDetail = new ReportingDetail();
            objReportingDetailBL = new ReportingDetailBL();
            objSkillDetail = new SkillDetail();
            objSkillDetailBL = new SkillDetailBL();
            objKnownLanguage = new KnownLanguage();
            objKnownLanguageBL = new KnownLanguageBL();
            objImmigrationDetail = new ImmigrationDetail();
            objImmigrationDetailBL = new ImmigrationDetailBL();
            objLicenceDetail = new LicenceDetail();
            objLicenceDetailBL = new LicenceDetailBL();
            objEmployeePreviousOrganisationDetail = new EmployeePreviousOrganisationDetail();
            objEmployeePreviousOrganisationDetailBL = new EmployeePreviousOrganisationDetailBL();
            objEmployeeFamilyDetail = new EmployeeFamilyDetail();
            objEmployeeFamilyDetailBL = new EmployeeFamilyDetailBL();
            objEmployeeEducationalDetail = new EmployeeEducationalDetail();
            objEmployeeEducationalDetailBL = new EmployeeEducationalDetailBL();
            objEmployeeMedicalDetail = new EmployeeMedicalDetail();
            objEmployeeMedicalDetailBL = new EmployeeMedicalDetailBL();

            using (TransactionScope objTransactionScope = new TransactionScope())
            {
                if (objEmployeeDetail.EmployeeAdministrativeDetailObject.EmployeeAdministrativeDetailId != null)
                { objEmployeeAdministrativeDetail = objEmployeeAdministrativeDetailBL.UpdateEmployeeAdministrativeDetail(objEmployeeDetail.EmployeeAdministrativeDetailObject); }
                else
                { objEmployeeAdministrativeDetail = objEmployeeAdministrativeDetailBL.InsertEmployeeAdministrativeDetail(objEmployeeDetail.EmployeeAdministrativeDetailObject); }

                if (objEmployeeAdministrativeDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    objEmployeeDetail.DbOperationStatus = objEmployeeAdministrativeDetail.DbOperationStatus;
                    return objEmployeeDetail;
                }

                if (objEmployeeDetail.EmployeeFinancialDetailObject.EmployeeFinancialDetailId != null)
                { objEmployeeFinancialDetail = objEmployeeFinancialDetailBL.UpdateEmployeeFinancialDetail(objEmployeeDetail.EmployeeFinancialDetailObject); }
                else
                { objEmployeeFinancialDetail = objEmployeeFinancialDetailBL.InsertEmployeeFinancialDetail(objEmployeeDetail.EmployeeFinancialDetailObject); }

                if (objEmployeeFinancialDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    objEmployeeDetail.DbOperationStatus = objEmployeeFinancialDetail.DbOperationStatus;
                    return objEmployeeDetail;
                }

                if (objEmployeeDetail.CurrentAddressObject.AddressId != null)
                { objAddressDetail = objAddressDetailBL.UpdateAddressDetail(objEmployeeDetail.CurrentAddressObject); }
                else
                { objAddressDetail = objAddressDetailBL.InsertAddressDetail(objEmployeeDetail.CurrentAddressObject); }

                if (objAddressDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    objEmployeeDetail.DbOperationStatus = objAddressDetail.DbOperationStatus;
                    return objEmployeeDetail;
                }

                if (objEmployeeDetail.PermanentAddressObject.AddressId != null)
                { objAddressDetail = objAddressDetailBL.UpdateAddressDetail(objEmployeeDetail.PermanentAddressObject); }
                else
                { objAddressDetail = objAddressDetailBL.InsertAddressDetail(objEmployeeDetail.PermanentAddressObject); }

                if (objAddressDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    objEmployeeDetail.DbOperationStatus = objAddressDetail.DbOperationStatus;
                    return objEmployeeDetail;
                }

                if (objEmployeeDetail.PrimaryEmergencyObject.EmergencyDetailId != null)
                { objEmergencyDetail = objEmergencyDetailBL.UpdateEmergencyDetail(objEmployeeDetail.PrimaryEmergencyObject); }
                else
                { objEmergencyDetail = objEmergencyDetailBL.InsertEmergencyDetail(objEmployeeDetail.PrimaryEmergencyObject); }

                if (objEmergencyDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    objEmployeeDetail.DbOperationStatus = objEmergencyDetail.DbOperationStatus;
                    return objEmployeeDetail;
                }

                if (objEmployeeDetail.SecondryEmergencyObject.EmergencyDetailId != null)
                { objEmergencyDetail = objEmergencyDetailBL.UpdateEmergencyDetail(objEmployeeDetail.SecondryEmergencyObject); }
                else
                { objEmergencyDetail = objEmergencyDetailBL.InsertEmergencyDetail(objEmployeeDetail.SecondryEmergencyObject); }

                if (objEmergencyDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    objEmployeeDetail.DbOperationStatus = objEmergencyDetail.DbOperationStatus;
                    return objEmployeeDetail;
                }

                objEmployeeDetail = objEmployeeDetailDAO.UpdateEmployeeDetail(objEmployeeDetail);
                if (objEmployeeDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    return objEmployeeDetail;
                }

                objEmployeeJoiningDetail.ObjectDataSet = DataUtility.UpdateDataColumnWithPrimaryKey(
                            objEmployeeDetail.EmployeeJoiningDetailData.Tables[0], strEmployeeJoiningDetailRelationKey, objEmployeeDetail.EmployeeId).DataSet;

                //objEmployeeJoiningDetailBL.SubmitEmployeeJoiningDetailData(objEmployeeJoiningDetail);

                if (objEmployeeJoiningDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    objEmployeeDetail.DbOperationStatus = CommonConstant.FAIL;
                    return objEmployeeDetail;
                }

                objReportingDetail.ObjectDataSet = DataUtility.UpdateDataColumnWithPrimaryKey(
                            objEmployeeDetail.ReportingDetailData.Tables[0], strReportingDetailRelationKey, objEmployeeDetail.EmployeeId).DataSet;

               // objReportingDetailBL.SubmitReportingDetailData(objReportingDetail);

                if (objReportingDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    objEmployeeDetail.DbOperationStatus = CommonConstant.FAIL;
                    return objEmployeeDetail;
                }

                objSkillDetail.ObjectDataSet = DataUtility.UpdateDataColumnWithPrimaryKey(
                            objEmployeeDetail.SkillDetailData.Tables[0], strSkillDetailRelationKey, objEmployeeDetail.EmployeeId).DataSet;

                //objSkillDetailBL.SubmitSkillDetailData(objSkillDetail,null);

                if (objSkillDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    objEmployeeDetail.DbOperationStatus = CommonConstant.FAIL;
                    return objEmployeeDetail;
                }

                objKnownLanguage.ObjectDataSet = DataUtility.UpdateDataColumnWithPrimaryKey(
                            objEmployeeDetail.KnownLanguageData.Tables[0], strKnownLanguageRelationKey, objEmployeeDetail.EmployeeId).DataSet;

                objKnownLanguageBL.SubmitKnownLanguageData(objKnownLanguage);

                if (objKnownLanguage.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    objEmployeeDetail.DbOperationStatus = CommonConstant.FAIL;
                    return objEmployeeDetail;
                }

                objImmigrationDetail.ObjectDataSet = DataUtility.UpdateDataColumnWithPrimaryKey(
                            objEmployeeDetail.ImmigrationDetailData.Tables[0], strImmigrationDetailRelationKey, objEmployeeDetail.EmployeeId).DataSet;

                objImmigrationDetailBL.SubmitImmigrationDetailData(objImmigrationDetail);

                if (objImmigrationDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    objEmployeeDetail.DbOperationStatus = CommonConstant.FAIL;
                    return objEmployeeDetail;
                }

                objLicenceDetail.ObjectDataSet = DataUtility.UpdateDataColumnWithPrimaryKey(
                            objEmployeeDetail.LicenceDetailData.Tables[0], strLicenceDetailRelationKey, objEmployeeDetail.EmployeeId).DataSet;

                objLicenceDetailBL.SubmitLicenceDetailData(objLicenceDetail);

                if (objLicenceDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    objEmployeeDetail.DbOperationStatus = CommonConstant.FAIL;
                    return objEmployeeDetail;
                }

                objEmployeePreviousOrganisationDetail.ObjectDataSet = DataUtility.UpdateDataColumnWithPrimaryKey(
                            objEmployeeDetail.EmployeePreviousOrganisationDetailData.Tables[0], strEmployeePreviousOrganisationDetailRelationKey, objEmployeeDetail.EmployeeId).DataSet;

                objEmployeePreviousOrganisationDetailBL.SubmitEmployeePreviousOrganisationDetailData(objEmployeePreviousOrganisationDetail);

                if (objEmployeePreviousOrganisationDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    objEmployeeDetail.DbOperationStatus = CommonConstant.FAIL;
                    return objEmployeeDetail;
                }

                objEmployeeFamilyDetail.ObjectDataSet = DataUtility.UpdateDataColumnWithPrimaryKey(
                            objEmployeeDetail.EmployeeFamilyDetailData.Tables[0], strEmployeeFamilyDetailRelationKey, objEmployeeDetail.EmployeeId).DataSet;

                //objEmployeeFamilyDetailBL.SubmitEmployeeFamilyDetailData(objEmployeeFamilyDetail);

                if (objEmployeeFamilyDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    objEmployeeDetail.DbOperationStatus = CommonConstant.FAIL;
                    return objEmployeeDetail;
                }

                objEmployeeEducationalDetail.ObjectDataSet = DataUtility.UpdateDataColumnWithPrimaryKey(
                            objEmployeeDetail.EmployeeEducationalDetailData.Tables[0], strEmployeeEducationalDetailRelationKey, objEmployeeDetail.EmployeeId).DataSet;

                objEmployeeEducationalDetailBL.SubmitEmployeeEducationalDetailData(objEmployeeEducationalDetail);

                if (objEmployeeEducationalDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    objEmployeeDetail.DbOperationStatus = CommonConstant.FAIL;
                    return objEmployeeDetail;
                }

                objEmployeeMedicalDetail.ObjectDataSet = DataUtility.UpdateDataColumnWithPrimaryKey(
                            objEmployeeDetail.EmployeeMedicalDetailData.Tables[0], strEmployeeMedicalDetailRelationKey, objEmployeeDetail.EmployeeId).DataSet;

                //objEmployeeMedicalDetailBL.SubmitEmployeeMedicalDetailData(objEmployeeMedicalDetail);

                if (objEmployeeMedicalDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    objEmployeeDetail.DbOperationStatus = CommonConstant.FAIL;
                    return objEmployeeDetail;
                }
                objTransactionScope.Complete();
            }
            return objEmployeeDetail;
        }

        public EmployeeDetail ActivateDeactivateEmployeeDetail(EmployeeDetail objEmployeeDetail)
        {
            objEmployeeDetailDAO = new EmployeeDetailDAO();
            objEmployeeDetail = objEmployeeDetailDAO.ActivateDeactivateEmployeeDetail(objEmployeeDetail);
            return objEmployeeDetail;
        }

        public EmployeeDetail SelectRecordById(EmployeeDetail objEmployeeDetail)
        {
            objEmployeeDetailDAO = new EmployeeDetailDAO();
            objEmployeeDetail = objEmployeeDetailDAO.SelectRecordById(objEmployeeDetail);
            if (!Convert.ToBoolean(objEmployeeDetail.IsRecordChanged)
                    && objEmployeeDetail.DbOperationStatus == CommonConstant.SUCCEED)
            {
                objEmployeeDetail.ConvertToObjectFromDataset(1);                
            }
            return objEmployeeDetail;
        }

        public EmployeeDetail SaveEmployeeBasicDetail(EmployeeDetail objEmployeeDetail)
        {
            objEmployeeDetailDAO = new EmployeeDetailDAO();
            objEmployeeDetail = objEmployeeDetailDAO.InsertEmployeeDetail(objEmployeeDetail);
            return objEmployeeDetail;
        }
        public EmployeeDetail EditEmployeeBasicDetail(EmployeeDetail objEmployeeDetail)
        {
            objEmployeeDetailDAO = new EmployeeDetailDAO();
            objEmployeeDetail = objEmployeeDetailDAO.UpdateEmployeeDetail(objEmployeeDetail);
            return objEmployeeDetail;
        }

        public EmployeeDetail UpdateEmployeeVersion(EmployeeDetail objEmployeeDetail)
        {
            objEmployeeDetailDAO = new EmployeeDetailDAO();
            objEmployeeDetail = objEmployeeDetailDAO.UpdateEmployeeVersion(objEmployeeDetail);
            return objEmployeeDetail;
        }

    }
}
