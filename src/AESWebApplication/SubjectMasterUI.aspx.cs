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

public partial class SubjectMasterUI : BasePage
{
	#region Page Variables
	SubjectMaster objSubjectMaster = null;
	SubjectMasterBL objSubjectMasterBL = null;

	private const int SELECT_COLUMN = 0;
	private const int ACTIVATE_COLUMN = 1;
	private const int DELETE_COLUMN = 2;

	private const int SUBJECT_ID_INDEX = 0;
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
			objSubjectMaster = BindSubjectMasterGrid(RecordStatus.Active);
			if (objSubjectMaster.DbOperationStatus != CommonConstant.SUCCEED)
			{
				btnAddNewRecord.Enabled = false;
				UIUtility.DisplayMessage(lblMessage, objSubjectMaster.DbOperationStatus);
				return;
			}

			ViewState[isControlsLoaded] = false;

			if (grdSubjectMaster.Rows.Count == 0)
			{
				BindSubjectMasterControls();
				MultiViewSubjectMaster.ActiveViewIndex = 1;
			}
		}
		else
		{
			if (rdbActiveRecord.Checked)
			{
				objSubjectMaster = BindSubjectMasterGrid(RecordStatus.Active);
				if (objSubjectMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objSubjectMaster.DbOperationStatus);
					return;
				}
				ViewActivateColumn(false);
			}
			else
			{
				objSubjectMaster = BindSubjectMasterGrid(RecordStatus.InActive);
				if (objSubjectMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objSubjectMaster.DbOperationStatus);
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
			grdSubjectMaster.Columns[SELECT_COLUMN].Visible = false;
			grdSubjectMaster.Columns[ACTIVATE_COLUMN].Visible = true;
			grdSubjectMaster.Columns[DELETE_COLUMN].Visible = false;
		}
		else
		{
			grdSubjectMaster.Columns[SELECT_COLUMN].Visible = true;
			grdSubjectMaster.Columns[ACTIVATE_COLUMN].Visible = false;
			grdSubjectMaster.Columns[DELETE_COLUMN].Visible = true;
		}
	}
	#endregion

	#region Grid Events and Functions
	protected void grdSubjectMaster_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			objSubjectMaster = SelectRecordById(grdSubjectMaster.SelectedIndex);
			if (!objSubjectMaster.DbOperationStatus.Equals(CommonConstant.FAIL))
			{
				if(!Convert.ToBoolean(objSubjectMaster.IsRecordChanged))
				{
					ActivateControlsView(false, objSubjectMaster, grdSubjectMaster.SelectedIndex);
				}
				else
				{
					UIUtility.DisplayMessage(lblMessage, objSubjectMaster.DbOperationStatus);
					InitializeForm();
				}
			}
			else
			{
				UIUtility.DisplayMessage(lblMessage, objSubjectMaster.DbOperationStatus);
			}
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdSubjectMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			objSubjectMasterBL = new SubjectMasterBL();
			objSubjectMaster = GetObjectForActivateDeactivate(e.RowIndex,RecordStatus.InActive);
			objSubjectMaster = objSubjectMasterBL.ActivateDeactivateSubjectMaster(objSubjectMaster);
			UIUtility.DisplayMessage(lblMessage, objSubjectMaster.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdSubjectMaster_ActivatingObject(object sender, GridViewEditEventArgs e)
	{
		try
		{
			objSubjectMasterBL = new SubjectMasterBL();
			objSubjectMaster = GetObjectForActivateDeactivate(e.NewEditIndex, RecordStatus.Active);
			objSubjectMaster = objSubjectMasterBL.ActivateDeactivateSubjectMaster(objSubjectMaster);
			UIUtility.DisplayMessage(lblMessage, objSubjectMaster.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdSubjectMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			grdSubjectMaster.PageIndex = e.NewPageIndex;
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected SubjectMaster BindSubjectMasterGrid(RecordStatus objRecordStatus)
	{
		objSubjectMasterBL = new SubjectMasterBL();
		objSubjectMaster = new SubjectMaster();
		objSubjectMaster.RecordStatus = Convert.ToInt16(objRecordStatus);

		objSubjectMaster = objSubjectMasterBL.SelectSubjectMaster(objSubjectMaster);
		if (objSubjectMaster.DbOperationStatus == CommonConstant.SUCCEED)
		{
			grdSubjectMaster.DataSource = objSubjectMaster.ObjectDataSet.Tables[0];
			grdSubjectMaster.DataBind();
		}
		return objSubjectMaster;
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
				objSubjectMaster = GetObjectForInsertUpdate();
				objSubjectMasterBL = new SubjectMasterBL();
				if (objSubjectMaster.SubjectId == null)
				{
					objSubjectMaster = objSubjectMasterBL.InsertSubjectMaster(objSubjectMaster);
				}
				else
				{
					objSubjectMaster = objSubjectMasterBL.UpdateSubjectMaster(objSubjectMaster);
				}
				if (objSubjectMaster.DbOperationStatus == CommonConstant.SUCCEED
							|| objSubjectMaster.DbOperationStatus == CommonConstant.INVALID)
				{
					InitializeForm();
					MultiViewSubjectMaster.ActiveViewIndex = 0;
				}
				UIUtility.DisplayMessage(lblMessage, objSubjectMaster.DbOperationStatus);
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
			MultiViewSubjectMaster.ActiveViewIndex = 0;
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
	protected void BindSubjectMasterControls()
	{
		if (!Convert.ToBoolean(ViewState[isControlsLoaded]))
		{
			ViewState[isControlsLoaded] = true;
		}
	}
	protected void ActivateControlsView(bool isNewRecord, SubjectMaster objSubjectMaster,int? editIndex)
	{
		if (isNewRecord)
		{
			ViewState[editIndexKey] = null;
			BindSubjectMasterControls();
			UIUtility.InitializeControls(ViewSubjectMasterControls);
		}
		else
		{
			ViewState[editIndexKey] = editIndex;
			BindSubjectMasterControls();
			PopulateControlsData(objSubjectMaster);
		}
		MultiViewSubjectMaster.ActiveViewIndex = 1;
	}
	private void PopulateControlsData(SubjectMaster objSubjectMaster)
	{
		txtSubjectCode.Text = objSubjectMaster.SubjectCode;
		txtSubjectName.Text = objSubjectMaster.SubjectName;
		txtDescription.Text = objSubjectMaster.Description;
	}
	#endregion

	#region Helper Functions
	private bool ValidateObject()
	{
		return true;
	}
	private SubjectMaster GetObjectForInsertUpdate()
	{
		objSubjectMaster = new SubjectMaster();

		if (ViewState[editIndexKey] == null)
		{
			objSubjectMaster.Version = BusinessUtility.RECORD_VERSION;
			objSubjectMaster.CreatedBy = LoggedInUser;
			objSubjectMaster.CreatedOn = GeneralUtility.CurrentDateTime;
		}
		else
		{
			objSubjectMaster.SubjectId = Convert.ToInt32(grdSubjectMaster.DataKeys[Convert.ToInt32(ViewState[editIndexKey])].Values[SUBJECT_ID_INDEX].ToString());
			objSubjectMaster.Version = Convert.ToInt16(grdSubjectMaster.DataKeys[Convert.ToInt16(ViewState[editIndexKey])].Values[VERSION_INDEX].ToString()) + 1;
		}

		objSubjectMaster.SubjectCode = txtSubjectCode.Text;
		objSubjectMaster.SubjectName = txtSubjectName.Text;
		objSubjectMaster.Description = txtDescription.Text;
		objSubjectMaster.ModifiedBy = LoggedInUser;
		objSubjectMaster.ModifiedOn = GeneralUtility.CurrentDateTime;
		objSubjectMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
		return objSubjectMaster;
	}
	private SubjectMaster GetObjectForActivateDeactivate(int editIndex,RecordStatus objStatus)
	{
		objSubjectMaster = new SubjectMaster();
		objSubjectMaster.SubjectId = Convert.ToInt32(grdSubjectMaster.DataKeys[editIndex].Values[SUBJECT_ID_INDEX].ToString());
		objSubjectMaster.Version = Convert.ToInt16(grdSubjectMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString()) + 1;
		objSubjectMaster.ModifiedBy = LoggedInUser;
		objSubjectMaster.RecordStatus = Convert.ToInt16(objStatus);
		return objSubjectMaster;
	}
	private SubjectMaster SelectRecordById(int editIndex)
	{
		objSubjectMasterBL = new SubjectMasterBL();
		objSubjectMaster = new SubjectMaster();
		objSubjectMaster.SubjectId = Convert.ToInt32(grdSubjectMaster.DataKeys[editIndex].Values[SUBJECT_ID_INDEX].ToString());
		objSubjectMaster.Version = Convert.ToInt16(grdSubjectMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString());
		objSubjectMaster = objSubjectMasterBL.SelectRecordById(objSubjectMaster);
		return objSubjectMaster;
	}
	#endregion
}
