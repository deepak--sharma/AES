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

public partial class FeeScheduleDetailUC : System.Web.UI.UserControl
{
    #region Page Variables
    FeeScheduleDetail objFeeScheduleDetail = null;
    FeeScheduleDetailBL objFeeScheduleDetailBL = null;
    private const int FeeScheduleDetailId = 0;
    private const int Fee_Schedule_Id = 1;
    #endregion

    #region Page Events and Functions
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    public void InitializeUserControl(int? dataKey, int _instances, bool _isPostPayment)
    {
        objFeeScheduleDetailBL = new FeeScheduleDetailBL();
        objFeeScheduleDetail = new FeeScheduleDetail();
        objFeeScheduleDetail.FeeScheduleObject = new FeeSchedule();
        objFeeScheduleDetail.FeeScheduleObject.FeeScheduleId = dataKey;
        objFeeScheduleDetail.FeeScheduleObject.NoOfInstances = _instances;
        objFeeScheduleDetail.FeeScheduleObject.DataHolder = _isPostPayment.ToString();

        objFeeScheduleDetail = objFeeScheduleDetailBL.SelectFeeScheduleDetail(objFeeScheduleDetail);
        grdFeeScheduleDetail.DataSource = objFeeScheduleDetail.ObjectDataSet.Tables[0];
        grdFeeScheduleDetail.DataBind();
    }
    protected void grdFeeScheduleDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList ddlStartMonth = e.Row.FindControl("ddlStartMonth") as DropDownList;
            ddlStartMonth.SelectedValue = ((DataRowView)(e.Row.DataItem)).Row.ItemArray[3].ToString();

            DropDownList ddlEndMonth = e.Row.FindControl("ddlEndMonth") as DropDownList;
            ddlEndMonth.SelectedValue = ((DataRowView)(e.Row.DataItem)).Row.ItemArray[4].ToString();

            DropDownList ddlProcessMonth = e.Row.FindControl("ddlProcessMonth") as DropDownList;
            ddlProcessMonth.SelectedValue = ((DataRowView)(e.Row.DataItem)).Row.ItemArray[5].ToString();

            Label lblCollectionStartDate = e.Row.FindControl("lblCollectionStartDate") as Label;
            lblCollectionStartDate.Text = ddlProcessMonth.SelectedItem.Text;

            Label lblCollectionLastDate = e.Row.FindControl("lblCollectionLastDate") as Label;
            lblCollectionLastDate.Text = ddlProcessMonth.SelectedItem.Text;
        }
    }
    #endregion

    #region Helper Functions
    private bool ValidateObject()
    {
        return true;
    }

    public DataSet GetFeeScheduleDetailData(int? _feeScheduleId)
    {
        objFeeScheduleDetailBL = new FeeScheduleDetailBL();
        objFeeScheduleDetail = new FeeScheduleDetail();
        objFeeScheduleDetail.FeeScheduleObject = new FeeSchedule();
        objFeeScheduleDetail.FeeScheduleObject.FeeScheduleId = _feeScheduleId;
        objFeeScheduleDetail = objFeeScheduleDetailBL.SelectFeeScheduleDetailData(objFeeScheduleDetail);

        DataTable objFeeScheduleDetailTable = objFeeScheduleDetail.ObjectDataSet.Tables[0];
     
        foreach (GridViewRow objRow in grdFeeScheduleDetail.Rows)
        {
            DataRow objDataRow = objFeeScheduleDetailTable.NewRow();

            objDataRow["Fee_Schedule_Detail_Id"] = grdFeeScheduleDetail.DataKeys[Convert.ToInt32(objRow.RowIndex)].Values[FeeScheduleDetailId];
            objDataRow["S_No"] = Convert.ToInt32((objRow.FindControl("lblSNo") as Label).Text);
            objDataRow["Start_Month"] = Convert.ToInt32((objRow.FindControl("ddlStartMonth") as DropDownList).SelectedValue);
            objDataRow["End_Month"] = Convert.ToInt32((objRow.FindControl("ddlEndMonth") as DropDownList).SelectedValue);
            objDataRow["Fee_Process_Month"] = Convert.ToInt32((objRow.FindControl("ddlProcessMonth") as DropDownList).SelectedValue);
            objDataRow["Collection_Start_Date"] = Convert.ToInt32((objRow.FindControl("txtCollectionStartDate") as TextBox).Text);
            objDataRow["Collection_Last_Date"] = Convert.ToInt32((objRow.FindControl("txtCollectionLastDate") as TextBox).Text);
            objFeeScheduleDetailTable.Rows.Add(objDataRow);

        }

        return objFeeScheduleDetailTable.DataSet;
    }
    #endregion
}
