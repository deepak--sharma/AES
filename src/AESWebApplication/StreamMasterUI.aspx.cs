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

public partial class StreamMasterUI : BasePage
{
	#region Page Variables
	StreamMaster objStreamMaster = null;
	StreamMasterBL objStreamMasterBL = null;
	ClassMaster objClassMaster = null;
	ClassMasterBL objClassMasterBL = null;

	private const int SELECT_COLUMN = 0;
	private const int ACTIVATE_COLUMN = 1;
	private const int DELETE_COLUMN = 2;

	private const int STREAM_ID_INDEX = 0;
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
			objStreamMaster = BindStreamMasterGrid(RecordStatus.Active);
			if (objStreamMaster.DbOperationStatus != CommonConstant.SUCCEED)
			{
				btnAddNewRecord.Enabled = false;
				UIUtility.DisplayMessage(lblMessage, objStreamMaster.DbOperationStatus);
				return;
			}

			ViewState[isControlsLoaded] = false;

			if (grdStreamMaster.Rows.Count == 0)
			{
				BindStreamMasterControls();
				MultiViewStreamMaster.ActiveViewIndex = 1;
			}
		}
		else
		{
			if (rdbActiveRecord.Checked)
			{
				objStreamMaster = BindStreamMasterGrid(RecordStatus.Active);
				if (objStreamMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objStreamMaster.DbOperationStatus);
					return;
				}
				ViewActivateColumn(false);
			}
			else
			{
				objStreamMaster = BindStreamMasterGrid(RecordStatus.InActive);
				if (objStreamMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objStreamMaster.DbOperationStatus);
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
			grdStreamMaster.Columns[SELECT_COLUMN].Visible = false;
			grdStreamMaster.Columns[ACTIVATE_COLUMN].Visible = true;
			grdStreamMaster.Columns[DELETE_COLUMN].Visible = false;
		}
		else
		{
			grdStreamMaster.Columns[SELECT_COLUMN].Visible = true;
			grdStreamMaster.Columns[ACTIVATE_COLUMN].Visible = false;
			grdStreamMaster.Columns[DELETE_COLUMN].Visible = true;
		}
	}
	#endregion

	#region Grid Events and Functions
	protected void grdStreamMaster_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			objStreamMaster = SelectRecordById(grdStreamMaster.SelectedIndex);
			if (!objStreamMaster.DbOperationStatus.Equals(CommonConstant.FAIL))
			{
				if(!Convert.ToBoolean(objStreamMaster.IsRecordChanged))
				{
					ActivateControlsView(false, objStreamMaster, grdStreamMaster.SelectedIndex);
				}
				else
				{
					UIUtility.DisplayMessage(lblMessage, objStreamMaster.DbOperationStatus);
					InitializeForm();
				}
			}
			else
			{
				UIUtility.DisplayMessage(lblMessage, objStreamMaster.DbOperationStatus);
			}
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdStreamMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			objStreamMasterBL = new StreamMasterBL();
			objStreamMaster = GetObjectForActivateDeactivate(e.RowIndex,RecordStatus.InActive);
			objStreamMaster = objStreamMasterBL.ActivateDeactivateStreamMaster(objStreamMaster);
			UIUtility.DisplayMessage(lblMessage, objStreamMaster.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdStreamMaster_ActivatingObject(object sender, GridViewEditEventArgs e)
	{
		try
		{
			objStreamMasterBL = new StreamMasterBL();
			objStreamMaster = GetObjectForActivateDeactivate(e.NewEditIndex, RecordStatus.Active);
			objStreamMaster = objStreamMasterBL.ActivateDeactivateStreamMaster(objStreamMaster);
			UIUtility.DisplayMessage(lblMessage, objStreamMaster.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdStreamMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			grdStreamMaster.PageIndex = e.NewPageIndex;
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected StreamMaster BindStreamMasterGrid(RecordStatus objRecordStatus)
	{
		objStreamMasterBL = new StreamMasterBL();
		objStreamMaster = new StreamMaster();
		objStreamMaster.RecordStatus = Convert.ToInt16(objRecordStatus);

		objStreamMaster = objStreamMasterBL.SelectStreamMaster(objStreamMaster);
		if (objStreamMaster.DbOperationStatus == CommonConstant.SUCCEED)
		{
			grdStreamMaster.DataSource = objStreamMaster.ObjectDataSet.Tables[0];
			grdStreamMaster.DataBind();
		}
		return objStreamMaster;
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
				objStreamMaster = GetObjectForInsertUpdate();
				objStreamMasterBL = new StreamMasterBL();
				if (objStreamMaster.StreamId == null)
				{
					objStreamMaster = objStreamMasterBL.InsertStreamMaster(objStreamMaster);
				}
				else
				{
					objStreamMaster = objStreamMasterBL.UpdateStreamMaster(objStreamMaster);
				}
				if (objStreamMaster.DbOperationStatus == CommonConstant.SUCCEED
							|| objStreamMaster.DbOperationStatus == CommonConstant.INVALID)
				{
					InitializeForm();
					MultiViewStreamMaster.ActiveViewIndex = 0;
				}
				UIUtility.DisplayMessage(lblMessage, objStreamMaster.DbOperationStatus);
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
			MultiViewStreamMaster.ActiveViewIndex = 0;
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
	protected void BindStreamMasterControls()
	{
		if (!Convert.ToBoolean(ViewState[isControlsLoaded]))
		{
			objClassMasterBL = new ClassMasterBL();
			objClassMaster = new ClassMaster();
			objClassMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
			objClassMaster = objClassMasterBL.SelectClassMaster(objClassMaster);
			ddlClass.DataSource = objClassMaster.ObjectDataSet.Tables[0];
			ddlClass.DataBind();
			ddlClass.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

			ViewState[isControlsLoaded] = true;
		}
	}
	protected void ActivateControlsView(bool isNewRecord, StreamMaster objStreamMaster,int? editIndex)
	{
		if (isNewRecord)
		{
			ViewState[editIndexKey] = null;
			BindStreamMasterControls();
			UIUtility.InitializeControls(ViewStreamMasterControls);
		}
		else
		{
			ViewState[editIndexKey] = editIndex;
			BindStreamMasterControls();
			PopulateControlsData(objStreamMaster);
		}
		MultiViewStreamMaster.ActiveViewIndex = 1;
	}
	private void PopulateControlsData(StreamMaster objStreamMaster)
	{
		UIUtility.SelectCurrentListItem(ddlClass, objStreamMaster.ClassObject.ClassId, BindListItem.ByValue, true);
		txtStreamName.Text = objStreamMaster.StreamName;
		txtDescription.Text = objStreamMaster.Description;
		UIUtility.SelectCurrentListItem(ddlIsStudent, objStreamMaster.IsStudent, BindListItem.ByValue, true);
	}
	#endregion

	#region Helper Functions
	private bool ValidateObject()
	{
		return true;
	}
	private StreamMaster GetObjectForInsertUpdate()
	{
		objStreamMaster = new StreamMaster();

		if (ViewState[editIndexKey] == null)
		{
			objStreamMaster.Version = BusinessUtility.RECORD_VERSION;
			objStreamMaster.CreatedBy = LoggedInUser;
			objStreamMaster.CreatedOn = GeneralUtility.CurrentDateTime;
		}
		else
		{
			objStreamMaster.StreamId = Convert.ToInt32(grdStreamMaster.DataKeys[Convert.ToInt32(ViewState[editIndexKey])].Values[STREAM_ID_INDEX].ToString());
			objStreamMaster.Version = Convert.ToInt16(grdStreamMaster.DataKeys[Convert.ToInt16(ViewState[editIndexKey])].Values[VERSION_INDEX].ToString()) + 1;
		}

		if (ddlClass.SelectedIndex != 0)
		{
			objStreamMaster.ClassObject = new ClassMaster();
			objStreamMaster.ClassObject.ClassId = Convert.ToInt32(ddlClass.SelectedItem.Value);
		}
		objStreamMaster.StreamName = txtStreamName.Text;
		objStreamMaster.Description = txtDescription.Text;
		objStreamMaster.IsStudent = Convert.ToBoolean(ddlIsStudent.SelectedItem.Value);
		objStreamMaster.ModifiedBy = LoggedInUser;
		objStreamMaster.ModifiedOn = GeneralUtility.CurrentDateTime;
		objStreamMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
		return objStreamMaster;
	}
	private StreamMaster GetObjectForActivateDeactivate(int editIndex,RecordStatus objStatus)
	{
		objStreamMaster = new StreamMaster();
		objStreamMaster.StreamId = Convert.ToInt32(grdStreamMaster.DataKeys[editIndex].Values[STREAM_ID_INDEX].ToString());
		objStreamMaster.Version = Convert.ToInt16(grdStreamMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString()) + 1;
		objStreamMaster.ModifiedBy = LoggedInUser;
		objStreamMaster.RecordStatus = Convert.ToInt16(objStatus);
		return objStreamMaster;
	}
	private StreamMaster SelectRecordById(int editIndex)
	{
		objStreamMasterBL = new StreamMasterBL();
		objStreamMaster = new StreamMaster();
		objStreamMaster.StreamId = Convert.ToInt32(grdStreamMaster.DataKeys[editIndex].Values[STREAM_ID_INDEX].ToString());
		objStreamMaster.Version = Convert.ToInt16(grdStreamMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString());
		objStreamMaster = objStreamMasterBL.SelectRecordById(objStreamMaster);
		return objStreamMaster;
	}
	#endregion
}
