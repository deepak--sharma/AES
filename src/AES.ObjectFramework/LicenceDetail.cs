using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class LicenceDetail : BaseClassObject
	{

		#region Fields Name ...
		private int? _licenceDetailId;
		private EmployeeDetail _memberId;
		private MetadataMaster _memberTypeId;
		private MetadataMaster _licenceTypeId;
		private int? _licenceNumber;
		private DateTime? _issueDate;
		private DateTime? _expDate;
		private string _comments;
		#endregion 

		#region Object Properties ...
		[DataMapping("Licence_Detail_ID",PrimaryKey=true)]
		public int? LicenceDetailId
		{
			get
			{
				return _licenceDetailId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_licenceDetailId = value; 
				}
				else
				{
				throw new Exception("Invalid LicenceDetailId");
				}
			}
		}
		[DataMapping("Member_Id",ForeignKey=true)]
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
		[DataMapping("Licence_Type_Id",ForeignKey=true)]
		public MetadataMaster LicenceTypeObject
		{
			get
			{
				return _licenceTypeId; 
			}
			set 
			{
				_licenceTypeId = value;
			}
		}
		[DataMapping("Licence_Number")]
		public int? LicenceNumber
		{
			get
			{
				return _licenceNumber; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_licenceNumber = value; 
				}
				else
				{
				throw new Exception("Invalid LicenceNumber");
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
		[DataMapping("Exp_Date")]
		public DateTime? ExpDate
		{
			get
			{
				return _expDate; 
			}
			set 
			{
				if (GeneralUtility.IsDateTime(value) || GeneralUtility.IsNull(value))
				{
					_expDate = value; 
				}
				else
				{
				throw new Exception("Invalid ExpDate");
				}
			}
		}
		[DataMapping("Comments")]
		public string Comments
		{
			get
			{
				return _comments; 
			}
			set 
			{
				if (value.Length<= 200)
				{
					_comments = value; 
				}
				else
				{
				throw new Exception("Invalid Comments");
				}
			}
		}
		#endregion 
	}
}
