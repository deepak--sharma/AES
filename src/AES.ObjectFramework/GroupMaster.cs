using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class GroupMaster : BaseClassObject
	{

		#region Fields Name ...
		private int? _groupId;
		private string _groupName;
		private GroupMaster _parentGroupId;
		private string _description;
		#endregion 

		#region Object Properties ...
		[DataMapping("Group_Id",PrimaryKey=true)]
		public int? GroupId
		{
			get
			{
				return _groupId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_groupId = value; 
				}
				else
				{
				throw new Exception("Invalid GroupId");
				}
			}
		}
		[DataMapping("Group_Name")]
		public string GroupName
		{
			get
			{
				return _groupName; 
			}
			set 
			{
				if (value.Length<= 100)
				{
					_groupName = value; 
				}
				else
				{
				throw new Exception("Invalid GroupName");
				}
			}
		}
		[DataMapping("Parent_Group_Id",ForeignKey=true)]
		public GroupMaster ParentGroupObject
		{
			get
			{
				return _parentGroupId; 
			}
			set 
			{
				_parentGroupId = value;
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
