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

public partial class FeeStructureUI : BasePage
{
	#region Page Variables
	FeeStructure objFeeStructure = null;
	FeeStructureBL objFeeStructureBL = null;

	private const int SELECT_COLUMN = 0;
	private const int ACTIVATE_COLUMN = 1;
	private const int DELETE_COLUMN = 2;

	private const int FEE_STRUCTURE_ID_INDEX = 0;
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
			objFeeStructure = BindFeeStructureGrid(RecordStatus.Active);
			if (objFeeStructure.DbOperationStatus != CommonConstant.SUCCEED)
			{
				btnAddNewRecord.Enabled = false;
				UIUtility.DisplayMessage(lblMessage, objFeeStructure.DbOperationStatus);
				return;
			}

			ViewState[isControlsLoaded] = false;

			if (grdFeeStructure.Rows.Count == 0)
			{
				BindFeeStructureControls();
				MultiViewFeeStructure.ActiveViewIndex = 1;
			}
		}
		else
		{
			if (rdbActiveRecord.Checked)
			{
				objFeeStructure = BindFeeStructureGrid(RecordStatus.Active);
				if (objFeeStructure.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objFeeStructure.DbOperationStatus);
					return;
				}
				ViewActivateColumn(false);
			}
			else
			{
				objFeeStructure = BindFeeStructureGrid(RecordStatus.InActive);
				if (objFeeStructure.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objFeeStructure.DbOperationStatus);
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
			grdFeeStructure.Columns[SELECT_COLUMN].Visible = false;
			grdFeeStructure.Columns[ACTIVATE_COLUMN].Visible = true;
			grdFeeStructure.Columns[DELETE_COLUMN].Visible = false;
		}
		else
		{
			grdFeeStructure.Columns[SELECT_COLUMN].Visible = true;
			grdFeeStructure.Columns[ACTIVATE_COLUMN].Visible = false;
			grdFeeStructure.Columns[DELETE_COLUMN].Visible = true;
		}
	}
	#endregion

	#region Grid Events and Functions
	protected void grdFeeStructure_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			objFeeStructure = SelectRecordById(grdFeeStructure.SelectedIndex);
			if (!objFeeStructure.DbOperationStatus.Equals(CommonConstant.FAIL))
			{
				if(!Convert.ToBoolean(objFeeStructure.IsRecordChanged))
				{
					ActivateControlsView(false, objFeeStructure, grdFeeStructure.SelectedIndex);
				}
				else
				{
					UIUtility.DisplayMessage(lblMessage, objFeeStructure.DbOperationStatus);
					InitializeForm();
				}
			}
			else
			{
				UIUtility.DisplayMessage(lblMessage, objFeeStructure.DbOperationStatus);
			}
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdFeeStructure_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			objFeeStructureBL = new FeeStructureBL();
			objFeeStructure = GetObjectForActivateDeactivate(e.RowIndex,RecordStatus.InActive);
			objFeeStructure = objFeeStructureBL.ActivateDeactivateFeeStructure(objFeeStructure);
			UIUtility.DisplayMessage(lblMessage, objFeeStructure.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdFeeStructure_ActivatingObject(object sender, GridViewEditEventArgs e)
	{
		try
		{
			objFeeStructureBL = new FeeStructureBL();
			objFeeStructure = GetObjectForActivateDeactivate(e.NewEditIndex, RecordStatus.Active);
			objFeeStructure = objFeeStructureBL.ActivateDeactivateFeeStructure(objFeeStructure);
			UIUtility.DisplayMessage(lblMessage, objFeeStructure.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdFeeStructure_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			grdFeeStructure.PageIndex = e.NewPageIndex;
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected FeeStructure BindFeeStructureGrid(RecordStatus objRecordStatus)
	{
		objFeeStructureBL = new FeeStructureBL();
		objFeeStructure = new FeeStructure();
		objFeeStructure.RecordStatus = Convert.ToInt16(objRecordStatus);

		objFeeStructure = objFeeStructureBL.SelectFeeStructure(objFeeStructure);
		if (objFeeStructure.DbOperationStatus == CommonConstant.SUCCEED)
		{
			grdFeeStructure.DataSource = objFeeStructure.ObjectDataSet.Tables[0];
			grdFeeStructure.DataBind();
		}
		return objFeeStructure;
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
				objFeeStructure = GetObjectForInsertUpdate();
				objFeeStructureBL = new FeeStructureBL();
				if (objFeeStructure.FeeStructureId == null)
				{
					objFeeStructure = objFeeStructureBL.InsertFeeStructure(objFeeStructure);
				}
				else
				{
					objFeeStructure = objFeeStructureBL.UpdateFeeStructure(objFeeStructure);
				}
				if (objFeeStructure.DbOperationStatus == CommonConstant.SUCCEED
							|| objFeeStructure.DbOperationStatus == CommonConstant.INVALID)
				{
					InitializeForm();
					MultiViewFeeStructure.ActiveViewIndex = 0;
				}
				UIUtility.DisplayMessage(lblMessage, objFeeStructure.DbOperationStatus);
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
			MultiViewFeeStructure.ActiveViewIndex = 0;
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
	protected void BindFeeStructureControls()
	{
		if (!Convert.ToBoolean(ViewState[isControlsLoaded]))
		{
			ViewState[isControlsLoaded] = true;
		}		
	}
	protected void ActivateControlsView(bool isNewRecord, FeeStructure objFeeStructure,int? editIndex)
	{
		if (isNewRecord)
		{
			ViewState[editIndexKey] = null;
			BindFeeStructureControls();
			UIUtility.InitializeControls(ViewFeeStructureControls);
		}
		else
		{
			ViewState[editIndexKey] = editIndex;
			BindFeeStructureControls();
			PopulateControlsData(objFeeStructure);
		}
		MultiViewFeeStructure.ActiveViewIndex = 1;
	}
	private void PopulateControlsData(FeeStructure objFeeStructure)
	{
		txtFeeStructureName.Text = objFeeStructure.FeeStructureName;
		txtDescription.Text = objFeeStructure.Description;
	}
	#endregion

	#region Helper Functions
	private bool ValidateObject()
	{
		return true;
	}
	private FeeStructure GetObjectForInsertUpdate()
	{
		objFeeStructure = new FeeStructure();

		if (ViewState[editIndexKey] == null)
		{
			objFeeStructure.Version = BusinessUtility.RECORD_VERSION;
			objFeeStructure.CreatedBy = LoggedInUser;
			objFeeStructure.CreatedOn = GeneralUtility.CurrentDateTime;
		}
		else
		{
			objFeeStructure.FeeStructureId = Convert.ToInt32(grdFeeStructure.DataKeys[Convert.ToInt32(ViewState[editIndexKey])].Values[FEE_STRUCTURE_ID_INDEX].ToString());
			objFeeStructure.Version = Convert.ToInt16(grdFeeStructure.DataKeys[Convert.ToInt16(ViewState[editIndexKey])].Values[VERSION_INDEX].ToString()) + 1;
		}

		objFeeStructure.FeeStructureName = txtFeeStructureName.Text;
        objFeeStructure.Description = txtDescription.Text;
		objFeeStructure.ModifiedBy = LoggedInUser;
		objFeeStructure.ModifiedOn = GeneralUtility.CurrentDateTime;
		objFeeStructure.RecordStatus = Convert.ToInt16(RecordStatus.Active);
		return objFeeStructure;
	}
	private FeeStructure GetObjectForActivateDeactivate(int editIndex,RecordStatus objStatus)
	{
		objFeeStructure = new FeeStructure();
		objFeeStructure.FeeStructureId = Convert.ToInt32(grdFeeStructure.DataKeys[editIndex].Values[FEE_STRUCTURE_ID_INDEX].ToString());
		objFeeStructure.Version = Convert.ToInt16(grdFeeStructure.DataKeys[editIndex].Values[VERSION_INDEX].ToString()) + 1;
		objFeeStructure.ModifiedBy = LoggedInUser;
		objFeeStructure.RecordStatus = Convert.ToInt16(objStatus);
		return objFeeStructure;
	}
	private FeeStructure SelectRecordById(int editIndex)
	{
		objFeeStructureBL = new FeeStructureBL();
		objFeeStructure = new FeeStructure();
		objFeeStructure.FeeStructureId = Convert.ToInt32(grdFeeStructure.DataKeys[editIndex].Values[FEE_STRUCTURE_ID_INDEX].ToString());
		objFeeStructure.Version = Convert.ToInt16(grdFeeStructure.DataKeys[editIndex].Values[VERSION_INDEX].ToString());
		objFeeStructure = objFeeStructureBL.SelectRecordById(objFeeStructure);
		return objFeeStructure;
	}
	#endregion
}
