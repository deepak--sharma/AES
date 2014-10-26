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

public partial class SkillMasterUI : BasePage
{
	#region Page Variables
	SkillMaster objSkillMaster = null;
	SkillMasterBL objSkillMasterBL = null;

	private const int SELECT_COLUMN = 0;
	private const int ACTIVATE_COLUMN = 1;
	private const int DELETE_COLUMN = 2;

	private const int SKILL_ID_INDEX = 0;
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
			objSkillMaster = BindSkillMasterGrid(RecordStatus.Active);
			if (objSkillMaster.DbOperationStatus != CommonConstant.SUCCEED)
			{
				btnAddNewRecord.Enabled = false;
				UIUtility.DisplayMessage(lblMessage, objSkillMaster.DbOperationStatus);
				return;
			}

			ViewState[isControlsLoaded] = false;

			if (grdSkillMaster.Rows.Count == 0)
			{
				BindSkillMasterControls();
				MultiViewSkillMaster.ActiveViewIndex = 1;
			}
		}
		else
		{
			if (rdbActiveRecord.Checked)
			{
				objSkillMaster = BindSkillMasterGrid(RecordStatus.Active);
				if (objSkillMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objSkillMaster.DbOperationStatus);
					return;
				}
				ViewActivateColumn(false);
			}
			else
			{
				objSkillMaster = BindSkillMasterGrid(RecordStatus.InActive);
				if (objSkillMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objSkillMaster.DbOperationStatus);
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
			grdSkillMaster.Columns[SELECT_COLUMN].Visible = false;
			grdSkillMaster.Columns[ACTIVATE_COLUMN].Visible = true;
			grdSkillMaster.Columns[DELETE_COLUMN].Visible = false;
		}
		else
		{
			grdSkillMaster.Columns[SELECT_COLUMN].Visible = true;
			grdSkillMaster.Columns[ACTIVATE_COLUMN].Visible = false;
			grdSkillMaster.Columns[DELETE_COLUMN].Visible = true;
		}
	}
	#endregion

	#region Grid Events and Functions
	protected void grdSkillMaster_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			objSkillMaster = SelectRecordById(grdSkillMaster.SelectedIndex);
			if (!objSkillMaster.DbOperationStatus.Equals(CommonConstant.FAIL))
			{
				if(!Convert.ToBoolean(objSkillMaster.IsRecordChanged))
				{
					ActivateControlsView(false, objSkillMaster, grdSkillMaster.SelectedIndex);
				}
				else
				{
					UIUtility.DisplayMessage(lblMessage, objSkillMaster.DbOperationStatus);
					InitializeForm();
				}
			}
			else
			{
				UIUtility.DisplayMessage(lblMessage, objSkillMaster.DbOperationStatus);
			}
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdSkillMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			objSkillMasterBL = new SkillMasterBL();
			objSkillMaster = GetObjectForActivateDeactivate(e.RowIndex,RecordStatus.InActive);
			objSkillMaster = objSkillMasterBL.ActivateDeactivateSkillMaster(objSkillMaster);
			UIUtility.DisplayMessage(lblMessage, objSkillMaster.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdSkillMaster_ActivatingObject(object sender, GridViewEditEventArgs e)
	{
		try
		{
			objSkillMasterBL = new SkillMasterBL();
			objSkillMaster = GetObjectForActivateDeactivate(e.NewEditIndex, RecordStatus.Active);
			objSkillMaster = objSkillMasterBL.ActivateDeactivateSkillMaster(objSkillMaster);
			UIUtility.DisplayMessage(lblMessage, objSkillMaster.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdSkillMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			grdSkillMaster.PageIndex = e.NewPageIndex;
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected SkillMaster BindSkillMasterGrid(RecordStatus objRecordStatus)
	{
		objSkillMasterBL = new SkillMasterBL();
		objSkillMaster = new SkillMaster();
		objSkillMaster.RecordStatus = Convert.ToInt16(objRecordStatus);

		objSkillMaster = objSkillMasterBL.SelectSkillMaster(objSkillMaster);
		if (objSkillMaster.DbOperationStatus == CommonConstant.SUCCEED)
		{
			grdSkillMaster.DataSource = objSkillMaster.ObjectDataSet.Tables[0];
			grdSkillMaster.DataBind();
		}
		return objSkillMaster;
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
				objSkillMaster = GetObjectForInsertUpdate();
				objSkillMasterBL = new SkillMasterBL();
				if (objSkillMaster.SkillId == null)
				{
					objSkillMaster = objSkillMasterBL.InsertSkillMaster(objSkillMaster);
				}
				else
				{
					objSkillMaster = objSkillMasterBL.UpdateSkillMaster(objSkillMaster);
				}
				if (objSkillMaster.DbOperationStatus == CommonConstant.SUCCEED
							|| objSkillMaster.DbOperationStatus == CommonConstant.INVALID)
				{
					InitializeForm();
					MultiViewSkillMaster.ActiveViewIndex = 0;
				}
				UIUtility.DisplayMessage(lblMessage, objSkillMaster.DbOperationStatus);
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
			MultiViewSkillMaster.ActiveViewIndex = 0;
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
	protected void BindSkillMasterControls()
	{
		if (!Convert.ToBoolean(ViewState[isControlsLoaded]))
		{
			ViewState[isControlsLoaded] = true;
		}
	}
	protected void ActivateControlsView(bool isNewRecord, SkillMaster objSkillMaster,int? editIndex)
	{
		if (isNewRecord)
		{
			ViewState[editIndexKey] = null;
			BindSkillMasterControls();
			UIUtility.InitializeControls(ViewSkillMasterControls);
		}
		else
		{
			ViewState[editIndexKey] = editIndex;
			BindSkillMasterControls();
			PopulateControlsData(objSkillMaster);
		}
		MultiViewSkillMaster.ActiveViewIndex = 1;
	}
	private void PopulateControlsData(SkillMaster objSkillMaster)
	{
		txtSkillName.Text = objSkillMaster.SkillName;
		txtDescription.Text = objSkillMaster.Description;
	}
	#endregion

	#region Helper Functions
	private bool ValidateObject()
	{
		return true;
	}
	private SkillMaster GetObjectForInsertUpdate()
	{
		objSkillMaster = new SkillMaster();

		if (ViewState[editIndexKey] == null)
		{
			objSkillMaster.Version = BusinessUtility.RECORD_VERSION;
			objSkillMaster.CreatedBy = LoggedInUser;
			objSkillMaster.CreatedOn = GeneralUtility.CurrentDateTime;
		}
		else
		{
			objSkillMaster.SkillId = Convert.ToInt32(grdSkillMaster.DataKeys[Convert.ToInt32(ViewState[editIndexKey])].Values[SKILL_ID_INDEX].ToString());
			objSkillMaster.Version = Convert.ToInt16(grdSkillMaster.DataKeys[Convert.ToInt16(ViewState[editIndexKey])].Values[VERSION_INDEX].ToString()) + 1;
		}

		objSkillMaster.SkillName = txtSkillName.Text;
		objSkillMaster.Description = txtDescription.Text;
		objSkillMaster.ModifiedBy = LoggedInUser;
		objSkillMaster.ModifiedOn = GeneralUtility.CurrentDateTime;
		objSkillMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
		return objSkillMaster;
	}
	private SkillMaster GetObjectForActivateDeactivate(int editIndex,RecordStatus objStatus)
	{
		objSkillMaster = new SkillMaster();
		objSkillMaster.SkillId = Convert.ToInt32(grdSkillMaster.DataKeys[editIndex].Values[SKILL_ID_INDEX].ToString());
		objSkillMaster.Version = Convert.ToInt16(grdSkillMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString()) + 1;
		objSkillMaster.ModifiedBy = LoggedInUser;
		objSkillMaster.RecordStatus = Convert.ToInt16(objStatus);
		return objSkillMaster;
	}
	private SkillMaster SelectRecordById(int editIndex)
	{
		objSkillMasterBL = new SkillMasterBL();
		objSkillMaster = new SkillMaster();
		objSkillMaster.SkillId = Convert.ToInt32(grdSkillMaster.DataKeys[editIndex].Values[SKILL_ID_INDEX].ToString());
		objSkillMaster.Version = Convert.ToInt16(grdSkillMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString());
		objSkillMaster = objSkillMasterBL.SelectRecordById(objSkillMaster);
		return objSkillMaster;
	}
	#endregion
}
