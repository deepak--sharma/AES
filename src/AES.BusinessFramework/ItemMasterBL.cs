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
	public class ItemMasterBL
	{
		private ItemMasterDAO objItemMasterDAO = null;

		public ItemMaster SelectItemMaster(ItemMaster objItemMaster)
		{
			objItemMasterDAO= new ItemMasterDAO();
			objItemMaster = objItemMasterDAO.SelectItemMaster(objItemMaster);
			return objItemMaster;
		}

		public ItemMaster InsertItemMaster(ItemMaster objItemMaster)
		{
			objItemMasterDAO= new ItemMasterDAO();
			objItemMaster = objItemMasterDAO.InsertItemMaster(objItemMaster);
			return objItemMaster;
		}

		public ItemMaster UpdateItemMaster(ItemMaster objItemMaster)
		{
			objItemMasterDAO= new ItemMasterDAO();
			objItemMaster = objItemMasterDAO.UpdateItemMaster(objItemMaster);
			return objItemMaster;
		}

		public ItemMaster ActivateDeactivateItemMaster(ItemMaster objItemMaster)
		{
			objItemMasterDAO= new ItemMasterDAO();
			objItemMaster = objItemMasterDAO.ActivateDeactivateItemMaster(objItemMaster);
			return objItemMaster;
		}

		public ItemMaster SelectRecordById(ItemMaster objItemMaster)
		{
			objItemMasterDAO = new ItemMasterDAO();
			objItemMaster = objItemMasterDAO.SelectRecordById(objItemMaster);
			if (!Convert.ToBoolean(objItemMaster.IsRecordChanged)
					&& objItemMaster.DbOperationStatus==CommonConstant.SUCCEED)
			{
				objItemMaster.ConvertToObjectFromDataset(1);
			}
			return objItemMaster ;
		}
	}
}
