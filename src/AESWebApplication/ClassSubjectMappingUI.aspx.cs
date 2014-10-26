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

public partial class ClassSubjectMappingUI : BasePage
{
	#region Page Variables
	ClassSubjectMapping objClassSubjectMapping = null;
	ClassSubjectMappingBL objClassSubjectMappingBL = null;
	ClassMaster objClassMaster = null;
	ClassMasterBL objClassMasterBL = null;
	SubjectMaster objSubjectMaster = null;
	SubjectMasterBL objSubjectMasterBL = null;

	private const int SELECT_COLUMN = 0;
	private const int ACTIVATE_COLUMN = 1;
	private const int DELETE_COLUMN = 2;

	private const int CLASS_SUBJECT_MAPPING_ID_INDEX = 0;
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
			objClassSubjectMapping = BindClassSubjectMappingGrid(RecordStatus.Active);
			if (objClassSubjectMapping.DbOperationStatus != CommonConstant.SUCCEED)
			{
				btnAddNewRecord.Enabled = false;
				UIUtility.DisplayMessage(lblMessage, objClassSubjectMapping.DbOperationStatus);
				return;
			}

			ViewState[isControlsLoaded] = false;

			if (grdClassSubjectMapping.Rows.Count == 0)
			{
				BindClassSubjectMappingControls();
				MultiViewClassSubjectMapping.ActiveViewIndex = 1;
			}
		}
		else
		{
			if (rdbActiveRecord.Checked)
			{
				objClassSubjectMapping = BindClassSubjectMappingGrid(RecordStatus.Active);
				if (objClassSubjectMapping.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objClassSubjectMapping.DbOperationStatus);
					return;
				}
				ViewActivateColumn(false);
			}
			else
			{
				objClassSubjectMapping = BindClassSubjectMappingGrid(RecordStatus.InActive);
				if (objClassSubjectMapping.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objClassSubjectMapping.DbOperationStatus);
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
			grdClassSubjectMapping.Columns[SELECT_COLUMN].Visible = false;
			grdClassSubjectMapping.Columns[ACTIVATE_COLUMN].Visible = true;
			grdClassSubjectMapping.Columns[DELETE_COLUMN].Visible = false;
		}
		else
		{
			grdClassSubjectMapping.Columns[SELECT_COLUMN].Visible = true;
			grdClassSubjectMapping.Columns[ACTIVATE_COLUMN].Visible = false;
			grdClassSubjectMapping.Columns[DELETE_COLUMN].Visible = true;
		}
	}
	#endregion

	#region Grid Events and Functions
	protected void grdClassSubjectMapping_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			objClassSubjectMapping = SelectRecordById(grdClassSubjectMapping.SelectedIndex);
			if (!objClassSubjectMapping.DbOperationStatus.Equals(CommonConstant.FAIL))
			{
				if(!Convert.ToBoolean(objClassSubjectMapping.IsRecordChanged))
				{
					ActivateControlsView(false, objClassSubjectMapping, grdClassSubjectMapping.SelectedIndex);
				}
				else
				{
					UIUtility.DisplayMessage(lblMessage, objClassSubjectMapping.DbOperationStatus);
					InitializeForm();
				}
			}
			else
			{
				UIUtility.DisplayMessage(lblMessage, objClassSubjectMapping.DbOperationStatus);
			}
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdClassSubjectMapping_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			objClassSubjectMappingBL = new ClassSubjectMappingBL();
			objClassSubjectMapping = GetObjectForActivateDeactivate(e.RowIndex,RecordStatus.InActive);
			objClassSubjectMapping = objClassSubjectMappingBL.ActivateDeactivateClassSubjectMapping(objClassSubjectMapping);
			UIUtility.DisplayMessage(lblMessage, objClassSubjectMapping.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdClassSubjectMapping_ActivatingObject(object sender, GridViewEditEventArgs e)
	{
		try
		{
			objClassSubjectMappingBL = new ClassSubjectMappingBL();
			objClassSubjectMapping = GetObjectForActivateDeactivate(e.NewEditIndex, RecordStatus.Active);
			objClassSubjectMapping = objClassSubjectMappingBL.ActivateDeactivateClassSubjectMapping(objClassSubjectMapping);
			UIUtility.DisplayMessage(lblMessage, objClassSubjectMapping.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdClassSubjectMapping_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			grdClassSubjectMapping.PageIndex = e.NewPageIndex;
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected ClassSubjectMapping BindClassSubjectMappingGrid(RecordStatus objRecordStatus)
	{
		objClassSubjectMappingBL = new ClassSubjectMappingBL();
		objClassSubjectMapping = new ClassSubjectMapping();
		objClassSubjectMapping.RecordStatus = Convert.ToInt16(objRecordStatus);

		objClassSubjectMapping = objClassSubjectMappingBL.SelectClassSubjectMapping(objClassSubjectMapping);
		if (objClassSubjectMapping.DbOperationStatus == CommonConstant.SUCCEED)
		{
			grdClassSubjectMapping.DataSource = objClassSubjectMapping.ObjectDataSet.Tables[0];
			grdClassSubjectMapping.DataBind();
		}
		return objClassSubjectMapping;
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
				objClassSubjectMapping = GetObjectForInsertUpdate();
				objClassSubjectMappingBL = new ClassSubjectMappingBL();
				if (objClassSubjectMapping.ClassSubjectMappingId == null)
				{
					objClassSubjectMapping = objClassSubjectMappingBL.InsertClassSubjectMapping(objClassSubjectMapping);
				}
				else
				{
					objClassSubjectMapping = objClassSubjectMappingBL.UpdateClassSubjectMapping(objClassSubjectMapping);
				}
				if (objClassSubjectMapping.DbOperationStatus == CommonConstant.SUCCEED
							|| objClassSubjectMapping.DbOperationStatus == CommonConstant.INVALID)
				{
					InitializeForm();
					MultiViewClassSubjectMapping.ActiveViewIndex = 0;
				}
				UIUtility.DisplayMessage(lblMessage, objClassSubjectMapping.DbOperationStatus);
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
			MultiViewClassSubjectMapping.ActiveViewIndex = 0;
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
	protected void BindClassSubjectMappingControls()
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

			objSubjectMasterBL = new SubjectMasterBL();
			objSubjectMaster = new SubjectMaster();
			objSubjectMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
			objSubjectMaster = objSubjectMasterBL.SelectSubjectMaster(objSubjectMaster);
			ddlSubject.DataSource = objSubjectMaster.ObjectDataSet.Tables[0];
			ddlSubject.DataBind();
			ddlSubject.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

			ViewState[isControlsLoaded] = true;
		}
	}
	protected void ActivateControlsView(bool isNewRecord, ClassSubjectMapping objClassSubjectMapping,int? editIndex)
	{
		if (isNewRecord)
		{
			ViewState[editIndexKey] = null;
			BindClassSubjectMappingControls();
			UIUtility.InitializeControls(ViewClassSubjectMappingControls);
		}
		else
		{
			ViewState[editIndexKey] = editIndex;
			BindClassSubjectMappingControls();
			PopulateControlsData(objClassSubjectMapping);
		}
		MultiViewClassSubjectMapping.ActiveViewIndex = 1;
	}
	private void PopulateControlsData(ClassSubjectMapping objClassSubjectMapping)
	{
		txtClassSubjectMappingName.Text = objClassSubjectMapping.ClassSubjectMappingName;
		UIUtility.SelectCurrentListItem(ddlClass, objClassSubjectMapping.ClassObject.ClassId, BindListItem.ByValue, true);
		UIUtility.SelectCurrentListItem(ddlSubject, objClassSubjectMapping.SubjectObject.SubjectId, BindListItem.ByValue, true);
		txtDescription.Text = objClassSubjectMapping.Description;
	}
	#endregion

	#region Helper Functions
	private bool ValidateObject()
	{
		return true;
	}
	private ClassSubjectMapping GetObjectForInsertUpdate()
	{
		objClassSubjectMapping = new ClassSubjectMapping();

		if (ViewState[editIndexKey] == null)
		{
			objClassSubjectMapping.Version = BusinessUtility.RECORD_VERSION;
			objClassSubjectMapping.CreatedBy = LoggedInUser;
			objClassSubjectMapping.CreatedOn = GeneralUtility.CurrentDateTime;
		}
		else
		{
			objClassSubjectMapping.ClassSubjectMappingId = Convert.ToInt32(grdClassSubjectMapping.DataKeys[Convert.ToInt32(ViewState[editIndexKey])].Values[CLASS_SUBJECT_MAPPING_ID_INDEX].ToString());
			objClassSubjectMapping.Version = Convert.ToInt16(grdClassSubjectMapping.DataKeys[Convert.ToInt16(ViewState[editIndexKey])].Values[VERSION_INDEX].ToString()) + 1;
		}

		objClassSubjectMapping.ClassSubjectMappingName = txtClassSubjectMappingName.Text;
		if (ddlClass.SelectedIndex != 0)
		{
			objClassSubjectMapping.ClassObject = new ClassMaster();
			objClassSubjectMapping.ClassObject.ClassId = Convert.ToInt32(ddlClass.SelectedItem.Value);
		}
		if (ddlSubject.SelectedIndex != 0)
		{
			objClassSubjectMapping.SubjectObject = new SubjectMaster();
			objClassSubjectMapping.SubjectObject.SubjectId = Convert.ToInt32(ddlSubject.SelectedItem.Value);
		}
		objClassSubjectMapping.Description = txtDescription.Text;
		objClassSubjectMapping.ModifiedBy = LoggedInUser;
		objClassSubjectMapping.ModifiedOn = GeneralUtility.CurrentDateTime;
		objClassSubjectMapping.RecordStatus = Convert.ToInt16(RecordStatus.Active);
		return objClassSubjectMapping;
	}
	private ClassSubjectMapping GetObjectForActivateDeactivate(int editIndex,RecordStatus objStatus)
	{
		objClassSubjectMapping = new ClassSubjectMapping();
		objClassSubjectMapping.ClassSubjectMappingId = Convert.ToInt32(grdClassSubjectMapping.DataKeys[editIndex].Values[CLASS_SUBJECT_MAPPING_ID_INDEX].ToString());
		objClassSubjectMapping.Version = Convert.ToInt16(grdClassSubjectMapping.DataKeys[editIndex].Values[VERSION_INDEX].ToString()) + 1;
		objClassSubjectMapping.ModifiedBy = LoggedInUser;
		objClassSubjectMapping.RecordStatus = Convert.ToInt16(objStatus);
		return objClassSubjectMapping;
	}
	private ClassSubjectMapping SelectRecordById(int editIndex)
	{
		objClassSubjectMappingBL = new ClassSubjectMappingBL();
		objClassSubjectMapping = new ClassSubjectMapping();
		objClassSubjectMapping.ClassSubjectMappingId = Convert.ToInt32(grdClassSubjectMapping.DataKeys[editIndex].Values[CLASS_SUBJECT_MAPPING_ID_INDEX].ToString());
		objClassSubjectMapping.Version = Convert.ToInt16(grdClassSubjectMapping.DataKeys[editIndex].Values[VERSION_INDEX].ToString());
		objClassSubjectMapping = objClassSubjectMappingBL.SelectRecordById(objClassSubjectMapping);
		return objClassSubjectMapping;
	}
	#endregion
}
