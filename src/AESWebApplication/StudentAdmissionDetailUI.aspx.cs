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

public partial class StudentAdmissionDetailUI : BasePage
{
    #region Page Variables
    ClassMaster objClassMaster = null;
    ClassMasterBL objClassMasterBL = null;
    BranchMaster objBranchMaster = null;
    BranchMasterBL objBranchMasterBL = null;
    StudentDetail objStudentDetail = null;
    StudentDetailBL objStudentDetailBL = null;
    StudentRegistrationDetailBL objStudentRegistrationDetailBL = null;
    StudentRegistrationDetail objStudentRegistrationDetail = null;

    private string isControlsLoaded = "ControlsLoaded";
    private string editIndexKey = "EditIndexKey";
    private string qRegId = "RegId";

    private int registrationId
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

    #endregion

    #region Page Events and Functions
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString.HasKeys())
                {
                    registrationId = Convert.ToInt32(Convert.ToString(Request.QueryString[qRegId]));

                    string script = string.Format("javascript:return OpenPopUp('StudentRegistrationEditViewUI.aspx?RegId={0}');",
                                                   registrationId);
                    lnkViewDetail.Attributes.Add("onclick", script);
                }
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
            ViewState[editIndexKey] = null;
            BindStudentDetailControls();
            objStudentRegistrationDetail = GetStudentRegistrationDetail();

            if (!objStudentRegistrationDetail.DbOperationStatus.Equals(CommonConstant.FAIL))
            {
                PopulateControlsData();
            }
            else
            {
                UIUtility.DisplayMessage(lblMessage, objStudentDetail.DbOperationStatus);
            }

        }
        else
        {
            //Show enrollment number and proper messege

        }

    }

    #endregion

    #region Controls Events and Functions
    protected void btnOk_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/HomePage.aspx");
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidateObject())
            {
                objStudentDetail = GetObjectForInsertUpdate();
                objStudentDetailBL = new StudentDetailBL();
                if (objStudentDetail.StudentId == null)
                {
                    objStudentDetail = objStudentDetailBL.InsertStudentDetail(objStudentDetail);
                }
                else
                {
                    objStudentDetail = objStudentDetailBL.UpdateStudentDetail(objStudentDetail);
                }
                if (objStudentDetail.DbOperationStatus == CommonConstant.SUCCEED
                            || objStudentDetail.DbOperationStatus == CommonConstant.INVALID)
                {
                    InitializeForm();
                    MultiViewStudentDetail.ActiveViewIndex = 0;
                }
                UIUtility.DisplayMessage(lblMessage, objStudentDetail.DbOperationStatus);
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
            MultiViewStudentDetail.ActiveViewIndex = 0;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    #endregion

    #region Helper Functions
    private void BindStudentDetailControls()
    {
        if (!Convert.ToBoolean(ViewState[isControlsLoaded]))
        {
            objClassMasterBL = new ClassMasterBL();
            objClassMaster = new ClassMaster();
            objClassMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
            objClassMaster = objClassMasterBL.SelectClassMaster(objClassMaster);
            ddlClassName.DataSource = objClassMaster.ObjectDataSet.Tables[0];
            ddlClassName.DataBind();
            ddlClassName.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

            objBranchMasterBL = new BranchMasterBL();
            objBranchMaster = new BranchMaster();
            objBranchMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
            objBranchMaster = objBranchMasterBL.SelectBranchMaster(objBranchMaster);
            ddlBranch.DataSource = objBranchMaster.ObjectDataSet.Tables[0];
            ddlBranch.DataBind();
            ddlBranch.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);


            ViewState[isControlsLoaded] = true;
        }
    }
    private void PopulateControlsData()
    {
        if (objStudentRegistrationDetail != null && objStudentRegistrationDetail.ObjectDataSet != null &&
            objStudentRegistrationDetail.ObjectDataSet.Tables.Count > 0)
        {
            DataTable dtStudentRegistrationDetail = objStudentRegistrationDetail.ObjectDataSet.Tables[0];
            if (dtStudentRegistrationDetail.Rows.Count > 0)
            {
                txtRegistrationNumber.Text = Convert.ToString(dtStudentRegistrationDetail.Rows[0]["REGISTRATION_NUMBER"]);
                txtRegistrationDate.Text = GeneralUtility.ToStandardDate(Convert.ToString(dtStudentRegistrationDetail.Rows[0]["REGISTRATION_DATE"]));
                txtComment.Text = Convert.ToString(dtStudentRegistrationDetail.Rows[0]["COMMENT"]);
                UIUtility.SelectCurrentListItem(ddlClassName, Convert.ToString(dtStudentRegistrationDetail.Rows[0]["CLASS_ID"]), BindListItem.ByValue, true);
                UIUtility.SelectCurrentListItem(ddlBranch, Convert.ToString(dtStudentRegistrationDetail.Rows[0]["BRANCH_ID"]), BindListItem.ByValue, true);
                txtCandidateName.Text = Convert.ToString(dtStudentRegistrationDetail.Rows[0]["CANDIDATE_NAME"]);
                txtDOB.Text = GeneralUtility.ToStandardDate(Convert.ToString(dtStudentRegistrationDetail.Rows[0]["DATE_OF_BIRTH"]));
                txtGuardianName.Text = Convert.ToString(dtStudentRegistrationDetail.Rows[0]["GUARDIAN_NAME"]);
                txtAdmissionDate.Text = GeneralUtility.ToStandardDate(DateTime.Now);
            }
        }

    }

    private bool ValidateObject()
    {
        return true;
    }
    private StudentDetail GetObjectForInsertUpdate()
    {
        objStudentDetail = new StudentDetail();

        if (ViewState[editIndexKey] == null)
        {
            objStudentDetail.Version = BusinessUtility.RECORD_VERSION;
            objStudentDetail.CreatedBy = LoggedInUser;
            objStudentDetail.CreatedOn = GeneralUtility.CurrentDateTime;
        }
        objStudentDetail.StudentRegistrationObject = new StudentRegistrationDetail();
        objStudentDetail.StudentRegistrationObject.StudentRegistrationId = registrationId;
        objStudentDetail.AdmissionDate = Convert.ToDateTime(txtAdmissionDate.Text);
        objStudentDetail.ModifiedBy = LoggedInUser;
        objStudentDetail.ModifiedOn = GeneralUtility.CurrentDateTime;
        objStudentDetail.RecordStatus = Convert.ToInt16(RecordStatus.Active);
        return objStudentDetail;
    }
    private StudentRegistrationDetail GetStudentRegistrationDetail()
    {
        objStudentRegistrationDetailBL = new StudentRegistrationDetailBL();
        objStudentRegistrationDetail = new StudentRegistrationDetail();
        objStudentRegistrationDetail.StudentRegistrationId = registrationId;
        objStudentRegistrationDetail = objStudentRegistrationDetailBL.SearchStudentRegistrationDetail(objStudentRegistrationDetail);
        return objStudentRegistrationDetail;
    }
    #endregion

}
