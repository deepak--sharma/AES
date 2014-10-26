using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class StreamMaster : BaseClassObject
	{

		#region Fields Name ...
		private int? _streamId;
		private ClassMaster _classId;
		private string _streamName;
		private string _description;
		private bool? _isStudent;
		#endregion 

		#region Object Properties ...
		[DataMapping("Stream_Id",PrimaryKey=true)]
		public int? StreamId
		{
			get
			{
				return _streamId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_streamId = value; 
				}
				else
				{
				throw new Exception("Invalid StreamId");
				}
			}
		}
		[DataMapping("Class_Course_Mapping_Id",ForeignKey=true)]
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
		[DataMapping("Stream_Name")]
		public string StreamName
		{
			get
			{
				return _streamName; 
			}
			set 
			{
				if (value.Length<= 100)
				{
					_streamName = value; 
				}
				else
				{
				throw new Exception("Invalid StreamName");
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
		[DataMapping("Is_Student")]
		public bool? IsStudent
		{
			get
			{
				return _isStudent; 
			}
			set 
			{
				if (GeneralUtility.IsBoolean(value) || GeneralUtility.IsNull(value))
				{
					_isStudent = value; 
				}
				else
				{
				throw new Exception("Invalid IsStudent");
				}
			}
		}
		#endregion 
	}
}
