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

public partial class MedicalMasterUI : BasePage
{
	#region Page Variables
	MedicalMaster objMedicalMaster = null;
	MedicalMasterBL objMedicalMasterBL = null;

	private const int SELECT_COLUMN = 0;
	private const int ACTIVATE_COLUMN = 1;
	private const int DELETE_COLUMN = 2;

	private const int MEDICAL_ID_INDEX = 0;
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
			objMedicalMaster = BindMedicalMasterGrid(RecordStatus.Active);
			if (objMedicalMaster.DbOperationStatus != CommonConstant.SUCCEED)
			{
				btnAddNewRecord.Enabled = false;
				UIUtility.DisplayMessage(lblMessage, objMedicalMaster.DbOperationStatus);
				return;
			}

			ViewState[isControlsLoaded] = false;

			if (grdMedicalMaster.Rows.Count == 0)
			{
				BindMedicalMasterControls();
				MultiViewMedicalMaster.ActiveViewIndex = 1;
			}
		}
		else
		{
			if (rdbActiveRecord.Checked)
			{
				objMedicalMaster = BindMedicalMasterGrid(RecordStatus.Active);
				if (objMedicalMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objMedicalMaster.DbOperationStatus);
					return;
				}
				ViewActivateColumn(false);
			}
			else
			{
				objMedicalMaster = BindMedicalMasterGrid(RecordStatus.InActive);
				if (objMedicalMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objMedicalMaster.DbOperationStatus);
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
			grdMedicalMaster.Columns[SELECT_COLUMN].Visible = false;
			grdMedicalMaster.Columns[ACTIVATE_COLUMN].Visible = true;
			grdMedicalMaster.Columns[DELETE_COLUMN].Visible = false;
		}
		else
		{
			grdMedicalMaster.Columns[SELECT_COLUMN].Visible = true;
			grdMedicalMaster.Columns[ACTIVATE_COLUMN].Visible = false;
			grdMedicalMaster.Columns[DELETE_COLUMN].Visible = true;
		}
	}
	#endregion

	#region Grid Events and Functions
	protected void grdMedicalMaster_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			objMedicalMaster = SelectRecordById(grdMedicalMaster.SelectedIndex);
			if (!objMedicalMaster.DbOperationStatus.Equals(CommonConstant.FAIL))
			{
				if(!Convert.ToBoolean(objMedicalMaster.IsRecordChanged))
				{
					ActivateControlsView(false, objMedicalMaster, grdMedicalMaster.SelectedIndex);
				}
				else
				{
					UIUtility.DisplayMessage(lblMessage, objMedicalMaster.DbOperationStatus);
					InitializeForm();
				}
			}
			else
			{
				UIUtility.DisplayMessage(lblMessage, objMedicalMaster.DbOperationStatus);
			}
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdMedicalMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			objMedicalMasterBL = new MedicalMasterBL();
			objMedicalMaster = GetObjectForActivateDeactivate(e.RowIndex,RecordStatus.InActive);
			objMedicalMaster = objMedicalMasterBL.ActivateDeactivateMedicalMaster(objMedicalMaster);
			UIUtility.DisplayMessage(lblMessage, objMedicalMaster.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdMedicalMaster_ActivatingObject(object sender, GridViewEditEventArgs e)
	{
		try
		{
			objMedicalMasterBL = new MedicalMasterBL();
			objMedicalMaster = GetObjectForActivateDeactivate(e.NewEditIndex, RecordStatus.Active);
			objMedicalMaster = objMedicalMasterBL.ActivateDeactivateMedicalMaster(objMedicalMaster);
			UIUtility.DisplayMessage(lblMessage, objMedicalMaster.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdMedicalMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			grdMedicalMaster.PageIndex = e.NewPageIndex;
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected MedicalMaster BindMedicalMasterGrid(RecordStatus objRecordStatus)
	{
		objMedicalMasterBL = new MedicalMasterBL();
		objMedicalMaster = new MedicalMaster();
		objMedicalMaster.RecordStatus = Convert.ToInt16(objRecordStatus);

		objMedicalMaster = objMedicalMasterBL.SelectMedicalMaster(objMedicalMaster);
		if (objMedicalMaster.DbOperationStatus == CommonConstant.SUCCEED)
		{
			grdMedicalMaster.DataSource = objMedicalMaster.ObjectDataSet.Tables[0];
			grdMedicalMaster.DataBind();
		}
		return objMedicalMaster;
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
				objMedicalMaster = GetObjectForInsertUpdate();
				objMedicalMasterBL = new MedicalMasterBL();
				if (objMedicalMaster.MedicalId == null)
				{
					objMedicalMaster = objMedicalMasterBL.InsertMedicalMaster(objMedicalMaster);
				}
				else
				{
					objMedicalMaster = objMedicalMasterBL.UpdateMedicalMaster(objMedicalMaster);
				}
				if (objMedicalMaster.DbOperationStatus == CommonConstant.SUCCEED
							|| objMedicalMaster.DbOperationStatus == CommonConstant.INVALID)
				{
					InitializeForm();
					MultiViewMedicalMaster.ActiveViewIndex = 0;
				}
				UIUtility.DisplayMessage(lblMessage, objMedicalMaster.DbOperationStatus);
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
			MultiViewMedicalMaster.ActiveViewIndex = 0;
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
	protected void BindMedicalMasterControls()
	{
		if (!Convert.ToBoolean(ViewState[isControlsLoaded]))
		{
			ViewState[isControlsLoaded] = true;
		}
	}
	protected void ActivateControlsView(bool isNewRecord, MedicalMaster objMedicalMaster,int? editIndex)
	{
		if (isNewRecord)
		{
			ViewState[editIndexKey] = null;
			BindMedicalMasterControls();
			UIUtility.InitializeControls(ViewMedicalMasterControls);
		}
		else
		{
			ViewState[editIndexKey] = editIndex;
			BindMedicalMasterControls();
			PopulateControlsData(objMedicalMaster);
		}
		MultiViewMedicalMaster.ActiveViewIndex = 1;
	}
	private void PopulateControlsData(MedicalMaster objMedicalMaster)
	{
		txtMedicalName.Text = objMedicalMaster.MedicalName;
		txtDescription.Text = objMedicalMaster.Description;
	}
	#endregion

	#region Helper Functions
	private bool ValidateObject()
	{
		return true;
	}
	private MedicalMaster GetObjectForInsertUpdate()
	{
		objMedicalMaster = new MedicalMaster();

		if (ViewState[editIndexKey] == null)
		{
			objMedicalMaster.Version = BusinessUtility.RECORD_VERSION;
			objMedicalMaster.CreatedBy = LoggedInUser;
			objMedicalMaster.CreatedOn = GeneralUtility.CurrentDateTime;
		}
		else
		{
			objMedicalMaster.MedicalId = Convert.ToInt32(grdMedicalMaster.DataKeys[Convert.ToInt32(ViewState[editIndexKey])].Values[MEDICAL_ID_INDEX].ToString());
			objMedicalMaster.Version = Convert.ToInt16(grdMedicalMaster.DataKeys[Convert.ToInt16(ViewState[editIndexKey])].Values[VERSION_INDEX].ToString()) + 1;
		}

		objMedicalMaster.MedicalName = txtMedicalName.Text;
		objMedicalMaster.Description = txtDescription.Text;
		objMedicalMaster.ModifiedBy = LoggedInUser;
		objMedicalMaster.ModifiedOn = GeneralUtility.CurrentDateTime;
		objMedicalMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
		return objMedicalMaster;
	}
	private MedicalMaster GetObjectForActivateDeactivate(int editIndex,RecordStatus objStatus)
	{
		objMedicalMaster = new MedicalMaster();
		objMedicalMaster.MedicalId = Convert.ToInt32(grdMedicalMaster.DataKeys[editIndex].Values[MEDICAL_ID_INDEX].ToString());
		objMedicalMaster.Version = Convert.ToInt16(grdMedicalMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString()) + 1;
		objMedicalMaster.ModifiedBy = LoggedInUser;
		objMedicalMaster.RecordStatus = Convert.ToInt16(objStatus);
		return objMedicalMaster;
	}
	private MedicalMaster SelectRecordById(int editIndex)
	{
		objMedicalMasterBL = new MedicalMasterBL();
		objMedicalMaster = new MedicalMaster();
		objMedicalMaster.MedicalId = Convert.ToInt32(grdMedicalMaster.DataKeys[editIndex].Values[MEDICAL_ID_INDEX].ToString());
		objMedicalMaster.Version = Convert.ToInt16(grdMedicalMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString());
		objMedicalMaster = objMedicalMasterBL.SelectRecordById(objMedicalMaster);
		return objMedicalMaster;
	}
	#endregion
}
