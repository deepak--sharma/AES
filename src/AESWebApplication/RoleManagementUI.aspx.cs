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

public partial class RoleManagementUI : BasePage
{
	#region Page Variables
	RoleManagement objRoleManagement = null;
	RoleManagementBL objRoleManagementBL = null;

	private const int SELECT_COLUMN = 0;
	private const int ACTIVATE_COLUMN = 1;
	private const int DELETE_COLUMN = 2;

	private const int ROLE_ID_INDEX = 0;
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
			objRoleManagement = BindRoleManagementGrid(RecordStatus.Active);
			if (objRoleManagement.DbOperationStatus != CommonConstant.SUCCEED)
			{
				btnAddNewRecord.Enabled = false;
				UIUtility.DisplayMessage(lblMessage, objRoleManagement.DbOperationStatus);
				return;
			}

			ViewState[isControlsLoaded] = false;

			if (grdRoleManagement.Rows.Count == 0)
			{
				BindRoleManagementControls();
				MultiViewRoleManagement.ActiveViewIndex = 1;
			}
		}
		else
		{
			if (rdbActiveRecord.Checked)
			{
				objRoleManagement = BindRoleManagementGrid(RecordStatus.Active);
				if (objRoleManagement.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objRoleManagement.DbOperationStatus);
					return;
				}
				ViewActivateColumn(false);
			}
			else
			{
				objRoleManagement = BindRoleManagementGrid(RecordStatus.InActive);
				if (objRoleManagement.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objRoleManagement.DbOperationStatus);
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
			grdRoleManagement.Columns[SELECT_COLUMN].Visible = false;
			grdRoleManagement.Columns[ACTIVATE_COLUMN].Visible = true;
			grdRoleManagement.Columns[DELETE_COLUMN].Visible = false;
		}
		else
		{
			grdRoleManagement.Columns[SELECT_COLUMN].Visible = true;
			grdRoleManagement.Columns[ACTIVATE_COLUMN].Visible = false;
			grdRoleManagement.Columns[DELETE_COLUMN].Visible = true;
		}
	}
	#endregion

	#region Grid Events and Functions
	protected void grdRoleManagement_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			objRoleManagement = SelectRecordById(grdRoleManagement.SelectedIndex);
			if (!objRoleManagement.DbOperationStatus.Equals(CommonConstant.FAIL))
			{
				if(!Convert.ToBoolean(objRoleManagement.IsRecordChanged))
				{
					ActivateControlsView(false, objRoleManagement, grdRoleManagement.SelectedIndex);
				}
				else
				{
					UIUtility.DisplayMessage(lblMessage, objRoleManagement.DbOperationStatus);
					InitializeForm();
				}
			}
			else
			{
				UIUtility.DisplayMessage(lblMessage, objRoleManagement.DbOperationStatus);
			}
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdRoleManagement_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			objRoleManagementBL = new RoleManagementBL();
			objRoleManagement = GetObjectForActivateDeactivate(e.RowIndex,RecordStatus.InActive);
			objRoleManagement = objRoleManagementBL.ActivateDeactivateRoleManagement(objRoleManagement);
			UIUtility.DisplayMessage(lblMessage, objRoleManagement.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdRoleManagement_ActivatingObject(object sender, GridViewEditEventArgs e)
	{
		try
		{
			objRoleManagementBL = new RoleManagementBL();
			objRoleManagement = GetObjectForActivateDeactivate(e.NewEditIndex, RecordStatus.Active);
			objRoleManagement = objRoleManagementBL.ActivateDeactivateRoleManagement(objRoleManagement);
			UIUtility.DisplayMessage(lblMessage, objRoleManagement.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdRoleManagement_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			grdRoleManagement.PageIndex = e.NewPageIndex;
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected RoleManagement BindRoleManagementGrid(RecordStatus objRecordStatus)
	{
		objRoleManagementBL = new RoleManagementBL();
		objRoleManagement = new RoleManagement();
		objRoleManagement.RecordStatus = Convert.ToInt16(objRecordStatus);

		objRoleManagement = objRoleManagementBL.SelectRoleManagement(objRoleManagement);
		if (objRoleManagement.DbOperationStatus == CommonConstant.SUCCEED)
		{
			grdRoleManagement.DataSource = objRoleManagement.ObjectDataSet.Tables[0];
			grdRoleManagement.DataBind();
		}
		return objRoleManagement;
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
				objRoleManagement = GetObjectForInsertUpdate();
				objRoleManagementBL = new RoleManagementBL();
				if (objRoleManagement.RoleId == null)
				{
					objRoleManagement = objRoleManagementBL.InsertRoleManagement(objRoleManagement);
				}
				else
				{
					objRoleManagement = objRoleManagementBL.UpdateRoleManagement(objRoleManagement);
				}
				if (objRoleManagement.DbOperationStatus == CommonConstant.SUCCEED
							|| objRoleManagement.DbOperationStatus == CommonConstant.INVALID)
				{
					InitializeForm();
					MultiViewRoleManagement.ActiveViewIndex = 0;
				}
				UIUtility.DisplayMessage(lblMessage, objRoleManagement.DbOperationStatus);
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
			MultiViewRoleManagement.ActiveViewIndex = 0;
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
	protected void BindRoleManagementControls()
	{
		if (!Convert.ToBoolean(ViewState[isControlsLoaded]))
		{
			ViewState[isControlsLoaded] = true;
		}
	}
	protected void ActivateControlsView(bool isNewRecord, RoleManagement objRoleManagement,int? editIndex)
	{
		if (isNewRecord)
		{
			ViewState[editIndexKey] = null;
			BindRoleManagementControls();
			UIUtility.InitializeControls(ViewRoleManagementControls);
		}
		else
		{
			ViewState[editIndexKey] = editIndex;
			BindRoleManagementControls();
			PopulateControlsData(objRoleManagement);
		}
		MultiViewRoleManagement.ActiveViewIndex = 1;
	}
	private void PopulateControlsData(RoleManagement objRoleManagement)
	{
		txtRoleName.Text = objRoleManagement.RoleName;
		txtDescription.Text = objRoleManagement.Description;
	}
	#endregion

	#region Helper Functions
	private bool ValidateObject()
	{
		return true;
	}
	private RoleManagement GetObjectForInsertUpdate()
	{
		objRoleManagement = new RoleManagement();

		if (ViewState[editIndexKey] == null)
		{
			objRoleManagement.Version = BusinessUtility.RECORD_VERSION;
			objRoleManagement.CreatedBy = LoggedInUser;
			objRoleManagement.CreatedOn = GeneralUtility.CurrentDateTime;
		}
		else
		{
			objRoleManagement.RoleId = Convert.ToInt32(grdRoleManagement.DataKeys[Convert.ToInt32(ViewState[editIndexKey])].Values[ROLE_ID_INDEX].ToString());
			objRoleManagement.Version = Convert.ToInt16(grdRoleManagement.DataKeys[Convert.ToInt16(ViewState[editIndexKey])].Values[VERSION_INDEX].ToString()) + 1;
		}

		objRoleManagement.RoleName = txtRoleName.Text;
		objRoleManagement.Description = txtDescription.Text;
		objRoleManagement.ModifiedBy = LoggedInUser;
		objRoleManagement.ModifiedOn = GeneralUtility.CurrentDateTime;
		objRoleManagement.RecordStatus = Convert.ToInt16(RecordStatus.Active);
		return objRoleManagement;
	}
	private RoleManagement GetObjectForActivateDeactivate(int editIndex,RecordStatus objStatus)
	{
		objRoleManagement = new RoleManagement();
		objRoleManagement.RoleId = Convert.ToInt32(grdRoleManagement.DataKeys[editIndex].Values[ROLE_ID_INDEX].ToString());
		objRoleManagement.Version = Convert.ToInt16(grdRoleManagement.DataKeys[editIndex].Values[VERSION_INDEX].ToString()) + 1;
		objRoleManagement.ModifiedBy = LoggedInUser;
		objRoleManagement.RecordStatus = Convert.ToInt16(objStatus);
		return objRoleManagement;
	}
	private RoleManagement SelectRecordById(int editIndex)
	{
		objRoleManagementBL = new RoleManagementBL();
		objRoleManagement = new RoleManagement();
		objRoleManagement.RoleId = Convert.ToInt32(grdRoleManagement.DataKeys[editIndex].Values[ROLE_ID_INDEX].ToString());
		objRoleManagement.Version = Convert.ToInt16(grdRoleManagement.DataKeys[editIndex].Values[VERSION_INDEX].ToString());
		objRoleManagement = objRoleManagementBL.SelectRecordById(objRoleManagement);
		return objRoleManagement;
	}
	#endregion
}
