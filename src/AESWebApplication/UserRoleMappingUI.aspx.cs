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

public partial class UserRoleMappingUI : BasePage
{
	#region Page Variables
	UserRoleMapping objUserRoleMapping = null;
	UserRoleMappingBL objUserRoleMappingBL = null;
	UserManagement objUserManagement = null;
	UserManagementBL objUserManagementBL = null;
	RoleManagement objRoleManagement = null;
	RoleManagementBL objRoleManagementBL = null;

	private const int SELECT_COLUMN = 0;
	private const int ACTIVATE_COLUMN = 1;
	private const int DELETE_COLUMN = 2;

	private const int USER_ROLE_MAPPING_ID_INDEX = 0;
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
			objUserRoleMapping = BindUserRoleMappingGrid(RecordStatus.Active);
			if (objUserRoleMapping.DbOperationStatus != CommonConstant.SUCCEED)
			{
				btnAddNewRecord.Enabled = false;
				UIUtility.DisplayMessage(lblMessage, objUserRoleMapping.DbOperationStatus);
				return;
			}

			ViewState[isControlsLoaded] = false;

			if (grdUserRoleMapping.Rows.Count == 0)
			{
				BindUserRoleMappingControls();
				MultiViewUserRoleMapping.ActiveViewIndex = 1;
			}
		}
		else
		{
			if (rdbActiveRecord.Checked)
			{
				objUserRoleMapping = BindUserRoleMappingGrid(RecordStatus.Active);
				if (objUserRoleMapping.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objUserRoleMapping.DbOperationStatus);
					return;
				}
				ViewActivateColumn(false);
			}
			else
			{
				objUserRoleMapping = BindUserRoleMappingGrid(RecordStatus.InActive);
				if (objUserRoleMapping.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objUserRoleMapping.DbOperationStatus);
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
			grdUserRoleMapping.Columns[SELECT_COLUMN].Visible = false;
			grdUserRoleMapping.Columns[ACTIVATE_COLUMN].Visible = true;
			grdUserRoleMapping.Columns[DELETE_COLUMN].Visible = false;
		}
		else
		{
			grdUserRoleMapping.Columns[SELECT_COLUMN].Visible = true;
			grdUserRoleMapping.Columns[ACTIVATE_COLUMN].Visible = false;
			grdUserRoleMapping.Columns[DELETE_COLUMN].Visible = true;
		}
	}
	#endregion

	#region Grid Events and Functions
	protected void grdUserRoleMapping_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			objUserRoleMapping = SelectRecordById(grdUserRoleMapping.SelectedIndex);
			if (!objUserRoleMapping.DbOperationStatus.Equals(CommonConstant.FAIL))
			{
				if(!Convert.ToBoolean(objUserRoleMapping.IsRecordChanged))
				{
					ActivateControlsView(false, objUserRoleMapping, grdUserRoleMapping.SelectedIndex);
				}
				else
				{
					UIUtility.DisplayMessage(lblMessage, objUserRoleMapping.DbOperationStatus);
					InitializeForm();
				}
			}
			else
			{
				UIUtility.DisplayMessage(lblMessage, objUserRoleMapping.DbOperationStatus);
			}
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdUserRoleMapping_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			objUserRoleMappingBL = new UserRoleMappingBL();
			objUserRoleMapping = GetObjectForActivateDeactivate(e.RowIndex,RecordStatus.InActive);
			objUserRoleMapping = objUserRoleMappingBL.ActivateDeactivateUserRoleMapping(objUserRoleMapping);
			UIUtility.DisplayMessage(lblMessage, objUserRoleMapping.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdUserRoleMapping_ActivatingObject(object sender, GridViewEditEventArgs e)
	{
		try
		{
			objUserRoleMappingBL = new UserRoleMappingBL();
			objUserRoleMapping = GetObjectForActivateDeactivate(e.NewEditIndex, RecordStatus.Active);
			objUserRoleMapping = objUserRoleMappingBL.ActivateDeactivateUserRoleMapping(objUserRoleMapping);
			UIUtility.DisplayMessage(lblMessage, objUserRoleMapping.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdUserRoleMapping_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			grdUserRoleMapping.PageIndex = e.NewPageIndex;
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected UserRoleMapping BindUserRoleMappingGrid(RecordStatus objRecordStatus)
	{
		objUserRoleMappingBL = new UserRoleMappingBL();
		objUserRoleMapping = new UserRoleMapping();
		objUserRoleMapping.RecordStatus = Convert.ToInt16(objRecordStatus);

		objUserRoleMapping = objUserRoleMappingBL.SelectUserRoleMapping(objUserRoleMapping);
		if (objUserRoleMapping.DbOperationStatus == CommonConstant.SUCCEED)
		{
			grdUserRoleMapping.DataSource = objUserRoleMapping.ObjectDataSet.Tables[0];
			grdUserRoleMapping.DataBind();
		}
		return objUserRoleMapping;
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
				objUserRoleMapping = GetObjectForInsertUpdate();
				objUserRoleMappingBL = new UserRoleMappingBL();
				if (objUserRoleMapping.UserRoleMappingId == null)
				{
					objUserRoleMapping = objUserRoleMappingBL.InsertUserRoleMapping(objUserRoleMapping);
				}
				else
				{
					objUserRoleMapping = objUserRoleMappingBL.UpdateUserRoleMapping(objUserRoleMapping);
				}
				if (objUserRoleMapping.DbOperationStatus == CommonConstant.SUCCEED
							|| objUserRoleMapping.DbOperationStatus == CommonConstant.INVALID)
				{
					InitializeForm();
					MultiViewUserRoleMapping.ActiveViewIndex = 0;
				}
				UIUtility.DisplayMessage(lblMessage, objUserRoleMapping.DbOperationStatus);
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
			MultiViewUserRoleMapping.ActiveViewIndex = 0;
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
	protected void BindUserRoleMappingControls()
	{
		if (!Convert.ToBoolean(ViewState[isControlsLoaded]))
		{
			objUserManagementBL = new UserManagementBL();
			objUserManagement = new UserManagement();
			objUserManagement.RecordStatus = Convert.ToInt16(RecordStatus.Active);
			objUserManagement = objUserManagementBL.SelectUserManagement(objUserManagement);
			ddlUser.DataSource = objUserManagement.ObjectDataSet.Tables[0];
			ddlUser.DataBind();
			ddlUser.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

			objRoleManagementBL = new RoleManagementBL();
			objRoleManagement = new RoleManagement();
			objRoleManagement.RecordStatus = Convert.ToInt16(RecordStatus.Active);
			objRoleManagement = objRoleManagementBL.SelectRoleManagement(objRoleManagement);
			ddlRole.DataSource = objRoleManagement.ObjectDataSet.Tables[0];
			ddlRole.DataBind();
			ddlRole.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

			ViewState[isControlsLoaded] = true;
		}
	}
	protected void ActivateControlsView(bool isNewRecord, UserRoleMapping objUserRoleMapping,int? editIndex)
	{
		if (isNewRecord)
		{
			ViewState[editIndexKey] = null;
			BindUserRoleMappingControls();
			UIUtility.InitializeControls(ViewUserRoleMappingControls);
		}
		else
		{
			ViewState[editIndexKey] = editIndex;
			BindUserRoleMappingControls();
			PopulateControlsData(objUserRoleMapping);
		}
		MultiViewUserRoleMapping.ActiveViewIndex = 1;
	}
	private void PopulateControlsData(UserRoleMapping objUserRoleMapping)
	{
		UIUtility.SelectCurrentListItem(ddlUser, objUserRoleMapping.UserObject.UserId, BindListItem.ByValue, true);
		UIUtility.SelectCurrentListItem(ddlRole, objUserRoleMapping.RoleObject.RoleId, BindListItem.ByValue, true);
	}
	#endregion

	#region Helper Functions
	private bool ValidateObject()
	{
		return true;
	}
	private UserRoleMapping GetObjectForInsertUpdate()
	{
		objUserRoleMapping = new UserRoleMapping();

		if (ViewState[editIndexKey] == null)
		{
			objUserRoleMapping.Version = BusinessUtility.RECORD_VERSION;
			objUserRoleMapping.CreatedBy = LoggedInUser;
			objUserRoleMapping.CreatedOn = GeneralUtility.CurrentDateTime;
		}
		else
		{
			objUserRoleMapping.UserRoleMappingId = Convert.ToInt32(grdUserRoleMapping.DataKeys[Convert.ToInt32(ViewState[editIndexKey])].Values[USER_ROLE_MAPPING_ID_INDEX].ToString());
			objUserRoleMapping.Version = Convert.ToInt16(grdUserRoleMapping.DataKeys[Convert.ToInt16(ViewState[editIndexKey])].Values[VERSION_INDEX].ToString()) + 1;
		}

		if (ddlUser.SelectedIndex != 0)
		{
			objUserRoleMapping.UserObject = new UserManagement();
			objUserRoleMapping.UserObject.UserId = Convert.ToInt32(ddlUser.SelectedItem.Value);
		}
		if (ddlRole.SelectedIndex != 0)
		{
			objUserRoleMapping.RoleObject = new RoleManagement();
			objUserRoleMapping.RoleObject.RoleId = Convert.ToInt32(ddlRole.SelectedItem.Value);
		}
		objUserRoleMapping.ModifiedBy = LoggedInUser;
		objUserRoleMapping.ModifiedOn = GeneralUtility.CurrentDateTime;
		objUserRoleMapping.RecordStatus = Convert.ToInt16(RecordStatus.Active);
		return objUserRoleMapping;
	}
	private UserRoleMapping GetObjectForActivateDeactivate(int editIndex,RecordStatus objStatus)
	{
		objUserRoleMapping = new UserRoleMapping();
		objUserRoleMapping.UserRoleMappingId = Convert.ToInt32(grdUserRoleMapping.DataKeys[editIndex].Values[USER_ROLE_MAPPING_ID_INDEX].ToString());
		objUserRoleMapping.Version = Convert.ToInt16(grdUserRoleMapping.DataKeys[editIndex].Values[VERSION_INDEX].ToString()) + 1;
		objUserRoleMapping.ModifiedBy = LoggedInUser;
		objUserRoleMapping.RecordStatus = Convert.ToInt16(objStatus);
		return objUserRoleMapping;
	}
	private UserRoleMapping SelectRecordById(int editIndex)
	{
		objUserRoleMappingBL = new UserRoleMappingBL();
		objUserRoleMapping = new UserRoleMapping();
		objUserRoleMapping.UserRoleMappingId = Convert.ToInt32(grdUserRoleMapping.DataKeys[editIndex].Values[USER_ROLE_MAPPING_ID_INDEX].ToString());
		objUserRoleMapping.Version = Convert.ToInt16(grdUserRoleMapping.DataKeys[editIndex].Values[VERSION_INDEX].ToString());
		objUserRoleMapping = objUserRoleMappingBL.SelectRecordById(objUserRoleMapping);
		return objUserRoleMapping;
	}
	#endregion
}
