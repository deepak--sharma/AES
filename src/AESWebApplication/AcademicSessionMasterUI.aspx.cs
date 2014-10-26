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

public partial class AcademicSessionMasterUI : BasePage
{
	#region Page Variables
	AcademicSessionMaster objAcademicSessionMaster = null;
	AcademicSessionMasterBL objAcademicSessionMasterBL = null;

	private const int SELECT_COLUMN = 0;
	private const int ACTIVATE_COLUMN = 1;
	private const int DELETE_COLUMN = 2;

	private const int SESSION_ID_INDEX = 0;
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
			objAcademicSessionMaster = BindAcademicSessionMasterGrid(RecordStatus.Active);
			if (objAcademicSessionMaster.DbOperationStatus != CommonConstant.SUCCEED)
			{
				btnAddNewRecord.Enabled = false;
				UIUtility.DisplayMessage(lblMessage, objAcademicSessionMaster.DbOperationStatus);
				return;
			}

			ViewState[isControlsLoaded] = false;

			if (grdAcademicSessionMaster.Rows.Count == 0)
			{
				BindAcademicSessionMasterControls();
				MultiViewAcademicSessionMaster.ActiveViewIndex = 1;
			}
		}
		else
		{
			if (rdbActiveRecord.Checked)
			{
				objAcademicSessionMaster = BindAcademicSessionMasterGrid(RecordStatus.Active);
				if (objAcademicSessionMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objAcademicSessionMaster.DbOperationStatus);
					return;
				}
				ViewActivateColumn(false);
			}
			else
			{
				objAcademicSessionMaster = BindAcademicSessionMasterGrid(RecordStatus.InActive);
				if (objAcademicSessionMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objAcademicSessionMaster.DbOperationStatus);
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
			grdAcademicSessionMaster.Columns[SELECT_COLUMN].Visible = false;
			grdAcademicSessionMaster.Columns[ACTIVATE_COLUMN].Visible = true;
			grdAcademicSessionMaster.Columns[DELETE_COLUMN].Visible = false;
		}
		else
		{
			grdAcademicSessionMaster.Columns[SELECT_COLUMN].Visible = true;
			grdAcademicSessionMaster.Columns[ACTIVATE_COLUMN].Visible = false;
			grdAcademicSessionMaster.Columns[DELETE_COLUMN].Visible = true;
		}
	}
	#endregion

	#region Grid Events and Functions
	protected void grdAcademicSessionMaster_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			objAcademicSessionMaster = SelectRecordById(grdAcademicSessionMaster.SelectedIndex);
			if (!objAcademicSessionMaster.DbOperationStatus.Equals(CommonConstant.FAIL))
			{
				if(!Convert.ToBoolean(objAcademicSessionMaster.IsRecordChanged))
				{
					ActivateControlsView(false, objAcademicSessionMaster, grdAcademicSessionMaster.SelectedIndex);
				}
				else
				{
					UIUtility.DisplayMessage(lblMessage, objAcademicSessionMaster.DbOperationStatus);
					InitializeForm();
				}
			}
			else
			{
				UIUtility.DisplayMessage(lblMessage, objAcademicSessionMaster.DbOperationStatus);
			}
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdAcademicSessionMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			objAcademicSessionMasterBL = new AcademicSessionMasterBL();
			objAcademicSessionMaster = GetObjectForActivateDeactivate(e.RowIndex,RecordStatus.InActive);
			objAcademicSessionMaster = objAcademicSessionMasterBL.ActivateDeactivateAcademicSessionMaster(objAcademicSessionMaster);
			UIUtility.DisplayMessage(lblMessage, objAcademicSessionMaster.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdAcademicSessionMaster_ActivatingObject(object sender, GridViewEditEventArgs e)
	{
		try
		{
			objAcademicSessionMasterBL = new AcademicSessionMasterBL();
			objAcademicSessionMaster = GetObjectForActivateDeactivate(e.NewEditIndex, RecordStatus.Active);
			objAcademicSessionMaster = objAcademicSessionMasterBL.ActivateDeactivateAcademicSessionMaster(objAcademicSessionMaster);
			UIUtility.DisplayMessage(lblMessage, objAcademicSessionMaster.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdAcademicSessionMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			grdAcademicSessionMaster.PageIndex = e.NewPageIndex;
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected AcademicSessionMaster BindAcademicSessionMasterGrid(RecordStatus objRecordStatus)
	{
		objAcademicSessionMasterBL = new AcademicSessionMasterBL();
		objAcademicSessionMaster = new AcademicSessionMaster();
		objAcademicSessionMaster.RecordStatus = Convert.ToInt16(objRecordStatus);

		objAcademicSessionMaster = objAcademicSessionMasterBL.SelectAcademicSessionMaster(objAcademicSessionMaster);
		if (objAcademicSessionMaster.DbOperationStatus == CommonConstant.SUCCEED)
		{
			grdAcademicSessionMaster.DataSource = objAcademicSessionMaster.ObjectDataSet.Tables[0];
			grdAcademicSessionMaster.DataBind();
		}
		return objAcademicSessionMaster;
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
				objAcademicSessionMaster = GetObjectForInsertUpdate();
				objAcademicSessionMasterBL = new AcademicSessionMasterBL();
				if (objAcademicSessionMaster.SessionId == null)
				{
					objAcademicSessionMaster = objAcademicSessionMasterBL.InsertAcademicSessionMaster(objAcademicSessionMaster);
				}
				else
				{
					objAcademicSessionMaster = objAcademicSessionMasterBL.UpdateAcademicSessionMaster(objAcademicSessionMaster);
				}
				if (objAcademicSessionMaster.DbOperationStatus == CommonConstant.SUCCEED
							|| objAcademicSessionMaster.DbOperationStatus == CommonConstant.INVALID)
				{
					InitializeForm();
					MultiViewAcademicSessionMaster.ActiveViewIndex = 0;
				}
				UIUtility.DisplayMessage(lblMessage, objAcademicSessionMaster.DbOperationStatus);
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
			MultiViewAcademicSessionMaster.ActiveViewIndex = 0;
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
	protected void BindAcademicSessionMasterControls()
	{
		if (!Convert.ToBoolean(ViewState[isControlsLoaded]))
		{
			ViewState[isControlsLoaded] = true;
		}
	}
	protected void ActivateControlsView(bool isNewRecord, AcademicSessionMaster objAcademicSessionMaster,int? editIndex)
	{
		if (isNewRecord)
		{
			ViewState[editIndexKey] = null;
			BindAcademicSessionMasterControls();
			UIUtility.InitializeControls(ViewAcademicSessionMasterControls);
		}
		else
		{
			ViewState[editIndexKey] = editIndex;
			BindAcademicSessionMasterControls();
			PopulateControlsData(objAcademicSessionMaster);
		}
		MultiViewAcademicSessionMaster.ActiveViewIndex = 1;
	}
	private void PopulateControlsData(AcademicSessionMaster objAcademicSessionMaster)
	{
		txtSessionName.Text = objAcademicSessionMaster.SessionName;
	}
	#endregion

	#region Helper Functions
	private bool ValidateObject()
	{
		return true;
	}
	private AcademicSessionMaster GetObjectForInsertUpdate()
	{
		objAcademicSessionMaster = new AcademicSessionMaster();

		if (ViewState[editIndexKey] == null)
		{
			objAcademicSessionMaster.Version = BusinessUtility.RECORD_VERSION;
			objAcademicSessionMaster.CreatedBy = LoggedInUser;
			objAcademicSessionMaster.CreatedOn = GeneralUtility.CurrentDateTime;
		}
		else
		{
			objAcademicSessionMaster.SessionId = Convert.ToInt32(grdAcademicSessionMaster.DataKeys[Convert.ToInt32(ViewState[editIndexKey])].Values[SESSION_ID_INDEX].ToString());
			objAcademicSessionMaster.Version = Convert.ToInt16(grdAcademicSessionMaster.DataKeys[Convert.ToInt16(ViewState[editIndexKey])].Values[VERSION_INDEX].ToString()) + 1;
		}

		objAcademicSessionMaster.SessionName = txtSessionName.Text;
		objAcademicSessionMaster.ModifiedBy = LoggedInUser;
		objAcademicSessionMaster.ModifiedOn = GeneralUtility.CurrentDateTime;
		objAcademicSessionMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
		return objAcademicSessionMaster;
	}
	private AcademicSessionMaster GetObjectForActivateDeactivate(int editIndex,RecordStatus objStatus)
	{
		objAcademicSessionMaster = new AcademicSessionMaster();
		objAcademicSessionMaster.SessionId = Convert.ToInt32(grdAcademicSessionMaster.DataKeys[editIndex].Values[SESSION_ID_INDEX].ToString());
		objAcademicSessionMaster.Version = Convert.ToInt16(grdAcademicSessionMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString()) + 1;
		objAcademicSessionMaster.ModifiedBy = LoggedInUser;
		objAcademicSessionMaster.RecordStatus = Convert.ToInt16(objStatus);
		return objAcademicSessionMaster;
	}
	private AcademicSessionMaster SelectRecordById(int editIndex)
	{
		objAcademicSessionMasterBL = new AcademicSessionMasterBL();
		objAcademicSessionMaster = new AcademicSessionMaster();
		objAcademicSessionMaster.SessionId = Convert.ToInt32(grdAcademicSessionMaster.DataKeys[editIndex].Values[SESSION_ID_INDEX].ToString());
		objAcademicSessionMaster.Version = Convert.ToInt16(grdAcademicSessionMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString());
		objAcademicSessionMaster = objAcademicSessionMasterBL.SelectRecordById(objAcademicSessionMaster);
		return objAcademicSessionMaster;
	}
	#endregion
}
