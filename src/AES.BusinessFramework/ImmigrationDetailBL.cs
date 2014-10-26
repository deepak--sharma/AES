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
	public class ImmigrationDetailBL
	{
		private ImmigrationDetailDAO objImmigrationDetailDAO = null;

		public ImmigrationDetail SelectImmigrationDetail(ImmigrationDetail objImmigrationDetail)
		{
			objImmigrationDetailDAO= new ImmigrationDetailDAO();
			objImmigrationDetail = objImmigrationDetailDAO.SelectImmigrationDetail(objImmigrationDetail);
			return objImmigrationDetail;
		}

		public ImmigrationDetail SubmitImmigrationDetailData(ImmigrationDetail objImmigrationDetail)
		{
			objImmigrationDetailDAO= new ImmigrationDetailDAO();
			objImmigrationDetail = objImmigrationDetailDAO.SubmitImmigrationDetailData(objImmigrationDetail);
			return objImmigrationDetail;
		}

	}
}
