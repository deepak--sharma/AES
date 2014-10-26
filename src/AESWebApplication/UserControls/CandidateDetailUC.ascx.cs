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

public partial class CandidateDetailUC : UserControl
{
    #region Page Variables
    CandidateDetail objCandidateDetail = null;
    MetadataMaster objMetadataMaster = null;
    MetadataMasterBL objMetadataMasterBL = null;

    #endregion

    enum EnumGuardian
    {
        Father = 1,
        Mother = 2,
        Other = 3
    }

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
        uxFatherUC.BindUCControls();
        uxMotherUC.BindUCControls();
        uxGuardianUC.BindUCControls();

        UIController.BindMetadataDDL(ddlGender, MetadataTypeEnum.Gender);
        UIController.BindMetadataDDL(ddlCategory, MetadataTypeEnum.CasteCategory);
        UIController.BindMetadataDDL(ddlReligion, MetadataTypeEnum.Religion);
        UIController.BindMetadataDDL(ddlMaritial, MetadataTypeEnum.MaritalStatus);              

        uxCurrentAddressUC.BindUCControls();
        uxPermanentAddressUC.BindUCControls();

        uxSiblingDetailUC.InitializeUserControl(UIUtility.DEFAULT_ID, UserDataKeys.SIBLINGDETAIL_CANDIDATEID);
        uxPreviousSchoolEducationDetailUC.InitializeUserControl(UIUtility.DEFAULT_ID, UserDataKeys.PREVIOUSSCHOOLDETAIL_CANDIDATEID);

    }
    public CandidateDetail GetUserControlData()
    {
        objCandidateDetail = new CandidateDetail();
        if (!string.IsNullOrEmpty(hfCandidateId.Value))
        { objCandidateDetail.CandidateId = Convert.ToInt32(hfCandidateId.Value); }
        objCandidateDetail.FirstName = txtFirstName.Text;
        objCandidateDetail.MiddleName = txtMiddleName.Text;
        objCandidateDetail.LastName = txtLastName.Text;
        objCandidateDetail.DateOfBirth = Convert.ToDateTime(calenderDateOfBirth.Text);

        objCandidateDetail.FatherObject = uxFatherUC.GetUserControlData();
        objCandidateDetail.MotherObject = uxMotherUC.GetUserControlData();

        if (rblGuardian.SelectedItem.Text == EnumGuardian.Father.ToString())
        {
            objCandidateDetail.FatherObject.IsGuardian = true;
        }
        else if (rblGuardian.SelectedItem.Text == EnumGuardian.Mother.ToString())
        {
            objCandidateDetail.MotherObject.IsGuardian = true;
        }
        else
        {
            //Need to rethink: should i insert guardian detail or not
            objCandidateDetail.GuardianObject = uxGuardianUC.GetUserControlData();
            objCandidateDetail.GuardianObject.IsGuardian = true;
        }


        if (ddlGender.SelectedIndex != 0)
        {
            objCandidateDetail.GenderObject = new MetadataMaster();
            objCandidateDetail.GenderObject.MetadataId = Convert.ToInt32(ddlGender.SelectedItem.Value);
        }
        if (ddlCategory.SelectedIndex != 0)
        {
            objCandidateDetail.CategoryObject = new MetadataMaster();
            objCandidateDetail.CategoryObject.MetadataId = Convert.ToInt32(ddlCategory.SelectedItem.Value);
        }
        if (ddlReligion.SelectedIndex != 0)
        {
            objCandidateDetail.ReligionObject = new MetadataMaster();
            objCandidateDetail.ReligionObject.MetadataId = Convert.ToInt32(ddlReligion.SelectedItem.Value);
        }
        if (ddlMaritial.SelectedIndex != 0)
        {
            objCandidateDetail.MaritialStatusObject = new MetadataMaster();
            objCandidateDetail.MaritialStatusObject.MetadataId = Convert.ToInt32(ddlMaritial.SelectedItem.Value);
        }
        objCandidateDetail.IsStaffChild = Convert.ToBoolean(ddlIsStaffChild.SelectedItem.Value);
        objCandidateDetail.CurrentAddressObject = uxCurrentAddressUC.GetUserControlData();
        objCandidateDetail.PermanentAddressObject = uxPermanentAddressUC.GetUserControlData();
        //objCandidateDetail.Photo = fuPhoto.PostedFile; //txtPhoto.Text;
        objCandidateDetail.PreviousSchoolEducationDetailData = ((DataTable)Session[UserDataKeys.PREVIOUSSCHOOLDETAIL_CANDIDATEID]).DataSet;
        objCandidateDetail.SiblingDetailData = ((DataTable)Session[UserDataKeys.SIBLINGDETAIL_CANDIDATEID]).DataSet;
        return objCandidateDetail;
    }
    public void SetUserControlData(CandidateDetail _objCandidateDetail)
    {
        hfCandidateId.Value = _objCandidateDetail.CandidateId.ToString();
        txtFirstName.Text = _objCandidateDetail.FirstName;
        txtMiddleName.Text = _objCandidateDetail.MiddleName;
        txtLastName.Text = _objCandidateDetail.LastName;
        calenderDateOfBirth.Text = _objCandidateDetail.DateOfBirth.ToString();
        uxFatherUC.SetUserControlData(_objCandidateDetail.FatherObject);
        uxMotherUC.SetUserControlData(_objCandidateDetail.MotherObject);
        uxGuardianUC.SetUserControlData(_objCandidateDetail.GuardianObject);
        UIUtility.SelectCurrentListItem(ddlGender, _objCandidateDetail.GenderObject.MetadataId, BindListItem.ByValue, true);
        UIUtility.SelectCurrentListItem(ddlCategory, _objCandidateDetail.CategoryObject.MetadataId, BindListItem.ByValue, true);
        UIUtility.SelectCurrentListItem(ddlReligion, _objCandidateDetail.ReligionObject.MetadataId, BindListItem.ByValue, true);
        UIUtility.SelectCurrentListItem(ddlMaritial, _objCandidateDetail.MaritialStatusObject.MetadataId, BindListItem.ByValue, true);
        UIUtility.SelectCurrentListItem(ddlIsStaffChild, _objCandidateDetail.IsStaffChild, BindListItem.ByValue, true);
        uxCurrentAddressUC.SetUserControlData(_objCandidateDetail.CurrentAddressObject);
        uxPermanentAddressUC.SetUserControlData(_objCandidateDetail.PermanentAddressObject);
        //txtPhoto.Text = _objCandidateDetail.Photo;
        uxSiblingDetailUC.InitializeUserControl(_objCandidateDetail.CandidateId, UserDataKeys.SIBLINGDETAIL_CANDIDATEID);
        uxPreviousSchoolEducationDetailUC.InitializeUserControl(_objCandidateDetail.CandidateId, UserDataKeys.PREVIOUSSCHOOLDETAIL_CANDIDATEID);

    }
    #endregion
}
