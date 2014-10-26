using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class FeeStructure : BaseClassObject
	{

		#region Fields Name ...
		private int? _feeStructureId;
		private string _feeStructureName;
		private string _description;
		#endregion 

		#region Object Properties ...
		[DataMapping("Fee_Structure_Id",PrimaryKey=true)]
		public int? FeeStructureId
		{
			get
			{
				return _feeStructureId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_feeStructureId = value; 
				}
				else
				{
				throw new Exception("Invalid FeeStructureId");
				}
			}
		}
		[DataMapping("Fee_Structure_Name")]
		public string FeeStructureName
		{
			get
			{
				return _feeStructureName; 
			}
			set 
			{
				if (value.Length<= 100)
				{
					_feeStructureName = value; 
				}
				else
				{
				throw new Exception("Invalid FeeStructureName");
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
