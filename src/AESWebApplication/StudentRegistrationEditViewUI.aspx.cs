using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using AES.SolutionFramework;
using AES.BusinessFramework;
using AES.ObjectFramework;
using System.Collections.Generic;

public partial class StudentRegistrationEditViewUI : BasePage
{
    #region Page Variables
    StudentRegistrationDetail objStudentRegistrationDetail;
    StudentRegistrationDetailBL objStudentRegistrationDetailBL;

    int registrationId
    {
        get
        {
            return Convert.ToInt32(ViewState["registrationId"]);
        }
        set
        {
            ViewState["registrationId"] = value;
        }
    }
    int registrationMasterId
    {
        get
        {
            return Convert.ToInt32(ViewState["registrationMasterId"]);
        }
        set
        {
            ViewState["registrationMasterId"] = value;
        }
    }
    int candidateId
    {
        get
        {
            return Convert.ToInt32(ViewState["candidateId"]);
        }
        set
        {
            ViewState["candidateId"] = value;
        }
    }
    int? recordVersion
    {
        get
        {
            return Convert.ToInt32(ViewState["recordVersion"]);
        }
        set
        {
            ViewState["recordVersion"] = value;
        }
    }
    int fatherId
    {
        get
        {
            return Convert.ToInt32(ViewState["fatherId"]);
        }
        set
        {
            ViewState["fatherId"] = value;
        }
    }
    int motherId
    {
        get
        {
            return Convert.ToInt32(ViewState["motherId"]);
        }
        set
        {
            ViewState["motherId"] = value;
        }
    }
    int guardianId
    {
        get
        {
            return Convert.ToInt32(ViewState["guardianId"]);
        }
        set
        {
            ViewState["guardianId"] = value;
        }
    }
    int siblingId1
    {
        get
        {
            return Convert.ToInt32(ViewState["siblingId1"]);
        }
        set
        {
            ViewState["siblingId1"] = value;
        }
    }
    int siblingId2
    {
        get
        {
            return Convert.ToInt32(ViewState["siblingId2"]);
        }
        set
        {
            ViewState["siblingId2"] = value;
        }
    }
    string isBasicDetailLoaded = "IsBasicDetailLoaded";
    string isEducationDetailLoaded = "IsEducationDetailLoaded";
    string isGuardianDetailLoaded = "IsGuardianDetailLoaded";
    string isSiblingDetailLoaded = "isSiblingDetailLoaded";
    string qRegId = "RegId";
    EventHandler objEventHandler = null;
    #endregion

