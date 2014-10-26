using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class FeeRegister : BaseClassObject
	{

		#region Fields Name ...
		private int? _feeRegisterId;
		private FeeStructure _feeStructureId;
		private StudentDetail _studentId;
		private FeeMaster _componentId;
		private decimal? _componentAmount;
		private int? _componentType;
		private DateTime? _processDate;
		#endregion 

		#region Object Properties ...
		[DataMapping("Fee_Register_Id",PrimaryKey=true)]
		public int? FeeRegisterId
		{
			get
			{
				return _feeRegisterId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_feeRegisterId = value; 
				}
				else
				{
				throw new Exception("Invalid FeeRegisterId");
				}
			}
		}
		[DataMapping("Fee_Structure_Id",ForeignKey=true)]
		public FeeStructure FeeStructureObject
		{
			get
			{
				return _feeStructureId; 
			}
			set 
			{
				_feeStructureId = value;
			}
		}
		[DataMapping("Student_Id",ForeignKey=true)]
		public StudentDetail StudentObject
		{
			get
			{
				return _studentId; 
			}
			set 
			{
				_studentId = value;
			}
		}
		[DataMapping("Component_Id",ForeignKey=true)]
		public FeeMaster ComponentObject
		{
			get
			{
				return _componentId; 
			}
			set 
			{
				_componentId = value;
			}
		}
		[DataMapping("Component_Amount")]
		public decimal? ComponentAmount
		{
			get
			{
				return _componentAmount; 
			}
			set 
			{
				if (GeneralUtility.IsDecimal(value) || GeneralUtility.IsNull(value))
				{
					_componentAmount = value; 
				}
				else
				{
				throw new Exception("Invalid ComponentAmount");
				}
			}
		}
		[DataMapping("Component_Type")]
		public int? ComponentType
		{
			get
			{
				return _componentType; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_componentType = value; 
				}
				else
				{
				throw new Exception("Invalid ComponentType");
				}
			}
		}
		[DataMapping("Process_Date")]
		public DateTime? ProcessDate
		{
			get
			{
				return _processDate; 
			}
			set 
			{
				if (GeneralUtility.IsDateTime(value) || GeneralUtility.IsNull(value))
				{
					_processDate = value; 
				}
				else
				{
				throw new Exception("Invalid ProcessDate");
				}
			}
		}
		#endregion 
	}
}
