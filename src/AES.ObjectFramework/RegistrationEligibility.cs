using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class RegistrationEligibility : BaseClassObject
	{

		#region Fields Name ...
		private int? _registrationEligibilityId;
		private RegistrationMaster _registrationId;
		private MetadataMaster _eligibilityId;
		private MetadataMaster _operatorId;
		private string _eligibilityValue;
		private string _description;
		#endregion 

		#region Object Properties ...
		[DataMapping("Registration_Eligibility_Id",PrimaryKey=true)]
		public int? RegistrationEligibilityId
		{
			get
			{
				return _registrationEligibilityId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_registrationEligibilityId = value; 
				}
				else
				{
				throw new Exception("Invalid RegistrationEligibilityId");
				}
			}
		}
		[DataMapping("Registration_Id",ForeignKey=true)]
		public RegistrationMaster RegistrationObject
		{
			get
			{
				return _registrationId; 
			}
			set 
			{
				_registrationId = value;
			}
		}
		[DataMapping("Eligibility_Id",ForeignKey=true)]
		public MetadataMaster EligibilityObject
		{
			get
			{
				return _eligibilityId; 
			}
			set 
			{
				_eligibilityId = value;
			}
		}
		[DataMapping("Operator_Id",ForeignKey=true)]
		public MetadataMaster OperatorObject
		{
			get
			{
				return _operatorId; 
			}
			set 
			{
				_operatorId = value;
			}
		}
		[DataMapping("Eligibility_Value")]
		public string EligibilityValue
		{
			get
			{
				return _eligibilityValue; 
			}
			set 
			{
				if (value.Length<= 500)
				{
					_eligibilityValue = value; 
				}
				else
				{
				throw new Exception("Invalid EligibilityValue");
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
				if (value.Length<= 4000)
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
