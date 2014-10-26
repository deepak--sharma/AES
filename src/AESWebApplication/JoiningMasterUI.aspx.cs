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

public partial class JoiningMasterUI : BasePage
{
	#region Page Variables
	JoiningMaster objJoiningMaster = null;
	JoiningMasterBL objJoiningMasterBL = null;

	private const int SELECT_COLUMN = 0;
	private const int ACTIVATE_COLUMN = 1;
	private const int DELETE_COLUMN = 2;

	private const int JOINING_ID_INDEX = 0;
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
			objJoiningMaster = BindJoiningMasterGrid(RecordStatus.Active);
			if (objJoiningMaster.DbOperationStatus != CommonConstant.SUCCEED)
			{
				btnAddNewRecord.Enabled = false;
				UIUtility.DisplayMessage(lblMessage, objJoiningMaster.DbOperationStatus);
				return;
			}

			ViewState[isControlsLoaded] = false;

			if (grdJoiningMaster.Rows.Count == 0)
			{
				BindJoiningMasterControls();
				MultiViewJoiningMaster.ActiveViewIndex = 1;
			}
		}
		else
		{
			if (rdbActiveRecord.Checked)
			{
				objJoiningMaster = BindJoiningMasterGrid(RecordStatus.Active);
				if (objJoiningMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objJoiningMaster.DbOperationStatus);
					return;
				}
				ViewActivateColumn(false);
			}
			else
			{
				objJoiningMaster = BindJoiningMasterGrid(RecordStatus.InActive);
				if (objJoiningMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objJoiningMaster.DbOperationStatus);
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
			grdJoiningMaster.Columns[SELECT_COLUMN].Visible = false;
			grdJoiningMaster.Columns[ACTIVATE_COLUMN].Visible = true;
			grdJoiningMaster.Columns[DELETE_COLUMN].Visible = false;
		}
		else
		{
			grdJoiningMaster.Columns[SELECT_COLUMN].Visible = true;
			grdJoiningMaster.Columns[ACTIVATE_COLUMN].Visible = false;
			grdJoiningMaster.Columns[DELETE_COLUMN].Visible = true;
		}
	}
	#endregion

	#region Grid Events and Functions
	protected void grdJoiningMaster_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			objJoiningMaster = SelectRecordById(grdJoiningMaster.SelectedIndex);
			if (!objJoiningMaster.DbOperationStatus.Equals(CommonConstant.FAIL))
			{
				if(!Convert.ToBoolean(objJoiningMaster.IsRecordChanged))
				{
					ActivateControlsView(false, objJoiningMaster, grdJoiningMaster.SelectedIndex);
				}
				else
				{
					UIUtility.DisplayMessage(lblMessage, objJoiningMaster.DbOperationStatus);
					InitializeForm();
				}
			}
			else
			{
				UIUtility.DisplayMessage(lblMessage, objJoiningMaster.DbOperationStatus);
			}
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdJoiningMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			objJoiningMasterBL = new JoiningMasterBL();
			objJoiningMaster = GetObjectForActivateDeactivate(e.RowIndex,RecordStatus.InActive);
			objJoiningMaster = objJoiningMasterBL.ActivateDeactivateJoiningMaster(objJoiningMaster);
			UIUtility.DisplayMessage(lblMessage, objJoiningMaster.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdJoiningMaster_ActivatingObject(object sender, GridViewEditEventArgs e)
	{
		try
		{
			objJoiningMasterBL = new JoiningMasterBL();
			objJoiningMaster = GetObjectForActivateDeactivate(e.NewEditIndex, RecordStatus.Active);
			objJoiningMaster = objJoiningMasterBL.ActivateDeactivateJoiningMaster(objJoiningMaster);
			UIUtility.DisplayMessage(lblMessage, objJoiningMaster.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdJoiningMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			grdJoiningMaster.PageIndex = e.NewPageIndex;
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected JoiningMaster BindJoiningMasterGrid(RecordStatus objRecordStatus)
	{
		objJoiningMasterBL = new JoiningMasterBL();
		objJoiningMaster = new JoiningMaster();
		objJoiningMaster.RecordStatus = Convert.ToInt16(objRecordStatus);

		objJoiningMaster = objJoiningMasterBL.SelectJoiningMaster(objJoiningMaster);
		if (objJoiningMaster.DbOperationStatus == CommonConstant.SUCCEED)
		{
			grdJoiningMaster.DataSource = objJoiningMaster.ObjectDataSet.Tables[0];
			grdJoiningMaster.DataBind();
		}
		return objJoiningMaster;
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
				objJoiningMaster = GetObjectForInsertUpdate();
				objJoiningMasterBL = new JoiningMasterBL();
				if (objJoiningMaster.JoiningId == null)
				{
					objJoiningMaster = objJoiningMasterBL.InsertJoiningMaster(objJoiningMaster);
				}
				else
				{
					objJoiningMaster = objJoiningMasterBL.UpdateJoiningMaster(objJoiningMaster);
				}
				if (objJoiningMaster.DbOperationStatus == CommonConstant.SUCCEED
							|| objJoiningMaster.DbOperationStatus == CommonConstant.INVALID)
				{
					InitializeForm();
					MultiViewJoiningMaster.ActiveViewIndex = 0;
				}
				UIUtility.DisplayMessage(lblMessage, objJoiningMaster.DbOperationStatus);
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
			MultiViewJoiningMaster.ActiveViewIndex = 0;
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
	protected void BindJoiningMasterControls()
	{
		if (!Convert.ToBoolean(ViewState[isControlsLoaded]))
		{
			ViewState[isControlsLoaded] = true;
		}
	}
	protected void ActivateControlsView(bool isNewRecord, JoiningMaster objJoiningMaster,int? editIndex)
	{
		if (isNewRecord)
		{
			ViewState[editIndexKey] = null;
			BindJoiningMasterControls();
			UIUtility.InitializeControls(ViewJoiningMasterControls);
		}
		else
		{
			ViewState[editIndexKey] = editIndex;
			BindJoiningMasterControls();
			PopulateControlsData(objJoiningMaster);
		}
		MultiViewJoiningMaster.ActiveViewIndex = 1;
	}
	private void PopulateControlsData(JoiningMaster objJoiningMaster)
	{
		txtJoiningName.Text = objJoiningMaster.JoiningName;
		txtDescription.Text = objJoiningMaster.Description;
	}
	#endregion

	#region Helper Functions
	private bool ValidateObject()
	{
		return true;
	}
	private JoiningMaster GetObjectForInsertUpdate()
	{
		objJoiningMaster = new JoiningMaster();

		if (ViewState[editIndexKey] == null)
		{
			objJoiningMaster.Version = BusinessUtility.RECORD_VERSION;
			objJoiningMaster.CreatedBy = LoggedInUser;
			objJoiningMaster.CreatedOn = GeneralUtility.CurrentDateTime;
		}
		else
		{
			objJoiningMaster.JoiningId = Convert.ToInt32(grdJoiningMaster.DataKeys[Convert.ToInt32(ViewState[editIndexKey])].Values[JOINING_ID_INDEX].ToString());
			objJoiningMaster.Version = Convert.ToInt16(grdJoiningMaster.DataKeys[Convert.ToInt16(ViewState[editIndexKey])].Values[VERSION_INDEX].ToString()) + 1;
		}

		objJoiningMaster.JoiningName = txtJoiningName.Text;
		objJoiningMaster.Description = txtDescription.Text;
		objJoiningMaster.ModifiedBy = LoggedInUser;
		objJoiningMaster.ModifiedOn = GeneralUtility.CurrentDateTime;
		objJoiningMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
		return objJoiningMaster;
	}
	private JoiningMaster GetObjectForActivateDeactivate(int editIndex,RecordStatus objStatus)
	{
		objJoiningMaster = new JoiningMaster();
		objJoiningMaster.JoiningId = Convert.ToInt32(grdJoiningMaster.DataKeys[editIndex].Values[JOINING_ID_INDEX].ToString());
		objJoiningMaster.Version = Convert.ToInt16(grdJoiningMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString()) + 1;
		objJoiningMaster.ModifiedBy = LoggedInUser;
		objJoiningMaster.RecordStatus = Convert.ToInt16(objStatus);
		return objJoiningMaster;
	}
	private JoiningMaster SelectRecordById(int editIndex)
	{
		objJoiningMasterBL = new JoiningMasterBL();
		objJoiningMaster = new JoiningMaster();
		objJoiningMaster.JoiningId = Convert.ToInt32(grdJoiningMaster.DataKeys[editIndex].Values[JOINING_ID_INDEX].ToString());
		objJoiningMaster.Version = Convert.ToInt16(grdJoiningMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString());
		objJoiningMaster = objJoiningMasterBL.SelectRecordById(objJoiningMaster);
		return objJoiningMaster;
	}
	#endregion
}
