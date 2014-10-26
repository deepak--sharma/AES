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

public partial class CountryMasterUI : BasePage
{
	#region Page Variables
	CountryMaster objCountryMaster = null;
	CountryMasterBL objCountryMasterBL = null;

	private const int SELECT_COLUMN = 0;
	private const int ACTIVATE_COLUMN = 1;
	private const int DELETE_COLUMN = 2;

	private const int COUNTRY_ID_INDEX = 0;
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
			objCountryMaster = BindCountryMasterGrid(RecordStatus.Active);
			if (objCountryMaster.DbOperationStatus != CommonConstant.SUCCEED)
			{
				btnAddNewRecord.Enabled = false;
				UIUtility.DisplayMessage(lblMessage, objCountryMaster.DbOperationStatus);
				return;
			}

			ViewState[isControlsLoaded] = false;

			if (grdCountryMaster.Rows.Count == 0)
			{
				BindCountryMasterControls();
				MultiViewCountryMaster.ActiveViewIndex = 1;
			}
		}
		else
		{
			if (rdbActiveRecord.Checked)
			{
				objCountryMaster = BindCountryMasterGrid(RecordStatus.Active);
				if (objCountryMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objCountryMaster.DbOperationStatus);
					return;
				}
				ViewActivateColumn(false);
			}
			else
			{
				objCountryMaster = BindCountryMasterGrid(RecordStatus.InActive);
				if (objCountryMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objCountryMaster.DbOperationStatus);
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
			grdCountryMaster.Columns[SELECT_COLUMN].Visible = false;
			grdCountryMaster.Columns[ACTIVATE_COLUMN].Visible = true;
			grdCountryMaster.Columns[DELETE_COLUMN].Visible = false;
		}
		else
		{
			grdCountryMaster.Columns[SELECT_COLUMN].Visible = true;
			grdCountryMaster.Columns[ACTIVATE_COLUMN].Visible = false;
			grdCountryMaster.Columns[DELETE_COLUMN].Visible = true;
		}
	}
	#endregion

	#region Grid Events and Functions
	protected void grdCountryMaster_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			objCountryMaster = SelectRecordById(grdCountryMaster.SelectedIndex);
			if (!objCountryMaster.DbOperationStatus.Equals(CommonConstant.FAIL))
			{
				if(!Convert.ToBoolean(objCountryMaster.IsRecordChanged))
				{
					ActivateControlsView(false, objCountryMaster, grdCountryMaster.SelectedIndex);
				}
				else
				{
					UIUtility.DisplayMessage(lblMessage, objCountryMaster.DbOperationStatus);
					InitializeForm();
				}
			}
			else
			{
				UIUtility.DisplayMessage(lblMessage, objCountryMaster.DbOperationStatus);
			}
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdCountryMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			objCountryMasterBL = new CountryMasterBL();
			objCountryMaster = GetObjectForActivateDeactivate(e.RowIndex,RecordStatus.InActive);
			objCountryMaster = objCountryMasterBL.ActivateDeactivateCountryMaster(objCountryMaster);
			UIUtility.DisplayMessage(lblMessage, objCountryMaster.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdCountryMaster_ActivatingObject(object sender, GridViewEditEventArgs e)
	{
		try
		{
			objCountryMasterBL = new CountryMasterBL();
			objCountryMaster = GetObjectForActivateDeactivate(e.NewEditIndex, RecordStatus.Active);
			objCountryMaster = objCountryMasterBL.ActivateDeactivateCountryMaster(objCountryMaster);
			UIUtility.DisplayMessage(lblMessage, objCountryMaster.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdCountryMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			grdCountryMaster.PageIndex = e.NewPageIndex;
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected CountryMaster BindCountryMasterGrid(RecordStatus objRecordStatus)
	{
		objCountryMasterBL = new CountryMasterBL();
		objCountryMaster = new CountryMaster();
		objCountryMaster.RecordStatus = Convert.ToInt16(objRecordStatus);

		objCountryMaster = objCountryMasterBL.SelectCountryMaster(objCountryMaster);
		if (objCountryMaster.DbOperationStatus == CommonConstant.SUCCEED)
		{
			grdCountryMaster.DataSource = objCountryMaster.ObjectDataSet.Tables[0];
			grdCountryMaster.DataBind();
		}
		return objCountryMaster;
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
				objCountryMaster = GetObjectForInsertUpdate();
				objCountryMasterBL = new CountryMasterBL();
				if (objCountryMaster.CountryId == null)
				{
					objCountryMaster = objCountryMasterBL.InsertCountryMaster(objCountryMaster);
				}
				else
				{
					objCountryMaster = objCountryMasterBL.UpdateCountryMaster(objCountryMaster);
				}
				if (objCountryMaster.DbOperationStatus == CommonConstant.SUCCEED
							|| objCountryMaster.DbOperationStatus == CommonConstant.INVALID)
				{
					InitializeForm();
					MultiViewCountryMaster.ActiveViewIndex = 0;
				}
				UIUtility.DisplayMessage(lblMessage, objCountryMaster.DbOperationStatus);
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
			MultiViewCountryMaster.ActiveViewIndex = 0;
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
	protected void BindCountryMasterControls()
	{
		if (!Convert.ToBoolean(ViewState[isControlsLoaded]))
		{
			ViewState[isControlsLoaded] = true;
		}
	}
	protected void ActivateControlsView(bool isNewRecord, CountryMaster objCountryMaster,int? editIndex)
	{
		if (isNewRecord)
		{
			ViewState[editIndexKey] = null;
			BindCountryMasterControls();
			UIUtility.InitializeControls(ViewCountryMasterControls);
		}
		else
		{
			ViewState[editIndexKey] = editIndex;
			BindCountryMasterControls();
			PopulateControlsData(objCountryMaster);
		}
		MultiViewCountryMaster.ActiveViewIndex = 1;
	}
	private void PopulateControlsData(CountryMaster objCountryMaster)
	{
		txtCountryName.Text = objCountryMaster.CountryName;
		txtDescription.Text = objCountryMaster.Description;
	}
	#endregion

	#region Helper Functions
	private bool ValidateObject()
	{
		return true;
	}
	private CountryMaster GetObjectForInsertUpdate()
	{
		objCountryMaster = new CountryMaster();

		if (ViewState[editIndexKey] == null)
		{
			objCountryMaster.Version = BusinessUtility.RECORD_VERSION;
			objCountryMaster.CreatedBy = LoggedInUser;
			objCountryMaster.CreatedOn = GeneralUtility.CurrentDateTime;
		}
		else
		{
			objCountryMaster.CountryId = Convert.ToInt32(grdCountryMaster.DataKeys[Convert.ToInt32(ViewState[editIndexKey])].Values[COUNTRY_ID_INDEX].ToString());
			objCountryMaster.Version = Convert.ToInt16(grdCountryMaster.DataKeys[Convert.ToInt16(ViewState[editIndexKey])].Values[VERSION_INDEX].ToString()) + 1;
		}

		objCountryMaster.CountryName = txtCountryName.Text;
		objCountryMaster.Description = txtDescription.Text;
		objCountryMaster.ModifiedBy = LoggedInUser;
		objCountryMaster.ModifiedOn = GeneralUtility.CurrentDateTime;
		objCountryMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
		return objCountryMaster;
	}
	private CountryMaster GetObjectForActivateDeactivate(int editIndex,RecordStatus objStatus)
	{
		objCountryMaster = new CountryMaster();
		objCountryMaster.CountryId = Convert.ToInt32(grdCountryMaster.DataKeys[editIndex].Values[COUNTRY_ID_INDEX].ToString());
		objCountryMaster.Version = Convert.ToInt16(grdCountryMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString()) + 1;
		objCountryMaster.ModifiedBy = LoggedInUser;
		objCountryMaster.RecordStatus = Convert.ToInt16(objStatus);
		return objCountryMaster;
	}
	private CountryMaster SelectRecordById(int editIndex)
	{
		objCountryMasterBL = new CountryMasterBL();
		objCountryMaster = new CountryMaster();
		objCountryMaster.CountryId = Convert.ToInt32(grdCountryMaster.DataKeys[editIndex].Values[COUNTRY_ID_INDEX].ToString());
		objCountryMaster.Version = Convert.ToInt16(grdCountryMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString());
		objCountryMaster = objCountryMasterBL.SelectRecordById(objCountryMaster);
		return objCountryMaster;
	}
	#endregion
}
