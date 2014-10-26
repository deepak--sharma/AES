using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class PreviousSchoolEducationMarksDetail : BaseClassObject
	{

		#region Fields Name ...
		private int? _previousSchoolEducationMarksId;
		private PreviousSchoolEducationDetail _previousSchoolEducationId;
		private SubjectMaster _subjectId;
        private RegistrationMaster _registrationId;

       
		private decimal? _marksPercent;
		#endregion 

		#region Object Properties ...
		[DataMapping("Previous_School_Education_Marks_Id",PrimaryKey=true)]
		public int? PreviousSchoolEducationMarksId
		{
			get
			{
				return _previousSchoolEducationMarksId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_previousSchoolEducationMarksId = value; 
				}
				else
				{
				throw new Exception("Invalid PreviousSchoolEducationMarksId");
				}
			}
		}
		[DataMapping("Previous_School_Education_Id",ForeignKey=true)]
		public PreviousSchoolEducationDetail PreviousSchoolEducationObject
		{
			get
			{
				return _previousSchoolEducationId; 
			}
			set 
			{
				_previousSchoolEducationId = value;
			}
		}
		[DataMapping("Subject_Id",ForeignKey=true)]
		public SubjectMaster SubjectObject
		{
			get
			{
				return _subjectId; 
			}
			set 
			{
				_subjectId = value;
			}
		}        
        public RegistrationMaster RegistrationObject
        {
            get { return _registrationId; }
            set { _registrationId = value; }
        }
		[DataMapping("Marks_Percent")]
		public decimal? MarksPercent
		{
			get
			{
				return _marksPercent; 
			}
			set 
			{
				if (GeneralUtility.IsDecimal(value) || GeneralUtility.IsNull(value))
				{
					_marksPercent = value; 
				}
				else
				{
				throw new Exception("Invalid MarksPercent");
				}
			}
		}
		#endregion 
	}
}
