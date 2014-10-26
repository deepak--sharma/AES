using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class DesignationMaster : BaseClassObject
	{

		#region Fields Name ...
		private int? _designationId;
		private string _designationCode;
		private string _designationName;
		private string _description;
		#endregion 

		#region Object Properties ...
		[DataMapping("Designation_Id",PrimaryKey=true)]
		public int? DesignationId
		{
			get
			{
				return _designationId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_designationId = value; 
				}
				else
				{
				throw new Exception("Invalid DesignationId");
				}
			}
		}
		[DataMapping("Designation_Code")]
		public string DesignationCode
		{
			get
			{
				return _designationCode; 
			}
			set 
			{
				if (value.Length<= 50)
				{
					_designationCode = value; 
				}
				else
				{
				throw new Exception("Invalid DesignationCode");
				}
			}
		}
		[DataMapping("Designation_Name")]
		public string DesignationName
		{
			get
			{
				return _designationName; 
			}
			set 
			{
				if (value.Length<= 100)
				{
					_designationName = value; 
				}
				else
				{
				throw new Exception("Invalid DesignationName");
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
