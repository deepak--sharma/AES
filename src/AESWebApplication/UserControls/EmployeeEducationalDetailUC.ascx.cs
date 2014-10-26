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

public partial class EmployeeEducationalDetailUC : System.Web.UI.UserControl
{
    #region Page Variables
    EmployeeEducationalDetail objEmployeeEducationalDetail = null;
    EmployeeEducationalDetailBL objEmployeeEducationalDetailBL = null;
    ClassMaster objClassMaster = null;
    ClassMasterBL objClassMasterBL = null;
    StreamMaster objStreamMaster = null;
    StreamMasterBL objStreamMasterBL = null;
    private string editIndexKey = "EditIndexEmployeeEducationalDetailKey";
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
            objEmployeeEducationalDetailBL = new EmployeeEducationalDetailBL();
            objEmployeeEducationalDetail = new EmployeeEducationalDetail();
            objEmployeeEducationalDetail.EmployeeObject = new EmployeeDetail();
            objEmployeeEducationalDetail.EmployeeObject.EmployeeId = dataKey;

            objEmployeeEducationalDetail = objEmployeeEducationalDetailBL.SelectEmployeeEducationalDetail(objEmployeeEducationalDetail);
            grdEmployeeEducationalDetail.DataSource = objEmployeeEducationalDetail.ObjectDataSet.Tables[0];
            grdEmployeeEducationalDetail.DataBind();

            Session[hfSessionDataKey.Value] = objEmployeeEducationalDetail.ObjectDataSet.Tables[0];
            MultiViewEmployeeEducationalDetail.ActiveViewIndex = 0;

