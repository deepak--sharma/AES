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
using AES.SolutionFramework;

public partial class UserControls_Calender : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public String Text
    {
        get
        {
            return txtDate.Text;
        }
        set
        {
            txtDate.Text = GeneralUtility.ToStandardDate(value);
        }
    }

    public String DateFormat
    {
        get
        {
            return ceDate.Format;
        }
        set
        {
            ceDate.Format = value;
        }
    }

    public Boolean EnableREValidator
    {
        get
        {
            return regexDate.Enabled;
        }
        set
        {
            regexDate.Enabled = value;
        }
    }

    public Boolean EnableRFValidator
    {
        get
        {
            return rfvDate.Enabled;
        }
        set
        {
            rfvDate.Enabled = value;
        }
    }

    public String REVMessage
    {
        get
        {
            return regexDate.ErrorMessage;
        }
        set
        {
            regexDate.ErrorMessage = value;
        }
    }

    public String RFVMessage
    {
        get
        {
            return rfvDate.ErrorMessage;
        }
        set
        {
            rfvDate.ErrorMessage = value;
        }
    }

    public Boolean ReadOnlyDateInputBox
    {
        get
        {
            return txtDate.ReadOnly;
        }
        set
        {
            txtDate.ReadOnly = value;
        }
    }
}
