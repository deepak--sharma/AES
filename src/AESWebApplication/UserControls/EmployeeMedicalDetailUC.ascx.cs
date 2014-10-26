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

public partial class EmployeeMedicalDetailUC : System.Web.UI.UserControl
{
    #region Page Variables
    EmployeeMedicalDetail objEmployeeMedicalDetail = null;
    EmployeeMedicalDetailBL objEmployeeMedicalDetailBL = null;
    MedicalMaster objMedicalMaster = null;
    MedicalMasterBL objMedicalMasterBL = null;
    private string editIndexKey = "EditIndexEmployeeMedicalDetailKey";
    #endregion

    #region Page Events and Functions
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    public void InitializeUserControl(int? dataKey)
    {
        objEmployeeMedicalDetailBL = new EmployeeMedicalDetailBL();
        objEmployeeMedicalDetail = new EmployeeMedicalDetail();
        objEmployeeMedicalDetail.EmployeeObject = new EmployeeDetail();
        objEmployeeMedicalDetail.EmployeeObject.EmployeeId = dataKey;

        objEmployeeMedicalDetail = objEmployeeMedicalDetailBL.SelectEmployeeMedicalDetail(objEmployeeMedicalDetail);
        grdEmployeeMedicalDetail.DataSource = objEmployeeMedicalDetail.ObjectDataSet.Tables[0];
        grdEmployeeMedicalDetail.DataBind();
    }
    #endregion

    #region Helper Functions
    private bool ValidateObject()
    {
        return true;
    }

    public List<EmployeeMedicalDetail> GetEmployeeMedicalDetailList(int _employeeId)
    {
       List<EmployeeMedicalDetail> objEmployeeMedicalDetailList = new List<EmployeeMedicalDetail>();
        foreach (GridViewRow ObjRow in grdEmployeeMedicalDetail.Rows)
        {
            objEmployeeMedicalDetail = new EmployeeMedicalDetail();

            objEmployeeMedicalDetail.EmployeeObject = new EmployeeDetail();
            objEmployeeMedicalDetail.EmployeeObject.EmployeeId = _employeeId;
            objEmployeeMedicalDetail.MedicalObject = new MedicalMaster();
            objEmployeeMedicalDetail.MedicalObject.MedicalId = Convert.ToInt32(grdEmployeeMedicalDetail.DataKeys[Convert.ToInt32(ObjRow.RowIndex)].Values[1].ToString());
            objEmployeeMedicalDetail.Description = ((TextBox)grdEmployeeMedicalDetail.Rows[ObjRow.RowIndex].FindControl("txtDescription")).Text;

            objEmployeeMedicalDetailList.Add(objEmployeeMedicalDetail);
        }
        return objEmployeeMedicalDetailList;
    }
    #endregion
}
