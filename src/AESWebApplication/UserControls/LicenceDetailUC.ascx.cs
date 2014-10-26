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

public partial class LicenceDetailUC : System.Web.UI.UserControl
{
    #region Page Variables
    LicenceDetail objLicenceDetail = null;
    LicenceDetailBL objLicenceDetailBL = null;
    MetadataMaster objMetadataMaster = null;
    MetadataMasterBL objMetadataMasterBL = null;
    private string editIndexKey = "EditIndexLicenceDetailKey";
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
            objLicenceDetailBL = new LicenceDetailBL();
            objLicenceDetail = new LicenceDetail();
            objLicenceDetail.MemberObject = new EmployeeDetail();
            objLicenceDetail.MemberObject.EmployeeId = dataKey;
            objLicenceDetail.MemberTypeObject = new MetadataMaster();
            objLicenceDetail.MemberTypeObject.MetadataId = Convert.ToInt32(ViewState[strMemberType]);
            objLicenceDetail.LicenceTypeObject = new MetadataMaster();
            objLicenceDetail.LicenceTypeObject.DataHolder = Convert.ToInt32(MetadataTypeEnum.LicenceType).ToString();

            objLicenceDetail = objLicenceDetailBL.SelectLicenceDetail(objLicenceDetail);
            grdLicenceDetail.DataSource = objLicenceDetail.ObjectDataSet.Tables[0];
            grdLicenceDetail.DataBind();

            Session[hfSessionDataKey.Value] = objLicenceDetail.ObjectDataSet.Tables[0];
            MultiViewLicenceDetail.ActiveViewIndex = 0;

            if (grdLicenceDetail.Rows.Count == 0)
            {
                hfEditIndexKey.Value = string.Empty;
                BindLicenceDetailControls();
                UIUtility.InitializeControls(ViewLicenceDetailControls);
                MultiViewLicenceDetail.ActiveViewIndex = 1;
            }
        }
        else
        {
            grdLicenceDetail.DataSource = (DataTable)Session[hfSessionDataKey.Value];
            grdLicenceDetail.DataBind();
        }
    }
    #endregion

    #region Grid Events and Functions

    protected void grdLicenceDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ActivateControlsView(false, grdLicenceDetail.SelectedIndex);
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void grdLicenceDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
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
    protected void grdLicenceDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grdLicenceDetail.PageIndex = e.NewPageIndex;
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
                objLicenceDetail = GetLicenceDetailForDataTable();
                if (string.IsNullOrEmpty(hfEditIndexKey.Value))
                {
                    int _rowIndex = grdLicenceDetail.Rows.Count;
                    objLicenceDetail.AddObjectToTable((DataTable)Session[hfSessionDataKey.Value]);
                    ((DataTable)Session[hfSessionDataKey.Value]).Rows[_rowIndex]["LICENCE_TYPE"] = ddlLicence.SelectedItem.Text;
                }
                else
                {
                    int _rowIndex = Convert.ToInt32(hfEditIndexKey.Value);
                    objLicenceDetail.UpdateTableFromObject((DataTable)Session[hfSessionDataKey.Value], _rowIndex);
                    ((DataTable)Session[hfSessionDataKey.Value]).Rows[_rowIndex]["LICENCE_TYPE"] = ddlLicence.SelectedItem.Text;
                }

                UIUtility.DisplayMessage(lblMessage, CommonConstant.SUCCEED);
                InitializeUserControl(null, null, Convert.ToInt32(ViewState[strMemberType]));
                MultiViewLicenceDetail.ActiveViewIndex = 0;
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
            MultiViewLicenceDetail.ActiveViewIndex = 0;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void BindLicenceDetailControls()
    {
        if (!Convert.ToBoolean(hfIsControlsLoaded.Value))
        {
            UIController.BindMetadataDDL(ddlLicence, MetadataTypeEnum.LicenceType);
            hfIsControlsLoaded.Value = true.ToString();
        }
    }
    protected void ActivateControlsView(bool isNewRecord, int? editLicenceDetailIndex)
    {
        if (isNewRecord)
        {
            hfEditIndexKey.Value = string.Empty;
            BindLicenceDetailControls();
            UIUtility.InitializeControls(ViewLicenceDetailControls);
        }
        else
        {
            int _rowIndex = Convert.ToInt32(editLicenceDetailIndex);
            hfEditIndexKey.Value = _rowIndex.ToString();
            BindLicenceDetailControls();
            PopulateControlsData(_rowIndex);
        }
        MultiViewLicenceDetail.ActiveViewIndex = 1;
    }
    private void PopulateControlsData(int rowIndex)
    {
        objLicenceDetail = new LicenceDetail();
        objLicenceDetail.ConvertToObjectFromDataRow((DataTable)Session[hfSessionDataKey.Value], rowIndex);
        UIUtility.SelectCurrentListItem(ddlLicence, objLicenceDetail.LicenceTypeObject.MetadataId, BindListItem.ByValue, true);
        txtLicenceNumber.Text = objLicenceDetail.LicenceNumber.ToString();
        txtIssueDate.Text = objLicenceDetail.IssueDate.ToString();
        txtExpDate.Text = objLicenceDetail.ExpDate.ToString();
        txtComments.Text = objLicenceDetail.Comments;
    }
    #endregion

    #region Helper Functions
    private bool ValidateObject()
    {
        return true;
    }

    private LicenceDetail GetLicenceDetailForDataTable()
    {
        objLicenceDetail = new LicenceDetail();
        objLicenceDetail.MemberTypeObject = new MetadataMaster();
        objLicenceDetail.MemberTypeObject.MetadataId = Convert.ToInt32(ViewState[strMemberType]);

        if (ddlLicence.SelectedIndex != 0)
        {
            objLicenceDetail.LicenceTypeObject = new MetadataMaster();
            objLicenceDetail.LicenceTypeObject.MetadataId = Convert.ToInt32(ddlLicence.SelectedItem.Value);
        }
        objLicenceDetail.LicenceNumber = Convert.ToInt32(txtLicenceNumber.Text);
        objLicenceDetail.IssueDate = Convert.ToDateTime(txtIssueDate.Text);
        objLicenceDetail.ExpDate = Convert.ToDateTime(txtExpDate.Text);
        objLicenceDetail.Comments = txtComments.Text;
        return objLicenceDetail;
    }
    #endregion
}
