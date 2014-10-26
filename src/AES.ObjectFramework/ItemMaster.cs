using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class ItemMaster : BaseClassObject
	{

		#region Fields Name ...
		private int? _itemId;
		private string _itemCode;
		private string _barCode;
		private ClassSubjectMapping _classSubjectId;
		private string _writerName;
		private string _publisherName;
		private MetadataMaster _mediumId;
		private string _edition;
		private DateTime? _publishDate;
		private string _volume;
		private RackMaster _rackId;
		private string _cellId;
		private ItemType _itemTypeId;
		#endregion 

		#region Object Properties ...
		[DataMapping("Item_ID",PrimaryKey=true)]
		public int? ItemId
		{
			get
			{
				return _itemId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_itemId = value; 
				}
				else
				{
				throw new Exception("Invalid ItemId");
				}
			}
		}
		[DataMapping("Item_Code")]
		public string ItemCode
		{
			get
			{
				return _itemCode; 
			}
			set 
			{
				if (value.Length<= 50)
				{
					_itemCode = value; 
				}
				else
				{
				throw new Exception("Invalid ItemCode");
				}
			}
		}
		[DataMapping("Bar_Code")]
		public string BarCode
		{
			get
			{
				return _barCode; 
			}
			set 
			{
				if (value.Length<= 50)
				{
					_barCode = value; 
				}
				else
				{
				throw new Exception("Invalid BarCode");
				}
			}
		}
		[DataMapping("Class_Subject_ID",ForeignKey=true)]
		public ClassSubjectMapping ClassSubjectObject
		{
			get
			{
				return _classSubjectId; 
			}
			set 
			{
				_classSubjectId = value;
			}
		}
		[DataMapping("Writer_Name")]
		public string WriterName
		{
			get
			{
				return _writerName; 
			}
			set 
			{
				if (value.Length<= 100)
				{
					_writerName = value; 
				}
				else
				{
				throw new Exception("Invalid WriterName");
				}
			}
		}
		[DataMapping("Publisher_Name")]
		public string PublisherName
		{
			get
			{
				return _publisherName; 
			}
			set 
			{
				if (value.Length<= 100)
				{
					_publisherName = value; 
				}
				else
				{
				throw new Exception("Invalid PublisherName");
				}
			}
		}
		[DataMapping("Medium_Id",ForeignKey=true)]
		public MetadataMaster MediumObject
		{
			get
			{
				return _mediumId; 
			}
			set 
			{
				_mediumId = value;
			}
		}
		[DataMapping("Edition")]
		public string Edition
		{
			get
			{
				return _edition; 
			}
			set 
			{
				if (value.Length<= 20)
				{
					_edition = value; 
				}
				else
				{
				throw new Exception("Invalid Edition");
				}
			}
		}
		[DataMapping("Publish_Date")]
		public DateTime? PublishDate
		{
			get
			{
				return _publishDate; 
			}
			set 
			{
				if (GeneralUtility.IsDateTime(value) || GeneralUtility.IsNull(value))
				{
					_publishDate = value; 
				}
				else
				{
				throw new Exception("Invalid PublishDate");
				}
			}
		}
		[DataMapping("Volume")]
		public string Volume
		{
			get
			{
				return _volume; 
			}
			set 
			{
				if (value.Length<= 20)
				{
					_volume = value; 
				}
				else
				{
				throw new Exception("Invalid Volume");
				}
			}
		}
		[DataMapping("Rack_ID",ForeignKey=true)]
		public RackMaster RackObject
		{
			get
			{
				return _rackId; 
			}
			set 
			{
				_rackId = value;
			}
		}
		[DataMapping("Cell_Id")]
		public string CellId
		{
			get
			{
				return _cellId; 
			}
			set 
			{
				if (value.Length<= 20)
				{
					_cellId = value; 
				}
				else
				{
				throw new Exception("Invalid CellId");
				}
			}
		}
		[DataMapping("Item_Type_ID",ForeignKey=true)]
		public ItemType ItemTypeObject
		{
			get
			{
				return _itemTypeId; 
			}
			set 
			{
				_itemTypeId = value;
			}
		}
		#endregion 
	}
}
