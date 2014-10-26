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

public partial class AddressDetailUC : System.Web.UI.UserControl
{
	#region Page Variables
	AddressDetail objAddressDetail = null;
	CityMaster objCityMaster = null;
	CityMasterBL objCityMasterBL = null;
	StateMaster objStateMaster = null;
	StateMasterBL objStateMasterBL = null;
	CountryMaster objCountryMaster = null;
	CountryMasterBL objCountryMasterBL = null;

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
        UIController.BindAddressDetailDDLs(ddlCountry, ddlState, ddlCity,null);           
	}
	public AddressDetail GetUserControlData()
	{
		objAddressDetail = new AddressDetail();
		if (!string.IsNullOrEmpty(hfAddressId.Value))
		{ objAddressDetail.AddressId = Convert.ToInt32(hfAddressId.Value); }
		objAddressDetail.AddressLine1 = txtAddressLine1.Text;
		objAddressDetail.AddressLine2 = txtAddressLine2.Text;
		if (ddlCity.SelectedIndex != 0)
		{
			objAddressDetail.CityObject = new CityMaster();
			objAddressDetail.CityObject.CityId = Convert.ToInt32(ddlCity.SelectedItem.Value);
		}
		if (ddlState.SelectedIndex != 0)
		{
			objAddressDetail.StateObject = new StateMaster();
			objAddressDetail.StateObject.StateId = Convert.ToInt32(ddlState.SelectedItem.Value);
		}
		if (ddlCountry.SelectedIndex != 0)
		{
			objAddressDetail.CountryObject = new CountryMaster();
			objAddressDetail.CountryObject.CountryId = Convert.ToInt32(ddlCountry.SelectedItem.Value);
		}
		objAddressDetail.District = txtDistrict.Text;
		objAddressDetail.PinCode = Convert.ToInt32(txtPinCode.Text);
		objAddressDetail.Landmark = txtLandmark.Text;
		objAddressDetail.LandlineNo = txtLandlineNo.Text;
		objAddressDetail.MobileNo = txtMobileNo.Text;
		objAddressDetail.EmailId = txtEmailId.Text;
		return objAddressDetail;
	}
	public void SetUserControlData(AddressDetail _objAddressDetail)
	{
		hfAddressId.Value = _objAddressDetail.AddressId.ToString();
		txtAddressLine1.Text = _objAddressDetail.AddressLine1;
		txtAddressLine2.Text = _objAddressDetail.AddressLine2;

        UIUtility.SelectCurrentListItem(ddlCountry, _objAddressDetail.CountryObject.CountryId, BindListItem.ByValue, true);
        ddlCountry_SelectedIndexChanged(null, null);
        UIUtility.SelectCurrentListItem(ddlState, _objAddressDetail.StateObject.StateId, BindListItem.ByValue, true);
        ddlState_SelectedIndexChanged(null, null);
		UIUtility.SelectCurrentListItem(ddlCity, _objAddressDetail.CityObject.CityId, BindListItem.ByValue, true);

		txtDistrict.Text = _objAddressDetail.District;
		txtPinCode.Text = _objAddressDetail.PinCode.ToString();
		txtLandmark.Text = _objAddressDetail.Landmark;
		txtLandlineNo.Text = _objAddressDetail.LandlineNo;
		txtMobileNo.Text = _objAddressDetail.MobileNo;
		txtEmailId.Text = _objAddressDetail.EmailId;
	}
	#endregion
    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCountry.SelectedIndex > 0)
        {
            objStateMaster = new StateMaster();
            objStateMaster.CountryObject = new CountryMaster();
            objStateMaster.CountryObject.CountryId = Convert.ToInt32(ddlCountry.SelectedValue);
            UIController.BindStateMasterDDL(ddlState,objStateMaster);
            ddlCity.Items.Clear();
            ddlCity.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);
        }
        else
        {
            ddlState.Items.Clear();
            ddlState.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);
            ddlCity.Items.Clear();
            ddlCity.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);
        }
    }
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlState.SelectedIndex > 0)
        {
            objCityMaster = new CityMaster();
            objCityMaster.StateObject = new StateMaster();
            objCityMaster.StateObject.StateId = Convert.ToInt32(ddlState.SelectedValue);
            UIController.BindCityMasterDDL(ddlCity, objCityMaster);
        }
        else
        {
            ddlCity.Items.Clear();
            ddlCity.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);
        }
    }
}
