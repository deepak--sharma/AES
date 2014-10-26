using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class AddressDetail : BaseClassObject
	{

		#region Fields Name ...
		private int? _addressId;
		private string _addressLine1;
		private string _addressLine2;
		private CityMaster _cityId;
		private StateMaster _stateId;
		private CountryMaster _countryId;
		private string _district;
		private int? _pinCode;
		private string _landmark;
		private string _landlineNo;
		private string _mobileNo;
		private string _emailId;
		#endregion 

		#region Object Properties ...
		[DataMapping("Address_Id",PrimaryKey=true)]
		public int? AddressId
		{
			get
			{
				return _addressId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_addressId = value; 
				}
				else
				{
				throw new Exception("Invalid AddressId");
				}
			}
		}
		[DataMapping("Address_Line1")]
		public string AddressLine1
		{
			get
			{
				return _addressLine1; 
			}
			set 
			{
				if (value.Length<= 500)
				{
					_addressLine1 = value; 
				}
				else
				{
				throw new Exception("Invalid AddressLine1");
				}
			}
		}
		[DataMapping("Address_Line2")]
		public string AddressLine2
		{
			get
			{
				return _addressLine2; 
			}
			set 
			{
				if (value.Length<= 500)
				{
					_addressLine2 = value; 
				}
				else
				{
				throw new Exception("Invalid AddressLine2");
				}
			}
		}
		[DataMapping("City_Id",ForeignKey=true)]
		public CityMaster CityObject
		{
			get
			{
				return _cityId; 
			}
			set 
			{
				_cityId = value;
			}
		}
		[DataMapping("State_Id",ForeignKey=true)]
		public StateMaster StateObject
		{
			get
			{
				return _stateId; 
			}
			set 
			{
				_stateId = value;
			}
		}
		[DataMapping("Country_Id",ForeignKey=true)]
		public CountryMaster CountryObject
		{
			get
			{
				return _countryId; 
			}
			set 
			{
				_countryId = value;
			}
		}
		[DataMapping("District")]
		public string District
		{
			get
			{
				return _district; 
			}
			set 
			{
				if (value.Length<= 100)
				{
					_district = value; 
				}
				else
				{
				throw new Exception("Invalid District");
				}
			}
		}
		[DataMapping("Pin_Code")]
		public int? PinCode
		{
			get
			{
				return _pinCode; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_pinCode = value; 
				}
				else
				{
				throw new Exception("Invalid PinCode");
				}
			}
		}
		[DataMapping("Landmark")]
		public string Landmark
		{
			get
			{
				return _landmark; 
			}
			set 
			{
				if (value.Length<= 100)
				{
					_landmark = value; 
				}
				else
				{
				throw new Exception("Invalid Landmark");
				}
			}
		}
		[DataMapping("Landline_No")]
		public string LandlineNo
		{
			get
			{
				return _landlineNo; 
			}
			set 
			{
				if (value.Length<= 15)
				{
					_landlineNo = value; 
				}
				else
				{
				throw new Exception("Invalid LandlineNo");
				}
			}
		}
		[DataMapping("Mobile_No")]
		public string MobileNo
		{
			get
			{
				return _mobileNo; 
			}
			set 
			{
				if (value.Length<= 15)
				{
					_mobileNo = value; 
				}
				else
				{
				throw new Exception("Invalid MobileNo");
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
