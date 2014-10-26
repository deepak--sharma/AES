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
using System.Collections.Generic;
using AES.SolutionFramework;
using AES.BusinessFramework;
using AES.ObjectFramework;

public partial class ReportingDetailUC : System.Web.UI.UserControl
{
    #region Page Variables
    ReportingDetail objReportingDetail = null;
    ReportingDetailBL objReportingDetailBL = null;
    #endregion

    #region Page Events and Grid Events
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    public void InitializeUserControl(int? dataKey)
    {
        objReportingDetailBL = new ReportingDetailBL();
        objReportingDetail = new ReportingDetail();
        objReportingDetail.EmployeeObject = new EmployeeDetail();
        objReportingDetail.EmployeeObject.EmployeeId = dataKey;

        objReportingDetail = objReportingDetailBL.SelectReportingDetail(objReportingDetail);
        Session[UserDataKeys.REPORTINGDETAIL_EMPLOYEEID] = objReportingDetail.ObjectDataSet.Tables[1];
        grdReportingDetail.DataSource = objReportingDetail.ObjectDataSet.Tables[0];
        grdReportingDetail.DataBind();
    }
    protected void grdReportingDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataTable objTable = Session[UserDataKeys.REPORTINGDETAIL_EMPLOYEEID] as DataTable;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList ddlSupervisor = e.Row.FindControl("ddlSupervisorDetail") as DropDownList;
            ddlSupervisor.DataSource = objTable;
            ddlSupervisor.DataBind();
            ddlSupervisor.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);
            ddlSupervisor.SelectedValue = ((DataRowView)(e.Row.DataItem)).Row.ItemArray[3].ToString();
        }
    }
    #endregion

    #region Helper Functions
    private bool ValidateObject()
    {
        return true;
    }

    public List<ReportingDetail> GetReportingDetailList(int _employeeId)
    {
        List<ReportingDetail> objReportingDetailList = new List<ReportingDetail>();
        foreach (GridViewRow ObjRow in grdReportingDetail.Rows)
        {
            objReportingDetail = new ReportingDetail();
            objReportingDetail.EmployeeObject = new EmployeeDetail();
            objReportingDetail.EmployeeObject.EmployeeId = _employeeId;
            objReportingDetail.SupervisorObject = new EmployeeDetail();
            if (((DropDownList)grdReportingDetail.Rows[ObjRow.RowIndex].FindControl("ddlSupervisorDetail")).SelectedIndex > 0)
            {
                objReportingDetail.SupervisorObject.EmployeeId = Convert.ToInt32(((DropDownList)grdReportingDetail.Rows[ObjRow.RowIndex].FindControl("ddlSupervisorDetail")).SelectedValue);
            }
            objReportingDetail.OtherDetail = ((TextBox)grdReportingDetail.Rows[ObjRow.RowIndex].FindControl("txtOtherDetail")).Text;
            objReportingDetail.IsPrimary = ((CheckBox)grdReportingDetail.Rows[ObjRow.RowIndex].FindControl("chkIsPrimary")).Checked;
            objReportingDetailList.Add(objReportingDetail);
        }
        return objReportingDetailList;
    }
    #endregion

}
