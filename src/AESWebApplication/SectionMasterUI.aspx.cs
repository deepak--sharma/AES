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

public partial class SectionMasterUI : BasePage
{
	#region Page Variables
	SectionMaster objSectionMaster = null;
	SectionMasterBL objSectionMasterBL = null;
	DivisionMaster objDivisionMaster = null;
	DivisionMasterBL objDivisionMasterBL = null;

	private const int SELECT_COLUMN = 0;
	private const int ACTIVATE_COLUMN = 1;
	private const int DELETE_COLUMN = 2;

	private const int SECTION_ID_INDEX = 0;
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
			objSectionMaster = BindSectionMasterGrid(RecordStatus.Active);
			if (objSectionMaster.DbOperationStatus != CommonConstant.SUCCEED)
			{
				btnAddNewRecord.Enabled = false;
				UIUtility.DisplayMessage(lblMessage, objSectionMaster.DbOperationStatus);
				return;
			}

			ViewState[isControlsLoaded] = false;

			if (grdSectionMaster.Rows.Count == 0)
			{
				BindSectionMasterControls();
				MultiViewSectionMaster.ActiveViewIndex = 1;
			}
		}
		else
		{
			if (rdbActiveRecord.Checked)
			{
				objSectionMaster = BindSectionMasterGrid(RecordStatus.Active);
				if (objSectionMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objSectionMaster.DbOperationStatus);
					return;
				}
				ViewActivateColumn(false);
			}
			else
			{
				objSectionMaster = BindSectionMasterGrid(RecordStatus.InActive);
				if (objSectionMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objSectionMaster.DbOperationStatus);
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
			grdSectionMaster.Columns[SELECT_COLUMN].Visible = false;
			grdSectionMaster.Columns[ACTIVATE_COLUMN].Visible = true;
			grdSectionMaster.Columns[DELETE_COLUMN].Visible = false;
		}
		else
		{
			grdSectionMaster.Columns[SELECT_COLUMN].Visible = true;
			grdSectionMaster.Columns[ACTIVATE_COLUMN].Visible = false;
			grdSectionMaster.Columns[DELETE_COLUMN].Visible = true;
		}
	}
	#endregion

	#region Grid Events and Functions
	protected void grdSectionMaster_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			objSectionMaster = SelectRecordById(grdSectionMaster.SelectedIndex);
			if (!objSectionMaster.DbOperationStatus.Equals(CommonConstant.FAIL))
			{
				if(!Convert.ToBoolean(objSectionMaster.IsRecordChanged))
				{
					ActivateControlsView(false, objSectionMaster, grdSectionMaster.SelectedIndex);
				}
				else
				{
					UIUtility.DisplayMessage(lblMessage, objSectionMaster.DbOperationStatus);
					InitializeForm();
				}
			}
			else
			{
				UIUtility.DisplayMessage(lblMessage, objSectionMaster.DbOperationStatus);
			}
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdSectionMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			objSectionMasterBL = new SectionMasterBL();
			objSectionMaster = GetObjectForActivateDeactivate(e.RowIndex,RecordStatus.InActive);
			objSectionMaster = objSectionMasterBL.ActivateDeactivateSectionMaster(objSectionMaster);
			UIUtility.DisplayMessage(lblMessage, objSectionMaster.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdSectionMaster_ActivatingObject(object sender, GridViewEditEventArgs e)
	{
		try
		{
			objSectionMasterBL = new SectionMasterBL();
			objSectionMaster = GetObjectForActivateDeactivate(e.NewEditIndex, RecordStatus.Active);
			objSectionMaster = objSectionMasterBL.ActivateDeactivateSectionMaster(objSectionMaster);
			UIUtility.DisplayMessage(lblMessage, objSectionMaster.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdSectionMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			grdSectionMaster.PageIndex = e.NewPageIndex;
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected SectionMaster BindSectionMasterGrid(RecordStatus objRecordStatus)
	{
		objSectionMasterBL = new SectionMasterBL();
		objSectionMaster = new SectionMaster();
		objSectionMaster.RecordStatus = Convert.ToInt16(objRecordStatus);

		objSectionMaster = objSectionMasterBL.SelectSectionMaster(objSectionMaster);
		if (objSectionMaster.DbOperationStatus == CommonConstant.SUCCEED)
		{
			grdSectionMaster.DataSource = objSectionMaster.ObjectDataSet.Tables[0];
			grdSectionMaster.DataBind();
		}
		return objSectionMaster;
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
				objSectionMaster = GetObjectForInsertUpdate();
				objSectionMasterBL = new SectionMasterBL();
				if (objSectionMaster.SectionId == null)
				{
					objSectionMaster = objSectionMasterBL.InsertSectionMaster(objSectionMaster);
				}
				else
				{
					objSectionMaster = objSectionMasterBL.UpdateSectionMaster(objSectionMaster);
				}
				if (objSectionMaster.DbOperationStatus == CommonConstant.SUCCEED
							|| objSectionMaster.DbOperationStatus == CommonConstant.INVALID)
				{
					InitializeForm();
					MultiViewSectionMaster.ActiveViewIndex = 0;
				}
				UIUtility.DisplayMessage(lblMessage, objSectionMaster.DbOperationStatus);
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
			MultiViewSectionMaster.ActiveViewIndex = 0;
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
	protected void BindSectionMasterControls()
	{
		if (!Convert.ToBoolean(ViewState[isControlsLoaded]))
		{

			ViewState[isControlsLoaded] = true;
		}
	}
	protected void ActivateControlsView(bool isNewRecord, SectionMaster objSectionMaster,int? editIndex)
	{
		if (isNewRecord)
		{
			ViewState[editIndexKey] = null;
			BindSectionMasterControls();
			UIUtility.InitializeControls(ViewSectionMasterControls);
		}
		else
		{
			ViewState[editIndexKey] = editIndex;
			BindSectionMasterControls();
			PopulateControlsData(objSectionMaster);
		}
		MultiViewSectionMaster.ActiveViewIndex = 1;
	}
	private void PopulateControlsData(SectionMaster objSectionMaster)
	{		
		txtSectionName.Text = objSectionMaster.SectionName;
		txtDescription.Text = objSectionMaster.Description;
	}
	#endregion

	#region Helper Functions
	private bool ValidateObject()
	{
		return true;
	}
	private SectionMaster GetObjectForInsertUpdate()
	{
		objSectionMaster = new SectionMaster();

		if (ViewState[editIndexKey] == null)
		{
			objSectionMaster.Version = BusinessUtility.RECORD_VERSION;
			objSectionMaster.CreatedBy = LoggedInUser;
			objSectionMaster.CreatedOn = GeneralUtility.CurrentDateTime;
		}
		else
		{
			objSectionMaster.SectionId = Convert.ToInt32(grdSectionMaster.DataKeys[Convert.ToInt32(ViewState[editIndexKey])].Values[SECTION_ID_INDEX].ToString());
			objSectionMaster.Version = Convert.ToInt16(grdSectionMaster.DataKeys[Convert.ToInt16(ViewState[editIndexKey])].Values[VERSION_INDEX].ToString()) + 1;
		}
		
		objSectionMaster.SectionName = txtSectionName.Text;
		objSectionMaster.Description = txtDescription.Text;
		objSectionMaster.ModifiedBy = LoggedInUser;
		objSectionMaster.ModifiedOn = GeneralUtility.CurrentDateTime;
		objSectionMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
		return objSectionMaster;
	}
	private SectionMaster GetObjectForActivateDeactivate(int editIndex,RecordStatus objStatus)
	{
		objSectionMaster = new SectionMaster();
		objSectionMaster.SectionId = Convert.ToInt32(grdSectionMaster.DataKeys[editIndex].Values[SECTION_ID_INDEX].ToString());
		objSectionMaster.Version = Convert.ToInt16(grdSectionMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString()) + 1;
		objSectionMaster.ModifiedBy = LoggedInUser;
		objSectionMaster.RecordStatus = Convert.ToInt16(objStatus);
		return objSectionMaster;
	}
	private SectionMaster SelectRecordById(int editIndex)
	{
		objSectionMasterBL = new SectionMasterBL();
		objSectionMaster = new SectionMaster();
		objSectionMaster.SectionId = Convert.ToInt32(grdSectionMaster.DataKeys[editIndex].Values[SECTION_ID_INDEX].ToString());
		objSectionMaster.Version = Convert.ToInt16(grdSectionMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString());
		objSectionMaster = objSectionMasterBL.SelectRecordById(objSectionMaster);
		return objSectionMaster;
	}
	#endregion
}
