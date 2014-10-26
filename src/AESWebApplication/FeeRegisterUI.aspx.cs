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

public partial class FeeRegisterUI : BasePage
{
	#region Page Variables
	FeeRegister objFeeRegister = null;
	FeeRegisterBL objFeeRegisterBL = null;
	FeeStructure objFeeStructure = null;
	FeeStructureBL objFeeStructureBL = null;
	StudentDetail objStudentDetail = null;
	StudentDetailBL objStudentDetailBL = null;
	FeeMaster objFeeMaster = null;
	FeeMasterBL objFeeMasterBL = null;

	private const int SELECT_COLUMN = 0;
	private const int ACTIVATE_COLUMN = 1;
	private const int DELETE_COLUMN = 2;

	private const int FEE_REGISTER_ID_INDEX = 0;
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
			objFeeRegister = BindFeeRegisterGrid(RecordStatus.Active);
			if (objFeeRegister.DbOperationStatus != CommonConstant.SUCCEED)
			{
				btnAddNewRecord.Enabled = false;
				UIUtility.DisplayMessage(lblMessage, objFeeRegister.DbOperationStatus);
				return;
			}

			ViewState[isControlsLoaded] = false;

			if (grdFeeRegister.Rows.Count == 0)
			{
				BindFeeRegisterControls();
				MultiViewFeeRegister.ActiveViewIndex = 1;
			}
		}
		else
		{
			if (rdbActiveRecord.Checked)
			{
				objFeeRegister = BindFeeRegisterGrid(RecordStatus.Active);
				if (objFeeRegister.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objFeeRegister.DbOperationStatus);
					return;
				}
				ViewActivateColumn(false);
			}
			else
			{
				objFeeRegister = BindFeeRegisterGrid(RecordStatus.InActive);
				if (objFeeRegister.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objFeeRegister.DbOperationStatus);
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
			grdFeeRegister.Columns[SELECT_COLUMN].Visible = false;
			grdFeeRegister.Columns[ACTIVATE_COLUMN].Visible = true;
			grdFeeRegister.Columns[DELETE_COLUMN].Visible = false;
		}
		else
		{
			grdFeeRegister.Columns[SELECT_COLUMN].Visible = true;
			grdFeeRegister.Columns[ACTIVATE_COLUMN].Visible = false;
			grdFeeRegister.Columns[DELETE_COLUMN].Visible = true;
		}
	}
	#endregion

	#region Grid Events and Functions
	protected void grdFeeRegister_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			objFeeRegister = SelectRecordById(grdFeeRegister.SelectedIndex);
			if (!objFeeRegister.DbOperationStatus.Equals(CommonConstant.FAIL))
			{
				if(!Convert.ToBoolean(objFeeRegister.IsRecordChanged))
				{
					ActivateControlsView(false, objFeeRegister, grdFeeRegister.SelectedIndex);
				}
				else
				{
					UIUtility.DisplayMessage(lblMessage, objFeeRegister.DbOperationStatus);
					InitializeForm();
				}
			}
			else
			{
				UIUtility.DisplayMessage(lblMessage, objFeeRegister.DbOperationStatus);
			}
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdFeeRegister_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			objFeeRegisterBL = new FeeRegisterBL();
			objFeeRegister = GetObjectForActivateDeactivate(e.RowIndex,RecordStatus.InActive);
			objFeeRegister = objFeeRegisterBL.ActivateDeactivateFeeRegister(objFeeRegister);
			UIUtility.DisplayMessage(lblMessage, objFeeRegister.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdFeeRegister_ActivatingObject(object sender, GridViewEditEventArgs e)
	{
		try
		{
			objFeeRegisterBL = new FeeRegisterBL();
			objFeeRegister = GetObjectForActivateDeactivate(e.NewEditIndex, RecordStatus.Active);
			objFeeRegister = objFeeRegisterBL.ActivateDeactivateFeeRegister(objFeeRegister);
			UIUtility.DisplayMessage(lblMessage, objFeeRegister.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdFeeRegister_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			grdFeeRegister.PageIndex = e.NewPageIndex;
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected FeeRegister BindFeeRegisterGrid(RecordStatus objRecordStatus)
	{
		objFeeRegisterBL = new FeeRegisterBL();
		objFeeRegister = new FeeRegister();
		objFeeRegister.RecordStatus = Convert.ToInt16(objRecordStatus);

		objFeeRegister = objFeeRegisterBL.SelectFeeRegister(objFeeRegister);
		if (objFeeRegister.DbOperationStatus == CommonConstant.SUCCEED)
		{
			grdFeeRegister.DataSource = objFeeRegister.ObjectDataSet.Tables[0];
			grdFeeRegister.DataBind();
		}
		return objFeeRegister;
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
				objFeeRegister = GetObjectForInsertUpdate();
				objFeeRegisterBL = new FeeRegisterBL();
				if (objFeeRegister.FeeRegisterId == null)
				{
					objFeeRegister = objFeeRegisterBL.InsertFeeRegister(objFeeRegister);
				}
				else
				{
					objFeeRegister = objFeeRegisterBL.UpdateFeeRegister(objFeeRegister);
				}
				if (objFeeRegister.DbOperationStatus == CommonConstant.SUCCEED
							|| objFeeRegister.DbOperationStatus == CommonConstant.INVALID)
				{
					InitializeForm();
					MultiViewFeeRegister.ActiveViewIndex = 0;
				}
				UIUtility.DisplayMessage(lblMessage, objFeeRegister.DbOperationStatus);
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
			MultiViewFeeRegister.ActiveViewIndex = 0;
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
	protected void BindFeeRegisterControls()
	{
		if (!Convert.ToBoolean(ViewState[isControlsLoaded]))
		{
			objFeeStructureBL = new FeeStructureBL();
			objFeeStructure = new FeeStructure();
			objFeeStructure.RecordStatus = Convert.ToInt16(RecordStatus.Active);
			objFeeStructure = objFeeStructureBL.SelectFeeStructure(objFeeStructure);
			ddlFee.DataSource = objFeeStructure.ObjectDataSet.Tables[0];
			ddlFee.DataBind();
			ddlFee.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

			objStudentDetailBL = new StudentDetailBL();
			objStudentDetail = new StudentDetail();
			objStudentDetail.RecordStatus = Convert.ToInt16(RecordStatus.Active);
			objStudentDetail = objStudentDetailBL.SelectStudentDetail(objStudentDetail);
			ddlStudent.DataSource = objStudentDetail.ObjectDataSet.Tables[0];
			ddlStudent.DataBind();
			ddlStudent.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

			objFeeMasterBL = new FeeMasterBL();
			objFeeMaster = new FeeMaster();
			objFeeMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
			objFeeMaster = objFeeMasterBL.SelectFeeMaster(objFeeMaster);
			ddlComponent.DataSource = objFeeMaster.ObjectDataSet.Tables[0];
			ddlComponent.DataBind();
			ddlComponent.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

			ViewState[isControlsLoaded] = true;
		}
	}
	protected void ActivateControlsView(bool isNewRecord, FeeRegister objFeeRegister,int? editIndex)
	{
		if (isNewRecord)
		{
			ViewState[editIndexKey] = null;
			BindFeeRegisterControls();
			UIUtility.InitializeControls(ViewFeeRegisterControls);
		}
		else
		{
			ViewState[editIndexKey] = editIndex;
			BindFeeRegisterControls();
			PopulateControlsData(objFeeRegister);
		}
		MultiViewFeeRegister.ActiveViewIndex = 1;
	}
	private void PopulateControlsData(FeeRegister objFeeRegister)
	{
		UIUtility.SelectCurrentListItem(ddlFee, objFeeRegister.FeeStructureObject.FeeStructureId, BindListItem.ByValue, true);
		UIUtility.SelectCurrentListItem(ddlStudent, objFeeRegister.StudentObject.StudentId, BindListItem.ByValue, true);
		UIUtility.SelectCurrentListItem(ddlComponent, objFeeRegister.ComponentObject.FeeId, BindListItem.ByValue, true);
		txtComponentAmount.Text = objFeeRegister.ComponentAmount.ToString();
		txtComponentType.Text = objFeeRegister.ComponentType.ToString();
		txtProcessDate.Text = objFeeRegister.ProcessDate.ToString();
	}
	#endregion

	#region Helper Functions
	private bool ValidateObject()
	{
		return true;
	}
	private FeeRegister GetObjectForInsertUpdate()
	{
		objFeeRegister = new FeeRegister();

		if (ViewState[editIndexKey] == null)
		{
			objFeeRegister.Version = BusinessUtility.RECORD_VERSION;
			objFeeRegister.CreatedBy = LoggedInUser;
			objFeeRegister.CreatedOn = GeneralUtility.CurrentDateTime;
		}
		else
		{
			objFeeRegister.FeeRegisterId = Convert.ToInt32(grdFeeRegister.DataKeys[Convert.ToInt32(ViewState[editIndexKey])].Values[FEE_REGISTER_ID_INDEX].ToString());
			objFeeRegister.Version = Convert.ToInt16(grdFeeRegister.DataKeys[Convert.ToInt16(ViewState[editIndexKey])].Values[VERSION_INDEX].ToString()) + 1;
		}

		if (ddlFee.SelectedIndex != 0)
		{
			objFeeRegister.FeeStructureObject = new FeeStructure();
			objFeeRegister.FeeStructureObject.FeeStructureId = Convert.ToInt32(ddlFee.SelectedItem.Value);
		}
		if (ddlStudent.SelectedIndex != 0)
		{
			objFeeRegister.StudentObject = new StudentDetail();
			objFeeRegister.StudentObject.StudentId = Convert.ToInt32(ddlStudent.SelectedItem.Value);
		}
		if (ddlComponent.SelectedIndex != 0)
		{
			objFeeRegister.ComponentObject = new FeeMaster();
			objFeeRegister.ComponentObject.FeeId = Convert.ToInt32(ddlComponent.SelectedItem.Value);
		}
		objFeeRegister.ComponentAmount = Convert.ToDecimal(txtComponentAmount.Text);
		objFeeRegister.ComponentType = Convert.ToInt32(txtComponentType.Text);
		objFeeRegister.ProcessDate = Convert.ToDateTime(txtProcessDate.Text);
		objFeeRegister.ModifiedBy = LoggedInUser;
		objFeeRegister.ModifiedOn = GeneralUtility.CurrentDateTime;
		objFeeRegister.RecordStatus = Convert.ToInt16(RecordStatus.Active);
		return objFeeRegister;
	}
	private FeeRegister GetObjectForActivateDeactivate(int editIndex,RecordStatus objStatus)
	{
		objFeeRegister = new FeeRegister();
		objFeeRegister.FeeRegisterId = Convert.ToInt32(grdFeeRegister.DataKeys[editIndex].Values[FEE_REGISTER_ID_INDEX].ToString());
		objFeeRegister.Version = Convert.ToInt16(grdFeeRegister.DataKeys[editIndex].Values[VERSION_INDEX].ToString()) + 1;
		objFeeRegister.ModifiedBy = LoggedInUser;
		objFeeRegister.RecordStatus = Convert.ToInt16(objStatus);
		return objFeeRegister;
	}
	private FeeRegister SelectRecordById(int editIndex)
	{
		objFeeRegisterBL = new FeeRegisterBL();
		objFeeRegister = new FeeRegister();
		objFeeRegister.FeeRegisterId = Convert.ToInt32(grdFeeRegister.DataKeys[editIndex].Values[FEE_REGISTER_ID_INDEX].ToString());
		objFeeRegister.Version = Convert.ToInt16(grdFeeRegister.DataKeys[editIndex].Values[VERSION_INDEX].ToString());
		objFeeRegister = objFeeRegisterBL.SelectRecordById(objFeeRegister);
		return objFeeRegister;
	}
	#endregion
}
