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
	public class RegistrationMasterBL
	{
		private RegistrationMasterDAO objRegistrationMasterDAO = null;
		private ReservationDetail objReservationDetail = null;
		private ReservationDetailBL objReservationDetailBL = null;
		private const string strReservationDetailRelationKey = "Registration_Id";
		private RegistrationEligibility objRegistrationEligibility = null;
		private RegistrationEligibilityBL objRegistrationEligibilityBL = null;
		private const string strRegistrationEligibilityRelationKey = "Registration_Id";

		public RegistrationMaster SelectRegistrationMaster(RegistrationMaster objRegistrationMaster)
		{
			objRegistrationMasterDAO= new RegistrationMasterDAO();
			objRegistrationMaster = objRegistrationMasterDAO.SelectRegistrationMaster(objRegistrationMaster);
			return objRegistrationMaster;
		}

		public RegistrationMaster InsertRegistrationMaster(RegistrationMaster objRegistrationMaster)
		{
			objRegistrationMasterDAO= new RegistrationMasterDAO();
			objReservationDetail= new ReservationDetail();
			objReservationDetailBL= new ReservationDetailBL();
			objRegistrationEligibility= new RegistrationEligibility();
			objRegistrationEligibilityBL= new RegistrationEligibilityBL();

			using (TransactionScope objTransactionScope = new TransactionScope())
			{
				objRegistrationMaster = objRegistrationMasterDAO.InsertRegistrationMaster(objRegistrationMaster);
				if (objRegistrationMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					return objRegistrationMaster;
				}

				objReservationDetail.ObjectDataSet = DataUtility.UpdateDataColumnWithPrimaryKey(
							objRegistrationMaster.ReservationDetailData.Tables[0], strReservationDetailRelationKey, objRegistrationMaster.RegistrationId).DataSet;
                objReservationDetail.RegistrationObject = objRegistrationMaster;

				objReservationDetailBL.SubmitReservationDetailData(objReservationDetail);

				if (objReservationDetail.DbOperationStatus != CommonConstant.SUCCEED)
				{
					objRegistrationMaster.DbOperationStatus = CommonConstant.FAIL;
					return objRegistrationMaster;
				}

				objRegistrationEligibility.ObjectDataSet = DataUtility.UpdateDataColumnWithPrimaryKey(
							objRegistrationMaster.RegistrationEligibilityData.Tables[0], strRegistrationEligibilityRelationKey, objRegistrationMaster.RegistrationId).DataSet;
                objRegistrationEligibility.RegistrationObject = objRegistrationMaster;

				objRegistrationEligibilityBL.SubmitRegistrationEligibilityData(objRegistrationEligibility);

				if (objRegistrationEligibility.DbOperationStatus != CommonConstant.SUCCEED)
				{
					objRegistrationMaster.DbOperationStatus = CommonConstant.FAIL;
					return objRegistrationMaster;
				}
				objTransactionScope.Complete();
			}
			return objRegistrationMaster;
		}

		public RegistrationMaster UpdateRegistrationMaster(RegistrationMaster objRegistrationMaster)
		{
			objRegistrationMasterDAO= new RegistrationMasterDAO();
			objReservationDetail= new ReservationDetail();
			objReservationDetailBL= new ReservationDetailBL();
			objRegistrationEligibility= new RegistrationEligibility();
			objRegistrationEligibilityBL= new RegistrationEligibilityBL();

			using (TransactionScope objTransactionScope = new TransactionScope())
			{
				objRegistrationMaster = objRegistrationMasterDAO.UpdateRegistrationMaster(objRegistrationMaster);
				if (objRegistrationMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					return objRegistrationMaster;
				}

				objReservationDetail.ObjectDataSet = DataUtility.UpdateDataColumnWithPrimaryKey(
							objRegistrationMaster.ReservationDetailData.Tables[0], strReservationDetailRelationKey, objRegistrationMaster.RegistrationId).DataSet;
                objReservationDetail.RegistrationObject = objRegistrationMaster;

				objReservationDetailBL.SubmitReservationDetailData(objReservationDetail);

				if (objReservationDetail.DbOperationStatus != CommonConstant.SUCCEED)
				{
					objRegistrationMaster.DbOperationStatus = CommonConstant.FAIL;
					return objRegistrationMaster;
				}

				objRegistrationEligibility.ObjectDataSet = DataUtility.UpdateDataColumnWithPrimaryKey(
							objRegistrationMaster.RegistrationEligibilityData.Tables[0], strRegistrationEligibilityRelationKey, objRegistrationMaster.RegistrationId).DataSet;
                objRegistrationEligibility.RegistrationObject = objRegistrationMaster;

				objRegistrationEligibilityBL.SubmitRegistrationEligibilityData(objRegistrationEligibility);

				if (objRegistrationEligibility.DbOperationStatus != CommonConstant.SUCCEED)
				{
					objRegistrationMaster.DbOperationStatus = CommonConstant.FAIL;
					return objRegistrationMaster;
				}
				objTransactionScope.Complete();
			}
			return objRegistrationMaster;
		}

		public RegistrationMaster ActivateDeactivateRegistrationMaster(RegistrationMaster objRegistrationMaster)
		{
			objRegistrationMasterDAO= new RegistrationMasterDAO();
			objRegistrationMaster = objRegistrationMasterDAO.ActivateDeactivateRegistrationMaster(objRegistrationMaster);
			return objRegistrationMaster;
		}

		public RegistrationMaster SelectRecordById(RegistrationMaster objRegistrationMaster)
		{
			objRegistrationMasterDAO = new RegistrationMasterDAO();
			objRegistrationMaster = objRegistrationMasterDAO.SelectRecordById(objRegistrationMaster);
			if (!Convert.ToBoolean(objRegistrationMaster.IsRecordChanged)
					&& objRegistrationMaster.DbOperationStatus==CommonConstant.SUCCEED)
			{
				objRegistrationMaster.ConvertToObjectFromDataset(1);
			}
			return objRegistrationMaster ;
		}

        public RegistrationMaster FetchActiveRegistration(RegistrationMaster objRegistrationMaster)
        {
            objRegistrationMasterDAO= new RegistrationMasterDAO();
            objRegistrationMaster = objRegistrationMasterDAO.FetchActiveRegistration(objRegistrationMaster);
            return objRegistrationMaster;
        }
	}
}
