using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class LateFeeSetup : BaseClassObject
	{

		#region Fields Name ...
		private int? _lateFeeId;
		private BranchMaster _branchId;
		private ClassMaster _classId;
		private StreamMaster _streamId;
		private DataSet _lateFeeSetupDetailData = null;
		#endregion 

		#region Object Properties ...
		[DataMapping("Late_Fee_Id",PrimaryKey=true)]
		public int? LateFeeId
		{
			get
			{
				return _lateFeeId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_lateFeeId = value; 
				}
				else
				{
				throw new Exception("Invalid LateFeeId");
				}
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
		[DataMapping("Stream_Id",ForeignKey=true)]
		public StreamMaster StreamObject
		{
			get
			{
				return _streamId; 
			}
			set 
			{
				_streamId = value;
			}
		}
		public DataSet LateFeeSetupDetailData
		{
			get
			{
				return _lateFeeSetupDetailData; 
			}
			set 
			{
				_lateFeeSetupDetailData = value;
			}
		}
		#endregion 
	}
}
