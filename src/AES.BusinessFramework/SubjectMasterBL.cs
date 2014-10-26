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
	public class SubjectMasterBL
	{
		private SubjectMasterDAO objSubjectMasterDAO = null;

		public SubjectMaster SelectSubjectMaster(SubjectMaster objSubjectMaster)
		{
			objSubjectMasterDAO= new SubjectMasterDAO();
			objSubjectMaster = objSubjectMasterDAO.SelectSubjectMaster(objSubjectMaster);
			return objSubjectMaster;
		}

		public SubjectMaster InsertSubjectMaster(SubjectMaster objSubjectMaster)
		{
			objSubjectMasterDAO= new SubjectMasterDAO();
			objSubjectMaster = objSubjectMasterDAO.InsertSubjectMaster(objSubjectMaster);
			return objSubjectMaster;
		}

		public SubjectMaster UpdateSubjectMaster(SubjectMaster objSubjectMaster)
		{
			objSubjectMasterDAO= new SubjectMasterDAO();
			objSubjectMaster = objSubjectMasterDAO.UpdateSubjectMaster(objSubjectMaster);
			return objSubjectMaster;
		}

		public SubjectMaster ActivateDeactivateSubjectMaster(SubjectMaster objSubjectMaster)
		{
			objSubjectMasterDAO= new SubjectMasterDAO();
			objSubjectMaster = objSubjectMasterDAO.ActivateDeactivateSubjectMaster(objSubjectMaster);
			return objSubjectMaster;
		}

		public SubjectMaster SelectRecordById(SubjectMaster objSubjectMaster)
		{
			objSubjectMasterDAO = new SubjectMasterDAO();
			objSubjectMaster = objSubjectMasterDAO.SelectRecordById(objSubjectMaster);
			if (!Convert.ToBoolean(objSubjectMaster.IsRecordChanged)
					&& objSubjectMaster.DbOperationStatus==CommonConstant.SUCCEED)
			{
				objSubjectMaster.ConvertToObjectFromDataset(1);
			}
			return objSubjectMaster ;
		}
	}
}
