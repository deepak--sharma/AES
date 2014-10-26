using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class RackMaster : BaseClassObject
	{

		#region Fields Name ...
		private int? _rackId;
		private string _rackCode;
		private int? _noOfRows;
		private int? _noOfColumns;
		private RackGroupMaster _rackGroupId;
		private string _descripition;
		#endregion 

		#region Object Properties ...
		[DataMapping("Rack_ID",PrimaryKey=true)]
		public int? RackId
		{
			get
			{
				return _rackId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_rackId = value; 
				}
				else
				{
				throw new Exception("Invalid RackId");
				}
			}
		}
		[DataMapping("Rack_Code")]
		public string RackCode
		{
			get
			{
				return _rackCode; 
			}
			set 
			{
				if (value.Length<= 50)
				{
					_rackCode = value; 
				}
				else
				{
				throw new Exception("Invalid RackCode");
				}
			}
		}
		[DataMapping("No_Of_Rows")]
		public int? NoOfRows
		{
			get
			{
				return _noOfRows; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_noOfRows = value; 
				}
				else
				{
				throw new Exception("Invalid NoOfRows");
				}
			}
		}
		[DataMapping("No_Of_Columns")]
		public int? NoOfColumns
		{
			get
			{
				return _noOfColumns; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_noOfColumns = value; 
				}
				else
				{
				throw new Exception("Invalid NoOfColumns");
				}
			}
		}
		[DataMapping("Rack_group_ID",ForeignKey=true)]
		public RackGroupMaster RackGroupObject
		{
			get
			{
				return _rackGroupId; 
			}
			set 
			{
				_rackGroupId = value;
			}
		}
		[DataMapping("Descripition")]
		public string Descripition
		{
			get
			{
				return _descripition; 
			}
			set 
			{
				if (value.Length<= 500)
				{
					_descripition = value; 
				}
				else
				{
				throw new Exception("Invalid Descripition");
				}
			}
		}
		#endregion 
	}
}
