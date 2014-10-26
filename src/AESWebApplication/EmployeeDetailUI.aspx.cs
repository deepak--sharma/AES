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

public partial class EmployeeDetailUI : BasePage
{
    #region Page Variables
    EmployeeDetail objEmployeeDetail = null;
    EmployeeDetailBL objEmployeeDetailBL = null;
    MetadataMaster objMetadataMaster = null;
    MetadataMasterBL objMetadataMasterBL = null;

    private const int SELECT_COLUMN = 0;
    private const int ACTIVATE_COLUMN = 1;
    private const int DELETE_COLUMN = 2;

    private const int EMPLOYEE_ID_INDEX = 0;
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
            objEmployeeDetail = BindEmployeeDetailGrid(RecordStatus.Active);
            if (objEmployeeDetail.DbOperationStatus != CommonConstant.SUCCEED)
            {
                btnAddNewRecord.Enabled = false;
                UIUtility.DisplayMessage(lblMessage, objEmployeeDetail.DbOperationStatus);
            }
        }
        else
        {
            if (rdbActiveRecord.Checked)
            {
                objEmployeeDetail = BindEmployeeDetailGrid(RecordStatus.Active);
                if (objEmployeeDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    UIUtility.DisplayMessage(lblMessage, objEmployeeDetail.DbOperationStatus);
                    return;
                }
                ViewActivateColumn(false);
            }
            else
            {
                objEmployeeDetail = BindEmployeeDetailGrid(RecordStatus.InActive);
                if (objEmployeeDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    UIUtility.DisplayMessage(lblMessage, objEmployeeDetail.DbOperationStatus);
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
            grdEmployeeDetail.Columns[SELECT_COLUMN].Visible = false;
            grdEmployeeDetail.Columns[ACTIVATE_COLUMN].Visible = true;
            grdEmployeeDetail.Columns[DELETE_COLUMN].Visible = false;
        }
        else
        {
            grdEmployeeDetail.Columns[SELECT_COLUMN].Visible = true;
            grdEmployeeDetail.Columns[ACTIVATE_COLUMN].Visible = false;
            grdEmployeeDetail.Columns[DELETE_COLUMN].Visible = true;
        }
    }
    #endregion

    #region Grid Events and Functions
    protected void grdEmployeeDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string employeeId =
                grdEmployeeDetail.DataKeys[e.Row.RowIndex].Values[EMPLOYEE_ID_INDEX].ToString();
            HyperLink hlnkSelect = (HyperLink)e.Row.FindControl("lnkSelect");
            hlnkSelect.NavigateUrl = "EmployeeActionViewUI.aspx?EmpId=" + employeeId;
        }
    }
    protected void grdEmployeeDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            objEmployeeDetailBL = new EmployeeDetailBL();
            objEmployeeDetail = GetObjectForActivateDeactivate(e.RowIndex, RecordStatus.InActive);
            objEmployeeDetail = objEmployeeDetailBL.ActivateDeactivateEmployeeDetail(objEmployeeDetail);
            UIUtility.DisplayMessage(lblMessage, objEmployeeDetail.DbOperationStatus);
            InitializeForm();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void grdEmployeeDetail_ActivatingObject(object sender, GridViewEditEventArgs e)
    {
        try
        {
            objEmployeeDetailBL = new EmployeeDetailBL();
            objEmployeeDetail = GetObjectForActivateDeactivate(e.NewEditIndex, RecordStatus.Active);
            objEmployeeDetail = objEmployeeDetailBL.ActivateDeactivateEmployeeDetail(objEmployeeDetail);
            UIUtility.DisplayMessage(lblMessage, objEmployeeDetail.DbOperationStatus);
            InitializeForm();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void grdEmployeeDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grdEmployeeDetail.PageIndex = e.NewPageIndex;
            InitializeForm();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected EmployeeDetail BindEmployeeDetailGrid(RecordStatus objRecordStatus)
    {
        objEmployeeDetailBL = new EmployeeDetailBL();
        objEmployeeDetail = new EmployeeDetail();
        objEmployeeDetail.RecordStatus = Convert.ToInt16(objRecordStatus);

        objEmployeeDetail = objEmployeeDetailBL.SelectEmployeeDetail(objEmployeeDetail);
        if (objEmployeeDetail.DbOperationStatus == CommonConstant.SUCCEED)
        {
            grdEmployeeDetail.DataSource = objEmployeeDetail.ObjectDataSet.Tables[0];
            grdEmployeeDetail.DataBind();
        }
        return objEmployeeDetail;
    }
    #endregion

    #region Controls Events and Functions
    protected void btnAddNewRecord_Click(object sender, EventArgs e)
    {

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
    #endregion

    #region Helper Functions
    private bool ValidateObject()
    {
        return true;
    }
    private EmployeeDetail GetObjectForActivateDeactivate(int editIndex, RecordStatus objStatus)
    {
        objEmployeeDetail = new EmployeeDetail();
        objEmployeeDetail.EmployeeId = Convert.ToInt32(grdEmployeeDetail.DataKeys[editIndex].Values[EMPLOYEE_ID_INDEX].ToString());
        objEmployeeDetail.Version = Convert.ToInt16(grdEmployeeDetail.DataKeys[editIndex].Values[VERSION_INDEX].ToString()) + 1;
        objEmployeeDetail.ModifiedBy = LoggedInUser;
        objEmployeeDetail.RecordStatus = Convert.ToInt16(objStatus);
        return objEmployeeDetail;
    }
    #endregion

}
