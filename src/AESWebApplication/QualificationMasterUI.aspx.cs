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

public partial class QualificationMasterUI : BasePage
{
	#region Page Variables
	QualificationMaster objQualificationMaster = null;
	QualificationMasterBL objQualificationMasterBL = null;

	private const int SELECT_COLUMN = 0;
	private const int ACTIVATE_COLUMN = 1;
	private const int DELETE_COLUMN = 2;

	private const int QUALIFICATION_ID_INDEX = 0;
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
			objQualificationMaster = BindQualificationMasterGrid(RecordStatus.Active);
			if (objQualificationMaster.DbOperationStatus != CommonConstant.SUCCEED)
			{
				btnAddNewRecord.Enabled = false;
				UIUtility.DisplayMessage(lblMessage, objQualificationMaster.DbOperationStatus);
				return;
			}

			ViewState[isControlsLoaded] = false;

			if (grdQualificationMaster.Rows.Count == 0)
			{
				BindQualificationMasterControls();
				MultiViewQualificationMaster.ActiveViewIndex = 1;
			}
		}
		else
		{
			if (rdbActiveRecord.Checked)
			{
				objQualificationMaster = BindQualificationMasterGrid(RecordStatus.Active);
				if (objQualificationMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objQualificationMaster.DbOperationStatus);
					return;
				}
				ViewActivateColumn(false);
			}
			else
			{
				objQualificationMaster = BindQualificationMasterGrid(RecordStatus.InActive);
				if (objQualificationMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objQualificationMaster.DbOperationStatus);
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
			grdQualificationMaster.Columns[SELECT_COLUMN].Visible = false;
			grdQualificationMaster.Columns[ACTIVATE_COLUMN].Visible = true;
			grdQualificationMaster.Columns[DELETE_COLUMN].Visible = false;
		}
		else
		{
			grdQualificationMaster.Columns[SELECT_COLUMN].Visible = true;
			grdQualificationMaster.Columns[ACTIVATE_COLUMN].Visible = false;
			grdQualificationMaster.Columns[DELETE_COLUMN].Visible = true;
		}
	}
	#endregion

	#region Grid Events and Functions
	protected void grdQualificationMaster_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			objQualificationMaster = SelectRecordById(grdQualificationMaster.SelectedIndex);
			if (!objQualificationMaster.DbOperationStatus.Equals(CommonConstant.FAIL))
			{
				if(!Convert.ToBoolean(objQualificationMaster.IsRecordChanged))
				{
					ActivateControlsView(false, objQualificationMaster, grdQualificationMaster.SelectedIndex);
				}
				else
				{
					UIUtility.DisplayMessage(lblMessage, objQualificationMaster.DbOperationStatus);
					InitializeForm();
				}
			}
			else
			{
				UIUtility.DisplayMessage(lblMessage, objQualificationMaster.DbOperationStatus);
			}
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdQualificationMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			objQualificationMasterBL = new QualificationMasterBL();
			objQualificationMaster = GetObjectForActivateDeactivate(e.RowIndex,RecordStatus.InActive);
			objQualificationMaster = objQualificationMasterBL.ActivateDeactivateQualificationMaster(objQualificationMaster);
			UIUtility.DisplayMessage(lblMessage, objQualificationMaster.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdQualificationMaster_ActivatingObject(object sender, GridViewEditEventArgs e)
	{
		try
		{
			objQualificationMasterBL = new QualificationMasterBL();
			objQualificationMaster = GetObjectForActivateDeactivate(e.NewEditIndex, RecordStatus.Active);
			objQualificationMaster = objQualificationMasterBL.ActivateDeactivateQualificationMaster(objQualificationMaster);
			UIUtility.DisplayMessage(lblMessage, objQualificationMaster.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdQualificationMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			grdQualificationMaster.PageIndex = e.NewPageIndex;
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected QualificationMaster BindQualificationMasterGrid(RecordStatus objRecordStatus)
	{
		objQualificationMasterBL = new QualificationMasterBL();
		objQualificationMaster = new QualificationMaster();
		objQualificationMaster.RecordStatus = Convert.ToInt16(objRecordStatus);

		objQualificationMaster = objQualificationMasterBL.SelectQualificationMaster(objQualificationMaster);
		if (objQualificationMaster.DbOperationStatus == CommonConstant.SUCCEED)
		{
			grdQualificationMaster.DataSource = objQualificationMaster.ObjectDataSet.Tables[0];
			grdQualificationMaster.DataBind();
		}
		return objQualificationMaster;
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
				objQualificationMaster = GetObjectForInsertUpdate();
				objQualificationMasterBL = new QualificationMasterBL();
				if (objQualificationMaster.QualificationId == null)
				{
					objQualificationMaster = objQualificationMasterBL.InsertQualificationMaster(objQualificationMaster);
				}
				else
				{
					objQualificationMaster = objQualificationMasterBL.UpdateQualificationMaster(objQualificationMaster);
				}
				if (objQualificationMaster.DbOperationStatus == CommonConstant.SUCCEED
							|| objQualificationMaster.DbOperationStatus == CommonConstant.INVALID)
				{
					InitializeForm();
					MultiViewQualificationMaster.ActiveViewIndex = 0;
				}
				UIUtility.DisplayMessage(lblMessage, objQualificationMaster.DbOperationStatus);
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
			MultiViewQualificationMaster.ActiveViewIndex = 0;
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
	protected void BindQualificationMasterControls()
	{
		if (!Convert.ToBoolean(ViewState[isControlsLoaded]))
		{
			ViewState[isControlsLoaded] = true;
		}
	}
	protected void ActivateControlsView(bool isNewRecord, QualificationMaster objQualificationMaster,int? editIndex)
	{
		if (isNewRecord)
		{
			ViewState[editIndexKey] = null;
			BindQualificationMasterControls();
			UIUtility.InitializeControls(ViewQualificationMasterControls);
		}
		else
		{
			ViewState[editIndexKey] = editIndex;
			BindQualificationMasterControls();
			PopulateControlsData(objQualificationMaster);
		}
		MultiViewQualificationMaster.ActiveViewIndex = 1;
	}
	private void PopulateControlsData(QualificationMaster objQualificationMaster)
	{
		txtQualificationName.Text = objQualificationMaster.QualificationName;
		txtDescription.Text = objQualificationMaster.Description;
	}
	#endregion

	#region Helper Functions
	private bool ValidateObject()
	{
		return true;
	}
	private QualificationMaster GetObjectForInsertUpdate()
	{
		objQualificationMaster = new QualificationMaster();

		if (ViewState[editIndexKey] == null)
		{
			objQualificationMaster.Version = BusinessUtility.RECORD_VERSION;
			objQualificationMaster.CreatedBy = LoggedInUser;
			objQualificationMaster.CreatedOn = GeneralUtility.CurrentDateTime;
		}
		else
		{
			objQualificationMaster.QualificationId = Convert.ToInt32(grdQualificationMaster.DataKeys[Convert.ToInt32(ViewState[editIndexKey])].Values[QUALIFICATION_ID_INDEX].ToString());
			objQualificationMaster.Version = Convert.ToInt16(grdQualificationMaster.DataKeys[Convert.ToInt16(ViewState[editIndexKey])].Values[VERSION_INDEX].ToString()) + 1;
		}

		objQualificationMaster.QualificationName = txtQualificationName.Text;
		objQualificationMaster.Description = txtDescription.Text;
		objQualificationMaster.ModifiedBy = LoggedInUser;
		objQualificationMaster.ModifiedOn = GeneralUtility.CurrentDateTime;
		objQualificationMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
		return objQualificationMaster;
	}
	private QualificationMaster GetObjectForActivateDeactivate(int editIndex,RecordStatus objStatus)
	{
		objQualificationMaster = new QualificationMaster();
		objQualificationMaster.QualificationId = Convert.ToInt32(grdQualificationMaster.DataKeys[editIndex].Values[QUALIFICATION_ID_INDEX].ToString());
		objQualificationMaster.Version = Convert.ToInt16(grdQualificationMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString()) + 1;
		objQualificationMaster.ModifiedBy = LoggedInUser;
		objQualificationMaster.RecordStatus = Convert.ToInt16(objStatus);
		return objQualificationMaster;
	}
	private QualificationMaster SelectRecordById(int editIndex)
	{
		objQualificationMasterBL = new QualificationMasterBL();
		objQualificationMaster = new QualificationMaster();
		objQualificationMaster.QualificationId = Convert.ToInt32(grdQualificationMaster.DataKeys[editIndex].Values[QUALIFICATION_ID_INDEX].ToString());
		objQualificationMaster.Version = Convert.ToInt16(grdQualificationMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString());
		objQualificationMaster = objQualificationMasterBL.SelectRecordById(objQualificationMaster);
		return objQualificationMaster;
	}
	#endregion
}
