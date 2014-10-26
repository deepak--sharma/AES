using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class UserRoleMapping : BaseClassObject
	{

		#region Fields Name ...
		private int? _userRoleMappingId;
		private UserManagement _userId;
		private RoleManagement _roleId;
		#endregion 

		#region Object Properties ...
		[DataMapping("User_Role_Mapping_Id",PrimaryKey=true)]
		public int? UserRoleMappingId
		{
			get
			{
				return _userRoleMappingId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_userRoleMappingId = value; 
				}
				else
				{
				throw new Exception("Invalid UserRoleMappingId");
				}
			}
		}
		[DataMapping("User_Id",ForeignKey=true)]
		public UserManagement UserObject
		{
			get
			{
				return _userId; 
			}
			set 
			{
				_userId = value;
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
		#endregion 
	}
}
