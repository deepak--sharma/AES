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
	public class StudentAttendanceBL
	{
		private StudentAttendanceDAO objStudentAttendanceDAO = null;

		public StudentAttendance SelectStudentAttendance(StudentAttendance objStudentAttendance)
		{
			objStudentAttendanceDAO= new StudentAttendanceDAO();
			objStudentAttendance = objStudentAttendanceDAO.SelectStudentAttendance(objStudentAttendance);
			return objStudentAttendance;
		}

		public StudentAttendance SubmitStudentAttendanceData(StudentAttendance objStudentAttendance)
		{
			objStudentAttendanceDAO= new StudentAttendanceDAO();
			objStudentAttendance = objStudentAttendanceDAO.SubmitStudentAttendanceData(objStudentAttendance);
			return objStudentAttendance;
		}

        public StudentAttendance SelectStudentAttendanceSchema(StudentAttendance objStudentAttendance)
        {
            objStudentAttendanceDAO = new StudentAttendanceDAO();
            objStudentAttendance = objStudentAttendanceDAO.SelectStudentAttendanceSchema(objStudentAttendance);
            return objStudentAttendance;
        }

	}
}
