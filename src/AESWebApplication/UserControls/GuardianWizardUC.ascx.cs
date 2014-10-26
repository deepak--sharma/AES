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

public partial class GuardianWizardUC : System.Web.UI.UserControl
{
    #region Page Variables
    GuardianDetail objGuardianDetail = null;
    MetadataMaster objMetadataMaster = null;
    MetadataMasterBL objMetadataMasterBL = null;
    public bool RelationRequired
    { get; set; }
    #endregion

    #region Helper Functions
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            lblRelation.Visible = false;
            txtRelation.Visible = false;
            if (RelationRequired)
            {
                lblRelation.Visible = true;
                txtRelation.Visible = true;
            }
        }
    }
    public void InitializeControl()
    {
        if (!Convert.ToBoolean(hfIsControlsLoaded.Value))
        {
            UIController.BindMetadataDDL(ddlNationality, MetadataTypeEnum.Nationality);
            hfIsControlsLoaded.Value = true.ToString();
        }

    }
    public GuardianDetail GetControlData()
    {
        objGuardianDetail = new GuardianDetail();
        objGuardianDetail.FullName = txtFullName.Text;
        objGuardianDetail.DateOfBirth = Convert.ToDateTime(txtDateOfBirth.Text);
        objGuardianDetail.ContactNo = txtContactNo.Text;
        objGuardianDetail.Designation = txtDesignation.Text;
        objGuardianDetail.Qualification = txtQualification.Text;
        if (ddlNationality.SelectedIndex != 0)
        {
            objGuardianDetail.NationalityObject = new MetadataMaster();
            objGuardianDetail.NationalityObject.MetadataId = Convert.ToInt32(ddlNationality.SelectedValue);
        }
        objGuardianDetail.Relation = txtRelation.Text;
        objGuardianDetail.IsStaff = Convert.ToBoolean(rblIsStaff.SelectedValue);
        objGuardianDetail.WasStudent = Convert.ToBoolean(rblWasStudent.SelectedValue);
        objGuardianDetail.OfficeDetail = txtOfficeDetail.Text;
        return objGuardianDetail;
    }
    public void SetControlData(GuardianDetail _objGuardianDetail)
    {
        txtFullName.Text = _objGuardianDetail.FullName;
        txtDateOfBirth.Text = _objGuardianDetail.DateOfBirth.ToString();
        txtContactNo.Text = _objGuardianDetail.ContactNo;
        txtDesignation.Text = _objGuardianDetail.Designation;
        txtQualification.Text = _objGuardianDetail.Qualification;
        UIUtility.SelectCurrentListItem(ddlNationality, _objGuardianDetail.NationalityObject.MetadataId, BindListItem.ByValue, true);
        txtRelation.Text = _objGuardianDetail.Relation;
        rblIsStaff.SelectedValue = Convert.ToString(_objGuardianDetail.IsStaff);
        rblWasStudent.SelectedValue = Convert.ToString(_objGuardianDetail.WasStudent);
        txtOfficeDetail.Text = _objGuardianDetail.OfficeDetail;
    }
    #endregion
}
