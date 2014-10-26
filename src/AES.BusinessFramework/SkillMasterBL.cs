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
	public class SkillMasterBL
	{
		private SkillMasterDAO objSkillMasterDAO = null;

		public SkillMaster SelectSkillMaster(SkillMaster objSkillMaster)
		{
			objSkillMasterDAO= new SkillMasterDAO();
			objSkillMaster = objSkillMasterDAO.SelectSkillMaster(objSkillMaster);
			return objSkillMaster;
		}

		public SkillMaster InsertSkillMaster(SkillMaster objSkillMaster)
		{
			objSkillMasterDAO= new SkillMasterDAO();
			objSkillMaster = objSkillMasterDAO.InsertSkillMaster(objSkillMaster);
			return objSkillMaster;
		}

		public SkillMaster UpdateSkillMaster(SkillMaster objSkillMaster)
		{
			objSkillMasterDAO= new SkillMasterDAO();
			objSkillMaster = objSkillMasterDAO.UpdateSkillMaster(objSkillMaster);
			return objSkillMaster;
		}

		public SkillMaster ActivateDeactivateSkillMaster(SkillMaster objSkillMaster)
		{
			objSkillMasterDAO= new SkillMasterDAO();
			objSkillMaster = objSkillMasterDAO.ActivateDeactivateSkillMaster(objSkillMaster);
			return objSkillMaster;
		}

		public SkillMaster SelectRecordById(SkillMaster objSkillMaster)
		{
			objSkillMasterDAO = new SkillMasterDAO();
			objSkillMaster = objSkillMasterDAO.SelectRecordById(objSkillMaster);
			if (!Convert.ToBoolean(objSkillMaster.IsRecordChanged)
					&& objSkillMaster.DbOperationStatus==CommonConstant.SUCCEED)
			{
				objSkillMaster.ConvertToObjectFromDataset(1);
			}
			return objSkillMaster ;
		}
	}
}
