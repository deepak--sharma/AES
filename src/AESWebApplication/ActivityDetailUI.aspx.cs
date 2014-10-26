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

public partial class ActivityDetailUI : BasePage
{
    #region Page Variables
    ActivityDetail objActivityDetail = null;
    ActivityDetailBL objActivityDetailBL = null;
    ActivityMaster objActivityMaster = null;
    ActivityMasterBL objActivityMasterBL = null;
    AcademicSessionMaster objAcademicSessionMaster = null;
    AcademicSessionMasterBL objAcademicSessionMasterBL = null;
    BranchMaster objBranchMaster = null;
    BranchMasterBL objBranchMasterBL = null;
    ClassMaster objClassMaster = null;
    ClassMasterBL objClassMasterBL = null;
    SubjectMaster objSubjectMaster = null;
    SubjectMasterBL objSubjectMasterBL = null;
    SectionMaster objSectionMaster = null;
    SectionMasterBL objSectionMasterBL = null;
    StreamMaster objStreamMaster = null;
    StreamMasterBL objStreamMasterBL = null;
    EmployeeDetail objEmployeeDetail = null;
    EmployeeDetailBL objEmployeeDetailBL = null;

    private const int SELECT_COLUMN = 0;
    private const int ACTIVATE_COLUMN = 1;
    private const int DELETE_COLUMN = 2;

    private const int ACTIVITY_DETAIL_ID_INDEX = 0;
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
            objActivityDetail = BindActivityDetailGrid(RecordStatus.Active);
            if (objActivityDetail.DbOperationStatus != CommonConstant.SUCCEED)
            {
                btnAddNewRecord.Enabled = false;
                UIUtility.DisplayMessage(lblMessage, objActivityDetail.DbOperationStatus);
                return;
            }

            ViewState[isControlsLoaded] = false;

