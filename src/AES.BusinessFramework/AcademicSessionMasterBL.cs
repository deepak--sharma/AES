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
	public class AcademicSessionMasterBL
	{
		private AcademicSessionMasterDAO objAcademicSessionMasterDAO = null;

		public AcademicSessionMaster SelectAcademicSessionMaster(AcademicSessionMaster objAcademicSessionMaster)
		{
			objAcademicSessionMasterDAO= new AcademicSessionMasterDAO();
			objAcademicSessionMaster = objAcademicSessionMasterDAO.SelectAcademicSessionMaster(objAcademicSessionMaster);
			return objAcademicSessionMaster;
		}

		public AcademicSessionMaster InsertAcademicSessionMaster(AcademicSessionMaster objAcademicSessionMaster)
		{
			objAcademicSessionMasterDAO= new AcademicSessionMasterDAO();
			objAcademicSessionMaster = objAcademicSessionMasterDAO.InsertAcademicSessionMaster(objAcademicSessionMaster);
			return objAcademicSessionMaster;
		}

		public AcademicSessionMaster UpdateAcademicSessionMaster(AcademicSessionMaster objAcademicSessionMaster)
		{
			objAcademicSessionMasterDAO= new AcademicSessionMasterDAO();
			objAcademicSessionMaster = objAcademicSessionMasterDAO.UpdateAcademicSessionMaster(objAcademicSessionMaster);
			return objAcademicSessionMaster;
		}

		public AcademicSessionMaster ActivateDeactivateAcademicSessionMaster(AcademicSessionMaster objAcademicSessionMaster)
		{
			objAcademicSessionMasterDAO= new AcademicSessionMasterDAO();
			objAcademicSessionMaster = objAcademicSessionMasterDAO.ActivateDeactivateAcademicSessionMaster(objAcademicSessionMaster);
			return objAcademicSessionMaster;
		}

		public AcademicSessionMaster SelectRecordById(AcademicSessionMaster objAcademicSessionMaster)
		{
			objAcademicSessionMasterDAO = new AcademicSessionMasterDAO();
			objAcademicSessionMaster = objAcademicSessionMasterDAO.SelectRecordById(objAcademicSessionMaster);
			if (!Convert.ToBoolean(objAcademicSessionMaster.IsRecordChanged)
					&& objAcademicSessionMaster.DbOperationStatus==CommonConstant.SUCCEED)
			{
				objAcademicSessionMaster.ConvertToObjectFromDataset(1);
			}
			return objAcademicSessionMaster ;
		}
	}
}
