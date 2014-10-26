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

public partial class BranchMasterUI : BasePage
{
	#region Page Variables
	BranchMaster objBranchMaster = null;
	BranchMasterBL objBranchMasterBL = null;
	EmployeeDetail objEmployeeDetail = null;
	EmployeeDetailBL objEmployeeDetailBL = null;

	private const int SELECT_COLUMN = 0;
	private const int ACTIVATE_COLUMN = 1;
	private const int DELETE_COLUMN = 2;

	private const int BRANCH_ID_INDEX = 0;
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
			objBranchMaster = BindBranchMasterGrid(RecordStatus.Active);
			if (objBranchMaster.DbOperationStatus != CommonConstant.SUCCEED)
			{
				btnAddNewRecord.Enabled = false;
				UIUtility.DisplayMessage(lblMessage, objBranchMaster.DbOperationStatus);
				return;
			}

			ViewState[isControlsLoaded] = false;

			if (grdBranchMaster.Rows.Count == 0)
			{
				BindBranchMasterControls();
				MultiViewBranchMaster.ActiveViewIndex = 1;
			}
		}
		else
		{
			if (rdbActiveRecord.Checked)
			{
				objBranchMaster = BindBranchMasterGrid(RecordStatus.Active);
				if (objBranchMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objBranchMaster.DbOperationStatus);
					return;
				}
				ViewActivateColumn(false);
			}
			else
			{
				objBranchMaster = BindBranchMasterGrid(RecordStatus.InActive);
				if (objBranchMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objBranchMaster.DbOperationStatus);
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
			grdBranchMaster.Columns[SELECT_COLUMN].Visible = false;
			grdBranchMaster.Columns[ACTIVATE_COLUMN].Visible = true;
			grdBranchMaster.Columns[DELETE_COLUMN].Visible = false;
		}
		else
		{
			grdBranchMaster.Columns[SELECT_COLUMN].Visible = true;
			grdBranchMaster.Columns[ACTIVATE_COLUMN].Visible = false;
			grdBranchMaster.Columns[DELETE_COLUMN].Visible = true;
		}
	}
	#endregion

	#region Grid Events and Functions
	protected void grdBranchMaster_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			objBranchMaster = SelectRecordById(grdBranchMaster.SelectedIndex);
			if (!objBranchMaster.DbOperationStatus.Equals(CommonConstant.FAIL))
			{
				if(!Convert.ToBoolean(objBranchMaster.IsRecordChanged))
				{
					ActivateControlsView(false, objBranchMaster, grdBranchMaster.SelectedIndex);
				}
				else
				{
					UIUtility.DisplayMessage(lblMessage, objBranchMaster.DbOperationStatus);
					InitializeForm();
				}
			}
			else
			{
				UIUtility.DisplayMessage(lblMessage, objBranchMaster.DbOperationStatus);
			}
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdBranchMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			objBranchMasterBL = new BranchMasterBL();
			objBranchMaster = GetObjectForActivateDeactivate(e.RowIndex,RecordStatus.InActive);
			objBranchMaster = objBranchMasterBL.ActivateDeactivateBranchMaster(objBranchMaster);
			UIUtility.DisplayMessage(lblMessage, objBranchMaster.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdBranchMaster_ActivatingObject(object sender, GridViewEditEventArgs e)
	{
		try
		{
			objBranchMasterBL = new BranchMasterBL();
			objBranchMaster = GetObjectForActivateDeactivate(e.NewEditIndex, RecordStatus.Active);
			objBranchMaster = objBranchMasterBL.ActivateDeactivateBranchMaster(objBranchMaster);
			UIUtility.DisplayMessage(lblMessage, objBranchMaster.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdBranchMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			grdBranchMaster.PageIndex = e.NewPageIndex;
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected BranchMaster BindBranchMasterGrid(RecordStatus objRecordStatus)
	{
		objBranchMasterBL = new BranchMasterBL();
		objBranchMaster = new BranchMaster();
		objBranchMaster.RecordStatus = Convert.ToInt16(objRecordStatus);

		objBranchMaster = objBranchMasterBL.SelectBranchMaster(objBranchMaster);
		if (objBranchMaster.DbOperationStatus == CommonConstant.SUCCEED)
		{
			grdBranchMaster.DataSource = objBranchMaster.ObjectDataSet.Tables[0];
			grdBranchMaster.DataBind();
		}
		return objBranchMaster;
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
				objBranchMaster = GetObjectForInsertUpdate();
				objBranchMasterBL = new BranchMasterBL();
				if (objBranchMaster.BranchId == null)
				{
					objBranchMaster = objBranchMasterBL.InsertBranchMaster(objBranchMaster);
				}
				else
				{
					objBranchMaster = objBranchMasterBL.UpdateBranchMaster(objBranchMaster);
				}
				if (objBranchMaster.DbOperationStatus == CommonConstant.SUCCEED
							|| objBranchMaster.DbOperationStatus == CommonConstant.INVALID)
				{
					InitializeForm();
					MultiViewBranchMaster.ActiveViewIndex = 0;
				}
				UIUtility.DisplayMessage(lblMessage, objBranchMaster.DbOperationStatus);
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
			MultiViewBranchMaster.ActiveViewIndex = 0;
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
	protected void BindBranchMasterControls()
	{
		if (!Convert.ToBoolean(ViewState[isControlsLoaded]))
		{
			objEmployeeDetailBL = new EmployeeDetailBL();
			objEmployeeDetail = new EmployeeDetail();
			objEmployeeDetail.RecordStatus = Convert.ToInt16(RecordStatus.Active);
			objEmployeeDetail = objEmployeeDetailBL.SelectEmployeeDetail(objEmployeeDetail);
			ddlBranch.DataSource = objEmployeeDetail.ObjectDataSet.Tables[0];
			ddlBranch.DataBind();
			ddlBranch.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

			uxBranchAddressUC.BindUCControls();
			ViewState[isControlsLoaded] = true;
		}
	}
	protected void ActivateControlsView(bool isNewRecord, BranchMaster objBranchMaster,int? editIndex)
	{
		if (isNewRecord)
		{
			ViewState[editIndexKey] = null;
			BindBranchMasterControls();
			UIUtility.InitializeControls(ViewBranchMasterControls);
		}
		else
		{
			ViewState[editIndexKey] = editIndex;
			BindBranchMasterControls();
			PopulateControlsData(objBranchMaster);
		}
		MultiViewBranchMaster.ActiveViewIndex = 1;
	}
	private void PopulateControlsData(BranchMaster objBranchMaster)
	{
		txtBranchCode.Text = objBranchMaster.BranchCode;
		txtBranchName.Text = objBranchMaster.BranchName;
		UIUtility.SelectCurrentListItem(ddlBranch, objBranchMaster.BranchHeadObject.EmployeeId, BindListItem.ByValue, true);
		txtEstablishedOn.Text = objBranchMaster.EstablishedOn.ToString();
		uxBranchAddressUC.SetUserControlData(objBranchMaster.BranchAddressObject);
		txtDescription.Text = objBranchMaster.Description;
	}
	#endregion

	#region Helper Functions
	private bool ValidateObject()
	{
		return true;
	}
	private BranchMaster GetObjectForInsertUpdate()
	{
		objBranchMaster = new BranchMaster();

		if (ViewState[editIndexKey] == null)
		{
			objBranchMaster.Version = BusinessUtility.RECORD_VERSION;
			objBranchMaster.CreatedBy = LoggedInUser;
			objBranchMaster.CreatedOn = GeneralUtility.CurrentDateTime;
		}
		else
		{
			objBranchMaster.BranchId = Convert.ToInt32(grdBranchMaster.DataKeys[Convert.ToInt32(ViewState[editIndexKey])].Values[BRANCH_ID_INDEX].ToString());
			objBranchMaster.Version = Convert.ToInt16(grdBranchMaster.DataKeys[Convert.ToInt16(ViewState[editIndexKey])].Values[VERSION_INDEX].ToString()) + 1;
		}

		objBranchMaster.BranchCode = txtBranchCode.Text;
		objBranchMaster.BranchName = txtBranchName.Text;
		if (ddlBranch.SelectedIndex != 0)
		{
			objBranchMaster.BranchHeadObject = new EmployeeDetail();
			objBranchMaster.BranchHeadObject.EmployeeId = Convert.ToInt32(ddlBranch.SelectedItem.Value);
		}
		objBranchMaster.EstablishedOn = Convert.ToDateTime(txtEstablishedOn.Text);
		objBranchMaster.BranchAddressObject = uxBranchAddressUC.GetUserControlData();
		objBranchMaster.Description = txtDescription.Text;
		objBranchMaster.ModifiedBy = LoggedInUser;
		objBranchMaster.ModifiedOn = GeneralUtility.CurrentDateTime;
		objBranchMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
		return objBranchMaster;
	}
	private BranchMaster GetObjectForActivateDeactivate(int editIndex,RecordStatus objStatus)
	{
		objBranchMaster = new BranchMaster();
		objBranchMaster.BranchId = Convert.ToInt32(grdBranchMaster.DataKeys[editIndex].Values[BRANCH_ID_INDEX].ToString());
		objBranchMaster.Version = Convert.ToInt16(grdBranchMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString()) + 1;
		objBranchMaster.ModifiedBy = LoggedInUser;
		objBranchMaster.RecordStatus = Convert.ToInt16(objStatus);
		return objBranchMaster;
	}
	private BranchMaster SelectRecordById(int editIndex)
	{
		objBranchMasterBL = new BranchMasterBL();
		objBranchMaster = new BranchMaster();
		objBranchMaster.BranchId = Convert.ToInt32(grdBranchMaster.DataKeys[editIndex].Values[BRANCH_ID_INDEX].ToString());
		objBranchMaster.Version = Convert.ToInt16(grdBranchMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString());
		objBranchMaster = objBranchMasterBL.SelectRecordById(objBranchMaster);
		return objBranchMaster;
	}
	#endregion
}
