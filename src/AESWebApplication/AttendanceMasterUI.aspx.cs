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

public partial class AttendanceMasterUI : BasePage
{
	#region Page Variables
	AttendanceMaster objAttendanceMaster = null;
	AttendanceMasterBL objAttendanceMasterBL = null;
	MetadataMaster objMetadataMaster = null;
	MetadataMasterBL objMetadataMasterBL = null;
	EmployeeDetail objEmployeeDetail = null;
	EmployeeDetailBL objEmployeeDetailBL = null;

	private const int SELECT_COLUMN = 0;
	private const int ACTIVATE_COLUMN = 1;
	private const int DELETE_COLUMN = 2;

	private const int ATTENDANCE_ID_INDEX = 0;
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
			objAttendanceMaster = BindAttendanceMasterGrid(RecordStatus.Active);
			if (objAttendanceMaster.DbOperationStatus != CommonConstant.SUCCEED)
			{
				btnAddNewRecord.Enabled = false;
				UIUtility.DisplayMessage(lblMessage, objAttendanceMaster.DbOperationStatus);
				return;
			}

			ViewState[isControlsLoaded] = false;

			if (grdAttendanceMaster.Rows.Count == 0)
			{
				BindAttendanceMasterControls();
				MultiViewAttendanceMaster.ActiveViewIndex = 1;
			}
		}
		else
		{
			if (rdbActiveRecord.Checked)
			{
				objAttendanceMaster = BindAttendanceMasterGrid(RecordStatus.Active);
				if (objAttendanceMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objAttendanceMaster.DbOperationStatus);
					return;
				}
				ViewActivateColumn(false);
			}
			else
			{
				objAttendanceMaster = BindAttendanceMasterGrid(RecordStatus.InActive);
				if (objAttendanceMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objAttendanceMaster.DbOperationStatus);
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
			grdAttendanceMaster.Columns[SELECT_COLUMN].Visible = false;
			grdAttendanceMaster.Columns[ACTIVATE_COLUMN].Visible = true;
			grdAttendanceMaster.Columns[DELETE_COLUMN].Visible = false;
		}
		else
		{
			grdAttendanceMaster.Columns[SELECT_COLUMN].Visible = true;
			grdAttendanceMaster.Columns[ACTIVATE_COLUMN].Visible = false;
			grdAttendanceMaster.Columns[DELETE_COLUMN].Visible = true;
		}
	}
	#endregion

	#region Grid Events and Functions
	protected void grdAttendanceMaster_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			objAttendanceMaster = SelectRecordById(grdAttendanceMaster.SelectedIndex);
			if (!objAttendanceMaster.DbOperationStatus.Equals(CommonConstant.FAIL))
			{
				if(!Convert.ToBoolean(objAttendanceMaster.IsRecordChanged))
				{
					ActivateControlsView(false, objAttendanceMaster, grdAttendanceMaster.SelectedIndex);
				}
				else
				{
					UIUtility.DisplayMessage(lblMessage, objAttendanceMaster.DbOperationStatus);
					InitializeForm();
				}
			}
			else
			{
				UIUtility.DisplayMessage(lblMessage, objAttendanceMaster.DbOperationStatus);
			}
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdAttendanceMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			objAttendanceMasterBL = new AttendanceMasterBL();
			objAttendanceMaster = GetObjectForActivateDeactivate(e.RowIndex,RecordStatus.InActive);
			objAttendanceMaster = objAttendanceMasterBL.ActivateDeactivateAttendanceMaster(objAttendanceMaster);
			UIUtility.DisplayMessage(lblMessage, objAttendanceMaster.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdAttendanceMaster_ActivatingObject(object sender, GridViewEditEventArgs e)
	{
		try
		{
			objAttendanceMasterBL = new AttendanceMasterBL();
			objAttendanceMaster = GetObjectForActivateDeactivate(e.NewEditIndex, RecordStatus.Active);
			objAttendanceMaster = objAttendanceMasterBL.ActivateDeactivateAttendanceMaster(objAttendanceMaster);
			UIUtility.DisplayMessage(lblMessage, objAttendanceMaster.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdAttendanceMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			grdAttendanceMaster.PageIndex = e.NewPageIndex;
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected AttendanceMaster BindAttendanceMasterGrid(RecordStatus objRecordStatus)
	{
		objAttendanceMasterBL = new AttendanceMasterBL();
		objAttendanceMaster = new AttendanceMaster();
		objAttendanceMaster.RecordStatus = Convert.ToInt16(objRecordStatus);

		objAttendanceMaster = objAttendanceMasterBL.SelectAttendanceMaster(objAttendanceMaster);
		if (objAttendanceMaster.DbOperationStatus == CommonConstant.SUCCEED)
		{
			grdAttendanceMaster.DataSource = objAttendanceMaster.ObjectDataSet.Tables[0];
			grdAttendanceMaster.DataBind();
		}
		return objAttendanceMaster;
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
				objAttendanceMaster = GetObjectForInsertUpdate();
				objAttendanceMasterBL = new AttendanceMasterBL();
				if (objAttendanceMaster.AttendanceId == null)
				{
					objAttendanceMaster = objAttendanceMasterBL.InsertAttendanceMaster(objAttendanceMaster);
				}
				else
				{
					objAttendanceMaster = objAttendanceMasterBL.UpdateAttendanceMaster(objAttendanceMaster);
				}
				if (objAttendanceMaster.DbOperationStatus == CommonConstant.SUCCEED
							|| objAttendanceMaster.DbOperationStatus == CommonConstant.INVALID)
				{
					InitializeForm();
					MultiViewAttendanceMaster.ActiveViewIndex = 0;
				}
				UIUtility.DisplayMessage(lblMessage, objAttendanceMaster.DbOperationStatus);
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
			MultiViewAttendanceMaster.ActiveViewIndex = 0;
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
	protected void BindAttendanceMasterControls()
	{
		if (!Convert.ToBoolean(ViewState[isControlsLoaded]))
		{
			objMetadataMasterBL = new MetadataMasterBL();
			objMetadataMaster = new MetadataMaster();
			objMetadataMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
			objMetadataMaster = objMetadataMasterBL.SelectMetadataMaster(objMetadataMaster);
			ddlMember.DataSource = objMetadataMaster.ObjectDataSet.Tables[0];
			ddlMember.DataBind();
			ddlMember.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

			ddlAttendance.DataSource = objMetadataMaster.ObjectDataSet.Tables[0].Copy();
			ddlAttendance.DataBind();
			ddlAttendance.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

			objEmployeeDetailBL = new EmployeeDetailBL();
			objEmployeeDetail = new EmployeeDetail();
			objEmployeeDetail.RecordStatus = Convert.ToInt16(RecordStatus.Active);
			objEmployeeDetail = objEmployeeDetailBL.SelectEmployeeDetail(objEmployeeDetail);
			ddlMarked.DataSource = objEmployeeDetail.ObjectDataSet.Tables[0];
			ddlMarked.DataBind();
			ddlMarked.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

			ViewState[isControlsLoaded] = true;
		}
	}
	protected void ActivateControlsView(bool isNewRecord, AttendanceMaster objAttendanceMaster,int? editIndex)
	{
		if (isNewRecord)
		{
			ViewState[editIndexKey] = null;
			BindAttendanceMasterControls();
			UIUtility.InitializeControls(ViewAttendanceMasterControls);
		}
		else
		{
			ViewState[editIndexKey] = editIndex;
			BindAttendanceMasterControls();
			PopulateControlsData(objAttendanceMaster);
		}
		MultiViewAttendanceMaster.ActiveViewIndex = 1;
	}
	private void PopulateControlsData(AttendanceMaster objAttendanceMaster)
	{
		txtMemberId.Text = objAttendanceMaster.MemberId.ToString();
		UIUtility.SelectCurrentListItem(ddlMember, objAttendanceMaster.MemberTypeObject.MetadataId, BindListItem.ByValue, true);
		txtActivityDetailId.Text = objAttendanceMaster.ActivityDetailId.ToString();
		UIUtility.SelectCurrentListItem(ddlAttendance, objAttendanceMaster.AttendanceStatusObject.MetadataId, BindListItem.ByValue, true);
		txtAttendanceDate.Text = objAttendanceMaster.AttendanceDate.ToString();
		txtInTime.Text = objAttendanceMaster.InTime;
		txtOutTime.Text = objAttendanceMaster.OutTime;
		UIUtility.SelectCurrentListItem(ddlMarked, objAttendanceMaster.MarkedBy.EmployeeId, BindListItem.ByValue, true);
	}
	#endregion

	#region Helper Functions
	private bool ValidateObject()
	{
		return true;
	}
	private AttendanceMaster GetObjectForInsertUpdate()
	{
		objAttendanceMaster = new AttendanceMaster();

		if (ViewState[editIndexKey] == null)
		{
			objAttendanceMaster.Version = BusinessUtility.RECORD_VERSION;
			objAttendanceMaster.CreatedBy = LoggedInUser;
			objAttendanceMaster.CreatedOn = GeneralUtility.CurrentDateTime;
		}
		else
		{
			objAttendanceMaster.AttendanceId = Convert.ToInt32(grdAttendanceMaster.DataKeys[Convert.ToInt32(ViewState[editIndexKey])].Values[ATTENDANCE_ID_INDEX].ToString());
			objAttendanceMaster.Version = Convert.ToInt16(grdAttendanceMaster.DataKeys[Convert.ToInt16(ViewState[editIndexKey])].Values[VERSION_INDEX].ToString()) + 1;
		}

		objAttendanceMaster.MemberId = Convert.ToInt32(txtMemberId.Text);
		if (ddlMember.SelectedIndex != 0)
		{
			objAttendanceMaster.MemberTypeObject = new MetadataMaster();
			objAttendanceMaster.MemberTypeObject.MetadataId = Convert.ToInt32(ddlMember.SelectedItem.Value);
		}
		objAttendanceMaster.ActivityDetailId = Convert.ToInt32(txtActivityDetailId.Text);
		if (ddlAttendance.SelectedIndex != 0)
		{
			objAttendanceMaster.AttendanceStatusObject = new MetadataMaster();
			objAttendanceMaster.AttendanceStatusObject.MetadataId = Convert.ToInt32(ddlAttendance.SelectedItem.Value);
		}
		objAttendanceMaster.AttendanceDate = Convert.ToDateTime(txtAttendanceDate.Text);
		objAttendanceMaster.InTime = txtInTime.Text;
		objAttendanceMaster.OutTime = txtOutTime.Text;
		if (ddlMarked.SelectedIndex != 0)
		{
			objAttendanceMaster.MarkedBy = new EmployeeDetail();
			objAttendanceMaster.MarkedBy.EmployeeId = Convert.ToInt32(ddlMarked.SelectedItem.Value);
		}
		objAttendanceMaster.ModifiedBy = LoggedInUser;
		objAttendanceMaster.ModifiedOn = GeneralUtility.CurrentDateTime;
		objAttendanceMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
		return objAttendanceMaster;
	}
	private AttendanceMaster GetObjectForActivateDeactivate(int editIndex,RecordStatus objStatus)
	{
		objAttendanceMaster = new AttendanceMaster();
		objAttendanceMaster.AttendanceId = Convert.ToInt32(grdAttendanceMaster.DataKeys[editIndex].Values[ATTENDANCE_ID_INDEX].ToString());
		objAttendanceMaster.Version = Convert.ToInt16(grdAttendanceMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString()) + 1;
		objAttendanceMaster.ModifiedBy = LoggedInUser;
		objAttendanceMaster.RecordStatus = Convert.ToInt16(objStatus);
		return objAttendanceMaster;
	}
	private AttendanceMaster SelectRecordById(int editIndex)
	{
		objAttendanceMasterBL = new AttendanceMasterBL();
		objAttendanceMaster = new AttendanceMaster();
		objAttendanceMaster.AttendanceId = Convert.ToInt32(grdAttendanceMaster.DataKeys[editIndex].Values[ATTENDANCE_ID_INDEX].ToString());
		objAttendanceMaster.Version = Convert.ToInt16(grdAttendanceMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString());
		objAttendanceMaster = objAttendanceMasterBL.SelectRecordById(objAttendanceMaster);
		return objAttendanceMaster;
	}
	#endregion
}
