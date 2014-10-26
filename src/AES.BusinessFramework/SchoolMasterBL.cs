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
	public class SchoolMasterBL
	{
		private SchoolMasterDAO objSchoolMasterDAO = null;
		private AddressDetail objAddressDetail = null;
		private AddressDetailBL objAddressDetailBL = null;

		public SchoolMaster SelectSchoolMaster(SchoolMaster objSchoolMaster)
		{
			objSchoolMasterDAO= new SchoolMasterDAO();
			objSchoolMaster = objSchoolMasterDAO.SelectSchoolMaster(objSchoolMaster);
			return objSchoolMaster;
		}

		public SchoolMaster InsertSchoolMaster(SchoolMaster objSchoolMaster)
		{
			objSchoolMasterDAO= new SchoolMasterDAO();
			objAddressDetailBL= new AddressDetailBL();

			using (TransactionScope objTransactionScope = new TransactionScope())
			{
				objAddressDetail = objAddressDetailBL.InsertAddressDetail(objSchoolMaster.SchoolAddressObject);
				if (objAddressDetail.DbOperationStatus != CommonConstant.SUCCEED)
				{
					objSchoolMaster.DbOperationStatus = objAddressDetail.DbOperationStatus;
					return objSchoolMaster;
				}

				objSchoolMaster = objSchoolMasterDAO.InsertSchoolMaster(objSchoolMaster);
				if (objSchoolMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					return objSchoolMaster;
				}
				objTransactionScope.Complete();
			}
			return objSchoolMaster;
		}

		public SchoolMaster UpdateSchoolMaster(SchoolMaster objSchoolMaster)
		{
			objSchoolMasterDAO= new SchoolMasterDAO();
			objAddressDetailBL= new AddressDetailBL();

			using (TransactionScope objTransactionScope = new TransactionScope())
			{
				if (objSchoolMaster.SchoolAddressObject.AddressId != null)
				{ objAddressDetail = objAddressDetailBL.UpdateAddressDetail(objSchoolMaster.SchoolAddressObject); }
				else
				{ objAddressDetail = objAddressDetailBL.InsertAddressDetail(objSchoolMaster.SchoolAddressObject); }

				if (objAddressDetail.DbOperationStatus != CommonConstant.SUCCEED)
				{
					objSchoolMaster.DbOperationStatus = objAddressDetail.DbOperationStatus;
					return objSchoolMaster;
				}

				objSchoolMaster = objSchoolMasterDAO.UpdateSchoolMaster(objSchoolMaster);
				if (objSchoolMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					return objSchoolMaster;
				}
				objTransactionScope.Complete();
			}
			return objSchoolMaster;
		}

		public SchoolMaster ActivateDeactivateSchoolMaster(SchoolMaster objSchoolMaster)
		{
			objSchoolMasterDAO= new SchoolMasterDAO();
			objSchoolMaster = objSchoolMasterDAO.ActivateDeactivateSchoolMaster(objSchoolMaster);
			return objSchoolMaster;
		}

		public SchoolMaster SelectRecordById(SchoolMaster objSchoolMaster)
		{
			objSchoolMasterDAO = new SchoolMasterDAO();
			objSchoolMaster = objSchoolMasterDAO.SelectRecordById(objSchoolMaster);
			if (!Convert.ToBoolean(objSchoolMaster.IsRecordChanged)
					&& objSchoolMaster.DbOperationStatus==CommonConstant.SUCCEED)
			{
				objSchoolMaster.ConvertToObjectFromDataset(1);

				if (objSchoolMaster.SchoolAddressObject.AddressId != null)
				{
					objAddressDetail = objSchoolMaster.SchoolAddressObject;
					objAddressDetailBL = new AddressDetailBL();
					objAddressDetail = objAddressDetailBL.SelectRecordById(objAddressDetail);
					objSchoolMaster.DbOperationStatus = objAddressDetail.DbOperationStatus;
				}
			}
			return objSchoolMaster ;
		}
	}
}
