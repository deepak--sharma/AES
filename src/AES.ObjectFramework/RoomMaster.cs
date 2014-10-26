using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class RoomMaster : BaseClassObject
	{

		#region Fields Name ...
		private int? _roomId;
		private string _roomName;
		private MetadataMaster _roomTypeId;
		private int? _sittingCapacity;
		private string _description;
		#endregion 

		#region Object Properties ...
		[DataMapping("Room_Id",PrimaryKey=true)]
		public int? RoomId
		{
			get
			{
				return _roomId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_roomId = value; 
				}
				else
				{
				throw new Exception("Invalid RoomId");
				}
			}
		}
		[DataMapping("Room_Name")]
		public string RoomName
		{
			get
			{
				return _roomName; 
			}
			set 
			{
				if (value.Length<= 100)
				{
					_roomName = value; 
				}
				else
				{
				throw new Exception("Invalid RoomName");
				}
			}
		}
		[DataMapping("Room_Type_Id",ForeignKey=true)]
		public MetadataMaster RoomTypeObject
		{
			get
			{
				return _roomTypeId; 
			}
			set 
			{
				_roomTypeId = value;
			}
		}
		[DataMapping("Sitting_Capacity")]
		public int? SittingCapacity
		{
			get
			{
				return _sittingCapacity; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_sittingCapacity = value; 
				}
				else
				{
				throw new Exception("Invalid SittingCapacity");
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
