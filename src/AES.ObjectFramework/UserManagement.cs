using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class UserManagement : BaseClassObject
	{

		#region Fields Name ...
		private int? _userId;
		private string _userName;
		private string _password;
		private MetadataMaster _userType;
		private DateTime? _lastLogin;
		private bool? _status;
		#endregion 

		#region Object Properties ...
		[DataMapping("User_Id",PrimaryKey=true)]
		public int? UserId
		{
			get
			{
				return _userId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_userId = value; 
				}
				else
				{
				throw new Exception("Invalid UserId");
				}
			}
		}
		[DataMapping("User_Name")]
		public string UserName
		{
			get
			{
				return _userName; 
			}
			set 
			{
				if (value.Length<= 100)
				{
					_userName = value; 
				}
				else
				{
				throw new Exception("Invalid UserName");
				}
			}
		}
		[DataMapping("Password")]
		public string Password
		{
			get
			{
				return _password; 
			}
			set 
			{
				if (value.Length<= 500)
				{
					_password = value; 
				}
				else
				{
				throw new Exception("Invalid Password");
				}
			}
		}
		[DataMapping("User_Type",ForeignKey=true)]
		public MetadataMaster UserType
		{
			get
			{
				return _userType; 
			}
			set 
			{
				_userType = value;
			}
		}
		[DataMapping("Last_Login")]
		public DateTime? LastLogin
		{
			get
			{
				return _lastLogin; 
			}
			set 
			{
				if (GeneralUtility.IsDateTime(value) || GeneralUtility.IsNull(value))
				{
					_lastLogin = value; 
				}
				else
				{
				throw new Exception("Invalid LastLogin");
				}
			}
		}
		[DataMapping("Status")]
		public bool? Status
		{
			get
			{
				return _status; 
			}
			set 
			{
				if (GeneralUtility.IsBoolean(value) || GeneralUtility.IsNull(value))
				{
					_status = value; 
				}
				else
				{
				throw new Exception("Invalid Status");
				}
			}
		}
		#endregion 
	}
}
