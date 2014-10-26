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

public partial class RegistrationMasterUI : BasePage
{
    #region Page Variables
    RegistrationMaster objRegistrationMaster = null;
    RegistrationMasterBL objRegistrationMasterBL = null;
    ClassMaster objClassMaster = null;
    ClassMasterBL objClassMasterBL = null;
    StreamMaster objStreamMaster = null;
    StreamMasterBL objStreamMasterBL = null;
    BranchMaster objBranchMaster = null;
    BranchMasterBL objBranchMasterBL = null;
    AcademicSessionMaster objAcademicSessionMaster = null;
    AcademicSessionMasterBL objAcademicSessionMasterBL = null;

    private const int SELECT_COLUMN = 0;
    private const int ACTIVATE_COLUMN = 1;
    private const int DELETE_COLUMN = 2;

    private const int REGISTRATION_ID_INDEX = 0;
    private const int VERSION_INDEX = 1;
    private string isControlsLoaded = "ControlsLoaded";
    private string editIndexKey = "EditIndexKey";
    #endregion

    #region Page Events and Functions
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                InitializeForm();
            }

        }
        catch (Exception ex)
        {
            btnAddNewRecord.Enabled = false;
            lblMessage.Text = ex.Message;
        }
    }
    private void InitializeForm()
    {
        if (!Page.IsPostBack)
        {
            Page.DataBind();
            objRegistrationMaster = BindRegistrationMasterGrid(RecordStatus.Active);
            if (objRegistrationMaster.DbOperationStatus != CommonConstant.SUCCEED)
            {
                btnAddNewRecord.Enabled = false;
                UIUtility.DisplayMessage(lblMessage, objRegistrationMaster.DbOperationStatus);
                return;
            }

            ViewState[isControlsLoaded] = false;

            if (grdRegistrationMaster.Rows.Count == 0)
            {
                BindRegistrationMasterControls();
                MultiViewRegistrationMaster.ActiveViewIndex = 1;
                wzdRegistrationMaster.ActiveStepIndex = 0;
            }

        }
        else
        {
            if (rdbActiveRecord.Checked)
            {
                objRegistrationMaster = BindRegistrationMasterGrid(RecordStatus.Active);
                if (objRegistrationMaster.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    UIUtility.DisplayMessage(lblMessage, objRegistrationMaster.DbOperationStatus);
                    return;
                }
                ViewActivateColumn(false);
            }
            else
            {
                objRegistrationMaster = BindRegistrationMasterGrid(RecordStatus.InActive);
                if (objRegistrationMaster.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    UIUtility.DisplayMessage(lblMessage, objRegistrationMaster.DbOperationStatus);
                    return;
                }
                ViewActivateColumn(true);
            }
        }
        btnAddNewRecord.Enabled = true;
    }
    private void ViewActivateColumn(bool view)
    {
        if (view)
        {
            grdRegistrationMaster.Columns[SELECT_COLUMN].Visible = false;
            grdRegistrationMaster.Columns[ACTIVATE_COLUMN].Visible = true;
            grdRegistrationMaster.Columns[DELETE_COLUMN].Visible = false;
        }
        else
        {
            grdRegistrationMaster.Columns[SELECT_COLUMN].Visible = true;
            grdRegistrationMaster.Columns[ACTIVATE_COLUMN].Visible = false;
            grdRegistrationMaster.Columns[DELETE_COLUMN].Visible = true;
        }
    }
    #endregion

    #region Grid Events and Functions
    protected void grdRegistrationMaster_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            objRegistrationMaster = SelectRecordById(grdRegistrationMaster.SelectedIndex);
            if (!objRegistrationMaster.DbOperationStatus.Equals(CommonConstant.FAIL))
            {
                if (!Convert.ToBoolean(objRegistrationMaster.IsRecordChanged))
                {
                    ActivateControlsView(false, objRegistrationMaster, grdRegistrationMaster.SelectedIndex);
                    wzdRegistrationMaster.ActiveStepIndex = 0;
                }
                else
                {
                    UIUtility.DisplayMessage(lblMessage, objRegistrationMaster.DbOperationStatus);
                    InitializeForm();
                }
            }
            else
            {
                UIUtility.DisplayMessage(lblMessage, objRegistrationMaster.DbOperationStatus);
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void grdRegistrationMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            objRegistrationMasterBL = new RegistrationMasterBL();
            objRegistrationMaster = GetObjectForActivateDeactivate(e.RowIndex, RecordStatus.InActive);
            objRegistrationMaster = objRegistrationMasterBL.ActivateDeactivateRegistrationMaster(objRegistrationMaster);
            UIUtility.DisplayMessage(lblMessage, objRegistrationMaster.DbOperationStatus);
            InitializeForm();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void grdRegistrationMaster_ActivatingObject(object sender, GridViewEditEventArgs e)
    {
        try
        {
            objRegistrationMasterBL = new RegistrationMasterBL();
            objRegistrationMaster = GetObjectForActivateDeactivate(e.NewEditIndex, RecordStatus.Active);
            objRegistrationMaster = objRegistrationMasterBL.ActivateDeactivateRegistrationMaster(objRegistrationMaster);
            UIUtility.DisplayMessage(lblMessage, objRegistrationMaster.DbOperationStatus);
            InitializeForm();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void grdRegistrationMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grdRegistrationMaster.PageIndex = e.NewPageIndex;
            InitializeForm();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected RegistrationMaster BindRegistrationMasterGrid(RecordStatus objRecordStatus)
    {
        objRegistrationMasterBL = new RegistrationMasterBL();
        objRegistrationMaster = new RegistrationMaster();
        objRegistrationMaster.RecordStatus = Convert.ToInt16(objRecordStatus);

        objRegistrationMaster = objRegistrationMasterBL.SelectRegistrationMaster(objRegistrationMaster);
        if (objRegistrationMaster.DbOperationStatus == CommonConstant.SUCCEED)
        {
            grdRegistrationMaster.DataSource = objRegistrationMaster.ObjectDataSet.Tables[0];
            grdRegistrationMaster.DataBind();
        }
        return objRegistrationMaster;
    }
    #endregion

    #region Controls Events and Functions
    protected void btnAddNewRecord_Click(object sender, EventArgs e)
    {
        try
        {
            ActivateControlsView(true, null, null);
            wzdRegistrationMaster.ActiveStepIndex = 0;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void rdbActiveRecord_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            InitializeForm();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void rdbInActiveRecord_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            InitializeForm();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void BindRegistrationMasterControls()
    {
        if (!Convert.ToBoolean(ViewState[isControlsLoaded]))
        {

            objBranchMasterBL = new BranchMasterBL();
            objBranchMaster = new BranchMaster();
            objBranchMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
            objBranchMaster = objBranchMasterBL.SelectBranchMaster(objBranchMaster);
            ddlBranch.DataSource = objBranchMaster.ObjectDataSet.Tables[0];
            ddlBranch.DataBind();
            ddlBranch.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

            objAcademicSessionMasterBL = new AcademicSessionMasterBL();
            objAcademicSessionMaster = new AcademicSessionMaster();
            objAcademicSessionMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
            objAcademicSessionMaster = objAcademicSessionMasterBL.SelectAcademicSessionMaster(objAcademicSessionMaster);
            ddlAcademic.DataSource = objAcademicSessionMaster.ObjectDataSet.Tables[0];
            ddlAcademic.DataBind();
            ddlAcademic.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

            objClassMasterBL = new ClassMasterBL();
            objClassMaster = new ClassMaster();
            objClassMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
            objClassMaster = objClassMasterBL.SelectClassMaster(objClassMaster);
            ddlClass.DataSource = objClassMaster.ObjectDataSet.Tables[0];
            ddlClass.DataBind();
            ddlClass.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

            objStreamMasterBL = new StreamMasterBL();
            objStreamMaster = new StreamMaster();
            objStreamMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
            objStreamMaster = objStreamMasterBL.SelectStreamMaster(objStreamMaster);
            ddlStream.DataSource = objStreamMaster.ObjectDataSet.Tables[0];
            ddlStream.DataBind();
            ddlStream.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

            ViewState[isControlsLoaded] = true;
        }
        if (ViewState[editIndexKey] != null)
        {
            Session[UserDataKeys.RESERVATIONDETAIL_REGISTRATIONID] = null;
            Session[UserDataKeys.REGISTRATIONELIGIBILITY_REGISTRATIONID] = null;
            int _dataKey = Convert.ToInt32(grdRegistrationMaster.DataKeys[Convert.ToInt32(ViewState[editIndexKey])].Values[REGISTRATION_ID_INDEX].ToString());
            uxReservationDetailUC.InitializeUserControl(_dataKey, UserDataKeys.RESERVATIONDETAIL_REGISTRATIONID);
            uxRegistrationEligibilityUC.InitializeUserControl(_dataKey, UserDataKeys.REGISTRATIONELIGIBILITY_REGISTRATIONID);
        }
        else
        {
            Session[UserDataKeys.RESERVATIONDETAIL_REGISTRATIONID] = null;
            Session[UserDataKeys.REGISTRATIONELIGIBILITY_REGISTRATIONID] = null;
            uxReservationDetailUC.InitializeUserControl(UIUtility.DEFAULT_ID, UserDataKeys.RESERVATIONDETAIL_REGISTRATIONID);
            uxRegistrationEligibilityUC.InitializeUserControl(UIUtility.DEFAULT_ID, UserDataKeys.REGISTRATIONELIGIBILITY_REGISTRATIONID);
        }
    }
    protected void ActivateControlsView(bool isNewRecord, RegistrationMaster objRegistrationMaster, int? editIndex)
    {
        if (isNewRecord)
        {
            ViewState[editIndexKey] = null;
            BindRegistrationMasterControls();
            InitializeControls();
        }
        else
        {
            ViewState[editIndexKey] = editIndex;
            BindRegistrationMasterControls();
            PopulateControlsData(objRegistrationMaster);
        }
        MultiViewRegistrationMaster.ActiveViewIndex = 1;
    }
    private void PopulateControlsData(RegistrationMaster objRegistrationMaster)
    {
        txtRegistrationName.Text = objRegistrationMaster.RegistrationName;
        UIUtility.SelectCurrentListItem(ddlClass, objRegistrationMaster.ClassObject.ClassId, BindListItem.ByValue, true);
        UIUtility.SelectCurrentListItem(ddlStream, objRegistrationMaster.StreamObject.StreamId, BindListItem.ByValue, true);
        UIUtility.SelectCurrentListItem(ddlBranch, objRegistrationMaster.BranchObject.BranchId, BindListItem.ByValue, true);
        txtStartDate.Text = GeneralUtility.ToStandardDate(objRegistrationMaster.StartDate.ToString()).ToString();
        txtEndDate.Text = GeneralUtility.ToStandardDate(objRegistrationMaster.EndDate.ToString()).ToString();
        UIUtility.SelectCurrentListItem(ddlAcademic, objRegistrationMaster.AcademicSessionObject.SessionId, BindListItem.ByValue, true);
        txtTotalSeat.Text = objRegistrationMaster.TotalSeat.ToString();
        txtManagementSeat.Text = objRegistrationMaster.ManagementSeat.ToString();
        txtRegistrationFee.Text = objRegistrationMaster.RegistrationFee.ToString();
        UIUtility.SelectCurrentListItem(ddlIsPartialFeeAllowed, objRegistrationMaster.IsPartialFeeAllowed, BindListItem.ByValue, true);

        txtInstruction.Text = objRegistrationMaster.Instruction;
        txtDisclaimer.Text = objRegistrationMaster.Disclaimer;
    }
    protected void wzdRegistrationMaster_FinishButtonClick(object sender, WizardNavigationEventArgs e)
    {
        try
        {
            if (ValidateObject())
            {
                objRegistrationMaster = GetObjectForInsertUpdate();
                objRegistrationMasterBL = new RegistrationMasterBL();
                if (objRegistrationMaster.RegistrationId == null)
                {
                    objRegistrationMaster = objRegistrationMasterBL.InsertRegistrationMaster(objRegistrationMaster);
                }
                else
                {
                    objRegistrationMaster = objRegistrationMasterBL.UpdateRegistrationMaster(objRegistrationMaster);
                }
                if (objRegistrationMaster.DbOperationStatus == CommonConstant.SUCCEED
                            || objRegistrationMaster.DbOperationStatus == CommonConstant.INVALID)
                {
                    InitializeForm();
                    MultiViewRegistrationMaster.ActiveViewIndex = 0;
                }

                UIUtility.DisplayMessage(lblMessage, objRegistrationMaster.DbOperationStatus);
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void wzdRegistrationMaster_CancelButtonClick(object sender, EventArgs e)
    {
        try
        {
            MultiViewRegistrationMaster.ActiveViewIndex = 0;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }

    #endregion

    #region Helper Functions
    private bool ValidateObject()
    {
        return true;
    }
    private RegistrationMaster GetObjectForInsertUpdate()
    {
        objRegistrationMaster = new RegistrationMaster();

        if (ViewState[editIndexKey] == null)
        {
            objRegistrationMaster.Version = BusinessUtility.RECORD_VERSION;
            objRegistrationMaster.CreatedBy = LoggedInUser;
            objRegistrationMaster.CreatedOn = GeneralUtility.CurrentDateTime;
            objRegistrationMaster.RegistrationStatusObject = new MetadataMaster();
            objRegistrationMaster.RegistrationStatusObject.MetadataId = Convert.ToInt32(RegistrationStatus.Created);//Convert.ToInt32(ddlRegistrationStatus.SelectedItem.Value);
        }
        else
        {
            objRegistrationMaster.RegistrationId = Convert.ToInt32(grdRegistrationMaster.DataKeys[Convert.ToInt32(ViewState[editIndexKey])].Values[REGISTRATION_ID_INDEX].ToString());
            objRegistrationMaster.Version = Convert.ToInt16(grdRegistrationMaster.DataKeys[Convert.ToInt16(ViewState[editIndexKey])].Values[VERSION_INDEX].ToString()) + 1;
        }

        objRegistrationMaster.RegistrationName = txtRegistrationName.Text;

        if (ddlBranch.SelectedIndex != 0)
        {
            objRegistrationMaster.BranchObject = new BranchMaster();
            objRegistrationMaster.BranchObject.BranchId = Convert.ToInt32(ddlBranch.SelectedItem.Value);
        }
        if (ddlAcademic.SelectedIndex != 0)
        {
            objRegistrationMaster.AcademicSessionObject = new AcademicSessionMaster();
            objRegistrationMaster.AcademicSessionObject.SessionId = Convert.ToInt32(ddlAcademic.SelectedItem.Value);
        }
        if (ddlClass.SelectedIndex != 0)
        {
            objRegistrationMaster.ClassObject = new ClassMaster();
            objRegistrationMaster.ClassObject.ClassId = Convert.ToInt32(ddlClass.SelectedItem.Value);
        }
        if (ddlStream.SelectedIndex != 0)
        {
            objRegistrationMaster.StreamObject = new StreamMaster();
            objRegistrationMaster.StreamObject.StreamId = Convert.ToInt32(ddlStream.SelectedItem.Value);
        }
        objRegistrationMaster.StartDate = GeneralUtility.DDMMYY_MMDDYY(txtStartDate.Text);
        objRegistrationMaster.EndDate = GeneralUtility.DDMMYY_MMDDYY(txtEndDate.Text);

        objRegistrationMaster.TotalSeat = Convert.ToInt32(txtTotalSeat.Text);
        objRegistrationMaster.ManagementSeat = Convert.ToInt32(txtManagementSeat.Text);
        objRegistrationMaster.RegistrationFee = Convert.ToDecimal(txtRegistrationFee.Text);
        objRegistrationMaster.IsPartialFeeAllowed = Convert.ToBoolean(ddlIsPartialFeeAllowed.SelectedItem.Value);

        objRegistrationMaster.Instruction = txtInstruction.Text;
        objRegistrationMaster.Disclaimer = txtDisclaimer.Text;

        objRegistrationMaster.ReservationDetailData = uxReservationDetailUC.GetReservationDetailForDataTable();
        objRegistrationMaster.RegistrationEligibilityData = uxRegistrationEligibilityUC.GetRegistrationEligibilityForDataTable();
        objRegistrationMaster.ModifiedBy = LoggedInUser;
        objRegistrationMaster.ModifiedOn = GeneralUtility.CurrentDateTime;
        objRegistrationMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);

        //TODO:Temporary
        objRegistrationMaster.RegistrationStatusObject = new MetadataMaster();
        objRegistrationMaster.RegistrationStatusObject.MetadataId = Convert.ToInt32(RegistrationStatus.Created);//Convert.ToInt32(ddlRegistrationStatus.SelectedItem.Value);

        return objRegistrationMaster;
    }
    private RegistrationMaster GetObjectForActivateDeactivate(int editIndex, RecordStatus objStatus)
    {
        objRegistrationMaster = new RegistrationMaster();
        objRegistrationMaster.RegistrationId = Convert.ToInt32(grdRegistrationMaster.DataKeys[editIndex].Values[REGISTRATION_ID_INDEX].ToString());
        objRegistrationMaster.Version = Convert.ToInt16(grdRegistrationMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString()) + 1;
        objRegistrationMaster.ModifiedBy = LoggedInUser;
        objRegistrationMaster.RecordStatus = Convert.ToInt16(objStatus);
        return objRegistrationMaster;
    }
    private RegistrationMaster SelectRecordById(int editIndex)
    {
        objRegistrationMasterBL = new RegistrationMasterBL();
        objRegistrationMaster = new RegistrationMaster();
        objRegistrationMaster.RegistrationId = Convert.ToInt32(grdRegistrationMaster.DataKeys[editIndex].Values[REGISTRATION_ID_INDEX].ToString());
        objRegistrationMaster.Version = Convert.ToInt16(grdRegistrationMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString());
        objRegistrationMaster = objRegistrationMasterBL.SelectRecordById(objRegistrationMaster);
        return objRegistrationMaster;
    }
    private void InitializeControls()
    {
        txtRegistrationName.Text = string.Empty;
        txtStartDate.Text = string.Empty;
        txtEndDate.Text = string.Empty;
        txtTotalSeat.Text = string.Empty;
        //txtFreeSeat.Text = string.Empty;
        txtManagementSeat.Text = string.Empty;
        txtRegistrationFee.Text = string.Empty;
        //txtEligibility.Text = string.Empty;
        txtInstruction.Text = string.Empty;
        txtDisclaimer.Text = string.Empty;

        ddlClass.SelectedIndex = 0;
        ddlBranch.SelectedIndex = 0;
        ddlAcademic.SelectedIndex = 0;
        ddlIsPartialFeeAllowed.SelectedIndex = 0;
        //ddlIsReservationAllowed.SelectedIndex = 0;
    }
    #endregion

}
