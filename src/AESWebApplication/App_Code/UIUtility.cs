using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using AES.BusinessFramework;
using AES.ObjectFramework;
using AES.SolutionFramework;
using System.Collections.Generic;
using System.Web.Caching;

public enum MessageType
{
    Info=0,
    Error=1,
    Warning=2
}
public class UIUtility
{
    public const string ERROR_MESSAGE_FILENAME = "ERRORMESSAGE";
    public const string CONFIRMATION_MESSAGE_FOR_DELETE = "CONFIRMATION_MESSAGE_FOR_DELETE";

    public const string RECORD_STATUS_CHANGED = "RECORD_STATUS_CHANGED";
    public const string RECORD_STATUS_NOT_CHANGED = "RECORD_STATUS_NOT_CHANGED";

    public const string CREATE_SUCCEED = "CREATE_SUCCEED";
    public const string UPDATE_SUCCEED = "UPDATE_SUCCEED";
    public const string DELETE_SUCCEED = "DELETE_SUCCEED";

    public const string CREATE_FAIL = "CREATE_FAIL";
    public const string UPDATE_FAIL = "UPDATE_FAIL";
    public const string DELETE_FAIL = "DELETE_FAIL";

    public const string UPDATE_INVALID = "UPDATE_INVALID";
    public const string DELETE_INVALID = "DELETE_INVALID";

    public const string CREATE_DUPLICATE = "CREATE_DUPLICATE";
    public const string UPDATE_DUPLICATE = "UPDATE_DUPLICATE";

    public const string PAGE_ERROR = "PAGE_ERROR";
    public const string DEFAULT_DDL_VALUE = "-Select-";
    public const int DEFAULT_ID = -77;

    public const string CACHE_EXPIRATION_TIME = "CacheExpirationTime";

    public UIUtility()
    {
       
    }

    public static void MakeReadOnly(Control objcontrol)
    {
        foreach (Control control in objcontrol.Controls)
        {
            if ((control.GetType() == typeof(TextBox)))
            {
                ((TextBox)control).ReadOnly = true;
            }

            if ((control.GetType() == typeof(DropDownList)))
            {
                ((DropDownList)control).Enabled = false;
            }

            if (control.HasControls())
            {
                MakeReadOnly(control);
            }
        }
    }

    public static void EmptyTextBoxes(Control objcontrol)
    {
        // Loop through all the controls on the page
        foreach (Control control in objcontrol.Controls)
        {
            // Check and see if it's a textbox
            if ((control.GetType() == typeof(TextBox)))
            {
                // Since its a textbox clear out the text    
                ((TextBox)(control)).Text = "";
            }
            // Now we need to call itself (recursive) because
            // all items (Panel, GroupBox, etc) is a container
            // so we need to check all containers for any
            // textboxes so we can clear them
            if (control.HasControls())
            {
                EmptyTextBoxes(control);
            }
        }
    }

    public static void InitializeControls(Control objcontrol)
    {
        foreach (Control control in objcontrol.Controls)
        {
            if ((control.GetType() == typeof(TextBox)))
            {
                ((TextBox)(control)).Text = "";
            }
            if ((control.GetType() == typeof(DropDownList)))
            {
                if (((DropDownList)(control)).Items.Count > 0)
                {
                    ((DropDownList)(control)).ClearSelection();
                    ((DropDownList)(control)).SelectedIndex = 0;
                }
            }
            if ((control.GetType() == typeof(CheckBox)))
            {
                ((CheckBox)(control)).Checked = false;
            }

            if (control.HasControls() && control.GetType() != typeof(MultiView))
            {
                InitializeControls(control);
            }
        }
    }

    public static void SelectCurrentListItem(DropDownList objDropDown, object currentValue, BindListItem bindType, bool setToZeroIndex)
    {
        if (currentValue != null)
        {
            if (bindType == BindListItem.ByValue)
            {
                objDropDown.ClearSelection();
                objDropDown.Items.FindByValue(currentValue.ToString()).Selected = true;
            }
            else
            {
                objDropDown.ClearSelection();
                objDropDown.Items.FindByText(currentValue.ToString()).Selected = true;
            }
        }
        else
        {
            if (setToZeroIndex)
            {
                objDropDown.ClearSelection();
                objDropDown.SelectedIndex = 0;
            }
        }
    }

    public static void DisplayMessage(Label objLabel, int? displayMode)
    {
        switch (displayMode)
        {
            case CommonConstant.SUCCEED:
                objLabel.Text = "Operation performed successfully";
                break;
            case CommonConstant.FAIL:
                objLabel.Text = "An error has occurred while perforing operation. please contact system administrator";
                break;
            case CommonConstant.INVALID:
                objLabel.Text = "The underlying record has already been changed, current operation has been aborted ";
                break;
            case CommonConstant.DUPLICATE:
                objLabel.Text = "The record already exist, current operation has been aborted ";
                break;
        }
    }
    public static void DisplayMessage(Label objLabel, string strMessage, MessageType objMessageType)
    {
        objLabel.Text = strMessage;
    }


    #region "Caching static Functions"

    /// <summary>
    /// Caches the expiration time.
    /// </summary>
    /// <returns></returns>
    private static int CacheExpirationTime()
    {

        return Convert.ToInt32(ConfigurationManager.AppSettings[CACHE_EXPIRATION_TIME].ToString());

    }

    /// <summary>
    /// Adds to cache.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="value">The value.</param>
    public static void AddToCache(string key, object value)
    {
        HttpContext context = HttpContext.Current;

        //Use insert method in stead of add method to avoid duplicate check
        context.Cache.Insert(key, value, null, Cache.NoAbsoluteExpiration, new TimeSpan(0, CacheExpirationTime(), 0));
    }

    /// <summary>
    /// Reads from cache.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <returns></returns>
    public static object ReadFromCache(string key)
    {

        HttpContext context = HttpContext.Current;

        //'Check if the key exists, if yes return the value, otherwise return null.
        if (context.Cache.Get(key) != null)
        {
            return context.Cache.Get(key);
        }

        return null;
    }

    #endregion

    public static void EnableDisableRequiredFieldValidator(Control objcontrol, bool status)
    {
        foreach (Control control in objcontrol.Controls)
        {
            if ((control.GetType() == typeof(RequiredFieldValidator)))
            {
                ((RequiredFieldValidator)control).Enabled = status;
            }

            if (control.HasControls())
            {
                EnableDisableRequiredFieldValidator(control, status);
            }
        }
    }
	#region XML Menu File Bind
    public static void BindMenuItem(Menu objMenu, string xmlPath)
    {
        objMenu.Items.Clear();
        DataSet objDataSet = new DataSet();
        objDataSet.ReadXml(xmlPath);

        foreach (DataRow objRow in objDataSet.Tables[0].Rows)
        {
            MenuItem objItem = new MenuItem();
            objItem.ImageUrl = objRow["ImageUrl"].ToString();
            objItem.Text = objRow["Name"].ToString();
            objItem.NavigateUrl = objRow["Url"].ToString();
            //objItem.SeparatorImageUrl = "~/Images/dot_line.jpg";
            objMenu.Items.Add(objItem);
        }
    }
    #endregion
}

