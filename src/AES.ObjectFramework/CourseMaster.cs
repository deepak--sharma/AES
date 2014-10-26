using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class CourseMaster : BaseClassObject
	{

		#region Fields Name ...
		private int? _courseId;
		private string _courseName;
		private string _description;
		#endregion 

		#region Object Properties ...
		[DataMapping("Course_Id",PrimaryKey=true)]
		public int? CourseId
		{
			get
			{
				return _courseId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_courseId = value; 
				}
				else
				{
				throw new Exception("Invalid CourseId");
				}
			}
		}
		[DataMapping("Course_Name")]
		public string CourseName
		{
			get
			{
				return _courseName; 
			}
			set 
			{
				if (value.Length<= 100)
				{
					_courseName = value; 
				}
				else
				{
				throw new Exception("Invalid CourseName");
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
