using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class RoleResourceMapping : BaseClassObject
	{

		#region Fields Name ...
		private int? _roleResourceMappingId;
		private RoleManagement _roleId;
		private ResourceManagement _resourceId;
		private bool? _view;
		private bool? _create;
		private bool? _edit;
		private bool? _delete;
		private bool? _download;
		#endregion 

		#region Object Properties ...
		[DataMapping("Role_Resource_Mapping_Id",PrimaryKey=true)]
		public int? RoleResourceMappingId
		{
			get
			{
				return _roleResourceMappingId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_roleResourceMappingId = value; 
				}
				else
				{
				throw new Exception("Invalid RoleResourceMappingId");
				}
			}
		}
		[DataMapping("Role_Id",ForeignKey=true)]
		public RoleManagement RoleObject
		{
			get
			{
				return _roleId; 
			}
			set 
			{
				_roleId = value;
			}
		}
		[DataMapping("Resource_Id",ForeignKey=true)]
		public ResourceManagement ResourceObject
		{
			get
			{
				return _resourceId; 
			}
			set 
			{
				_resourceId = value;
			}
		}
		[DataMapping("View")]
		public bool? View
		{
			get
			{
				return _view; 
			}
			set 
			{
				if (GeneralUtility.IsBoolean(value) || GeneralUtility.IsNull(value))
				{
					_view = value; 
				}
				else
				{
				throw new Exception("Invalid View");
				}
			}
		}
		[DataMapping("Create")]
		public bool? Create
		{
			get
			{
				return _create; 
			}
			set 
			{
				if (GeneralUtility.IsBoolean(value) || GeneralUtility.IsNull(value))
				{
					_create = value; 
				}
				else
				{
				throw new Exception("Invalid Create");
				}
			}
		}
		[DataMapping("Edit")]
		public bool? Edit
		{
			get
			{
				return _edit; 
			}
			set 
			{
				if (GeneralUtility.IsBoolean(value) || GeneralUtility.IsNull(value))
				{
					_edit = value; 
				}
				else
				{
				throw new Exception("Invalid Edit");
				}
			}
		}
		[DataMapping("Delete")]
		public bool? Delete
		{
			get
			{
				return _delete; 
			}
			set 
			{
				if (GeneralUtility.IsBoolean(value) || GeneralUtility.IsNull(value))
				{
					_delete = value; 
				}
				else
				{
				throw new Exception("Invalid Delete");
				}
			}
		}
		[DataMapping("Download")]
		public bool? Download
		{
			get
			{
				return _download; 
			}
			set 
			{
				if (GeneralUtility.IsBoolean(value) || GeneralUtility.IsNull(value))
				{
					_download = value; 
				}
				else
				{
				throw new Exception("Invalid Download");
				}
			}
		}
		#endregion 
	}
}
