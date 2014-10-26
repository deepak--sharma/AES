using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class CityMaster : BaseClassObject
	{

		#region Fields Name ...
		private int? _cityId;
		private string _cityName;
		private StateMaster _stateId;
		private bool? _isDefaultSelected;
		private string _description;
		#endregion 

		#region Object Properties ...
		[DataMapping("City_Id",PrimaryKey=true)]
		public int? CityId
		{
			get
			{
				return _cityId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_cityId = value; 
				}
				else
				{
				throw new Exception("Invalid CityId");
				}
			}
		}
		[DataMapping("City_Name")]
		public string CityName
		{
			get
			{
				return _cityName; 
			}
			set 
			{
				if (value.Length<= 100)
				{
					_cityName = value; 
				}
				else
				{
				throw new Exception("Invalid CityName");
				}
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
		[DataMapping("Is_Default_Selected")]
		public bool? IsDefaultSelected
		{
			get
			{
				return _isDefaultSelected; 
			}
			set 
			{
				if (GeneralUtility.IsBoolean(value) || GeneralUtility.IsNull(value))
				{
					_isDefaultSelected = value; 
				}
				else
				{
				throw new Exception("Invalid IsDefaultSelected");
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
