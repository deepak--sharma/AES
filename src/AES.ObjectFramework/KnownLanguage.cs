using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class KnownLanguage : BaseClassObject
	{

		#region Fields Name ...
		private int? _knownLanguageId;
		private int _memberId;
		private MetadataMaster _memberTypeId;
		private MetadataMaster _languageId;
		private bool? _canRead;
		private bool? _canWrite;
		private bool? _canSpeak;
		#endregion 

		#region Object Properties ...
		[DataMapping("Known_Language_Id",PrimaryKey=true)]
		public int? KnownLanguageId
		{
			get
			{
				return _knownLanguageId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_knownLanguageId = value; 
				}
				else
				{
				throw new Exception("Invalid KnownLanguageId");
				}
			}
		}
		[DataMapping("Member_ID")]
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
		[DataMapping("Member_Type_ID",ForeignKey=true)]
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
		[DataMapping("Language_ID",ForeignKey=true)]
		public MetadataMaster LanguageObject
		{
			get
			{
				return _languageId; 
			}
			set 
			{
				_languageId = value;
			}
		}
		[DataMapping("Can_Read")]
		public bool? CanRead
		{
			get
			{
				return _canRead; 
			}
			set 
			{
				if (GeneralUtility.IsBoolean(value) || GeneralUtility.IsNull(value))
				{
					_canRead = value; 
				}
				else
				{
				throw new Exception("Invalid CanRead");
				}
			}
		}
		[DataMapping("Can_Write")]
		public bool? CanWrite
		{
			get
			{
				return _canWrite; 
			}
			set 
			{
				if (GeneralUtility.IsBoolean(value) || GeneralUtility.IsNull(value))
				{
					_canWrite = value; 
				}
				else
				{
				throw new Exception("Invalid CanWrite");
				}
			}
		}
		[DataMapping("Can_Speak")]
		public bool? CanSpeak
		{
			get
			{
				return _canSpeak; 
			}
			set 
			{
				if (GeneralUtility.IsBoolean(value) || GeneralUtility.IsNull(value))
				{
					_canSpeak = value; 
				}
				else
				{
				throw new Exception("Invalid CanSpeak");
				}
			}
		}
		#endregion 
	}
}
