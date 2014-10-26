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
	public class RoomMasterBL
	{
		private RoomMasterDAO objRoomMasterDAO = null;

		public RoomMaster SelectRoomMaster(RoomMaster objRoomMaster)
		{
			objRoomMasterDAO= new RoomMasterDAO();
			objRoomMaster = objRoomMasterDAO.SelectRoomMaster(objRoomMaster);
			return objRoomMaster;
		}

		public RoomMaster InsertRoomMaster(RoomMaster objRoomMaster)
		{
			objRoomMasterDAO= new RoomMasterDAO();
			objRoomMaster = objRoomMasterDAO.InsertRoomMaster(objRoomMaster);
			return objRoomMaster;
		}

		public RoomMaster UpdateRoomMaster(RoomMaster objRoomMaster)
		{
			objRoomMasterDAO= new RoomMasterDAO();
			objRoomMaster = objRoomMasterDAO.UpdateRoomMaster(objRoomMaster);
			return objRoomMaster;
		}

		public RoomMaster ActivateDeactivateRoomMaster(RoomMaster objRoomMaster)
		{
			objRoomMasterDAO= new RoomMasterDAO();
			objRoomMaster = objRoomMasterDAO.ActivateDeactivateRoomMaster(objRoomMaster);
			return objRoomMaster;
		}

		public RoomMaster SelectRecordById(RoomMaster objRoomMaster)
		{
			objRoomMasterDAO = new RoomMasterDAO();
			objRoomMaster = objRoomMasterDAO.SelectRecordById(objRoomMaster);
			if (!Convert.ToBoolean(objRoomMaster.IsRecordChanged)
					&& objRoomMaster.DbOperationStatus==CommonConstant.SUCCEED)
			{
				objRoomMaster.ConvertToObjectFromDataset(1);
			}
			return objRoomMaster ;
		}
	}
}
