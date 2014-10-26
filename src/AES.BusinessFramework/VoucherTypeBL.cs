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
	public class VoucherTypeBL
	{
		private VoucherTypeDAO objVoucherTypeDAO = null;

		public VoucherType SelectVoucherType(VoucherType objVoucherType)
		{
			objVoucherTypeDAO= new VoucherTypeDAO();
			objVoucherType = objVoucherTypeDAO.SelectVoucherType(objVoucherType);
			return objVoucherType;
		}

		public VoucherType InsertVoucherType(VoucherType objVoucherType)
		{
			objVoucherTypeDAO= new VoucherTypeDAO();
			objVoucherType = objVoucherTypeDAO.InsertVoucherType(objVoucherType);
			return objVoucherType;
		}

		public VoucherType UpdateVoucherType(VoucherType objVoucherType)
		{
			objVoucherTypeDAO= new VoucherTypeDAO();
			objVoucherType = objVoucherTypeDAO.UpdateVoucherType(objVoucherType);
			return objVoucherType;
		}

		public VoucherType ActivateDeactivateVoucherType(VoucherType objVoucherType)
		{
			objVoucherTypeDAO= new VoucherTypeDAO();
			objVoucherType = objVoucherTypeDAO.ActivateDeactivateVoucherType(objVoucherType);
			return objVoucherType;
		}

		public VoucherType SelectRecordById(VoucherType objVoucherType)
		{
			objVoucherTypeDAO = new VoucherTypeDAO();
			objVoucherType = objVoucherTypeDAO.SelectRecordById(objVoucherType);
			if (!Convert.ToBoolean(objVoucherType.IsRecordChanged)
					&& objVoucherType.DbOperationStatus==CommonConstant.SUCCEED)
			{
				objVoucherType.ConvertToObjectFromDataset(1);
			}
			return objVoucherType ;
		}
	}
}
