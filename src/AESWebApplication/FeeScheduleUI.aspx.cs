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

public partial class FeeScheduleUI : BasePage
{
    #region Page Variables
    FeeSchedule objFeeSchedule = null;
    FeeScheduleBL objFeeScheduleBL = null;
    MetadataMaster objMetadataMaster = null;
    MetadataMasterBL objMetadataMasterBL = null;
    BranchMaster objBranchMaster = null;
    BranchMasterBL objBranchMasterBL = null;
    ClassMaster objClassMaster = null;
    ClassMasterBL objClassMasterBL = null;
    StreamMaster objStreamMaster = null;
    StreamMasterBL objStreamMasterBL = null;
    FeeStructure objFeeStructure = null;
    FeeStructureBL objFeeStructureBL = null;

    private const int SELECT_COLUMN = 0;
    private const int ACTIVATE_COLUMN = 1;
    private const int DELETE_COLUMN = 2;

    private const int FEE_SCHEDULE_ID_INDEX = 0;
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
            objFeeSchedule = BindFeeScheduleGrid(RecordStatus.Active);
            if (objFeeSchedule.DbOperationStatus != CommonConstant.SUCCEED)
            {
                UIUtility.DisplayMessage(lblMessage, objFeeSchedule.DbOperationStatus);
                return;
            }

            ViewState[isControlsLoaded] = false;

