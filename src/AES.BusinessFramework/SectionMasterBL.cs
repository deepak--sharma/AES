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
	public class SectionMasterBL
	{
		private SectionMasterDAO objSectionMasterDAO = null;

		public SectionMaster SelectSectionMaster(SectionMaster objSectionMaster)
		{
			objSectionMasterDAO= new SectionMasterDAO();
			objSectionMaster = objSectionMasterDAO.SelectSectionMaster(objSectionMaster);
			return objSectionMaster;
		}

		public SectionMaster InsertSectionMaster(SectionMaster objSectionMaster)
		{
			objSectionMasterDAO= new SectionMasterDAO();
			objSectionMaster = objSectionMasterDAO.InsertSectionMaster(objSectionMaster);
			return objSectionMaster;
		}

		public SectionMaster UpdateSectionMaster(SectionMaster objSectionMaster)
		{
			objSectionMasterDAO= new SectionMasterDAO();
			objSectionMaster = objSectionMasterDAO.UpdateSectionMaster(objSectionMaster);
			return objSectionMaster;
		}

		public SectionMaster ActivateDeactivateSectionMaster(SectionMaster objSectionMaster)
		{
			objSectionMasterDAO= new SectionMasterDAO();
			objSectionMaster = objSectionMasterDAO.ActivateDeactivateSectionMaster(objSectionMaster);
			return objSectionMaster;
		}

		public SectionMaster SelectRecordById(SectionMaster objSectionMaster)
		{
			objSectionMasterDAO = new SectionMasterDAO();
			objSectionMaster = objSectionMasterDAO.SelectRecordById(objSectionMaster);
			if (!Convert.ToBoolean(objSectionMaster.IsRecordChanged)
					&& objSectionMaster.DbOperationStatus==CommonConstant.SUCCEED)
			{
				objSectionMaster.ConvertToObjectFromDataset(1);
			}
			return objSectionMaster ;
		}
	}
}
