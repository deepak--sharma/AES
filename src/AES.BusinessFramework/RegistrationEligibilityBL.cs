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
	public class RegistrationEligibilityBL
	{
		private RegistrationEligibilityDAO objRegistrationEligibilityDAO = null;

        public RegistrationEligibility GetRegistrationEligibilitySchema(RegistrationEligibility objRegistrationEligibility)
		{
			objRegistrationEligibilityDAO= new RegistrationEligibilityDAO();
            objRegistrationEligibility = objRegistrationEligibilityDAO.GetRegistrationEligibilitySchema(objRegistrationEligibility);
			return objRegistrationEligibility;
		}
        
        public RegistrationEligibility GetRegistrationEligibility(RegistrationEligibility objRegistrationEligibility)
        {
            objRegistrationEligibilityDAO = new RegistrationEligibilityDAO();
            objRegistrationEligibility = objRegistrationEligibilityDAO.GetRegistrationEligibility(objRegistrationEligibility);
            return objRegistrationEligibility;
        }

		public RegistrationEligibility SubmitRegistrationEligibilityData(RegistrationEligibility objRegistrationEligibility)
		{
			objRegistrationEligibilityDAO= new RegistrationEligibilityDAO();
			objRegistrationEligibility = objRegistrationEligibilityDAO.SubmitRegistrationEligibilityData(objRegistrationEligibility);
			return objRegistrationEligibility;
		}

	}
}
