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

public partial class ImmigrationDetailUC : System.Web.UI.UserControl
{
    #region Page Variables
    ImmigrationDetail objImmigrationDetail = null;
    ImmigrationDetailBL objImmigrationDetailBL = null;
    MetadataMaster objMetadataMaster = null;
    MetadataMasterBL objMetadataMasterBL = null;
    private string editIndexKey = "EditIndexImmigrationDetailKey";
    string strMemberType = "MemberType";
    #endregion

    #region Page Events and Functions
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    public void InitializeUserControl(int? dataKey, string strSessionDataKey, int objMemberType)
    {
        if (!string.IsNullOrEmpty(strSessionDataKey))
        { hfSessionDataKey.Value = strSessionDataKey; }
        if (objMemberType != null)
        { ViewState[strMemberType] = objMemberType; }

        if (Session[hfSessionDataKey.Value] == null)
        {
            hfIsControlsLoaded.Value = false.ToString();
            objImmigrationDetailBL = new ImmigrationDetailBL();
            objImmigrationDetail = new ImmigrationDetail();
            objImmigrationDetail.MemberObject = new EmployeeDetail();
            objImmigrationDetail.MemberObject.EmployeeId = dataKey;
            objImmigrationDetail.MemberTypeObject = new MetadataMaster();
            objImmigrationDetail.MemberTypeObject.MetadataId = Convert.ToInt32(ViewState[strMemberType]);
            objImmigrationDetail.StatusObject = new MetadataMaster();
            objImmigrationDetail.StatusObject.DataHolder = Convert.ToInt32(MetadataTypeEnum.ImmigrationStatus).ToString();

            objImmigrationDetail = objImmigrationDetailBL.SelectImmigrationDetail(objImmigrationDetail);
            grdImmigrationDetail.DataSource = objImmigrationDetail.ObjectDataSet.Tables[0];
            grdImmigrationDetail.DataBind();

            Session[hfSessionDataKey.Value] = objImmigrationDetail.ObjectDataSet.Tables[0];
            MultiViewImmigrationDetail.ActiveViewIndex = 0;

            if (grdImmigrationDetail.Rows.Count == 0)
            {
                hfEditIndexKey.Value = string.Empty;
                BindImmigrationDetailControls();
                UIUtility.InitializeControls(ViewImmigrationDetailControls);
                MultiViewImmigrationDetail.ActiveViewIndex = 1;
            }
        }
        else
        {
            grdImmigrationDetail.DataSource = (DataTable)Session[hfSessionDataKey.Value];
            grdImmigrationDetail.DataBind();
        }
    }
    #endregion

    #region Grid Events and Functions

    protected void grdImmigrationDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ActivateControlsView(false, grdImmigrationDetail.SelectedIndex);
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void grdImmigrationDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            DataTable _objTable = (DataTable)Session[hfSessionDataKey.Value];
            _objTable.Rows[e.RowIndex].Delete();
            InitializeUserControl(null, string.Empty, Convert.ToInt32(ViewState[strMemberType]));
            UIUtility.DisplayMessage(lblMessage, CommonConstant.SUCCEED);
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void grdImmigrationDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grdImmigrationDetail.PageIndex = e.NewPageIndex;
            InitializeUserControl(null, string.Empty, Convert.ToInt32(ViewState[strMemberType]));
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    #endregion

