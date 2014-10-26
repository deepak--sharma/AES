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

public partial class CityMasterUI : BasePage
{
	#region Page Variables
	CityMaster objCityMaster = null;
	CityMasterBL objCityMasterBL = null;
	StateMaster objStateMaster = null;
	StateMasterBL objStateMasterBL = null;

	private const int SELECT_COLUMN = 0;
	private const int ACTIVATE_COLUMN = 1;
	private const int DELETE_COLUMN = 2;

	private const int CITY_ID_INDEX = 0;
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
			objCityMaster = BindCityMasterGrid(RecordStatus.Active);
			if (objCityMaster.DbOperationStatus != CommonConstant.SUCCEED)
			{
				btnAddNewRecord.Enabled = false;
				UIUtility.DisplayMessage(lblMessage, objCityMaster.DbOperationStatus);
				return;
			}

			ViewState[isControlsLoaded] = false;

			if (grdCityMaster.Rows.Count == 0)
			{
				BindCityMasterControls();
				MultiViewCityMaster.ActiveViewIndex = 1;
			}
		}
		else
		{
			if (rdbActiveRecord.Checked)
			{
				objCityMaster = BindCityMasterGrid(RecordStatus.Active);
				if (objCityMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objCityMaster.DbOperationStatus);
					return;
				}
				ViewActivateColumn(false);
			}
			else
			{
				objCityMaster = BindCityMasterGrid(RecordStatus.InActive);
				if (objCityMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objCityMaster.DbOperationStatus);
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
			grdCityMaster.Columns[SELECT_COLUMN].Visible = false;
			grdCityMaster.Columns[ACTIVATE_COLUMN].Visible = true;
			grdCityMaster.Columns[DELETE_COLUMN].Visible = false;
		}
		else
		{
			grdCityMaster.Columns[SELECT_COLUMN].Visible = true;
			grdCityMaster.Columns[ACTIVATE_COLUMN].Visible = false;
			grdCityMaster.Columns[DELETE_COLUMN].Visible = true;
		}
	}
	#endregion

	#region Grid Events and Functions
	protected void grdCityMaster_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			objCityMaster = SelectRecordById(grdCityMaster.SelectedIndex);
			if (!objCityMaster.DbOperationStatus.Equals(CommonConstant.FAIL))
			{
				if(!Convert.ToBoolean(objCityMaster.IsRecordChanged))
				{
					ActivateControlsView(false, objCityMaster, grdCityMaster.SelectedIndex);
				}
				else
				{
					UIUtility.DisplayMessage(lblMessage, objCityMaster.DbOperationStatus);
					InitializeForm();
				}
			}
			else
			{
				UIUtility.DisplayMessage(lblMessage, objCityMaster.DbOperationStatus);
			}
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdCityMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			objCityMasterBL = new CityMasterBL();
			objCityMaster = GetObjectForActivateDeactivate(e.RowIndex,RecordStatus.InActive);
			objCityMaster = objCityMasterBL.ActivateDeactivateCityMaster(objCityMaster);
			UIUtility.DisplayMessage(lblMessage, objCityMaster.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdCityMaster_ActivatingObject(object sender, GridViewEditEventArgs e)
	{
		try
		{
			objCityMasterBL = new CityMasterBL();
			objCityMaster = GetObjectForActivateDeactivate(e.NewEditIndex, RecordStatus.Active);
			objCityMaster = objCityMasterBL.ActivateDeactivateCityMaster(objCityMaster);
			UIUtility.DisplayMessage(lblMessage, objCityMaster.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdCityMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			grdCityMaster.PageIndex = e.NewPageIndex;
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected CityMaster BindCityMasterGrid(RecordStatus objRecordStatus)
	{
		objCityMasterBL = new CityMasterBL();
		objCityMaster = new CityMaster();
		objCityMaster.RecordStatus = Convert.ToInt16(objRecordStatus);

		objCityMaster = objCityMasterBL.SelectCityMaster(objCityMaster);
		if (objCityMaster.DbOperationStatus == CommonConstant.SUCCEED)
		{
			grdCityMaster.DataSource = objCityMaster.ObjectDataSet.Tables[0];
			grdCityMaster.DataBind();
		}
		return objCityMaster;
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
				objCityMaster = GetObjectForInsertUpdate();
				objCityMasterBL = new CityMasterBL();
				if (objCityMaster.CityId == null)
				{
					objCityMaster = objCityMasterBL.InsertCityMaster(objCityMaster);
				}
				else
				{
					objCityMaster = objCityMasterBL.UpdateCityMaster(objCityMaster);
				}
				if (objCityMaster.DbOperationStatus == CommonConstant.SUCCEED
							|| objCityMaster.DbOperationStatus == CommonConstant.INVALID)
				{
					InitializeForm();
					MultiViewCityMaster.ActiveViewIndex = 0;
				}
				UIUtility.DisplayMessage(lblMessage, objCityMaster.DbOperationStatus);
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
			MultiViewCityMaster.ActiveViewIndex = 0;
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
	protected void BindCityMasterControls()
	{
		if (!Convert.ToBoolean(ViewState[isControlsLoaded]))
		{
			objStateMasterBL = new StateMasterBL();
			objStateMaster = new StateMaster();
			objStateMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
			objStateMaster = objStateMasterBL.SelectStateMaster(objStateMaster);
			ddlState.DataSource = objStateMaster.ObjectDataSet.Tables[0];
			ddlState.DataBind();
			ddlState.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

			ViewState[isControlsLoaded] = true;
		}
	}
	protected void ActivateControlsView(bool isNewRecord, CityMaster objCityMaster,int? editIndex)
	{
		if (isNewRecord)
		{
			ViewState[editIndexKey] = null;
			BindCityMasterControls();
			UIUtility.InitializeControls(ViewCityMasterControls);
		}
		else
		{
			ViewState[editIndexKey] = editIndex;
			BindCityMasterControls();
			PopulateControlsData(objCityMaster);
		}
		MultiViewCityMaster.ActiveViewIndex = 1;
	}
	private void PopulateControlsData(CityMaster objCityMaster)
	{
		txtCityName.Text = objCityMaster.CityName;
		UIUtility.SelectCurrentListItem(ddlState, objCityMaster.StateObject.StateId, BindListItem.ByValue, true);
		UIUtility.SelectCurrentListItem(ddlIsDefaultSelected, objCityMaster.IsDefaultSelected, BindListItem.ByValue, true);
		txtDescription.Text = objCityMaster.Description;
	}
	#endregion

	#region Helper Functions
	private bool ValidateObject()
	{
		return true;
	}
	private CityMaster GetObjectForInsertUpdate()
	{
		objCityMaster = new CityMaster();

		if (ViewState[editIndexKey] == null)
		{
			objCityMaster.Version = BusinessUtility.RECORD_VERSION;
			objCityMaster.CreatedBy = LoggedInUser;
			objCityMaster.CreatedOn = GeneralUtility.CurrentDateTime;
		}
		else
		{
			objCityMaster.CityId = Convert.ToInt32(grdCityMaster.DataKeys[Convert.ToInt32(ViewState[editIndexKey])].Values[CITY_ID_INDEX].ToString());
			objCityMaster.Version = Convert.ToInt16(grdCityMaster.DataKeys[Convert.ToInt16(ViewState[editIndexKey])].Values[VERSION_INDEX].ToString()) + 1;
		}

		objCityMaster.CityName = txtCityName.Text;
		if (ddlState.SelectedIndex != 0)
		{
			objCityMaster.StateObject = new StateMaster();
			objCityMaster.StateObject.StateId = Convert.ToInt32(ddlState.SelectedItem.Value);
		}
		objCityMaster.IsDefaultSelected = Convert.ToBoolean(ddlIsDefaultSelected.SelectedItem.Value);
		objCityMaster.Description = txtDescription.Text;
		objCityMaster.ModifiedBy = LoggedInUser;
		objCityMaster.ModifiedOn = GeneralUtility.CurrentDateTime;
		objCityMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
		return objCityMaster;
	}
	private CityMaster GetObjectForActivateDeactivate(int editIndex,RecordStatus objStatus)
	{
		objCityMaster = new CityMaster();
		objCityMaster.CityId = Convert.ToInt32(grdCityMaster.DataKeys[editIndex].Values[CITY_ID_INDEX].ToString());
		objCityMaster.Version = Convert.ToInt16(grdCityMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString()) + 1;
		objCityMaster.ModifiedBy = LoggedInUser;
		objCityMaster.RecordStatus = Convert.ToInt16(objStatus);
		return objCityMaster;
	}
	private CityMaster SelectRecordById(int editIndex)
	{
		objCityMasterBL = new CityMasterBL();
		objCityMaster = new CityMaster();
		objCityMaster.CityId = Convert.ToInt32(grdCityMaster.DataKeys[editIndex].Values[CITY_ID_INDEX].ToString());
		objCityMaster.Version = Convert.ToInt16(grdCityMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString());
		objCityMaster = objCityMasterBL.SelectRecordById(objCityMaster);
		return objCityMaster;
	}
	#endregion
}