    #region Basic Details
    protected void Page_Load()
    {
        try
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString.HasKeys())
                {
                    registrationId = Convert.ToInt32(Request.QueryString[qRegId].ToString());
                    objEventHandler = new EventHandler(lnkBasicDetail_Click);
                    ViewState[isBasicDetailLoaded] = false;
                    ViewState[isEducationDetailLoaded] = false;
                    ViewState[isGuardianDetailLoaded] = false;
                    ViewState[isSiblingDetailLoaded] = false;
                    objEventHandler(null, null);
                }
                else
                {
                    UIUtility.DisplayMessage(lblMessage, "Registration details missing", MessageType.Error);
                }
                
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    protected void lnkBasicDetail_Click(object sender, EventArgs e)
    {
        try
        {
            if (!Convert.ToBoolean(ViewState[isBasicDetailLoaded]))
            {
                uxCandidateWizardUC.InitializeControl();
                UIController.BindMetadataDDL(ddlBoarding, MetadataTypeEnum.BoardingType);
                UIController.BindMetadataDDL(ddlRegistrationStatus, MetadataTypeEnum.RegistrationRequestStatus);
                ViewState[isBasicDetailLoaded] = true;
            }
            PopulateBasicDetail();
            SetCurrentView(true, false, false, false);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    private void PopulateBasicDetail()
    {
        objStudentRegistrationDetail = SelectRegistrationById();
        lblRegistrationNumberValue.Text = objStudentRegistrationDetail.RegistrationNumber;
        registrationMasterId = Convert.ToInt32(objStudentRegistrationDetail.RegistrationObject.RegistrationId);
        lblRegistration.Text = objStudentRegistrationDetail.RegistrationObject.RegistrationName;
        txtFeeSubmited.Text = objStudentRegistrationDetail.FeeSubmited.ToString();
        UIUtility.SelectCurrentListItem(ddlBoarding, objStudentRegistrationDetail.BoardingTypeObject.MetadataId, BindListItem.ByValue, true);
        UIUtility.SelectCurrentListItem(ddlIsTransportRequired, objStudentRegistrationDetail.IsTransportRequired, BindListItem.ByValue, true);
        calenderRegistrationDate.Text = GeneralUtility.ToStandardDate(objStudentRegistrationDetail.RegistrationDate);
        UIUtility.SelectCurrentListItem(ddlRegistrationStatus, objStudentRegistrationDetail.RegistrationStatusObject.MetadataId, BindListItem.ByValue, true);
        txtComment.Text = objStudentRegistrationDetail.Comment;
        txtDistance.Text = objStudentRegistrationDetail.Distance.ToString();
        recordVersion = Convert.ToInt32(objStudentRegistrationDetail.Version);
        uxCandidateWizardUC.SetControlData(objStudentRegistrationDetail.CandidateObject);

        //TODO:Apply rol based change registration status task
        if (objStudentRegistrationDetail.RegistrationStatusObject.MetadataId != Convert.ToInt32(RegistrationRequestStatus.New))
        {
            //Set registration status row visibility
            UpdateStatusButtonPanel.Visible = true;
            BasicDetailButton.Visible = false;
            EducationalDetailButton.Visible = false;
            GuardianDetailButton.Visible = false;
            SiblingDetailButton.Visible = false;

        }
    }
    private StudentRegistrationDetail SelectRegistrationById()
    {
        objStudentRegistrationDetailBL = new StudentRegistrationDetailBL();
        objStudentRegistrationDetail = new StudentRegistrationDetail();
        objStudentRegistrationDetail.StudentRegistrationId = registrationId;
        objStudentRegistrationDetail.Version = (recordVersion > 0) ? recordVersion : null;
        objStudentRegistrationDetail = objStudentRegistrationDetailBL.SelectRecordById(objStudentRegistrationDetail);
        candidateId = Convert.ToInt32(objStudentRegistrationDetail.CandidateObject.CandidateId);
        fatherId = Convert.ToInt32(objStudentRegistrationDetail.CandidateObject.FatherObject.GuardianId);
        motherId = Convert.ToInt32(objStudentRegistrationDetail.CandidateObject.MotherObject.GuardianId);
        guardianId = Convert.ToInt32(objStudentRegistrationDetail.CandidateObject.GuardianObject.GuardianId);
        recordVersion = objStudentRegistrationDetail.Version;
        return objStudentRegistrationDetail;
    }
    protected void btnSaveBasic_Click(object sender, EventArgs e)
    {
        try
        {
            objStudentRegistrationDetail = GetBasicDetailForSave();
            objStudentRegistrationDetailBL = new StudentRegistrationDetailBL();

            objStudentRegistrationDetail = objStudentRegistrationDetailBL.EditStudentRegistrationDetail(objStudentRegistrationDetail);

            if (objStudentRegistrationDetail.DbOperationStatus == CommonConstant.SUCCEED)
            {
                recordVersion = recordVersion + 1;
            }
            UIUtility.DisplayMessage(lblMessage, objStudentRegistrationDetail.DbOperationStatus);
        }
        catch (Exception ex)
        {

            throw;
        }

    }
    protected void btnCancelBasic_Click(object sender, EventArgs e)
    {

    }
    protected void btnProceed_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(txtComment.Text) || ddlRegistrationStatus.SelectedIndex == 0)
            {
                lblMsg.Text = "Enter/Select mandatory fields";
            }
            else
            {
                objStudentRegistrationDetailBL = new StudentRegistrationDetailBL();
                Dictionary<int, int> dicRegistrationId = new Dictionary<int, int>();
                dicRegistrationId.Add(registrationId, Convert.ToInt32(recordVersion) + 1);

                objStudentRegistrationDetail = objStudentRegistrationDetailBL.EditStudentRegistrationStatus(dicRegistrationId, Convert.ToInt32(ddlRegistrationStatus.SelectedValue),
                                                                                                            txtComment.Text, LoggedInUser, GeneralUtility.CurrentDateTime);

                if (objStudentRegistrationDetail.DbOperationStatus == CommonConstant.SUCCEED)
                {
                    recordVersion = recordVersion + 1;
                }
                UIUtility.DisplayMessage(lblMsg, objStudentRegistrationDetail.DbOperationStatus);
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    private StudentRegistrationDetail GetBasicDetailForSave()
    {
        objStudentRegistrationDetail = new StudentRegistrationDetail();

        objStudentRegistrationDetail.StudentRegistrationId = registrationId;
        objStudentRegistrationDetail.RegistrationNumber = lblRegistrationNumberValue.Text;

        if (registrationMasterId > 0)
        {
            objStudentRegistrationDetail.RegistrationObject = new RegistrationMaster();
            objStudentRegistrationDetail.RegistrationObject.RegistrationId = registrationMasterId;
        }

        objStudentRegistrationDetail.FeeSubmited = Convert.ToDecimal(txtFeeSubmited.Text);
        if (ddlBoarding.SelectedIndex != 0)
        {
            objStudentRegistrationDetail.BoardingTypeObject = new MetadataMaster();
            objStudentRegistrationDetail.BoardingTypeObject.MetadataId = Convert.ToInt32(ddlBoarding.SelectedItem.Value);
        }
        objStudentRegistrationDetail.IsTransportRequired = Convert.ToBoolean(ddlIsTransportRequired.SelectedItem.Value);
        objStudentRegistrationDetail.RegistrationDate = Convert.ToDateTime(calenderRegistrationDate.Text);
        if (ddlRegistrationStatus.SelectedIndex != 0)
        {
            objStudentRegistrationDetail.RegistrationStatusObject = new MetadataMaster();
            objStudentRegistrationDetail.RegistrationStatusObject.MetadataId = Convert.ToInt32(ddlRegistrationStatus.SelectedItem.Value);
        }
        objStudentRegistrationDetail.Distance = Convert.ToInt32(txtDistance.Text);

        objStudentRegistrationDetail.Version = recordVersion + 1;
        objStudentRegistrationDetail.CreatedBy = LoggedInUser;
        objStudentRegistrationDetail.CreatedOn = GeneralUtility.CurrentDateTime;
        objStudentRegistrationDetail.ModifiedBy = LoggedInUser;
        objStudentRegistrationDetail.ModifiedOn = GeneralUtility.CurrentDateTime;
        objStudentRegistrationDetail.RecordStatus = Convert.ToInt16(RecordStatus.Active);

        objStudentRegistrationDetail.CandidateObject = uxCandidateWizardUC.GetControlData();
        objStudentRegistrationDetail.CandidateObject.CandidateId = candidateId;

        return objStudentRegistrationDetail;
    }
    #endregion

    #region Previous Educational Detail
    protected void lnkEducationalDetail_Click(object sender, EventArgs e)
    {
        try
        {
            if (!Convert.ToBoolean(ViewState[isEducationDetailLoaded]))
            {
                uxPreviousSchoolEducationWizardUC.InitializeControl();
                ViewState[isEducationDetailLoaded] = true;
            }
            PopulateEducationalDetail();
            SetCurrentView(false, true, false, false);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    private void PopulateEducationalDetail()
    {
        PreviousSchoolEducationDetail _objEducationalDetail = new PreviousSchoolEducationDetail();
        PreviousSchoolEducationDetailBL _objEducationalDetailBL = new PreviousSchoolEducationDetailBL();
        _objEducationalDetail.CandidateObject = new CandidateDetail();
        _objEducationalDetail.CandidateObject.CandidateId = candidateId;
        _objEducationalDetail.ParentId = registrationId;
        _objEducationalDetail = _objEducationalDetailBL.SelectSchoolEducationDetailById(_objEducationalDetail);
        uxPreviousSchoolEducationWizardUC.SetControlData(_objEducationalDetail);
        recordVersion = _objEducationalDetail.ParentVersion;
    }
    protected void btnSaveEducational_Click(object sender, EventArgs e)
    {
        try
        {
            PreviousSchoolEducationDetail _objEducationalDetail = uxPreviousSchoolEducationWizardUC.GetControlData();
            PreviousSchoolEducationDetailBL _objEducationalDetailBL = new PreviousSchoolEducationDetailBL();
            _objEducationalDetail.CandidateObject = new CandidateDetail();
            _objEducationalDetail.CandidateObject.CandidateId = candidateId;
            _objEducationalDetail.ModifiedBy = LoggedInUser;
            _objEducationalDetail.ParentId = registrationId;
            _objEducationalDetail.ParentVersion = recordVersion;
            _objEducationalDetail = _objEducationalDetailBL.EdiPreviousSchoolEducationDetailData(_objEducationalDetail);
            if (_objEducationalDetail.DbOperationStatus == CommonConstant.SUCCEED)
            {
                recordVersion = recordVersion + 1;
            }
            UIUtility.DisplayMessage(lblMessage, _objEducationalDetail.DbOperationStatus);

        }
        catch (Exception ex)
        {
            throw;
        }
    }
    protected void btnCancelEducational_Click(object sender, EventArgs e)
    {

    }
    #endregion

    #region Guardian Detail
    protected void lnkGuardianDetail_Click(object sender, EventArgs e)
    {
        try
        {
            if (!Convert.ToBoolean(ViewState[isGuardianDetailLoaded]))
            {
                uxFatherWizardUC.InitializeControl();
                uxMotherWizardUC.InitializeControl();
                uxGuardianWizardUC.InitializeControl();
                PopulateGuardianDetail();
            }
            SetCurrentView(false, false, true, false);
        }
        catch (Exception ex)
        {

            throw;
        }

    }
    private void PopulateGuardianDetail()
    {
        GuardianDetail _objFatherDetail = new GuardianDetail();
        GuardianDetailBL _objGuardianDetailBL = new GuardianDetailBL();
        _objFatherDetail.GuardianId = fatherId;
        _objFatherDetail.ParentId = registrationId;
        _objFatherDetail = _objGuardianDetailBL.SelectRecordById(_objFatherDetail);
        uxFatherWizardUC.SetControlData(_objFatherDetail);

        GuardianDetail _objMotherDetail = new GuardianDetail();
        _objMotherDetail.GuardianId = motherId;
        _objMotherDetail.ParentId = registrationId;
        _objMotherDetail = _objGuardianDetailBL.SelectRecordById(_objMotherDetail);
        uxMotherWizardUC.SetControlData(_objMotherDetail);

        GuardianDetail _objGuardianDetail = new GuardianDetail();
        _objGuardianDetail.GuardianId = guardianId;
        _objGuardianDetail.ParentId = registrationId;
        _objGuardianDetail = _objGuardianDetailBL.SelectRecordById(_objGuardianDetail);
        uxGuardianWizardUC.SetControlData(_objGuardianDetail);
        recordVersion = _objGuardianDetail.ParentVersion;
    }
    protected void btnSaveGuardian_Click(object sender, EventArgs e)
    {
        try
        {
            GuardianDetail _objFatherDetail = uxFatherWizardUC.GetControlData();
            _objFatherDetail.GuardianId = fatherId;
            _objFatherDetail.IsGuardian = rdbFatherGuardion.Checked;
            _objFatherDetail.ModifiedBy = LoggedInUser;
            _objFatherDetail.ParentId = registrationId;
            _objFatherDetail.ParentVersion = recordVersion;
            GuardianDetail _objMotherDetail = uxMotherWizardUC.GetControlData();
            _objMotherDetail.GuardianId = motherId;
            _objMotherDetail.IsGuardian = rdbMotherGuardion.Checked;
            _objMotherDetail.ModifiedBy = LoggedInUser;

            GuardianDetail _objGuardianDetail = null;
            if (rdbGuardion.Checked)
            {
                _objGuardianDetail = uxGuardianWizardUC.GetControlData();
                _objGuardianDetail.GuardianId = guardianId;
                _objGuardianDetail.IsGuardian = true;
                _objGuardianDetail.ModifiedBy = LoggedInUser;
            }
            else
            {
                _objGuardianDetail = new GuardianDetail();
                _objGuardianDetail.GuardianId = guardianId;
                _objGuardianDetail.FullName = "";
                _objGuardianDetail.IsGuardian = false;
                _objGuardianDetail.ModifiedBy = LoggedInUser;
            }

            GuardianDetailBL _objGuardianDetailBL = new GuardianDetailBL();
            _objGuardianDetail = _objGuardianDetailBL.EditGuardianDetail(_objFatherDetail, _objMotherDetail, _objGuardianDetail);

            if (_objGuardianDetail.DbOperationStatus == CommonConstant.SUCCEED)
            {
                recordVersion = recordVersion + 1;
            }
            UIUtility.DisplayMessage(lblMessage, _objGuardianDetail.DbOperationStatus);
        }
        catch (Exception ex)
        {
            throw;
        }

    }
    protected void btnCancelGuardian_Click(object sender, EventArgs e)
    {

    }
    #endregion

    #region Sibling Detail
    protected void lnkSiblingDetail_Click(object sender, EventArgs e)
    {
        try
        {
            if (!Convert.ToBoolean(ViewState[isSiblingDetailLoaded]))
            {
                uxSiblingWizardUC1.InitializeControl();
                uxSiblingWizardUC2.InitializeControl();
                PopulateSiblingDetail();
            }
            SetCurrentView(false, false, false, true);

        }
        catch (Exception ex)
        {

            throw;
        }
    }
    private void PopulateSiblingDetail()
    {
        SiblingDetail _objSiblingDetail = new SiblingDetail();
        SiblingDetailBL _objSiblingDetailBL = new SiblingDetailBL();
        _objSiblingDetail.CandidateObject = new CandidateDetail();
        _objSiblingDetail.CandidateObject.CandidateId = candidateId;
        _objSiblingDetail.ParentId = registrationId;

        _objSiblingDetail = _objSiblingDetailBL.SelectSiblingDetail(_objSiblingDetail);
        _objSiblingDetail.ConvertToObjectFromDataRow(_objSiblingDetail.ObjectDataSet.Tables[0], 0);
        uxSiblingWizardUC1.SetControlData(_objSiblingDetail);
        siblingId1 = Convert.ToInt32(_objSiblingDetail.SiblingId);

        _objSiblingDetail.ConvertToObjectFromDataRow(_objSiblingDetail.ObjectDataSet.Tables[0], 1);
        uxSiblingWizardUC2.SetControlData(_objSiblingDetail);
        siblingId2 = Convert.ToInt32(_objSiblingDetail.SiblingId);
        recordVersion = _objSiblingDetail.ParentVersion;
    }
    protected void btnSaveSibling_Click(object sender, EventArgs e)
    {
        try
        {
            SiblingDetail _objSiblingDetail1 = uxSiblingWizardUC1.GetControlData();
            _objSiblingDetail1.SiblingId = siblingId1;
            _objSiblingDetail1.CandidateObject = new CandidateDetail();
            _objSiblingDetail1.CandidateObject.CandidateId = candidateId;
            _objSiblingDetail1.ModifiedBy = LoggedInUser;
            _objSiblingDetail1.ParentId = registrationId;
            _objSiblingDetail1.ParentVersion = recordVersion;
            SiblingDetail _objSiblingDetail2 = uxSiblingWizardUC2.GetControlData();
            _objSiblingDetail2.SiblingId = siblingId2;
            _objSiblingDetail2.CandidateObject = new CandidateDetail();
            _objSiblingDetail2.CandidateObject.CandidateId = candidateId;
            _objSiblingDetail2.ModifiedBy = LoggedInUser;

            SiblingDetailBL _objSiblingDetailBL = new SiblingDetailBL();
            _objSiblingDetail1 = _objSiblingDetailBL.EditSiblingDetail(_objSiblingDetail1, _objSiblingDetail2);

            if (_objSiblingDetail1.DbOperationStatus == CommonConstant.SUCCEED)
            {
                recordVersion = recordVersion + 1;
            }
            UIUtility.DisplayMessage(lblMessage, _objSiblingDetail1.DbOperationStatus);
        }
        catch (Exception ex)
        {

            throw;
        }
    }
    protected void btnCancelSibling_Click(object sender, EventArgs e)
    {

    }
    #endregion

    #region Helper Functions
    private void SetCurrentView(bool isBasicDetail, bool isEducationalDetail, bool isGuardianDetail, bool isSiblingDetail)
    {
        dvBasicDetail.Visible = isBasicDetail;
        dvEducationalDetail.Visible = isEducationalDetail;
        dvGuardianDetail.Visible = isGuardianDetail;
        dvSiblingDetail.Visible = isSiblingDetail;
    }
    #endregion

}
