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
	public class CourseMasterBL
	{
		private CourseMasterDAO objCourseMasterDAO = null;

		public CourseMaster SelectCourseMaster(CourseMaster objCourseMaster)
		{
			objCourseMasterDAO= new CourseMasterDAO();
			objCourseMaster = objCourseMasterDAO.SelectCourseMaster(objCourseMaster);
			return objCourseMaster;
		}

		public CourseMaster InsertCourseMaster(CourseMaster objCourseMaster)
		{
			objCourseMasterDAO= new CourseMasterDAO();
			objCourseMaster = objCourseMasterDAO.InsertCourseMaster(objCourseMaster);
			return objCourseMaster;
		}

		public CourseMaster UpdateCourseMaster(CourseMaster objCourseMaster)
		{
			objCourseMasterDAO= new CourseMasterDAO();
			objCourseMaster = objCourseMasterDAO.UpdateCourseMaster(objCourseMaster);
			return objCourseMaster;
		}

		public CourseMaster ActivateDeactivateCourseMaster(CourseMaster objCourseMaster)
		{
			objCourseMasterDAO= new CourseMasterDAO();
			objCourseMaster = objCourseMasterDAO.ActivateDeactivateCourseMaster(objCourseMaster);
			return objCourseMaster;
		}

		public CourseMaster SelectRecordById(CourseMaster objCourseMaster)
		{
			objCourseMasterDAO = new CourseMasterDAO();
			objCourseMaster = objCourseMasterDAO.SelectRecordById(objCourseMaster);
			if (!Convert.ToBoolean(objCourseMaster.IsRecordChanged)
					&& objCourseMaster.DbOperationStatus==CommonConstant.SUCCEED)
			{
				objCourseMaster.ConvertToObjectFromDataset(1);
			}
			return objCourseMaster ;
		}
	}
}
