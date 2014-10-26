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

public partial class PreviousSchoolEducationMarksWizardUC : System.Web.UI.UserControl
{
    #region Page Variables
    PreviousSchoolEducationMarksDetail objPreviousSchoolEducationMarksDetail = null;
    PreviousSchoolEducationMarksDetailBL objPreviousSchoolEducationMarksDetailBL = null;
    #endregion

    #region Page Events and Functions
    public void InitializeControl()
    {
        if (!Convert.ToBoolean(hfIsControlsLoaded.Value))
        {
            objPreviousSchoolEducationMarksDetailBL = new PreviousSchoolEducationMarksDetailBL();
            objPreviousSchoolEducationMarksDetail = new PreviousSchoolEducationMarksDetail();

            objPreviousSchoolEducationMarksDetail = objPreviousSchoolEducationMarksDetailBL.SelectPreviousSchoolEducationMarksDetail(objPreviousSchoolEducationMarksDetail);
            grdPreviousSchoolEducationMarksDetail.DataSource = objPreviousSchoolEducationMarksDetail.ObjectDataSet.Tables[0];
            grdPreviousSchoolEducationMarksDetail.DataBind();

            hfIsControlsLoaded.Value = true.ToString();
        }
    }
    public string GetPreviousSchoolMarksString()
    {
        string strMarks = "";
        foreach (GridViewRow grdRow in grdPreviousSchoolEducationMarksDetail.Rows)
        {
            if (!string.IsNullOrEmpty(((TextBox)grdRow.FindControl("txtSubject")).Text.Trim())
                && !string.IsNullOrEmpty(((TextBox)grdRow.FindControl("txtMarks")).Text.Trim()))
            {
                strMarks += ((TextBox)grdRow.FindControl("txtSubject")).Text + ",";
                strMarks += ((TextBox)grdRow.FindControl("txtMarks")).Text + ",";
            }
        }

        return strMarks;
    }
    public void SetControlData(DataSet dsMarksDetail)
    {
        grdPreviousSchoolEducationMarksDetail.DataSource = dsMarksDetail;
        grdPreviousSchoolEducationMarksDetail.DataBind();
    }

    #endregion

}
