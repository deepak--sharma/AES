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

public partial class StudentDetailUI : BasePage
{
	#region Page Variables
	StudentDetail objStudentDetail = null;
	StudentDetailBL objStudentDetailBL = null;
	ClassMaster objClassMaster = null;
	ClassMasterBL objClassMasterBL = null;
    SectionMaster objSectionMaster = null;
    SectionMasterBL objSectionMasterBL = null;
	StreamMaster objStreamMaster = null;
	StreamMasterBL objStreamMasterBL = null;
	FeeStructure objFeeStructure = null;
	FeeStructureBL objFeeStructureBL = null;

	private const int SELECT_COLUMN = 0;
	private const int ACTIVATE_COLUMN = 1;
	private const int DELETE_COLUMN = 2;

	private const int STUDENT_ID_INDEX = 0;
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
			objStudentDetail = BindStudentDetailGrid(RecordStatus.Active);
			if (objStudentDetail.DbOperationStatus != CommonConstant.SUCCEED)
			{
				btnAddNewRecord.Enabled = false;
				UIUtility.DisplayMessage(lblMessage, objStudentDetail.DbOperationStatus);
				return;
			}

			ViewState[isControlsLoaded] = false;

			if (grdStudentDetail.Rows.Count == 0)
			{
				BindStudentDetailControls();
				MultiViewStudentDetail.ActiveViewIndex = 1;
			}
		}
		else
		{
			if (rdbActiveRecord.Checked)
			{
				objStudentDetail = BindStudentDetailGrid(RecordStatus.Active);
				if (objStudentDetail.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objStudentDetail.DbOperationStatus);
					return;
				}
				ViewActivateColumn(false);
			}
			else
			{
				objStudentDetail = BindStudentDetailGrid(RecordStatus.InActive);
				if (objStudentDetail.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objStudentDetail.DbOperationStatus);
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
			grdStudentDetail.Columns[SELECT_COLUMN].Visible = false;
			grdStudentDetail.Columns[ACTIVATE_COLUMN].Visible = true;
			grdStudentDetail.Columns[DELETE_COLUMN].Visible = false;
		}
		else
		{
			grdStudentDetail.Columns[SELECT_COLUMN].Visible = true;
			grdStudentDetail.Columns[ACTIVATE_COLUMN].Visible = false;
			grdStudentDetail.Columns[DELETE_COLUMN].Visible = true;
		}
	}
	#endregion

	#region Grid Events and Functions
	protected void grdStudentDetail_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			objStudentDetail = SelectRecordById(grdStudentDetail.SelectedIndex);
			if (!objStudentDetail.DbOperationStatus.Equals(CommonConstant.FAIL))
			{
				if(!Convert.ToBoolean(objStudentDetail.IsRecordChanged))
				{
					ActivateControlsView(false, objStudentDetail, grdStudentDetail.SelectedIndex);
				}
				else
				{
					UIUtility.DisplayMessage(lblMessage, objStudentDetail.DbOperationStatus);
					InitializeForm();
				}
			}
			else
			{
				UIUtility.DisplayMessage(lblMessage, objStudentDetail.DbOperationStatus);
			}
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdStudentDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			objStudentDetailBL = new StudentDetailBL();
			objStudentDetail = GetObjectForActivateDeactivate(e.RowIndex,RecordStatus.InActive);
			objStudentDetail = objStudentDetailBL.ActivateDeactivateStudentDetail(objStudentDetail);
			UIUtility.DisplayMessage(lblMessage, objStudentDetail.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdStudentDetail_ActivatingObject(object sender, GridViewEditEventArgs e)
	{
		try
		{
			objStudentDetailBL = new StudentDetailBL();
			objStudentDetail = GetObjectForActivateDeactivate(e.NewEditIndex, RecordStatus.Active);
			objStudentDetail = objStudentDetailBL.ActivateDeactivateStudentDetail(objStudentDetail);
			UIUtility.DisplayMessage(lblMessage, objStudentDetail.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdStudentDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			grdStudentDetail.PageIndex = e.NewPageIndex;
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected StudentDetail BindStudentDetailGrid(RecordStatus objRecordStatus)
	{
		objStudentDetailBL = new StudentDetailBL();
		objStudentDetail = new StudentDetail();
		objStudentDetail.RecordStatus = Convert.ToInt16(objRecordStatus);

		objStudentDetail = objStudentDetailBL.SelectStudentDetail(objStudentDetail);
		if (objStudentDetail.DbOperationStatus == CommonConstant.SUCCEED)
		{
			grdStudentDetail.DataSource = objStudentDetail.ObjectDataSet.Tables[0];
			grdStudentDetail.DataBind();
		}
		return objStudentDetail;
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
				objStudentDetail = GetObjectForInsertUpdate();
				objStudentDetailBL = new StudentDetailBL();
				if (objStudentDetail.StudentId == null)
				{
					objStudentDetail = objStudentDetailBL.InsertStudentDetail(objStudentDetail);
				}
				else
				{
					objStudentDetail = objStudentDetailBL.UpdateStudentDetail(objStudentDetail);
				}
				if (objStudentDetail.DbOperationStatus == CommonConstant.SUCCEED
							|| objStudentDetail.DbOperationStatus == CommonConstant.INVALID)
				{
					InitializeForm();
					MultiViewStudentDetail.ActiveViewIndex = 0;
				}
				UIUtility.DisplayMessage(lblMessage, objStudentDetail.DbOperationStatus);
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
			MultiViewStudentDetail.ActiveViewIndex = 0;
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
	protected void BindStudentDetailControls()
	{
		if (!Convert.ToBoolean(ViewState[isControlsLoaded]))
		{
			uxCandidateUC.BindUCControls();
			objClassMasterBL = new ClassMasterBL();
			objClassMaster = new ClassMaster();
			objClassMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
			objClassMaster = objClassMasterBL.SelectClassMaster(objClassMaster);
			ddlClass.DataSource = objClassMaster.ObjectDataSet.Tables[0];
			ddlClass.DataBind();
			ddlClass.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

			objSectionMasterBL = new SectionMasterBL();
			objSectionMaster = new SectionMaster();
			objSectionMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
			objSectionMaster = objSectionMasterBL.SelectSectionMaster(objSectionMaster);
			ddlSection.DataSource = objSectionMaster.ObjectDataSet.Tables[0];
			ddlSection.DataBind();
			ddlSection.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

			objStreamMasterBL = new StreamMasterBL();
			objStreamMaster = new StreamMaster();
			objStreamMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
			objStreamMaster = objStreamMasterBL.SelectStreamMaster(objStreamMaster);
			ddlStream.DataSource = objStreamMaster.ObjectDataSet.Tables[0];
			ddlStream.DataBind();
			ddlStream.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

			objFeeStructureBL = new FeeStructureBL();
			objFeeStructure = new FeeStructure();
			objFeeStructure.RecordStatus = Convert.ToInt16(RecordStatus.Active);
			objFeeStructure = objFeeStructureBL.SelectFeeStructure(objFeeStructure);
			ddlFee.DataSource = objFeeStructure.ObjectDataSet.Tables[0];
			ddlFee.DataBind();
			ddlFee.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

			ViewState[isControlsLoaded] = true;
		}
	}
	protected void ActivateControlsView(bool isNewRecord, StudentDetail objStudentDetail,int? editIndex)
	{
		if (isNewRecord)
		{
			ViewState[editIndexKey] = null;
			BindStudentDetailControls();
			UIUtility.InitializeControls(ViewStudentDetailControls);
		}
		else
		{
			ViewState[editIndexKey] = editIndex;
			BindStudentDetailControls();
			PopulateControlsData(objStudentDetail);
		}
		MultiViewStudentDetail.ActiveViewIndex = 1;
	}
	private void PopulateControlsData(StudentDetail objStudentDetail)
	{
//		uxCandidateUC.SetUserControlData(objStudentDetail.CandidateObject);
//		UIUtility.SelectCurrentListItem(ddlClass, objStudentDetail.ClassObject.ClassId, BindListItem.ByValue, true);
//		UIUtility.SelectCurrentListItem(ddlSection, objStudentDetail.SectionObject.ClassSectionId, BindListItem.ByValue, true);
//		UIUtility.SelectCurrentListItem(ddlStream, objStudentDetail.StreamObject.StreamId, BindListItem.ByValue, true);
		txtRollNo.Text = objStudentDetail.RollNo;
		//txtSessionId.Text = objStudentDetail.SessionId.ToString();
		UIUtility.SelectCurrentListItem(ddlFee, objStudentDetail.FeeStructureObject.FeeStructureId, BindListItem.ByValue, true);
		txtAdmissionDate.Text = objStudentDetail.AdmissionDate.ToString();
	}
	#endregion

	#region Helper Functions
	private bool ValidateObject()
	{
		return true;
	}
	private StudentDetail GetObjectForInsertUpdate()
	{
		objStudentDetail = new StudentDetail();

		if (ViewState[editIndexKey] == null)
		{
			objStudentDetail.Version = BusinessUtility.RECORD_VERSION;
			objStudentDetail.CreatedBy = LoggedInUser;
			objStudentDetail.CreatedOn = GeneralUtility.CurrentDateTime;
		}
		else
		{
			objStudentDetail.StudentId = Convert.ToInt32(grdStudentDetail.DataKeys[Convert.ToInt32(ViewState[editIndexKey])].Values[STUDENT_ID_INDEX].ToString());
			objStudentDetail.Version = Convert.ToInt16(grdStudentDetail.DataKeys[Convert.ToInt16(ViewState[editIndexKey])].Values[VERSION_INDEX].ToString()) + 1;
		}

		//objStudentDetail.CandidateObject = uxCandidateUC.GetUserControlData();
		if (ddlClass.SelectedIndex != 0)
		{
			//objStudentDetail.ClassObject = new ClassMaster();
			//objStudentDetail.ClassObject.ClassId = Convert.ToInt32(ddlClass.SelectedItem.Value);
		}
		if (ddlSection.SelectedIndex != 0)
		{
			objStudentDetail.SectionObject = new SectionMaster();
			objStudentDetail.SectionObject.SectionId = Convert.ToInt32(ddlSection.SelectedItem.Value);
		}
		if (ddlStream.SelectedIndex != 0)
		{
			objStudentDetail.StreamObject = new StreamMaster();
			objStudentDetail.StreamObject.StreamId = Convert.ToInt32(ddlStream.SelectedItem.Value);
		}
		objStudentDetail.RollNo = txtRollNo.Text;
		//objStudentDetail.SessionId = Convert.ToInt32(txtSessionId.Text);
		if (ddlFee.SelectedIndex != 0)
		{
			objStudentDetail.FeeStructureObject = new FeeStructure();
			objStudentDetail.FeeStructureObject.FeeStructureId = Convert.ToInt32(ddlFee.SelectedItem.Value);
		}
		objStudentDetail.AdmissionDate = Convert.ToDateTime(txtAdmissionDate.Text);
		objStudentDetail.ModifiedBy = LoggedInUser;
		objStudentDetail.ModifiedOn = GeneralUtility.CurrentDateTime;
		objStudentDetail.RecordStatus = Convert.ToInt16(RecordStatus.Active);
		return objStudentDetail;
	}
	private StudentDetail GetObjectForActivateDeactivate(int editIndex,RecordStatus objStatus)
	{
		objStudentDetail = new StudentDetail();
		objStudentDetail.StudentId = Convert.ToInt32(grdStudentDetail.DataKeys[editIndex].Values[STUDENT_ID_INDEX].ToString());
		objStudentDetail.Version = Convert.ToInt16(grdStudentDetail.DataKeys[editIndex].Values[VERSION_INDEX].ToString()) + 1;
		objStudentDetail.ModifiedBy = LoggedInUser;
		objStudentDetail.RecordStatus = Convert.ToInt16(objStatus);
		return objStudentDetail;
	}
	private StudentDetail SelectRecordById(int editIndex)
	{
		objStudentDetailBL = new StudentDetailBL();
		objStudentDetail = new StudentDetail();
		objStudentDetail.StudentId = Convert.ToInt32(grdStudentDetail.DataKeys[editIndex].Values[STUDENT_ID_INDEX].ToString());
		objStudentDetail.Version = Convert.ToInt16(grdStudentDetail.DataKeys[editIndex].Values[VERSION_INDEX].ToString());
		objStudentDetail = objStudentDetailBL.SelectRecordById(objStudentDetail);
		return objStudentDetail;
	}
	#endregion
}
