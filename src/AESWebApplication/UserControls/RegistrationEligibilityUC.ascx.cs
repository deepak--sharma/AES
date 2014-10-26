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

public partial class RegistrationEligibilityUC : System.Web.UI.UserControl
{
    #region Page Variables
    RegistrationEligibility objRegistrationEligibility = null;
    RegistrationEligibilityBL objRegistrationEligibilityBL = null;

    private const int Eligibility_Id_DataKey_INDEX = 0;

    private const int Id_INDEX = 2;
    private const int Min_Value_INDEX = 3;
    private const int Max_Value_INDEX = 4;
    private const int Description_INDEX = 5;
    #endregion

    #region Page Events and Functions
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    public void InitializeUserControl(int? dataKey, string strSessionDataKey)
    {
        objRegistrationEligibilityBL = new RegistrationEligibilityBL();
        objRegistrationEligibility = new RegistrationEligibility();
        objRegistrationEligibility.RegistrationObject = new RegistrationMaster();
        objRegistrationEligibility.RegistrationObject.RegistrationId = dataKey;
        objRegistrationEligibility.EligibilityObject = new MetadataMaster();
        objRegistrationEligibility.EligibilityObject.DataHolder = Convert.ToInt32(MetadataTypeEnum.EligiblityFactor).ToString();
        objRegistrationEligibility.RecordStatus = Convert.ToInt32(RecordStatus.Active);

        objRegistrationEligibility = objRegistrationEligibilityBL.GetRegistrationEligibility(objRegistrationEligibility);
        grdRegistrationEligibility.DataSource = objRegistrationEligibility.ObjectDataSet.Tables[0];
        grdRegistrationEligibility.DataBind();

    }
    #endregion

    #region Grid Events and Functions

    protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //Enable/Disable max value field
            Label lblEligibility = (Label)e.Row.FindControl("lblEligibility");
            if (lblEligibility != null && !string.IsNullOrEmpty(lblEligibility.Text))
            {                
                TextBox txtMaxValue = (TextBox)e.Row.FindControl("txtMaxValue");

                RegularExpressionValidator revMinValue = (RegularExpressionValidator)e.Row.FindControl("revMinValue");
                RegularExpressionValidator revMaxValue = (RegularExpressionValidator)e.Row.FindControl("revMaxValue");
                switch (lblEligibility.Text)
                {
                    case "Age":
                        lblEligibility.Text += "(In Years)";
                        break;
                    case "Nationality":
                    case "Income":
                        txtMaxValue.Enabled = false;
                        revMinValue.Enabled = false;
                        revMaxValue.Enabled = false;
                        break;

                    default:
                        txtMaxValue.Enabled = true;
                        break;
                }
            }

        }
    }

    #endregion
    
    #region Helper Functions
    private bool ValidateObject()
    {
        return true;
    }

    public DataSet GetRegistrationEligibilityForDataTable()
    {
        objRegistrationEligibilityBL = new RegistrationEligibilityBL();
        objRegistrationEligibility = new RegistrationEligibility();
        DataSet dsEligibilityDetail = objRegistrationEligibilityBL.GetRegistrationEligibilitySchema(objRegistrationEligibility).ObjectDataSet;

        GetEligibilityDetailFromGridToTable(grdRegistrationEligibility, dsEligibilityDetail.Tables[0]);

        return dsEligibilityDetail;
    }

    private DataTable GetEligibilityDetailFromGridToTable(GridView grd, DataTable dtEligibilityDetail)
    {
        DataRow drRow;
        foreach (GridViewRow gvRow in grd.Rows)
        {
            drRow = dtEligibilityDetail.NewRow();

            drRow[Id_INDEX] = Convert.ToInt32(grd.DataKeys[gvRow.RowIndex].Values[Eligibility_Id_DataKey_INDEX]);
            drRow[Min_Value_INDEX] = (gvRow.FindControl("txtMinValue") as TextBox).Text;
            drRow[Max_Value_INDEX] = (gvRow.FindControl("txtMaxValue") as TextBox).Text;
            drRow[Description_INDEX] = (gvRow.FindControl("txtDescription") as TextBox).Text;

            dtEligibilityDetail.Rows.Add(drRow);
        }
        return dtEligibilityDetail;
    }
    #endregion
}
