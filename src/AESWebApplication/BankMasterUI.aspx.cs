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
using System.Diagnostics;

public partial class BankMasterUI : BasePage
{
    #region Page Variables
    BankMaster objBankMaster = null;
    BankMasterBL objBankMasterBL = null;

    private const int SELECT_COLUMN = 0;
    private const int ACTIVATE_COLUMN = 1;
    private const int DELETE_COLUMN = 2;

    private const int BANK_ID_INDEX = 0;
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
            objBankMaster = BindBankMasterGrid(RecordStatus.Active);
            if (objBankMaster.DbOperationStatus != CommonConstant.SUCCEED)
            {
                btnAddNewRecord.Enabled = false;
                UIUtility.DisplayMessage(lblMessage, objBankMaster.DbOperationStatus);
                return;
            }

            ViewState[isControlsLoaded] = false;

            if (grdBankMaster.Rows.Count == 0)
            {
                BindBankMasterControls();
                MultiViewBankMaster.ActiveViewIndex = 1;
            }
        }
        else
        {
            if (rdbActiveRecord.Checked)
            {
                objBankMaster = BindBankMasterGrid(RecordStatus.Active);
                if (objBankMaster.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    UIUtility.DisplayMessage(lblMessage, objBankMaster.DbOperationStatus);
                    return;
                }
                ViewActivateColumn(false);
            }
            else
            {
                objBankMaster = BindBankMasterGrid(RecordStatus.InActive);
                if (objBankMaster.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    UIUtility.DisplayMessage(lblMessage, objBankMaster.DbOperationStatus);
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
            grdBankMaster.Columns[SELECT_COLUMN].Visible = false;
            grdBankMaster.Columns[ACTIVATE_COLUMN].Visible = true;
            grdBankMaster.Columns[DELETE_COLUMN].Visible = false;
        }
        else
        {
            grdBankMaster.Columns[SELECT_COLUMN].Visible = true;
            grdBankMaster.Columns[ACTIVATE_COLUMN].Visible = false;
            grdBankMaster.Columns[DELETE_COLUMN].Visible = true;
        }
    }
    #endregion

    #region Grid Events and Functions
    protected void grdBankMaster_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            objBankMaster = SelectRecordById(grdBankMaster.SelectedIndex);
            if (!objBankMaster.DbOperationStatus.Equals(CommonConstant.FAIL))
            {
                if (!Convert.ToBoolean(objBankMaster.IsRecordChanged))
                {
                    ActivateControlsView(false, objBankMaster, grdBankMaster.SelectedIndex);
                }
                else
                {
                    UIUtility.DisplayMessage(lblMessage, objBankMaster.DbOperationStatus);
                    InitializeForm();
                }
            }
            else
            {
                UIUtility.DisplayMessage(lblMessage, objBankMaster.DbOperationStatus);
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void grdBankMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            objBankMasterBL = new BankMasterBL();
            objBankMaster = GetObjectForActivateDeactivate(e.RowIndex, RecordStatus.InActive);
            objBankMaster = objBankMasterBL.ActivateDeactivateBankMaster(objBankMaster);
            UIUtility.DisplayMessage(lblMessage, objBankMaster.DbOperationStatus);
            InitializeForm();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void grdBankMaster_ActivatingObject(object sender, GridViewEditEventArgs e)
    {
        try
        {
            objBankMasterBL = new BankMasterBL();
            objBankMaster = GetObjectForActivateDeactivate(e.NewEditIndex, RecordStatus.Active);
            objBankMaster = objBankMasterBL.ActivateDeactivateBankMaster(objBankMaster);
            UIUtility.DisplayMessage(lblMessage, objBankMaster.DbOperationStatus);
            InitializeForm();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void grdBankMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grdBankMaster.PageIndex = e.NewPageIndex;
            InitializeForm();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected BankMaster BindBankMasterGrid(RecordStatus objRecordStatus)
    {
        objBankMasterBL = new BankMasterBL();
        objBankMaster = new BankMaster();
        objBankMaster.RecordStatus = Convert.ToInt16(objRecordStatus);

        objBankMaster = objBankMasterBL.SelectBankMaster(objBankMaster);
        if (objBankMaster.DbOperationStatus == CommonConstant.SUCCEED)
        {
            grdBankMaster.DataSource = objBankMaster.ObjectDataSet.Tables[0];
            grdBankMaster.DataBind();
        }
        return objBankMaster;
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
                objBankMaster = GetObjectForInsertUpdate();
                objBankMasterBL = new BankMasterBL();
                if (objBankMaster.BankId == null)
                {
                    objBankMaster = objBankMasterBL.InsertBankMaster(objBankMaster);
                }
                else
                {
                    objBankMaster = objBankMasterBL.UpdateBankMaster(objBankMaster);
                }
                if (objBankMaster.DbOperationStatus == CommonConstant.SUCCEED
                            || objBankMaster.DbOperationStatus == CommonConstant.INVALID)
                {
                    InitializeForm();
                    MultiViewBankMaster.ActiveViewIndex = 0;
                }
                UIUtility.DisplayMessage(lblMessage, objBankMaster.DbOperationStatus);
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
            MultiViewBankMaster.ActiveViewIndex = 0;
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
    protected void BindBankMasterControls()
    {
        if (!Convert.ToBoolean(ViewState[isControlsLoaded]))
        {
            ViewState[isControlsLoaded] = true;
        }
    }
    protected void ActivateControlsView(bool isNewRecord, BankMaster objBankMaster, int? editIndex)
    {
        if (isNewRecord)
        {
            ViewState[editIndexKey] = null;
            BindBankMasterControls();
            UIUtility.InitializeControls(ViewBankMasterControls);
        }
        else
        {
            ViewState[editIndexKey] = editIndex;
            BindBankMasterControls();
            PopulateControlsData(objBankMaster);
        }
        MultiViewBankMaster.ActiveViewIndex = 1;
    }
    private void PopulateControlsData(BankMaster objBankMaster)
    {
        txtBankCode.Text = objBankMaster.BankCode;
        txtBankName.Text = objBankMaster.BankName;
        txtBankAddressId.Text = objBankMaster.BankAddressId.ToString();
        txtDescription.Text = objBankMaster.Description;
        
        
    }
    #endregion

    #region Helper Functions
    private bool ValidateObject()
    {
        return true;
    }
    private BankMaster GetObjectForInsertUpdate()
    {
        objBankMaster = new BankMaster();

        if (ViewState[editIndexKey] == null)
        {
            objBankMaster.Version = BusinessUtility.RECORD_VERSION;
            objBankMaster.CreatedBy = LoggedInUser;
            objBankMaster.CreatedOn = GeneralUtility.CurrentDateTime;
        }
        else
        {
            objBankMaster.BankId = Convert.ToInt32(grdBankMaster.DataKeys[Convert.ToInt32(ViewState[editIndexKey])].Values[BANK_ID_INDEX].ToString());
            objBankMaster.Version = Convert.ToInt16(grdBankMaster.DataKeys[Convert.ToInt16(ViewState[editIndexKey])].Values[VERSION_INDEX].ToString()) + 1;
        }

        objBankMaster.BankCode = txtBankCode.Text;
        objBankMaster.BankName = txtBankName.Text;
        objBankMaster.BankAddressId = Convert.ToInt32(txtBankAddressId.Text);
        objBankMaster.Description = txtDescription.Text;
        objBankMaster.ModifiedBy = LoggedInUser;
        objBankMaster.ModifiedOn = GeneralUtility.CurrentDateTime;
        objBankMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
        return objBankMaster;
    }
    private BankMaster GetObjectForActivateDeactivate(int editIndex, RecordStatus objStatus)
    {
        objBankMaster = new BankMaster();
        objBankMaster.BankId = Convert.ToInt32(grdBankMaster.DataKeys[editIndex].Values[BANK_ID_INDEX].ToString());
        objBankMaster.Version = Convert.ToInt16(grdBankMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString()) + 1;
        objBankMaster.ModifiedBy = LoggedInUser;
        objBankMaster.RecordStatus = Convert.ToInt16(objStatus);
        return objBankMaster;
    }
    private BankMaster SelectRecordById(int editIndex)
    {
        objBankMasterBL = new BankMasterBL();
        objBankMaster = new BankMaster();
        objBankMaster.BankId = Convert.ToInt32(grdBankMaster.DataKeys[editIndex].Values[BANK_ID_INDEX].ToString());
        objBankMaster.Version = Convert.ToInt16(grdBankMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString());
        objBankMaster = objBankMasterBL.SelectRecordById(objBankMaster);
        return objBankMaster;
    }
    #endregion
    
}
