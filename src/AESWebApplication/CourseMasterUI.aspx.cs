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

public partial class CourseMasterUI : BasePage
{
	#region Page Variables
	CourseMaster objCourseMaster = null;
	CourseMasterBL objCourseMasterBL = null;

	private const int SELECT_COLUMN = 0;
	private const int ACTIVATE_COLUMN = 1;
	private const int DELETE_COLUMN = 2;

	private const int COURSE_ID_INDEX = 0;
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
			objCourseMaster = BindCourseMasterGrid(RecordStatus.Active);
			if (objCourseMaster.DbOperationStatus != CommonConstant.SUCCEED)
			{
				btnAddNewRecord.Enabled = false;
				UIUtility.DisplayMessage(lblMessage, objCourseMaster.DbOperationStatus);
				return;
			}

			ViewState[isControlsLoaded] = false;

			if (grdCourseMaster.Rows.Count == 0)
			{
				BindCourseMasterControls();
				MultiViewCourseMaster.ActiveViewIndex = 1;
			}
		}
		else
		{
			if (rdbActiveRecord.Checked)
			{
				objCourseMaster = BindCourseMasterGrid(RecordStatus.Active);
				if (objCourseMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objCourseMaster.DbOperationStatus);
					return;
				}
				ViewActivateColumn(false);
			}
			else
			{
				objCourseMaster = BindCourseMasterGrid(RecordStatus.InActive);
				if (objCourseMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objCourseMaster.DbOperationStatus);
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
			grdCourseMaster.Columns[SELECT_COLUMN].Visible = false;
			grdCourseMaster.Columns[ACTIVATE_COLUMN].Visible = true;
			grdCourseMaster.Columns[DELETE_COLUMN].Visible = false;
		}
		else
		{
			grdCourseMaster.Columns[SELECT_COLUMN].Visible = true;
			grdCourseMaster.Columns[ACTIVATE_COLUMN].Visible = false;
			grdCourseMaster.Columns[DELETE_COLUMN].Visible = true;
		}
	}
	#endregion

	#region Grid Events and Functions
	protected void grdCourseMaster_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			objCourseMaster = SelectRecordById(grdCourseMaster.SelectedIndex);
			if (!objCourseMaster.DbOperationStatus.Equals(CommonConstant.FAIL))
			{
				if(!Convert.ToBoolean(objCourseMaster.IsRecordChanged))
				{
					ActivateControlsView(false, objCourseMaster, grdCourseMaster.SelectedIndex);
				}
				else
				{
					UIUtility.DisplayMessage(lblMessage, objCourseMaster.DbOperationStatus);
					InitializeForm();
				}
			}
			else
			{
				UIUtility.DisplayMessage(lblMessage, objCourseMaster.DbOperationStatus);
			}
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdCourseMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			objCourseMasterBL = new CourseMasterBL();
			objCourseMaster = GetObjectForActivateDeactivate(e.RowIndex,RecordStatus.InActive);
			objCourseMaster = objCourseMasterBL.ActivateDeactivateCourseMaster(objCourseMaster);
			UIUtility.DisplayMessage(lblMessage, objCourseMaster.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdCourseMaster_ActivatingObject(object sender, GridViewEditEventArgs e)
	{
		try
		{
			objCourseMasterBL = new CourseMasterBL();
			objCourseMaster = GetObjectForActivateDeactivate(e.NewEditIndex, RecordStatus.Active);
			objCourseMaster = objCourseMasterBL.ActivateDeactivateCourseMaster(objCourseMaster);
			UIUtility.DisplayMessage(lblMessage, objCourseMaster.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdCourseMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			grdCourseMaster.PageIndex = e.NewPageIndex;
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected CourseMaster BindCourseMasterGrid(RecordStatus objRecordStatus)
	{
		objCourseMasterBL = new CourseMasterBL();
		objCourseMaster = new CourseMaster();
		objCourseMaster.RecordStatus = Convert.ToInt16(objRecordStatus);

		objCourseMaster = objCourseMasterBL.SelectCourseMaster(objCourseMaster);
		if (objCourseMaster.DbOperationStatus == CommonConstant.SUCCEED)
		{
			grdCourseMaster.DataSource = objCourseMaster.ObjectDataSet.Tables[0];
			grdCourseMaster.DataBind();
		}
		return objCourseMaster;
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
				objCourseMaster = GetObjectForInsertUpdate();
				objCourseMasterBL = new CourseMasterBL();
				if (objCourseMaster.CourseId == null)
				{
					objCourseMaster = objCourseMasterBL.InsertCourseMaster(objCourseMaster);
				}
				else
				{
					objCourseMaster = objCourseMasterBL.UpdateCourseMaster(objCourseMaster);
				}
				if (objCourseMaster.DbOperationStatus == CommonConstant.SUCCEED
							|| objCourseMaster.DbOperationStatus == CommonConstant.INVALID)
				{
					InitializeForm();
					MultiViewCourseMaster.ActiveViewIndex = 0;
				}
				UIUtility.DisplayMessage(lblMessage, objCourseMaster.DbOperationStatus);
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
			MultiViewCourseMaster.ActiveViewIndex = 0;
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
	protected void BindCourseMasterControls()
	{
		if (!Convert.ToBoolean(ViewState[isControlsLoaded]))
		{
			ViewState[isControlsLoaded] = true;
		}
	}
	protected void ActivateControlsView(bool isNewRecord, CourseMaster objCourseMaster,int? editIndex)
	{
		if (isNewRecord)
		{
			ViewState[editIndexKey] = null;
			BindCourseMasterControls();
			UIUtility.InitializeControls(ViewCourseMasterControls);
		}
		else
		{
			ViewState[editIndexKey] = editIndex;
			BindCourseMasterControls();
			PopulateControlsData(objCourseMaster);
		}
		MultiViewCourseMaster.ActiveViewIndex = 1;
	}
	private void PopulateControlsData(CourseMaster objCourseMaster)
	{
		txtCourseName.Text = objCourseMaster.CourseName;
		txtDescription.Text = objCourseMaster.Description;
	}
	#endregion

	#region Helper Functions
	private bool ValidateObject()
	{
		return true;
	}
	private CourseMaster GetObjectForInsertUpdate()
	{
		objCourseMaster = new CourseMaster();

		if (ViewState[editIndexKey] == null)
		{
			objCourseMaster.Version = BusinessUtility.RECORD_VERSION;
			objCourseMaster.CreatedBy = LoggedInUser;
			objCourseMaster.CreatedOn = GeneralUtility.CurrentDateTime;
		}
		else
		{
			objCourseMaster.CourseId = Convert.ToInt32(grdCourseMaster.DataKeys[Convert.ToInt32(ViewState[editIndexKey])].Values[COURSE_ID_INDEX].ToString());
			objCourseMaster.Version = Convert.ToInt16(grdCourseMaster.DataKeys[Convert.ToInt16(ViewState[editIndexKey])].Values[VERSION_INDEX].ToString()) + 1;
		}

		objCourseMaster.CourseName = txtCourseName.Text;
		objCourseMaster.Description = txtDescription.Text;
		objCourseMaster.ModifiedBy = LoggedInUser;
		objCourseMaster.ModifiedOn = GeneralUtility.CurrentDateTime;
		objCourseMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
		return objCourseMaster;
	}
	private CourseMaster GetObjectForActivateDeactivate(int editIndex,RecordStatus objStatus)
	{
		objCourseMaster = new CourseMaster();
		objCourseMaster.CourseId = Convert.ToInt32(grdCourseMaster.DataKeys[editIndex].Values[COURSE_ID_INDEX].ToString());
		objCourseMaster.Version = Convert.ToInt16(grdCourseMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString()) + 1;
		objCourseMaster.ModifiedBy = LoggedInUser;
		objCourseMaster.RecordStatus = Convert.ToInt16(objStatus);
		return objCourseMaster;
	}
	private CourseMaster SelectRecordById(int editIndex)
	{
		objCourseMasterBL = new CourseMasterBL();
		objCourseMaster = new CourseMaster();
		objCourseMaster.CourseId = Convert.ToInt32(grdCourseMaster.DataKeys[editIndex].Values[COURSE_ID_INDEX].ToString());
		objCourseMaster.Version = Convert.ToInt16(grdCourseMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString());
		objCourseMaster = objCourseMasterBL.SelectRecordById(objCourseMaster);
		return objCourseMaster;
	}
	#endregion
}
