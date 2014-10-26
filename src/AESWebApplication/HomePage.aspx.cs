using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using AES.BusinessFramework;
using AES.ObjectFramework;

public partial class NewHomePage_HomePage : System.Web.UI.Page
{
    RegistrationMasterBL objRegistrationMasterBL = null;
    RegistrationMaster objRegistrationMaster = null;
    private int RegistrationId
    {
        get
        {
            return (int)ViewState["RegistrationId"];

        }
        set
        {
            ViewState["RegistrationId"] = value;

        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {
                LoadActiveRegistration();

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
    private void LoadActiveRegistration()
    {
        objRegistrationMaster = new RegistrationMaster();
        objRegistrationMasterBL = new RegistrationMasterBL();

        objRegistrationMaster = objRegistrationMasterBL.FetchActiveRegistration(objRegistrationMaster);
        if (objRegistrationMaster != null && objRegistrationMaster.ObjectDataSet != null &&
            objRegistrationMaster.ObjectDataSet.Tables != null &&
            objRegistrationMaster.ObjectDataSet.Tables.Count > 0)
        {
            dlActiveRegistration.DataSource = objRegistrationMaster.ObjectDataSet.Tables[0];
            dlActiveRegistration.DataBind();
        }


    }
    protected void lnkLogIn_Click(object sender, EventArgs e)
    {
        Session["LoggedInUser"] = 1;
        Response.Redirect("WelcomePage.aspx");
    }
}
