using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class MedicalMaster : BaseClassObject
	{

		#region Fields Name ...
		private int? _medicalId;
		private string _medicalName;
		private string _description;
		#endregion 

		#region Object Properties ...
		[DataMapping("Medical_Id",PrimaryKey=true)]
		public int? MedicalId
		{
			get
			{
				return _medicalId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_medicalId = value; 
				}
				else
				{
				throw new Exception("Invalid MedicalId");
				}
			}
		}
		[DataMapping("Medical_Name")]
		public string MedicalName
		{
			get
			{
				return _medicalName; 
			}
			set 
			{
				if (value.Length<= 200)
				{
					_medicalName = value; 
				}
				else
				{
				throw new Exception("Invalid MedicalName");
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
