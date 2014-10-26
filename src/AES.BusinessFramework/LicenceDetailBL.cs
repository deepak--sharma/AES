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
	public class LicenceDetailBL
	{
		private LicenceDetailDAO objLicenceDetailDAO = null;

		public LicenceDetail SelectLicenceDetail(LicenceDetail objLicenceDetail)
		{
			objLicenceDetailDAO= new LicenceDetailDAO();
			objLicenceDetail = objLicenceDetailDAO.SelectLicenceDetail(objLicenceDetail);
			return objLicenceDetail;
		}

		public LicenceDetail SubmitLicenceDetailData(LicenceDetail objLicenceDetail)
		{
			objLicenceDetailDAO= new LicenceDetailDAO();
			objLicenceDetail = objLicenceDetailDAO.SubmitLicenceDetailData(objLicenceDetail);
			return objLicenceDetail;
		}

	}
}
