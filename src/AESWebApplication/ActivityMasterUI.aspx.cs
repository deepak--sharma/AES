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

public partial class ActivityMasterUI : BasePage
{
	#region Page Variables
	ActivityMaster objActivityMaster = null;
	ActivityMasterBL objActivityMasterBL = null;

	private const int SELECT_COLUMN = 0;
	private const int ACTIVATE_COLUMN = 1;
	private const int DELETE_COLUMN = 2;

	private const int ACTIVITY_ID_INDEX = 0;
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
			objActivityMaster = BindActivityMasterGrid(RecordStatus.Active);
			if (objActivityMaster.DbOperationStatus != CommonConstant.SUCCEED)
			{
				btnAddNewRecord.Enabled = false;
				UIUtility.DisplayMessage(lblMessage, objActivityMaster.DbOperationStatus);
				return;
			}

			ViewState[isControlsLoaded] = false;

			if (grdActivityMaster.Rows.Count == 0)
			{
				BindActivityMasterControls();
				MultiViewActivityMaster.ActiveViewIndex = 1;
			}
		}
		else
		{
			if (rdbActiveRecord.Checked)
			{
				objActivityMaster = BindActivityMasterGrid(RecordStatus.Active);
				if (objActivityMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objActivityMaster.DbOperationStatus);
					return;
				}
				ViewActivateColumn(false);
			}
			else
			{
				objActivityMaster = BindActivityMasterGrid(RecordStatus.InActive);
				if (objActivityMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objActivityMaster.DbOperationStatus);
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
			grdActivityMaster.Columns[SELECT_COLUMN].Visible = false;
			grdActivityMaster.Columns[ACTIVATE_COLUMN].Visible = true;
			grdActivityMaster.Columns[DELETE_COLUMN].Visible = false;
		}
		else
		{
			grdActivityMaster.Columns[SELECT_COLUMN].Visible = true;
			grdActivityMaster.Columns[ACTIVATE_COLUMN].Visible = false;
			grdActivityMaster.Columns[DELETE_COLUMN].Visible = true;
		}
	}
	#endregion

	#region Grid Events and Functions
	protected void grdActivityMaster_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			objActivityMaster = SelectRecordById(grdActivityMaster.SelectedIndex);
			if (!objActivityMaster.DbOperationStatus.Equals(CommonConstant.FAIL))
			{
				if(!Convert.ToBoolean(objActivityMaster.IsRecordChanged))
				{
					ActivateControlsView(false, objActivityMaster, grdActivityMaster.SelectedIndex);
				}
				else
				{
					UIUtility.DisplayMessage(lblMessage, objActivityMaster.DbOperationStatus);
					InitializeForm();
				}
			}
			else
			{
				UIUtility.DisplayMessage(lblMessage, objActivityMaster.DbOperationStatus);
			}
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdActivityMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			objActivityMasterBL = new ActivityMasterBL();
			objActivityMaster = GetObjectForActivateDeactivate(e.RowIndex,RecordStatus.InActive);
			objActivityMaster = objActivityMasterBL.ActivateDeactivateActivityMaster(objActivityMaster);
			UIUtility.DisplayMessage(lblMessage, objActivityMaster.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdActivityMaster_ActivatingObject(object sender, GridViewEditEventArgs e)
	{
		try
		{
			objActivityMasterBL = new ActivityMasterBL();
			objActivityMaster = GetObjectForActivateDeactivate(e.NewEditIndex, RecordStatus.Active);
			objActivityMaster = objActivityMasterBL.ActivateDeactivateActivityMaster(objActivityMaster);
			UIUtility.DisplayMessage(lblMessage, objActivityMaster.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdActivityMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			grdActivityMaster.PageIndex = e.NewPageIndex;
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected ActivityMaster BindActivityMasterGrid(RecordStatus objRecordStatus)
	{
		objActivityMasterBL = new ActivityMasterBL();
		objActivityMaster = new ActivityMaster();
		objActivityMaster.RecordStatus = Convert.ToInt16(objRecordStatus);

		objActivityMaster = objActivityMasterBL.SelectActivityMaster(objActivityMaster);
		if (objActivityMaster.DbOperationStatus == CommonConstant.SUCCEED)
		{
			grdActivityMaster.DataSource = objActivityMaster.ObjectDataSet.Tables[0];
			grdActivityMaster.DataBind();
		}
		return objActivityMaster;
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
				objActivityMaster = GetObjectForInsertUpdate();
				objActivityMasterBL = new ActivityMasterBL();
				if (objActivityMaster.ActivityId == null)
				{
					objActivityMaster = objActivityMasterBL.InsertActivityMaster(objActivityMaster);
				}
				else
				{
					objActivityMaster = objActivityMasterBL.UpdateActivityMaster(objActivityMaster);
				}
				if (objActivityMaster.DbOperationStatus == CommonConstant.SUCCEED
							|| objActivityMaster.DbOperationStatus == CommonConstant.INVALID)
				{
					InitializeForm();
					MultiViewActivityMaster.ActiveViewIndex = 0;
				}
				UIUtility.DisplayMessage(lblMessage, objActivityMaster.DbOperationStatus);
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
			MultiViewActivityMaster.ActiveViewIndex = 0;
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
	protected void BindActivityMasterControls()
	{
		if (!Convert.ToBoolean(ViewState[isControlsLoaded]))
		{
			ViewState[isControlsLoaded] = true;
		}
	}
	protected void ActivateControlsView(bool isNewRecord, ActivityMaster objActivityMaster,int? editIndex)
	{
		if (isNewRecord)
		{
			ViewState[editIndexKey] = null;
			BindActivityMasterControls();
			UIUtility.InitializeControls(ViewActivityMasterControls);
		}
		else
		{
			ViewState[editIndexKey] = editIndex;
			BindActivityMasterControls();
			PopulateControlsData(objActivityMaster);
		}
		MultiViewActivityMaster.ActiveViewIndex = 1;
	}
	private void PopulateControlsData(ActivityMaster objActivityMaster)
	{
		txtActivityName.Text = objActivityMaster.ActivityName;
		txtDescription.Text = objActivityMaster.Description;
	}
	#endregion

	#region Helper Functions
	private bool ValidateObject()
	{
		return true;
	}
	private ActivityMaster GetObjectForInsertUpdate()
	{
		objActivityMaster = new ActivityMaster();

		if (ViewState[editIndexKey] == null)
		{
			objActivityMaster.Version = BusinessUtility.RECORD_VERSION;
			objActivityMaster.CreatedBy = LoggedInUser;
			objActivityMaster.CreatedOn = GeneralUtility.CurrentDateTime;
		}
		else
		{
			objActivityMaster.ActivityId = Convert.ToInt32(grdActivityMaster.DataKeys[Convert.ToInt32(ViewState[editIndexKey])].Values[ACTIVITY_ID_INDEX].ToString());
			objActivityMaster.Version = Convert.ToInt16(grdActivityMaster.DataKeys[Convert.ToInt16(ViewState[editIndexKey])].Values[VERSION_INDEX].ToString()) + 1;
		}

		objActivityMaster.ActivityName = txtActivityName.Text;
		objActivityMaster.Description = txtDescription.Text;
		objActivityMaster.ModifiedBy = LoggedInUser;
		objActivityMaster.ModifiedOn = GeneralUtility.CurrentDateTime;
		objActivityMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
		return objActivityMaster;
	}
	private ActivityMaster GetObjectForActivateDeactivate(int editIndex,RecordStatus objStatus)
	{
		objActivityMaster = new ActivityMaster();
		objActivityMaster.ActivityId = Convert.ToInt32(grdActivityMaster.DataKeys[editIndex].Values[ACTIVITY_ID_INDEX].ToString());
		objActivityMaster.Version = Convert.ToInt16(grdActivityMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString()) + 1;
		objActivityMaster.ModifiedBy = LoggedInUser;
		objActivityMaster.RecordStatus = Convert.ToInt16(objStatus);
		return objActivityMaster;
	}
	private ActivityMaster SelectRecordById(int editIndex)
	{
		objActivityMasterBL = new ActivityMasterBL();
		objActivityMaster = new ActivityMaster();
		objActivityMaster.ActivityId = Convert.ToInt32(grdActivityMaster.DataKeys[editIndex].Values[ACTIVITY_ID_INDEX].ToString());
		objActivityMaster.Version = Convert.ToInt16(grdActivityMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString());
		objActivityMaster = objActivityMasterBL.SelectRecordById(objActivityMaster);
		return objActivityMaster;
	}
	#endregion
}
