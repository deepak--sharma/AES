using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class SchoolMaster : BaseClassObject
	{

		#region Fields Name ...
		private int? _schoolId;
		private string _schoolCode;
		private string _schoolName;
		private int? _schoolHead;
		private DateTime? _establishedOn;
		private string _logo;
		private string _webAddress;
		private AddressDetail _schoolAddressId;
		private string _description;
		#endregion 

		#region Object Properties ...
		[DataMapping("School_Id",PrimaryKey=true)]
		public int? SchoolId
		{
			get
			{
				return _schoolId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_schoolId = value; 
				}
				else
				{
				throw new Exception("Invalid SchoolId");
				}
			}
		}
		[DataMapping("School_Code")]
		public string SchoolCode
		{
			get
			{
				return _schoolCode; 
			}
			set 
			{
				if (value.Length<= 50)
				{
					_schoolCode = value; 
				}
				else
				{
				throw new Exception("Invalid SchoolCode");
				}
			}
		}
		[DataMapping("School_Name")]
		public string SchoolName
		{
			get
			{
				return _schoolName; 
			}
			set 
			{
				if (value.Length<= 100)
				{
					_schoolName = value; 
				}
				else
				{
				throw new Exception("Invalid SchoolName");
				}
			}
		}
		[DataMapping("School_Head")]
		public int? SchoolHead
		{
			get
			{
				return _schoolHead; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_schoolHead = value; 
				}
				else
				{
				throw new Exception("Invalid SchoolHead");
				}
			}
		}
		[DataMapping("Established_On")]
		public DateTime? EstablishedOn
		{
			get
			{
				return _establishedOn; 
			}
			set 
			{
				if (GeneralUtility.IsDateTime(value) || GeneralUtility.IsNull(value))
				{
					_establishedOn = value; 
				}
				else
				{
				throw new Exception("Invalid EstablishedOn");
				}
			}
		}
		[DataMapping("Logo")]
		public string Logo
		{
			get
			{
				return _logo; 
			}
			set 
			{
				if (value.Length<= 100)
				{
					_logo = value; 
				}
				else
				{
				throw new Exception("Invalid Logo");
				}
			}
		}
		[DataMapping("Web_Address")]
		public string WebAddress
		{
			get
			{
				return _webAddress; 
			}
			set 
			{
				if (value.Length<= 100)
				{
					_webAddress = value; 
				}
				else
				{
				throw new Exception("Invalid WebAddress");
				}
			}
		}
		[DataMapping("School_Address_Id",ForeignKey=true)]
		public AddressDetail SchoolAddressObject
		{
			get
			{
				return _schoolAddressId; 
			}
			set 
			{
				_schoolAddressId = value;
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
