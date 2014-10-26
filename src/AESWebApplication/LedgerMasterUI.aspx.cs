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

public partial class LedgerMasterUI : BasePage
{
	#region Page Variables
	LedgerMaster objLedgerMaster = null;
	LedgerMasterBL objLedgerMasterBL = null;
	GroupMaster objGroupMaster = null;
	GroupMasterBL objGroupMasterBL = null;

	private const int SELECT_COLUMN = 0;
	private const int ACTIVATE_COLUMN = 1;
	private const int DELETE_COLUMN = 2;

	private const int LEDGER_ID_INDEX = 0;
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
			objLedgerMaster = BindLedgerMasterGrid(RecordStatus.Active);
			if (objLedgerMaster.DbOperationStatus != CommonConstant.SUCCEED)
			{
				btnAddNewRecord.Enabled = false;
				UIUtility.DisplayMessage(lblMessage, objLedgerMaster.DbOperationStatus);
				return;
			}

			ViewState[isControlsLoaded] = false;

			if (grdLedgerMaster.Rows.Count == 0)
			{
				BindLedgerMasterControls();
				MultiViewLedgerMaster.ActiveViewIndex = 1;
			}
		}
		else
		{
			if (rdbActiveRecord.Checked)
			{
				objLedgerMaster = BindLedgerMasterGrid(RecordStatus.Active);
				if (objLedgerMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objLedgerMaster.DbOperationStatus);
					return;
				}
				ViewActivateColumn(false);
			}
			else
			{
				objLedgerMaster = BindLedgerMasterGrid(RecordStatus.InActive);
				if (objLedgerMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objLedgerMaster.DbOperationStatus);
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
			grdLedgerMaster.Columns[SELECT_COLUMN].Visible = false;
			grdLedgerMaster.Columns[ACTIVATE_COLUMN].Visible = true;
			grdLedgerMaster.Columns[DELETE_COLUMN].Visible = false;
		}
		else
		{
			grdLedgerMaster.Columns[SELECT_COLUMN].Visible = true;
			grdLedgerMaster.Columns[ACTIVATE_COLUMN].Visible = false;
			grdLedgerMaster.Columns[DELETE_COLUMN].Visible = true;
		}
	}
	#endregion

	#region Grid Events and Functions
	protected void grdLedgerMaster_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			objLedgerMaster = SelectRecordById(grdLedgerMaster.SelectedIndex);
			if (!objLedgerMaster.DbOperationStatus.Equals(CommonConstant.FAIL))
			{
				if(!Convert.ToBoolean(objLedgerMaster.IsRecordChanged))
				{
					ActivateControlsView(false, objLedgerMaster, grdLedgerMaster.SelectedIndex);
				}
				else
				{
					UIUtility.DisplayMessage(lblMessage, objLedgerMaster.DbOperationStatus);
					InitializeForm();
				}
			}
			else
			{
				UIUtility.DisplayMessage(lblMessage, objLedgerMaster.DbOperationStatus);
			}
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdLedgerMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			objLedgerMasterBL = new LedgerMasterBL();
			objLedgerMaster = GetObjectForActivateDeactivate(e.RowIndex,RecordStatus.InActive);
			objLedgerMaster = objLedgerMasterBL.ActivateDeactivateLedgerMaster(objLedgerMaster);
			UIUtility.DisplayMessage(lblMessage, objLedgerMaster.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdLedgerMaster_ActivatingObject(object sender, GridViewEditEventArgs e)
	{
		try
		{
			objLedgerMasterBL = new LedgerMasterBL();
			objLedgerMaster = GetObjectForActivateDeactivate(e.NewEditIndex, RecordStatus.Active);
			objLedgerMaster = objLedgerMasterBL.ActivateDeactivateLedgerMaster(objLedgerMaster);
			UIUtility.DisplayMessage(lblMessage, objLedgerMaster.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdLedgerMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			grdLedgerMaster.PageIndex = e.NewPageIndex;
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected LedgerMaster BindLedgerMasterGrid(RecordStatus objRecordStatus)
	{
		objLedgerMasterBL = new LedgerMasterBL();
		objLedgerMaster = new LedgerMaster();
		objLedgerMaster.RecordStatus = Convert.ToInt16(objRecordStatus);

		objLedgerMaster = objLedgerMasterBL.SelectLedgerMaster(objLedgerMaster);
		if (objLedgerMaster.DbOperationStatus == CommonConstant.SUCCEED)
		{
			grdLedgerMaster.DataSource = objLedgerMaster.ObjectDataSet.Tables[0];
			grdLedgerMaster.DataBind();
		}
		return objLedgerMaster;
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
				objLedgerMaster = GetObjectForInsertUpdate();
				objLedgerMasterBL = new LedgerMasterBL();
				if (objLedgerMaster.LedgerId == null)
				{
					objLedgerMaster = objLedgerMasterBL.InsertLedgerMaster(objLedgerMaster);
				}
				else
				{
					objLedgerMaster = objLedgerMasterBL.UpdateLedgerMaster(objLedgerMaster);
				}
				if (objLedgerMaster.DbOperationStatus == CommonConstant.SUCCEED
							|| objLedgerMaster.DbOperationStatus == CommonConstant.INVALID)
				{
					InitializeForm();
					MultiViewLedgerMaster.ActiveViewIndex = 0;
				}
				UIUtility.DisplayMessage(lblMessage, objLedgerMaster.DbOperationStatus);
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
			MultiViewLedgerMaster.ActiveViewIndex = 0;
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
	protected void BindLedgerMasterControls()
	{
		if (!Convert.ToBoolean(ViewState[isControlsLoaded]))
		{
			objGroupMasterBL = new GroupMasterBL();
			objGroupMaster = new GroupMaster();
			objGroupMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
			objGroupMaster = objGroupMasterBL.SelectGroupMaster(objGroupMaster);
			ddlGroup.DataSource = objGroupMaster.ObjectDataSet.Tables[0];
			ddlGroup.DataBind();
			ddlGroup.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

			ViewState[isControlsLoaded] = true;
		}
	}
	protected void ActivateControlsView(bool isNewRecord, LedgerMaster objLedgerMaster,int? editIndex)
	{
		if (isNewRecord)
		{
			ViewState[editIndexKey] = null;
			BindLedgerMasterControls();
			UIUtility.InitializeControls(ViewLedgerMasterControls);
		}
		else
		{
			ViewState[editIndexKey] = editIndex;
			BindLedgerMasterControls();
			PopulateControlsData(objLedgerMaster);
		}
		MultiViewLedgerMaster.ActiveViewIndex = 1;
	}
	private void PopulateControlsData(LedgerMaster objLedgerMaster)
	{
		txtLedgerName.Text = objLedgerMaster.LedgerName;
		UIUtility.SelectCurrentListItem(ddlGroup, objLedgerMaster.GroupObject.GroupId, BindListItem.ByValue, true);
		txtOpeningBalance.Text = objLedgerMaster.OpeningBalance.ToString();
		txtOpeningDate.Text = objLedgerMaster.OpeningDate.ToString();
		txtDrCr.Text = objLedgerMaster.DrCr;
		txtOnDate.Text = objLedgerMaster.OnDate.ToString();
		txtDescription.Text = objLedgerMaster.Description;
	}
	#endregion

	#region Helper Functions
	private bool ValidateObject()
	{
		return true;
	}
	private LedgerMaster GetObjectForInsertUpdate()
	{
		objLedgerMaster = new LedgerMaster();

		if (ViewState[editIndexKey] == null)
		{
			objLedgerMaster.Version = BusinessUtility.RECORD_VERSION;
			objLedgerMaster.CreatedBy = LoggedInUser;
			objLedgerMaster.CreatedOn = GeneralUtility.CurrentDateTime;
		}
		else
		{
			objLedgerMaster.LedgerId = Convert.ToInt32(grdLedgerMaster.DataKeys[Convert.ToInt32(ViewState[editIndexKey])].Values[LEDGER_ID_INDEX].ToString());
			objLedgerMaster.Version = Convert.ToInt16(grdLedgerMaster.DataKeys[Convert.ToInt16(ViewState[editIndexKey])].Values[VERSION_INDEX].ToString()) + 1;
		}

		objLedgerMaster.LedgerName = txtLedgerName.Text;
		if (ddlGroup.SelectedIndex != 0)
		{
			objLedgerMaster.GroupObject = new GroupMaster();
			objLedgerMaster.GroupObject.GroupId = Convert.ToInt32(ddlGroup.SelectedItem.Value);
		}
		objLedgerMaster.OpeningBalance = Convert.ToDecimal(txtOpeningBalance.Text);
		objLedgerMaster.OpeningDate = Convert.ToDateTime(txtOpeningDate.Text);
		objLedgerMaster.DrCr = txtDrCr.Text;
		objLedgerMaster.OnDate = Convert.ToDateTime(txtOnDate.Text);
		objLedgerMaster.Description = txtDescription.Text;
		objLedgerMaster.ModifiedBy = LoggedInUser;
		objLedgerMaster.ModifiedOn = GeneralUtility.CurrentDateTime;
		objLedgerMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
		return objLedgerMaster;
	}
	private LedgerMaster GetObjectForActivateDeactivate(int editIndex,RecordStatus objStatus)
	{
		objLedgerMaster = new LedgerMaster();
		objLedgerMaster.LedgerId = Convert.ToInt32(grdLedgerMaster.DataKeys[editIndex].Values[LEDGER_ID_INDEX].ToString());
		objLedgerMaster.Version = Convert.ToInt16(grdLedgerMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString()) + 1;
		objLedgerMaster.ModifiedBy = LoggedInUser;
		objLedgerMaster.RecordStatus = Convert.ToInt16(objStatus);
		return objLedgerMaster;
	}
	private LedgerMaster SelectRecordById(int editIndex)
	{
		objLedgerMasterBL = new LedgerMasterBL();
		objLedgerMaster = new LedgerMaster();
		objLedgerMaster.LedgerId = Convert.ToInt32(grdLedgerMaster.DataKeys[editIndex].Values[LEDGER_ID_INDEX].ToString());
		objLedgerMaster.Version = Convert.ToInt16(grdLedgerMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString());
		objLedgerMaster = objLedgerMasterBL.SelectRecordById(objLedgerMaster);
		return objLedgerMaster;
	}
	#endregion
}
