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

public partial class RackGroupMasterUI : BasePage
{
	#region Page Variables
	RackGroupMaster objRackGroupMaster = null;
	RackGroupMasterBL objRackGroupMasterBL = null;

	private const int SELECT_COLUMN = 0;
	private const int ACTIVATE_COLUMN = 1;
	private const int DELETE_COLUMN = 2;

	private const int RACK_GROUP_ID_INDEX = 0;
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
			objRackGroupMaster = BindRackGroupMasterGrid(RecordStatus.Active);
			if (objRackGroupMaster.DbOperationStatus != CommonConstant.SUCCEED)
			{
				btnAddNewRecord.Enabled = false;
				UIUtility.DisplayMessage(lblMessage, objRackGroupMaster.DbOperationStatus);
				return;
			}

			ViewState[isControlsLoaded] = false;

			if (grdRackGroupMaster.Rows.Count == 0)
			{
				BindRackGroupMasterControls();
				MultiViewRackGroupMaster.ActiveViewIndex = 1;
			}
		}
		else
		{
			if (rdbActiveRecord.Checked)
			{
				objRackGroupMaster = BindRackGroupMasterGrid(RecordStatus.Active);
				if (objRackGroupMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objRackGroupMaster.DbOperationStatus);
					return;
				}
				ViewActivateColumn(false);
			}
			else
			{
				objRackGroupMaster = BindRackGroupMasterGrid(RecordStatus.InActive);
				if (objRackGroupMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objRackGroupMaster.DbOperationStatus);
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
			grdRackGroupMaster.Columns[SELECT_COLUMN].Visible = false;
			grdRackGroupMaster.Columns[ACTIVATE_COLUMN].Visible = true;
			grdRackGroupMaster.Columns[DELETE_COLUMN].Visible = false;
		}
		else
		{
			grdRackGroupMaster.Columns[SELECT_COLUMN].Visible = true;
			grdRackGroupMaster.Columns[ACTIVATE_COLUMN].Visible = false;
			grdRackGroupMaster.Columns[DELETE_COLUMN].Visible = true;
		}
	}
	#endregion

	#region Grid Events and Functions
	protected void grdRackGroupMaster_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			objRackGroupMaster = SelectRecordById(grdRackGroupMaster.SelectedIndex);
			if (!objRackGroupMaster.DbOperationStatus.Equals(CommonConstant.FAIL))
			{
				if(!Convert.ToBoolean(objRackGroupMaster.IsRecordChanged))
				{
					ActivateControlsView(false, objRackGroupMaster, grdRackGroupMaster.SelectedIndex);
				}
				else
				{
					UIUtility.DisplayMessage(lblMessage, objRackGroupMaster.DbOperationStatus);
					InitializeForm();
				}
			}
			else
			{
				UIUtility.DisplayMessage(lblMessage, objRackGroupMaster.DbOperationStatus);
			}
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdRackGroupMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			objRackGroupMasterBL = new RackGroupMasterBL();
			objRackGroupMaster = GetObjectForActivateDeactivate(e.RowIndex,RecordStatus.InActive);
			objRackGroupMaster = objRackGroupMasterBL.ActivateDeactivateRackGroupMaster(objRackGroupMaster);
			UIUtility.DisplayMessage(lblMessage, objRackGroupMaster.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdRackGroupMaster_ActivatingObject(object sender, GridViewEditEventArgs e)
	{
		try
		{
			objRackGroupMasterBL = new RackGroupMasterBL();
			objRackGroupMaster = GetObjectForActivateDeactivate(e.NewEditIndex, RecordStatus.Active);
			objRackGroupMaster = objRackGroupMasterBL.ActivateDeactivateRackGroupMaster(objRackGroupMaster);
			UIUtility.DisplayMessage(lblMessage, objRackGroupMaster.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdRackGroupMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			grdRackGroupMaster.PageIndex = e.NewPageIndex;
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected RackGroupMaster BindRackGroupMasterGrid(RecordStatus objRecordStatus)
	{
		objRackGroupMasterBL = new RackGroupMasterBL();
		objRackGroupMaster = new RackGroupMaster();
		objRackGroupMaster.RecordStatus = Convert.ToInt16(objRecordStatus);

		objRackGroupMaster = objRackGroupMasterBL.SelectRackGroupMaster(objRackGroupMaster);
		if (objRackGroupMaster.DbOperationStatus == CommonConstant.SUCCEED)
		{
			grdRackGroupMaster.DataSource = objRackGroupMaster.ObjectDataSet.Tables[0];
			grdRackGroupMaster.DataBind();
		}
		return objRackGroupMaster;
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
				objRackGroupMaster = GetObjectForInsertUpdate();
				objRackGroupMasterBL = new RackGroupMasterBL();
				if (objRackGroupMaster.RackGroupId == null)
				{
					objRackGroupMaster = objRackGroupMasterBL.InsertRackGroupMaster(objRackGroupMaster);
				}
				else
				{
					objRackGroupMaster = objRackGroupMasterBL.UpdateRackGroupMaster(objRackGroupMaster);
				}
				if (objRackGroupMaster.DbOperationStatus == CommonConstant.SUCCEED
							|| objRackGroupMaster.DbOperationStatus == CommonConstant.INVALID)
				{
					InitializeForm();
					MultiViewRackGroupMaster.ActiveViewIndex = 0;
				}
				UIUtility.DisplayMessage(lblMessage, objRackGroupMaster.DbOperationStatus);
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
			MultiViewRackGroupMaster.ActiveViewIndex = 0;
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
	protected void BindRackGroupMasterControls()
	{
		if (!Convert.ToBoolean(ViewState[isControlsLoaded]))
		{
			ViewState[isControlsLoaded] = true;
		}
	}
	protected void ActivateControlsView(bool isNewRecord, RackGroupMaster objRackGroupMaster,int? editIndex)
	{
		if (isNewRecord)
		{
			ViewState[editIndexKey] = null;
			BindRackGroupMasterControls();
			UIUtility.InitializeControls(ViewRackGroupMasterControls);
		}
		else
		{
			ViewState[editIndexKey] = editIndex;
			BindRackGroupMasterControls();
			PopulateControlsData(objRackGroupMaster);
		}
		MultiViewRackGroupMaster.ActiveViewIndex = 1;
	}
	private void PopulateControlsData(RackGroupMaster objRackGroupMaster)
	{
		txtRackGroupName.Text = objRackGroupMaster.RackGroupName;
		txtDescription.Text = objRackGroupMaster.Description;
	}
	#endregion

	#region Helper Functions
	private bool ValidateObject()
	{
		return true;
	}
	private RackGroupMaster GetObjectForInsertUpdate()
	{
		objRackGroupMaster = new RackGroupMaster();

		if (ViewState[editIndexKey] == null)
		{
			objRackGroupMaster.Version = BusinessUtility.RECORD_VERSION;
			objRackGroupMaster.CreatedBy = LoggedInUser;
			objRackGroupMaster.CreatedOn = GeneralUtility.CurrentDateTime;
		}
		else
		{
			objRackGroupMaster.RackGroupId = Convert.ToInt32(grdRackGroupMaster.DataKeys[Convert.ToInt32(ViewState[editIndexKey])].Values[RACK_GROUP_ID_INDEX].ToString());
			objRackGroupMaster.Version = Convert.ToInt16(grdRackGroupMaster.DataKeys[Convert.ToInt16(ViewState[editIndexKey])].Values[VERSION_INDEX].ToString()) + 1;
		}

		objRackGroupMaster.RackGroupName = txtRackGroupName.Text;
		objRackGroupMaster.Description = txtDescription.Text;
		objRackGroupMaster.ModifiedBy = LoggedInUser;
		objRackGroupMaster.ModifiedOn = GeneralUtility.CurrentDateTime;
		objRackGroupMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
		return objRackGroupMaster;
	}
	private RackGroupMaster GetObjectForActivateDeactivate(int editIndex,RecordStatus objStatus)
	{
		objRackGroupMaster = new RackGroupMaster();
		objRackGroupMaster.RackGroupId = Convert.ToInt32(grdRackGroupMaster.DataKeys[editIndex].Values[RACK_GROUP_ID_INDEX].ToString());
		objRackGroupMaster.Version = Convert.ToInt16(grdRackGroupMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString()) + 1;
		objRackGroupMaster.ModifiedBy = LoggedInUser;
		objRackGroupMaster.RecordStatus = Convert.ToInt16(objStatus);
		return objRackGroupMaster;
	}
	private RackGroupMaster SelectRecordById(int editIndex)
	{
		objRackGroupMasterBL = new RackGroupMasterBL();
		objRackGroupMaster = new RackGroupMaster();
		objRackGroupMaster.RackGroupId = Convert.ToInt32(grdRackGroupMaster.DataKeys[editIndex].Values[RACK_GROUP_ID_INDEX].ToString());
		objRackGroupMaster.Version = Convert.ToInt16(grdRackGroupMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString());
		objRackGroupMaster = objRackGroupMasterBL.SelectRecordById(objRackGroupMaster);
		return objRackGroupMaster;
	}
	#endregion
}
