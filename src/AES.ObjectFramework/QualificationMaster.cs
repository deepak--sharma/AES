using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class QualificationMaster : BaseClassObject
	{

		#region Fields Name ...
		private int? _qualificationId;
		private string _qualificationName;
		private string _description;
		#endregion 

		#region Object Properties ...
		[DataMapping("Qualification_Id",PrimaryKey=true)]
		public int? QualificationId
		{
			get
			{
				return _qualificationId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_qualificationId = value; 
				}
				else
				{
				throw new Exception("Invalid QualificationId");
				}
			}
		}
		[DataMapping("Qualification_Name")]
		public string QualificationName
		{
			get
			{
				return _qualificationName; 
			}
			set 
			{
				if (value.Length<= 100)
				{
					_qualificationName = value; 
				}
				else
				{
				throw new Exception("Invalid QualificationName");
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
