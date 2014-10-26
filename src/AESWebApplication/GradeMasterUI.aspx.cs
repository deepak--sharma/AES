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

public partial class GradeMasterUI : BasePage
{
	#region Page Variables
	GradeMaster objGradeMaster = null;
	GradeMasterBL objGradeMasterBL = null;

	private const int SELECT_COLUMN = 0;
	private const int ACTIVATE_COLUMN = 1;
	private const int DELETE_COLUMN = 2;

	private const int GRADE_ID_INDEX = 0;
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
			objGradeMaster = BindGradeMasterGrid(RecordStatus.Active);
			if (objGradeMaster.DbOperationStatus != CommonConstant.SUCCEED)
			{
				btnAddNewRecord.Enabled = false;
				UIUtility.DisplayMessage(lblMessage, objGradeMaster.DbOperationStatus);
				return;
			}

			ViewState[isControlsLoaded] = false;

			if (grdGradeMaster.Rows.Count == 0)
			{
				BindGradeMasterControls();
				MultiViewGradeMaster.ActiveViewIndex = 1;
			}
		}
		else
		{
			if (rdbActiveRecord.Checked)
			{
				objGradeMaster = BindGradeMasterGrid(RecordStatus.Active);
				if (objGradeMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objGradeMaster.DbOperationStatus);
					return;
				}
				ViewActivateColumn(false);
			}
			else
			{
				objGradeMaster = BindGradeMasterGrid(RecordStatus.InActive);
				if (objGradeMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objGradeMaster.DbOperationStatus);
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
			grdGradeMaster.Columns[SELECT_COLUMN].Visible = false;
			grdGradeMaster.Columns[ACTIVATE_COLUMN].Visible = true;
			grdGradeMaster.Columns[DELETE_COLUMN].Visible = false;
		}
		else
		{
			grdGradeMaster.Columns[SELECT_COLUMN].Visible = true;
			grdGradeMaster.Columns[ACTIVATE_COLUMN].Visible = false;
			grdGradeMaster.Columns[DELETE_COLUMN].Visible = true;
		}
	}
	#endregion

	#region Grid Events and Functions
	protected void grdGradeMaster_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			objGradeMaster = SelectRecordById(grdGradeMaster.SelectedIndex);
			if (!objGradeMaster.DbOperationStatus.Equals(CommonConstant.FAIL))
			{
				if(!Convert.ToBoolean(objGradeMaster.IsRecordChanged))
				{
					ActivateControlsView(false, objGradeMaster, grdGradeMaster.SelectedIndex);
				}
				else
				{
					UIUtility.DisplayMessage(lblMessage, objGradeMaster.DbOperationStatus);
					InitializeForm();
				}
			}
			else
			{
				UIUtility.DisplayMessage(lblMessage, objGradeMaster.DbOperationStatus);
			}
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdGradeMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			objGradeMasterBL = new GradeMasterBL();
			objGradeMaster = GetObjectForActivateDeactivate(e.RowIndex,RecordStatus.InActive);
			objGradeMaster = objGradeMasterBL.ActivateDeactivateGradeMaster(objGradeMaster);
			UIUtility.DisplayMessage(lblMessage, objGradeMaster.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdGradeMaster_ActivatingObject(object sender, GridViewEditEventArgs e)
	{
		try
		{
			objGradeMasterBL = new GradeMasterBL();
			objGradeMaster = GetObjectForActivateDeactivate(e.NewEditIndex, RecordStatus.Active);
			objGradeMaster = objGradeMasterBL.ActivateDeactivateGradeMaster(objGradeMaster);
			UIUtility.DisplayMessage(lblMessage, objGradeMaster.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdGradeMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			grdGradeMaster.PageIndex = e.NewPageIndex;
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected GradeMaster BindGradeMasterGrid(RecordStatus objRecordStatus)
	{
		objGradeMasterBL = new GradeMasterBL();
		objGradeMaster = new GradeMaster();
		objGradeMaster.RecordStatus = Convert.ToInt16(objRecordStatus);

		objGradeMaster = objGradeMasterBL.SelectGradeMaster(objGradeMaster);
		if (objGradeMaster.DbOperationStatus == CommonConstant.SUCCEED)
		{
			grdGradeMaster.DataSource = objGradeMaster.ObjectDataSet.Tables[0];
			grdGradeMaster.DataBind();
		}
		return objGradeMaster;
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
				objGradeMaster = GetObjectForInsertUpdate();
				objGradeMasterBL = new GradeMasterBL();
				if (objGradeMaster.GradeId == null)
				{
					objGradeMaster = objGradeMasterBL.InsertGradeMaster(objGradeMaster);
				}
				else
				{
					objGradeMaster = objGradeMasterBL.UpdateGradeMaster(objGradeMaster);
				}
				if (objGradeMaster.DbOperationStatus == CommonConstant.SUCCEED
							|| objGradeMaster.DbOperationStatus == CommonConstant.INVALID)
				{
					InitializeForm();
					MultiViewGradeMaster.ActiveViewIndex = 0;
				}
				UIUtility.DisplayMessage(lblMessage, objGradeMaster.DbOperationStatus);
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
			MultiViewGradeMaster.ActiveViewIndex = 0;
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
	protected void BindGradeMasterControls()
	{
		if (!Convert.ToBoolean(ViewState[isControlsLoaded]))
		{
			ViewState[isControlsLoaded] = true;
		}
	}
	protected void ActivateControlsView(bool isNewRecord, GradeMaster objGradeMaster,int? editIndex)
	{
		if (isNewRecord)
		{
			ViewState[editIndexKey] = null;
			BindGradeMasterControls();
			UIUtility.InitializeControls(ViewGradeMasterControls);
		}
		else
		{
			ViewState[editIndexKey] = editIndex;
			BindGradeMasterControls();
			PopulateControlsData(objGradeMaster);
		}
		MultiViewGradeMaster.ActiveViewIndex = 1;
	}
	private void PopulateControlsData(GradeMaster objGradeMaster)
	{
		txtGradeName.Text = objGradeMaster.GradeName;
		txtDescription.Text = objGradeMaster.Description;
	}
	#endregion

	#region Helper Functions
	private bool ValidateObject()
	{
		return true;
	}
	private GradeMaster GetObjectForInsertUpdate()
	{
		objGradeMaster = new GradeMaster();

		if (ViewState[editIndexKey] == null)
		{
			objGradeMaster.Version = BusinessUtility.RECORD_VERSION;
			objGradeMaster.CreatedBy = LoggedInUser;
			objGradeMaster.CreatedOn = GeneralUtility.CurrentDateTime;
		}
		else
		{
			objGradeMaster.GradeId = Convert.ToInt32(grdGradeMaster.DataKeys[Convert.ToInt32(ViewState[editIndexKey])].Values[GRADE_ID_INDEX].ToString());
			objGradeMaster.Version = Convert.ToInt16(grdGradeMaster.DataKeys[Convert.ToInt16(ViewState[editIndexKey])].Values[VERSION_INDEX].ToString()) + 1;
		}

		objGradeMaster.GradeName = txtGradeName.Text;
		objGradeMaster.Description = txtDescription.Text;
		objGradeMaster.ModifiedBy = LoggedInUser;
		objGradeMaster.ModifiedOn = GeneralUtility.CurrentDateTime;
		objGradeMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
		return objGradeMaster;
	}
	private GradeMaster GetObjectForActivateDeactivate(int editIndex,RecordStatus objStatus)
	{
		objGradeMaster = new GradeMaster();
		objGradeMaster.GradeId = Convert.ToInt32(grdGradeMaster.DataKeys[editIndex].Values[GRADE_ID_INDEX].ToString());
		objGradeMaster.Version = Convert.ToInt16(grdGradeMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString()) + 1;
		objGradeMaster.ModifiedBy = LoggedInUser;
		objGradeMaster.RecordStatus = Convert.ToInt16(objStatus);
		return objGradeMaster;
	}
	private GradeMaster SelectRecordById(int editIndex)
	{
		objGradeMasterBL = new GradeMasterBL();
		objGradeMaster = new GradeMaster();
		objGradeMaster.GradeId = Convert.ToInt32(grdGradeMaster.DataKeys[editIndex].Values[GRADE_ID_INDEX].ToString());
		objGradeMaster.Version = Convert.ToInt16(grdGradeMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString());
		objGradeMaster = objGradeMasterBL.SelectRecordById(objGradeMaster);
		return objGradeMaster;
	}
	#endregion
}
