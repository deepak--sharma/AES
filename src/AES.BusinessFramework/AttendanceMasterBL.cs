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
	public class AttendanceMasterBL
	{
		private AttendanceMasterDAO objAttendanceMasterDAO = null;

		public AttendanceMaster SelectAttendanceMaster(AttendanceMaster objAttendanceMaster)
		{
			objAttendanceMasterDAO= new AttendanceMasterDAO();
			objAttendanceMaster = objAttendanceMasterDAO.SelectAttendanceMaster(objAttendanceMaster);
			return objAttendanceMaster;
		}

		public AttendanceMaster InsertAttendanceMaster(AttendanceMaster objAttendanceMaster)
		{
			objAttendanceMasterDAO= new AttendanceMasterDAO();
			objAttendanceMaster = objAttendanceMasterDAO.InsertAttendanceMaster(objAttendanceMaster);
			return objAttendanceMaster;
		}

		public AttendanceMaster UpdateAttendanceMaster(AttendanceMaster objAttendanceMaster)
		{
			objAttendanceMasterDAO= new AttendanceMasterDAO();
			objAttendanceMaster = objAttendanceMasterDAO.UpdateAttendanceMaster(objAttendanceMaster);
			return objAttendanceMaster;
		}

		public AttendanceMaster ActivateDeactivateAttendanceMaster(AttendanceMaster objAttendanceMaster)
		{
			objAttendanceMasterDAO= new AttendanceMasterDAO();
			objAttendanceMaster = objAttendanceMasterDAO.ActivateDeactivateAttendanceMaster(objAttendanceMaster);
			return objAttendanceMaster;
		}

		public AttendanceMaster SelectRecordById(AttendanceMaster objAttendanceMaster)
		{
			objAttendanceMasterDAO = new AttendanceMasterDAO();
			objAttendanceMaster = objAttendanceMasterDAO.SelectRecordById(objAttendanceMaster);
			if (!Convert.ToBoolean(objAttendanceMaster.IsRecordChanged)
					&& objAttendanceMaster.DbOperationStatus==CommonConstant.SUCCEED)
			{
				objAttendanceMaster.ConvertToObjectFromDataset(1);
			}
			return objAttendanceMaster ;
		}
	}
}
