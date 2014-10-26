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

public partial class SiblingDetailUC :UserControl
{
	#region Page Variables
	SiblingDetail objSiblingDetail = null;
	SiblingDetailBL objSiblingDetailBL = null;
	MetadataMaster objMetadataMaster = null;
	MetadataMasterBL objMetadataMasterBL = null;
	SchoolMaster objSchoolMaster = null;
	SchoolMasterBL objSchoolMasterBL = null;
	ClassMaster objClassMaster = null;
	ClassMasterBL objClassMasterBL = null;
	private string editIndexKey = "EditIndexSiblingDetailKey";
	#endregion

	#region Page Events and Functions
	protected void Page_Load(object sender, EventArgs e)
	{
	}
	public void InitializeUserControl(int? dataKey,string strSessionDataKey)
	{
		if(!string.IsNullOrEmpty(strSessionDataKey))
		{hfSessionDataKey.Value = strSessionDataKey;}

		if (Session[hfSessionDataKey.Value] == null)
		{
			hfIsControlsLoaded.Value = false.ToString();
			objSiblingDetailBL = new SiblingDetailBL();
			objSiblingDetail = new SiblingDetail();
			objSiblingDetail.CandidateObject = new CandidateDetail();
			objSiblingDetail.CandidateObject.CandidateId = dataKey;

			objSiblingDetail = objSiblingDetailBL.SelectSiblingDetail(objSiblingDetail);
			grdSiblingDetail.DataSource = objSiblingDetail.ObjectDataSet.Tables[0];
			grdSiblingDetail.DataBind();

			Session[hfSessionDataKey.Value] = objSiblingDetail.ObjectDataSet.Tables[0];
			MultiViewSiblingDetail.ActiveViewIndex = 0;

			if (grdSiblingDetail.Rows.Count == 0)
			{
				hfEditIndexKey.Value = string.Empty;
				BindSiblingDetailControls();
				UIUtility.InitializeControls(ViewSiblingDetailControls);
				MultiViewSiblingDetail.ActiveViewIndex = 1;
			}
		}
		else
		{
			grdSiblingDetail.DataSource = (DataTable)Session[hfSessionDataKey.Value];
			grdSiblingDetail.DataBind();
		}
	}
	#endregion

	#region Grid Events and Functions

	protected void grdSiblingDetail_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			ActivateControlsView(false, grdSiblingDetail.SelectedIndex);
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdSiblingDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			DataTable _objTable =(DataTable) Session[hfSessionDataKey.Value];			
            _objTable.Rows[e.RowIndex].Delete();
			InitializeUserControl(null,string.Empty);
			UIUtility.DisplayMessage(lblMessage, CommonConstant.SUCCEED);
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdSiblingDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			grdSiblingDetail.PageIndex = e.NewPageIndex;
			InitializeUserControl(null,string.Empty);
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	#endregion

