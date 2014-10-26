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
	public class ClassSubjectMappingBL
	{
		private ClassSubjectMappingDAO objClassSubjectMappingDAO = null;

		public ClassSubjectMapping SelectClassSubjectMapping(ClassSubjectMapping objClassSubjectMapping)
		{
			objClassSubjectMappingDAO= new ClassSubjectMappingDAO();
			objClassSubjectMapping = objClassSubjectMappingDAO.SelectClassSubjectMapping(objClassSubjectMapping);
			return objClassSubjectMapping;
		}

		public ClassSubjectMapping InsertClassSubjectMapping(ClassSubjectMapping objClassSubjectMapping)
		{
			objClassSubjectMappingDAO= new ClassSubjectMappingDAO();
			objClassSubjectMapping = objClassSubjectMappingDAO.InsertClassSubjectMapping(objClassSubjectMapping);
			return objClassSubjectMapping;
		}

		public ClassSubjectMapping UpdateClassSubjectMapping(ClassSubjectMapping objClassSubjectMapping)
		{
			objClassSubjectMappingDAO= new ClassSubjectMappingDAO();
			objClassSubjectMapping = objClassSubjectMappingDAO.UpdateClassSubjectMapping(objClassSubjectMapping);
			return objClassSubjectMapping;
		}

		public ClassSubjectMapping ActivateDeactivateClassSubjectMapping(ClassSubjectMapping objClassSubjectMapping)
		{
			objClassSubjectMappingDAO= new ClassSubjectMappingDAO();
			objClassSubjectMapping = objClassSubjectMappingDAO.ActivateDeactivateClassSubjectMapping(objClassSubjectMapping);
			return objClassSubjectMapping;
		}

		public ClassSubjectMapping SelectRecordById(ClassSubjectMapping objClassSubjectMapping)
		{
			objClassSubjectMappingDAO = new ClassSubjectMappingDAO();
			objClassSubjectMapping = objClassSubjectMappingDAO.SelectRecordById(objClassSubjectMapping);
			if (!Convert.ToBoolean(objClassSubjectMapping.IsRecordChanged)
					&& objClassSubjectMapping.DbOperationStatus==CommonConstant.SUCCEED)
			{
				objClassSubjectMapping.ConvertToObjectFromDataset(1);
			}
			return objClassSubjectMapping ;
		}
	}
}
