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

public partial class VoucherTypeUI : BasePage
{
	#region Page Variables
	VoucherType objVoucherType = null;
	VoucherTypeBL objVoucherTypeBL = null;

	private const int SELECT_COLUMN = 0;
	private const int ACTIVATE_COLUMN = 1;
	private const int DELETE_COLUMN = 2;

	private const int VOUCHER_TYPE_ID_INDEX = 0;
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
			objVoucherType = BindVoucherTypeGrid(RecordStatus.Active);
			if (objVoucherType.DbOperationStatus != CommonConstant.SUCCEED)
			{
				btnAddNewRecord.Enabled = false;
				UIUtility.DisplayMessage(lblMessage, objVoucherType.DbOperationStatus);
				return;
			}

			ViewState[isControlsLoaded] = false;

			if (grdVoucherType.Rows.Count == 0)
			{
				BindVoucherTypeControls();
				MultiViewVoucherType.ActiveViewIndex = 1;
			}
		}
		else
		{
			if (rdbActiveRecord.Checked)
			{
				objVoucherType = BindVoucherTypeGrid(RecordStatus.Active);
				if (objVoucherType.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objVoucherType.DbOperationStatus);
					return;
				}
				ViewActivateColumn(false);
			}
			else
			{
				objVoucherType = BindVoucherTypeGrid(RecordStatus.InActive);
				if (objVoucherType.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objVoucherType.DbOperationStatus);
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
			grdVoucherType.Columns[SELECT_COLUMN].Visible = false;
			grdVoucherType.Columns[ACTIVATE_COLUMN].Visible = true;
			grdVoucherType.Columns[DELETE_COLUMN].Visible = false;
		}
		else
		{
			grdVoucherType.Columns[SELECT_COLUMN].Visible = true;
			grdVoucherType.Columns[ACTIVATE_COLUMN].Visible = false;
			grdVoucherType.Columns[DELETE_COLUMN].Visible = true;
		}
	}
	#endregion

	#region Grid Events and Functions
	protected void grdVoucherType_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			objVoucherType = SelectRecordById(grdVoucherType.SelectedIndex);
			if (!objVoucherType.DbOperationStatus.Equals(CommonConstant.FAIL))
			{
				if(!Convert.ToBoolean(objVoucherType.IsRecordChanged))
				{
					ActivateControlsView(false, objVoucherType, grdVoucherType.SelectedIndex);
				}
				else
				{
					UIUtility.DisplayMessage(lblMessage, objVoucherType.DbOperationStatus);
					InitializeForm();
				}
			}
			else
			{
				UIUtility.DisplayMessage(lblMessage, objVoucherType.DbOperationStatus);
			}
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdVoucherType_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			objVoucherTypeBL = new VoucherTypeBL();
			objVoucherType = GetObjectForActivateDeactivate(e.RowIndex,RecordStatus.InActive);
			objVoucherType = objVoucherTypeBL.ActivateDeactivateVoucherType(objVoucherType);
			UIUtility.DisplayMessage(lblMessage, objVoucherType.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdVoucherType_ActivatingObject(object sender, GridViewEditEventArgs e)
	{
		try
		{
			objVoucherTypeBL = new VoucherTypeBL();
			objVoucherType = GetObjectForActivateDeactivate(e.NewEditIndex, RecordStatus.Active);
			objVoucherType = objVoucherTypeBL.ActivateDeactivateVoucherType(objVoucherType);
			UIUtility.DisplayMessage(lblMessage, objVoucherType.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdVoucherType_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			grdVoucherType.PageIndex = e.NewPageIndex;
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected VoucherType BindVoucherTypeGrid(RecordStatus objRecordStatus)
	{
		objVoucherTypeBL = new VoucherTypeBL();
		objVoucherType = new VoucherType();
		objVoucherType.RecordStatus = Convert.ToInt16(objRecordStatus);

		objVoucherType = objVoucherTypeBL.SelectVoucherType(objVoucherType);
		if (objVoucherType.DbOperationStatus == CommonConstant.SUCCEED)
		{
			grdVoucherType.DataSource = objVoucherType.ObjectDataSet.Tables[0];
			grdVoucherType.DataBind();
		}
		return objVoucherType;
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
				objVoucherType = GetObjectForInsertUpdate();
				objVoucherTypeBL = new VoucherTypeBL();
				if (objVoucherType.VoucherTypeId == null)
				{
					objVoucherType = objVoucherTypeBL.InsertVoucherType(objVoucherType);
				}
				else
				{
					objVoucherType = objVoucherTypeBL.UpdateVoucherType(objVoucherType);
				}
				if (objVoucherType.DbOperationStatus == CommonConstant.SUCCEED
							|| objVoucherType.DbOperationStatus == CommonConstant.INVALID)
				{
					InitializeForm();
					MultiViewVoucherType.ActiveViewIndex = 0;
				}
				UIUtility.DisplayMessage(lblMessage, objVoucherType.DbOperationStatus);
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
			MultiViewVoucherType.ActiveViewIndex = 0;
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
	protected void BindVoucherTypeControls()
	{
		if (!Convert.ToBoolean(ViewState[isControlsLoaded]))
		{
			ViewState[isControlsLoaded] = true;
		}
	}
	protected void ActivateControlsView(bool isNewRecord, VoucherType objVoucherType,int? editIndex)
	{
		if (isNewRecord)
		{
			ViewState[editIndexKey] = null;
			BindVoucherTypeControls();
			UIUtility.InitializeControls(ViewVoucherTypeControls);
		}
		else
		{
			ViewState[editIndexKey] = editIndex;
			BindVoucherTypeControls();
			PopulateControlsData(objVoucherType);
		}
		MultiViewVoucherType.ActiveViewIndex = 1;
	}
	private void PopulateControlsData(VoucherType objVoucherType)
	{
		txtVoucherTypeName.Text = objVoucherType.VoucherTypeName;
		txtSerialNumberMode.Text = objVoucherType.SerialNumberMode;
		txtSerialNumberPrefix.Text = objVoucherType.SerialNumberPrefix;
		txtNumericalWidth.Text = objVoucherType.NumericalWidth.ToString();
		UIUtility.SelectCurrentListItem(ddlIsZeroPrefix, objVoucherType.IsZeroPrefix, BindListItem.ByValue, true);
		txtStartingNumber.Text = objVoucherType.StartingNumber;
	}
	#endregion

	#region Helper Functions
	private bool ValidateObject()
	{
		return true;
	}
	private VoucherType GetObjectForInsertUpdate()
	{
		objVoucherType = new VoucherType();

		if (ViewState[editIndexKey] == null)
		{
			objVoucherType.Version = BusinessUtility.RECORD_VERSION;
			objVoucherType.CreatedBy = LoggedInUser;
			objVoucherType.CreatedOn = GeneralUtility.CurrentDateTime;
		}
		else
		{
			objVoucherType.VoucherTypeId = Convert.ToInt32(grdVoucherType.DataKeys[Convert.ToInt32(ViewState[editIndexKey])].Values[VOUCHER_TYPE_ID_INDEX].ToString());
			objVoucherType.Version = Convert.ToInt16(grdVoucherType.DataKeys[Convert.ToInt16(ViewState[editIndexKey])].Values[VERSION_INDEX].ToString()) + 1;
		}

		objVoucherType.VoucherTypeName = txtVoucherTypeName.Text;
		objVoucherType.SerialNumberMode = txtSerialNumberMode.Text;
		objVoucherType.SerialNumberPrefix = txtSerialNumberPrefix.Text;
		objVoucherType.NumericalWidth = Convert.ToInt32(txtNumericalWidth.Text);
		objVoucherType.IsZeroPrefix = Convert.ToBoolean(ddlIsZeroPrefix.SelectedItem.Value);
		objVoucherType.StartingNumber = txtStartingNumber.Text;
		objVoucherType.ModifiedBy = LoggedInUser;
		objVoucherType.ModifiedOn = GeneralUtility.CurrentDateTime;
		objVoucherType.RecordStatus = Convert.ToInt16(RecordStatus.Active);
		return objVoucherType;
	}
	private VoucherType GetObjectForActivateDeactivate(int editIndex,RecordStatus objStatus)
	{
		objVoucherType = new VoucherType();
		objVoucherType.VoucherTypeId = Convert.ToInt32(grdVoucherType.DataKeys[editIndex].Values[VOUCHER_TYPE_ID_INDEX].ToString());
		objVoucherType.Version = Convert.ToInt16(grdVoucherType.DataKeys[editIndex].Values[VERSION_INDEX].ToString()) + 1;
		objVoucherType.ModifiedBy = LoggedInUser;
		objVoucherType.RecordStatus = Convert.ToInt16(objStatus);
		return objVoucherType;
	}
	private VoucherType SelectRecordById(int editIndex)
	{
		objVoucherTypeBL = new VoucherTypeBL();
		objVoucherType = new VoucherType();
		objVoucherType.VoucherTypeId = Convert.ToInt32(grdVoucherType.DataKeys[editIndex].Values[VOUCHER_TYPE_ID_INDEX].ToString());
		objVoucherType.Version = Convert.ToInt16(grdVoucherType.DataKeys[editIndex].Values[VERSION_INDEX].ToString());
		objVoucherType = objVoucherTypeBL.SelectRecordById(objVoucherType);
		return objVoucherType;
	}
	#endregion
}
