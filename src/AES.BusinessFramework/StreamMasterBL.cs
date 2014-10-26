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
	public class StreamMasterBL
	{
		private StreamMasterDAO objStreamMasterDAO = null;

		public StreamMaster SelectStreamMaster(StreamMaster objStreamMaster)
		{
			objStreamMasterDAO= new StreamMasterDAO();
			objStreamMaster = objStreamMasterDAO.SelectStreamMaster(objStreamMaster);
			return objStreamMaster;
		}

		public StreamMaster InsertStreamMaster(StreamMaster objStreamMaster)
		{
			objStreamMasterDAO= new StreamMasterDAO();
			objStreamMaster = objStreamMasterDAO.InsertStreamMaster(objStreamMaster);
			return objStreamMaster;
		}

		public StreamMaster UpdateStreamMaster(StreamMaster objStreamMaster)
		{
			objStreamMasterDAO= new StreamMasterDAO();
			objStreamMaster = objStreamMasterDAO.UpdateStreamMaster(objStreamMaster);
			return objStreamMaster;
		}

		public StreamMaster ActivateDeactivateStreamMaster(StreamMaster objStreamMaster)
		{
			objStreamMasterDAO= new StreamMasterDAO();
			objStreamMaster = objStreamMasterDAO.ActivateDeactivateStreamMaster(objStreamMaster);
			return objStreamMaster;
		}

		public StreamMaster SelectRecordById(StreamMaster objStreamMaster)
		{
			objStreamMasterDAO = new StreamMasterDAO();
			objStreamMaster = objStreamMasterDAO.SelectRecordById(objStreamMaster);
			if (!Convert.ToBoolean(objStreamMaster.IsRecordChanged)
					&& objStreamMaster.DbOperationStatus==CommonConstant.SUCCEED)
			{
				objStreamMaster.ConvertToObjectFromDataset(1);
			}
			return objStreamMaster ;
		}
	}
}
