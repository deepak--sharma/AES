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

public partial class EmployeeJoiningDetailUC : System.Web.UI.UserControl
{
    #region Page Variables
    EmployeeJoiningDetail objEmployeeJoiningDetail = null;
    EmployeeJoiningDetailBL objEmployeeJoiningDetailBL = null;
    JoiningMaster objJoiningMaster = null;
    JoiningMasterBL objJoiningMasterBL = null;
    private string editIndexKey = "EditIndexEmployeeJoiningDetailKey";
    #endregion

    #region Page Events and Functions
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    public void InitializeUserControl(int? dataKey)
    {
        objEmployeeJoiningDetailBL = new EmployeeJoiningDetailBL();
        objEmployeeJoiningDetail = new EmployeeJoiningDetail();
        objEmployeeJoiningDetail.EmployeeObject = new EmployeeDetail();
        objEmployeeJoiningDetail.EmployeeObject.EmployeeId = dataKey;

        objEmployeeJoiningDetail = objEmployeeJoiningDetailBL.SelectEmployeeJoiningDetail(objEmployeeJoiningDetail);
        grdEmployeeJoiningDetail.DataSource = objEmployeeJoiningDetail.ObjectDataSet.Tables[0];
        grdEmployeeJoiningDetail.DataBind();
    }
    #endregion

    #region Helper Functions
    private bool ValidateObject()
    {
        return true;
    }

    public List<EmployeeJoiningDetail> GetEmployeeJoiningDetailList(int _employeeId)
    {
        List<EmployeeJoiningDetail> objEmployeeJoiningDetailList = new List<EmployeeJoiningDetail>();
        foreach (GridViewRow ObjRow in grdEmployeeJoiningDetail.Rows)
        {
            objEmployeeJoiningDetail = new EmployeeJoiningDetail();

            objEmployeeJoiningDetail.EmployeeObject = new EmployeeDetail();
            objEmployeeJoiningDetail.EmployeeObject.EmployeeId = _employeeId;
            objEmployeeJoiningDetail.JoiningObject = new JoiningMaster();
            objEmployeeJoiningDetail.JoiningObject.JoiningId = Convert.ToInt32(grdEmployeeJoiningDetail.DataKeys[Convert.ToInt32(ObjRow.RowIndex)].Values[1].ToString());
            objEmployeeJoiningDetail.Description = ((TextBox)grdEmployeeJoiningDetail.Rows[ObjRow.RowIndex].FindControl("txtDescription")).Text;

            objEmployeeJoiningDetailList.Add(objEmployeeJoiningDetail);
        }
        return objEmployeeJoiningDetailList;
    }
    #endregion
}
