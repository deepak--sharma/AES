using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class SkillMaster : BaseClassObject
	{

		#region Fields Name ...
		private int? _skillId;
		private string _skillName;
		private string _description;
		#endregion 

		#region Object Properties ...
		[DataMapping("Skill_ID",PrimaryKey=true)]
		public int? SkillId
		{
			get
			{
				return _skillId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_skillId = value; 
				}
				else
				{
				throw new Exception("Invalid SkillId");
				}
			}
		}
		[DataMapping("Skill_Name")]
		public string SkillName
		{
			get
			{
				return _skillName; 
			}
			set 
			{
				if (value.Length<= 200)
				{
					_skillName = value; 
				}
				else
				{
				throw new Exception("Invalid SkillName");
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
				if (value.Length<= 200)
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
