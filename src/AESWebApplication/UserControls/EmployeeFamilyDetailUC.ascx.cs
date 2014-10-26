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

public partial class EmployeeFamilyDetailUC : System.Web.UI.UserControl
{
    #region Page Variables
    EmployeeFamilyDetail objEmployeeFamilyDetail = null;
    EmployeeFamilyDetailBL objEmployeeFamilyDetailBL = null;
    MetadataMaster objMetadataMaster = null;
    MetadataMasterBL objMetadataMasterBL = null;
    private string editIndexKey = "EditIndexEmployeeFamilyDetailKey";
    #endregion

    #region Page Events and Functions
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    public void InitializeUserControl(int? dataKey, string strSessionDataKey)
    {
        if (!string.IsNullOrEmpty(strSessionDataKey))
        { hfSessionDataKey.Value = strSessionDataKey; }

        if (Session[hfSessionDataKey.Value] == null)
        {
            hfIsControlsLoaded.Value = false.ToString();
            objEmployeeFamilyDetailBL = new EmployeeFamilyDetailBL();
            objEmployeeFamilyDetail = new EmployeeFamilyDetail();
            objEmployeeFamilyDetail.EmployeeObject = new EmployeeDetail();
            objEmployeeFamilyDetail.EmployeeObject.EmployeeId = dataKey;
            objEmployeeFamilyDetail.GenderObject = new MetadataMaster();
            objEmployeeFamilyDetail.GenderObject.DataHolder = Convert.ToInt32(MetadataTypeEnum.Gender).ToString();
            objEmployeeFamilyDetail.RelationObject = new MetadataMaster();
            objEmployeeFamilyDetail.RelationObject.DataHolder = Convert.ToInt32(MetadataTypeEnum.Relation).ToString();
            objEmployeeFamilyDetail.NationalityObject = new MetadataMaster();
            objEmployeeFamilyDetail.NationalityObject.DataHolder = Convert.ToInt32(MetadataTypeEnum.Nationality).ToString();

            objEmployeeFamilyDetail = objEmployeeFamilyDetailBL.SelectEmployeeFamilyDetail(objEmployeeFamilyDetail);
            grdEmployeeFamilyDetail.DataSource = objEmployeeFamilyDetail.ObjectDataSet.Tables[0];
            grdEmployeeFamilyDetail.DataBind();

            Session[hfSessionDataKey.Value] = objEmployeeFamilyDetail.ObjectDataSet.Tables[0];
            MultiViewEmployeeFamilyDetail.ActiveViewIndex = 0;

            if (grdEmployeeFamilyDetail.Rows.Count == 0)
            {
                hfEditIndexKey.Value = string.Empty;
                BindEmployeeFamilyDetailControls();
                UIUtility.InitializeControls(ViewEmployeeFamilyDetailControls);
                MultiViewEmployeeFamilyDetail.ActiveViewIndex = 1;
            }
        }
        else
        {
            grdEmployeeFamilyDetail.DataSource = (DataTable)Session[hfSessionDataKey.Value];
            grdEmployeeFamilyDetail.DataBind();
        }
    }
    #endregion

    #region Grid Events and Functions

    protected void grdEmployeeFamilyDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ActivateControlsView(false, grdEmployeeFamilyDetail.SelectedIndex);
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void grdEmployeeFamilyDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            DataTable _objTable = (DataTable)Session[hfSessionDataKey.Value];
            _objTable.Rows[e.RowIndex].Delete();
            InitializeUserControl(null, string.Empty);
            UIUtility.DisplayMessage(lblMessage, CommonConstant.SUCCEED);
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void grdEmployeeFamilyDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grdEmployeeFamilyDetail.PageIndex = e.NewPageIndex;
            InitializeUserControl(null, string.Empty);
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
                objEmployeeFamilyDetail = GetEmployeeFamilyDetailForDataTable();
                if (string.IsNullOrEmpty(hfEditIndexKey.Value))
                {
                    int _rowIndex = grdEmployeeFamilyDetail.Rows.Count;
                    objEmployeeFamilyDetail.AddObjectToTable((DataTable)Session[hfSessionDataKey.Value]);
                    ((DataTable)Session[hfSessionDataKey.Value]).Rows[_rowIndex]["GENDER"] = ddlGender.SelectedItem.Text;
                    ((DataTable)Session[hfSessionDataKey.Value]).Rows[_rowIndex]["RELATION"] = ddlRelation.SelectedItem.Text;
                    ((DataTable)Session[hfSessionDataKey.Value]).Rows[_rowIndex]["NATIONALITY"] = ddlNationality.SelectedItem.Text;
                }
                else
                {
                    int _rowIndex = Convert.ToInt32(hfEditIndexKey.Value);
                    objEmployeeFamilyDetail.UpdateTableFromObject((DataTable)Session[hfSessionDataKey.Value], _rowIndex);
                    ((DataTable)Session[hfSessionDataKey.Value]).Rows[_rowIndex]["GENDER"] = ddlGender.SelectedItem.Text;
                    ((DataTable)Session[hfSessionDataKey.Value]).Rows[_rowIndex]["RELATION"] = ddlRelation.SelectedItem.Text;
                    ((DataTable)Session[hfSessionDataKey.Value]).Rows[_rowIndex]["NATIONALITY"] = ddlNationality.SelectedItem.Text;
                }

