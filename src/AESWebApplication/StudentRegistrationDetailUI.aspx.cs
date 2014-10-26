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
using System.Collections.Generic;

public partial class StudentRegistrationDetailUI : BasePage
{
    #region Page Variables
    StudentRegistrationDetail objStudentRegistrationDetail = null;
    StudentRegistrationDetailBL objStudentRegistrationDetailBL = null;

    private const int STUDENT_REGISTRATION_ID_DATA_KEY_INDEX = 0;
    private const int VERSION_DATA_KEY_INDEX = 1;
    private const int REGISTRATION_STATUS_ID_DATA_KEY_INDEX = 2;
    private const int PROCESS_ADMISSION_COLUMN_INDEX = 1;

    private string qModuleKey = "Module";
    #endregion

    public string qModuleValue
    {
        get
        {
            return Convert.ToString(ViewState[qModuleKey]);
        }
        set
        {
            ViewState[qModuleKey] = value;
        }
    }

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
        if (Request.QueryString.HasKeys())
        {
            qModuleValue = Request.QueryString[qModuleKey].ToString();
            if (qModuleValue == "SR")
            {
                dvAdvanceSearch.Visible = true;
                dvSearchByRegistrationNumber.Visible = true;
                grdStudentRegistrationDetail.Columns[2].Visible = false;
            }
            else if (qModuleValue == "SA")
            {
                dvSearchByRegistrationNumber.Visible = true;
                dvAdvanceSearch.Visible = false;
                dvChangeRegistrationStatus.Visible = false;
                btnAddNewRecord.Visible = false;
                grdStudentRegistrationDetail.Columns[0].Visible = false;
                grdStudentRegistrationDetail.Columns[1].Visible = false;
            }
        }

