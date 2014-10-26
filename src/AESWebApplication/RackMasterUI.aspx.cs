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

public partial class RackMasterUI : BasePage
{
	#region Page Variables
	RackMaster objRackMaster = null;
	RackMasterBL objRackMasterBL = null;
	RackGroupMaster objRackGroupMaster = null;
	RackGroupMasterBL objRackGroupMasterBL = null;

	private const int SELECT_COLUMN = 0;
	private const int ACTIVATE_COLUMN = 1;
	private const int DELETE_COLUMN = 2;

	private const int RACK_ID_INDEX = 0;
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
			objRackMaster = BindRackMasterGrid(RecordStatus.Active);
			if (objRackMaster.DbOperationStatus != CommonConstant.SUCCEED)
			{
				btnAddNewRecord.Enabled = false;
				UIUtility.DisplayMessage(lblMessage, objRackMaster.DbOperationStatus);
				return;
			}

			ViewState[isControlsLoaded] = false;

			if (grdRackMaster.Rows.Count == 0)
			{
				BindRackMasterControls();
				MultiViewRackMaster.ActiveViewIndex = 1;
			}
		}
		else
		{
			if (rdbActiveRecord.Checked)
			{
				objRackMaster = BindRackMasterGrid(RecordStatus.Active);
				if (objRackMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objRackMaster.DbOperationStatus);
					return;
				}
				ViewActivateColumn(false);
			}
			else
			{
				objRackMaster = BindRackMasterGrid(RecordStatus.InActive);
				if (objRackMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objRackMaster.DbOperationStatus);
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
			grdRackMaster.Columns[SELECT_COLUMN].Visible = false;
			grdRackMaster.Columns[ACTIVATE_COLUMN].Visible = true;
			grdRackMaster.Columns[DELETE_COLUMN].Visible = false;
		}
		else
		{
			grdRackMaster.Columns[SELECT_COLUMN].Visible = true;
			grdRackMaster.Columns[ACTIVATE_COLUMN].Visible = false;
			grdRackMaster.Columns[DELETE_COLUMN].Visible = true;
		}
	}
	#endregion

	#region Grid Events and Functions
	protected void grdRackMaster_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			objRackMaster = SelectRecordById(grdRackMaster.SelectedIndex);
			if (!objRackMaster.DbOperationStatus.Equals(CommonConstant.FAIL))
			{
				if(!Convert.ToBoolean(objRackMaster.IsRecordChanged))
				{
					ActivateControlsView(false, objRackMaster, grdRackMaster.SelectedIndex);
				}
				else
				{
					UIUtility.DisplayMessage(lblMessage, objRackMaster.DbOperationStatus);
					InitializeForm();
				}
			}
			else
			{
				UIUtility.DisplayMessage(lblMessage, objRackMaster.DbOperationStatus);
			}
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdRackMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			objRackMasterBL = new RackMasterBL();
			objRackMaster = GetObjectForActivateDeactivate(e.RowIndex,RecordStatus.InActive);
			objRackMaster = objRackMasterBL.ActivateDeactivateRackMaster(objRackMaster);
			UIUtility.DisplayMessage(lblMessage, objRackMaster.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdRackMaster_ActivatingObject(object sender, GridViewEditEventArgs e)
	{
		try
		{
			objRackMasterBL = new RackMasterBL();
			objRackMaster = GetObjectForActivateDeactivate(e.NewEditIndex, RecordStatus.Active);
			objRackMaster = objRackMasterBL.ActivateDeactivateRackMaster(objRackMaster);
			UIUtility.DisplayMessage(lblMessage, objRackMaster.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdRackMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			grdRackMaster.PageIndex = e.NewPageIndex;
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected RackMaster BindRackMasterGrid(RecordStatus objRecordStatus)
	{
		objRackMasterBL = new RackMasterBL();
		objRackMaster = new RackMaster();
		objRackMaster.RecordStatus = Convert.ToInt16(objRecordStatus);

		objRackMaster = objRackMasterBL.SelectRackMaster(objRackMaster);
		if (objRackMaster.DbOperationStatus == CommonConstant.SUCCEED)
		{
			grdRackMaster.DataSource = objRackMaster.ObjectDataSet.Tables[0];
			grdRackMaster.DataBind();
		}
		return objRackMaster;
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
				objRackMaster = GetObjectForInsertUpdate();
				objRackMasterBL = new RackMasterBL();
				if (objRackMaster.RackId == null)
				{
					objRackMaster = objRackMasterBL.InsertRackMaster(objRackMaster);
				}
				else
				{
					objRackMaster = objRackMasterBL.UpdateRackMaster(objRackMaster);
				}
				if (objRackMaster.DbOperationStatus == CommonConstant.SUCCEED
							|| objRackMaster.DbOperationStatus == CommonConstant.INVALID)
				{
					InitializeForm();
					MultiViewRackMaster.ActiveViewIndex = 0;
				}
				UIUtility.DisplayMessage(lblMessage, objRackMaster.DbOperationStatus);
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
			MultiViewRackMaster.ActiveViewIndex = 0;
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
	protected void BindRackMasterControls()
	{
		if (!Convert.ToBoolean(ViewState[isControlsLoaded]))
		{
			objRackGroupMasterBL = new RackGroupMasterBL();
			objRackGroupMaster = new RackGroupMaster();
			objRackGroupMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
			objRackGroupMaster = objRackGroupMasterBL.SelectRackGroupMaster(objRackGroupMaster);
			ddlRack.DataSource = objRackGroupMaster.ObjectDataSet.Tables[0];
			ddlRack.DataBind();
			ddlRack.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

			ViewState[isControlsLoaded] = true;
		}
	}
	protected void ActivateControlsView(bool isNewRecord, RackMaster objRackMaster,int? editIndex)
	{
		if (isNewRecord)
		{
			ViewState[editIndexKey] = null;
			BindRackMasterControls();
			UIUtility.InitializeControls(ViewRackMasterControls);
		}
		else
		{
			ViewState[editIndexKey] = editIndex;
			BindRackMasterControls();
			PopulateControlsData(objRackMaster);
		}
		MultiViewRackMaster.ActiveViewIndex = 1;
	}
	private void PopulateControlsData(RackMaster objRackMaster)
	{
		txtRackCode.Text = objRackMaster.RackCode;
		txtNoOfRows.Text = objRackMaster.NoOfRows.ToString();
		txtNoOfColumns.Text = objRackMaster.NoOfColumns.ToString();
		UIUtility.SelectCurrentListItem(ddlRack, objRackMaster.RackGroupObject.RackGroupId, BindListItem.ByValue, true);
		txtDescripition.Text = objRackMaster.Descripition;
	}
	#endregion

	#region Helper Functions
	private bool ValidateObject()
	{
		return true;
	}
	private RackMaster GetObjectForInsertUpdate()
	{
		objRackMaster = new RackMaster();

		if (ViewState[editIndexKey] == null)
		{
			objRackMaster.Version = BusinessUtility.RECORD_VERSION;
			objRackMaster.CreatedBy = LoggedInUser;
			objRackMaster.CreatedOn = GeneralUtility.CurrentDateTime;
		}
		else
		{
			objRackMaster.RackId = Convert.ToInt32(grdRackMaster.DataKeys[Convert.ToInt32(ViewState[editIndexKey])].Values[RACK_ID_INDEX].ToString());
			objRackMaster.Version = Convert.ToInt16(grdRackMaster.DataKeys[Convert.ToInt16(ViewState[editIndexKey])].Values[VERSION_INDEX].ToString()) + 1;
		}

		objRackMaster.RackCode = txtRackCode.Text;
		objRackMaster.NoOfRows = Convert.ToInt32(txtNoOfRows.Text);
		objRackMaster.NoOfColumns = Convert.ToInt32(txtNoOfColumns.Text);
		if (ddlRack.SelectedIndex != 0)
		{
			objRackMaster.RackGroupObject = new RackGroupMaster();
			objRackMaster.RackGroupObject.RackGroupId = Convert.ToInt32(ddlRack.SelectedItem.Value);
		}
		objRackMaster.Descripition = txtDescripition.Text;
		objRackMaster.ModifiedBy = LoggedInUser;
		objRackMaster.ModifiedOn = GeneralUtility.CurrentDateTime;
		objRackMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
		return objRackMaster;
	}
	private RackMaster GetObjectForActivateDeactivate(int editIndex,RecordStatus objStatus)
	{
		objRackMaster = new RackMaster();
		objRackMaster.RackId = Convert.ToInt32(grdRackMaster.DataKeys[editIndex].Values[RACK_ID_INDEX].ToString());
		objRackMaster.Version = Convert.ToInt16(grdRackMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString()) + 1;
		objRackMaster.ModifiedBy = LoggedInUser;
		objRackMaster.RecordStatus = Convert.ToInt16(objStatus);
		return objRackMaster;
	}
	private RackMaster SelectRecordById(int editIndex)
	{
		objRackMasterBL = new RackMasterBL();
		objRackMaster = new RackMaster();
		objRackMaster.RackId = Convert.ToInt32(grdRackMaster.DataKeys[editIndex].Values[RACK_ID_INDEX].ToString());
		objRackMaster.Version = Convert.ToInt16(grdRackMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString());
		objRackMaster = objRackMasterBL.SelectRecordById(objRackMaster);
		return objRackMaster;
	}
	#endregion
}
