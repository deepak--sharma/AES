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

public partial class FeeStructureDetailUI : BasePage
{
    #region Page Variables
    FeeStructureDetail objFeeStructureDetail = null;
    FeeStructureDetailBL objFeeStructureDetailBL = null;
    BranchMaster objBranchMaster = null;
    BranchMasterBL objBranchMasterBL = null;
    ClassMaster objClassMaster = null;
    ClassMasterBL objClassMasterBL = null;
    StreamMaster objStreamMaster = null;
    StreamMasterBL objStreamMasterBL = null;

    private const int SELECT_COLUMN = 0;
    private const int ACTIVATE_COLUMN = 1;
    private const int DELETE_COLUMN = 2;

    private const int FEE_STRUCTURE_DETAIL_ID_INDEX = 0;
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
            objFeeStructureDetail = BindFeeStructureDetailGrid(RecordStatus.Active);
            if (objFeeStructureDetail.DbOperationStatus != CommonConstant.SUCCEED)
            {
                UIUtility.DisplayMessage(lblMessage, objFeeStructureDetail.DbOperationStatus);
                return;
            }

            ViewState[isControlsLoaded] = false;

            if (grdFeeStructureDetail.Rows.Count == 0)
            {
                BindFeeStructureDetailControls();
                MultiViewFeeStructureDetail.ActiveViewIndex = 1;
            }
        }
        else
        {
            objFeeStructureDetail = BindFeeStructureDetailGrid(RecordStatus.Active);
            if (objFeeStructureDetail.DbOperationStatus != CommonConstant.SUCCEED)
            {
                UIUtility.DisplayMessage(lblMessage, objFeeStructureDetail.DbOperationStatus);
                return;
            }
            ViewActivateColumn(false);
        }
    }
    private void ViewActivateColumn(bool view)
    {
        if (view)
        {
            grdFeeStructureDetail.Columns[SELECT_COLUMN].Visible = false;
            grdFeeStructureDetail.Columns[ACTIVATE_COLUMN].Visible = true;
            grdFeeStructureDetail.Columns[DELETE_COLUMN].Visible = false;
        }
        else
        {
            grdFeeStructureDetail.Columns[SELECT_COLUMN].Visible = true;
            grdFeeStructureDetail.Columns[ACTIVATE_COLUMN].Visible = false;
            grdFeeStructureDetail.Columns[DELETE_COLUMN].Visible = true;
        }
    }
    #endregion

    #region Grid Events and Functions
    protected void grdFeeStructureDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Label lblStatus = grdFeeStructureDetail.Rows[grdFeeStructureDetail.SelectedIndex].FindControl("lblStatus") as Label;
            if (!lblStatus.Text.Equals("Setup"))
            {
                objFeeStructureDetail = new FeeStructureDetail();
                objFeeStructureDetail.BranchObject = new BranchMaster();
                objFeeStructureDetail.ClassObject = new ClassMaster();
                objFeeStructureDetail.StreamObject = new StreamMaster();
                objFeeStructureDetail.BranchObject.BranchId =
                    Convert.ToInt32(grdFeeStructureDetail.DataKeys[grdFeeStructureDetail.SelectedIndex].Values[BRANCH_ID_INDEX].ToString());
                objFeeStructureDetail.ClassObject.ClassId =
                   Convert.ToInt32(grdFeeStructureDetail.DataKeys[grdFeeStructureDetail.SelectedIndex].Values[CLASS_ID_INDEX].ToString());
                objFeeStructureDetail.StreamObject.StreamId =
                   Convert.ToInt32(grdFeeStructureDetail.DataKeys[grdFeeStructureDetail.SelectedIndex].Values[STREAM_ID_INDEX].ToString());

                ActivateControlsView(true, objFeeStructureDetail, null);
            }
            else
            {
                objFeeStructureDetail = SelectRecordById(grdFeeStructureDetail.SelectedIndex);
                if (!objFeeStructureDetail.DbOperationStatus.Equals(CommonConstant.FAIL))
                {
                    if (!Convert.ToBoolean(objFeeStructureDetail.IsRecordChanged))
                    {
                        ActivateControlsView(false, objFeeStructureDetail, grdFeeStructureDetail.SelectedIndex);
                    }
                    else
                    {
                        UIUtility.DisplayMessage(lblMessage, objFeeStructureDetail.DbOperationStatus);
                        InitializeForm();
                    }
                }
                else
                {
                    UIUtility.DisplayMessage(lblMessage, objFeeStructureDetail.DbOperationStatus);
                }
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void grdFeeStructureDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            objFeeStructureDetailBL = new FeeStructureDetailBL();
            objFeeStructureDetail = GetObjectForActivateDeactivate(e.RowIndex, RecordStatus.InActive);
            objFeeStructureDetail = objFeeStructureDetailBL.ActivateDeactivateFeeStructureDetail(objFeeStructureDetail);
            UIUtility.DisplayMessage(lblMessage, objFeeStructureDetail.DbOperationStatus);
            InitializeForm();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void grdFeeStructureDetail_ActivatingObject(object sender, GridViewEditEventArgs e)
    {
        try
        {
            objFeeStructureDetailBL = new FeeStructureDetailBL();
            objFeeStructureDetail = GetObjectForActivateDeactivate(e.NewEditIndex, RecordStatus.Active);
            objFeeStructureDetail = objFeeStructureDetailBL.ActivateDeactivateFeeStructureDetail(objFeeStructureDetail);
            UIUtility.DisplayMessage(lblMessage, objFeeStructureDetail.DbOperationStatus);
            InitializeForm();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void grdFeeStructureDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grdFeeStructureDetail.PageIndex = e.NewPageIndex;
            InitializeForm();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void grdFeeStructureDetail_RowDataBound(object sender, GridViewRowEventArgs e)
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
    protected FeeStructureDetail BindFeeStructureDetailGrid(RecordStatus objRecordStatus)
    {
        objFeeStructureDetailBL = new FeeStructureDetailBL();
        objFeeStructureDetail = new FeeStructureDetail();
        objFeeStructureDetail.RecordStatus = Convert.ToInt16(objRecordStatus);

        objFeeStructureDetail = objFeeStructureDetailBL.SelectFeeStructureDetail(objFeeStructureDetail);
        if (objFeeStructureDetail.DbOperationStatus == CommonConstant.SUCCEED)
        {
            grdFeeStructureDetail.DataSource = objFeeStructureDetail.ObjectDataSet.Tables[0];
            grdFeeStructureDetail.DataBind();
        }
        return objFeeStructureDetail;
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
                objFeeStructureDetail = GetObjectForInsertUpdate();
                objFeeStructureDetailBL = new FeeStructureDetailBL();
                if (objFeeStructureDetail.FeeStructureDetailId == null)
                {
                    objFeeStructureDetail = objFeeStructureDetailBL.InsertFeeStructureDetail(objFeeStructureDetail);
                }
                else
                {
                    objFeeStructureDetail = objFeeStructureDetailBL.UpdateFeeStructureDetail(objFeeStructureDetail);
                }
                if (objFeeStructureDetail.DbOperationStatus == CommonConstant.SUCCEED
                            || objFeeStructureDetail.DbOperationStatus == CommonConstant.INVALID)
                {
                    InitializeForm();
                    MultiViewFeeStructureDetail.ActiveViewIndex = 0;
                }
                UIUtility.DisplayMessage(lblMessage, objFeeStructureDetail.DbOperationStatus);
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
            MultiViewFeeStructureDetail.ActiveViewIndex = 0;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void BindFeeStructureDetailControls()
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
    protected void ActivateControlsView(bool isNewRecord, FeeStructureDetail objFeeStructureDetail, int? editIndex)
    {
        if (isNewRecord)
        {
            ViewState[editIndexKey] = null;
            BindFeeStructureDetailControls();
            //UIUtility.InitializeControls(ViewFeeStructureDetailControls);
            PopulateControlsData(objFeeStructureDetail);
            uxFeeSetupUC.InitializeUserControl();
        }
        else
        {
            ViewState[editIndexKey] = editIndex;
            BindFeeStructureDetailControls();
            PopulateControlsData(objFeeStructureDetail);
        }
        MultiViewFeeStructureDetail.ActiveViewIndex = 1;
    }
    private void PopulateControlsData(FeeStructureDetail objFeeStructureDetail)
    {
        UIUtility.SelectCurrentListItem(ddlBranch, objFeeStructureDetail.BranchObject.BranchId, BindListItem.ByValue, true);
        UIUtility.SelectCurrentListItem(ddlClass, objFeeStructureDetail.ClassObject.ClassId, BindListItem.ByValue, true);
        UIUtility.SelectCurrentListItem(ddlStream, objFeeStructureDetail.StreamObject.StreamId, BindListItem.ByValue, true);
        uxFeeSetupUC.SetUserControlData(objFeeStructureDetail);
    }
    #endregion

    #region Helper Functions
    private bool ValidateObject()
    {
        return true;
    }
    private FeeStructureDetail GetObjectForInsertUpdate()
    {
        objFeeStructureDetail = new FeeStructureDetail();

        if (ViewState[editIndexKey] == null)
        {
            objFeeStructureDetail.Version = BusinessUtility.RECORD_VERSION;
            objFeeStructureDetail.CreatedBy = LoggedInUser;
            objFeeStructureDetail.CreatedOn = GeneralUtility.CurrentDateTime;
        }
        else
        {
            objFeeStructureDetail.FeeStructureDetailId = Convert.ToInt32(grdFeeStructureDetail.DataKeys[Convert.ToInt32(ViewState[editIndexKey])].Values[FEE_STRUCTURE_DETAIL_ID_INDEX].ToString());
            objFeeStructureDetail.Version = Convert.ToInt16(grdFeeStructureDetail.DataKeys[Convert.ToInt16(ViewState[editIndexKey])].Values[VERSION_INDEX].ToString()) + 1;
        }

        objFeeStructureDetail.FeeStructureObject = new FeeStructure();
        objFeeStructureDetail.FeeStructureObject.FeeStructureId = 1;
        if (ddlBranch.SelectedIndex != 0)
        {
            objFeeStructureDetail.BranchObject = new BranchMaster();
            objFeeStructureDetail.BranchObject.BranchId = Convert.ToInt32(ddlBranch.SelectedItem.Value);
        }
        if (ddlClass.SelectedIndex != 0)
        {
            objFeeStructureDetail.ClassObject = new ClassMaster();
            objFeeStructureDetail.ClassObject.ClassId = Convert.ToInt32(ddlClass.SelectedItem.Value);
        }
        if (ddlStream.SelectedIndex != 0)
        {
            objFeeStructureDetail.StreamObject = new StreamMaster();
            objFeeStructureDetail.StreamObject.StreamId = Convert.ToInt32(ddlStream.SelectedItem.Value);
        }
        objFeeStructureDetail.FeeSetupData = uxFeeSetupUC.GetUserControlData();
        objFeeStructureDetail.ModifiedBy = LoggedInUser;
        objFeeStructureDetail.ModifiedOn = GeneralUtility.CurrentDateTime;
        objFeeStructureDetail.RecordStatus = Convert.ToInt16(RecordStatus.Active);
        return objFeeStructureDetail;
    }
    private FeeStructureDetail GetObjectForActivateDeactivate(int editIndex, RecordStatus objStatus)
    {
        objFeeStructureDetail = new FeeStructureDetail();
        objFeeStructureDetail.FeeStructureDetailId = Convert.ToInt32(grdFeeStructureDetail.DataKeys[editIndex].Values[FEE_STRUCTURE_DETAIL_ID_INDEX].ToString());
        objFeeStructureDetail.Version = Convert.ToInt16(grdFeeStructureDetail.DataKeys[editIndex].Values[VERSION_INDEX].ToString()) + 1;
        objFeeStructureDetail.ModifiedBy = LoggedInUser;
        objFeeStructureDetail.RecordStatus = Convert.ToInt16(objStatus);
        return objFeeStructureDetail;
    }
    private FeeStructureDetail SelectRecordById(int editIndex)
    {
        objFeeStructureDetailBL = new FeeStructureDetailBL();
        objFeeStructureDetail = new FeeStructureDetail();
        objFeeStructureDetail.FeeStructureDetailId = Convert.ToInt32(grdFeeStructureDetail.DataKeys[editIndex].Values[FEE_STRUCTURE_DETAIL_ID_INDEX].ToString());
        objFeeStructureDetail.Version = Convert.ToInt16(grdFeeStructureDetail.DataKeys[editIndex].Values[VERSION_INDEX].ToString());
        objFeeStructureDetail = objFeeStructureDetailBL.SelectRecordById(objFeeStructureDetail);
        return objFeeStructureDetail;
    }
    #endregion
}
