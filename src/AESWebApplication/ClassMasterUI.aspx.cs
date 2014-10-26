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

public partial class ClassMasterUI : BasePage
{
	#region Page Variables
	ClassMaster objClassMaster = null;
	ClassMasterBL objClassMasterBL = null;

	private const int SELECT_COLUMN = 0;
	private const int ACTIVATE_COLUMN = 1;
	private const int DELETE_COLUMN = 2;

	private const int CLASS_ID_INDEX = 0;
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
			objClassMaster = BindClassMasterGrid(RecordStatus.Active);
			if (objClassMaster.DbOperationStatus != CommonConstant.SUCCEED)
			{
				btnAddNewRecord.Enabled = false;
				UIUtility.DisplayMessage(lblMessage, objClassMaster.DbOperationStatus);
				return;
			}

			ViewState[isControlsLoaded] = false;

			if (grdClassMaster.Rows.Count == 0)
			{
				BindClassMasterControls();
				MultiViewClassMaster.ActiveViewIndex = 1;
			}
		}
		else
		{
			if (rdbActiveRecord.Checked)
			{
				objClassMaster = BindClassMasterGrid(RecordStatus.Active);
				if (objClassMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objClassMaster.DbOperationStatus);
					return;
				}
				ViewActivateColumn(false);
			}
			else
			{
				objClassMaster = BindClassMasterGrid(RecordStatus.InActive);
				if (objClassMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objClassMaster.DbOperationStatus);
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
			grdClassMaster.Columns[SELECT_COLUMN].Visible = false;
			grdClassMaster.Columns[ACTIVATE_COLUMN].Visible = true;
			grdClassMaster.Columns[DELETE_COLUMN].Visible = false;
		}
		else
		{
			grdClassMaster.Columns[SELECT_COLUMN].Visible = true;
			grdClassMaster.Columns[ACTIVATE_COLUMN].Visible = false;
			grdClassMaster.Columns[DELETE_COLUMN].Visible = true;
		}
	}
	#endregion

	#region Grid Events and Functions
	protected void grdClassMaster_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			objClassMaster = SelectRecordById(grdClassMaster.SelectedIndex);
			if (!objClassMaster.DbOperationStatus.Equals(CommonConstant.FAIL))
			{
				if(!Convert.ToBoolean(objClassMaster.IsRecordChanged))
				{
					ActivateControlsView(false, objClassMaster, grdClassMaster.SelectedIndex);
				}
				else
				{
					UIUtility.DisplayMessage(lblMessage, objClassMaster.DbOperationStatus);
					InitializeForm();
				}
			}
			else
			{
				UIUtility.DisplayMessage(lblMessage, objClassMaster.DbOperationStatus);
			}
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdClassMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			objClassMasterBL = new ClassMasterBL();
			objClassMaster = GetObjectForActivateDeactivate(e.RowIndex,RecordStatus.InActive);
			objClassMaster = objClassMasterBL.ActivateDeactivateClassMaster(objClassMaster);
			UIUtility.DisplayMessage(lblMessage, objClassMaster.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdClassMaster_ActivatingObject(object sender, GridViewEditEventArgs e)
	{
		try
		{
			objClassMasterBL = new ClassMasterBL();
			objClassMaster = GetObjectForActivateDeactivate(e.NewEditIndex, RecordStatus.Active);
			objClassMaster = objClassMasterBL.ActivateDeactivateClassMaster(objClassMaster);
			UIUtility.DisplayMessage(lblMessage, objClassMaster.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdClassMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			grdClassMaster.PageIndex = e.NewPageIndex;
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected ClassMaster BindClassMasterGrid(RecordStatus objRecordStatus)
	{
		objClassMasterBL = new ClassMasterBL();
		objClassMaster = new ClassMaster();
		objClassMaster.RecordStatus = Convert.ToInt16(objRecordStatus);

		objClassMaster = objClassMasterBL.SelectClassMaster(objClassMaster);
		if (objClassMaster.DbOperationStatus == CommonConstant.SUCCEED)
		{
			grdClassMaster.DataSource = objClassMaster.ObjectDataSet.Tables[0];
			grdClassMaster.DataBind();
		}
		return objClassMaster;
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
				objClassMaster = GetObjectForInsertUpdate();
				objClassMasterBL = new ClassMasterBL();
				if (objClassMaster.ClassId == null)
				{
					objClassMaster = objClassMasterBL.InsertClassMaster(objClassMaster);
				}
				else
				{
					objClassMaster = objClassMasterBL.UpdateClassMaster(objClassMaster);
				}
				if (objClassMaster.DbOperationStatus == CommonConstant.SUCCEED
							|| objClassMaster.DbOperationStatus == CommonConstant.INVALID)
				{
					InitializeForm();
					MultiViewClassMaster.ActiveViewIndex = 0;
				}
				UIUtility.DisplayMessage(lblMessage, objClassMaster.DbOperationStatus);
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
			MultiViewClassMaster.ActiveViewIndex = 0;
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
	protected void BindClassMasterControls()
	{
		if (!Convert.ToBoolean(ViewState[isControlsLoaded]))
		{
			ViewState[isControlsLoaded] = true;
		}
	}
	protected void ActivateControlsView(bool isNewRecord, ClassMaster objClassMaster,int? editIndex)
	{
		if (isNewRecord)
		{
			ViewState[editIndexKey] = null;
			BindClassMasterControls();
			UIUtility.InitializeControls(ViewClassMasterControls);
		}
		else
		{
			ViewState[editIndexKey] = editIndex;
			BindClassMasterControls();
			PopulateControlsData(objClassMaster);
		}
		MultiViewClassMaster.ActiveViewIndex = 1;
	}
	private void PopulateControlsData(ClassMaster objClassMaster)
	{
		txtClassCode.Text = objClassMaster.ClassCode;
		txtClassName.Text = objClassMaster.ClassName;
		txtDescription.Text = objClassMaster.Description;
		UIUtility.SelectCurrentListItem(ddlIsStudent, objClassMaster.IsStudent, BindListItem.ByValue, true);
	}
	#endregion

	#region Helper Functions
	private bool ValidateObject()
	{
		return true;
	}
	private ClassMaster GetObjectForInsertUpdate()
	{
		objClassMaster = new ClassMaster();

		if (ViewState[editIndexKey] == null)
		{
			objClassMaster.Version = BusinessUtility.RECORD_VERSION;
			objClassMaster.CreatedBy = LoggedInUser;
			objClassMaster.CreatedOn = GeneralUtility.CurrentDateTime;
		}
		else
		{
			objClassMaster.ClassId = Convert.ToInt32(grdClassMaster.DataKeys[Convert.ToInt32(ViewState[editIndexKey])].Values[CLASS_ID_INDEX].ToString());
			objClassMaster.Version = Convert.ToInt16(grdClassMaster.DataKeys[Convert.ToInt16(ViewState[editIndexKey])].Values[VERSION_INDEX].ToString()) + 1;
		}

		objClassMaster.ClassCode = txtClassCode.Text;
		objClassMaster.ClassName = txtClassName.Text;
		objClassMaster.Description = txtDescription.Text;
		objClassMaster.IsStudent = Convert.ToBoolean(ddlIsStudent.SelectedItem.Value);
		objClassMaster.ModifiedBy = LoggedInUser;
		objClassMaster.ModifiedOn = GeneralUtility.CurrentDateTime;
		objClassMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
		return objClassMaster;
	}
	private ClassMaster GetObjectForActivateDeactivate(int editIndex,RecordStatus objStatus)
	{
		objClassMaster = new ClassMaster();
		objClassMaster.ClassId = Convert.ToInt32(grdClassMaster.DataKeys[editIndex].Values[CLASS_ID_INDEX].ToString());
		objClassMaster.Version = Convert.ToInt16(grdClassMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString()) + 1;
		objClassMaster.ModifiedBy = LoggedInUser;
		objClassMaster.RecordStatus = Convert.ToInt16(objStatus);
		return objClassMaster;
	}
	private ClassMaster SelectRecordById(int editIndex)
	{
		objClassMasterBL = new ClassMasterBL();
		objClassMaster = new ClassMaster();
		objClassMaster.ClassId = Convert.ToInt32(grdClassMaster.DataKeys[editIndex].Values[CLASS_ID_INDEX].ToString());
		objClassMaster.Version = Convert.ToInt16(grdClassMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString());
		objClassMaster = objClassMasterBL.SelectRecordById(objClassMaster);
		return objClassMaster;
	}
	#endregion
}
