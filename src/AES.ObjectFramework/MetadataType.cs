using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class MetadataType : BaseClassObject
	{

		#region Fields Name ...
		private int? _metadataTypeId;
		private string _metadataTypeName;
		#endregion 

		#region Object Properties ...
		[DataMapping("Metadata_Type_Id",PrimaryKey=true)]
		public int? MetadataTypeId
		{
			get
			{
				return _metadataTypeId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_metadataTypeId = value; 
				}
				else
				{
				throw new Exception("Invalid MetadataTypeId");
				}
			}
		}
		[DataMapping("Metadata_Type_Name")]
		public string MetadataTypeName
		{
			get
			{
				return _metadataTypeName; 
			}
			set 
			{
				if (value.Length<= 100)
				{
					_metadataTypeName = value; 
				}
				else
				{
				throw new Exception("Invalid MetadataTypeName");
				}
			}
		}
		#endregion 
	}
}
