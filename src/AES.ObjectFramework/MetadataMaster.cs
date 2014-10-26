using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class MetadataMaster : BaseClassObject
	{

		#region Fields Name ...
		private int? _metadataId;
		private MetadataType _metadataTypeId;
		private string _metadataName;
		private string _metadataCode;
		private bool? _isSystemType;
		#endregion 

		#region Object Properties ...
		[DataMapping("Metadata_Id",PrimaryKey=true)]
		public int? MetadataId
		{
			get
			{
				return _metadataId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_metadataId = value; 
				}
				else
				{
				throw new Exception("Invalid MetadataId");
				}
			}
		}
		[DataMapping("Metadata_Type_Id",ForeignKey=true)]
		public MetadataType MetadataTypeObject
		{
			get
			{
				return _metadataTypeId; 
			}
			set 
			{
				_metadataTypeId = value;
			}
		}
		[DataMapping("Metadata_Name")]
		public string MetadataName
		{
			get
			{
				return _metadataName; 
			}
			set 
			{
				if (value.Length<= 100)
				{
					_metadataName = value; 
				}
				else
				{
				throw new Exception("Invalid MetadataName");
				}
			}
		}
		[DataMapping("Metadata_Code")]
		public string MetadataCode
		{
			get
			{
				return _metadataCode; 
			}
			set 
			{
				if (value.Length<= 50)
				{
					_metadataCode = value; 
				}
				else
				{
				throw new Exception("Invalid MetadataCode");
				}
			}
		}
		[DataMapping("Is_System_Type")]
		public bool? IsSystemType
		{
			get
			{
				return _isSystemType; 
			}
			set 
			{
				if (GeneralUtility.IsBoolean(value) || GeneralUtility.IsNull(value))
				{
					_isSystemType = value; 
				}
				else
				{
				throw new Exception("Invalid IsSystemType");
				}
			}
		}
		#endregion 
	}
}
