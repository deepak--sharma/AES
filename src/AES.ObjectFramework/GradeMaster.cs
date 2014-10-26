using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class GradeMaster : BaseClassObject
	{

		#region Fields Name ...
		private int? _gradeId;
		private string _gradeName;
		private string _description;
		#endregion 

		#region Object Properties ...
		[DataMapping("Grade_Id",PrimaryKey=true)]
		public int? GradeId
		{
			get
			{
				return _gradeId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_gradeId = value; 
				}
				else
				{
				throw new Exception("Invalid GradeId");
				}
			}
		}
		[DataMapping("Grade_Name")]
		public string GradeName
		{
			get
			{
				return _gradeName; 
			}
			set 
			{
				if (value.Length<= 100)
				{
					_gradeName = value; 
				}
				else
				{
				throw new Exception("Invalid GradeName");
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