            if (grdFeeSchedule.Rows.Count == 0)
            {
                BindFeeScheduleControls();
                MultiViewFeeSchedule.ActiveViewIndex = 1;
            }
        }
        else
        {
            objFeeSchedule = BindFeeScheduleGrid(RecordStatus.Active);
            if (objFeeSchedule.DbOperationStatus != CommonConstant.SUCCEED)
            {
                UIUtility.DisplayMessage(lblMessage, objFeeSchedule.DbOperationStatus);
                return;
            }
        }

    }
    private void ViewActivateColumn(bool view)
    {
        if (view)
        {
            grdFeeSchedule.Columns[SELECT_COLUMN].Visible = false;
            grdFeeSchedule.Columns[ACTIVATE_COLUMN].Visible = true;
            grdFeeSchedule.Columns[DELETE_COLUMN].Visible = false;
        }
        else
        {
            grdFeeSchedule.Columns[SELECT_COLUMN].Visible = true;
            grdFeeSchedule.Columns[ACTIVATE_COLUMN].Visible = false;
            grdFeeSchedule.Columns[DELETE_COLUMN].Visible = true;
        }
    }
    #endregion

    #region Grid Events and Functions
    protected void grdFeeSchedule_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Label lblStatus = grdFeeSchedule.Rows[grdFeeSchedule.SelectedIndex].FindControl("lblStatus") as Label;
            if (!lblStatus.Text.Equals("Setup"))
            {
                objFeeSchedule = new FeeSchedule();
                objFeeSchedule.FeeProcessModeObject = new MetadataMaster();
                objFeeSchedule.BranchObject = new BranchMaster();
                objFeeSchedule.ClassObject = new ClassMaster();
                objFeeSchedule.StreamObject = new StreamMaster();
                objFeeSchedule.BranchObject.BranchId =
                    Convert.ToInt32(grdFeeSchedule.DataKeys[grdFeeSchedule.SelectedIndex].Values[BRANCH_ID_INDEX].ToString());
                objFeeSchedule.ClassObject.ClassId =
                   Convert.ToInt32(grdFeeSchedule.DataKeys[grdFeeSchedule.SelectedIndex].Values[CLASS_ID_INDEX].ToString());
                objFeeSchedule.StreamObject.StreamId =
                   Convert.ToInt32(grdFeeSchedule.DataKeys[grdFeeSchedule.SelectedIndex].Values[STREAM_ID_INDEX].ToString());

                ActivateControlsView(true, objFeeSchedule, null);
            }
            else
            {
                objFeeSchedule = SelectRecordById(grdFeeSchedule.SelectedIndex);
                if (!objFeeSchedule.DbOperationStatus.Equals(CommonConstant.FAIL))
                {
                    if (!Convert.ToBoolean(objFeeSchedule.IsRecordChanged))
                    {
                        ActivateControlsView(false, objFeeSchedule, grdFeeSchedule.SelectedIndex);
                    }
                    else
                    {
                        UIUtility.DisplayMessage(lblMessage, objFeeSchedule.DbOperationStatus);
                        InitializeForm();
                    }
                }
                else
                {
                    UIUtility.DisplayMessage(lblMessage, objFeeSchedule.DbOperationStatus);
                }
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void grdFeeSchedule_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            objFeeScheduleBL = new FeeScheduleBL();
            objFeeSchedule = GetObjectForActivateDeactivate(e.RowIndex, RecordStatus.InActive);
            objFeeSchedule = objFeeScheduleBL.ActivateDeactivateFeeSchedule(objFeeSchedule);
            UIUtility.DisplayMessage(lblMessage, objFeeSchedule.DbOperationStatus);
            InitializeForm();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void grdFeeSchedule_ActivatingObject(object sender, GridViewEditEventArgs e)
    {
        try
        {
            objFeeScheduleBL = new FeeScheduleBL();
            objFeeSchedule = GetObjectForActivateDeactivate(e.NewEditIndex, RecordStatus.Active);
            objFeeSchedule = objFeeScheduleBL.ActivateDeactivateFeeSchedule(objFeeSchedule);
            UIUtility.DisplayMessage(lblMessage, objFeeSchedule.DbOperationStatus);
            InitializeForm();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void grdFeeSchedule_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grdFeeSchedule.PageIndex = e.NewPageIndex;
            InitializeForm();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void grdFeeSchedule_RowDataBound(object sender, GridViewRowEventArgs e)
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
    protected FeeSchedule BindFeeScheduleGrid(RecordStatus objRecordStatus)
    {
        objFeeScheduleBL = new FeeScheduleBL();
        objFeeSchedule = new FeeSchedule();
        objFeeSchedule.RecordStatus = Convert.ToInt16(objRecordStatus);

        objFeeSchedule = objFeeScheduleBL.SelectFeeSchedule(objFeeSchedule);
        if (objFeeSchedule.DbOperationStatus == CommonConstant.SUCCEED)
        {
            grdFeeSchedule.DataSource = objFeeSchedule.ObjectDataSet.Tables[0];
            grdFeeSchedule.DataBind();
        }
        return objFeeSchedule;
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
                objFeeSchedule = GetObjectForInsertUpdate();
                objFeeScheduleBL = new FeeScheduleBL();
                if (objFeeSchedule.FeeScheduleId == null)
                {
                    objFeeSchedule = objFeeScheduleBL.InsertFeeSchedule(objFeeSchedule);
                }
                else
                {
                    objFeeSchedule = objFeeScheduleBL.UpdateFeeSchedule(objFeeSchedule);
                }
                if (objFeeSchedule.DbOperationStatus == CommonConstant.SUCCEED
                            || objFeeSchedule.DbOperationStatus == CommonConstant.INVALID)
                {
                    InitializeForm();
                    MultiViewFeeSchedule.ActiveViewIndex = 0;
                }
                UIUtility.DisplayMessage(lblMessage, objFeeSchedule.DbOperationStatus);
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
            MultiViewFeeSchedule.ActiveViewIndex = 0;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void btnGo_Click(object sender, EventArgs e)
    {
        bool isPostPayment = (ddlFeeProcess.SelectedValue.Equals(((int)FeeProcessMode.PostPayment).ToString())) ? true : false;
        uxFeeScheduleDetailUC.InitializeUserControl(null, Convert.ToInt32(txtNoOfInstances.Text), isPostPayment);
        fldFeeScheduleDetail.Visible = true;
    }
    protected void BindFeeScheduleControls()
    {
        if (!Convert.ToBoolean(ViewState[isControlsLoaded]))
        {
            UIController.BindMetadataDDL(ddlFeeProcess, MetadataTypeEnum.FeeProcessMode);

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
    protected void ActivateControlsView(bool isNewRecord, FeeSchedule objFeeSchedule, int? editIndex)
    {
        if (isNewRecord)
        {
            ViewState[editIndexKey] = null;
            BindFeeScheduleControls();
            UIUtility.InitializeControls(ViewFeeScheduleControls);
            PopulateControlsData(objFeeSchedule);
            fldFeeScheduleDetail.Visible = false;
        }
        else
        {
            ViewState[editIndexKey] = editIndex;
            BindFeeScheduleControls();
            PopulateControlsData(objFeeSchedule);
        }
        MultiViewFeeSchedule.ActiveViewIndex = 1;
    }
    private void PopulateControlsData(FeeSchedule objFeeSchedule)
    {
        txtNoOfInstances.Text = objFeeSchedule.NoOfInstances.ToString();
        UIUtility.SelectCurrentListItem(ddlFeeProcess, objFeeSchedule.FeeProcessModeObject.MetadataId, BindListItem.ByValue, true);
        UIUtility.SelectCurrentListItem(ddlBranch, objFeeSchedule.BranchObject.BranchId, BindListItem.ByValue, true);
        UIUtility.SelectCurrentListItem(ddlClass, objFeeSchedule.ClassObject.ClassId, BindListItem.ByValue, true);
        UIUtility.SelectCurrentListItem(ddlStream, objFeeSchedule.StreamObject.StreamId, BindListItem.ByValue, true);
        fldFeeScheduleDetail.Visible = true;
        if (ViewState[editIndexKey] != null)
        {
            int _editIndex = Convert.ToInt32(ViewState[editIndexKey]);
            int _dataKey = Convert.ToInt32(grdFeeSchedule.DataKeys[_editIndex].Values[FEE_SCHEDULE_ID_INDEX].ToString());
            bool isPostPayment = (ddlFeeProcess.SelectedValue.Equals(((int)FeeProcessMode.PostPayment).ToString())) ? true : false;
            uxFeeScheduleDetailUC.InitializeUserControl(_dataKey, Convert.ToInt32(txtNoOfInstances.Text), isPostPayment);
        }
    }
    #endregion

    #region Helper Functions
    private bool ValidateObject()
    {
        return true;
    }
    private FeeSchedule GetObjectForInsertUpdate()
    {
        objFeeSchedule = new FeeSchedule();

        if (ViewState[editIndexKey] == null)
        {
            objFeeSchedule.Version = BusinessUtility.RECORD_VERSION;
            objFeeSchedule.CreatedBy = LoggedInUser;
            objFeeSchedule.CreatedOn = GeneralUtility.CurrentDateTime;
        }
        else
        {
            objFeeSchedule.FeeScheduleId = Convert.ToInt32(grdFeeSchedule.DataKeys[Convert.ToInt32(ViewState[editIndexKey])].Values[FEE_SCHEDULE_ID_INDEX].ToString());
            objFeeSchedule.Version = Convert.ToInt16(grdFeeSchedule.DataKeys[Convert.ToInt16(ViewState[editIndexKey])].Values[VERSION_INDEX].ToString()) + 1;
        }

        objFeeSchedule.NoOfInstances = Convert.ToInt32(txtNoOfInstances.Text);
        if (ddlFeeProcess.SelectedIndex != 0)
        {
            objFeeSchedule.FeeProcessModeObject = new MetadataMaster();
            objFeeSchedule.FeeProcessModeObject.MetadataId = Convert.ToInt32(ddlFeeProcess.SelectedItem.Value);
        }
        if (ddlBranch.SelectedIndex != 0)
        {
            objFeeSchedule.BranchObject = new BranchMaster();
            objFeeSchedule.BranchObject.BranchId = Convert.ToInt32(ddlBranch.SelectedItem.Value);
        }
        if (ddlClass.SelectedIndex != 0)
        {
            objFeeSchedule.ClassObject = new ClassMaster();
            objFeeSchedule.ClassObject.ClassId = Convert.ToInt32(ddlClass.SelectedItem.Value);
        }
        if (ddlStream.SelectedIndex != 0)
        {
            objFeeSchedule.StreamObject = new StreamMaster();
            objFeeSchedule.StreamObject.StreamId = Convert.ToInt32(ddlStream.SelectedItem.Value);
        }       
        
        objFeeSchedule.FeeScheduleDetailData = uxFeeScheduleDetailUC.GetFeeScheduleDetailData(UIUtility.DEFAULT_ID);

        objFeeSchedule.ModifiedBy = LoggedInUser;
        objFeeSchedule.ModifiedOn = GeneralUtility.CurrentDateTime;
        objFeeSchedule.RecordStatus = Convert.ToInt16(RecordStatus.Active);
        return objFeeSchedule;
    }
    private FeeSchedule GetObjectForActivateDeactivate(int editIndex, RecordStatus objStatus)
    {
        objFeeSchedule = new FeeSchedule();
        objFeeSchedule.FeeScheduleId = Convert.ToInt32(grdFeeSchedule.DataKeys[editIndex].Values[FEE_SCHEDULE_ID_INDEX].ToString());
        objFeeSchedule.Version = Convert.ToInt16(grdFeeSchedule.DataKeys[editIndex].Values[VERSION_INDEX].ToString()) + 1;
        objFeeSchedule.ModifiedBy = LoggedInUser;
        objFeeSchedule.RecordStatus = Convert.ToInt16(objStatus);
        return objFeeSchedule;
    }
    private FeeSchedule SelectRecordById(int editIndex)
    {
        objFeeScheduleBL = new FeeScheduleBL();
        objFeeSchedule = new FeeSchedule();
        objFeeSchedule.FeeScheduleId = Convert.ToInt32(grdFeeSchedule.DataKeys[editIndex].Values[FEE_SCHEDULE_ID_INDEX].ToString());
        objFeeSchedule.Version = Convert.ToInt16(grdFeeSchedule.DataKeys[editIndex].Values[VERSION_INDEX].ToString());
        objFeeSchedule = objFeeScheduleBL.SelectRecordById(objFeeSchedule);
        return objFeeSchedule;
    }
    #endregion
}
