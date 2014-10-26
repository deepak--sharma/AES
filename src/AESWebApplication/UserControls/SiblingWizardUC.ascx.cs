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

public partial class SiblingWizardUC : UserControl
{
    #region Page Variables
    SiblingDetail objSiblingDetail = null;
    SiblingDetailBL objSiblingDetailBL = null;
    MetadataMaster objMetadataMaster = null;
    MetadataMasterBL objMetadataMasterBL = null;
    SchoolMaster objSchoolMaster = null;
    SchoolMasterBL objSchoolMasterBL = null;
    ClassMaster objClassMaster = null;
    ClassMasterBL objClassMasterBL = null;
    private string editIndexKey = "EditIndexSiblingDetailKey";
    #endregion

    #region Page Events and Functions
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    public void InitializeUserControl(int? dataKey, string strSessionDataKey)
    {

        objSiblingDetailBL = new SiblingDetailBL();
        objSiblingDetail = new SiblingDetail();
        objSiblingDetail.CandidateObject = new CandidateDetail();
        objSiblingDetail.CandidateObject.CandidateId = dataKey;

        objSiblingDetail = objSiblingDetailBL.SelectSiblingDetail(objSiblingDetail);


    }
    #endregion

    #region Controls Events and Functions
    public void InitializeControl()
    {
        if (!Convert.ToBoolean(hfIsControlsLoaded.Value))
        {
            UIController.BindMetadataDDL(ddlGender, MetadataTypeEnum.Gender);

            objClassMasterBL = new ClassMasterBL();
            objClassMaster = new ClassMaster();
            objClassMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
            objClassMaster = objClassMasterBL.SelectClassMaster(objClassMaster);
            ddlClass.DataSource = objClassMaster.ObjectDataSet.Tables[0];
            ddlClass.DataBind();
            ddlClass.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

            hfIsControlsLoaded.Value = true.ToString();
        }
    }
    public void SetControlData(SiblingDetail objSiblingDetail)
    {
        if (Convert.ToBoolean(objSiblingDetail.IsRequired))
        {
            txtFullName.Text = objSiblingDetail.FullName;
            txtDateOfBirth.Text = objSiblingDetail.DateOfBirth.ToString();
            if (objSiblingDetail.GenderObject != null)
            {
                UIUtility.SelectCurrentListItem(ddlGender, objSiblingDetail.GenderObject.MetadataId, BindListItem.ByValue, true);
            }

            txtSchoolName.Text = objSiblingDetail.SchoolName;
            txtSchoolAddress.Text = objSiblingDetail.SchoolAddress;
            txtSchoolContacts.Text = objSiblingDetail.SchoolContacts;
            if (objSiblingDetail.ClassObject != null)
            {
                UIUtility.SelectCurrentListItem(ddlClass, objSiblingDetail.ClassObject.ClassId, BindListItem.ByValue, true);
            }
            txtRegistrationNumber.Text = objSiblingDetail.RegistrationNumber.ToString();
            rblIsCandidate.SelectedValue = Convert.ToString(objSiblingDetail.IsCandidate);

            chkSiblingRequired.Checked = true;
        }
        else
        {
            chkSiblingRequired.Checked = false;
        }
    }
    #endregion

    #region Helper Functions
    public SiblingDetail GetControlData()
    {
        objSiblingDetail = new SiblingDetail();
        if (chkSiblingRequired.Checked)
        {
            objSiblingDetail.FullName = txtFullName.Text;
            objSiblingDetail.DateOfBirth = Convert.ToDateTime(txtDateOfBirth.Text);
            if (ddlGender.SelectedIndex != 0)
            {
                objSiblingDetail.GenderObject = new MetadataMaster();
                objSiblingDetail.GenderObject.MetadataId = Convert.ToInt32(ddlGender.SelectedValue);
            }
            
            objSiblingDetail.SchoolName = txtSchoolName.Text;
            objSiblingDetail.SchoolAddress = txtSchoolAddress.Text;
            objSiblingDetail.SchoolContacts = txtSchoolContacts.Text;
            if (ddlClass.SelectedIndex != 0)
            {
                objSiblingDetail.ClassObject = new ClassMaster();
                objSiblingDetail.ClassObject.ClassId = Convert.ToInt32(ddlClass.SelectedValue);
            }
            objSiblingDetail.RegistrationNumber = txtRegistrationNumber.Text;
            objSiblingDetail.IsCandidate = Convert.ToBoolean(rblIsCandidate.SelectedValue);
            objSiblingDetail.IsRequired = true;
        }
        else
        {
            objSiblingDetail.FullName = "";
            objSiblingDetail.DateOfBirth = Convert.ToDateTime("01/01/1950");
            objSiblingDetail.GenderObject = new MetadataMaster();
            objSiblingDetail.GenderObject.MetadataId = Convert.ToInt32(ddlGender.Items[1].Value);
            objSiblingDetail.IsCandidate = false;
            objSiblingDetail.IsRequired = false;
        }
        return objSiblingDetail;
    }
    #endregion
}
