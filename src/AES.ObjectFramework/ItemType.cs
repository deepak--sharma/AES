using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class ItemType : BaseClassObject
	{

		#region Fields Name ...
		private int? _itemTypeId;
		private string _itemTypeName;
		private string _orderByFields;
		private string _description;
		#endregion 

		#region Object Properties ...
		[DataMapping("Item_Type_ID",PrimaryKey=true)]
		public int? ItemTypeId
		{
			get
			{
				return _itemTypeId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_itemTypeId = value; 
				}
				else
				{
				throw new Exception("Invalid ItemTypeId");
				}
			}
		}
		[DataMapping("Item_Type_Name")]
		public string ItemTypeName
		{
			get
			{
				return _itemTypeName; 
			}
			set 
			{
				if (value.Length<= 100)
				{
					_itemTypeName = value; 
				}
				else
				{
				throw new Exception("Invalid ItemTypeName");
				}
			}
		}
		[DataMapping("Order_By_Fields")]
		public string OrderByFields
		{
			get
			{
				return _orderByFields; 
			}
			set 
			{
				if (value.Length<= 500)
				{
					_orderByFields = value; 
				}
				else
				{
				throw new Exception("Invalid OrderByFields");
				}
			}
		}
		[DataMapping("Description")]
		public string Description
		{
			get
			{
				return _description; 
			}
			set 
			{
				if (value.Length<= 500)
				{
					_description = value; 
				}
				else
				{
				throw new Exception("Invalid Description");
				}
			}
		}
		#endregion 
	}
}
