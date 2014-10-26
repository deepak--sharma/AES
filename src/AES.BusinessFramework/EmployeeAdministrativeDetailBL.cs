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
	public class EmployeeAdministrativeDetailBL
	{
		private EmployeeAdministrativeDetailDAO objEmployeeAdministrativeDetailDAO = null;

		public EmployeeAdministrativeDetail SelectEmployeeAdministrativeDetail(EmployeeAdministrativeDetail objEmployeeAdministrativeDetail)
		{
			objEmployeeAdministrativeDetailDAO= new EmployeeAdministrativeDetailDAO();
			objEmployeeAdministrativeDetail = objEmployeeAdministrativeDetailDAO.SelectEmployeeAdministrativeDetail(objEmployeeAdministrativeDetail);
			return objEmployeeAdministrativeDetail;
		}

		public EmployeeAdministrativeDetail InsertEmployeeAdministrativeDetail(EmployeeAdministrativeDetail objEmployeeAdministrativeDetail)
		{
			objEmployeeAdministrativeDetailDAO= new EmployeeAdministrativeDetailDAO();
			objEmployeeAdministrativeDetail = objEmployeeAdministrativeDetailDAO.InsertEmployeeAdministrativeDetail(objEmployeeAdministrativeDetail);
			return objEmployeeAdministrativeDetail;
		}

		public EmployeeAdministrativeDetail UpdateEmployeeAdministrativeDetail(EmployeeAdministrativeDetail objEmployeeAdministrativeDetail)
		{
			objEmployeeAdministrativeDetailDAO= new EmployeeAdministrativeDetailDAO();
			objEmployeeAdministrativeDetail = objEmployeeAdministrativeDetailDAO.UpdateEmployeeAdministrativeDetail(objEmployeeAdministrativeDetail);
			return objEmployeeAdministrativeDetail;
		}

		public EmployeeAdministrativeDetail SelectRecordById(EmployeeAdministrativeDetail objEmployeeAdministrativeDetail)
		{
			objEmployeeAdministrativeDetailDAO = new EmployeeAdministrativeDetailDAO();
			objEmployeeAdministrativeDetail = objEmployeeAdministrativeDetailDAO.SelectRecordById(objEmployeeAdministrativeDetail);
			if (!Convert.ToBoolean(objEmployeeAdministrativeDetail.IsRecordChanged)
					&& objEmployeeAdministrativeDetail.DbOperationStatus==CommonConstant.SUCCEED)
			{
				objEmployeeAdministrativeDetail.ConvertToObjectFromDataset(1);
			}
			return objEmployeeAdministrativeDetail ;
		}
	}
}
