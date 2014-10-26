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
	public class KnownLanguageBL
	{
		private KnownLanguageDAO objKnownLanguageDAO = null;

		public KnownLanguage SelectKnownLanguage(KnownLanguage objKnownLanguage)
		{
			objKnownLanguageDAO= new KnownLanguageDAO();
			objKnownLanguage = objKnownLanguageDAO.SelectKnownLanguage(objKnownLanguage);
			return objKnownLanguage;
		}

		public KnownLanguage SubmitKnownLanguageData(KnownLanguage objKnownLanguage)
		{
			objKnownLanguageDAO= new KnownLanguageDAO();
			objKnownLanguage = objKnownLanguageDAO.SubmitKnownLanguageData(objKnownLanguage);
			return objKnownLanguage;
		}

	}
}
