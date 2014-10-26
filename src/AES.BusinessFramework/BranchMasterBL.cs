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
	public class BranchMasterBL
	{
		private BranchMasterDAO objBranchMasterDAO = null;
		private AddressDetail objAddressDetail = null;
		private AddressDetailBL objAddressDetailBL = null;

		public BranchMaster SelectBranchMaster(BranchMaster objBranchMaster)
		{
			objBranchMasterDAO= new BranchMasterDAO();
			objBranchMaster = objBranchMasterDAO.SelectBranchMaster(objBranchMaster);
			return objBranchMaster;
		}

		public BranchMaster InsertBranchMaster(BranchMaster objBranchMaster)
		{
			objBranchMasterDAO= new BranchMasterDAO();
			objAddressDetailBL= new AddressDetailBL();

			using (TransactionScope objTransactionScope = new TransactionScope())
			{
				objAddressDetail = objAddressDetailBL.InsertAddressDetail(objBranchMaster.BranchAddressObject);
				if (objAddressDetail.DbOperationStatus != CommonConstant.SUCCEED)
				{
					objBranchMaster.DbOperationStatus = objAddressDetail.DbOperationStatus;
					return objBranchMaster;
				}

				objBranchMaster = objBranchMasterDAO.InsertBranchMaster(objBranchMaster);
				if (objBranchMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					return objBranchMaster;
				}
				objTransactionScope.Complete();
			}
			return objBranchMaster;
		}

		public BranchMaster UpdateBranchMaster(BranchMaster objBranchMaster)
		{
			objBranchMasterDAO= new BranchMasterDAO();
			objAddressDetailBL= new AddressDetailBL();

			using (TransactionScope objTransactionScope = new TransactionScope())
			{
				if (objBranchMaster.BranchAddressObject.AddressId != null)
				{ objAddressDetail = objAddressDetailBL.UpdateAddressDetail(objBranchMaster.BranchAddressObject); }
				else
				{ objAddressDetail = objAddressDetailBL.InsertAddressDetail(objBranchMaster.BranchAddressObject); }

				if (objAddressDetail.DbOperationStatus != CommonConstant.SUCCEED)
				{
					objBranchMaster.DbOperationStatus = objAddressDetail.DbOperationStatus;
					return objBranchMaster;
				}

				objBranchMaster = objBranchMasterDAO.UpdateBranchMaster(objBranchMaster);
				if (objBranchMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					return objBranchMaster;
				}
				objTransactionScope.Complete();
			}
			return objBranchMaster;
		}

		public BranchMaster ActivateDeactivateBranchMaster(BranchMaster objBranchMaster)
		{
			objBranchMasterDAO= new BranchMasterDAO();
			objBranchMaster = objBranchMasterDAO.ActivateDeactivateBranchMaster(objBranchMaster);
			return objBranchMaster;
		}

		public BranchMaster SelectRecordById(BranchMaster objBranchMaster)
		{
			objBranchMasterDAO = new BranchMasterDAO();
			objBranchMaster = objBranchMasterDAO.SelectRecordById(objBranchMaster);
			if (!Convert.ToBoolean(objBranchMaster.IsRecordChanged)
					&& objBranchMaster.DbOperationStatus==CommonConstant.SUCCEED)
			{
				objBranchMaster.ConvertToObjectFromDataset(1);

				if (objBranchMaster.BranchAddressObject.AddressId != null)
				{
					objAddressDetail = objBranchMaster.BranchAddressObject;
					objAddressDetailBL = new AddressDetailBL();
					objAddressDetail = objAddressDetailBL.SelectRecordById(objAddressDetail);
					objBranchMaster.DbOperationStatus = objAddressDetail.DbOperationStatus;
				}
			}
			return objBranchMaster ;
		}
	}
}
