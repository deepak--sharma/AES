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

public partial class GuardianDetailUC : System.Web.UI.UserControl
{
	#region Page Variables
	GuardianDetail objGuardianDetail = null;
	MetadataMaster objMetadataMaster = null;
	MetadataMasterBL objMetadataMasterBL = null;

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
			objMetadataMasterBL = new MetadataMasterBL();
			objMetadataMaster = new MetadataMaster();
			objMetadataMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
			objMetadataMaster = objMetadataMasterBL.SelectMetadataMaster(objMetadataMaster);
			ddlNationality.DataSource = objMetadataMaster.ObjectDataSet.Tables[0];
			ddlNationality.DataBind();
			ddlNationality.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

	}
	public GuardianDetail GetUserControlData()
	{
		objGuardianDetail = new GuardianDetail();
		if (!string.IsNullOrEmpty(hfGuardianId.Value))
		{ objGuardianDetail.GuardianId = Convert.ToInt32(hfGuardianId.Value); }
		objGuardianDetail.FullName = txtFullName.Text;
		objGuardianDetail.DateOfBirth = Convert.ToDateTime(txtDateOfBirth.Text);
		objGuardianDetail.ContactNo = txtContactNo.Text;
		objGuardianDetail.Designation = txtDesignation.Text;
		objGuardianDetail.Qualification = txtQualification.Text;
		if (ddlNationality.SelectedIndex != 0)
		{
			objGuardianDetail.NationalityObject = new MetadataMaster();
			objGuardianDetail.NationalityObject.MetadataId = Convert.ToInt32(ddlNationality.SelectedItem.Value);
		}
		objGuardianDetail.Relation = txtRelation.Text;
		objGuardianDetail.IsGuardian = Convert.ToBoolean(ddlIsGuardian.SelectedItem.Value);
		objGuardianDetail.IsStaff = Convert.ToBoolean(ddlIsStaff.SelectedItem.Value);
		objGuardianDetail.WasStudent = Convert.ToBoolean(ddlWasStudent.SelectedItem.Value);
		objGuardianDetail.OfficeDetail = txtOfficeDetail.Text;
		return objGuardianDetail;
	}
	public void SetUserControlData(GuardianDetail _objGuardianDetail)
	{
		hfGuardianId.Value = _objGuardianDetail.GuardianId.ToString();
		txtFullName.Text = _objGuardianDetail.FullName;
		txtDateOfBirth.Text = _objGuardianDetail.DateOfBirth.ToString();
		txtContactNo.Text = _objGuardianDetail.ContactNo;
		txtDesignation.Text = _objGuardianDetail.Designation;
		txtQualification.Text = _objGuardianDetail.Qualification;
		UIUtility.SelectCurrentListItem(ddlNationality, _objGuardianDetail.NationalityObject.MetadataId, BindListItem.ByValue, true);
		txtRelation.Text = _objGuardianDetail.Relation;
		UIUtility.SelectCurrentListItem(ddlIsGuardian, _objGuardianDetail.IsGuardian, BindListItem.ByValue, true);
		UIUtility.SelectCurrentListItem(ddlIsStaff, _objGuardianDetail.IsStaff, BindListItem.ByValue, true);
		UIUtility.SelectCurrentListItem(ddlWasStudent, _objGuardianDetail.WasStudent, BindListItem.ByValue, true);
		txtOfficeDetail.Text = _objGuardianDetail.OfficeDetail;
	}
	#endregion
}
