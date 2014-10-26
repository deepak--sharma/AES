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

public partial class UserManagementUI : BasePage
{
	#region Page Variables
	UserManagement objUserManagement = null;
	UserManagementBL objUserManagementBL = null;
	MetadataMaster objMetadataMaster = null;
	MetadataMasterBL objMetadataMasterBL = null;

	private const int SELECT_COLUMN = 0;
	private const int ACTIVATE_COLUMN = 1;
	private const int DELETE_COLUMN = 2;

	private const int USER_ID_INDEX = 0;
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
			objUserManagement = BindUserManagementGrid(RecordStatus.Active);
			if (objUserManagement.DbOperationStatus != CommonConstant.SUCCEED)
			{
				btnAddNewRecord.Enabled = false;
				UIUtility.DisplayMessage(lblMessage, objUserManagement.DbOperationStatus);
				return;
			}

			ViewState[isControlsLoaded] = false;

			if (grdUserManagement.Rows.Count == 0)
			{
				BindUserManagementControls();
				MultiViewUserManagement.ActiveViewIndex = 1;
			}
		}
		else
		{
			if (rdbActiveRecord.Checked)
			{
				objUserManagement = BindUserManagementGrid(RecordStatus.Active);
				if (objUserManagement.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objUserManagement.DbOperationStatus);
					return;
				}
				ViewActivateColumn(false);
			}
			else
			{
				objUserManagement = BindUserManagementGrid(RecordStatus.InActive);
				if (objUserManagement.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objUserManagement.DbOperationStatus);
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
			grdUserManagement.Columns[SELECT_COLUMN].Visible = false;
			grdUserManagement.Columns[ACTIVATE_COLUMN].Visible = true;
			grdUserManagement.Columns[DELETE_COLUMN].Visible = false;
		}
		else
		{
			grdUserManagement.Columns[SELECT_COLUMN].Visible = true;
			grdUserManagement.Columns[ACTIVATE_COLUMN].Visible = false;
			grdUserManagement.Columns[DELETE_COLUMN].Visible = true;
		}
	}
	#endregion

	#region Grid Events and Functions
	protected void grdUserManagement_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			objUserManagement = SelectRecordById(grdUserManagement.SelectedIndex);
			if (!objUserManagement.DbOperationStatus.Equals(CommonConstant.FAIL))
			{
				if(!Convert.ToBoolean(objUserManagement.IsRecordChanged))
				{
					ActivateControlsView(false, objUserManagement, grdUserManagement.SelectedIndex);
				}
				else
				{
					UIUtility.DisplayMessage(lblMessage, objUserManagement.DbOperationStatus);
					InitializeForm();
				}
			}
			else
			{
				UIUtility.DisplayMessage(lblMessage, objUserManagement.DbOperationStatus);
			}
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdUserManagement_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			objUserManagementBL = new UserManagementBL();
			objUserManagement = GetObjectForActivateDeactivate(e.RowIndex,RecordStatus.InActive);
			objUserManagement = objUserManagementBL.ActivateDeactivateUserManagement(objUserManagement);
			UIUtility.DisplayMessage(lblMessage, objUserManagement.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdUserManagement_ActivatingObject(object sender, GridViewEditEventArgs e)
	{
		try
		{
			objUserManagementBL = new UserManagementBL();
			objUserManagement = GetObjectForActivateDeactivate(e.NewEditIndex, RecordStatus.Active);
			objUserManagement = objUserManagementBL.ActivateDeactivateUserManagement(objUserManagement);
			UIUtility.DisplayMessage(lblMessage, objUserManagement.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdUserManagement_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			grdUserManagement.PageIndex = e.NewPageIndex;
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected UserManagement BindUserManagementGrid(RecordStatus objRecordStatus)
	{
		objUserManagementBL = new UserManagementBL();
		objUserManagement = new UserManagement();
		objUserManagement.RecordStatus = Convert.ToInt16(objRecordStatus);

		objUserManagement = objUserManagementBL.SelectUserManagement(objUserManagement);
		if (objUserManagement.DbOperationStatus == CommonConstant.SUCCEED)
		{
			grdUserManagement.DataSource = objUserManagement.ObjectDataSet.Tables[0];
			grdUserManagement.DataBind();
		}
		return objUserManagement;
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
				objUserManagement = GetObjectForInsertUpdate();
				objUserManagementBL = new UserManagementBL();
				if (objUserManagement.UserId == null)
				{
					objUserManagement = objUserManagementBL.InsertUserManagement(objUserManagement);
				}
				else
				{
					objUserManagement = objUserManagementBL.UpdateUserManagement(objUserManagement);
				}
				if (objUserManagement.DbOperationStatus == CommonConstant.SUCCEED
							|| objUserManagement.DbOperationStatus == CommonConstant.INVALID)
				{
					InitializeForm();
					MultiViewUserManagement.ActiveViewIndex = 0;
				}
				UIUtility.DisplayMessage(lblMessage, objUserManagement.DbOperationStatus);
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
			MultiViewUserManagement.ActiveViewIndex = 0;
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
	protected void BindUserManagementControls()
	{
		if (!Convert.ToBoolean(ViewState[isControlsLoaded]))
		{
			objMetadataMasterBL = new MetadataMasterBL();
			objMetadataMaster = new MetadataMaster();
			objMetadataMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
			objMetadataMaster = objMetadataMasterBL.SelectMetadataMaster(objMetadataMaster);
			ddlUser.DataSource = objMetadataMaster.ObjectDataSet.Tables[0];
			ddlUser.DataBind();
			ddlUser.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

			ViewState[isControlsLoaded] = true;
		}
	}
	protected void ActivateControlsView(bool isNewRecord, UserManagement objUserManagement,int? editIndex)
	{
		if (isNewRecord)
		{
			ViewState[editIndexKey] = null;
			BindUserManagementControls();
			UIUtility.InitializeControls(ViewUserManagementControls);
		}
		else
		{
			ViewState[editIndexKey] = editIndex;
			BindUserManagementControls();
			PopulateControlsData(objUserManagement);
		}
		MultiViewUserManagement.ActiveViewIndex = 1;
	}
	private void PopulateControlsData(UserManagement objUserManagement)
	{
		txtUserName.Text = objUserManagement.UserName;
		txtPassword.Text = objUserManagement.Password;
		UIUtility.SelectCurrentListItem(ddlUser, objUserManagement.UserType.MetadataId, BindListItem.ByValue, true);
		txtLastLogin.Text = objUserManagement.LastLogin.ToString();
		UIUtility.SelectCurrentListItem(ddlStatus, objUserManagement.Status, BindListItem.ByValue, true);
	}
	#endregion

	#region Helper Functions
	private bool ValidateObject()
	{
		return true;
	}
	private UserManagement GetObjectForInsertUpdate()
	{
		objUserManagement = new UserManagement();

		if (ViewState[editIndexKey] == null)
		{
			objUserManagement.Version = BusinessUtility.RECORD_VERSION;
			objUserManagement.CreatedBy = LoggedInUser;
			objUserManagement.CreatedOn = GeneralUtility.CurrentDateTime;
		}
		else
		{
			objUserManagement.UserId = Convert.ToInt32(grdUserManagement.DataKeys[Convert.ToInt32(ViewState[editIndexKey])].Values[USER_ID_INDEX].ToString());
			objUserManagement.Version = Convert.ToInt16(grdUserManagement.DataKeys[Convert.ToInt16(ViewState[editIndexKey])].Values[VERSION_INDEX].ToString()) + 1;
		}

		objUserManagement.UserName = txtUserName.Text;
		objUserManagement.Password = txtPassword.Text;
		if (ddlUser.SelectedIndex != 0)
		{
			objUserManagement.UserType = new MetadataMaster();
			objUserManagement.UserType.MetadataId = Convert.ToInt32(ddlUser.SelectedItem.Value);
		}
		objUserManagement.LastLogin = Convert.ToDateTime(txtLastLogin.Text);
		objUserManagement.Status = Convert.ToBoolean(ddlStatus.SelectedItem.Value);
		objUserManagement.ModifiedBy = LoggedInUser;
		objUserManagement.ModifiedOn = GeneralUtility.CurrentDateTime;
		objUserManagement.RecordStatus = Convert.ToInt16(RecordStatus.Active);
		return objUserManagement;
	}
	private UserManagement GetObjectForActivateDeactivate(int editIndex,RecordStatus objStatus)
	{
		objUserManagement = new UserManagement();
		objUserManagement.UserId = Convert.ToInt32(grdUserManagement.DataKeys[editIndex].Values[USER_ID_INDEX].ToString());
		objUserManagement.Version = Convert.ToInt16(grdUserManagement.DataKeys[editIndex].Values[VERSION_INDEX].ToString()) + 1;
		objUserManagement.ModifiedBy = LoggedInUser;
		objUserManagement.RecordStatus = Convert.ToInt16(objStatus);
		return objUserManagement;
	}
	private UserManagement SelectRecordById(int editIndex)
	{
		objUserManagementBL = new UserManagementBL();
		objUserManagement = new UserManagement();
		objUserManagement.UserId = Convert.ToInt32(grdUserManagement.DataKeys[editIndex].Values[USER_ID_INDEX].ToString());
		objUserManagement.Version = Convert.ToInt16(grdUserManagement.DataKeys[editIndex].Values[VERSION_INDEX].ToString());
		objUserManagement = objUserManagementBL.SelectRecordById(objUserManagement);
		return objUserManagement;
	}
	#endregion
}
