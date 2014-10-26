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

public partial class StateMasterUI : BasePage
{
	#region Page Variables
	StateMaster objStateMaster = null;
	StateMasterBL objStateMasterBL = null;
	CountryMaster objCountryMaster = null;
	CountryMasterBL objCountryMasterBL = null;

	private const int SELECT_COLUMN = 0;
	private const int ACTIVATE_COLUMN = 1;
	private const int DELETE_COLUMN = 2;

	private const int STATE_ID_INDEX = 0;
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
			objStateMaster = BindStateMasterGrid(RecordStatus.Active);
			if (objStateMaster.DbOperationStatus != CommonConstant.SUCCEED)
			{
				btnAddNewRecord.Enabled = false;
				UIUtility.DisplayMessage(lblMessage, objStateMaster.DbOperationStatus);
				return;
			}

			ViewState[isControlsLoaded] = false;

			if (grdStateMaster.Rows.Count == 0)
			{
				BindStateMasterControls();
				MultiViewStateMaster.ActiveViewIndex = 1;
			}
		}
		else
		{
			if (rdbActiveRecord.Checked)
			{
				objStateMaster = BindStateMasterGrid(RecordStatus.Active);
				if (objStateMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objStateMaster.DbOperationStatus);
					return;
				}
				ViewActivateColumn(false);
			}
			else
			{
				objStateMaster = BindStateMasterGrid(RecordStatus.InActive);
				if (objStateMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objStateMaster.DbOperationStatus);
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
			grdStateMaster.Columns[SELECT_COLUMN].Visible = false;
			grdStateMaster.Columns[ACTIVATE_COLUMN].Visible = true;
			grdStateMaster.Columns[DELETE_COLUMN].Visible = false;
		}
		else
		{
			grdStateMaster.Columns[SELECT_COLUMN].Visible = true;
			grdStateMaster.Columns[ACTIVATE_COLUMN].Visible = false;
			grdStateMaster.Columns[DELETE_COLUMN].Visible = true;
		}
	}
	#endregion

	#region Grid Events and Functions
	protected void grdStateMaster_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			objStateMaster = SelectRecordById(grdStateMaster.SelectedIndex);
			if (!objStateMaster.DbOperationStatus.Equals(CommonConstant.FAIL))
			{
				if(!Convert.ToBoolean(objStateMaster.IsRecordChanged))
				{
					ActivateControlsView(false, objStateMaster, grdStateMaster.SelectedIndex);
				}
				else
				{
					UIUtility.DisplayMessage(lblMessage, objStateMaster.DbOperationStatus);
					InitializeForm();
				}
			}
			else
			{
				UIUtility.DisplayMessage(lblMessage, objStateMaster.DbOperationStatus);
			}
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdStateMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			objStateMasterBL = new StateMasterBL();
			objStateMaster = GetObjectForActivateDeactivate(e.RowIndex,RecordStatus.InActive);
			objStateMaster = objStateMasterBL.ActivateDeactivateStateMaster(objStateMaster);
			UIUtility.DisplayMessage(lblMessage, objStateMaster.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdStateMaster_ActivatingObject(object sender, GridViewEditEventArgs e)
	{
		try
		{
			objStateMasterBL = new StateMasterBL();
			objStateMaster = GetObjectForActivateDeactivate(e.NewEditIndex, RecordStatus.Active);
			objStateMaster = objStateMasterBL.ActivateDeactivateStateMaster(objStateMaster);
			UIUtility.DisplayMessage(lblMessage, objStateMaster.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdStateMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			grdStateMaster.PageIndex = e.NewPageIndex;
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected StateMaster BindStateMasterGrid(RecordStatus objRecordStatus)
	{
		objStateMasterBL = new StateMasterBL();
		objStateMaster = new StateMaster();
		objStateMaster.RecordStatus = Convert.ToInt16(objRecordStatus);

		objStateMaster = objStateMasterBL.SelectStateMaster(objStateMaster);
		if (objStateMaster.DbOperationStatus == CommonConstant.SUCCEED)
		{
			grdStateMaster.DataSource = objStateMaster.ObjectDataSet.Tables[0];
			grdStateMaster.DataBind();
		}
		return objStateMaster;
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
				objStateMaster = GetObjectForInsertUpdate();
				objStateMasterBL = new StateMasterBL();
				if (objStateMaster.StateId == null)
				{
					objStateMaster = objStateMasterBL.InsertStateMaster(objStateMaster);
				}
				else
				{
					objStateMaster = objStateMasterBL.UpdateStateMaster(objStateMaster);
				}
				if (objStateMaster.DbOperationStatus == CommonConstant.SUCCEED
							|| objStateMaster.DbOperationStatus == CommonConstant.INVALID)
				{
					InitializeForm();
					MultiViewStateMaster.ActiveViewIndex = 0;
				}
				UIUtility.DisplayMessage(lblMessage, objStateMaster.DbOperationStatus);
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
			MultiViewStateMaster.ActiveViewIndex = 0;
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
	protected void BindStateMasterControls()
	{
		if (!Convert.ToBoolean(ViewState[isControlsLoaded]))
		{
			objCountryMasterBL = new CountryMasterBL();
			objCountryMaster = new CountryMaster();
			objCountryMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
			objCountryMaster = objCountryMasterBL.SelectCountryMaster(objCountryMaster);
			ddlCountry.DataSource = objCountryMaster.ObjectDataSet.Tables[0];
			ddlCountry.DataBind();
			ddlCountry.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

			ViewState[isControlsLoaded] = true;
		}
	}
	protected void ActivateControlsView(bool isNewRecord, StateMaster objStateMaster,int? editIndex)
	{
		if (isNewRecord)
		{
			ViewState[editIndexKey] = null;
			BindStateMasterControls();
			UIUtility.InitializeControls(ViewStateMasterControls);
		}
		else
		{
			ViewState[editIndexKey] = editIndex;
			BindStateMasterControls();
			PopulateControlsData(objStateMaster);
		}
		MultiViewStateMaster.ActiveViewIndex = 1;
	}
	private void PopulateControlsData(StateMaster objStateMaster)
	{
		txtStateName.Text = objStateMaster.StateName;
		UIUtility.SelectCurrentListItem(ddlCountry, objStateMaster.CountryObject.CountryId, BindListItem.ByValue, true);
		txtDescription.Text = objStateMaster.Description;
	}
	#endregion

	#region Helper Functions
	private bool ValidateObject()
	{
		return true;
	}
	private StateMaster GetObjectForInsertUpdate()
	{
		objStateMaster = new StateMaster();

		if (ViewState[editIndexKey] == null)
		{
			objStateMaster.Version = BusinessUtility.RECORD_VERSION;
			objStateMaster.CreatedBy = LoggedInUser;
			objStateMaster.CreatedOn = GeneralUtility.CurrentDateTime;
		}
		else
		{
			objStateMaster.StateId = Convert.ToInt32(grdStateMaster.DataKeys[Convert.ToInt32(ViewState[editIndexKey])].Values[STATE_ID_INDEX].ToString());
			objStateMaster.Version = Convert.ToInt16(grdStateMaster.DataKeys[Convert.ToInt16(ViewState[editIndexKey])].Values[VERSION_INDEX].ToString()) + 1;
		}

		objStateMaster.StateName = txtStateName.Text;
		if (ddlCountry.SelectedIndex != 0)
		{
			objStateMaster.CountryObject = new CountryMaster();
			objStateMaster.CountryObject.CountryId = Convert.ToInt32(ddlCountry.SelectedItem.Value);
		}
		objStateMaster.Description = txtDescription.Text;
		objStateMaster.ModifiedBy = LoggedInUser;
		objStateMaster.ModifiedOn = GeneralUtility.CurrentDateTime;
		objStateMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
		return objStateMaster;
	}
	private StateMaster GetObjectForActivateDeactivate(int editIndex,RecordStatus objStatus)
	{
		objStateMaster = new StateMaster();
		objStateMaster.StateId = Convert.ToInt32(grdStateMaster.DataKeys[editIndex].Values[STATE_ID_INDEX].ToString());
		objStateMaster.Version = Convert.ToInt16(grdStateMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString()) + 1;
		objStateMaster.ModifiedBy = LoggedInUser;
		objStateMaster.RecordStatus = Convert.ToInt16(objStatus);
		return objStateMaster;
	}
	private StateMaster SelectRecordById(int editIndex)
	{
		objStateMasterBL = new StateMasterBL();
		objStateMaster = new StateMaster();
		objStateMaster.StateId = Convert.ToInt32(grdStateMaster.DataKeys[editIndex].Values[STATE_ID_INDEX].ToString());
		objStateMaster.Version = Convert.ToInt16(grdStateMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString());
		objStateMaster = objStateMasterBL.SelectRecordById(objStateMaster);
		return objStateMaster;
	}
	#endregion
}