	#region Controls Events and Functions
	protected void btnAddRecord_Click(object sender, EventArgs e)
	{
		try
		{
			ActivateControlsView(true, null);
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void btnSave_Click(object sender, EventArgs e)
	{
		try
		{
			if (ValidateObject())
			{
				objSiblingDetail = GetSiblingDetailForDataTable();
				if (string.IsNullOrEmpty(hfEditIndexKey.Value))
				{
					objSiblingDetail.AddObjectToTable((DataTable)Session[hfSessionDataKey.Value]);
				}
				else
				{
					int _rowIndex = Convert.ToInt32(hfEditIndexKey.Value);
					objSiblingDetail.UpdateTableFromObject((DataTable)Session[hfSessionDataKey.Value], _rowIndex);
				}

				UIUtility.DisplayMessage(lblMessage, CommonConstant.SUCCEED);
				InitializeUserControl(null,null);
				MultiViewSiblingDetail.ActiveViewIndex = 0;
			}
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void btnCancel_Click(object sender, EventArgs e)
	{
		try
		{
			MultiViewSiblingDetail.ActiveViewIndex = 0;
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void BindSiblingDetailControls()
	{
		if (!Convert.ToBoolean(hfIsControlsLoaded.Value))
		{
            UIController.BindMetadataDDL(ddlGender,MetadataTypeEnum.Gender);
			
			objSchoolMasterBL = new SchoolMasterBL();
			objSchoolMaster = new SchoolMaster();
			objSchoolMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
			objSchoolMaster = objSchoolMasterBL.SelectSchoolMaster(objSchoolMaster);
			ddlSchool.DataSource = objSchoolMaster.ObjectDataSet.Tables[0];
			ddlSchool.DataBind();
			ddlSchool.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

			objClassMasterBL = new ClassMasterBL();
			objClassMaster = new ClassMaster();
			objClassMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
			objClassMaster = objClassMasterBL.SelectClassMaster(objClassMaster);
			ddlClass.DataSource = objClassMaster.ObjectDataSet.Tables[0];
			ddlClass.DataBind();
			ddlClass.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

			hfIsControlsLoaded.Value = true.ToString();
		}
	}
	protected void ActivateControlsView(bool isNewRecord, int? editSiblingDetailIndex)
	{
		if (isNewRecord)
		{
			hfEditIndexKey.Value=string.Empty;
			BindSiblingDetailControls();
			UIUtility.InitializeControls(ViewSiblingDetailControls);
		}
		else
		{
			int _rowIndex = Convert.ToInt32(editSiblingDetailIndex);
			hfEditIndexKey.Value = _rowIndex.ToString();
			BindSiblingDetailControls();
			PopulateControlsData(_rowIndex);
		}
		MultiViewSiblingDetail.ActiveViewIndex = 1;
	}
	private void PopulateControlsData(int rowIndex)
	{
		objSiblingDetail = new SiblingDetail();
		objSiblingDetail.ConvertToObjectFromDataRow((DataTable)Session[hfSessionDataKey.Value], rowIndex);
		txtFullName.Text = objSiblingDetail.FullName;
		txtDateOfBirth.Text = objSiblingDetail.DateOfBirth.ToString();
		UIUtility.SelectCurrentListItem(ddlGender, objSiblingDetail.GenderObject.MetadataId, BindListItem.ByValue, true);
		UIUtility.SelectCurrentListItem(ddlSchool, objSiblingDetail.SchoolObject.SchoolId, BindListItem.ByValue, true);
		txtSchoolName.Text = objSiblingDetail.SchoolName;
		txtSchoolAddress.Text = objSiblingDetail.SchoolAddress;
		txtSchoolContacts.Text = objSiblingDetail.SchoolContacts;
		UIUtility.SelectCurrentListItem(ddlClass, objSiblingDetail.ClassObject.ClassId, BindListItem.ByValue, true);
		txtRegistrationNumber.Text = objSiblingDetail.RegistrationNumber.ToString();
		UIUtility.SelectCurrentListItem(ddlIsCandidate, objSiblingDetail.IsCandidate, BindListItem.ByValue, true);
	}
	#endregion

	#region Helper Functions
	private bool ValidateObject()
	{
		return true;
	}

	private SiblingDetail GetSiblingDetailForDataTable()
	{
		objSiblingDetail = new SiblingDetail();
		objSiblingDetail.FullName = txtFullName.Text;
		objSiblingDetail.DateOfBirth = Convert.ToDateTime(txtDateOfBirth.Text);
		if (ddlGender.SelectedIndex != 0)
		{
			objSiblingDetail.GenderObject = new MetadataMaster();
			objSiblingDetail.GenderObject.MetadataId = Convert.ToInt32(ddlGender.SelectedItem.Value);
		}
		if (ddlSchool.SelectedIndex != 0)
		{
			objSiblingDetail.SchoolObject = new SchoolMaster();
			objSiblingDetail.SchoolObject.SchoolId = Convert.ToInt32(ddlSchool.SelectedItem.Value);
		}
		objSiblingDetail.SchoolName = txtSchoolName.Text;
		objSiblingDetail.SchoolAddress = txtSchoolAddress.Text;
		objSiblingDetail.SchoolContacts = txtSchoolContacts.Text;
		if (ddlClass.SelectedIndex != 0)
		{
			objSiblingDetail.ClassObject = new ClassMaster();
			objSiblingDetail.ClassObject.ClassId = Convert.ToInt32(ddlClass.SelectedItem.Value);
		}
		objSiblingDetail.RegistrationNumber = txtRegistrationNumber.Text;
		objSiblingDetail.IsCandidate = Convert.ToBoolean(ddlIsCandidate.SelectedItem.Value);
		return objSiblingDetail;
	}
	#endregion
}
