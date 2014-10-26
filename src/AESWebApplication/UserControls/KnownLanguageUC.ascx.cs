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

public partial class KnownLanguageUC : System.Web.UI.UserControl
{
    #region Page Variables
    KnownLanguage objKnownLanguage = null;
    KnownLanguageBL objKnownLanguageBL = null;
    MetadataMaster objMetadataMaster = null;
    MetadataMasterBL objMetadataMasterBL = null;
    string strMemberType = "MemberType";

    private string editIndexKey = "EditIndexKnownLanguageKey";
    #endregion

    #region Page Events and Functions
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    public void InitializeUserControl(int? dataKey, MemberType? objMemberType, MetadataTypeEnum objMetadataType)
    {
        if (objMemberType != null)
        {
            ViewState[strMemberType] = Convert.ToInt32(objMemberType);
        }
        objKnownLanguageBL = new KnownLanguageBL();
        objKnownLanguage = new KnownLanguage();
        objKnownLanguage.MemberId = Convert.ToInt32(dataKey);
        objKnownLanguage.MemberTypeObject = new MetadataMaster();
        objKnownLanguage.MemberTypeObject.MetadataId = Convert.ToInt32(ViewState[strMemberType]);
        objKnownLanguage.DataHolder = Convert.ToInt32(objMetadataType).ToString();

        objKnownLanguage = objKnownLanguageBL.SelectKnownLanguage(objKnownLanguage);
        grdKnownLanguage.DataSource = objKnownLanguage.ObjectDataSet.Tables[0];
        grdKnownLanguage.DataBind();
    }
    #endregion     

    #region Helper Functions
    private bool ValidateObject()
    {
        return true;
    }

    public List<KnownLanguage> GetKnownLanguageColection(int _MemberId, int _memberTypeId)
    {
        List<KnownLanguage> objKnownLanguageList = new List<KnownLanguage>();
        foreach (GridViewRow ObjRow in grdKnownLanguage.Rows)
        {
            objKnownLanguage = new KnownLanguage();
            objKnownLanguage.MemberId = _MemberId;
            objKnownLanguage.MemberTypeObject = new MetadataMaster();
            objKnownLanguage.MemberTypeObject.MetadataId = _memberTypeId;
            objKnownLanguage.LanguageObject = new MetadataMaster();
            objKnownLanguage.LanguageObject.MetadataId = Convert.ToInt32(grdKnownLanguage.DataKeys[Convert.ToInt32(ObjRow.RowIndex)].Values[0].ToString());
            objKnownLanguage.CanRead = ((CheckBox)grdKnownLanguage.Rows[ObjRow.RowIndex].FindControl("chkCanRead")).Checked;
            objKnownLanguage.CanWrite = ((CheckBox)grdKnownLanguage.Rows[ObjRow.RowIndex].FindControl("chkCanWrite")).Checked;
            objKnownLanguage.CanSpeak = ((CheckBox)grdKnownLanguage.Rows[ObjRow.RowIndex].FindControl("chkCanSpeak")).Checked;
            objKnownLanguageList.Add(objKnownLanguage);
        }
        return objKnownLanguageList;
    }
    #endregion
}
