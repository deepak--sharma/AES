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

public partial class DesignationMasterUI : BasePage
{
	#region Page Variables
	DesignationMaster objDesignationMaster = null;
	DesignationMasterBL objDesignationMasterBL = null;

	private const int SELECT_COLUMN = 0;
	private const int ACTIVATE_COLUMN = 1;
	private const int DELETE_COLUMN = 2;

	private const int DESIGNATION_ID_INDEX = 0;
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
			objDesignationMaster = BindDesignationMasterGrid(RecordStatus.Active);
			if (objDesignationMaster.DbOperationStatus != CommonConstant.SUCCEED)
			{
				btnAddNewRecord.Enabled = false;
				UIUtility.DisplayMessage(lblMessage, objDesignationMaster.DbOperationStatus);
				return;
			}

			ViewState[isControlsLoaded] = false;

			if (grdDesignationMaster.Rows.Count == 0)
			{
				BindDesignationMasterControls();
				MultiViewDesignationMaster.ActiveViewIndex = 1;
			}
		}
		else
		{
			if (rdbActiveRecord.Checked)
			{
				objDesignationMaster = BindDesignationMasterGrid(RecordStatus.Active);
				if (objDesignationMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objDesignationMaster.DbOperationStatus);
					return;
				}
				ViewActivateColumn(false);
			}
			else
			{
				objDesignationMaster = BindDesignationMasterGrid(RecordStatus.InActive);
				if (objDesignationMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objDesignationMaster.DbOperationStatus);
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
			grdDesignationMaster.Columns[SELECT_COLUMN].Visible = false;
			grdDesignationMaster.Columns[ACTIVATE_COLUMN].Visible = true;
			grdDesignationMaster.Columns[DELETE_COLUMN].Visible = false;
		}
		else
		{
			grdDesignationMaster.Columns[SELECT_COLUMN].Visible = true;
			grdDesignationMaster.Columns[ACTIVATE_COLUMN].Visible = false;
			grdDesignationMaster.Columns[DELETE_COLUMN].Visible = true;
		}
	}
	#endregion

	#region Grid Events and Functions
	protected void grdDesignationMaster_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			objDesignationMaster = SelectRecordById(grdDesignationMaster.SelectedIndex);
			if (!objDesignationMaster.DbOperationStatus.Equals(CommonConstant.FAIL))
			{
				if(!Convert.ToBoolean(objDesignationMaster.IsRecordChanged))
				{
					ActivateControlsView(false, objDesignationMaster, grdDesignationMaster.SelectedIndex);
				}
				else
				{
					UIUtility.DisplayMessage(lblMessage, objDesignationMaster.DbOperationStatus);
					InitializeForm();
				}
			}
			else
			{
				UIUtility.DisplayMessage(lblMessage, objDesignationMaster.DbOperationStatus);
			}
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdDesignationMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			objDesignationMasterBL = new DesignationMasterBL();
			objDesignationMaster = GetObjectForActivateDeactivate(e.RowIndex,RecordStatus.InActive);
			objDesignationMaster = objDesignationMasterBL.ActivateDeactivateDesignationMaster(objDesignationMaster);
			UIUtility.DisplayMessage(lblMessage, objDesignationMaster.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdDesignationMaster_ActivatingObject(object sender, GridViewEditEventArgs e)
	{
		try
		{
			objDesignationMasterBL = new DesignationMasterBL();
			objDesignationMaster = GetObjectForActivateDeactivate(e.NewEditIndex, RecordStatus.Active);
			objDesignationMaster = objDesignationMasterBL.ActivateDeactivateDesignationMaster(objDesignationMaster);
			UIUtility.DisplayMessage(lblMessage, objDesignationMaster.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdDesignationMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			grdDesignationMaster.PageIndex = e.NewPageIndex;
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected DesignationMaster BindDesignationMasterGrid(RecordStatus objRecordStatus)
	{
		objDesignationMasterBL = new DesignationMasterBL();
		objDesignationMaster = new DesignationMaster();
		objDesignationMaster.RecordStatus = Convert.ToInt16(objRecordStatus);

		objDesignationMaster = objDesignationMasterBL.SelectDesignationMaster(objDesignationMaster);
		if (objDesignationMaster.DbOperationStatus == CommonConstant.SUCCEED)
		{
			grdDesignationMaster.DataSource = objDesignationMaster.ObjectDataSet.Tables[0];
			grdDesignationMaster.DataBind();
		}
		return objDesignationMaster;
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
				objDesignationMaster = GetObjectForInsertUpdate();
				objDesignationMasterBL = new DesignationMasterBL();
				if (objDesignationMaster.DesignationId == null)
				{
					objDesignationMaster = objDesignationMasterBL.InsertDesignationMaster(objDesignationMaster);
				}
				else
				{
					objDesignationMaster = objDesignationMasterBL.UpdateDesignationMaster(objDesignationMaster);
				}
				if (objDesignationMaster.DbOperationStatus == CommonConstant.SUCCEED
							|| objDesignationMaster.DbOperationStatus == CommonConstant.INVALID)
				{
					InitializeForm();
					MultiViewDesignationMaster.ActiveViewIndex = 0;
				}
				UIUtility.DisplayMessage(lblMessage, objDesignationMaster.DbOperationStatus);
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
			MultiViewDesignationMaster.ActiveViewIndex = 0;
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
	protected void BindDesignationMasterControls()
	{
		if (!Convert.ToBoolean(ViewState[isControlsLoaded]))
		{
			ViewState[isControlsLoaded] = true;
		}
	}
	protected void ActivateControlsView(bool isNewRecord, DesignationMaster objDesignationMaster,int? editIndex)
	{
		if (isNewRecord)
		{
			ViewState[editIndexKey] = null;
			BindDesignationMasterControls();
			UIUtility.InitializeControls(ViewDesignationMasterControls);
		}
		else
		{
			ViewState[editIndexKey] = editIndex;
			BindDesignationMasterControls();
			PopulateControlsData(objDesignationMaster);
		}
		MultiViewDesignationMaster.ActiveViewIndex = 1;
	}
	private void PopulateControlsData(DesignationMaster objDesignationMaster)
	{
		txtDesignationCode.Text = objDesignationMaster.DesignationCode;
		txtDesignationName.Text = objDesignationMaster.DesignationName;
		txtDescription.Text = objDesignationMaster.Description;
	}
	#endregion

	#region Helper Functions
	private bool ValidateObject()
	{
		return true;
	}
	private DesignationMaster GetObjectForInsertUpdate()
	{
		objDesignationMaster = new DesignationMaster();

		if (ViewState[editIndexKey] == null)
		{
			objDesignationMaster.Version = BusinessUtility.RECORD_VERSION;
			objDesignationMaster.CreatedBy = LoggedInUser;
			objDesignationMaster.CreatedOn = GeneralUtility.CurrentDateTime;
		}
		else
		{
			objDesignationMaster.DesignationId = Convert.ToInt32(grdDesignationMaster.DataKeys[Convert.ToInt32(ViewState[editIndexKey])].Values[DESIGNATION_ID_INDEX].ToString());
			objDesignationMaster.Version = Convert.ToInt16(grdDesignationMaster.DataKeys[Convert.ToInt16(ViewState[editIndexKey])].Values[VERSION_INDEX].ToString()) + 1;
		}

		objDesignationMaster.DesignationCode = txtDesignationCode.Text;
		objDesignationMaster.DesignationName = txtDesignationName.Text;
		objDesignationMaster.Description = txtDescription.Text;
		objDesignationMaster.ModifiedBy = LoggedInUser;
		objDesignationMaster.ModifiedOn = GeneralUtility.CurrentDateTime;
		objDesignationMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
		return objDesignationMaster;
	}
	private DesignationMaster GetObjectForActivateDeactivate(int editIndex,RecordStatus objStatus)
	{
		objDesignationMaster = new DesignationMaster();
		objDesignationMaster.DesignationId = Convert.ToInt32(grdDesignationMaster.DataKeys[editIndex].Values[DESIGNATION_ID_INDEX].ToString());
		objDesignationMaster.Version = Convert.ToInt16(grdDesignationMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString()) + 1;
		objDesignationMaster.ModifiedBy = LoggedInUser;
		objDesignationMaster.RecordStatus = Convert.ToInt16(objStatus);
		return objDesignationMaster;
	}
	private DesignationMaster SelectRecordById(int editIndex)
	{
		objDesignationMasterBL = new DesignationMasterBL();
		objDesignationMaster = new DesignationMaster();
		objDesignationMaster.DesignationId = Convert.ToInt32(grdDesignationMaster.DataKeys[editIndex].Values[DESIGNATION_ID_INDEX].ToString());
		objDesignationMaster.Version = Convert.ToInt16(grdDesignationMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString());
		objDesignationMaster = objDesignationMasterBL.SelectRecordById(objDesignationMaster);
		return objDesignationMaster;
	}
	#endregion
}
