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

public partial class RoomMasterUI : BasePage
{
	#region Page Variables
	RoomMaster objRoomMaster = null;
	RoomMasterBL objRoomMasterBL = null;
	MetadataMaster objMetadataMaster = null;
	MetadataMasterBL objMetadataMasterBL = null;

	private const int SELECT_COLUMN = 0;
	private const int ACTIVATE_COLUMN = 1;
	private const int DELETE_COLUMN = 2;

	private const int ROOM_ID_INDEX = 0;
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
			objRoomMaster = BindRoomMasterGrid(RecordStatus.Active);
			if (objRoomMaster.DbOperationStatus != CommonConstant.SUCCEED)
			{
				btnAddNewRecord.Enabled = false;
				UIUtility.DisplayMessage(lblMessage, objRoomMaster.DbOperationStatus);
				return;
			}

			ViewState[isControlsLoaded] = false;

			if (grdRoomMaster.Rows.Count == 0)
			{
				BindRoomMasterControls();
				MultiViewRoomMaster.ActiveViewIndex = 1;
			}
		}
		else
		{
			if (rdbActiveRecord.Checked)
			{
				objRoomMaster = BindRoomMasterGrid(RecordStatus.Active);
				if (objRoomMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objRoomMaster.DbOperationStatus);
					return;
				}
				ViewActivateColumn(false);
			}
			else
			{
				objRoomMaster = BindRoomMasterGrid(RecordStatus.InActive);
				if (objRoomMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objRoomMaster.DbOperationStatus);
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
			grdRoomMaster.Columns[SELECT_COLUMN].Visible = false;
			grdRoomMaster.Columns[ACTIVATE_COLUMN].Visible = true;
			grdRoomMaster.Columns[DELETE_COLUMN].Visible = false;
		}
		else
		{
			grdRoomMaster.Columns[SELECT_COLUMN].Visible = true;
			grdRoomMaster.Columns[ACTIVATE_COLUMN].Visible = false;
			grdRoomMaster.Columns[DELETE_COLUMN].Visible = true;
		}
	}
	#endregion

	#region Grid Events and Functions
	protected void grdRoomMaster_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			objRoomMaster = SelectRecordById(grdRoomMaster.SelectedIndex);
			if (!objRoomMaster.DbOperationStatus.Equals(CommonConstant.FAIL))
			{
				if(!Convert.ToBoolean(objRoomMaster.IsRecordChanged))
				{
					ActivateControlsView(false, objRoomMaster, grdRoomMaster.SelectedIndex);
				}
				else
				{
					UIUtility.DisplayMessage(lblMessage, objRoomMaster.DbOperationStatus);
					InitializeForm();
				}
			}
			else
			{
				UIUtility.DisplayMessage(lblMessage, objRoomMaster.DbOperationStatus);
			}
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdRoomMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			objRoomMasterBL = new RoomMasterBL();
			objRoomMaster = GetObjectForActivateDeactivate(e.RowIndex,RecordStatus.InActive);
			objRoomMaster = objRoomMasterBL.ActivateDeactivateRoomMaster(objRoomMaster);
			UIUtility.DisplayMessage(lblMessage, objRoomMaster.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdRoomMaster_ActivatingObject(object sender, GridViewEditEventArgs e)
	{
		try
		{
			objRoomMasterBL = new RoomMasterBL();
			objRoomMaster = GetObjectForActivateDeactivate(e.NewEditIndex, RecordStatus.Active);
			objRoomMaster = objRoomMasterBL.ActivateDeactivateRoomMaster(objRoomMaster);
			UIUtility.DisplayMessage(lblMessage, objRoomMaster.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdRoomMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			grdRoomMaster.PageIndex = e.NewPageIndex;
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected RoomMaster BindRoomMasterGrid(RecordStatus objRecordStatus)
	{
		objRoomMasterBL = new RoomMasterBL();
		objRoomMaster = new RoomMaster();
		objRoomMaster.RecordStatus = Convert.ToInt16(objRecordStatus);

		objRoomMaster = objRoomMasterBL.SelectRoomMaster(objRoomMaster);
		if (objRoomMaster.DbOperationStatus == CommonConstant.SUCCEED)
		{
			grdRoomMaster.DataSource = objRoomMaster.ObjectDataSet.Tables[0];
			grdRoomMaster.DataBind();
		}
		return objRoomMaster;
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
				objRoomMaster = GetObjectForInsertUpdate();
				objRoomMasterBL = new RoomMasterBL();
				if (objRoomMaster.RoomId == null)
				{
					objRoomMaster = objRoomMasterBL.InsertRoomMaster(objRoomMaster);
				}
				else
				{
					objRoomMaster = objRoomMasterBL.UpdateRoomMaster(objRoomMaster);
				}
				if (objRoomMaster.DbOperationStatus == CommonConstant.SUCCEED
							|| objRoomMaster.DbOperationStatus == CommonConstant.INVALID)
				{
					InitializeForm();
					MultiViewRoomMaster.ActiveViewIndex = 0;
				}
				UIUtility.DisplayMessage(lblMessage, objRoomMaster.DbOperationStatus);
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
			MultiViewRoomMaster.ActiveViewIndex = 0;
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
	protected void BindRoomMasterControls()
	{
		if (!Convert.ToBoolean(ViewState[isControlsLoaded]))
		{
			objMetadataMasterBL = new MetadataMasterBL();
			objMetadataMaster = new MetadataMaster();
			objMetadataMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
			objMetadataMaster = objMetadataMasterBL.SelectMetadataMaster(objMetadataMaster);
			ddlRoom.DataSource = objMetadataMaster.ObjectDataSet.Tables[0];
			ddlRoom.DataBind();
			ddlRoom.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

			ViewState[isControlsLoaded] = true;
		}
	}
	protected void ActivateControlsView(bool isNewRecord, RoomMaster objRoomMaster,int? editIndex)
	{
		if (isNewRecord)
		{
			ViewState[editIndexKey] = null;
			BindRoomMasterControls();
			UIUtility.InitializeControls(ViewRoomMasterControls);
		}
		else
		{
			ViewState[editIndexKey] = editIndex;
			BindRoomMasterControls();
			PopulateControlsData(objRoomMaster);
		}
		MultiViewRoomMaster.ActiveViewIndex = 1;
	}
	private void PopulateControlsData(RoomMaster objRoomMaster)
	{
		txtRoomName.Text = objRoomMaster.RoomName;
		UIUtility.SelectCurrentListItem(ddlRoom, objRoomMaster.RoomTypeObject.MetadataId, BindListItem.ByValue, true);
		txtSittingCapacity.Text = objRoomMaster.SittingCapacity.ToString();
		txtDescription.Text = objRoomMaster.Description;
	}
	#endregion

	#region Helper Functions
	private bool ValidateObject()
	{
		return true;
	}
	private RoomMaster GetObjectForInsertUpdate()
	{
		objRoomMaster = new RoomMaster();

		if (ViewState[editIndexKey] == null)
		{
			objRoomMaster.Version = BusinessUtility.RECORD_VERSION;
			objRoomMaster.CreatedBy = LoggedInUser;
			objRoomMaster.CreatedOn = GeneralUtility.CurrentDateTime;
		}
		else
		{
			objRoomMaster.RoomId = Convert.ToInt32(grdRoomMaster.DataKeys[Convert.ToInt32(ViewState[editIndexKey])].Values[ROOM_ID_INDEX].ToString());
			objRoomMaster.Version = Convert.ToInt16(grdRoomMaster.DataKeys[Convert.ToInt16(ViewState[editIndexKey])].Values[VERSION_INDEX].ToString()) + 1;
		}

		objRoomMaster.RoomName = txtRoomName.Text;
		if (ddlRoom.SelectedIndex != 0)
		{
			objRoomMaster.RoomTypeObject = new MetadataMaster();
			objRoomMaster.RoomTypeObject.MetadataId = Convert.ToInt32(ddlRoom.SelectedItem.Value);
		}
		objRoomMaster.SittingCapacity = Convert.ToInt32(txtSittingCapacity.Text);
		objRoomMaster.Description = txtDescription.Text;
		objRoomMaster.ModifiedBy = LoggedInUser;
		objRoomMaster.ModifiedOn = GeneralUtility.CurrentDateTime;
		objRoomMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
		return objRoomMaster;
	}
	private RoomMaster GetObjectForActivateDeactivate(int editIndex,RecordStatus objStatus)
	{
		objRoomMaster = new RoomMaster();
		objRoomMaster.RoomId = Convert.ToInt32(grdRoomMaster.DataKeys[editIndex].Values[ROOM_ID_INDEX].ToString());
		objRoomMaster.Version = Convert.ToInt16(grdRoomMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString()) + 1;
		objRoomMaster.ModifiedBy = LoggedInUser;
		objRoomMaster.RecordStatus = Convert.ToInt16(objStatus);
		return objRoomMaster;
	}
	private RoomMaster SelectRecordById(int editIndex)
	{
		objRoomMasterBL = new RoomMasterBL();
		objRoomMaster = new RoomMaster();
		objRoomMaster.RoomId = Convert.ToInt32(grdRoomMaster.DataKeys[editIndex].Values[ROOM_ID_INDEX].ToString());
		objRoomMaster.Version = Convert.ToInt16(grdRoomMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString());
		objRoomMaster = objRoomMasterBL.SelectRecordById(objRoomMaster);
		return objRoomMaster;
	}
	#endregion
}
