using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class FeeScheduleDetail : BaseClassObject
	{

		#region Fields Name ...
		private int? _feeScheduleDetailId;
		private FeeSchedule _feeScheduleId;
        private int? _sNo;
		private int? _startMonth;
		private int? _endMonth;
		private int? _feeProcessMonth;
        private int? _collectionStartDate;
        private int? _collectionLastDate;
		#endregion 

		#region Object Properties ...
		[DataMapping("Fee_Schedule_Detail_Id",PrimaryKey=true)]
		public int? FeeScheduleDetailId
		{
			get
			{
				return _feeScheduleDetailId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_feeScheduleDetailId = value; 
				}
				else
				{
				throw new Exception("Invalid FeeScheduleDetailId");
				}
			}
		}
		[DataMapping("Fee_Schedule_Id",ForeignKey=true)]
		public FeeSchedule FeeScheduleObject
		{
			get
			{
				return _feeScheduleId; 
			}
			set 
			{
				_feeScheduleId = value;
			}
		}
        [DataMapping("S_No")]
        public int? SNo
        {
            get
            {
                return _sNo;
            }
            set
            {
                if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
                {
                    _sNo = value;
                }
                else
                {
                    throw new Exception("Invalid SNo");
                }
            }
        }
		[DataMapping("Start_Month")]
		public int? StartMonth
		{
			get
			{
				return _startMonth; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_startMonth = value; 
				}
				else
				{
				throw new Exception("Invalid StartMonth");
				}
			}
		}
		[DataMapping("End_Month")]
		public int? EndMonth
		{
			get
			{
				return _endMonth; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_endMonth = value; 
				}
				else
				{
				throw new Exception("Invalid EndMonth");
				}
			}
		}
		[DataMapping("Fee_Process_Month")]
		public int? FeeProcessMonth
		{
			get
			{
				return _feeProcessMonth; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_feeProcessMonth = value; 
				}
				else
				{
				throw new Exception("Invalid FeeProcessMonth");
				}
			}
		}
		[DataMapping("Collection_Start_Date")]
        public int? CollectionStartDate
		{
			get
			{
				return _collectionStartDate; 
			}
			set 
			{
				if (GeneralUtility.IsDateTime(value) || GeneralUtility.IsNull(value))
				{
					_collectionStartDate = value; 
				}
				else
				{
				throw new Exception("Invalid CollectionStartDate");
				}
			}
		}
		[DataMapping("Collection_Last_Date")]
        public int? CollectionLastDate
		{
			get
			{
				return _collectionLastDate; 
			}
			set 
			{
				if (GeneralUtility.IsDateTime(value) || GeneralUtility.IsNull(value))
				{
					_collectionLastDate = value; 
				}
				else
				{
				throw new Exception("Invalid CollectionLastDate");
				}
			}
		}
		#endregion 
	}
}
