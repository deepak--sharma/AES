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

public partial class DocumentDetailUC : System.Web.UI.UserControl
{
	#region Page Variables
	DocumentDetail objDocumentDetail = null;
	MetadataMaster objMetadataMaster = null;
	MetadataMasterBL objMetadataMasterBL = null;

	#endregion

	#region Page Events and Functions
	protected void Page_Load(object sender, EventArgs e)
	{
	}
	#endregion

	#region Helper Functions
	public bool ValidateObject()
	{
		return true;
	}
	public void BindUCControls()
	{
			objMetadataMasterBL = new MetadataMasterBL();
			objMetadataMaster = new MetadataMaster();
			objMetadataMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
			objMetadataMaster = objMetadataMasterBL.SelectMetadataMaster(objMetadataMaster);
			ddlMember.DataSource = objMetadataMaster.ObjectDataSet.Tables[0];
			ddlMember.DataBind();
			ddlMember.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

			ddlDocument.DataSource = objMetadataMaster.ObjectDataSet.Tables[0].Copy();
			ddlDocument.DataBind();
			ddlDocument.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

	}
	public DocumentDetail GetUserControlData()
	{
		objDocumentDetail = new DocumentDetail();
		if (!string.IsNullOrEmpty(hfDocumentDetailId.Value))
		{ objDocumentDetail.DocumentDetailId = Convert.ToInt32(hfDocumentDetailId.Value); }
		objDocumentDetail.MemberId = Convert.ToInt32(txtMemberId.Text);
		if (ddlMember.SelectedIndex != 0)
		{
			objDocumentDetail.MemberTypeObject = new MetadataMaster();
			objDocumentDetail.MemberTypeObject.MetadataId = Convert.ToInt32(ddlMember.SelectedItem.Value);
		}
		if (ddlDocument.SelectedIndex != 0)
		{
			objDocumentDetail.DocumentObject = new MetadataMaster();
			objDocumentDetail.DocumentObject.MetadataId = Convert.ToInt32(ddlDocument.SelectedItem.Value);
		}
		objDocumentDetail.DocumentDescription = txtDocumentDescription.Text;
		objDocumentDetail.DocumentPath = txtDocumentPath.Text;
		objDocumentDetail.Comments = txtComments.Text;
		objDocumentDetail.UploadDate = Convert.ToDateTime(txtUploadDate.Text);
		return objDocumentDetail;
	}
	public void SetUserControlData(DocumentDetail _objDocumentDetail)
	{
		hfDocumentDetailId.Value = _objDocumentDetail.DocumentDetailId.ToString();
		txtMemberId.Text = _objDocumentDetail.MemberId.ToString();
		UIUtility.SelectCurrentListItem(ddlMember, _objDocumentDetail.MemberTypeObject.MetadataId, BindListItem.ByValue, true);
		UIUtility.SelectCurrentListItem(ddlDocument, _objDocumentDetail.DocumentObject.MetadataId, BindListItem.ByValue, true);
		txtDocumentDescription.Text = _objDocumentDetail.DocumentDescription;
		txtDocumentPath.Text = _objDocumentDetail.DocumentPath;
		txtComments.Text = _objDocumentDetail.Comments;
		txtUploadDate.Text = _objDocumentDetail.UploadDate.ToString();
	}
	#endregion
}
