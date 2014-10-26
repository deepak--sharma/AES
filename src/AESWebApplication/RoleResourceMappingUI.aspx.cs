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

public partial class RoleResourceMappingUI : BasePage
{
	#region Page Variables
	RoleResourceMapping objRoleResourceMapping = null;
	RoleResourceMappingBL objRoleResourceMappingBL = null;
	RoleManagement objRoleManagement = null;
	RoleManagementBL objRoleManagementBL = null;
	ResourceManagement objResourceManagement = null;
	ResourceManagementBL objResourceManagementBL = null;

	private const int SELECT_COLUMN = 0;
	private const int ACTIVATE_COLUMN = 1;
	private const int DELETE_COLUMN = 2;

	private const int ROLE_RESOURCE_MAPPING_ID_INDEX = 0;
	private const int VERSION_INDEX = 1;
	private string isControlsLoaded = "ControlsLoaded";
	private string editIndexKey = "EditIndexKey";
	#endregion

	#region Page Events and Functions
	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			if (!Page.IsPostBack)
			{
				InitializeForm();
			}
		}
		catch (Exception ex)
		{
			btnAddNewRecord.Enabled = false;
			lblMessage.Text = ex.Message;
		}
	}
	private void InitializeForm()
	{
		if (!Page.IsPostBack)
		{
			objRoleResourceMapping = BindRoleResourceMappingGrid(RecordStatus.Active);
			if (objRoleResourceMapping.DbOperationStatus != CommonConstant.SUCCEED)
			{
				btnAddNewRecord.Enabled = false;
				UIUtility.DisplayMessage(lblMessage, objRoleResourceMapping.DbOperationStatus);
				return;
			}

			ViewState[isControlsLoaded] = false;

			if (grdRoleResourceMapping.Rows.Count == 0)
			{
				BindRoleResourceMappingControls();
				MultiViewRoleResourceMapping.ActiveViewIndex = 1;
			}
		}
		else
		{
			if (rdbActiveRecord.Checked)
			{
				objRoleResourceMapping = BindRoleResourceMappingGrid(RecordStatus.Active);
				if (objRoleResourceMapping.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objRoleResourceMapping.DbOperationStatus);
					return;
				}
				ViewActivateColumn(false);
			}
			else
			{
				objRoleResourceMapping = BindRoleResourceMappingGrid(RecordStatus.InActive);
				if (objRoleResourceMapping.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objRoleResourceMapping.DbOperationStatus);
					return;
				}
				ViewActivateColumn(true);
			}
		}
		btnAddNewRecord.Enabled = true;
	}
	private void ViewActivateColumn(bool view)
	{
		if (view)
		{
			grdRoleResourceMapping.Columns[SELECT_COLUMN].Visible = false;
			grdRoleResourceMapping.Columns[ACTIVATE_COLUMN].Visible = true;
			grdRoleResourceMapping.Columns[DELETE_COLUMN].Visible = false;
		}
		else
		{
			grdRoleResourceMapping.Columns[SELECT_COLUMN].Visible = true;
			grdRoleResourceMapping.Columns[ACTIVATE_COLUMN].Visible = false;
			grdRoleResourceMapping.Columns[DELETE_COLUMN].Visible = true;
		}
	}
	#endregion

	#region Grid Events and Functions
	protected void grdRoleResourceMapping_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			objRoleResourceMapping = SelectRecordById(grdRoleResourceMapping.SelectedIndex);
			if (!objRoleResourceMapping.DbOperationStatus.Equals(CommonConstant.FAIL))
			{
				if(!Convert.ToBoolean(objRoleResourceMapping.IsRecordChanged))
				{
					ActivateControlsView(false, objRoleResourceMapping, grdRoleResourceMapping.SelectedIndex);
				}
				else
				{
					UIUtility.DisplayMessage(lblMessage, objRoleResourceMapping.DbOperationStatus);
					InitializeForm();
				}
			}
			else
			{
				UIUtility.DisplayMessage(lblMessage, objRoleResourceMapping.DbOperationStatus);
			}
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdRoleResourceMapping_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			objRoleResourceMappingBL = new RoleResourceMappingBL();
			objRoleResourceMapping = GetObjectForActivateDeactivate(e.RowIndex,RecordStatus.InActive);
			objRoleResourceMapping = objRoleResourceMappingBL.ActivateDeactivateRoleResourceMapping(objRoleResourceMapping);
			UIUtility.DisplayMessage(lblMessage, objRoleResourceMapping.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdRoleResourceMapping_ActivatingObject(object sender, GridViewEditEventArgs e)
	{
		try
		{
			objRoleResourceMappingBL = new RoleResourceMappingBL();
			objRoleResourceMapping = GetObjectForActivateDeactivate(e.NewEditIndex, RecordStatus.Active);
			objRoleResourceMapping = objRoleResourceMappingBL.ActivateDeactivateRoleResourceMapping(objRoleResourceMapping);
			UIUtility.DisplayMessage(lblMessage, objRoleResourceMapping.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdRoleResourceMapping_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			grdRoleResourceMapping.PageIndex = e.NewPageIndex;
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected RoleResourceMapping BindRoleResourceMappingGrid(RecordStatus objRecordStatus)
	{
		objRoleResourceMappingBL = new RoleResourceMappingBL();
		objRoleResourceMapping = new RoleResourceMapping();
		objRoleResourceMapping.RecordStatus = Convert.ToInt16(objRecordStatus);

		objRoleResourceMapping = objRoleResourceMappingBL.SelectRoleResourceMapping(objRoleResourceMapping);
		if (objRoleResourceMapping.DbOperationStatus == CommonConstant.SUCCEED)
		{
			grdRoleResourceMapping.DataSource = objRoleResourceMapping.ObjectDataSet.Tables[0];
			grdRoleResourceMapping.DataBind();
		}
		return objRoleResourceMapping;
	}
	#endregion

	#region Controls Events and Functions
	protected void btnAddNewRecord_Click(object sender, EventArgs e)
	{
		try
		{
			ActivateControlsView(true, null, null);
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void btnSave_Click(object sender, EventArgs e)
	{

	}
	protected void btnSubmit_Click(object sender, EventArgs e)
	{
		try
		{
			if (ValidateObject())
			{
				objRoleResourceMapping = GetObjectForInsertUpdate();
				objRoleResourceMappingBL = new RoleResourceMappingBL();
				if (objRoleResourceMapping.RoleResourceMappingId == null)
				{
					objRoleResourceMapping = objRoleResourceMappingBL.InsertRoleResourceMapping(objRoleResourceMapping);
				}
				else
				{
					objRoleResourceMapping = objRoleResourceMappingBL.UpdateRoleResourceMapping(objRoleResourceMapping);
				}
				if (objRoleResourceMapping.DbOperationStatus == CommonConstant.SUCCEED
							|| objRoleResourceMapping.DbOperationStatus == CommonConstant.INVALID)
				{
					InitializeForm();
					MultiViewRoleResourceMapping.ActiveViewIndex = 0;
				}
				UIUtility.DisplayMessage(lblMessage, objRoleResourceMapping.DbOperationStatus);
			}
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void btnCancelRollback_Click(object sender, EventArgs e)
	{
		try
		{
			MultiViewRoleResourceMapping.ActiveViewIndex = 0;
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void rdbActiveRecord_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void rdbInActiveRecord_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void BindRoleResourceMappingControls()
	{
		if (!Convert.ToBoolean(ViewState[isControlsLoaded]))
		{
			objRoleManagementBL = new RoleManagementBL();
			objRoleManagement = new RoleManagement();
			objRoleManagement.RecordStatus = Convert.ToInt16(RecordStatus.Active);
			objRoleManagement = objRoleManagementBL.SelectRoleManagement(objRoleManagement);
			ddlRole.DataSource = objRoleManagement.ObjectDataSet.Tables[0];
			ddlRole.DataBind();
			ddlRole.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

			objResourceManagementBL = new ResourceManagementBL();
			objResourceManagement = new ResourceManagement();
			objResourceManagement.RecordStatus = Convert.ToInt16(RecordStatus.Active);
			objResourceManagement = objResourceManagementBL.SelectResourceManagement(objResourceManagement);
			ddlResource.DataSource = objResourceManagement.ObjectDataSet.Tables[0];
			ddlResource.DataBind();
			ddlResource.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

			ViewState[isControlsLoaded] = true;
		}
	}
	protected void ActivateControlsView(bool isNewRecord, RoleResourceMapping objRoleResourceMapping,int? editIndex)
	{
		if (isNewRecord)
		{
			ViewState[editIndexKey] = null;
			BindRoleResourceMappingControls();
			UIUtility.InitializeControls(ViewRoleResourceMappingControls);
		}
		else
		{
			ViewState[editIndexKey] = editIndex;
			BindRoleResourceMappingControls();
			PopulateControlsData(objRoleResourceMapping);
		}
		MultiViewRoleResourceMapping.ActiveViewIndex = 1;
	}
	private void PopulateControlsData(RoleResourceMapping objRoleResourceMapping)
	{
		UIUtility.SelectCurrentListItem(ddlRole, objRoleResourceMapping.RoleObject.RoleId, BindListItem.ByValue, true);
		UIUtility.SelectCurrentListItem(ddlResource, objRoleResourceMapping.ResourceObject.ResourceId, BindListItem.ByValue, true);
		UIUtility.SelectCurrentListItem(ddlView, objRoleResourceMapping.View, BindListItem.ByValue, true);
		UIUtility.SelectCurrentListItem(ddlCreate, objRoleResourceMapping.Create, BindListItem.ByValue, true);
		UIUtility.SelectCurrentListItem(ddlEdit, objRoleResourceMapping.Edit, BindListItem.ByValue, true);
		UIUtility.SelectCurrentListItem(ddlDelete, objRoleResourceMapping.Delete, BindListItem.ByValue, true);
		UIUtility.SelectCurrentListItem(ddlDownload, objRoleResourceMapping.Download, BindListItem.ByValue, true);
	}
	#endregion

	#region Helper Functions
	private bool ValidateObject()
	{
		return true;
	}
	private RoleResourceMapping GetObjectForInsertUpdate()
	{
		objRoleResourceMapping = new RoleResourceMapping();

		if (ViewState[editIndexKey] == null)
		{
			objRoleResourceMapping.Version = BusinessUtility.RECORD_VERSION;
			objRoleResourceMapping.CreatedBy = LoggedInUser;
			objRoleResourceMapping.CreatedOn = GeneralUtility.CurrentDateTime;
		}
		else
		{
			objRoleResourceMapping.RoleResourceMappingId = Convert.ToInt32(grdRoleResourceMapping.DataKeys[Convert.ToInt32(ViewState[editIndexKey])].Values[ROLE_RESOURCE_MAPPING_ID_INDEX].ToString());
			objRoleResourceMapping.Version = Convert.ToInt16(grdRoleResourceMapping.DataKeys[Convert.ToInt16(ViewState[editIndexKey])].Values[VERSION_INDEX].ToString()) + 1;
		}

		if (ddlRole.SelectedIndex != 0)
		{
			objRoleResourceMapping.RoleObject = new RoleManagement();
			objRoleResourceMapping.RoleObject.RoleId = Convert.ToInt32(ddlRole.SelectedItem.Value);
		}
		if (ddlResource.SelectedIndex != 0)
		{
			objRoleResourceMapping.ResourceObject = new ResourceManagement();
			objRoleResourceMapping.ResourceObject.ResourceId = Convert.ToInt32(ddlResource.SelectedItem.Value);
		}
		objRoleResourceMapping.View = Convert.ToBoolean(ddlView.SelectedItem.Value);
		objRoleResourceMapping.Create = Convert.ToBoolean(ddlCreate.SelectedItem.Value);
		objRoleResourceMapping.Edit = Convert.ToBoolean(ddlEdit.SelectedItem.Value);
		objRoleResourceMapping.Delete = Convert.ToBoolean(ddlDelete.SelectedItem.Value);
		objRoleResourceMapping.Download = Convert.ToBoolean(ddlDownload.SelectedItem.Value);
		objRoleResourceMapping.ModifiedBy = LoggedInUser;
		objRoleResourceMapping.ModifiedOn = GeneralUtility.CurrentDateTime;
		objRoleResourceMapping.RecordStatus = Convert.ToInt16(RecordStatus.Active);
		return objRoleResourceMapping;
	}
	private RoleResourceMapping GetObjectForActivateDeactivate(int editIndex,RecordStatus objStatus)
	{
		objRoleResourceMapping = new RoleResourceMapping();
		objRoleResourceMapping.RoleResourceMappingId = Convert.ToInt32(grdRoleResourceMapping.DataKeys[editIndex].Values[ROLE_RESOURCE_MAPPING_ID_INDEX].ToString());
		objRoleResourceMapping.Version = Convert.ToInt16(grdRoleResourceMapping.DataKeys[editIndex].Values[VERSION_INDEX].ToString()) + 1;
		objRoleResourceMapping.ModifiedBy = LoggedInUser;
		objRoleResourceMapping.RecordStatus = Convert.ToInt16(objStatus);
		return objRoleResourceMapping;
	}
	private RoleResourceMapping SelectRecordById(int editIndex)
	{
		objRoleResourceMappingBL = new RoleResourceMappingBL();
		objRoleResourceMapping = new RoleResourceMapping();
		objRoleResourceMapping.RoleResourceMappingId = Convert.ToInt32(grdRoleResourceMapping.DataKeys[editIndex].Values[ROLE_RESOURCE_MAPPING_ID_INDEX].ToString());
		objRoleResourceMapping.Version = Convert.ToInt16(grdRoleResourceMapping.DataKeys[editIndex].Values[VERSION_INDEX].ToString());
		objRoleResourceMapping = objRoleResourceMappingBL.SelectRecordById(objRoleResourceMapping);
		return objRoleResourceMapping;
	}
	#endregion
}
