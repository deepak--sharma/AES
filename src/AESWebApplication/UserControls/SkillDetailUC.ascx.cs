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
using System.Collections.Generic;

public partial class SkillDetailUC : System.Web.UI.UserControl
{
    #region Page Variables
    SkillDetail objSkillDetail = null;
    SkillDetailBL objSkillDetailBL = null;
    MetadataMaster objMetadataMaster = null;
    MetadataMasterBL objMetadataMasterBL = null;
    SkillMaster objSkillMaster = null;
    SkillMasterBL objSkillMasterBL = null;
    private string editIndexKey = "EditIndexSkillDetailKey";
    string strMemberType = "MemberType";
    #endregion

    #region Page Events and Functions
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    public void InitializeUserControl(int? dataKey, MemberType? objMemberType)
    {
        if (objMemberType != null)
        {
            ViewState[strMemberType] = Convert.ToInt32(objMemberType);
        }
        objSkillDetailBL = new SkillDetailBL();
        objSkillDetail = new SkillDetail();
        objSkillDetail.MemberId = Convert.ToInt32(dataKey);
        objSkillDetail.MemberTypeObject = new MetadataMaster();
        objSkillDetail.MemberTypeObject.MetadataId = Convert.ToInt32(ViewState[strMemberType]);

        objSkillDetail = objSkillDetailBL.SelectSkillDetail(objSkillDetail);
        grdSkillDetail.DataSource = objSkillDetail.ObjectDataSet.Tables[0];
        grdSkillDetail.DataBind();

    }
    #endregion

    #region Helper Functions
    private bool ValidateObject()
    {
        return true;
    }

    public List<SkillDetail> GetSkillDetailColection(int _MemberId,int _memberTypeId)
    {
        List<SkillDetail> objSkillDetailList = new List<SkillDetail>();
        foreach (GridViewRow ObjRow in grdSkillDetail.Rows)
        {
            objSkillDetail = new SkillDetail();
            objSkillDetail.SkillObject = new SkillMaster();
            objSkillDetail.SkillObject.SkillId = Convert.ToInt32(grdSkillDetail.DataKeys[Convert.ToInt32(ObjRow.RowIndex)].Values[0].ToString());
            objSkillDetail.MemberId = _MemberId;
            objSkillDetail.MemberTypeObject = new MetadataMaster();
            objSkillDetail.MemberTypeObject.MetadataId = _memberTypeId;
            objSkillDetail.Yearofexp = Convert.ToDecimal(((TextBox)grdSkillDetail.Rows[ObjRow.RowIndex].FindControl("txtYearofexp")).Text);
            objSkillDetail.Comment = ((TextBox)grdSkillDetail.Rows[ObjRow.RowIndex].FindControl("txtComment")).Text;
            objSkillDetailList.Add(objSkillDetail);
        }
        return objSkillDetailList;
    }
    #endregion
}
