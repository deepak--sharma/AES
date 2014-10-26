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

public partial class ResourceManagementUI : BasePage
{
	#region Page Variables
	ResourceManagement objResourceManagement = null;
	ResourceManagementBL objResourceManagementBL = null;

	private const int SELECT_COLUMN = 0;
	private const int ACTIVATE_COLUMN = 1;
	private const int DELETE_COLUMN = 2;

	private const int RESOURCE_ID_INDEX = 0;
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
			objResourceManagement = BindResourceManagementGrid(RecordStatus.Active);
			if (objResourceManagement.DbOperationStatus != CommonConstant.SUCCEED)
			{
				btnAddNewRecord.Enabled = false;
				UIUtility.DisplayMessage(lblMessage, objResourceManagement.DbOperationStatus);
				return;
			}

			ViewState[isControlsLoaded] = false;

			if (grdResourceManagement.Rows.Count == 0)
			{
				BindResourceManagementControls();
				MultiViewResourceManagement.ActiveViewIndex = 1;
			}
		}
		else
		{
			if (rdbActiveRecord.Checked)
			{
				objResourceManagement = BindResourceManagementGrid(RecordStatus.Active);
				if (objResourceManagement.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objResourceManagement.DbOperationStatus);
					return;
				}
				ViewActivateColumn(false);
			}
			else
			{
				objResourceManagement = BindResourceManagementGrid(RecordStatus.InActive);
				if (objResourceManagement.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objResourceManagement.DbOperationStatus);
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
			grdResourceManagement.Columns[SELECT_COLUMN].Visible = false;
			grdResourceManagement.Columns[ACTIVATE_COLUMN].Visible = true;
			grdResourceManagement.Columns[DELETE_COLUMN].Visible = false;
		}
		else
		{
			grdResourceManagement.Columns[SELECT_COLUMN].Visible = true;
			grdResourceManagement.Columns[ACTIVATE_COLUMN].Visible = false;
			grdResourceManagement.Columns[DELETE_COLUMN].Visible = true;
		}
	}
	#endregion

	#region Grid Events and Functions
	protected void grdResourceManagement_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			objResourceManagement = SelectRecordById(grdResourceManagement.SelectedIndex);
			if (!objResourceManagement.DbOperationStatus.Equals(CommonConstant.FAIL))
			{
				if(!Convert.ToBoolean(objResourceManagement.IsRecordChanged))
				{
					ActivateControlsView(false, objResourceManagement, grdResourceManagement.SelectedIndex);
				}
				else
				{
					UIUtility.DisplayMessage(lblMessage, objResourceManagement.DbOperationStatus);
					InitializeForm();
				}
			}
			else
			{
				UIUtility.DisplayMessage(lblMessage, objResourceManagement.DbOperationStatus);
			}
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdResourceManagement_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			objResourceManagementBL = new ResourceManagementBL();
			objResourceManagement = GetObjectForActivateDeactivate(e.RowIndex,RecordStatus.InActive);
			objResourceManagement = objResourceManagementBL.ActivateDeactivateResourceManagement(objResourceManagement);
			UIUtility.DisplayMessage(lblMessage, objResourceManagement.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdResourceManagement_ActivatingObject(object sender, GridViewEditEventArgs e)
	{
		try
		{
			objResourceManagementBL = new ResourceManagementBL();
			objResourceManagement = GetObjectForActivateDeactivate(e.NewEditIndex, RecordStatus.Active);
			objResourceManagement = objResourceManagementBL.ActivateDeactivateResourceManagement(objResourceManagement);
			UIUtility.DisplayMessage(lblMessage, objResourceManagement.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdResourceManagement_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			grdResourceManagement.PageIndex = e.NewPageIndex;
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected ResourceManagement BindResourceManagementGrid(RecordStatus objRecordStatus)
	{
		objResourceManagementBL = new ResourceManagementBL();
		objResourceManagement = new ResourceManagement();
		objResourceManagement.RecordStatus = Convert.ToInt16(objRecordStatus);

		objResourceManagement = objResourceManagementBL.SelectResourceManagement(objResourceManagement);
		if (objResourceManagement.DbOperationStatus == CommonConstant.SUCCEED)
		{
			grdResourceManagement.DataSource = objResourceManagement.ObjectDataSet.Tables[0];
			grdResourceManagement.DataBind();
		}
		return objResourceManagement;
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
				objResourceManagement = GetObjectForInsertUpdate();
				objResourceManagementBL = new ResourceManagementBL();
				if (objResourceManagement.ResourceId == null)
				{
					objResourceManagement = objResourceManagementBL.InsertResourceManagement(objResourceManagement);
				}
				else
				{
					objResourceManagement = objResourceManagementBL.UpdateResourceManagement(objResourceManagement);
				}
				if (objResourceManagement.DbOperationStatus == CommonConstant.SUCCEED
							|| objResourceManagement.DbOperationStatus == CommonConstant.INVALID)
				{
					InitializeForm();
					MultiViewResourceManagement.ActiveViewIndex = 0;
				}
				UIUtility.DisplayMessage(lblMessage, objResourceManagement.DbOperationStatus);
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
			MultiViewResourceManagement.ActiveViewIndex = 0;
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
	protected void BindResourceManagementControls()
	{
		if (!Convert.ToBoolean(ViewState[isControlsLoaded]))
		{
			objResourceManagementBL = new ResourceManagementBL();
			objResourceManagement = new ResourceManagement();
			objResourceManagement.RecordStatus = Convert.ToInt16(RecordStatus.Active);
			objResourceManagement = objResourceManagementBL.SelectResourceManagement(objResourceManagement);
			ddlParent.DataSource = objResourceManagement.ObjectDataSet.Tables[0];
			ddlParent.DataBind();
			ddlParent.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

			ViewState[isControlsLoaded] = true;
		}
	}
	protected void ActivateControlsView(bool isNewRecord, ResourceManagement objResourceManagement,int? editIndex)
	{
		if (isNewRecord)
		{
			ViewState[editIndexKey] = null;
			BindResourceManagementControls();
			UIUtility.InitializeControls(ViewResourceManagementControls);
		}
		else
		{
			ViewState[editIndexKey] = editIndex;
			BindResourceManagementControls();
			PopulateControlsData(objResourceManagement);
		}
		MultiViewResourceManagement.ActiveViewIndex = 1;
	}
	private void PopulateControlsData(ResourceManagement objResourceManagement)
	{
		txtResourceName.Text = objResourceManagement.ResourceName;
		txtUrl.Text = objResourceManagement.Url;
		UIUtility.SelectCurrentListItem(ddlParent, objResourceManagement.ParentResourceObject.ResourceId, BindListItem.ByValue, true);
	}
	#endregion

	#region Helper Functions
	private bool ValidateObject()
	{
		return true;
	}
	private ResourceManagement GetObjectForInsertUpdate()
	{
		objResourceManagement = new ResourceManagement();

		if (ViewState[editIndexKey] == null)
		{
			objResourceManagement.Version = BusinessUtility.RECORD_VERSION;
			objResourceManagement.CreatedBy = LoggedInUser;
			objResourceManagement.CreatedOn = GeneralUtility.CurrentDateTime;
		}
		else
		{
			objResourceManagement.ResourceId = Convert.ToInt32(grdResourceManagement.DataKeys[Convert.ToInt32(ViewState[editIndexKey])].Values[RESOURCE_ID_INDEX].ToString());
			objResourceManagement.Version = Convert.ToInt16(grdResourceManagement.DataKeys[Convert.ToInt16(ViewState[editIndexKey])].Values[VERSION_INDEX].ToString()) + 1;
		}

		objResourceManagement.ResourceName = txtResourceName.Text;
		objResourceManagement.Url = txtUrl.Text;
		if (ddlParent.SelectedIndex != 0)
		{
			objResourceManagement.ParentResourceObject = new ResourceManagement();
			objResourceManagement.ParentResourceObject.ResourceId = Convert.ToInt32(ddlParent.SelectedItem.Value);
		}
		objResourceManagement.ModifiedBy = LoggedInUser;
		objResourceManagement.ModifiedOn = GeneralUtility.CurrentDateTime;
		objResourceManagement.RecordStatus = Convert.ToInt16(RecordStatus.Active);
		return objResourceManagement;
	}
	private ResourceManagement GetObjectForActivateDeactivate(int editIndex,RecordStatus objStatus)
	{
		objResourceManagement = new ResourceManagement();
		objResourceManagement.ResourceId = Convert.ToInt32(grdResourceManagement.DataKeys[editIndex].Values[RESOURCE_ID_INDEX].ToString());
		objResourceManagement.Version = Convert.ToInt16(grdResourceManagement.DataKeys[editIndex].Values[VERSION_INDEX].ToString()) + 1;
		objResourceManagement.ModifiedBy = LoggedInUser;
		objResourceManagement.RecordStatus = Convert.ToInt16(objStatus);
		return objResourceManagement;
	}
	private ResourceManagement SelectRecordById(int editIndex)
	{
		objResourceManagementBL = new ResourceManagementBL();
		objResourceManagement = new ResourceManagement();
		objResourceManagement.ResourceId = Convert.ToInt32(grdResourceManagement.DataKeys[editIndex].Values[RESOURCE_ID_INDEX].ToString());
		objResourceManagement.Version = Convert.ToInt16(grdResourceManagement.DataKeys[editIndex].Values[VERSION_INDEX].ToString());
		objResourceManagement = objResourceManagementBL.SelectRecordById(objResourceManagement);
		return objResourceManagement;
	}
	#endregion
}
