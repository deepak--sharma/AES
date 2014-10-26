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

public partial class LateFeeSetupUI : BasePage
{
    #region Page Variables
    LateFeeSetup objLateFeeSetup = null;
    LateFeeSetupBL objLateFeeSetupBL = null;
    BranchMaster objBranchMaster = null;
    BranchMasterBL objBranchMasterBL = null;
    ClassMaster objClassMaster = null;
    ClassMasterBL objClassMasterBL = null;
    StreamMaster objStreamMaster = null;
    StreamMasterBL objStreamMasterBL = null;

    private const int SELECT_COLUMN = 0;
    private const int ACTIVATE_COLUMN = 1;
    private const int DELETE_COLUMN = 2;

    private const int LATE_FEE_ID_INDEX = 0;
    private const int VERSION_INDEX = 1;
    private const int BRANCH_ID_INDEX = 2;
    private const int CLASS_ID_INDEX = 3;
    private const int STREAM_ID_INDEX = 4;
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
            lblMessage.Text = ex.Message;
        }
    }
    private void InitializeForm()
    {
        if (!Page.IsPostBack)
        {
            objLateFeeSetup = BindLateFeeSetupGrid(RecordStatus.Active);
            if (objLateFeeSetup.DbOperationStatus != CommonConstant.SUCCEED)
            {
                UIUtility.DisplayMessage(lblMessage, objLateFeeSetup.DbOperationStatus);
                return;
            }

            ViewState[isControlsLoaded] = false;

            if (grdLateFeeSetup.Rows.Count == 0)
            {
                BindLateFeeSetupControls();
                MultiViewLateFeeSetup.ActiveViewIndex = 1;
            }
        }
        else
        {

            objLateFeeSetup = BindLateFeeSetupGrid(RecordStatus.Active);
            if (objLateFeeSetup.DbOperationStatus != CommonConstant.SUCCEED)
            {
                UIUtility.DisplayMessage(lblMessage, objLateFeeSetup.DbOperationStatus);
                return;
            }
            ViewActivateColumn(false);
        }
    }
    private void ViewActivateColumn(bool view)
    {
        if (view)
        {
            grdLateFeeSetup.Columns[SELECT_COLUMN].Visible = false;
            grdLateFeeSetup.Columns[ACTIVATE_COLUMN].Visible = true;
            grdLateFeeSetup.Columns[DELETE_COLUMN].Visible = false;
        }
        else
        {
            grdLateFeeSetup.Columns[SELECT_COLUMN].Visible = true;
            grdLateFeeSetup.Columns[ACTIVATE_COLUMN].Visible = false;
            grdLateFeeSetup.Columns[DELETE_COLUMN].Visible = true;
        }
    }
    #endregion

    #region Grid Events and Functions
    protected void grdLateFeeSetup_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Label lblStatus = grdLateFeeSetup.Rows[grdLateFeeSetup.SelectedIndex].FindControl("lblStatus") as Label;
            if (!lblStatus.Text.Equals("Setup"))
            {
                objLateFeeSetup = new LateFeeSetup();
                objLateFeeSetup.BranchObject = new BranchMaster();
                objLateFeeSetup.ClassObject = new ClassMaster();
                objLateFeeSetup.StreamObject = new StreamMaster();
                objLateFeeSetup.BranchObject.BranchId =
                    Convert.ToInt32(grdLateFeeSetup.DataKeys[grdLateFeeSetup.SelectedIndex].Values[BRANCH_ID_INDEX].ToString());
                objLateFeeSetup.ClassObject.ClassId =
                   Convert.ToInt32(grdLateFeeSetup.DataKeys[grdLateFeeSetup.SelectedIndex].Values[CLASS_ID_INDEX].ToString());
                objLateFeeSetup.StreamObject.StreamId =
                   Convert.ToInt32(grdLateFeeSetup.DataKeys[grdLateFeeSetup.SelectedIndex].Values[STREAM_ID_INDEX].ToString());

                ActivateControlsView(true, objLateFeeSetup, null);
            }
            else
            {
                objLateFeeSetup = SelectRecordById(grdLateFeeSetup.SelectedIndex);
                if (!objLateFeeSetup.DbOperationStatus.Equals(CommonConstant.FAIL))
                {
                    if (!Convert.ToBoolean(objLateFeeSetup.IsRecordChanged))
                    {
                        ActivateControlsView(false, objLateFeeSetup, grdLateFeeSetup.SelectedIndex);
                    }
                    else
                    {
                        UIUtility.DisplayMessage(lblMessage, objLateFeeSetup.DbOperationStatus);
                        InitializeForm();
                    }
                }
                else
                {
                    UIUtility.DisplayMessage(lblMessage, objLateFeeSetup.DbOperationStatus);
                }
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void grdLateFeeSetup_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            objLateFeeSetupBL = new LateFeeSetupBL();
            objLateFeeSetup = GetObjectForActivateDeactivate(e.RowIndex, RecordStatus.InActive);
            objLateFeeSetup = objLateFeeSetupBL.ActivateDeactivateLateFeeSetup(objLateFeeSetup);
            UIUtility.DisplayMessage(lblMessage, objLateFeeSetup.DbOperationStatus);
            InitializeForm();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void grdLateFeeSetup_ActivatingObject(object sender, GridViewEditEventArgs e)
    {
        try
        {
            objLateFeeSetupBL = new LateFeeSetupBL();
            objLateFeeSetup = GetObjectForActivateDeactivate(e.NewEditIndex, RecordStatus.Active);
            objLateFeeSetup = objLateFeeSetupBL.ActivateDeactivateLateFeeSetup(objLateFeeSetup);
            UIUtility.DisplayMessage(lblMessage, objLateFeeSetup.DbOperationStatus);
            InitializeForm();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void grdLateFeeSetup_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grdLateFeeSetup.PageIndex = e.NewPageIndex;
            InitializeForm();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void grdLateFeeSetup_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblStatus = e.Row.FindControl("lblStatus") as Label;
            if (string.IsNullOrEmpty(((DataRowView)(e.Row.DataItem)).Row.ItemArray[8].ToString()))
            {
                lblStatus.Text = "Not Setup";
            }
            else
            {
                lblStatus.Text = "Setup";
            }
        }
    }
    protected LateFeeSetup BindLateFeeSetupGrid(RecordStatus objRecordStatus)
    {
        objLateFeeSetupBL = new LateFeeSetupBL();
        objLateFeeSetup = new LateFeeSetup();
        objLateFeeSetup.RecordStatus = Convert.ToInt16(objRecordStatus);

        objLateFeeSetup = objLateFeeSetupBL.SelectLateFeeSetup(objLateFeeSetup);
        if (objLateFeeSetup.DbOperationStatus == CommonConstant.SUCCEED)
        {
            grdLateFeeSetup.DataSource = objLateFeeSetup.ObjectDataSet.Tables[0];
            grdLateFeeSetup.DataBind();
        }
        return objLateFeeSetup;
    }
    #endregion

    #region Controls Events and Functions
    protected void btnSave_Click(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidateObject())
            {
                objLateFeeSetup = GetObjectForInsertUpdate();
                objLateFeeSetupBL = new LateFeeSetupBL();
                if (objLateFeeSetup.LateFeeId == null)
                {
                    objLateFeeSetup = objLateFeeSetupBL.InsertLateFeeSetup(objLateFeeSetup);
                }
                else
                {
                    objLateFeeSetup = objLateFeeSetupBL.UpdateLateFeeSetup(objLateFeeSetup);
                }
                if (objLateFeeSetup.DbOperationStatus == CommonConstant.SUCCEED
                            || objLateFeeSetup.DbOperationStatus == CommonConstant.INVALID)
                {
                    InitializeForm();
                    MultiViewLateFeeSetup.ActiveViewIndex = 0;
                }
                UIUtility.DisplayMessage(lblMessage, objLateFeeSetup.DbOperationStatus);
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
            MultiViewLateFeeSetup.ActiveViewIndex = 0;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void BindLateFeeSetupControls()
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
    }
    protected void ActivateControlsView(bool isNewRecord, LateFeeSetup objLateFeeSetup, int? editIndex)
    {
        if (isNewRecord)
        {
            ViewState[editIndexKey] = null;
            BindLateFeeSetupControls();
            UIUtility.InitializeControls(ViewLateFeeSetupControls);
            PopulateControlsData(objLateFeeSetup);
        }
        else
        {
            ViewState[editIndexKey] = editIndex;
            BindLateFeeSetupControls();
            PopulateControlsData(objLateFeeSetup);
        }
        MultiViewLateFeeSetup.ActiveViewIndex = 1;
    }
    private void PopulateControlsData(LateFeeSetup objLateFeeSetup)
    {
        UIUtility.SelectCurrentListItem(ddlBranch, objLateFeeSetup.BranchObject.BranchId, BindListItem.ByValue, true);
        UIUtility.SelectCurrentListItem(ddlClass, objLateFeeSetup.ClassObject.ClassId, BindListItem.ByValue, true);
        UIUtility.SelectCurrentListItem(ddlStream, objLateFeeSetup.StreamObject.StreamId, BindListItem.ByValue, true);

        uxLateFeeSetupDetailUC.InitializeUserControl(objLateFeeSetup.LateFeeId);
    }
    #endregion

    #region Helper Functions
    private bool ValidateObject()
    {
        return true;
    }
    private LateFeeSetup GetObjectForInsertUpdate()
    {
        objLateFeeSetup = new LateFeeSetup();

        if (ViewState[editIndexKey] == null)
        {
            objLateFeeSetup.Version = BusinessUtility.RECORD_VERSION;
            objLateFeeSetup.CreatedBy = LoggedInUser;
            objLateFeeSetup.CreatedOn = GeneralUtility.CurrentDateTime;
        }
        else
        {
            objLateFeeSetup.LateFeeId = Convert.ToInt32(grdLateFeeSetup.DataKeys[Convert.ToInt32(ViewState[editIndexKey])].Values[LATE_FEE_ID_INDEX].ToString());
            objLateFeeSetup.Version = Convert.ToInt16(grdLateFeeSetup.DataKeys[Convert.ToInt16(ViewState[editIndexKey])].Values[VERSION_INDEX].ToString()) + 1;
        }

        if (ddlBranch.SelectedIndex != 0)
        {
            objLateFeeSetup.BranchObject = new BranchMaster();
            objLateFeeSetup.BranchObject.BranchId = Convert.ToInt32(ddlBranch.SelectedItem.Value);
        }
        if (ddlClass.SelectedIndex != 0)
        {
            objLateFeeSetup.ClassObject = new ClassMaster();
            objLateFeeSetup.ClassObject.ClassId = Convert.ToInt32(ddlClass.SelectedItem.Value);
        }
        if (ddlStream.SelectedIndex != 0)
        {
            objLateFeeSetup.StreamObject = new StreamMaster();
            objLateFeeSetup.StreamObject.StreamId = Convert.ToInt32(ddlStream.SelectedItem.Value);
        }
        objLateFeeSetup.LateFeeSetupDetailData = uxLateFeeSetupDetailUC.GetLateFeeDetailData();
        objLateFeeSetup.ModifiedBy = LoggedInUser;
        objLateFeeSetup.ModifiedOn = GeneralUtility.CurrentDateTime;
        objLateFeeSetup.RecordStatus = Convert.ToInt16(RecordStatus.Active);
        return objLateFeeSetup;
    }
    private LateFeeSetup GetObjectForActivateDeactivate(int editIndex, RecordStatus objStatus)
    {
        objLateFeeSetup = new LateFeeSetup();
        objLateFeeSetup.LateFeeId = Convert.ToInt32(grdLateFeeSetup.DataKeys[editIndex].Values[LATE_FEE_ID_INDEX].ToString());
        objLateFeeSetup.Version = Convert.ToInt16(grdLateFeeSetup.DataKeys[editIndex].Values[VERSION_INDEX].ToString()) + 1;
        objLateFeeSetup.ModifiedBy = LoggedInUser;
        objLateFeeSetup.RecordStatus = Convert.ToInt16(objStatus);
        return objLateFeeSetup;
    }
    private LateFeeSetup SelectRecordById(int editIndex)
    {
        objLateFeeSetupBL = new LateFeeSetupBL();
        objLateFeeSetup = new LateFeeSetup();
        objLateFeeSetup.LateFeeId = Convert.ToInt32(grdLateFeeSetup.DataKeys[editIndex].Values[LATE_FEE_ID_INDEX].ToString());
        objLateFeeSetup.Version = Convert.ToInt16(grdLateFeeSetup.DataKeys[editIndex].Values[VERSION_INDEX].ToString());
        objLateFeeSetup = objLateFeeSetupBL.SelectRecordById(objLateFeeSetup);
        return objLateFeeSetup;
    }
    #endregion
}
