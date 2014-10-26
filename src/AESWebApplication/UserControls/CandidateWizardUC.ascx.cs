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

public partial class CandidateWizardUC : UserControl
{
    #region Page Variables
    CandidateDetail objCandidateDetail = null;   
    #endregion
   
    #region Helper Functions
    public void InitializeControl()
    {
        if (!Convert.ToBoolean(hfIsControlsLoaded.Value))
        {
            UIController.BindMetadataDDL(ddlGender, MetadataTypeEnum.Gender);
            UIController.BindMetadataDDL(ddlCategory, MetadataTypeEnum.CasteCategory);
            UIController.BindMetadataDDL(ddlReligion, MetadataTypeEnum.Religion);
            UIController.BindMetadataDDL(ddlMaritialStatus, MetadataTypeEnum.MaritalStatus);
            uxCurrentAddressUC.BindUCControls();
            hfIsControlsLoaded.Value = true.ToString();
        }
    }
    public CandidateDetail GetControlData()
    {
        objCandidateDetail = new CandidateDetail();
        objCandidateDetail.FirstName = txtFirstName.Text;
        objCandidateDetail.MiddleName = txtMiddleName.Text;
        objCandidateDetail.LastName = txtLastName.Text;
        objCandidateDetail.DateOfBirth = Convert.ToDateTime(calenderDateOfBirth.Text);

        if (ddlGender.SelectedIndex != 0)
        {
            objCandidateDetail.GenderObject = new MetadataMaster();
            objCandidateDetail.GenderObject.MetadataId = Convert.ToInt32(ddlGender.SelectedValue);
        }
        if (ddlCategory.SelectedIndex != 0)
        {
            objCandidateDetail.CategoryObject = new MetadataMaster();
            objCandidateDetail.CategoryObject.MetadataId = Convert.ToInt32(ddlCategory.SelectedValue);
        }
        if (ddlReligion.SelectedIndex != 0)
        {
            objCandidateDetail.ReligionObject = new MetadataMaster();
            objCandidateDetail.ReligionObject.MetadataId = Convert.ToInt32(ddlReligion.SelectedValue);
        }
        if (ddlMaritialStatus.SelectedIndex != 0)
        {
            objCandidateDetail.MaritialStatusObject = new MetadataMaster();
            objCandidateDetail.MaritialStatusObject.MetadataId = Convert.ToInt32(ddlMaritialStatus.SelectedValue);
        }
        objCandidateDetail.IsStaffChild = Convert.ToBoolean(rblIsStaffChild.SelectedValue);
        objCandidateDetail.CurrentAddressObject = uxCurrentAddressUC.GetUserControlData();
        //objCandidateDetail.Photo = fuPhoto.PostedFile; //txtPhoto.Text;        
        return objCandidateDetail;
    }
    public void SetControlData(CandidateDetail _objCandidateDetail)
    {
        txtFirstName.Text = _objCandidateDetail.FirstName;
        txtMiddleName.Text = _objCandidateDetail.MiddleName;
        txtLastName.Text = _objCandidateDetail.LastName;
        calenderDateOfBirth.Text = GeneralUtility.ToStandardDate(_objCandidateDetail.DateOfBirth.ToString());

        UIUtility.SelectCurrentListItem(ddlGender, _objCandidateDetail.GenderObject.MetadataId, BindListItem.ByValue, true);
        UIUtility.SelectCurrentListItem(ddlCategory, _objCandidateDetail.CategoryObject.MetadataId, BindListItem.ByValue, true);
        UIUtility.SelectCurrentListItem(ddlReligion, _objCandidateDetail.ReligionObject.MetadataId, BindListItem.ByValue, true);
        UIUtility.SelectCurrentListItem(ddlMaritialStatus, _objCandidateDetail.MaritialStatusObject.MetadataId, BindListItem.ByValue, true);

        rblIsStaffChild.SelectedValue = Convert.ToString(_objCandidateDetail.IsStaffChild);        
        uxCurrentAddressUC.SetUserControlData(_objCandidateDetail.CurrentAddressObject);
        //txtPhoto.Text = _objCandidateDetail.Photo;      

    }
    #endregion
}
