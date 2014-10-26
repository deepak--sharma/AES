using System;
using System.Data;
using System.Configuration;
//using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using AES.BusinessFramework;
using AES.ObjectFramework;
using AES.SolutionFramework;

public class BasePage : System.Web.UI.Page
{
    public BasePage()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    protected void Page_PreInit()
    {
        if (!Page.IsPostBack)
        {
            SetRedirect();
        }
    }

    private void SetRedirect()
    {
        if (string.IsNullOrEmpty(LoggedInUserId))
        {
            HyperLink hlnk;
            hlnk = (HyperLink)this.Master.FindControl("linkHome");
            if (hlnk != null)
            {
                hlnk.NavigateUrl = "~/HomePage.aspx";
            }

            hlnk = (HyperLink)this.Master.FindControl("linkSingOut");
            if (hlnk != null)
            {
                hlnk.Visible = false;
            }
        }
    }

    public string LoggedInUserId
    {
        get
        {
            return Convert.ToString(Session["LoggedInUser"]);
        }
    }
    public String LoggedInUser
    {
        get
        {
            //Following code need to be removed once this session is assigned value correctly.
            if (Session["LoggedUser"] == null)
            {
                Session["LoggedUser"] = "Admin";
            }
            //******************************************************************
            return Convert.ToString(Session["LoggedUser"]);
        }
        set
        {
            Session["LoggedUser"] = value;
        }
    }

    //To manage page default display mode
    public Boolean IsPageSplitModeOn
    {
        get
        {
            bool isPageSplitModeOn = false;

            if (Cache["PageSplitMode"] == null)
            {
                //Read from config
                Boolean.TryParse(ConfigurationManager.AppSettings["PageSplitMode"], out isPageSplitModeOn);

                Cache["PageSplitMode"] = isPageSplitModeOn;
            }
            //******************************************************************

            return isPageSplitModeOn;
        }
    }



}
