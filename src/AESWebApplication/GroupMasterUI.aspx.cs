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

public partial class GroupMasterUI : BasePage
{
	#region Page Variables
	GroupMaster objGroupMaster = null;
	GroupMasterBL objGroupMasterBL = null;

	private const int SELECT_COLUMN = 0;
	private const int ACTIVATE_COLUMN = 1;
	private const int DELETE_COLUMN = 2;

	private const int GROUP_ID_INDEX = 0;
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
			objGroupMaster = BindGroupMasterGrid(RecordStatus.Active);
			if (objGroupMaster.DbOperationStatus != CommonConstant.SUCCEED)
			{
				btnAddNewRecord.Enabled = false;
				UIUtility.DisplayMessage(lblMessage, objGroupMaster.DbOperationStatus);
				return;
			}

			ViewState[isControlsLoaded] = false;

			if (grdGroupMaster.Rows.Count == 0)
			{
				BindGroupMasterControls();
				MultiViewGroupMaster.ActiveViewIndex = 1;
			}
		}
		else
		{
			if (rdbActiveRecord.Checked)
			{
				objGroupMaster = BindGroupMasterGrid(RecordStatus.Active);
				if (objGroupMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objGroupMaster.DbOperationStatus);
					return;
				}
				ViewActivateColumn(false);
			}
			else
			{
				objGroupMaster = BindGroupMasterGrid(RecordStatus.InActive);
				if (objGroupMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objGroupMaster.DbOperationStatus);
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
			grdGroupMaster.Columns[SELECT_COLUMN].Visible = false;
			grdGroupMaster.Columns[ACTIVATE_COLUMN].Visible = true;
			grdGroupMaster.Columns[DELETE_COLUMN].Visible = false;
		}
		else
		{
			grdGroupMaster.Columns[SELECT_COLUMN].Visible = true;
			grdGroupMaster.Columns[ACTIVATE_COLUMN].Visible = false;
			grdGroupMaster.Columns[DELETE_COLUMN].Visible = true;
		}
	}
	#endregion

	#region Grid Events and Functions
	protected void grdGroupMaster_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			objGroupMaster = SelectRecordById(grdGroupMaster.SelectedIndex);
			if (!objGroupMaster.DbOperationStatus.Equals(CommonConstant.FAIL))
			{
				if(!Convert.ToBoolean(objGroupMaster.IsRecordChanged))
				{
					ActivateControlsView(false, objGroupMaster, grdGroupMaster.SelectedIndex);
				}
				else
				{
					UIUtility.DisplayMessage(lblMessage, objGroupMaster.DbOperationStatus);
					InitializeForm();
				}
			}
			else
			{
				UIUtility.DisplayMessage(lblMessage, objGroupMaster.DbOperationStatus);
			}
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdGroupMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			objGroupMasterBL = new GroupMasterBL();
			objGroupMaster = GetObjectForActivateDeactivate(e.RowIndex,RecordStatus.InActive);
			objGroupMaster = objGroupMasterBL.ActivateDeactivateGroupMaster(objGroupMaster);
			UIUtility.DisplayMessage(lblMessage, objGroupMaster.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdGroupMaster_ActivatingObject(object sender, GridViewEditEventArgs e)
	{
		try
		{
			objGroupMasterBL = new GroupMasterBL();
			objGroupMaster = GetObjectForActivateDeactivate(e.NewEditIndex, RecordStatus.Active);
			objGroupMaster = objGroupMasterBL.ActivateDeactivateGroupMaster(objGroupMaster);
			UIUtility.DisplayMessage(lblMessage, objGroupMaster.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdGroupMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			grdGroupMaster.PageIndex = e.NewPageIndex;
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected GroupMaster BindGroupMasterGrid(RecordStatus objRecordStatus)
	{
		objGroupMasterBL = new GroupMasterBL();
		objGroupMaster = new GroupMaster();
		objGroupMaster.RecordStatus = Convert.ToInt16(objRecordStatus);

		objGroupMaster = objGroupMasterBL.SelectGroupMaster(objGroupMaster);
		if (objGroupMaster.DbOperationStatus == CommonConstant.SUCCEED)
		{
			grdGroupMaster.DataSource = objGroupMaster.ObjectDataSet.Tables[0];
			grdGroupMaster.DataBind();
		}
		return objGroupMaster;
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
				objGroupMaster = GetObjectForInsertUpdate();
				objGroupMasterBL = new GroupMasterBL();
				if (objGroupMaster.GroupId == null)
				{
					objGroupMaster = objGroupMasterBL.InsertGroupMaster(objGroupMaster);
				}
				else
				{
					objGroupMaster = objGroupMasterBL.UpdateGroupMaster(objGroupMaster);
				}
				if (objGroupMaster.DbOperationStatus == CommonConstant.SUCCEED
							|| objGroupMaster.DbOperationStatus == CommonConstant.INVALID)
				{
					InitializeForm();
					MultiViewGroupMaster.ActiveViewIndex = 0;
				}
				UIUtility.DisplayMessage(lblMessage, objGroupMaster.DbOperationStatus);
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
			MultiViewGroupMaster.ActiveViewIndex = 0;
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
	protected void BindGroupMasterControls()
	{
		if (!Convert.ToBoolean(ViewState[isControlsLoaded]))
		{
			objGroupMasterBL = new GroupMasterBL();
			objGroupMaster = new GroupMaster();
			objGroupMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
			objGroupMaster = objGroupMasterBL.SelectGroupMaster(objGroupMaster);
			ddlParent.DataSource = objGroupMaster.ObjectDataSet.Tables[0];
			ddlParent.DataBind();
			ddlParent.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

			ViewState[isControlsLoaded] = true;
		}
	}
	protected void ActivateControlsView(bool isNewRecord, GroupMaster objGroupMaster,int? editIndex)
	{
		if (isNewRecord)
		{
			ViewState[editIndexKey] = null;
			BindGroupMasterControls();
			UIUtility.InitializeControls(ViewGroupMasterControls);
		}
		else
		{
			ViewState[editIndexKey] = editIndex;
			BindGroupMasterControls();
			PopulateControlsData(objGroupMaster);
		}
		MultiViewGroupMaster.ActiveViewIndex = 1;
	}
	private void PopulateControlsData(GroupMaster objGroupMaster)
	{
		txtGroupName.Text = objGroupMaster.GroupName;
		UIUtility.SelectCurrentListItem(ddlParent, objGroupMaster.ParentGroupObject.GroupId, BindListItem.ByValue, true);
		txtDescription.Text = objGroupMaster.Description;
	}
	#endregion

	#region Helper Functions
	private bool ValidateObject()
	{
		return true;
	}
	private GroupMaster GetObjectForInsertUpdate()
	{
		objGroupMaster = new GroupMaster();

		if (ViewState[editIndexKey] == null)
		{
			objGroupMaster.Version = BusinessUtility.RECORD_VERSION;
			objGroupMaster.CreatedBy = LoggedInUser;
			objGroupMaster.CreatedOn = GeneralUtility.CurrentDateTime;
		}
		else
		{
			objGroupMaster.GroupId = Convert.ToInt32(grdGroupMaster.DataKeys[Convert.ToInt32(ViewState[editIndexKey])].Values[GROUP_ID_INDEX].ToString());
			objGroupMaster.Version = Convert.ToInt16(grdGroupMaster.DataKeys[Convert.ToInt16(ViewState[editIndexKey])].Values[VERSION_INDEX].ToString()) + 1;
		}

		objGroupMaster.GroupName = txtGroupName.Text;
		if (ddlParent.SelectedIndex != 0)
		{
			objGroupMaster.ParentGroupObject = new GroupMaster();
			objGroupMaster.ParentGroupObject.GroupId = Convert.ToInt32(ddlParent.SelectedItem.Value);
		}
		objGroupMaster.Description = txtDescription.Text;
		objGroupMaster.ModifiedBy = LoggedInUser;
		objGroupMaster.ModifiedOn = GeneralUtility.CurrentDateTime;
		objGroupMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
		return objGroupMaster;
	}
	private GroupMaster GetObjectForActivateDeactivate(int editIndex,RecordStatus objStatus)
	{
		objGroupMaster = new GroupMaster();
		objGroupMaster.GroupId = Convert.ToInt32(grdGroupMaster.DataKeys[editIndex].Values[GROUP_ID_INDEX].ToString());
		objGroupMaster.Version = Convert.ToInt16(grdGroupMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString()) + 1;
		objGroupMaster.ModifiedBy = LoggedInUser;
		objGroupMaster.RecordStatus = Convert.ToInt16(objStatus);
		return objGroupMaster;
	}
	private GroupMaster SelectRecordById(int editIndex)
	{
		objGroupMasterBL = new GroupMasterBL();
		objGroupMaster = new GroupMaster();
		objGroupMaster.GroupId = Convert.ToInt32(grdGroupMaster.DataKeys[editIndex].Values[GROUP_ID_INDEX].ToString());
		objGroupMaster.Version = Convert.ToInt16(grdGroupMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString());
		objGroupMaster = objGroupMasterBL.SelectRecordById(objGroupMaster);
		return objGroupMaster;
	}
	#endregion
}
