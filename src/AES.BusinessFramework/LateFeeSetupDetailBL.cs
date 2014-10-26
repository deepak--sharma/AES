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
	public class LateFeeSetupDetailBL
	{
		private LateFeeSetupDetailDAO objLateFeeSetupDetailDAO = null;

		public LateFeeSetupDetail SelectLateFeeSetupDetail(LateFeeSetupDetail objLateFeeSetupDetail)
		{
			objLateFeeSetupDetailDAO= new LateFeeSetupDetailDAO();
			objLateFeeSetupDetail = objLateFeeSetupDetailDAO.SelectLateFeeSetupDetail(objLateFeeSetupDetail);
			return objLateFeeSetupDetail;
		}

		public LateFeeSetupDetail SubmitLateFeeSetupDetailData(LateFeeSetupDetail objLateFeeSetupDetail)
		{
			objLateFeeSetupDetailDAO= new LateFeeSetupDetailDAO();
			objLateFeeSetupDetail = objLateFeeSetupDetailDAO.SubmitLateFeeSetupDetailData(objLateFeeSetupDetail);
			return objLateFeeSetupDetail;
		}

	}
}