    #region Controls Events and Functions
    protected void btnAddRecord_Click(object sender, EventArgs e)
    {
        try
        {
            ActivateControlsView(true, null);
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidateObject())
            {
                objImmigrationDetail = GetImmigrationDetailForDataTable();
                if (string.IsNullOrEmpty(hfEditIndexKey.Value))
                {
                    int _rowIndex = grdImmigrationDetail.Rows.Count;
                    objImmigrationDetail.AddObjectToTable((DataTable)Session[hfSessionDataKey.Value]);
                    ((DataTable)Session[hfSessionDataKey.Value]).Rows[_rowIndex]["IMMIGRATION_STATUS"] = ddlStatus.SelectedItem.Text;
                }
                else
                {
                    int _rowIndex = Convert.ToInt32(hfEditIndexKey.Value);
                    objImmigrationDetail.UpdateTableFromObject((DataTable)Session[hfSessionDataKey.Value], _rowIndex);
                    ((DataTable)Session[hfSessionDataKey.Value]).Rows[_rowIndex]["IMMIGRATION_STATUS"] = ddlStatus.SelectedItem.Text;
                }

                UIUtility.DisplayMessage(lblMessage, CommonConstant.SUCCEED);
                InitializeUserControl(null, null, Convert.ToInt32(ViewState[strMemberType]));
                MultiViewImmigrationDetail.ActiveViewIndex = 0;
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            MultiViewImmigrationDetail.ActiveViewIndex = 0;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void BindImmigrationDetailControls()
    {
        if (!Convert.ToBoolean(hfIsControlsLoaded.Value))
        {
            UIController.BindMetadataDDL(ddlStatus, MetadataTypeEnum.ImmigrationStatus);
            hfIsControlsLoaded.Value = true.ToString();
        }
    }
    protected void ActivateControlsView(bool isNewRecord, int? editImmigrationDetailIndex)
    {
        if (isNewRecord)
        {
            hfEditIndexKey.Value = string.Empty;
            BindImmigrationDetailControls();
            UIUtility.InitializeControls(ViewImmigrationDetailControls);
        }
        else
        {
            int _rowIndex = Convert.ToInt32(editImmigrationDetailIndex);
            hfEditIndexKey.Value = _rowIndex.ToString();
            BindImmigrationDetailControls();
            PopulateControlsData(_rowIndex);
        }
        MultiViewImmigrationDetail.ActiveViewIndex = 1;
    }
    private void PopulateControlsData(int rowIndex)
    {
        objImmigrationDetail = new ImmigrationDetail();
        objImmigrationDetail.ConvertToObjectFromDataRow((DataTable)Session[hfSessionDataKey.Value], rowIndex);
        txtPassportNo.Text = objImmigrationDetail.PassportNo;
        txtPassportDetail.Text = objImmigrationDetail.PassportDetail;
        txtIssueDate.Text = objImmigrationDetail.IssueDate.ToString();
        txtExpiryDate.Text = objImmigrationDetail.ExpiryDate.ToString();
        txtReviseDate.Text = objImmigrationDetail.ReviseDate.ToString();
        txtSponsor.Text = objImmigrationDetail.Sponsor;
        UIUtility.SelectCurrentListItem(ddlStatus, objImmigrationDetail.StatusObject.MetadataId, BindListItem.ByValue, true);
        txtComment.Text = objImmigrationDetail.Comment;
    }
    #endregion

    #region Helper Functions
    private bool ValidateObject()
    {
        return true;
    }

    private ImmigrationDetail GetImmigrationDetailForDataTable()
    {
        objImmigrationDetail = new ImmigrationDetail();

        objImmigrationDetail.MemberTypeObject = new MetadataMaster();
        objImmigrationDetail.MemberTypeObject.MetadataId = Convert.ToInt32(ViewState[strMemberType]);
        objImmigrationDetail.PassportNo = txtPassportNo.Text;
        objImmigrationDetail.PassportDetail = txtPassportDetail.Text;
        objImmigrationDetail.IssueDate = Convert.ToDateTime(txtIssueDate.Text);
        objImmigrationDetail.ExpiryDate = Convert.ToDateTime(txtExpiryDate.Text);
        objImmigrationDetail.ReviseDate = Convert.ToDateTime(txtReviseDate.Text);
        objImmigrationDetail.Sponsor = txtSponsor.Text;
        if (ddlStatus.SelectedIndex != 0)
        {
            objImmigrationDetail.StatusObject = new MetadataMaster();
            objImmigrationDetail.StatusObject.MetadataId = Convert.ToInt32(ddlStatus.SelectedItem.Value);
        }
        objImmigrationDetail.Comment = txtComment.Text;
        return objImmigrationDetail;
    }
    #endregion
}
