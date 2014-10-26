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
	public class ClassMasterBL
	{
		private ClassMasterDAO objClassMasterDAO = null;

		public ClassMaster SelectClassMaster(ClassMaster objClassMaster)
		{
			objClassMasterDAO= new ClassMasterDAO();
			objClassMaster = objClassMasterDAO.SelectClassMaster(objClassMaster);
			return objClassMaster;
		}

		public ClassMaster InsertClassMaster(ClassMaster objClassMaster)
		{
			objClassMasterDAO= new ClassMasterDAO();
			objClassMaster = objClassMasterDAO.InsertClassMaster(objClassMaster);
			return objClassMaster;
		}

		public ClassMaster UpdateClassMaster(ClassMaster objClassMaster)
		{
			objClassMasterDAO= new ClassMasterDAO();
			objClassMaster = objClassMasterDAO.UpdateClassMaster(objClassMaster);
			return objClassMaster;
		}

		public ClassMaster ActivateDeactivateClassMaster(ClassMaster objClassMaster)
		{
			objClassMasterDAO= new ClassMasterDAO();
			objClassMaster = objClassMasterDAO.ActivateDeactivateClassMaster(objClassMaster);
			return objClassMaster;
		}

		public ClassMaster SelectRecordById(ClassMaster objClassMaster)
		{
			objClassMasterDAO = new ClassMasterDAO();
			objClassMaster = objClassMasterDAO.SelectRecordById(objClassMaster);
			if (!Convert.ToBoolean(objClassMaster.IsRecordChanged)
					&& objClassMaster.DbOperationStatus==CommonConstant.SUCCEED)
			{
				objClassMaster.ConvertToObjectFromDataset(1);
			}
			return objClassMaster ;
		}
	}
}
