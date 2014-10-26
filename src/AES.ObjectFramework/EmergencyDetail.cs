using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class EmergencyDetail : BaseClassObject
	{

		#region Fields Name ...
		private int? _emergencyDetailId;
		private string _contactPerson;
		private string _relation;
		private string _contactNumber;
		private string _address;
		private string _emailId;
		#endregion 

		#region Object Properties ...
		[DataMapping("Emergency_Detail_Id",PrimaryKey=true)]
		public int? EmergencyDetailId
		{
			get
			{
				return _emergencyDetailId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_emergencyDetailId = value; 
				}
				else
				{
				throw new Exception("Invalid EmergencyDetailId");
				}
			}
		}
		[DataMapping("Contact_Person")]
		public string ContactPerson
		{
			get
			{
				return _contactPerson; 
			}
			set 
			{
				if (value.Length<= 100)
				{
					_contactPerson = value; 
				}
				else
				{
				throw new Exception("Invalid ContactPerson");
				}
			}
		}
		[DataMapping("Relation")]
		public string Relation
		{
			get
			{
				return _relation; 
			}
			set 
			{
				if (value.Length<= 50)
				{
					_relation = value; 
				}
				else
				{
				throw new Exception("Invalid Relation");
				}
			}
		}
		[DataMapping("Contact_Number")]
		public string ContactNumber
		{
			get
			{
				return _contactNumber; 
			}
			set 
			{
				if (value.Length<= 20)
				{
					_contactNumber = value; 
				}
				else
				{
				throw new Exception("Invalid ContactNumber");
				}
			}
		}
		[DataMapping("Address")]
		public string Address
		{
			get
			{
				return _address; 
			}
			set 
			{
				if (value.Length<= 500)
				{
					_address = value; 
				}
				else
				{
				throw new Exception("Invalid Address");
				}
			}
		}
		[DataMapping("Email_Id")]
		public string EmailId
		{
			get
			{
				return _emailId; 
			}
			set 
			{
				if (value.Length<= 100)
				{
					_emailId = value; 
				}
				else
				{
				throw new Exception("Invalid EmailId");
				}
			}
		}
		#endregion 
	}
}