            if (grdActivityDetail.Rows.Count == 0)
            {
                BindActivityDetailControls();
                MultiViewActivityDetail.ActiveViewIndex = 1;
            }
        }
        else
        {
            if (rdbActiveRecord.Checked)
            {
                objActivityDetail = BindActivityDetailGrid(RecordStatus.Active);
                if (objActivityDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    UIUtility.DisplayMessage(lblMessage, objActivityDetail.DbOperationStatus);
                    return;
                }
                ViewActivateColumn(false);
            }
            else
            {
                objActivityDetail = BindActivityDetailGrid(RecordStatus.InActive);
                if (objActivityDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    UIUtility.DisplayMessage(lblMessage, objActivityDetail.DbOperationStatus);
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
            grdActivityDetail.Columns[SELECT_COLUMN].Visible = false;
            grdActivityDetail.Columns[ACTIVATE_COLUMN].Visible = true;
            grdActivityDetail.Columns[DELETE_COLUMN].Visible = false;
        }
        else
        {
            grdActivityDetail.Columns[SELECT_COLUMN].Visible = true;
            grdActivityDetail.Columns[ACTIVATE_COLUMN].Visible = false;
            grdActivityDetail.Columns[DELETE_COLUMN].Visible = true;
        }
    }
    #endregion

    #region Grid Events and Functions
    protected void grdActivityDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            objActivityDetail = SelectRecordById(grdActivityDetail.SelectedIndex);
            if (!objActivityDetail.DbOperationStatus.Equals(CommonConstant.FAIL))
            {
                if (!Convert.ToBoolean(objActivityDetail.IsRecordChanged))
                {
                    ActivateControlsView(false, objActivityDetail, grdActivityDetail.SelectedIndex);
                }
                else
                {
                    UIUtility.DisplayMessage(lblMessage, objActivityDetail.DbOperationStatus);
                    InitializeForm();
                }
            }
            else
            {
                UIUtility.DisplayMessage(lblMessage, objActivityDetail.DbOperationStatus);
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void grdActivityDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            objActivityDetailBL = new ActivityDetailBL();
            objActivityDetail = GetObjectForActivateDeactivate(e.RowIndex, RecordStatus.InActive);
            objActivityDetail = objActivityDetailBL.ActivateDeactivateActivityDetail(objActivityDetail);
            UIUtility.DisplayMessage(lblMessage, objActivityDetail.DbOperationStatus);
            InitializeForm();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void grdActivityDetail_ActivatingObject(object sender, GridViewEditEventArgs e)
    {
        try
        {
            objActivityDetailBL = new ActivityDetailBL();
            objActivityDetail = GetObjectForActivateDeactivate(e.NewEditIndex, RecordStatus.Active);
            objActivityDetail = objActivityDetailBL.ActivateDeactivateActivityDetail(objActivityDetail);
            UIUtility.DisplayMessage(lblMessage, objActivityDetail.DbOperationStatus);
            InitializeForm();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void grdActivityDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grdActivityDetail.PageIndex = e.NewPageIndex;
            InitializeForm();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected ActivityDetail BindActivityDetailGrid(RecordStatus objRecordStatus)
    {
        objActivityDetailBL = new ActivityDetailBL();
        objActivityDetail = new ActivityDetail();
        objActivityDetail.RecordStatus = Convert.ToInt16(objRecordStatus);

        objActivityDetail = objActivityDetailBL.SelectActivityDetail(objActivityDetail);
        if (objActivityDetail.DbOperationStatus == CommonConstant.SUCCEED)
        {
            grdActivityDetail.DataSource = objActivityDetail.ObjectDataSet.Tables[0];
            grdActivityDetail.DataBind();
        }
        return objActivityDetail;
    }
    #endregion

    #region Controls Events and Functions
    protected void btnAddNewRecord_Click(object sender, EventArgs e)
    {
        try
        {
            ActivateControlsView(true, null, null);
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void btnGo_Click(object sender, EventArgs e)
    {
        try
        {
            StudentDetail objStudentDetail = new StudentDetail();
            objStudentDetail.StudentRegistrationObject = new StudentRegistrationDetail();
            objStudentDetail.StudentRegistrationObject.RegistrationObject = new RegistrationMaster();
            objStudentDetail.StudentRegistrationObject.RegistrationObject.BranchObject = new BranchMaster();
            objStudentDetail.StudentRegistrationObject.RegistrationObject.ClassObject = new ClassMaster();
            objStudentDetail.StudentRegistrationObject.RegistrationObject.AcademicSessionObject = new AcademicSessionMaster();
            objStudentDetail.SectionObject = new SectionMaster();
            objStudentDetail.StreamObject = new StreamMaster();

            if (ddlSession.SelectedIndex > 0)
            {
                objStudentDetail.StudentRegistrationObject.RegistrationObject.AcademicSessionObject.SessionId = Convert.ToInt32(ddlSession.SelectedValue);
            }
            else
            {
                throw new Exception("Please select session");
            }
            if (ddlBranch.SelectedIndex > 0)
            {
                objStudentDetail.StudentRegistrationObject.RegistrationObject.BranchObject.BranchId = Convert.ToInt32(ddlBranch.SelectedValue);
            }
            else
            {
                throw new Exception("Please select branch");
            }
            if (ddlClass.SelectedIndex > 0)
            {
                objStudentDetail.StudentRegistrationObject.RegistrationObject.ClassObject.ClassId = Convert.ToInt32(ddlClass.SelectedValue);
            }
            else
            {
                throw new Exception("Please select class");
            }
            if (ddlSection.SelectedIndex > 0)
            {
                objStudentDetail.SectionObject.SectionId = Convert.ToInt32(ddlSection.SelectedValue);
            }
            if (ddlStream.SelectedIndex > 0)
            {
                objStudentDetail.StreamObject.StreamId = Convert.ToInt32(ddlStream.SelectedValue);
            }
            objStudentDetail.RecordStatus = Convert.ToInt32(RecordStatus.Active);
            objStudentDetail.DataHolder = Convert.ToInt32(MetadataTypeEnum.AttendanceStatus).ToString();
            uxStudentAttendanceUC.InitializeUserControl(objStudentDetail, calenderStartDate.Text, calenderEndDate.Text);
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidateObject())
            {
                objActivityDetail = GetObjectForInsertUpdate();
                objActivityDetailBL = new ActivityDetailBL();
                if (objActivityDetail.ActivityDetailId == null)
                {
                    objActivityDetail = objActivityDetailBL.InsertActivityDetail(objActivityDetail);
                }
                else
                {
                    objActivityDetail = objActivityDetailBL.UpdateActivityDetail(objActivityDetail);
                }
                if (objActivityDetail.DbOperationStatus == CommonConstant.SUCCEED
                            || objActivityDetail.DbOperationStatus == CommonConstant.INVALID)
                {
                    InitializeForm();
                    MultiViewActivityDetail.ActiveViewIndex = 0;
                }
                UIUtility.DisplayMessage(lblMessage, objActivityDetail.DbOperationStatus);
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void btnCancelRollback_Click(object sender, EventArgs e)
    {
        try
        {
            MultiViewActivityDetail.ActiveViewIndex = 0;
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
    protected void BindActivityDetailControls()
    {
        if (!Convert.ToBoolean(ViewState[isControlsLoaded]))
        {
            objAcademicSessionMasterBL = new AcademicSessionMasterBL();
            objAcademicSessionMaster = new AcademicSessionMaster();
            objAcademicSessionMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
            objAcademicSessionMaster = objAcademicSessionMasterBL.SelectAcademicSessionMaster(objAcademicSessionMaster);
            ddlSession.DataSource = objAcademicSessionMaster.ObjectDataSet.Tables[0];
            ddlSession.DataBind();
            ddlSession.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

            objStreamMasterBL = new StreamMasterBL();
            objStreamMaster = new StreamMaster();
            objStreamMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
            objStreamMaster = objStreamMasterBL.SelectStreamMaster(objStreamMaster);
            ddlStream.DataSource = objStreamMaster.ObjectDataSet.Tables[0];
            ddlStream.DataBind();
            ddlStream.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

            objActivityMasterBL = new ActivityMasterBL();
            objActivityMaster = new ActivityMaster();
            objActivityMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
            objActivityMaster = objActivityMasterBL.SelectActivityMaster(objActivityMaster);
            ddlActivityDetail.DataSource = objActivityMaster.ObjectDataSet.Tables[0];
            ddlActivityDetail.DataBind();
            ddlActivityDetail.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

            objEmployeeDetailBL = new EmployeeDetailBL();
            objEmployeeDetail = new EmployeeDetail();
            objEmployeeDetail.RecordStatus = Convert.ToInt16(RecordStatus.Active);
            objEmployeeDetail = objEmployeeDetailBL.SelectEmployeeDetail(objEmployeeDetail);
            ddlActivityOwner.DataSource = objEmployeeDetail.ObjectDataSet.Tables[0];
            ddlActivityOwner.DataBind();
            ddlActivityOwner.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

            objBranchMasterBL = new BranchMasterBL();
            objBranchMaster = new BranchMaster();
            objBranchMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
            objBranchMaster = objBranchMasterBL.SelectBranchMaster(objBranchMaster);
            ddlBranch.DataSource = objBranchMaster.ObjectDataSet.Tables[0];
            ddlBranch.DataBind();
            ddlBranch.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

            objClassMasterBL = new ClassMasterBL();
            objClassMaster = new ClassMaster();
            objClassMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
            objClassMaster = objClassMasterBL.SelectClassMaster(objClassMaster);
            ddlClass.DataSource = objClassMaster.ObjectDataSet.Tables[0];
            ddlClass.DataBind();
            ddlClass.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

            objSubjectMasterBL = new SubjectMasterBL();
            objSubjectMaster = new SubjectMaster();
            objSubjectMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
            objSubjectMaster = objSubjectMasterBL.SelectSubjectMaster(objSubjectMaster);
            ddlSubject.DataSource = objSubjectMaster.ObjectDataSet.Tables[0];
            ddlSubject.DataBind();
            ddlSubject.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

            objSectionMasterBL = new SectionMasterBL();
            objSectionMaster = new SectionMaster();
            objSectionMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
            objSectionMaster = objSectionMasterBL.SelectSectionMaster(objSectionMaster);
            ddlSection.DataSource = objSectionMaster.ObjectDataSet.Tables[0];
            ddlSection.DataBind();
            ddlSection.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

            ViewState[isControlsLoaded] = true;
        }

    }
    protected void ActivateControlsView(bool isNewRecord, ActivityDetail objActivityDetail, int? editIndex)
    {
        if (isNewRecord)
        {
            ViewState[editIndexKey] = null;
            BindActivityDetailControls();
            UIUtility.InitializeControls(ViewActivityDetailControls);
            btnGo.Visible = true;
            objActivityDetail = new ActivityDetail() { ActivityDetailId = UIUtility.DEFAULT_ID };
            uxStudentAttendanceUC.SetUserControlData(objActivityDetail);
        }
        else
        {
            ViewState[editIndexKey] = editIndex;
            BindActivityDetailControls();
            PopulateControlsData(objActivityDetail);
            btnGo.Visible = false;
        }
        MultiViewActivityDetail.ActiveViewIndex = 1;
    }
    private void PopulateControlsData(ActivityDetail objActivityDetail)
    {
        UIUtility.SelectCurrentListItem(ddlActivityDetail, objActivityDetail.ActivityObject.ActivityId, BindListItem.ByValue, true);
        UIUtility.SelectCurrentListItem(ddlSession, objActivityDetail.SessionObject.SessionId, BindListItem.ByValue, true);
        UIUtility.SelectCurrentListItem(ddlBranch, objActivityDetail.BranchObject.BranchId, BindListItem.ByValue, true);
        UIUtility.SelectCurrentListItem(ddlClass, objActivityDetail.ClassObject.ClassId, BindListItem.ByValue, true);
        UIUtility.SelectCurrentListItem(ddlSubject, objActivityDetail.SubjectObject.SubjectId, BindListItem.ByValue, true);
        UIUtility.SelectCurrentListItem(ddlSection, objActivityDetail.SectionObject.SectionId, BindListItem.ByValue, true);
        UIUtility.SelectCurrentListItem(ddlStream, objActivityDetail.StreamObject.StreamId, BindListItem.ByValue, true);
        calenderStartDate.Text = GeneralUtility.ToStandardDate(objActivityDetail.StartDate);
        calenderEndDate.Text = GeneralUtility.ToStandardDate(objActivityDetail.EndDate);
        UIUtility.SelectCurrentListItem(ddlActivityOwner, objActivityDetail.ActivityOwnerObject.EmployeeId, BindListItem.ByValue, true);
        txtDescription.Text = objActivityDetail.Description;
        uxStudentAttendanceUC.SetUserControlData(objActivityDetail);
    }
    #endregion

    #region Helper Functions
    private bool ValidateObject()
    {
        return true;
    }
    private ActivityDetail GetObjectForInsertUpdate()
    {
        objActivityDetail = new ActivityDetail();

        if (ViewState[editIndexKey] == null)
        {
            objActivityDetail.Version = BusinessUtility.RECORD_VERSION;
            objActivityDetail.CreatedBy = LoggedInUser;
            objActivityDetail.CreatedOn = GeneralUtility.CurrentDateTime;
        }
        else
        {
            objActivityDetail.ActivityDetailId = Convert.ToInt32(grdActivityDetail.DataKeys[Convert.ToInt32(ViewState[editIndexKey])].Values[ACTIVITY_DETAIL_ID_INDEX].ToString());
            objActivityDetail.Version = Convert.ToInt16(grdActivityDetail.DataKeys[Convert.ToInt16(ViewState[editIndexKey])].Values[VERSION_INDEX].ToString()) + 1;
        }


        if (ddlActivityDetail.SelectedIndex != 0)
        {
            objActivityDetail.ActivityObject = new ActivityMaster();
            objActivityDetail.ActivityObject.ActivityId = Convert.ToInt32(ddlActivityDetail.SelectedItem.Value);
        }
        if (ddlActivityOwner.SelectedIndex != 0)
        {
            objActivityDetail.ActivityOwnerObject = new EmployeeDetail();
            objActivityDetail.ActivityOwnerObject.EmployeeId = Convert.ToInt32(ddlActivityOwner.SelectedItem.Value);
        }
        if (ddlSession.SelectedIndex != 0)
        {
            objActivityDetail.SessionObject = new AcademicSessionMaster();
            objActivityDetail.SessionObject.SessionId = Convert.ToInt32(ddlSession.SelectedItem.Value);
        }
        if (ddlBranch.SelectedIndex != 0)
        {
            objActivityDetail.BranchObject = new BranchMaster();
            objActivityDetail.BranchObject.BranchId = Convert.ToInt32(ddlBranch.SelectedItem.Value);
        }
        if (ddlClass.SelectedIndex != 0)
        {
            objActivityDetail.ClassObject = new ClassMaster();
            objActivityDetail.ClassObject.ClassId = Convert.ToInt32(ddlClass.SelectedItem.Value);
        }
        if (ddlSubject.SelectedIndex != 0)
        {
            objActivityDetail.SubjectObject = new SubjectMaster();
            objActivityDetail.SubjectObject.SubjectId = Convert.ToInt32(ddlSubject.SelectedItem.Value);
        }
        if (ddlSection.SelectedIndex != 0)
        {
            objActivityDetail.SectionObject = new SectionMaster();
            objActivityDetail.SectionObject.SectionId = Convert.ToInt32(ddlSection.SelectedItem.Value);
        }
        if (ddlStream.SelectedIndex != 0)
        {
            objActivityDetail.StreamObject = new StreamMaster();
            objActivityDetail.StreamObject.StreamId = Convert.ToInt32(ddlStream.SelectedItem.Value);
        }
        objActivityDetail.StartDate = Convert.ToDateTime(calenderStartDate.Text);
        objActivityDetail.EndDate = Convert.ToDateTime(calenderEndDate.Text);

        objActivityDetail.Description = txtDescription.Text;
        if (objActivityDetail.ActivityDetailId == null)
        {
            objActivityDetail.StudentAttendanceData = uxStudentAttendanceUC.GetStudentAttendanceData(UIUtility.DEFAULT_ID);
        }
        else
        {
            objActivityDetail.StudentAttendanceData = uxStudentAttendanceUC.GetStudentAttendanceData(objActivityDetail.ActivityDetailId);
        }
        objActivityDetail.ModifiedBy = LoggedInUser;
        objActivityDetail.ModifiedOn = GeneralUtility.CurrentDateTime;
        objActivityDetail.RecordStatus = Convert.ToInt16(RecordStatus.Active);
        return objActivityDetail;
    }
    private ActivityDetail GetObjectForActivateDeactivate(int editIndex, RecordStatus objStatus)
    {
        objActivityDetail = new ActivityDetail();
        objActivityDetail.ActivityDetailId = Convert.ToInt32(grdActivityDetail.DataKeys[editIndex].Values[ACTIVITY_DETAIL_ID_INDEX].ToString());
        objActivityDetail.Version = Convert.ToInt16(grdActivityDetail.DataKeys[editIndex].Values[VERSION_INDEX].ToString()) + 1;
        objActivityDetail.ModifiedBy = LoggedInUser;
        objActivityDetail.RecordStatus = Convert.ToInt16(objStatus);
        return objActivityDetail;
    }
    private ActivityDetail SelectRecordById(int editIndex)
    {
        objActivityDetailBL = new ActivityDetailBL();
        objActivityDetail = new ActivityDetail();
        objActivityDetail.ActivityDetailId = Convert.ToInt32(grdActivityDetail.DataKeys[editIndex].Values[ACTIVITY_DETAIL_ID_INDEX].ToString());
        objActivityDetail.Version = Convert.ToInt16(grdActivityDetail.DataKeys[editIndex].Values[VERSION_INDEX].ToString());
        objActivityDetail = objActivityDetailBL.SelectRecordById(objActivityDetail);
        return objActivityDetail;
    }
    #endregion
}
