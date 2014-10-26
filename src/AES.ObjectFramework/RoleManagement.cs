using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class RoleManagement : BaseClassObject
	{

		#region Fields Name ...
		private int? _roleId;
		private string _roleName;
		private string _description;
		#endregion 

		#region Object Properties ...
		[DataMapping("Role_Id",PrimaryKey=true)]
		public int? RoleId
		{
			get
			{
				return _roleId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_roleId = value; 
				}
				else
				{
				throw new Exception("Invalid RoleId");
				}
			}
		}
		[DataMapping("Role_Name")]
		public string RoleName
		{
			get
			{
				return _roleName; 
			}
			set 
			{
				if (value.Length<= 100)
				{
					_roleName = value; 
				}
				else
				{
				throw new Exception("Invalid RoleName");
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
