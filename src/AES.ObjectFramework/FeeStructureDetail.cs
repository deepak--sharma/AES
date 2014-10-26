using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class FeeStructureDetail : BaseClassObject
	{

		#region Fields Name ...
		private int? _feeStructureDetailId;
		private FeeStructure _feeStructureId;
		private BranchMaster _branchId;
		private ClassMaster _classId;
        private StreamMaster _streamId;       
		private DateTime? _startDate;
		private DateTime? _endDate;
		private DataSet _feeSetupData = null;
		#endregion 

		#region Object Properties ...
		[DataMapping("Fee_Structure_Detail_Id",PrimaryKey=true)]
		public int? FeeStructureDetailId
		{
			get
			{
				return _feeStructureDetailId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_feeStructureDetailId = value; 
				}
				else
				{
				throw new Exception("Invalid FeeStructureDetailId");
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
		[DataMapping("Branch_Id",ForeignKey=true)]
		public BranchMaster BranchObject
		{
			get
			{
				return _branchId; 
			}
			set 
			{
				_branchId = value;
			}
		}
		[DataMapping("Class_Id",ForeignKey=true)]
		public ClassMaster ClassObject
		{
			get
			{
				return _classId; 
			}
			set 
			{
				_classId = value;
			}
		}
        [DataMapping("Stream_Id", ForeignKey = true)]
        public StreamMaster StreamObject
        {
            get { return _streamId; }
            set { _streamId = value; }
        }
		[DataMapping("Start_Date")]
		public DateTime? StartDate
		{
			get
			{
				return _startDate; 
			}
			set 
			{
				if (GeneralUtility.IsDateTime(value) || GeneralUtility.IsNull(value))
				{
					_startDate = value; 
				}
				else
				{
				throw new Exception("Invalid StartDate");
				}
			}
		}
		[DataMapping("End_Date")]
		public DateTime? EndDate
		{
			get
			{
				return _endDate; 
			}
			set 
			{
				if (GeneralUtility.IsDateTime(value) || GeneralUtility.IsNull(value))
				{
					_endDate = value; 
				}
				else
				{
				throw new Exception("Invalid EndDate");
				}
			}
		}
		public DataSet FeeSetupData
		{
			get
			{
				return _feeSetupData; 
			}
			set 
			{
				_feeSetupData = value;
			}
		}
		#endregion 
	}
}
