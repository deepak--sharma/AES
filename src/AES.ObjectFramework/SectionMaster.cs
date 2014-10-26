using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class SectionMaster : BaseClassObject
	{

		#region Fields Name ...
		private int? _sectionId;		
		private string _sectionName;
		private string _description;
		#endregion 

		#region Object Properties ...
		[DataMapping("Section_Id",PrimaryKey=true)]
		public int? SectionId
		{
			get
			{
				return _sectionId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_sectionId = value; 
				}
				else
				{
				throw new Exception("Invalid SectionId");
				}
			}
		}
		[DataMapping("Section_Name")]
		public string SectionName
		{
			get
			{
				return _sectionName; 
			}
			set 
			{
				if (value.Length<= 100)
				{
					_sectionName = value; 
				}
				else
				{
				throw new Exception("Invalid SectionName");
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
