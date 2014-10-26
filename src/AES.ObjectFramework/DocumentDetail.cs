using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class DocumentDetail : BaseClassObject
	{

		#region Fields Name ...
		private int? _documentDetailId;
		private int? _memberId;
		private MetadataMaster _memberTypeId;
		private MetadataMaster _documentId;
		private string _documentDescription;
		private string _documentPath;
		private string _comments;
		private DateTime? _uploadDate;
		#endregion 

		#region Object Properties ...
		[DataMapping("Document_Detail_Id",PrimaryKey=true)]
		public int? DocumentDetailId
		{
			get
			{
				return _documentDetailId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_documentDetailId = value; 
				}
				else
				{
				throw new Exception("Invalid DocumentDetailId");
				}
			}
		}
		[DataMapping("Member_Id")]
		public int? MemberId
		{
			get
			{
				return _memberId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_memberId = value; 
				}
				else
				{
				throw new Exception("Invalid MemberId");
				}
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
		[DataMapping("Document_Id",ForeignKey=true)]
		public MetadataMaster DocumentObject
		{
			get
			{
				return _documentId; 
			}
			set 
			{
				_documentId = value;
			}
		}
		[DataMapping("Document_Description")]
		public string DocumentDescription
		{
			get
			{
				return _documentDescription; 
			}
			set 
			{
				if (value.Length<= 500)
				{
					_documentDescription = value; 
				}
				else
				{
				throw new Exception("Invalid DocumentDescription");
				}
			}
		}
		[DataMapping("Document_Path")]
		public string DocumentPath
		{
			get
			{
				return _documentPath; 
			}
			set 
			{
				if (value.Length<= 500)
				{
					_documentPath = value; 
				}
				else
				{
				throw new Exception("Invalid DocumentPath");
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
		[DataMapping("Upload_Date")]
		public DateTime? UploadDate
		{
			get
			{
				return _uploadDate; 
			}
			set 
			{
				if (GeneralUtility.IsDateTime(value) || GeneralUtility.IsNull(value))
				{
					_uploadDate = value; 
				}
				else
				{
				throw new Exception("Invalid UploadDate");
				}
			}
		}
		#endregion 
	}
}
