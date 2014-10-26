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
	public class MedicalMasterBL
	{
		private MedicalMasterDAO objMedicalMasterDAO = null;

		public MedicalMaster SelectMedicalMaster(MedicalMaster objMedicalMaster)
		{
			objMedicalMasterDAO= new MedicalMasterDAO();
			objMedicalMaster = objMedicalMasterDAO.SelectMedicalMaster(objMedicalMaster);
			return objMedicalMaster;
		}

		public MedicalMaster InsertMedicalMaster(MedicalMaster objMedicalMaster)
		{
			objMedicalMasterDAO= new MedicalMasterDAO();
			objMedicalMaster = objMedicalMasterDAO.InsertMedicalMaster(objMedicalMaster);
			return objMedicalMaster;
		}

		public MedicalMaster UpdateMedicalMaster(MedicalMaster objMedicalMaster)
		{
			objMedicalMasterDAO= new MedicalMasterDAO();
			objMedicalMaster = objMedicalMasterDAO.UpdateMedicalMaster(objMedicalMaster);
			return objMedicalMaster;
		}

		public MedicalMaster ActivateDeactivateMedicalMaster(MedicalMaster objMedicalMaster)
		{
			objMedicalMasterDAO= new MedicalMasterDAO();
			objMedicalMaster = objMedicalMasterDAO.ActivateDeactivateMedicalMaster(objMedicalMaster);
			return objMedicalMaster;
		}

		public MedicalMaster SelectRecordById(MedicalMaster objMedicalMaster)
		{
			objMedicalMasterDAO = new MedicalMasterDAO();
			objMedicalMaster = objMedicalMasterDAO.SelectRecordById(objMedicalMaster);
			if (!Convert.ToBoolean(objMedicalMaster.IsRecordChanged)
					&& objMedicalMaster.DbOperationStatus==CommonConstant.SUCCEED)
			{
				objMedicalMaster.ConvertToObjectFromDataset(1);
			}
			return objMedicalMaster ;
		}
	}
}
