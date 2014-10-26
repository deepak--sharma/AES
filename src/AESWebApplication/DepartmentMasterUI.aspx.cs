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

public partial class DepartmentMasterUI : BasePage
{
	#region Page Variables
	DepartmentMaster objDepartmentMaster = null;
	DepartmentMasterBL objDepartmentMasterBL = null;
	EmployeeDetail objEmployeeDetail = null;
	EmployeeDetailBL objEmployeeDetailBL = null;

	private const int SELECT_COLUMN = 0;
	private const int ACTIVATE_COLUMN = 1;
	private const int DELETE_COLUMN = 2;

	private const int DEPARTMENT_ID_INDEX = 0;
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
			objDepartmentMaster = BindDepartmentMasterGrid(RecordStatus.Active);
			if (objDepartmentMaster.DbOperationStatus != CommonConstant.SUCCEED)
			{
				btnAddNewRecord.Enabled = false;
				UIUtility.DisplayMessage(lblMessage, objDepartmentMaster.DbOperationStatus);
				return;
			}

			ViewState[isControlsLoaded] = false;

			if (grdDepartmentMaster.Rows.Count == 0)
			{
				BindDepartmentMasterControls();
				MultiViewDepartmentMaster.ActiveViewIndex = 1;
			}
		}
		else
		{
			if (rdbActiveRecord.Checked)
			{
				objDepartmentMaster = BindDepartmentMasterGrid(RecordStatus.Active);
				if (objDepartmentMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objDepartmentMaster.DbOperationStatus);
					return;
				}
				ViewActivateColumn(false);
			}
			else
			{
				objDepartmentMaster = BindDepartmentMasterGrid(RecordStatus.InActive);
				if (objDepartmentMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objDepartmentMaster.DbOperationStatus);
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
			grdDepartmentMaster.Columns[SELECT_COLUMN].Visible = false;
			grdDepartmentMaster.Columns[ACTIVATE_COLUMN].Visible = true;
			grdDepartmentMaster.Columns[DELETE_COLUMN].Visible = false;
		}
		else
		{
			grdDepartmentMaster.Columns[SELECT_COLUMN].Visible = true;
			grdDepartmentMaster.Columns[ACTIVATE_COLUMN].Visible = false;
			grdDepartmentMaster.Columns[DELETE_COLUMN].Visible = true;
		}
	}
	#endregion

	#region Grid Events and Functions
	protected void grdDepartmentMaster_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			objDepartmentMaster = SelectRecordById(grdDepartmentMaster.SelectedIndex);
			if (!objDepartmentMaster.DbOperationStatus.Equals(CommonConstant.FAIL))
			{
				if(!Convert.ToBoolean(objDepartmentMaster.IsRecordChanged))
				{
					ActivateControlsView(false, objDepartmentMaster, grdDepartmentMaster.SelectedIndex);
				}
				else
				{
					UIUtility.DisplayMessage(lblMessage, objDepartmentMaster.DbOperationStatus);
					InitializeForm();
				}
			}
			else
			{
				UIUtility.DisplayMessage(lblMessage, objDepartmentMaster.DbOperationStatus);
			}
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdDepartmentMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			objDepartmentMasterBL = new DepartmentMasterBL();
			objDepartmentMaster = GetObjectForActivateDeactivate(e.RowIndex,RecordStatus.InActive);
			objDepartmentMaster = objDepartmentMasterBL.ActivateDeactivateDepartmentMaster(objDepartmentMaster);
			UIUtility.DisplayMessage(lblMessage, objDepartmentMaster.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdDepartmentMaster_ActivatingObject(object sender, GridViewEditEventArgs e)
	{
		try
		{
			objDepartmentMasterBL = new DepartmentMasterBL();
			objDepartmentMaster = GetObjectForActivateDeactivate(e.NewEditIndex, RecordStatus.Active);
			objDepartmentMaster = objDepartmentMasterBL.ActivateDeactivateDepartmentMaster(objDepartmentMaster);
			UIUtility.DisplayMessage(lblMessage, objDepartmentMaster.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdDepartmentMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			grdDepartmentMaster.PageIndex = e.NewPageIndex;
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected DepartmentMaster BindDepartmentMasterGrid(RecordStatus objRecordStatus)
	{
		objDepartmentMasterBL = new DepartmentMasterBL();
		objDepartmentMaster = new DepartmentMaster();
		objDepartmentMaster.RecordStatus = Convert.ToInt16(objRecordStatus);

		objDepartmentMaster = objDepartmentMasterBL.SelectDepartmentMaster(objDepartmentMaster);
		if (objDepartmentMaster.DbOperationStatus == CommonConstant.SUCCEED)
		{
			grdDepartmentMaster.DataSource = objDepartmentMaster.ObjectDataSet.Tables[0];
			grdDepartmentMaster.DataBind();
		}
		return objDepartmentMaster;
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
				objDepartmentMaster = GetObjectForInsertUpdate();
				objDepartmentMasterBL = new DepartmentMasterBL();
				if (objDepartmentMaster.DepartmentId == null)
				{
					objDepartmentMaster = objDepartmentMasterBL.InsertDepartmentMaster(objDepartmentMaster);
				}
				else
				{
					objDepartmentMaster = objDepartmentMasterBL.UpdateDepartmentMaster(objDepartmentMaster);
				}
				if (objDepartmentMaster.DbOperationStatus == CommonConstant.SUCCEED
							|| objDepartmentMaster.DbOperationStatus == CommonConstant.INVALID)
				{
					InitializeForm();
					MultiViewDepartmentMaster.ActiveViewIndex = 0;
				}
				UIUtility.DisplayMessage(lblMessage, objDepartmentMaster.DbOperationStatus);
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
			MultiViewDepartmentMaster.ActiveViewIndex = 0;
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
	protected void BindDepartmentMasterControls()
	{
		if (!Convert.ToBoolean(ViewState[isControlsLoaded]))
		{
			objEmployeeDetailBL = new EmployeeDetailBL();
			objEmployeeDetail = new EmployeeDetail();
			objEmployeeDetail.RecordStatus = Convert.ToInt16(RecordStatus.Active);
			objEmployeeDetail = objEmployeeDetailBL.SelectEmployeeDetail(objEmployeeDetail);
			ddlHod.DataSource = objEmployeeDetail.ObjectDataSet.Tables[0];
			ddlHod.DataBind();
			ddlHod.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

			ViewState[isControlsLoaded] = true;
		}
	}
	protected void ActivateControlsView(bool isNewRecord, DepartmentMaster objDepartmentMaster,int? editIndex)
	{
		if (isNewRecord)
		{
			ViewState[editIndexKey] = null;
			BindDepartmentMasterControls();
			UIUtility.InitializeControls(ViewDepartmentMasterControls);
		}
		else
		{
			ViewState[editIndexKey] = editIndex;
			BindDepartmentMasterControls();
			PopulateControlsData(objDepartmentMaster);
		}
		MultiViewDepartmentMaster.ActiveViewIndex = 1;
	}
	private void PopulateControlsData(DepartmentMaster objDepartmentMaster)
	{
		txtDepartmentCode.Text = objDepartmentMaster.DepartmentCode;
		txtDepartmentName.Text = objDepartmentMaster.DepartmentName;
		txtDescription.Text = objDepartmentMaster.Description;
		UIUtility.SelectCurrentListItem(ddlHod, objDepartmentMaster.Hod.EmployeeId, BindListItem.ByValue, true);
	}
	#endregion

	#region Helper Functions
	private bool ValidateObject()
	{
		return true;
	}
	private DepartmentMaster GetObjectForInsertUpdate()
	{
		objDepartmentMaster = new DepartmentMaster();

		if (ViewState[editIndexKey] == null)
		{
			objDepartmentMaster.Version = BusinessUtility.RECORD_VERSION;
			objDepartmentMaster.CreatedBy = LoggedInUser;
			objDepartmentMaster.CreatedOn = GeneralUtility.CurrentDateTime;
		}
		else
		{
			objDepartmentMaster.DepartmentId = Convert.ToInt32(grdDepartmentMaster.DataKeys[Convert.ToInt32(ViewState[editIndexKey])].Values[DEPARTMENT_ID_INDEX].ToString());
			objDepartmentMaster.Version = Convert.ToInt16(grdDepartmentMaster.DataKeys[Convert.ToInt16(ViewState[editIndexKey])].Values[VERSION_INDEX].ToString()) + 1;
		}

		objDepartmentMaster.DepartmentCode = txtDepartmentCode.Text;
		objDepartmentMaster.DepartmentName = txtDepartmentName.Text;
		objDepartmentMaster.Description = txtDescription.Text;
		if (ddlHod.SelectedIndex != 0)
		{
			objDepartmentMaster.Hod = new EmployeeDetail();
			objDepartmentMaster.Hod.EmployeeId = Convert.ToInt32(ddlHod.SelectedItem.Value);
		}
		objDepartmentMaster.ModifiedBy = LoggedInUser;
		objDepartmentMaster.ModifiedOn = GeneralUtility.CurrentDateTime;
		objDepartmentMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
		return objDepartmentMaster;
	}
	private DepartmentMaster GetObjectForActivateDeactivate(int editIndex,RecordStatus objStatus)
	{
		objDepartmentMaster = new DepartmentMaster();
		objDepartmentMaster.DepartmentId = Convert.ToInt32(grdDepartmentMaster.DataKeys[editIndex].Values[DEPARTMENT_ID_INDEX].ToString());
		objDepartmentMaster.Version = Convert.ToInt16(grdDepartmentMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString()) + 1;
		objDepartmentMaster.ModifiedBy = LoggedInUser;
		objDepartmentMaster.RecordStatus = Convert.ToInt16(objStatus);
		return objDepartmentMaster;
	}
	private DepartmentMaster SelectRecordById(int editIndex)
	{
		objDepartmentMasterBL = new DepartmentMasterBL();
		objDepartmentMaster = new DepartmentMaster();
		objDepartmentMaster.DepartmentId = Convert.ToInt32(grdDepartmentMaster.DataKeys[editIndex].Values[DEPARTMENT_ID_INDEX].ToString());
		objDepartmentMaster.Version = Convert.ToInt16(grdDepartmentMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString());
		objDepartmentMaster = objDepartmentMasterBL.SelectRecordById(objDepartmentMaster);
		return objDepartmentMaster;
	}
	#endregion
}
