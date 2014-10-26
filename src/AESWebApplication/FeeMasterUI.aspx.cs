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

public partial class FeeMasterUI : BasePage
{
    #region Page Variables
    FeeMaster objFeeMaster = null;
    FeeMasterBL objFeeMasterBL = null;
    MetadataMaster objMetadataMaster = null;
    MetadataMasterBL objMetadataMasterBL = null;

    private const int SELECT_COLUMN = 0;
    private const int ACTIVATE_COLUMN = 1;
    private const int DELETE_COLUMN = 2;

    private const int FEE_ID_INDEX = 0;
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
            objFeeMaster = BindFeeMasterGrid(RecordStatus.Active);
            if (objFeeMaster.DbOperationStatus != CommonConstant.SUCCEED)
            {
                btnAddNewRecord.Enabled = false;
                UIUtility.DisplayMessage(lblMessage, objFeeMaster.DbOperationStatus);
                return;
            }

            ViewState[isControlsLoaded] = false;

            if (grdFeeMaster.Rows.Count == 0)
            {
                BindFeeMasterControls();
                MultiViewFeeMaster.ActiveViewIndex = 1;
            }
        }
        else
        {
            if (rdbActiveRecord.Checked)
            {
                objFeeMaster = BindFeeMasterGrid(RecordStatus.Active);
                if (objFeeMaster.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    UIUtility.DisplayMessage(lblMessage, objFeeMaster.DbOperationStatus);
                    return;
                }
                ViewActivateColumn(false);
            }
            else
            {
                objFeeMaster = BindFeeMasterGrid(RecordStatus.InActive);
                if (objFeeMaster.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    UIUtility.DisplayMessage(lblMessage, objFeeMaster.DbOperationStatus);
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
            grdFeeMaster.Columns[SELECT_COLUMN].Visible = false;
            grdFeeMaster.Columns[ACTIVATE_COLUMN].Visible = true;
            grdFeeMaster.Columns[DELETE_COLUMN].Visible = false;
        }
        else
        {
            grdFeeMaster.Columns[SELECT_COLUMN].Visible = true;
            grdFeeMaster.Columns[ACTIVATE_COLUMN].Visible = false;
            grdFeeMaster.Columns[DELETE_COLUMN].Visible = true;
        }
    }
    #endregion

    #region Grid Events and Functions
    protected void grdFeeMaster_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            objFeeMaster = SelectRecordById(grdFeeMaster.SelectedIndex);
            if (!objFeeMaster.DbOperationStatus.Equals(CommonConstant.FAIL))
            {
                if (!Convert.ToBoolean(objFeeMaster.IsRecordChanged))
                {
                    ActivateControlsView(false, objFeeMaster, grdFeeMaster.SelectedIndex);
                }
                else
                {
                    UIUtility.DisplayMessage(lblMessage, objFeeMaster.DbOperationStatus);
                    InitializeForm();
                }
            }
            else
            {
                UIUtility.DisplayMessage(lblMessage, objFeeMaster.DbOperationStatus);
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void grdFeeMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            objFeeMasterBL = new FeeMasterBL();
            objFeeMaster = GetObjectForActivateDeactivate(e.RowIndex, RecordStatus.InActive);
            objFeeMaster = objFeeMasterBL.ActivateDeactivateFeeMaster(objFeeMaster);
            UIUtility.DisplayMessage(lblMessage, objFeeMaster.DbOperationStatus);
            InitializeForm();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void grdFeeMaster_ActivatingObject(object sender, GridViewEditEventArgs e)
    {
        try
        {
            objFeeMasterBL = new FeeMasterBL();
            objFeeMaster = GetObjectForActivateDeactivate(e.NewEditIndex, RecordStatus.Active);
            objFeeMaster = objFeeMasterBL.ActivateDeactivateFeeMaster(objFeeMaster);
            UIUtility.DisplayMessage(lblMessage, objFeeMaster.DbOperationStatus);
            InitializeForm();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void grdFeeMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grdFeeMaster.PageIndex = e.NewPageIndex;
            InitializeForm();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected FeeMaster BindFeeMasterGrid(RecordStatus objRecordStatus)
    {
        objFeeMasterBL = new FeeMasterBL();
        objFeeMaster = new FeeMaster();
        objFeeMaster.RecordStatus = Convert.ToInt16(objRecordStatus);

        objFeeMaster.FeeGroupObject = new MetadataMaster();
        objFeeMaster.FeeGroupObject.DataHolder = ((int)MetadataTypeEnum.FeeGroup).ToString();

        objFeeMaster.FrequencyObject = new MetadataMaster();
        objFeeMaster.FrequencyObject.DataHolder = ((int)MetadataTypeEnum.FeeFrequency).ToString();

        objFeeMaster.ApplicableTo = new MetadataMaster();
        objFeeMaster.ApplicableTo.DataHolder = ((int)MetadataTypeEnum.FeeApplicableTo).ToString();

        objFeeMaster = objFeeMasterBL.SelectFeeMaster(objFeeMaster);
        if (objFeeMaster.DbOperationStatus == CommonConstant.SUCCEED)
        {
            grdFeeMaster.DataSource = objFeeMaster.ObjectDataSet.Tables[0];
            grdFeeMaster.DataBind();
        }
        return objFeeMaster;
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
    protected void btnSave_Click(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidateObject())
            {
                objFeeMaster = GetObjectForInsertUpdate();
                objFeeMasterBL = new FeeMasterBL();
                if (objFeeMaster.FeeId == null)
                {
                    objFeeMaster = objFeeMasterBL.InsertFeeMaster(objFeeMaster);
                }
                else
                {
                    objFeeMaster = objFeeMasterBL.UpdateFeeMaster(objFeeMaster);
                }
                if (objFeeMaster.DbOperationStatus == CommonConstant.SUCCEED
                            || objFeeMaster.DbOperationStatus == CommonConstant.INVALID)
                {
                    InitializeForm();
                    MultiViewFeeMaster.ActiveViewIndex = 0;
                }
                UIUtility.DisplayMessage(lblMessage, objFeeMaster.DbOperationStatus);
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
            MultiViewFeeMaster.ActiveViewIndex = 0;
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
    protected void BindFeeMasterControls()
    {
        if (!Convert.ToBoolean(ViewState[isControlsLoaded]))
        {
            UIController.BindMetadataDDL(ddlFeeGroup, MetadataTypeEnum.FeeGroup);
            UIController.BindMetadataDDL(ddlFrequency, MetadataTypeEnum.FeeFrequency);
            UIController.BindMetadataDDL(ddlApplicable, MetadataTypeEnum.FeeApplicableTo);
            ViewState[isControlsLoaded] = true;
        }
    }
    protected void ActivateControlsView(bool isNewRecord, FeeMaster objFeeMaster, int? editIndex)
    {
        if (isNewRecord)
        {
            ViewState[editIndexKey] = null;
            BindFeeMasterControls();
            UIUtility.InitializeControls(ViewFeeMasterControls);
        }
        else
        {
            ViewState[editIndexKey] = editIndex;
            BindFeeMasterControls();
            PopulateControlsData(objFeeMaster);
        }
        MultiViewFeeMaster.ActiveViewIndex = 1;
    }
    private void PopulateControlsData(FeeMaster objFeeMaster)
    {
        txtFeeCode.Text = objFeeMaster.FeeCode;
        txtFeeName.Text = objFeeMaster.FeeName;
        UIUtility.SelectCurrentListItem(ddlFeeGroup, objFeeMaster.FeeGroupObject.MetadataId, BindListItem.ByValue, true);
        UIUtility.SelectCurrentListItem(ddlFrequency, objFeeMaster.FrequencyObject.MetadataId, BindListItem.ByValue, true);
        UIUtility.SelectCurrentListItem(ddlIsMandatory, objFeeMaster.IsMandatory, BindListItem.ByValue, true);
        UIUtility.SelectCurrentListItem(ddlIsRefundable, objFeeMaster.IsRefundable, BindListItem.ByValue, true);
        UIUtility.SelectCurrentListItem(ddlApplicable, objFeeMaster.ApplicableTo.MetadataId, BindListItem.ByValue, true);
        txtDescription.Text = objFeeMaster.Description;
    }
    #endregion

    #region Helper Functions
    private bool ValidateObject()
    {
        return true;
    }
    private FeeMaster GetObjectForInsertUpdate()
    {
        objFeeMaster = new FeeMaster();

        if (ViewState[editIndexKey] == null)
        {
            objFeeMaster.Version = BusinessUtility.RECORD_VERSION;
            objFeeMaster.CreatedBy = LoggedInUser;
            objFeeMaster.CreatedOn = GeneralUtility.CurrentDateTime;
        }
        else
        {
            objFeeMaster.FeeId = Convert.ToInt32(grdFeeMaster.DataKeys[Convert.ToInt32(ViewState[editIndexKey])].Values[FEE_ID_INDEX].ToString());
            objFeeMaster.Version = Convert.ToInt16(grdFeeMaster.DataKeys[Convert.ToInt16(ViewState[editIndexKey])].Values[VERSION_INDEX].ToString()) + 1;
        }

        objFeeMaster.FeeCode = txtFeeCode.Text;
        objFeeMaster.FeeName = txtFeeName.Text;
        if (ddlFeeGroup.SelectedIndex != 0)
        {
            objFeeMaster.FeeGroupObject = new MetadataMaster();
            objFeeMaster.FeeGroupObject.MetadataId = Convert.ToInt32(ddlFeeGroup.SelectedItem.Value);
        }
        if (ddlFrequency.SelectedIndex != 0)
        {
            objFeeMaster.FrequencyObject = new MetadataMaster();
            objFeeMaster.FrequencyObject.MetadataId = Convert.ToInt32(ddlFrequency.SelectedItem.Value);
        }
        objFeeMaster.IsMandatory = Convert.ToBoolean(ddlIsMandatory.SelectedItem.Value);
        objFeeMaster.IsRefundable = Convert.ToBoolean(ddlIsRefundable.SelectedItem.Value);
        if (ddlApplicable.SelectedIndex != 0)
        {
            objFeeMaster.ApplicableTo = new MetadataMaster();
            objFeeMaster.ApplicableTo.MetadataId = Convert.ToInt32(ddlApplicable.SelectedItem.Value);
        }
        objFeeMaster.Description = txtDescription.Text;
        objFeeMaster.ModifiedBy = LoggedInUser;
        objFeeMaster.ModifiedOn = GeneralUtility.CurrentDateTime;
        objFeeMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
        return objFeeMaster;
    }
    private FeeMaster GetObjectForActivateDeactivate(int editIndex, RecordStatus objStatus)
    {
        objFeeMaster = new FeeMaster();
        objFeeMaster.FeeId = Convert.ToInt32(grdFeeMaster.DataKeys[editIndex].Values[FEE_ID_INDEX].ToString());
        objFeeMaster.Version = Convert.ToInt16(grdFeeMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString()) + 1;
        objFeeMaster.ModifiedBy = LoggedInUser;
        objFeeMaster.RecordStatus = Convert.ToInt16(objStatus);
        return objFeeMaster;
    }
    private FeeMaster SelectRecordById(int editIndex)
    {
        objFeeMasterBL = new FeeMasterBL();
        objFeeMaster = new FeeMaster();
        objFeeMaster.FeeId = Convert.ToInt32(grdFeeMaster.DataKeys[editIndex].Values[FEE_ID_INDEX].ToString());
        objFeeMaster.Version = Convert.ToInt16(grdFeeMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString());
        objFeeMaster = objFeeMasterBL.SelectRecordById(objFeeMaster);
        return objFeeMaster;
    }
    #endregion
}
