using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class AcademicSessionMaster : BaseClassObject
	{

		#region Fields Name ...
		private int? _sessionId;
		private string _sessionName;
		#endregion 

		#region Object Properties ...
		[DataMapping("Session_Id",PrimaryKey=true)]
		public int? SessionId
		{
			get
			{
				return _sessionId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_sessionId = value; 
				}
				else
				{
				throw new Exception("Invalid SessionId");
				}
			}
		}
		[DataMapping("Session_Name")]
		public string SessionName
		{
			get
			{
				return _sessionName; 
			}
			set 
			{
				if (value.Length<= 50)
				{
					_sessionName = value; 
				}
				else
				{
				throw new Exception("Invalid SessionName");
				}
			}
		}
		#endregion 
	}
}
