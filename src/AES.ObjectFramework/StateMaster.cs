using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class StateMaster : BaseClassObject
	{

		#region Fields Name ...
		private int? _stateId;
		private string _stateName;
		private CountryMaster _countryId;
		private string _description;
		#endregion 

		#region Object Properties ...
		[DataMapping("State_Id",PrimaryKey=true)]
		public int? StateId
		{
			get
			{
				return _stateId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_stateId = value; 
				}
				else
				{
				throw new Exception("Invalid StateId");
				}
			}
		}
		[DataMapping("State_Name")]
		public string StateName
		{
			get
			{
				return _stateName; 
			}
			set 
			{
				if (value.Length<= 100)
				{
					_stateName = value; 
				}
				else
				{
				throw new Exception("Invalid StateName");
				}
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
