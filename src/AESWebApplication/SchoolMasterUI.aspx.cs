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

public partial class SchoolMasterUI : BasePage
{
	#region Page Variables
	SchoolMaster objSchoolMaster = null;
	SchoolMasterBL objSchoolMasterBL = null;

	private const int SELECT_COLUMN = 0;
	private const int ACTIVATE_COLUMN = 1;
	private const int DELETE_COLUMN = 2;

	private const int SCHOOL_ID_INDEX = 0;
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
			objSchoolMaster = BindSchoolMasterGrid(RecordStatus.Active);
			if (objSchoolMaster.DbOperationStatus != CommonConstant.SUCCEED)
			{
				btnAddNewRecord.Enabled = false;
				UIUtility.DisplayMessage(lblMessage, objSchoolMaster.DbOperationStatus);
				return;
			}

			ViewState[isControlsLoaded] = false;

			if (grdSchoolMaster.Rows.Count == 0)
			{
				BindSchoolMasterControls();
				MultiViewSchoolMaster.ActiveViewIndex = 1;
			}
		}
		else
		{
			if (rdbActiveRecord.Checked)
			{
				objSchoolMaster = BindSchoolMasterGrid(RecordStatus.Active);
				if (objSchoolMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objSchoolMaster.DbOperationStatus);
					return;
				}
				ViewActivateColumn(false);
			}
			else
			{
				objSchoolMaster = BindSchoolMasterGrid(RecordStatus.InActive);
				if (objSchoolMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objSchoolMaster.DbOperationStatus);
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
			grdSchoolMaster.Columns[SELECT_COLUMN].Visible = false;
			grdSchoolMaster.Columns[ACTIVATE_COLUMN].Visible = true;
			grdSchoolMaster.Columns[DELETE_COLUMN].Visible = false;
		}
		else
		{
			grdSchoolMaster.Columns[SELECT_COLUMN].Visible = true;
			grdSchoolMaster.Columns[ACTIVATE_COLUMN].Visible = false;
			grdSchoolMaster.Columns[DELETE_COLUMN].Visible = true;
		}
	}
	#endregion

	#region Grid Events and Functions
	protected void grdSchoolMaster_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			objSchoolMaster = SelectRecordById(grdSchoolMaster.SelectedIndex);
			if (!objSchoolMaster.DbOperationStatus.Equals(CommonConstant.FAIL))
			{
				if(!Convert.ToBoolean(objSchoolMaster.IsRecordChanged))
				{
					ActivateControlsView(false, objSchoolMaster, grdSchoolMaster.SelectedIndex);
				}
				else
				{
					UIUtility.DisplayMessage(lblMessage, objSchoolMaster.DbOperationStatus);
					InitializeForm();
				}
			}
			else
			{
				UIUtility.DisplayMessage(lblMessage, objSchoolMaster.DbOperationStatus);
			}
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdSchoolMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			objSchoolMasterBL = new SchoolMasterBL();
			objSchoolMaster = GetObjectForActivateDeactivate(e.RowIndex,RecordStatus.InActive);
			objSchoolMaster = objSchoolMasterBL.ActivateDeactivateSchoolMaster(objSchoolMaster);
			UIUtility.DisplayMessage(lblMessage, objSchoolMaster.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdSchoolMaster_ActivatingObject(object sender, GridViewEditEventArgs e)
	{
		try
		{
			objSchoolMasterBL = new SchoolMasterBL();
			objSchoolMaster = GetObjectForActivateDeactivate(e.NewEditIndex, RecordStatus.Active);
			objSchoolMaster = objSchoolMasterBL.ActivateDeactivateSchoolMaster(objSchoolMaster);
			UIUtility.DisplayMessage(lblMessage, objSchoolMaster.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdSchoolMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			grdSchoolMaster.PageIndex = e.NewPageIndex;
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected SchoolMaster BindSchoolMasterGrid(RecordStatus objRecordStatus)
	{
		objSchoolMasterBL = new SchoolMasterBL();
		objSchoolMaster = new SchoolMaster();
		objSchoolMaster.RecordStatus = Convert.ToInt16(objRecordStatus);

		objSchoolMaster = objSchoolMasterBL.SelectSchoolMaster(objSchoolMaster);
		if (objSchoolMaster.DbOperationStatus == CommonConstant.SUCCEED)
		{
			grdSchoolMaster.DataSource = objSchoolMaster.ObjectDataSet.Tables[0];
			grdSchoolMaster.DataBind();
		}
		return objSchoolMaster;
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
				objSchoolMaster = GetObjectForInsertUpdate();
				objSchoolMasterBL = new SchoolMasterBL();
				if (objSchoolMaster.SchoolId == null)
				{
					objSchoolMaster = objSchoolMasterBL.InsertSchoolMaster(objSchoolMaster);
				}
				else
				{
					objSchoolMaster = objSchoolMasterBL.UpdateSchoolMaster(objSchoolMaster);
				}
				if (objSchoolMaster.DbOperationStatus == CommonConstant.SUCCEED
							|| objSchoolMaster.DbOperationStatus == CommonConstant.INVALID)
				{
					InitializeForm();
					MultiViewSchoolMaster.ActiveViewIndex = 0;
				}
				UIUtility.DisplayMessage(lblMessage, objSchoolMaster.DbOperationStatus);
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
			MultiViewSchoolMaster.ActiveViewIndex = 0;
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
	protected void BindSchoolMasterControls()
	{
		if (!Convert.ToBoolean(ViewState[isControlsLoaded]))
		{
			uxSchoolAddressUC.BindUCControls();
			ViewState[isControlsLoaded] = true;
		}
	}
	protected void ActivateControlsView(bool isNewRecord, SchoolMaster objSchoolMaster,int? editIndex)
	{
		if (isNewRecord)
		{
			ViewState[editIndexKey] = null;
			BindSchoolMasterControls();
			UIUtility.InitializeControls(ViewSchoolMasterControls);
		}
		else
		{
			ViewState[editIndexKey] = editIndex;
			BindSchoolMasterControls();
			PopulateControlsData(objSchoolMaster);
		}
		MultiViewSchoolMaster.ActiveViewIndex = 1;
	}
	private void PopulateControlsData(SchoolMaster objSchoolMaster)
	{
		txtSchoolCode.Text = objSchoolMaster.SchoolCode;
		txtSchoolName.Text = objSchoolMaster.SchoolName;
		txtSchoolHead.Text = objSchoolMaster.SchoolHead.ToString();
		txtEstablishedOn.Text = objSchoolMaster.EstablishedOn.ToString();
		txtLogo.Text = objSchoolMaster.Logo;
		txtWebAddress.Text = objSchoolMaster.WebAddress;
		uxSchoolAddressUC.SetUserControlData(objSchoolMaster.SchoolAddressObject);
		txtDescription.Text = objSchoolMaster.Description;
	}
	#endregion

	#region Helper Functions
	private bool ValidateObject()
	{
		return true;
	}
	private SchoolMaster GetObjectForInsertUpdate()
	{
		objSchoolMaster = new SchoolMaster();

		if (ViewState[editIndexKey] == null)
		{
			objSchoolMaster.Version = BusinessUtility.RECORD_VERSION;
			objSchoolMaster.CreatedBy = LoggedInUser;
			objSchoolMaster.CreatedOn = GeneralUtility.CurrentDateTime;
		}
		else
		{
			objSchoolMaster.SchoolId = Convert.ToInt32(grdSchoolMaster.DataKeys[Convert.ToInt32(ViewState[editIndexKey])].Values[SCHOOL_ID_INDEX].ToString());
			objSchoolMaster.Version = Convert.ToInt16(grdSchoolMaster.DataKeys[Convert.ToInt16(ViewState[editIndexKey])].Values[VERSION_INDEX].ToString()) + 1;
		}

		objSchoolMaster.SchoolCode = txtSchoolCode.Text;
		objSchoolMaster.SchoolName = txtSchoolName.Text;
		objSchoolMaster.SchoolHead = Convert.ToInt32(txtSchoolHead.Text);
		objSchoolMaster.EstablishedOn = Convert.ToDateTime(txtEstablishedOn.Text);
		objSchoolMaster.Logo = txtLogo.Text;
		objSchoolMaster.WebAddress = txtWebAddress.Text;
		objSchoolMaster.SchoolAddressObject = uxSchoolAddressUC.GetUserControlData();
		objSchoolMaster.Description = txtDescription.Text;
		objSchoolMaster.ModifiedBy = LoggedInUser;
		objSchoolMaster.ModifiedOn = GeneralUtility.CurrentDateTime;
		objSchoolMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
		return objSchoolMaster;
	}
	private SchoolMaster GetObjectForActivateDeactivate(int editIndex,RecordStatus objStatus)
	{
		objSchoolMaster = new SchoolMaster();
		objSchoolMaster.SchoolId = Convert.ToInt32(grdSchoolMaster.DataKeys[editIndex].Values[SCHOOL_ID_INDEX].ToString());
		objSchoolMaster.Version = Convert.ToInt16(grdSchoolMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString()) + 1;
		objSchoolMaster.ModifiedBy = LoggedInUser;
		objSchoolMaster.RecordStatus = Convert.ToInt16(objStatus);
		return objSchoolMaster;
	}
	private SchoolMaster SelectRecordById(int editIndex)
	{
		objSchoolMasterBL = new SchoolMasterBL();
		objSchoolMaster = new SchoolMaster();
		objSchoolMaster.SchoolId = Convert.ToInt32(grdSchoolMaster.DataKeys[editIndex].Values[SCHOOL_ID_INDEX].ToString());
		objSchoolMaster.Version = Convert.ToInt16(grdSchoolMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString());
		objSchoolMaster = objSchoolMasterBL.SelectRecordById(objSchoolMaster);
		return objSchoolMaster;
	}
	#endregion
}