                UIUtility.DisplayMessage(lblMessage, CommonConstant.SUCCEED);
                InitializeUserControl(null, null);
                MultiViewEmployeeFamilyDetail.ActiveViewIndex = 0;
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
            MultiViewEmployeeFamilyDetail.ActiveViewIndex = 0;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void BindEmployeeFamilyDetailControls()
    {
        if (!Convert.ToBoolean(hfIsControlsLoaded.Value))
        {
            UIController.BindMetadataDDL(ddlGender, MetadataTypeEnum.Gender);
            UIController.BindMetadataDDL(ddlRelation, MetadataTypeEnum.Relation);
            UIController.BindMetadataDDL(ddlNationality, MetadataTypeEnum.Nationality);
            hfIsControlsLoaded.Value = true.ToString();
        }
    }
    protected void ActivateControlsView(bool isNewRecord, int? editEmployeeFamilyDetailIndex)
    {
        if (isNewRecord)
        {
            hfEditIndexKey.Value = string.Empty;
            BindEmployeeFamilyDetailControls();
            UIUtility.InitializeControls(ViewEmployeeFamilyDetailControls);
        }
        else
        {
            int _rowIndex = Convert.ToInt32(editEmployeeFamilyDetailIndex);
            hfEditIndexKey.Value = _rowIndex.ToString();
            BindEmployeeFamilyDetailControls();
            PopulateControlsData(_rowIndex);
        }
        MultiViewEmployeeFamilyDetail.ActiveViewIndex = 1;
    }
    private void PopulateControlsData(int rowIndex)
    {
        objEmployeeFamilyDetail = new EmployeeFamilyDetail();
        objEmployeeFamilyDetail.ConvertToObjectFromDataRow((DataTable)Session[hfSessionDataKey.Value], rowIndex);
        txtFirstName.Text = objEmployeeFamilyDetail.FirstName;
        UIUtility.SelectCurrentListItem(ddlGender, objEmployeeFamilyDetail.GenderObject.MetadataId, BindListItem.ByValue, true);
        UIUtility.SelectCurrentListItem(ddlRelation, objEmployeeFamilyDetail.RelationObject.MetadataId, BindListItem.ByValue, true);
        txtDateOfBirth.Text = objEmployeeFamilyDetail.DateOfBirth.ToString();
        UIUtility.SelectCurrentListItem(ddlNationality, objEmployeeFamilyDetail.NationalityObject.MetadataId, BindListItem.ByValue, true);
        chkIsDependent.Checked = Convert.ToBoolean(objEmployeeFamilyDetail.IsDependent);
    }
    #endregion

    #region Helper Functions
    private bool ValidateObject()
    {
        return true;
    }

    private EmployeeFamilyDetail GetEmployeeFamilyDetailForDataTable()
    {
        objEmployeeFamilyDetail = new EmployeeFamilyDetail();
        objEmployeeFamilyDetail.FirstName = txtFirstName.Text;
        objEmployeeFamilyDetail.MiddleName = "";
        objEmployeeFamilyDetail.LastName = "";
        if (ddlGender.SelectedIndex != 0)
        {
            objEmployeeFamilyDetail.GenderObject = new MetadataMaster();
            objEmployeeFamilyDetail.GenderObject.MetadataId = Convert.ToInt32(ddlGender.SelectedItem.Value);
           
        }
        if (ddlRelation.SelectedIndex != 0)
        {
            objEmployeeFamilyDetail.RelationObject = new MetadataMaster();
            objEmployeeFamilyDetail.RelationObject.MetadataId = Convert.ToInt32(ddlRelation.SelectedItem.Value);
          
        }
        objEmployeeFamilyDetail.DateOfBirth = Convert.ToDateTime(txtDateOfBirth.Text);
        if (ddlNationality.SelectedIndex != 0)
        {
            objEmployeeFamilyDetail.NationalityObject = new MetadataMaster();
            objEmployeeFamilyDetail.NationalityObject.MetadataId = Convert.ToInt32(ddlNationality.SelectedItem.Value);
           
        }
        objEmployeeFamilyDetail.IsDependent = chkIsDependent.Checked;
        return objEmployeeFamilyDetail;
    }
    #endregion
}
