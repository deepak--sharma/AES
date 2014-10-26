using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class JoiningMaster : BaseClassObject
	{

		#region Fields Name ...
		private int? _joiningId;
		private string _joiningName;
		private string _description;
		#endregion 

		#region Object Properties ...
		[DataMapping("Joining_Id",PrimaryKey=true)]
		public int? JoiningId
		{
			get
			{
				return _joiningId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_joiningId = value; 
				}
				else
				{
				throw new Exception("Invalid JoiningId");
				}
			}
		}
		[DataMapping("Joining_Name")]
		public string JoiningName
		{
			get
			{
				return _joiningName; 
			}
			set 
			{
				if (value.Length<= 200)
				{
					_joiningName = value; 
				}
				else
				{
				throw new Exception("Invalid JoiningName");
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
