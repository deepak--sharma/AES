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

public partial class FeeCollectionDetailUI : BasePage
{
	#region Page Variables
	FeeCollectionDetail objFeeCollectionDetail = null;
	FeeCollectionDetailBL objFeeCollectionDetailBL = null;
	StudentDetail objStudentDetail = null;
	StudentDetailBL objStudentDetailBL = null;

	private const int SELECT_COLUMN = 0;
	private const int ACTIVATE_COLUMN = 1;
	private const int DELETE_COLUMN = 2;

	private const int FEE_COLLECTION_ID_INDEX = 0;
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
			objFeeCollectionDetail = BindFeeCollectionDetailGrid(RecordStatus.Active);
			if (objFeeCollectionDetail.DbOperationStatus != CommonConstant.SUCCEED)
			{
				btnAddNewRecord.Enabled = false;
				UIUtility.DisplayMessage(lblMessage, objFeeCollectionDetail.DbOperationStatus);
				return;
			}

			ViewState[isControlsLoaded] = false;

			if (grdFeeCollectionDetail.Rows.Count == 0)
			{
				BindFeeCollectionDetailControls();
				MultiViewFeeCollectionDetail.ActiveViewIndex = 1;
			}
		}
		else
		{
			if (rdbActiveRecord.Checked)
			{
				objFeeCollectionDetail = BindFeeCollectionDetailGrid(RecordStatus.Active);
				if (objFeeCollectionDetail.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objFeeCollectionDetail.DbOperationStatus);
					return;
				}
				ViewActivateColumn(false);
			}
			else
			{
				objFeeCollectionDetail = BindFeeCollectionDetailGrid(RecordStatus.InActive);
				if (objFeeCollectionDetail.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objFeeCollectionDetail.DbOperationStatus);
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
			grdFeeCollectionDetail.Columns[SELECT_COLUMN].Visible = false;
			grdFeeCollectionDetail.Columns[ACTIVATE_COLUMN].Visible = true;
			grdFeeCollectionDetail.Columns[DELETE_COLUMN].Visible = false;
		}
		else
		{
			grdFeeCollectionDetail.Columns[SELECT_COLUMN].Visible = true;
			grdFeeCollectionDetail.Columns[ACTIVATE_COLUMN].Visible = false;
			grdFeeCollectionDetail.Columns[DELETE_COLUMN].Visible = true;
		}
	}
	#endregion

	#region Grid Events and Functions
	protected void grdFeeCollectionDetail_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			objFeeCollectionDetail = SelectRecordById(grdFeeCollectionDetail.SelectedIndex);
			if (!objFeeCollectionDetail.DbOperationStatus.Equals(CommonConstant.FAIL))
			{
				if(!Convert.ToBoolean(objFeeCollectionDetail.IsRecordChanged))
				{
					ActivateControlsView(false, objFeeCollectionDetail, grdFeeCollectionDetail.SelectedIndex);
				}
				else
				{
					UIUtility.DisplayMessage(lblMessage, objFeeCollectionDetail.DbOperationStatus);
					InitializeForm();
				}
			}
			else
			{
				UIUtility.DisplayMessage(lblMessage, objFeeCollectionDetail.DbOperationStatus);
			}
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdFeeCollectionDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			objFeeCollectionDetailBL = new FeeCollectionDetailBL();
			objFeeCollectionDetail = GetObjectForActivateDeactivate(e.RowIndex,RecordStatus.InActive);
			objFeeCollectionDetail = objFeeCollectionDetailBL.ActivateDeactivateFeeCollectionDetail(objFeeCollectionDetail);
			UIUtility.DisplayMessage(lblMessage, objFeeCollectionDetail.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdFeeCollectionDetail_ActivatingObject(object sender, GridViewEditEventArgs e)
	{
		try
		{
			objFeeCollectionDetailBL = new FeeCollectionDetailBL();
			objFeeCollectionDetail = GetObjectForActivateDeactivate(e.NewEditIndex, RecordStatus.Active);
			objFeeCollectionDetail = objFeeCollectionDetailBL.ActivateDeactivateFeeCollectionDetail(objFeeCollectionDetail);
			UIUtility.DisplayMessage(lblMessage, objFeeCollectionDetail.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdFeeCollectionDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			grdFeeCollectionDetail.PageIndex = e.NewPageIndex;
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected FeeCollectionDetail BindFeeCollectionDetailGrid(RecordStatus objRecordStatus)
	{
		objFeeCollectionDetailBL = new FeeCollectionDetailBL();
		objFeeCollectionDetail = new FeeCollectionDetail();
		objFeeCollectionDetail.RecordStatus = Convert.ToInt16(objRecordStatus);

		objFeeCollectionDetail = objFeeCollectionDetailBL.SelectFeeCollectionDetail(objFeeCollectionDetail);
		if (objFeeCollectionDetail.DbOperationStatus == CommonConstant.SUCCEED)
		{
			grdFeeCollectionDetail.DataSource = objFeeCollectionDetail.ObjectDataSet.Tables[0];
			grdFeeCollectionDetail.DataBind();
		}
		return objFeeCollectionDetail;
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
				objFeeCollectionDetail = GetObjectForInsertUpdate();
				objFeeCollectionDetailBL = new FeeCollectionDetailBL();
				if (objFeeCollectionDetail.FeeCollectionId == null)
				{
					objFeeCollectionDetail = objFeeCollectionDetailBL.InsertFeeCollectionDetail(objFeeCollectionDetail);
				}
				else
				{
					objFeeCollectionDetail = objFeeCollectionDetailBL.UpdateFeeCollectionDetail(objFeeCollectionDetail);
				}
				if (objFeeCollectionDetail.DbOperationStatus == CommonConstant.SUCCEED
							|| objFeeCollectionDetail.DbOperationStatus == CommonConstant.INVALID)
				{
					InitializeForm();
					MultiViewFeeCollectionDetail.ActiveViewIndex = 0;
				}
				UIUtility.DisplayMessage(lblMessage, objFeeCollectionDetail.DbOperationStatus);
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
			MultiViewFeeCollectionDetail.ActiveViewIndex = 0;
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
	protected void BindFeeCollectionDetailControls()
	{
		if (!Convert.ToBoolean(ViewState[isControlsLoaded]))
		{
			objStudentDetailBL = new StudentDetailBL();
			objStudentDetail = new StudentDetail();
			objStudentDetail.RecordStatus = Convert.ToInt16(RecordStatus.Active);
			objStudentDetail = objStudentDetailBL.SelectStudentDetail(objStudentDetail);
			ddlStudent.DataSource = objStudentDetail.ObjectDataSet.Tables[0];
			ddlStudent.DataBind();
			ddlStudent.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

			ViewState[isControlsLoaded] = true;
		}
	}
	protected void ActivateControlsView(bool isNewRecord, FeeCollectionDetail objFeeCollectionDetail,int? editIndex)
	{
		if (isNewRecord)
		{
			ViewState[editIndexKey] = null;
			BindFeeCollectionDetailControls();
			UIUtility.InitializeControls(ViewFeeCollectionDetailControls);
		}
		else
		{
			ViewState[editIndexKey] = editIndex;
			BindFeeCollectionDetailControls();
			PopulateControlsData(objFeeCollectionDetail);
		}
		MultiViewFeeCollectionDetail.ActiveViewIndex = 1;
	}
	private void PopulateControlsData(FeeCollectionDetail objFeeCollectionDetail)
	{
		UIUtility.SelectCurrentListItem(ddlStudent, objFeeCollectionDetail.StudentObject.StudentId, BindListItem.ByValue, true);
		txtBaseFee.Text = objFeeCollectionDetail.BaseFee.ToString();
		txtDiscountFee.Text = objFeeCollectionDetail.DiscountFee.ToString();
		txtLateFee.Text = objFeeCollectionDetail.LateFee.ToString();
		txtFine.Text = objFeeCollectionDetail.Fine.ToString();
		txtTotalFee.Text = objFeeCollectionDetail.TotalFee.ToString();
		txtPreviousBalance.Text = objFeeCollectionDetail.PreviousBalance.ToString();
		txtFeeDeposite.Text = objFeeCollectionDetail.FeeDeposite.ToString();
		txtCurrentBalance.Text = objFeeCollectionDetail.CurrentBalance.ToString();
		txtSubmitionDate.Text = objFeeCollectionDetail.SubmitionDate.ToString();
	}
	#endregion

	#region Helper Functions
	private bool ValidateObject()
	{
		return true;
	}
	private FeeCollectionDetail GetObjectForInsertUpdate()
	{
		objFeeCollectionDetail = new FeeCollectionDetail();

		if (ViewState[editIndexKey] == null)
		{
			objFeeCollectionDetail.Version = BusinessUtility.RECORD_VERSION;
			objFeeCollectionDetail.CreatedBy = LoggedInUser;
			objFeeCollectionDetail.CreatedOn = GeneralUtility.CurrentDateTime;
		}
		else
		{
			objFeeCollectionDetail.FeeCollectionId = Convert.ToInt32(grdFeeCollectionDetail.DataKeys[Convert.ToInt32(ViewState[editIndexKey])].Values[FEE_COLLECTION_ID_INDEX].ToString());
			objFeeCollectionDetail.Version = Convert.ToInt16(grdFeeCollectionDetail.DataKeys[Convert.ToInt16(ViewState[editIndexKey])].Values[VERSION_INDEX].ToString()) + 1;
		}

		if (ddlStudent.SelectedIndex != 0)
		{
			objFeeCollectionDetail.StudentObject = new StudentDetail();
			objFeeCollectionDetail.StudentObject.StudentId = Convert.ToInt32(ddlStudent.SelectedItem.Value);
		}
		objFeeCollectionDetail.BaseFee = Convert.ToDecimal(txtBaseFee.Text);
		objFeeCollectionDetail.DiscountFee = Convert.ToDecimal(txtDiscountFee.Text);
		objFeeCollectionDetail.LateFee = Convert.ToDecimal(txtLateFee.Text);
		objFeeCollectionDetail.Fine = Convert.ToDecimal(txtFine.Text);
		objFeeCollectionDetail.TotalFee = Convert.ToDecimal(txtTotalFee.Text);
		objFeeCollectionDetail.PreviousBalance = Convert.ToDecimal(txtPreviousBalance.Text);
		objFeeCollectionDetail.FeeDeposite = Convert.ToDecimal(txtFeeDeposite.Text);
		objFeeCollectionDetail.CurrentBalance = Convert.ToDecimal(txtCurrentBalance.Text);
		objFeeCollectionDetail.SubmitionDate = Convert.ToDateTime(txtSubmitionDate.Text);
		objFeeCollectionDetail.ModifiedBy = LoggedInUser;
		objFeeCollectionDetail.ModifiedOn = GeneralUtility.CurrentDateTime;
		objFeeCollectionDetail.RecordStatus = Convert.ToInt16(RecordStatus.Active);
		return objFeeCollectionDetail;
	}
	private FeeCollectionDetail GetObjectForActivateDeactivate(int editIndex,RecordStatus objStatus)
	{
		objFeeCollectionDetail = new FeeCollectionDetail();
		objFeeCollectionDetail.FeeCollectionId = Convert.ToInt32(grdFeeCollectionDetail.DataKeys[editIndex].Values[FEE_COLLECTION_ID_INDEX].ToString());
		objFeeCollectionDetail.Version = Convert.ToInt16(grdFeeCollectionDetail.DataKeys[editIndex].Values[VERSION_INDEX].ToString()) + 1;
		objFeeCollectionDetail.ModifiedBy = LoggedInUser;
		objFeeCollectionDetail.RecordStatus = Convert.ToInt16(objStatus);
		return objFeeCollectionDetail;
	}
	private FeeCollectionDetail SelectRecordById(int editIndex)
	{
		objFeeCollectionDetailBL = new FeeCollectionDetailBL();
		objFeeCollectionDetail = new FeeCollectionDetail();
		objFeeCollectionDetail.FeeCollectionId = Convert.ToInt32(grdFeeCollectionDetail.DataKeys[editIndex].Values[FEE_COLLECTION_ID_INDEX].ToString());
		objFeeCollectionDetail.Version = Convert.ToInt16(grdFeeCollectionDetail.DataKeys[editIndex].Values[VERSION_INDEX].ToString());
		objFeeCollectionDetail = objFeeCollectionDetailBL.SelectRecordById(objFeeCollectionDetail);
		return objFeeCollectionDetail;
	}
	#endregion
}
