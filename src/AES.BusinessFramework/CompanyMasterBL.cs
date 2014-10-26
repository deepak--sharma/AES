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
	public class CompanyMasterBL
	{
		private CompanyMasterDAO objCompanyMasterDAO = null;
		private AddressDetail objAddressDetail = null;
		private AddressDetailBL objAddressDetailBL = null;

		public CompanyMaster SelectCompanyMaster(CompanyMaster objCompanyMaster)
		{
			objCompanyMasterDAO= new CompanyMasterDAO();
			objCompanyMaster = objCompanyMasterDAO.SelectCompanyMaster(objCompanyMaster);
			return objCompanyMaster;
		}

		public CompanyMaster InsertCompanyMaster(CompanyMaster objCompanyMaster)
		{
			objCompanyMasterDAO= new CompanyMasterDAO();
			objAddressDetailBL= new AddressDetailBL();

			using (TransactionScope objTransactionScope = new TransactionScope())
			{
				objAddressDetail = objAddressDetailBL.InsertAddressDetail(objCompanyMaster.CompanyAddressObject);
				if (objAddressDetail.DbOperationStatus != CommonConstant.SUCCEED)
				{
					objCompanyMaster.DbOperationStatus = objAddressDetail.DbOperationStatus;
					return objCompanyMaster;
				}

				objCompanyMaster = objCompanyMasterDAO.InsertCompanyMaster(objCompanyMaster);
				if (objCompanyMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					return objCompanyMaster;
				}
				objTransactionScope.Complete();
			}
			return objCompanyMaster;
		}

		public CompanyMaster UpdateCompanyMaster(CompanyMaster objCompanyMaster)
		{
			objCompanyMasterDAO= new CompanyMasterDAO();
			objAddressDetailBL= new AddressDetailBL();

			using (TransactionScope objTransactionScope = new TransactionScope())
			{
				if (objCompanyMaster.CompanyAddressObject.AddressId != null)
				{ objAddressDetail = objAddressDetailBL.UpdateAddressDetail(objCompanyMaster.CompanyAddressObject); }
				else
				{ objAddressDetail = objAddressDetailBL.InsertAddressDetail(objCompanyMaster.CompanyAddressObject); }

				if (objAddressDetail.DbOperationStatus != CommonConstant.SUCCEED)
				{
					objCompanyMaster.DbOperationStatus = objAddressDetail.DbOperationStatus;
					return objCompanyMaster;
				}

				objCompanyMaster = objCompanyMasterDAO.UpdateCompanyMaster(objCompanyMaster);
				if (objCompanyMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					return objCompanyMaster;
				}
				objTransactionScope.Complete();
			}
			return objCompanyMaster;
		}

		public CompanyMaster ActivateDeactivateCompanyMaster(CompanyMaster objCompanyMaster)
		{
			objCompanyMasterDAO= new CompanyMasterDAO();
			objCompanyMaster = objCompanyMasterDAO.ActivateDeactivateCompanyMaster(objCompanyMaster);
			return objCompanyMaster;
		}

		public CompanyMaster SelectRecordById(CompanyMaster objCompanyMaster)
		{
			objCompanyMasterDAO = new CompanyMasterDAO();
			objCompanyMaster = objCompanyMasterDAO.SelectRecordById(objCompanyMaster);
			if (!Convert.ToBoolean(objCompanyMaster.IsRecordChanged)
					&& objCompanyMaster.DbOperationStatus==CommonConstant.SUCCEED)
			{
				objCompanyMaster.ConvertToObjectFromDataset(1);

				if (objCompanyMaster.CompanyAddressObject.AddressId != null)
				{
					objAddressDetail = objCompanyMaster.CompanyAddressObject;
					objAddressDetailBL = new AddressDetailBL();
					objAddressDetail = objAddressDetailBL.SelectRecordById(objAddressDetail);
					objCompanyMaster.DbOperationStatus = objAddressDetail.DbOperationStatus;
				}
			}
			return objCompanyMaster ;
		}
	}
}
