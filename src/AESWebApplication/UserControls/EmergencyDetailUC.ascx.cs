using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using AES.SolutionFramework;
using AES.BusinessFramework;
using AES.ObjectFramework;

public partial class EmergencyDetailUC : System.Web.UI.UserControl
{
	#region Page Variables
	EmergencyDetail objEmergencyDetail = null;

	#endregion

	#region Page Events and Functions
	protected void Page_Load(object sender, EventArgs e)
	{
	}
	#endregion

	#region Helper Functions
	public bool ValidateObject()
	{
		return true;
	}
	public void BindUCControls()
	{
	}
	public EmergencyDetail GetUserControlData()
	{
		objEmergencyDetail = new EmergencyDetail();
		if (!string.IsNullOrEmpty(hfEmergencyDetailId.Value))
		{ objEmergencyDetail.EmergencyDetailId = Convert.ToInt32(hfEmergencyDetailId.Value); }
		objEmergencyDetail.ContactPerson = txtContactPerson.Text;
		objEmergencyDetail.Relation = txtRelation.Text;
		objEmergencyDetail.ContactNumber = txtContactNumber.Text;
		objEmergencyDetail.Address = txtAddress.Text;
		objEmergencyDetail.EmailId = txtEmailId.Text;
		return objEmergencyDetail;
	}
	public void SetUserControlData(EmergencyDetail _objEmergencyDetail)
	{
		hfEmergencyDetailId.Value = _objEmergencyDetail.EmergencyDetailId.ToString();
		txtContactPerson.Text = _objEmergencyDetail.ContactPerson;
		txtRelation.Text = _objEmergencyDetail.Relation;
		txtContactNumber.Text = _objEmergencyDetail.ContactNumber;
		txtAddress.Text = _objEmergencyDetail.Address;
		txtEmailId.Text = _objEmergencyDetail.EmailId;
	}
	#endregion
}
