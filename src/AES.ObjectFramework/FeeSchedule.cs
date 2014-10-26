using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class FeeSchedule : BaseClassObject
	{

		#region Fields Name ...
		private int? _feeScheduleId;
		private int? _noOfInstances;
		private MetadataMaster _feeProcessModeId;
		private BranchMaster _branchId;
		private ClassMaster _classId;
        private StreamMaster _streamId;
		private DataSet _feeScheduleDetailData = null;
		#endregion 

		#region Object Properties ...
		[DataMapping("Fee_Schedule_Id",PrimaryKey=true)]
		public int? FeeScheduleId
		{
			get
			{
				return _feeScheduleId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_feeScheduleId = value; 
				}
				else
				{
				throw new Exception("Invalid FeeScheduleId");
				}
			}
		}
		[DataMapping("No_Of_Instances")]
		public int? NoOfInstances
		{
			get
			{
				return _noOfInstances; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_noOfInstances = value; 
				}
				else
				{
				throw new Exception("Invalid NoOfInstances");
				}
			}
		}
		[DataMapping("Fee_Process_Mode_Id",ForeignKey=true)]
		public MetadataMaster FeeProcessModeObject
		{
			get
			{
				return _feeProcessModeId; 
			}
			set 
			{
				_feeProcessModeId = value;
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
		public DataSet FeeScheduleDetailData
		{
			get
			{
				return _feeScheduleDetailData; 
			}
			set 
			{
				_feeScheduleDetailData = value;
			}
		}
		#endregion 
	}
}
