using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class CountryMaster : BaseClassObject
	{

		#region Fields Name ...
		private int? _countryId;
		private string _countryName;
		private string _description;
		#endregion 

		#region Object Properties ...
		[DataMapping("Country_Id",PrimaryKey=true)]
		public int? CountryId
		{
			get
			{
				return _countryId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_countryId = value; 
				}
				else
				{
				throw new Exception("Invalid CountryId");
				}
			}
		}
		[DataMapping("Country_Name")]
		public string CountryName
		{
			get
			{
				return _countryName; 
			}
			set 
			{
				if (value.Length<= 100)
				{
					_countryName = value; 
				}
				else
				{
				throw new Exception("Invalid CountryName");
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
