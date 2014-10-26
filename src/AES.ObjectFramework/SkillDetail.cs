using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class SkillDetail : BaseClassObject
	{

		#region Fields Name ...
		private int? _skillDetailId;
		private int _memberId;
		private MetadataMaster _memberTypeId;
		private SkillMaster _skillId;
		private decimal? _yearofexp;
		private string _comment;
		#endregion 

		#region Object Properties ...
		[DataMapping("Skill_Detail_Id",PrimaryKey=true)]
		public int? SkillDetailId
		{
			get
			{
				return _skillDetailId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_skillDetailId = value; 
				}
				else
				{
				throw new Exception("Invalid SkillDetailId");
				}
			}
		}
		[DataMapping("Member_Id")]
		public int MemberId
		{
			get
			{
				return _memberId; 
			}
			set 
			{
				_memberId = value;
			}
		}
		[DataMapping("Member_Type_Id",ForeignKey=true)]
		public MetadataMaster MemberTypeObject
		{
			get
			{
				return _memberTypeId; 
			}
			set 
			{
				_memberTypeId = value;
			}
		}
		[DataMapping("Skill_Id",ForeignKey=true)]
		public SkillMaster SkillObject
		{
			get
			{
				return _skillId; 
			}
			set 
			{
				_skillId = value;
			}
		}
		[DataMapping("YearOfExp")]
		public decimal? Yearofexp
		{
			get
			{
				return _yearofexp; 
			}
			set 
			{
				if (GeneralUtility.IsDecimal(value) || GeneralUtility.IsNull(value))
				{
					_yearofexp = value; 
				}
				else
				{
				throw new Exception("Invalid Yearofexp");
				}
			}
		}
		[DataMapping("Comment")]
		public string Comment
		{
			get
			{
				return _comment; 
			}
			set 
			{
				if (value.Length<= 200)
				{
					_comment = value; 
				}
				else
				{
				throw new Exception("Invalid Comment");
				}
			}
		}
		#endregion 
	}
}