        UIController.BindMetadataDDL(ddlSearchRegistrationStatus, MetadataTypeEnum.RegistrationRequestStatus);
        BindStudentRegistrationDetailGrid(RecordStatus.Active);
        if (grdStudentRegistrationDetail.Rows.Count > 0)
        {
            UIController.BindMetadataDDL(ddlUpdatedRegistrationStatus, MetadataTypeEnum.RegistrationRequestStatus);
            GridPanel.Visible = true;
        }

    }
    #endregion

    #region Grid Events and Functions

    protected void grdStudentRegistrationDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (qModuleValue == "SA")
            {
                HyperLink lnkProcessAdmission = (HyperLink)e.Row.FindControl("lnkProcessAdmission");

                int registrationStatusId;
                int.TryParse(Convert.ToString(grdStudentRegistrationDetail.DataKeys[e.Row.RowIndex].Values[REGISTRATION_STATUS_ID_DATA_KEY_INDEX]), out registrationStatusId);

                if ((RegistrationRequestStatus)registrationStatusId == RegistrationRequestStatus.Accepted)
                {
                    lnkProcessAdmission.Enabled = true;
                }
                else
                {
                    lnkProcessAdmission.Enabled = false;
                }
            }
            //CheckBox chkSelectItem = e.Row.FindControl("chkSelectItem") as CheckBox;
            //chkSelectItem.Attributes.Add("onclick", "return SelectAllCheckboxes(this,'" + grdStudentRegistrationDetail.ClientID + "');");
        }
        //else if (e.Row.RowType == DataControlRowType.Header)
        //{
        //    CheckBox chkSelectAll = e.Row.FindControl("chkSelectAll") as CheckBox;
        //    chkSelectAll.Attributes.Add("onclick", "return SelectAllCheckboxes(this,'" + grdStudentRegistrationDetail.ClientID + "');");
        //}

    }
    protected void grdStudentRegistrationDetail_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow &&
           (e.Row.RowState == DataControlRowState.Normal ||
            e.Row.RowState == DataControlRowState.Alternate))
        {
            CheckBox chkBxSelect = (CheckBox)e.Row.Cells[1].FindControl("chkSelectItem");
            CheckBox chkBxHeader = (CheckBox)this.grdStudentRegistrationDetail.HeaderRow.FindControl("chkSelectAll");
            chkBxSelect.Attributes["onclick"] = string.Format
                                                   (
                                                      "javascript:ChildClick(this,'{0}','{1}');",
                                                      chkBxHeader.ClientID, grdStudentRegistrationDetail.ClientID
                                                   );

            chkBxHeader.Attributes["onclick"] = string.Format
                                                   (
                                                      "javascript:HeaderClick(this,'{0}');",
                                                      grdStudentRegistrationDetail.ClientID
                                                   ); 
        }
    }
    protected void grdStudentRegistrationDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grdStudentRegistrationDetail.PageIndex = e.NewPageIndex;
            BindStudentRegistrationDetailGrid(RecordStatus.Active);
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void BindStudentRegistrationDetailGrid(RecordStatus objRecordStatus)
    {
        objStudentRegistrationDetailBL = new StudentRegistrationDetailBL();
        objStudentRegistrationDetail = GetObjectForStudentRegistrationSearch();
        objStudentRegistrationDetail.RecordStatus = Convert.ToInt32(objRecordStatus);
        objStudentRegistrationDetail = objStudentRegistrationDetailBL.SearchStudentRegistrationDetail(objStudentRegistrationDetail);

        if (objStudentRegistrationDetail.DbOperationStatus == CommonConstant.SUCCEED)
        {
            grdStudentRegistrationDetail.DataSource = objStudentRegistrationDetail.ObjectDataSet.Tables[0];
            grdStudentRegistrationDetail.DataBind();
            if (qModuleValue == "SA")
            {
                grdStudentRegistrationDetail.Columns[1].Visible = true;
            }
            else
            {
                grdStudentRegistrationDetail.Columns[1].Visible = false;
            }
        }
        else
        {
            UIUtility.DisplayMessage(lblMessage, objStudentRegistrationDetail.DbOperationStatus);
        }
    }

    protected string MakeShort(String str)
    {
        if (str.Length > 20)
        {
            str = str.Substring(0, 20) + "...";
        }
        return str;
    }
    #endregion

    #region Controls Events and Functions
    protected void btnAddNewRecord_Click(object sender, EventArgs e)
    {
        Response.Redirect("StudentRegistrationWizardUI.aspx");
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            BindStudentRegistrationDetailGrid(RecordStatus.Active);
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }

    }
    protected void btnChangeRegistrationStatus_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlUpdatedRegistrationStatus.SelectedIndex > 0)
            {
                Dictionary<int, int> dicRegistrationId = new Dictionary<int, int>();
                //Loop through student registration detail grid to find the selected rows for status update
                foreach (GridViewRow row in grdStudentRegistrationDetail.Rows)
                {
                    CheckBox chkSelect = (CheckBox)(row.FindControl("chkSelectItem"));
                    if (chkSelect.Checked)
                    {
                        int registrationId = Convert.ToInt32(grdStudentRegistrationDetail.DataKeys[row.RowIndex].Values[STUDENT_REGISTRATION_ID_DATA_KEY_INDEX]);
                        int version = Convert.ToInt32(grdStudentRegistrationDetail.DataKeys[row.RowIndex].Values[VERSION_DATA_KEY_INDEX]) + 1;
                        dicRegistrationId.Add(registrationId, version);
                    }

                }
                if (dicRegistrationId.Count > 0)
                {
                    objStudentRegistrationDetailBL = new StudentRegistrationDetailBL();
                    //TODO: Add Comment
                    string comment = ddlUpdatedRegistrationStatus.SelectedItem.Text;
                    objStudentRegistrationDetail = objStudentRegistrationDetailBL.EditStudentRegistrationStatus(dicRegistrationId, Convert.ToInt32(ddlUpdatedRegistrationStatus.SelectedValue),
                                                                                                                comment, LoggedInUser, GeneralUtility.CurrentDateTime);
                    BindStudentRegistrationDetailGrid(RecordStatus.Active);
                    UIUtility.DisplayMessage(lblMessage, objStudentRegistrationDetail.DbOperationStatus);
                    if (objStudentRegistrationDetail.DbOperationStatus == CommonConstant.SUCCEED)
                    {
                        ddlUpdatedRegistrationStatus.SelectedIndex = 0;
                    }
                }
                else
                {
                    lblMessage.Text = "Select at least one registration";
                }
            }
            else
            {
                lblMessage.Text = "Select registration status";
            }
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
    private StudentRegistrationDetail GetObjectForStudentRegistrationSearch()
    {
        objStudentRegistrationDetail = new StudentRegistrationDetail();

        if (!string.IsNullOrEmpty(txtRegNumber.Text))
        {
            objStudentRegistrationDetail.RegistrationNumber = txtRegNumber.Text;
        }

        if (ddlSearchRegistrationStatus.SelectedIndex > 0)
        {
            objStudentRegistrationDetail.RegistrationStatusObject = new MetadataMaster();
            objStudentRegistrationDetail.RegistrationStatusObject.MetadataId = Convert.ToInt32(ddlSearchRegistrationStatus.SelectedValue);
        }
        if (!string.IsNullOrEmpty(txtStartDate.Text))
        {
            objStudentRegistrationDetail.StartDate = GeneralUtility.DDMMYY_MMDDYY(txtStartDate.Text);
        }
        if (!string.IsNullOrEmpty(txtStartDate.Text))
        {
            objStudentRegistrationDetail.EndDate = GeneralUtility.DDMMYY_MMDDYY(txtEndDate.Text);
        }
        if (qModuleValue == "SA")
        {
            objStudentRegistrationDetail.RegistrationStatusObject = new MetadataMaster();
            objStudentRegistrationDetail.RegistrationStatusObject.MetadataId = Convert.ToInt32(RegistrationRequestStatus.Accepted);
        }

        return objStudentRegistrationDetail;
    }

    #endregion

}
