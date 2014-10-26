using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class CompanyMaster : BaseClassObject
	{

		#region Fields Name ...
		private int? _companyId;
		private string _companyName;
		private string _lstNo;
		private string _cstNo;
		private string _exciseNo;
		private string _eccNo;
		private string _ienNo;
		private AddressDetail _companyAddressId;
		#endregion 

		#region Object Properties ...
		[DataMapping("Company_Id",PrimaryKey=true)]
		public int? CompanyId
		{
			get
			{
				return _companyId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_companyId = value; 
				}
				else
				{
				throw new Exception("Invalid CompanyId");
				}
			}
		}
		[DataMapping("Company_Name")]
		public string CompanyName
		{
			get
			{
				return _companyName; 
			}
			set 
			{
				if (value.Length<= 100)
				{
					_companyName = value; 
				}
				else
				{
				throw new Exception("Invalid CompanyName");
				}
			}
		}
		[DataMapping("LST_No")]
		public string LstNo
		{
			get
			{
				return _lstNo; 
			}
			set 
			{
				if (value.Length<= 50)
				{
					_lstNo = value; 
				}
				else
				{
				throw new Exception("Invalid LstNo");
				}
			}
		}
		[DataMapping("CST_No")]
		public string CstNo
		{
			get
			{
				return _cstNo; 
			}
			set 
			{
				if (value.Length<= 50)
				{
					_cstNo = value; 
				}
				else
				{
				throw new Exception("Invalid CstNo");
				}
			}
		}
		[DataMapping("Excise_No")]
		public string ExciseNo
		{
			get
			{
				return _exciseNo; 
			}
			set 
			{
				if (value.Length<= 50)
				{
					_exciseNo = value; 
				}
				else
				{
				throw new Exception("Invalid ExciseNo");
				}
			}
		}
		[DataMapping("ECC_No")]
		public string EccNo
		{
			get
			{
				return _eccNo; 
			}
			set 
			{
				if (value.Length<= 50)
				{
					_eccNo = value; 
				}
				else
				{
				throw new Exception("Invalid EccNo");
				}
			}
		}
		[DataMapping("IEN_No")]
		public string IenNo
		{
			get
			{
				return _ienNo; 
			}
			set 
			{
				if (value.Length<= 50)
				{
					_ienNo = value; 
				}
				else
				{
				throw new Exception("Invalid IenNo");
				}
			}
		}
		[DataMapping("Company_Address_Id",ForeignKey=true)]
		public AddressDetail CompanyAddressObject
		{
			get
			{
				return _companyAddressId; 
			}
			set 
			{
				_companyAddressId = value;
			}
		}
		#endregion 
	}
}
