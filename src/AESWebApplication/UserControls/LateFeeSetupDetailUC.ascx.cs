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

public partial class LateFeeSetupDetailUC : System.Web.UI.UserControl
{
    #region Page Variables
    LateFeeSetupDetail objLateFeeSetupDetail = null;
    LateFeeSetupDetailBL objLateFeeSetupDetailBL = null;
    MetadataMaster objMetadataMaster = null;
    MetadataMasterBL objMetadataMasterBL = null;
    private string editIndexKey = "EditIndexLateFeeSetupDetailKey";
    #endregion

    #region Page Events and Control Functions
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    public void InitializeUserControl(int? dataKey)
    {
        objLateFeeSetupDetailBL = new LateFeeSetupDetailBL();
        objLateFeeSetupDetail = new LateFeeSetupDetail();
        objLateFeeSetupDetail.LateFeeSetupObject = new LateFeeSetup();
        objLateFeeSetupDetail.LateFeeSetupObject.LateFeeId = dataKey;

        objLateFeeSetupDetail = objLateFeeSetupDetailBL.SelectLateFeeSetupDetail(objLateFeeSetupDetail);
        grdLateFeeSetupDetail.DataSource = objLateFeeSetupDetail.ObjectDataSet.Tables[0];
        grdLateFeeSetupDetail.DataBind();
        Session[UserDataKeys.LATEFEEDETAIL_DATA] = objLateFeeSetupDetail.ObjectDataSet.Tables[0];

        if (grdLateFeeSetupDetail.Rows.Count == 0)
        {
            btnAddMore_Click(null, null);
        }

    }

    protected void btnAddMore_Click(object sender, EventArgs e)
    {
        DataTable objLateFeeTable = GetLateFeeDataTable();
        DataRow objRow = objLateFeeTable.NewRow();
        objRow["Amount"] = 0.00;
        objLateFeeTable.Rows.Add(objRow);

        grdLateFeeSetupDetail.DataSource = objLateFeeTable;
        grdLateFeeSetupDetail.DataBind();
        Session[UserDataKeys.LATEFEEDETAIL_DATA] = objLateFeeTable;
    }
    #endregion

    #region Grid Events and Functions

    protected void grdLateFeeSetupDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList ddlFreuency = e.Row.FindControl("ddlFrequency") as DropDownList;
            UIController.BindMetadataDDL(ddlFreuency, MetadataTypeEnum.LateFeeFrequency);
            ddlFreuency.SelectedValue = ((DataRowView)(e.Row.DataItem)).Row.ItemArray[5].ToString();
        }
    }
    protected void grdLateFeeSetupDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataTable objLateFeeTable = (DataTable)Session[UserDataKeys.LATEFEEDETAIL_DATA];
        objLateFeeTable.Rows[e.RowIndex].Delete();
        objLateFeeTable.AcceptChanges();

        grdLateFeeSetupDetail.DataSource = objLateFeeTable;
        grdLateFeeSetupDetail.DataBind();
    }
    #endregion


    #region Helper Functions
    private bool ValidateObject()
    {
        return true;
    }

    private DataTable GetLateFeeDataTable()
    {
        DataTable objTable = (DataTable)Session[UserDataKeys.LATEFEEDETAIL_DATA];
        objTable.Rows.Clear();
        objTable.AcceptChanges();

        DataRow objTableRow = null;

        foreach (GridViewRow objRow in grdLateFeeSetupDetail.Rows)
        {
            objTableRow = objTable.NewRow();
            //objTableRow["LATE_FEE_SETUP_DETAIL_ID"]=
            //    Convert.ToInt32(grdLateFeeSetupDetail.DataKeys[objRow.DataItemIndex].Values[0]);
            //objTableRow["LATE_FEE_SETUP_ID"] =
            //    Convert.ToInt32(grdLateFeeSetupDetail.DataKeys[objRow.DataItemIndex].Values[1].ToString());

            objTableRow["START_RANGE"] = Convert.ToInt32((objRow.FindControl("txtStartRange") as TextBox).Text);
            objTableRow["END_RANGE"] = Convert.ToInt32((objRow.FindControl("txtEndRange") as TextBox).Text);
            objTableRow["AMOUNT"] = (objRow.FindControl("txtAmount") as TextBox).Text;
            objTableRow["FREQUENCY_ID"] = (objRow.FindControl("ddlFrequency") as DropDownList).SelectedValue;

            objTable.Rows.Add(objTableRow);
        }

        return objTable;
    }

    public DataSet GetLateFeeDetailData()
    {
        DataTable objTable = GetLateFeeDataTable();
        return objTable.DataSet;
    }
    #endregion
}
