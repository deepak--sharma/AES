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

public partial class FeeSetupUC : System.Web.UI.UserControl
{
	#region Page Variables
	FeeSetup objFeeSetup = null;
	FeeSetupBL objFeeSetupBL = null;
	FeeMaster objFeeMaster = null;
	FeeMasterBL objFeeMasterBL = null;
    private const int FEE_ID_INDEX = 2;
	#endregion

	#region Page Events and Functions
	protected void Page_Load(object sender, EventArgs e)
	{
	}
	public void InitializeUserControl()
	{       
        objFeeSetup = new FeeSetup();
        BindFeeSetupGrids(objFeeSetup);
	}
	#endregion
    #region Grid Events and Functions
    protected void grdFeeSetup_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataTable objTable = objFeeSetup.ObjectDataSet.Tables[0];
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList ddlStartMonth = e.Row.FindControl("ddlStartMonth") as DropDownList;
            ddlStartMonth.SelectedValue = ((DataRowView)(e.Row.DataItem)).Row.ItemArray[3].ToString();
        }
    }
    #endregion
    #region Helper Functions
    public DataSet GetUserControlData()
    {
        DataTable tblFeeSetup = null;
        objFeeSetupBL = new FeeSetupBL();
        objFeeSetup = new FeeSetup();
        objFeeSetup = objFeeSetupBL.SelectFeeSetupSchema(objFeeSetup);
        tblFeeSetup = objFeeSetup.ObjectDataSet.Tables[0];       

        GetGridData(grdRegistrationFeeSetup, tblFeeSetup);
        GetGridData(grdAdmissionFeeSetup, tblFeeSetup);
        GetGridData(grdRegularOneTimeFeeSetup, tblFeeSetup);
        GetGridData(grdRegularYearlyFeeSetup, tblFeeSetup);
        GetGridData(grdRegularHalfYearlyFeeSetup, tblFeeSetup);
        GetGridData(grdRegularQuaterlyFeeSetup, tblFeeSetup);
        GetGridData(grdRegularBiMonthlyFeeSetup, tblFeeSetup);
        GetGridData(grdRegularMonthlyFeeSetup, tblFeeSetup);
        
        return tblFeeSetup.DataSet;
    }
    public void SetUserControlData(FeeStructureDetail objFeeStructureDetail)
    {        
        objFeeSetup = new FeeSetup();
        objFeeSetup.FeeStructureDetailObject = objFeeStructureDetail;
        BindFeeSetupGrids(objFeeSetup);
    }
    private void BindFeeSetupGrids(FeeSetup _objFeeSetup)
    {
        objFeeSetupBL = new FeeSetupBL();
        _objFeeSetup.FrequencyTypeId = Convert.ToInt32(MetadataTypeEnum.FeeFrequency);
        _objFeeSetup.RecordStatus = Convert.ToInt16(RecordStatus.Active);
        _objFeeSetup = objFeeSetupBL.SelectFeeSetup(_objFeeSetup);
        //Bind Registration Fee Grid
        DataView objRegistrationView = _objFeeSetup.ObjectDataSet.Tables[0].DefaultView;
        objRegistrationView.RowFilter = string.Format("FEE_GROUP_ID = {0}", (int)FeeGroup.RegistrationFee);
        fldRegistration.Visible = false;
        if (objRegistrationView.Count > 0)
        {
            fldRegistration.Visible = true;
            grdRegistrationFeeSetup.DataSource = objRegistrationView;
            grdRegistrationFeeSetup.DataBind();
        }
        //Bind Admission Fee Grid
        DataView objAdmissionView = _objFeeSetup.ObjectDataSet.Tables[0].DefaultView;
        objAdmissionView.RowFilter = string.Format("FEE_GROUP_ID = {0}", (int)FeeGroup.AdmissionFee);
        fldAdmission.Visible = false;
        if (objAdmissionView.Count > 0)
        {
            fldAdmission.Visible = true;
            grdAdmissionFeeSetup.DataSource = objAdmissionView;
            grdAdmissionFeeSetup.DataBind();
        }
        //Bind Regular Fee One Time Grid
        DataView objRegularFeeOneTimeView = _objFeeSetup.ObjectDataSet.Tables[0].DefaultView;
        objRegularFeeOneTimeView.RowFilter = string.Format("FEE_GROUP_ID = {0} AND FREQUENCY_ID = {1}", (int)FeeGroup.RegularFee,(int)FeeFrequency.OneTime);
        fldRegularOneTime.Visible = false;
        if (objRegularFeeOneTimeView.Count > 0)
        {
            fldRegularOneTime.Visible = true;
            grdRegularOneTimeFeeSetup.DataSource = objRegularFeeOneTimeView;
            grdRegularOneTimeFeeSetup.DataBind();
        }
        //Bind Regular Fee Yearly Grid
        DataView objRegularFeeYearlyView = _objFeeSetup.ObjectDataSet.Tables[0].DefaultView;
        objRegularFeeYearlyView.RowFilter = string.Format("FEE_GROUP_ID = {0} AND FREQUENCY_ID = {1}", (int)FeeGroup.RegularFee, (int)FeeFrequency.Yearly);
        fldRegularYearly.Visible = false;
        if (objRegularFeeYearlyView.Count > 0)
        {
            fldRegularYearly.Visible = true;
            grdRegularYearlyFeeSetup.DataSource = objRegularFeeYearlyView;
            grdRegularYearlyFeeSetup.DataBind();
        }
        //Bind Regular Fee Half Yearly Grid
        DataView objRegularFeeHalfYearlyView = _objFeeSetup.ObjectDataSet.Tables[0].DefaultView;
        objRegularFeeHalfYearlyView.RowFilter = string.Format("FEE_GROUP_ID = {0} AND FREQUENCY_ID = {1}", (int)FeeGroup.RegularFee, (int)FeeFrequency.HalfYearly);
        fldRegularHalfYearly.Visible = false;
        if (objRegularFeeHalfYearlyView.Count > 0)
        {
            fldRegularHalfYearly.Visible = true;
            grdRegularHalfYearlyFeeSetup.DataSource = objRegularFeeHalfYearlyView;
            grdRegularHalfYearlyFeeSetup.DataBind();
        }
        //Bind Regular Fee Quaterly Grid
        DataView objRegularFeeQuaterlyView = _objFeeSetup.ObjectDataSet.Tables[0].DefaultView;
        objRegularFeeQuaterlyView.RowFilter = string.Format("FEE_GROUP_ID = {0} AND FREQUENCY_ID = {1}", (int)FeeGroup.RegularFee, (int)FeeFrequency.Quaterly);
        fldRegularQuaterly.Visible = false;
        if (objRegularFeeQuaterlyView.Count > 0)
        {
            fldRegularQuaterly.Visible = true;
            grdRegularQuaterlyFeeSetup.DataSource = objRegularFeeQuaterlyView;
            grdRegularQuaterlyFeeSetup.DataBind();
        }
        //Bind Regular Fee BiMonthly Grid
        DataView objRegularFeeBiMonthlyView = _objFeeSetup.ObjectDataSet.Tables[0].DefaultView;
        objRegularFeeBiMonthlyView.RowFilter = string.Format("FEE_GROUP_ID = {0} AND FREQUENCY_ID = {1}", (int)FeeGroup.RegularFee, (int)FeeFrequency.BiMonthly);
        fldRegularBiMonthly.Visible = false;
        if (objRegularFeeBiMonthlyView.Count > 0)
        {
            fldRegularBiMonthly.Visible = true;
            grdRegularBiMonthlyFeeSetup.DataSource = objRegularFeeBiMonthlyView;
            grdRegularBiMonthlyFeeSetup.DataBind();
        }
        //Bind Regular Fee Monthly Grid
        DataView objRegularFeeMonthlyView = _objFeeSetup.ObjectDataSet.Tables[0].DefaultView;
        objRegularFeeMonthlyView.RowFilter = string.Format("FEE_GROUP_ID = {0} AND FREQUENCY_ID = {1}", (int)FeeGroup.RegularFee, (int)FeeFrequency.Monthly);
        fldRegularMonthly.Visible = false;
        if (objRegularFeeMonthlyView.Count > 0)
        {
            fldRegularMonthly.Visible = true;
            grdRegularMonthlyFeeSetup.DataSource = objRegularFeeMonthlyView;
            grdRegularMonthlyFeeSetup.DataBind();
        }
    }
    private void GetGridData(GridView grdFeeSetupGrid, DataTable _tblFeeSetup)
    {
        foreach (GridViewRow objGridRow in grdFeeSetupGrid.Rows)
        {
            DataRow objTableRow = _tblFeeSetup.NewRow();
            objTableRow["Fee_Id"] = grdFeeSetupGrid.DataKeys[objGridRow.RowIndex].Values[FEE_ID_INDEX].ToString();
            objTableRow["Fee_Amount"] = ((TextBox)objGridRow.FindControl("txtFeeAmount")).Text;
            objTableRow["Start_Month"] = Convert.ToInt32(((DropDownList)objGridRow.FindControl("ddlStartMonth")).SelectedValue);
            objTableRow["Is_Applicable"] = ((CheckBox)objGridRow.FindControl("chkIsApplicable")).Checked;
            _tblFeeSetup.Rows.Add(objTableRow);
        }
    }
    #endregion
}
