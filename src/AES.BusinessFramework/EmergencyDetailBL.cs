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
	public class EmergencyDetailBL
	{
		private EmergencyDetailDAO objEmergencyDetailDAO = null;

		public EmergencyDetail SelectEmergencyDetail(EmergencyDetail objEmergencyDetail)
		{
			objEmergencyDetailDAO= new EmergencyDetailDAO();
			objEmergencyDetail = objEmergencyDetailDAO.SelectEmergencyDetail(objEmergencyDetail);
			return objEmergencyDetail;
		}

		public EmergencyDetail InsertEmergencyDetail(EmergencyDetail objEmergencyDetail)
		{
			objEmergencyDetailDAO= new EmergencyDetailDAO();
			objEmergencyDetail = objEmergencyDetailDAO.InsertEmergencyDetail(objEmergencyDetail);
			return objEmergencyDetail;
		}

		public EmergencyDetail UpdateEmergencyDetail(EmergencyDetail objEmergencyDetail)
		{
			objEmergencyDetailDAO= new EmergencyDetailDAO();
			objEmergencyDetail = objEmergencyDetailDAO.UpdateEmergencyDetail(objEmergencyDetail);
			return objEmergencyDetail;
		}

		public EmergencyDetail SelectRecordById(EmergencyDetail objEmergencyDetail)
		{
			objEmergencyDetailDAO = new EmergencyDetailDAO();
			objEmergencyDetail = objEmergencyDetailDAO.SelectRecordById(objEmergencyDetail);
			if (!Convert.ToBoolean(objEmergencyDetail.IsRecordChanged)
					&& objEmergencyDetail.DbOperationStatus==CommonConstant.SUCCEED)
			{
				objEmergencyDetail.ConvertToObjectFromDataset(1);
			}
			return objEmergencyDetail ;
		}
	}
}
