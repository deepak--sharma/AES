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
	public class StudentDetailBL
	{
		private StudentDetailDAO objStudentDetailDAO = null;

		public StudentDetail SelectStudentDetail(StudentDetail objStudentDetail)
		{
			objStudentDetailDAO= new StudentDetailDAO();
			objStudentDetail = objStudentDetailDAO.SelectStudentDetail(objStudentDetail);
			return objStudentDetail;
		}

		public StudentDetail InsertStudentDetail(StudentDetail objStudentDetail)
		{
			objStudentDetailDAO= new StudentDetailDAO();
			objStudentDetail = objStudentDetailDAO.InsertStudentDetail(objStudentDetail);
			return objStudentDetail;
		}

		public StudentDetail UpdateStudentDetail(StudentDetail objStudentDetail)
		{
			objStudentDetailDAO= new StudentDetailDAO();
			objStudentDetail = objStudentDetailDAO.UpdateStudentDetail(objStudentDetail);
			return objStudentDetail;
		}

		public StudentDetail ActivateDeactivateStudentDetail(StudentDetail objStudentDetail)
		{
			objStudentDetailDAO= new StudentDetailDAO();
			objStudentDetail = objStudentDetailDAO.ActivateDeactivateStudentDetail(objStudentDetail);
			return objStudentDetail;
		}

		public StudentDetail SelectRecordById(StudentDetail objStudentDetail)
		{
			objStudentDetailDAO = new StudentDetailDAO();
			objStudentDetail = objStudentDetailDAO.SelectRecordById(objStudentDetail);
			if (!Convert.ToBoolean(objStudentDetail.IsRecordChanged)
					&& objStudentDetail.DbOperationStatus==CommonConstant.SUCCEED)
			{
				objStudentDetail.ConvertToObjectFromDataset(1);
			}
			return objStudentDetail ;
		}
	}
}
