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
using System.Collections.Generic;
using AES.SolutionFramework;
using AES.BusinessFramework;
using AES.ObjectFramework;

public partial class EmployeeActionViewUI : BasePage
{
    #region Page Variables
    EmployeeDetail objEmployeeDetail = null;
    EmployeeDetailBL objEmployeeDetailBL = null;
    EmployeeAdministrativeDetail objEmployeeAdministrativeDetail = null;
    EmployeeAdministrativeDetailBL objEmployeeAdministrativeDetailBL = null;
    EmployeeFinancialDetail objEmployeeFinancialDetail = null;
    EmployeeFinancialDetailBL objEmployeeFinancialDetailBL = null;
    AddressDetail objCurrentAddress = null;
    AddressDetail objPermanentAddress = null;
    AddressDetailBL objAddressDetailBL = null;
    EmergencyDetail objPrimaryEmergencyDetail = null;
    EmergencyDetail objSecondryEmergencyDetail = null;
    EmergencyDetailBL objEmergencyDetailBL = null;

    private string strMessage = "Basic Info not exist. Please enter Basic Info details";
    private string isBIControlsLoaded = "BIControlsLoaded";
    private string isADControlsLoaded = "ADControlsLoaded";
    private string isFDControlsLoaded = "FDControlsLoaded";
    private string isCIControlsLoaded = "CIControlsLoaded";
    private string qEmpId = "EmpId";
    private int employeeId
    {
        get
        {
            return Convert.ToInt32(ViewState["employeeId"]);
        }
        set
        {
            ViewState["employeeId"] = value;
        }
    }
    private int recordVersion
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
    private int administrativeDetailId
    {
        get
        {
            return Convert.ToInt32(ViewState["administrativeDetailId"]);
        }
        set
        {
            ViewState["administrativeDetailId"] = value;
        }
    }
    private int financialDetailId
    {
        get
        {
            return Convert.ToInt32(ViewState["financialDetailId"]);
        }
        set
        {
            ViewState["financialDetailId"] = value;
        }
    }
    private int currentAddressId
    {
        get
        {
            return Convert.ToInt32(ViewState["currentAddressId"]);
        }
        set
        {
            ViewState["currentAddressId"] = value;
        }
    }
    private int permanentAddressId
    {
        get
        {
            return Convert.ToInt32(ViewState["permanentAddressId"]);
        }
        set
        {
            ViewState["permanentAddressId"] = value;
        }
    }
    private int primaryEmergencyId
    {
        get
        {
            return Convert.ToInt32(ViewState["primaryEmergencyId"]);
        }
        set
        {
            ViewState["primaryEmergencyId"] = value;
        }
    }
    private int secondryEmergencyId
    {
        get
        {
            return Convert.ToInt32(ViewState["secondryEmergencyId"]);
        }
        set
        {
            ViewState["secondryEmergencyId"] = value;
        }
    }
    #endregion

