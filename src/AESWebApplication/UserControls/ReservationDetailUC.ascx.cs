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

public partial class ReservationDetailUC : System.Web.UI.UserControl
{
    #region Page Variables
    ReservationDetail objReservationDetail = null;
    ReservationDetailBL objReservationDetailBL = null;

    private const int Reservation_Type_Id_DataKey_INDEX = 0;
    private const int Reservation_Criteria_Id_DataKey_INDEX = 1;
    private const int Reservation_Sub_Criteria_Id_DataKey_INDEX = 2;

    private const int Reservation_Type_Id_INDEX = 2;
    private const int Reservation_Criteria_Id_INDEX = 3;
    private const int Reservation_Sub_Criteria_Id_INDEX = 4;
    private const int Value_INDEX = 5;
    private const int Is_Percent_INDEX = 6;
    #endregion

    #region Page Events and Functions
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    public void InitializeUserControl(int? dataKey, string strSessionDataKey)
    {
        objReservationDetailBL = new ReservationDetailBL();
        objReservationDetail = new ReservationDetail();
        objReservationDetail.RegistrationObject = new RegistrationMaster();
        objReservationDetail.RegistrationObject.RegistrationId = dataKey;

        string strReservationCriteria = string.Format("{0},{1},{2}",
                                        Convert.ToInt32(ReservationCriteria.CasteCategory),
                                        Convert.ToInt32(ReservationCriteria.Gender),
                                        Convert.ToInt32(ReservationCriteria.OtherCriteria));
        objReservationDetail.DataHolder = strReservationCriteria;

        objReservationDetail.FreeSeatId = Convert.ToInt32(ReservationType.FreeSeat);
        objReservationDetail.ManagementSeatId = Convert.ToInt32(ReservationType.ManagementSeat);
        objReservationDetail.RecordStatus = Convert.ToInt32(RecordStatus.Active);

        objReservationDetail = objReservationDetailBL.GetReservationDetail(objReservationDetail);

        grdFreeSeatReservationDetail.DataSource = objReservationDetail.ObjectDataSet.Tables[0];
        grdFreeSeatReservationDetail.DataBind();

        grdManagementSeatReservationDetail.DataSource = objReservationDetail.ObjectDataSet.Tables[1];
        grdManagementSeatReservationDetail.DataBind();

    }
    #endregion

    #region Grid Events and Functions

    protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ClearReservationCriteriaText(e.Row);

            DropDownList ddlIsPercent = e.Row.FindControl("ddlIsPercent") as DropDownList;
            if (ddlIsPercent != null)
            {
                ddlIsPercent.SelectedValue = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "IS_PERCENT")).ToString();
            }
        }
    }

    #endregion

    #region Helper Functions
    public DataSet GetReservationDetailForDataTable()
    {
        objReservationDetailBL = new ReservationDetailBL();
        objReservationDetail = new ReservationDetail();
        DataSet dsReservationDetail = objReservationDetailBL.GetReservationDetailSchema(objReservationDetail).ObjectDataSet;

        GetReservationDetailFromGridToTable(grdFreeSeatReservationDetail, dsReservationDetail.Tables[0]);
        GetReservationDetailFromGridToTable(grdManagementSeatReservationDetail, dsReservationDetail.Tables[0]);
       
        return dsReservationDetail;
    }

    private DataTable GetReservationDetailFromGridToTable(GridView grd, DataTable dtReservationDetail)
    {
        DataRow drRow;
        foreach (GridViewRow gvRow in grd.Rows)
        {
            drRow = dtReservationDetail.NewRow();

            drRow[Reservation_Type_Id_INDEX] = Convert.ToInt32(grd.DataKeys[gvRow.RowIndex].Values[Reservation_Type_Id_DataKey_INDEX]);
            drRow[Reservation_Criteria_Id_INDEX] = Convert.ToInt32(grd.DataKeys[gvRow.RowIndex].Values[Reservation_Criteria_Id_DataKey_INDEX]);
            drRow[Reservation_Sub_Criteria_Id_INDEX] = Convert.ToInt32(grd.DataKeys[gvRow.RowIndex].Values[Reservation_Sub_Criteria_Id_DataKey_INDEX]);
            drRow[Value_INDEX] = Convert.ToDecimal((gvRow.FindControl("txtValue") as TextBox).Text);
            drRow[Is_Percent_INDEX] = Convert.ToBoolean(Convert.ToInt32((gvRow.FindControl("ddlIsPercent") as DropDownList).SelectedValue));

            dtReservationDetail.Rows.Add(drRow);
        }
        return dtReservationDetail;
    }
    
    private void ClearReservationCriteriaText(GridViewRow gvRow)
    {
        Label lblReservationCriteria = gvRow.FindControl("lblReservationCriteria") as Label;
        string currentRowReservationCriteria = lblReservationCriteria.Text;

        if (currentRowReservationCriteria == PreviousReservationCriteriaText)
        {
            //Empty label
            lblReservationCriteria.Text = string.Empty;
        }
        else
        {
            PreviousReservationCriteriaText = currentRowReservationCriteria;
        }
    }
    
    private string PreviousReservationCriteriaText
    {
        get
        {
            return Convert.ToString(ViewState["ReservationCriteria"]);
        }
        set
        {
            ViewState["ReservationCriteria"] = value;
        }
    }
    #endregion

   
}
