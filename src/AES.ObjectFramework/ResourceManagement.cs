using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class ResourceManagement : BaseClassObject
	{

		#region Fields Name ...
		private int? _resourceId;
		private string _resourceName;
		private string _url;
		private ResourceManagement _parentResourceId;
		#endregion 

		#region Object Properties ...
		[DataMapping("Resource_Id",PrimaryKey=true)]
		public int? ResourceId
		{
			get
			{
				return _resourceId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_resourceId = value; 
				}
				else
				{
				throw new Exception("Invalid ResourceId");
				}
			}
		}
		[DataMapping("Resource_Name")]
		public string ResourceName
		{
			get
			{
				return _resourceName; 
			}
			set 
			{
				if (value.Length<= 100)
				{
					_resourceName = value; 
				}
				else
				{
				throw new Exception("Invalid ResourceName");
				}
			}
		}
		[DataMapping("URL")]
		public string Url
		{
			get
			{
				return _url; 
			}
			set 
			{
				if (value.Length<= 500)
				{
					_url = value; 
				}
				else
				{
				throw new Exception("Invalid Url");
				}
			}
		}
		[DataMapping("Parent_Resource_Id",ForeignKey=true)]
		public ResourceManagement ParentResourceObject
		{
			get
			{
				return _parentResourceId; 
			}
			set 
			{
				_parentResourceId = value;
			}
		}
		#endregion 
	}
}
