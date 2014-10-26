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

public partial class DivisionMasterUI : BasePage
{
	#region Page Variables
	DivisionMaster objDivisionMaster = null;
	DivisionMasterBL objDivisionMasterBL = null;
	DepartmentMaster objDepartmentMaster = null;
	DepartmentMasterBL objDepartmentMasterBL = null;

	private const int SELECT_COLUMN = 0;
	private const int ACTIVATE_COLUMN = 1;
	private const int DELETE_COLUMN = 2;

	private const int DIVISION_ID_INDEX = 0;
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
			objDivisionMaster = BindDivisionMasterGrid(RecordStatus.Active);
			if (objDivisionMaster.DbOperationStatus != CommonConstant.SUCCEED)
			{
				btnAddNewRecord.Enabled = false;
				UIUtility.DisplayMessage(lblMessage, objDivisionMaster.DbOperationStatus);
				return;
			}

			ViewState[isControlsLoaded] = false;

			if (grdDivisionMaster.Rows.Count == 0)
			{
				BindDivisionMasterControls();
				MultiViewDivisionMaster.ActiveViewIndex = 1;
			}
		}
		else
		{
			if (rdbActiveRecord.Checked)
			{
				objDivisionMaster = BindDivisionMasterGrid(RecordStatus.Active);
				if (objDivisionMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objDivisionMaster.DbOperationStatus);
					return;
				}
				ViewActivateColumn(false);
			}
			else
			{
				objDivisionMaster = BindDivisionMasterGrid(RecordStatus.InActive);
				if (objDivisionMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objDivisionMaster.DbOperationStatus);
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
			grdDivisionMaster.Columns[SELECT_COLUMN].Visible = false;
			grdDivisionMaster.Columns[ACTIVATE_COLUMN].Visible = true;
			grdDivisionMaster.Columns[DELETE_COLUMN].Visible = false;
		}
		else
		{
			grdDivisionMaster.Columns[SELECT_COLUMN].Visible = true;
			grdDivisionMaster.Columns[ACTIVATE_COLUMN].Visible = false;
			grdDivisionMaster.Columns[DELETE_COLUMN].Visible = true;
		}
	}
	#endregion

	#region Grid Events and Functions
	protected void grdDivisionMaster_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			objDivisionMaster = SelectRecordById(grdDivisionMaster.SelectedIndex);
			if (!objDivisionMaster.DbOperationStatus.Equals(CommonConstant.FAIL))
			{
				if(!Convert.ToBoolean(objDivisionMaster.IsRecordChanged))
				{
					ActivateControlsView(false, objDivisionMaster, grdDivisionMaster.SelectedIndex);
				}
				else
				{
					UIUtility.DisplayMessage(lblMessage, objDivisionMaster.DbOperationStatus);
					InitializeForm();
				}
			}
			else
			{
				UIUtility.DisplayMessage(lblMessage, objDivisionMaster.DbOperationStatus);
			}
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdDivisionMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			objDivisionMasterBL = new DivisionMasterBL();
			objDivisionMaster = GetObjectForActivateDeactivate(e.RowIndex,RecordStatus.InActive);
			objDivisionMaster = objDivisionMasterBL.ActivateDeactivateDivisionMaster(objDivisionMaster);
			UIUtility.DisplayMessage(lblMessage, objDivisionMaster.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdDivisionMaster_ActivatingObject(object sender, GridViewEditEventArgs e)
	{
		try
		{
			objDivisionMasterBL = new DivisionMasterBL();
			objDivisionMaster = GetObjectForActivateDeactivate(e.NewEditIndex, RecordStatus.Active);
			objDivisionMaster = objDivisionMasterBL.ActivateDeactivateDivisionMaster(objDivisionMaster);
			UIUtility.DisplayMessage(lblMessage, objDivisionMaster.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdDivisionMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			grdDivisionMaster.PageIndex = e.NewPageIndex;
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected DivisionMaster BindDivisionMasterGrid(RecordStatus objRecordStatus)
	{
		objDivisionMasterBL = new DivisionMasterBL();
		objDivisionMaster = new DivisionMaster();
		objDivisionMaster.RecordStatus = Convert.ToInt16(objRecordStatus);

		objDivisionMaster = objDivisionMasterBL.SelectDivisionMaster(objDivisionMaster);
		if (objDivisionMaster.DbOperationStatus == CommonConstant.SUCCEED)
		{
			grdDivisionMaster.DataSource = objDivisionMaster.ObjectDataSet.Tables[0];
			grdDivisionMaster.DataBind();
		}
		return objDivisionMaster;
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
				objDivisionMaster = GetObjectForInsertUpdate();
				objDivisionMasterBL = new DivisionMasterBL();
				if (objDivisionMaster.DivisionId == null)
				{
					objDivisionMaster = objDivisionMasterBL.InsertDivisionMaster(objDivisionMaster);
				}
				else
				{
					objDivisionMaster = objDivisionMasterBL.UpdateDivisionMaster(objDivisionMaster);
				}
				if (objDivisionMaster.DbOperationStatus == CommonConstant.SUCCEED
							|| objDivisionMaster.DbOperationStatus == CommonConstant.INVALID)
				{
					InitializeForm();
					MultiViewDivisionMaster.ActiveViewIndex = 0;
				}
				UIUtility.DisplayMessage(lblMessage, objDivisionMaster.DbOperationStatus);
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
			MultiViewDivisionMaster.ActiveViewIndex = 0;
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
	protected void BindDivisionMasterControls()
	{
		if (!Convert.ToBoolean(ViewState[isControlsLoaded]))
		{
			objDepartmentMasterBL = new DepartmentMasterBL();
			objDepartmentMaster = new DepartmentMaster();
			objDepartmentMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
			objDepartmentMaster = objDepartmentMasterBL.SelectDepartmentMaster(objDepartmentMaster);
			ddlDepartment.DataSource = objDepartmentMaster.ObjectDataSet.Tables[0];
			ddlDepartment.DataBind();
			ddlDepartment.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

			ViewState[isControlsLoaded] = true;
		}
	}
	protected void ActivateControlsView(bool isNewRecord, DivisionMaster objDivisionMaster,int? editIndex)
	{
		if (isNewRecord)
		{
			ViewState[editIndexKey] = null;
			BindDivisionMasterControls();
			UIUtility.InitializeControls(ViewDivisionMasterControls);
		}
		else
		{
			ViewState[editIndexKey] = editIndex;
			BindDivisionMasterControls();
			PopulateControlsData(objDivisionMaster);
		}
		MultiViewDivisionMaster.ActiveViewIndex = 1;
	}
	private void PopulateControlsData(DivisionMaster objDivisionMaster)
	{
		UIUtility.SelectCurrentListItem(ddlDepartment, objDivisionMaster.DepartmentObject.DepartmentId, BindListItem.ByValue, true);
		txtDivisionCode.Text = objDivisionMaster.DivisionCode;
		txtDivisionName.Text = objDivisionMaster.DivisionName;
		txtDescription.Text = objDivisionMaster.Description;
	}
	#endregion

	#region Helper Functions
	private bool ValidateObject()
	{
		return true;
	}
	private DivisionMaster GetObjectForInsertUpdate()
	{
		objDivisionMaster = new DivisionMaster();

		if (ViewState[editIndexKey] == null)
		{
			objDivisionMaster.Version = BusinessUtility.RECORD_VERSION;
			objDivisionMaster.CreatedBy = LoggedInUser;
			objDivisionMaster.CreatedOn = GeneralUtility.CurrentDateTime;
		}
		else
		{
			objDivisionMaster.DivisionId = Convert.ToInt32(grdDivisionMaster.DataKeys[Convert.ToInt32(ViewState[editIndexKey])].Values[DIVISION_ID_INDEX].ToString());
			objDivisionMaster.Version = Convert.ToInt16(grdDivisionMaster.DataKeys[Convert.ToInt16(ViewState[editIndexKey])].Values[VERSION_INDEX].ToString()) + 1;
		}

		if (ddlDepartment.SelectedIndex != 0)
		{
			objDivisionMaster.DepartmentObject = new DepartmentMaster();
			objDivisionMaster.DepartmentObject.DepartmentId = Convert.ToInt32(ddlDepartment.SelectedItem.Value);
		}
		objDivisionMaster.DivisionCode = txtDivisionCode.Text;
		objDivisionMaster.DivisionName = txtDivisionName.Text;
		objDivisionMaster.Description = txtDescription.Text;
		objDivisionMaster.ModifiedBy = LoggedInUser;
		objDivisionMaster.ModifiedOn = GeneralUtility.CurrentDateTime;
		objDivisionMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
		return objDivisionMaster;
	}
	private DivisionMaster GetObjectForActivateDeactivate(int editIndex,RecordStatus objStatus)
	{
		objDivisionMaster = new DivisionMaster();
		objDivisionMaster.DivisionId = Convert.ToInt32(grdDivisionMaster.DataKeys[editIndex].Values[DIVISION_ID_INDEX].ToString());
		objDivisionMaster.Version = Convert.ToInt16(grdDivisionMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString()) + 1;
		objDivisionMaster.ModifiedBy = LoggedInUser;
		objDivisionMaster.RecordStatus = Convert.ToInt16(objStatus);
		return objDivisionMaster;
	}
	private DivisionMaster SelectRecordById(int editIndex)
	{
		objDivisionMasterBL = new DivisionMasterBL();
		objDivisionMaster = new DivisionMaster();
		objDivisionMaster.DivisionId = Convert.ToInt32(grdDivisionMaster.DataKeys[editIndex].Values[DIVISION_ID_INDEX].ToString());
		objDivisionMaster.Version = Convert.ToInt16(grdDivisionMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString());
		objDivisionMaster = objDivisionMasterBL.SelectRecordById(objDivisionMaster);
		return objDivisionMaster;
	}
	#endregion
}
