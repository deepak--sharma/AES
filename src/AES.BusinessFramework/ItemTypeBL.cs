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
	public class ItemTypeBL
	{
		private ItemTypeDAO objItemTypeDAO = null;

		public ItemType SelectItemType(ItemType objItemType)
		{
			objItemTypeDAO= new ItemTypeDAO();
			objItemType = objItemTypeDAO.SelectItemType(objItemType);
			return objItemType;
		}

		public ItemType InsertItemType(ItemType objItemType)
		{
			objItemTypeDAO= new ItemTypeDAO();
			objItemType = objItemTypeDAO.InsertItemType(objItemType);
			return objItemType;
		}

		public ItemType UpdateItemType(ItemType objItemType)
		{
			objItemTypeDAO= new ItemTypeDAO();
			objItemType = objItemTypeDAO.UpdateItemType(objItemType);
			return objItemType;
		}

		public ItemType ActivateDeactivateItemType(ItemType objItemType)
		{
			objItemTypeDAO= new ItemTypeDAO();
			objItemType = objItemTypeDAO.ActivateDeactivateItemType(objItemType);
			return objItemType;
		}

		public ItemType SelectRecordById(ItemType objItemType)
		{
			objItemTypeDAO = new ItemTypeDAO();
			objItemType = objItemTypeDAO.SelectRecordById(objItemType);
			if (!Convert.ToBoolean(objItemType.IsRecordChanged)
					&& objItemType.DbOperationStatus==CommonConstant.SUCCEED)
			{
				objItemType.ConvertToObjectFromDataset(1);
			}
			return objItemType ;
		}
	}
}
