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

public partial class ActivityDetailNewUI : BasePage
{
    #region Page Variables
    AcademicSessionMaster objAcademicSessionMaster = null;
    AcademicSessionMasterBL objAcademicSessionMasterBL = null;
    ActivityDetail objActivityDetail = null;
    ActivityDetailBL objActivityDetailBL = null;
    ActivityMaster objActivityMaster = null;
    ActivityMasterBL objActivityMasterBL = null;
    BranchMaster objBranchMaster = null;
    BranchMasterBL objBranchMasterBL = null;
    ClassMaster objClassMaster = null;
    ClassMasterBL objClassMasterBL = null;
    SubjectMaster objSubjectMaster = null;
    SubjectMasterBL objSubjectMasterBL = null;
    StreamMaster objStreamMaster = null;
    StreamMasterBL objStreamMasterBL = null;
    SectionMaster objSectionMaster = null;
    SectionMasterBL objSectionMasterBL = null;
    private string isControlsLoaded = "ControlsLoaded";
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
            lblMessage.Text = ex.Message;
        }
    }
    private void InitializeForm()
    {
        if (!Page.IsPostBack)
        {
            ViewState[isControlsLoaded] = false;
            BindActivityDetailControls();
        }
    }
    #endregion

    #region Controls Events and Functions
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
            uxStudentAttendanceUC.InitializeUserControl(objStudentDetail, calenderStartDate.Text,calenderEndDate.Text);
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
            ddlActivity.DataSource = objActivityMaster.ObjectDataSet.Tables[0];
            ddlActivity.DataBind();
            ddlActivity.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

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

    #endregion

    #region Helper Functions
    private bool ValidateObject()
    {
        return true;
    }
    private ActivityDetail GetObjectForInsertUpdate()
    {
        objActivityDetail = new ActivityDetail();

        objActivityDetail.Version = BusinessUtility.RECORD_VERSION;
        objActivityDetail.CreatedBy = LoggedInUser;
        objActivityDetail.CreatedOn = GeneralUtility.CurrentDateTime;

        if (ddlActivity.SelectedIndex != 0)
        {
            objActivityDetail.ActivityObject = new ActivityMaster();
            objActivityDetail.ActivityObject.ActivityId = Convert.ToInt32(ddlActivity.SelectedItem.Value);
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
        objActivityDetail.StudentAttendanceData = uxStudentAttendanceUC.GetStudentAttendanceData(UIUtility.DEFAULT_ID);
        objActivityDetail.ModifiedBy = LoggedInUser;
        objActivityDetail.ModifiedOn = GeneralUtility.CurrentDateTime;
        objActivityDetail.RecordStatus = Convert.ToInt16(RecordStatus.Active);
        return objActivityDetail;
    }

    #endregion

}