            if (grdEmployeeEducationalDetail.Rows.Count == 0)
            {
                hfEditIndexKey.Value = string.Empty;
                BindEmployeeEducationalDetailControls();
                UIUtility.InitializeControls(ViewEmployeeEducationalDetailControls);
                MultiViewEmployeeEducationalDetail.ActiveViewIndex = 1;
            }
        }
        else
        {
            grdEmployeeEducationalDetail.DataSource = (DataTable)Session[hfSessionDataKey.Value];
            grdEmployeeEducationalDetail.DataBind();
        }
    }
    #endregion

    #region Grid Events and Functions

    protected void grdEmployeeEducationalDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ActivateControlsView(false, grdEmployeeEducationalDetail.SelectedIndex);
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void grdEmployeeEducationalDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
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
    protected void grdEmployeeEducationalDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grdEmployeeEducationalDetail.PageIndex = e.NewPageIndex;
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
                objEmployeeEducationalDetail = GetEmployeeEducationalDetailForDataTable();
                if (string.IsNullOrEmpty(hfEditIndexKey.Value))
                {
                    int _rowIndex = grdEmployeeEducationalDetail.Rows.Count;
                    objEmployeeEducationalDetail.AddObjectToTable((DataTable)Session[hfSessionDataKey.Value]);
                    ((DataTable)Session[hfSessionDataKey.Value]).Rows[_rowIndex]["Class_Name"] = ddlClass.SelectedItem.Text;
                    ((DataTable)Session[hfSessionDataKey.Value]).Rows[_rowIndex]["STREAM_NAME"] = ddlStream.SelectedItem.Text;
                }
                else
                {
                    int _rowIndex = Convert.ToInt32(hfEditIndexKey.Value);
                    objEmployeeEducationalDetail.UpdateTableFromObject((DataTable)Session[hfSessionDataKey.Value], _rowIndex);
                    ((DataTable)Session[hfSessionDataKey.Value]).Rows[_rowIndex]["Class_Name"] = ddlClass.SelectedItem.Text;
                    ((DataTable)Session[hfSessionDataKey.Value]).Rows[_rowIndex]["STREAM_NAME"] = ddlStream.SelectedItem.Text;
                }

                UIUtility.DisplayMessage(lblMessage, CommonConstant.SUCCEED);
                InitializeUserControl(null, null);
                MultiViewEmployeeEducationalDetail.ActiveViewIndex = 0;
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
            MultiViewEmployeeEducationalDetail.ActiveViewIndex = 0;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void BindEmployeeEducationalDetailControls()
    {
        if (string.IsNullOrEmpty(hfIsControlsLoaded.Value) || !Convert.ToBoolean(hfIsControlsLoaded.Value))
        {
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

            hfIsControlsLoaded.Value = true.ToString();
        }
    }
    protected void ActivateControlsView(bool isNewRecord, int? editEmployeeEducationalDetailIndex)
    {
        if (isNewRecord)
        {
            hfEditIndexKey.Value = string.Empty;
            BindEmployeeEducationalDetailControls();
            UIUtility.InitializeControls(ViewEmployeeEducationalDetailControls);
        }
        else
        {
            int _rowIndex = Convert.ToInt32(editEmployeeEducationalDetailIndex);
            hfEditIndexKey.Value = _rowIndex.ToString();
            BindEmployeeEducationalDetailControls();
            PopulateControlsData(_rowIndex);
        }
        MultiViewEmployeeEducationalDetail.ActiveViewIndex = 1;
    }
    private void PopulateControlsData(int rowIndex)
    {
        objEmployeeEducationalDetail = new EmployeeEducationalDetail();
        objEmployeeEducationalDetail.ConvertToObjectFromDataRow((DataTable)Session[hfSessionDataKey.Value], rowIndex);
        UIUtility.SelectCurrentListItem(ddlClass, objEmployeeEducationalDetail.ClassObject.ClassId, BindListItem.ByValue, true);
        UIUtility.SelectCurrentListItem(ddlStream, objEmployeeEducationalDetail.StreamObject.StreamId, BindListItem.ByValue, true);
        txtPeriodFrom.Text = objEmployeeEducationalDetail.PeriodFrom.ToString();
        txtPeriodTo.Text = objEmployeeEducationalDetail.PeriodTo.ToString();
        txtMarksPercentage.Text = objEmployeeEducationalDetail.MarksPercentage.ToString();
        txtSchoolCollegeInstituteName.Text = objEmployeeEducationalDetail.SchoolCollegeInstituteName;
        txtAddress.Text = objEmployeeEducationalDetail.Address;
        txtBoardUniversityName.Text = objEmployeeEducationalDetail.BoardUniversityName;
        txtRemarks.Text = objEmployeeEducationalDetail.Remarks;
    }
    #endregion

    #region Helper Functions
    private bool ValidateObject()
    {
        return true;
    }
    private EmployeeEducationalDetail GetEmployeeEducationalDetailForDataTable()
    {
        objEmployeeEducationalDetail = new EmployeeEducationalDetail();
        if (ddlClass.SelectedIndex != 0)
        {
            objEmployeeEducationalDetail.ClassObject = new ClassMaster();
            objEmployeeEducationalDetail.ClassObject.ClassId = Convert.ToInt32(ddlClass.SelectedItem.Value);
        }
        if (ddlStream.SelectedIndex != 0)
        {
            objEmployeeEducationalDetail.StreamObject = new StreamMaster();
            objEmployeeEducationalDetail.StreamObject.StreamId = Convert.ToInt32(ddlStream.SelectedItem.Value);
        }
        objEmployeeEducationalDetail.PeriodFrom = Convert.ToDateTime(txtPeriodFrom.Text);
        objEmployeeEducationalDetail.PeriodTo = Convert.ToDateTime(txtPeriodTo.Text);
        objEmployeeEducationalDetail.MarksPercentage = Convert.ToDecimal(txtMarksPercentage.Text);
        objEmployeeEducationalDetail.SchoolCollegeInstituteName = txtSchoolCollegeInstituteName.Text;
        objEmployeeEducationalDetail.Address = txtAddress.Text;
        objEmployeeEducationalDetail.BoardUniversityName = txtBoardUniversityName.Text;
        objEmployeeEducationalDetail.Remarks = txtRemarks.Text;
        return objEmployeeEducationalDetail;
    }
    #endregion
}
