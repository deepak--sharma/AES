using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using AES.SolutionFramework;
using AES.BusinessFramework;
using AES.ObjectFramework;

/// <summary>
/// Summary description for BasePageUC
/// </summary>
public class BasePageUC : System.Web.UI.UserControl
{
    public BasePageUC()
    {
        //
        // TODO: Add constructor logic here
        //
        ValidationRequired = true;
    }

    public virtual bool ValidationRequired { get; set; }
}
