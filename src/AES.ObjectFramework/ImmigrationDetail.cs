using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class ImmigrationDetail : BaseClassObject
	{

		#region Fields Name ...
		private int? _immigrationId;
		private EmployeeDetail _memberId;
		private MetadataMaster _memberTypeId;
		private string _passportNo;
		private string _passportDetail;
		private DateTime? _issueDate;
		private DateTime? _expiryDate;
		private DateTime? _reviseDate;
		private string _sponsor;
		private MetadataMaster _statusId;
		private string _comment;
		#endregion 

		#region Object Properties ...
		[DataMapping("Immigration_ID",PrimaryKey=true)]
		public int? ImmigrationId
		{
			get
			{
				return _immigrationId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_immigrationId = value; 
				}
				else
				{
				throw new Exception("Invalid ImmigrationId");
				}
			}
		}
		[DataMapping("Member_ID",ForeignKey=true)]
		public EmployeeDetail MemberObject
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
		[DataMapping("Passport_No")]
		public string PassportNo
		{
			get
			{
				return _passportNo; 
			}
			set 
			{
				if (value.Length<= 50)
				{
					_passportNo = value; 
				}
				else
				{
				throw new Exception("Invalid PassportNo");
				}
			}
		}
		[DataMapping("Passport_Detail")]
		public string PassportDetail
		{
			get
			{
				return _passportDetail; 
			}
			set 
			{
				if (value.Length<= 100)
				{
					_passportDetail = value; 
				}
				else
				{
				throw new Exception("Invalid PassportDetail");
				}
			}
		}
		[DataMapping("Issue_Date")]
		public DateTime? IssueDate
		{
			get
			{
				return _issueDate; 
			}
			set 
			{
				if (GeneralUtility.IsDateTime(value) || GeneralUtility.IsNull(value))
				{
					_issueDate = value; 
				}
				else
				{
				throw new Exception("Invalid IssueDate");
				}
			}
		}
		[DataMapping("Expiry_Date")]
		public DateTime? ExpiryDate
		{
			get
			{
				return _expiryDate; 
			}
			set 
			{
				if (GeneralUtility.IsDateTime(value) || GeneralUtility.IsNull(value))
				{
					_expiryDate = value; 
				}
				else
				{
				throw new Exception("Invalid ExpiryDate");
				}
			}
		}
		[DataMapping("Revise_Date")]
		public DateTime? ReviseDate
		{
			get
			{
				return _reviseDate; 
			}
			set 
			{
				if (GeneralUtility.IsDateTime(value) || GeneralUtility.IsNull(value))
				{
					_reviseDate = value; 
				}
				else
				{
				throw new Exception("Invalid ReviseDate");
				}
			}
		}
		[DataMapping("Sponsor")]
		public string Sponsor
		{
			get
			{
				return _sponsor; 
			}
			set 
			{
				if (value.Length<= 100)
				{
					_sponsor = value; 
				}
				else
				{
				throw new Exception("Invalid Sponsor");
				}
			}
		}
		[DataMapping("Status_Id",ForeignKey=true)]
		public MetadataMaster StatusObject
		{
			get
			{
				return _statusId; 
			}
			set 
			{
				_statusId = value;
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
