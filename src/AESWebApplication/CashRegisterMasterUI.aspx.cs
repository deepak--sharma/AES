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

public partial class CashRegisterMasterUI : BasePage
{
	#region Page Variables
	CashRegisterMaster objCashRegisterMaster = null;
	CashRegisterMasterBL objCashRegisterMasterBL = null;
	GroupMaster objGroupMaster = null;
	GroupMasterBL objGroupMasterBL = null;

	private const int SELECT_COLUMN = 0;
	private const int ACTIVATE_COLUMN = 1;
	private const int DELETE_COLUMN = 2;

	private const int CASH_REGISTER_ID_INDEX = 0;
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
			objCashRegisterMaster = BindCashRegisterMasterGrid(RecordStatus.Active);
			if (objCashRegisterMaster.DbOperationStatus != CommonConstant.SUCCEED)
			{
				btnAddNewRecord.Enabled = false;
				UIUtility.DisplayMessage(lblMessage, objCashRegisterMaster.DbOperationStatus);
				return;
			}

			ViewState[isControlsLoaded] = false;

			if (grdCashRegisterMaster.Rows.Count == 0)
			{
				BindCashRegisterMasterControls();
				MultiViewCashRegisterMaster.ActiveViewIndex = 1;
			}
		}
		else
		{
			if (rdbActiveRecord.Checked)
			{
				objCashRegisterMaster = BindCashRegisterMasterGrid(RecordStatus.Active);
				if (objCashRegisterMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objCashRegisterMaster.DbOperationStatus);
					return;
				}
				ViewActivateColumn(false);
			}
			else
			{
				objCashRegisterMaster = BindCashRegisterMasterGrid(RecordStatus.InActive);
				if (objCashRegisterMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objCashRegisterMaster.DbOperationStatus);
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
			grdCashRegisterMaster.Columns[SELECT_COLUMN].Visible = false;
			grdCashRegisterMaster.Columns[ACTIVATE_COLUMN].Visible = true;
			grdCashRegisterMaster.Columns[DELETE_COLUMN].Visible = false;
		}
		else
		{
			grdCashRegisterMaster.Columns[SELECT_COLUMN].Visible = true;
			grdCashRegisterMaster.Columns[ACTIVATE_COLUMN].Visible = false;
			grdCashRegisterMaster.Columns[DELETE_COLUMN].Visible = true;
		}
	}
	#endregion

	#region Grid Events and Functions
	protected void grdCashRegisterMaster_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			objCashRegisterMaster = SelectRecordById(grdCashRegisterMaster.SelectedIndex);
			if (!objCashRegisterMaster.DbOperationStatus.Equals(CommonConstant.FAIL))
			{
				if(!Convert.ToBoolean(objCashRegisterMaster.IsRecordChanged))
				{
					ActivateControlsView(false, objCashRegisterMaster, grdCashRegisterMaster.SelectedIndex);
				}
				else
				{
					UIUtility.DisplayMessage(lblMessage, objCashRegisterMaster.DbOperationStatus);
					InitializeForm();
				}
			}
			else
			{
				UIUtility.DisplayMessage(lblMessage, objCashRegisterMaster.DbOperationStatus);
			}
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdCashRegisterMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			objCashRegisterMasterBL = new CashRegisterMasterBL();
			objCashRegisterMaster = GetObjectForActivateDeactivate(e.RowIndex,RecordStatus.InActive);
			objCashRegisterMaster = objCashRegisterMasterBL.ActivateDeactivateCashRegisterMaster(objCashRegisterMaster);
			UIUtility.DisplayMessage(lblMessage, objCashRegisterMaster.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdCashRegisterMaster_ActivatingObject(object sender, GridViewEditEventArgs e)
	{
		try
		{
			objCashRegisterMasterBL = new CashRegisterMasterBL();
			objCashRegisterMaster = GetObjectForActivateDeactivate(e.NewEditIndex, RecordStatus.Active);
			objCashRegisterMaster = objCashRegisterMasterBL.ActivateDeactivateCashRegisterMaster(objCashRegisterMaster);
			UIUtility.DisplayMessage(lblMessage, objCashRegisterMaster.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdCashRegisterMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			grdCashRegisterMaster.PageIndex = e.NewPageIndex;
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected CashRegisterMaster BindCashRegisterMasterGrid(RecordStatus objRecordStatus)
	{
		objCashRegisterMasterBL = new CashRegisterMasterBL();
		objCashRegisterMaster = new CashRegisterMaster();
		objCashRegisterMaster.RecordStatus = Convert.ToInt16(objRecordStatus);

		objCashRegisterMaster = objCashRegisterMasterBL.SelectCashRegisterMaster(objCashRegisterMaster);
		if (objCashRegisterMaster.DbOperationStatus == CommonConstant.SUCCEED)
		{
			grdCashRegisterMaster.DataSource = objCashRegisterMaster.ObjectDataSet.Tables[0];
			grdCashRegisterMaster.DataBind();
		}
		return objCashRegisterMaster;
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
				objCashRegisterMaster = GetObjectForInsertUpdate();
				objCashRegisterMasterBL = new CashRegisterMasterBL();
				if (objCashRegisterMaster.CashRegisterId == null)
				{
					objCashRegisterMaster = objCashRegisterMasterBL.InsertCashRegisterMaster(objCashRegisterMaster);
				}
				else
				{
					objCashRegisterMaster = objCashRegisterMasterBL.UpdateCashRegisterMaster(objCashRegisterMaster);
				}
				if (objCashRegisterMaster.DbOperationStatus == CommonConstant.SUCCEED
							|| objCashRegisterMaster.DbOperationStatus == CommonConstant.INVALID)
				{
					InitializeForm();
					MultiViewCashRegisterMaster.ActiveViewIndex = 0;
				}
				UIUtility.DisplayMessage(lblMessage, objCashRegisterMaster.DbOperationStatus);
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
			MultiViewCashRegisterMaster.ActiveViewIndex = 0;
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
	protected void BindCashRegisterMasterControls()
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
	protected void ActivateControlsView(bool isNewRecord, CashRegisterMaster objCashRegisterMaster,int? editIndex)
	{
		if (isNewRecord)
		{
			ViewState[editIndexKey] = null;
			BindCashRegisterMasterControls();
			UIUtility.InitializeControls(ViewCashRegisterMasterControls);
		}
		else
		{
			ViewState[editIndexKey] = editIndex;
			BindCashRegisterMasterControls();
			PopulateControlsData(objCashRegisterMaster);
		}
		MultiViewCashRegisterMaster.ActiveViewIndex = 1;
	}
	private void PopulateControlsData(CashRegisterMaster objCashRegisterMaster)
	{
		txtCashRegisterName.Text = objCashRegisterMaster.CashRegisterName;
		UIUtility.SelectCurrentListItem(ddlGroup, objCashRegisterMaster.GroupObject.GroupId, BindListItem.ByValue, true);
		txtOpeningDate.Text = objCashRegisterMaster.OpeningDate.ToString();
		txtDrCr.Text = objCashRegisterMaster.DrCr;
		txtOnDate.Text = objCashRegisterMaster.OnDate.ToString();
		txtDescription.Text = objCashRegisterMaster.Description;
	}
	#endregion

	#region Helper Functions
	private bool ValidateObject()
	{
		return true;
	}
	private CashRegisterMaster GetObjectForInsertUpdate()
	{
		objCashRegisterMaster = new CashRegisterMaster();

		if (ViewState[editIndexKey] == null)
		{
			objCashRegisterMaster.Version = BusinessUtility.RECORD_VERSION;
			objCashRegisterMaster.CreatedBy = LoggedInUser;
			objCashRegisterMaster.CreatedOn = GeneralUtility.CurrentDateTime;
		}
		else
		{
			objCashRegisterMaster.CashRegisterId = Convert.ToInt32(grdCashRegisterMaster.DataKeys[Convert.ToInt32(ViewState[editIndexKey])].Values[CASH_REGISTER_ID_INDEX].ToString());
			objCashRegisterMaster.Version = Convert.ToInt16(grdCashRegisterMaster.DataKeys[Convert.ToInt16(ViewState[editIndexKey])].Values[VERSION_INDEX].ToString()) + 1;
		}

		objCashRegisterMaster.CashRegisterName = txtCashRegisterName.Text;
		if (ddlGroup.SelectedIndex != 0)
		{
			objCashRegisterMaster.GroupObject = new GroupMaster();
			objCashRegisterMaster.GroupObject.GroupId = Convert.ToInt32(ddlGroup.SelectedItem.Value);
		}
		objCashRegisterMaster.OpeningDate = Convert.ToDateTime(txtOpeningDate.Text);
		objCashRegisterMaster.DrCr = txtDrCr.Text;
		objCashRegisterMaster.OnDate = Convert.ToDateTime(txtOnDate.Text);
		objCashRegisterMaster.Description = txtDescription.Text;
		objCashRegisterMaster.ModifiedBy = LoggedInUser;
		objCashRegisterMaster.ModifiedOn = GeneralUtility.CurrentDateTime;
		objCashRegisterMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
		return objCashRegisterMaster;
	}
	private CashRegisterMaster GetObjectForActivateDeactivate(int editIndex,RecordStatus objStatus)
	{
		objCashRegisterMaster = new CashRegisterMaster();
		objCashRegisterMaster.CashRegisterId = Convert.ToInt32(grdCashRegisterMaster.DataKeys[editIndex].Values[CASH_REGISTER_ID_INDEX].ToString());
		objCashRegisterMaster.Version = Convert.ToInt16(grdCashRegisterMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString()) + 1;
		objCashRegisterMaster.ModifiedBy = LoggedInUser;
		objCashRegisterMaster.RecordStatus = Convert.ToInt16(objStatus);
		return objCashRegisterMaster;
	}
	private CashRegisterMaster SelectRecordById(int editIndex)
	{
		objCashRegisterMasterBL = new CashRegisterMasterBL();
		objCashRegisterMaster = new CashRegisterMaster();
		objCashRegisterMaster.CashRegisterId = Convert.ToInt32(grdCashRegisterMaster.DataKeys[editIndex].Values[CASH_REGISTER_ID_INDEX].ToString());
		objCashRegisterMaster.Version = Convert.ToInt16(grdCashRegisterMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString());
		objCashRegisterMaster = objCashRegisterMasterBL.SelectRecordById(objCashRegisterMaster);
		return objCashRegisterMaster;
	}
	#endregion
}
