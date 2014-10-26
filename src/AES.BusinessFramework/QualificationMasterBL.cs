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
	public class QualificationMasterBL
	{
		private QualificationMasterDAO objQualificationMasterDAO = null;

		public QualificationMaster SelectQualificationMaster(QualificationMaster objQualificationMaster)
		{
			objQualificationMasterDAO= new QualificationMasterDAO();
			objQualificationMaster = objQualificationMasterDAO.SelectQualificationMaster(objQualificationMaster);
			return objQualificationMaster;
		}

		public QualificationMaster InsertQualificationMaster(QualificationMaster objQualificationMaster)
		{
			objQualificationMasterDAO= new QualificationMasterDAO();
			objQualificationMaster = objQualificationMasterDAO.InsertQualificationMaster(objQualificationMaster);
			return objQualificationMaster;
		}

		public QualificationMaster UpdateQualificationMaster(QualificationMaster objQualificationMaster)
		{
			objQualificationMasterDAO= new QualificationMasterDAO();
			objQualificationMaster = objQualificationMasterDAO.UpdateQualificationMaster(objQualificationMaster);
			return objQualificationMaster;
		}

		public QualificationMaster ActivateDeactivateQualificationMaster(QualificationMaster objQualificationMaster)
		{
			objQualificationMasterDAO= new QualificationMasterDAO();
			objQualificationMaster = objQualificationMasterDAO.ActivateDeactivateQualificationMaster(objQualificationMaster);
			return objQualificationMaster;
		}

		public QualificationMaster SelectRecordById(QualificationMaster objQualificationMaster)
		{
			objQualificationMasterDAO = new QualificationMasterDAO();
			objQualificationMaster = objQualificationMasterDAO.SelectRecordById(objQualificationMaster);
			if (!Convert.ToBoolean(objQualificationMaster.IsRecordChanged)
					&& objQualificationMaster.DbOperationStatus==CommonConstant.SUCCEED)
			{
				objQualificationMaster.ConvertToObjectFromDataset(1);
			}
			return objQualificationMaster ;
		}
	}
}