    #region Basic Info Details...
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString.HasKeys())
                {
                    employeeId = Convert.ToInt32(Request.QueryString[qEmpId]);
                }
                ViewState[isBIControlsLoaded] = false;
                ViewState[isADControlsLoaded] = false;
                ViewState[isFDControlsLoaded] = false;
                ViewState[isCIControlsLoaded] = false;
                InitializeBIDetails();
                SetCurrentView("BI");
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    private void InitializeBIDetails()
    {
        if (employeeId > 0)
        {
            objEmployeeDetail = new EmployeeDetail();
            objEmployeeDetail.EmployeeId = employeeId;
            objEmployeeDetail = SelectBIDetailById(objEmployeeDetail);
            if (!objEmployeeDetail.DbOperationStatus.Equals(CommonConstant.FAIL))
            {
                PopulateBIDetail(false, objEmployeeDetail);
            }
            else
            {
                UIUtility.DisplayMessage(lblMessage, objEmployeeDetail.DbOperationStatus);
            }
        }
        else
        {
            PopulateBIDetail(true, null);
        }
    }
    private EmployeeDetail SelectBIDetailById(EmployeeDetail _objEmployeeDetail)
    {
        objEmployeeDetailBL = new EmployeeDetailBL();
        _objEmployeeDetail = objEmployeeDetailBL.SelectRecordById(_objEmployeeDetail);
        recordVersion = Convert.ToInt32(_objEmployeeDetail.Version);

        administrativeDetailId = 0;
        if (_objEmployeeDetail.EmployeeAdministrativeDetailObject != null)
        {
            administrativeDetailId = Convert.ToInt32(_objEmployeeDetail.EmployeeAdministrativeDetailObject.EmployeeAdministrativeDetailId);
        }
        financialDetailId = 0;
        if (_objEmployeeDetail.EmployeeFinancialDetailObject != null)
        {
            financialDetailId = Convert.ToInt32(_objEmployeeDetail.EmployeeFinancialDetailObject.EmployeeFinancialDetailId);
        }
        currentAddressId = 0;
        if (_objEmployeeDetail.CurrentAddressObject != null)
        {
            currentAddressId = Convert.ToInt32(_objEmployeeDetail.CurrentAddressObject.AddressId);
        }
        permanentAddressId = 0;
        if (_objEmployeeDetail.PermanentAddressObject != null)
        {
            permanentAddressId = Convert.ToInt32(_objEmployeeDetail.PermanentAddressObject.AddressId);
        }
        primaryEmergencyId = 0;
        if (_objEmployeeDetail.PrimaryEmergencyObject != null)
        {
            primaryEmergencyId = Convert.ToInt32(_objEmployeeDetail.PrimaryEmergencyObject.EmergencyDetailId);
        }
        secondryEmergencyId = 0;
        if (_objEmployeeDetail.SecondryEmergencyObject != null)
        {
            secondryEmergencyId = Convert.ToInt32(_objEmployeeDetail.SecondryEmergencyObject.EmergencyDetailId);
        }
        return _objEmployeeDetail;
    }
    protected void PopulateBIDetail(bool isNewRecord, EmployeeDetail _objEmployeeDetail)
    {
        UIUtility.InitializeControls(divBasicDetail);
        BindBIDetailControls();
        if (!isNewRecord)
        {
            FillBIControlsData(_objEmployeeDetail);
        }
    }
    protected void BindBIDetailControls()
    {
        if (!Convert.ToBoolean(ViewState[isBIControlsLoaded]))
        {
            UIController.BindMetadataDDL(ddlGender, MetadataTypeEnum.Gender);
            UIController.BindMetadataDDL(ddlMaritial, MetadataTypeEnum.MaritalStatus);
            UIController.BindMetadataDDL(ddlReligion, MetadataTypeEnum.Religion);
            UIController.BindMetadataDDL(ddlCastecategory, MetadataTypeEnum.CasteCategory);
            UIController.BindMetadataDDL(ddlNationality, MetadataTypeEnum.Nationality);
            ViewState[isBIControlsLoaded] = true;
        }
    }
    private void FillBIControlsData(EmployeeDetail objEmployeeDetail)
    {
        txtEmployeeCode.Text = objEmployeeDetail.EmployeeCode;
        txtFirstName.Text = objEmployeeDetail.FirstName;
        txtMiddleName.Text = objEmployeeDetail.MiddleName;
        txtLastName.Text = objEmployeeDetail.LastName;
        txtFatherName.Text = objEmployeeDetail.FatherName;
        UIUtility.SelectCurrentListItem(ddlGender, objEmployeeDetail.GenderObject.MetadataId, BindListItem.ByValue, true);
        txtDateOfBirth.Text = objEmployeeDetail.DateOfBirth.ToString();
        UIUtility.SelectCurrentListItem(ddlMaritial, objEmployeeDetail.MaritialStatusObject.MetadataId, BindListItem.ByValue, true);
        txtMarriageDate.Text = objEmployeeDetail.MarriageDate.ToString();
        txtPhoto.Text = objEmployeeDetail.Photo;
        //uxEmployeeAdministrativeDetailUC.SetUserControlData(objEmployeeDetail.EmployeeAdministrativeDetailObject);
        //uxEmployeeFinancialDetailUC.SetUserControlData(objEmployeeDetail.EmployeeFinancialDetailObject);
        UIUtility.SelectCurrentListItem(ddlReligion, objEmployeeDetail.ReligionObject.MetadataId, BindListItem.ByValue, true);
        UIUtility.SelectCurrentListItem(ddlCastecategory, objEmployeeDetail.CastecategoryObject.MetadataId, BindListItem.ByValue, true);
        UIUtility.SelectCurrentListItem(ddlNationality, objEmployeeDetail.NationalityObject.MetadataId, BindListItem.ByValue, true);
        //uxCurrentAddressUC.SetUserControlData(objEmployeeDetail.CurrentAddressObject);
        //uxPermanentAddressUC.SetUserControlData(objEmployeeDetail.PermanentAddressObject);
        // uxPrimaryEmergencyUC.SetUserControlData(objEmployeeDetail.PrimaryEmergencyObject);
        //uxSecondryEmergencyUC.SetUserControlData(objEmployeeDetail.SecondryEmergencyObject);
        txtPersonalEmailId.Text = objEmployeeDetail.PersonalEmailId;
        txtOfficeEmailId.Text = objEmployeeDetail.OfficeEmailId;
        UIUtility.SelectCurrentListItem(ddlIsFresher, objEmployeeDetail.IsFresher, BindListItem.ByValue, true);
        txtCompaign.Text = objEmployeeDetail.Compaign;
        txtSsnNo.Text = objEmployeeDetail.SsnNo;
    }
    private void SaveEmployeeBIDetail()
    {
        objEmployeeDetail = GetObjectForBIDetail();
        objEmployeeDetailBL = new EmployeeDetailBL();
        if (objEmployeeDetail.EmployeeId > 0)
        {
            objEmployeeDetail = objEmployeeDetailBL.EditEmployeeBasicDetail(objEmployeeDetail);
            if (objEmployeeDetail.DbOperationStatus == CommonConstant.SUCCEED)
            {
                recordVersion = recordVersion + 1;
            }
            if (objEmployeeDetail.DbOperationStatus == CommonConstant.INVALID)
            {
                InitializeBIDetails();
                objEmployeeDetail.DbOperationStatus = CommonConstant.INVALID;
            }
        }
        else
        {
            objEmployeeDetail = objEmployeeDetailBL.SaveEmployeeBasicDetail(objEmployeeDetail);
            employeeId = Convert.ToInt32(objEmployeeDetail.EmployeeId);
            recordVersion = recordVersion + 1;
        }

        UIUtility.DisplayMessage(lblMessage, objEmployeeDetail.DbOperationStatus);
    }
    private EmployeeDetail GetObjectForBIDetail()
    {
        objEmployeeDetail = new EmployeeDetail();
        if (employeeId > 0)
        {
            objEmployeeDetail.Version = recordVersion + 1;
        }
        else
        {
            objEmployeeDetail.Version = BusinessUtility.RECORD_VERSION;
            objEmployeeDetail.CreatedBy = LoggedInUser;
            objEmployeeDetail.CreatedOn = GeneralUtility.CurrentDateTime;
        }

        objEmployeeDetail.EmployeeId = employeeId;
        objEmployeeDetail.EmployeeCode = txtEmployeeCode.Text;
        objEmployeeDetail.FirstName = txtFirstName.Text;
        objEmployeeDetail.MiddleName = txtMiddleName.Text;
        objEmployeeDetail.LastName = txtLastName.Text;
        objEmployeeDetail.FatherName = txtFatherName.Text;
        if (ddlGender.SelectedIndex != 0)
        {
            objEmployeeDetail.GenderObject = new MetadataMaster();
            objEmployeeDetail.GenderObject.MetadataId = Convert.ToInt32(ddlGender.SelectedItem.Value);
        }
        objEmployeeDetail.DateOfBirth = Convert.ToDateTime(txtDateOfBirth.Text);
        if (ddlMaritial.SelectedIndex != 0)
        {
            objEmployeeDetail.MaritialStatusObject = new MetadataMaster();
            objEmployeeDetail.MaritialStatusObject.MetadataId = Convert.ToInt32(ddlMaritial.SelectedItem.Value);
        }
        objEmployeeDetail.MarriageDate = Convert.ToDateTime(txtMarriageDate.Text);
        objEmployeeDetail.Photo = txtPhoto.Text;
        if (administrativeDetailId > 0)
        {
            objEmployeeDetail.EmployeeAdministrativeDetailObject = new EmployeeAdministrativeDetail();
            objEmployeeDetail.EmployeeAdministrativeDetailObject.EmployeeAdministrativeDetailId = Convert.ToInt32(administrativeDetailId);
        }
        if (financialDetailId > 0)
        {
            objEmployeeDetail.EmployeeFinancialDetailObject = new EmployeeFinancialDetail();
            objEmployeeDetail.EmployeeFinancialDetailObject.EmployeeFinancialDetailId = Convert.ToInt32(financialDetailId);
        }
        if (currentAddressId > 0)
        {
            objEmployeeDetail.CurrentAddressObject = new AddressDetail();
            objEmployeeDetail.CurrentAddressObject.AddressId = Convert.ToInt32(currentAddressId);
        }
        if (permanentAddressId > 0)
        {
            objEmployeeDetail.PermanentAddressObject = new AddressDetail();
            objEmployeeDetail.PermanentAddressObject.AddressId = Convert.ToInt32(permanentAddressId);
        }
        if (primaryEmergencyId > 0)
        {
            objEmployeeDetail.PrimaryEmergencyObject = new EmergencyDetail();
            objEmployeeDetail.PrimaryEmergencyObject.EmergencyDetailId = Convert.ToInt32(primaryEmergencyId);
        }
        if (secondryEmergencyId > 0)
        {
            objEmployeeDetail.SecondryEmergencyObject = new EmergencyDetail();
            objEmployeeDetail.SecondryEmergencyObject.EmergencyDetailId = Convert.ToInt32(secondryEmergencyId);
        }
        if (ddlReligion.SelectedIndex != 0)
        {
            objEmployeeDetail.ReligionObject = new MetadataMaster();
            objEmployeeDetail.ReligionObject.MetadataId = Convert.ToInt32(ddlReligion.SelectedItem.Value);
        }
        if (ddlCastecategory.SelectedIndex != 0)
        {
            objEmployeeDetail.CastecategoryObject = new MetadataMaster();
            objEmployeeDetail.CastecategoryObject.MetadataId = Convert.ToInt32(ddlCastecategory.SelectedItem.Value);
        }
        if (ddlNationality.SelectedIndex != 0)
        {
            objEmployeeDetail.NationalityObject = new MetadataMaster();
            objEmployeeDetail.NationalityObject.MetadataId = Convert.ToInt32(ddlNationality.SelectedItem.Value);
        }
        objEmployeeDetail.PersonalEmailId = txtPersonalEmailId.Text;
        objEmployeeDetail.IsFresher = Convert.ToBoolean(ddlIsFresher.SelectedItem.Text);
        objEmployeeDetail.OfficeEmailId = txtOfficeEmailId.Text;
        objEmployeeDetail.SsnNo = txtSsnNo.Text;
        objEmployeeDetail.Compaign = txtCompaign.Text;
        objEmployeeDetail.ModifiedBy = LoggedInUser;
        objEmployeeDetail.ModifiedOn = GeneralUtility.CurrentDateTime;
        objEmployeeDetail.RecordStatus = Convert.ToInt16(RecordStatus.Active);
        return objEmployeeDetail;
    }
    #endregion

    #region Administrative Details...
    private void InitializeADDetails()
    {
        if (administrativeDetailId > 0)
        {
            objEmployeeAdministrativeDetail = new EmployeeAdministrativeDetail();
            objEmployeeAdministrativeDetail.EmployeeAdministrativeDetailId = administrativeDetailId;
            objEmployeeAdministrativeDetail = SelectADDetailById(objEmployeeAdministrativeDetail);
            if (!objEmployeeAdministrativeDetail.DbOperationStatus.Equals(CommonConstant.FAIL))
            {
                PopulateADDetail(false, objEmployeeAdministrativeDetail);
            }
            else
            {
                UIUtility.DisplayMessage(lblMessage, objEmployeeAdministrativeDetail.DbOperationStatus);
            }
        }
        else
        {
            PopulateADDetail(true, null);
        }
    }
    private EmployeeAdministrativeDetail SelectADDetailById(EmployeeAdministrativeDetail _objEmployeeAdministrativeDetail)
    {
        objEmployeeAdministrativeDetailBL = new EmployeeAdministrativeDetailBL();
        _objEmployeeAdministrativeDetail = objEmployeeAdministrativeDetailBL.SelectRecordById(_objEmployeeAdministrativeDetail);
        return _objEmployeeAdministrativeDetail;
    }
    protected void PopulateADDetail(bool isNewRecord, EmployeeAdministrativeDetail _objEmployeeAdministrativeDetail)
    {
        UIUtility.InitializeControls(divAdministrativeDetail);
        BindADDetailControls();
        if (!isNewRecord)
        {
            FillADControlsData(_objEmployeeAdministrativeDetail);
        }
        else
        { }
    }
    protected void BindADDetailControls()
    {
        if (!Convert.ToBoolean(ViewState[isADControlsLoaded]))
        {
            uxEmployeeAdministrativeDetailUC.BindUCControls();
            ViewState[isADControlsLoaded] = true;
        }
    }
    private void FillADControlsData(EmployeeAdministrativeDetail _objEmployeeAdministrativeDetail)
    {
        uxEmployeeAdministrativeDetailUC.SetUserControlData(_objEmployeeAdministrativeDetail);
    }
    private void SaveEmployeeADDetail()
    {
        objEmployeeAdministrativeDetailBL = new EmployeeAdministrativeDetailBL();
        objEmployeeAdministrativeDetail = GetObjectForADDetail();
        objEmployeeAdministrativeDetail.ModifiedBy = LoggedInUser;
        objEmployeeAdministrativeDetail.ParentId = employeeId;
        objEmployeeAdministrativeDetail.ParentVersion = recordVersion;

        if (objEmployeeAdministrativeDetail.EmployeeAdministrativeDetailId > 0)
        {
            objEmployeeAdministrativeDetail = objEmployeeAdministrativeDetailBL.UpdateEmployeeAdministrativeDetail(objEmployeeAdministrativeDetail);
            if (objEmployeeAdministrativeDetail.DbOperationStatus == CommonConstant.SUCCEED)
            {
                recordVersion = recordVersion + 1;
            }
        }
        else
        {
            objEmployeeAdministrativeDetail = objEmployeeAdministrativeDetailBL.InsertEmployeeAdministrativeDetail(objEmployeeAdministrativeDetail);
            if (objEmployeeAdministrativeDetail.DbOperationStatus == CommonConstant.SUCCEED)
            {
                administrativeDetailId = Convert.ToInt32(objEmployeeAdministrativeDetail.EmployeeAdministrativeDetailId);
                recordVersion = recordVersion + 1;
            }
        }
        if (objEmployeeAdministrativeDetail.DbOperationStatus == CommonConstant.INVALID)
        {
            InitializeBIDetails();
            InitializeADDetails();
            objEmployeeAdministrativeDetail.DbOperationStatus = CommonConstant.INVALID;
        }
        UIUtility.DisplayMessage(lblMessage, objEmployeeAdministrativeDetail.DbOperationStatus);
    }
    private EmployeeAdministrativeDetail GetObjectForADDetail()
    {
        objEmployeeAdministrativeDetail = uxEmployeeAdministrativeDetailUC.GetUserControlData();
        objEmployeeAdministrativeDetail.EmployeeAdministrativeDetailId = administrativeDetailId;
        return objEmployeeAdministrativeDetail;
    }
    #endregion

    #region Financial Details....
    private void InitializeFDDetails()
    {
        if (financialDetailId > 0)
        {
            objEmployeeFinancialDetail = new EmployeeFinancialDetail();
            objEmployeeFinancialDetail.EmployeeFinancialDetailId = financialDetailId;
            objEmployeeFinancialDetail = SelectFDDetailById(objEmployeeFinancialDetail);
            if (!objEmployeeFinancialDetail.DbOperationStatus.Equals(CommonConstant.FAIL))
            {
                PopulateFDDetail(false, objEmployeeFinancialDetail);
            }
            else
            {
                UIUtility.DisplayMessage(lblMessage, objEmployeeFinancialDetail.DbOperationStatus);
            }
        }
        else
        {
            PopulateFDDetail(true, null);
        }
    }
    private EmployeeFinancialDetail SelectFDDetailById(EmployeeFinancialDetail _objEmployeeFinancialDetail)
    {
        objEmployeeFinancialDetailBL = new EmployeeFinancialDetailBL();
        objEmployeeFinancialDetail = objEmployeeFinancialDetailBL.SelectRecordById(_objEmployeeFinancialDetail);
        return _objEmployeeFinancialDetail;
    }
    protected void PopulateFDDetail(bool isNewRecord, EmployeeFinancialDetail _objEmployeeFinancialDetail)
    {
        UIUtility.InitializeControls(divEmployeeFinancialDetail);
        BindFDDetailControls();
        if (!isNewRecord)
        {
            FillFDControlsData(_objEmployeeFinancialDetail);
        }
        else
        {

        }
    }
    protected void BindFDDetailControls()
    {
        if (!Convert.ToBoolean(ViewState[isFDControlsLoaded]))
        {
            uxEmployeeFinancialDetailUC.BindUCControls();
            ViewState[isFDControlsLoaded] = true;
        }
    }
    private void FillFDControlsData(EmployeeFinancialDetail _objEmployeeFinancialDetail)
    {
        uxEmployeeFinancialDetailUC.SetUserControlData(_objEmployeeFinancialDetail);
    }
    private void SaveEmployeeFDDetail()
    {
        objEmployeeFinancialDetailBL = new EmployeeFinancialDetailBL();
        objEmployeeFinancialDetail = GetObjectForFDDetail();
        objEmployeeFinancialDetail.ModifiedBy = LoggedInUser;
        objEmployeeFinancialDetail.ParentId = employeeId;
        objEmployeeFinancialDetail.ParentVersion = recordVersion;

        if (objEmployeeFinancialDetail.EmployeeFinancialDetailId > 0)
        {
            objEmployeeFinancialDetail = objEmployeeFinancialDetailBL.UpdateEmployeeFinancialDetail(objEmployeeFinancialDetail);
            if (objEmployeeFinancialDetail.DbOperationStatus == CommonConstant.SUCCEED)
            {
                recordVersion = recordVersion + 1;
            }
        }
        else
        {
            objEmployeeFinancialDetail = objEmployeeFinancialDetailBL.InsertEmployeeFinancialDetail(objEmployeeFinancialDetail);
            if (objEmployeeFinancialDetail.DbOperationStatus == CommonConstant.SUCCEED)
            {
                financialDetailId = Convert.ToInt32(objEmployeeFinancialDetail.EmployeeFinancialDetailId);
                recordVersion = recordVersion + 1;
            }
        }
        if (objEmployeeFinancialDetail.DbOperationStatus == CommonConstant.INVALID)
        {
            InitializeBIDetails();
            InitializeFDDetails();
            objEmployeeFinancialDetail.DbOperationStatus = CommonConstant.INVALID;
        }
        UIUtility.DisplayMessage(lblMessage, objEmployeeFinancialDetail.DbOperationStatus);
    }
    private EmployeeFinancialDetail GetObjectForFDDetail()
    {
        objEmployeeFinancialDetail = uxEmployeeFinancialDetailUC.GetUserControlData();
        objEmployeeFinancialDetail.EmployeeFinancialDetailId = financialDetailId;
        return objEmployeeFinancialDetail;
    }
    #endregion

    #region Contact Info....
    private void InitializeCIDetails()
    {
        if (currentAddressId > 0)
        {
            objCurrentAddress = new AddressDetail();
            objCurrentAddress.AddressId = currentAddressId;
            objCurrentAddress = SelectCIDetailById(objCurrentAddress, null);

            objPermanentAddress = new AddressDetail();
            objPermanentAddress.AddressId = permanentAddressId;
            objPermanentAddress = SelectCIDetailById(objPermanentAddress, null);

            objPrimaryEmergencyDetail = new EmergencyDetail();
            objPrimaryEmergencyDetail.EmergencyDetailId = primaryEmergencyId;
            SelectCIDetailById(null, objPrimaryEmergencyDetail);

            objSecondryEmergencyDetail = new EmergencyDetail();
            objSecondryEmergencyDetail.EmergencyDetailId = secondryEmergencyId;
            SelectCIDetailById(null, objSecondryEmergencyDetail);

            if (!objCurrentAddress.DbOperationStatus.Equals(CommonConstant.FAIL) && !objPermanentAddress.DbOperationStatus.Equals(CommonConstant.FAIL)
                && !objPrimaryEmergencyDetail.DbOperationStatus.Equals(CommonConstant.FAIL) && !objSecondryEmergencyDetail.DbOperationStatus.Equals(CommonConstant.FAIL))
            {
                PopulateCIDetail(false, objCurrentAddress, objPermanentAddress, objPrimaryEmergencyDetail, objSecondryEmergencyDetail);
            }
            else
            {
                UIUtility.DisplayMessage(lblMessage, CommonConstant.FAIL);
            }
        }
        else
        {
            PopulateCIDetail(true, objCurrentAddress, objPermanentAddress, objPrimaryEmergencyDetail, objSecondryEmergencyDetail);
        }
    }
    private AddressDetail SelectCIDetailById(AddressDetail _objAddressDetail, EmergencyDetail _objEmergencyDetail)
    {
        if (_objAddressDetail != null)
        {
            objAddressDetailBL = new AddressDetailBL();
            _objAddressDetail = objAddressDetailBL.SelectRecordById(_objAddressDetail);
        }
        else
        {
            objEmergencyDetailBL = new EmergencyDetailBL();
            _objEmergencyDetail = objEmergencyDetailBL.SelectRecordById(_objEmergencyDetail);
        }

        return _objAddressDetail;
    }
    protected void PopulateCIDetail(bool isNewRecord, AddressDetail _objCurrentAddressDetail, AddressDetail _objPermanentAddressDetail,
        EmergencyDetail _objPrimaryEmergencyDetail, EmergencyDetail _objSecondryEmergencyDetail)
    {
        UIUtility.InitializeControls(divContactInformation);
        BindCIDetailControls();
        if (!isNewRecord)
        {
            FillCIControlsData(_objCurrentAddressDetail, _objPermanentAddressDetail, _objPrimaryEmergencyDetail, _objSecondryEmergencyDetail);
        }
        else
        {
            uxCurrentAddressUC.BindUCControls();
            uxPermanentAddressUC.BindUCControls();
        }
    }
    protected void BindCIDetailControls()
    {
        if (!Convert.ToBoolean(ViewState[isCIControlsLoaded]))
        {
            uxCurrentAddressUC.BindUCControls();
            uxPermanentAddressUC.BindUCControls();
            uxPrimaryEmergencyUC.BindUCControls();
            uxSecondryEmergencyUC.BindUCControls();
            ViewState[isCIControlsLoaded] = true;
        }
    }
    private void FillCIControlsData(AddressDetail _objCurrentAddressDetail, AddressDetail _objPermanentAddressDetail,
        EmergencyDetail _objPrimaryEmergencyDetail, EmergencyDetail _objSecondryEmergencyDetail)
    {
        uxCurrentAddressUC.SetUserControlData(_objCurrentAddressDetail);
        uxPermanentAddressUC.SetUserControlData(_objPermanentAddressDetail);
        uxPrimaryEmergencyUC.SetUserControlData(_objPrimaryEmergencyDetail);
        uxSecondryEmergencyUC.SetUserControlData(_objSecondryEmergencyDetail);
    }
    private void SaveEmployeeCIDetail()
    {
        objAddressDetailBL = new AddressDetailBL();
        objCurrentAddress = GetObjectForAddressDetail(true);
        objCurrentAddress.ModifiedBy = LoggedInUser;
        objCurrentAddress.ParentId = employeeId;
        objCurrentAddress.ParentVersion = recordVersion;

        objPermanentAddress = GetObjectForAddressDetail(false);
        objPermanentAddress.ParentId = employeeId;

        objEmergencyDetailBL = new EmergencyDetailBL();
        objPrimaryEmergencyDetail = GetObjectForEmergencyDetail(true);
        objPrimaryEmergencyDetail.ParentId = employeeId;
        objPrimaryEmergencyDetail.ParentVersion = recordVersion;

        objSecondryEmergencyDetail = GetObjectForEmergencyDetail(false);
        objSecondryEmergencyDetail.ParentId = employeeId;

        if (objCurrentAddress.AddressId > 0)
        {
            objCurrentAddress = objAddressDetailBL.EditEmployeeContactInfo(objCurrentAddress, objPermanentAddress,
                                                                        objPrimaryEmergencyDetail, objSecondryEmergencyDetail);
            if (objCurrentAddress.DbOperationStatus == CommonConstant.SUCCEED)
            {
                recordVersion = recordVersion + 1;
            }
        }
        else
        {
            objCurrentAddress = objAddressDetailBL.SaveEmployeeContactInfo(objCurrentAddress, objPermanentAddress,
                                                                        objPrimaryEmergencyDetail, objSecondryEmergencyDetail);
            if (objCurrentAddress.DbOperationStatus == CommonConstant.SUCCEED)
            {
                currentAddressId = Convert.ToInt32(objCurrentAddress.AddressId);
                permanentAddressId = Convert.ToInt32(objPermanentAddress.AddressId);
                primaryEmergencyId = Convert.ToInt32(objPrimaryEmergencyDetail.EmergencyDetailId);
                secondryEmergencyId = Convert.ToInt32(objSecondryEmergencyDetail.EmergencyDetailId);
                recordVersion = recordVersion + 1;
            }
        }
        if (objCurrentAddress.DbOperationStatus == CommonConstant.INVALID)
        {
            InitializeBIDetails();
            InitializeCIDetails();
            objCurrentAddress.DbOperationStatus = CommonConstant.INVALID;
        }
        UIUtility.DisplayMessage(lblMessage, objCurrentAddress.DbOperationStatus);
    }
    private AddressDetail GetObjectForAddressDetail(bool _isCurrentType)
    {
        AddressDetail objAddressDetail = null;
        if (_isCurrentType)
        {
            objAddressDetail = uxCurrentAddressUC.GetUserControlData();
            objAddressDetail.AddressId = currentAddressId;
        }
        else
        {
            objAddressDetail = uxPermanentAddressUC.GetUserControlData();
            objAddressDetail.AddressId = permanentAddressId;
        }

        return objAddressDetail;
    }
    private EmergencyDetail GetObjectForEmergencyDetail(bool _isPrimaryType)
    {
        EmergencyDetail objEmergencyDetail = null;
        if (_isPrimaryType)
        {
            objEmergencyDetail = uxPrimaryEmergencyUC.GetUserControlData();
            objEmergencyDetail.EmergencyDetailId = primaryEmergencyId;
        }
        else
        {
            objEmergencyDetail = uxSecondryEmergencyUC.GetUserControlData();
            objEmergencyDetail.EmergencyDetailId = secondryEmergencyId;
        }

        return objEmergencyDetail;
    }
    #endregion

    #region Joining Detail
    private void InitializeJDDetails()
    {
        uxEmployeeJoiningDetailUC.InitializeUserControl(employeeId);
    }
    private void SaveEmployeeJDDetail()
    {
        EmployeeJoiningDetail objEmployeeJoiningDetail = null;
        EmployeeJoiningDetailBL objEmployeeJoiningDetailBL = new EmployeeJoiningDetailBL();
        List<EmployeeJoiningDetail> objEmployeeJoiningDetailList = uxEmployeeJoiningDetailUC.GetEmployeeJoiningDetailList(employeeId);

        objEmployeeJoiningDetail = objEmployeeJoiningDetailList[0];
        objEmployeeJoiningDetail.EmployeeObject = new EmployeeDetail();
        objEmployeeJoiningDetail.EmployeeObject.EmployeeId = employeeId;
        objEmployeeJoiningDetail.EmployeeObject.Version = recordVersion;
        objEmployeeJoiningDetail.EmployeeObject.ModifiedBy = LoggedInUser;
        objEmployeeJoiningDetail.EmployeeObject.ModifiedOn = GeneralUtility.CurrentDateTime;

        objEmployeeJoiningDetail = objEmployeeJoiningDetailBL.SubmitEmployeeJoiningDetailData(objEmployeeJoiningDetailList);
        if (objEmployeeJoiningDetail.DbOperationStatus == CommonConstant.SUCCEED)
        {
            recordVersion = recordVersion + 1;
        }
        if (objEmployeeJoiningDetail.DbOperationStatus == CommonConstant.INVALID)
        {
            InitializeBIDetails();
            InitializeJDDetails();
            objEmployeeJoiningDetail.DbOperationStatus = CommonConstant.INVALID;
        }
        UIUtility.DisplayMessage(lblMessage, objEmployeeJoiningDetail.DbOperationStatus);
    }
    #endregion

    #region Reporting Detail
    private void InitializeRDDetails()
    {
        uxReportingDetailUC.InitializeUserControl(employeeId);
    }
    private void SaveEmployeeRDDetail()
    {
        ReportingDetailBL objReportingDetailBL = new ReportingDetailBL();
        ReportingDetail objReportingDetail = new ReportingDetail();
        List<ReportingDetail> objReportingDetailList = uxReportingDetailUC.GetReportingDetailList(employeeId);
        objReportingDetail.EmployeeObject = objReportingDetailList[0].EmployeeObject;
        objReportingDetail.EmployeeObject.EmployeeId = employeeId;
        objReportingDetail.EmployeeObject.Version = recordVersion;
        objReportingDetail.EmployeeObject.ModifiedBy = LoggedInUser;
        objReportingDetail.EmployeeObject.ModifiedOn = GeneralUtility.CurrentDateTime;

        objReportingDetail = objReportingDetailBL.SubmitReportingDetailData(objReportingDetailList);
        if (objReportingDetail.DbOperationStatus == CommonConstant.SUCCEED)
        {
            recordVersion = recordVersion + 1;
        }
        if (objReportingDetail.DbOperationStatus == CommonConstant.INVALID)
        {
            InitializeBIDetails();
            InitializeRDDetails();
            objReportingDetail.DbOperationStatus = CommonConstant.INVALID;
        }
        UIUtility.DisplayMessage(lblMessage, objReportingDetail.DbOperationStatus);
    }
    #endregion

    #region Skill Details
    private void InitializeSDDetails()
    {
        uxSkillDetailUC.InitializeUserControl(employeeId, MemberType.Employee);
        uxKnownLanguageUC.InitializeUserControl(employeeId, MemberType.Employee, MetadataTypeEnum.Language);
    }
    private void SaveEmployeeSDDetail()
    {
        SkillDetailBL objSkillDetailBL = new SkillDetailBL();
        KnownLanguage objKnownLanguage = new KnownLanguage();
        SkillDetail objSkillDetail = null;

        List<SkillDetail> objSkillDetailList = uxSkillDetailUC.GetSkillDetailColection(employeeId, Convert.ToInt32(MemberType.Employee));
        List<KnownLanguage> objKnownLanguageList = uxKnownLanguageUC.GetKnownLanguageColection(employeeId, Convert.ToInt32(MemberType.Employee));

        objSkillDetail = objSkillDetailList[0];
        objSkillDetail.ParentId = employeeId;
        objSkillDetail.ParentVersion = recordVersion;
        objSkillDetail.ModifiedBy = LoggedInUser;
        objSkillDetail.ModifiedOn = GeneralUtility.CurrentDateTime;
        objSkillDetail = objSkillDetailBL.SubmitSkillDetailData(objSkillDetailList, objKnownLanguageList);

        if (objSkillDetail.DbOperationStatus == CommonConstant.SUCCEED)
        {
            recordVersion = recordVersion + 1;
        }
        if (objSkillDetail.DbOperationStatus == CommonConstant.INVALID)
        {
            InitializeBIDetails();
            InitializeSDDetails();
            objSkillDetail.DbOperationStatus = CommonConstant.INVALID;
        }
        UIUtility.DisplayMessage(lblMessage, objSkillDetail.DbOperationStatus);
    }
    #endregion

    #region Medical Detail
    private void InitializeMDDetails()
    {
        uxEmployeeMedicalDetailUC.InitializeUserControl(employeeId);
    }
    private void SaveEmployeeMDDetail()
    {
        EmployeeMedicalDetail objEmployeeMedicalDetail = null;
        EmployeeMedicalDetailBL objEmployeeMedicalDetailBL = new EmployeeMedicalDetailBL();
        List<EmployeeMedicalDetail> objEmployeeMedicalDetailList = uxEmployeeMedicalDetailUC.GetEmployeeMedicalDetailList(employeeId);

        objEmployeeMedicalDetail = objEmployeeMedicalDetailList[0];
        objEmployeeMedicalDetail.EmployeeObject = new EmployeeDetail();
        objEmployeeMedicalDetail.EmployeeObject.EmployeeId = employeeId;
        objEmployeeMedicalDetail.EmployeeObject.Version = recordVersion;
        objEmployeeMedicalDetail.EmployeeObject.ModifiedBy = LoggedInUser;
        objEmployeeMedicalDetail.EmployeeObject.ModifiedOn = GeneralUtility.CurrentDateTime;

        objEmployeeMedicalDetail = objEmployeeMedicalDetailBL.SubmitEmployeeMedicalDetailData(objEmployeeMedicalDetailList);
        if (objEmployeeMedicalDetail.DbOperationStatus == CommonConstant.SUCCEED)
        {
            recordVersion = recordVersion + 1;
        }
        if (objEmployeeMedicalDetail.DbOperationStatus == CommonConstant.INVALID)
        {
            InitializeBIDetails();
            InitializeMDDetails();
            objEmployeeMedicalDetail.DbOperationStatus = CommonConstant.INVALID;
        }
        UIUtility.DisplayMessage(lblMessage, objEmployeeMedicalDetail.DbOperationStatus);
    }
    #endregion

    #region Educational Details
    private void InitializeEDDetails()
    {
        Session[UserDataKeys.EMPLOYEEEDUCATIONALDETAIL_EMPLOYEEID] = null;
        uxEmployeeEducationalDetailUC.InitializeUserControl(employeeId, UserDataKeys.EMPLOYEEEDUCATIONALDETAIL_EMPLOYEEID);
    }
    private void SaveEmployeeEDDetail()
    {
        EmployeeEducationalDetail objEmployeeEducationalDetail = new EmployeeEducationalDetail();
        EmployeeEducationalDetailBL objEmployeeEducationalDetailBL = new EmployeeEducationalDetailBL();
        objEmployeeEducationalDetail.EmployeeObject = new EmployeeDetail();
        objEmployeeEducationalDetail.EmployeeObject.EmployeeId = employeeId;
        objEmployeeEducationalDetail.EmployeeObject.Version = recordVersion;
        objEmployeeEducationalDetail.EmployeeObject.ModifiedBy = LoggedInUser;
        objEmployeeEducationalDetail.EmployeeObject.ModifiedOn = GeneralUtility.CurrentDateTime;

        objEmployeeEducationalDetail.ObjectDataSet = ((DataTable)Session[UserDataKeys.EMPLOYEEEDUCATIONALDETAIL_EMPLOYEEID]).DataSet;
        objEmployeeEducationalDetail = objEmployeeEducationalDetailBL.SubmitEmployeeEducationalDetailData(objEmployeeEducationalDetail);
        if (objEmployeeEducationalDetail.DbOperationStatus == CommonConstant.SUCCEED)
        {
            recordVersion = recordVersion + 1;
        }
        if (objEmployeeEducationalDetail.DbOperationStatus == CommonConstant.INVALID)
        {
            InitializeBIDetails();
            InitializeEDDetails();
            objEmployeeEducationalDetail.DbOperationStatus = CommonConstant.INVALID;
        }
        UIUtility.DisplayMessage(lblMessage, objEmployeeEducationalDetail.DbOperationStatus);
    }
    #endregion

    #region Previous Organisation Details
    private void InitializePODetails()
    {
        Session[UserDataKeys.EMPLOYEEPREVIOUSORGANISATIONDETAIL_EMPLOYEEID] = null;
        uxEmployeePreviousOrganisationDetailUC.InitializeUserControl(employeeId, UserDataKeys.EMPLOYEEPREVIOUSORGANISATIONDETAIL_EMPLOYEEID);
    }
    private void SaveEmployeePODetail()
    {
        EmployeePreviousOrganisationDetail objEmployeePreviousOrganisationDetail = new EmployeePreviousOrganisationDetail();
        EmployeePreviousOrganisationDetailBL objEmployeePreviousOrganisationDetailBL = new EmployeePreviousOrganisationDetailBL();
        objEmployeePreviousOrganisationDetail.EmployeeObject = new EmployeeDetail();
        objEmployeePreviousOrganisationDetail.EmployeeObject.EmployeeId = employeeId;
        objEmployeePreviousOrganisationDetail.EmployeeObject.Version = recordVersion;
        objEmployeePreviousOrganisationDetail.EmployeeObject.ModifiedBy = LoggedInUser;
        objEmployeePreviousOrganisationDetail.EmployeeObject.ModifiedOn = GeneralUtility.CurrentDateTime;

        objEmployeePreviousOrganisationDetail.ObjectDataSet = ((DataTable)Session[UserDataKeys.EMPLOYEEPREVIOUSORGANISATIONDETAIL_EMPLOYEEID]).DataSet;
        objEmployeePreviousOrganisationDetail = objEmployeePreviousOrganisationDetailBL.SubmitEmployeePreviousOrganisationDetailData(objEmployeePreviousOrganisationDetail);
        if (objEmployeePreviousOrganisationDetail.DbOperationStatus == CommonConstant.SUCCEED)
        {
            recordVersion = recordVersion + 1;
        }
        if (objEmployeePreviousOrganisationDetail.DbOperationStatus == CommonConstant.INVALID)
        {
            InitializeBIDetails();
            InitializePODetails();
            objEmployeePreviousOrganisationDetail.DbOperationStatus = CommonConstant.INVALID;
        }
        UIUtility.DisplayMessage(lblMessage, objEmployeePreviousOrganisationDetail.DbOperationStatus);
    }
    #endregion

    #region Others Details
    private void InitializeODDetails()
    {
        Session[UserDataKeys.EMPLOYEEFAMILYDETAIL_EMPLOYEEID] = null;
        uxEmployeeFamilyDetailUC.InitializeUserControl(employeeId, UserDataKeys.EMPLOYEEFAMILYDETAIL_EMPLOYEEID);

        Session[UserDataKeys.LICENCEDETAIL_MEMBERID] = null;
        uxLicenceDetailUC.InitializeUserControl(employeeId, UserDataKeys.LICENCEDETAIL_MEMBERID, Convert.ToInt32(MemberType.Employee));

        Session[UserDataKeys.IMMIGRATIONDETAIL_MEMBERID] = null;
        uxImmigrationDetailUC.InitializeUserControl(employeeId, UserDataKeys.IMMIGRATIONDETAIL_MEMBERID, Convert.ToInt32(MemberType.Employee));
    }
    private void SaveEmployeeODDetail()
    {
        EmployeeFamilyDetail objEmployeeFamilyDetail = new EmployeeFamilyDetail();
        EmployeeFamilyDetailBL objEmployeeFamilyDetailBL = new EmployeeFamilyDetailBL();
        LicenceDetail objLicenceDetail = new LicenceDetail();
        LicenceDetailBL objLicenceDetailBL = new LicenceDetailBL();
        ImmigrationDetail objImmigrationDetail = new ImmigrationDetail();
        ImmigrationDetailBL objImmigrationDetailBL = new ImmigrationDetailBL();

        objEmployeeFamilyDetail.ObjectDataSet = ((DataTable)Session[UserDataKeys.EMPLOYEEFAMILYDETAIL_EMPLOYEEID]).DataSet;
        objEmployeeFamilyDetail.EmployeeObject = new EmployeeDetail();
        objEmployeeFamilyDetail.EmployeeObject.EmployeeId = employeeId;
        objEmployeeFamilyDetail.EmployeeObject.Version = recordVersion;
        objEmployeeFamilyDetail.EmployeeObject.ModifiedBy = LoggedInUser;
        objEmployeeFamilyDetail.EmployeeObject.ModifiedOn = GeneralUtility.CurrentDateTime;

        objLicenceDetail.ObjectDataSet = ((DataTable)Session[UserDataKeys.LICENCEDETAIL_MEMBERID]).DataSet;
        objLicenceDetail.MemberObject = new EmployeeDetail();
        objLicenceDetail.MemberObject.EmployeeId = employeeId;

        objImmigrationDetail.ObjectDataSet = ((DataTable)Session[UserDataKeys.IMMIGRATIONDETAIL_MEMBERID]).DataSet;
        objImmigrationDetail.MemberObject = new EmployeeDetail();
        objImmigrationDetail.MemberObject.EmployeeId = employeeId;

        objEmployeeFamilyDetail = objEmployeeFamilyDetailBL.SubmitEmployeeFamilyDetailData(objEmployeeFamilyDetail, objLicenceDetail, objImmigrationDetail);

        if (objEmployeeFamilyDetail.DbOperationStatus == CommonConstant.SUCCEED)
        {
            InitializeODDetails();
            recordVersion = recordVersion + 1;
        }
        if (objEmployeeFamilyDetail.DbOperationStatus == CommonConstant.INVALID)
        {
            InitializeBIDetails();
            InitializeODDetails();
            objEmployeeFamilyDetail.DbOperationStatus = CommonConstant.INVALID;
        }
        UIUtility.DisplayMessage(lblMessage, objEmployeeFamilyDetail.DbOperationStatus);
    }
    #endregion

    #region Action Events...
    protected void linkButton_Click(object sender, EventArgs e)
    {
        LinkButton linkbtn = (LinkButton)sender;
        SetCurrentView(linkbtn.CommandArgument);
        switch (linkbtn.CommandArgument)
        {
            case "BI":
                InitializeBIDetails();
                break;
            case "AD":
                InitializeADDetails();
                break;
            case "FD":
                InitializeFDDetails();
                break;
            case "CI":
                InitializeCIDetails();
                break;
            case "JD":
                InitializeJDDetails();
                break;
            case "RD":
                InitializeRDDetails();
                break;
            case "SD":
                InitializeSDDetails();
                break;
            case "MD":
                InitializeMDDetails();
                break;
            case "ED":
                InitializeEDDetails();
                break;
            case "PO":
                InitializePODetails();
                break;
            case "OD":
                InitializeODDetails();
                break;
            default:
                InitializeBIDetails();
                break;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (!hdnfLinkName.Value.ToUpper().Equals("BI"))
        {
            if (employeeId <= 0)
            {
                SetCurrentView("BI");
                UIUtility.DisplayMessage(lblMessage, strMessage, MessageType.Error);
                return;
            }
        }
        switch (hdnfLinkName.Value)
        {
            case "BI":
                SaveEmployeeBIDetail();
                break;
            case "AD":
                SaveEmployeeADDetail();
                break;
            case "FD":
                SaveEmployeeFDDetail();
                break;
            case "CI":
                SaveEmployeeCIDetail();
                break;
            case "JD":
                SaveEmployeeJDDetail();
                break;
            case "RD":
                SaveEmployeeRDDetail();
                break;
            case "SD":
                SaveEmployeeSDDetail();
                break;
            case "MD":
                SaveEmployeeMDDetail();
                break;
            case "ED":
                SaveEmployeeEDDetail();
                break;
            case "PO":
                SaveEmployeePODetail();
                break;
            case "OD":
                SaveEmployeeODDetail();
                break;
            default:
                break;
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        switch (hdnfLinkName.Value)
        {
            case "BI":
                InitializeBIDetails();
                break;
            case "AD":
                InitializeADDetails();
                break;
            case "FD":
                InitializeFDDetails();
                break;
            case "CI":
                InitializeCIDetails();
                break;
            case "JD":
                InitializeJDDetails();
                break;
            case "RD":
                InitializeRDDetails();
                break;
            case "SD":
                InitializeSDDetails();
                break;
            case "MD":
                InitializeMDDetails();
                break;
            case "ED":
                InitializeEDDetails();
                break;
            case "PO":
                InitializePODetails();
                break;
            case "OD":
                InitializeODDetails();
                break;
            default:
                break;
        }
    }
    #endregion

    #region Helper Functions
    private void SetCurrentView(string _viewId)
    {
        divBasicDetail.Style.Value = "display:none";
        divAdministrativeDetail.Style.Value = "display:none";
        divEmployeeFinancialDetail.Style.Value = "display:none";
        divContactInformation.Style.Value = "display:none";
        divJoiningDetail.Style.Value = "display:none";
        divReportingDetail.Style.Value = "display:none";
        divSkillDetail.Style.Value = "display:none";
        divMedicalDetail.Style.Value = "display:none";
        divEducationalDetail.Style.Value = "display:none";
        divPreviousOrganisationDetail.Style.Value = "display:none";
        divOtherDetail.Style.Value = "display:none";

        switch (_viewId.ToUpper())
        {
            case "AD":
                hdnfLinkName.Value = "AD";
                divAdministrativeDetail.Style.Value = "display:block";
                break;
            case "FD":
                hdnfLinkName.Value = "FD";
                divEmployeeFinancialDetail.Style.Value = "display:block";
                break;
            case "CI":
                hdnfLinkName.Value = "CI";
                divContactInformation.Style.Value = "display:block";
                break;
            case "JD":
                hdnfLinkName.Value = "JD";
                divJoiningDetail.Style.Value = "display:block";
                break;
            case "RD":
                hdnfLinkName.Value = "RD";
                divReportingDetail.Style.Value = "display:block";
                break;
            case "SD":
                hdnfLinkName.Value = "SD";
                divSkillDetail.Style.Value = "display:block";
                break;
            case "MD":
                hdnfLinkName.Value = "MD";
                divMedicalDetail.Style.Value = "display:block";
                break;
            case "ED":
                hdnfLinkName.Value = "ED";
                divEducationalDetail.Style.Value = "display:block";
                break;
            case "PO":
                hdnfLinkName.Value = "PO";
                divPreviousOrganisationDetail.Style.Value = "display:block";
                break;
            case "OD":
                hdnfLinkName.Value = "OD";
                divOtherDetail.Style.Value = "display:block";
                break;
            default:
                hdnfLinkName.Value = "BI";
                divBasicDetail.Style.Value = "display:block";
                break;
        }
    }
    private bool ValidateObject()
    {
        return true;
    }
    #endregion
}