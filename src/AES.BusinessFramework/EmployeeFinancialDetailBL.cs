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
	public class EmployeeFinancialDetailBL
	{
		private EmployeeFinancialDetailDAO objEmployeeFinancialDetailDAO = null;

		public EmployeeFinancialDetail SelectEmployeeFinancialDetail(EmployeeFinancialDetail objEmployeeFinancialDetail)
		{
			objEmployeeFinancialDetailDAO= new EmployeeFinancialDetailDAO();
			objEmployeeFinancialDetail = objEmployeeFinancialDetailDAO.SelectEmployeeFinancialDetail(objEmployeeFinancialDetail);
			return objEmployeeFinancialDetail;
		}

		public EmployeeFinancialDetail InsertEmployeeFinancialDetail(EmployeeFinancialDetail objEmployeeFinancialDetail)
		{
			objEmployeeFinancialDetailDAO= new EmployeeFinancialDetailDAO();
			objEmployeeFinancialDetail = objEmployeeFinancialDetailDAO.InsertEmployeeFinancialDetail(objEmployeeFinancialDetail);
			return objEmployeeFinancialDetail;
		}

		public EmployeeFinancialDetail UpdateEmployeeFinancialDetail(EmployeeFinancialDetail objEmployeeFinancialDetail)
		{
			objEmployeeFinancialDetailDAO= new EmployeeFinancialDetailDAO();
			objEmployeeFinancialDetail = objEmployeeFinancialDetailDAO.UpdateEmployeeFinancialDetail(objEmployeeFinancialDetail);
			return objEmployeeFinancialDetail;
		}

		public EmployeeFinancialDetail SelectRecordById(EmployeeFinancialDetail objEmployeeFinancialDetail)
		{
			objEmployeeFinancialDetailDAO = new EmployeeFinancialDetailDAO();
			objEmployeeFinancialDetail = objEmployeeFinancialDetailDAO.SelectRecordById(objEmployeeFinancialDetail);
			if (!Convert.ToBoolean(objEmployeeFinancialDetail.IsRecordChanged)
					&& objEmployeeFinancialDetail.DbOperationStatus==CommonConstant.SUCCEED)
			{
				objEmployeeFinancialDetail.ConvertToObjectFromDataset(1);
			}
			return objEmployeeFinancialDetail ;
		}
	}
}
